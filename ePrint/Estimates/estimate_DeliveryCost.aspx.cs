using nmsCommon;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
namespace ePrint.Estimates
{
    public partial class estimate_DeliveryCost : BaseClass, IRequiresSessionState
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

        public estimate_DeliveryCost()
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
                        object[] estimateID = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                        empty = string.Concat(estimateID);
                    }
                    if (this.IsItemCompleted == 1)
                    {
                        string[] languageConversion = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                        base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Edit_DeliveryCost")));
                        base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                        return;
                    }
                    if (this.IsItemCompleted == 0)
                    {
                        string[] strArrays = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;" };
                        base.Navigation_Path(string.Concat(strArrays), this.objLanguage.GetLanguageConversion("Estimate_Add_Delivery_Cost"));
                        base.Title = this.objLanguage.convert(global.pageTitle("Estimate Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    }
                }
                return;
            }
            if (base.Request.Params["FromAddAnItem"] != null)
            {
                if (base.Request.Params["FromAddAnItem"].ToString() == "Y")
                {
                    object[] objArray = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                    empty = string.Concat(objArray);
                    string[] languageConversion1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Delivery_Cost")));
                }
            }
            else if (base.Request.Params["maintype"] != "edit")
            {
                string[] strArrays1 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                base.Navigation_Path(string.Concat(strArrays1), this.objLanguage.GetLanguageConversion("Estimate_Add_Delivery_Cost"));
            }
            else
            {
                object[] estimateID1 = new object[] { "<a href='", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", this.EstimateID, "' class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_Summary"), "</a>&nbsp;>" };
                empty = string.Concat(estimateID1);
                string[] languageConversion2 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Estimate_View"), "</a> &nbsp;>&nbsp;", empty };
                base.Navigation_Path(string.Concat(languageConversion2), string.Concat("&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_Add_Delivery_Cost")));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Estimate Add", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}