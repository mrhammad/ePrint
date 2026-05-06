using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class create_account : System.Web.UI.Page, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label Label10;

        //protected TextBox txtCompanyName;

        //protected Label lbl_firstName;

        //protected TextBox txt_firstName;

        //protected RequiredFieldValidator req_firstName;

        //protected Label Label5;

        //protected Label lbl_BillAddress1;

        //protected HtmlGenericControl lblAdd1;

        //protected TextBox txtBillAddress1;

        //protected RequiredFieldValidator reqAddress1;

        //protected Label lbl_BillAddress2;

        //protected HtmlGenericControl lblAdd2;

        //protected TextBox txtBillAddress2;

        //protected RequiredFieldValidator reqAddress2;

        //protected Label lbl_BillCity;

        //protected HtmlGenericControl lblAdd3;

        //protected TextBox txtBillCity;

        //protected RequiredFieldValidator reqAddress3;

        //protected Label lbl_BillState;

        //protected HtmlGenericControl lblAdd4;

        //protected TextBox txtBillState;

        //protected RequiredFieldValidator reqAddress4;

        //protected Label lblBillZipCode;

        //protected HtmlGenericControl lblAdd5;

        //protected TextBox txtBillZipCode;

        //protected RequiredFieldValidator reqAddress5;

        //protected Label lblBillCountry;

        //protected DropDownList ddlBillCountry;

        //protected RequiredFieldValidator reqCountry;

        //protected Label lblBillTelephone;

        //protected TextBox txtBillTelephone;

        //protected RequiredFieldValidator reqTelephone;

        //protected Label lblBillFax;

        //protected TextBox txtBillFax;

        //protected CheckBox chkCopyAdd;

        //protected CheckBox chkAddEmilDmc;

        //protected Label lbl_email;

        //protected TextBox txt_email;

        //protected RequiredFieldValidator reqemail;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected CustomValidator cvEmailID;

        //protected Label lbl_password;

        //protected TextBox txtpassword;

        //protected RequiredFieldValidator reqpassword;

        //protected Label lbl_lastName;

        //protected TextBox txt_lastName;

        //protected RequiredFieldValidator reqlastName;

        //protected Label Label9;

        //protected Label lbl_ShipAddress1;

        //protected HtmlGenericControl lbl_ShipAdd1;

        //protected TextBox txtShipAddress1;

        //protected RequiredFieldValidator req_ShipAddress1;

        //protected Label lbl_ShipAddress2;

        //protected HtmlGenericControl lbl_ShipAdd2;

        //protected TextBox txtShipAddress2;

        //protected RequiredFieldValidator req_ShipAddress2;

        //protected Label lbl_ShipCity;

        //protected HtmlGenericControl lbl_ShipAdd3;

        //protected TextBox txtShipCity;

        //protected RequiredFieldValidator req_ShipAddress3;

        //protected Label lbl_ShipState;

        //protected HtmlGenericControl lbl_ShipAdd4;

        //protected TextBox txtShipState;

        //protected RequiredFieldValidator req_ShipAddress4;

        //protected Label lbl_ShipZipCode;

        //protected HtmlGenericControl lbl_ShipAdd5;

        //protected TextBox txtShipZipCode;

        //protected RequiredFieldValidator req_ShipAddress5;

        //protected Label lblShipCountry;

        //protected DropDownList ddlShipCountry;

        //protected RequiredFieldValidator req_ShipCountry;

        //protected Label lblShipTelephone;

        //protected TextBox txtShipTelephone;

        //protected RequiredFieldValidator req_ShipTelephone;

        //protected Label lblShipFax;

        //protected TextBox txtShipFax;

        //protected Label lbl_confirmPassword;

        //protected TextBox txt_confirmPassword;

        //protected RequiredFieldValidator reqconfirmPassword;

        //protected CompareValidator CompareValidator1;

        //protected Button btn_createAccount;

        //protected HiddenField hdnIsMandAdd1;

        //protected HiddenField hdnIsMandAdd2;

        //protected HiddenField hdnIsMandAdd3;

        //protected HiddenField hdnIsMandAdd4;

        //protected HiddenField hdnIsMandAdd5;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass Objemail = new EmailClass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        private DateTime CreatedDate;

        public int UserID;

        public long StoreUserID;

        public long CompanyID;

        public long AccountID;

        public long BillingAddressID;

        public long ShippingAddressID;

        public long rtnDeptID;

        public long retClientID;

        public string AccountType = string.Empty;

        public string ClientName = string.Empty;

        public string SesseionKey = string.Empty;

        public string PostCode = string.Empty;

        public string DateFormat = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public static string strSitepath;

        public int ddlCountryIndex;

        public string NewSessionID = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Frompage = string.Empty;

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

        static create_account()
        {
            create_account.strSitepath = string.Empty;
        }

        public create_account()
        {
        }

        [WebMethod]
        public static int Check_EmailID_Duplicacy(string val)
        {
            loginclass _loginclass = new loginclass();
            BaseClass baseClass = new BaseClass();
            string str = val;
            int num = LoginBasePage.CheckEmailID_Duplicacy((long)0, baseClass.SpecialEncode(str), (long)0);
            return num;
        }

        protected void custEmailID_Duplicacy_ServerValidate(object source, ServerValidateEventArgs args)
        {
            loginclass _loginclass = new loginclass();
            if (LoginBasePage.CheckEmailID_Duplicacy(this.StoreUserID, this.objBase.SpecialDecode(this.txt_email.Text), this.AccountID) == -1)
            {
                args.IsValid = false;
                return;
            }
            args.IsValid = true;
        }

        protected void Onclick_btnCreateAccount(object sender, EventArgs e)
        {
            try
            {
                commonclass _commonclass = this.comm;
                string dateFormat = this.DateFormat;
                commonclass _commonclass1 = this.comm;
                DateTime now = DateTime.Now;
                this.CreatedDate = Convert.ToDateTime(_commonclass.date_Check_new(dateFormat, _commonclass1.Eprint_return_Date_Before_View(now.ToString(), Convert.ToInt32(this.CompanyID), this.UserID, true)));
            }
            catch
            {
                this.CreatedDate = DateTime.Now;
            }
            if (this.Page.IsValid)
            {
                int num = 0;
                num = (!this.chkAddEmilDmc.Checked ? 0 : 1);
                this.StoreUserID = LoginBasePage.Create_StoreUser((long)0, (long)0, this.objBase.SpecialEncode(this.txt_firstName.Text), this.objBase.SpecialEncode(this.txt_lastName.Text), this.objBase.SpecialEncode(this.txt_email.Text), this.txtpassword.Text, this.CompanyID, this.AccountID, "new", this.objBase.SpecialEncode(this.txtCompanyName.Text), num);
                if (this.StoreUserID != (long)0)
                {
                    this.SesseionKey = this.comm.UniqueID;
                    this.login.Insert_intoResume_Session(this.objBase.SpecialEncode(this.txt_email.Text), this.txtpassword.Text);
                    this.login.LogInFromDefault(this.objBase.SpecialEncode(this.txt_email.Text), this.txtpassword.Text);
                    CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
                    if (!(this.txtBillAddress1.Text.Trim() == this.txtShipAddress1.Text.Trim()) || !(this.txtBillAddress2.Text.Trim() == this.txtShipAddress2.Text.Trim()) || !(this.txtBillCity.Text.Trim() == this.txtShipCity.Text.Trim()) || !(this.txtBillState.Text.Trim() == this.txtShipState.Text.Trim()) || !(this.txtBillZipCode.Text.Trim() == this.txtShipZipCode.Text.Trim()) || !(this.txtBillTelephone.Text.Trim() == this.txtShipTelephone.Text.Trim()) || !(this.txtBillFax.Text.Trim() == this.txtShipFax.Text.Trim()) || this.ddlBillCountry.SelectedIndex != this.ddlShipCountry.SelectedIndex)
                    {
                        this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.objBase.SpecialEncode(this.txt_firstName.Text), this.objBase.SpecialEncode(this.txt_lastName.Text), this.objBase.SpecialEncode(this.txtBillAddress1.Text), this.objBase.SpecialEncode(this.txtBillAddress2.Text), this.objBase.SpecialEncode(this.txtBillCity.Text), this.objBase.SpecialEncode(this.txtBillState.Text), this.txtBillZipCode.Text, this.txtBillTelephone.Text, this.txtBillFax.Text, this.ddlBillCountry.SelectedItem.Text, 1, 0, "Main", this.CreatedDate);
                        this.ShippingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.txt_firstName.Text, this.txt_lastName.Text, this.txtShipAddress1.Text, this.txtShipAddress2.Text, this.txtShipCity.Text, this.txtShipState.Text, this.txtShipZipCode.Text, this.txtShipTelephone.Text, this.txtShipFax.Text, this.ddlShipCountry.SelectedItem.Text, 0, 1, "Main", this.CreatedDate);
                    }
                    else
                    {
                        this.BillingAddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.objBase.SpecialEncode(this.txt_firstName.Text), this.objBase.SpecialEncode(this.txt_lastName.Text), this.objBase.SpecialEncode(this.txtBillAddress1.Text), this.objBase.SpecialEncode(this.txtBillAddress2.Text), this.objBase.SpecialEncode(this.txtBillCity.Text), this.objBase.SpecialEncode(this.txtBillState.Text), this.txtBillZipCode.Text, this.txtBillTelephone.Text, this.txtBillFax.Text, this.ddlBillCountry.SelectedItem.Text, 1, 1, "Main", this.CreatedDate);
                        this.ShippingAddressID = this.BillingAddressID;
                    }
                    this.retClientID = OrderBasePage.Insert_CustomerOn_Order(this.CompanyID, this.StoreUserID, this.AccountID, this.BillingAddressID, this.ShippingAddressID, "yes", this.CreatedDate,"","");
                    this.Objemail.emailRegisterDetails(Convert.ToInt32(this.StoreUserID), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID), "New User Registration");
                }
                int num1 = 0;
                foreach (DataRow row in CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID).Rows)
                {
                    num1++;
                }
                if (this.Frompage.ToLower() == "cart")
                {
                    if (ConnectionClass.RewriteModule.ToLower() != "on")
                    {
                        base.Response.Redirect(string.Concat(create_account.strSitepath, "checkoutnew.aspx"));
                        return;
                    }
                    base.Response.Redirect(string.Concat(create_account.strSitepath, "checkoutnew", ConnectionClass.FileExtension));
                    return;
                }
                if (num1 == 0 || ConnectionClass.AccountType.Trim().ToLower() != "public")
                {
                    if (ConnectionClass.RewriteModule.ToLower() != "on")
                    {
                        base.Response.Redirect(string.Concat(create_account.strSitepath, "account/account.aspx"));
                        return;
                    }
                    base.Response.Redirect(string.Concat(create_account.strSitepath, "account/account", ConnectionClass.FileExtension));
                    return;
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    HttpResponse response = base.Response;
                    string[] keySeparator = new string[] { create_account.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                    response.Redirect(string.Concat(keySeparator));
                    return;
                }
                base.Response.Redirect(string.Concat(create_account.strSitepath, "shoppingcart.aspx?ID=0&amp;PID=0"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.req_firstName.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress1.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress2.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress3.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress4.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress5.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqCountry.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Select_Country");
            this.reqTelephone.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqemail.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Email_Address_Example_Note");
            this.cvEmailID.ErrorMessage = this.objLanguage.GetLanguageConversion("EmailID_already_exists");
            this.reqpassword.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqlastName.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipAddress1.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipAddress2.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipAddress3.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipAddress4.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipAddress5.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ShipCountry.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Select_Country");
            this.req_ShipTelephone.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqconfirmPassword.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.CompareValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_make_sure_your_passwords_match");
            this.chkCopyAdd.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Copy_to_Delivery_Address"));
            this.chkAddEmilDmc.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Add_Email_to_EDM_Database"));
            this.btn_createAccount.Text = this.objLanguage.GetLanguageConversion("Create_An_Account");
            if (ConnectionClass.ISSubScribeUser != null)
            {
                if (ConnectionClass.ISSubScribeUser == "true" || ConnectionClass.IsmailChimpEnabled == "true")
                {
                    this.chkAddEmilDmc.Visible = true;
                }
                else
                {
                    this.chkAddEmilDmc.Visible = false;
                }
            }
            if (ConnectionClass.SitePath != null)
            {
                create_account.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt64(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddlBillCountry);
                OrderBasePage.company_country_select(this.ddlShipCountry);
                DataTable dataTable = OrderBasePage.settings_companyprofile_select(Convert.ToInt32(this.CompanyID));
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["CountryID"].ToString() == "")
                        {
                            continue;
                        }
                        this.Session["ddlCountryIndex"] = Convert.ToInt32(row["CountryID"]);
                    }
                }
                if (this.Session["ddlCountryIndex"] != null && this.Session["ddlCountryIndex"].ToString() != "")
                {
                    this.ddlBillCountry.SelectedIndex = Convert.ToInt32(this.Session["ddlCountryIndex"]);
                    this.ddlShipCountry.SelectedIndex = Convert.ToInt32(this.Session["ddlCountryIndex"]);
                }
            }
            try
            {
                this.ddlCountryIndex = Convert.ToInt32(this.Session["ddlCountryIndex"]);
            }
            catch
            {
            }
            this.lbl_BillAddress1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lbl_BillAddress2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lbl_BillCity.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lbl_BillState.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblBillZipCode.Text = this.comm.GetAddressLabelByKey("Address5");
            if (this.comm.GetMandatoryByKey("Address1").ToLower() != "true")
            {
                this.reqAddress1.Enabled = false;
                this.req_ShipAddress1.Enabled = false;
                this.lbl_ShipAdd1.Visible = false;
                this.lblAdd1.Visible = false;
            }
            else
            {
                this.reqAddress1.Enabled = true;
                this.req_ShipAddress1.Enabled = true;
                this.lbl_ShipAdd1.Visible = true;
                this.lblAdd1.Visible = true;
            }
            if (this.comm.GetMandatoryByKey("Address2").ToLower() != "true")
            {
                this.reqAddress2.Enabled = false;
                this.req_ShipAddress2.Enabled = false;
                this.lbl_ShipAdd2.Visible = false;
                this.lblAdd2.Visible = false;
            }
            else
            {
                this.reqAddress2.Enabled = true;
                this.req_ShipAddress2.Enabled = true;
                this.lbl_ShipAdd2.Visible = true;
                this.lblAdd2.Visible = true;
            }
            if (this.comm.GetMandatoryByKey("Address3").ToLower() != "true")
            {
                this.reqAddress3.Enabled = false;
                this.req_ShipAddress3.Enabled = false;
                this.lbl_ShipAdd3.Visible = false;
                this.lblAdd3.Visible = false;
            }
            else
            {
                this.reqAddress3.Enabled = true;
                this.req_ShipAddress3.Enabled = true;
                this.lbl_ShipAdd3.Visible = true;
                this.lblAdd3.Visible = true;
            }
            if (this.comm.GetMandatoryByKey("Address4").ToLower() != "true")
            {
                this.reqAddress4.Enabled = false;
                this.req_ShipAddress4.Enabled = false;
                this.lbl_ShipAdd4.Visible = false;
                this.lblAdd4.Visible = false;
            }
            else
            {
                this.reqAddress4.Enabled = true;
                this.req_ShipAddress4.Enabled = true;
                this.lbl_ShipAdd4.Visible = true;
                this.lblAdd4.Visible = true;
            }
            if (this.comm.GetMandatoryByKey("Address5").ToLower() != "true")
            {
                this.reqAddress5.Enabled = false;
                this.req_ShipAddress5.Enabled = false;
                this.lbl_ShipAdd5.Visible = false;
                this.lblAdd5.Visible = false;
            }
            else
            {
                this.reqAddress5.Enabled = true;
                this.req_ShipAddress5.Enabled = true;
                this.lbl_ShipAdd5.Visible = true;
                this.lblAdd5.Visible = true;
            }
            this.lbl_ShipAddress1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lbl_ShipAddress2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lbl_ShipCity.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lbl_ShipState.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lbl_ShipZipCode.Text = this.comm.GetAddressLabelByKey("Address5");
            base.Title = commonclass.pageTitle("Create Account", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
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
            this.txtCompanyName.Focus();
            this.AccountType = this.comm.return_AccountType(this.CompanyID, this.AccountID);
            if (this.Session["StoreUserID"] != null || !(this.AccountType == "x"))
            {
                this.txt_firstName.Focus();
            }
            else
            {
                this.txtCompanyName.Focus();
            }
            foreach (DataRow dataRow in LoginBasePage.Select_AccountDetails(this.CompanyID, this.AccountID).Rows)
            {
                this.AccountType = dataRow["accountType"].ToString();
                this.DateFormat = dataRow["DateFormat"].ToString();
                this.ClientName = dataRow["clientName"].ToString();
                this.PostCode = dataRow["PostCode"].ToString();
            }
            if (this.AccountType == "p")
            {
                this.txtCompanyName.Text = this.ClientName;
                this.txtCompanyName.ReadOnly = true;
            }
            this.NewSessionID = this.comm.UniqueID;
            if (base.Request.QueryString["from"] != null)
            {
                this.Frompage = base.Request.QueryString["from"].ToString();
            }
        }
    }
}