using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using Printcenter.UI.Department;
namespace ePrint
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public string SecureDocFilepath = nmsCommon.global.SecureDocFilepath();

        public string ServerName = string.Empty;
        public string CompanyID = "";
        public string AttachmeniID = "";


        public void ProcessRequest(HttpContext context)
        {
            if (nmsConnectionClass.ConnectionClass.ServerName != null)
            {
                ServerName = nmsConnectionClass.ConnectionClass.ServerName;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files[0];

                if (context.Request.QueryString["Cid"] != null)
                {
                    if (context.Request.QueryString["Cid"].ToString() != "")
                    {
                        CompanyID = context.Request.QueryString["Cid"].ToString().Replace("\"", "");
                    }

                    if (context.Request.QueryString["Aid"].ToString() != "")
                    {
                        string[] words = context.Request.QueryString["Aid"].ToString().Split('?');
                        //  AttachmeniID = context.Request.QueryString["Aid"].ToString();
                        AttachmeniID = words[0].ToString().Replace("\"", "");
                        AttachmeniID = AttachmeniID.Replace(" ", "");
                    }
                }

                string fileName = postedFile.FileName;
                string savepath = "";

                savepath = SecureDocFilepath + "/" + ServerName + "/" + CompanyID + "/attachments";


                int filecounter = 1;
                string Extension = Path.GetExtension(savepath + "/" + fileName);

            AgainStart:
                if (File.Exists(savepath + @"\" + fileName))
                {
                    fileName = postedFile.FileName.Trim().ToLower().Replace(Extension.ToLower(), "");
                    fileName = fileName + "_" + filecounter.ToString() + Extension.ToLower();
                    filecounter++;
                    goto AgainStart;
                }


                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }


                postedFile.SaveAs(savepath + "/" + fileName);

                //context.Response.Write(fileName + "~~" + postedFile.ContentLength);
                //context.Response.End();

                string FileSize = postedFile.ContentLength.ToString();
                //Printcenter.UI.Department.DepartmentBaseClass.CRM_Update_AttacmentFileName(Convert.ToInt32(AttachmeniID), Convert.ToInt32(CompanyID), fileName, FileSize);
                DepartmentBaseClass.CRM_Update_AttacmentFileName(Convert.ToInt32(AttachmeniID), Convert.ToInt32(CompanyID), fileName, FileSize);
                context.Response.Write(savepath + "/" + fileName);
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                // context.Response.Write("Error: " + ex.Message);
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