using nmsCommon;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;

namespace ePrint.usercontrol.settings
{
    public partial class Loading : System.Web.UI.UserControl
    {

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

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

        public Loading()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}