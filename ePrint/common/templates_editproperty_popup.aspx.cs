using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.common
{
    public partial class templates_editproperty_popup : BaseClass, IRequiresSessionState
    {

        public languageClass objlang = new languageClass();

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

        public templates_editproperty_popup()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new Global()).setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Settings: Templates", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}