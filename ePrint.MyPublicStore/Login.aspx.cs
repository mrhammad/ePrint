using nmsCommon;
using nmsConnection;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class Login : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected HtmlGenericControl div_NavigationID;

        //protected HtmlGenericControl spnLoginID;

        //protected HtmlImage imgError;

        //protected Label lblSucess;

        //protected HtmlGenericControl div_InvalidMsg;

        //protected Label lbl_NewUser;

        //protected Button btn_createAccount;

        //protected HtmlTableCell td_NewUserID;

        //protected Label lbl_RegisteredCustomer;

        //protected Label lbl_loginemail;

        //protected TextBox txt_loginemail;

        //protected RequiredFieldValidator req_;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected Label lbl_loginpassword;

        //protected TextBox txt_loginpassword;

        //protected RequiredFieldValidator RequiredFieldValidator1;

        //protected Button BtnLogin;

        //protected HtmlGenericControl div_private;

        public string SesseionKey = string.Empty;

        public string AccountType = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string Email = string.Empty;

        public string Pwd = string.Empty;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        public bool IsActive;

        public long StoreUserID;

        public static int companyID;

        public static long AccountID;

        public string RewriteModule = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string NewSessionID = string.Empty;

        public string Frompage = string.Empty;

        private DataTable dtDisplaySetting;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        static Login()
        {
        }

        public Login()
        {
        }

        public void _Login(string Email, string Password)
        {
            bool flag = false;
            this.Session["IsHomePageVisible"] = null;
            this.Session["IsPPW"] = null;
            DataTable dataTable = LoginBasePage.LoginTo_Store(Email, Password, Login.AccountID, ConnectionClass.AccountType);
            foreach (DataRow row in dataTable.Rows)
            {
                this.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                Login.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                this.dtDisplaySetting = CMSBasePage.GetDisplaySettings(Login.AccountID);
                this.Session["eStoreDisplaySetting"] = this.dtDisplaySetting;
                if (!Convert.ToBoolean(row["IsActive"].ToString()))
                {
                    flag = false;
                    this.IsActive = true;
                    this.Session["IsHomePageVisible"] = null;
                    this.Session["IsPPW"] = null;
                }
                else
                {
                    flag = true;
                    this.IsActive = false;
                    this.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    this.Session["IsPPW"] = row["IsPPW"].ToString();
                }
            }
            if (!flag)
            {
                if (this.IsActive)
                {
                    this.lblSucess.Text = this.objLanguage.GetLanguageConversion("Your_account_is_deactivated");
                    this.div_InvalidMsg.Attributes.Add("style", "display:block");
                    return;
                }
                this.lblSucess.Text = this.objLanguage.GetLanguageConversion("Invalid_login_or_password");
                this.div_InvalidMsg.Attributes.Add("style", "display:block");
                return;
            }
            this.SesseionKey = this.comm.UniqueID;
            this.login.Insert_intoResume_Session(Email, Password);
            this.login.LogInFromDefault(Email, Password);
            CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
            Login.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            this.AccountType = this.comm.return_AccountType((long)Login.companyID, Login.AccountID);
            if (this.Session["fromEmail"] != null && this.Session["fromEmail"] != null)
            {
                base.Response.Redirect(this.Session["fromEmail"].ToString());
                return;
            }
            int num = 0;
            foreach (DataRow dataRow in CartBasePage.Select_CartItems(this.NewSessionID, "", this.StoreUserID).Rows)
            {
                num++;
            }
            if (num == 0 && ConnectionClass.AccountType.Trim().ToLower() == "public")
            {
                if (this.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "default.aspx"));
                    return;
                }
                base.Response.Redirect(string.Concat(this.strSitepath, "default", ConnectionClass.FileExtension));
                return;
            }
            if (this.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "shoppingcart.aspx?ID=0&amp;PID=0"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitepath, "shoppingcart", ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        public void AutoLogin()
        {
            if (base.Request.Params["email"] != null && base.Request.Params["password"] != null)
            {
                string str = base.Request.Params["email"].ToString().Trim().Replace("'", "`");
                string str1 = base.Request.Params["password"].ToString().Trim();
                string str2 = string.Format("{0:dd-M-yyyy}", DateTime.Now).ToString();
                string str3 = string.Concat(str, "GS6IHKHqiX", str2);
                string str4 = this.AutoLogin_Check(str);
                if (str1 == this.MD5Hash(str3).ToLower() && str4.Length > 0)
                {
                    this._Login(this.objBase.SpecialEncode(str), str4);
                }
            }
        }

        public string AutoLogin_Check(string EmailID)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString());
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("select Password from Ws_StoreUser where EmailID='", EmailID, "'"))
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text
            };
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["Password"].ToString();
            }
            return empty;
        }

        protected void btn_createAccount_Click(object sender, EventArgs e)
        {
            if (this.Frompage.ToLower() != "cart")
            {
                base.Response.Redirect(string.Concat("create_account", ConnectionClass.FileExtension));
                return;
            }
            base.Response.Redirect(string.Concat("create_account", ConnectionClass.FileExtension, "?from=cart"));
        }

        public string MD5Hash(string text)
        {
            MD5 mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            return Regex.Replace(BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(text))), "-", "");
        }

        protected void Onclick_BtnLogin(object sender, EventArgs e)
        {
            this._Login(this.objBase.SpecialEncode(this.txt_loginemail.Text), this.txt_loginpassword.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Url.ToString().ToLower().IndexOf("dmcsportonline") != -1)
            {
                bool flag = false;
                string lower = base.Request.Url.ToString().ToLower();
                if (lower.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower = lower.Replace("http", "https");
                    flag = true;
                }
                if (lower.ToString().ToLower().IndexOf("https://dmcsportonline.com.au") != -1)
                {
                    lower = lower.Replace("https://dmcsportonline.com.au", "https://www.dmcsportonline.com.au");
                    flag = true;
                }
                if (flag)
                {
                    base.Response.Redirect(lower);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("printbank") != -1)
            {
                bool flag1 = false;
                string str = base.Request.Url.ToString().ToLower();
                if (str.ToString().ToLower().IndexOf("https") == -1)
                {
                    str = str.Replace("http", "https");
                    flag1 = true;
                }
                if (flag1)
                {
                    base.Response.Redirect(str);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("eprintsoftware") != -1)
            {
                bool flag2 = false;
                string lower1 = base.Request.Url.ToString().ToLower();
                if (lower1.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower1 = lower1.Replace("http", "https");
                    flag2 = true;
                }
                if (flag2)
                {
                    base.Response.Redirect(lower1);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("avivaprint") != -1)
            {
                bool flag3 = false;
                string str1 = base.Request.Url.ToString().ToLower();
                if (str1.ToString().ToLower().IndexOf("https") == -1)
                {
                    str1 = str1.Replace("http", "https");
                    flag3 = true;
                }
                if (flag3)
                {
                    base.Response.Redirect(str1);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("smponline") != -1)
            {
                bool flag4 = false;
                string lower2 = base.Request.Url.ToString().ToLower();
                if (lower2.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower2 = lower2.Replace("http", "https");
                    flag4 = true;
                }
                if (flag4)
                {
                    base.Response.Redirect(lower2);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("siriusprinting") != -1)
            {
                bool flag5 = false;
                string str2 = base.Request.Url.ToString().ToLower();
                if (str2.ToString().ToLower().IndexOf("https") == -1)
                {
                    str2 = str2.Replace("http", "https");
                    flag5 = true;
                }
                if (flag5)
                {
                    base.Response.Redirect(str2);
                }
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                Login.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
                this.Session["LanguageConversion"] = LoginBasePage.Fetch_LanguageConversionFileName(Login.AccountID);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.RewriteModule = ConnectionClass.RewriteModule;
            }
            if (base.Request["b2bemail"] != null && base.Request["b2bpwd"] != null)
            {
                this.Email = base.Request["b2bemail"].ToString();
                this.Pwd = base.Request["b2bpwd"].ToString();
                this.SesseionKey = this.comm.UniqueID;
                this.login.Insert_intoResume_Session(this.Email, this.Pwd);
                this.login.LogInFromDefault(this.Email, this.Pwd);
                CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
                Login.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
                Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
                this.AccountType = this.comm.return_AccountType((long)Login.companyID, Login.AccountID);
                DataTable dataTable = LoginBasePage.LoginTo_Store(this.Email, this.Pwd, Login.AccountID, this.AccountType);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                    if (!Convert.ToBoolean(row["IsActive"].ToString()))
                    {
                        this.Session["IsHomePageVisible"] = null;
                        this.Session["IsPPW"] = null;
                    }
                    else
                    {
                        this.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                        this.Session["IsPPW"] = row["IsPPW"].ToString();
                    }
                }
                this.dtDisplaySetting = CMSBasePage.GetDisplaySettings(Login.AccountID);
                this.Session["eStoreDisplaySetting"] = this.dtDisplaySetting;
                if (this.Session["fromEmail"] != null && this.Session["fromEmail"].ToString() != "")
                {
                    base.Response.Redirect(this.Session["fromEmail"].ToString());
                }
                else if (this.AccountType.ToLower() == "p")
                {
                    if (this.RewriteModule.ToLower() != "on")
                    {
                        base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                    }
                    else
                    {
                        HttpResponse response = base.Response;
                        string[] keySeparator = new string[] { this.strSitepath, "products", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                        response.Redirect(string.Concat(keySeparator));
                    }
                }
                else if (this.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/account.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/account", ConnectionClass.FileExtension));
                }
            }
            if (Login.AccountID == (long)0 && Login.companyID == 0)
            {
                this.td_NewUserID.Style.Add("display", "none");
                this.div_private.Style.Add("display", "block");
                this.div_NavigationID.Style.Add("display", "none");
                this.spnLoginID.InnerHtml = "Login";
            }
            this.AccountType = this.comm.return_AccountType((long)Login.companyID, Login.AccountID);
            if (this.Session["StoreUserID"] == null)
            {
                if (this.AccountType == "p")
                {
                    this.lbl_NewUser.Text = this.objLanguage.GetLanguageConversion("NEW_USERS");
                    this.lbl_RegisteredCustomer.Text = this.objLanguage.GetLanguageConversion("REGISTERED_USERS");
                    this.spnLoginID.InnerHtml = this.objLanguage.GetLanguageConversion("Login");
                    this.td_NewUserID.Style.Add("display", "none");
                    this.div_NavigationID.Style.Add("display", "none");
                }
                else if (this.AccountType == "x")
                {
                    if (this.comm.GetDisplayValue("IsHome", Login.AccountID) != "true")
                    {
                        this.lbl_home.Visible = false;
                        this.lbl_spliter.Visible = false;
                    }
                    else
                    {
                        this.lbl_home.Text = ConnectionClass.PageName(Login.companyID, Convert.ToInt32(Login.AccountID), 0);
                        this.lbl_home.Visible = true;
                        this.lbl_spliter.Visible = true;
                    }
                }
            }
            if (this.AccountType == "p")
            {
                this.td_NewUserID.Style.Add("display", "none");
                this.spnLoginID.InnerHtml = "Login";
            }
            HtmlImage htmlImage = this.imgError;
            object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=i_msg-error.gif&amp;type=r&amp;aid=", Login.AccountID, " &amp;cid=", Login.companyID };
            htmlImage.Src = string.Concat(accountID);
            base.Title = commonclass.pageTitle("Login", Convert.ToInt32(Login.companyID), Convert.ToInt32(Login.AccountID));
            this.txt_loginemail.Focus();
            this.NewSessionID = this.comm.UniqueID;
            if (!base.IsPostBack)
            {
                this.AutoLogin();
            }
            if (base.Request.QueryString["from"] != null)
            {
                this.Frompage = base.Request.QueryString["from"].ToString();
            }
            this.btn_createAccount.Text = this.objLanguage.GetLanguageConversion("Create_An_Account");
            this.req_.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.RegularExpressionValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("Email_Address_Example_Note");
            this.RequiredFieldValidator1.ErrorMessage = this.objLanguage.GetLanguageConversion("This_is_a_required_field");
            this.BtnLogin.Text = this.objLanguage.GetLanguageConversion("Login");
            this.lbl_NewUser.Text = this.objLanguage.GetLanguageConversion("NEW_USERS");
            this.lbl_RegisteredCustomer.Text = this.objLanguage.GetLanguageConversion("REGISTERED_USERS");
            if (this.Session["StoreUserID"] == null || Login.AccountID == (long)0)
            {
                base.Response.Redirect(string.Concat(this.strSitepath.Trim(), "/Default.aspx"));
            }
        }
    }
}