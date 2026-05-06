using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.WebStore
{
    public partial class checkout : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected HtmlGenericControl div_EmptyCart;

        //protected HtmlGenericControl li_payment;

        //protected HtmlGenericControl li1;

        //protected usercontrol_orderinformation ucOrderInfo;

        //protected usercontrol_invoice_del_Info ucAddressInfo;

        //protected Button btn_billingAddress;

        //protected Button btn_BackShop;

        //protected Image Image1;

        //protected LinkButton lnkBtnBillingAddress;

        //protected HiddenField hdn_OrderID;

        //protected HiddenField hdn_BillingAddressID;

        //protected HiddenField hdn_ClientID;

        //protected HiddenField hdn_NewBillingAddressID;

        //protected HiddenField hdnservername;

        //protected HiddenField hdnaccountid;

        //protected UpdatePanel updatebillingAddress;

        //protected Label lbl_billingRF;

        //protected HtmlGenericControl div_CartContentArea;

        //protected HiddenField hid_address;

        //protected HiddenField hid_billingaddress;

        //protected HiddenField hid_Shippingaddress;

        //protected HiddenField hdnCountryID;

        //protected HiddenField hdnBillAdd1;

        //protected HiddenField hdnBillAdd2;

        //protected HiddenField hdnBillAdd3;

        //protected HiddenField hdnBillAdd4;

        //protected HiddenField hdnBillAdd5;

        //protected HiddenField hdnBilltelephone;

        //protected HiddenField hdnOldAdd1;

        //protected HiddenField hdnOldAdd2;

        //protected HiddenField hdnOldAdd3;

        //protected HiddenField hdnOldAdd4;

        //protected HiddenField hdnOldAdd5;

        //protected HiddenField hdnOldCountryID;

        //protected HiddenField hdnOldTel;

        //protected HiddenField hdnOldPhone;

        public string strImagepath = BaseClass.imagePath();

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass Objemail = new EmailClass();

        private BaseClass objBc = new BaseClass();

        private OrderBasePage objOrder = new OrderBasePage();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private DateTime OrderDate;

        private DateTime CreatedDate;

        public int IsEnable;

        public int CompanyID;

        public int UserID;

        public long StoreUserID;

        public long BillingAddressID;

        public long ShippingAddressID;

        public long AccountID;

        public long OrderID;

        public long ClientID;

        public long defaultClientID;

        public string IsOrdered = "no";

        public decimal TotalPrice;

        public decimal Tax;

        public decimal OrderShipping;

        public int cartCount;

        public int IsDefaultShipping;

        public int IsDefaultBilling;

        public int ModeOfPayments;

        public bool paymentFlag;

        public bool IsSessionCheckOut;

        public long CampManageID;

        private long DefaultBillingAddressID;

        private long DefaultShippingAddressID;

        private string[] paymentMode;

        private string[] CardTypes;

        public string PaymentType = string.Empty;

        public string CardType = string.Empty;

        public string AccountType = "P";

        public string SesseionKey = string.Empty;

        public string strSitepath = string.Empty;

        public string emailFrom = string.Empty;

        public string emailTo = string.Empty;

        public string emailBCC = string.Empty;

        public string emailCC = string.Empty;

        public string emailSubject = string.Empty;

        public string emailBody = string.Empty;

        public string emailAttachment = string.Empty;

        public string email_return_body = string.Empty;

        public string DateFormat = string.Empty;

        public string newdate = string.Empty;

        public string PostCode = string.Empty;

        public string OrderKey = string.Empty;

        public string Rewritemodule = string.Empty;

        public string SystemName = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string defaultpaymentMode = string.Empty;

        public string FromOrdrConfrm = string.Empty;

        public string NewSessionID = string.Empty;

        public string isLoginInfo = "1";

        public string isOrderInfo = "1";

        public string isInvoiceInfo = "1";

        public string isDeliveryInfo = "1";

        public string isPaymentInfo = "1";

        public string isGuest = "0";

        public string isCheckDeliveryRequiredBy = "1";

        public string PaymentStep = string.Empty;

        public string IsCampaignEnabled = string.Empty;

        private string cartitemids = string.Empty;

        private string orderbehalftype = string.Empty;

        public long OriginalStoreUserID;

        private long DeptID;

        public string isCheckDeliveryInfo = string.Empty;

        public string isCheckInvoiceInfo = string.Empty;

        public string is_DeliveryAddress_Mandatory = string.Empty;

        public string is_InvoiceAddress_Mandatory = string.Empty;

        public string approverEmailcontains = string.Empty;

        public string ApprovalType = string.Empty;

        public string MainApprover;

        public string DeptApprover;

        public string users_addnew_address_notsaved_mainapp;

        public string users_addnew_address_notsaved_deptapp;

        public string users_addnew_address_notsaved_alluser;

        private TextBox txt_orderTitle = new TextBox();

        private TextBox txt_orderNumber = new TextBox();

        private TextBox txtRequiredBy = new TextBox();

        private DropDownList ddlCostCentre = new DropDownList();

        private TextBox txtComments = new TextBox();

        private Label lblBillingAddress = new Label();

        private Label lblShippingAddress = new Label();

        private DropDownList ddl_country_billing = new DropDownList();

        private Label lblAddressBill1 = new Label();

        private Label lblAddressBill2 = new Label();

        private Label lblAddressBill3 = new Label();

        private Label lblAddressBill4 = new Label();

        private Label lblAddressBill5 = new Label();

        private Label lblBillAdd1_UCReq = new Label();

        private Label lblBillAdd2_UCReq = new Label();

        private Label lblBillAdd3_UCReq = new Label();

        private Label lblBillAdd4_UCReq = new Label();

        private Label lblBillAdd5_UCReq = new Label();

        private Label lblBillPhone_UCReq = new Label();

        private HiddenField hdnshippingaddr = new HiddenField();

        private HiddenField hdnChkInvAddress = new HiddenField();

        private TextBox txtaddressLabelBilling = new TextBox();

        private TextBox txt_address_billing1 = new TextBox();

        private TextBox txt_address_billing2 = new TextBox();

        private TextBox txt_address_billing3 = new TextBox();

        private TextBox txt_address_billing4 = new TextBox();

        private TextBox txt_address_billing5 = new TextBox();

        private TextBox txt_telephone_billing = new TextBox();

        private TextBox txt_fax_billing = new TextBox();

        private TextBox txt_email_billing = new TextBox();

        private CheckBox Chk_copy_to_invaddress = new CheckBox();

        private CheckBox Chk_copy_to_deladdress = new CheckBox();

        private TextBox txtDesigApprover = new TextBox();

        private LinkButton lnkEdit_Bill = new LinkButton();

        private LinkButton lnkEdit_Ship = new LinkButton();

        private RequiredFieldValidator Required_Address1 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address2 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address3 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address4 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address5 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Phone = new RequiredFieldValidator();

        private RadGrid rdgrd_ship = new RadGrid();

        private RadGrid rdgrd_bill = new RadGrid();

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

        public checkout()
        {
        }

        public void ApprovalSystem_OrderingProcess()
        {
            DataSet dataSet = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.MainApprover = "False";
            }
            else
            {
                this.MainApprover = dataSet.Tables[0].Rows[0]["MainApprover"].ToString();
            }
            if (dataSet.Tables[1].Rows.Count <= 0)
            {
                this.DeptApprover = "";
            }
            else
            {
                this.DeptApprover = dataSet.Tables[1].Rows[0]["DeptApprover"].ToString();
            }
            this.users_addnew_address_notsaved_mainapp = this.objBc.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_mainapp");
            this.users_addnew_address_notsaved_deptapp = this.objBc.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_deptapp");
            this.users_addnew_address_notsaved_alluser = this.objBc.Return_ApprovalOrderingProcess_Settings("users_addnew_address_notsaved_alluser");
        }

        public void Checkouts_BillingShippingAddress_New()
        {
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            if (this.hid_billingaddress.Value == "yes")
            {
                this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.OriginalStoreUserID, "", "", this.txt_address_billing1.Text, this.txt_address_billing2.Text, this.txt_address_billing3.Text, this.txt_address_billing4.Text, this.txt_address_billing5.Text, this.txt_telephone_billing.Text, this.txt_email_billing.Text, this.txt_fax_billing.Text, this.ddl_country_billing.SelectedItem.Text, 0, 0, this.txtaddressLabelBilling.Text, this.CreatedDate);
                this.hdn_BillingAddressID.Value = this.BillingAddressID.ToString();
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

        protected void GetAddressDetails(string Type, string Id)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address(Convert.ToInt64(Id));
            if (Type == "bill")
            {
                DataTable dataTable1 = new DataTable();
                if (dataTable.Rows.Count > 0)
                {
                    dataTable1 = dataTable;
                }
                this.lblBillingAddress.Text = "";
                foreach (DataRow row in dataTable1.Rows)
                {
                    if (row["AddressLabel"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["AddressLabel"].ToString());
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                        Label label = this.lblBillingAddress;
                        string text = this.lblBillingAddress.Text;
                        char[] chrArray = new char[] { ',' };
                        label.Text = string.Concat(text.TrimEnd(chrArray), "<br/>");
                    }
                    if (row["AddressLine1"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["AddressLine1"].ToString());
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                        Label label1 = this.lblBillingAddress;
                        string str = this.lblBillingAddress.Text;
                        char[] chrArray1 = new char[] { ',' };
                        label1.Text = string.Concat(str.TrimEnd(chrArray1), "<br/>");
                    }
                    if (row["AddressLine2"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["AddressLine2"].ToString());
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                        Label label2 = this.lblBillingAddress;
                        string text1 = this.lblBillingAddress.Text;
                        char[] chrArray2 = new char[] { ',' };
                        label2.Text = string.Concat(text1.TrimEnd(chrArray2), "<br/>");
                    }
                    if (row["Address2"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["Address2"].ToString());
                        if (row["Address3"].ToString() != "" || row["Address4"].ToString() != "")
                        {
                            this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (row["Address3"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["Address3"].ToString());
                        if (row["Address4"].ToString() != "")
                        {
                            this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (row["Address4"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, row["Address4"].ToString());
                    }
                    if (row["Country"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, "<br/>", row["Country"].ToString());
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                        Label label3 = this.lblBillingAddress;
                        string str1 = this.lblBillingAddress.Text;
                        char[] chrArray3 = new char[] { ',' };
                        label3.Text = string.Concat(str1.TrimEnd(chrArray3), "<br/>");
                    }
                    if (row["Phone"].ToString() != "")
                    {
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, "<br/> T:&nbsp;", row["Phone"].ToString());
                        this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                        Label label4 = this.lblBillingAddress;
                        string text2 = this.lblBillingAddress.Text;
                        char[] chrArray4 = new char[] { ',' };
                        label4.Text = string.Concat(text2.TrimEnd(chrArray4), "<br/>");
                    }
                    if (row["Fax"].ToString() == "")
                    {
                        continue;
                    }
                    this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, "F:&nbsp", row["Fax"].ToString());
                    this.lblBillingAddress.Text = string.Concat(this.lblBillingAddress.Text, ",");
                    Label label5 = this.lblBillingAddress;
                    string str2 = this.lblBillingAddress.Text;
                    char[] chrArray5 = new char[] { ',' };
                    label5.Text = string.Concat(str2.TrimEnd(chrArray5), "<br/>");
                }
                this.lblBillingAddress.Text = base.SpecialDecode(this.lblBillingAddress.Text);
                if (this.lblBillingAddress.Text == "")
                {
                    this.lnkEdit_Bill.Attributes.Add("style", "display:none");
                    return;
                }
            }
            else if (Type == "ship")
            {
                DataTable dataTable2 = new DataTable();
                if (dataTable.Rows.Count > 0)
                {
                    dataTable2 = dataTable;
                }
                this.lblShippingAddress.Text = "";
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    if (dataRow["AddressLabel"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["AddressLabel"].ToString());
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                        Label label6 = this.lblShippingAddress;
                        string text3 = this.lblShippingAddress.Text;
                        char[] chrArray6 = new char[] { ',' };
                        label6.Text = string.Concat(text3.TrimEnd(chrArray6), "<br/>");
                    }
                    if (dataRow["AddressLine1"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["AddressLine1"].ToString());
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                        Label label7 = this.lblShippingAddress;
                        string str3 = this.lblShippingAddress.Text;
                        char[] chrArray7 = new char[] { ',' };
                        label7.Text = string.Concat(str3.TrimEnd(chrArray7), "<br/>");
                    }
                    if (dataRow["AddressLine2"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["AddressLine2"].ToString());
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                        Label label8 = this.lblShippingAddress;
                        string text4 = this.lblShippingAddress.Text;
                        char[] chrArray8 = new char[] { ',' };
                        label8.Text = string.Concat(text4.TrimEnd(chrArray8), "<br/>");
                    }
                    if (dataRow["Address2"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["Address2"].ToString());
                        if (dataRow["Address3"].ToString() != "" || dataRow["Address4"].ToString() != "")
                        {
                            this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (dataRow["Address3"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["Address3"].ToString());
                        if (dataRow["Address4"].ToString() != "")
                        {
                            this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",&nbsp;");
                        }
                    }
                    if (dataRow["Address4"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, dataRow["Address4"].ToString());
                    }
                    if (dataRow["Country"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, "<br/>", dataRow["Country"].ToString());
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                        Label label9 = this.lblShippingAddress;
                        string str4 = this.lblShippingAddress.Text;
                        char[] chrArray9 = new char[] { ',' };
                        label9.Text = string.Concat(str4.TrimEnd(chrArray9), "<br/>");
                    }
                    if (dataRow["Phone"].ToString() != "")
                    {
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, "<br/> T:&nbsp;", dataRow["Phone"].ToString());
                        this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                        Label label10 = this.lblShippingAddress;
                        string text5 = this.lblShippingAddress.Text;
                        char[] chrArray10 = new char[] { ',' };
                        label10.Text = string.Concat(text5.TrimEnd(chrArray10), "<br/>");
                    }
                    if (dataRow["Fax"].ToString() == "")
                    {
                        continue;
                    }
                    this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, "F:&nbsp;", dataRow["Fax"].ToString());
                    this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                    Label label11 = this.lblShippingAddress;
                    string str5 = this.lblShippingAddress.Text;
                    char[] chrArray11 = new char[] { ',' };
                    label11.Text = string.Concat(str5.TrimEnd(chrArray11), "<br/>");
                }
                this.lblShippingAddress.Text = base.SpecialDecode(this.lblShippingAddress.Text);
                this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
                if (this.lblShippingAddress.Text == "")
                {
                    this.lnkEdit_Ship.Attributes.Add("style", "display:none");
                }
            }
        }

        public int GetWeekNumber(string WeekDay)
        {
            int num = 0;
            string lower = WeekDay.Trim().ToLower();
            string str = lower;
            if (lower != null)
            {
                switch (str)
                {
                    case "sunday":
                        {
                            num = 1;
                            break;
                        }
                    case "monday":
                        {
                            num = 2;
                            break;
                        }
                    case "tuesday":
                        {
                            num = 3;
                            break;
                        }
                    case "wednesday":
                        {
                            num = 4;
                            break;
                        }
                    case "thursday":
                        {
                            num = 5;
                            break;
                        }
                    case "friday":
                        {
                            num = 6;
                            break;
                        }
                    case "saturday":
                        {
                            num = 7;
                            break;
                        }
                    default:
                        {
                            num = -1;
                            return num;
                        }
                }
            }
            else
            {
                num = -1;
                return num;
            }
            return num;
        }

        protected void OnClick_btn_BackShop(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "shoppingcart.aspx?ID=0&amp;PID=0"));
        }

        protected void OnClick_lnkBtnBillingAddress(object sender, EventArgs e)
        {
            this.Checkouts_BillingShippingAddress_New();
            this.OrderPayment();
            this.Session["ConfirmBeforeOrdernew"] = "1";
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrder.aspx?OrdKey=", this.OrderKey, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrder", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void OnClick_lnkbtnOrder(object sender, EventArgs e)
        {
            this.Checkouts_BillingShippingAddress_New();
            this.OrderPayment();
            string str = this.GenPassWithCap(12);
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrder.aspx?OrdKey=", str, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrder", ConnectionClass.KeySeparator, str, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void OnClick_lnkBtnShippingAddress(object sender, EventArgs e)
        {
            this.Checkouts_BillingShippingAddress_New();
            this.OrderPayment();
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrder.aspx?OrdKey=", this.OrderKey, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrder", ConnectionClass.KeySeparator, this.OrderKey, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        public void OrderPayment()
        {
            long storeUserID = this.StoreUserID;
            if (this.orderbehalftype.Trim().ToLower() != "u" && this.orderbehalftype.Trim().ToLower() != "d")
            {
                DataTable storeUserContactDetails = OrderBasePage.GetStoreUserContactDetails(Convert.ToInt64(this.Session["StoreUserID"]));
                foreach (DataRow row in storeUserContactDetails.Rows)
                {
                    storeUserID = Convert.ToInt64(row["ContactID"]);
                }
            }
            foreach (DataRow dataRow in LoginBasePage.StoreUser_select_by_Conditions(storeUserID, this.orderbehalftype, this.DeptID).Rows)
            {
                this.ClientID = Convert.ToInt64(dataRow["ClientID"].ToString());
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StoreUserID", typeof(string));
            dataTable.Columns.Add("SessionKey", typeof(string));
            dataTable.Columns.Add("InvoiceAddressID", typeof(string));
            dataTable.Columns.Add("DeliveryAddressID", typeof(string));
            dataTable.Columns.Add("ClientID", typeof(string));
            dataTable.Columns.Add("IsOrdered", typeof(string));
            dataTable.Columns.Add("PaymentType", typeof(string));
            dataTable.Columns.Add("RequiredBy", typeof(string));
            dataTable.Columns.Add("Comments", typeof(string));
            dataTable.Columns.Add("OrderTitle", typeof(string));
            dataTable.Columns.Add("OrderNumber", typeof(string));
            dataTable.Columns.Add("OrderID", typeof(string));
            dataTable.Columns.Add("CostCentreID", typeof(string));
            dataTable.Columns.Add("DesignatedApproverEmail", typeof(string));
            dataTable.Columns.Add("CostCentreName", typeof(string));
            dataTable.Columns.Add("DeptID", typeof(string));
            dataTable.Columns.Add("orderbehalftype", typeof(string));
            dataTable.Columns.Add("OrderForUserID", typeof(string));
            if (this.Session["BillingAddressID"] == null)
            {
                this.Session["BillingAddressID"] = 0;
            }
            if (this.Session["ShippingAddressID"] == null)
            {
                this.Session["ShippingAddressID"] = 0;
            }
            if (this.ddlCostCentre.SelectedItem == null)
            {
                object[] originalStoreUserID = new object[] { this.OriginalStoreUserID, this.SesseionKey, this.Session["BillingAddressID"].ToString(), this.Session["ShippingAddressID"].ToString(), this.ClientID, this.IsOrdered, this.PaymentType, this.txtRequiredBy.Text, this.txtComments.Text, this.txt_orderTitle.Text, this.txt_orderNumber.Text, this.hdn_OrderID.Value, "0", base.SpecialEncode(this.txtDesigApprover.Text.Trim()), "", this.DeptID, this.orderbehalftype, storeUserID };
                dataTable.Rows.Add(originalStoreUserID);
            }
            else
            {
                object[] objArray = new object[] { this.OriginalStoreUserID, this.SesseionKey, this.Session["BillingAddressID"].ToString(), this.Session["ShippingAddressID"].ToString(), this.ClientID, this.IsOrdered, this.PaymentType, this.txtRequiredBy.Text, base.SpecialEncode(this.txtComments.Text), base.SpecialEncode(this.txt_orderTitle.Text), base.SpecialEncode(this.txt_orderNumber.Text), this.hdn_OrderID.Value, this.ddlCostCentre.SelectedItem.Value, base.SpecialEncode(this.txtDesigApprover.Text.Trim()), base.SpecialEncode(this.ddlCostCentre.SelectedItem.Text), this.DeptID, this.orderbehalftype, storeUserID };
                dataTable.Rows.Add(objArray);
            }
            this.Session["InsertOrder"] = dataTable;
            this.StoreOldDatas();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)base.Master.FindControl("lblPathLink")).Text = string.Concat("<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "checkout.aspx'></a> ", this.objLanguage.GetLanguageConversion("Checkout"));
            Label label = (Label)base.Master.FindControl("lblPathLink");
            this.txt_orderTitle = (TextBox)this.ucOrderInfo.FindControl("txt_orderTitle");
            this.txt_orderNumber = (TextBox)this.ucOrderInfo.FindControl("txt_orderNumber");
            this.txtRequiredBy = (TextBox)this.ucOrderInfo.FindControl("txtRequiredBy");
            this.ddlCostCentre = (DropDownList)this.ucOrderInfo.FindControl("ddlCostCenter");
            this.txtComments = (TextBox)this.ucOrderInfo.FindControl("txtComments");
            this.txtDesigApprover = (TextBox)this.ucOrderInfo.FindControl("txtDesigApprover");
            this.lblBillingAddress = (Label)this.ucAddressInfo.FindControl("lblBillingAddress");
            this.lblShippingAddress = (Label)this.ucAddressInfo.FindControl("lblShippingAddress");
            this.hdnshippingaddr = (HiddenField)this.ucAddressInfo.FindControl("hdnshippingaddr");
            this.ddl_country_billing = (DropDownList)this.ucAddressInfo.FindControl("ddlCountry");
            this.lblAddressBill1 = (Label)this.ucAddressInfo.FindControl("lblAddressBill1");
            this.lblAddressBill2 = (Label)this.ucAddressInfo.FindControl("lblAddressBill2");
            this.lblAddressBill3 = (Label)this.ucAddressInfo.FindControl("lblAddressBill3");
            this.lblAddressBill4 = (Label)this.ucAddressInfo.FindControl("lblAddressBill4");
            this.lblAddressBill5 = (Label)this.ucAddressInfo.FindControl("lblAddressBill5");
            this.lblBillPhone_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillPhone_UC");
            this.lblBillAdd1_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillAdd1_UC");
            this.lblBillAdd2_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillAdd2_UC");
            this.lblBillAdd3_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillAdd3_UC");
            this.lblBillAdd4_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillAdd4_UC");
            this.lblBillAdd5_UCReq = (Label)this.ucAddressInfo.FindControl("lblBillAdd5_UC");
            this.Required_Address1 = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Address1");
            this.Required_Address2 = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Address2");
            this.Required_Address3 = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Address3");
            this.Required_Address4 = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Address4");
            this.Required_Address5 = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Address5");
            this.Required_Phone = (RequiredFieldValidator)this.ucAddressInfo.FindControl("Required_Phone");
            this.txtaddressLabelBilling = (TextBox)this.ucAddressInfo.FindControl("txtaddressLabelBilling");
            this.txt_address_billing1 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing1");
            this.txt_address_billing2 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing2");
            this.txt_address_billing3 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing3");
            this.txt_address_billing4 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing4");
            this.txt_address_billing5 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing5");
            this.txt_telephone_billing = (TextBox)this.ucAddressInfo.FindControl("txt_telephone_billing");
            this.txt_fax_billing = (TextBox)this.ucAddressInfo.FindControl("txt_fax_billing");
            this.txt_email_billing = (TextBox)this.ucAddressInfo.FindControl("txt_email_billing");
            this.Chk_copy_to_invaddress = (CheckBox)this.ucAddressInfo.FindControl("Chk_copy_to_invaddress");
            this.Chk_copy_to_deladdress = (CheckBox)this.ucAddressInfo.FindControl("Chk_copy_to_deladdress");
            this.rdgrd_ship = (RadGrid)this.ucAddressInfo.FindControl("rdgrd_ship_choose");
            this.rdgrd_bill = (RadGrid)this.ucAddressInfo.FindControl("rdgrd_bill_choose");
            Button button = (Button)this.ucOrderInfo.FindControl("btn_orderInfo");
            button.Attributes.Add("OnClick", "javascript:return OrderValidate();");
            this.ucAddressInfo.ButtonClick_Ship += new EventHandler(this.ucAddressInfo_ButtonClick_Ship);
            this.ucAddressInfo.ButtonClick_Bill += new EventHandler(this.ucAddressInfo_ButtonClick_Bill);
            this.ucAddressInfo.ButtonSaveClick_Bill += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Bill);
            this.ucAddressInfo.ButtonSaveClick_Ship += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Ship);
            this.ucAddressInfo.ButtonUpdateClick_Bill += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Bill);
            this.ucAddressInfo.ButtonUpdateClick_Ship += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Ship);
            this.lnkEdit_Bill = (LinkButton)this.ucAddressInfo.FindControl("lnkEdit_Bill");
            this.lnkEdit_Ship = (LinkButton)this.ucAddressInfo.FindControl("lnkEdit_Ship");
            this.hdnChkInvAddress = (HiddenField)this.ucAddressInfo.FindControl("hdnChkInvAddress");
            this.defaultClientID = Convert.ToInt64(EprintConfigurationManager.AppSettings["DefaultClientID"].ToString());
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (this.Session["PaymentStep"] != null && (this.Session["PaymentStep"].ToString() != null || this.Session["PaymentStep"].ToString() != ""))
            {
                this.PaymentStep = this.Session["PaymentStep"].ToString();
            }
            this.hdnservername.Value = ConnectionClass.ServerName.ToLower();
            this.hdnaccountid.Value = this.AccountID.ToString();
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, this.AccountID).Rows)
            {
                this.AccountType = row["accountType"].ToString();
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
            }
            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", this.AccountID) == "false")
            {
                this.isCheckDeliveryRequiredBy = "0";
            }
            if (this.Session["StoreUserID"] == null)
            {
                this.isInvoiceInfo = "1";
                if (this.comm.GetDisplayValue("isCheckOrderInfo", this.AccountID) == "false")
                {
                    this.isOrderInfo = "0";
                }
                if (this.comm.GetDisplayValue("isCheckPaymentInfo", this.AccountID) != "false")
                {
                    this.li_payment.Style.Add("display", "block");
                }
                else
                {
                    this.isPaymentInfo = "0";
                    this.li_payment.Style.Add("display", "none");
                }
                if (this.comm.GetDisplayValue("isCheckLoginRegister", this.AccountID) == "false")
                {
                    this.isLoginInfo = "0";
                    this.isDeliveryInfo = "0";
                }
                else if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false")
                {
                    this.isDeliveryInfo = "0";
                }
            }
            else
            {
                if (this.Session["MultipleCartID"] != null)
                {
                    this.cartitemids = this.Session["MultipleCartID"].ToString();
                }
                if (this.Session["OrderBehalfType"] != null)
                {
                    this.orderbehalftype = this.Session["OrderBehalfType"].ToString();
                }
                if (this.orderbehalftype.ToLower() == "d" || this.orderbehalftype.ToLower() == "u")
                {
                    DataTable dataTable = OrderBasePage.Select_StoreUserID_UserDept_Behalf(this.cartitemids, this.orderbehalftype);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.StoreUserID = Convert.ToInt64(dataTable.Rows[0]["Order_Behalf_UserID"]);
                        this.DeptID = Convert.ToInt64(dataTable.Rows[0]["Order_Behalf_DeptID"]);
                    }
                    this.OriginalStoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                }
                else if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                    this.OriginalStoreUserID = Convert.ToInt64(this.Session["StoreUserID"]);
                }
                this.isLoginInfo = "0";
                this.isInvoiceInfo = "1";
                if (this.comm.GetDisplayValue("isCheckOrderInfo", this.AccountID) == "false")
                {
                    this.isOrderInfo = "0";
                }
                if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "false")
                {
                    this.isDeliveryInfo = "0";
                }
                if (this.comm.GetDisplayValue("isCheckPaymentInfo", this.AccountID) != "false")
                {
                    this.li_payment.Style.Add("display", "block");
                }
                else
                {
                    this.isPaymentInfo = "0";
                    this.li_payment.Style.Add("display", "none");
                }
            }
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddl_country_billing);
                foreach (DataRow dataRow in OrderBasePage.settings_companyprofile_select(this.CompanyID).Rows)
                {
                    this.hdnCountryID.Value = dataRow["CountryID"].ToString();
                }
            }
            this.lblAddressBill1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lblAddressBill2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lblAddressBill3.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lblAddressBill4.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblAddressBill5.Text = this.comm.GetAddressLabelByKey("Address5");
            if (this.comm.GetMandatoryByKey("address1").ToLower() != "true")
            {
                this.hdnBillAdd1.Value = "0";
                this.lblBillAdd1_UCReq.Visible = false;
                this.Required_Address1.Display = ValidatorDisplay.None;
                this.Required_Address1.Enabled = false;
            }
            else
            {
                this.hdnBillAdd1.Value = "1";
                this.lblBillAdd1_UCReq.Visible = true;
                this.Required_Address1.Display = ValidatorDisplay.Dynamic;
                this.Required_Address1.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("address2").ToLower() != "true")
            {
                this.hdnBillAdd2.Value = "0";
                this.lblBillAdd2_UCReq.Visible = false;
                this.Required_Address2.Display = ValidatorDisplay.None;
                this.Required_Address2.Enabled = false;
            }
            else
            {
                this.hdnBillAdd2.Value = "1";
                this.lblBillAdd2_UCReq.Visible = true;
                this.Required_Address2.Display = ValidatorDisplay.Dynamic;
                this.Required_Address2.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("address3").ToLower() != "true")
            {
                this.hdnBillAdd3.Value = "0";
                this.lblBillAdd3_UCReq.Visible = false;
                this.Required_Address3.Display = ValidatorDisplay.None;
                this.Required_Address3.Enabled = false;
            }
            else
            {
                this.hdnBillAdd3.Value = "1";
                this.lblBillAdd3_UCReq.Visible = true;
                this.Required_Address3.Display = ValidatorDisplay.Dynamic;
                this.Required_Address3.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("address4").ToLower() != "true")
            {
                this.hdnBillAdd4.Value = "0";
                this.lblBillAdd4_UCReq.Visible = false;
                this.Required_Address4.Display = ValidatorDisplay.None;
                this.Required_Address4.Enabled = false;
            }
            else
            {
                this.hdnBillAdd4.Value = "1";
                this.lblBillAdd4_UCReq.Visible = true;
                this.Required_Address4.Display = ValidatorDisplay.Dynamic;
                this.Required_Address4.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("address5").ToLower() != "true")
            {
                this.hdnBillAdd5.Value = "0";
                this.lblBillAdd5_UCReq.Visible = false;
                this.Required_Address5.Display = ValidatorDisplay.None;
                this.Required_Address5.Enabled = false;
            }
            else
            {
                this.hdnBillAdd5.Value = "1";
                this.lblBillAdd5_UCReq.Visible = true;
                this.Required_Address5.Display = ValidatorDisplay.Dynamic;
                this.Required_Address5.Enabled = true;
            }
            if (ConnectionClass.ServerName == null || !(ConnectionClass.ServerName.ToLower() == "smp") || this.AccountID != (long)276)
            {
                this.hdnBilltelephone.Value = "0";
                this.lblBillPhone_UCReq.Visible = false;
                this.Required_Phone.Display = ValidatorDisplay.None;
                this.Required_Phone.Enabled = false;
            }
            else
            {
                this.hdnBilltelephone.Value = "1";
                this.lblBillPhone_UCReq.Visible = true;
                this.Required_Phone.Display = ValidatorDisplay.Dynamic;
                this.Required_Phone.Enabled = true;
            }
            if (this.Session["StoreUserID"] == null && this.AccountType == "p" || this.AccountID == (long)0 && this.CompanyID == 0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            base.Title = commonclass.pageTitle("Checkout", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            this.SesseionKey = this.comm.UniqueID;
            DataTable dataTable1 = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
            foreach (DataRow row1 in dataTable1.Rows)
            {
                this.IsEnable = Convert.ToInt32(row1["IsEnable"]);
                if (this.isPaymentInfo != "1")
                {
                    continue;
                }
                this.ModeOfPayments = 1;
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable2 = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
                foreach (DataRow dataRow1 in dataTable2.Rows)
                {
                    string str = dataRow1["paymentMode"].ToString().Trim();
                    char[] chrArray = new char[] { ',' };
                    this.paymentMode = str.Split(chrArray);
                    this.defaultpaymentMode = dataRow1["defaultpaymentMode"].ToString();
                    string str1 = dataRow1["creaditCardTypes"].ToString().Trim();
                    char[] chrArray1 = new char[] { ',' };
                    this.CardTypes = str1.Split(chrArray1);
                    if (this.isPaymentInfo != "0")
                    {
                        if (this.isPaymentInfo != "1")
                        {
                            continue;
                        }
                        this.ModeOfPayments = 1;
                        for (int i = 0; i < (int)this.CardTypes.Length; i++)
                        {
                        }
                        for (int j = 0; j < (int)this.paymentMode.Length; j++)
                        {
                            if (!(this.paymentMode[j].ToString() == "CD") && !(this.paymentMode[j].ToString() == "CH") && !(this.paymentMode[j].ToString() == "CC") && !(this.paymentMode[j].ToString() == "PP"))
                            {
                            }
                        }
                    }
                    else
                    {
                        this.ModeOfPayments = 0;
                    }
                }
                this.cartCount = 0;
                DataTable cartItemCount = CartBasePage.Get_CartItemCount(this.OriginalStoreUserID);
                if (cartItemCount.Rows.Count > 0 && cartItemCount.Rows[0]["Count"].ToString() != "0")
                {
                    this.cartCount = Convert.ToInt32(cartItemCount.Rows[0]["Count"]);
                }
                if (this.cartCount != 0)
                {
                    this.div_EmptyCart.Style.Add("display", "none");
                    this.div_CartContentArea.Style.Add("display", "block");
                }
                else
                {
                    this.div_EmptyCart.Style.Add("display", "block");
                    this.div_CartContentArea.Style.Add("display", "none");
                }
                DataSet dataSet = OrderBasePage.SelectDeptandCostCentre(this.StoreUserID, this.orderbehalftype, this.DeptID);
                if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
                {
                    this.DefaultBillingAddressID = Convert.ToInt64(dataSet.Tables[1].Rows[0]["DefaultBillingID"].ToString());
                    this.DefaultShippingAddressID = Convert.ToInt64(dataSet.Tables[1].Rows[0]["DefaultShippingID"].ToString());
                }
                if (this.Session["InsertOrder"] != null)
                {
                    DataTable item = (DataTable)this.Session["InsertOrder"];
                    if (item != null)
                    {
                        foreach (DataRow row2 in item.Rows)
                        {
                            this.DefaultBillingAddressID = Convert.ToInt64(row2["InvoiceAddressID"]);
                            this.DefaultShippingAddressID = Convert.ToInt64(row2["DeliveryAddressID"]);
                        }
                    }
                }
                this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(this.AccountID);
                if (this.IsCampaignEnabled.ToLower() == "true")
                {
                    if (base.Request.Params["CampID"] != null)
                    {
                        this.CampManageID = Convert.ToInt64(base.Request.Params["CampID"].ToString());
                    }
                    DataTable dataTable3 = OrderBasePage.PreFill_OrderInfo(this.CampManageID);
                    if (dataTable3.Rows.Count > 0 && Convert.ToInt64(dataTable3.Rows[0]["DeliveryAddressID"]) != (long)0)
                    {
                        this.DefaultShippingAddressID = Convert.ToInt64(dataTable3.Rows[0]["DeliveryAddressID"]);
                    }
                }
                this.Session["BillingAddressID"] = this.DefaultBillingAddressID.ToString();
                this.Session["ShippingAddressID"] = this.DefaultShippingAddressID.ToString();
                this.GetAddressDetails("bill", this.DefaultBillingAddressID.ToString());
                this.GetAddressDetails("ship", this.DefaultShippingAddressID.ToString());
                if (this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) == "true")
                {
                    this.GetAddressDetails("bill", this.DefaultBillingAddressID.ToString());
                }
                if (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) == "true")
                {
                    this.GetAddressDetails("ship", this.DefaultShippingAddressID.ToString());
                }
                this.lbl_billingRF.Style.Add("display", "none");
                if (this.DefaultBillingAddressID <= (long)0 && this.DefaultShippingAddressID <= (long)0)
                {
                    this.hid_address.Value = "no";
                    this.lbl_billingRF.Style.Add("display", "block");
                }
                if (this.Session["CheckOut"] == null)
                {
                    if (this.txtRequiredBy.Text.Trim().Length == 0)
                    {
                        if (ConnectionClass.SystemName.ToLower() != "aviva")
                        {
                            int num = 0;
                            int num1 = 0;
                            int num2 = 0;
                            num = Convert.ToInt32(this.comm.GetDisplayValue("WorkingDaysFrom", this.AccountID));
                            num1 = Convert.ToInt32(this.comm.GetDisplayValue("WorkingDaysTo", this.AccountID));
                            num2 = Convert.ToInt32(this.comm.GetDisplayValue("DefaultEstimatedDelivery", this.AccountID));
                            if (Convert.ToInt32(this.comm.GetDisplayValue("DeliveryRequiredByValue", this.AccountID)) != -1)
                            {
                                TextBox textBox = this.txtRequiredBy;
                                commonclass _commonclass = this.comm;
                                DateTime dateTime = this.ReturnWeekDate(DateTime.Now, num, num1, num2);
                                textBox.Text = _commonclass.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                            }
                            else
                            {
                                this.txtRequiredBy.Text = "";
                            }
                        }
                        else
                        {
                            TextBox textBox1 = this.txtRequiredBy;
                            commonclass _commonclass1 = this.comm;
                            DateTime dateTime1 = DateTime.Now.AddDays(5);
                            textBox1.Text = _commonclass1.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                        }
                    }
                    if (this.txtComments.Text.Trim().Length == 0)
                    {
                        string displayValue = this.comm.GetDisplayValue("CommentsDefaultValue", this.AccountID);
                        this.txtComments.Text = displayValue;
                    }
                    if (this.txt_orderTitle.Text.Trim().Length == 0)
                    {
                        string displayValue1 = this.comm.GetDisplayValue("OrderTitleValue", this.AccountID);
                        this.txt_orderTitle.Text = displayValue1;
                    }
                    if (this.txt_orderNumber.Text.Trim().Length == 0)
                    {
                        string displayValue2 = this.comm.GetDisplayValue("OrderNumberValue", this.AccountID);
                        this.txt_orderNumber.Text = displayValue2;
                    }
                }
                else
                {
                    DataTable item1 = (DataTable)this.Session["CheckOut"];
                    if (item1 != null)
                    {
                        foreach (DataRow dataRow2 in item1.Rows)
                        {
                            string empty = string.Empty;
                            string empty1 = string.Empty;
                            this.IsSessionCheckOut = true;
                            this.hdn_ClientID.Value = dataRow2["ClientID"].ToString();
                            this.txt_orderTitle.Text = dataRow2["OrderTitle"].ToString();
                            this.txt_orderNumber.Text = dataRow2["OrderNo"].ToString();
                            this.txtRequiredBy.Text = dataRow2["ReferedBy"].ToString();
                            this.txtComments.Text = dataRow2["Comments"].ToString();
                            this.txtDesigApprover.Text = base.SpecialDecode(dataRow2["DesignatedApproverEmail"].ToString());
                        }
                    }
                }
                commonclass _commonclass2 = this.comm;
                DateTime now = DateTime.Now;
                DateTime dateTime2 = Convert.ToDateTime(_commonclass2.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
                this.newdate = dateTime2.ToShortDateString();
                this.txtRequiredBy.Attributes.Add("onclick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (base.Request.Params["frm"] != null)
                {
                    this.FromOrdrConfrm = base.Request.Params["frm"].ToString();
                }
            }
            if (this.Session["ShippingAddressID"] != null)
            {
                this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
            }
            if (this.Session["BillingAddressID"] != null)
            {
                this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
            }
            this.NewSessionID = this.comm.UniqueID;
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on")
            {
                this.ApprovalType = base.Return_ApprovalSystem_Settings("approvaltype").ToLower();
                if (this.ApprovalType == "u")
                {
                    this.approverEmailcontains = this.objBc.Return_ApprovalSystem_Settings("approveremail");
                }
            }
            this.isCheckDeliveryInfo = this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID).ToLower().Trim();
            this.isCheckInvoiceInfo = this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID).ToLower().Trim();
            this.is_DeliveryAddress_Mandatory = this.comm.GetDisplayValue("is_DeliveryAddress_Mandatory", this.AccountID).ToLower().Trim();
            this.is_InvoiceAddress_Mandatory = this.comm.GetDisplayValue("is_InvoiceAddress_Mandatory", this.AccountID).ToLower().Trim();

            this.hdn_isOrderInformationAccessible.Value = "1";
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
                this.hdn_isOrderInformationAccessible.Value = "0";
                this.li3.Attributes.Add("style", "display:none");
                this.lblStep4.InnerText = "1";
                this.lblStep5.InnerText = "2";
                this.lblStep6.InnerText = "3";
            }
        }

        public DateTime ReturnWeekDate(DateTime TodaysDate, int WorkingDaysFrom, int WorkingDaysTo, int AddDays)
        {
            DateTime todaysDate;
            if (AddDays == 0)
            {
                return TodaysDate;
            }
            this.GetWeekNumber(TodaysDate.DayOfWeek.ToString());
            DateTime dateTime = TodaysDate;
            int num = 1;
        Label1:
            while (num <= AddDays)
            {
                try
                {
                    dateTime = dateTime.AddDays(1);
                    int weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
                    if (WorkingDaysFrom <= WorkingDaysTo)
                    {
                        while (weekNumber < WorkingDaysFrom || weekNumber > WorkingDaysTo)
                        {
                            dateTime = dateTime.AddDays(1);
                            weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
                        }
                    }
                    else
                    {
                        while (weekNumber < WorkingDaysFrom)
                        {
                            if (weekNumber > WorkingDaysTo)
                            {
                                dateTime = dateTime.AddDays(1);
                                weekNumber = this.GetWeekNumber(dateTime.DayOfWeek.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    goto Label0;
                }
                catch
                {
                    todaysDate = TodaysDate;
                }
                return todaysDate;
            }
            return dateTime;
        Label0:
            num++;
            goto Label1;
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        public void StoreOldDatas()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ClientID", typeof(string));
            dataTable.Columns.Add("OrderTitle", typeof(string));
            dataTable.Columns.Add("OrderNo", typeof(string));
            dataTable.Columns.Add("ReferedBy", typeof(string));
            dataTable.Columns.Add("Comments", typeof(string));
            dataTable.Columns.Add("InvoiceAddressID", typeof(string));
            dataTable.Columns.Add("DeliveryddressID", typeof(string));
            dataTable.Columns.Add("PaymentOption", typeof(string));
            dataTable.Columns.Add("CardHolderName", typeof(string));
            dataTable.Columns.Add("CardType", typeof(string));
            dataTable.Columns.Add("CardNo", typeof(string));
            dataTable.Columns.Add("ExpMonth", typeof(string));
            dataTable.Columns.Add("ExpYear", typeof(string));
            dataTable.Columns.Add("VerificationNo", typeof(string));
            dataTable.Columns.Add("DesignatedApproverEmail", typeof(string));
            object[] value = new object[] { this.hdn_ClientID.Value, this.txt_orderTitle.Text, this.txt_orderNumber.Text, this.txtRequiredBy.Text, this.txtComments.Text, this.Session["BillingAddressID"].ToString(), this.Session["ShippingAddressID"].ToString(), "", "", "", "", "0", "0", "", base.SpecialEncode(this.txtDesigApprover.Text.Trim()) };
            dataTable.Rows.Add(value);
            this.Session["CheckOut"] = dataTable;
        }

        protected void ucAddressInfo_ButtonClick_Bill(object sender, EventArgs e)
        {
            string str = ((LinkButton)sender).CommandArgument.ToString();
            this.Session["BillingAddressID"] = str;
            if (this.Session["BillingAddressID"] != null)
            {
                this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
            }
            this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog3();", true);
            this.rdgrd_bill.Rebind();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonClick_Ship(object sender, EventArgs e)
        {
            string str = ((LinkButton)sender).CommandArgument.ToString();
            this.Session["ShippingAddressID"] = str;
            if (this.Session["ShippingAddressID"] != null)
            {
                this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
            }
            this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog4();", true);
            this.rdgrd_ship.Rebind();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonSaveClick_Bill(object sender, EventArgs e)
        {
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.OriginalStoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), this.txt_email_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), 0, 0, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            this.Session["BillingAddressID"] = this.BillingAddressID.ToString();
            if (!this.Chk_copy_to_deladdress.Checked)
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            else
            {
                this.Session["ShippingAddressID"] = this.BillingAddressID.ToString();
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog();", true);
            this.ApprovalSystem_OrderingProcess();
            if (this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y")
            {
                this.Session["TempSaveAddress_Bill"] = this.BillingAddressID;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonSaveClick_Ship(object sender, EventArgs e)
        {
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true));
            this.ShippingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.OriginalStoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), this.txt_email_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), 0, 0, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            this.Session["ShippingAddressID"] = this.ShippingAddressID.ToString();
            if (!this.Chk_copy_to_invaddress.Checked)
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            else
            {
                this.Session["BillingAddressID"] = this.ShippingAddressID;
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            this.hdnshippingaddr.Value = this.Session["ShippingAddressID"].ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:HideDialog();", true);
            this.ApprovalSystem_OrderingProcess();
            if (this.users_addnew_address_notsaved_mainapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_deptapp.ToLower().Trim() == "y" || this.users_addnew_address_notsaved_alluser.ToLower().Trim() == "y")
            {
                this.Session["TempSaveAddress_Ship"] = this.ShippingAddressID;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "Script", string.Concat("showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Bill(object sender, EventArgs e)
        {
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["BillingAddressID"]), "", "", base.SpecialEncode(this.txt_address_billing1.Text.Trim()), base.SpecialEncode(this.txt_address_billing2.Text.Trim()), base.SpecialEncode(this.txt_address_billing3.Text.Trim()), base.SpecialEncode(this.txt_address_billing4.Text.Trim()), base.SpecialEncode(this.txt_telephone_billing.Text.Trim()), this.txt_email_billing.Text.Trim(), base.SpecialEncode(this.txt_fax_billing.Text.Trim()), base.SpecialEncode(this.ddl_country_billing.SelectedItem.Text.Trim()), base.SpecialEncode(this.txtaddressLabelBilling.Text.Trim()), base.SpecialEncode(this.txt_address_billing5.Text.Trim()));
            if (!this.Chk_copy_to_deladdress.Checked)
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            else
            {
                this.Session["ShippingAddressID"] = Convert.ToInt64(this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:HideDialog();showEdit(", this.lnkEdit_Bill.ClientID, ");"), true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Ship(object sender, EventArgs e)
        {
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["ShippingAddressID"]), "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_telephone_billing.Text.Trim(), this.txt_email_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), this.txtaddressLabelBilling.Text.Trim(), this.txt_address_billing5.Text.Trim());
            if (!this.Chk_copy_to_invaddress.Checked)
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            else
            {
                this.Session["BillingAddressID"] = Convert.ToInt64(this.Session["ShippingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", string.Concat("javascript:HideDialog();showEdit(", this.lnkEdit_Ship.ClientID, ");"), true);
        }
    }
}
