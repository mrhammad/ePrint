using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.SessionState;

using System.Text;
using System.Text.RegularExpressions;
using nmsCommon;
using Printcenter.UI.Products;
using nmsConnection;
using Printcenter.UI.CatrsNew;

using System.IO;
using System.Web.Hosting;
using System.Diagnostics;
using System.IO.Compression;

namespace ePrint.MyPublicStore
{
    /// <summary>
    /// Summary description for Imagename
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        private HttpContext _httpContext;
        private string _fileName;
        private string _type;
        public string StoreimageHandlerPath = string.Empty;
        public string productImageHandlerPath = string.Empty;
        public string catagoryImageHandlerPath = string.Empty;
        public string bannerImagePath = string.Empty;
        private string _AccountID = string.Empty;
        private string _CompanyID = string.Empty;
        public string PrintReadyFilePath = string.Empty;
        public string artworkPath = string.Empty;
        public string PdfFilePath = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            _httpContext = context;
            _AccountID = _httpContext.Request.QueryString["aid"];
            _CompanyID = _httpContext.Request.QueryString["cid"];


            if (ConnectionClass.StoreimageHandlerPath != null)
            {
                StoreimageHandlerPath = ConnectionClass.StoreimageHandlerPath.ToString();
            }

            if (ConnectionClass.SecureDocPath != null)
            {
                //productImageHandlerPath = ConnectionClass.ImageHandlerPath + _CompanyID + "\\Product\\";
                //PrintReadyFilePath = ConnectionClass.ImageHandlerPath + _CompanyID + "\\Product\\PrintReady\\";
                productImageHandlerPath = ConnectionClass.SecureDocPath + ConnectionClass.ServerName + "\\" + _CompanyID + "\\Product\\";
                PrintReadyFilePath = ConnectionClass.SecureDocPath + ConnectionClass.ServerName + "\\" + _CompanyID + "\\Product\\PrintReady\\";
            }

            if (ConnectionClass.SecureDocPath != null)
            {
                //   catagoryImageHandlerPath = ConnectionClass.ImageHandlerPath.ToString() + _CompanyID + "\\ProductCatalogueCategory\\";
                catagoryImageHandlerPath = ConnectionClass.SecureDocPath + ConnectionClass.ServerName + "\\" + _CompanyID + "\\ProductCatalogueCategory\\";
            }

            if (ConnectionClass.SecureDocFilepath != null)
            {
                //  bannerImagePath = ConnectionClass.eprintDocument.ToString() + "store\\" + _AccountID + "\\banners\\";
                bannerImagePath = ConnectionClass.SecureDocFilepath + ConnectionClass.ServerName + "\\store\\" + _AccountID + "\\banners\\";
            }

            if (ConnectionClass.SecureDocFilepath != null)
            {
                //  artworkPath = ConnectionClass.eprintDocument.ToString() + "store\\" + _AccountID + "\\";
                artworkPath = ConnectionClass.SecureDocFilepath + ConnectionClass.ServerName + "/store/" + _AccountID + "/artwork/";
            }
            if (ConnectionClass.SecureDocPath != null)
            {
                PdfFilePath = ConnectionClass.SecureDocPath + ConnectionClass.ServerName + "\\store\\" + _AccountID + "\\pdf\\";
            }
            //productImageHandlerPath = "";
            //catagoryImageHandlerPath = "";
            //bannerImagePath = "";



            _fileName = _httpContext.Request.QueryString["ImageName"];
            _type = _httpContext.Request.QueryString["type"];
            HttpRequest req = context.Request;

            if (_type == "r")
            {
                if (_fileName != null)
                    _fileName = StoreimageHandlerPath + _httpContext.Request.QueryString["ImageName"]; ;
            }
            else if (_type == "p")
            {
                if (_fileName != null)
                    _fileName = productImageHandlerPath + _httpContext.Request.QueryString["ImageName"]; ;
            }
            else if (_type == "c")
            {
                if (_fileName != null)
                    _fileName = catagoryImageHandlerPath + _httpContext.Request.QueryString["ImageName"]; ;
            }
            else if (_type == "b")
            {
                if (_fileName != null)
                    _fileName = bannerImagePath + _httpContext.Request.QueryString["ImageName"];
            }
            else if (_type == "pr")// type pr for PrintReadyFile 
            {
                if (_fileName != null)
                {
                    _fileName = PrintReadyFilePath + _httpContext.Request.QueryString["ImageName"];
                }
            }
            else if (_type == "a")// type a for artwork 
            {
                if (_fileName != null)
                {
                    _fileName = artworkPath + _httpContext.Request.QueryString["ImageName"];
                }
            }
            else if (_type == "pdf")// type pdf 
            {
                if (_fileName != null)
                {
                    _fileName = PdfFilePath + _httpContext.Request.QueryString["ImageName"];
                }
            }


            if (File.Exists(_fileName))
            {
                string FileExt = Path.GetExtension(_fileName);
                context.Response.StatusCode = 200;
                if (FileExt.ToLower() == ".pdf")
                {
                    context.Response.ContentType = "application/pdf";
                    context.Response.WriteFile(_fileName);
                }
                else
                {
                    context.Response.ContentType = "image/png";
                    //Changed by Gaj
                    FileInfo objFileInfo = new FileInfo(_fileName);
                    context.Response.Cache.SetCacheability(HttpCacheability.Public);
                    context.Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
                    string rawIfModifiedSince = context.Request.Headers
                                                .Get("If-Modified-Since");




                    //Changed by Gaj
                    if (string.IsNullOrEmpty(rawIfModifiedSince))
                    {
                        // Set Last Modified time
                        context.Response.Cache.SetLastModified(objFileInfo.CreationTime);
                        context.Response.WriteFile(_fileName);
                    }
                    else
                    {
                        if (objFileInfo.CreationTime <= Convert.ToDateTime(rawIfModifiedSince))
                        {
                            context.Response.StatusCode = 304;
                            return;
                        }
                        else
                        {
                            context.Response.WriteFile(_fileName);
                        }

                    }
                    //Changed by Gaj
                    //context.Response.WriteFile(_fileName);
                }
            }
            else
            {
                //context.Response.Status = "Image not found";
                //context.Response.StatusCode = 404;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}