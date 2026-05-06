<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using System.IO;
using TemplateEditor;
using System.Collections.Generic;

public class UploadHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        TemplateEditorService objTemplateEditorService = new TemplateEditorService();


        List<string> lstOfFileNames = new List<string>();

        long CompanyID = Convert.ToInt64(context.Request.QueryString["CompanyID"]);
        string dbKey = context.Request.QueryString["Dbkey"];
        string imageUploadPath = context.Request.QueryString["ImageUploadPath"];
        string[] uploadFileNames = context.Request.QueryString["UploadFileNames"].Split(',');
        long CategoryID = Convert.ToInt64(context.Request.QueryString["CategoryID"]);
        long TemplateID = Convert.ToInt64(context.Request.QueryString["TemplateID"]);
        long UserID = Convert.ToInt64(context.Request.QueryString["UserID"]);

        string ImagePath = imageUploadPath;
        string Zoom = context.Request.QueryString["Zoom"];
        //string imagelist = "";


        string pathForOriginalImages = ImagePath + CompanyID + "/Images/Gallery/OriginalImages";
        string pathForImages = ImagePath + CompanyID + "/Images";
        string pathForThumnailImages = ImagePath + CompanyID + "/Images/Gallery/ThumbnailImages";
        string pathForPdf = ImagePath + CompanyID + "/pdf";
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

        if (!Directory.Exists(pathForImages))//added By shahbaz
        {
            try
            {
                Directory.CreateDirectory(pathForImages);
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
                    if (onlyName == objHttpPostedFile.FileName)
                    {
                        if (extention[1].ToLower() != "pdf")
                        {
                            objHttpPostedFile.SaveAs(string.Concat(pathForOriginalImages, "/", strGuiD + "_" + onlyName));
                            objHttpPostedFile.SaveAs(string.Concat(pathForImages, "/", strGuiD + "_" + onlyName));//added By Shahbaz
                            lstOfFileNames.Add(strGuiD + "_" + objHttpPostedFile.FileName);
                            byte[] fileBytes = System.IO.File.ReadAllBytes(string.Concat(pathForOriginalImages, "/", strGuiD + "_" + onlyName));
                            MemoryStream stream = new MemoryStream(fileBytes);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                            //imagelist += objTemplateEditorService.InsertImageGallery(CompanyID, TemplateID, CategoryID, UserID, "admin", onlyName, strGuiD + "_" + onlyName, objHttpPostedFile.ContentLength.ToString(), "", "", dbKey) + ",";

                            createThumbnail.CreateProportionalImage(image, pathForOriginalImages + "/", pathForThumnailImages + "/", strGuiD + "_" + onlyName, 100, 100, image.Width, image.Height, true, 100, true);
                        }
                        else
                        {
                            objHttpPostedFile.SaveAs(string.Concat(pathForPdf, "/", strGuiD + "_" + onlyName));
                        }
                    }
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