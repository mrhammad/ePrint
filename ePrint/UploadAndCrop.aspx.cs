using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Upload;

namespace ePrint
{
    public partial class UploadAndCrop : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string path;

        private createImageThumnail objthumb = new createImageThumnail();

        public languageClass objLanguage = new languageClass();

        private string filename = string.Empty;

        public string strImagepath = global.imagePath();

        public string strFilepath = global.filePath();

        public string strSitePath = global.sitePath();

        public string t_catagoryImage = string.Empty;

        public string m_catagoryImage = string.Empty;

        public static string catagoryImageName;

        public static string OrigFile_image;

        public static string NewFile_image;

        public static string GOrigFile_image;

        public string CompanyID = string.Empty;

        public string catagoryImage = string.Empty;

        public string productImage = string.Empty;

        public string UserImage = string.Empty;

        public int categoryID;

        public int ProductCatalogueID;

        public int UserID;

        public string imgToSave = string.Empty;

        public string imgcropheightprop = string.Empty;

        public string Pagetype = string.Empty;

        public string savepath = string.Empty;

        public bool thumbproptional;

        private BaseClass objBase = new BaseClass();

        public string ServerName = string.Empty;

        public string SecureVirtualPath = string.Empty;

        private bool Err_flag = true;

        public string stripeImage = string.Empty;

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

        static UploadAndCrop()
        {
            UploadAndCrop.catagoryImageName = string.Empty;
            UploadAndCrop.OrigFile_image = string.Empty;
            UploadAndCrop.NewFile_image = string.Empty;
            UploadAndCrop.GOrigFile_image = string.Empty;
        }

        public UploadAndCrop()
        {
        }

