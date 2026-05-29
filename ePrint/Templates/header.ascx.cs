using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint
{
    public partial class header : UserControl
    {

        public string ColorCode = string.Empty;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureSitePath = global.SecureSitePath();

        public string cla = string.Empty;

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public string tabcolor = "";

        public string ActiveForecolor = "";

        public string headerforecolor = "";

        public int companyID;

        private string SelectedSection = string.Empty;

        public string ActiveNavSection
        {
            get { return this.SelectedSection ?? string.Empty; }
        }

        public string SidebarCompanyDisplayName { get; private set; }

        public string SidebarProductBrandTagline { get; private set; }

        public string SidebarUserDisplayName { get; private set; }

        public string SidebarUserRoleDisplay { get; private set; }

        public string SidebarLogoText { get; private set; }

        public string AccountingExport = ConnectionClass.AccountingExport;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ServerName = ConnectionClass.ServerName;

        public string IsAccessRight = string.Empty;

        private commonClass cmn = new commonClass();

        private int STviewid;

        private string pg = string.Empty;

        public int defaultviewid;

        private string _Pg = string.Empty;

        private commonClass comm = new commonClass();

        public languageClass objLanguage = new languageClass();

        public commonClass commclass = new commonClass();

        public string UserImage1 = string.Empty;

        public string UserImage2 = string.Empty;

        public string CurrencySymbol = ConnectionClass.CurrencySymbol;

        public string EnableAdvancedCRM = "";

        public int UserID;

        public int sessionTimeout;

        public string divlistestimate = string.Empty;

        public string divlistcrm = string.Empty;

        public string divlistjob = string.Empty;

        public string divlistpurchase = string.Empty;

        public string divlistdeliverynotes = string.Empty;
        public string divlistproofs = string.Empty;


        public string divlistinvoice = string.Empty;

        public string divlistinventory = string.Empty;

        public string divlistreport = string.Empty;

        public string divlistcampaign = string.Empty;

        public string divlistorder = string.Empty;

        public string divlistproductcatalogue = string.Empty;

        public string GetSelectedTabText = string.Empty;

        public string IsWebstore = string.Empty;

        public string GetRolesRight_SettingIcon = string.Empty;

        public string MISsettingHeight = string.Empty;

        public string eStoreSettingHeight = string.Empty;

        public string IsSettingTabDisplay = string.Empty;

        public string IsReportsDisplay = string.Empty;

        public string GetRolesRight_ReportIcon = string.Empty;

        public string divlistForecast = string.Empty;

        public string bordercolor = "";

        public string DateFormat = string.Empty;

        public string TodayDate = string.Empty;

        public string TodDate = string.Empty;

        public string Createddate = DateTime.Now.ToString();

        public string SystemDateTime = string.Empty;

        public string PitstopPath = string.Empty;

        public int CompanyID;

        private SettingsBasePage objSetBase = new SettingsBasePage();

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

        public string SectionName
        {
            get
            {
                return this._Pg;
            }
            set
            {
                this._Pg = value;
            }
        }

        public header()
        {
        }

        public void BindEdirTaskPyorty()
        {

        }

        public void BindEditStatusDrop()
        {

        }

        public void BindEditSubJectDropdown()
        {
            try
            {

            }
            catch
            {
            }
        }

        public void BindPyortyDrop()
        {

        }

        public void BindStatusDrop()
        {
            taskClass _taskClass = new taskClass();

        }

        public void BindSubJectDropdown()
        {
            DataTable dataTable = Settings.settings_subject_select(Convert.ToInt32(this.companyID));
            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["IsDefault"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                }
            }
        }

        public void BonDCallOwner()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_user_select(this.companyID, this.UserID, Convert.ToInt16(this.hdnSectionID_FromHeader.Value));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    row["Name"] = this.objBase.SpecialDecode(row["Name"].ToString());
                }

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (dataRow["UserID"].ToString().ToLower() != Convert.ToInt32(this.UserID).ToString())
                    {
                        continue;
                    }


                }

            }
        }

        protected void btnContinueWorking_Click(object sender, EventArgs e)
        {
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "logout.aspx"));
        }

        public void Check_ReportTab()
        {
            if (this.objBase.ReturnRoles_Privileges_ForGrid("clients", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("purchases", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("webstoreorder", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("deliverynote", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("warehouse", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {

            }
            else
            {

            }

        }

        protected void GridView2_OnRowDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnFirstLastName");
                    HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnLastName");
                    HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnContactID");
                    AttributeCollection attributes = ((HtmlAnchor)e.Item.FindControl("Contacts")).Attributes;
                    string[] strArrays = new string[] { "javascript:SelectContact('", this.objBase.SpecialEncode(hiddenField.Value), " ", this.objBase.SpecialEncode(hiddenField1.Value), "','", hiddenField2.Value, "');" };
                    attributes.Add("onclick", string.Concat(strArrays));
                }
            }
            catch
            {
            }
        }

        public void GroupCallPurpose()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_Select_CallPurpose(this.companyID);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    row["StatusTitle"] = this.objBase.SpecialDecode(row["StatusTitle"].ToString());
                }

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    if (dataRow["Isdefault"].ToString().ToLower() != "true")
                    {
                        continue;
                    }

                }

            }
        }

        protected void lnkcategory_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/ProductCatalogueCategory.aspx?&mode=add"));
        }

        protected void lnkCostAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/othercost_add.aspx"));
        }

        protected void lnkCostView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/othercost_view.aspx"));
        }

        protected void lnkcust_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(global.sitePath(), "common/usermore.aspx"));
        }

        protected void lnkDigAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/digital_press_add.aspx"));
        }

        protected void lnkDigView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/digital_press_view.aspx"));
        }

        protected void lnkEstAddSettings_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates_add.aspx?page=Estimate&action=add"));
        }

        protected void lnkEstViewSettings_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates.aspx?page=Estimate"));
        }

        protected void lnkInvAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates_add.aspx?page=Invoice&action=add"));
        }

        protected void lnkInvView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates.aspx?page=Invoice"));
        }

        protected void lnkJobAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates_add.aspx?page=Job&action=add"));
        }

        protected void lnkJobView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates.aspx?page=Job"));
        }

        protected void lnkOffAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/litho_press_add.aspx"));
        }

        protected void lnkOffView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/litho_press_view.aspx"));
        }

        protected void lnkProdAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/ProductCatalogue_item.aspx"));
        }

        protected void lnkProdView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/PriceCatalogue.aspx"));
        }

        protected void lnkPurcAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates_add.aspx?page=Purchase&action=add"));
        }

        protected void lnkPurcView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates.aspx?page=Purchase"));
        }

        protected void lnkSupAdd_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isadd", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates_add.aspx?page=PrintBroker&action=add"));
        }

        protected void lnkSupView_OnClick(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ReturnRoles_Privileges_Tabs("settings", "isview", this.Page.Request.Url.ToString());
            base.Response.Redirect(string.Concat(global.sitePath(), "Settings/templates.aspx?page=PrintBroker"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
            DataTable _item = appSettingsAndConnectionString.Tables[0];
            foreach (DataRow dr in _item.Rows)
            {
                if (dr["IsCrmImport"].ToString() == "1")
                {

                }
                else
                {

                }
                if (Convert.ToBoolean(dr["IsJobScanning"]))
                {

                }
                else
                {

                }
            }
            if (ConnectionClass.ServerName != "smartdisplays")
            {

            }


            this.companyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.EnableAdvancedCRM = "true";
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            string str = _commonClass.Eprint_return_DateTime_Before_View_For_AlertNotifications(now.ToString(), Convert.ToInt32(base.Session["CompanyID"]), Convert.ToInt32(base.Session["userID"]), true);
            DataSet dataSet = DepartmentBaseClass.Crm_Select_Alert_Notifications(this.companyID, this.UserID, str, true);
            if (dataSet.Tables[1].Rows.Count <= 0)
            {

            }
            else
            {

            }

            this.sessionTimeout = base.Session.Timeout;
            //  Label label = this.lblLoginUser;
            string[] languageConversion = new string[] { this.objLanguage.GetLanguageConversion("Logged_In_As"), "&nbsp;", this.objBase.SpecialDecode(base.Session["firstName"].ToString()), "</b>&nbsp;", this.objBase.SpecialDecode(base.Session["lastName"].ToString()) };
            // label.Text = string.Concat(languageConversion);
            //  this.lblVersion.Text = string.Concat("<i>", this.objBase.SpecialDecode(base.Session["companyname"].ToString().Trim()), "</i> &nbsp;v", this.VersionNumber);
            // this.btnSignput.Text = this.objLanguage.GetLanguageConversion("Logout");
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = new DataTable();
                dataTable1 = EstimateBasePage.Notification_select(this.VersionNumber);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<table id='tblNotification' class='headerdialog'>");
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    string str2 = dataRow["Notification"].ToString();
                    long num = Convert.ToInt64(dataRow["NotificationID"]);
                    if (string.IsNullOrEmpty(str2) || EstimateBasePage.NoticationSeen_select(Convert.ToInt64(base.Session["userID"]), num) == -1)
                    {
                        continue;
                    }

                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td style='vertical-align:top;'> <img src='~/../../images/bullet_black.png' width='12px' height='12px' style='border: 0px solid black;'/></td>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append(str2);
                    stringBuilder.Append("</td>");
                    stringBuilder.Append("</tr>");
                }
                stringBuilder.Append("</table");
                this.hdnSessionCntr.Value = Convert.ToString(base.Session.Timeout);
            }
            this.IsAccessRight = base.Session["CustomAccessRight"].ToString().Trim().ToLower();
            if (base.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }

            this.ApplySidebarDisplayInfo();

            commonClass _commonClass1 = new commonClass();
            try
            {
                string lower = base.Session["pagename"].ToString().ToLower();
                if (Request.QueryString["ProofID"] != null)
                {
                    lower = "proofs";
                }
                string str3 = lower;
                if (lower != null)
                {
                    switch (str3)
                    {
                        case "welcome":
                            {
                                this.SelectedSection = "HOME";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "home":
                            {
                                this.SelectedSection = "HOME";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "client":
                            {
                                this.SelectedSection = "CLIENTS";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "contact":
                            {
                                this.SelectedSection = "CONTACTS";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "product":
                            {
                                this.SelectedSection = "PRODUCTS";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "campaign":
                            {
                                this.SelectedSection = "CAMPAIGN";
                                this.GetSelectedTabText = this.SelectedSection;
                                this.pg = "campaign";
                                break;
                            }
                        case "document":
                            {
                                this.SelectedSection = "DOCUMENTS";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "report":
                            {
                                this.SelectedSection = "REPORTS";
                                this.GetSelectedTabText = this.SelectedSection;
                                this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyid"]), "report");
                                break;
                            }
                        case "estimate":
                            {
                                this.SelectedSection = "ESTIMATES";
                                this.GetSelectedTabText = this.SelectedSection;
                                this.pg = "estimate";
                                break;
                            }
                        case "job":
                            {
                                this.SelectedSection = "JOBS";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "purchase":
                            {
                                this.SelectedSection = "PURCHASES";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "invoice":
                            {
                                this.SelectedSection = "Invoices";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "inventory":
                            {
                                this.SelectedSection = "INVENTORY";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "deliverynote":
                            {
                                this.SelectedSection = "DELIVERYNOTE";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "setting":
                            {
                                this.SelectedSection = "Settings";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "moretabs":
                            {
                                this.SelectedSection = "CUSTOMIZE";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "warehouse":
                            {
                                this.SelectedSection = "Warehouse";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "webstoreorder":
                            {
                                this.SelectedSection = "WebStoreorder";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "productcatalogue":
                            {
                                this.SelectedSection = "PRODUCTCATALOGUE";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "forecast":
                            {
                                this.SelectedSection = "forecast";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "proofs":
                            {
                                this.SelectedSection = "Proofs";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                        case "proof":
                            {
                                this.SelectedSection = "Proofs";
                                this.GetSelectedTabText = this.SelectedSection;
                                break;
                            }
                    }
                }
            }
            catch
            {
            }
            DataTable dataTable2 = new DataTable();
            BasePage basePage = new BasePage();
            DataSet item = new DataSet();
            try
            {
                this.tabcolor = this.objpage.colorCode(this.companyID, base.Session["pagename"].ToString().ToLower());
                this.bordercolor = this.tabcolor;
            }
            catch
            {
            }
            if (base.Session["HeaderNavigation"] != null)
            {
                item = (DataSet)base.Session["HeaderNavigation"];
                List<DataRow> toDelete = new List<DataRow>();
                DataTable dataTable = item.Tables[0];
                if (!commonClass.CheckProofPermission())
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (dr["headerName"].ToString().ToLower().Equals("proofs"))
                        {
                            toDelete.Add(dr);
                        }
                    }
                    foreach (DataRow dr in toDelete)
                    {
                        dataTable.Rows.Remove(dr);
                    }
                }
                else
                {

                }
            }
            else
            {
                item = basePage.GetHeaderimage(Convert.ToInt32(base.Session["companyID"]), Convert.ToInt32(base.Session["userID"]), this.SelectedSection, ref dataTable2, ref this.ColorCode, (int)base.Session["admin"]);
                List<DataRow> toDelete = new List<DataRow>();
                DataTable dataTable = item.Tables[0];
                if (!commonClass.CheckProofPermission())
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (dr["headerName"].ToString().ToLower().Equals("proofs"))
                        {
                            toDelete.Add(dr);
                        }
                    }
                    foreach (DataRow dr in toDelete)
                    {
                        dataTable.Rows.Remove(dr);
                    }
                }
                else
                {

                }
                base.Session["HeaderNavigation"] = item;
            }
            foreach (DataRow row1 in item.Tables[0].Rows)
            {
                if (row1["headerName"].ToString().ToLower().Contains("crm") || row1["headerName"].ToString().ToLower().Contains("clients"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("estimates") || row1["headerName"].ToString().ToLower().Contains("estimate"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("webstoreorder") || row1["headerName"].ToString().ToLower().Contains("orders"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("jobs") || row1["headerName"].ToString().ToLower().Contains("job"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("purchase") || row1["headerName"].ToString().ToLower().Contains("purchases"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("warehouse") || row1["headerName"].ToString().ToLower().Contains("inventory"))
                {


                }
                if (row1["headerName"].ToString().ToLower().Contains("invoice") || row1["headerName"].ToString().ToLower().Contains("invoices"))
                {


                }
                if (!row1["headerName"].ToString().ToLower().Contains("DeliveryNotes") && !row1["headerName"].ToString().ToLower().Contains("DeliveryNote"))
                {
                    continue;
                }


            }
            //this.upperRepeater.DataSource = item.Tables[0];
            //this.upperRepeater.DataBind();


            DataTable item1 = item.Tables[0];
            this.IsSettingTabDisplay = this.HeaderNameContains(item1, "settings") ? "true" : "false";
            this.IsReportsDisplay = this.HeaderNameContains(item1, "reports") ? "true" : "false";

            string[] strArrays = new string[] { base.Session["firstName"].ToString(), " ", base.Session["lastName"].ToString(), " (", base.Session["companyname"].ToString().Trim(), ")" };
            string str4 = string.Concat(strArrays);
            this.HiddenField1.Value = base.Session["language"].ToString();
            if (ConnectionClass.SheetFedOffset != "")
            {

            }
            if (ConnectionClass.SheetFedDigital != null)
            {

            }
            if (this.AccountingExport.ToLower() != "ae")
            {

            }
            else
            {

            }
            if (this.AccountingCode == "d")
            {

            }
            else if (this.AccountingCode != "e")
            {

            }
            else
            {

            }
            if (!string.IsNullOrEmpty(ConnectionClass.WebStore))
            {
                if (!string.Equals(ConnectionClass.WebStore.Trim(), "no", StringComparison.OrdinalIgnoreCase))
                {
                    this.IsWebstore = "yes";
                }
                else
                {
                    this.IsWebstore = "no";
                }
            }
            else if (!string.IsNullOrWhiteSpace(ConnectionClass.B2BURL))
            {
                this.IsWebstore = "yes";
            }

            string str5 = this.objBase.ReturnRoles_Privileges_ForGrid("settings", "isdisplay", this.Page.Request.Url.ToString());
            string str6 = this.objBase.ReturnRoles_Privileges_ForGrid("estore", "isdisplay", this.Page.Request.Url.ToString());
            string str7 = this.objBase.ReturnRoles_Privileges_ForGrid("reports", "isdisplay", this.Page.Request.Url.ToString());
            if (str5.Trim().ToLower() == "false")
            {
                this.MISsettingHeight = "false";

            }
            if (str6.Trim().ToLower() == "false")
            {
                this.eStoreSettingHeight = "false";
            }
            if (str5.Trim().ToLower() == "false" && str6.Trim().ToLower() == "false")
            {

            }
            if (str7.Trim().ToLower() == "false")
            {
                this.GetRolesRight_ReportIcon = "false";
            }
            if (!(str5.Trim().ToLower() == "false") || !(str6.Trim().ToLower() == "false"))
            {
                this.GetRolesRight_SettingIcon = "true";
            }
            else
            {
                this.GetRolesRight_SettingIcon = "false";
            }

            if (item != null && item.Tables.Count > 0)
            {
                this.ApplySidebarNavVisibility(item.Tables[0]);
            }

            this.Check_ReportTab();
            string str8 = SettingsBasePage.Settings_UserImage_Select((long)this.UserID);
            if (!string.IsNullOrEmpty(str8))
            {
                string str9 = str8.Trim();
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "/", this.companyID, "/UserImageCategory/t_", str9 };
                if (File.Exists(string.Concat(secureDocPath)))
                {
                    this.UserImage1 = string.Concat(this.strSitepath, "DocManager.ashx?doctype=imgcpuser&filename=t_", str9);
                }
                object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "/", this.companyID, "/UserImageCategory/m_", str9 };
                if (File.Exists(string.Concat(secureDocPath1)))
                {
                    this.UserImage2 = string.Concat(this.strSitepath, "DocManager.ashx?doctype=imgcpuser&filename=m_", str9);
                }
            }
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.TodayDate = DateTime.Today.ToString();

            try
            {
                commonClass _commonClass2 = this.commclass;
                DateTime dateTime = DateTime.Now;
                string str10 = _commonClass2.Eprint_return_DateTime_Before_View(dateTime.ToString(), Convert.ToInt32(this.companyID), Convert.ToInt32(this.UserID), false);
                string[] strArrays1 = str10.Split(new char[] { ' ' });
                this.hdntodaydate_FromHeader.Value = strArrays1[0].ToString();
                this.TodDate = this.hdntodaydate_FromHeader.Value;
                string str11 = this.commclass.Eprint_return_DateTime_Before_View_OnlyHoursandMinute(this.Createddate.ToString(), Convert.ToInt32(this.companyID), this.UserID, true);
                string[] strArrays2 = str11.Split(new char[] { ' ' });
                string[] strArrays3 = strArrays2[1].Split(new char[] { ':' });
                long num1 = Convert.ToInt64(strArrays3[0]);
                if (strArrays2[2] == "PM" && strArrays3[0] != "12")
                {
                    num1 = num1 + (long)12;
                }
                string str12 = string.Concat(num1, ":", strArrays3[1]);
                HiddenField hdnSystemDateTime = this.hdn_SystemDateTime;
                string[] strArrays4 = new string[] { strArrays2[0], " ", str12, " ", strArrays2[2] };
                hdnSystemDateTime.Value = string.Concat(strArrays4);
            }
            catch
            {
            }
        }

        protected void Repeater_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.AlternatingItem)
            {
                ListItemType itemType = e.Item.ItemType;
            }
        }

        protected void Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label label = (Label)e.Item.FindControl("lblIsSelected");
                Panel panel = (Panel)e.Item.FindControl("pnlColorFull");
                Panel panel1 = (Panel)e.Item.FindControl("pnlWhite");
                Label label1 = (Label)e.Item.FindControl("ModuleName");
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_Forecolor");
                Label label2 = (Label)e.Item.FindControl("ActiveModuleName");
                this.headerforecolor = this.objpage.Forecolor(this.companyID, label.Text.ToString().ToLower());
                this.headerforecolor = hiddenField.Value;
                label1.Text = this.objBase.SpecialDecode(label1.Text);
                label2.Style.Add("color", hiddenField.Value);
                if (this.GetSelectedTabText.ToLower() == this.SelectedSection.ToLower())
                {
                    string str = this.objpage.Select_GetActiveTabForeColor(this.companyID, this.GetSelectedTabText);
                    this.ActiveForecolor = str;
                }
                if (label.Text.Trim().ToLower() == "estimates")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "estimate")
                    {
                        this.divlistestimate = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistestimate = "black";
                    }
                    else
                    {
                        this.divlistestimate = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "clients")
                {
                    if (base.Session["pagename"] != null)
                    {


                        if (base.Session["pagename"].ToString().ToLower() == "client")
                        {
                            this.divlistcrm = hiddenField.Value;
                        }
                        else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                        {
                            this.divlistcrm = "black";
                        }
                        else
                        {
                            this.divlistcrm = this.ActiveForecolor;
                        }
                    }
                }
                if (label.Text.Trim().ToLower() == "jobs")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "job")
                    {
                        this.divlistjob = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistjob = "black";
                    }
                    else
                    {
                        this.divlistjob = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "purchases")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "purchase")
                    {
                        this.divlistpurchase = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistpurchase = "black";
                    }
                    else
                    {
                        this.divlistpurchase = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "deliverynote")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "deliverynote")
                    {
                        this.divlistdeliverynotes = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistdeliverynotes = "black";
                    }
                    else
                    {
                        this.divlistdeliverynotes = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "proofs")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "proofs")
                    {
                        this.divlistproofs = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistproofs = "white";
                    }
                    else
                    {
                        this.divlistproofs = this.ActiveForecolor;
                    }
                }

                if (label.Text.Trim().ToLower() == "invoices")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "invoice")
                    {
                        this.divlistinvoice = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistinvoice = "black";
                    }
                    else
                    {
                        this.divlistinvoice = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "warehouse")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "warehouse")
                    {
                        this.divlistinventory = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistinventory = "black";
                    }
                    else
                    {
                        this.divlistinventory = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "reports")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "report")
                    {
                        this.divlistreport = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistreport = "black";
                    }
                    else
                    {
                        this.divlistreport = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "campaign")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "campaign")
                    {
                        this.divlistcampaign = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistcampaign = "black";
                    }
                    else
                    {
                        this.divlistcampaign = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "webstoreorder")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "webstoreorder")
                    {
                        this.divlistorder = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistorder = "black";
                    }
                    else
                    {
                        this.divlistorder = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "productcatalogue")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "productcatalogue")
                    {
                        this.divlistproductcatalogue = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistproductcatalogue = "black";
                    }
                    else
                    {
                        this.divlistproductcatalogue = this.ActiveForecolor;
                    }
                }
                if (label.Text.Trim().ToLower() == "forecast")
                {
                    if (base.Session["pagename"].ToString().ToLower() == "forecast")
                    {
                        this.divlistForecast = hiddenField.Value;
                    }
                    else if (label.Text.ToLower() == this.SelectedSection.ToLower())
                    {
                        this.divlistForecast = "black";
                    }
                    else
                    {
                        this.divlistForecast = this.ActiveForecolor;
                    }
                }

                if (label.Text.Trim().ToLower() == this.SelectedSection.Trim().ToLower())
                {
                    panel.Visible = true;
                    panel1.Visible = false;
                    return;
                }
                panel.Visible = false;
                panel1.Visible = true;
            }
        }

        private void ApplySidebarDisplayInfo()
        {
            this.SidebarCompanyDisplayName = global.companyName();
            this.SidebarProductBrandTagline = global.productBrandTagline();

            string firstName = base.Session["firstName"] != null
                ? this.objBase.SpecialDecode(base.Session["firstName"].ToString()).Trim()
                : string.Empty;
            string lastName = base.Session["lastName"] != null
                ? this.objBase.SpecialDecode(base.Session["lastName"].ToString()).Trim()
                : string.Empty;
            this.SidebarUserDisplayName = (firstName + " " + lastName).Trim();
            if (string.IsNullOrEmpty(this.SidebarUserDisplayName))
            {
                this.SidebarUserDisplayName = "User";
            }

            bool isAdmin = false;
            if (base.Session["isadmin"] != null)
            {
                string adminValue = base.Session["isadmin"].ToString().Trim();
                isAdmin = adminValue == "1" || string.Equals(adminValue, "true", StringComparison.OrdinalIgnoreCase);
            }

            string adminLabel = this.objLanguage.GetLanguageConversion("Administrator");
            string userLabel = this.objLanguage.GetLanguageConversion("User");
            this.SidebarUserRoleDisplay = isAdmin
                ? (string.IsNullOrEmpty(adminLabel) ? "Administrator" : adminLabel)
                : (string.IsNullOrEmpty(userLabel) ? "User" : userLabel);

            if (string.Equals(this.SidebarCompanyDisplayName, global.ProductBrandName, StringComparison.OrdinalIgnoreCase))
            {
                this.SidebarLogoText = "P3";
            }
            else
            {
                this.SidebarLogoText = BuildLogoInitials(this.SidebarCompanyDisplayName);
            }
        }

        private static string BuildLogoInitials(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "P3";
            }

            string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                return (parts[0].Substring(0, 1) + parts[1].Substring(0, 1)).ToUpperInvariant();
            }

            return name.Length >= 2 ? name.Substring(0, 2).ToUpperInvariant() : name.ToUpperInvariant();
        }

        private void ApplySidebarNavVisibility(DataTable headerTabs)
        {
            if (headerTabs == null)
            {
                return;
            }

            if (this.phNavDashboard != null)
            {
                this.phNavDashboard.Visible = this.HeaderNameContains(headerTabs, "dashboard", "home", "welcome")
                    || headerTabs.Rows.Count > 0;
            }

            if (this.phNavCrm != null)
            {
                this.phNavCrm.Visible = this.HeaderNameContains(headerTabs, "crm", "client");
            }

            if (this.phNavEstimates != null)
            {
                this.phNavEstimates.Visible = this.HeaderNameContains(headerTabs, "estimate");
            }

            if (this.phNavOrders != null)
            {
                this.phNavOrders.Visible = this.HeaderNameContains(headerTabs, "webstoreorder", "order")
                    && !string.Equals(this.IsWebstore, "no", StringComparison.OrdinalIgnoreCase);
            }

            if (this.phNavJobs != null)
            {
                this.phNavJobs.Visible = this.HeaderNameContains(headerTabs, "job");
            }

            if (this.phNavWarehouse != null)
            {
                this.phNavWarehouse.Visible = this.HeaderNameContains(headerTabs, "warehouse", "inventory");
            }

            if (this.phNavInvoice != null)
            {
                this.phNavInvoice.Visible = this.HeaderNameContains(headerTabs, "invoice");
            }

            if (this.phNavPurchases != null)
            {
                this.phNavPurchases.Visible = this.HeaderNameContains(headerTabs, "purchase");
            }

            if (this.phNavDelivery != null)
            {
                this.phNavDelivery.Visible = this.HeaderNameContains(headerTabs, "delivery");
            }

            if (this.phNavProducts != null)
            {
                this.phNavProducts.Visible = this.HeaderNameContains(headerTabs, "product", "productcatalogue");
            }

            if (this.phNavSettings != null)
            {
                this.phNavSettings.Visible = string.Equals(this.IsSettingTabDisplay, "true", StringComparison.OrdinalIgnoreCase);
            }

            if (this.phNavStoreSettings != null)
            {
                this.phNavStoreSettings.Visible = this.ShouldShowEstoreSettingsNav(headerTabs);
            }

            bool showReports = this.ShouldShowSidebarReports();

            if (this.phNavCrmReports != null)
            {
                this.phNavCrmReports.Visible = showReports && this.phNavCrm != null && this.phNavCrm.Visible;
            }

            if (this.phNavEstimateReports != null)
            {
                this.phNavEstimateReports.Visible = showReports && this.phNavEstimates != null && this.phNavEstimates.Visible;
            }

            if (this.phNavOrderReports != null)
            {
                this.phNavOrderReports.Visible = showReports && this.phNavOrders != null && this.phNavOrders.Visible;
            }

            if (this.phNavJobReports != null)
            {
                this.phNavJobReports.Visible = showReports && this.phNavJobs != null && this.phNavJobs.Visible;
            }

            if (this.phNavInvoiceReports != null)
            {
                this.phNavInvoiceReports.Visible = showReports && this.phNavInvoice != null && this.phNavInvoice.Visible;
            }

            if (this.phNavPurchaseReports != null)
            {
                this.phNavPurchaseReports.Visible = showReports && this.phNavPurchases != null && this.phNavPurchases.Visible;
            }

            if (this.phNavDeliveryReports != null)
            {
                this.phNavDeliveryReports.Visible = showReports && this.phNavDelivery != null && this.phNavDelivery.Visible;
            }

            if (this.phNavProductReports != null)
            {
                this.phNavProductReports.Visible = showReports && this.phNavProducts != null && this.phNavProducts.Visible;
            }
        }

        /// <summary>
        /// Module report links use the same rules as legacy pages (GetTabDisplayRight + role grid),
        /// not the top-level Reports header tab flag (IsReportsDisplay).
        /// </summary>
        private bool ShouldShowSidebarReports()
        {
            if (string.Equals(this.GetRolesRight_ReportIcon, "false", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (global.GetTabDisplayRight(this.companyID, this.UserID, "REPORTS"))
            {
                return true;
            }

            return string.Equals(this.IsReportsDisplay, "true", StringComparison.OrdinalIgnoreCase);
        }

        private bool ShouldShowEstoreSettingsNav(DataTable headerTabs)
        {
            if (string.Equals(this.eStoreSettingHeight, "false", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            string estoreDisplay = this.objBase.ReturnRoles_Privileges_ForGrid("estore", "isdisplay", this.Page.Request.Url.ToString());
            if (string.Equals(estoreDisplay.Trim(), "false", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (string.Equals(this.IsWebstore, "yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (this.HeaderNameContains(headerTabs, "estore", "storesettings", "webstore"))
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(ConnectionClass.B2BURL))
            {
                return true;
            }

            return false;
        }

        private bool HeaderNameContains(DataTable headerTabs, params string[] keys)
        {
            if (headerTabs == null || keys == null || keys.Length == 0)
            {
                return false;
            }

            foreach (DataRow row in headerTabs.Rows)
            {
                string headerName = row["headerName"].ToString().ToLower();
                for (int i = 0; i < keys.Length; i++)
                {
                    if (headerName.Contains(keys[i].ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}