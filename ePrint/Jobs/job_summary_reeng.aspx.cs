using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.Jobs
{
    public partial class job_summary_reeng : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        private commonClass commclass = new commonClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

        public static string Ispaidenable;

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

        static job_summary_reeng()
        {
            job_summary_reeng.Ispaidenable = string.Empty;
        }

        public job_summary_reeng()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.objBC.ReturnRoles_Privileges_Tabs("jobs", "isview", "");
            global.pageName = "job";
            this.pg = "job";
            this.gloobj.setpagename("job");
            job_summary_reeng.Ispaidenable = ConnectionClass.IsPaymentEnable.ToString();
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            languageClass _languageClass = new languageClass();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Job_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Job_Summary")));
            base.Title = _languageClass.convert(global.pageTitle("Job Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}