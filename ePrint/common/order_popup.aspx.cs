using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.common
{
    public partial class order_popup : BaseClass, IRequiresSessionState
    {
        private string module = string.Empty;

        public string type;

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

        public order_popup()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["module"] != null)
            {
                this.module = base.Request.Params["module"].ToString();
            }
            global.pgName = this.module;
            this.gloobj.setpagename(this.module);
            base.Title = this.objLanguage.convert(global.pageTitle("Product List", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}