using nmsCommon;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_addnew_costcentre : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public commonClass commclass = new commonClass();

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

        public item_addnew_costcentre()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "Estimate";
            global.pgName = "";
        }
    }
}