using nmsConnectionClass;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmsCommon;
using Stripe.Checkout;
using System.Web.SessionState;
using iText.IO.Util;


namespace ePrint
{
    /// <summary>
    /// Summary description for StripePaymentHandler
    /// </summary>
    public class StripePaymentHandler : IHttpHandler, IRequiresSessionState
    {
        public string StripeKey = string.Empty;
        public string StripeLogoImage = string.Empty;
        public string StripeMessage = string.Empty;
        public string StripeRedirectURL = string.Empty;
        public string StripeLogoURL = string.Empty;

        protected string SessionId = string.Empty;
        private HttpContext _httpContext;
        private string strSitepath = global.sitePath();
        private string stripeUrl = string.Empty;
        private string StripePaymentLink = string.Empty;


        public void ProcessRequest(HttpContext context)
        {
            if (ConnectionClass.StripeKey != null)
            {
                this.StripeKey = ConnectionClass.StripeKey.ToString();
            }

            if (ConnectionClass.StripeLogoImage != null)
            {
                this.StripeLogoImage = ConnectionClass.StripeLogoImage.ToString();
            }

            if (ConnectionClass.StripeMessage != null)
            {
                this.StripeMessage = ConnectionClass.StripeMessage.ToString();
            }

            if (ConnectionClass.StripeRedirectURL != null)
            {
                this.StripeRedirectURL = ConnectionClass.StripeRedirectURL.ToString();
            }

            if (ConnectionClass.StripeLogoURL != null)
            {
                this.StripeLogoURL = ConnectionClass.StripeLogoURL.ToString();
            }

            QueryString queryString = new QueryString()
                        {
                            { "doctype", "stripenew" },
                            { "filename", this.StripeLogoImage }
            };
            QueryString queryString1 = Encryption.EncryptQueryString(queryString);
            this.StripeLogoURL = String.Concat(this.strSitepath, "DocManagerView.ashx", queryString1.ToString().Trim());

            //EprintConfigurationManager.GetAppSettingsAndConnectionString();
            //EprintConfigurationManager.AppSettings["LogoURL"].ToString();



            if (string.IsNullOrEmpty(this.SessionId))
            {
                StripeConfiguration.ApiKey = this.StripeKey;
                long TAmount = 1000;
                Decimal OrderTotalPrice = Convert.ToDecimal(context.Request.QueryString["OrderTotalPrice"]);
                string InvoiceNumber = context.Request.QueryString["InvoiceNumber"];
                string InvoiceTitle = context.Request.QueryString["InvoiceTitle"];
                long EstimateID = Convert.ToInt64(context.Request.QueryString["EstimateID"]);
                string cur= context.Request.QueryString["Currency"]; 

                if (Convert.ToInt32(OrderTotalPrice) != 0 && Convert.ToInt32(OrderTotalPrice) > 0)
                {
                    //TAmount = Convert.ToInt64(current["OrderTotalPrice"]) * 100;
                    decimal total = Convert.ToDecimal(OrderTotalPrice);
                    TAmount = Convert.ToInt64(total * 100);
                }

                if (!this.StripeRedirectURL.StartsWith("http://") && !this.StripeRedirectURL.StartsWith("https://"))
                {
                    // Prepend "http://"
                    this.StripeRedirectURL = "https://" + this.StripeRedirectURL;
                }


                string baseUrl = "https://stripe.eprintsoftware.com/success";
                string encodedUrl = "";// Uri.EscapeDataString(StripeLogoURL);
                if (!String.IsNullOrEmpty(this.StripeLogoImage))
                {
                    encodedUrl = Uri.EscapeDataString(StripeLogoURL);
                }
                else {
                    encodedUrl = "";
                }

                // Parameters to add
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                queryParams["amount"] = OrderTotalPrice.ToString();
                queryParams["orderNumber"] = InvoiceNumber.ToString();
                queryParams["redirectUrl"] = this.StripeRedirectURL;
                queryParams["logo"] = encodedUrl;
                queryParams["message"] = this.StripeMessage;

                // Construct the final URL
                string finalUrl = $"{baseUrl}?{queryParams}";

                //string SuccessUrl = "http://localhost:4200/success?amount="+ OrderTotalPrice.ToString() + "&orderNumber="+ InvoiceNumber + "&redirectUrl=" + this.StripeRedirectURL + "&logo="+ encodedUrl + "&message="+ this.StripeMessage+"" ;
                string SuccessUrl = "https://stripe.eprintsoftware.com/success?amount=" + OrderTotalPrice.ToString() + "&orderNumber=" + InvoiceNumber + "&redirectUrl=" + this.StripeRedirectURL + "&logo=" + encodedUrl + "&message=" + this.StripeMessage + "";

                //string SuccessUrl = finalUrl;
                //string CancelUrl = "http://localhost:4200/cancel?redirectUrl=" + this.StripeRedirectURL + "&logo="+ encodedUrl +"";
                string CancelUrl = "https://stripe.eprintsoftware.com/cancel?redirectUrl=" + this.StripeRedirectURL + "&logo=" + encodedUrl + "";

                //string SuccessUrl = this.strSitepath + "/Invoice/invoice_summary_reeng.aspx?InvID="+ context.Request.QueryString["InvID"] + "&EstimateID="+ EstimateID + "&OrderTotalPrice="+ OrderTotalPrice + "&stripe_payment=succeeded";
                //string CancelUrl = this.strSitepath + "/Invoice/invoice_summary_reeng.aspx?InvID=" + context.Request.QueryString["InvID"] + "&EstimateID=" + EstimateID + "";
                var options = new SessionCreateOptions
                {
                    SuccessUrl = SuccessUrl,
                    CancelUrl = CancelUrl,
                    PaymentMethodTypes = new List<string>
                            {
                                "card",
                            },
                    LineItems = new List<SessionLineItemOptions>
                            {
                                new SessionLineItemOptions{
                                    Name = InvoiceNumber,
                                    Amount = TAmount,
                                    Quantity = 1,
                                    Currency = string.IsNullOrEmpty(cur) ? "AUD" : cur,
                                    Description = InvoiceTitle
                                },
                            },
                    Mode = "payment",
                };
                var service = new SessionService();
                Session session = service.Create(options);
                string paymentint = session.PaymentIntentId;
                HttpContext.Current.Session["Stripe_Payment_ID"] = paymentint;
                this.SessionId = session.Id;
                this.stripeUrl = session.Url;
            }
            string[] Stripelink = new string[] { "https://checkout.stripe.com/pay/", this.SessionId, "#fidkdWxOYHwnPyd1blpxYHZxWjA0T2RHdTBGUmBGMnBVRFFudWFEU0lzTFNTZzRhdz13R1ZGQUs9bG9MMm1wTFVySG5BTmlucHBndXxxdFJ3QmdpMEJBbmNGSHM9b018YEh0Y21dUHdzaVdfNTVgSX1QSFVibicpJ2hsYXYnP34nYnBsYSc%2FJ0tEJyknaHBsYSc%2FJ0tEJykndmxhJz8nS0QneCknZ2BxZHYnP15YKSdpZHxqcHFRfHVgJz8ndmxrYmlgWmxxYGgnKSd3YGNgd3dgd0p3bGJsayc%2FJ21xcXU%2FKippamZkaW1qdnE%2FMzQxMzEneCUl" };
            this.StripePaymentLink = string.Concat(Stripelink);
            this.StripePaymentLink = this.stripeUrl;
            context.Response.Redirect(this.StripePaymentLink);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}