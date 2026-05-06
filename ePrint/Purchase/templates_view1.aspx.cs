using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
namespace ePrint.Purchase
{
    public partial class templates_view1 : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_templates_view1 UCtemplate1;

        private Global gloobj = new Global();

        private string sumpath = string.Empty;

        private static long CompanyID;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

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

        static templates_view1()
        {
        }

        public templates_view1()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Params["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (this.Session["CompanyID"] != null)
            {
                templates_view1.CompanyID = (long)Convert.ToInt32(this.Session["CompanyID"]);
            }
            // Ticket #11005 Wrong tab shows when displaying the purchase order PDF 
            if (Convert.ToString(base.Session["pagename"]).ToLower() == "purchase")
            {
                base.Title = "Purchases: Templates";
                this.sumpath = string.Concat("../purchase/purchase_add.aspx?type=edit&id=", base.Request.Params["EstID"].ToString());
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>Home</a>&nbsp;>&nbsp;<a href=../Purchase/purchase_view.aspx class='subnavigator'  style='text-decoration:underline;'>Purchase View</a>&nbsp;>&nbsp;<a href='", this.sumpath, "' class='subnavigator'  style='text-decoration:underline;'>Purchase Summary</a>"), "&nbsp;>&nbsp;Templates");
            }
            else
            {
                this.gloobj.setpagename("job");
                base.Title = "Jobs: Templates";
                if (base.Request.Params["GenPdf"] != null && base.Request.Params["GenPdf"].ToLower() == "all")
                {
                    this.Session["SelectedItemForPrint"] = null;
                }
                if (InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs").ToLower() != "yes")
                {
                    this.sumpath = string.Concat("../jobs/job_summary_reeng.aspx?frm=view&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID);
                }
                else
                {
                    string[] str = new string[] { "../jobs/job_order_summary.aspx?frm=view&ordid=", base.Request.Params["EstID"].ToString(), "&estid=", base.Request.Params["EstID"].ToString(), this.jID, this.InvID };
                    this.sumpath = string.Concat(str);
                }
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>Home</a>&nbsp;>&nbsp;<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>Job View</a>&nbsp;>&nbsp;<a href='", this.sumpath, "' class='subnavigator'  style='text-decoration:underline;'>Job Summary</a>"), "&nbsp;>&nbsp;Templates");
            }

           
        }

        [WebMethod]
        public static string SaveEmailedTemplate(string strattachment, string PDFKey)
        {
            SettingsBasePage.settings_template_emailed_insert(strattachment, PDFKey, templates_view1.CompanyID);
            return PDFKey;
        }
    }
}