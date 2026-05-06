using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class B2B_Registration : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected PlaceHolder ph_headerLeft;

        //protected HtmlTableCell tdheaderimage;

        //protected HtmlTable tblheaderimage;

        //protected Label lblRegisterMessage;

        //protected Label lblRM;

        //protected LinkButton LnkBack;

        //protected Panel pnlMessage;

        //protected Label lbl_firstName;

        //protected TextBox txt_firstName;

        //protected RequiredFieldValidator req_firstName;

        //protected Label lbl_lastName;

        //protected TextBox txt_lastName;

        //protected Label lbl_Department;

        //protected HtmlGenericControl lblDeptMandatry;

        //protected HtmlInputImage imgAddDepartment;

        //protected HiddenField hdnNewDeptID;

        //protected HtmlTableCell divDepartmentNameLeft;

        //protected DropDownList ddl_Department;

        //protected Label lblDepartment;

        //protected HiddenField HdnDepartmentID;

        //protected HiddenField hdnIsAddDepartment;

        //protected RequiredFieldValidator req_ddldepartment;

        //protected Label lblAddDepartmentNote;

        //protected HtmlGenericControl NoteGeneral;

        //protected HtmlTableCell divDepartmentName;

        //protected HtmlTableCell tdAddNewDept;

        //protected HtmlTable tblTop;

        //protected HiddenField hdnInsertAddress;

        //protected Label lbl_DeptName;

        //protected TextBox txtDeptName;

        //protected Label lblErrorDuplicateMessage;

        //protected RequiredFieldValidator rfvDeptName;

        //protected Label lblDeliveryAddress;

        //protected Label lblDelAddLabel;

        //protected TextBox txtDelAddLabel;

        //protected Label lblDelAdd1;

        //protected HtmlGenericControl lblDelAddMandatory1;

        //protected TextBox txtDelAdd1;

        //protected RequiredFieldValidator rfvDelAdd1;

        //protected Label lblDelAdd2;

        //protected HtmlGenericControl lblDelAddMandatory2;

        //protected TextBox txtDelAdd2;

        //protected RequiredFieldValidator rfvDelAdd2;

        //protected Label lblDelAdd3;

        //protected HtmlGenericControl lblDelAddMandatory3;

        //protected TextBox txtDelAdd3;

        //protected RequiredFieldValidator rfvDelAdd3;

        //protected Label lblDelAdd4;

        //protected HtmlGenericControl lblDelAddMandatory4;

        //protected TextBox txtDelAdd4;

        //protected RequiredFieldValidator rfvDelAdd4;

        //protected Label lblDelAdd5;

        //protected HtmlGenericControl lblDelAddMandatory5;

        //protected TextBox txtDelAdd5;

        //protected RequiredFieldValidator rfvDelAdd5;

        //protected Label lblDelCountry;

        //protected DropDownList ddlDelCountry;

        //protected RequiredFieldValidator rfvDelCountry;

        //protected HiddenField hdnCountryIndex;

        //protected Label lblDelTelephone;

        //protected TextBox txtDelTelephone;

        //protected RequiredFieldValidator rfvDelTelephone;

        //protected Label lblDelFax;

        //protected TextBox txtDelFax;

        //protected CheckBox chkCopyToInvoice;

        //protected Label lblCopyToInvoice;

        //protected Label lblInvoiceAddress;

        //protected Label lblInvAddLabel;

        //protected TextBox txtInvAddLabel;

        //protected Label lblInvAdd1;

        //protected HtmlGenericControl lblInvAddMandatory1;

        //protected TextBox txtInvAdd1;

        //protected RequiredFieldValidator rfvInvAdd1;

        //protected Label lblInvAdd2;

        //protected HtmlGenericControl lblInvAddMandatory2;

        //protected TextBox txtInvAdd2;

        //protected RequiredFieldValidator rfvInvAdd2;

        //protected Label lblInvAdd3;

        //protected HtmlGenericControl lblInvAddMandatory3;

        //protected TextBox txtInvAdd3;

        //protected RequiredFieldValidator rfvInvAdd3;

        //protected Label lblInvAdd4;

        //protected HtmlGenericControl lblInvAddMandatory4;

        //protected TextBox txtInvAdd4;

        //protected RequiredFieldValidator rfvInvAdd4;

        //protected Label lblInvAdd5;

        //protected HtmlGenericControl lblInvAddMandatory5;

        //protected TextBox txtInvAdd5;

        //protected RequiredFieldValidator rfvInvAdd5;

        //protected Label lblInvCountry;

        //protected DropDownList ddlInvCountry;

        //protected RequiredFieldValidator rfvInvCountry;

        //protected Label lblInvTelephone;

        //protected TextBox txtInvTelephone;

        //protected RequiredFieldValidator rfvInvTelephone;

        //protected Label lblInvFax;

        //protected TextBox txtInvFax;

        //protected HtmlInputButton btnCancel;

        //protected Button btnSaveAndUse;

        //protected Label lblContact;

        //protected HiddenField isPrefill;

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

        //protected Label lblLogin;

        //protected Label lbl_email;

        //protected HtmlGenericControl div_lblemail;

        //protected TextBox txt_email;

        //protected RequiredFieldValidator reqemail;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected HtmlGenericControl spn_txt_email;

        //protected HtmlGenericControl spn_txt_email_Rej;

        //protected HtmlGenericControl div_txtemail;

        //protected HtmlTableRow trcost;

        //protected Label lbl_password;

        //protected HtmlTableCell costSmartTdLeft;

        //protected TextBox txtpassword;

        //protected RequiredFieldValidator reqpassword;

        //protected RegularExpressionValidator Regexp_validateEmailForCostsmart;

        //protected HtmlGenericControl spn_txtpassemail;

        //protected HtmlGenericControl spn_txtpassemail_Rej;

        //protected HtmlGenericControl spn_txtPassEmailExists;

        //protected Label lbl_confirmPassword;

        //protected HtmlTableCell costSmartTdRight;

        //protected TextBox txt_confirmPassword;

        //protected RequiredFieldValidator reqconfirmPassword;

        //protected CompareValidator CompareValidator1;

        //protected Label lbldesignate;

        //protected HtmlGenericControl div_Approver_Header;

        //protected Label lbl_ApproEmail;

        //protected TextBox txt_ApproEmail;

        //protected HiddenField hdnApproverID;

        //protected RequiredFieldValidator RequiredFieldValidator2;

        //protected RegularExpressionValidator RegularExpressionValidator2;

        //protected HtmlGenericControl div_Approver_Content;

        //protected Label lblReqiEmail;

        //protected CheckBox chkAddEmilDmc;

        //protected Button btnBackRegister;

        //protected Button btn_createAccount;

        //protected Panel pnlRegister;

        //protected LinkButton LinkButton1;

        //protected Panel pnlAccessDeniedMsg;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HtmlGenericControl divfootersub;

        //protected HtmlGenericControl divfooterMain;

        public string strImagepath = BaseClass.imagePath();

        public static int CompanyID;

        public static long AccountID;

        public string strSitepath = string.Empty;

        public string approvalType = string.Empty;

        public string Subject = string.Empty;

        public string EmailBodyApprover = string.Empty;

        public string EmailBodyUser = string.Empty;

        private commonclass comm = new commonclass();

        private storeEmail objEmail = new storeEmail();

        private long DepartmentID;

        private string approverEmailcontains = string.Empty;

        private string Result = string.Empty;

        private LoginItems objLogItems = new LoginItems();

        public languageClass objLanguage = new languageClass();

        public int roundoff;

        public int pageID;

        public int arrayLength;

        public char KeySeparator;

        public string Rewritemodule = string.Empty;

        public string strSitePath = string.Empty;

        public string imageHandlerPath = string.Empty;

        public string StyleSheetPath = string.Empty;

        public string StoreimageHandlerPath = string.Empty;

        public string logoImageHeader = string.Empty;

        public string logoImageFooter = string.Empty;

        public string nilImage = "nil.gif";

        public string BannerImageHeader = string.Empty;

        public string BannerImageFooter = string.Empty;

        public string bannerImagePath = string.Empty;

        public string StyleSheetPathMaster = string.Empty;

        public string SystemName = string.Empty;

        public static int AccCompanyID;

        public string IsHomePageVisible = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int clientid;

        public int createuserid;

        private long rtnDeptID;

        private long deliveryAddressId;

        private int invoiceAddressId;

        private int costCenterId;

        private string deptScreenName = string.Empty;

        private BaseClass obj = new BaseClass();

        private DateTime CreatedDate;

        public string IsSingleField = "false";

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

        static B2B_Registration()
        {
            B2B_Registration.CompanyID = 0;
            B2B_Registration.AccountID = (long)0;
        }

        public B2B_Registration()
        {
        }

        public void _Login(string Email, string Password)
        {
            loginclass _loginclass = new loginclass();
            this.Session["IsHomePageVisible"] = null;
            this.Session["IsPPW"] = null;
            DataTable dataTable = LoginBasePage.LoginTo_Store(Email, Password, B2B_Registration.AccountID, ConnectionClass.AccountType);
            HttpCookie item = base.Response.Cookies["CooEmail"];
            commonclass _commonclass = this.comm;
            DateTime dateTime = DateTime.Now.AddDays(-1);
            item.Expires = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(dateTime.ToString(), B2B_Registration.CompanyID, this.createuserid, true));
            HttpCookie httpCookie = base.Response.Cookies["CooPassword"];
            commonclass _commonclass1 = this.comm;
            DateTime dateTime1 = DateTime.Now.AddDays(-1);
            httpCookie.Expires = Convert.ToDateTime(_commonclass1.Eprint_return_ActualDate_Before_View(dateTime1.ToString(), B2B_Registration.CompanyID, this.createuserid, true));
            foreach (DataRow row in dataTable.Rows)
            {
                base.Response.Cookies["B2BAccountID"].Value = row["AccountID"].ToString();
                Convert.ToInt64(row["StoreUserID"].ToString());
                B2B_Registration.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                DataTable displaySettings = CMSBasePage.GetDisplaySettings(B2B_Registration.AccountID);
                this.Session["AccountID"] = B2B_Registration.AccountID.ToString();
                this.Session["eStoreDisplaySetting"] = displaySettings;
                this.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                this.Session["IsPPW"] = row["IsPPW"].ToString();
                base.Assign_ApprovalSystemSettings_ForAccount(B2B_Registration.AccountID);
            }
            _loginclass.Insert_intoResume_Session(Email, Password, B2B_Registration.AccountID);
            _loginclass.LogInFromDefault(Email, Password);
            base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
        }

        public void BindDepartmentDrop()
        {
            DataTable dataTable = new DataTable();
            dataTable = LoginBasePage.Select_Departments(B2B_Registration.AccountID);
            this.ddl_Department.DataSource = dataTable;
            long num = (long)0;
            foreach (DataRow row in dataTable.Rows)
            {
                row["DeptName"] = base.SpecialDecode(row["DeptName"].ToString());
                if (row["IsDefault"].ToString().ToLower() != "true")
                {
                    continue;
                }
                num = Convert.ToInt64(row["DeptID"]);
            }
            this.ddl_Department.DataTextField = "DeptName";
            this.ddl_Department.DataValueField = "DeptID";
            this.ddl_Department.DataBind();
            if (ConnectionClass.SystemName.ToString().ToLower() == "dmc2" && B2B_Registration.AccountID == (long)242)
            {
                this.ddl_Department.Items.Insert(0, "--Select--");
                this.ddl_Department.Items[0].Text = "--Select--";
                this.ddl_Department.Items[0].Value = "0";
            }
            if (this.hdnNewDeptID.Value != "")
            {
                num = Convert.ToInt64(this.hdnNewDeptID.Value);
            }
            if (num != (long)0)
            {
                base.SetDDLValue(this.ddl_Department, num.ToString());
            }
            if (this.hdnNewDeptID.Value == "")
            {
                if (!this.ddl_Department.Visible)
                {
                    if (this.HdnDepartmentID.Value != null && this.HdnDepartmentID.Value != "")
                    {
                        num = Convert.ToInt64(this.HdnDepartmentID.Value);
                    }
                }
                else if (num == (long)0)
                {
                    num = Convert.ToInt64(this.ddl_Department.SelectedValue);
                }
            }
            DataTable item = LoginBasePage.GetDepartmentName(num).Tables[1];
            if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && base.Return_ApprovalSystem_Settings("lastapproverdefault").ToLower() != "false" && dataTable.Rows.Count > 0)
            {
                this.txt_ApproEmail.Text = dataTable.Rows[0]["ApproverEmail"].ToString();
            }
            string str = base.Return_ApprovalRegistration_Settings("prefiladded");
            if (item.Rows.Count <= 0 || !(str.ToLower() == "true"))
            {
                this.txtBillAddress1.Text = "";
                this.txtBillAddress2.Text = "";
                this.txtBillCity.Text = "";
                this.txtBillZipCode.Text = "";
                this.txtBillFax.Text = "";
                this.txtBillState.Text = "";
                this.txtBillTelephone.Text = "";
            }
            else
            {
                foreach (DataRow dataRow in item.Rows)
                {
                    this.txtBillAddress1.Text = base.SpecialDecode(dataRow["Address"].ToString());
                    this.txtBillAddress2.Text = base.SpecialDecode(dataRow["AddressLine2"].ToString());
                    this.txtBillCity.Text = base.SpecialDecode(dataRow["City"].ToString());
                    this.txtBillZipCode.Text = dataRow["ZipCode"].ToString();
                    this.txtBillState.Text = base.SpecialDecode(dataRow["State"].ToString());
                    this.txtBillTelephone.Text = base.SpecialDecode(dataRow["Telephone"].ToString());
                    this.txtBillFax.Text = base.SpecialDecode(dataRow["Fax"].ToString());
                    this.obj.SetDDLText(this.ddlBillCountry, base.SpecialDecode(dataRow["Country"].ToString()));
                }
            }
        }

        protected void btn_createAccount_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.objLogItems.FirstName = base.SpecialEncode(this.txt_firstName.Text.Trim());
                this.objLogItems.LastName = base.SpecialEncode(this.txt_lastName.Text.Trim());
                string str = base.Return_ApprovalRegistration_Settings("userdepttype");
                this.objLogItems.Address1 = base.SpecialEncode(this.txtBillAddress1.Text.Trim());
                this.objLogItems.Address2 = base.SpecialEncode(this.txtBillAddress2.Text.Trim());
                this.objLogItems.Address3 = base.SpecialEncode(this.txtBillCity.Text.Trim());
                this.objLogItems.Address4 = base.SpecialEncode(this.txtBillState.Text.Trim());
                this.objLogItems.Address5 = this.txtBillZipCode.Text.Trim();
                this.objLogItems.Country = this.ddlBillCountry.SelectedItem.Text;
                this.objLogItems.Telephone = this.txtBillTelephone.Text.Trim();
                this.objLogItems.Fax = this.txtBillFax.Text.Trim();
                this.objLogItems.Email = base.SpecialEncode(this.txt_email.Text.Trim());
                this.objLogItems.Password = this.txtpassword.Text.Trim();
                this.objLogItems.ApprovalType = this.approvalType;
                this.objLogItems.ApproverEmail = this.txt_ApproEmail.Text.Trim();
                if (!this.chkAddEmilDmc.Checked)
                {
                    this.objLogItems.IsSubscribeuser = (long)0;
                }
                else
                {
                    this.objLogItems.IsSubscribeuser = (long)1;
                }
                this.objLogItems.DepartmentName = base.SpecialEncode(this.ddl_Department.SelectedItem.Text);
                this.objLogItems.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                this.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                string str1 = base.Return_ApprovalRegistration_Settings("approvedemailaddress");
                string str2 = base.Return_ApprovalRegistration_Settings("registeremailaddress");
                if (!this.txt_email.Text.Trim().Contains(str2))
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
                }
                else if (this.Session["ApprovalSystem"] != null)
                {
                    if (this.Session["ApprovalSystem"].ToString() != "on")
                    {
                        if (str == "L" || str == "")
                        {
                            this.objLogItems.DepartmentName = this.ddl_Department.SelectedItem.Text;
                            this.objLogItems.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                            this.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                        }
                        else if (str == "D")
                        {
                            try
                            {
                                if (this.hdnNewDeptID.Value != "")
                                {
                                    this.DepartmentID = Convert.ToInt64(this.hdnNewDeptID.Value);
                                }
                                else
                                {
                                    this.DepartmentID = Convert.ToInt64(base.Return_ApprovalRegistration_Settings("departmentid"));
                                }
                                DataSet departmentName = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (departmentName.Tables[0].Rows.Count > 0)
                                {
                                    string str3 = departmentName.Tables[0].Rows[0]["DeptName"].ToString();
                                    this.objLogItems.DepartmentName = str3;
                                }
                                this.objLogItems.DepartmentID = this.DepartmentID;
                            }
                            catch
                            {
                            }
                        }
                        if (str2 != "")
                        {
                            string str4 = base.Return_ApprovalRegistration_Settings("prefiladded");
                            if (!this.txt_email.Text.Trim().Contains(str2))
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
                                return;
                            }
                            long num = (long)0;
                            if (str4.ToString().ToLower() != "true")
                            {
                                num = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                            }
                            else
                            {
                                DataSet dataSet = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (dataSet.Tables.Count > 0)
                                {
                                    long num1 = (long)0;
                                    if (dataSet.Tables[1].Rows.Count > 0)
                                    {
                                        num1 = Convert.ToInt64(dataSet.Tables[1].Rows[0]["AddressID"].ToString());
                                        if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                        {
                                            num1 = this.Check_PreFillAddressFields(num1);
                                        }
                                    }
                                    num = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, num1, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                                }
                            }
                            if (num == (long)-1)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                                    this.spn_txt_email_Rej.Visible = false;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = true;
                                this.spn_txtpassemail_Rej.Visible = false;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num == (long)-2)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                                    this.spn_txt_email_Rej.Visible = true;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = false;
                                this.spn_txtpassemail_Rej.Visible = true;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num > (long)0)
                            {
                                this.objEmail.B2BRegisterDetails_Email(num, B2B_Registration.CompanyID, B2B_Registration.AccountID, "New B2B Contact Registration", "Customer", (long)0, this.txt_email.Text.Trim());
                                this._Login(base.SpecialEncode(this.txt_email.Text.Trim()), this.txtpassword.Text.Trim());
                                this.pnlMessage.Visible = true;
                                this.pnlRegister.Visible = false;
                                this.lblRegisterMessage.Text = this.objLanguage.GetLanguageConversion("Your_registration_is_successfully_completed");
                                return;
                            }
                        }
                        else
                        {
                            string str5 = base.Return_ApprovalRegistration_Settings("prefiladded");
                            long num2 = (long)0;
                            if (str5.ToString().ToLower() != "true")
                            {
                                num2 = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                            }
                            else
                            {
                                DataSet departmentName1 = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (departmentName1.Tables.Count > 0)
                                {
                                    long num3 = (long)0;
                                    if (departmentName1.Tables[1].Rows.Count > 0)
                                    {
                                        num3 = Convert.ToInt64(departmentName1.Tables[1].Rows[0]["AddressID"].ToString());
                                        if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                        {
                                            num3 = this.Check_PreFillAddressFields(num3);
                                        }
                                    }
                                    num2 = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, num3, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                                }
                            }
                            if (num2 == (long)-1)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    ///modifications
                                    this.spn_txt_email.Text = this.objLanguage.GetLanguageConversion("Email_address_already_exists_please_enter_another_email_address");
                                    this.spn_txt_email.Visible = true;
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                                    this.spn_txt_email_Rej.Visible = false;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = true;
                                this.spn_txtpassemail_Rej.Visible = false;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num2 == (long)-2)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                                    this.spn_txt_email_Rej.Visible = true;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = false;
                                this.spn_txtpassemail_Rej.Visible = true;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num2 > (long)0)
                            {
                                this.objEmail.B2BRegisterDetails_Email(num2, B2B_Registration.CompanyID, B2B_Registration.AccountID, "New B2B Contact Registration", "Customer", (long)0, this.txt_email.Text.Trim());
                                this._Login(base.SpecialEncode(this.txt_email.Text.Trim()), this.txtpassword.Text.Trim());
                                this.pnlMessage.Visible = true;
                                this.pnlRegister.Visible = false;
                                this.lblRegisterMessage.Text = this.objLanguage.GetLanguageConversion("Your_registration_is_successfully_completed");
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (str == "L" || str == "")
                        {
                            this.objLogItems.DepartmentName = this.ddl_Department.SelectedItem.Text;
                            this.objLogItems.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                            this.DepartmentID = Convert.ToInt64(this.ddl_Department.SelectedItem.Value);
                        }
                        else if (str == "D")
                        {
                            try
                            {
                                if (this.hdnNewDeptID.Value != "")
                                {
                                    this.DepartmentID = Convert.ToInt64(this.hdnNewDeptID.Value);
                                }
                                else
                                {
                                    this.DepartmentID = Convert.ToInt64(base.Return_ApprovalRegistration_Settings("departmentid"));
                                }
                                DataSet dataSet1 = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (dataSet1.Tables[0].Rows.Count > 0)
                                {
                                    string str6 = dataSet1.Tables[0].Rows[0]["DeptName"].ToString();
                                    this.objLogItems.DepartmentName = str6;
                                }
                                this.objLogItems.DepartmentID = this.DepartmentID;
                            }
                            catch
                            {
                            }
                        }
                        string str7 = base.Return_ApprovalRegistration_Settings("prefiladded");
                        if (base.Return_ApprovalSystem_Settings("newuserapprove").ToLower().Trim() != "true")
                        {
                            long num4 = (long)0;
                            if (str7.ToString().ToLower() != "true")
                            {
                                num4 = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                            }
                            else
                            {
                                DataSet departmentName2 = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (departmentName2.Tables.Count > 0)
                                {
                                    long num5 = (long)0;
                                    if (departmentName2.Tables[1].Rows.Count > 0)
                                    {
                                        num5 = Convert.ToInt64(departmentName2.Tables[1].Rows[0]["AddressID"].ToString());
                                        if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                        {
                                            num5 = this.Check_PreFillAddressFields(num5);
                                        }
                                    }
                                    num4 = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, num5, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                                }
                            }
                            if (num4 == (long)-1)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                                    this.spn_txt_email_Rej.Visible = false;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = true;
                                this.spn_txtpassemail_Rej.Visible = false;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num4 == (long)-2)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                                    this.spn_txt_email_Rej.Visible = true;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = false;
                                this.spn_txtpassemail_Rej.Visible = true;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num4 > (long)0)
                            {
                                this.objEmail.B2BRegisterDetails_Email(num4, B2B_Registration.CompanyID, B2B_Registration.AccountID, "New B2B Contact Registration", "Customer", (long)0, this.txt_email.Text.Trim());
                                this._Login(base.SpecialEncode(this.txt_email.Text.Trim()), this.txtpassword.Text.Trim());
                                this.pnlMessage.Visible = true;
                                this.pnlRegister.Visible = false;
                                this.lblRegisterMessage.Text = this.objLanguage.GetLanguageConversion("Your_registration_is_successfully_completed");
                                return;
                            }
                        }
                        else
                        {
                            if (str1 == "")
                            {
                                if (str2 == "")
                                {
                                    this.MainFunction();
                                    return;
                                }
                                if (this.txt_email.Text.Trim().Contains(str2))
                                {
                                    this.MainFunction();
                                    return;
                                }
                                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
                                return;
                            }
                            if (!this.txt_email.Text.Trim().Contains(str1))
                            {
                                if (str2 == "")
                                {
                                    this.MainFunction();
                                    return;
                                }
                                if (this.txt_email.Text.Trim().Contains(str2))
                                {
                                    this.MainFunction();
                                    return;
                                }
                                System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
                                return;
                            }
                            long num6 = (long)0;
                            if (str7.ToString().ToLower() != "true")
                            {
                                num6 = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                            }
                            else
                            {
                                DataSet dataSet2 = LoginBasePage.GetDepartmentName(this.DepartmentID);
                                if (dataSet2.Tables.Count > 0)
                                {
                                    long num7 = (long)0;
                                    if (dataSet2.Tables[1].Rows.Count > 0)
                                    {
                                        num7 = Convert.ToInt64(dataSet2.Tables[1].Rows[0]["AddressID"].ToString());
                                        if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                        {
                                            num7 = this.Check_PreFillAddressFields(num7);
                                        }
                                    }
                                    num6 = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, true, num7, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                                }
                            }
                            if (num6 == (long)-1)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                                    this.spn_txt_email_Rej.Visible = false;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = true;
                                this.spn_txtpassemail_Rej.Visible = false;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num6 == (long)-2)
                            {
                                if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                                {
                                    this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                                    this.spn_txt_email_Rej.Visible = true;
                                    return;
                                }
                                this.spn_txtpassemail.Visible = false;
                                this.spn_txtpassemail_Rej.Visible = true;
                                this.reqpassword.Style.Add("display", "none");
                                this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                                return;
                            }
                            if (num6 > (long)0)
                            {
                                this.objEmail.B2BRegisterDetails_Email(num6, B2B_Registration.CompanyID, B2B_Registration.AccountID, "New B2B Contact Registration", "Customer", (long)0, this.txt_email.Text.Trim());
                                this.pnlMessage.Visible = true;
                                this.pnlRegister.Visible = false;
                                this.lblRegisterMessage.Text = this.objLanguage.GetLanguageConversion("Your_registration_is_successfully_completed");
                                return;
                            }
                        }
                    }
                }
            }
        }
        protected void btnBackRegister_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", B2B_Registration.AccountID));
        }

        public long Check_PreFillAddressFields(long AddressID)
        {
            long num = (long)0;
            bool flag = false;
            if (this.ddl_Department.Visible)
            {
                num = Convert.ToInt64(this.ddl_Department.SelectedValue);
            }
            else if (this.hdnNewDeptID.Value != "")
            {
                num = Convert.ToInt64(this.hdnNewDeptID.Value);
            }
            else if (this.HdnDepartmentID.Value != null && this.HdnDepartmentID.Value != "")
            {
                num = Convert.ToInt64(this.HdnDepartmentID.Value);
            }
            DataTable item = LoginBasePage.GetDepartmentName(num).Tables[1];
            if (item.Rows.Count <= 0)
            {
                flag = true;
            }
            else
            {
                foreach (DataRow row in item.Rows)
                {
                    if (this.txtBillAddress1.Text != base.SpecialDecode(row["Address"].ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else if (this.txtBillAddress2.Text != base.SpecialDecode(row["AddressLine2"].ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else if (this.txtBillCity.Text != base.SpecialDecode(row["City"].ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else if (this.txtBillZipCode.Text != row["ZipCode"].ToString())
                    {
                        flag = true;
                        break;
                    }
                    else if (this.txtBillState.Text != base.SpecialDecode(row["State"].ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else if (this.txtBillTelephone.Text != base.SpecialDecode(row["Telephone"].ToString()))
                    {
                        flag = true;
                        break;
                    }
                    else if (this.ddlBillCountry.SelectedItem.Text == base.SpecialDecode(row["Country"].ToString()))
                    {
                        if (this.txtBillFax.Text == base.SpecialDecode(row["Fax"].ToString()))
                        {
                            continue;
                        }
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                AddressID = LoginBasePage.Address_Insert_Registration(B2B_Registration.AccountID, base.SpecialEncode(this.txtBillAddress1.Text.Trim()), base.SpecialEncode(this.txtBillAddress2.Text.Trim()), base.SpecialEncode(this.txtBillCity.Text.Trim()), base.SpecialEncode(this.txtBillState.Text.Trim()), base.SpecialEncode(this.ddlBillCountry.SelectedItem.Text), base.SpecialEncode(this.txtBillTelephone.Text.Trim()), base.SpecialEncode(this.txtBillFax.Text.Trim()), base.SpecialEncode(this.txtBillZipCode.Text.Trim()), "");
            }
            return AddressID;
        }

        protected void ddl_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            long num = Convert.ToInt64(this.ddl_Department.SelectedValue);
            if (num.ToString() != this.hdnNewDeptID.Value.ToString())
            {
                this.hdnIsAddDepartment.Value = "false";
            }
            else
            {
                this.hdnIsAddDepartment.Value = "true";
            }
            DataTable item = LoginBasePage.GetDepartmentName(num).Tables[1];
            string str = base.Return_ApprovalRegistration_Settings("prefiladded");
            if (item.Rows.Count <= 0 || !(str.ToLower() == "true"))
            {
                this.txtBillAddress1.Text = "";
                this.txtBillAddress2.Text = "";
                this.txtBillCity.Text = "";
                this.txtBillZipCode.Text = "";
                this.txtBillFax.Text = "";
                this.txtBillState.Text = "";
                this.txtBillTelephone.Text = "";
            }
            else
            {
                foreach (DataRow row in item.Rows)
                {
                    this.txtBillAddress1.Text = base.SpecialDecode(row["Address"].ToString());
                    this.txtBillAddress2.Text = base.SpecialDecode(row["AddressLine2"].ToString());
                    this.txtBillCity.Text = base.SpecialDecode(row["City"].ToString());
                    this.txtBillZipCode.Text = row["ZipCode"].ToString();
                    this.txtBillState.Text = base.SpecialDecode(row["State"].ToString());
                    this.txtBillTelephone.Text = base.SpecialDecode(row["Telephone"].ToString());
                    this.txtBillFax.Text = base.SpecialDecode(row["Fax"].ToString());
                    this.obj.SetDDLText(this.ddlBillCountry, base.SpecialDecode(row["Country"].ToString()));
                }
            }
        }

        public void DisableAddressFileds()
        {
            this.txtBillAddress1.Enabled = false;
            this.txtBillAddress2.Enabled = false;
            this.txtBillCity.Enabled = false;
            this.txtBillFax.Enabled = false;
            this.txtBillState.Enabled = false;
            this.txtBillTelephone.Enabled = false;
            this.txtBillZipCode.Enabled = false;
            this.ddlBillCountry.Enabled = false;
            this.reqAddress1.Visible = false;
            this.reqAddress2.Visible = false;
            this.reqAddress3.Visible = false;
            this.reqAddress4.Visible = false;
            this.reqAddress5.Visible = false;
            this.reqCountry.Visible = false;
            this.reqTelephone.Visible = false;
        }

        public void InsertDepartment(object sender, EventArgs e)
        {
            if (this.hdnInsertAddress.Value == "")
            {
                this.deliveryAddressId = LoginBasePage.Address_Insert_Registration(B2B_Registration.AccountID, base.SpecialEncode(this.txtDelAdd1.Text.Trim()), base.SpecialEncode(this.txtDelAdd2.Text.Trim()), base.SpecialEncode(this.txtDelAdd3.Text.Trim()), base.SpecialEncode(this.txtDelAdd4.Text.Trim()), base.SpecialEncode(this.ddlDelCountry.SelectedItem.Text.Trim()), base.SpecialEncode(this.txtDelTelephone.Text.Trim()), base.SpecialEncode(this.txtDelFax.Text.Trim()), base.SpecialEncode(this.txtDelAdd5.Text.Trim()), base.SpecialEncode(this.txtDelAddLabel.Text.Trim()));
                this.invoiceAddressId = Convert.ToInt32(LoginBasePage.Address_Insert_Registration(B2B_Registration.AccountID, base.SpecialEncode(this.txtInvAdd1.Text.Trim()), base.SpecialEncode(this.txtInvAdd2.Text.Trim()), base.SpecialEncode(this.txtInvAdd3.Text.Trim()), base.SpecialEncode(this.txtInvAdd4.Text.Trim()), base.SpecialEncode(this.ddlInvCountry.SelectedItem.Text.Trim()), base.SpecialEncode(this.txtInvTelephone.Text.Trim()), base.SpecialEncode(this.txtInvFax.Text.Trim()), base.SpecialEncode(this.txtInvAdd5.Text.Trim()), base.SpecialEncode(this.txtInvAddLabel.Text.Trim())));
            }
            else if (this.hdnInsertAddress.Value == "delivery")
            {
                this.deliveryAddressId = LoginBasePage.Address_Insert_Registration(B2B_Registration.AccountID, base.SpecialEncode(this.txtDelAdd1.Text.Trim()), base.SpecialEncode(this.txtDelAdd2.Text.Trim()), base.SpecialEncode(this.txtDelAdd3.Text.Trim()), base.SpecialEncode(this.txtDelAdd4.Text.Trim()), base.SpecialEncode(this.ddlDelCountry.SelectedItem.Text.Trim()), base.SpecialEncode(this.txtDelTelephone.Text.Trim()), base.SpecialEncode(this.txtDelFax.Text.Trim()), base.SpecialEncode(this.txtDelAdd5.Text.Trim()), base.SpecialEncode(this.txtDelAddLabel.Text.Trim()));
                this.invoiceAddressId = Convert.ToInt32(this.deliveryAddressId);
            }
            DataTable dataTable = LoginBasePage.costcenter_getdefaultcenter(this.clientid);
            this.costCenterId = Convert.ToInt32(dataTable.Rows[0]["CostCentreID"]);
            this.rtnDeptID = LoginBasePage.departmentInsert((long)0, this.obj.SpecialEncode(this.txtDeptName.Text.Trim()), this.clientid, 0, this.createuserid, this.invoiceAddressId, "A", this.CreatedDate, this.CreatedDate, B2B_Registration.CompanyID, this.deliveryAddressId, 0, this.costCenterId, "N", false, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", (long)0, "", "", false);
            if (this.rtnDeptID != (long)0)
            {
                this.hdnNewDeptID.Value = this.rtnDeptID.ToString();
                this.hdnIsAddDepartment.Value = "true";
                string str = base.Return_ApprovalRegistration_Settings("userdepttype");
                this.BindDepartmentDrop();
                if (str == "L")
                {
                    this.ddl_Department.Visible = true;
                }
                else if (str == "D")
                {
                    try
                    {
                        this.ddl_Department.Visible = false;
                        this.lblDepartment.Visible = true;
                        DataSet departmentName = LoginBasePage.GetDepartmentName(this.rtnDeptID);
                        if (departmentName.Tables[0].Rows.Count > 0)
                        {
                            string str1 = departmentName.Tables[0].Rows[0]["DeptName"].ToString();
                            this.lblDepartment.Text = base.SpecialDecode(str1);
                            this.divDepartmentName.Style.Add("height", "27px");
                            this.divDepartmentNameLeft.Style.Add("padding-top", "0px");
                        }
                    }
                    catch
                    {
                    }
                }
            }
            string str2 = base.Return_ApprovalRegistration_Settings("deptscreenname");
            if (str2 == "")
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", "Page_ClientValidateReset();alert('Department added successfully')", true);
                return;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("Page_ClientValidateReset();alert('", str2, " added successfully')"), true);
        }

        public void MainFunction()
        {
            this.approverEmailcontains = base.Return_ApprovalSystem_Settings("approveremail");
            base.Return_ApprovalRegistration_Settings("registeremailaddress");
            if (this.approvalType == "u")
            {
                this.objLogItems.ApproverEmail = this.txt_ApproEmail.Text.Trim();
                if (this.approverEmailcontains != "")
                {
                    if (!this.txt_ApproEmail.Text.Trim().Contains(this.approverEmailcontains))
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "__showConfirm", "javascript:ShowAlert();", true);
                        return;
                    }
                    string str = base.Return_ApprovalRegistration_Settings("prefiladded");
                    long num = (long)0;
                    if (str.ToString().ToLower() != "true")
                    {
                        num = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                    }
                    else
                    {
                        DataSet departmentName = LoginBasePage.GetDepartmentName(this.DepartmentID);
                        if (departmentName.Tables.Count > 0)
                        {
                            long num1 = (long)0;
                            if (departmentName.Tables[1].Rows.Count > 0)
                            {
                                num1 = Convert.ToInt64(departmentName.Tables[1].Rows[0]["AddressID"].ToString());
                                if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                {
                                    num1 = this.Check_PreFillAddressFields(num1);
                                }
                            }
                            num = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, num1, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                        }
                    }
                    if (num == (long)-1)
                    {
                        if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                        {
                            this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                            this.spn_txt_email_Rej.Visible = false;
                            return;
                        }
                        this.spn_txtpassemail.Visible = true;
                        this.spn_txtpassemail_Rej.Visible = false;
                        this.reqpassword.Style.Add("display", "none");
                        this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                        return;
                    }
                    if (num == (long)-2)
                    {
                        if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                        {
                            this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                            this.spn_txt_email_Rej.Visible = true;
                            return;
                        }
                        this.spn_txtpassemail.Visible = false;
                        this.spn_txtpassemail_Rej.Visible = true;
                        this.reqpassword.Style.Add("display", "none");
                        this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                        return;
                    }
                    if (num > (long)0)
                    {
                        this.objEmail.B2BRegisterDetails_Email(num, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New user registration", "approver", (long)0, this.txt_ApproEmail.Text.Trim());
                        this.objEmail.B2BRegisterDetails_Email(num, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New User Registration Approval Pending", "Customer", (long)0, this.txt_email.Text.Trim());
                        this.pnlMessage.Visible = true;
                        this.pnlRegister.Visible = false;
                        return;
                    }
                }
                else
                {
                    string str1 = base.Return_ApprovalRegistration_Settings("prefiladded");
                    long num2 = (long)0;
                    if (str1.ToString().ToLower() != "true")
                    {
                        num2 = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                    }
                    else
                    {
                        DataSet dataSet = LoginBasePage.GetDepartmentName(this.DepartmentID);
                        if (dataSet.Tables.Count > 0)
                        {
                            long num3 = (long)0;
                            if (dataSet.Tables[1].Rows.Count > 0)
                            {
                                num3 = Convert.ToInt64(dataSet.Tables[1].Rows[0]["AddressID"].ToString());
                                if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                                {
                                    num3 = this.Check_PreFillAddressFields(num3);
                                }
                            }
                            num2 = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, num3, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                        }
                    }
                    if (num2 == (long)-1)
                    {
                        if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                        {
                            this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                            this.spn_txt_email_Rej.Visible = false;
                            return;
                        }
                        this.spn_txtpassemail.Visible = true;
                        this.spn_txtpassemail_Rej.Visible = false;
                        this.reqpassword.Style.Add("display", "none");
                        this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                        return;
                    }
                    if (num2 == (long)-2)
                    {
                        if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                        {
                            this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                            this.spn_txt_email_Rej.Visible = true;
                            return;
                        }
                        this.spn_txtpassemail.Visible = false;
                        this.spn_txtpassemail_Rej.Visible = true;
                        this.reqpassword.Style.Add("display", "none");
                        this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                        return;
                    }
                    if (num2 > (long)0)
                    {
                        this.objEmail.B2BRegisterDetails_Email(num2, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New user registration", "approver", (long)0, this.txt_ApproEmail.Text.Trim());
                        this.objEmail.B2BRegisterDetails_Email(num2, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New User Registration Approval Pending", "Customer", (long)0, this.txt_email.Text.Trim());
                        this.pnlMessage.Visible = true;
                        this.pnlRegister.Visible = false;
                        return;
                    }
                }
            }
            else if (this.approvalType != "u")
            {
                string empty = string.Empty;
                string empty1 = string.Empty;
                DataSet dataSet1 = new DataSet();
                dataSet1 = LoginBasePage.ApproversEmail_Select(B2B_Registration.AccountID, this.DepartmentID);
                DataTable dataTable = new DataTable();
                dataTable = dataSet1.Tables[0];
                DataTable item = new DataTable();
                item = dataSet1.Tables[1];
                if (this.approvalType == "a")
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty = row["email"].ToString();
                        empty1 = string.Concat(row["contactID"].ToString(), "~", row["email"].ToString());
                    }
                }
                else if (this.approvalType == "da")
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (!(dataRow["email"].ToString() != "") || dataRow["email"].ToString() == null)
                        {
                            continue;
                        }
                        empty = string.Concat(dataRow["email"].ToString(), ",");
                        empty1 = string.Concat(dataRow["contactID"].ToString(), "~", dataRow["email"].ToString(), ",");
                    }
                    foreach (DataRow row1 in item.Rows)
                    {
                        empty = string.Concat(empty, row1["email"].ToString(), ",");
                        string[] strArrays = new string[] { empty1, row1["contactID"].ToString(), "~", row1["email"].ToString(), "," };
                        empty1 = string.Concat(strArrays);
                    }
                }
                this.objLogItems.ApproverEmail = empty;
                string str2 = base.Return_ApprovalRegistration_Settings("prefiladded");
                long num4 = (long)0;
                if (str2.ToString().ToLower() != "true")
                {
                    num4 = LoginBasePage.StoreUser_Register(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                }
                else
                {
                    DataSet departmentName1 = LoginBasePage.GetDepartmentName(this.DepartmentID);
                    if (departmentName1.Tables.Count > 0)
                    {
                        long num5 = (long)0;
                        if (departmentName1.Tables[1].Rows.Count > 0)
                        {
                            num5 = Convert.ToInt64(departmentName1.Tables[1].Rows[0]["AddressID"].ToString());
                            if (base.Return_ApprovalRegistration_Settings("overwriteadded").ToLower() == "true")
                            {
                                num5 = this.Check_PreFillAddressFields(num5);
                            }
                        }
                        num4 = LoginBasePage.StoreUser_Register_prefil(this.objLogItems, (long)B2B_Registration.CompanyID, B2B_Registration.AccountID, "", this.CreatedDate, false, num5, Convert.ToBoolean(this.hdnIsAddDepartment.Value));
                    }
                }
                if (num4 == (long)-1)
                {
                    if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                    {
                        this.spn_txt_email.Attributes.Add("class", "spnDisplayBlock");
                        this.spn_txt_email_Rej.Visible = false;
                        return;
                    }
                    this.spn_txtpassemail.Visible = true;
                    this.spn_txtpassemail_Rej.Visible = false;
                    this.reqpassword.Style.Add("display", "none");
                    this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                    return;
                }
                if (num4 == (long)-2)
                {
                    if (base.Return_ApprovalRegistration_Settings("issinglefield") != "True")
                    {
                        this.spn_txt_email.Attributes.Add("class", "spnDisplayNone");
                        this.spn_txt_email_Rej.Visible = true;
                        return;
                    }
                    this.spn_txtpassemail.Visible = false;
                    this.spn_txtpassemail_Rej.Visible = true;
                    this.reqpassword.Style.Add("display", "none");
                    this.Regexp_validateEmailForCostsmart.Style.Add("display", "none");
                    return;
                }
                if (num4 > (long)0)
                {
                    string[] strArrays1 = empty1.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        string str3 = strArrays1[i];
                        string[] strArrays2 = str3.Split(new char[] { '~' });
                        if (strArrays2[0].ToString() != "" && strArrays2[0].ToString() != null)
                        {
                            this.objEmail.B2BRegisterDetails_Email(num4, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New user registration", "approver", Convert.ToInt64(strArrays2[0].ToString()), strArrays2[1].ToString());
                            this.objEmail.B2BRegisterDetails_Email(num4, B2B_Registration.CompanyID, B2B_Registration.AccountID, "B2B New User Registration Approval Pending", "Customer", Convert.ToInt64(strArrays2[0].ToString()), this.txt_email.Text.Trim());
                        }
                    }
                    this.pnlMessage.Visible = true;
                    this.pnlRegister.Visible = false;
                }
            }
        }

        protected void Onclick_LnkBack(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", B2B_Registration.AccountID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] secureDocFilepath;
            string[] bannerImageFooter;
            if (base.Request["id"] != null && base.Request["id"] != "")
            {
                B2B_Registration.AccountID = Convert.ToInt64(base.Request["id"].ToString());
                this.Session["AccountID"] = B2B_Registration.AccountID;
                this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(B2B_Registration.AccountID);
            }
            if (base.Request["id"] != null && base.Request["id"] != "" && LoginBasePage.IsSelfRegister_Select(B2B_Registration.AccountID) == 0)
            {
                this.pnlAccessDeniedMsg.Visible = true;
                this.pnlRegister.Visible = false;
            }
            this.IsSingleField = base.Return_ApprovalRegistration_Settings("issinglefield").ToLower();
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddlBillCountry);
                OrderBasePage.company_country_select(this.ddlDelCountry);
                OrderBasePage.company_country_select(this.ddlInvCountry);
                this.hdnCountryIndex.Value = this.ddlDelCountry.SelectedIndex.ToString();
                this.BindDepartmentDrop();
                if (B2B_Registration.AccountID != (long)0)
                {
                    (new BaseClass()).Assign_ApprovalSystemSettings_ForAccount(B2B_Registration.AccountID);
                }
                this.deptScreenName = base.Return_ApprovalRegistration_Settings("deptscreenname");
                if (this.deptScreenName == "")
                {
                    this.lbl_Department.Text = this.objLanguage.GetLanguageConversion("Department");
                    this.lbl_DeptName.Text = this.objLanguage.GetLanguageConversion("Department_Name");
                    this.lblAddDepartmentNote.Text = string.Concat("<span style='margin-left: 1px; color: grey; font-size: 11px; vertical-align: top;'>", this.objLanguage.GetLanguageConversion("Add_Department_Note").Replace(",", ",</span><br /><span style='color: grey; font-size: 11px; vertical-align: top;margin-left:3px;line-height:150%'>"), "</span>");
                    this.imgAddDepartment.Attributes.Add("title", this.objLanguage.GetLanguageConversion("Create_new_department"));
                    this.lblErrorDuplicateMessage.Text = this.objLanguage.GetLanguageConversion("Department_Duplicate_ErrorMessage");
                }
                else
                {
                    this.lbl_Department.Text = this.deptScreenName;
                    this.lbl_DeptName.Text = this.deptScreenName;
                    this.lblAddDepartmentNote.Text = string.Concat("<span style='margin-left: 1px; color: grey; font-size: 11px; vertical-align: top;'>", this.objLanguage.GetLanguageConversion("Add_Department_Note").Replace("department", this.deptScreenName).Replace(",", ",</span><br /><span style='color: grey; font-size: 11px; vertical-align: top;margin-left:3px;line-height:150%'>"), "</span>");
                    this.imgAddDepartment.Attributes.Add("title", this.objLanguage.GetLanguageConversion("Create_new_department").Replace("department", this.deptScreenName));
                    this.lblErrorDuplicateMessage.Text = this.objLanguage.GetLanguageConversion("Department_Duplicate_ErrorMessage").Replace("Department", this.deptScreenName);
                }
            }
            this.btnBackRegister.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btn_createAccount.Text = this.objLanguage.GetLanguageConversion("Create_An_Account");
            this.req_firstName.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.req_ddldepartment.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress1.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress2.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress3.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress4.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqAddress5.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqCountry.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_Select_Country");
            this.reqTelephone.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqemail.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Email_Address_Example");
            this.reqpassword.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.reqconfirmPassword.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.CompareValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Please_make_sure_your_passwords_match");
            this.RequiredFieldValidator2.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.RegularExpressionValidator2.ErrorMessage = this.objLanguage.GetLanguageConversion("Email_Address_Example").Replace(". ", ". <br />");
            this.chkAddEmilDmc.Text = this.objLanguage.GetLanguageConversion("Subscribe_to_EDM_Database");
            this.lbl_password.Text = this.objLanguage.GetLanguageConversion("Password");
            this.lbl_confirmPassword.Text = this.objLanguage.GetLanguageConversion("Confirm_Password");
            if (ConnectionClass.SystemName.ToString().ToLower() == "dmc2" && B2B_Registration.AccountID == (long)224)
            {
                this.lbl_Department.Text = this.objLanguage.GetLanguageConversion("State_Cricket_Association");
                this.lbl_DeptName.Text = this.objLanguage.GetLanguageConversion("State_Cricket_Association");
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                B2B_Registration.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SitePath != null && ConnectionClass.SitePath != "")
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.IsmailChimpEnabled != null)
            {
                if (ConnectionClass.IsmailChimpEnabled != "true")
                {
                    this.chkAddEmilDmc.Visible = false;
                }
                else
                {
                    this.chkAddEmilDmc.Visible = true;
                }
            }
            if (B2B_Registration.AccountID != (long)0)
            {
                foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)B2B_Registration.CompanyID, B2B_Registration.AccountID).Rows)
                {
                    this.clientid = Convert.ToInt32(row["clientID"]);
                    this.createuserid = Convert.ToInt32(row["createdBy"]);
                }
            }
            if (base.Return_ApprovalRegistration_Settings("addnewdept") != "True")
            {
                this.imgAddDepartment.Visible = false;
                this.lblAddDepartmentNote.Visible = false;
            }
            else
            {
                this.imgAddDepartment.Visible = true;
                this.lblAddDepartmentNote.Visible = true;
            }
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    string str = base.Return_ApprovalRegistration_Settings("userdepttype");
                    if (str == "L")
                    {
                        this.ddl_Department.Visible = true;
                    }
                    else if (str == "D")
                    {
                        try
                        {
                            this.ddl_Department.Visible = false;
                            this.lblDepartment.Visible = true;
                            long num = (long)0;
                            num = (this.hdnNewDeptID.Value != "" ? Convert.ToInt64(this.hdnNewDeptID.Value) : Convert.ToInt64(base.Return_ApprovalRegistration_Settings("departmentid")));
                            DataSet departmentName = LoginBasePage.GetDepartmentName(num);
                            if (departmentName.Tables[0].Rows.Count > 0)
                            {
                                string str1 = departmentName.Tables[0].Rows[0]["DeptName"].ToString();
                                this.lblDepartment.Text = base.SpecialDecode(str1);
                                this.divDepartmentName.Style.Add("height", "27px");
                                this.divDepartmentNameLeft.Style.Add("padding-top", "0px");
                            }
                            this.HdnDepartmentID.Value = num.ToString();
                        }
                        catch
                        {
                        }
                    }
                    string str2 = base.Return_ApprovalRegistration_Settings("prefiladded");
                    this.isPrefill.Value = str2.ToLower();
                    if (str2 == "True" && !base.IsPostBack)
                    {
                        this.PreFillAddressFileds();
                    }
                    if (base.Return_ApprovalRegistration_Settings("overwriteadded") != "True")
                    {
                        this.DisableAddressFileds();
                    }
                    this.div_Approver_Header.Visible = false;
                    this.div_Approver_Header.Attributes.Add("style", "display:none");
                    this.div_Approver_Content.Visible = false;
                    this.div_Approver_Content.Attributes.Add("style", "display:none");
                }
                else
                {
                    string str3 = base.Return_ApprovalSystem_Settings("newuserapprove");
                    this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                    if (str3.ToLower().Trim() != "true")
                    {
                        string str4 = base.Return_ApprovalRegistration_Settings("userdepttype");
                        if (str4 == "L")
                        {
                            this.ddl_Department.Visible = true;
                        }
                        else if (str4 == "D")
                        {
                            try
                            {
                                this.ddl_Department.Visible = false;
                                this.lblDepartment.Visible = true;
                                long num1 = (long)0;
                                num1 = (this.hdnNewDeptID.Value != "" ? Convert.ToInt64(this.hdnNewDeptID.Value) : Convert.ToInt64(base.Return_ApprovalRegistration_Settings("departmentid")));
                                DataSet dataSet = LoginBasePage.GetDepartmentName(num1);
                                if (dataSet.Tables[0].Rows.Count > 0)
                                {
                                    string str5 = dataSet.Tables[0].Rows[0]["DeptName"].ToString();
                                    this.lblDepartment.Text = base.SpecialDecode(str5);
                                    this.divDepartmentName.Style.Add("height", "27px");
                                    this.divDepartmentNameLeft.Style.Add("padding-top", "0px");
                                }
                                this.HdnDepartmentID.Value = num1.ToString();
                            }
                            catch
                            {
                            }
                        }
                        string str6 = base.Return_ApprovalRegistration_Settings("prefiladded");
                        this.isPrefill.Value = str6.ToLower();
                        if (str6 == "True" && !base.IsPostBack)
                        {
                            this.PreFillAddressFileds();
                        }
                        if (base.Return_ApprovalRegistration_Settings("overwriteadded") != "True")
                        {
                            this.DisableAddressFileds();
                        }
                        this.div_Approver_Header.Visible = false;
                        this.div_Approver_Header.Attributes.Add("style", "display:none");
                        this.div_Approver_Content.Visible = false;
                        this.div_Approver_Content.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        if (this.approvalType != "u")
                        {
                            this.div_Approver_Header.Visible = false;
                            this.div_Approver_Header.Attributes.Add("style", "display:none");
                            this.div_Approver_Content.Visible = false;
                            this.div_Approver_Content.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            this.div_Approver_Header.Visible = true;
                            this.div_Approver_Header.Attributes.Add("style", "display:block");
                            this.div_Approver_Content.Visible = true;
                            this.div_Approver_Content.Attributes.Add("style", "display:block");
                            this.RequiredFieldValidator2.Enabled = true;
                        }
                        string str7 = base.Return_ApprovalRegistration_Settings("userdepttype");
                        if (str7 == "L")
                        {
                            this.ddl_Department.Visible = true;
                        }
                        else if (str7 == "D")
                        {
                            try
                            {
                                this.ddl_Department.Visible = false;
                                this.lblDepartment.Visible = true;
                                long num2 = (long)0;
                                num2 = (this.hdnNewDeptID.Value != "" ? Convert.ToInt64(this.hdnNewDeptID.Value) : Convert.ToInt64(base.Return_ApprovalRegistration_Settings("departmentid")));
                                DataSet departmentName1 = LoginBasePage.GetDepartmentName(num2);
                                if (departmentName1.Tables[0].Rows.Count > 0)
                                {
                                    string str8 = departmentName1.Tables[0].Rows[0]["DeptName"].ToString();
                                    this.lblDepartment.Text = base.SpecialDecode(str8);
                                    this.divDepartmentName.Style.Add("height", "27px");
                                    this.divDepartmentNameLeft.Style.Add("padding-top", "0px");
                                }
                                this.HdnDepartmentID.Value = num2.ToString();
                            }
                            catch
                            {
                            }
                        }
                        string str9 = base.Return_ApprovalRegistration_Settings("prefiladded");
                        this.isPrefill.Value = str9.ToLower();
                        if (str9 == "True" && !base.IsPostBack)
                        {
                            this.PreFillAddressFileds();
                        }
                        if (base.Return_ApprovalRegistration_Settings("overwriteadded") != "True")
                        {
                            this.DisableAddressFileds();
                        }
                    }
                }
            }
            this.lbl_BillAddress1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lbl_BillAddress2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lbl_BillCity.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lbl_BillState.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblBillZipCode.Text = this.comm.GetAddressLabelByKey("Address5");
            this.lblDelAddLabel.Text = this.objLanguage.GetLanguageConversion("Address_Label");
            this.lblDelAdd1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lblDelAdd2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lblDelAdd3.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lblDelAdd4.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblDelAdd5.Text = this.comm.GetAddressLabelByKey("Address5");
            this.lblDelCountry.Text = this.objLanguage.GetLanguageConversion("Country");
            this.lblDelTelephone.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lblDelFax.Text = this.objLanguage.GetLanguageConversion("Fax");
            this.lblCopyToInvoice.Text = this.objLanguage.GetLanguageConversion("This_is_my_Invoice_address");
            this.lblInvAddLabel.Text = this.objLanguage.GetLanguageConversion("Address_Label");
            this.lblInvAdd1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lblInvAdd2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lblInvAdd3.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lblInvAdd4.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lblInvAdd5.Text = this.comm.GetAddressLabelByKey("Address5");
            this.lblInvCountry.Text = this.objLanguage.GetLanguageConversion("Country");
            this.lblInvTelephone.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lblInvFax.Text = this.objLanguage.GetLanguageConversion("Fax");
            if (this.comm.GetMandatoryByKey("Address1").ToLower() != "true")
            {
                this.reqAddress1.Enabled = false;
                this.lblAdd1.Visible = false;
                this.lblDelAddMandatory1.Visible = false;
                this.rfvDelAdd1.Enabled = false;
                this.lblInvAddMandatory1.Visible = false;
                this.rfvInvAdd1.Enabled = false;
            }
            else
            {
                this.reqAddress1.Enabled = true;
                this.lblAdd1.Visible = true;
                this.lblDelAddMandatory1.Visible = true;
                this.rfvDelAdd1.Enabled = true;
                this.lblInvAddMandatory1.Visible = true;
                this.rfvInvAdd1.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("Address2").ToLower() != "true")
            {
                this.reqAddress2.Enabled = false;
                this.lblAdd2.Visible = false;
                this.lblDelAddMandatory2.Visible = false;
                this.rfvDelAdd2.Enabled = false;
                this.lblInvAddMandatory2.Visible = false;
                this.rfvInvAdd2.Enabled = false;
            }
            else
            {
                this.reqAddress2.Enabled = true;
                this.lblAdd2.Visible = true;
                this.lblDelAddMandatory2.Visible = true;
                this.rfvDelAdd2.Enabled = true;
                this.lblInvAddMandatory2.Visible = true;
                this.rfvInvAdd2.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("Address3").ToLower() != "true")
            {
                this.reqAddress3.Enabled = false;
                this.lblAdd3.Visible = false;
                this.lblDelAddMandatory3.Visible = false;
                this.rfvDelAdd3.Enabled = false;
                this.lblInvAddMandatory3.Visible = false;
                this.rfvInvAdd3.Enabled = false;
            }
            else
            {
                this.reqAddress3.Enabled = true;
                this.lblAdd3.Visible = true;
                this.lblDelAddMandatory3.Visible = true;
                this.rfvDelAdd3.Enabled = true;
                this.lblInvAddMandatory3.Visible = true;
                this.rfvInvAdd3.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("Address4").ToLower() != "true")
            {
                this.reqAddress4.Enabled = false;
                this.lblAdd4.Visible = false;
                this.lblDelAddMandatory4.Visible = false;
                this.rfvDelAdd4.Enabled = false;
                this.lblInvAddMandatory4.Visible = false;
                this.rfvInvAdd4.Enabled = false;
            }
            else
            {
                this.reqAddress4.Enabled = true;
                this.lblAdd4.Visible = true;
                this.lblDelAddMandatory4.Visible = true;
                this.rfvDelAdd4.Enabled = true;
                this.lblInvAddMandatory4.Visible = true;
                this.rfvInvAdd4.Enabled = true;
            }
            if (this.comm.GetMandatoryByKey("Address5").ToLower() != "true")
            {
                this.reqAddress5.Enabled = false;
                this.lblAdd5.Visible = false;
                this.lblDelAddMandatory5.Visible = false;
                this.rfvDelAdd5.Enabled = false;
                this.lblInvAddMandatory5.Visible = false;
                this.rfvInvAdd5.Enabled = false;
            }
            else
            {
                this.reqAddress5.Enabled = true;
                this.lblAdd5.Visible = true;
                this.lblDelAddMandatory5.Visible = true;
                this.rfvDelAdd5.Enabled = true;
                this.lblInvAddMandatory5.Visible = true;
                this.rfvInvAdd5.Enabled = true;
            }
            try
            {
                if (ConnectionClass.SecureDocFilepath != null)
                {
                    secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", B2B_Registration.AccountID, "\\banners\\" };
                    this.bannerImagePath = string.Concat(secureDocFilepath);
                }
                DataTable dataTable = new DataTable();
                dataTable = LoginBasePage.Select_CompanyID(B2B_Registration.AccountID);
                IEnumerator enumerator = dataTable.Rows.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        B2B_Registration.AccCompanyID = Convert.ToInt32(current["CompanyID"].ToString());
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
                DataTable dataTable1 = CMSBasePage.headerSelect(B2B_Registration.AccCompanyID, Convert.ToInt32(B2B_Registration.AccountID), "H");
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    if (dataRow["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageHeader = dataRow["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageHeader)))
                        {
                            object[] accountID = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", B2B_Registration.AccountID, "&amp;cid=", B2B_Registration.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID);
                        }
                        else
                        {
                            object[] objArray = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageHeader, "&amp;type=b&amp;aid=", B2B_Registration.AccountID, "&amp;cid=", B2B_Registration.AccCompanyID };
                            this.BannerImageHeader = string.Concat(objArray);
                        }
                        if (!Convert.ToBoolean(dataRow["IsLogoEnlarged"]))
                        {
                            this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                            this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                        }
                        else
                        {
                            this.tblheaderimage.Attributes["class"] = "width100p";
                            this.tdheaderimage.Attributes["class"] = "width100p paddingBottom5 floatLeft";
                        }
                        int width = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath1 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", B2B_Registration.AccountID, "/banners/", dataRow["logoImage"].ToString() };
                            string str10 = string.Concat(secureDocFilepath1);
                            width = System.Drawing.Image.FromFile(str10).Width;
                        }
                        if (ConnectionClass.RewriteModule.ToLower() != "on")
                        {
                            if (this.BannerImageHeader == "")
                            {
                                if (this.IsHomePageVisible != "1")
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl("<img src='javascript:void(0);' class='floatLeft' alt=' '/>"));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<a href='", this.strSitePath, " target='_self' ><img src='#' class='floatLeft' /></a>")));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow["IsLogoEnlarged"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' alt=' '/></a>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' alt=' '/></a>")));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/></a>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width:950px;' class='floatLeft' alt=' '/></a>")));
                                }
                            }
                            else if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/></a>")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width:950px;' class='floatLeft' alt=' '/></a>")));
                            }
                        }
                        else if (this.BannerImageHeader == "")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' /></a>")));
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(dataRow["IsLogoEnlarged"]))
                            {
                                if (width <= 950)
                                {
                                    ControlCollection controls = this.ph_headerLeft.Controls;
                                    string[] strArrays = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' /></a>" };
                                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                                }
                                else
                                {
                                    ControlCollection controlCollections = this.ph_headerLeft.Controls;
                                    bannerImageFooter = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    ControlCollection controls1 = this.ph_headerLeft.Controls;
                                    string[] strArrays1 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' class='floatLeft' /></a>" };
                                    controls1.Add(new LiteralControl(string.Concat(strArrays1)));
                                }
                                else
                                {
                                    ControlCollection controlCollections1 = this.ph_headerLeft.Controls;
                                    string[] strArrays2 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
                                }
                            }
                            else if (width <= 950)
                            {
                                ControlCollection controls2 = this.ph_headerLeft.Controls;
                                string[] strArrays3 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' class='floatLeft' /></a>" };
                                controls2.Add(new LiteralControl(string.Concat(strArrays3)));
                            }
                            else
                            {
                                ControlCollection controlCollections2 = this.ph_headerLeft.Controls;
                                string[] strArrays4 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(strArrays4)));
                            }
                        }
                        else if (Convert.ToBoolean(dataRow["IsLogoEnlarged"]))
                        {
                            if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (Convert.ToBoolean(dataRow["IsLogoResized"]))
                        {
                            if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (width <= 950)
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                        }
                    }
                    if (dataRow["logoType"].ToString().Trim() == "T")
                    {
                        this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                        this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                        string str11 = null;
                        str11 = (dataRow["logoText"].ToString().Trim().Length <= 40 ? dataRow["logoText"].ToString().Trim() : dataRow["logoText"].ToString().Trim().Substring(0, 40));
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext'> <label id='lbl_headerTextLeft' class='logoText'>", base.SpecialDecode(str11), "</label></div>")));
                    }
                    if (dataRow["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                    string str12 = null;
                    str12 = dataRow["logoTemplate"].ToString().Trim();
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", base.SpecialDecode(str12), "</label>")));
                }
                if (dataTable1.Rows.Count == 0)
                {
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                }
                StringBuilder stringBuilder = new StringBuilder();
                DataTable dataTable2 = CMSBasePage.CMSPages_get(Convert.ToInt32(B2B_Registration.AccCompanyID), Convert.ToInt32(B2B_Registration.AccountID), 0);
                dataTable2.Select("ShowPagesIN ='H' or ShowPagesIN ='B'");
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    if (!(row1["showPagesIn"].ToString().Trim() == "B") && !(row1["showPagesIn"].ToString().Trim() == "F"))
                    {
                        continue;
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        if (row1["systemName"].ToString().ToLower().Trim() == "home")
                        {
                            string[] strArrays5 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", row1["pageName"].ToString().Trim(), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays5));
                        }
                        else if (row1["systemName"].ToString().ToLower().Trim() == "products")
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", row1["pageName"].ToString().Trim(), " </a></div>"));
                        }
                        else if (row1["systemName"].ToString().ToLower().Trim() != "sitemap")
                        {
                            string[] strArrays6 = new string[] { "<div><a href='", null, null, null, null };
                            secureDocFilepath = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), ConnectionClass.KeySeparator, Convert.ToInt32(row1["pageID"].ToString()), ConnectionClass.FileExtension };
                            strArrays6[1] = base.ResolveUrl(string.Concat(secureDocFilepath));
                            strArrays6[2] = "'> ";
                            strArrays6[3] = row1["pageName"].ToString().Trim();
                            strArrays6[4] = " </a></div>";
                            stringBuilder.Append(string.Concat(strArrays6));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", row1["pageName"].ToString().Trim(), " </a></div>"));
                        }
                    }
                    else if (row1["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        bannerImageFooter = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", row1["pageName"].ToString().Trim(), " </a></div>" };
                        stringBuilder.Append(string.Concat(bannerImageFooter));
                    }
                    else if (row1["systemName"].ToString().ToLower().Trim() == "products")
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", row1["pageName"].ToString().Trim(), " </a></div>"));
                    }
                    else if (row1["systemName"].ToString().ToLower().Trim() != "sitemap")
                    {
                        secureDocFilepath = new object[] { "<div><a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row1["pageID"].ToString()), "'> ", row1["pageName"].ToString().Trim().Trim(), "</a></div>" };
                        stringBuilder.Append(string.Concat(secureDocFilepath));
                    }
                    else
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", row1["pageName"].ToString().Trim(), " </a></div>"));
                    }
                }
                this.ph_footer.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                DataTable dataTable3 = CMSBasePage.headerSelect(Convert.ToInt32(B2B_Registration.AccCompanyID), Convert.ToInt32(B2B_Registration.AccountID), "F");
                foreach (DataRow dataRow1 in dataTable3.Rows)
                {
                    if (dataRow1["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageFooter = dataRow1["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageFooter)))
                        {
                            secureDocFilepath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", B2B_Registration.AccountID, "&amp;cid=", B2B_Registration.AccCompanyID };
                            this.BannerImageHeader = string.Concat(secureDocFilepath);
                        }
                        else
                        {
                            secureDocFilepath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageFooter, "&amp;type=b&amp;aid=", B2B_Registration.AccountID, "&amp;cid=", B2B_Registration.AccCompanyID };
                            this.BannerImageFooter = string.Concat(secureDocFilepath);
                        }
                        if (!Convert.ToBoolean(dataRow1["IsLogoEnlarged"]))
                        {
                            this.divfooterMain.Attributes["class"] = "footer_div";
                            this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        }
                        else
                        {
                            this.divfooterMain.Attributes["class"] = "footer_divsub";
                        }
                        int width1 = 0;
                        if (this.BannerImageHeader != "")
                        {
                            secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", B2B_Registration.AccountID, "/banners/", dataRow1["logoImage"].ToString() };
                            string str13 = string.Concat(secureDocFilepath);
                            width1 = System.Drawing.Image.FromFile(str13).Width;
                        }
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            if (this.IsHomePageVisible == "1")
                            {
                                if (Convert.ToBoolean(dataRow1["IsLogoEnlarged"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls3 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                        controls3.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections3 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                        controlCollections3.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                }
                                else if (Convert.ToBoolean(dataRow1["IsLogoResized"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls4 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                        controls4.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections4 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                        controlCollections4.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                }
                                else if (width1 <= 950)
                                {
                                    ControlCollection controls5 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                    controls5.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections5 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' />")));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow1["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                            }
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(dataRow1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls6 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                    controls6.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections6 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(dataRow1["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls7 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                    controls7.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections7 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                ControlCollection controls8 = this.ph_copyWriter.Controls;
                                bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                controls8.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                            }
                            else
                            {
                                ControlCollection controlCollections8 = this.ph_copyWriter.Controls;
                                bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                controlCollections8.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                            }
                        }
                        else if (Convert.ToBoolean(dataRow1["IsLogoEnlarged"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' />")));
                            }
                        }
                        else if (Convert.ToBoolean(dataRow1["IsLogoResized"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                            }
                        }
                        else if (width1 <= 950)
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                        }
                    }
                    if (dataRow1["logoType"].ToString().Trim() == "T")
                    {
                        this.divfooterMain.Attributes["class"] = "footer_div";
                        this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", base.SpecialDecode(dataRow1["logoText"].ToString().Trim()), "</label>")));
                    }
                    if (dataRow1["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", base.SpecialDecode(dataRow1["logoTemplate"].ToString().Trim()), "</label>")));
                }
                if (dataTable3.Rows.Count == 0)
                {
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                }
            }
            catch
            {
            }
            if (ConnectionClass.SystemName.ToString().ToLower() == "dmc2" && B2B_Registration.AccountID == (long)225 || B2B_Registration.AccountID == (long)242)
            {
                if (B2B_Registration.AccountID == (long)225)
                {
                    this.lbl_BillAddress1.Text = this.objLanguage.GetLanguageConversion("Auskick_Centre_Name");
                }
                else if (B2B_Registration.AccountID == (long)242)
                {
                    this.lbl_BillAddress1.Text = this.objLanguage.GetLanguageConversion("Centre_Name");
                }
                this.reqAddress1.Enabled = true;
                this.lblAdd1.Visible = true;
            }
            if (!(ConnectionClass.SystemName.ToString().ToLower() == "dmc2") || B2B_Registration.AccountID != (long)242)
            {
                this.lblDeptMandatry.Visible = false;
                this.req_ddldepartment.Enabled = false;
            }
            else
            {
                this.lbl_Department.Text = this.objLanguage.GetLanguageConversion("District");
                this.lbl_DeptName.Text = this.objLanguage.GetLanguageConversion("District");
                this.lblDeptMandatry.Visible = true;
                this.req_ddldepartment.Enabled = true;
            }
            if (base.Return_ApprovalRegistration_Settings("issinglefield") == "True")
            {
                this.div_lblemail.Style.Add("display", "none");
                this.div_txtemail.Style.Add("display", "none");
                this.trcost.Style.Add("display", "none");
                this.chkAddEmilDmc.Style.Add("display", "none");
                this.costSmartTdRight.Style.Add("padding-left", "10px");
                this.txtpassword.TextMode = TextBoxMode.SingleLine;
                this.txt_confirmPassword.TextMode = TextBoxMode.SingleLine;
                this.lbl_password.Text = this.objLanguage.GetLanguageConversion("Enter_Email_Address");
                this.lbl_confirmPassword.Text = this.objLanguage.GetLanguageConversion("Confirm_email_address");

                this.spn_txtpassemail.Text = this.objLanguage.GetLanguageConversion("Email_address_already_exists_please_enter_another_email_address");
                this.spn_txt_email.Text = this.objLanguage.GetLanguageConversion("Email_address_already_exists_please_enter_another_email_address");
                this.spn_txtPassEmailExists.Text = this.objLanguage.GetLanguageConversion("Email_address_already_exists_please_enter_another_email_address");

                this.CompareValidator1.ErrorMessage = "Please make sure your emails match.";
                this.txtpassword.Attributes.Add("onkeyup", "javascript: CopyEmailtoEmail(this,this.value);");
                this.txtpassword.Attributes.Add("onblur", " javascript: CopyEmailtoEmail(this.id,this.value);");
                this.spn_txtpassemail.Style.Add("display", "block");
                this.spn_txtpassemail_Rej.Style.Add("display", "block");
                this.Regexp_validateEmailForCostsmart.Style.Add("display", "block");
                this.Regexp_validateEmailForCostsmart.ControlToValidate = this.txtpassword.ID;
                this.Regexp_validateEmailForCostsmart.Visible = true;
            }
            commonclass _commonclass = this.comm;
            DateTime now = DateTime.Now;
            this.CreatedDate = Convert.ToDateTime(_commonclass.Eprint_return_ActualDate_Before_View(now.ToString(), B2B_Registration.CompanyID, this.createuserid, true));
            base.Title = commonclass.pageTitle("Registration", Convert.ToInt32(B2B_Registration.CompanyID), Convert.ToInt32(B2B_Registration.AccountID));
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            ((Panel)base.Master.FindControl("HeaderPanel")).Visible = false;
            ((Panel)base.Master.FindControl("FooterPanel")).Visible = false;
        }

        public void PreFillAddressFileds()
        {
            long num = (long)0;
            if (this.ddl_Department.Visible)
            {
                num = Convert.ToInt64(this.ddl_Department.SelectedValue);
            }
            else if (this.HdnDepartmentID.Value != null && this.HdnDepartmentID.Value != "")
            {
                num = Convert.ToInt64(this.HdnDepartmentID.Value);
            }
            DataTable item = LoginBasePage.GetDepartmentName(num).Tables[1];
            if (item.Rows.Count <= 0)
            {
                this.txtBillAddress1.Text = "";
                this.txtBillAddress2.Text = "";
                this.txtBillCity.Text = "";
                this.txtBillZipCode.Text = "";
                this.txtBillFax.Text = "";
                this.txtBillState.Text = "";
                this.txtBillTelephone.Text = "";
            }
            else
            {
                foreach (DataRow row in item.Rows)
                {
                    this.txtBillAddress1.Text = base.SpecialDecode(row["Address"].ToString());
                    this.txtBillAddress2.Text = base.SpecialDecode(row["AddressLine2"].ToString());
                    this.txtBillCity.Text = base.SpecialDecode(row["City"].ToString());
                    this.txtBillZipCode.Text = row["ZipCode"].ToString();
                    this.txtBillState.Text = base.SpecialDecode(row["State"].ToString());
                    this.txtBillTelephone.Text = base.SpecialDecode(row["Telephone"].ToString());
                    this.txtBillFax.Text = base.SpecialDecode(row["Fax"].ToString());
                    this.obj.SetDDLText(this.ddlBillCountry, base.SpecialDecode(row["Country"].ToString()));
                }
            }
        }
    }
}