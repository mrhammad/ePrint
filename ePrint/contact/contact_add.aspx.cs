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

namespace ePrint.contact
{
    public partial class contact_add : BaseClass, IRequiresSessionState
    {

        private Global gloobj = new Global();

        public languageClass objLanguage = new languageClass();

        public int CompanyID;

        public int UserID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string newdate = string.Empty;

        public string DateFormat = string.Empty;

        public string CustomerName = string.Empty;

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

        public contact_add()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "client";
            global.pgName = "";
            this.gloobj.setpagename("client");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            BaseClass baseClass = new BaseClass();
            if (base.Request.Params["CustomerName"] != null)
            {
                this.CustomerName = baseClass.SpecialDecode(base.Request.Params["CustomerName"].ToString());
                if (base.Request.Params["action"] == null)
                {
                    base.Title = string.Concat(this.CustomerName, ":  Add New Contact");
                }
                else
                {
                    base.Title = string.Concat(this.CustomerName, ":  Edit Contact");
                }
            }
            else if (base.Request.Params["action"] == null)
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Add New Contact", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            else
            {
                base.Title = this.objLanguage.convert(global.pageTitle("Edit Contact", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            }
            this.DateFormat = this.objpage.GetRegionalSettings(this.CompanyID, "Dateformat");
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(base.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
        }
    }
}