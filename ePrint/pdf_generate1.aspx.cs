using com.lowagie.text;
using com.lowagie.text.pdf;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class pdf_generate1 : BaseClass, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected HiddenField hdnPdf;

        //protected HiddenField hdnisSplit;

        //protected HiddenField hdnisKeepWithPrevious;

        //protected LinkButton lnkPdf;

        //protected Panel pnl_hideLoad;

        //protected HtmlForm form1;

        public long EstimateID;

        public long jobID;

        public long InvoiceID;

        public long temp_ordid;

        public long OrdID;

        public long TemplateID;

        public long EstimateItemID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        public string SelectedItems = string.Empty;

        public string IsFrom = string.Empty;

        public string isdirect = string.Empty;

        public string PageType = string.Empty;

        public string PDFKey = string.Empty;

        public bool RetRefforPDFVisible;

        public long CompanyID;

        public long UserID;

        public string customType = string.Empty;

        public string filename = string.Empty;

        private pdfGenerate GenratePDF = new pdfGenerate();

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

        public pdf_generate1()
        {
        }

        protected void lnkPdf_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat("tempattachment\\", this.GenratePDF.hdnPdf, "#zoom=100"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = (long)Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.GenratePDF.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.GenratePDF.jobID);
            }
            if (this.GenratePDF.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.GenratePDF.InvoiceID);
            }
            if (string.IsNullOrEmpty(this.GenratePDF.PageType))
            {
                this.PageType = base.Request.Params["page"].ToString();
                this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstID"]);
                this.PDFKey = base.SpecialEncode(base.Request.Params["key"].ToString());
            }
            if (base.Request.Params["From"] != null && base.Request.Params["From"] != "")
            {
                this.IsFrom = base.Request.Params["From"].ToString();
            }
            if (base.Request.Params["isdirect"] != null && base.Request.Params["isdirect"] != "")
            {
                this.isdirect = base.Request.Params["isdirect"].ToString();
            }
            if (base.Request.Params["EstID"] != null && base.Request.Params["EstID"] != "")
            {
                this.temp_ordid = Convert.ToInt64(base.Request.Params["EstID"]);
            }
            if (base.Request.Params["Ordid"] != null && base.Request.Params["Ordid"] != "")
            {
                this.OrdID = Convert.ToInt64(base.Request.Params["Ordid"]);
            }
            if (this.EstimateID != (long)-1)
            {
                this.TemplateID = (base.Request.QueryString["TemplateID"] == null ? (long)0 : Convert.ToInt64(base.Request.QueryString["TemplateID"]));
            }
            else
            {
                this.TemplateID = Convert.ToInt64(EprintConfigurationManager.AppSettings["TemplateIDforReport"]);
                this.Session[string.Concat("TemplateTable", this.GenratePDF.EstimateID.ToString().Trim())] = null;
            }
            if ((this.PageType.ToLower() == "job" || this.PageType.ToLower() == "printbroker") && base.Request.Params["EstItemID"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["EstItemID"].ToString());
            }

            if (!String.IsNullOrEmpty(base.Request.Params["customtype"]))
            {
                this.customType = base.Request.Params["customtype"].ToString();
            }

            ArrayList arrayLists = new ArrayList();
            bool flag = false;
            this.GenratePDF.MainFunction(this.EstimateID, this.jobID, this.InvoiceID, this.jID, this.InvID, this.PageType, this.PDFKey, this.IsFrom, this.isdirect, this.temp_ordid, this.OrdID, this.TemplateID, this.EstimateItemID, this.CompanyID, this.UserID, ref this.RetRefforPDFVisible, ref arrayLists, ref flag );
            this.filename = arrayLists[0].ToString();

            if (this.customType.Contains("download"))
            {
                string file = this.filename;
                string fileUrl = $"tempattachment/{file}";
                string downloadUrl = $"DownloadFile.ashx?file={file}";

                            string script = $@"
                // Open PDF in a new tab (from parent)
              //  window.parent.open('{fileUrl}', '_blank');

                // Trigger download from inside the iframe
                var downloadLink = document.createElement('a');
                downloadLink.href = '{downloadUrl}';
                downloadLink.download = '{file}';
                document.body.appendChild(downloadLink);
                downloadLink.click();
                document.body.removeChild(downloadLink);

                // Wait a bit before closing to allow download to start
                setTimeout(function() {{
                    window.parent.close();
                }}, 1000); // Wait 1 second before closing";
                ClientScript.RegisterStartupScript(this.GetType(), "dualDownload", script, true);
            }


            if (this.EstimateID != (long)-1)
            {
                if (this.RetRefforPDFVisible)
                {
                    this.pnl_hideLoad.Visible = true;
                }
                return;
            }

            this.Session[string.Concat("TemplateTable", this.EstimateID.ToString().Trim())] = null;
            base.Response.Redirect(string.Concat("tempattachment\\", arrayLists[0], "#zoom=100"));
        }
    }
}