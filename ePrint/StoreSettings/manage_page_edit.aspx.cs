
using nmsCommon;
using nmsConnectionClass;
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
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.FileExplorer;

namespace ePrint.StoreSettings
{
    public partial class manage_page_edit : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public string strFilepath = global.filePath();

        private WebstoreBasePage objeStore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objlang = new languageClass();

        public static int CompanyID;

        public int UserID;

        public static int AccountID;

        public int pageID;

        public int NoOfItems_featured;

        public int NoOfItems_selected;

        public long homePageID;

        public static int sortOrderID;

        public string TypeIDs = string.Empty;

        public static int PageID;

        private char ShowPage = 'N';

        public string stay = "c";

        public string mode = string.Empty;

        public string CPOptionText = string.Empty;

        public string CenterPanelOption = string.Empty;

        public string imagePath = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private DataTable dt_featuredProduct;

        private DataTable dt_seletedProduct;

        private ContentManagementWebService objContent = new ContentManagementWebService();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<manage_page_edit.OrderNew> AvailableOrders
        {
            get
            {
                IList<manage_page_edit.OrderNew> orderNews;
                try
                {
                    object item = this.Session["available_orders"];
                    if (item == null)
                    {
                        item = this.GetAvailableOrders();
                        if (item == null)
                        {
                            item = new List<manage_page_edit.OrderNew>();
                        }
                        else
                        {
                            this.Session["available_orders"] = item;
                        }
                    }
                    orderNews = (IList<manage_page_edit.OrderNew>)item;
                }
                catch
                {
                    this.Session["available_orders"] = null;
                    return new List<manage_page_edit.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["available_orders"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        protected IList<manage_page_edit.OrderNew> SelectedOrders
        {
            get
            {
                IList<manage_page_edit.OrderNew> orderNews;
                try
                {
                    object item = this.Session["selected_orders"];
                    if (item == null)
                    {
                        item = this.GetSelectedOrders();
                        if (item == null)
                        {
                            item = new List<manage_page_edit.OrderNew>();
                        }
                        else
                        {
                            this.Session["selected_orders"] = item;
                        }
                    }
                    orderNews = (IList<manage_page_edit.OrderNew>)item;
                }
                catch
                {
                    this.Session["selected_orders"] = null;
                    return new List<manage_page_edit.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["selected_orders"] = value;
            }
        }

        static manage_page_edit()
        {
        }

        public manage_page_edit()
        {
        }

        public void Bind_featuredProducts(long CompanyID, long AccountID)
        {
            this.dt_featuredProduct = WebstoreBasePage.products_Select(CompanyID, AccountID);
            foreach (DataRow row in this.dt_featuredProduct.Rows)
            {
                row["CatalogueName"] = base.SpecialDecode(row["CatalogueName"].ToString());
                row["ItemTitle"] = base.SpecialDecode(row["ItemTitle"].ToString());
            }
            this.RadGrid_featuredProducts.DataSource = this.dt_featuredProduct;
            this.RadGrid_featuredProducts.DataBind();
        }

        public void Bind_selectedProducts(long CompanyID, long AccountID)
        {
            this.dt_seletedProduct = WebstoreBasePage.FeaturedProducts_Select(CompanyID, AccountID);
            foreach (DataRow row in this.dt_seletedProduct.Rows)
            {
                row["CatalogueName"] = base.SpecialDecode(row["CatalogueName"].ToString());
                row["PriceCatalogueCategoryName"] = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
            }
            this.RadGrid_seletedProducts.DataSource = this.dt_seletedProduct;
            this.RadGrid_seletedProducts.DataBind();
        }

        private static void BindTrreView(RadTreeView treeView)
        {
            long num = (long)0;
            DataSet catgoryList = WebstoreBasePage.GetCatgoryList(manage_page_edit.CompanyID, manage_page_edit.AccountID, num);
            treeView.DataTextField = "PriceCatalogueCategoryName";
            treeView.DataFieldID = "PriceCatalogueCategoryID";
            treeView.DataSource = catgoryList;
            treeView.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("manage_page.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            this.save("save");
        }

        protected void btn_SaveHP_Click(object sender, EventArgs e)
        {
            if (this.chk_topNavi.Checked)
            {
                this.ShowPage = 'H';
            }
            if (this.chk_footer.Checked)
            {
                this.ShowPage = 'F';
            }
            if (this.chk_footer.Checked && this.chk_topNavi.Checked)
            {
                this.ShowPage = 'B';
            }
            if (manage_page_edit.AccountID == 0 || manage_page_edit.CompanyID == 0 || this.pageID == 0)
            {
                this.pnl_alert.Visible = true;
                return;
            }
            WebstoreBasePage.pagesInsert(this.pageID, manage_page_edit.CompanyID, manage_page_edit.AccountID, base.SpecialEncode(this.txt_title.Text), base.SpecialEncode(this.txt_title.Text), DateTime.Now, manage_page_edit.sortOrderID, this.RadEditor1.Content, base.SpecialEncode(this.txt_title_property.Text), this.txt_description.Text, this.txt_key.Text, this.ShowPage, DateTime.Now);
            if (this.rdn_Feature.Checked)
            {
                this.CPOptionText = "Featured";
            }
            else if (this.rdn_new.Checked)
            {
                this.CPOptionText = "New";
            }
            else if (this.rdn_customize.Checked)
            {
                this.CPOptionText = "Html";
            }
            else if (this.rdbCustomizeNew.Checked)
            {
                this.CPOptionText = "Custom";
            }
            this.homePageID = WebstoreBasePage.homePageUpdate(Convert.ToInt64(this.pageID), Convert.ToInt32(this.chk_slidingBanner.Checked), this.txt_centerPaneltext.Text, this.CPOptionText.ToString(), this.RadEditor_customize.Content);
            if (this.rdn_Feature.Checked)
            {
                IList<manage_page_edit.OrderNew> selectedOrders = this.SelectedOrders;
                if (base.Request.Cookies["SelectedProductsIDs"] != null)
                {
                    WebstoreBasePage.FeaturedProducts_Update((long)manage_page_edit.CompanyID, (long)manage_page_edit.AccountID);
                    string[] strArrays = base.Request.Cookies["SelectedProductsIDs"].Value.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        if (strArrays[i] != "")
                        {
                            long num = Convert.ToInt64(strArrays[i]);
                            WebstoreBasePage.FeaturedProducts_Insert((long)manage_page_edit.CompanyID, (long)manage_page_edit.AccountID, num, (long)(i + 1));
                        }
                    }
                }
            }
            if (this.hdnIsRightBanner.Value != "")
            {
                this.objContent.SaveIsRightBanner((long)manage_page_edit.CompanyID, (long)manage_page_edit.AccountID, Convert.ToInt32(this.hdnIsRightBanner.Value));
            }
            if (this.hdnCustomHeigthWidth.Value != "")
            {
                this.objContent.UpdateCustomText((long)manage_page_edit.AccountID, this.hdnCustomHeigthWidth.Value);
            }
            if (this.hdnIDs.Value != "")
            {
                this.objContent.UpdateCustomOrder((long)manage_page_edit.AccountID, this.hdnIDs.Value);
            }
            base.Response.Redirect("manage_page.aspx?suc=up");
        }

        protected void btn_saveStay_Click(object sender, EventArgs e)
        {
            this.save("savestay");
        }

        protected void BtnMove_Onclick(object sender, EventArgs e)
        {
            IList<manage_page_edit.OrderNew> selectedOrders = this.SelectedOrders;
            IList<manage_page_edit.OrderNew> availableOrders = this.AvailableOrders;
            if (base.Request.Cookies["MoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["MoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        manage_page_edit.OrderNew order = manage_page_edit.GetOrder(availableOrders, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            selectedOrders.Add(order);
                            availableOrders.Remove(order);
                        }
                    }
                }
            }
            this.SelectedOrders = selectedOrders;
            this.AvailableOrders = availableOrders;
            this.RadGrid_featuredProducts.Rebind();
            this.RadGrid_seletedProducts.Rebind();
        }

        protected void BtnReMove_Onclick(object sender, EventArgs e)
        {
            IList<manage_page_edit.OrderNew> selectedOrders = this.SelectedOrders;
            IList<manage_page_edit.OrderNew> availableOrders = this.AvailableOrders;
            if (base.Request.Cookies["RemoveOrders"] != null)
            {
                string[] strArrays = base.Request.Cookies["RemoveOrders"].Value.ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].ToString() != "")
                    {
                        manage_page_edit.OrderNew order = manage_page_edit.GetOrder(selectedOrders, Convert.ToInt64(strArrays[i].ToString()));
                        if (order != null)
                        {
                            this.AvailableOrders.Add(order);
                            selectedOrders.Remove(order);
                        }
                    }
                }
            }
            this.SelectedOrders = selectedOrders;
            this.AvailableOrders = availableOrders;
            this.RadGrid_featuredProducts.Rebind();
            this.RadGrid_seletedProducts.Rebind();
        }

        private string GetAllContentByAccountId(long AccountID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DataTable contentByAccountId = WebstoreBasePage.GetContentByAccountId(AccountID);
            for (int i = 0; i < contentByAccountId.Rows.Count; i++)
            {
                stringBuilder.Append(contentByAccountId.Rows[i]["TypeID"].ToString());
                stringBuilder.Append("μ");
            }
            return stringBuilder.ToString();
        }

        protected IList<manage_page_edit.OrderNew> GetAvailableOrders()
        {
            IList<manage_page_edit.OrderNew> orderNews = new List<manage_page_edit.OrderNew>();
            DataTable dataTable = WebstoreBasePage.products_Select(Convert.ToInt64(manage_page_edit.CompanyID), Convert.ToInt64(manage_page_edit.AccountID));
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                        string str = base.SpecialDecode(row["CatalogueName"].ToString());
                        string str1 = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
                        orderNews.Add(new manage_page_edit.OrderNew((long)0, num, str, str1));
                    }
                    this.Session["available_orders"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        private static manage_page_edit.OrderNew GetOrder(IEnumerable<manage_page_edit.OrderNew> ordersToSearchIn, long PriceCatalogueID)
        {
            manage_page_edit.OrderNew orderNew;
            using (IEnumerator<manage_page_edit.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    manage_page_edit.OrderNew current = enumerator.Current;
                    if (current.PriceCatalogueID != PriceCatalogueID)
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

        protected IList<manage_page_edit.OrderNew> GetSelectedOrders()
        {
            IList<manage_page_edit.OrderNew> orderNews = new List<manage_page_edit.OrderNew>();
            DataTable dataTable = WebstoreBasePage.FeaturedProducts_Select(Convert.ToInt64(manage_page_edit.CompanyID), Convert.ToInt64(manage_page_edit.AccountID));
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["FeaturedProductsID"].ToString());
                        long num1 = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                        string str = base.SpecialDecode(row["CatalogueName"].ToString());
                        string str1 = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
                        orderNews.Add(new manage_page_edit.OrderNew(num, num1, str, str1));
                    }
                    this.Session["selected_orders"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        protected void grdAvailableOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid_featuredProducts.ClientID)
            {
                if (e.DestDataItem == null && this.SelectedOrders.Count == 0 || e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_seletedProducts.ClientID)
                {
                    IList<manage_page_edit.OrderNew> selectedOrders = this.SelectedOrders;
                    IList<manage_page_edit.OrderNew> availableOrders = this.AvailableOrders;
                    int num = -1;
                    if (e.DestDataItem != null)
                    {
                        manage_page_edit.OrderNew order = manage_page_edit.GetOrder(this.SelectedOrders, (long)e.DestDataItem.GetDataKeyValue("PriceCatalogueID"));
                        num = (order != null ? this.SelectedOrders.IndexOf(order) : -1);
                    }
                    foreach (GridDataItem draggedItem in e.DraggedItems)
                    {
                        manage_page_edit.OrderNew orderNew = manage_page_edit.GetOrder(availableOrders, (long)draggedItem.GetDataKeyValue("PriceCatalogueID"));
                        if (orderNew == null)
                        {
                            continue;
                        }
                        if (num <= -1)
                        {
                            this.SelectedOrders.Add(orderNew);
                        }
                        else
                        {
                            if (e.DropPosition == GridItemDropPosition.Below)
                            {
                                num++;
                            }
                            this.SelectedOrders.Insert(num, orderNew);
                        }
                        availableOrders.Remove(orderNew);
                    }
                    this.SelectedOrders = selectedOrders;
                    this.AvailableOrders = availableOrders;
                    this.RadGrid_featuredProducts.Rebind();
                    this.RadGrid_seletedProducts.Rebind();
                    return;
                }
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_featuredProducts.ClientID)
                {
                    IList<manage_page_edit.OrderNew> orderNews = this.AvailableOrders;
                    manage_page_edit.OrderNew order1 = manage_page_edit.GetOrder(orderNews, (long)e.DestDataItem.GetDataKeyValue("PriceCatalogueID"));
                    int num1 = orderNews.IndexOf(order1);
                    if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                    {
                        num1--;
                    }
                    if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                    {
                        num1++;
                    }
                    List<manage_page_edit.OrderNew> orderNews1 = new List<manage_page_edit.OrderNew>();
                    foreach (GridDataItem gridDataItem in e.DraggedItems)
                    {
                        manage_page_edit.OrderNew orderNew1 = manage_page_edit.GetOrder(orderNews, (long)gridDataItem.GetDataKeyValue("PriceCatalogueID"));
                        if (orderNew1 == null)
                        {
                            continue;
                        }
                        orderNews1.Add(orderNew1);
                    }
                    foreach (manage_page_edit.OrderNew orderNew2 in orderNews1)
                    {
                        orderNews.Remove(orderNew2);
                        orderNews.Insert(num1, orderNew2);
                    }
                    this.AvailableOrders = orderNews;
                    this.RadGrid_featuredProducts.Rebind();
                    int pageSize = num1 - this.RadGrid_featuredProducts.PageSize * this.RadGrid_featuredProducts.CurrentPageIndex;
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
            }
        }

        protected void grdSelectedOptions_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid_seletedProducts.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_seletedProducts.ClientID)
            {
                IList<manage_page_edit.OrderNew> selectedOrders = this.SelectedOrders;
                manage_page_edit.OrderNew order = manage_page_edit.GetOrder(selectedOrders, (long)e.DestDataItem.GetDataKeyValue("PriceCatalogueID"));
                int num = selectedOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<manage_page_edit.OrderNew> orderNews = new List<manage_page_edit.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    manage_page_edit.OrderNew orderNew = manage_page_edit.GetOrder(selectedOrders, (long)draggedItem.GetDataKeyValue("PriceCatalogueID"));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (manage_page_edit.OrderNew orderNew1 in orderNews)
                {
                    selectedOrders.Remove(orderNew1);
                    selectedOrders.Insert(num, orderNew1);
                }
                this.SelectedOrders = selectedOrders;
                this.RadGrid_seletedProducts.Rebind();
                int pageSize = num - this.RadGrid_seletedProducts.PageSize * this.RadGrid_seletedProducts.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "javascript:loadingimg('div_Button1','div_Button1process');");
            this.btn_cancel.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel','div_btn_cancelprocess');");
            this.chk_footer.Text = this.objLanguage.GetLanguageConversion("Footer");
            this.chk_topNavi.Text = this.objLanguage.GetLanguageConversion("Top_Navigation");
            this.btnReMove.ToolTip = this.objLanguage.GetLanguageConversion("Remove");
            this.btnMove.ToolTip = this.objLanguage.GetLanguageConversion("Move");
            this.lgdfeatured.InnerText = this.objLanguage.GetLanguageConversion("Featured_Products");
            this.btn_Next.Text = this.objLanguage.GetLanguageConversion("Next");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_SaveHP.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_previous.Text = this.objLanguage.GetLanguageConversion("Previous");
            this.btn_saveStay.Text = this.objLanguage.GetLanguageConversion("Save_Stay");
            this.btn_save.Text = this.objLanguage.GetLanguageConversion("Save");
            manage_page_edit.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            object[] companyID = new object[] { this.strSitepath, "document/", manage_page_edit.CompanyID, "/UploadImages/" };
            this.imagePath = string.Concat(companyID);
            UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/StoreSettings/account_list.ascx");
            this.plhAccountList.Controls.Add(userControl);
            if (this.Session["imageName"] != null)
            {
                object[] objArray = new object[] { this.strSitepath, "document/", manage_page_edit.CompanyID, "/UploadImages/" };
                this.imagePath = string.Concat(objArray);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str == "")
            {
                DropDownList dropDownList = (DropDownList)userControl.FindControl("ddl_accountsList");
                dropDownList.DataSource = this.objAcc.accountsList(manage_page_edit.CompanyID);
                dropDownList.DataTextField = "accountName";
                dropDownList.DataValueField = "Categorylist";
                dropDownList.DataBind();
                base.SetDDLValue(dropDownList, str.ToString());
                char[] chrArray = new char[] { '~' };
                manage_page_edit.AccountID = Convert.ToInt32(str.Split(chrArray)[0]);
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Select");
            }
            else
            {
                string[] strArrays = str.Split(new char[] { '~' });
                manage_page_edit.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (base.Request.Params["mode"] == null)
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a> > <a href=../StoreSettings/manage_page.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Manage_Page"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add")));
                base.Title = this.objLanguage.convert(global.pageTitle("Manage Page Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                this.Label1.Text = this.objLanguage.GetLanguageConversion("Manage_Page_Add");
                this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Page_Add");
                this.header.dtAccountList = this.objAcc.accountsList(manage_page_edit.CompanyID);
            }
            else
            {
                if (base.Request.Params["mode"] != "edit")
                {
                    string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a> > <a href=../StoreSettings/manage_page.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Manage_Page"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Add")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Manage Page Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.Label1.Text = this.objLanguage.GetLanguageConversion("Manage_Page_Add");
                    this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Page_Add");
                    this.header.dtAccountList = this.objAcc.accountsList(manage_page_edit.CompanyID);
                }
                else
                {
                    this.pageID = Convert.ToInt32(base.Request.Params["pageID"].ToString());
                    string[] strArrays1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a> > <a href=../StoreSettings/manage_page.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Manage_Page"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Edit")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Manage Page Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    this.Label1.Text = this.objLanguage.GetLanguageConversion("Manage_Page_Edit");
                    this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Page_Edit");
                    this.header.dtAccountList = this.objAcc.accountsList(manage_page_edit.CompanyID);
                }
                if (base.Request.Params["page"] != null)
                {
                    this.stay = base.Request.Params["page"];
                }
            }
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
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            string[] strArrays2 = new string[1];
            string[] secureVirtualPath = new string[] { this.SecureVirtualPath, ConnectionClass.ServerName, "/", this.Session["CompanyID"].ToString(), "/" };
            strArrays2[0] = string.Concat(secureVirtualPath);
            string[] strArrays3 = strArrays2;
            this.RadEditor1.ImageManager.UploadPaths = strArrays3;
            this.RadEditor1.ImageManager.ViewPaths = strArrays3;
            this.RadEditor1.FlashManager.ViewPaths = strArrays3;
            this.RadEditor1.FlashManager.UploadPaths = strArrays3;
            this.RadEditor1.DocumentManager.ViewPaths = strArrays3;
            this.RadEditor1.DocumentManager.UploadPaths = strArrays3;
            this.RadEditor1.Height = Unit.Pixel(400);
            this.RadEditor1.Width = Unit.Pixel(800);
            if (ConnectionClass.RadEditorUploadSize != null)
            {
                this.RadEditor1.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
                this.RadEditor1.DocumentManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
                this.RadEditor1.FlashManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
                this.RadEditor_customize.ImageManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
                this.RadEditor_customize.FlashManager.MaxUploadFileSize = Convert.ToInt32(ConnectionClass.RadEditorUploadSize);
            }
            this.RadEditor_customize.ImageManager.UploadPaths = strArrays3;
            this.RadEditor_customize.ImageManager.ViewPaths = strArrays3;
            this.RadEditor_customize.FlashManager.ViewPaths = strArrays3;
            this.RadEditor_customize.FlashManager.UploadPaths = strArrays3;
            this.RadEditor_customize.DocumentManager.ViewPaths = strArrays3;
            this.RadEditor_customize.DocumentManager.UploadPaths = strArrays3;
            this.RadEditor_customize.Height = Unit.Pixel(400);
            this.RadEditor_customize.Width = Unit.Pixel(800);
            if (!base.IsPostBack)
            {
                this.Session["selected_orders"] = null;
                this.Session["available_orders"] = null;
                if (manage_page_edit.AccountID == 0 || manage_page_edit.CompanyID == 0)
                {
                    this.pnl_alert.Visible = true;
                }
                else
                {
                    this.pnl_alert.Visible = false;
                    DataTable dataTable = WebstoreBasePage.pagesDetails(this.pageID, manage_page_edit.CompanyID, manage_page_edit.AccountID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["systemName"].ToString().ToLower().Trim() == "home")
                        {
                            this.div_homeCustomize.Style.Add("display", "block");
                            this.div_imgtitle.Style.Add("display", "block");
                            this.lbl_UploadImages.Visible = true;
                        }
                        if (row["systemName"].ToString().ToLower().Trim() == "home" || row["systemName"].ToString().ToLower().Trim() == "products" || row["systemName"].ToString().ToLower().Trim() == "sitemap" || row["systemName"].ToString().ToLower().Trim() == "saved drafts" || row["systemName"].ToString().ToLower().Trim() == "orders" || row["systemName"].ToString().ToLower().Trim() == "dash board" || row["systemName"].ToString().ToLower().Trim() == "campaign" || row["systemName"].ToString().ToLower().Trim() == "reports")
                        {
                            this.li_Properties.Style.Add("display", "block");
                            this.txt_title.Text = base.SpecialDecode(row["pageName"].ToString());
                            manage_page_edit.sortOrderID = Convert.ToInt32(row["sortOrderID"].ToString());
                            this.div_body.Style.Add("display", "none");
                            this.btn_Next.Style.Add("display", "none");
                            this.btn_SaveHP.Style.Add("display", "block");
                        }
                        else
                        {
                            this.li_Properties.Style.Add("display", "block");
                            this.div_body.Style.Add("display", "block");
                            this.btn_Next.Style.Add("display", "block");
                        }
                        this.txt_title.Text = base.SpecialDecode(row["pageName"].ToString());
                        this.RadEditor1.Content = row["pageBody"].ToString();
                        this.txt_title_property.Text = row["metaTitle"].ToString();
                        this.txt_description.Text = row["metaDescription"].ToString();
                        this.txt_key.Text = row["metaKeywords"].ToString();
                        this.ShowPage = Convert.ToChar(row["ShowPagesIn"].ToString());
                        manage_page_edit.sortOrderID = Convert.ToInt32(row["sortOrderID"].ToString());
                        if (this.ShowPage == 'H')
                        {
                            this.chk_topNavi.Checked = true;
                            this.chk_footer.Checked = false;
                        }
                        else if (this.ShowPage == 'F')
                        {
                            this.chk_footer.Checked = true;
                            this.chk_topNavi.Checked = false;
                        }
                        else if (this.ShowPage == 'B')
                        {
                            this.chk_topNavi.Checked = true;
                            this.chk_footer.Checked = true;
                        }
                        else if (this.ShowPage != 'N')
                        {
                            this.chk_topNavi.Checked = false;
                            this.chk_footer.Checked = false;
                        }
                        else
                        {
                            this.chk_topNavi.Checked = false;
                            this.chk_footer.Checked = false;
                        }
                    }
                }
                DataTable dataTable1 = WebstoreBasePage.homePageSelect(Convert.ToInt64(this.pageID), 0, 0);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.RadEditor_customize.Content = dataRow["CustomText"].ToString();
                    if (dataRow["IsSliddingBanners"].ToString().ToLower() != "true")
                    {
                        this.chk_slidingBanner.Checked = false;
                    }
                    else
                    {
                        this.chk_slidingBanner.Checked = true;
                    }
                    this.txt_centerPaneltext.Text = dataRow["CenterPanelText"].ToString();
                    this.CenterPanelOption = dataRow["CenterPanelOption"].ToString();
                    if (this.CenterPanelOption.ToLower() == "featured")
                    {
                        this.rdn_Feature.Checked = true;
                        this.div_featuredProductsMain.Style.Add("display", "block");
                    }
                    else if (this.CenterPanelOption.ToLower() == "new")
                    {
                        this.rdn_new.Checked = true;
                    }
                    else if (this.CenterPanelOption.ToLower() == "html")
                    {
                        this.div_FCK.Style.Add("display", "block");
                        this.rdn_customize.Checked = true;
                    }
                    else if (this.CenterPanelOption.ToLower() == "custom")
                    {
                        this.div_CustomizePannel.Style.Add("display", "block");
                        this.rdbCustomizeNew.Checked = true;
                    }
                    this.Bind_selectedProducts(Convert.ToInt64(manage_page_edit.CompanyID), Convert.ToInt64(manage_page_edit.AccountID));
                    this.Bind_featuredProducts(Convert.ToInt64(manage_page_edit.CompanyID), Convert.ToInt64(manage_page_edit.AccountID));
                    IList<manage_page_edit.OrderNew> availableOrders = this.AvailableOrders;
                    this.dt_seletedProduct = WebstoreBasePage.FeaturedProducts_Select((long)manage_page_edit.CompanyID, (long)manage_page_edit.AccountID);
                    foreach (DataRow row1 in this.dt_seletedProduct.Rows)
                    {
                        manage_page_edit.OrderNew order = manage_page_edit.GetOrder(availableOrders, Convert.ToInt64(row1["PriceCatalogueID"].ToString()));
                        if (order != null)
                        {
                            this.AvailableOrders.Remove(order);
                        }
                        this.AvailableOrders = availableOrders;
                        this.RadGrid_featuredProducts.DataSource = this.AvailableOrders;
                        this.RadGrid_featuredProducts.Rebind();
                    }
                }
            }
            if (base.Request.QueryString["pageid"] != null)
            {
                manage_page_edit.PageID = Convert.ToInt32(base.Request.QueryString["pageid"].ToString().Trim());
            }
            this.txt_title.Focus();
            this.TypeIDs = this.GetAllContentByAccountId((long)manage_page_edit.AccountID);
            this.hdnTypeIDs.Value = this.TypeIDs;
            if (!this.Page.IsPostBack)
            {
                manage_page_edit.BindTrreView(this.rtvProduct);
            }
            this.rdlWithRightBanner.Items[0].Text = this.objLanguage.GetLanguageConversion("With_Right_Banner");
            this.rdlWithRightBanner.Items[1].Text = this.objLanguage.GetLanguageConversion("Without_Right_Banner");
        }

        protected void RadGrid_featuredProducts_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid_featuredProducts.DataSource = this.AvailableOrders;
        }

        protected void RadGrid_seletedProducts_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid_seletedProducts.DataSource = this.SelectedOrders;
        }

        protected void rlvBanner_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                RadListViewDataItem item = (RadListViewDataItem)e.Item;
                Image str = (Image)e.Item.FindControl("imgBanner");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("imageName");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnURL");
                if (hiddenField.Value.ToString().Trim() != "")
                {
                    object[] accountID = new object[] { this.strSitepath, "document/store/", manage_page_edit.AccountID, "/banners/", hiddenField.Value };
                    str.ImageUrl = string.Concat(accountID);
                }
                else if (hiddenField1.Value.ToString().Trim() != "")
                {
                    str.ImageUrl = hiddenField1.Value.ToString();
                }
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnBannerID");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("chkBannerID");
                if (this.hdnTypeIDs.Value.Contains(hiddenField2.Value))
                {
                    checkBox.Checked = true;
                }
            }
        }

        protected void rlvBanner_NeedDataSource(object source, RadListViewNeedDataSourceEventArgs e)
        {
            DataTable dataTable = WebstoreBasePage.BindBanner(manage_page_edit.AccountID, 0, "R", "HOME");
            this.rlvBanner.DataSource = dataTable;
        }

        protected void rtvProduct_NodeDataBound(object sender, RadTreeNodeEventArgs e)
        {
            RadTreeNode node = e.Node;
            CheckBox checkBox = (CheckBox)e.Node.FindControl("chkProductID");
            HiddenField hiddenField = (HiddenField)e.Node.FindControl("hdnProductID");
            if (this.hdnTypeIDs.Value.Contains(hiddenField.Value))
            {
                checkBox.Checked = true;
            }
        }

        public void save(string type)
        {
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"] == "add")
                {
                    if (this.chk_topNavi.Checked)
                    {
                        this.ShowPage = 'H';
                    }
                    if (this.chk_footer.Checked)
                    {
                        this.ShowPage = 'F';
                    }
                    if (this.chk_footer.Checked && this.chk_topNavi.Checked)
                    {
                        this.ShowPage = 'B';
                    }
                    if (manage_page_edit.AccountID == 0 || manage_page_edit.CompanyID == 0)
                    {
                        this.pnl_alert.Visible = true;
                    }
                    else
                    {
                        this.pageID = WebstoreBasePage.pagesInsert(0, manage_page_edit.CompanyID, manage_page_edit.AccountID, base.SpecialEncode(this.txt_title.Text), base.SpecialEncode(this.txt_title.Text), DateTime.Now, 0, this.RadEditor1.Content, this.txt_title_property.Text, this.txt_description.Text, this.txt_key.Text, this.ShowPage, DateTime.Now);
                        if (type != "save")
                        {
                            base.Response.Redirect("manage_page.aspx?suc=in");
                        }
                        else
                        {
                            base.Response.Redirect(string.Concat("manage_page_edit.aspx?mode=edit&pageID=", this.pageID, "&page=p&suc=in"));
                        }
                    }
                }
                if (base.Request.Params["mode"] == "edit")
                {
                    if (this.chk_topNavi.Checked)
                    {
                        this.ShowPage = 'H';
                    }
                    if (this.chk_footer.Checked)
                    {
                        this.ShowPage = 'F';
                    }
                    if (this.chk_footer.Checked && this.chk_topNavi.Checked)
                    {
                        this.ShowPage = 'B';
                    }
                    if (manage_page_edit.AccountID != 0 && manage_page_edit.CompanyID != 0 && this.pageID != 0)
                    {
                        WebstoreBasePage.pagesInsert(this.pageID, manage_page_edit.CompanyID, manage_page_edit.AccountID, "", base.SpecialEncode(this.txt_title.Text), DateTime.Now, manage_page_edit.sortOrderID, this.RadEditor1.Content, base.SpecialEncode(this.txt_title_property.Text), this.txt_description.Text, this.txt_key.Text, this.ShowPage, DateTime.Now);
                        if (type != "save")
                        {
                            base.Response.Redirect("manage_page.aspx?suc=up");
                            return;
                        }
                        base.Response.Redirect(string.Concat("manage_page_edit.aspx?mode=edit&pageID=", this.pageID, "&page=p&suc=up"));
                        return;
                    }
                    this.pnl_alert.Visible = true;
                }
            }
        }

        protected class OrderNew
        {
            private long _FeaturedProductsID;

            private long _PriceCatalogueID;

            private string _CatalogueName;

            private string _PriceCatalogueCategoryName;

            public string CatalogueName
            {
                get
                {
                    return this._CatalogueName;
                }
            }

            public long FeaturedProductsID
            {
                get
                {
                    return this._FeaturedProductsID;
                }
            }

            public string PriceCatalogueCategoryName
            {
                get
                {
                    return this._PriceCatalogueCategoryName;
                }
            }

            public long PriceCatalogueID
            {
                get
                {
                    return this._PriceCatalogueID;
                }
            }

            public OrderNew(long FeaturedProductsID, long PriceCatalogueID, string CatalogueName, string PriceCatalogueCategoryName)
            {
                this._FeaturedProductsID = FeaturedProductsID;
                this._PriceCatalogueID = PriceCatalogueID;
                this._CatalogueName = CatalogueName;
                this._PriceCatalogueCategoryName = PriceCatalogueCategoryName;
            }
        }
    }
}