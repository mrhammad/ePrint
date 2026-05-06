using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;


namespace ePrint.Jobs
{
    public partial class job_litho_single_item : BaseClass, IRequiresSessionState
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

        public job_litho_single_item()
        {
        }

        [WebMethod]
        public static string GetPaperHeightWidth(string CompID, string InventoryID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_paperproperties_select(Convert.ToInt32(CompID), Convert.ToInt64(InventoryID));
            return empty;
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
                base.Response.Redirect(string.Concat(this.strSitepath, "jobs/jobs_view.aspx"));
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
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            string empty = string.Empty;
            try
            {
                if (base.Request.Params["parentestitemid"] != null)
                {
                    Convert.ToInt64(base.Request.Params["parentestitemid"]);
                }
                if (base.Request.Params["parentesttype"] != null)
                {
                    base.Request.Params["parentesttype"].ToString();
                }
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
            }
            catch
            {
            }
            string str = string.Empty;
            str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            string empty1 = string.Empty;
            if (string.Compare(this.req_type, "add", true) != 0)
            {
                if (string.Compare(this.req_type, "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    if (this.FromSummary == "sum" || this.req_type == "edit")
                    {
                        if (str.ToString().ToLower() != "yes")
                        {
                            object[] estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(estimateID);
                        }
                        else
                        {
                            object[] objArray = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                            empty1 = string.Concat(objArray);
                        }
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] languageConversion = new string[] { "<a href=", this.strSitepath, "jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Edit_Single_Item")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    string[] strArrays = new string[] { "<a href=", this.strSitepath, "jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;" };
                    base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Job_Add_Single_Item"));
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                return;
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                {
                    if (str.ToString().ToLower() != "yes")
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty1 = string.Concat(estimateID1);
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty1 = string.Concat(objArray1);
                    }
                    string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty1 };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Single_Item")));
                }
            }
            else if (base.Request.Params["maintype"] != "edit")
            {
                string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;" };
                base.Navigation_Path(string.Concat(strArrays1), this.objLanguage.GetLanguageConversion("Job_Add_Single_Item"));
            }
            else
            {
                if (str.ToString().ToLower() != "yes")
                {
                    object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                    empty1 = string.Concat(estimateID2);
                }
                else
                {
                    object[] objArray2 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                    empty1 = string.Concat(objArray2);
                }
                string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty1 };
                base.Navigation_Path(string.Concat(languageConversion2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Single_Item")));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}
