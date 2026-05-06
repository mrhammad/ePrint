using nmsCommon;
using nmsConnection;
using PayPalExample;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class advanced_paypalapi : System.Web.UI.Page, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected PlaceHolder plh_paypal;

        //protected HtmlForm form1;

        public string paypalKey = string.Empty;

        private commonclass comm = new commonclass();

        public int CompanyID;

        public long StoreUserID;

        public long AccountID;

        public decimal TotalPrice;

        public decimal Tax;

        public string strSitepath = string.Empty;

        public int BillingAddress;

        public decimal UnitPrice;

        public string PaypalLiveMode = string.Empty;

        public string PaypalTestUrl = string.Empty;

        public string PaypalLiveUrl = string.Empty;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public advanced_paypalapi()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session["paypalKey"] = null;
            this.paypalKey = Guid.NewGuid().ToString();
            this.Session["paypalKey"] = this.paypalKey;
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath.ToString();
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (ConnectionClass.CompanyID != null)
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.PaypalLiveMode != null)
            {
                this.PaypalLiveMode = ConnectionClass.PaypalLiveMode;
            }
            if (ConnectionClass.PaypalTestUrl != null)
            {
                this.PaypalTestUrl = ConnectionClass.PaypalTestUrl;
            }
            if (ConnectionClass.PaypalLiveUrl != null)
            {
                this.PaypalLiveUrl = ConnectionClass.PaypalLiveUrl;
            }
            if (this.PaypalLiveMode.ToLower() != "yes")
            {
                this.form1.Action = this.PaypalTestUrl;
            }
            else
            {
                this.form1.Action = this.PaypalLiveUrl;
            }
            string empty = string.Empty;
            string str = string.Empty;
            string str1 = "";
            string str2 = "";
            NVPAPICaller nVPAPICaller = new NVPAPICaller();
            DataTable dataTable = CartBasePage.Select_CartItems_Paypal(this.StoreUserID, this.Session["MultipleCartID"].ToString());
            DataTable dataTable1 = new DataTable();
            if (this.Session["BillingAddress"] != null)
            {
                this.BillingAddress = Convert.ToInt32(this.Session["BillingAddress"]);
                dataTable1 = OrderBasePage.Select_BillingShipping_Address(this.StoreUserID, "", (long)this.BillingAddress);
            }
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                object[] item = new object[] { this.strSitepath, "order_confirmation.aspx?OrdKey=0&type=1&key=", this.paypalKey, "&BID=", this.Session["BillingAddress"], "&SID=", this.Session["ShippingAddress"] };
                str1 = string.Concat(item);
                str2 = string.Concat(this.strSitepath, "payment_information.aspx?");
            }
            else
            {
                object[] keySeparator = new object[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, 0, ConnectionClass.KeySeparator, "1", ConnectionClass.KeySeparator, this.paypalKey, ConnectionClass.KeySeparator, this.Session["BillingAddress"], ConnectionClass.KeySeparator, this.Session["ShippingAddress"], ConnectionClass.FileExtension };
                str1 = string.Concat(keySeparator);
                str2 = string.Concat(this.strSitepath, "payment_information.aspx?");
            }
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            int num4 = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (num4 == 1)
                {
                    num1 = Convert.ToDecimal(row["TotalCartAdditionalPrice"].ToString());
                    num = num + num1;
                }
                this.UnitPrice = Convert.ToDecimal(row["UnitPrice"].ToString());
                num = num + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                num3 = num3 + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                num2 = Convert.ToDecimal(row["Tax"]);
                num4++;
            }
            num2 = (num2 * num) / new decimal(100);
            if (num != new decimal(0))
            {
                if (nVPAPICaller.ExpressCheckout(this.CompanyID, str1, str2, dataTable, dataTable1, ref empty, ref str))
                {
                    HttpContext.Current.Session["token"] = empty;
                    base.Response.Redirect(str);
                    return;
                }
                string empty1 = string.Empty;
                if (this.Session["PP_PriceValue"] != null && this.Session["PP_TaxValue"] != null)
                {
                    empty1 = string.Concat("Tp=", this.Session["PP_PriceValue"].ToString(), "&Tx=", this.Session["PP_TaxValue"].ToString());
                }
                base.Response.Redirect(string.Concat(str2, empty1, "&error=", str));
                return;
            }
            this.form1.Action = "";
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                HttpResponse response = base.Response;
                object[] objArray = new object[] { this.strSitepath, "order_confirmation.aspx?OrdKey=0&type=1&key=", this.paypalKey, "&BID=", this.Session["BillingAddress"], "&SID=", this.Session["ShippingAddress"] };
                response.Redirect(string.Concat(objArray));
                return;
            }
            HttpResponse httpResponse = base.Response;
            object[] keySeparator1 = new object[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, 0, ConnectionClass.KeySeparator, "1", ConnectionClass.KeySeparator, this.paypalKey, ConnectionClass.KeySeparator, this.Session["BillingAddress"], ConnectionClass.KeySeparator, this.Session["ShippingAddress"], ConnectionClass.FileExtension };
            httpResponse.Redirect(string.Concat(keySeparator1));
        }
    }
}