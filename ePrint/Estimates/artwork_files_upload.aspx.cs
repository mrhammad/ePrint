using nmsCommon;
using nmsConnectionClass;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.UI.Estimates;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.Estimates
{
    public partial class artwork_files_upload : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        public string strNum = string.Empty;

        public string file_name = string.Empty;

        public string strDownLoad = string.Empty;

        public string ServerName = string.Empty;

        public string pg = string.Empty;

        public long AttachmentID;

        public BaseClass objBase = new BaseClass();

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

        public artwork_files_upload()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            long num = (long)0;
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString().ToLower();
            }
            if (Convert.ToUInt64(base.Request.Params["EstimateID"].ToString()) != (long)0)
            {
                num = Convert.ToInt64(base.Request.Params["EstimateID"].ToString());
            }
            if (Convert.ToUInt64(base.Request.Params["JobID"].ToString()) != (long)0)
            {
                num = Convert.ToInt64(base.Request.Params["JobID"].ToString());
            }
            if (Convert.ToUInt64(base.Request.Params["InvoiceID"].ToString()) != (long)0)
            {
                num = Convert.ToInt64(base.Request.Params["InvoiceID"].ToString());
            }
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
            string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/attachments/" };
            this.strDownLoad = string.Concat(secureSitePath);
            this.strNum = base.Request.Params["s"].ToString();
            HttpPostedFile item = base.Request.Files[0];
            int contentLength = item.ContentLength;
            string[] strArrays1 = item.FileName.Split(new char[] { '\\' });
            string str = base.GenPassWithCap(15);
            this.file_name = string.Concat(str, "_", strArrays1[(int)strArrays1.Length - 1].ToString().Replace(" ", "_"));
            string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this.Session["CompanyID"].ToString(), "/attachments/" };
            string str1 = string.Concat(secureDocPath1);
            this.file_name = (this.file_name.Length > 244 ? string.Concat(str, this.file_name.Substring(17, 20)) : this.file_name);
            item.SaveAs(string.Concat(str1, this.file_name));
            EstimateItem estimateItem = new EstimateItem()
            {
                CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString()),
                AttachmentID = this.AttachmentID,
                EstimateID = num,
                UploadedBy = Convert.ToInt32(this.Session["UserID"].ToString()),
                FileName = this.objBase.ReplaceSingleQuote(this.file_name),
                ModuleType = this.pg,
                IsDisplayToEstore = false,
                AttachmentType = "O",
                OriginalFileName = item.FileName
            };
            EstimateBasePage.etimates_attachment_insert(estimateItem);
            this.pnlTest.Visible = true;
        }
    }
}