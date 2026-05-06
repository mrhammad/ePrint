using ePrint.MyPublicStore.Templates;
using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace ePrint.MyPublicStore
{
    public partial class LoginMethods : System.Web.UI.Page, IRequiresSessionState
    {
        //protected HtmlForm form1;

        public commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        public languageClass objLanguage = new languageClass();

        public static int companyID;

        public static long AccountID;

        public string RewriteModule = string.Empty;

        public string strSitepath = string.Empty;

        public string SesseionKey = string.Empty;

        public string AccountType = string.Empty;

        public string NewSessionID = string.Empty;

        public static string accountType;
        public static string DefaultLandPageName = string.Empty;
        public static string accID = string.Empty;
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

        static LoginMethods()
        {
        }

        public LoginMethods()
        {
        }

        [WebMethod(EnableSession = true)]
        public static IList<LoginMethods.CreateAcctDetails> accountcreate(string AddEmilToDmc, string txtcompanyname, string txtsignupEmail, string txtuname, string txtlname, string txtupass, string agentcode, string Phone,string mobilePhone)
        {
            DateTime dateTime;
            BaseClass baseClass = new BaseClass();
            commonclass _commonclass = new commonclass();
            long num = (long)Convert.ToInt32(ConnectionClass.CompanyID);
            int num1 = 0;
            long num2 = (long)0;
            if (ConnectionClass.AccountID != null)
            {
                num1 = Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.ServerName.ToLower() == "phoneink")
            {
                foreach (DataRow row in LoginBasePage.Public_User_ClientIDbyAgentCode(num, LoginMethods.AccountID, agentcode).Rows)
                {
                    num2 = Convert.ToInt64(row["ClientID"]);
                }
            }
            List<LoginMethods.CreateAcctDetails> createAcctDetails = new List<LoginMethods.CreateAcctDetails>();
            LoginMethods.CreateAcctDetails createAcctDetail = new LoginMethods.CreateAcctDetails();
            string empty = string.Empty;
            foreach (DataRow dataRow in LoginBasePage.Select_AccountDetails(num, Convert.ToInt64(num1)).Rows)
            {
                empty = dataRow["DateFormat"].ToString();
            }
            try
            {
                DateTime now = DateTime.Now;
                dateTime = Convert.ToDateTime(_commonclass.date_Check_new(empty, _commonclass.Eprint_return_Date_Before_View(now.ToString(), Convert.ToInt32(num), 0, true)));
            }
            catch
            {
                dateTime = DateTime.Now;
            }
            long num3 = (long)0;
            loginclass _loginclass = new loginclass();
            if (LoginBasePage.CheckEmailID_Duplicacy(num3, baseClass.SpecialDecode(txtsignupEmail), Convert.ToInt64(num1)) != -1)
            {
                int num4 = 0;
                num4 = (AddEmilToDmc != "true" ? 0 : 1);
                num3 = (num2 == (long)0 ? LoginBasePage.Create_StoreUser((long)0, (long)0, baseClass.SpecialEncode(txtuname), baseClass.SpecialEncode(txtlname), baseClass.SpecialEncode(txtsignupEmail), txtupass, num, Convert.ToInt64(num1), "new", baseClass.SpecialEncode(txtcompanyname), num4) : LoginBasePage.Create_StoreUser_AgentCode((long)0, num2, baseClass.SpecialEncode(txtuname), baseClass.SpecialEncode(txtlname), baseClass.SpecialEncode(txtsignupEmail), txtupass, num, Convert.ToInt64(num1), "new", baseClass.SpecialEncode(txtcompanyname), num4));
                if (num3 != (long)0)
                {
                    loginclass _loginclass1 = new loginclass();
                    string uniqueID = _commonclass.UniqueID;
                    _loginclass1.Insert_intoResume_Session(baseClass.SpecialEncode(txtsignupEmail), txtupass);
                    CartBasePage.Update_Cart_StoreUserID(uniqueID, num3);
                    EmailClass emailClass = new EmailClass();
                    long num5 = (long)0;
                    long num6 = (long)0;
                    if (num2 == (long)0)
                    {
                        OrderBasePage.Insert_CustomerOn_Order(num, num3, Convert.ToInt64(num1), num5, num6, "yes", dateTime,Phone,mobilePhone);
                    }
                    else
                    {
                        OrderBasePage.Insert_CustomerOn_OrderAgentCode(num, num3, Convert.ToInt64(num1), num5, num6, "yes", dateTime);
                    }
                    _loginclass1.LogInFromDefault(baseClass.SpecialEncode(txtsignupEmail), txtupass);
                    emailClass.emailRegisterDetails(Convert.ToInt32(num3), Convert.ToInt32(num), Convert.ToInt32(num1), "New User Registration");
                }
                string str = _commonclass.UniqueID;
                int num7 = 0;
                foreach (DataRow row1 in CartBasePage.Select_CartItems(str, "", num3).Rows)
                {
                    num7++;
                }
                if (!(ConnectionClass.ServerName.ToLower() == "phoneink") || num2 == (long)0)
                {
                    createAcctDetail.Result = num7.ToString();
                }
                else
                {
                    createAcctDetail.Result = "phoneink";
                }
            }
            else
            {
                createAcctDetail.Result = "exists";
            }
            createAcctDetails.Add(createAcctDetail);
            return createAcctDetails;
        }

        [WebMethod(EnableSession = true)]
        public static IList<LoginMethods.ForgotPwdDetails> ForgotPassword(string txtEmail, string accid, string AccountType)
        {
            BaseClass baseClass = new BaseClass();
            List<LoginMethods.ForgotPwdDetails> forgotPwdDetails = new List<LoginMethods.ForgotPwdDetails>();
            LoginMethods.ForgotPwdDetails forgotPwdDetail = new LoginMethods.ForgotPwdDetails();
            loginclass _loginclass = new loginclass();
            if (LoginBasePage.CheckEmailID_Duplicacy((long)0, baseClass.SpecialEncode(txtEmail), Convert.ToInt64(accid)) != -1)
            {
                forgotPwdDetail.Result = "not exists";
            }
            else
            {
                EmailClass emailClass = new EmailClass();
                DataTable dataTable = LoginBasePage.LoginTo_Store(baseClass.SpecialEncode(txtEmail.Trim()), "", Convert.ToInt64(accid), ConnectionClass.AccountType);
                foreach (DataRow row in dataTable.Rows)
                {
                    emailClass.emailPassword(Convert.ToInt32(row["StoreUserID"].ToString()), Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(row["AccountID"]), "Password Reminder Email");
                }
                forgotPwdDetail.Result = "success";
            }
            forgotPwdDetails.Add(forgotPwdDetail);
            return forgotPwdDetails;
        }

        [WebMethod(EnableSession = true)]
        public static IList<LoginMethods.GetClientIDDetails> GetCLientIDbyAgentcode(string AgentCode)
        {
            List<LoginMethods.GetClientIDDetails> getClientIDDetails = new List<LoginMethods.GetClientIDDetails>();
            LoginMethods.GetClientIDDetails getClientIDDetail = new LoginMethods.GetClientIDDetails();
            long num = Convert.ToInt64(ConnectionClass.CompanyID);
            long num1 = (long)0;
            if (ConnectionClass.AccountID != null)
            {
                num1 = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            DataTable dataTable = LoginBasePage.Public_User_ClientIDbyAgentCode(num, num1, AgentCode);
            foreach (DataRow row in dataTable.Rows)
            {
                getClientIDDetail.Result = row["ClientID"].ToString();
            }
            if (dataTable.Rows.Count == 0)
            {
                getClientIDDetail.Result = "0";
            }
            getClientIDDetails.Add(getClientIDDetail);
            return getClientIDDetails;
        }

        [WebMethod(EnableSession = true)]
        public static IList<LoginMethods.GetSecretCodeDetails> GetSecretCode(string SecretCode)
        {
            List<LoginMethods.GetSecretCodeDetails> getSecretCodeDetails = new List<LoginMethods.GetSecretCodeDetails>();
            LoginMethods.GetSecretCodeDetails getSecretCodeDetail = new LoginMethods.GetSecretCodeDetails();
            long num = Convert.ToInt64(ConnectionClass.CompanyID);
            long num1 = (long)0;
            if (ConnectionClass.AccountID != null)
            {
                num1 = (long)Convert.ToInt32(ConnectionClass.AccountID);
            }
            DataTable dataTable = LoginBasePage.Public_User_SecretCodebyAccountID(num, num1, SecretCode);
            foreach (DataRow row in dataTable.Rows)
            {
                getSecretCodeDetail.Result = row["SecretCode"].ToString();
            }
            if (dataTable.Rows.Count == 0)
            {
                getSecretCodeDetail.Result = "0";
            }
            getSecretCodeDetails.Add(getSecretCodeDetail);
            return getSecretCodeDetails;
        }

        [WebMethod(EnableSession = true)]
        public static IList<Properties.GetQuantity> LoadQuantity(string ChangedProductID)
        {
            IList<Properties.GetQuantity> getQuantities;
            try
            {
                getQuantities = ProductBasePage.Product_CatalogueQty_SelectFor_OtherMultiple((long)Convert.ToInt16(ChangedProductID));
            }
            catch
            {
                getQuantities = null;
            }
            return getQuantities;
        }

        [WebMethod(EnableSession = true)]
        public static IList<LoginMethods.LoginDetails> Login(string txtEmail, string txtPwd, string accid, string AccountType)
        {
            List<LoginMethods.LoginDetails> loginDetails = new List<LoginMethods.LoginDetails>();
            LoginMethods.LoginDetails loginDetail = new LoginMethods.LoginDetails();
            BaseClass baseClass = new BaseClass();
            bool flag = false;
            long num = (long)0;
            bool flag1 = false;
            accID = accid;
            HttpContext.Current.Session["accid"] = accid;
            HttpContext.Current.Session["AccountType"] = AccountType;
            HttpContext.Current.Session["IsHomePageVisible"] = null;
            HttpContext.Current.Session["IsPPW"] = null;
            DataTable dataTable = LoginBasePage.LoginTo_Store(baseClass.SpecialEncode(txtEmail), txtPwd, Convert.ToInt64(accid), ConnectionClass.AccountType);
            foreach (DataRow row in dataTable.Rows)
            {
                num = Convert.ToInt64(row["StoreUserID"].ToString());
                LoginMethods.AccountID = Convert.ToInt64(row["AccountID"].ToString());
                DataTable displaySettings = CMSBasePage.GetDisplaySettings(LoginMethods.AccountID);
                HttpContext.Current.Session["eStoreDisplaySetting"] = displaySettings;
                if (!Convert.ToBoolean(row["IsActive"].ToString()))
                {
                    flag1 = false;
                    flag = true;
                    HttpContext.Current.Session["IsHomePageVisible"] = null;
                    HttpContext.Current.Session["IsPPW"] = null;
                }
                else
                {
                    flag1 = true;
                    flag = false;
                    HttpContext.Current.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    HttpContext.Current.Session["IsPPW"] = row["IsPPW"].ToString();
                }
            }
            if (flag1)
            {
                loginDetail.Result = num.ToString();
            }
            else if (!flag)
            {
                loginDetail.Result = "invaliddetails";
            }
            else
            {
                loginDetail.Result = "accountdeactivated";
            }
            loginDetails.Add(loginDetail);
            return loginDetails;
        }

        [WebMethod(EnableSession = true)]
        public static string btnlogin_Click(string hdnIsfromPage, string hdnloginproductID, string hdnloginproductname, string signin_email, string signin_password)
        {
            masterPageDefault This = new masterPageDefault();
            bool flag = false;
            HttpContext.Current.Session["IsHomePageVisible"] = null;
            HttpContext.Current.Session["IsPPW"] = null;
            BaseClass baseClass = new BaseClass();
            long num = (long)0;
            //string str = baseClass.SpecialEncode(HttpContext.Current.Request.Form["signin_email"]);
            //string item = HttpContext.Current.Request.Form["signin_password"];
            string str = baseClass.SpecialEncode(signin_email);
            string item = signin_password;
            //string AccountID = HttpContext.Current.Session["accid"].ToString();
            string AccountID = accID;
            //HttpContext.Current.Session["AccountType"] = AccountType;
            DataTable dataTable = LoginBasePage.LoginTo_Store(str, item, Convert.ToInt64(AccountID), ConnectionClass.AccountType);
            foreach (DataRow row in dataTable.Rows)
            {
                This.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                num = Convert.ToInt64(row["AccountID"].ToString());
                DataTable displaySettings = CMSBasePage.GetDisplaySettings(num);
                HttpContext.Current.Session["eStoreDisplaySetting"] = displaySettings;
                if (!Convert.ToBoolean(row["IsActive"].ToString()))
                {
                    flag = false;
                    HttpContext.Current.Session["IsHomePageVisible"] = null;
                    HttpContext.Current.Session["IsPPW"] = null;
                }
                else
                {
                    flag = true;
                    HttpContext.Current.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    HttpContext.Current.Session["IsPPW"] = row["IsPPW"].ToString();
                }
            }
            if (flag)
            {
                This.SesseionKey = This.comm.UniqueID;
                This.login.Insert_intoResume_Session(str, item);
                This.login.LogInFromDefault(str, item);
                CartBasePage.Update_Cart_StoreUserID(This.SesseionKey, This.StoreUserID);
                num = Convert.ToInt64(ConnectionClass.AccountID);
                This.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
                accountType = This.comm.return_AccountType((long)This.CompanyID, num);
                DataTable dataTable1 = LoginBasePage.SelectB2B_DefaultLandingPage(This.CompanyID, Convert.ToInt64(ConnectionClass.AccountID), "view");
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    if (!Convert.ToBoolean(dataRow["IsDefaultLand"]))
                    {
                        continue;
                    }
                    DefaultLandPageName = dataRow["systemName"].ToString();
                    This.pageID = Convert.ToInt32(dataRow["pageID"]);
                    break;
                }
                if (HttpContext.Current.Session["fromEmail"] != null && HttpContext.Current.Session["fromEmail"] != null)
                {
                    //HttpContext.Current.Response.Redirect(HttpContext.Current.Session["fromEmail"].ToString());
                    return HttpContext.Current.Session["fromEmail"].ToString();
                }
                if (DefaultLandPageName == "")
                {
                    if (hdnIsfromPage.Trim() == "product")
                    {
                        if (This.Rewritemodule.ToLower() != "on")
                        {
                            //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "products/productdetails.aspx?ID=", hdnloginproductID, "&amp;type=0"));
                            return string.Concat(This.strSitePath, "products/productdetails.aspx?ID=", hdnloginproductID, "&amp;type=0");
                        }
                        else
                        {
                            HttpResponse response = HttpContext.Current.Response;
                            string[] strArrays = new string[] { This.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(hdnloginproductname), ConnectionClass.KeySeparator, hdnloginproductID, ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                            //response.Redirect(string.Concat(strArrays));
                            return string.Concat(strArrays);
                        }
                    }
                    if (hdnIsfromPage.Trim() == "sitemap")
                    {
                        if (This.Rewritemodule.ToLower() != "on")
                        {
                            //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap.aspx"));
                            return string.Concat(This.strSitePath, "sitemap.aspx");
                        }
                        //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap", ConnectionClass.FileExtension));
                        return string.Concat(This.strSitePath, "sitemap", ConnectionClass.FileExtension);
                    }
                    if (hdnIsfromPage.Trim() != "carticon")
                    {
                        if (hdnIsfromPage.Trim() == "main")
                        {
                            if (This.Rewritemodule.ToLower() != "on")
                            {
                                //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "products/product.aspx?ID=0"));
                                return string.Concat(This.strSitePath, "products/product.aspx?ID=0");
                            }
                            HttpResponse httpResponse = HttpContext.Current.Response;
                            object[] keySeparator = new object[] { This.strSitePath, "products", ConnectionClass.KeySeparator, 0, ConnectionClass.FileExtension };
                            //httpResponse.Redirect(string.Concat(keySeparator));
                            return string.Concat(keySeparator);
                        }
                        string uniqueID = This.comm.UniqueID;
                        int num1 = 0;
                        foreach (DataRow row1 in CartBasePage.Select_CartItems(uniqueID, "", This.StoreUserID).Rows)
                        {
                            num1++;
                        }
                        if (num1 == 0 && ConnectionClass.AccountType.Trim().ToLower() == "public")
                        {
                            if (This.Rewritemodule.ToLower() != "on")
                            {
                                //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "default.aspx"));
                                return string.Concat(This.strSitePath, "default.aspx");
                            }
                            //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "default", ConnectionClass.FileExtension));
                            return string.Concat(This.strSitePath, "default", ConnectionClass.FileExtension);
                        }
                        if (This.Rewritemodule.ToLower() == "on")
                        {
                            HttpResponse response1 = HttpContext.Current.Response;
                            string[] keySeparator1 = new string[] { This.strSitePath, "shoppingcart", ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                            //response1.Redirect(string.Concat(keySeparator1));
                            return string.Concat(keySeparator1);
                        }
                        //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "shoppingcart.aspx?ID=0&amp;PID=0"));
                        return string.Concat(This.strSitePath, "shoppingcart.aspx?ID=0&amp;PID=0");
                    }
                    else if (This.Rewritemodule.ToLower() == "on")
                    {
                        HttpResponse httpResponse1 = HttpContext.Current.Response;
                        string[] strArrays1 = new string[] { This.strSitePath, "products", ConnectionClass.KeySeparator, hdnloginproductID, ConnectionClass.FileExtension };
                        //httpResponse1.Redirect(string.Concat(strArrays1));
                        return string.Concat(strArrays1);
                    }
                }
                else
                {
                    if (DefaultLandPageName.ToLower() != "home")
                    {
                        if (DefaultLandPageName.ToLower() == "sitemap")
                        {
                            if (This.Rewritemodule.ToLower() != "on")
                            {
                                //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap.aspx"));
                                return string.Concat(This.strSitePath, "sitemap.aspx");
                            }
                            //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap", ConnectionClass.FileExtension));
                            return string.Concat(This.strSitePath, "sitemap", ConnectionClass.FileExtension);
                        }
                        if (DefaultLandPageName.ToLower() == "products")
                        {
                            if (This.Rewritemodule.ToLower() != "on")
                            {
                                //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "products/product.aspx?ID=0"));
                                return string.Concat(This.strSitePath, "products/product.aspx?ID=0");
                            }
                            HttpResponse response2 = HttpContext.Current.Response;
                            object[] objArray = new object[] { This.strSitePath, "products", ConnectionClass.KeySeparator, 0, ConnectionClass.FileExtension };
                            //response2.Redirect(string.Concat(objArray));
                            return string.Concat(objArray);
                        }
                        if (DefaultLandPageName.ToLower() == "sitemap")
                        {
                            if (This.Rewritemodule.ToLower() != "on")
                            {
                                //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap.aspx"));
                                return string.Concat(This.strSitePath, "sitemap.aspx");
                            }
                            //HttpContext.Current.Response.Redirect(string.Concat(This.strSitePath, "sitemap", ConnectionClass.KeySeparator, ConnectionClass.FileExtension));
                            return string.Concat(This.strSitePath, "sitemap", ConnectionClass.KeySeparator, ConnectionClass.FileExtension);
                        }
                        if (This.Rewritemodule.ToLower() != "on")
                        {
                            HttpResponse httpResponse2 = HttpContext.Current.Response;
                            object[] defaultLandPageName = new object[] { This.strSitePath, "cms/", DefaultLandPageName, This.pageID, ".aspx" };
                            //httpResponse2.Redirect(string.Concat(defaultLandPageName));
                            return string.Concat(defaultLandPageName);
                        }
                        HttpResponse response3 = HttpContext.Current.Response;
                        object[] defaultLandPageName1 = new object[] { This.strSitePath, "cms/", DefaultLandPageName, ConnectionClass.KeySeparator, This.pageID, ConnectionClass.FileExtension };
                        //response3.Redirect(string.Concat(defaultLandPageName1));
                        return string.Concat(defaultLandPageName1);
                    }
                    if (Convert.ToInt64(HttpContext.Current.Session["IsHomePageVisible"]) == (long)1)
                    {
                        if (This.Rewritemodule.ToLower() != "on")
                        {
                            //HttpContext.Current.Response.Redirect(This.strSitePath);
                            return This.strSitePath;
                        }
                        //HttpContext.Current.Response.Redirect(This.ResolveUrl(This.strSitePath));
                        return This.ResolveUrl(This.strSitePath);
                    }
                }
            }
            return string.Concat(This.strSitePath, "default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                LoginMethods.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                LoginMethods.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
                this.Session["LanguageConversion"] = LoginBasePage.Fetch_LanguageConversionFileName(LoginMethods.AccountID);
            }
            this.NewSessionID = this.comm.UniqueID;
        }

        public class CreateAcctDetails
        {
            public string Result
            {
                get;
                set;
            }

            public CreateAcctDetails()
            {
            }
        }

        public class ForgotPwdDetails
        {
            public string Result
            {
                get;
                set;
            }

            public ForgotPwdDetails()
            {
            }
        }

        public class GetClientIDDetails
        {
            public string Result
            {
                get;
                set;
            }

            public GetClientIDDetails()
            {
            }
        }

        public class GetSecretCodeDetails
        {
            public string Result
            {
                get;
                set;
            }

            public GetSecretCodeDetails()
            {
            }
        }

        public class LoginDetails
        {
            public string Result
            {
                get;
                set;
            }

            public LoginDetails()
            {
            }
        }
    }
}
