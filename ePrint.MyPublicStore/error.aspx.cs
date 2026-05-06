using nmsConnection;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.MyPublicStore
{
    public partial class error : System.Web.UI.Page, IRequiresSessionState
    {
        //protected HtmlForm form1;

        public string strSitepath = string.Empty;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public error()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
        }
    }
}