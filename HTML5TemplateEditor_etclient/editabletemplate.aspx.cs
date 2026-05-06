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
using TemplateEditorFrontEnd;

namespace HTML5TemplateEditor_etclient
{
    public partial class editabletemplate : System.Web.UI.Page, IRequiresSessionState
    {
        //protected HtmlTableCell editor;

        //protected System.Web.UI.ScriptManager RadScriptManager1;

        //protected RadImageEditor RadImageEditor1;

        //protected HtmlForm form;

        private static GlobalVariables _ObjGlobalVariables;

        public static string UserImageUploadPath;

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

        static editabletemplate()
        {
            editabletemplate._ObjGlobalVariables = new GlobalVariables();
        }

        public editabletemplate()
        {
        }

        [WebMethod]
        public static string assignToTemplateFolrder(string originalFilename, string sourcepath, string savepath)
        {
            byte[] numArray = File.ReadAllBytes(string.Concat(sourcepath, "/", originalFilename));
            Image image = Image.FromStream(new MemoryStream(numArray));
            if (File.Exists(string.Concat(savepath, originalFilename)))
            {
                return originalFilename;
            }
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
            return originalFilename;
        }

        [WebMethod]
        public static string checkImageForDPI(string OriginalImageName, string isEdited, string ischecked, string isfrombackend, string BackEndPath, string ImageUploadPath, string TemplateID, string UserID, string CompanyID, string iscropfromtop, string minDPI)
        {
            int num = Convert.ToInt32(minDPI);
            string userImageUploadPath = string.Concat(ImageUploadPath, "UsersImages/", UserID, "/Gallery/OriginalImages");
            if (ischecked == "false")
            {
                userImageUploadPath = string.Concat(ImageUploadPath, TemplateID, "/Images");
            }
            if (isfrombackend == "true")
            {
                userImageUploadPath = string.Concat(BackEndPath, CompanyID, "/Images//Gallery/OriginalImages");
            }
            char[] chrArray = new char[] { '.' };
            if (OriginalImageName.Split(chrArray)[1].ToLower() == "pdf")
            {
                char[] chrArray1 = new char[] { '.' };
                OriginalImageName = string.Concat(OriginalImageName.Split(chrArray1)[0], ".png");
                userImageUploadPath = string.Concat(ImageUploadPath, "UsersImages/", UserID, "/Gallery/OriginalImages");
            }
            if (isEdited == "true")
            {
                userImageUploadPath = editabletemplate.UserImageUploadPath;
            }
            if ((int)Image.FromFile(string.Concat(userImageUploadPath, "\\", OriginalImageName)).HorizontalResolution >= num)
            {
                return "success";
            }
            return "error";
        }

