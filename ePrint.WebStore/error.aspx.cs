using nmsConnection;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.WebStore
{
    public partial class error : System.Web.UI.Page, IRequiresSessionState
    {
        protected HtmlForm form1;

        public string strSitepath = string.Empty;

        public string StyleSheetPathMaster = string.Empty;

        public string StyleSheetPath = string.Empty;

        private string AccountID = "0";

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
            if (ConnectionClass.AccountID == null || !(ConnectionClass.AccountID != ""))
            {
                this.AccountID = "0";
            }
            else
            {
                this.AccountID = Convert.ToString(ConnectionClass.AccountID);
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                this.StyleSheetPath = string.Concat(ConnectionClass.StyleSheetPath, this.AccountID);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.StyleSheetPath, "0");
            }
        }
    }
}