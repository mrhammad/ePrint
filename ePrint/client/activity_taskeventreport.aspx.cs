using ePrint.usercontrol;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using nmsView;
using ePrint.ePrintUtilities;
namespace ePrint.client
{
    public partial class activity_taskeventreport : BaseClass, IRequiresSessionState
    {
        public languageClass objLangClass = new languageClass();

        public string pagename = string.Empty;

        private BaseClass objBase = new BaseClass();

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public string VersionNumber = ConnectionClass.VersionNumber;

        public commonClass objJava = new commonClass();

        public int CompanyID;

        public int UserID;

        public int PageSize = 100;
        public string[] yestday;

        public string[] stdate;

        public string[] endate;

        public string[] stquardate;

        public string[] enquardate;

        public string[] stlastquardate;

        public string[] enlastquardate;

        public string[] stlastweek;

        public string[] enlastweek;

        public string[] stlastmonth;

        public string[] enlastmonth;

        public string[] stlastyear;

        public string[] enlastyear;

        public string cs = string.Empty;

        private int PageNumber = 1;

        public string CompanyName = string.Empty;

        public languageClass objlang = new languageClass();

        public string ColumnNames = string.Empty;

        public string strColoumns = string.Empty;

        public string SaveType = string.Empty;

        public int ReportID;

        public string DateFormat = string.Empty;

        public string FreeTextColoumn = string.Empty;

        public string[] day;

        public string flag_DateTime = string.Empty;

        public int cellvalue_DateTime;

        public string export = string.Empty;

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

        public activity_taskeventreport()
        {
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
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            base.Response.Redirect(string.Concat(this.strSitepath, "client/client_view.aspx"));
        }

