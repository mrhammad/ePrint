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
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class manage_banner : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public string bannerImage = string.Empty;

        public string imgToSave = string.Empty;

        public string OrigFile_image = string.Empty;

        public string m_bannerImage = string.Empty;

        public string o_bannerImage = string.Empty;

        public string TD_bannerImage = string.Empty;

        public string filePath_img = string.Empty;

        public string stay = "h";

        public static Hashtable ht;

        public static Hashtable ht_Home;

        public static Hashtable ht_Right;

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int bannerID;

        public int bannerID_rtn;

        public int imgSortOrderNo;

        public static int cnt_checkBox_bannerHome;

        public static int cnt_checkBox_bannerLeft;

        public static int cnt_checkBox_bannerRight;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ServerName = ConnectionClass.ServerName;

        private bool Err_flag = true;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<manage_banner.OrderNew> PendingOrders
        {
            get
            {
                IList<manage_banner.OrderNew> orderNews;
                try
                {
                    object item = this.Session["LeftBanner"];
                    if (item == null || item == null)
                    {
                        item = this.GetOrders("L");
                        if (item == null)
                        {
                            item = new List<manage_banner.OrderNew>();
                        }
                        else
                        {
                            this.Session["LeftBanner"] = item;
                        }
                    }
                    orderNews = (IList<manage_banner.OrderNew>)item;
                }
                catch
                {
                    this.Session["LeftBanner"] = null;
                    return new List<manage_banner.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["LeftBanner"] = value;
            }
        }

        protected IList<manage_banner.OrderNew> PendingOrders_Home
        {
            get
            {
                IList<manage_banner.OrderNew> orderNews;
                try
                {
                    object item = this.Session["HomeBanner"];
                    if (item == null)
                    {
                        item = this.GetOrders("H");
                        if (item == null)
                        {
                            item = new List<manage_banner.OrderNew>();
                        }
                        else
                        {
                            this.Session["HomeBanner"] = item;
                        }
                    }
                    orderNews = (IList<manage_banner.OrderNew>)item;
                }
                catch
                {
                    this.Session["HomeBanner"] = null;
                    return new List<manage_banner.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["HomeBanner"] = value;
            }
        }

        protected IList<manage_banner.OrderNew> PendingOrders_Right
        {
            get
            {
                IList<manage_banner.OrderNew> orderNews;
                try
                {
                    object item = this.Session["RightBanner"];
                    if (item == null || item == null)
                    {
                        item = this.GetOrders("R");
                        if (item == null)
                        {
                            item = new List<manage_banner.OrderNew>();
                        }
                        else
                        {
                            this.Session["RightBanner"] = item;
                        }
                    }
                    orderNews = (IList<manage_banner.OrderNew>)item;
                }
                catch
                {
                    this.Session["RightBanner"] = null;
                    return new List<manage_banner.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["RightBanner"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static manage_banner()
        {
            manage_banner.ht = new Hashtable();
            manage_banner.ht_Home = new Hashtable();
            manage_banner.ht_Right = new Hashtable();
            manage_banner.cnt_checkBox_bannerHome = 0;
            manage_banner.cnt_checkBox_bannerLeft = 0;
            manage_banner.cnt_checkBox_bannerRight = 0;
        }

        public manage_banner()
        {
        }

        protected void BannerHome_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                Image image = (Image)e.Item.FindControl("imgbannerHome");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnImageHome");
                object[] accountID = new object[] { this.strSitepath, "DocManager.ashx?doctype=banner&actid=", this.AccountID, "&filename=", hiddenField.Value };
                image.ImageUrl = string.Concat(accountID);
            }
            catch
            {
            }
        }

        protected void BannerLeft_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                Image image = (Image)e.Item.FindControl("imgbannerLeft");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnImageLeft");
                object[] accountID = new object[] { this.strSitepath, "DocManager.ashx?doctype=banner&actid=", this.AccountID, "&filename=", hiddenField.Value };
                image.ImageUrl = string.Concat(accountID);
            }
            catch
            {
            }
        }

        protected void BannerRight_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Image image = (Image)e.Item.FindControl("imgbannerRight");
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnImageRight");
                    object[] accountID = new object[] { this.strSitepath, "DocManager.ashx?doctype=banner&actid=", this.AccountID, "&filename=", hiddenField.Value };
                    image.ImageUrl = string.Concat(accountID);
                }
            }
            catch
            {
            }
        }

        protected DataTable bannerSelectBindTable(string type)
        {
            DataSet dataSet = WebstoreBasePage.bannerSelect(0, this.CompanyID, this.AccountID, type);
            return dataSet.Tables[0];
        }

        public void bind_checkBox_bannerRight(int bannerID, int CompanyID, int AccountID, string type)
        {
            DataSet dataSet = WebstoreBasePage.bannerSelect(bannerID, CompanyID, AccountID, type);
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                if (type == "R")
                {
                    for (int i = 0; i < manage_banner.cnt_checkBox_bannerRight; i++)
                    {
                        Label label = (Label)this.div_locationRight.FindControl(string.Concat("lblPageRightID_", i));
                        CheckBox checkBox = (CheckBox)this.div_locationRight.FindControl(string.Concat("chk_location_right_", i));
                        if (label.Text == row["PageID"].ToString())
                        {
                            checkBox.Checked = true;
                        }
                    }
                }
                if (type != "L")
                {
                    continue;
                }
                for (int j = 0; j < manage_banner.cnt_checkBox_bannerLeft; j++)
                {
                    Label label1 = (Label)this.div_locationRight.FindControl(string.Concat("lblPageID_", j));
                    CheckBox checkBox1 = (CheckBox)this.div_locationRight.FindControl(string.Concat("chk_location_left_", j));
                    if (label1.Text == row["PageID"].ToString())
                    {
                        checkBox1.Checked = true;
                    }
                }
            }
        }

        public void bind_RadGrid_bannerHome(int bannerID, int CompanyID, int AccountID, string type)
        {
            DataSet dataSet = WebstoreBasePage.bannerSelect(0, CompanyID, AccountID, type);
            DataTable item = dataSet.Tables[0];
            foreach (DataRow row in item.Rows)
            {
                row["BannerTitle"] = base.SpecialDecode(row["BannerTitle"].ToString());
            }
            this.RadGrid_bannerHome.DataSource = item;
            this.RadGrid_bannerHome.DataBind();
        }

        public void bind_RadGrid_bannerLeft(int bannerID, int CompanyID, int AccountID, string type)
        {
            DataSet dataSet = WebstoreBasePage.bannerSelect(0, CompanyID, AccountID, type);
            DataTable item = dataSet.Tables[0];
            foreach (DataRow row in item.Rows)
            {
                row["BannerTitle"] = base.SpecialDecode(row["BannerTitle"].ToString());
            }
            this.RadGrid_bannerLeft.DataSource = item;
            this.RadGrid_bannerLeft.DataBind();
            int num = 3;
            int num1 = 0;
            foreach (DataRow dataRow in WebstoreBasePage.pagesSelect(CompanyID, AccountID, "display").Rows)
            {
                if (!(dataRow["systemName"].ToString().ToLower().Trim() != "productdetails") || !(dataRow["systemName"].ToString().ToLower().Trim() != "products"))
                {
                    continue;
                }
                CheckBox checkBox = new CheckBox()
                {
                    ID = string.Concat("chk_location_left_", num1),
                    Text = dataRow["pageName"].ToString().Trim(),
                    Width = 150,
                    Height = 20
                };
                this.ph_location_left.Controls.Add(checkBox);
                Label label = new Label()
                {
                    ID = string.Concat("lblPageID_", num1),
                    Text = dataRow["pageID"].ToString()
                };
                label.Style.Add("display", "none");
                this.ph_location_left.Controls.Add(label);
                num1++;
                if (num != num1)
                {
                    continue;
                }
                this.ph_location_left.Controls.Add(new LiteralControl("<br />"));
                num = num + 3;
            }
            manage_banner.cnt_checkBox_bannerLeft = num1;
        }

        public void bind_RadGrid_bannerRight(int bannerID, int CompanyID, int AccountID, string type)
        {
            DataSet dataSet = WebstoreBasePage.bannerSelect(0, CompanyID, AccountID, type);
            DataTable item = dataSet.Tables[0];
            foreach (DataRow row in item.Rows)
            {
                row["BannerTitle"] = base.SpecialDecode(row["BannerTitle"].ToString());
            }
            this.RadGrid_bannerRight.DataSource = item;
            this.RadGrid_bannerRight.DataBind();
            int num = 3;
            int num1 = 0;
            foreach (DataRow dataRow in WebstoreBasePage.pagesSelect(CompanyID, AccountID, "display").Rows)
            {
                if (dataRow["systemName"].ToString().ToLower().Trim() == "my accounts")
                {
                    continue;
                }
                CheckBox checkBox = new CheckBox()
                {
                    ID = string.Concat("chk_location_right_", num1),
                    Text = dataRow["pageName"].ToString().Trim(),
                    Width = 150,
                    Height = 20
                };
                this.ph_location_right.Controls.Add(checkBox);
                Label label = new Label()
                {
                    ID = string.Concat("lblPageRightID_", num1),
                    Text = dataRow["pageID"].ToString()
                };
                label.Style.Add("display", "none");
                this.ph_location_right.Controls.Add(label);
                num1++;
                if (num != num1)
                {
                    continue;
                }
                this.ph_location_right.Controls.Add(new LiteralControl("<br />"));
                num = num + 3;
            }
            manage_banner.cnt_checkBox_bannerRight = num1;
        }

        public void BindCustomColumns(string pg, CheckBoxList chkList)
        {
            DataTable dataTable = new DataTable();
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("[crm_common_CustomView_Columns]", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@pg", pg);
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            chkList.DataSource = dataTable;
            chkList.DataTextField = "ColumnAlias";
            chkList.DataValueField = "ColumnName";
            chkList.DataBind();
            _commonClass.closeConnection();
        }

        protected void btn_cancel_home_click(object sender, EventArgs e)
        {
            base.Response.Redirect("manage_banner.aspx?page=h");
        }

        protected void btn_cancel_left_click(object sender, EventArgs e)
        {
            base.Response.Redirect("manage_banner.aspx?page=l");
        }

        protected void btn_cancel_right_click(object sender, EventArgs e)
        {
            base.Response.Redirect("manage_banner.aspx?page=r");
        }

        protected void btn_saveBannerHome_Click(object sender, EventArgs e)
        {
            this.saveBanners(base.SpecialEncode(this.txt_bannerName_HomeBanner.Text), this.txt_bannerDescription_HomeBanner.Text, this.txt_url_HomeBanner.Text, "H", base.SpecialEncode(this.txtBannerName.Text));
        }

        protected void btn_saveBannerLeft_Click(object sender, EventArgs e)
        {
            this.saveBanners(base.SpecialEncode(this.txt_bannerName_LeftBanner.Text), "", this.txt_url_LeftBanner.Text, "L", "");
        }

        protected void btn_saveBannerRight_Click(object sender, EventArgs e)
        {
            this.saveBanners(base.SpecialEncode(this.txt_bannerName_RightBanner.Text), "", this.txt_url_RightBanner.Text, "R", "");
        }

        protected void btn_saveHome_Click(object sender, EventArgs e)
        {
            this.saveReorder_Banners("H");
        }

        protected void btn_saveLeft_Click(object sender, EventArgs e)
        {
            this.saveReorder_Banners("L");
        }

        protected void btn_saveRight_Click(object sender, EventArgs e)
        {
            this.saveReorder_Banners("R");
        }

        protected void DeleteHome_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_bannerHome.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_bannerHome.Items[i].Cells[0].FindControl("checkBox_Home");
                if (htmlInputCheckBox.Checked)
                {
                    this.bannerID = Convert.ToInt32(htmlInputCheckBox.Value);
                    WebstoreBasePage.bannerDelete(this.bannerID);
                    htmlInputCheckBox.Checked = false;
                }
            }
            this.RadGrid_bannerHome.Rebind();
            this.Session["HomeBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=h&suc=del");
        }

        protected void DeleteImgHome_OnClick(object sender, CommandEventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            WebstoreBasePage.bannerDelete(Convert.ToInt32(e.CommandArgument));
            this.Session["HomeBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=h&suc=del");
        }

        protected void DeleteImgLeft_OnClick(object sender, CommandEventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            WebstoreBasePage.bannerDelete(Convert.ToInt32(e.CommandArgument));
            this.Session["LeftBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=l&suc=del");
        }

        protected void DeleteImgRight_OnClick(object sender, CommandEventArgs e)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            WebstoreBasePage.bannerDelete(Convert.ToInt32(e.CommandArgument));
            this.Session["RightBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=r&suc=del");
        }

        protected void DeleteLeft_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_bannerLeft.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_bannerLeft.Items[i].Cells[0].FindControl("checkBox_Left");
                if (htmlInputCheckBox.Checked)
                {
                    this.bannerID = Convert.ToInt32(htmlInputCheckBox.Value);
                    WebstoreBasePage.bannerDelete(this.bannerID);
                    htmlInputCheckBox.Checked = false;
                }
            }
            this.Session["LeftBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=l&suc=del");
        }

        protected void DeleteRight_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RadGrid_bannerRight.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
                htmlInputCheckBox = (HtmlInputCheckBox)this.RadGrid_bannerRight.Items[i].Cells[0].FindControl("checkBox_Right");
                if (htmlInputCheckBox.Checked)
                {
                    this.bannerID = Convert.ToInt32(htmlInputCheckBox.Value);
                    WebstoreBasePage.bannerDelete(this.bannerID);
                    htmlInputCheckBox.Checked = false;
                }
            }
            this.Session["RightBanner"] = null;
            base.Response.Redirect("manage_banner.aspx?&page=r&suc=del");
        }

        private static manage_banner.OrderNew GetOrder(IEnumerable<manage_banner.OrderNew> ordersToSearchIn, int bannerID)
        {
            manage_banner.OrderNew orderNew;
            using (IEnumerator<manage_banner.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    manage_banner.OrderNew current = enumerator.Current;
                    if (current.bannerID != bannerID)
                    {
                        continue;
                    }
                    orderNew = current;
                    return orderNew;
                }
                return null;
            }
            //return orderNew;
        }

        protected IList<manage_banner.OrderNew> GetOrders(string type)
        {
            IList<manage_banner.OrderNew> orderNews = new List<manage_banner.OrderNew>();
            DataTable dataTable = this.bannerSelectBindTable(type);
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    int num = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int num1 = Convert.ToInt32(row["bannerID"].ToString());
                        string str = row["bannerTitle"].ToString().Trim();
                        string str1 = row["bannerImage"].ToString().Trim();
                        string str2 = row["bannerName"].ToString().Trim();
                        orderNews.Add(new manage_banner.OrderNew(num1, str, str1, num, str2));
                        num++;
                    }
                    if (type == "L")
                    {
                        this.Session["LeftBanner"] = dataTable;
                    }
                    else if (type == "H")
                    {
                        this.Session["HomeBanner"] = dataTable;
                    }
                    else if (type == "R")
                    {
                        this.Session["RightBanner"] = dataTable;
                    }
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
            this.RadGrid_bannerLeft.DataSource = this.PendingOrders;
        }

        protected void grdPendingOrders_NeedDataSource_Home(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid_bannerHome.DataSource = this.PendingOrders_Home;
        }

        protected void grdPendingOrders_NeedDataSource_Right(object source, GridNeedDataSourceEventArgs e)
        {
            this.RadGrid_bannerRight.DataSource = this.PendingOrders_Right;
        }

        protected void grdPendingOrders_RowDrop(object sender, GridDragDropEventArgs e)
        {
            manage_banner.ht.Clear();
            string empty = string.Empty;
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid_bannerLeft.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_bannerLeft.ClientID)
            {
                IList<manage_banner.OrderNew> pendingOrders = this.PendingOrders;
                manage_banner.OrderNew order = manage_banner.GetOrder(pendingOrders, Convert.ToInt32(e.DestDataItem.GetDataKeyValue("bannerID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<manage_banner.OrderNew> orderNews = new List<manage_banner.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    manage_banner.OrderNew orderNew = manage_banner.GetOrder(pendingOrders, Convert.ToInt32(draggedItem.GetDataKeyValue("bannerID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (manage_banner.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                    if (!manage_banner.ht.ContainsKey(pendingOrders[i].bannerID))
                    {
                        manage_banner.ht.Add(pendingOrders[i].bannerID, i + 1);
                    }
                }
                this.RadGrid_bannerLeft.DataSource = this.PendingOrders;
                this.RadGrid_bannerLeft.DataBind();
                int pageSize = num - this.RadGrid_bannerLeft.PageSize * this.RadGrid_bannerLeft.CurrentPageIndex;
                try
                {
                    e.DestinationTableView.Items[pageSize].Selected = true;
                }
                catch
                {
                }
            }
        }

        protected void grdPendingOrders_RowDrop_Home(object sender, GridDragDropEventArgs e)
        {
            manage_banner.ht_Home.Clear();
            string empty = string.Empty;
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid_bannerHome.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_bannerHome.ClientID)
            {
                IList<manage_banner.OrderNew> pendingOrdersHome = this.PendingOrders_Home;
                manage_banner.OrderNew order = manage_banner.GetOrder(pendingOrdersHome, Convert.ToInt32(e.DestDataItem.GetDataKeyValue("bannerID")));
                int num = pendingOrdersHome.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<manage_banner.OrderNew> orderNews = new List<manage_banner.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    manage_banner.OrderNew orderNew = manage_banner.GetOrder(pendingOrdersHome, Convert.ToInt32(draggedItem.GetDataKeyValue("bannerID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (manage_banner.OrderNew orderNew1 in orderNews)
                {
                    pendingOrdersHome.Remove(orderNew1);
                    pendingOrdersHome.Insert(num, orderNew1);
                }
                this.PendingOrders_Home = pendingOrdersHome;
                for (int i = 0; i < pendingOrdersHome.Count; i++)
                {
                    manage_banner.ht_Home.Add(pendingOrdersHome[i].bannerID, i + 1);
                }
                this.RadGrid_bannerHome.DataSource = this.PendingOrders_Home;
                this.RadGrid_bannerHome.DataBind();
                int pageSize = num - this.RadGrid_bannerHome.PageSize * this.RadGrid_bannerHome.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void grdPendingOrders_RowDrop_Right(object sender, GridDragDropEventArgs e)
        {
            manage_banner.ht_Right.Clear();
            string empty = string.Empty;
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.RadGrid_bannerRight.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.RadGrid_bannerRight.ClientID)
            {
                IList<manage_banner.OrderNew> pendingOrdersRight = this.PendingOrders_Right;
                manage_banner.OrderNew order = manage_banner.GetOrder(pendingOrdersRight, Convert.ToInt32(e.DestDataItem.GetDataKeyValue("bannerID")));
                int num = pendingOrdersRight.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List<manage_banner.OrderNew> orderNews = new List<manage_banner.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                    manage_banner.OrderNew orderNew = manage_banner.GetOrder(pendingOrdersRight, Convert.ToInt32(draggedItem.GetDataKeyValue("bannerID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach (manage_banner.OrderNew orderNew1 in orderNews)
                {
                    pendingOrdersRight.Remove(orderNew1);
                    pendingOrdersRight.Insert(num, orderNew1);
                }
                this.PendingOrders_Right = pendingOrdersRight;
                for (int i = 0; i < pendingOrdersRight.Count; i++)
                {
                    manage_banner.ht_Right.Add(pendingOrdersRight[i].bannerID, i + 1);
                }
                this.RadGrid_bannerRight.DataSource = this.PendingOrders_Right;
                this.RadGrid_bannerRight.DataBind();
                int pageSize = num - this.RadGrid_bannerRight.PageSize * this.RadGrid_bannerRight.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
            }
        }

        protected void lnkCopyBanners_click(object sender, EventArgs e)
        {
            if (base.Request.Cookies["CopyBanners"] != null)
            {
                if (base.Request.Cookies["CopyBanners"].Value == "home")
                {
                    this.bind_RadGrid_bannerHome(0, this.CompanyID, this.AccountID, "H");
                    this.RadGrid_bannerHome.MasterTableView.Rebind();
                    base.Response.Redirect("manage_banner.aspx?&page=h&copy=yes");
                }
                if (base.Request.Cookies["CopyBanners"].Value == "left")
                {
                    this.bind_RadGrid_bannerLeft(0, this.CompanyID, this.AccountID, "L");
                    this.RadGrid_bannerLeft.MasterTableView.Rebind();
                    base.Response.Redirect("manage_banner.aspx?&page=l&copy=yes");
                }
                if (base.Request.Cookies["CopyBanners"].Value == "right")
                {
                    this.bind_RadGrid_bannerRight(0, this.CompanyID, this.AccountID, "R");
                    this.RadGrid_bannerRight.MasterTableView.Rebind();
                    base.Response.Redirect("manage_banner.aspx?&page=r&copy=yes");
                }
            }
            base.Message_Display("Banners Copied Successfully", "msg-success", this.plhMessageNew);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btn_cancel_right.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel_right','div_btn_cancel_rightprocess');");
            this.btn_cancel_left.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel_left','div_btn_cancel_leftprocess');");
            this.btn_cancel_home.Attributes.Add("onclick", "javascript:loadingimg('div_btn_cancel_home','div_btn_cancel_homeprocess');");
            this.btn_saveBannerHome.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel_home.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_saveBannerLeft.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel_left.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_saveLeft.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_saveBannerRight.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btn_cancel_right.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_saveRight.Text = this.objLanguage.GetLanguageConversion("Save");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.QueryString["copy"] != null && base.Request.QueryString["copy"].ToString() == "yes")
            {
                base.Message_Display("Banners Copied Successfully", "msg-success", this.plhMessageNew);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            string str1 = "";
            str1 = (this.AccountID == 0 ? "x" : WebstoreBasePage.SelectAccountType(this.AccountID));
            if (str1.ToLower() != "p")
            {
                this.li_home.Visible = true;
            }
            else
            {
                this.li_home.Visible = false;
                this.stay = "l";
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Manage_Banners")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Manage Banners", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            object[] accountID = new object[] { this.strSitepath, "DocManager.ashx?doctype=banner&actid=", this.AccountID, "&filename=" };
            this.filePath_img = string.Concat(accountID);
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Manage_Banners");
            if (base.Request.Params["page"] != null)
            {
                this.stay = base.Request.Params["page"];
            }
            if (!base.IsPostBack && base.Request.Params["suc"] != null)
            {
                if (base.Request.Params["suc"] == "in")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Record_Saved_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "up")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Record_Updated_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "no")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Please_Select_Account_And_Proceed"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "reH")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Sliding_Banner_Reordered_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "reL")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Left_Banner_Reordered_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "reR")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Right_Banner_Reordered_Successfully"), "msg-success", this.plhMessageNew);
                }
                if (base.Request.Params["suc"] == "del")
                {
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Banner_Deleted_Successfully"), "msg-success", this.plhMessageNew);
                }
            }
            if (base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit" && base.Request.Params["bannerID"] != null)
            {
                this.bannerID = Convert.ToInt32(base.Request.Params["bannerID"]);
            }
            if (!base.IsPostBack && base.Request.Params["mode"] != null && base.Request.Params["mode"] == "edit" && base.Request.Params["bannerID"] != null)
            {
                this.bannerID = Convert.ToInt32(base.Request.Params["bannerID"]);
                if (base.Request.Params["page"] != null)
                {
                    if (base.Request.Params["page"].ToLower().Trim() == "l")
                    {
                        DataSet dataSet = WebstoreBasePage.bannerSelect(this.bannerID, this.CompanyID, this.AccountID, "L");
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            this.txt_bannerName_LeftBanner.Text = base.SpecialDecode(row["bannerTitle"].ToString().Trim());
                            this.txt_url_LeftBanner.Text = row["URL"].ToString().Trim();
                            if (row["bannerImage"].ToString().Trim() == "")
                            {
                                continue;
                            }
                            this.lnkFileName.InnerHtml = row["bannerImage"].ToString().Trim();
                            this.hdn_catagoryImageName_left.Value = row["bannerImage"].ToString().Trim();
                            this.imgSortOrderNo = Convert.ToInt32(row["imageSortOrderNo"].ToString().Trim());
                            this.div_fuBanner_LeftBanner.Style.Add("display", "none");
                            this.div_changeImage.Style.Add("display", "block");
                        }
                        this.txt_bannerName_LeftBanner.Focus();
                    }
                    if (base.Request.Params["page"].ToLower().Trim() == "h")
                    {
                        DataSet dataSet1 = WebstoreBasePage.bannerSelect(this.bannerID, this.CompanyID, this.AccountID, "H");
                        foreach (DataRow dataRow in dataSet1.Tables[0].Rows)
                        {
                            this.txtBannerName.Text = dataRow["bannerName"].ToString().Trim();
                            this.txt_bannerName_HomeBanner.Text = base.SpecialDecode(dataRow["bannerTitle"].ToString().Trim());
                            this.txt_url_HomeBanner.Text = dataRow["URL"].ToString().Trim();
                            this.txt_bannerDescription_HomeBanner.Text = dataRow["bannerDescription"].ToString().Trim();
                            if (dataRow["bannerImage"].ToString().Trim() == "")
                            {
                                continue;
                            }
                            this.lnkFileName_Home.InnerHtml = dataRow["bannerImage"].ToString().Trim();
                            this.hdn_catagoryImageName_home.Value = dataRow["bannerImage"].ToString().Trim();
                            this.imgSortOrderNo = Convert.ToInt32(dataRow["imageSortOrderNo"].ToString().Trim());
                            this.div_fuBanner_HomeBanner.Style.Add("display", "none");
                            this.div_changeImage_Home.Style.Add("display", "block");
                        }
                        this.txt_bannerName_HomeBanner.Focus();
                    }
                    if (base.Request.Params["page"].ToLower().Trim() == "r")
                    {
                        DataSet dataSet2 = WebstoreBasePage.bannerSelect(this.bannerID, this.CompanyID, this.AccountID, "R");
                        foreach (DataRow row1 in dataSet2.Tables[0].Rows)
                        {
                            this.txt_bannerName_RightBanner.Text = base.SpecialDecode(row1["bannerTitle"].ToString().Trim());
                            this.txt_url_RightBanner.Text = row1["URL"].ToString().Trim();
                            if (row1["bannerImage"].ToString().Trim() == "")
                            {
                                continue;
                            }
                            this.lnkFileName_Right.InnerHtml = row1["bannerImage"].ToString().Trim();
                            this.hdn_catagoryImageName_Right.Value = row1["bannerImage"].ToString().Trim();
                            this.imgSortOrderNo = Convert.ToInt32(row1["imageSortOrderNo"].ToString().Trim());
                            this.div_fuBanner_RightBanner.Style.Add("display", "none");
                            this.div_changeImage_Right.Style.Add("display", "block");
                        }
                        this.txt_bannerName_RightBanner.Focus();
                    }
                }
            }
            if (!base.IsPostBack)
            {
                manage_banner.ht.Clear();
                manage_banner.ht_Home.Clear();
                manage_banner.ht_Right.Clear();
                this.bind_RadGrid_bannerLeft(0, this.CompanyID, this.AccountID, "L");
                this.bind_RadGrid_bannerHome(0, this.CompanyID, this.AccountID, "H");
                this.bind_RadGrid_bannerRight(0, this.CompanyID, this.AccountID, "R");
                this.Session["HomeBanner"] = null;
                this.Session["LeftBanner"] = null;
                this.Session["RightBanner"] = null;
                if (this.bannerID != 0)
                {
                    if (this.stay == "r")
                    {
                        this.bind_checkBox_bannerRight(this.bannerID, this.CompanyID, this.AccountID, "R");
                    }
                    if (this.stay == "l")
                    {
                        this.bind_checkBox_bannerRight(this.bannerID, this.CompanyID, this.AccountID, "L");
                    }
                }
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.commclass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.commclass.functionCheckChange());
            }
            if (this.Session["HomeBanner"] == null)
            {
                this.Session["HomeBanner"] = this.GetOrders("H");
            }
            if (this.Session["LeftBanner"] == null)
            {
                this.Session["LeftBanner"] = this.GetOrders("L");
            }
            if (this.Session["RightBanner"] == null)
            {
                this.Session["RightBanner"] = this.GetOrders("R");
            }
        }

        public string ReturnFileName(string fileName, int Number)
        {
            string empty = string.Empty;
            object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//" };
            string str = string.Concat(secureDocPath);
            string str1 = string.Concat(str, fileName);
            string str2 = fileName.Substring(0, fileName.LastIndexOf("."));
            string str3 = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
            if (!File.Exists(str1))
            {
                empty = fileName;
            }
            else
            {
                string str4 = string.Concat("_", Number.ToString());
                empty = string.Concat(str2, str4, str3);
            }
            if (!File.Exists(string.Concat(str, empty)))
            {
                return empty;
            }
            return this.ReturnFileName(fileName, Number + 1);
        }

        public void saveBanners(string bannerTitle, string bannerDiscription, string bannerURL, string bannerType, string bannerName)
        {
            string[] strArrays;
            bool hasFile = false;
            string empty = string.Empty;
            string str = string.Empty;
            if (bannerType == "R")
            {
                hasFile = this.fuBanner_RightBanner.HasFile;
                empty = this.fuBanner_RightBanner.FileName;
                strArrays = this.fuBanner_RightBanner.FileName.ToString().Trim().Split(new char[] { '.' });
                str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            }
            if (bannerType == "L")
            {
                hasFile = this.fuBanner_LeftBanner.HasFile;
                empty = this.fuBanner_LeftBanner.FileName;
                strArrays = this.fuBanner_LeftBanner.FileName.ToString().Trim().Split(new char[] { '.' });
                str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            }
            if (bannerType == "H")
            {
                hasFile = this.fuBanner_HomeBanner.HasFile;
                empty = this.fuBanner_HomeBanner.FileName;
                strArrays = this.fuBanner_HomeBanner.FileName.ToString().Trim().Split(new char[] { '.' });
                str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
            }
            this.Err_flag = true;
            string str1 = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str1 != "")
            {
                string[] strArrays1 = str1.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays1[0]);
                string str2 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays1[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str2, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (this.AccountID != 0)
            {
                if (hasFile)
                {
                    if (str.ToLower() == "jpg" || str.ToLower() == "png" || str.ToLower() == "tif" || str.ToLower() == "jpeg" || str.ToLower() == "bmp" || str.ToLower() == "jpf" || str.ToLower() == "gif" || str.ToLower() == "msp" || str.ToLower() == "mng" || str.ToLower() == "pct" || str.ToLower() == "yuv" || str.ToLower() == "tiff" || str.ToLower() == "mng" || str.ToLower() == "jfif" || str.ToLower() == "dib" || str.ToLower() == "jpe")
                    {
                        if (bannerType == "R")
                        {
                            this.spn_image_RightBanner.Style.Add("display", "none");
                            this.spn_image_RightBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_RightBanner_onlyImg.Style.Add("display", "none");
                        }
                        if (bannerType == "L")
                        {
                            this.spn_image_LeftBanner.Style.Add("display", "none");
                            this.spn_image_LeftBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_LeftBanner_onlyImg.Style.Add("display", "none");
                        }
                        if (bannerType == "H")
                        {
                            this.spn_image_RightBanner.Style.Add("display", "none");
                            this.spn_image_RightBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_RightBanner_onlyImg.Style.Add("display", "none");
                        }
                        if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//")))
                        {
                            Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//"));
                        }
                        string str3 = string.Concat(this.SecureDocPath, this.ServerName, "//");
                        if (!Directory.Exists(string.Concat(str3, "store//")))
                        {
                            Directory.CreateDirectory(string.Concat(str3, "store//"));
                        }
                        if (!Directory.Exists(string.Concat(str3, "store//", this.AccountID)))
                        {
                            Directory.CreateDirectory(string.Concat(str3, "store//", this.AccountID));
                        }
                        object[] accountID = new object[] { str3, "store//", this.AccountID, "//banners" };
                        if (!Directory.Exists(string.Concat(accountID)))
                        {
                            object[] objArray = new object[] { str3, "store//", this.AccountID, "//banners" };
                            Directory.CreateDirectory(string.Concat(objArray));
                        }
                        this.bannerImage = empty;
                        string str4 = Guid.NewGuid().ToString();
                        str4 = str4.Replace("-", string.Empty);
                        str4 = str4.Substring(0, 5);
                        this.bannerImage = this.bannerImage.Replace(" ", "_");
                        this.bannerImage = this.ReturnFileName(this.bannerImage, 0);
                        this.imgToSave = this.bannerImage;
                        if (bannerType == "R")
                        {
                            FileUpload fuBannerRightBanner = this.fuBanner_RightBanner;
                            object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            fuBannerRightBanner.SaveAs(string.Concat(secureDocPath));
                        }
                        if (bannerType == "L")
                        {
                            FileUpload fuBannerLeftBanner = this.fuBanner_LeftBanner;
                            object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            fuBannerLeftBanner.SaveAs(string.Concat(secureDocPath1));
                        }
                        if (bannerType == "H")
                        {
                            FileUpload fuBannerHomeBanner = this.fuBanner_HomeBanner;
                            object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            fuBannerHomeBanner.SaveAs(string.Concat(objArray1));
                        }
                    }
                    else
                    {
                        if (bannerType == "R")
                        {
                            this.spn_image_RightBanner.Style.Add("display", "none");
                            this.spn_image_RightBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_RightBanner_onlyImg.Style.Add("display", "none");
                        }
                        if (bannerType == "L")
                        {
                            this.spn_image_LeftBanner.Style.Add("display", "none");
                            this.spn_image_LeftBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_LeftBanner_onlyImg.Style.Add("display", "none");
                        }
                        if (bannerType == "H")
                        {
                            this.spn_image_RightBanner.Style.Add("display", "none");
                            this.spn_image_RightBanner_selectImg.Style.Add("display", "none");
                            this.spn_image_RightBanner_onlyImg.Style.Add("display", "none");
                        }
                        this.Err_flag = false;
                    }
                }
                if (!this.Err_flag)
                {
                    if (bannerType == "R")
                    {
                        base.Response.Redirect("manage_banner.aspx?&page=r&suc=no");
                    }
                    if (bannerType == "L")
                    {
                        base.Response.Redirect("manage_banner.aspx?&page=l&suc=no");
                    }
                    if (bannerType == "H")
                    {
                        base.Response.Redirect("manage_banner.aspx?&page=h&suc=no");
                    }
                }
                else
                {
                    if (this.bannerID == 0)
                    {
                        this.bannerID_rtn = WebstoreBasePage.bannerInsert(0, this.CompanyID, this.AccountID, bannerTitle, bannerDiscription, this.bannerImage, bannerURL, bannerType, 0, bannerName);
                        if (bannerType == "H")
                        {
                            this.Session["HomeBanner"] = null;
                            this.Session["HomeBanner"] = this.GetOrders("H");
                        }
                        if (bannerType == "L")
                        {
                            this.Session["LeftBanner"] = null;
                            this.Session["LeftBanner"] = this.GetOrders("L");
                        }
                        if (bannerType == "R")
                        {
                            this.Session["RightBanner"] = null;
                            this.Session["RightBanner"] = this.GetOrders("R");
                        }
                        if (bannerType == "L")
                        {
                            string[] strArrays2 = this.hid_LeftBannerPaperID.Value.Split(new char[] { 'µ' });
                            for (int i = 0; i < (int)strArrays2.Length; i++)
                            {
                                if (strArrays2[i] != "")
                                {
                                    WebstoreBasePage.bannerLocationInsert(this.bannerID_rtn, bannerType, Convert.ToInt32(strArrays2[i]));
                                }
                            }
                        }
                        else if (bannerType == "R")
                        {
                            string[] strArrays3 = this.hid_RightBannerPaperID.Value.Split(new char[] { 'µ' });
                            for (int j = 0; j < (int)strArrays3.Length; j++)
                            {
                                if (strArrays3[j] != "")
                                {
                                    WebstoreBasePage.bannerLocationInsert(this.bannerID_rtn, bannerType, Convert.ToInt32(strArrays3[j]));
                                }
                            }
                        }
                    }
                    else if (bannerType == "H")
                    {
                        if (this.hdn_catagoryImageName_home.Value != "")
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, bannerDiscription, this.hdn_catagoryImageName_home.Value, bannerURL, bannerType, this.imgSortOrderNo, bannerName);
                        }
                        else
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, bannerDiscription, this.bannerImage, bannerURL, bannerType, this.imgSortOrderNo, bannerName);
                        }
                        this.Session["HomeBanner"] = null;
                        this.Session["HomeBanner"] = this.GetOrders("H");
                    }
                    else if (bannerType == "L")
                    {
                        if (this.hdn_catagoryImageName_left.Value != "")
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, "", this.hdn_catagoryImageName_left.Value, bannerURL, bannerType, this.imgSortOrderNo, "");
                        }
                        else
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, "", this.bannerImage, bannerURL, bannerType, this.imgSortOrderNo, "");
                        }
                        string[] strArrays4 = this.hid_LeftBannerPaperID.Value.Split(new char[] { 'µ' });
                        for (int k = 0; k < (int)strArrays4.Length; k++)
                        {
                            if (strArrays4[k] != "")
                            {
                                WebstoreBasePage.bannerLocationInsert(this.bannerID_rtn, bannerType, Convert.ToInt32(strArrays4[k]));
                            }
                        }
                        this.Session["LeftBanner"] = null;
                        this.Session["LeftBanner"] = this.GetOrders("L");
                    }
                    else if (bannerType == "R")
                    {
                        if (this.hdn_catagoryImageName_Right.Value != "")
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, "", this.hdn_catagoryImageName_Right.Value, bannerURL, bannerType, this.imgSortOrderNo, "");
                        }
                        else
                        {
                            this.bannerID_rtn = WebstoreBasePage.bannerInsert(this.bannerID, this.CompanyID, this.AccountID, bannerTitle, "", this.bannerImage, bannerURL, bannerType, this.imgSortOrderNo, "");
                        }
                        string[] strArrays5 = this.hid_RightBannerPaperID.Value.Split(new char[] { 'µ' });
                        for (int l = 0; l < (int)strArrays5.Length; l++)
                        {
                            if (strArrays5[l] != "")
                            {
                                WebstoreBasePage.bannerLocationInsert(this.bannerID_rtn, bannerType, Convert.ToInt32(strArrays5[l]));
                            }
                        }
                        this.Session["RightBanner"] = null;
                        this.Session["RightBanner"] = this.GetOrders("R");
                    }
                    if (bannerType == "H")
                    {
                        if (this.hdn_catagoryImageName_home.Value != "")
                        {
                            object[] secureDocPath2 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.hdn_catagoryImageName_home.Value };
                            this.m_bannerImage = string.Concat(secureDocPath2);
                            this.imgToSave = this.hdn_catagoryImageName_home.Value;
                        }
                        else
                        {
                            object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            this.OrigFile_image = string.Concat(objArray2);
                        }
                    }
                    if (bannerType == "R")
                    {
                        if (this.hdn_catagoryImageName_Right.Value != "")
                        {
                            object[] secureDocPath3 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.hdn_catagoryImageName_Right.Value };
                            this.m_bannerImage = string.Concat(secureDocPath3);
                            this.imgToSave = this.hdn_catagoryImageName_Right.Value;
                        }
                        else
                        {
                            object[] objArray3 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            this.OrigFile_image = string.Concat(objArray3);
                        }
                    }
                    if (bannerType == "L")
                    {
                        if (this.hdn_catagoryImageName_left.Value != "")
                        {
                            object[] secureDocPath4 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.hdn_catagoryImageName_left.Value };
                            this.m_bannerImage = string.Concat(secureDocPath4);
                            this.imgToSave = this.hdn_catagoryImageName_left.Value;
                        }
                        else
                        {
                            object[] objArray4 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                            this.OrigFile_image = string.Concat(objArray4);
                        }
                    }
                    if (bannerType == "R")
                    {
                        if (this.bannerID != 0)
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=r&suc=up");
                        }
                        else
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=r&suc=in");
                        }
                        this.RadGrid_bannerRight.Rebind();
                    }
                    if (bannerType == "L")
                    {
                        if (this.bannerID != 0)
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=l&suc=up");
                        }
                        else
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=l&suc=in");
                        }
                        this.RadGrid_bannerLeft.Rebind();
                    }
                    if (bannerType == "H")
                    {
                        if (this.bannerID != 0)
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=h&suc=up");
                        }
                        else
                        {
                            base.Response.Redirect("manage_banner.aspx?&page=h&suc=in");
                        }
                        this.RadGrid_bannerHome.Rebind();
                        return;
                    }
                }
            }
        }

        public void saveReorder_Banners(string type)
        {
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (type == "L")
            {
                foreach (int key in manage_banner.ht.Keys)
                {
                    WebstoreBasePage.bannerSort(Convert.ToInt32(key), this.CompanyID, this.AccountID, Convert.ToInt32(manage_banner.ht[key]));
                }
                base.Response.Redirect("manage_banner.aspx?&page=l&suc=reL");
                return;
            }
            if (type == "H")
            {
                foreach (int num in manage_banner.ht_Home.Keys)
                {
                    WebstoreBasePage.bannerSort(Convert.ToInt32(num), this.CompanyID, this.AccountID, Convert.ToInt32(manage_banner.ht_Home[num]));
                }
                base.Response.Redirect("manage_banner.aspx?&page=h&suc=reH");
                return;
            }
            if (type == "R")
            {
                foreach (int key1 in manage_banner.ht_Right.Keys)
                {
                    WebstoreBasePage.bannerSort(Convert.ToInt32(key1), this.CompanyID, this.AccountID, Convert.ToInt32(manage_banner.ht_Right[key1]));
                }
                base.Response.Redirect("manage_banner.aspx?&page=r&suc=reR");
            }
        }

        protected class OrderNew
        {
            private int _bannerID;

            private string _bannerTitle;

            private string _bannerImage;

            private int _imageSortOrderNo;

            private string _bannerName;

            public int bannerID
            {
                get
                {
                    return this._bannerID;
                }
            }

            public string bannerImage
            {
                get
                {
                    return this._bannerImage;
                }
            }

            public string bannerName
            {
                get
                {
                    return this._bannerName;
                }
            }

            public string bannerTitle
            {
                get
                {
                    return this._bannerTitle;
                }
            }

            public int imageSortOrderNo
            {
                get
                {
                    return this._imageSortOrderNo;
                }
            }

            public OrderNew(int bannerID, string bannerTitle, string bannerImage, int imageSortOrderNo, string bannerName)
            {
                this._bannerID = bannerID;
                this._bannerTitle = bannerTitle;
                this._bannerImage = bannerImage;
                this._imageSortOrderNo = imageSortOrderNo;
                this._bannerName = bannerName;
            }
        }
    }
}