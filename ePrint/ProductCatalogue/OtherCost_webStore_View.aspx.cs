using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.ProductCatalogue
{
    public partial class OtherCost_webStore_View : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        private commonClass objJava = new commonClass();

        public int totalrec;

        public int PageSize = 10000;

        public languageClass objlang = new languageClass();

        public string formatScript = "";

        public string AdditionalType = "p";

        public static Hashtable ht;

        public static int Pagenumber;

        public string AddStatus = string.Empty;

        public string DeleteStatus = string.Empty;

        public string WhereConditionAdditionaloptions = string.Empty;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<OtherCost_webStore_View.OrderNew> PendingOrders
        {
            get
            {
                IList<OtherCost_webStore_View.OrderNew> orderNews;
                try
                {
                    object item = this.Session["webtable"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<OtherCost_webStore_View.OrderNew>();
                        }
                        else
                        {
                            this.Session["webtable"] = item;
                        }
                    }
                    orderNews = (IList<OtherCost_webStore_View.OrderNew>)item;
                }
                catch
                {
                    this.Session["webtable"] = null;
                    return new List<OtherCost_webStore_View.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["webtable"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static OtherCost_webStore_View()
        {
            OtherCost_webStore_View.ht = new Hashtable();
            OtherCost_webStore_View.Pagenumber = 1;
        }

        public OtherCost_webStore_View()
        {
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/othercost_add.aspx"));
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hid_Delete_IDs.Value))
            {
                string[] strArrays = this.hid_Delete_IDs.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        WebstoreBasePage.Othercost_Webstore_Delete(this.CompanyID, Convert.ToInt64(strArrays[i]));
                    }
                }
                base.Message_Display(this.objlang.GetLanguageConversion("Additional_Option_Deleted_Successfully"), "msg-success", this.plhMessage);
                this.GridWebOtherCost.DataSource = WebstoreBasePage.SettingsWebStore_OtherCost_PageText(this.CompanyID, this.PageSize, OtherCost_webStore_View.Pagenumber, "OrderNumber", "asc", "", "p", true);
                this.GridWebOtherCost.DataBind();
            }
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.GridWebOtherCost.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridWebOtherCost.MasterTableView.FilterExpression = string.Empty;
            this.GridWebOtherCost.MasterTableView.Rebind();
        }

        private static OtherCost_webStore_View.OrderNew GetOrder(IEnumerable<OtherCost_webStore_View.OrderNew> ordersToSearchIn, long WebOtherCostID)
        {
            OtherCost_webStore_View.OrderNew orderNew;
            using (IEnumerator<OtherCost_webStore_View.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    OtherCost_webStore_View.OrderNew current = enumerator.Current;
                    if (current.WebOtherCostID != WebOtherCostID)
                    {
                        continue;
                    }
                    orderNew = current;
                    return orderNew;
                }
                return null;
            }
            return orderNew;
        }

        protected IList<OtherCost_webStore_View.OrderNew> GetOrders()
        {
            IList<OtherCost_webStore_View.OrderNew> orderNews = new List<OtherCost_webStore_View.OrderNew>();
            int num = 1;
            DataSet dataSet = WebstoreBasePage.SettingsWebStore_OtherCost_PageText(this.CompanyID, this.PageSize, num, "OrderNumber", "asc", "", "p", true);
            DataTable item = dataSet.Tables[0];
            if (item.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in item.Rows)
                    {
                        long num1 = Convert.ToInt64(row["WebOtherCostID"].ToString());
                        string str = base.SpecialDecode(row["OtherCostCategoryName"].ToString());
                        string str1 = base.SpecialDecode(row["WebOtherCostName"].ToString());
                        string str2 = base.SpecialDecode(row["UserFriendlyName"].ToString());
                        string str3 = base.SpecialDecode(row["Description"].ToString());
                        string str4 = base.SpecialDecode(row["IsSubAdditionOption"].ToString());
                        orderNews.Add(new OtherCost_webStore_View.OrderNew(num1, str, str1, str2, str3, str4));
                    }
                    this.Session["webtable"] = item;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        protected void grdwebstoreothercost_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GridWebOtherCost.DataSource = this.PendingOrders;
        }

        protected void grdwWebStoreOthercost_RowDrop(object sender, GridDragDropEventArgs e)
        {
            OtherCost_webStore_View.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridWebOtherCost.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridWebOtherCost.ClientID)
            {
                IList<OtherCost_webStore_View.OrderNew> pendingOrders = this.PendingOrders;
                OtherCost_webStore_View.OrderNew order = OtherCost_webStore_View.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("WebOtherCostID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<OtherCost_webStore_View.OrderNew> orderNews = new List<OtherCost_webStore_View.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    OtherCost_webStore_View.OrderNew orderNew = OtherCost_webStore_View.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("WebOtherCostID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (OtherCost_webStore_View.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    OtherCost_webStore_View.ht.Add(pendingOrders[i].WebOtherCostID, i + 1);
                }
                this.GridWebOtherCost.DataSource = this.PendingOrders;
                this.GridWebOtherCost.Rebind();
                int pageSize = 0;
                if (num <= this.GridWebOtherCost.PageSize * this.GridWebOtherCost.PageCount && e.DestinationTableView.Items.Count > 0)
                {
                    pageSize = num - this.GridWebOtherCost.PageSize * this.GridWebOtherCost.CurrentPageIndex;
                    pageSize = e.DestDataItem.ItemIndex;
                    if (pageSize <= e.DestinationTableView.Items.Count && pageSize > 0)
                    {
                        e.DestinationTableView.Items[pageSize].Selected = true;
                    }
                }
                foreach (long key in OtherCost_webStore_View.ht.Keys)
                {
                    SettingsBasePage.settings_webstoreothercost_order_number_update(this.CompanyID, Convert.ToInt32(key), Convert.ToInt32(OtherCost_webStore_View.ht[key]));
                }
            }
        }

        protected void GridBind(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            DataSet dataSet = WebstoreBasePage.SettingsWebStore_OtherCost_PageText(CompanyID, PageSize, PageNumber, "OrderNumber", "asc", WhereCondition, "p", true);
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                dataSet.Tables[0].Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["WebOtherCostName"] = base.SpecialDecode(row["WebOtherCostName"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
                row["Description"] = base.SpecialDecode(row["Description"].ToString());
                row["OtherCostCategoryName"] = base.SpecialDecode(row["OtherCostCategoryName"].ToString());
                row["IsSubAdditionOption"] = base.SpecialDecode(row["IsSubAdditionOption"].ToString());
            }
            this.GridWebOtherCost.DataSource = dataSet.Tables[0];
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.hidGridCount.Value = this.totalrec.ToString();
                return;
            }
            this.div_Main.Style.Add("display", "block");
            this.GridWebOtherCost.DataBind();
            this.totalrec = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            this.hidGridCount.Value = this.totalrec.ToString();
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew("setting", "GridWebOtherCostSettings", this.GridWebOtherCost, "no");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew("setting", "GridWebOtherCostSettings", this.GridWebOtherCost);
        }

        protected void GridWebOtherCost_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            GridTableView masterTableView = this.GridWebOtherCost.MasterTableView;
            GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
            GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
            HtmlControl htmlControl = (HtmlControl)items.FindControl("div_AddNewRecord");
            if (this.AddStatus.Trim().ToLower() != "false")
            {
                htmlControl.Visible = true;
            }
            else
            {
                htmlControl.Visible = false;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                ImageButton imageButton = (ImageButton)e.Item.FindControl("ImgButtonDelete");
                ImageButton imageButton1 = (ImageButton)e.Item.FindControl("imgbtnCopy");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_webothercostid_Categoryname");
                string str = "";
                if (hiddenField.Value != "")
                {
                    str = string.Concat(this.strSitepath, "ProductCatalogue/Othercost_webstore.aspx?type=edit&id=", hiddenField.Value);
                }
                if (this.AddStatus.Trim().ToLower() != "false")
                {
                    imageButton1.Visible = true;
                }
                else
                {
                    imageButton1.Visible = false;
                }
                if (this.DeleteStatus.Trim().ToLower() != "false")
                {
                    imageButton.Visible = true;
                }
                else
                {
                    imageButton.Visible = false;
                }
                e.Item.Cells[3].Attributes.Add("style", "Cursor:pointer");
                e.Item.Cells[3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                e.Item.Cells[4].Attributes.Add("style", "Cursor:pointer");
                e.Item.Cells[4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                e.Item.Cells[5].Attributes.Add("style", "Cursor:pointer");
                e.Item.Cells[5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                e.Item.Cells[6].Attributes.Add("style", "Cursor:pointer");
                e.Item.Cells[6].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                e.Item.Cells[7].Attributes.Add("style", "Cursor:pointer");
                e.Item.Cells[7].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                int count = this.GridWebOtherCost.Items.Count;
                if (count > this.GridWebOtherCost.PageSize * count)
                {
                    this.GridWebOtherCost.ClientSettings.AllowRowsDragDrop = false;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView gridTableView = this.GridWebOtherCost.MasterTableView;
                GridItemType[] gridItemTypeArray1 = new GridItemType[] { GridItemType.Pager };
                GridPagerItem gridPagerItem = (GridPagerItem)gridTableView.GetItems(gridItemTypeArray1)[0];
                this.GridWebOtherCost.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridWebOtherCost_PazeIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.GridWebOtherCost.CurrentPageIndex = e.NewPageIndex;
            this.GridWebOtherCost.Rebind();
        }

        protected void GridWebOtherCost_PazeSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.GridWebOtherCost.Rebind();
        }

        protected void imgbtnCopy_OnCommand(object sender, CommandEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            long num = WebstoreBasePage.SettingsWebStore_OtherCost_Copy(this.CompanyID, Convert.ToInt64(imageButton.CommandArgument.ToString()));
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "ProductCatalogue/Othercost_webstore.aspx?type=edit&id=", num, "&cop=yes" };
            response.Redirect(string.Concat(objArray));
        }

        protected void imgbtnDelete_OnClick(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.Othercost_Webstore_Delete(this.CompanyID, Convert.ToInt64(e.CommandArgument));
            base.Message_Display(this.objlang.GetLanguageConversion("Additional_Option_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridWebOtherCost.DataSource = WebstoreBasePage.SettingsWebStore_OtherCost_PageText(this.CompanyID, this.PageSize, OtherCost_webStore_View.Pagenumber, "OrderNumber", "asc", "", "p", true);
            this.GridWebOtherCost.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridWebOtherCost.FilterMenu;
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
            GridFilterFunction.IllegalStrings = new string[] { " \"" };
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("productcatalogue", "isview", "");
            BaseClass baseClass = new BaseClass();
            this.AddStatus = baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isadd", this.Page.Request.Url.ToString());
            this.DeleteStatus = baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdelete", this.Page.Request.Url.ToString());
            this.gloobj.setpagename("productcatalogue");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("home_Page_Details"), "</a>&nbsp;>&nbsp;<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Product_Catalogue_Additional_Option_view")));
            base.Title = this.objLanguage.convert(global.pageTitle("Product Catalogue Additional Option View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.GridWebOtherCost.MasterTableView.NoMasterRecordsText = this.objlang.GetLanguageConversion("No_records_to_Display");
            if (!base.IsPostBack)
            {
                this.GridBind(this.CompanyID, this.PageSize, OtherCost_webStore_View.Pagenumber, "OrderNumber", "asc", "");
                this.Session["searchadditionaloptionstbl"] = null;
                this.Session["webtable"] = null;
                if (base.Request.Params["su"] != null)
                {
                    if (base.Request.Params["su"] == "in")
                    {
                        base.Message_Display(this.objlang.GetLanguageConversion("Additional_Option_Saved_Successfully"), "msg-success", this.plhMessage);
                    }
                    else if (base.Request.Params["su"] == "up")
                    {
                        base.Message_Display(this.objlang.GetLanguageConversion("Additional_Option_Updated_Successfully"), "msg-success", this.plhMessage);
                    }
                    else if (base.Request.Params["su"] == "de")
                    {
                        base.Message_Display(this.objlang.GetLanguageConversion("Additional_Option_Deleted_Successfully"), "msg-success", this.plhMessage);
                    }
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
        }

        protected class OrderNew
        {
            private long _WebOtherCostID;

            private string _OtherCostCategoryName;

            private string _WebOtherCostName;

            private string _UserFriendlyName;

            private string _Description;

            private string _IsSubAdditionOption;

            public string Description
            {
                get
                {
                    return this._Description;
                }
            }

            public string IsSubAdditionOption
            {
                get
                {
                    return this._IsSubAdditionOption;
                }
            }

            public string OtherCostCategoryName
            {
                get
                {
                    return this._OtherCostCategoryName;
                }
            }

            public string UserFriendlyName
            {
                get
                {
                    return this._UserFriendlyName;
                }
            }

            public long WebOtherCostID
            {
                get
                {
                    return this._WebOtherCostID;
                }
            }

            public string WebOtherCostName
            {
                get
                {
                    return this._WebOtherCostName;
                }
            }

            public OrderNew(long WebOtherCostID, string OtherCostCategoryName, string WebOtherCostName, string UserFriendlyName, string Description, string IsSubAdditionOption)
            {
                this._WebOtherCostID = WebOtherCostID;
                this._OtherCostCategoryName = OtherCostCategoryName;
                this._WebOtherCostName = WebOtherCostName;
                this._UserFriendlyName = UserFriendlyName;
                this._Description = Description;
                this._IsSubAdditionOption = IsSubAdditionOption;
            }
        }
    }
}