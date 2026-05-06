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

namespace ePrint.WebStore
{
    public partial class payment_information : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

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

        //protected UpdatePanel UpdatePanel1;

        //protected HiddenField hdn_EstimateID;

        //protected HiddenField hdn_Creditcardtypes;

        //protected HiddenField hdn_Creditcardtypes_BT;

        protected HiddenField hdn_SelectedCardType;

        public string strImagepath = BaseClass.imagePath();

        private commonclass comm = new commonclass();

        private BaseClass objBc = new BaseClass();

        private storeEmail Objemail = new storeEmail();

        public languageClass objLanguage = new languageClass();

        public string OrderKey = string.Empty;

        private string[] paymentMode;

        private string[] CardTypes;

        public long AccountID;

        public int CompanyID;

        public string defaultpaymentMode = string.Empty;

        public string strSitepath = string.Empty;

        public static string imagePath;

        public string StyleSheetPath = string.Empty;

        public string eprintDocument = string.Empty;

        public string AccountType = string.Empty;

        public string DateFormat = string.Empty;

        public int UserID;

        public long OrderID;

        public long StoreUserID;

        private DateTime OrderDate;

        public string isLoginInfo = "1";

        public string CardType = string.Empty;

        public decimal TotalPrice;

        public decimal DeliveryCost;

        public decimal Tax;

        public decimal OrderShipping;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ApproverEmail = string.Empty;

        public long DepartmentID;

        public string UserType = string.Empty;

        public string BCKORDERTYPE = string.Empty;

        public string NEWORDER = string.Empty;

        public bool IsBackOrder;

        public int AvailableQuantity;

        public string SecureDocFilepath = string.Empty;

        public string SecureDocPath = string.Empty;

        public string ServerName = string.Empty;

        public string Paypal_ButtonText = string.Empty;

        public string OtherOptions_ButtonText = string.Empty;

        private string Prod_Id = string.Empty;

        public string BT_OrderID = string.Empty;

        public string BT_AuthorizationCode = string.Empty;

        public string Stripe_Paymentid = string.Empty;

        protected string SessionId = string.Empty;

        public string stripeUrl = string.Empty;

        protected string StripePaymentLink = string.Empty;

        protected Random rGen;

        protected string[] strCharacters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public bool isCheckOrderTitle = true;
        public bool isCheckOrderNumber = true;
        public bool isCheckDeliveryRequiredBy_1 = true;
        public bool isCheckCooments = true;
        public bool ShowCostCenters = true;
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

        static payment_information()
        {
            payment_information.imagePath = string.Empty;
        }

        public payment_information()
        {
        }

