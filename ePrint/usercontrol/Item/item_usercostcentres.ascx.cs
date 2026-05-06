using nmsCommon;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class item_usercostcentres : System.Web.UI.UserControl
    {
        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int rowcount;

        public long CatID;

        public string OtherCostValues = string.Empty;

        public string WinOpenType = string.Empty;

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

        public item_usercostcentres()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = int.Parse(base.Session["companyid"].ToString());
        }
    }
}