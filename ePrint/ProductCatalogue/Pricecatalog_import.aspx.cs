using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using Sample.Web.UI.Compatibility;
using Spire.DataExport.XLS;
using Spire.DataExport.Common;
//using Spire.Xls;
//using Spire.Xls.Collections;
//using Spire.Xls.Core.Spreadsheet;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using System.Linq;
//using Syncfusion.XlsIO;

namespace ePrint.ProductCatalogue
{
    public partial class Pricecatalog_import : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        public string strImagepath = global.imagePath();

        private Global gloobj = new Global();

        private int CompanyID;

        public int count;

        public int count1;

        public string action = "add";

        private commonClass objJava = new commonClass();

        public languageClass objlang = new languageClass();

        private SettingsBasePage obj = new SettingsBasePage();

        public int PageSize = 5;

        public int PageIndex = 1;

        public int totalrec;

        public string colorformat = string.Empty;

        public ArrayList screenNameArray = new ArrayList();

        public ArrayList screenNameArrayForPriceMatrix = new ArrayList();

        public string IswebStore = string.Empty;

        public int UserID;

        public string SystemName = string.Empty;

        public string ActualFileName = string.Empty;
        public string ZipActualFileName = string.Empty;

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

        public Pricecatalog_import()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "ProductCatalogue/PriceCatalogue.aspx"));
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString().Substring(0, 10);
            string fileName = this.fileCsv.FileName;
            this.ActualFileName = fileName;
            string[] strArrays = fileName.Split(new char[] { '\\' });
            string str1 = strArrays[(int)strArrays.Length - 1];
            string.Concat("Import/", strArrays[(int)strArrays.Length - 1]);
            ////////////////For products image files by Amin///////////////
            string ZipfileName = this.FileUploadZip.FileName;
            this.ZipActualFileName = ZipfileName;
             strArrays = ZipfileName.Split(new char[] { '\\' });
            string strzip = strArrays[(int)strArrays.Length - 1];
            string.Concat("Import/", strArrays[(int)strArrays.Length - 1]);
            //////////////// End of product image By Amin/////////////////
            if (!Directory.Exists(base.Server.MapPath("./Import/")))
            {
                Directory.CreateDirectory(base.Server.MapPath("./Import/"));
            }
            if (!Directory.Exists(string.Concat(base.Server.MapPath("./Import/"), this.SystemName)))
            {
                Directory.CreateDirectory(string.Concat(base.Server.MapPath("./Import/"), this.SystemName));
                string[] strArrays1 = new string[] { base.Server.MapPath("./Import/"), this.SystemName, "\\", str, str1 };
                string str2 = string.Concat(strArrays1);
                if (!File.Exists(str2))
                {
                    this.fileCsv.SaveAs(str2);
                    fileName = string.Concat(str, str1);
                }
            }
            string[] strArrays2 = new string[] { base.Server.MapPath("./Import/"), this.SystemName, "\\", str, str1 };
            string str3 = string.Concat(strArrays2);
            if (!File.Exists(str3))
            {
                this.fileCsv.SaveAs(str3);
                fileName = string.Concat(str, str1);
            }
            //////////////////For product image file /////////////////
             strArrays2 = new string[] { base.Server.MapPath("./Import/"), this.SystemName, "\\", str, strzip };
             str3 = string.Concat(strArrays2);
            if (!File.Exists(str3))
            {
                this.FileUploadZip.SaveAs(str3);
                ZipfileName = string.Concat(str, strzip);
            }
            /////////////////End of product image file////////////////
            this.InsertFileFotImport(fileName, ZipfileName);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        }

        public void createExcelTable()
        {
            DataTable dataTable = new DataTable("Table1");
            dataTable.Columns.Add("Item Title", typeof(string));
            dataTable.Columns.Add("Item Code", typeof(string));
            dataTable.Columns.Add("Category Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Artwork", typeof(string));
            dataTable.Columns.Add("Color", typeof(string));
            dataTable.Columns.Add("Size", typeof(string));
            dataTable.Columns.Add("Material", typeof(string));
            dataTable.Columns.Add("Delivery", typeof(string));
            dataTable.Columns.Add("Finishing", typeof(string));
            dataTable.Columns.Add("Notes", typeof(string));
            dataTable.Columns.Add("Terms/Instructions", typeof(string));
            this.Session["Headers"] = dataTable;
        }

        public void createExcelTableForPriceMatrix()
        {
            DataTable dataTable = new DataTable("Table1");
            dataTable.Columns.Add("Item Title", typeof(string));
            dataTable.Columns.Add("Item Code", typeof(string));
            dataTable.Columns.Add("Category Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Artwork", typeof(string));
            dataTable.Columns.Add("Color", typeof(string));
            dataTable.Columns.Add("Size", typeof(string));
            dataTable.Columns.Add("Material", typeof(string));
            dataTable.Columns.Add("Delivery", typeof(string));
            dataTable.Columns.Add("Finishing", typeof(string));
            dataTable.Columns.Add("Notes", typeof(string));
            dataTable.Columns.Add("Terms/Instructions", typeof(string));
            dataTable.Columns.Add("FromQuantity", typeof(int));
            dataTable.Columns.Add("ToQuantity", typeof(double));
            dataTable.Columns.Add("Price", typeof(double));
            dataTable.Columns.Add("Markup", typeof(double));
            this.Session["Headers"] = dataTable;
        }

        //public void ExportData(DataTable WashedPart, string attachmentName)
        //{
        //    Workbook workbook = new Workbook()
        //    {
        //        Version = ExcelVersion.Version2007
        //    };
        //    Worksheet item = workbook.Worksheets[0];
        //    item.InsertDataTable(WashedPart, true, 1, 1);
        //    workbook.SaveToFile(attachmentName);
        //    FileInfo fileInfo = new FileInfo(attachmentName);
        //    if (!fileInfo.Exists)
        //    {
        //        base.Response.Write("This file does not exist.");
        //        return;
        //    }
        //    base.Response.Clear();
        //    base.Response.AddHeader("Content-Disposition", "attachment; filename=ProductCatalogueWithMatrix.xlsx");
        //    base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        //    base.Response.ContentType = "application/octet-stream";
        //    base.Response.WriteFile(fileInfo.FullName);
        //    base.Response.End();
        //}
        public string StripHTML(string html)
        {
            var regex = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return System.Web.HttpUtility.HtmlDecode((regex.Replace(html, "")));
        }
        public void Export_with_XSLT_Web(DataTable dsExport, string FileName)
        {
            //CellExport cellExport = new CellExport()
            //{
            //    ActionAfterExport = ActionType.OpenView,
            //    AutoFitColWidth = true
            //};
            //if ((dsExport.Columns.Contains("ItemDescription")))
            //{


            //    foreach (System.Data.DataColumn col in dsExport.Columns) col.ReadOnly = false;
            //    foreach (DataRow item in dsExport.Rows)
            //    {
            //        item["ItemDescription"] = StripHTML(item["ItemDescription"].ToString());

            //    }
            //}
            //cellExport.DataFormats.CultureName = "en-US";
            //cellExport.DataFormats.Currency = "#,###,##0.00";
            //cellExport.DataFormats.DateTime = "yyyy-M-d H:mm";
            //cellExport.DataFormats.Float = "#,###,##0.00";
            //cellExport.DataFormats.Integer = "#,###,##0";
            //cellExport.DataFormats.Time = "H:mm";
            //cellExport.SheetOptions.AggregateFormat.Font.Name = "Arial";
            //cellExport.SheetOptions.CustomDataFormat.Font.Name = "Arial";
            //cellExport.SheetOptions.DefaultFont.Name = "Arial";
            //cellExport.SheetOptions.FooterFormat.Font.Name = "Arial";
            //cellExport.SheetOptions.HeaderFormat.Font.Name = "Arial";
            //cellExport.SheetOptions.HyperlinkFormat.Font.Color = CellColor.Blue;
            //cellExport.SheetOptions.HyperlinkFormat.Font.Name = "Arial";
            //cellExport.SheetOptions.HyperlinkFormat.Font.Underline = XlsFontUnderline.Single;
            //cellExport.SheetOptions.NoteFormat.Alignment.Horizontal = HorizontalAlignment.Left;
            //cellExport.SheetOptions.NoteFormat.Alignment.Vertical = VerticalAlignment.Top;
            //cellExport.SheetOptions.NoteFormat.Font.Bold = true;
            //cellExport.SheetOptions.NoteFormat.Font.Name = "Tahoma";
            //cellExport.SheetOptions.NoteFormat.Font.Size = 8f;
            //cellExport.SheetOptions.TitlesFormat.Font.Bold = true;
            //cellExport.SheetOptions.TitlesFormat.Font.Name = "Arial";
            //cellExport.DataTable = dsExport;
            //cellExport.DataSource = ExportSource.DataTable;
            //FileName = FileName.ToLower().Replace(".csv", "").Replace(".xls", "");
            //cellExport.FileName = string.Concat(FileName, ".xls");
            //MemoryStream memoryStream = new MemoryStream();
            //cellExport.SaveToStream(memoryStream);
            //byte[] numArray = new byte[checked(memoryStream.Length)];
            //memoryStream.Read(numArray, 0, (int)numArray.Length);
            //memoryStream.Close();
            //Response.ClearHeaders();
            //Response.ClearContent();
            //this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //this.Response.AddHeader("content-disposition", string.Concat("attachment; filename=\"", cellExport.FileName, "\""));
            //this.Response.BinaryWrite(numArray);
            ////HttpContext.Current.ApplicationInstance.CompleteRequest();
            //Response.Flush();

            //Response.End();

            FileName = FileName.ToLower().Replace(".csv", "").Replace(".xls", "");
            FileName = string.Concat(FileName, ".xlsx");


            DataSet ds = new DataSet();
            DataTable dtCopy1 = dsExport.Copy();
            ds.Tables.Add(dtCopy1);
            //string fullPath = Path.Combine(Server.MapPath("~/temp"), FileName);
            //using (ExcelEngine excelEngine = new ExcelEngine())
            //{
            //    IApplication application = excelEngine.Excel;
            //    application.DefaultVersion = ExcelVersion.Xlsx;
            //    IWorkbook workbook = application.Workbooks.Create(1);
            //    IWorksheet worksheet = workbook.Worksheets[0];

            //    //Import DataTable to the worksheet.
            //    worksheet.ImportDataTable(dtCopy1, true, 1, 1);
            //    workbook.SaveAs(fullPath);

            //}
            //byte[] fileByteArray = System.IO.File.ReadAllBytes(fullPath);
            //System.IO.File.Delete(fullPath);

            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename= " + FileName + "");
            //Response.BinaryWrite(fileByteArray);
            //Response.End();

            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AppendHeader("Content-Disposition", FileName);

            //Response.BinaryWrite(fileByteArray);

            //var stream = new MemoryStream(fileByteArray);
            //stream.WriteTo(fileByteArray);
            //System.IO.File(fileByteArray, "application/vnd.ms-excel", fileName);

            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable _dt in ds.Tables)
                {
                    wb.Worksheets.Add(_dt);
                }

                Response.Clear();
                Response.Buffer = false;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= " + FileName + "");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            //}
        }
        public string[] GetExcelSheetNames(string excelFile)
        {
            string[] strArrays;
            OleDbConnection oleDbConnection = null;
            DataTable oleDbSchemaTable = null;
            try
            {
                try
                {
                    string str = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", base.Server.MapPath("./Import/"), excelFile, ";Extended Properties=Excel 12.0;");
                    oleDbConnection = new OleDbConnection(str);
                    oleDbConnection.Open();
                    oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (oleDbSchemaTable != null)
                    {
                        string[] str1 = new string[oleDbSchemaTable.Rows.Count];
                        int num = 0;
                        foreach (DataRow row in oleDbSchemaTable.Rows)
                        {
                            str1[num] = row["TABLE_NAME"].ToString();
                            num++;
                        }
                        strArrays = str1;
                    }
                    else
                    {
                        strArrays = null;
                    }
                }
                catch (Exception exception)
                {
                    strArrays = null;
                }
            }
            finally
            {
                if (oleDbConnection != null)
                {
                    oleDbConnection.Close();
                    oleDbConnection.Dispose();
                }
                if (oleDbSchemaTable != null)
                {
                    oleDbSchemaTable.Dispose();
                }
            }
            return strArrays;
        }

        protected void GridImport_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        public void InsertFileFotImport(string FileName, string ZipFileName)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            string empty = string.Empty;
            object[] companyID = new object[] { "insert into tb_PriceCatalogueimport(CompanyID,Filename,uploadeddate,uploadedby,isimported,ActualFileName,DuplicateRecords,ZipFileName,ZipActualFileName,ZipIsImported)values(", this.CompanyID, ",'", FileName, "','", DateTime.Now, "','", Convert.ToInt32(this.Session["UserID"]), "','", 0, "','", this.ActualFileName, "','", this.ddlDuplicateRecords.SelectedValue, "','", ZipFileName, "','", ZipActualFileName, "','", false, "')" };
            SqlCommand sqlCommand = new SqlCommand(string.Concat(companyID), sqlConnection)
            {
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            base.Message_Display(this.objlang.GetLanguageConversion("Produt_Catalogue_Import_Upload_Sucessful_Note"), "msg-success", this.plhMessage);
        }

        protected void lnkDownLoadDefault_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = (this.IswebStore.ToLower() != "yes" ? string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/Samplesheet.xls") : string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/SamplesheetwithStore.xls"));
            FileInfo fileInfo = new FileInfo(empty);
            if (!fileInfo.Exists)
            {
                base.Response.Write("This file does not exist.");
                return;
            }
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
            base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(fileInfo.FullName);
            base.Response.End();
        }

        protected void lnkDownLoadDefaultWithPriceMatrix_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = (this.IswebStore.ToLower() != "yes" ? string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/SamplesheetPricematrix.xls") : string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/SamplesheetPricematrixwithStore.xls"));
            FileInfo fileInfo = new FileInfo(empty);
            if (!fileInfo.Exists)
            {
                base.Response.Write("This file does not exist.");
                return;
            }
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
            base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(fileInfo.FullName);
            base.Response.End();
        }

        protected void lnkexistdefault_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(str);
            SqlCommand sqlCommand = new SqlCommand();
            EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
            dataTable = SettingsBasePage.Pricecatalog_Import((long)this.CompanyID, this.IswebStore, "c", "");
            this.plhCreateExcelSheet = new PlaceHolder();
            (new WebExport()).WebExportDetails(dataTable, WebExport.ExportFormat.Excel, "Pricecatalogue.xls", "");
        }

        protected void lnkexistdefaultWithPriceMatrix_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Pricecatalog_Import((long)this.CompanyID, this.IswebStore, "c", "Matrix");
            this.plhCreateExcelSheet = new PlaceHolder();
            DataTable dataTable1 = dataTable;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dataTable1, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "ProductCatalogueWithMatrix.xlsx")));
            Export_with_XSLT_Web(dataTable1, string.Concat(guid.ToString().Substring(0, 10), "ProductCatalogueWithMatrix.xlsx"));
        }

        protected void lnkexistdefaultwithpricesellingprice_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            DataTable dataTable = new DataTable();
            dataTable = SettingsBasePage.Pricecatalog_Import((long)this.CompanyID, this.IswebStore, "c", "SellingPrice");
            this.plhCreateExcelSheet = new PlaceHolder();
            DataTable dataTable1 = dataTable;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dataTable1, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "ProductCatalogueWithMatrix.xlsx")));
            Export_with_XSLT_Web(dataTable1, string.Concat(guid.ToString().Substring(0, 10), "ProductCatalogueWithMatrix.xlsx"));
        }

        protected void lnlDownLoadDefaultPriceMatrixWithSellingPrice_OnClick(object sender, EventArgs e)
        {
            string empty = string.Empty;
            empty = (this.IswebStore.ToLower() != "yes" ? string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/SampleFileWithOuteStoreSellingPrice.xls") : string.Concat(this.strFilepath, "Pricecatalogue Import Samplefiles/SampleFileWitheStoreSellingPrice.xls"));
            FileInfo fileInfo = new FileInfo(empty);
            if (!fileInfo.Exists)
            {
                base.Response.Write("This file does not exist.");
                return;
            }
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
            base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(fileInfo.FullName);
            base.Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            this.lnkexistdefault.Text = this.objlang.GetValueOnLang("Download Product Catalogue");
            this.lnkDownLoadDefault.Text = this.objlang.GetValueOnLang("Download Sample File1");
            this.lnkexistdefaultWithPriceMatrix.Text = this.objlang.GetLanguageConversion("Existing_Product_Catalogue_With_Matrix");
            this.lnkDownLoadDefaultWithPriceMatrix.Text = this.objlang.GetLanguageConversion("Example_file_with_costprice_markup");
            this.lnkexistdefaultwithpricesellingprice.Text = this.objlang.GetLanguageConversion("Existing_Product_Catalogue_With_SellingPrice");
            this.Button9.Text = this.objlang.GetLanguageConversion("Cancel");
            this.btnImport.Text = this.objlang.GetLanguageConversion("Import");
            this.btnSubmit.Text = this.objlang.GetLanguageConversion("Submit");
            this.rfv1.ErrorMessage = this.objlang.GetLanguageConversion("Please_Select_File_Name_For_Import");
            this.valRegEx.ErrorMessage = this.objlang.GetLanguageConversion("Only_Excel_File_Validation_For_Product_Catalogue_Import");
            this.lnlDownLoadDefaultPriceMatrixWithSellingPrice.Text = this.objlang.GetLanguageConversion("Example_file_with_cost_sellingprice");
            this.lnkFileConverter.Text = this.objlang.GetLanguageConversion("File_Converter");
            this.hdnisdeleteqty.Value = "0";
            this.SystemName = ConnectionClass.ServerName;
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.btnImport.Attributes.Add("onclick", "VerifyAndSave('vg1')");
            this.gloobj.setpagename("productcatalogue");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            base.Navigation_Path(string.Concat("<a href='../ProductCatalogue/PriceCatalogue.aspx' class='subnavigator'  style='text-decoration:underline;'>", this.objlang.GetLanguageConversion("Products"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objlang.GetLanguageConversion("Price_Catalogue")));
            base.Title = this.objLanguage.convert(global.pageTitle("Price Catalogue", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
            if (ConnectionClass.WebStore != null)
            {
                this.IswebStore = ConnectionClass.WebStore.ToString();
            }
            this.div_importaption.Visible = false;
            bool productFileConverter = ConnectionClass.ProductFileConverter;
            if (ConnectionClass.ProductFileConverter)
            {
                this.lnkFileConverter.Visible = true;
            }
        }
    }
}