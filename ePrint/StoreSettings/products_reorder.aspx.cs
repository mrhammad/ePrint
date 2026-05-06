using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class products_reorder : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int ClientID;

        private Global gloobj = new Global();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        public static Hashtable ht;

        public int SortOrderID;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<products_reorder.OrderNew> PendingOrders
        {
            get
            {
                IList<products_reorder.OrderNew> orderNews;
                try
                {
                    object item = this.Session["ProductsList"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<products_reorder.OrderNew>();
                        }
                        else
                        {
                            this.Session["ProductsList"] = item;
                        }
                    }
                    orderNews = (IList<products_reorder.OrderNew>)item;
                }
                catch
                {
                    this.Session["ProductsList"] = null;
                    return new List<products_reorder.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["ProductsList"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static products_reorder()
        {
            products_reorder.ht = new Hashtable();
        }

        public products_reorder()
        {
        }

        protected void BindRadioButtons()
        {
            DataTable dataTable = WebstoreBasePage.Select_Custom_OR_Alphbetic_Order((long)this.CompanyID, (long)this.AccountID, "Products");
            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToBoolean(row["Is_AlphabeticalOrder_Product"]))
                {
                    this.rdbAutoAlphabetic.Checked = true;
                    this.GrdProductsList.Attributes.Add("style", "display:none");
                    this.ddlCategorySelect.Attributes.Add("style", "display:none");
                }
                if (!Convert.ToBoolean(row["Is_CustomOrder_Product"]))
                {
                    continue;
                }
                this.rdbCustom.Checked = true;
                this.GrdProductsList.Attributes.Add("style", "display:block");
                this.ddlCategorySelect.Attributes.Add("style", "display:block");
            }
        }

        protected void btnSaveOrder_Onclick(object sender, EventArgs e)
        {
            if (this.GrdProductsList.Items.Count > 0)
            {
                foreach (long key in products_reorder.ht.Keys)
                {
                    WebstoreBasePage.ProductsReorder_Delete((long)this.CompanyID, (long)this.AccountID, Convert.ToInt32(key), Convert.ToInt32(this.ddlCategorySelect.SelectedValue));
                    WebstoreBasePage.ProductsReorder_Insert_Update(this.CompanyID, this.AccountID, Convert.ToInt32(key), Convert.ToInt32(products_reorder.ht[key]), this.ClientID, Convert.ToInt32(this.ddlCategorySelect.SelectedValue));
                }
                WebstoreBasePage.InsertUpdate_Custom_Alphbetic_Order(this.rdbAutoAlphabetic.Checked, this.rdbCustom.Checked, (long)this.CompanyID, (long)this.AccountID, "Products");
                this.BindRadioButtons();
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Products_Reordered_Successfully"), "msg-success", this.plhMessageNew);
                this.Session["ProductsList"] = null;
            }
        }

        protected void ddlCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridBinding(this.CompanyID);
        }

        private static products_reorder.OrderNew GetOrder(IEnumerable<products_reorder.OrderNew> ordersToSearchIn, long PriceCatalogueID)
        {
            products_reorder.OrderNew orderNew;
            using (IEnumerator<products_reorder.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    products_reorder.OrderNew current = enumerator.Current;
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

        protected IList<products_reorder.OrderNew> GetOrders()
        {
            IList<products_reorder.OrderNew> orderNews = new List<products_reorder.OrderNew>();
            DataTable dataTable = WebstoreBasePage.products_Select_Select_Basedon_CatID((long)this.CompanyID, (long)this.AccountID, (long)Convert.ToInt32(this.ddlCategorySelect.SelectedValue));
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    int num = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num1 = Convert.ToInt64(row["PriceCatalogueID"].ToString());
                        string str = base.SpecialDecode(row["Description"].ToString().Trim());
                        int num2 = num;
                        string str1 = base.SpecialDecode(row["CatalogueName"].ToString().Trim());
                        orderNews.Add(new products_reorder.OrderNew(num1, str, num2, str1));
                        num++;
                    }
                    this.Session["ProductsList"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        protected void grdPendingOrders_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            this.GrdProductsList.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            products_reorder.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GrdProductsList.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GrdProductsList.ClientID)
            {
                IList<products_reorder.OrderNew> pendingOrders = this.PendingOrders;
                products_reorder.OrderNew order = products_reorder.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("PriceCatalogueID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<products_reorder.OrderNew> orderNews = new List<products_reorder.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    products_reorder.OrderNew orderNew = products_reorder.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("PriceCatalogueID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (products_reorder.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    if (!products_reorder.ht.ContainsKey(pendingOrders[i].PriceCatalogueID))
                    {
                        products_reorder.ht.Add(pendingOrders[i].PriceCatalogueID, i + 1);
                    }
                }
                this.GrdProductsList.DataSource = this.PendingOrders;
                this.GrdProductsList.Rebind();
                int pageSize = num - this.GrdProductsList.PageSize * this.GrdProductsList.CurrentPageIndex;
                try
                {
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
                catch
                {
                }
            }
        }

        public void gridBinding(int CompanyID)
        {
            DataTable dataTable = WebstoreBasePage.products_Select_Select_Basedon_CatID((long)CompanyID, (long)this.AccountID, (long)Convert.ToInt32(this.ddlCategorySelect.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                row["CatalogueName"] = base.SpecialDecode(row["CatalogueName"].ToString());
                row["DEscription"] = base.SpecialDecode(row["Description"].ToString());
            }
            this.GrdProductsList.DataSource = dataTable;
            this.GrdProductsList.DataBind();
        }

        protected DataTable GridCategoryBindTable()
        {
            return this.objAcc.productsCategoryList_Select(this.CompanyID, this.AccountID);
        }

        public void OnClick_lnkaccountsList(object sender, EventArgs e)
        {
            this.gridBinding(this.CompanyID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_saveReorder.Text = this.objLanguage.GetLanguageConversion("Save");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>eStore Settings View</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Products_Reorder")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Products Reorder", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Products_Reorder");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (!base.IsPostBack)
            {
                DataTable dataTable = this.GridCategoryBindTable();
                this.ddlCategorySelect.DataSource = dataTable;
                this.ddlCategorySelect.DataTextField = "PriceCatalogueCategoryName";
                this.ddlCategorySelect.DataValueField = "PriceCatalogueCategoryID";
                this.ddlCategorySelect.DataBind();
                this.ddlCategorySelect.Items.Insert(0, new ListItem("All", "0"));
            }
            if (!base.IsPostBack)
            {
                products_reorder.ht.Clear();
                this.gridBinding(this.CompanyID);
                this.Session["ProductsList"] = null;
                this.BindRadioButtons();
            }
        }

        protected class OrderNew
        {
            private long _PriceCatalogueID;

            private string _Description;

            private int _ReorderNo;

            private string _CatalogueName;

            public string CatalogueName
            {
                get
                {
                    return this._CatalogueName;
                }
            }

            public string Description
            {
                get
                {
                    return this._Description;
                }
            }

            public long PriceCatalogueID
            {
                get
                {
                    return this._PriceCatalogueID;
                }
            }

            public int ReorderNo
            {
                get
                {
                    return this._ReorderNo;
                }
            }

            public OrderNew(long PriceCatalogueID, string Description, int ReorderNo, string CatalogueName)
            {
                this._PriceCatalogueID = PriceCatalogueID;
                this._Description = Description;
                this._ReorderNo = ReorderNo;
                this._CatalogueName = CatalogueName;
            }
        }
    }
}