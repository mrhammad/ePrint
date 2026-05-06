using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using Printcenter.UI.Accounts;
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
using ShipEngine.ApiClient.Api;
using ShipEngine.ApiClient.Model;
using System.Net;

namespace ePrint.settings
{
    public partial class DeliveryCost : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int UserID;

        public int AccountID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private Global gloobj = new Global();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        public static Hashtable ht;

        public int OrdStatusID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        static string ShipAPiKey = ConnectionClass.ShipAPiKey;

        public string strSitepath = global.sitePath();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }


        protected IList<DeliveryCost.OrderNew> PendingOrders
        {
            get
            {
                IList<DeliveryCost.OrderNew> orderNews;
                try
                {
                    object item = this.Session["Status"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List<DeliveryCost.OrderNew>();
                        }
                        else
                        {
                            this.Session["Status"] = item;
                        }
                    }
                    orderNews = (IList<DeliveryCost.OrderNew>)item;
                }
                catch
                {
                    this.Session["Status"] = null;
                    return new List<DeliveryCost.OrderNew>();
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

        static DeliveryCost()
        {
            DeliveryCost.ht = new Hashtable();
        }

        public DeliveryCost()
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
                        SettingsBasePage.settings_MIS_DeliveryCost_delete(this.CompanyID, Convert.ToInt32(strArrays[i]));
                    }
                }
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Status_Deleted_Successfully"), "msg-success", this.plhMessage);
            this.GridOrderBind();
            this.GridOrders.Rebind();
        }

        protected void btnUpDown_OnClick(object sender, EventArgs e)
        {
            foreach (long key in DeliveryCost.ht.Keys)
            {
                SettingsBasePage.settings_estimatestatus_order_number_update(this.CompanyID, Convert.ToInt32(key), Convert.ToInt32(DeliveryCost.ht[key]));
                SettingsBasePage.settings_estimatestatus_sortalpha_update(this.CompanyID, Convert.ToInt32(key), "False");
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Order_ReArranged_Successfully"), "msg-success", this.plhMessage);
        }

        protected void btnOtherStoreImport_OnClick(object sender, EventArgs e)
        {
            int num2 = -1;
            DataTable dataTable = SettingsBasePage.OtherStore_Delivery_Costs(this.CompanyID, this.AccountID);
            foreach (DataRow row in dataTable.Rows)
            {
                num2 = SettingsBasePage.settings_DeliveryCost_insert_new(this.CompanyID, row["DeliveryCostTitle"].ToString(), row["Type"].ToString(), row["Formula"].ToString(), false, true, this.AccountID);
            }
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_already_exists"), "msg-fail", this.plhMessage);

            this.GridOrderBind();
            this.GridOrders.Rebind();
        }

        protected void btnShipImport_OnClick(object sender, EventArgs e)
        {

            var apiKey = GetApiKey();
            ChooseCarrier(apiKey);
            base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
        }

        protected string GetApiKey()
        {
            var apiKey = ShipAPiKey;
            if (String.IsNullOrWhiteSpace(apiKey))
            {
                apiKey = "TEST_1PltA1iiloyrhM/82FF9k7WY4pLAtt/1ylzPp7vPX9U";
            }
            return apiKey;
        }

        protected void ChooseCarrier(string apiKey)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int num2 = -1;
            var carriersApi = new CarriersApi();
            var carriers = carriersApi.CarriersList(apiKey).Carriers;

            for (var i = 0; i < carriers.Count; i++)
            {
                var iCarrier = carriers[i];
                DataTable dataTable = SettingsBasePage.settings_Delivery_Costs(this.CompanyID, this.AccountID);
                bool idExists = DoesIdExist(dataTable, iCarrier.CarrierId);
                if (idExists)
                {
                    num2 = 0;
                }
                else
                {
                    num2 = SettingsBasePage.settings_MIS_DeliveryCost_insert_new(this.CompanyID, iCarrier.FriendlyName, "Ship Engine", iCarrier.CarrierId, true, false, this.AccountID);
                }
            }
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
                base.Response.Redirect(base.Request.Url.ToString());
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_already_exists"), "msg-fail", this.plhMessage);
            return;
        }

        static bool DoesIdExist(DataTable dataTable, string idToCheck)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["Formula"].ToString();
                if (id == idToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        private static DeliveryCost.OrderNew GetOrder(IEnumerable<DeliveryCost.OrderNew> ordersToSearchIn, long DeliveryCostID)
        {
            DeliveryCost.OrderNew orderNew;
            using (IEnumerator<DeliveryCost.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    DeliveryCost.OrderNew current = enumerator.Current;
                    if (current.DeliveryCostID != DeliveryCostID)
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

        protected IList<DeliveryCost.OrderNew> GetOrders()
        {
            IList<DeliveryCost.OrderNew> orderNews = new List<DeliveryCost.OrderNew>();
            DataTable dataTable = this.GridStatusBindTable();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["DeliveryCostID"].ToString());
                        string str = base.SpecialDecode(row["DeliveryCostTitle"].ToString());
                        string str1 = base.SpecialDecode(row["Type"].ToString());
                        string str2 = row["Formula"].ToString();
                        string empty = string.Empty;
                        orderNews.Add(new DeliveryCost.OrderNew(num, str, str1, str2, empty));
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
            DeliveryCost.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.GridOrders.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.GridOrders.ClientID)
            {
                IList<DeliveryCost.OrderNew> pendingOrders = this.PendingOrders;
                DeliveryCost.OrderNew order = DeliveryCost.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("DeliveryCostID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<DeliveryCost.OrderNew> orderNews = new List<DeliveryCost.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    DeliveryCost.OrderNew orderNew = DeliveryCost.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("DeliveryCostID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (DeliveryCost.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    DeliveryCost.ht.Add(pendingOrders[i].DeliveryCostID, i + 1);
                }
                this.GridOrders.DataSource = this.PendingOrders;
                this.GridOrders.Rebind();
                int pageSize = num - this.GridOrders.PageSize * this.GridOrders.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        public void GridBind(int CompanyID)
        {
            DataTable dataTable = SettingsBasePage.settings_MIS_Delivery_Costs(CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["DeliveryCostTitle"] = base.SpecialDecode(row["DeliveryCostTitle"].ToString());
                row["Type"] = base.SpecialDecode(row["Type"].ToString());
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
            dataTable = SettingsBasePage.settings_MIS_Delivery_Costs(this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["DeliveryCostTitle"] = base.SpecialDecode(row["DeliveryCostTitle"].ToString());
                row["Type"] = base.SpecialDecode(row["Type"].ToString());
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
            int num2 = SettingsBasePage.settings_MIS_DeliveryCost_insert_new(this.CompanyID, base.SpecialEncode(empty.Text), base.SpecialEncode(radTextBox.Text)," ", false, false,this.AccountID);
            if (num2 != -1)
            {
                empty.Text = string.Empty;
            }
            this.GridBind(this.CompanyID);
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_already_exists"), "msg-fail", this.plhMessage);
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
                System.Web.UI.WebControls.Label label = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblDeliveryCostID");
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
                System.Web.UI.WebControls.Label languageConversion = (System.Web.UI.WebControls.Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
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
            HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_deliverycostid");
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
            int num2 = SettingsBasePage.settings_MIS_DeliveryCost_update_new(this.CompanyID, this.OrdStatusID, base.SpecialEncode(empty.Text), base.SpecialEncode(radTextBox.Text),"",false,false,this.AccountID);
            if (num2 != -1)
            {
                empty.Text = string.Empty;
            }
            this.GridBind(this.CompanyID);
            if (num2 != -1)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_Saved_Successfully"), "msg-success", this.plhMessage);
                return;
            }
            base.Message_Display(this.objLanguage.GetLanguageConversion("Delivery_Cost_already_exists"), "msg-fail", this.plhMessage);
        }

        protected void GridOrdersBindTableAlpha(object source, GridSortCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.settings_Delivery_Costs(this.CompanyID,this.AccountID);
            this.GridOrders.DataSource = dataTable;
            this.GridOrders.DataBind();
        }

        protected DataTable GridStatusBindTable()
        {
            return SettingsBasePage.settings_Delivery_Costs(this.CompanyID,this.AccountID);
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
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Delivery_Cost"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays2 = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays2[0]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Settings/Settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Delivery_Cost")));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Delivery_Cost");
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() != "" && base.Request.Params["mode"].ToString().ToLower() == "update" && base.Request.Params["editid"].ToString() != "")
            {
                this.OrdStatusID = Convert.ToInt32(base.Request.Params["editid"].ToString());
            }
            DataTable dataTable = SettingsBasePage.settings_MIS_Delivery_Costs(this.CompanyID);
            foreach (DataRow row in dataTable.Rows)
            {
                row["DeliveryCostTitle"] = base.SpecialDecode(row["DeliveryCostTitle"].ToString());
                row["Type"] = base.SpecialDecode(row["Type"].ToString());
            }
            this.GridOrders.DataSource = dataTable;

            if (!base.IsPostBack)
            {
                this.Session["Status"] = null;
                if (base.Request.Params["mode"] != null && base.Request.Params["mode"].ToString() != "" && base.Request.Params["mode"].ToString().ToLower() == "update")
                {
                }
                DataTable dataTable1 = SettingsBasePage.PC_select_MIS_DeliveryCost_Settings(this.CompanyID);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    if (Convert.ToInt32(row1["IsEnableDC"]) != 1)
                    {
                        this.chkEnable.Checked = false;
                    }
                    else
                    {
                        this.chkEnable.Checked = true;
                    }
                    if (Convert.ToInt32(row1["IsEnableShipEngine"]) != 1)
                    {
                        this.ChkShipEngine.Checked = false;
                    }
                    else
                    {
                        this.ChkShipEngine.Checked = true;
                    }
                    if (Convert.ToInt32(row1["Allowpickup"]) != 1)
                    {
                        this.ChkAllowpickup.Checked = false;
                    }
                    else
                    {
                        this.ChkAllowpickup.Checked = true;
                    }
                }
            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays2 = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays2[0]);
            }
            SettingsBasePage.PC_Update_DeliveryCost_Settings(CompanyID,this.AccountID, this.chkEnable.Checked, this.ChkShipEngine.Checked, this.ChkAllowpickup.Checked);
        }

        protected class OrderNew
        {
            private long _DeliveryCostID;

            private string _DeliveryCostTitle;

            private string _Type;

            private bool _IsDefault;

            private string _FromShipEngine;

            private string _FromOtherStore;

            public bool IsDefault
            {
                get
                {
                    return this._IsDefault;
                }
            }
            public string FromShipEngine
            {
                get
                {
                    return this._FromShipEngine;
                }
            }

            public string FromOtherStore
            {
                get
                {
                    return this._FromOtherStore;
                }
            }

            public long DeliveryCostID
            {
                get
                {
                    return this._DeliveryCostID;
                }
            }

            public string DeliveryCostTitle
            {
                get
                {
                    return this._DeliveryCostTitle;
                }
            }

            public string Type
            {
                get
                {
                    return this._Type;
                }
            }

            public OrderNew(long DeliveryCostID, string DeliveryCostTitle, string Type, string FromShipEngine, string FromOtherStore)
            {
                this._DeliveryCostID = DeliveryCostID;
                this._DeliveryCostTitle = DeliveryCostTitle;
                this._Type = Type;
                this._FromShipEngine = FromShipEngine;
                this._FromOtherStore = FromOtherStore;
            }
        }
    }
}