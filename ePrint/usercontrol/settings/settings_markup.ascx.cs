using nmsCommon;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.settings
{
    public partial class settings_markup : System.Web.UI.UserControl
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string page = string.Empty;

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

        public settings_markup()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["page"] != null)
            {
                this.page = base.Request.Params["page"].ToString().ToLower();
                if (this.page == "edit")
                {
                    this.lblheader.Text = "Settings:&nbsp;Edit System Markup";
                    this.btnDelete.Visible = true;
                    this.btnAdd.Visible = true;
                    return;
                }
                this.lblheader.Text = "Settings:&nbsp;Add System Markup";
                this.btnDelete.Visible = false;
                this.btnAdd.Visible = false;
            }
        }
    }
}