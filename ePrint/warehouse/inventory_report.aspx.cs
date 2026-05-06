using ClosedXML.Excel;
using ePrint.usercontrol;
using EPRINT;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Company;
using Printcenter.UI.Inventories;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;
namespace ePrint.warehouse
{
    public partial class inventory_report : BaseClass, IRequiresSessionState
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private SettingsBasePage objSet = new SettingsBasePage();

        private InventoryBasePage obj = new InventoryBasePage();

        private commonClass objJava = new commonClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string ColumnNames = string.Empty;

        public string CompanyName = string.Empty;

        public string cs = string.Empty;

        public int CompanyID;

        public string DateFormat = string.Empty;

        public string flag = string.Empty;

        public string row_flag = string.Empty;

        public char goods_type;

        public string PropertyValue = string.Empty;

        public string colorformat = string.Empty;

        public int cell_packprice;

        public int cell_cost;

        public int cell_InStock;

        public int cell_QuantityUsed;

        public int cell_width;

        public int cell_height;

        public int cell_createddate;

        public int cell_packedin;

        public int cell_weight;

        public int cell_caliper;

        public int cell_sizeordered;

        public int cell_InventoryCode;

        public int cell_InventoryName;

        public int cell_SupplierName;

        public int cell_colour;

        public int UserID;

        public string startdate_quart = string.Empty;

        public string enddate_quart = string.Empty;

