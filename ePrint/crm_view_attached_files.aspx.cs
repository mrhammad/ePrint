using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Department;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint
{
    public partial class crm_view_attached_files : BaseClass, IRequiresSessionState
    {
        public int CompanyID;

        public int AttachedID;

        public string path = string.Empty;

        public string SecureDocPath = string.Empty;

        public string ServerName = string.Empty;

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

        public crm_view_attached_files()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.SecureDocPath = global.SecureDocPath();
                this.ServerName = ConnectionClass.ServerName;
                if (base.Request.QueryString["CID"] != null && base.Request.QueryString["CID"].ToString() != "")
                {
                    this.CompanyID = Convert.ToInt16(base.Request.QueryString["CID"].ToString());
                }
                if (base.Request.QueryString["AID"] != null && base.Request.QueryString["AID"].ToString() != "")
                {
                    this.AttachedID = Convert.ToInt16(base.Request.QueryString["AID"].ToString());
                }
                DataSet dataSet = DepartmentBaseClass.CRM_Select_AttachedFileName(this.AttachedID);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        string str = row["fileName"].ToString();
                        if (string.IsNullOrEmpty(str))
                        {
                            continue;
                        }
                        object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "/", this.CompanyID, "/attachments/", str };
                        this.path = string.Concat(secureDocPath);
                    }
                }
                if (File.Exists(this.path))
                {
                    FileInfo fileInfo = new FileInfo(this.path);
                    File.ReadAllBytes(this.path);
                    this.Context.Response.StatusCode = 200;
                    this.Context.Response.ContentType = "application/octet-stream";
                    this.Context.Response.Buffer = true;
                    this.Context.Response.Clear();
                    this.Context.Response.AddHeader("content-disposition", string.Concat("attachment;filename=\"", fileInfo.Name, "\""));
                    this.Context.Response.TransmitFile(this.path);
                    this.Context.Response.End();
                    this.Context.Response.Flush();
                }
            }
            catch
            {
            }
        }
    }
}