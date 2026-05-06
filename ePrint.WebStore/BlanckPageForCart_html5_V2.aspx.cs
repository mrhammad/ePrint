using EditableTemplate.DataAccessLayer;
using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using nmsConnection;
using Printcenter.UI.CatrsNew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.WebStore
{
    public partial class BlanckPageForCart_html5_V2 : BaseClass, IRequiresSessionState
    {
        //protected HtmlHead Head1;

        //protected System.Web.UI.WebControls.Image LoadingImage;

        //protected Label Label1;

        //protected HtmlForm form1;

        protected FontStyle objFontStyle;

        public string PDFFrom = string.Empty;

        public string StorePDFTo = string.Empty;

        public string FontFilePathForPDF = string.Empty;

        public string ImagePathFromFrontEnd = string.Empty;

        public string ImageFromPath = string.Empty;

        public string ImageToPath = string.Empty;

        private string CartItemID = "0";

        private string CompanyID = "0";

        private string AccountID = "0";

        private string TemplateID = string.Empty;

        private string SessionID1 = string.Empty;

        public double CropMarkWidth;

        public double CropMarkHeight;

        public bool isAllowPDFPreviews;

        public bool isPDFPreviewMandatory;

        public string CropedPDFName = string.Empty;

        private string Label_FontStyle = string.Empty;

        public bool isAllowWaterMark;

        public string PDFPathForAdmin = string.Empty;

        public string PreviewType = string.Empty;

        public bool MakeWaterMarkfalse = true;

        public string WaterMarkText;

        private string TOPDFName = "";

        private string ConnectionString = string.Empty;

        protected Color color;

        private string _curentstatus = string.Empty;

        public int totalRequiredPages;

        public int totalPagesize;

        public string _pathforpdf = string.Empty;

        public string LabelColor = "";

        private bool isOverPrintFileRequired;

        public bool _IsOverPrintForAdmin;

        private string PriceCatID = "0";

        private string SystemName = "";

        public string TemplateName;

        public string directToCart = string.Empty;

        public static string JobName;

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

        //static BlanckPageForCart_html5_V2()
        //{

        //}

        public BlanckPageForCart_html5_V2()
        {
            BlanckPageForCart_html5_V2.JobName = string.Empty;
        }

        public void changePageSize(string outputURI, string pdf)
        {
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

        public string CreatedBlankPDF(int noofPages, string pdfsavepath, string pdfname, iTextSharp.text.Rectangle pageSize)
        {
            string[] strArrays = new string[] { pdfsavepath, this.CartItemID, "_B_", null, null };
            Guid guid = Guid.NewGuid();
            strArrays[3] = guid.ToString().Substring(0, 2);
            strArrays[4] = pdfname;
            string str = string.Concat(strArrays);
            Document document = new Document(pageSize);
            PdfWriter.GetInstance(document, new FileStream(str, FileMode.Create));
            document.Open();
            for (int i = 0; i < noofPages; i++)
            {
                document.Add(new Paragraph(" "));
                document.NewPage();
            }
            document.Close();
            document.Dispose();
            return str;
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
                    PdfContentByte underContent = pdfStamper.GetUnderContent(i);
                    underContent.BeginText();
                    BaseFont baseFont = BaseFont.CreateFont("Helvetica", "Cp1252", false);
                    underContent.SetFontAndSize(baseFont, (float)Convert.ToInt16(35));
                    underContent.SetRGBColorFill(220, 220, 220);
                    float hypotenuseAngleInDegreesFrom = (float)this.GetHypotenuseAngleInDegreesFrom((double)pageSizeWithRotation.Height, (double)pageSizeWithRotation.Width);
                    underContent.ShowTextAligned(1, stringToWriteToPdf, pageSizeWithRotation.Width / 2f, pageSizeWithRotation.Height / 2f - 16f, hypotenuseAngleInDegreesFrom);
                    underContent.EndText();
                }
                pdfStamper.Close();
                pdfReader.Close();
                array = memoryStream.ToArray();
            }
            return array;
        }

        public string ExecuteCommand(string command)
        {
            string end;
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
                end = process.StandardOutput.ReadToEnd();
            }
            catch
            {
                return null;
            }
            return end;
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
            string str = string.Empty;
            foreach (DataRow row in templateData.Tables[1].Rows)
            {
                empty = row["PDFName"].ToString();
                str = row["PDFName"].ToString();
                this.CropedPDFName = row["CropedPDFName"].ToString();
                if (this.CropedPDFName != string.Empty)
                {
                    empty = this.CropedPDFName;
                    if (!this.MakeWaterMarkfalse)
                    {
                        empty = row["PDFName"].ToString();
                    }
                }
                row["Zoomx"].ToString();
                row["Zoomy"].ToString();
                double num = 2.845275591;
                this.CropMarkHeight = Convert.ToDouble(row["CropMarkHeight"]) * num;
                this.CropMarkWidth = Convert.ToDouble(row["CropMarkWidth"]) * num;
                this.isOverPrintFileRequired = Convert.ToBoolean(row["isOverPrintFileRequired"]);
                this.isAllowWaterMark = Convert.ToBoolean(row["isAllowWaterMark"]);
                this.WaterMarkText = row["WaterMarkText"].ToString();
                this.TemplateName = row["TemplateName"].ToString();
                this.PriceCatID = row["PriceCatalogueID"].ToString();
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
            string str1 = "0";
            string str2 = "0";

            string str3 = string.Concat(this.PDFFrom, this.CompanyID, "\\pdf\\", empty.ToString());
            if (this.CropedPDFName != string.Empty)
            {
                empty = str;
            }
            if (this.Session["pdfnameF"] != null && this.Session["pdfnameF"].ToString() != string.Empty)
            {
                this.TOPDFName = this.Session["pdfnameF"].ToString();
                //this.TOPDFName = Session["pdfnameF"].ToString() == string.Empty || Session["pdfnameF"].ToString() == "" ? string.Concat(this.CartItemID, "_", empty.ToString()) : Session["pdfnameF"].ToString();
            }
            else if(Session["pdfnameDirect"].ToString() == String.Empty || Session["pdfnameDirect"].ToString() == "")
            {
                this.TOPDFName = string.Concat(this.CartItemID, "_", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), empty.ToString());
                Session["pdfnameDirect"] = this.TOPDFName;
            }
            else
            {
                this.TOPDFName = Session["pdfnameDirect"].ToString();
            }
            //this.TOPDFName = string.Concat(this.CartItemID, "_", empty.ToString());
            this._pathforpdf = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf");
            string str4 = string.Concat(this._pathforpdf, "\\", this.TOPDFName);
            if (!Directory.Exists(this._pathforpdf))
            {
                Directory.CreateDirectory(this._pathforpdf);
            }
            if (!this.MakeWaterMarkfalse)
            {
                str4 = string.Concat(this.PDFPathForAdmin, this.TOPDFName);
            }
            PdfReader pdfReader = new PdfReader(str3);
            iTextSharp.text.Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(1);
            PdfContentByte overContent = null;
            PdfStamper pdfStamper = null;
            FileStream fileStream = null;
            if (!this._IsOverPrintForAdmin || !this.isOverPrintFileRequired)
            {
                fileStream = new FileStream(str4, FileMode.Create);
                pdfStamper = new PdfStamper(pdfReader, fileStream);
                overContent = pdfStamper.GetOverContent(1);
            }
            else
            {
                string str5 = string.Concat(this.PDFFrom, this.CompanyID, "\\pdf\\");
                str5 = this.CreatedBlankPDF(pdfReader.NumberOfPages, str5, empty, pageSizeWithRotation);
                Thread.Sleep(5000);
                pdfReader = new PdfReader(str5);
                fileStream = new FileStream(str4, FileMode.Create);
                pdfStamper = new PdfStamper(pdfReader, fileStream);
                overContent = pdfStamper.GetOverContent(1);
            }
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
            str1 = Convert.ToInt32(pageSizeWithRotation.Height).ToString();
            str2 = pageSizeWithRotation.Width.ToString();
            int num1 = 1;
            foreach (DataRow dataRow in templateData.Tables[0].Rows)
            {
                try
                {
                    string upper = dataRow["DefaultContent"].ToString();
                    string str6 = dataRow["Capitalize"].ToString();
                    string str7 = dataRow["ImageURl"].ToString();
                    string str8 = dataRow["OriginalImageName"].ToString();
                    string str9 = dataRow["EditedImageName"].ToString();
                    string str10 = dataRow["FieldType"].ToString();
                    bool flag = Convert.ToBoolean(dataRow["IsFromBackEnd"]);
                    double num2 = Convert.ToDouble(dataRow["Indent"]);
                    dataRow["CompanyID"].ToString();
                    bool flag1 = Convert.ToBoolean(dataRow["Visibility"]);
                    string str11 = dataRow["fontfamily"].ToString();
                    double num3 = Convert.ToDouble(dataRow["fontsize"]);
                    string str12 = dataRow["fontweight"].ToString();
                    string str13 = dataRow["fontstyle"].ToString();
                    double num4 = Convert.ToDouble(dataRow["width"]);
                    double num5 = Convert.ToDouble(dataRow["height"]);
                    this.MmToPoint((float)num4);
                    this.MmToPoint((float)num5);
                    string str14 = dataRow["ExceedWidth"].ToString();
                    double num6 = (dataRow["PixelWidth"].ToString().Trim().Length > 0 ? Convert.ToDouble(dataRow["PixelWidth"]) : 0);
                    double num7 = Convert.ToDouble(dataRow["MaxWidth"]);
                    double num8 = Convert.ToDouble(dataRow["MaxHeight"]);
                    string str15 = dataRow["ExceedImage"].ToString();
                    string str16 = dataRow["ExceedHeight"].ToString();
                    bool flag2 = Convert.ToBoolean(dataRow["IsCropFromTop"]);
                    Convert.ToBoolean(dataRow["IsCropped"]);
                    bool flag3 = Convert.ToBoolean(dataRow["isDisplayonPDf"]);
                    double num9 = Convert.ToDouble(dataRow["Positionx"]);
                    double num10 = Convert.ToDouble(dataRow["Positiony"]);
                    string str17 = dataRow["ImageLocation"].ToString();
                    double num11 = Convert.ToDouble(dataRow["FieldLeft"]);
                    bool flag4 = Convert.ToBoolean(dataRow["IsJobNameField"]);
                    if (str10.Trim().ToLower() == "image" && str15 == "P")
                    {
                        if (str17 == "TL")
                        {
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str17 == "TC")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str17 == "TR")
                        {
                            num9 = num9 + Math.Abs(num4 - num7);
                            num10 = num10 + Math.Abs(num5 - num8);
                        }
                        else if (str17 == "CL")
                        {
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str17 == "C")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str17 == "CR")
                        {
                            num9 = num9 + Math.Abs(num4 - num7);
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                        }
                        else if (str17 != "BL")
                        {
                            if (str17 == "BC")
                            {
                                num9 = num9 + Math.Abs(num4 / 2 - num7 / 2);
                            }
                            else if (str17 != "BR")
                            {
                                num10 = num10 + Math.Abs(num5 - num8);
                            }
                            else
                            {
                                num9 = num9 + Math.Abs(num4 - num7);
                            }
                        }
                        if (str15 == "P")
                        {
                            num4 = num7;
                            num5 = num8;
                        }
                    }
                    dataRow["LabelActualFontName"].ToString();
                    string str18 = dataRow["LabelFontExtension"].ToString();
                    dataRow["ActualFontFamilyName"].ToString();
                    string str19 = dataRow["FontExtension"].ToString();
                    double num12 = Convert.ToDouble(dataRow["LabelFontSize"]);
                    string str20 = dataRow["ManualTracking"].ToString();
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays = str20.Split(chrArray);
                    double num13 = 0;
                    string str21 = "+";
                    string str22 = "pt";
                    if ((int)strArrays.Length != 1)
                    {
                        str21 = strArrays[0];
                        num13 = Convert.ToDouble(strArrays[1]);
                        str22 = strArrays[2];
                    }
                    else
                    {
                        num13 = Convert.ToDouble(dataRow["ManualTracking"]);
                        str21 = "+";
                        str22 = "pt";
                    }
                    double num14 = Convert.ToDouble(dataRow["LineSpacing"]);
                    double num15 = Convert.ToDouble(dataRow["MaxShrink"]);
                    string str23 = dataRow["BackgroundColor"].ToString();
                    long num16 = Convert.ToInt64(dataRow["GroupID"]);
                    string str24 = dataRow["GroupOrientation"].ToString();
                    string str25 = dataRow["Labels"].ToString();
                    string lower = dataRow["Value"].ToString();
                    dataRow["LabelStyle"].ToString();
                    string str26 = dataRow["LabelPosition"].ToString();
                    double num17 = Convert.ToDouble(dataRow["CustomLeft"]);
                    double num18 = Convert.ToDouble(dataRow["CustomTop"]);
                    double num19 = Convert.ToDouble(dataRow["CustomRight"]);
                    this.LabelColor = dataRow["LabelColor"].ToString();
                    this.Label_FontStyle = dataRow["LabelFontStyle"].ToString();
                    bool flag5 = Convert.ToBoolean(dataRow["SpotColor"]);
                    string str27 = dataRow["SpotColorRef"].ToString();
                    double num20 = Convert.ToDouble(dataRow["RotateAngle"]);
                    string str28 = dataRow["textAlign"].ToString();
                    if (str28.Trim().Length == 0)
                    {
                        str28 = "left";
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
                    if (str10.Trim().ToLower() == "textblock")
                    {
                        str10 = "1";
                    }
                    if (str10.Trim().ToLower() == "paragraph")
                    {
                        str10 = "2";
                    }
                    if (str10.Trim().ToLower() == "image")
                    {
                        str10 = "3";
                    }
                    if (str10 == "1")
                    {
                        num26 = Convert.ToDouble(dataRow["OffsetLeft"]);
                        if (str26 == "Attached")
                        {
                        }
                        if (num16 == (long)0)
                        {
                            if (str28 == "Center")
                            {
                                num9 = num26;
                            }
                            if (str28 == "Right")
                            {
                                num9 = num26;
                            }
                            if (str25 != "None" && str26 != "Attached")
                            {
                                num9 = Convert.ToDouble(dataRow["Positionx"]);
                            }
                            if (str25 != "None" && str26 == "customLeft" && str28 == "Center")
                            {
                                num9 = Convert.ToDouble(dataRow["OffsetLeft"]);
                            }
                        }
                        else if (str24 == "Horizontal")
                        {
                            if (str28 == "Right" && str26 != "Attached")
                            {
                                num9 = num26;
                            }
                            if (str28 == "Right" && str26 == "Attached" && num16 > (long)0)
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
                    if (str6 == "First Cap")
                    {
                        bool flag6 = false;
                        char[] charArray = upper.ToCharArray();
                        string str29 = "";
                        for (int i = 0; i < (int)charArray.Length; i++)
                        {
                            if (flag6 || i == 0)
                            {
                                str29 = string.Concat(str29, charArray[i].ToString().ToUpper());
                                flag6 = false;
                            }
                            else
                            {
                                str29 = string.Concat(str29, charArray[i].ToString().ToLower());
                            }
                            if (charArray[i] == ' ' || charArray[i] == '\r' || charArray[i] == '\n')
                            {
                                flag6 = true;
                            }
                        }
                        upper = str29;
                    }
                    if (str6 == "FirstCapAllowCaps")
                    {
                        bool flag7 = false;
                        char[] charArray1 = upper.ToCharArray();
                        string str30 = "";
                        for (int j = 0; j < (int)charArray1.Length; j++)
                        {
                            if (flag7 || j == 0)
                            {
                                str30 = string.Concat(str30, charArray1[j].ToString().ToUpper());
                                flag7 = false;
                            }
                            else
                            {
                                str30 = string.Concat(str30, charArray1[j].ToString());
                            }
                            if (charArray1[j] == ' ' || charArray1[j] == '\r' || charArray1[j] == '\n')
                            {
                                flag7 = true;
                            }
                        }
                        upper = str30;
                    }
                    if (str6 == "All Caps")
                    {
                        upper = upper.ToUpper();
                    }
                    if (str6 == "All Lower")
                    {
                        upper = upper.ToLower();
                    }
                    if (str6 == "InitCap")
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
                    if (str10.Trim().Length > 0 && flag1)
                    {
                        if (Convert.ToInt32(str10) == 3)
                        {
                            bool flag8 = Convert.ToBoolean(dataRow["IsPDF"]);
                            string str31 = dataRow["UserType"].ToString();
                            if (!flag8)
                            {
                                string.Concat(this.ImageToPath, "HorizontalLine.gif");
                                if (str7 != "noimage.jpg" && !flag3)
                                {
                                    if (!flag2 && flag)
                                    {
                                        str7 = str8;
                                        if (str9 != "")
                                        {
                                            str7 = str9;
                                        }
                                    }
                                    if (flag)
                                    {
                                        str7 = (str9 == "" ? str8 : str9);
                                        str7 = string.Concat(this.ImageFromPath, this.CompanyID, "\\Images\\", str7);
                                    }
                                    else
                                    {
                                        if (str9 != "")
                                        {
                                            str7 = str9;
                                        }
                                        else if (!flag2)
                                        {
                                            str7 = str8;
                                        }
                                        str7 = string.Concat(this.ImagePathFromFrontEnd, this.TemplateID, "\\Images\\", str7);
                                    }
                                    if (str23 != "")
                                    {
                                        iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(str7);
                                        instance.SetDpi(300, 300);
                                        instance.SetAbsolutePosition(0f, 0f);
                                        float single12 = (float)Convert.ToDouble(str1) + (float)this.CropMarkHeight * 2f;
                                        float single13 = (float)Convert.ToDouble(str2) + (float)this.CropMarkWidth * 2f;
                                        instance.ScaleAbsolute(single13, single12);
                                        overContent.AddImage(instance);
                                    }
                                    else
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(str7);
                                        image.SetDpi(300, 300);
                                        image.SetAbsolutePosition(point4, point5);
                                        if (image.Height >= image.Width)
                                        {
                                            if (str15 != "S")
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
                                        else if (str15 != "S")
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
                                            AffineTransform affineTransform = new AffineTransform();
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
                                string str32 = dataRow["PDFCompanyID"].ToString();
                                string str33 = dataRow["PDFUserID"].ToString();
                                string empty1 = string.Empty;
                                string str34 = dataRow["UsedPDFName"].ToString();
                                if (str31.Trim().ToLower() != "admin")
                                {
                                    string[] imagePathFromFrontEnd = new string[] { this.ImagePathFromFrontEnd, "UsersImages\\", str33, "\\pdf\\", str34.Replace(".png", ".pdf") };
                                    empty1 = string.Concat(imagePathFromFrontEnd);
                                }
                                else
                                {
                                    empty1 = string.Concat(this.ImageFromPath, str32, "\\pdf\\", str34.Replace(".png", ".pdf"));
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
                        else if (Convert.ToInt32(str10) != 13 && upper.Trim().ToLower().IndexOf("www.paypal.com") == -1 && str11.Trim().ToLower().IndexOf("barcode39") == -1)
                        {
                            if (str10 == "2")
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
                            if (flag4)
                            {
                                BlanckPageForCart_html5_V2.JobName = upper;
                            }
                            int num30 = 0;
                            this.objFontStyle = FontStyle.Regular;
                            if (str12.ToLower().Trim() == "bold")
                            {
                                num30 = 1;
                                this.objFontStyle = FontStyle.Bold;
                            }
                            if (str13.ToLower().Trim() == "italic")
                            {
                                num30 = 2;
                                this.objFontStyle = FontStyle.Italic;
                            }
                            if (str12.ToLower().Trim() == "bold" && str13.ToLower().Trim() == "italic")
                            {
                                num30 = 3;
                                this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                            }
                            float single14 = (float)num3;
                            if (str11.Contains("Bold"))
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
                            if (str11.Contains("Italic") && num30 == 2)
                            {
                                num30 = 0;
                            }
                            double num31 = (double)single4;
                            if (str11.Contains("Bold"))
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
                            if (str11.Contains("Italic") && num30 == 2)
                            {
                                num30 = 0;
                            }
                            Guid guid = Guid.NewGuid();
                            string str35 = guid.ToString().Substring(0, 10);
                            FontFactory.Register(string.Concat(this.FontFilePathForPDF, str19), str35);
                            iTextSharp.text.Font font = null;
                            font = FontFactory.GetFont(str35, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, single14, num30, new CMYKColor(single, single1, single2, single3));
                            PdfSpotColor pdfSpotColor = null;
                            if (flag5)
                            {
                                pdfSpotColor = new PdfSpotColor(str27, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor, single4);
                                font = FontFactory.GetFont(str35, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, single14, num30, new SpotColor(pdfSpotColor, single4));
                            }
                            if ((double)single4 < 1 && !flag5)
                            {
                                PdfSpotColor pdfSpotColor1 = new PdfSpotColor(str27, new CMYKColor(single, single1, single2, single3));
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
                            ColumnText columnText = new ColumnText(overContent);
                            Phrase phrase = new Phrase(string.Empty);
                            Phrase phrase1 = new Phrase(string.Empty);
                            Chunk chunk = null;
                            chunk = new Chunk(upper, font);
                            phrase.Add(0, chunk);
                            if (str14 == "Track")
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
                                if (str21 == "+" && str22 == "pt")
                                {
                                    chunk.SetCharacterSpacing(single6);
                                    if (str10 == "1")
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
                                if (str21 == "+" && str22 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(single6);
                                    if (str10 == "1")
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
                                if (str21 == "-" && str22 == "pt")
                                {
                                    chunk.SetCharacterSpacing(-single6);
                                    if (str10 == "1")
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
                                if (str21 == "-" && str22 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(-single6);
                                    if (str10 == "1")
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
                            }
                            if (str10 == "2" && str16.ToLower() == "expand height")
                            {
                                point5 = point5 - float.Parse(str1);
                            }
                            if (str10 == "1")
                            {
                                if (str25 == "None")
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
                                    if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                                    bool flag9 = false;
                                    string str36 = "";
                                    double num37 = 0;
                                    float single15 = 0f;
                                    float single16 = 0f;
                                    float single17 = 0f;
                                    float single18 = 100f;
                                    float single19 = 0f;
                                    bool flag10 = false;
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
                                                flag9 = Convert.ToBoolean(row1["SpotColor"]);
                                                str36 = row1["SpotColorRef"].ToString();
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
                                            flag10 = true;
                                        }
                                    }
                                    if (this.Label_FontStyle != "")
                                    {
                                        DataSet labelFontStyle = this.GetLabelFontStyle();
                                        DataTable item1 = labelFontStyle.Tables[0];
                                        string str37 = "";
                                        foreach (DataRow dataRow1 in labelFontStyle.Tables[0].Rows)
                                        {
                                            string str38 = dataRow1["ManualTracking"].ToString();
                                            chrArray = new char[] { ',' };
                                            string[] strArrays2 = str38.Split(chrArray);
                                            str37 = dataRow1["Capitalize"].ToString();
                                            if ((int)strArrays2.Length != 1)
                                            {
                                                string str39 = strArrays2[0];
                                                Convert.ToDouble(strArrays2[1]);
                                                string str40 = strArrays2[2];
                                            }
                                            else
                                            {
                                                Convert.ToDouble(dataRow1["ManualTracking"]);
                                            }
                                            if (str37 == "First Cap")
                                            {
                                                bool flag11 = false;
                                                char[] charArray2 = lower.ToCharArray();
                                                string str41 = "";
                                                for (int n = 0; n < (int)charArray2.Length; n++)
                                                {
                                                    if (flag11 || n == 0)
                                                    {
                                                        str41 = string.Concat(str41, charArray2[n].ToString().ToUpper());
                                                        flag11 = false;
                                                    }
                                                    else
                                                    {
                                                        str41 = string.Concat(str41, charArray2[n].ToString().ToLower());
                                                    }
                                                    if (charArray2[n] == ' ' || charArray2[n] == '\r')
                                                    {
                                                        flag11 = true;
                                                    }
                                                }
                                                lower = str41;
                                            }
                                            if (str37 == "All Caps")
                                            {
                                                lower = lower.ToUpper();
                                            }
                                            if (str37 == "All Lower")
                                            {
                                                lower = lower.ToLower();
                                            }
                                            if (str37 != "InitCap")
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
                                    string str42 = guid.ToString().Substring(0, 10);
                                    FontFactory.Register(string.Concat(this.FontFilePathForPDF, str18), str42);
                                    iTextSharp.text.Font font1 = null;
                                    font1 = FontFactory.GetFont(str42, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, (float)num12, num30, new CMYKColor(single15, single16, single17, single18));
                                    PdfSpotColor pdfSpotColor2 = null;
                                    if (flag9)
                                    {
                                        pdfSpotColor2 = new PdfSpotColor(str36, new CMYKColor(single15, single16, single17, single18));
                                        overContent.SetColorStroke(pdfSpotColor2, single19);
                                        font1 = FontFactory.GetFont(str42, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, (float)num12, num30, new SpotColor(pdfSpotColor2, single19));
                                    }
                                    if ((double)single19 < 1 && !flag9 && flag10)
                                    {
                                        PdfSpotColor pdfSpotColor3 = new PdfSpotColor(str36, new CMYKColor(single15, single16, single17, single18));
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
                                    if (str14 == "Track")
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
                                        if (str21 == "+" && str22 == "pt")
                                        {
                                            chunk.SetCharacterSpacing(single6);
                                            if (str10 == "1")
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
                                        if (str21 == "+" && str22 == "mm")
                                        {
                                            chunk.SetCharacterSpacing(single6);
                                            if (str10 == "1")
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
                                        if (str21 == "-" && str22 == "pt")
                                        {
                                            chunk.SetCharacterSpacing(-single6);
                                            if (str10 == "1")
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
                                        if (str21 == "-" && str22 == "mm")
                                        {
                                            chunk.SetCharacterSpacing(-single6);
                                            if (str10 == "1")
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
                                    }
                                    if (num17 >= 0 && str26 == "customLeft")
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
                                            if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                                            if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                                            if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                                    //if (num19 >= 0 && str26 == "customRight") Changed by Amin
                                    if (str26 == "customRight")
                                    {
                                        float point10 = this.MmToPoint((float)num19);
                                        point4 = this.MmToPoint((float)num26);
                                        if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                                    if (num18 >= 0 && str26 == "customTop")
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
                                        float point11 = this.MmToPoint((float)(num18 - 0.2));
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
                                    else if (str26 == "Attached")
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
                                        if (num32 == 1 && str24 == "Horizontal" && str26 == "Attached" && num16 > (long)0)
                                        {
                                            num32 = 0;
                                        }
                                        phrase1.Add(phrase);
                                        if ((!(str21 == "+") || !(str22 == "pt")) && (!(str21 == "+") || !(str22 == "mm")))
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
                            else if (str10 == "2")
                            {
                                float single21 = (float)this.MmToPoint((float)num14);
                                if (point6 > 0f)
                                {
                                    point4 = point4 + point6;
                                }
                                if (single21 > 0f)
                                {
                                    phrase = new Phrase(single21);
                                    phrase.Add(chunk);
                                    if (num32 == 1)
                                    {
                                        num27 = num27 / 2;
                                    }
                                    if (num32 == 0)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4, point5, single8, single9 + (single21 - single14), single14, num32);
                                    }
                                    else if (num32 == 1)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4 - point2 / 2f, point5, single8 - point2 / 2f, single9 + (single21 - single14), single14, num32);
                                    }
                                    else if (num32 == 2)
                                    {
                                        columnText.SetSimpleColumn(phrase, point4 - point2, point5, single8 - point2, single9 + (single21 - single14), single14, num32);
                                    }
                                    columnText.SetLeading(single21, 0f);
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
                                    AffineTransform affineTransform1 = new AffineTransform();
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
            pdfReader.Dispose();
            fileStream.Dispose();
            pdfStamper.Dispose();
            if (this.isAllowWaterMark && this.MakeWaterMarkfalse)
            {
                FileInfo fileInfo = new FileInfo(str4);
                File.WriteAllBytes(str4, this.CreateWaterMark(fileInfo, this.WaterMarkText));
            }
            if (this.CropMarkHeight <= 0)
            {
                double cropMarkWidth = this.CropMarkWidth;
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
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", this.TemplateID), new SqlParameter("@CartItemID", this.CartItemID), new SqlParameter("@IsOverPrintForAdmin", (object)this._IsOverPrintForAdmin) };
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
            this.Page.Header.Title = "Saving...";
            if (ConnectionClass.AccountID == null || !(ConnectionClass.AccountID != ""))
            {
                this.AccountID = "0";
            }
            else
            {
                this.AccountID = Convert.ToString(ConnectionClass.AccountID);
            }
            if (base.Request.QueryString["CompanyID"].ToString() == "")
            {
                this.CompanyID = "0";
            }
            else
            {
                this.CompanyID = base.Request.QueryString["CompanyID"];
            }
            if (ConnectionClass.SystemName == null || !(ConnectionClass.SystemName != ""))
            {
                this.SystemName = "";
            }
            else
            {
                this.SystemName = ConnectionClass.SystemName.ToString();
            }
            Session["pdfnameDirect"] = String.Empty;
            this.ImagePathFromFrontEnd = EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"].ToString();
            this.ImageFromPath = EprintConfigurationManager.AppSettings["ImageFromPath"].ToString();
            this.ImageToPath = EprintConfigurationManager.AppSettings["ImageToPath"].ToString();
            this.ConnectionString = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();
            this.FontFilePathForPDF = string.Concat(EprintConfigurationManager.AppSettings["ImageFromPath"].ToString(), "Fonts//");
            this.PDFFrom = EprintConfigurationManager.AppSettings["PDFFrom"].ToString();
            this.StorePDFTo = EprintConfigurationManager.AppSettings["StorePDFTo"].ToString();
            if (!Directory.Exists(string.Concat(this.StorePDFTo, this.AccountID, "/pdf/")))
            {
                Directory.CreateDirectory(string.Concat(this.StorePDFTo, this.AccountID, "/pdf/"));
            }
            try
            {
                this.TemplateID = base.Request.QueryString["TemplateID"].ToString();
            }
            catch
            {
                this.SessionID1 = "1ywnrhmlx0xnuwsf0wxtmex0";
                this.TemplateID = "0";
            }      
            string str = EprintConfigurationManager.AppSettings["SitePath"].ToString();
            string item = base.Request.QueryString["ID"];
            this.CartItemID = base.Request.QueryString["CartItemID"];
            if (base.Request.QueryString["PreviewType"].ToString() == "")
            {
                this.PreviewType = "pdf";
            }
            else
            {
                this.PreviewType = base.Request.QueryString["PreviewType"];
            }
            if (base.Request.QueryString["directToCart"].ToString() != "")
            {
                this.directToCart = base.Request.QueryString["directToCart"];
            }
            if (this.directToCart.ToLower() == "true")
            {
                this.MakeWaterMarkfalse = true;
                this.GeneratePDF();
                Thread.Sleep(5000);
            }
            this.MakeWaterMarkfalse = false;
            this._IsOverPrintForAdmin = true;
            string[] secureDocPath = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
            this.PDFPathForAdmin = string.Concat(secureDocPath);
            if (!Directory.Exists(this.PDFPathForAdmin))
            {
                Directory.CreateDirectory(this.PDFPathForAdmin);
            }
            this.GeneratePDF();
            string empty = string.Empty;
            Session["pdfnameF"] = String.Empty;
            if (this.directToCart.ToLower() != "true")
            {
                empty = base.Request.QueryString["PreviewImages"].ToString();
                string str1 = string.Concat(this._pathforpdf, "\\", this.TOPDFName);
                string str2 = string.Concat(this._pathforpdf, "\\", base.Request.QueryString["FinalPDFName"].ToString());
                if (!File.Exists(str1) && File.Exists(str2))
                {
                    using (Stream stream = File.Open(str2, FileMode.Open))
                    {
                        using (Stream stream1 = File.Create(str1))
                        {
                            while (stream.Position < stream.Length)
                            {
                                stream1.WriteByte((byte)stream.ReadByte());
                            }
                        }
                    }
                }
            }
            else if (this.PreviewType == "img" || this.PreviewType == "pdfimg")
            {
                string str3 = this.TOPDFName.Remove(this.TOPDFName.Length - 4);
                string str4 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", this.TOPDFName);
                string str5 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf\\", str3);
                PdfReader pdfReader = new PdfReader(str4);
                if (File.Exists(str4))
                {
                    this.ConvertToImage(str4, string.Concat(str5, ".png"), str3);
                }
                for (int i = 0; i < pdfReader.NumberOfPages; i++)
                {
                    if (pdfReader.NumberOfPages > 1)
                    {
                        object[] objArray = new object[] { str5, "-", i, ".png" };
                        if (File.Exists(string.Concat(objArray)))
                        {
                            object obj1 = empty;
                            object[] objArray1 = new object[] { obj1, str3, "-", i, ".png," };
                            empty = string.Concat(objArray1);
                        }
                    }
                    else if (File.Exists(string.Concat(str5, ".png")))
                    {
                        empty = string.Concat(empty, str3, ".png,");
                    }
                }
                pdfReader.Dispose();
                pdfReader.Close();
            }
            DataTable dataTable = new DataTable();
            dataTable = CartBasePage.Get_Status(Convert.ToInt64(this.CartItemID));
            if (dataTable.Rows.Count > 0)
            {
                this._curentstatus = dataTable.Rows[0]["OrderStatus"].ToString();
            }
            if (this._curentstatus != "C")
            {
                CartBasePage.Update_SaveName_Status(Convert.ToInt64(this.CartItemID), this.TOPDFName, empty);
                base.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "closepage", "<script type='text/JavaScript'>window.close();</script>");
                return;
            }

            CartBasePage.Update_PDFNameC(Convert.ToInt64(this.CartItemID), this.TOPDFName, empty, this.PreviewType, BlanckPageForCart_html5_V2.JobName);

            HttpResponse response = base.Response;
            var approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
            var isReapproval = base.Return_ApprovalSystem_Settings("reapproval");

            var ApprovalStatus = false;

            var table = CartBasePage.GetCartItemStatusForApproval(Convert.ToInt32(CartItemID));
            if (table.Rows.Count > 0)
            {
                ApprovalStatus = Convert.ToBoolean(table.Rows[0]["IsConvertedToOrder"]);
            }
            if (ApprovalStatus)
            {
                string[] sitePath = new string[] { str, "order.aspx?OrderID=" + table.Rows[0]["EstimateID"].ToString() };
                response.Redirect(string.Concat(sitePath));
            }
            else
            {
                string[] cartItemID = new string[] { str, "ShoppingCart.aspx?ID=", item, "&CartItemID=", this.CartItemID };
                response.Redirect(string.Concat(cartItemID));
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