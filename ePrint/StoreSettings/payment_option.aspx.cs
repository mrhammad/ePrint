using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
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

namespace ePrint.StoreSettings
{
    public partial class payment_option : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public int IsEnable;

        private string defaultpaymentMode = string.Empty;

        private string[] paymentMode;

        private string payMode = string.Empty;

        private string creaditCardTypes = string.Empty;

        private string defPayMode = string.Empty;

        private string[] CardTypes;

        private string[] CardTypes_BinaryTree;

        private string[] CardTypes_Stripe;

        private string CreditCardBrainTreeTypes = string.Empty;

        private string CreditCardStripeTypes = string.Empty;

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

        public payment_option()
        {
        }

        public void btn_Save_Onclick(object sender, EventArgs e)
        {
            if (this.lbl_selectAccount.Text == "")
            {
                this.objBase.Message_Display(" Please select account and proceed", "msg-success", this.plhMessageNew);
                return;
            }
            if (this.chk_cash.Checked)
            {
                this.payMode = string.Concat(this.payMode, "CD,");
                if (this.rdn_cash.Checked)
                {
                    this.defPayMode = "CD";
                }
            }
            if (this.chk_cheque.Checked)
            {
                this.payMode = string.Concat(this.payMode, "CH,");
                if (this.rdn_cheque.Checked)
                {
                    this.defPayMode = "CH";
                }
            }
            if (this.chk_credit.Checked)
            {
                if (this.ddlMode.SelectedIndex != 0)
                {
                    if (this.ddlMode.SelectedIndex == 1) {
                        this.payMode = string.Concat(this.payMode, "BT,");
                        if (this.chk_visa.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Visa,");
                        }
                        if (this.chk_master.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "MasterCard,");
                        }
                        if (this.chk_discover.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Discover,");
                        }
                        if (this.chk_american.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "American");
                        }
                        if (this.rdn_credit.Checked)
                        {
                            this.defPayMode = "BT";
                        }
                    }
                    else
                    {
                        this.payMode = string.Concat(this.payMode, "ST,");
                        if (this.chk_visa.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Visa,");
                        }
                        if (this.chk_master.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "MasterCard,");
                        }
                        if (this.chk_discover.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Discover,");
                        }
                        if (this.chk_american.Checked)
                        {
                            this.creaditCardTypes = string.Concat(this.creaditCardTypes, "American");
                        }
                        if (this.rdn_credit.Checked)
                        {
                            this.defPayMode = "ST";
                        }
                    }
                }
                else
                {
                    this.payMode = string.Concat(this.payMode, "CC,");
                    if (this.chk_visa.Checked)
                    {
                        this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Visa,");
                    }
                    if (this.chk_master.Checked)
                    {
                        this.creaditCardTypes = string.Concat(this.creaditCardTypes, "MasterCard,");
                    }
                    if (this.chk_discover.Checked)
                    {
                        this.creaditCardTypes = string.Concat(this.creaditCardTypes, "Discover,");
                    }
                    if (this.chk_american.Checked)
                    {
                        this.creaditCardTypes = string.Concat(this.creaditCardTypes, "American");
                    }
                    if (this.rdn_credit.Checked)
                    {
                        this.defPayMode = "CC";
                    }
                }
            }
            if (this.chk_paypal.Checked)
            {
                this.payMode = string.Concat(this.payMode, "PP,");
                if (this.rdn_paypal.Checked)
                {
                    this.defPayMode = "PP";
                }
            }
            if (this.chk_Invoice.Checked)
            {
                this.payMode = string.Concat(this.payMode, "PI,");
                if (this.rdn_Invoice.Checked)
                {
                    this.defPayMode = "PI";
                }
            }
            if (!this.rdn_disable.Checked)
            {
                WebstoreBasePage.paymentInsert(Convert.ToInt32(this.lbl_PaymentID.Text), this.CompanyID, this.AccountID, this.payMode, this.defPayMode, this.creaditCardTypes, this.CreditCardBrainTreeTypes, this.CreditCardStripeTypes, 1);
            }
            else
            {
                WebstoreBasePage.paymentInsert(Convert.ToInt32(this.lbl_PaymentID.Text), this.CompanyID, this.AccountID, this.payMode, this.defPayMode, this.creaditCardTypes, this.CreditCardBrainTreeTypes, this.CreditCardStripeTypes, 0);
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "StoreSettings/payment_option.aspx?suc=add"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.rdn_disable.Text = this.objLanguage.GetLanguageConversion("Disable");
            this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.chk_american.Text = this.objLanguage.GetLanguageConversion("American");
            this.chk_visa.Text = this.objLanguage.GetLanguageConversion("Visa");
            this.chk_master.Text = this.objLanguage.GetLanguageConversion("Master");
            this.chk_discover.Text = this.objLanguage.GetLanguageConversion("Discover");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString() == "add")
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Payment_Option_Saved_Successfully"), "msg-success", this.plhMessageNew);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
                string str1 = base.SpecialDecode(SettingsBasePage.Fetch_SelectedAccountName(Convert.ToInt64(strArrays[0].ToString())));
                this.lbl_selectAccount.Text = string.Concat("(", str1, ")");
                this.lbl_change.Text = this.objLanguage.GetLanguageConversion("Change");
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Payment_Option")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Payment Options", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Payment_Option");
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            if (!base.IsPostBack)
            {
                foreach (DataRow row in WebstoreBasePage.paymentSelect(this.CompanyID, this.AccountID).Rows)
                {
                    this.lbl_PaymentID.Text = row["paymentID"].ToString();
                    this.defaultpaymentMode = row["defaultpaymentMode"].ToString();
                    string str2 = row["paymentMode"].ToString().Trim();
                    char[] chrArray = new char[] { ',' };
                    this.paymentMode = str2.Split(chrArray);
                    string str3 = row["creaditCardTypes"].ToString().Trim();
                    char[] chrArray1 = new char[] { ',' };
                    this.CardTypes = str3.Split(chrArray1);
                    this.IsEnable = Convert.ToInt32(row["IsEnable"]);
                    string str4 = row["creditCardBrainTreeTypes"].ToString().Trim();
                    string str5 = row["creditCardStripeTypes"].ToString().Trim();
                    char[] chrArray2 = new char[] { ',' };
                    this.CardTypes_BinaryTree = str4.Split(chrArray2);
                    this.CardTypes_Stripe = str5.Split(chrArray2);
                    if (this.IsEnable == 0)
                    {
                        this.rdn_disable.Checked = true;
                    }
                    if ((int)this.CardTypes.Length != 1 || !(this.CardTypes[0] == ""))
                    {
                        this.div_creditcardType.Style.Add("display", "block");
                    }
                    else
                    {
                        this.div_creditcardType.Style.Add("display", "block");
                    }
                    for (int i = 0; i < (int)this.CardTypes.Length; i++)
                    {
                        if (this.CardTypes[i].ToLower() == "visa")
                        {
                            this.chk_visa.Checked = true;
                        }
                        if (this.CardTypes[i].ToLower() == "mastercard")
                        {
                            this.chk_master.Checked = true;
                        }
                        if (this.CardTypes[i].ToLower() == "discover")
                        {
                            this.chk_discover.Checked = true;
                        }
                        if (this.CardTypes[i].ToLower() == "american")
                        {
                            this.chk_american.Checked = true;
                        }
                    }
                    for (int j = 0; j < (int)this.paymentMode.Length; j++)
                    {
                        if (this.paymentMode[j] == "CD")
                        {
                            this.chk_cash.Checked = true;
                            if (this.defaultpaymentMode != "CD")
                            {
                                this.rdn_cash.Checked = false;
                            }
                            else
                            {
                                this.rdn_cash.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "CH")
                        {
                            this.chk_cheque.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "CH")
                            {
                                this.rdn_cheque.Checked = false;
                            }
                            else
                            {
                                this.rdn_cheque.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "CC")
                        {
                            this.chk_credit.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "CC")
                            {
                                this.rdn_credit.Checked = false;
                            }
                            else
                            {
                                this.rdn_credit.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "BT")
                        {
                            this.ddlMode.SelectedIndex = 1;
                            this.chk_credit.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "BT")
                            {
                                this.rdn_credit.Checked = false;
                            }
                            else
                            {
                                this.rdn_credit.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "ST")
                        {
                            this.ddlMode.SelectedIndex = 2;
                            this.chk_credit.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "ST")
                            {
                                this.rdn_credit.Checked = false;
                            }
                            else
                            {
                                this.rdn_credit.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "PP")
                        {
                            this.chk_paypal.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "PP")
                            {
                                this.rdn_paypal.Checked = false;
                            }
                            else
                            {
                                this.rdn_paypal.Checked = true;
                            }
                        }
                        else if (this.paymentMode[j] == "PI")
                        {
                            this.chk_Invoice.Checked = true;
                            if (row["defaultpaymentMode"].ToString() != "PI")
                            {
                                this.rdn_Invoice.Checked = false;
                            }
                            else
                            {
                                this.rdn_Invoice.Checked = true;
                            }
                        }
                    }
                }
            }
        }
    }
}