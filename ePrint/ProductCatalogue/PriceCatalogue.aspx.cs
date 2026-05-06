using iTextSharp.text.pdf;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint
{
    public partial class PriceCatalogue : BaseClass, IRequiresSessionState
    {
        //protected ScriptManagerProxy SMproxy;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected PlaceHolder plhAccountList;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected LinkButton lnk_load;

        //protected Label lblFilterByCategory;

        //protected DropDownList ddlCategorySelect;

        //protected LinkButton btnclrFilters;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkOrderedit;

        //protected Label lblChange;

        //protected Label lbl_CurrentView;

        //protected Label lblView;

        //protected RadMenu RadMenu1;

        //protected HtmlGenericControl df;

        //protected HiddenField hdnGridPriceCatalogueRadGrid;

        //protected HiddenField hdnDbID;

        //protected RadGrid GridPriceCatalogue;

        //protected HtmlGenericControl div_Main;

        //protected Button btnsavemultiple;

        //protected HiddenField hdn_Customers;

        //protected RadWindowManager RadWinCustomer;

        //protected HtmlGenericControl divgrd;

        //protected LinkButton lnkDelete;

        //protected Button lnkCopy;

        //protected HiddenField hdnProcessedId;

        //protected HiddenField hid_PO_values;

        //protected HiddenField editOrderViewID;

        //protected Panel pnlLoadOnEdit;

        //protected HiddenField hid_ddlMatrixType;

        //protected HiddenField hid_gridid_orderno;

        //protected HiddenField hidGridCount;

        //protected HiddenField hid_Delete_IDs;

        //protected HiddenField hid_visible_invisible_IDs;

        //protected RadWindowManager RadWindowManager1;

        //protected Panel pnlShowMsg;

        public int defaultviewid;

        public int totalrec;

        private string para = string.Empty;

        public static string WhereCondition;

        public static string SortedBy;

        public static string sortdirection;

        private createViewClass objCreateView = new createViewClass();

        public string pg;

        public string cellvalue_categoryname = string.Empty;

        public string flag_categoryname = string.Empty;

        public string cellvalue_itemtitle = string.Empty;

        public string flag_itemtitle = string.Empty;

        public string cellvalue_description = string.Empty;

        public string flag_description = string.Empty;

        public string cellvalue_allocatedcustomer = string.Empty;

        public string flag_allocatedcustomer = string.Empty;

        public string cellvalue_publicaccounts = string.Empty;

        public string flag_publicaccounts = string.Empty;

        public string cellvalue_producttype = string.Empty;

        public string flag_producttype = string.Empty;

        public string cellvalue_Action = string.Empty;

        public string flag_Action = string.Empty;

        public string cellvalue_CustomerCode = string.Empty;

        public string flag_CustomerCode = string.Empty;

        public string cellvalue_ItemCode = string.Empty;

        public string flag_ItemCode = string.Empty;

        public string cellvalue_SalesTaxRate = string.Empty;

        public string flag_SalesTaxRate = string.Empty;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public languageClass objlang = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        public int CompanyID;

        public int UserID;

        public int count; 

        public string action = "add";

        private commonClass objJava = new commonClass();

        public int ClientID;

        public int PageIndex = 1;

        private int sortcount;

        public string colorformat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public string DateFormat = string.Empty;

        public string WebStore = string.Empty;

        public long PriceCatalogueID;

        public string StrCustom = string.Empty;

        public string FilterCondition = "";

        public string EditableTemplateURL = string.Empty;

        public string EditableTemplatePath = string.Empty;

        public static int PageSize;

        public string EditableTemplate = ConnectionClass.EditableTemplate;

        public DataTable dt = new DataTable();

        public int ViewID;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string XeroConnectKey = string.Empty;

        public long DbID;

        public string AddStatus = string.Empty;

        public string DeleteStatus = string.Empty;


        //-----------------------------------------------

        public string cellvalue_Artwork = string.Empty;
        public string flag_Artwork = string.Empty;

        public string cellvalue_Color = string.Empty;
        public string flag_Color = string.Empty;

        public string cellvalue_Size = string.Empty;
        public string flag_Size = string.Empty;

        public string cellvalue_Material = string.Empty;
        public string flag_Material = string.Empty;

        public string cellvalue_Delivery = string.Empty;
        public string flag_Delivery = string.Empty;

        public string cellvalue_Finishing = string.Empty;
        public string flag_Finishing = string.Empty;

        public string cellvalue_Proofs = string.Empty;
        public string flag_Proofs = string.Empty;

        public string cellvalue_Packing = string.Empty;
        public string flag_Packing = string.Empty;

        public string cellvalue_Notes = string.Empty;
        public string flag_Notes = string.Empty;
        //-----------------------------------------------

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

        static PriceCatalogue()
        {
            PriceCatalogue.WhereCondition = string.Empty;
            PriceCatalogue.SortedBy = string.Empty;
            PriceCatalogue.sortdirection = string.Empty;
            PriceCatalogue.ManageStockPermission = 0;
            PriceCatalogue.PageSize = 50;
        }

        public PriceCatalogue()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridPriceCatalogue.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "action")
                    {
                        gridBoundColumn.AllowFiltering = false;
                    }
                }
                for (int j = 0; j < this.GridPriceCatalogue.Columns.Count; j++)
                {
                    this.GridPriceCatalogue.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridPriceCatalogue.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "pricecatalogueid")
                    {
                        this.GridPriceCatalogue.Columns[j].Visible = false;
                    }
                    if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "categoryname")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Category_Name");
                        this.flag_categoryname = "true";
                        this.cellvalue_categoryname = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_itemtitle = "true";
                        this.cellvalue_itemtitle = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "description")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Description");
                        this.flag_description = "true";
                        this.cellvalue_description = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "allocatedcustomer")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Allocated_Customer");
                        this.flag_allocatedcustomer = "true";
                        this.cellvalue_allocatedcustomer = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "publicaccounts")
                    {
                        if (this.WebStore.ToLower() != "yes")
                        {
                            this.GridPriceCatalogue.Columns[j].Visible = false;
                        }
                        else
                        {
                            this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Public_Accounts");
                            this.flag_publicaccounts = "true";
                            this.cellvalue_publicaccounts = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                            this.GridPriceCatalogue.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        }
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "producttype")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Product_Type");
                        this.flag_producttype = "true";
                        this.cellvalue_producttype = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "customercode")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("P_Customer_Code");
                        this.flag_CustomerCode = "true";
                        this.cellvalue_CustomerCode = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemcode")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Code");
                        this.flag_ItemCode = "true";
                        this.cellvalue_ItemCode = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "salestax")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Tax");
                        this.flag_SalesTaxRate = "true";
                        this.cellvalue_SalesTaxRate = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "action")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                        this.flag_Action = "true";
                        this.cellvalue_Action = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                        this.GridPriceCatalogue.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridPriceCatalogue.HeaderStyle.Width = Unit.Pixel(100);
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Artwork");
                        this.flag_Artwork = "true";
                        this.cellvalue_Artwork = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Colour");
                        this.flag_Color = "true";
                        this.cellvalue_Color = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Size");
                        this.flag_Size = "true";
                        this.cellvalue_Size = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Material");
                        this.flag_Material = "true";
                        this.cellvalue_Material = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery");
                        this.flag_Delivery = "true";
                        this.cellvalue_Delivery = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Finishing");
                        this.flag_Finishing = "true";
                        this.cellvalue_Finishing = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proofs");
                        this.flag_Proofs = "true";
                        this.cellvalue_Proofs = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Packing");
                        this.flag_Packing = "true";
                        this.cellvalue_Packing = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.GridPriceCatalogue.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Notes");
                        this.flag_Notes = "true";
                        this.cellvalue_Notes = this.GridPriceCatalogue.Columns[j].SortExpression.ToLower();
                    }
                }
            }
        }

        public void Bind_ddlCategorySelectedcategory()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            DataSet dataSet = SettingsBasePage.Bindddl_SelectedCategory(this.CompanyID);
            this.ddlCategorySelect.DataSource = dataSet.Tables[0];
            this.ddlCategorySelect.DataTextField = "PriceCatalogueCategoryName";
            this.ddlCategorySelect.DataValueField = "PriceCatalogueCategoryid";
            this.ddlCategorySelect.DataBind();
            this.ddlCategorySelect.Items.Insert(0, new ListItem("All", "0"));
        }

        public void btnEditViewOrder_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../productcatalogue/customviewproduct.aspx?type=edit&id=", this.editOrderViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        protected void btnsavemultiple_onclick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdn_Customers.Value.Split(new char[] { ',' });
            int num = 0;
            for (int i = 0; i < this.GridPriceCatalogue.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridPriceCatalogue.Items[i].Cells[0].FindControl("checkBox_Copy1");
                if (htmlInputCheckBox.Checked)
                {
                    num = Convert.ToInt32(htmlInputCheckBox.Value);
                    for (int j = 0; j < (int)strArrays.Length; j++)
                    {
                        if (strArrays[j] != "")
                        {
                            WebstoreBasePage.PriceCatalogueCustomer_Insert(Convert.ToInt64(num), Convert.ToInt64(strArrays[j]), (long)0, "S");
                        }
                    }
                }
            }
            this.GridPriceCatalogue.Rebind();
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("product_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("product_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            this.Session["GridPriceCataloguesearchFilter"] = null;
            this.Session["GridPriceCatalogueFilterCondition"] = null;
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, PriceCatalogue.SortedBy, PriceCatalogue.sortdirection, PriceCatalogue.WhereCondition);
            foreach (GridColumn column in this.GridPriceCatalogue.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
                if (this.Session[string.Concat("product_", column.UniqueName)] == null)
                {
                    continue;
                }
                this.Session[string.Concat("product_", column.UniqueName)] = "";
            }
            this.GridPriceCatalogue.MasterTableView.FilterExpression = string.Empty;
            this.GridPriceCatalogue.MasterTableView.Rebind();
        }

        protected void ddlCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["Category"] = this.ddlCategorySelect.SelectedValue;
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, "CategoryName", "asc", "");
            this.GridPriceCatalogue.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpCookie httpCookie = new HttpCookie("ckeEditviewID_product");
            httpCookie["product_viewID"] = this.ddl_View.SelectedValue;
            base.Response.Cookies.Add(httpCookie);
            foreach (GridColumn column in this.GridPriceCatalogue.MasterTableView.Columns)
            {
                if (this.Session[string.Concat("product_", column.UniqueName)] == null)
                {
                    continue;
                }
                this.Session[string.Concat("product_", column.UniqueName)] = "";
            }
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "productcatalogue/pricecatalogue.aspx?viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
        }

        public bool GetStockValue(long PriceCatalogueID)
        {
            DataTable isStockValue = SettingsBasePage.getIsStock_Value(PriceCatalogueID);
            return Convert.ToBoolean(isStockValue.Rows[0]["IsStockItem"].ToString());
        }

        public long GetTemplateID(long PriceCatalogueID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();
            commonClass _commonClass = new commonClass();
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(str, CommandType.StoredProcedure, "et_TemplateID_By_PriceCatalogueID", sqlParameterArray);
            return Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        protected void GridAllocatedCust_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            GridTableView masterTableView = this.GridPriceCatalogue.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("div_AddNewRecord");
            if (this.AddStatus.Trim().ToLower() != "false")
            {
                htmlControl.Visible = true;
                this.RadMenu1.Items[0].Visible = true;
            }
            else
            {
                htmlControl.Visible = false;
                this.RadMenu1.Items[0].Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridPriceCatalogue.Columns.Count; i++)
                {
                    this.GridPriceCatalogue.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridPriceCatalogue.Columns[i].HeaderStyle.Wrap = false;
                    if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "pricecatalogueid")
                    {
                        this.GridPriceCatalogue.Columns[i].Visible = false;
                    }
                    if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "categoryname")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Category_Name");
                        this.flag_categoryname = "true";
                        this.cellvalue_categoryname = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_itemtitle = "true";
                        this.cellvalue_itemtitle = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "description")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Description");
                        this.flag_description = "true";
                        this.cellvalue_description = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "allocatedcustomer")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Allocated_Customer");
                        this.flag_allocatedcustomer = "true";
                        this.cellvalue_allocatedcustomer = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "publicaccounts")
                    {
                        if (this.WebStore.ToLower() != "yes")
                        {
                            this.GridPriceCatalogue.Columns[i].Visible = false;
                        }
                        else
                        {
                            this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Public_Accounts");
                            this.flag_publicaccounts = "true";
                            this.cellvalue_publicaccounts = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                            this.GridPriceCatalogue.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        }
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "producttype")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Product_Type");
                        this.flag_producttype = "true";
                        this.cellvalue_producttype = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "customercode")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("P_Customer_Code");
                        this.flag_CustomerCode = "true";
                        this.cellvalue_CustomerCode = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "itemcode")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Item_Code");
                        this.flag_ItemCode = "true";
                        this.cellvalue_ItemCode = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "salestax")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Tax");
                        this.flag_SalesTaxRate = "true";
                        this.cellvalue_SalesTaxRate = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "action")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Action");
                        this.flag_Action = "true";
                        this.cellvalue_Action = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                        this.GridPriceCatalogue.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridPriceCatalogue.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.GridPriceCatalogue.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Artwork");
                        this.flag_Artwork = "true";
                        this.cellvalue_Artwork = this.GridPriceCatalogue.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnPriceCatalogueID");
                string str = string.Concat("ProductCatalogue_item.aspx?action=edit&id=", hiddenField.Value);
                if (this.flag_categoryname == "true")
                {
                    //item[this.cellvalue_categoryname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_categoryname].Style.Add("cursor", "pointer");


                    //item[this.cellvalue_categoryname].Attributes.Add("align", "center");

                    if (item["categoryname"].Text == "Multiple")
                    {

                        item[this.cellvalue_categoryname].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_categoryname].Attributes.Add("onclick",
                           string.Concat("javascript:AddMultipleCategories('", Convert.ToInt64(item["pricecatalogueid"].Text), "','", this.CompanyID, "','0','0','FromGrid',);"));
                    }
                    //this.imgbtnaddcategory.Attributes.Add("onclick", string.Concat("javascript:AddMultipleCategories('", this.ProductCatalogueID, "','", this.CompanyID, "','0','0','order',);"));


                }
                if (this.flag_itemtitle == "true")
                {
                    item[this.cellvalue_itemtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_itemtitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_description == "true")
                {
                    if (item[this.cellvalue_description].Text != "")
                    {
                        item[this.cellvalue_description].ToolTip = item[this.cellvalue_description].Text;
                    }
                    if (item[this.cellvalue_description].Text.Length > 125)
                    {
                        item[this.cellvalue_description].Text = string.Concat(item[this.cellvalue_description].Text.Substring(0, 50), "....");
                    }
                    item[this.cellvalue_description].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_description].Style.Add("cursor", "pointer");
                }
                if (this.flag_allocatedcustomer == "true")
                {
                    Label label = new Label()
                    {
                        ID = string.Concat("lbl_", this.cellvalue_allocatedcustomer),
                        Text = string.Concat(item[this.cellvalue_allocatedcustomer].Text, " ")
                    };
                    label.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_allocatedcustomer].Style.Add("cursor", "pointer");
                    item[this.cellvalue_allocatedcustomer].Controls.Clear();
                    Image image = new Image()
                    {
                        ID = string.Concat("img_", this.cellvalue_allocatedcustomer),
                        ImageUrl = "~/images/invoiced-paid.PNG"
                    };
                    image.Attributes.Add("onclick", string.Concat("javascript:OpenCustomer_List('", hiddenField.Value, "');"));
                    item[this.cellvalue_allocatedcustomer].Controls.Add(label);
                    if (item[this.cellvalue_allocatedcustomer].Text.ToLower() == "allocated")
                    {
                        item[this.cellvalue_allocatedcustomer].Controls.Add(image);
                    }
                }
                if (this.flag_publicaccounts == "true")
                {
                    if (item[this.cellvalue_publicaccounts].Text != "")
                    {
                        item[this.cellvalue_publicaccounts].ToolTip = item[this.cellvalue_publicaccounts].Text;
                    }
                    if (item[this.cellvalue_publicaccounts].Text.Length > 125)
                    {
                        item[this.cellvalue_publicaccounts].Text = string.Concat(item[this.cellvalue_publicaccounts].Text.Substring(0, 50), "....");
                    }
                    item[this.cellvalue_publicaccounts].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_publicaccounts].Style.Add("cursor", "pointer");
                }
                if (this.flag_producttype == "true")
                {
                    item[this.cellvalue_producttype].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_producttype].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomerCode == "true")
                {
                    item[this.cellvalue_CustomerCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomerCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemCode == "true")
                {
                    item[this.cellvalue_ItemCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_Action == "true")
                {
                    item[this.cellvalue_Action].Attributes.Add("align", "right");
                    item[this.cellvalue_Action].Controls.Clear();
                    ImageButton imageButton = new ImageButton()
                    {
                        ID = "imgbtnDelete",
                        CommandArgument = hiddenField.Value,
                        ImageUrl = "~/images/erase.png",
                        ToolTip = this.objlang.GetLanguageConversion("Delete"),
                        OnClientClick = string.Concat("javascript:return EraseCheck('", hiddenField.Value, "');")
                    };
                    item[this.cellvalue_Action].Controls.Add(imageButton);
                    ImageButton imageButton1 = new ImageButton()
                    {
                        ID = "imgbtnCopy",
                        CommandArgument = hiddenField.Value,
                        ImageUrl = "~/images/copy.png",
                        ToolTip = this.objlang.GetLanguageConversion("Copy"),
                        OnClientClick = string.Concat("javascript:Copy('", hiddenField.Value, "')")
                    };
                    imageButton1.Attributes.Add("Style", "margin-left:5px");
                    item[this.cellvalue_Action].Controls.Add(imageButton1);
                    ImageButton languageConversion = new ImageButton()
                    {
                        ID = "imgCreateTemplate",
                        CommandArgument = hiddenField.Value,
                        ImageUrl = "~/images/Autocrop.jpg",
                        ToolTip = this.objlang.GetLanguageConversion("Setup_Template")
                    };
                    languageConversion.Attributes.Add("Style", "margin-left:5px");
                    item[this.cellvalue_Action].Controls.Add(languageConversion);
                    ImageButton imageButton2 = new ImageButton()
                    {
                        ID = "imgStockEdit",
                        CommandArgument = hiddenField.Value,
                        ImageUrl = "~/images/Stocksimg.png",
                        ToolTip = this.objlang.GetLanguageConversion("Manage_Stock")
                    };
                    imageButton2.Attributes.Add("Style", "margin-left:5px");
                    item[this.cellvalue_Action].Controls.Add(imageButton2);
                    if (this.DeleteStatus.Trim().ToLower() != "false")
                    {
                        imageButton.Visible = true;
                    }
                    else
                    {
                        imageButton.Visible = false;
                    }
                    if (this.AddStatus.Trim().ToLower() != "false")
                    {
                        imageButton1.Visible = true;
                        this.RadMenu1.Items[0].Visible = true;
                    }
                    else
                    {
                        imageButton1.Visible = false;
                        this.RadMenu1.Items[0].Visible = false;
                    }
                    long templateID = this.GetTemplateID(Convert.ToInt64(hiddenField.Value));
                    object[] value = new object[] { "templateid=", templateID, "&pricecatalogid=", hiddenField.Value, "&companyid=", this.CompanyID, "&userid=", this.UserID, "&dbkey=", this.XeroConnectKey };
                    string str1 = commonClass.Encrypt(string.Concat(value));
                    string str2 = string.Concat(this.EditableTemplateURL, "editableproduct.aspx?", str1);
                    if (templateID <= (long)0)
                    {
                        languageConversion.Visible = false;
                        if (ConnectionClass.EditableTemplate != null && ConnectionClass.EditableTemplate.ToLower() == "on")
                        {
                            DataSet dataSet = SettingsBasePage.IsConverted_IsCorped(Convert.ToInt64(hiddenField.Value), Convert.ToInt32(this.DbID));
                            foreach (DataRow row in dataSet.Tables[0].Rows)
                            {
                                if (!(row["IsConverted"].ToString() == "0") || !(row["isPdforCropMarkChanged"].ToString() == "1"))
                                {
                                    if (!(row["IsConverted"].ToString() == "2") || !(row["isPdforCropMarkChanged"].ToString() == "1"))
                                    {
                                        continue;
                                    }
                                    languageConversion.Visible = true;
                                    languageConversion.ToolTip = this.objlang.GetLanguageConversion("Background_Not_ready");
                                    object[] objArray = new object[] { "javascript:Onclick_editImage('", str2, "','", hiddenField.Value, "','", this.DbID, "');return false;" };
                                    languageConversion.OnClientClick = string.Concat(objArray);
                                }
                                else
                                {
                                    languageConversion.Visible = true;
                                    languageConversion.ToolTip = this.objlang.GetLanguageConversion("Background_Not_ready");
                                    object[] value1 = new object[] { "javascript:Onclick_editImage('", str2, "','", hiddenField.Value, "','", this.DbID, "');return false;" };
                                    languageConversion.OnClientClick = string.Concat(value1);
                                }
                            }
                        }
                    }
                    else if (ConnectionClass.EditableTemplate == null)
                    {
                        languageConversion.Visible = false;
                    }
                    else if (ConnectionClass.EditableTemplate.ToLower() != "on")
                    {
                        languageConversion.Visible = false;
                    }
                    else if (!SettingsBasePage.GetEditableTemplate_Value(Convert.ToInt64(hiddenField.Value)))
                    {
                        languageConversion.Visible = false;
                    }
                    else
                    {
                        languageConversion.Visible = true;
                        object[] objArray1 = new object[] { "javascript:Onclick_editImage('", str2, "','", hiddenField.Value, "','", this.DbID, "');return false;" };
                        languageConversion.OnClientClick = string.Concat(objArray1);
                    }
                    bool stockValue = this.GetStockValue(Convert.ToInt64(hiddenField.Value));
                    imageButton2.Attributes.Add("onclick", string.Concat("javascript:editstock('", hiddenField.Value, "');return false;"));
                    if (PriceCatalogue.ManageStockPermission != 1)
                    {
                        imageButton2.Visible = false;
                    }
                    else if (!stockValue)
                    {
                        imageButton2.Visible = false;
                    }
                    else
                    {
                        imageButton2.Visible = true;
                    }
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_categoryname == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_categoryname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_categoryname)] != null)
                    {
                        textBox.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_categoryname)].ToString());
                    }
                }
                if (this.flag_itemtitle == "true")
                {
                    TextBox item1 = (e.Item as GridFilteringItem)[this.cellvalue_itemtitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_itemtitle)] != null)
                    {
                        item1.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_itemtitle)].ToString());
                    }
                }
                if (this.flag_producttype == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_producttype].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_producttype)] != null)
                    {
                        textBox1.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_producttype)].ToString());
                    }
                }
                if (this.flag_allocatedcustomer == "true")
                {
                    TextBox item2 = (e.Item as GridFilteringItem)[this.cellvalue_allocatedcustomer].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_allocatedcustomer)] != null)
                    {
                        item2.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_allocatedcustomer)].ToString());
                    }
                }
                if (this.flag_CustomerCode == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_CustomerCode].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_CustomerCode)] != null)
                    {
                        textBox2.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_CustomerCode)].ToString());
                    }
                }
                if (this.flag_description == "true")
                {
                    TextBox item3 = (e.Item as GridFilteringItem)[this.cellvalue_description].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_description)] != null)
                    {
                        item3.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_description)].ToString());
                    }
                }
                if (this.flag_ItemCode == "true")
                {
                    TextBox str3 = (e.Item as GridFilteringItem)[this.cellvalue_ItemCode].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_ItemCode)] != null)
                    {
                        str3.Text = this.Session[string.Concat("product_", this.cellvalue_ItemCode)].ToString();
                    }
                }
                if (this.flag_publicaccounts == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_publicaccounts].Controls[0] as TextBox;
                    if (this.Session[string.Concat("product_", this.cellvalue_publicaccounts)] != null)
                    {
                        textBox3.Text = base.SpecialDecode(this.Session[string.Concat("product_", this.cellvalue_publicaccounts)].ToString());
                    }
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridPriceCatalogue.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridPriceCatalogue.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int defaultviewid, string SortedBy, string SortDirection, string para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, "productcatalogue", defaultviewid, SortedBy, SortDirection, para);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@strSQL", empty);
            sqlCommand.CommandTimeout = Int32.MaxValue;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            _commonClass.closeConnection();
            this.GridPriceCatalogue.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridPriceCatalogue);
                this.div_Main.Style.Add("display", "block");
                this.GridPriceCatalogue.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridPriceCatalogue);
            this.div_Main.Style.Add("display", "block");
            this.GridPriceCatalogue.AllowCustomPaging = true;
            this.GridPriceCatalogue.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        protected void GridPriceCatalogu_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridPriceCatalogue.CurrentPageIndex = e.NewPageIndex;
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, "CategoryName", "asc", "");
            this.GridPriceCatalogue.Rebind();
        }

        protected void GridPriceCatalogue_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string empty = string.Empty;
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = base.SpecialEncode(item.Text);
                this.FilterCondition = "";
                string empty1 = string.Empty;
                string str1 = string.Empty;
                if (this.Session["GridPriceCataloguesearchFilter"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["GridPriceCataloguesearchFilter"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["GridPriceCataloguesearchFilter"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length > 0)
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        if (item.Text != "")
                        {
                            empty = item.Text.Trim();
                        }
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, empty };
                        this.dtsearch.Rows.Add(second);
                    }
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                else if (commandArgument.First.ToString().ToLower() != "nofilter")
                {
                    if (item.Text != "")
                    {
                        empty = item.Text.Trim();
                    }
                    object[] objArray = new object[] { commandArgument.Second, commandArgument.First, empty };
                    this.dtsearch.Rows.Add(objArray);
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                if (commandArgument.First.ToString().ToLower() == "nofilter" && this.dtsearch.Rows.Count == 0)
                {
                    this.GridPriceCatalogue.MasterTableView.FilterExpression = string.Empty;
                    GridColumn[] renderColumns = this.GridPriceCatalogue.MasterTableView.RenderColumns;
                    for (int i = 0; i < (int)renderColumns.Length; i++)
                    {
                        GridColumn gridColumn = renderColumns[i];
                        if (gridColumn.SupportsFiltering())
                        {
                            gridColumn.CurrentFilterValue = string.Empty;
                            gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                        }
                    }
                }
                this.Session["GridPriceCataloguesearchFilter"] = this.dtsearch;
                foreach (DataRow row in this.dtsearch.Rows)
                {
                    if (row["filter"].ToString().ToLower() != "nofilter" && this.FilterCondition != "")
                    {
                        PriceCatalogue productCataloguePriceCatalogue = this;
                        productCataloguePriceCatalogue.FilterCondition = string.Concat(productCataloguePriceCatalogue.FilterCondition, " and ");
                    }
                    empty1 = (row["ColumnName"].ToString().Trim().ToLower() != "description" ? row["ColumnName"].ToString() : row["ColumnName"].ToString());
                    str1 = row["FilterText"].ToString();
                    if (str1.Length > 200)
                    {
                        str1 = str1.Substring(0, 200);
                    }
                    string lower = row["filter"].ToString().ToLower();
                    string str2 = lower;
                    if (lower == null)
                    {
                        continue;
                    }
                    if (str2 == "startswith")
                    {
                        if (empty1.Trim().ToLower() == "allocatedcustomer")
                        {
                            if (str1.Trim().ToLower() == "allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue1 = this;
                                productCataloguePriceCatalogue1.FilterCondition = string.Concat(productCataloguePriceCatalogue1.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                            }
                            else if (str1.Trim().ToLower() != "not allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue2 = this;
                                object filterCondition = productCataloguePriceCatalogue2.FilterCondition;
                                object[] companyID = new object[] { filterCondition, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName like '", str1, "%' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                                productCataloguePriceCatalogue2.FilterCondition = string.Concat(companyID);
                            }
                            else
                            {
                                PriceCatalogue productCataloguePriceCatalogue3 = this;
                                productCataloguePriceCatalogue3.FilterCondition = string.Concat(productCataloguePriceCatalogue3.FilterCondition, " allocatedcustomer like '%not allocated%'");
                            }
                        }
                        else if (empty1.Trim().ToLower() != "publicaccounts")
                        {
                            PriceCatalogue productCataloguePriceCatalogue4 = this;
                            string filterCondition1 = productCataloguePriceCatalogue4.FilterCondition;
                            string[] strArrays = new string[] { filterCondition1, " ", empty1, " like '", str1, "%'" };
                            productCataloguePriceCatalogue4.FilterCondition = string.Concat(strArrays);
                        }
                        else if (str1.Trim().ToLower() != "not allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue5 = this;
                            object obj = productCataloguePriceCatalogue5.FilterCondition;
                            object[] companyID1 = new object[] { obj, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname like '", str1, "%' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                            productCataloguePriceCatalogue5.FilterCondition = string.Concat(companyID1);
                        }
                        else
                        {
                            PriceCatalogue productCataloguePriceCatalogue6 = this;
                            productCataloguePriceCatalogue6.FilterCondition = string.Concat(productCataloguePriceCatalogue6.FilterCondition, " publicaccounts  like '%not allocated%'");
                        }
                    }
                    else if (str2 == "endswith")
                    {
                        if (empty1.Trim().ToLower() == "allocatedcustomer")
                        {
                            if (str1.Trim().ToLower() == "allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue7 = this;
                                productCataloguePriceCatalogue7.FilterCondition = string.Concat(productCataloguePriceCatalogue7.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                            }
                            else if (str1.Trim().ToLower() != "not allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue8 = this;
                                object obj1 = productCataloguePriceCatalogue8.FilterCondition;
                                object[] objArray1 = new object[] { obj1, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName like '%", str1, "' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                                productCataloguePriceCatalogue8.FilterCondition = string.Concat(objArray1);
                            }
                            else
                            {
                                PriceCatalogue productCataloguePriceCatalogue9 = this;
                                productCataloguePriceCatalogue9.FilterCondition = string.Concat(productCataloguePriceCatalogue9.FilterCondition, " allocatedcustomer like '%not allocated%'");
                            }
                        }
                        else if (empty1.Trim().ToLower() != "publicaccounts")
                        {
                            PriceCatalogue productCataloguePriceCatalogue10 = this;
                            string filterCondition2 = productCataloguePriceCatalogue10.FilterCondition;
                            string[] strArrays1 = new string[] { filterCondition2, " ", empty1, " like '%", str1, "'" };
                            productCataloguePriceCatalogue10.FilterCondition = string.Concat(strArrays1);
                        }
                        else if (str1.Trim().ToLower() != "not allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue11 = this;
                            object obj2 = productCataloguePriceCatalogue11.FilterCondition;
                            object[] companyID2 = new object[] { obj2, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname like '%", str1, "' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                            productCataloguePriceCatalogue11.FilterCondition = string.Concat(companyID2);
                        }
                        else
                        {
                            PriceCatalogue productCataloguePriceCatalogue12 = this;
                            productCataloguePriceCatalogue12.FilterCondition = string.Concat(productCataloguePriceCatalogue12.FilterCondition, " publicaccounts  like '%not allocated%'");
                        }
                    }
                    else if (str2 == "contains")
                    {
                        if (empty1.Trim().ToLower() == "allocatedcustomer")
                        {
                            if (str1.Trim().ToLower() == "allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue13 = this;
                                productCataloguePriceCatalogue13.FilterCondition = string.Concat(productCataloguePriceCatalogue13.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                            }
                            else if (str1.Trim().ToLower() != "not allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue14 = this;
                                object filterCondition3 = productCataloguePriceCatalogue14.FilterCondition;
                                object[] objArray2 = new object[] { filterCondition3, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName like '%", str1, "%' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                                productCataloguePriceCatalogue14.FilterCondition = string.Concat(objArray2);
                            }
                            else
                            {
                                PriceCatalogue productCataloguePriceCatalogue15 = this;
                                productCataloguePriceCatalogue15.FilterCondition = string.Concat(productCataloguePriceCatalogue15.FilterCondition, " allocatedcustomer like '%not allocated%'");
                            }
                        }
                        else if (empty1.Trim().ToLower() != "publicaccounts")
                        {
                            PriceCatalogue productCataloguePriceCatalogue16 = this;
                            string str3 = productCataloguePriceCatalogue16.FilterCondition;
                            string[] strArrays2 = new string[] { str3, " ", empty1, " like '%", str1, "%'" };
                            productCataloguePriceCatalogue16.FilterCondition = string.Concat(strArrays2);
                        }
                        else if (str1.Trim().ToLower() == "not allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue17 = this;
                            productCataloguePriceCatalogue17.FilterCondition = string.Concat(productCataloguePriceCatalogue17.FilterCondition, " publicaccounts  like '%not allocated%'");
                        }
                        else if (str1.Trim().ToLower() != "allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue18 = this;
                            object obj3 = productCataloguePriceCatalogue18.FilterCondition;
                            object[] companyID3 = new object[] { obj3, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname like '%", str1, "%' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                            productCataloguePriceCatalogue18.FilterCondition = string.Concat(companyID3);
                        }
                        else
                        {
                            PriceCatalogue productCataloguePriceCatalogue19 = this;
                            productCataloguePriceCatalogue19.FilterCondition = string.Concat(productCataloguePriceCatalogue19.FilterCondition, " publicaccounts  like '%allocated%'");
                        }
                    }
                    else if (str2 == "doesnotcontain")
                    {
                        if (empty1.Trim().ToLower() == "allocatedcustomer")
                        {
                            if (str1.Trim().ToLower() == "allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue20 = this;
                                productCataloguePriceCatalogue20.FilterCondition = string.Concat(productCataloguePriceCatalogue20.FilterCondition, " allocatedcustomer  like '%not allocated%'");
                            }
                            else if (str1.Trim().ToLower() != "not allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue21 = this;
                                object filterCondition4 = productCataloguePriceCatalogue21.FilterCondition;
                                object[] objArray3 = new object[] { filterCondition4, " PriceCatalogueID not IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName  like '%", str1, "%' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                                productCataloguePriceCatalogue21.FilterCondition = string.Concat(objArray3);
                            }
                            else
                            {
                                PriceCatalogue productCataloguePriceCatalogue22 = this;
                                productCataloguePriceCatalogue22.FilterCondition = string.Concat(productCataloguePriceCatalogue22.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                            }
                        }
                        else if (empty1.Trim().ToLower() != "publicaccounts")
                        {
                            PriceCatalogue productCataloguePriceCatalogue23 = this;
                            string str4 = productCataloguePriceCatalogue23.FilterCondition;
                            string[] strArrays3 = new string[] { str4, " ", empty1, " not like '%", str1, "%'" };
                            productCataloguePriceCatalogue23.FilterCondition = string.Concat(strArrays3);
                        }
                        else if (str1.Trim().ToLower() != "not allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue24 = this;
                            object obj4 = productCataloguePriceCatalogue24.FilterCondition;
                            object[] companyID4 = new object[] { obj4, " PriceCatalogueID not IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname  like '%", str1, "%' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                            productCataloguePriceCatalogue24.FilterCondition = string.Concat(companyID4);
                        }
                        else
                        {
                            PriceCatalogue productCataloguePriceCatalogue25 = this;
                            productCataloguePriceCatalogue25.FilterCondition = string.Concat(productCataloguePriceCatalogue25.FilterCondition, " publicaccounts not  like '%not allocated%'");
                        }
                    }
                    else if (str2 != "equalto")
                    {
                        if (str2 == "notequalto")
                        {
                            if (empty1.Trim().ToLower() == "allocatedcustomer")
                            {
                                if (str1.Trim().ToLower() == "allocated")
                                {
                                    PriceCatalogue productCataloguePriceCatalogue26 = this;
                                    productCataloguePriceCatalogue26.FilterCondition = string.Concat(productCataloguePriceCatalogue26.FilterCondition, " allocatedcustomer  like '%not allocated%'");
                                }
                                else if (str1.Trim().ToLower() != "not allocated")
                                {
                                    PriceCatalogue productCataloguePriceCatalogue27 = this;
                                    object filterCondition5 = productCataloguePriceCatalogue27.FilterCondition;
                                    object[] objArray4 = new object[] { filterCondition5, " a.PriceCatalogueID not IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName = '", str1, "' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                                    productCataloguePriceCatalogue27.FilterCondition = string.Concat(objArray4);
                                }
                                else
                                {
                                    PriceCatalogue productCataloguePriceCatalogue28 = this;
                                    productCataloguePriceCatalogue28.FilterCondition = string.Concat(productCataloguePriceCatalogue28.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                                }
                            }
                            else if (empty1.Trim().ToLower() != "publicaccounts")
                            {
                                PriceCatalogue productCataloguePriceCatalogue29 = this;
                                string str5 = productCataloguePriceCatalogue29.FilterCondition;
                                string[] strArrays4 = new string[] { str5, " ", empty1, " != '", str1, "'" };
                                productCataloguePriceCatalogue29.FilterCondition = string.Concat(strArrays4);
                            }
                            else if (str1.Trim().ToLower() != "not allocated")
                            {
                                PriceCatalogue productCataloguePriceCatalogue30 = this;
                                object obj5 = productCataloguePriceCatalogue30.FilterCondition;
                                object[] companyID5 = new object[] { obj5, " PriceCatalogueID not IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname= '", str1, "' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                                productCataloguePriceCatalogue30.FilterCondition = string.Concat(companyID5);
                            }
                            else
                            {
                                PriceCatalogue productCataloguePriceCatalogue31 = this;
                                productCataloguePriceCatalogue31.FilterCondition = string.Concat(productCataloguePriceCatalogue31.FilterCondition, " publicaccounts not  like '%not allocated%'");
                            }
                        }
                    }
                    else if (empty1.Trim().ToLower() == "allocatedcustomer")
                    {
                        if (str1.Trim().ToLower() == "allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue32 = this;
                            productCataloguePriceCatalogue32.FilterCondition = string.Concat(productCataloguePriceCatalogue32.FilterCondition, " allocatedcustomer not like '%not allocated%'");
                        }
                        else if (str1.Trim().ToLower() != "not allocated")
                        {
                            PriceCatalogue productCataloguePriceCatalogue33 = this;
                            object filterCondition6 = productCataloguePriceCatalogue33.FilterCondition;
                            object[] objArray5 = new object[] { filterCondition6, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE customerid IN (SELECT clientid FROM tb_client WHERE clientName = '", str1, "' AND companyID=", this.CompanyID, " AND isDelete=0))" };
                            productCataloguePriceCatalogue33.FilterCondition = string.Concat(objArray5);
                        }
                        else
                        {
                            PriceCatalogue productCataloguePriceCatalogue34 = this;
                            productCataloguePriceCatalogue34.FilterCondition = string.Concat(productCataloguePriceCatalogue34.FilterCondition, " allocatedcustomer like '%not allocated%'");
                        }
                    }
                    else if (empty1.Trim().ToLower() != "publicaccounts")
                    {
                        PriceCatalogue productCataloguePriceCatalogue35 = this;
                        string str6 = productCataloguePriceCatalogue35.FilterCondition;
                        string[] strArrays5 = new string[] { str6, " ", empty1, " = '", str1, "'" };
                        productCataloguePriceCatalogue35.FilterCondition = string.Concat(strArrays5);
                    }
                    else if (str1.Trim().ToLower() != "not allocated")
                    {
                        PriceCatalogue productCataloguePriceCatalogue36 = this;
                        object obj6 = productCataloguePriceCatalogue36.FilterCondition;
                        object[] companyID6 = new object[] { obj6, " PriceCatalogueID IN ( SELECT PriceCatalogueID FROM tb_Pricecataloguecustomer WHERE accountid IN (SELECT accountid FROM tb_accounts WHERE accountname = '", str1, "' AND companyID=", this.CompanyID, " AND isDeleted=0))" };
                        productCataloguePriceCatalogue36.FilterCondition = string.Concat(companyID6);
                    }
                    else
                    {
                        PriceCatalogue productCataloguePriceCatalogue37 = this;
                        productCataloguePriceCatalogue37.FilterCondition = string.Concat(productCataloguePriceCatalogue37.FilterCondition, " publicaccounts   like '%not allocated%'");
                    }
                }
                this.Session["GridPriceCatalogueFilterCondition"] = this.FilterCondition;
                if (this.FilterCondition.Length == 0)
                {
                    this.Session["GridPriceCatalogueFilterCondition"] = null;
                }
                this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, PriceCatalogue.SortedBy, PriceCatalogue.sortdirection, this.FilterCondition);
                this.GridPriceCatalogue.Rebind();
            }
        }

        protected void GridPriceCatalogue_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            PriceCatalogue.SortedBy = e.SortExpression;
            PriceCatalogue.sortdirection = e.NewSortOrder.ToString();
            if (PriceCatalogue.sortdirection.ToLower() == "ascending")
            {
                PriceCatalogue.sortdirection = "ASC";
                this.GridPriceCatalogue.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (PriceCatalogue.sortdirection.ToLower() != "descending")
            {
                PriceCatalogue.sortdirection = "ASC";
                this.GridPriceCatalogue.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                PriceCatalogue.sortdirection = "DESC";
                this.GridPriceCatalogue.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            if (this.Session["GridPriceCatalogueFilterCondition"] != null)
            {
                this.FilterCondition = this.Session["GridPriceCatalogueFilterCondition"].ToString();
            }
            this.GridPriceCatalogue.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, this.GridPriceCatalogue.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, PriceCatalogue.sortdirection, this.FilterCondition);
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("setting", "GridPriceCatalogueSettings", this.GridPriceCatalogue, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("setting", "GridPriceCatalogueSettings", this.GridPriceCatalogue);
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridPriceCatalogue.AllowCustomPaging = true;
            if (this.Session["GridPriceCatalogueFilterCondition"] == null)
            {
                this.FilterCondition = "";
            }
            else
            {
                this.FilterCondition = this.Session["GridPriceCatalogueFilterCondition"].ToString();
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, this.GridPriceCatalogue.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.SelectedValue), PriceCatalogue.SortedBy, PriceCatalogue.sortdirection, this.FilterCondition);
        }

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            int num = SettingsBasePage.price_catalogue_copy(this.CompanyID, Convert.ToInt32(this.Session["UserID"]), Convert.ToInt32(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray));
        }

        protected void imgDelete_OnCommand(object sender, CommandEventArgs e)
        {
            SettingsBasePage.settings_price_catalogue_properties_deleteAll(Convert.ToInt32(this.CompanyID), Convert.ToInt32(e.CommandArgument));
            base.Message_Display("Product Catalogue(s) Deleted Successfully", "msg-success", this.plhMessage);
            this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, "CategoryName", "asc", "");
            this.GridPriceCatalogue.Rebind();
        }

        protected void lnkCopy_OnClick(object sender, EventArgs e)
        {
            int num = SettingsBasePage.price_catalogue_copy(this.CompanyID, Convert.ToInt32(this.Session["UserID"]), Convert.ToInt32(this.hdnProcessedId.Value));
            Guid guid = Guid.NewGuid();
            string str = guid.ToString().Substring(0, 30);
            DataTable oldPDFName = SettingsBasePage.getOldPDFName(Convert.ToInt32(this.hdnProcessedId.Value), num, str);
            string str1 = "";
            string str2 = "";
            foreach (DataRow row in oldPDFName.Rows)
            {
                str1 = row["PDFName"].ToString();
                str2 = row["ImageName"].ToString();
            }
            object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID, "/pdf/", str1 };
            string str3 = string.Concat(editableTemplatePath);
            object[] objArray = new object[] { this.EditableTemplatePath, this.CompanyID, "/pdf/", str, ".pdf" };
            string str4 = string.Concat(objArray);
            string str5 = str2;
            string str6 = string.Concat(this.EditableTemplatePath, this.CompanyID, "/images/");
            string str7 = string.Concat(this.EditableTemplatePath, this.CompanyID, "/images/");
            if (File.Exists(str3))
            {
                int numberOfPages = (new PdfReader(str3)).NumberOfPages;
                File.Copy(str3, str4, true);
                File.Copy(string.Concat(str6, str2), string.Concat(str7, str, "-0.png"), true);
                for (int i = 1; i < numberOfPages; i++)
                {
                    string str8 = string.Concat(str6, str5.Replace("-0.png", string.Concat("-", i, ".png")));
                    object[] objArray1 = new object[] { str7, str, "-", i, ".png" };
                    File.Copy(str8, string.Concat(objArray1), true);
                }
            }
            DataTable imageNames = SettingsBasePage.GetImageNames((long)Convert.ToInt32(this.hdnProcessedId.Value));
            List<string> strs = new List<string>();
            List<string> strs1 = new List<string>();
            foreach (DataRow dataRow in imageNames.Rows)
            {
                strs.Add(dataRow["ImageUrl"].ToString());
                strs1.Add(dataRow["ObjectID"].ToString());
            }
            for (int j = 0; j < strs.Count; j++)
            {
                object[] editableTemplatePath1 = new object[] { this.EditableTemplatePath, this.CompanyID, "/images/", strs[j] };
                if (File.Exists(string.Concat(editableTemplatePath1)))
                {
                    Guid guid1 = Guid.NewGuid();
                    string str9 = guid1.ToString().Substring(0, 20);
                    string[] strArrays = strs[j].Split(new char[] { '.' });
                    string str10 = strArrays[(int)strArrays.Length - 1].ToString();
                    File.Copy(string.Concat(str6, strs[j]), string.Concat(str6, str9, ".", str10), true);
                    SettingsBasePage.UpdateImageName(num, strs1[j], string.Concat(str9, ".", str10));
                }
            }
            HttpResponse response = base.Response;
            object[] objArray2 = new object[] { this.strSitepath, "ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray2));
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            SettingsBasePage.settings_price_catalogue_properties_deleteAll(Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.hdnProcessedId.Value));
            base.Message_Display("Product Catalogue(s) Deleted Successfully", "msg-success", this.plhMessage);
            this.GridPriceCatalogue.Rebind();
        }

        protected void lnkgrdPriceText_OnCommand(object sender, CommandEventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/pricecatalogue.aspx?action=edit&id=", e.CommandArgument.ToString()));
        }

        protected void lnkload_click(object sender, EventArgs e)
        {
            this.GridPriceCatalogue.Rebind();
            if (this.Session["option"] != null)
            {
                if (this.Session["option"] == null)
                {
                    base.Message_Display("Addition option added successfully", "msg-success", this.plhMessage);
                }
                if (this.Session["option"] == null)
                {
                    base.Message_Display("Product Catalogue copies successfully", "msg-success", this.plhMessage);
                }
                if (this.Session["option"] == null)
                {
                    base.Message_Display("CouponCode option added successfully", "msg-success", this.plhMessage);
                }
                this.Session["option"] = null;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridPriceCatalogue.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        public string Only_number(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            try
            {
                SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
                sqlConnection.Open();
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_Xero_ConnectKey_Select")
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.AddWithValue("@System_Name", ConnectionClass.ServerName.ToString());
                this.XeroConnectKey = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            catch
            {
            }
            if (ConnectionClass.ServerName != "")
            {
                this.DbID = SettingsBasePage.SelectDBID((long)this.CompanyID, ConnectionClass.ServerName);
            }
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("productcatalogue", "isview", "");
            this.GridPriceCatalogue.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.RadMenu1.Items[0].Text = string.Concat(this.objlang.GetLanguageConversion("Allocate"), " ", this.objlang.GetLanguageConversion("To"));
            this.RadMenu1.Items[1].Text = this.objlang.GetLanguageConversion("Detele_Selected");
            this.RadMenu1.Items[2].Text = this.objlang.GetLanguageConversion("In_visible");
            this.RadMenu1.Items[3].Text = this.objlang.GetLanguageConversion("Visible");
            this.lblChange.Text = this.objlang.GetLanguageConversion("Change");
            this.lblFilterByCategory.Text = this.objlang.GetLanguageConversion("Filter_By_Category");
            BaseClass baseClass1 = new BaseClass();
            this.AddStatus = baseClass1.ReturnRoles_Privileges_ForGrid("productcatalogue", "isadd", this.Page.Request.Url.ToString());
            this.DeleteStatus = baseClass1.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdelete", this.Page.Request.Url.ToString());
            if (this.DeleteStatus.Trim().ToLower() != "false")
            {
                this.RadMenu1.Items[1].Visible = true;
            }
            else
            {
                this.RadMenu1.Items[1].Visible = false;
            }
            if (ConnectionClass.WebStore != null)
            {
                this.WebStore = ConnectionClass.WebStore.ToString();
            }
            try
            {
                this.EditableTemplateURL = EprintConfigurationManager.AppSettings["EditableTemplateURL"].ToString();
                this.EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();
            }
            catch
            {
            }
            this.gloobj.setpagename("productcatalogue");
            this.pg = "productcatalogue";
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Home"), "</a>&nbsp;>&nbsp; <a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator' style=text-decoration:underline>", this.objlang.GetLanguageConversion("Products"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Product_Catalogue")));
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "productcatalogue_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.Session["PrdViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["PrdViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridPriceCatalogue.PageSize = 50;
                this.editOrderViewID.Value = "";
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
                    int num = 0;
                    while (num < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num].Value != this.ViewID.ToString())
                        {
                            num++;
                        }
                        else
                        {
                            baseClass.SetDDLValue(this.ddl_View, this.ddl_View.Items[num].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.pg);
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow row in this.dt.Rows)
                        {
                            this.defaultviewid = Convert.ToInt32(row["ViewID"].ToString());
                        }
                    }
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View);
                    int num1 = 0;
                    while (num1 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num1].Value != this.defaultviewid.ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            baseClass.SetDDLValue(this.ddl_View, this.ddl_View.Items[num1].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }
                else
                {
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, this.defaultviewid);
                    int num2 = 0;
                    while (num2 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num2].Value != this.defaultviewid.ToString())
                        {
                            num2++;
                        }
                        else
                        {
                            baseClass.SetDDLValue(this.ddl_View, this.ddl_View.Items[num2].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }
                if (this.ddl_View.Text.Length == 0)
                {
                    this.ddl_View.Visible = false;
                }
            }
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str1 = string.Concat(this.pg, this.UserID, this.pg);
                this.Session["GridPriceCataloguesearchFilter"] = null;
                this.Session["GridPriceCatalogueFilterCondition"] = null;
                this.Session[str1] = null;
            }
            int num3 = 0;
            num3 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, "productcatalogue");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow dataRow in this.dt.Rows)
                {
                    this.defaultsortedby = dataRow["SortedBy"].ToString();
                    this.defaultsortdirection = dataRow["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                PriceCatalogue.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    //PriceCatalogue.SortedBy = "categoryname";//kr
                    PriceCatalogue.SortedBy = "PriceCatalogueID";//kr
                }
                else
                {
                    PriceCatalogue.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    PriceCatalogue.sortdirection = "asc";
                }
                else if (this.defaultsortdirection != "")
                {
                    PriceCatalogue.sortdirection = this.defaultsortdirection;
                }
            }
            this.colorformat = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
            this.plhAccountList.Controls.Add(userControl);
            DataTable dataTable1 = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            PriceCatalogue.ManageStockPermission = Convert.ToInt32(dataTable1.Rows[0]["ProductStockManagement"]);
            if (!base.IsPostBack)
            {
                this.GridStateLoad();
                PriceCatalogue.PageSize = this.objJava.ReturnPageSize("setting", "GridPriceCatalogueSettings", this.GridPriceCatalogue);
                this.GridPriceCatalogue.PageSize = PriceCatalogue.PageSize;
                this.Session["PrdViewID"] = this.defaultviewid;
                if (this.Session["GridPriceCatalogueFilterCondition"] == null)
                {
                    this.FilterCondition = "";
                }
                else
                {
                    this.FilterCondition = this.Session["GridPriceCatalogueFilterCondition"].ToString();
                }
                this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, PriceCatalogue.SortedBy, "asc", this.FilterCondition);
                this.GridPriceCatalogue.Rebind();
            }
            if (!base.IsPostBack && base.Request.Params["display"] != null)
            {
                if (base.Request.Params["display"] == "in")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Price_Catalogue_Saved_Successfully"), "msg-success", this.plhMessage);
                }
                else if (base.Request.Params["display"] == "up")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Price_Catalogue_Updated_successfully"), "msg-success", this.plhMessage);
                }
            }
            if (!base.IsPostBack && this.Session["Category"] != null)
            {
                ListItem listItem = this.ddlCategorySelect.Items.FindByValue(this.Session["Category"].ToString());
                this.ddlCategorySelect.SelectedIndex = this.ddlCategorySelect.Items.IndexOf(listItem);
                this.ddlCategorySelect_SelectedIndexChanged(sender, e);
            }
        }

        protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (this.RadMenu1.SelectedValue.ToString() != "Delete")
            {
                if (this.RadMenu1.SelectedValue.ToString().ToLower() == "invisible")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Items_In_Visible_To_eStore_Successfully"), "msg-success", this.plhMessage);
                    this.GridPriceCatalogue.Rebind();
                    return;
                }
                if (this.RadMenu1.SelectedValue.ToString().ToLower() == "visible")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Items_Visible_To_eStore_Successfully"), "msg-success", this.plhMessage);
                    this.GridPriceCatalogue.Rebind();
                }
            }
            else if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        SettingsBasePage.settings_price_catalogue_properties_deleteAll(this.CompanyID, Convert.ToInt32(strArrays[i]));
                    }
                }
                base.Message_Display(this.objlang.GetLanguageConversion("Product_Catalogue_Deleted_Successfully"), "msg-success", this.plhMessage);
                this.GridBind(this.CompanyID, this.UserID, this.GridPriceCatalogue.PageSize, 1, this.defaultviewid, "CategoryName", "asc", "");
                this.GridPriceCatalogue.Rebind();
                return;
            }
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }
    }
}