        public void btnExport_New_OnClick(object sender, EventArgs e)
        {
            this.export = "true";
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
            DataSet activityTaskEventData = this.GetActivityTaskEventData(0);
            DataTable item = activityTaskEventData.Tables[0];
            if (item != null)
            {
                string empty = string.Empty;
                foreach (DataRow row in item.Rows)
                {
                    if (!row.Table.Columns.Contains("DateAndTime"))
                    {
                        continue;
                    }
                    try
                    {
                        string[] strArrays = row["DateAndTime"].ToString().Split(new char[] { '$' });
                        string str = this.objJava.Eprint_return_Date_Before_View(strArrays[0].ToString(), this.CompanyID, this.UserID, false);
                        row["DateAndTime"] = string.Concat(str, " ", strArrays[1]);
                    }
                    catch
                    {
                    }
                }
            }
            this.GetActivityTaskEventData(0);
            DataTable languageConversion = activityTaskEventData.Tables[0];
            if (languageConversion.Columns.Contains("clientID"))
            {
                languageConversion.Columns.Remove("clientID");
            }
            HttpContext current = HttpContext.Current;
            current.Response.Clear();
            current.Response.ClearHeaders();
            string empty1 = string.Empty;
            empty1 = string.Concat(empty1, "<html><body><table  border='1'>");
            empty1 = string.Concat(empty1, "<tr>");
            foreach (DataColumn column in languageConversion.Columns)
            {
                for (int j = 0; j < languageConversion.Columns.Count; j++)
                {
                    if (languageConversion.Columns[j].ColumnName == "CompanyName")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Company_Name");
                    }
                    if (languageConversion.Columns[j].ColumnName == "ContactName")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    if (languageConversion.Columns[j].ColumnName == "SalesPerson")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Subject")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Subject");
                    }
                    if (languageConversion.Columns[j].ColumnName == "AssignedTo")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Assigned_To");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Description")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (languageConversion.Columns[j].ColumnName == "DateAndTime")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Task_date_time");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Status")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Status");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Priority")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Priority");
                    }
                }
                empty1 = string.Concat(empty1, "<th>");
                empty1 = string.Concat(empty1, column.ColumnName);
                empty1 = string.Concat(empty1, "</th>");
            }
            empty1 = string.Concat(empty1, "</tr>");
            empty1 = string.Concat(empty1, Environment.NewLine);
            foreach (DataRow dataRow in languageConversion.Rows)
            {
                empty1 = string.Concat(empty1, "<tr>");
                for (int k = 0; k < languageConversion.Columns.Count; k++)
                {
                    empty1 = string.Concat(empty1, "<td>");
                    string str1 = dataRow.ItemArray[k].ToString();
                    str1 = Regex.Replace(str1, "'", "ˈ");
                    empty1 = string.Concat(empty1, str1);
                    empty1 = string.Concat(empty1, "</td>");
                }
                empty1 = string.Concat(empty1, "</tr>");
                empty1 = string.Concat(empty1, Environment.NewLine);
            }
            empty1 = string.Concat(empty1, "</table></body></html>");
            string str2 = "ActivityTaskEvent_Excel.xls";
            current.Response.ContentType = "application/vnd.ms-excel";
            current.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=\"", str2, "\""));
            current.Response.ContentEncoding = Encoding.Unicode;
            base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            current.Response.Write(empty1);
            current.Response.End();
            current.Response.Close();
            current.Response.Flush();
        }
        private DataTable SetTaskReportColumns(DataSet TaskData)
        {
            DataSet activityTaskEventData = TaskData;
            DataTable item = activityTaskEventData.Tables[0];
            if (item != null)
            {
                string empty = string.Empty;
                foreach (DataRow row in item.Rows)
                {
                    if (!row.Table.Columns.Contains("DateAndTime"))
                    {
                        continue;
                    }
                    try
                    {
                        string[] strArrays = row["DateAndTime"].ToString().Split(new char[] { '$' });
                        string str = this.objJava.Eprint_return_Date_Before_View(strArrays[0].ToString(), this.CompanyID, this.UserID, false);
                        row["DateAndTime"] = string.Concat(str, " ", strArrays[1]);
                    }
                    catch
                    {
                    }
                }
            }
            this.GetActivityTaskEventData(0);
            DataTable languageConversion = activityTaskEventData.Tables[0];
            if (languageConversion.Columns.Contains("clientID"))
            {
                languageConversion.Columns.Remove("clientID");
            }
            foreach (DataColumn column in languageConversion.Columns)
            {
                for (int j = 0; j < languageConversion.Columns.Count; j++)
                {
                    if (languageConversion.Columns[j].ColumnName == "CompanyName")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Company_Name");
                    }
                    if (languageConversion.Columns[j].ColumnName == "ContactName")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    if (languageConversion.Columns[j].ColumnName == "SalesPerson")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Subject")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Subject");
                    }
                    if (languageConversion.Columns[j].ColumnName == "AssignedTo")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Assigned_To");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Description")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Description");
                    }
                    if (languageConversion.Columns[j].ColumnName == "DateAndTime")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Task_date_time");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Status")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Status");
                    }
                    if (languageConversion.Columns[j].ColumnName == "Priority")
                    {
                        languageConversion.Columns[j].ColumnName = this.objLangClass.GetLanguageConversion("Priority");
                    }
                }
            }
            return languageConversion;
        }
        public void btnExport_vivid_OnClick(object sender, EventArgs e)
        {
            this.export = "true";
            this.Session["DeleteMsg"] = null;
            string value = this.hdnInnerHtml.Value;
            string str = "ActivityTaskEvent_Presentation.xls";
            base.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            base.Response.Clear();
            base.Response.Charset = "";
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.ContentEncoding = Encoding.Unicode;
            base.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StringWriter());
            base.Response.AppendHeader("content-disposition", string.Concat("attachment;filename=\"", str, "\""));
            this.EnableViewState = false;
            base.Response.Write("\r\n");
            base.Response.Write(value);
            base.Response.End();
        }

        protected void btnfilter_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = "selectoptions";
            this.divtab.Visible = true;
            this.pnlReports.Visible = true;
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            if (this.Session["SaveAsNew"] != null)
            {
                this.btnSaveRun.Text = "Save and Run";
            }
            else
            {
                this.btnSaveRun.Text = "Save as New";
            }
            BaseClass baseClass = new BaseClass();
            this.btnExportPPT.Visible = true;
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:GetCallSelect();", true);
        }

        public void btngo_OnClick(object sender, EventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            if (this.txt1.Text != "")
            {
                try
                {
                    this.paging_OnPageChange(Convert.ToInt32(this.txt1.Text));
                }
                catch
                {
                    this.paging_OnPageChange(Convert.ToInt32("1"));
                }
            }
        }

        public void btnRunReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.Session["DeleteMsg"] = null;
                this.btnUpdateExisting.Visible = false;
                this.btnRunReport.Visible = true;
                this.btnSaveRun.Text = "Save and Run";
                this.Panel1.Visible = false;
                int num = 0;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.divtab.Visible = false;
                this.btnfilter.Visible = true;
                BaseClass baseClass = new BaseClass();
                this.btnExport.Visible = true;
                this.divtoolbar.Visible = true;
                this.txt1.Visible = true;
                this.btngo.Visible = true;
                for (int i = 0; i < this.chkColumns.Items.Count; i++)
                {
                    foreach (ListItem item in this.chkColumns.Items)
                    {
                        if (!item.Selected)
                        {
                            continue;
                        }
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
                }
                else
                {
                    DataSet activityTaskEventData = this.GetActivityTaskEventData(1);
                    this.lblTotalRecords.Text = activityTaskEventData.Tables[1].Rows[0][0].ToString();
                    if (activityTaskEventData.Tables[0].Rows.Count == 0)
                    {
                        this.pnlEmptyRecords.Visible = true;
                        this.GridEstReport.Visible = false;
                        this.btnExport.Visible = false;
                        this.btnExportPPT.Visible = false;
                        this.divtoolbar.Visible = true;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                    }
                    else if (Convert.ToInt32(activityTaskEventData.Tables[1].Rows[0][0].ToString()) > 100)
                    {
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetTaskReportColumns(activityTaskEventData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridActivityTaskEventReport_RowDataBound);
                        this.GridEstReport.DataBind();
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activityTaskEventData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                        {
                            this.GridEstReport.Visible = false;
                            this.usrPaging.Visible = false;
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                        }
                    }
                    else
                    {
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetTaskReportColumns(activityTaskEventData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridActivityTaskEventReport_RowDataBound);
                        this.GridEstReport.DataBind();
                        this.btnExportPPT.Visible = true;
                        this.btnExport.Visible = true;
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activityTaskEventData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                        {
                            this.btnExport.Visible = false;
                            this.GridEstReport.Visible = false;
                            this.usrPaging.Visible = false;
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                        }
                    }
                }
            }
            catch
            {
            }
            this.pnlMask.Visible = false;
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
                sqlCommand.Parameters.AddWithValue("@Pagename", "activitytaskeventreport");
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
            //if (this.GridEstReport.PageIndex == 1 || this.GridEstReport.PageIndex == 0)
            //{
            //    linkButton5.Enabled = false;
            //    linkButton6.Enabled = false;
            //}
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

        private DataSet GetActivityTaskEventData(int PageNumber)
        {
            string[] strArrays;
            object[] companyID;
            string str;
            object empty;
            DataSet dataSet = new DataSet();
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
            string str8 = this.txtFreeText.Text.ToString();
            char[] chrArray = new char[] { ',' };
            str8.Split(chrArray);
            if (this.txtFreeText.Text != "" || this.txtFreeText.Text != null)
            {
                str5 = base.SpecialEncode(this.txtFreeText.Text);
                if (str5.Contains(" "))
                {
                    strArrays = new string[] { " " };
                    string[] strArrays1 = str5.Split(strArrays, StringSplitOptions.None);
                    str5 = strArrays1[0].ToString();
                    strArrays1[1].ToString();
                }
            }
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    foreach (ListItem item in this.chkColumns.Items)
                    {
                        if (!item.Selected)
                        {
                            continue;
                        }
                        if (item.Value == "CompanyName")
                        {
                            empty1 = "DISTINCT a.clientID,isnull(a.clientname ,'') as CompanyName";
                        }
                        if (item.Value == "ContactName")
                        {
                            empty1 = (empty1 == "" ? string.Concat(empty1, ",ISNULL((SELECT Isnull(RTRIM(LTRIM(IsNull(b.firstname, '')+' '+IsNull(b.Middlename,'')+' '+IsNull(b.lastname,''))),'') FROM tb_contact b WHERE b.contactId = t.ContactID and b.isDelete=0), '') as ContactName") : string.Concat(empty1, ", ISNULL(RTRIM(LTRIM(isnull(cc.firstname,'')+isnull(NULLIF(' '+cc.middlename,' '),'')+isnull(' '+cc.lastname,''))),'') as ContactName"));
                        }
                        if (item.Value == "SalesPerson")
                        {
                            if (empty1 == "")
                            {
                                empty1 = string.Concat("(Select  ISNULL(r.FirstName,'') + '' + ISNULL(r.LastName,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0) as SalesPerson ");
                            }
                            else
                            {
                                companyID = new object[] { empty1, ",(Select  ISNULL(r.FirstName,'') + '' + ISNULL(r.LastName,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0) as SalesPerson" };
                                empty1 = string.Concat(companyID);
                            }
                        }
                        if (item.Value == "Subject")
                        {
                            empty1 = (empty1 == "" ? "isnull(t.Subject,'') as Subject " : string.Concat(empty1, ",isnull(t.Subject,'') as Subject "));
                        }
                        if (item.Value == "AssignedTo")
                        {
                            if (empty1 == "")
                            {
                                empty1 = string.Concat("(Select isnull(r.firstname,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0)  as AssignedTo");
                            }
                            else
                            {
                                object[] objArray = new object[] { empty1, ",(Select isnull(r.firstname,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0)  as AssignedTo" };
                                empty1 = string.Concat(objArray);
                            }
                        }
                        if (item.Value == "Notes")
                        {
                            empty1 = (empty1 == "" ? "isnull(t.Description,'') as Description" : string.Concat(empty1, ",isnull(t.Description,'') as Description"));
                        }
                        if (item.Value == "DateAndTime")
                        {
                            empty1 = (empty1 == "" ? "((CONVERT(varchar(100) ,t.duedate,101))+'$'+ isnull(t.taskTime,'')) as DateAndTime" : string.Concat(empty1, ",((CONVERT(varchar(100) ,t.duedate,101))+'$'+ isnull(t.taskTime,'')) as DateAndTime"));
                        }
                        if (item.Value == "Status")
                        {
                            empty1 = (empty1 == "" ? "isnull(t.Calldetails ,'')as Status" : string.Concat(empty1, ",isnull(t.taskStatus ,'')as Status"));
                        }
                        if (item.Value != "Priority")
                        {
                            continue;
                        }
                        empty1 = (empty1 == "" ? "isnull(t.priority,'') as Priority" : string.Concat(empty1, ",isnull(t.priority,'') as Priority"));
                    }
                }
            }
            // filter report record
            viewClass _viewClass = new viewClass();
            if (this.pagename == "client")
            {
                string page = "client";
                str4 = _viewClass.showRecords_BaseOn_RolesAndPrivileges(page);
            }
            str1 = "from tb_Client a ";
            str1 = string.Concat(" ", str1, "left join tb_contact cc on a.clientid=cc.clientid and  cc.isDelete=0   ");
            str1 = string.Concat(" ", str1, "left join tb_task t on t.typeid=a.clientid and t.IsDelete=0 AND t.ContactID = cc.contactId   ");
            //object[] companyID1 = new object[] { " ", str1, "where a.companyid=", this.CompanyID, " and a.isdelete=0 " };
            object[] companyID1 = new object[] { " ", str1, "where "  + str4 +  "a.companyid=", this.CompanyID, " and a.isdelete=0 " };
            str1 = string.Concat(companyID1);
            if (this.chkDateOption.Checked)
            {
                if (this.rdlDate.SelectedValue == "daily")
                {
                    string str9 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.day[0].ToString());
                    string[] strArrays2 = new string[] { " ", str1, " and DateADD(d,0,DateDiff(d,0,t.duedate)) = '", str9, "' " };
                    str1 = string.Concat(strArrays2);
                }

                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    string str12 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.yestday[0].ToString());
                    string[] strArrays2 = new string[] { " ", str1, " and DateADD(d,0,DateDiff(d,0,c.CallStartdate)) = '", str12, "' " };
                    str1 = string.Concat(strArrays2);
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    string str14 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stdate[0].ToString());
                    string str15 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.endate[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str14, "' AND '", str15, "' " };
                    str1 = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    string str16 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stquardate[0].ToString());
                    string str17 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enquardate[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str16, "' AND '", str17, "' " };
                    str1 = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    string startDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat));
                    string endDate = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm", "MM")));
                    strArrays = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", startDate, "' and '", endDate, "' " };
                    str1 = string.Concat(strArrays);
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastquardate[0].ToString());
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastquardate[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str18, "' AND '", str19, "' " };
                    str1 = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastweek[0].ToString());
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastweek[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str18, "' AND '", str19, "' " };
                    str1 = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastmonth[0].ToString());
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastmonth[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str18, "' AND '", str19, "' " };
                    str1 = string.Concat(strArrays3);
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    string str18 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.stlastyear[0].ToString());
                    string str19 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.enlastyear[0].ToString());
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,c.CallStartdate)) BETWEEN '", str18, "' AND '", str19, "' " };
                    str1 = string.Concat(strArrays3);
                }



                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    string str10 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtFrom.Text));
                    string str11 = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, base.ReplaceSingleQuote(this.txtTo.Text));
                    string[] strArrays3 = new string[] { " ", str1, " and DateAdd(d,0,DateDiff(d,0,t.duedate)) BETWEEN '", str10, "' AND '", str11, "' " };
                    str1 = string.Concat(strArrays3);
                }
            }
            if (this.txtFreeText.Text != "")
            {
                int num = 0;
                for (int j = 0; j < this.chkFreeText.Items.Count; j++)
                {
                    if (this.chkFreeText.Items[j].Selected)
                    {
                        num++;
                    }
                }
                int num1 = 0;
                for (int k = 0; k < this.chkFreeText.Items.Count; k++)
                {
                    if (num > 1)
                    {
                        if (this.chkFreeText.Items[k].Selected)
                        {
                            if (this.chkFreeText.Items[k].Value == "CompanyName")
                            {
                                str1 = string.Concat(str1, " and ( (ltrim(a.clientName) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')  ");
                            }
                            if (this.chkFreeText.Items[k].Value == "ContactName")
                            {
                                str1 = (num1 != 0 ? string.Concat(str1, " or ") : string.Concat(str1, " and ( "));
                                str1 = string.Concat(str1, "(RTRIM(LTRIM(isnull(cc.firstname,'')+isnull(NULLIF(' '+cc.middlename,' '),'')+isnull(' '+cc.lastname,''))) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')");
                            }
                            if (this.chkFreeText.Items[k].Value == "SalesPerson")
                            {
                                str1 = (num1 != 0 ? string.Concat(str1, " or ") : string.Concat(str1, " and ( "));
                                object[] objArray1 = new object[] { str1, " ((Select  ISNULL(r.FirstName,'') + '' + ISNULL(r.LastName,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%') " };
                                str1 = string.Concat(objArray1);
                            }
                            if (this.chkFreeText.Items[k].Value == "AssignedTo")
                            {
                                str1 = (num1 != 0 ? string.Concat(str1, " or ") : string.Concat(str1, " and ( "));
                                object[] companyID2 = new object[] { str1, " ((Select isnull(r.firstname,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')  " };
                                str1 = string.Concat(companyID2);
                            }
                            if (this.chkFreeText.Items[k].Value == "Subject")
                            {
                                str1 = (num1 != 0 ? string.Concat(str1, " or ") : string.Concat(str1, " and ( "));
                                str1 = string.Concat(str1, " (isnull(t.Subject,'') like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%') ");
                            }
                            if (this.chkFreeText.Items[k].Value == "Description")
                            {
                                str1 = (num1 != 0 ? string.Concat(str1, " or ") : string.Concat(str1, " and ( "));
                                str1 = string.Concat(str1, " (isnull(t.Description,'') like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%') ");
                            }
                            num1++;
                        }
                    }
                    else if (num == 1 && this.chkFreeText.Items[k].Selected)
                    {
                        if (this.chkFreeText.Items[k].Value == "CompanyName")
                        {
                            str1 = string.Concat(str1, " and ( (ltrim(a.clientName) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')");
                        }
                        if (this.chkFreeText.Items[k].Value == "ContactName")
                        {
                            str1 = string.Concat(str1, " and (RTRIM(LTRIM(isnull(cc.firstname,'')+isnull(NULLIF(' '+cc.middlename,' '),'')+isnull(' '+cc.lastname,''))) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%'");
                        }
                        if (this.chkFreeText.Items[k].Value == "SalesPerson")
                        {
                            object[] objArray2 = new object[] { str1, " and ( ((Select  ISNULL(r.FirstName,'') + '' + ISNULL(r.LastName,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=a.SalesPerson and r.IsDelete=0) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')" };
                            str1 = string.Concat(objArray2);
                        }
                        if (this.chkFreeText.Items[k].Value == "AssignedTo")
                        {
                            object[] companyID3 = new object[] { str1, " and ( ((Select isnull(r.firstname,'') from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0) like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')" };
                            str1 = string.Concat(companyID3);
                        }
                        if (this.chkFreeText.Items[k].Value == "Subject")
                        {
                            str1 = string.Concat(str1, " and ( (isnull(t.Subject,'') like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%') ");
                        }
                        if (this.chkFreeText.Items[k].Value == "Description")
                        {
                            str1 = string.Concat(str1, " and ( (isnull(t.Description,'') like '%", base.SpecialEncode(this.txtFreeText.Text.Trim()), "%')");
                        }
                    }
                }
                if (num != 0)
                {
                    str1 = string.Concat(str1, " ) ");
                }
                base.SpecialEncode(this.txtFreeText.Text.Trim());
            }
            SqlConnection sqlConnection = new SqlConnection(this.cs);
            string empty8 = string.Empty;
            if (PageNumber != 0)
            {
                empty8 = "CREATE TABLE #PageIndexNew( IndexId INT IDENTITY (1, 1) NOT NULL";
                if (this.chkColumns.Items[0].Selected)
                {
                    empty8 = (empty8 == "" ? "clientID int" : string.Concat(empty8, " ,clientID int"));
                    empty8 = (empty8 == "" ? "CompanyName nvarchar(max)" : string.Concat(empty8, " ,CompanyName nvarchar(max)"));
                }
                if (this.chkColumns.Items[1].Selected)
                {
                    empty8 = (empty8 == "" ? "ContactName nvarchar(max)" : string.Concat(empty8, " ,ContactName nvarchar(max)"));
                }
                if (this.chkColumns.Items[2].Selected)
                {
                    empty8 = (empty8 == "" ? "SalesPerson nvarchar(max)" : string.Concat(empty8, " ,SalesPerson nvarchar(max)"));
                }
                if (this.chkColumns.Items[3].Selected)
                {
                    empty8 = (empty8 == "" ? "Subject nvarchar(max)" : string.Concat(empty8, " ,Subject nvarchar(max)"));
                }
                if (this.chkColumns.Items[4].Selected)
                {
                    empty8 = (empty8 == "" ? "AssignedTo nvarchar(max)" : string.Concat(empty8, " ,AssignedTo nvarchar(max)"));
                }
                if (this.chkColumns.Items[5].Selected)
                {
                    empty8 = (empty8 == "" ? "Description nvarchar(max)" : string.Concat(empty8, " ,Description nvarchar(max)"));
                }
                if (this.chkColumns.Items[6].Selected)
                {
                    empty8 = (empty8 == "" ? "DateAndTime nvarchar(500)" : string.Concat(empty8, " ,DateAndTime nvarchar(500)"));
                }
                if (this.chkColumns.Items[7].Selected)
                {
                    empty8 = (empty8 == "" ? "Status nvarchar(max)" : string.Concat(empty8, " ,Status nvarchar(max)"));
                }
                if (this.chkColumns.Items[8].Selected)
                {
                    empty8 = (empty8 == "" ? "Priority nvarchar(max)" : string.Concat(empty8, " ,Priority nvarchar(max)"));
                }
                empty8 = string.Concat(empty8, ")");
                empty8 = string.Concat(empty8, "Insert Into #PageIndexNew  (");
                if (this.chkColumns.Items[0].Selected)
                {
                    empty8 = (empty8 == "" ? "clientID" : string.Concat(empty8, " clientID"));
                    empty8 = (empty8 == "" ? "CompanyName" : string.Concat(empty8, " ,CompanyName "));
                }
                if (this.chkColumns.Items[1].Selected)
                {
                    empty8 = (empty8 == "" ? "ContactName" : string.Concat(empty8, " ,ContactName"));
                }
                if (this.chkColumns.Items[2].Selected)
                {
                    empty8 = (empty8 == "" ? "SalesPerson" : string.Concat(empty8, " ,SalesPerson"));
                }
                if (this.chkColumns.Items[3].Selected)
                {
                    empty8 = (empty8 == "" ? "Subject" : string.Concat(empty8, " ,Subject"));
                }
                if (this.chkColumns.Items[4].Selected)
                {
                    empty8 = (empty8 == "" ? "AssignedTo" : string.Concat(empty8, " ,AssignedTo"));
                }
                if (this.chkColumns.Items[5].Selected)
                {
                    empty8 = (empty8 == "" ? "Description" : string.Concat(empty8, " ,Description"));
                }
                if (this.chkColumns.Items[6].Selected)
                {
                    empty8 = (empty8 == "" ? "DateAndTime" : string.Concat(empty8, " ,DateAndTime"));
                }
                if (this.chkColumns.Items[7].Selected)
                {
                    empty8 = (empty8 == "" ? "Status" : string.Concat(empty8, " ,Status"));
                }
                if (this.chkColumns.Items[8].Selected)
                {
                    empty8 = (empty8 == "" ? "Priority" : string.Concat(empty8, " ,Priority"));
                }
                empty8 = string.Concat(empty8, ")");
                if (this.chkColumns.Items[3].Selected || this.chkColumns.Items[4].Selected || this.chkColumns.Items[5].Selected || this.chkColumns.Items[6].Selected || this.chkColumns.Items[7].Selected || this.chkColumns.Items[8].Selected)
                {
                    str = empty8;
                    strArrays = new string[] { str, "select  ", empty1, " ", str1, "AND t.isDelete = 0 order by [CompanyName] " };
                    empty8 = string.Concat(strArrays);
                }
                else
                {
                    str = empty8;
                    strArrays = new string[] { str, "select distinct ", empty1, " ", str1, "AND t.isDelete = 0 order by [CompanyName] " };
                    empty8 = string.Concat(strArrays);
                }
                int pageNumber = 0;
                int pageSize = 0;
                if (PageNumber != 1)
                {
                    pageNumber = PageNumber * this.PageSize - this.PageSize + 1;
                    pageSize = pageNumber + this.PageSize - 1;
                }
                else
                {
                    pageNumber = 1;
                    pageSize = this.PageSize;
                }
                empty8 = string.Concat(empty8, "select ");
                if (this.chkColumns.Items[0].Selected)
                {
                    empty8 = (empty8 == "" ? "clientID" : string.Concat(empty8, " clientID"));
                    empty8 = (empty8 == "" ? "CompanyName" : string.Concat(empty8, " , CompanyName"));
                }
                if (this.chkColumns.Items[1].Selected)
                {
                    empty8 = (empty8 == "" ? "ContactName" : string.Concat(empty8, " ,ContactName"));
                }
                if (this.chkColumns.Items[2].Selected)
                {
                    empty8 = (empty8 == "" ? "SalesPerson" : string.Concat(empty8, " ,SalesPerson"));
                }
                if (this.chkColumns.Items[3].Selected)
                {
                    empty8 = (empty8 == "" ? "Subject" : string.Concat(empty8, " ,Subject"));
                }
                if (this.chkColumns.Items[4].Selected)
                {
                    empty8 = (empty8 == "" ? "AssignedTo" : string.Concat(empty8, " ,AssignedTo"));
                }
                if (this.chkColumns.Items[5].Selected)
                {
                    empty8 = (empty8 == "" ? "Description" : string.Concat(empty8, " ,Description"));
                }
                if (this.chkColumns.Items[6].Selected)
                {
                    empty8 = (empty8 == "" ? "DateAndTime" : string.Concat(empty8, " ,DateAndTime"));
                }
                if (this.chkColumns.Items[7].Selected)
                {
                    empty8 = (empty8 == "" ? "Status" : string.Concat(empty8, " ,Status"));
                }
                if (this.chkColumns.Items[8].Selected)
                {
                    empty8 = (empty8 == "" ? "Priority" : string.Concat(empty8, " ,Priority"));
                }
                empty = empty8;
                companyID = new object[] { empty, " From #PageIndexNew where IndexID>=", pageNumber, " and IndexID <=", pageSize, "  select count(*) from #PageIndexNew Where 1=1" };
                empty8 = string.Concat(companyID);
            }
            else if (this.chkColumns.Items[3].Selected || this.chkColumns.Items[4].Selected || this.chkColumns.Items[5].Selected || this.chkColumns.Items[6].Selected || this.chkColumns.Items[7].Selected || this.chkColumns.Items[8].Selected)
            {
                str = empty8;
                strArrays = new string[] { str, "select  ", empty1, " ", str1, "AND t.isDelete = 0 order by [CompanyName] " };
                empty8 = string.Concat(strArrays);
            }
            else
            {
                str = empty8;
                strArrays = new string[] { str, "select distinct ", empty1, " ", str1, "AND t.isDelete = 0 order by [CompanyName] " };
                empty8 = string.Concat(strArrays);
            }
            (new SqlDataAdapter(empty8, sqlConnection)).Fill(dataSet);
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "1")
            {
                this.btnExport.Visible = false;
                this.btnExportPPT.Visible = true;
                DataSet dataSet1 = new DataSet();
                string str12 = string.Concat("select distinct isnull(DATEADD(d, 0, DATEDIFF(d, 0, t.createDate)),'') as DueDate ", str1, " order by DueDate ");
                (new SqlDataAdapter(str12, sqlConnection)).Fill(dataSet1);
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold' ><b>&nbsp;"));
                    Label label = new Label();
                    commonClass _commonClass = this.objJava;
                    DateTime dateTime = Convert.ToDateTime(row["DueDate"]);
                    label.Text = _commonClass.Eprint_return_Date_Before_View(dateTime.ToShortDateString(), this.CompanyID, this.UserID, false);
                    this.plhdetails.Controls.Add(label);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    if (label.Text != "")
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% style='padding:5px;' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Contact_Name"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Subject"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Assigned_To"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Task_date_time"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Status"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Priority"), "</b>&nbsp;</div></td>")));
                        }
                        this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                        string empty9 = string.Empty;
                        commonClass _commonClass1 = this.objJava;
                        dateTime = Convert.ToDateTime(row["DueDate"]);
                        string str13 = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToShortDateString(), this.CompanyID, this.UserID, false);
                        strArrays = new string[] { "select ", empty1, " ", str1, " and DATEADD(d, 0, DATEDIFF(d, 0, t.createDate)) = '", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, str13), "'" };
                        SqlCommand sqlCommand = new SqlCommand(string.Concat(strArrays), sqlConnection)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        int num2 = 0;
                        if (!sqlDataReader.HasRows)
                        {
                            this.plhdetails.Controls.Clear();
                        }
                        string empty10 = string.Empty;
                        string empty11 = string.Empty;
                        string empty12 = string.Empty;
                        string empty13 = string.Empty;
                        string empty14 = string.Empty;
                        string str14 = string.Empty;
                        string empty15 = string.Empty;
                        string str15 = string.Empty;
                        string empty16 = string.Empty;
                        string str16 = string.Empty;
                        string empty17 = string.Empty;
                        string str17 = string.Empty;
                        string empty18 = string.Empty;
                        string str18 = string.Empty;
                        string empty19 = string.Empty;
                        string str19 = string.Empty;
                        string empty20 = string.Empty;
                        while (sqlDataReader.Read())
                        {
                            num2++;
                            if (num2 % 2 != 0)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                            }
                            else
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                            }
                            if (this.chkColumns.Items[0].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["CompanyName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[1].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["ContactName"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[2].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["SalesPerson"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[3].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["Subject"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[4].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["AssignedTo"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[5].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["Description"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (this.chkColumns.Items[6].Selected)
                            {
                                try
                                {
                                    string str20 = sqlDataReader["DateAndTime"].ToString();
                                    chrArray = new char[] { '$' };
                                    string[] strArrays4 = str20.Split(chrArray);
                                    string str21 = this.objJava.Eprint_return_Date_Before_View(strArrays4[0].ToString(), this.CompanyID, this.UserID, false);
                                    string str22 = string.Concat(str21, " ", strArrays4[1]);
                                    this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", str22, "&nbsp;</div></td>")));
                                }
                                catch
                                {
                                }
                            }
                            if (this.chkColumns.Items[7].Selected)
                            {
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["Status"].ToString()), "&nbsp;</div></td>")));
                            }
                            if (!this.chkColumns.Items[8].Selected)
                            {
                                continue;
                            }
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader["Priority"].ToString()), "&nbsp;</div></td>")));
                        }
                        sqlConnection.Close();
                        this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
            }
            else if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "2")
            {
                this.btnExport.Visible = false;
                this.btnExportPPT.Visible = true;
                this.usrPaging.Visible = false;
                this.btngo.Visible = false;
                DataSet dataSet2 = new DataSet();
                companyID = new object[] { "select distinct isnull((Select r.firstname from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0),'') as AssignedTo ", str1, " " };
                string str23 = string.Concat(companyID);
                (new SqlDataAdapter(str23, sqlConnection)).Fill(dataSet2);
                foreach (DataRow dataRow in dataSet2.Tables[0].Rows)
                {
                    this.plhdetails.Controls.Add(new LiteralControl("<table boder=0  width=100% cellspacing=0 cellpadding=0>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' style='font-weight:bold;padding-top:5px' ><b>&nbsp;"));
                    Label label1 = new Label();
                    string str24 = this.objBase.SpecialDecode(dataRow["AssignedTo"].ToString());
                    dataRow["AssignedTo"] = this.objBase.SpecialEncode(dataRow["AssignedTo"].ToString());
                    if (str24 != "")
                    {
                        label1.Text = str24;
                    }
                    else
                    {
                        label1.Text = "Not Specified";
                    }
                    this.plhdetails.Controls.Add(label1);
                    this.plhdetails.Controls.Add(new LiteralControl("</b></td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("<td>"));
                    if (label1.Text != "")
                    {
                        this.plhdetails.Controls.Add(new LiteralControl("<table width=100% class='callreport_grpby' cellspacing=0 cellpadding=1 border=0 ><tr class='headerstylereport1'  valign=top height=23>"));
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%'wordwrap='true' nowwrap='nowwrap' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>&nbsp;", this.objLangClass.GetLanguageConversion("Company_Name"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align=left width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Contact_Name"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Sales_Person"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Subject"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Assigned_To"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Description"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Task_date_time"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Status"), "</b>&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[8].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='headerstylereport1' align='left' width='5%' valign='top' style='vertical-align:middle;'><div style='min-width: 100px; max-height: 15px; height: 25px;float: left; width: 99%; overflow: hidden'><b>", this.objLangClass.GetLanguageConversion("Priority"), "</b>&nbsp;</div></td>")));
                        }
                    }
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    empty = string.Empty;
                    companyID = new object[] { empty, "select ", empty1, " ", str1, " and isnull((Select r.firstname from tb_user r  where r.CompanyID=", this.CompanyID, " and r.userid=t.assignToUserId and r.IsDelete=0),'') = '", dataRow["AssignedTo"], "'" };
                    SqlCommand sqlCommand1 = new SqlCommand(string.Concat(companyID), sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
                    int num3 = 0;
                    if (!sqlDataReader1.HasRows)
                    {
                        this.plhdetails.Controls.Clear();
                    }
                    string empty21 = string.Empty;
                    string empty22 = string.Empty;
                    string empty23 = string.Empty;
                    string empty24 = string.Empty;
                    string empty25 = string.Empty;
                    string str25 = string.Empty;
                    string empty26 = string.Empty;
                    string str26 = string.Empty;
                    string empty27 = string.Empty;
                    string str27 = string.Empty;
                    string empty28 = string.Empty;
                    string str28 = string.Empty;
                    string empty29 = string.Empty;
                    string str29 = string.Empty;
                    string empty30 = string.Empty;
                    string str30 = string.Empty;
                    string empty31 = string.Empty;
                    while (sqlDataReader1.Read())
                    {
                        num3++;
                        if (num3 % 2 != 0)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr>"));
                        }
                        else
                        {
                            this.plhdetails.Controls.Add(new LiteralControl("<tr class=NewAlternativereport >"));
                        }
                        if (this.chkColumns.Items[0].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["CompanyName"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[1].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["ContactName"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[2].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["SalesPerson"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[3].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["Subject"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[4].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["AssignedTo"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[5].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["Description"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (this.chkColumns.Items[6].Selected)
                        {
                            try
                            {
                                string str31 = sqlDataReader1["DateAndTime"].ToString();
                                chrArray = new char[] { '$' };
                                string[] strArrays5 = str31.Split(chrArray);
                                string str32 = this.objJava.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
                                string str33 = string.Concat(str32, " ", strArrays5[1]);
                                this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", str33, "&nbsp;</div></td>")));
                            }
                            catch
                            {
                                this.plhdetails.Controls.Add(new LiteralControl("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'></div></td>"));
                            }
                        }
                        if (this.chkColumns.Items[7].Selected)
                        {
                            this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["Status"].ToString()), "&nbsp;</div></td>")));
                        }
                        if (!this.chkColumns.Items[8].Selected)
                        {
                            continue;
                        }
                        this.plhdetails.Controls.Add(new LiteralControl(string.Concat("<td class='table-rowrpt' align='left' width='5%' style='vertical-align:middle'><div id='division' style='overflow:auto;word-break:break-all;height:25px;min-width: 200px; max-height: 15px;float: left; width: 99%;padding-top:0px;' class='divscroll'>", this.objBase.SpecialDecode(sqlDataReader1["Priority"].ToString()), "&nbsp;</div></td>")));
                    }
                    sqlConnection.Close();
                    this.plhdetails.Controls.Add(new LiteralControl("</tr></table>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</td>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</tr>"));
                    this.plhdetails.Controls.Add(new LiteralControl("</table>"));
                }
            }
            foreach (DataRow row1 in dataSet.Tables[0].Rows)
            {
                if (row1.Table.Columns.Contains("CompanyName"))
                {
                    row1["CompanyName"] = base.SpecialDecode(row1["CompanyName"].ToString());
                }
                if (row1.Table.Columns.Contains("ContactName"))
                {
                    row1["ContactName"] = base.SpecialDecode(row1["ContactName"].ToString());
                }
                if (row1.Table.Columns.Contains("SalesPerson"))
                {
                    row1["SalesPerson"] = base.SpecialDecode(row1["SalesPerson"].ToString());
                }
                if (row1.Table.Columns.Contains("Subject"))
                {
                    row1["Subject"] = base.SpecialDecode(row1["Subject"].ToString());
                }
                if (row1.Table.Columns.Contains("AssignedTo"))
                {
                    row1["AssignedTo"] = base.SpecialDecode(row1["AssignedTo"].ToString());
                }
                if (row1.Table.Columns.Contains("Description"))
                {
                    row1["Description"] = base.SpecialDecode(row1["Description"].ToString());
                }
                if (row1.Table.Columns.Contains("Status"))
                {
                    row1["Status"] = base.SpecialDecode(row1["Status"].ToString());
                }
                if (!row1.Table.Columns.Contains("Priority"))
                {
                    continue;
                }
                row1["Priority"] = base.SpecialDecode(row1["Priority"].ToString());
            }
            foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(dataRow1[0].ToString());
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
            DataSet activityTaskEventData = this.GetActivityTaskEventData(PageNumber);
            this.lblTotalRecords.Text = activityTaskEventData.Tables[1].Rows[0][0].ToString();
            if (activityTaskEventData.Tables[0].Rows.Count == 0)
            {
                this.pnlEmptyRecords.Visible = true;
                this.GridEstReport.Visible = false;
                this.btnExport.Visible = false;
                this.btnExportPPT.Visible = false;
                this.divtoolbar.Visible = false;
                this.txt1.Visible = false;
                this.btngo.Visible = false;
                return;
            }
            this.GridEstReport.Visible = true;
            this.div_Total.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            DataTable dt = SetTaskReportColumns(activityTaskEventData);
            this.GridEstReport.DataSource = dt;
            //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridActivityTaskEventReport_RowDataBound);
            this.GridEstReport.DataBind();
            this.usrPaging.Visible = false;
            pagingreport.intCurrentPage = PageNumber;
            pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activityTaskEventData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
            this.usrPaging.CreatePaging();
            //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
            this.CallPagingBtn_ScrollGrid(this.usrPaging);
        }

        private void GetSelectColoumns()
        {
            DataTable dataTable = SettingsBasePage.ActivityTaskEventReport_SelectColoumn();
            if (dataTable.Rows.Count > 1)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    row["ScreenName"] = this.objBase.SpecialDecode(row["ScreenName"].ToString());
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (row["ScreenName"].ToString().Contains("Date & Time"))
                        {
                            row["ScreenName"] = "Task Date & Time";
                        }
                    }
                }
                this.chkColumns.DataSource = dataTable;
                this.chkColumns.DataTextField = "ScreenName";
                this.chkColumns.DataValueField = "ActualName";
                this.chkColumns.DataBind();
            }
        }

        private void GridActivityTaskEventReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "CompanyName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Company_Name");
                    }
                    else if (e.Row.Cells[i].Text == "ContactName")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
                    }
                    else if (e.Row.Cells[i].Text == "SalesPerson")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
                    }
                    else if (e.Row.Cells[i].Text == "Subject")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Subject");
                    }
                    else if (e.Row.Cells[i].Text == "AssignedTo")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Assigned_To");
                    }
                    else if (e.Row.Cells[i].Text == "Description")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Description");
                    }
                    else if (e.Row.Cells[i].Text == "DateAndTime")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Task_date_time");
                        this.flag_DateTime = "true";
                        this.cellvalue_DateTime = i;
                    }
                    else if (e.Row.Cells[i].Text == "Status")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Status");
                    }
                    else if (e.Row.Cells[i].Text == "Priority")
                    {
                        e.Row.Cells[i].Text = this.objLangClass.GetLanguageConversion("Priority");
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                if (this.flag_DateTime == "true")
                {
                    try
                    {
                        string[] strArrays = e.Row.Cells[this.cellvalue_DateTime].Text.Split(new char[] { '$' });
                        string str = this.objJava.Eprint_return_Date_Before_View(strArrays[0].ToString(), this.CompanyID, this.UserID, false);
                        e.Row.Cells[this.cellvalue_DateTime].Text = string.Concat(str, " ", strArrays[1]);
                    }
                    catch
                    {
                    }
                }
                for (int j = 0; j < e.Row.Cells.Count; j++)
                {
                    e.Row.Cells[j].Text = string.Concat("<div style='min-width: 100px;max-height: 15px;height:15px;'><div style='float: left; width: 99%; overflow: hidden'>", this.objBase.SpecialDecode(e.Row.Cells[j].Text), "</div></div>");
                }
            }
        }

        protected void GridTaskEventReport_DataBound(object sender, EventArgs e)
        {
            int num = 0;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected && (i == 0 || i == 1 || i == 2))
                {
                    num++;
                }
            }
            this.GridEstReport.HeaderStyle.CssClass = "commonheaderstylereport11";

            for (int j = 0; j < GridEstReport.Items.Count; j++)
            {
                string text = this.GridEstReport.Items[j].Cells[0].Text;
                for (int k = j + 1; k < this.GridEstReport.Items.Count; k++)
                {
                    // Compare text of the first cell of the current item and the next item
                    if (string.Compare(text, this.GridEstReport.Items[k].Cells[0].Text, true) == 0)
                    {
                        for (int l = 1; l < this.GridEstReport.Items[j].Cells.Count; l++)
                        {
                            if (string.Compare(this.GridEstReport.Items[j].Cells[l].Text, this.GridEstReport.Items[k].Cells[l].Text, true) == 0)
                            {
                                this.GridEstReport.Items[k].Cells[l].Text = string.Empty;
                            }
                        }
                    }
                }
            }
            //for (int j = 0; j < this.GridEstReport.Rows.Count; j++)
            //{
            //    string text = this.GridEstReport.Rows[j].Cells[0].Text;
            //    for (int k = j + 1; k < this.GridEstReport.Rows.Count; k++)
            //    {
            //        if (string.Compare(text, this.GridEstReport.Rows[k].Cells[0].Text, true) == 0)
            //        {
            //            for (int l = 1; l <= num; l++)
            //            {
            //                if (string.Compare(this.GridEstReport.Rows[j].Cells[l].Text, this.GridEstReport.Rows[k].Cells[l].Text, true) == 0)
            //                {
            //                    this.GridEstReport.Rows[k].Cells[l].Text = string.Empty;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.objBase.ReturnRoles_Privileges_Reports("crm", "showreport", "");
                if (base.Request.Params["pg"] == null)
                {
                    this.pagename = "client";
                }
                else if (base.Request.Params["pg"].ToString().Trim().ToLower() == "report")
                {
                    this.pagename = "Report";
                }
                global.pageName = this.pagename;
                global.pgName = "";
                this.gloobj.setpagename(this.pagename);
                languageClass _languageClass = new languageClass();
                base.Title = _languageClass.convert(global.pageTitle("Task Report", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                if (this.pagename.ToString().ToLower().Trim() != "report")
                {
                    string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../client/client_view.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLangClass.GetLanguageConversion("Client_View"), "</a>" };
                    base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Task_Event_Report")));
                }
                else
                {
                    base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;<a href=../common/report.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Reports"), "</a>&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Task_Event_Report")));
                }
                this.DateFormat = this.Session["Dateformat"].ToString();
                this.CompanyID = Convert.ToInt32(this.Session["companyid"].ToString());
                this.UserID = Convert.ToInt32(this.Session["UserID"]);
                this.cs = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
                SqlConnection sqlConnection = new SqlConnection(this.cs);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(string.Concat("select CompanyName from tb_Company where CompanyID=", this.CompanyID, " and isdelete=0"), sqlConnection);
                this.CompanyName = (string)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                string str = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                char[] chrArray = new char[] { ' ' };
                this.day = str.Split(chrArray);
                HtmlGenericControl spnDaily = this.spn_daily;
                string[] strArrays = new string[] { "(", this.objLangClass.GetLanguageConversion("Eg"), ".", this.day[0].ToString(), ")" };
                spnDaily.InnerText = string.Concat(strArrays);

                commonClass _commonClass22 = this.objJava;
                string str4 = dateTime.AddDays(-1).ToString();
                char[] chrArray1 = new char[] { ' ' };
                string str5 = _commonClass22.Eprint_return_Date_Before_View(str4.Split(chrArray1)[0].ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray2 = new char[] { ' ' };
                this.yestday = str5.Split(chrArray2);
                this.spn_yest.InnerText = string.Concat("(", this.yestday[0].ToString(), ")");
                DateTime dateTime11 = new DateTime(dateTime.Year, dateTime.Month, 1);
                DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, 1);
                DateTime dateTime3 = dateTime2.AddMonths(1).AddDays(-1);
                string str6 = this.objJava.Eprint_return_Date_Before_View(dateTime11.ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray3 = new char[] { ' ' };
                this.stdate = str6.Split(chrArray3);
                string str7 = this.objJava.Eprint_return_Date_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, false);
                char[] chrArray4 = new char[] { ' ' };
                this.endate = str7.Split(chrArray4);
                HtmlGenericControl spnMonth = this.spn_month;
                string[] strArrays11 = new string[] { "(", this.stdate[0].ToString(), " to ", this.endate[0].ToString(), ")" };
                spnMonth.InnerText = string.Concat(strArrays11);
                try
                {
                    string[] strArrays1 = this.CurrentQuater().Split(new char[] { ',' });
                    string str8 = this.objJava.Eprint_return_Date_Before_View(strArrays1[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray5 = new char[] { ' ' };
                    this.stquardate = str8.Split(chrArray5);
                    string str9 = this.objJava.Eprint_return_Date_Before_View(strArrays1[1].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray6 = new char[] { ' ' };
                    this.enquardate = str9.Split(chrArray6);
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
                    string str10 = this.objJava.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray7 = new char[] { ' ' };
                    this.stlastquardate = str10.Split(chrArray7);
                    string str11 = this.objJava.Eprint_return_Date_Before_View(strArrays3[1].ToString(), this.CompanyID, this.UserID, false);
                    char[] chrArray8 = new char[] { ' ' };
                    this.enlastquardate = str11.Split(chrArray8);
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
                HtmlGenericControl spn_rdlDate_task1 = this.spndlDate_AnnualYear;
                string[] strArrays33 = new string[] { "(",
                    this.objJava.Eprint_return_Date_Before_View(
                        ePrintUtilities.Utilities.GetFirstDateOfTheCuurentYear(this.DateFormat)
                        , this.CompanyID, this.UserID, false),
                                " to ",
                    this.objJava.Eprint_return_Date_Before_View(
                                ePrintUtilities.Utilities.GetCurrentDateString(this.DateFormat.Replace("mm","MM"))
                        , this.CompanyID, this.UserID, false)
                                , ")" }; 
                spn_rdlDate_task1.InnerText = string.Concat(strArrays33);
                

                this.btnCancel.Text = this.objLangClass.GetLanguageConversion("Cancel");
                this.btnSaveRun.Text = this.objLangClass.GetLanguageConversion("Save_And_Run");
                this.btnUpdateExisting.Text = this.objLangClass.GetLanguageConversion("Update_Report");
                this.btnRunReport.Text = this.objLangClass.GetLanguageConversion("Run_Report");
                this.RadPanelBar1.Items[0].Text = this.objLangClass.GetLanguageConversion("Select_Columns_To_Run_Report");
                this.RadPanelBar1.Items[1].Text = this.objLangClass.GetLanguageConversion("Sort_The_Records");
                this.RadPanelBar1.Items[2].Text = this.objLangClass.GetLanguageConversion("Report_Filters");
                this.RadPanelBar1.Items[3].Text = this.objLangClass.GetLanguageConversion("Save_Report_Options");
                this.chkFreeText.Items[0].Text = this.objLangClass.GetLanguageConversion("Company_Name");
                this.chkFreeText.Items[1].Text = this.objLangClass.GetLanguageConversion("Contact_Name");
                this.chkFreeText.Items[2].Text = this.objLangClass.GetLanguageConversion("Sales_Person");
                this.chkFreeText.Items[3].Text = this.objLangClass.GetLanguageConversion("Assigned_To");
                this.chkFreeText.Items[4].Text = this.objLangClass.GetLanguageConversion("Subject");
                this.chkFreeText.Items[5].Text = this.objLangClass.GetLanguageConversion("Description");
                if (!base.IsPostBack)
                {
                    this.txtFrom.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox = this.txtFrom;
                    commonClass _commonClass2 = this.objJava;
                    DateTime now1 = DateTime.Now;
                    textBox.Text = _commonClass2.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                    this.txtTo.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                    TextBox textBox1 = this.txtTo;
                    commonClass _commonClass3 = this.objJava;
                    DateTime dateTime1 = DateTime.Now;
                    textBox1.Text = _commonClass3.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                    this.GetSelectColoumns();
                    this.Panel1.Visible = true;
                }
                this.usrReportsave.OnReportClick += new SavingReportEventHandler(this.usrReportsave_OnReportClick);
                this.usrReportsave.OnEditClick += new EditReportEventHandler(this.usrReportsave_OnEditClick);
                this.usrReportsave.OnDeleteClick += new DeleteReportEventHandler(this.usrReportsave_OnDeleteClick);
                if (!base.IsPostBack)
                {
                    this.usrPaging.Visible = false;
                }
                this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                if (!base.IsPostBack)
                {
                    this.Session["DeleteMsg"] = null;
                    this.Session["SaveAsNew"] = null;
                    this.pnlReports.Visible = true;
                }
            }
            catch
            {
            }
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


        private void paging_OnPageChange(int PageNumber1)
        {
            //if (PageNumber1 <= 0)
            //{
            //    this.GridEstReport.PageIndex = PageNumber1;
            //}
            //else
            //{
            //    this.GridEstReport.PageIndex = PageNumber1 - 1;
            //}
            this.GetPageBind(PageNumber1);
            this.div_showfilters.Style.Add("display", "none");
            this.divusrReportsave.Style.Add("display", "none");
            this.GridEstReport.DataBind();
        }

        private void ReportDetails(int ReportID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
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
                row["Status"].ToString();
                row["CustomerType"].ToString();
                string[] strArrays = empty.Split(new char[] { 'µ' });
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    if (strArrays[j] == "CompanyName")
                    {
                        this.chkColumns.Items[0].Selected = true;
                    }
                    else if (strArrays[j] == "ContactName")
                    {
                        this.chkColumns.Items[1].Selected = true;
                    }
                    else if (strArrays[j] == "SalesPerson")
                    {
                        this.chkColumns.Items[2].Selected = true;
                    }
                    else if (strArrays[j] == "Subject")
                    {
                        this.chkColumns.Items[3].Selected = true;
                    }
                    else if (strArrays[j] == "AssignedTo")
                    {
                        this.chkColumns.Items[4].Selected = true;
                    }
                    else if (strArrays[j] == "Notes")
                    {
                        this.chkColumns.Items[5].Selected = true;
                    }
                    else if (strArrays[j] == "DateAndTime")
                    {
                        this.chkColumns.Items[6].Selected = true;
                    }
                    else if (strArrays[j] == "Status")
                    {
                        this.chkColumns.Items[7].Selected = true;
                    }
                    else if (strArrays[j] == "Priority")
                    {
                        this.chkColumns.Items[8].Selected = true;
                    }
                }
                if (Convert.ToInt32(row["GroupedBy"]) != 0)
                {
                    base.SetDDLValue(this.ddlGrouprecords, row["GroupedBy"].ToString());
                }
                if (row["SearchKeyword"].ToString() != "")
                {
                    this.txtFreeText.Text = base.SpecialDecode(row["SearchKeyword"].ToString());
                }
                if (row["ReportName"].ToString() != "")
                {
                    this.txtSaveReports.Text = base.SpecialDecode(row["ReportName"].ToString());
                }
                str1 = row["SelectedSearchText"].ToString();
                string[] strArrays1 = str1.Split(new char[] { 'µ' });
                this.chkFreeText.Items[0].Selected = false;
                this.chkFreeText.Items[1].Selected = false;
                this.chkFreeText.Items[2].Selected = false;
                this.chkFreeText.Items[3].Selected = false;
                this.chkFreeText.Items[4].Selected = false;
                this.chkFreeText.Items[5].Selected = false;
                for (int k = 0; k < (int)strArrays1.Length; k++)
                {
                    if (strArrays1[k] == "CompanyName")
                    {
                        this.chkFreeText.Items[0].Selected = true;
                    }
                    if (strArrays1[k] == "ContactName")
                    {
                        this.chkFreeText.Items[1].Selected = true;
                    }
                    if (strArrays1[k] == "SalesPerson")
                    {
                        this.chkFreeText.Items[2].Selected = true;
                    }
                    if (strArrays1[k] == "AssignedTo")
                    {
                        this.chkFreeText.Items[3].Selected = true;
                    }
                    if (strArrays1[k] == "Subject")
                    {
                        this.chkFreeText.Items[4].Selected = true;
                    }
                    if (strArrays1[k] == "Description")
                    {
                        this.chkFreeText.Items[5].Selected = true;
                    }
                }
                this.txtDescription.Text = base.SpecialDecode(row["Description"].ToString());
                if (Convert.ToInt32(row["IsCreatedDate"]) != 1)
                {
                    this.chkDateOption.Checked = false;
                }
                else
                {
                    this.chkDateOption.Checked = true;
                    
                    if (row["CreatedDateType"].ToString().Trim() == "t")
                    {
                        this.rdlDate.SelectedValue = "daily";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "y")
                    {
                        this.rdlDate.SelectedValue = "yesterday";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cm")
                    {
                        this.rdlDate.SelectedValue = "thismonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "cq")
                    {
                        this.rdlDate.SelectedValue = "thisquarter";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ay")
                    {
                        this.rdlDate.SelectedValue = ePrintConstants.ThisAnnualYear;
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lq")
                    {
                        this.rdlDate.SelectedValue = "lastquater";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lw")
                    {
                        this.rdlDate.SelectedValue = "lastweek";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "lm")
                    {
                        this.rdlDate.SelectedValue = "lastmonth";
                    }
                    else if (row["CreatedDateType"].ToString().Trim() == "ly")
                    {
                        this.rdlDate.SelectedValue = "lastyear";
                    }
                    if (row["CreatedDateType"].ToString().Trim() != "t")
                    {
                        if (row["CreatedDateType"].ToString() != "dr")
                        {
                            continue;
                        }
                        this.rdlDate.SelectedValue = "daterange";
                        this.txtFrom.Enabled = true;
                        this.txtTo.Enabled = true;
                        this.txtFrom.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateFrom"].ToString(), this.CompanyID, this.UserID, false);
                        this.txtTo.Text = this.objJava.Eprint_return_Date_Before_View(row["CreatedDateTo"].ToString(), this.CompanyID, this.UserID, false);
                    }
                }
            }
        }

        private void RunReportOnClick()
        {
            try
            {
                this.btnUpdateExisting.Visible = true;
                this.btnRunReport.Visible = true;
                this.Session["SaveAsNew"] = "SaveAsNew";
                this.btnSaveRun.Text = "Save as new";
                int num = 0;
                this.Panel1.Visible = false;
                this.pnlReports.Visible = false;
                this.div_showfilters.Style.Add("display", "none");
                this.divusrReportsave.Style.Add("display", "none");
                this.divtab.Visible = false;
                this.btnfilter.Visible = true;
                this.btnExport.Visible = true;
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
                }
                else
                {
                    DataSet activityTaskEventData = this.GetActivityTaskEventData(1);
                    this.lblTotalRecords.Text = activityTaskEventData.Tables[1].Rows[0][0].ToString();
                    if (activityTaskEventData.Tables[0].Rows.Count == 0)
                    {
                        this.pnlEmptyRecords.Visible = true;
                        this.GridEstReport.Visible = false;
                        this.btnExport.Visible = false;
                        this.btnExportPPT.Visible = false;
                        this.divtoolbar.Visible = true;
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                    }
                    else if (Convert.ToInt32(activityTaskEventData.Tables[1].Rows[0][0].ToString()) > 100)
                    {
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetTaskReportColumns(activityTaskEventData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridActivityTaskEventReport_RowDataBound);
                        this.GridEstReport.DataBind();
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activityTaskEventData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                        {
                            this.GridEstReport.Visible = false;
                            this.usrPaging.Visible = false;
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                        }
                    }
                    else
                    {
                        this.txt1.Visible = false;
                        this.btngo.Visible = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkNext")).Enabled = false;
                        ((LinkButton)this.usrPaging.FindControl("lnkEnd")).Enabled = false;
                        this.GridEstReport.Visible = true;
                        this.div_Total.Visible = false;
                        this.pnlEmptyRecords.Visible = false;
                        DataTable dt = SetTaskReportColumns(activityTaskEventData);
                        this.GridEstReport.DataSource = dt;
                        //this.GridEstReport.RowDataBound += new GridViewRowEventHandler(this.GridActivityTaskEventReport_RowDataBound);
                        this.GridEstReport.DataBind();

                        for (int j = 0; j < GridEstReport.Items.Count; j++)
                        {
                            string text = this.GridEstReport.Items[j].Cells[0].Text;
                            for (int k = j + 1; k < this.GridEstReport.Items.Count; k++)
                            {
                                // Compare text of the first cell of the current item and the next item
                                if (string.Compare(text, this.GridEstReport.Items[k].Cells[0].Text, true) == 0)
                                {
                                    for (int l = 1; l < this.GridEstReport.Items[j].Cells.Count; l++)
                                    {
                                        if (string.Compare(this.GridEstReport.Items[j].Cells[l].Text, this.GridEstReport.Items[k].Cells[l].Text, true) == 0)
                                        {
                                            this.GridEstReport.Items[k].Cells[l].Text = string.Empty;
                                        }
                                    }
                                }
                            }
                        }
                        //for (int j = 0; j < this.GridEstReport.Rows.Count; j++)
                        //{
                        //    string text = this.GridEstReport.Rows[j].Cells[0].Text;
                        //    for (int k = j + 1; k < this.GridEstReport.Rows.Count; k++)
                        //    {
                        //        if (string.Compare(text, this.GridEstReport.Rows[k].Cells[0].Text, true) == 0)
                        //        {
                        //            for (int l = 0; l < this.GridEstReport.Rows[k].Cells.Count; l++)
                        //            {
                        //                if (string.Compare(this.GridEstReport.Rows[j].Cells[l].Text, this.GridEstReport.Rows[k].Cells[l].Text, true) == 0)
                        //                {
                        //                    this.GridEstReport.Rows[k].Cells[l].Text = string.Empty;
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        this.usrPaging.Visible = false;
                        pagingreport.intCurrentPage = this.PageNumber;
                        pagingreport.intPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activityTaskEventData.Tables[1].Rows[0][0].ToString()) / (double)this.PageSize));
                        this.usrPaging.CreatePaging();
                        //this.usrPaging.OnPageChange += new PagingEventHandlerreport(this.paging_OnPageChange);
                        this.CallPagingBtn_ScrollGrid(this.usrPaging);
                        if (this.ddlGrouprecords.SelectedValue.ToString().Trim() != "0")
                        {
                            this.GridEstReport.Visible = false;
                            this.usrPaging.Visible = false;
                            this.txt1.Visible = false;
                            this.btngo.Visible = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void SaveReports(string value)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            for (int i = 0; i < this.chkColumns.Items.Count; i++)
            {
                if (this.chkColumns.Items[i].Selected)
                {
                    if (i != 0)
                    {
                        str1 = this.chkColumns.Items[i].Value;
                        activity_taskeventreport clientActivityReport = this;
                        clientActivityReport.ColumnNames = string.Concat(clientActivityReport.ColumnNames, "µ", str1);
                    }
                    else
                    {
                        str1 = this.chkColumns.Items[i].Value;
                        this.ColumnNames = str1;
                    }
                }
            }
            empty = " Columns";
            str = string.Concat("'", this.ColumnNames, "'");
            if (this.ddlGrouprecords.SelectedValue.ToString().Trim() == "0")
            {
                empty = string.Concat(empty, " ,ReportType,GroupedBy");
                str = string.Concat(str, " ,'',0");
            }
            else
            {
                empty = string.Concat(empty, " ,ReportType,GroupedBy");
                str = string.Concat(str, " ,'',", this.ddlGrouprecords.SelectedValue);
            }
            if (this.txtFreeText.Text != "")
            {
                empty = string.Concat(empty, " ,SearchKeyword");
                str = string.Concat(str, " ,'", base.SpecialEncode(this.txtFreeText.Text), "'");
            }
            if (!this.chkDateOption.Checked)
            {
                empty = string.Concat(empty, " ,IsCreatedDate,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                str = string.Concat(str, " ,0,'','',''");
            }
            else
            {
                empty = string.Concat(empty, " ,IsCreatedDate");
                str = string.Concat(str, " ,1");
                if (this.rdlDate.SelectedValue == "daily")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 't','',''");
                }
                else if (this.rdlDate.SelectedValue == "yesterday")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'y','',''");
                }
                else if (this.rdlDate.SelectedValue == "thismonth")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'cm','',''");
                }
                else if (this.rdlDate.SelectedValue == "thisquarter")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'cq','',''");
                }
                else if (this.rdlDate.SelectedValue == ePrintConstants.ThisAnnualYear)
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'ay','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastquater")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lq','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastweek")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lw','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastmonth")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'lm','',''");
                }
                else if (this.rdlDate.SelectedValue == "lastyear")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    str = string.Concat(str, ", 'ly','',''");
                }
                else if (this.rdlDate.SelectedValue == "daterange")
                {
                    empty = string.Concat(empty, " ,CreatedDateType,CreatedDateFrom,CreatedDateTo");
                    string str2 = str;
                    string[] strArrays = new string[] { str2, ", 'dr','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtFrom.Text), "','", this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtTo.Text), "'" };
                    str = string.Concat(strArrays);
                }
            }
            for (int j = 0; j < this.chkFreeText.Items.Count; j++)
            {
                if (this.chkFreeText.Items[j].Selected)
                {
                    if (j != 0)
                    {
                        this.FreeTextColoumn = this.chkFreeText.Items[j].Value;
                        empty2 = string.Concat(empty2, "µ", this.FreeTextColoumn);
                    }
                    else
                    {
                        this.FreeTextColoumn = this.chkFreeText.Items[j].Value;
                        empty2 = string.Concat(empty2, this.FreeTextColoumn);
                    }
                }
            }
            empty = string.Concat(empty, " ,SelectedSearchText");
            str = string.Concat(str, " ,'", empty2, "'");
            if (this.txtSaveReports.Text != "")
            {
                empty = string.Concat(empty, " ,ReportName");
                str = string.Concat(str, ", '", base.SpecialEncode(this.txtSaveReports.Text), "'");
            }
            if (this.txtDescription.Text != "")
            {
                empty = string.Concat(empty, " ,Description");
                str = string.Concat(str, ", '", base.SpecialEncode(this.txtDescription.Text), "'");
            }
            empty = string.Concat(empty, " ,PageName,CompanyID,UserID");
            object obj = str;
            object[] num = new object[] { obj, ", 'activitytaskeventreport',", Convert.ToInt32(this.Session["companyid"].ToString()), ",", Convert.ToInt32(this.Session["UserID"].ToString()) };
            str = string.Concat(num);
            if (value == "Save")
            {
                string[] strArrays1 = new string[] { "Insert into tb_Reports_Save(", empty, ") Values (", str, ")" };
                empty1 = string.Concat(strArrays1);
            }
            else if (value == "Update")
            {
                if (this.hdn_reportID.Value == "")
                {
                    this.hdn_reportID.Value = "0";
                }
                empty1 = string.Concat("delete tb_reports_save where ReportID=", Convert.ToInt32(this.hdn_reportID.Value));
                string[] strArrays2 = new string[] { " ", empty1, "Insert into tb_Reports_Save(", empty, ") Values (", str, ")" };
                empty1 = string.Concat(strArrays2);
                this.hdn_reportID.Value = "";
            }
            SqlCommand sqlCommand = new SqlCommand(empty1, this.objJava.openConnection())
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
            this.div_showfilters.Style.Add("display", "block");
            this.divusrReportsave.Style.Add("display", "none");
            this.divtab.Visible = true;
            this.GridEstReport.Visible = false;
            this.div_Total.Visible = false;
            this.btnfilter.Visible = false;
            this.btnExport.Visible = false;
            this.divtoolbar.Visible = false;
            this.txt1.Visible = false;
            this.btngo.Visible = false;
            this.pnlEmptyRecords.Visible = false;
            this.usrPaging.Visible = false;
            this.btnUpdateExisting.Visible = true;
            this.btnSaveRun.Visible = true;
            this.btnRunReport.Visible = false;
            this.btnSaveRun.Text = "Save as New";
            this.ReportDetails(ReportID);
            this.hdn_reportID.Value = ReportID.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "selected", "javascript:OnEditCallReport();", true);
        }

        private void usrReportsave_OnReportClick(int ReportID)
        {
            if (ReportID == 0)
            {
                this.Session["DeleteMsg"] = "SelectDeleteTab";
                return;
            }
            this.Session["DeleteMsg"] = null;
            this.ReportDetails(ReportID);
            this.RunReportOnClick();
            this.hdn_reportID.Value = ReportID.ToString();
        }


        protected void GridTask_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (base.IsPostBack)
            {
                DataSet TaskData = this.GetActivityTaskEventData(this.PageNumber);
                DataTable dt = SetTaskReportColumns(TaskData);
                this.GridEstReport.DataSource = dt;
            }

        }
        protected void GridTask_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageNumber = e.NewPageIndex + 1;
        }

        protected void GridTask_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.Session["DeleteMsg"] = null;
            this.PageSize = e.NewPageSize;
        }
    }
}