using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
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
    public partial class estore_email_settings : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private languageClass objLanguage = new languageClass();

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        public int CompanyID;

        public int UserID;

        public int EmailSettingID;

        public int AccountId;

        private string EmailSettingType = string.Empty;

        public languageClass objlang = new languageClass();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

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

        public estore_email_settings()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SettingsBasePage.Save_Estore_EmailSetting(this.EmailSettingID, this.AccountId, this.CompanyID, base.SpecialEncode(this.hdnAdminTo.Value), base.SpecialEncode(this.hdnAdminCc.Value), base.SpecialEncode(this.hdnAdminBcc.Value), "", "", "");
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/estore_email_settings.aspx?suc=add"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ref1.Title = this.objLanguage.GetLanguageConversion("Multiple_Emali_Address_Note");
            this.ref2.Title = this.objLanguage.GetLanguageConversion("Multiple_Emali_Address_Note");
            this.ref3.Title = this.objLanguage.GetLanguageConversion("Multiple_Emali_Address_Note");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Email Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString() == "add")
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Email_Settings_Saved_Successfully"), "msg-success", this.plhMessage);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountId = Convert.ToInt32(strArrays[0]);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Email_Settings")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Email Settings", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Email_Settings");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            DataTable emailForSetting = SettingsBasePage.getEmailForSetting(this.AccountId);
            if (emailForSetting.Rows.Count > 0)
            {
                this.txt_Admin_To.Text = base.SpecialDecode(emailForSetting.Rows[0]["AdminTo"].ToString());
                this.txt_Admin_CC.Text = base.SpecialDecode(emailForSetting.Rows[0]["AdminCc"].ToString());
                this.txt_Admin_BCC.Text = base.SpecialDecode(emailForSetting.Rows[0]["AdminBcc"].ToString());
            }
        }
    }
}