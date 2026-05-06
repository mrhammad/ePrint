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
    public partial class LogoutSettings : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public static int CompanyID;

        public static int UserID;

        public static long AccountID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        private BaseClass objBase = new BaseClass();

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

        static LogoutSettings()
        {
        }

        public LogoutSettings()
        {
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.rdocustomlogout.Checked)
            {
                flag = true;
            }
            SettingsBasePage.Setting_Insert_PublicLogoutSettings(LogoutSettings.AccountID, (long)LogoutSettings.CompanyID, (long)LogoutSettings.UserID, this.txtCustomURL.Text, flag, this.chkloginoption.Checked);
            base.Response.Redirect("LogoutSettings.aspx?suc=up");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"].ToString() != null)
            {
                LogoutSettings.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"].ToString() != null)
            {
                LogoutSettings.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)LogoutSettings.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                LogoutSettings.AccountID = (long)Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("LogoutSettings")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Logout Options", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("LogoutSettings");
            this.header.dtAccountList = this.objAcc.PublicAccountsListforApprovalSystem(LogoutSettings.CompanyID);
            this.lbllogoutoption.Text = "Force user to login before accessing products section";
            this.lbllogin.Text = "Redirect user to default page";
            this.lblCustomUrl.Text = "Redirect to a different page";
            this.lblnote.Text = "[please note this option is applicable to public store only]";
            this.lbllogutmsg.Text = "enter the full URL prefixed with http:// or https://";
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.Setting_PublicLogoutSettings_Select(LogoutSettings.AccountID, (long)LogoutSettings.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.chkloginoption.Checked = Convert.ToBoolean(row["IsForceUser"]);
                    if (Convert.ToBoolean(row["IsCustomLogout"]))
                    {
                        this.rdologout.Checked = false;
                        this.rdocustomlogout.Checked = true;
                        this.txtCustomURL.Enabled = true;
                        this.txtCustomURL.Text = row["ReDirectURL"].ToString();
                    }
                    else
                    {
                        this.rdologout.Checked = true;
                        this.rdocustomlogout.Checked = false;
                        this.txtCustomURL.Enabled = false;
                        this.txtCustomURL.Text = "";
                    }
                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chkloginoption.Checked = false;
                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable();", true);
        }
    }
}