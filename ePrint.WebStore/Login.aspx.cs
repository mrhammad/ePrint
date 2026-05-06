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


namespace ePrint.WebStore
{
    public partial class Login : BaseClass, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected HiddenField hdnAccountID;

        //protected System.Web.UI.ScriptManager sm1;

        //protected PlaceHolder ph_headerLeft;

        //protected HtmlTableCell tdheaderimage;

        //protected HtmlTable tblheaderimage;

        //protected Label lblLogInHead;

        //protected HtmlImage imgError;

        //protected Label lblSucess;

        //protected HtmlGenericControl div_InvalidMsg;

        //protected Label lblbl;

        //protected TextBox txtEmail;

        //protected RequiredFieldValidator RequiredFieldValidator1;

        //protected Label Label2;

        //protected TextBox txtPassword;

        //protected RequiredFieldValidator RequiredFieldValidator2;

        //protected HtmlGenericControl div_password;

        //protected Button Button1;

        //protected HtmlInputCheckBox chkrememberme;

        //protected HtmlGenericControl div_rememberme;

        //protected Label lblRememberMe;

        //protected LinkButton LnkForGotPass;

        //protected LinkButton lnkRegister;

        //protected HtmlAnchor lnktoInkiAdminMail;

        //protected HtmlTableCell ForgotPassAndRegistration;

        //protected Label lblBelowLogin;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HtmlGenericControl divfootersub;

        //protected HtmlGenericControl divfooterMain;

        //protected HtmlForm form1;

        //protected HtmlGenericControl BodyBackColor;

        public string strImagepath = BaseClass.imagePath();

        public string SesseionKey = string.Empty;

        public string AccountType = "P";

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        public string Email = string.Empty;

        public string Pwd = string.Empty;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objbase = new BaseClass();

        public bool IsActive;

        public long StoreUserID;

        public static int companyID;

        public static long AccountID;

        public string RewriteModule = string.Empty;

        public string IsHomePageVisible = string.Empty;

        public string IsPPW = string.Empty;

        public string NewSessionID = string.Empty;

        private DataTable dtDisplaySetting;

        public string VersionNumber = ConnectionClass.VersionNumber;

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

        public string cookielogout = string.Empty;

        public string cookieval = string.Empty;

        public long cookieClientID;

        public string footer_id = string.Empty;

        private string DefaultLandPageName = string.Empty;

