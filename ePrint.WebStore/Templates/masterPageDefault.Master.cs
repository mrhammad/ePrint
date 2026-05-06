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
using System.Collections;
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class Templates_Sample : MasterPage
    {
        //protected ContentPlaceHolder head;

        //protected HtmlHead Head1;

        //protected PlaceHolder ph_headerLeft;

        //protected HtmlTableCell headerdetailsid;

        //protected HtmlTable headertable;

        //protected HtmlGenericControl myDetails;

        //protected HtmlGenericControl headertopLeft;

        //protected System.Web.UI.WebControls.Image img_search;

        //protected HtmlInputText txt_search;

        //protected HtmlGenericControl div_searchProducts;

        //protected HtmlGenericControl headertop;

        //protected PlaceHolder ph_topNavi;

        //protected Label lblNotifications;

        //protected Label lblPathLink;

        //protected HtmlGenericControl divsitepath;

        //protected HtmlGenericControl divNavigatePannel;

        //protected Label lbl_loginName;

        //protected LinkButton lnkLogout;

        //protected HtmlImage Img_cart;

        //protected HtmlAnchor lbl_mycard;

        //protected Label lblMycarSpliter;

        //protected HtmlGenericControl divMyCart;

        //protected HtmlGenericControl Divlbl_loginName;

        //protected LinkButton lnkApprUser;

        //protected LinkButton lnkEditAddres;

        //protected HtmlGenericControl divlnkEditAddres;

        //protected LinkButton lnkApprOrders;

        //protected HtmlGenericControl divlnkApprOrders;

        //protected HtmlImage imgClose;

        //protected HtmlGenericControl divNotifications;

        //protected Panel HeaderPanel;

        //protected ContentPlaceHolder ContentPlaceHolder1;

        //protected HtmlGenericControl contentPlaceHolder;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HtmlGenericControl divfootersub;

        //protected HtmlGenericControl divfooterMain;

        //protected Panel FooterPanel;

        //protected HtmlForm form1;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int roundoff;

        public int CompanyID;

        public int AccountID;

        public int pageID;

        public long StoreUserID;

        public int arrayLength;

        public char KeySeparator;

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

        public static string AccountType;

        public string SystemName = string.Empty;

        public string PreviewPageName = string.Empty;

        public string IsPPW = string.Empty;

        public string SesseionKey = string.Empty;

        public string Email = string.Empty;

        public string approvalType = string.Empty;

        public string UserType = string.Empty;

        public string Page_Type = string.Empty;

        private string CartImage = string.Empty;

        private string OriginalCartImageName = string.Empty;

        private string IsHomePageVisible = "1";

        private string isProductVisible = "1";

        public string MeasurementValue = string.Empty;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass Objemail = new EmailClass();

        public languageClass objLanguage = new languageClass();

        public string CurrencySymbol = ConnectionClass.CurrencySymbol;

        public string DateFormat = string.Empty;

        public string strMainfooterdiv = string.Empty;

        public string strsubfooterdiv = string.Empty;

        public string strImagepath = BaseClass.SitePath;

        public string CustomRedirectURL = string.Empty;

        public bool estorereportsenabled;

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

        static Templates_Sample()
        {
            Templates_Sample.AccountType = string.Empty;
        }

        public Templates_Sample()
        {
        }

        protected void img_AppOrders_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitePath, "account/myorder.aspx?Po=1"));
        }

        public void lnk_LoginClick(object sender, EventArgs e)
        {
            try
            {
                base.Response.Cookies["cookieePath"].Expires = DateTime.Now.AddYears(-30);
                base.Response.Cookies["cookieeClientID"].Expires = DateTime.Now.AddYears(-30);
            }
            catch
            {
            }
            try
            {
                base.Response.Cookies["cookieLogout"].Value = "yes";
                base.Response.Cookies["cookieLogout"].Expires = DateTime.Now.AddHours(24);
            }
            catch
            {
            }
            base.Session.Abandon();
            base.Response.Redirect(string.Concat(this.strSitePath, "login", this.FileExtension));
        }

        public void lnk_LogoutClick(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountType.ToLower() != "private")
            {
                Templates_Sample.AccountType = "x";
            }
            else
            {
                Templates_Sample.AccountType = "p";
            }
            if (Templates_Sample.AccountType != "p")
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "default.aspx?frm=logout"));
                return;
            }
            base.Response.Cookies["CooPassword"].Expires = DateTime.Now.AddDays(-1);
            if (this.CustomRedirectURL != "")
            {
                base.Response.Redirect(this.CustomRedirectURL);
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitePath, "logout.aspx?id=", this.AccountID));
        }

        protected void lnkApprOrders_Click(object sender, EventArgs e)
        {
            if (this.approvalType == "s")
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "account/myorder.aspx?Po=2"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitePath, "account/myorder.aspx?Po=1"));
        }

        protected void lnkEditAddres_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitePath, "approvalpending.aspx"));
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
            else if (base.Request.Url.ToString().ToLower().IndexOf("avivaprint") != -1)
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
            else if (base.Request.Url.ToString().ToLower().IndexOf("smponline") != -1)
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
            else if (base.Request.Url.ToString().ToLower().IndexOf("siriusprinting") != -1)
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
            else if (base.Request.Url.ToString().ToLower().IndexOf("handyexpress") != -1)
            {

                //Add scripts to the Header of every Page
                Page.Header.Controls.Add(
                        new LiteralControl(
                           Constants.Constants.GoogleTagManagerScript_HandyExpress
                    )
                );

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


            if (base.Request.Browser.Type.ToUpper().Contains("IE"))
            {
                this.divNavigatePannel.Style.Add("padding-top", "1.8px");
                this.Divlbl_loginName.Style.Add("padding-top", "2.5px");
                this.Img_cart.Style.Add("margin-top", "-1px");
            }
            if (base.Request.Url.ToString().ToLower().Contains("my_design.aspx"))
            {
                this.Page_Type = "savedraft";
            }
            if (base.Request.Url.ToString().ToLower().Contains("sitemap.aspx"))
            {
                this.Page_Type = "sitemap";
            }
            if (base.Request.Url.ToString().ToLower().Contains("checkout.aspx"))
            {
                this.Page_Type = "checkout";
            }
            if (base.Request.Url.ToString().ToLower().Contains("account/myorder.aspx"))
            {
                this.Page_Type = "orders";
            }
            if (base.Request.Url.ToString().ToLower().Contains("products/product.aspx"))
            {
                this.Page_Type = "products";
            }
            if (base.Request.Url.ToString().ToLower().Contains("cms.aspx"))
            {
                this.Page_Type = "policy";
            }
            if (base.Request.Url.ToString().ToLower().Contains("default.aspx"))
            {
                this.Page_Type = "home";
            }
            if (base.Request.Url.ToString().ToLower().Contains("account/account.aspx"))
            {
                this.Page_Type = "myaccount";
            }
            if (base.Request.Url.ToString().ToLower().Contains("campaign.aspx"))
            {
                this.Page_Type = "campaign";
            }
            if (base.Request.Url.ToString().ToLower().Contains("estore_reports.aspx"))
            {
                this.Page_Type = "estore_report";
            }
            BaseClass baseClass = new BaseClass();
            this.lblNotifications.Attributes.Add("onclick", "JavaScript:ShowDeshboard();");
            this.imgClose.Attributes.Add("onclick", "javascript:CloseDeshboard();");
            if (ConnectionClass.AccountType.ToLower() != "private")
            {
                Templates_Sample.AccountType = "x";
            }
            else
            {
                Templates_Sample.AccountType = "p";
            }
            if (ConnectionClass.SitePath == null)
            {
                this.strSitePath = "";
            }
            else
            {
                this.strSitePath = ConnectionClass.SitePath.ToString();
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                this.AccountID = Convert.ToInt32(ConnectionClass.AccountID);
            }
            if (ConnectionClass.PublicDocPath != null && ConnectionClass.ServerName != null)
            {
                publicDocPath = new object[] { ConnectionClass.PublicDocPath, ConnectionClass.ServerName, "/store/", this.AccountID };
                this.StyleSheetPath = string.Concat(publicDocPath);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.PublicDocPath, "store/0");
            }
            DataTable dataTable = new DataTable();
            dataTable = LoginBasePage.Select_CompanyID((long)this.AccountID);
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.OriginalCartImageName = current["OriginalCartImageName"].ToString();
                    this.CustomRedirectURL = current["redirectURL"].ToString().Trim();
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
            if (string.IsNullOrEmpty(this.OriginalCartImageName))
            {
                this.Img_cart.Src = "~/images/StoreImages/empty_cart_icon.png";
            }
            else
            {
                string str2 = string.Concat(this.StyleSheetPath, "/CartIcon/", this.OriginalCartImageName);
                try
                {
                    this.Img_cart.Src = str2;
                }
                catch (Exception exception)
                {
                    this.Img_cart.Src = "~/images/StoreImages/empty_cart_icon.png";
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
            if (ConnectionClass.SecureDocFilepath != null)
            {
                object[] secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", this.AccountID, "\\banners\\" };
                this.bannerImagePath = string.Concat(secureDocFilepath);
            }
            if (ConnectionClass.StoreimageHandlerPath != null)
            {
                this.StoreimageHandlerPath = ConnectionClass.StoreimageHandlerPath.ToString();
            }
            if (base.Session["StoreUserID"] != null && base.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(base.Session["StoreUserID"]));
            }
            if (ConnectionClass.SitePath != null)
            {
                this.SystemName = ConnectionClass.SystemName.ToLower().Trim();
            }
            if (ConnectionClass.PreviewPageName != null)
            {
                this.PreviewPageName = ConnectionClass.PreviewPageName.ToLower().Trim();
            }
            if (this.comm.GetDisplayValue("isCheckLoginRegister", (long)this.AccountID) != "true")
            {
                base.Session["CommonClient"] = EprintConfigurationManager.AppSettings["DefaultClientID"].ToString();
            }
            else
            {
                base.Session["CommonClient"] = null;
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
            if (this.comm.GetDisplayValue("isProducts", (long)this.AccountID) == "false")
            {
                this.isProductVisible = "0";
            }
            if (this.comm.GetDisplayValue("IsHome", (long)this.AccountID) == "false")
            {
                this.IsHomePageVisible = "0";
            }
            if (base.Session["StoreUserID"] == null && Templates_Sample.AccountType == "p")
            {
                this.lbl_loginName.Style.Add("display", "none");
                this.lbl_mycard.Style.Add("display", "none");
                this.lblMycarSpliter.Style.Add("display", "none");
            }
            if (base.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(base.Session["StoreUserID"].ToString());
                if (base.Session["LastName"].ToString() == "")
                {
                    this.lbl_loginName.Text = string.Concat(this.objLanguage.GetLanguageConversion("Welcome"), " - ", baseClass.SpecialDecode(base.Session["FirstName"].ToString()));
                }
                else
                {
                    Label lblLoginName = this.lbl_loginName;
                    languageConversion = new string[] { this.objLanguage.GetLanguageConversion("Welcome"), " - ", baseClass.SpecialDecode(base.Session["FirstName"].ToString()), " ", baseClass.SpecialDecode(base.Session["LastName"].ToString()) };
                    lblLoginName.Text = string.Concat(languageConversion);
                }
            }
            if (base.Session["EmailID"] != null)
            {
                this.Email = base.Session["EmailID"].ToString();
            }
            if (base.Request.Url.ToString().ToLower().Contains("/login.aspx") || base.Request.Url.ToString().ToLower().Contains("/logout.aspx"))
            {
                this.div_searchProducts.Style.Add("display", "none");
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
                foreach (DataRow row in dataTable1.Rows)
                {
                    this.roundoff = Convert.ToInt32(row["Roundoff"].ToString());
                }
            }
           
            DataTable dataTable2 = OrderBasePage.Select_EstoreReportsEnabled(this.StoreUserID, (long)this.CompanyID, (long)this.AccountID);
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                if (!Convert.ToBoolean(dataRow["IsEnabled"]))
                {
                    continue;
                }
                this.estorereportsenabled = true;
            }
            this.MeasurementValue = ProductBasePage.MeasurementValue((long)this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            this.newdate = dateTime.ToShortDateString();
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable3 = CMSBasePage.CMSPages_get(this.CompanyID, this.AccountID, 0);
            int length = (int)dataTable3.Select("ShowPagesIN ='H' or ShowPagesIN ='B'").Length;
            int num = 0;
            stringBuilder.Append("<ul id='topnav' style='width: 100%;'>");
            foreach (DataRow row1 in dataTable3.Rows)
            {
                if (!(row1["showPagesIn"].ToString().Trim() == "B") && !(row1["showPagesIn"].ToString().Trim() == "H"))
                {
                    continue;
                }
                if (row1["systemName"].ToString().ToLower().Trim() == "home")
                {
                    if (this.IsHomePageVisible == "1")
                    {
                        if (this.Page_Type != "home")
                        {
                            string[] strArrays = new string[] { "<li><a href='", base.ResolveUrl(this.strSitePath), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                        else
                        {
                            string[] strArrays1 = new string[] { "<li class='SelectedTab'><a class='headerfontcolor' href='", base.ResolveUrl(this.strSitePath), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(strArrays1));
                        }
                    }
                    else if (Templates_Sample.AccountType == "x" && this.IsHomePageVisible == "1")
                    {
                        if (this.Page_Type != "home")
                        {
                            string[] strArrays2 = new string[] { "<li><a href='", base.ResolveUrl(this.strSitePath), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(strArrays2));
                        }
                        else
                        {
                            string[] strArrays3 = new string[] { "<li class='SelectedTab'><a class='headerfontcolor' href='", base.ResolveUrl(this.strSitePath), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(strArrays3));
                        }
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() == "orders")
                {
                    if (base.Session["StoreUserID"] != null)
                    {
                        if (this.Page_Type != "orders")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/myorder.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/myorder.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (this.Page_Type != "orders")
                    {
                        languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/myorder.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                    else
                    {
                        languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/myorder.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() == "my account")
                {
                    if (base.Session["StoreUserID"] != null)
                    {
                        if (this.Page_Type != "myaccount")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/account.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/account.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (this.Page_Type != "myaccount")
                    {
                        languageConversion = new string[] { "<li><a  class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/account.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                    else
                    {
                        languageConversion = new string[] { "<li class='SelectedTab'><a  class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "account/account.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() == "check out")
                {
                    if (base.Session["StoreUserID"] != null)
                    {
                        if (this.Page_Type != "checkout")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "checkout.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "checkout.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (this.Page_Type != "checkout")
                    {
                        languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "checkout.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                    else
                    {
                        languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "checkout.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() == "saved drafts")
                {
                    if (base.Session["StoreUserID"] != null)
                    {
                        if (this.Page_Type != "savedraft")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "my_design.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "my_design.aspx")), "'>", row1["pageName"].ToString().Trim(), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (this.Page_Type != "savedraft")
                    {
                        languageConversion = new string[] { "<li><a  class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "my_design.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                    else
                    {
                        languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "my_design.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() == "campaign")
                {
                    if (base.Session["StoreUserID"] != null)
                    {
                        if (this.Page_Type != "campaign")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "campaign.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "campaign.aspx")), "'>", row1["pageName"].ToString().Trim(), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (this.Page_Type != "campaign")
                    {
                        languageConversion = new string[] { "<li><a  class='UpperCaseText' href='", base.ResolveUrl(string.Concat(this.strSitePath, "campaign.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                    else
                    {
                        languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(string.Concat(this.strSitePath, "campaign.aspx")), "'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                        stringBuilder.Append(string.Concat(languageConversion));
                    }
                }
                else if (row1["systemName"].ToString().ToLower().Trim() != "products")
                {
                    if (row1["systemName"].ToString().ToLower().Trim() == "sitemap" && Templates_Sample.AccountType.ToLower() == "x")
                    {
                        if (this.Page_Type != "sitemap")
                        {
                            languageConversion = new string[] { "<li><a class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "sitemap.aspx' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li class='SelectedTab'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(this.strSitePath), "sitemap.aspx' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                    }
                    else if (row1["systemName"].ToString().ToLower().Trim().Contains("reports") && this.estorereportsenabled)
                    {
                        if (!base.Request.Url.ToString().Contains("estore_reports"))
                        {
                            languageConversion = new string[] { "<li id='li_reports'  style='cursor:pointer'><a class='UpperCaseText' href='", base.ResolveUrl(this.strSitePath), "estore_reports.aspx' >", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), "</a>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        else
                        {
                            languageConversion = new string[] { "<li id='li_reports'  class='SelectedTab' style='cursor:pointer'><a class='UpperCaseText_withColor' href='", base.ResolveUrl(this.strSitePath), "estore_reports.aspx'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), "</a>" };
                            stringBuilder.Append(string.Concat(languageConversion));
                        }
                        stringBuilder.Append("<div id='div_reportsb2bmenu1'>");
                        stringBuilder.Append("</div>");
                        stringBuilder.Append("</li>");
                    }
                    else if (!row1["pageName"].ToString().ToLower().Contains("reports"))
                    {
                        if (!base.Request.Url.ToString().ToLower().Contains(string.Concat("cms.aspx?id=", Convert.ToInt32(row1["pageID"].ToString()))))
                        {
                            publicDocPath = new object[] { "<li><a  class='UpperCaseText'  href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row1["pageID"].ToString()), "'> ", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), "</a></li>" };
                            stringBuilder.Append(string.Concat(publicDocPath));
                        }
                        else
                        {
                            publicDocPath = new object[] { "<li class='SelectedTab'><a  class='UpperCaseText_withColor'  href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(row1["pageID"].ToString()), "'> ", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), "</a></li>" };
                            stringBuilder.Append(string.Concat(publicDocPath));
                        }
                    }
                }
                else if (this.Page_Type == "products")
                {
                    stringBuilder.Append(string.Concat("<li class='SelectedTab'><a id='LnkProduct' runat='Server' href='javascript:void(0);'  class='UpperCaseText_withColor' onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>"));
                }
                else if (base.Request.Url.AbsoluteUri.Contains("productdetails.aspx"))
                {
                    stringBuilder.Append(string.Concat("<li class='SelectedTab'><a id='LnkProduct' runat='Server' href='javascript:void(0);'  class='UpperCaseText_withColor' onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>"));
                }
                else if (base.Request.Url.AbsoluteUri.Contains("edit_template.aspx"))
                {
                    stringBuilder.Append(string.Concat("<li class='SelectedTab'><a id='LnkProduct' runat='Server' href='javascript:void(0);'  class='UpperCaseText_withColor' onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>"));
                }
                else if (!base.Request.Url.AbsoluteUri.Contains("preview.aspx"))
                {
                    stringBuilder.Append(string.Concat("<li><a id='LnkProduct' runat='Server' href='javascript:void(0);'  class='UpperCaseText'  onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>"));
                }
                else
                {
                    stringBuilder.Append(string.Concat("<li class='SelectedTab'><a id='LnkProduct' runat='Server' href='javascript:void(0);'  class='UpperCaseText_withColor' onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(row1["pageName"].ToString().Trim()), " </a></li>"));
                }
                num++;
                if (num >= length || !(Templates_Sample.AccountType == "x") || !(this.SystemName.ToLower() == "ppw"))
                {
                    continue;
                }
                stringBuilder.Append("<div style='float:left;'></div>");
            }
            stringBuilder.Append("</ul>");
            this.ph_topNavi.Controls.Add(new LiteralControl(stringBuilder.ToString()));
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (DataRow dataRow1 in dataTable3.Rows)
            {
                if (!(dataRow1["showPagesIn"].ToString().Trim() == "B") && !(dataRow1["showPagesIn"].ToString().Trim() == "F"))
                {
                    continue;
                }
                if (dataRow1["systemName"].ToString().ToLower().Trim() == "home")
                {
                    languageConversion = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", baseClass.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>" };
                    stringBuilder1.Append(string.Concat(languageConversion));
                }
                else if (dataRow1["systemName"].ToString().ToLower().Trim() == "products")
                {
                    stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", baseClass.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                }
                else if (dataRow1["systemName"].ToString().ToLower().Trim() != "sitemap")
                {
                    publicDocPath = new object[] { "<div><a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(dataRow1["pageID"].ToString()), "'> ", baseClass.SpecialDecode(dataRow1["pageName"].ToString().Trim()), "</a></div>" };
                    stringBuilder1.Append(string.Concat(publicDocPath));
                }
                else
                {
                    stringBuilder1.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", baseClass.SpecialDecode(dataRow1["pageName"].ToString().Trim()), " </a></div>"));
                }
            }
            this.ph_footer.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
            DataTable dataTable4 = CMSBasePage.headerSelect(this.CompanyID, this.AccountID, "H");
            foreach (DataRow row2 in dataTable4.Rows)
            {
                if (row2["logoType"].ToString().Trim() == "I")
                {
                    this.logoImageHeader = row2["logoImage"].ToString();
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
                    int width = 0;
                    if (this.BannerImageHeader != "")
                    {
                        publicDocPath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", this.AccountID, "/banners/", row2["logoImage"].ToString() };
                        string str3 = string.Concat(publicDocPath);
                        if (File.Exists(str3))
                        {
                            width = System.Drawing.Image.FromFile(str3).Width;
                        }
                    }
                    if (!Convert.ToBoolean(row2["IsLogoEnlarged"]))
                    {
                        this.headertopLeft.Attributes["class"] = "headerdivMain";
                        this.myDetails.Attributes["class"] = "headermyDetails";
                        this.headertable.Attributes["class"] = "headermyDetailstable";
                        this.headerdetailsid.Attributes["class"] = "headermyDetailstabletd";
                        this.headertop.Attributes["class"] = "HeadertopPadding";
                        this.div_searchProducts.Attributes["class"] = "div_searchProducts";
                    }
                    else
                    {
                        this.headertopLeft.Attributes["class"] = "headerMaindiv";
                        this.myDetails.Attributes["class"] = "headersubdiv";
                        this.headertable.Attributes["class"] = "headersubdivtable";
                        this.headerdetailsid.Attributes["class"] = "headersubdivtabletd";
                        this.div_searchProducts.Attributes["class"] = "div_searchProducts paddingTop5 headersearchposition";
                    }
                    if (this.BannerImageHeader == "")
                    {
                        if (this.IsHomePageVisible != "1")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl("<img src='javascript:void(0);' style='border: solid 0px white;float:left' alt=' '/>"));
                        }
                        else
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<a href='", this.strSitePath, " target='_self' ><img src='#' style='border: solid 0px white;float:left' /></a>")));
                        }
                    }
                    else if (Convert.ToBoolean(row2["IsLogoEnlarged"]))
                    {
                        if (width <= 950)
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left;width:101.8%;' alt=' '/></a>")));
                        }
                        else
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left;width:101.8%;' alt=' '/></a>")));
                        }
                    }
                    else if (Convert.ToBoolean(row2["IsLogoResized"]))
                    {
                        if (width <= 950)
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left' alt=' '/></a>")));
                        }
                        else
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left;width:950px;' alt=' '/></a>")));
                        }
                    }
                    else if (width <= 950)
                    {
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left' alt=' '/></a>")));
                    }
                    else
                    {
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='border: solid 0px white;float:left;width:950px;' alt=' '/></a>")));
                    }
                }
                if (row2["logoType"].ToString().Trim() == "T")
                {
                    this.headertopLeft.Attributes["class"] = "headerdivMain";
                    this.myDetails.Attributes["class"] = "headermyDetails";
                    this.headertable.Attributes["class"] = "headermyDetailstable";
                    this.headerdetailsid.Attributes["class"] = "headermyDetailstabletd";
                    this.headertop.Attributes["class"] = "HeadertopPadding";
                    this.div_searchProducts.Attributes["class"] = "div_searchProducts";
                    string str4 = null;
                    str4 = (row2["logoText"].ToString().Trim().Length <= 40 ? row2["logoText"].ToString().Trim() : row2["logoText"].ToString().Trim().Substring(0, 40));
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext_header'> <label id='lbl_headerTextLeft' class='logoText'>", baseClass.SpecialDecode(str4), "</label></div>")));
                }
                if (row2["logoType"].ToString().Trim() == "C")
                {
                    this.headertopLeft.Attributes["class"] = "headerdivMain";
                    this.myDetails.Attributes["class"] = "headermyDetails";
                    this.headertable.Attributes["class"] = "headermyDetailstable";
                    this.headerdetailsid.Attributes["class"] = "headermyDetailstabletd";
                    this.headertop.Attributes["class"] = "HeadertopPadding";
                    this.div_searchProducts.Attributes["class"] = "div_searchProducts";
                    string str5 = null;
                    str5 = row2["logoTemplate"].ToString().Trim();
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", baseClass.SpecialDecode(str5), "</label>")));
                }
                if (row2["logoType"].ToString().Trim() != null && !(row2["logoType"].ToString().Trim() == ""))
                {
                    continue;
                }
                this.div_searchProducts.Attributes.Add("Style", "margin-top:6px;");
            }
            if (dataTable4.Rows.Count == 0)
            {
                this.headertopLeft.Attributes["class"] = "headerdivMain";
                this.myDetails.Attributes["class"] = "headermyDetails";
                this.headertable.Attributes["class"] = "headermyDetailstable";
                this.headerdetailsid.Attributes["class"] = "headermyDetailstabletd";
                this.headertop.Attributes["class"] = "HeadertopPadding";
                this.div_searchProducts.Attributes["class"] = "div_searchProducts";
            }
            DataTable dataTable5 = CMSBasePage.headerSelect(this.CompanyID, this.AccountID, "F");
            foreach (DataRow dataRow2 in dataTable5.Rows)
            {
                if (dataRow2["logoType"].ToString().Trim() == "I")
                {
                    if (!Convert.ToBoolean(dataRow2["IsLogoEnlarged"]))
                    {
                        this.divfooterMain.Attributes["class"] = "footer_div";
                        this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                    }
                    else
                    {
                        this.divfooterMain.Attributes["class"] = "footer_divsub";
                    }
                    this.logoImageFooter = dataRow2["logoImage"].ToString();
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
                    int width1 = 0;
                    if (this.BannerImageHeader != "")
                    {
                        publicDocPath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", this.AccountID, "/banners/", dataRow2["logoImage"].ToString() };
                        string str6 = string.Concat(publicDocPath);
                        if (File.Exists(str6))
                        {
                            width1 = System.Drawing.Image.FromFile(str6).Width;
                        }
                    }
                    if (this.IsHomePageVisible == "1")
                    {
                        if (Convert.ToBoolean(dataRow2["IsLogoEnlarged"]))
                        {
                            if (width1 <= 950)
                            {
                                ControlCollection controls = this.ph_copyWriter.Controls;
                                languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;width: 100%;' alt=' ' /></a>" };
                                controls.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                            else
                            {
                                ControlCollection controlCollections = this.ph_copyWriter.Controls;
                                languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;width: 100%;' alt=' ' /></a>" };
                                controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                        else if (Convert.ToBoolean(dataRow2["IsLogoResized"]))
                        {
                            if (width1 <= 950)
                            {
                                ControlCollection controls1 = this.ph_copyWriter.Controls;
                                languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;' alt=' ' /></a>" };
                                controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                            else
                            {
                                ControlCollection controlCollections1 = this.ph_copyWriter.Controls;
                                languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;width:950px;' alt=' ' /></a>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                            }
                        }
                        else if (width1 <= 950)
                        {
                            ControlCollection controls2 = this.ph_copyWriter.Controls;
                            languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;' alt=' ' /></a>" };
                            controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                        else
                        {
                            ControlCollection controlCollections2 = this.ph_copyWriter.Controls;
                            languageConversion = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='border: solid 0px white;width:950px;' alt=' ' /></a>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                        }
                    }
                    else if (Convert.ToBoolean(dataRow2["IsLogoEnlarged"]))
                    {
                        if (width1 <= 950)
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;width: 100%;' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;width: 100%;' alt=' ' />")));
                        }
                    }
                    else if (Convert.ToBoolean(dataRow2["IsLogoResized"]))
                    {
                        if (width1 <= 950)
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;width:950px;' alt=' ' />")));
                        }
                    }
                    else if (width1 <= 950)
                    {
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;' alt=' ' />")));
                    }
                    else
                    {
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='border: solid 0px white;width:950px;' alt=' ' />")));
                    }
                }
                if (dataRow2["logoType"].ToString().Trim() == "T")
                {
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", baseClass.SpecialDecode(dataRow2["logoText"].ToString().Trim()), "</label>")));
                }
                if (dataRow2["logoType"].ToString().Trim() != "C")
                {
                    continue;
                }
                this.divfooterMain.Attributes["class"] = "footer_div";
                this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", baseClass.SpecialDecode(dataRow2["logoTemplate"].ToString().Trim()), "</label>")));
            }
            if (dataTable5.Rows.Count == 0)
            {
                this.divfooterMain.Attributes["class"] = "footer_div";
                this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
            }
            string empty = string.Empty;
            DataTable cartItemCount = new DataTable();
            cartItemCount = CartBasePage.Get_CartItemCount(Convert.ToInt64(this.StoreUserID));
            if (cartItemCount.Rows.Count > 0)
            {
                empty = (cartItemCount.Rows[0]["Count"].ToString() != "0" ? string.Concat(cartItemCount.Rows[0]["Count"].ToString(), "  ", this.objLanguage.GetLanguageConversion("Items_in_cart")) : this.objLanguage.GetLanguageConversion("No_Item_In_cart"));
            }
            this.Img_cart.Attributes.Add("title", empty);
            if (base.Session["ApprovalSystem"] != null)
            {
                if (base.Session["ApprovalSystem"].ToString() != "on")
                {
                    this.divNotifications.Style.Add("display", "none");
                }
                else
                {
                    DataSet dataSet = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
                    if (dataSet.Tables.Count <= 0)
                    {
                        this.divNotifications.Style.Add("display", "none");
                    }
                    else if (dataSet.Tables[0].Rows.Count > 0 || dataSet.Tables[1].Rows.Count > 0 || dataSet.Tables[2].Rows.Count > 0 || dataSet.Tables[3].Rows.Count > 0)
                    {
                        this.approvalType = (new BaseClass()).Return_ApprovalSystem_Settings("approvaltype");
                        if (this.approvalType == "u")
                        {
                            this.divNotifications.Style.Add("display", "none");
                        }
                        else
                        {
                            DataTable dataTable6 = LoginBasePage.PendCountUsersandOrders(this.Email, (long)this.AccountID);
                            if (dataTable6.Rows.Count > 0)
                            {
                                if (dataTable6.Rows[0]["UserCount"].ToString() == "0")
                                {
                                    this.lnkApprUser.Text = this.objLanguage.GetLanguageConversion("No_Users_Approval_Pending");
                                    this.lnkApprUser.Visible = false;
                                }
                                else
                                {
                                    this.lnkApprUser.Text = string.Concat(this.objLanguage.GetLanguageConversion("Users_Approval_Pending"), " (", dataTable6.Rows[0]["UserCount"].ToString(), ")");
                                }
                                if (dataTable6.Rows[0]["AddressCount"].ToString() != "0" || dataTable6.Rows[0]["UserCount"].ToString() != "0")
                                {
                                    long num1 = (long)0;
                                    num1 = Convert.ToInt64(dataTable6.Rows[0]["AddressCount"].ToString()) + Convert.ToInt64(dataTable6.Rows[0]["UserCount"].ToString());
                                    LinkButton linkButton = this.lnkEditAddres;
                                    publicDocPath = new object[] { this.objLanguage.GetLanguageConversion("User_Profile_Approval"), " (", num1, ")" };
                                    linkButton.Text = string.Concat(publicDocPath);
                                }
                                else
                                {
                                    this.lnkEditAddres.Text = this.objLanguage.GetLanguageConversion("No_User_Profile_Approval");
                                    this.lnkEditAddres.Visible = false;
                                    this.divlnkEditAddres.Style.Add("display", "none");
                                }
                                if (dataTable6.Rows[0]["OrderCount"].ToString() == "0")
                                {
                                    this.lnkApprOrders.Text = this.objLanguage.GetLanguageConversion("No_Orders_Approval");
                                    this.lnkApprOrders.Visible = false;
                                    this.divlnkApprOrders.Style.Add("display", "none");
                                }
                                else
                                {
                                    this.lnkApprOrders.Text = string.Concat(this.objLanguage.GetLanguageConversion("Orders_Approval"), " (", dataTable6.Rows[0]["OrderCount"].ToString(), ")");
                                }
                                if (dataTable6.Rows[0]["OrderCount"].ToString() != "0" || dataTable6.Rows[0]["UserCount"].ToString() != "0" || dataTable6.Rows[0]["AddressCount"].ToString() != "0")
                                {
                                    Label label = this.lblNotifications;
                                    publicDocPath = new object[] { this.objLanguage.GetLanguageConversion("Notification"), "  (", Convert.ToInt32(dataTable6.Rows[0]["UserCount"].ToString()) + Convert.ToInt32(dataTable6.Rows[0]["OrderCount"].ToString()) + Convert.ToInt32(dataTable6.Rows[0]["AddressCount"].ToString()), " items for action)" };
                                    label.Text = string.Concat(publicDocPath);
                                }
                                else
                                {
                                    this.lblNotifications.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.divNotifications.Style.Add("display", "none");
                    }
                }
            }
            if (!this.lblNotifications.Visible || this.divNotifications.Style["display"] == "none")
            {
                base.Session["Notification"] = "no";
                this.divsitepath.Attributes["class"] = "floatLeft divsitepathwidthwithoutNotification";
            }
            else
            {
                base.Session["Notification"] = "yes";
                this.divsitepath.Attributes["class"] = "floatLeft divsitepathwidth";
            }
            this.txt_search.Style.Add("color", "Gray");
            DataTable dataTable7 = LoginBasePage.Select_AccountDetails((long)this.CompanyID, (long)this.AccountID);
            foreach (DataRow row3 in dataTable7.Rows)
            {
                this.DateFormat = row3["DateFormat"].ToString();
            }
            this.txt_search.Style.Add("background", string.Concat("url('", this.strImagepath, "Images/StoreImages/rsz_213267.png')no-repeat;"));
        }


        protected override void OnInit(EventArgs e)
        {
            // set stylesheet Hrefs before base.OnInit so Page.Theme/SetStyleSheet can safely modify Header
            try
            {
                SetHeadResources();
            }
            catch (Exception ex)
            {
               System.Diagnostics.Trace.TraceWarning("SetStyleSheetLinks failed: " + ex.Message);
            }

            base.OnInit(e);
        }

        private void SetHeadResources()
        {
            try
            {
                //// DateFormat script (emit safely)
                //var sd = this.FindControl("scriptDateFormat") as HtmlGenericControl;
                //if (sd != null)
                //{
                //    sd.InnerHtml = "DateFormat = '" + HttpUtility.JavaScriptStringEncode(this.DateFormat ?? "") + "';";
                //}

                //// Script src attributes
                //string sitePath = (this.strSitePath ?? "").Trim();
                //string ver = (this.VersionNumber ?? "").Trim(); sitePath = sitePath.Trim();

                //var sj = this.FindControl("scriptJquery") as HtmlGenericControl;
                //if (sj != null)
                //{
                //    sj.Attributes["src"] = ResolveUrl(sitePath + "js/jquery-1.3.1.min.js?VN=" + ver);
                //}

                //var ssc = this.FindControl("scriptScrollTo") as HtmlGenericControl;
                //if (ssc != null)
                //{
                //    ssc.Attributes["src"] = ResolveUrl(sitePath + "js/jquery.scrollTo.js?VN=" + ver);
                //}

                //var sld = this.FindControl("scriptSliding") as HtmlGenericControl;
                //if (sld != null)
                //{
                //    sld.Attributes["src"] = ResolveUrl(sitePath + "js/SlidingDescription.js?VN=" + ver);
                //}

                //var sc = this.FindControl("scriptCalendar") as HtmlGenericControl;
                //if (sc != null)
                //{
                //    sc.Attributes["src"] = ResolveUrl(sitePath + "js/swazz_calendar_store.js?VN=" + ver);
                //}

                //var sm = this.FindControl("scriptMaster") as HtmlGenericControl;
                //if (sm != null)
                //{
                //    sm.Attributes["src"] = ResolveUrl(sitePath + "js/master.js?VN=" + ver);
                //}

                // Stylesheet links (if present)
                string publicDocPath = ConnectionClass.PublicDocPath ?? string.Empty;
                string serverName = ConnectionClass.ServerName ?? string.Empty;
                string accountId = ConnectionClass.AccountID ?? string.Empty;

                if (string.IsNullOrEmpty(publicDocPath) || string.IsNullOrEmpty(serverName))
                    return;

                string styleSheetPath = string.Concat(publicDocPath, serverName, "/store/", accountId).TrimEnd('/');
                string styleSheetPathMaster = string.Concat(publicDocPath, "store/0").TrimEnd('/');

                if (this.Link1 != null)
                {
                    this.Link1.Href = ResolveUrl(styleSheetPathMaster + "/Themes/StyleSheet_B2B_Live404.css");
                }

                if (this.MainStyle2 != null)
                {
                    this.MainStyle2.Href = ResolveUrl(styleSheetPath + "/Themes/StyleSheet_B2B.css");
                }

                if (this.Link2 != null)
                {
                    this.Link2.Href = ResolveUrl(styleSheetPath + "/Themes/CustomStyleSheet.css");
                }

                //// Emit page-level JS variables into litPageVars (replace the inline <%=%> block)
                //Literal lit = this.FindControl("litPageVars") as Literal;
                //if (lit != null)
                //{
                //    var sb = new StringBuilder();
                //    sb.AppendLine("<script type=\"text/javascript\">");
                //    sb.AppendFormat("var roundoff = '{0}';", HttpUtility.JavaScriptStringEncode(Convert.ToString(this.roundoff)));
                //    sb.AppendLine();
                //    sb.AppendFormat("var MeasurementValue = '{0}';", HttpUtility.JavaScriptStringEncode(this.MeasurementValue ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var currentdate = '{0}';", HttpUtility.JavaScriptStringEncode(this.newdate ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var StyleSheetPath = '{0}';", HttpUtility.JavaScriptStringEncode(this.StyleSheetPath ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var accid = '{0}';", HttpUtility.JavaScriptStringEncode(Convert.ToString(this.AccountID)));
                //    sb.AppendLine();
                //    sb.AppendFormat("var strSitePath = '{0}';", HttpUtility.JavaScriptStringEncode(this.strSitePath ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var AccountType = '{0}';", HttpUtility.JavaScriptStringEncode(Templates_Sample.AccountType ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var SystemName = '{0}';", HttpUtility.JavaScriptStringEncode(this.SystemName ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var PreviewPageName = '{0}';", HttpUtility.JavaScriptStringEncode(this.PreviewPageName ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var StyleSheetPathMaster = '{0}';", HttpUtility.JavaScriptStringEncode(this.StyleSheetPathMaster ?? ""));
                //    sb.AppendLine();
                //    sb.AppendFormat("var jsCurrencySymbol = '{0}';", HttpUtility.JavaScriptStringEncode(this.CurrencySymbol ?? ""));
                //    sb.AppendLine("</script>");

                //    lit.Text = sb.ToString();
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceWarning("SetHeadResources failed: " + ex.Message);
            }
        }
    }
}