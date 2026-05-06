using nmsCommon;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_reportsList : UsercontrolBasePage
    {
        public string strpath;

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

        public item_reportsList()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "jobs";
            global.pgName = "";
            this.strpath = global.sitePath();
        }
    }
}