        public string[] day;

        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] from_halffiscalyear;

        public string[] to_halffiscalyear;

        public string[] stlastweek;

        public string[] enlastweek;

        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string[] startyear;

        public string[] endyear;

        public string year = string.Empty;

        public string pagename = string.Empty;

        public int PageSize = 100;

        public int totalrec;

        private int PageNumber = 1;

        public string pg = string.Empty;

        public static string divVisibility;

        public static string imgVisibility;

        public languageClass objLangClass = new languageClass();

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

        static inventory_report()
        {
            inventory_report.divVisibility = "none";
            inventory_report.imgVisibility = "block";
        }

        public inventory_report()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.pagename.ToString().ToLower().Trim() == "report")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "common/report.aspx"));
                return;
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "warehouse/warehouse.aspx?type=inventory"));
        }

        public void btnExport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.spnError.Visible = true;
                return;
            }
            DataTable item = this.GetEstimateData(0).Tables[0];
            foreach (DataRow row in item.Rows)
            {
                if (row.Table.Columns.Contains("papersizeid"))
                {
                    string str = SettingsBasePage.settings_papersizename_select(this.CompanyID, Convert.ToInt32(row["papersizeid"].ToString()));
                    if (str != null)
                    {
                        str.ToString();
                    }
                    if (str == null)
                    {
                        row["papersizeid"] = DBNull.Value;
                    }
                    else
                    {
                        row["papersizeid"] = str;
                    }
                }
                if (!row.Table.Columns.Contains("CreatedDate"))
                {
                    continue;
                }
                row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
            }
            for (int j = 0; j < item.Columns.Count; j++)
            {
                if (item.Columns[j].ColumnName == "inventorycode")
                {
                    item.Columns[j].ColumnName = "Inventory Code";
                }
                else if (item.Columns[j].ColumnName == "inventoryname")
                {
                    item.Columns[j].ColumnName = "Inventory Name";
                }
                else if (item.Columns[j].ColumnName == "suppliername")
                {
                    item.Columns[j].ColumnName = "Supplier Name";
                }
                else if (item.Columns[j].ColumnName == "cost")
                {
                    item.Columns[j].ColumnName = string.Concat("Cost (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                }
                else if (item.Columns[j].ColumnName == "InStock")
                {
                    item.Columns[j].ColumnName = "In Stock Qty";
                }
                else if (item.Columns[j].ColumnName == "QuantityUsed")
                {
                    item.Columns[j].ColumnName = "Quantity Used";
                }
                else if (item.Columns[j].ColumnName == "packedin")
                {
                    item.Columns[j].ColumnName = "Packed In";
                }
                else if (item.Columns[j].ColumnName == "packedprice")
                {
                    item.Columns[j].ColumnName = string.Concat("Pack Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                }
                else if (item.Columns[j].ColumnName == "CreatedDate")
                {
                    item.Columns[j].ColumnName = "Created On";
                }
                else if (item.Columns[j].ColumnName == "basisweight")
                {
                    item.Columns[j].ColumnName = "Weight";
                }
                else if (item.Columns[j].ColumnName == "coated")
                {
                    item.Columns[j].ColumnName = "Coating Type";
                }
                else if (item.Columns[j].ColumnName == "colour")
                {
                    item.Columns[j].ColumnName = this.objpage.GetRegionalSettings(Convert.ToInt32(this.Session["companyid"].ToString()), "colour");
                }
                else if (item.Columns[j].ColumnName == "papersizeid")
                {
                    item.Columns[j].ColumnName = "Size Ordered";
                }
                else if (item.Columns[j].ColumnName == "Caliper")
                {
                    item.Columns[j].ColumnName = "Caliper";
                }
                else if (item.Columns[j].ColumnName == "height")
                {
                    item.Columns[j].ColumnName = "Height";
                }
                else if (item.Columns[j].ColumnName == "width")
                {
                    item.Columns[j].ColumnName = "Width";
                }
            }
            if (item.Columns.Contains("InventoryID"))
            {
                try
                {
                    item.Columns.Remove("InventoryID");
                }
                catch
                {
                }
            }
            item.AcceptChanges();
            item.AcceptChanges();
            DataSet ds = new DataSet();
            DataTable dtCopy1 = item.Copy();
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
                Response.AddHeader("content-disposition", "attachment;filename=Inventoryreport_Excel.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

            //(new WebExport()).Export_with_XSLT_Web(item, "Inventoryreport_Excel.xls");
        }

        protected void btnfilter_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            if (this.Session["SaveAsNew"] != null)
            {
                this.btnSaveRun.Text = "Save and Run";
            }
            else
            {
                this.btnSaveRun.Text = "Save as New";
            }
            inventory_report.imgVisibility = "block";
            inventory_report.divVisibility = "none";
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetSelect();", true);
        }

        public void btngo_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            try
            {
                this.paging_OnPageChange(Convert.ToInt32(this.txt1.Text));
            }
            catch
            {
                this.paging_OnPageChange(Convert.ToInt32("1"));
            }
        }

        public void btnRunReport_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.btnUpdateExisting.Visible = false;
            this.btnRunReport.Visible = true;
            this.btnSaveRun.Text = "Save and Run";
            this.txt1.Text = "";
            int num = 0;
            inventory_report.imgVisibility = "none";
            inventory_report.divVisibility = "none";
            this.divtab.Visible = false;
            this.btnfilter.Visible = true;
            if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("inventory", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.divtoolbar.Visible = true;
            this.txt1.Visible = true;
            this.btngo.Visible = true;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.divtoolbar.Visible = true;
                return;
            }
            DataSet estimateData = this.GetEstimateData(1);
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
            {
                this.GridEstReport.Visible = true;
                this.div_Total.Visible = true;
                this.pnlEmptyRecords.Visible = false;
                this.GridEstReport.DataSource = estimateData;
                this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                this.GridEstReport.DataBind();
                this.usrPaging.Visible = true;
                pagingreport.intCurrentPage = this.PageNumber;
                pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                this.usrPaging.CreatePaging();
                this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                this.CallPagingBtn_ScrollGrid(this.usrPaging);
                return;
            }
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = true;
            this.pnlEmptyRecords.Visible = false;
            this.GridEstReport.DataSource = estimateData;
            this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            this.usrPaging.Visible = true;
            pagingreport.intCurrentPage = this.PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        public void btnSaveRun_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.SaveReports("Save");
            this.RunReportOnClick();
        }

        public void btnUpdateExisting_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.Session["SaveAsNew"] = "SaveAsNew";
            if (this.hdn_reportID.Value == "")
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("PC_GetReportID", this.objJava.openConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CompanyID", this.CompanyID);
                sqlCommand.Parameters.AddWithValue("@UserID", this.UserID);
                sqlCommand.Parameters.AddWithValue("@Pagename", "warehouse");
                (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
                this.objJava.closeConnection();
                foreach (DataRow row in dataTable.Rows)
                {
                    this.hdn_reportID.Value = row["ReportID"].ToString();
                }
            }
            this.SaveReports("Update");
            this.RunReportOnClick();
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            LinkButton linkButton = (LinkButton)usrPagingID.FindControl("lnkFirst");
            linkButton.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton1 = (LinkButton)usrPagingID.FindControl("lnkSecond");
            linkButton1.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton2 = (LinkButton)usrPagingID.FindControl("lnkThird");
            linkButton2.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton3 = (LinkButton)usrPagingID.FindControl("lnkFour");
            linkButton3.OnClientClick = "javascript:CheckGrid();";
            LinkButton linkButton4 = (LinkButton)usrPagingID.FindControl("lnkFive");
            linkButton4.OnClientClick = "javascript:CheckGrid();";
            if (this.txt1.Text == linkButton.Text)
            {
                linkButton.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton1.Text)
            {
                linkButton1.Font.Bold = true;
                linkButton.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton2.Text)
            {
                linkButton2.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton3.Text)
            {
                linkButton3.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton.Font.Bold = false;
                linkButton4.Font.Bold = false;
            }
            else if (this.txt1.Text == linkButton4.Text)
            {
                linkButton4.Font.Bold = true;
                linkButton1.Font.Bold = false;
                linkButton2.Font.Bold = false;
                linkButton3.Font.Bold = false;
                linkButton.Font.Bold = false;
            }
            LinkButton linkButton5 = (LinkButton)usrPagingID.FindControl("lnkstart");
            LinkButton linkButton6 = (LinkButton)usrPagingID.FindControl("lnkPrev");
            LinkButton linkButton7 = (LinkButton)usrPagingID.FindControl("lnkNext");
            LinkButton linkButton8 = (LinkButton)usrPagingID.FindControl("lnkEnd");
            if (this.txt1.Text != "")
            {
                if (Convert.ToInt16(this.txt1.Text) >= 4)
                {
                    linkButton5.Enabled = true;
                    linkButton6.Enabled = true;
                }
                if (Convert.ToInt16(this.txt1.Text) >= 1)
                {
                    linkButton.Enabled = true;
                }
            }
            if (this.GridEstReport.PageIndex == 1 || this.GridEstReport.PageIndex == 0)
            {
                linkButton5.Enabled = false;
                linkButton6.Enabled = false;
            }
            if (linkButton5.Enabled)
            {
                linkButton5.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton5.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton6.Enabled)
            {
                linkButton6.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton6.OnClientClick = "javascript:Disablelnk();";
            }
            if (linkButton7.Enabled)
            {
                linkButton7.OnClientClick = "javascript:showWaitMessage();";
            }
            else
            {
                linkButton7.OnClientClick = "javascript:Disablelnk();";
            }
            if (!linkButton8.Enabled)
            {
                linkButton8.OnClientClick = "javascript:Disablelnk();";
                return;
            }
            linkButton8.OnClientClick = "javascript:showWaitMessage();";
        }

        public string CurrentFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            string str = string.Concat(dateTime.ToString(), ",", dateTime1.ToString());
            return str;
        }

        public string CurrentMonth()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime[] dateTimeArray = new DateTime[] { new DateTime(dateTime.Year, dateTime.Month, 1), default(DateTime) };
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = dateTime1.AddMonths(1);
            dateTimeArray[1] = dateTime2.AddDays(-1);
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string CurrentQuater()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            DateTime dateTime1 = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime1.Month;
            int num = dateTime.Month;
            DateTime dateTime2 = new DateTime();
            dateTime2 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int month1 = dateTime2.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (month1 == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int num1 = dateTime1.Month;
                    if (num1 == 1)
                    {
                        int num2 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num2, DateTime.DaysInMonth(dateTime1.Year, num2));
                    }
                    else if (num1 == 2)
                    {
                        num1--;
                        int num3 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num3, DateTime.DaysInMonth(dateTime1.Year, num3));
                    }
                    else if (num1 == 3)
                    {
                        num1 = num1 - 2;
                        int num4 = num1 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, num1, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num4, DateTime.DaysInMonth(dateTime1.Year, num4));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime1.Month;
                    if (month2 == 4)
                    {
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num5, DateTime.DaysInMonth(dateTime1.Year, num5));
                    }
                    else if (month2 == 5)
                    {
                        month2--;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num6, DateTime.DaysInMonth(dateTime1.Year, num6));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 2;
                        int num7 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num7, DateTime.DaysInMonth(dateTime1.Year, num7));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime1.Month;
                    if (month3 == 7)
                    {
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num8, DateTime.DaysInMonth(dateTime1.Year, num8));
                    }
                    else if (month3 == 8)
                    {
                        month3--;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num9, DateTime.DaysInMonth(dateTime1.Year, num9));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 2;
                        int num10 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num10, DateTime.DaysInMonth(dateTime1.Year, num10));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime1.Month;
                    if (month4 == 10)
                    {
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num11, DateTime.DaysInMonth(dateTime1.Year, num11));
                    }
                    if (month4 == 11)
                    {
                        month4--;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num12, DateTime.DaysInMonth(dateTime1.Year, num12));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 2;
                        int num13 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num13, DateTime.DaysInMonth(dateTime1.Year, num13));
                    }
                }
            }
            if (month1 == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime1.Month;
                    if (month5 == 2)
                    {
                        int num14 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num14, DateTime.DaysInMonth(dateTime1.Year, num14));
                    }
                    else if (month5 == 3)
                    {
                        month5--;
                        int num15 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num15, DateTime.DaysInMonth(dateTime1.Year, num15));
                    }
                    else if (month5 == 4)
                    {
                        month5 = month5 - 2;
                        int num16 = month5 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num16, DateTime.DaysInMonth(dateTime1.Year, num16));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime1.Month;
                    if (month6 == 5)
                    {
                        int num17 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num17, DateTime.DaysInMonth(dateTime1.Year, num17));
                    }
                    else if (month6 == 6)
                    {
                        month6--;
                        int num18 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num18, DateTime.DaysInMonth(dateTime1.Year, num18));
                    }
                    else if (month6 == 7)
                    {
                        month6 = month6 - 2;
                        int num19 = month6 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num19, DateTime.DaysInMonth(dateTime1.Year, num19));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime1.Month;
                    if (month7 == 8)
                    {
                        int num20 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num20, DateTime.DaysInMonth(dateTime1.Year, num20));
                    }
                    else if (month7 == 9)
                    {
                        month7--;
                        int num21 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num21, DateTime.DaysInMonth(dateTime1.Year, num21));
                    }
                    else if (month7 == 10)
                    {
                        month7 = month7 - 2;
                        int num22 = month7 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num22, DateTime.DaysInMonth(dateTime1.Year, num22));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime1.Month;
                    if (month8 == 11)
                    {
                        int num23 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num23, DateTime.DaysInMonth(dateTime1.Year, num23));
                    }
                    if (month8 == 12)
                    {
                        month8--;
                        int num24 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num24, DateTime.DaysInMonth(dateTime1.Year, num24));
                    }
                    else if (month8 == 1)
                    {
                        month8 = month8 + 10;
                        int num25 = month8 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num25, DateTime.DaysInMonth(dateTime1.Year, num25));
                    }
                }
            }
            if (month1 == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime1.Month;
                    if (month9 == 3)
                    {
                        int num26 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num26, DateTime.DaysInMonth(dateTime1.Year, num26));
                    }
                    else if (month9 == 4)
                    {
                        month9--;
                        int num27 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num27, DateTime.DaysInMonth(dateTime1.Year, num27));
                    }
                    else if (month9 == 5)
                    {
                        month9 = month9 - 2;
                        int num28 = month9 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num28, DateTime.DaysInMonth(dateTime1.Year, num28));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime1.Month;
                    if (month10 == 6)
                    {
                        int num29 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num29, DateTime.DaysInMonth(dateTime1.Year, num29));
                    }
                    else if (month10 == 7)
                    {
                        month10--;
                        int num30 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num30, DateTime.DaysInMonth(dateTime1.Year, num30));
                    }
                    else if (month10 == 8)
                    {
                        month10 = month10 - 2;
                        int num31 = month10 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num31, DateTime.DaysInMonth(dateTime1.Year, num31));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime1.Month;
                    if (month11 == 9)
                    {
                        int num32 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num32, DateTime.DaysInMonth(dateTime1.Year, num32));
                    }
                    else if (month11 == 10)
                    {
                        month11--;
                        int num33 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num33, DateTime.DaysInMonth(dateTime1.Year, num33));
                    }
                    else if (month11 == 11)
                    {
                        month11 = month11 - 2;
                        int num34 = month11 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num34, DateTime.DaysInMonth(dateTime1.Year, num34));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime1.Month;
                    if (month12 == 12)
                    {
                        int num35 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num35, DateTime.DaysInMonth(dateTime1.Year, num35));
                    }
                    if (month12 == 1)
                    {
                        month12 = month12 + 11;
                        int num36 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num36, DateTime.DaysInMonth(dateTime1.Year, num36));
                    }
                    else if (month12 == 2)
                    {
                        month12 = month12 + 10;
                        int num37 = month12 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num37, DateTime.DaysInMonth(dateTime1.Year, num37));
                    }
                }
            }
            if (month1 == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime1.Month;
                    if (month13 == 4)
                    {
                        int num38 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num38, DateTime.DaysInMonth(dateTime1.Year, num38));
                    }
                    else if (month13 == 5)
                    {
                        month13--;
                        int num39 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num39, DateTime.DaysInMonth(dateTime1.Year, num39));
                    }
                    else if (month13 == 6)
                    {
                        month13 = month13 - 2;
                        int num40 = month13 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num40, DateTime.DaysInMonth(dateTime1.Year, num40));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime1.Month;
                    if (month14 == 7)
                    {
                        int num41 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num41, DateTime.DaysInMonth(dateTime1.Year, num41));
                    }
                    else if (month14 == 8)
                    {
                        month14--;
                        int num42 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num42, DateTime.DaysInMonth(dateTime1.Year, num42));
                    }
                    else if (month14 == 9)
                    {
                        month14 = month14 - 2;
                        int num43 = month14 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num43, DateTime.DaysInMonth(dateTime1.Year, num43));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime1.Month;
                    if (month15 == 10)
                    {
                        int num44 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num44, DateTime.DaysInMonth(dateTime1.Year, num44));
                    }
                    else if (month15 == 11)
                    {
                        month15--;
                        int num45 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num45, DateTime.DaysInMonth(dateTime1.Year, num45));
                    }
                    else if (month15 == 12)
                    {
                        month15 = month15 - 2;
                        int num46 = month15 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num46, DateTime.DaysInMonth(dateTime1.Year, num46));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime1.Month;
                    if (month16 == 1)
                    {
                        int num47 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num47, DateTime.DaysInMonth(dateTime1.Year, num47));
                    }
                    if (month16 == 2)
                    {
                        month16--;
                        int num48 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num48, DateTime.DaysInMonth(dateTime1.Year, num48));
                    }
                    else if (month16 == 3)
                    {
                        month16 = month16 - 2;
                        int num49 = month16 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num49, DateTime.DaysInMonth(dateTime1.Year, num49));
                    }
                }
            }
            if (month1 == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime1.Month;
                    if (month17 == 5)
                    {
                        int num50 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num50, DateTime.DaysInMonth(dateTime1.Year, num50));
                    }
                    else if (month17 == 6)
                    {
                        month17--;
                        int num51 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num51, DateTime.DaysInMonth(dateTime1.Year, num51));
                    }
                    else if (month17 == 7)
                    {
                        month17 = month17 - 2;
                        int num52 = month17 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num52, DateTime.DaysInMonth(dateTime1.Year, num52));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime1.Month;
                    if (month18 == 8)
                    {
                        int num53 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num53, DateTime.DaysInMonth(dateTime1.Year, num53));
                    }
                    else if (month18 == 9)
                    {
                        month18--;
                        int num54 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num54, DateTime.DaysInMonth(dateTime1.Year, num54));
                    }
                    else if (month18 == 10)
                    {
                        month18 = month18 - 2;
                        int num55 = month18 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num55, DateTime.DaysInMonth(dateTime1.Year, num55));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime1.Month;
                    if (month19 == 11)
                    {
                        int num56 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num56, DateTime.DaysInMonth(dateTime1.Year, num56));
                    }
                    else if (month19 == 12)
                    {
                        month19--;
                        int num57 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num57, DateTime.DaysInMonth(dateTime1.Year, num57));
                    }
                    else if (month19 == 1)
                    {
                        month19 = month19 + 10;
                        int num58 = month19 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num58, DateTime.DaysInMonth(dateTime1.Year, num58));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime1.Month;
                    if (month20 == 2)
                    {
                        int num59 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num59, DateTime.DaysInMonth(dateTime1.Year, num59));
                    }
                    if (month20 == 3)
                    {
                        month20--;
                        int num60 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num60, DateTime.DaysInMonth(dateTime1.Year, num60));
                    }
                    else if (month20 == 4)
                    {
                        month20 = month20 - 2;
                        int num61 = month20 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num61, DateTime.DaysInMonth(dateTime1.Year, num61));
                    }
                }
            }
            if (month1 == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime1.Month;
                    if (month21 == 6)
                    {
                        int num62 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num62, DateTime.DaysInMonth(dateTime1.Year, num62));
                    }
                    else if (month21 == 7)
                    {
                        month21--;
                        int num63 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num63, DateTime.DaysInMonth(dateTime1.Year, num63));
                    }
                    else if (month21 == 8)
                    {
                        month21 = month21 - 2;
                        int num64 = month21 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num64, DateTime.DaysInMonth(dateTime1.Year, num64));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime1.Month;
                    if (month22 == 9)
                    {
                        int num65 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num65, DateTime.DaysInMonth(dateTime1.Year, num65));
                    }
                    else if (month22 == 10)
                    {
                        month22--;
                        int num66 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num66, DateTime.DaysInMonth(dateTime1.Year, num66));
                    }
                    else if (month22 == 11)
                    {
                        month22 = month22 - 2;
                        int num67 = month22 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num67, DateTime.DaysInMonth(dateTime1.Year, num67));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime1.Month;
                    if (month23 == 12)
                    {
                        int num68 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num68, DateTime.DaysInMonth(dateTime1.Year, num68));
                    }
                    else if (month23 == 1)
                    {
                        month23 = month23 + 11;
                        int num69 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num69, DateTime.DaysInMonth(dateTime1.Year, num69));
                    }
                    else if (month23 == 2)
                    {
                        month23 = month23 + 10;
                        int num70 = month23 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num70, DateTime.DaysInMonth(dateTime1.Year, num70));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime1.Month;
                    if (month24 == 3)
                    {
                        int num71 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num71, DateTime.DaysInMonth(dateTime1.Year, num71));
                    }
                    if (month24 == 4)
                    {
                        month24--;
                        int num72 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num72, DateTime.DaysInMonth(dateTime1.Year, num72));
                    }
                    else if (month24 == 5)
                    {
                        month24 = month24 - 2;
                        int num73 = month24 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num73, DateTime.DaysInMonth(dateTime1.Year, num73));
                    }
                }
            }
            if (month1 == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime1.Month;
                    if (month25 == 7)
                    {
                        int num74 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num74, DateTime.DaysInMonth(dateTime1.Year, num74));
                    }
                    else if (month25 == 8)
                    {
                        month25--;
                        int num75 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num75, DateTime.DaysInMonth(dateTime1.Year, num75));
                    }
                    else if (month25 == 9)
                    {
                        month25 = month25 - 2;
                        int num76 = month25 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num76, DateTime.DaysInMonth(dateTime1.Year, num76));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime1.Month;
                    if (month26 == 10)
                    {
                        int num77 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num77, DateTime.DaysInMonth(dateTime1.Year, num77));
                    }
                    else if (month26 == 11)
                    {
                        month26--;
                        int num78 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num78, DateTime.DaysInMonth(dateTime1.Year, num78));
                    }
                    else if (month26 == 12)
                    {
                        month26 = month26 - 2;
                        int num79 = month26 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num79, DateTime.DaysInMonth(dateTime1.Year, num79));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime1.Month;
                    if (month27 == 1)
                    {
                        int num80 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num80, DateTime.DaysInMonth(dateTime1.Year, num80));
                    }
                    else if (month27 == 2)
                    {
                        month27--;
                        int num81 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num81, DateTime.DaysInMonth(dateTime1.Year, num81));
                    }
                    else if (month27 == 3)
                    {
                        month27 = month27 - 2;
                        int num82 = month27 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num82, DateTime.DaysInMonth(dateTime1.Year, num82));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime1.Month;
                    if (month28 == 4)
                    {
                        int num83 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num83, DateTime.DaysInMonth(dateTime1.Year, num83));
                    }
                    if (month28 == 5)
                    {
                        month28--;
                        int num84 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num84, DateTime.DaysInMonth(dateTime1.Year, num84));
                    }
                    else if (month28 == 6)
                    {
                        month28 = month28 - 2;
                        int num85 = month28 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num85, DateTime.DaysInMonth(dateTime1.Year, num85));
                    }
                }
            }
            if (month1 == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime1.Month;
                    if (month29 == 8)
                    {
                        int num86 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num86, DateTime.DaysInMonth(dateTime1.Year, num86));
                    }
                    else if (month29 == 9)
                    {
                        month29--;
                        int num87 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num87, DateTime.DaysInMonth(dateTime1.Year, num87));
                    }
                    else if (month29 == 10)
                    {
                        month29 = month29 - 2;
                        int num88 = month29 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num88, DateTime.DaysInMonth(dateTime1.Year, num88));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime1.Month;
                    if (month30 == 11)
                    {
                        int num89 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num89, DateTime.DaysInMonth(dateTime1.Year, num89));
                    }
                    else if (month30 == 12)
                    {
                        month30--;
                        int num90 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num90, DateTime.DaysInMonth(dateTime1.Year, num90));
                    }
                    else if (month30 == 1)
                    {
                        month30 = month30 + 10;
                        int num91 = month30 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num91, DateTime.DaysInMonth(dateTime1.Year, num91));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime1.Month;
                    if (month31 == 2)
                    {
                        int num92 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num92, DateTime.DaysInMonth(dateTime1.Year, num92));
                    }
                    else if (month31 == 3)
                    {
                        month31--;
                        int num93 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num93, DateTime.DaysInMonth(dateTime1.Year, num93));
                    }
                    else if (month31 == 4)
                    {
                        month31 = month31 - 2;
                        int num94 = month31 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num94, DateTime.DaysInMonth(dateTime1.Year, num94));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime1.Month;
                    if (month32 == 5)
                    {
                        int num95 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num95, DateTime.DaysInMonth(dateTime1.Year, num95));
                    }
                    if (month32 == 6)
                    {
                        month32--;
                        int num96 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num96, DateTime.DaysInMonth(dateTime1.Year, num96));
                    }
                    else if (month32 == 7)
                    {
                        month32 = month32 - 2;
                        int num97 = month32 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num97, DateTime.DaysInMonth(dateTime1.Year, num97));
                    }
                }
            }
            if (month1 == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime1.Month;
                    if (month33 == 9)
                    {
                        int num98 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num98, DateTime.DaysInMonth(dateTime1.Year, num98));
                    }
                    else if (month33 == 10)
                    {
                        month33--;
                        int num99 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num99, DateTime.DaysInMonth(dateTime1.Year, num99));
                    }
                    else if (month33 == 11)
                    {
                        month33 = month33 - 2;
                        int num100 = month33 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num100, DateTime.DaysInMonth(dateTime1.Year, num100));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime1.Month;
                    if (month34 == 12)
                    {
                        int num101 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num101, DateTime.DaysInMonth(dateTime1.Year, num101));
                    }
                    else if (month34 == 1)
                    {
                        month34 = month34 + 11;
                        int num102 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num102, DateTime.DaysInMonth(dateTime1.Year, num102));
                    }
                    else if (month34 == 2)
                    {
                        month34 = month34 + 10;
                        int num103 = month34 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num103, DateTime.DaysInMonth(dateTime1.Year, num103));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime1.Month;
                    if (month35 == 3)
                    {
                        int num104 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num104, DateTime.DaysInMonth(dateTime1.Year, num104));
                    }
                    else if (month35 == 4)
                    {
                        month35--;
                        int num105 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num105, DateTime.DaysInMonth(dateTime1.Year, num105));
                    }
                    else if (month35 == 5)
                    {
                        month35 = month35 - 2;
                        int num106 = month35 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num106, DateTime.DaysInMonth(dateTime1.Year, num106));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime1.Month;
                    if (month36 == 6)
                    {
                        int num107 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num107, DateTime.DaysInMonth(dateTime1.Year, num107));
                    }
                    if (month36 == 7)
                    {
                        month36--;
                        int num108 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num108, DateTime.DaysInMonth(dateTime1.Year, num108));
                    }
                    else if (month36 == 8)
                    {
                        month36 = month36 - 2;
                        int num109 = month36 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num109, DateTime.DaysInMonth(dateTime1.Year, num109));
                    }
                }
            }
            if (month1 == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime1.Month;
                    if (month37 == 10)
                    {
                        int num110 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num110, DateTime.DaysInMonth(dateTime1.Year, num110));
                    }
                    else if (month37 == 11)
                    {
                        month37--;
                        int num111 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num111, DateTime.DaysInMonth(dateTime1.Year, num111));
                    }
                    else if (month37 == 12)
                    {
                        month37 = month37 - 2;
                        int num112 = month37 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num112, DateTime.DaysInMonth(dateTime1.Year, num112));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime1.Month;
                    if (month38 == 1)
                    {
                        int num113 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num113, DateTime.DaysInMonth(dateTime1.Year, num113));
                    }
                    else if (month38 == 2)
                    {
                        month38--;
                        int num114 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num114, DateTime.DaysInMonth(dateTime1.Year, num114));
                    }
                    else if (month38 == 3)
                    {
                        month38 = month38 - 2;
                        int num115 = month38 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num115, DateTime.DaysInMonth(dateTime1.Year, num115));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime1.Month;
                    if (month39 == 4)
                    {
                        int num116 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num116, DateTime.DaysInMonth(dateTime1.Year, num116));
                    }
                    else if (month39 == 5)
                    {
                        month39--;
                        int num117 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num117, DateTime.DaysInMonth(dateTime1.Year, num117));
                    }
                    else if (month39 == 6)
                    {
                        month39 = month39 - 2;
                        int num118 = month39 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num118, DateTime.DaysInMonth(dateTime1.Year, num118));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime1.Month;
                    if (month40 == 7)
                    {
                        int num119 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num119, DateTime.DaysInMonth(dateTime1.Year, num119));
                    }
                    if (month40 == 8)
                    {
                        month40--;
                        int num120 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num120, DateTime.DaysInMonth(dateTime1.Year, num120));
                    }
                    else if (month40 == 9)
                    {
                        month40 = month40 - 2;
                        int num121 = month40 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num121, DateTime.DaysInMonth(dateTime1.Year, num121));
                    }
                }
            }
            if (month1 == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime1.Month;
                    if (month41 == 11)
                    {
                        int num122 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num122, DateTime.DaysInMonth(dateTime1.Year, num122));
                    }
                    else if (month41 == 12)
                    {
                        month41--;
                        int num123 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num123, DateTime.DaysInMonth(dateTime1.Year, num123));
                    }
                    else if (month41 == 1)
                    {
                        month41 = month41 + 10;
                        int num124 = month41 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num124, DateTime.DaysInMonth(dateTime1.Year, num124));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime1.Month;
                    if (month42 == 2)
                    {
                        int num125 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num125, DateTime.DaysInMonth(dateTime1.Year, num125));
                    }
                    else if (month42 == 3)
                    {
                        month42--;
                        int num126 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num126, DateTime.DaysInMonth(dateTime1.Year, num126));
                    }
                    else if (month42 == 4)
                    {
                        month42 = month42 - 2;
                        int num127 = month42 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num127, DateTime.DaysInMonth(dateTime1.Year, num127));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime1.Month;
                    if (month43 == 5)
                    {
                        int num128 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num128, DateTime.DaysInMonth(dateTime1.Year, num128));
                    }
                    else if (month43 == 6)
                    {
                        month43--;
                        int num129 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num129, DateTime.DaysInMonth(dateTime1.Year, num129));
                    }
                    else if (month43 == 7)
                    {
                        month43 = month43 - 2;
                        int num130 = month43 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num130, DateTime.DaysInMonth(dateTime1.Year, num130));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime1.Month;
                    if (month44 == 8)
                    {
                        int num131 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num131, DateTime.DaysInMonth(dateTime1.Year, num131));
                    }
                    if (month44 == 9)
                    {
                        month44--;
                        int num132 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num132, DateTime.DaysInMonth(dateTime1.Year, num132));
                    }
                    else if (month44 == 10)
                    {
                        month44 = month44 - 2;
                        int num133 = month44 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num133, DateTime.DaysInMonth(dateTime1.Year, num133));
                    }
                }
            }
            if (month1 == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime1.Month;
                    if (month45 == 12)
                    {
                        int num134 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num134, DateTime.DaysInMonth(dateTime1.Year, num134));
                    }
                    else if (month45 == 1)
                    {
                        month45 = month45 + 11;
                        int num135 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num135, DateTime.DaysInMonth(dateTime1.Year, num135));
                    }
                    else if (month45 == 2)
                    {
                        month45 = month45 + 10;
                        int num136 = month45 - 10;
                        dateTimeArray[0] = new DateTime(dateTime1.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num136, DateTime.DaysInMonth(dateTime1.Year, num136));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime1.Month;
                    if (month46 == 3)
                    {
                        int num137 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num137, DateTime.DaysInMonth(dateTime1.Year, num137));
                    }
                    else if (month46 == 4)
                    {
                        month46--;
                        int num138 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num138, DateTime.DaysInMonth(dateTime1.Year, num138));
                    }
                    else if (month46 == 5)
                    {
                        month46 = month46 - 2;
                        int num139 = month46 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num139, DateTime.DaysInMonth(dateTime1.Year, num139));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime1.Month;
                    if (month47 == 6)
                    {
                        int num140 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num140, DateTime.DaysInMonth(dateTime1.Year, num140));
                    }
                    else if (month47 == 7)
                    {
                        month47--;
                        int num141 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num141, DateTime.DaysInMonth(dateTime1.Year, num141));
                    }
                    else if (month47 == 8)
                    {
                        month47 = month47 - 2;
                        int num142 = month47 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num142, DateTime.DaysInMonth(dateTime1.Year, num142));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime1.Month;
                    if (month48 == 9)
                    {
                        int num143 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num143, DateTime.DaysInMonth(dateTime1.Year, num143));
                    }
                    if (month48 == 10)
                    {
                        month48--;
                        int num144 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num144, DateTime.DaysInMonth(dateTime1.Year, num144));
                    }
                    else if (month48 == 11)
                    {
                        month48 = month48 - 2;
                        int num145 = month48 + 2;
                        dateTimeArray[0] = new DateTime(dateTime1.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime1.Year, num145, DateTime.DaysInMonth(dateTime1.Year, num145));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        protected void ddlInvCategory_databound(object sender, EventArgs e)
        {
            DataTable dataTable = this.obj.settings_inventoryproperties_name_select_by_categoryID(this.CompanyID, Convert.ToInt32(this.ddlInvCategory.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                this.PropertyValue = row["Properties"].ToString();
                string[] strArrays = new string[] { "^" };
                string[] strArrays1 = this.PropertyValue.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    if (strArrays1[i].ToString().ToLower() == "weight")
                    {
                        this.chkColumns.Items[8].Enabled = true;
                    }
                    if (strArrays1[i].ToString().ToLower() == "coated")
                    {
                        this.chkColumns.Items[9].Enabled = true;
                    }
                    if (strArrays1[i].ToString().ToLower() == "color")
                    {
                        this.chkColumns.Items[10].Enabled = true;
                    }
                    if (strArrays1[i].ToString().ToLower() == "papersize")
                    {
                        this.chkColumns.Items[11].Enabled = true;
                    }
                    if (strArrays1[i].ToString().ToLower() == "itemcustomsize")
                    {
                        this.chkColumns.Items[12].Enabled = true;
                    }
                    if (strArrays1[i].ToString().ToLower() == "caliper")
                    {
                        this.chkColumns.Items[13].Enabled = true;
                    }
                }
            }
        }

        protected void ddlInvCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            for (int i = 1; i < this.chkColumns.Items.Count; i++)
            {
                this.chkColumns.Items[i].Selected = false;
                if(this.ddlInvCategory.SelectedValue != "0")
                {
                    if (i > 7)
                    {
                        this.chkColumns.Items[i].Selected = false;
                        this.chkColumns.Items[i].Enabled = false;
                    }
                }
                else
                {
                    this.chkColumns.Items[8].Enabled = true;
                    this.chkColumns.Items[9].Enabled = true;
                    this.chkColumns.Items[11].Enabled = true;
                    this.chkColumns.Items[13].Enabled = true;
                    this.chkColumns.Items[14].Enabled = true;

                }
            }
            DataTable dataTable = this.obj.settings_inventoryproperties_name_select_by_categoryID(this.CompanyID, Convert.ToInt32(this.ddlInvCategory.SelectedValue));
            foreach (DataRow row in dataTable.Rows)
            {
                this.PropertyValue = row["Properties"].ToString();
                string[] strArrays = new string[] { "^" };
                string[] strArrays1 = this.PropertyValue.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    if (strArrays1[j].ToString().ToLower() == "weight")
                    {
                        this.chkColumns.Items[8].Enabled = true;
                    }
                    if (strArrays1[j].ToString().ToLower() == "coated")
                    {
                        this.chkColumns.Items[9].Enabled = true;
                    }
                    if (strArrays1[j].ToString().ToLower() == "color")
                    {
                        this.chkColumns.Items[10].Enabled = true;
                    }
                    if (strArrays1[j].ToString().ToLower() == "papersize")
                    {
                        this.chkColumns.Items[11].Enabled = true;
                    }
                    if (strArrays1[j].ToString().ToLower() == "itemcustomsize")
                    {
                        this.chkColumns.Items[12].Enabled = true;
                    }
                    if (strArrays1[j].ToString().ToLower() == "caliper")
                    {
                        this.chkColumns.Items[14].Enabled = true;
                    }
                }
            }
        }

        private void dgGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                for (int i = 0; i < e.Item.Controls.Count; i++)
                {
                    e.Item.Cells[i].Wrap = false;
                    e.Item.Cells[i].Style.Add("border-bottom", "1px solid #BE1333");
                    if (e.Item.Cells[i].Text.ToLower() == "inventorycode")
                    {
                        e.Item.Cells[i].Text = "Inventory Code";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "inventoryname")
                    {
                        e.Item.Cells[i].Text = "Inventory Name";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "suppliername")
                    {
                        e.Item.Cells[i].Text = "Supplier Name";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "coated")
                    {
                        e.Item.Cells[i].Text = "Coating Type";
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "colour")
                    {
                        e.Item.Cells[i].Text = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "papersizeid")
                    {
                        e.Item.Cells[i].Text = "Size Ordered";
                        this.cell_sizeordered = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "basisweight")
                    {
                        e.Item.Cells[i].Text = "Weight";
                        e.Item.Cells[i].Text = "Weight";
                        e.Item.Cells[i].Text = "Weight";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_weight = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "packedin")
                    {
                        e.Item.Cells[i].Text = "Packed In";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_packedin = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "cost")
                    {
                        e.Item.Cells[i].Text = string.Concat("Cost (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_cost = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "instock")
                    {
                        e.Item.Cells[i].Text = "In Stock Qty";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_InStock = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "quantityused")
                    {
                        e.Item.Cells[i].Text = "Quantity Used";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_QuantityUsed = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Item.Cells[i].Text = "Created On";
                        e.Item.Cells[i].Attributes.Add("align", "center");
                        this.cell_createddate = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "packedprice")
                    {
                        e.Item.Cells[i].Text = string.Concat("Pack Price (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_packprice = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "height")
                    {
                        e.Item.Cells[i].Text = "Height";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_height = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "width")
                    {
                        e.Item.Cells[i].Text = "Width";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_width = i;
                    }
                    if (e.Item.Cells[i].Text.ToLower() == "caliper")
                    {
                        e.Item.Cells[i].Text = "Caliper";
                        e.Item.Cells[i].Attributes.Add("align", "right");
                        this.cell_caliper = i;
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
                }
                if (this.cell_packedin != 0)
                {
                    e.Item.Cells[this.cell_packedin].Attributes.Add("align", "right");
                }
                if (this.cell_cost != 0)
                {
                    e.Item.Cells[this.cell_cost].Attributes.Add("align", "right");
                }
                if (this.cell_InStock != 0)
                {
                    e.Item.Cells[this.cell_InStock].Attributes.Add("align", "right");
                }
                if (this.cell_height != 0)
                {
                    e.Item.Cells[this.cell_height].Attributes.Add("align", "right");
                }
                if (this.cell_width != 0)
                {
                    e.Item.Cells[this.cell_width].Attributes.Add("align", "right");
                }
                if (this.cell_packprice != 0)
                {
                    e.Item.Cells[this.cell_packprice].Attributes.Add("align", "right");
                }
                if (this.cell_weight != 0)
                {
                    e.Item.Cells[this.cell_weight].Attributes.Add("align", "right");
                }
                if (this.cell_createddate != 0)
                {
                    e.Item.Cells[this.cell_createddate].Attributes.Add("align", "center");
                }
                if (this.cell_sizeordered != 0)
                {
                    e.Item.Cells[this.cell_sizeordered].Text = SettingsBasePage.settings_papersizename_select(this.CompanyID, Convert.ToInt32(e.Item.Cells[this.cell_sizeordered].Text));
                }
                if (this.cell_caliper != 0)
                {
                    e.Item.Cells[this.cell_caliper].Attributes.Add("align", "right");
                }
            }
        }

        private DataSet GetEstimateData(int PageNumber)
        {
            DataSet dataSet = new DataSet();
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (this.chkColumns.Items[i].Value.ToLower() == "inventorycode")
                    {
                        empty = "a.InventoryID,a.inventorycode ";
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "inventoryname")
                    {
                        empty = (empty == "" ? "Replace(Replace(a.inventoryname,'%27',''''),'%22','\"') as inventoryname" : string.Concat(empty, ",Replace(Replace(a.inventoryname,'%27',''''),'%22','\"') as inventoryname"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "supplierid")
                    {
                        if (empty == "")
                        {
                            empty = string.Concat("Replace(Replace((select ISNULL(clientname,'') from tb_client b where b.clientid=a.SupplierID and b.IsDelete=0 and b.CompanyID=", this.CompanyID, "),'%27',''''),'%22','\"') as suppliername ");
                        }
                        else
                        {
                            object[] companyID = new object[] { empty, ",Replace(Replace((select ISNULL(clientname,'') from tb_client b where b.clientid=a.SupplierID and b.IsDelete=0 and b.CompanyID=", this.CompanyID, "),'%27',''''),'%22','\"') as suppliername " };
                            empty = string.Concat(companyID);
                        }
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "cost")
                    {
                        empty = (empty == "" ? "b.cost" : string.Concat(empty, ",b.cost"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "instock")
                    {
                        empty = (empty == "" ? "cast(a.InStock as int) as  InStock" : string.Concat(empty, ",cast(a.InStock as int) as InStock"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "quantityused")
                    {
                        empty = (empty == "" ? "(select CAST(REPLACE(SUM(ISNULL(FinalQuantity, 0)), '-', '') AS decimal(18,2)) from tb_inventoryhistory where inventoryid= a.InventoryID AND EstimateItemID <> 0 and FinalQuantity < 0) AS QuantityUsed " : string.Concat(empty, ",(select CAST(REPLACE(SUM(ISNULL(FinalQuantity, 0)), '-', '') AS decimal(18,2)) from tb_inventoryhistory where inventoryid= a.InventoryID AND EstimateItemID <> 0 and FinalQuantity < 0) AS QuantityUsed "));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "packedin")
                    {
                        empty = (empty == "" ? "b.packedin" : string.Concat(empty, ",b.packedin"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "packedprice")
                    {
                        empty = (empty == "" ? "b.packedprice" : string.Concat(empty, ",b.packedprice"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "createddate")
                    {
                        empty = (empty == "" ? "CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate" : string.Concat(empty, ",CONVERT(VARCHAR(10),a.CreatedDate,101) as CreatedDate"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "basisweight")
                    {
                        empty = (empty == "" ? "cast(b.basisweight as int) as basisweight" : string.Concat(empty, ",cast(b.basisweight as int) as basisweight"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "caliper")
                    {
                        empty = (empty == "" ? "cast(b.Caliper as int) as Caliper" : string.Concat(empty, ",cast(b.Caliper as int) as Caliper"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "coated")
                    {
                        empty = (empty == "" ? "b.coated" : string.Concat(empty, ",b.coated"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "colour")
                    {
                        empty = (empty == "" ? "Replace(Replace(b.colour,'%27',''''),'%22','\"') as colour" : string.Concat(empty, ",Replace(Replace(b.colour,'%27',''''),'%22','\"') as colour"));
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "itempapersize")
                    {
                        if (empty == "")
                        {
                            empty = "CONVERT(VARCHAR(50),b.papersizeid) as papersizeid,cast(b.basisweight as int) as basisweight,b.colour";
                        }
                        else
                        {
                            if (!empty.Contains("basisweight"))
                            {
                                empty = string.Concat(empty, ",cast(b.basisweight as int) as basisweight");
                            }
                            if (!empty.Contains("colour"))
                            {
                                empty = string.Concat(empty, ",b.colour");
                            }
                            if (!empty.Contains("papersizeid"))
                            {
                                empty = string.Concat(empty, ",CONVERT(VARCHAR(50),b.papersizeid) as papersizeid");
                            }
                        }
                    }
                    if (this.chkColumns.Items[i].Value.ToLower() == "itemcustomsize")
                    {
                        if (empty == "")
                        {
                            empty = "CAST(b.height AS decimal(18,4)) AS height,CAST(b.width AS decimal(18,4)) AS width,b.basisweight,b.colour";
                        }
                        else
                        {
                            if (!empty.Contains("height"))
                            {
                                empty = string.Concat(empty, ",CAST(b.height AS decimal(18,4)) AS height");
                            }
                            if (!empty.Contains("width"))
                            {
                                empty = string.Concat(empty, ",CAST(b.width AS decimal(18,4)) AS width");
                            }
                            if (!empty.Contains("basisweight"))
                            {
                                empty = string.Concat(empty, ",b.basisweight");
                            }
                            if (!empty.Contains("colour"))
                            {
                                empty = string.Concat(empty, ",b.colour");
                            }
                        }
                    }
                }
            }
            if(this.ddlInvCategory.SelectedValue == "0")
            {
                empty = string.Concat(empty, ",a.InventoryCategoryID ");
                empty = string.Concat(empty, ",c.CategoryName as 'Type' ");
            }

            //str = string.Concat(" from tb_inventory a,tb_inventoryproperties b,tb_stockcategory c where a.companyid=", this.CompanyID, " and a.InventoryID=b.InventoryID and a.IsDeleted=0 and a.IsArchived=0 ");
            str = string.Concat(" from tb_inventory a,tb_inventoryproperties b ");
            if (this.ddlInvCategory.SelectedValue == "0")
            {
                str = string.Concat(str, " ,tb_stockcategory c ");
            }
            str = string.Concat(str, " where a.companyid=", this.CompanyID, " and a.InventoryID=b.InventoryID and a.IsDeleted=0 and a.IsArchived=0  ");

            if (this.txtFreetext.Text != "")
            {
                object[] objArray = new object[] { str, "and (a.inventorycode like '", base.SpecialEncode(this.txtFreetext.Text), "%' or a.inventoryname like '", base.SpecialEncode(this.txtFreetext.Text), "%' or (select ISNULL(ltrim(clientname),'') from tb_client b where b.clientid=a.SupplierID and b.IsDelete=0 and b.CompanyID=", this.CompanyID, ") like '", base.SpecialEncode(this.txtFreetext.Text), "%') " };
                str = string.Concat(objArray);
                base.SpecialDecode(this.txtFreetext.Text);
            }
            if (this.ddlInvCategory.SelectedIndex != 0 && this.ddlInvCategory.SelectedValue!= "0")
            {
                str = string.Concat(str, "and (a.InventoryCategoryID like '", base.ReplaceSingleQuote(this.ddlInvCategory.SelectedValue), "')");
            }
            if (this.ddlInvCategory.SelectedValue == "0")
            {
                str = string.Concat(str, " and c.CategoryID=a.Inventorycategoryid ");
            }
            if (this.ddlEstimateRange.SelectedIndex != 0)
            {
                string str8 = string.Empty;
                string empty9 = string.Empty;
                string str9 = string.Empty;
                string empty10 = string.Empty;
                if (this.ddlEstimateRange.SelectedValue == "2")
                {
                    str8 = "0";
                    empty9 = "500";
                }
                if (this.ddlEstimateRange.SelectedValue == "3")
                {
                    str8 = "501";
                    empty9 = "2500";
                }
                if (this.ddlEstimateRange.SelectedValue == "4")
                {
                    str8 = "2501";
                    empty9 = "5000";
                }
                empty10 = "false";
                if (this.ddlEstimateRange.SelectedValue == ">5")
                {
                    empty10 = "true";
                    str9 = ">5000";
                }
                if (empty10 != "true")
                {
                    string[] strArrays = new string[] { str, "and b.packedprice between ", str8, " and ", empty9, " " };
                    str = string.Concat(strArrays);
                }
                else
                {
                    str = string.Concat(str, "and b.packedprice ", str9, " ");
                }
            }
            str = (!this.chkEstimate.Checked ? string.Concat(str, "and b.packedprice>0 ") : string.Concat(str, " "));
            if (this.txtName.Text != "")
            {
                str = string.Concat(str, "and a.supplierid=", this.hid_ClientID.Value);
                base.SpecialEncode(this.txtName.Text);
            }
            if (this.chkDateOption.Checked)
            {
                if (this.rdlDate.SelectedValue == "daily")
                {
                    string str10 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    str = string.Concat(str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) = '", str10, "' ");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    string str11 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    str = string.Concat(str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) = '", str11, "' ");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    string str12 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str13 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    string[] strArrays1 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str12, "' and '", str13, "' " };
                    str = string.Concat(strArrays1);
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    string[] strArrays2 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str14, "' and '", str15, "' " };
                    str = string.Concat(strArrays2);
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    string str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    string[] strArrays3 = new string[] { str, " and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str16, "' and '", str17, "'" };
                    str = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.startyear[0].ToString());
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endyear[0].ToString());
                    string[] strArrays4 = new string[] { str, "and DateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str18, "' and '", str19, "'" };
                    str = string.Concat(strArrays4);
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.from_halffiscalyear[0].ToString());
                    string str21 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.to_halffiscalyear[0].ToString());
                    string[] strArrays5 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str20, "' and '", str21, "' " };
                    str = string.Concat(strArrays5);
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    commonClass _commonClass = this.objJava;
                    DateTime now = DateTime.Now;
                    string[] strArrays6 = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true).Split(new char[] { ' ' });
                    str = string.Concat(str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) <= '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, strArrays6[0].ToString()), "' ");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    string str22 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtFrom.Text));
                    string str23 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtTo.Text));
                    string[] strArrays7 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) BETWEEN '", str22, "' AND '", str23, "' " };
                    str = string.Concat(strArrays7);
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str21 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    string[] strArrays5 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str20, "' and '", str21, "' " };
                    str = string.Concat(strArrays5);
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str21 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    string[] strArrays5 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str20, "' and '", str21, "' " };
                    str = string.Concat(strArrays5);
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    string str20 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str21 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    string[] strArrays5 = new string[] { str, "and dateAdd(d,0,DateDiff(d,0,a.CreatedDate)) between '", str20, "' and '", str21, "' " };
                    str = string.Concat(strArrays5);
                }
            }
            string str24 = string.Concat(str, " and ISNULL(a.Inventorycategoryid,0)>0");
            if(this.ddlInvCategory.SelectedValue == "0")
            {
                str = string.Concat(str, " and ISNULL(a.Inventorycategoryid,0)>0 order by a.InventoryCategoryID desc");
            }
            else
            {
                str = string.Concat(str, " and ISNULL(a.Inventorycategoryid,0)>0 order by a.inventorycode");
            }
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            if (PageNumber != 0)
            {
                int pageNumber = PageNumber * 100 - 100;
                int num = 100;
                string[] strArrays8 = new string[] { "select distinct ", empty, " ", str, " " };
                stringBuilder.Append(string.Concat(strArrays8));
                object[] objArray1 = new object[] { " offset ", pageNumber, " rows fetch next ", num, " rows only;" };
                stringBuilder.Append(string.Concat(objArray1));
                stringBuilder.Append(string.Concat(" select count(*) ", str24));
            }
            else
            {
                string[] strArrays9 = new string[] { "select distinct ", empty, " ", str, " " };
                stringBuilder.Append(string.Concat(strArrays9));
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder.ToString(), sqlConnection);
            sqlDataAdapter.Fill(dataSet);
            if (this.ddlInvCategory.SelectedValue == "0")
            {
                dataSet.Tables[0].Columns.Remove("InventoryCategoryID");
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(row[0].ToString());
            }
            return dataSet;
        }

        public void GetPageBind(int PageNumber)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            DataSet estimateData = this.GetEstimateData(PageNumber);
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = true;
            this.pnlEmptyRecords.Visible = false;
            this.GridEstReport.DataSource = estimateData;
            this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            this.usrPaging.Visible = true;
            pagingreport.intCurrentPage = PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        [WebMethod]
        public static string GetSupplierName(string val)
        {
            string[] strArrays = val.Split(new char[] { '±' });
            string str = strArrays[0];
            string str1 = strArrays[1];
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            CompanyBasePage companyBasePage = new CompanyBasePage();
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = companyBasePage.company_autocomplete(Convert.ToInt32(str), "Supplier", baseClass.SpecialEncode(str1));
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["ClientID"].ToString();
                empty1 = row["ClientName"].ToString();
                empty2 = row["Contacts"].ToString();
                str2 = row["CustomizedValue"].ToString();
                empty3 = companyBasePage.default_address_select(Convert.ToInt32(str), Convert.ToInt32(empty));
                string[] strArrays1 = new string[] { empty, "$", empty1, "$", empty2, "$", str2, "$", empty3, "µ" };
                empty4 = string.Concat(empty4, string.Concat(strArrays1));
            }
            return empty4;
        }

        private void GridEstReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.GridEstReport.HeaderStyle.CssClass = "commonheaderstylereport1";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    if (e.Row.Cells[i].Text.ToLower() == "inventorycode")
                    {
                        this.cell_InventoryCode = i;
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Inventory_Code");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "inventoryname")
                    {
                        this.cell_InventoryName = i;
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Inventory_Name");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "suppliername")
                    {
                        this.cell_SupplierName = i;
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Supplier_Name");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "coated")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Coating_Type");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "colour")
                    {
                        this.cell_colour = i;
                        e.Row.Cells[i].Text = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "papersizeid")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Size_Ordered");
                        this.cell_sizeordered = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "basisweight")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Weight");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_weight = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "caliper")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Caliper");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_caliper = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "packedin")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Packed_In");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_packedin = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "cost")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Cost"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_cost = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "instock")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("In_Stock_Qty");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_InStock = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "quantityused")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Quantity_Used");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_QuantityUsed = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "createddate")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Created_On");
                        e.Row.Cells[i].Attributes.Add("align", "center");
                        this.cell_createddate = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "packedprice")
                    {
                        e.Row.Cells[i].Text = string.Concat(this.objLangClass.GetLanguageConversion("Packed_Price"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_packprice = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "height")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Height");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_height = i;
                    }
                    if (e.Row.Cells[i].Text.ToLower() == "width")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Width");
                        e.Row.Cells[i].Attributes.Add("align", "right");
                        this.cell_width = i;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                for (int j = 0; j < this.GridEstReport.Rows.Count; j++)
                {
                    string text = this.GridEstReport.Rows[j].Cells[0].Text;
                    for (int k = j + 1; k < this.GridEstReport.Rows.Count; k++)
                    {
                        if (string.Compare(text, this.GridEstReport.Rows[k].Cells[0].Text, true) == 0)
                        {
                            for (int l = 0; l < this.GridEstReport.Rows[k].Cells.Count; l++)
                            {
                                if (string.Compare(this.GridEstReport.Rows[j].Cells[l].Text, this.GridEstReport.Rows[k].Cells[l].Text, true) == 0)
                                {
                                    this.GridEstReport.Rows[k].Cells[l].Text = string.Empty;
                                }
                            }
                        }
                    }
                }
                if (this.cell_packedin != 0)
                {
                    e.Row.Cells[this.cell_packedin].Attributes.Add("align", "right");
                    e.Row.Cells[this.cell_packedin].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cell_packedin].Text), 0, "", false, false, true), "</div>");
                }
                if (this.cell_cost != 0)
                {
                    e.Row.Cells[this.cell_cost].Attributes.Add("align", "right");
                    e.Row.Cells[this.cell_cost].Text = string.Concat("<div style='min-width: 100px ;width: 80px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cell_cost].Text), 0, "", false, false, true), "</div>");
                }
                if (this.cell_InStock != 0)
                {
                    e.Row.Cells[this.cell_InStock].Attributes.Add("align", "right");
                    e.Row.Cells[this.cell_InStock].Text = string.Concat("<div style='min-width: 100px ;width: 80px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToInt32(e.Row.Cells[this.cell_InStock].Text), 0, "", true, false, true), "</div>");
                }
                if (this.cell_QuantityUsed != 0)
                {
                    e.Row.Cells[this.cell_QuantityUsed].Attributes.Add("align", "right");
                    //e.Row.Cells[this.cell_QuantityUsed].Text = string.Concat("<div style='min-width: 100px ;width: 80px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToInt32(e.Row.Cells[this.cell_QuantityUsed].Text), 0, "", true, false, true), "</div>");
                }
                if (this.cell_height != 0)
                {
                    e.Row.Cells[this.cell_height].Attributes.Add("align", "right");
                }
                if (this.cell_width != 0)
                {
                    e.Row.Cells[this.cell_width].Attributes.Add("align", "right");
                }
                if (this.cell_packprice != 0)
                {
                    e.Row.Cells[this.cell_packprice].Attributes.Add("align", "right");
                    e.Row.Cells[this.cell_packprice].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(e.Row.Cells[this.cell_packprice].Text), 0, "", false, false, true), "</div>");
                }
                if (this.cell_weight != 0)
                {
                    e.Row.Cells[this.cell_weight].Attributes.Add("align", "right");
                }
                if (this.cell_caliper != 0)
                {
                    e.Row.Cells[this.cell_caliper].Attributes.Add("align", "right");
                }
                if (this.cell_createddate != 0)
                {
                    e.Row.Cells[this.cell_createddate].Attributes.Add("align", "center");
                    e.Row.Cells[this.cell_createddate].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", this.objJava.Eprint_return_Date_Before_View(e.Row.Cells[this.cell_createddate].Text, this.CompanyID, this.UserID, false), "</div>");
                }
                if (this.cell_sizeordered != 0)
                {
                    e.Row.Cells[this.cell_sizeordered].Text = SettingsBasePage.settings_papersizename_select(this.CompanyID, Convert.ToInt32(e.Row.Cells[this.cell_sizeordered].Text));
                }
                if (this.cell_InventoryCode != 0)
                {
                    e.Row.Cells[this.cell_InventoryCode].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cell_InventoryCode].Text), "</div>");
                }
                if (this.cell_InventoryName != 0)
                {
                    e.Row.Cells[this.cell_InventoryName].Text = string.Concat("<div style='min-width: 100px ;width: 150px ;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cell_InventoryName].Text), "</div>");
                }
                if (this.cell_SupplierName != 0)
                {
                    TableCell item = e.Row.Cells[this.cell_SupplierName];
                    string[] strArrays = new string[] { "<div style='min-width: 100px;' title='", base.SpecialDecode(e.Row.Cells[this.cell_SupplierName].Text), "'>", base.SpecialDecode(e.Row.Cells[this.cell_SupplierName].Text), "</div>" };
                    item.Text = string.Concat(strArrays);
                }
                if (this.cell_colour != 0)
                {
                    e.Row.Cells[this.cell_colour].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", base.SpecialDecode(e.Row.Cells[this.cell_colour].Text), "</div>");
                }
                for (int m = 0; m < e.Row.Cells.Count; m++)
                {
                    if (e.Row.Cells.Count == 13)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 12)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 11)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 10)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 100px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 9)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 125px ;width: 150px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 8)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 125px ;width: 100px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 7)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 125px ;width: 120px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 6)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width:143px ;width: 120px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 5)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 200px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 4)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 167px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 3)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 250px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 2)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 333px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 1)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 500px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                    if (e.Row.Cells.Count == 0)
                    {
                        e.Row.Cells[m].Text = string.Concat("<div style='min-width: 1000px ;overflow:hidden;max-height: 15px;height:15px;'>", e.Row.Cells[m].Text, "</div>");
                    }
                }
            }
        }

        public string HalfFiscalYear()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalTo"]);
            int month = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToString());
            int num = dateTime.Month;
            DateTime dateTime3 = dateTime.AddMonths(5);
            int month1 = dateTime3.Month;
            int year = 0;
            int num1 = 0;
            int month2 = dateTime.Month;
            int num2 = dateTime2.Month;
            int month3 = dateTime3.Month;
            if (num <= 7)
            {
                num1 = DateTime.DaysInMonth(dateTime.Year, month1);
            }
            else
            {
                year = dateTime.AddYears(1).Year;
                num1 = DateTime.DaysInMonth(year, month1);
            }
            if (num2 <= month1 || dateTime2.Year != dateTime3.Year)
            {
                dateTimeArray[0] = new DateTime(dateTime.Year, num, 1);
                dateTimeArray[1] = new DateTime(dateTime3.Year, month1, num1);
            }
            else
            {
                dateTimeArray[0] = new DateTime(dateTime3.Year, month1 + 1, 1);
                dateTimeArray[1] = dateTime1;
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        public string LastQuarter()
        {
            DataTable dataTable = SettingsBasePage.settings_regionalsettings_select(this.CompanyID);
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString());
            int month = dateTime.Month;
            DateTime dateTime1 = new DateTime();
            dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["FisCalFrom"]);
            int num = dateTime1.Month;
            DateTime[] dateTimeArray = new DateTime[2];
            if (num == 1)
            {
                if (month == 1 || month == 2 || month == 3)
                {
                    int month1 = dateTime.Month;
                    if (month1 == 1)
                    {
                        int num1 = month1 + 11;
                        month1 = month1 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num1, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 2)
                    {
                        int num2 = month1 + 10;
                        month1 = month1 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num2, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                    else if (month1 == 3)
                    {
                        int num3 = month1 + 9;
                        month1 = month1 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month1, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num3, DateTime.DaysInMonth(dateTime.Year, month1));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month2 = dateTime.Month;
                    if (month2 == 4)
                    {
                        month2 = month2 - 3;
                        int num4 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num4, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 5)
                    {
                        month2 = month2 - 4;
                        int num5 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num5, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                    else if (month2 == 6)
                    {
                        month2 = month2 - 5;
                        int num6 = month2 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month2, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num6, DateTime.DaysInMonth(dateTime.Year, month2));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month3 = dateTime.Month;
                    if (month3 == 7)
                    {
                        month3 = month3 - 3;
                        int num7 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num7, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 8)
                    {
                        month3 = month3 - 4;
                        int num8 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num8, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                    else if (month3 == 9)
                    {
                        month3 = month3 - 5;
                        int num9 = month3 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month3, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num9, DateTime.DaysInMonth(dateTime.Year, month3));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month4 = dateTime.Month;
                    if (month4 == 10)
                    {
                        month4 = month4 - 3;
                        int num10 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num10, DateTime.DaysInMonth(dateTime.Year, num10));
                    }
                    if (month4 == 11)
                    {
                        month4 = month4 - 4;
                        int num11 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num11, DateTime.DaysInMonth(dateTime.Year, num11));
                    }
                    else if (month4 == 12)
                    {
                        month4 = month4 - 5;
                        int num12 = month4 + 2;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month4, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num12, DateTime.DaysInMonth(dateTime.Year, num12));
                    }
                }
            }
            if (num == 2)
            {
                if (month == 2 || month == 3 || month == 4)
                {
                    int month5 = dateTime.Month;
                    if (month5 == 2)
                    {
                        int num13 = month5 - 1;
                        month5 = month5 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num13, DateTime.DaysInMonth(dateTime.Year, num13));
                    }
                    else if (month5 == 3)
                    {
                        int num14 = month5 - 2;
                        month5 = month5 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num14, DateTime.DaysInMonth(dateTime.Year, num14));
                    }
                    else if (month5 == 4)
                    {
                        int num15 = month5 - 3;
                        month5 = month5 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month5, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num15, DateTime.DaysInMonth(dateTime.Year, num15));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month6 = dateTime.Month;
                    if (month6 == 5)
                    {
                        int num16 = month6 - 1;
                        month6 = month6 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num16, DateTime.DaysInMonth(dateTime.Year, num16));
                    }
                    else if (month6 == 6)
                    {
                        int num17 = month6 - 2;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num17, DateTime.DaysInMonth(dateTime.Year, num17));
                    }
                    else if (month6 == 7)
                    {
                        int num18 = month6 - 3;
                        month6 = month6 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month6, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num18, DateTime.DaysInMonth(dateTime.Year, num18));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month7 = dateTime.Month;
                    if (month7 == 8)
                    {
                        int num19 = month7 - 1;
                        month7 = month7 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num19, DateTime.DaysInMonth(dateTime.Year, num19));
                    }
                    else if (month7 == 9)
                    {
                        int num20 = month7 - 2;
                        month7 = month7 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num20, DateTime.DaysInMonth(dateTime.Year, num20));
                    }
                    else if (month7 == 10)
                    {
                        int num21 = month7 - 3;
                        month7 = month7 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month7, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num21, DateTime.DaysInMonth(dateTime.Year, num21));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month8 = dateTime.Month;
                    if (month8 == 11)
                    {
                        int num22 = month8 - 1;
                        month8 = month8 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num22, DateTime.DaysInMonth(dateTime.Year, num22));
                    }
                    if (month8 == 12)
                    {
                        int num23 = month8 - 2;
                        month8 = month8 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num23, DateTime.DaysInMonth(dateTime.Year, num23));
                    }
                    else if (month8 == 1)
                    {
                        int num24 = month8 + 9;
                        month8 = month8 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month8, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num24, DateTime.DaysInMonth(dateTime.Year, num24));
                    }
                }
            }
            if (num == 3)
            {
                if (month == 3 || month == 4 || month == 5)
                {
                    int month9 = dateTime.Month;
                    if (month9 == 3)
                    {
                        int num25 = month9 - 1;
                        month9 = month9 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num25, DateTime.DaysInMonth(dateTime.Year, num25));
                    }
                    else if (month9 == 4)
                    {
                        int num26 = month9 - 2;
                        month9 = month9 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num26, DateTime.DaysInMonth(dateTime.Year, num26));
                    }
                    else if (month9 == 5)
                    {
                        int num27 = month9 - 3;
                        month9 = month9 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month9, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num27, DateTime.DaysInMonth(dateTime.Year, num27));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month10 = dateTime.Month;
                    if (month10 == 6)
                    {
                        int num28 = month10 - 1;
                        month10 = month10 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num28, DateTime.DaysInMonth(dateTime.Year, num28));
                    }
                    else if (month10 == 7)
                    {
                        int num29 = month10 - 2;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num29, DateTime.DaysInMonth(dateTime.Year, num29));
                    }
                    else if (month10 == 8)
                    {
                        int num30 = month10 - 3;
                        month10 = month10 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month10, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num30, DateTime.DaysInMonth(dateTime.Year, num30));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month11 = dateTime.Month;
                    if (month11 == 9)
                    {
                        int num31 = month11 - 1;
                        month11 = month11 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num31, DateTime.DaysInMonth(dateTime.Year, num31));
                    }
                    else if (month11 == 10)
                    {
                        int num32 = month11 - 2;
                        month11 = month11 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num32, DateTime.DaysInMonth(dateTime.Year, num32));
                    }
                    else if (month11 == 11)
                    {
                        int num33 = month11 - 3;
                        month11 = month11 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month11, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num33, DateTime.DaysInMonth(dateTime.Year, num33));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month12 = dateTime.Month;
                    if (month12 == 12)
                    {
                        int num34 = month12 - 1;
                        month12 = month12 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num34, DateTime.DaysInMonth(dateTime.Year, num34));
                    }
                    if (month12 == 1)
                    {
                        int num35 = month12 + 10;
                        month12 = month12 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num35, DateTime.DaysInMonth(dateTime.Year, num35));
                    }
                    else if (month12 == 2)
                    {
                        int num36 = month12 + 9;
                        month12 = month12 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month12, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num36, DateTime.DaysInMonth(dateTime.Year, num36));
                    }
                }
            }
            if (num == 4)
            {
                if (month == 4 || month == 5 || month == 6)
                {
                    int month13 = dateTime.Month;
                    if (month13 == 4)
                    {
                        int num37 = month13 - 1;
                        month13 = month13 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num37, DateTime.DaysInMonth(dateTime.Year, num37));
                    }
                    else if (month13 == 5)
                    {
                        int num38 = month13 - 2;
                        month13 = month13 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num38, DateTime.DaysInMonth(dateTime.Year, num38));
                    }
                    else if (month13 == 6)
                    {
                        int num39 = month13 - 3;
                        month13 = month13 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month13, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num39, DateTime.DaysInMonth(dateTime.Year, num39));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month14 = dateTime.Month;
                    if (month14 == 7)
                    {
                        int num40 = month14 - 1;
                        month14 = month14 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num40, DateTime.DaysInMonth(dateTime.Year, num40));
                    }
                    else if (month14 == 8)
                    {
                        int num41 = month14 - 2;
                        month14 = month14 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num41, DateTime.DaysInMonth(dateTime.Year, num41));
                    }
                    else if (month14 == 9)
                    {
                        int num42 = month14 - 3;
                        month14 = month14 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month14, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num42, DateTime.DaysInMonth(dateTime.Year, num42));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month15 = dateTime.Month;
                    if (month15 == 10)
                    {
                        int num43 = month15 - 1;
                        month15 = month15 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num43, DateTime.DaysInMonth(dateTime.Year, num43));
                    }
                    else if (month15 == 11)
                    {
                        int num44 = month15 - 2;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num44, DateTime.DaysInMonth(dateTime.Year, num44));
                    }
                    else if (month15 == 12)
                    {
                        int num45 = month15 - 3;
                        month15 = month15 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month15, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num45, DateTime.DaysInMonth(dateTime.Year, num45));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month16 = dateTime.Month;
                    if (month16 == 1)
                    {
                        int num46 = month16 + 11;
                        month16 = month16 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num46, DateTime.DaysInMonth(dateTime.Year, num46));
                    }
                    if (month16 == 2)
                    {
                        int num47 = month16 + 10;
                        month16 = month16 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num47, DateTime.DaysInMonth(dateTime.Year, num47));
                    }
                    else if (month16 == 3)
                    {
                        int num48 = month16 + 9;
                        month16 = month16 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month16, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num48, DateTime.DaysInMonth(dateTime.Year, num48));
                    }
                }
            }
            if (num == 5)
            {
                if (month == 5 || month == 6 || month == 7)
                {
                    int month17 = dateTime.Month;
                    if (month17 == 5)
                    {
                        int num49 = month17 - 1;
                        month17 = month17 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num49, DateTime.DaysInMonth(dateTime.Year, num49));
                    }
                    else if (month17 == 6)
                    {
                        int num50 = month17 - 2;
                        month17 = month17 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num50, DateTime.DaysInMonth(dateTime.Year, num50));
                    }
                    else if (month17 == 7)
                    {
                        int num51 = month17 - 3;
                        month17 = month17 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month17, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num51, DateTime.DaysInMonth(dateTime.Year, num51));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month18 = dateTime.Month;
                    if (month18 == 8)
                    {
                        int num52 = month18 - 1;
                        month18 = month18 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num52, DateTime.DaysInMonth(dateTime.Year, num52));
                    }
                    else if (month18 == 9)
                    {
                        int num53 = month18 - 2;
                        month18 = month18 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num53, DateTime.DaysInMonth(dateTime.Year, num53));
                    }
                    else if (month18 == 10)
                    {
                        int num54 = month18 - 3;
                        month18 = month18 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month18, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num54, DateTime.DaysInMonth(dateTime.Year, num54));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month19 = dateTime.Month;
                    if (month19 == 11)
                    {
                        int num55 = month19 - 1;
                        month19 = month19 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num55, DateTime.DaysInMonth(dateTime.Year, num55));
                    }
                    else if (month19 == 12)
                    {
                        int num56 = month19 - 2;
                        month19 = month19 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num56, DateTime.DaysInMonth(dateTime.Year, num56));
                    }
                    else if (month19 == 1)
                    {
                        int num57 = month19 + 7;
                        month19 = month19 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month19, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num57, DateTime.DaysInMonth(dateTime.Year, num57));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month20 = dateTime.Month;
                    if (month20 == 2)
                    {
                        int num58 = month20 - 1;
                        month20 = month20 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num58, DateTime.DaysInMonth(dateTime.Year, num58));
                    }
                    if (month20 == 3)
                    {
                        int num59 = month20 - 2;
                        month20 = month20 - 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num59, DateTime.DaysInMonth(dateTime.Year, num59));
                    }
                    else if (month20 == 4)
                    {
                        int num60 = month20 - 3;
                        month20 = month20 - 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month20, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num60, DateTime.DaysInMonth(dateTime.Year, num60));
                    }
                }
            }
            if (num == 6)
            {
                if (month == 6 || month == 7 || month == 8)
                {
                    int month21 = dateTime.Month;
                    if (month21 == 6)
                    {
                        int num61 = month21 - 1;
                        month21 = month21 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num61, DateTime.DaysInMonth(dateTime.Year, num61));
                    }
                    else if (month21 == 7)
                    {
                        int num62 = month21 - 2;
                        month21 = month21 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num62, DateTime.DaysInMonth(dateTime.Year, num62));
                    }
                    else if (month21 == 8)
                    {
                        int num63 = month21 - 3;
                        month21 = month21 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month21, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num63, DateTime.DaysInMonth(dateTime.Year, num63));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month22 = dateTime.Month;
                    if (month22 == 9)
                    {
                        int num64 = month22 - 1;
                        month22 = month22 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num64, DateTime.DaysInMonth(dateTime.Year, num64));
                    }
                    else if (month22 == 10)
                    {
                        int num65 = month22 - 2;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num65, DateTime.DaysInMonth(dateTime.Year, num65));
                    }
                    else if (month22 == 11)
                    {
                        int num66 = month22 - 3;
                        month22 = month22 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month22, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num66, DateTime.DaysInMonth(dateTime.Year, num66));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month23 = dateTime.Month;
                    if (month23 == 12)
                    {
                        int num67 = month23 - 1;
                        month23 = month23 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num67, DateTime.DaysInMonth(dateTime.Year, num67));
                    }
                    else if (month23 == 1)
                    {
                        int num68 = month23 + 10;
                        month23 = month23 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num68, DateTime.DaysInMonth(dateTime.Year, num68));
                    }
                    else if (month23 == 2)
                    {
                        int num69 = month23 + 9;
                        month23 = month23 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month23, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num69, DateTime.DaysInMonth(dateTime.Year, num69));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month24 = dateTime.Month;
                    if (month24 == 3)
                    {
                        int num70 = month24 - 1;
                        month24 = month24 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num70, DateTime.DaysInMonth(dateTime.Year, num70));
                    }
                    if (month24 == 4)
                    {
                        int num71 = month24 - 2;
                        month24 = month24 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num71, DateTime.DaysInMonth(dateTime.Year, num71));
                    }
                    else if (month24 == 5)
                    {
                        int num72 = month24 - 3;
                        month24 = month24 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month24, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num72, DateTime.DaysInMonth(dateTime.Year, num72));
                    }
                }
            }
            if (num == 7)
            {
                if (month == 7 || month == 8 || month == 9)
                {
                    int month25 = dateTime.Month;
                    if (month25 == 7)
                    {
                        int num73 = month25 - 1;
                        month25 = month25 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num73, DateTime.DaysInMonth(dateTime.Year, num73));
                    }
                    else if (month25 == 8)
                    {
                        int num74 = month25 - 2;
                        month25 = month25 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num74, DateTime.DaysInMonth(dateTime.Year, num74));
                    }
                    else if (month25 == 9)
                    {
                        int num75 = month25 - 3;
                        month25 = month25 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month25, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num75, DateTime.DaysInMonth(dateTime.Year, num75));
                    }
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    int month26 = dateTime.Month;
                    if (month26 == 10)
                    {
                        int num76 = month26 - 1;
                        month26 = month26 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num76, DateTime.DaysInMonth(dateTime.Year, num76));
                    }
                    else if (month26 == 11)
                    {
                        int num77 = month26 - 2;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num77, DateTime.DaysInMonth(dateTime.Year, num77));
                    }
                    else if (month26 == 12)
                    {
                        int num78 = month26 - 3;
                        month26 = month26 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month26, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num78, DateTime.DaysInMonth(dateTime.Year, num78));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month27 = dateTime.Month;
                    if (month27 == 1)
                    {
                        int num79 = month27 + 11;
                        month27 = month27 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num79, DateTime.DaysInMonth(dateTime.Year, num79));
                    }
                    else if (month27 == 2)
                    {
                        int num80 = month27 + 10;
                        month27 = month27 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num80, DateTime.DaysInMonth(dateTime.Year, num80));
                    }
                    else if (month27 == 3)
                    {
                        int num81 = month27 + 9;
                        month27 = month27 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month27, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num81, DateTime.DaysInMonth(dateTime.Year, num81));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month28 = dateTime.Month;
                    if (month28 == 4)
                    {
                        int num82 = month28 - 1;
                        month28 = month28 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num82, DateTime.DaysInMonth(dateTime.Year, num82));
                    }
                    if (month28 == 5)
                    {
                        int num83 = month28 - 2;
                        month28 = month28 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num83, DateTime.DaysInMonth(dateTime.Year, num83));
                    }
                    else if (month28 == 6)
                    {
                        int num84 = month28 - 3;
                        month28 = month28 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month28, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num84, DateTime.DaysInMonth(dateTime.Year, num84));
                    }
                }
            }
            if (num == 8)
            {
                if (month == 8 || month == 9 || month == 10)
                {
                    int month29 = dateTime.Month;
                    if (month29 == 8)
                    {
                        int num85 = month29 - 1;
                        month29 = month29 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num85, DateTime.DaysInMonth(dateTime.Year, num85));
                    }
                    else if (month29 == 9)
                    {
                        int num86 = month29 - 2;
                        month29 = month29 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num86, DateTime.DaysInMonth(dateTime.Year, num86));
                    }
                    else if (month29 == 10)
                    {
                        int num87 = month29 - 3;
                        month29 = month29 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month29, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num87, DateTime.DaysInMonth(dateTime.Year, num87));
                    }
                }
                else if (month == 11 || month == 12 || month == 1)
                {
                    int month30 = dateTime.Month;
                    if (month30 == 11)
                    {
                        int num88 = month30 - 1;
                        month30 = month30 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num88, DateTime.DaysInMonth(dateTime.Year, num88));
                    }
                    else if (month30 == 12)
                    {
                        int num89 = month30 - 2;
                        month30 = month30 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num89, DateTime.DaysInMonth(dateTime.Year, num89));
                    }
                    else if (month30 == 1)
                    {
                        int num90 = month30 + 9;
                        month30 = month30 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month30, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num90, DateTime.DaysInMonth(dateTime.Year, num90));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month31 = dateTime.Month;
                    if (month31 == 2)
                    {
                        int num91 = month31 - 1;
                        month31 = month31 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num91, DateTime.DaysInMonth(dateTime.Year, num91));
                    }
                    else if (month31 == 3)
                    {
                        int num92 = month31 - 2;
                        month31 = month31 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num92, DateTime.DaysInMonth(dateTime.Year, num92));
                    }
                    else if (month31 == 4)
                    {
                        int num93 = month31 - 3;
                        month31 = month31 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month31, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num93, DateTime.DaysInMonth(dateTime.Year, num93));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month32 = dateTime.Month;
                    if (month32 == 5)
                    {
                        int num94 = month32 - 1;
                        month32 = month32 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num94, DateTime.DaysInMonth(dateTime.Year, num94));
                    }
                    if (month32 == 6)
                    {
                        int num95 = month32 - 2;
                        month32 = month32 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num95, DateTime.DaysInMonth(dateTime.Year, num95));
                    }
                    else if (month32 == 7)
                    {
                        int num96 = month32 - 3;
                        month32 = month32 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month32, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num96, DateTime.DaysInMonth(dateTime.Year, num96));
                    }
                }
            }
            if (num == 9)
            {
                if (month == 9 || month == 10 || month == 11)
                {
                    int month33 = dateTime.Month;
                    if (month33 == 9)
                    {
                        int num97 = month33 - 1;
                        month33 = month33 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num97, DateTime.DaysInMonth(dateTime.Year, num97));
                    }
                    else if (month33 == 10)
                    {
                        int num98 = month33 - 2;
                        month33 = month33 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num98, DateTime.DaysInMonth(dateTime.Year, num98));
                    }
                    else if (month33 == 11)
                    {
                        int num99 = month33 - 3;
                        month33 = month33 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month33, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num99, DateTime.DaysInMonth(dateTime.Year, num99));
                    }
                }
                else if (month == 12 || month == 1 || month == 2)
                {
                    int month34 = dateTime.Month;
                    if (month34 == 12)
                    {
                        int num100 = month34 - 1;
                        month34 = month34 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num100, DateTime.DaysInMonth(dateTime.Year, num100));
                    }
                    else if (month34 == 1)
                    {
                        int num101 = month34 + 10;
                        month34 = month34 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num101, DateTime.DaysInMonth(dateTime.Year, num101));
                    }
                    else if (month34 == 2)
                    {
                        int num102 = month34 + 9;
                        month34 = month34 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month34, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num102, DateTime.DaysInMonth(dateTime.Year, num102));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month35 = dateTime.Month;
                    if (month35 == 3)
                    {
                        int num103 = month35 - 1;
                        month35 = month35 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num103, DateTime.DaysInMonth(dateTime.Year, num103));
                    }
                    else if (month35 == 4)
                    {
                        int num104 = month35 - 2;
                        month35 = month35 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num104, DateTime.DaysInMonth(dateTime.Year, num104));
                    }
                    else if (month35 == 5)
                    {
                        int num105 = month35 - 3;
                        month35 = month35 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month35, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num105, DateTime.DaysInMonth(dateTime.Year, num105));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month36 = dateTime.Month;
                    if (month36 == 6)
                    {
                        int num106 = month36 - 1;
                        month36 = month36 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num106, DateTime.DaysInMonth(dateTime.Year, num106));
                    }
                    if (month36 == 7)
                    {
                        int num107 = month36 - 2;
                        month36 = month36 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num107, DateTime.DaysInMonth(dateTime.Year, num107));
                    }
                    else if (month36 == 8)
                    {
                        int num108 = month36 - 3;
                        month36 = month36 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month36, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num108, DateTime.DaysInMonth(dateTime.Year, num108));
                    }
                }
            }
            if (num == 10)
            {
                if (month == 10 || month == 11 || month == 12)
                {
                    int month37 = dateTime.Month;
                    if (month37 == 10)
                    {
                        int num109 = month37 - 1;
                        month37 = month37 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num109, DateTime.DaysInMonth(dateTime.Year, num109));
                    }
                    else if (month37 == 11)
                    {
                        int num110 = month37 - 2;
                        month37 = month37 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num110, DateTime.DaysInMonth(dateTime.Year, num110));
                    }
                    else if (month37 == 12)
                    {
                        int num111 = month37 - 3;
                        month37 = month37 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month37, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num111, DateTime.DaysInMonth(dateTime.Year, num111));
                    }
                }
                else if (month == 1 || month == 2 || month == 3)
                {
                    int month38 = dateTime.Month;
                    if (month38 == 1)
                    {
                        int num112 = month38 + 11;
                        month38 = month38 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num112, DateTime.DaysInMonth(dateTime.Year, num112));
                    }
                    else if (month38 == 2)
                    {
                        int num113 = month38 + 10;
                        month38 = month38 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num113, DateTime.DaysInMonth(dateTime.Year, num113));
                    }
                    else if (month38 == 3)
                    {
                        int num114 = month38 + 9;
                        month38 = month38 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month38, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num114, DateTime.DaysInMonth(dateTime.Year, num114));
                    }
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    int month39 = dateTime.Month;
                    if (month39 == 4)
                    {
                        int num115 = month39 - 1;
                        month39 = month39 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num115, DateTime.DaysInMonth(dateTime.Year, num115));
                    }
                    else if (month39 == 5)
                    {
                        int num116 = month39 - 2;
                        month39 = month39 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num116, DateTime.DaysInMonth(dateTime.Year, num116));
                    }
                    else if (month39 == 6)
                    {
                        int num117 = month39 - 3;
                        month39 = month39 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month39, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num117, DateTime.DaysInMonth(dateTime.Year, num117));
                    }
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    int month40 = dateTime.Month;
                    if (month40 == 7)
                    {
                        int num118 = month40 - 1;
                        month40 = month40 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num118, DateTime.DaysInMonth(dateTime.Year, num118));
                    }
                    if (month40 == 8)
                    {
                        int num119 = month40 - 2;
                        month40 = month40 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num119, DateTime.DaysInMonth(dateTime.Year, num119));
                    }
                    else if (month40 == 9)
                    {
                        int num120 = month40 - 3;
                        month40 = month40 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month40, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num120, DateTime.DaysInMonth(dateTime.Year, num120));
                    }
                }
            }
            if (num == 11)
            {
                if (month == 11 || month == 12 || month == 1)
                {
                    int month41 = dateTime.Month;
                    if (month41 == 11)
                    {
                        int num121 = month41 - 1;
                        month41 = month41 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num121, DateTime.DaysInMonth(dateTime.Year, num121));
                    }
                    else if (month41 == 12)
                    {
                        int num122 = month41 - 2;
                        month41 = month41 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num122, DateTime.DaysInMonth(dateTime.Year, num122));
                    }
                    else if (month41 == 1)
                    {
                        int num123 = month41 + 9;
                        month41 = month41 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month41, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num123, DateTime.DaysInMonth(dateTime.Year, num123));
                    }
                }
                else if (month == 2 || month == 3 || month == 4)
                {
                    int month42 = dateTime.Month;
                    if (month42 == 2)
                    {
                        int num124 = month42 - 1;
                        month42 = month42 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num124, DateTime.DaysInMonth(dateTime.Year, num124));
                    }
                    else if (month42 == 3)
                    {
                        int num125 = month42 - 2;
                        month42 = month42 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num125, DateTime.DaysInMonth(dateTime.Year, num125));
                    }
                    else if (month42 == 4)
                    {
                        int num126 = month42 - 3;
                        month42 = month42 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month42, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num126, DateTime.DaysInMonth(dateTime.Year, num126));
                    }
                }
                else if (month == 5 || month == 6 || month == 7)
                {
                    int month43 = dateTime.Month;
                    if (month43 == 5)
                    {
                        int num127 = month43 - 1;
                        month43 = month43 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num127, DateTime.DaysInMonth(dateTime.Year, num127));
                    }
                    else if (month43 == 6)
                    {
                        int num128 = month43 - 2;
                        month43 = month43 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num128, DateTime.DaysInMonth(dateTime.Year, num128));
                    }
                    else if (month43 == 7)
                    {
                        int num129 = month43 - 3;
                        month43 = month43 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month43, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num129, DateTime.DaysInMonth(dateTime.Year, num129));
                    }
                }
                else if (month == 8 || month == 9 || month == 10)
                {
                    int month44 = dateTime.Month;
                    if (month44 == 8)
                    {
                        int num130 = month44 - 1;
                        month44 = month44 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num130, DateTime.DaysInMonth(dateTime.Year, num130));
                    }
                    if (month44 == 9)
                    {
                        int num131 = month44 - 2;
                        month44 = month44 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num131, DateTime.DaysInMonth(dateTime.Year, num131));
                    }
                    else if (month44 == 10)
                    {
                        int num132 = month44 - 3;
                        month44 = month44 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month44, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num132, DateTime.DaysInMonth(dateTime.Year, num132));
                    }
                }
            }
            if (num == 12)
            {
                if (month == 12 || month == 1 || month == 2)
                {
                    int month45 = dateTime.Month;
                    if (month45 == 12)
                    {
                        int num133 = month45 - 1;
                        month45 = month45 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num133, DateTime.DaysInMonth(dateTime.Year, num133));
                    }
                    else if (month45 == 1)
                    {
                        int num134 = month45 + 10;
                        month45 = month45 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num134, DateTime.DaysInMonth(dateTime.Year, num134));
                    }
                    else if (month45 == 2)
                    {
                        int num135 = month45 + 9;
                        month45 = month45 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month45, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year - 1, num135, DateTime.DaysInMonth(dateTime.Year, num135));
                    }
                }
                else if (month == 3 || month == 4 || month == 5)
                {
                    int month46 = dateTime.Month;
                    if (month46 == 3)
                    {
                        int num136 = month46 - 1;
                        month46 = month46 + 9;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num136, DateTime.DaysInMonth(dateTime.Year, num136));
                    }
                    else if (month46 == 4)
                    {
                        int num137 = month46 - 2;
                        month46 = month46 + 8;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num137, DateTime.DaysInMonth(dateTime.Year, num137));
                    }
                    else if (month46 == 5)
                    {
                        int num138 = month46 - 3;
                        month46 = month46 + 7;
                        dateTimeArray[0] = new DateTime(dateTime.Year - 1, month46, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num138, DateTime.DaysInMonth(dateTime.Year, num138));
                    }
                }
                else if (month == 6 || month == 7 || month == 8)
                {
                    int month47 = dateTime.Month;
                    if (month47 == 6)
                    {
                        int num139 = month47 - 1;
                        month47 = month47 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num139, DateTime.DaysInMonth(dateTime.Year, num139));
                    }
                    else if (month47 == 7)
                    {
                        int num140 = month47 - 2;
                        month47 = month47 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num140, DateTime.DaysInMonth(dateTime.Year, num140));
                    }
                    else if (month47 == 8)
                    {
                        int num141 = month47 - 3;
                        month47 = month47 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month47, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num141, DateTime.DaysInMonth(dateTime.Year, num141));
                    }
                }
                else if (month == 9 || month == 10 || month == 11)
                {
                    int month48 = dateTime.Month;
                    if (month48 == 9)
                    {
                        int num142 = month48 - 1;
                        month48 = month48 - 3;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num142, DateTime.DaysInMonth(dateTime.Year, num142));
                    }
                    if (month48 == 10)
                    {
                        int num143 = month48 - 2;
                        month48 = month48 - 4;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num143, DateTime.DaysInMonth(dateTime.Year, num143));
                    }
                    else if (month48 == 11)
                    {
                        int num144 = month48 - 3;
                        month48 = month48 - 5;
                        dateTimeArray[0] = new DateTime(dateTime.Year, month48, 1);
                        dateTimeArray[1] = new DateTime(dateTime.Year, num144, DateTime.DaysInMonth(dateTime.Year, num144));
                    }
                }
            }
            string str = string.Concat(dateTimeArray[0].ToString(), ",", dateTimeArray[1].ToString());
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            (new BaseClass()).ReturnRoles_Privileges_Reports("inventory", "showreport", "");
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            if (baseClass.ReturnRoles_Privileges_ForGrid("inventory", "isdisplay", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "accessdenied.aspx"));
            }
            if (baseClass.ReturnRoles_Privileges_ReportStatus("inventory", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.pg = "warehouse";
            if (base.Request.Params["pg"] == null)
            {
                this.pagename = "warehouse";
            }
            else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
            {
                this.pagename = "Report";
            }
            global.pageName = this.pagename;
            global.pgName = "";
            this.gloobj.setpagename(this.pagename);
            languageClass _languageClass = new languageClass();
            base.Title = _languageClass.convert(global.pageTitle("Inventory Report", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.chkEstimate.Text = this.objLangClass.GetLanguageConversion("Show_Price_With_No_Assigned_Value");
            this.chkDateOption.Text = this.objLangClass.GetLanguageConversion("Date_Options");
            if (this.rdlDate.Items.Count >= 9)
            {
                this.rdlDate.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
                this.rdlDate.Items[1].Text = this.objLangClass.GetLanguageConversion("Yesterday");
                this.rdlDate.Items[2].Text = this.objLangClass.GetLanguageConversion("Current_Month");
                this.rdlDate.Items[3].Text = this.objLangClass.GetLanguageConversion("Current_Quarter");
                this.rdlDate.Items[4].Text = this.objLangClass.GetLanguageConversion("Last_Quarter");
                this.rdlDate.Items[5].Text = this.objLangClass.GetLanguageConversion("Current_Year_Fiscal");
                this.rdlDate.Items[6].Text = this.objLangClass.GetLanguageConversion("Half_Fiscal_year");
                this.rdlDate.Items[7].Text = this.objLangClass.GetLanguageConversion("Till_Date");
                this.rdlDate.Items[8].Text = this.objLangClass.GetLanguageConversion("Select_Date");
            }
            else
            {
                switch (this.rdlDate.Items.Count)
                {
                    case 9:
                    case 8:
                        this.rdlDate.Items[8].Text = this.objLangClass.GetLanguageConversion("Select_Date");
                        goto case 7;
                    case 7:
                        this.rdlDate.Items[7].Text = this.objLangClass.GetLanguageConversion("Till_Date");
                        goto case 6;
                    case 6:
                        this.rdlDate.Items[6].Text = this.objLangClass.GetLanguageConversion("Half_Fiscal_year");
                        goto case 5;
                    case 5:
                        this.rdlDate.Items[5].Text = this.objLangClass.GetLanguageConversion("Current_Year_Fiscal");
                        goto case 4;
                    case 4:
                        this.rdlDate.Items[4].Text = this.objLangClass.GetLanguageConversion("Last_Quarter");
                        goto case 3;
                    case 3:
                        this.rdlDate.Items[3].Text = this.objLangClass.GetLanguageConversion("Current_Quarter");
                        goto case 2;
                    case 2:
                        this.rdlDate.Items[2].Text = this.objLangClass.GetLanguageConversion("Current_Month");
                        goto case 1;
                    case 1:
                        this.rdlDate.Items[1].Text = this.objLangClass.GetLanguageConversion("Yesterday");
                        goto case 0;
                    case 0:
                        this.rdlDate.Items[0].Text = this.objLangClass.GetLanguageConversion("Today");
                        break;
                }
            }

            if (this.RadPanelBar1.Items.Count >= 3)
            {
                this.RadPanelBar1.Items[0].Text = _languageClass.GetLanguageConversion("Select_Columns_To_Run_Report");
                this.RadPanelBar1.Items[1].Text = _languageClass.GetLanguageConversion("Report_Filters");
                this.RadPanelBar1.Items[2].Text = _languageClass.GetLanguageConversion("Save_Report_Options");
            }
            else
            {
                switch (this.RadPanelBar1.Items.Count)
                {
                    case 3:
                    case 2:
                        this.RadPanelBar1.Items[2].Text = _languageClass.GetLanguageConversion("Save_Report_Options");
                        goto case 1;
                    case 1:
                        this.RadPanelBar1.Items[1].Text = _languageClass.GetLanguageConversion("Report_Filters");
                        goto case 0;
                    case 0:
                        this.RadPanelBar1.Items[0].Text = _languageClass.GetLanguageConversion("Select_Columns_To_Run_Report");
                        break;
                }
            }

            if (this.chkColumns.Items.Count >= 15)
            {
                this.chkColumns.Items[0].Text = this.objLangClass.GetLanguageConversion("Inventory_Code");
                this.chkColumns.Items[1].Text = this.objLangClass.GetLanguageConversion("Inventory_Name");
                this.chkColumns.Items[2].Text = this.objLangClass.GetLanguageConversion("Supplier");
                this.chkColumns.Items[3].Text = this.objLangClass.GetLanguageConversion("Cost");
                this.chkColumns.Items[4].Text = this.objLangClass.GetLanguageConversion("In_Stock_Qty");
                this.chkColumns.Items[5].Text = this.objLangClass.GetLanguageConversion("Quantity_Used");
                this.chkColumns.Items[6].Text = this.objLangClass.GetLanguageConversion("Packed_In");
                this.chkColumns.Items[7].Text = this.objLangClass.GetLanguageConversion("Pack_Price");
                this.chkColumns.Items[8].Text = this.objLangClass.GetLanguageConversion("Created_On");
                this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Weight");
                this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Coating_Type");
                this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Colour");
                this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Item_Paper_Size");
                this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Item_Custom_Size");
                this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Caliper");
                this.chkColumns.Items[0].Enabled = false;
            }
            else
            {
                switch (this.chkColumns.Items.Count)
                {
                    case 15:
                    case 14:
                        this.chkColumns.Items[14].Text = this.objLangClass.GetLanguageConversion("Caliper");
                        goto case 13;
                    case 13:
                        this.chkColumns.Items[13].Text = this.objLangClass.GetLanguageConversion("Item_Custom_Size");
                        goto case 12;
                    case 12:
                        this.chkColumns.Items[12].Text = this.objLangClass.GetLanguageConversion("Item_Paper_Size");
                        goto case 11;
                    case 11:
                        this.chkColumns.Items[11].Text = this.objLangClass.GetLanguageConversion("Colour");
                        goto case 10;
                    case 10:
                        this.chkColumns.Items[10].Text = this.objLangClass.GetLanguageConversion("Coating_Type");
                        goto case 9;
                    case 9:
                        this.chkColumns.Items[9].Text = this.objLangClass.GetLanguageConversion("Weight");
                        goto case 8;
                    case 8:
                        this.chkColumns.Items[8].Text = this.objLangClass.GetLanguageConversion("Created_On");
                        goto case 7;
                    case 7:
                        this.chkColumns.Items[7].Text = this.objLangClass.GetLanguageConversion("Pack_Price");
                        goto case 6;
                    case 6:
                        this.chkColumns.Items[6].Text = this.objLangClass.GetLanguageConversion("Packed_In");
                        goto case 5;
                    case 5:
                        this.chkColumns.Items[5].Text = this.objLangClass.GetLanguageConversion("Quantity_Used");
                        goto case 4;
                    case 4:
                        this.chkColumns.Items[4].Text = this.objLangClass.GetLanguageConversion("In_Stock_Qty");
                        goto case 3;
                    case 3:
                        this.chkColumns.Items[3].Text = this.objLangClass.GetLanguageConversion("Cost");
                        goto case 2;
                    case 2:
                        this.chkColumns.Items[2].Text = this.objLangClass.GetLanguageConversion("Supplier");
                        goto case 1;
                    case 1:
                        this.chkColumns.Items[1].Text = this.objLangClass.GetLanguageConversion("Inventory_Name");
                        goto case 0;
                    case 0:
                        this.chkColumns.Items[0].Text = this.objLangClass.GetLanguageConversion("Inventory_Code");
                        this.chkColumns.Items[0].Enabled = false;
                        break;
                }
            }

            if (this.pagename.ToString().ToLower().Trim() != "report")
            {
                string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../warehouse/warehouse.aspx?type=inventory class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Warehouse_Inventory"), " </a>" };
                base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Invertory_Report")));
            }
            else
            {
                base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Invertory_Report")));
            }
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Text.ToLower().Trim() == "colour")
                {
                    this.chkColumns.Items[i].Text = this.objpage.GetRegionalSettings(Convert.ToInt32(this.Session["companyid"].ToString()), "colour");
                }
            }
            this.chkColumns.Items[0].Enabled = false;
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.txtName.Attributes.Add("autocomplete", "off");
            this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
            this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("select CompanyName from tb_Company where CompanyID=", this.CompanyID, " and isdelete=0"), sqlConnection);
            this.CompanyName = (string)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            commonClass _commonClass = this.objJava;
            DateTime now = DateTime.Now;
            DateTime dateTime = _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            commonClass _commonClass1 = this.objJava;
            DateTime now1 = DateTime.Now;
            string str = _commonClass1.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
            char[] chrArray = new char[] { ' ' };
            this.day = str.Split(chrArray);
            this.spn_daily.InnerText = string.Concat("(", this.day[0].ToString(), ")");
            commonClass _commonClass2 = this.objJava;
            string str1 = dateTime.AddDays(-1).ToString();
            char[] chrArray1 = new char[] { ' ' };
            string str2 = _commonClass2.Eprint_return_Date_Before_View(str1.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray2 = new char[] { ' ' };
            this.yestday = str2.Split(chrArray2);
            this.spn_yest.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
            DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime dateTime3 = dateTime2.AddMonths(1).AddDays(-1);
            string str3 = this.objJava.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray3 = new char[] { ' ' };
            this.stdate = str3.Split(chrArray3);
            string str4 = this.objJava.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray4 = new char[] { ' ' };
            this.endate = str4.Split(chrArray4);
            HtmlGenericControl spnMonth = this.spn_month;
            string[] strArrays = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
            spnMonth.InnerText = string.Concat(strArrays);
            try
            {
                string[] strArrays1 = this.CurrentQuater().Split(new char[] { ',' });
                string str5 = this.objJava.Eprint_return_Date_Before_View(strArrays1[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray5 = new char[] { ' ' };
                this.stquardate = str5.Split(chrArray5);
                string str6 = this.objJava.Eprint_return_Date_Before_View(strArrays1[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray6 = new char[] { ' ' };
                this.enquardate = str6.Split(chrArray6);
                HtmlGenericControl spnQuarter = this.spn_quarter;
                string[] strArrays2 = new string[] { "(", this.stquardate[0].ToString(), " to ", this.enquardate[0].ToString(), ")" };
                spnQuarter.InnerText = string.Concat(strArrays2);
            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.LastQuarter().Split(new char[] { ',' });
                string str7 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastquardate = str7.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastquardate = str8.Split(chrArray8);
                HtmlGenericControl spnLastque = this.spn_lastque;
                string[] strArrays4 = new string[] { "(", this.stlastquardate[0].ToString(), " to ", this.enlastquardate[0].ToString(), ")" };
                spnLastque.InnerText = string.Concat(strArrays4);
            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastweek().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastweek = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastweek = str8.Split(chrArray8);
                HtmlGenericControl spnLastweek = this.spn_lastweek;
                string[] strArrays4 = new string[] { "(", this.stlastweek[0].ToString(), " to ", this.enlastweek[0].ToString(), ")" };
                spnLastweek.InnerText = string.Concat(strArrays4);


            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastmonth().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastmonth = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastmonth = str8.Split(chrArray8);
                HtmlGenericControl spnLastmonth = this.spn_lastmonth;
                string[] strArrays4 = new string[] { "(", this.stlastmonth[0].ToString(), " to ", this.enlastmonth[0].ToString(), ")" };
                spnLastmonth.InnerText = string.Concat(strArrays4);

            }
            catch
            {
            }
            try
            {
                string[] strArrays3 = this.Lastyear().Split(new char[] { ',' });
                string str71 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray7 = new char[] { ' ' };
                this.stlastyear = str71.Split(chrArray7);
                string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray8 = new char[] { ' ' };
                this.enlastyear = str8.Split(chrArray8);
                HtmlGenericControl spnLastyear = this.spn_lastyear;
                string[] strArrays4 = new string[] { "(", this.stlastyear[0].ToString(), " to ", this.enlastyear[0].ToString(), ")" };
                spnLastyear.InnerText = string.Concat(strArrays4);

            }
            catch
            {
            }


            string[] strArrays5 = this.HalfFiscalYear().Split(new char[] { ',' });
            string str9 = this.objJava.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray9 = new char[] { ' ' };
            this.from_halffiscalyear = str9.Split(chrArray9);
            string str10 = this.objJava.Eprint_return_Date_Before_View(strArrays5[1].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray10 = new char[] { ' ' };
            this.to_halffiscalyear = str10.Split(chrArray10);
            HtmlGenericControl spanHalfyear = this.span_halfyear;
            string[] strArrays6 = new string[] { "(", this.from_halffiscalyear[0].ToString(), " to ", this.to_halffiscalyear[0].ToString(), ")" };
            spanHalfyear.InnerText = string.Concat(strArrays6);
            string[] strArrays7 = this.CurrentFiscalYear().Split(new char[] { ',' });
            string str11 = this.objJava.Eprint_return_Date_Before_View(strArrays7[0].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray11 = new char[] { ' ' };
            this.startyear = str11.Split(chrArray11);
            string str12 = this.objJava.Eprint_return_Date_Before_View(strArrays7[1].ToString(), this.CompanyID, this.UserID, false);
            char[] chrArray12 = new char[] { ' ' };
            this.endyear = str12.Split(chrArray12);
            HtmlGenericControl spnYear = this.spn_year;
            string[] strArrays8 = new string[] { "(", this.startyear[0].ToString(), " to ", this.endyear[0].ToString(), ")" };
            spnYear.InnerText = string.Concat(strArrays8);
            this.txtName.Attributes.Add("autocomplete", "off");
            if (!base.IsPostBack)
            {
                this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'supplier','", this.CompanyID, "','1',event);"));
                this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'supplier','", this.CompanyID, "','1',event);"));
            }
            this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
            this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
            this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
            this.btnfilter.ToolTip = this.objLangClass.GetLanguageConversion("Back_To_Search_Option");
            this.btnExport.ToolTip = this.objLangClass.GetLanguageConversion("Export");
            this.btngo.ToolTip = this.objLangClass.GetLanguageConversion("GoTo");
            if (!base.IsPostBack)
            {
                this.obj.Bind_Stock_Category(this.ddlInvCategory, this.CompanyID, "--- Any ---");
                int _index = this.ddlInvCategory.Items.Count - 1;
                this.ddlInvCategory.Items.Insert(_index + 1, new ListItem("All","0"));
                this.pnlDateOption_Disable.Visible = true;
                this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox = this.txtFrom;
                commonClass _commonClass3 = this.objJava;
                DateTime now2 = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(now2.ToShortDateString(), this.CompanyID, this.UserID, true);
                this.txtTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                TextBox textBox1 = this.txtTo;
                commonClass _commonClass4 = this.objJava;
                DateTime now3 = DateTime.Now;
                textBox1.Text = _commonClass4.Eprint_return_Date_Before_View(now3.ToShortDateString(), this.CompanyID, this.UserID, true);
            }
            this.usrPaging.Visible = false;
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            if (!base.IsPostBack)
            {
                this.Session["DeleteMsg"] = null;
                this.Session["SaveAsNew"] = null;
                this.pnlReports.Visible = true;
            }
            inventory_report.divVisibility = "none";
            inventory_report.imgVisibility = "block";
            this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
            this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
            this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
            this.usrReportsave.OnPageIndexChanged += new OnPageIndexChangedClick(this.usrReportsave_OnPageIndexChanged);
            this.usrReportsave.OnPageSizeChanged += new OnPageSizeChangedClick(this.usrReportsave_OnPageSizeChanged);
            if (!base.IsPostBack)
            {
                ListItem[] listItem = new ListItem[] { new ListItem(string.Concat("--", _languageClass.GetLanguageConversion("Any"), "--"), "1"), new ListItem(string.Concat(_languageClass.GetLanguageConversion("Below"), this.objJava.GetCurrencyinRequiredFormate("", true), "500"), "2"), new ListItem(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), "501-", this.objJava.GetCurrencyinRequiredFormate("", true), "2500"), "3"), new ListItem(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), "2501-", this.objJava.GetCurrencyinRequiredFormate("", true), "5000"), "4"), new ListItem(string.Concat(_languageClass.GetLanguageConversion("Above"), this.objJava.GetCurrencyinRequiredFormate("", true), "5000"), ">5") };
                this.ddlEstimateRange.Items.AddRange(listItem);
                this.ddlEstimateRange.DataBind();
            }
        }
        private void paging_OnPageChange(int PageNumber1)
        {
            if (PageNumber1 <= 0)
            {
                this.GridEstReport.PageIndex = PageNumber1;
            }
            else
            {
                this.GridEstReport.PageIndex = PageNumber1 - 1;
            }
            this.GetPageBind(PageNumber1);
            inventory_report.imgVisibility = "none";
            inventory_report.divVisibility = "none";
            this.GridEstReport.DataBind();
        }

        public string Lastweek()
        {
            DateTime today = DateTime.Today;
            DayOfWeek currentDayOfWeek = today.DayOfWeek;

            // Calculate the start date of last week
            DateTime lastWeekStartDate = today.AddDays(-(int)currentDayOfWeek - 6);

            // Calculate the end date of last week
            DateTime lastWeekEndDate = lastWeekStartDate.AddDays(6);

            return lastWeekStartDate.ToString() + "," + lastWeekEndDate.ToString();
        }
        public string Lastmonth()
        {
            DateTime today = DateTime.Today;

            // Get the first day of the current month
            DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);

            // Get the last day of the previous month
            DateTime lastDayOfLastMonth = firstDayOfThisMonth.AddDays(-1);

            // Get the first day of the previous month
            DateTime firstDayOfLastMonth = new DateTime(lastDayOfLastMonth.Year, lastDayOfLastMonth.Month, 1);



            return firstDayOfLastMonth.ToString() + "," + lastDayOfLastMonth.ToString();
        }
        public string Lastyear()
        {
            DateTime currentDate = DateTime.Today;

            // Get start date of last year
            DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);

            // Get end date of last year
            DateTime lastYearEndDate = new DateTime(currentDate.Year - 1, 12, 31);


            return lastYearStartDate.ToString() + "," + lastYearEndDate.ToString();
        }

        private void ReportDetails(int ReportID)
        {
            string empty = string.Empty;
            string str = string.Empty;
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
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                empty = row["Columns"].ToString();
                if (row["Status"].ToString() != "0")
                {
                    try
                    {
                        this.ddlInvCategory.SelectedValue = row["status"].ToString();
                    }
                    catch
                    {
                        this.ddlInvCategory.SelectedIndex = 0;
                    }
                }
                DataTable dataTable = this.obj.settings_inventoryproperties_name_select_by_categoryID(this.CompanyID, Convert.ToInt32(this.ddlInvCategory.SelectedValue));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    this.PropertyValue = dataRow["Properties"].ToString();
                    string[] strArrays = new string[] { "^" };
                    string[] strArrays1 = this.PropertyValue.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        if (strArrays1[j].ToString().ToLower() == "weight")
                        {
                            this.chkColumns.Items[8].Enabled = true;
                        }
                        if (strArrays1[j].ToString().ToLower() == "coated")
                        {
                            this.chkColumns.Items[9].Enabled = true;
                        }
                        if (strArrays1[j].ToString().ToLower() == "color")
                        {
                            this.chkColumns.Items[10].Enabled = true;
                        }
                        if (strArrays1[j].ToString().ToLower() == "papersize")
                        {
                            this.chkColumns.Items[11].Enabled = true;
                        }
                        if (strArrays1[j].ToString().ToLower() == "itemcustomsize")
                        {
                            this.chkColumns.Items[12].Enabled = true;
                        }
                        if (strArrays1[j].ToString().ToLower() == "caliper")
                        {
                            this.chkColumns.Items[14].Enabled = true;
                        }
                    }
                }
                string[] strArrays2 = empty.Split(new char[] { 'µ' });
                for (int k = 0; k < (int)strArrays2.Length; k++)
                {
                    if (strArrays2[k] == "InventoryCode")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (strArrays2[k] == "InventoryName")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (strArrays2[k] == "Supplierid")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (strArrays2[k] == "Cost")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (strArrays2[k] == "InStock")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (strArrays2[k] == "QuantityUsed")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (strArrays2[k] == "PackedIn")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (strArrays2[k] == "PackedPrice")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (strArrays2[k] == "createddate")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                    else if (strArrays2[k] == "basisweight")
                    {
                        this.chkColumns.Items[9].Selected = true;
                    }
                    else if (strArrays2[k] == "Coated")
                    {
                        this.chkColumns.Items[10].Selected = true;
                    }
                    else if (strArrays2[k] == "Colour")
                    {
                        this.chkColumns.Items[11].Selected = true;
                    }
                    else if (strArrays2[k] == "itempapersize")
                    {
                        this.chkColumns.Items[12].Selected = true;
                    }
                    else if (strArrays2[k] == "itemcustomsize")
                    {
                        this.chkColumns.Items[13].Selected = true;
                    }
                    else if (strArrays2[k] == "Caliper")
                    {
                        this.chkColumns.Items[14].Selected = true;
                    }
                }
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = base.SpecialDecode(row["ReportName"].ToString());
                }
                this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                if (row["SearchKeyword"].ToString() != "")
                {
                    this.txtFreetext.Text = row["SearchKeyword"].ToString();
                }
                if (Convert.ToInt32(row["PriceRange"]) != 0)
                {
                    if (row["PriceRange"].ToString() != "5001")
                    {
                        this.ddlEstimateRange.SelectedValue = row["PriceRange"].ToString();
                    }
                    else
                    {
                        this.ddlEstimateRange.SelectedValue = ">5";
                    }
                }
                if (Convert.ToInt32(row["EstNoAssignedValue"]) != 1)
                {
                    this.chkEstimate.Checked = false;
                }
                else
                {
                    this.chkEstimate.Checked = true;
                }
                if (row["CompanyName"].ToString() != "")
                {
                    this.txtName.Text = base.SpecialDecode(row["CompanyName"].ToString());
                }
                if (Convert.ToInt32(row["IsCreatedDate"]) != 1)
                {
                    this.chkDateOption.Checked = false;
                }
                else
                {
                    this.chkDateOption.Checked = true;
                    if (row["CreatedDateType"].ToString().ToLower().Trim() == "t")
                    {
                        this.rdlDate.SelectedValue = "daily";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "y")
                    {
                        this.rdlDate.SelectedValue = "yesterday";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "cm")
                    {
                        this.rdlDate.SelectedValue = "thismonth";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "cq")
                    {
                        this.rdlDate.SelectedValue = "thisquarter";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "lq")
                    {
                        this.rdlDate.SelectedValue = "lastquater";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "cy")
                    {
                        this.rdlDate.SelectedValue = "thisyear";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "hy")
                    {
                        this.rdlDate.SelectedValue = "halfyear";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "lw")
                    {
                        this.rdlDate.SelectedValue = "lastweek";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "lm")
                    {
                        this.rdlDate.SelectedValue = "lastmonth";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() == "ly")
                    {
                        this.rdlDate.SelectedValue = "lastyear";
                    }
                    else if (row["CreatedDateType"].ToString().ToLower().Trim() != "td")
                    {
                        if (row["CreatedDateType"].ToString().ToLower().Trim() != "dr")
                        {
                            continue;
                        }
                        this.rdlDate.SelectedValue = "daterange";
                        this.txtFrom.Enabled = true;
                        this.txtTo.Enabled = true;
                        this.txtFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtTo.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.rdlDate.SelectedValue = "tilldate";
                    }
                }
            }
        }

        private void RunReportOnClick()
        {
            this.btnUpdateExisting.Visible = true;
            this.btnRunReport.Visible = true;
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.btnSaveRun.Text = "Save and Run";
            this.txt1.Text = "";
            int num = 0;
            inventory_report.imgVisibility = "none";
            inventory_report.divVisibility = "none";
            this.divtab.Visible = false;
            this.btnfilter.Visible = true;
            if ((new BaseClass()).ReturnRoles_Privileges_ReportStatus("inventory", "exportreport").Trim().ToLower() != "false")
            {
                this.btnExport.Visible = true;
            }
            else
            {
                this.btnExport.Visible = false;
            }
            this.divtoolbar.Visible = true;
            this.txt1.Visible = true;
            this.btngo.Visible = true;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    num = 1;
                }
            }
            if (num != 1)
            {
                this.GridEstReport.Visible = false;
                this.div_Total.Visible = false;
                this.btnExport.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                this.divtoolbar.Visible = true;
                return;
            }
            DataSet estimateData = this.GetEstimateData(1);
            this.lblTotalRecords.Text = estimateData.Tables[1].Rows[0][0].ToString();
            if (estimateData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.divtoolbar.Visible = true;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            if (Convert.ToInt32(estimateData.Tables[1].Rows[0][0].ToString()) > 100)
            {
                this.GridEstReport.Visible = true;
                this.div_Total.Visible = true;
                this.pnlEmptyRecords.Visible = false;
                this.GridEstReport.DataSource = estimateData;
                this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
                this.GridEstReport.DataBind();
                this.usrPaging.Visible = true;
                pagingreport.intCurrentPage = this.PageNumber;
                pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                this.usrPaging.CreatePaging();
                this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                this.CallPagingBtn_ScrollGrid(this.usrPaging);
                return;
            }
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
            ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = true;
            this.pnlEmptyRecords.Visible = false;
            this.GridEstReport.DataSource = estimateData;
            this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridEstReport_RowDataBound);
            this.GridEstReport.DataBind();
            this.usrPaging.Visible = true;
            pagingreport.intCurrentPage = this.PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(estimateData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        private void SaveReports(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            string empty = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (i != 0)
                    {
                        str = this.chkColumns.Items[i].Value;
                        inventory_report warehouseInventoryReport = this;
                        warehouseInventoryReport.ColumnNames = string.Concat(warehouseInventoryReport.ColumnNames, "µ", str);
                    }
                    else
                    {
                        str = this.chkColumns.Items[i].Value;
                        this.ColumnNames = str;
                    }
                }
            }
            stringBuilder.Append(" Columns");
            stringBuilder1.Append(string.Concat(" '", this.ColumnNames, "'"));
            stringBuilder.Append(",Status");
            stringBuilder1.Append(string.Concat(",", this.ddlInvCategory.SelectedValue));
            stringBuilder.Append(" ,EstCount");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstTotal");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstAverage");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstMaximum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstMinimum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,EstConvertedCount");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetTotal");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetAverage");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetMaximum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,NetMinimum");
            stringBuilder1.Append(" ,0");
            stringBuilder.Append(" ,ReportType,GroupedBy");
            stringBuilder1.Append(" ,'',0");
            if (this.txtFreetext.Text != "")
            {
                stringBuilder.Append(" ,SearchKeyword");
                stringBuilder1.Append(string.Concat(" ,'", base.SpecialEncode(this.txtFreetext.Text), "'"));
            }
            if (this.ddlEstimateRange.SelectedIndex == 0)
            {
                stringBuilder.Append(" ,PriceRange");
                stringBuilder1.Append(" ,0");
            }
            else
            {
                stringBuilder.Append(" ,PriceRange");
                if (this.ddlEstimateRange.SelectedValue != ">5")
                {
                    stringBuilder1.Append(string.Concat(" ,", this.ddlEstimateRange.SelectedValue));
                }
                else
                {
                    stringBuilder1.Append(" ,5001");
                }
            }
            if (!this.chkEstimate.Checked)
            {
                stringBuilder.Append(" ,EstNoAssignedValue");
                stringBuilder1.Append(", 0");
            }
            else
            {
                stringBuilder.Append(" ,EstNoAssignedValue");
                stringBuilder1.Append(", 1");
            }
            if (this.txtName.Text != "")
            {
                stringBuilder.Append(" ,CompanyName");
                stringBuilder1.Append(string.Concat(" ,'", base.SpecialEncode(this.txtName.Text), "'"));
            }
            if (!this.chkDateOption.Checked)
            {
                stringBuilder.Append(" ,IsCreatedDate,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                stringBuilder1.Append(" ,0,'','',''");
            }
            else
            {
                stringBuilder.Append(" ,IsCreatedDate");
                stringBuilder1.Append(" ,1");
                if (this.rdlDate.SelectedValue == "daily")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 't','',''");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'y','',''");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cm','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cq','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lq','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'cy','',''");
                }
                else if (this.rdlDate.SelectedValue == "halfyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'hy','',''");
                }
                else if (this.rdlDate.SelectedValue == "tilldate")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'td','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lw','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'lm','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    stringBuilder1.Append(", 'ly','',''");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    stringBuilder.Append(" ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    string[] strArrays = new string[] { ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtTo.Text), "'" };
                    stringBuilder1.Append(string.Concat(strArrays));
                }
            }
            stringBuilder.Append(" ,EstConvertionDate,EstConvertionDateType,EstConvertionDateFrom,EstConvertionDateTo,ApplyDates");
            stringBuilder1.Append(" ,0,'','','',0");
            if (this.txtSaveReports.Text != "")
            {
                stringBuilder.Append(" ,ReportName");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtSaveReports.Text), "'"));
            }
            if (this.txtDescription.Text != "")
            {
                stringBuilder.Append(" ,Description");
                stringBuilder1.Append(string.Concat(", '", base.SpecialEncode(this.txtDescription.Text), "'"));
            }
            stringBuilder.Append(" ,PageName,CompanyID,UserID");
            object[] num = new object[] { ", '", this.pg, "',", Convert.ToInt32(this.Session["companyid"].ToString()), ",", Convert.ToInt32(this.Session["UserID"].ToString()) };
            stringBuilder1.Append(string.Concat(num));
            if (value == "Save")
            {
                object[] objArray = new object[] { "Insert into tb_Reports_Save(", stringBuilder, ") Values (", stringBuilder1, ")" };
                empty = string.Concat(objArray);
            }
            else if (value == "Update")
            {
                empty = string.Concat("delete tb_reports_save where ReportID=", Convert.ToInt32(this.hdn_reportID.Value));
                object[] objArray1 = new object[] { " ", empty, "Insert into tb_Reports_Save(", stringBuilder, ") Values (", stringBuilder1, ")" };
                empty = string.Concat(objArray1);
                this.hdn_reportID.Value = "";
            }
            SqlCommand sqlCommand = new SqlCommand(empty, this.objJava.openConnection())
            {
                CommandType = CommandType.Text
            };
            sqlCommand.ExecuteNonQuery();
            this.objJava.closeConnection();
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
            this.Session["SaveAsNew"] = null;
        }

        private void usrReportsave_OnEditClick(int ReportID)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.Session["SaveAsNew"] = "SaveAsNew";
            this.pnlSavedReports.Visible = false;
            inventory_report.divVisibility = "none";
            inventory_report.imgVisibility = "block";
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.div_searchres.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            this.btnUpdateExisting.Visible = true;
            this.btnRunReport.Visible = false;
            this.btnSaveRun.Text = "Save as New";
            for (int i = 8; i < this.chkColumns.Items.Count; i++)
            {
                this.chkColumns.Items[i].Enabled = false;
                this.chkColumns.Items[i].Selected = false;
            }
            this.ReportDetails(ReportID);
            this.hdn_reportID.Value = ReportID.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "selected", "javascript:OnEditReport();", true);
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
            this.Session["DeleteMsg"] = null;
            this.ReportDetails(ReportID);
            this.RunReportOnClick();
            this.hdn_reportID.Value = ReportID.ToString();
        }
    }
}