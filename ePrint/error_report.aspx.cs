using nmsCommon;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint
{
    public partial class error_report : BaseClass, IRequiresSessionState
    {
        public string strsitepath;

        public string returnURL = string.Empty;

        public string strCompany = global.companyName();

        private BasePage objpage = new BasePage();

        public int companyid;

        public string type = "both";

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

        public error_report()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.strsitepath = global.sitePath();
            if (base.Request.Params["returnUrl"] == null)
            {
                this.returnURL = string.Concat(this.strsitepath, "error.aspx");
            }
            else if (!base.Request.Params["returnUrl"].ToString().Contains("error_report.aspx"))
            {
                this.returnURL = Convert.ToString(base.Request.Params["returnUrl"]);
                this.Session["returnUrl"] = Convert.ToString(base.Request.Params["returnUrl"]);
            }
            else
            {
                this.returnURL = Convert.ToString(this.Session["returnUrl"]);
            }
            this.returnURL = string.Concat(this.strsitepath, "welcome.aspx");
            this.objpage.logoSetting(this.plhHeader, this.plhFooter, this.companyid, this.type);
        }
    }
}