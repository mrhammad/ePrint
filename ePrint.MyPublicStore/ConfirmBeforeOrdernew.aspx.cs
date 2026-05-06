using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using System;
using System.Collections;
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
using Telerik.Web.UI;
namespace ePrint.MyPublicStore
{
    public partial class ConfirmBeforeOrdernew : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected TextBox txtaddressLabelBilling;

        //protected RequiredFieldValidator reqemail;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected Button btnApprEmail_Save;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_checkout;

        //protected Label lblCheckout;

        //protected Label Label2;

        //protected HtmlGenericControl li_Order;

        //protected HtmlGenericControl li_Address;

        //protected HtmlGenericControl li_Confirmation;

        //protected HtmlGenericControl li_payment;

        //protected Label lblOrderConfoHeader;

        //protected Label lblname;

        //protected Label lbl_name;

        //protected Label lblemail;

        //protected Label lbl_email;

        //protected Label lblUserRefOrderNo;

        //protected Label lbl_UserRefOrderNo;

        //protected HtmlGenericControl div_OrderNo;

        //protected Label lblOrderTitle;

        //protected Label lbl_OrderTitle;

        //protected HtmlGenericControl div_OrderTitle;

        //protected Label lblPayment;

        //protected Label lbl_Payment;

        //protected HtmlGenericControl div_PaymentType;

        //protected Label lblOrderDate;

        //protected Label lbl_OrderDate;

        //protected Label lblDeliverydate;

        //protected Label lbl_DeliveryDate;

        //protected HtmlGenericControl div_DeliveryRequiredby;

        //protected Label lblCouponCode;

        //protected Label lblCoupon_Code;

        //protected HtmlGenericControl DivCouponCode;

        //protected Label lbl_ShippingAddressID;

        //protected Label lbl_ShippingAddress;

        //protected HtmlGenericControl shipping_billingaddress;

        //protected Label lbl_BliingAddressID;

        //protected Label lbl_BliingAddress;

        //protected HtmlGenericControl order_billingAddress;

        //protected PlaceHolder plhorder_Header;

        //protected PlaceHolder plhorder;

        //protected Label lbl_subTotal;

        //protected PlaceHolder plhOrdAddOptions;

        //protected Label lbl_tax;

        //protected Label lbl_grandTotal;

        //protected Label lbl_subTotal_cost;

        //protected PlaceHolder plhOrdAddOptionsPrice;

        //protected Label lbl_TaxValue;

        //protected Label lbl_grandTotal_cost;

        //protected HtmlGenericControl Order_area;

        //protected CheckBox chk_terms_conditions;

        //protected Label lbl_terms_conditions;

        //protected HtmlGenericControl div_confirmOrder;

        //protected Button Button1;

        //protected Button btn_confirm;

        //protected HtmlGenericControl div_confirm;

        //protected Button Button2;

        //protected Button btn_PaymentInfo;

        //protected Image Image1;

        //protected HtmlGenericControl div_Payment;

        //protected HiddenField hdn_OrderID;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected RadScriptBlock RadScriptBlock1;

        //protected HtmlGenericControl div_imagePreview;

        //protected RadWindow ImagePopWindow;

        private commonclass comm = new commonclass();

        private BaseClass objBc = new BaseClass();

        private EmailClass Objemail = new EmailClass();

        public languageClass objLanguage = new languageClass();

        public int CompanyID;

        public long CartID;

        public long StoreUserID;

        public long OrderID;

        public int ProductID;

        public long ClientID;

        public int UserID;

        public decimal TotalPrice;

        public decimal Tax;

        public decimal OrderShipping;

        public static long AccountID;

        public char KeySeparator;

        public string Rewritemodule = string.Empty;

        private string NewSessionID = string.Empty;

        public string imageName = string.Empty;

        public string productImagePath = string.Empty;

        public string productImage = string.Empty;

        public string strSitepath = string.Empty;

        public string eprintDocument = string.Empty;

        public string FileExtension = string.Empty;

        public string Address = string.Empty;

        public string OrderKey = string.Empty;

        public string IsTerms = string.Empty;

        public string DateFormat = string.Empty;

        public string SystemName = string.Empty;

        public string AccountType = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string PaymentStep = string.Empty;

        public static string imagePath;

        public string strImagepath = BaseClass.imagePath();

        public bool IsPPW_SystemName;

        public string isLoginInfo = "1";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strSitePath = ConnectionClass.SitePath.ToString();

        public bool IsBackOrder;

        public string BCKORDERTYPE = string.Empty;

        public string NEWORDER = string.Empty;

        public int AvailableQuantity;

        public int NewQuantity;

        private string Prod_Id = string.Empty;

        private string MeasurementValue = string.Empty;

        private string HideAddress = string.Empty;

        public string isCheckOrderInfoPublic = string.Empty;

        public string isCheckAddressInfo = string.Empty;

        private DateTime OrderDate;

        private DateTime CreatedDate;

        public bool IsCumulative;

        public bool ISCouponCodeEnabled;

        public bool ISCouponCodeApplied;

        public string CouponCodeDisplay = "style='display:none;'";

        public bool IsCouponCodeApplied;

        public string CouponCodeDiscount = string.Empty;

        public string orderConfirm_footer_left_Style = string.Empty;

        public string orderConfirm_footer_right_Style = string.Empty;

        public string isCheckPaymentInfo = string.Empty;

        public string MainProductName = string.Empty;

        public long MainProductId;

        public string PDFToURLPath = string.Empty;

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

        static ConfirmBeforeOrdernew()
        {
            ConfirmBeforeOrdernew.AccountID = (long)0;
            ConfirmBeforeOrdernew.imagePath = string.Empty;
        }

        public ConfirmBeforeOrdernew()
        {
        }

