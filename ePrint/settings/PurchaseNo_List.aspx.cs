using nmsCommon;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.settings
{
    public partial class PurchaseNo_List : System.Web.UI.Page, IRequiresSessionState
    {
        ////protected usercontrol_CallClass usrCallclass;

        ////protected usercontrol_StoreSettings_PriceCatalogue_CustomerNames ucCustomerName;

        public languageClass objLanguage = new languageClass();

        public string strImagepath;

        public int companyId;

        public string sectionname = string.Empty;

        private Global gloobj = new Global();

        public string EstimateID = string.Empty;

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

        public PurchaseNo_List()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = this.Session["pagename"].ToString();
            this.gloobj.setpagename(this.Session["pagename"].ToString());
            base.Title = this.objLanguage.convert(global.pageTitle(this.objLanguage.GetLanguageConversion("Purchase_No"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (base.Request.QueryString["EstimateID"] == null)
            {
                this.ucCustomerName.EstimateID = (long)-100;
                return;
            }
            this.ucCustomerName.EstimateID = Convert.ToInt64(base.Request.QueryString["EstimateID"]);
        }
    }
}