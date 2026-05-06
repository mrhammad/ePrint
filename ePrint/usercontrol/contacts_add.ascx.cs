using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ePrint.usercontrol
{
    public partial class contacts_add : System.Web.UI.UserControl
    {
        public string mode = string.Empty;

        public string pg = string.Empty;

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

        public contacts_add()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.mode = base.Request.QueryString["mode"].ToString();
            this.pg = base.Request.QueryString["pg"].ToString();
        }
    }
}