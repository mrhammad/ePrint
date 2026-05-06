using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Accounts;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ePrint.StoreSettings
{
    public partial class customize_footer : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private commonClass objComm = new commonClass();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private WebstoreBasePage objestore = new WebstoreBasePage();

        private BaseClass objBase = new BaseClass();

        private createImageThumnail objcreateImg = new createImageThumnail();

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public int AccountID;

        public static int appID;

        public string header_title = string.Empty;

        public string header_img = string.Empty;

        public string header_HTML = string.Empty;

        public string bannerImage = string.Empty;

        public static string OrigFile_image;

        public static string NewFile_image;

        public string m_bannerImage = string.Empty;

        public string saveImg = string.Empty;

        public string ServerName = string.Empty;

        private bool flag = true;

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

        static customize_footer()
        {
            customize_footer.appID = 0;
            customize_footer.OrigFile_image = string.Empty;
            customize_footer.NewFile_image = string.Empty;
        }

        public customize_footer()
        {
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            if (this.fu_footer.HasFile)
            {
                string[] strArrays = this.fu_footer.FileName.ToString().Trim().Split(new char[] { '.' });
                string str = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
                if (str.ToLower() == "jpg" || str.ToLower() == "png" || str.ToLower() == "tif" || str.ToLower() == "jpeg" || str.ToLower() == "bmp" || str.ToLower() == "jpf" || str.ToLower() == "gif" || str.ToLower() == "msp" || str.ToLower() == "mng" || str.ToLower() == "pct" || str.ToLower() == "yuv" || str.ToLower() == "tiff" || str.ToLower() == "mng" || str.ToLower() == "jfif" || str.ToLower() == "dib" || str.ToLower() == "jpe")
                {
                    if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//")))
                    {
                        Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//"));
                    }
                    if (!Directory.Exists(string.Concat(this.SecureDocPath, this.ServerName, "//store")))
                    {
                        Directory.CreateDirectory(string.Concat(this.SecureDocPath, this.ServerName, "//store"));
                    }
                    object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID };
                    if (!Directory.Exists(string.Concat(secureDocPath)))
                    {
                        object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID };
                        Directory.CreateDirectory(string.Concat(objArray));
                    }
                    object[] secureDocPath1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners" };
                    if (!Directory.Exists(string.Concat(secureDocPath1)))
                    {
                        object[] objArray1 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners" };
                        Directory.CreateDirectory(string.Concat(objArray1));
                    }
                    empty = this.objComm.ReplaceSplSymbol(this.fu_footer.FileName.ToString());
                    this.bannerImage = empty;
                    this.bannerImage = this.bannerImage.Replace(" ", "_");
                    this.bannerImage = this.ReturnFileName(this.bannerImage, 0);
                    FileUpload fuFooter = this.fu_footer;
                    object[] secureDocPath2 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                    fuFooter.SaveAs(string.Concat(secureDocPath2));
                    FileUpload fileUpload = this.fu_footer;
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//m_", this.bannerImage };
                    fileUpload.SaveAs(string.Concat(objArray2));
                    System.Drawing.Image image = null;
                    object[] secureDocPath3 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.bannerImage };
                    customize_footer.OrigFile_image = string.Concat(secureDocPath3);
                    this.saveImg = this.bannerImage;
                    object[] objArray3 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//m_", this.bannerImage };
                    this.m_bannerImage = string.Concat(objArray3);
                    if (!this.chk_imgSize.Checked)
                    {
                        this.txt_width.Text = "0";
                    }
                    else
                    {
                        if (this.txt_width.Text != "")
                        {
                            int num = Convert.ToInt32(this.txt_width.Text);
                            using (System.Drawing.Image image1 = System.Drawing.Image.FromFile(customize_footer.OrigFile_image))
                            {
                                if (image1.Width <= num)
                                {
                                    this.saveImg = this.bannerImage;
                                }
                                else
                                {
                                    try
                                    {
                                        System.Drawing.Image image2 = System.Drawing.Image.FromFile(customize_footer.OrigFile_image);
                                        image = createImageThumnail.FixedSize(customize_footer.OrigFile_image, image2, num, image1.Height, true, this.m_bannerImage);
                                        image2.Dispose();
                                        image.Dispose();
                                        GC.Collect();
                                    }
                                    catch (Exception exception)
                                    {
                                    }
                                }
                            }
                        }
                        if (this.txt_width.Text == "")
                        {
                            this.txt_width.Text = "0";
                        }
                    }
                    object[] secureDocPath4 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.saveImg };
                    File.Delete(string.Concat(secureDocPath4));
                    object[] objArray4 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//m_", this.saveImg };
                    string str1 = string.Concat(objArray4);
                    object[] secureDocPath5 = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//", this.saveImg };
                    File.Move(str1, string.Concat(secureDocPath5));
                    this.objcreateImg.InsertThumbCommand(string.Concat(" /C imconvert ", customize_footer.OrigFile_image, "[251x71]", this.m_bannerImage));
                }
                else
                {
                    this.lblError.Text = "Please upload only image file";
                    this.lblError.Style.Add("display", "block");
                    this.fu_footer.Style.Add("display", "block");
                    this.div_customizeSize.Style.Add("display", "block");
                    this.lbl_curImg.Style.Add("display", "none");
                    this.lbl_image.Style.Add("display", "none");
                    this.lbl_remove.Style.Add("display", "none");
                    this.flag = false;
                }
            }
            if (this.txt_width.Text == "")
            {
                this.txt_width.Text = "0";
            }
            if (this.flag)
            {
                if (this.saveImg == "")
                {
                    this.saveImg = this.hd_image.Value;
                }
                if (this.rdtext.Checked)
                {
                    WebstoreBasePage.headerInsert(customize_footer.appID, this.CompanyID, this.AccountID, "", base.SpecialEncode(this.txttext.Text), "", "T", "F", false, false, 0);
                }
                if (this.rdimage.Checked)
                {
                    WebstoreBasePage.headerInsert(customize_footer.appID, this.CompanyID, this.AccountID, this.saveImg, "", "", "I", "F", this.rdomakeitcentpercent.Checked, this.rdologosize.Checked, Convert.ToInt32(this.txt_width.Text));
                }
                if (this.rdtemplate.Checked)
                {
                    WebstoreBasePage.headerInsert(customize_footer.appID, this.CompanyID, this.AccountID, "", "", base.SpecialEncode(this.txttemplate.Text), "C", "F", false, false, 0);
                }
                base.Response.Redirect("customize_footer.aspx?suc=up");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.rdimage.Text = this.objLanguage.GetLanguageConversion("Image");
            this.rdtext.Text = this.objLanguage.GetLanguageConversion("Text");
            this.btn_Save.Text = this.objLanguage.GetLanguageConversion("Save");
            this.chk_imgSize.Text = this.objLanguage.GetLanguageConversion("Change_Size");
            this.rdtemplate.Text = this.objLanguage.GetLanguageConversion("Custom_HTML");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.rdologosize.Text = this.objLanguage.GetLanguageConversion("Image_resized_proportionately_max_width");
            this.img_Help_ShortDescritpion_Link_Image.Title = this.objLanguage.GetLanguageConversion("File_exstensions_allowed_gif_png_jpg_jpeg_tiff_tif_bmp");
            this.rdomakeitcentpercent.Text = this.objLanguage.GetLanguageConversion("Make_the_image_width_wide");
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (base.Request.Params["suc"] != null && base.Request.Params["suc"] == "up")
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Updated_Successfully"), "msg-success", this.plhMessageNew);
            }
            string str = SettingsBasePage.Fetch_SelectedAccountID((long)this.UserID);
            if (str != "")
            {
                string[] strArrays = str.Split(new char[] { '~' });
                this.AccountID = Convert.ToInt32(strArrays[0]);
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in WebstoreBasePage.headerSelect(this.CompanyID, this.AccountID, "F").Rows)
                {
                    customize_footer.appID = Convert.ToInt32(row["appID"].ToString());
                    if (row["logoType"].ToString() == "I")
                    {
                        this.rdimage.Checked = true;
                        this.rdtext.Checked = false;
                        this.rdtemplate.Checked = false;
                        if (row["logoImage"].ToString() == "")
                        {
                            continue;
                        }
                        this.divsize.Style.Add("display", "none");
                        this.fu_footer.Style.Add("display", "none");
                        this.div_customizeSize.Style.Add("display", "none");
                        this.lbl_curImg.Style.Add("display", "block");
                        this.lbl_image.Style.Add("display", "block");
                        this.lbl_remove.Style.Add("display", "block");
                        this.lbl_image.Text = row["logoImage"].ToString();
                        this.hd_image.Value = row["logoImage"].ToString();
                        this.rdomakeitcentpercent.Checked = Convert.ToBoolean(row["IsLogoEnlarged"]);
                    }
                    else if (row["logoType"].ToString() != "T")
                    {
                        if (row["logoType"].ToString() != "C")
                        {
                            continue;
                        }
                        this.rdimage.Checked = false;
                        this.rdtext.Checked = false;
                        this.rdtemplate.Checked = true;
                        this.txttemplate.Text = base.SpecialDecode(row["logoTemplate"].ToString());
                    }
                    else
                    {
                        this.rdimage.Checked = false;
                        this.rdtext.Checked = true;
                        this.rdtemplate.Checked = false;
                        this.txttext.Text = base.SpecialDecode(row["logoText"].ToString());
                    }
                }
                HtmlAnchor hrefImage = this.href_image;
                string[] str1 = new string[] { this.strSitepath, "DocManager.ashx?doctype=banner&actid=", this.AccountID.ToString(), "&filename=", this.lbl_image.Text };
                hrefImage.HRef = string.Concat(str1);
            }
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a> > <a href=../StoreSettings/StoreSettings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("eStore_Settings_Panel"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Customize_Footer")));
            global.pageName = "setting";
            global.pgName = "";
            this.gloobj.setpagename("setting");
            base.Title = this.objLanguage.convert(global.pageTitle("Customize Footer", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (this.Session["accountList"] == null)
            {
                this.lbl_change.Text = "Select";
            }
            else
            {
                this.lbl_selectAccount.Text = string.Concat("(", this.Session["accountList"].ToString(), ")");
                this.lbl_change.Text = "Change";
            }
            this.header.dtAccountList = this.objAcc.accountsList(this.CompanyID);
            this.header.SettingName = this.objLanguage.GetLanguageConversion("Customize_Footer");
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, base.GetType(), "", "javascript:CheckallRadiobutton();", true);
        }

        public string ReturnFileName(string fileName, int Number)
        {
            string empty = string.Empty;
            object[] secureDocPath = new object[] { this.SecureDocPath, this.ServerName, "//store//", this.AccountID, "//banners//" };
            string str = string.Concat(secureDocPath);
            string str1 = string.Concat(str, fileName);
            string str2 = fileName.Substring(0, fileName.LastIndexOf("."));
            string str3 = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
            if (!File.Exists(str1))
            {
                empty = fileName;
            }
            else
            {
                string str4 = string.Concat("_", Number.ToString());
                empty = string.Concat(str2, str4, str3);
            }
            if (!File.Exists(string.Concat(str, empty)))
            {
                return empty;
            }
            return this.ReturnFileName(fileName, Number + 1);
        }
    }
}