using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ePrint.Jobs
{
    public partial class job_productcatalogue : BaseClass, IRequiresSessionState
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

        public string tabtype = "webstoreorder";

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

        public string frmcopyitem = string.Empty;

        public int IsItemCompleted;

        public long OrderID;

        public long jobID;

        public string jID = string.Empty;

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

        public job_productcatalogue()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("job");
            try
            {
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
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
                    base.Navigation_Path("<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>Job View</a>", "&nbsp;>&nbsp;Job Add: Product Catalogue");
                    base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "more", true) == 0)
                {
                    this.req_type = "more";
                }
                else if (string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
                {
                    if (base.Request.Params["estid"] != null)
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"].ToString());
                    }
                    if (base.Request.Params["estitemid"] != null)
                    {
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
                    }
                    if (base.Request.Params["ordid"] != null)
                    {
                        this.OrderID = Convert.ToInt64(base.Request.Params["ordid"]);
                    }
                    if (base.Request.QueryString["jID"] != null)
                    {
                        this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
                    }
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                    this.req_type = "edit";
                    string empty = string.Empty;
                    if (this.FromSummary == "sum")
                    {
                        object[] orderID = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "&jID=", this.jobID, "' class='subnavigator'  style='text-decoration:underline;'>Job Summary</a>&nbsp;></a>" };
                        empty = string.Concat(orderID);
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        base.Navigation_Path(string.Concat("<a href=", this.strSitepath, "jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>Job View</a> &nbsp;>&nbsp;", empty), "&nbsp;Job Edit: Product Catalogue");
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                    else if (this.IsItemCompleted == 0)
                    {
                        base.Navigation_Path("<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>Job View</a>", string.Concat("&nbsp;>&nbsp;", empty, "Job Add: Product Catalogue"));
                        base.Title = this.objLanguage.convert(global.pageTitle("Job Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                }
            }
            if (base.Request.QueryString["frmcopyitem"] != null)
            {
                this.frmcopyitem = base.Request.QueryString["frmcopyitem"].ToString();
            }
            if (this.frmcopyitem == "yes" && string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
            {
                this.lblheaderr.Text = "Create Item(Copied Item)";
                return;
            }
            if (this.frmcopyitem != "yes" && string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
            {
                this.lblheaderr.Text = "Create Item";
                return;
            }
            if (this.frmcopyitem != "yes" && string.Compare(base.Request.Params["type"].ToString(), "edit", true) == 0)
            {
                this.lblheaderr.Text = "Update Item";
            }
        }
    }
}