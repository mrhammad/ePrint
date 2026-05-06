using nmsConnection;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class error_report : BaseClass, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected PlaceHolder plhHeader;

        //protected PlaceHolder plhFooter;

        public string strsitepath;

        public string returnURL = string.Empty;

        public int companyid;

        public string type = "both";

        public string StyleSheetPathMaster = string.Empty;

        public string StyleSheetPath = string.Empty;

        public int AccountID;

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

        public error_report()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.strsitepath = ConnectionClass.SitePath;
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                this.StyleSheetPath = string.Concat(ConnectionClass.StyleSheetPath, this.AccountID);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.StyleSheetPath, "0");
            }
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
            this.returnURL = string.Concat(this.strsitepath, "products/product.aspx");
        }
    }
}