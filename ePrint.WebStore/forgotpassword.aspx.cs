using nmsCommon;
using nmsConnection;
using nmsEmail;
using nmsLanguage;
using nmsLoginclass;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Data;
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
    public partial class forgotpassword : System.Web.UI.Page, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected PlaceHolder ph_headerLeft;

        //protected HtmlTableCell tdheaderimage;

        //protected HtmlTable tblheaderimage;

        //protected Label lblForGotPassword;

        //protected HtmlGenericControl div_Not_in_DB;

        //protected HtmlGenericControl div_PasswordSent;

        //protected HtmlImage imgError;

        //protected Label lblSucess;

        //protected HtmlGenericControl div_InvalidMsg;

        //protected Label lbl;

        //protected TextBox txtEmail;

        //protected LinkButton LnkForGotPass;

        //protected Button Button1;

        //protected PlaceHolder ph_footer;

        //protected Label lbl_copyWriter;

        //protected PlaceHolder ph_copyWriter;

        //protected HtmlGenericControl divfootersub;

        //protected HtmlGenericControl divfooterMain;

        //protected HtmlForm form1;

        public string SesseionKey = string.Empty;

        public string AccountType = string.Empty;

        public string strSitepath = string.Empty;

        public string FileExtension = string.Empty;

        private commonclass comm = new commonclass();

        private loginclass login = new loginclass();

        private EmailClass objemail = new EmailClass();

        public languageClass objLanguage = new languageClass();

        private BaseClass objBase = new BaseClass();

        public string strImagepath = BaseClass.imagePath();

        public long StoreUserID;

        public static int companyID;

        public static long AccountID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string StyleSheetPath = string.Empty;

        public string StyleSheetPathMaster = string.Empty;

        public int roundoff;

        public int pageID;

        public int arrayLength;

        public char KeySeparator;

        public string Rewritemodule = string.Empty;

        public string strSitePath = string.Empty;

        public string imageHandlerPath = string.Empty;

        public string StoreimageHandlerPath = string.Empty;

        public string logoImageHeader = string.Empty;

        public string logoImageFooter = string.Empty;

        public string nilImage = "nil.gif";

        public string BannerImageHeader = string.Empty;

        public string BannerImageFooter = string.Empty;

        public string bannerImagePath = string.Empty;

        public string SystemName = string.Empty;

        public static int AccCompanyID;

        public string IsHomePageVisible = string.Empty;

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

        static forgotpassword()
        {
            forgotpassword.companyID = 0;
            forgotpassword.AccountID = (long)0;
        }

        public forgotpassword()
        {
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                this.div_Not_in_DB.Style.Add("display", "block");
                this.div_InvalidMsg.Style.Add("display", "none");
            }
            else
            {
                DataTable dataTable = LoginBasePage.LoginTo_Store(this.objBase.SpecialEncode(this.txtEmail.Text.Trim()), "", forgotpassword.AccountID, ConnectionClass.AccountType);
                if (dataTable.Rows.Count <= 0)
                {
                    this.div_Not_in_DB.Style.Add("display", "block");
                    this.div_PasswordSent.Style.Add("display", "none");
                    this.div_InvalidMsg.Style.Add("display", "none");
                    return;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!Convert.ToBoolean(row["IsActive"].ToString()) || !Convert.ToBoolean(row["IsApproved"].ToString()))
                    {
                        HtmlImage htmlImage = this.imgError;
                        object[] accountID = new object[] { this.strSitepath, "ImageHandler.ashx?Imagename=i_msg-error.gif&amp;type=r&amp;aid=", forgotpassword.AccountID, " &amp;cid=", forgotpassword.companyID };
                        htmlImage.Src = string.Concat(accountID);
                        this.div_Not_in_DB.Style.Add("display", "none");
                        this.div_PasswordSent.Style.Add("display", "none");
                        this.div_InvalidMsg.Style.Add("display", "block");
                    }
                    else
                    {
                        this.objemail.emailPassword(Convert.ToInt32(row["StoreUserID"]), Convert.ToInt32(row["CompanyID"]), Convert.ToInt32(row["AccountID"]), "Password Reminder Email");
                        this.div_Not_in_DB.Style.Add("display", "none");
                        this.div_PasswordSent.Style.Add("display", "block");
                        this.div_InvalidMsg.Style.Add("display", "none");
                    }
                }
            }
        }

        protected void LnkCancel_Click(object sender, EventArgs e)
        {
            if (base.Request["id"] == null)
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx?id=", base.Request["id"].ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.div_PasswordSent.Style.Add("display", "none");
            this.div_Not_in_DB.Style.Add("display", "none");
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                forgotpassword.companyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                forgotpassword.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (base.Request["id"] != null)
            {
                forgotpassword.AccountID = Convert.ToInt64(base.Request["id"].ToString());
                this.Session["LanguageConversion"] = LoginBasePage.FetchLanguageConversion(forgotpassword.AccountID);
            }
            this.Button1.Text = this.objLanguage.GetLanguageConversion("Submit");
            this.LnkForGotPass.Text = this.objLanguage.GetLanguageConversion("Cancel");
            base.Title = commonclass.pageTitle("Forgot Password", Convert.ToInt32(forgotpassword.companyID), Convert.ToInt32(forgotpassword.AccountID));
            this.txtEmail.Focus();
            if (ConnectionClass.StyleSheetPath != null)
            {
                object[] publicDocPath = new object[] { ConnectionClass.PublicDocPath, ConnectionClass.ServerName, "/store/", forgotpassword.AccountID };
                this.StyleSheetPath = string.Concat(publicDocPath);
                this.StyleSheetPathMaster = string.Concat(ConnectionClass.StyleSheetPath, "0");
            }
            this.Page.Header.DataBind();
            try
            {
                if (ConnectionClass.SecureDocFilepath != null)
                {
                    object[] secureDocFilepath = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", forgotpassword.AccountID, "\\banners\\" };
                    this.bannerImagePath = string.Concat(secureDocFilepath);
                }
                DataTable dataTable = new DataTable();
                dataTable = LoginBasePage.Select_CompanyID(forgotpassword.AccountID);
                IEnumerator enumerator = dataTable.Rows.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;
                        forgotpassword.AccCompanyID = Convert.ToInt32(current["CompanyID"].ToString());
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
                DataTable dataTable1 = CMSBasePage.headerSelect(forgotpassword.AccCompanyID, Convert.ToInt32(forgotpassword.AccountID), "H");
                foreach (DataRow row in dataTable1.Rows)
                {
                    if (row["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageHeader = row["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageHeader)))
                        {
                            object[] accountID = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", forgotpassword.AccountID, "&amp;cid=", forgotpassword.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID);
                        }
                        else
                        {
                            object[] objArray = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageHeader, "&amp;type=b&amp;aid=", forgotpassword.AccountID, "&amp;cid=", forgotpassword.AccCompanyID };
                            this.BannerImageHeader = string.Concat(objArray);
                        }
                        if (!Convert.ToBoolean(row["IsLogoEnlarged"]))
                        {
                            this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                            this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                        }
                        else
                        {
                            this.tblheaderimage.Attributes["class"] = "width100p";
                            this.tdheaderimage.Attributes["class"] = "width100p paddingBottom5 floatLeft";
                        }
                        int width = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath1 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", forgotpassword.AccountID, "/banners/", row["logoImage"].ToString() };
                            string str = string.Concat(secureDocFilepath1);
                            width = System.Drawing.Image.FromFile(str).Width;
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
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;'  class='floatLeft' alt=' '/>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width: 100%;'  class='floatLeft' alt=' '/>")));
                                }
                            }
                            else if (Convert.ToBoolean(row["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/>")));
                                }
                                else
                                {
                                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' '/>")));
                                }
                            }
                            else if (width <= 950)
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' '/>")));
                            }
                            else
                            {
                                this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' alt=' '/>")));
                            }
                        }
                        else if (this.BannerImageHeader == "")
                        {
                            this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageHeader, "' class='floatLeft' alt=' ' />")));
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(row["IsLogoEnlarged"]))
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
                                    string[] strArrays1 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "'  style='width: 100%;' class='floatLeft' /></a>" };
                                    controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                                }
                            }
                            else if (Convert.ToBoolean(row["IsLogoResized"]))
                            {
                                if (width <= 950)
                                {
                                    ControlCollection controls1 = this.ph_headerLeft.Controls;
                                    string[] strArrays2 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' class='floatLeft' /></a>" };
                                    controls1.Add(new LiteralControl(string.Concat(strArrays2)));
                                }
                                else
                                {
                                    ControlCollection controlCollections1 = this.ph_headerLeft.Controls;
                                    string[] strArrays3 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' /></a>" };
                                    controlCollections1.Add(new LiteralControl(string.Concat(strArrays3)));
                                }
                            }
                            else if (width <= 950)
                            {
                                ControlCollection controls2 = this.ph_headerLeft.Controls;
                                string[] strArrays4 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' class='floatLeft' /></a>" };
                                controls2.Add(new LiteralControl(string.Concat(strArrays4)));
                            }
                            else
                            {
                                ControlCollection controlCollections2 = this.ph_headerLeft.Controls;
                                string[] strArrays5 = new string[] { "<a href='", base.ResolveUrl(this.strSitePath), "' target='_self'><img src='", this.BannerImageHeader, "' style='width:950px;' class='floatLeft' /></a>" };
                                controlCollections2.Add(new LiteralControl(string.Concat(strArrays5)));
                            }
                        }
                        else if (Convert.ToBoolean(row["IsLogoEnlarged"]))
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
                        this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                        this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                        string str1 = null;
                        str1 = (row["logoText"].ToString().Trim().Length <= 40 ? row["logoText"].ToString().Trim() : row["logoText"].ToString().Trim().Substring(0, 40));
                        this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<div class='div_logotext'> <label id='lbl_headerTextLeft' class='logoText'>", this.objBase.SpecialDecode(str1), "</label></div>")));
                    }
                    if (row["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                    string str2 = null;
                    str2 = row["logoTemplate"].ToString().Trim();
                    this.ph_headerLeft.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft1' class='logoText'>", this.objBase.SpecialDecode(str2), "</label>")));
                }
                if (dataTable1.Rows.Count == 0)
                {
                    this.tblheaderimage.Attributes["class"] = "HeaderPlh_tbl";
                    this.tdheaderimage.Attributes["class"] = "HeaderPlh_td1 paddingLeft15";
                }
                StringBuilder stringBuilder = new StringBuilder();
                DataTable dataTable2 = CMSBasePage.CMSPages_get(Convert.ToInt32(forgotpassword.AccCompanyID), Convert.ToInt32(forgotpassword.AccountID), 0);
                dataTable2.Select("ShowPagesIN ='H' or ShowPagesIN ='B'");
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    if (!(dataRow["showPagesIn"].ToString().Trim() == "B") && !(dataRow["showPagesIn"].ToString().Trim() == "F"))
                    {
                        continue;
                    }
                    if (ConnectionClass.RewriteModule.ToLower() == "on")
                    {
                        if (dataRow["systemName"].ToString().ToLower().Trim() == "home")
                        {
                            string[] strArrays6 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow["pageName"].ToString().Trim(), " </a></div>" };
                            stringBuilder.Append(string.Concat(strArrays6));
                        }
                        else if (dataRow["systemName"].ToString().ToLower().Trim() == "products")
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Productnew();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                        }
                        else if (dataRow["systemName"].ToString().ToLower().Trim() != "sitemap")
                        {
                            string[] strArrays7 = new string[] { "<div><a href='", null, null, null, null };
                            object[] objArray1 = new object[] { this.strSitePath, ConnectionClass.RemoveIllegalChars("cms"), ConnectionClass.KeySeparator, Convert.ToInt32(dataRow["pageID"].ToString()), ConnectionClass.FileExtension };
                            strArrays7[1] = base.ResolveUrl(string.Concat(objArray1));
                            strArrays7[2] = "'> ";
                            strArrays7[3] = dataRow["pageName"].ToString().Trim();
                            strArrays7[4] = " </a></div>";
                            stringBuilder.Append(string.Concat(strArrays7));
                        }
                        else
                        {
                            stringBuilder.Append(string.Concat("<div><a href='javascript:void(0);' onclick='Onclick_Sitemap();' target='_self'>", dataRow["pageName"].ToString().Trim(), " </a></div>"));
                        }
                    }
                    else if (dataRow["systemName"].ToString().ToLower().Trim() == "home")
                    {
                        string[] strArrays8 = new string[] { "<div><a href='", base.ResolveUrl(this.strSitePath), "'>", dataRow["pageName"].ToString().Trim(), " </a></div>" };
                        stringBuilder.Append(string.Concat(strArrays8));
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
                DataTable dataTable3 = CMSBasePage.headerSelect(Convert.ToInt32(forgotpassword.AccCompanyID), Convert.ToInt32(forgotpassword.AccountID), "F");
                foreach (DataRow row1 in dataTable3.Rows)
                {
                    if (row1["logoType"].ToString().Trim() == "I")
                    {
                        this.logoImageFooter = row1["logoImage"].ToString();
                        if (!File.Exists(string.Concat(this.bannerImagePath, "\\", this.logoImageFooter)))
                        {
                            object[] accountID1 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.nilImage, "&amp;type=r&amp;aid=", forgotpassword.AccountID, "&amp;cid=", forgotpassword.AccCompanyID };
                            this.BannerImageHeader = string.Concat(accountID1);
                        }
                        else
                        {
                            object[] accountID2 = new object[] { this.strSitePath, "ImageHandler.ashx?Imagename=", this.logoImageFooter, "&amp;type=b&amp;aid=", forgotpassword.AccountID, "&amp;cid=", forgotpassword.AccCompanyID };
                            this.BannerImageFooter = string.Concat(accountID2);
                        }
                        if (!Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            this.divfooterMain.Attributes["class"] = "footer_div";
                            this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        }
                        else
                        {
                            this.divfooterMain.Attributes["class"] = "footer_divsub";
                        }
                        int width1 = 0;
                        if (this.BannerImageHeader != "")
                        {
                            object[] secureDocFilepath2 = new object[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", forgotpassword.AccountID, "/banners/", row1["logoImage"].ToString() };
                            string str3 = string.Concat(secureDocFilepath2);
                            width1 = System.Drawing.Image.FromFile(str3).Width;
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
                                        string[] strArrays9 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' /></a>" };
                                        controls3.Add(new LiteralControl(string.Concat(strArrays9)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections3 = this.ph_copyWriter.Controls;
                                        string[] strArrays10 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' /></a>" };
                                        controlCollections3.Add(new LiteralControl(string.Concat(strArrays10)));
                                    }
                                }
                                else if (Convert.ToBoolean(row1["IsLogoResized"]))
                                {
                                    if (width1 <= 950)
                                    {
                                        ControlCollection controls4 = this.ph_copyWriter.Controls;
                                        string[] strArrays11 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' /></a>" };
                                        controls4.Add(new LiteralControl(string.Concat(strArrays11)));
                                    }
                                    else
                                    {
                                        ControlCollection controlCollections4 = this.ph_copyWriter.Controls;
                                        string[] strArrays12 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' /></a>" };
                                        controlCollections4.Add(new LiteralControl(string.Concat(strArrays12)));
                                    }
                                }
                                else if (width1 <= 950)
                                {
                                    ControlCollection controls5 = this.ph_copyWriter.Controls;
                                    string[] strArrays13 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' /></a>" };
                                    controls5.Add(new LiteralControl(string.Concat(strArrays13)));
                                }
                                else
                                {
                                    ControlCollection controlCollections5 = this.ph_copyWriter.Controls;
                                    string[] strArrays14 = new string[] { "<a target='_blank' href='", base.ResolveUrl(this.strSitePath), "'><img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' /></a>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(strArrays14)));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' />")));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' />")));
                                }
                                else
                                {
                                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (this.IsHomePageVisible == "1")
                        {
                            if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls6 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' /></a>" };
                                    controls6.Add(new LiteralControl(string.Concat(bannerImageFooter)));
                                }
                                else
                                {
                                    ControlCollection controlCollections6 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter1 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' /></a>" };
                                    controlCollections6.Add(new LiteralControl(string.Concat(bannerImageFooter1)));
                                }
                            }
                            else if (Convert.ToBoolean(row1["IsLogoResized"]))
                            {
                                if (width1 <= 950)
                                {
                                    ControlCollection controls7 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter2 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' /></a>" };
                                    controls7.Add(new LiteralControl(string.Concat(bannerImageFooter2)));
                                }
                                else
                                {
                                    ControlCollection controlCollections7 = this.ph_copyWriter.Controls;
                                    string[] bannerImageFooter3 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' /></a>" };
                                    controlCollections7.Add(new LiteralControl(string.Concat(bannerImageFooter3)));
                                }
                            }
                            else if (width1 <= 950)
                            {
                                ControlCollection controls8 = this.ph_copyWriter.Controls;
                                string[] bannerImageFooter4 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' /></a>" };
                                controls8.Add(new LiteralControl(string.Concat(bannerImageFooter4)));
                            }
                            else
                            {
                                ControlCollection controlCollections8 = this.ph_copyWriter.Controls;
                                string[] bannerImageFooter5 = new string[] { "<a target='_blank' href='", this.strSitePath, "'><img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' /></a>" };
                                controlCollections8.Add(new LiteralControl(string.Concat(bannerImageFooter5)));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoEnlarged"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width: 100%;'  class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (Convert.ToBoolean(row1["IsLogoResized"]))
                        {
                            if (width1 <= 950)
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' />")));
                            }
                            else
                            {
                                this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                            }
                        }
                        else if (width1 <= 950)
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' class='floatLeft' alt=' ' />")));
                        }
                        else
                        {
                            this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<img src='", this.BannerImageFooter, "' style='width:950px;' class='floatLeft' alt=' ' />")));
                        }
                    }
                    if (row1["logoType"].ToString().Trim() == "T")
                    {
                        this.divfooterMain.Attributes["class"] = "footer_div";
                        this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                        this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft2'>", this.objBase.SpecialDecode(row1["logoText"].ToString().Trim()), "</label>")));
                    }
                    if (row1["logoType"].ToString().Trim() != "C")
                    {
                        continue;
                    }
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                    this.ph_copyWriter.Controls.Add(new LiteralControl(string.Concat("<label id='lbl_headerTextLeft3'>", this.objBase.SpecialDecode(row1["logoTemplate"].ToString().Trim()), "</label>")));
                }
                if (dataTable3.Rows.Count == 0)
                {
                    this.divfooterMain.Attributes["class"] = "footer_div";
                    this.divfootersub.Attributes["class"] = "lbl_copyWriterDiv";
                }
            }
            catch
            {
            }
        }
    }
}