using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.Estimates
{
    public partial class artwork_files_upload_0 : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strDownLoad = string.Empty;

        private Global gloobj = new Global();

        public static int n;

        public string QueryType = string.Empty;

        public static StringBuilder strbuild;

        public languageClass objLanguage = new languageClass();

        public string ServerName = string.Empty;

        public string pg = string.Empty;

        public long EstimateID;

        public long JobID;

        public long InvoiceID;

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

        static artwork_files_upload_0()
        {
            artwork_files_upload_0.n = 3;
            artwork_files_upload_0.strbuild = new StringBuilder();
        }

        public artwork_files_upload_0()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString().ToLower();
            }
            if (Convert.ToUInt64(base.Request.Params["EstimateID"].ToString()) != (long)0)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"].ToString());
            }
            if (Convert.ToUInt64(base.Request.Params["JobID"].ToString()) != (long)0)
            {
                this.JobID = Convert.ToInt64(base.Request.Params["JobID"].ToString());
            }
            if (Convert.ToUInt64(base.Request.Params["InvoiceID"].ToString()) != (long)0)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvoiceID"].ToString());
            }
            this.btn_AllowMore.Text = this.objLanguage.GetLanguageConversion("Add_More");
            this.btnDone.Text = this.objLanguage.GetLanguageConversion("Upload");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            string[] secureDocPath = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.Session["CompanyID"].ToString(), "//attachments" };
            if (!Directory.Exists(string.Concat(secureDocPath)))
            {
                string[] strArrays = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.Session["CompanyID"].ToString(), "//attachments" };
                Directory.CreateDirectory(string.Concat(strArrays));
            }
            if (base.Request.QueryString["pagetype"] != null)
            {
                this.QueryType = base.Request.QueryString["pagetype"].ToString().Trim();
            }
            this.gloobj.setpagename(base.Request.QueryString["pg"].ToLower());
            string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/attachments/" };
            this.strDownLoad = string.Concat(secureSitePath);
        }
    }
}