        protected void btn_confirm_OnClick(object sender, EventArgs e)
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
                            ConfirmBeforeOrdernew confirmBeforeOrdernew = this;
                            confirmBeforeOrdernew.Prod_Id = string.Concat(confirmBeforeOrdernew.Prod_Id, row["ProductID"].ToString(), "$");
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
                                ConfirmBeforeOrdernew confirmBeforeOrdernew1 = this;
                                confirmBeforeOrdernew1.Prod_Id = string.Concat(confirmBeforeOrdernew1.Prod_Id, row["ProductID"].ToString(), "$");
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
            this.OrderPayment();
        }

        protected void btn_PaymentInfo_OnClick(object sender, EventArgs e)
        {
            this.Session["PaymentInfo"] = "0";
            HttpResponse response = base.Response;
            string[] strArrays = new string[] { this.strSitepath, "payment_information.aspx?Tp=", this.lbl_subTotal_cost.Text.Trim(), "&Tx=", this.lbl_TaxValue.Text.Trim() };
            response.Redirect(string.Concat(strArrays));
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

        private void Insert_Order(string CookieID, long StoreUserID, long BillingAddressID, long ShippingAddressID, long ClientID, string IsOrdered, string PaymentType, string RequiredDate, string Comments, string OrderTitle, string OrderNo, long CostCentreID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (IsOrdered == "no")
            {
                if (this.isLoginInfo != "0")
                {
                    ClientID = OrderBasePage.Insert_CustomerOn_Order((long)this.CompanyID, StoreUserID, ConfirmBeforeOrdernew.AccountID, BillingAddressID, ShippingAddressID, "no", this.CreatedDate,"","");
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
            long num = OrderBasePage.InsertOrderDetails_MIS(StoreUserID, ConfirmBeforeOrdernew.AccountID, this.TotalPrice, this.Tax, BillingAddressID, ShippingAddressID, (long)this.CompanyID, ClientID, PaymentType, this.OrderDate, Convert.ToDateTime(str2), Comments, this.OrderKey, OrderTitle, OrderNo, CostCentreID, "", "", (long)0, "");
            this.OrderID = num;
            this.hdn_OrderID.Value = this.OrderID.ToString();
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
                    if (File.Exists(empty))
                    {
                        object[] objArray1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        string str3 = string.Concat(objArray1);
                        if (!Directory.Exists(str3))
                        {
                            Directory.CreateDirectory(str3);
                        }
                        File.Copy(empty, string.Concat(str3, dataRow["PrintReadyFile"].ToString()), true);
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
                if (!File.Exists(str))
                {
                    continue;
                }
                object[] objArray3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                string str4 = string.Concat(objArray3);
                if (!Directory.Exists(str4))
                {
                    Directory.CreateDirectory(str4);
                }
                File.Copy(str, string.Concat(str4, dataRow["ReportFileName"].ToString()), true);
            }
            OrderBasePage.Insert_OrderItemDetails_ToNotes(num, (long)this.CompanyID, StoreUserID, (long)dataTable.Rows.Count);
            OrderBasePage.PriceCatalogue_ItemDescription_InsertUpdate(num);
        }

        public void OrderPayment()
        {
            if (this.Session["InsertOrder"] != null)
            {
                DataTable item = (DataTable)this.Session["InsertOrder"];
                if (item != null)
                {
                    foreach (DataRow row in item.Rows)
                    {
                        if (row["PaymentType"].ToString() == "PayPal")
                        {
                            if (row["PaymentType"].ToString() != "PayPal")
                            {
                                continue;
                            }
                            this.Session["BillingAddress"] = row["InvoiceAddressID"].ToString();
                            this.Session["ShippingAddress"] = row["DeliveryAddressID"].ToString();
                            this.Session["RequiredDate"] = row["RequiredBy"].ToString();
                            this.Session["Comments"] = row["Comments"].ToString();
                            this.Session["OrderTitle"] = row["OrderTitle"].ToString();
                            this.Session["UserRefOrderNo"] = row["OrderNumber"].ToString();
                            if (!ConnectionClass.IsAdvancePayPal)
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "checkout_paypal.aspx"));
                            }
                            else
                            {
                                base.Response.Redirect(string.Concat(this.strSitepath, "advanced_paypalapi.aspx"));
                            }
                        }
                        else
                        {
                            if (!(row["OrderID"].ToString() == "") && !(row["OrderID"].ToString() == "0"))
                            {
                                continue;
                            }
                            this.Insert_Order(row["SessionKey"].ToString(), Convert.ToInt64(row["StoreUserID"]), Convert.ToInt64(row["InvoiceAddressID"]), Convert.ToInt64(row["DeliveryAddressID"]), Convert.ToInt64(row["ClientID"]), row["IsOrdered"].ToString(), row["PaymentType"].ToString(), row["RequiredBy"].ToString(), row["Comments"].ToString(), row["OrderTitle"].ToString(), row["OrderNumber"].ToString(), Convert.ToInt64(row["CostCentreID"]));
                            DataTable dataTable = OrderBasePage.Select_OrderItems(Convert.ToInt64(this.hdn_OrderID.Value), this.StoreUserID);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                this.OrderKey = dataRow["OrderKey"].ToString();
                                long num = Convert.ToInt64(dataRow["ProductID"]);
                                int num1 = Convert.ToInt32(dataRow["Quantity"]);
                                decimal num2 = Convert.ToDecimal(dataRow["UnitPrice"]);
                                long num3 = Convert.ToInt64(dataRow["EstimateItemID"]);
                                long num4 = Convert.ToInt64(dataRow["OrderItemID"]);
                                BaseClass baseClass = new BaseClass();
                                string str = baseClass.Return_StockManagementSettings("SA_EstoreOrdersAndJobs");
                                string str1 = baseClass.Return_StockManagementSettings("SR_StockReductionMethod");
                                string str2 = baseClass.Return_StockManagementSettings("SR_IsStockPickFromSingleLoc");
                                if (!(str == "p") && !(str == "a"))
                                {
                                    continue;
                                }
                                foreach (DataRow row1 in baseClass.ProductStockType_Select((long)this.CompanyID, num).Rows)
                                {
                                    if (row1["DrawStockFrom"].ToString().ToLower() == "s")
                                    {
                                        baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(num), (long)0, num1, str1, "self", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                    }
                                    else if (row1["DrawStockFrom"].ToString().ToLower() == "o")
                                    {
                                        baseClass.StockAllocation_Others((long)this.CompanyID, num, num1, str1, Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                    }
                                    else if (row1["DrawStockFrom"].ToString().ToLower() != "a")
                                    {
                                        if (row1["DrawStockFrom"].ToString().ToLower() != "m")
                                        {
                                            continue;
                                        }
                                        foreach (DataRow dataRow1 in OrderBasePage.OtherMultipleProductDetails_Select(num, num1, true).Rows)
                                        {
                                            baseClass.StockAllocationProcess((long)this.CompanyID, Convert.ToInt64(dataRow1["KitItemID"].ToString()), num, num1, str1, "multiple", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID);
                                        }
                                    }
                                    else
                                    {
                                        baseClass.StockAllocationForAdditionalOption((long)this.CompanyID, num, num1, str1, "additional option", Convert.ToBoolean(str2), num3, "Job", num2, this.StoreUserID, Convert.ToInt64(this.hdn_OrderID.Value), num4);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.Session["Insert_CreditCardDetails"] != null)
            {
                DataTable item1 = (DataTable)this.Session["Insert_CreditCardDetails"];
                if (item1 != null)
                {
                    foreach (DataRow row2 in item1.Rows)
                    {
                        OrderBasePage.Insert_CreditCardDetails(Convert.ToInt64(this.hdn_OrderID.Value), row2["HolderName"].ToString(), "", Convert.ToInt64(row2["CardNumber"]), row2["CardType"].ToString(), row2["Verification"].ToString(), Convert.ToInt32(row2["Month"]), Convert.ToInt32(row2["Year"]));
                        ConfirmBeforeOrdernew.AccountID = (long)Convert.ToInt32(row2["AccountID"]);
                    }
                }
            }
            this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrdernew.AccountID), "Thank you for your order");
            if (this.IsBackOrder)
            {
                if (this.BCKORDERTYPE.ToLower() == "true")
                {
                    this.Objemail.emailOrdersDetailsBackOrder(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrdernew.AccountID), "Back Order");
                }
            }
            else if (this.NEWORDER.ToLower() == "true")
            {
                this.Objemail.emailOrdersDetails(this.StoreUserID, this.OrderID, this.CompanyID, Convert.ToInt32(ConfirmBeforeOrdernew.AccountID), "New Order");
            }
            this.Session["InsertOrder"] = null;
            this.Session["Insert_CreditCardDetails"] = null;
            this.Session["CheckOut"] = null;
            this.Session["ConfirmBeforeOrdernew"] = null;
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "order_confirmation.aspx?OrdKey=", this.OrderKey, "&type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "order_confirmation", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] accountID;
            string empty = string.Empty;
            string str = string.Empty;
            this.PDFToURLPath = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            this.btn_PaymentInfo.Text = this.objLanguage.GetLanguageConversion("Continue");
            this.Button2.Text = this.objLanguage.GetLanguageConversion("Back");
            if (this.Session["PaymentStep"] != null && (this.Session["PaymentStep"].ToString() != null || this.Session["PaymentStep"].ToString() != ""))
            {
                this.PaymentStep = this.Session["PaymentStep"].ToString();
            }
            if (this.Session["ConfirmBeforeOrdernew"] == null || this.Session["ConfirmBeforeOrdernew"].ToString() == "")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "CheckOutnew.aspx"));
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "edit", "javascript:FourthStep();", true);
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                ConfirmBeforeOrdernew.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("Order confirmation", Convert.ToInt32(this.CompanyID), Convert.ToInt32(ConfirmBeforeOrdernew.AccountID));
            if (EprintConfigurationManager.AppSettings["imagePath"] != null)
            {
                ConfirmBeforeOrdernew.imagePath = EprintConfigurationManager.AppSettings["imagePath"].ToString();
            }
            if (EprintConfigurationManager.AppSettings["productImagePath"] != null)
            {
                this.productImagePath = EprintConfigurationManager.AppSettings["productImagePath"];
            }
            if (EprintConfigurationManager.AppSettings["eprintDocument"] != null)
            {
                this.eprintDocument = EprintConfigurationManager.AppSettings["eprintDocument"];
            }
            if (EprintConfigurationManager.AppSettings["SitePath"] != null)
            {
                this.strSitepath = EprintConfigurationManager.AppSettings["SitePath"];
            }
            if (this.Session["StoreUserID"] == null)
            {
                this.Session["fromEmail"] = base.Request.Url.ToString();
                base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
            }
            else
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            if (EprintConfigurationManager.AppSettings["FileExtension"] != null)
            {
                this.FileExtension = EprintConfigurationManager.AppSettings["FileExtension"].ToString();
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = EprintConfigurationManager.AppSettings["RewriteModule"].ToString();
            }
            if (ConnectionClass.SystemName != null)
            {
                this.SystemName = ConnectionClass.SystemName.ToLower().Trim();
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            if (this.comm.GetDisplayValue("isCheckLoginRegister", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.isLoginInfo = "0";
            }
            if (this.comm.GetDisplayValue("isCheckOut", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.lbl_checkout.Visible = false;
                this.lblCheckout.Visible = true;
            }
            string displayValue = this.comm.GetDisplayValue("OrderTitleText", ConfirmBeforeOrdernew.AccountID);
            this.lblOrderTitle.Text = string.Concat(displayValue, ":");
            string displayValue1 = this.comm.GetDisplayValue("OrderNumberText", ConfirmBeforeOrdernew.AccountID);
            this.lblUserRefOrderNo.Text = string.Concat(displayValue1, ":");
            string str1 = this.comm.GetDisplayValue("DeliveryRequiredByText", ConfirmBeforeOrdernew.AccountID);
            this.lblDeliverydate.Text = string.Concat(str1, ":");
            if (this.comm.GetDisplayValue("isCBOOrderNumber", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_OrderNo.Style.Add("display", "none");
            }
            else if (this.comm.GetDisplayValue("isCheckOrderNumber", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_OrderNo.Style.Add("display", "none");
            }
            else
            {
                this.div_OrderNo.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCBOOrderTitle", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_OrderTitle.Style.Add("display", "none");
            }
            else if (this.comm.GetDisplayValue("isCheckOrderTitle", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_OrderTitle.Style.Add("display", "none");
            }
            else
            {
                this.div_OrderTitle.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_DeliveryRequiredby.Style.Add("display", "none");
            }
            else
            {
                this.div_DeliveryRequiredby.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCBOPaymentType", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.div_PaymentType.Style.Add("display", "none");
            }
            else
            {
                this.div_PaymentType.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCBOInvoiceAddress", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.order_billingAddress.Style.Add("display", "none");
            }
            else
            {
                this.order_billingAddress.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCBODeliveryAddress", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.shipping_billingaddress.Style.Add("display", "none");
            }
            else
            {
                this.shipping_billingaddress.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isCheckAddressInfo", ConfirmBeforeOrdernew.AccountID) != "false")
            {
                if (this.comm.GetDisplayValue("isCheckInvoiceInfo", ConfirmBeforeOrdernew.AccountID) == "false")
                {
                    this.order_billingAddress.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckDeliveryInfo", ConfirmBeforeOrdernew.AccountID) == "false")
                {
                    this.shipping_billingaddress.Style.Add("display", "none");
                }
            }
            else
            {
                this.HideAddress = "yes";
                this.order_billingAddress.Style.Add("display", "none");
                this.shipping_billingaddress.Style.Add("display", "none");
            }
            this.isCheckOrderInfoPublic = this.comm.GetDisplayValue("isCheckOrderInfoPublic", ConfirmBeforeOrdernew.AccountID).ToLower().Trim();
            this.isCheckAddressInfo = this.comm.GetDisplayValue("isCheckAddressInfo", ConfirmBeforeOrdernew.AccountID).ToLower().Trim();
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string str3 = "style='display:block;'";
            string str4 = "style='display:block;'";
            if (this.comm.GetDisplayValue("isCBOUnitPrice", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                empty = "style='display:none;'";
                str3 = "style='display:none;'";
                str2 = "style='width:94px;'";
            }
            if (this.comm.GetDisplayValue("isCBOTotal", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                str = "style='display:none'";
                str4 = "style='display:none;'";
            }
            if (this.comm.GetDisplayValue("isCBOSubtotal", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.lbl_subTotal.Style.Add("display", "none");
                this.lbl_subTotal_cost.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCBOTotalTax", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.lbl_tax.Style.Add("display", "none");
                this.lbl_TaxValue.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCBOGrandTotal", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.lbl_grandTotal.Style.Add("display", "none");
                this.lbl_grandTotal_cost.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("IsHome", ConfirmBeforeOrdernew.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(ConfirmBeforeOrdernew.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                if (RewriteContext.Current.Params["OrdKey"] != null)
                {
                    string str5 = RewriteContext.Current.Params["OrdKey"].ToString();
                    char[] keySeparator = new char[] { this.KeySeparator };
                    this.OrderKey = str5.Split(keySeparator)[1].ToString();
                }
            }
            else if (base.Request.Params["OrdKey"] != null)
            {
                this.OrderKey = base.Request.Params["OrdKey"].ToString();
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, ConfirmBeforeOrdernew.AccountID).Rows)
            {
                this.AccountType = row["accountType"].ToString();
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
            }
            this.CreatedDate = DateTime.Now;
            this.NewSessionID = this.comm.UniqueID;
            if (!base.IsPostBack && this.StoreUserID != (long)0)
            {
                int num = 0;
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string str6 = string.Empty;
                DataSet dataSet = OrderBasePage.Select_OrderItems_BeforeOrder(this.StoreUserID);
                DataTable item = dataSet.Tables[0];
                foreach (DataRow dataRow in item.Rows)
                {
                    this.ISCouponCodeEnabled = Convert.ToBoolean(dataRow["ISCouponCodeEnabled"]);
                    if (this.ISCouponCodeApplied)
                    {
                        continue;
                    }
                    this.ISCouponCodeApplied = Convert.ToBoolean(dataRow["ISCouponCodeApplied"]);
                    empty5 = dataRow["UserFriendlyName"].ToString();
                    empty6 = dataRow["CouponCode"].ToString();
                    str6 = dataRow["CouponCodeDiscount"].ToString();
                }
                if (this.ISCouponCodeEnabled)
                {
                    this.CouponCodeDisplay = "style='display:table-cell;'";
                }
                string empty7 = string.Empty;
                long num3 = (long)0;
                this.plhorder.Controls.Add(new LiteralControl("<table class='b_productName_table table'>"));
                this.plhorder.Controls.Add(new LiteralControl("<tr>"));
                this.plhorder.Controls.Add(new LiteralControl("<th id='h_productName'></th>"));
                ControlCollection controls = this.plhorder.Controls;
                string[] languageConversion = new string[] { "<th id='h_productName'", empty1, " style='min-width:80px'><strong>", this.objLanguage.GetLanguageConversion("Product_Name"), " </strong></th>" };
                controls.Add(new LiteralControl(string.Concat(languageConversion)));
                ControlCollection controlCollections = this.plhorder.Controls;
                string[] strArrays = new string[] { "<th id='h_productDescription'", empty1, "><strong>", this.objLanguage.GetLanguageConversion("Product_Description"), " </strong></th>" };
                controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
                ControlCollection controls1 = this.plhorder.Controls;
                string[] languageConversion1 = new string[] { "<th id='h_productPrice2'", empty, "><strong>", this.objLanguage.GetLanguageConversion("Unit_Price"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></th>" };
                controls1.Add(new LiteralControl(string.Concat(languageConversion1)));
                ControlCollection controlCollections1 = this.plhorder.Controls;
                string[] strArrays1 = new string[] { "<th id='h_TaxApplicable'", empty, "><strong>", this.objLanguage.GetLanguageConversion("Tax_Applicable"), "</strong></th>" };
                controlCollections1.Add(new LiteralControl(string.Concat(strArrays1)));
                ControlCollection controls2 = this.plhorder.Controls;
                languageConversion = new string[] { "<th id='h_productQty'", empty2, "><strong>", this.objLanguage.GetLanguageConversion("Qty"), " </strong></th>" };
                controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                ControlCollection controlCollections2 = this.plhorder.Controls;
                languageConversion = new string[] { "<th id='h_productDiscount'", this.CouponCodeDisplay, "><strong>", this.objLanguage.GetLanguageConversion("Discount"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></th>" };
                controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                if (!this.ISCouponCodeEnabled)
                {
                    ControlCollection controls3 = this.plhorder.Controls;
                    languageConversion = new string[] { "<th id='h_productTotal'", str, "><strong>", this.objLanguage.GetLanguageConversion("Total_ex_Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></th>" };
                    controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    if (str == "")
                    {
                        str = "style='width:114px;'";
                    }
                    ControlCollection controlCollections3 = this.plhorder.Controls;
                    languageConversion = new string[] { "<th id='h_productTotal'", str, "><strong>", this.objLanguage.GetLanguageConversion("Total_ex_Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")</strong></th>" };
                    controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                this.plhorder.Controls.Add(new LiteralControl("</tr>"));
                foreach (DataRow row1 in item.Rows)
                {
                    if (Convert.ToInt64(row1["MainProductID"]) != (long)0)
                    {
                        this.MainProductName = CartBasePage.Select_MainProductName(Convert.ToInt64(row1["MainProductID"]));
                        this.MainProductId = Convert.ToInt64(row1["MainProductID"]);
                    }
                    this.IsCumulative = Convert.ToBoolean(row1["IsCumulativePricing"].ToString());
                    this.NewQuantity = Convert.ToInt32(row1["Quantity"].ToString());
                    this.lbl_name.Text = this.objBc.SpecialDecode(string.Concat(row1["FirstName"].ToString(), " ", row1["LastName"].ToString()));
                    this.lbl_email.Text = this.objBc.SpecialDecode(row1["EmailID"].ToString());
                    if (this.ISCouponCodeApplied && this.ISCouponCodeEnabled)
                    {
                        this.DivCouponCode.Style.Add("display", "block");
                        Label lblCouponCode = this.lblCoupon_Code;
                        languageConversion = new string[] { empty5, "(", empty6, ") - ", str6 };
                        lblCouponCode.Text = string.Concat(languageConversion);
                    }
                    this.plhorder.Controls.Add(new LiteralControl("<tr class='b_productName_tr'>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_PDF_td'>"));
                    string str7 = string.Empty;
                    if (row1["PrintReadyFile"].ToString() != "")
                    {
                        str7 = "printready";
                        if (ConnectionClass.ServerName.ToLower() == "creativeatlanta" || ConnectionClass.ServerName.ToLower() == "creativeapproach")
                        {
                            ControlCollection controls4 = this.plhorder.Controls;
                            accountID = new object[] { "<img id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ConfirmBeforeOrdernew.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Template / Print Ready Requirement' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", row1["PrintReadyFile"].ToString(), "\",", ConfirmBeforeOrdernew.AccountID, ",\"", str7, "\");'/>" };
                            controls4.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        else
                        {
                            ControlCollection controlCollections4 = this.plhorder.Controls;
                            accountID = new object[] { "<img id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ConfirmBeforeOrdernew.AccountID, "&amp;cid=", this.CompanyID, "' title='Open Print Ready File' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", row1["PrintReadyFile"].ToString(), "\",", ConfirmBeforeOrdernew.AccountID, ",\"", str7, "\");'/>" };
                            controlCollections4.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    else if (row1["PDFNameFromCart"].ToString() != "")
                    {
                        if (row1["PreviewType"].ToString() == "" || row1["PreviewType"].ToString() == "pdfimg" || row1["PreviewType"].ToString() == "pdf")
                        {
                            str7 = "pdf";
                            ControlCollection controls5 = this.plhorder.Controls;
                            accountID = new object[] { "<img id='img_Pdf_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=PDFNEW1.jpg&amp;type=r&amp;aid=", ConfirmBeforeOrdernew.AccountID, "&amp;cid=", this.CompanyID, "' title='Open PDF' alt=' ' onclick='javascript:Pdf_OpenShopping(\"", row1["PDFNameFromCart"].ToString(), "\",", ConfirmBeforeOrdernew.AccountID, ",\"", str7, "\");'/>" };
                            controls5.Add(new LiteralControl(string.Concat(accountID)));
                        }
                        if (row1["ImageNameFromCart"].ToString() != "" && (row1["PreviewType"].ToString() == "pdfimg" || row1["PreviewType"].ToString() == "img"))
                        {
                            str7 = "previewimage";
                            ControlCollection controlCollections5 = this.plhorder.Controls;
                            accountID = new object[] { "<div class='floatLeft paddingLeft5'><img id='img_img_", num, "' class='img_trash WS_Cursor_Style' target='' src='", this.strSitepath, "ImageHandler.ashx?ImageName=imgIcon.png&amp;type=r&amp;aid=", ConfirmBeforeOrdernew.AccountID, "&amp;cid=", this.CompanyID, "' title='View Image' alt=' ' onclick='javascript:Pdf_ImagPopup(\"", row1["ImageNameFromCart"].ToString(), "\",", ConfirmBeforeOrdernew.AccountID, ",\"", this.strSitepath, "\",\"", str7, "\");'/></div>" };
                            controlCollections5.Add(new LiteralControl(string.Concat(accountID)));
                        }
                    }
                    if (row1["UploadFile"].ToString() != "" || row1["UploadFile1"].ToString() != "" || row1["UploadFile2"].ToString() != "")
                    {
                        ControlCollection controls6 = this.plhorder.Controls;
                        accountID = new object[] { "<a ><img id='img_Edit_", num, "' onclick='openArtworkPopup(", row1["CartItemID"].ToString(), ",", row1["CartID"].ToString(), ") ' class='img_trash WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", ConfirmBeforeOrdernew.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/>" };
                        controls6.Add(new LiteralControl(string.Concat(accountID)));
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productName_td' data-label='"+ this.objLanguage.GetLanguageConversion("Product_Name") + "'", empty1, ">")));
                    Label label = new Label()
                    {
                        ID = string.Concat("lblproductName_", num),
                        Text = this.objBc.SpecialDecode(row1["CatalogueName"].ToString())
                    };
                    Label label1 = new Label()
                    {
                        ID = string.Concat("lblMainproductName", num),
                        Text = this.objBc.SpecialDecode(this.MainProductName)
                    };
                    if (row1["MatrixType"].ToString().ToLower() == "g")
                    {
                        string str8 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Width"].ToString()), 2, "", false, false, true);
                        string str9 = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Height"].ToString()), 2, "", false, false, true);
                        languageConversion = new string[] { label.Text, "<br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Dimension"), "(", this.MeasurementValue, ") </label></span><br/><span class='smallfontgrey'><label>", this.objLanguage.GetLanguageConversion("Width"), ":&nbsp;", str8, " </label><br/><label>", this.objLanguage.GetLanguageConversion("Height"), ":&nbsp;", str9, " </label></span>" };
                        label.Text = string.Concat(languageConversion);
                    }
                    if (this.MainProductId != (long)0)
                    {
                        this.plhorder.Controls.Add(new LiteralControl("<div style='width:250px;'>"));
                        this.plhorder.Controls.Add(label1);
                        this.plhorder.Controls.Add(new LiteralControl("</div>"));
                    }
                    this.plhorder.Controls.Add(label);
                    int num4 = 0;
                    DataTable dataTable = CartBasePage.Select_CartAdditionalItems(Convert.ToInt64(row1["CartItemID"]));
                    foreach (DataRow dataRow1 in dataTable.Rows)
                    {
                        if (Convert.ToInt32(dataRow1["CheckCount"]) <= 0)
                        {
                            break;
                        }
                        if (Convert.ToInt32(dataRow1["OptionID"]) <= 0)
                        {
                            continue;
                        }
                        Label label2 = new Label()
                        {
                            ID = string.Concat("lblAdditionalName_", num, num4)
                        };
                        label2.Style.Add("padding-left", "10px");
                        if (num4 == 0)
                        {
                            this.plhorder.Controls.Add(new LiteralControl(string.Concat("<br/><div class='marginTop5'><Strong><label><i>", this.objLanguage.GetLanguageConversion("Additional_Items"), "</i></label></Strong></div>")));
                        }
                        label2.Text = string.Concat(this.objBc.SpecialDecode(dataRow1["UserFriendlyName"].ToString()), "</br>");
                        this.plhorder.Controls.Add(label2);
                        if (dataRow1["MainCalculationType"].ToString().ToLower() == "c")
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<div>"));
                            Label label3 = new Label();
                            accountID = new object[] { "lblSelectedValue_", num, "_", num4 };
                            label3.ID = string.Concat(accountID);
                            label3.Text = this.objBc.SpecialDecode(dataRow1["SelectedValue"].ToString().Trim());
                            label3.Attributes.Add("style", "padding-left:20px; font-size:11px;");
                            this.plhorder.Controls.Add(label3);
                            this.plhorder.Controls.Add(new LiteralControl("<span>&nbsp;&nbsp;</span>"));
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        num4++;
                    }
                    if (num4 == 0)
                    {
                        if (this.MainProductId != (long)0)
                        {
                            this.plhorder.Controls.Add(new LiteralControl("<div>"));
                            this.plhorder.Controls.Add(label1);
                            this.plhorder.Controls.Add(new LiteralControl("</div>"));
                        }
                        this.plhorder.Controls.Add(new LiteralControl("<div>"));
                        this.plhorder.Controls.Add(label);
                        this.plhorder.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        this.plhorder.Controls.Add(new LiteralControl("</div></div>"));
                    }
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productDescription_td' data-label='" + this.objLanguage.GetLanguageConversion("Product_Description") + "'", empty1, ">")));
                    Label label4 = new Label()
                    {
                        ID = string.Concat("lblproductDescription_", num),
                        Text = this.objBc.SpecialDecode(row1["Description"].ToString())
                    };
                    this.plhorder.Controls.Add(new LiteralControl("<div style='width:150px;'>"));
                    this.plhorder.Controls.Add(label4);
                    this.plhorder.Controls.Add(new LiteralControl("</div>"));
                    this.plhorder.Controls.Add(new LiteralControl("</td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productPrice_td' data-label='" + this.objLanguage.GetLanguageConversion("Unit_Price") + "'", str3, "><div style='width:85px;float:right'>")));
                    Label label5 = new Label()
                    {
                        ID = string.Concat("lblproductPrice_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["UnitPrice"].ToString()), 2, "", false, false, true)
                    };
                    this.plhorder.Controls.Add(label5);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_TaxApplicable_td' data-label='" + this.objLanguage.GetLanguageConversion("Tax_Applicable") + "'><div style='width:110px;'>"));
                    Label label6 = new Label()
                    {
                        ID = string.Concat("lblTaxApplicable_", num),
                        Text = string.Concat(row1["TaxName"].ToString(), " - ", this.comm.ToRemoveDecimalPlacesIfZero(this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Tax"]), 2, "", false, false, true)), "%")
                    };
                    this.plhorder.Controls.Add(label6);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productQty_td' data-label='" + this.objLanguage.GetLanguageConversion("Qty") + "'", str2, "><div style='width:40px;float:right'>")));
                    Label label7 = new Label()
                    {
                        ID = string.Concat("lblproductQty_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Quantity"].ToString()), 0, "", true, false, true)
                    };
                    this.plhorder.Controls.Add(label7);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    if (this.ISCouponCodeEnabled)
                    {
                        this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productQty_td' data-label='" + this.objLanguage.GetLanguageConversion("Qty") + "'", str2, " style='padding-right:4px;'><div style='width:80px;float:right'>")));
                        Label label8 = new Label()
                        {
                            ID = string.Concat("lbl_CouponCodeDiscount_", row1["CartItemID"].ToString()),
                            Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["CouponCodeDiscountAmount"].ToString()), 0, "", false, false, true)
                        };
                        this.plhorder.Controls.Add(label8);
                        this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    }
                    this.plhorder.Controls.Add(new LiteralControl(string.Concat("<td class='b_productTotal_td' data-label='" + this.objLanguage.GetLanguageConversion("Total_ex_Tax") + "'", str4, "><div style='width:106px;float:right'>")));
                    Label label9 = new Label()
                    {
                        ID = string.Concat("lblproductTotal_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["UnitPrice"].ToString()) * Convert.ToDecimal(row1["Quantity"].ToString()), 2, "", false, false, true)
                    };
                    num1 = num1 + (Convert.ToDecimal(row1["UnitPrice"].ToString()) * Convert.ToDecimal(row1["Quantity"].ToString()));
                    this.plhorder.Controls.Add(label9);
                    this.plhorder.Controls.Add(new LiteralControl("</div></td>"));
                    decimal num5 = Convert.ToDecimal(row1["UnitPrice"].ToString()) * Convert.ToDecimal(row1["Quantity"].ToString());
                    decimal num6 = Convert.ToDecimal(row1["Tax"]);
                    num2 = num2 + (num5 * (num6 / new decimal(100)));
                    this.plhorder.Controls.Add(new LiteralControl("<td class='b_productTotal_td1 displayNone'><div class='displayNone'>"));
                    Label label10 = new Label()
                    {
                        ID = string.Concat("lblproductTax_", num),
                        Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row1["Tax"].ToString()), 2, "", false, false, true)
                    };
                    this.plhorder.Controls.Add(label10);
                    this.plhorder.Controls.Add(new LiteralControl("</td></tr>"));
                    num++;
                }
                this.plhorder.Controls.Add(new LiteralControl("</table>"));
                int num7 = 0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                foreach (DataRow row2 in dataSet.Tables[1].Rows)
                {
                    ControlCollection controlCollections6 = this.plhOrdAddOptions.Controls;
                    accountID = new object[] { "<label id='lblOrderAddValue_", num7, "'> ", row2["SelectedValue"].ToString(), "</label><br/>" };
                    controlCollections6.Add(new LiteralControl(string.Concat(accountID)));
                    ControlCollection controls7 = this.plhOrdAddOptionsPrice.Controls;
                    accountID = new object[] { "<label id='lblOrderAddPrice_", num7, "'> ", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(row2["SelectedPrice"].ToString()), 2, "", false, false, true), "</label><br/>" };
                    controls7.Add(new LiteralControl(string.Concat(accountID)));
                    num8 = num8 + Convert.ToDecimal(row2["SelectedPrice"]);
                    num9 = num9 + ((Convert.ToDecimal(row2["SelectedPrice"]) * Convert.ToDecimal(row2["cartAdditionalTaxPercentage"])) / new decimal(100));
                    num7++;
                }
                num10 = num2 + num9;
                this.lbl_subTotal_cost.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num1, 2, "", false, false, true);
                this.lbl_TaxValue.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, num10, 2, "", false, false, true);
                this.lbl_grandTotal_cost.Text = string.Concat(this.comm.GetCurrencyinRequiredFormate("", true), this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num10) + num8, 2, "", false, false, true));
                this.Session["GrandTotal"] = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, (num1 + num10) + num8, 2, "", false, false, true);
                foreach (DataRow dataRow2 in dataSet.Tables[2].Rows)
                {
                    this.IsTerms = dataRow2["IsTerms"].ToString().ToLower();
                    if (dataRow2["IsTerms"].ToString().ToLower() != "true")
                    {
                        continue;
                    }
                    this.div_confirmOrder.Style.Add("display", "block");
                    this.lbl_terms_conditions.Text = dataRow2["TermsAndCondition"].ToString();
                }
                if (this.Session["InsertOrder"] != null)
                {
                    DataTable item1 = (DataTable)this.Session["InsertOrder"];
                    if (item1 != null)
                    {
                        foreach (DataRow row3 in item1.Rows)
                        {
                            if (this.HideAddress != "yes")
                            {
                                this.Return_address(this.StoreUserID, "", num3, Convert.ToInt64(row3["InvoiceAddressID"]), out this.Address);
                                this.lbl_BliingAddress.Text = this.objBc.SpecialDecode(this.Address);
                                this.Return_address(this.StoreUserID, "", num3, Convert.ToInt64(row3["DeliveryAddressID"]), out this.Address);
                                this.lbl_ShippingAddress.Text = this.objBc.SpecialDecode(this.Address);
                            }
                            else
                            {
                                this.lbl_BliingAddress.Text = "";
                                this.lbl_ShippingAddress.Text = "";
                            }
                            this.lbl_UserRefOrderNo.Text = this.objBc.SpecialDecode(row3["OrderNumber"].ToString());
                            this.lbl_OrderTitle.Text = this.objBc.SpecialDecode(row3["OrderTitle"].ToString());
                            this.lbl_OrderDate.Text = this.comm.Eprint_return_Date_Before_View(this.CreatedDate.ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_DeliveryDate.Text = row3["Requiredby"].ToString();
                            this.lbl_Payment.Text = row3["PaymentType"].ToString();
                        }
                    }
                }
                if (this.lbl_BliingAddress.Text == "")
                {
                    this.order_billingAddress.Attributes.Add("style", "display:none");
                }
                if (this.lbl_ShippingAddress.Text == "")
                {
                    this.shipping_billingaddress.Attributes.Add("style", "display:none");
                }
            }
            this.isCheckPaymentInfo = this.comm.GetDisplayValue("isCheckPaymentInfo", ConfirmBeforeOrdernew.AccountID);
            if (this.comm.GetDisplayValue("isCheckPaymentInfo", ConfirmBeforeOrdernew.AccountID) != "false")
            {
                this.div_confirm.Attributes.Add("style", "display:none");
                this.div_Payment.Attributes.Add("style", "display:block; float: left; width: 100%; margin: 10px 0px 14px 8px;");
                this.li_payment.Attributes.Add("style", "display:block; margin: 0px 0px 0px 1px;");
            }
            else
            {
                this.div_confirm.Attributes.Add("style", "display:block; float: left; width: 100%; margin: 0px 0px 0px 8px;");
                this.div_Payment.Attributes.Add("style", "display:none");
                this.li_payment.Attributes.Add("style", "display:none;");
                this.li_Confirmation.Attributes.Add("class", "HideArrow");
            }
            if (this.comm.GetDisplayValue("isCheckOrderInfoPublic", ConfirmBeforeOrdernew.AccountID) != "false")
            {
                this.li_Order.Style.Add("display", "block");
            }
            else
            {
                this.li_Order.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckAddressInfo", ConfirmBeforeOrdernew.AccountID) != "false")
            {
                this.li_Address.Style.Add("display", "block");
            }
            else
            {
                this.li_Address.Style.Add("display", "none");
            }
            if (this.comm.GetDisplayValue("isCheckAddressInfo", ConfirmBeforeOrdernew.AccountID) == "false" && this.comm.GetDisplayValue("isCheckOrderInfoPublic", ConfirmBeforeOrdernew.AccountID) == "false" && this.comm.GetDisplayValue("isCheckPaymentInfo", ConfirmBeforeOrdernew.AccountID) == "false")
            {
                this.li_Confirmation.Attributes.Add("class", "HideArrow");
            }

        }

        public void Return_address(long StoreUserID, string type, long ContactID, long AddressID, out string Address)
        {
            string empty = string.Empty;
            foreach (DataRow row in OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(AddressID)).Rows)
            {
                if (Convert.ToInt64(row["AddressID"].ToString()) != AddressID)
                {
                    continue;
                }
                string[] strArrays = row["Address"].ToString().Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        if (i != 6)
                        {
                            empty = (i != 7 ? string.Concat(empty, strArrays[i], "<br/>") : string.Concat(empty, "F: ", strArrays[i], "<br/>"));
                        }
                        else
                        {
                            empty = string.Concat(empty, "T: ", strArrays[i], "<br/>");
                        }
                    }
                }
            }
            Address = empty;
        }

        public int SimpleMatrixCumulativePriceingQty(int qty, int ProductID)
        {
            int num;
            if (qty == 0)
            {
                return qty;
            }
            DataTable dataTable = ProductBasePage.Product_CatalogueQty_Select((long)ProductID);
            string[] strArrays = new string[dataTable.Rows.Count];
            string[] strArrays1 = new string[dataTable.Rows.Count];
            string[] strArrays2 = new string[dataTable.Rows.Count];
            string[] strArrays3 = new string[dataTable.Rows.Count];
            string[] strArrays4 = new string[dataTable.Rows.Count];
            int count = dataTable.Rows.Count;
            int num1 = 0;
            if (dataTable.Rows.Count > 0)
            {
                int num2 = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    strArrays.SetValue(row["FromQuantity"].ToString(), num2);
                    strArrays1.SetValue(row["ToQuantity"].ToString(), num2);
                    strArrays2.SetValue(row["Price"].ToString(), num2);
                    strArrays3.SetValue(row["SellingPrice"].ToString(), num2);
                    strArrays4.SetValue(row["Markup"].ToString(), num2);
                    num2++;
                }
            }
            int num3 = 0;
        Label1:
            while (num3 < (int)strArrays.Length)
            {
                try
                {
                    if (num3 == 0)
                    {
                        Convert.ToInt32(strArrays[num3].ToString());
                    }
                    if (qty <= Convert.ToInt32(strArrays[num3].ToString()))
                    {
                        num = Convert.ToInt32(strArrays[num3].ToString());
                    }
                    else if (qty >= Convert.ToInt32(strArrays[num3].ToString()) && qty <= Convert.ToInt32(strArrays1[num3].ToString()))
                    {
                        num = Convert.ToInt32(strArrays1[num3].ToString());
                    }
                    else if (qty > Convert.ToInt32(strArrays1[num3].ToString()) && qty < Convert.ToInt32(strArrays[num3 + 1].ToString()))
                    {
                        num = Convert.ToInt32(strArrays[num3 + 1].ToString());
                    }
                    else if (Convert.ToInt32(num3) != Convert.ToInt32((int)strArrays.Length - 1))
                    {
                        goto Label0;
                    }
                    else
                    {
                        num = Convert.ToInt32(strArrays[num3].ToString());
                    }
                }
                catch
                {
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        if (i == (int)strArrays1.Length - 1)
                        {
                            num1 = Convert.ToInt32(strArrays1[i]);
                        }
                    }
                    num = num1;
                }
                return num;
            }
            return qty;
        Label0:
            num3++;
            goto Label1;
        }
    }
}