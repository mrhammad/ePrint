using nmsLanguage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Printcenter.UI.Setting;
using nmsCommon;
using System.Globalization;

namespace ePrint.settings
{
    public partial class FTPLogs : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        public int CompanyID;

        public int UserID;

        private commonClass cmnClass = new commonClass();

        public string DateFormat = string.Empty;

        public string strSitepath = global.sitePath();

        //protected void rgFtpLog_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    DataTable dt = SettingsBasePage.GetFtpLogSettings(this.CompanyID); 
        //    rgFtpLog.DataSource = dt;
        //}
        protected void rgFtpLog_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt = SettingsBasePage.GetFtpLogSettings(this.CompanyID);
            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("TimeStamp"))
                {

                    string formattedDateStr = this.cmnClass.Eprint_return_DateTime_Before_View(row["TimeStamp"].ToString(), CompanyID, UserID, false);
                    if (DateTime.TryParseExact(formattedDateStr,"dd/MM/yyyy hh:mm:ss tt",CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime parsedDate))
                    {
                        row["TimeStamp"] = parsedDate;
                    }
                    //row["TimeStamp"] = this.cmnClass.Eprint_return_Date_Before_View(row["TimeStamp"].ToString(), CompanyID, UserID, false);
                }
            }
            DataTable filteredTable = dt.Copy();

            string filterExpression = "";
            var tableView = rgFtpLog.MasterTableView;

            // 1. TimeStamp (DateTime -> convert to string for filtering)
            string timeStampFilter = tableView.GetColumn("TimeStamp").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(timeStampFilter))
            {
                string _date = string.Empty;
                _date = this.cmnClass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, timeStampFilter.Trim());
                filterExpression = $"CONVERT(TimeStamp, 'System.String') LIKE '%{_date.Replace("'", "''")}%' AND ";
            }

            // 2. Status (TemplateColumn - needs manual filter)
            string statusFilter = tableView.GetColumn("Status").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(statusFilter))
            {
                filterExpression += $"Status LIKE '%{statusFilter.Replace("'", "''")}%' AND ";
            }

            // 3. TargetDestination
            string targetFilter = tableView.GetColumn("TargetDestination").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(targetFilter))
            {
                filterExpression += $"TargetDestination LIKE '%{targetFilter.Replace("'", "''")}%' AND ";
            }

            string failureReasonFilter = tableView.GetColumn("FailureReasons").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(failureReasonFilter))
            {
                filterExpression += $"FTPError LIKE '%{failureReasonFilter.Replace("'", "''")}%' AND ";
            }

            // 4. FileName
            string fileNameFilter = tableView.GetColumn("FileName").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(fileNameFilter))
            {
                filterExpression += $"FileName LIKE '%{fileNameFilter.Replace("'", "''")}%' AND ";
            }

            // 5. ProductCode (TemplateColumn - manual)
            string productCodeFilter = tableView.GetColumn("ProductCode").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(productCodeFilter))
            {
                filterExpression += $"ProductCode LIKE '%{productCodeFilter.Replace("'", "''")}%' AND ";
            }

            // 6. OrderEstimateNo (TemplateColumn - manual)
            string orderFilter = tableView.GetColumn("OrderEstimateNo").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(orderFilter))
            {
                filterExpression += $"OrderEstimateNo LIKE '%{orderFilter.Replace("'", "''")}%' AND ";
            }

            // 7. JobNumber (TemplateColumn - manual)
            string jobFilter = tableView.GetColumn("JobNumber").CurrentFilterValue;
            if (!string.IsNullOrWhiteSpace(jobFilter))
            {
                filterExpression += $"JobNumber LIKE '%{jobFilter.Replace("'", "''")}%' AND ";
            }

            // Trim trailing 'AND'
            if (filterExpression.EndsWith(" AND "))
            {
                filterExpression = filterExpression.Substring(0, filterExpression.Length - 5);
            }

            if (!string.IsNullOrEmpty(filterExpression))
            {
                try
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = filterExpression;
                    filteredTable = dv.ToTable();
                }
                catch (Exception ex)
                {
                    // Log or handle invalid filter expressions (optional)
                }
            }

            rgFtpLog.DataSource = filteredTable;
        }
        protected void clrFilters_Click(object sender, EventArgs e)
        {
            rgFtpLog.MasterTableView.FilterExpression = string.Empty;
            foreach (Telerik.Web.UI.GridColumn column in rgFtpLog.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.rgFtpLog.MasterTableView.FilterExpression = string.Empty;
            rgFtpLog.MasterTableView.Rebind();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Telerik.Web.UI.GridFilterMenu filterMenu = this.rgFtpLog.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("FTP_Logs");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("FTP_Logs");
            base.Session["pagename"] = "setting";
            this.DateFormat = this.Session["Dateformat"].ToString();
            if (!IsPostBack)
            {
                rgFtpLog.Rebind();
            }
        }
    }
}