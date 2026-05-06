using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.Templates
{
    public partial class ResumeSession : UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string strpath;

        public int subscriptionid;

        public int loginDay;

        private int nooflogin;

        private int COMPANYID;

        private loginClass login = new loginClass();

        public string jsTimeout = string.Empty;

        public string url = string.Empty;

        public int int_MilliSecondsTimeOut;

        public int int_TimeOut;

        public string str_RedirectPage;

        private languageClass objLanguage = new languageClass();

        public string first = string.Empty;

        public string second = string.Empty;

        public string currenturl = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public ResumeSession()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.int_MilliSecondsTimeOut = 9000;
                this.int_TimeOut = 10000;
            }
            catch
            {
                this.int_MilliSecondsTimeOut = 1199000;
                this.int_TimeOut = 1200000;
            }
            try
            {
                this.str_RedirectPage = base.Session["redirectpage"].ToString().Trim();
            }
            catch
            {
                this.str_RedirectPage = "no";
            }
            try
            {
                this.first = base.Session["email"].ToString();
                this.second = base.Session["password"].ToString();
                this.url = base.Request.Url.ToString();
            }
            catch
            {
            }
        }
    }
}