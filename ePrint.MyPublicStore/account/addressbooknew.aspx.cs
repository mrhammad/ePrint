using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using RewriteModule;
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

namespace ePrint.MyPublicStore.account
{
    public partial class addressbooknew : BaseClass, IRequiresSessionState
    {
        //protected System.Web.UI.ScriptManager sm1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_PageName;

        //protected usercontrols_account_leftpanel account_panel1;

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

        //protected Label lbl_country;

        //protected HtmlGenericControl Label5;

        //protected DropDownList ddl_Country;

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

        private commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public char KeySeparator;

        public int IsAdditionAddress;

        public int UserID;

        public long AddressID;

        public long StoreUserID;

        public long DefaultBillingID;

        public long DefaultShippingID;

        public static int companyID;

        public static long AccountID;

        public string Rewritemodule;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string RedirectTo = string.Empty;

        public string PostCode = string.Empty;

        public string DateFormat = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public bool IsPrivate_SystemName;

        private DateTime CreatedDate;

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
            if (this.AddressID != (long)0)
            {
                OrderBasePage.Update_BillingShipping_Address(this.AddressID, base.SpecialEncode(this.txt_firstName.Text.Trim()), base.SpecialEncode(this.txt_lastName.Text.Trim()), base.SpecialEncode(this.txt_address.Text.Trim()), base.SpecialEncode(this.txt_address2.Text.Trim()), base.SpecialEncode(this.txt_city.Text.Trim()), base.SpecialEncode(this.txt_state.Text.Trim()), this.txt_telephone.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), base.SpecialEncode(this.txt_addressLabel.Text.Trim()), this.txt_zipCode.Text.Trim(), (long)0, (long)0, this.StoreUserID);
                OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
            }
            else
            {
                this.AddressID = OrderBasePage.Insert_BillingShipping_Address(this.StoreUserID, base.SpecialEncode(this.txt_firstName.Text.Trim()), base.SpecialEncode(this.txt_lastName.Text.Trim()), base.SpecialEncode(this.txt_address.Text.Trim()), base.SpecialEncode(this.txt_address2.Text.Trim()), base.SpecialEncode(this.txt_city.Text.Trim()), base.SpecialEncode(this.txt_state.Text.Trim()), this.txt_zipCode.Text.Trim(), this.txt_telephone.Text.Trim(), this.txt_fax.Text.Trim(), this.ddl_Country.SelectedItem.Text.Trim(), num, num1, this.txt_addressLabel.Text.Trim(), this.CreatedDate);
                OrderBasePage.update_BillingShipping_AddressID(this.StoreUserID, this.AddressID, num, num1);
            }
            if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbook.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "account/addressbook", ConnectionClass.FileExtension));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.chk_billing_address.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Use_above_address_as_my_default_Invoice_address"));
            this.chk_shipping_address.Text = string.Concat(" ", this.objLanguage.GetLanguageConversion("Use_above_address_as_my_default_Delivery_Address"));
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
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator);
            }
            if (this.Session["IsHomePageVisible"] != null && this.Session["IsHomePageVisible"].ToString() == "1")
            {
                this.IsHomePageVisible = "1";
            }
            if (this.comm.GetDisplayValue("IsHome", addressbooknew.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(addressbooknew.companyID), Convert.ToInt32(addressbooknew.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (!base.IsPostBack)
            {
                OrderBasePage.company_country_select(this.ddl_Country);
            }
            try
            {
                if (this.Session["StoreUserID"] != null)
                {
                    this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
                }
                else if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (RewriteContext.Current.Params["ID"] != null)
                    {
                        string str = RewriteContext.Current.Params["ID"].ToString();
                        char[] keySeparator = new char[] { this.KeySeparator };
                        this.AddressID = Convert.ToInt64(str.Split(keySeparator)[1]);
                    }
                    if (RewriteContext.Current.Params["type"] != null)
                    {
                        this.RedirectTo = RewriteContext.Current.Params["type"].ToString();
                    }
                }
                else
                {
                    if (base.Request.Params["ID"] != null)
                    {
                        this.AddressID = Convert.ToInt64(base.Request.Params["ID"]);
                    }
                    if (base.Request.Params["type"] != null)
                    {
                        this.RedirectTo = base.Request.Params["type"].ToString();
                    }
                }
            }
            catch
            {
            }
            if (this.AddressID == (long)0)
            {
                this.lbl_PageName.Text = this.objLanguage.GetLanguageConversion("Add_New_Address");
                this.lbl_addressHeader.Text = this.objLanguage.GetLanguageConversion("Add_New_Address");
            }
            else
            {
                this.lbl_PageName.Text = this.objLanguage.GetLanguageConversion("Address_Edit");
                this.lbl_addressHeader.Text = this.objLanguage.GetLanguageConversion("Address_Edit");
            }
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)addressbooknew.companyID, addressbooknew.AccountID).Rows)
            {
                this.DateFormat = row["DateFormat"].ToString();
                this.UserID = Convert.ToInt32(row["createdBy"].ToString());
                this.PostCode = row["PostCode"].ToString();
            }
            commonclass _commonclass = this.comm;
            string dateFormat = this.DateFormat;
            commonclass _commonclass1 = this.comm;
            DateTime now = DateTime.Now;
            //this.CreatedDate = Convert.ToDateTime(_commonclass.date_Check_new(dateFormat, _commonclass1.Eprint_return_Date_Before_View(now.ToString(), addressbooknew.companyID, this.UserID, true)));
            this.CreatedDate = Convert.ToDateTime(now.ToString());
            if (!base.IsPostBack)
            {
                foreach (DataRow dataRow in LoginBasePage.StoreUser_select(this.StoreUserID).Rows)
                {
                    this.DefaultBillingID = Convert.ToInt64(dataRow["DefaultBillingID"]);
                    this.DefaultShippingID = Convert.ToInt64(dataRow["DefaultShippingID"]);
                }
                if (this.AddressID != (long)0)
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
                            this.lblDefaultBilling.Text = this.objLanguage.GetLanguageConversion("Default_Invoice_Address");
                            this.lblDefaultBilling.Style.Add("display", "block");
                        }
                        if (this.DefaultShippingID != this.AddressID)
                        {
                            continue;
                        }
                        this.chk_shipping_address.Checked = true;
                        this.chk_shipping_address.Style.Add("display", "none");
                        this.lblDefaultShipping.Text = this.objLanguage.GetLanguageConversion("Default_Delivery_Address");
                        this.lblDefaultShipping.Style.Add("display", "block");
                    }
                    this.txt_firstName.Focus();
                    return;
                }
                this.txt_addressLabel.Focus();
            }
        }
    }
}