using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
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

namespace ePrint.StoreSettings
{
    public partial class manage_page : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        private commonClass cmncls = new commonClass();

        private commonClass commclass = new commonClass();

        private BasePage objPage = new BasePage();

        public string ImgPath = global.imagePath();

        private DataTable dtsearch = new DataTable();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public static string WhereCondition;

        public string DateFormat = string.Empty;

        public static Hashtable ht;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public string stay = "m";

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

        protected IList<manage_page.OrderNew> SortOrders
        {
            get
            {
                IList<manage_page.OrderNew> orderNews;
                try
                {
                    object item = this.Session["Account"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<manage_page.OrderNew>();
                        }
                        else
                        {
                            this.Session["Account"] = item;
                        }
                    }
                    orderNews = (IList<manage_page.OrderNew>)item;
                }
                catch
                {
                    this.Session["Account"] = null;
                    return new List<manage_page.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["Account"] = value;
            }
        }

        static manage_page()
        {
            manage_page.WhereCondition = string.Empty;
            manage_page.ht = new Hashtable();
        }

        public manage_page()
        {
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            foreach (int key in manage_page.ht.Keys)
            {
                WebstoreBasePage.pagesSort(Convert.ToInt32(key), this.CompanyID, this.AccountID, Convert.ToInt32(manage_page.ht[key]));
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Manage_Page_Sorted_Successfully"), "msg-success", this.plhMessageNew);
            this.gridBinding_GridView1(this.CompanyID, this.AccountID);
            this.gridBinding_RadGrid1(this.CompanyID, this.AccountID);
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            this.Session["searchClient"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridView1.MasterTableView.Rebind();
        }

        protected void Delete_OnClick(object sender, EventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            for (int i = 0; i < this.GridView1.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.GridView1.Items[i].Cells[0].FindControl("Id");
                if (htmlInputCheckBox.Checked)
                {
                    WebstoreBasePage.pageDelete(Convert.ToInt32(htmlInputCheckBox.Value));
                    htmlInputCheckBox.Checked = false;
                }
            }
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Page_deleted_successfully"), "msg-success", this.plhMessageNew);
            this.gridBinding_GridView1(this.CompanyID, this.AccountID);
            this.gridBinding_RadGrid1(this.CompanyID, this.AccountID);
        }

        protected void DeleteImg_OnClick(object sender, CommandEventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            WebstoreBasePage.pageDelete(Convert.ToInt32(e.CommandArgument));
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Page_deleted_successfully"), "msg-success", this.plhMessageNew);
            this.gridBinding_GridView1(this.CompanyID, this.AccountID);
            this.gridBinding_RadGrid1(this.CompanyID, this.AccountID);
        }

        private static manage_page.OrderNew GetOrder(IEnumerable<manage_page.OrderNew> ordersToSearchIn, int pageID)
        {
            manage_page.OrderNew orderNew;
            using (IEnumerator<manage_page.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    manage_page.OrderNew current = enumerator.Current;
                    if (current.pageID != pageID)
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

        protected IList<manage_page.OrderNew> GetOrders()
        {
            IList<manage_page.OrderNew> orderNews = new List<manage_page.OrderNew>();
            DataTable dataTable = this.GridCategoryBindTable();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    int num = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int num1 = Convert.ToInt32(row["pageID"].ToString());
                        string str = row["systemName"].ToString().Trim();
                        string str1 = row["pageName"].ToString().Trim();
                        string str2 = row["modifiedDate"].ToString().Trim();
                        orderNews.Add(new manage_page.OrderNew(num1, str, str1, str2, num));
                        num++;
                    }
                    this.Session["Account"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        public void gridBinding_GridView1(int CompanyID, int AccountID)
        {
            DataTable dataTable = WebstoreBasePage.pagesSelect(CompanyID, AccountID, "view");
            this.GridView1.DataSource = dataTable;
            this.GridView1.DataBind();
        }

        public void gridBinding_RadGrid1(int CompanyID, int AccountID)
        {
            DataTable dataTable = WebstoreBasePage.pagesSelect(CompanyID, AccountID, "view");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    if (row.Table.Columns.Contains("modifiedDate"))
                    {
                        row["modifiedDate"] = this.cmncls.Eprint_return_Date_Before_View(row["modifiedDate"].ToString(), CompanyID, this.UserID, false);
                    }
                }
                catch
                {
                }
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.Table.Columns["systemname"] != null)
                {
                    dataRow["systemName"] = this.objBase.SpecialDecode(dataRow["systemName"].ToString());
                }
                if (dataRow.Table.Columns["pagename"] == null)
                {
                    continue;
                }
                dataRow["pageName"] = this.objBase.SpecialDecode(dataRow["pageName"].ToString());
            }
            this.RadGrid1.DataSource = dataTable;
            this.RadGrid1.DataBind();
        }

        protected DataTable GridCategoryBindTable()
        {
            return WebstoreBasePage.pagesSelect(this.CompanyID, this.AccountID, "view");
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                string str = ((Pair)e.CommandArgument).Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                if (str.ToLower() == "modifieddate")
                {
                    this.Session["searchClient"] = item.Text;
                    item.Text = this.cmncls.Eprint_return_Date_Before_View(item.Text, this.CompanyID, this.UserID, false);
                }
            }
        }

        protected void GridView1_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = WebstoreBasePage.pagesSelect(this.CompanyID, this.AccountID, "view");
            this.GridView1.DataSource = dataTable;
        }

