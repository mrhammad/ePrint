<%@ WebHandler Language="C#" Class="CropHandler" %>

using System;
using System.Web;
using System.IO;
using TemplateEditorFrontEnd;
using System.Collections.Generic;
using System.Web.Script.Serialization;
public class CropHandler : IHttpHandler
{
    public static System.Drawing.Image DownloadImageFromUrl(string imageUrl)
    {
        System.Drawing.Image image = null;

        try
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Timeout = 30000;

            System.Net.WebResponse webResponse = webRequest.GetResponse();

            System.IO.Stream stream = webResponse.GetResponseStream();

            image = System.Drawing.Image.FromStream(stream);

            webResponse.Close();
        }
        catch (Exception ex)
        {
            return null;
        }

        return image;
    }
    public void ProcessRequest(HttpContext context)
    {

        try
        {
            string imgUrl = context.Request["imgUrl"];
            // original sizes
            string imgInitW = context.Request["imgInitW"];
            string imgInitH = context.Request["imgInitH"];
            // resized sizes
            string imgW = context.Request["imgW"];
            string imgH = context.Request["imgH"];
            // offsets
            string imgY1 = context.Request["imgY1"];
            string imgX1 = context.Request["imgX1"];
            // crop box
            string cropW = context.Request["cropW"];
            string cropH = context.Request["cropH"];
            // rotation angle
            string angle = context.Request["rotation"];


            string FrontEndUploadPath = context.Request["FrontEndUploadPath"];
            string originalFilename = context.Request["originalFilename"];
            string newFilename = context.Request["newFilename"];
            string FontPath = context.Request["FontPath"];


            string jpeg_quality = "100";


            string TemplateID = context.Request["TemplateID"];

            //  System.Drawing.Image objOrigionnalImage = DownloadImageFromUrl(imgUrl);







            string MainDocURL = FontPath.Replace(@"editabletemplatebackend/Fonts/", "");
            string MainDocPath = FrontEndUploadPath.Replace(@"editabletemplatefrontend", "").Replace(@"TemplateEditorForntEnd", "");

            // string CurrentImagePath = imgUrl.Replace(MainDocURL + "Fronend/", MainDocPath);
            // CurrentImagePath = CurrentImagePath.Replace(@"/", @"\");
            // = CurrentImagePath.Replace(@"\\", @"\");
            //string CurrentImagePath = imgUrl.Replace(MainDocURL, MainDocPath);
            //string CurentImageFolder = CurrentImagePath.Replace(originalFilename, "");


            byte[] fileBytes = null;
            string CurentImageFolder = string.Empty;
            try
            {
                CurentImageFolder = imgUrl.Replace(MainDocURL, MainDocPath);
                CurentImageFolder = CurentImageFolder.Replace(originalFilename, "");
                fileBytes = System.IO.File.ReadAllBytes(string.Concat(CurentImageFolder, "/", originalFilename));
            }
            catch
            {
                string CurrentImagePath = imgUrl.Replace(MainDocURL + "Fronend/", MainDocPath);
                CurentImageFolder = CurrentImagePath.Replace(originalFilename, "");
                fileBytes = System.IO.File.ReadAllBytes(string.Concat(CurentImageFolder, "/", originalFilename));
            }
            MemoryStream stream = new MemoryStream(fileBytes);
            System.Drawing.Image objOrigionnalImage = System.Drawing.Image.FromStream(stream);




            System.Drawing.Image objResizedImage = createThumbnail.Resize(objOrigionnalImage, Convert.ToInt32(Math.Round(Convert.ToDouble(imgW))), Convert.ToInt32(Math.Round(Convert.ToDouble(imgH))));


            if (Convert.ToInt32(Math.Round(Convert.ToDouble(angle))) != 0)
            {
                objResizedImage = createThumbnail.RotateImageByAngle(objResizedImage, (float)Convert.ToDouble(angle));
            }

            System.Drawing.Image objCropped = createThumbnail.Crop(objResizedImage, Convert.ToInt32(Math.Round(Convert.ToDouble(imgX1))), Convert.ToInt32(Math.Round(Convert.ToDouble(imgY1))), Convert.ToInt32(Math.Round(Convert.ToDouble(cropW))), Convert.ToInt32(Math.Round(Convert.ToDouble(cropH))));


            if (!Directory.Exists(CurentImageFolder))
            {
                try
                {
                    Directory.CreateDirectory(CurentImageFolder);
                }
                catch
                {
                }
            }


            if (!Directory.Exists(FrontEndUploadPath + TemplateID + "//Images"))
            {
                try
                {
                    Directory.CreateDirectory(FrontEndUploadPath + TemplateID + "//Images");
                }
                catch
                {
                }
            }

            objCropped.Save(CurentImageFolder + newFilename);

            try
            {

                File.Copy(CurentImageFolder + newFilename, FrontEndUploadPath + TemplateID + "//Images//" + newFilename, true);
            }
            catch (Exception ex)
            {
            }


            response obj = new response();
            obj.status = "success";
            obj.url = imgUrl.Replace(originalFilename, newFilename);




            JavaScriptSerializer jss = new JavaScriptSerializer();

            string output = jss.Serialize(obj);
            context.Response.Write(output);
            context.Response.Flush();
            // context.Response.End();
        }
        catch
        {
            //Uncommented this all Catch block Shahbaz
            response obj = new response();
            obj.status = "error";
            obj.url = "";




            JavaScriptSerializer jss = new JavaScriptSerializer();

            string output = jss.Serialize(obj);
            context.Response.Write(output);
            context.Response.Flush();
            context.Response.End();
        }


    }


    public class response
    {
        public string status { get; set; }
        public string url { get; set; }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}