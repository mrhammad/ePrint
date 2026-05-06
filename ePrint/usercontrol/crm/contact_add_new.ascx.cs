using nmsCommon;
using nmsConnectionClass;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using Sample.Web.UI.Compatibility;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.crm
{
    public partial class contact_add_new : System.Web.UI.UserControl
    {
        //protected ScriptManagerProxy SMP;

        protected HiddenField hdnsystemname = new HiddenField();

        //protected Label Label35;

        //protected Label Label2;

        //protected TextBox txtCompanyName;

        //protected HiddenField hdnAddress;

        //protected HiddenField hdnClientID;

        //protected HtmlGenericControl div_Autocomplete;

        //protected Label Label3;

        //protected Label lbl_CompanyType;

        //protected HiddenField hid_CompanyType;

        //protected HtmlGenericControl div_CompanyType;

        //protected Label Label4;

        //protected TextBox txtTitle;

        //protected Label Label5;

        //protected TextBox txtFirstName;

        //protected Label Label6;

        //protected TextBox txtMiddleName;

        //protected Label Label7;

        //protected TextBox txtLastName;

        //protected Label lbl_Department;

        //protected ImageButton ImageButton1;

        //protected HtmlGenericControl DivDepartment;

        //protected TextBox txtDepartment;

        //protected DropDownList ddlDepartment;

        //protected HiddenField hdnDeptID;

        //protected Label Label10;

        //protected ImageButton ImageButton2;

        //protected HtmlGenericControl DivContactImage=new HtmlGenericControl();

        //protected Label lbl_ContactAddressDetails;

        //protected Label Label12;

        //protected Label lbl_DeliveryAddressDetails;

        //protected HiddenField hdn_ContactAddressDetails;

        //protected HiddenField hdn_DeliveryAddressDetails;

        //protected HiddenField hdn_InvoiceAddressDetails;

        //protected Label Label14;

        //protected Label lbl_InvoiceAddressDetails;

        //protected Label lbl_b2b;

        //protected CheckBox chkB2bLogin;

        //protected CheckBox chkB2bLoginChngPass;

        //protected Label Label8;

        //protected HtmlGenericControl div_Password;

        //protected Label Label33;

        //protected TextBox txtPassword;

        //protected Label Label39;

        //protected TextBox txtConfirmPassword;

        //protected HtmlGenericControl div_PasswordArea;

        //protected HtmlGenericControl div_B2bLogin;

        //protected CheckBox chkLoginEmail;

        //protected HtmlGenericControl div_LoginEmail;

        //protected CheckBox ChkSubscribeduser;

        //protected HtmlGenericControl div1;

        //protected CheckBox chkReceiveMailOut;

        //protected HtmlGenericControl divMailOut;

        //protected Label Label11;

        //protected TextBox txtJobTitle;

        protected Label lblJobTitle2 = new Label();

        protected TextBox txtJobTitle2 = new TextBox();

        //protected Label lbl_ContactEmail;

        //protected TextBox txt_ContactEmail;

        //protected UpdatePanel up1;

        //protected Label Label1;

        //protected TextBox txtContactMobile;

        //protected Label Label28;

        //protected TextBox txtHomePhone;

        //protected Label Label9;

        //protected TextBox txtPersonalFax;

        //protected Label lblAlternate;

        //protected TextBox txtAlternateNumber;

        //protected Label lblImageUpload=new Label();

        //protected Sample.Web.UI.Compatibility.CustomValidator CustomValidator1;

        protected FileUpload ImageUpload = new FileUpload();

        //protected HtmlAnchor FileTextClear;

        //protected HtmlGenericControl DivClear;

        protected Label lblContactImage = new Label();

        protected HtmlGenericControl ContactImage = new HtmlGenericControl();

        //protected Label lblImgguidance;

        //protected Label Label16;

        //protected Label Label17;

        //protected Label Label18;

        //protected Label Label13;

        //protected CheckBox chkMainApprover;

        //protected HtmlGenericControl DivMainApprover;

        //protected Label lblcustom1;

        //protected TextBox txtc1;

        //protected Label lblcustom9;

        //protected TextBox txtc9;

        //protected Label lblcustom2;

        //protected TextBox txtc2;

        //protected Label lblcustom10;

        //protected TextBox txtc10;

        //protected Label lblcustom3;

        //protected TextBox txtc3;

        //protected Label lblcustom11;

        //protected TextBox txtc11;

        //protected Label lblcustom4;

        //protected TextBox txtc4;

        //protected Label lblcustom12;

        //protected TextBox txtc12;

        //protected Label lblcustom5;

        //protected TextBox txtc5;

        //protected Label lblcustom13;

        //protected TextBox txtc13;

        //protected Label lblcustom6;

        //protected TextBox txtc6;

        //protected Label lblcustom14;

        //protected TextBox txtc14;

        //protected Label lblcustom7;

        //protected TextBox txtc7;

        //protected Label lblcustom15;

        //protected TextBox txtc15;

        //protected Label lblcustom8;

        //protected TextBox txtc8;

        //protected Button btnCancel;

        //protected HtmlGenericControl div_cancel;

        //protected Button btnSave;

        //protected HtmlGenericControl DivSAve;

        //protected LinkButton lnk_redirect;

        //protected HtmlInputHidden hid_ClientID;

        //protected HiddenField hid_ContactID;

        protected HiddenField hid_Mainapprovercount = new HiddenField();

        protected HiddenField hid_type = new HiddenField();

        protected HiddenField hid_ContactImage = new HiddenField();

        protected HiddenField hid_Actualfilename = new HiddenField();

        protected HiddenField hid_Originalfilename = new HiddenField();

        protected HiddenField hid_IsProccessed = new HiddenField();

        //protected RadWindowManager RadWindowManager2;

        //protected HiddenField hdnAddressID;

        //protected HiddenField hdnPassword;

        //protected HiddenField hdnContactAddressID;

        //protected HiddenField hdnShippingAddressID;

        //protected Panel pnlcopyAddress;

        //protected usercontrol_settings_loading_ascx ucLoading;

        //protected Panel pnlWinClose;

        //protected Panel pnlWinClose1;

        //protected Panel pnlContactClose;

        //protected Panel pnlContacts;

        //protected Panel pnlLoadContactPanel;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        private BaseClass objBase = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass comncls = new commonClass();

        private storeEmail Objemail = new storeEmail();

        public languageClass objLanguage = new languageClass();

        public bool ChkEmailDuplicacy;

        public int retContactID;

        public int CompanyID;

        public int UserID;

        public int ContactID;

        public int ClientID;

        public int NewDeptID;

        public int popuplevel;

        public long StoreUserID;

        public long AccountID;

        public long AddressID;

        public long DeliveryAddressID;

        public int ContactAddressID;

        public int CharLengthToDisplay = 40;

        public int id;

        public string wintype = string.Empty;

        public string pg = string.Empty;

        public string strFinalData = string.Empty;

        public string strRedirectUrl = string.Empty;

        public string CompanyType = string.Empty;

        public string DateFormat = string.Empty;

        public string BusinessAddressLine1 = string.Empty;

        public string BusinessAddressLine2 = string.Empty;

        public string BusinessAddressLine3 = string.Empty;

        public string BusinessAddressLine4 = string.Empty;

        public string BusinessCountry = string.Empty;

        public string PhoneNumbercopy = string.Empty;

        public string EmailCopy = string.Empty;

        public string FaxCopy = string.Empty;

        public static string strFinalContactData;

        public string CountryName = string.Empty;

        public string IsFromWebStore = string.Empty;

        public string mode = string.Empty;

        public string web_key = string.Empty;

        public string IsAddMode = string.Empty;

        public string action = string.Empty;

        public string item = string.Empty;

        public DataTable dt_Contact_MainApprover;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public DateTime CreatedDate;

        public string canChangetheContactAddress = "yes";

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public commonClass objcommon = new commonClass();

        public string SecureDocPath = global.SecureDocPath();

        public bool IsB2BEnabled;

        public DateTime TodaysDate;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static contact_add_new()
        {
            contact_add_new.strFinalContactData = string.Empty;
            contact_add_new.SalesPersonID = string.Empty;
            contact_add_new.IsEditOnlyHisRecords = string.Empty;
        }

        public contact_add_new()
        {
        }

        public void ArrangeAddress(string Address1, string Address2, string City, string State, string ZipCode, string Country, string Telephone, string Fax, string AddressLabel, string Email, string Mobile, string AddressTo)
        {
            if (AddressTo.ToLower() == "billing")
            {
                string[] address1 = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                string str = string.Concat(address1);
                str = (str.Trim().Length <= this.CharLengthToDisplay ? str.Trim() : str.Trim().Substring(0, this.CharLengthToDisplay));
                this.lbl_InvoiceAddressDetails.Text = str;
                this.hdn_InvoiceAddressDetails.Value = str;
                this.lbl_InvoiceAddressDetails.Style.Add("cursor", "pointer");
                Label lblInvoiceAddressDetails = this.lbl_InvoiceAddressDetails;
                string[] strArrays = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                lblInvoiceAddressDetails.ToolTip = string.Concat(strArrays);
                return;
            }
            if (AddressTo.ToLower() == "shipping")
            {
                string[] address11 = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                string str1 = string.Concat(address11);
                str1 = (str1.Trim().Length <= this.CharLengthToDisplay ? str1.Trim() : str1.Trim().Substring(0, this.CharLengthToDisplay));
                this.lbl_DeliveryAddressDetails.Text = str1;
                this.hdn_DeliveryAddressDetails.Value = str1;
                this.lbl_DeliveryAddressDetails.Style.Add("cursor", "pointer");
                Label lblDeliveryAddressDetails = this.lbl_DeliveryAddressDetails;
                string[] strArrays1 = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                lblDeliveryAddressDetails.ToolTip = string.Concat(strArrays1);
                return;
            }
            if (AddressTo.ToLower() == "contactaddress")
            {
                string[] address12 = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                string str2 = string.Concat(address12);
                str2 = (str2.Trim().Length <= this.CharLengthToDisplay ? str2.Trim() : str2.Trim().Substring(0, this.CharLengthToDisplay));
                this.lbl_ContactAddressDetails.Text = str2;
                this.hdn_ContactAddressDetails.Value = str2;
                this.lbl_ContactAddressDetails.Style.Add("cursor", "pointer");
                Label lblContactAddressDetails = this.lbl_ContactAddressDetails;
                string[] strArrays2 = new string[] { Address1, " ", Address2, " ", City, " ", State, " ", ZipCode, " ", Country };
                lblContactAddressDetails.ToolTip = string.Concat(strArrays2);
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (base.Request.Params["frm"] == null)
            {
                if (base.Request.Url.ToString().ToLower().Contains("contact/contact_add_main.aspx"))
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "contact/contact_view.aspx"));
                    return;
                }
                base.Response.Write("<script language='javascript' type='text/javascript'>window.close();</script>");
            }
            else if (base.Request.Params["frm"].ToString().ToLower() == "viewall")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "client/contact_view.aspx?clientid=", this.hid_ClientID.Value));
                return;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            this.ContactID = Convert.ToInt32(base.Request.Params["contactid"]);
            int num = 0;
            string empty = string.Empty;
            num = (!this.ChkSubscribeduser.Checked ? 0 : 1);
            if (ConnectionClass.ServerName != null)
            {
                empty = ConnectionClass.ServerName;
            }
            try
            {
                commonClass _commonClass = this.comncls;
                DateTime dateTime = DateTime.Now;
                this.TodaysDate = _commonClass.Eprint_return_ActualDate_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                commonClass _commonClass1 = this.comncls;
                string dateFormat = this.DateFormat;
                commonClass _commonClass2 = this.comncls;
                DateTime now1 = DateTime.Now;
                string str = _commonClass1.date_Check_new(dateFormat, _commonClass2.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true), this.CompanyID);
                this.CreatedDate = Convert.ToDateTime(str);
            }
            catch
            {
                this.CreatedDate = DateTime.Now;
            }
            int num1 = 0;
            num1 = (!this.chkReceiveMailOut.Checked ? 0 : 1);
            int num2 = 0;
            if (base.Request.Params["clientid"] != null)
            {
                num2 = Convert.ToInt32(base.Request.Params["clientid"].ToString());
            }
            string fileName = this.ImageUpload.FileName;
            string value = string.Empty;
            string empty1 = string.Empty;
            object[] secureDocPath = new object[] { this.SecureDocPath, "//", empty, "//", this.CompanyID, "//ContactImages//" };
            string.Concat(secureDocPath);
            bool flag = false;
            if (!this.ImageUpload.HasFile)
            {
                value = this.hid_Actualfilename.Value;
                fileName = this.hid_Originalfilename.Value;
                string[] strArrays = value.ToString().Trim().Split(new char[] { '.' });
                string[] strArrays1 = value.ToString().Trim().Split(new char[] { '.' });
                if (fileName != "" && strArrays1[1].ToString().Trim().ToLower() == "pdf")
                {
                    flag = true;
                }
                if (value != "" && this.hid_IsProccessed.Value.ToString().ToLower().Trim() == "true")
                {
                    value = string.Concat(strArrays[0], ".png");
                }
                this.hid_IsProccessed.Value = "";
                this.hid_Originalfilename.Value = "";
                this.hid_Actualfilename.Value = "";
            }
            else
            {
                string[] strArrays2 = this.ImageUpload.FileName.ToString().Trim().Split(new char[] { '.' });
                string[] strArrays3 = new string[] { strArrays2[0], "_", null, null, null };
                Guid guid = Guid.NewGuid();
                strArrays3[2] = guid.ToString().Substring(0, 5);
                strArrays3[3] = ".";
                strArrays3[4] = strArrays2[1];
                value = string.Concat(strArrays3);
                if (strArrays2[1].ToString().Trim().ToLower() == "pdf")
                {
                    flag = true;
                }
                object[] objArray = new object[] { this.SecureDocPath, "//", empty, "//", this.CompanyID, "//ContactImages" };
                if (!Directory.Exists(string.Concat(objArray)))
                {
                    object[] secureDocPath1 = new object[] { this.SecureDocPath, "//", empty, "//", this.CompanyID, "//ContactImages" };
                    Directory.CreateDirectory(string.Concat(secureDocPath1));
                }
                FileUpload imageUpload = this.ImageUpload;
                object[] objArray1 = new object[] { this.SecureDocPath, "//", empty, "//", this.CompanyID, "//ContactImages//", value };
                imageUpload.SaveAs(string.Concat(objArray1));
            }
            if (base.Request.Params["action"] == null)
            {
                if (this.hdnDeptID.Value == "")
                {
                    if (this.ddlDepartment.Items.Count <= 0)
                    {
                        this.hdnDeptID.Value = "0";
                    }
                    else
                    {
                        this.hdnDeptID.Value = this.ddlDepartment.SelectedItem.Value;
                    }
                }
                this.retContactID = CompanyBasePage.Contact_InsertUpdate(this.CompanyID, 0, Convert.ToInt32(this.hid_ClientID.Value), this.objBase.SpecialEncode(this.txtTitle.Text), this.objBase.SpecialEncode(this.txtFirstName.Text), this.objBase.SpecialEncode(this.txtMiddleName.Text), this.objBase.SpecialEncode(this.txtLastName.Text), "", this.objBase.SpecialEncode(this.txtCompanyName.Text), this.objBase.SpecialEncode(this.txtJobTitle.Text), this.objBase.SpecialEncode(this.txtJobTitle2.Text), this.objBase.SpecialEncode(this.txtHomePhone.Text), this.objBase.SpecialEncode(this.txtContactMobile.Text), this.objBase.SpecialEncode(this.txt_ContactEmail.Text), 0, this.UserID, Convert.ToInt64(this.hdnDeptID.Value), this.objBase.SpecialEncode(this.txtPersonalFax.Text), Convert.ToInt32(this.hdnContactAddressID.Value), this.chkMainApprover.Checked, num, num1, this.txtAlternateNumber.Text, this.objBase.SpecialEncode(this.txtc1.Text), this.objBase.SpecialEncode(this.txtc2.Text), this.objBase.SpecialEncode(this.txtc3.Text), this.objBase.SpecialEncode(this.txtc4.Text), this.objBase.SpecialEncode(this.txtc5.Text), this.objBase.SpecialEncode(this.txtc6.Text), this.objBase.SpecialEncode(this.txtc7.Text), this.objBase.SpecialEncode(this.txtc8.Text), this.objBase.SpecialEncode(this.txtc9.Text), this.objBase.SpecialEncode(this.txtc10.Text), this.objBase.SpecialEncode(this.txtc11.Text), this.objBase.SpecialEncode(this.txtc12.Text), this.objBase.SpecialEncode(this.txtc13.Text), this.objBase.SpecialEncode(this.txtc14.Text), this.objBase.SpecialEncode(this.txtc15.Text), value, fileName, flag, this.TodaysDate);
                if (this.hdnAddressID.Value != "")
                {
                    this.AddressID = Convert.ToInt64(this.hdnAddressID.Value);
                }
                if (this.hdnShippingAddressID.Value != "")
                {
                    this.DeliveryAddressID = Convert.ToInt64(this.hdnShippingAddressID.Value);
                }
                if (this.chkB2bLogin.Checked && this.CompanyType.ToLower() == "customer" && base.Request.Params["clientid"] != null)
                {
                    DataTable dataTable = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(base.Request.Params["clientid"].ToString()), "customer");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (Convert.ToInt64(row["AccountID"].ToString()) == (long)0)
                        {
                            continue;
                        }
                        this.StoreUserID = CompanyBasePage.Create_StoreUser((long)0, this.txtFirstName.Text, this.txtLastName.Text, this.objBase.SpecialEncode(this.txt_ContactEmail.Text), this.txtPassword.Text, (long)this.CompanyID, Convert.ToInt64(row["AccountID"].ToString()), "", row["clientName"].ToString(), num);
                        CompanyBasePage.Update_ContactID_ForB2B(this.StoreUserID, (long)Convert.ToInt32(this.hdnShippingAddressID.Value), (long)Convert.ToInt32(this.hdnShippingAddressID.Value), this.retContactID);
                        if (!this.chkLoginEmail.Checked)
                        {
                            continue;
                        }
                        this.Objemail.emailB2BRegisterDetails(this.StoreUserID, this.CompanyID, Convert.ToInt64(row["AccountID"].ToString()), "New B2B Contact Registration");
                    }
                }
            }
            else if (base.Request.Params["action"].ToString() == "edit" && base.Request.Params["contactid"] != null)
            {
                this.hid_ContactID.Value = base.Request.Params["contactid"].ToString();
                if (this.ddlDepartment.SelectedItem.Text.ToString().Equals("--- Select ---"))
                {
                    this.ddlDepartment.SelectedItem.Text = " ";
                }
                if (this.hdnShippingAddressID.Value == "")
                {
                    this.hdnShippingAddressID.Value = "0";
                }
                CompanyBasePage.Contact_InsertUpdate(this.CompanyID, Convert.ToInt32(base.Request.Params["contactid"].ToString()), num2, this.objBase.SpecialEncode(this.txtTitle.Text), this.objBase.SpecialEncode(this.txtFirstName.Text), this.objBase.SpecialEncode(this.txtMiddleName.Text), this.objBase.SpecialEncode(this.txtLastName.Text), this.objBase.SpecialEncode(string.Concat(this.txtFirstName.Text, " ", this.txtLastName.Text)), this.objBase.SpecialEncode(this.txtCompanyName.Text), this.objBase.SpecialEncode(this.txtJobTitle.Text), this.objBase.SpecialEncode(this.txtJobTitle2.Text), this.objBase.SpecialEncode(this.txtHomePhone.Text), this.objBase.SpecialEncode(this.txtContactMobile.Text), this.objBase.SpecialEncode(this.txt_ContactEmail.Text), 0, this.UserID, Convert.ToInt64(this.ddlDepartment.SelectedValue), this.objBase.SpecialEncode(this.txtPersonalFax.Text), Convert.ToInt32(this.hdnContactAddressID.Value), this.chkMainApprover.Checked, num, num1, this.txtAlternateNumber.Text, this.objBase.SpecialEncode(this.txtc1.Text), this.objBase.SpecialEncode(this.txtc2.Text), this.objBase.SpecialEncode(this.txtc3.Text), this.objBase.SpecialEncode(this.txtc4.Text), this.objBase.SpecialEncode(this.txtc5.Text), this.objBase.SpecialEncode(this.txtc6.Text), this.objBase.SpecialEncode(this.txtc7.Text), this.objBase.SpecialEncode(this.txtc8.Text), this.objBase.SpecialEncode(this.txtc9.Text), this.objBase.SpecialEncode(this.txtc10.Text), this.objBase.SpecialEncode(this.txtc11.Text), this.objBase.SpecialEncode(this.txtc12.Text), this.objBase.SpecialEncode(this.txtc13.Text), this.objBase.SpecialEncode(this.txtc14.Text), this.objBase.SpecialEncode(this.txtc15.Text), value, fileName, flag, this.TodaysDate);
                if (Convert.ToInt32(this.hid_ContactID.Value) != 0)
                {
                    DataTable dataTable1 = CompanyBasePage.company_contact_select(this.CompanyID, Convert.ToInt32(this.hid_ContactID.Value), Convert.ToInt32(this.hid_ClientID.Value));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.StoreUserID = Convert.ToInt64(dataRow["StoreUserID"].ToString());
                    }
                }
                if (this.CompanyType.ToLower() == "customer")
                {
                    foreach (DataRow row1 in CompanyBasePage.company_client_select(this.CompanyID, num2, "customer").Rows)
                    {
                        if (Convert.ToInt64(row1["AccountID"].ToString()) == (long)0)
                        {
                            continue;
                        }
                        if (this.StoreUserID != (long)0)
                        {
                            if (this.txtPassword.Text == "")
                            {
                                this.txtPassword.Text = this.hdnPassword.Value;
                            }
                            this.StoreUserID = CompanyBasePage.Create_StoreUser(this.StoreUserID, this.objBase.SpecialEncode(this.txtFirstName.Text), this.objBase.SpecialEncode(this.txtLastName.Text), this.objBase.SpecialEncode(this.txt_ContactEmail.Text), this.txtPassword.Text, (long)this.CompanyID, Convert.ToInt64(row1["AccountID"].ToString()), "FromContactUpdate", "", num);
                        }
                        if (this.StoreUserID == (long)0 || !this.chkB2bLoginChngPass.Checked)
                        {
                            if (!this.chkB2bLogin.Checked)
                            {
                                continue;
                            }
                            this.StoreUserID = CompanyBasePage.Create_StoreUser((long)0, this.objBase.SpecialEncode(this.txtFirstName.Text), this.objBase.SpecialEncode(this.txtLastName.Text), this.objBase.SpecialEncode(this.txt_ContactEmail.Text), this.txtPassword.Text, (long)this.CompanyID, Convert.ToInt64(row1["AccountID"].ToString()), "", row1["clientName"].ToString(), num);
                            CompanyBasePage.Update_ContactID_ForB2B(this.StoreUserID, (long)Convert.ToInt32(this.hdnShippingAddressID.Value), (long)Convert.ToInt32(this.hdnShippingAddressID.Value), Convert.ToInt32(this.hid_ContactID.Value));
                            if (!this.chkLoginEmail.Checked)
                            {
                                continue;
                            }
                            this.Objemail.emailB2BRegisterDetails(this.StoreUserID, this.CompanyID, Convert.ToInt64(row1["AccountID"].ToString()), "Password Reminder Email");
                        }
                        else
                        {
                            if (!this.chkLoginEmail.Checked)
                            {
                                continue;
                            }
                            bool flag1 = false;
                            DataTable customerSelect = WebstoreBasePage.EmailToCustomer_Select(this.CompanyID, Convert.ToInt32(row1["AccountID"].ToString()), (long)0, "Password Reminder Email", "Customer");
                            foreach (DataRow dataRow1 in customerSelect.Rows)
                            {
                                flag1 = Convert.ToBoolean(dataRow1["IsActive"]);
                            }
                            if (!flag1)
                            {
                                continue;
                            }
                            this.Objemail.emailB2BRegisterDetails(this.StoreUserID, this.CompanyID, Convert.ToInt64(row1["AccountID"].ToString()), "Password Reminder Email");
                        }
                    }
                }
            }
            if (base.Request.Params["wintype"] != null)
            {
                if (base.Request.Params["action"] == null)
                {
                    if (base.Request.Params["wintype"] == "main")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "contact/contact_view.aspx"));
                        return;
                    }
                    QueryString queryString = new QueryString()
				{
					{ "clientid", this.hdnClientID.Value },
					{ "isnew", "2" },
					{ "bypass", "1" },
					{ "type", "Customer" }
				};
                    string str1 = string.Concat(this.strSitepath, "client/client_detail.aspx");
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    str1 = string.Concat(str1, queryString1.ToString());
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", str1, "';</script>"));
                    return;
                }
                if (base.Request.Params["wintype"] == "main")
                {
                    object[] objArray2 = new object[] { this.strSitepath, "/contact/contact_view.aspx?action=edit&clientid=", Convert.ToInt32(this.hid_ClientID.Value), "&contactid=", this.ContactID, "&type=", this.CompanyType, "&wintype=main" };
                    this.strRedirectUrl = string.Concat(objArray2);
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", this.strRedirectUrl, "';</script>"));
                    return;
                }
                if (base.Request.Params["wintype"].ToLower() == "contactview")
                {
                    this.strRedirectUrl = string.Concat(this.strSitepath, "contact/contact_view.aspx");
                    base.Response.Write(string.Concat("<script language='javascript' type='text/javascript'>window.close();parent.window.location.href='", this.strRedirectUrl, "';</script>"));
                    return;
                }
                if (base.Request.Params["wintype"].ToLower() == "crm")
                {
                    base.Session["IsEditContact"] = "yes2";
                    if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                    {
                        this.pnlLoadContactPanel.Visible = true;
                        return;
                    }
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetRadWindow().BrowserWindow.location.reload();Close();", true);
                    return;
                }
            }
            else if (base.Request.Params["pg"] == null)
            {
                if (base.Request.Browser.Type.ToUpper().Contains("IE"))
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetRadWindow().BrowserWindow.location.reload();Close();", true);
                    return;
                }
                this.pnlLoadContactPanel.Visible = true;
            }
            else
            {
                if (base.Request.Params["pg"].Trim().Length <= 0)
                {
                    if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                    {
                        this.pnlLoadContactPanel.Visible = true;
                        return;
                    }
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetRadWindow().BrowserWindow.location.reload();Close();", true);
                    return;
                }
                string empty2 = string.Empty;
                if (base.Request.Params["clientid"] != null)
                {
                    DataTable dataTable2 = new DataTable();
                    if (base.Request.Params["pg"].ToString().ToLower() != "client")
                    {
                        dataTable2 = this.objComp.company_contacts_select(this.CompanyID, Convert.ToInt32(base.Request.Params["clientid"].ToString()), "");
                        foreach (DataRow row2 in dataTable2.Rows)
                        {
                            string str2 = row2["ContactName"].ToString();
                            string str3 = row2["ContactID"].ToString();
                            string[] strArrays4 = new string[] { empty2, str3, "±", this.objBase.SpecialEncode(str2), "µ" };
                            empty2 = string.Concat(strArrays4);
                        }
                    }
                }
                this.strFinalData = empty2;
                if (base.Request.Params["pg"].ToString().ToLower() == "estimate")
                {
                    if (base.Request.Params["mode"] == null)
                    {
                        this.strRedirectUrl = string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=", base.Request.Params["mode"].ToString().ToLower());
                        this.pnlWinClose.Visible = true;
                        return;
                    }
                    if (base.Request.Params["mode"].ToString().ToLower() == "edit")
                    {
                        this.strRedirectUrl = string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=", base.Request.Params["mode"].ToString().ToLower());
                        this.pnlWinClose.Visible = true;
                        return;
                    }
                    this.strRedirectUrl = string.Concat(this.strSitepath, "estimates/estimates_add.aspx?type=", base.Request.Params["mode"].ToString().ToLower());
                    this.pnlWinClose.Visible = true;
                    return;
                }
                if (base.Request.Params["pg"].ToString().ToLower() == "customer")
                {
                    if (base.Request.Params["mode"].ToString().ToLower() == "add")
                    {
                        this.pnlWinClose1.Visible = true;
                        return;
                    }
                }
                else if (base.Request.Params["pg"].ToString().ToLower() != "purchase")
                {
                    if (base.Request.Params["pg"].ToString().ToLower() == "deliverynote")
                    {
                        this.strRedirectUrl = string.Concat(this.strSitepath, "delivery/delivery_add.aspx");
                        this.pnlWinClose.Visible = true;
                        return;
                    }
                    if (base.Request.Params["pg"].ToString().ToLower() != "estimates" && base.Request.Params["pg"].ToString().ToLower() != "jobs" && base.Request.Params["pg"].ToString().ToLower() != "invoice")
                    {
                        if (base.Request.Params["pg"].ToString().ToLower() == "client")
                        {
                            base.Session["IsAddedContact"] = "yes1";
                            if (!base.Request.Browser.Type.ToUpper().Contains("IE"))
                            {
                                this.pnlLoadContactPanel.Visible = true;
                                return;
                            }
                            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetRadWindow().BrowserWindow.location.reload();Close();", true);
                            return;
                        }
                    }
                    else if (base.Request.Params["item"] != null && base.Request.Params["item"].ToString().ToLower() == "outwork")
                    {
                        string[] str4 = new string[] { this.retContactID.ToString(), "~", base.Request.Params["id"].ToString(), "~", this.objBase.SpecialEncode(this.txtFirstName.Text), " ", this.objBase.SpecialEncode(this.txtLastName.Text) };
                        contact_add_new.strFinalContactData = string.Concat(str4);
                        this.pnlContactClose.Visible = true;
                        return;
                    }
                }
                else if (base.Request.Params["mode"] != null && base.Request.Params["id"] != null)
                {
                    if (base.Request.Params["mode"].ToString().ToLower() != "edit")
                    {
                        this.strRedirectUrl = string.Concat(this.strSitepath, "purchase/purchase_add.aspx?type=", base.Request.Params["mode"].ToString().ToLower());
                        this.pnlWinClose.Visible = true;
                        return;
                    }
                    string[] lower = new string[] { this.strSitepath, "purchase/purchase_add.aspx?type=", base.Request.Params["mode"].ToString().ToLower(), "&id=", base.Request.Params["id"].ToString() };
                    this.strRedirectUrl = string.Concat(lower);
                    this.pnlWinClose.Visible = true;
                    return;
                }
            }
        }

        protected void lnk_ContactChange_Click(object sender, EventArgs e)
        {
            this.StoreOldData();
            if (base.Request.Params["action"] != null)
            {
                if (base.Request.Params["action"] == "edit")
                {
                    if (base.Request.Params["wintype"] == null)
                    {
                        HttpResponse response = base.Response;
                        string[] value = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&pagename=ContactAddress&action=edit&from=contacteditmode_ch&ContactID=", this.hid_ContactID.Value };
                        response.Redirect(string.Concat(value));
                        return;
                    }
                    if (base.Request.Params["wintype"].ToString().ToLower() == "contactview")
                    {
                        HttpResponse httpResponse = base.Response;
                        string[] strArrays = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&pagename=ContactAddress&action=edit&from=contacteditmode_ch&ContactID=", this.hid_ContactID.Value, "&wintype=", this.wintype };
                        httpResponse.Redirect(string.Concat(strArrays));
                        return;
                    }
                    HttpResponse response1 = base.Response;
                    string[] value1 = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&pagename=ContactAddress&action=edit&from=contacteditmode_ch&ContactID=", this.hid_ContactID.Value, "&wintype=", this.wintype };
                    response1.Redirect(string.Concat(value1));
                    return;
                }
            }
            else if (base.Request.Params["pg"] == null)
            {
                HttpResponse httpResponse1 = base.Response;
                string[] strArrays1 = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&pagename=ContactAddress&action=add&from=contacteditmode_edit&ContactID=", this.hid_ContactID.Value };
                httpResponse1.Redirect(string.Concat(strArrays1));
            }
            else
            {
                if (base.Request.Params["pg"].ToString().ToLower() == "estimate" || base.Request.Params["pg"].ToString().ToLower() == "estimates" || base.Request.Params["pg"].ToString().ToLower() == "job" || base.Request.Params["pg"].ToString().ToLower() == "jobs" || base.Request.Params["pg"].ToString().ToLower() == "invoice" || base.Request.Params["pg"].ToString().ToLower() == "invoice")
                {
                    HttpResponse response2 = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", base.Request.Params["pg"].ToString().ToLower(), "&pagename=ContactAddress&action=add&from=contacteditmode_edit&ContactID=", this.hid_ContactID.Value, "&item=", this.item, "&id=", this.id };
                    response2.Redirect(string.Concat(objArray));
                    return;
                }
                if (base.Request.Params["pg"].ToString().ToLower() == "client")
                {
                    HttpResponse httpResponse2 = base.Response;
                    string[] value2 = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&pagename=ContactAddress&action=add&from=contacteditmode_edit&ContactID=", this.hid_ContactID.Value };
                    httpResponse2.Redirect(string.Concat(value2));
                    return;
                }
                if (base.Request.Params["pg"].ToString().ToLower() == "deliverynote")
                {
                    HttpResponse response3 = base.Response;
                    string[] strArrays2 = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", base.Request.Params["pg"].ToString().ToLower(), "&pagename=ContactAddress&action=add&from=contacteditmode_edit&ContactID=", this.hid_ContactID.Value };
                    response3.Redirect(string.Concat(strArrays2));
                    return;
                }
                if (base.Request.Params["pg"].ToString().ToLower() == "purchase")
                {
                    HttpResponse httpResponse3 = base.Response;
                    string[] value3 = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=view&clientid=", this.hdnClientID.Value, "&pg=", base.Request.Params["pg"].ToString().ToLower(), "&pagename=ContactAddress&action=add&from=contacteditmode_edit&ContactID=", this.hid_ContactID.Value };
                    httpResponse3.Redirect(string.Concat(value3));
                    return;
                }
            }
        }

        protected void lnk_ContactEdit_Click(object sender, EventArgs e)
        {
            this.StoreOldData();
            if (base.Request.Params["action"] == null)
            {
                HttpResponse response = base.Response;
                string[] value = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=add&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&action=add&pagename=Contact&from=contacteditmode_edit&addressid=", this.hdnContactAddressID.Value, "&ContactID=", this.hid_ContactID.Value };
                response.Redirect(string.Concat(value));
            }
            else if (base.Request.Params["action"] == "edit")
            {
                HttpResponse httpResponse = base.Response;
                string[] strArrays = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreaddress&mode=edit&clientid=", this.hdnClientID.Value, "&pg=", this.pg, "&action=edit&pagename=Contact&from=contacteditmode_edit&addressid=", this.hdnContactAddressID.Value, "&ContactID=", this.hid_ContactID.Value };
                httpResponse.Redirect(string.Concat(strArrays));
                return;
            }
        }

        protected void lnk_redirect_Click(object sender, EventArgs e)
        {
            this.StoreOldData();
            if (base.Request.Params["action"] == null)
            {
                HttpResponse response = base.Response;
                object[] value = new object[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&clientid=", this.hdnClientID.Value, "&mode=add&pg=", this.pg, "&companytype=", this.CompanyType, "&Pgtype=", this.pg, "&from=newcontact&parentpage=newcontact&popuplevel=2&item=", this.item, "&id=", this.id };
                response.Redirect(string.Concat(value));
            }
            else if (base.Request.Params["action"] == "edit")
            {
                HttpResponse httpResponse = base.Response;
                string[] strArrays = new string[] { this.strSitepath, "common/common_popup.aspx?type=moreDept&clientid=", this.hdnClientID.Value, "&ContactID=", this.hid_ContactID.Value, "&mode=", base.Request.Params["action"].ToString(), "&pg=", this.pg, "&companytype=", this.CompanyType, "&Pgtype=", this.pg, "&from=editcontact&parentpage=editcontact&popuplevel=2&wintype=", this.wintype };
                httpResponse.Redirect(string.Concat(strArrays));
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerator enumerator;
            this.hdnsystemname.Value = ConnectionClass.ServerName.ToString();
            BaseClass baseClass = new BaseClass();
            if (base.Request.Params["pg"] != null)
            {
                this.pg = base.Request.Params["pg"].ToString();
            }
            if (base.Request.Params["mode"] != null)
            {
                this.mode = base.Request.Params["mode"].ToString();
            }
            if (base.Request.Params["item"] != null)
            {
                this.item = base.Request.Params["item"].ToString().ToLower().Trim();
            }
            if (base.Request.Params["id"] != null)
            {
                this.id = Convert.ToInt32(base.Request.Params["id"]);
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"]);
            this.DateFormat = base.Session["DateFormat"].ToString();
            if (base.Request.Params["contactid"] != null)
            {
                this.ContactID = Convert.ToInt32(base.Request.Params["contactid"].ToString());
                this.hid_ContactID.Value = base.Request.Params["contactid"].ToString();
            }
            if (base.Request.Params["newdept"] != null)
            {
                this.NewDeptID = Convert.ToInt32(base.Request.Params["newdept"].ToString());
                base.Response.Write(base.Session["Contact"]);
                if (base.Session["Contact"] != null)
                {
                    DataTable item = (DataTable)base.Session["Contact"];
                    if (item != null)
                    {
                        foreach (DataRow row in item.Rows)
                        {
                            row["DeptID"] = this.NewDeptID;
                        }
                    }
                }
            }
            if (base.Request.Params["type"] != null)
            {
                this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
                this.hdnClientID.Value = base.Request.Params["clientid"].ToString();
                this.hid_ClientID.Value = base.Request.Params["clientid"].ToString();
                this.CompanyType = base.Request.Params["type"].ToString();
            }
            if (this.hdnsystemname.Value != "fsg")
            {
                this.Label4.Text = this.objLangClass.GetLanguageConversion("Title");
                this.Label7.Text = this.objLangClass.GetLanguageConversion("Last_Name");
                this.Label11.Text = this.objLangClass.GetLanguageConversion("Job_Title1");
                this.lblJobTitle2.Text = this.objLangClass.GetLanguageConversion("Job_Title2");
                this.Label28.Text = this.objLangClass.GetLanguageConversion("Phone");
                this.lbl_ContactEmail.Text = this.objLangClass.GetLanguageConversion("Email");
            }
            else
            {
                this.Label4.Text = string.Concat(this.objLangClass.GetLanguageConversion("Title"), "<span style='color: red;'>&nbsp;*</span>");
                this.Label7.Text = string.Concat(this.objLangClass.GetLanguageConversion("Last_Name"), "<span style='color: red;'>&nbsp;*</span>");
                this.Label11.Text = string.Concat(this.objLangClass.GetLanguageConversion("Job_Title1"), "<span style='color: red;'>&nbsp;*</span>");
                this.Label28.Text = string.Concat(this.objLangClass.GetLanguageConversion("Phone"), "<span style='color: red;'>&nbsp;*</span>");
                this.lbl_ContactEmail.Text = string.Concat(this.objLangClass.GetLanguageConversion("Email"), "<span style='color: red;'>&nbsp;*</span>");
                this.lblJobTitle2.Text = string.Concat(this.objLangClass.GetLanguageConversion("Job_Title2"), "<span style='color: red;'>&nbsp;*</span>");
            }
            if (base.Request.Params["action"] != null)
            {
                this.action = base.Request.Params["action"].ToString().ToLower().Trim();
                if (base.Request.Params["action"] == "edit")
                {
                    string str = base.Request.Params["contactid"];
                    this.ClientID = Convert.ToInt32(base.Request.Params["clientid"].ToString());
                    this.hid_ClientID.Value = base.Request.Params["clientid"].ToString();
                    this.div_Autocomplete.Style.Add("display", "none");
                    this.div_CompanyType.Style.Add("display", "none");
                }
            }
            if (base.Request.Params["contactaddressid"] != null)
            {
                this.ContactAddressID = Convert.ToInt32(base.Request.Params["contactaddressid"].ToString());
                this.hdnContactAddressID.Value = base.Request.Params["contactaddressid"].ToString();
                base.Session["canChangetheContactAddress"] = "no";
                DataTable dataTable = (DataTable)base.Session["Contact"];
                if (dataTable != null)
                {
                    foreach (DataRow contactAddressID in dataTable.Rows)
                    {
                        contactAddressID["ContactAddressID"] = this.ContactAddressID;
                    }
                }
            }
            if (base.Request.Params["popuplevel"] != null)
            {
                this.popuplevel = Convert.ToInt32(base.Request.Params["popuplevel"]);
            }
            if (!base.IsPostBack)
            {
                this.txtFirstName.Focus();
            }
            if (base.Request.Params["IsAddMode"] != null)
            {
                this.IsAddMode = base.Request.Params["IsAddMode"].ToString().ToLower().Trim();
            }
            this.hid_type.Value = "add";
            int num = 0;
            DataTable dataTable1 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.CompanyType);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                contact_add_new.SalesPersonID = dataRow["SalesPerson"].ToString();
                if (dataRow["companytype"].ToString().ToLower() != "customer")
                {
                    this.DivMainApprover.Visible = false;
                }
                else
                {
                    this.DivMainApprover.Visible = true;
                    DataTable dataTable2 = SettingsBasePage.Check_IsApprovalFeaturesOn(Convert.ToInt32(base.Session["companyID"].ToString()));
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        if (row1["IsApprovalFeaturesOn"].ToString().ToLower() != "false")
                        {
                            this.DivMainApprover.Visible = true;
                        }
                        else
                        {
                            this.DivMainApprover.Visible = false;
                        }
                    }
                }
                this.AccountID = Convert.ToInt64(dataRow["AccountID"]);
                this.IsFromWebStore = dataRow["IsFromWebStore"].ToString();
                if (this.AccountID == (long)0)
                {
                    this.IsB2BEnabled = false;
                    this.ChkEmailDuplicacy = false;
                }
                else
                {
                    this.IsB2BEnabled = true;
                }
                num++;
                if (this.AccountID != (long)0)
                {
                    this.div_B2bLogin.Style.Add("display", "block");
                }
                else
                {
                    this.div_B2bLogin.Style.Add("display", "none");
                }
            }
            string empty = string.Empty;
            contact_add_new.IsEditOnlyHisRecords = baseClass.ReturnRoles_Privileges_Others("editrecords");
            if (baseClass.ReturnRoles_Privileges_ForGrid("clients", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                this.DivDepartment.Visible = false;
                this.DivSAve.Visible = false;
                this.DivContactImage.Visible = false;
            }
            else if (contact_add_new.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != contact_add_new.SalesPersonID)
            {
                this.DivSAve.Visible = false;
            }
            if (num == 0)
            {
                if (dataTable1.Rows.Count != 0)
                {
                    this.div_B2bLogin.Style.Add("display", "block");
                }
                else
                {
                    this.div_B2bLogin.Style.Add("display", "none");
                }
            }
            if (base.Request.Params["wintype"] != null)
            {
                this.wintype = base.Request.Params["wintype"].ToString().ToLower();
            }
            if (!base.IsPostBack)
            {
                if (this.IsAddMode == "yes")
                {
                    base.Session["Contact"] = null;
                    base.Session["canChangetheContactAddress"] = null;
                }
                DataTable dataTable3 = DepartmentBaseClass.department_getDeptNameID(this.CompanyID, this.UserID, Convert.ToInt32(this.hid_ClientID.Value), (long)0);
                if (dataTable3.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable3.Rows.Count; i++)
                    {
                        dataTable3.Columns["DeptName"].ReadOnly = false;
                        dataTable3.Rows[i]["DeptName"] = this.objBase.SpecialDecode(dataTable3.Rows[i]["DeptName"].ToString());
                    }
                }
                this.ddlDepartment.DataSource = dataTable3;
                this.ddlDepartment.DataTextField = "DeptName";
                this.ddlDepartment.DataValueField = "DeptID";
                this.ddlDepartment.DataBind();
                this.txtCompanyName.AutoCompleteType = AutoCompleteType.None;
                this.txtCompanyName.Attributes.Add("autocomplete", "off");
                this.txtCompanyName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'all','", this.CompanyID, "','1',event);"));
                this.txtCompanyName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'all','", this.CompanyID, "','1',event);"));
                if (base.Request.Params["type"] != null)
                {
                    DataTable dataTable4 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(this.hid_ClientID.Value), this.CompanyType);
                    foreach (DataRow dataRow1 in dataTable4.Rows)
                    {
                        if (base.Request.Params["action"] != null)
                        {
                            this.AccountID = Convert.ToInt64(dataRow1["AccountID"]);
                        }
                        else
                        {
                            this.txtCompanyName.Text = dataRow1["ClientName"].ToString();
                            this.lbl_CompanyType.Text = dataRow1["CompanyType"].ToString();
                            int num1 = 0;
                            int num2 = 0;
                            string empty1 = string.Empty;
                            string str1 = string.Empty;
                            string empty2 = string.Empty;
                            this.hdnDeptID.Value = dataRow1["DeptID"].ToString();
                            DataSet deptAddressDetails = CompanyBasePage.GetDeptAddressDetails(this.CompanyID, Convert.ToInt32(dataRow1["DeptID"].ToString()));
                            foreach (DataRow row2 in deptAddressDetails.Tables[0].Rows)
                            {
                                this.hdnAddressID.Value = row2["InvoiceAddressID"].ToString();
                                this.ArrangeAddress(row2["Address"].ToString(), row2["AddressLine2"].ToString(), row2["City"].ToString(), row2["State"].ToString(), row2["ZipCode"].ToString(), row2["Country"].ToString(), row2["Telephone"].ToString(), row2["Fax"].ToString(), row2["AddressLabel"].ToString(), "", "", "billing");
                                num1++;
                            }
                            foreach (DataRow dataRow2 in deptAddressDetails.Tables[1].Rows)
                            {
                                this.hdnShippingAddressID.Value = dataRow2["DeliveryAddressID"].ToString();
                                this.hdnContactAddressID.Value = dataRow2["DeliveryAddressID"].ToString();
                                this.ArrangeAddress(dataRow2["Address"].ToString(), dataRow2["AddressLine2"].ToString(), dataRow2["City"].ToString(), dataRow2["State"].ToString(), dataRow2["ZipCode"].ToString(), dataRow2["Country"].ToString(), dataRow2["Telephone"].ToString(), dataRow2["Fax"].ToString(), dataRow2["AddressLabel"].ToString(), "", "", "shipping");
                                this.ArrangeAddress(dataRow2["Address"].ToString(), dataRow2["AddressLine2"].ToString(), dataRow2["City"].ToString(), dataRow2["State"].ToString(), dataRow2["ZipCode"].ToString(), dataRow2["Country"].ToString(), dataRow2["Telephone"].ToString(), dataRow2["Fax"].ToString(), dataRow2["AddressLabel"].ToString(), "", "", "contactaddress");
                                num2++;
                            }
                            if (num1 == 0)
                            {
                                this.ArrangeAddress("", "", "", "", "", "", "", "", "", "", "", "Billing");
                            }
                            if (num2 != 0)
                            {
                                continue;
                            }
                            this.ArrangeAddress("", "", "", "", "", "", "", "", "", "", "", "Shipping");
                        }
                    }
                }
                if (base.Request.Params["wintype"] == null)
                {
                    this.div_Autocomplete.Style.Add("display", "none");
                    this.div_CompanyType.Style.Add("display", "none");
                    if (base.Request.Params["action"] == null)
                    {
                        this.pnlcopyAddress.Visible = true;
                    }
                }
                else if (base.Request.Params["action"] != "edit")
                {
                    this.txtCompanyName.Focus();
                    this.wintype = "main";
                    this.div_Autocomplete.Style.Add("display", "block");
                    this.div_CompanyType.Style.Add("display", "block");
                    this.div_cancel.Style.Add("display", "block");
                }
                if (base.Request.Params["action"] == null)
                {
                    DataTable dataTable5 = CompanyBasePage.company_client_select(this.CompanyID, Convert.ToInt32(base.Request.Params["clientid"].ToString()), "customer");
                    this.hid_type.Value = "add";
                    foreach (DataRow row3 in dataTable5.Rows)
                    {
                        if (Convert.ToInt64(row3["AccountID"].ToString()) == (long)0)
                        {
                            this.div_B2bLogin.Style.Add("display", "none");
                            this.div_LoginEmail.Style.Add("display", "none");
                        }
                        else
                        {
                            this.div_B2bLogin.Style.Add("display", "block");
                            this.div_LoginEmail.Style.Add("display", "block");
                        }
                        this.ddlDepartment.SelectedValue = row3["DeptID"].ToString();
                        this.hdnDeptID.Value = row3["DeptID"].ToString();
                    }
                    if (this.IsFromWebStore.ToLower() == "store")
                    {
                        this.div_B2bLogin.Style.Add("display", "none");
                        this.div_LoginEmail.Style.Add("display", "none");
                        this.lbl_b2b.Text = "B2C ordering Portal";
                        this.chkB2bLogin.Style.Add("display", "none");
                        this.chkB2bLoginChngPass.Style.Add("display", "block");
                        this.chkB2bLoginChngPass.Text = "Allow this contact to change password for B2C ordering Portal";
                    }
                }
                else if (base.Request.Params["action"].ToString() == "edit")
                {
                    if (base.Request.Params["contactid"] != null)
                    {
                        this.ContactID = Convert.ToInt32(base.Request.Params["contactid"].ToString());
                        this.hid_ContactID.Value = this.ContactID.ToString();
                    }
                    if (this.ContactID != 0)
                    {
                        base.Session["canChangetheContactAddress"] = "no";
                        DataTable dataTable6 = CompanyBasePage.company_contact_select(this.CompanyID, this.ContactID, Convert.ToInt32(this.hid_ClientID.Value));
                        this.hid_type.Value = "edit";
                        foreach (DataRow dataRow3 in dataTable6.Rows)
                        {
                            if (base.Request.Params["wintype"] != null)
                            {
                                base.Request.Params["wintype"].ToString();
                                if (base.Request.Params["wintype"] != "crm" && base.Request.Params["wintype"] != "contactview" && base.Request.Params["wintype"] != "")
                                {
                                    this.div_CompanyType.Style.Add("display", "block");
                                    this.lbl_CompanyType.Text = dataRow3["CompanyType"].ToString();
                                    this.div_Autocomplete.Style.Add("display", "block");
                                    this.txtCompanyName.Text = dataRow3["CompanyName"].ToString();
                                }
                            }
                            this.txtTitle.Text = this.objBase.SpecialDecode(dataRow3["Salutation"].ToString());
                            this.txtFirstName.Text = this.objBase.SpecialDecode(dataRow3["FirstName"].ToString());
                            this.txtMiddleName.Text = this.objBase.SpecialDecode(dataRow3["MiddleName"].ToString());
                            this.txtLastName.Text = this.objBase.SpecialDecode(dataRow3["LastName"].ToString());
                            this.txtCompanyName.Text = this.objBase.SpecialDecode(dataRow3["CompanyName"].ToString());
                            this.txtJobTitle.Text = this.objBase.SpecialDecode(dataRow3["JobTitle"].ToString());
                            this.txtJobTitle2.Text = this.objBase.SpecialDecode(dataRow3["JobTitle2"].ToString());
                            this.txt_ContactEmail.Text = this.objBase.SpecialDecode(dataRow3["email"].ToString());
                            this.txtContactMobile.Text = this.objBase.SpecialDecode(dataRow3["mobile"].ToString());
                            this.txtHomePhone.Text = this.objBase.SpecialDecode(dataRow3["HomeTelephone"].ToString());
                            this.txtPersonalFax.Text = this.objBase.SpecialDecode(dataRow3["PersonalFax"].ToString());
                            this.txtAlternateNumber.Text = this.objBase.SpecialDecode(dataRow3["AlternateNumbers"].ToString());
                            this.hid_Mainapprovercount.Value = this.objBase.SpecialDecode(dataRow3["PendingApprovercount"].ToString());
                            this.hid_type.Value = string.Concat("edit", this.objBase.SpecialDecode(dataRow3["MainApprover"].ToString()));
                            this.txtc1.Text = this.objBase.SpecialDecode(dataRow3["CustomField1"].ToString());
                            this.txtc2.Text = this.objBase.SpecialDecode(dataRow3["CustomField2"].ToString());
                            this.txtc3.Text = this.objBase.SpecialDecode(dataRow3["CustomField3"].ToString());
                            this.txtc4.Text = this.objBase.SpecialDecode(dataRow3["CustomField4"].ToString());
                            this.txtc5.Text = this.objBase.SpecialDecode(dataRow3["CustomField5"].ToString());
                            this.txtc6.Text = this.objBase.SpecialDecode(dataRow3["CustomField6"].ToString());
                            this.txtc7.Text = this.objBase.SpecialDecode(dataRow3["CustomField7"].ToString());
                            this.txtc8.Text = this.objBase.SpecialDecode(dataRow3["CustomField8"].ToString());
                            this.txtc9.Text = this.objBase.SpecialDecode(dataRow3["CustomField9"].ToString());
                            this.txtc10.Text = this.objBase.SpecialDecode(dataRow3["CustomField10"].ToString());
                            this.txtc11.Text = this.objBase.SpecialDecode(dataRow3["CustomField11"].ToString());
                            this.txtc12.Text = this.objBase.SpecialDecode(dataRow3["CustomField12"].ToString());
                            this.txtc13.Text = this.objBase.SpecialDecode(dataRow3["CustomField13"].ToString());
                            this.txtc14.Text = this.objBase.SpecialDecode(dataRow3["CustomField14"].ToString());
                            this.txtc15.Text = this.objBase.SpecialDecode(dataRow3["CustomField15"].ToString());
                            if (dataRow3["ActualFileName"].ToString() != "")
                            {
                                this.hid_Actualfilename.Value = dataRow3["ActualFileName"].ToString();
                                this.hid_Originalfilename.Value = dataRow3["OriginalFileName"].ToString();
                                this.hid_IsProccessed.Value = dataRow3["IsProcessed"].ToString();
                                this.hid_ContactImage.Value = dataRow3["OriginalFileName"].ToString();
                                this.ImageUpload.Attributes.Add("style", "display:none");
                                this.ContactImage.Attributes.Add("style", "display:block");
                                this.ContactImage.Attributes.Add("style", "margin-top:22px");
                                QueryString queryString = new QueryString()
							{
								{ "doctype", "ContactImg" }
							};
                                Label label = this.lblContactImage;
                                string[] strArrays = new string[] { "<a href='", this.strSitepath, "DocManager.ashx", queryString.ToString().Trim(), "&filename=", dataRow3["ActualFileName"].ToString(), "' style='margin-right:20px;' target='_blank'>", dataRow3["OriginalFileName"].ToString(), "</a> <img src='../images/erase.png' onclick=RemoveImage(); title='Remove'>" };
                                label.Text = string.Concat(strArrays);
                                this.lblContactImage.ToolTip = dataRow3["OriginalFileName"].ToString();
                            }
                            if (dataRow3["subscribe_newsletter"].ToString().ToLower() != "true")
                            {
                                this.ChkSubscribeduser.Checked = false;
                            }
                            else
                            {
                                this.ChkSubscribeduser.Checked = true;
                            }
                            this.StoreUserID = (long)Convert.ToInt32(dataRow3["StoreUserID"].ToString());
                            if (!(dataRow3["MainApprover"].ToString() != "") || dataRow3["MainApprover"].ToString() == null)
                            {
                                this.chkMainApprover.Checked = false;
                            }
                            else
                            {
                                this.chkMainApprover.Checked = Convert.ToBoolean(dataRow3["MainApprover"].ToString());
                            }
                            if (dataRow3["IsReceiveMailOut"].ToString() != "True")
                            {
                                this.chkReceiveMailOut.Checked = false;
                            }
                            else
                            {
                                this.chkReceiveMailOut.Checked = true;
                            }
                            this.hdnPassword.Value = dataRow3["Password"].ToString();
                            this.chkB2bLoginChngPass.Checked = true;
                            this.div_PasswordArea.Style.Add("display", "none");
                            if (dataRow3["Password"].ToString() == "")
                            {
                                this.div_Password.Style.Add("display", "none");
                            }
                            else
                            {
                                this.div_Password.Style.Add("display", "block");
                            }
                            this.ContactAddressID = Convert.ToInt32(dataRow3["ContactAddressID"].ToString());
                            this.hdnContactAddressID.Value = dataRow3["ContactAddressID"].ToString();
                            this.hdnDeptID.Value = dataRow3["DepartmentID"].ToString();
                            DataTable dataTable7 = DepartmentBaseClass.department_getAllDetails(this.CompanyID, this.UserID, Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt64(this.hdnDeptID.Value));
                            foreach (DataRow row4 in dataTable7.Rows)
                            {
                                this.ddlDepartment.SelectedValue = row4["DeptID"].ToString();
                                this.hdnDeptID.Value = row4["DeptID"].ToString();
                                this.AddressID = Convert.ToInt64(row4["Addressid"].ToString());
                                this.hdnAddressID.Value = row4["Addressid"].ToString();
                                this.ArrangeAddress(row4["Address"].ToString(), row4["AddressLine2"].ToString(), row4["City"].ToString(), row4["State"].ToString(), row4["ZipCode"].ToString(), row4["Country"].ToString(), row4["Telephone"].ToString(), row4["Fax"].ToString(), "", "", "", "Billing");
                                this.hdnShippingAddressID.Value = row4["DeliveryAddressID"].ToString();
                                this.ArrangeAddress(row4["DeliveryAddress"].ToString(), row4["DeliveryAddressLine2"].ToString(), row4["DeliveryCity"].ToString(), row4["DeliveryState"].ToString(), row4["DeliveryZipCode"].ToString(), row4["DeliveryCountry"].ToString(), row4["DeliveryTelephone"].ToString(), row4["DeliveryFax"].ToString(), "", "", "", "Shipping");
                            }
                            DataTable dataTable8 = CompanyBasePage.address_select_For_Edit(this.CompanyID, this.ContactAddressID, this.UserID);
                            foreach (DataRow dataRow4 in dataTable8.Rows)
                            {
                                this.ArrangeAddress(dataRow4["Address"].ToString(), dataRow4["AddressLine2"].ToString(), dataRow4["City"].ToString(), dataRow4["State"].ToString(), dataRow4["ZipCode"].ToString(), dataRow4["Country"].ToString(), dataRow4["Telephone"].ToString(), dataRow4["Fax"].ToString(), dataRow4["AddressLabel"].ToString(), "", "", "ContactAddress");
                            }
                            if (this.AccountID == (long)0)
                            {
                                this.div_B2bLogin.Style.Add("display", "none");
                            }
                            else
                            {
                                this.StoreUserID = Convert.ToInt64(dataRow3["StoreUserID"].ToString());
                                if (this.StoreUserID != (long)0)
                                {
                                    this.div_B2bLogin.Style.Add("display", "block");
                                    this.chkB2bLogin.Style.Add("display", "none");
                                    this.chkB2bLoginChngPass.Style.Add("display", "none");
                                    this.div_LoginEmail.Style.Add("display", "block");
                                    this.chkLoginEmail.Style.Add("display", "block");
                                    this.hdnPassword.Value = dataRow3["Password"].ToString();
                                    if (this.IsFromWebStore.ToLower() != "store")
                                    {
                                        this.lbl_b2b.Text = "B2B Ordering Portal";
                                    }
                                    else
                                    {
                                        this.lbl_b2b.Text = "B2C Ordering Portal";
                                    }
                                }
                                else if (this.IsFromWebStore.ToLower() != "store")
                                {
                                    this.div_B2bLogin.Style.Add("display", "block");
                                    this.div_LoginEmail.Style.Add("display", "block");
                                    this.div_PasswordArea.Style.Add("display", "block");
                                }
                                else
                                {
                                    if (Convert.ToInt32(dataRow3["StoreContactID"].ToString()) != this.ContactID)
                                    {
                                        continue;
                                    }
                                    this.div_B2bLogin.Style.Add("display", "block");
                                    this.lbl_b2b.Text = "B2C Ordering Portal";
                                    this.chkB2bLogin.Style.Add("display", "none");
                                    this.chkB2bLoginChngPass.Style.Add("display", "block");
                                    this.chkB2bLoginChngPass.Text = "Allow this contact to change password for B2C ordering Portal";
                                }
                            }
                        }
                    }
                }
                if (base.Session["canChangetheContactAddress"] != null)
                {
                    this.canChangetheContactAddress = base.Session["canChangetheContactAddress"].ToString();
                }
                if (base.Session["Contact"] != null)
                {
                    foreach (DataRow row5 in ((DataTable)base.Session["Contact"]).Rows)
                    {
                        this.txtTitle.Text = row5["Title"].ToString();
                        this.txtFirstName.Text = row5["FirstName"].ToString();
                        this.txtMiddleName.Text = row5["MiddleName"].ToString();
                        this.txtLastName.Text = row5["LastName"].ToString();
                        this.ddlDepartment.SelectedValue = row5["Department"].ToString();
                        this.txtJobTitle.Text = row5["JobTitle"].ToString();
                        this.txtJobTitle2.Text = row5["JobTitle2"].ToString();
                        this.txt_ContactEmail.Text = row5["Email"].ToString();
                        this.txtContactMobile.Text = row5["Mobile"].ToString();
                        this.txtHomePhone.Text = row5["Phone"].ToString();
                        this.txtPersonalFax.Text = row5["Fax"].ToString();
                        this.txtAlternateNumber.Text = row5["AlternateNumbers"].ToString();
                        if (!(row5["MainApprover"].ToString() != "") || row5["MainApprover"].ToString() == null)
                        {
                            this.chkMainApprover.Checked = false;
                        }
                        else
                        {
                            this.chkMainApprover.Checked = Convert.ToBoolean(row5["MainApprover"].ToString());
                        }
                        if (this.NewDeptID != 0)
                        {
                            this.ddlDepartment.SelectedValue = this.NewDeptID.ToString();
                        }
                        else if (row5["DeptID"] != null && row5["DeptID"].ToString().Length > 0)
                        {
                            this.NewDeptID = Convert.ToInt32(row5["DeptID"].ToString());
                        }
                        this.hdnContactAddressID.Value = row5["ContactAddressID"].ToString();
                        this.hdnDeptID.Value = this.NewDeptID.ToString();
                        DataTable dataTable9 = CompanyBasePage.address_select_For_Edit(this.CompanyID, Convert.ToInt32(row5["ContactAddressID"].ToString()), this.UserID);
                        foreach (DataRow dataRow5 in dataTable9.Rows)
                        {
                            this.ArrangeAddress(dataRow5["Address"].ToString(), dataRow5["AddressLine2"].ToString(), dataRow5["City"].ToString(), dataRow5["State"].ToString(), dataRow5["ZipCode"].ToString(), dataRow5["Country"].ToString(), dataRow5["Telephone"].ToString(), dataRow5["Fax"].ToString(), dataRow5["AddressLabel"].ToString(), "", "", "ContactAddress");
                        }
                        DataSet dataSet = CompanyBasePage.GetDeptAddressDetails(this.CompanyID, Convert.ToInt32(this.hdnDeptID.Value));
                        foreach (DataRow row6 in dataSet.Tables[0].Rows)
                        {
                            this.hdnAddressID.Value = row6["InvoiceAddressID"].ToString();
                            this.ArrangeAddress(row6["Address"].ToString(), row6["AddressLine2"].ToString(), row6["City"].ToString(), row6["State"].ToString(), row6["ZipCode"].ToString(), row6["Country"].ToString(), row6["Telephone"].ToString(), row6["Fax"].ToString(), row6["AddressLabel"].ToString(), "", "", "Billing");
                        }
                        foreach (DataRow dataRow6 in dataSet.Tables[1].Rows)
                        {
                            this.hdnShippingAddressID.Value = dataRow6["DeliveryAddressID"].ToString();
                            this.ArrangeAddress(dataRow6["Address"].ToString(), dataRow6["AddressLine2"].ToString(), dataRow6["City"].ToString(), dataRow6["State"].ToString(), dataRow6["ZipCode"].ToString(), dataRow6["Country"].ToString(), dataRow6["Telephone"].ToString(), dataRow6["Fax"].ToString(), dataRow6["AddressLabel"].ToString(), "", "", "Shipping");
                            if (this.canChangetheContactAddress.Trim().ToLower() == "no")
                            {
                                continue;
                            }
                            this.hdnContactAddressID.Value = dataRow6["DeliveryAddressID"].ToString();
                            this.ArrangeAddress(dataRow6["Address"].ToString(), dataRow6["AddressLine2"].ToString(), dataRow6["City"].ToString(), dataRow6["State"].ToString(), dataRow6["ZipCode"].ToString(), dataRow6["Country"].ToString(), dataRow6["Telephone"].ToString(), dataRow6["Fax"].ToString(), dataRow6["AddressLabel"].ToString(), "", "", "ContactAddress");
                        }
                    }
                }
            }
            base.Session["Contact"] = null;
            this.SetLabelAddress();
            this.btnSave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.chkB2bLogin.Text = this.objLangClass.GetLanguageConversion("Allow_This_Contact_To_Login_To_B2B_Ordering_Portal");
            this.chkLoginEmail.Text = this.objLangClass.GetLanguageConversion("Email_Info_To_User");
            this.chkReceiveMailOut.Text = this.objLangClass.GetLanguageConversion("Receive_Mail_Out");
            this.ChkSubscribeduser.Text = this.objLangClass.GetLanguageConversion("Subscribed_user");
            CompanyBasePage companyBasePage = new CompanyBasePage();
            this.dt_Contact_MainApprover = companyBasePage.company_contacts_select(this.CompanyID, this.ClientID, "no");
            if (this.dt_Contact_MainApprover.Rows.Count == 0)
            {
                this.chkMainApprover.Checked = true;
                this.chkMainApprover.Enabled = false;
            }
            enumerator = this.dt_Contact_MainApprover.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.hid_Mainapprovercount.Value = current["PendingApprovercount"].ToString();
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            this.txtPassword.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnSave.ClientID, "');"));
            this.txtConfirmPassword.Attributes.Add("onkeypress", string.Concat("javascript:KeyDownHandler(event,'", this.btnSave.ClientID, "');"));
            DataTable dataTable10 = new DataTable();
            dataTable10 = CompanyBasePage.ContactCustomFields_ScreenName_Select((long)this.CompanyID);
            int num3 = 1;
            foreach (DataRow row7 in dataTable10.Rows)
            {
                Label label1 = (Label)this.FindControl(string.Concat("lblcustom", num3));
                label1.Text = this.objBase.SpecialDecode(row7["ScreenName"].ToString());
                num3++;
            }
        }

        public void SetLabelAddress()
        {
            this.lbl_InvoiceAddressDetails.Text = this.objBase.SpecialDecode(this.hdn_InvoiceAddressDetails.Value);
            this.lbl_DeliveryAddressDetails.Text = this.objBase.SpecialDecode(this.hdn_DeliveryAddressDetails.Value);
            this.lbl_ContactAddressDetails.Text = this.objBase.SpecialDecode(this.hdn_ContactAddressDetails.Value);
        }

        public void StoreOldData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("MiddleName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("JobTitle", typeof(string));
            dataTable.Columns.Add("JobTitle2", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Mobile", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Fax", typeof(string));
            dataTable.Columns.Add("ClientID", typeof(string));
            dataTable.Columns.Add("ContactID", typeof(string));
            dataTable.Columns.Add("ContactAddressID", typeof(string));
            dataTable.Columns.Add("DeptID", typeof(string));
            dataTable.Columns.Add("InvoiceAddressID", typeof(string));
            dataTable.Columns.Add("DeliveryAddressID", typeof(string));
            dataTable.Columns.Add("MainApprover", typeof(string));
            dataTable.Columns.Add("AlternateNumbers", typeof(string));
            object[] text = new object[] { this.txtTitle.Text, this.txtFirstName.Text, this.txtMiddleName.Text, this.txtLastName.Text, this.ddlDepartment.SelectedValue.ToString(), this.txtJobTitle.Text, this.txtJobTitle2.Text, this.txt_ContactEmail.Text, this.txtContactMobile.Text, this.txtHomePhone.Text, this.txtPersonalFax.Text, this.ClientID, this.ContactID, this.hdnContactAddressID.Value, this.hdnDeptID.Value, this.hdnAddressID.Value, this.hdnShippingAddressID.Value, this.chkMainApprover.Checked, this.txtAlternateNumber.Text };
            dataTable.Rows.Add(text);
            base.Session["Contact"] = dataTable;
        }

        protected void txt_ContactEmail_TextChanged(object sender, EventArgs e)
        {
            int num = CompanyBasePage.Check_EmailID_Duplicacy_for_Account(this.txt_ContactEmail.Text, (long)this.ClientID, (long)this.ContactID);
            if (num == -1)
            {
                this.ChkEmailDuplicacy = true;
                return;
            }
            if (num == -2)
            {
                this.ChkEmailDuplicacy = true;
                return;
            }
            this.ChkEmailDuplicacy = false;
        }
    }
}