using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using Printcenter.UI.Products;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore.Templates
{
    public partial class masterPageDefault : MasterPage
    {
        //protected ContentPlaceHolder head;

        //protected HtmlHead Head1;

        //protected HtmlInputText txt_search_ppw;

        //protected Image img_search_ppw;

        //protected HtmlGenericControl div_searchproducts_ppw;

        //protected Label lbl_loginName;

        //protected HtmlGenericControl divWelcome;

        //protected HtmlAnchor lbl_myaccount;

        //protected Label lbl_myaccountSpliter;

        //protected HtmlGenericControl divMyAccount;

        //protected HtmlAnchor lbl_myorder;

        //protected Label lbl_myorderSpliter;

        //protected HtmlGenericControl divMyOrder;

        //protected HtmlAnchor lbl_mycard;

        //protected Label lblMycarSpliter;

        //protected HtmlGenericControl divMyCart;

        //protected HtmlAnchor lnk_checkout;

        //protected Label lblCheckoutSpliter;

        //protected HtmlGenericControl divCheckOut;

        //protected Label lblsignupSpliter;

        //protected HtmlGenericControl Signup;

        //protected LinkButton lnk_Login;

        //protected LinkButton lnk_Logout;

        //protected HtmlGenericControl divLogIn;

        //protected HtmlInputText txt_search;

        //protected Image img_search;

        //protected HtmlGenericControl divSearchBox;

        //protected HtmlGenericControl div_searchProducts;

        //protected PlaceHolder ph_headerLeft;

        //protected Label header_bottom_empty_lbl;

        //protected PlaceHolder ph_topNavi;

        //protected Button btnlogin;

        //protected Button btnloginsave;

        //protected Button btnSendEmail;

        //protected HtmlGenericControl divcompanyname;

        //protected CheckBox chkAddEmilDmc;

        //protected Label Label1;

        //protected HtmlGenericControl divsubscribe;

        //protected Button btnCreateAccount;

        //protected Button btnSubmit;

        //protected Button btnagentsubmit;

        //protected ContentPlaceHolder ContentPlaceHolder1;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HiddenField hdnIsfromPage;

        //protected HiddenField hdnloginproductID;

        //protected HiddenField hdnloginproductname;

        //protected HtmlForm form1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        public int roundoff;

        public int CompanyID;

        public int AccountID;

        public int pageID;

        public long StoreUserID;

        public int arrayLength;

        public char KeySeparator;

        public string strloginImagepath = BaseClass.imagePath();

        public string FileExtension = string.Empty;

        public string Rewritemodule = string.Empty;

        public string strSitePath = string.Empty;

        public string imageHandlerPath = string.Empty;

        public string newdate = string.Empty;

        public string StyleSheetPath = string.Empty;

        public string StoreimageHandlerPath = string.Empty;

        public string logoImageHeader = string.Empty;

        public string logoImageFooter = string.Empty;

        public string nilImage = "nil.gif";

        public string BannerImageHeader = string.Empty;

        public string BannerImageFooter = string.Empty;

        public string bannerImagePath = string.Empty;

        public string StyleSheetPathMaster = string.Empty;

        public string StyleSheetPathMaster_withPPW = string.Empty;

        public string CurrencySymbol = string.Empty;

        public static string AccountType;

        public string SystemName = string.Empty;

        public string IsPPW = string.Empty;

        public string floatvalue = string.Empty;

        public string MeasurementValue = string.Empty;

        public string SesseionKey = string.Empty;

        private string IsHomePageVisible = "1";

        private string isProductVisible = "1";

        public commonclass comm = new commonclass();

        public loginclass login = new loginclass();

        private EmailClass Objemail = new EmailClass();

        public string DateFormat = string.Empty;

        public string CustomRedirectURL = string.Empty;

        public bool IsValidAgentCode;

        public string LoginOrgAgentCode = string.Empty;

        public bool IsForceUserLoginProduct;

        private string DefaultLandPageName = string.Empty;

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

        static masterPageDefault()
        {
            AccountType = string.Empty;
        }

        public masterPageDefault()
        {
        }

        public void btnagentsubmit_Click(object sender, EventArgs e)
        {
        }

        public void btnlogin_Click(object sender, EventArgs e)
        {
            bool flag = false;
            base.Session["IsHomePageVisible"] = null;
            base.Session["IsPPW"] = null;
            BaseClass baseClass = new BaseClass();
            long num = (long)0;
            string str = baseClass.SpecialEncode(base.Request.Form["signin_email"]);
            string item = base.Request.Form["signin_password"];
            DataTable dataTable = LoginBasePage.LoginTo_Store(str, item, Convert.ToInt64(this.AccountID), ConnectionClass.AccountType);
            foreach (DataRow row in dataTable.Rows)
            {
                this.StoreUserID = Convert.ToInt64(row["StoreUserID"].ToString());
                num = Convert.ToInt64(row["AccountID"].ToString());
                DataTable displaySettings = CMSBasePage.GetDisplaySettings(num);
                base.Session["eStoreDisplaySetting"] = displaySettings;
                if (!Convert.ToBoolean(row["IsActive"].ToString()))
                {
                    flag = false;
                    base.Session["IsHomePageVisible"] = null;
                    base.Session["IsPPW"] = null;
                }
                else
                {
                    flag = true;
                    base.Session["IsHomePageVisible"] = row["IsHomePage"].ToString();
                    base.Session["IsPPW"] = row["IsPPW"].ToString();
                }
            }
            if (flag)
            {
                this.SesseionKey = this.comm.UniqueID;
                this.login.Insert_intoResume_Session(str, item);
                this.login.LogInFromDefault(str, item);
                CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
                num = Convert.ToInt64(ConnectionClass.AccountID);
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
                AccountType = this.comm.return_AccountType((long)this.CompanyID, num);
                DataTable dataTable1 = LoginBasePage.SelectB2B_DefaultLandingPage(this.CompanyID, Convert.ToInt64(ConnectionClass.AccountID), "view");
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    if (!Convert.ToBoolean(dataRow["IsDefaultLand"]))
                    {
                        continue;
                    }
                    this.DefaultLandPageName = dataRow["systemName"].ToString();
                    this.pageID = Convert.ToInt32(dataRow["pageID"]);
                    break;
                }
                if (base.Session["fromEmail"] != null && base.Session["fromEmail"] != null)
                {
                    base.Response.Redirect(base.Session["fromEmail"].ToString());
                    return;
                }
                if (this.DefaultLandPageName == "")
                {
                    if (this.hdnIsfromPage.Value.ToString().Trim() == "product")
                    {
                        if (this.Rewritemodule.ToLower() != "on")
                        {
                            base.Response.Redirect(string.Concat(this.strSitePath, "products/productdetails.aspx?ID=", this.hdnloginproductID.Value, "&amp;type=0"));
                        }
                        else
                        {
                            HttpResponse response = base.Response;
                            string[] strArrays = new string[] { this.strSitePath, "products/", ConnectionClass.RemoveIllegalChars(this.hdnloginproductname.Value), ConnectionClass.KeySeparator, this.hdnloginproductID.Value, ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                            response.Redirect(string.Concat(strArrays));
                        }
                    }
                    if (this.hdnIsfromPage.Value.ToString().Trim() == "sitemap")
                    {
                        if (this.Rewritemodule.ToLower() != "on")
                        {
                            base.Response.Redirect(string.Concat(this.strSitePath, "sitemap.aspx"));
                            return;
                        }
                        base.Response.Redirect(string.Concat(this.strSitePath, "sitemap", ConnectionClass.FileExtension));
                        return;
                    }
                    if (this.hdnIsfromPage.Value.ToString().Trim() != "carticon")
                    {
                        if (this.hdnIsfromPage.Value.ToString().Trim() == "main")
                        {
                            if (this.Rewritemodule.ToLower() != "on")
                            {
                                base.Response.Redirect(string.Concat(this.strSitePath, "products/product.aspx?ID=0"));
                                return;
                            }
                            HttpResponse httpResponse = base.Response;
                            object[] keySeparator = new object[] { this.strSitePath, "products", ConnectionClass.KeySeparator, 0, ConnectionClass.FileExtension };
                            httpResponse.Redirect(string.Concat(keySeparator));
                            return;
                        }
                        string uniqueID = this.comm.UniqueID;
                        int num1 = 0;
                        foreach (DataRow row1 in CartBasePage.Select_CartItems(uniqueID, "", this.StoreUserID).Rows)
                        {
                            num1++;
                        }
                        if (num1 == 0 && ConnectionClass.AccountType.Trim().ToLower() == "public")
                        {
                            if (this.Rewritemodule.ToLower() != "on")
                            {
                                base.Response.Redirect(string.Concat(this.strSitePath, "default.aspx"));
                                return;
                            }
                            base.Response.Redirect(string.Concat(this.strSitePath, "default", ConnectionClass.FileExtension));
                            return;
                        }
                        if (this.Rewritemodule.ToLower() == "on")
                        {
                            HttpResponse response1 = base.Response;
                            string[] keySeparator1 = new string[] { this.strSitePath, "shoppingcart", ConnectionClass.KeySeparator, "0", ConnectionClass.KeySeparator, "0", ConnectionClass.FileExtension };
                            response1.Redirect(string.Concat(keySeparator1));
                            return;
                        }
                        base.Response.Redirect(string.Concat(this.strSitePath, "shoppingcart.aspx?ID=0&amp;PID=0"));
                    }
                    else if (this.Rewritemodule.ToLower() == "on")
                    {
                        HttpResponse httpResponse1 = base.Response;
                        string[] strArrays1 = new string[] { this.strSitePath, "products", ConnectionClass.KeySeparator, this.hdnloginproductID.Value, ConnectionClass.FileExtension };
                        httpResponse1.Redirect(string.Concat(strArrays1));
                        return;
                    }
                }
                else
                {
                    if (this.DefaultLandPageName.ToLower() != "home")
                    {
                        if (this.DefaultLandPageName.ToLower() == "sitemap")
                        {
                            if (this.Rewritemodule.ToLower() != "on")
                            {
                                base.Response.Redirect(string.Concat(this.strSitePath, "sitemap.aspx"));
                                return;
                            }
                            base.Response.Redirect(string.Concat(this.strSitePath, "sitemap", ConnectionClass.FileExtension));
                            return;
                        }
                        if (this.DefaultLandPageName.ToLower() == "products")
                        {
                            if (this.Rewritemodule.ToLower() != "on")
                            {
                                base.Response.Redirect(string.Concat(this.strSitePath, "products/product.aspx?ID=0"));
                                return;
                            }
                            HttpResponse response2 = base.Response;
                            object[] objArray = new object[] { this.strSitePath, "products", ConnectionClass.KeySeparator, 0, ConnectionClass.FileExtension };
                            response2.Redirect(string.Concat(objArray));
                            return;
                        }
                        if (this.DefaultLandPageName.ToLower() == "sitemap")
                        {
                            if (this.Rewritemodule.ToLower() != "on")
                            {
                                base.Response.Redirect(string.Concat(this.strSitePath, "sitemap.aspx"));
                                return;
                            }
                            base.Response.Redirect(string.Concat(this.strSitePath, "sitemap", ConnectionClass.KeySeparator, ConnectionClass.FileExtension));
                            return;
                        }
                        if (this.Rewritemodule.ToLower() != "on")
                        {
                            HttpResponse httpResponse2 = base.Response;
                            object[] defaultLandPageName = new object[] { this.strSitePath, "cms/", this.DefaultLandPageName, this.pageID, ".aspx" };
                            httpResponse2.Redirect(string.Concat(defaultLandPageName));
                            return;
                        }
                        HttpResponse response3 = base.Response;
                        object[] defaultLandPageName1 = new object[] { this.strSitePath, "cms/", this.DefaultLandPageName, ConnectionClass.KeySeparator, this.pageID, ConnectionClass.FileExtension };
                        response3.Redirect(string.Concat(defaultLandPageName1));
                        return;
                    }
                    if (this.DefaultLandPageName.ToLower() == "home")
                    {
                        base.Response.Redirect(string.Concat(this.strSitePath, "default.aspx"));
                        return;
                    }
                    else if (Convert.ToInt64(base.Session["IsHomePageVisible"]) == (long)1)
                    {
                        if (this.Rewritemodule.ToLower() != "on")
                        {
                            base.Response.Redirect(this.strSitePath);
                            return;
                        }
                        base.Response.Redirect(base.ResolveUrl(this.strSitePath));
                        return;
                    }
                    
                }
            }
        }

        public void lnk_LoginClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitePath, "login", this.FileExtension));
        }

        public void lnk_LogoutClick(object sender, EventArgs e)
        {
            base.Session.Clear();
            base.Session.Abandon();
            base.Session["StoreUserID"] = "";
            base.Session["eStoreDisplaySetting"] = "";
            if (EprintConfigurationManager.AppSettings["AccountType"].ToString().ToLower() != "private")
            {
                AccountType = "x";
            }
            else
            {
                AccountType = "p";
            }
            if (AccountType == "p")
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "login.aspx"));
                return;
            }
            if (this.CustomRedirectURL != "")
            {
                base.Response.Redirect(this.CustomRedirectURL);
                return;
            }
            if (this.Rewritemodule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "default.aspx?frm=logout"));
                return;
            }
            HttpResponse response = base.Response;
            string[] keySeparator = new string[] { this.strSitePath, "default", ConnectionClass.KeySeparator, "logout", ConnectionClass.FileExtension };
            response.Redirect(string.Concat(keySeparator));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] publicDocPath;
            string[] languageConversion;
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
            this.CurrencySymbol = ConnectionClass.CurrencySymbol;
            if (EprintConfigurationManager.AppSettings["AccountType"].ToString().ToLower() != "private")
            {
                AccountType = "x";
            }
            else
            {
                AccountType = "p";
            }
            if (ConnectionClass.SitePath == null)
            {
                this.strSitePath = "";
            }
            else
            {
                this.strSitePath = ConnectionClass.SitePath.ToString();
            }
            if (ConnectionClass.AccountID != null)
            {
                this.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
                base.Session["LanguageConversion"] = LoginBasePage.Fetch_LanguageConversionFileName((long)this.AccountID);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.SystemName = ConnectionClass.SystemName.ToLower().Trim();
            }

            if (this.SystemName.ToLower() == "handyexpress")
            {
                this.Page.Header.Controls.Add(
                    new LiteralControl(@"<!-- Global site tag (gtag.js) - Google Analytics -->
                    <script async src=\""https://www.googletagmanager.com/gtag/js?id=UA-86660923-1\""></script>
                    <script>
                      window.dataLayer = window.dataLayer || [];
                                    function gtag(){ dataLayer.push(arguments); }
                                    gtag('js', new Date());
                                    gtag('config', 'UA-86660923-1');
                        </script>"
                    ));
            }

            if (ConnectionClass.ServerName.ToLower() == "phoneink" || ConnectionClass.ServerName.ToLower() == "prelive")
            {
                string empty = string.Empty;
                if (base.Request.Cookies["agentcode"] != null)
                {
                    empty = base.Request.Cookies["agentcode"].Value;
                }
                DataTable dataTable = LoginBasePage.Public_User_ClientIDbyAgentCode((long)this.CompanyID, (long)this.AccountID, empty);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsValidAgentCode = true;
                    this.LoginOrgAgentCode = empty;
                }
            }
            if (ConnectionClass.PublicDocPath != null && ConnectionClass.ServerName != null)
            {
                publicDocPath = new object[] { ConnectionClass.PublicDocPath, ConnectionClass.ServerName, "/store/", this.AccountID };
                this.StyleSheetPath = string.Concat(publicDocPath);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.PublicDocPath, "store/0");
                if (this.SystemName.ToLower() != "ppw")
                {
                    this.StyleSheetPathMaster_withPPW = string.Concat(ConnectionClass.PublicDocPath, "store/0/Themes/StyleSheet.css");
                }
                else
                {
                    this.StyleSheetPathMaster_withPPW = string.Concat(ConnectionClass.PublicDocPath, "store/0/Themes1/StyleSheet.css");
                }
            }
            this.Page.Header.DataBind();
            base.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.Cache.SetNoStore();
            if (ConnectionClass.KeySeparator != null)
            {
                this.KeySeparator = Convert.ToChar(ConnectionClass.KeySeparator.ToString());
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension.ToString();
            }
            if (ConnectionClass.RewriteModule != null)
            {
                this.Rewritemodule = ConnectionClass.RewriteModule;
            }
            if (ConnectionClass.eprintDocument != null)
            {
                object[] secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", this.AccountID, "\\banners\\" };
                this.bannerImagePath = string.Concat(secureDocFilepath);
            }
            if (ConnectionClass.StoreimageHandlerPath != null)
            {
                this.StoreimageHandlerPath = ConnectionClass.StoreimageHandlerPath.ToString();
            }
            this.lnk_Login.Text = this.objLanguage.GetLanguageConversion("Log_In");
            this.lnk_Logout.Text = this.objLanguage.GetLanguageConversion("Logout");
            if (this.comm.GetDisplayValue("isSearchboxright", (long)this.AccountID) != "true")
            {
                this.div_searchproducts_ppw.Style.Add("display", "block");
                this.div_searchProducts.Style.Add("display", "none");
                this.floatvalue = "right";
            }
            else
            {
                this.div_searchproducts_ppw.Style.Add("display", "none");
                this.div_searchProducts.Style.Add("display", "block");
                this.floatvalue = "left";
            }
            if (this.comm.GetDisplayValue("isCheckLoginRegister", (long)this.AccountID) != "true")
            {
                base.Session["CommonClient"] = EprintConfigurationManager.AppSettings["DefaultClientID"].ToString();
                if (this.Rewritemodule.ToLower() == "on" && AccountType == "x" && base.Request.Url.AbsoluteUri.ToLower().IndexOf("login.aspx") != -1)
                {
                    base.Response.Redirect(string.Concat(this.strSitePath, "default", this.FileExtension));
                }
            }
            else
            {
                base.Session["CommonClient"] = null;
            }
            if (this.comm.GetDisplayValue("isHome", (long)this.AccountID) == "false" && this.Rewritemodule.ToLower() == "on" && base.Request.Url.AbsoluteUri.ToLower().IndexOf("default.aspx") != -1)
            {
                HttpResponse response = base.Response;
                object[] keySeparator = new object[] { this.strSitePath, "products", this.KeySeparator, 0, this.FileExtension };
                response.Redirect(string.Concat(keySeparator));
            }
            if (this.comm.GetDisplayValue("isWelcome", (long)this.AccountID) != "true")
            {
                this.divWelcome.Style.Add("display", "none");
            }
            else
            {
                this.divWelcome.Style.Add("display", "block");
            }
            if (this.comm.GetDisplayValue("isMyAccount", (long)this.AccountID) != "true")
            {
                this.divMyAccount.Style.Add("display", "none");
            }
            else
            {
                this.divMyAccount.Style.Add("display", "block");
                if (this.comm.GetDisplayValue("isMyOrders", (long)this.AccountID) != "true")
                {
                    this.lbl_myaccountSpliter.Visible = false;
                }
                else
                {
                    this.lbl_myaccountSpliter.Visible = true;
                }
            }
            if (this.comm.GetDisplayValue("isMyOrders", (long)this.AccountID) != "true")
            {
                this.divMyOrder.Style.Add("display", "none");
            }
            else
            {
                this.divMyOrder.Style.Add("display", "block");
                if (this.comm.GetDisplayValue("isMyCart", (long)this.AccountID) != "true")
                {
                    this.lbl_myorderSpliter.Visible = false;
                }
                else
                {
                    this.lbl_myorderSpliter.Visible = true;
                }
            }
            if (this.comm.GetDisplayValue("isMyCart", (long)this.AccountID) != "true")
            {
                this.divMyCart.Style.Add("display", "none");
            }
            else
            {
                this.divMyCart.Style.Add("display", "block");
                if (this.comm.GetDisplayValue("isCheckOut", (long)this.AccountID) != "true")
                {
                    this.lblMycarSpliter.Visible = false;
                }
                else
                {
                    this.lblMycarSpliter.Visible = true;
                }
            }
            if (this.comm.GetDisplayValue("isCheckOut", (long)this.AccountID) != "true")
            {
                this.divCheckOut.Style.Add("display", "none");
            }
            else
            {
                this.divCheckOut.Style.Add("display", "block");
                if (this.comm.GetDisplayValue("isCheckLoginRegister", (long)this.AccountID) != "true")
                {
                    this.lblCheckoutSpliter.Visible = false;
                }
                else
                {
                    this.lblCheckoutSpliter.Visible = true;
                }
            }
            if (this.comm.GetDisplayValue("isProducts", (long)this.AccountID) == "false")
            {
                this.isProductVisible = "0";
            }
            if (this.comm.GetDisplayValue("IsHome", (long)this.AccountID) == "false")
            {
                this.IsHomePageVisible = "0";
            }
            if (base.Session["StoreUserID"] == null)
            {
                this.divMyAccount.Style.Add("display", "none");
                this.divMyOrder.Style.Add("display", "none");
                this.divMyCart.Style.Add("display", "none");
                if (AccountType != "p")
                {
                    this.lnk_Logout.Style.Add("display", "none");
                    if (this.comm.GetDisplayValue("isCheckLoginRegister", (long)this.AccountID) != "true")
                    {
                        this.lnk_Login.Style.Add("display", "none");
                        this.Signup.Style.Add("display", "none");
                    }
                    else
                    {
                        this.lnk_Login.Style.Add("display", "block");
                        this.Signup.Style.Add("display", "block");
                    }
                }
                else
                {
                    this.lbl_myaccount.Style.Add("display", "none");
                    this.lbl_myaccountSpliter.Style.Add("display", "none");
                    this.lbl_myorder.Style.Add("display", "none");
                    this.lbl_myorderSpliter.Style.Add("display", "none");
                    this.lbl_loginName.Style.Add("display", "none");
                    this.lbl_mycard.Style.Add("display", "none");
                    this.lblMycarSpliter.Style.Add("display", "none");
                    this.lnk_checkout.Style.Add("display", "none");
                    this.lblCheckoutSpliter.Style.Add("display", "none");
                    this.lnk_Login.Style.Add("display", "none");
                    this.Signup.Style.Add("display", "none");
                }
            }
            else
            {
                this.divMyAccount.Style.Add("display", "block");
                this.divMyOrder.Style.Add("display", "block");
                this.divMyCart.Style.Add("display", "block");
                if (base.Session["isGuest"] == null)
                {
                    this.lnk_Logout.Style.Add("display", "block");
                }
                else if (base.Session["isGuest"].ToString().ToLower() == "yes")
                {
                    this.divLogIn.Style.Add("display", "none");
                    this.Signup.Style.Add("display", "none");
                }
            }
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
                if (base.Session["LastName"].ToString() == "")
                {
                    this.lbl_loginName.Text = string.Concat(this.objLanguage.GetLanguageConversion("Welcome"), ", ", this.objBase.SpecialDecode(base.Session["FirstName"].ToString()), "!");
                }
                else
                {
                    this.lbl_loginName.Text = string.Concat(this.objLanguage.GetLanguageConversion("Welcome"), ", ", this.objBase.SpecialDecode(string.Concat(base.Session["FirstName"].ToString(), " ", base.Session["LastName"].ToString())), "!");
                }
            }
            if (this.StoreUserID == (long)0 && base.Request.Cookies["StoreUserID"] != null)
            {
                base.Session["isGuest"] = "Yes";
                long num = (long)0;
                HttpCookie item = base.Request.Cookies["StoreUserID"];
                num = Convert.ToInt64(item.Value);
                DataTable guestDetail = CMSBasePage.getGuestDetail(num);
                if (guestDetail.Rows.Count > 0)
                {
                    Label lblLoginName = this.lbl_loginName;
                    languageConversion = new string[] { this.objLanguage.GetLanguageConversion("Welcome"), ", ", guestDetail.Rows[0]["FirstName"].ToString(), " ", guestDetail.Rows[0]["LastName"].ToString(), "!" };
                    lblLoginName.Text = string.Concat(languageConversion);
                    this.SesseionKey = this.comm.UniqueID;
                    this.login.Insert_intoResume_Session(guestDetail.Rows[0]["EmailID"].ToString(), guestDetail.Rows[0]["Password"].ToString());
                    this.login.LogInFromDefault(guestDetail.Rows[0]["EmailID"].ToString(), guestDetail.Rows[0]["Password"].ToString());
                }
                CartBasePage.Update_Cart_StoreUserID(this.SesseionKey, this.StoreUserID);
            }
            if (base.Request.Url.ToString().ToLower().Contains("/login.aspx") || base.Request.Url.ToString().ToLower().Contains("/logout.aspx"))
            {
                this.div_searchProducts.Style.Add("display", "none");
                this.div_searchproducts_ppw.Style.Add("display", "none");
            }
            if (base.Session["UniqueID"] == null)
            {
                HttpSessionState session = HttpContext.Current.Session;
                base.Session["UniqueID"] = session;
            }
            if (EprintConfigurationManager.AppSettings["Footer"] == null)
            {
                this.lbl_copyWriter.Text = "";
            }
            else
            {
                this.lbl_copyWriter.Text = EprintConfigurationManager.AppSettings["Footer"].ToString();
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            this.roundoff = 0;
            DataTable dataTable1 = ProductBasePage.default_price_for_pack_select(this.CompanyID);
            if (dataTable1.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.roundoff = Convert.ToInt32(dataRow["Roundoff"].ToString());
                }
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
            DataTable dataTable2 = LoginBasePage.Select_PublicUserAccountDetails((long)this.CompanyID, (long)this.AccountID);
            foreach (DataRow row1 in dataTable2.Rows)
            {
                this.CustomRedirectURL = row1["ReDirectURL"].ToString().Trim();
                this.IsForceUserLoginProduct = Convert.ToBoolean(row1["IsForceUser"]);
            }
            if (base.Session["StoreUserID"] == null && this.IsForceUserLoginProduct)
            {
                this.divSearchBox.Style.Add("display", "none");
            }
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable3 = CMSBasePage.CMSPages_get(this.CompanyID, this.AccountID, 0);  
            int length = (int)dataTable3.Select("ShowPagesIN ='H' or ShowPagesIN ='B'").Length;
            int num1 = 0;
            foreach (DataRow dataRow1 in dataTable3.Rows)
            {
                if (!(dataRow1["showPagesIn"].ToString().Trim() == "B") && !(dataRow1["showPagesIn"].ToString().Trim() == "H"))
                {
                    continue;
                }
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    if (dataRow1["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        if (this.IsHomePageVisible == "1")
                        {
                            string[] strArrays = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else if (AccountType == "x" && this.IsHomePageVisible == "1")
                        {
                            string[] strArrays1 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays1));
                        }
                    }
                    else if (dataRow1["systemName"].ToString().ToLower().Trim() == "products")
                    {
                        if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='ShowLoginonProduct(0, 0);' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                        }
                    }
                    else if (!(dataRow1["systemName"].ToString().ToLower().Trim() == "sitemap") || !(AccountType.ToLower() == "x"))
                    {
                        object[] objArray = new object[] { "<div><a  class='UpperCaseText'  href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(dataRow1["pageID"].ToString()), "'> ", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), "</a></div>" };
                        stringBuilder.Append(string.Concat(objArray));
                    }
                    else
                    {
                        string[] strArrays2 = new string[] { "<div><a class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "sitemap.aspx' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                        stringBuilder.Append(string.Concat(strArrays2));
                    }
                    num1++;
                    if (num1 >= length || !(AccountType == "x") || !(this.SystemName.ToLower() == "ppw"))
                    {
                        continue;
                    }
                    stringBuilder.Append("<div>|</div>");
                }
                else
                {
                    if (dataRow1["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        if (base.Session["StoreUserID"] != null)
                        {
                            if (this.IsHomePageVisible == "1")
                            {
                                string[] strArrays3 = new string[] { "<div><a class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "Default.aspx", "'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                                stringBuilder.Append(string.Concat(strArrays3));
                            }
                        }
                        else if (AccountType != "p" && this.comm.GetDisplayValue("isHome", (long)this.AccountID) == "true")
                        {
                            string[] strArrays4 = new string[] { "<div><a  class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays4));
                        }
                    }
                    else if (dataRow1["systemName"].ToString().ToLower().Trim() != "products")
                    {
                        if (dataRow1["systemName"].ToString().ToLower().Trim() != "sitemap")
                        {
                            string[] strArrays5 = new string[] { "<div><a  class='UpperCaseText'  href='", null, null, null, null };
                            object[] objArray1 = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), "/", ConnectionClass.RemoveIllegalChars(dataRow1["pageName"].ToString()), ConnectionClass.KeySeparator, Convert.ToInt32(dataRow1["pageID"].ToString()), ConnectionClass.FileExtension };
                            strArrays5[1] = base.ResolveUrl(string.Concat(objArray1));
                            strArrays5[2] = "'> ";
                            strArrays5[3] = this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim());
                            strArrays5[4] = " </a></div>";
                            stringBuilder.Append(string.Concat(strArrays5));
                        }
                        else if (AccountType.ToLower() == "x")
                        {
                            if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                            {
                                string[] strArrays6 = new string[] { "<div><a class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "sitemap.aspx' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                                stringBuilder.Append(string.Concat(strArrays6));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='ShowLoginonProduct(0, 1);' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                            }
                        }
                    }
                    else if (base.Session["StoreUserID"] != null)
                    {
                        if (AccountType == "p")
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' class='UpperCaseText' onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                        }
                        else if (this.isProductVisible == "1")
                        {
                            if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                            {
                                stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                            }
                            else
                            {
                                stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='ShowLoginonProduct(0, 0);' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                            }
                        }
                    }
                    else if (AccountType == "p")
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                    }
                    else if (this.comm.GetDisplayValue("isProducts", (long)this.AccountID) == "true")
                    {
                        if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);'  class='UpperCaseText'  onclick='ShowLoginonProduct(0, 0);' target='_self'>", this.objBase.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                        }
                    }
                    num1++;
                    if (num1 >= length || !(AccountType == "x") || !(this.SystemName.ToLower() == "ppw"))
                    {
                        continue;
                    }
                    stringBuilder.Append("<div>|</div>");
                }
            }
            this.ph_topNavi.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (DataRow row2 in dataTable3.Rows)
            {
                if (!(row2["showPagesIn"].ToString().Trim() == "B") && !(row2["showPagesIn"].ToString().Trim() == "F"))
                {
                    continue;
                }
                if (ConnectionClass.RewriteModule.ToLower() == "on")
                {
                    if (row2["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        languageConversion = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>" };
                        stringBuilder1.Append(string.Concat(languageConversion));
                    }
                    else if (row2["systemName"].ToString().ToLower().Trim() == "products")
                    {
                        if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                        {
                            stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                        }
                        else
                        {
                            stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='ShowLoginonProduct(0, 0);' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                        }
                    }
                    else if (row2["systemName"].ToString().ToLower().Trim() != "sitemap")
                    {
                        languageConversion = new string[] { "<div><a href='", null, null, null, null };
                        publicDocPath = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), "/", ConnectionClass.RemoveIllegalChars(row2["pageName"].ToString()), ConnectionClass.KeySeparator, Convert.ToInt32(row2["pageID"].ToString()), ConnectionClass.FileExtension };
                        languageConversion[1] = base.ResolveUrl(string.Concat(publicDocPath));
                        languageConversion[2] = "'> ";
                        languageConversion[3] = this.objBase.SpecialDecode(row2["pageName"].ToString().Trim());
                        languageConversion[4] = " </a></div>";
                        stringBuilder1.Append(string.Concat(languageConversion));
                    }
                    else if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                    {
                        stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                    }
                    else
                    {
                        stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='ShowLoginonProduct(0, 1);' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                    }
                }
                else if (row2["systemName"].ToString().ToLower().Trim() == "home")
                {
                    languageConversion = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>" };
                    stringBuilder1.Append(string.Concat(languageConversion));
                }
                else if (row2["systemName"].ToString().ToLower().Trim() == "products")
                {
                    if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                    {
                        stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                    }
                    else
                    {
                        stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='ShowLoginonProduct(0, 0);' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                    }
                }
                else if (row2["systemName"].ToString().ToLower().Trim() != "sitemap")
                {
                    publicDocPath = new object[] { "<div><a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row2["pageID"].ToString()), "'> ", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), "</a></div>" };
                    stringBuilder1.Append(string.Concat(publicDocPath));
                }
                else if (!this.IsForceUserLoginProduct || base.Session["StoreUserID"] != null)
                {
                    stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                }
                else
                {
                    stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='ShowLoginonProduct(0, 1);' target='_self'>", this.objBase.SpecialDecode(row2["pageName"].ToString().Trim()), " </a></div>"));
                }
            }
            if (ConnectionClass.ServerName.ToLower() == "phoneink" || ConnectionClass.ServerName.ToLower() == "prelive")
            {
                stringBuilder1.Append("<div><a  href='javascript:void(0);' onclick='ShowAgentCode();' > Agent Code </a></div>");
            }
            this.ph_footer.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
            foreach (DataRow dataRow2 in CMSBasePage.headerSelect(this.CompanyID, this.AccountID, "H").Rows)
            {
                if (dataRow2["logoType"].ToString().Trim() == "I")
                {
                    this.logoImageHeader = dataRow2["logoImage"].ToString();
                    if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageHeader)))
                    {
                        publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", this.AccountID, "&amp;cid=", this.CompanyID };
                        this.BannerImageHeader = string.Concat(publicDocPath);
                    }
                    else
                    {
                        publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageHeader, "&amp;type=b&amp;aid=", this.AccountID, "&amp;cid=", this.CompanyID };
                        this.BannerImageHeader = string.Concat(publicDocPath);
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        if (this.BannerImageHeader == "")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='img-responsive'  alt=' ' /></a>")));
                        }
                        else if (this.IsHomePageVisible != "1")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='img-responsive' alt=' ' />")));
                        }
                        else
                        {
                            ControlCollection controls = this.ph_headerLeft.Controls;
                            languageConversion = new string[] { "<a href='", base.ResolveUrl(this.strSitePath + "Default.aspx"), "' target='_self'><img src='", this.BannerImageHeader, "' class='img-responsive' /></a>" };
                            controls.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    else if (this.BannerImageHeader != "")
                    {
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='img-responsive' alt=' '/></a>")));
                    }
                    else if (this.IsHomePageVisible != "1")
                    {
                        this.ph_headerLeft.Controls.Add(new LiteralControl("<img src='javascript:void(0);' class='img-responsive' alt=' '/>"));
                    }
                    else
                    {
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<a href='", this.strSitePath + "Default.aspx", " target='_self' ><img src='#'  /></a>")));
                    }
                }
                if (dataRow2["logoType"].ToString().Trim() == "T")
                {
                    string str3 = null;
                    str3 = (dataRow2["logoText"].ToString().Trim().Length <= 40 ? dataRow2["logoText"].ToString().Trim() : dataRow2["logoText"].ToString().Trim().Substring(0, 40));
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext_header'> <label id='lbl_headerTextLeft' class='logoText'>", this.objBase.SpecialDecode(str3), "</label></div>")));
                }
                if (dataRow2["logoType"].ToString().Trim() != "C")
                {
                    continue;
                }
                string str4 = null;
                str4 = dataRow2["logoTemplate"].ToString().Trim();
                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", this.objBase.SpecialDecode(str4), "</label>")));
            }
            foreach (DataRow row3 in CMSBasePage.headerSelect(this.CompanyID, this.AccountID, "F").Rows)
            {
                if (row3["logoType"].ToString().Trim() == "I")
                {
                    this.logoImageFooter = row3["logoImage"].ToString();
                    if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageFooter)))
                    {
                        publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", this.AccountID, "&amp;cid=", this.CompanyID };
                        this.BannerImageHeader = string.Concat(publicDocPath);
                    }
                    else
                    {
                        publicDocPath = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageFooter, "&amp;type=b&amp;aid=", this.AccountID, "&amp;cid=", this.CompanyID };
                        this.BannerImageFooter = string.Concat(publicDocPath);
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        if (this.IsHomePageVisible != "1")
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='img-responsive' alt=' ' />")));
                        }
                        else
                        {
                            ControlCollection controlCollections = this.ph_copyWriter.Controls;
                            languageConversion = new string[] { "<a target='_self' href='", base.ResolveUrl(this.strSitePath + "Default.aspx"), "'><img src='", this.BannerImageFooter, "' class='img-responsive' alt=' ' /></a>" };
                            controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    else if (this.IsHomePageVisible != "1")
                    {
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='img-responsive' alt=' ' />")));
                    }
                    else
                    {
                        ControlCollection controls1 = this.ph_copyWriter.Controls;
                        languageConversion = new string[] { "<a target='_self' href='", this.strSitePath+"Default.aspx", "'><img src='", this.BannerImageFooter, "' class='img-responsive' alt=' ' /></a>" };
                        controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                }
                if (row3["logoType"].ToString().Trim() == "T")
                {
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", this.objBase.SpecialDecode(row3["logoText"].ToString().Trim()), "</label>")));
                }
                if (row3["logoType"].ToString().Trim() != "C")
                {
                    continue;
                }
                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", this.objBase.SpecialDecode(row3["logoTemplate"].ToString().Trim()), "</label>")));
            }
            DataTable dataTable4 = LoginBasePage.Select_AccountDetails((long)this.CompanyID, (long)this.AccountID);
            foreach (DataRow dataRow3 in dataTable4.Rows)
            {
                this.DateFormat = dataRow3["DateFormat"].ToString();
            }
            if (ConnectionClass.ISSubScribeUser != null)
            {
                if (ConnectionClass.ISSubScribeUser == "true" || ConnectionClass.IsmailChimpEnabled == "true")
                {
                    this.divsubscribe.Style.Add("display", "block");
                }
                else
                {
                    this.divsubscribe.Style.Add("display", "none");
                }
            }
            if (this.IsValidAgentCode)
            {
                this.divcompanyname.Style.Add("display", "none");
                return;
            }
            this.divcompanyname.Style.Add("display", "block");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