        protected void GridView1_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    Label label = (Label)e.Item.FindControl("lbl_dateGridView1");
                    label.Text = this.cmncls.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, false);
                    HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                    LinkButton linkButton = (LinkButton)e.Item.FindControl("lnk_systemName");
                    Image image = (Image)e.Item.FindControl("ImgButtonDelete");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_IsDefaultLand");
                    Image image1 = (Image)e.Item.FindControl("img_DefaultLand");
                    if (((HiddenField)e.Item.FindControl("hdn_ShowPageIn")).Value.ToLower() == "n")
                    {
                        image1.ImageUrl = string.Concat(this.ImgPath, "1t.gif");
                    }
                    else
                    {
                        image1.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_u.gif");
                    }
                    if (hiddenField.Value.ToLower() == "true")
                    {
                        image1.ImageUrl = string.Concat(this.ImgPath, "ICON_checkbox_d.gif");
                    }
                    if (linkButton.Text == "Home" || linkButton.Text == "Products" || linkButton.Text == "Sitemap" || linkButton.Text == "404" || linkButton.Text == "Saved Drafts" || linkButton.Text == "Orders" || linkButton.Text == "Dash Board" || linkButton.Text == "Campaign" || linkButton.Text == "Reports")
                    {
                        htmlInputCheckBox.Disabled = true;
                        image.Visible = false;
                    }
                }
                if (e.Item.ItemType == GridItemType.FilteringItem)
                {
                    GridFilteringItem item = (GridFilteringItem)e.Item;
                    TextBox str = (e.Item as GridFilteringItem)["modifieddate"].Controls[0] as TextBox;
                    string regionalSettings = this.objPage.GetRegionalSettings(this.CompanyID, "Dateformat");
                    if (this.Session["searchClient"] != null && regionalSettings == "dd/mm/yyyy")
                    {
                        str.Text = this.Session["searchClient"].ToString();
                    }
                }
            }
            catch
            {
            }
        }

        public void OnClick_lnkaccountsList(object sender, EventArgs e)
        {
            this.gridBinding_RadGrid1(this.CompanyID, this.AccountID);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.lnkSave.Text = this.objLanguage.GetLanguageConversion("Save");
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Manage_Page")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Manage Pages", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            AccountsBaseClass accountsBaseClass = new AccountsBaseClass();
            this.header.dtAccountList = accountsBaseClass.accountsList(this.CompanyID);
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Page");
            if (base.Request.Params["suc"] != null)
            {
                if (base.Request.Params["suc"] == "in")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Manage_Page_Saved_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "up")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Manage_Page_Updated_Successfully"), "msg-success", this.plhMessageNew);
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["page"] != null)
                {
                    this.stay = base.Request.Params["page"];
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Manage_Page_Sorted_Successfully"), "msg-success", this.plhMessageNew);
                }
                this.gridBinding_GridView1(this.CompanyID, this.AccountID);
                this.gridBinding_RadGrid1(this.CompanyID, this.AccountID);
                this.Session["Account"] = null;
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.commclass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.commclass.functionCheckChange());
            }
        }

        public DataTable pagesSelect()
        {
            return WebstoreBasePage.pagesSelect(this.CompanyID, this.AccountID, "view");
        }

        protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid1.DataSource = this.SortOrders;
        }

        protected void RadGrid1_RowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Label label = (Label)e.Item.FindControl("lbl_date");
                    label.Text = this.cmncls.Eprint_return_Date_Before_View(label.Text, this.CompanyID, this.UserID, false);
                }
            }
            catch
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGrid1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGrid1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGrid1_RowDrop(object sender, GridDragDropEventArgs e)
        {
            manage_page.ht.Clear();
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid1.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid1.ClientID)
            {
                IList<manage_page.OrderNew> sortOrders = this.SortOrders;
                manage_page.OrderNew order = manage_page.GetOrder(sortOrders, Convert.ToInt32(e.DestDataItem.GetDataKeyValue("pageID")));
                int num = sortOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<manage_page.OrderNew> orderNews = new List<manage_page.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    manage_page.OrderNew orderNew = manage_page.GetOrder(sortOrders, Convert.ToInt32(draggedItem.GetDataKeyValue("pageID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (manage_page.OrderNew orderNew1 in orderNews)
                {
                    sortOrders.Remove(orderNew1);
                    sortOrders.Insert(num, orderNew1);
                }
                for (int i = 0; i < sortOrders.Count; i++)
                {
                    manage_page.ht.Add(sortOrders[i].pageID, i + 1);
                }
                this.SortOrders = sortOrders;
                this.RadGrid1.DataSource = this.SortOrders;
                this.RadGrid1.Rebind();
                int pageSize = num - this.RadGrid1.PageSize * this.RadGrid1.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void setDefaultLand_OnClick(object sender, CommandEventArgs e)
        {
            WebstoreBasePage.client_defaultLand(this.CompanyID, this.AccountID, Convert.ToInt32(e.CommandArgument));
            this.objBase.Message_Display("Default land page set successfully", "msg-success", this.plhMessageNew);
            this.GridView1.Rebind();
        }

        protected class OrderNew
        {
            private int _pageID;

            private string _systemName;

            private string _pageName;

            private string _modifiedDate;

            private int _ReorderNo;

            public string modifiedDate
            {
                get
                {
                    return this._modifiedDate;
                }
            }

            public int pageID
            {
                get
                {
                    return this._pageID;
                }
            }

            public string pageName
            {
                get
                {
                    return this._pageName;
                }
            }

            public int ReorderNo
            {
                get
                {
                    return this._ReorderNo;
                }
            }

            public string systemName
            {
                get
                {
                    return this._systemName;
                }
            }

            public OrderNew(int pageID, string systemName, string pageName, string modifiedDate, int ReorderNo)
            {
                this._pageID = pageID;
                this._systemName = systemName;
                this._pageName = pageName;
                this._modifiedDate = modifiedDate;
                this._ReorderNo = ReorderNo;
            }
        }
    }
}