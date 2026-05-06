using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.StoreSettings
{
    public partial class registration_option : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public static int CompanyID;

        public static int UserID;

        public static long AccountID;

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        public languageClass objLanguage = new languageClass();

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

        static registration_option()
        {
        }

        public registration_option()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("setting");
            if (this.Session["CompanyID"].ToString() != null)
            {
                registration_option.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            }
            if (this.Session["UserID"].ToString() != null)
            {
                registration_option.UserID = Convert.ToInt32(this.Session["USerID"].ToString());
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("registration_option")));
            base.Title = this.objLanguage.convert(global.pageTitle("Registration Option", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Registration_Option");
            this.header.dtAccountList = this.objAcc.AccountsListforApprovalSystem(registration_option.CompanyID);
        }
    }
}