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
    public partial class productcategory_reorder : BaseClass, IRequiresSessionState
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

        protected IList<productcategory_reorder.OrderNew> PendingOrders
        {
            get
            {
                IList<productcategory_reorder.OrderNew> orderNews;
                try
                {
                    object item = this.Session["Category"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<productcategory_reorder.OrderNew>();
                        }
                        else
                        {
                            this.Session["Category"] = item;
                        }
                    }
                    orderNews = (IList<productcategory_reorder.OrderNew>)item;
                }
                catch
                {
                    this.Session["Category"] = null;
                    return new List<productcategory_reorder.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["Category"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static productcategory_reorder()
        {
            productcategory_reorder.ht = new Hashtable();
        }

        public productcategory_reorder()
        {
        }

        protected void BindRadioButtons()
        {
            DataTable dataTable = WebstoreBasePage.Select_Custom_OR_Alphbetic_Order((long)this.CompanyID, (long)this.AccountID, "ProductCategory");
            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToBoolean(row["Is_AlphabeticalOrder_ProdCategory"]))
                {
                    this.rdbAutoAlphabetic.Checked = true;
                    this.GridView1.Attributes.Add("style", "display:none");
                    this.ddlCategorySelect.Attributes.Add("style", "display:none");
                }
                if (!Convert.ToBoolean(row["Is_CustomOrder_ProdCategory"]))
                {
                    continue;
                }
                this.rdbCustom.Checked = true;
                this.GridView1.Attributes.Add("style", "display:block");
                this.ddlCategorySelect.Attributes.Add("style", "display:block");
            }
        }

        protected void btnSaveOrder_Onclick(object sender, EventArgs e)
        {
            foreach (long key in productcategory_reorder.ht.Keys)
            {
                AccountsBaseClass.ProductCategoryReorder_Insert_Update(this.SortOrderID, this.AccountID, this.ClientID, Convert.ToInt32(key), Convert.ToInt32(productcategory_reorder.ht[key]), this.CompanyID);
            }
            WebstoreBasePage.InsertUpdate_Custom_Alphbetic_Order(this.rdbAutoAlphabetic.Checked, this.rdbCustom.Checked, (long)this.CompanyID, (long)this.AccountID, "ProductCategory");
            this.BindRadioButtons();
            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Product_Category_Reorder_Successfully"), "msg-success", this.plhMessageNew);
            this.Session["Category"] = null;
        }

        protected void ddlCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridBinding(this.CompanyID);
        }

        private static productcategory_reorder.OrderNew GetOrder(IEnumerable<productcategory_reorder.OrderNew> ordersToSearchIn, long PriceCatalogueCategoryID)
        {
            productcategory_reorder.OrderNew orderNew;
            using (IEnumerator<productcategory_reorder.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    productcategory_reorder.OrderNew current = enumerator.Current;
                    if (current.PriceCatalogueCategoryID != PriceCatalogueCategoryID)
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

        protected IList<productcategory_reorder.OrderNew> GetOrders()
        {
            IList<productcategory_reorder.OrderNew> orderNews = new List<productcategory_reorder.OrderNew>();
            DataTable dataTable = this.GridCategoryBindTable();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    int num = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num1 = Convert.ToInt64(row["PriceCatalogueCategoryID"].ToString());
                        string str = base.SpecialDecode(row["Description"].ToString().Trim());
                        int num2 = num;
                        string str1 = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString().Trim());
                        orderNews.Add(new productcategory_reorder.OrderNew(num1, str, num2, str1));
                        num++;
                    }
                    this.Session["Category"] = dataTable;
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
            this.GridView1.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            productcategory_reorder.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridView1.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridView1.ClientID)
            {
                IList<productcategory_reorder.OrderNew> pendingOrders = this.PendingOrders;
                productcategory_reorder.OrderNew order = productcategory_reorder.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("PriceCatalogueCategoryID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<productcategory_reorder.OrderNew> orderNews = new List<productcategory_reorder.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    productcategory_reorder.OrderNew orderNew = productcategory_reorder.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("PriceCatalogueCategoryID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (productcategory_reorder.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    if (!productcategory_reorder.ht.ContainsKey(pendingOrders[i].PriceCatalogueCategoryID))
                    {
                        productcategory_reorder.ht.Add(pendingOrders[i].PriceCatalogueCategoryID, i + 1);
                    }
                }
                this.GridView1.DataSource = this.PendingOrders;
                this.GridView1.DataBind();
                int pageSize = num - this.GridView1.PageSize * this.GridView1.CurrentPageIndex;
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
            DataTable dataTable = new DataTable();
            dataTable = (Convert.ToString(this.ddlCategorySelect.SelectedValue) != "all" ? this.objAcc.productsCategoryList_Select_CategoryID(CompanyID, this.AccountID, Convert.ToInt32(this.ddlCategorySelect.SelectedValue), false) : this.objAcc.productsCategoryList_Select_CategoryID(CompanyID, this.AccountID, 0, true));
            foreach (DataRow row in dataTable.Rows)
            {
                row["PriceCatalogueCategoryName"] = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
                row["DEscription"] = base.SpecialDecode(row["Description"].ToString());
            }
            this.GridView1.DataSource = dataTable;
            this.GridView1.DataBind();
        }

        protected DataTable GridCategoryBindTable()
        {
            if (Convert.ToString(this.ddlCategorySelect.SelectedValue) == "all")
            {
                return this.objAcc.productsCategoryList_Select_CategoryID(this.CompanyID, this.AccountID, 0, true);
            }
            return this.objAcc.productsCategoryList_Select_CategoryID(this.CompanyID, this.AccountID, Convert.ToInt32(this.ddlCategorySelect.SelectedValue), false);
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
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Product_Category_Reorder")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Product Category Reorder", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Product_Category_Reorder");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable = WebstoreBasePage.Select_ProductCategory_based_on_accountid((long)this.CompanyID, "ProductCategory", this.AccountID);
                foreach (DataRow row in dataTable.Rows)
                {
                    row["MultiLevelCategory"] = base.SpecialDecode(row["MultiLevelCategory"].ToString());
                }
                this.ddlCategorySelect.DataSource = dataTable;
                this.ddlCategorySelect.DataTextField = "MultiLevelCategory";
                this.ddlCategorySelect.DataValueField = "CategoryID";
                this.ddlCategorySelect.DataBind();
                this.ddlCategorySelect.Items.Insert(0, new ListItem("All", "all"));
                this.ddlCategorySelect.Items.Insert(1, new ListItem("/", "0"));
            }
            if (!base.IsPostBack)
            {
                this.gridBinding(this.CompanyID);
                this.Session["Category"] = null;
                this.BindRadioButtons();
            }
        }

        protected class OrderNew
        {
            private long _PriceCatalogueCategoryID;

            private string _Description;

            private int _ReorderNo;

            private string _PriceCatalogueCategoryName;

            public string Description
            {
                get
                {
                    return this._Description;
                }
            }

            public long PriceCatalogueCategoryID
            {
                get
                {
                    return this._PriceCatalogueCategoryID;
                }
            }

            public string PriceCatalogueCategoryName
            {
                get
                {
                    return this._PriceCatalogueCategoryName;
                }
            }

            public int ReorderNo
            {
                get
                {
                    return this._ReorderNo;
                }
            }

            public OrderNew(long PriceCatalogueCategoryID, string Description, int ReorderNo, string PriceCatalogueCategoryName)
            {
                this._PriceCatalogueCategoryID = PriceCatalogueCategoryID;
                this._Description = Description;
                this._ReorderNo = ReorderNo;
                this._PriceCatalogueCategoryName = PriceCatalogueCategoryName;
            }
        }
    }
}