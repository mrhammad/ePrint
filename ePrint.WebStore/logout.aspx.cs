using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
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
    public partial class logout : BaseClass, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected PlaceHolder ph_headerLeft;

        //protected HtmlTableCell tdheaderimage;

        //protected HtmlTable tblheaderimage;

        //protected Label lblLogOutHead;

        //protected LinkButton Label1;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HtmlGenericControl divfootersub;

        //protected HtmlGenericControl divfooterMain;

        //protected HtmlForm form1;

        public static int AccCompanyID;

        public static int companyID;

        public static long AccountID;

        public static string AccountName;

        public int roundoff;

        public int pageID;

        public long StoreUserID;

        public int arrayLength;

        public char KeySeparator;

        public string FileExtension = string.Empty;

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

        public static string AccountType;

        public string SystemName = string.Empty;

        public string IsPPW = string.Empty;

        public string SesseionKey = string.Empty;

        private string IsHomePageVisible = "1";

        private string isProductVisible = "1";

        public languageClass objLanguage = new languageClass();

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

        static logout()
        {
            logout.companyID = 0;
            logout.AccountID = (long)0;
            logout.AccountName = string.Empty;
            logout.AccountType = string.Empty;
        }

        public logout()
        {
        }

        protected void Label1_LogInAgain(object sender, EventArgs e)
        {
            if (base.Request.Params["id"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitePath, "404.aspx?AccountName=", logout.AccountName));
                return;
            }
            logout.AccountID = Convert.ToInt64(base.Request.Params["id"]);
            base.Response.Redirect(string.Concat(this.strSitePath, "login.aspx?id=", logout.AccountID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] secureDocFilepath;
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
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                logout.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                logout.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
                this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(logout.AccountID);
            }
            if (ConnectionClass.SitePath != null && ConnectionClass.SitePath != "")
            {
                this.strSitePath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.AccountName != null && ConnectionClass.AccountName != "")
            {
                logout.AccountName = ConnectionClass.AccountName;
            }
            if (base.Request.Params["id"] != null)
            {
                logout.AccountID = Convert.ToInt64(base.Request.Params["id"]);
                this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(logout.AccountID);
                DataTable dataTable = LoginBasePage.accounts_getAccountDetails(Convert.ToInt32(logout.AccountID));
                if (dataTable.Rows.Count > 0)
                {
                    logout.AccountName = dataTable.Rows[0]["accountName"].ToString();
                }
            }
            this.Label1.Text = this.objLanguage.GetLanguageConversion("Click_here_To_Login_Again");
            if (base.Request["id"] != null)
            {
                this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(Convert.ToInt64(base.Request["id"].ToString()));
                base.Title = commonclass.pageTitle("Logout", Convert.ToInt32(logout.companyID), Convert.ToInt32(base.Request["id"].ToString()));
            }
            if (!base.IsPostBack)
            {
                HttpCookie item = this.Context.Request.Cookies["ResumeSessionID"];
                if (item != null)
                {
                    commonclass _commonclass = new commonclass();
                    SqlCommand sqlCommand = new SqlCommand("Ws_ResumeSessionStore_delete", _commonclass.openConnection())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@ResumeSessionID", item.Value.ToString());
                    sqlCommand.ExecuteNonQuery();
                    _commonclass.closeConnection();
                    base.Request.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                    base.Response.Cookies.Set(new HttpCookie("ResumeSessionID", ""));
                }
                base.Response.Cookies["ResumeSessionID"].Expires = DateTime.Now.AddDays(-1);
                this.Session.Clear();
                this.Session.Abandon();
                GC.Collect();
            }
            this.lblLogOutHead.Text = LoginBasePage.Select_Phrases("Logout Messages", logout.AccountID);
            this.lblLogOutHead.Text = base.SpecialDecode(this.lblLogOutHead.Text).ToString().Replace("\n", "<br/>");
            if (this.lblLogOutHead.Text == "")
            {
                this.lblLogOutHead.Text = this.objLanguage.GetLanguageConversion("You_have_successfully_Logged_out");
            }
            try
            {
                if (ConnectionClass.SecureDocFilepath != null)
                {
                    secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", logout.AccountID, "\\banners\\" };
                    this.bannerImagePath = string.Concat(secureDocFilepath);
                }
                DataTable dataTable1 = new DataTable();
                dataTable1 = LoginBasePage.Select_CompanyID(logout.AccountID);
                IEnumerator enumerator = dataTable1.Rows.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        logout.AccCompanyID = Convert.ToInt32(current["companyID"].ToString());
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
                DataTable dataTable2 = CMSBasePage.headerSelect(logout.AccCompanyID, Convert.ToInt32(logout.AccountID), "H");
                foreach (DataRow row in dataTable2.Rows)
                {
                    if (row["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageHeader = row["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageHeader)))
                        {
                            object[] accountID = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", logout.AccountID, "&amp;cid=", logout.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID);
                        }
                        else
                        {
                            object[] objArray = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageHeader, "&amp;type=b&amp;aid=", logout.AccountID, "&amp;cid=", logout.AccCompanyID };
                            this.BannerImageHeader = string.Concat(objArray);
                        }
                        if (!Convert.ToBoolean(row["IsLogoEnlarged"]))
                        {
                            this.tblheaderimage.Attributes["class"] = "width98p";
                            this.tdheaderimage.Attributes["class"] = "width98p paddingBottom5 paddingLeft15 floatLeft";
                        }
                        else
                        {
                            this.tblheaderimage.Attributes["class"] = "width100p";
                            this.tdheaderimage.Attributes["class"] = "width100p paddingBottom5 floatLeft";
                        }
                        int width = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath1 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", logout.AccountID, "/banners/", row["logoImage"].ToString() };
                            string str = string.Concat(secureDocFilepath1);
                            if (File.Exists(str))
                            {
                                width = System.Drawing.Image.FromFile(str).Width;
                            }
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
                            else if (Convert.ToBoolean(row["IsLogoEnlarged"]))
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
                            else if (Convert.ToBoolean(row["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  class='floatLeft' alt=' '/></a>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' '/></a>")));
                                }
                            }
                            else if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "'  class='floatLeft' alt=' '/></a>")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' '/></a>")));
                            }
                        }
                        else if (this.BannerImageHeader == "")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' /></a>")));
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(row["IsLogoEnlarged"]))
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
                            else if (Convert.ToBoolean(row["IsLogoResized"]))
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
                        else if (Convert.ToBoolean(row["IsLogoEnlarged"]))
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
                        else if (Convert.ToBoolean(row["IsLogoResized"]))
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
                    if (row["logoType"].ToString().Trim() == "T")
                    {
                        this.tblheaderimage.Attributes["class"] = "width98p";
                        this.tdheaderimage.Attributes["class"] = "width98p paddingBottom5 paddingLeft15 floatLeft";
                        string str1 = null;
                        str1 = (row["logoText"].ToString().Trim().Length <= 40 ? row["logoText"].ToString().Trim() : row["logoText"].ToString().Trim().Substring(0, 40));
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext'> <label id='lbl_headerTextLeft' class='logoText'>", base.SpecialDecode(str1), "</label></div>")));
                    }
                    if (row["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.tblheaderimage.Attributes["class"] = "width98p";
                    this.tdheaderimage.Attributes["class"] = "width98p paddingBottom5 paddingLeft15 floatLeft";
                    string str2 = null;
                    str2 = row["logoTemplate"].ToString().Trim();
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", base.SpecialDecode(str2), "</label>")));
                }
                if (dataTable2.Rows.Count == 0)
                {
                    this.tblheaderimage.Attributes["class"] = "width98p";
                    this.tdheaderimage.Attributes["class"] = "width98p paddingBottom5 paddingLeft15 floatLeft";
                }
                StringBuilder stringBuilder = new StringBuilder();
                DataTable dataTable3 = CMSBasePage.CMSPages_get(Convert.ToInt32(logout.AccCompanyID), Convert.ToInt32(logout.AccountID), 0);
                dataTable3.Select("ShowPagesIN ='H' or ShowPagesIN ='B'");
                foreach (DataRow dataRow in dataTable3.Rows)
                {
                    if (!(dataRow["showPagesIn"].ToString().Trim() == "B") && !(dataRow["showPagesIn"].ToString().Trim() == "F"))
                    {
                        continue;
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        if (dataRow["systemName"].ToString().ToLower().Trim() == "home")
                        {
                            string[] strArrays5 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow["pageName"].ToString().Trim(), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays5));
                        }
                        else if (dataRow["systemName"].ToString().ToLower().Trim() == "products")
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                        }
                        else if (dataRow["systemName"].ToString().ToLower().Trim() != "sitemap")
                        {
                            string[] strArrays6 = new string[] { "<div><a href='", null, null, null, null };
                            object[] objArray1 = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), ConnectionClass.KeySeparator, Convert.ToInt32(dataRow["pageID"].ToString()), ConnectionClass.FileExtension };
                            strArrays6[1] = base.ResolveUrl(string.Concat(objArray1));
                            strArrays6[2] = "'> ";
                            strArrays6[3] = dataRow["pageName"].ToString().Trim();
                            strArrays6[4] = " </a></div>";
                            stringBuilder.Append(string.Concat(strArrays6));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                        }
                    }
                    else if (dataRow["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        string[] strArrays7 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow["pageName"].ToString().Trim(), " </a></div>" };
                        stringBuilder.Append(string.Concat(strArrays7));
                    }
                    else if (dataRow["systemName"].ToString().ToLower().Trim() == "products")
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                    }
                    else if (dataRow["systemName"].ToString().ToLower().Trim() != "sitemap")
                    {
                        object[] num = new object[] { "<div><a href='", this.strSitePath, "cms.aspx?ID=", Convert.ToInt32(dataRow["pageID"].ToString()), "'> ", dataRow["pageName"].ToString().Trim().Trim(), "</a></div>" };
                        stringBuilder.Append(string.Concat(num));
                    }
                    else
                    {
                        stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                    }
                }
                this.ph_footer.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                DataTable dataTable4 = CMSBasePage.headerSelect(Convert.ToInt32(logout.AccCompanyID), Convert.ToInt32(logout.AccountID), "F");
                foreach (DataRow row1 in dataTable4.Rows)
                {
                    if (row1["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageFooter = row1["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageFooter)))
                        {
                            object[] accountID1 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", logout.AccountID, "&amp;cid=", logout.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID1);
                        }
                        else
                        {
                            object[] accountID2 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageFooter, "&amp;type=b&amp;aid=", logout.AccountID, "&amp;cid=", logout.AccCompanyID };
                            this.BannerImageFooter = string.Concat(accountID2);
                        }
                        if (!Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            this.divfooterMain.Attributes["class"] = "footer_div";
                            this.divfootersub.Attributes["class"] = "width95p";
                        }
                        else
                        {
                            this.divfooterMain.Attributes["class"] = "footer_divsub";
                        }
                        int width1 = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath2 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", logout.AccountID, "/banners/", row1["logoImage"].ToString() };
                            string str3 = string.Concat(secureDocFilepath2);
                            if (File.Exists(str3))
                            {
                                width1 = System.Drawing.Image.FromFile(str3).Width;
                            }
                        }
                        if (ConnectionClass.RewriteModule.ToLower() == "on")
                        {
                            if (this.IsHomePageVisible == "1")
                            {
                                if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls3 = this.ph_copyWriter.Controls;
                                        string[] strArrays8 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                        controls3.Add(new LiteralControl(string.Concat(strArrays8)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections3 = this.ph_copyWriter.Controls;
                                        string[] strArrays9 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "'  style='width: 100%;' alt=' ' /></a>" };
                                        controlCollections3.Add(new LiteralControl(string.Concat(strArrays9)));
                                    }
                                }
                                else if (Convert.ToBoolean(row1["IsLogoResized"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls4 = this.ph_copyWriter.Controls;
                                        string[] strArrays10 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                        controls4.Add(new LiteralControl(string.Concat(strArrays10)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections4 = this.ph_copyWriter.Controls;
                                        string[] strArrays11 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                        controlCollections4.Add(new LiteralControl(string.Concat(strArrays11)));
                                    }
                                }
                                else if (width1 <= 950)
                                {
                                    ControlCollection controls5 = this.ph_copyWriter.Controls;
                                    string[] strArrays12 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                    controls5.Add(new LiteralControl(string.Concat(strArrays12)));
                                }
                                else
                                {
                                    ControlCollection controlCollections5 = this.ph_copyWriter.Controls;
                                    string[] strArrays13 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(strArrays13)));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' />")));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
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
                            if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls6 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter1 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' /></a>" };
                                    controls6.Add(new LiteralControl(string.Concat(bannerImageFooter1)));
                                }
                                else
                                {
                                    ControlCollection controlCollections6 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter2 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' /></a>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(bannerImageFooter2)));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls7 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter3 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' alt=' ' /></a>" };
                                    controls7.Add(new LiteralControl(string.Concat(bannerImageFooter3)));
                                }
                                else
                                {
                                    ControlCollection controlCollections7 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter4 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(bannerImageFooter4)));
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
                                string[] bannerImageFooter5 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' alt=' ' /></a>" };
                                controlCollections8.Add(new LiteralControl(string.Concat(bannerImageFooter5)));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;' alt=' ' />")));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoResized"]))
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
                    if (row1["logoType"].ToString().Trim() == "T")
                    {
                        this.divfooterMain.Attributes["class"] = "footer_div";
                        this.divfootersub.Attributes["class"] = "width95p";
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", base.SpecialDecode(row1["logoText"].ToString().Trim()), "</label>")));
                    }
                    if (row1["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "width95p";
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", base.SpecialDecode(row1["logoTemplate"].ToString().Trim()), "</label>")));
                }
                if (dataTable4.Rows.Count == 0)
                {
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "width95p";
                }
                string empty = string.Empty;
                DataTable cartItemCount = new DataTable();
                cartItemCount = CartBasePage.Get_CartItemCount(Convert.ToInt64(this.StoreUserID));
                if (cartItemCount.Rows.Count > 0 && !(cartItemCount.Rows[0]["Count"].ToString() == "0"))
                {
                    string.Concat(cartItemCount.Rows[0]["Count"].ToString(), "  Items in cart");
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            if (ConnectionClass.StyleSheetPath != null)
            {
                secureDocFilepath = new object[] { ConnectionClass.PublicDocPath, ConnectionClass.ServerName, "/store/", logout.AccountID };
                this.StyleSheetPath = string.Concat(secureDocFilepath);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.StyleSheetPath, "0");
            }
            this.Page.Header.DataBind();
        }
    }
}