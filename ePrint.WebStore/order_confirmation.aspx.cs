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
namespace ePrint.WebStore
{
    public partial class order_confirmation : BaseClass, IRequiresSessionState
    {
        //protected HtmlGenericControl spn_OrderNo;

        //protected Label lblBackOrder;

        //protected Label lblBackOrder1;

        //protected HtmlAnchor A1;

        //protected HtmlGenericControl spnLogout;

        private commonclass comm = new commonclass();

        private storeEmail Objemail = new storeEmail();

        private BaseClass objBc = new BaseClass();

        private DateTime OrderDate;

        private DateTime CreatedDate;

        public languageClass objLanguage = new languageClass();

        public int CompanyID;

        public int UserID;

        public long OrderID;

        public long BillingAddressID;

        public long ShippingAddressID;

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

        public string AccountName = string.Empty;

        public string IsBackOrder = string.Empty;

        public int AvailableQuantity;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public long StoreUserIDBehalf;

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
            if (this.Session["token"] != null)
            {
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
            this.TotalPrice = new decimal(0);
            this.Tax = new decimal(0);
            this.OrderShipping = new decimal(0);
            DataTable dataTable = CartBasePage.Select_MultipleCartItems(CookieID, "", StoreUserID, this.Session["MultipleCartID"].ToString());
            foreach (DataRow row in dataTable.Rows)
            {
                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                this.Tax = this.Tax + Convert.ToDecimal(row["CartTax"]);
                this.OrderShipping = this.OrderShipping + Convert.ToDecimal(row["CartShipping"]);
            }
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            DateTime dateTime = _commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.OrderDate = Convert.ToDateTime(dateTime.ToString());
            string empty = string.Empty;
            if (this.Session["RequiredDate"] != null)
            {
                string str = this.Session["RequiredDate"].ToString();
                empty = this.comm.date_Check_new(this.DateFormat, this.objBc.ReplaceSingleQuote(str.ToString()));
            }
            string empty1 = string.Empty;
            if (this.Session["Comments"] != null)
            {
                empty1 = this.Session["Comments"].ToString();
            }
            string str1 = string.Empty;
            if (this.Session["OrderTitle"] != null)
            {
                str1 = this.Session["OrderTitle"].ToString();
            }
            string empty2 = string.Empty;
            if (this.Session["UserRefOrderNo"] != null)
            {
                empty2 = this.Session["UserRefOrderNo"].ToString();
            }
            string str2 = "n";
            if (this.Session["OrderBehalfType"] != null)
            {
                str2 = this.Session["OrderBehalfType"].ToString();
            }
            string empty3 = string.Empty;
            if (this.Session["PP_ApproverEmail"] != null)
            {
                empty3 = this.Session["PP_ApproverEmail"].ToString();
            }
            long num = (long)0;
            if (this.Session["PP_OrderForUserID"] != null)
            {
                num = Convert.ToInt64(this.Session["PP_OrderForUserID"]);
            }
            long num1 = (long)0;
            if (this.Session["PP_DeptID"] != null)
            {
                num1 = Convert.ToInt64(this.Session["PP_DeptID"]);
            }
            long num2 = (long)0;
            if (this.Session["PP_CostCentreID"] != null)
            {
                num2 = Convert.ToInt64(this.Session["PP_CostCentreID"]);
            }
            bool flag = false;
            if (this.Session["PP_IsApproved"] != null)
            {
                flag = Convert.ToBoolean(this.Session["PP_IsApproved"]);
            }
            long num3 = (long)0;
            string str3 = this.GenPassWithCap(12);
            num3 = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, order_confirmation.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(empty), empty1, str3, str1, empty2, empty3, num, num1, num2, StoreUserID, str2, flag, "", "", (long)0, "");
            this.OrderID = num3;
            string empty4 = string.Empty;
            if (this.Session["PP_BackOrderProducts"] != null)
            {
                empty4 = this.Session["PP_BackOrderProducts"].ToString();
            }
            DataTable dataTable1 = CartBasePage.Select_MultipleCartItems("", "", StoreUserID, this.Session["MultipleCartID"].ToString());
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                bool flag1 = false;
                if (!string.IsNullOrEmpty(empty4))
                {
                    string[] strArrays = empty4.Split(new char[] { '$' });
                    int num4 = 0;
                    while (num4 < (int)strArrays.Length)
                    {
                        if (strArrays[num4].ToString() != dataRow["ProductID"].ToString())
                        {
                            num4++;
                        }
                        else
                        {
                            flag1 = true;
                            break;
                        }
                    }
                }
                string str4 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
                bool flag2 = flag;
                if (!flag && str4.ToLower() == "s" && this.Session["SelfApproval_ItemID"] != null && this.Session["SelfApproval_ItemID"].ToString().Trim() != "")
                {
                    string[] strArrays1 = this.Session["SelfApproval_ItemID"].ToString().Split(new char[] { ',' });
                    int num5 = 0;
                    while (num5 < (int)strArrays1.Length - 1)
                    {
                        if (strArrays1[num5].ToString() != dataRow["CartItemID"].ToString())
                        {
                            num5++;
                        }
                        else
                        {
                            flag2 = true;
                            break;
                        }
                    }
                }
                OrderBasePage.Insert_OrderItemDetails_MIS(Convert.ToInt64(dataRow["CartItemID"].ToString()), flag1, num3, (long)this.CompanyID, flag2, StoreUserID, empty3, ClientID, dataTable1.Rows.Count);
            }
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num3, (long)this.CompanyID, StoreUserID, (long)dataTable1.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num3);
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
            HttpCookie dateTime = base.Response.Cookies["ResumeSessionID"];
            commonclass _commonclass1 = this.comm;
            DateTime dateTime1 = DateTime.Now.AddDays(-1);
            dateTime.Expires = Convert.ToDateTime(_commonclass1.Eprint_return_ActualDate_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true));
            this.Session["StoreUserID"] = "";
            this.Session.Clear();
            this.Session.Abandon();
            GC.Collect();
            base.Response.Redirect(string.Concat(this.strSitePath, "logout.aspx?id=", order_confirmation.AccountID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            char[] keySeparator;
            string[] strArrays;
            int i;

            if (base.Request.Url.ToString().ToLower().IndexOf("handyexpress") != -1)
            {
                ltrLanguageConversionScript.Text = Constants.Constants.LanguageConversionScript_HandyExpress;
            }

            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft' href ='", BaseClass.SitePath, "order_confirmation.aspx'></a>", this.objLanguage.GetLanguageConversion("Order_Confirmation"));
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (!IsPostBack)
            {
                order_confirmation.AccountID = Convert.ToInt64(0);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                order_confirmation.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            DataTable dataTable = LoginBasePage.accounts_getAccountDetails(Convert.ToInt32(order_confirmation.AccountID));
            if (dataTable.Rows.Count > 0)
            {
                this.AccountName = dataTable.Rows[0]["accountName"].ToString();
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
                base.Response.Redirect(string.Concat(this.strSitePath, this.AccountName));
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
                    keySeparator = new char[] { this.KeySeparator };
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
            foreach (DataRow row in OrderBasePage.Select_OrderID(this.OrderKey).Rows)
            {
                this.OrderID = Convert.ToInt64(row["OrderID"].ToString());
                this.StoreUserIDBehalf = Convert.ToInt64(row["StoreUserID"].ToString());
            }
            foreach (DataRow dataRow in LoginBasePage.Select_AccountDetails((long)this.CompanyID, order_confirmation.AccountID).Rows)
            {
                this.DateFormat = dataRow["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(dataRow["createdBy"].ToString());
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
                }
                this.OrderID = this.Insert_Order("", this.StoreUserID, Convert.ToInt64(this.BillingAddressID), Convert.ToInt64(this.ShippingAddressID), this.ClientID, this.IsOrdered, "PayPal");
                string str1 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
                string lower = string.Empty;
                if (this.Session["CatgoryNotReqApproval"] != null)
                {
                    lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
                }
                string empty1 = string.Empty;
                if (this.Session["DeptNotReqApproval"] != null)
                {
                    empty1 = this.Session["DeptNotReqApproval"].ToString().ToLower();
                }
                if (this.Session["ApprovalSystem"] != null)
                {
                    bool flag = false;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    long num = (long)0;
                    if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
                    {
                        str3 = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
                    }
                    if (this.Session["PP_IsBackOrder"] != null)
                    {
                        flag = Convert.ToBoolean(this.Session["PP_IsBackOrder"]);
                    }
                    if (this.Session["PP_BCKORDERTYPE"] != null)
                    {
                        empty2 = this.Session["PP_BCKORDERTYPE"].ToString();
                    }
                    if (this.Session["PP_NEWORDER"] != null)
                    {
                        str2 = this.Session["PP_NEWORDER"].ToString();
                    }
                    if (this.Session["PP_DesignatedApproverEmail"] != null)
                    {
                        empty3 = this.Session["PP_DesignatedApproverEmail"].ToString();
                    }
                    if (this.Session["ApprovalSystem"].ToString() != "on")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                        if (flag)
                        {
                            if (empty2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                            }
                        }
                        else if (str2.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                        }
                    }
                    else
                    {
                        string str4 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                        string str5 = this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                        string empty4 = string.Empty;
                        string empty5 = string.Empty;
                        if (this.Session["PP_PriceValue"] != null)
                        {
                            empty4 = this.Session["PP_PriceValue"].ToString();
                        }
                        if (this.Session["PP_TaxValue"] != null)
                        {
                            empty5 = this.Session["PP_TaxValue"].ToString();
                        }
                        decimal num1 = Convert.ToDecimal(empty4);
                        decimal num2 = num1 + Convert.ToDecimal(empty5);
                        if (str1.ToLower() == "s")
                        {
                            if (!(str4 != "") || !(str4 != "0"))
                            {
                                if (flag && empty2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                }
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str1);
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            }
                            else if (num2 <= Convert.ToInt64(str4))
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                if (flag)
                                {
                                    if (empty2.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                    }
                                }
                                else if (str2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                }
                            }
                            else
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str1);
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            }
                        }
                        else if (empty1 != "false")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            if (flag)
                            {
                                if (empty2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                }
                            }
                            else if (str2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                            }
                        }
                        else if (lower != "false")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            if (flag)
                            {
                                if (empty2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                }
                            }
                            else if (str2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                            }
                        }
                        else if (str1 != "u")
                        {
                            if (str1 != "u")
                            {
                                if (str3 == "u")
                                {
                                    foreach (DataRow dataRow1 in LoginBasePage.Select_DeptDetail_For_StoreUser(order_confirmation.AccountID, this.StoreUserID).Rows)
                                    {
                                        num = Convert.ToInt64(dataRow1["DeptID"].ToString());
                                    }
                                    string empty6 = string.Empty;
                                    string str6 = string.Empty;
                                    DataSet dataSet = new DataSet();
                                    dataSet = LoginBasePage.ApproversEmail_Select(order_confirmation.AccountID, num);
                                    DataTable item = new DataTable();
                                    item = dataSet.Tables[0];
                                    DataTable dataTable1 = new DataTable();
                                    dataTable1 = dataSet.Tables[1];
                                    if (str1 == "a")
                                    {
                                        foreach (DataRow row2 in item.Rows)
                                        {
                                            empty6 = row2["email"].ToString();
                                            str6 = string.Concat(row2["contactID"].ToString(), "~", row2["email"].ToString());
                                        }
                                        keySeparator = new char[] { ',' };
                                        strArrays = str6.Split(keySeparator);
                                        for (i = 0; i < (int)strArrays.Length; i++)
                                        {
                                            string str7 = strArrays[i];
                                            keySeparator = new char[] { '~' };
                                            string[] strArrays1 = str7.Split(keySeparator);
                                            if (strArrays1[0].ToString() != "" && strArrays1[0].ToString() != null)
                                            {
                                                if (str5.ToString().Trim().ToLower() != "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    if (flag)
                                                    {
                                                        if (empty2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                    else if (str2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else if (!(str4 != "") || !(str4 != "0"))
                                                {
                                                    if (flag && empty2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str1);
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                }
                                                else if (num2 <= Convert.ToInt64(str4))
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    if (flag)
                                                    {
                                                        if (empty2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                    else if (str2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str1);
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                }
                                            }
                                        }
                                    }
                                    else if (str1 != "da")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                        if (flag)
                                        {
                                            if (empty2.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                            }
                                        }
                                        else if (str2.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                        }
                                    }
                                    else
                                    {
                                        foreach (DataRow dataRow2 in item.Rows)
                                        {
                                            if (!(dataRow2["email"].ToString() != "") || dataRow2["email"].ToString() == null)
                                            {
                                                continue;
                                            }
                                            empty6 = string.Concat(dataRow2["email"].ToString(), ",");
                                            str6 = string.Concat(dataRow2["contactID"].ToString(), "~", dataRow2["email"].ToString(), ",");
                                        }
                                        foreach (DataRow row3 in dataTable1.Rows)
                                        {
                                            empty6 = string.Concat(empty6, row3["email"].ToString(), ",");
                                            string[] strArrays2 = new string[] { str6, row3["contactID"].ToString(), "~", row3["email"].ToString(), "," };
                                            str6 = string.Concat(strArrays2);
                                        }
                                        keySeparator = new char[] { ',' };
                                        string[] strArrays3 = str6.Split(keySeparator);
                                        int num3 = 0;
                                        strArrays = strArrays3;
                                        for (i = 0; i < (int)strArrays.Length; i++)
                                        {
                                            string str8 = strArrays[i];
                                            keySeparator = new char[] { '~' };
                                            string[] strArrays4 = str8.Split(keySeparator);
                                            if (strArrays4[0].ToString() != "" && strArrays4[0].ToString() != null)
                                            {
                                                if (str5.ToString().Trim().ToLower() != "true")
                                                {
                                                    if (num3 == 0)
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                        if (flag)
                                                        {
                                                            if (empty2.ToLower() == "true")
                                                            {
                                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                            }
                                                        }
                                                        else if (str2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                }
                                                else if (!(str4 != "") || !(str4 != "0"))
                                                {
                                                    if (flag && num3 == 0 && empty2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str1);
                                                    if (num3 == 0)
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    }
                                                }
                                                else if (num2 > Convert.ToInt64(str4))
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str1);
                                                    if (num3 == 0)
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    }
                                                }
                                                else if (num3 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    if (flag)
                                                    {
                                                        if (empty2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                    else if (str2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                            }
                                            num3++;
                                        }
                                    }
                                }
                                else if (str3 != "d")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                    if (flag)
                                    {
                                        if (empty2.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                        }
                                    }
                                    else if (str2.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                    }
                                }
                                else if (str1 == "da")
                                {
                                    if (this.objBc.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                        if (flag)
                                        {
                                            if (empty2.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                            }
                                        }
                                        else if (str2.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                        }
                                    }
                                    else
                                    {
                                        string empty7 = string.Empty;
                                        string empty8 = string.Empty;
                                        DataSet dataSet1 = new DataSet();
                                        dataSet1 = LoginBasePage.ApproversEmail_Select(order_confirmation.AccountID, num);
                                        DataTable item1 = new DataTable();
                                        item1 = dataSet1.Tables[0];
                                        foreach (DataRow dataRow3 in item1.Rows)
                                        {
                                            dataRow3["email"].ToString();
                                            empty8 = string.Concat(dataRow3["contactID"].ToString(), "~", dataRow3["email"].ToString());
                                        }
                                        keySeparator = new char[] { ',' };
                                        strArrays = empty8.Split(keySeparator);
                                        for (i = 0; i < (int)strArrays.Length; i++)
                                        {
                                            string str9 = strArrays[i];
                                            keySeparator = new char[] { '~' };
                                            string[] strArrays5 = str9.Split(keySeparator);
                                            if (strArrays5[0].ToString() != "" && strArrays5[0].ToString() != null)
                                            {
                                                if (str5.ToString().Trim().ToLower() != "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    if (flag)
                                                    {
                                                        if (empty2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                    else if (str2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else if (!(str4 != "") || !(str4 != "0"))
                                                {
                                                    if (flag && empty2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str1);
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                }
                                                else if (num2 <= Convert.ToInt64(str4))
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                    if (flag)
                                                    {
                                                        if (empty2.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                        }
                                                    }
                                                    else if (str2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str1);
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (str1 != "a")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                    if (flag)
                                    {
                                        if (empty2.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                        }
                                    }
                                    else if (str2.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                    }
                                }
                                else
                                {
                                    string empty9 = string.Empty;
                                    string empty10 = string.Empty;
                                    DataSet dataSet2 = new DataSet();
                                    dataSet2 = LoginBasePage.ApproversEmail_Select(order_confirmation.AccountID, num);
                                    DataTable dataTable2 = new DataTable();
                                    dataTable2 = dataSet2.Tables[0];
                                    foreach (DataRow row4 in dataTable2.Rows)
                                    {
                                        row4["email"].ToString();
                                        empty10 = string.Concat(row4["contactID"].ToString(), "~", row4["email"].ToString());
                                    }
                                    keySeparator = new char[] { ',' };
                                    strArrays = empty10.Split(keySeparator);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str10 = strArrays[i];
                                        keySeparator = new char[] { '~' };
                                        string[] strArrays6 = str10.Split(keySeparator);
                                        if (strArrays6[0].ToString() != "" && strArrays6[0].ToString() != null)
                                        {
                                            if (str5.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                if (flag)
                                                {
                                                    if (empty2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else if (str2.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                }
                                            }
                                            else if (!(str4 != "") || !(str4 != "0"))
                                            {
                                                if (flag && empty2.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays6[0].ToString()), strArrays6[1].ToString(), str1);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                            }
                                            else if (num2 <= Convert.ToInt64(str4))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                                if (flag)
                                                {
                                                    if (empty2.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                                    }
                                                }
                                                else if (str2.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays6[0].ToString()), strArrays6[1].ToString(), str1);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (str5.ToString().Trim().ToLower() != "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            if (flag)
                            {
                                if (empty2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                }
                            }
                            else if (str2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                            }
                        }
                        else if (!(str4 != "") || !(str4 != "0"))
                        {
                            if (flag && empty2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                            }
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", (long)0, empty3, str1);
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                        }
                        else if (num2 <= Convert.ToInt64(str4))
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                            if (flag)
                            {
                                if (empty2.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Back Order", "Admin", (long)0, "no approval", str1);
                                }
                            }
                            else if (str2.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New Order", "Admin", (long)0, "no approval", str1);
                            }
                        }
                        else
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "New B2B Order", "Approver", (long)0, empty3, str1);
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(order_confirmation.AccountID), "Thank you for your order", "Customer", (long)0, "", str1);
                        }
                    }
                }
                this.Session["paypalKey"] = null;
                this.Session["InsertOrder"] = null;
                this.Session["Insert_CreditCardDetails"] = null;
                this.Session["CheckOut"] = null;
                this.Session["PaymentInfo"] = null;
                this.Session["ConfirmBeforeOrdernew"] = null;
                this.Session["PP_CostCentreID"] = null;
                this.Session["PP_DeptID"] = null;
                this.Session["PP_orderbehalftype"] = null;
                this.Session["PP_OrderForUserID"] = null;
                this.Session["PP_IsApproved"] = null;
                this.Session["PP_ApproverEmail"] = null;
                this.Session["PP_PriceValue"] = null;
                this.Session["PP_TaxValue"] = null;
                this.Session["PP_IsBackOrder"] = null;
                this.Session["PP_BCKORDERTYPE"] = null;
                this.Session["PP_NEWORDER"] = null;
                this.Session["PP_DesignatedApproverEmail"] = null;
                this.Session["CatgoryNotReqApproval"] = null;
                this.Session["DeptNotReqApproval"] = null;
            }
            string empty11 = string.Empty;
            foreach (DataRow dataRow4 in OrderBasePage.Select_OrderItems(this.OrderID, this.StoreUserID).Rows)
            {
                this.spn_OrderNo.InnerHtml = dataRow4["OrderNo"].ToString();
                this.OrderKey = dataRow4["OrderKey"].ToString();
                this.IsBackOrder = dataRow4["IsBackOrder"].ToString().Trim().ToLower();
                if (dataRow4["IsBackOrder"].ToString() != "1")
                {
                    continue;
                }
                if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                {
                    if (!(dataRow4["AvailableQuantity"].ToString() != "") && dataRow4["AvailableQuantity"].ToString() == null)
                    {
                        continue;
                    }
                    this.AvailableQuantity = Convert.ToInt32(dataRow4["AvailableQuantity"].ToString());
                    empty11 = string.Concat(empty11, this.AvailableQuantity, ",");
                }
                else
                {
                    DataTable dataTable3 = OrderBasePage.OtherMultipleProductDetails_Select(Convert.ToInt64(dataRow4["ProductID"]), Convert.ToInt16(dataRow4["Quantity"]), true);
                    foreach (DataRow row5 in dataTable3.Rows)
                    {
                        if (!(row5["AvailableQuantity"].ToString() != "") && row5["AvailableQuantity"].ToString() == null)
                        {
                            continue;
                        }
                        this.AvailableQuantity = Convert.ToInt32(row5["AvailableQuantity"].ToString());
                        empty11 = string.Concat(empty11, this.AvailableQuantity, ",");
                    }
                }
            }
            try
            {
                bool flag1 = false;
                bool flag2 = false;
                keySeparator = new char[] { ',' };
                string[] strArrays7 = empty11.Split(keySeparator);
                for (int j = 0; j < (int)strArrays7.Length - 1; j++)
                {
                    if (Convert.ToInt32(strArrays7[j]) >= 0)
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
        }
    }
}