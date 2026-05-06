using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.StoreSettings
{
    public partial class Phrase_Book : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        public string strSitepath = global.sitePath();

        private AccountsBaseClass objAccnt = new AccountsBaseClass();

        public int CompanyID;

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

        public Phrase_Book()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "setting";
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("eStore_Phrasebook")));
            base.Title = this.objLanguage.convert(global.pageTitle("eStore Phrasebook", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.header.SettingName = this.objLanguage.GetLanguageConversion("eStore_Phrasebook");
            this.header.dtAccountList = this.objAccnt.accountsList(this.CompanyID);
        }
    }
}