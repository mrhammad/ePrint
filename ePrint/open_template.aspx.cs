using nmsCommon;
using nmsConnectionClass;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint
{
    public partial class open_template : System.Web.UI.Page, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string securesitepath = global.SecureSitePath();

        public string ServerName = string.Empty;

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

        public open_template()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (ConnectionClass.ServerName != null)
                {
                    this.ServerName = ConnectionClass.ServerName;
                }
                string str = base.Request.Params["tempname"].ToString().Trim();
                string str1 = base.Request.Params["CID"].ToString().Trim();
                if (str1 != null)
                {
                    string[] serverName = new string[] { this.securesitepath, this.ServerName, "/", str1, "/sentpdf/", str };
                    string str2 = string.Concat(serverName);
                    base.Response.Redirect(string.Concat(str2, "#zoom=100"));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "tempattachment/", base.Request.Params["tempname"].ToString().Trim(), "#zoom=100"));
            }
        }
    }
}