        [WebMethod]
        public static string fitTheImageTocontroll(string OriginalImageName, string widthOfControll, string HeightOfControll, string zoom, string objcetID, string isEdited, string ischecked, string isfrombackend, string TemplateID, string BackEndPath, string ImageUploadPath, string UserID, string CompanyID, string iscropfromtop
            , string dbKey, string securePath, string priceCatalogId)
        {
            string str = string.Concat(ImageUploadPath, "UsersImages/", UserID, "/Gallery/OriginalImages");
            if (ischecked == "false")
            {
                str = string.Concat(ImageUploadPath, TemplateID, "/Images");
            }
            if (isfrombackend == "true")
            {
                str = string.Concat(BackEndPath, CompanyID, "/Images/Gallery/OriginalImages");
            }
            char[] chrArray = new char[] { '.' };
            if (OriginalImageName.Split(chrArray)[1].ToLower() == "pdf")
            {
                char[] chrArray1 = new char[] { '.' };
                OriginalImageName = string.Concat(OriginalImageName.Split(chrArray1)[0], ".png");
                str = string.Concat(ImageUploadPath, "UsersImages/", UserID, "/Gallery/OriginalImages");
            }
            string str1 = string.Concat(ImageUploadPath, TemplateID, "/Images");
            byte[] numArray = null;
            if (isEdited != "true")
            {
                try
                {
                    numArray = File.ReadAllBytes(string.Concat(str, "/", OriginalImageName));
                }
                catch
                {
                    str = string.Concat(BackEndPath, CompanyID, "/Images");
                    numArray = File.ReadAllBytes(string.Concat(str, "/", OriginalImageName));
                }
                if (!string.IsNullOrEmpty(securePath)) // Additional check related to store.
                {
                    SaveAndUpdateImageForEditableProduct(securePath, CompanyID, dbKey, OriginalImageName, objcetID, numArray, OriginalImageName, priceCatalogId);
                }

                editabletemplate.assignToTemplateFolrder(OriginalImageName, str, string.Concat(str1, "\\"));
            }
            else
            {
                str = (!File.Exists(string.Concat(editabletemplate.UserImageUploadPath, OriginalImageName)) ? string.Concat(str, "/") : editabletemplate.UserImageUploadPath);
                numArray = File.ReadAllBytes(string.Concat(str, OriginalImageName));
                editabletemplate.assignToTemplateFolrder(OriginalImageName, str, string.Concat(str1, "\\"));
            }
            if (!Directory.Exists(str1))
            {
                try
                {
                    Directory.CreateDirectory(str1);
                }
                catch
                {
                }
            }
            GC.Collect();
            Image image = Image.FromStream(new MemoryStream(numArray));
            string str2 = "";
            if (iscropfromtop.ToLower() == "false")
            {
                str2 = createThumbnail.CreateProportionalImage(image, string.Concat(str, "/"), string.Concat(str1, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, false, Convert.ToDouble(zoom), false);
            }
            else if (iscropfromtop.ToLower() == "true")
            {
                str2 = createThumbnail.CreateProportionalImageIsCropFromTop(image, string.Concat(str, "/"), string.Concat(str1, "/"), OriginalImageName, Convert.ToInt32(widthOfControll), Convert.ToInt32(HeightOfControll), (double)image.Width, (double)image.Height, true, Convert.ToDouble(zoom), true);
            }
            string[] strArrays = str2.Split(new char[] { '~' });
            if ((int)strArrays.Length != 4)
            {
                string[] strArrays1 = new string[] { strArrays[0], "~", objcetID, "~", OriginalImageName, "~", strArrays[1], "~", strArrays[2] };
                return string.Concat(strArrays1);
            }
            string[] strArrays2 = new string[] { strArrays[0], "~", objcetID, "~", OriginalImageName, "~", strArrays[1], "~", strArrays[2], "~", strArrays[3] };
            return string.Concat(strArrays2);
        }

        [WebMethod]
        public static Globals LoadSitePath(string Querystring)
        {
            GlobalSitePaths globalSitePath = new GlobalSitePaths();
            List<QueryStringPara> decriptedQuerySting = (new TemplateEditorFrontEndSevice()).GetDecriptedQuerySting(Querystring);
            Globals sitePaths = globalSitePath.GetSitePaths(decriptedQuerySting[0].CompanyID, decriptedQuerySting[0].dbKey);
            object[] frontEndUploadPath = new object[] { sitePaths.FrontEndUploadPath, "UsersImages/", decriptedQuerySting[0].StoreUserID, "/Gallery/OriginalImages/" };
            editabletemplate.UserImageUploadPath = string.Concat(frontEndUploadPath);
            sitePaths.CompanyID = decriptedQuerySting[0].CompanyID;
            sitePaths.UserID = decriptedQuerySting[0].StoreUserID;
            sitePaths.CartitemID = decriptedQuerySting[0].CartItemID;
            sitePaths.SesionID = decriptedQuerySting[0].SessionID;
            sitePaths.TemplateID = decriptedQuerySting[0].TemplateID;
            sitePaths.PriceCatalogId = decriptedQuerySting[0].PriceCatalogId;
            sitePaths.CType = decriptedQuerySting[0].Type;
            sitePaths.AccountID = decriptedQuerySting[0].AccountID;
            return sitePaths;
        }

        [WebMethod]
        public static TemplateDetails LoadTemplateToPage(string templateid, string _key)
        {
            return (new TemplateEditorFrontEndSevice()).LoadTemplateDetails(templateid, _key);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RadImgEdt_ImageSaving(object sender, ImageEditorSavingEventArgs args)
        {
            string userImageUploadPath = editabletemplate.UserImageUploadPath;
            if (!Directory.Exists(userImageUploadPath))
            {
                try
                {
                    Directory.CreateDirectory(userImageUploadPath);
                }
                catch
                {
                }
            }
            GlobalVariables.SitePathPahysical = string.Concat(userImageUploadPath, "\\");
            EditableImage image = args.Image;
            image.Image.Save(string.Concat(userImageUploadPath, "\\", args.FileName));
            args.Cancel = true;
        }

        #region Private Custom Methods
        static void SaveAndUpdateImageForEditableProduct(string securePath, string CompanyID, string dbKey, string fileName, string selectedObjectID,
            byte[] numArray, string OriginalImageName, string productId)
        {
            bool isImageSaved = true;
            string attachmentsPathDestination = string.Concat(securePath, CompanyID, "/", "attachments");
            try
            {
                // Save file to the editableTemplateBackend Path
                Image image = Image.FromStream(new MemoryStream(numArray));
                image.Save(string.Concat(attachmentsPathDestination, "/", OriginalImageName));
            }
            catch (global::System.Exception e)
            {
                isImageSaved = false;
            }

            if (isImageSaved)
            {
                TemplateEditorFrontEndSevice objTemplateEditorFrontEndSevice = new TemplateEditorFrontEndSevice();
                string connectionString = objTemplateEditorFrontEndSevice.GetDomainKey(dbKey);
                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = sqlConnection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "UpdateEditableProductTemplateImageUrl";
                    command.Parameters.AddWithValue("@fileName", fileName);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@objectId", selectedObjectID);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }




        #endregion

    }
}