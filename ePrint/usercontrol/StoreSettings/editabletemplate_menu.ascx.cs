using nmsCommon;
using nmsLanguage;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint.usercontrol.StoreSettings
{
    public partial class editabletemplate_menu : System.Web.UI.UserControl
    {
        public string strImagepath = global.imagePath();

        public languageClass objLanguage = new languageClass();

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

        public editabletemplate_menu()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}