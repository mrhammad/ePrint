using nmsCommon;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.Jobs
{
    public partial class job_quickquote : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        private BaseClass Objclss = new BaseClass();

        public string req_type = string.Empty;

        private Global gloobj = new Global();

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public string FromSummary = string.Empty;

        public int IsItemCompleted;

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

        public job_quickquote()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.gloobj.setpagename("job");
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.gloobj.setpagename("estimate");
            }
            else
            {
                this.gloobj.setpagename("invoice");
            }
            if (base.Request.QueryString["type"] != null)
            {
                this.req_type = base.Request.QueryString["type"].ToString();
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            }
            if (base.Request.QueryString["estitemid"] != null)
            {
                this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
            }
            if (this.EstimateID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
            }
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            string str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            string empty = string.Empty;
            if (string.Compare(this.req_type, "add", true) != 0)
            {
                if (string.Compare(this.req_type, "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    if (this.FromSummary == "sum")
                    {
                        if (str.ToLower() != "yes")
                        {
                            object[] estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "&nbsp;></a>" };
                            empty = string.Concat(estimateID);
                        }
                        else
                        {
                            object[] objArray = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "&nbsp;></a>" };
                            empty = string.Concat(objArray);
                        }
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        if (str.ToLower() != "yes")
                        {
                            object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                            empty = string.Concat(estimateID1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                            empty = string.Concat(objArray1);
                        }
                        string[] languageConversion = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Edit_Quick_Quote")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    string[] strArrays = new string[] { "<a href=", this.strSitepath, "jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;" };
                    base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote"));
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                return;
            }
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                {
                    if (str.ToLower() != "yes")
                    {
                        object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(estimateID2);
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote")));
                    }
                    else
                    {
                        object[] objArray2 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(objArray2);
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote")));
                    }
                }
            }
            else if (base.Request.Params["maintype"] != "edit")
            {
                string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;" };
                base.Navigation_Path(string.Concat(languageConversion2), this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote"));
            }
            else if (str.ToLower() != "yes")
            {
                object[] estimateID3 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                empty = string.Concat(estimateID3);
                string[] strArrays2 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                base.Navigation_Path(string.Concat(strArrays2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote")));
            }
            else
            {
                object[] objArray3 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                empty = string.Concat(objArray3);
                string[] languageConversion3 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                base.Navigation_Path(string.Concat(languageConversion3), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Quick_Quote")));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}