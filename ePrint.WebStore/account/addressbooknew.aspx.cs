using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ePrint.WebStore.account
{
    public partial class addressbooknew : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected usercontrols_leftpanel panel1;

        //protected Label LblErrorMsg;

        //protected HtmlGenericControl DivLblErrorMsg;

        //protected Label lbl_addressHeader;

        //protected Label lbl_addressLabel;

        //protected TextBox txt_addressLabel;

        //protected Label lbl_addressLabel_note;

        //protected HtmlGenericControl div_lbladdressLabel;

        //protected Label AddressLabel;

        //protected TextBox txt_firstName;

        //protected HtmlGenericControl div_lblfirstName;

        //protected Label lbl_telephone;

        //protected TextBox txt_telephone;

        //protected Label lbl_lastName;

        //protected TextBox txt_lastName;

        //protected HtmlGenericControl div_lbllastName;

        //protected Label lbl_fax;

        //protected TextBox txt_fax;

        //protected Label lbl_country;

        //protected HtmlGenericControl Label5;

        //protected DropDownList ddl_Country;

        //protected Label lbl_Address1;

        //protected HtmlGenericControl lblMandAdd1;

        //protected TextBox txt_address;

        //protected Label lbl_Address2;

        //protected HtmlGenericControl lblMandAdd2;

        //protected TextBox txt_address2;

        //protected Label lbl_Address3;

        //protected HtmlGenericControl lblMandAdd3;

        //protected TextBox txt_city;

        //protected Label lbl_Address4;

        //protected HtmlGenericControl lblMandAdd4;

        //protected TextBox txt_state;

        //protected Label lbl_Address5;

        //protected HtmlGenericControl lblMandAdd5;

        //protected TextBox txt_zipCode;

        //protected Label Label7;

        //protected TextBox txtApproverEmail;

        //protected HiddenField hdnApproverID;

        //protected HtmlGenericControl DivApproverEmail;

        //protected Label lblReqiEmail;

        //protected CheckBox chk_billing_address;

        //protected Label lblDefaultBilling;

        //protected CheckBox chk_shipping_address;

        //protected Label lblDefaultShipping;

        //protected Button btnUpdateAddress;

        //protected HiddenField hdnIsMandAdd1;

        //protected HiddenField hdnIsMandAdd2;

        //protected HiddenField hdnIsMandAdd3;

        //protected HiddenField hdnIsMandAdd4;

        //protected HiddenField hdnIsMandAdd5;

        //protected HiddenField hdnValidation;

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public char KeySeparator;

        public int IsAdditionAddress;

        public int UserID;

        public long AddressID;

        public long ContactID;

        public long StoreUserID;

        public long DefaultBillingID;

        public long DefaultShippingID;

        public static int companyID;

        public static long AccountID;

        public long DepartmentID;

        public string Rewritemodule;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string Subject = string.Empty;

        public string EmailBodyApprover = string.Empty;

        public string RedirectTo = string.Empty;

        public string PostCode = string.Empty;

        public string DateFormat = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string approvalType = string.Empty;

        public string FirstName = string.Empty;

        public string LastName = string.Empty;

        public string UserEmailID = string.Empty;

        public string CompanyName = string.Empty;

        public string UserType = string.Empty;

        public static string lblMGSA;

        public int ClientID;

        public int lblMGS;

        public bool IsPrivate_SystemName;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private DateTime CreatedDate;

        public string strImagepath = BaseClass.imagePath();

        private storeEmail objEmail = new storeEmail();

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

        static addressbooknew()
        {
            addressbooknew.companyID = 0;
            addressbooknew.AccountID = (long)0;
            addressbooknew.lblMGSA = "";
        }

        public addressbooknew()
        {
        }

        protected void OnClick_btnUpdateAddress(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            if (this.AddressID != (long)0)
            {
                if (this.DefaultBillingID == this.AddressID)
                {
                    this.chk_billing_address.Checked = true;
                }
                if (this.DefaultShippingID == this.AddressID)
                {
                    this.chk_shipping_address.Checked = true;
                }
            }
            if (this.chk_billing_address.Checked)
            {
                num = 1;
            }
            if (this.chk_shipping_address.Checked)
            {
                num1 = 1;
            }
            string empty = string.Empty;
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"] == null)
                {
                    this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                    if (base.Return_ApprovalSystem_Settings("editeduserapprove").ToLower().Trim() != "true")
                    {
                        if (this.AddressID != (long)0)
                        {
                            OrderBasePage.Update_BillingShipping_Address(this.AddressID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), this.txt_addressLabel.Text.Trim(), this.txt_zipCode.Text.Trim());
                            OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                        }
                        else
                        {
                            this.AddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_zipCode.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), num, num1, this.txt_addressLabel.Text.Trim(), this.CreatedDate);
                            OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                        }
                    }
                    else if (this.approvalType == "u" && this.UserType == "u" || this.approvalType == "u" && this.UserType == "m" || this.approvalType == "u" && this.UserType == "d")
                    {
                        OrderBasePage.Insert_Personal_Info_Address_temp(this.StoreUserID, addressbooknew.AccountID, base.SpecialEncode(this.txt_addressLabel.Text.Trim()), this.txt_fax.Text.Trim(), this.txt_telephone.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), base.SpecialEncode(this.txt_address.Text.Trim()), base.SpecialEncode(this.txt_address2.Text.Trim()), base.SpecialEncode(this.txt_city.Text.Trim()), base.SpecialEncode(this.txt_state.Text.Trim()), this.txt_zipCode.Text.Trim(), this.AddressID, num, num1, this.txtApproverEmail.Text.Trim(), this.approvalType, "a");
                        this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, addressbooknew.companyID, addressbooknew.AccountID, "B2B User Profile Modification", "approver", (long)0, this.txtApproverEmail.Text);
                    }
                    else if (this.approvalType == "a" && this.UserType == "u" || this.approvalType == "a" && this.UserType == "d" || this.approvalType == "da" && this.UserType == "u")
                    {
                        string str = string.Empty;
                        string empty1 = string.Empty;
                        DataSet dataSet = new DataSet();
                        dataSet = LoginBasePage.ApproversEmail_Select(addressbooknew.AccountID, this.DepartmentID);
                        DataTable dataTable = new DataTable();
                        dataTable = dataSet.Tables[0];
                        DataTable item = new DataTable();
                        item = dataSet.Tables[1];
                        if (this.approvalType == "a")
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                str = row["email"].ToString();
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
                                str = string.Concat(dataRow["email"].ToString(), ",");
                                empty1 = string.Concat(dataRow["contactID"].ToString(), "~", dataRow["email"].ToString(), ",");
                            }
                            foreach (DataRow row1 in item.Rows)
                            {
                                str = string.Concat(str, row1["email"].ToString(), ",");
                                string[] strArrays = new string[] { empty1, row1["contactID"].ToString(), "~", row1["email"].ToString(), "," };
                                empty1 = string.Concat(strArrays);
                            }
                        }
                        str = str.Remove(str.Length - 1, 1);
                        empty1 = empty1.Remove(empty1.Length - 1, 1);
                        OrderBasePage.Insert_Personal_Info_Address_temp(this.StoreUserID, addressbooknew.AccountID, base.SpecialEncode(this.txt_addressLabel.Text.Trim()), this.txt_fax.Text.Trim(), this.txt_telephone.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), base.SpecialEncode(this.txt_address.Text.Trim()), base.SpecialEncode(this.txt_address2.Text.Trim()), base.SpecialEncode(this.txt_city.Text.Trim()), base.SpecialEncode(this.txt_state.Text.Trim()), this.txt_zipCode.Text.Trim(), this.AddressID, num, num1, str, this.approvalType, "a");
                        string[] strArrays1 = empty1.Split(new char[] { ',' });
                        for (int i = 0; i < (int)strArrays1.Length; i++)
                        {
                            string str1 = strArrays1[i];
                            string[] strArrays2 = str1.Split(new char[] { '~' });
                            if (strArrays2[0].ToString() != "" && strArrays2[0].ToString() != null)
                            {
                                this.objEmail.B2BProfileApprovalDetails_Email(this.StoreUserID, addressbooknew.companyID, addressbooknew.AccountID, "B2B User Profile Modification", "approver", Convert.ToInt64(strArrays2[0].ToString()), strArrays2[1].ToString());
                            }
                        }
                    }
                    else if (this.AddressID != (long)0)
                    {
                        OrderBasePage.Update_BillingShipping_Address(this.AddressID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), this.txt_addressLabel.Text.Trim(), this.txt_zipCode.Text.Trim());
                        OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                    }
                    else
                    {
                        this.AddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_zipCode.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), num, num1, this.txt_addressLabel.Text.Trim(), this.CreatedDate);
                        OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                    }
                }
                else if (this.AddressID != (long)0)
                {
                    OrderBasePage.Update_BillingShipping_Address(this.AddressID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), this.txt_addressLabel.Text.Trim(), this.txt_zipCode.Text.Trim());
                    OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                }
                else
                {
                    this.AddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, this.txt_firstName.Text.Trim(), this.txt_lastName.Text.Trim(), this.txt_address.Text.Trim(), this.txt_address2.Text.Trim(), this.txt_city.Text.Trim(), this.txt_state.Text.Trim(), this.txt_zipCode.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_email.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), num, num1, this.txt_addressLabel.Text.Trim(), this.CreatedDate);
                    OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbook", ConnectionClass.FileExtension));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbook.aspx"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/account.aspx' >My Account<span Class='floatLeft'>&nbsp;</span></a><a Class='floatLeft' href ='", BaseClass.SitePath, "account/addressbooknew.aspx' ><span Class='floatLeft'>&nbsp;>>&nbsp;</span></a>Edit Address" };
            label.Text = string.Concat(sitePath);
            this.LblErrorMsg.Text = this.objLanguage.GetLanguageConversion("Your_Last_Edit_Profile_Approval_Is_Pending");
            this.lbl_addressLabel.Text = this.objLanguage.GetLanguageConversion("Address_Label");
            this.AddressLabel.Text = this.objLanguage.GetLanguageConversion("First_Name");
            this.lbl_telephone.Text = this.objLanguage.GetLanguageConversion("Telephone");
            this.lbl_lastName.Text = this.objLanguage.GetLanguageConversion("Last_Name");
            this.lbl_fax.Text = this.objLanguage.GetLanguageConversion("Fax");
            this.lbl_country.Text = this.objLanguage.GetLanguageConversion("Country");
            this.Label7.Text = this.objLanguage.GetLanguageConversion("Approver_Email");
            this.lblReqiEmail.Text = this.objLanguage.GetLanguageConversion("designated_approver_email_not_contains_in_this_Account");
            this.chk_billing_address.Text = this.objLanguage.GetLanguageConversion("Use_above_address_as_my_default_Invoice_address");
            this.chk_shipping_address.Text = this.objLanguage.GetLanguageConversion("Use_above_address_as_my_default_Delivery_Address");
            this.btnUpdateAddress.Text = this.objLanguage.GetLanguageConversion("Save_Address");
            this.txt_telephone.Attributes.Add("onkeypress", "javascript:return HideShowError('divTelephone')");
            this.txt_address.Attributes.Add("onkeypress", "javascript:return HideShowError('divAdd1')");
            this.txt_address2.Attributes.Add("onkeypress", "javascript:return HideShowError('divAdd2')");
            this.txt_city.Attributes.Add("onkeypress", "javascript:return HideShowError('divAdd3')");
            this.txt_state.Attributes.Add("onkeypress", "javascript:return HideShowError('divAdd4')");
            this.txt_zipCode.Attributes.Add("onkeypress", "javascript:return HideShowError('divAdd5')");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                addressbooknew.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                addressbooknew.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            this.IsPrivate_SystemName = this.comm.IsPrivate_SystemName();
            base.Title = commonclass.pageTitle("Address", Convert.ToInt32(addressbooknew.companyID), Convert.ToInt32(addressbooknew.AccountID));
            this.lbl_Address1.Text = this.comm.GetAddressLabelByKey("Address1");
            this.lbl_Address2.Text = this.comm.GetAddressLabelByKey("Address2");
            this.lbl_Address3.Text = this.comm.GetAddressLabelByKey("Address3");
            this.lbl_Address4.Text = this.comm.GetAddressLabelByKey("Address4");
            this.lbl_Address5.Text = this.comm.GetAddressLabelByKey("Address5");
            if (this.comm.GetMandatoryByKey("address1").ToLower() != "true")
            {
                this.lblMandAdd1.Visible = false;
                this.hdnIsMandAdd1.Value = "0";
            }
            else
            {
                this.lblMandAdd1.Visible = true;
                this.hdnIsMandAdd1.Value = "1";
            }
            if (this.comm.GetMandatoryByKey("address2").ToLower() != "true")
            {
                this.lblMandAdd2.Visible = false;
                this.hdnIsMandAdd2.Value = "0";
            }
            else
            {
                this.lblMandAdd2.Visible = true;
                this.hdnIsMandAdd2.Value = "1";
            }
            if (this.comm.GetMandatoryByKey("address3").ToLower() != "true")
            {
                this.lblMandAdd3.Visible = false;
                this.hdnIsMandAdd3.Value = "0";
            }
            else
            {
                this.lblMandAdd3.Visible = true;
                this.hdnIsMandAdd3.Value = "1";
            }
            if (this.comm.GetMandatoryByKey("address4").ToLower() != "true")
            {
                this.lblMandAdd4.Visible = false;
                this.hdnIsMandAdd4.Value = "0";
            }
            else
            {
                this.lblMandAdd4.Visible = true;
                this.hdnIsMandAdd4.Value = "1";
            }
            if (this.comm.GetMandatoryByKey("address5").ToLower() != "true")
            {
                this.lblMandAdd5.Visible = false;
                this.hdnIsMandAdd5.Value = "0";
            }
            else
            {
                this.lblMandAdd5.Visible = true;
                this.hdnIsMandAdd5.Value = "1";
            }
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
            }
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddl_Country);
            }
            try
            {
                if (this.Session["StoreUserID"] == null)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                if (base.Request.Params["ID"] != null)
                {
                    this.AddressID = Convert.ToInt64(base.Request.Params["ID"]);
                }
                if (base.Request.Params["type"] != null)
                {
                    this.RedirectTo = base.Request.Params["type"].ToString();
                }
            }
            catch
            {
            }
            if (this.AddressID != (long)0)
            {
                this.lbl_addressHeader.Text = this.objLanguage.GetLanguageConversion("Edit_Address");
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)addressbooknew.companyID, addressbooknew.AccountID).Rows)
            {
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
                this.PostCode = row["PostCode"].ToString();
            }
            this.CreatedDate = DateTime.Now;
            if (!base.IsPostBack)
            {
                foreach (DataRow dataRow in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.DefaultBillingID = Convert.ToInt64(dataRow["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(dataRow["DefaultShippingID"]);
                    this.FirstName = dataRow["FirstName"].ToString();
                    this.LastName = dataRow["LastName"].ToString();
                    this.UserEmailID = dataRow["EmailID"].ToString();
                    this.CompanyName = dataRow["CompanyName"].ToString();
                }
                if (this.AddressID == (long)0)
                {
                    this.txt_addressLabel.Focus();
                }
                else
                {
                    foreach (DataRow row1 in OrderBasePage.Select_BillingShippingAddress_OnAddressID(this.StoreUserID, this.AddressID).Rows)
                    {
                        if (Convert.ToInt64(row1["AddressID"].ToString()) == this.AddressID)
                        {
                            if (row1["FirstName"].ToString() != "")
                            {
                                this.IsAdditionAddress = 1;
                                this.div_lbladdressLabel.Style.Add("display", "block");
                                this.div_lbllastName.Style.Add("display", "none");
                                this.div_lblfirstName.Style.Add("display", "none");
                            }
                            this.txt_addressLabel.Text = base.SpecialDecode(row1["AddressLabel"].ToString());
                            this.txt_firstName.Text = base.SpecialDecode(row1["FirstName"].ToString());
                            this.txt_lastName.Text = base.SpecialDecode(row1["LastName"].ToString());
                            this.txt_telephone.Text = row1["Phone"].ToString();
                            this.txt_email.Text = row1["Email"].ToString();
                            this.txt_fax.Text = row1["Fax"].ToString();
                            this.txt_address.Text = base.SpecialDecode(row1["Address1"].ToString());
                            this.txt_address2.Text = base.SpecialDecode(row1["Address2"].ToString());
                            this.txt_city.Text = base.SpecialDecode(row1["Address3"].ToString());
                            this.txt_state.Text = base.SpecialDecode(row1["Address4"].ToString());
                            this.txt_zipCode.Text = base.SpecialDecode(row1["Address5"].ToString());
                            this.ddl_Country.SelectedIndex = (row1["CountryID"].ToString() == "" ? 0 : Convert.ToInt32(row1["CountryID"]));
                        }
                        if (this.DefaultBillingID == this.AddressID)
                        {
                            this.chk_billing_address.Checked = true;
                            this.chk_billing_address.Style.Add("display", "none");
                            this.lblDefaultBilling.Text = "Default Invoice Address";
                            this.lblDefaultBilling.Style.Add("display", "block");
                        }
                        if (this.DefaultShippingID != this.AddressID)
                        {
                            continue;
                        }
                        this.chk_shipping_address.Checked = true;
                        this.chk_shipping_address.Style.Add("display", "none");
                        this.lblDefaultShipping.Text = "Default Delivery Address";
                        this.lblDefaultShipping.Style.Add("display", "block");
                    }
                    this.txt_firstName.Focus();
                }
            }
            if (this.Session["ApprovalSystem"] != null)
            {
                if (this.Session["ApprovalSystem"] != null)
                {
                    this.DivApproverEmail.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                    string str = base.Return_ApprovalSystem_Settings("editeduserapprove");
                    if ((!(this.approvalType == "u") || !(this.UserType == "u")) && (!(this.approvalType == "u") || !(this.UserType == "m")) && (!(this.approvalType == "u") || !(this.UserType == "d")))
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:none");
                    }
                    else if (str.ToLower().Trim() != "true")
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.DivApproverEmail.Attributes.Add("style", "display:block");
                        this.hdnValidation.Value = str;
                        DataTable dataTable = LoginBasePage.StoreUser_select(this.StoreUserID);
                        if (base.Return_ApprovalSystem_Settings("lastapproverdefault").ToLower() != "false" && !base.IsPostBack && dataTable.Rows.Count > 0)
                        {
                            this.txtApproverEmail.Text = dataTable.Rows[0]["DesignatedApproverEmail"].ToString();
                        }
                    }
                }
            }
            foreach (DataRow dataRow1 in OrderBasePage.Get_IsApprovalAddress(this.StoreUserID).Rows)
            {
                if (this.Session["ApprovalSystem"] != null)
                {
                    this.DivLblErrorMsg.Attributes.Add("style", "display:none");
                    this.btnUpdateAddress.Visible = true;
                }
                else
                {
                    addressbooknew.lblMGSA = dataRow1["IsApproved"].ToString();
                    if (dataRow1["IsApproved"].ToString().ToLower() == "true" || dataRow1["Rejected"].ToString().ToLower() == "true")
                    {
                        this.DivLblErrorMsg.Attributes.Add("style", "display:none");
                        this.btnUpdateAddress.Visible = true;
                    }
                    else
                    {
                        this.DivLblErrorMsg.Attributes.Add("style", "display:block");
                        this.btnUpdateAddress.Visible = false;
                    }
                }
            }
            foreach (DataRow row2 in LoginBasePage.Select_DeptDetail_For_StoreUser(addressbooknew.AccountID, this.StoreUserID).Rows)
            {
                this.DepartmentID = Convert.ToInt64(row2["DeptID"].ToString());
            }
        }
    }
}