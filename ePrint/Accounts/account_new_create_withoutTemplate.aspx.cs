using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.Account
{
    public partial class account_new_create_withoutTemplate : System.Web.UI.Page, IRequiresSessionState
    {
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

        public account_new_create_withoutTemplate()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
