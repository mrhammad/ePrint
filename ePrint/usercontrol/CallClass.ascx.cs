using nmsCommon;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol
{
    public partial class CallClass : System.Web.UI.UserControl
    {

        public BasePage objpage = new BasePage();

        public BaseClass objBase = new BaseClass();

        public string forecolor = "";

        public string tabcolor = string.Empty;

        public int companyid;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

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

        public CallClass()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.companyid = int.Parse(base.Session["companyID"].ToString());
            try
            {
                this.forecolor = this.objpage.Forecolor(this.companyid, base.Session["pagename"].ToString());
                this.tabcolor = this.objpage.colorCode(this.companyid, base.Session["pagename"].ToString());
                this.objBase.CallStyle(this.plhStyle, this.tabcolor, this.forecolor);
            }
            catch
            {
            }
        }
    }
}