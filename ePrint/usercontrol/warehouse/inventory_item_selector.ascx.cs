using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.warehouse
{
    public partial class inventory_item_selector : System.Web.UI.UserControl
    {
        public string ItemType = string.Empty;

        public string inkid = string.Empty;

        public int totalrec;

        public string CatValue1 = string.Empty;

        private InventoryBasePage obj = new InventoryBasePage();

        //private BaseClass objBase = new BaseClass();inAccessible in aspx page due to its protection level.

        public BaseClass objBase = new BaseClass();

        private commonClass cmnDate = new commonClass();

        public int CompanyID;

        public int UserID;

        public long InvID;

        public string InvName = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int PageSize = 10;

        public int PageNumber;

        public string AddedItem = string.Empty;

        public languageClass objlang = new languageClass();

        public string paperType = " ";

        public string InkType = string.Empty;

        public string Filtervalue = string.Empty;

        private DataTable dtsearchInv = new DataTable();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string IsLargeItem = string.Empty;

        public int MaterialNo;

        public string IsColororwhiteink = string.Empty;

        public string paperWeight = string.Empty;

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

        public inventory_item_selector()
        {
        }

        protected void GridBindInk_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = InventoryBasePage.inventory_selectall(this.CompanyID, base.Request.Params["item"].ToString().ToLower(), " ", this.InkType);
            this.GridInk.DataSource = dataSet;
        }

        protected void GridBindInv_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet = (!base.Request.Url.Query.Contains("IsLargeMaterial") ? InventoryBasePage.inventory_selectall(this.CompanyID, this.ItemType, this.paperType, " ") : InventoryBasePage.inventory_SelectLargeFormat(this.CompanyID, this.ItemType));
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            if (item != null)
            {
                string DecimalPaperSizeFlag = string.Empty;
                int DecimalPaperSize = 0;
                foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    DecimalPaperSizeFlag = dataRow["Decimal3ForPaperSizes"] != DBNull.Value
                                       ? dataRow["Decimal3ForPaperSizes"].ToString() : "False";
                }

                foreach (DataRow row in item.Rows)
                {
                    string str = row["PaperType"].ToString();
                    string str1 = row["Height"].ToString();
                    string str2 = row["Width"].ToString();
                    string str3 = row["WidthType"].ToString();
                    string str4 = row["Length"].ToString();
                    string str5 = row["LengthType"].ToString();
                 
                    if (DecimalPaperSizeFlag.ToLower() == "true")
                    {
                        DecimalPaperSize = 3;
                    }
                    else
                    {
                        DecimalPaperSize = 0;
                    }
                    if (str.ToString().ToLower() != "sheet")
                    {
                        if (str.ToString().ToLower() != "web printing")
                        {
                            continue;
                        }
                        string[] strArrays = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str2), DecimalPaperSize, "", false, false, true), str3, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str4), DecimalPaperSize, "", false, false, true), str5 };
                        row["PaperName"] = string.Concat(strArrays);
                    }
                    else
                    {
                        string[] strArrays1 = new string[] { this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str1), DecimalPaperSize, "", false, false, true), str3, " X ", this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(str2), DecimalPaperSize, "", false, false, true), str3 };
                        row["PaperName"] = string.Concat(strArrays1);
                    }
                }
            }
            this.GridInventory.DataSource = item;
        }

        protected void GridInk_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            GridTableView masterTableView = this.GridInk.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridItem items = masterTableView.GetItems(gridItemTypeArray)[0];
            LinkButton languageConversion = items.FindControl("lnkAddNew") as LinkButton;
            if (base.Request.Params["item"] != null)
            {
                if (base.Request.Params["item"].ToString().ToLower() == "ink")
                {
                    languageConversion.Text = this.objlang.GetLanguageConversion("Add_New_lnk");
                }
                else if (base.Request.Params["item"].ToString().ToLower() == "plates")
                {
                    languageConversion.Text = this.objlang.GetLanguageConversion("Add_New_Plate");
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkPackQty");
                linkButton.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedIn"].ToString()), 0, "", false, false, true);
                LinkButton linkButton1 = (LinkButton)e.Item.FindControl("lnkPackPrice");
                linkButton1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedPrice"].ToString()), 0, "", false, false, true);
                LinkButton linkButton2 = (LinkButton)e.Item.FindControl("lnkInvName1");
                LinkButton linkButton3 = (LinkButton)e.Item.FindControl("lnkDescription");
                Label label = (Label)e.Item.FindControl("lblSupplier");
                Label label1 = (Label)e.Item.FindControl("lblInvName");
                Label label2 = (Label)e.Item.FindControl("lblInkID");
                if (this.ItemType.ToLower() == "ink" || this.ItemType.ToLower() == "inks")
                {
                    string[] text = new string[] { "javascript:setvalue('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "','');" };
                    linkButton2.OnClientClick = string.Concat(text);
                    string[] strArrays = new string[] { "javascript:setvalue('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "','');" };
                    linkButton3.OnClientClick = string.Concat(strArrays);
                    string[] text1 = new string[] { "javascript:setvalue('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "','');" };
                    linkButton.OnClientClick = string.Concat(text1);
                    string[] strArrays1 = new string[] { "javascript:setvalue('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "','');" };
                    linkButton1.OnClientClick = string.Concat(strArrays1);
                }
                else
                {
                    string[] text2 = new string[] { "javascript:setplatesid('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "');TimerToClose();return false;" };
                    linkButton2.OnClientClick = string.Concat(text2);
                    string[] strArrays2 = new string[] { "javascript:setplatesid('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "');TimerToClose();return false;" };
                    linkButton3.OnClientClick = string.Concat(strArrays2);
                    string[] text3 = new string[] { "javascript:setplatesid('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "');TimerToClose();return false;" };
                    linkButton.OnClientClick = string.Concat(text3);
                    string[] strArrays3 = new string[] { "javascript:setplatesid('", label2.Text, "','", this.objBase.SpecialEncode(label1.Text), "');TimerToClose();return false;" };
                    linkButton1.OnClientClick = string.Concat(strArrays3);
                }
                linkButton2.Text = BaseClass.WrapString(linkButton2.Text.ToString().Trim(), 25);
                linkButton3.Text = BaseClass.WrapString(linkButton3.Text.ToString().Trim(), 15);
            }
            GridTableView gridTableView = this.GridInk.MasterTableView;
            GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem gridCommandItem = (GridCommandItem)gridTableView.GetItems(gridItemTypeArray1)[0];
            HtmlControl htmlControl = (HtmlControl)gridCommandItem.FindControl("DivAddNewPlate");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).ToLower() != "false")
            {
                htmlControl.Visible = true;
            }
            else
            {
                htmlControl.Visible = false;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion1 = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion1.Text = this.objlang.GetLanguageConversion("Page_size");
                GridTableView masterTableView1 = this.GridInk.MasterTableView;
                GridItemType[] gridItemTypeArray2 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)masterTableView1.GetItems(gridItemTypeArray2)[0];
                this.GridInk.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objlang.GetLanguageConversion("items_in"), " {1} ", this.objlang.GetLanguageConversion("pages"));
            }
        }

        protected void GridInventory_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = (Label)e.Item.FindControl("lblPackQty");
                label.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedIn"].ToString()), 0, "", true, false, true);
                Label label1 = (Label)e.Item.FindControl("lblPackPrice");
                label1.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["PackedPrice"].ToString()), 0, "", false, false, true);
                Label label2 = (Label)e.Item.FindControl("lblInvCost");
                label2.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label2.Text), 0, "", false, false, true);
                Label label3 = (Label)e.Item.FindControl("lblInvPer");
                label3.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label3.Text), 0, "", true, false, true);
                Label label4 = (Label)e.Item.FindControl("lblunitprice");
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
                Label label5 = (Label)e.Item.FindControl("lblInvWeightSize");
                Label label6 = (Label)e.Item.FindControl("lblGsm");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hid_PaperType");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hid_LengthType");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hid_WidthType");
                HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("hid_Length");
                HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("hid_Width");
                HiddenField hiddenField5 = (HiddenField)e.Item.FindControl("hid_Height");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkInvName1");
                Label label7 = (Label)e.Item.FindControl("lblInvName");
                Label label8 = (Label)e.Item.FindControl("lblDescription");
                Label text = (Label)e.Item.FindControl("lblSupplier");
                HiddenField hiddenField6 = (HiddenField)e.Item.FindControl("hid_InventoryID");
                label6.Text = this.paperWeight;
                label5.Text = this.cmnDate.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(label5.Text), 0, "", false, false, true);
                if (base.Request.Url.Query.Contains("id"))
                {
                    Convert.ToInt32(base.Request.Params["id"].ToString());
                }
                string[] value = new string[] { "javascript:setpaperid('", hiddenField6.Value, "','", label7.Text.Replace(Environment.NewLine, ""), "','", hiddenField.Value, "','", label5.Text, "','", hiddenField5.Value, "','", hiddenField4.Value, "');TimerToClose();return false;" };
                linkButton.OnClientClick = string.Concat(value);
                text.ToolTip = text.Text;
                linkButton.Text = BaseClass.WrapString(linkButton.Text.ToString().Trim(), 30);
                label8.Text = BaseClass.WrapString(label8.Text.ToString().Trim(), 15);
                text.Text = BaseClass.WrapString(text.Text.ToString().Trim(), 15);
                if (label5.Text == "0")
                {
                    label5.Text = "";
                    label6.Text = "";
                }
            }
            GridTableView masterTableView = this.GridInventory.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("DivbtnAddNewRecord");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("warehouse", "isadd", this.Page.Request.Url.ToString()).ToLower() != "false")
            {
                htmlControl.Visible = true;
            }
            else
            {
                htmlControl.Visible = false;
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objlang.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridInventory.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridInventory.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objlang.GetLanguageConversion("items_in"), " {1} ", this.objlang.GetLanguageConversion("pages"));
            }
        }

        protected void InkclrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridInk.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInk.MasterTableView.FilterExpression = string.Empty;
            this.GridInk.MasterTableView.Rebind();
        }

        protected void InvclrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridInventory.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridInventory.MasterTableView.FilterExpression = string.Empty;
            this.GridInventory.MasterTableView.Rebind();
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
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objlang.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu languageConversion = this.GridInk.FilterMenu;
            for (int j = languageConversion.Items.Count - 1; j >= 0; j--)
            {
                if (languageConversion.Items[j].Text == "Custom")
                {
                    languageConversion.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion.Items[j].Text.ToLower() == "isempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "isnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "between")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notbetween")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "nofilter")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("NoFilter");
                }
                if (languageConversion.Items[j].Text.ToLower() == "contains")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("Contains");
                }
                if (languageConversion.Items[j].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion.Items[j].Text.ToLower() == "startswith")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("StartsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "endswith")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("EndsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = this.objlang.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridInventory.MasterTableView.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Code");
            this.GridInventory.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Name");
            this.GridInventory.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Weight");
            this.GridInventory.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Size");
            this.GridInventory.Columns[4].HeaderText = this.objlang.GetLanguageConversion("Pack_Qty");
            this.GridInventory.Columns[5].HeaderText = this.objlang.GetLanguageConversion("Pack_Price");
            this.GridInventory.Columns[6].HeaderText = this.objlang.GetLanguageConversion("Cost_Price");
            this.GridInventory.Columns[7].HeaderText = this.objlang.GetLanguageConversion("Unit_Price(");
            this.GridInventory.Columns[8].HeaderText = this.objlang.GetLanguageConversion("Supplier");
            this.GridInventory.Columns[9].HeaderText = this.objlang.GetLanguageConversion("Description");
            this.GridInventory.Columns[10].HeaderText = this.objlang.GetLanguageConversion("Friendly_Name");


            this.GridInk.Columns[0].HeaderText = this.objlang.GetLanguageConversion("Name");
            this.GridInk.Columns[1].HeaderText = this.objlang.GetLanguageConversion("Description");
            this.GridInk.Columns[2].HeaderText = this.objlang.GetLanguageConversion("Pack_Qty");
            this.GridInk.Columns[3].HeaderText = this.objlang.GetLanguageConversion("Pack_Price");
            if (base.Session["CompanyID"] != null)
            {
                this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            }
            if (base.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(base.Session["UserID"]);
            }
            if (base.Request.Params["id"] != null)
            {
                this.inkid = base.Request.Params["id"];
            }
            if (base.Request.Params["IsLargeFormat"] != null)
            {
                this.IsLargeItem = "true";
            }
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            this.paperWeight = this.objBase.SpecialDecode(dataTable.Rows[0]["Weight"].ToString());
            if (base.Request.Params["item"] != null)
            {
                this.div_MainInk.Visible = false;
                this.div_MainInv.Visible = false;
                if (base.Request.Params["item"].ToString().ToLower() == "ink")
                {
                    this.div_MainInk.Visible = true;
                    this.ItemType = "inks";
                    try
                    {
                        this.InkType = base.Request.QueryString["InkType"].ToString();
                    }
                    catch
                    {
                    }
                }
                else if (base.Request.Params["item"].ToString().ToLower() != "plates")
                {
                    this.div_MainInv.Visible = true;
                    try
                    {
                        if (base.Request.Params["paperType"] != null)
                        {
                            this.paperType = base.Request.Params["paperType"].ToString();
                        }
                        if (this.paperType.ToString().Trim().Length == 0)
                        {
                            this.paperType = "sheet";
                        }
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
                }
                else
                {
                    this.div_MainInk.Visible = true;
                    this.ItemType = "plates";
                }
            }
            if (base.Request.Params["MaterialNo"] != null && base.Request.Params["MaterialNo"].ToString() != "")
            {
                this.MaterialNo = Convert.ToInt32(base.Request.Params["MaterialNo"].ToString());
            }
            if (base.Request.Params["inkcolor"] != null)
            {
                this.IsColororwhiteink = base.Request.Params["inkcolor"].ToString();
            }
            ((ImageButton)this.UCInventory_Add.FindControl("ImageButton8")).Visible = false;
            ((ImageButton)this.UCInventory_Add.FindControl("ImageButtonPlus")).Visible = true;
            if (base.Request.Params["invid"] != null)
            {
                this.AddedItem = base.Request.Params["item"].ToString().ToLower();
                this.InvID = Convert.ToInt64(base.Request.Params["invid"].ToString());
                this.InvName = base.Request.Params["invname"].ToString();
                this.pnlAddNewPaper.Visible = true;
            }
        }
    }
}