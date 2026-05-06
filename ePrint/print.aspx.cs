using nmsCommon;
using nmsLanguage;
using Printcenter.UI.dashboard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Charting;
using Telerik.Charting.Styles;
using Telerik.Web.UI;

namespace ePrint
{
    public partial class print : System.Web.UI.Page
    {
        public languageClass objLanguage = new languageClass();//kr

        public string strSitepath = global.sitePath();//kr

        public commonClass objCommon = new commonClass();

        private BaseClass objbase = new BaseClass();

        private long CopyMasterID;

        private long MasterID;

        private string GraphType = "";

        private string status = "";

        private string ShowArchivedStatus = "";

        private string salesperson = "";

        private string ModuleName = "";

        private int NoOfRecords;

        private string WhereCondition = "";

        public string DateFormat = string.Empty;

        private string CustomizeColumns = "";

        private int CustomerID;

        private string Date = "";

        private string DisplayType = "";

        private string CompanyType = "";

        private string EstimateType = "";

        private string QuarterType = "";

        private string WidgetsTitle = "";

        private string ChartType = "";

        private string SalePID = "";

        private string ForecastType = "";

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

        public print()
        {
        }

        public string BarColors(int ai)
        {
            string str = "";
            try
            {
                if (ai > 10)
                {
                    ai -= 10;
                    if (ai > 10)
                    {
                        ai -= 10;
                    }
                }
                string[] strArrays = new string[] { "#23AD2E", "#FF9200", "#1789C5", "#A77CCB", "#ED8ED1", "#C8C800", "#00C8DA", "#EB6E38", "#F6924E", "#1368B2", "#00BCA7", "#41546F", "#8ED0D2" };
                str = strArrays[ai];
            }
            catch
            {
            }
            return str;
        }

