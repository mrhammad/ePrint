using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.warehouse
{
    public partial class Inventory_popup : UserControl
    {
        //protected RadAjaxManagerProxy RadAjaxManagerProxy1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected usercontrol_settings_Loading ucLoading;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel2;

        //protected Button btnSelect;

        //protected Button btnShowAll;

        //protected LinkButton btnclrFilters;

        //protected RadGrid GridInventory;

        //protected Button btnSelect_new;

        //protected Button btnShowAll_new;

        //protected HtmlGenericControl div_InvItems;

        //protected LinkButton lnkselect;

        //protected HiddenField hidGridCount;

        //protected HiddenField hid_IventoryIDs;

        //protected HiddenField hid_InvDetails;

        //protected Panel popUpClose;

        public commonClass objJava = new commonClass();

        public string ItemType = string.Empty;

        public string inkid = string.Empty;

        public int totalrec;

        public string CatValue1 = string.Empty;

        private InventoryBasePage obj = new InventoryBasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        public int CompanyID;

        public int UserID;

        public long InvID;

        public string InvName = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int PageSize = 25;

        public string AddedItem = string.Empty;

        private string paperType = " ";

        private string InkType = " ";

        private DataTable dtsearchInvItem = new DataTable();

        public static string WhereCondition;

        public static string SortDirection;

        public static string SortedBy;

        public string WeightMeasure = string.Empty;

        private BasePage ObjPage = new BasePage();

        public languageClass objLangClass = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        static Inventory_popup()
        {
            Inventory_popup.WhereCondition = string.Empty;
            Inventory_popup.SortDirection = string.Empty;
            Inventory_popup.SortedBy = string.Empty;
        }

        public Inventory_popup()
        {
        }

        public void AddBoundColumns_inventory(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < this.GridInventory.Columns.Count; i++)
                {
                    if (this.GridInventory.Columns[i].SortExpression.ToLower() == "basisweight")
                    {
                        this.GridInventory.Columns[i].HeaderText = string.Concat("Weight (", this.WeightMeasure, ")");
                        this.GridInventory.Columns[i].ItemStyle.Wrap = false;
                    }
                }
            }
        }

        protected void btnSelect_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_IventoryIDs.Value))
            {
                string[] strArrays = this.hid_IventoryIDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string empty = string.Empty;
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    if (strArrays[i] != "")
                    {
                        DataTable dataTable = WebstoreBasePage.Select_InventoryProperties(this.CompanyID, Convert.ToInt64(strArrays[i]));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            str = row["InventoryName"].ToString();
                            empty1 = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["UnitPrice"].ToString()), 0, "", false, false, true);
                            str1 = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["Markup"].ToString()), 0, "", false, false, true);
                            string[] strArrays1 = new string[] { str, "±", empty1, "±", str1, "±", strArrays[i] };
                            empty = string.Concat(strArrays1);
                        }
                        HiddenField hidInvDetails = this.hid_InvDetails;
                        hidInvDetails.Value = string.Concat(hidInvDetails.Value, empty, "µ");
                    }
                }
            }
            this.popUpClose.Visible = true;
        }

        public void btnShowAll_OnClick(object sender, EventArgs e)
        {
            base.Session["ItemType"] = "all";
            this.GridBindInv(this.CompanyID, "all", this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, Inventory_popup.WhereCondition, this.paperType);
            this.GridInventory.MasterTableView.Rebind();
        }

        private void call_java()
        {
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            base.Session["dtsearchInvItem"] = null;
            this.ViewState["InventoryCode"] = null;
            this.ViewState["InventoryName"] = null;
            this.ViewState["SupplierName"] = null;
            this.ViewState["Description"] = null;
            Inventory_popup.WhereCondition = "";
            foreach (GridColumn column in this.GridInventory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInventory.MasterTableView.FilterExpression = string.Empty;
            this.GridBindInv(this.CompanyID, this.ItemType, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, Inventory_popup.WhereCondition, this.paperType);
            this.GridInventory.MasterTableView.Rebind();
        }

        protected void GridBindInv(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string PaperType)
        {
            if (base.Session["ItemType"] != null)
            {
                ItemType = base.Session["ItemType"].ToString();
            }
            DataSet dataSet = WebstoreBasePage.Select_Inventory_PopUp_Select(CompanyID, ItemType, PageSize, PageNumber, Inventory_popup.SortedBy, SortDirection, WhereCondition);
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                dataSet.Tables[0].Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["InventoryCode"] = this.objBase.SpecialDecode(row["InventoryCode"].ToString());
                row["InventoryName"] = this.objBase.SpecialDecode(row["InventoryName"].ToString());
                row["SupplierName"] = this.objBase.SpecialDecode(row["SupplierName"].ToString());
                row["Description"] = this.objBase.SpecialDecode(row["Description"].ToString());
            }
            this.GridInventory.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridInventory);
                this.GridInventory.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns_inventory(dataSet.Tables[0], this.GridInventory);
            this.GridInventory.AllowCustomPaging = true;
            this.GridInventory.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = dataSet.Tables[1].Rows[0][0].ToString();
        }

        protected void GridInventory_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                Label label = (Label)e.Row.FindControl("lblPackQty");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedIn"].ToString()), 0, "", true, false, true);
                Label label1 = (Label)e.Row.FindControl("lblPackPrice");
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedPrice"].ToString()), 0, "", false, false, true);
                Label label2 = (Label)e.Row.FindControl("lblInvCost");
                label2.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                Label label3 = (Label)e.Row.FindControl("lblInvPer");
                label3.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text), 0, "", true, false, true);
                Label label4 = (Label)e.Row.FindControl("lblunitprice");
                decimal num = new decimal(0);
                if (Convert.ToDecimal(dataItem["PerQuantity"].ToString()) == new decimal(0))
                {
                    label4.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true);
                }
                else
                {
                    num = Convert.ToDecimal(dataItem["Cost"].ToString()) / Convert.ToDecimal(dataItem["PerQuantity"].ToString());
                    label4.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(num), 0, "", false, false, true);
                }
                Label label5 = (Label)e.Row.FindControl("lblPaperSize");
                Label label6 = (Label)e.Row.FindControl("lblInvWeightSize");
                Label label7 = (Label)e.Row.FindControl("lblGsm");
                HiddenField hiddenField = (HiddenField)e.Row.FindControl("hid_PaperType");
                HiddenField hiddenField1 = (HiddenField)e.Row.FindControl("hid_LengthType");
                HiddenField hiddenField2 = (HiddenField)e.Row.FindControl("hid_WidthType");
                HiddenField hiddenField3 = (HiddenField)e.Row.FindControl("hid_Length");
                HiddenField hiddenField4 = (HiddenField)e.Row.FindControl("hid_Width");
                HiddenField hiddenField5 = (HiddenField)e.Row.FindControl("hid_Height");
                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkInvName1");
                Label label8 = (Label)e.Row.FindControl("lblInvName");
                Label label9 = (Label)e.Row.FindControl("lblDescription");
                Label text = (Label)e.Row.FindControl("lblSupplier");
                HiddenField hiddenField6 = (HiddenField)e.Row.FindControl("hid_InventoryID");
                label6.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label6.Text), 0, "", false, false, true);
                string[] value = new string[] { "javascript:setpaperid('", hiddenField6.Value, "','", label8.Text, "','", hiddenField.Value, "','", hiddenField5.Value, "','", hiddenField4.Value, "');TimerToClose();return false;" };
                linkButton.OnClientClick = string.Concat(value);
                linkButton.Text = BaseClass.WrapString(linkButton.Text.ToString().Trim(), 30);
                label9.Text = BaseClass.WrapString(label9.Text.ToString().Trim(), 15);
                text.Text = BaseClass.WrapString(text.Text.ToString().Trim(), 15);
                text.ToolTip = text.Text;
                if (label6.Text == "0")
                {
                    label6.Text = "";
                    label7.Text = "";
                }
                if (hiddenField.Value.ToLower() == "sheet")
                {
                    string[] strArrays = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField5.Value), 0, "", false, false, true), hiddenField2.Value, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField4.Value), 0, "", false, false, true), hiddenField2.Value };
                    label5.Text = string.Concat(strArrays);
                    return;
                }
                if (hiddenField.Value.ToLower() == "web printing")
                {
                    string[] strArrays1 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField4.Value), 0, "", false, false, true), hiddenField2.Value, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(hiddenField3.Value), 0, "", false, false, true), hiddenField1.Value };
                    label5.Text = string.Concat(strArrays1);
                }
            }
        }

        protected void GridInvItem_ItemCommand(object sender, GridCommandEventArgs e)
        {
            int num;
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                this.ViewState[str] = item.Text;
                item.Text = this.objBase.SpecialEncode(item.Text);
                Inventory_popup.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                int num1 = 0;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    num1 = Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() == "nofilter")
                {
                    if (str.ToLower() == "inventorycode")
                    {
                        this.ViewState["InventoryCode"] = null;
                    }
                    if (str.ToLower() == "inventoryname")
                    {
                        this.ViewState["InventoryName"] = null;
                    }
                    if (str.ToLower() == "suppliername")
                    {
                        this.ViewState["SupplierName"] = null;
                    }
                    if (str.ToLower() == "description")
                    {
                        this.ViewState["Description"] = null;
                    }
                }
                else if (commandArgument.Second.ToString().ToLower() == "cost" || commandArgument.Second.ToString().ToLower() == "unitprice" || commandArgument.Second.ToString().ToLower() == "basisweight" || commandArgument.Second.ToString().ToLower() == "packedin" || commandArgument.Second.ToString().ToLower() == "packedprice")
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Pls Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (base.Session["dtsearchInvItem"] == null)
                {
                    this.dtsearchInvItem.Columns.Add("ColumnName");
                    this.dtsearchInvItem.Columns.Add("Filter");
                    this.dtsearchInvItem.Columns.Add("FilterText");
                }
                if (base.Session["dtsearchInvItem"] != null)
                {
                    this.dtsearchInvItem = (DataTable)base.Session["dtsearchInvItem"];
                }
                DataRow[] dataRowArray = this.dtsearchInvItem.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if (item.Text != "")
                {
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearchInvItem.Rows.Add(second);
                    }
                    else
                    {
                        this.dtsearchInvItem.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            this.dtsearchInvItem.Rows.Add(objArray);
                        }
                    }
                }
                base.Session["dtsearchInvItem"] = this.dtsearchInvItem;
                foreach (DataRow dataRow in this.dtsearchInvItem.Rows)
                {
                    if (dataRow["filter"].ToString().ToLower() != "nofilter" && Inventory_popup.WhereCondition != "")
                    {
                        Inventory_popup.WhereCondition = string.Concat(Inventory_popup.WhereCondition, " and ");
                    }
                    if (dataRow["ColumnName"].ToString().ToLower() == "cost")
                    {
                        empty1 = dataRow["FilterText"].ToString();
                        object[] str1 = new object[] { "round(a.", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                        empty = string.Concat(str1);
                    }
                    else if (dataRow["ColumnName"].ToString().ToLower() == "description" || dataRow["ColumnName"].ToString().ToLower() == "inventorycode" || dataRow["ColumnName"].ToString().ToLower() == "inventoryname" || dataRow["ColumnName"].ToString().ToLower() == "packedin" || dataRow["ColumnName"].ToString().ToLower() == "basisweight" || dataRow["ColumnName"].ToString().ToLower() == "packedprice")
                    {
                        empty1 = dataRow["FilterText"].ToString();
                        empty = string.Concat("a.", dataRow["ColumnName"].ToString());
                    }
                    else
                    {
                        empty = dataRow["ColumnName"].ToString();
                        empty1 = dataRow["FilterText"].ToString();
                    }
                    string lower = dataRow["filter"].ToString().ToLower();
                    string str2 = lower;



                }
                this.GridBindInv(this.CompanyID, this.ItemType, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, Inventory_popup.WhereCondition, this.paperType);
                this.GridInventory.Rebind();
            }
        }

        protected void GridInvItem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridInventory.AllowCustomPaging = true;
            this.GridBindInv(this.CompanyID, this.ItemType, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, Inventory_popup.WhereCondition, this.paperType);
        }

        protected void GridInvItem_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            Inventory_popup.SortedBy = e.SortExpression;
            Inventory_popup.SortDirection = e.NewSortOrder.ToString();
            if (Inventory_popup.SortDirection.ToLower() == "ascending")
            {
                Inventory_popup.SortDirection = "ASC";
            }
            else if (Inventory_popup.SortDirection.ToLower() != "descending")
            {
                Inventory_popup.SortDirection = "ASC";
            }
            else
            {
                Inventory_popup.SortDirection = "DESC";
            }
            this.GridInventory.CurrentPageIndex = 0;
            this.GridBindInv(this.CompanyID, this.ItemType, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, "", this.paperType);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridInventory.FilterMenu;
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
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
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
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
        }

        public string Only_number(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }

        public void OnRowDataBound_GridInvItem(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                for (int i = 0; i < this.GridInventory.Columns.Count; i++)
                {
                    if (this.GridInventory.Columns[i].SortExpression.ToLower() == "basisweight")
                    {
                        this.GridInventory.Columns[i].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Weight"), " (", this.WeightMeasure, ")");
                    }
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem item = (GridFilteringItem)e.Item;
                TextBox str = (e.Item as GridFilteringItem)["InventoryName"].Controls[0] as TextBox;
                TextBox textBox = (e.Item as GridFilteringItem)["InventoryCode"].Controls[0] as TextBox;
                TextBox item1 = (e.Item as GridFilteringItem)["SupplierName"].Controls[0] as TextBox;
                Control control = (e.Item as GridFilteringItem)["Description"].Controls[0];
                if (this.ViewState["InventoryName"] != null)
                {
                    str.Text = this.ViewState["InventoryName"].ToString();
                }
                if (this.ViewState["InventoryCode"] != null)
                {
                    textBox.Text = this.ViewState["InventoryCode"].ToString();
                }
                if (this.ViewState["SupplierName"] != null)
                {
                    item1.Text = this.ViewState["SupplierName"].ToString();
                }
                if (this.ViewState["Description"] != null)
                {
                    item1.Text = this.ViewState["Description"].ToString();
                }
                item["UnitPrice"].HorizontalAlign = HorizontalAlign.Right;
                item["PackedPrice"].HorizontalAlign = HorizontalAlign.Right;
                item["PackedIn"].HorizontalAlign = HorizontalAlign.Right;
                item["BasisWeight"].HorizontalAlign = HorizontalAlign.Right;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem gridDataItem = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = (Label)e.Item.FindControl("lblPackedIn");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label.Text), 0, "", true, false, true);
                Label label1 = (Label)e.Item.FindControl("lblPackedPrice");
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label1.Text), 0, "", false, false, true);
                Label label2 = (Label)e.Item.FindControl("lblInvCost");
                label2.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                Label label3 = (Label)e.Item.FindControl("lblInvPer");
                label3.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text), 0, "", true, false, true);
                Label label4 = (Label)e.Item.FindControl("lblUnitPrice");
                label4.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label4.Text), 0, "", false, false, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridInventory.MasterTableView.Columns[5].HeaderText = string.Concat("Pack Price(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInventory.MasterTableView.Columns[6].HeaderText = string.Concat("Cost Price(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInventory.MasterTableView.Columns[7].HeaderText = string.Concat("Unit Price(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            try
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                Inventory_popup.WhereCondition = "";
                base.Session["dtsearchInvItem"] = null;
                base.Session["ItemType"] = null;
                Inventory_popup.SortedBy = "InventoryCode";
                Inventory_popup.SortDirection = "Desc";
            }
            this.WeightMeasure = this.ObjPage.GetRegionalSettings(this.CompanyID, "Weight");
            this.GridInventory.MasterTableView.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Inventory_Code");
            this.GridInventory.MasterTableView.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Inventory_Name");
            this.GridInventory.MasterTableView.Columns[3].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Weight"), "(", this.WeightMeasure, ")");
            this.GridInventory.MasterTableView.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Pack_Qty");
            this.GridInventory.MasterTableView.Columns[5].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Pack_Price"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInventory.MasterTableView.Columns[6].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Cost_Price"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInventory.MasterTableView.Columns[7].HeaderText = string.Concat(this.objLangClass.GetLanguageConversion("Unit_Price"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
            this.GridInventory.MasterTableView.Columns[8].HeaderText = this.objLangClass.GetLanguageConversion("Supplier");
            this.GridInventory.MasterTableView.Columns[9].HeaderText = this.objLangClass.GetLanguageConversion("Description");
            this.btnShowAll.Text = this.objLangClass.GetLanguageConversion("Show_All_Inventory");
            this.btnSelect.Text = this.objLangClass.GetLanguageConversion("Select");
            this.btnSelect_new.Text = this.objLangClass.GetLanguageConversion("Select");
            this.btnShowAll_new.Text = this.objLangClass.GetLanguageConversion("Show_All_Inventory");
            this.btnclrFilters.Text = this.objLangClass.GetLanguageConversion("Clear_All_Filters");
            if (!base.IsPostBack && base.Request.Params["item"] != null)
            {
                this.div_InvItems.Visible = false;
                if (base.Request.Params["item"].ToString().ToLower() == "paper")
                {
                    this.div_InvItems.Visible = true;
                    try
                    {
                        this.paperType = base.Request.Params["paperType"].ToString();
                    }
                    catch
                    {
                    }
                    if (base.Request.Params["item"].ToString().ToLower() != "paper")
                    {
                        this.ItemType = base.Request.Params["item"].ToString().ToLower();
                    }
                    else
                    {
                        this.ItemType = "paper";
                    }
                    base.Session["ItemType"] = this.ItemType;
                    if (!base.IsPostBack)
                    {
                        this.GridBindInv(this.CompanyID, this.ItemType, this.GridInventory.PageSize, this.GridInventory.CurrentPageIndex + 1, Inventory_popup.SortedBy, Inventory_popup.SortDirection, "", this.paperType);
                    }
                }
            }
        }
    }
}