        public void autocrop()
        {
            System.Drawing.Image image = null;
            System.Drawing.Image image1 = null;
            string empty = string.Empty;
            string str = string.Empty;
            UploadAndCrop.OrigFile_image = string.Concat(this.savepath, this.hdnUploadfilename.Value);
            int num = 200;
            int num1 = 150;
            int num2 = 300;
            int num3 = 300;
            try
            {
                System.Drawing.Image image2 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                double num4 = Convert.ToDouble(image2.Height);
                double num5 = Convert.ToDouble(image2.Width);
                double num6 = 0;
                double num7 = 0;
                if (num4 / num5 == 1 || num5 / num4 == 1)
                {
                    num6 = Convert.ToDouble(image2.Height);
                    num7 = Convert.ToDouble(image2.Width);
                    if (image2.Width < 300 && image2.Height < 300)
                    {
                        num2 = Convert.ToInt32(image2.Width);
                        num3 = Convert.ToInt32(image2.Height);
                    }
                }
                else
                {
                    num6 = num4 / num5 * 300;
                    num7 = num5 / num4 * 300;
                }
                double num8 = num4 / num5 * 200;
                double num9 = num5 / num4 * 150;
                this.imgcropheightprop = Convert.ToString(Math.Round(Convert.ToDouble(num6), 0));
                string str1 = Convert.ToString(Math.Round(Convert.ToDouble(num7), 0));
                string str2 = Convert.ToString(Math.Round(Convert.ToDouble(num8), 0));
                string str3 = Convert.ToString(Math.Round(Convert.ToDouble(num9), 0));
                if (num6 < num7)
                {
                    this.lbltextforimg300.Text = string.Concat(this.objLanguage.GetLanguageConversion("Product_Image"), " (300*", this.imgcropheightprop, ")px");
                    empty = "300";
                    str = this.imgcropheightprop;
                }
                else if (num6 != num7)
                {
                    this.lbltextforimg300.Text = string.Concat(this.objLanguage.GetLanguageConversion("Product_Image"), " (", str1, "*300)px");
                    empty = str1;
                    str = "300";
                }
                else
                {
                    Label label = this.lbltextforimg300;
                    object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("Product_Image"), " (", image2.Width, "*", image2.Height, ")px" };
                    label.Text = string.Concat(languageConversion);
                    empty = image2.Width.ToString();
                    str = image2.Height.ToString();
                }
                if (num8 >= num9)
                {
                    if (Convert.ToInt16(str3) < 200)
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", str3, "*150)px");
                    }
                    else
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (200*150)px");
                    }
                    this.hdnthumbwidth.Value = str3;
                    this.hdnthumbheight.Value = "150";
                    HiddenField hiddenField = this.hdnthumbcroptype;
                    Label label1 = this.lblcropthumbprop;
                    string str4 = string.Concat("(", str3, "*150)px");
                    string str5 = str4;
                    label1.Text = str4;
                    hiddenField.Value = str5;
                }
                else
                {
                    if (Convert.ToInt16(str2) < 150)
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (200*", str2, ")px");
                    }
                    else
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (200*150)px");
                    }
                    this.hdnthumbwidth.Value = "200";
                    this.hdnthumbheight.Value = str2;
                    HiddenField hiddenField1 = this.hdnthumbcroptype;
                    Label label2 = this.lblcropthumbprop;
                    string str6 = string.Concat("(200 *", str2, ")");
                    string str7 = str6;
                    label2.Text = str6;
                    hiddenField1.Value = str7;
                }
                System.Drawing.Image image3 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                FrameDimension frameDimension = new FrameDimension(image3.FrameDimensionsList[0]);
                int frameCount = image3.GetFrameCount(frameDimension);
                string[] strArrays = this.Upload.FileName.ToString().Trim().Split(new char[] { '.' });
                string str8 = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
                if (image2.Width >= 200 || image2.Height >= 150)
                {
                    System.Drawing.Image image4 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image4, num, num1, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else if (frameCount <= 0)
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image4, num, num1, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                    }
                    image4.Dispose();
                    image.Dispose();
                    GC.Collect();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString = new QueryString()
					{
						{ "doctype", "imgcpprd" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim());
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString2 = new QueryString()
					{
						{ "doctype", "imgcpcat" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
                    }
                    else if (this.Pagetype.ToLower() == "stripe_settings")
                    {
                        QueryString queryString2 = new QueryString()
                    {
                        { "doctype", "imgcpstripe" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
                    }
                    System.Drawing.Image image5 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image5, num2, num3, false);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else if (frameCount <= 0)
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image5, num2, num3, false);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image1 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                        this.imgthumbnail.Width = Convert.ToInt16(this.hdnthumbwidth.Value);
                        this.imgthumbnail.Height = Convert.ToInt16(this.hdnthumbheight.Value);
                        this.lnkbtnCrop.Visible = false;
                    }
                    image5.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    image3.Dispose();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString4 = new QueryString()
					{
						{ "doctype", "imgcpprd" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString5.ToString().Trim());
                        if (str8.ToLower() != "gif")
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else if (frameCount <= 0)
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else
                        {
                            this.img300preview.Width = Convert.ToInt16(empty);
                            this.img300preview.Height = Convert.ToInt16(str);
                            this.lnkbtnCroplarge.Visible = false;
                        }
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString6 = new QueryString()
					{
						{ "doctype", "imgcpcat" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString7);
                    }

                    if (this.Pagetype.ToLower() == "stripe_settings")
                    {
                        this.lnkbtnCrop.Visible = false;
                    }
                }
                else
                {
                    System.Drawing.Image image6 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image6, image2.Width, image2.Height, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                    }
                    image6.Dispose();
                    image.Dispose();
                    GC.Collect();
                    string empty1 = string.Empty;
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString8 = new QueryString()
					{
						{ "doctype", "imgcpprd" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString9.ToString().Trim());
                        string[] secureDocPath = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//m_", this.hdnUploadfilename.Value };
                        empty1 = string.Concat(secureDocPath);
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString10 = new QueryString()
					{
						{ "doctype", "imgcpprd" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString11.ToString().Trim());
                        string[] secureDocPath1 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory//m_", this.hdnUploadfilename.Value };
                        empty1 = string.Concat(secureDocPath1);
                    }
                    else if (this.Pagetype.ToLower() == "stripe_settings")
                    {
                        QueryString queryString2 = new QueryString()
                    {
                        { "doctype", "imgcpstripe" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
                    }

                    Label label3 = this.Label3;
                    object[] objArray = new object[] { this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", image2.Width, "*", image2.Height, ")px" };
                    label3.Text = string.Concat(objArray);
                    Label label4 = this.lbltextforimg300;
                    object[] languageConversion1 = new object[] { this.objLanguage.GetLanguageConversion("Product_Image"), " (", image2.Width, "*", image2.Height, ")px" };
                    label4.Text = string.Concat(languageConversion1);
                    System.Drawing.Image image7 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image7, num2, num3, true, empty1);
                    }
                    else if (frameCount <= 0)
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image7, num2, num3, true, empty1);
                    }
                    else
                    {
                        image1 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                        this.imgthumbnail.Width = Convert.ToInt16(this.hdnthumbwidth.Value);
                        this.imgthumbnail.Height = Convert.ToInt16(this.hdnthumbheight.Value);
                        this.lnkbtnCrop.Visible = false;
                    }
                    image7.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    image3.Dispose();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString12 = new QueryString()
					{
						{ "doctype", "imgcpprd" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString13.ToString().Trim());
                        if (str8.ToLower() != "gif")
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else if (frameCount <= 0)
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else
                        {
                            this.img300preview.Width = Convert.ToInt16(empty);
                            this.img300preview.Height = Convert.ToInt16(str);
                            this.lnkbtnCroplarge.Visible = false;
                        }
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString14 = new QueryString()
					{
						{ "doctype", "imgcpcat" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString15.ToString().Trim());
                    }
                    if (this.Pagetype.ToLower() == "stripe_settings")
                    {
                        this.lnkbtnCrop.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
            }
            this.pnlCropped.Visible = true;
            this.pnlCrop.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnsaveimg.Visible = true;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.divsave_crop.Attributes["class"] = "showdiv";
        }

        public void autocrop1()
        {
            System.Drawing.Image image = null;
            System.Drawing.Image image1 = null;
            string empty = string.Empty;
            string str = string.Empty;
            UploadAndCrop.OrigFile_image = string.Concat(this.savepath, this.hdnUploadfilename.Value);
            int num = 500;
            int num1 = 500;
            int num2 = 500;
            int num3 = 500;
            try
            {
                System.Drawing.Image image2 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                double num4 = Convert.ToDouble(image2.Height);
                double num5 = Convert.ToDouble(image2.Width);
                double num6 = 0;
                double num7 = 0;
                if (num4 / num5 == 1 || num5 / num4 == 1)
                {
                    num6 = Convert.ToDouble(image2.Height);
                    num7 = Convert.ToDouble(image2.Width);
                    if (image2.Width < 500 && image2.Height < 500)
                    {
                        num2 = Convert.ToInt32(image2.Width);
                        num3 = Convert.ToInt32(image2.Height);
                    }
                }
                else
                {
                    num6 = num4 / num5 * 500;
                    num7 = num5 / num4 * 500;
                }
                double num8 = num4 / num5 * 500;
                double num9 = num5 / num4 * 500;
                this.imgcropheightprop = Convert.ToString(Math.Round(Convert.ToDouble(num6), 0));
                string str1 = Convert.ToString(Math.Round(Convert.ToDouble(num7), 0));
                string str2 = Convert.ToString(Math.Round(Convert.ToDouble(num8), 0));
                string str3 = Convert.ToString(Math.Round(Convert.ToDouble(num9), 0));
                if (num6 < num7)
                {
                    this.lbltextforimg300.Text = string.Concat(this.objLanguage.GetLanguageConversion("Product_Image"), " (500*", this.imgcropheightprop, ")px");
                    empty = "500";
                    str = this.imgcropheightprop;
                }
                else if (num6 != num7)
                {
                    this.lbltextforimg300.Text = string.Concat(this.objLanguage.GetLanguageConversion("Product_Image"), " (", str1, "*500)px");
                    empty = str1;
                    str = "500";
                }
                else
                {
                    Label label = this.lbltextforimg300;
                    object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("Product_Image"), " (500*500)px" };
                    label.Text = string.Concat(languageConversion);
                    empty = image2.Width.ToString();
                    str = image2.Height.ToString();
                }
                if (num8 >= num9)
                {
                    if (Convert.ToInt16(str3) < 500)
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", str3, "*500)px");
                    }
                    else
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (500*500)px");
                    }
                    this.hdnthumbwidth.Value = str3;
                    this.hdnthumbheight.Value = "500";
                    HiddenField hiddenField = this.hdnthumbcroptype;
                    Label label1 = this.lblcropthumbprop;
                    string str4 = string.Concat("(", str3, "*500)px");
                    string str5 = str4;
                    label1.Text = str4;
                    hiddenField.Value = str5;
                }
                else
                {
                    if (Convert.ToInt16(str2) < 500)
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (500*", str2, ")px");
                    }
                    else
                    {
                        this.Label3.Text = string.Concat(this.objLanguage.GetLanguageConversion("Thumb_nail"), " (500*500)px");
                    }
                    this.hdnthumbwidth.Value = "500";
                    this.hdnthumbheight.Value = str2;
                    HiddenField hiddenField1 = this.hdnthumbcroptype;
                    Label label2 = this.lblcropthumbprop;
                    string str6 = string.Concat("(500 *", str2, ")");
                    string str7 = str6;
                    label2.Text = str6;
                    hiddenField1.Value = str7;
                }
                System.Drawing.Image image3 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                FrameDimension frameDimension = new FrameDimension(image3.FrameDimensionsList[0]);
                int frameCount = image3.GetFrameCount(frameDimension);
                string[] strArrays = this.Upload.FileName.ToString().Trim().Split(new char[] { '.' });
                string str8 = strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
                if (image2.Width >= 500 || image2.Height >= 500)
                {
                    System.Drawing.Image image4 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image4, num, num1, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else if (frameCount <= 0)
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image4, num, num1, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                    }
                    image4.Dispose();
                    image.Dispose();
                    GC.Collect();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString = new QueryString()
                    {
                        { "doctype", "imgcpprd" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim());
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString2 = new QueryString()
                    {
                        { "doctype", "imgcpcat" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
                    }
                    System.Drawing.Image image5 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image5, num2, num3, false);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else if (frameCount <= 0)
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image5, num2, num3, false);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image1 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                        this.imgthumbnail.Width = Convert.ToInt16(this.hdnthumbwidth.Value);
                        this.imgthumbnail.Height = Convert.ToInt16(this.hdnthumbheight.Value);
                        this.lnkbtnCrop.Visible = false;
                    }
                    image5.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    image3.Dispose();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString4 = new QueryString()
                    {
                        { "doctype", "imgcpprd" },
                        { "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString5.ToString().Trim());
                        if (str8.ToLower() != "gif")
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else if (frameCount <= 0)
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else
                        {
                            this.img300preview.Width = Convert.ToInt16(empty);
                            this.img300preview.Height = Convert.ToInt16(str);
                            this.lnkbtnCroplarge.Visible = false;
                        }
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString6 = new QueryString()
                    {
                        { "doctype", "imgcpcat" },
                        { "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString7);
                    }
                }
                else
                {
                    System.Drawing.Image image6 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image6, image2.Width, image2.Height, false);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    }
                    else
                    {
                        image = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                    }
                    image6.Dispose();
                    image.Dispose();
                    GC.Collect();
                    string empty1 = string.Empty;
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString8 = new QueryString()
                    {
                        { "doctype", "imgcpprd" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString9 = Encryption.EncryptQueryString(queryString8);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString9.ToString().Trim());
                        string[] secureDocPath = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product//m_", this.hdnUploadfilename.Value };
                        empty1 = string.Concat(secureDocPath);
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString10 = new QueryString()
                    {
                        { "doctype", "imgcpprd" },
                        { "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString11 = Encryption.EncryptQueryString(queryString10);
                        this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString11.ToString().Trim());
                        string[] secureDocPath1 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory//m_", this.hdnUploadfilename.Value };
                        empty1 = string.Concat(secureDocPath1);
                    }
                    Label label3 = this.Label3;
                    object[] objArray = new object[] { this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", image2.Width, "*", image2.Height, ")px" };
                    label3.Text = string.Concat(objArray);
                    Label label4 = this.lbltextforimg300;
                    object[] languageConversion1 = new object[] { this.objLanguage.GetLanguageConversion("Product_Image"), " (", image2.Width, "*", image2.Height, ")px" };
                    label4.Text = string.Concat(languageConversion1);
                    System.Drawing.Image image7 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    if (str8.ToLower() != "gif")
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image7, num2, num3, true, empty1);
                    }
                    else if (frameCount <= 0)
                    {
                        this.lnkbtnCrop.Visible = true;
                        image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image7, num2, num3, true, empty1);
                    }
                    else
                    {
                        image1 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                        image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Gif);
                        this.imgthumbnail.Width = Convert.ToInt16(this.hdnthumbwidth.Value);
                        this.imgthumbnail.Height = Convert.ToInt16(this.hdnthumbheight.Value);
                        this.lnkbtnCrop.Visible = false;
                    }
                    image7.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    image3.Dispose();
                    if (this.Pagetype.ToLower() == "productcatalogue_item")
                    {
                        QueryString queryString12 = new QueryString()
                    {
                        { "doctype", "imgcpprd" },
                        { "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString13 = Encryption.EncryptQueryString(queryString12);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString13.ToString().Trim());
                        if (str8.ToLower() != "gif")
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else if (frameCount <= 0)
                        {
                            this.lnkbtnCroplarge.Visible = true;
                        }
                        else
                        {
                            this.img300preview.Width = Convert.ToInt16(empty);
                            this.img300preview.Height = Convert.ToInt16(str);
                            this.lnkbtnCroplarge.Visible = false;
                        }
                    }
                    else if (this.Pagetype.ToLower() == "product_category")
                    {
                        QueryString queryString14 = new QueryString()
                    {
                        { "doctype", "imgcpcat" },
                        { "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
                    };
                        QueryString queryString15 = Encryption.EncryptQueryString(queryString14);
                        this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString15.ToString().Trim());
                    }
                }
            }
            catch (Exception exception)
            {
            }
            this.pnlCropped.Visible = true;
            this.pnlCrop.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnsaveimg.Visible = true;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.divsave_crop.Attributes["class"] = "showdiv";
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Pagetype.ToLower() != "user_add")
            {
                this.divPreview.Attributes["class"] = "showdiv";
                this.pnlCrop.Visible = false;
                this.pnlCropped.Visible = true;
                this.divsave_crop.Attributes["class"] = "showdiv";
                return;
            }
            this.div_previewuserimg.Attributes["class"] = "showdiv";
            this.pnlCrop.Visible = false;
            this.pnlCropped.Visible = true;
            this.divsave_crop.Attributes["class"] = "showdiv";
            this.divPreview.Attributes["class"] = "hidethediv";
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            if (this.ViewState["proptionalthumb"] == null)
            {
                this.mannualcrop(200, 150, "stdthumb");
            }
            else if (this.ViewState["proptionalthumb"].ToString() == "true" && this.hdnthumbheight.Value != "0" && this.hdnthumbwidth.Value != "0")
            {
                this.mannualcrop(Convert.ToInt16(this.hdnthumbwidth.Value), Convert.ToInt16(this.hdnthumbheight.Value), "propthumb");
                this.ViewState["proptionalthumb"] = null;
                return;
            }
        }

        protected void btnlargeCrop_Click(object sender, EventArgs e)
        {
            decimal num = Convert.ToDecimal(base.Request["x2"]);
            decimal num1 = Convert.ToDecimal(base.Request["y2"]);
            decimal num2 = decimal.Round(num, 0);
            decimal num3 = decimal.Round(num1, 0);
            int num4 = Convert.ToInt32(num2);
            int num5 = Convert.ToInt32(num3);
            if (this.Pagetype.ToLower() != "user_add")
            {
                this.mannualcrop(num4, num5, "productimage");
                return;
            }
            this.mannualcrop(num4, num5, "userimage");
            this.div_previewuserimg.Attributes["class"] = "showdiv";
            this.pnlCrop.Visible = false;
            this.pnlCropped.Visible = true;
            this.divsave_crop.Attributes["class"] = "showdiv";
            this.divPreview.Attributes["class"] = "hidethediv";
        }

        protected void btnsaveimg_Click(object sender, EventArgs e)
        {
            if (this.Pagetype.ToLower() == "stripe_settings")
            {
                HttpCookie httpCookie = new HttpCookie("cke_uploadimageName");
                httpCookie["stripeUploadImgname"] = this.hdnUploadfilename.Value;
                //httpCookie["catagoryImage"] = this.hdnUpImagename.Value;
                base.Response.Cookies.Add(httpCookie);
                HttpCookie value = new HttpCookie("UploadedImageName");
                value["UploadedImageName"] = this.hdnUploadfilename.Value;
                value["t_StripeImageName"] = string.Concat("t_", this.hdnUploadfilename.Value);
                base.Response.Cookies.Add(value);
            }
            else if (this.Pagetype.ToLower() != "user_add")
            {
                HttpCookie httpCookie = new HttpCookie("cke_uploadimageName");
                httpCookie["uploadImgname"] = this.hdnUploadfilename.Value;
                httpCookie["catagoryImage"] = this.hdnUpImagename.Value;
                base.Response.Cookies.Add(httpCookie);
                HttpCookie value = new HttpCookie("UploadedImageName");
                value["UploadedImageName"] = this.hdnUploadfilename.Value;
                value["t_ProductImageName"] = string.Concat("t_", this.hdnUploadfilename.Value);
                base.Response.Cookies.Add(value);
            }
            else
            {
                HttpCookie httpCookie1 = new HttpCookie("cke_uploadimageName");
                httpCookie1["uploadImgname"] = this.hdnUploadfilename.Value;
                httpCookie1["catagoryImage"] = this.hdnUpImagename.Value;
                base.Response.Cookies.Add(httpCookie1);
                HttpCookie value1 = new HttpCookie("UploadedUserImage");
                value1["UploadedUserImage"] = this.hdnUploadfilename.Value;
                value1["m_UserImage"] = string.Concat("m_", this.hdnUploadfilename.Value);
                value1["t_UserImage"] = string.Concat("t_", this.hdnUploadfilename.Value);
                base.Response.Cookies.Add(value1);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            bool flag = false;
            if (this.Pagetype.ToLower() == "productcatalogue_item")
            {
                string[] secureDocPath = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product" };
                if (!Directory.Exists(string.Concat(secureDocPath)))
                {
                    string[] strArrays = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Product" };
                    Directory.CreateDirectory(string.Concat(strArrays));
                }
            }
            else if (this.Pagetype.ToLower() == "product_category")
            {
                string[] secureDocPath1 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory" };
                if (!Directory.Exists(string.Concat(secureDocPath1)))
                {
                    string[] strArrays1 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory" };
                    Directory.CreateDirectory(string.Concat(strArrays1));
                }
            }
            else if (this.Pagetype.ToLower() == "user_add")
            {
                string[] secureDocPath2 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//UserImageCategory" };
                if (!Directory.Exists(string.Concat(secureDocPath2)))
                {
                    string[] strArrays2 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//UserImageCategory" };
                    Directory.CreateDirectory(string.Concat(strArrays2));
                }
            }
            else if (this.Pagetype.ToLower() == "stripe_settings")
            {
                string[] secureDocPath2 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Stripe" };
                if (!Directory.Exists(string.Concat(secureDocPath2)))
                {
                    string[] strArrays2 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//Stripe" };
                    Directory.CreateDirectory(string.Concat(strArrays2));
                }
            }
            if (!this.Upload.HasFile)
            {
                this.objBase.Message_Display("Please select image", "", this.plhMessage_upload);
                this.divUploadMsg.Attributes.Add("class", "errorMsg");
                this.divUploadMsg.Attributes.Add("style", "display:block; width: 18% ;padding-left:4px;padding-right:6px");
                this.lblError.Visible = true;
                this.Err_flag = false;
                return;
            }
            string[] strArrays3 = this.Upload.FileName.ToString().Trim().Split(new char[] { '.' });
            string str = strArrays3[(int)strArrays3.Length - 1].ToString().ToLower().Trim();
            if (!(str.ToLower() == "jpg") && !(str.ToLower() == "png") && !(str.ToLower() == "tif") && !(str.ToLower() == "jpeg") && !(str.ToLower() == "bmp") && !(str.ToLower() == "jpf") && !(str.ToLower() == "gif") && !(str.ToLower() == "msp") && !(str.ToLower() == "mng") && !(str.ToLower() == "pct") && !(str.ToLower() == "yuv") && !(str.ToLower() == "tiff") && !(str.ToLower() == "mng") && !(str.ToLower() == "jfif") && !(str.ToLower() == "dib") && !(str.ToLower() == "jpe"))
            {
                this.objBase.Message_Display("Please upload valid format", "", this.plhMessage_upload);
                this.divUploadMsg.Attributes.Add("class", "errorMsg");
                this.divUploadMsg.Attributes.Add("style", "display:block; width: 25%;padding-left:4px;padding-right:6px");
                this.lblError.Visible = true;
                this.Err_flag = false;
                return;
            }
            empty = this.replacesplchar(this.Upload.FileName.ToString().Replace(" ", "_"));
            if (this.Pagetype.ToLower() == "product_category")
            {
                this.hdnUpImagename.Value = empty;
                this.catagoryImage = empty;
                if (this.categoryID != 0)
                {
                    string str1 = Guid.NewGuid().ToString();
                    str1 = str1.Replace("-", string.Empty);
                    str1 = str1.Substring(0, 5);
                    this.catagoryImage = this.catagoryImage.Replace(" ", "_");
                    object[] objArray = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory//", this.categoryID, "_", this.catagoryImage };
                    if (!File.Exists(string.Concat(objArray)))
                    {
                        this.catagoryImage = string.Concat(this.categoryID, "_", this.catagoryImage);
                    }
                    else
                    {
                        object[] objArray1 = new object[] { this.categoryID, "_", str1, this.catagoryImage };
                        this.catagoryImage = string.Concat(objArray1);
                    }
                }
                else
                {
                    this.catagoryImage = empty;
                }
                this.imgToSave = this.catagoryImage;
                this.hdnUploadfilename.Value = this.catagoryImage;
                FileUpload upload = this.Upload;
                string[] secureDocPath3 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory//", this.catagoryImage };
                upload.SaveAs(string.Concat(secureDocPath3));
                flag = true;
            }
            else if (this.Pagetype.ToLower() == "productcatalogue_item")
            {
                this.productImage = empty;
                this.hdnUpImagename.Value = empty;
                if (this.ProductCatalogueID != 0)
                {
                    string str2 = Guid.NewGuid().ToString();
                    str2 = str2.Replace("-", string.Empty);
                    str2 = str2.Substring(0, 5);
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//", this.ProductCatalogueID, "_", this.hdnUpImagename.Value };
                    if (!File.Exists(string.Concat(objArray2)))
                    {
                        this.productImage = string.Concat(this.ProductCatalogueID, "_", this.hdnUpImagename.Value);
                    }
                    else
                    {
                        object[] productCatalogueID = new object[] { this.ProductCatalogueID, "_", str2, this.hdnUpImagename.Value };
                        this.productImage = string.Concat(productCatalogueID);
                    }
                }
                else
                {
                    this.productImage = empty;
                }
                this.imgToSave = this.productImage;
                this.hdnUploadfilename.Value = this.productImage;
                FileUpload fileUpload = this.Upload;
                string[] secureDocPath4 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//", this.productImage };
                fileUpload.SaveAs(string.Concat(secureDocPath4));
                flag = true;
            }
            else if (this.Pagetype.ToLower() == "user_add")
            {
                this.hdnUpImagename.Value = empty;
                this.UserImage = empty;
                string empty1 = string.Empty;
                if (this.UserID != 0)
                {
                    string str3 = Guid.NewGuid().ToString();
                    str3 = str3.Replace("-", string.Empty);
                    str3 = str3.Substring(0, 5);
                    this.UserImage = this.UserImage.Replace(" ", "_");
                    this.UserImage = string.Concat(this.UserID, "_", this.UserImage);
                }
                else
                {
                    this.UserImage = empty;
                    string[] strArrays4 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//UserImageCategory//", this.UserImage };
                    if (!File.Exists(string.Concat(strArrays4)))
                    {
                        this.UserImage = empty;
                    }
                    else
                    {
                        int num = 1;
                        while (num < 10000)
                        {
                            empty1 = string.Concat(num, "_", this.UserImage);
                            string[] secureDocPath5 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this.CompanyID, "//UserImageCategory//", empty1 };
                            if (File.Exists(string.Concat(secureDocPath5)))
                            {
                                num++;
                            }
                            else
                            {
                                this.UserImage = empty1;
                                goto Label0;
                            }
                        }
                    }
                }
            Label0:
                this.imgToSave = this.UserImage;
                this.hdnUploadfilename.Value = this.UserImage;
                FileUpload upload1 = this.Upload;
                string[] strArrays5 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//UserImageCategory//", this.UserImage };
                upload1.SaveAs(string.Concat(strArrays5));
                flag = true;
            }
            else if (this.Pagetype.ToLower() == "stripe_settings")
            {
                this.stripeImage = empty;
                this.hdnUpImagename.Value = empty;
                    string str2 = Guid.NewGuid().ToString();
                    str2 = str2.Replace("-", string.Empty);
                    str2 = str2.Substring(0, 5);
                    object[] objArray2 = new object[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Stripe//", this.hdnUpImagename.Value };
                    this.stripeImage = this.hdnUpImagename.Value;

                this.imgToSave = this.stripeImage;
                this.hdnUploadfilename.Value = this.stripeImage;
                FileUpload fileUpload = this.Upload;
                string[] secureDocPath4 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Stripe //", this.stripeImage };
                fileUpload.SaveAs(string.Concat(secureDocPath4));
                flag = true;
            }
            if (flag)
            {
                this.lbluploadmsg.Visible = false;
                this.pnlBeforeCrop.Visible = true;
                this.div_upload.Attributes["class"] = "hidethediv";
                if (this.Pagetype.ToLower() == "productcatalogue_item")
                {
                    QueryString queryString = new QueryString()
				{
					{ "doctype", "imgcpprd" },
					{ "filename", Convert.ToString(this.productImage) }
				};
                    Encryption.EncryptQueryString(queryString);
                    this.imgCrop.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx?doctype=imgcpprd&filename=", this.productImage);
                }
                else if (this.Pagetype.ToLower() == "product_category")
                {
                    QueryString queryString1 = new QueryString()
				{
					{ "doctype", "imgcpcat" },
					{ "filename", Convert.ToString(this.catagoryImage) }
				};
                    Encryption.EncryptQueryString(queryString1);
                    this.imgCrop.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx?doctype=imgcpcat&filename=", this.catagoryImage);
                }
                else if (this.Pagetype.ToLower() == "user_add")
                {
                    QueryString queryString2 = new QueryString()
				{
					{ "doctype", "imgcpuser" },
					{ "filename", Convert.ToString(this.UserImage) }
				};
                    Encryption.EncryptQueryString(queryString2);
                    this.imgCrop.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx?doctype=imgcpuser&filename=", this.UserImage);
                }
                else if (this.Pagetype.ToLower() == "stripe_settings")
                {
                    QueryString queryString2 = new QueryString()
                {
                    { "doctype", "imgcpstripe" },
                    { "filename", Convert.ToString(this.stripeImage) }
                };
                    Encryption.EncryptQueryString(queryString2);
                    this.imgCrop.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx?doctype=imgcpuser&filename=", this.stripeImage);
                }
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Image_uploaded_succesfully"), "msg-success", this.plhMessage_upload);
                this.divUploadMsg.Attributes.Add("class", "");
                this.divUploadMsg.Attributes.Add("style", "display:block; width: 32%;");
                if (this.Pagetype.ToLower() != "user_add")
                {
                    this.divPreview.Attributes["class"] = "showdiv";
                    if (this.Pagetype.ToLower() == "productcatalogue_item" || this.Pagetype.ToLower() == "product_category")
                    {
                        this.autocrop1();
                    }
                    else
                    {
                        this.autocrop();
                    }
                }
                else
                {
                    this.div_previewuserimg.Attributes["class"] = "showdiv";
                    this.UserImageautocrop();
                }
            }
            this.UpdateProgressContext();
        }

        protected void lnkbtnCrop_Click(object sender, EventArgs e)
        {
            this.pnlCrop.Visible = true;
            this.pnlCropped.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnCrop.Visible = true;
            this.btnlargeCrop.Visible = false;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.lnkcrpproptional.Visible = true;
            this.lblcropthumbprop.Visible = true;
            string str = "thumbnail";
            this.lnkcrpproptional.Text = this.objLanguage.GetLanguageConversion("Crop_proptional");
            this.lblcropthumbprop.Text = this.hdnthumbcroptype.Value;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("test('", str, "');"), true);
        }

        protected void lnkbtnCroplarge_Click(object sender, EventArgs e)
        {
            this.pnlCrop.Visible = true;
            this.pnlCropped.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnCrop.Visible = false;
            this.btnlargeCrop.Visible = true;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.div_previewuserimg.Attributes["class"] = "hidethediv";
            string str = "largesize";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("test('", str, "');"), true);
        }

        protected void lnkcrpproptional_Click(object sender, EventArgs e)
        {
            this.pnlCrop.Visible = true;
            this.pnlCropped.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnCrop.Visible = true;
            this.btnlargeCrop.Visible = false;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.ViewState["proptionalthumb"] = "true";
            string empty = string.Empty;
            if (this.lnkcrpproptional.Text != this.objLanguage.GetLanguageConversion("Crop_default_thumbnail"))
            {
                empty = "thumbproptional";
                this.lnkcrpproptional.Text = this.objLanguage.GetLanguageConversion("Crop_default_thumbnail");
                this.lblcropthumbprop.Text = "(200*150)px";
            }
            else
            {
                empty = "thumbnail";
                this.lnkcrpproptional.Text = this.objLanguage.GetLanguageConversion("Crop_proptional");
                this.lblcropthumbprop.Text = this.hdnthumbcroptype.Value;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("test('", empty, "');"), true);
        }

        public void mannualcrop(int crpwidth, int crpheight, string croptype)
        {
            try
            {
                decimal num = Convert.ToDecimal(base.Request["x1"]);
                decimal num1 = Convert.ToDecimal(base.Request["y1"]);
                decimal num2 = decimal.Round(num, 0);
                decimal num3 = decimal.Round(num1, 0);
                int num4 = Convert.ToInt32(num2);
                int num5 = Convert.ToInt32(num3);
                decimal num6 = Convert.ToDecimal(base.Request["x2"]);
                decimal num7 = Convert.ToDecimal(base.Request["y2"]);
                decimal num8 = decimal.Round(num6, 0);
                decimal num9 = decimal.Round(num7, 0);
                int num10 = Convert.ToInt32(num8);
                int num11 = Convert.ToInt32(num9);
                Math.Min(num4, num10);
                Math.Min(num5, num11);
                int num12 = Convert.ToInt32(base.Request["wth"]);
                int num13 = 0;
                num13 = (Convert.ToInt32(base.Request["hgt"]) != 0 ? Convert.ToInt32(base.Request["hgt"]) : num12);
                string value = this.hdnUploadfilename.Value;
                string str = string.Concat(this.savepath, value);
                str.Split(new char[] { '/' });
                System.Drawing.Image image = System.Drawing.Image.FromFile(str);
                System.Drawing.Image bitmap = new Bitmap(image, num12, num13);
                Graphics graphic = Graphics.FromImage(bitmap);
                graphic.InterpolationMode = InterpolationMode.High;
                graphic.DrawImage(bitmap, 0, 0, num12, num13);
                graphic.Save();
                MemoryStream memoryStream = new MemoryStream();
                Bitmap bitmap1 = new Bitmap(num12, num13, PixelFormat.Format24bppRgb);
                bitmap1.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                bitmap1.MakeTransparent();
                Graphics graphic1 = Graphics.FromImage(bitmap1);
                graphic1.DrawImage(bitmap, new Rectangle(0, 0, num12, num13), 0, 0, num12, num13, GraphicsUnit.Pixel);
                memoryStream.Dispose();
                image.Dispose();
                using (MemoryStream memoryStream1 = new MemoryStream())
                {
                    bitmap1.Save(string.Concat(this.savepath, "temp", value), ImageFormat.Png);
                    memoryStream1.ToArray();
                    memoryStream1.Close();
                }
                int num14 = num4 - 7;
                int num15 = num5 - 2;
                int num16 = crpwidth;
                int num17 = crpheight;
                string str1 = string.Concat(this.savepath, "temp", this.hdnUploadfilename.Value);
                using (System.Drawing.Image image1 = System.Drawing.Image.FromFile(str1))
                {
                    using (Bitmap bitmap2 = new Bitmap(num16, num17, image1.PixelFormat))
                    {
                        bitmap2.SetResolution(image1.HorizontalResolution, image1.VerticalResolution);
                        using (Graphics graphic2 = Graphics.FromImage(bitmap2))
                        {
                            if (croptype.ToLower() == "stdthumb")
                            {
                                if (num16 == 200 && num17 == 150)
                                {
                                    graphic2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    graphic2.DrawImage(image1, new Rectangle(0, 0, num16, num17), new Rectangle(num14, num15, num16, num17), GraphicsUnit.Pixel);
                                    image1.Dispose();
                                    bitmap2.Save(string.Concat(this.savepath, "t_", value));
                                    Label label3 = this.Label3;
                                    object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", num16, "*", num17, ")px" };
                                    label3.Text = string.Concat(languageConversion);
                                    this.objBase.Message_Display("Thumbnail Modified succesfully", "msg-success", this.plhMessage_upload);
                                    this.divUploadMsg.Attributes.Add("class", "");
                                }
                            }
                            else if (croptype.ToLower() == "propthumb")
                            {
                                graphic2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphic2.DrawImage(image1, new Rectangle(0, 0, num16, num17), new Rectangle(num14, num15, num16, num17), GraphicsUnit.Pixel);
                                image1.Dispose();
                                bitmap2.Save(string.Concat(this.savepath, "t_", value));
                                Label label = this.Label3;
                                object[] objArray = new object[] { this.objLanguage.GetLanguageConversion("Thumb_nail"), " (", num16, "*", num17, ")px" };
                                label.Text = string.Concat(objArray);
                                this.objBase.Message_Display("Thumbnail Modified succesfully", "msg-success", this.plhMessage_upload);
                                this.divUploadMsg.Attributes.Add("class", "");
                            }
                            else if (croptype.ToLower() == "productimage")
                            {
                                graphic2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphic2.DrawImage(image1, new Rectangle(0, 0, num16, num17), new Rectangle(num14, num15, num16, num17), GraphicsUnit.Pixel);
                                image1.Dispose();
                                bitmap2.Save(string.Concat(this.savepath, "m_", value));
                                Label label1 = this.lbltextforimg300;
                                object[] languageConversion1 = new object[] { this.objLanguage.GetLanguageConversion("Large_Image"), " (", crpwidth, "*", crpheight, ")px" };
                                label1.Text = string.Concat(languageConversion1);
                                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Image_Modified_succesfully"), "msg-success", this.plhMessage_upload);
                                this.divUploadMsg.Attributes.Add("class", "");
                            }
                            else if (croptype.ToLower() == "userimage")
                            {
                                graphic2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphic2.DrawImage(image1, new Rectangle(0, 0, num16, num17), new Rectangle(num14, num15, num16, num17), GraphicsUnit.Pixel);
                                image1.Dispose();
                                string str2 = string.Concat(this.savepath, "m_", value);
                                bitmap2.Save(str2);
                                System.Drawing.Image image2 = null;
                                System.Drawing.Image image3 = System.Drawing.Image.FromFile(str2);
                                image2 = createImageThumnail.FixedSize(str2, image3, 28, 28, false);
                                image2.Save(string.Concat(this.savepath, "t_", value));
                                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Image_Modified_succesfully"), "msg-success", this.plhMessage_upload);
                                this.divUploadMsg.Attributes.Add("class", "");
                            }
                        }
                    }
                }
                if (File.Exists(str1))
                {
                    File.Delete(str1);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            this.pnlCrop.Visible = false;
            this.pnlCropped.Visible = true;
            if (this.Pagetype.ToLower() == "productcatalogue_item")
            {
                QueryString queryString = new QueryString()
			{
				{ "doctype", "imgcpprd" },
				{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
			};
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim());
                QueryString queryString2 = new QueryString();
                queryString.Add("doctype", "imgcpprd");
                queryString.Add("filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)));
                QueryString queryString3 = Encryption.EncryptQueryString(queryString);
                this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
            }
            else if (this.Pagetype.ToLower() == "product_category")
            {
                QueryString queryString4 = new QueryString()
			{
				{ "doctype", "imgcpcat" },
				{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
			};
                QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                this.imgthumbnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString5.ToString().Trim());
                QueryString queryString6 = new QueryString();
                queryString4.Add("doctype", "imgcpcat");
                queryString4.Add("filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)));
                QueryString queryString7 = Encryption.EncryptQueryString(queryString4);
                this.img300preview.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString7.ToString().Trim());
            }
            this.btnsaveimg.Visible = true;
            this.divPreview.Attributes["class"] = "showdiv";
            this.divsave_crop.Attributes["class"] = "showdiv";
            this.lbluploadmsg.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnUpload.Text = this.objLanguage.GetLanguageConversion("Upload");
            this.lnkbtnCrop.Text = this.objLanguage.GetLanguageConversion("Crop");
            this.lnkbtnCroplarge.Text = this.objLanguage.GetLanguageConversion("Crop");
            this.btnsaveimg.Text = this.objLanguage.GetLanguageConversion("Confirm_Save");
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnCrop.Text = this.objLanguage.GetLanguageConversion("Crop");
            if (this.Session["email"] == null)
            {
                base.Response.Redirect("error.aspx");
            }
            if (!base.IsPostBack)
            {
                this.lbluploadmsg.Visible = true;
                RadProgressArea radProgressArea1 = this.RadProgressArea1;
                radProgressArea1.ProgressIndicators = radProgressArea1.ProgressIndicators & (ProgressIndicators.TotalProgressBar | ProgressIndicators.TotalProgress | ProgressIndicators.TotalProgressPercent | ProgressIndicators.RequestSize | ProgressIndicators.FilesCountBar | ProgressIndicators.FilesCount | ProgressIndicators.FilesCountPercent | ProgressIndicators.CurrentFileName | ProgressIndicators.TimeElapsed | ProgressIndicators.TimeEstimated | ProgressIndicators.TransferSpeed);
                this.hdnUploadfilename.Value = "";
            }
            if (this.Session["CompanyID"] != null)
            {
                this.CompanyID = this.Session["CompanyID"].ToString();
            }
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (ConnectionClass.SecureVirtualPath != null)
            {
                this.SecureVirtualPath = ConnectionClass.SecureVirtualPath;
            }
            if (base.Request.Url.ToString().ToLower().Contains("from=product_category"))
            {
                this.Pagetype = "product_category";
                string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//ProductCatalogueCategory//" };
                this.savepath = string.Concat(secureDocPath);
                if (base.Request.Params["catagoryID"] != null)
                {
                    if (base.Request.Params["catagoryID"] != "add")
                    {
                        this.categoryID = Convert.ToInt32(base.Request.Params["catagoryID"]);
                    }
                    else
                    {
                        this.categoryID = 0;
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("from=productcatalogue_item"))
            {
                this.Pagetype = "ProductCatalogue_item";
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Product//" };
                this.savepath = string.Concat(strArrays);
                this.div_preview300.Attributes["class"] = "showdiv";
                if (base.Request.Params["ProductCatalogueID"] != null)
                {
                    if (base.Request.Params["ProductCatalogueID"] != "add")
                    {
                        this.ProductCatalogueID = Convert.ToInt32(base.Request.Params["ProductCatalogueID"]);
                    }
                    else
                    {
                        this.ProductCatalogueID = 0;
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("from=settings/user_add"))
            {
                this.Pagetype = "User_Add";
                this.hdnPagetype.Value = this.Pagetype.ToLower();
                string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//UserImageCategory//" };
                this.savepath = string.Concat(secureDocPath1);
                this.div_preview300.Attributes["class"] = "showdiv";
                if (base.Request.Params["userid"] != null)
                {
                    if (base.Request.Params["userid"] != "add")
                    {
                        this.UserID = Convert.ToInt32(base.Request.Params["userid"]);
                    }
                    else
                    {
                        this.UserID = 0;
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("user_add"))
            {
                this.Pagetype = "User_Add";
                this.hdnPagetype.Value = this.Pagetype.ToLower();
                string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//UserImageCategory//" };
                this.savepath = string.Concat(secureDocPath1);
                this.div_preview300.Attributes["class"] = "showdiv";
                if (base.Request.Params["userid"] != null)
                {
                    if (base.Request.Params["userid"] != "add")
                    {
                        this.UserID = Convert.ToInt32(base.Request.Params["userid"]);
                    }
                    else
                    {
                        this.UserID = 0;
                    }
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("stripe"))
            {
                    this.Pagetype = "stripe_settings";
                    string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "//", this.CompanyID, "//Stripe//" };
                    this.savepath = string.Concat(secureDocPath);
                
            }
            this.RadProgressArea1.Localization.UploadedFiles = "Progress";
            this.RadProgressArea1.Localization.CurrentFileName = "Image Upload Progress: ";
            this.divPreview.Attributes["class"] = "hidethediv";
            this.divsave_crop.Attributes["class"] = "hidethediv";
            this.path = string.Concat(global.filePath(), "images/");
        }

        private string replacesplchar(string inputstring)
        {
            string empty = string.Empty;
            return (new Regex("[;\\\\/:*?\"<>|&'@#+^!%~`$,]")).Replace(inputstring, "_");
        }

        private void UpdateProgressContext()
        {
            RadProgressContext current = RadProgressContext.Current;
            current.Speed = "N/A";
            for (int i = 0; i < 100; i++)
            {
                current.SecondaryTotal = 100;
                current.SecondaryValue = i;
                current.SecondaryPercent = i;
                current.CurrentOperationText = string.Concat(i.ToString(), "%");
                if (!base.Response.IsClientConnected)
                {
                    return;
                }
                current.TimeEstimated = (100 - i) * 100;
                Thread.Sleep(8);
            }
        }

        public void UserImageautocrop()
        {
            System.Drawing.Image image = null;
            System.Drawing.Image image1 = null;
            UploadAndCrop.OrigFile_image = string.Concat(this.savepath, this.hdnUploadfilename.Value);
            int num = 28;
            int num1 = 28;
            int num2 = 100;
            int num3 = 100;
            try
            {
                System.Drawing.Image image2 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                double num4 = Convert.ToDouble(image2.Height);
                double num5 = Convert.ToDouble(image2.Width);
                double height = 0;
                double width = 0;
                double num6 = 0;
                double num7 = 0;
                if (num4 < 100)
                {
                    height = Convert.ToDouble(image2.Height);
                }
                if (num5 >= 100)
                {
                    height = (double)(image2.Height * num2 / image2.Width);
                    width = (double)num2;
                    if (height > (double)num3)
                    {
                        width = (double)(image2.Width * num3 / image2.Height);
                        height = (double)num3;
                    }
                }
                else
                {
                    width = Convert.ToDouble(image2.Width);
                }
                Label label = this.lbltextdimension;
                object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("User_Image"), " (", width, "*", height, ")px" };
                label.Text = string.Concat(languageConversion);
                this.imgcropheightprop = Convert.ToString(Math.Round(Convert.ToDouble(height), 0));
                Convert.ToString(Math.Round(Convert.ToDouble(width), 0));
                string str = Convert.ToString(num4);
                string str1 = Convert.ToString(num5);
                num7 = (Convert.ToInt16(str) <= 28 ? Convert.ToDouble(num4) : 28);
                this.hdnthumbheight.Value = Convert.ToString(num7);
                num6 = (Convert.ToInt16(str1) <= 28 ? Convert.ToDouble(num5) : 28);
                this.hdnthumbwidth.Value = Convert.ToString(num6);
                if (image2.Width >= 28 || image2.Height >= 28)
                {
                    System.Drawing.Image image3 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image3, num, num1, false);
                    image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    image3.Dispose();
                    image.Dispose();
                    GC.Collect();
                    if (this.Pagetype.ToLower() == "user_add")
                    {
                        QueryString queryString = new QueryString()
					{
						{ "doctype", "imgcpuser" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                        this.imgUserimagethumnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString1.ToString().Trim());
                    }
                }
                else
                {
                    System.Drawing.Image image4 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    image = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image4, image2.Width, image2.Height, false);
                    image.Save(string.Concat(this.savepath, "\\t_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    image4.Dispose();
                    image.Dispose();
                    GC.Collect();
                    string empty = string.Empty;
                    if (this.Pagetype.ToLower() == "user_add")
                    {
                        QueryString queryString2 = new QueryString()
					{
						{ "doctype", "imgcpuser" },
						{ "filename", Convert.ToString(string.Concat("t_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString3 = Encryption.EncryptQueryString(queryString2);
                        this.imgUserimagethumnail.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString3.ToString().Trim());
                    }
                }
                if (image2.Width >= 100 || image2.Height >= 100)
                {
                    System.Drawing.Image image5 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image5, num2, num3, false);
                    image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    image5.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    if (this.Pagetype.ToLower() == "user_add")
                    {
                        QueryString queryString4 = new QueryString()
					{
						{ "doctype", "imgcpuser" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString5 = Encryption.EncryptQueryString(queryString4);
                        this.imgUserimage.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString5.ToString().Trim());
                    }
                }
                else
                {
                    System.Drawing.Image image6 = System.Drawing.Image.FromFile(UploadAndCrop.OrigFile_image);
                    image1 = createImageThumnail.FixedSize(UploadAndCrop.OrigFile_image, image6, image2.Width, image2.Height, false);
                    image1.Save(string.Concat(this.savepath, "\\m_", this.hdnUploadfilename.Value), ImageFormat.Png);
                    image6.Dispose();
                    image1.Dispose();
                    GC.Collect();
                    image2.Dispose();
                    if (this.Pagetype.ToLower() == "user_add")
                    {
                        QueryString queryString6 = new QueryString()
					{
						{ "doctype", "imgcpuser" },
						{ "filename", Convert.ToString(string.Concat("m_", this.hdnUploadfilename.Value)) }
					};
                        QueryString queryString7 = Encryption.EncryptQueryString(queryString6);
                        this.imgUserimage.ImageUrl = string.Concat(this.strSitePath, "DocManager.ashx", queryString7.ToString().Trim());
                    }
                }
            }
            catch (Exception exception)
            {
            }
            this.pnlCropped.Visible = true;
            this.pnlCrop.Visible = false;
            this.pnlBeforeCrop.Visible = true;
            this.btnsaveimg.Visible = true;
            this.div_upload.Attributes["class"] = "hidethediv";
            this.divsave_crop.Attributes["class"] = "showdiv";
        }
    }
}