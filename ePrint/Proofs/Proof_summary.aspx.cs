using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using nmsLanguage;
using System.Web.Services;
using System.IO;
using System.Diagnostics;
using nmsConnectionClass;
using Ghostscript.NET.Processor;
using System.Drawing;
using System.Data;
using Printcenter.UI.Estimates;
using Newtonsoft.Json;

namespace ePrint.Proofs
{
    public partial class Proof_summary : BaseClass, IRequiresSessionState
    {
        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public string pg = string.Empty;

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

        protected void Page_Load(object sender, EventArgs e)
        {

            global.pageName = "proof";
            this.pg = "proof";
            this.gloobj.setpagename("proof");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            languageClass _languageClass = new languageClass();
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", _languageClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../Estimates/Proofs.aspx class='subnavigator'  style='text-decoration:underline;'>", "Proof View", "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", "Proof Summary"));
            base.Title = _languageClass.convert(global.pageTitle("proof Summary", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
        }
        [WebMethod]
        public static string OnSubmit(string fileName, string OriginalFileName)
        {
            string strSitepath = global.sitePath();
            string serverName = ConnectionClass.ServerName;
            int companyID = Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString());
            string SecureDocPath = global.SecureDocPath();
            object[] secureDocPath;
            string _secureDocPath = global.SecureDocPath();
            secureDocPath = new object[] { _secureDocPath, serverName, "/", companyID, "/attachments/", fileName };
            string pdfPath = string.Concat(secureDocPath);
            string empty1 = pdfPath.Replace(".pdf", "");
            string imagePath = string.Concat(empty1, ".png");
            string image = Proof_summary.ExecuteCommandGhostLibrary(pdfPath, imagePath);
            object[] secureDocPath1 = new object[] { strSitepath, "/document/securedoc/", serverName, "/", companyID, "/attachments/", fileName };
            string _imagePath = string.Concat(secureDocPath1);
            string _filePath = _imagePath.Replace(".pdf", ".png");
            return _filePath;
        }

