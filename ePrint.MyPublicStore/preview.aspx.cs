using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.MyPublicStore
{
    public partial class preview : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected Label lbl_nav_catagoty;

        //protected Label lbl_nav_product;

        //protected Label lbl_nav_productName;

        //protected Label Label1;

        //protected HtmlGenericControl navigation_div;

        //protected CheckBox chkconform;

        //protected Button btnback;

        //protected Button addtocart;

        //protected HtmlIframe pdfframe;

        protected FontStyle objFontStyle;

        private commonclass comm = new commonclass();

        public string PDFFrom = string.Empty;

        public string StorePDFTo = string.Empty;

        public string PDFToURL = string.Empty;

        public string ImagePathFromFrontEnd = string.Empty;

        public string FontFilePathForPDF = string.Empty;

        public string ImageFromPath = string.Empty;

        public string ImageToPath = string.Empty;

        private string Label_FontStyle = string.Empty;

        private string _finalpdfpath = "";

        private string SitePath = "";

        private string TemplateID = string.Empty;

        private string SessionID1 = string.Empty;

        public double CropMarkWidth;

        public double CropMarkHeight;

        public bool isAllowPDFPreviews;

        public bool isPDFPreviewMandatory;

        public bool isAllowWaterMark;

        public string WaterMarkText;

        private string AccountID = "0";

        private string CartItemID = "0";

        private string CompanyID = "0";

        private string PriceCatID = "0";

        private string TOPDFName = "";

        private string CropedPDFName = "";

        public string StorePDFToLocalFolder = "";

        private string fromstore = "";

        private string AccountType = string.Empty;

        public int PriceCatalogueCategoryID;

        private string ConnectionString = string.Empty;

        protected Color color;

        public int totalRequiredPages;

        public string LabelColor = "";

        public languageClass objLanguage = new languageClass();

        public string strSitepath = string.Empty;

        private string SystemName = "";

        private string TemplateName = "";

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

        public preview()
        {
        }

        protected void addtocart_Click(object sender, EventArgs e)
        {
            CartBasePage.Update_PDFNameC(Convert.ToInt64(this.CartItemID), this.TOPDFName, "", "", "");
            HttpResponse response = base.Response;
            string[] sitePath = new string[] { this.SitePath, "BlanckPageForCart.aspx?ID=", this.PriceCatID, "&CartItemID=", this.CartItemID, "&TemplateID=", this.TemplateID, "&CompanyID=", this.CompanyID };
            response.Redirect(string.Concat(sitePath));
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                HttpResponse response = base.Response;
                string[] sitePath = new string[] { this.SitePath, "products/edit_template", ConnectionClass.KeySeparator, this.CartItemID, ConnectionClass.KeySeparator, this.PriceCatID, ConnectionClass.FileExtension };
                response.Redirect(string.Concat(sitePath));
                return;
            }
            HttpResponse httpResponse = base.Response;
            string[] strArrays = new string[] { this.SitePath, "products/edit_template", ConnectionClass.FileExtension, "?CartItemID=", this.CartItemID, "&ID=", this.PriceCatID };
            httpResponse.Redirect(string.Concat(strArrays));
        }

        public void changePageSize(string outputURI, string pdf)
        {
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

        private void GeneratePDF()
        {
            DateTime date;
            Thread.Sleep(5000);
            DataSet templateData = this.GetTemplateData();
            DataTable item = templateData.Tables[0];
            Document document = new Document();
            string empty = string.Empty;
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
                this.isPDFPreviewMandatory = Convert.ToBoolean(row["isPDFPreviewMandatory"]);
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
            string str2 = string.Concat(this.PDFFrom, this.CompanyID, "\\pdf\\", empty.ToString());
            this.TOPDFName = string.Concat(this.CartItemID, "_", empty.ToString());
            string str3 = string.Concat(this.StorePDFTo, this.AccountID, "\\pdf");
            string str4 = string.Concat(str3, "\\", this.TOPDFName);
            if (!Directory.Exists(str3))
            {
                Directory.CreateDirectory(str3);
            }
            PdfReader pdfReader = new PdfReader(str2);
            this.PDFToURL = string.Concat(this.PDFToURL, this.AccountID, "/pdf/", this.TOPDFName);
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
                    double num6 = Convert.ToDouble(dataRow["MaxWidth"]);
                    double num7 = Convert.ToDouble(dataRow["MaxHeight"]);
                    string str13 = dataRow["ExceedImage"].ToString();
                    string str14 = dataRow["ExceedWidth"].ToString();
                    double num8 = Convert.ToDouble(dataRow["PixelWidth"]);
                    bool flag2 = Convert.ToBoolean(dataRow["IsCropFromTop"]);
                    bool flag3 = Convert.ToBoolean(dataRow["IsCropped"]);
                    double num9 = Convert.ToDouble(dataRow["Positionx"]);
                    double num10 = Convert.ToDouble(dataRow["Positiony"]);
                    string str15 = dataRow["ImageLocation"].ToString();
                    if (str9.Trim().ToLower() == "image" && str13 == "P")
                    {
                        if (str15 == "TL")
                        {
                            num10 = num10 + Math.Abs(num5 - num7);
                        }
                        else if (str15 == "TC")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num6 / 2);
                            num10 = num10 + Math.Abs(num5 - num7);
                        }
                        else if (str15 == "TR")
                        {
                            num9 = num9 + Math.Abs(num4 - num6);
                            num10 = num10 + Math.Abs(num5 - num7);
                        }
                        else if (str15 == "CL")
                        {
                            num10 = num10 + Math.Abs(num5 / 2 - num7 / 2);
                        }
                        else if (str15 == "C")
                        {
                            num9 = num9 + Math.Abs(num4 / 2 - num6 / 2);
                            num10 = num10 + Math.Abs(num5 / 2 - num7 / 2);
                        }
                        else if (str15 == "CR")
                        {
                            num9 = num9 + Math.Abs(num4 - num6);
                            num10 = num10 + Math.Abs(num5 / 2 - num7 / 2);
                        }
                        else if (str15 != "BL")
                        {
                            if (str15 == "BC")
                            {
                                num9 = num9 + Math.Abs(num4 / 2 - num6 / 2);
                            }
                            else if (str15 != "BR")
                            {
                                num10 = num10 + Math.Abs(num5 - num7);
                            }
                            else
                            {
                                num9 = num9 + Math.Abs(num4 - num6);
                            }
                        }
                        if (str13 == "P")
                        {
                            num4 = num6;
                            num5 = num7;
                        }
                    }
                    string str16 = dataRow["ManualTracking"].ToString();
                    char[] chrArray = new char[] { ',' };
                    string[] strArrays = str16.Split(chrArray);
                    double num11 = 0;
                    string str17 = "+";
                    string str18 = "pt";
                    if ((int)strArrays.Length != 1)
                    {
                        str17 = strArrays[0];
                        num11 = Convert.ToDouble(strArrays[1]);
                        str18 = strArrays[2];
                    }
                    else
                    {
                        num11 = Convert.ToDouble(dataRow["ManualTracking"]);
                        str17 = "+";
                        str18 = "pt";
                    }
                    double num12 = Convert.ToDouble(dataRow["LineSpacing"]);
                    double num13 = Convert.ToDouble(dataRow["MaxShrink"]);
                    string str19 = dataRow["BackgroundColor"].ToString();
                    long num14 = Convert.ToInt64(dataRow["GroupID"]);
                    string str20 = dataRow["GroupOrientation"].ToString();
                    string str21 = dataRow["Labels"].ToString();
                    string lower = dataRow["Value"].ToString();
                    dataRow["LabelStyle"].ToString();
                    string str22 = dataRow["LabelPosition"].ToString();
                    double num15 = Convert.ToDouble(dataRow["CustomLeft"]);
                    double num16 = Convert.ToDouble(dataRow["CustomTop"]);
                    double num17 = Convert.ToDouble(dataRow["CustomRight"]);
                    this.LabelColor = dataRow["LabelColor"].ToString();
                    this.Label_FontStyle = dataRow["LabelFontStyle"].ToString();
                    bool flag4 = Convert.ToBoolean(dataRow["SpotColor"]);
                    string str23 = dataRow["SpotColorRef"].ToString();
                    dataRow["LabelActualFontName"].ToString();
                    string str24 = dataRow["LabelFontExtension"].ToString();
                    dataRow["ActualFontFamilyName"].ToString();
                    string str25 = dataRow["FontExtension"].ToString();
                    double num18 = Convert.ToDouble(dataRow["LabelFontSize"]);
                    double num19 = Convert.ToDouble(dataRow["RotateAngle"]);
                    string str26 = dataRow["textAlign"].ToString();
                    if (str26.Trim().Length == 0)
                    {
                        str26 = "left";
                    }
                    double num20 = 0;
                    double num21 = 0;
                    double num22 = 0;
                    double num23 = 0;
                    double num24 = 0;
                    float single = 0f;
                    float single1 = 0f;
                    float single2 = 0f;
                    float single3 = 0f;
                    float single4 = 0f;
                    try
                    {
                        num20 = Convert.ToDouble(dataRow["C"]);
                        num21 = Convert.ToDouble(dataRow["M"]);
                        num22 = Convert.ToDouble(dataRow["Y"]);
                        num23 = Convert.ToDouble(dataRow["K"]);
                        num24 = Convert.ToDouble(dataRow["Tint"]);
                    }
                    catch
                    {
                    }
                    single = (float)num20;
                    single1 = (float)num21;
                    single2 = (float)num22;
                    single3 = (float)num23;
                    single4 = (float)num24 / 100f;
                    num1 = Convert.ToInt32(dataRow["pagenumber"]);
                    overContent = pdfStamper.GetOverContent(num1);
                    double num25 = 0;
                    double num26 = num10;
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
                        num25 = Convert.ToDouble(dataRow["OffsetLeft"]);
                        if (str22 == "Attached")
                        {
                        }
                        if (num14 == (long)0)
                        {
                            if (str26 == "Center")
                            {
                                num9 = num25;
                            }
                            if (str26 == "Right")
                            {
                                num9 = num25;
                            }
                            if (str21 != "None" && str22 != "Attached")
                            {
                                num9 = Convert.ToDouble(dataRow["Positionx"]);
                            }
                            if (str21 != "None" && str22 == "customLeft" && str26 == "Center")
                            {
                                num9 = Convert.ToDouble(dataRow["OffsetLeft"]);
                            }
                        }
                        else if (str20 == "Horizontal")
                        {
                            if (str26 == "Right" && str22 != "Attached")
                            {
                                num9 = num25;
                            }
                            if (str26 == "Right" && str22 == "Attached" && num14 > (long)0)
                            {
                                num9 = num25;
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
                    float single5 = (float)num13;
                    float single6 = (float)num11;
                    float point6 = this.MmToPoint((float)num2);
                    float single7 = (float)num19;
                    float single8 = point4 + point2;
                    float single9 = point5 + point3;
                    float single10 = point4 + point;
                    float single11 = point5 - point1;
                    if (str5 == "First Cap")
                    {
                        bool flag5 = false;
                        char[] charArray = upper.ToCharArray();
                        string str27 = "";
                        for (int i = 0; i < (int)charArray.Length; i++)
                        {
                            if (flag5 || i == 0)
                            {
                                str27 = string.Concat(str27, charArray[i].ToString().ToUpper());
                                flag5 = false;
                            }
                            else
                            {
                                str27 = string.Concat(str27, charArray[i].ToString().ToLower());
                            }
                            if (charArray[i] == ' ' || charArray[i] == '\r')
                            {
                                flag5 = true;
                            }
                        }
                        upper = str27;
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
                    if (str9.Trim().Length > 0 && flag1)
                    {
                        if (Convert.ToInt32(str9) == 3)
                        {
                            string.Concat(this.ImageToPath, "HorizontalLine.gif");
                            if (str6 != "noimage.jpg")
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
                                    if (str8 == "")
                                    {
                                        str6 = str7;
                                    }
                                    else
                                    {
                                        str6 = (!flag3 ? str7 : str8);
                                    }
                                    str6 = string.Concat(this.ImagePathFromFrontEnd, this.TemplateID, "\\Images\\", str6);
                                }
                                if (str19 != "")
                                {
                                    str6 = string.Concat(this.ImageFromPath, this.CompanyID, "\\Images\\", str19);
                                    iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(str6);
                                    instance.SetDpi(300, 300);
                                    instance.SetAbsolutePosition(0f, 0f);
                                    float single12 = (float)Convert.ToDouble(str);
                                    instance.ScaleAbsolute((float)Convert.ToDouble(str1), single12);
                                    overContent.AddImage(instance);
                                }
                                else
                                {
                                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(str6);
                                    image.SetDpi(300, 300);
                                    image.SetAbsolutePosition(point4, point5);
                                    if (image.Height >= image.Width)
                                    {
                                        if (str13 != "S")
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
                                    else if (str13 != "S")
                                    {
                                        float width = 0f;
                                        width = (float)point / image.Width;
                                        image.ScalePercent(width * 100f);
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
                        else if (Convert.ToInt32(str9) != 13 && upper.Trim().ToLower().IndexOf("www.paypal.com") == -1 && str10.Trim().ToLower().IndexOf("barcode39") == -1)
                        {
                            int num27 = 0;
                            this.objFontStyle = FontStyle.Regular;
                            if (str11.ToLower().Trim() == "bold")
                            {
                                num27 = 1;
                                this.objFontStyle = FontStyle.Bold;
                            }
                            if (str12.ToLower().Trim() == "italic")
                            {
                                num27 = 2;
                                this.objFontStyle = FontStyle.Italic;
                            }
                            if (str11.ToLower().Trim() == "bold" && str12.ToLower().Trim() == "italic")
                            {
                                num27 = 3;
                                this.objFontStyle = FontStyle.Bold | FontStyle.Italic;
                            }
                            float single13 = (float)num3;
                            if (str10.Contains("Bold"))
                            {
                                if (num27 == 1)
                                {
                                    num27 = 0;
                                }
                                if (num27 == 3)
                                {
                                    num27 = 2;
                                }
                            }
                            if (str10.Contains("Italic") && num27 == 2)
                            {
                                num27 = 0;
                            }
                            double num28 = (double)single4;
                            if (str10.Contains("Bold"))
                            {
                                if (num27 == 1)
                                {
                                    num27 = 0;
                                }
                                if (num27 == 3)
                                {
                                    num27 = 0;
                                }
                            }
                            if (str10.Contains("Italic") && num27 == 2)
                            {
                                num27 = 0;
                            }
                            Guid guid = Guid.NewGuid();
                            string str28 = guid.ToString().Substring(0, 10);
                            FontFactory.Register(string.Concat(this.FontFilePathForPDF, str25), str28);
                            iTextSharp.text.Font font = null;
                            font = FontFactory.GetFont(str28, "Cp1252", true, single13, num27, new CMYKColor(single, single1, single2, single3));
                            font.GetCalculatedBaseFont(false);
                            PdfSpotColor pdfSpotColor = null;
                            if (flag4)
                            {
                                pdfSpotColor = new PdfSpotColor(str23, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor, single4);
                                font = FontFactory.GetFont(str28, "Cp1252", true, single13, num27, new SpotColor(pdfSpotColor, single4));
                                font.GetCalculatedBaseFont(false);
                            }
                            if ((double)single4 < 1 && !flag4)
                            {
                                PdfSpotColor pdfSpotColor1 = new PdfSpotColor(str23, new CMYKColor(single, single1, single2, single3));
                                overContent.SetColorStroke(pdfSpotColor1, single4);
                                overContent.SetColorFill(pdfSpotColor1, single4);
                            }
                            int num29 = 0;
                            if (dataRow["textalign"].ToString().Trim().ToLower() == "left")
                            {
                                num29 = 0;
                            }
                            else if (dataRow["textalign"].ToString().Trim().ToLower() != "center")
                            {
                                num29 = (dataRow["textalign"].ToString().Trim().ToLower() != "right" ? 3 : 2);
                            }
                            else
                            {
                                num29 = 1;
                            }
                            ColumnText columnText = new ColumnText(overContent);
                            Phrase phrase = new Phrase(string.Empty);
                            Phrase phrase1 = new Phrase(string.Empty);
                            Chunk chunk = null;
                            Chunk chunk1 = null;
                            chunk = new Chunk(upper, font);
                            phrase.Add(0, chunk);
                            if (str14 == "Track")
                            {
                                single5 = (float)(num8 / 100);
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
                                if (str17 == "+" && str18 == "pt")
                                {
                                    chunk.SetCharacterSpacing(single6);
                                }
                                if (str17 == "+" && str18 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(single6);
                                }
                                if (str17 == "-" && str18 == "pt")
                                {
                                    chunk.SetCharacterSpacing(-single6);
                                }
                                if (str17 == "-" && str18 == "mm")
                                {
                                    single6 = (float)((double)single6 / 0.352777778);
                                    chunk.SetCharacterSpacing(-single6);
                                }
                            }
                            if (str9 == "1")
                            {
                                if (str21 == "None")
                                {
                                    if (num29 == 1 && str20 == "Horizontal" && num14 > (long)0)
                                    {
                                        num29 = 0;
                                    }
                                    if (point6 > 0f)
                                    {
                                        point4 = point4 + point6;
                                    }
                                    if ((!(str17 == "+") || !(str18 == "pt")) && (!(str17 == "+") || !(str18 == "mm")))
                                    {
                                        ColumnText.ShowTextAligned(overContent, num29, phrase, point4 - single6, point5, single7);
                                    }
                                    else
                                    {
                                        ColumnText.ShowTextAligned(overContent, num29, phrase, point4 + single6, point5, single7);
                                    }
                                }
                                else
                                {
                                    if (upper == string.Empty)
                                    {
                                        lower = string.Empty;
                                    }
                                    double num30 = 0;
                                    double num31 = 0;
                                    double num32 = 0;
                                    double num33 = 100;
                                    bool flag6 = false;
                                    string str29 = "";
                                    double num34 = 0;
                                    float single14 = 0f;
                                    float single15 = 0f;
                                    float single16 = 0f;
                                    float single17 = 100f;
                                    float single18 = 0f;
                                    double num35 = 0;
                                    string str30 = "+";
                                    string str31 = "pt";
                                    bool flag7 = false;
                                    if (this.LabelColor != "")
                                    {
                                        DataSet labelColor = this.GetLabelColor();
                                        DataTable dataTable = labelColor.Tables[0];
                                        foreach (DataRow row1 in labelColor.Tables[0].Rows)
                                        {
                                            try
                                            {
                                                num30 = Convert.ToDouble(row1["C"]);
                                                num31 = Convert.ToDouble(row1["M"]);
                                                num32 = Convert.ToDouble(row1["Y"]);
                                                num33 = Convert.ToDouble(row1["K"]);
                                                flag6 = Convert.ToBoolean(row1["SpotColor"]);
                                                str29 = row1["SpotColorRef"].ToString();
                                                num34 = Convert.ToDouble(row1["Tint"]);
                                            }
                                            catch
                                            {
                                            }
                                            single14 = (float)num30 / 100f;
                                            single15 = (float)num31 / 100f;
                                            single16 = (float)num32 / 100f;
                                            single17 = (float)num33 / 100f;
                                            single18 = (float)num34 / 100f;
                                            flag7 = true;
                                        }
                                    }
                                    if (this.Label_FontStyle != "")
                                    {
                                        DataSet labelFontStyle = this.GetLabelFontStyle();
                                        DataTable item1 = labelFontStyle.Tables[0];
                                        string str32 = "";
                                        foreach (DataRow dataRow1 in labelFontStyle.Tables[0].Rows)
                                        {
                                            string str33 = dataRow1["ManualTracking"].ToString();
                                            chrArray = new char[] { ',' };
                                            string[] strArrays1 = str33.Split(chrArray);
                                            str32 = dataRow1["Capitalize"].ToString();
                                            if ((int)strArrays1.Length != 1)
                                            {
                                                str30 = strArrays1[0];
                                                num35 = Convert.ToDouble(strArrays1[1]);
                                                str31 = strArrays1[2];
                                            }
                                            else
                                            {
                                                num35 = Convert.ToDouble(dataRow1["ManualTracking"]);
                                                str30 = "+";
                                                str31 = "pt";
                                            }
                                            if (str32 == "First Cap")
                                            {
                                                bool flag8 = false;
                                                char[] chrArray1 = lower.ToCharArray();
                                                string str34 = "";
                                                for (int k = 0; k < (int)chrArray1.Length; k++)
                                                {
                                                    if (flag8 || k == 0)
                                                    {
                                                        str34 = string.Concat(str34, chrArray1[k].ToString().ToUpper());
                                                        flag8 = false;
                                                    }
                                                    else
                                                    {
                                                        str34 = string.Concat(str34, chrArray1[k].ToString().ToLower());
                                                    }
                                                    if (chrArray1[k] == ' ' || chrArray1[k] == '\r')
                                                    {
                                                        flag8 = true;
                                                    }
                                                }
                                                lower = str34;
                                            }
                                            if (str32 == "All Caps")
                                            {
                                                lower = lower.ToUpper();
                                            }
                                            if (str32 == "All Lower")
                                            {
                                                lower = lower.ToLower();
                                            }
                                            if (str32 != "InitCap")
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
                                    if (num18 == 0)
                                    {
                                        num18 = (double)single13;
                                    }
                                    guid = Guid.NewGuid();
                                    string str35 = guid.ToString().Substring(0, 10);
                                    FontFactory.Register(string.Concat(this.FontFilePathForPDF, str24), str35);
                                    iTextSharp.text.Font font1 = null;
                                    font1 = FontFactory.GetFont(str35, "Cp1252", true, (float)num18, num27, new CMYKColor(single14, single15, single16, single17));
                                    font1.GetCalculatedBaseFont(true);
                                    PdfSpotColor pdfSpotColor2 = null;
                                    if (flag6)
                                    {
                                        pdfSpotColor2 = new PdfSpotColor(str29, new CMYKColor(single14, single15, single16, single17));
                                        overContent.SetColorStroke(pdfSpotColor2, single18);
                                        font1 = FontFactory.GetFont(str35, "Cp1252", true, (float)num18, num27, new SpotColor(pdfSpotColor2, single18));
                                        font1.GetCalculatedBaseFont(true);
                                    }
                                    if ((double)single18 < 1 && !flag6 && flag7)
                                    {
                                        PdfSpotColor pdfSpotColor3 = new PdfSpotColor(str29, new CMYKColor(single14, single15, single16, single17));
                                        overContent.SetColorStroke(pdfSpotColor3, single18);
                                        overContent.SetColorFill(pdfSpotColor3, single18);
                                    }
                                    phrase1 = new Phrase();
                                    chunk1 = new Chunk(lower, font1);
                                    phrase1.Add(0, chunk1);
                                    if (num35 > 0)
                                    {
                                        if (str30 == "+" && str31 == "pt")
                                        {
                                            chunk1.SetCharacterSpacing((float)num35);
                                        }
                                        if (str30 == "+" && str31 == "mm")
                                        {
                                            num35 = (double)((float)((double)((float)num35) / 0.352777778));
                                            chunk1.SetCharacterSpacing((float)num35);
                                        }
                                        if (str30 == "-" && str31 == "pt")
                                        {
                                            chunk1.SetCharacterSpacing(-(float)num35);
                                        }
                                        if (str30 == "-" && str31 == "mm")
                                        {
                                            num35 = (double)((float)((double)((float)num35) / 0.352777778));
                                            chunk1.SetCharacterSpacing(-(float)num35);
                                        }
                                    }
                                    if (num15 >= 0 && str22 == "customLeft")
                                    {
                                        this.PixelToPoint((float)num15);
                                        float point7 = this.MmToPoint((float)num15);
                                        if (num29 == 0)
                                        {
                                            ColumnText.ShowTextAligned(overContent, num29, phrase1, point4, point5, single7);
                                            ColumnText.ShowTextAligned(overContent, num29, phrase, point4 + point7, point5, single7);
                                        }
                                        if (num29 == 1)
                                        {
                                            if (!(str20 == "Horizontal") || num14 <= (long)0)
                                            {
                                                ColumnText.ShowTextAligned(overContent, num29, phrase, point4 + point7 / 2f, point5, single7);
                                                float width1 = ColumnText.GetWidth(phrase) / 2f;
                                                ColumnText.ShowTextAligned(overContent, num29, phrase1, point4 - width1, point5, single7);
                                            }
                                            else
                                            {
                                                num29 = 0;
                                                ColumnText.ShowTextAligned(overContent, num29, phrase, point4, point5, single7);
                                                ColumnText.ShowTextAligned(overContent, num29, phrase1, point4 - point7, point5, single7);
                                            }
                                        }
                                        if (num29 == 2)
                                        {
                                            if (num14 == (long)0)
                                            {
                                                point4 = this.MmToPoint((float)num25);
                                            }
                                            if ((!(str17 == "+") || !(str18 == "pt")) && (!(str17 == "+") || !(str18 == "mm")))
                                            {
                                                ColumnText.ShowTextAligned(overContent, num29, phrase, point4 - single6, point5, single7);
                                            }
                                            else
                                            {
                                                ColumnText.ShowTextAligned(overContent, num29, phrase, point4 + single6, point5, single7);
                                            }
                                            float width2 = point4 - (ColumnText.GetWidth(phrase) + point7);
                                            ColumnText.ShowTextAligned(overContent, 0, phrase1, width2, point5, single7);
                                        }
                                    }
                                    if (num17 >= 0)
                                    {
                                    }
                                    if (num16 >= 0 && str22 == "customTop")
                                    {
                                        this.PixelToPoint((float)num16);
                                        columnText.SetSimpleColumn(phrase, point4, point5, single10, single11, 0f, num29);
                                        phrase1 = new Phrase(lower, font1);
                                        columnText.SetSimpleColumn(phrase1, point4, point5, single10, single11, 0f, num29);
                                    }
                                    else if (str22 == "Attached")
                                    {
                                        if (num29 == 1 && str20 == "Horizontal" && str22 == "Attached" && num14 > (long)0)
                                        {
                                            num29 = 0;
                                        }
                                        phrase1.Add(phrase);
                                        if ((!(str17 == "+") || !(str18 == "pt")) && (!(str17 == "+") || !(str18 == "mm")))
                                        {
                                            ColumnText.ShowTextAligned(overContent, num29, phrase1, point4 - single6, point5, single7);
                                        }
                                        else
                                        {
                                            ColumnText.ShowTextAligned(overContent, num29, phrase1, point4 + single6, point5, single7);
                                        }
                                    }
                                }
                            }
                            else if (str9 == "2")
                            {
                                float point8 = this.MmToPoint((float)num12);
                                if (point6 > 0f)
                                {
                                    point4 = point4 + point6;
                                }
                                if (point8 <= 0f)
                                {
                                    columnText.SetSimpleColumn(phrase, point4, point5, single8, single9, single13, num29);
                                }
                                else
                                {
                                    phrase = new Phrase(point8);
                                    phrase.Add(chunk);
                                    if (num29 == 1)
                                    {
                                        num26 = num26 / 2;
                                    }
                                    columnText.SetSimpleColumn(phrase, point4, point5, single8, single9 + (float)num12, single13, num29);
                                    columnText.SetLeading(point8, 0f);
                                }
                            }
                            try
                            {
                                columnText.Go();
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
            commonclass _commonclass = new commonclass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetLabelColor_ForPDF");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, this.CompanyID);
            database.AddInParameter(storedProcCommand, "@ColorName", DbType.String, this.LabelColor);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataSet GetLabelFontStyle()
        {
            commonclass _commonclass = new commonclass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetFontStyle_ForPDF");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, this.CompanyID);
            database.AddInParameter(storedProcCommand, "@LabelFontStyle", DbType.String, this.Label_FontStyle);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataSet GetTemplateData()
        {
            commonclass _commonclass = new commonclass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_Generate_PDF");
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, this.TemplateID);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, this.CartItemID);
            return database.ExecuteDataSet(storedProcCommand);
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
            if (ConnectionClass.AccountID == null || !(ConnectionClass.AccountID != ""))
            {
                this.AccountID = "0";
            }
            else
            {
                this.AccountID = Convert.ToString(ConnectionClass.AccountID);
            }
            if (ConnectionClass.CompanyID == null || !(ConnectionClass.CompanyID != ""))
            {
                this.CompanyID = "2099";
            }
            else
            {
                this.CompanyID = Convert.ToString(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.SystemName == null || !(ConnectionClass.SystemName != ""))
            {
                this.SystemName = "";
            }
            else
            {
                this.SystemName = Convert.ToString(ConnectionClass.SystemName);
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (base.Request.QueryString["CompanyID"].ToString() == "")
            {
                this.CompanyID = "2099";
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
            base.Title = commonclass.pageTitle("PDF Preview", Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID));
            this.AccountType = this.comm.return_AccountType(Convert.ToInt64(this.CompanyID), Convert.ToInt64(this.AccountID));
            if (this.Session["StoreUserID"] != null)
            {
                if (this.comm.GetDisplayValue("IsHome", Convert.ToInt64(this.AccountID)) != "true")
                {
                    this.lbl_home.Visible = false;
                    this.lbl_spliter.Visible = false;
                }
                else
                {
                    this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID), 0);
                    this.lbl_home.Visible = true;
                    this.lbl_spliter.Visible = true;
                }
            }
            else if (this.AccountType != "x")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else if (this.comm.GetDisplayValue("IsHome", Convert.ToInt64(this.AccountID)) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            foreach (DataRow row in ProductBasePage.productsDetails_Select(Convert.ToInt32(this.PriceCatID)).Rows)
            {
                BaseClass baseClass = new BaseClass();
                this.lbl_nav_productName.Text = baseClass.SpecialDecode(row["CatalogueName"].ToString());
                this.PriceCatalogueCategoryID = Convert.ToInt32(row["PriceCatalogueCategoryID"].ToString());
                this.lbl_nav_product.Text = baseClass.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
            }
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
            this.ImageToPath = EprintConfigurationManager.AppSettings["ImagetoPath"].ToString();
            this.ConnectionString = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();
            this.FontFilePathForPDF = string.Concat(EprintConfigurationManager.AppSettings["ImageFromPath"].ToString(), "Fonts//");
            try
            {
                this.TemplateID = base.Request.QueryString["TemplateID"].ToString();
            }
            catch
            {
                this.SessionID1 = "1ywnrhmlx0xnuwsf0wxtmex0";
                this.TemplateID = "1170";
            }
            if (!base.IsPostBack)
            {
                this.GeneratePDF();
                CartBasePage.Update_PDFNameP(Convert.ToInt64(this.CartItemID), this.TOPDFName, "", "");
                this.pdfframe.Attributes["src"] = this._finalpdfpath;
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