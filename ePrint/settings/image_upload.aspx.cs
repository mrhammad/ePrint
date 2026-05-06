using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsConnectionClass;
using RemovingWhiteSpacesAspNet;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace ePrint.settings
{
    public partial class image_upload : System.Web.UI.Page, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private double Resolution;

        private int error;

        protected string strSitepath = global.sitePath();

        protected string strImagepath = global.imagePath();

        public int FinalWidth;

        public int FinalHeight;

        public string crop = string.Empty;

        public string CropImgPath = string.Empty;

        public string Mode = string.Empty;

        private createImageThumnail objImg = new createImageThumnail();

        public string SecureDocPath = global.SecureDocPath();

        public string SecureSitePath = global.SecureSitePath();

        public string SecureDocFilePath = global.SecureDocFilepath();

        public string ServerName = string.Empty;

        public long CompanyID;

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

        public image_upload()
        {
        }

        protected void btnContinue_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.rdllstimgAction.Items.Count; i++)
            {
                string value = this.hid_FileName.Value;
                if (this.rdllstimgAction.Items[i].Selected)
                {
                    if (this.rdllstimgAction.Items[i].Value == "retain")
                    {
                        string[] secureDocFilePath = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", value };
                        string str = string.Concat(secureDocFilePath);
                        string[] strArrays = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", value };
                        string.Concat(strArrays);
                        int num = 300;
                        int num1 = 100;
                        try
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile(str);
                            this.FinalWidth = image.Width;
                            this.FinalHeight = image.Height;
                            image.Dispose();
                            GC.Collect();
                        }
                        catch (Exception exception)
                        {
                            this.FinalWidth = num;
                            this.FinalHeight = num1;
                            this.hid_FileName.Value = "Eprint_logo1.jpg";
                        }
                        this.hid_FileName.Value = value;
                        this.pnlWinClose.Visible = true;
                    }
                    else if (this.rdllstimgAction.Items[i].Value != "resize")
                    {
                        HttpResponse response = base.Response;
                        string[] mode = new string[] { this.strSitepath, "settings/image_upload.aspx?mode=", this.Mode, "&crop=yes&img=", this.hid_FileName.Value };
                        response.Redirect(string.Concat(mode));
                    }
                    else
                    {
                        System.Drawing.Image image1 = null;
                        string[] secureDocFilePath1 = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", value };
                        string str1 = string.Concat(secureDocFilePath1);
                        value = string.Concat("t_", value);
                        string[] strArrays1 = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", value };
                        string str2 = string.Concat(strArrays1);
                        int num2 = 300;
                        int num3 = 100;
                        try
                        {
                            System.Drawing.Image image2 = System.Drawing.Image.FromFile(str1);
                            image1 = createImageThumnail.FixedSize(str1, image2, num2, num3, true, str2);
                            this.FinalWidth = num2;
                            this.FinalHeight = num3;
                            image2.Dispose();
                            image1.Dispose();
                            GC.Collect();
                        }
                        catch (Exception exception1)
                        {
                            this.FinalWidth = num2;
                            this.FinalHeight = num3;
                            this.hid_FileName.Value = "Eprint_logo1.jpg";
                        }
                        this.hid_FileName.Value = value;
                        this.pnlWinClose.Visible = true;
                    }
                }
            }
        }

        protected void btnCropCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/image_upload.aspx?mode=", this.Mode));
        }

        protected void btnSaveCropImg_OnClick(object sender, EventArgs e)
        {
            string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "\\", this.Session["companyid"].ToString(), "\\", base.Request.Params["img"].ToString() };
            string str = string.Concat(secureDocPath);
            string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "\\", this.Session["companyid"].ToString(), "\\new_", base.Request.Params["img"].ToString() };
            string str1 = string.Concat(strArrays);
            try
            {
                this.objImg.corpImagesJavascript(str, str1, Convert.ToInt32(this.x1.Value), Convert.ToInt32(this.y1.Value), Convert.ToInt32(this.width.Value), Convert.ToInt32(this.height.Value));
                GC.Collect();
                this.FinalWidth = Convert.ToInt32(this.width.Value);
                this.FinalHeight = Convert.ToInt32(this.height.Value);
                this.hid_FileName.Value = string.Concat("new_", base.Request.Params["img"].ToString());
                this.pnlWinClose.Visible = true;
            }
            catch
            {
                System.Drawing.Image image = null;
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(str);
                this.FinalWidth = image1.Width;
                this.FinalHeight = image1.Height;
                image = createImageThumnail.FixedSize(str, image1, image1.Width, image1.Height, true, str1);
                image1.Dispose();
                image.Save(str1, ImageFormat.Jpeg);
                image.Dispose();
                GC.Collect();
                this.hid_FileName.Value = string.Concat("new_", base.Request.Params["img"].ToString());
                this.pnlWinClose.Visible = true;
            }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            string str = this.File1.FileName.Replace('&', '\u00A7');
            string str1 = Guid.NewGuid().ToString();
            str1 = str1.Replace("-", string.Empty);
            str1 = str1.Substring(0, 5);
            str = string.Concat(str1, "_", str.Replace(" ", "_"));
            string empty = string.Empty;
            if (this.File1.HasFile)
            {
                string[] strArrays = this.File1.FileName.ToString().Trim().Split(new char[] { '.' });
                strArrays[(int)strArrays.Length - 1].ToString().ToLower().Trim();
                long length = this.File1.FileContent.Length;
                this.hid_FileName.Value = str;
                FileUpload file1 = this.File1;
                string[] secureDocFilePath = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", str };
                file1.SaveAs(string.Concat(secureDocFilePath));
                System.Drawing.Image image = null;
                string[] secureDocFilePath1 = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", str };
                string str2 = string.Concat(secureDocFilePath1);
                string[] strArrays1 = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", str };
                string str3 = string.Concat(strArrays1);
                int num = 300;
                int num1 = 100;
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(str2);
                this.Resolution = (double)image1.HorizontalResolution;
                image1.Dispose();
                if (Convert.ToInt32(this.Resolution) > 0 && Convert.ToInt32(this.Resolution) < 200)
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "__showConfirm11111", ";CheckResolution();", true);
                    this.error = Convert.ToInt16(this.hid_UpType.Value);
                }
                if (this.error == 0)
                {
                    for (int i = 0; i < this.rdllstimgAction.Items.Count; i++)
                    {
                        if (this.rdllstimgAction.Items[i].Selected)
                        {
                            if (this.rdllstimgAction.Items[i].Value == "retain")
                            {
                                try
                                {
                                    System.Drawing.Image image2 = System.Drawing.Image.FromFile(str2);
                                    this.FinalWidth = image2.Width;
                                    this.FinalHeight = image2.Height;
                                    image2.Dispose();
                                    GC.Collect();
                                }
                                catch (Exception exception)
                                {
                                    this.FinalWidth = num;
                                    this.FinalHeight = num1;
                                    this.hid_FileName.Value = "Eprint_logo1.jpg";
                                }
                                this.pnlWinClose.Visible = true;
                            }
                            else if (this.rdllstimgAction.Items[i].Value != "resize")
                            {
                                HttpResponse response = base.Response;
                                string[] mode = new string[] { this.strSitepath, "settings/image_upload.aspx?mode=", this.Mode, "&crop=yes&img=", str };
                                response.Redirect(string.Concat(mode));
                            }
                            else
                            {
                                try
                                {
                                    str = string.Concat("t_", str);
                                    string[] secureDocFilePath2 = new string[] { this.SecureDocFilePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", str };
                                    str3 = string.Concat(secureDocFilePath2);
                                    System.Drawing.Image image3 = System.Drawing.Image.FromFile(str2);
                                    image = createImageThumnail.FixedSize(str2, image3, num, num1, true, str3);
                                    this.FinalWidth = num;
                                    this.FinalHeight = num1;
                                    image3.Dispose();
                                    image.Save(str3, ImageFormat.Jpeg);
                                    image.Dispose();
                                    GC.Collect();
                                }
                                catch (Exception exception1)
                                {
                                    this.FinalWidth = num;
                                    this.FinalHeight = num1;
                                    this.hid_FileName.Value = "Eprint_logo1.jpg";
                                }
                                this.pnlWinClose.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Session["companyid"])))
            {
                (new BaseClass()).Session_Check();
            }
            this.CompanyID = Convert.ToInt64(this.Session["companyid"]);
            this.gloobj.setpagename("estimate");
            this.Mode = base.Request.Params["mode"].ToString();
            if (ConnectionClass.ServerName != null)
            {
                this.ServerName = ConnectionClass.ServerName;
            }
            if (!base.IsPostBack && base.Request.Params["crop"] != null)
            {
                this.crop = base.Request.Params["crop"].ToString();
                string str = base.Request.Params["img"].ToString();
                this.div_img.Style.Add("display", "block");
                this.div_Upload.Style.Add("display", "none");
                System.Drawing.Image image = null;
                string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "\\", this.Session["companyid"].ToString(), "\\", str };
                string str1 = string.Concat(secureDocPath);
                string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "\\", this.Session["companyid"].ToString(), "\\", str };
                string str2 = string.Concat(strArrays);
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(str1);
                if (image1.Width > 500 && image1.Height > 400)
                {
                    int num = 500;
                    int num1 = 400;
                    image = createImageThumnail.FixedSize(str1, image1, num, num1, true, str2);
                    image1.Dispose();
                    image.Save(str2, ImageFormat.Jpeg);
                    image.Dispose();
                    GC.Collect();
                }
                string[] secureSitePath = new string[] { this.SecureSitePath, this.ServerName, "/", this.Session["companyid"].ToString(), "/", str };
                this.CropImgPath = string.Concat(secureSitePath);
                this.imgPhoto.Src = this.CropImgPath;
                this.hid_FileName.Value = this.CropImgPath;
            }
        }
    }
}