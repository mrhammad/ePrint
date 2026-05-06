using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using Telerik.Web.UI.ImageEditor;
using TemplateEditor;

namespace HTML5TemplateEditor
{
    public partial class editableproduct : System.Web.UI.Page, IRequiresSessionState
    {
        public static GlobalVariables _ObjGlobalVariables;

        public long globalCID;

        public static string ImageUploadPath;

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

        static editableproduct()
        {
            editableproduct._ObjGlobalVariables = new GlobalVariables();
        }

        public editableproduct()
        {
        }

        [WebMethod]
        public static string assignToTemplateFolrder(string originalFilename, string sourcepath, string savepath)
        {
            byte[] numArray;
            try
            {
                numArray = File.ReadAllBytes(string.Concat(sourcepath, "/", originalFilename));
            }
            catch
            {
                numArray = File.ReadAllBytes(string.Concat(savepath, "/", originalFilename));
            }
            Image image = Image.FromStream(new MemoryStream(numArray));
            if (!File.Exists(string.Concat(savepath, originalFilename)))
            {
                if (!Directory.Exists(savepath))
                {
                    try
                    {
                        Directory.CreateDirectory(savepath);
                    }
                    catch
                    {
                    }
                }
                image.Save(string.Concat(savepath, originalFilename));
            }
            if (!File.Exists(string.Concat(sourcepath, "/", originalFilename)))
            {
                if (!Directory.Exists(sourcepath))
                {
                    try
                    {
                        Directory.CreateDirectory(sourcepath);
                    }
                    catch
                    {
                    }
                }
                image.Save(string.Concat(sourcepath, "/", originalFilename));
            }
            return originalFilename;
        }

        [WebMethod]
        public static string checkImageForDPI(string OriginalImageName, string isEdited, string ImageUploadPath, string CompanyID, string minDPI)
        {
            int num = Convert.ToInt32(minDPI);
            string str = string.Concat(ImageUploadPath, CompanyID, "/Images/Gallery/OriginalImages");
            if (isEdited == "true")
            {
                str = string.Concat(GlobalVariables.SitePathPahysical, OriginalImageName);
            }
            if ((int)Image.FromFile(string.Concat(str, "\\", OriginalImageName)).HorizontalResolution >= num)
            {
                return "success";
            }
            return "error";
        }

        [WebMethod]
        public static string fitTheImageTocontroll(string OriginalImageName, string widthOfControll, string HeightOfControll, string zoom, string objcetID, string isEdited, string ImageUploadPath, string CompanyID, string _isCropFromTop)
        {
            string str = string.Concat(ImageUploadPath, CompanyID, "/Images/Gallery/OriginalImages");
            string str1 = string.Concat(ImageUploadPath, CompanyID, "/Images");
            byte[] numArray = null;
            if (isEdited.ToLower() == "true")
            {
                numArray = File.ReadAllBytes(string.Concat(GlobalVariables.SitePathPahysical, OriginalImageName));
                editableproduct.assignToTemplateFolrder(OriginalImageName, GlobalVariables.SitePathPahysical, string.Concat(str1, "\\"));
            }
            else if (OriginalImageName == "noimage.png" || OriginalImageName == "noimage.jpg")
            {
                str = string.Concat(HttpContext.Current.Server.MapPath("~"), "\\StyleSheets\\Images");
                numArray = File.ReadAllBytes(string.Concat(str, "/", OriginalImageName));
                editableproduct.assignToTemplateFolrder(OriginalImageName, str, string.Concat(str1, "\\"));
            }
            else
            {
                try
                {
                    numArray = File.ReadAllBytes(string.Concat(str, "/", OriginalImageName));
                    editableproduct.assignToTemplateFolrder(OriginalImageName, str, string.Concat(str1, "\\"));
                }
                catch
                {
                    numArray = File.ReadAllBytes(string.Concat(str1, "/", OriginalImageName));
                    editableproduct.assignToTemplateFolrder(OriginalImageName, GlobalVariables.SitePathPahysical, string.Concat(str1, "\\"));
                }
            }
            Image image = Image.FromStream(new MemoryStream(numArray));
            string str2 = "";
            if (isEdited != "true")
            {
                str2 = (_isCropFromTop.ToLower() != "true" ? createThumbnail.CreateProportionalImage(image, string.Concat(str, "/"), string.Concat(str1, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, false, Convert.ToDouble(zoom), true) : createThumbnail.CreateProportionalImageIsCropFromTop(image, string.Concat(str, "/"), string.Concat(str1, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, false, Convert.ToDouble(zoom), true));
            }
            else
            {
                str2 = (_isCropFromTop.ToLower() != "true" ? createThumbnail.CreateProportionalImage(image, GlobalVariables.SitePathPahysical, string.Concat(str, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, true, Convert.ToDouble(zoom), true) : createThumbnail.CreateProportionalImageIsCropFromTop(image, GlobalVariables.SitePathPahysical, string.Concat(str1, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, true, Convert.ToDouble(zoom), true));
            }
            string[] strArrays = str2.Split(new char[] { '~' });
            string[] strArrays1 = new string[] { strArrays[0], "~", objcetID, "~", OriginalImageName, "~", strArrays[1], "~", strArrays[2] };
            return string.Concat(strArrays1);
        }

        [WebMethod]
        public static Globals LoadSitePath(string Querystring)
        {
            List<QueryStringPara> decriptedQuerySting = (new TemplateEditorService()).GetDecriptedQuerySting(Querystring);
            GlobalSitePaths globalSitePath = new GlobalSitePaths();
            editableproduct._ObjGlobalVariables.CompanyID = Convert.ToInt64(decriptedQuerySting[0].CompanyID);
            Globals sitePaths = globalSitePath.GetSitePaths(Convert.ToInt64(decriptedQuerySting[0].CompanyID), decriptedQuerySting[0].dbKey);
            editableproduct.ImageUploadPath = sitePaths.ImageUploadPath;
            sitePaths.TemplateID = decriptedQuerySting[0].TemplateID;
            sitePaths.CompanyID = decriptedQuerySting[0].CompanyID;
            sitePaths.UserID = decriptedQuerySting[0].UserID;
            sitePaths.PriceCatalogId = decriptedQuerySting[0].PriceCatalogId;
            return sitePaths;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RadImgEdt_ImageSaving(object sender, ImageEditorSavingEventArgs args)
        {
            string str = string.Concat(editableproduct.ImageUploadPath, editableproduct._ObjGlobalVariables.CompanyID, "/Images");
            if (!Directory.Exists(str))
            {
                try
                {
                    Directory.CreateDirectory(str);
                }
                catch
                {
                }
            }
            GlobalVariables.SitePathPahysical = string.Concat(str, "\\");
            EditableImage image = args.Image;
            image.Image.Save(string.Concat(str, "\\", args.FileName));
            args.Cancel = true;
        }
    }
}