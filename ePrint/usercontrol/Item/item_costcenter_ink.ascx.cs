using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_costcenter_ink : System.Web.UI.UserControl
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

        public item_costcenter_ink()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}