        public void BindCustomerActivityGrid(RadGrid Grid, int noOfRecords, string Columns, string companyType)
        {
            try
            {
                string caption = "";
                string languageConversion = "";
                string str = Columns.Replace("Customer Name", "CustomerName").Replace("Main Contact", "MainContact").Replace("Phone", "MainContactPhone").Replace("Last Activity Type", "LastActivityType").Replace("Time", "time");
                DataSet dataSet = dashboardestimate.Dashboard_CustomerActivity_Select((long)Convert.ToInt32(this.Session["CompanyID"]), Convert.ToInt32(this.Session["UserID"]), companyType, noOfRecords, str);
                if (dataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        caption = dataSet.Tables[0].Columns[i].Caption;
                        languageConversion = dataSet.Tables[0].Columns[i].Caption;
                        if (languageConversion.ToLower() == "customername" || languageConversion.ToLower() == "maincontact" || languageConversion.ToLower() == "maincontactphone" || languageConversion.ToLower() == "lastactivitytype" || languageConversion.ToLower() == "time")
                        {
                            if (languageConversion.ToLower() == "customername")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Customer_Name");
                            }
                            else if (languageConversion.ToLower() == "maincontact")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Main_Contact");
                            }
                            else if (languageConversion.ToLower() == "maincontactphone")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Phone");
                            }
                            else if (languageConversion.ToLower() == "lastactivitytype")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Last_Activity_Type");
                            }
                            else if (languageConversion.ToLower() == "time")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Time");
                            }
                            this.GenerateCustomerActivityGridBoundColumns(caption, languageConversion, Grid);
                        }
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["CustomerName"] = this.objbase.SpecialDecode(row["CustomerName"].ToString());
                        }
                        catch
                        {
                        }
                    }
                    Grid.DataSource = dataSet;
                    Grid.DataBind();
                }
            }
            catch
            {
            }
        }

        public void BindGrid()
        {
            try
            {
                HtmlGenericControl htmlGenericControl = new HtmlGenericControl("div");
                htmlGenericControl.Attributes.Add("style", "border-bottom: 1px solid #C9C9C9; width: 99.1%; margin-top:20px;");
                RadGrid radGrid = new RadGrid()
                {
                    Width = System.Web.UI.WebControls.Unit.Percentage(99),
                    Height = System.Web.UI.WebControls.Unit.Percentage(99)
                };
                radGrid.Style.Add("margin-bottom", "6px");
                radGrid.ID = string.Concat("radGrid_", this.CopyMasterID.ToString());
                radGrid.ClientSettings.Scrolling.AllowScroll = false;
                radGrid.AutoGenerateColumns = false;
                radGrid.AllowPaging = false;
                radGrid.AllowSorting = false;
                radGrid.AllowFilteringByColumn = false;
                radGrid.Skin = "Default";
                radGrid.CssClass = "AddBorders";
                radGrid.HeaderStyle.Font.Bold = true;
                radGrid.GridLines = GridLines.None;
                radGrid.HeaderStyle.ForeColor = ColorTranslator.FromHtml("#333333");
                radGrid.HeaderStyle.BorderStyle = BorderStyle.Double;
                radGrid.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
                radGrid.EnableEmbeddedSkins = true;
                radGrid.AlternatingItemStyle.BackColor = Color.White;
                radGrid.MasterTableView.NoMasterRecordsText = "<div style='margin-left:-px; margin-top:5px;'> No Records Found </div>";
                radGrid.ClientSettings.ClientEvents.OnRowMouseOver = "RowMouseOver";
                radGrid.ClientSettings.ClientEvents.OnRowMouseOut = "RowMouseOut";
                radGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                Label label = new Label()
                {
                    Text = this.WidgetsTitle,
                    ID = string.Concat("LabelwidgetsName_", this.CopyMasterID)
                };
                label.Style.Add("margin-right", "10px; font-weight:bold;");
                label.Style.Add("float", "left;");
                LinkButton linkButton = new LinkButton()
                {
                    Text = this.objLanguage.GetLanguageConversion("Print"),
                    ID = string.Concat("lnkPrint_", this.CopyMasterID)
                };
                linkButton.Style.Add("margin-right", "10px;");
                linkButton.Style.Add("float", "right;");
                linkButton.OnClientClick = "Javascript:printfun();";
                if (this.MasterID == (long)5)
                {
                    this.BindLatestNotesGrid(radGrid, this.NoOfRecords, this.CustomizeColumns, (long)this.CustomerID);
                }
                else if (this.MasterID == (long)4)
                {
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewTaskCall);
                    this.BindGrid(radGrid, this.Date, this.NoOfRecords, this.DisplayType, this.SalePID);
                }
                else if (this.MasterID == (long)7)
                {
                    this.BindCustomerActivityGrid(radGrid, Convert.ToInt32(this.NoOfRecords), this.CustomizeColumns, this.CompanyType);
                }
                else if (this.MasterID == (long)11)
                {
                    this.BindGrid_ForAdmin(radGrid, this.Date, this.NoOfRecords, this.DisplayType, Convert.ToInt64(this.CustomerID), Convert.ToInt64(this.salesperson));
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewTaskCall);
                }
                if (this.MasterID == (long)9)
                {
                    if (this.ModuleName.ToString().ToLower() != "company")
                    {
                        this.BindTargetVSActual(radGrid, this.salesperson, this.QuarterType, this.EstimateType);
                    }
                    else
                    {
                        this.BindTargetVSActual(radGrid, "-1", this.QuarterType, this.EstimateType);
                    }
                }
                if (this.MasterID == (long)12)
                {
                    this.BindGrid1(radGrid, this.Date, this.SalePID);
                }
                this.plsGrid.Controls.Add(label);
                this.plsGrid.Controls.Add(linkButton);
                this.plsGrid.Controls.Add(htmlGenericControl);
                this.plsGrid.Controls.Add(radGrid);
            }
            catch
            {
            }
        }

        public void BindGrid(RadGrid Grid, string dateType, int noOfRecords, string RecordType, string SalePID)
        {
            try
            {
                string caption = "";
                string languageConversion = "";
                if (dateType == "1")
                {
                    dateType = "Today";
                }
                else if (dateType == "2")
                {
                    dateType = "TodayOverDue";
                }
                else if (dateType == "3")
                {
                    dateType = "Tomorrow";
                }
                else if (dateType == "4")
                {
                    dateType = "Next7Days";
                }
                else if (dateType == "5")
                {
                    dateType = "Next7DaysPlusOverDue";
                }
                else if (dateType == "6")
                {
                    dateType = "ThisMonth";
                }
                else if (dateType == "7")
                {
                    dateType = "AllOpen";
                }
                else if (dateType == "8")
                {
                    dateType = "All";
                }
                else if (dateType == "All")
                {
                    dateType = "All";
                }
                else if (dateType != "-1")
                {
                    dateType = "";
                }
                else
                {
                    dateType = "-1";
                }
                DataSet dataSet = dashboardestimate.Dashboard_Select_TaskCall(Convert.ToInt64(this.Session["CompanyId"]), dateType, noOfRecords, RecordType, SalePID);
                if (dataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        caption = dataSet.Tables[0].Columns[i].Caption;
                        languageConversion = dataSet.Tables[0].Columns[i].Caption;
                        if (languageConversion.ToLower() == "activitytype" || languageConversion.ToLower() == "companyname" || languageConversion.ToLower() == "taskstatus" || languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "duedate" || languageConversion.ToLower() == "contactname" || languageConversion.ToLower() == "assigntousername")
                        {
                            if (languageConversion.ToLower() == "activitytype")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Type");
                            }
                            if (languageConversion.ToLower() == "taskstatus")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Status");
                            }
                            else if (languageConversion.ToLower() == "subject")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Subject");
                            }
                            else if (languageConversion.ToLower() == "duedate")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Due_Date");
                            }
                            else if (languageConversion.ToLower() == "contactname")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Contact_Name");
                            }
                            else if (languageConversion.ToLower() == "assigntousername")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Assigned_To");
                            }
                            else if (languageConversion.ToLower() == "companyname")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Customer_Name");
                            }
                            this.GenerateGridBoundColumns(caption, languageConversion, Grid);
                        }
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            try
                            {
                                row["AssignToUserName"] = this.objbase.SpecialDecode(row["AssignToUserName"].ToString());
                                row["CompanyName"] = this.objbase.SpecialDecode(row["CompanyName"].ToString());
                                row["ContactName"] = this.objbase.SpecialDecode(row["ContactName"].ToString());
                            }
                            catch
                            {
                            }
                        }
                    }
                    Grid.DataSource = dataSet;
                    Grid.DataBind();
                }
            }
            catch
            {
            }
        }

        public void BindGrid_ForAdmin(RadGrid Grid, string dateType, int noOfRecords, string RecordType, long CustomerID, long DisplayRecordSalesOf)
        {
            string caption = "";
            string languageConversion = "";
            if (dateType == "1")
            {
                dateType = "Today";
            }
            else if (dateType == "2")
            {
                dateType = "TodayOverDue";
            }
            else if (dateType == "3")
            {
                dateType = "Tomorrow";
            }
            else if (dateType == "4")
            {
                dateType = "Next7Days";
            }
            else if (dateType == "5")
            {
                dateType = "Next7DaysPlusOverDue";
            }
            else if (dateType == "6")
            {
                dateType = "ThisMonth";
            }
            else if (dateType == "7")
            {
                dateType = "AllOpen";
            }
            else if (dateType == "8")
            {
                dateType = "All";
            }
            DataSet dataSet = dashboardestimate.Dashboard_Select_TaskCall_ForAdmin((long)Convert.ToInt32(this.Session["CompanyID"]), Convert.ToInt32(this.Session["UserID"]), dateType, noOfRecords, RecordType, CustomerID, DisplayRecordSalesOf);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    if (languageConversion.ToLower() == "activitytype" || languageConversion.ToLower() == "taskstatus" || languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "duedate" || languageConversion.ToLower() == "contactname" || languageConversion.ToLower() == "assigntousername")
                    {
                        if (languageConversion.ToLower() == "activitytype")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Type");
                        }
                        if (languageConversion.ToLower() == "taskstatus")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Status");
                        }
                        else if (languageConversion.ToLower() == "subject")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Subject");
                        }
                        else if (languageConversion.ToLower() == "duedate")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Due_Date");
                        }
                        else if (languageConversion.ToLower() == "contactname")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Contact_Name");
                        }
                        else if (languageConversion.ToLower() == "assigntousername")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Assigned_To");
                        }
                        this.GenerateGridBoundColumns(caption, languageConversion, Grid);
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["AssignToUserName"] = this.objbase.SpecialDecode(row["AssignToUserName"].ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BindGrid1(RadGrid Grid, string dateType, string SalesPerson)
        {
            string caption = "";
            string languageConversion = "";
            if (dateType == "1")
            {
                dateType = "Today";
            }
            else if (dateType == "2")
            {
                dateType = "ThisWeek";
            }
            else if (dateType == "3")
            {
                dateType = "ThisMonth";
            }
            DataSet dataSet = dashboardestimate.Dashboard_Select_CallVS(Convert.ToInt64(this.Session["CompanyId"]), dateType, SalesPerson);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    if (languageConversion.ToLower() == "salespersonname" || languageConversion.ToLower() == "scheduled" || languageConversion.ToLower() == "completed")
                    {
                        if (languageConversion.ToLower() == "salespersonname")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Assigned_To");
                        }
                        else if (languageConversion.ToLower() == "scheduled")
                        {
                            languageConversion = "Scheduled";
                        }
                        else if (languageConversion.ToLower() == "completed")
                        {
                            languageConversion = "Completed";
                        }
                        this.GenerateGridBoundColumnsForCallVS(caption, languageConversion, Grid);
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["SalesPersonName"] = this.objbase.SpecialDecode(row["SalesPersonName"].ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BindLatestNotesGrid(RadGrid Grid, int noOfRecords, string Columns, long clientID)
        {
            try
            {
                string caption = "";
                string languageConversion = "";
                string str = "";
                string str1 = "";
                DataSet fromUsertypeShowAll = dashboardestimate.GetFromUsertype_ShowAll(Convert.ToInt32(this.Session["CompanyID"]), Convert.ToInt32(this.Session["UserID"]));
                foreach (DataRow row in fromUsertypeShowAll.Tables[0].Rows)
                {
                    if (row["CompanyType"].ToString() != "")
                    {
                        str = row["CompanyType"].ToString().Substring(0, row["CompanyType"].ToString().Length - 1);
                    }
                    str1 = row["ShowRecords"].ToString();
                }
                string str2 = Columns.Replace("Created By", "CreatedBy").Replace("Created On", "CreatedOn").Replace("Specific To", "SpecificTo").Replace("Note Title", "title").Replace("Note Content", "Subject").Replace("Specific to Contact", "Specificto").Replace("Customer Name", "CustomerName");
                DataSet dataSet = dashboardestimate.Dashboard_LatestNotes_Select(clientID, (long)Convert.ToInt32(this.Session["CompanyID"]), str, str1, (long)Convert.ToInt32(this.Session["UserID"]), noOfRecords, str2);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        caption = dataSet.Tables[0].Columns[i].Caption;
                        languageConversion = dataSet.Tables[0].Columns[i].Caption;
                        if (languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "title" || languageConversion.ToLower() == "createdby" || languageConversion.ToLower() == "createdon" || languageConversion.ToLower() == "specificto" || languageConversion.ToLower() == "customername")
                        {
                            if (languageConversion.ToLower() == "subject")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Notes");
                            }
                            else if (languageConversion.ToLower() == "title")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Title");
                            }
                            else if (languageConversion.ToLower() == "createdby")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Created_By");
                            }
                            else if (languageConversion.ToLower() == "createdon")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Created_On");
                            }
                            else if (languageConversion.ToLower() == "specificto")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Specific_to_Contact");
                            }
                            else if (languageConversion.ToLower() == "customername")
                            {
                                languageConversion = this.objLanguage.GetLanguageConversion("Customer_Name");
                            }
                            this.GenerateLatestNotesGridBoundColumns(caption, languageConversion, Grid);
                        }
                        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                        {
                            try
                            {
                                dataRow["CreatedBy"] = this.objbase.SpecialDecode(dataRow["CreatedBy"].ToString());
                                dataRow["SpecificTo"] = this.objbase.SpecialDecode(dataRow["SpecificTo"].ToString());
                                dataRow["CustomerName"] = this.objbase.SpecialDecode(dataRow["CustomerName"].ToString());
                                dataRow["Subject"] = this.objbase.SpecialDecode(dataRow["Subject"].ToString());
                                dataRow["title"] = this.objbase.SpecialDecode(dataRow["title"].ToString());
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
            catch
            {
            }
        }

        public void BindTargetVSActual(RadGrid Grid, string SalesOf, string QuarterType, string EstimateType)
        {
            string caption = "";
            string languageConversion = "";
            string quarterType = QuarterType;
            DataSet dataSet = new DataSet();
            dataSet = dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), SalesOf, quarterType, EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    if (languageConversion.ToLower() == "actualvalue" || languageConversion.ToLower() == "targetvalue" || languageConversion.ToLower() == "username")
                    {
                        if (languageConversion.ToLower() == "actualvalue")
                        {
                            languageConversion = string.Concat(this.objLanguage.GetLanguageConversion("Actual_Amount"), " (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        else if (languageConversion.ToLower() == "targetvalue")
                        {
                            languageConversion = string.Concat(this.objLanguage.GetLanguageConversion("Target_Amount"), " (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        else if (languageConversion.ToLower() == "username")
                        {
                            languageConversion = this.objLanguage.GetLanguageConversion("Sales_Person");
                        }
                        this.GenerateTargetVSActualGridBoundColumns(caption, languageConversion, Grid);
                    }
                }
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    try
                    {
                        row["username"] = this.objbase.SpecialDecode(row["username"].ToString());
                    }
                    catch
                    {
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BintEstimateCountByStatusBAR()
        {
            string[] str;
            Color[] colorArray;
            try
            {
                RadChart radChart = new RadChart()
                {
                    ID = string.Concat("radChart_", this.CopyMasterID)
                };
                radChart.PlotArea.EmptySeriesMessage.TextBlock.Text = "No Records Found";
                radChart.PlotArea.EmptySeriesMessage.TextBlock.Appearance.TextProperties.Font = new Font("Lucida Sans Unicode,Arial,Helvetica,sans-serif", 10f, FontStyle.Regular);
                radChart.Width = new System.Web.UI.WebControls.Unit("1080px");
                radChart.Height = new System.Web.UI.WebControls.Unit("570px");
                radChart.AutoTextWrap = false;
                radChart.AutoLayout = true;
                radChart.Skin = "Vista";
                radChart.Style.Add("margin-top", "7px;");
                radChart.Style.Add("margin-bottom", "5px;");
                radChart.Style.Add("float", "left;");
                radChart.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
                radChart.Appearance.Border.Visible = false;
                radChart.Appearance.FillStyle.FillType = FillType.Image;
                radChart.ChartTitle.Visible = false;
                DataSet dataSet = new DataSet();
                radChart.ChartTitle.TextBlock.Appearance.TextProperties.Font = new Font("Lucida Sans Unicode,Arial,Helvetica,sans-serif", 12f, FontStyle.Bold);
                radChart.PlotArea.XAxis.AutoScale = false;
                if (this.MasterID == (long)1 || this.MasterID == (long)10)
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_ItemDataBound);
                }
                if (this.MasterID == (long)3)
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChartJobInvoice_ItemDataBound);
                }
                else if (this.MasterID == (long)8 && this.GraphType.ToString().ToLower() != "stackedbar")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_EstimateJobInvoiceItemDataBound);
                }
                Label label = new Label()
                {
                    Text = this.WidgetsTitle,
                    ID = string.Concat("LabelwidgetsName_", this.CopyMasterID)
                };
                label.Style.Add("margin-right", "10px; font-weight:bold;");
                label.Style.Add("float", "left;");
                LinkButton linkButton = new LinkButton()
                {
                    Text = this.objLanguage.GetLanguageConversion("Print"),
                    ID = string.Concat("lnkPrint_", this.CopyMasterID)
                };
                linkButton.Style.Add("margin-right", "10px;");
                linkButton.Style.Add("float", "right;");
                linkButton.OnClientClick = "Javascript:printfun();";
                if (this.MasterID == (long)1)
                {
                    int num = 0;
                    if (this.GraphType != "Bar")
                    {
                        dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.status, this.ModuleName, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                if (dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString().Length <= 8)
                                {
                                    radChart.PlotArea.XAxis[num].TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.PlotArea.XAxis.Items[num].ActiveRegion.Tooltip = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.Legend.TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num].TextBlock.Text = string.Concat(this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString()).Substring(0, 5), "...");
                                    radChart.PlotArea.XAxis.Items[num].ActiveRegion.Tooltip = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.Legend.TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                }
                                num++;
                            }
                        }
                        ChartSeries chartSeries = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), this.GraphType)
                        };
                        chartSeries.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries.DataYColumn = "ProbabilitySum";
                        try
                        {
                            chartSeries.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                        radChart.Series.Add(chartSeries);
                        radChart.DataSource = dataSet;
                        radChart.DataBind();
                        radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;
                        radChart.Legend.Visible = true;
                        int num1 = 0;
                        foreach (ChartSeriesItem item in radChart.Series[0].Items)
                        {
                            int num2 = num1;
                            num1 = num2 + 1;
                            item.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num2));
                            item.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                    else
                    {
                        dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.status, this.ModuleName, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable table = dataViews.ToTable(true, str);
                            DataView dataViews1 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable dataTable = dataViews.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table.Rows.Count, 1);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ChartSeries chartSeries1 = new ChartSeries(row["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row["EstimateStatus"].ToString().Length <= 10)
                                {
                                    chartSeries1.Name = row["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries1.Name = string.Concat(row["EstimateStatus"].ToString().Substring(0, 10), "..");
                                }
                                chartSeries1.YAxisType = ChartYAxisType.Primary;
                                chartSeries1.Type = ChartSeriesType.Bar;
                                chartSeries1.Appearance.LabelAppearance.Visible = true;
                                int num3 = 0;
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    DataTable item1 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row["EstimateStatus"].ToString(), "' and EstimateStatus='", dataRow["EstimateStatus"].ToString(), "'" };
                                    DataRow[] dataRowArray = item1.Select(string.Concat(str));
                                    if ((int)dataRowArray.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem.Label.Visible = false;
                                        chartSeries1.AddItem(chartSeriesItem, new ChartSeriesItem[0]);
                                        num3++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem1 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray[0]["TotalNoOfCount"]),
                                            Name = dataRowArray[0]["EstimateStatus"].ToString()
                                        };
                                        chartSeriesItem1.Label.Visible = false;
                                        str = new string[] { dataRowArray[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray[0]["TotalNoOfCount"].ToString() };
                                        string str1 = string.Concat(str);
                                        chartSeriesItem1.Label.ActiveRegion.Tooltip = str1;
                                        chartSeriesItem1.ActiveRegion.Tooltip = str1;
                                        chartSeries1.AddItem(chartSeriesItem1, new ChartSeriesItem[0]);
                                        if (dataRowArray[0]["EstimateStatus"].ToString().Length <= 13)
                                        {
                                            radChart.PlotArea.XAxis[num3].TextBlock.Text = dataRowArray[0]["EstimateStatus"].ToString();
                                            radChart.PlotArea.XAxis.Items[num3].ActiveRegion.Tooltip = dataRowArray[0]["EstimateStatus"].ToString();
                                        }
                                        else
                                        {
                                            radChart.PlotArea.XAxis[num3].TextBlock.Text = string.Concat(dataRowArray[0]["EstimateStatus"].ToString().Substring(0, 13), "...");
                                            radChart.PlotArea.XAxis.Items[num3].ActiveRegion.Tooltip = dataRowArray[0]["EstimateStatus"].ToString();
                                        }
                                        num3++;
                                    }
                                }
                                radChart.Series.Add(chartSeries1);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                        Palette palette = new Palette("seriesPalette", colorArray, true);
                        radChart.CustomPalettes.Add(palette);
                        radChart.SeriesPalette = "seriesPalette";
                    }
                }
                else if (this.MasterID == (long)2)
                {
                    if (this.GraphType.ToString().ToLower() != "stackedbar")
                    {
                        dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews2 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "SalespersonName" };
                            DataTable table1 = dataViews2.ToTable(true, str);
                            DataView dataViews3 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable dataTable1 = dataViews2.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table1.Rows.Count, 1);
                            foreach (DataRow row1 in dataTable1.Rows)
                            {
                                ChartSeries chartSeries2 = new ChartSeries(row1["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row1["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries2.Name = row1["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries2.Name = string.Concat(row1["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries2.YAxisType = ChartYAxisType.Primary;
                                chartSeries2.Type = ChartSeriesType.Bar;
                                chartSeries2.Appearance.LabelAppearance.Visible = true;
                                int num4 = 0;
                                foreach (DataRow dataRow1 in table1.Rows)
                                {
                                    DataTable item2 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row1["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow1["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray1 = item2.Select(string.Concat(str));
                                    if ((int)dataRowArray1.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem2 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem2.Label.Visible = false;
                                        chartSeries2.AddItem(chartSeriesItem2, new ChartSeriesItem[0]);
                                        num4++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem3 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray1[0]["Estimatevalue"]),
                                            Name = dataRowArray1[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem3.Label.Visible = false;
                                        str = new string[] { dataRowArray1[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray1[0]["Estimatevalue"].ToString() };
                                        string str2 = string.Concat(str);
                                        chartSeriesItem3.Label.ActiveRegion.Tooltip = str2;
                                        chartSeriesItem3.ActiveRegion.Tooltip = str2;
                                        chartSeries2.AddItem(chartSeriesItem3, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num4].TextBlock.Text = dataRowArray1[0]["SalespersonName"].ToString();
                                        num4++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(chartSeries2);
                                radChart.PlotArea.XAxis.AutoScale = false;
                                try
                                {
                                    chartSeries2.PlotArea.YAxis.Appearance.CustomFormat = string.Concat(this.objCommon.GetCurrencyinRequiredFormate("", true), " #");
                                }
                                catch
                                {
                                }
                            }
                        }
                        radChart.DataBind();
                    }
                    else
                    {
                        dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews4 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "SalespersonName" };
                            DataTable table2 = dataViews4.ToTable(true, str);
                            DataView dataViews5 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable dataTable2 = dataViews4.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table2.Rows.Count, 1);
                            foreach (DataRow row2 in dataTable2.Rows)
                            {
                                ChartSeries chartSeries3 = new ChartSeries(row2["EstimateStatus"].ToString(), ChartSeriesType.StackedBar);
                                if (row2["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries3.Name = row2["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries3.Name = string.Concat(row2["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries3.YAxisType = ChartYAxisType.Primary;
                                chartSeries3.Type = ChartSeriesType.StackedBar;
                                chartSeries3.Appearance.LabelAppearance.Visible = true;
                                int num5 = 0;
                                foreach (DataRow dataRow2 in table2.Rows)
                                {
                                    DataTable item3 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row2["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow2["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray2 = item3.Select(string.Concat(str));
                                    if ((int)dataRowArray2.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem4 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem4.Label.Visible = false;
                                        chartSeries3.AddItem(chartSeriesItem4, new ChartSeriesItem[0]);
                                        num5++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem5 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray2[0]["Estimatevalue"]),
                                            Name = dataRowArray2[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem5.Label.Visible = false;
                                        str = new string[] { dataRowArray2[0]["EstimateStatus"].ToString(), "\r\n Total Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray2[0]["Estimatevalue"].ToString() };
                                        string str3 = string.Concat(str);
                                        chartSeriesItem5.Label.ActiveRegion.Tooltip = str3;
                                        chartSeriesItem5.ActiveRegion.Tooltip = str3;
                                        chartSeries3.AddItem(chartSeriesItem5, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num5].TextBlock.Text = dataRowArray2[0]["SalespersonName"].ToString();
                                        num5++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(chartSeries3);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        radChart.DataBind();
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette1 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette1);
                    radChart.SeriesPalette = "seriesPalette";
                }
                else if (this.MasterID == (long)3)
                {
                    int num6 = 0;
                    dataSet = dashboardestimate.Dashboard_Select_ByDueDate_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.WhereCondition, this.NoOfRecords, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                        for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                        {
                            radChart.PlotArea.XAxis[num6].TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[j]["StatusName"].ToString());
                            radChart.PlotArea.XAxis.Items[num6].ActiveRegion.Tooltip = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[j]["StatusName"].ToString());
                            num6++;
                        }
                    }
                    ChartSeries chartSeries4 = new ChartSeries()
                    {
                        Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), this.GraphType)
                    };
                    chartSeries4.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                    chartSeries4.DataYColumn = "TotalCount";
                    if (this.GraphType.ToString().ToLower() == "pie")
                    {
                        try
                        {
                            chartSeries4.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                    }
                    radChart.Series.Add(chartSeries4);
                    radChart.DataSource = dataSet;
                    radChart.DataBind();
                    radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;
                    radChart.Legend.Visible = true;
                    if (this.GraphType.ToString().ToLower() != "line")
                    {
                        int num7 = 0;
                        foreach (ChartSeriesItem item4 in radChart.Series[0].Items)
                        {
                            int num8 = num7;
                            num7 = num8 + 1;
                            item4.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num8));
                            item4.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                    else
                    {
                        colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                        Palette palette2 = new Palette("seriesPalette", colorArray, true);
                        radChart.CustomPalettes.Add(palette2);
                        radChart.SeriesPalette = "seriesPalette";
                    }
                }
                else if (this.MasterID == (long)8)
                {
                    if (this.GraphType.ToString().ToLower() != "stackedbar")
                    {
                        dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews6 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "SalespersonName" };
                            DataTable table3 = dataViews6.ToTable(true, str);
                            DataView dataViews7 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable dataTable3 = dataViews6.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table3.Rows.Count, 1);
                            foreach (DataRow row3 in dataTable3.Rows)
                            {
                                ChartSeries str4 = new ChartSeries(row3["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row3["EstimateStatus"].ToString().Length <= 15)
                                {
                                    str4.Name = row3["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    str4.Name = string.Concat(row3["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                str4.YAxisType = ChartYAxisType.Primary;
                                str4.Type = ChartSeriesType.Bar;
                                str4.Appearance.LabelAppearance.Visible = true;
                                int num9 = 0;
                                foreach (DataRow dataRow3 in table3.Rows)
                                {
                                    DataTable dataTable4 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row3["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow3["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray3 = dataTable4.Select(string.Concat(str));
                                    if ((int)dataRowArray3.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem6 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem6.Label.Visible = false;
                                        str4.AddItem(chartSeriesItem6, new ChartSeriesItem[0]);
                                        num9++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem7 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray3[0]["TotalCount"]),
                                            Name = dataRowArray3[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem7.Label.Visible = false;
                                        str = new string[] { dataRowArray3[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray3[0]["TotalCount"].ToString() };
                                        string str5 = string.Concat(str);
                                        chartSeriesItem7.Label.ActiveRegion.Tooltip = str5;
                                        chartSeriesItem7.ActiveRegion.Tooltip = str5;
                                        str4.AddItem(chartSeriesItem7, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num9].TextBlock.Text = dataRowArray3[0]["SalespersonName"].ToString();
                                        num9++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(str4);
                                radChart.PlotArea.XAxis.AutoScale = false;
                                try
                                {
                                    radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                                }
                                catch
                                {
                                }
                            }
                        }
                        radChart.DataBind();
                    }
                    else
                    {
                        dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews8 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "SalespersonName" };
                            DataTable table4 = dataViews8.ToTable(true, str);
                            DataView dataViews9 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable table5 = dataViews8.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table4.Rows.Count, 1);
                            foreach (DataRow row4 in table5.Rows)
                            {
                                ChartSeries chartSeries5 = new ChartSeries(row4["EstimateStatus"].ToString(), ChartSeriesType.StackedBar);
                                if (row4["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries5.Name = row4["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries5.Name = string.Concat(row4["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries5.YAxisType = ChartYAxisType.Primary;
                                chartSeries5.Type = ChartSeriesType.StackedBar;
                                chartSeries5.Appearance.LabelAppearance.Visible = true;
                                int num10 = 0;
                                foreach (DataRow dataRow4 in table4.Rows)
                                {
                                    DataTable item5 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row4["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow4["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray4 = item5.Select(string.Concat(str));
                                    if ((int)dataRowArray4.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem8 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem8.Label.Visible = false;
                                        chartSeries5.AddItem(chartSeriesItem8, new ChartSeriesItem[0]);
                                        num10++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem9 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray4[0]["TotalCount"]),
                                            Name = dataRowArray4[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem9.Label.Visible = false;
                                        str = new string[] { dataRowArray4[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray4[0]["TotalCount"].ToString() };
                                        string str6 = string.Concat(str);
                                        chartSeriesItem9.Label.ActiveRegion.Tooltip = str6;
                                        chartSeriesItem9.ActiveRegion.Tooltip = str6;
                                        chartSeries5.AddItem(chartSeriesItem9, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num10].TextBlock.Text = dataRowArray4[0]["SalespersonName"].ToString();
                                        num10++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(chartSeries5);
                                radChart.PlotArea.XAxis.AutoScale = false;
                                try
                                {
                                    radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                                }
                                catch
                                {
                                }
                            }
                        }
                        radChart.DataBind();
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette3 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette3);
                    radChart.SeriesPalette = "seriesPalette";
                }
                else if (this.MasterID == (long)10)
                {
                    if (this.GraphType.ToString().ToLower() != "bar")
                    {
                        int num11 = 0;
                        dataSet = dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                            for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
                            {
                                if (dataSet.Tables[0].Rows[k]["EstimateStatus"].ToString().Length <= 8)
                                {
                                    radChart.PlotArea.XAxis[num11].TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[k]["EstimateStatus"].ToString());
                                    radChart.PlotArea.XAxis.Items[num11].ActiveRegion.Tooltip = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[k]["EstimateStatus"].ToString());
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num11].TextBlock.Text = string.Concat(this.objbase.SpecialDecode(dataSet.Tables[0].Rows[k]["EstimateStatus"].ToString()).Substring(0, 5), "...");
                                    radChart.PlotArea.XAxis.Items[num11].ActiveRegion.Tooltip = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[k]["EstimateStatus"].ToString());
                                }
                                num11++;
                            }
                        }
                        ChartSeries chartSeries6 = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), this.GraphType)
                        };
                        chartSeries6.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries6.DataYColumn = "Probability%";
                        try
                        {
                            chartSeries6.DefaultLabelValue = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #Y");
                            chartSeries6.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                        radChart.Series.Add(chartSeries6);
                        radChart.DataSource = dataSet;
                        radChart.DataBind();
                        radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;
                        radChart.Legend.Visible = true;
                        int num12 = 0;
                        foreach (ChartSeriesItem item6 in radChart.Series[0].Items)
                        {
                            int num13 = num12;
                            num12 = num13 + 1;
                            item6.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num13));
                            item6.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                    else
                    {
                        dataSet = dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews10 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable dataTable5 = dataViews10.ToTable(true, str);
                            DataView dataViews11 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "EstimateStatus" };
                            DataTable table6 = dataViews10.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)dataTable5.Rows.Count, 1);
                            foreach (DataRow row5 in table6.Rows)
                            {
                                ChartSeries chartSeries7 = new ChartSeries(row5["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row5["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries7.Name = row5["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries7.Name = string.Concat(row5["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries7.YAxisType = ChartYAxisType.Primary;
                                chartSeries7.Type = ChartSeriesType.Bar;
                                chartSeries7.Appearance.LabelAppearance.Visible = true;
                                int num14 = 0;
                                foreach (DataRow dataRow5 in dataTable5.Rows)
                                {
                                    DataTable dataTable6 = dataSet.Tables[0];
                                    str = new string[] { " EstimateStatus='", row5["EstimateStatus"].ToString(), "' and EstimateStatus='", dataRow5["EstimateStatus"].ToString(), "'" };
                                    DataRow[] dataRowArray5 = dataTable6.Select(string.Concat(str));
                                    if ((int)dataRowArray5.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem10 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem10.Label.Visible = false;
                                        chartSeries7.AddItem(chartSeriesItem10, new ChartSeriesItem[0]);
                                        num14++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem11 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray5[0]["Probability%"]),
                                            Name = dataRowArray5[0]["EstimateStatus"].ToString()
                                        };
                                        chartSeriesItem11.Label.Visible = false;
                                        str = new string[] { dataRowArray5[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray5[0]["Probability%"].ToString() };
                                        string str7 = string.Concat(str);
                                        chartSeriesItem11.Label.ActiveRegion.Tooltip = str7;
                                        chartSeriesItem11.ActiveRegion.Tooltip = str7;
                                        chartSeries7.AddItem(chartSeriesItem11, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num14].TextBlock.Text = dataRowArray5[0]["EstimateStatus"].ToString();
                                        num14++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(chartSeries7);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        try
                        {
                            radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                        }
                        catch
                        {
                        }
                        radChart.DataBind();
                    }
                    if (this.GraphType.ToString().ToLower() != "pie")
                    {
                        colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                        Palette palette4 = new Palette("seriesPalette", colorArray, true);
                        radChart.CustomPalettes.Add(palette4);
                        radChart.SeriesPalette = "seriesPalette";
                    }
                    else
                    {
                        int num15 = 0;
                        foreach (ChartSeriesItem item7 in radChart.Series[0].Items)
                        {
                            int num16 = num15;
                            num15 = num16 + 1;
                            item7.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num16));
                            item7.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                }
                else if (this.MasterID == (long)9)
                {
                    if (this.GraphType.ToString().ToLower() == "stackedbar")
                    {
                        dataSet = dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.QuarterType, this.EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            Hashtable hashtables = new Hashtable();
                            int num17 = 0;
                            foreach (DataRow row6 in dataSet.Tables[0].Rows)
                            {
                                if (hashtables.ContainsKey(row6["Username"].ToString().Trim()))
                                {
                                    continue;
                                }
                                num17++;
                                hashtables.Add(row6["Username"].ToString().Trim(), num17);
                            }
                            radChart.PlotArea.XAxis.AddRange(1, (double)hashtables.Count, 1);
                            for (int l = 1; l <= hashtables.Count; l++)
                            {
                                int num18 = 0;
                                object key = null;
                                foreach (DictionaryEntry hashtable in hashtables)
                                {
                                    if (hashtable.Value.ToString() != l.ToString())
                                    {
                                        continue;
                                    }
                                    key = hashtable.Key;
                                    num18 = l;
                                    break;
                                }
                                if (key.ToString().Length <= 15)
                                {
                                    radChart.PlotArea.XAxis[num18 - 1].TextBlock.Text = key.ToString();
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num18 - 1].TextBlock.Text = string.Concat(key.ToString().Substring(0, 15), "...");
                                }
                                radChart.PlotArea.XAxis.Items[num18 - 1].ActiveRegion.Tooltip = key.ToString();
                                radChart.PlotArea.XAxis.DataLabelsColumn = "Username";
                            }
                            num17 = 0;
                            foreach (DataRow dataRow6 in dataSet.Tables[0].Rows)
                            {
                                ChartSeries chartSeries8 = new ChartSeries();
                                if (dataRow6["ActualValue"].ToString().Length <= 8)
                                {
                                    chartSeries8.Name = "Actual Amount";
                                }
                                else
                                {
                                    chartSeries8.Name = "Actual Amount";
                                }
                                chartSeries8.YAxisType = ChartYAxisType.Primary;
                                chartSeries8.Type = ChartSeriesType.StackedBar;
                                chartSeries8.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" ActualValue='", dataRow6["ActualValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem12 = new ChartSeriesItem(Convert.ToDouble(hashtables[dataRow6["Username"].ToString().Trim()]), Convert.ToDouble(dataRow6["ActualValue"]))
                                {
                                    Name = dataRow6["Username"].ToString()
                                };
                                chartSeriesItem12.Label.Visible = false;
                                str = new string[] { dataRow6["Username"].ToString(), "\r\nActual Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow6["ActualValue"].ToString() };
                                string str8 = string.Concat(str);
                                chartSeriesItem12.Label.ActiveRegion.Tooltip = str8;
                                chartSeriesItem12.ActiveRegion.Tooltip = str8;
                                chartSeries8.AddItem(chartSeriesItem12, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries8);
                                ChartSeries chartSeries9 = new ChartSeries();
                                if (dataRow6["TargetValue"].ToString().Length <= 8)
                                {
                                    chartSeries9.Name = "Target Amount";
                                }
                                else
                                {
                                    chartSeries9.Name = "Target Amount";
                                }
                                chartSeries9.YAxisType = ChartYAxisType.Primary;
                                chartSeries9.Type = ChartSeriesType.StackedBar;
                                chartSeries9.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" TargetValue='", dataRow6["TargetValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem13 = new ChartSeriesItem(Convert.ToDouble(hashtables[dataRow6["Username"].ToString().Trim()]), Convert.ToDouble(dataRow6["TargetValue"]))
                                {
                                    Name = dataRow6["Username"].ToString()
                                };
                                chartSeriesItem13.Label.Visible = false;
                                str = new string[] { dataRow6["Username"].ToString(), "\r\nTarget Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow6["TargetValue"].ToString() };
                                str8 = string.Concat(str);
                                chartSeriesItem13.Label.ActiveRegion.Tooltip = str8;
                                chartSeriesItem13.ActiveRegion.Tooltip = str8;
                                chartSeries9.AddItem(chartSeriesItem13, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries9);
                            }
                            try
                            {
                                radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                            }
                            catch
                            {
                            }
                            radChart.DataBind();
                        }
                    }
                    else if (this.GraphType.ToString().ToLower() != "bar")
                    {
                        int num19 = 0;
                        dataSet = (this.ModuleName.ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_SelectPie_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.QuarterType, this.EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus)) : dashboardestimate.Dashboard_Target_Actual_Date_SelectPie_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", this.QuarterType, this.EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus)));
                        if (dataSet.Tables.Count > 0)
                        {
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                                for (int m = 0; m < dataSet.Tables[0].Rows.Count; m++)
                                {
                                    if (dataSet.Tables[0].Rows[m]["ValueType"].ToString().Length <= 15)
                                    {
                                        radChart.PlotArea.XAxis[num19].TextBlock.Text = dataSet.Tables[0].Rows[m]["ValueType"].ToString();
                                        radChart.PlotArea.XAxis.Items[num19].ActiveRegion.Tooltip = dataSet.Tables[0].Rows[m]["ValueType"].ToString();
                                        radChart.Legend.TextBlock.Text = dataSet.Tables[0].Rows[m]["ValueType"].ToString();
                                    }
                                    else
                                    {
                                        radChart.PlotArea.XAxis[num19].TextBlock.Text = string.Concat(dataSet.Tables[0].Rows[m]["ValueType"].ToString().Substring(0, 15), "...");
                                        radChart.PlotArea.XAxis.Items[num19].ActiveRegion.Tooltip = dataSet.Tables[0].Rows[m]["ValueType"].ToString();
                                        radChart.Legend.TextBlock.Text = dataSet.Tables[0].Rows[m]["ValueType"].ToString();
                                    }
                                    num19++;
                                    radChart.ChartTitle.TextBlock.Text = this.objbase.SpecialDecode(dataSet.Tables[0].Rows[m]["Username"].ToString());
                                }
                            }
                            radChart.ChartTitle.Visible = true;
                            radChart.ChartTitle.TextBlock.Appearance.TextProperties.Color = Color.Black;
                            radChart.ChartTitle.TextBlock.Appearance.TextProperties.Font = new Font("Verdana", 10f, FontStyle.Bold);
                        }
                        ChartSeries chartSeries10 = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), this.GraphType)
                        };
                        chartSeries10.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries10.DataYColumn = "Amount";
                        try
                        {
                            chartSeries10.DefaultLabelValue = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #Y");
                            chartSeries10.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                        radChart.Series.Add(chartSeries10);
                        radChart.DataSource = dataSet;
                        radChart.DataBind();
                        radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = true;
                        radChart.Legend.Visible = true;
                        int num20 = 0;
                        foreach (ChartSeriesItem item8 in radChart.Series[0].Items)
                        {
                            int num21 = num20;
                            num20 = num21 + 1;
                            item8.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num21));
                            item8.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                    else
                    {
                        dataSet = (this.ModuleName.ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.salesperson, this.QuarterType, this.EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus)) : dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", this.QuarterType, this.EstimateType, this.ModuleName, this.status, Convert.ToBoolean(this.ShowArchivedStatus)));
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            Hashtable hashtables1 = new Hashtable();
                            int num22 = 0;
                            foreach (DataRow row7 in dataSet.Tables[0].Rows)
                            {
                                if (hashtables1.ContainsKey(row7["Username"].ToString().Trim()))
                                {
                                    continue;
                                }
                                num22++;
                                hashtables1.Add(row7["Username"].ToString().Trim(), num22);
                            }
                            radChart.PlotArea.XAxis.AddRange(1, (double)hashtables1.Count, 1);
                            for (int n = 1; n <= hashtables1.Count; n++)
                            {
                                int num23 = 0;
                                object key1 = null;
                                foreach (DictionaryEntry dictionaryEntry in hashtables1)
                                {
                                    if (dictionaryEntry.Value.ToString() != n.ToString())
                                    {
                                        continue;
                                    }
                                    key1 = dictionaryEntry.Key;
                                    num23 = n;
                                    break;
                                }
                                if (key1.ToString().Length <= 15)
                                {
                                    radChart.PlotArea.XAxis[num23 - 1].TextBlock.Text = key1.ToString();
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num23 - 1].TextBlock.Text = string.Concat(key1.ToString().Substring(0, 15), "...");
                                }
                                radChart.PlotArea.XAxis.Items[num23 - 1].ActiveRegion.Tooltip = key1.ToString();
                                radChart.PlotArea.XAxis.DataLabelsColumn = "Username";
                            }
                            num22 = 0;
                            foreach (DataRow dataRow7 in dataSet.Tables[0].Rows)
                            {
                                ChartSeries chartSeries11 = new ChartSeries();
                                if (dataRow7["TargetValue"].ToString().Length <= 8)
                                {
                                    chartSeries11.Name = "Target Amount";
                                }
                                else
                                {
                                    chartSeries11.Name = "Target Amount";
                                }
                                chartSeries11.YAxisType = ChartYAxisType.Primary;
                                chartSeries11.Type = ChartSeriesType.Bar;
                                chartSeries11.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" TargetValue='", dataRow7["TargetValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem14 = new ChartSeriesItem(Convert.ToDouble(hashtables1[dataRow7["Username"].ToString().Trim()]), Convert.ToDouble(dataRow7["TargetValue"]))
                                {
                                    Name = dataRow7["Username"].ToString()
                                };
                                chartSeriesItem14.Label.Visible = false;
                                str = new string[] { dataRow7["Username"].ToString(), "\r\nTarget Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow7["TargetValue"].ToString() };
                                string str9 = string.Concat(str);
                                chartSeriesItem14.Label.ActiveRegion.Tooltip = str9;
                                chartSeriesItem14.ActiveRegion.Tooltip = str9;
                                chartSeries11.AddItem(chartSeriesItem14, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries11);
                                ChartSeries chartSeries12 = new ChartSeries();
                                if (dataRow7["ActualValue"].ToString().Length <= 8)
                                {
                                    chartSeries12.Name = "Actual Amount";
                                }
                                else
                                {
                                    chartSeries12.Name = "Actual Amount";
                                }
                                chartSeries12.YAxisType = ChartYAxisType.Primary;
                                chartSeries12.Type = ChartSeriesType.Bar;
                                chartSeries12.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" ActualValue='", dataRow7["ActualValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem15 = new ChartSeriesItem(Convert.ToDouble(hashtables1[dataRow7["Username"].ToString().Trim()]), Convert.ToDouble(dataRow7["ActualValue"]))
                                {
                                    Name = dataRow7["Username"].ToString()
                                };
                                chartSeriesItem15.Label.Visible = false;
                                str = new string[] { dataRow7["Username"].ToString(), "\r\nActual Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow7["ActualValue"].ToString() };
                                str9 = string.Concat(str);
                                chartSeriesItem15.Label.ActiveRegion.Tooltip = str9;
                                chartSeriesItem15.ActiveRegion.Tooltip = str9;
                                chartSeries12.AddItem(chartSeriesItem15, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries12);
                            }
                            try
                            {
                                radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                            }
                            catch
                            {
                            }
                            radChart.DataBind();
                        }
                    }
                    if (this.GraphType.ToString().ToLower() != "pie")
                    {
                        colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                        Palette palette5 = new Palette("seriesPalette", colorArray, true);
                        radChart.CustomPalettes.Add(palette5);
                        radChart.SeriesPalette = "seriesPalette";
                    }
                    else
                    {
                        int num24 = 0;
                        foreach (ChartSeriesItem item9 in radChart.Series[0].Items)
                        {
                            int num25 = num24;
                            num24 = num25 + 1;
                            item9.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num25));
                            item9.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                    }
                }
                else if (this.MasterID == (long)12)
                {
                    if (this.GraphType == "Bar")
                    {
                        if (this.Date == "1")
                        {
                            this.Date = "Today";
                        }
                        if (this.Date == "2")
                        {
                            this.Date = "ThisWeek";
                        }
                        if (this.Date == "3")
                        {
                            this.Date = "ThisMonth";
                        }
                        if (this.Date == "---Select---")
                        {
                            this.Date = "Today";
                        }
                        dataSet = dashboardestimate.Dashboard_Select_CallVSCount(Convert.ToInt64(this.Session["CompanyId"]), this.Date, this.SalePID);
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews12 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "SalesPersonName" };
                            DataTable table7 = dataViews12.ToTable(true, str);
                            DataView dataViews13 = new DataView(dataSet.Tables[0]);
                            str = new string[] { "CallStatus" };
                            DataTable dataTable7 = dataViews12.ToTable(true, str);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table7.Rows.Count, 1);
                            foreach (DataRow row8 in dataTable7.Rows)
                            {
                                ChartSeries str10 = new ChartSeries(row8["CallStatus"].ToString(), ChartSeriesType.Bar);
                                if (row8["CallStatus"].ToString().Length <= 15)
                                {
                                    str10.Name = row8["CallStatus"].ToString();
                                }
                                else
                                {
                                    str10.Name = string.Concat(row8["CallStatus"].ToString().Substring(0, 15), "...");
                                }
                                str10.YAxisType = ChartYAxisType.Primary;
                                str10.Type = ChartSeriesType.Bar;
                                str10.Appearance.LabelAppearance.Visible = true;
                                int num26 = 0;
                                foreach (DataRow dataRow8 in table7.Rows)
                                {
                                    DataTable dataTable8 = dataSet.Tables[0];
                                    str = new string[] { " CallStatus='", row8["CallStatus"].ToString(), "' and SalesPersonName='", dataRow8["SalesPersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray6 = dataTable8.Select(string.Concat(str));
                                    if ((int)dataRowArray6.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem16 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem16.Label.Visible = false;
                                        str10.AddItem(chartSeriesItem16, new ChartSeriesItem[0]);
                                        num26++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem17 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray6[0]["Count"]),
                                            Name = dataRowArray6[0]["SalesPersonName"].ToString()
                                        };
                                        chartSeriesItem17.Label.Visible = false;
                                        str = new string[] { dataRowArray6[0]["SalesPersonName"].ToString(), "\r\nCall: (", dataRowArray6[0]["Count"].ToString(), ")\r\nStatus: ", dataRowArray6[0]["CallStatus"].ToString() };
                                        string str11 = string.Concat(str);
                                        chartSeriesItem17.Label.ActiveRegion.Tooltip = str11;
                                        chartSeriesItem17.ActiveRegion.Tooltip = str11;
                                        str10.AddItem(chartSeriesItem17, new ChartSeriesItem[0]);
                                        radChart.PlotArea.XAxis[num26].TextBlock.Text = dataRowArray6[0]["SalesPersonName"].ToString();
                                        num26++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalesPersonName";
                                radChart.Series.Add(str10);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette6 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette6);
                    radChart.SeriesPalette = "seriesPalette";
                }
                radChart.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                radChart.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 0f;
                radChart.PlotArea.XAxis.Appearance.TextAppearance.AutoTextWrap = AutoTextWrap.False;
                radChart.PlotArea.XAxis.Appearance.TextAppearance.Dimensions.Margins = new ChartMargins(1, 1, 1, 1);
                this.plsEstimatecountbyStatus.Controls.Add(label);
                this.plsEstimatecountbyStatus.Controls.Add(linkButton);
                this.plsEstimatecountbyStatus.Controls.Add(radChart);
            }
            catch
            {
            }
        }

        public void GenerateCustomerActivityGridBoundColumns(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                if (datafield.ToString().ToLower() == "customername")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                }
                if (datafield.ToString().ToLower() == "time")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(6);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(6);
                }
                if (datafield.ToString().ToLower() == "maincontact")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                }
                if (datafield.ToString().ToLower() == "maincontactphone")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                }
                if (datafield.ToString().ToLower() == "lastactivitytype")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                }
                Grid.MasterTableView.Columns.Add(gridBoundColumn);
            }
            catch
            {
            }
        }

        public void GenerateGridBoundColumns(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                if (headertext == "Type")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(3);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(3);
                }
                else if (headertext.ToLower() == "subject")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                }
                else if (headertext.ToLower() == "contact name")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                }
                else if (headertext.ToLower() == "customer name")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                }
                else if (headertext.ToLower() == "time" || headertext.ToLower() == "action")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                }
                else if (datafield.ToString().ToLower() != "duedate")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                }
                else
                {
                    this.DateFormat = this.Session["DateFormat"].ToString();
                    gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                }
                gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                Grid.MasterTableView.Columns.Add(gridBoundColumn);
            }
            catch
            {
            }
        }

        public void GenerateGridBoundColumnsForCallVS(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                if (headertext.ToLower() == "assigned to")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(35);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(35);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                }
                if (headertext.ToLower() == "scheduled")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    gridBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                else if (headertext.ToLower() == "completed")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    gridBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                Grid.MasterTableView.Columns.Add(gridBoundColumn);
            }
            catch
            {
            }
        }

        public void GenerateLatestNotesGridBoundColumns(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                if (datafield.ToString().ToLower() == "createdon" || datafield.ToString().ToLower() == "lastviewdon")
                {
                    this.DateFormat = this.Session["DateFormat"].ToString();
                    gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                }
                else if (datafield.ToString().ToLower() == "addedfromcall" || datafield.ToString().ToLower() == "subject")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (datafield.ToString().ToLower() == "duedate")
                {
                    this.DateFormat = this.Session["DateFormat"].ToString();
                    gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (datafield.ToString().ToLower() == "specificto")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                Grid.MasterTableView.Columns.Add(gridBoundColumn);
            }
            catch
            {
            }
        }

        public void GenerateTargetVSActualGridBoundColumns(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(7);
                if (datafield.ToString().ToLower() == "username")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(15);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    gridBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                }
                if (datafield.ToString().ToLower() == "targetvalue")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    gridBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                if (datafield.ToString().ToLower() == "actualvalue")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    gridBoundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                }
                Grid.MasterTableView.Columns.Add(gridBoundColumn);
            }
            catch
            {
            }
        }

        private void OnRowDataBound_GridViewCallVS(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                QueryString queryString = new QueryString()
            {
                { "clientid", dataItem["clientid"].ToString() },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", dataItem["CustomerType"].ToString() }
            };
                string empty = string.Empty;
                empty = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                empty = string.Concat(empty, queryString1.ToString());
                GridDataItem item = (GridDataItem)e.Item;
            }
        }

        private void OnRowDataBound_GridViewTaskCall(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    GridDataItem item = (GridDataItem)e.Item;
                    if (item["ActivityType"].Text != "Task")
                    {
                        item["ActivityType"].Text = "<img style='color:#10357F;margin-left:2px;' src='images/Call.png' alt='Call' title='Call'/>";
                    }
                    else
                    {
                        item["ActivityType"].Text = "<img style='color:#10357F; margin-left:2px;' src='images/Tasks.png' alt='Task' title='Task'/>";
                    }
                }
            }
            catch
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.DateFormat = this.Session["Dateformat"].ToString();
                if (base.Request.QueryString["CopyMasterID"] != null)
                {
                    this.CopyMasterID = (long)Convert.ToInt32(base.Request.QueryString["CopyMasterID"]);
                }
                if (base.Request.QueryString["MasterID"] != null)
                {
                    this.MasterID = (long)Convert.ToInt32(base.Request.QueryString["MasterID"]);
                }
                if (base.Request.QueryString["GraphType"] != null)
                {
                    this.GraphType = base.Request.QueryString["GraphType"].ToString();
                }
                if (base.Request.QueryString["status"] != null)
                {
                    this.status = base.Request.QueryString["status"].ToString();
                }
                if (base.Request.QueryString["ShowArchivedStatus"] != null)
                {
                    this.ShowArchivedStatus = base.Request.QueryString["ShowArchivedStatus"].ToString();
                }
                if (base.Request.QueryString["salesperson"] != null)
                {
                    this.salesperson = base.Request.QueryString["salesperson"].ToString();
                }
                if (base.Request.QueryString["ModuleName"] != null)
                {
                    this.ModuleName = base.Request.QueryString["ModuleName"].ToString();
                }
                if (base.Request.QueryString["WhereCondition"] != null)
                {
                    this.WhereCondition = base.Request.QueryString["WhereCondition"].ToString();
                }
                if (base.Request.QueryString["NoOfRecords"] != null)
                {
                    this.NoOfRecords = Convert.ToInt32(base.Request.QueryString["NoOfRecords"].ToString());
                }
                if (base.Request.QueryString["CustomizeColumns"] != null)
                {
                    this.CustomizeColumns = base.Request.QueryString["CustomizeColumns"].ToString();
                }
                if (base.Request.QueryString["CustomerID"] != null)
                {
                    this.CustomerID = Convert.ToInt32(base.Request.QueryString["CustomerID"].ToString());
                }
                if (base.Request.QueryString["SalesPID"] != null)
                {
                    this.SalePID = base.Request.QueryString["SalesPID"].ToString();
                }
                if (base.Request.QueryString["Date"] != null)
                {
                    this.Date = base.Request.QueryString["Date"].ToString();
                }
                if (base.Request.QueryString["DisplayType"] != null)
                {
                    this.DisplayType = base.Request.QueryString["DisplayType"].ToString();
                }
                if (base.Request.QueryString["CompanyType"] != null)
                {
                    this.CompanyType = base.Request.QueryString["CompanyType"].ToString();
                }
                if (base.Request.QueryString["EstimateType"] != null)
                {
                    this.EstimateType = base.Request.QueryString["EstimateType"].ToString();
                }
                if (base.Request.QueryString["QuarterType"] != null)
                {
                    this.QuarterType = base.Request.QueryString["QuarterType"].ToString();
                }
                if (base.Request.QueryString["WidgetsTitle"] != null)
                {
                    this.WidgetsTitle = base.Request.QueryString["WidgetsTitle"].ToString();
                }
                if (base.Request.QueryString["ChartType"] != null)
                {
                    this.ChartType = base.Request.QueryString["ChartType"].ToString();
                }
                if (base.Request.QueryString["ForecastType"] != null)
                {
                    this.ForecastType = base.Request.QueryString["ForecastType"].ToString();
                }
                if (this.MasterID == (long)5 || this.MasterID == (long)4 || this.MasterID == (long)7 || this.MasterID == (long)11)
                {
                    this.BindGrid();
                }
                else if (!(this.ForecastType == "Grid") || this.MasterID != (long)9)
                {
                    this.BintEstimateCountByStatusBAR();
                }
                else
                {
                    this.BindGrid();
                }
            }
            catch
            {
            }
        }

        private void radChart_EstimateJobInvoiceItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {
            if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
            {
                if (((DataRowView)e.DataItem)["SalespersonName"].ToString().Length <= 10)
                {
                    e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    return;
                }
                e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString()).Substring(0, 10), "...");
                e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                return;
            }
            if (((DataRowView)e.DataItem)["SalespersonName"].ToString().Length <= 10)
            {
                try
                {
                    e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString()).Substring(0, 10), "...");
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                }
                catch
                {
                }
            }
        }

        private void radChart_ItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {
            try
            {
                if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
                {
                    if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 20)
                    {
                        e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                    else
                    {
                        e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 20), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                }
                else if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 20)
                {
                    try
                    {
                        e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 20), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objbase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void radChartJobInvoice_ItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {
            if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
            {
                if (((DataRowView)e.DataItem)["StatusName"].ToString().Length <= 10)
                {
                    e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    return;
                }
                e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString()).Substring(0, 10), "...");
                e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                return;
            }
            if (((DataRowView)e.DataItem)["StatusName"].ToString().Length <= 20)
            {
                try
                {
                    e.SeriesItem.Name = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    e.SeriesItem.Name = string.Concat(this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString()).Substring(0, 20), "...");
                    e.SeriesItem.ActiveRegion.Tooltip = this.objbase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                }
                catch
                {
                }
            }
        }
    }
}