using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint
{
    public partial class pdf : System.Web.UI.Page, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public languageClass objLanguage = new languageClass();

        public string PdfPath = string.Empty;

        public string TemplateName = string.Empty;

        public string CompanyID = string.Empty;

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

        public pdf()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string str = base.Request.Params["key"].ToString().Trim();
                if (str != "")
                {
                    this.TemplateName = SettingsBasePage.settings_template_emailed_select(str);
                    this.CompanyID = SettingsBasePage.settings_template_emailed_select_CompanyID(str);
                }
            }
        }
    }
}