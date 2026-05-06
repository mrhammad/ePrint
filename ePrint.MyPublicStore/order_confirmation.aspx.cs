using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using PayPalExample;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using RewriteModule;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.MyPublicStore
{
    public partial class order_confirmation : BaseClass, IRequiresSessionState
    {
        //protected HtmlGenericControl spn_OrderNo;

        //protected Label lblBackOrder;

        //protected Label lblBackOrder1;

        //protected HtmlGenericControl spnLogout;

        //protected HtmlGenericControl messageboxorderconfirmation;

        //protected Label lblOrderConfirmationValue;

        //protected HtmlGenericControl divOrderConfirmationValue;

        public languageClass objLanguage = new languageClass();

        private commonclass comm = new commonclass();

        private EmailClass Objemail = new EmailClass();

        private BaseClass objBc = new BaseClass();

        private DateTime OrderDate;

        private DateTime CreatedDate;

        public int CompanyID;

        public int UserID;

        public long OrderID;

        public long BillingAddressID;

        public long ShippingAddressID;

        public string ordtype;

        public long ClientID;

        public long StoreUserID;

        public char KeySeparator;

        private string addressIDs;

        private string strSitePath = string.Empty;

        private string AccountType = string.Empty;

        public string PaypalKey;

        public string PaypalType;

        public static long AccountID;

        public string IsOrdered = "no";

        public string FileExtension = string.Empty;

        public string DateFormat = string.Empty;

        public string OrderKey = string.Empty;

        public decimal TotalPrice;

        public decimal Tax;

        public decimal OrderShipping;

        public string IsBackOrder = string.Empty;

        public int AvailableQuantity;

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

        static order_confirmation()
        {
        }

        public order_confirmation()
        {
        }

        public void confirmpaymentbytoken()
        {
            NVPAPICaller nVPAPICaller = new NVPAPICaller();
            NVPCodec nVPCodec = new NVPCodec();
            string empty = string.Empty;
            string item = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string item1 = string.Empty;
            empty = this.Session["token"].ToString();
            if (nVPAPICaller.GetDetails(empty, ref nVPCodec, ref empty1))
            {
                item = nVPCodec["PayerID"];
                empty = nVPCodec["token"];
                str = nVPCodec["PAYMENTREQUEST_0_AMT"];
                item1 = nVPCodec["CURRENCYCODE"];
            }
            NVPCodec nVPCodec1 = new NVPCodec();
            if (nVPAPICaller.ConfirmPayment(str, empty, item, item1, ref nVPCodec1, ref empty1))
            {
                empty = nVPCodec1["token"];
            }
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

        private long Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType)
        {
            commonclass _commonclass = this.comm;
            string dateFormat = this.DateFormat;
            commonclass _commonclass1 = this.comm;
            DateTime now = DateTime.Now;
            //this.CreatedDate = Convert.ToDateTime(_commonclass.date_Check_new(dateFormat, _commonclass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true)));
            var dateString = _commonclass1.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.CreatedDate = Convert.ToDateTime(dateString);
            if (IsOrdered == "no")
            {
                ClientID = OrderBasePage.Insert_CustomerOn_Order((long)this.CompanyID, StoreUserID, order_confirmation.AccountID, BillingAddressID, ShippingAddressID, "no", this.CreatedDate,"","");
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
            string str = DateTime.Now.ToString();
            this.OrderDate = Convert.ToDateTime(str);
            string empty = string.Empty;
            if (this.Session["RequiredDate"] != null)
            {
                string str1 = this.Session["RequiredDate"].ToString();
                empty = this.comm.date_Check_new(this.DateFormat, this.objBc.ReplaceSingleQuote(str1.ToString()));
            }
            string empty1 = string.Empty;
            if (this.Session["Comments"] != null)
            {
                empty1 = this.Session["Comments"].ToString();
            }
            string empty2 = string.Empty;
            if (this.Session["OrderTitle"] != null)
            {
                empty2 = this.Session["OrderTitle"].ToString();
            }
            string str2 = string.Empty;
            if (this.Session["UserRefOrderNo"] != null)
            {
                str2 = this.Session["UserRefOrderNo"].ToString();
            }
            string str3 = this.GenPassWithCap(12);
            this.OrderID = OrderBasePage.Insert_Orders(StoreUserID, order_confirmation.AccountID, "", this.TotalPrice, this.Tax, this.OrderShipping, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(empty), empty1, str3, empty2, str2, (long)0);
            long num = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, order_confirmation.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(empty), empty1, str3, empty2, str2, (long)0, "", "", (long)0, "");
            this.OrderID = num;
            string empty3 = string.Empty;
            if (this.Session["PP_BackOrderProducts"] != null)
            {
                empty3 = this.Session["PP_BackOrderProducts"].ToString();
            }
            DataTable dataTable = CartBasePage.Select_CartItems("", "", StoreUserID);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                bool flag = false;
                if (!string.IsNullOrEmpty(empty3))
                {
                    string[] strArrays = empty3.Split(new char[] { '$' });
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
            }
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num, (long)this.CompanyID, StoreUserID, (long)dataTable.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num);
            return this.OrderID;
        }

        protected void onclick_logout(object sender, EventArgs e)
        {
            HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
            if (item != null)
            {
                commonclass _commonclass = new commonclass();
                SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                sqlCommand.ExecuteNonQuery();
                _commonclass.closeConnection();
                base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
            }
            base.Response.Cookies["ResumeSessionID"].Expires = DateTime.Now.AddDays(-1);
            this.Session["StoreUserID"] = "";
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            base.Response.Redirect("default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                order_confirmation.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitePath = ConnectionClass.SitePath;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                if (this.Session["CommonClient"] != null)
                {
                    this.spnLogout.Visible = false;
                }
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            this.AccountType = this.comm.return_AccountType((long)this.CompanyID, order_confirmation.AccountID);
            if (this.Session["StoreUserID"] == null && this.AccountType == "p" || order_confirmation.AccountID == (long)0 && this.CompanyID == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "login", ConnectionClass.FileExtension));
            }
            base.Title = commonclass.pageTitle("Order Confirmation", Convert.ToInt32(this.CompanyID), Convert.ToInt32(order_confirmation.AccountID));
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                if (base.Request.Params["type"] != null)
                {
                    this.PaypalType = base.Request.Params["type"].ToString();
                }
                if (base.Request.Params["OrdKey"] != null)
                {
                    this.OrderKey = base.Request.Params["OrdKey"].ToString();
                }
                if (base.Request.Params["key"] != null)
                {
                    this.PaypalKey = base.Request.Params["key"].ToString();
                }
                if (base.Request.Params["BID"] != null)
                {
                    this.BillingAddressID = Convert.ToInt64(base.Request.Params["BID"]);
                }
                if (base.Request.Params["SID"] != null)
                {
                    this.ShippingAddressID = Convert.ToInt64(base.Request.Params["SID"]);
                }
            }
            else
            {
                if (RewriteContext.Current.Params["OrdKey"] != null)
                {
                    string str = RewriteContext.Current.Params["OrdKey"].ToString();
                    char[] keySeparator = new char[] { this.KeySeparator };
                    this.OrderKey = str.Split(keySeparator)[1].ToString();
                }
                if (RewriteContext.Current.Params["type"] != null)
                {
                    this.PaypalType = RewriteContext.Current.Params["type"].ToString();
                }
                if (RewriteContext.Current.Params["key"] != null)
                {
                    this.PaypalKey = RewriteContext.Current.Params["key"].ToString();
                }
                if (RewriteContext.Current.Params["BID"] != null)
                {
                    this.BillingAddressID = Convert.ToInt64(RewriteContext.Current.Params["BID"].ToString());
                }
                if (RewriteContext.Current.Params["SID"] != null)
                {
                    this.ShippingAddressID = Convert.ToInt64(RewriteContext.Current.Params["SID"].ToString());
                }
            }
            DataTable dataTable = OrderBasePage.Select_OrderID(this.OrderKey, this.StoreUserID);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.OrderID = Convert.ToInt64(row["OrderID"].ToString());
                }
            }
            DataTable dataTable1 = LoginBasePage.Select_AccountDetails((long)this.CompanyID, order_confirmation.AccountID);
            if (dataTable1.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.DateFormat = dataRow["DateFormat"].ToString();
                    this.UserID = Convert.ToInt32(dataRow["createdBy"].ToString());
                }
            }

            if (this.OrderKey == "0" && this.PaypalType == "1" && this.Session["paypalKey"] != null && this.PaypalKey == this.Session["paypalKey"].ToString())
            {
                string empty = string.Empty;
                if (ConnectionClass.ServerName != null)
                {
                    string serverName = ConnectionClass.ServerName;
                }
                if (ConnectionClass.IsAdvancePayPal)
                {
                    this.confirmpaymentbytoken();
                }
                foreach (DataRow row1 in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.ClientID = Convert.ToInt64(row1["ClientID"].ToString());
                    if (!Convert.ToBoolean(row1["IsOrdered"].ToString()))
                    {
                        this.IsOrdered = "no";
                    }
                    else
                    {
                        this.IsOrdered = "yes";
                    }
                }
                this.OrderID = this.Insert_Order("", this.StoreUserID, Convert.ToInt64(this.BillingAddressID), Convert.ToInt64(this.ShippingAddressID), this.ClientID, this.IsOrdered, "PayPal");
                bool flag = false;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                if (this.Session["PP_IsBackOrder"] != null)
                {
                    flag = Convert.ToBoolean(this.Session["PP_IsBackOrder"]);
                }
                if (this.Session["PP_BCKORDERTYPE"] != null)
                {
                    empty1 = this.Session["PP_BCKORDERTYPE"].ToString();
                }
                if (this.Session["PP_NEWORDER"] != null)
                {
                    str1 = this.Session["PP_NEWORDER"].ToString();
                }
                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order");
                if (flag)
                {
                    if (empty1.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order");
                    }
                }
                else if (str1.ToLower() == "true")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order");
                }
                this.Session["paypalKey"] = null;
                this.Session["InsertOrder"] = null;
                this.Session["Insert_CreditCardDetails"] = null;
                this.Session["CheckOut"] = null;
                this.Session["PaymentInfo"] = null;
                this.Session["ConfirmBeforeOrdernew"] = null;
            }
            string empty2 = string.Empty;
            foreach (DataRow dataRow1 in OrderBasePage.Select_OrderItems(this.OrderID, this.StoreUserID).Rows)
            {
                this.spn_OrderNo.InnerHtml = dataRow1["OrderNo"].ToString();
                this.OrderKey = dataRow1["OrderKey"].ToString();
                this.IsBackOrder = dataRow1["IsBackOrder"].ToString().Trim().ToLower();
                if (!(dataRow1["IsBackOrder"].ToString() == "1") || !(dataRow1["AvailableQuantity"].ToString() != "") && dataRow1["AvailableQuantity"].ToString() == null)
                {
                    continue;
                }
                this.AvailableQuantity = Convert.ToInt32(dataRow1["AvailableQuantity"].ToString());
                empty2 = string.Concat(empty2, this.AvailableQuantity, ",");
            }
            try
            {
                bool flag1 = false;
                bool flag2 = false;
                string[] strArrays = empty2.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    if (Convert.ToInt32(strArrays[i]) > 0)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag1 = true;
                    }
                }
                if (flag1 && flag2)
                {
                    this.lblBackOrder1.Style.Add("display", "block");
                }
                else if (!flag1 || flag2)
                {
                    this.lblBackOrder.Style.Add("display", "none");
                }
                else
                {
                    this.lblBackOrder.Style.Add("display", "block");
                }
            }
            catch
            {
            }
            this.divOrderConfirmationValue.Style.Add("display", "none");
            this.messageboxorderconfirmation.Style.Add("display", "block");
        }
    }
}