        public static string ExecuteCommandGhostLibrary(string commandInput, string commandOut)
        {
            try
            {
                int pageFrom = 1;
                int pageTo = 50;



                using (GhostscriptProcessor ghostscript = new GhostscriptProcessor())
                {
                    ghostscript.Processing += new GhostscriptProcessorProcessingEventHandler(ghostscript_Processing);

                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dSAFER");
                    switches.Add("-dBATCH");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOPROMPT");
                    switches.Add("-dFirstPage=" + pageFrom.ToString());
                    switches.Add("-dLastPage=" + pageTo.ToString());
                    switches.Add("-sDEVICE=png16m");
                    //switches.Add("-r200");
                    switches.Add("-r72");
                    switches.Add("-dOptimize=true");

                    switches.Add("-dTextAlphaBits=4");
                    switches.Add("-dGraphicsAlphaBits=4");
                    switches.Add(@"-sOutputFile=" + commandOut);
                    switches.Add(@"-f");
                    switches.Add(commandInput);

                    ghostscript.Process(switches.ToArray());
                }

                return "";

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static void ghostscript_Processing(object sender, GhostscriptProcessorProcessingEventArgs e)
        {
            Console.WriteLine(e.CurrentPage.ToString() + " / " + e.CurrentPage.ToString());
        }


        [WebMethod]
        public static string ChangeAttachment(int proofID, int estimateItemID, int attachmentID)
        {
            //DataTable dt = EstimateBasePage.ProofHistoryDetails(proofID, estimateItemID, attachmentID);
            DataTable dt = EstimateBasePage.ProofAttachmentHistory(proofID, estimateItemID, attachmentID);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
        [WebMethod]
        public static void UpdateTwoStageApproval(bool IsChecked,int ProofItemID,string ApproverName,string ApproverEmail)
        {
            EstimateBasePage.UpdateProofApproval(IsChecked, ProofItemID,ApproverName,ApproverEmail);
        }
        [WebMethod]
        public static Object ChangeAttachmentImage(int proofID, int estimateItemID, int attachmentID)
        {
            BaseClass objBase = new BaseClass();
            string SecureDocPath = global.SecureDocPath();
            string imagePath = string.Empty;
            DataTable dt = EstimateBasePage.ProofSelectedAttachmentImage(proofID, estimateItemID, attachmentID);
            var fileName = string.Empty;
            var origFileName = string.Empty;
            string _latestImagePath = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                string[] secureDocPath = new string[] { SecureDocPath, ConnectionClass.ServerName, @"\", HttpContext.Current.Session["CompanyID"].ToString(), @"\attachments", @"\", objBase.SpecialDecode(row["FileName"].ToString()) };
                string filePath = string.Concat(secureDocPath);
                string empty1 = filePath.Replace(".pdf", "");
                imagePath = string.Concat(empty1, ".png");
                Proof_summary.ExecuteCommandGhostLibrary(filePath, imagePath);
                fileName = row["fileName"].ToString();
                origFileName = row["OriginalFileName"].ToString();
                string strSitepath = global.sitePath();
                int companyID = Convert.ToInt32(HttpContext.Current.Session["CompanyID"].ToString());

                string serverName = ConnectionClass.ServerName;
                string PngFileName = fileName.Replace(".pdf", ".png");
                _latestImagePath = "" + strSitepath + "/document/securedoc/" + serverName + "/" + companyID + "/attachments/" + PngFileName + "";
                _latestImagePath=_latestImagePath.Replace(" ", "%20");
            }
            var result = new { imagePath = _latestImagePath, fileName = fileName, orignalFileName = origFileName };
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);
            return result;
        }

        //public void ConvertPdfPageToImage(string outputFileName, int pageNumber)
        //{
        //    if (pageNumber < 1 || pageNumber > this.PageCount)
        //        throw new ArgumentException("Page number is out of bounds", "pageNumber");

        //    using (GhostScriptAPI api = new GhostScriptAPI())
        //        api.Execute(this.GetConversionArguments(this._pdfFileName,
        //        outputFileName, pageNumber, this.PdfPassword, this.Settings));
        //}

        //public Bitmap GetImage(int pageNumber)
        //{
        //    Bitmap result;
        //    string workFile;

        //    if (pageNumber < 1 || pageNumber > this.PageCount)
        //        throw new ArgumentException("Page number is out of bounds", "pageNumber");

        //    workFile = Path.GetTempFileName();

        //    try
        //    {
        //        this.ConvertPdfPageToImage(workFile, pageNumber);
        //        using (FileStream stream = new FileStream(workFile, FileMode.Open, FileAccess.Read))
        //            result = new Bitmap(stream);
        //    }
        //    finally
        //    {
        //        File.Delete(workFile);
        //    }

        //    return result;
        //}
        //public Bitmap[] GetImages(int startPage, int lastPage)
        //{
        //    List<Bitmap> results;

        //    if (startPage < 1 || startPage > this.PageCount)
        //        throw new ArgumentException
        //        ("Start page number is out of bounds", "startPage");

        //    if (lastPage < 1 || lastPage > this.PageCount)
        //        throw new ArgumentException
        //        ("Last page number is out of bounds", "lastPage");
        //    else if (lastPage < startPage)
        //        throw new ArgumentException
        //        ("Last page cannot be less than start page", "lastPage");

        //    results = new List<Bitmap>();
        //    for (int i = startPage; i <= lastPage; i++)
        //        results.Add(this.GetImage(i));

        //    return results.ToArray();
        //}

        //protected virtual IDictionary<GhostScriptCommand, object> GetConversionArguments(string pdfFileName, string outputImageFileName,
        //                    int pageNumber, string password, Pdf2ImageSettings settings)
        //{
        //    IDictionary<GhostScriptCommand, object> arguments;

        //    arguments = new Dictionary<GhostScriptCommand, object>();

        //    // basic GhostScript setup
        //    arguments.Add(GhostScriptCommand.Silent, null);
        //    arguments.Add(GhostScriptCommand.Safer, null);
        //    arguments.Add(GhostScriptCommand.Batch, null);
        //    arguments.Add(GhostScriptCommand.NoPause, null);

        //    // specify the output
        //    arguments.Add(GhostScriptCommand.Device,
        //    GhostScriptAPI.GetDeviceName(settings.ImageFormat));
        //    arguments.Add(GhostScriptCommand.OutputFile, outputImageFileName);

        //    // page numbers
        //    arguments.Add(GhostScriptCommand.FirstPage, pageNumber);
        //    arguments.Add(GhostScriptCommand.LastPage, pageNumber);

        //    // graphics options
        //    arguments.Add(GhostScriptCommand.UseCIEColor, null);

        //    if (settings.AntiAliasMode != AntiAliasMode.None)
        //    {
        //        arguments.Add(GhostScriptCommand.TextAlphaBits, settings.AntiAliasMode);
        //        arguments.Add(GhostScriptCommand.GraphicsAlphaBits, settings.AntiAliasMode);
        //    }

        //    arguments.Add(GhostScriptCommand.GridToFitTT, settings.GridFitMode);

        //    // image size
        //    if (settings.TrimMode != PdfTrimMode.PaperSize)
        //        arguments.Add(GhostScriptCommand.Resolution, settings.Dpi.ToString());

        //    switch (settings.TrimMode)
        //    {
        //        case PdfTrimMode.PaperSize:
        //            if (settings.PaperSize != PaperSize.Default)
        //            {
        //                arguments.Add(GhostScriptCommand.FixedMedia, true);
        //                arguments.Add(GhostScriptCommand.PaperSize, settings.PaperSize);
        //            }
        //            break;
        //        case PdfTrimMode.TrimBox:
        //            arguments.Add(GhostScriptCommand.UseTrimBox, true);
        //            break;
        //        case PdfTrimMode.CropBox:
        //            arguments.Add(GhostScriptCommand.UseCropBox, true);
        //            break;
        //    }

        //    // pdf password
        //    if (!string.IsNullOrEmpty(password))
        //        arguments.Add(GhostScriptCommand.PDFPassword, password);

        //    // pdf filename
        //    arguments.Add(GhostScriptCommand.InputFile, pdfFileName);

        //    return arguments;
        //}

    }
}