        private int PageID;

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
            Login.companyID = 0;
            Login.AccountID = (long)0;
        }

        public Login()
        {
        }

        public void _Login(string Email, string Password)
        {
            bool flag = false;
            this.Session["IsHomePageVisible"] = null;
            this.Session["IsPPW"] = null;
            if (!(this.hdnAccountID.Value.Trim() != "0") || !(this.hdnAccountID.Value.Trim() != ""))
            {
                Login.AccountID = (long)0;
            }
            else 
            {
                Login.AccountID = Convert.ToInt64(this.hdnAccountID.Value);
            }

            Password = base.Return_ApprovalRegistration_Settings("issinglefield") == "True" ? "" : Password;
            DataTable dataTable = LoginBasePage.LoginTo_Store(this.objbase.SpecialEncode(Email), Password, Login.AccountID, ConnectionClass.AccountType);
            if (dataTable.Rows.Count == 0 && Login.AccountID != (long)0 && base.Request["id"] == null)
            {
                dataTable = LoginBasePage.LoginTo_Store(this.objbase.SpecialEncode(Email), Password, (long)0, ConnectionClass.AccountType);
            }
            if (!this.chkrememberme.Checked)
            {
                base.Response.Cookies["CooEmail"].Value = Email;
                base.Response.Cookies["CooEmail"].Expires = DateTime.Now.AddDays(100);
                base.Response.Cookies["CooPassword"].Expires = DateTime.Now.AddDays(-1);
            }
            else
            {
                base.Response.Cookies["CooEmail"].Value = Email;
                base.Response.Cookies["CooPassword"].Value = Password;
                base.Response.Cookies["CooEmail"].Expires = DateTime.Now.AddDays(100);
                base.Response.Cookies["CooPassword"].Expires = DateTime.Now.AddDays(100);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                base.Response.Cookies["B2BAccountID"].Value = row["AccountID"].ToString();
                this.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                Login.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                this.dtDisplaySetting = CMSBasePage.GetDisplaySettings(Login.AccountID);
                if (!Convert.ToBoolean(row["IsActive"].ToString()))
                {
                    flag = false;
                    this.IsActive = true;
                    this.Session["IsHomePageVisible"] = null;
                    this.Session["IsPPW"] = null;
                }
                else
                {
                    this.Session["AccountID"] = Login.AccountID.ToString();
                    this.Session["eStoreDisplaySetting"] = this.dtDisplaySetting;
                    flag = true;
                    this.IsActive = false;
                    this.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    this.Session["IsPPW"] = row["IsPPW"].ToString();
                    this.Session["LanguageConversion"] = row["LanguageConversionFile"].ToString();
                    if (!(this.hdnAccountID.Value.Trim() != "0") || !(this.hdnAccountID.Value.Trim() != ""))
                    {
                        continue;
                    }
                    base.Assign_ApprovalSystemSettings_ForAccount(Convert.ToInt64(this.hdnAccountID.Value));
                }
            }
            if (!flag)
            {
                if (this.IsActive)
                {
                    this.lblSucess.Text = this.objLanguage.GetLanguageConversion("Your_account_is_deactivated");
                    this.lblSucess.CssClass = "InvalidLoginText";
                    this.div_InvalidMsg.Attributes.Add("style", "display:block");
                    return;
                }
                this.lblSucess.Text = this.objLanguage.GetLanguageConversion("Invalid_login_or_password");
                this.lblSucess.CssClass = "InvalidLoginText";
                this.div_InvalidMsg.Attributes.Add("style", "display:block");
                return;
            }
            this.SesseionKey = this.comm.UniqueID;
            this.login.Insert_intoResume_Session(base.SpecialEncode(Email), Password, Login.AccountID);
            this.login.LogInFromDefault(base.SpecialEncode(Email), Password);
            CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
            Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            if (this.Session["fromEmail"] != null && this.Session["fromEmail"] != null)
            {
                base.Response.Redirect(this.Session["fromEmail"].ToString());
                return;
            }
            int num = 0;
            DataTable cartItemCount = CartBasePage.Get_CartItemCount(this.StoreUserID);
            if (cartItemCount.Rows.Count > 0 && cartItemCount.Rows[0]["Count"].ToString() != "0")
            {
                num = Convert.ToInt32(cartItemCount.Rows[0]["Count"]);
            }
            if (this.Session["RedirectToUserRegApprovalPage"] != null && this.Session["RedirectToUserRegApprovalPage"] != null)
            {
                base.Response.Redirect(this.Session["RedirectToUserRegApprovalPage"].ToString());
            }
            if (this.Session["RedirectToProfModApprovalPage"] != null && this.Session["RedirectToProfModApprovalPage"] != null)
            {
                base.Response.Redirect(this.Session["RedirectToProfModApprovalPage"].ToString());
            }
            if (this.Session["RedirectToApproverOrderPage"] != null && this.Session["RedirectToApproverOrderPage"] != null)
            {
                base.Response.Redirect(this.Session["RedirectToApproverOrderPage"].ToString());
            }
            if (this.Session["RedirectToUserOrderPage"] != null && this.Session["RedirectToUserOrderPage"] != null)
            {
                base.Response.Redirect(this.Session["RedirectToUserOrderPage"].ToString());
            }
            if (num == 0 && ConnectionClass.AccountType.Trim().ToLower() != "public")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
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
                    this._Login(base.SpecialEncode(str), str4);
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

        public static int CountStringOccurrences(string text, string pattern)
        {
            int num = 0;
            int length = 0;
            while (true)
            {
                int num1 = text.IndexOf(pattern, length);
                length = num1;
                if (num1 == -1)
                {
                    break;
                }
                length = length + pattern.Length;
                num++;
            }
            return num;
        }

        protected void LnkForGotPass_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "forgotpassword.aspx?id=", this.hdnAccountID.Value));
        }

        public string MD5Hash(string text)
        {
            MD5 mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            return Regex.Replace(BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(text))), "-", "");
        }

        protected void Onclick_BtnLogin(object sender, EventArgs e)
        {
            this._Login(base.SpecialEncode(this.txtEmail.Text), this.txtPassword.Text);
        }

        protected void Onclick_btnRegister(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "B2B_Registration.aspx?id=", this.hdnAccountID.Value));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] publicDocPath;
            string[] bannerImageFooter;
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
            else if (base.Request.Url.ToString().ToLower().IndexOf("porderingonline.co.nz") != -1)
            {
                if (base.Request.QueryString["ID"] == null)
                {
                    base.Response.Redirect("http://www.vporderingonline.co.nz/login.aspx?ID=276");
                }
                if (base.Request.QueryString["ID"] != null)
                {
                    this.LnkForGotPass.Style.Add("display", "none");
                    this.txtEmail.Text = "vp@vporderingonline.co.nz";
                    string str = this.AutoLogin_Check(this.txtEmail.Text);
                    this.txtPassword.Attributes.Add("value", str);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("printbank") != -1)
            {
                bool flag1 = false;
                string lower1 = base.Request.Url.ToString().ToLower();
                if (lower1.ToString().ToLower().IndexOf("https") == -1)
                {
                    lower1 = lower1.Replace("http", "https");
                    flag1 = true;
                }
                if (flag1)
                {
                    base.Response.Redirect(lower1);
                }
            }
            else if (base.Request.Url.ToString().ToLower().IndexOf("eprintsoftware") != -1)
            {
                bool flag2 = false;
                string str1 = base.Request.Url.ToString().ToLower();
                if (str1.ToString().ToLower().IndexOf("https") == -1)
                {
                    str1 = str1.Replace("http", "https");
                    flag2 = true;
                }
                if (flag2)
                {
                    base.Response.Redirect(str1);
                }
            }
            this.LnkForGotPass.Text = this.objLanguage.GetLanguageConversion("Forgot_Password");
            this.Label2.Text = this.objLanguage.GetLanguageConversion("Password");
            this.lnkRegister.Text = this.objLanguage.GetLanguageConversion("New_User_Register");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (base.Request["id"] == null)
            {
                this.BodyBackColor.Style.Add("background-color", "white");
                base.Response.Cookies["B2B_AccountID"].Value = null;
            }
            else
            {
                this.LnkForGotPass.Style.Add("display", "block");
                this.hdnAccountID.Value = base.Request["id"].ToString();
                if (base.Request["from"] == null || !(base.Request["from"].ToString() != "mis"))
                {
                    base.Response.Cookies["B2B_AccountID"].Value = null;
                }
                else
                {
                    this.Session.Abandon();
                    base.Response.Cookies["B2B_AccountID"].Value = base.Request["id"].ToString();
                }
            }
            if ((this.hdnAccountID.Value.Trim() == "0" || this.hdnAccountID.Value.Trim() == "") && base.Request.Cookies["B2BAccountID"] != null)
            {
                this.hdnAccountID.Value = base.Request.Cookies["B2BAccountID"].Value;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (!(this.hdnAccountID.Value.Trim() != "0") || !(this.hdnAccountID.Value.Trim() != ""))
            {
                Login.AccountID = Convert.ToInt64(0);
            }
            else
            {
                Login.AccountID = Convert.ToInt64(this.hdnAccountID.Value);
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.RewriteModule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.PublicDocPath != null && ConnectionClass.ServerName != null)
            {
                publicDocPath = new object[] { ConnectionClass.PublicDocPath, ConnectionClass.ServerName, "/store/", Login.AccountID };
                this.StyleSheetPath = string.Concat(publicDocPath);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.PublicDocPath, "store/0");
            }
            this.Page.Header.DataBind();
            long accountID = (long)0;
            accountID = Login.AccountID;
            if (base.Request.Params["from"] != null && base.Request.Params["from"] != "" && base.Request.Params["from"].ToLower() == "campaign")
            {
                accountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            DataTable dataTable = LoginBasePage.SelectB2B_DefaultLandingPage(Login.companyID, Convert.ToInt64(accountID), "view");
            foreach (DataRow row in dataTable.Rows)
            {
                if (!Convert.ToBoolean(row["IsDefaultLand"]))
                {
                    continue;
                }
                this.DefaultLandPageName = row["systemName"].ToString();
                this.pageID = Convert.ToInt32(row["pageID"]);
                break;
            }
            if (base.Request["b2bemail"] == null || base.Request["b2bpwd"] == null)
            {
                if (this.Session["StoreUserID"] != null && this.DefaultLandPageName.ToLower() == "campaign")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "campaign.aspx"));
                }
                if (this.Session["StoreUserID"] != null)
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                }
            }
            else
            {
                this.Email = base.Request["b2bemail"].ToString();
                this.Pwd = base.Request["b2bpwd"].ToString();
                this.SesseionKey = this.comm.UniqueID;
                this.login.Insert_intoResume_Session(base.SpecialEncode(this.Email), this.Pwd, Login.AccountID);
                this.login.LogInFromDefault(base.SpecialEncode(this.Email), this.Pwd);
                CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
                Login.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
                DataTable dataTable1 = LoginBasePage.LoginTo_Store(this.objbase.SpecialEncode(this.Email), this.Pwd, Login.AccountID, this.AccountType);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.StoreUserID = Convert.ToInt64(dataRow["StoreUserID"].ToString());
                    if (!Convert.ToBoolean(dataRow["IsActive"].ToString()))
                    {
                        this.Session["IsHomePageVisible"] = null;
                        this.Session["IsPPW"] = null;
                    }
                    else
                    {
                        this.Session["IsHomePageVisible"] = dataRow["IsHomePage"].ToString();
                        this.Session["IsPPW"] = dataRow["IsPPW"].ToString();
                    }
                }
                this.dtDisplaySetting = CMSBasePage.GetDisplaySettings(Login.AccountID);
                this.Session["eStoreDisplaySetting"] = this.dtDisplaySetting;
                if (this.Session["fromEmail"] != null && this.Session["fromEmail"].ToString() != "")
                {
                    base.Response.Redirect(this.Session["fromEmail"].ToString());
                }
                else if (this.DefaultLandPageName.ToLower() == "products")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                }
                else if (this.DefaultLandPageName.ToLower() == "home")
                {
                    base.Response.Redirect(this.strSitepath);
                }
                else if (this.DefaultLandPageName.ToLower() == "orders")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/myorder.aspx"));
                }
                else if (this.DefaultLandPageName.ToLower() == "saved drafts")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "my_design.aspx"));
                }
                else if (this.DefaultLandPageName.ToLower() == "campaign")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "campaign.aspx"));
                }
                else if (this.DefaultLandPageName.ToLower() == "my account")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "account/account.aspx"));
                }
                else if (this.DefaultLandPageName.ToLower() == "")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "products/product.aspx?ID=0"));
                }
                else if (this.DefaultLandPageName.ToLower() != "reports")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "cms.aspx?ID=", this.pageID));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "estore_reports.aspx"));
                }
            }
            HtmlImage htmlImage = this.imgError;
            object[] objArray = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=error.gif&amp;type=r&amp;aid=", Login.AccountID, " &amp;cid=", Login.companyID };
            htmlImage.Src = string.Concat(objArray);
            if (this.hdnAccountID.Value.Trim() != "0" && this.hdnAccountID.Value.Trim() != "")
            {
                if (base.Request["id"] != null)
                {
                    this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(Convert.ToInt64(this.hdnAccountID.Value));
                    base.Title = commonclass.pageTitle("Login", Convert.ToInt32(Login.companyID), Convert.ToInt32(this.hdnAccountID.Value));
                }
                this.txtEmail.Focus();
                this.Button1.Text = this.objLanguage.GetLanguageConversion("Login");
                this.NewSessionID = this.comm.UniqueID;
                string str2 = LoginBasePage.Select_Phrases("Login Messages", (long)Convert.ToInt32(this.hdnAccountID.Value));
                int num = 0;
                if (str2 != null)
                {
                    int num1 = Login.CountStringOccurrences(str2.ToLower(), "[tickbox]");
                    if (num1 > 0)
                    {
                        for (int i = 0; i < num1; i++)
                        {
                            Regex regex = new Regex(Regex.Escape("[tickbox]"), RegexOptions.IgnoreCase);
                            str2 = regex.Replace(str2, string.Concat("<input type='checkbox' id='chkval", i, "'  />"), 1);
                            num++;
                        }
                    }
                    this.lblLogInHead.Text = base.SpecialDecode(str2).ToString().Replace("<a ", "<a class='alogin'");
                }
                str2 = LoginBasePage.Select_Phrases("Below Login Messages", (long)Convert.ToInt32(this.hdnAccountID.Value));
                if (str2 != null)
                {
                    int num2 = Login.CountStringOccurrences(str2.ToLower(), "[tickbox]");
                    if (num2 > 0)
                    {
                        for (int j = 0; j < num2; j++)
                        {
                            Regex regex1 = new Regex(Regex.Escape("[tickbox]"), RegexOptions.IgnoreCase);
                            str2 = regex1.Replace(str2, string.Concat("<input type='checkbox' id='chkval", num, "' />"), 1);
                            num++;
                        }
                    }
                    this.lblBelowLogin.Text = base.SpecialDecode(str2).ToString().Replace("<a ", "<a class='alogin'");
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["CooEmail"] != null && base.Request.Cookies["CooPassword"] != null)
                {
                    this.txtEmail.Text = base.SpecialDecode(base.Request.Cookies["CooEmail"].Value);
                    this.txtPassword.Attributes.Add("value", base.Request.Cookies["CooPassword"].Value);
                    this.chkrememberme.Checked = true;
                    this._Login(base.SpecialEncode(base.Request.Cookies["CooEmail"].Value), base.Request.Cookies["CooPassword"].Value);
                }
                else if (base.Request.Cookies["CooEmail"] != null && base.Request.Cookies["CooPassword"] == null)
                {
                    this.txtEmail.Text = base.SpecialDecode(base.Request.Cookies["CooEmail"].Value);
                }
            }
            if (ConnectionClass.SecureDocFilepath != null)
            {
                object[] secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", Login.AccountID, "\\banners\\" };
                this.bannerImagePath = string.Concat(secureDocFilepath);
            }
            DataTable dataTable2 = new DataTable();
            dataTable2 = LoginBasePage.Select_CompanyID(Login.AccountID);
            IEnumerator enumerator = dataTable2.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    Login.AccCompanyID = Convert.ToInt32(current["CompanyID"].ToString());
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
            this.footer_id = "footer_content";
            if (ConnectionClass.ServerName != "inki")
            {
                DataTable dataTable3 = CMSBasePage.headerSelect(Login.AccCompanyID, Convert.ToInt32(Login.AccountID), "H");
                foreach (DataRow row1 in dataTable3.Rows)
                {
                    if (base.Request["id"] == null && Login.AccountID == (long)0)
                    {
                        continue;
                    }
                    if (row1["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageHeader = row1["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageHeader)))
                        {
                            object[] accountID1 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", Login.AccountID, "&amp;cid=", Login.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID1);
                        }
                        else
                        {
                            object[] objArray1 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageHeader, "&amp;type=b&amp;aid=", Login.AccountID, "&amp;cid=", Login.AccCompanyID };
                            this.BannerImageHeader = string.Concat(objArray1);
                        }
                        int width = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath1 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", Login.AccountID, "/banners/", row1["logoImage"].ToString() };
                            string str3 = string.Concat(secureDocFilepath1);
                            if (File.Exists(str3))
                            {
                                width = System.Drawing.Image.FromFile(str3).Width;
                            }
                        }
                        if (!Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                            this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                        }
                        else
                        {
                            this.tblheaderimage.Attributes["class"] = "width100p";
                            this.tdheaderimage.Attributes["class"] = "width100p paddingBottom5 floatLeft";
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
                            else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' alt=' '/></a>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' alt=' '/></a>")));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/></a>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' alt=' '/></a>")));
                                }
                            }
                            else if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/></a>")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' alt=' '/></a>")));
                            }
                        }
                        else if (this.BannerImageHeader == "")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' /></a>")));
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width <= 950)
                                {
                                    ControlCollection controls = this.ph_headerLeft.Controls;
                                    string[] strArrays = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' /></a>" };
                                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                                }
                                else
                                {
                                    ControlCollection controlCollections = this.ph_headerLeft.Controls;
                                    bannerImageFooter = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
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
                                    string[] strArrays2 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' /></a>" };
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
                                string[] strArrays4 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(strArrays4)));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoResized"]))
                        {
                            if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (width <= 950)
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 950px;' class='floatLeft' alt=' ' />")));
                        }
                    }
                    if (row1["logoType"].ToString().Trim() == "T")
                    {
                        this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                        this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1";
                        string str4 = null;
                        str4 = (row1["logoText"].ToString().Trim().Length <= 40 ? row1["logoText"].ToString().Trim() : row1["logoText"].ToString().Trim().Substring(0, 40));
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext'> <label id='lbl_headerTextLeft' class='logoText'>", base.SpecialDecode(str4), "</label></div>")));
                    }
                    if (row1["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1";
                    string str5 = null;
                    str5 = row1["logoTemplate"].ToString().Trim();
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", base.SpecialDecode(str5), "</label>")));
                }
                if (dataTable3.Rows.Count == 0)
                {
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1";
                }
            }
            else
            {
                this.BodyBackColor.Style.Add("background-color", "white");
                this.LnkForGotPass.Attributes.Add("style", "color:grey");
                this.lnktoInkiAdminMail.Attributes.Add("style", "color:grey");
                this.lnktoInkiAdminMail.Style.Add("display", "block");
                this.LnkForGotPass.Text = "Forgotten Password?";
                this.LnkForGotPass.Style.Add("display", "block");
                this.footer_id = "footer_content_Inki";
                this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl_Inki";
                this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1_Inki";
            }
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable4 = CMSBasePage.CMSPages_get(Convert.ToInt32(Login.AccCompanyID), Convert.ToInt32(Login.AccountID), 0);
            dataTable4.Select("ShowPagesIN ='H' or ShowPagesIN ='B'");
            foreach (DataRow dataRow1 in dataTable4.Rows)
            {
                if (!(dataRow1["showPagesIn"].ToString().Trim() == "B") && !(dataRow1["showPagesIn"].ToString().Trim() == "F"))
                {
                    continue;
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (dataRow1["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        string[] strArrays5 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow1["pageName"].ToString().Trim(), " </a></div>" };
                        stringBuilder.Append(string.Concat(strArrays5));
                    }
                    else if (dataRow1["systemName"].ToString().ToLower().Trim() == "products")
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", dataRow1["pageName"].ToString().Trim(), " </a></div>"));
                    }
                    else if (dataRow1["systemName"].ToString().ToLower().Trim() != "sitemap")
                    {
                        string[] strArrays6 = new string[] { "<div><a href='", null, null, null, null };
                        publicDocPath = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), ConnectionClass.KeySeparator, Convert.ToInt32(dataRow1["pageID"].ToString()), ConnectionClass.FileExtension };
                        strArrays6[1] = base.ResolveUrl(string.Concat(publicDocPath));
                        strArrays6[2] = "'> ";
                        strArrays6[3] = dataRow1["pageName"].ToString().Trim();
                        strArrays6[4] = " </a></div>";
                        stringBuilder.Append(string.Concat(strArrays6));
                    }
                    else
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", dataRow1["pageName"].ToString().Trim(), " </a></div>"));
                    }
                }
                else if (dataRow1["systemName"].ToString().ToLower().Trim() == "home")
                {
                    bannerImageFooter = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow1["pageName"].ToString().Trim(), " </a></div>" };
                    stringBuilder.Append(string.Concat(bannerImageFooter));
                }
                else if (dataRow1["systemName"].ToString().ToLower().Trim() == "products")
                {
                    stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", dataRow1["pageName"].ToString().Trim(), " </a></div>"));
                }
                else if (dataRow1["systemName"].ToString().ToLower().Trim() != "sitemap")
                {
                    publicDocPath = new object[] { "<div><a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(dataRow1["pageID"].ToString()), "'> ", dataRow1["pageName"].ToString().Trim().Trim(), "</a></div>" };
                    stringBuilder.Append(string.Concat(publicDocPath));
                }
                else
                {
                    stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", dataRow1["pageName"].ToString().Trim(), " </a></div>"));
                }
            }
            this.ph_footer.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            if (ConnectionClass.ServerName != "inki")
            {
                DataTable dataTable5 = CMSBasePage.headerSelect(Convert.ToInt32(Login.AccCompanyID), Convert.ToInt32(Login.AccountID), "F");
                foreach (DataRow row2 in dataTable5.Rows)
                {
                    if (base.Request["id"] == null && Login.AccountID == (long)0)
                    {
                        continue;
                    }
                    if (row2["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageFooter = row2["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageFooter)))
                        {
                            publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", Login.AccountID, "&amp;cid=", Login.AccCompanyID };
                            this.BannerImageHeader = string.Concat(publicDocPath);
                        }
                        else
                        {
                            publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageFooter, "&amp;type=b&amp;aid=", Login.AccountID, "&amp;cid=", Login.AccCompanyID };
                            this.BannerImageFooter = string.Concat(publicDocPath);
                        }
                        int width1 = 0;
                        if (this.BannerImageHeader != "")
                        {
                            publicDocPath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", Login.AccountID, "/banners/", row2["logoImage"].ToString() };
                            string str6 = string.Concat(publicDocPath);
                            if (File.Exists(str6))
                            {
                                width1 = System.Drawing.Image.FromFile(str6).Width;
                            }
                        }
                        if (!Convert.ToBoolean(row2["IsLogoEnlarged"]))
                        {
                            this.divfooterMain.Attributes["class"] = "footer_div";
                            this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        }
                        else
                        {
                            this.divfooterMain.Attributes["class"] = "footer_divsub";
                        }
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            if (this.IsHomePageVisible == "1")
                            {
                                if (Convert.ToBoolean(row2["IsLogoEnlarged"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls3 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;'  alt=' ' /></a>" };
                                        controls3.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections3 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;'  alt=' ' /></a>" };
                                        controlCollections3.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                }
                                else if (Convert.ToBoolean(row2["IsLogoResized"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls4 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  alt=' ' /></a>" };
                                        controls4.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections4 = this.ph_copyWriter.Controls;
                                        bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' /></a>" };
                                        controlCollections4.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                    }
                                }
                                else if (width1 <= 950)
                                {
                                    ControlCollection controls5 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  alt=' ' /></a>" };
                                    controls5.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections5 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' /></a>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(row2["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'   style='width: 100%;' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'   style='width: 100%;' alt=' ' />")));
                                }
                            }
                            else if (Convert.ToBoolean(row2["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' />")));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' />")));
                            }
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(row2["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls6 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  style='width: 100%;'  alt=' ' /></a>" };
                                    controls6.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections6 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  style='width: 100%;'  alt=' ' /></a>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (Convert.ToBoolean(row2["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls7 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  alt=' ' /></a>" };
                                    controls7.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections7 = this.ph_copyWriter.Controls;
                                    bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' /></a>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                ControlCollection controls8 = this.ph_copyWriter.Controls;
                                bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "'  alt=' ' /></a>" };
                                controls8.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                            }
                            else
                            {
                                ControlCollection controlCollections8 = this.ph_copyWriter.Controls;
                                bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;'  alt=' ' /></a>" };
                                controlCollections8.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                            }
                        }
                        else if (Convert.ToBoolean(row2["IsLogoEnlarged"]))
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
                        else if (Convert.ToBoolean(row2["IsLogoResized"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                            }
                        }
                        else if (width1 <= 950)
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "'  alt=' ' />")));
                        }
                        else
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' />")));
                        }
                    }
                    if (row2["logoType"].ToString().Trim() == "T")
                    {
                        this.divfooterMain.Attributes["class"] = "footer_div";
                        this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", base.SpecialDecode(row2["logoText"].ToString().Trim()), "</label>")));
                    }
                    if (row2["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", base.SpecialDecode(row2["logoTemplate"].ToString().Trim()), "</label>")));
                }
                if (dataTable5.Rows.Count == 0)
                {
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                }
            }
            else
            {
                this.divfooterMain.Attributes["class"] = "footer_content";
            }
            if (base.Request["id"] != null)
            {
                if (LoginBasePage.IsSelfRegister_Select(Login.AccountID) != 1)
                {
                    this.lnkRegister.Style.Add("display", "none");
                }
                else
                {
                    this.lnkRegister.Style.Add("display", "block");
                    if (ConnectionClass.ServerName.ToLower() == "inki")
                    {
                        this.lnkRegister.Attributes.Add("style", "color:grey");
                    }
                }
                if (Login.AccountID != (long)0)
                {
                    this.objbase.Assign_ApprovalSystemSettings_ForAccount(Login.AccountID);
                }
            }
            if (base.Return_ApprovalRegistration_Settings("issinglefield") == "True")
            {
                this.div_password.Style.Add("display", "none");
                this.txtPassword.Style.Add("display", "none");
                this.div_rememberme.Style.Add("display", "none");
                this.LnkForGotPass.Style.Add("display", "none");
                this.Label2.Style.Add("display", "none");
                this.Label2.Text = this.objLanguage.GetLanguageConversion("Reenter_your_email");
                this.txtEmail.Attributes.Add("onkeyup", "javascript: CopyEmailtoPassword(this,this.value);");
                this.txtEmail.Attributes.Add("onblur", " javascript: CopyEmailtoPassword(this.id,this.value);");
            }
            this.lblRememberMe.Text = this.objLanguage.GetLanguageConversion("Stay_logged_in");
        }
    }
}