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

namespace ePrint.StoreSettings
{
    public partial class eStoreStatus : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        private Global gloobj = new Global();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        public static Hashtable ht;

        public int OrdStatusID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<eStoreStatus.OrderNew> PendingOrders
        {
            get
            {
                IList<eStoreStatus.OrderNew> orderNews;
                try
                {
                    object item = this.Session["Status"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<eStoreStatus.OrderNew>();
                        }
                        else
                        {
                            this.Session["Status"] = item;
                        }
                    }
                    orderNews = (IList<eStoreStatus.OrderNew>)item;
                }
                catch
                {
                    this.Session["Status"] = null;
                    return new List<eStoreStatus.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["Status"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static eStoreStatus()
        {
            eStoreStatus.ht = new Hashtable();
        }

        public eStoreStatus()
        {
        }

        protected void btn_DeleteStatusOrders_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hidGridCount.Value))
            {
                string[] strArrays = this.hidGridCount.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i] != "")
                    {
                        SettingsBasePage.settings_estimatestatus_delete(this.CompanyID, Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Status_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridOrderBind();
            this.GridOrders.Rebind();
        }

        protected void btnUpDown_OnClick(object sender, EventArgs e)
        {
            foreach (long key in eStoreStatus.ht.Keys)
            {
                SettingsBasePage.settings_estimatestatus_order_number_update(this.CompanyID, Convert.ToInt32(key), Convert.ToInt32(eStoreStatus.ht[key]));
                SettingsBasePage.settings_estimatestatus_sortalpha_update(this.CompanyID, Convert.ToInt32(key), "False");
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Order_ReArranged_Successfully"), "msg-success", this.plhMessage);
        }

        private static eStoreStatus.OrderNew GetOrder(IEnumerable<eStoreStatus.OrderNew> ordersToSearchIn, long StatusID)
        {
            eStoreStatus.OrderNew orderNew;
            using (IEnumerator<eStoreStatus.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    eStoreStatus.OrderNew current = enumerator.Current;
                    if (current.StatusID != StatusID)
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

        protected IList<eStoreStatus.OrderNew> GetOrders()
        {
            IList<eStoreStatus.OrderNew> orderNews = new List<eStoreStatus.OrderNew>();
            DataTable dataTable = this.GridStatusBindTable();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["StatusID"].ToString());
                        string str = base.SpecialDecode(row["StatusTitle"].ToString());
                        string str1 = base.SpecialDecode(row["UserFriendlyName"].ToString());
                        string str2 = row["OrdersDefault"].ToString();
                        string empty = string.Empty;
                        orderNews.Add(new eStoreStatus.OrderNew(num, str, str1, str2, empty));
                    }
                    this.Session["Status"] = dataTable;
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
            this.GridOrders.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            eStoreStatus.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridOrders.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridOrders.ClientID)
            {
                IList<eStoreStatus.OrderNew> pendingOrders = this.PendingOrders;
                eStoreStatus.OrderNew order = eStoreStatus.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("StatusID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<eStoreStatus.OrderNew> orderNews = new List<eStoreStatus.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    eStoreStatus.OrderNew orderNew = eStoreStatus.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("StatusID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (eStoreStatus.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    eStoreStatus.ht.Add(pendingOrders[i].StatusID, i + 1);
                }
                this.GridOrders.DataSource = this.PendingOrders;
                this.GridOrders.Rebind();
                int pageSize = num - this.GridOrders.PageSize * this.GridOrders.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        public void GridBind(int CompanyID)
        {
            DataTable dataTable = SettingsBasePage.settings_eStore_Orders(CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = base.SpecialDecode(row["StatusTitle"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
            }
            this.GridOrders.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.GridOrders.DataBind();
            }
        }

        protected void GridOrderBind()
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_eStore_Orders(this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = base.SpecialDecode(row["StatusTitle"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
            }
            this.GridOrders.DataSource = dataTable;
            this.GridOrders.DataBind();
        }

        protected void GridOrders_InsertCommand(object source, GridCommandEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            GridItem item = e.Item;
            RadTextBox empty = (RadTextBox)e.Item.FindControl("txtOdrStsTtl");
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtUsrFrndlyName");
            if (!((CheckBox)e.Item.FindControl("Chk_OrdersDefault")).Checked)
            {
                num = 0;
                num1 = 0;
            }
            else
            {
                num = 1;
                num1 = 1;
            }
            int num2 = SettingsBasePage.settings_estimatestatus_insert_new(this.CompanyID, base.SpecialEncode(empty.Text), 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, num, num1, base.SpecialEncode(radTextBox.Text), 0,"");
            if (num2 != -1)
            {
                empty.Text = string.Empty;
            }
            this.GridBind(this.CompanyID);
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Status_Saved_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Status_already_exists"), "msg-fail", this.plhMessage);
        }

        protected void GridOrders_OnItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridOrders.MasterTableView.IsItemInserted = false;
            }
            if (e.CommandName == "InitInsert")
            {
                this.GridOrders.MasterTableView.ClearEditItems();
            }
        }

        protected void GridOrders_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("checkAll");
                HtmlInputCheckBox htmlInputCheckBox1 = (HtmlInputCheckBox)e.Item.FindControl("Id");
                Label label = (Label)e.Item.FindControl("lblStatusID");
                Image image = (Image)e.Item.FindControl("img_default_value");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkStatus");
                if (SettingsBasePage.settings_estimatestatus_delete_check_all_module(this.CompanyID, Convert.ToInt32(label.Text), linkButton.Text.ToString()) != -1)
                {
                    image.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    htmlInputCheckBox1.Disabled = true;
                    image.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
                if (linkButton.Text.ToString().ToLower() == "locked")
                {
                    htmlInputCheckBox1.Disabled = true;
                }
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Orders");
                Image image1 = (Image)e.Item.FindControl("img_orders");
                if (hiddenField.Value != "True")
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "1t.gif");
                }
                else
                {
                    image1.ImageUrl = string.Concat(global.imagePath(), "check.gif");
                }
                RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtOdrStsTtl");
                RadTextBox radTextBox1 = (RadTextBox)e.Item.FindControl("txtUsrFrndlyName");
                radTextBox.Text = base.SpecialDecode(radTextBox.Text);
                radTextBox1.Text = base.SpecialDecode(radTextBox1.Text);
            }
            catch (Exception exception)
            {
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridOrders.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridOrders.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void GridOrders_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            GridItem item = e.Item;
            RadTextBox empty = (RadTextBox)e.Item.FindControl("txtOdrStsTtl");
            RadTextBox radTextBox = (RadTextBox)e.Item.FindControl("txtUsrFrndlyName");
            CheckBox checkBox = (CheckBox)e.Item.FindControl("Chk_OrdersDefault");
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_statusid");
            this.OrdStatusID = Convert.ToInt32(hiddenField.Value);
            if (!checkBox.Checked)
            {
                num = 0;
                num1 = 0;
            }
            else
            {
                num = 1;
                num1 = 1;
            }
            int num2 = SettingsBasePage.settings_estimatestatus_update_new(this.CompanyID, this.OrdStatusID, base.SpecialEncode(empty.Text), 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, num, num1, base.SpecialEncode(radTextBox.Text), 0,"");
            if (num2 != -1)
            {
                empty.Text = string.Empty;
            }
            this.GridBind(this.CompanyID);
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Status_Saved_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Order_Status_already_exists"), "msg-fail", this.plhMessage);
        }

        protected void GridOrdersBindTableAlpha(object source, GridSortCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_eStore_Orders(this.CompanyID);
            this.GridOrders.DataSource = dataTable;
            this.GridOrders.DataBind();
        }

        protected DataTable GridStatusBindTable()
        {
            return SettingsBasePage.settings_eStore_Orders(this.CompanyID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSavOrdr.Attributes.Add("onclick", "javascript:loadingimg('div_btnSavOrdr','div_btnSavOrdrprocess');");
            this.btnDel.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.btnSavOrdr.Text = this.objLanguage.GetLanguageConversion("Save_Order");
            this.GridOrders.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Order_Status"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_Status")));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Order_Status");
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() != "" && base.Request.Params["mode"].ToString().ToLower() == "update" && base.Request.Params["editid"].ToString() != "")
            {
                this.OrdStatusID = Convert.ToInt32(base.Request.Params["editid"].ToString());
            }
            DataTable dataTable = SettingsBasePage.settings_eStore_Orders(this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["StatusTitle"] = base.SpecialDecode(row["StatusTitle"].ToString());
                row["UserFriendlyName"] = base.SpecialDecode(row["UserFriendlyName"].ToString());
            }
            this.GridOrders.DataSource = dataTable;
            if (!base.IsPostBack)
            {
                this.Session["Status"] = null;
                if (base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() != "" && base.Request.Params["mode"].ToString().ToLower() == "update")
                {
                }
            }
        }

        protected class OrderNew
        {
            private long _StatusID;

            private string _StatusTitle;

            private string _UserFriendlyName;

            private string _OrdersDefault;

            private string _InUse;

            public string InUse
            {
                get
                {
                    return this._InUse;
                }
            }

            public string OrdersDefault
            {
                get
                {
                    return this._OrdersDefault;
                }
            }

            public long StatusID
            {
                get
                {
                    return this._StatusID;
                }
            }

            public string StatusTitle
            {
                get
                {
                    return this._StatusTitle;
                }
            }

            public string UserFriendlyName
            {
                get
                {
                    return this._UserFriendlyName;
                }
            }

            public OrderNew(long StatusID, string StatusTitle, string UserFriendlyName, string OrdersDefault, string InUse)
            {
                this._StatusID = StatusID;
                this._StatusTitle = StatusTitle;
                this._UserFriendlyName = UserFriendlyName;
                this._OrdersDefault = OrdersDefault;
                this._InUse = InUse;
            }
        }
    }
}