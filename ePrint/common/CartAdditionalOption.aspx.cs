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
    public partial class CartAdditionalOption : System.Web.UI.Page, IRequiresSessionState
    {
        public languageClass objLanguage = new languageClass();

        public string strImagepath;

        public int companyId;

        private Global gloobj = new Global();

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

        public CartAdditionalOption()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pgName = "";
            global.pageName = this.Session["pagename"].ToString();
            this.gloobj.setpagename(this.Session["pagename"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle("Edit Cart Additional", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}