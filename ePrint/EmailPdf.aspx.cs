using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Estimates;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ePrint
{
    public partial class EmailPdf : System.Web.UI.Page, IRequiresSessionState
    {
        private long AccountID;

        public string SecureDocFilepath = global.SecureDocFilepath();

        public string ServerName = ConnectionClass.ServerName;

        public string SecureSitePath = global.SecureSitePath();

        public string CompanyID = string.Empty;

        public string FileName = string.Empty;

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

        public EmailPdf()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["File"].ToString() != "")
            {
                if (this.Session["CompanyID"] != null)
                {
                    this.CompanyID = this.Session["CompanyID"].ToString();
                }
                if (base.Request.Params["AccountName"] != null)
                {
                    DataTable dataTable = new DataTable();
                    dataTable = EstimateBasePage.AccountInfo_FrontEnd(base.Request.Params["AccountName"].ToString());
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                        }
                    }
                    this.FileName = base.Request.Params["File"].ToString();
                    ClientScriptManager clientScript = base.ClientScript;
                    Type type = this.Page.GetType();
                    object[] fileName = new object[] { "javascript:Pdf_OpenFromEmail(\"", this.FileName, "\",", this.AccountID, ");" };
                    clientScript.RegisterStartupScript(type, "OnLoad", string.Concat(fileName), true);
                    return;
                }
                this.AccountID = (long)Convert.ToInt32(base.Request.Params["Account"]);
                this.FileName = base.Request.Params["File"].ToString();
                ClientScriptManager clientScriptManager = base.ClientScript;
                Type type1 = this.Page.GetType();
                object[] objArray = new object[] { "javascript:Pdf_OpenFromEmail(\"", this.FileName, "\",", this.AccountID, ");" };
                clientScriptManager.RegisterStartupScript(type1, "OnLoad", string.Concat(objArray), true);
            }
        }
    }
}