<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using System.IO;
using TemplateEditorFrontEnd;
using System.Collections.Generic;

public class UploadHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

        string IsChecked = string.Empty;
        List<string> lstOfFileNames = new List<string>();
        if (context.Request.QueryString["isChecked"] != null)// Added by shahbaz
            IsChecked = context.Request.QueryString["isChecked"];
        if (IsChecked.ToLower() == "true")
        {
            long CompanyID = Convert.ToInt64(context.Request.QueryString["CompanyID"]);
            string dbKey = context.Request.QueryString["Dbkey"];
            string imageUploadPath = context.Request.QueryString["ImageUploadPath"];
            string[] uploadFileNames = context.Request.QueryString["UploadFileNames"].Split(',');
            //long CategoryID = Convert.ToInt64(context.Request.QueryString["CategoryID"]);
            long TemplateID = Convert.ToInt64(context.Request.QueryString["TemplateID"]);
            long UserID = Convert.ToInt64(context.Request.QueryString["UserID"]);

            string ImagePath = imageUploadPath;
            string Zoom = context.Request.QueryString["Zoom"];
            //string imagelist = "";


            string pathForOriginalImages = ImagePath + "/UsersImages/" + UserID + "/Gallery/OriginalImages";
            string pathForThumnailImages = ImagePath + "/UsersImages/" + UserID + "/Gallery/ThumbnailImages";
            string pathForPdf = ImagePath + "/UsersImages/" + UserID + "/pdf";
            if (!Directory.Exists(pathForPdf))
            {
                try
                {
                    Directory.CreateDirectory(pathForPdf);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(pathForOriginalImages))
            {
                try
                {
                    Directory.CreateDirectory(pathForOriginalImages);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(pathForThumnailImages))
            {
                try
                {
                    Directory.CreateDirectory(pathForThumnailImages);
                }
                catch
                {
                }
            }
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                //var strGuiD = System.Guid.NewGuid().ToString().Substring(0, 5);
                HttpPostedFile objHttpPostedFile = (HttpPostedFile)context.Request.Files[i];
                string[] extention = objHttpPostedFile.FileName.Split('.');

                for (int k = 0; k < uploadFileNames.Length; k++)
                {
                    if (uploadFileNames[k] != "")
                    {
                        string[] arry = uploadFileNames[k].Split('~');
                        string onlyName = arry[1];
                        string strGuiD = arry[0];
                        string PostedFileName = objHttpPostedFile.FileName;
                        if (extention.Length > 2)
                        {
                            PostedFileName = extention[0].ToString() + "." + extention[extention.Length - 1].ToString();
                        }
                        if (onlyName == PostedFileName)
                        {
                            if (extention[extention.Length - 1].ToLower() != "pdf")
                            {
                                objHttpPostedFile.SaveAs(string.Concat(pathForOriginalImages, "/", strGuiD + "_" + onlyName));
                                lstOfFileNames.Add(strGuiD + "_" + objHttpPostedFile.FileName);
                                byte[] fileBytes = System.IO.File.ReadAllBytes(string.Concat(pathForOriginalImages, "/", strGuiD + "_" + onlyName));
                                MemoryStream stream = new MemoryStream(fileBytes);
                                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                                createThumbnail.CreateProportionalImage(image, pathForOriginalImages + "/", pathForThumnailImages + "/", strGuiD + "_" + onlyName, 100, 100, image.Width, image.Height, true, 100, true);
                            }
                            else
                            {
                                string fileNameWidthGuid = strGuiD + "_" + onlyName;

                                objHttpPostedFile.SaveAs(string.Concat(pathForPdf, "/", fileNameWidthGuid));

                                TemplateEditorFrontEndSevice objTemplateEditorFrontEndSevice = new TemplateEditorFrontEndSevice();
                                string Filenewname = objTemplateEditorFrontEndSevice.CreateImageThumbnails(CompanyID, TemplateID, UserID, fileNameWidthGuid + ",", objHttpPostedFile.ContentLength.ToString() + ",", dbKey);

                                byte[] fileBytes = System.IO.File.ReadAllBytes(string.Concat(pathForOriginalImages, "/", Filenewname));
                                MemoryStream stream = new MemoryStream(fileBytes);
                                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                                createThumbnail.CreateProportionalImage(image, pathForOriginalImages + "/", pathForThumnailImages + "/", Filenewname, 100, 100, image.Width, image.Height, true, 100, true);
                                
                            }
                        }
                    }
                }

            }
        }
        else
        {
            string imageUploadPath = context.Request.QueryString["ImageUploadPath"];
            string uploadFileName = context.Request.QueryString["UploadFileName"];
            long TemplateID = Convert.ToInt64(context.Request.QueryString["TemplateID"]);
            long CompanyID = Convert.ToInt64(context.Request.QueryString["CompanyID"]);
            long UserID = Convert.ToInt64(context.Request.QueryString["UserID"]);
            string dbKey = context.Request.QueryString["Dbkey"];

            string pathForImage = imageUploadPath + TemplateID + "/Images";
            string pathForPdf = imageUploadPath + "/UsersImages/" + UserID + "/pdf";
            if (!Directory.Exists(pathForPdf))
            {
                try
                {
                    Directory.CreateDirectory(pathForPdf);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(pathForImage))
            {
                try
                {
                    Directory.CreateDirectory(pathForImage);
                }
                catch
                {
                }
            }

            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                //var strGuiD = System.Guid.NewGuid().ToString().Substring(0, 5);
                HttpPostedFile objHttpPostedFile = (HttpPostedFile)context.Request.Files[i];
                string[] extention = objHttpPostedFile.FileName.Split('.');

                string[] arry = uploadFileName.Split('~');
                string onlyName = arry[1];
                string strGuiD = arry[0];
                if (onlyName == objHttpPostedFile.FileName)
                {
                    if (extention[1].ToLower() != "pdf")
                    {
                        objHttpPostedFile.SaveAs(string.Concat(pathForImage, "/", strGuiD + "_" + onlyName));
                    }
                    else
                    {
                        objHttpPostedFile.SaveAs(string.Concat(pathForPdf, "/", strGuiD + "_" + onlyName));

                        TemplateEditorFrontEndSevice objTemplateEditorFrontEndSevice = new TemplateEditorFrontEndSevice();
                        string Filenewname = objTemplateEditorFrontEndSevice.CreateImageThumbnails(CompanyID, TemplateID, UserID, strGuiD + "_" + onlyName + ",", objHttpPostedFile.ContentLength.ToString() + ",", dbKey);
                    }
                    break;
                }
            }
        }
        //GlobalVariables.ImageList = imagelist;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}