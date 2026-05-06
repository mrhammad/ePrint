using nmsCommon;
using nmsLanguage;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint
{
    public partial class home_leftpanel : System.Web.UI.UserControl
    {
        public languageClass objlang = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int height = 55;

        public string IsHome = string.Empty;

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

        public home_leftpanel()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().Contains("common/task_detail"))
            {
                this.litask.Visible = true;
                this.lievent.Visible = true;
                this.lihome.Visible = true;
                this.height = 85;
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/task_edit"))
            {
                this.litask.Visible = true;
                this.lievent.Visible = true;
                this.lihome.Visible = true;
                this.height = 85;
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/task"))
            {
                this.litask.Visible = false;
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/event_edit") || base.Request.Url.ToString().ToLower().Contains("common/event_detail") || base.Request.Url.ToString().ToLower().Contains("common/event_dayview") || base.Request.Url.ToString().ToLower().Contains("common/event_weekview") || base.Request.Url.ToString().ToLower().Contains("common/event_monthview") || base.Request.Url.ToString().ToLower().Contains("common/event_allview"))
            {
                this.lievent.Visible = true;
                this.litask.Visible = true;
                this.lihome.Visible = true;
                this.height = 85;
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("common/event"))
            {
                this.lievent.Visible = false;
                return;
            }
            if (base.Request.Url.ToString().ToLower().Contains("welcome"))
            {
                this.lihome.Visible = false;
                this.IsHome = "true";
            }
        }
    }
}