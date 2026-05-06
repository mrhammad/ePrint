using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Invoices;
using RemovingWhiteSpacesAspNet;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ePrint.invoice
{
    public partial class invoice_summary_reeng : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

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

        public invoice_summary_reeng()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.objBC.ReturnRoles_Privileges_Tabs("invoices", "isview", "");
            global.pageName = "invoice";
            this.pg = "invoice";
            this.gloobj.setpagename("invoice");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            languageClass _languageClass = new languageClass();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../invoice/invoice_view.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Invoice_View"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", _languageClass.GetLanguageConversion("Invoice_Summary")));
            base.Title = _languageClass.convert(global.pageTitle("Invoice Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (HttpContext.Current.Request.QueryString["stripe_payment"] != null && Session["Stripe_Payment_ID"] != null)
            {
                string Stripe_Paymentid = string.Empty;
                if (Session["Stripe_Payment_ID"] != null)
                {
                    Stripe_Paymentid = Session["Stripe_Payment_ID"].ToString();
                }
                long EstimateID = Convert.ToInt64(HttpContext.Current.Request.QueryString["EstimateID"]);
                long InvID = Convert.ToInt64(HttpContext.Current.Request.QueryString["InvID"]);
                Decimal OrderTotalPrice = Convert.ToDecimal(HttpContext.Current.Request.QueryString["OrderTotalPrice"]);
                InvoiceBasePage.Insert_StripePayment((long)this.CompanyID, EstimateID, Stripe_Paymentid);
                InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(InvID, (long)this.CompanyID,15, DateTime.Now, "Payment through checkout", "", "", 0, 0, "", "", OrderTotalPrice, OrderTotalPrice);
                //HttpContext.Current.Request.QueryString["stripe_payment"] = null;
                Session["Stripe_Payment_ID"] = null;
                Session["stripe_payment"] = null;

            }
        }
    }
}
