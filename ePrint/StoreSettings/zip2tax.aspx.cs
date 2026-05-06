using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using Printcenter.UI.Setting;
using System.Data;
using System.Web.SessionState;

namespace ePrint.StoreSettings
{
    public partial class zip2tax : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public static int CompanyID;

        public static int UserID;

        public static long AccountID;

        public static string ZipUsername;

        public static string ZipPassword;

        public static bool Isenabled;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

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
        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            //if(zip2tax.Isenabled)
            if (hidTextBoxEnabled.Value == "true")
            {
                SettingsBasePage.Setting_Insert_ZipToTaxsettings(zip2tax.AccountID, (long)zip2tax.CompanyID, (long)zip2tax.UserID, this.chkzip2tax.Checked, false, zip2tax.ZipUsername, zip2tax.ZipPassword);
                base.Response.Redirect("zip2tax.aspx?suc=up");
            }
            else
            {
                SettingsBasePage.Setting_Insert_ZipToTaxsettings_only(zip2tax.AccountID, (long)zip2tax.CompanyID, (long)zip2tax.UserID, this.chkzip2tax.Checked, false);
                base.Response.Redirect("zip2tax.aspx?suc=up");
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/StoreSettings.aspx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CompanyID"] != null)
            {
                zip2tax.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"] != null)
            {
                zip2tax.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            this.lblzip2taxcheck.Text = "Enable Zip To Tax for this store";
            zip2tax.ZipUsername = txtUserName.Text;
            zip2tax.ZipPassword = txtPassword.Text;
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)zip2tax.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                zip2tax.AccountID = (long)Convert.ToInt32(strArrays[0]);
                string str1 = this.objBase.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display("Settings Saved Successfully", "msg-success", this.plhMessageNew);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Zip2Tax_settings")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Zip To Tax settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Zip2Tax_settings");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(zip2tax.CompanyID);
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.Setting_ZiptoTax_Select(zip2tax.AccountID, (long)zip2tax.CompanyID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.txtUserName.Text = row["ZipTaxUserName"].ToString();
                    this.txtPassword.Text = row["ZipTaxPassword"].ToString();
                    if (!Convert.ToBoolean(row["IsZip2taxEnabled"]))
                    {
                        this.chkzip2tax.Checked = false;
                    }
                    else
                    {
                        this.chkzip2tax.Checked = true;
                    }

                }
                if (dataTable.Rows.Count == 0)
                {
                    this.chkzip2tax.Checked = false;

                }
            }
        }
    }
}