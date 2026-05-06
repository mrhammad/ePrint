using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
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
    public partial class job_pricecatalog : BaseClass, IRequiresSessionState
    {
        public BaseClass objBase = new BaseClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string section = string.Empty;

        private BaseClass Objclss = new BaseClass();

        private BasePage ObjPage = new BasePage();

        public string DateFormat = string.Empty;

        public int CompanyID;

        public long EstimateID;

        public long EstimateItemID;

        public long EstSingleItemID;

        public long EstPadItemID;

        public long EstLargeItemID;

        public long EstBookletItemID;

        public long EstBookletSectionID;

        private string strEstSectionIDs = string.Empty;

        public long TypeID;

        public long EstOtherCostID;

        public string OtherCostValuesFromTB = string.Empty;

        public string EstType = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "job";

        public string widthsize = string.Empty;

        public string Pub_CustomerID = "0";

        public string Pub_CustomerName = "";

        private Global gloobj = new Global();

        public string EstTypeFromSP = string.Empty;

        private long ParentItemID;

        private string ParentItemType = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string req_type = string.Empty;

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

        public job_pricecatalog()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            string str = InvoiceBasePage.IS_INVOICEorJOB_from_Webstore(this.jobID, "jobs");
            this.gloobj.setpagename("job");
            try
            {
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
                if (base.Request.QueryString["EstID"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.QueryString["EstID"].ToString());
                }
                if (base.Request.QueryString["estitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.QueryString["estitemid"].ToString());
                }
            }
            catch
            {
            }
            if (base.Request.Params["type"] != null)
            {
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    this.req_type = "add";
                    string empty = string.Empty;
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                        {
                            if (str.ToLower() != "yes")
                            {
                                object[] estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                                empty = string.Concat(estimateID);
                                string[] languageConversion = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_view"), "</a> &nbsp;>&nbsp;", empty };
                                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue")));
                            }
                            else
                            {
                                object[] objArray = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                                empty = string.Concat(objArray);
                                string[] strArrays = new string[] { "<a href=", this.strSitepath, "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_view"), "</a> &nbsp;>&nbsp;", empty };
                                base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue")));
                            }
                        }
                    }
                    else if (base.Request.Params["maintype"] != "edit")
                    {
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;" };
                        base.Navigation_Path(string.Concat(languageConversion1), this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue"));
                    }
                    else if (str.ToLower() != "yes")
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(estimateID1);
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue")));
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(objArray1);
                        string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue")));
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    return;
                }
                if (string.Compare(base.Request.Params["type"].ToString(), "more", true) == 0)
                {
                    this.req_type = "more";
                    return;
                }
                if (string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
                {
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    this.req_type = "edit";
                    string empty1 = string.Empty;
                    if (this.FromSummary == "sum" || base.Request.Params["type"].ToString() == "edit")
                    {
                        if (str.ToLower() != "yes")
                        {
                            object[] estimateID2 = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;></a>" };
                            empty1 = string.Concat(estimateID2);
                        }
                        else
                        {
                            object[] objArray2 = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", this.EstimateID, this.jID, this.InvID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;></a>" };
                            empty1 = string.Concat(objArray2);
                        }
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] strArrays2 = new string[] { "<a href=", this.strSitepath, "Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a> &nbsp;>&nbsp;", empty1 };
                        base.Navigation_Path(string.Concat(strArrays2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Job_Edit_Product_Catalogue")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    base.Navigation_Path(string.Concat("<a href=../Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", empty1, this.objLanguage.GetLanguageConversion("Job_Add_Product_Catalogue")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
            }
        }
    }
}
