using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
namespace ePrint.common
{
    public partial class Client_add_new : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        public languageClass objLanguage = new languageClass();

        private BaseClass basecls = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private BasePage comnbasepage = new BasePage();

        public commonClass comncls = new commonClass();

        public int CompanyID;

        public int UserID;

        public string DateFormat = string.Empty;

        public string companytype = string.Empty;

        public int ClientID;

        private int isnew = 2;

        public string newdate = string.Empty;

        public string action = string.Empty;

        public string postback = string.Empty;

        public string mode = string.Empty;

        public string id = string.Empty;

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

        public Client_add_new()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "client";
            global.pgName = "";
            this.gloobj.setpagename("client");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Add New Company", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.DateFormat = this.Session["DateFormat"].ToString();
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
        }
    }
}