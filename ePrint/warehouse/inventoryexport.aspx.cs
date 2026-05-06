using EPRINT;
using nmsCommon;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.warehouse
{
    public partial class inventoryexport : BaseClass, IRequiresSessionState
    {

        private Global gloobj = new Global();

        private createViewClass objCreateView = new createViewClass();

        public string pg = string.Empty;

        private InventoryBasePage obj = new InventoryBasePage();

        public int CompanyID;

        public int UserID;

        private WebExport WebObj = new WebExport();

        public int cell_packprice;

        public int cell_cost;

        public int cell_width;

        public int cell_height;

        public int cell_createddate;

        public int cell_packedin;

        public int cell_weight;

        public int cell_sizeordered;

        public string cs = string.Empty;

        public languageClass objLangClass = new languageClass();

        private commonClass objJava = new commonClass();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public inventoryexport()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect("~/warehouse/warehouse.aspx?type=inventory");
        }

        protected void btnExport_OnClick(object sender, EventArgs e)
        {
            DataTable item = this.GetEstimateData().Tables[0];
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("InventoryCode"))
                    {
                        row["InventoryCode"] = base.SpecialDecode(row["InventoryCode"].ToString());
                    }
                    if (row.Table.Columns.Contains("InventoryName"))
                    {
                        row["InventoryName"] = base.SpecialDecode(row["InventoryName"].ToString());
                    }
                    if (row.Table.Columns.Contains("FriendlyName"))
                    {
                        row["FriendlyName"] = base.SpecialDecode(row["FriendlyName"].ToString());
                    }
                    if (row.Table.Columns.Contains("SupplierName"))
                    {
                        row["SupplierName"] = base.SpecialDecode(row["SupplierName"].ToString());
                    }
                    if (row.Table.Columns.Contains("Colour"))
                    {
                        row["Colour"] = base.SpecialDecode(row["Colour"].ToString());
                    }
                    if (row.Table.Columns.Contains("Description"))
                    {
                        row["Description"] = base.SpecialDecode(row["Description"].ToString());
                    }
                    if (row.Table.Columns.Contains("Location"))
                    {
                        row["Location"] = base.SpecialDecode(row["Location"].ToString());
                    }
                    if (row.Table.Columns.Contains("Markup"))
                    {
                        row["Markup"] = base.SpecialDecode(row["Markup"].ToString());
                    }
                    if (!row.Table.Columns.Contains("CreatedDate"))
                    {
                        continue;
                    }
                    row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, true);
                }
                foreach (DataColumn column in item.Columns)
                {
                    for (int i = 0; i < item.Columns.Count; i++)
                    {
                        if (item.Columns[i].ColumnName.ToLower() == "inventorycode")
                        {
                            item.Columns[i].ColumnName = "Inventory Code";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "inventoryname")
                        {
                            item.Columns[i].ColumnName = "Inventory Name";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "friendlyname")
                        {
                            item.Columns[i].ColumnName = "Friendly Name";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "instock")
                        {
                            item.Columns[i].ColumnName = "In Stock";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "suppliername")
                        {
                            item.Columns[i].ColumnName = "Supplier Name";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "packedin")
                        {
                            item.Columns[i].ColumnName = "Packed In";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "perquantity")
                        {
                            item.Columns[i].ColumnName = "Per Quantity";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "packedprice")
                        {
                            item.Columns[i].ColumnName = "Packed Price";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "basisweight")
                        {
                            item.Columns[i].ColumnName = "Basis Weight";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "width")
                        {
                            item.Columns[i].ColumnName = "Width";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "reorderlevel")
                        {
                            item.Columns[i].ColumnName = "Reorder Level";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "reorderquantity")
                        {
                            item.Columns[i].ColumnName = "ReOrder Quantity";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "papertype")
                        {
                            item.Columns[i].ColumnName = "Paper Type";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "largeformatmaterial")
                        {
                            item.Columns[i].ColumnName = "Large Format Material";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "markup")
                        {
                            item.Columns[i].ColumnName = "Markup %";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "caliper")
                        {
                            item.Columns[i].ColumnName = "Caliper";
                        }
                        if (item.Columns[i].ColumnName.ToLower() == "createddate")
                        {
                            item.Columns[i].ColumnName = "Created Date";
                        }
                    }
                }
            }
            item.AcceptChanges();
            if (this.rdoExcelFormat.Checked)
            {
                this.WebObj.WebExportDetails(item, WebExport.ExportFormat.Excel, "InventoryExport.xls", ",");
            }
            else if (this.rdoCsvFormat.Checked)
            {
                this.WebObj.WebExportDetails(item, WebExport.ExportFormat.CSV, "InventoryExport.csv", ",");
            }
            base.Response.Redirect(string.Concat(this.strFilepath, "warehouse/inventoryexport.aspx"));
        }

        private DataSet GetEstimateData()
        {
            DataSet dataSet = new DataSet();
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            for (int i = 0; i < this.chkColumnName.Items.Count; i++)
            {
                if (this.chkColumnName.Items[i].Selected)
                {
                    if (this.chkColumnName.Items[i].Value.ToLower() == "inventoryname")
                    {
                        empty = "a.InventoryName";
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "friendlyname")
                    {
                        empty = (empty == "" ? "a.FriendlyName" : string.Concat(empty, ",a.FriendlyName"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "description")
                    {
                        empty = (empty == "" ? "a.Description" : string.Concat(empty, ",a.Description"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "inventorycode")
                    {
                        empty = (empty == "" ? "a.InventoryCode" : string.Concat(empty, ",a.InventoryCode"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "location")
                    {
                        empty = (empty == "" ? "a.Location" : string.Concat(empty, ",a.Location"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "instock")
                    {
                        empty = (empty == "" ? "a.InStock" : string.Concat(empty, ",a.InStock"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "reorderlevel")
                    {
                        empty = (empty == "" ? "a.ReorderLevel" : string.Concat(empty, ",a.ReorderLevel"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "reorderquantity")
                    {
                        empty = (empty == "" ? "a.ReOrderQuantity" : string.Concat(empty, ",a.ReOrderQuantity"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "supplierid")
                    {
                        if (empty == "")
                        {
                            empty = string.Concat("(select ISNULL(clientname,'') from tb_client b where b.clientid=a.SupplierID and b.IsDelete=0 and b.CompanyID=", this.CompanyID, ") as suppliername ");
                        }
                        else
                        {
                            object[] companyID = new object[] { empty, ",(select ISNULL(clientname,'') from tb_client b where b.clientid=a.SupplierID and b.IsDelete=0 and b.CompanyID=", this.CompanyID, ") as suppliername " };
                            empty = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "cost")
                    {
                        empty = (empty == "" ? "b.Cost" : string.Concat(empty, ",b.Cost"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "perquantity")
                    {
                        empty = (empty == "" ? "b.PerQuantity" : string.Concat(empty, ",b.PerQuantity"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "packedin")
                    {
                        empty = (empty == "" ? "b.PackedIn" : string.Concat(empty, ",b.PackedIn"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "packedprice")
                    {
                        empty = (empty == "" ? "b.PackedPrice" : string.Concat(empty, ",b.PackedPrice"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "basisweight")
                    {
                        empty = (empty == "" ? "b.BasisWeight" : string.Concat(empty, ",b.BasisWeight"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "colour")
                    {
                        empty = (empty == "" ? "b.Colour" : string.Concat(empty, ",b.Colour"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "length")
                    {
                        empty = (empty == "" ? "b.Length" : string.Concat(empty, ",b.Length"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "itempapersize")
                    {
                        if (empty == "")
                        {
                            empty = "b.PaperSizeid,b.BasisWeight,b.Colour";
                        }
                        else
                        {
                            if (!empty.Contains("BasisWeight"))
                            {
                                empty = string.Concat(empty, ",b.BasisWeight");
                            }
                            if (!empty.Contains("Colour"))
                            {
                                empty = string.Concat(empty, ",b.Colour");
                            }
                        }
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "itemcustomsize")
                    {
                        if (empty == "")
                        {
                            empty = "b.Height,b.Width,b.BasisWeight,b.Colour";
                        }
                        else
                        {
                            if (!empty.Contains("Height"))
                            {
                                empty = string.Concat(empty, ",b.Height");
                            }
                            if (!empty.Contains("Width"))
                            {
                                empty = string.Concat(empty, ",b.width");
                            }
                            if (!empty.Contains("BasisWeight"))
                            {
                                empty = string.Concat(empty, ",b.BasisWeight");
                            }
                            if (!empty.Contains("Colour"))
                            {
                                empty = string.Concat(empty, ",b.Colour");
                            }
                        }
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "papertype")
                    {
                        empty = (empty == "" ? "b.PaperType" : string.Concat(empty, ",b.PaperType"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "largeformatmaterial")
                    {
                        empty = (empty == "" ? "case when a.IsLargeFormatMaterial=1 then 'Yes' else 'No' end as LargeFormatMaterial" : string.Concat(empty, ", case when a.IsLargeFormatMaterial=1 then 'Yes' else 'No' end as LargeFormatMaterial"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "coated")
                    {
                        empty = (empty == "" ? "b.Coated" : string.Concat(empty, ",b.Coated"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "createddate")
                    {
                        empty = (empty == "" ? " CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate " : string.Concat(empty, ", CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate "));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "markup")
                    {
                        empty = (empty == "" ? "b.Markup" : string.Concat(empty, ",b.Markup"));
                    }
                    if (this.chkColumnName.Items[i].Value.ToLower() == "caliper")
                    {
                        empty = (empty == "" ? "b.Caliper" : string.Concat(empty, ",b.Caliper"));
                    }
                }
            }
            object[] objArray = new object[] { "Select ", empty, " from tb_inventory a,tb_inventoryproperties b where a.companyid=", this.CompanyID, " and a.InventoryID=b.InventoryID and a.IsDeleted=0 " };
            str = string.Concat(objArray);
            if (this.ddlInvCategory.SelectedIndex != 0)
            {
                str = string.Concat(str, "and (a.InventoryCategoryID like '", base.ReplaceSingleQuote(this.ddlInvCategory.SelectedValue), "')");
            }
            str = string.Concat(str, " and ISNULL(a.Inventorycategoryid,0)>0 order by a.inventorycode");
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            (new SqlDataAdapter(str, sqlConnection)).Fill(dataSet);
            for (int j = 0; j < dataSet.Tables[0].Columns.Count; j++)
            {
                dataSet.Tables[0].Columns[j].ReadOnly = false;
            }
            return dataSet;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("warehouse", "exportorimport", "");
            global.pageName = "Warehouse";
            global.pgName = "";
            this.gloobj.setpagename("Warehouse");
            this.pg = "inventory";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href='../warehouse/warehouse.aspx?type=inventory' class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Inventory_Export")));
            base.Title = this.objLanguage.convert(global.pageTitle("Inventory Export", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            if (!base.IsPostBack)
            {
                this.obj.Bind_Stock_Category(this.ddlInvCategory, this.CompanyID, "----- All -----");
                this.ddlInvCategory.AutoPostBack = false;
                this.ddlInvCategory.SelectedIndex = 0;
            }
            this.rdoExcelFormat.Text = this.objLangClass.GetLanguageConversion("Excel");
            this.rdoCsvFormat.Text = this.objLangClass.GetLanguageConversion("CSV");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnExport.Text = this.objLangClass.GetLanguageConversion("Export");
            this.chkColumnName.Items[0].Text = this.objLangClass.GetLanguageConversion("Inventory_Name");
            this.chkColumnName.Items[1].Text = this.objLangClass.GetLanguageConversion("Friendly_Name");
            this.chkColumnName.Items[2].Text = this.objLangClass.GetLanguageConversion("Description");
            this.chkColumnName.Items[3].Text = this.objLangClass.GetLanguageConversion("Inventory_Code");
            this.chkColumnName.Items[4].Text = this.objLangClass.GetLanguageConversion("Location");
            this.chkColumnName.Items[5].Text = this.objLangClass.GetLanguageConversion("In_Stock");
            this.chkColumnName.Items[6].Text = this.objLangClass.GetLanguageConversion("ReOrder_Alert_Level");
            this.chkColumnName.Items[7].Text = this.objLangClass.GetLanguageConversion("ReOrder_Quantity");
            this.chkColumnName.Items[8].Text = this.objLangClass.GetLanguageConversion("Supplier");
            this.chkColumnName.Items[9].Text = this.objLangClass.GetLanguageConversion("Cost");
            this.chkColumnName.Items[10].Text = this.objLangClass.GetLanguageConversion("Per_Quantity");
            this.chkColumnName.Items[11].Text = this.objLangClass.GetLanguageConversion("Packed_In");
            this.chkColumnName.Items[12].Text = this.objLangClass.GetLanguageConversion("Pack_Price");
            this.chkColumnName.Items[13].Text = this.objLangClass.GetLanguageConversion("Weight");
            this.chkColumnName.Items[14].Text = this.objLangClass.GetLanguageConversion("Colour");
            this.chkColumnName.Items[15].Text = this.objLangClass.GetLanguageConversion("Length");
            this.chkColumnName.Items[16].Text = this.objLangClass.GetLanguageConversion("Item_Paper_Size");
            this.chkColumnName.Items[17].Text = this.objLangClass.GetLanguageConversion("Item_Custom_Size");
            this.chkColumnName.Items[18].Text = this.objLangClass.GetLanguageConversion("Paper_Type_Text");
            this.chkColumnName.Items[19].Text = this.objLangClass.GetLanguageConversion("Large_Format_Material");
            this.chkColumnName.Items[20].Text = this.objLangClass.GetLanguageConversion("Coating_Type");
            this.chkColumnName.Items[21].Text = this.objLangClass.GetLanguageConversion("Created_On");
            this.chkColumnName.Items[22].Text = this.objLangClass.GetLanguageConversion("Caliper");
        }
    }
}