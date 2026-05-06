using nmsConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ePrint.WebStore
{
    /// <summary>
    /// Summary description for ImageHandler
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

        public string artworkPath = string.Empty;

        private string _AccountID = string.Empty;

        private string _CompanyID = string.Empty;

        private string FromStoreAttach = string.Empty;

        public string PrintReadyFilePath = string.Empty;

        public string PdfFilePath = string.Empty;

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            this._httpContext = context;
            this._AccountID = this._httpContext.Request.QueryString["aid"];
            this._CompanyID = this._httpContext.Request.QueryString["cid"];
            if (this._httpContext.Request.QueryString["fromattachment"] != null)
            {
                this.FromStoreAttach = this._httpContext.Request.QueryString["fromattachment"];
            }
            if (ConnectionClass.StoreimageHandlerPath != null)
            {
                this.StoreimageHandlerPath = ConnectionClass.StoreimageHandlerPath.ToString();
            }
            if (ConnectionClass.SecureDocPath != null)
            {
                string[] secureDocPath = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this._CompanyID, "\\Product\\" };
                this.productImageHandlerPath = string.Concat(secureDocPath);
                string[] strArrays = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this._CompanyID, "\\Product\\PrintReady\\" };
                this.PrintReadyFilePath = string.Concat(strArrays);
            }
            if (ConnectionClass.SecureDocPath != null)
            {
                string[] secureDocPath1 = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this._CompanyID, "\\ProductCatalogueCategory\\" };
                this.catagoryImageHandlerPath = string.Concat(secureDocPath1);
            }
            if (ConnectionClass.SecureDocFilepath != null)
            {
                string[] secureDocFilepath = new string[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "\\store\\", this._AccountID, "\\banners\\" };
                this.bannerImagePath = string.Concat(secureDocFilepath);
            }
            if (ConnectionClass.SecureDocFilepath != null)
            {
                if (this.FromStoreAttach.ToLower() != "false")
                {
                    string[] secureDocFilepath1 = new string[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/store/", this._AccountID, "/artwork/" };
                    this.artworkPath = string.Concat(secureDocFilepath1);
                }
                else
                {
                    string[] strArrays1 = new string[] { ConnectionClass.SecureDocFilepath, ConnectionClass.ServerName, "/", this._CompanyID, "/attachments/" };
                    this.artworkPath = string.Concat(strArrays1);
                }
            }
            if (ConnectionClass.SecureSitePath != null)
            {
                string[] secureDocPath2 = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", this._AccountID, "\\pdf\\" };
                this.PdfFilePath = string.Concat(secureDocPath2);
            }
            this._fileName = this._httpContext.Request.QueryString["ImageName"];
            this._type = this._httpContext.Request.QueryString["type"];
            HttpRequest request = context.Request;
            if (this._type == "r")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.StoreimageHandlerPath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "p")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.productImageHandlerPath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "c")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.catagoryImageHandlerPath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "b")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.bannerImagePath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "pr")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.PrintReadyFilePath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "a")
            {
                if (this._fileName != null)
                {
                    this._fileName = string.Concat(this.artworkPath, this._httpContext.Request.QueryString["ImageName"]);
                }
            }
            else if (this._type == "pdf" && this._fileName != null)
            {
                this._fileName = string.Concat(this.PdfFilePath, this._httpContext.Request.QueryString["ImageName"]);
            }
            else if (_type == "previewimage")
            {
                if (_fileName != null)
                {
                    _fileName = string.Concat(PdfFilePath , _httpContext.Request.QueryString["ImageName"]);
                }
            }
            if (File.Exists(this._fileName))
            {
                string extension = Path.GetExtension(this._fileName);
                context.Response.StatusCode = 200;
                if (extension.ToLower() != ".jpg" && extension.ToLower() != ".tif" && extension.ToLower() != ".png" && extension.ToLower() != ".gif" && extension.ToLower() != ".jpeg")
                {
                    FileInfo fileInfo = new FileInfo(this._fileName);
                    File.ReadAllBytes(this._fileName);
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.Buffer = true;
                    context.Response.Clear();
                    context.Response.AddHeader("content-disposition", string.Concat("attachment;filename=\"", fileInfo.Name, "\""));
                    context.Response.TransmitFile(this._fileName);
                    context.Response.End();
                    context.Response.Flush();
                }
                if (extension.ToLower() == ".pdf")
                {
                    context.Response.ContentType = "application/pdf";
                    context.Response.WriteFile(this._fileName);
                    return;
                }
                context.Response.ContentType = "image/png";
                FileInfo fileInfo1 = new FileInfo(this._fileName);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
                string str = context.Request.Headers.Get("If-Modified-Since");
                if (string.IsNullOrEmpty(str))
                {
                    context.Response.Cache.SetLastModified(fileInfo1.CreationTime);
                    context.Response.WriteFile(this._fileName);
                    return;
                }
                if (fileInfo1.CreationTime <= Convert.ToDateTime(str))
                {
                    context.Response.StatusCode = 304;
                    return;
                }
                context.Response.WriteFile(this._fileName);
            }
        }
    }
}