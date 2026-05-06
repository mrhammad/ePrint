using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.common
{
    public partial class Common_inventory_popup : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected PlaceHolder plhDiv;

        public string type;

        public string VersionNumber = ConnectionClass.VersionNumber;
        public string strSitePath = global.sitePath();
        public languageClass objLanguage = new languageClass();

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

        public Common_inventory_popup()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pgName = "";
            try
            {
                this.type = base.Request.QueryString["type"].ToString();
            }
            catch
            {
            }
            if (this.type == "invselector")
            {
                this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
                base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.Request.Params["item"].ToString(), "&nbsp;Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                UserControl userControl = (UserControl)base.LoadControl("~/usercontrol/warehouse/Inventory_popup.ascx");
                this.plhDiv.Controls.Add(userControl);
            }
        }
    }
}
    