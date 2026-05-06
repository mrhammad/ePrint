using Braintree;
using Stripe;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Stripe.Checkout;

namespace ePrint.MyPublicStore
{
    public partial class payment_information : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_Checkout;

        //protected HtmlGenericControl div_NavigationID;

        //protected HtmlGenericControl li_Order;

        //protected HtmlGenericControl li_Address;

        //protected HtmlGenericControl li_payment;

        //protected Label lblPaypalAlertMSG;

        //protected Label lblPIHeader;

        //protected Label lbl_payment;

        //protected DropDownList ddl_payments;

        //protected HtmlGenericControl div_PaymentMode;

        //protected RadioButton rdn_Check_Money;

        //protected RadioButton rdn_Card;

        //protected Label lbl_HolderName;

        //protected TextBox txt_HolderName;

        //protected Label lbl_cardType;

        //protected RadioButton rbnVisaID;

        //protected HtmlImage imgVisaCard;

        //protected HtmlGenericControl div_creditCard_Visa;

        //protected RadioButton rbnMasterCardID;

        //protected HtmlImage imgMasterCard;

        //protected HtmlGenericControl div_creditCard_Master;

        //protected RadioButton rbnAmericanID;

        //protected HtmlImage imgAmericanCard;

        //protected HtmlGenericControl div_creditCard_American;

        //protected RadioButton rbnDiscoverID;

        //protected HtmlImage imgDiscoverCard;

        //protected HtmlGenericControl div_creditCard_Discover;

        //protected Label lbl_cardNumber;

        //protected TextBox txt_cardNumber;

        //protected Label lbl_expDate;

        //protected DropDownList ddl_month;

        //protected DropDownList ddl_year;

        //protected Label lbl_verification;

        //protected TextBox txt_verification;

        //protected Label lbl_paymentRF;

        //protected Button BackLink;

        //protected Button btnOrder;

        //protected Image imgLoading;

        //protected LinkButton lnkbtnOrder;

        //protected Button btnsrt;

        //protected Button btnOrderonsubmit;

        //protected Panel Panel1;

        //protected HiddenField hdn_OrderID;

        //protected HiddenField hdnagentcode;

        //protected HiddenField hdnsecretcode;

        //protected HiddenField hdn_Creditcardtypes;

        //protected HiddenField hdn_Creditcardtypes_BT;

        //protected HiddenField hdn_SelectedCardType;

        public string strImagepath = BaseClass.imagePath();

        private commonclass comm = new commonclass();

        private BaseClass objBc = new BaseClass();

        private EmailClass Objemail = new EmailClass();

        public languageClass objLanguage = new languageClass();

        public string OrderKey = string.Empty;

        private string[] paymentMode;

        private string[] CardTypes;

        public long AccountID;

        public int CompanyID;

        public string defaultpaymentMode = string.Empty;

        public string strSitepath = string.Empty;

        public string eprintDocument = string.Empty;

        public string AccountType = string.Empty;

        public string DateFormat = string.Empty;

        public int UserID;

        public long OrderID;

        public long StoreUserID;

        private DateTime OrderDate;

        private DateTime CreatedDate;

        public string isLoginInfo = "1";

        public string CardType = string.Empty;

        public decimal TotalPrice;

        public decimal Tax;

        public decimal OrderShipping;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ApproverEmail = string.Empty;

        public long DepartmentID;

        public string UserType = string.Empty;

        public bool IsBackOrder;

        public string BCKORDERTYPE = string.Empty;

        public string NEWORDER = string.Empty;

        public int AvailableQuantity;

        public string Paypal_ButtonText = string.Empty;

        public string OtherOptions_ButtonText = string.Empty;

        private string Prod_Id = string.Empty;

        public string ServerName = string.Empty;

        public bool IsValidAgent;

        public string BT_OrderID = string.Empty;

        public string BT_AuthorizationCode = string.Empty;

        public string Stripe_Paymentid = string.Empty;

        protected string SessionId = string.Empty;

        public string stripeUrl = string.Empty;

        protected string StripePaymentLink = string.Empty;

        protected Random rGen;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

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

        public payment_information()
        {
        }

