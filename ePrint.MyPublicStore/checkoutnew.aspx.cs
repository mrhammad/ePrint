using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
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
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.MyPublicStore
{
    public partial class checkoutnew : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_Checkout;

        //protected HtmlGenericControl div_NavigationID;

        //protected HtmlGenericControl div_EmptyCart;

        //protected HtmlGenericControl li_Order;

        //protected HtmlGenericControl li_Address;

        //protected HtmlGenericControl li_Confirmation;

        //protected HtmlGenericControl li_payment;

        //protected HtmlGenericControl li1;

        //protected usercontrol_orderinformation_ascx ucOrderInfo;

        //protected usercontrol_invoice_del_info_ascx ucAddressInfo;

        //protected Button btn_billingAddress;

        //protected Button btn_BackShop;

        //protected Image Image1;

        //protected LinkButton lnkBtnBillingAddress;

        //protected HiddenField hdn_OrderID;

        //protected HiddenField hdn_BillingAddressID;

        //protected HiddenField hdn_ClientID;

        //protected HiddenField hdn_NewBillingAddressID;

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

        //protected HiddenField hdnOldAdd1;

        //protected HiddenField hdnOldAdd2;

        //protected HiddenField hdnOldAdd3;

        //protected HiddenField hdnOldAdd4;

        //protected HiddenField hdnOldAdd5;

        //protected HiddenField hdnOldCountryID;

        //protected HiddenField hdnOldTel;

        //protected HiddenField hdnOldPhone;

        //protected Panel pnl_checkout;

        //protected Panel pnl_BillingAddress;

        //protected Panel pnl_ShippingAddress;

        public string strImagepath = BaseClass.imagePath();

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass Objemail = new EmailClass();

        private BaseClass objBc = new BaseClass();

        private OrderBasePage objOrder = new OrderBasePage();

        public languageClass objLanguage = new languageClass();

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        private long DefaultBillingAddressID;

        private long DefaultShippingAddressID;

        public long ContactID;

        private string[] paymentMode;

        private string[] CardTypes;

        public string PaymentType = string.Empty;

        public string CardType = string.Empty;

        public string AccountType = string.Empty;

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

        public string FileExtension = string.Empty;

        public string KeySeparator = string.Empty;

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

        public string isCheckOrderInfoPublic = string.Empty;

        public string isCheckAddressInfo = string.Empty;

        public string isCheckDeliveryInfo = string.Empty;

        public string isCheckInvoiceInfo = string.Empty;

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

        private Label lblLine = new Label();

        private Label lblDeliveryLine = new Label();

        private TextBox txtaddressLabelBilling = new TextBox();

        private TextBox txt_address_billing1 = new TextBox();

        private TextBox txt_address_billing2 = new TextBox();

        private TextBox txt_address_billing3 = new TextBox();

        private TextBox txt_address_billing4 = new TextBox();

        private TextBox txt_address_billing5 = new TextBox();

        private TextBox txt_telephone_billing = new TextBox();

        private TextBox txt_fax_billing = new TextBox();

        private CheckBox chkCopytoInvoice = new CheckBox();

        private CheckBox ChkcopytoDel = new CheckBox();

        private CheckBox Chk_makedefaultAddres_Invoice = new CheckBox();

        private CheckBox Chk_makedefaultAddres_Delivery = new CheckBox();

        private RequiredFieldValidator Required_Address1 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address2 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address3 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address4 = new RequiredFieldValidator();

        private RequiredFieldValidator Required_Address5 = new RequiredFieldValidator();

        private RadGrid rdgrd_ship = new RadGrid();

        private RadGrid rdgrd_bill = new RadGrid();

        private LinkButton lnkEdit_Bill = new LinkButton();

        private LinkButton lnkEdit_Ship = new LinkButton();

        private HiddenField hdnChkInvAddress = new HiddenField();

        private HiddenField hdnChkDelAddress = new HiddenField();

        private HiddenField hdnTotalAddressCount = new HiddenField();

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

        public checkoutnew()
        {
        }

        public void bindAddress_Grid(long StoreUserID, string Type, long StoreContactID)
        {
            DataTable dataTable = OrderBasePage.Select_BillingShipping_Address(StoreUserID, Type, StoreContactID);
            List<string> strs = new List<string>();
            List<string> strs1 = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string str = string.Concat(row["AddressLabel"].ToString(), ", ", row["Address"].ToString());
                string empty = string.Empty;
                string[] strArrays = str.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].Trim() != "")
                    {
                        empty = string.Concat(empty, strArrays[i]);
                        empty = string.Concat(empty, ",");
                    }
                }
                empty = empty.TrimEnd(new char[] { ',' });
                strs.Add(this.objBc.SpecialDecode(empty));
                strs1.Add(row["Addressid"].ToString());
            }
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("AddressID", typeof(string));
            dataTable1.Columns.Add("Address", typeof(string));
            for (int j = 0; j < strs.Count; j++)
            {
                object[] item = new object[] { strs1[j], strs[j] };
                dataTable1.Rows.Add(item);
            }
            this.rdgrd_ship.DataSource = dataTable1;
            this.rdgrd_bill.DataSource = dataTable1;
            this.rdgrd_ship.DataBind();
            this.rdgrd_bill.DataBind();
            this.Session["AddressGrid"] = dataTable1;
            this.hdnTotalAddressCount.Value = dataTable1.Rows.Count.ToString();
        }

        public void Checkouts_BillingShippingAddress_New()
        {
            this.CreatedDate = DateTime.Now;
            if (this.hid_billingaddress.Value == "yes")
            {
                if (this.Session["isGuest"] == null || !(this.Session["isGuest"].ToString().ToLower() == "yes"))
                {
                    this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, "", "", this.txt_address_billing1.Text, this.txt_address_billing2.Text, this.txt_address_billing3.Text, this.txt_address_billing4.Text, this.txt_address_billing5.Text, this.txt_telephone_billing.Text, this.txt_fax_billing.Text, this.ddl_country_billing.SelectedItem.Text, 0, 0, this.txtaddressLabelBilling.Text, this.CreatedDate);
                    this.hdn_BillingAddressID.Value = this.BillingAddressID.ToString();
                }
                else
                {
                    if (this.hdnOldAdd1.Value != this.txt_address_billing1.Text || this.hdnOldAdd2.Value != this.txt_address_billing2.Text || this.hdnOldAdd3.Value != this.txt_address_billing3.Text || this.hdnOldAdd4.Value != this.txt_address_billing4.Text || this.hdnOldAdd5.Value != this.txt_address_billing5.Text || this.hdnOldTel.Value != this.txt_telephone_billing.Text || this.hdnOldPhone.Value != this.txt_fax_billing.Text || this.hdnOldCountryID.Value != this.ddl_country_billing.SelectedValue)
                    {
                        this.IsOrdered = "new";
                        this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, "", "", this.txt_address_billing1.Text, this.txt_address_billing2.Text, this.txt_address_billing3.Text, this.txt_address_billing4.Text, this.txt_address_billing5.Text, this.txt_telephone_billing.Text, this.txt_fax_billing.Text, this.ddl_country_billing.SelectedItem.Text, 0, 0, this.txtaddressLabelBilling.Text, this.CreatedDate);
                        this.hdn_BillingAddressID.Value = this.BillingAddressID.ToString();
                    }
                    if (this.BillingAddressID == (long)0)
                    {
                        HttpCookie item = base.Request.Cookies["BillAddressID"];
                        this.hdn_BillingAddressID.Value = item.Value;
                    }
                }
                if (this.StoreUserID != (long)0 && this.BillingAddressID > (long)0 && this.Session["isGuest"] != null && this.Session["isGuest"].ToString().ToLower() == "yes")
                {
                    HttpCookie httpCookie = new HttpCookie("BillAddressID")
                    {
                        Value = this.BillingAddressID.ToString()
                    };
                    base.Response.Cookies.Add(httpCookie);
                    HttpCookie httpCookie1 = new HttpCookie("BillCountryID")
                    {
                        Value = this.ddl_country_billing.SelectedValue.ToString()
                    };
                    base.Response.Cookies.Add(httpCookie1);
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

        protected void GetAddressDetails(string Type, string Id)
        {
            DataTable dataTable = OrderBasePage.Select_One_BillingShipping_Address(Convert.ToInt64(Id));
            if (Type == "bill")
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.lblBillingAddress.Text = string.Empty;
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
                this.lblBillingAddress.Text = this.objBc.SpecialDecode(this.lblBillingAddress.Text);
                return;
            }
            if (Type == "ship")
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.lblShippingAddress.Text = string.Empty;
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
                    this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, "F:&nbsp", dataRow["Fax"].ToString());
                    this.lblShippingAddress.Text = string.Concat(this.lblShippingAddress.Text, ",");
                    Label label11 = this.lblShippingAddress;
                    string str5 = this.lblShippingAddress.Text;
                    char[] chrArray11 = new char[] { ',' };
                    label11.Text = string.Concat(str5.TrimEnd(chrArray11), "<br/>");
                }
                this.lblShippingAddress.Text = this.objBc.SpecialDecode(this.lblShippingAddress.Text);
            }
        }

        protected void OnClick_btn_BackShop(object sender, EventArgs e)
        {
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "shoppingcart.aspx?ID=0&amp;PID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void OnClick_lnkBtnBillingAddress(object sender, EventArgs e)
        {
            this.Checkouts_BillingShippingAddress_New();
            this.OrderPayment();
            this.Session["ConfirmBeforeOrdernew"] = "1";
            string str = this.GenPassWithCap(12);
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "ConfirmBeforeOrdernew.aspx?OrdKey=", str, "&amp;type=0&key=&BID=0&SID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "ConfirmBeforeOrdernew", ConnectionClass.KeySeparator, str, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void OnClick_lnkbtnOrder(object sender, EventArgs e)
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
            foreach (DataRow row in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
            {
                this.ClientID = Convert.ToInt64(row["ClientID"].ToString());
                if (this.IsOrdered == "new")
                {
                    this.IsOrdered = "no";
                }
                else if (!Convert.ToBoolean(row["IsOrdered"].ToString()))
                {
                    this.IsOrdered = "no";
                }
                else
                {
                    this.IsOrdered = "yes";
                }
            }
            if (this.IsOrdered == "no")
            {
                if (this.isLoginInfo != "0")
                {
                    this.ClientID = OrderBasePage.Insert_CustomerOn_Order((long)this.CompanyID, this.StoreUserID, this.AccountID, this.BillingAddressID, this.ShippingAddressID, "no", this.CreatedDate,"","");
                }
                else if (this.Session["CommonClient"] != null)
                {
                    this.ClientID = (long)Convert.ToInt32(this.Session["CommonClient"]);
                    OrderBasePage.Insert_Contact(this.CompanyID, this.ClientID, this.StoreUserID, this.AccountID, this.BillingAddressID, this.ShippingAddressID, "no", this.CreatedDate);
                }
                this.hdn_ClientID.Value = this.ClientID.ToString();
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
            string str = "0";
            string str1 = "0";
            if (this.comm.GetDisplayValue("isCheckAddressInfo", this.AccountID) == "true")
            {
                str = (this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID) != "true" ? this.Session["ShippingAddressID"].ToString() : this.Session["BillingAddressID"].ToString());
                str1 = (this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID) != "true" ? this.Session["BillingAddressID"].ToString() : this.Session["ShippingAddressID"].ToString());
            }
            object[] storeUserID = new object[] { this.StoreUserID, this.SesseionKey, str, str1, this.ClientID, this.IsOrdered, this.PaymentType, this.txtRequiredBy.Text, this.objBc.SpecialEncode(this.txtComments.Text), this.objBc.SpecialEncode(this.txt_orderTitle.Text), this.objBc.SpecialEncode(this.txt_orderNumber.Text), this.hdn_OrderID.Value, "0" };
            dataTable.Rows.Add(storeUserID);
            this.Session["InsertOrder"] = dataTable;
            this.StoreOldDatas();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btn_billingAddress);
            
            this.btn_billingAddress.Text = this.objLanguage.GetLanguageConversion("Continue");
            this.txt_orderTitle = (TextBox)this.ucOrderInfo.FindControl("txt_orderTitle");
            this.txt_orderNumber = (TextBox)this.ucOrderInfo.FindControl("txt_orderNumber");
            this.txtRequiredBy = (TextBox)this.ucOrderInfo.FindControl("txtRequiredBy");
            this.ddlCostCentre = (DropDownList)this.ucOrderInfo.FindControl("ddlCostCenter");
            this.txtComments = (TextBox)this.ucOrderInfo.FindControl("txtComments");
            this.lblBillingAddress = (Label)this.ucAddressInfo.FindControl("lblBillingAddress");
            this.lblShippingAddress = (Label)this.ucAddressInfo.FindControl("lblShippingAddress");
            this.ddl_country_billing = (DropDownList)this.ucAddressInfo.FindControl("ddlCountry");
            this.lblAddressBill1 = (Label)this.ucAddressInfo.FindControl("lblAddressBill1");
            this.lblAddressBill2 = (Label)this.ucAddressInfo.FindControl("lblAddressBill2");
            this.lblAddressBill3 = (Label)this.ucAddressInfo.FindControl("lblAddressBill3");
            this.lblAddressBill4 = (Label)this.ucAddressInfo.FindControl("lblAddressBill4");
            this.lblAddressBill5 = (Label)this.ucAddressInfo.FindControl("lblAddressBill5");
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
            this.txtaddressLabelBilling = (TextBox)this.ucAddressInfo.FindControl("txtaddressLabelBilling");
            this.txt_address_billing1 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing1");
            this.txt_address_billing2 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing2");
            this.txt_address_billing3 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing3");
            this.txt_address_billing4 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing4");
            this.txt_address_billing5 = (TextBox)this.ucAddressInfo.FindControl("txt_address_billing5");
            this.txt_telephone_billing = (TextBox)this.ucAddressInfo.FindControl("txt_telephone_billing");
            this.txt_fax_billing = (TextBox)this.ucAddressInfo.FindControl("txt_fax_billing");
            this.chkCopytoInvoice = (CheckBox)this.ucAddressInfo.FindControl("chkCopytoInvoice");
            this.ChkcopytoDel = (CheckBox)this.ucAddressInfo.FindControl("ChkcopytoDel");
            this.Chk_makedefaultAddres_Invoice = (CheckBox)this.ucAddressInfo.FindControl("Chk_makedefaultAddres_Invoice");
            this.Chk_makedefaultAddres_Delivery = (CheckBox)this.ucAddressInfo.FindControl("Chk_makedefaultAddres_Delivery");
            this.rdgrd_ship = (RadGrid)this.ucAddressInfo.FindControl("rdgrd_ship_choose");
            this.rdgrd_bill = (RadGrid)this.ucAddressInfo.FindControl("rdgrd_bill_choose");
            this.hdnChkInvAddress = (HiddenField)this.ucAddressInfo.FindControl("hdnChkInvAddress");
            this.hdnChkDelAddress = (HiddenField)this.ucAddressInfo.FindControl("hdnChkDelAddress");
            this.hdnTotalAddressCount = (HiddenField)this.ucAddressInfo.FindControl("hdnTotalAddressCount");
            Button button = (Button)this.ucOrderInfo.FindControl("btn_orderInfo");
            button.Attributes.Add("OnClick", "javascript:return OrderValidate();");
            this.ucAddressInfo.ButtonClick_Ship += new EventHandler(this.ucAddressInfo_ButtonClick_Ship);
            this.ucAddressInfo.ButtonClick_Bill += new EventHandler(this.ucAddressInfo_ButtonClick_Bill);
            this.ucAddressInfo.ButtonSaveClick_Bill += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Bill);
            this.ucAddressInfo.ButtonSaveClick_Ship += new EventHandler(this.ucAddressInfo_ButtonSaveClick_Ship);
            this.ucAddressInfo.ButtonUpdateClick_Bill += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Bill);
            this.ucAddressInfo.ButtonUpdateClick_Ship += new EventHandler(this.ucAddressInfo_ButtonUpdateClick_Ship);
            this.lblLine = (Label)this.ucAddressInfo.FindControl("lblLine");
            this.lblDeliveryLine = (Label)this.ucAddressInfo.FindControl("lblDeliveryLine");
            this.lnkEdit_Bill = (LinkButton)this.ucAddressInfo.FindControl("lnkEdit_Bill");
            this.lnkEdit_Ship = (LinkButton)this.ucAddressInfo.FindControl("lnkEdit_Ship");
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
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = ConnectionClass.KeySeparator;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (this.Session["isGuest"] != null && this.Session["isGuest"].ToString().ToLower() == "yes")
            {
                this.isGuest = "1";
            }
            if (this.Session["PaymentStep"] != null && (this.Session["PaymentStep"].ToString() != null || this.Session["PaymentStep"].ToString() != ""))
            {
                this.PaymentStep = this.Session["PaymentStep"].ToString();
            }
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
                    this.li_Confirmation.Attributes.Add("class", "HideArrow");
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
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
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
                    this.li_Confirmation.Attributes.Add("class", "HideArrow");
                }
                if (this.comm.GetDisplayValue("isCheckOrderInfoPublic", this.AccountID) != "false")
                {
                    this.li_Order.Style.Add("display", "block");
                }
                else
                {
                    this.li_Order.Style.Add("display", "none");
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "", true);
                }
                if (this.comm.GetDisplayValue("isCheckAddressInfo", this.AccountID) != "false")
                {
                    this.li_Address.Style.Add("display", "block");
                }
                else
                {
                    this.li_Address.Style.Add("display", "none");
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
            if (this.Session["StoreUserID"] == null || this.AccountID == (long)0 && this.CompanyID == 0)
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
            base.Title = commonclass.pageTitle("Checkout", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            this.SesseionKey = this.comm.UniqueID;
            if (this.StoreUserID == (long)0)
            {
                this.hid_billingaddress.Value = "yes";
            }
            else if (this.Session["isGuest"] != null && this.Session["isGuest"].ToString().ToLower() == "yes")
            {
                this.hid_billingaddress.Value = "yes";
            }
            DataTable dataTable = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
            foreach (DataRow row1 in dataTable.Rows)
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
                DataTable dataTable1 = CMSBasePage.paymentSelect(this.CompanyID, Convert.ToInt32(this.AccountID));
                foreach (DataRow dataRow1 in dataTable1.Rows)
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
                foreach (DataRow row2 in CartBasePage.Select_CartItems(this.SesseionKey, "", this.StoreUserID).Rows)
                {
                    checkoutnew _checkoutnew = this;
                    _checkoutnew.cartCount = _checkoutnew.cartCount + 1;
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
                int num = 0;
                DataTable dataTable2 = OrderBasePage.Select_BillingShipping_Address(this.StoreUserID, "bill", (long)0);
                if (this.StoreUserID != (long)0)
                {
                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        this.hid_address.Value = "yes";
                        num++;
                    }
                }
                if (num == 0)
                {
                    this.hid_address.Value = "no";
                    this.lbl_billingRF.Style.Add("display", "block");
                }
                else if (this.Session["isGuest"] == null || !(this.Session["isGuest"].ToString().ToLower() == "yes"))
                {
                    this.bindAddress_Grid(this.StoreUserID, "bill", (long)0);
                    foreach (DataRow row3 in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                    {
                        this.DefaultBillingAddressID = Convert.ToInt64(row3["DefaultBillingID"]);
                        this.DefaultShippingAddressID = Convert.ToInt64(row3["DefaultShippingID"]);
                    }
                    if (this.Session["InsertOrder"] != null)
                    {
                        DataTable item = (DataTable)this.Session["InsertOrder"];
                        if (item != null)
                        {
                            foreach (DataRow dataRow3 in item.Rows)
                            {
                                this.DefaultBillingAddressID = Convert.ToInt64(dataRow3["InvoiceAddressID"]);
                                this.DefaultShippingAddressID = Convert.ToInt64(dataRow3["DeliveryAddressID"]);
                            }
                        }
                    }
                    this.Session["BillingAddressID"] = this.DefaultBillingAddressID.ToString();
                    this.Session["ShippingAddressID"] = this.DefaultShippingAddressID.ToString();
                    this.GetAddressDetails("bill", this.DefaultBillingAddressID.ToString());
                    this.GetAddressDetails("ship", this.DefaultShippingAddressID.ToString());
                    this.lbl_billingRF.Style.Add("display", "none");
                }
                else if (base.Request.Cookies["BillAddressID"] != null)
                {
                    HttpCookie httpCookie = base.Request.Cookies["BillAddressID"];
                    HttpCookie item1 = base.Request.Cookies["BillCountryID"];
                    DataView dataViews = new DataView(dataTable2)
                    {
                        RowFilter = string.Concat("AddressID = '", Convert.ToInt64(httpCookie.Value), "'")
                    };
                    this.txt_address_billing1.Text = dataViews[0]["AddressLine1"].ToString();
                    this.txt_address_billing2.Text = dataViews[0]["AddressLine2"].ToString();
                    this.txt_address_billing3.Text = dataViews[0]["Address2"].ToString();
                    this.txt_address_billing4.Text = dataViews[0]["Address3"].ToString();
                    this.txt_address_billing5.Text = dataViews[0]["Address4"].ToString();
                    this.txt_telephone_billing.Text = dataViews[0]["phone"].ToString();
                    this.txt_fax_billing.Text = dataViews[0]["fax"].ToString();
                    this.ddl_country_billing.SelectedValue = item1.Value;
                    this.hdnOldAdd1.Value = dataViews[0]["AddressLine1"].ToString();
                    this.hdnOldAdd2.Value = dataViews[0]["AddressLine2"].ToString();
                    this.hdnOldAdd3.Value = dataViews[0]["Address2"].ToString();
                    this.hdnOldAdd4.Value = dataViews[0]["Address3"].ToString();
                    this.hdnOldAdd5.Value = dataViews[0]["Address4"].ToString();
                    this.hdnOldTel.Value = dataViews[0]["phone"].ToString();
                    this.hdnOldPhone.Value = dataViews[0]["fax"].ToString();
                    this.hdnOldCountryID.Value = item1.Value;
                    this.hid_address.Value = "no";
                    this.lbl_billingRF.Style.Add("display", "block");
                }
                if (this.Session["CheckOut"] == null)
                {
                    if (this.txtRequiredBy.Text.Trim().Length == 0)
                    {
                        if (ConnectionClass.SystemName.ToLower() != "aviva")
                        {
                            int num1 = 0;
                            int num2 = 0;
                            int num3 = 0;
                            num1 = Convert.ToInt32(this.comm.GetDisplayValue("WorkingDaysFrom", this.AccountID));
                            num2 = Convert.ToInt32(this.comm.GetDisplayValue("WorkingDaysTo", this.AccountID));
                            num3 = Convert.ToInt32(this.comm.GetDisplayValue("DefaultEstimatedDelivery", this.AccountID));
                            if (Convert.ToInt32(this.comm.GetDisplayValue("DeliveryRequiredByValue", this.AccountID)) != -1)
                            {
                                TextBox textBox = this.txtRequiredBy;
                                commonclass _commonclass = this.comm;
                                DateTime dateTime = this.comm.ReturnWeekDate(DateTime.Now, num1, num2, num3);
                                textBox.Text = _commonclass.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);
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
                            textBox1.Text = _commonclass1.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
                        }
                    }
                    if (this.txtComments.Text.Trim().Length == 0)
                    {
                        string displayValue = this.comm.GetDisplayValue("CommentsDefaultValue", this.AccountID);
                        this.txtComments.Text = displayValue;
                    }
                }
                else
                {
                    DataTable item2 = (DataTable)this.Session["CheckOut"];
                    if (item2 != null)
                    {
                        foreach (DataRow row4 in item2.Rows)
                        {
                            string empty = string.Empty;
                            string empty1 = string.Empty;
                            this.IsSessionCheckOut = true;
                            this.hdn_ClientID.Value = row4["ClientID"].ToString();
                            this.txt_orderTitle.Text = row4["OrderTitle"].ToString();
                            this.txt_orderNumber.Text = row4["OrderNo"].ToString();
                            this.txtRequiredBy.Text = row4["ReferedBy"].ToString();
                            this.txtComments.Text = row4["Comments"].ToString();
                            this.pnl_BillingAddress.Visible = true;
                            this.pnl_ShippingAddress.Visible = true;
                            this.pnl_checkout.Visible = false;
                        }
                    }
                }
                DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToString());
                this.newdate = dateTime2.ToShortDateString();
                this.txtRequiredBy.Attributes.Add("onclick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                if (base.Request.Params["frm"] != null)
                {
                    this.FromOrdrConfrm = base.Request.Params["frm"].ToString();
                }
            }
            this.NewSessionID = this.comm.UniqueID;
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
            if (this.Session["BillingAddressID"] == null)
            {
                this.Session["BillingAddressID"] = "0";
            }
            else
            {
                this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
            }
            if (this.Session["ShippingAddressID"] == null)
            {
                this.Session["ShippingAddressID"] = "0";
            }
            else
            {
                this.hdnChkDelAddress.Value = this.Session["ShippingAddressID"].ToString();
            }
            this.isCheckOrderInfoPublic = this.comm.GetDisplayValue("isCheckOrderInfoPublic", this.AccountID).ToLower().Trim();
            this.isCheckAddressInfo = this.comm.GetDisplayValue("isCheckAddressInfo", this.AccountID).ToLower().Trim();
            this.isCheckDeliveryInfo = this.comm.GetDisplayValue("isCheckDeliveryInfo", this.AccountID).ToLower().Trim();
            this.isCheckInvoiceInfo = this.comm.GetDisplayValue("isCheckInvoiceInfo", this.AccountID).ToLower().Trim();
            if (this.Session["AddressGrid"] != null)
            {
                DataTable item3 = (DataTable)this.Session["AddressGrid"];
                this.hdnTotalAddressCount.Value = item3.Rows.Count.ToString();
            }
        }

        public void SetDDLValue(DropDownList ddl, string value)
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
            string str = "0";
            string str1 = "0";
            if (this.Session["BillingAddressID"] != null)
            {
                str = this.Session["BillingAddressID"].ToString();
            }
            if (this.Session["ShippingAddressID"] != null)
            {
                str1 = this.Session["ShippingAddressID"].ToString();
            }
            object[] value = new object[] { this.hdn_ClientID.Value, this.txt_orderTitle.Text, this.txt_orderNumber.Text, this.txtRequiredBy.Text, this.txtComments.Text, str, str1, "", "", "", "", "0", "0", "" };
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
            System.Web.UI.Page page = this.Page;
            Type type = typeof(System.Web.UI.Page);
            string[] strArrays = new string[] { "HideDialog3();ShowEdit(", this.Session["ShippingAddressID"].ToString(), ",", this.Session["BillingAddressID"].ToString(), ",'Invoice');" };
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, type, "Script", string.Concat(strArrays), true);
            this.rdgrd_bill.Rebind();
        }

        protected void ucAddressInfo_ButtonClick_Ship(object sender, EventArgs e)
        {
            string str = ((LinkButton)sender).CommandArgument.ToString();
            this.Session["ShippingAddressID"] = str;
            if (this.Session["ShippingAddressID"] != null)
            {
                this.hdnChkDelAddress.Value = this.Session["ShippingAddressID"].ToString();
            }
            this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            System.Web.UI.Page page = this.Page;
            Type type = typeof(System.Web.UI.Page);
            string[] strArrays = new string[] { "HideDialog4();ShowEdit(", this.Session["ShippingAddressID"].ToString(), ",", this.Session["BillingAddressID"].ToString(), ",'Delivery');" };
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, type, "Script", string.Concat(strArrays), true);
            this.rdgrd_ship.Rebind();
        }

        protected void ucAddressInfo_ButtonSaveClick_Bill(object sender, EventArgs e)
        {
            this.CreatedDate = DateTime.Now;
            if (this.Chk_makedefaultAddres_Invoice.Checked)
            {
                this.IsDefaultBilling = 1;
            }
            if (this.ChkcopytoDel.Checked && this.Chk_makedefaultAddres_Invoice.Checked)
            {
                this.IsDefaultShipping = 1;
            }
            this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), this.IsDefaultBilling, this.IsDefaultShipping, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            this.Session["BillingAddressID"] = this.BillingAddressID.ToString();
            this.bindAddress_Grid(this.StoreUserID, "bill", (long)0);
            string str = "Invoice";
            if (!this.ChkcopytoDel.Checked)
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            else
            {
                str = "Copy";
                this.Session["ShippingAddressID"] = this.BillingAddressID.ToString();
                if (this.Session["BillingAddressID"] != null)
                {
                    this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
                }
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            System.Web.UI.Page page = this.Page;
            Type type = typeof(System.Web.UI.Page);
            string[] value = new string[] { "HideDialog();ShowChooseandEdit(", this.hdnTotalAddressCount.Value, ",'", str, "');" };
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, type, "Script", string.Concat(value), true);
        }

        protected void ucAddressInfo_ButtonSaveClick_Ship(object sender, EventArgs e)
        {
            this.CreatedDate = DateTime.Now;
            if (this.Chk_makedefaultAddres_Delivery.Checked)
            {
                this.IsDefaultShipping = 1;
            }
            if (this.chkCopytoInvoice.Checked && this.Chk_makedefaultAddres_Delivery.Checked)
            {
                this.IsDefaultBilling = 1;
            }
            this.ShippingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, "", "", this.txt_address_billing1.Text.Trim(), this.txt_address_billing2.Text.Trim(), this.txt_address_billing3.Text.Trim(), this.txt_address_billing4.Text.Trim(), this.txt_address_billing5.Text.Trim(), this.txt_telephone_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), this.IsDefaultBilling, this.IsDefaultShipping, this.txtaddressLabelBilling.Text.Trim(), this.CreatedDate);
            this.Session["ShippingAddressID"] = this.ShippingAddressID.ToString();
            if (this.Session["ShippingAddressID"] != null)
            {
                this.hdnChkDelAddress.Value = this.Session["ShippingAddressID"].ToString();
            }
            this.bindAddress_Grid(this.StoreUserID, "bill", (long)0);
            string str = "Delivery";
            if (!this.chkCopytoInvoice.Checked)
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            else
            {
                str = "Copy";
                this.Session["BillingAddressID"] = this.ShippingAddressID.ToString();
                if (this.Session["BillingAddressID"] != null)
                {
                    this.hdnChkInvAddress.Value = this.Session["BillingAddressID"].ToString();
                }
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            System.Web.UI.Page page = this.Page;
            Type type = typeof(System.Web.UI.Page);
            string[] value = new string[] { "HideDialog();ShowChooseandEdit(", this.hdnTotalAddressCount.Value, ",'", str, "');" };
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, type, "script", string.Concat(value), true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Bill(object sender, EventArgs e)
        {
            if (this.Chk_makedefaultAddres_Invoice.Checked)
            {
                this.IsDefaultBilling = 1;
            }
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["BillingAddressID"]), "", "", this.objBc.SpecialEncode(this.txt_address_billing1.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing2.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing3.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing4.Text.Trim()), this.objBc.SpecialEncode(this.txt_telephone_billing.Text.Trim()), this.objBc.SpecialEncode(this.txt_fax_billing.Text.Trim()), this.ddl_country_billing.SelectedItem.Text.Trim(), this.objBc.SpecialEncode(this.txtaddressLabelBilling.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing5.Text.Trim()), (long)this.IsDefaultBilling, (long)this.IsDefaultShipping, this.StoreUserID);
            this.bindAddress_Grid(this.StoreUserID, "bill", (long)0);
            if (this.Session["BillingAddressID"].ToString() == this.Session["ShippingAddressID"].ToString())
            {
                this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            }
            this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, typeof(System.Web.UI.Page), "Script", "HideDialog();", true);
        }

        protected void ucAddressInfo_ButtonUpdateClick_Ship(object sender, EventArgs e)
        {
            if (this.Chk_makedefaultAddres_Delivery.Checked)
            {
                this.IsDefaultShipping = 1;
            }
            OrderBasePage.Update_BillingShipping_Address(Convert.ToInt64(this.Session["ShippingAddressID"]), "", "", this.objBc.SpecialEncode(this.txt_address_billing1.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing2.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing3.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing4.Text.Trim()), this.txt_telephone_billing.Text.Trim(), this.txt_fax_billing.Text.Trim(), this.ddl_country_billing.SelectedItem.Text.Trim(), this.objBc.SpecialEncode(this.txtaddressLabelBilling.Text.Trim()), this.objBc.SpecialEncode(this.txt_address_billing5.Text.Trim()), (long)this.IsDefaultBilling, (long)this.IsDefaultShipping, this.StoreUserID);
            this.bindAddress_Grid(this.StoreUserID, "bill", (long)0);
            if (this.Session["BillingAddressID"].ToString() == this.Session["ShippingAddressID"].ToString())
            {
                this.GetAddressDetails("bill", this.Session["BillingAddressID"].ToString());
            }
            this.GetAddressDetails("ship", this.Session["ShippingAddressID"].ToString());
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, typeof(System.Web.UI.Page), "Script", "HideDialog();", true);
        }
    }
}