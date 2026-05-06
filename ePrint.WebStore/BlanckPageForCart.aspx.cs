using EditableTemplate.DataAccessLayer;
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
    public partial class BlanckPageForCart : System.Web.UI.Page, IRequiresSessionState
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

        public bool MakeWaterMarkfalse = true;

        public string WaterMarkText;

        private string TOPDFName = "";

        private string ConnectionString = string.Empty;

        protected Color color;

        private string _curentstatus = string.Empty;

        public int totalRequiredPages;

        public string _pathforpdf = string.Empty;

        public string LabelColor = "";

        private bool isOverPrintFileRequired;

        public bool _IsOverPrintForAdmin;

        private string PriceCatID = "0";

        private string SystemName = "";

        public string TemplateName;

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

        public BlanckPageForCart()
        {
        }

        public void changePageSize(string outputURI, string pdf)
        {
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
                    underContent.SetFontAndSize(baseFont, (float)Convert.ToInt16(45));
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
        public PdfContentByte CalculateKerning(PdfContentByte overContent, Chunk chunk, double width, float single6)
        {
            float WidthWithCharSpacing = chunk.GetWidthPoint() + chunk.GetCharacterSpacing() * (chunk.Content.Length - 1);

            if (WidthWithCharSpacing > width)
            {
                while (WidthWithCharSpacing > width)
                {
                    single6 = single6 - .1f;
                    chunk.SetCharacterSpacing(single6);
                    WidthWithCharSpacing = chunk.GetWidthPoint() + chunk.GetCharacterSpacing() * (chunk.Content.Length - 1);
                }
                overContent.SetCharacterSpacing(single6);
                return overContent;
            }

            return overContent;
        }

        private void GeneratePDF()
        {
            DateTime date;
            Thread.Sleep(5000);
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
            this.TOPDFName = string.Concat(this.CartItemID, "_", empty.ToString());
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
                info.Add("Keywords", "Eprint_Admin");
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
                info.Add("Keywords", "Eprint_Admin");
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
                info.Add("Keywords", "Eprint_Admin");
                pdfStamper.MoreInfo = info;
            }
            str1 = Convert.ToInt32(pageSizeWithRotation.Height).ToString();
            str2 = pageSizeWithRotation.Width.ToString();
            int num1 = 1;
            foreach (DataRow dataRow in templateData.Tables[0].Rows)
            {
                try
                {
                    overContent.SetCharacterSpacing(0);
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
                    dataRow["LabelActualFontName"].ToString();
                    string str14 = dataRow["LabelFontExtension"].ToString();
                    dataRow["ActualFontFamilyName"].ToString();
                    string str15 = dataRow["FontExtension"].ToString();
                    double num4 = Convert.ToDouble(dataRow["LabelFontSize"]);
                    double num5 = Convert.ToDouble(dataRow["width"]);
                    double num6 = Convert.ToDouble(dataRow["height"]);
                    this.MmToPoint((float)num5);
                    this.MmToPoint((float)num6);
                    string str16 = dataRow["ExceedWidth"].ToString();
                    double num7 = Convert.ToDouble(dataRow["PixelWidth"]);
                    double num8 = Convert.ToDouble(dataRow["MaxWidth"]);
                    double num9 = Convert.ToDouble(dataRow["MaxHeight"]);
                    string str17 = dataRow["ExceedImage"].ToString();
                    bool flag2 = Convert.ToBoolean(dataRow["IsCropFromTop"]);
                    bool flag3 = Convert.ToBoolean(dataRow["IsCropped"]);
                    double num10 = Convert.ToDouble(dataRow["Positionx"]);
                    double num11 = Convert.ToDouble(dataRow["Positiony"]);
                    double num12 = Convert.ToDouble(dataRow["FieldLeft"]);
                    string str18 = dataRow["ImageLocation"].ToString();
                    if (str10.Trim().ToLower() == "image" && str17 == "P")
                    {
                        if (str18 == "TL")
                        {
                            num11 = num11 + Math.Abs(num6 - num9);
                        }
                        else if (str18 == "TC")
                        {
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                            num11 = num11 + Math.Abs(num6 - num9);
                        }
                        else if (str18 == "TR")
                        {
                            num10 = num10 + Math.Abs(num5 - num8);
                            num11 = num11 + Math.Abs(num6 - num9);
                        }
                        else if (str18 == "CL")
                        {
                            num11 = num11 + Math.Abs(num6 / 2 - num9 / 2);
                        }
                        else if (str18 == "C")
                        {
                            num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                            num11 = num11 + Math.Abs(num6 / 2 - num9 / 2);
                        }
                        else if (str18 == "CR")
                        {
                            num10 = num10 + Math.Abs(num5 - num8);
                            num11 = num11 + Math.Abs(num6 / 2 - num9 / 2);
                        }
                        else if (str18 != "BL")
                        {
                            if (str18 == "BC")
                            {
                                num10 = num10 + Math.Abs(num5 / 2 - num8 / 2);
                            }
                            else if (str18 != "BR")
                            {
                                num11 = num11 + Math.Abs(num6 - num9);
                            }
                            else
                            {
                                num10 = num10 + Math.Abs(num5 - num8);
                            }
                        }
                        if (str17 == "P")
                        {
                            num5 = num8;
                            num6 = num9;
                        }
                    }
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
                    double num27 = num11;
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
                        if (str25 == "Attached")
                        {
                        }
                        if (num16 == (long)0)
                        {
                            if (str27 == "Center")
                            {
                                num10 = num26;
                            }
                            if (str27 == "Right")
                            {
                                num10 = num26;
                            }
                            if (str24 != "None" && str25 != "Attached")
                            {
                                num10 = Convert.ToDouble(dataRow["Positionx"]);
                            }
                            if (str24 != "None" && str25 == "customLeft" && str27 == "Center")
                            {
                                num10 = Convert.ToDouble(dataRow["OffsetLeft"]);
                            }
                        }
                        else if (str23 == "Horizontal")
                        {
                            if (str27 == "Right" && str25 != "Attached")
                            {
                                num10 = num26;
                            }
                            if (str27 == "Right" && str25 == "Attached" && num16 > (long)0)
                            {
                                num10 = ((this.TemplateID == "282" || this.TemplateID == "308") && this.SystemName.Trim().ToLower() == "quickcorporate" ? num12 : num26);
                            }
                        }
                    }
                    float point = this.MmToPoint((float)num5);
                    float point1 = this.MmToPoint((float)num6);
                    float point2 = this.MmToPoint((float)num5);
                    float point3 = this.MmToPoint((float)num6);
                    float point4 = this.MmToPoint((float)num10);
                    float point5 = this.MmToPoint((float)num11);
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
                            if (charArray[i] == ' ' || charArray[i] == '\r')
                            {
                                flag5 = true;
                            }
                        }
                        upper = str28;
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
                        char[] charArray1 = upper.ToCharArray();
                        string upper1 = charArray1[0].ToString().ToUpper();
                        string lower1 = "";
                        for (int j = 1; j < (int)charArray1.Length; j++)
                        {
                            lower1 = string.Concat(lower1, charArray1[j].ToString());
                        }
                        lower1 = lower1.ToLower();
                        upper = string.Concat(upper1, lower1);
                    }
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
                    if (str10.Trim().Length > 0 && flag1)
                    {
                        if (Convert.ToInt32(str10) != 3)
                        {
                            int num28 = 0;
                            this.objFontStyle = FontStyle.Regular;
                            if (str12.ToLower().Trim() == "bold")
                            {
                                num28 = 1;
                                this.objFontStyle = FontStyle.Bold;
                            }
                            if (str13.ToLower().Trim() == "italic")
                            {
                                num28 = 2;
                                this.objFontStyle = FontStyle.Italic;
                            }
                            if (str12.ToLower().Trim() == "bold" && str13.ToLower().Trim() == "italic")
                            {
                                num28 = 3;
                                this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                            }
                            float single12 = (float)num3;
                            if (str11.Contains("Bold"))
                            {
                                if (num28 == 1)
                                {
                                    num28 = 0;
                                }
                                if (num28 == 3)
                                {
                                    num28 = 2;
                                }
                            }
                            if (str11.Contains("Italic") && num28 == 2)
                            {
                                num28 = 0;
                            }
                            double num29 = (double)single4;
                            Guid guid = Guid.NewGuid();
                            string str29 = guid.ToString().Substring(0, 10);
                            FontFactory.Register(string.Concat(this.FontFilePathForPDF, str15), str29);
                            iTextSharp.text.Font font = null;
                            font = FontFactory.GetFont(str29, "Cp1252", true, single12, num28, new CMYKColor(single, single1, single2, single3));
                            PdfSpotColor pdfSpotColor = null;
                            if (flag4)
                            {
                                pdfSpotColor = new PdfSpotColor(str26, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor, single4);
                                font = FontFactory.GetFont(str29, "Cp1252", true, single12, num28, new SpotColor(pdfSpotColor, single4));
                            }
                            if ((double)single4 < 1 && !flag4)
                            {
                                PdfSpotColor pdfSpotColor1 = new PdfSpotColor(str26, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor1, single4);
                                overContent.SetColorFill(pdfSpotColor1, single4);
                            }
                            int num30 = 0;
                            if (dataRow["textalign"].ToString().Trim().ToLower() == "left")
                            {
                                num30 = 0;
                            }
                            else if (dataRow["textalign"].ToString().Trim().ToLower() != "center")
                            {
                                num30 = (dataRow["textalign"].ToString().Trim().ToLower() != "right" ? 3 : 2);
                            }
                            else
                            {
                                num30 = 1;
                            }
                            ColumnText columnText = new ColumnText(overContent);
                            Phrase phrase = new Phrase(string.Empty);
                            Phrase phrase1 = new Phrase(string.Empty);
                            Chunk chunk = null;
                            Chunk chunk1 = null;
                            chunk = new Chunk(upper, font);
                            phrase.Add(0, chunk);
                            if (str16 == "Track")
                            {
                                single5 = this.PixelToPoint((float)num7) / 100f;
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
                                }
                                if (str20 == "+" && str21 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(single6);
                                }
                                if (str20 == "-" && str21 == "pt")
                                {
                                    chunk.SetCharacterSpacing(-single6);
                                }
                                if (str20 == "-" && str21 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(-single6);
                                }
                            }
                            if (str10 == "1")
                            {
                                if (str24 == "None")
                                {
                                    if (num30 == 1 && str23 == "Horizontal" && num16 > (long)0)
                                    {
                                        num30 = 0;
                                    }
                                    if (point6 > 0f)
                                    {
                                        point4 = point4 + point6;
                                    }
                                    var letterSpacing = str20 == "-" ? -single6 : single6;
                                  
                                    var width = this.MmToPoint((float)num7);
                                    overContent = CalculateKerning(overContent, chunk, width, point6);

                                    if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                    {
                                        ColumnText.ShowTextAligned(overContent, num30, phrase, point4 - single6, point5, single7);
                                    }
                                    else
                                    {
                                        ColumnText.ShowTextAligned(overContent, num30, phrase, point4 + single6, point5, single7);
                                    }
                                }
                                else
                                {
                                    if (upper == string.Empty)
                                    {
                                        lower = string.Empty;
                                    }
                                    double num31 = 0;
                                    double num32 = 0;
                                    double num33 = 0;
                                    double num34 = 100;
                                    bool flag6 = false;
                                    string str30 = "";
                                    double num35 = 0;
                                    float single13 = 0f;
                                    float single14 = 0f;
                                    float single15 = 0f;
                                    float single16 = 100f;
                                    float single17 = 0f;
                                    double num36 = 0;
                                    string str31 = "+";
                                    string str32 = "pt";
                                    bool flag7 = false;
                                    if (this.LabelColor != "")
                                    {
                                        DataSet labelColor = this.GetLabelColor();
                                        DataTable dataTable = labelColor.Tables[0];
                                        foreach (DataRow row1 in labelColor.Tables[0].Rows)
                                        {
                                            try
                                            {
                                                num31 = Convert.ToDouble(row1["C"]);
                                                num32 = Convert.ToDouble(row1["M"]);
                                                num33 = Convert.ToDouble(row1["Y"]);
                                                num34 = Convert.ToDouble(row1["K"]);
                                                flag6 = Convert.ToBoolean(row1["SpotColor"]);
                                                str30 = row1["SpotColorRef"].ToString();
                                                num35 = Convert.ToDouble(row1["Tint"]);
                                            }
                                            catch
                                            {
                                            }
                                            single13 = (float)num31 / 100f;
                                            single14 = (float)num32 / 100f;
                                            single15 = (float)num33 / 100f;
                                            single16 = (float)num34 / 100f;
                                            single17 = (float)num35 / 100f;
                                            flag7 = true;
                                        }
                                    }
                                    if (this.Label_FontStyle != "")
                                    {
                                        DataSet labelFontStyle = this.GetLabelFontStyle();
                                        DataTable item1 = labelFontStyle.Tables[0];
                                        string str33 = "";
                                        foreach (DataRow dataRow1 in labelFontStyle.Tables[0].Rows)
                                        {
                                            string str34 = dataRow1["ManualTracking"].ToString();
                                            chrArray = new char[] { ',' };
                                            string[] strArrays1 = str34.Split(chrArray);
                                            str33 = dataRow1["Capitalize"].ToString();
                                            if ((int)strArrays1.Length != 1)
                                            {
                                                str31 = strArrays1[0];
                                                num36 = Convert.ToDouble(strArrays1[1]);
                                                str32 = strArrays1[2];
                                            }
                                            else
                                            {
                                                num36 = Convert.ToDouble(dataRow1["ManualTracking"]);
                                                str31 = "+";
                                                str32 = "pt";
                                            }
                                            if (str33 == "First Cap")
                                            {
                                                bool flag8 = false;
                                                char[] chrArray1 = lower.ToCharArray();
                                                string str35 = "";
                                                for (int k = 0; k < (int)chrArray1.Length; k++)
                                                {
                                                    if (flag8 || k == 0)
                                                    {
                                                        str35 = string.Concat(str35, chrArray1[k].ToString().ToUpper());
                                                        flag8 = false;
                                                    }
                                                    else
                                                    {
                                                        str35 = string.Concat(str35, chrArray1[k].ToString().ToLower());
                                                    }
                                                    if (chrArray1[k] == ' ' || chrArray1[k] == '\r')
                                                    {
                                                        flag8 = true;
                                                    }
                                                }
                                                lower = str35;
                                            }
                                            if (str33 == "All Caps")
                                            {
                                                lower = lower.ToUpper();
                                            }
                                            if (str33 == "All Lower")
                                            {
                                                lower = lower.ToLower();
                                            }
                                            if (str33 != "InitCap")
                                            {
                                                continue;
                                            }
                                            char[] charArray2 = lower.ToCharArray();
                                            string upper2 = charArray2[0].ToString().ToUpper();
                                            string lower2 = "";
                                            for (int l = 1; l < (int)charArray2.Length; l++)
                                            {
                                                lower2 = string.Concat(lower2, charArray2[l].ToString());
                                            }
                                            lower2 = lower2.ToLower();
                                            lower = string.Concat(upper2, lower2);
                                        }
                                    }
                                    if (num4 == 0)
                                    {
                                        num4 = (double)single12;
                                    }
                                    guid = Guid.NewGuid();
                                    string str36 = guid.ToString().Substring(0, 10);
                                    FontFactory.Register(string.Concat(this.FontFilePathForPDF, str14), str36);
                                    iTextSharp.text.Font font1 = null;
                                    font1 = FontFactory.GetFont(str36, "Cp1252", true, (float)num4, num28, new CMYKColor(single13, single14, single15, single16));
                                    PdfSpotColor pdfSpotColor2 = null;
                                    if (flag6)
                                    {
                                        pdfSpotColor2 = new PdfSpotColor(str30, new CMYKColor(single13, single14, single15, single16));
                                        overContent.SetColorStroke(pdfSpotColor2, single17);
                                        font1 = FontFactory.GetFont(str36, "Cp1252", true, (float)num4, num28, new SpotColor(pdfSpotColor2, single17));
                                    }
                                    if ((double)single17 < 1 && !flag6 && flag7)
                                    {
                                        PdfSpotColor pdfSpotColor3 = new PdfSpotColor(str30, new CMYKColor(single13, single14, single15, single16));
                                        overContent.SetColorStroke(pdfSpotColor3, single17);
                                        overContent.SetColorFill(pdfSpotColor3, single17);
                                    }
                                    phrase1 = new Phrase();
                                    chunk1 = new Chunk(lower, font1);
                                    phrase1.Add(0, chunk1);
                                    if (num36 > 0)
                                    {
                                        if (str31 == "+" && str32 == "pt")
                                        {
                                            chunk1.SetCharacterSpacing((float)num36);
                                        }
                                        if (str31 == "+" && str32 == "mm")
                                        {
                                            num36 = (double)((float)((double)((float)num36) / 0.352777778));
                                            chunk1.SetCharacterSpacing((float)num36);
                                        }
                                        if (str31 == "-" && str32 == "pt")
                                        {
                                            chunk1.SetCharacterSpacing(-(float)num36);
                                        }
                                        if (str31 == "-" && str32 == "mm")
                                        {
                                            num36 = (double)((float)((double)((float)num36) / 0.352777778));
                                            chunk1.SetCharacterSpacing(-(float)num36);
                                        }
                                    }
                                    var Textwidth = this.MmToPoint((float)num7);
                                    overContent = CalculateKerning(overContent, chunk, Textwidth, point6);
                                    if (num17 >= 0 && str25 == "customLeft")
                                    {
                                        this.PixelToPoint((float)num17);
                                        float point7 = this.MmToPoint((float)num17);
                                        if (num30 == 0)
                                        {
                                            ColumnText.ShowTextAligned(overContent, num30, phrase1, point4, point5, single7);
                                            ColumnText.ShowTextAligned(overContent, num30, phrase, point4 + point7, point5, single7);
                                        }
                                        if (num30 == 1)
                                        {
                                            if (!(str23 == "Horizontal") || num16 <= (long)0)
                                            {
                                                ColumnText.ShowTextAligned(overContent, num30, phrase, point4 + point7 / 2f, point5, single7);
                                                float width = ColumnText.GetWidth(phrase) / 2f;
                                                ColumnText.ShowTextAligned(overContent, num30, phrase1, point4 - width, point5, single7);
                                            }
                                            else
                                            {
                                                num30 = 0;
                                                ColumnText.ShowTextAligned(overContent, num30, phrase, point4, point5, single7);
                                                ColumnText.ShowTextAligned(overContent, num30, phrase1, point4 - point7, point5, single7);
                                            }
                                        }
                                        if (num30 == 2)
                                        {
                                            if (num16 == (long)0)
                                            {
                                                point4 = this.MmToPoint((float)num26);
                                            }
                                            if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                            {
                                                ColumnText.ShowTextAligned(overContent, num30, phrase, point4 - single6, point5, single7);
                                            }
                                            else
                                            {
                                                ColumnText.ShowTextAligned(overContent, num30, phrase, point4 + single6, point5, single7);
                                            }
                                            float width1 = point4 - (ColumnText.GetWidth(phrase) + point7);
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width1, point5, single7);
                                        }
                                    }
                                    if (num19 >= 0)
                                    {
                                    }
                                    if (num18 >= 0 && str25 == "customTop")
                                    {
                                        this.PixelToPoint((float)num18);
                                        columnText.SetSimpleColumn(phrase, point4, point5, single10, single11, 0f, num30);
                                        phrase1 = new Phrase(lower, font1);
                                        columnText.SetSimpleColumn(phrase1, point4, point5, single10, single11, 0f, num30);
                                    }
                                    else if (str25 == "Attached")
                                    {
                                        if (num30 == 1 && str23 == "Horizontal" && str25 == "Attached" && num16 > (long)0)
                                        {
                                            num30 = 0;
                                        }
                                        phrase1.Add(phrase);
                                        if ((!(str20 == "+") || !(str21 == "pt")) && (!(str20 == "+") || !(str21 == "mm")))
                                        {
                                            ColumnText.ShowTextAligned(overContent, num30, phrase1, point4 - single6, point5, single7);
                                        }
                                        else
                                        {
                                            ColumnText.ShowTextAligned(overContent, num30, phrase1, point4 + single6, point5, single7);
                                        }
                                    }
                                }
                            }
                            else if (str10 == "2")
                            {
                                float point8 = this.MmToPoint((float)num14);
                                if (point6 > 0f)
                                {
                                    point4 = point4 + point6;
                                }
                                if (point8 <= 0f)
                                {
                                    columnText.SetSimpleColumn(phrase, point4, point5, single8, single9, single12, num30);
                                }
                                else
                                {
                                    phrase = new Phrase(point8);
                                    phrase.Add(chunk);
                                    if (num30 == 1)
                                    {
                                        num27 = num27 / 2;
                                    }
                                    columnText.SetSimpleColumn(phrase, point4, point5, single8, single9, single12, num30);
                                    columnText.SetLeading(point8, 0f);
                                }
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
                        else
                        {
                            bool flag9 = Convert.ToBoolean(dataRow["IsPDF"]);
                            string str37 = dataRow["UserType"].ToString();
                            if (!flag9 || !(this.SystemName.Trim().ToLower() == "quickcorporate"))
                            {
                                string.Concat(this.ImageToPath, "HorizontalLine.gif");
                                if (str7 != "noimage.jpg")
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
                                        if (str9 == "")
                                        {
                                            str7 = str8;
                                        }
                                        else
                                        {
                                            str7 = (!flag3 ? str8 : str9);
                                        }
                                        str7 = string.Concat(this.ImagePathFromFrontEnd, this.TemplateID, "\\Images\\", str7);
                                    }
                                    if (str22 != "")
                                    {
                                        str7 = string.Concat(this.ImageFromPath, this.CompanyID, "\\Images\\", str22);
                                        iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(str7);
                                        instance.SetDpi(300, 300);
                                        instance.SetAbsolutePosition(0f, 0f);
                                        float single18 = (float)Convert.ToDouble(str1);
                                        instance.ScaleAbsolute((float)Convert.ToDouble(str2), single18);
                                        overContent.AddImage(instance);
                                    }
                                    else
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(str7);
                                        image.SetDpi(300, 300);
                                        image.SetAbsolutePosition(point4, point5);
                                        if (image.Height >= image.Width)
                                        {
                                            if (str17 != "S")
                                            {
                                                float height = 0f;
                                                height = (float)point1 / image.Height;
                                                image.ScalePercent(height * 100f);
                                            }
                                            else
                                            {
                                                image.ScalePercent(100f);
                                                image.ScaleAbsolute(single10 - point4, point5 - single11);
                                            }
                                        }
                                        else if (str17 != "S")
                                        {
                                            float width2 = 0f;
                                            width2 = (float)point / image.Width;
                                            image.ScalePercent(width2 * 100f);
                                        }
                                        else
                                        {
                                            image.ScalePercent(100f);
                                            image.ScaleAbsolute(single10 - point4, point5 - single11);
                                        }
                                        if (single7 > 0f)
                                        {
                                            image.Rotate();
                                            image.Rotation = single7 * 0.0174532924f;
                                        }
                                        overContent.AddImage(image);
                                    }
                                }
                            }
                            else
                            {
                                string str38 = dataRow["PDFCompanyID"].ToString();
                                string str39 = dataRow["PDFUserID"].ToString();
                                string empty1 = string.Empty;
                                string str40 = dataRow["UsedPDFName"].ToString();
                                if (str37.Trim().ToLower() != "admin")
                                {
                                    string[] imagePathFromFrontEnd = new string[] { this.ImagePathFromFrontEnd, "UsersImages\\", str39, "\\pdf\\", str40.Replace(".png", ".pdf") };
                                    empty1 = string.Concat(imagePathFromFrontEnd);
                                }
                                else
                                {
                                    empty1 = string.Concat(this.ImageFromPath, str38, "\\pdf\\", str40.Replace(".png", ".pdf"));
                                }
                                PdfReader pdfReader1 = new PdfReader(empty1, (new ASCIIEncoding()).GetBytes(""));
                                PdfImportedPage importedPage = pdfStamper.GetImportedPage(pdfReader1, 1);
                                float width3 = 0f;
                                float height1 = 0f;
                                width3 = (float)point / importedPage.Width;
                                height1 = (float)point1 / importedPage.Height;
                                float single19 = Math.Min(width3, height1);
                                overContent.AddTemplate(importedPage, single19, 0f, 0f, single19, point4, point5);
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
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@TemplateID", this.TemplateID), new SqlParameter("@CartItemID", this.CartItemID) };
            return EditableTemplate.DataAccessLayer.SQL.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, "et_Generate_PDF", sqlParameter);
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
            this.GeneratePDF();
            this.MakeWaterMarkfalse = false;
            this._IsOverPrintForAdmin = true;
            string[] secureDocPath = new string[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
            this.PDFPathForAdmin = string.Concat(secureDocPath);
            if (!Directory.Exists(this.PDFPathForAdmin))
            {
                Directory.CreateDirectory(this.PDFPathForAdmin);
            }
            Thread.Sleep(8000);
            this.GeneratePDF();
            DataTable dataTable = new DataTable();
            dataTable = CartBasePage.Get_Status(Convert.ToInt64(this.CartItemID));
            if (dataTable.Rows.Count > 0)
            {
                this._curentstatus = dataTable.Rows[0]["OrderStatus"].ToString();
            }
            if (this._curentstatus != "C")
            {
                CartBasePage.Update_SaveName_Status(Convert.ToInt64(this.CartItemID), this.TOPDFName, "");
                base.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "closepage", "<script type='text/JavaScript'>window.close();</script>");
                return;
            }
            CartBasePage.Update_PDFNameC(Convert.ToInt64(this.CartItemID), this.TOPDFName, "", "", "");
            HttpResponse response = base.Response;
            string[] cartItemID = new string[] { str, "ShoppingCart.aspx?ID=", item, "&CartItemID=", this.CartItemID };
            response.Redirect(string.Concat(cartItemID));
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