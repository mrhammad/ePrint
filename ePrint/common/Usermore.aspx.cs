using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class Usermore : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lblusertype;

        //protected usercontrol_settings_settings_mis_headerpanel header_mis;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected RadGrid grdScreenName;

        //protected Panel pnlGrid;

        //protected Button btnsave;

        //protected Button btncancel;

        public string strImagepath;

        public int usertypeid;

        public languageClass objLanguage = new languageClass();

        public int companyId;

        public int userId;

        public ArrayList objOldScreenName = new ArrayList();

        public ArrayList objHeaderName = new ArrayList();

        private string bypass = string.Empty;

        private BasePage objpage = new BasePage();

        private Global gloobj = new Global();

        public string tabcolor = "";

        public languageClass objlang = new languageClass();

        public commonClass cmn = new commonClass();

        public static Hashtable ht;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected IList<Usermore.OrderNew> PendingOrders
        {
            get
            {
                IList< Usermore.OrderNew> orderNews;
                try
                {
                    object item = this.Session["UserTab"];
                    if (item == null)
                    {
                        item = this.GetOrders();
                        if (item == null)
                        {
                            item = new List< Usermore.OrderNew>();
                        }
                        else
                        {
                            this.Session["UserTab"] = item;
                        }
                    }
                    orderNews = (IList< Usermore.OrderNew>)item;
                }
                catch
                {
                    this.Session["UserTab"] = null;
                    return new List< Usermore.OrderNew>();
                }
                return orderNews;
            }
            set
            {
                this.Session["UserTab"] = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static  Usermore()
        {
             Usermore.ht = new Hashtable();
        }

        public  Usermore()
        {
        }

        public DataTable BindGrid()
        {
            DataTable dataTable = new DataTable();
            object[] item = new object[] { "crm_common_select_UserTab ", this.Session["companyID"], ",", this.Session["userID"] };
            SqlCommand sqlCommand = new SqlCommand(string.Concat(item), this.cmn.openConnection());
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            List<DataRow> toDelete = new List<DataRow>();
            if (!commonClass.CheckProofPermission())
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (dr["HeaderName"].ToString().ToLower().Equals("proofs"))
                    {
                        toDelete.Add(dr);
                    }
                }
                foreach (DataRow dr in toDelete)
                {
                    dataTable.Rows.Remove(dr);
                }
            }

            this.cmn.closeConnection();
            return dataTable;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "admin/usertype_view.aspx"));
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool flag;
            for (int i = 0; i < this.grdScreenName.Items.Count; i++)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)this.grdScreenName.Items[i].FindControl("chkDisplay");
                TextBox textBox = (TextBox)this.grdScreenName.Items[i].Cells[2].FindControl("txtScreenName");
                HiddenField hiddenField = (HiddenField)this.grdScreenName.Items[i].FindControl("hdnHeaderName");
                long num = Convert.ToInt64(this.grdScreenName.Items[i].GetDataKeyValue("Usertabid"));
                string str = base.SpecialEncode(textBox.Text);
                string value = hiddenField.Value;
                flag = (value.ToLower() != "home" ? htmlInputCheckBox.Checked : true);
                this.UpdateData(num, flag, str, value, i);
            }
            this.Session["HeaderNavigation"] = null;
            this.Session["HOME"] = "False";
            this.Session["LEADS"] = "False";
            this.Session["CLIENTS"] = "False";
            this.Session["OPPORTUNITIES"] = "False";
            this.Session["CONTACTS"] = "False";
            this.Session["TICKETS"] = "False";
            this.Session["CAMPAIGN"] = "False";
            this.Session["SOLUTIONS"] = "False";
            this.Session["DOCUMENTS"] = "False";
            this.Session["REPORTS"] = "False";
            this.Session["DASHBOARD"] = "False";
            this.Session["CONTRACTS"] = "False";
            this.Session["PRODUCTS"] = "False";
            this.Session["ASSETS"] = "False";
            this.Session["S_HOME"] = "HOME";
            this.Session["S_LEADS"] = "LEADS";
            this.Session["S_CLIENTS"] = "CLIENTS";
            this.Session["S_OPPORTUNITIES"] = "OPPORTUNITIES";
            this.Session["S_CONTACTS"] = "CONTACTS";
            this.Session["S_TICKETS"] = "TICKETS";
            this.Session["S_CAMPAIGN"] = "CAMPAIGN";
            this.Session["S_SOLUTIONS"] = "SOLUTIONS";
            this.Session["S_DOCUMENTS"] = "DOCUMENTS";
            this.Session["S_REPORTS"] = "REPORTS";
            this.Session["S_DASHBOARD"] = "DASHBOARD";
            this.Session["S_CONTRACTS"] = "CONTRACTS";
            this.Session["S_PRODUCTS"] = "PRODUCTS";
            this.Session["S_ASSETS"] = "ASSETS";
            object[] item = new object[] { "crm_common_select_UserTab ", this.Session["companyID"], ",", this.Session["userID"] };
            SqlCommand sqlCommand = new SqlCommand(string.Concat(item), this.cmn.openConnection());
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.Session[sqlDataReader["headerName"].ToString()] = sqlDataReader["isDisplay"];
                this.Session[sqlDataReader["s_HeaderName"].ToString()] = sqlDataReader["screenname"];
            }
            this.cmn.closeConnection();
            base.Response.Redirect(string.Concat(global.sitePath(), "common/usermore.aspx?&error=1"));
        }

        public void ChangeDataBaseScreenName(string HeaderName, string ScreenName, int i)
        {
            for (int num = 0; num < this.objHeaderName.Count; num++)
            {
                if (this.objOldScreenName[i].ToString().Trim().ToLower() != ScreenName.ToLower().Trim())
                {
                    commonClass _commonClass = new commonClass();
                    SqlCommand sqlCommand = new SqlCommand()
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "crm_common_select_ScreenNameForReplace"
                    };
                    sqlCommand.Parameters.Add("@pg", Convert.ToString(this.objHeaderName[num]));
                    sqlCommand.Parameters.Add("@companyID", Convert.ToInt32(this.Session["companyID"]));
                    sqlCommand.Connection = _commonClass.openConnection();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    base.Response.Write(string.Concat("<span style=color:red><b>HeaderName</b>=&nbsp;</span>", Convert.ToString(this.objHeaderName[num]), "<br/>"));
                    while (sqlDataReader.Read())
                    {
                        string str = sqlDataReader["ScreenName"].ToString().Replace(base.ReturnDataBaseScreenName(this.objOldScreenName[i].ToString().Trim(), 2, "p"), base.ReturnDataBaseScreenName(ScreenName, 2, "p").Trim());
                        commonClass _commonClass1 = new commonClass();
                        SqlCommand sqlCommand1 = new SqlCommand()
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "crm_common_Update_ScreenNameForReplace"
                        };
                        sqlCommand1.Parameters.Add("@pg", Convert.ToString(this.objHeaderName[num]));
                        sqlCommand1.Parameters.Add("@companyID", Convert.ToInt32(this.Session["companyID"]));
                        sqlCommand1.Parameters.Add("@CustomizeID", sqlDataReader["CustomizeID"].ToString());
                        sqlCommand1.Parameters.Add("@ScreenName", str);
                        sqlCommand1.Connection = _commonClass1.openConnection();
                        sqlCommand1.ExecuteNonQuery();
                        _commonClass1.closeConnection();
                    }
                    sqlDataReader.Close();
                    _commonClass.closeConnection();
                }
            }
        }

        private static  Usermore.OrderNew GetOrder(IEnumerable< Usermore.OrderNew> ordersToSearchIn, long HeaderId)
        {
             Usermore.OrderNew orderNew;
            using (IEnumerator< Usermore.OrderNew> enumerator = ordersToSearchIn.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                     Usermore.OrderNew current = enumerator.Current;
                    if (current.HeaderID != HeaderId)
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

        protected IList< Usermore.OrderNew> GetOrders()
        {
            IList< Usermore.OrderNew> orderNews = new List< Usermore.OrderNew>();
            DataTable dataTable = this.BindGrid();
            if (dataTable.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        long num = Convert.ToInt64(row["HeaderId"].ToString());
                        string str = row["HeaderName"].ToString();
                        string str1 = row["ScreenName"].ToString();
                        long num1 = Convert.ToInt64(row["UserTabId"].ToString());
                        int num2 = Convert.ToInt16(row["OrderNumber"].ToString());
                        bool flag = Convert.ToBoolean(row["IsDisplay"].ToString());
                        string str2 = row["tabName"].ToString();
                        orderNews.Add(new  Usermore.OrderNew(num, str1, str, num1, num2, flag, str2));
                    }
                    this.Session["UserTab"] = dataTable;
                }
                catch
                {
                    orderNews.Clear();
                }
            }
            return orderNews;
        }

        protected void grdScreenName_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("chkDisplay");
                Image image = (Image)e.Item.FindControl("imgDisplay");
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plhImg");
                TextBox textBox = (TextBox)e.Item.FindControl("txtScreenName");
                Label label = (Label)e.Item.FindControl("lblScreenName");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnHeaderName");
                Label label1 = (Label)e.Item.FindControl("lblTabName");
                textBox.Text = base.SpecialDecode(textBox.Text);
                if (hiddenField.Value.ToLower() == "home")
                {
                    htmlInputCheckBox.Visible = false;
                    placeHolder.Controls.Add(global.GetTickImage("img"));
                    textBox.Visible = false;
                    label.Visible = true;
                }
                string lower = label1.Text.ToLower();
                string str = lower;
                if (lower != null)
                {
                    switch (str)
                    {
                        case "home":
                            {
                                label1.Text = "Home";
                                return;
                            }
                        case "clients":
                            {
                                label1.Text = "CRM";
                                return;
                            }
                        case "jobs":
                            {
                                label1.Text = "Jobs";
                                return;
                            }
                        case "estimates":
                            {
                                label1.Text = "Estimates";
                                return;
                            }
                        case "purchases":
                            {
                                label1.Text = "Purchases";
                                return;
                            }
                        case "deliverynote":
                            {
                                label1.Text = "Deliverynote";
                                return;
                            }
                        case "invoices":
                            {
                                label1.Text = "Invoices";
                                return;
                            }
                        case "productcatalogue":
                            {
                                label1.Text = "Productcatalogue";
                                return;
                            }
                        case "reports":
                            {
                                label1.Text = "Reports";
                                return;
                            }
                        case "warehouse":
                            {
                                label1.Text = "Inventory";
                                return;
                            }
                        case "documents":
                            {
                                label1.Text = "Documents";
                                return;
                            }
                        case "campaign":
                            {
                                label1.Text = "Campaigns";
                                return;
                            }
                        case "webstoreorder":
                            {
                                label1.Text = "eStore Orders";
                                return;
                            }
                        case "settings":
                            {
                                label1.Text = "Settings";
                                return;
                            }
                        case "digitalasset":
                            {
                                label1.Text = "Digitalasset";
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
            }
        }

        protected void grdScreenName_RowDrop(object sender, GridDragDropEventArgs e)
        {
             Usermore.ht.Clear();
            string empty = string.Empty;
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DraggedItems[0].OwnerGridID == this.grdScreenName.ClientID && e.DestDataItem != null && e.DestDataItem.OwnerGridID == this.grdScreenName.ClientID)
            {
                IList< Usermore.OrderNew> pendingOrders = this.PendingOrders;
                 Usermore.OrderNew order =  Usermore.GetOrder(pendingOrders, Convert.ToInt64(e.DestDataItem.GetDataKeyValue("HeaderID")));
                int num = pendingOrders.IndexOf(order);
                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    num--;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    num++;
                }
                List< Usermore.OrderNew> orderNews = new List< Usermore.OrderNew>();
                foreach (GridDataItem draggedItem in e.DraggedItems)
                {
                     Usermore.OrderNew orderNew =  Usermore.GetOrder(pendingOrders, Convert.ToInt64(draggedItem.GetDataKeyValue("HeaderID")));
                    if (orderNew == null)
                    {
                        continue;
                    }
                    orderNews.Add(orderNew);
                }
                foreach ( Usermore.OrderNew orderNew1 in orderNews)
                {
                    pendingOrders.Remove(orderNew1);
                    pendingOrders.Insert(num, orderNew1);
                }
                this.PendingOrders = pendingOrders;
                for (int i = 0; i < pendingOrders.Count; i++)
                {
                     Usermore.ht.Add(pendingOrders[i].HeaderID, i + 1);
                }
                this.grdScreenName.DataSource = this.PendingOrders;
                this.grdScreenName.Rebind();
                int pageSize = num - this.grdScreenName.PageSize * this.grdScreenName.CurrentPageIndex;
                e.DestinationTableView.Items[pageSize].Selected = true;
                foreach (long key in  Usermore.ht.Keys)
                {
                    SettingsBasePage.settings_taborder_update(Convert.ToInt16(this.Session["CompanyID"].ToString()), Convert.ToInt32(Usermore.ht[key]), Convert.ToInt32(key));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnsave.Attributes.Add("onclick", "javascript:if(Page_ClientValidate()) {loadingimage(this.id,'div_btnsaveprocess');}");
            this.btnsave.Text = this.objlang.GetValueOnLang("Save");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (!base.IsPostBack)
            {
                this.btnsave.Text = this.objLanguage.GetLanguageConversion("Save");
                this.btncancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
                this.lblusertype.Text = this.objLanguage.convert(this.lblusertype.Text);
                this.grdScreenName.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Sections");
                this.grdScreenName.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Display");
                this.grdScreenName.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Screen_Name");
                this.grdScreenName.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("ReOrder");
            }
            global.pageName = "MoreTabs";
            global.pgDetail = "Home";
            this.gloobj.setpagename("setting");
            this.strImagepath = global.imagePath();
            this.companyId = int.Parse(this.Session["companyid"].ToString());
            this.userId = int.Parse(this.Session["userid"].ToString());
            this.bypass = base.Request.Params["bypass"];
            string deliveryNote = ConnectionClass.DeliveryNote;
            string warehouse = ConnectionClass.Warehouse;
            if (ConnectionClass.WebStore != null)
            {
            }
            this.tabcolor = this.objpage.colorCode(this.companyId, "moretabs");
            base.Title = this.objLanguage.convert(global.pageTitle("Tab Display", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Customize_Tab_Display")));
            global.pgDetail = string.Concat(this.objLanguage.convert("Home"), ">>", this.objLanguage.convert("More Tabs"));
            commonClass _commonClass = new commonClass();
            this.lblusertype.Text = base.SpecialDecode(string.Concat(this.Session["firstName"].ToString(), " ", this.Session["lastName"].ToString()));
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Customize_Tab_Display");
            if (!base.IsPostBack)
            {
                DataTable dataTable = new DataTable();
                dataTable = this.BindGrid();
                this.grdScreenName.DataSource = dataTable;
                this.grdScreenName.DataBind();
                this.Session["UserTab"] = null;
            }
            try
            {
                if (base.Request.QueryString["error"] == "1")
                {
                    base.Message_Display(this.objlang.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessage);
                }
            }
            catch
            {
            }
        }

        public void UpdateData(long UserTabId, bool IsDisplay, string ScreenName, string HeaderName, int counter)
        {
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("crm_common_update_userTab", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@usertabId", UserTabId);
            sqlCommand.Parameters.AddWithValue("@companyid", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@userid", int.Parse(this.Session["userID"].ToString()));
            sqlCommand.Parameters.AddWithValue("@isdisplay", IsDisplay);
            sqlCommand.ExecuteNonQuery();
            _commonClass.closeConnection();
            commonClass _commonClass1 = new commonClass();
            SqlCommand sqlCommand1 = new SqlCommand("crm_common_update_userTab_screenname", _commonClass1.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand1.Parameters.AddWithValue("@companyid", int.Parse(this.Session["companyID"].ToString()));
            sqlCommand1.Parameters.AddWithValue("@HeaderName", HeaderName);
            sqlCommand1.Parameters.AddWithValue("@ScreenName", ScreenName);
            sqlCommand1.ExecuteNonQuery();
            _commonClass1.closeConnection();
            this.ChangeDataBaseScreenName(HeaderName, ScreenName, counter);
        }

        protected class OrderNew
        {
            private long _HeaderID;

            private string _ScreenName;

            private string _HeaderName;

            private long _UserTabId;

            private int _OrderNumber;

            private bool _IsDisplay;

            private string _TabName;

            public long HeaderID
            {
                get
                {
                    return this._HeaderID;
                }
            }

            public string HeaderName
            {
                get
                {
                    return this._HeaderName;
                }
            }

            public bool IsDisplay
            {
                get
                {
                    return this._IsDisplay;
                }
            }

            public int OrderNumber
            {
                get
                {
                    return this._OrderNumber;
                }
            }

            public string ScreenName
            {
                get
                {
                    return this._ScreenName;
                }
            }

            public string TabName
            {
                get
                {
                    return this._TabName;
                }
            }

            public long UserTabId
            {
                get
                {
                    return this._UserTabId;
                }
            }

            public OrderNew(long HeaderID, string ScreenName, string HeaderName, long UserTabId, int OrderNumber, bool IsDisplay, string TabName)
            {
                this._HeaderID = HeaderID;
                this._ScreenName = ScreenName;
                this._HeaderName = HeaderName;
                this._UserTabId = UserTabId;
                this._OrderNumber = OrderNumber;
                this._IsDisplay = IsDisplay;
                this._TabName = TabName;
            }
        }
    }
}