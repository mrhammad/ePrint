using nmsCommon;
using nmsConnection;
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
    public partial class checkout_paypal : BaseClass, IRequiresSessionState
    {
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

        public checkout_paypal()
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
            if (this.Session["BillingAddress"] != null)
            {
                this.BillingAddress = Convert.ToInt32(this.Session["BillingAddress"]);
                DataTable dataTable = OrderBasePage.Select_BillingShipping_Address(this.StoreUserID, "", (long)this.BillingAddress);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.plh_paypal.Controls.Add(new LiteralControl("<input type='hidden' name='cmd' value='_cart'>"));
                    this.plh_paypal.Controls.Add(new LiteralControl("<input type='hidden' name='upload' value='1'>"));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='business' value='", ConnectionClass.Paypalbusiness, "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='first_name' value='", row["FirstName"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='last_name' value='", row["LastName"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='address1' value='", row["Address1"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='city' value='", row["Address2"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='state' value='", row["Address3"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='zip' value='", row["Address4"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='phone' value='", row["Phone"], "'>")));
                    this.plh_paypal.Controls.Add(new LiteralControl("<input type='hidden' name='country' value='AU'>"));
                    this.plh_paypal.Controls.Add(new LiteralControl("<input type='hidden' name='rm' value='2'>"));
                }
            }
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            int num3 = 1;
            foreach (DataRow dataRow in CartBasePage.Select_CartItems("", "", this.StoreUserID).Rows)
            {
                if (num3 == 1)
                {
                    this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='currency_code' value='", dataRow["currency"], "'>")));
                    num1 = Convert.ToDecimal(dataRow["TotalCartAdditionalPrice"].ToString());
                    num = num + num1;
                }
                ControlCollection controls = this.plh_paypal.Controls;
                object[] objArray = new object[] { "<input type='hidden' name='amount_", num3, "' value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(dataRow["CartTotalPrice"]), 2, "", false, false, true), "'>" };
                controls.Add(new LiteralControl(string.Concat(objArray)));
                ControlCollection controlCollections = this.plh_paypal.Controls;
                object[] item = new object[] { "<input type='hidden' name='item_name_", num3, "' value='", dataRow["CatalogueName"], "'>" };
                controlCollections.Add(new LiteralControl(string.Concat(item)));
                this.UnitPrice = Convert.ToDecimal(dataRow["UnitPrice"].ToString());
                num = num + Convert.ToDecimal(dataRow["CartTotalPrice"].ToString());
                num2 = Convert.ToDecimal(dataRow["Tax"]);
                num3++;
            }
            num2 = (num2 * num) / new decimal(100);
            this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='handling_cart' value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num1), 2, "", false, false, true), "'>")));
            this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='tax_cart' value='", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(num2), 2, "", false, false, true), "'>")));
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                ControlCollection controls1 = this.plh_paypal.Controls;
                object[] item1 = new object[] { "<input type='hidden' name='return' value='", this.strSitepath, "order_confirmation.aspx?OrdKey=0&type=1&key=", this.paypalKey, "&BID=", this.Session["BillingAddress"], "&SID=", this.Session["ShippingAddress"], "'>" };
                controls1.Add(new LiteralControl(string.Concat(item1)));
                this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='cancel_return' value='", this.strSitepath, "default.aspx?type=0'>")));
            }
            else
            {
                ControlCollection controlCollections1 = this.plh_paypal.Controls;
                object[] keySeparator = new object[] { "<input type='hidden' name='return' value='", this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, 0, ConnectionClass.KeySeparator, "1", ConnectionClass.KeySeparator, this.paypalKey, ConnectionClass.KeySeparator, this.Session["BillingAddress"], ConnectionClass.KeySeparator, this.Session["ShippingAddress"], ConnectionClass.FileExtension, "'>" };
                controlCollections1.Add(new LiteralControl(string.Concat(keySeparator)));
                this.plh_paypal.Controls.Add(new LiteralControl(string.Concat("<input type='hidden' name='cancel_return' value='", this.strSitepath, "default.aspx?type=0'>")));
            }
            if (num == new decimal(0))
            {
                this.form1.Action = "";
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    HttpResponse response = base.Response;
                    object[] keySeparator1 = new object[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, 0, ConnectionClass.KeySeparator, "1", ConnectionClass.KeySeparator, this.paypalKey, ConnectionClass.KeySeparator, this.Session["BillingAddress"], ConnectionClass.KeySeparator, this.Session["ShippingAddress"], ConnectionClass.FileExtension };
                    response.Redirect(string.Concat(keySeparator1));
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "order_confirmation.aspx?OrdKey=0&type=1&key=", this.paypalKey, "&BID=", this.Session["BillingAddress"], "&SID=", this.Session["ShippingAddress"] };
                httpResponse.Redirect(string.Concat(objArray1));
            }
        }
    }
}