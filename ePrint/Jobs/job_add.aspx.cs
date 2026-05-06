using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
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
    public partial class job_add : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

        private Global gloobj = new Global();

        public long EstimateID;

        public long EstimateItemID;

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

        public job_add()
        {
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetClientName(string val)
        {
            return "";
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetContactAddress(string CompID, string ContactID)
        {
            string str = CompanyBasePage.company_contact_address_select(Convert.ToInt32(CompID), Convert.ToInt32(ContactID));
            return str;
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetContacts(string StrCompanyID, string StrClientID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_contacts_select_by_clientid(Convert.ToInt32(StrCompanyID), Convert.ToInt32(StrClientID));
            return empty;
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetPaperHeightWidth(string CompID, string InventoryID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.estimate_paperproperties_select(Convert.ToInt32(CompID), Convert.ToInt64(InventoryID));
            return empty;
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetSalesPerson(string CompID, string ClientID)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            string str = companyBasePage.main_company_salesperson_select(Convert.ToInt32(ClientID), Convert.ToInt32(CompID));
            return str;
        }
        [WebMethod]
        public static string GetInvoiceContact(string CompID, string ClientID)
        {
            CompanyBasePage companyBasePage = new CompanyBasePage();
            string str = companyBasePage.main_company_InvocieContact_select(Convert.ToInt32(ClientID), Convert.ToInt32(CompID));
            return str;
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static string GetSuppliers_List(string StrCompanyID)
        {
            string empty = string.Empty;
            empty = EstimateBasePage.supplier_select_in_printbroker(Convert.ToInt32(StrCompanyID));
            return (new BaseClass()).ReplaceSingleQuote(empty);
        }

        protected void onclik_cancel(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_item_form.aspx", this.jID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Tabs("jobs", "isadd", "");
            global.pageName = "job";
            global.pgName = "";
            this.pg = "job";
            this.gloobj.setpagename("job");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
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
            languageClass _languageClass = new languageClass();
            if (base.Request.Params["type"].ToString().ToLower() == "add")
            {
                base.Title = _languageClass.convert(global.pageTitle("Add Job", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Job_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Job_Add")));
            }
            else if (base.Request.Params["type"].ToString().ToLower() == "edit")
            {
                try
                {
                    if (base.Request.QueryString["estid"] != null)
                    {
                        this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                    }
                    if (base.Request.QueryString["estitemid"] != null)
                    {
                        this.EstimateItemID = Convert.ToInt64(base.Request.Params["estitemid"]);
                    }
                    foreach (DataRow row in EstimatesBasePage.selectEstimatetype_estimateitemid(this.EstimateItemID, this.EstimateID).Rows)
                    {
                        this.IsItemCompleted = Convert.ToInt16(row["IsItemCompleted"].ToString());
                    }
                }
                catch
                {
                }
                if (this.IsItemCompleted != 1)
                {
                    base.Title = _languageClass.convert(global.pageTitle("Add Job", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    object[] estimateID = new object[] { "<a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", this.EstimateID, this.jID, "' class='subnavigator'  style='text-decoration:underline;'>Job Summary</a>&nbsp;>" };
                    string str = string.Concat(estimateID);
                    string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Job_View"), "</a>" };
                    base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", str, _languageClass.GetLanguageConversion("Job_Edit")));
                }
                else
                {
                    base.Title = _languageClass.convert(global.pageTitle("Job Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                    string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Job_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Job_Edit")));
                }
            }
            if (base.Request.Params["type"] != null && base.Request.Params["type"].ToString().ToLower() == "add")
            {
                EstimateBasePage.etimates_tempattachment_delete(this.CompanyID, this.UserID);
            }
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static void RemoveOtherCostItem(string CompID, string EstOtherCostID)
        {
            EstimateBasePage.Estimate_Summary_OtherCost_Remove(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
            EstimateBasePage.estimate_othercost_variableqty_delete(Convert.ToInt32(CompID), Convert.ToInt64(EstOtherCostID));
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static void RemovePrintBroker(string CompID, string EstOutworkID, string OutworkType)
        {
            long num = Convert.ToInt64(EstOutworkID);
            EstimateBasePage.Estimate_Outwork_Delete(Convert.ToInt32(CompID), num, OutworkType);
        }

        [WebMethod(EnableSession = true, CacheDuration = 0)]
        public static void RemoveWarehouseItem(string CompID, string EstWarehouseItemID)
        {
            EstimateBasePage.Estimate_Summary_Warehouse_Delete(Convert.ToInt32(CompID), Convert.ToInt64(EstWarehouseItemID));
        }
        [WebMethod]
        public static string GetContactFirstName(string ContactID)
        {
            string firstName = EstimateBasePage.GetContactFirstName(ContactID);
            return firstName;
        }
    }
}