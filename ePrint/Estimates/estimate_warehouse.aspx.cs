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

namespace ePrint.Estimates
{
    public partial class estimate_warehouse : BaseClass, IRequiresSessionState
    {
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

        public string EstTypeFromSP = string.Empty;

        private long InvoiceNum;

        public long EstNo;

        private string CatalogueProfitAndTax = string.Empty;

        public long PressID;

        public int IsItemCompleted;

        private CompanyBasePage objCom = new CompanyBasePage();

        private InventoryBasePage objInv = new InventoryBasePage();

        public string QueryType = string.Empty;

        public string tabtype = "estimate";

        public string widthsize = string.Empty;

        public long ParentEstimateItemID;

        public string ParentEstimateType = string.Empty;

        public string req_type = string.Empty;

        private Global gloobj = new Global();

        public string FromSummary = string.Empty;

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

        public estimate_warehouse()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("estimate");
            if (!base.Request.Url.ToString().ToLower().Contains("jobs/job_add.aspx"))
            {
                base.Request.Url.ToString().ToLower().Contains("invoice/invoices_add.aspx");
            }
            try
            {
                if (base.Request.Params["frm"] != null)
                {
                    this.FromSummary = base.Request.Params["frm"].ToString();
                }
                if (base.Request.QueryString["estitemid"] != null)
                {
                    this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
                }
            }
            catch
            {
            }
            if (base.Request.QueryString["esttype"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.EstType = base.Request.QueryString["esttype"].ToString().ToLower();
            }
            if (base.Request.Params["type"] != null)
            {
                if (base.Request.Params["estid"] != null)
                {
                    this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                }
                if (string.Compare(base.Request.Params["type"].ToString(), "add", true) == 0)
                {
                    string empty = string.Empty;
                    this.req_type = "add";
                    if (base.Request.Params["FromAddAnItem"] != null)
                    {
                        if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                        {
                            object[] estimateID = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                            empty = string.Concat(estimateID);
                            string[] languageConversion = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Warehouse")));
                        }
                    }
                    else if (base.Request.Params["maintype"] != "edit")
                    {
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Estimate_Add_Warehouse"));
                    }
                    else
                    {
                        object[] objArray = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(objArray);
                        string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Warehouse")));
                    }
                    base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
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
                    string str = string.Empty;
                    if (this.FromSummary == "sum")
                    {
                        object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                        str = string.Concat(estimateID1);
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", str };
                        base.Navigation_Path(string.Concat(strArrays1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Edit_Warehouse")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Estimate Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    base.Navigation_Path(string.Concat("<a href=../estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Warehouse")));
                    base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
            }
        }
    }
}
    
