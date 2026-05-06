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
    public partial class EnableTracking : BaseClass, IRequiresSessionState
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

        static EnableTracking()
        {
        }

        public EnableTracking()
        {
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (this.chksecurity.Checked)
            {
                flag = true;
            }
            SettingsBasePage.Setting_Insert_PublicttrackingSettings(EnableTracking.AccountID, (long)EnableTracking.CompanyID, (long)EnableTracking.UserID, this.txtsecurity.Text, flag);
            base.Response.Redirect("EnableTracking.aspx?suc=up");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"].ToString() != null)
            {
                EnableTracking.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"].ToString() != null)
            {
                EnableTracking.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)EnableTracking.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                EnableTracking.AccountID = (long)Convert.ToInt32(strArrays[0]);
                base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("TrackingSettings")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Enable Tracking", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("TrackingSettings");
            this.header.dtAccountList = this.objAcc.PublicAccountsListforApprovalSystem(EnableTracking.CompanyID);
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.Setting_PublicLogoutSettings_Select(EnableTracking.AccountID, (long)EnableTracking.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.chksecurity.Checked = Convert.ToBoolean(row["IsEnableTracking"]);
                    if (!this.chksecurity.Checked)
                    {
                        this.txtsecurity.Text = "";
                    }
                    else
                    {
                        this.txtsecurity.Text = row["SecretCode"].ToString();
                    }
                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chksecurity.Checked = false;
                }
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "javascript:EnableDisable();", true);
        }
    }
}