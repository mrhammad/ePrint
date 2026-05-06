using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.StoreSettings
{
    public partial class eStoreReports : BaseClass, IRequiresSessionState
    {
        public static int CompanyID;

        private Global gloobj = new Global();

        public static int UserID;

        public static int AccountID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private BaseClass objBase = new BaseClass();

        public string AccountType = string.Empty;

        public string Type = string.Empty;

        public string strSitepath = global.sitePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public DataTable dt = new DataTable();

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

        static eStoreReports()
        {
        }

        public eStoreReports()
        {
        }

        protected void btnSave_Click(object o, EventArgs e)
        {
            string empty = string.Empty;
            if (this.rdoMainApprover.Checked)
            {
                empty = "M";
            }
            else if (this.rdoMainDeptApprover.Checked)
            {
                empty = "D";
            }
            else if (this.rdoAllUsers.Checked)
            {
                empty = "A";
            }
            SettingsBasePage.Setting_eStoreReports_InsertUpdate(this.chkEnableReports.Checked, empty, eStoreReports.AccountID, eStoreReports.CompanyID);
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/eStoreReports.aspx?suc=up"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"].ToString() != null)
            {
                eStoreReports.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"].ToString() != null)
            {
                eStoreReports.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Estore Reports setting saved successfully", "msg-success", this.plhMessage);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)eStoreReports.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                eStoreReports.AccountID = Convert.ToInt32(strArrays[0]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/eStoreSpendLimit.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Reports")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("eStore Reports", eStoreReports.CompanyID, this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Reports");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(eStoreReports.CompanyID);
            this.chkEnableReports.Text = this.objLanguage.GetLanguageConversion("Enable_End_User_Reports");
            this.rdoMainApprover.Text = this.objLanguage.GetLanguageConversion("Main_Approvers_and_Main_Contacts_Only");
            this.rdoMainDeptApprover.Text = this.objLanguage.GetLanguageConversion("Main_and_Department_Approvers");
            this.rdoAllUsers.Text = this.objLanguage.GetLanguageConversion("All_Users");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            if (!base.IsPostBack)
            {
                this.dt = SettingsBasePage.Setting_eStoreReports_Select(eStoreReports.AccountID, eStoreReports.CompanyID);
                foreach (DataRow row in this.dt.Rows)
                {
                    if (row["IsEnabled"].ToString() != "True")
                    {
                        this.chkEnableReports.Checked = false;
                    }
                    else
                    {
                        this.chkEnableReports.Checked = true;
                        this.rdoMainApprover.Enabled = true;
                        this.rdoMainDeptApprover.Enabled = true;
                        this.rdoAllUsers.Enabled = true;
                        if (row["usertype"].ToString() == "M")
                        {
                            this.rdoMainApprover.Checked = true;
                        }
                        else if (row["usertype"].ToString() != "D")
                        {
                            if (row["usertype"].ToString() != "A")
                            {
                                continue;
                            }
                            this.rdoAllUsers.Checked = true;
                        }
                        else
                        {
                            this.rdoMainDeptApprover.Checked = true;
                        }
                    }
                }
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisableOnLoad();", true);
            }
        }
    }
}