using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.settings
{
    public partial class settings_mis_headerpanel : UsercontrolBasePage
    {
        //protected Label lblSettingName;

        public string SettingName = string.Empty;

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

        public settings_mis_headerpanel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblSettingName.Text = this.SettingName;
        }
    }
}