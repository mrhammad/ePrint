using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.settings
{
    public partial class EstoreReports_AllocatedCustomers : System.Web.UI.Page, IRequiresSessionState
    {
        //protected usercontrol_callclass_ascx usrCallclass;

        //protected usercontrol_storesettings_estorereports_allocatedcustomers_ascx ucCustomerName;

        public languageClass objLanguage = new languageClass();

        public string strImagepath;

        public int companyId;

        public string sectionname = string.Empty;

        private Global gloobj = new Global();

        public string From = string.Empty;

        public string ReportID = string.Empty;

        public string ReportName = string.Empty;

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

        public EstoreReports_AllocatedCustomers()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = this.Session["pagename"].ToString();
            this.gloobj.setpagename(this.Session["pagename"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Estore_Reports_Allocated_Customers"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (base.Request.QueryString["From"] != null)
            {
                this.ucCustomerName.From = base.Request.QueryString["From"].ToString();
            }
            if (base.Request.QueryString["ReportID"] == null)
            {
                this.ucCustomerName.ReportID = (long)-100;
            }
            else
            {
                this.ucCustomerName.ReportID = Convert.ToInt64(base.Request.QueryString["ReportID"]);
            }
            if (base.Request.QueryString["ReportName"] != null)
            {
                this.ucCustomerName.ReportName = base.Request.QueryString["ReportName"].ToString();
            }
            if (base.Request.QueryString["ModuleType"] != null)
            {
                this.ucCustomerName.ModuleName = base.Request.QueryString["ModuleType"].ToString();
            }
        }
    }
}