        protected void BackLink_onclick(object sender, EventArgs e)
        {
            this.Session["PaymentStep"] = "true";
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrdernew.aspx?OrdKey=", this.OrderKey, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrdernew", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void btnApprEmail_Save_Click(object sender, EventArgs e)
        {
            this.OrderPayment(false);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
        }

        public string GenPassWithCap(int i)
        {
            this.rGen = new Random();
            int num = 0;
            string str = "";
            for (int i1 = 0; i1 <= i; i1++)
            {
                num = this.rGen.Next(0, 60);
                str = string.Concat(str, this.strCharacters[num]);
            }
            return str;
        }

        private void Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType, string RequiredDate, string Comments, string OrderTitle, string OrderNo, string strMultipleCartID, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (IsOrdered == "no")
            {
                if (this.isLoginInfo != "0")
                {
                    ClientID = OrderBasePage.Insert_CustomerOn_Order((long)this.CompanyID, StoreUserID, this.AccountID, BillingAddressID, ShippingAddressID, "no", this.CreatedDate, "", "");
                }
                else if (this.Session["CommonClient"] != null)
                {
                    ClientID = (long)Convert.ToInt32(this.Session["CommonClient"]);
                }
            }
            this.TotalPrice = new decimal(0);
            this.Tax = new decimal(0);
            this.OrderShipping = new decimal(0);
            foreach (DataRow row in CartBasePage.Select_CartItems(CookieID, "", StoreUserID).Rows)
            {
                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                this.Tax = this.Tax + Convert.ToDecimal(row["CartTax"]);
                this.OrderShipping = this.OrderShipping + Convert.ToDecimal(row["CartShipping"]);
            }
            string str1 = DateTime.Now.ToString();
            this.OrderDate = Convert.ToDateTime(str1);
            string str2 = this.comm.date_Check_new(this.DateFormat, this.objBc.ReplaceSingleQuote(RequiredDate.ToString()));
            long num = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, this.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(str2), Comments, this.OrderKey, OrderTitle, OrderNo, CostCentreID, this.BT_OrderID, this.BT_AuthorizationCode, (long)0, this.Stripe_Paymentid);
            this.OrderID = num;
            this.hdn_OrderID.Value = this.OrderID.ToString();
            if (this.IsValidAgent)
            {
                string value = string.Empty;
                if (base.Request.Cookies["agentcode"] != null)
                {
                    value = base.Request.Cookies["agentcode"].Value;
                }
                OrderBasePage.Insert_AgentCode_Details(num, value, this.hdnsecretcode.Value);
            }
            DataTable dataTable = CartBasePage.Select_CartItems("", "", StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                bool flag = false;
                if (!string.IsNullOrEmpty(this.Prod_Id))
                {
                    string[] strArrays = this.Prod_Id.Split(new char[] { '$' });
                    int num1 = 0;
                    while (num1 < (int)strArrays.Length)
                    {
                        if (strArrays[num1].ToString() != dataRow["ProductID"].ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                OrderBasePage.Insert_OrderItemDetails_MIS(Convert.ToInt64(dataRow["CartItemID"].ToString()), flag, num, (long)this.CompanyID, StoreUserID, dataTable.Rows.Count);
                object[] secureDocPath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString() };
                empty = string.Concat(secureDocPath);
                if (dataRow["PrintReadyFile"].ToString() != "")
                {
                    object[] objArray = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(objArray)))
                    {
                        object[] secureDocPath1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(secureDocPath1));
                    }
                    if (System.IO.File.Exists(empty))
                    {
                        object[] objArray1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        string str3 = string.Concat(objArray1);
                        if (!Directory.Exists(str3))
                        {
                            Directory.CreateDirectory(str3);
                        }
                        System.IO.File.Copy(empty, string.Concat(str3, dataRow["PrintReadyFile"].ToString()), true);
                    }
                }
                if (dataRow["ReportFileName"] == null && !(dataRow["ReportFileName"].ToString() != ""))
                {
                    continue;
                }
                object[] secureDocPath2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["ReportFileName"].ToString() };
                str = string.Concat(secureDocPath2);
                object[] objArray2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                if (!Directory.Exists(string.Concat(objArray2)))
                {
                    object[] secureDocPath3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    Directory.CreateDirectory(string.Concat(secureDocPath3));
                }
                if (!System.IO.File.Exists(str))
                {
                    continue;
                }
                object[] objArray3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                string str4 = string.Concat(objArray3);
                if (!Directory.Exists(str4))
                {
                    Directory.CreateDirectory(str4);
                }
                System.IO.File.Copy(str, string.Concat(str4, dataRow["ReportFileName"].ToString()), true);
            }
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num, (long)this.CompanyID, StoreUserID, (long)dataTable.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num);
            if (this.ddl_payments.SelectedValue.ToString() == "ST" && num > (long)0)
            {
                //OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 15, this.OrderDate, "", this.txt_HolderName.Text, this.hdn_SelectedCardType.Value, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue), this.txt_verification.Text, this.txt_cardNumber.Text);
                OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 15, this.OrderDate, "", "","",0, 0, "", "");
                return;
            }

        }
        protected void OnClick_lnkbtnOrder(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
            {
                base.Request.Params["Tp"].ToString();
                base.Request.Params["Tx"].ToString();
            }
            string empty1 = string.Empty;
            bool flag = OrderBasePage.Fetch_Stock_Mgmt_Exists((long)this.CompanyID);
            if (this.Session["MultipleCartID"] != null)
            {
                DataSet dataSet = OrderBasePage.Select_OrderItems_BeforeOrder(this.StoreUserID, this.Session["MultipleCartID"].ToString());
                DataTable item = dataSet.Tables[0];
                if (item.Rows.Count > 0)
                {
                    foreach (DataRow row in item.Rows)
                    {
                        if (!(row["IsStockItem"].ToString().ToLower() == "true") || !(row["MainBackOrder"].ToString().ToLower() == "true") || !(row["AvailableQuantity"].ToString() != "") && row["AvailableQuantity"] == null || !(row["Quantity"].ToString() != "") && row["Quantity"] == null || !(row["IsBackOrder"].ToString() == "1") || !(row["AvailableQuantity"].ToString() != ""))
                        {
                            continue;
                        }
                        if (row["DrawStockFrom"].ToString().ToLower() != "m")
                        {
                            if (Convert.ToInt32(row["AvailableQuantity"].ToString()) >= Convert.ToInt32(row["Quantity"].ToString()) || !flag)
                            {
                                continue;
                            }
                            this.IsBackOrder = true;
                            payment_information paymentInformation = this;
                            paymentInformation.Prod_Id = string.Concat(paymentInformation.Prod_Id, row["ProductID"].ToString(), "$");
                        }
                        else
                        {
                            DataTable dataTable = OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(row["ProductID"]), Convert.ToInt16(row["Quantity"]), true);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (Convert.ToInt32(dataRow["AvailableQuantity"].ToString()) >= Convert.ToInt32(row["Quantity"].ToString()) || !flag)
                                {
                                    continue;
                                }
                                this.IsBackOrder = true;
                                payment_information paymentInformation1 = this;
                                paymentInformation1.Prod_Id = string.Concat(paymentInformation1.Prod_Id, row["ProductID"].ToString(), "$");
                            }
                        }
                    }
                }
            }
            DataSet adminBackORDSelectIsActiveType = OrderBasePage.EmailToAdminBackORD_SelectIsActiveType((long)this.CompanyID);
            DataTable item1 = adminBackORDSelectIsActiveType.Tables[0];
            if (item1.Rows.Count > 0 && flag)
            {
                foreach (DataRow row1 in item1.Rows)
                {
                    this.BCKORDERTYPE = row1["IsActive"].ToString();
                }
            }
            DataSet adminSelectIsActiveType = OrderBasePage.EmailToAdmin_SelectIsActiveType((long)this.CompanyID);
            DataTable dataTable1 = adminSelectIsActiveType.Tables[0];
            if (dataTable1.Rows.Count > 0)
            {
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    this.NEWORDER = dataRow1["IsActive"].ToString();
                }
            }
            try
            {
                this.OrderPayment(true);

            }
            catch (Exception ex)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='"+url+"';", true);
            }
        }

        public bool OrderPayment(bool IsApproved)
        {
            bool flag;
            IEnumerator enumerator;
            IDisposable disposable;
            string[] keySeparator;
            string empty = string.Empty;
            string[] str;
            string currency = "";
            DataTable currencySymbolCurrency = CMSBasePage.Get_CurrencySymbol_Currency_Company(this.CompanyID);
            if (currencySymbolCurrency != null)
            {
                currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
            }
            if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
            {
                base.Request.Params["Tp"].ToString();
                base.Request.Params["Tx"].ToString();
            }
            string empty1 = string.Empty;
            if (this.Session["MultipleCartID"] != null)
            {
                empty1 = this.Session["MultipleCartID"].ToString();
            }
            if (this.Session["InsertOrder"] != null)
            {
                DataTable item = (DataTable)this.Session["InsertOrder"];
                if (item != null)
                {
                    IEnumerator enumerator1 = item.Rows.GetEnumerator();
                    try
                    {
                        while (enumerator1.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator1.Current;
                            string text = string.Empty;
                            if (this.ddl_payments.SelectedValue.ToString() == "PP")
                            {
                                if (this.ddl_payments.SelectedValue.ToString() != "PP")
                                {
                                    continue;
                                }
                                this.Session["BillingAddress"] = current["InvoiceAddressID"].ToString();
                                this.Session["ShippingAddress"] = current["DeliveryAddressID"].ToString();
                                this.Session["RequiredDate"] = current["RequiredBy"].ToString();
                                this.Session["Comments"] = current["Comments"].ToString();
                                this.Session["OrderTitle"] = current["OrderTitle"].ToString();
                                this.Session["UserRefOrderNo"] = current["OrderNumber"].ToString();
                                this.Session["PP_IsBackOrder"] = this.IsBackOrder;
                                this.Session["PP_BCKORDERTYPE"] = this.BCKORDERTYPE;
                                this.Session["PP_NEWORDER"] = this.NEWORDER;
                                this.Session["PP_BackOrderProducts"] = this.Prod_Id;
                                if (!ConnectionClass.IsAdvancePayPal)
                                {
                                    base.Response.Redirect(string.Concat(this.strSitepath, "checkout_paypal.aspx"));
                                }
                                else
                                {
                                    base.Response.Redirect(string.Concat(this.strSitepath, "advanced_paypalapi.aspx"));
                                }
                            }
                            if (this.ddl_payments.SelectedValue.ToString() == "ST")
                            {
                                //if (this.rbnAmericanID.Checked)
                                //{
                                //    this.hdn_SelectedCardType.Value = "american";
                                //}
                                //else if (this.rbnVisaID.Checked)
                                //{
                                //    this.hdn_SelectedCardType.Value = "visa";
                                //}
                                //else if (this.rbnDiscoverID.Checked)
                                //{
                                //    this.hdn_SelectedCardType.Value = "discover";
                                //}
                                //else if (this.rbnMasterCardID.Checked)
                                //{
                                //    this.hdn_SelectedCardType.Value = "mastercard";
                                //}
                                //text = "Stripe Credit Card";
                                string str2 = string.Empty;
                                bool flag1 = false;
                                string empty3 = string.Empty;
                                string str3 = string.Empty;
                                string empty4 = string.Empty;
                                string str4 = string.Empty;
                                string empty5 = string.Empty;
                                long num = (long)0;
                                decimal totalPrice = new decimal(0);
                                string str5 = string.Empty;
                                string empty6 = string.Empty;
                                string str6 = string.Empty;
                                string empty7 = string.Empty;
                                string str7 = string.Empty;
                                string empty8 = string.Empty;
                                string str8 = string.Empty;
                                string str9 = ConnectionClass.ServerName.ToString();
                                DataTable dataTable = CartBasePage.Select_CartItems(current["SessionKey"].ToString(), "", this.StoreUserID);
                                enumerator1 = dataTable.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator1.MoveNext())
                                    {
                                        DataRow dataRow = (DataRow)enumerator1.Current;
                                        this.TotalPrice = this.TotalPrice + Convert.ToDecimal(dataRow["CartTotalPrice"].ToString());
                                        this.Tax = Convert.ToDecimal(dataRow["Tax"]);
                                        this.OrderShipping = Convert.ToDecimal(dataRow["TotalCartAdditionalPrice"]);
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator1 as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                                decimal totalPrice1 = ((this.TotalPrice + this.OrderShipping) * this.Tax) / new decimal(100);
                                //long totalPrice1 = Convert.ToInt64((this.TotalPrice + this.OrderShipping) * this.Tax);
                                totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
                                //totalPrice = Convert.ToInt64(totalPrice);
                                long TAmount = Convert.ToInt64((totalPrice) * 100);
                                long num1 = Convert.ToInt64(current["InvoiceAddressID"]);
                                Convert.ToInt64(current["DeliveryAddressID"]);
                                num = num1;
                                BaseClass baseClass = new BaseClass();
                                DataTable dataTable1 = OrderBasePage.Select_BrainTree_Details(this.AccountID, this.StoreUserID);
                                DataTable dataTable2 = OrderBasePage.Select_BillingShippingAddress_OnAddressID(this.StoreUserID, num);
                                enumerator1 = dataTable2.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator1.MoveNext())
                                    {
                                        DataRow current1 = (DataRow)enumerator1.Current;
                                        str5 = baseClass.SpecialDecode(current1["Address1"].ToString());
                                        empty6 = baseClass.SpecialDecode(current1["Address2"].ToString());
                                        str6 = baseClass.SpecialDecode(current1["Address3"].ToString());
                                        empty7 = baseClass.SpecialDecode(current1["Address4"].ToString());
                                        empty8 = baseClass.SpecialDecode(current1["Address5"].ToString());
                                        str7 = baseClass.SpecialDecode(current1["Country"].ToString());
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator1 as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                                str = new string[] { str5, ",", empty6, ",", str6, ",", empty7 };
                                str8 = string.Concat(str);
                                enumerator1 = dataTable1.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator1.MoveNext())
                                    {
                                        DataRow dataRow1 = (DataRow)enumerator1.Current;
                                        str2 = dataRow1["BrainTreeMerchantID"].ToString();
                                        flag1 = Convert.ToBoolean(dataRow1["isBrainTreeLive"]);
                                        empty3 = dataRow1["BrainTreePublicKey"].ToString();
                                        str3 = dataRow1["BrainTreePrivateKey"].ToString();
                                        empty4 = baseClass.SpecialDecode(dataRow1["FirstName"].ToString());
                                        str4 = baseClass.SpecialDecode(dataRow1["LastName"].ToString());
                                        empty5 = baseClass.SpecialDecode(dataRow1["EmailID"].ToString());
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator1 as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                                Braintree.Environment pRODUCTION = Braintree.Environment.PRODUCTION;
                                if (str2.Length <= 0)
                                {
                                    DataTable dataTable3 = OrderBasePage.Select_details_ClientInfo((long)this.CompanyID, str9);
                                    enumerator1 = dataTable3.Rows.GetEnumerator();
                                    try
                                    {
                                        while (enumerator1.MoveNext())
                                        {
                                            DataRow current2 = (DataRow)enumerator1.Current;
                                            str2 = current2["BrainTreeMerchantID"].ToString();
                                            flag1 = Convert.ToBoolean(current2["isBrainTreeLive"]);
                                            empty3 = current2["BrainTreePublicKey"].ToString();
                                            str3 = current2["StripePrivateKey"].ToString();
                                        }
                                    }
                                    finally
                                    {
                                        disposable = enumerator1 as IDisposable;
                                        if (disposable != null)
                                        {
                                            disposable.Dispose();
                                        }
                                    }
                                    pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                }
                                else
                                {
                                    pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                }


                                //StripeConfiguration.ApiKey = "sk_test_51JaBp5CWeC7uPATkNUTD4Fh700AToHoowqIUBrGeK3VC7eRFIakQPlYvVwosxPgrKIkrUBkQLjCaEOkX1cZBPNhY00bvTgTT03";

                                //StripeConfiguration.ApiKey = str3;
                                //var option = new TokenCreateOptions
                                //{
                                //    Card = new TokenCardOptions
                                //    {
                                //        //Number = "4242424242424242",
                                //        //ExpMonth = 9,
                                //        //ExpYear = 2022,
                                //        //Cvc = "314",
                                //        Name = this.txt_HolderName.Text,
                                //        Number = this.txt_cardNumber.Text,
                                //        ExpMonth = Convert.ToInt64(this.ddl_month.SelectedItem.Text),
                                //        ExpYear = Convert.ToInt64(this.ddl_year.SelectedItem.Text),
                                //        Cvc = this.txt_verification.Text,
                                //        //CardholderName = this.txt_HolderName.Text
                                //    },
                                //};
                                //var service = new TokenService();
                                //var res = service.Create(option);
                                //var options = new ChargeCreateOptions
                                //{
                                //    //Amount = Convert.ToInt64(totalPrice),
                                //    Amount = TAmount,
                                //    Currency = currency == "" ? "AUD" : currency,
                                //    Source = res.Id, // obtained with Stripe.js
                                //    Description = current["OrderNumber"].ToString(),
                                //};
                                //var service1 = new ChargeService();
                                //// service1.Create(options);
                                //var res3 = service1.Create(options);
                                //this.Stripe_Paymentid = res3.Id;

                                if (string.IsNullOrEmpty(this.SessionId))
                                {
                                    StripeConfiguration.ApiKey = str3;
                                    string SuccessUrl = this.strSitepath + "/payment_information.aspx?stripe_payment=succeeded&Approvred=" + IsApproved + "&Tp=" + empty + "&Tx=" + empty1 + "";
                                    string CancelUrl = HttpContext.Current.Request.Url.AbsoluteUri;
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
                                                Name = current["OrderTitle"].ToString() == "" ? dataTable.Rows[0]["ItemTitle"].ToString() : current["OrderTitle"].ToString(),
                                                Amount = TAmount,
                                                Quantity = 1,
                                                Currency = currency == "" ? "AUD" : currency,
                                                Description = "Payment through checkout"  ,
                                            },
                                        },
                                        Mode = "payment",
                                    };
                                    var service = new SessionService();
                                    Session session = service.Create(options);
                                    string paymentint = session.PaymentIntentId;
                                    Session["Stripe_Payment_ID"] = paymentint;
                                    this.SessionId = session.Id;
                                    this.stripeUrl = session.Url;
                                }
                                string[] Stripelink = new string[] { "https://checkout.stripe.com/pay/", this.SessionId, "#fidkdWxOYHwnPyd1blpxYHZxWjA0T2RHdTBGUmBGMnBVRFFudWFEU0lzTFNTZzRhdz13R1ZGQUs9bG9MMm1wTFVySG5BTmlucHBndXxxdFJ3QmdpMEJBbmNGSHM9b018YEh0Y21dUHdzaVdfNTVgSX1QSFVibicpJ2hsYXYnP34nYnBsYSc%2FJ0tEJyknaHBsYSc%2FJ0tEJykndmxhJz8nS0QneCknZ2BxZHYnP15YKSdpZHxqcHFRfHVgJz8ndmxrYmlgWmxxYGgnKSd3YGNgd3dgd0p3bGJsayc%2FJ21xcXU%2FKippamZkaW1qdnE%2FMzQxMzEneCUl" };
                                this.StripePaymentLink = string.Concat(Stripelink);
                                this.StripePaymentLink = this.stripeUrl;
                                base.Response.Redirect(this.StripePaymentLink);

                            }

                            else
                            {
                                if (this.ddl_payments.SelectedValue.ToString() == "BT" || this.ddl_payments.SelectedValue.ToString() == "ST")
                                {
                                    //    text = this.ddl_payments.SelectedItem.Text;
                                    //}
                                    //else
                                    //{
                                    if (this.ddl_payments.SelectedValue.ToString() == "BT")
                                    {
                                        if (this.rbnAmericanID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "american";
                                        }
                                        else if (this.rbnVisaID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "visa";
                                        }
                                        else if (this.rbnDiscoverID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "discover";
                                        }
                                        else if (this.rbnMasterCardID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "mastercard";
                                        }
                                        text = this.objLanguage.GetLanguageConversion("Braintree_Credit_Card");
                                        string str1 = string.Empty;
                                        bool flag1 = false;
                                        string empty2 = string.Empty;
                                        string str2 = string.Empty;
                                        string empty3 = string.Empty;
                                        string str3 = string.Empty;
                                        string empty4 = string.Empty;
                                        long num = (long)0;
                                        decimal totalPrice = new decimal(0);
                                        string str4 = string.Empty;
                                        string empty5 = string.Empty;
                                        string str5 = string.Empty;
                                        string empty6 = string.Empty;
                                        string str6 = string.Empty;
                                        string empty7 = string.Empty;
                                        string str7 = string.Empty;
                                        string str8 = ConnectionClass.ServerName.ToString();
                                        DataTable dataTable = CartBasePage.Select_CartItems(current["SessionKey"].ToString(), "", this.StoreUserID);
                                        enumerator = dataTable.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator.MoveNext())
                                            {
                                                DataRow dataRow = (DataRow)enumerator.Current;
                                                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(dataRow["CartTotalPrice"].ToString());
                                                this.Tax = Convert.ToDecimal(dataRow["Tax"]);
                                                this.OrderShipping = Convert.ToDecimal(dataRow["TotalCartAdditionalPrice"]);
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        decimal totalPrice1 = ((this.TotalPrice + this.OrderShipping) * this.Tax) / new decimal(100);
                                        totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                        totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
                                        long num1 = Convert.ToInt64(current["InvoiceAddressID"]);
                                        Convert.ToInt64(current["DeliveryAddressID"]);
                                        num = num1;
                                        BaseClass baseClass = new BaseClass();
                                        DataTable dataTable1 = OrderBasePage.Select_BrainTree_Details(this.AccountID, this.StoreUserID);
                                        DataTable dataTable2 = OrderBasePage.Select_BillingShippingAddress_OnAddressID(this.StoreUserID, num);
                                        enumerator = dataTable2.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator.MoveNext())
                                            {
                                                DataRow current1 = (DataRow)enumerator.Current;
                                                str4 = baseClass.SpecialDecode(current1["Address1"].ToString());
                                                empty5 = baseClass.SpecialDecode(current1["Address2"].ToString());
                                                str5 = baseClass.SpecialDecode(current1["Address3"].ToString());
                                                empty6 = baseClass.SpecialDecode(current1["Address4"].ToString());
                                                empty7 = baseClass.SpecialDecode(current1["Address5"].ToString());
                                                str6 = baseClass.SpecialDecode(current1["Country"].ToString());
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        keySeparator = new string[] { str4, ",", empty5, ",", str5, ",", empty6 };
                                        str7 = string.Concat(keySeparator);
                                        enumerator = dataTable1.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator.MoveNext())
                                            {
                                                DataRow dataRow1 = (DataRow)enumerator.Current;
                                                str1 = dataRow1["BrainTreeMerchantID"].ToString();
                                                flag1 = Convert.ToBoolean(dataRow1["isBrainTreeLive"]);
                                                empty2 = dataRow1["BrainTreePublicKey"].ToString();
                                                str2 = dataRow1["BrainTreePrivateKey"].ToString();
                                                empty3 = baseClass.SpecialDecode(dataRow1["FirstName"].ToString());
                                                str3 = baseClass.SpecialDecode(dataRow1["LastName"].ToString());
                                                empty4 = baseClass.SpecialDecode(dataRow1["EmailID"].ToString());
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        Braintree.Environment pRODUCTION = Braintree.Environment.PRODUCTION;
                                        if (str1.Length <= 0)
                                        {
                                            DataTable dataTable3 = OrderBasePage.Select_details_ClientInfo((long)this.CompanyID, str8);
                                            enumerator = dataTable3.Rows.GetEnumerator();
                                            try
                                            {
                                                while (enumerator.MoveNext())
                                                {
                                                    DataRow current2 = (DataRow)enumerator.Current;
                                                    str1 = current2["BrainTreeMerchantID"].ToString();
                                                    flag1 = Convert.ToBoolean(current2["isBrainTreeLive"]);
                                                    empty2 = current2["BrainTreePublicKey"].ToString();
                                                    str2 = current2["BrainTreePrivateKey"].ToString();
                                                }
                                            }
                                            finally
                                            {
                                                disposable = enumerator as IDisposable;
                                                if (disposable != null)
                                                {
                                                    disposable.Dispose();
                                                }
                                            }
                                            pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                        }
                                        else
                                        {
                                            pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                        }
                                        BraintreeGateway braintreeGateway = new BraintreeGateway()
                                        {
                                            Environment = pRODUCTION,
                                            MerchantId = str1,
                                            PublicKey = empty2,
                                            PrivateKey = str2
                                        };
                                        BraintreeGateway braintreeGateway1 = braintreeGateway;
                                        CustomerRequest customerRequest = new CustomerRequest()
                                        {
                                            FirstName = empty3,
                                            LastName = str3,
                                            Email = empty4,
                                            Phone = ""
                                        };
                                        CustomerRequest customerRequest1 = customerRequest;
                                        try
                                        {
                                            braintreeGateway1.Customer.Create(customerRequest1);
                                        }
                                        catch (Exception exception)
                                        {
                                            this.lblPaypalAlertMSG.Text = exception.Message.ToString();
                                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:show();", true);
                                            flag = false;
                                            return flag;
                                        }
                                        braintreeGateway1.Customer.Create(customerRequest1).IsSuccess();
                                        string id = braintreeGateway1.Customer.Create(customerRequest1).Target.Id;
                                        TransactionCreditCardRequest transactionCreditCardRequest = new TransactionCreditCardRequest()
                                        {
                                            Number = this.txt_cardNumber.Text,
                                            ExpirationMonth = this.ddl_month.SelectedItem.Text,
                                            ExpirationYear = this.ddl_year.SelectedItem.Text,
                                            CVV = this.txt_verification.Text,
                                            CardholderName = this.txt_HolderName.Text
                                        };
                                        AddressRequest addressRequest = new AddressRequest()
                                        {
                                            CountryName = str6,
                                            StreetAddress = str7,
                                            PostalCode = empty7
                                        };
                                        TransactionRequest transactionRequest = new TransactionRequest()
                                        {
                                            OrderId = "",
                                            CustomerId = id,
                                            CreditCard = transactionCreditCardRequest,
                                            Amount = totalPrice,
                                            BillingAddress = addressRequest,
                                            ShippingAddress = addressRequest
                                        };
                                        TransactionOptionsRequest transactionOptionsRequest = new TransactionOptionsRequest()
                                        {
                                            SubmitForSettlement = new bool?(true)
                                        };
                                        transactionRequest.Options = transactionOptionsRequest;
                                        Result<Transaction> result = braintreeGateway1.Transaction.Sale(transactionRequest);
                                        if (!result.IsSuccess())
                                        {
                                            string empty8 = string.Empty;
                                            List<ValidationError>.Enumerator enumerator2 = result.Errors.DeepAll().GetEnumerator();
                                            try
                                            {
                                                while (enumerator2.MoveNext())
                                                {
                                                    empty8 = string.Concat(empty8, enumerator2.Current.Message);
                                                }
                                            }
                                            finally
                                            {
                                                ((IDisposable)enumerator2).Dispose();
                                            }
                                            if (!string.IsNullOrEmpty(empty8))
                                            {
                                                this.lblPaypalAlertMSG.Text = empty8;
                                            }
                                            else
                                            {
                                                this.lblPaypalAlertMSG.Text = result.Message.ToString();
                                            }
                                            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:show();", true);
                                            flag = false;
                                            return flag;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                this.BT_OrderID = result.Target.Id.ToString();
                                            }
                                            catch
                                            {
                                                this.BT_OrderID = "";
                                            }
                                            try
                                            {
                                                this.BT_AuthorizationCode = result.Target.ProcessorAuthorizationCode.ToString();
                                            }
                                            catch
                                            {
                                                this.BT_AuthorizationCode = "";
                                            }
                                        }
                                    }
                                    if (this.ddl_payments.SelectedValue.ToString() == "ST")
                                    {
                                        if (this.rbnAmericanID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "american";
                                        }
                                        else if (this.rbnVisaID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "visa";
                                        }
                                        else if (this.rbnDiscoverID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "discover";
                                        }
                                        else if (this.rbnMasterCardID.Checked)
                                        {
                                            this.hdn_SelectedCardType.Value = "mastercard";
                                        }
                                        text = "Stripe Credit Card";
                                        string str2 = string.Empty;
                                        bool flag1 = false;
                                        string empty3 = string.Empty;
                                        string str3 = string.Empty;
                                        string empty4 = string.Empty;
                                        string str4 = string.Empty;
                                        string empty5 = string.Empty;
                                        long num = (long)0;
                                        decimal totalPrice = new decimal(0);
                                        string str5 = string.Empty;
                                        string empty6 = string.Empty;
                                        string str6 = string.Empty;
                                        string empty7 = string.Empty;
                                        string str7 = string.Empty;
                                        string empty8 = string.Empty;
                                        string str8 = string.Empty;
                                        string str9 = ConnectionClass.ServerName.ToString();
                                        DataTable dataTable = CartBasePage.Select_CartItems(current["SessionKey"].ToString(), "", this.StoreUserID);
                                        enumerator1 = dataTable.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator1.MoveNext())
                                            {
                                                DataRow dataRow = (DataRow)enumerator1.Current;
                                                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(dataRow["CartTotalPrice"].ToString());
                                                this.Tax = Convert.ToDecimal(dataRow["Tax"]);
                                                this.OrderShipping = Convert.ToDecimal(dataRow["TotalCartAdditionalPrice"]);
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator1 as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        decimal totalPrice1 = ((this.TotalPrice + this.OrderShipping) * this.Tax) / new decimal(100);
                                        //long totalPrice1 = Convert.ToInt64((this.TotalPrice + this.OrderShipping) * this.Tax);
                                        totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                        totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
                                        //totalPrice = Convert.ToInt64(totalPrice);
                                        long TAmount = Convert.ToInt64((totalPrice) * 100);
                                        long num1 = Convert.ToInt64(current["InvoiceAddressID"]);
                                        Convert.ToInt64(current["DeliveryAddressID"]);
                                        num = num1;
                                        BaseClass baseClass = new BaseClass();
                                        DataTable dataTable1 = OrderBasePage.Select_BrainTree_Details(this.AccountID, this.StoreUserID);
                                        DataTable dataTable2 = OrderBasePage.Select_BillingShippingAddress_OnAddressID(this.StoreUserID, num);
                                        enumerator1 = dataTable2.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator1.MoveNext())
                                            {
                                                DataRow current1 = (DataRow)enumerator1.Current;
                                                str5 = baseClass.SpecialDecode(current1["Address1"].ToString());
                                                empty6 = baseClass.SpecialDecode(current1["Address2"].ToString());
                                                str6 = baseClass.SpecialDecode(current1["Address3"].ToString());
                                                empty7 = baseClass.SpecialDecode(current1["Address4"].ToString());
                                                empty8 = baseClass.SpecialDecode(current1["Address5"].ToString());
                                                str7 = baseClass.SpecialDecode(current1["Country"].ToString());
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator1 as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        str = new string[] { str5, ",", empty6, ",", str6, ",", empty7 };
                                        str8 = string.Concat(str);
                                        enumerator1 = dataTable1.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator1.MoveNext())
                                            {
                                                DataRow dataRow1 = (DataRow)enumerator1.Current;
                                                str2 = dataRow1["BrainTreeMerchantID"].ToString();
                                                flag1 = Convert.ToBoolean(dataRow1["isBrainTreeLive"]);
                                                empty3 = dataRow1["BrainTreePublicKey"].ToString();
                                                str3 = dataRow1["BrainTreePrivateKey"].ToString();
                                                empty4 = baseClass.SpecialDecode(dataRow1["FirstName"].ToString());
                                                str4 = baseClass.SpecialDecode(dataRow1["LastName"].ToString());
                                                empty5 = baseClass.SpecialDecode(dataRow1["EmailID"].ToString());
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator1 as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                        Braintree.Environment pRODUCTION = Braintree.Environment.PRODUCTION;
                                        if (str2.Length <= 0)
                                        {
                                            DataTable dataTable3 = OrderBasePage.Select_details_ClientInfo((long)this.CompanyID, str9);
                                            enumerator1 = dataTable3.Rows.GetEnumerator();
                                            try
                                            {
                                                while (enumerator1.MoveNext())
                                                {
                                                    DataRow current2 = (DataRow)enumerator1.Current;
                                                    str2 = current2["BrainTreeMerchantID"].ToString();
                                                    flag1 = Convert.ToBoolean(current2["isBrainTreeLive"]);
                                                    empty3 = current2["BrainTreePublicKey"].ToString();
                                                    str3 = current2["StripePrivateKey"].ToString();
                                                }
                                            }
                                            finally
                                            {
                                                disposable = enumerator1 as IDisposable;
                                                if (disposable != null)
                                                {
                                                    disposable.Dispose();
                                                }
                                            }
                                            pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                        }
                                        else
                                        {
                                            pRODUCTION = (flag1.ToString().ToLower() != "true" ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION);
                                        }


                                        //StripeConfiguration.ApiKey = "sk_test_51JaBp5CWeC7uPATkNUTD4Fh700AToHoowqIUBrGeK3VC7eRFIakQPlYvVwosxPgrKIkrUBkQLjCaEOkX1cZBPNhY00bvTgTT03";

                                        StripeConfiguration.ApiKey = str3;
                                        var option = new TokenCreateOptions
                                        {
                                            Card = new TokenCardOptions
                                            {
                                                //Number = "4242424242424242",
                                                //ExpMonth = 9,
                                                //ExpYear = 2022,
                                                //Cvc = "314",
                                                Name = this.txt_HolderName.Text,
                                                Number = this.txt_cardNumber.Text,
                                                ExpMonth = Convert.ToInt64(this.ddl_month.SelectedItem.Text),
                                                ExpYear = Convert.ToInt64(this.ddl_year.SelectedItem.Text),
                                                Cvc = this.txt_verification.Text,
                                                //CardholderName = this.txt_HolderName.Text
                                            },
                                        };
                                        var service = new TokenService();
                                        var res = service.Create(option);
                                        var options = new ChargeCreateOptions
                                        {
                                            //Amount = Convert.ToInt64(totalPrice),
                                            Amount = TAmount,
                                            Currency = currency==""?"AUD": currency,
                                            Source = res.Id, // obtained with Stripe.js
                                            Description = current["OrderNumber"].ToString(),
                                        };
                                        var service1 = new ChargeService();
                                        // service1.Create(options);
                                        var res3 = service1.Create(options);
                                        this.Stripe_Paymentid = res3.Id;

                                    }

                                }
                                else
                                {
                                    text = this.ddl_payments.SelectedItem.Text;
                                }
                                if (!(current["OrderID"].ToString() == "") && !(current["OrderID"].ToString() == "0"))
                                {
                                    continue;
                                }
                                this.Insert_Order(current["SessionKey"].ToString(), Convert.ToInt64(current["StoreUserID"]), Convert.ToInt64(current["InvoiceAddressID"]), Convert.ToInt64(current["DeliveryAddressID"]), Convert.ToInt64(current["ClientID"]), current["IsOrdered"].ToString(), text, current["RequiredBy"].ToString(), current["Comments"].ToString(), current["OrderTitle"].ToString(), current["OrderNumber"].ToString(), empty1, (long)0, (long)0, IsApproved, Convert.ToInt64(current["CostCentreID"]));
                                DataTable dataTable4 = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_OrderID.Value), this.StoreUserID);
                                enumerator = dataTable4.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator.MoveNext())
                                    {
                                        DataRow dataRow2 = (DataRow)enumerator.Current;
                                        this.OrderKey = dataRow2["OrderKey"].ToString();
                                        long num2 = Convert.ToInt64(dataRow2["ProductID"]);
                                        int num3 = Convert.ToInt32(dataRow2["Quantity"]);
                                        decimal num4 = Convert.ToDecimal(dataRow2["UnitPrice"]);
                                        long num5 = Convert.ToInt64(dataRow2["EstimateItemID"]);
                                        long num6 = Convert.ToInt64(dataRow2["OrderItemID"]);
                                        BaseClass baseClass1 = new BaseClass();
                                        string str9 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                        string str10 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                        string str11 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                        if (!(str9 == "p") && !(str9 == "a"))
                                        {
                                            continue;
                                        }
                                        DataTable dataTable5 = baseClass1.ProductStockType_Select((long)this.CompanyID, num2);
                                        IEnumerator enumerator3 = dataTable5.Rows.GetEnumerator();
                                        try
                                        {
                                            while (enumerator3.MoveNext())
                                            {
                                                DataRow current3 = (DataRow)enumerator3.Current;
                                                if (current3["DrawStockFrom"].ToString().ToLower() == "s")
                                                {
                                                    baseClass1.StockAllocationProcess((long)this.CompanyID, num2, (long)0, num3, str10, "self", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                                }
                                                else if (current3["DrawStockFrom"].ToString().ToLower() == "o")
                                                {
                                                    baseClass1.StockAllocation_Others((long)this.CompanyID, num2, num3, str10, Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                                }
                                                else if (current3["DrawStockFrom"].ToString().ToLower() != "a")
                                                {
                                                    if (current3["DrawStockFrom"].ToString().ToLower() != "m")
                                                    {
                                                        continue;
                                                    }
                                                    DataTable dataTable6 = OrderBasePage.OtherMultipleProductDetails_Select(num2, num3, true);
                                                    IEnumerator enumerator4 = dataTable6.Rows.GetEnumerator();
                                                    try
                                                    {
                                                        while (enumerator4.MoveNext())
                                                        {
                                                            DataRow dataRow3 = (DataRow)enumerator4.Current;
                                                            baseClass1.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow3["KitItemID"].ToString()), num2, num3, str10, "multiple", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        disposable = enumerator4 as IDisposable;
                                                        if (disposable != null)
                                                        {
                                                            disposable.Dispose();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num2, num3, str10, "additional option", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID, Convert.ToInt64(this.hdn_OrderID.Value), num6);
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            disposable = enumerator3 as IDisposable;
                                            if (disposable != null)
                                            {
                                                disposable.Dispose();
                                            }
                                        }
                                    }
                                }
                                finally
                                {
                                    disposable = enumerator as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                            }
                        }
                        goto Label0;
                    }
                    finally
                    {
                        disposable = enumerator1 as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                    return flag;
                }
            }
        Label0:
            if (this.ddl_payments.SelectedValue.ToString() == "CC")
            {
                if (this.rbnAmericanID.Checked)
                {
                    this.CardType = "American";
                }
                else if (this.rbnVisaID.Checked)
                {
                    this.CardType = "Visa";
                }
                else if (this.rbnMasterCardID.Checked)
                {
                    this.CardType = "MasterCard";
                }
                else if (this.rbnDiscoverID.Checked)
                {
                    this.CardType = "Discover";
                }
                if (this.ddl_payments.SelectedValue.ToString() == "ST")
                {
                    OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_OrderID.Value),"", "", 0, "", "", 0, 0);
                }
                else
                {
                    OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_OrderID.Value), this.txt_HolderName.Text, "", Convert.ToInt64(this.txt_cardNumber.Text), this.CardType, this.txt_verification.Text, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue));
                }
            }
            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order");
            if (this.IsBackOrder)
            {
                if (this.BCKORDERTYPE.ToLower() == "true")
                {
                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order");
                }
            }
            else if (this.NEWORDER.ToLower() == "true")
            {
                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order");
            }
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["PaymentInfo"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
            }
            else
            {
                HttpResponse response = base.Response;
                keySeparator = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                response.Redirect(string.Concat(keySeparator));
            }
            return true;
        }

        public bool StripeOrderCreate(bool IsApproved, string StripePaymentStatus, string Tp, string Tx)
        {
            bool flag;
            IEnumerator enumerator;
            IDisposable disposable;
            string[] keySeparator;
            string empty = string.Empty;
            string[] str;
            string currency = "";
            DataTable currencySymbolCurrency = CMSBasePage.Get_CurrencySymbol_Currency_Company(this.CompanyID);
            if (currencySymbolCurrency != null)
            {
                currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
            }
            //if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
            //{
            //    base.Request.Params["Tp"].ToString();
            //    base.Request.Params["Tx"].ToString();
            //}
            string empty1 = string.Empty;
            if (this.Session["MultipleCartID"] != null)
            {
                empty1 = this.Session["MultipleCartID"].ToString();
            }
            if (this.Session["InsertOrder"] != null)
            {
                DataSet adminSelectIsActiveType = OrderBasePage.EmailToAdmin_SelectIsActiveType((long)this.CompanyID);
                DataTable dataTable1 = adminSelectIsActiveType.Tables[0];
                if (dataTable1.Rows.Count > 0)
                {
                    foreach (DataRow dataRow1 in dataTable1.Rows)
                    {
                        this.NEWORDER = dataRow1["IsActive"].ToString();
                    }
                }
                DataTable item = (DataTable)this.Session["InsertOrder"];
                if (item != null)
                {
                    IEnumerator enumerator1 = item.Rows.GetEnumerator();
                    try
                    {
                        while (enumerator1.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator1.Current;
                            string text = string.Empty;
                            if (!(current["OrderID"].ToString() == "") && !(current["OrderID"].ToString() == "0"))
                            {
                                continue;
                            }
                            text = "Stripe Credit Card";
                            if (Session["Stripe_Payment_ID"] != null)
                            {
                                this.Stripe_Paymentid = Session["Stripe_Payment_ID"].ToString();
                            }
                            this.Insert_Order(current["SessionKey"].ToString(), Convert.ToInt64(current["StoreUserID"]), Convert.ToInt64(current["InvoiceAddressID"]), Convert.ToInt64(current["DeliveryAddressID"]), Convert.ToInt64(current["ClientID"]), current["IsOrdered"].ToString(), text, current["RequiredBy"].ToString(), current["Comments"].ToString(), current["OrderTitle"].ToString(), current["OrderNumber"].ToString(), empty1, (long)0, (long)0, IsApproved, Convert.ToInt64(current["CostCentreID"]));
                            DataTable dataTable4 = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_OrderID.Value), this.StoreUserID);
                            enumerator = dataTable4.Rows.GetEnumerator();
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    DataRow dataRow2 = (DataRow)enumerator.Current;
                                    this.OrderKey = dataRow2["OrderKey"].ToString();
                                    long num2 = Convert.ToInt64(dataRow2["ProductID"]);
                                    int num3 = Convert.ToInt32(dataRow2["Quantity"]);
                                    decimal num4 = Convert.ToDecimal(dataRow2["UnitPrice"]);
                                    long num5 = Convert.ToInt64(dataRow2["EstimateItemID"]);
                                    long num6 = Convert.ToInt64(dataRow2["OrderItemID"]);
                                    BaseClass baseClass1 = new BaseClass();
                                    string str9 = baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                    string str10 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                    string str11 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                    if (!(str9 == "p") && !(str9 == "a"))
                                    {
                                        continue;
                                    }
                                    DataTable dataTable5 = baseClass1.ProductStockType_Select((long)this.CompanyID, num2);
                                    IEnumerator enumerator3 = dataTable5.Rows.GetEnumerator();
                                    try
                                    {
                                        while (enumerator3.MoveNext())
                                        {
                                            DataRow current3 = (DataRow)enumerator3.Current;
                                            if (current3["DrawStockFrom"].ToString().ToLower() == "s")
                                            {
                                                baseClass1.StockAllocationProcess((long)this.CompanyID, num2, (long)0, num3, str10, "self", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                            }
                                            else if (current3["DrawStockFrom"].ToString().ToLower() == "o")
                                            {
                                                baseClass1.StockAllocation_Others((long)this.CompanyID, num2, num3, str10, Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                            }
                                            else if (current3["DrawStockFrom"].ToString().ToLower() != "a")
                                            {
                                                if (current3["DrawStockFrom"].ToString().ToLower() != "m")
                                                {
                                                    continue;
                                                }
                                                DataTable dataTable6 = OrderBasePage.OtherMultipleProductDetails_Select(num2, num3, true);
                                                IEnumerator enumerator4 = dataTable6.Rows.GetEnumerator();
                                                try
                                                {
                                                    while (enumerator4.MoveNext())
                                                    {
                                                        DataRow dataRow3 = (DataRow)enumerator4.Current;
                                                        baseClass1.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow3["KitItemID"].ToString()), num2, num3, str10, "multiple", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID);
                                                    }
                                                }
                                                finally
                                                {
                                                    disposable = enumerator4 as IDisposable;
                                                    if (disposable != null)
                                                    {
                                                        disposable.Dispose();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num2, num3, str10, "additional option", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID, Convert.ToInt64(this.hdn_OrderID.Value), num6);
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        disposable = enumerator3 as IDisposable;
                                        if (disposable != null)
                                        {
                                            disposable.Dispose();
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                disposable = enumerator as IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                        }
                        goto Label0;
                    }
                    finally
                    {
                        disposable = enumerator1 as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                    return flag;
                }
            }
        Label0:
            if (this.ddl_payments.SelectedValue.ToString() == "CC")
            {
                if (this.rbnAmericanID.Checked)
                {
                    this.CardType = "American";
                }
                else if (this.rbnVisaID.Checked)
                {
                    this.CardType = "Visa";
                }
                else if (this.rbnMasterCardID.Checked)
                {
                    this.CardType = "MasterCard";
                }
                else if (this.rbnDiscoverID.Checked)
                {
                    this.CardType = "Discover";
                }
                if (this.ddl_payments.SelectedValue.ToString() == "ST")
                {
                    OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_OrderID.Value), "", "", 0, "", "", 0, 0);
                }
                else
                {
                    OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_OrderID.Value), this.txt_HolderName.Text, "", Convert.ToInt64(this.txt_cardNumber.Text), this.CardType, this.txt_verification.Text, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue));
                }
            }
            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order");
            if (this.IsBackOrder)
            {
                if (this.BCKORDERTYPE.ToLower() == "true")
                {
                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order");
                }
            }
            else if (this.NEWORDER.ToLower() == "true")
            {
                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order");
            }
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["PaymentInfo"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            Session["Stripe_Payment_ID"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
            }
            else
            {
                HttpResponse response = base.Response;
                keySeparator = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                response.Redirect(string.Concat(keySeparator));
            }
            return true;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (EprintConfigurationManager.AppSettings["eprintDocument"] != null)
            {
                this.eprintDocument = EprintConfigurationManager.AppSettings["eprintDocument"];
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            base.Title = commonclass.pageTitle("Payment information", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            this.ServerName = ConnectionClass.ServerName;
            if (this.ServerName.ToLower() == "phoneink" || this.ServerName.ToLower() == "prelive")
            {
                string empty = string.Empty;
                if (base.Request.Cookies["agentcode"] != null)
                {
                    empty = base.Request.Cookies["agentcode"].Value;
                }
                DataTable dataTable = LoginBasePage.Public_User_ClientIDbyAgentCode((long)this.CompanyID, this.AccountID, empty);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsValidAgent = true;
                }
            }
            this.btnOrder.Text = this.objLanguage.GetLanguageConversion("Confirm_Order");
            this.Paypal_ButtonText = this.objLanguage.GetLanguageConversion("Proceed_To_Payment");
            this.OtherOptions_ButtonText = this.objLanguage.GetLanguageConversion("Confirm_Order");
            if (this.comm.GetDisplayValue("isCheckLoginRegister", this.AccountID) == "false")
            {
                this.isLoginInfo = "0";
            }
            
            foreach (DataRow dataRow in LoginBasePage.Select_AccountDetails((long)this.CompanyID, this.AccountID).Rows)
            {
                this.AccountType = dataRow["accountType"].ToString();
                this.DateFormat = dataRow["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(dataRow["createdBy"].ToString());
            }
            if (this.Session["StoreUserID"] == null && this.AccountType == "p" || this.AccountID == (long)0 && this.CompanyID == 0)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                }
            }
            if (this.Session["PaymentInfo"] == null || this.Session["PaymentInfo"].ToString() == "")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "CheckOutnew.aspx"));
            }
            this.Session["PaymentStep"] = "";
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    string str = row1["paymentMode"].ToString().Trim();
                    char[] chrArray = new char[] { ',' };
                    this.paymentMode = str.Split(chrArray);
                    this.defaultpaymentMode = row1["defaultpaymentMode"].ToString();
                    this.hdn_Creditcardtypes.Value = row1["creaditCardTypes"].ToString().Trim();
                    this.hdn_Creditcardtypes_BT.Value = row1["creaditCardTypes"].ToString().Trim();
                    this.hdn_Creditcardtypes_ST.Value = row1["creaditCardTypes"].ToString().Trim();
                }
                for (int i = 0; i < (int)this.paymentMode.Length; i++)
                {
                    if (this.paymentMode[i].ToString() == "CD")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Cash_on_Delivery");
                        this.ddl_payments.Items[i].Value = "CD";
                    }
                    else if (this.paymentMode[i].ToString() == "CH")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Cheque_Money_Order");
                        this.ddl_payments.Items[i].Value = "CH";
                    }
                    else if (this.paymentMode[i].ToString() == "CC")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Credit_Card");
                        this.ddl_payments.Items[i].Value = "CC";
                    }
                    else if (this.paymentMode[i].ToString() == "PP")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("PayPal");
                        this.ddl_payments.Items[i].Value = "PP";
                    }
                    else if (this.paymentMode[i].ToString() == "PI")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Payment_on_Invoice");
                        this.ddl_payments.Items[i].Value = "PI";
                    }
                    else if (this.paymentMode[i].ToString() == "BT")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Credit_Card");
                        this.ddl_payments.Items[i].Value = "BT";
                    }
                    else if (this.paymentMode[i].ToString() == "ST")
                    {
                        this.ddl_payments.Items.Insert(i, " ");
                        this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Credit_Card");
                        this.ddl_payments.Items[i].Value = "ST";
                    }
                }
                if (this.defaultpaymentMode != null)
                {
                    this.ddl_payments.SelectedValue = this.defaultpaymentMode;
                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:show();", true);
            }
            if (HttpContext.Current.Request.QueryString["stripe_payment"] != null)
            {
                bool IsApprovred = Convert.ToBoolean(HttpContext.Current.Request.QueryString["Approvred"].ToString());
                string stripePaymentStatus = HttpContext.Current.Request.QueryString["stripe_payment"].ToString();
                string Tp = HttpContext.Current.Request.QueryString["Tp"].ToString();
                string Tx = HttpContext.Current.Request.QueryString["Tx"].ToString();
                StripeOrderCreate(IsApprovred, stripePaymentStatus, Tp, Tx);
            }
            HtmlImage htmlImage = this.imgAmericanCard;
            object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=cc_amex_icon.jpg&amp;type=r&amp;aid=", this.AccountID, " &amp;cid=", this.CompanyID };
            htmlImage.Src = string.Concat(accountID);
            HtmlImage htmlImage1 = this.imgVisaCard;
            object[] objArray = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=cc_visa_icon.jpg&amp;type=r&amp;aid=", this.AccountID, " &amp;cid=", this.CompanyID };
            htmlImage1.Src = string.Concat(objArray);
            HtmlImage htmlImage2 = this.imgMasterCard;
            object[] accountID1 = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=cc_master_card_icon.jpg&amp;type=r&amp;aid=", this.AccountID, " &amp;cid=", this.CompanyID };
            htmlImage2.Src = string.Concat(accountID1);
            HtmlImage htmlImage3 = this.imgDiscoverCard;
            object[] objArray1 = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=cc_discover_icon.jpg&amp;type=r&amp;aid=", this.AccountID, " &amp;cid=", this.CompanyID };
            htmlImage3.Src = string.Concat(objArray1);
            this.CreatedDate = DateTime.Now;
            if (this.comm.GetDisplayValue("IsHome", this.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.comm.GetDisplayValue("isCheckOrderInfoPublic", this.AccountID) != "false")
            {
                this.li_Order.Style.Add("display", "block");
            }
            else
            {
                this.li_Order.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckAddressInfo", this.AccountID) != "false")
            {
                this.li_Address.Style.Add("display", "block");
            }
            else
            {
                this.li_Address.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckPaymentInfo", this.AccountID) == "false")
            {
                this.li_payment.Attributes.Add("class", "HideArrow");
            }
            if (base.Request.Params["error"] != null)
            {
                try
                {
                    string str1 = base.Request.Params["error"].ToString();
                    string[] strArrays = str1.Split(new char[] { '\u00B6' });
                    string[] strArrays1 = strArrays[0].ToString().Split(new char[] { '=' });
                    string[] strArrays2 = strArrays[2].ToString().Split(new char[] { '=' });
                    Label label = this.lblPaypalAlertMSG;
                    string[] str2 = new string[] { "<span>Error Code / Description:", strArrays1[1].ToString(), " / ", strArrays2[1].ToString(), " </span> <br />" };
                    label.Text = string.Concat(str2);
                    if (!base.IsPostBack)
                    {
                        this.objBc.SetDDLValue(this.ddl_payments, "PP");
                    }
                }
                catch
                {
                }
            }
        }
    }
}