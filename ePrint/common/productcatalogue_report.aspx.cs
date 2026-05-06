using ClosedXML.Excel;
using EPRINT;
using FileExport;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Accounts;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using Printcenter.UI.Webstores;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.common
{
    public partial class productcatalogue_report : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string pagename = string.Empty;

        public string CategoryName = string.Empty;

        private commonClass commclass = new commonClass();

        private ExportTODrive ExpTODrive = new ExportTODrive();

        private AccountsBaseClass objAcc = new AccountsBaseClass();

        private languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        private Global gloobj = new Global();

        private commonClass objJava = new commonClass();

        private int IssStockItemPosition;

        private int ActivityRecordsPosition;

        private int TempProductposition;

        private int TempAvailableQtyPosition;

        public int PageSize = 50;

        public string WebStore = string.Empty;

        public int ProductCatalogueID;

        public int CompanyID;

        public int PageNumber = 1;

        public string ISDateChecked = string.Empty;

        public string PageName = string.Empty;

        public static int TempProductID;

        public int PriceCatalogueID;

        public string SortBy = string.Empty;

        public string SortDirection = string.Empty;

        public string WhereCondition = string.Empty;

        public string Columns = string.Empty;

        public string SaveType = string.Empty;

        public string Columns1 = string.Empty;

        public string DateType = string.Empty;

        public string CompanyName = string.Empty;

        public int ReportID;

        public string FromDate = "1900-01-01 00:00:00.000";

        public string ToDate = "1900-01-01 00:00:00.000";

        public string createdDate = DateTime.Now.ToString();

        public int UserID;

        public string companyName = string.Empty;

        public string pg = string.Empty;

        public string pg_Report = string.Empty;

        public string AccountingCode = ConnectionClass.AccountingCode;

        public int cellvalue_productcatalogueID;

        public int cellvalue_ItemTitle;

        public int cellvalue_itemtitle;

        public int cellvalue_itemcode;

        public int cellvalue_categoryname;

        public int cellvalue_scorpio;

        public int cellvalue_Itemcolour;

        public int cellvalue_material;

        public int cellvalue_delivery;

        public int cellvalue_finishing;

        public int cellvalue_publicaccounts;

        public int cellvalue_proofs;

        public int cellvalue_itempacking;

        public int cellvalue_itemnotes;

        public int cellvalue_terms;

        public int cellvalue_price;

        public int cellvalue_qtyprice;

        public string Qtyoption = "no";

        public string IsPriceChecked = "no";

        public StringBuilder strColumns = new StringBuilder();

        public string NewSaveType = string.Empty;

        public string cs = string.Empty;

        public bool Check_SpecialPrivilege;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objlang = new languageClass();

        public languageClass objLangClass = new languageClass();

        public static int ManageStockPermission;

        public string Paper_Stock = string.Empty;

        public string Weight_gsm = string.Empty;

        public string Paper_Stock_Lenght = string.Empty;

        public bool IsDisplayLocation;

        public string[] ScreenValue;

        public string StockFields = string.Empty;

        public string Location_Value = string.Empty;

        public bool IsStockLocation;

        public string Querytext = string.Empty;

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

        static productcatalogue_report()
        {
        }

        public productcatalogue_report()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.div_header.Visible = true;
            if (this.pagename.ToString().ToLower().Trim() == "report")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "common/report.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/PriceCatalogue.aspx"));
        }

        public void btnExport_New_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            commonClass _commonClass = this.objJava;
            this.hdn_reportID.Value = this.ReportID.ToString();
            int num = 0;
            int num1 = 0;
            while (num1 < this.chkColumns.Items.Count)
            {
                if (!this.chkColumns.Items[num1].Selected)
                {
                    num1++;
                }
                else
                {
                    num = 1;
                    break;
                }
            }
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            this.NewSaveType = "export";
            System.Data.DataTable text = this.Run_ReportExport();
            SetFormatForDateTypeFields(text);

            for (int i = 0; i < text.Columns.Count; i++)
            {
                if (text.Columns[i].ColumnName == "CustomField2")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[63].Text;
                }
                else if (text.Columns[i].ColumnName == "CustomField3")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[64].Text;
                }
                else if (text.Columns[i].ColumnName == "CustomField4")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[65].Text;
                }
                else if (text.Columns[i].ColumnName == "CustomField5")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[66].Text;
                }
                else if (text.Columns[i].ColumnName == "CustomField6")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[67].Text;
                }
                else if (text.Columns[i].ColumnName == "TotalStockQuantity")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[30].Text;
                }
                else if (text.Columns[i].ColumnName == "AllocatedStockQuantity")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[31].Text;
                }
                else if (text.Columns[i].ColumnName == "AvailableStockQuantity")
                {
                    text.Columns[i].ColumnName = this.chkColumns.Items[32].Text;
                }
                else if (text.Columns[i].ColumnName == "Created Date")
                {
                    text.Columns[i].Caption = "Date Created";
                    text.Columns[i].ColumnName = this.chkColumns.Items[65].Text;
                }
                else if (text.Columns[i].ColumnName == "Modified Date")
                {
                    text.Columns[i].Caption = "Date Modified";
                    text.Columns[i].ColumnName = this.chkColumns.Items[66].Text;
                }
            }


            foreach (DataRow row in text.Rows)
            {
                if (row.Table.Columns.Contains("ItemTitle"))
                {
                    row["ItemTitle"] = base.SpecialDecode(row["ItemTitle"].ToString());
                }
                if (row.Table.Columns.Contains("CategoryName"))
                {
                    row["CategoryName"] = base.SpecialDecode(row["CategoryName"].ToString());
                }
                if (row.Table.Columns.Contains("ItemCode"))
                {
                    row["ItemCode"] = base.SpecialDecode(row["ItemCode"].ToString());
                }
                if (row.Table.Columns.Contains("CustomerCode"))
                {
                    row["CustomerCode"] = base.SpecialDecode(row["CustomerCode"].ToString());
                }
                if (row.Table.Columns.Contains("ProductType"))
                {
                    row["ProductType"] = base.SpecialDecode(row["ProductType"].ToString());
                }
                if (row.Table.Columns.Contains("ItemDescription"))
                {
                    row["ItemDescription"] = base.SpecialDecode(row["ItemDescription"].ToString());
                }
                if (row.Table.Columns.Contains("ItemArtWork"))
                {
                    row["ItemArtWork"] = base.SpecialDecode(row["ItemArtWork"].ToString());
                }
                if (row.Table.Columns.Contains("ItemColour"))
                {
                    row["ItemColour"] = base.SpecialDecode(row["ItemColour"].ToString());
                }
                if (row.Table.Columns.Contains("ItemSize"))
                {
                    row["ItemSize"] = base.SpecialDecode(row["ItemSize"].ToString());
                }
                if (row.Table.Columns.Contains("Material"))
                {
                    row["Material"] = base.SpecialDecode(row["Material"].ToString());
                }
                if (row.Table.Columns.Contains("Delivery"))
                {
                    row["Delivery"] = base.SpecialDecode(row["Delivery"].ToString());
                }
                if (row.Table.Columns.Contains("Finishing"))
                {
                    row["Finishing"] = base.SpecialDecode(row["Finishing"].ToString());
                }
                if (row.Table.Columns.Contains("Proofs"))
                {
                    row["Proofs"] = base.SpecialDecode(row["Proofs"].ToString());
                }
                if (row.Table.Columns.Contains("ItemPacking"))
                {
                    row["ItemPacking"] = base.SpecialDecode(row["ItemPAcking"].ToString());
                }
                if (row.Table.Columns.Contains("ItemNotes"))
                {
                    row["ItemNotes"] = base.SpecialDecode(row["ItemNotes"].ToString());
                }
                if (row.Table.Columns.Contains("Terms/Instruction"))
                {
                    row["Terms/Instruction"] = base.SpecialDecode(row["Terms/Instruction"].ToString());
                }
                if (row.Table.Columns.Contains("Created Date"))
                {
                    row["Created Date"] = _commonClass.Eprint_return_Date_Before_View(row["Created Date"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (row.Table.Columns.Contains("Modified Date"))
                {
                    row["Modified Date"] = _commonClass.Eprint_return_Date_Before_View(row["Modified Date"].ToString(), this.CompanyID, this.UserID, false);
                }

                if (!row.Table.Columns.Contains("Location"))
                {
                    continue;
                }
                row["Location"] = base.SpecialDecode(row["Location"].ToString());
            }
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            DataGrid dataGrid = new DataGrid();
            if (this.Qtyoption == "no")
            {
                text.Columns.Remove(text.Columns[0]);
                text.AcceptChanges();
                text.Columns.Remove(text.Columns[0]);
            }
            dataGrid.DataSource = text;
            htmlTextWriter.WriteLine("<div align='left' style='width:100%;padding:10px'>");
            htmlTextWriter.WriteLine("<div align='left' style='width:100%;'>");
            htmlTextWriter.WriteLine("<div style='float:left;'>");
            htmlTextWriter.WriteLine("<span style='font-family:Arial;font-size:12px;font-weight:bold;width:70px'>Date:</span>");

            DateTime now = DateTime.Now;
            htmlTextWriter.WriteLine(string.Concat("<span style='font:bold 10px  Arial;color:#82858C;'>", _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false), "</span>"));
            htmlTextWriter.WriteLine("</div>");
            htmlTextWriter.WriteLine("</div>");
            htmlTextWriter.WriteLine("<br/>");
            htmlTextWriter.WriteLine("<div align='left'>");
            htmlTextWriter.WriteLine("<span style='font-size:22px;font-weight:bold;color:#BE1333;font-family:Verdana'>ProductCatelogue List</span>");
            htmlTextWriter.WriteLine("</div>");
            htmlTextWriter.WriteLine("<div class='only10px'></div>");
            htmlTextWriter.WriteLine("<div align='left'>");
            htmlTextWriter.WriteLine(string.Concat("<span style='font-size:20px;font-weight:300;font-family:Nina'>", this.CompanyName, "</span>"));
            htmlTextWriter.WriteLine("</div>");
            htmlTextWriter.WriteLine("<div style='height:20x'>&nbsp;</div>");
            htmlTextWriter.WriteLine("</div>");
            dataGrid.Width = Unit.Percentage(100);
            dataGrid.BorderWidth = 0;
            dataGrid.GridLines = GridLines.Both;
            dataGrid.HeaderStyle.Font.Bold = true;
            dataGrid.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
            dataGrid.CellPadding = 3;
            dataGrid.ItemDataBound += new DataGridItemEventHandler(this.dgGrid_ItemDataBound);
            dataGrid.DataBind();
            text.Columns.Remove("IsStockItem");
            text.Columns.Remove("ActivityRecords");
            text.Columns.Remove("TempProduct");
            text.Columns.Remove("TempAvailableQty");
            text.AcceptChanges();
            int num2 = 0;
            for (int j = 0; j < this.chkColumns.Items.Count; j++)
            {
                if (this.chkColumns.Items[j].Selected && (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7))
                {
                    num2++;
                }
            }
            for (int k = 0; k < dataGrid.Items.Count; k++)
            {
                string str = dataGrid.Items[k].Cells[0].Text;
                for (int l = k + 1; l < dataGrid.Items.Count; l++)
                {
                    if (string.Compare(str, dataGrid.Items[l].Cells[0].Text, true) == 0)
                    {
                        for (int m = 0; m <= num2; m++)
                        {
                            if (string.Compare(dataGrid.Items[k].Cells[m].Text, dataGrid.Items[l].Cells[m].Text, true) == 0)
                            {
                                dataGrid.Items[l].Cells[m].Text = string.Empty;
                            }
                        }
                    }
                }
            }
            for (int n = 0; n < dataGrid.Items.Count; n++)
            {
                dataGrid.Items[n].Width = Unit.Percentage(20);
                dataGrid.Items[n].Style.Add("border-bottom", "solid thin silver");
                dataGrid.Items[n].Style.Add("color", "#82858C");
                dataGrid.Items[n].Style.Add("font", "bold 10px Arial");
                dataGrid.Items[n].Style.Add("height", "50px");
            }
            for (int o = 0; o < dataGrid.Items.Count; o++)
            {
                dataGrid.Items[o].Cells[this.IssStockItemPosition].Text = string.Empty;
                dataGrid.Items[o].Cells[this.ActivityRecordsPosition].Text = string.Empty;
                dataGrid.Items[o].Cells[this.TempProductposition].Text = string.Empty;
                dataGrid.Items[o].Cells[this.TempAvailableQtyPosition].Text = string.Empty;
            }
            for (int p = 0; p < dataGrid.Items.Count; p++)
            {
                dataGrid.Items[p].Cells[this.IssStockItemPosition].Text = string.Empty;
                dataGrid.Items[p].Cells[this.ActivityRecordsPosition].Text = string.Empty;
                dataGrid.Items[p].Cells[this.TempProductposition].Text = string.Empty;
                dataGrid.Items[p].Cells[this.TempAvailableQtyPosition].Text = string.Empty;
            }
            dataGrid.RenderControl(htmlTextWriter);



            DataSet ds = new DataSet();
            DataTable dtCopy1 = text.Copy();
            ds.Tables.Add(dtCopy1);
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable _dt in ds.Tables)
                {
                    wb.Worksheets.Add(_dt);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Productcatalogue Report_Excel.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }






            //string str1 = "ProductCateloguereport_Presentation.xlsx";
            ////base.Response.ContentType = "application/vnd.ms-excel";
            ////base.Response.AppendHeader("content-disposition", string.Concat("attachment;filename=\"", str1, "\""));

            //base.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //base.Response.AppendHeader("content-disposition", string.Concat("attachment;filename=\"", str1, "\""));
            //this.EnableViewState = false;
            //base.Response.Write(stringWriter.ToString());
            //base.Response.End();

        }

        private void SetFormatForDateTypeFields(System.Data.DataTable text)
        {
            commonClass _commonClass = this.objJava;
            if (text.Columns.Contains("CreateDate") && text.Columns["CreateDate"].DataType == typeof(DateTime))
            {
                text.Columns["CreateDate"].Caption = "Date Created";
                // Step 1: Create a temporary string column to store formatted values
                text.Columns.Add("CreateDate_Temp", typeof(string));

                foreach (DataRow row in text.Rows)
                {
                    if (row["CreateDate"] != DBNull.Value)
                    {
                        string formattedDate = _commonClass.Eprint_return_Date_Before_View(
                            row["CreateDate"].ToString(),
                            this.CompanyID,
                            this.UserID,
                            false);

                        row["CreateDate_Temp"] = formattedDate;
                    }
                }

                // Step 2: Remove the original DateTime column
                text.Columns.Remove("CreateDate");

                // Step 3: Rename the temporary column to 'CreateDate'
                text.Columns["CreateDate_Temp"].Caption = "Date Created";
                text.Columns["CreateDate_Temp"].ColumnName = "Date Created";
            }
            if (text.Columns.Contains("ModifiedDate") && text.Columns["ModifiedDate"].DataType == typeof(DateTime))
            {
                text.Columns["ModifiedDate"].Caption = "Date Modified";
                // Step 1: Create a temporary string column to store formatted values
                text.Columns.Add("ModifiedDate_Temp", typeof(string));

                foreach (DataRow row in text.Rows)
                {
                    if (row["ModifiedDate"] != DBNull.Value)
                    {
                        string formattedDate = _commonClass.Eprint_return_Date_Before_View(
                            row["ModifiedDate"].ToString(),
                            this.CompanyID,
                            this.UserID,
                            false);

                        row["ModifiedDate_Temp"] = formattedDate;
                    }
                }

                // Step 2: Remove the original DateTime column
                text.Columns.Remove("ModifiedDate");

                // Step 3: Rename the temporary column to 'CreateDate'
                text.Columns["ModifiedDate_Temp"].Caption = "Date Modified";
                text.Columns["ModifiedDate_Temp"].ColumnName = "Date Modified";
            }

        }

        public void btnExport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            int num = 0;
            int num1 = 0;
            while (num1 < this.chkColumns.Items.Count)
            {
                if (!this.chkColumns.Items[num1].Selected)
                {
                    num1++;
                }
                else
                {
                    num = 1;
                    break;
                }
            }
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            this.NewSaveType = "export";
            DataTable dataTable = new DataTable();
            if (this.Session["Export_dt_export_toexcel"] == null)
            {
                dataTable = this.Run_ReportExport();
            }
            else
            {
                this.Qtyoption = "yes";
                dataTable = this.Session["Export_dt_export_toexcel"] as DataTable;
            }
            SetFormatForDateTypeFields(dataTable);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (dataTable.Columns[i].ColumnName == "ItemTitle")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[0].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CategoryName")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[1].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemCode")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[2].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomerCode")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[3].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "IsEditableProduct")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[4].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Ownership")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[5].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Allocation")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[6].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "publicAccount")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[7].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemDescription")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[8].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemArtwork")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[9].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemColour")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[10].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemSize")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[11].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Material")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[12].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Delivery")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[13].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Finishing")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[14].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Proofs")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[15].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemPacking")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[16].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ItemNotes")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[17].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Terms/Instructions")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[18].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "MatrixType")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[19].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "fromquantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[20].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "toquantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[21].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "price")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[22].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "MarkUpPercentage")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[23].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "MarkUpValue")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[24].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "SellingPrice")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[25].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Weight")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[26].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Width")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[27].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Height")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[28].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "Length")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[29].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "QtyInHand")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[30].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "AllocatedQty")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[31].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "AvailableQty")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[32].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ReOrderQuantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[33].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "ReorderAlertLevel")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[34].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "QtySoldWeekToDate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[35].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "QtySoldMonthToDate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[36].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "qtysoldquartertodate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[37].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "QtySoldYearToDate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[38].Text;
                }

                // Ticket #5202 Added new checkbox column "QTY financial year sold to date"  
                else if (dataTable.Columns[i].ColumnName == "QtySoldFinancialYearToDate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[39].Text;
                }

                else if (dataTable.Columns[i].ColumnName == "QtySoldTillDate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[40].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "DrawStockFrom")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[41].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "SalesTaxRate")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[42].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "datelastreplenished")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[43].Text;
                }



                //// Ticket #11148 add columns for custom fields 1 through 5 
                //else if (dataTable.Columns[i].ColumnName == "CustomDescription1")
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[44].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomDescription2")
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[45].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomDescription3")
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[46].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomDescription4")
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[47].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomDescription5")
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[48].Text;
                //}
                else if (dataTable.Columns[i].ColumnName == "OutworkProductionQty")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[44].Text;//49
                }
                else if (dataTable.Columns[i].ColumnName == "StockCost")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[45].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "SupplierName")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[46].Text;
                }
                //else if (dataTable.Columns[i].ColumnName == "CustomField2" && this.chkColumns.Items.Count > 47)
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[47].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomField3" && this.chkColumns.Items.Count > 48)
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[48].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomField4" && this.chkColumns.Items.Count > 49)
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[49].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomField5" && this.chkColumns.Items.Count > 50)
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[50].Text;
                //}
                //else if (dataTable.Columns[i].ColumnName == "CustomField6" && this.chkColumns.Items.Count > 51)
                //{
                //    dataTable.Columns[i].ColumnName = this.chkColumns.Items[51].Text;
                //}
                else if (dataTable.Columns[i].ColumnName == "QtyAddedWeekToDate" && this.chkColumns.Items.Count > 47)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[47].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "qtyaddedmonthtodate" && this.chkColumns.Items.Count > 48) //QtyAddMonthToDate
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[48].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "qtyaddedquartertodate" && this.chkColumns.Items.Count > 49)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[49].Text;
                }

                else if (dataTable.Columns[i].ColumnName == "QtyAddedYearToDate" && this.chkColumns.Items.Count > 50)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[50].Text;
                }

                else if (dataTable.Columns[i].ColumnName == "QtyAddedFinancialYearToDate" && this.chkColumns.Items.Count > 51)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[51].Text;
                }

                else if (dataTable.Columns[i].ColumnName == "QtyAddedTillDate" && this.chkColumns.Items.Count > 52)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[52].Text;
                }



                // Ticket #11148 add columns for custom fields 1 through 5 
                else if (dataTable.Columns[i].ColumnName == "CustomDescription1" && this.chkColumns.Items.Count > 53)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[53].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription2" && this.chkColumns.Items.Count > 54)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[54].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription3" && this.chkColumns.Items.Count > 55)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[55].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription4" && this.chkColumns.Items.Count > 56)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[56].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription5" && this.chkColumns.Items.Count > 57)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[57].Text;
                }



                else if (dataTable.Columns[i].ColumnName == "CustomDescription6" && this.chkColumns.Items.Count > 58)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[58].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription7" && this.chkColumns.Items.Count > 59)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[59].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription8" && this.chkColumns.Items.Count > 60)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[60].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription9" && this.chkColumns.Items.Count > 61)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[61].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomDescription10" && this.chkColumns.Items.Count > 62)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[62].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "LocationQty" && this.chkColumns.Items.Count > 63)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[63].Text;
                }


                else if (dataTable.Columns[i].ColumnName == "CustomField2" && this.chkColumns.Items.Count > 64)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[64].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomField3" && this.chkColumns.Items.Count > 65)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[65].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomField4" && this.chkColumns.Items.Count > 66)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[66].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomField5" && this.chkColumns.Items.Count > 67)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[67].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "CustomField6" && this.chkColumns.Items.Count > 68)
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[68].Text;
                }




                else if (dataTable.Columns[i].ColumnName == "TotalStockQuantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[30].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "AllocatedStockQuantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[31].Text;
                }
                else if (dataTable.Columns[i].ColumnName == "AvailableStockQuantity")
                {
                    dataTable.Columns[i].ColumnName = this.chkColumns.Items[32].Text;
                }
                if (this.chkaggregate.SelectedIndex != -1)
                {
                    if (this.chkaggregate.Items[0].Selected && dataTable.Columns[i].ColumnName == "OpeningStock")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[0].Text;
                    }
                    if (this.chkaggregate.Items[1].Selected && dataTable.Columns[i].ColumnName == "Location")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[1].Text;
                    }
                    if (this.chkaggregate.Items[2].Selected && dataTable.Columns[i].ColumnName == "QtyAdded")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[2].Text;
                    }
                    if (this.chkaggregate.Items[3].Selected && dataTable.Columns[i].ColumnName == "QtySold")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[3].Text;
                    }
                    if (this.chkaggregate.Items[4].Selected && dataTable.Columns[i].ColumnName == "QtyAdjusted(+)")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[4].Text;
                    }
                    if (this.chkaggregate.Items[5].Selected && dataTable.Columns[i].ColumnName == "QtyAdjusted(-)")
                    {
                        dataTable.Columns[i].ColumnName = this.chkaggregate.Items[5].Text;
                    }
                }
                if (this.chkDrawStock.Checked)
                {
                    if (dataTable.Columns[i].ColumnName == "AdditionalOptionName")
                    {
                        dataTable.Columns[i].ColumnName = "Additional OptionName";
                    }
                    if (dataTable.Columns[i].ColumnName == "AdditionalOptionValue")
                    {
                        dataTable.Columns[i].ColumnName = "Additional OptionValue";
                    }
                    if (this.chkColumns.Items[26].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionQtyInHand")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option QtyInHand";
                    }
                    if (this.chkColumns.Items[27].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionAllocatedStock")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option AllocatedStock";
                    }
                    if (this.chkColumns.Items[28].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionAvailableStock")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option AvailableStock";
                    }
                    if (this.chkaggregate.Items[0].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionOpeningStock")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option OpeningStock";
                    }
                    if (this.chkaggregate.Items[2].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionQtyAdded")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option QtyAdded";
                    }
                    if (this.chkaggregate.Items[3].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionQtySold")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option QtySold";
                    }
                    if (this.chkaggregate.Items[4].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionQuantityIncreament")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option  Manual Adjustment +";
                    }
                    if (this.chkaggregate.Items[5].Selected && dataTable.Columns[i].ColumnName == "AdditionalOptionQuantityDecreament")
                    {
                        dataTable.Columns[i].ColumnName = "Additional Option  Manual Adjustment -";
                    }
                }
                if (dataTable.Columns[i].ColumnName == "IsStockItem")
                {
                    dataTable.Columns.RemoveAt(i);
                }
                if (dataTable.Columns[i].ColumnName == "ActivityRecords")
                {
                    dataTable.Columns.RemoveAt(i);
                }
                if (dataTable.Columns[i].ColumnName == "TempProduct")
                {
                    dataTable.Columns.RemoveAt(i);
                }
                if (dataTable.Columns[i].ColumnName == "TempAvailableQty")
                {
                    dataTable.Columns.RemoveAt(i);
                }
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Table.Columns.Contains(this.chkColumns.Items[0].Text))
                {
                    row[this.chkColumns.Items[0].Text] = base.SpecialDecode(row[this.chkColumns.Items[0].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains("Category Name"))
                {
                    row["Category Name"] = base.SpecialDecode(row["Category Name"].ToString());
                }
                if (row.Table.Columns.Contains("Item Code"))
                {
                    row["Item Code"] = base.SpecialDecode(row["Item Code"].ToString());
                }
                if (row.Table.Columns.Contains("Customer Code"))
                {
                    row["Customer Code"] = base.SpecialDecode(row["Customer Code"].ToString());
                }
                if (row.Table.Columns.Contains("Product Type"))
                {
                    row["Product Type"] = base.SpecialDecode(row["Product Type"].ToString());
                }
                if (row.Table.Columns.Contains("Location"))
                {
                    row["Location"] = base.SpecialDecode(row["Location"].ToString());
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[8].Text))
                {
                    row[this.chkColumns.Items[8].Text] = base.SpecialDecode(row[this.chkColumns.Items[8].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[9].Text))
                {
                    row[this.chkColumns.Items[9].Text] = base.SpecialDecode(row[this.chkColumns.Items[9].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[10].Text))
                {
                    row[this.chkColumns.Items[10].Text] = base.SpecialDecode(row[this.chkColumns.Items[10].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[11].Text))
                {
                    row[this.chkColumns.Items[11].Text] = base.SpecialDecode(row[this.chkColumns.Items[11].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[12].Text))
                {
                    row[this.chkColumns.Items[12].Text] = base.SpecialDecode(row[this.chkColumns.Items[12].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[13].Text))
                {
                    row[this.chkColumns.Items[13].Text] = base.SpecialDecode(row[this.chkColumns.Items[13].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[14].Text))
                {
                    row[this.chkColumns.Items[14].Text] = base.SpecialDecode(row[this.chkColumns.Items[14].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[15].Text))
                {
                    row[this.chkColumns.Items[15].Text] = base.SpecialDecode(row[this.chkColumns.Items[15].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[16].Text))
                {
                    row[this.chkColumns.Items[16].Text] = base.SpecialDecode(row[this.chkColumns.Items[16].Text].ToString().Replace("\r\n", " "));
                }
                if (row.Table.Columns.Contains(this.chkColumns.Items[17].Text))
                {
                    row[this.chkColumns.Items[17].Text] = base.SpecialDecode(row[this.chkColumns.Items[17].Text].ToString().Replace("\r\n", " "));
                }
                if (!row.Table.Columns.Contains(this.chkColumns.Items[18].Text))
                {
                    continue;
                }
                row[this.chkColumns.Items[18].Text] = base.SpecialDecode(row[this.chkColumns.Items[18].Text].ToString().Replace("\r\n", " "));
            }
            dataTable.AcceptChanges();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            WebExport webExport = new WebExport();
            if (this.Qtyoption == "no")
            {
                dataTable.Columns.Remove(dataTable.Columns[0]);
                dataTable.AcceptChanges();
                dataTable.Columns.Remove(dataTable.Columns[0]);
            }
            DataSet ds = new DataSet();
            DataTable dtCopy1 = dataTable.Copy();
            ds.Tables.Add(dtCopy1);
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable _dt in ds.Tables)
                {
                    wb.Worksheets.Add(_dt);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Productcatalogue Report_Excel.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            //webExport.Export_with_XSLT_Web(dataTable, "Productcatalogue Report_Excel.xls");
        }

        protected void btnfilter_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.div_header.Visible = true;
            this.divtab.Visible = true;
            this.div_option.Style.Add("display", "block");
            this.divexport.Style.Add("display", "none");
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.hdn_reportID.Value = this.ReportID.ToString();
        }

        public void btnRunReport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.NewSaveType = "view";
            this.div_option.Style.Add("display", "none");
            this.divexport.Style.Add("display", "block");
            this.Run_Report();
            this.GridProduct.Rebind();
        }

        protected void btnsavemultiple_onclick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdn_Customers.Value.Split(new char[] { ',' });
            string[] strArrays1 = this.hdn_ReportIDs.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                string empty = string.Empty;
                int num = 0;
                if (strArrays1[i] != "")
                {
                    string str = strArrays1[i];
                    char[] chrArray = new char[] { '\u005F' };
                    if (Convert.ToInt64(str.Split(chrArray)[0]) != (long)0)
                    {
                        string str1 = strArrays1[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        num = Convert.ToInt32(str1.Split(chrArray1)[0]);
                        empty = "C";
                    }
                    else
                    {
                        string str2 = strArrays1[i];
                        char[] chrArray2 = new char[] { '\u005F' };
                        num = Convert.ToInt32(str2.Split(chrArray2)[0]);
                        string str3 = strArrays1[i];
                        char[] chrArray3 = new char[] { '\u005F' };
                        empty = str3.Split(chrArray3)[1].ToString();
                    }
                    for (int j = 0; j < (int)strArrays.Length; j++)
                    {
                        if (strArrays[j] != "")
                        {
                            WebstoreBasePage.EstoreReports_AllocatedCustomers_Insert((long)num, Convert.ToInt64(strArrays[j]), "product", empty);
                        }
                    }
                }
            }
            this.Session["AllocatedCust_0"] = null;
            base.Response.Redirect(string.Concat(this.strSitepath, "common/Productcatalogue_report.aspx"));
        }

        public void btnSaveRun_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.NewSaveType = "save";
            this.Run_Report();
            this.div_option.Style.Add("display", "none");
            this.divexport.Style.Add("display", "block");
            this.btnUpdateExisting.Visible = true;
            this.GridProduct.Rebind();
            this.ReportID = Convert.ToInt32(this.hdn_reportID.Value);
        }

        public void btnUpdateExisting_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.ReportID = Convert.ToInt32(this.hdn_reportID.Value);
            this.ReportID = Convert.ToInt32(this.hdn_reportID2.Value);
            this.NewSaveType = "Update";
            this.div_option.Style.Add("display", "none");
            this.divexport.Style.Add("display", "block");
            this.Run_Report();
            this.GridProduct.Rebind();
        }

        private void dgGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    if (e.Item.Cells[i].Text.ToLower() == "itemcode")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("Item_Code");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "categoryname")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("Category_Name");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemtitle")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[0].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "customercode")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("p_Customer_Code");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "iseditableproduct")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("Product_Type");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "ownership")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("OwnerShip");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "allocation")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("Allocation");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "publicaccount")
                    {
                        e.Item.Cells[i].Text = this.objlang.GetLanguageConversion("Public_Accounts");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemdescription")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[8].Text;
                        e.Item.Cells[i].Attributes.Add("width", "100px");
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemartwork")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[9].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemcolour")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[10].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemsize")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[11].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "material")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[12].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "delivery")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[13].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "finishing")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[14].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "proofs")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[15].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itempacking")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[16].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "itemnotes")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[17].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "terms/instructions")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[18].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "matrixtype")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[19].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "fromquantity")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[20].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "toquantity")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[21].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "price")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[22].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "markuppercentage")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[23].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "markupvalue")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[24].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "sellingprice")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[25].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "weight")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[26].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "width")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[27].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "height")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[28].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "length")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[29].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtyinhand")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[30].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "allocatedqty")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[31].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "availableqty")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[32].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "reorderquantity")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[33].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "ReorderAlertLevel")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[34].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "QtySoldWeekToDate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[35].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtysoldmonthtodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[36].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtysoldquartertodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[37].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtysoldyeartodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[38].Text;
                    }

                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    else if (e.Item.Cells[i].Text.ToLower() == "QtySoldFinancialYearToDate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[39].Text;
                    }

                    else if (e.Item.Cells[i].Text.ToLower() == "qtysoldtilldate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[40].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "drawstockfrom")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[41].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "salestaxrate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[42].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "datelastreplenished")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[43].Text;
                    }

                    //else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription1")
                    //{
                    //    e.Item.Cells[i].Text = this.chkColumns.Items[44].Text;
                    //}
                    //else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription2")
                    //{
                    //    e.Item.Cells[i].Text = this.chkColumns.Items[45].Text;
                    //}
                    //else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription3")
                    //{
                    //    e.Item.Cells[i].Text = this.chkColumns.Items[46].Text;
                    //}
                    //else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription4")
                    //{
                    //    e.Item.Cells[i].Text = this.chkColumns.Items[47].Text;
                    //}
                    //else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription5")
                    //{
                    //    e.Item.Cells[i].Text = this.chkColumns.Items[48].Text;
                    //}
                    else if (e.Item.Cells[i].Text.ToLower() == "OutworkProductionQty")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[44].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "stockcost")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[45].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "suppliername")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[46].Text;
                    }


                    else if (e.Item.Cells[i].Text.ToLower() == "qtyaddedweektodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[47].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtyaddedmonthtodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[48].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtyaddedquartertodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[49].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "qtyaddedyeartodate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[50].Text;
                    }

                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    else if (e.Item.Cells[i].Text.ToLower() == "QtyaddedFinancialYearToDate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[51].Text;
                    }

                    else if (e.Item.Cells[i].Text.ToLower() == "qtyaddedtilldate")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[52].Text;
                    }


                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription1")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[53].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription2")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[54].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription3")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[55].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription4")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[56].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription5")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[57].Text;
                    }




                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription6")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[58].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription7")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[59].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription8")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[60].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription9")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[61].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "CustomDescription10")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[62].Text;
                    }
                    else if (e.Item.Cells[i].Text.ToLower() == "LocationQty")
                    {
                        e.Item.Cells[i].Text = this.chkColumns.Items[63].Text;
                    }




                    else if (e.Item.Cells[i].Text.ToString() == "IsStockItem")
                    {
                        e.Item.Cells[i].Visible = false;
                        this.IssStockItemPosition = i;
                    }
                    else if (e.Item.Cells[i].Text.ToString() == "ActivityRecords")
                    {
                        e.Item.Cells[i].Visible = false;
                        this.ActivityRecordsPosition = i;
                    }
                    else if (e.Item.Cells[i].Text.ToString() == "TempProduct")
                    {
                        e.Item.Cells[i].Visible = false;
                        this.TempProductposition = i;
                    }
                    else if (e.Item.Cells[i].Text.ToString() == "TempAvailableQty")
                    {
                        e.Item.Cells[i].Visible = false;
                        this.TempAvailableQtyPosition = i;
                    }

                    if (this.chkaggregate.SelectedIndex != -1)
                    {
                        if (this.chkaggregate.Items[0].Selected && e.Item.Cells[i].Text.ToString() == "OpeningStock")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[0].Text;
                        }
                        if (this.chkaggregate.Items[1].Selected && e.Item.Cells[i].Text.ToString() == "Location")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[1].Text;
                        }
                        if (this.chkaggregate.Items[2].Selected && e.Item.Cells[i].Text.ToString() == "QtyAdded")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[2].Text;
                        }
                        if (this.chkaggregate.Items[3].Selected && e.Item.Cells[i].Text.ToString() == "QtySold")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[3].Text;
                        }
                        if (this.chkaggregate.Items[4].Selected && e.Item.Cells[i].Text.ToString() == "QtyAdjusted(+)")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[4].Text;
                        }
                        if (this.chkaggregate.Items[5].Selected && e.Item.Cells[i].Text.ToString() == "QtyAdjusted(-)")
                        {
                            e.Item.Cells[i].Text = this.chkaggregate.Items[5].Text;
                        }
                    }
                    if (this.chkDrawStock.Checked)
                    {
                        if (e.Item.Cells[i].Text.ToString() == "AdditionalOptionName")
                        {
                            e.Item.Cells[i].Text = "Additional OptionName";
                        }
                        if (e.Item.Cells[i].Text.ToString() == "AdditionalOptionValue")
                        {
                            e.Item.Cells[i].Text = "Additional OptionValue";
                        }
                        if (this.chkColumns.Items[30].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionQtyInHand")
                        {
                            e.Item.Cells[i].Text = "Additional Option QtyInHand";
                        }
                        if (this.chkColumns.Items[31].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionAllocatedStock")
                        {
                            e.Item.Cells[i].Text = "Additional Option AllocatedStock";
                        }
                        if (this.chkColumns.Items[32].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionAvailableStock")
                        {
                            e.Item.Cells[i].Text = "Additional Option AvailableStock";
                        }
                        if (this.chkaggregate.Items[0].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionOpeningStock")
                        {
                            e.Item.Cells[i].Text = "Additional Option OpeningStock";
                        }
                        if (this.chkaggregate.Items[2].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionQtyAdded")
                        {
                            e.Item.Cells[i].Text = "Additional Option QtyAdded";
                        }
                        if (this.chkaggregate.Items[3].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionQtySold")
                        {
                            e.Item.Cells[i].Text = "Additional Option QtySold";
                        }
                        if (this.chkaggregate.Items[4].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionQuantityIncreament")
                        {
                            e.Item.Cells[i].Text = "Additional Option Manual Adjustment +";
                        }
                        if (this.chkaggregate.Items[5].Selected && e.Item.Cells[i].Text.ToString() == "AdditionalOptionQuantityDecreament")
                        {
                            e.Item.Cells[i].Text = "Additional Option  Manual Adjustment - ";
                        }
                    }
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int j = 0; j < e.Item.Controls.Count; j++)
                {
                    e.Item.Cells[j].Width = Unit.Percentage(20);
                    e.Item.Cells[j].Attributes.Add("align", "left");
                    e.Item.Cells[j].Style.Add("border-bottom", "solid thin silver");
                    e.Item.Cells[j].Style.Add("color", "#000000");
                    e.Item.Cells[j].Style.Add("font", "10px Arial");
                    e.Item.Cells[j].Style.Add("height", "50px");
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    if (dataItem.Row["TempProduct"].ToString() == "NonEditable" && dataItem.Row["TempAvailableQty"].ToString() == "0" && dataItem.Row["IsStockItem"].ToString() == "1")
                    {
                        e.Item.Cells[j].BackColor = ColorTranslator.FromHtml("#EE7E7B");
                    }
                    if (dataItem.Row["TempProduct"].ToString() == "NonEditable" && dataItem.Row["TempAvailableQty"].ToString().Contains("-") && dataItem.Row["IsStockItem"].ToString() == "1")
                    {
                        e.Item.Cells[j].BackColor = ColorTranslator.FromHtml("#FF84FF");
                    }
                    if (dataItem.Row["TempProduct"].ToString() == "NonEditable" && dataItem.Row["IsStockItem"].ToString() == "1" && dataItem.Row["ActivityRecords"].ToString() == "0")
                    {
                        e.Item.Cells[j].BackColor = ColorTranslator.FromHtml("#BFBFFF");
                    }
                }
            }
        }

        public void GetCategorychkListView()
        {
            DataTable dataTable = Settings.PriceCatalogue_Category_Select(this.CompanyID);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["PriceCatalogueCategoryName"] = base.SpecialDecode(row["PriceCatalogueCategoryName"].ToString());
            }
            CheckBoxList checkBoxList = (CheckBoxList)this.ddlCategory.Items[0].FindControl("chkEstType");
            checkBoxList.DataSource = dataTable;
            checkBoxList.DataTextField = "PriceCatalogueCategoryName";
            checkBoxList.DataValueField = "PriceCatalogueCategoryID";
            checkBoxList.DataBind();
        }

        private void getColumnNameFromSettings()
        {
            DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(this.CompanyID, "c");
            if (dataSet.Tables[0].Rows[0]["databaseFieldName"].ToString() == "ItemTitle")
            {
                this.chkColumns.Items[0].Text = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[1]["databaseFieldName"].ToString() == "Description")
            {
                this.chkColumns.Items[8].Text = dataSet.Tables[0].Rows[1]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[2]["databaseFieldName"].ToString() == "Artwork")
            {
                this.chkColumns.Items[9].Text = dataSet.Tables[0].Rows[2]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[3]["databaseFieldName"].ToString() == "Colour")
            {
                this.chkColumns.Items[10].Text = dataSet.Tables[0].Rows[3]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[4]["databaseFieldName"].ToString() == "Size")
            {
                this.chkColumns.Items[11].Text = dataSet.Tables[0].Rows[4]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[5]["databaseFieldName"].ToString() == "Material")
            {
                this.chkColumns.Items[12].Text = dataSet.Tables[0].Rows[5]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[6]["databaseFieldName"].ToString() == "Delivery")
            {
                this.chkColumns.Items[13].Text = dataSet.Tables[0].Rows[6]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[7]["databaseFieldName"].ToString() == "Finishing")
            {
                this.chkColumns.Items[14].Text = dataSet.Tables[0].Rows[7]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[8]["databaseFieldName"].ToString() == "Proofs")
            {
                this.chkColumns.Items[15].Text = dataSet.Tables[0].Rows[8]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[9]["databaseFieldName"].ToString() == "Packing")
            {
                this.chkColumns.Items[16].Text = dataSet.Tables[0].Rows[9]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[10]["databaseFieldName"].ToString() == "Notes")
            {
                this.chkColumns.Items[17].Text = dataSet.Tables[0].Rows[10]["ScreenName"].ToString();
            }
            if (dataSet.Tables[0].Rows[11]["databaseFieldName"].ToString() == "Instructions")
            {
                this.chkColumns.Items[18].Text = dataSet.Tables[0].Rows[11]["ScreenName"].ToString();
            }
        }

        public DataTable GetListItem()
        {
            DataTable dataTable = new DataTable();
            return Settings.PriceCatalogue_Category_Select(this.CompanyID);
        }

        protected void GridProduct_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (base.IsPostBack)
            {
                if (e.Item is GridHeaderItem)
                {
                    GridHeaderItem item = (GridHeaderItem)e.Item;
                    item["ItemTitle"].Text = this.chkColumns.Items[0].Text;
                    //if (this.chkColumns.Items[0].Selected)
                    //{
                    //    item["ItemTitle"].Text = this.chkColumns.Items[0].Text;
                    //}


                    if (this.chkColumns.Items[1].Selected)
                    {
                        item["categoryname"].Text = this.objlang.GetLanguageConversion("Category_Name");
                    }
                    if (this.chkColumns.Items[2].Selected)
                    {
                        item["ItemCode"].Text = this.objlang.GetLanguageConversion("Item_Code");
                    }
                    if (this.chkColumns.Items[3].Selected)
                    {
                        item["customercode"].Text = this.objlang.GetLanguageConversion("p_Customer_Code");
                    }
                    if (this.chkColumns.Items[4].Selected)
                    {
                        item["iseditableproduct"].Text = this.objlang.GetLanguageConversion("Product_Type");
                    }
                    if (this.chkColumns.Items[5].Selected)
                    {
                        item["ownership"].Text = this.objlang.GetLanguageConversion("Ownership");
                    }
                    if (this.chkColumns.Items[6].Selected)
                    {
                        item["allocation"].Text = this.objlang.GetLanguageConversion("Allocation");
                    }
                    if (this.chkColumns.Items[7].Selected)
                    {
                        item["publicaccount"].Text = this.objlang.GetLanguageConversion("Public_Accounts");
                    }
                    if (this.chkColumns.Items[8].Selected)
                    {
                        item["itemdescription"].Text = this.chkColumns.Items[8].Text;
                    }
                    if (this.chkColumns.Items[9].Selected)
                    {
                        item["itemartwork"].Text = this.chkColumns.Items[9].Text;
                    }
                    if (this.chkColumns.Items[10].Selected)
                    {
                        item["Itemcolour"].Text = this.chkColumns.Items[10].Text;
                    }
                    if (this.chkColumns.Items[11].Selected)
                    {
                        item["itemsize"].Text = this.chkColumns.Items[11].Text;
                    }
                    if (this.chkColumns.Items[12].Selected)
                    {
                        item["material"].Text = this.chkColumns.Items[12].Text;
                    }
                    if (this.chkColumns.Items[13].Selected)
                    {
                        item["delivery"].Text = this.chkColumns.Items[13].Text;
                    }
                    if (this.chkColumns.Items[14].Selected)
                    {
                        item["finishing"].Text = this.chkColumns.Items[14].Text;
                    }
                    if (this.chkColumns.Items[15].Selected)
                    {
                        item["proofs"].Text = this.chkColumns.Items[15].Text;
                    }
                    if (this.chkColumns.Items[16].Selected)
                    {
                        item["itempacking"].Text = this.chkColumns.Items[16].Text;
                    }
                    if (this.chkColumns.Items[17].Selected)
                    {
                        item["itemnotes"].Text = this.chkColumns.Items[17].Text;
                    }
                    if (this.chkColumns.Items[18].Selected)
                    {
                        item["terms/instructions"].Text = this.chkColumns.Items[18].Text;
                    }
                    if (this.chkColumns.Items[19].Selected)
                    {
                        item["matrixtype"].Text = "Pricing Type";
                    }
                    if (this.chkColumns.Items[20].Selected)
                    {
                        item["fromquantity"].Text = this.chkColumns.Items[20].Text;
                        item["fromquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[21].Selected)
                    {
                        item["toquantity"].Text = this.chkColumns.Items[21].Text;
                        item["toquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[22].Selected)
                    {
                        item["price"].Text = this.chkColumns.Items[22].Text;
                        item["price"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[23].Selected)
                    {
                        item["markuppercentage"].Text = string.Concat(this.objlang.GetLanguageConversion("Mark"), " (%)");
                        item["markuppercentage"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[24].Selected)
                    {
                        item["markupvalue"].Text = this.objlang.GetLanguageConversion("Mark_Value");
                        item["markupvalue"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[25].Selected)
                    {
                        item["sellingprice"].Text = this.objlang.GetLanguageConversion("Selling_Price");
                        item["sellingprice"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[26].Selected)
                    {
                        item["Weight"].Text = string.Concat(this.objlang.GetLanguageConversion("Weight"), " (", this.Weight_gsm, ")");
                        item["Weight"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[27].Selected)
                    {
                        item["Width"].Text = string.Concat(this.objlang.GetLanguageConversion("Width"), " (", this.Paper_Stock, ")");
                        item["Width"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[28].Selected)
                    {
                        item["Height"].Text = string.Concat(this.objlang.GetLanguageConversion("Height"), " (", this.Paper_Stock, ")");
                        item["Height"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[29].Selected)
                    {
                        item["Length"].Text = string.Concat(this.objlang.GetLanguageConversion("Length"), " (", this.Paper_Stock_Lenght, ")");
                        item["Length"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[30].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item["TotalStockQuantity"].Text = this.objlang.GetLanguageConversion("Qty_On_Hand");
                            item["TotalStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item["qtyinhand"].Text = this.objlang.GetLanguageConversion("Qty_On_Hand");
                            item["qtyinhand"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[31].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item["AllocatedStockQuantity"].Text = this.objlang.GetLanguageConversion("Allocated_Qty");
                            item["AllocatedStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item["allocatedqty"].Text = this.objlang.GetLanguageConversion("Allocated_Qty");
                            item["allocatedqty"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[32].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item["AvailableStockQuantity"].Text = this.objlang.GetLanguageConversion("Available_Qty");
                            item["AvailableStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item["availableqty"].Text = this.objlang.GetLanguageConversion("Available_Qty");
                            item["availableqty"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[33].Selected)
                    {
                        item["reorderquantity"].Text = this.objlang.GetLanguageConversion("ReOrder_Qty");
                        item["reorderquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[34].Selected)
                    {
                        item["reorderalertlevel"].Text = this.objlang.GetLanguageConversion("ReOrder_Alert_Level");
                        item["reorderalertlevel"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[35].Selected)
                    {
                        item["Qtysoldweektodate"].Text = this.objlang.GetLanguageConversion("Quantity_WTD");
                        item["Qtysoldweektodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[36].Selected)
                    {
                        item["qtysoldmonthtodate"].Text = this.objlang.GetLanguageConversion("Quantity_MTD");
                        item["qtysoldmonthtodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[37].Selected)
                    {
                        item["qtysoldquartertodate"].Text = this.objlang.GetLanguageConversion("Quantity_QTD");
                        item["qtysoldquartertodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[38].Selected)
                    {
                        item["qtysoldyeartodate"].Text = this.objlang.GetLanguageConversion("Quantity_YTD");
                        item["qtysoldyeartodate"].HorizontalAlign = HorizontalAlign.Right;
                    }

                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    if (this.chkColumns.Items[39].Selected)
                    {
                        item["QtySoldFinancialYearToDate"].Text = this.objlang.GetLanguageConversion("Quantity_FYTD");
                        item["QtySoldFinancialYearToDate"].HorizontalAlign = HorizontalAlign.Right;
                    }

                    if (this.chkColumns.Items[40].Selected)
                    {
                        item["qtysoldtilldate"].Text = this.objlang.GetLanguageConversion("Quantity_TD");
                        item["qtysoldtilldate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[41].Selected)
                    {
                        item["drawstockfrom"].Text = this.objlang.GetLanguageConversion("Draw_Stock_From");
                    }
                    if (this.chkColumns.Items[42].Selected)
                    {
                        item["SalesTaxRate"].Text = this.objlang.GetLanguageConversion("Sales_Tax_Rate");
                        item["SalesTaxRate"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[43].Selected)
                    {
                        item["DateLastReplenished"].Text = this.objlang.GetLanguageConversion("Date_Last_Replenished");
                        item["DateLastReplenished"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    //// Ticket #11148 add columns for custom fields 1 through 5 
                    //if (this.chkColumns.Items[44].Selected)
                    //{
                    //    item["CustomDescription1"].Text = this.objlang.GetLanguageConversion("Custom_Description1");
                    //    item["CustomDescription1"].HorizontalAlign = HorizontalAlign.Left;
                    //}
                    //if (this.chkColumns.Items[45].Selected)
                    //{
                    //    item["CustomDescription2"].Text = this.objlang.GetLanguageConversion("Custom_Description2");
                    //    item["CustomDescription2"].HorizontalAlign = HorizontalAlign.Left;
                    //}
                    //if (this.chkColumns.Items[46].Selected)
                    //{
                    //    item["CustomDescription3"].Text = this.objlang.GetLanguageConversion("Custom_Description3");
                    //    item["CustomDescription3"].HorizontalAlign = HorizontalAlign.Left;
                    //}
                    //if (this.chkColumns.Items[47].Selected)
                    //{
                    //    item["CustomDescription4"].Text = this.objlang.GetLanguageConversion("Custom_Description4");
                    //    item["CustomDescription4"].HorizontalAlign = HorizontalAlign.Left;
                    //}
                    //if (this.chkColumns.Items[48].Selected)
                    //{
                    //    item["CustomDescription5"].Text = this.objlang.GetLanguageConversion("Custom_Description5");
                    //    item["CustomDescription5"].HorizontalAlign = HorizontalAlign.Left;
                    //}
                    if (this.chkColumns.Items[44].Selected)
                    {
                        item["OutworkProductionQty"].Text = this.objlang.GetLanguageConversion("Outwork_Production_Qty");
                        item["OutworkProductionQty"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[45].Selected)
                    {
                        item["StockCost"].Text = this.objlang.GetLanguageConversion("Stock_Cost");
                        item["StockCost"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[46].Selected)
                    {
                        item["SupplierName"].Text = this.objlang.GetLanguageConversion("Supplier_Name");
                        item["SupplierName"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    //if (this.chkColumns.Items.Count > 47 && this.chkColumns.Items[47].Selected && this.chkColumns.Items[47].Value == "CustomField2")
                    //{
                    //    item["CustomField2"].Text = this.chkColumns.Items[47].Text;
                    //    item["CustomField2"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items.Count > 48 && this.chkColumns.Items[48].Selected && this.chkColumns.Items[48].Value == "CustomField3")
                    //{
                    //    item["CustomField3"].Text = this.chkColumns.Items[48].Text;
                    //    item["CustomField3"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items.Count > 49 && this.chkColumns.Items[49].Selected && this.chkColumns.Items[49].Value == "CustomField4")
                    //{
                    //    item["CustomField4"].Text = this.chkColumns.Items[49].Text;
                    //    item["CustomField4"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items.Count > 50 && this.chkColumns.Items[50].Selected && this.chkColumns.Items[50].Value == "CustomField5")
                    //{
                    //    item["CustomField5"].Text = this.chkColumns.Items[50].Text;
                    //    item["CustomField5"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items.Count > 51 && this.chkColumns.Items[51].Selected && this.chkColumns.Items[51].Value == "CustomField6")
                    //{
                    //    item["CustomField6"].Text = this.chkColumns.Items[51].Text;
                    //    item["CustomField6"].HorizontalAlign = HorizontalAlign.Right;
                    //}


                    if (this.chkColumns.Items.Count > 47 && this.chkColumns.Items[47].Selected && this.chkColumns.Items[47].Value == "QtyAddedWeekToDate" && item["QtyAddedweektodate"] != null)
                    {
                        item["QtyAddedweektodate"].Text = "Quantity_AWTD";
                        item["QtyAddedweektodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items.Count > 48 && this.chkColumns.Items[48].Selected && this.chkColumns.Items[48].Value == "QtyAddedMonthToDate")
                    {
                        item["qtyaddedmonthtodate"].Text = "Quantity_AMTD";
                        item["qtyaddedmonthtodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items.Count > 49 && this.chkColumns.Items[49].Selected && this.chkColumns.Items[49].Value == "QtyAddedQuarterToDate")
                    {
                        item["qtyaddedquartertodate"].Text = "Quantity_AQTD";
                        item["qtyaddedquartertodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items.Count > 50 && this.chkColumns.Items[50].Selected && this.chkColumns.Items[50].Value == "QtyAddedYearToDate")
                    {
                        item["qtyaddedyeartodate"].Text = "Quantity_AYTD";
                        item["qtyaddedyeartodate"].HorizontalAlign = HorizontalAlign.Right;
                    }


                    if (this.chkColumns.Items.Count > 51 && this.chkColumns.Items[51].Selected && this.chkColumns.Items[51].Value == "QtyAddedFinancialYearToDate")
                    {
                        item["QtyAddedFinancialYearToDate"].Text = "Quantity_AFYTD";
                        item["QtyAddedFinancialYearToDate"].HorizontalAlign = HorizontalAlign.Right;
                    }

                    if (this.chkColumns.Items.Count > 52 && this.chkColumns.Items[52].Selected && this.chkColumns.Items[52].Value == "qtyaddedtilldate")
                    {
                        item["qtyaddedtilldate"].Text = "Quantity_ATD";
                        item["qtyaddedtilldate"].HorizontalAlign = HorizontalAlign.Right;
                    }


                    // Ticket #11148 add columns for custom fields 1 through 5 
                    if (this.chkColumns.Items[53].Selected)
                    {
                        item["CustomDescription1"].Text = this.objlang.GetLanguageConversion("Custom_Description1");
                        item["CustomDescription1"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[54].Selected)
                    {
                        item["CustomDescription2"].Text = this.objlang.GetLanguageConversion("Custom_Description2");
                        item["CustomDescription2"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[55].Selected)
                    {
                        item["CustomDescription3"].Text = this.objlang.GetLanguageConversion("Custom_Description3");
                        item["CustomDescription3"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[56].Selected)
                    {
                        item["CustomDescription4"].Text = this.objlang.GetLanguageConversion("Custom_Description4");
                        item["CustomDescription4"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items[57].Selected)
                    {
                        item["CustomDescription5"].Text = this.objlang.GetLanguageConversion("Custom_Description5");
                        item["CustomDescription5"].HorizontalAlign = HorizontalAlign.Left;
                    }


                    if (this.chkColumns.Items.Count > 58 && this.chkColumns.Items[58].Selected && this.chkColumns.Items[58].Value == "CustomDescription6")
                    {
                        item["CustomDescription6"].Text = this.objlang.GetLanguageConversion("Custom_Description6");
                        item["CustomDescription6"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items.Count > 59 && this.chkColumns.Items[59].Selected && this.chkColumns.Items[59].Value == "CustomDescription7")
                    {
                        item["CustomDescription7"].Text = this.objlang.GetLanguageConversion("Custom_Description7");
                        item["CustomDescription7"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items.Count > 60 && this.chkColumns.Items[60].Selected && this.chkColumns.Items[60].Value == "CustomDescription8")
                    {
                        item["CustomDescription8"].Text = this.objlang.GetLanguageConversion("Custom_Description8");
                        item["CustomDescription8"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items.Count > 61 && this.chkColumns.Items[61].Selected && this.chkColumns.Items[61].Value == "CustomDescription9")
                    {
                        item["CustomDescription9"].Text = this.objlang.GetLanguageConversion("Custom_Description9");
                        item["CustomDescription9"].HorizontalAlign = HorizontalAlign.Left;
                    }
                    if (this.chkColumns.Items.Count > 62 && this.chkColumns.Items[62].Selected && this.chkColumns.Items[62].Value == "CustomDescription10")
                    {
                        item["CustomDescription10"].Text = this.objlang.GetLanguageConversion("Custom_Description10");
                        item["CustomDescription10"].HorizontalAlign = HorizontalAlign.Left;
                    }

                    if (this.chkColumns.Items.Count > 63 && this.chkColumns.Items[63].Selected && this.chkColumns.Items[63].Value == "LocationQty")
                    {
                        item["LocationQty"].Text = "Location Qty";
                        item["LocationQty"].HorizontalAlign = HorizontalAlign.Left;
                    }

                    if (this.chkColumns.Items.Count > 64 && this.chkColumns.Items[64].Selected && this.chkColumns.Items[64].Value == "CustomField2")
                    {
                        item["CustomField2"].Text = this.chkColumns.Items[64].Text;
                        item["CustomField2"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items.Count > 65 && this.chkColumns.Items[65].Selected)
                    {
                        if (this.chkColumns.Items[65].Value == "CustomField3")
                        {
                            item["CustomField3"].Text = this.chkColumns.Items[65].Text;
                            item["CustomField3"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else if (this.chkColumns.Items[65].Value == "CreateDate")
                        {
                            item["CreateDate"].Text = this.chkColumns.Items[65].Text;
                        }
                    }
                    if (this.chkColumns.Items.Count > 66 && this.chkColumns.Items[66].Selected)
                    {
                        if (this.chkColumns.Items[66].Value == "CustomField4")
                        {
                            item["CustomField4"].Text = this.chkColumns.Items[66].Text;
                            item["CustomField4"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else if (this.chkColumns.Items[66].Value == "ModifiedDate")
                        {
                            item["ModifiedDate"].Text = this.chkColumns.Items[66].Text;
                        }
                    }
                    if (this.chkColumns.Items.Count > 67 && this.chkColumns.Items[67].Selected && this.chkColumns.Items[67].Value == "CustomField5")
                    {
                        item["CustomField5"].Text = this.chkColumns.Items[67].Text;
                        item["CustomField5"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items.Count > 68 && this.chkColumns.Items[68].Selected && this.chkColumns.Items[68].Value == "CustomField6")
                    {
                        item["CustomField6"].Text = this.chkColumns.Items[68].Text;
                        item["CustomField6"].HorizontalAlign = HorizontalAlign.Right;
                    }





                    item["IsStockItem"].Visible = false;
                    item["ActivityRecords"].Visible = false;
                    item["TempProduct"].Visible = false;
                    item["TempAvailableQty"].Visible = false;
                    if (this.chkaggregate.Items[0].Selected)
                    {
                        item["openingstock"].Text = this.objlang.GetLanguageConversion("Opening_Stock");
                    }
                    if (this.chkaggregate.Items[1].Selected)
                    {
                        item["location"].Text = this.Location_Value;
                    }
                    if (this.chkaggregate.Items[2].Selected)
                    {
                        item["qtyadded"].Text = this.objlang.GetLanguageConversion("Qty_Added");
                    }
                    if (this.chkaggregate.Items[3].Selected)
                    {
                        item["qtysold"].Text = this.objlang.GetLanguageConversion("Qty_Sold");
                    }
                    if (this.chkaggregate.Items[4].Selected)
                    {
                        item["QtyAdjusted(+)"].Text = this.objlang.GetLanguageConversion("Manual_Adjustment_Plus");
                    }
                    if (this.chkaggregate.Items[5].Selected)
                    {
                        item["QtyAdjusted(-)"].Text = this.objlang.GetLanguageConversion("Manual_Adjustment_Minus");
                    }
                    if (this.chkDrawStock.Checked)
                    {
                        item["AdditionalOptionName"].Text = "Additional Option Name";
                        item["AdditionalOptionValue"].Text = "Additional Option Value";
                        if (this.chkaggregate.Items[0].Selected)
                        {
                            item["AdditionalOptionOpeningStock"].Text = this.objlang.GetLanguageConversion("Additional_Option_Opening_Stock");
                        }
                        if (this.chkaggregate.Items[2].Selected)
                        {
                            item["AdditionalOptionQtyAdded"].Text = this.objlang.GetLanguageConversion("Additional_Option_Qty_Added");
                        }
                        if (this.chkaggregate.Items[3].Selected)
                        {
                            item["AdditionalOptionQtySold"].Text = this.objlang.GetLanguageConversion("Additional_Option_Qty_Sold");
                        }
                        if (this.chkaggregate.Items[4].Selected)
                        {
                            item["AdditionalOptionQuantityIncreament"].Text = this.objlang.GetLanguageConversion("Additional_Option_Quantity_plus");
                        }
                        if (this.chkaggregate.Items[5].Selected)
                        {
                            item["AdditionalOptionQuantityDecreament"].Text = this.objlang.GetLanguageConversion("Additional_Option_Quantity_minus");
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            item["AdditionalOptionQtyInHand"].Text = this.objlang.GetLanguageConversion("Additional_Option_Qty_In_Hand");
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            item["AdditionalOptionAllocatedStock"].Text = this.objlang.GetLanguageConversion("Additional_Option_Allocated_Stock");
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            item["AdditionalOptionAvailableStock"].Text = this.objlang.GetLanguageConversion("Additional_Option_Available_Stock");
                        }
                    }
                }
                if (this.chkColumns.Items[8].Selected && (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem))
                {
                    GridDataItem gridDataItem = (GridDataItem)e.Item;
                    if (gridDataItem["itemdescription"].Text.Trim().Length > 20)
                    {
                        gridDataItem["itemdescription"].Text = string.Concat(gridDataItem["itemdescription"].Text.Substring(0, 20), "...");
                    }
                }
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    GridDataItem item1 = (GridDataItem)e.Item;
                    if (item1["TempProduct"].Text.Trim() == "NonEditable" && item1["TempAvailableQty"].Text.Trim() == "0" && item1["IsStockItem"].Text.Trim() == "1")
                    {
                        item1.BackColor = ColorTranslator.FromHtml("#EE7E7B");
                    }
                    if (item1["TempProduct"].Text.Trim() == "NonEditable" && item1["TempAvailableQty"].Text.Contains("-") && item1["IsStockItem"].Text.Trim() == "1")
                    {
                        item1.BackColor = ColorTranslator.FromHtml("#FF84FF");
                    }
                    if (item1["TempProduct"].Text.Trim() == "NonEditable" && item1["IsStockItem"].Text.Trim() == "1" && item1["ActivityRecords"].Text.Trim() == "0")
                    {
                        item1.BackColor = ColorTranslator.FromHtml("#BFBFFF");
                    }
                    if (this.chkColumns.Items[20].Selected)
                    {
                        item1["fromquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[21].Selected)
                    {
                        item1["toquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[22].Selected)
                    {
                        item1["price"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[23].Selected)
                    {
                        item1["markuppercentage"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[24].Selected)
                    {
                        item1["markupvalue"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[25].Selected)
                    {
                        item1["sellingprice"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[26].Selected)
                    {
                        item1["Weight"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[27].Selected)
                    {
                        item1["Width"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[28].Selected)
                    {
                        item1["Height"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[29].Selected)
                    {
                        item1["Length"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[30].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item1["TotalStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item1["qtyinhand"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[31].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item1["AllocatedStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item1["allocatedqty"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[32].Selected)
                    {
                        if (this.IsStockLocation)
                        {
                            item1["AvailableStockQuantity"].HorizontalAlign = HorizontalAlign.Right;
                        }
                        else
                        {
                            item1["availableqty"].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                    if (this.chkColumns.Items[33].Selected)
                    {
                        item1["reorderquantity"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[34].Selected)
                    {
                        item1["reorderalertlevel"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[35].Selected)
                    {
                        item1["Qtysoldweektodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[36].Selected)
                    {
                        item1["qtysoldmonthtodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[37].Selected)
                    {
                        item1["qtysoldquartertodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[38].Selected)
                    {
                        item1["qtysoldyeartodate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    if (this.chkColumns.Items[39].Selected)
                    {
                        item1["QtySoldFinancialYearToDate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    if (this.chkColumns.Items[40].Selected)
                    {
                        item1["qtysoldtilldate"].HorizontalAlign = HorizontalAlign.Right;
                    }
                    {
                        commonClass _commonClass = this.objJava;
                        var drv = item1.DataItem as DataRowView;
                        if (drv != null && drv.Row.Table.Columns.Contains("CreateDate") && item1["CreateDate"].Text.Trim() != "&nbsp;" && DateTime.TryParse(item1["CreateDate"].Text, out DateTime createdDate))
                        {
                            item1["CreateDate"].Text = _commonClass.Eprint_return_Date_Before_View(item1["CreateDate"].Text.Trim(), this.CompanyID, this.UserID, false);
                        }

                        if (drv != null && drv.Row.Table.Columns.Contains("ModifiedDate") && item1["ModifiedDate"].Text.Trim() != "&nbsp;" && DateTime.TryParse(item1["ModifiedDate"].Text, out DateTime modifiedDate))
                        {
                            item1["ModifiedDate"].Text = _commonClass.Eprint_return_Date_Before_View(item1["ModifiedDate"].Text.Trim(), this.CompanyID, this.UserID, false);
                        }
                    }
                    //ticket 105270
                    //if (this.chkColumns.Items[41].Selected)
                    //{
                    //    item1["QtyAddedweektodate"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items[42].Selected)
                    //{
                    //    item1["qtyaddedmonthtodate"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items[43].Selected)
                    //{
                    //    item1["qtyaddedquartertodate"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items[44].Selected)
                    //{
                    //    item1["qtyaddedyeartodate"].HorizontalAlign = HorizontalAlign.Right;
                    //}

                    //if (this.chkColumns.Items[45].Selected)
                    //{
                    //    item1["QtyAddedFinancialYearToDate"].HorizontalAlign = HorizontalAlign.Right;
                    //}
                    //if (this.chkColumns.Items[46].Selected)
                    //{
                    //    item1["qtyaddedtilldate"].HorizontalAlign = HorizontalAlign.Right;
                    //}


                    item1["IsStockItem"].Visible = false;
                    item1["ActivityRecords"].Visible = false;
                    item1["TempProduct"].Visible = false;
                    item1["TempAvailableQty"].Visible = false;
                    if (this.chkDrawStock.Checked)
                    {
                        item1["AdditionalOptionName"].Visible = true;
                        item1["AdditionalOptionValue"].Visible = true;
                        if (this.chkaggregate.Items[0].Selected)
                        {
                            item1["AdditionalOptionOpeningStock"].Visible = true;
                        }
                        if (this.chkaggregate.Items[2].Selected)
                        {
                            item1["AdditionalOptionQtyAdded"].Visible = true;
                        }
                        if (this.chkaggregate.Items[3].Selected)
                        {
                            item1["AdditionalOptionQtySold"].Visible = true;
                        }
                        if (this.chkaggregate.Items[4].Selected)
                        {
                            item1["AdditionalOptionQuantityIncreament"].Visible = true;
                        }
                        if (this.chkaggregate.Items[5].Selected)
                        {
                            item1["AdditionalOptionQuantityDecreament"].Visible = true;
                        }
                        if (this.chkColumns.Items[30].Selected)
                        {
                            item1["AdditionalOptionQtyInHand"].Visible = true;
                        }
                        if (this.chkColumns.Items[31].Selected)
                        {
                            item1["AdditionalOptionAllocatedStock"].Visible = true;
                        }
                        if (this.chkColumns.Items[32].Selected)
                        {
                            item1["AdditionalOptionAvailableStock"].Visible = true;
                        }

                    }
                }
                GridTableView masterTableView = this.GridProduct.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.CommandItem };
                GridCommandItem items = (GridCommandItem)masterTableView.GetItems(gridItemTypeArray)[0];
                ImageButton imageButton = (ImageButton)items.FindControl("btnNewExport");
                ImageButton imageButton1 = (ImageButton)items.FindControl("btnExport");
                if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("product catalogue", "exportreport").Trim().ToLower() == "false")
                {
                    imageButton.Visible = false;
                    imageButton1.Visible = false;
                    return;
                }
                imageButton.Visible = true;
                imageButton1.Visible = true;
            }
        }

        protected void GridProduct_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (this.Session["beforepostback_dt_runreport"] != null)
            {
                // dataTable = (this.Session["beforepostback_dt_runreport"] == null ? this.Run_Report() : this.Session["beforepostback_dt_runreport"] as DataTable);
                dataTable = this.Session["beforepostback_dt_runreport"] as DataTable;
                this.GridProduct.DataSource = dataTable;
            }
        }

        protected void GridProduct_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void GridProduct_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageSize = e.NewPageSize;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("productcatalogue", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            baseClass.ReturnRoles_Privileges_Reports("product catalogue", "showreport", "");
            this.PriceCatalogueID = Convert.ToInt32(this.Session["PriceCatalogueID"]);
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            this.chkColumns.Items[0].Text = "Item Title";
            this.chkColumns.Items[0].Text = "Item Description";
            this.chkColumns.Items[0].Text = "Item Artwork";
            this.chkColumns.Items[0].Text = "Item Colour";
            this.chkColumns.Items[0].Text = "Item Size";
            this.chkColumns.Items[0].Text = "Item Material";
            this.chkColumns.Items[0].Text = "Item Delivery";
            this.chkColumns.Items[0].Text = "Item Finishing";
            this.chkColumns.Items[0].Text = "Item Proofs";
            this.chkColumns.Items[0].Text = "Item Packing";
            this.chkColumns.Items[0].Text = "Item Notes";
            this.chkColumns.Items[0].Text = "Item Instructions";
            this.getColumnNameFromSettings();
            this.div_header.Visible = true;
            this.pg = "Report";
            this.pg = "productcatalogue";
            if (base.Request.Params["pg"] == null)
            {
                this.pagename = "productcatalogue";
            }
            else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
            {
                this.pagename = "Report";
            }
            global.pageName = this.pagename;
            global.pgName = "";
            this.gloobj.setpagename(this.pagename);
            if (ConnectionClass.WebStore.ToLower() != "yes")
            {
                this.publicAccount_label.Style.Add("display", "none");
            }
            else
            {
                this.publicAccount_label.Style.Add("display", "Block");
            }
            base.Title = this.objLanguage.convert(global.pageTitle("ProductCatalogue Report", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            if (this.pagename.ToString().ToLower().Trim() != "report")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../ProductCatalogue/PriceCatalogue.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Product_Catalogue_View"), "</a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Product_Catalogue_Report")));
            }
            else
            {
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Product_Catalogue_Report")));
            }
            this.txtName.Attributes.Add("autocomplete", "off");
            if (SettingsBasePage.Select_ProductStockManagement(this.CompanyID).Rows[0]["productstockmanagement"].ToString().ToLower() == "true")
            {
                this.DivStockHelpText.Attributes.Add("style", "display:block");
            }
            if (!base.IsPostBack)
            {
                this.Session["DeleteMsg"] = null;
                this.pnlReports.Visible = true;
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
                DropDownList dropDownList = new DropDownList();
                this.objAcc.publicAccount_bind('x', this.CompanyID, dropDownList);
                for (int i = 0; i < dropDownList.Items.Count; i++)
                {
                    if (dropDownList.Items[i].Value == "0")
                    {
                        ListItem listItem = new ListItem();
                        if (i == 0)
                        {
                            listItem.Text = "none";
                            listItem.Value = "0";
                            this.lstAccountPublic.Items.Add(listItem);
                        }
                    }
                    else
                    {
                        ListItem listItem1 = new ListItem()
                        {
                            Text = dropDownList.Items[i].Text,
                            Value = dropDownList.Items[i].Value
                        };
                        this.lstAccountPublic.Items.Add(listItem1);
                    }
                }
                this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(this.cs);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(string.Concat("select CompanyName from tb_Company where CompanyID=", this.CompanyID, " and isdelete=0"), sqlConnection);
                this.CompanyName = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
            this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
            this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
            this.usrReportsave.onLinkProductRunReport += new LinkProductRunReportEventHandler(this.usrReportsave_onLinkProductRunReport);
            this.usrReportsave.OnPageIndexChanged += new OnPageIndexChangedClick(this.usrReportsave_OnPageIndexChanged);
            this.usrReportsave.OnPageSizeChanged += new OnPageSizeChangedClick(this.usrReportsave_OnPageSizeChanged);
            if (!base.IsPostBack)
            {
                this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
                this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
                this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
                this.rdlSpecific.Items[0].Text = this.objLangClass.GetLanguageConversion("Specific");
                this.rdlSpecific.Items[1].Text = this.objLangClass.GetLanguageConversion("Not_Specific");
                this.RadPanelBar1.Items[0].Text = this.objLangClass.GetLanguageConversion("Select_Columns_To_Run_Report");
                this.RadPanelBar1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sort_The_Records");
                this.RadPanelBar1.Items[2].Text = this.objLangClass.GetLanguageConversion("Report_Filters");
                this.RadPanelBar1.Items[3].Text = this.objLangClass.GetLanguageConversion("Aggregate_Functions");
                this.RadPanelBar1.Items[4].Text = this.objLangClass.GetLanguageConversion("Save_Report_Options");
                this.ddldirection.Items[0].Text = this.objLangClass.GetLanguageConversion("Ascending");
                this.ddldirection.Items[1].Text = this.objLangClass.GetLanguageConversion("Descending");
                this.ddlEstimateRange.Items[0].Text = this.objLangClass.GetLanguageConversion("Item_Title");
                this.ddlEstimateRange.Items[1].Text = this.objLangClass.GetLanguageConversion("Category_Name");
                this.ddlEstimateRange.Items[2].Text = this.objLangClass.GetLanguageConversion("Customer_Name");
            }
            try
            {
                DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
                this.Paper_Stock = dataTable.Rows[0]["PaperMeasure"].ToString();
                if (this.Paper_Stock == "mm")
                {
                    this.Paper_Stock_Lenght = "Mtr";
                }
                else if (this.Paper_Stock == "In.")
                {
                    this.Paper_Stock_Lenght = "Feet";
                }
                if (dataTable.Rows[0]["Weight"].ToString() != "")
                {
                    this.Weight_gsm = dataTable.Rows[0]["GeneralWeight"].ToString();
                }
                if (!base.IsPostBack)
                {
                    this.chkColumns.Items[1].Text = this.objlang.GetLanguageConversion("Category_Name");
                    this.chkColumns.Items[2].Text = this.objlang.GetLanguageConversion("Item_Code");
                    this.chkColumns.Items[3].Text = this.objlang.GetLanguageConversion("p_Customer_Code");
                    this.chkColumns.Items[4].Text = this.objlang.GetLanguageConversion("Product_Type");
                    this.chkColumns.Items[5].Text = this.objlang.GetLanguageConversion("OwnerShip");
                    this.chkColumns.Items[6].Text = this.objlang.GetLanguageConversion("Allocation");
                    this.chkColumns.Items[7].Text = this.objlang.GetLanguageConversion("Public_Accounts");
                    this.chkColumns.Items[19].Text = this.objlang.GetLanguageConversion("Pricing_type");
                    this.chkColumns.Items[20].Text = this.objlang.GetLanguageConversion("Start_Qty");
                    this.chkColumns.Items[21].Text = this.objlang.GetLanguageConversion("End_Qty");
                    this.chkColumns.Items[22].Text = this.objlang.GetLanguageConversion("Cost");
                    this.chkColumns.Items[23].Text = string.Concat(this.objlang.GetLanguageConversion("Mark"), " (%)");
                    this.chkColumns.Items[24].Text = this.objlang.GetLanguageConversion("Mark_Value");
                    this.chkColumns.Items[25].Text = this.objlang.GetLanguageConversion("Selling_Price");
                    this.chkColumns.Items[26].Text = string.Concat(this.objlang.GetLanguageConversion("Weight"), " (", this.Weight_gsm, ")");
                    this.chkColumns.Items[27].Text = string.Concat(this.objlang.GetLanguageConversion("Width"), " (", this.Paper_Stock, ")");
                    this.chkColumns.Items[28].Text = string.Concat(this.objlang.GetLanguageConversion("Height"), " (", this.Paper_Stock, ")");
                    this.chkColumns.Items[29].Text = string.Concat(this.objlang.GetLanguageConversion("Length"), " (", this.Paper_Stock_Lenght, ")");
                    this.chkColumns.Items[30].Text = this.objlang.GetLanguageConversion("Qty_On_Hand");
                    this.chkColumns.Items[31].Text = this.objlang.GetLanguageConversion("Allocated_Qty");
                    this.chkColumns.Items[32].Text = this.objlang.GetLanguageConversion("Available_Qty");
                    this.chkColumns.Items[33].Text = this.objlang.GetLanguageConversion("ReOrder_Qty");
                    this.chkColumns.Items[34].Text = this.objlang.GetLanguageConversion("ReOrder_Alert_Level");
                    this.chkColumns.Items[35].Text = this.objlang.GetLanguageConversion("Qty_Sold_Week_to_Date");
                    this.chkColumns.Items[36].Text = this.objlang.GetLanguageConversion("Qty_Sold_Month_to_Date");
                    this.chkColumns.Items[37].Text = this.objlang.GetLanguageConversion("Qty_Sold_Quarter_to_Date");
                    this.chkColumns.Items[38].Text = this.objlang.GetLanguageConversion("Qty_Sold_Year_to_Date");
                    this.chkColumns.Items[39].Text = this.objlang.GetLanguageConversion("Qty_Financial_Sold_Year_to_Date");
                    this.chkColumns.Items[40].Text = this.objlang.GetLanguageConversion("Qty_Sold_till_Date");
                    this.chkColumns.Items[41].Text = this.objlang.GetLanguageConversion("Draw_Stock_From");
                    this.chkColumns.Items[42].Text = this.objlang.GetLanguageConversion("Sales_Tax_Rate");
                    this.chkColumns.Items[43].Text = this.objlang.GetLanguageConversion("Date_Last_Replenished");
                    // Ticket #11148 add columns for custom fields 1 through 5 
                    //this.chkColumns.Items[44].Text = this.objlang.GetLanguageConversion("Custom_Description1");
                    //this.chkColumns.Items[45].Text = this.objlang.GetLanguageConversion("Custom_Description2");
                    //this.chkColumns.Items[46].Text = this.objlang.GetLanguageConversion("Custom_Description3");
                    //this.chkColumns.Items[47].Text = this.objlang.GetLanguageConversion("Custom_Description4");
                    //this.chkColumns.Items[48].Text = this.objlang.GetLanguageConversion("Custom_Description5");
                    this.chkColumns.Items[44].Text = this.objlang.GetLanguageConversion("Outwork_Production_Qty");
                    this.chkColumns.Items[45].Text = this.objlang.GetLanguageConversion("Stock_Cost");
                    this.chkColumns.Items[46].Text = this.objlang.GetLanguageConversion("Supplier_Name");

                    this.chkProductType.Items[0].Text = this.objlang.GetLanguageConversion("Non_Editable");
                    this.chkProductType.Items[1].Text = this.objlang.GetLanguageConversion("Stock");
                    this.chkProductType.Items[2].Text = this.objlang.GetLanguageConversion("Editable");
                    this.chkaggregate.Items[0].Text = this.objlang.GetLanguageConversion("Opening_Stock");
                    this.chkaggregate.Items[2].Text = this.objlang.GetLanguageConversion("Qty_Added");
                    this.chkaggregate.Items[3].Text = this.objlang.GetLanguageConversion("Qty_Sold");
                    this.chkaggregate.Items[4].Text = this.objlang.GetLanguageConversion("Manual_Adjustment_Plus");
                    this.chkaggregate.Items[5].Text = this.objlang.GetLanguageConversion("Manual_Adjustment_Minus");
                    DataTable dataTable1 = SettingsBasePage.productcatalogue_warehousestock_select(this.CompanyID);
                    string str = string.Empty;
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        this.IsDisplayLocation = Convert.ToBoolean(row["Isdisplay"]);
                        if (row["DatafieldName"].ToString().Trim() == "CustomField1")
                        {
                            this.chkaggregate.Items[1].Text = row["ScreenName"].ToString().Trim();
                            this.Location_Value = row["ScreenName"].ToString().Trim();
                        }
                        if (row["DatafieldName"].ToString().Trim() == "CustomField2" && this.chkColumns.Items.Count > 63)
                        {
                            this.chkColumns.Items[64].Text = row["ScreenName"].ToString().Trim();
                            if (!this.IsDisplayLocation)
                            {
                                str = string.Concat(str, Convert.ToString(row["ScreenName"]).Trim(), "^");
                            }
                        }
                        if (row["DatafieldName"].ToString().Trim() == "CustomField3" && this.chkColumns.Items.Count > 64)
                        {
                            this.chkColumns.Items[65].Text = row["ScreenName"].ToString().Trim();
                            if (!this.IsDisplayLocation)
                            {
                                str = string.Concat(str, Convert.ToString(row["ScreenName"]).Trim(), "^");
                            }
                        }
                        if (row["DatafieldName"].ToString().Trim() == "CustomField4" && this.chkColumns.Items.Count > 65)
                        {
                            this.chkColumns.Items[66].Text = row["ScreenName"].ToString().Trim();
                            if (!this.IsDisplayLocation)
                            {
                                str = string.Concat(str, Convert.ToString(row["ScreenName"]).Trim(), "^");
                            }
                        }
                        if (row["DatafieldName"].ToString().Trim() == "CustomField5" && this.chkColumns.Items.Count > 66)
                        {
                            this.chkColumns.Items[67].Text = row["ScreenName"].ToString().Trim();
                            if (!this.IsDisplayLocation)
                            {
                                str = string.Concat(str, Convert.ToString(row["ScreenName"]).Trim(), "^");
                            }
                        }
                        if (!(row["DatafieldName"].ToString().Trim() == "CustomField6") || this.chkColumns.Items.Count <= 67)
                        {
                            continue;
                        }
                        this.chkColumns.Items[68].Text = row["ScreenName"].ToString().Trim();
                        if (this.IsDisplayLocation)
                        {
                            continue;
                        }
                        str = string.Concat(str, Convert.ToString(row["ScreenName"]).Trim(), "^");
                    }
                    int num = 0;
                    while (true)
                    {
                        char[] chrArray = new char[] { '\u005E' };
                        if (num >= (int)str.Split(chrArray).Length - 1)
                        {
                            break;
                        }
                        char[] chrArray1 = new char[] { '\u005E' };
                        if (!string.IsNullOrEmpty(str.Split(chrArray1)[num]))
                        {
                            ListItemCollection items = this.chkColumns.Items;
                            ListItemCollection listItemCollections = this.chkColumns.Items;
                            char[] chrArray2 = new char[] { '\u005E' };
                            items.Remove(listItemCollections.FindByText(Convert.ToString(str.Split(chrArray2)[num]).Trim()));
                        }
                        num++;
                    }
                    this.GetCategorychkListView();
                    this.Session["Export_dt_export_toexcel"] = null;
                }
                if (base.IsPostBack)
                {
                    // this.Session["beforepostback_dt_runreport"] = null;
                }
            }
            catch
            {
            }
        }

        public void ReportDetails(int ReportID)
        {
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                this.chkColumns.Items[i].Selected = false;
            }
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_GetReport_Details", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            this.objJava.closeConnection();
            string empty = string.Empty;
            string str = string.Empty;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["Columns"].ToString();
                this.CategoryName = "";
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = base.SpecialDecode(row["ReportName"].ToString());
                }
                this.txtDescription.Text = row["Description"].ToString();
                string[] strArrays = row["publicAcounts"].ToString().Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    for (int k = 0; k < this.lstAccountPublic.Items.Count; k++)
                    {
                        if (this.lstAccountPublic.Items[k].Value == strArrays[j])
                        {
                            this.lstAccountPublic.Items[k].Selected = true;
                        }
                    }
                }
                if (row["Companyname"].ToString() != "")
                {
                    this.txtName.Text = base.SpecialDecode(row["Companyname"].ToString());
                }
                if (row["IsNonEditable"].ToString() != "True")
                {
                    this.chkProductType.Items[0].Selected = false;
                }
                else
                {
                    this.chkProductType.Items[0].Selected = true;
                }
                if (row["IsStock"].ToString() != "True")
                {
                    this.chkProductType.Items[1].Selected = false;
                }
                else
                {
                    this.chkProductType.Items[1].Selected = true;
                }
                if (row["IsEditable"].ToString() != "True")
                {
                    this.chkProductType.Items[2].Selected = false;
                }
                else
                {
                    this.chkProductType.Items[2].Selected = true;
                }
                if (this.chkaggregate.SelectedIndex != -1)
                {
                    if (this.chkaggregate.Items[0].Selected)
                    {
                        this.chkaggregate.Items[0].Selected = true;
                    }
                    if (this.chkaggregate.Items[1].Selected)
                    {
                        this.chkaggregate.Items[1].Selected = true;
                    }
                    if (this.chkaggregate.Items[2].Selected)
                    {
                        this.chkaggregate.Items[2].Selected = true;
                    }
                    if (this.chkaggregate.Items[3].Selected)
                    {
                        this.chkaggregate.Items[3].Selected = true;
                    }
                    if (this.chkaggregate.Items[4].Selected)
                    {
                        this.chkaggregate.Items[4].Selected = true;
                    }
                    if (this.chkaggregate.Items[5].Selected)
                    {
                        this.chkaggregate.Items[5].Selected = true;
                    }
                }
                if (row["CustomerID"].ToString() != "")
                {
                    this.hid_ClientID.Value = row["CustomerID"].ToString();
                }
                if (row["CategoryID"].ToString() != "")
                {
                    string str1 = base.SpecialDecode(row["CategoryID"].ToString());
                    string[] strArrays1 = str1.Split(new char[] { ',' });
                    foreach (RadComboBoxItem item in this.ddlCategory.Items)
                    {
                        foreach (ListItem listItem in ((CheckBoxList)item.FindControl("chkEstType")).Items)
                        {
                            for (int l = 0; l < (int)strArrays1.Length; l++)
                            {
                                if (listItem.Value == strArrays1[l].ToString().Trim())
                                {
                                    listItem.Selected = true;
                                }
                            }
                        }
                    }
                }
                this.txtFreetext.Text = base.SpecialDecode(row["SearchText"].ToString());
                row["IsSpecific"].ToString();
                if (row["IsSpecific"].ToString().Trim() != "" && row["IsSpecific"].ToString().Trim() != "null" && row["IsSpecific"].ToString().Trim() != "a")
                {
                    this.rdlSpecific.SelectedValue = row["IsSpecific"].ToString();
                }
                if (row["IsDetailedAdditionalOptionStock"].ToString().Trim() == "True")
                {
                    this.chkDrawStock.Checked = true;
                }
                string[] strArrays2 = empty.Split(new char[] { '±' });
                string[] strArrays3 = strArrays2[0].Split(new char[] { 'µ' });
                if (strArrays2.Length > 1)
                {
                    str = strArrays2[1].ToString();
                }

                this.chkColumns.Items[20].Selected = (str.ToLower() == "yes" ? true : false);
                string[] strArrays4 = strArrays3;
                for (int m = 0; m < (int)strArrays4.Length; m++)
                {
                    string str2 = strArrays4[m];
                    if (str2 == "ItemTitle")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (str2.ToLower() == "categoryname")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (str2 == "ItemCode")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (str2.ToLower() == "customercode")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (str2.ToLower() == "iseditableproduct")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (str2.ToLower() == "ownership")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (str2.ToLower() == "allocation")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (str2.ToLower() == "publicaccount")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (str2.ToLower() == "itemdescription")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                    else if (str2.ToLower() == "itemartwork")
                    {
                        this.chkColumns.Items[9].Selected = true;
                    }
                    else if (str2.ToLower() == "itemcolour")
                    {
                        this.chkColumns.Items[10].Selected = true;
                    }
                    else if (str2.ToLower() == "itemsize")
                    {
                        this.chkColumns.Items[11].Selected = true;
                    }
                    else if (str2.ToLower() == "material")
                    {
                        this.chkColumns.Items[12].Selected = true;
                    }
                    else if (str2.ToLower() == "delivery")
                    {
                        this.chkColumns.Items[13].Selected = true;
                    }
                    else if (str2.ToLower() == "finishing")
                    {
                        this.chkColumns.Items[14].Selected = true;
                    }
                    else if (str2.ToLower() == "proofs")
                    {
                        this.chkColumns.Items[15].Selected = true;
                    }
                    else if (str2.ToLower() == "itempacking")
                    {
                        this.chkColumns.Items[16].Selected = true;
                    }
                    else if (str2.ToLower() == "itemnotes")
                    {
                        this.chkColumns.Items[17].Selected = true;
                    }
                    else if (str2.Trim() == "[Terms/Instructions]")
                    {
                        this.chkColumns.Items[18].Selected = true;
                    }
                    else if (str2.Trim() == "MatrixType")
                    {
                        this.chkColumns.Items[19].Selected = true;
                    }
                    else if (str2.Trim() == "fromquantity")
                    {
                        this.chkColumns.Items[20].Selected = true;
                    }
                    else if (str2.Trim() == "toquantity")
                    {
                        this.chkColumns.Items[21].Selected = true;
                    }
                    else if (str2.Trim() == "price")
                    {
                        this.chkColumns.Items[22].Selected = true;
                    }
                    else if (str2.Trim() == "MarkUpPercentage")
                    {
                        this.chkColumns.Items[23].Selected = true;
                    }
                    else if (str2.Trim() == "MarkUpValue")
                    {
                        this.chkColumns.Items[24].Selected = true;
                    }
                    else if (str2.Trim() == "SellingPrice")
                    {
                        this.chkColumns.Items[25].Selected = true;
                    }
                    else if (str2.Trim() == "Weight")
                    {
                        this.chkColumns.Items[26].Selected = true;
                    }
                    else if (str2.Trim() == "Width")
                    {
                        this.chkColumns.Items[27].Selected = true;
                    }
                    else if (str2.Trim() == "Height")
                    {
                        this.chkColumns.Items[28].Selected = true;
                    }
                    else if (str2.Trim() == "Length")
                    {
                        this.chkColumns.Items[29].Selected = true;
                    }
                    else if (str2.Trim() == "QtyInHand")
                    {
                        this.chkColumns.Items[30].Selected = true;
                    }
                    else if (str2.Trim() == "AllocatedQty")
                    {
                        this.chkColumns.Items[31].Selected = true;
                    }
                    else if (str2.Trim() == "AvailableQty")
                    {
                        this.chkColumns.Items[32].Selected = true;
                    }
                    else if (str2.Trim() == "TotalStockQuantity")
                    {
                        this.chkColumns.Items[30].Selected = true;
                    }
                    else if (str2.Trim() == "AllocatedStockQuantity")
                    {
                        this.chkColumns.Items[31].Selected = true;
                    }
                    else if (str2.Trim() == "AvailableStockQuantity")
                    {
                        this.chkColumns.Items[32].Selected = true;
                    }
                    else if (str2.Trim() == "ReOrderQuantity")
                    {
                        this.chkColumns.Items[33].Selected = true;
                    }
                    else if (str2.Trim() == "ReorderAlertLevel")
                    {
                        this.chkColumns.Items[34].Selected = true;
                    }
                    else if (str2.Trim() == "QtySoldWeekToDate")
                    {
                        this.chkColumns.Items[35].Selected = true;
                    }
                    else if (str2.Trim() == "QtySoldMonthToDate")
                    {
                        this.chkColumns.Items[36].Selected = true;
                    }
                    else if (str2.Trim() == "QtySoldQuarterToDate")
                    {
                        this.chkColumns.Items[37].Selected = true;
                    }
                    else if (str2.Trim() == "QtySoldYearToDate")
                    {
                        this.chkColumns.Items[38].Selected = true;
                    }

                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    else if (str2.Trim() == "QtySoldFinancialYearToDate")
                    {
                        this.chkColumns.Items[39].Selected = true;
                    }

                    else if (str2.Trim() == "QtySoldTillDate")
                    {
                        this.chkColumns.Items[40].Selected = true;
                    }
                    else if (str2.Trim() == "DrawStockFrom")
                    {
                        this.chkColumns.Items[41].Selected = true;
                    }
                    else if (str2.Trim() == "SalesTaxRate")
                    {
                        this.chkColumns.Items[42].Selected = true;
                    }
                    else if (str2.Trim() == "DateLastReplenished")
                    {
                        this.chkColumns.Items[43].Selected = true;
                    }
                    // Ticket #11148 add columns for custom fields 1 through 5 
                    //else if (str2.Trim() == "CustomDescription1")
                    //{
                    //    this.chkColumns.Items[44].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomDescription2")
                    //{
                    //    this.chkColumns.Items[45].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomDescription3")
                    //{
                    //    this.chkColumns.Items[46].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomDescription4")
                    //{
                    //    this.chkColumns.Items[47].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomDescription5")
                    //{
                    //    this.chkColumns.Items[48].Selected = true;
                    //}
                    else if (str2.Trim() == "OutworkProductionQty")
                    {
                        this.chkColumns.Items[44].Selected = true;
                    }
                    else if (str2.Trim() == "StockCost")
                    {
                        this.chkColumns.Items[45].Selected = true;
                    }
                    else if (str2.Trim() == "SupplierName")
                    {
                        this.chkColumns.Items[46].Selected = true;
                    }
                    //else if (str2.Trim() == "CustomField2")
                    //{
                    //    this.chkColumns.Items[47].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomField3")
                    //{
                    //    this.chkColumns.Items[48].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomField4")
                    //{
                    //    this.chkColumns.Items[49].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomField5")
                    //{
                    //    this.chkColumns.Items[50].Selected = true;
                    //}
                    //else if (str2.Trim() == "CustomField6")
                    //{
                    //    this.chkColumns.Items[51].Selected = true;
                    //}

                    else if (str2.Trim() == "QtyAddedWeekToDate")
                    {
                        this.chkColumns.Items[47].Selected = true;
                    }
                    else if (str2.Trim() == "QtyAddedMonthToDate")
                    {
                        this.chkColumns.Items[48].Selected = true;
                    }
                    else if (str2.Trim() == "QtyAddedQuarterToDate")
                    {
                        this.chkColumns.Items[49].Selected = true;
                    }
                    else if (str2.Trim() == "QtyAddedYearToDate")
                    {
                        this.chkColumns.Items[50].Selected = true;
                    }

                    // Ticket #5202 Added new checkbox column "QTY financial year sold to date"
                    else if (str2.Trim() == "QtyAddedFinancialYearToDate")
                    {
                        this.chkColumns.Items[51].Selected = true;
                    }

                    else if (str2.Trim() == "QtyAddedTillDate")
                    {
                        this.chkColumns.Items[52].Selected = true;
                    }

                    else if (str2.Trim() == "CustomDescription1")
                    {
                        this.chkColumns.Items[53].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription2")
                    {
                        this.chkColumns.Items[54].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription3")
                    {
                        this.chkColumns.Items[55].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription4")
                    {
                        this.chkColumns.Items[56].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription5")
                    {
                        this.chkColumns.Items[57].Selected = true;
                    }


                    else if (str2.Trim() == "CustomDescription6")
                    {
                        this.chkColumns.Items[58].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription7")
                    {
                        this.chkColumns.Items[59].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription8")
                    {
                        this.chkColumns.Items[60].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription9")
                    {
                        this.chkColumns.Items[61].Selected = true;
                    }
                    else if (str2.Trim() == "CustomDescription10")
                    {
                        this.chkColumns.Items[62].Selected = true;
                    }
                    else if (str2.Trim() == "LocationQty")
                    {
                        this.chkColumns.Items[63].Selected = true;
                    }


                    else if (str2.Trim() == "CustomField2")
                    {
                        this.chkColumns.Items[64].Selected = true;
                    }
                    else if (str2.Trim() == "CustomField3")
                    {
                        this.chkColumns.Items[65].Selected = true;
                    }
                    else if (str2.Trim() == "CustomField4")
                    {
                        this.chkColumns.Items[66].Selected = true;
                    }
                    else if (str2.Trim() == "CustomField5")
                    {
                        this.chkColumns.Items[67].Selected = true;
                    }
                    else if (str2.Trim() == "CustomField6")
                    {
                        this.chkColumns.Items[68].Selected = true;
                    }
                    else if (str2.Trim() == "CreateDate")
                    {
                        if (this.chkColumns.Items.FindByValue("CreateDate") != null)
                        {
                            this.chkColumns.Items.FindByValue("CreateDate").Selected = true;
                        }
                    }
                    else if (str2.Trim() == "ModifiedDate")
                    {
                        if (this.chkColumns.Items.FindByValue("ModifiedDate") != null)
                        {
                            this.chkColumns.Items.FindByValue("ModifiedDate").Selected = true;
                        }
                       
                    }







                    else if (str2.Trim() == "OpeningStock")
                    {
                        this.chkaggregate.Items[0].Selected = true;
                    }
                    else if (str2.Trim() == "Location")
                    {
                        this.chkaggregate.Items[1].Selected = true;
                    }
                    else if (str2.Trim() == "QtyAdded")
                    {
                        this.chkaggregate.Items[2].Selected = true;
                    }
                    else if (str2.Trim() == "QtySold")
                    {
                        this.chkaggregate.Items[3].Selected = true;
                    }
                    else if (str2.Trim() == "[QtyAdjusted(+)]")
                    {
                        this.chkaggregate.Items[4].Selected = true;
                    }
                    else if (str2.Trim() == "[QtyAdjusted(-)]")
                    {
                        this.chkaggregate.Items[5].Selected = true;
                    }
                }
            }
        }

        public DataTable Run_Report()
        {
            string empty = string.Empty;
            string str = string.Empty;
            //if ((this.chkColumns.Items.Count <= 49 || !this.chkColumns.Items[49].Selected) && (this.chkColumns.Items.Count <= 50 || !this.chkColumns.Items[50].Selected) && (this.chkColumns.Items.Count <= 51 || !this.chkColumns.Items[51].Selected) && (this.chkColumns.Items.Count <= 52 || !this.chkColumns.Items[52].Selected) && (this.chkColumns.Items.Count <= 53 || !this.chkColumns.Items[53].Selected) && !this.chkaggregate.Items[1].Selected)
            if ((this.chkColumns.Items.Count <= 50 || !this.chkColumns.Items[50].Selected) && (this.chkColumns.Items.Count <= 51 || !this.chkColumns.Items[51].Selected) && (this.chkColumns.Items.Count <= 52 || !this.chkColumns.Items[52].Selected) && (this.chkColumns.Items.Count <= 53 || !this.chkColumns.Items[53].Selected) && !this.chkaggregate.Items[1].Selected)
            {
                this.chkColumns.Items[30].Value = "QtyInHand";
                this.chkColumns.Items[31].Value = "AllocatedQty";
                this.chkColumns.Items[32].Value = "AvailableQty";
                this.IsStockLocation = false;
            }
            else
            {
                this.chkColumns.Items[30].Value = "TotalStockQuantity";
                this.chkColumns.Items[31].Value = "AllocatedStockQuantity";
                this.chkColumns.Items[32].Value = "AvailableStockQuantity";
                this.IsStockLocation = true;
            }
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Value.ToLower() == "itemtitle")
                {
                    this.strColumns.Append(this.chkColumns.Items[i].Value);
                }
                if (this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value != "cost" && this.chkColumns.Items[i].Value != "fromquantity" && this.chkColumns.Items[i].Value != "toquantity")
                    {
                        if (i != 0)
                        {
                            this.strColumns.Append(string.Concat(",", this.chkColumns.Items[i].Value));
                        }
                        //else
                        //{
                        //    this.strColumns.Append(this.chkColumns.Items[i].Value);
                        //}
                    }
                    else if (this.chkColumns.Items[i].Value == "cost")
                    {
                        this.Qtyoption = "yes";
                        this.IsPriceChecked = "yes";
                        this.strColumns.Append(string.Concat(',', this.chkColumns.Items[i].Value));
                    }
                    else if (this.chkColumns.Items[i].Value == "fromquantity" || this.chkColumns.Items[i].Value == "toquantity" || this.chkColumns.Items[i].Value == "price" || this.chkColumns.Items[i].Value == "MarkUpPercentage" || this.chkColumns.Items[i].Value == "MarkUpValue" || this.chkColumns.Items[i].Value == "SellingPrice")
                    {
                        this.Qtyoption = "yes";
                        this.strColumns.Append(string.Concat(',', this.chkColumns.Items[i].Value));
                    }
                }
                if (this.chkColumns.Items[22].Selected || this.chkColumns.Items[23].Selected || this.chkColumns.Items[24].Selected || this.chkColumns.Items[25].Selected || this.chkColumns.Items[26].Selected || this.chkColumns.Items[27].Selected || this.chkColumns.Items[28].Selected || this.chkColumns.Items[29].Selected)
                {
                    this.Qtyoption = "yes";
                }
            }
            if (this.chkaggregate.SelectedIndex != -1)
            {
                if (this.chkaggregate.Items[0].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[0].Value));
                }
                if (this.chkaggregate.Items[1].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[1].Value));
                }
                if (this.chkaggregate.Items[2].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[2].Value));
                }
                if (this.chkaggregate.Items[3].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[3].Value));
                }
                if (this.chkaggregate.Items[4].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[4].Value));
                }
                if (this.chkaggregate.Items[5].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[5].Value));
                }
            }
            if (this.chkDrawStock.Checked)
            {
                this.strColumns.Append(string.Concat(',', "AdditionalOptionName,AdditionalOptionValue"));
                if (this.chkColumns.Items[30].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtyInHand"));
                }
                if (this.chkColumns.Items[31].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionAllocatedStock"));
                }
                if (this.chkColumns.Items[32].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionAvailableStock"));
                }
                if (this.chkaggregate.Items[0].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionOpeningStock"));
                }
                if (this.chkaggregate.Items[2].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtyAdded"));
                }
                if (this.chkaggregate.Items[3].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtySold"));
                }
                if (this.chkaggregate.Items[4].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQuantityIncreament"));
                }
                if (this.chkaggregate.Items[5].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQuantityDecreament"));
                }
            }
            this.strColumns.Append(string.Concat(',', "IsStockItem,ActivityRecords,TempProduct,TempAvailableQty"));
            int num = 0;
            foreach (RadComboBoxItem item in this.ddlCategory.Items)
            {
                foreach (ListItem listItem in ((CheckBoxList)item.FindControl("chkEstType")).Items)
                {
                    if (!listItem.Selected)
                    {
                        continue;
                    }
                    productcatalogue_report commonProductcatalogueReport = this;
                    commonProductcatalogueReport.CategoryName = string.Concat(commonProductcatalogueReport.CategoryName, base.SpecialEncode(listItem.Value), ", ");
                    num++;
                }
            }
            if (this.CategoryName.Trim() != "")
            {
                this.CategoryName = this.CategoryName.Substring(0, this.CategoryName.Length - 2);
            }
            if (this.lstAccountPublic.Text != "")
            {
                for (int j = 0; j < this.lstAccountPublic.Items.Count; j++)
                {
                    if (this.lstAccountPublic.Items[j].Selected)
                    {
                        empty = string.Concat(empty, this.lstAccountPublic.Items[j].Value, ",");
                    }
                }
            }
            if (this.chkColumns.Items[20].Selected || this.chkColumns.Items[21].Selected)
            {
                str = (this.ddlEstimateRange.SelectedIndex != 0 || num == 0 ? this.ddlEstimateRange.SelectedItem.Value : string.Concat(this.ddlEstimateRange.SelectedItem.Value, " "));
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num1 = (!this.chkProductType.Items[0].Selected ? 0 : 1);
            num2 = (!this.chkProductType.Items[1].Selected ? 0 : 1);
            num3 = (!this.chkProductType.Items[2].Selected ? 0 : 1);
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            if (this.chkaggregate.Items[0].Selected)
            {
                num4 = 1;
            }
            if (this.chkaggregate.Items[1].Selected)
            {
                num5 = 1;
            }
            if (this.chkaggregate.Items[2].Selected)
            {
                num6 = 1;
            }
            if (this.chkaggregate.Items[3].Selected)
            {
                num7 = 1;
            }
            if (this.chkaggregate.Items[4].Selected)
            {
                num8 = 1;
            }
            if (this.chkaggregate.Items[5].Selected)
            {
                num9 = 1;
            }
            if (this.chkDrawStock.Checked)
            {
                num10 = 1;
            }
            string empty1 = string.Empty;
            if (this.ddlCategory.SelectedValue.ToString().Trim() != "0")
            {
                foreach (RadComboBoxItem radComboBoxItem in this.ddlCategory.Items)
                {
                    foreach (ListItem item1 in ((CheckBoxList)radComboBoxItem.FindControl("chkEstType")).Items)
                    {
                        if (!item1.Selected)
                        {
                            continue;
                        }
                        empty1 = string.Concat(empty1, base.SpecialEncode(item1.Value), ", ");
                    }
                }
            }
            if (empty1.Trim() != "0" && empty1 != "")
            {
                empty1 = empty1.Substring(0, empty1.Length - 2);
            }
            string str1 = string.Concat("%27", str, "%27");
            string str2 = string.Concat("%27", this.ddldirection.SelectedItem.Value, "%27");
            string str3 = string.Concat("%27", this.strColumns.ToString(), "%27");
            string str4 = string.Concat("%27", this.Qtyoption, "%27");
            string str5 = string.Concat("%27", base.SpecialEncode(this.txtFreetext.Text), "%27");
            string str6 = string.Concat("%27", this.CategoryName, "%27");
            string str7 = string.Concat("%27", base.SpecialEncode(this.txtName.Text.ToLower()), "%27");
            string str8 = "%27%27";
            string str9 = "%27%27";
            string str10 = string.Concat("%27", this.DateType, "%27");
            string str11 = string.Concat("%27", this.CompanyName, "%27");
            string str12 = string.Concat("%27", this.txtSaveReports.Text, "%27");
            string str13 = string.Concat("%27", this.txtDescription.Text, "%27");
            string str14 = string.Concat("%27", this.PageName, "%27");
            string str15 = string.Concat("%27", this.FromDate, "%27");
            string str16 = string.Concat("%27", this.ToDate, "%27");
            string str17 = string.Concat("%27", this.createdDate, "%27");
            string str18 = string.Concat("%27", empty1, "%27");
            string.Concat("%27", this.IsPriceChecked, "%27");
            string str19 = string.Concat("%27", empty, "%27");
            string str20 = string.Concat("%27", this.ISDateChecked, "%27");
            string str21 = "";
            for (int k = 0; k < this.chkaggregate.Items.Count; k++)
            {
                if (this.chkaggregate.Items[k].Selected)
                {
                    str21 = string.Concat(str21, this.chkaggregate.Items[k].Value, ",");
                }
            }
            string[] strArrays = str21.Split(new char[] { ',' });
            for (int l = 0; l < (int)strArrays.Length; l++)
            {
                if (str3.IndexOf(string.Concat(strArrays[l], ",")) > -1 && strArrays[l] != "")
                {
                    int num11 = str3.IndexOf(string.Concat(strArrays[l], ","));
                    str3 = str3.Remove(num11, strArrays[l].Length + 1);
                }
            }
            if (str3.Contains(",AdditionalOptionName"))
            {
                int num12 = str3.IndexOf(",AdditionalOptionName");
                str3 = string.Concat(str3.Remove(num12), ",IsStockItem,ActivityRecords,TempProduct,TempAvailableQty%27");
            }
            object[] companyID = new object[] { "PC_Estore_Products_Report ", this.CompanyID, "$@pagesize$@pagenumber$", str1, "$", str2, "$", str3, "$", str4, "$", this.IsPriceChecked, "$", str5, "$", str6, "$", str7, "$", str19, "$", str8, "$", str20, "$", str9, "$", str10, "$", str11, "$", str12, "$", str13, "$", str14, "$", Convert.ToInt64(this.UserID), "$", Convert.ToInt64(this.ReportID), "$", str15, "$", str16, "$", str17, "$", str18, "$@customerid$", Convert.ToInt16(num1), "$", Convert.ToInt16(num2), "$", Convert.ToInt16(num3), "$", Convert.ToInt16(num4), "$", Convert.ToInt16(num5), "$", Convert.ToInt16(num6), "$", Convert.ToInt16(num7), "$", Convert.ToInt16(num8), "$", Convert.ToInt16(num9), "$", Convert.ToInt16(num10), "$@StoreUserID" };
            this.Querytext = string.Concat(companyID);
            DataSet dataSet = SettingsBasePage.report_pricecatalogue_select(this.CompanyID, 1000000, 1, str, this.ddldirection.SelectedItem.Value, this.strColumns.ToString(), this.Qtyoption, this.IsPriceChecked, base.SpecialEncode(this.txtFreetext.Text), this.CategoryName, base.SpecialEncode(this.txtName.Text.ToLower()), empty, this.rdlSpecific.SelectedValue, this.ISDateChecked, this.NewSaveType, this.DateType, this.CompanyName, this.txtSaveReports.Text, this.txtDescription.Text, this.PageName, Convert.ToInt64(this.UserID), Convert.ToInt64(this.ReportID), this.FromDate, this.ToDate, this.createdDate, empty1, Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt16(num1), Convert.ToInt16(num2), Convert.ToInt16(num3), Convert.ToInt16(num4), Convert.ToInt16(num5), Convert.ToInt16(num6), Convert.ToInt16(num7), Convert.ToInt16(num8), Convert.ToInt16(num9), Convert.ToInt16(num10));
            if (this.NewSaveType.ToLower() == "save")
            {
                long num13 = (long)0;
                SqlCommand sqlCommand = new SqlCommand("SELECT top 1 ReportID FROM tb_Reports_Save WHERE Isdeleted = 0 and pagename = '' ORDER by reportid desc", this.objJava.openConnection())
                {
                    CommandType = CommandType.Text
                };
                num13 = (long)Convert.ToInt32(sqlCommand.ExecuteScalar());
                this.objJava.closeConnection();
                StringBuilder stringBuilder = new StringBuilder();
                companyID = new object[] { "Update tb_Reports_Save set QueryText = '", this.Querytext, "' where ReportID = ", num13, " and pagename = ''" };
                stringBuilder.Append(string.Concat(companyID));
                SqlCommand sqlCommand1 = new SqlCommand(stringBuilder.ToString(), this.objJava.openConnection())
                {
                    CommandType = CommandType.Text
                };
                sqlCommand1.ExecuteNonQuery();
                this.objJava.closeConnection();
            }
            else if (this.NewSaveType.ToLower() == "update" && Convert.ToInt64(this.ReportID) != (long)0)
            {
                long num14 = (long)0;
                num14 = Convert.ToInt64(this.ReportID);
                long num15 = (long)0;
                SqlCommand sqlCommand2 = new SqlCommand("SELECT top 1 ReportID FROM tb_Reports_Save WHERE Isdeleted = 0 and pagename = '' ORDER by reportid desc", this.objJava.openConnection())
                {
                    CommandType = CommandType.Text
                };
                num15 = (long)Convert.ToInt32(sqlCommand2.ExecuteScalar());
                this.objJava.closeConnection();
                StringBuilder stringBuilder1 = new StringBuilder();
                companyID = new object[] { "Update tb_Reports_Save set QueryText = '", this.Querytext, "' where ReportID = ", num15, " and pagename = '' " };
                stringBuilder1.Append(string.Concat(companyID));
                SqlCommand sqlCommand3 = new SqlCommand(stringBuilder1.ToString(), this.objJava.openConnection())
                {
                    CommandType = CommandType.Text
                };
                sqlCommand3.ExecuteNonQuery();
                this.objJava.closeConnection();
                StringBuilder stringBuilder2 = new StringBuilder();
                companyID = new object[] { "Update tb_EstoreReports_AllocatedCustomers set ReportID = ", num15, " where ReportID = ", num14, " and pagetype='product'" };
                stringBuilder2.Append(string.Concat(companyID));
                SqlCommand sqlCommand4 = new SqlCommand(stringBuilder2.ToString(), this.objJava.openConnection())
                {
                    CommandType = CommandType.Text
                };
                sqlCommand4.ExecuteNonQuery();
                this.objJava.closeConnection();
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.GridProduct.PagerStyle.Visible = false;
            }
            else
            {
                this.GridProduct.PagerStyle.Visible = true;
            }
            for (int m = 0; m < dataSet.Tables[0].Columns.Count; m++)
            {
                dataSet.Tables[0].Columns[m].ReadOnly = false;
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (row.Table.Columns.Contains("ItemTitle"))
                {
                    row["ItemTitle"] = base.SpecialDecode(row["ItemTitle"].ToString());
                }
                if (row.Table.Columns.Contains("CategoryName"))
                {
                    row["CategoryName"] = base.SpecialDecode(row["CategoryName"].ToString());
                }
                if (row.Table.Columns.Contains("ItemCode"))
                {
                    row["ItemCode"] = base.SpecialDecode(row["ItemCode"].ToString());
                }
                if (row.Table.Columns.Contains("CustomerCode"))
                {
                    row["CustomerCode"] = base.SpecialDecode(row["CustomerCode"].ToString());
                }
                if (row.Table.Columns.Contains("ItemDescription"))
                {
                    row["ItemDescription"] = base.SpecialDecode(row["ItemDescription"].ToString());
                }
                if (row.Table.Columns.Contains("ItemArtWork"))
                {
                    row["ItemArtWork"] = base.SpecialDecode(row["ItemArtWork"].ToString());
                }
                if (row.Table.Columns.Contains("ItemColour"))
                {
                    row["ItemColour"] = base.SpecialDecode(row["ItemColour"].ToString());
                }
                if (row.Table.Columns.Contains("ItemSize"))
                {
                    row["ItemSize"] = base.SpecialDecode(row["ItemSize"].ToString());
                }
                if (row.Table.Columns.Contains("Material"))
                {
                    row["Material"] = base.SpecialDecode(row["Material"].ToString());
                }
                if (row.Table.Columns.Contains("Delivery"))
                {
                    row["Delivery"] = base.SpecialDecode(row["Delivery"].ToString());
                }
                if (row.Table.Columns.Contains("Finishing"))
                {
                    row["Finishing"] = base.SpecialDecode(row["Finishing"].ToString());
                }
                if (row.Table.Columns.Contains("Proofs"))
                {
                    row["Proofs"] = base.SpecialDecode(row["Proofs"].ToString());
                }
                if (row.Table.Columns.Contains("ItemPacking"))
                {
                    row["ItemPacking"] = base.SpecialDecode(row["ItemPacking"].ToString());
                }
                if (row.Table.Columns.Contains("ItemNotes"))
                {
                    row["ItemNotes"] = base.SpecialDecode(row["ItemNotes"].ToString());
                }
                if (!row.Table.Columns.Contains("Terms/Instructions"))
                {
                    continue;
                }
                row["Terms/Instructions"] = base.SpecialDecode(row["Terms/Instructions"].ToString());
            }
            if (this.Qtyoption == "no")
            {
                dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
                dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[0]);
            }
            this.GridProduct.DataSource = dataSet.Tables[0];
            this.GridProduct.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);
            this.lblTotalRecords.Text = dataSet.Tables[1].Rows[0][0].ToString();
            this.hdn_reportID.Value = dataSet.Tables[2].Rows[0][0].ToString();
            this.hdn_reportID2.Value = dataSet.Tables[2].Rows[0][0].ToString();
            this.Session["beforepostback_dt_runreport"] = dataSet.Tables[0];
            return dataSet.Tables[0];
        }

        public DataTable Run_ReportExport()
        {
            string empty = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value != "cost" && this.chkColumns.Items[i].Value != "fromquantity" && this.chkColumns.Items[i].Value != "toquantity")
                    {
                        if (i != 0)
                        {
                            this.strColumns.Append(string.Concat(",", this.chkColumns.Items[i].Value));
                        }
                        else
                        {
                            this.strColumns.Append(this.chkColumns.Items[i].Value);
                        }
                    }
                    else if (this.chkColumns.Items[i].Value == "cost")
                    {
                        this.IsPriceChecked = "yes";
                        this.strColumns.Append(string.Concat(',', this.chkColumns.Items[i].Value));
                    }
                    else if (this.chkColumns.Items[i].Value == "fromquantity" || this.chkColumns.Items[i].Value == "toquantity")
                    {
                        this.Qtyoption = "yes";
                        this.strColumns.Append(string.Concat(',', this.chkColumns.Items[i].Value));
                    }
                }
                if (this.chkColumns.Items[22].Selected || this.chkColumns.Items[23].Selected || this.chkColumns.Items[24].Selected || this.chkColumns.Items[25].Selected || this.chkColumns.Items[26].Selected || this.chkColumns.Items[27].Selected || this.chkColumns.Items[28].Selected || this.chkColumns.Items[29].Selected)
                {
                    this.Qtyoption = "yes";
                }
            }
            if (this.chkaggregate.SelectedIndex != -1)
            {
                if (this.chkaggregate.Items[0].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[0].Value));
                }
                if (this.chkaggregate.Items[1].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[1].Value));
                }
                if (this.chkaggregate.Items[2].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[2].Value));
                }
                if (this.chkaggregate.Items[3].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[3].Value));
                }
                if (this.chkaggregate.Items[4].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[4].Value));
                }
                if (this.chkaggregate.Items[5].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[5].Value));
                }
            }
            if (this.chkDrawStock.Checked)
            {
                this.strColumns.Append(string.Concat(',', "AdditionalOptionName,AdditionalOptionValue"));
                if (this.chkColumns.Items[30].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtyInHand"));
                }
                if (this.chkColumns.Items[31].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionAllocatedStock"));
                }
                if (this.chkColumns.Items[32].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionAvailableStock"));
                }
                if (this.chkaggregate.Items[0].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionOpeningStock"));
                }
                if (this.chkaggregate.Items[2].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtyAdded"));
                }
                if (this.chkaggregate.Items[3].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQtySold"));
                }
                if (this.chkaggregate.Items[4].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQuantityIncreament"));
                }
                if (this.chkaggregate.Items[5].Selected)
                {
                    this.strColumns.Append(string.Concat(',', "AdditionalOptionQuantityDecreament"));
                }
            }
            this.strColumns.Append(string.Concat(',', "IsStockItem,ActivityRecords,TempProduct,TempAvailableQty"));
            int num = 0;
            foreach (RadComboBoxItem item in this.ddlCategory.Items)
            {
                foreach (ListItem listItem in ((CheckBoxList)item.FindControl("chkEstType")).Items)
                {
                    if (!listItem.Selected)
                    {
                        continue;
                    }
                    productcatalogue_report commonProductcatalogueReport = this;
                    commonProductcatalogueReport.CategoryName = string.Concat(commonProductcatalogueReport.CategoryName, base.SpecialEncode(listItem.Value), ", ");
                    num++;
                }
            }
            if (this.CategoryName.Trim() != "")
            {
                this.CategoryName = this.CategoryName.Substring(0, this.CategoryName.Length - 2);
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            if (this.chkProductType.Items[0].Selected)
            {
                num1 = 1;
            }
            if (this.chkProductType.Items[1].Selected)
            {
                num2 = 1;
            }
            if (this.chkProductType.Items[2].Selected)
            {
                num3 = 1;
            }
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            if (this.chkaggregate.Items[0].Selected)
            {
                num4 = 1;
            }
            if (this.chkaggregate.Items[1].Selected)
            {
                num5 = 1;
            }
            if (this.chkaggregate.Items[2].Selected)
            {
                num6 = 1;
            }
            if (this.chkaggregate.Items[3].Selected)
            {
                num7 = 1;
            }
            if (this.chkaggregate.Items[4].Selected)
            {
                num8 = 1;
            }
            if (this.chkaggregate.Items[5].Selected)
            {
                num9 = 1;
            }
            if (this.chkDrawStock.Checked)
            {
                num10 = 1;
            }
            if (this.lstAccountPublic.Text != "")
            {
                for (int j = 0; j < this.lstAccountPublic.Items.Count; j++)
                {
                    if (this.lstAccountPublic.Items[j].Selected)
                    {
                        empty = string.Concat(empty, this.lstAccountPublic.Items[j].Value, ",");
                    }
                }
            }
            if (this.chkColumns.Items[21].Selected)
            {
                str = (this.ddlEstimateRange.SelectedIndex != 0 || num == 0 ? this.ddlEstimateRange.SelectedItem.Value : string.Concat(this.ddlEstimateRange.SelectedItem.Value, " "));
            }
            string empty1 = string.Empty;
            if (this.ddlCategory.SelectedValue.ToString().Trim() != "0")
            {
                foreach (RadComboBoxItem radComboBoxItem in this.ddlCategory.Items)
                {
                    foreach (ListItem item1 in ((CheckBoxList)radComboBoxItem.FindControl("chkEstType")).Items)
                    {
                        if (!item1.Selected)
                        {
                            continue;
                        }
                        empty1 = string.Concat(empty1, base.SpecialEncode(item1.Value), ", ");
                    }
                }
            }
            if (empty1.Trim() != "0" && empty1 != "")
            {
                empty1 = empty1.Substring(0, empty1.Length - 2);
            }
            this.ReportID = Convert.ToInt32(this.hdn_reportID.Value);
            DataSet dataSet = SettingsBasePage.report_pricecatalogue_select(this.CompanyID, 1000000, 1, str, this.ddldirection.SelectedItem.Value, this.strColumns.ToString(), this.Qtyoption, this.IsPriceChecked, base.SpecialEncode(this.txtFreetext.Text), this.CategoryName, base.SpecialEncode(this.txtName.Text.ToLower()), empty, this.rdlSpecific.SelectedValue, this.ISDateChecked, this.NewSaveType, this.DateType, this.CompanyName, this.txtSaveReports.Text, this.txtDescription.Text, this.PageName, Convert.ToInt64(this.UserID), Convert.ToInt64(this.ReportID), this.FromDate, this.ToDate, this.createdDate, empty1, Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt16(num1), Convert.ToInt16(num2), Convert.ToInt16(num3), Convert.ToInt16(num4), Convert.ToInt16(num5), Convert.ToInt16(num6), Convert.ToInt16(num7), Convert.ToInt16(num8), Convert.ToInt16(num9), Convert.ToInt16(num10));
            // this.Session["Export_dt_export_toexcel"] = dataSet.Tables[0];
            return dataSet.Tables[0];
        }

        public void RunReportOnClick()
        {
            this.Session["DeleteMsg"] = null;
            this.btnRunReport.Visible = true;
            this.pnlReports.Visible = false;
            this.divtab.Visible = false;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Value.ToLower() == "itemtitle")
                {
                    this.strColumns.Append(this.chkColumns.Items[i].Value);
                }
                if (this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value != "cost" && this.chkColumns.Items[i].Value != "fromquantity" && this.chkColumns.Items[i].Value != "toquantity")
                    {
                        if (i != 0)
                        {
                            this.strColumns.Append(string.Concat(",", this.chkColumns.Items[i].Value));
                        }
                        //else
                        //{
                        //    this.strColumns.Append(this.chkColumns.Items[i].Value);
                        //}
                    }
                    else if (this.chkColumns.Items[i].Value == "fromquantity" || this.chkColumns.Items[i].Value == "toquantity")
                    {
                        this.Qtyoption = "yes";
                    }
                    else if (this.chkColumns.Items[i].Value == "cost")
                    {
                        this.IsPriceChecked = "yes";
                    }
                }
            }
            if (this.chkaggregate.SelectedIndex != -1)
            {
                if (this.chkaggregate.Items[0].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[0].Value));
                }
                if (this.chkaggregate.Items[1].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[1].Value));
                }
                if (this.chkaggregate.Items[2].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[2].Value));
                }
                if (this.chkaggregate.Items[3].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[3].Value));
                }
                if (this.chkaggregate.Items[4].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[4].Value));
                }
                if (this.chkaggregate.Items[5].Selected)
                {
                    this.strColumns.Append(string.Concat(",", this.chkaggregate.Items[5].Value));
                }
            }
            int num = 0;
            foreach (RadComboBoxItem item in this.ddlCategory.Items)
            {
                CheckBoxList checkBoxList = (CheckBoxList)item.FindControl("chkEstType");
                foreach (ListItem listItem in checkBoxList.Items)
                {
                    if (!listItem.Selected)
                    {
                        continue;
                    }
                    productcatalogue_report commonProductcatalogueReport = this;
                    commonProductcatalogueReport.CategoryName = string.Concat(commonProductcatalogueReport.CategoryName, checkBoxList.SelectedValue, ", ");
                    num++;
                }
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num1 = (!this.chkProductType.Items[0].Selected ? 0 : 1);
            num2 = (!this.chkProductType.Items[1].Selected ? 0 : 1);
            num3 = (!this.chkProductType.Items[2].Selected ? 0 : 1);
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            if (this.chkaggregate.Items[0].Selected)
            {
                num4 = 1;
            }
            if (this.chkaggregate.Items[1].Selected)
            {
                num5 = 1;
            }
            if (this.chkaggregate.Items[2].Selected)
            {
                num6 = 1;
            }
            if (this.chkaggregate.Items[3].Selected)
            {
                num7 = 1;
            }
            if (this.chkaggregate.Items[4].Selected)
            {
                num8 = 1;
            }
            if (this.chkaggregate.Items[5].Selected)
            {
                num9 = 1;
            }
            if (this.chkDrawStock.Checked)
            {
                num10 = 1;
            }
            string empty = string.Empty;
            int selectedIndex = this.chkaggregate.SelectedIndex;
            string str = "0";
            if (this.ddlCategory.SelectedValue.ToString().Trim() != "0")
            {
                foreach (RadComboBoxItem radComboBoxItem in this.ddlCategory.Items)
                {
                    foreach (ListItem item1 in ((CheckBoxList)radComboBoxItem.FindControl("chkEstType")).Items)
                    {
                        if (!item1.Selected)
                        {
                            continue;
                        }
                        str = string.Concat(str, item1.Text, ", ");
                    }
                }
            }
            DataSet dataSet = SettingsBasePage.report_pricecatalogue_select(this.CompanyID, 1000000, 1, this.ddlEstimateRange.SelectedItem.Value, this.ddldirection.SelectedItem.Value, this.strColumns.ToString(), this.Qtyoption, this.IsPriceChecked, base.SpecialEncode(this.txtFreetext.Text), this.CategoryName, base.SpecialEncode(this.txtName.Text), this.lstAccountPublic.SelectedValue, this.rdlSpecific.SelectedValue, this.ISDateChecked, this.SaveType, this.DateType, this.CompanyName, this.txtSaveReports.Text, this.txtDescription.Text, this.PageName, Convert.ToInt64(this.UserID), Convert.ToInt64(this.ReportID), this.FromDate, this.ToDate, this.createdDate, str, Convert.ToInt32(this.hid_ClientID.Value), Convert.ToInt16(num1), Convert.ToInt16(num2), Convert.ToInt16(num3), Convert.ToInt16(num4), Convert.ToInt16(num5), Convert.ToInt16(num6), Convert.ToInt16(num7), Convert.ToInt16(num8), Convert.ToInt16(num9), Convert.ToInt16(num10));
            this.GridProduct.DataSource = dataSet.Tables[0];
            this.GridProduct.DataBind();
        }

        private void usrReportsave_OnDeleteClick(int ReportID)
        {
            SqlCommand sqlCommand = new SqlCommand("PC_Reports_Delete", this.objJava.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@ReportID", ReportID);
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
            this.pnlSavedReports.Visible = true;
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnEditClick(int ReportID)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.ReportDetails(ReportID);
            this.hdn_reportID.Value = ReportID.ToString();
            this.pnlSavedReports.Visible = false;
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.div_Total.Visible = false;
            this.btnUpdateExisting.Visible = true;
            this.btnSaveRun.Visible = true;
            this.btnRunReport.Visible = false;
            this.btnSaveRun.Text = "Save as New";
            this.hdn_reportID.Value = ReportID.ToString();
            this.hdn_reportID2.Value = ReportID.ToString();
        }

        private void usrReportsave_onLinkProductRunReport(int ReportID)
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnPageIndexChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnPageSizeChanged()
        {
            this.Session["DeleteMsg"] = "SelectDeleteTab";
        }

        private void usrReportsave_OnReportClick(int ReportID)
        {
            if (ReportID == 0)
            {
                this.Session["DeleteMsg"] = "SelectDeleteTab";
                return;
            }
            this.Session["DeleteMsg"] = null;
            this.NewSaveType = "view";
            this.ReportDetails(ReportID);
            this.Run_Report();
            this.div_option.Style.Add("display", "none");
            this.divexport.Style.Add("display", "block");
            this.btnUpdateExisting.Visible = true;
            this.GridProduct.Rebind();
            this.hdn_reportID.Value = ReportID.ToString();
            this.hdn_reportID2.Value = ReportID.ToString();
        }
    }
}