using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Company;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.orders
{
    public partial class order_summary_rerun : BaseClass, IRequiresSessionState
    {
        //protected usercontrol_orders_order_rerun_ascx orderrerun;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        public int OrderID;

        public int EstimateID;

        public string Type = "";

        public int JobID;

        public int InvoiceID;

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

        public order_summary_rerun()
        {
        }

        [WebMethod]
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.gloobj.setpagename("webstoreorder");
            if (base.Request.Params["orderid"] != null)
            {
                this.OrderID = Convert.ToInt32(base.Request.Params["orderid"]);
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt32(base.Request.Params["estid"]);
            }
            if (base.Request.Params["jID"] != null)
            {
                this.JobID = Convert.ToInt32(base.Request.Params["jID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt32(base.Request.Params["InvID"]);
            }
            if (base.Request.Params["type"] != null)
            {
                this.Type = base.Request.Params["type"].ToString();
            }
            if (this.Type.ToLower() == "webstoreorder")
            {
                string str = string.Concat("<a href=../orders/order_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_View"), "</a>&nbsp;>&nbsp");
                object[] orderID = new object[] { "<a href='", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "'  class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Order_Summary"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Order_Edit") };
                base.Navigation_Path(str, string.Concat(orderID));
                base.Title = this.objLanguage.convert(global.pageTitle("Order Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                return;
            }
            if (this.Type.ToLower() != "job")
            {
                if (this.Type.ToLower() == "invoice")
                {
                    this.gloobj.setpagename("invoice");
                    string str1 = string.Concat("<a href=../invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_View"), "</a>&nbsp;>&nbsp");
                    object[] invoiceID = new object[] { "<a href='", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&InvID=", this.InvoiceID, "'  class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Invoice_Summary"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_Order_Edit") };
                    base.Navigation_Path(str1, string.Concat(invoiceID));
                    base.Title = this.objLanguage.convert(global.pageTitle("Invoice Order Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                }
                return;
            }
            this.gloobj.setpagename("job");
            string str2 = string.Concat("<a href=../jobs/jobs_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_View"), "</a>&nbsp;>&nbsp");
            object[] objArray = new object[] { "<a href='", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&ordid=", this.OrderID, "&estid=", this.EstimateID, "&jID=", this.JobID, "'  class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Job_Summary"), "</a>&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_Order_Edit") };
            base.Navigation_Path(str2, string.Concat(objArray));
            base.Title = this.objLanguage.convert(global.pageTitle("Job Order Edit", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
    }
}