using EditableTemplate.DataAccessLayer;
using Ghostscript.NET.Processor;
using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using java.awt.geom;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class preview_HTML5_V2 : BaseClass, IRequiresSessionState
    {
        //protected CheckBox chkconform;

        //protected Button btnback;

        //protected Button addtocart;

        //protected HtmlTableCell tdTypeSelect;

        //protected HtmlIframe pdfframe;

        //protected HtmlGenericControl div_imagePreview;

        //protected HtmlGenericControl imageframe;

        protected FontStyle objFontStyle;

        public string PDFFrom = string.Empty;

        public string StorePDFTo = string.Empty;

        public string PDFToURL = string.Empty;

        public string ImagePathFromFrontEnd = string.Empty;

        public string FontFilePathForPDF = string.Empty;

        public string ImageFromPath = string.Empty;

        public string ImageToPath = string.Empty;

        private string _finalpdfpath = "";

        private string SitePath = "";

        private string TemplateID = string.Empty;

        private string SessionID1 = string.Empty;

        public double CropMarkWidth;

        public double CropMarkHeight;

        public bool isAllowPDFPreviews;

        public string PreviewType = string.Empty;

        public bool isPDFPreviewMandatory;

        public bool isAllowWaterMark;

        public string WaterMarkText;

        public string AccountID = "0";

        private string CartItemID = "0";

        public string CompanyID = "0";

        private string PriceCatID = "0";

        private string TOPDFName = "";

        private string CropedPDFName = "";

        public string StorePDFToLocalFolder = "";

        private string fromstore = "";

        private string Label_FontStyle = string.Empty;

        private string ConnectionString = string.Empty;

        protected Color color;

        public int totalRequiredPages;

        public int totalPagesize;

        public string LabelColor = "";

        public string ImagesName = string.Empty;

        private static string PreviewImages;

        private static string FinalPDFName;

        private string SystemName = "";

        public string TemplateName;

        public string strImagepath = BaseClass.imagePath();





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

        static preview_HTML5_V2()
        {
            preview_HTML5_V2.PreviewImages = string.Empty;
            preview_HTML5_V2.FinalPDFName = string.Empty;
        }

        public preview_HTML5_V2()
        {
        }

        protected void addtocart_Click(object sender, EventArgs e)
        {
            CartBasePage.Update_PDFNameC(Convert.ToInt64(this.CartItemID), preview_HTML5_V2.FinalPDFName, preview_HTML5_V2.PreviewImages, this.PreviewType, "");
            HttpResponse response = base.Response;
            string[] sitePath;

            var IsConvertedToOrder = false;

            var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
            if (table.Rows.Count > 0)
            {
                IsConvertedToOrder = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
            }

            if (IsConvertedToOrder)
            {

                string str3 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf");
                var TempPdfFileName = string.Concat(this.CompanyID, preview_HTML5_V2.FinalPDFName);
                //string str4 = string.Concat(str3, "\\", IsConvertedToOrder == false ? this.TOPDFName : TempPdfFileName);

                string newFileName = string.Concat(str3, "\\", preview_HTML5_V2.FinalPDFName);
                string oldFileName = string.Concat(str3, "\\", TempPdfFileName);

                File.Delete(newFileName); // Delete the existing file if exists
                File.Move(oldFileName, newFileName);

            }
           
            //if (ApprovalStatus )
            //{
            //    sitePath = new string[] { this.SitePath, "order.aspx?OrderID=" + table.Rows[0]["EstimateID"].ToString() };
            //}
            //else
            //{
            sitePath = new string[] { this.SitePath, "BlanckPageForCart_html5_V2.aspx?ID=", this.PriceCatID, "&CartItemID=", this.CartItemID, "&TemplateID=", this.TemplateID, "&CompanyID=", this.CompanyID, "&PreviewType=", this.PreviewType, "&directToCart=false&PreviewImages=", preview_HTML5_V2.PreviewImages, "&FinalPDFName=", preview_HTML5_V2.FinalPDFName };
            //}


            response.Redirect(string.Concat(sitePath));
        }

        protected void btnback_Click(object sender, EventArgs e)
        {

            var IsConvertedToOrder = false;

            var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
            string OrderId = "";
            if (table.Rows.Count > 0)
            {
                IsConvertedToOrder = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
                if (IsConvertedToOrder)               
                OrderId = "&OrderId=" + table.Rows[0]["EstimateID"].ToString();
            }

            HttpResponse response = base.Response;
            string[] sitePath = new string[] { this.SitePath, "products/edit_template.aspx?ID=", this.PriceCatID, "&CartItemID=", this.CartItemID, OrderId };
            response.Redirect(string.Concat(sitePath));
        }

        public void changePageSize(string outputURI, string pdf)
        {
        }
        public string ExecuteCommandGhostLibrary(string commandInput, string commandOut)
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
                    switches.Add("-r200");
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
        void ghostscript_Processing(object sender, GhostscriptProcessorProcessingEventArgs e)
        {
            Console.WriteLine(e.CurrentPage.ToString() + " / " + e.CurrentPage.ToString());
        }
        public void ConvertToImage(string PDFPath, string ImagePath, string UniqueKey)
        {
            string empty = string.Empty;
            string str = string.Empty;
            PdfReader pdfReader = new PdfReader(PDFPath);
            iTextSharp.text.Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(1);
            double height = (double)pageSizeWithRotation.Height;
            double width = (double)pageSizeWithRotation.Width;
            str = "imgconvert -units pixelspercentimeter -density 800 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"";
            str = "imgconvert -units pixelspercentimeter \"[density]\" -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"";
            if (height <= 200 && width <= 300)
            {
                str = "imgconvert -units pixelspercentimeter -density 300 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"";
            }
            else if (height < 200 || height > 800 || width < 300 || width > 500)
            {
                str = (height < 800 || height > 1500 || width < 500 || width > 800 ? "imgconvert -units pixelspercentimeter -density 800 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"" : "imgconvert -units pixelspercentimeter -density 500 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"");
            }
            else
            {
                str = "imgconvert -units pixelspercentimeter -density 400 -colorspace sRGB \"[PDF]\" -channel rgba -fuzz 600 -transparent \"#ffffff\" -resize 100% \"[Image]\"";
            }
            str = str.Replace("[PDF]", PDFPath).Replace("[Image]", ImagePath);
            this.ExecuteCommand(str);
            pdfReader.Dispose();
            pdfReader.Close();
        }

        public byte[] CreateWaterMark(FileInfo sourceFile, string stringToWriteToPdf)
        {
            byte[] array;
            PdfReader pdfReader = new PdfReader(sourceFile.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
                for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                {
                    iTextSharp.text.Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(i);
                    //Ticket #8529 SMP-watermark on editable product previews with images not show
                    //PdfContentByte overContent = pdfStamper.GetUnderContent(i);

                    PdfContentByte overContent = pdfStamper.GetOverContent(i);
                    overContent.BeginText();
                    PdfGState gstate = new PdfGState();
                    gstate.FillOpacity = 0.3f;
                    gstate.StrokeOpacity = 0.3f;
                    overContent.SetGState(gstate);
                    //BaseFont baseFont = BaseFont.CreateFont("Helvetica", "Cp1252", false);
                    //overContent.SetFontAndSize(baseFont, (float)Convert.ToInt16(35));
                    overContent.SetRGBColorFill(242, 242, 242);
                    float hypotenuseAngleInDegreesFrom = (float)this.GetHypotenuseAngleInDegreesFrom((double)pageSizeWithRotation.Height, (double)pageSizeWithRotation.Width);
                    //overContent.ShowTextAligned(1, stringToWriteToPdf, pageSizeWithRotation.Width / 2f, pageSizeWithRotation.Height / 2f - 16f, hypotenuseAngleInDegreesFrom);
                    //water mark
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                    BaseColor bc = new BaseColor(0, 0, 0, 65);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 50f, iTextSharp.text.Font.NORMAL, bc);

                    // Dim wfont = New Font(BaseFont.TIMES_ROMAN, 1.0F, BaseFont.COURIER, BaseColor.LIGHT_GRAY)
                    ColumnText.ShowTextAligned(overContent, Element.ALIGN_CENTER, new Phrase(stringToWriteToPdf, times), pageSizeWithRotation.Width / 2f, pageSizeWithRotation.Height / 2f - 16f, hypotenuseAngleInDegreesFrom);

                    //End water mark

                    overContent.EndText();
                }
                pdfStamper.Close();
                pdfReader.Close();
                array = memoryStream.ToArray();
            }
            return array;
        }

        public string ExecuteCommand(string command)
        {
            string str;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", string.Concat("/c ", command))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process process = new Process()
                {
                    StartInfo = processStartInfo
                };
                process.Start();
                process.WaitForExit();
                string end = process.StandardOutput.ReadToEnd();
                process.Dispose();
                process.Close();
                str = end;
            }
            catch
            {
                return null;
            }
            return str;
        }

        public void CalculateKerning(Chunk chunk, double width)
        {
            float single6 = chunk.GetCharacterSpacing();
            float WidthWithCharSpacing = chunk.GetWidthPoint() + chunk.GetCharacterSpacing() * (chunk.Content.Length - 1);

            if (WidthWithCharSpacing > width)
            {
                while (WidthWithCharSpacing > width)
                {
                    single6 = single6 - .1f;
                    chunk.SetCharacterSpacing(single6);
                    WidthWithCharSpacing = chunk.GetWidthPoint() + chunk.GetCharacterSpacing() * (chunk.Content.Length - 1);
                }
            }
        }

        public Phrase CheckSpecialCharacterInChunk(string upper, Phrase phrase, Chunk chunk)
        {
            string[] separators = { "®", "™" };
            string separator = "®";
            string[] parts = upper.Split(separators, StringSplitOptions.None);
            phrase = new Phrase();

            Chunk chk = null;

            if (!upper.Contains(separator))
                separator = "™";

            for (int i = 0; i < parts.Length; i++)

            {
                chk = new Chunk(parts[i], chunk.Font);
                chk.SetCharacterSpacing(chunk.GetCharacterSpacing());
                phrase.Add(chk);
                if (i != parts.Length - 1)
                {

                    chk = new Chunk(separator, chunk.Font).SetTextRise(2);
                    chk.SetCharacterSpacing(chunk.GetCharacterSpacing());
                    phrase.Add(chk);
                }

            }

            return phrase;
        }
        private void GeneratePDF()
        {
            DateTime date;
            DataSet templateData = this.GetTemplateData();
            DataTable item = templateData.Tables[0];
            string empty = string.Empty;
            Boolean IsConvertedToOrder = false;

            var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
            if (table.Rows.Count > 0)
            {
                IsConvertedToOrder = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
            }

            foreach (DataRow row in templateData.Tables[1].Rows)
            {
                empty = row["PDFName"].ToString();
                this.CropedPDFName = row["CropedPDFName"].ToString();
                if (this.CropedPDFName != string.Empty)
                {
                    empty = this.CropedPDFName;
                }
                row["Zoomx"].ToString();
                row["Zoomy"].ToString();
                double num = 2.845275591;
                this.CropMarkHeight = Convert.ToDouble(row["CropMarkHeight"]) * num;
                this.CropMarkWidth = Convert.ToDouble(row["CropMarkWidth"]) * num;
                this.isAllowPDFPreviews = Convert.ToBoolean(row["isAllowPDFPreviews"]);
                this.isAllowWaterMark = Convert.ToBoolean(row["isAllowWaterMark"]);
                this.WaterMarkText = row["WaterMarkText"].ToString();
                this.TemplateName = row["TemplateName"].ToString();
            }
            DataRow[] dataRowArray = item.Select("pagenumber = max(pagenumber)");
            if ((int)dataRowArray.Length > 0)
            {
                this.totalRequiredPages = Convert.ToInt32(dataRowArray[0]["pagenumber"]);
            }
            if (this.totalRequiredPages == 0)
            {
                this.totalRequiredPages = 1;
            }
            string str = "0";
            string str1 = "0";

            Session["pdfnameF"] = String.Empty;
            string str2 = string.Concat(this.PDFFrom, this.CompanyID, "\\pdf\\", empty.ToString());
            this.TOPDFName = string.Concat(this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), empty.ToString());//KR added date time. Ticket 72008
            string str3 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf");
            string TempPdfFileName = string.Concat(this.CompanyID, this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), empty.ToString());//KR added date time. Ticket 72008
            string str4 = string.Concat(str3, "\\", IsConvertedToOrder == false ? this.TOPDFName : TempPdfFileName);
            Session["pdfnameF"] = this.TOPDFName.ToString();
            if (!Directory.Exists(str3))
            {
                Directory.CreateDirectory(str3);
            }

            PdfReader pdfReader = new PdfReader(str2);

            this.PDFToURL = string.Concat(this.PDFToURL, this.AccountID, "/pdf/", IsConvertedToOrder == false ? this.TOPDFName : TempPdfFileName);
            FileStream fileStream = new FileStream(str4, FileMode.Create);
            iTextSharp.text.Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(1);
            PdfStamper pdfStamper = null;
            pdfStamper = new PdfStamper(pdfReader, fileStream);
            PdfContentByte overContent = pdfStamper.GetOverContent(1);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            Convert.ToInt32(binaryReader.BaseStream.Length);
            Dictionary<string, string> info = null;
            if (pdfReader.Info == null)
            {
                info.Add("Title", this.TemplateName);
                info.Add("Author", this.TemplateName);
                info.Add("Producer", "Eprint_System");
                info.Add("Subject", string.Concat(this.PriceCatID, "_", this.TemplateName));
                info.Add("Creator", this.SystemName);
                date = DateTime.Now.Date;
                info.Add("AddCreationDate", date.ToString());
                date = DateTime.Now.Date;
                info.Add("ModDate", date.ToString());
                info.Add("Keywords", "Eprint_User");
                pdfStamper.MoreInfo = info;
            }
            else if (pdfReader.Info.Count <= 0)
            {
                info = pdfReader.Info;
                info.Add("Title", this.TemplateName);
                info.Add("Author", this.TemplateName);
                info.Add("Producer", "Eprint_System");
                info.Add("Subject", string.Concat(this.PriceCatID, "_", this.TemplateName));
                info.Add("Creator", this.SystemName);
                date = DateTime.Now.Date;
                info.Add("AddCreationDate", date.ToString());
                date = DateTime.Now.Date;
                info.Add("ModDate", date.ToString());
                info.Add("Keywords", "Eprint_User");
                pdfStamper.MoreInfo = info;
            }
            else
            {
                info = pdfReader.Info;
                info.Remove("Title");
                info.Remove("Subject");
                info.Remove("Keywords");
                info.Remove("Author");
                info.Remove("Creator");
                info.Remove("ModDate");
                info.Remove("AddCreationDate");
                info.Remove("Producer");
                info.Add("Title", this.TemplateName);
                info.Add("Author", this.TemplateName);
                info.Add("Producer", "Eprint_System");
                info.Add("Subject", string.Concat(this.PriceCatID, "_", this.TemplateName));
                info.Add("Creator", this.SystemName);
                date = DateTime.Now.Date;
                info.Add("AddCreationDate", date.ToString());
                date = DateTime.Now.Date;
                info.Add("ModDate", date.ToString());
                info.Add("Keywords", "Eprint_User");
                pdfStamper.MoreInfo = info;
            }
            str = Convert.ToInt32(pageSizeWithRotation.Height).ToString();
            str1 = pageSizeWithRotation.Width.ToString();
            int num1 = 1;
            foreach (DataRow dataRow in templateData.Tables[0].Rows)
            {
                try
                {
                    string upper = dataRow["DefaultContent"].ToString();
                    string str5 = dataRow["Capitalize"].ToString();
                    string str6 = dataRow["ImageURl"].ToString();
                    string str7 = dataRow["OriginalImageName"].ToString();
                    string str8 = dataRow["EditedImageName"].ToString();
                    string str9 = dataRow["FieldType"].ToString();
                    bool flag = Convert.ToBoolean(dataRow["IsFromBackEnd"]);
                    double num2 = Convert.ToDouble(dataRow["Indent"]);
                    dataRow["CompanyID"].ToString();
                    bool flag1 = Convert.ToBoolean(dataRow["Visibility"]);
                    string str10 = dataRow["fontfamily"].ToString();
                    double num3 = Convert.ToDouble(dataRow["fontsize"]);
                    string str11 = dataRow["fontweight"].ToString();
                    string str12 = dataRow["fontstyle"].ToString();
                    double num4 = Convert.ToDouble(dataRow["width"]);
                    double num5 = Convert.ToDouble(dataRow["height"]);
                    this.MmToPoint((float)num4);
                    this.MmToPoint((float)num5);
                    string str13 = dataRow["ExceedWidth"].ToString();
                    double num6 = (dataRow["PixelWidth"].ToString().Trim().Length > 0 ? Convert.ToDouble(dataRow["PixelWidth"]) : 0);
                    double num7 = Convert.ToDouble(dataRow["MaxWidth"]);
                    double num8 = Convert.ToDouble(dataRow["MaxHeight"]);
                    string str14 = dataRow["ExceedImage"].ToString();
                    string str15 = dataRow["ExceedHeight"].ToString();
                    bool flag2 = Convert.ToBoolean(dataRow["IsCropFromTop"]);
                    Convert.ToBoolean(dataRow["IsCropped"]);
                    bool flag3 = Convert.ToBoolean(dataRow["isDisplayonPDf"]);
                    double num9 = Convert.ToDouble(dataRow["Positionx"]);
                    double num10 = Convert.ToDouble(dataRow["Positiony"]);
                    string str16 = dataRow["ImageLocation"].ToString();
                    double num11 = Convert.ToDouble(dataRow["FieldLeft"]);
                    if (str9.Trim().ToLower() == "image" && str14 == "P")
                    {
                        if (str16 == "TL")
                        {
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str16 == "TC")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str16 == "TR")
                        {
                            num9 = num9 + Math.Abs(num4 - num7);
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str16 == "CL")
                        {
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str16 == "C")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str16 == "CR")
                        {
                            num9 = num9 + Math.Abs(num4 - num7);
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str16 != "BL")
                        {
                            if (str16 == "BC")
                            {
                                num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            }
                            else if (str16 != "BR")
                            {
                                num10 = num10 + Math.Abs(num5 - num8);
                            }
                            else
                            {
                                num9 = num9 + Math.Abs(num4 - num7);
                            }
                        }
                        if (str14 == "P")
                        {
                            num4 = num7;
                            num5 = num8;
                        }
                    }
                    dataRow["LabelActualFontName"].ToString();
                    string str17 = dataRow["LabelFontExtension"].ToString();
                    dataRow["ActualFontFamilyName"].ToString();
                    string str18 = dataRow["FontExtension"].ToString();
                    double num12 = Convert.ToDouble(dataRow["LabelFontSize"]);
                    string str19 = dataRow["ManualTracking"].ToString();
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays = str19.Split(chrArray);
                    double num13 = 0;
                    string str20 = "+";
                    string str21 = "pt";
                    if ((int)strArrays.Length != 1)
                    {
                        str20 = strArrays[0];
                        num13 = Convert.ToDouble(strArrays[1]);
                        str21 = strArrays[2];
                    }
                    else
                    {
                        num13 = Convert.ToDouble(dataRow["ManualTracking"]);
                        str20 = "+";
                        str21 = "pt";
                    }
                    double num14 = Convert.ToDouble(dataRow["LineSpacing"]);
                    double num15 = Convert.ToDouble(dataRow["MaxShrink"]);
                    string str22 = dataRow["BackgroundColor"].ToString();
                    long num16 = Convert.ToInt64(dataRow["GroupID"]);
                    string str23 = dataRow["GroupOrientation"].ToString();
                    string str24 = dataRow["Labels"].ToString();
                    string lower = dataRow["Value"].ToString();
                    dataRow["LabelStyle"].ToString();
                    string str25 = dataRow["LabelPosition"].ToString();
                    double num17 = Convert.ToDouble(dataRow["CustomLeft"]);
                    double num18 = Convert.ToDouble(dataRow["CustomTop"]);
                    double num19 = Convert.ToDouble(dataRow["CustomRight"]);
                    this.LabelColor = dataRow["LabelColor"].ToString();
                    this.Label_FontStyle = dataRow["LabelFontStyle"].ToString();
                    bool flag4 = Convert.ToBoolean(dataRow["SpotColor"]);
                    string str26 = dataRow["SpotColorRef"].ToString();
                    double num20 = Convert.ToDouble(dataRow["RotateAngle"]);
                    string str27 = dataRow["textAlign"].ToString();
                    if (str27.Trim().Length == 0)
                    {
                        str27 = "left";
                    }
                    double num21 = 0;
                    double num22 = 0;
                    double num23 = 0;
                    double num24 = 0;
                    double num25 = 0;
                    float single = 0f;
                    float single1 = 0f;
                    float single2 = 0f;
                    float single3 = 0f;
                    float single4 = 0f;
                    try
                    {
                        num21 = Convert.ToDouble(dataRow["C"]);
                        num22 = Convert.ToDouble(dataRow["M"]);
                        num23 = Convert.ToDouble(dataRow["Y"]);
                        num24 = Convert.ToDouble(dataRow["K"]);
                        num25 = Convert.ToDouble(dataRow["Tint"]);
                    }
                    catch
                    {
                    }
                    single = (float)num21;
                    single1 = (float)num22;
                    single2 = (float)num23;
                    single3 = (float)num24;
                    single4 = (float)num25 / 100f;
                    num1 = Convert.ToInt32(dataRow["pagenumber"]);
                    overContent = pdfStamper.GetOverContent(num1);
                    double num26 = 0;
                    double num27 = num10;
                    if (str9.Trim().ToLower() == "textblock")
                    {
                        str9 = "1";
                    }
                    if (str9.Trim().ToLower() == "paragraph")
                    {
                        str9 = "2";
                    }
                    if (str9.Trim().ToLower() == "image")
                    {
                        str9 = "3";
                    }
                    if (str9 == "1")
                    {
                        num26 = Convert.ToDouble(dataRow["OffsetLeft"]);
                        if (str25 == "Attached")
                        {
                        }
                        if (num16 == (long)0)
                        {
                            if (str27 == "Center")
                            {
                                num9 = num26;
                            }
                            if (str27 == "Right")
                            {
                                num9 = num26;
                            }
                            if (str24 != "None" && str25 != "Attached")
                            {
                                num9 = Convert.ToDouble(dataRow["Positionx"]);
                            }
                            if (str24 != "None" && str25 == "customLeft" && str27 == "Center")
                            {
                                num9 = Convert.ToDouble(dataRow["OffsetLeft"]);
                            }
                        }
                        else if (str23 == "Horizontal")
                        {
                            if (str27 == "Right" && str25 != "Attached")
                            {
                                num9 = num26;
                            }
                            if (str27 == "Right" && str25 == "Attached" && num16 > (long)0)
                            {
                                num9 = ((this.TemplateID == "282" || this.TemplateID == "308") && this.SystemName.Trim().ToLower() == "quickcorporate" ? num11 : num26);
                            }
                        }
                    }
                    float point = this.MmToPoint((float)num4);
                    float point1 = this.MmToPoint((float)num5);
                    float point2 = this.MmToPoint((float)num4);
                    float point3 = this.MmToPoint((float)num5);
                    float point4 = this.MmToPoint((float)num9);
                    float point5 = this.MmToPoint((float)num10);
                    Convert.ToInt32(Convert.ToDouble(dataRow["R"]));
                    Convert.ToInt32(Convert.ToDouble(dataRow["G"]));
                    Convert.ToInt32(Convert.ToDouble(dataRow["B"]));
                    float single5 = (float)num15;
                    float single6 = (float)num13;
                    float point6 = this.MmToPoint((float)num2);
                    float single7 = (float)num20;
                    float single8 = point4 + point2;
                    float single9 = point5 + point3;
                    float single10 = point4 + point;
                    float single11 = point5 - point1;
                    if (str5 == "First Cap")
                    {
                        bool flag5 = false;
                        char[] charArray = upper.ToCharArray();
                        string str28 = "";
                        for (int i = 0; i < (int)charArray.Length; i++)
                        {
                            if (flag5 || i == 0)
                            {
                                str28 = string.Concat(str28, charArray[i].ToString().ToUpper());
                                flag5 = false;
                            }
                            else
                            {
                                str28 = string.Concat(str28, charArray[i].ToString().ToLower());
                            }
                            if (charArray[i] == ' ' || charArray[i] == '\r' || charArray[i] == '\n')
                            {
                                flag5 = true;
                            }
                        }
                        upper = str28;
                    }
                    if (str5 == "FirstCapAllowCaps")
                    {
                        bool flag6 = false;
                        char[] charArray1 = upper.ToCharArray();
                        string str29 = "";
                        for (int j = 0; j < (int)charArray1.Length; j++)
                        {
                            if (flag6 || j == 0)
                            {
                                str29 = string.Concat(str29, charArray1[j].ToString().ToUpper());
                                flag6 = false;
                            }
                            else
                            {
                                str29 = string.Concat(str29, charArray1[j].ToString());
                            }
                            if (charArray1[j] == ' ' || charArray1[j] == '\r' || charArray1[j] == '\n')
                            {
                                flag6 = true;
                            }
                        }
                        upper = str29;
                    }
                    if (str5 == "All Caps")
                    {
                        upper = upper.ToUpper();
                    }
                    if (str5 == "All Lower")
                    {
                        upper = upper.ToLower();
                    }
                    if (str5 == "InitCap")
                    {
                        char[] chrArray1 = upper.ToCharArray();
                        string upper1 = chrArray1[0].ToString().ToUpper();
                        string lower1 = "";
                        for (int k = 1; k < (int)chrArray1.Length; k++)
                        {
                            lower1 = string.Concat(lower1, chrArray1[k].ToString());
                        }
                        lower1 = lower1.ToLower();
                        upper = string.Concat(upper1, lower1);
                    }
                    if (str9.Trim().Length > 0 && flag1)
                    {
                        if (Convert.ToInt32(str9) == 3)
                        {
                            bool flag7 = Convert.ToBoolean(dataRow["IsPDF"]);
                            string str30 = dataRow["UserType"].ToString();
                            if (!flag7)
                            {
                                string.Concat(this.ImageToPath, "HorizontalLine.gif");
                                if (str6 != "noimage.jpg" && !flag3)
                                {
                                    if (!flag2 && flag)
                                    {
                                        str6 = str7;
                                        if (str8 != "")
                                        {
                                            str6 = str8;
                                        }
                                    }
                                    if (flag)
                                    {
                                        str6 = (str8 == "" ? str7 : str8);
                                        str6 = string.Concat(this.ImageFromPath, this.CompanyID, "\\Images\\", str6);
                                    }
                                    else
                                    {
                                        if (str8 != "")
                                        {
                                            str6 = str8;
                                        }
                                        else if (!flag2)
                                        {
                                            str6 = str7;
                                        }
                                        str6 = string.Concat(this.ImagePathFromFrontEnd, this.TemplateID, "\\Images\\", str6);
                                    }
                                    if (str22 != "")
                                    {
                                        iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(str6);
                                        instance.SetDpi(300, 300);
                                        instance.SetAbsolutePosition(0f, 0f);
                                        float single12 = (float)Convert.ToDouble(str) + (float)this.CropMarkHeight * 2f;
                                        float single13 = (float)Convert.ToDouble(str1) + (float)this.CropMarkWidth * 2f;
                                        instance.ScaleAbsolute(single13, single12);
                                        overContent.AddImage(instance);
                                    }
                                    else
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(str6);
                                        image.SetDpi(300, 300);
                                        image.SetAbsolutePosition(point4, point5);
                                        if (image.Height >= image.Width)
                                        {
                                            if (str14 != "S")
                                            {
                                                float height = 0f;
                                                height = (float)point1 / image.Height;
                                                image.ScalePercent(height * 100f);
                                                image.ScaleAbsolute(single10 - point4, point5 - single11);
                                            }
                                            else
                                            {
                                                image.ScalePercent(100f);
                                                image.ScaleAbsolute(single10 - point4, point5 - single11);
                                            }
                                        }
                                        else if (str14 != "S")
                                        {
                                            float width = 0f;
                                            width = (float)point / image.Width;
                                            image.ScalePercent(width * 100f);
                                            image.ScaleAbsolute(single10 - point4, point5 - single11);
                                        }
                                        else
                                        {
                                            image.ScalePercent(100f);
                                            image.ScaleAbsolute(single10 - point4, point5 - single11);
                                        }
                                        overContent.SaveState();
                                        if (single7 > 0f)
                                        {
                                            iTextSharp.awt.geom.AffineTransform affineTransform = new iTextSharp.awt.geom.AffineTransform();
                                            float point7 = this.MmToPoint((float)Convert.ToDouble(dataRow["MaxHeight"]));
                                            float point8 = this.MmToPoint((float)Convert.ToDouble(dataRow["height"]));
                                            if (point8 > point7)
                                            {
                                                point5 = point5 - (point8 - point7);
                                            }
                                            affineTransform.Rotate((double)single7 * 3.14159265358979 / 180, (double)point4, (double)point5);
                                            overContent.Transform(affineTransform);
                                        }
                                        overContent.AddImage(image);
                                        overContent.RestoreState();
                                    }
                                }
                            }
                            else
                            {
                                string str31 = dataRow["PDFCompanyID"].ToString();
                                string str32 = dataRow["PDFUserID"].ToString();
                                string empty1 = string.Empty;
                                string str33 = dataRow["UsedPDFName"].ToString();
                                Convert.ToInt64(dataRow["UsedImageId"].ToString());
                                if (str30.Trim().ToLower() != "admin")
                                {
                                    string[] imagePathFromFrontEnd = new string[] { this.ImagePathFromFrontEnd, "UsersImages\\", str32, "\\pdf\\", str33.Replace(".png", ".pdf") };
                                    empty1 = string.Concat(imagePathFromFrontEnd);
                                }
                                else
                                {
                                    empty1 = string.Concat(this.ImageFromPath, str31, "\\pdf\\", str33.Replace(".png", ".pdf"));
                                }
                                PdfReader pdfReader1 = new PdfReader(empty1, (new ASCIIEncoding()).GetBytes(""));
                                PdfImportedPage importedPage = pdfStamper.GetImportedPage(pdfReader1, 1);
                                float width1 = 0f;
                                float height1 = 0f;
                                width1 = (float)point / importedPage.Width;
                                height1 = (float)point1 / importedPage.Height;
                                Math.Min(width1, height1);
                                overContent.AddTemplate(importedPage, width1, 0f, 0f, height1, point4, point5);
                            }
                        }
                        else if (Convert.ToInt32(str9) != 13 && upper.Trim().ToLower().IndexOf("www.paypal.com") == -1 && str10.Trim().ToLower().IndexOf("barcode39") == -1)
                        {
                            if (str9 == "2")
                            {
                                chrArray = new char[] { '\t' };
                                string[] strArrays1 = upper.Split(chrArray);
                                string empty2 = string.Empty;
                                if ((int)strArrays1.Length > 1)
                                {
                                    for (int l = 0; l < (int)strArrays1.Length; l++)
                                    {
                                        empty2 = string.Concat(empty2, strArrays1[l]);
                                        int length = strArrays1[l].ToString().Length;
                                        int num28 = length / 8;
                                        int num29 = 8 * (num28 + 1) - length;
                                        for (int m = 0; m < num29; m++)
                                        {
                                            empty2 = string.Concat(empty2, " ");
                                        }
                                    }
                                    upper = empty2;
                                }
                            }
                            int num30 = 0;
                            this.objFontStyle = FontStyle.Regular;
                            if (str11.ToLower().Trim() == "bold")
                            {
                                num30 = 1;
                                this.objFontStyle = FontStyle.Bold;
                            }
                            if (str12.ToLower().Trim() == "italic")
                            {
                                num30 = 2;
                                this.objFontStyle = FontStyle.Italic;
                            }
                            if (str11.ToLower().Trim() == "bold" && str12.ToLower().Trim() == "italic")
                            {
                                num30 = 3;
                                this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                            }
                            float single14 = (float)num3;
                            if (str10.Contains("Bold"))
                            {
                                if (num30 == 1)
                                {
                                    num30 = 0;
                                }
                                if (num30 == 3)
                                {
                                    num30 = 2;
                                }
                            }
                            if (str10.Contains("Italic") && num30 == 2)
                            {
                                num30 = 0;
                            }
                            double num31 = (double)single4;
                            if (str10.Contains("Bold"))
                            {
                                if (num30 == 1)
                                {
                                    num30 = 0;
                                }
                                if (num30 == 3)
                                {
                                    num30 = 0;
                                }
                            }
                            if (str10.Contains("Italic") && num30 == 2)
                            {
                                num30 = 0;
                            }
                            Guid guid = Guid.NewGuid();
                            string str34 = guid.ToString().Substring(0, 10);
                            FontFactory.Register(string.Concat(this.FontFilePathForPDF, str18), str34);
                            iTextSharp.text.Font font = null;
                            font = FontFactory.GetFont(str34, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, single14, num30, new CMYKColor(single, single1, single2, single3));
                            PdfSpotColor pdfSpotColor = null;
                            if (flag4)
                            {
                                pdfSpotColor = new PdfSpotColor(str26, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor, single4);
                                font = FontFactory.GetFont(str34, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, single14, num30, new SpotColor(pdfSpotColor, single4));
                            }
                            if ((double)single4 < 1 && !flag4)
                            {
                                PdfSpotColor pdfSpotColor1 = new PdfSpotColor(str26, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor1, single4);
                                overContent.SetColorFill(pdfSpotColor1, single4);
                            }
                            int num32 = 0;
                            if (dataRow["textalign"].ToString().Trim().ToLower() == "left")
                            {
                                num32 = 0;
                            }
                            else if (dataRow["textalign"].ToString().Trim().ToLower() != "center")
                            {
                                num32 = (dataRow["textalign"].ToString().Trim().ToLower() != "right" ? 3 : 2);
                            }
                            else
                            {
                                num32 = 1;
                            }
                            //string[] separators = { "®", "™" };
                            //string separator = "®";
                            //string[] parts = upper.Split(separators, StringSplitOptions.None);

                            //Paragraph pg = new Paragraph();
                            //Chunk chunk = null;

                            //if (!upper.Contains(separator))
                            //    separator = "™";

                            //for (int i = 0; i < parts.Length; i++)

                            //{
                            //    chunk = new Chunk(parts[i], font);
                            //    pg.Add(chunk);
                            //    if (i != parts.Length - 1)
                            //    {
                            //        iTextSharp.text.Font fontLocal = null;
                            //        fontLocal = FontFactory.GetFont(str34, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, single14 - 3, num30, new CMYKColor(single, single1, single2, single3));

                            //        chunk = new Chunk(separator, fontLocal).SetTextRise(3);
                            //        pg.Add(chunk);
                            //    }

                            //}



                            //ColumnText columnText = new ColumnText(overContent);
                            //Phrase phrase = new Phrase(string.Empty);
                            //Phrase phrase1 = new Phrase(string.Empty);


                            Paragraph pg = new Paragraph();

                            ////chunk = new Chunk(upper, font);
                            //phrase.Add(0, pg);
                            ColumnText columnText = new ColumnText(overContent);
                            Phrase phrase = new Phrase(string.Empty);
                            Phrase phrase1 = new Phrase(string.Empty);
                            Chunk chunk = null;
                            chunk = new Chunk(upper, font);
                            phrase.Add(0, chunk);
                            //pg.Add(chunk);
                            if (str13 == "Track")
                            {
                                single5 = this.PixelToPoint((float)num6) / 100f;
                                if ((double)single5 == 0)
                                {
                                    chunk.SetCharacterSpacing(0f);
                                }
                                else
                                {
                                    chunk.SetCharacterSpacing(single5);
                                    single6 = single6 + single5;
                                }
                            }
                            if ((double)single6 > 0)
                            {
                                if (str20 == "+" && str21 == "pt")
                                {
                                    chunk.SetCharacterSpacing(single6);
                                    if (str9 == "1")
                                    {
                                        var width = this.MmToPoint((float)num7);
                                        CalculateKerning(chunk, width);
                                    }

                                    var match = upper.IndexOfAny("™®".ToCharArray()) != -1;
                                    if (match)
                                    {
                                        phrase = CheckSpecialCharacterInChunk(upper, phrase, chunk);
                                    }


                                }
                                if (str20 == "+" && str21 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(single6);

                                    if (str9 == "1")
                                    {
                                        var width = this.MmToPoint((float)num7);
                                        CalculateKerning(chunk, width);
                                    }
                                    var match = upper.IndexOfAny("™®".ToCharArray()) != -1;


                                    if (match)
                                    {
                                        phrase = CheckSpecialCharacterInChunk(upper, phrase, chunk);
                                    }
                                }
                                if (str20 == "-" && str21 == "pt")
                                {
                                    chunk.SetCharacterSpacing(-single6);
                                    if (str9 == "1")
                                    {
                                        var width = this.MmToPoint((float)num7);
                                        CalculateKerning(chunk, width);
                                    }
                                    var match = upper.IndexOfAny("™®".ToCharArray()) != -1;


                                    if (match)
                                    {
                                        phrase = CheckSpecialCharacterInChunk(upper, phrase, chunk);
                                    }


                                }
                                if (str20 == "-" && str21 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(-single6);
                                    if (str9 == "1")
                                    {
                                        var width = this.MmToPoint((float)num7);
                                        CalculateKerning(chunk, width);
                                    }
                                    var match = upper.IndexOfAny("™®".ToCharArray()) != -1;


                                    if (match)
                                    {
                                        CheckSpecialCharacterInChunk(upper, phrase, chunk);
                                    }
                                }
                            }
                            if (str9 == "2" && str15.ToLower() == "expand height")
                            {
                                point5 = point5 - float.Parse(str);
                            }
                            if (str9 == "1")
                            {
                                if (str24 == "None")
                                {
                                    point4 = this.MmToPoint((float)num26);
                                    if (point6 > 0f)
                                    {
                                        if (num32 == 1)
                                        {
                                            point4 = point4 + point6 / 2f;
                                        }
                                        else if (num32 == 0)
                                        {
                                            point4 = point4 + point6;
                                        }
                                    }
                                    if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                    {
                                        ColumnText.ShowTextAligned(overContent, num32, phrase, point4, point5, single7);
                                    }
                                    else
                                    {
                                        ColumnText.ShowTextAligned(overContent, num32, phrase, point4, point5, single7);
                                    }
                                }
                                else
                                {
                                    if (upper == string.Empty)
                                    {
                                        lower = string.Empty;
                                    }
                                    double num33 = 0;
                                    double num34 = 0;
                                    double num35 = 0;
                                    double num36 = 100;
                                    bool flag8 = false;
                                    string str35 = "";
                                    double num37 = 0;
                                    float single15 = 0f;
                                    float single16 = 0f;
                                    float single17 = 0f;
                                    float single18 = 100f;
                                    float single19 = 0f;
                                    bool flag9 = false;
                                    if (this.LabelColor != "")
                                    {
                                        DataSet labelColor = this.GetLabelColor();
                                        DataTable dataTable = labelColor.Tables[0];
                                        foreach (DataRow row1 in labelColor.Tables[0].Rows)
                                        {
                                            try
                                            {
                                                num33 = Convert.ToDouble(row1["C"]);
                                                num34 = Convert.ToDouble(row1["M"]);
                                                num35 = Convert.ToDouble(row1["Y"]);
                                                num36 = Convert.ToDouble(row1["K"]);
                                                Convert.ToInt32(Convert.ToDouble(row1["R"]));
                                                Convert.ToInt32(Convert.ToDouble(row1["G"]));
                                                Convert.ToInt32(Convert.ToDouble(row1["B"]));
                                                Convert.ToInt32(Convert.ToDouble(row1["A"]));
                                                flag8 = Convert.ToBoolean(row1["SpotColor"]);
                                                str35 = row1["SpotColorRef"].ToString();
                                                num37 = Convert.ToDouble(row1["Tint"]);
                                            }
                                            catch
                                            {
                                            }
                                            single15 = (float)num33 / 100f;
                                            single16 = (float)num34 / 100f;
                                            single17 = (float)num35 / 100f;
                                            single18 = (float)num36 / 100f;
                                            single19 = (float)num37 / 100f;
                                            flag9 = true;
                                        }
                                    }
                                    if (this.Label_FontStyle != "")
                                    {
                                        DataSet labelFontStyle = this.GetLabelFontStyle();
                                        DataTable item1 = labelFontStyle.Tables[0];
                                        string str36 = "";
                                        foreach (DataRow dataRow1 in labelFontStyle.Tables[0].Rows)
                                        {
                                            string str37 = dataRow1["ManualTracking"].ToString();
                                            chrArray = new char[] { ',' };
                                            string[] strArrays2 = str37.Split(chrArray);
                                            str36 = dataRow1["Capitalize"].ToString();
                                            if ((int)strArrays2.Length != 1)
                                            {
                                                string str38 = strArrays2[0];
                                                Convert.ToDouble(strArrays2[1]);
                                                string str39 = strArrays2[2];
                                            }
                                            else
                                            {
                                                Convert.ToDouble(dataRow1["ManualTracking"]);
                                            }
                                            if (str36 == "First Cap")
                                            {
                                                bool flag10 = false;
                                                char[] charArray2 = lower.ToCharArray();
                                                string str40 = "";
                                                for (int n = 0; n < (int)charArray2.Length; n++)
                                                {
                                                    if (flag10 || n == 0)
                                                    {
                                                        str40 = string.Concat(str40, charArray2[n].ToString().ToUpper());
                                                        flag10 = false;
                                                    }
                                                    else
                                                    {
                                                        str40 = string.Concat(str40, charArray2[n].ToString().ToLower());
                                                    }
                                                    if (charArray2[n] == ' ' || charArray2[n] == '\r')
                                                    {
                                                        flag10 = true;
                                                    }
                                                }
                                                lower = str40;
                                            }
                                            if (str36 == "All Caps")
                                            {
                                                lower = lower.ToUpper();
                                            }
                                            if (str36 == "All Lower")
                                            {
                                                lower = lower.ToLower();
                                            }
                                            if (str36 != "InitCap")
                                            {
                                                continue;
                                            }
                                            char[] chrArray2 = lower.ToCharArray();
                                            string upper2 = chrArray2[0].ToString().ToUpper();
                                            string lower2 = "";
                                            for (int o = 1; o < (int)chrArray2.Length; o++)
                                            {
                                                lower2 = string.Concat(lower2, chrArray2[o].ToString());
                                            }
                                            lower2 = lower2.ToLower();
                                            lower = string.Concat(upper2, lower2);
                                        }
                                    }
                                    if (num12 == 0)
                                    {
                                        num12 = (double)single14;
                                    }
                                    guid = Guid.NewGuid();
                                    string str41 = guid.ToString().Substring(0, 10);
                                    FontFactory.Register(string.Concat(this.FontFilePathForPDF, str17), str41);
                                    iTextSharp.text.Font font1 = null;
                                    font1 = FontFactory.GetFont(str41, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, (float)num12, num30, new CMYKColor(single15, single16, single17, single18));
                                    PdfSpotColor pdfSpotColor2 = null;
                                    if (flag8)
                                    {
                                        pdfSpotColor2 = new PdfSpotColor(str35, new CMYKColor(single15, single16, single17, single18));
                                        overContent.SetColorStroke(pdfSpotColor2, single19);
                                        font1 = FontFactory.GetFont(str41, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, (float)num12, num30, new SpotColor(pdfSpotColor2, single19));
                                    }
                                    if ((double)single19 < 1 && !flag8 && flag9)
                                    {
                                        PdfSpotColor pdfSpotColor3 = new PdfSpotColor(str35, new CMYKColor(single15, single16, single17, single18));
                                        overContent.SetColorStroke(pdfSpotColor3, single19);
                                        overContent.SetColorFill(pdfSpotColor3, single19);
                                    }
                                    phrase1 = new Phrase()
                                {
                                    { 0, new Chunk(lower, font1) }
                                };
                                    chunk = null;
                                    phrase = null;
                                    phrase = new Phrase();
                                    chunk = new Chunk(upper, font);
                                    phrase.Add(0, chunk);
                                    if (str13 == "Track")
                                    {
                                        single5 = this.PixelToPoint((float)num6) / 100f;
                                        if ((double)single5 == 0)
                                        {
                                            chunk.SetCharacterSpacing(0f);
                                        }
                                        else
                                        {
                                            chunk.SetCharacterSpacing(single5);
                                        }
                                    }
                                    if ((double)single6 > 0)
                                    {
                                        if (str20 == "+" && str21 == "pt")
                                        {
                                            chunk.SetCharacterSpacing(single6);
                                            if (str9 == "1")
                                            {
                                                var width = this.MmToPoint((float)num7);
                                                CalculateKerning(chunk, width);
                                            }
                                        }
                                        if (str20 == "+" && str21 == "mm")
                                        {
                                            chunk.SetCharacterSpacing(single6);
                                            if (str9 == "1")
                                            {
                                                var width = this.MmToPoint((float)num7);
                                                CalculateKerning(chunk, width);
                                            }
                                        }
                                        if (str20 == "-" && str21 == "pt")
                                        {
                                            chunk.SetCharacterSpacing(-single6);
                                            if (str9 == "1")
                                            {
                                                var width = this.MmToPoint((float)num7);
                                                CalculateKerning(chunk, width);
                                            }
                                        }
                                        if (str20 == "-" && str21 == "mm")
                                        {
                                            chunk.SetCharacterSpacing(-single6);
                                            if (str9 == "1")
                                            {
                                                var width = this.MmToPoint((float)num7);
                                                CalculateKerning(chunk, width);
                                            }
                                        }
                                    }
                                    if (num17 >= 0 && str25 == "customLeft")
                                    {
                                        this.PixelToPoint((float)num17);
                                        float point9 = this.MmToPoint((float)num17);
                                        if (num32 == 0)
                                        {
                                            point4 = this.MmToPoint((float)num26);
                                            if (point6 > 0f)
                                            {
                                                point4 = point4 + point6;
                                            }
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, point4 - point9, point5, single7);
                                            if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                            {
                                                ColumnText.ShowTextAligned(overContent, 0, phrase, point4, point5, single7);
                                            }
                                            else
                                            {
                                                ColumnText.ShowTextAligned(overContent, 0, phrase, point4, point5, single7);
                                            }
                                        }
                                        if (num32 == 1)
                                        {
                                            point4 = this.MmToPoint((float)num26);
                                            if (point6 > 0f)
                                            {
                                                point4 = point4 + point6 / 2f;
                                            }
                                            if (num13 > 0)
                                            {
                                                point4 = point4 + (float)(num13 / 2);
                                            }
                                            float width2 = point4 - (ColumnText.GetWidth(phrase) + point9) / 2f;
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width2, point5, single7);
                                            if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                            {
                                                ColumnText.ShowTextAligned(overContent, 0, phrase, width2 + point9 - single6, point5, single7);
                                            }
                                            else
                                            {
                                                ColumnText.ShowTextAligned(overContent, 0, phrase, width2 + point9 + single6, point5, single7);
                                            }
                                        }
                                        if (num32 == 2)
                                        {
                                            point4 = this.MmToPoint((float)num26);
                                            if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                            {
                                                ColumnText.ShowTextAligned(overContent, 2, phrase, point4, point5, single7);
                                            }
                                            else
                                            {
                                                ColumnText.ShowTextAligned(overContent, 2, phrase, point4, point5, single7);
                                            }
                                            float width3 = point4 - (ColumnText.GetWidth(phrase) + point9);
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width3, point5, single7);
                                        }
                                    }
                                    // if (num19 >= 0 && str25 == "customRight") change by Amin
                                    if (str25 == "customRight")
                                    {
                                        float point10 = this.MmToPoint((float)num19);
                                        point4 = this.MmToPoint((float)num26);
                                        if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                        {
                                            ColumnText.ShowTextAligned(overContent, 2, phrase, point4, point5, single7);
                                        }
                                        else
                                        {
                                            ColumnText.ShowTextAligned(overContent, 2, phrase, point4, point5, single7);
                                        }
                                        float single20 = point4 - point10;
                                        ColumnText.ShowTextAligned(overContent, 2, phrase1, single20, point5, single7);
                                    }
                                    if (num18 >= 0 && str25 == "customTop")
                                    {
                                        if (point6 > 0f)
                                        {
                                            if (num32 == 1)
                                            {
                                                point4 = point4 + point6;
                                            }
                                            else if (num32 == 0)
                                            {
                                                point4 = point4 + point6;
                                            }
                                        }
                                        float point11 = this.MmToPoint((float)num18);
                                        ColumnText.ShowTextAligned(overContent, num32, phrase, point4, point5, single7);
                                        phrase1 = new Phrase(lower, font1);
                                        columnText.Go();
                                        float ascentPoint = font1.BaseFont.GetAscentPoint(lower, font1.Size) - font1.BaseFont.GetDescentPoint(lower, font1.Size);
                                        if (num32 == 2)
                                        {
                                            float width4 = point4 - ColumnText.GetWidth(phrase);
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width4, point5 + point11 + ascentPoint + this.PixelToPoint(2f), single7);
                                        }
                                        else if (num32 != 1)
                                        {
                                            ColumnText.ShowTextAligned(overContent, num32, phrase1, point4, point5 + point11 + ascentPoint + this.PixelToPoint(2f), single7);
                                        }
                                        else
                                        {
                                            float width5 = point4 - ColumnText.GetWidth(phrase) / 2f;
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width5, point5 + point11 + ascentPoint + this.PixelToPoint(2f), single7);
                                        }
                                    }
                                    else if (str25 == "Attached")
                                    {
                                        point4 = this.MmToPoint((float)num26);
                                        if (point6 > 0f)
                                        {
                                            if (num32 == 1)
                                            {
                                                point4 = point4 + point6 / 2f;
                                            }
                                            else if (num32 == 0)
                                            {
                                                point4 = point4 + point6;
                                            }
                                        }
                                        if (num32 == 1 && str23 == "Horizontal" && str25 == "Attached" && num16 > (long)0)
                                        {
                                            num32 = 0;
                                        }
                                        phrase1.Add(phrase);
                                        if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                        {
                                            ColumnText.ShowTextAligned(overContent, num32, phrase1, point4, point5, single7);
                                        }
                                        else
                                        {
                                            ColumnText.ShowTextAligned(overContent, num32, phrase1, point4, point5, single7);
                                        }
                                    }
                                }
                            }
                            else if (str9 == "2")
                            {
                                float point12 = (float)this.MmToPoint((float)num14);
                                if (point6 > 0f)
                                {
                                    point4 = point4 + point6;
                                }
                                if (point12 > 0f)
                                {
                                    phrase = new Phrase(point12);
                                    phrase.Add(chunk);
                                    if (num32 == 1)
                                    {
                                        num27 = num27 / 2;
                                    }
                                    if (num32 == 0)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4, point5, single8, single9 + (point12 - single14), single14, num32);
                                    }
                                    else if (num32 == 1)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4 - point2 / 2f, point5, single8 - point2 / 2f, single9 + (point12 - single14), single14, num32);
                                    }
                                    else if (num32 == 2)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4 - point2, point5, single8 - point2, single9 + (point12 - single14), single14, num32);
                                    }
                                    columnText.SetLeading(point12, 0f);
                                }
                                else if (num32 == 0)
                                {
                                    columnText.SetSimpleColumn(phrase, point4, point5, single8, single9 + 2f, single14, num32);
                                }
                                else if (num32 == 1)
                                {
                                    columnText.SetSimpleColumn(phrase, point4 - point2 / 2f, point5, single8 - point2 / 2f, single9 + 2f, single14, num32);
                                }
                                else if (num32 == 2)
                                {
                                    columnText.SetSimpleColumn(phrase, point4 - point2, point5, single8 - point2, single9 + 2f, single14, num32);
                                }
                                overContent.SaveState();
                                if (single7 > 0f)
                                {
                                    iTextSharp.awt.geom.AffineTransform affineTransform1 = new iTextSharp.awt.geom.AffineTransform();
                                    affineTransform1.Rotate((double)single7 * 3.14159265358979 / 180, (double)point4, (double)point5);
                                    overContent.Transform(affineTransform1);
                                }
                                if (Convert.ToBoolean(Convert.ToInt16(dataRow["IsJustify"].ToString())))
                                {
                                    columnText.Alignment = 3;
                                }
                                columnText.Go();
                                overContent.RestoreState();
                            }
                            try
                            {
                                columnText.Go();
                                overContent.EndText();
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            pdfStamper.Close();
            pdfReader.Close();
            fileStream.Close();
            pdfReader.Close();
            fileStream.Dispose();
            if (this.isAllowWaterMark)
            {
                FileInfo fileInfo = new FileInfo(str4);
                File.WriteAllBytes(str4, this.CreateWaterMark(fileInfo, this.WaterMarkText));
            }
            if (this.CropMarkHeight <= 0)
            {
                double cropMarkWidth = this.CropMarkWidth;
            }
            if (this.PDFToURL.Trim().ToLower().Contains(".pdf") && this.isAllowPDFPreviews)
            {
                this._finalpdfpath = string.Concat(this.PDFToURL, "#zoom=100");
            }
        }

        public double GetHypotenuseAngleInDegreesFrom(double opposite, double adjacent)
        {
            return Math.Atan2(opposite, adjacent) * 57.2957795130823;
        }

        public DataSet GetLabelColor()
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.CompanyID), new SqlParameter("@ColorName", this.LabelColor) };
            return EditableTemplate.DataAccessLayer.SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_GetLabelColor_ForPDF", sqlParameter);
        }

        public DataSet GetLabelFontStyle()
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", this.CompanyID), new SqlParameter("@LabelFontStyle", this.Label_FontStyle) };
            return EditableTemplate.DataAccessLayer.SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_GetFontStyle_ForPDF", sqlParameter);
        }

        public DataSet GetTemplateData()
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", this.TemplateID), new SqlParameter("@CartItemID", this.CartItemID), new SqlParameter("@IsOverPrintForAdmin", false) };
            return EditableTemplate.DataAccessLayer.SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_Generate_PDF_HTML5", sqlParameter);
        }

        private double HeightForMultiply(string ImageHeight, string PDFHeight, double top)
        {
            top = top / Convert.ToDouble(ImageHeight) * Convert.ToDouble(PDFHeight);
            return top;
        }

        public float MmToPoint(float mm)
        {
            return mm * 2.83464575f;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            var approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
            var isReapproval = base.Return_ApprovalSystem_Settings("reapproval");
            var CartItemID = Convert.ToInt32(base.Request.Params["CartItemID"]);



            var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
            if (table.Rows.Count > 0)
            {
                var IsConvertedToOrder = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
                if (IsConvertedToOrder == true)
                    addtocart.Text = "Confirm And Go to Order Detail";
            }




            languageClass _languageClass = new languageClass();
            if (ConnectionClass.AccountID == null || !(ConnectionClass.AccountID != ""))
            {
                this.AccountID = "0";
            }
            else
            {
                this.AccountID = Convert.ToString(ConnectionClass.AccountID);
            }
            if (ConnectionClass.SystemName == null || !(ConnectionClass.SystemName != ""))
            {
                this.SystemName = "";
            }
            else
            {
                this.SystemName = ConnectionClass.SystemName.ToString();
            }
            if (base.Request.QueryString["CompanyID"].ToString() == "")
            {
                this.CompanyID = "0";
            }
            else
            {
                this.CompanyID = base.Request.QueryString["CompanyID"];
            }
            if (base.Request.QueryString["ID"].ToString() == "")
            {
                this.PriceCatID = "0";
            }
            else
            {
                this.PriceCatID = base.Request.QueryString["ID"];
            }
            if (base.Request.QueryString["CartItemID"].ToString() == "")
            {
                this.CartItemID = "0";
            }
            else
            {
                this.CartItemID = base.Request.QueryString["CartItemID"];
            }
            if (base.Request.QueryString["PreviewType"].ToString() == "")
            {
                this.PreviewType = "pdf";
            }
            else
            {
                this.PreviewType = base.Request.QueryString["PreviewType"];
            }
            if (base.Request.QueryString != null && base.Request.QueryString["ID"] != "0")
            {
                DataTable dataTable = ProductBasePage.WS_CategoryName_SubCategory_Select_for_Navigation(Convert.ToInt32(this.PriceCatID), 0, 0);
                foreach (DataRow row in dataTable.Rows)
                {
                    string str = row["PriceCatalogueCategoryName"].ToString();
                    string empty = string.Empty;
                    empty = (row["CatalogueName"].ToString().Length <= 35 ? row["CatalogueName"].ToString() : string.Concat(row["CatalogueName"].ToString().Trim().Substring(0, 35), "..."));
                    BaseClass baseClass = new BaseClass();
                    Label label = (Label)base.Master.FindControl("lblPathLink");
                    object[] sitePath = new object[] { "<a Class='floatLeft TextUnderline'  href ='", BaseClass.SitePath, "Default.aspx' ></a><span Class='floatLeft'></span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx'>", _languageClass.GetLanguageConversion("Product_List"), "</a><span Class='floatLeft'>&nbsp;>>&nbsp;&nbsp;</span><a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/product.aspx?ID=", row["PriceCatalogueCategoryID"], "'>", baseClass.SpecialDecode(str), " </a><span Class='floatLeft'>&nbsp;>>&nbsp;&nbsp;</span>", baseClass.SpecialDecode(empty), "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "products/productdetails.aspx'></a><span>&nbsp;>>&nbsp;</span>PDF Preview" };
                    label.Text = string.Concat(sitePath);
                }
            }
            base.Title = commonclass.pageTitle("PDF Preview", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            this.PDFFrom = EprintConfigurationManager.AppSettings["PDFFrom"].ToString();
            this.StorePDFTo = EprintConfigurationManager.AppSettings["StorePDFTo"].ToString();
            this.PDFToURL = EprintConfigurationManager.AppSettings["PDFToURL"].ToString();
            if (!Directory.Exists(string.Concat(this.StorePDFTo, this.AccountID, "/pdf/")))
            {
                Directory.CreateDirectory(string.Concat(this.StorePDFTo, this.AccountID, "/pdf/"));
            }
            this.SitePath = EprintConfigurationManager.AppSettings["SitePath"].ToString();
            this.ImagePathFromFrontEnd = EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"].ToString();
            this.ImageFromPath = EprintConfigurationManager.AppSettings["ImageFromPath"].ToString();
            this.ImageToPath = EprintConfigurationManager.AppSettings["ImageToPath"].ToString();
            this.ConnectionString = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();
            this.FontFilePathForPDF = string.Concat(EprintConfigurationManager.AppSettings["ImageFromPath"].ToString(), "Fonts//");
            try
            {
                this.TemplateID = base.Request.QueryString["TemplateID"].ToString();
            }
            catch
            {
                this.SessionID1 = "1ywnrhmlx0xnuwsf0wxtmex0";
                this.TemplateID = "0";
            }
            if (!base.IsPostBack)
            {
                this.GeneratePDF();
                if (this.PreviewType == "img" || this.PreviewType == "pdfimg")
                {
                    var IsConvertedToOrder = false;

                    var table_new = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
                    if (table_new.Rows.Count > 0)
                    {
                        IsConvertedToOrder = Convert.ToBoolean(table_new.Rows[0]["IsConvertedToOrder"]);
                    }
                    string str1 = "";
                    string str2 = "";
                    if (IsConvertedToOrder)
                    {
                        str1 = this.TOPDFName.Remove(this.TOPDFName.Length - 4);
                        str1 = string.Concat(this.CompanyID, str1);
                         str2 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", (String.Concat(this.CompanyID, this.TOPDFName)));

                    }
                    else
                    {

                        str1 = this.TOPDFName.Remove(this.TOPDFName.Length - 4);
                         str2 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", this.TOPDFName);
                    }
                    //string str1 = this.TOPDFName.Remove(this.TOPDFName.Length - 4);
                   //string str2 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", this.TOPDFName);
                    string str3 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", str1);
                    PdfReader pdfReader = new PdfReader(str2);
                    this.totalPagesize = pdfReader.NumberOfPages;
                    if (File.Exists(str2))
                    {
                        //  this.ConvertToImage(str2, string.Concat(str3, ".png"), str1);

                        ExecuteCommandGhostLibrary(str2, string.Concat(str3, totalPagesize == 1 ? ".png" : "-%d.png"));

                        if (totalPagesize > 1)
                        {
                            for (int i = 1; i <= totalPagesize; i++)
                            {
                                var FileName = string.Concat(str3, "-%.png");
                                if (File.Exists(FileName.Replace("%", (i - 1).ToString())))
                                {
                                    File.Delete(FileName.Replace("%", (i - 1).ToString()));
                                }
                                System.IO.File.Move(FileName.Replace("%", i.ToString()), FileName.Replace("%", (i - 1).ToString()));

                            }
                        }

                    }
                    string str4 = this.PDFToURL.Remove(this.PDFToURL.Length - 4);
                    StringBuilder stringBuilder = new StringBuilder();
                    string str5 = "";
                    string str6 = "selected";
                    for (int i = 0; i < pdfReader.NumberOfPages; i++)
                    {
                        if (i > 0)
                        {
                            str5 = "none";
                            str6 = "";
                        }
                        if (pdfReader.NumberOfPages > 1)
                        {
                            object[] objArray = new object[] { str3, "-", i, ".png" };
                            if (File.Exists(string.Concat(objArray)))
                            {
                                preview_HTML5_V2 previewHTML5V2 = this;
                                object imagesName = previewHTML5V2.ImagesName;
                                object[] objArray1 = new object[] { imagesName, str1, "-", i, ".png," };
                                previewHTML5V2.ImagesName = string.Concat(objArray1);
                                object[] objArray2 = new object[] { "<li class='", str6, "' style='display:", str5, ";padding-top:15px'><img class='img' style='width:50%;background:white;' onload='imgLoaded(this);' src='", str4, "-", i, ".png'/><input type='hidden' value='", str1, "-", i, ".png'/></li>" };
                                stringBuilder.Append(string.Concat(objArray2));
                            }
                        }
                        else if (File.Exists(string.Concat(str3, ".png")))
                        {
                            preview_HTML5_V2 previewHTML5V21 = this;
                            previewHTML5V21.ImagesName = string.Concat(previewHTML5V21.ImagesName, str1, ".png,");
                            string[] strArrays = new string[] { "<li class='", str6, "' style='display:", str5, ";padding-top:15px'><img class='img' style='width:50%;background:white;' src='", str4, ".png' onload='imgLoaded(this);'/><input type='hidden' value='", str1, ".png'/></li>" };
                            stringBuilder.Append(string.Concat(strArrays));
                        }
                    }
                    pdfReader.Dispose();
                    pdfReader.Close();
                    this.div_imagePreview.InnerHtml = stringBuilder.ToString();
                    this.pdfframe.Attributes["src"] = this._finalpdfpath;
                    if (this.PreviewType != "img")
                    {
                        this.tdTypeSelect.Visible = true;
                        this.pdfframe.Visible = true;
                        this.imageframe.Style.Add("display", "none");
                    }
                    else
                    {
                        this.tdTypeSelect.Visible = false;
                        this.pdfframe.Visible = false;
                        this.imageframe.Visible = true;
                        this.imageframe.Style.Add("display", "block");
                    }
                }
                else
                {
                    this.pdfframe.Attributes["src"] = this._finalpdfpath;
                    this.pdfframe.Visible = true;
                    this.tdTypeSelect.Visible = false;
                    this.imageframe.Visible = false;
                }
                CartBasePage.Update_PDFNameP(Convert.ToInt64(this.CartItemID), this.TOPDFName, this.ImagesName, this.PreviewType);
                preview_HTML5_V2.FinalPDFName = this.TOPDFName;
                preview_HTML5_V2.PreviewImages = this.ImagesName;

            }
        }


        public float PixelToPoint(float pixel)
        {
            return pixel * 0.7528125f;
        }

        public static int[] rgbToCmyk(int red, int green, int blue)
        {
            int num = Math.Min(Math.Min(255 - red, 255 - green), 255 - blue);
            if (num == 255)
            {
                int num1 = 255 - red;
                int num2 = 255 - green;
                int num3 = 255 - blue;
                return new int[] { num1, num2, num3, num };
            }
            int num4 = (255 - red - num) / (255 - num);
            int num5 = (255 - green - num) / (255 - num);
            int num6 = (255 - blue - num) / (255 - num);
            return new int[] { num4, num5, num6, num };
        }

        private double WidthForMultiply(string ImageWidth, string PDFWidth, double left)
        {
            left = left / Convert.ToDouble(ImageWidth) * Convert.ToDouble(PDFWidth);
            return left;
        }
    }
}