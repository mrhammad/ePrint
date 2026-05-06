using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Company;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.usercontrol.Accounts
{
    public partial class accounts_new_create : UsercontrolBasePage
    {

        private commonClass comncls = new commonClass();

        private BasePage objpage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private commonClass commclass = new commonClass();

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private BaseClass basecls = new BaseClass();

        private SettingsBasePage objset = new SettingsBasePage();

        private CompanyBasePage objcomp = new CompanyBasePage();

        private AccountsBaseClass objacc = new AccountsBaseClass();

        private BasePage comnbasepage = new BasePage();

        private BaseClass objbase = new BaseClass();

        public int ClientID;

        public int email;

        public int isnew = 2;

        public int IsB2BCreated;

        public int def_addressID;

        public static int CompanyID;

        public static int UserID;

        public static int clientID;

        public static int def_addressID1;

        public static int ContactID;

        public static int accountID;

        public string UcStageSection = string.Empty;

        public string DateFormat = string.Empty;

        public string companytype = string.Empty;

        public string companyName = string.Empty;

        public string clientName = string.Empty;

        public string UserName = string.Empty;

        public static string txt_accountNameOld;

        public static string txt_accountPrefixOld;

        public string newdate = string.Empty;

        public string action = string.Empty;

        public string postback = string.Empty;

        public string mode = string.Empty;

        public string id = string.Empty;

        public static string strFinalData;

        public string strSitepath = global.sitePath();

        public string strImagepath = global.strimagepath;

        public string strFilePath = global.filePath();

        public string FileExtension = ConnectionClass.FileExtension;

        public string footerht = string.Empty;

        public string Pgtype = string.Empty;

        public static string account_editType;

        public string Store_Sitepath = string.Empty;

        public string Store_ThemePath = string.Empty;

        public string redirectTo = string.Empty;

        public string AccountName = string.Empty;

        public char addressType = 'A';

        public char accountType;

        public string B2BURL = ConnectionClass.B2BURL;

        public string B2CURL = ConnectionClass.B2CURL;

        public DateTime created_date;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public string PublicDocPath = global.PublicDocPath();

        public string SecureDocPath = global.SecureDocPath();

        public string ServerName = string.Empty;

        public string AccountNameUrl = string.Empty;

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

        static accounts_new_create()
        {
            accounts_new_create.CompanyID = 0;
            accounts_new_create.UserID = 0;
            accounts_new_create.clientID = 0;
            accounts_new_create.def_addressID1 = 0;
            accounts_new_create.ContactID = 0;
            accounts_new_create.accountID = 0;
            accounts_new_create.txt_accountNameOld = string.Empty;
            accounts_new_create.txt_accountPrefixOld = string.Empty;
            accounts_new_create.strFinalData = string.Empty;
            accounts_new_create.account_editType = "add";
        }

        public accounts_new_create()
        {
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (this.redirectTo == "client")
            {
                this.IsB2BCreated = 0;
                this.phB2BTab.Visible = true;
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_view.aspx?type=customer"));
        }

        protected void btnmodify_Click(object sender, EventArgs e)
        {
            commonClass _commonClass = this.commclass;
            string dateFormat = this.DateFormat;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            string str = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), accounts_new_create.CompanyID, accounts_new_create.UserID, true), accounts_new_create.CompanyID);
            this.created_date = Convert.ToDateTime(str);
            accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
            accounts_new_create.ContactID = Convert.ToInt32(this.hid_ContactID.Value);
            foreach (DataRow row in AccountsBaseClass.accounts_getDetails(0, 0, accounts_new_create.accountID).Rows)
            {
                accounts_new_create.clientID = Convert.ToInt32(row["clientID"].ToString());
            }
            if (this.lblaccountTypeData.Text == "Private")
            {
                this.objacc.account_modify(this.ClientID, this.lblCustomerName1.Text, this.txt_accountName.Text, this.txt_accountPrefix.Text.Trim(), this.created_date.ToString(), accounts_new_create.UserID, accounts_new_create.ContactID, accounts_new_create.def_addressID1, accounts_new_create.accountID);
                this.CheckStyleSheetPrivate(accounts_new_create.accountID);
                base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_view.aspx?type=Customer&msg=up&accid=", accounts_new_create.accountID));
                return;
            }
            if (this.lblaccountTypeData.Text == "Public")
            {
                accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
                this.objacc.account_modifyPublic(this.txt_accountName.Text, this.txt_accountPrefix.Text.Trim(), accounts_new_create.accountID);
                this.CheckStyleSheet(accounts_new_create.accountID);
                base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_view.aspx?type=Customer&msg=up&accid=", accounts_new_create.accountID));
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            this.ClientID = Convert.ToInt32(this.hid_ClientID.Value);
            if (this.rbtnPrivate.Checked)
            {
                bool flag = true;
                if (this.txt_accountName.Text == "")
                {
                    this.objBase.Message_Display(" * fields are mandatory", "msg-alert", this.plhMessage);
                    flag = false;
                }
                else
                {
                    foreach (DataRow row in AccountsBaseClass.accounts_clientID(this.txt_accountName.Text, accounts_new_create.CompanyID).Rows)
                    {
                        if (this.txt_accountName.Text != row["accountName"].ToString())
                        {
                            continue;
                        }
                        this.txt_companyName.Text = "";
                        this.txt_accountName.Text = "";
                        this.txt_accountPrefix.Text = "";
                        this.ddlcontact.Items.Clear();
                        this.ddlcontact.Text = "";
                        this.txt_def_DeliveryAddress.Text = "";
                        this.ckbEmail.Checked = false;
                        flag = false;
                        this.divMessage.Attributes.Add("style", "width: 100%; margin-bottom: -25px; margin-top: 30px; margin-left: 15px;");
                        this.objBase.Message_Display("&nbsp;&nbsp;Account name already exist", "msg-alert", this.plhMessage);
                        break;
                    }
                    foreach (DataRow dataRow in AccountsBaseClass.accounts_getDetails(this.ClientID, accounts_new_create.CompanyID, 0).Rows)
                    {
                        if (this.ClientID != Convert.ToInt32(dataRow["clientID"].ToString()))
                        {
                            continue;
                        }
                        this.txt_companyName.Text = "";
                        this.txt_accountName.Text = "";
                        this.txt_accountPrefix.Text = "";
                        this.ddlcontact.Items.Clear();
                        this.ddlcontact.Text = "";
                        this.txt_def_DeliveryAddress.Text = "";
                        this.ckbEmail.Checked = false;
                        flag = false;
                        this.objBase.Message_Display("  Company name already exist", "msg-alert", this.plhMessage);
                        break;
                    }
                }
                if (flag)
                {
                    try
                    {
                        this.def_addressID = Convert.ToInt32(this.hid_addressID.Value);
                        this.addressType = 'A';
                    }
                    catch
                    {
                    }
                    if (!this.ckbEmail.Checked)
                    {
                        this.email = 0;
                    }
                    else
                    {
                        this.email = 1;
                    }
                    commonClass _commonClass = this.commclass;
                    string dateFormat = this.DateFormat;
                    commonClass _commonClass1 = this.commclass;
                    DateTime now = DateTime.Now;
                    string str = _commonClass.date_Check_new(dateFormat, _commonClass1.Eprint_return_Date_Before_View(now.ToString(), accounts_new_create.CompanyID, accounts_new_create.UserID, true), accounts_new_create.CompanyID);
                    this.created_date = Convert.ToDateTime(str);
                    this.accountType = Convert.ToChar("p");
                    this.Store_Sitepath = this.B2BURL;
                    if (this.ddlcontact.Items.Count == 0)
                    {
                        accounts_new_create.ContactID = Convert.ToInt32(this.hid_ContactID.Value);
                    }
                    else
                    {
                        accounts_new_create.ContactID = Convert.ToInt32(this.ddlcontact.SelectedValue);
                    }
                    int num = this.objacc.account_insert(this.ClientID, this.objbase.SpecialEncode(this.txt_companyName.Text), this.objbase.SpecialEncode(this.txt_accountName.Text), this.objbase.SpecialEncode(this.txt_accountPrefix.Text.Trim()), this.created_date.ToString(), accounts_new_create.UserID, accounts_new_create.ContactID, this.def_addressID, this.accountType, this.addressType, accounts_new_create.CompanyID, this.Store_Sitepath, this.FileExtension);
                    SettingsBasePage.Setting_Insert_Crm_ZipToTaxsettings(num, accounts_new_create.CompanyID, accounts_new_create.UserID, false, false);
                    SettingsBasePage.PC_Update_DeliveryCost_Settings(accounts_new_create.CompanyID,num, false ,false , false);
                    this.CheckStyleSheetPrivate(num);
                    if (this.redirectTo != "client")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_view.aspx?type=Customer&msg=suc&accid=", num));
                    }
                    else
                    {
                        this.IsB2BCreated = 1;
                        this.AccountNameUrl = this.txt_accountName.Text;
                        this.phB2BTab.Visible = true;
                    }
                }
            }
            if (this.rbtnPublic.Checked)
            {
                commonClass _commonClass2 = this.commclass;
                string dateFormat1 = this.DateFormat;
                commonClass _commonClass3 = this.commclass;
                DateTime dateTime = DateTime.Now;
                string str1 = _commonClass2.date_Check_new(dateFormat1, _commonClass3.Eprint_return_Date_Before_View(dateTime.ToString(), accounts_new_create.CompanyID, accounts_new_create.UserID, true), accounts_new_create.CompanyID);
                this.created_date = Convert.ToDateTime(str1);
                bool flag1 = true;
                DataTable dataTable = AccountsBaseClass.accounts_getAccountID(this.txt_accountName.Text, this.txt_accountPrefix.Text, accounts_new_create.CompanyID);
                foreach (DataRow row1 in dataTable.Rows)
                {
                    accounts_new_create.accountID = Convert.ToInt32(row1["accountID"].ToString());
                    if (this.txt_accountName.Text.ToLower() != row1["accountName"].ToString().ToLower())
                    {
                        if (this.txt_accountPrefix.Text.ToLower().Trim() != row1["accountPrefix"].ToString().ToLower().Trim())
                        {
                            continue;
                        }
                        this.txt_accountName.Text = "";
                        this.txt_accountPrefix.Text = "";
                        flag1 = false;
                        this.objBase.Message_Display("  Account name/prefix already exist", "msg-alert", this.plhMessage);
                        break;
                    }
                    else
                    {
                        this.txt_accountName.Text = "";
                        this.txt_accountPrefix.Text = "";
                        flag1 = false;
                        this.objBase.Message_Display("  Account name/prefix already exist", "msg-alert", this.plhMessage);
                        break;
                    }
                }
                if (flag1)
                {
                    this.Store_Sitepath = this.B2CURL;
                    this.accountType = Convert.ToChar("x");
                    int num1 = this.objacc.account_insert(0, "n/a", this.txt_accountName.Text.Trim(), this.txt_accountPrefix.Text.Trim(), this.created_date.ToString(), accounts_new_create.UserID, 0, 0, this.accountType, 'x', accounts_new_create.CompanyID, this.Store_Sitepath, this.FileExtension);
                    SettingsBasePage.Setting_Insert_Crm_ZipToTaxsettings(num1, accounts_new_create.CompanyID, accounts_new_create.UserID, false, false);
                    SettingsBasePage.PC_Update_DeliveryCost_Settings(accounts_new_create.CompanyID, num1, false, false, false);
                    this.CheckStyleSheet(num1);
                    base.Response.Redirect(string.Concat(this.strSitepath, "Accounts/accounts_view.aspx?type=Customer&msg=suc&accid=", num1));
                }
            }
        }

        public void CheckStyleSheet(int Account_ID)
        {
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, this.ServerName, "\\")))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, this.ServerName, "\\"));
            }
            string str = string.Concat(this.Store_ThemePath, this.ServerName, "\\");
            if (!Directory.Exists(string.Concat(str, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(str, "store\\"));
            }
            if (!Directory.Exists(string.Concat(str, "store\\", Account_ID)))
            {
                Directory.CreateDirectory(string.Concat(str, "store\\", Account_ID));
            }
            object[] accountID = new object[] { str, "store\\", Account_ID, "\\Themes\\" };
            if (!Directory.Exists(string.Concat(accountID)))
            {
                object[] objArray = new object[] { str, "store\\", Account_ID, "\\Themes\\" };
                Directory.CreateDirectory(string.Concat(objArray));
                string str1 = "StyleSheet.css";
                object[] accountID1 = new object[] { str, "store\\", Account_ID, "\\Themes\\", str1 };
                string str2 = string.Concat(accountID1);
                if (!File.Exists(str2))
                {
                    File.Create(str2);
                }
            }
            if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "\\")))
            {
                Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "\\"));
            }
            string str3 = string.Concat(this.SecureDocPath, this.ServerName, "\\");
            if (!Directory.Exists(string.Concat(str3, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(str3, "store\\"));
            }
            if (!Directory.Exists(string.Concat(str3, "store\\", Account_ID)))
            {
                Directory.CreateDirectory(string.Concat(str3, "store\\", Account_ID));
            }
        }

        public void CheckStyleSheetPrivate(int Account_ID)
        {
            if (!Directory.Exists(string.Concat(this.Store_ThemePath, this.ServerName, "\\")))
            {
                Directory.CreateDirectory(string.Concat(this.Store_ThemePath, this.ServerName, "\\"));
            }
            string str = string.Concat(this.Store_ThemePath, this.ServerName, "\\");
            if (!Directory.Exists(string.Concat(str, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(str, "store\\"));
            }
            if (!Directory.Exists(string.Concat(str, "store\\", Account_ID)))
            {
                Directory.CreateDirectory(string.Concat(str, "store\\", Account_ID));
            }
            object[] accountID = new object[] { str, "store\\", Account_ID, "\\Themes\\" };
            if (!Directory.Exists(string.Concat(accountID)))
            {
                object[] objArray = new object[] { str, "store\\", Account_ID, "\\Themes\\" };
                Directory.CreateDirectory(string.Concat(objArray));
                string str1 = "StyleSheet_B2B.css";
                object[] accountID1 = new object[] { str, "store\\", Account_ID, "\\Themes\\", str1 };
                string str2 = string.Concat(accountID1);
                if (!File.Exists(str2))
                {
                    File.Create(str2);
                }
            }
            if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "\\")))
            {
                Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "\\"));
            }
            string str3 = string.Concat(this.SecureDocPath, this.ServerName, "\\");
            if (!Directory.Exists(string.Concat(str3, "store\\")))
            {
                Directory.CreateDirectory(string.Concat(str3, "store\\"));
            }
            if (!Directory.Exists(string.Concat(str3, "store\\", Account_ID)))
            {
                Directory.CreateDirectory(string.Concat(str3, "store\\", Account_ID));
            }
        }

        protected void ckbEmail_CheckedChanged(object sender, EventArgs e)
        {
        }

        public void getDetails()
        {
            int num = 0;
            DataTable dataTable = null;
            if (!base.IsPostBack)
            {
                try
                {
                    num = Convert.ToInt32(base.Request.Params["clientID"].ToString());
                    accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
                }
                catch
                {
                }
                dataTable = AccountsBaseClass.accounts_getDetails(accounts_new_create.clientID, accounts_new_create.CompanyID, accounts_new_create.accountID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.lblCustomerName1.Text = this.objbase.SpecialDecode(row["clientName"].ToString());
                    this.txt_accountName.Text = this.objbase.SpecialDecode(row["accountName"].ToString());
                    this.txt_accountPrefix.Text = this.objbase.SpecialDecode(row["accountPrefix"].ToString().Trim());
                    this.addressType = Convert.ToChar(row["addressType"].ToString());
                    this.def_addressID = Convert.ToInt32(row["defaultAddressID"].ToString());
                    accounts_new_create.ContactID = Convert.ToInt32(row["defaultContactID"].ToString());
                    foreach (DataRow dataRow in AccountsBaseClass.accounts_contactName(accounts_new_create.ContactID).Rows)
                    {
                        accounts_new_create.ContactID = Convert.ToInt32(dataRow["contactId"].ToString());
                        this.ddlcontact.Items.Add(dataRow["ContactName"].ToString());
                    }
                    this.ddlcontact.SelectedIndex = 0;
                    if (base.Request.Params["type"].ToString() == "Customer")
                    {
                        this.companytype = "Customer";
                        if (this.addressType == 'M')
                        {
                            DataTable dataTable1 = AccountsBaseClass.accounts_clientAddress(accounts_new_create.CompanyID, this.companytype, num, this.addressType, this.def_addressID);
                            foreach (DataRow row1 in dataTable1.Rows)
                            {
                                TextBox txtDefDeliveryAddress = this.txt_def_DeliveryAddress;
                                string[] str = new string[] { row1["BusinessAddressLine1"].ToString(), " ", row1["BusinessAddressLine2"].ToString(), " ", row1["BusinessAddressLine3"].ToString(), " ", row1["BusinessAddressLine4"].ToString() };
                                txtDefDeliveryAddress.Text = string.Concat(str);
                                accounts_new_create.def_addressID1 = Convert.ToInt32(row1[6].ToString());
                            }
                        }
                        if (this.addressType == 'C')
                        {
                            DataTable dataTable2 = AccountsBaseClass.accounts_clientAddress(accounts_new_create.CompanyID, this.companytype, num, this.addressType, this.def_addressID);
                            foreach (DataRow dataRow1 in dataTable2.Rows)
                            {
                                TextBox textBox = this.txt_def_DeliveryAddress;
                                string[] strArrays = new string[] { dataRow1["BusinessAddressLine1"].ToString(), " ", dataRow1["BusinessAddressLine2"].ToString(), " ", dataRow1["BusinessAddressLine3"].ToString(), " ", dataRow1["BusinessAddressLine4"].ToString() };
                                textBox.Text = string.Concat(strArrays);
                                accounts_new_create.def_addressID1 = Convert.ToInt32(dataRow1["contactId"].ToString());
                            }
                        }
                    }
                    this.div_accountType.Visible = true;
                    this.lblaccountTypeData.Text = "Private";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.companyName = base.Session["companyName"].ToString();
            accounts_new_create.UserID = int.Parse(base.Session["userID"].ToString());
            this.Store_ThemePath = this.PublicDocPath;
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (base.Request.Params["clientID"] != null)
            {
                accounts_new_create.clientID = Convert.ToInt32(base.Request.Params["clientID"].ToString());
            }
            if (base.Request.Params["accountID"] != null)
            {
                accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
            }
            if (base.Request.Params["mode"] != null)
            {
                if (base.Request.Params["mode"].ToString().ToLower() != "edit")
                {
                    accounts_new_create.account_editType = "add";
                }
                else
                {
                    accounts_new_create.account_editType = "edit";
                    this.lblAddCompany.Text = "Accounts Edit";
                }
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString().ToLower() == "add")
            {
                this.objbase.Message_Display(" Company Saved Successfully", "successfulMsg", this.plhMessage);
            }
            if (base.Request.Params["from"] != null && base.Request.Params["from"].ToString().ToLower() == "client")
            {
                this.redirectTo = base.Request.Params["from"].ToString().ToLower();
            }
            if (this.redirectTo.ToLower() == "client")
            {
                this.ImgCustomerAdd.Visible = false;
                this.ImgContact.Visible = false;
            }
            if (base.Request.Params["acctype"] != null && base.Request.Params["acctype"] == "x")
            {
                this.rbtnPublic.Checked = true;
                this.account_Type.Style.Add("margin", "20px 0px 0px 0px");
                this.account_Type.Style.Add("display", "block");
                this.div_accountdetails.Style.Add("margin", "5px 0px 0px 15px");
            }
            this.UcStageSection = base.BaseSection;
            this.Pgtype = "client";
            accounts_new_create.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            if (base.Request.Params["accountID"] == null)
            {
                this.ImgCustomerAdd.PostBackUrl = string.Concat(this.strSitepath, "client/client_add.aspx?type=Customer&post=accounts&mode=add");
            }
            else
            {
                accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
                foreach (DataRow row in AccountsBaseClass.accounts_getDetails(0, 0, accounts_new_create.accountID).Rows)
                {
                    this.hid_ClientID.Value = row["clientID"].ToString();
                    accounts_new_create.clientID = Convert.ToInt32(row["clientID"].ToString());
                    ImageButton imgCustomerAdd = this.ImgCustomerAdd;
                    object[] str = new object[] { this.strSitepath, "client/client_add.aspx?type=Customer&post=accounts&mode=edit&clientID=", accounts_new_create.clientID, "&accountID=", base.Request.Params["accountID"].ToString() };
                    imgCustomerAdd.PostBackUrl = string.Concat(str);
                }
            }
            this.txt_companyName.Focus();
            this.txt_companyName.Attributes.Add("autocomplete", "off");
            if (!base.IsPostBack)
            {
                this.txt_companyName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", accounts_new_create.CompanyID, "','1',event);"));
                this.txt_companyName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", accounts_new_create.CompanyID, "','1',event);"));
            }
            if (!this.rbtnPublic.Checked)
            {
                this.rbtnPublic.Checked = false;
                this.rbtnPrivate.Checked = true;
            }
            else
            {
                this.btnsave.Visible = true;
                this.btnmodify.Visible = false;
                this.txt_companyName.Visible = false;
                this.lblCustomerName1.Visible = true;
                this.account_Type.Visible = true;
                this.div_companyName.Visible = false;
                this.div_defContactName.Visible = false;
                this.div_defDeliveryName.Visible = false;
                this.div_email.Visible = false;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["type"] == "Customer" && base.Request.Params["mode"] == "add")
                {
                    this.hid_ClientID.Value = base.Request.Params["clientID"].ToString();
                    if (this.hid_ClientID.Value != null)
                    {
                        this.account_Type.Style.Add("display", "none");
                    }
                    DataTable dataTable = AccountsBaseClass.accounts_clientAddress(Convert.ToInt32(accounts_new_create.CompanyID), "Customer", Convert.ToInt32(base.Request.Params["clientID"].ToString()), this.addressType, this.def_addressID);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string empty = string.Empty;
                        empty = Regex.Replace(this.objbase.SpecialDecode(dataRow[4].ToString()), "[^0-9a-zA-Z_]", " ");
                        empty = Regex.Replace(empty, "[ ]{2,}", " ");
                        this.txt_companyName.Text = this.objbase.SpecialDecode(dataRow[4].ToString());
                        this.txt_accountName.Text = Regex.Replace(empty, "[^0-9a-zA-Z_]", "-");
                        TextBox txtDefDeliveryAddress = this.txt_def_DeliveryAddress;
                        string[] strArrays = new string[] { dataRow[0].ToString(), " ", dataRow[1].ToString(), " ", dataRow[2].ToString(), " ", dataRow[3].ToString() };
                        txtDefDeliveryAddress.Text = string.Concat(strArrays);
                    }
                    DataTable dataTable1 = AccountsBaseClass.accounts_getcontactDetails(Convert.ToInt32(accounts_new_create.CompanyID), Convert.ToInt32(base.Request.Params["clientID"].ToString()));
                    this.ddlcontact.DataSource = dataTable1;
                    this.ddlcontact.DataTextField = "ContactName";
                    this.ddlcontact.DataValueField = "contactId";
                    this.ddlcontact.DataBind();
                    foreach (DataRow row1 in dataTable1.Rows)
                    {
                        if (row1["DefaultContact"].ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        this.ddlcontact.SelectedValue = row1["contactId"].ToString();
                    }
                }
                else if (base.Request.Params["mode"] != null)
                {
                    DataTable dataTable2 = null;
                    try
                    {
                        accounts_new_create.accountID = Convert.ToInt32(base.Request.Params["accountID"].ToString());
                        dataTable2 = AccountsBaseClass.accounts_getDetails(0, 0, accounts_new_create.accountID);
                        foreach (DataRow dataRow1 in dataTable2.Rows)
                        {
                            accounts_new_create.clientID = Convert.ToInt32(dataRow1["clientID"].ToString());
                            this.hid_ContactID.Value = dataRow1["defaultContactID"].ToString();
                        }
                    }
                    catch
                    {
                        accounts_new_create.clientID = Convert.ToInt32(base.Request.Params["clientID"].ToString());
                        accounts_new_create.CompanyID = Convert.ToInt32(accounts_new_create.CompanyID);
                        dataTable2 = AccountsBaseClass.accounts_getDetails(accounts_new_create.clientID, accounts_new_create.CompanyID, accounts_new_create.accountID);
                    }
                    foreach (DataRow row2 in dataTable2.Rows)
                    {
                        this.accountType = Convert.ToChar(row2["accountType"].ToString());
                        if (this.accountType != 'p')
                        {
                            if (this.accountType != 'x' || base.IsPostBack)
                            {
                                continue;
                            }
                            this.btnsave.Visible = false;
                            this.btnmodify.Visible = true;
                            this.txt_companyName.Visible = false;
                            this.lblCustomerName1.Visible = true;
                            this.account_Type.Visible = false;
                            this.div_companyName.Visible = false;
                            this.div_defContactName.Visible = false;
                            this.div_defDeliveryName.Visible = false;
                            this.div_email.Visible = false;
                            this.txt_accountName.Text = this.objbase.SpecialDecode(row2["accountName"].ToString());
                            this.txt_accountPrefix.Text = this.objbase.SpecialDecode(row2["accountPrefix"].ToString().Trim());
                            accounts_new_create.txt_accountNameOld = this.objbase.SpecialDecode(row2["accountName"].ToString());
                            accounts_new_create.txt_accountPrefixOld = this.objbase.SpecialDecode(row2["accountPrefix"].ToString().Trim());
                            this.div_accountType.Visible = true;
                            this.lblaccountTypeData.Text = "Public";
                            this.hid_accountName.Value = this.objbase.SpecialDecode(row2["accountName"].ToString());
                            this.hid_accountPrefix.Value = this.objbase.SpecialDecode(row2["accountPrefix"].ToString());
                            this.txt_accountName.Focus();
                        }
                        else
                        {
                            this.btnsave.Visible = false;
                            this.btnmodify.Visible = true;
                            this.txt_companyName.Visible = false;
                            this.lblCustomerName1.Visible = true;
                            this.ImgCustomerAdd.Visible = false;
                            this.account_Type.Visible = false;
                            this.getDetails();
                            DataTable dataTable3 = AccountsBaseClass.accounts_getcontactDetails(Convert.ToInt32(accounts_new_create.CompanyID), accounts_new_create.clientID);
                            this.ddlcontact.DataSource = dataTable3;
                            this.ddlcontact.DataTextField = "ContactName";
                            this.ddlcontact.DataValueField = "contactId";
                            this.ddlcontact.DataBind();
                            this.ddlcontact.SelectedValue = this.hid_ContactID.Value;
                            this.txt_accountName.Focus();
                        }
                    }
                }
            }
            this.btncancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnsave.Text = this.objLangClass.GetLanguageConversion("Save");
            this.btnmodify.Text = this.objLangClass.GetLanguageConversion("Save");
            if (base.Request.Url.ToString().Contains("accounts/accounts_new_create.aspx"))
            {
                this.div_accountdetails.Style.Add("margin", "20px 0px 0px 15px");
            }
        }
    }
}