        protected void BackLink_onclick(object sender, EventArgs e)
        {
            this.Session["PaymentStep"] = "true";
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrder.aspx?OrdKey=", this.OrderKey, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrder", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
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

        private void Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType, string RequiredDate, string Comments, string OrderTitle, string OrderNo, string strMultipleCartID, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long DeptID, string orderbehalftype, long OrderForUserID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (ClientID == (long)0)
            {
                DataTable dataTable = LoginBasePage.StoreUser_select_by_Conditions(OrderForUserID, orderbehalftype, DeptID);
                if (dataTable.Rows.Count > 0)
                {
                    ClientID = Convert.ToInt64(dataTable.Rows[0]["ClientID"].ToString());
                }
            }
            this.TotalPrice = new decimal(0);
            this.Tax = new decimal(0);
            this.OrderShipping = new decimal(0);
            this.DeliveryCost = new decimal(0);
            foreach (DataRow row in CartBasePage.Select_MultipleCartItems(CookieID, "", StoreUserID, strMultipleCartID).Rows)
            {
                this.TotalPrice = this.TotalPrice + Convert.ToDecimal(row["CartTotalPrice"].ToString());
                this.Tax = this.Tax + Convert.ToDecimal(row["CartTax"]);
                this.OrderShipping = this.OrderShipping + Convert.ToDecimal(row["CartShipping"]);
                //this.DeliveryCost = Convert.ToDecimal(row["DeliveryCost"]);
            }
            //this.TotalPrice = this.TotalPrice + this.DeliveryCost;
            DateTime.Now.ToString();
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.OrderDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            string str1 = this.comm.date_Check_new(this.DateFormat, this.objBc.ReplaceSingleQuote(RequiredDate.ToString()));
            long num = (long)0;
            num = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, this.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(str1), Comments, this.OrderKey, OrderTitle, OrderNo, this.ApproverEmail, OrderForUserID, DeptID, CostCentreID, StoreUserID, orderbehalftype, IsApproved, this.BT_OrderID, this.BT_AuthorizationCode, (long)0, this.Stripe_Paymentid);
            this.OrderID = num;
            this.hdn_EstimateID.Value = num.ToString();
            DataTable dataTable1 = CartBasePage.Select_MultipleCartItems("", "", StoreUserID, strMultipleCartID);
            int index = 0;
            foreach (DataRow dataRow in dataTable1.Rows)
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
                string str2 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
                bool isApproved = IsApproved;
                if (!IsApproved && str2.ToLower() == "s" && this.Session["SelfApproval_ItemID"] != null && this.Session["SelfApproval_ItemID"].ToString().Trim() != "")
                {
                    string[] strArrays1 = this.Session["SelfApproval_ItemID"].ToString().Split(new char[] { ',' });
                    int num2 = 0;
                    while (num2 < (int)strArrays1.Length - 1)
                    {
                        if (strArrays1[num2].ToString() != dataRow["CartItemID"].ToString())
                        {
                            num2++;
                        }
                        else
                        {
                            isApproved = true;
                            break;
                        }
                    }
                }
                OrderBasePage.Insert_OrderItemDetails_MIS(Convert.ToInt64(dataRow["CartItemID"].ToString()), flag, num, (long)this.CompanyID, isApproved, StoreUserID, this.ApproverEmail, ClientID, dataTable1.Rows.Count);
                object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["PrintReadyFile"].ToString() };
                empty = string.Concat(secureDocPath);
                if (dataRow["PrintReadyFile"].ToString() != "")
                {
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(objArray)))
                    {
                        object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(secureDocPath1));
                    }
                    string str3 = string.Empty;
                    if (System.IO.File.Exists(empty))
                    {
                        object[] objArray1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        str3 = string.Concat(objArray1);
                        if (!Directory.Exists(str3))
                        {
                            Directory.CreateDirectory(str3);
                        }
                        System.IO.File.Copy(empty, string.Concat(str3, dataRow["PrintReadyFile"].ToString()), true);
                    }
                }
                if (commonclass.CheckFTPEnable())
                {
                    string filePath = string.Empty;
                    DataTable dt = OrderBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, (long)Convert.ToInt32(this.OrderID));
                    DataTable dataTable6 = commonclass.Get_ProductFileByType(Convert.ToInt64(dataRow["ProductID"].ToString()), this.CompanyID);
                    if (!string.IsNullOrEmpty(dataTable6.Rows[0]["PrintReadyFile"].ToString()))
                    {
                        if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                        {
                            DataTable _attachment = commonclass.GetAttachmentByEstimateItemID(Convert.ToInt64(dt.Rows[index]["EstimateItemID"].ToString()));
                            object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                            //string EditableTemplatePath = string.Empty;
                            //DataTable _item = EprintConfigurationManager.GetAppSettings();
                            //foreach (DataRow dr in _item.Rows)
                            //{
                            //    EditableTemplatePath = dr["EditableTemplatePath"].ToString();
                            //}
                            //object[] editableTemplatePath = new object[] { EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                            filePath = string.Concat(secureDocEditablePath);
                        }
                        else
                        {
                            string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                            filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                        }
                        commonclass.UploadPrintReadyFileToSftp(this.CompanyID, dataRow["ProductID"].ToString(), filePath, "OrderCreation", "OnlineOrder", Convert.ToInt64(dt.Rows[index]["EstimateItemID"].ToString()));
                    }
                   
                }

                index++;
                if (dataRow["ReportFileName"] == null && !(dataRow["ReportFileName"].ToString() != ""))
                {
                    continue;
                }
                object[] secureDocPath2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\Product\\PrintReady\\", dataRow["ReportFileName"].ToString() };
                str = string.Concat(secureDocPath2);
                object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "\\", this.CompanyID };
                if (!Directory.Exists(string.Concat(objArray2)))
                {
                    object[] secureDocPath3 = new object[] { this.SecureDocPath, this.ServerName, "\\", this.CompanyID };
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
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num, (long)this.CompanyID, StoreUserID, (long)dataTable1.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num);
            if (this.ddl_payments.SelectedValue.ToString() == "BT" && num > (long)0)
            {
                //OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 10, this.OrderDate, "", this.txt_HolderName.Text, this.hdn_SelectedCardType.Value, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue), this.txt_verification.Text, this.txt_cardNumber.Text);
                OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 10, this.OrderDate, "", "", "", 0, 0, "", "");
                return;
            }
            if (this.ddl_payments.SelectedValue.ToString() == "ST" && num > (long)0)
            {
                //OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 15, this.OrderDate, "", this.txt_HolderName.Text, this.hdn_SelectedCardType.Value, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue), this.txt_verification.Text, this.txt_cardNumber.Text);
                OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 15, this.OrderDate, "", "", "", 0, 0, "", "");
                return;
            }
            if (this.ddl_payments.SelectedValue.ToString() == "PP" && num > (long)0)
            {
                //OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 7, this.OrderDate, "", this.txt_HolderName.Text, this.hdn_SelectedCardType.Value, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue), this.txt_verification.Text, this.txt_cardNumber.Text);
                OrderBasePage.Insert_InvoicePaymentDetailsForEstore((long)0, num, (long)this.CompanyID, 7, this.OrderDate, "", "", "", 0, 0, "", "");
            }
        }

        protected void OnClick_lnkbtnOrder(object sender, EventArgs e)
        {
            string empty = string.Empty;
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
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable2 = new DataTable();
            if (this.Session["InsertOrder"] != null)
            {
                dataTable2 = (DataTable)this.Session["InsertOrder"];
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                    str = dataTable2.Rows[0]["DesignatedApproverEmail"].ToString();
                }
            }
            if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
            {
                empty1 = base.Request.Params["Tp"].ToString();
                str1 = base.Request.Params["Tx"].ToString();
            }
            string lower = string.Empty;
            if (this.Session["CatgoryNotReqApproval"] != null)
            {
                lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
            }
            string lower1 = string.Empty;
            if (this.Session["DeptNotReqApproval"] != null)
            {
                lower1 = this.Session["DeptNotReqApproval"].ToString().ToLower();
            }
            if (this.Session["ApprovalSystem"] == null)
            {
                try
                {
                    this.OrderPayment(true);

                }
                catch (Exception ex)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                }
            }
            else
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    try
                    {
                        this.OrderPayment(true);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                string str2 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
                string str3 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                string str4 = this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                decimal num = Convert.ToDecimal(empty1);
                decimal num1 = num + Convert.ToDecimal(str1);
                if (str2.ToLower() == "s")
                {
                    if (!(str3 != "") || !(str3 != "0"))
                    {
                        this.ApproverEmail = this.Session["EmailID"].ToString();
                        try
                        {
                            this.OrderPayment(false);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    if (num1 <= Convert.ToInt64(str3))
                    {
                        try
                        {
                            this.OrderPayment(true);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    this.ApproverEmail = this.Session["EmailID"].ToString();
                    try
                    {
                        this.OrderPayment(false);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                if (lower1 != "false")
                {
                    try
                    {
                        this.OrderPayment(true);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                if (lower != "false")
                {
                    try
                    {
                        this.OrderPayment(true);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                if (str4.ToString().Trim().ToLower() != "true")
                {
                    try
                    {
                        this.OrderPayment(true);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                if (str2 == "u")
                {
                    if (!(str3 != "") || !(str3 != "0"))
                    {
                        this.ApproverEmail = str;
                        try
                        {
                            this.OrderPayment(false);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    if (num1 <= Convert.ToInt64(str3))
                    {
                        try
                        {
                            this.OrderPayment(true);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    this.ApproverEmail = str;
                    try
                    {
                        this.OrderPayment(false);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
                if (str2 != "u")
                {
                    if (this.UserType != "u")
                    {
                        if (this.UserType != "d")
                        {
                            try
                            {
                                this.OrderPayment(true);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        if (str2 == "da")
                        {
                            if (this.objBc.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                            {
                                try
                                {
                                    this.OrderPayment(true);

                                }
                                catch (Exception ex)
                                {
                                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                                }
                            }
                            else
                            {
                                string empty2 = string.Empty;
                                string empty3 = string.Empty;
                                DataSet dataSet1 = new DataSet();
                                dataSet1 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                DataTable item2 = new DataTable();
                                item2 = dataSet1.Tables[0];
                                foreach (DataRow row2 in item2.Rows)
                                {
                                    empty2 = row2["email"].ToString();
                                    string.Concat(row2["contactID"].ToString(), "~", row2["email"].ToString());
                                }
                                if (!(str3 != "") || !(str3 != "0"))
                                {
                                    this.ApproverEmail = empty2;
                                    try
                                    {
                                        this.OrderPayment(false);

                                    }
                                    catch (Exception ex)
                                    {
                                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                                    }
                                }
                                else if (num1 <= Convert.ToInt64(str3))
                                {
                                    try
                                    {
                                        this.OrderPayment(true);

                                    }
                                    catch (Exception ex)
                                    {
                                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                                    }
                                }
                                else
                                {
                                    this.ApproverEmail = empty2;
                                    try
                                    {
                                        this.OrderPayment(false);

                                    }
                                    catch (Exception ex)
                                    {
                                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                                    }
                                }
                            }
                        }
                        if (str2 != "a")
                        {
                            try
                            {
                                this.OrderPayment(true);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        string empty4 = string.Empty;
                        string empty5 = string.Empty;
                        DataSet dataSet2 = new DataSet();
                        dataSet2 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                        DataTable dataTable3 = new DataTable();
                        dataTable3 = dataSet2.Tables[0];
                        foreach (DataRow dataRow2 in dataTable3.Rows)
                        {
                            empty4 = dataRow2["email"].ToString();
                            string.Concat(dataRow2["contactID"].ToString(), "~", dataRow2["email"].ToString());
                        }
                        if (!(str3 != "") || !(str3 != "0"))
                        {
                            this.ApproverEmail = empty4;
                            try
                            {
                                this.OrderPayment(false);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        if (num1 <= Convert.ToInt64(str3))
                        {
                            try
                            {
                                this.OrderPayment(true);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        this.ApproverEmail = empty4;
                        try
                        {
                            this.OrderPayment(false);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    foreach (DataRow row3 in LoginBasePage.Select_DeptDetail_For_StoreUser(this.AccountID, this.StoreUserID).Rows)
                    {
                        this.DepartmentID = Convert.ToInt64(row3["DeptID"].ToString());
                    }
                    string str5 = string.Empty;
                    string empty6 = string.Empty;
                    DataSet dataSet3 = new DataSet();
                    dataSet3 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                    DataTable item3 = new DataTable();
                    item3 = dataSet3.Tables[0];
                    DataTable dataTable4 = new DataTable();
                    dataTable4 = dataSet3.Tables[1];
                    if (str2 == "a")
                    {
                        foreach (DataRow dataRow3 in item3.Rows)
                        {
                            str5 = dataRow3["email"].ToString();
                            empty6 = string.Concat(dataRow3["contactID"].ToString(), "~", dataRow3["email"].ToString());
                        }
                        if (!(str3 != "") || !(str3 != "0"))
                        {
                            this.ApproverEmail = str5;
                            try
                            {
                                this.OrderPayment(false);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        if (num1 <= Convert.ToInt64(str3))
                        {
                            try
                            {
                                this.OrderPayment(true);

                            }
                            catch (Exception ex)
                            {
                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                            }
                            return;
                        }
                        this.ApproverEmail = str5;
                        try
                        {
                            this.OrderPayment(false);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    if (str2 != "da")
                    {
                        try
                        {
                            this.OrderPayment(true);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    foreach (DataRow row4 in item3.Rows)
                    {
                        if (!(row4["email"].ToString() != "") || row4["email"].ToString() == null)
                        {
                            continue;
                        }
                        str5 = string.Concat(row4["email"].ToString(), ",");
                        empty6 = string.Concat(row4["contactID"].ToString(), "~", row4["email"].ToString(), ",");
                    }
                    foreach (DataRow dataRow4 in dataTable4.Rows)
                    {
                        str5 = string.Concat(str5, dataRow4["email"].ToString(), ",");
                        string[] strArrays = new string[] { empty6, dataRow4["contactID"].ToString(), "~", dataRow4["email"].ToString(), "," };
                        empty6 = string.Concat(strArrays);
                    }
                    if (!(str3 != "") || !(str3 != "0"))
                    {
                        this.ApproverEmail = str5;
                        try
                        {
                            this.OrderPayment(false);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    if (num1 <= Convert.ToInt64(str3))
                    {
                        try
                        {
                            this.OrderPayment(true);

                        }
                        catch (Exception ex)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                        }
                        return;
                    }
                    this.ApproverEmail = str5;
                    try
                    {
                        this.OrderPayment(false);

                    }
                    catch (Exception ex)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "") + "');window.location ='" + url + "';", true);
                    }
                    return;
                }
            }
        }

        public bool OrderPayment(bool IsApproved)
        {
            bool flag;
            IEnumerator enumerator;
            IEnumerator enumerator1;
            IDisposable disposable;
            string[] str;
            char[] chrArray;
            string[] strArrays;
            int i;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string currency = "";
            DataTable currencySymbolCurrency = CMSBasePage.Get_CurrencySymbol_Currency_Company(this.CompanyID);
            if (currencySymbolCurrency != null)
            {
                currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
            }
            if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
            {
                empty = base.Request.Params["Tp"].ToString();
                empty1 = base.Request.Params["Tx"].ToString();
            }
            string empty2 = string.Empty;
            if (this.Session["MultipleCartID"] != null)
            {
                empty2 = this.Session["MultipleCartID"].ToString();
            }
            string lower = string.Empty;
            if (this.Session["CatgoryNotReqApproval"] != null)
            {
                lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
            }
            string lower1 = string.Empty;
            if (this.Session["DeptNotReqApproval"] != null)
            {
                lower1 = this.Session["DeptNotReqApproval"].ToString().ToLower();
            }
            if (this.Session["InsertOrder"] != null)
            {
                DataTable item = (DataTable)this.Session["InsertOrder"];
                if (item != null)
                {
                    enumerator = item.Rows.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            str1 = current["DesignatedApproverEmail"].ToString();
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
                                this.Session["PP_CostCentreID"] = current["CostCentreID"].ToString();
                                this.Session["PP_DeptID"] = current["DeptID"].ToString();
                                this.Session["PP_orderbehalftype"] = current["orderbehalftype"].ToString();
                                this.Session["PP_OrderForUserID"] = current["OrderForUserID"].ToString();
                                this.Session["PP_IsApproved"] = IsApproved;
                                this.Session["PP_ApproverEmail"] = this.ApproverEmail;
                                if (base.Request.Params["Tp"] != null && base.Request.Params["Tx"] != null)
                                {
                                    this.Session["PP_PriceValue"] = base.Request.Params["Tp"].ToString();
                                    this.Session["PP_TaxValue"] = base.Request.Params["Tx"].ToString();
                                }
                                this.Session["PP_IsBackOrder"] = this.IsBackOrder;
                                this.Session["PP_BCKORDERTYPE"] = this.BCKORDERTYPE;
                                this.Session["PP_NEWORDER"] = this.NEWORDER;
                                this.Session["PP_DesignatedApproverEmail"] = str1;
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
                                //text = this.objLanguage.GetLanguageConversion("Stripe_Credit_Card");
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
                                DataTable dataTable = CartBasePage.Select_MultipleCartItems(current["SessionKey"].ToString(), "", this.StoreUserID, empty2);
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
                                totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
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
                                Convert.ToInt64(current["DeliveryAddressID"]);
                                string text = string.Empty;
                                if (this.ddl_payments.SelectedValue.ToString() == "BT" || this.ddl_payments.SelectedValue.ToString() == "ST")
                                {
                                    // text = this.ddl_payments.SelectedItem.Text;
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
                                        DataTable dataTable = CartBasePage.Select_MultipleCartItems(current["SessionKey"].ToString(), "", this.StoreUserID, empty2);
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
                                        totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                        totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
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
                                                    str3 = current2["BrainTreePrivateKey"].ToString();
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
                                        BraintreeGateway braintreeGateway = new BraintreeGateway()
                                        {
                                            Environment = pRODUCTION,
                                            MerchantId = str2,
                                            PublicKey = empty3,
                                            PrivateKey = str3
                                        };
                                        BraintreeGateway braintreeGateway1 = braintreeGateway;
                                        CustomerRequest customerRequest = new CustomerRequest()
                                        {
                                            FirstName = empty4,
                                            LastName = str4,
                                            Email = empty5,
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
                                            CountryName = str7,
                                            StreetAddress = str8,
                                            PostalCode = empty8
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
                                            string empty9 = string.Empty;
                                            List<ValidationError>.Enumerator enumerator2 = result.Errors.DeepAll().GetEnumerator();
                                            try
                                            {
                                                while (enumerator2.MoveNext())
                                                {
                                                    empty9 = string.Concat(empty9, enumerator2.Current.Message);
                                                }
                                            }
                                            finally
                                            {
                                                ((IDisposable)enumerator2).Dispose();
                                            }
                                            if (!string.IsNullOrEmpty(empty9))
                                            {
                                                this.lblPaypalAlertMSG.Text = empty9;
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
                                        text = this.objLanguage.GetLanguageConversion("Stripe_Credit_Card");
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
                                        DataTable dataTable = CartBasePage.Select_MultipleCartItems(current["SessionKey"].ToString(), "", this.StoreUserID, empty2);
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
                                        totalPrice = (this.TotalPrice + totalPrice1) + this.OrderShipping;
                                        totalPrice = Convert.ToDecimal(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, totalPrice, 2, "", false, false, true));
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
                                            Currency = currency == "" ? "AUD" : currency,
                                            Source = res.Id, // obtained with Stripe.js
                                            Description = current["OrderNumber"].ToString(),
                                        };
                                        var service1 = new ChargeService();
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
                                this.Insert_Order(current["SessionKey"].ToString(), Convert.ToInt64(current["StoreUserID"]), Convert.ToInt64(current["InvoiceAddressID"]), Convert.ToInt64(current["DeliveryAddressID"]), Convert.ToInt64(current["ClientID"]), current["IsOrdered"].ToString(), text, current["RequiredBy"].ToString(), current["Comments"].ToString(), current["OrderTitle"].ToString(), current["OrderNumber"].ToString(), empty2, (long)0, (long)0, IsApproved, Convert.ToInt64(current["CostCentreID"]), Convert.ToInt64(current["DeptID"]), current["orderbehalftype"].ToString(), Convert.ToInt64(current["OrderForUserID"]));
                                DataTable dataTable4 = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_EstimateID.Value), Convert.ToInt64(current["StoreUserID"]));
                                enumerator1 = dataTable4.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator1.MoveNext())
                                    {
                                        DataRow dataRow2 = (DataRow)enumerator1.Current;
                                        this.OrderKey = dataRow2["OrderKey"].ToString();
                                        long num2 = Convert.ToInt64(dataRow2["ProductID"]);
                                        int num3 = Convert.ToInt32(dataRow2["Quantity"]);
                                        decimal num4 = Convert.ToDecimal(dataRow2["UnitPrice"]);
                                        long num5 = Convert.ToInt64(dataRow2["EstimateItemID"]);
                                        long num6 = Convert.ToInt64(dataRow2["OrderItemID"]);
                                        BaseClass baseClass1 = new BaseClass();
                                        baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                        string str10 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                        string str11 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                        bool flag2 = Convert.ToBoolean(dataRow2["IsStockReplenish"]);
                                        if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && baseClass1.Return_ApprovalSystem_Settings("approvaltype").ToLower() == "s")
                                        {
                                            IsApproved = Convert.ToBoolean(dataRow2["ApproveStatus"]);
                                        }
                                        if (flag2.ToString().ToLower() == "true")
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
                                                    baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num2, num3, str10, "additional option", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID, Convert.ToInt64(this.hdn_EstimateID.Value), num6);
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
                                    disposable = enumerator1 as IDisposable;
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
                        disposable = enumerator as IDisposable;
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
                OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_EstimateID.Value), this.txt_HolderName.Text, "", Convert.ToInt64(this.txt_cardNumber.Text), this.CardType, this.txt_verification.Text, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue));
            }
            string str12 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else if (str12.ToLower() == "s")
                {
                    string str13 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                    this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                    decimal num7 = Convert.ToDecimal(empty);
                    decimal num8 = num7 + Convert.ToDecimal(empty1);
                    if (!(str13 != "") || !(str13 != "0"))
                    {
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                        if (IsApproved.ToString().Trim().ToLower() != "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str12);
                        }
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                    else if (num8 <= Convert.ToInt64(str13))
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                }
                else if (lower1 != "false")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else if (lower != "false")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else
                {
                    string str14 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                    string str15 = this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                    decimal num9 = Convert.ToDecimal(empty);
                    decimal num10 = num9 + Convert.ToDecimal(empty1);
                    if (str12 != "u")
                    {
                        if (str12 != "u")
                        {
                            if (this.UserType == "u")
                            {
                                foreach (DataRow row in LoginBasePage.Select_DeptDetail_For_StoreUser(this.AccountID, this.StoreUserID).Rows)
                                {
                                    this.DepartmentID = Convert.ToInt64(row["DeptID"].ToString());
                                }
                                string empty10 = string.Empty;
                                string empty11 = string.Empty;
                                DataSet dataSet = new DataSet();
                                dataSet = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                DataTable item1 = new DataTable();
                                item1 = dataSet.Tables[0];
                                DataTable item2 = new DataTable();
                                item2 = dataSet.Tables[1];
                                if (str12 == "a")
                                {
                                    foreach (DataRow row1 in item1.Rows)
                                    {
                                        empty10 = row1["email"].ToString();
                                        empty11 = string.Concat(row1["contactID"].ToString(), "~", row1["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty11.Split(chrArray);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str16 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays1 = str16.Split(chrArray);
                                        if (strArrays1[0].ToString() != "" && strArrays1[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                            else if (num10 <= Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                        }
                                    }
                                }
                                else if (str12 != "da")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else
                                {
                                    foreach (DataRow row2 in item1.Rows)
                                    {
                                        if (!(row2["email"].ToString() != "") || row2["email"].ToString() == null)
                                        {
                                            continue;
                                        }
                                        empty10 = string.Concat(row2["email"].ToString(), ",");
                                        empty11 = string.Concat(row2["contactID"].ToString(), "~", row2["email"].ToString(), ",");
                                    }
                                    foreach (DataRow row3 in item2.Rows)
                                    {
                                        empty10 = string.Concat(empty10, row3["email"].ToString(), ",");
                                        str = new string[] { empty11, row3["contactID"].ToString(), "~", row3["email"].ToString(), "," };
                                        empty11 = string.Concat(str);
                                    }
                                    chrArray = new char[] { ',' };
                                    string[] strArrays2 = empty11.Split(chrArray);
                                    int num11 = 0;
                                    strArrays = strArrays2;
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str17 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays3 = str17.Split(chrArray);
                                        if (strArrays3[0].ToString() != "" && strArrays3[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                    if (this.IsBackOrder)
                                                    {
                                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                        }
                                                    }
                                                    else if (this.NEWORDER.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && num11 == 0 && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str12);
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                }
                                            }
                                            else if (num10 > Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str12);
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                }
                                            }
                                            else if (num11 == 0)
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                        }
                                        num11++;
                                    }
                                }
                            }
                            else if (this.UserType != "d")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                }
                            }
                            else if (str12 == "da")
                            {
                                if (this.objBc.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else
                                {
                                    string empty12 = string.Empty;
                                    string empty13 = string.Empty;
                                    DataSet dataSet1 = new DataSet();
                                    dataSet1 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                    DataTable item3 = new DataTable();
                                    item3 = dataSet1.Tables[0];
                                    foreach (DataRow row4 in item3.Rows)
                                    {
                                        row4["email"].ToString();
                                        empty13 = string.Concat(row4["contactID"].ToString(), "~", row4["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty13.Split(chrArray);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str18 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays4 = str18.Split(chrArray);
                                        if (strArrays4[0].ToString() != "" && strArrays4[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                            else if (num10 <= Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (str12 != "a")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                }
                            }
                            else
                            {
                                string empty14 = string.Empty;
                                string empty15 = string.Empty;
                                DataSet dataSet2 = new DataSet();
                                dataSet2 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                DataTable item4 = new DataTable();
                                item4 = dataSet2.Tables[0];
                                foreach (DataRow dataRow4 in item4.Rows)
                                {
                                    dataRow4["email"].ToString();
                                    empty15 = string.Concat(dataRow4["contactID"].ToString(), "~", dataRow4["email"].ToString());
                                }
                                chrArray = new char[] { ',' };
                                strArrays = empty15.Split(chrArray);
                                for (i = 0; i < (int)strArrays.Length; i++)
                                {
                                    string str19 = strArrays[i];
                                    chrArray = new char[] { '~' };
                                    string[] strArrays5 = str19.Split(chrArray);
                                    if (strArrays5[0].ToString() != "" && strArrays5[0].ToString() != null)
                                    {
                                        if (str15.ToString().Trim().ToLower() != "true")
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                            }
                                        }
                                        else if (!(str14 != "") || !(str14 != "0"))
                                        {
                                            if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                            }
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str12);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                        }
                                        else if (num10 <= Convert.ToInt64(str14))
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                            }
                                        }
                                        else
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str12);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (str15.ToString().Trim().ToLower() != "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (!(str14 != "") || !(str14 != "0"))
                    {
                        if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, str1, str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                    else if (num10 <= Convert.ToInt64(str14))
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, str1, str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                }
            }
            var storeCredit = Convert.ToDouble(Session["StoreCredit"]);
            if (storeCredit > 0)
            {
                CartBasePage.Update_StoreCredit(StoreUserID, storeCredit);

            }
            Session["StoreCredit"] = null;
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["PaymentInfo"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            this.Session["CatgoryNotReqApproval"] = null;
            this.Session["DeptNotReqApproval"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
            }
            else
            {
                HttpResponse response = base.Response;
                str = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                response.Redirect(string.Concat(str));
            }
            return true;
        }


        public bool StripeOrderCreate(bool IsApproved, string StripePaymentStatus, string Tp, string Tx)
        {
            bool flag;
            IEnumerator enumerator;
            IEnumerator enumerator1;
            IDisposable disposable;
            string[] str;
            char[] chrArray;
            string[] strArrays;
            int i;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string currency = "";
            DataTable currencySymbolCurrency = CMSBasePage.Get_CurrencySymbol_Currency_Company(this.CompanyID);
            if (currencySymbolCurrency != null)
            {
                currency = currencySymbolCurrency.Rows[0][0].ToString().Trim();
            }
            empty = Tp;
            empty1 = Tx;
            string empty2 = string.Empty;
            if (this.Session["MultipleCartID"] != null)
            {
                empty2 = this.Session["MultipleCartID"].ToString();
            }
            string lower = string.Empty;
            if (this.Session["CatgoryNotReqApproval"] != null)
            {
                lower = this.Session["CatgoryNotReqApproval"].ToString().ToLower();
            }
            string lower1 = string.Empty;
            if (this.Session["DeptNotReqApproval"] != null)
            {
                lower1 = this.Session["DeptNotReqApproval"].ToString().ToLower();
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
                    enumerator = item.Rows.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow)enumerator.Current;
                            str1 = current["DesignatedApproverEmail"].ToString();
                            Convert.ToInt64(current["DeliveryAddressID"]);
                            string text = string.Empty;
                            if (!(current["OrderID"].ToString() == "") && !(current["OrderID"].ToString() == "0"))
                            {
                                continue;
                            }
                            text = this.objLanguage.GetLanguageConversion("Stripe_Credit_Card");
                            if (Session["Stripe_Payment_ID"] != null)
                            {
                                this.Stripe_Paymentid = Session["Stripe_Payment_ID"].ToString();
                            }
                            this.Insert_Order(current["SessionKey"].ToString(), Convert.ToInt64(current["StoreUserID"]), Convert.ToInt64(current["InvoiceAddressID"]), Convert.ToInt64(current["DeliveryAddressID"]), Convert.ToInt64(current["ClientID"]), current["IsOrdered"].ToString(), text, current["RequiredBy"].ToString(), current["Comments"].ToString(), current["OrderTitle"].ToString(), current["OrderNumber"].ToString(), empty2, (long)0, (long)0, IsApproved, Convert.ToInt64(current["CostCentreID"]), Convert.ToInt64(current["DeptID"]), current["orderbehalftype"].ToString(), Convert.ToInt64(current["OrderForUserID"]));
                            DataTable dataTable4 = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_EstimateID.Value), Convert.ToInt64(current["StoreUserID"]));
                            enumerator1 = dataTable4.Rows.GetEnumerator();
                            try
                            {
                                while (enumerator1.MoveNext())
                                {
                                    DataRow dataRow2 = (DataRow)enumerator1.Current;
                                    this.OrderKey = dataRow2["OrderKey"].ToString();
                                    long num2 = Convert.ToInt64(dataRow2["ProductID"]);
                                    int num3 = Convert.ToInt32(dataRow2["Quantity"]);
                                    decimal num4 = Convert.ToDecimal(dataRow2["UnitPrice"]);
                                    long num5 = Convert.ToInt64(dataRow2["EstimateItemID"]);
                                    long num6 = Convert.ToInt64(dataRow2["OrderItemID"]);
                                    BaseClass baseClass1 = new BaseClass();
                                    baseClass1.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                    string str10 = baseClass1.Return_StockManagementSettings("SR_StockReductionMethod");
                                    string str11 = baseClass1.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                    bool flag2 = Convert.ToBoolean(dataRow2["IsStockReplenish"]);
                                    if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && baseClass1.Return_ApprovalSystem_Settings("approvaltype").ToLower() == "s")
                                    {
                                        IsApproved = Convert.ToBoolean(dataRow2["ApproveStatus"]);
                                    }
                                    if (flag2.ToString().ToLower() == "true")
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
                                                baseClass1.StockAllocationForAdditionalOption((long)this.CompanyID, num2, num3, str10, "additional option", Convert.ToBoolean(str11), num5, "Job", num4, this.StoreUserID, Convert.ToInt64(this.hdn_EstimateID.Value), num6);
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
                                disposable = enumerator1 as IDisposable;
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
                        disposable = enumerator as IDisposable;
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
                OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_EstimateID.Value), this.txt_HolderName.Text, "", Convert.ToInt64(this.txt_cardNumber.Text), this.CardType, this.txt_verification.Text, Convert.ToInt32(this.ddl_month.SelectedValue), Convert.ToInt32(this.ddl_year.SelectedValue));
            }
            string str12 = this.objBc.Return_ApprovalSystem_Settings("approvaltype");
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else if (str12.ToLower() == "s")
                {
                    string str13 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                    this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                    decimal num7 = Convert.ToDecimal(empty);
                    decimal num8 = num7 + Convert.ToDecimal(empty1);
                    if (!(str13 != "") || !(str13 != "0"))
                    {
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                        if (IsApproved.ToString().Trim().ToLower() != "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str12);
                        }
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                    else if (num8 <= Convert.ToInt64(str13))
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, this.Session["EmailID"].ToString(), str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                }
                else if (lower1 != "false")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else if (lower != "false")
                {
                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    if (this.IsBackOrder)
                    {
                        if (this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (this.NEWORDER.ToLower() == "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                    }
                }
                else
                {
                    string str14 = this.objBc.Return_ApprovalSystem_Settings("approvalreqfororder");
                    string str15 = this.objBc.Return_ApprovalSystem_Settings("newordersapprove");
                    decimal num9 = Convert.ToDecimal(empty);
                    decimal num10 = num9 + Convert.ToDecimal(empty1);
                    if (str12 != "u")
                    {
                        if (str12 != "u")
                        {
                            if (this.UserType == "u")
                            {
                                foreach (DataRow row in LoginBasePage.Select_DeptDetail_For_StoreUser(this.AccountID, this.StoreUserID).Rows)
                                {
                                    this.DepartmentID = Convert.ToInt64(row["DeptID"].ToString());
                                }
                                string empty10 = string.Empty;
                                string empty11 = string.Empty;
                                DataSet dataSet = new DataSet();
                                dataSet = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                DataTable item1 = new DataTable();
                                item1 = dataSet.Tables[0];
                                DataTable item2 = new DataTable();
                                item2 = dataSet.Tables[1];
                                if (str12 == "a")
                                {
                                    foreach (DataRow row1 in item1.Rows)
                                    {
                                        empty10 = row1["email"].ToString();
                                        empty11 = string.Concat(row1["contactID"].ToString(), "~", row1["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty11.Split(chrArray);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str16 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays1 = str16.Split(chrArray);
                                        if (strArrays1[0].ToString() != "" && strArrays1[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                            else if (num10 <= Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays1[0].ToString()), strArrays1[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                        }
                                    }
                                }
                                else if (str12 != "da")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else
                                {
                                    foreach (DataRow row2 in item1.Rows)
                                    {
                                        if (!(row2["email"].ToString() != "") || row2["email"].ToString() == null)
                                        {
                                            continue;
                                        }
                                        empty10 = string.Concat(row2["email"].ToString(), ",");
                                        empty11 = string.Concat(row2["contactID"].ToString(), "~", row2["email"].ToString(), ",");
                                    }
                                    foreach (DataRow row3 in item2.Rows)
                                    {
                                        empty10 = string.Concat(empty10, row3["email"].ToString(), ",");
                                        str = new string[] { empty11, row3["contactID"].ToString(), "~", row3["email"].ToString(), "," };
                                        empty11 = string.Concat(str);
                                    }
                                    chrArray = new char[] { ',' };
                                    string[] strArrays2 = empty11.Split(chrArray);
                                    int num11 = 0;
                                    strArrays = strArrays2;
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str17 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays3 = str17.Split(chrArray);
                                        if (strArrays3[0].ToString() != "" && strArrays3[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                    if (this.IsBackOrder)
                                                    {
                                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                                        {
                                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                        }
                                                    }
                                                    else if (this.NEWORDER.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && num11 == 0 && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str12);
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                }
                                            }
                                            else if (num10 > Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays3[0].ToString()), strArrays3[1].ToString(), str12);
                                                if (num11 == 0)
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                }
                                            }
                                            else if (num11 == 0)
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                        }
                                        num11++;
                                    }
                                }
                            }
                            else if (this.UserType != "d")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                }
                            }
                            else if (str12 == "da")
                            {
                                if (this.objBc.Return_ApprovalSystem_Settings("reapproval").ToLower().Trim() != "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                    if (this.IsBackOrder)
                                    {
                                        if (this.BCKORDERTYPE.ToLower() == "true")
                                        {
                                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                        }
                                    }
                                    else if (this.NEWORDER.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else
                                {
                                    string empty12 = string.Empty;
                                    string empty13 = string.Empty;
                                    DataSet dataSet1 = new DataSet();
                                    dataSet1 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                    DataTable item3 = new DataTable();
                                    item3 = dataSet1.Tables[0];
                                    foreach (DataRow row4 in item3.Rows)
                                    {
                                        row4["email"].ToString();
                                        empty13 = string.Concat(row4["contactID"].ToString(), "~", row4["email"].ToString());
                                    }
                                    chrArray = new char[] { ',' };
                                    strArrays = empty13.Split(chrArray);
                                    for (i = 0; i < (int)strArrays.Length; i++)
                                    {
                                        string str18 = strArrays[i];
                                        chrArray = new char[] { '~' };
                                        string[] strArrays4 = str18.Split(chrArray);
                                        if (strArrays4[0].ToString() != "" && strArrays4[0].ToString() != null)
                                        {
                                            if (str15.ToString().Trim().ToLower() != "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (!(str14 != "") || !(str14 != "0"))
                                            {
                                                if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                            else if (num10 <= Convert.ToInt64(str14))
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                                if (this.IsBackOrder)
                                                {
                                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                                    {
                                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                    }
                                                }
                                                else if (this.NEWORDER.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays4[0].ToString()), strArrays4[1].ToString(), str12);
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (str12 != "a")
                            {
                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                if (this.IsBackOrder)
                                {
                                    if (this.BCKORDERTYPE.ToLower() == "true")
                                    {
                                        this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                    }
                                }
                                else if (this.NEWORDER.ToLower() == "true")
                                {
                                    this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                }
                            }
                            else
                            {
                                string empty14 = string.Empty;
                                string empty15 = string.Empty;
                                DataSet dataSet2 = new DataSet();
                                dataSet2 = LoginBasePage.ApproversEmail_Select(this.AccountID, this.DepartmentID);
                                DataTable item4 = new DataTable();
                                item4 = dataSet2.Tables[0];
                                foreach (DataRow dataRow4 in item4.Rows)
                                {
                                    dataRow4["email"].ToString();
                                    empty15 = string.Concat(dataRow4["contactID"].ToString(), "~", dataRow4["email"].ToString());
                                }
                                chrArray = new char[] { ',' };
                                strArrays = empty15.Split(chrArray);
                                for (i = 0; i < (int)strArrays.Length; i++)
                                {
                                    string str19 = strArrays[i];
                                    chrArray = new char[] { '~' };
                                    string[] strArrays5 = str19.Split(chrArray);
                                    if (strArrays5[0].ToString() != "" && strArrays5[0].ToString() != null)
                                    {
                                        if (str15.ToString().Trim().ToLower() != "true")
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                            }
                                        }
                                        else if (!(str14 != "") || !(str14 != "0"))
                                        {
                                            if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                            }
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str12);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                        }
                                        else if (num10 <= Convert.ToInt64(str14))
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                            if (this.IsBackOrder)
                                            {
                                                if (this.BCKORDERTYPE.ToLower() == "true")
                                                {
                                                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                                                }
                                            }
                                            else if (this.NEWORDER.ToLower() == "true")
                                            {
                                                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                                            }
                                        }
                                        else
                                        {
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", Convert.ToInt64(strArrays5[0].ToString()), strArrays5[1].ToString(), str12);
                                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (str15.ToString().Trim().ToLower() != "true")
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else if (!(str14 != "") || !(str14 != "0"))
                    {
                        if (this.IsBackOrder && this.BCKORDERTYPE.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                        }
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, str1, str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                    else if (num10 <= Convert.ToInt64(str14))
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                        if (this.IsBackOrder)
                        {
                            if (this.BCKORDERTYPE.ToLower() == "true")
                            {
                                this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Back Order", "Admin", (long)0, "no approval", str12);
                            }
                        }
                        else if (this.NEWORDER.ToLower() == "true")
                        {
                            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New Order", "Admin", (long)0, "no approval", str12);
                        }
                    }
                    else
                    {
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "New B2B Order", "Approver", (long)0, str1, str12);
                        this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(this.AccountID), "Thank you for your order", "Customer", (long)0, "", str12);
                    }
                }
            }
            var storeCredit = Convert.ToDouble(Session["StoreCredit"]);
            if (storeCredit > 0)
            {
                CartBasePage.Update_StoreCredit(StoreUserID, storeCredit);

            }
            Session["StoreCredit"] = null;
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["PaymentInfo"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            this.Session["CatgoryNotReqApproval"] = null;
            this.Session["DeptNotReqApproval"] = null;
            Session["Stripe_Payment_ID"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
            }
            else
            {
                HttpResponse response = base.Response;
                str = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                response.Redirect(string.Concat(str));
            }
            return true;
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "checkout.aspx'></a> ", this.objLanguage.GetLanguageConversion("checkout"));
            this.btnOrder.Text = this.objLanguage.GetLanguageConversion("Confirm_Order");
            this.Paypal_ButtonText = this.objLanguage.GetLanguageConversion("Proceed_To_Payment");
            this.OtherOptions_ButtonText = this.objLanguage.GetLanguageConversion("Confirm_Order");
           
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (EprintConfigurationManager.AppSettings["imagePath"] != null)
            {
                payment_information.imagePath = EprintConfigurationManager.AppSettings["imagePath"].ToString();
            }
            if (EprintConfigurationManager.AppSettings["StyleSheetPath"] != null)
            {
                this.StyleSheetPath = EprintConfigurationManager.AppSettings["StyleSheetPath"];
            }
            if (EprintConfigurationManager.AppSettings["eprintDocument"] != null)
            {
                this.eprintDocument = EprintConfigurationManager.AppSettings["eprintDocument"];
            }
            if (ConnectionClass.SecureDocFilepath != null)
            {
                this.SecureDocFilepath = ConnectionClass.SecureDocFilepath;
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.SecureDocPath != null)
            {
                this.SecureDocPath = ConnectionClass.SecureDocPath;
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
            }
            if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
            }
            if (!(ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg") || this.AccountID != (long)267)
            {
                this.lbl_payment.Text = this.objLanguage.GetLanguageConversion("Select_payment_option");
            }
            else
            {
                this.lbl_payment.Text = this.objLanguage.GetLanguageConversion("Select_Option");
            }
            if (this.comm.GetDisplayValue("isCheckLoginRegister", this.AccountID) == "false")
            {
                this.isLoginInfo = "0";
            }
          
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, this.AccountID).Rows)
            {
                this.AccountType = row["accountType"].ToString();
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
            }
          
            if (this.Session["StoreUserID"] == null && this.AccountType == "p" || this.AccountID == (long)0 && this.CompanyID == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            if (this.Session["PaymentInfo"] == null || this.Session["PaymentInfo"].ToString() == "")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "CheckOut.aspx"));
            }
            this.Session["PaymentStep"] = "";
            if (!base.IsPostBack)
            {

                DataTable dataTable = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string str = dataRow["paymentMode"].ToString().Trim();
                    char[] chrArray = new char[] { ',' };
                    this.paymentMode = str.Split(chrArray);
                    this.defaultpaymentMode = dataRow["defaultpaymentMode"].ToString();
                    this.hdn_Creditcardtypes.Value = dataRow["creaditCardTypes"].ToString().Trim();
                    this.hdn_Creditcardtypes_BT.Value = dataRow["creaditCardTypes"].ToString().Trim();
                    this.hdn_Creditcardtypes_ST.Value = dataRow["creaditCardTypes"].ToString().Trim();
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
                        if (!(ConnectionClass.ServerName.ToString().ToLower().Trim() == "fsg") || this.AccountID != (long)267)
                        {
                            this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Cheque_Money_Order");
                        }
                        else
                        {
                            this.ddl_payments.Items[i].Text = this.objLanguage.GetLanguageConversion("Confirom_order");
                        }
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
            //this.hdn_isOrderInformationAccessible.Value = "1";
            DataSet ds = OrderBasePage.approvalsystemsettings_getDetails(UserID, CompanyID, AccountID);
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                if (row["ShowCostCenters"].ToString().ToLower() != "true")
                {
                    this.ShowCostCenters = false;
                }
            }
            DataTable dt = OrderBasePage.settings_OrderingProcess_select(Convert.ToInt32(CompanyID), Convert.ToInt32(AccountID));
            foreach (DataRow dataRow in dt.Rows)
            {
                if (dataRow["isCheckOrderTitle"].ToString().ToLower() != "true")
                {
                    this.isCheckOrderTitle = false;
                }
                if (dataRow["isCheckOrderNumber"].ToString().ToLower() != "true")
                {
                    this.isCheckOrderNumber = false;
                }
                if (dataRow["isCheckDeliveryRequiredBy"].ToString().ToLower() != "true")
                {
                    this.isCheckDeliveryRequiredBy_1 = false;
                }
                if (dataRow["isCheckCooments"].ToString().ToLower() != "true")
                {
                    this.isCheckCooments = false;
                }
            }
            if (this.isCheckOrderTitle == false && this.isCheckOrderTitle == false && this.isCheckOrderNumber == false && this.isCheckDeliveryRequiredBy_1 == false && this.isCheckCooments == false)
            {
                //this.hdn_isOrderInformationAccessible.Value = "0";
                this.li3.Attributes.Add("style", "display:none");
                this.lblStep4.InnerText = "1";
                this.lblStep5.InnerText = "2";
                this.lblStep6.InnerText = "3";
            }
        }

    }
}