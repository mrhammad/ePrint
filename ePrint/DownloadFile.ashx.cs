using System;
using System.Web;
using System.IO;

namespace ePrint
{


    public class DownloadFile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request["file"];
            string filePath = context.Server.MapPath("~/tempattachment/" + file);

            if (!File.Exists(filePath))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("File not found.");
                return;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            context.Response.TransmitFile(filePath);
            context.Response.End();
        }

        public bool IsReusable => false;
    }


}