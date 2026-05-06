using java.sql;
using Microsoft.Ajax.Utilities;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.dashboard;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Charting;
using Telerik.Charting.Styles;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;
using Telerik.Web.UI.Dock;


namespace ePrint
{
    public partial class dashboard : BaseClass, IRequiresSessionState
    {
        private BasePage objpage = new BasePage();

        private commonClass objJava = new commonClass();

        private Global gloobj = new Global();

        private createViewClass objCreateView = new createViewClass();

        public string ImgPath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public int ClientID = 19930;

        public string tabcolor = string.Empty;

        public static int compid;
        public static int usrid;
        public static int CopyMasterIDdaily;
        public static int CopyMasterIDmonthly;
        public static bool monthlyTarget = false;
        public static bool monthlyLastyear = false;
        public static bool dailyTarget = false;
        public static bool dailyLastyear = false;
        public static string format;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public languageClass objLangClass = new languageClass();

        public string DateFormat = string.Empty;

        private commonClass commclass = new commonClass();

        public string SelectedDate = "01/01/1990";

        public string TodayDate = string.Empty;

        public string Connectionstr = string.Empty;

        public string SectionName = "";

        public string ModuleNames = "";

        public int AppID;

        private BaseClass objBase = new BaseClass();

        public int j;

        public commonClass objCommon = new commonClass();

        private SettingsBasePage objSet = new SettingsBasePage();

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

        public static Size ScreenResolution
        {
            get
            {
                return (Size)HttpContext.Current.Session["ScreenResolution"];
            }
            set
            {
                HttpContext.Current.Session["ScreenResolution"] = value;
            }
        }

        public dashboard()
        {
        }

        public string BarColors(int ai)
        {
            string str = "";
            try
            {
                if (ai > 10)
                {
                    ai = ai - 10;
                    if (ai > 10)
                    {
                        ai = ai - 10;
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
            string caption = "";
            string languageConversion = "";
            string str = Columns.Replace("Customer Name", "CustomerName").Replace("Main Contact", "MainContact").Replace("Phone", "MainContactPhone").Replace("Last Activity Type", "LastActivityType").Replace("Time", "time");
            DataSet dataSet = dashboardestimate.Dashboard_CustomerActivity_Select(Convert.ToInt64(this.CompanyID), Convert.ToInt32(this.UserID), companyType, noOfRecords, str);
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
                        row["CustomerName"] = this.objBase.SpecialDecode(row["CustomerName"].ToString());
                        row["MainContact"] = this.objBase.SpecialDecode(row["MainContact"].ToString());
                    }
                    catch
                    {
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BindGrid(RadGrid Grid, string dateType, int noOfRecords, string RecordType, string SalesPerson)
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
            DataSet dataSet = dashboardestimate.Dashboard_Select_TaskCall((long)this.CompanyID, dateType, noOfRecords, RecordType, SalesPerson);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    if (languageConversion.ToLower() == "activitytype" || languageConversion.ToLower() == "companyname" || languageConversion.ToLower() == "taskstatus" || languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "duedate" || languageConversion.ToLower() == "contactname" || languageConversion.ToLower() == "assigntousername")
                    {
                        try
                        {
                            if (languageConversion.ToLower() == "activitytype")
                            {
                                languageConversion = "";
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
                            this.GenerateGridBoundColumns123(caption, languageConversion, Grid);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["AssignToUserName"] = this.objBase.SpecialDecode(row["AssignToUserName"].ToString());
                            row["CompanyName"] = this.objBase.SpecialDecode(row["CompanyName"].ToString());
                            row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                            string str = row["Duedate"].ToString();
                            string[] strArrays = str.Split(new char[] { ' ' });
                            string str1 = string.Concat(strArrays[0].ToString(), " ", row["TaskTime"].ToString());
                            row["Duedate"] = str1;
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
            DataSet dataSet = dashboardestimate.Dashboard_Select_TaskCall_ForAdmin((long)this.CompanyID, this.UserID, dateType, noOfRecords, RecordType, CustomerID, DisplayRecordSalesOf);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    if (languageConversion.ToLower() == "activitytype" || languageConversion.ToLower() == "taskstatus" || languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "duedate" || languageConversion.ToLower() == "contactname" || languageConversion.ToLower() == "assigntousername")
                    {
                        try
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
                        catch (Exception)
                        {
                        }
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["AssignToUserName"] = this.objBase.SpecialDecode(row["AssignToUserName"].ToString());
                            string str = row["Duedate"].ToString();
                            string[] strArrays = str.Split(new char[] { ' ' });
                            string str1 = string.Concat(strArrays[0].ToString(), " ", row["TaskTime"].ToString());
                            row["Duedate"] = str1;
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
            DataSet dataSet = dashboardestimate.Dashboard_Select_CallVS((long)this.CompanyID, dateType, SalesPerson);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    caption = dataSet.Tables[0].Columns[i].Caption;
                    languageConversion = dataSet.Tables[0].Columns[i].Caption;
                    try
                    {
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
                    }
                    catch (Exception)
                    {
                    }
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        try
                        {
                            row["SalesPersonName"] = this.objBase.SpecialDecode(row["SalesPersonName"].ToString());
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
            string caption = "";
            string languageConversion = "";
            string str = "";
            string str1 = "";
            DataSet fromUsertypeShowAll = dashboardestimate.GetFromUsertype_ShowAll(this.CompanyID, Convert.ToInt32(this.Session["UserID"]));
            foreach (DataRow row in fromUsertypeShowAll.Tables[0].Rows)
            {
                if (row["CompanyType"].ToString() != "")
                {
                    str = row["CompanyType"].ToString().Substring(0, row["CompanyType"].ToString().Length - 1);
                }
                str1 = row["ShowRecords"].ToString();
            }
            string str2 = Columns.Replace("Created By", "CreatedBy").Replace("Created On", "CreatedOn").Replace("Specific To", "SpecificTo").Replace("Note Title", "title").Replace("Note Content", "Subject").Replace("Specific to Contact", "Specificto").Replace("Customer Name", "CustomerName");
            DataSet dataSet = dashboardestimate.Dashboard_LatestNotes_Select(clientID, (long)this.CompanyID, str, str1, (long)Convert.ToInt32(this.Session["UserID"]), noOfRecords, str2);
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
                        dataRow["CreatedBy"] = this.objBase.SpecialDecode(dataRow["CreatedBy"].ToString());
                        dataRow["SpecificTo"] = this.objBase.SpecialDecode(dataRow["SpecificTo"].ToString());
                        dataRow["CustomerName"] = this.objBase.SpecialDecode(dataRow["CustomerName"].ToString());
                        dataRow["Subject"] = this.objBase.SpecialDecode(dataRow["Subject"].ToString());
                        dataRow["title"] = this.objBase.SpecialDecode(dataRow["title"].ToString());
                    }
                    catch
                    {
                    }
                }
            }
            Grid.DataSource = dataSet;
            Grid.DataBind();
        }

        public void BindMiniWidgets()
        {
            DataTable dataTable = dashboardestimate.PC_Dashboard_Select_MiniWidgets((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        if (row["WidgetType"].ToString() == "Quotesnumberof" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty = string.Empty;
                            string str = string.Empty;
                            string empty1 = string.Empty;
                            string str1 = string.Empty;
                            DataSet dataSet = dashboardestimate.PC_Dashboard_Select_DataForQuoteNumberCount(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                            {
                                empty = dataRow["Total Quotes"].ToString();
                                str = dataRow["Estimate Value"].ToString();
                            }
                            empty1 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (empty1.ToString().Length > 65)
                            {
                                empty1 = string.Concat(empty1.ToString().Substring(0, 65), "...");
                            }
                            if (empty == "")
                            {
                                empty = "0";
                            }
                            if (str == "")
                            {
                                str = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", empty1, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), ";float:left'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(empty));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "; float:right; margin-right:7px;'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(str), 0, "", false, false, true))));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "Quoteconversionrateestimatestojobs" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty2 = string.Empty;
                            string str2 = string.Empty;
                            string empty3 = string.Empty;
                            DataSet dataSet1 = dashboardestimate.PC_Dashboard_Select_Quoteconversionrate(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow row1 in dataSet1.Tables[0].Rows)
                            {
                                empty2 = row1["ConvertCount"].ToString();
                            }
                            str2 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str2.ToString().Length > 65)
                            {
                                str2 = string.Concat(str2.ToString().Substring(0, 65), "...");
                            }
                            if (empty2 == "")
                            {
                                empty2 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str2, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(empty2));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "Salesnumberofjobs" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string str3 = string.Empty;
                            string empty4 = string.Empty;
                            string str4 = string.Empty;
                            DataSet dataSet2 = dashboardestimate.PC_Dashboard_Select_Salesnumberofjobs(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow1 in dataSet2.Tables[0].Rows)
                            {
                                str3 = dataRow1["Total Live jobs count"].ToString();
                            }
                            empty4 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (empty4.ToString().Length > 65)
                            {
                                empty4 = string.Concat(empty4.ToString().Substring(0, 65), "...");
                            }
                            if (str3 == "")
                            {
                                str3 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", empty4, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(str3));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "Salesvaluesubtotalvalueofjobs" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            string empty6 = string.Empty;
                            string str6 = string.Empty;
                            DataSet dataSet3 = dashboardestimate.PC_Dashboard_Select_Salessubtotalvalueofjobs(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow row2 in dataSet3.Tables[0].Rows)
                            {
                                empty5 = row2["TotalSubtotalOfJobs"].ToString();
                                str5 = row2["Total Live jobs count"].ToString();
                            }
                            empty6 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (empty6.ToString().Length > 65)
                            {
                                empty6 = string.Concat(empty6.ToString().Substring(0, 65), "...");
                            }
                            if (empty5 == "")
                            {
                                empty5 = "0";
                            }
                            if (str5 == "")
                            {
                                str5 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", empty6, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "; float:left;'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(str5));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "; float:right; margin-right:7px;'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(empty5), 0, "", false, false, true))));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "SalesGP$valueofjobsGP$" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty7 = string.Empty;
                            string str7 = string.Empty;
                            string empty8 = string.Empty;
                            DataSet dataSet4 = dashboardestimate.PC_Dashboard_Select_SalesvalueofjobsGP(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow2 in dataSet4.Tables[0].Rows)
                            {
                                empty7 = dataRow2["jobsValueIncGPS"].ToString();
                            }
                            str7 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str7.ToString().Length > 65)
                            {
                                str7 = string.Concat(str7.ToString().Substring(0, 65), "...");
                            }
                            if (empty7 == "")
                            {
                                empty7 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str7, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(empty7), 0, "", false, false, true))));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "SalesGPPercentage" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty7_1 = string.Empty;
                            string str7_1 = string.Empty;
                            string empty8_1 = string.Empty;
                            DataSet dataSet4_1 = dashboardestimate.PC_Dashboard_Select_SalesvalueofjobsGP_Percentage(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow2_1 in dataSet4_1.Tables[0].Rows)
                            {
                                empty7_1 = dataRow2_1["jobsValueIncGPS"].ToString();
                            }
                            str7_1 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str7_1.ToString().Length > 65)
                            {
                                str7_1 = string.Concat(str7_1.ToString().Substring(0, 65), "...");
                            }
                            if (empty7_1 == "")
                            {
                                empty7_1 = "0";
                            }
                            decimal d = decimal.Parse(empty7_1);
                            string s = d.ToString("0.00");
                            string finalString = s + "%";
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str7_1, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(finalString));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "AppointmentsTaskscompletedineprint" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string str8 = string.Empty;
                            string empty9 = string.Empty;
                            string str9 = string.Empty;
                            DataSet dataSet5 = dashboardestimate.PC_Dashboard_Select_AppointmentsTaskscompletedineprint(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow row3 in dataSet5.Tables[0].Rows)
                            {
                                str8 = row3["Task Completed"].ToString();
                            }
                            empty9 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (empty9.ToString().Length > 65)
                            {
                                empty9 = string.Concat(empty9.ToString().Substring(0, 65), "...");
                            }
                            if (str8 == "")
                            {
                                str8 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", empty9, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(str8));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "callscompletedineprint" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty10 = string.Empty;
                            string str10 = string.Empty;
                            string empty11 = string.Empty;
                            DataSet dataSet6 = dashboardestimate.PC_Dashboard_Select_Callscompletedineprint(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow3 in dataSet6.Tables[0].Rows)
                            {
                                empty10 = dataRow3["Calls Completed"].ToString();
                            }
                            str10 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str10.ToString().Length > 65)
                            {
                                str10 = string.Concat(str10.ToString().Substring(0, 65), "...");
                            }
                            if (empty10 == "")
                            {
                                empty10 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str10, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(empty10));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "Newcustomerscreatedineprint" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string str11 = string.Empty;
                            string empty12 = string.Empty;
                            string str12 = string.Empty;
                            DataSet dataSet7 = dashboardestimate.PC_Dashboard_Select_Newcustomerscreatedineprint(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow row4 in dataSet7.Tables[0].Rows)
                            {
                                str11 = row4["Total Clients created"].ToString();
                            }
                            empty12 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (empty12.ToString().Length > 25)
                            {
                                empty12 = string.Concat(empty12.ToString().Substring(0, 25), "...");
                            }
                            if (str11 == "")
                            {
                                str11 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", empty12, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(str11));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }
                        if (row["WidgetType"].ToString() == "Invoicetotal$valueofinvoices" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty13 = string.Empty;
                            string str13 = string.Empty;
                            string empty14 = string.Empty;
                            DataSet dataSet8 = dashboardestimate.PC_Dashboard_Select_Valueofinvoicessubtotalfigure(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow4 in dataSet8.Tables[0].Rows)
                            {
                                empty13 = dataRow4["InvoiceTotalSubTotal"].ToString();
                            }
                            str13 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str13.ToString().Length > 25)
                            {
                                str13 = string.Concat(str13.ToString().Substring(0, 25), "...");
                            }
                            if (empty13 == "")
                            {
                                empty13 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str13, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(empty13), 0, "", false, false, true))));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }

                        if (row["WidgetType"].ToString() == "SalesGP$valueofinvoicesGP$" && row["IsDisplayWidget"].ToString().ToLower() == "true")
                        {
                            string empty7 = string.Empty;
                            string str7 = string.Empty;
                            string empty8 = string.Empty;
                            DataSet dataSet4 = dashboardestimate.PC_Dashboard_Select_SalesvalueofinvoicesGP(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString());
                            foreach (DataRow dataRow2 in dataSet4.Tables[0].Rows)
                            {
                                empty7 = dataRow2["invoicesValueIncGPS"].ToString();
                            }
                            str7 = row["Title"].ToString();
                            row["Title"].ToString();
                            if (str7.ToString().Length > 65)
                            {
                                str7 = string.Concat(str7.ToString().Substring(0, 65), "...");
                            }
                            if (empty7 == "")
                            {
                                empty7 = "0";
                            }
                            this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str7, "</div>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "'>")));
                            this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(empty7), 0, "", false, false, true))));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                            this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        }

                        if (!(row["WidgetType"].ToString() == "Saleslivejobsteam") || !(row["IsDisplayWidget"].ToString().ToLower() == "true"))
                        {
                            continue;
                        }
                        string str14 = string.Empty;
                        string empty15 = string.Empty;
                        string str15 = string.Empty;
                        string empty16 = string.Empty;
                        string hostName = ConfigurationManager.AppSettings["HostName"].ToString();
                        DataSet dataSet9 = dashboardestimate.PC_Dashboard_Select_SaleslivejobsteamWithValue(row["UserID"].ToString(), row["DateType"].ToString(), Convert.ToBoolean(row["IncludeArchiverecords"]), Convert.ToInt64(row["CompanyID"]), row["IsCalendarYear"].ToString(), row["FromDate"].ToString(), row["ToDate"].ToString(), hostName);
                        foreach (DataRow row5 in dataSet9.Tables[0].Rows)
                        {
                            str14 = row5["Total Live jobs count"].ToString();
                            empty15 = row5["TotalJobValue"].ToString();
                        }
                        str15 = row["Title"].ToString();
                        row["Title"].ToString();
                        if (str15.ToString().Length > 25)
                        {
                            str15 = string.Concat(str15.ToString().Substring(0, 25), "...");
                        }
                        if (str14 == "")
                        {
                            str14 = "0";
                        }
                        if (empty15 == "")
                        {
                            empty15 = "0";
                        }
                        this.plhminidashboard.Controls.Add(new LiteralControl("<div style='float:left; margin-left: 10px; margin-top: 10px;'>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("<table cellspacing = '0' cellpadding = '0' height='60px' width = '250px'>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "; width:6px;' >")));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("<td valign='top' style='border-top: 1px solid #E1E1E4; border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4;'>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div style='margin-left:6px; margin-top:4px;' >", str15, "</div>")));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("<tr>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<td style='background-color:", row["Color"].ToString(), "'>")));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("<td style='border-right: 1px solid #E1E1E4; border-bottom: 1px solid #E1E1E4; background-color: #F5F5F5;'>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), ";float:left'>")));
                        this.plhminidashboard.Controls.Add(new LiteralControl(str14));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat("<div class='miniwidgetsvalue' style='color: ", row["Color"].ToString(), "; float:right; margin-right:7px;'>")));
                        this.plhminidashboard.Controls.Add(new LiteralControl(string.Concat(this.objJava.GetCurrencyinRequiredFormate("", true), this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(empty15), 0, "", false, false, true))));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</td>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</tr>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</table>"));
                        this.plhminidashboard.Controls.Add(new LiteralControl("</div>"));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public void BindScheduler()
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_Scheduler(this.ClientID, this.CompanyID, this.UserID);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadScheduler1.DataSource = dataSet;
                this.RadScheduler1.DataBind();
            }
        }

        public void BindTargetVSActual(RadGrid Grid, string SalesOf, string QuarterType, string EstimateType, string TargetRecordType, string StatusID, bool ShowArchivedStatus)
        {
            string caption = "";
            string str = "";
            string quarterType = QuarterType;
            DataSet dataSet = new DataSet();
            dataSet = (this.ModuleNames.ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), SalesOf, quarterType, EstimateType, TargetRecordType, StatusID, ShowArchivedStatus) : dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", quarterType, EstimateType, TargetRecordType, StatusID, ShowArchivedStatus));
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    try
                    {
                        caption = dataSet.Tables[0].Columns[i].Caption;
                        str = dataSet.Tables[0].Columns[i].Caption;
                        if (str.ToLower() == "actualvalue" || str.ToLower() == "targetvalue" || str.ToLower() == "username")
                        {
                            if (str.ToLower() == "actualvalue")
                            {
                                str = string.Concat(this.objLanguage.GetLanguageConversion("Actual_Amount"), " (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
                            }
                            else if (str.ToLower() == "targetvalue")
                            {
                                str = string.Concat(this.objLanguage.GetLanguageConversion("Target_Amount"), " (", this.objCommon.GetCurrencyinRequiredFormate("", true), ")");
                            }
                            else if (str.ToLower() == "username")
                            {
                                str = (TargetRecordType.ToString().ToLower() != "company" ? this.objLanguage.GetLanguageConversion("Sales_Person") : this.objLanguage.GetLanguageConversion("Company_Name"));
                            }
                            this.GenerateTargetVSActualGridBoundColumns(caption, str, Grid);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    try
                    {
                        row["username"] = this.objBase.SpecialDecode(row["username"].ToString());
                    }
                    catch
                    {
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BindTasksGrid(RadGrid Grid, string dateType, string TaskStatus, int noOfRecords)
        {
            string caption = "";
            string languageConversion = "";
            if (dateType == "1")
            {
                dateType = "Today";
            }
            else if (dateType == "3")
            {
                dateType = "ThisMonth";
            }
            else if (dateType == "4")
            {
                dateType = "TodayOverDue";
            }
            else if (dateType == "5")
            {
                dateType = "Tomorrow";
            }
            else if (dateType == "6")
            {
                dateType = "Next7Days";
            }
            else if (dateType == "7")
            {
                dateType = "Next7DaysOverDue";
            }
            else if (dateType == "8")
            {
                dateType = "AllOpen";
            }
            else if (dateType == "9")
            {
                dateType = "All";
            }
            DataSet dataSet = dashboardestimate.Dashboard_WidgetTasks_Select(this.CompanyID, Convert.ToInt32(this.Session["UserID"]), dateType, TaskStatus, noOfRecords);
            if (dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    try
                    {
                        caption = dataSet.Tables[0].Columns[i].Caption;
                        languageConversion = dataSet.Tables[0].Columns[i].Caption;
                        if (languageConversion.ToLower() == "taskstatus" || languageConversion.ToLower() == "subject" || languageConversion.ToLower() == "duedate" || languageConversion.ToLower() == "contactname" || languageConversion.ToLower() == "assigntousername")
                        {
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
                            this.GenerateLatestNotesGridBoundColumns(caption, languageConversion, Grid);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    try
                    {
                        try
                        {
                            row["AssignToUserName"] = this.objBase.SpecialDecode(row["AssignToUserName"].ToString());
                            row["ContactName"] = this.objBase.SpecialDecode(row["ContactName"].ToString());
                            string str = row["Duedate"].ToString();
                            string[] strArrays = str.Split(new char[] { ' ' });
                            string str1 = string.Concat(strArrays[0].ToString(), " ", row["TaskTime"].ToString());
                            row["Duedate"] = str1;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    catch
                    {
                    }
                }
                Grid.DataSource = dataSet;
                Grid.DataBind();
            }
        }

        public void BindTodayAdminGrid()
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskCall_Today_ForallUsers((long)this.CompanyID, (long)0);
            this.RadGridTodayAdmin.DataSource = dataSet;
            this.RadGridTodayAdmin.DataBind();
        }

        public void BindTodayGrid()
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_Today((long)this.ClientID, (long)this.CompanyID, this.UserID, "All");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadGridToday.DataSource = dataSet;
                this.RadGridToday.DataBind();
            }
        }

        public void BindUserDrop()
        {
            DataSet dataSet = DepartmentBaseClass.CRM_Alluser_select(this.CompanyID);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["Name"] = this.objBase.SpecialDecode(row["Name"].ToString());
            }
            this.ddlAssignto.DataSource = dataSet;
            this.ddlAssignto.DataTextField = "Name";
            this.ddlAssignto.DataValueField = "UserID";
            this.ddlAssignto.DataBind();
            this.ddlAssignto.Items.Insert(0, "");
            this.ddlAssignto.Items[0].Text = "All";
            this.ddlAssignto.Items[0].Value = "-1";
        }

        public void BindWeekGrid()
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_ThiSweek(this.ClientID, this.CompanyID, this.UserID, Convert.ToDateTime(this.SelectedDate));
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadGridWeeks.DataSource = dataSet;
                this.RadGridWeeks.DataBind();
            }
        }

        protected void btnCustomize_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "Settings/dashboard_settings.aspx"));
        }

        protected void btnGetScreenResolution_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object width = dashboard.ScreenResolution.Width;
            Size screenResolution = dashboard.ScreenResolution;
            response.Write(string.Format("Your screen available size is {0} by {1}", width, screenResolution.Height));
        }

        protected void btnInvchange_Click(object sender, EventArgs e)
        {
            this.ddlstatus_OnSelectedIndexChanged1();
        }

        private RadDock CreateRadDock(DataRow dr)
        {
            object[] str;
            string[] strArrays;
            Color[] colorArray;
            int num = Convert.ToInt32(this.Session["ScreenResolutionWidth"]);
            int num1 = num / 2;
            int num2 = num * 3 / 100;
            string str1 = string.Concat(num1 - num2, "px");
            int num3 = Convert.ToInt32(this.Session["ScreenResolutionWidth"]);
            int num4 = num3 * 96 / 100;
            string str2 = string.Concat(num4, "px");
            int num5 = Convert.ToInt32(dr["CopyMasterID"]);
            string str3 = this.GenerateWhereConditions(dr);
            format = this.DateFormat;
            RadDock radDock = new RadDock()
            {
                DockMode = DockMode.Docked
            };
            Guid guid = Guid.NewGuid();
            radDock.UniqueName = guid.ToString().Replace("-", "a");
            radDock.ID = string.Concat("RadDock", num5);
            radDock.Title = this.objBase.SpecialDecode(dr["TitleName"].ToString());
            radDock.Skin = "Default";
            radDock.EnableRoundedCorners = true;
            radDock.DefaultCommands = DefaultCommands.ExpandCollapse;
            radDock.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            radDock.Height = System.Web.UI.WebControls.Unit.Pixel(365);
            radDock.Style.Add("margin-bottom", "15px");
            radDock.ContentContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            radDock.OnClientInitialize = "OnClientInitialize";
            radDock.OnClientDockPositionChanged = "ClientDockPositionChanged";
            radDock.TitlebarContainer.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
            if (dr["DisplayType"].ToString().ToLower() == "tabular" || dr["DisplayType"].ToString().ToLower() == "calender" || dr["DisplayType"].ToString().ToLower() == "task" || dr["DisplayType"].ToString().ToLower() == "call" || dr["DisplayType"].ToString().ToLower() == "both")
            {
                DropDownList dropDownList = new DropDownList()
                {
                    ID = string.Concat("ddlType_", num5.ToString()),
                    Width = 150,
                    AutoPostBack = true,
                    CssClass = "simpledropdownPopup"
                };
                dropDownList.Attributes.Add("style", "margin-top:5px; margin-left:1px;");
                dropDownList.SelectedIndexChanged += new EventHandler(this.ddlCallTaskEvent_OnSelectedIndexChanged);
                dropDownList.Items.Insert(0, "All");
                dropDownList.Items.Insert(1, "Call");
                dropDownList.Items.Insert(2, "Task");
                if (dr["MasterID"].ToString() == "5" || dr["MasterID"].ToString() == "6" || dr["MasterID"].ToString() == "7")
                {
                    dropDownList.Visible = false;
                }
                else
                {
                    dropDownList.Visible = false;
                }
                RadDatePicker radDatePicker = new RadDatePicker()
                {
                    ID = string.Concat("rdpCalender_", num5.ToString()),
                    Width = 100
                };
                radDatePicker.Attributes.Add("style", "padding-top:5px; margin-left:15px;");
                radDatePicker.AutoPostBack = true;
                radDatePicker.ShowPopupOnFocus = true;
                radDatePicker.DatePopupButton.Visible = false;
                radDatePicker.SelectedDate = new DateTime?(DateTime.Now);
                radDatePicker.SelectedDateChanged += new SelectedDateChangedEventHandler(this.rdpCalender_SelectedDateChanged);
                if (dr["MasterID"].ToString() == "5" || dr["MasterID"].ToString() == "6" || dr["MasterID"].ToString() == "7")
                {
                    radDatePicker.Visible = false;
                }
                else
                {
                    radDatePicker.Visible = false;
                }
                HtmlGenericControl htmlGenericControl = new HtmlGenericControl("div");
                htmlGenericControl.Attributes.Add("style", "border-bottom: 1px solid #C9C9C9; width: 99.6%; margin-top:2px;");
                RadGrid radGrid = new RadGrid()
                {
                    Width = System.Web.UI.WebControls.Unit.Percentage(99.5)
                };
                radGrid.Style.Add("margin-bottom", "6px");
                radGrid.ID = string.Concat("radGrid_", num5.ToString());
                radGrid.ClientSettings.Scrolling.AllowScroll = true;
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
                radGrid.MasterTableView.NoMasterRecordsText = string.Concat("<div style='margin-left:-px; margin-top:5px;'>", this.objLangClass.GetLanguageConversion("No_Records_Found"), "</div>");
                radGrid.ClientSettings.ClientEvents.OnRowMouseOver = "RowMouseOver";
                radGrid.ClientSettings.ClientEvents.OnRowMouseOut = "RowMouseOut";
                radGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                radDock.ContentContainer.Controls.Add(dropDownList);
                radDock.ContentContainer.Controls.Add(radDatePicker);
                System.Web.UI.UpdatePanel updatePanel = new System.Web.UI.UpdatePanel()
                {
                    ID = string.Concat("upanel", num5.ToString()),
                    UpdateMode = UpdatePanelUpdateMode.Conditional
                };
                updatePanel.ContentTemplateContainer.Controls.Add(dropDownList);
                updatePanel.ContentTemplateContainer.Controls.Add(radDatePicker);
                updatePanel.ContentTemplateContainer.Controls.Add(htmlGenericControl);
                updatePanel.ContentTemplateContainer.Controls.Add(radGrid);
                radDock.ContentContainer.Controls.Add(updatePanel);
                if (dr["MasterID"].ToString() == "4")
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringBuilder1 = new StringBuilder();
                    stringBuilder.Append("<div style='margin-top:0px;'>");
                    stringBuilder.Append("<table style='width:99%;'>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='float:right'>");
                    DropDownList languageConversion = new DropDownList();
                    languageConversion.Items.Insert(0, " ");
                    languageConversion.Items[0].Text = this.objLanguage.GetLanguageConversion("Today");
                    languageConversion.Items[0].Value = "Today";
                    languageConversion.Items.Insert(1, " ");
                    languageConversion.Items[1].Text = this.objLanguage.GetLanguageConversion("Today_Plus_Overdue");
                    languageConversion.Items[1].Value = "TodayOverDue";
                    languageConversion.Items.Insert(2, " ");
                    languageConversion.Items[2].Text = this.objLanguage.GetLanguageConversion("Tomorrow");
                    languageConversion.Items[2].Value = "Tomorrow";
                    languageConversion.Items.Insert(3, " ");
                    languageConversion.Items[3].Text = this.objLanguage.GetLanguageConversion("Next_7_Days");
                    languageConversion.Items[3].Value = "Next7Days";
                    languageConversion.Items.Insert(4, " ");
                    languageConversion.Items[4].Text = this.objLanguage.GetLanguageConversion("Next_7_Days_Plus_Overdue");
                    languageConversion.Items[4].Value = "Next7DaysPlusOverDue";
                    languageConversion.Items.Insert(5, " ");
                    languageConversion.Items[5].Text = this.objLanguage.GetLanguageConversion("This_Month");
                    languageConversion.Items[5].Value = "ThisMonth";
                    languageConversion.Items.Insert(6, " ");
                    languageConversion.Items[6].Text = this.objLanguage.GetLanguageConversion("All_Open");
                    languageConversion.Items[6].Value = "AllOpen";
                    languageConversion.Items.Insert(7, " ");
                    languageConversion.Items[7].Text = this.objLanguage.GetLanguageConversion("All");
                    languageConversion.Items[7].Value = "All";
                    if (dr["DefaultDate"].ToString() == "1")
                    {
                        this.objBase.SetDDLValue(languageConversion, "Today");
                    }
                    else if (dr["DefaultDate"].ToString() == "2")
                    {
                        this.objBase.SetDDLValue(languageConversion, "TodayOverDue");
                    }
                    else if (dr["DefaultDate"].ToString() == "3")
                    {
                        this.objBase.SetDDLValue(languageConversion, "Tomorrow");
                    }
                    else if (dr["DefaultDate"].ToString() == "4")
                    {
                        this.objBase.SetDDLValue(languageConversion, "Next7Days");
                    }
                    else if (dr["DefaultDate"].ToString() == "5")
                    {
                        this.objBase.SetDDLValue(languageConversion, "Next7DaysPlusOverDue");
                    }
                    else if (dr["DefaultDate"].ToString() == "6")
                    {
                        this.objBase.SetDDLValue(languageConversion, "ThisMonth");
                    }
                    else if (dr["DefaultDate"].ToString() == "7")
                    {
                        this.objBase.SetDDLValue(languageConversion, "AllOpen");
                    }
                    else if (dr["DefaultDate"].ToString() == "8")
                    {
                        this.objBase.SetDDLValue(languageConversion, "All");
                    }
                    else if (dr["DefaultDate"].ToString() == "-1")
                    {
                        this.objBase.SetDDLValue(languageConversion, "All");
                    }
                    languageConversion.ID = "ddldaterange_";
                    languageConversion.AutoPostBack = true;
                    languageConversion.Style.Add("float", "right;");
                    languageConversion.Style.Add("margin-right", "15px;");
                    languageConversion.Style.Add("width", "115px;margin-top:1px;");
                    languageConversion.CssClass = "simpledropdownPopup";
                    languageConversion.Attributes.Add("onchange", string.Concat("javascript:TaskCallDAte(this.value, ", num5, ");"));
                    stringBuilder1.Append("</div>");
                    stringBuilder1.Append("</td>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='float:right'>");
                    DropDownList value = new DropDownList();
                    forecast _forecast = new forecast();
                    DataTable dataTable = new DataTable();
                    dataTable = _forecast.SelectAllUsers(this.CompanyID);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            column.ReadOnly = false;
                        }
                        row["SalesPersonName"] = this.objBase.SpecialDecode(row["SalesPersonName"].ToString());
                    }
                    value.DataSource = dataTable;
                    value.DataTextField = "SalesPersonName";
                    value.DataValueField = "userid";
                    value.DataBind();
                    value.Items.Insert(0, " ");
                    value.Items[0].Text = "All";
                    value.Items[0].Value = "-1";
                    value.ID = "ddlcustomertask_";
                    value.AutoPostBack = true;
                    value.Style.Add("float", "right;");
                    value.Style.Add("margin-right", "15px;");
                    value.Style.Add("width", "115px;margin-top:1px;");
                    value.CssClass = "simpledropdownPopup";
                    value.Attributes.Add("onchange", string.Concat("javascript:TaskCall(this.value, ", num5, ");"));
                    stringBuilder1.Append("</div>");
                    stringBuilder1.Append("</td>");
                    stringBuilder.Append("<td>");
                    stringBuilder.Append("<div style='float:right'>");
                    LinkButton linkButton = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("lnkPrint_", num5)
                    };
                    linkButton.Style.Add("float", "right; margin-top:5px;");
                    if (this.taskcallcustomer.Value == "")
                    {
                        str = new object[] { "Javascript:PrintTaskCall('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", dr["DefaultDate"].ToString(), "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        str = new object[] { "Javascript:PrintTaskCall('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.taskcallcustomer.Value, "','", dr["NoOfRecords"].ToString(), "','", dr["DefaultDate"].ToString(), "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton.OnClientClick = string.Concat(str);
                    }
                    stringBuilder1.Append("</div>");
                    stringBuilder1.Append("</td>");
                    stringBuilder1.Append("</tr>");
                    stringBuilder1.Append("</table>");
                    stringBuilder1.Append("</div>");
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        if (this.taskcalldate.Value == "")
                        {
                            this.taskcalldate.Value = "All";
                        }
                        this.BindGrid(radGrid, dr["DefaultDate"].ToString(), Convert.ToInt32(dr["NoOfRecords"]), dr["DisplayType"].ToString(), dr["DisplayRecordSalesOf"].ToString());
                    }
                    else
                    {
                        if (this.taskcallcustomer.Value == "")
                        {
                            this.taskcallcustomer.Value = "-1";
                        }
                        if (this.taskcalldate.Value == "")
                        {
                            this.taskcalldate.Value = "All";
                        }
                        this.BindGrid(radGrid, this.taskcalldate.Value, Convert.ToInt32(dr["NoOfRecords"]), dr["DisplayType"].ToString(), this.taskcallcustomer.Value);
                        value.SelectedValue = this.taskcallcustomer.Value;
                        languageConversion.SelectedValue = this.taskcalldate.Value;
                    }
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(280);
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewTaskCall);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(value);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(languageConversion);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder1.ToString()));
                }
                else if (dr["MasterID"].ToString() == "5")
                {
                    StringBuilder stringBuilder2 = new StringBuilder();
                    StringBuilder stringBuilder3 = new StringBuilder();
                    stringBuilder2.Append("<div style='margin-top:0px;'>");
                    stringBuilder2.Append("<table style='width:99%;'>");
                    stringBuilder2.Append("<tr>");
                    stringBuilder2.Append("<td>");
                    stringBuilder2.Append("<div style='float:right'>");
                    DropDownList dropDownList1 = new DropDownList();
                    dropDownList1.Items.Insert(0, " ");
                    dropDownList1.Items[0].Text = "---Select---";
                    dropDownList1.Items[0].Value = "51";
                    dropDownList1.Items.Insert(1, " ");
                    dropDownList1.Items[1].Text = "5";
                    dropDownList1.Items[1].Value = "5";
                    dropDownList1.Items.Insert(2, " ");
                    dropDownList1.Items[2].Text = "10";
                    dropDownList1.Items[2].Value = "10";
                    dropDownList1.Items.Insert(3, " ");
                    dropDownList1.Items[3].Text = "25";
                    dropDownList1.Items[3].Value = "25";
                    dropDownList1.Items.Insert(4, " ");
                    dropDownList1.Items[4].Text = "50";
                    dropDownList1.Items[4].Value = "50";
                    dropDownList1.ID = "ddlNoOfRecords_";
                    dropDownList1.AutoPostBack = true;
                    dropDownList1.Style.Add("float", "right;");
                    dropDownList1.Style.Add("margin-right", "15px;");
                    dropDownList1.Style.Add("width", "115px;margin-top:1px;");
                    dropDownList1.CssClass = "simpledropdownPopup";
                    dropDownList1.Attributes.Add("onchange", string.Concat("javascript:latestNotesNo(this.value, ", num5, ");"));
                    if (this.hdnlatestNotesNo.Value != "")
                    {
                        dropDownList1.SelectedValue = this.hdnlatestNotesNo.Value;
                    }
                    else
                    {
                        dropDownList1.SelectedValue = dr["NoOFRecords"].ToString();
                        this.hdnlatestNotesNo.Value = dr["NoOFRecords"].ToString();
                    }
                    stringBuilder3.Append("</div>");
                    stringBuilder3.Append("</td>");
                    stringBuilder2.Append("<td>");
                    stringBuilder2.Append("<div style='float:right'>");
                    DropDownList value1 = new DropDownList();
                    DataTable dataTable1 = SettingsBasePage.CRM_Customers_SelectForDashboard(Convert.ToInt64(this.Session["CompanyID"]), "latestnotesofCustomerandProspect");
                    if (dataTable1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable1.Columns.Count; i++)
                        {
                            dataTable1.Columns[i].ReadOnly = false;
                        }
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            dataRow["ClientName"] = this.objBase.SpecialDecode(dataRow["ClientName"].ToString());
                        }
                    }
                    value1.DataSource = dataTable1;
                    value1.DataValueField = "ClientID";
                    value1.DataTextField = "ClientName";
                    value1.DataBind();
                    value1.Items.Insert(0, " ");
                    value1.Items[0].Text = "All";
                    value1.Items[0].Value = "-1";
                    value1.ID = "ddlcustomer_";
                    value1.AutoPostBack = true;
                    value1.Style.Add("float", "right;");
                    value1.Style.Add("margin-right", "15px;");
                    value1.Style.Add("width", "115px;margin-top:1px;");
                    value1.CssClass = "simpledropdownPopup";
                    value1.Attributes.Add("onchange", string.Concat("javascript:latestNotes(this.value, ", num5, ");"));
                    stringBuilder3.Append("</div>");
                    stringBuilder3.Append("</td>");
                    stringBuilder2.Append("<td>");
                    stringBuilder2.Append("<div style='float:right'>");
                    LinkButton linkButton1 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("lnkPrint_", num5)
                    };
                    linkButton1.Style.Add("float", "right; margin-top:5px;");
                    if (this.hdnlatestNotes.Value == "")
                    {
                        if (this.hdnlatestNotesNo.Value == "")
                        {
                            this.hdnlatestNotesNo.Value = "50";
                        }
                        str = new object[] { "Javascript:PrintLAtestNotes('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomerID"].ToString(), "','", this.hdnlatestNotesNo.Value, "','", dr["TitleName"].ToString(), "');" };
                        linkButton1.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        if (this.hdnlatestNotes.Value == "")
                        {
                            this.hdnlatestNotesNo.Value = "50";
                        }
                        str = new object[] { "Javascript:PrintLAtestNotes('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnlatestNotes.Value, "','", this.hdnlatestNotesNo.Value, "','", dr["TitleName"].ToString(), "');" };
                        linkButton1.OnClientClick = string.Concat(str);
                    }
                    stringBuilder3.Append("</div>");
                    stringBuilder3.Append("</td>");
                    stringBuilder3.Append("</tr>");
                    stringBuilder3.Append("</table>");
                    stringBuilder3.Append("</div>");
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(280);
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        if (this.hdnlatestNotesNo.Value == "")
                        {
                            this.hdnlatestNotesNo.Value = "5";
                        }
                        this.BindLatestNotesGrid(radGrid, Convert.ToInt32(dr["NoOfRecords"]), dr["CustomizeColumns"].ToString(), Convert.ToInt64(dr["CustomerID"]));
                    }
                    else
                    {
                        if (this.hdnlatestNotes.Value == "")
                        {
                            HiddenField hiddenField = this.hdnlatestNotes;
                            long num6 = Convert.ToInt64(dr["CustomerID"]);
                            hiddenField.Value = num6.ToString();
                        }
                        if (this.hdnlatestNotesNo.Value == "")
                        {
                            this.hdnlatestNotesNo.Value = "5";
                        }
                        this.BindLatestNotesGrid(radGrid, Convert.ToInt32(this.hdnlatestNotesNo.Value), dr["CustomizeColumns"].ToString(), Convert.ToInt64(this.hdnlatestNotes.Value));
                        value1.SelectedValue = this.hdnlatestNotes.Value;
                    }
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewLatestNotes);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder2.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton1);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(value1);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(dropDownList1);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder3.ToString()));
                }
                else if (dr["MasterID"].ToString() == "6")
                {
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(300);
                    this.BindTasksGrid(radGrid, dr["DefaultDate"].ToString(), dr["TaskStatus"].ToString(), Convert.ToInt32(dr["NoOfRecords"]));
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewTAsk);
                }
                else if (dr["MasterID"].ToString() == "7")
                {
                    StringBuilder stringBuilder4 = new StringBuilder();
                    StringBuilder stringBuilder5 = new StringBuilder();
                    stringBuilder4.Append("<div style='margin-top:0px;'>");
                    stringBuilder4.Append("<table style='width:99%;'>");
                    stringBuilder4.Append("<tr>");
                    stringBuilder4.Append("<td>");
                    stringBuilder4.Append("<div style='float:right'>");
                    DropDownList languageConversion1 = new DropDownList();
                    languageConversion1.Items.Insert(0, " ");
                    languageConversion1.Items[0].Text = "---Select---";
                    languageConversion1.Items[0].Value = "Both";
                    languageConversion1.Items.Insert(1, " ");
                    languageConversion1.Items[1].Text = this.objLanguage.GetLanguageConversion("Customer");
                    languageConversion1.Items[1].Value = "Customer";
                    languageConversion1.Items.Insert(2, " ");
                    languageConversion1.Items[2].Text = this.objLanguage.GetLanguageConversion("Prospect");
                    languageConversion1.Items[2].Value = "Prospect";
                    languageConversion1.Items.Insert(3, " ");
                    languageConversion1.Items[3].Text = this.objLanguage.GetLanguageConversion("Both");
                    languageConversion1.Items[3].Value = "Both";
                    languageConversion1.ID = "ddldaterange_";
                    languageConversion1.AutoPostBack = true;
                    languageConversion1.Style.Add("float", "right;");
                    languageConversion1.Style.Add("margin-right", "15px;");
                    languageConversion1.Style.Add("width", "115px;margin-top:1px;");
                    languageConversion1.CssClass = "simpledropdownPopup";
                    languageConversion1.Attributes.Add("onchange", string.Concat("javascript:CustomerActivity(this.value, ", num5, ");"));
                    languageConversion1.SelectedValue = this.hdnCompanyType.Value;
                    stringBuilder5.Append("</div>");
                    stringBuilder5.Append("</td>");
                    stringBuilder4.Append("<td>");
                    stringBuilder4.Append("<div style='float:right'>");
                    DropDownList dropDownList2 = new DropDownList();
                    dropDownList2.Items.Insert(0, " ");
                    dropDownList2.Items[0].Text = "---Select---";
                    dropDownList2.Items[0].Value = "10";
                    dropDownList2.Items.Insert(1, " ");
                    dropDownList2.Items[1].Text = "5";
                    dropDownList2.Items[1].Value = "5";
                    dropDownList2.Items.Insert(2, " ");
                    dropDownList2.Items[2].Text = "10";
                    dropDownList2.Items[2].Value = "10";
                    dropDownList2.Items.Insert(3, " ");
                    dropDownList2.Items[3].Text = "25";
                    dropDownList2.Items[3].Value = "25";
                    dropDownList2.Items.Insert(4, " ");
                    dropDownList2.Items[4].Text = "50";
                    dropDownList2.Items[4].Value = "50";
                    dropDownList2.ID = "ddlActivityNo_";
                    dropDownList2.AutoPostBack = true;
                    dropDownList2.Style.Add("float", "right;");
                    dropDownList2.Style.Add("margin-right", "15px;");
                    dropDownList2.Style.Add("width", "115px;margin-top:1px;");
                    dropDownList2.CssClass = "simpledropdownPopup";
                    dropDownList2.Attributes.Add("onchange", string.Concat("javascript:CustomerActivityNo(this.value, ", num5, ");"));
                    stringBuilder5.Append("</div>");
                    stringBuilder5.Append("</td>");
                    stringBuilder4.Append("<td>");
                    stringBuilder4.Append("<div style='float:right'>");
                    LinkButton linkButton2 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("lnkPrint_", num5)
                    };
                    linkButton2.Style.Add("float", "right; margin-top:5px;");
                    if (this.hdnCompanyType.Value == "")
                    {
                        if (this.hdnCompanyTypeNO.Value == "")
                        {
                            this.hdnCompanyTypeNO.Value = "50";
                        }
                        str = new object[] { "Javascript:PrintCustomerActivity('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomerID"].ToString(), "','", this.hdnCompanyTypeNO.Value, "','", dr["DefaultDate"].ToString(), "','", dr["DisplayType"].ToString(), "','", dr["CompanyType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton2.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        if (this.hdnCompanyType.Value == "")
                        {
                            this.hdnCompanyTypeNO.Value = "50";
                        }
                        str = new object[] { "Javascript:PrintCustomerActivity('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomerID"].ToString(), "','", this.hdnCompanyTypeNO.Value, "','", dr["DefaultDate"].ToString(), "','", dr["DisplayType"].ToString(), "','", dr["CompanyType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton2.OnClientClick = string.Concat(str);
                    }
                    stringBuilder5.Append("</div>");
                    stringBuilder5.Append("</td>");
                    stringBuilder5.Append("</tr>");
                    stringBuilder5.Append("</table>");
                    stringBuilder5.Append("</div>");
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(280);
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        if (this.hdnCompanyTypeNO.Value == "")
                        {
                            this.hdnCompanyTypeNO.Value = "5";
                        }
                        this.BindCustomerActivityGrid(radGrid, Convert.ToInt32(dr["NoOfRecords"]), dr["CustomizeColumns"].ToString(), dr["CompanyType"].ToString());
                    }
                    else
                    {
                        if (this.hdnCompanyType.Value == "")
                        {
                            this.hdnCompanyType.Value = dr["CompanyType"].ToString();
                        }
                        if (this.hdnCompanyTypeNO.Value == "")
                        {
                            this.hdnCompanyTypeNO.Value = "10";
                        }
                        this.BindCustomerActivityGrid(radGrid, Convert.ToInt32(this.hdnCompanyTypeNO.Value), dr["CustomizeColumns"].ToString(), this.hdnCompanyType.Value);
                        dropDownList2.SelectedValue = this.hdnCompanyTypeNO.Value;
                    }
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewCustomerActivity);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder4.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton2);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(languageConversion1);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(dropDownList2);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder5.ToString()));
                }
                else if (dr["MasterID"].ToString() == "9")
                {
                    this.ModuleNames = dr["ModuleName"].ToString();
                    StringBuilder stringBuilder6 = new StringBuilder();
                    StringBuilder stringBuilder7 = new StringBuilder();
                    stringBuilder6.Append("<div style='margin-top:0px;'>");
                    stringBuilder6.Append("<table style='width:99%;'>");
                    stringBuilder6.Append("<tr>");
                    stringBuilder6.Append("<td>");
                    stringBuilder6.Append("<div style='float:right'>");
                    DropDownList value2 = new DropDownList();
                    forecast _forecast1 = new forecast();
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = _forecast1.SelectAllUsers(this.CompanyID);
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        foreach (DataColumn dataColumn in dataTable2.Columns)
                        {
                            dataColumn.ReadOnly = false;
                        }
                        row1["SalesPersonName"] = this.objBase.SpecialDecode(row1["SalesPersonName"].ToString());
                    }
                    value2.DataSource = dataTable2;
                    value2.DataTextField = "SalesPersonName";
                    value2.DataValueField = "userid";
                    value2.DataBind();
                    value2.Items.Insert(0, " ");
                    value2.Items[0].Text = "---Select---";
                    value2.Items[0].Value = "0";
                    value2.ID = string.Concat("ddlStatusforeacst_", num5);
                    value2.AutoPostBack = true;
                    value2.Style.Add("float", "right;");
                    value2.Style.Add("margin-right", "15px;");
                    value2.Style.Add("width", "115px;margin-top:1px;");
                    value2.CssClass = "simpledropdownPopup";
                    value2.Attributes.Add("onchange", string.Concat("javascript:getSalesidforecast2(this.value, ", num5, ");"));
                    stringBuilder7.Append("</div>");
                    stringBuilder7.Append("</td>");
                    stringBuilder6.Append("<td>");
                    stringBuilder6.Append("<div style='float:right'>");
                    LinkButton linkButton3 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("LnkPrint1_", num5)
                    };
                    linkButton3.Style.Add("float", "right;margin-top:5px;");
                    if (this.hdsalesForecast2.Value != "")
                    {
                        str = new object[] { "Javascript:PrintForecastGrid('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", this.hdsalesForecast2.Value, "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton3.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        str = new object[] { "Javascript:PrintForecastGrid('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton3.OnClientClick = string.Concat(str);
                    }
                    stringBuilder7.Append("</div>");
                    stringBuilder7.Append("</td>");
                    stringBuilder7.Append("</tr>");
                    stringBuilder7.Append("</table>");
                    stringBuilder7.Append("</div>");
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        this.BindTargetVSActual(radGrid, dr["DisplayRecordSalesOf"].ToString(), dr["QuarterType"].ToString(), dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                    }
                    else
                    {
                        if (this.hdsalesForecast2.Value == "")
                        {
                            this.hdsalesForecast2.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        this.BindTargetVSActual(radGrid, this.hdsalesForecast2.Value, dr["QuarterType"].ToString(), dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                        value2.SelectedValue = this.hdsalesForecast2.Value;
                    }
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(285);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder6.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton3);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true" && dr["ModuleName"].ToString().ToLower() != "company")
                    {
                        radDock.ContentContainer.Controls.Add(value2);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder7.ToString()));
                }
                if (dr["MasterID"].ToString() == "11")
                {
                    StringBuilder stringBuilder8 = new StringBuilder();
                    StringBuilder stringBuilder9 = new StringBuilder();
                    stringBuilder8.Append("<div style='margin-top:0px;'>");
                    stringBuilder8.Append("<table style='width:99%;'>");
                    stringBuilder8.Append("<tr>");
                    stringBuilder8.Append("<td>");
                    stringBuilder8.Append("<div style='float:right'>");
                    DropDownList languageConversion2 = new DropDownList();
                    languageConversion2.Items.Insert(0, " ");
                    languageConversion2.Items[0].Text = "---Select---";
                    languageConversion2.Items[0].Value = "---Select---";
                    languageConversion2.Items.Insert(1, " ");
                    languageConversion2.Items[1].Text = this.objLanguage.GetLanguageConversion("Today");
                    languageConversion2.Items[1].Value = "1";
                    languageConversion2.Items.Insert(2, " ");
                    languageConversion2.Items[2].Text = this.objLanguage.GetLanguageConversion("Today_Plus_Overdue");
                    languageConversion2.Items[2].Value = "2";
                    languageConversion2.Items.Insert(3, " ");
                    languageConversion2.Items[3].Text = this.objLanguage.GetLanguageConversion("Tomorrow");
                    languageConversion2.Items[3].Value = "3";
                    languageConversion2.Items.Insert(4, " ");
                    languageConversion2.Items[4].Text = this.objLanguage.GetLanguageConversion("Next_7_Days");
                    languageConversion2.Items[4].Value = "4";
                    languageConversion2.Items.Insert(5, " ");
                    languageConversion2.Items[5].Text = this.objLanguage.GetLanguageConversion("Next_7_Days_Plus_Overdue");
                    languageConversion2.Items[5].Value = "5";
                    languageConversion2.Items.Insert(6, " ");
                    languageConversion2.Items[6].Text = this.objLanguage.GetLanguageConversion("This_Month");
                    languageConversion2.Items[6].Value = "6";
                    languageConversion2.Items.Insert(7, " ");
                    languageConversion2.Items[7].Text = this.objLanguage.GetLanguageConversion("All_Open");
                    languageConversion2.Items[7].Value = "7";
                    languageConversion2.Items.Insert(8, " ");
                    languageConversion2.Items[8].Text = this.objLanguage.GetLanguageConversion("All");
                    languageConversion2.Items[8].Value = "8";
                    languageConversion2.ID = "ddldaterangeadmin";
                    languageConversion2.AutoPostBack = true;
                    languageConversion2.Style.Add("float", "right;");
                    languageConversion2.Style.Add("margin-right", "15px;");
                    languageConversion2.Style.Add("width", "115px;margin-top:1px;");
                    languageConversion2.CssClass = "simpledropdownPopup";
                    languageConversion2.Attributes.Add("onchange", string.Concat("javascript:SetshowingActivities(this.value, ", num5, ");"));
                    languageConversion2.SelectedValue = this.hdnShowingActivities.Value;
                    stringBuilder9.Append("</div>");
                    stringBuilder9.Append("</td>");
                    stringBuilder8.Append("<td>");
                    stringBuilder8.Append("<div style='float:right'>");
                    DropDownList dropDownList3 = new DropDownList();
                    DataTable dataTable3 = SettingsBasePage.CRM_Customers_SelectForDashboard(Convert.ToInt64(this.Session["CompanyID"]), "latestnotes");
                    if (dataTable3.Rows.Count > 0)
                    {
                        // To fix error: Column 'ClientName' is read only
                        dataTable3.Columns["ClientName"].ReadOnly = false;
                        foreach (DataRow dataRow1 in dataTable3.Rows)
                        {

                            dataRow1["ClientName"] = this.objBase.SpecialDecode(dataRow1["ClientName"].ToString());
                        }
                    }
                    dropDownList3.DataSource = dataTable3;
                    dropDownList3.DataValueField = "ClientID";
                    dropDownList3.DataTextField = "ClientName";
                    dropDownList3.DataBind();
                    dropDownList3.Items.Insert(0, " ");
                    dropDownList3.Items[0].Text = "All";
                    dropDownList3.Items[0].Value = "-1";
                    dropDownList3.ID = "ddlcustomeradmin";
                    dropDownList3.AutoPostBack = true;
                    dropDownList3.Style.Add("float", "right;");
                    dropDownList3.Style.Add("margin-right", "15px;");
                    dropDownList3.Style.Add("width", "115px;margin-top:1px;");
                    dropDownList3.CssClass = "simpledropdownPopup";
                    dropDownList3.Attributes.Add("onchange", string.Concat("javascript:SetshowingActivities1(this.value, ", num5, ");"));
                    dropDownList3.SelectedValue = this.hdnShowingActivities1.Value;
                    stringBuilder9.Append("</div>");
                    stringBuilder9.Append("</td>");
                    stringBuilder8.Append("<td>");
                    stringBuilder8.Append("<div style='float:right'>");
                    DropDownList value3 = new DropDownList();
                    forecast _forecast2 = new forecast();
                    DataTable dataTable4 = new DataTable();
                    dataTable4 = _forecast2.SelectAllUsers(this.CompanyID);
                    foreach (DataRow row2 in dataTable4.Rows)
                    {
                        foreach (DataColumn column1 in dataTable4.Columns)
                        {
                            column1.ReadOnly = false;
                        }
                        row2["SalesPersonName"] = this.objBase.SpecialDecode(row2["SalesPersonName"].ToString());
                    }
                    value3.DataSource = dataTable4;
                    value3.DataTextField = "SalesPersonName";
                    value3.DataValueField = "userid";
                    value3.DataBind();
                    value3.Items.Insert(0, " ");
                    value3.Items[0].Text = "All";
                    value3.Items[0].Value = "-1";
                    value3.ID = "ddlcustomeradminsal";
                    value3.AutoPostBack = true;
                    value3.Style.Add("float", "right;");
                    value3.Style.Add("margin-right", "15px;");
                    value3.Style.Add("width", "115px;margin-top:1px;");
                    value3.CssClass = "simpledropdownPopup";
                    value3.Attributes.Add("onchange", string.Concat("javascript:SetshowingActivities2(this.value, ", num5, ");"));
                    stringBuilder9.Append("</div>");
                    stringBuilder9.Append("</td>");
                    stringBuilder8.Append("<td>");
                    stringBuilder8.Append("<div style='float:right'>");
                    LinkButton linkButton4 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("lnkPrint_", num5)
                    };
                    linkButton4.Style.Add("float", "right; margin-top:5px;");
                    if (this.hdnShowingActivities.Value == "")
                    {
                        if (this.hdnShowingActivities.Value == "---Select---" || this.hdnShowingActivities.Value == "")
                        {
                            this.hdnShowingActivities.Value = "All";
                        }
                        if (this.hdnShowingActivities1.Value == "")
                        {
                            this.hdnShowingActivities1.Value = dr["CustomerID"].ToString();
                        }
                        if (this.hdnShowingActivities2.Value == "")
                        {
                            this.hdnShowingActivities2.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        str = new object[] { "Javascript:ShowingActivities('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnShowingActivities.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnShowingActivities1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnShowingActivities.Value, "','", dr["DisplayType"].ToString(), "','", this.hdnShowingActivities2.Value, "','", dr["TitleName"].ToString(), "');" };
                        linkButton4.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        if (this.hdnShowingActivities.Value == "---Select---")
                        {
                            this.hdnShowingActivities.Value = "All";
                        }
                        if (this.hdnShowingActivities1.Value == "")
                        {
                            this.hdnShowingActivities1.Value = dr["CustomerID"].ToString();
                        }
                        if (this.hdnShowingActivities2.Value == "")
                        {
                            this.hdnShowingActivities2.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        str = new object[] { "Javascript:ShowingActivities('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnShowingActivities.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnShowingActivities1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnShowingActivities.Value, "','", dr["DisplayType"].ToString(), "','", this.hdnShowingActivities2.Value, "','", dr["TitleName"].ToString(), "');" };
                        linkButton4.OnClientClick = string.Concat(str);
                    }
                    stringBuilder9.Append("</div>");
                    stringBuilder9.Append("</td>");
                    stringBuilder9.Append("</tr>");
                    stringBuilder9.Append("</table>");
                    stringBuilder9.Append("</div>");
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        if (this.hdnShowingActivities1.Value == "")
                        {
                            this.hdnShowingActivities1.Value = dr["CustomerID"].ToString();
                        }
                        if (this.hdnShowingActivities2.Value == "")
                        {
                            this.hdnShowingActivities2.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        this.BindGrid_ForAdmin(radGrid, dr["DefaultDate"].ToString(), Convert.ToInt32(dr["NoOfRecords"]), dr["DisplayType"].ToString(), Convert.ToInt64(dr["CustomerID"]), Convert.ToInt64(dr["DisplayRecordSalesOf"]));
                    }
                    else
                    {
                        if (this.hdnShowingActivities.Value == "---Select---")
                        {
                            this.hdnShowingActivities.Value = "All";
                        }
                        if (this.hdnShowingActivities1.Value == "")
                        {
                            this.hdnShowingActivities1.Value = dr["CustomerID"].ToString();
                        }
                        if (this.hdnShowingActivities2.Value == "")
                        {
                            this.hdnShowingActivities2.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        this.BindGrid_ForAdmin(radGrid, this.hdnShowingActivities.Value, Convert.ToInt32(dr["NoOfRecords"]), dr["DisplayType"].ToString(), Convert.ToInt64(this.hdnShowingActivities1.Value), Convert.ToInt64(this.hdnShowingActivities2.Value));
                        value3.SelectedValue = this.hdnShowingActivities2.Value;
                    }
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(287);
                    radGrid.ItemDataBound += new GridItemEventHandler(this.OnRowDataBound_GridViewTaskCall);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder8.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton4);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(value3);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(dropDownList3);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(languageConversion2);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder9.ToString()));
                }
                if (dr["MasterID"].ToString() == "12")
                {
                    StringBuilder stringBuilder10 = new StringBuilder();
                    StringBuilder stringBuilder11 = new StringBuilder();
                    stringBuilder10.Append("<div style='margin-top:0px;'>");
                    stringBuilder10.Append("<table style='width:99%;'>");
                    stringBuilder10.Append("<tr>");
                    stringBuilder10.Append("<td>");
                    stringBuilder10.Append("<div style='float:right'>");
                    DropDownList languageConversion3 = new DropDownList();
                    languageConversion3.Items.Insert(0, " ");
                    languageConversion3.Items[0].Text = "---Select---";
                    languageConversion3.Items[0].Value = "---Select---";
                    languageConversion3.Items.Insert(1, " ");
                    languageConversion3.Items[1].Text = this.objLanguage.GetLanguageConversion("Today");
                    languageConversion3.Items[1].Value = "Today";
                    languageConversion3.Items.Insert(2, " ");
                    languageConversion3.Items[2].Text = this.objLanguage.GetLanguageConversion("This_Week");
                    languageConversion3.Items[2].Value = "ThisWeek";
                    languageConversion3.Items.Insert(3, " ");
                    languageConversion3.Items[3].Text = this.objLanguage.GetLanguageConversion("This_Month");
                    languageConversion3.Items[3].Value = "ThisMonth";
                    languageConversion3.ID = "ddldaterange12_";
                    languageConversion3.AutoPostBack = true;
                    languageConversion3.Style.Add("float", "right;");
                    languageConversion3.Style.Add("margin-right", "15px;");
                    languageConversion3.Style.Add("width", "115px;margin-top:1px;");
                    languageConversion3.CssClass = "simpledropdownPopup";
                    languageConversion3.Attributes.Add("onchange", string.Concat("javascript:CallVSGrid1(this.value, ", num5, ");"));
                    stringBuilder11.Append("</div>");
                    stringBuilder11.Append("</td>");
                    stringBuilder10.Append("<td>");
                    stringBuilder10.Append("<div style='float:right'>");
                    DropDownList dropDownList4 = new DropDownList();
                    forecast _forecast3 = new forecast();
                    DataTable dataTable5 = new DataTable();
                    dataTable5 = _forecast3.SelectAllUsers(this.CompanyID);
                    foreach (DataRow dataRow2 in dataTable5.Rows)
                    {
                        foreach (DataColumn dataColumn1 in dataTable5.Columns)
                        {
                            dataColumn1.ReadOnly = false;
                        }
                        dataRow2["SalesPersonName"] = this.objBase.SpecialDecode(dataRow2["SalesPersonName"].ToString());
                    }
                    dropDownList4.DataSource = dataTable5;
                    dropDownList4.DataTextField = "SalesPersonName";
                    dropDownList4.DataValueField = "userid";
                    dropDownList4.DataBind();
                    dropDownList4.Items.Insert(0, " ");
                    dropDownList4.Items[0].Text = "All";
                    dropDownList4.Items[0].Value = "-1";
                    dropDownList4.ID = "ddlcustomertask12_";
                    dropDownList4.AutoPostBack = true;
                    dropDownList4.Style.Add("float", "right;");
                    dropDownList4.Style.Add("margin-right", "15px;");
                    dropDownList4.Style.Add("width", "115px;margin-top:1px;");
                    dropDownList4.CssClass = "simpledropdownPopup";
                    dropDownList4.Attributes.Add("onchange", string.Concat("javascript:CallVSGrid(this.value, ", num5, ");"));
                    stringBuilder11.Append("</div>");
                    stringBuilder11.Append("</td>");
                    stringBuilder10.Append("<td>");
                    stringBuilder10.Append("<div style='float:right'>");
                    LinkButton linkButton5 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Print"),
                        ID = string.Concat("lnkPrint_", num5)
                    };
                    linkButton5.Style.Add("float", "right; margin-top:5px;");
                    if (this.hdnCallVS1Grid.Value == "")
                    {
                        if (this.hdnCallVSGrid.Value == "" || this.hdnCallVSGrid.Value == "---Select---")
                        {
                            this.hdnCallVSGrid.Value = dr["DefaultDate"].ToString();
                        }
                        str = new object[] { "Javascript:PrintCall1('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["CustomerID"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", dr["DefaultDate"].ToString(), "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton5.OnClientClick = string.Concat(str);
                    }
                    else
                    {
                        if (this.hdnCallVSGrid.Value == "" || this.hdnCallVSGrid.Value == "---Select---")
                        {
                            this.hdnCallVSGrid.Value = dr["DefaultDate"].ToString();
                        }
                        str = new object[] { "Javascript:PrintCall1('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1Grid.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVSGrid.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                        linkButton5.OnClientClick = string.Concat(str);
                    }
                    stringBuilder11.Append("</div>");
                    stringBuilder11.Append("</td>");
                    stringBuilder11.Append("</tr>");
                    stringBuilder11.Append("</table>");
                    stringBuilder11.Append("</div>");
                    if (this.hdnChartID.Value != num5.ToString())
                    {
                        if (this.hdnCallVS1Grid.Value == "")
                        {
                            this.hdnCallVS1Grid.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        if (this.hdnCallVSGrid.Value == "" || this.hdnCallVSGrid.Value == "---Select---")
                        {
                            this.hdnCallVSGrid.Value = dr["DefaultDate"].ToString();
                        }
                        this.BindGrid1(radGrid, this.hdnCallVSGrid.Value, this.hdnCallVS1Grid.Value);
                    }
                    else
                    {
                        if (this.hdnCallVS1Grid.Value == "")
                        {
                            this.hdnCallVS1Grid.Value = dr["DisplayRecordSalesOf"].ToString();
                        }
                        if (this.hdnCallVSGrid.Value == "" || this.hdnCallVSGrid.Value == "---Select---")
                        {
                            this.hdnCallVSGrid.Value = dr["DefaultDate"].ToString();
                        }
                        this.BindGrid1(radGrid, this.hdnCallVSGrid.Value, this.hdnCallVS1Grid.Value);
                        dropDownList4.SelectedValue = this.hdnCallVS1Grid.Value;
                        languageConversion3.SelectedValue = this.hdnCallVSGrid.Value;
                    }
                    radGrid.Height = System.Web.UI.WebControls.Unit.Pixel(280);
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder10.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton5);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(languageConversion3);
                    }
                    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(dropDownList4);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder11.ToString()));
                }
                radDock.ContentContainer.Controls.Add(htmlGenericControl);
                radDock.ContentContainer.Controls.Add(radGrid);
            }
            else
            {
                RadChart radChart = new RadChart()
                {
                    ID = string.Concat("radChart_", num5)
                };
                radChart.PlotArea.EmptySeriesMessage.TextBlock.Text = this.objLangClass.GetLanguageConversion("No_Records_Found");
                radChart.PlotArea.EmptySeriesMessage.TextBlock.Appearance.TextProperties.Font = new Font("Lucida Sans Unicode,Arial,Helvetica,sans-serif", 10f, FontStyle.Regular);
                if (dr["IsSpreadOverTwoColumns"].ToString().ToLower() != "true")
                {
                    radChart.Width = new System.Web.UI.WebControls.Unit(str1);
                    radChart.Height = new System.Web.UI.WebControls.Unit("310px");
                }
                else if (dr["GraphType"].ToString().ToLower() == "pie")
                {
                    radChart.Width = new System.Web.UI.WebControls.Unit(str1);
                    radChart.Height = new System.Web.UI.WebControls.Unit("310px");
                }
                else
                {
                    radChart.Height = new System.Web.UI.WebControls.Unit("310px");
                    radChart.Width = new System.Web.UI.WebControls.Unit(str2);
                }
                radChart.AutoTextWrap = false;
                radChart.AutoLayout = true;
                radChart.Skin = "Vista";
                radChart.Style.Add("margin-top", "0px;");
                radChart.Style.Add("margin-bottom", "0px;");
                radChart.ChartTitle.Visible = false;
                if (dr["TitleName"].ToString().Length <= 50)
                {
                    radChart.ChartTitle.TextBlock.Text = this.objBase.SpecialDecode(dr["TitleName"].ToString());
                }
                else
                {
                    radChart.ChartTitle.TextBlock.Text = string.Concat(this.objBase.SpecialDecode(dr["TitleName"].ToString()).Substring(0, 50), "...");
                }
                if (dr["MasterID"].ToString() == "3")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChartJobInvoice_ItemDataBound);
                }
                if (dr["MasterID"].ToString() == "9")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_ItemDataBoundPie);
                }
                else if (dr["MasterID"].ToString() == "15")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_ItemDataBoundPie1);
                }
                else if (dr["MasterID"].ToString() == "2" || dr["MasterID"].ToString() == "8")
                {
                    if (dr["GraphType"].ToString().ToLower() != "stackedbar")
                    {
                        radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_EstimateJobInvoiceItemDataBound);
                    }
                }
                else if (dr["MasterID"].ToString() == "1")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_ItemDataBound1);
                }
                else if (dr["MasterID"].ToString() == "10")
                {
                    radChart.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(this.radChart_ItemDataBound);
                }
                radChart.Style.Add(HtmlTextWriterStyle.Overflow, "hidden");
                radChart.Appearance.Border.Visible = false;
                radChart.Appearance.FillStyle.FillType = FillType.Image;
                DataSet dataSet = new DataSet();
                radChart.ChartTitle.TextBlock.Appearance.TextProperties.Font = new Font("Lucida Sans Unicode,Arial,Helvetica,sans-serif", 12f, FontStyle.Bold);
                radChart.PlotArea.XAxis.AutoScale = false;
                int num7 = 0;
                if (dr["MasterID"].ToString() == "1")
                {
                    if (dr["GraphType"].ToString().ToLower() != "bar")
                    {
                        StringBuilder stringBuilder12 = new StringBuilder();
                        StringBuilder stringBuilder13 = new StringBuilder();
                        stringBuilder12.Append("<div style='margin-top:0px;'>");
                        stringBuilder12.Append("<table style='width:99%;'>");
                        stringBuilder12.Append("<tr>");
                        stringBuilder12.Append("<td>");
                        stringBuilder12.Append("<div style='float:right'>");
                        DropDownList value4 = new DropDownList();
                        this.objSet.Bind_Status_new(value4, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "estimate");
                        value4.ID = string.Concat("ddlStatus1_", num5);
                        value4.AutoPostBack = true;
                        value4.Style.Add("float", "right;");
                        value4.Style.Add("margin-right", "15px;");
                        value4.Style.Add("width", "115px;margin-top:1px;");
                        value4.CssClass = "simpledropdownPopup";
                        value4.Attributes.Add("onchange", string.Concat("javascript:getstatusvalue1(this.value, ", num5, ");"));
                        stringBuilder13.Append("</div>");
                        stringBuilder13.Append("</td>");
                        stringBuilder12.Append("<td>");
                        stringBuilder12.Append("<div style='float:right'>");
                        LinkButton linkButton6 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton6.Style.Add("float", "right;margin-top:5px;");
                        if (this.ddlStatusValue1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton6.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton6.OnClientClick = string.Concat(str);
                        }
                        stringBuilder13.Append("</div>");
                        stringBuilder13.Append("</td>");
                        stringBuilder12.Append("<td>");
                        stringBuilder12.Append("<div style='float:right'>");
                        LinkButton linkButton7 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton7.Style.Add("float", "right;");
                        linkButton7.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.ddlStatusValue1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton7.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton7.OnClientClick = string.Concat(str);
                        }
                        stringBuilder13.Append("</div>");
                        stringBuilder13.Append("</td>");
                        stringBuilder13.Append("</tr>");
                        stringBuilder13.Append("</table>");
                        stringBuilder13.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["Status"].ToString(), dr["ModuleName"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["Status"].ToString(), dr["ModuleName"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            value4.SelectedValue = this.ddlStatusValue1.Value;
                        }
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                if (dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString().Length <= 8)
                                {
                                    radChart.PlotArea.XAxis[num7].TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.Legend.TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num7].TextBlock.Text = string.Concat(this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString()).Substring(0, 5), "...");
                                    radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                    radChart.Legend.TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[i]["EstimateStatus"].ToString());
                                }
                                num7++;
                            }
                        }
                        ChartSeries chartSeries = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), dr["GraphType"].ToString())
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
                        int num8 = 0;
                        foreach (ChartSeriesItem item in radChart.Series[0].Items)
                        {
                            int num9 = num8;
                            num8 = num9 + 1;
                            item.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num9));
                            item.Appearance.FillStyle.FillType = FillType.Solid;
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder12.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton6);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton7);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(value4);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder13.ToString()));
                    }
                    else
                    {
                        StringBuilder stringBuilder14 = new StringBuilder();
                        StringBuilder stringBuilder15 = new StringBuilder();
                        stringBuilder14.Append("<div style='margin-top:0px;'>");
                        stringBuilder14.Append("<table style='width:99%;'>");
                        stringBuilder14.Append("<tr>");
                        stringBuilder14.Append("<td>");
                        stringBuilder14.Append("<div style='float:right'>");
                        DropDownList dropDownList5 = new DropDownList();
                        this.objSet.Bind_Status_new(dropDownList5, this.CompanyID, string.Concat("---", this.objLanguage.GetLanguageConversion("Select"), "---"), "estimate");
                        dropDownList5.ID = string.Concat("ddlStatus_", num5);
                        dropDownList5.AutoPostBack = true;
                        dropDownList5.Style.Add("float", "right;");
                        dropDownList5.Style.Add("margin-right", "15px;");
                        dropDownList5.Style.Add("width", "115px;margin-top:1px;");
                        dropDownList5.CssClass = "simpledropdownPopup";
                        dropDownList5.Attributes.Add("onchange", string.Concat("javascript:getstatusvalue(this.value, ", num5, ");"));
                        stringBuilder15.Append("</div>");
                        stringBuilder15.Append("</td>");
                        stringBuilder14.Append("<td>");
                        stringBuilder14.Append("<div style='float:right'>");
                        LinkButton linkButton8 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Print"),
                            ID = string.Concat("lnkPrint_", num5)
                        };
                        linkButton8.Style.Add("float", "right; margin-top:5px;");
                        if (this.ddlStatusValue.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton8.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton8.OnClientClick = string.Concat(str);
                        }
                        stringBuilder15.Append("</div>");
                        stringBuilder15.Append("</td>");
                        stringBuilder14.Append("<td>");
                        stringBuilder14.Append("<div style='float:right'>");
                        LinkButton linkButton9 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen_", num5)
                        };
                        linkButton9.Style.Add("float", "right;");
                        linkButton9.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.ddlStatusValue.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton9.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateCountbyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton9.OnClientClick = string.Concat(str);
                        }
                        stringBuilder15.Append("</div>");
                        stringBuilder15.Append("</td>");
                        stringBuilder15.Append("</tr>");
                        stringBuilder15.Append("</table>");
                        stringBuilder15.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["Status"].ToString(), dr["ModuleName"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_ProbalilityPercent_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["Status"].ToString(), dr["ModuleName"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            dropDownList5.SelectedValue = this.ddlStatusValue.Value;
                        }
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table = dataViews.ToTable(true, strArrays);
                            DataView dataViews1 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table1 = dataViews.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table.Rows.Count, 1);
                            foreach (DataRow row3 in table1.Rows)
                            {
                                ChartSeries chartSeries1 = new ChartSeries(row3["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row3["EstimateStatus"].ToString().Length <= 10)
                                {
                                    chartSeries1.Name = row3["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries1.Name = string.Concat(row3["EstimateStatus"].ToString().Substring(0, 10), "..");
                                }
                                chartSeries1.YAxisType = ChartYAxisType.Primary;
                                chartSeries1.Type = ChartSeriesType.Bar;
                                chartSeries1.Appearance.LabelAppearance.Visible = true;
                                int num10 = 0;
                                foreach (DataRow dataRow3 in table.Rows)
                                {
                                    DataTable item1 = dataSet.Tables[0];
                                    strArrays = new string[] { " EstimateStatus='", row3["EstimateStatus"].ToString(), "' and EstimateStatus='", dataRow3["EstimateStatus"].ToString(), "'" };
                                    DataRow[] dataRowArray = item1.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem.Label.Visible = false;
                                        chartSeries1.AddItem(chartSeriesItem, new ChartSeriesItem[0]);
                                        num10++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem1 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray[0]["TotalNoOfCount"]),
                                            Name = dataRowArray[0]["EstimateStatus"].ToString()
                                        };
                                        chartSeriesItem1.Label.Visible = false;
                                        string str4 = string.Concat(dataRowArray[0]["EstimateStatus"].ToString(), "\r\nTotal Count: ", dataRowArray[0]["TotalNoOfCount"].ToString());
                                        chartSeriesItem1.Label.ActiveRegion.Tooltip = str4;
                                        chartSeriesItem1.ActiveRegion.Tooltip = str4;
                                        chartSeries1.AddItem(chartSeriesItem1, new ChartSeriesItem[0]);
                                        if (dataRowArray[0]["EstimateStatus"].ToString().Length <= 13)
                                        {
                                            radChart.PlotArea.XAxis[num10].TextBlock.Text = dataRowArray[0]["EstimateStatus"].ToString();
                                            radChart.PlotArea.XAxis.Items[num10].ActiveRegion.Tooltip = dataRowArray[0]["EstimateStatus"].ToString();
                                        }
                                        else
                                        {
                                            radChart.PlotArea.XAxis[num10].TextBlock.Text = string.Concat(dataRowArray[0]["EstimateStatus"].ToString().Substring(0, 13), "...");
                                            radChart.PlotArea.XAxis.Items[num10].ActiveRegion.Tooltip = dataRowArray[0]["EstimateStatus"].ToString();
                                        }
                                        num10++;
                                    }
                                }
                                radChart.Series.Add(chartSeries1);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder14.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton8);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton9);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(dropDownList5);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder15.ToString()));
                        colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                        Palette palette = new Palette("seriesPalette", colorArray, true);
                        radChart.CustomPalettes.Add(palette);
                        radChart.SeriesPalette = "seriesPalette";
                    }
                }
                else if (dr["MasterID"].ToString() == "2")
                {
                    if (dr["GraphType"].ToString().ToLower() != "stackedbar")
                    {
                        StringBuilder stringBuilder16 = new StringBuilder();
                        StringBuilder stringBuilder17 = new StringBuilder();
                        stringBuilder16.Append("<div style='margin-top:0px;'>");
                        stringBuilder16.Append("<table style='width:99%;'>");
                        stringBuilder16.Append("<tr>");
                        stringBuilder16.Append("<td>");
                        stringBuilder16.Append("<div style='float:right'>");
                        DropDownList value5 = new DropDownList();
                        forecast _forecast4 = new forecast();
                        DataTable dataTable6 = new DataTable();
                        dataTable6 = _forecast4.SelectAllUsers(this.CompanyID);
                        foreach (DataRow row4 in dataTable6.Rows)
                        {
                            foreach (DataColumn column2 in dataTable6.Columns)
                            {
                                column2.ReadOnly = false;
                            }
                            row4["SalesPersonName"] = this.objBase.SpecialDecode(row4["SalesPersonName"].ToString());
                        }
                        value5.DataSource = dataTable6;
                        value5.DataTextField = "SalesPersonName";
                        value5.DataValueField = "userid";
                        value5.DataBind();
                        value5.Items.Insert(0, " ");
                        value5.Items[0].Text = "All";
                        value5.Items[0].Value = "-1";
                        value5.ID = string.Concat("ddlStatus4_", num5);
                        value5.AutoPostBack = true;
                        value5.Style.Add("float", "right;");
                        value5.Style.Add("margin-right", "15px;");
                        value5.Style.Add("width", "115px;margin-top:1px;");
                        value5.CssClass = "simpledropdownPopup";
                        value5.Attributes.Add("onchange", string.Concat("javascript:getstatusvalue4(this.value, ", num5, ");"));
                        stringBuilder17.Append("</div>");
                        stringBuilder17.Append("</td>");
                        stringBuilder16.Append("<td>");
                        stringBuilder16.Append("<div style='float:right'>");
                        LinkButton linkButton10 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton10.Style.Add("float", "right;margin-top:5px;");
                        if (this.ddlStatusValue4.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", this.ddlStatusValue4.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton10.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton10.OnClientClick = string.Concat(str);
                        }
                        stringBuilder17.Append("</div>");
                        stringBuilder17.Append("</td>");
                        stringBuilder16.Append("<td>");
                        stringBuilder16.Append("<div style='float:right'>");
                        LinkButton linkButton11 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton11.Style.Add("float", "right;");
                        linkButton11.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.ddlStatusValue4.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", this.ddlStatusValue4.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton11.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton11.OnClientClick = string.Concat(str);
                        }
                        stringBuilder17.Append("</div>");
                        stringBuilder17.Append("</td>");
                        stringBuilder17.Append("</tr>");
                        stringBuilder17.Append("</table>");
                        stringBuilder17.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());

                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), this.ddlStatusValue3.Value, dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            value5.SelectedValue = this.ddlStatusValue4.Value;
                        }
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews2 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "SalespersonName" };
                            DataTable table2 = dataViews2.ToTable(true, strArrays);
                            DataView dataViews3 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table3 = dataViews2.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table2.Rows.Count, 1);
                            foreach (DataRow dataRow4 in table3.Rows)
                            {
                                ChartSeries chartSeries2 = new ChartSeries(dataRow4["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (dataRow4["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries2.Name = dataRow4["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries2.Name = string.Concat(dataRow4["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries2.YAxisType = ChartYAxisType.Primary;
                                chartSeries2.Type = ChartSeriesType.Bar;
                                chartSeries2.Appearance.LabelAppearance.Visible = true;
                                int num11 = 0;
                                foreach (DataRow row5 in table2.Rows)
                                {
                                    DataTable item2 = dataSet.Tables[0];
                                    strArrays = new string[] { " EstimateStatus='", dataRow4["EstimateStatus"].ToString(), "' and SalespersonName='", row5["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray1 = item2.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray1.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem2 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem2.Label.Visible = false;
                                        chartSeries2.AddItem(chartSeriesItem2, new ChartSeriesItem[0]);
                                        num11++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem3 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray1[0]["Estimatevalue"]),
                                            Name = dataRowArray1[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem3.Label.Visible = false;
                                        strArrays = new string[] { dataRowArray1[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray1[0]["Estimatevalue"].ToString() };
                                        string str5 = string.Concat(strArrays);
                                        chartSeriesItem3.Label.ActiveRegion.Tooltip = str5;
                                        chartSeriesItem3.ActiveRegion.Tooltip = str5;
                                        chartSeries2.AddItem(chartSeriesItem3, new ChartSeriesItem[0]);
                                        if (dataRowArray1[0]["SalesPersonName"].ToString().Length <= 15)
                                        {
                                            dataRowArray1[0]["SalesPersonName"] = dataRowArray1[0]["SalesPersonName"].ToString();
                                        }
                                        else
                                        {
                                            dataRowArray1[0]["SalesPersonName"] = string.Concat(dataRowArray1[0]["SalesPersonName"].ToString().Substring(0, 15), "...");
                                        }
                                        radChart.PlotArea.XAxis[num11].TextBlock.Text = dataRowArray1[0]["SalespersonName"].ToString();
                                        num11++;
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
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder16.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton10);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton11);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(value5);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder17.ToString()));
                        radChart.DataBind();
                    }
                    else
                    {
                        StringBuilder stringBuilder18 = new StringBuilder();
                        StringBuilder stringBuilder19 = new StringBuilder();
                        stringBuilder18.Append("<div style='margin-top:0px;'>");
                        stringBuilder18.Append("<table style='width:99%;'>");
                        stringBuilder18.Append("<tr>");
                        stringBuilder18.Append("<td>");
                        stringBuilder18.Append("<div style='float:right'>");
                        DropDownList dropDownList6 = new DropDownList();
                        forecast _forecast5 = new forecast();
                        DataTable dataTable7 = new DataTable();
                        dataTable7 = _forecast5.SelectAllUsers(this.CompanyID);
                        foreach (DataRow dataRow5 in dataTable7.Rows)
                        {
                            foreach (DataColumn dataColumn2 in dataTable7.Columns)
                            {
                                dataColumn2.ReadOnly = false;
                            }
                            dataRow5["SalesPersonName"] = this.objBase.SpecialDecode(dataRow5["SalesPersonName"].ToString());
                        }
                        dropDownList6.DataSource = dataTable7;
                        dropDownList6.DataTextField = "SalesPersonName";
                        dropDownList6.DataValueField = "userid";
                        dropDownList6.DataBind();
                        dropDownList6.Items.Insert(0, " ");
                        dropDownList6.Items[0].Text = "All";
                        dropDownList6.Items[0].Value = "-1";
                        dropDownList6.ID = string.Concat("ddlStatus1_", num5);
                        dropDownList6.AutoPostBack = true;
                        dropDownList6.Style.Add("float", "right;");
                        dropDownList6.Style.Add("margin-right", "15px;");
                        dropDownList6.Style.Add("width", "115px;margin-top:1px;");
                        dropDownList6.CssClass = "simpledropdownPopup";
                        dropDownList6.Attributes.Add("onchange", string.Concat("javascript:getstatusvalue3(this.value, ", num5, ");"));
                        stringBuilder19.Append("</div>");
                        stringBuilder19.Append("</td>");
                        stringBuilder18.Append("<td>");
                        stringBuilder18.Append("<div style='float:right'>");
                        LinkButton linkButton12 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton12.Style.Add("float", "right;margin-top:5px;");
                        if (this.ddlStatusValue3.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue3.Value, "','", this.ddlStatusValue3.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton12.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue3.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton12.OnClientClick = string.Concat(str);
                        }
                        stringBuilder19.Append("</div>");
                        stringBuilder19.Append("</td>");
                        stringBuilder18.Append("<td>");
                        stringBuilder18.Append("<div style='float:right'>");
                        LinkButton linkButton13 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton13.Style.Add("float", "right;");
                        linkButton13.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.ddlStatusValue3.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue3.Value, "','", this.ddlStatusValue3.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton13.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatus('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue3.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton13.OnClientClick = string.Concat(str);
                        }
                        stringBuilder19.Append("</div>");
                        stringBuilder19.Append("</td>");
                        stringBuilder19.Append("</tr>");
                        stringBuilder19.Append("</table>");
                        stringBuilder19.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_SalesPersonByModule_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), this.ddlStatusValue3.Value, dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            dropDownList6.SelectedValue = this.ddlStatusValue3.Value;
                        }
                        if (dataSet.Tables.Count > 0)
                        {
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                DataView dataViews4 = new DataView(dataSet.Tables[0]);
                                strArrays = new string[] { "SalespersonName" };
                                DataTable table4 = dataViews4.ToTable(true, strArrays);
                                DataView dataViews5 = new DataView(dataSet.Tables[0]);
                                strArrays = new string[] { "EstimateStatus" };
                                DataTable table5 = dataViews4.ToTable(true, strArrays);
                                radChart.PlotArea.XAxis.AddRange(1, (double)table4.Rows.Count, 1);
                                foreach (DataRow row6 in table5.Rows)
                                {
                                    ChartSeries chartSeries3 = new ChartSeries(row6["EstimateStatus"].ToString(), ChartSeriesType.StackedBar);
                                    if (row6["EstimateStatus"].ToString().Length <= 15)
                                    {
                                        chartSeries3.Name = row6["EstimateStatus"].ToString();
                                    }
                                    else
                                    {
                                        chartSeries3.Name = string.Concat(row6["EstimateStatus"].ToString().Substring(0, 15), "...");
                                    }
                                    chartSeries3.YAxisType = ChartYAxisType.Primary;
                                    chartSeries3.Type = ChartSeriesType.StackedBar;
                                    chartSeries3.Appearance.LabelAppearance.Visible = true;
                                    int num12 = 0;
                                    foreach (DataRow dataRow6 in table4.Rows)
                                    {
                                        DataTable item3 = dataSet.Tables[0];
                                        strArrays = new string[] { " EstimateStatus='", row6["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow6["SalespersonName"].ToString(), "'" };
                                        DataRow[] dataRowArray2 = item3.Select(string.Concat(strArrays));
                                        if ((int)dataRowArray2.Length <= 0)
                                        {
                                            ChartSeriesItem chartSeriesItem4 = new ChartSeriesItem(0)
                                            {
                                                Name = "wew"
                                            };
                                            chartSeriesItem4.Label.Visible = false;
                                            chartSeries3.AddItem(chartSeriesItem4, new ChartSeriesItem[0]);
                                            num12++;
                                        }
                                        else
                                        {
                                            ChartSeriesItem chartSeriesItem5 = new ChartSeriesItem()
                                            {
                                                YValue = Convert.ToDouble(dataRowArray2[0]["Estimatevalue"]),
                                                Name = dataRowArray2[0]["SalespersonName"].ToString()
                                            };
                                            chartSeriesItem5.Label.Visible = false;
                                            strArrays = new string[] { dataRowArray2[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray2[0]["Estimatevalue"].ToString() };
                                            string str6 = string.Concat(strArrays);
                                            chartSeriesItem5.Label.ActiveRegion.Tooltip = str6;
                                            chartSeriesItem5.ActiveRegion.Tooltip = str6;
                                            chartSeries3.AddItem(chartSeriesItem5, new ChartSeriesItem[0]);
                                            if (dataRowArray2[0]["SalesPersonName"].ToString().Length <= 15)
                                            {
                                                dataRowArray2[0]["SalesPersonName"] = dataRowArray2[0]["SalesPersonName"].ToString();
                                            }
                                            else
                                            {
                                                dataRowArray2[0]["SalesPersonName"] = string.Concat(dataRowArray2[0]["SalesPersonName"].ToString().Substring(0, 15), "...");
                                            }
                                            radChart.PlotArea.XAxis[num12].TextBlock.Text = dataRowArray2[0]["SalespersonName"].ToString();
                                            num12++;
                                        }
                                    }
                                    radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                    radChart.Series.Add(chartSeries3);
                                    radChart.PlotArea.XAxis.AutoScale = false;
                                    try
                                    {
                                        chartSeries3.PlotArea.YAxis.Appearance.CustomFormat = string.Concat(this.objCommon.GetCurrencyinRequiredFormate("", true), " #");
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder18.ToString()));
                            if (dr["ShowPrint"].ToString().ToLower() == "true")
                            {
                                radDock.ContentContainer.Controls.Add(linkButton12);
                            }
                            if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                            {
                                radDock.ContentContainer.Controls.Add(linkButton13);
                            }
                            if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                            {
                                radDock.ContentContainer.Controls.Add(dropDownList6);
                            }
                            radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder19.ToString()));
                        }
                        radChart.DataBind();
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette1 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette1);
                    radChart.SeriesPalette = "seriesPalette";
                }
                else if (dr["MasterID"].ToString() == "3")
                {
                    StringBuilder stringBuilder20 = new StringBuilder();
                    StringBuilder stringBuilder21 = new StringBuilder();
                    stringBuilder20.Append("<div style='margin-top:0px;'>");
                    stringBuilder20.Append("<table style='width:99%;'>");
                    stringBuilder20.Append("<tr>");
                    stringBuilder20.Append("<td>");
                    stringBuilder20.Append("<div style='float:right'>");
                    LinkButton linkButton14 = new LinkButton()
                    {
                        Text = "Print",
                        ID = string.Concat("LnkPrint1_", num5)
                    };
                    linkButton14.Style.Add("float", "right;margin-top:5px;");
                    str = new object[] { "Javascript:JobInvoiceByDueDate('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["ModuleName"].ToString(), "','", str3, "','", dr["NoOfRecords"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                    linkButton14.OnClientClick = string.Concat(str);
                    stringBuilder21.Append("</div>");
                    stringBuilder21.Append("</td>");
                    stringBuilder20.Append("<td>");
                    stringBuilder20.Append("<div style='float:right'>");
                    LinkButton linkButton15 = new LinkButton()
                    {
                        Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                        ID = string.Concat("LnkFullscreen1_", num5)
                    };
                    linkButton15.Style.Add("float", "right;");
                    linkButton15.Style.Add("margin-right", "15px;margin-top:5px;");
                    str = new object[] { "Javascript:JobInvoiceByDueDate('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["ModuleName"].ToString(), "','", str3, "','", dr["NoOfRecords"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                    linkButton15.OnClientClick = string.Concat(str);
                    stringBuilder21.Append("</div>");
                    stringBuilder21.Append("</td>");
                    stringBuilder21.Append("</tr>");
                    stringBuilder21.Append("</table>");
                    stringBuilder21.Append("</div>");
                    dataSet = dashboardestimate.Dashboard_Select_ByDueDate_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), str3, Convert.ToInt32(dr["NoOfRecords"]), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                        for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                        {
                            radChart.PlotArea.XAxis[num7].TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[j]["StatusName"].ToString());
                            radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[j]["StatusName"].ToString());
                            num7++;
                        }
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder20.ToString()));
                    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton14);
                    }
                    if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                    {
                        radDock.ContentContainer.Controls.Add(linkButton15);
                    }
                    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder21.ToString()));
                    ChartSeries chartSeries4 = new ChartSeries()
                    {
                        Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), dr["GraphType"].ToString())
                    };
                    chartSeries4.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                    chartSeries4.DataYColumn = "TotalCount";
                    if (dr["GraphType"].ToString().ToLower() == "pie")
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
                    if (dr["GraphType"].ToString().ToLower() != "line")
                    {
                        int num13 = 0;
                        foreach (ChartSeriesItem item4 in radChart.Series[0].Items)
                        {
                            int num14 = num13;
                            num13 = num14 + 1;
                            item4.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num14));
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
                else if (dr["MasterID"].ToString() == "8")
                {
                    if (dr["GraphType"].ToString().ToLower() != "stackedbar")
                    {
                        StringBuilder stringBuilder22 = new StringBuilder();
                        StringBuilder stringBuilder23 = new StringBuilder();
                        stringBuilder22.Append("<div style='margin-top:0px;'>");
                        stringBuilder22.Append("<table style='width:99%;'>");
                        stringBuilder22.Append("<tr>");
                        stringBuilder22.Append("<td>");
                        stringBuilder22.Append("<div style='float:right'>");
                        DropDownList value6 = new DropDownList();
                        forecast _forecast6 = new forecast();
                        DataTable dataTable8 = new DataTable();
                        dataTable8 = _forecast6.SelectAllUsers(this.CompanyID);
                        foreach (DataRow row7 in dataTable8.Rows)
                        {
                            foreach (DataColumn column3 in dataTable8.Columns)
                            {
                                column3.ReadOnly = false;
                            }
                            row7["SalesPersonName"] = this.objBase.SpecialDecode(row7["SalesPersonName"].ToString());
                        }
                        value6.DataSource = dataTable8;
                        value6.DataTextField = "SalesPersonName";
                        value6.DataValueField = "userid";
                        value6.DataBind();
                        value6.Items.Insert(0, " ");
                        value6.Items[0].Text = "All";
                        value6.Items[0].Value = "-1";
                        value6.ID = string.Concat("ddlStatus1_", num5);
                        value6.AutoPostBack = true;
                        value6.Style.Add("float", "right;");
                        value6.Style.Add("margin-right", "15px;");
                        value6.Style.Add("width", "115px;margin-top:1px;");
                        value6.CssClass = "simpledropdownPopup";
                        value6.Attributes.Add("onchange", string.Concat("javascript:getSalesID1(this.value, ", num5, ");"));
                        stringBuilder23.Append("</div>");
                        stringBuilder23.Append("</td>");
                        stringBuilder22.Append("<td>");
                        stringBuilder22.Append("<div style='float:right'>");
                        LinkButton linkButton16 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton16.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdnsalesID81.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnsalesID81.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton16.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton16.OnClientClick = string.Concat(str);
                        }
                        stringBuilder23.Append("</div>");
                        stringBuilder23.Append("</td>");
                        stringBuilder22.Append("<td>");
                        stringBuilder22.Append("<div style='float:right'>");
                        LinkButton linkButton17 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton17.Style.Add("float", "right;");
                        linkButton17.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdnsalesID81.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnsalesID81.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton17.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton17.OnClientClick = string.Concat(str);
                        }
                        stringBuilder23.Append("</div>");
                        stringBuilder23.Append("</td>");
                        stringBuilder23.Append("</tr>");
                        stringBuilder23.Append("</table>");
                        stringBuilder23.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), this.hdnsalesID81.Value, dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            value6.SelectedValue = this.hdnsalesID81.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews6 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "SalespersonName" };
                            DataTable table6 = dataViews6.ToTable(true, strArrays);
                            DataView dataViews7 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table7 = dataViews6.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table6.Rows.Count, 1);
                            foreach (DataRow dataRow7 in table7.Rows)
                            {
                                ChartSeries chartSeries5 = new ChartSeries(dataRow7["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (dataRow7["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries5.Name = dataRow7["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries5.Name = string.Concat(dataRow7["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries5.YAxisType = ChartYAxisType.Primary;
                                chartSeries5.Type = ChartSeriesType.Bar;
                                chartSeries5.Appearance.LabelAppearance.Visible = true;
                                int num15 = 0;
                                foreach (DataRow row8 in table6.Rows)
                                {
                                    DataTable item5 = dataSet.Tables[0];
                                    strArrays = new string[] { " EstimateStatus='", dataRow7["EstimateStatus"].ToString(), "' and SalespersonName='", row8["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray3 = item5.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray3.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem6 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem6.Label.Visible = false;
                                        chartSeries5.AddItem(chartSeriesItem6, new ChartSeriesItem[0]);
                                        num15++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem7 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray3[0]["TotalCount"]),
                                            Name = dataRowArray3[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem7.Label.Visible = false;
                                        strArrays = new string[] { dataRowArray3[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray3[0]["TotalCount"].ToString() };
                                        string str7 = string.Concat(strArrays);
                                        chartSeriesItem7.Label.ActiveRegion.Tooltip = str7;
                                        chartSeriesItem7.ActiveRegion.Tooltip = str7;
                                        chartSeries5.AddItem(chartSeriesItem7, new ChartSeriesItem[0]);
                                        if (dataRowArray3[0]["SalesPersonName"].ToString().Length <= 15)
                                        {
                                            dataRowArray3[0]["SalesPersonName"] = dataRowArray3[0]["SalesPersonName"].ToString();
                                        }
                                        else
                                        {
                                            dataRowArray3[0]["SalesPersonName"] = string.Concat(dataRowArray3[0]["SalesPersonName"].ToString().Substring(0, 15), "...");
                                        }
                                        radChart.PlotArea.XAxis[num15].TextBlock.Text = dataRowArray3[0]["SalespersonName"].ToString();
                                        num15++;
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
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder22.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton16);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton17);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(value6);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder23.ToString()));
                        radChart.DataBind();
                    }
                    else
                    {
                        StringBuilder stringBuilder24 = new StringBuilder();
                        StringBuilder stringBuilder25 = new StringBuilder();
                        stringBuilder24.Append("<div style='margin-top:0px;'>");
                        stringBuilder24.Append("<table style='width:99%;'>");
                        stringBuilder24.Append("<tr>");
                        stringBuilder24.Append("<td>");
                        stringBuilder24.Append("<div style='float:right'>");
                        DropDownList dropDownList7 = new DropDownList();
                        forecast _forecast7 = new forecast();
                        DataTable dataTable9 = new DataTable();
                        dataTable9 = _forecast7.SelectAllUsers(this.CompanyID);
                        foreach (DataRow dataRow8 in dataTable9.Rows)
                        {
                            foreach (DataColumn dataColumn3 in dataTable9.Columns)
                            {
                                dataColumn3.ReadOnly = false;
                            }
                            dataRow8["SalesPersonName"] = this.objBase.SpecialDecode(dataRow8["SalesPersonName"].ToString());
                        }
                        dropDownList7.DataSource = dataTable9;
                        dropDownList7.DataTextField = "SalesPersonName";
                        dropDownList7.DataValueField = "userid";
                        dropDownList7.DataBind();
                        dropDownList7.Items.Insert(0, " ");
                        dropDownList7.Items[0].Text = "All";
                        dropDownList7.Items[0].Value = "-1";
                        dropDownList7.ID = string.Concat("ddlsales_", num5);
                        dropDownList7.AutoPostBack = true;
                        dropDownList7.Style.Add("float", "right;");
                        dropDownList7.Style.Add("margin-right", "15px;");
                        dropDownList7.Style.Add("width", "115px;margin-top:1px;");
                        dropDownList7.CssClass = "simpledropdownPopup";
                        dropDownList7.Attributes.Add("onchange", string.Concat("javascript:getSalesID(this.value, ", num5, ");"));
                        stringBuilder25.Append("</div>");
                        stringBuilder25.Append("</td>");
                        stringBuilder24.Append("<td>");
                        stringBuilder24.Append("<div style='float:right'>");
                        LinkButton linkButton18 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton18.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdnsalesID8.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnsalesID8.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton18.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton18.OnClientClick = string.Concat(str);
                        }
                        stringBuilder25.Append("</div>");
                        stringBuilder25.Append("</td>");
                        stringBuilder24.Append("<td>");
                        stringBuilder24.Append("<div style='float:right'>");
                        LinkButton linkButton19 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton19.Style.Add("float", "right;");
                        linkButton19.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdnsalesID8.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnsalesID8.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton19.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton19.OnClientClick = string.Concat(str);
                        }
                        stringBuilder25.Append("</div>");
                        stringBuilder25.Append("</td>");
                        stringBuilder25.Append("</tr>");
                        stringBuilder25.Append("</table>");
                        stringBuilder25.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(Convert.ToInt64(this.Session["CompanyId"]), this.hdnsalesID8.Value, dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()), dr["DateType"].ToString(), dr["IsCalendarYear"].ToString(), dr["FromDate"].ToString(), dr["Todate"].ToString());
                            dropDownList7.SelectedValue = this.hdnsalesID8.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews8 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "SalespersonName" };
                            DataTable table8 = dataViews8.ToTable(true, strArrays);
                            DataView dataViews9 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table9 = dataViews8.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table8.Rows.Count, 1);
                            foreach (DataRow row9 in table9.Rows)
                            {
                                ChartSeries chartSeries6 = new ChartSeries(row9["EstimateStatus"].ToString(), ChartSeriesType.StackedBar);
                                if (row9["EstimateStatus"].ToString().Length <= 15)
                                {
                                    chartSeries6.Name = row9["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries6.Name = string.Concat(row9["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries6.YAxisType = ChartYAxisType.Primary;
                                chartSeries6.Type = ChartSeriesType.StackedBar;
                                chartSeries6.Appearance.LabelAppearance.Visible = true;
                                int num16 = 0;
                                foreach (DataRow dataRow9 in table8.Rows)
                                {
                                    DataTable item6 = dataSet.Tables[0];
                                    strArrays = new string[] { " EstimateStatus='", row9["EstimateStatus"].ToString(), "' and SalespersonName='", dataRow9["SalespersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray4 = item6.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray4.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem8 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem8.Label.Visible = false;
                                        chartSeries6.AddItem(chartSeriesItem8, new ChartSeriesItem[0]);
                                        num16++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem9 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray4[0]["TotalCount"]),
                                            Name = dataRowArray4[0]["SalespersonName"].ToString()
                                        };
                                        chartSeriesItem9.Label.Visible = false;
                                        strArrays = new string[] { dataRowArray4[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray4[0]["TotalCount"].ToString() };
                                        string str8 = string.Concat(strArrays);
                                        chartSeriesItem9.Label.ActiveRegion.Tooltip = str8;
                                        chartSeriesItem9.ActiveRegion.Tooltip = str8;
                                        chartSeries6.AddItem(chartSeriesItem9, new ChartSeriesItem[0]);
                                        if (dataRowArray4[0]["SalesPersonName"].ToString().Length <= 15)
                                        {
                                            dataRowArray4[0]["SalesPersonName"] = dataRowArray4[0]["SalesPersonName"].ToString();
                                        }
                                        else
                                        {
                                            dataRowArray4[0]["SalesPersonName"] = string.Concat(dataRowArray4[0]["SalesPersonName"].ToString().Substring(0, 15), "...");
                                        }
                                        radChart.PlotArea.XAxis[num16].TextBlock.Text = dataRowArray4[0]["SalespersonName"].ToString();
                                        num16++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(chartSeries6);
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
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder24.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton18);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton19);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(dropDownList7);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder25.ToString()));
                        radChart.DataBind();
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette3 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette3);
                    radChart.SeriesPalette = "seriesPalette";
                }
                if (dr["MasterID"].ToString() == "9")
                {
                    string str9 = dr["QuarterType"].ToString();
                    if (dr["GraphType"].ToString().ToLower() == "stackedbar")
                    {
                        StringBuilder stringBuilder26 = new StringBuilder();
                        StringBuilder stringBuilder27 = new StringBuilder();
                        stringBuilder26.Append("<div style='margin-top:0px;'>");
                        stringBuilder26.Append("<table style='width:99%;'>");
                        stringBuilder26.Append("<tr>");
                        stringBuilder26.Append("<td>");
                        stringBuilder26.Append("<div style='float:right'>");
                        DropDownList value7 = new DropDownList();
                        forecast _forecast8 = new forecast();
                        DataTable dataTable10 = new DataTable();
                        dataTable10 = _forecast8.SelectAllUsers(this.CompanyID);
                        foreach (DataRow row10 in dataTable10.Rows)
                        {
                            foreach (DataColumn column4 in dataTable10.Columns)
                            {
                                column4.ReadOnly = false;
                            }
                            row10["SalesPersonName"] = this.objBase.SpecialDecode(row10["SalesPersonName"].ToString());
                        }
                        value7.DataSource = dataTable10;
                        value7.DataTextField = "SalesPersonName";
                        value7.DataValueField = "userid";
                        value7.DataBind();
                        value7.Items.Insert(0, " ");
                        value7.Items[0].Text = "---Select---";
                        value7.Items[0].Value = "0";
                        value7.ID = string.Concat("ddlStatusforeacst_", num5);
                        value7.AutoPostBack = true;
                        value7.Style.Add("float", "right;");
                        value7.Style.Add("margin-right", "15px;");
                        value7.Style.Add("width", "115px;margin-top:1px;");
                        value7.CssClass = "simpledropdownPopup";
                        value7.Attributes.Add("onchange", string.Concat("javascript:getSalesidforecast(this.value, ", num5, ");"));
                        stringBuilder27.Append("</div>");
                        stringBuilder27.Append("</td>");
                        stringBuilder26.Append("<td>");
                        stringBuilder26.Append("<div style='float:right'>");
                        LinkButton linkButton20 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton20.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdsalesForecast.Value != "")
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", this.hdsalesForecast.Value, "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton20.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton20.OnClientClick = string.Concat(str);
                        }
                        stringBuilder27.Append("</div>");
                        stringBuilder27.Append("</td>");
                        stringBuilder26.Append("<td>");
                        stringBuilder26.Append("<div style='float:right'>");
                        LinkButton linkButton21 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton21.Style.Add("float", "right;");
                        linkButton21.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdsalesForecast.Value != "")
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnsalesID81.Value, "','", this.hdsalesForecast.Value, "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton21.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnsalesID81.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton21.OnClientClick = string.Concat(str);
                        }
                        stringBuilder27.Append("</div>");
                        stringBuilder27.Append("</td>");
                        stringBuilder27.Append("</tr>");
                        stringBuilder27.Append("</table>");
                        stringBuilder27.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = dashboardestimate.Dashboard_Target_Actual_Date_Select(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Target_Actual_Date_Select(Convert.ToInt64(this.Session["CompanyId"]), this.hdsalesForecast.Value, str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                            value7.SelectedValue = this.hdsalesForecast.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            Hashtable hashtables = new Hashtable();
                            int num17 = 0;
                            foreach (DataRow dataRow10 in dataSet.Tables[0].Rows)
                            {
                                if (hashtables.ContainsKey(dataRow10["Username"].ToString().Trim()))
                                {
                                    continue;
                                }
                                num17++;
                                hashtables.Add(dataRow10["Username"].ToString().Trim(), num17);
                            }
                            radChart.PlotArea.XAxis.AddRange(1, (double)hashtables.Count, 1);
                            for (int k = 1; k <= hashtables.Count; k++)
                            {
                                int num18 = 0;
                                object key = null;
                                foreach (DictionaryEntry hashtable in hashtables)
                                {
                                    if (hashtable.Value.ToString() != k.ToString())
                                    {
                                        continue;
                                    }
                                    key = hashtable.Key;
                                    num18 = k;
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
                            foreach (DataRow row11 in dataSet.Tables[0].Rows)
                            {
                                ChartSeries chartSeries7 = new ChartSeries();
                                if (row11["ActualValue"].ToString().Length <= 8)
                                {
                                    chartSeries7.Name = "Actual Amount";
                                }
                                else
                                {
                                    chartSeries7.Name = "Actual Amount";
                                }
                                chartSeries7.YAxisType = ChartYAxisType.Primary;
                                chartSeries7.Type = ChartSeriesType.StackedBar;
                                chartSeries7.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" ActualValue='", row11["ActualValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem10 = new ChartSeriesItem(Convert.ToDouble(hashtables[row11["Username"].ToString().Trim()]), Convert.ToDouble(row11["ActualValue"]))
                                {
                                    Name = row11["Username"].ToString()
                                };
                                chartSeriesItem10.Label.Visible = false;
                                strArrays = new string[] { row11["Username"].ToString(), "\r\nActual Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", row11["ActualValue"].ToString() };
                                string str10 = string.Concat(strArrays);
                                chartSeriesItem10.Label.ActiveRegion.Tooltip = str10;
                                chartSeriesItem10.ActiveRegion.Tooltip = str10;
                                chartSeries7.AddItem(chartSeriesItem10, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries7);
                                ChartSeries chartSeries8 = new ChartSeries();
                                if (row11["TargetValue"].ToString().Length <= 8)
                                {
                                    chartSeries8.Name = "Target Amount";
                                }
                                else
                                {
                                    chartSeries8.Name = "Target Amount";
                                }
                                chartSeries8.YAxisType = ChartYAxisType.Primary;
                                chartSeries8.Type = ChartSeriesType.StackedBar;
                                chartSeries8.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" TargetValue='", row11["TargetValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem11 = new ChartSeriesItem(Convert.ToDouble(hashtables[row11["Username"].ToString().Trim()]), Convert.ToDouble(row11["TargetValue"]))
                                {
                                    Name = row11["Username"].ToString()
                                };
                                chartSeriesItem11.Label.Visible = false;
                                strArrays = new string[] { row11["Username"].ToString(), "\r\nTarget Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", row11["TargetValue"].ToString() };
                                str10 = string.Concat(strArrays);
                                chartSeriesItem11.Label.ActiveRegion.Tooltip = str10;
                                chartSeriesItem11.ActiveRegion.Tooltip = str10;
                                chartSeries8.AddItem(chartSeriesItem11, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries8);
                            }
                            radChart.DataBind();
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder26.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton20);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton21);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true" && dr["ModuleName"].ToString().ToLower() != "company")
                        {
                            radDock.ContentContainer.Controls.Add(value7);
                        }
                        try
                        {
                            radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                        }
                        catch
                        {
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder27.ToString()));
                    }
                    else if (dr["GraphType"].ToString().ToLower() != "bar")
                    {
                        dataSet = (dr["ModuleName"].ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_SelectPie_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())) : dashboardestimate.Dashboard_Target_Actual_Date_SelectPie_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())));
                        if (dataSet.Tables.Count > 0)
                        {
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                                for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
                                {
                                    if (dataSet.Tables[0].Rows[l]["ValueType"].ToString().Length <= 15)
                                    {
                                        radChart.PlotArea.XAxis[num7].TextBlock.Text = dataSet.Tables[0].Rows[l]["ValueType"].ToString();
                                        radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = dataSet.Tables[0].Rows[l]["ValueType"].ToString();
                                        radChart.Legend.TextBlock.Text = dataSet.Tables[0].Rows[l]["ValueType"].ToString();
                                    }
                                    else
                                    {
                                        radChart.PlotArea.XAxis[num7].TextBlock.Text = string.Concat(dataSet.Tables[0].Rows[l]["ValueType"].ToString().Substring(0, 15), "...");
                                        radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = dataSet.Tables[0].Rows[l]["ValueType"].ToString();
                                        radChart.Legend.TextBlock.Text = dataSet.Tables[0].Rows[l]["ValueType"].ToString();
                                    }
                                    num7++;
                                    radChart.ChartTitle.TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[l]["Username"].ToString());
                                }
                            }
                            radChart.ChartTitle.Visible = true;
                            radChart.ChartTitle.TextBlock.Appearance.TextProperties.Color = Color.Black;
                            radChart.ChartTitle.TextBlock.Appearance.TextProperties.Font = new Font("Verdana", 10f, FontStyle.Bold);
                        }
                        ChartSeries chartSeries9 = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), dr["GraphType"].ToString())
                        };
                        chartSeries9.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries9.DataYColumn = "Amount";
                        try
                        {
                            chartSeries9.DefaultLabelValue = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #Y");
                            chartSeries9.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                        radChart.Series.Add(chartSeries9);
                        radChart.DataSource = dataSet;
                        radChart.DataBind();
                        radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = true;
                        radChart.Legend.Visible = true;
                        if (dr["GraphType"].ToString().ToLower() != "pie")
                        {
                            colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                            Palette palette4 = new Palette("seriesPalette", colorArray, true);
                            radChart.CustomPalettes.Add(palette4);
                            radChart.SeriesPalette = "seriesPalette";
                        }
                        else
                        {
                            int num19 = 0;
                            foreach (ChartSeriesItem item7 in radChart.Series[0].Items)
                            {
                                int num20 = num19;
                                num19 = num20 + 1;
                                item7.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num20));
                                item7.Appearance.FillStyle.FillType = FillType.Solid;
                            }
                        }
                    }
                    else
                    {
                        StringBuilder stringBuilder28 = new StringBuilder();
                        StringBuilder stringBuilder29 = new StringBuilder();
                        stringBuilder28.Append("<div style='margin-top:0px;'>");
                        stringBuilder28.Append("<table style='width:99%;'>");
                        stringBuilder28.Append("<tr>");
                        stringBuilder28.Append("<td>");
                        stringBuilder28.Append("<div style='float:right'>");
                        DropDownList dropDownList8 = new DropDownList();
                        forecast _forecast9 = new forecast();
                        DataTable dataTable11 = new DataTable();
                        dataTable11 = _forecast9.SelectAllUsers(this.CompanyID);
                        foreach (DataRow dataRow11 in dataTable11.Rows)
                        {
                            foreach (DataColumn dataColumn4 in dataTable11.Columns)
                            {
                                dataColumn4.ReadOnly = false;
                            }
                            dataRow11["SalesPersonName"] = this.objBase.SpecialDecode(dataRow11["SalesPersonName"].ToString());
                        }
                        dropDownList8.DataSource = dataTable11;
                        dropDownList8.DataTextField = "SalesPersonName";
                        dropDownList8.DataValueField = "userid";
                        dropDownList8.DataBind();
                        dropDownList8.Items.Insert(0, " ");
                        dropDownList8.Items[0].Text = "---Select---";
                        dropDownList8.Items[0].Value = "0";
                        dropDownList8.ID = string.Concat("ddlStatusforeacst_", num5);
                        dropDownList8.AutoPostBack = true;
                        dropDownList8.Style.Add("float", "right;");
                        dropDownList8.Style.Add("margin-right", "15px;");
                        dropDownList8.Style.Add("width", "115px;margin-top:1px;");
                        dropDownList8.CssClass = "simpledropdownPopup";
                        dropDownList8.Attributes.Add("onchange", string.Concat("javascript:getSalesidforecast1(this.value, ", num5, ");"));
                        stringBuilder29.Append("</div>");
                        stringBuilder29.Append("</td>");
                        stringBuilder28.Append("<td>");
                        stringBuilder28.Append("<div style='float:right'>");
                        LinkButton linkButton22 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton22.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdsalesForecast1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", this.hdsalesForecast1.Value, "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton22.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue4.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton22.OnClientClick = string.Concat(str);
                        }
                        stringBuilder29.Append("</div>");
                        stringBuilder29.Append("</td>");
                        stringBuilder28.Append("<td>");
                        stringBuilder28.Append("<div style='float:right'>");
                        LinkButton linkButton23 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton23.Style.Add("float", "right;");
                        linkButton23.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdsalesForecast1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnsalesID81.Value, "','", this.hdsalesForecast1.Value, "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton23.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintForecast('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.hdnsalesID81.Value, "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["EstimateType"].ToString(), "','", dr["QuarterType"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["Status"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton23.OnClientClick = string.Concat(str);
                        }
                        stringBuilder29.Append("</div>");
                        stringBuilder29.Append("</td>");
                        stringBuilder29.Append("</tr>");
                        stringBuilder29.Append("</table>");
                        stringBuilder29.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = (dr["ModuleName"].ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())) : dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())));
                        }
                        else
                        {
                            dataSet = (dr["ModuleName"].ToString().ToLower() != "company" ? dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), this.hdsalesForecast1.Value, str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())) : dashboardestimate.Dashboard_Target_Actual_Date_Select_SplitItem(Convert.ToInt64(this.Session["CompanyId"]), "-1", str9, dr["EstimateType"].ToString(), dr["ModuleName"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())));
                            dropDownList8.SelectedValue = this.hdsalesForecast1.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            Hashtable hashtables1 = new Hashtable();
                            int num21 = 0;
                            foreach (DataRow row12 in dataSet.Tables[0].Rows)
                            {
                                if (hashtables1.ContainsKey(row12["Username"].ToString().Trim()))
                                {
                                    continue;
                                }
                                num21++;
                                hashtables1.Add(row12["Username"].ToString().Trim(), num21);
                            }
                            radChart.PlotArea.XAxis.AddRange(1, (double)hashtables1.Count, 1);
                            for (int m = 1; m <= hashtables1.Count; m++)
                            {
                                int num22 = 0;
                                object key1 = null;
                                foreach (DictionaryEntry dictionaryEntry in hashtables1)
                                {
                                    if (dictionaryEntry.Value.ToString() != m.ToString())
                                    {
                                        continue;
                                    }
                                    key1 = dictionaryEntry.Key;
                                    num22 = m;
                                    break;
                                }
                                if (key1.ToString().Length <= 15)
                                {
                                    radChart.PlotArea.XAxis[num22 - 1].TextBlock.Text = key1.ToString();
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num22 - 1].TextBlock.Text = string.Concat(key1.ToString().Substring(0, 15), "...");
                                }
                                radChart.PlotArea.XAxis.Items[num22 - 1].ActiveRegion.Tooltip = key1.ToString();
                                radChart.PlotArea.XAxis.DataLabelsColumn = "Username";
                            }
                            num21 = 0;
                            foreach (DataRow dataRow12 in dataSet.Tables[0].Rows)
                            {
                                ChartSeries chartSeries10 = new ChartSeries();
                                if (dataRow12["TargetValue"].ToString().Length <= 8)
                                {
                                    chartSeries10.Name = "Target Amount";
                                }
                                else
                                {
                                    chartSeries10.Name = "Target Amount";
                                }
                                chartSeries10.YAxisType = ChartYAxisType.Primary;
                                chartSeries10.Type = ChartSeriesType.Bar;
                                chartSeries10.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" TargetValue='", dataRow12["TargetValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem12 = new ChartSeriesItem(Convert.ToDouble(hashtables1[dataRow12["Username"].ToString().Trim()]), Convert.ToDouble(dataRow12["TargetValue"]))
                                {
                                    Name = dataRow12["Username"].ToString()
                                };
                                chartSeriesItem12.Label.Visible = false;
                                strArrays = new string[] { dataRow12["Username"].ToString(), "\r\nTarget Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow12["TargetValue"].ToString() };
                                string str11 = string.Concat(strArrays);
                                chartSeriesItem12.Label.ActiveRegion.Tooltip = str11;
                                chartSeriesItem12.ActiveRegion.Tooltip = str11;
                                chartSeries10.AddItem(chartSeriesItem12, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries10);
                                ChartSeries chartSeries11 = new ChartSeries();
                                if (dataRow12["ActualValue"].ToString().Length <= 8)
                                {
                                    chartSeries11.Name = "Actual Amount";
                                }
                                else
                                {
                                    chartSeries11.Name = "Actual Amount";
                                }
                                chartSeries11.YAxisType = ChartYAxisType.Primary;
                                chartSeries11.Type = ChartSeriesType.Bar;
                                chartSeries11.Appearance.LabelAppearance.Visible = true;
                                dataSet.Tables[0].Select(string.Concat(" ActualValue='", dataRow12["ActualValue"].ToString(), "'"));
                                ChartSeriesItem chartSeriesItem13 = new ChartSeriesItem(Convert.ToDouble(hashtables1[dataRow12["Username"].ToString().Trim()]), Convert.ToDouble(dataRow12["ActualValue"]))
                                {
                                    Name = dataRow12["Username"].ToString()
                                };
                                chartSeriesItem13.Label.Visible = false;
                                strArrays = new string[] { dataRow12["Username"].ToString(), "\r\nActual Amount (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRow12["ActualValue"].ToString() };
                                str11 = string.Concat(strArrays);
                                chartSeriesItem13.Label.ActiveRegion.Tooltip = str11;
                                chartSeriesItem13.ActiveRegion.Tooltip = str11;
                                chartSeries11.AddItem(chartSeriesItem13, new ChartSeriesItem[0]);
                                radChart.Series.Add(chartSeries11);
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
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder28.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton22);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton23);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true" && dr["ModuleName"].ToString().ToLower() != "company")
                        {
                            radDock.ContentContainer.Controls.Add(dropDownList8);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder29.ToString()));
                    }
                }
                if (dr["MasterID"].ToString() == "10")
                {
                    if (dr["GraphType"].ToString().ToLower() != "bar")
                    {
                        StringBuilder stringBuilder30 = new StringBuilder();
                        StringBuilder stringBuilder31 = new StringBuilder();
                        stringBuilder30.Append("<div style='margin-top:0px;'>");
                        stringBuilder30.Append("<table style='width:99%;'>");
                        stringBuilder30.Append("<tr>");
                        stringBuilder30.Append("<td>");
                        stringBuilder30.Append("<div style='float:right'>");
                        DropDownList value8 = new DropDownList();
                        forecast _forecast10 = new forecast();
                        DataTable dataTable12 = new DataTable();
                        dataTable12 = _forecast10.SelectAllUsers(this.CompanyID);
                        foreach (DataRow row13 in dataTable12.Rows)
                        {
                            foreach (DataColumn column5 in dataTable12.Columns)
                            {
                                column5.ReadOnly = false;
                            }
                            row13["SalesPersonName"] = this.objBase.SpecialDecode(row13["SalesPersonName"].ToString());
                        }
                        value8.DataSource = dataTable12;
                        value8.DataTextField = "SalesPersonName";
                        value8.DataValueField = "userid";
                        value8.DataBind();
                        value8.Items.Insert(0, " ");
                        value8.Items[0].Text = "All";
                        value8.Items[0].Value = "-1";
                        value8.ID = string.Concat("ddlProsales1_", num5);
                        value8.AutoPostBack = true;
                        value8.Style.Add("float", "right;");
                        value8.Style.Add("margin-right", "15px;");
                        value8.Style.Add("width", "115px;margin-top:1px;");
                        value8.CssClass = "simpledropdownPopup";
                        value8.Attributes.Add("onchange", string.Concat("javascript:getProSalesID1(this.value, ", num5, ");"));
                        stringBuilder31.Append("</div>");
                        stringBuilder31.Append("</td>");
                        stringBuilder30.Append("<td>");
                        stringBuilder30.Append("<div style='float:right'>");
                        LinkButton linkButton24 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton24.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdnProSales1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnProSales1.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton24.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton24.OnClientClick = string.Concat(str);
                        }
                        stringBuilder31.Append("</div>");
                        stringBuilder31.Append("</td>");
                        stringBuilder30.Append("<td>");
                        stringBuilder30.Append("<div style='float:right'>");
                        LinkButton linkButton25 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton25.Style.Add("float", "right;");
                        linkButton25.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdnProSales1.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnProSales1.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton25.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton25.OnClientClick = string.Concat(str);
                        }
                        stringBuilder31.Append("</div>");
                        stringBuilder31.Append("</td>");
                        stringBuilder31.Append("</tr>");
                        stringBuilder31.Append("</table>");
                        stringBuilder31.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = (this.hdnProSales1.Value != "" ? dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.hdnProSales1.Value, dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())) : dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())));
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.hdnProSales1.Value, dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                            value8.SelectedValue = this.hdnProSales1.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            radChart.PlotArea.XAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                            for (int n = 0; n < dataSet.Tables[0].Rows.Count; n++)
                            {
                                if (dataSet.Tables[0].Rows[n]["EstimateStatus"].ToString().Length <= 8)
                                {
                                    radChart.PlotArea.XAxis[num7].TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[n]["EstimateStatus"].ToString());
                                    radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[n]["EstimateStatus"].ToString());
                                }
                                else
                                {
                                    radChart.PlotArea.XAxis[num7].TextBlock.Text = string.Concat(this.objBase.SpecialDecode(dataSet.Tables[0].Rows[n]["EstimateStatus"].ToString()).Substring(0, 5), "...");
                                    radChart.PlotArea.XAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[n]["EstimateStatus"].ToString());
                                }
                                num7++;
                            }
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder30.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton24);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton25);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(value8);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder31.ToString()));
                        ChartSeries chartSeries12 = new ChartSeries()
                        {
                            Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), dr["GraphType"].ToString())
                        };
                        chartSeries12.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                        chartSeries12.DataYColumn = "Probability%";
                        try
                        {
                            chartSeries12.DefaultLabelValue = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #Y");
                            chartSeries12.Appearance.TextAppearance.Dimensions.Paddings = "20px;20px;20px;20px";
                        }
                        catch
                        {
                        }
                        radChart.Series.Add(chartSeries12);
                        radChart.DataSource = dataSet;
                        radChart.DataBind();
                        radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;
                        radChart.Legend.Visible = true;
                    }
                    else
                    {
                        StringBuilder stringBuilder32 = new StringBuilder();
                        StringBuilder stringBuilder33 = new StringBuilder();
                        stringBuilder32.Append("<div style='margin-top:0px;'>");
                        stringBuilder32.Append("<table style='width:99%;'>");
                        stringBuilder32.Append("<tr>");
                        stringBuilder32.Append("<td>");
                        stringBuilder32.Append("<div style='float:right'>");
                        DropDownList dropDownList9 = new DropDownList();
                        forecast _forecast11 = new forecast();
                        DataTable dataTable13 = new DataTable();
                        dataTable13 = _forecast11.SelectAllUsers(this.CompanyID);
                        foreach (DataRow dataRow13 in dataTable13.Rows)
                        {
                            foreach (DataColumn dataColumn5 in dataTable13.Columns)
                            {
                                dataColumn5.ReadOnly = false;
                            }
                            dataRow13["SalesPersonName"] = this.objBase.SpecialDecode(dataRow13["SalesPersonName"].ToString());
                        }
                        dropDownList9.DataSource = dataTable13;
                        dropDownList9.DataTextField = "SalesPersonName";
                        dropDownList9.DataValueField = "userid";
                        dropDownList9.DataBind();
                        dropDownList9.Items.Insert(0, " ");
                        dropDownList9.Items[0].Text = "All";
                        dropDownList9.Items[0].Value = "-1";
                        dropDownList9.ID = string.Concat("ddlProsales_", num5);
                        dropDownList9.AutoPostBack = true;
                        dropDownList9.Style.Add("float", "right;");
                        dropDownList9.Style.Add("margin-right", "15px;");
                        dropDownList9.Style.Add("width", "115px;margin-top:1px;");
                        dropDownList9.CssClass = "simpledropdownPopup";
                        dropDownList9.Attributes.Add("onchange", string.Concat("javascript:getProSalesID(this.value, ", num5, ");"));
                        stringBuilder33.Append("</div>");
                        stringBuilder33.Append("</td>");
                        stringBuilder32.Append("<td>");
                        stringBuilder32.Append("<div style='float:right'>");
                        LinkButton linkButton26 = new LinkButton()
                        {
                            Text = "Print",
                            ID = string.Concat("LnkPrint1_", num5)
                        };
                        linkButton26.Style.Add("float", "right;margin-top:5px;");
                        if (this.hdnProSales.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnProSales.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton26.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton26.OnClientClick = string.Concat(str);
                        }
                        stringBuilder33.Append("</div>");
                        stringBuilder33.Append("</td>");
                        stringBuilder32.Append("<td>");
                        stringBuilder32.Append("<div style='float:right'>");
                        LinkButton linkButton27 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen1_", num5)
                        };
                        linkButton27.Style.Add("float", "right;");
                        linkButton27.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdnProSales.Value != "")
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", this.hdnProSales.Value, "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton27.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            str = new object[] { "Javascript:PrintEstimateValuebyStatusNew('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", dr["Status"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["ModuleName"].ToString(), "','", dr["TitleName"].ToString(), "','", dr["ShowArchivedStatus"].ToString(), "');" };
                            linkButton27.OnClientClick = string.Concat(str);
                        }
                        stringBuilder33.Append("</div>");
                        stringBuilder33.Append("</td>");
                        stringBuilder33.Append("</tr>");
                        stringBuilder33.Append("</table>");
                        stringBuilder33.Append("</div>");
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            dataSet = (this.hdnProSales.Value == "" ? dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), dr["DisplayRecordSalesOf"].ToString(), dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())) : dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.hdnProSales.Value, dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString())));
                        }
                        else
                        {
                            dataSet = dashboardestimate.Dashboard_Select_Probalility_SplitItems(Convert.ToInt64(this.Session["CompanyId"]), this.hdnProSales.Value, dr["Status"].ToString(), Convert.ToBoolean(dr["ShowArchivedStatus"].ToString()));
                            dropDownList9.SelectedValue = this.hdnProSales.Value;
                        }
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews10 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table10 = dataViews10.ToTable(true, strArrays);
                            DataView dataViews11 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "EstimateStatus" };
                            DataTable table11 = dataViews10.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table10.Rows.Count, 1);
                            foreach (DataRow row14 in table11.Rows)
                            {
                                ChartSeries str12 = new ChartSeries(row14["EstimateStatus"].ToString(), ChartSeriesType.Bar);
                                if (row14["EstimateStatus"].ToString().Length <= 15)
                                {
                                    str12.Name = row14["EstimateStatus"].ToString();
                                }
                                else
                                {
                                    str12.Name = string.Concat(row14["EstimateStatus"].ToString().Substring(0, 15), "...");
                                }
                                str12.YAxisType = ChartYAxisType.Primary;
                                str12.Type = ChartSeriesType.Bar;
                                str12.Appearance.LabelAppearance.Visible = true;
                                int num23 = 0;
                                foreach (DataRow dataRow14 in table10.Rows)
                                {
                                    DataTable item8 = dataSet.Tables[0];
                                    strArrays = new string[] { " EstimateStatus='", row14["EstimateStatus"].ToString(), "' and EstimateStatus='", dataRow14["EstimateStatus"].ToString(), "'" };
                                    DataRow[] dataRowArray5 = item8.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray5.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem14 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem14.Label.Visible = false;
                                        str12.AddItem(chartSeriesItem14, new ChartSeriesItem[0]);
                                        num23++;
                                    }
                                    else
                                    {
                                        ChartSeriesItem chartSeriesItem15 = new ChartSeriesItem()
                                        {
                                            YValue = Convert.ToDouble(dataRowArray5[0]["Probability%"]),
                                            Name = dataRowArray5[0]["EstimateStatus"].ToString()
                                        };
                                        chartSeriesItem15.Label.Visible = false;
                                        strArrays = new string[] { dataRowArray5[0]["EstimateStatus"].ToString(), "\r\nTotal Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", dataRowArray5[0]["Probability%"].ToString() };
                                        string str13 = string.Concat(strArrays);
                                        chartSeriesItem15.Label.ActiveRegion.Tooltip = str13;
                                        chartSeriesItem15.ActiveRegion.Tooltip = str13;
                                        str12.AddItem(chartSeriesItem15, new ChartSeriesItem[0]);
                                        if (dataRowArray5[0]["EstimateStatus"].ToString().Length <= 15)
                                        {
                                            dataRowArray5[0]["EstimateStatus"] = dataRowArray5[0]["EstimateStatus"].ToString();
                                        }
                                        else
                                        {
                                            dataRowArray5[0]["EstimateStatus"] = string.Concat(dataRowArray5[0]["EstimateStatus"].ToString().Substring(0, 15), "...");
                                        }
                                        radChart.PlotArea.XAxis[num23].TextBlock.Text = dataRowArray5[0]["EstimateStatus"].ToString();
                                        num23++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalespersonName";
                                radChart.Series.Add(str12);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder32.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton26);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton27);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(dropDownList9);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder33.ToString()));
                        try
                        {
                            radChart.PlotArea.YAxis.Appearance.CustomFormat = string.Concat("(", this.objCommon.GetCurrencyinRequiredFormate("", true), ") #");
                        }
                        catch
                        {
                        }
                        radChart.DataBind();
                    }
                    if (dr["GraphType"].ToString().ToLower() != "pie")
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
                else if (dr["MasterID"].ToString() == "12")
                {
                    if (dr["GraphType"].ToString().ToLower() == "bar")
                    {
                        StringBuilder stringBuilder34 = new StringBuilder();
                        StringBuilder stringBuilder35 = new StringBuilder();
                        stringBuilder34.Append("<div style='margin-top:0px;'>");
                        stringBuilder34.Append("<table style='width:99%;'>");
                        stringBuilder34.Append("<tr>");
                        stringBuilder34.Append("<td>");
                        stringBuilder34.Append("<div style='float:right'>");
                        DropDownList languageConversion4 = new DropDownList();
                        languageConversion4.Items.Insert(0, " ");
                        languageConversion4.Items[0].Text = "---Select---";
                        languageConversion4.Items[0].Value = "---Select---";
                        languageConversion4.Items.Insert(1, " ");
                        languageConversion4.Items[1].Text = this.objLanguage.GetLanguageConversion("Today");
                        languageConversion4.Items[1].Value = "Today";
                        languageConversion4.Items.Insert(2, " ");
                        languageConversion4.Items[2].Text = "This Week";
                        languageConversion4.Items[2].Value = "ThisWeek";
                        languageConversion4.Items.Insert(3, " ");
                        languageConversion4.Items[3].Text = this.objLanguage.GetLanguageConversion("This_Month");
                        languageConversion4.Items[3].Value = "ThisMonth";
                        languageConversion4.ID = "ddldaterange12_";
                        languageConversion4.AutoPostBack = true;
                        languageConversion4.Style.Add("float", "right;");
                        languageConversion4.Style.Add("margin-right", "15px;");
                        languageConversion4.Style.Add("width", "115px;margin-top:1px;");
                        languageConversion4.CssClass = "simpledropdownPopup";
                        languageConversion4.Attributes.Add("onchange", string.Concat("javascript:CallVS(this.value, ", num5, ");"));
                        stringBuilder35.Append("</div>");
                        stringBuilder35.Append("</td>");
                        stringBuilder34.Append("<td>");
                        stringBuilder34.Append("<div style='float:right'>");
                        DropDownList value9 = new DropDownList();
                        forecast _forecast12 = new forecast();
                        DataTable dataTable14 = new DataTable();
                        dataTable14 = _forecast12.SelectAllUsers(this.CompanyID);
                        foreach (DataRow row15 in dataTable14.Rows)
                        {
                            foreach (DataColumn column6 in dataTable14.Columns)
                            {
                                column6.ReadOnly = false;
                            }
                            row15["SalesPersonName"] = this.objBase.SpecialDecode(row15["SalesPersonName"].ToString());
                        }
                        value9.DataSource = dataTable14;
                        value9.DataTextField = "SalesPersonName";
                        value9.DataValueField = "userid";
                        value9.DataBind();
                        value9.Items.Insert(0, " ");
                        value9.Items[0].Text = "All";
                        value9.Items[0].Value = "-1";
                        value9.ID = "ddlcustomertask12_";
                        value9.AutoPostBack = true;
                        value9.Style.Add("float", "right;");
                        value9.Style.Add("margin-right", "15px;");
                        value9.Style.Add("width", "115px;margin-top:1px;");
                        value9.CssClass = "simpledropdownPopup";
                        value9.Attributes.Add("onchange", string.Concat("javascript:CallVS1(this.value, ", num5, ");"));
                        stringBuilder35.Append("</div>");
                        stringBuilder35.Append("</td>");
                        stringBuilder34.Append("<td>");
                        stringBuilder34.Append("<div style='float:right'>");
                        LinkButton linkButton28 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Print"),
                            ID = string.Concat("lnkPrint_", num5)
                        };
                        linkButton28.Style.Add("float", "right; margin-top:5px;");
                        if (this.hdnCallVS1.Value == "")
                        {
                            if (this.hdnCallVS.Value == "")
                            {
                                this.hdnCallVS.Value = dr["DefaultDate"].ToString();
                            }
                            str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                            linkButton28.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            if (this.hdnCallVS.Value == "")
                            {
                                this.hdnCallVS.Value = "---Select---";
                            }
                            str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                            linkButton28.OnClientClick = string.Concat(str);
                        }
                        stringBuilder35.Append("</div>");
                        stringBuilder35.Append("</td>");
                        stringBuilder34.Append("<td>");
                        stringBuilder34.Append("<div style='float:right'>");
                        LinkButton linkButton29 = new LinkButton()
                        {
                            Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                            ID = string.Concat("LnkFullscreen_", num5)
                        };
                        linkButton29.Style.Add("float", "right;");
                        linkButton29.Style.Add("margin-right", "15px;margin-top:5px;");
                        if (this.hdnCallVS1.Value == "")
                        {
                            if (this.hdnCallVS.Value == "")
                            {
                                this.hdnCallVS.Value = "---Select---";
                            }
                            str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                            linkButton29.OnClientClick = string.Concat(str);
                        }
                        else
                        {
                            if (this.hdnCallVS.Value == "")
                            {
                                this.hdnCallVS.Value = "---Select---";
                            }
                            str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                            linkButton29.OnClientClick = string.Concat(str);
                        }
                        stringBuilder35.Append("</div>");
                        stringBuilder35.Append("</td>");
                        stringBuilder35.Append("</tr>");
                        stringBuilder35.Append("</table>");
                        stringBuilder35.Append("</div>");
                        string value10 = "";
                        if (dr["DefaultDate"].ToString() == "1")
                        {
                            value10 = "Today";
                        }
                        if (dr["DefaultDate"].ToString() == "2")
                        {
                            value10 = "ThisWeek";
                        }
                        if (dr["DefaultDate"].ToString() == "3")
                        {
                            value10 = "ThisMonth";
                        }
                        if (this.hdnChartID.Value != num5.ToString())
                        {
                            if (this.hdnCallVS1.Value == "" || this.hdnCallVS1.Value == "---Select---")
                            {
                                this.hdnCallVS1.Value = dr["DisplayRecordSalesOf"].ToString();
                            }
                            if (this.hdnCallVS.Value == "---Select---" || this.hdnCallVS.Value == "")
                            {
                                value10 = "Today";
                            }
                            else
                            {
                                value10 = this.hdnCallVS.Value;
                                if (value10 == "1")
                                {
                                    value10 = "Today";
                                }
                                if (value10 == "2")
                                {
                                    value10 = "ThisWeek";
                                }
                                if (value10 == "3")
                                {
                                    value10 = "ThisMonth";
                                }
                            }
                            dataSet = dashboardestimate.Dashboard_Select_CallVSCount((long)this.CompanyID, value10, this.hdnCallVS1.Value);
                        }
                        else
                        {
                            if (this.hdnCallVS1.Value == "")
                            {
                                this.hdnCallVS1.Value = dr["DisplayRecordSalesOf"].ToString();
                            }
                            if (this.hdnCallVS.Value == "---Select---" || this.hdnCallVS.Value == "")
                            {
                                value10 = "Today";
                            }
                            else
                            {
                                value10 = this.hdnCallVS.Value;
                                if (value10 == "1")
                                {
                                    value10 = "Today";
                                }
                                if (value10 == "2")
                                {
                                    value10 = "ThisWeek";
                                }
                                if (value10 == "3")
                                {
                                    value10 = "ThisMonth";
                                }
                            }
                            dataSet = dashboardestimate.Dashboard_Select_CallVSCount((long)this.CompanyID, value10, this.hdnCallVS1.Value);
                            value9.SelectedValue = this.hdnCallVS1.Value;
                            languageConversion4.SelectedValue = this.hdnCallVS.Value;
                        }
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            DataView dataViews12 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "SalesPersonName" };
                            DataTable table12 = dataViews12.ToTable(true, strArrays);
                            DataView dataViews13 = new DataView(dataSet.Tables[0]);
                            strArrays = new string[] { "CallStatus" };
                            DataTable table13 = dataViews12.ToTable(true, strArrays);
                            radChart.PlotArea.XAxis.AddRange(1, (double)table12.Rows.Count, 1);
                            foreach (DataRow dataRow15 in table13.Rows)
                            {
                                ChartSeries chartSeries13 = new ChartSeries(dataRow15["CallStatus"].ToString(), ChartSeriesType.Bar);
                                if (dataRow15["CallStatus"].ToString().Length <= 15)
                                {
                                    chartSeries13.Name = dataRow15["CallStatus"].ToString();
                                }
                                else
                                {
                                    chartSeries13.Name = string.Concat(dataRow15["CallStatus"].ToString().Substring(0, 15), "...");
                                }
                                chartSeries13.YAxisType = ChartYAxisType.Primary;
                                chartSeries13.Type = ChartSeriesType.Bar;
                                chartSeries13.Appearance.LabelAppearance.Visible = true;
                                int num26 = 0;
                                foreach (DataRow row16 in table12.Rows)
                                {
                                    DataTable item10 = dataSet.Tables[0];
                                    strArrays = new string[] { " CallStatus='", dataRow15["CallStatus"].ToString(), "' and SalesPersonName='", row16["SalesPersonName"].ToString(), "'" };
                                    DataRow[] dataRowArray6 = item10.Select(string.Concat(strArrays));
                                    if ((int)dataRowArray6.Length <= 0)
                                    {
                                        ChartSeriesItem chartSeriesItem16 = new ChartSeriesItem(0)
                                        {
                                            Name = "wew"
                                        };
                                        chartSeriesItem16.Label.Visible = false;
                                        chartSeries13.AddItem(chartSeriesItem16, new ChartSeriesItem[0]);
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
                                        strArrays = new string[] { dataRowArray6[0]["SalesPersonName"].ToString(), "\r\nCall: (", dataRowArray6[0]["Count"].ToString(), ")\r\nStatus: ", dataRowArray6[0]["CallStatus"].ToString() };
                                        string str14 = string.Concat(strArrays);
                                        chartSeriesItem17.Label.ActiveRegion.Tooltip = str14;
                                        chartSeriesItem17.ActiveRegion.Tooltip = str14;
                                        chartSeries13.AddItem(chartSeriesItem17, new ChartSeriesItem[0]);
                                        if (dataRowArray6[0]["SalesPersonName"].ToString().Length <= 15)
                                        {
                                            dataRowArray6[0]["SalesPersonName"] = dataRowArray6[0]["SalesPersonName"].ToString();
                                        }
                                        else
                                        {
                                            dataRowArray6[0]["SalesPersonName"] = string.Concat(dataRowArray6[0]["SalesPersonName"].ToString().Substring(0, 15), "...");
                                        }
                                        radChart.PlotArea.XAxis[num26].TextBlock.Text = dataRowArray6[0]["SalesPersonName"].ToString();
                                        num26++;
                                    }
                                }
                                radChart.PlotArea.XAxis.DataLabelsColumn = "SalesPersonName";
                                radChart.Series.Add(chartSeries13);
                                radChart.PlotArea.XAxis.AutoScale = false;
                            }
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder34.ToString()));
                        if (dr["ShowPrint"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton28);
                        }
                        if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(linkButton29);
                        }
                        if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                        {
                            radDock.ContentContainer.Controls.Add(languageConversion4);
                            radDock.ContentContainer.Controls.Add(value9);
                        }
                        radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder35.ToString()));
                    }
                    colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    Palette palette6 = new Palette("seriesPalette", colorArray, true);
                    radChart.CustomPalettes.Add(palette6);
                    radChart.SeriesPalette = "seriesPalette";
                }
                else if (dr["MasterID"].ToString() == "13")
                {
                    //if (dr["GraphType"].ToString().ToLower() == "bar")
                    //{
                    //    StringBuilder stringBuilder34 = new StringBuilder();
                    //    StringBuilder stringBuilder35 = new StringBuilder();
                    //    stringBuilder34.Append("<div style='margin-top:0px;'>");
                    //    stringBuilder34.Append("<table style='width:99%;'>");
                    //    stringBuilder34.Append("<tr>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    DropDownList languageConversion4 = new DropDownList();
                    //    languageConversion4.Items.Insert(0, " ");
                    //    languageConversion4.Items[0].Text = "---Select---";
                    //    languageConversion4.Items[0].Value = "---Select---";
                    //    languageConversion4.Items.Insert(1, " ");
                    //    languageConversion4.Items[1].Text = this.objLanguage.GetLanguageConversion("Today");
                    //    languageConversion4.Items[1].Value = "Today";
                    //    languageConversion4.Items.Insert(2, " ");
                    //    languageConversion4.Items[2].Text = "This Week";
                    //    languageConversion4.Items[2].Value = "ThisWeek";
                    //    languageConversion4.Items.Insert(3, " ");
                    //    languageConversion4.Items[3].Text = this.objLanguage.GetLanguageConversion("This_Month");
                    //    languageConversion4.Items[3].Value = "ThisMonth";
                    //    languageConversion4.ID = "ddldaterange12_";
                    //    languageConversion4.AutoPostBack = true;
                    //    languageConversion4.Style.Add("float", "right;");
                    //    languageConversion4.Style.Add("margin-right", "15px;");
                    //    languageConversion4.Style.Add("width", "115px;margin-top:1px;");
                    //    languageConversion4.CssClass = "simpledropdownPopup";
                    //    languageConversion4.Attributes.Add("onchange", string.Concat("javascript:CallVS(this.value, ", num5, ");"));
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    DropDownList value9 = new DropDownList();
                    //    forecast _forecast12 = new forecast();
                    //    DataTable dataTable14 = new DataTable();
                    //    dataTable14 = _forecast12.SelectAllUsers(this.CompanyID);
                    //    foreach (DataRow row15 in dataTable14.Rows)
                    //    {
                    //        foreach (DataColumn column6 in dataTable14.Columns)
                    //        {
                    //            column6.ReadOnly = false;
                    //        }
                    //        row15["SalesPersonName"] = this.objBase.SpecialDecode(row15["SalesPersonName"].ToString());
                    //    }
                    //    value9.DataSource = dataTable14;
                    //    value9.DataTextField = "SalesPersonName";
                    //    value9.DataValueField = "userid";
                    //    value9.DataBind();
                    //    value9.Items.Insert(0, " ");
                    //    value9.Items[0].Text = "All";
                    //    value9.Items[0].Value = "-1";
                    //    value9.ID = "ddlcustomertask12_";
                    //    value9.AutoPostBack = true;
                    //    value9.Style.Add("float", "right;");
                    //    value9.Style.Add("margin-right", "15px;");
                    //    value9.Style.Add("width", "115px;margin-top:1px;");
                    //    value9.CssClass = "simpledropdownPopup";
                    //    value9.Attributes.Add("onchange", string.Concat("javascript:CallVS1(this.value, ", num5, ");"));
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    LinkButton linkButton28 = new LinkButton()
                    //    {
                    //        Text = this.objLanguage.GetLanguageConversion("Print"),
                    //        ID = string.Concat("lnkPrint_", num5)
                    //    };
                    //    linkButton28.Style.Add("float", "right; margin-top:5px;");
                    //    if (this.hdnCallVS1.Value == "")
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = dr["DefaultDate"].ToString();
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton28.OnClientClick = string.Concat(str);
                    //    }
                    //    else
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton28.OnClientClick = string.Concat(str);
                    //    }
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    LinkButton linkButton29 = new LinkButton()
                    //    {
                    //        Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                    //        ID = string.Concat("LnkFullscreen_", num5)
                    //    };
                    //    linkButton29.Style.Add("float", "right;");
                    //    linkButton29.Style.Add("margin-right", "15px;margin-top:5px;");
                    //    if (this.hdnCallVS1.Value == "")
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton29.OnClientClick = string.Concat(str);
                    //    }
                    //    else
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton29.OnClientClick = string.Concat(str);
                    //    }
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder35.Append("</tr>");
                    //    stringBuilder35.Append("</table>");
                    //    stringBuilder35.Append("</div>");
                    //    string value10 = "";
                    //    if (dr["DefaultDate"].ToString() == "1")
                    //    {
                    //        value10 = "Today";
                    //    }
                    //    if (dr["DefaultDate"].ToString() == "2")
                    //    {
                    //        value10 = "ThisWeek";
                    //    }
                    //    if (dr["DefaultDate"].ToString() == "3")
                    //    {
                    //        value10 = "ThisMonth";
                    //    }
                    //    dataSet = dashboardestimate.Dashboard_Select_DailyOrMonthlyJobTotal(Convert.ToInt64(this.Session["CompanyId"]),12,"Daily");


                    //    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    //    {
                    //        DataView dataViews2 = new DataView(dataSet.Tables[0]);
                    //        strArrays = new string[] { "CreatedDate" };
                    //        DataTable table2 = dataViews2.ToTable(true, strArrays);
                    //        DataView dataViews3 = new DataView(dataSet.Tables[0]);
                    //        strArrays = new string[] { "DailyTarget" };
                    //        DataTable table3 = dataViews2.ToTable(true, strArrays);
                    //        radChart.PlotArea.XAxis.AddRange(1, (double)table2.Rows.Count, 1);
                    //        List<string> days = new List<string>();
                    //        foreach(DataRow dailyData in dataSet.Tables[0].Rows)
                    //        {
                    //            days.Add(dailyData["Day"].ToString());
                    //        }
                    //        foreach (DataRow dataRow4 in table3.Rows)
                    //        {
                    //            ChartSeries chartSeries2 = new ChartSeries(dataRow4["DailyTarget"].ToString(), ChartSeriesType.Bar);
                    //            chartSeries2.YAxisType = ChartYAxisType.Primary;
                    //            chartSeries2.Type = ChartSeriesType.Bar;
                    //            chartSeries2.Appearance.LabelAppearance.Visible = true;
                    //            int num11 = 0;
                    //            foreach (DataRow row5 in table2.Rows)
                    //            {
                    //                DataTable item2 = dataSet.Tables[0];
                    //                strArrays = new string[] { " DailyTarget='", this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRow4["DailyTarget"].ToString()), 0, "", false, false, true), "' and CreatedDate='",row5["CreatedDate"].ToString().Split(' ')[0], "'" };
                    //                DataRow[] dataRowArray1 = item2.Select(string.Concat(strArrays));
                    //                if ((int)dataRowArray1.Length <= 0)
                    //                {
                    //                    ChartSeriesItem chartSeriesItem2 = new ChartSeriesItem(0)
                    //                    {
                    //                        Name = "wew"
                    //                    };
                    //                    chartSeriesItem2.Label.Visible = false;
                    //                    chartSeries2.AddItem(chartSeriesItem2, new ChartSeriesItem[0]);
                    //                    num11++;
                    //                }
                    //                else
                    //                {
                    //                    ChartSeriesItem chartSeriesItem3 = new ChartSeriesItem()
                    //                    {
                    //                        YValue = Convert.ToDouble(dataRowArray1[0]["SubTotal"]),
                    //                        Name = dataRowArray1[0]["CreatedDate"].ToString().Split(' ')[0]
                    //                    };
                    //                    chartSeriesItem3.Label.Visible = false;
                    //                    strArrays = new string[] { "Total Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray1[0]["SubTotal"].ToString()), 0, "", false, false, true) };
                    //                    string str5 = string.Concat(strArrays);
                    //                    chartSeriesItem3.Label.ActiveRegion.Tooltip = str5;
                    //                    chartSeriesItem3.ActiveRegion.Tooltip = str5;
                    //                    chartSeries2.Name = this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray1[0]["SubTotal"].ToString()), 0, "", false, false, true);
                    //                    chartSeries2.AddItem(chartSeriesItem3, new ChartSeriesItem[0]);
                    //                    dataRowArray1[0]["CreatedDate"] = dataRowArray1[0]["CreatedDate"].ToString().Split(' ')[0];
                    //                    radChart.PlotArea.XAxis[num11].TextBlock.Text = dataRowArray1[0]["CreatedDate"].ToString().Split(' ')[0];
                    //                    num11++;
                    //                }
                    //            }
                    //            radChart.PlotArea.XAxis.DataLabelsColumn = "CreatedDate";
                    //            radChart.Series.Add(chartSeries2);
                    //            radChart.PlotArea.XAxis.AutoScale = false;


                    //            if (dr["IsLastYearData"].ToString().ToLower() == "true")
                    //            {
                    //                DataTable dt = dashboardestimate.Dashboard_Select_LastYearDailyOrMonthlyJobTotal(Convert.ToInt64(this.Session["CompanyId"]), 12, "Daily");
                    //                ChartSeries lineSeries = new ChartSeries("Last Year Data", ChartSeriesType.Line);
                    //                lineSeries.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.Nothing;
                    //                lineSeries.Appearance.PointMark.Visible = true;
                    //                lineSeries.YAxisType = ChartYAxisType.Primary;
                    //                lineSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Orange;
                    //                //lineSeries.Type = ChartSeriesType.Line;
                    //                lineSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                    //                lineSeries.Appearance.PointMark.Dimensions.Width = 5;
                    //                lineSeries.Appearance.PointMark.Dimensions.Height = 5;
                    //                lineSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Red;
                    //                lineSeries.ActiveRegionToolTip = "Last Year Job Value";
                    //                int i = 0;
                    //                foreach(DataRow _dataRow in dt.Rows)
                    //                {
                    //                    ChartSeriesItem lineSeriesItem = new ChartSeriesItem();
                    //                    foreach(string day in days)
                    //                    {
                    //                        if(day == _dataRow["Day"].ToString())
                    //                        {
                    //                            //lineSeriesItem.Label.ActiveRegion.Tooltip = "Last Year Job Value : " + Convert.ToDouble(_dataRow["SubTotal"].ToString()) + "";
                    //                            //lineSeriesItem.ActiveRegion.Tooltip = "Last Year Job Value : " + Convert.ToDouble(_dataRow["SubTotal"].ToString()) + "";
                    //                            lineSeries.AddItem(Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(_dataRow["SubTotal"].ToString()), 0, "", false, false, true)));

                    //                        }
                    //                    }

                    //                }

                    //                radChart.Series.Add(lineSeries);
                    //            }
                    //            if (dr["IsDailyTarget"].ToString().ToLower() == "true")
                    //            {
                    //                DataTable _dt = dataSet.Tables[0];
                    //                ChartSeries _lineSeries = new ChartSeries("Daily Target", ChartSeriesType.Line);
                    //                int i = 0;
                    //                _lineSeries.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.Nothing;
                    //                _lineSeries.YAxisType = ChartYAxisType.Primary;
                    //                _lineSeries.Appearance.LineSeriesAppearance.Color = ColorTranslator.FromHtml(this.BarColors(2));
                    //                //_lineSeries.Type = ChartSeriesType.Line;
                    //                _lineSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                    //                _lineSeries.Appearance.PointMark.Dimensions.Width = 5;
                    //                _lineSeries.Appearance.PointMark.Dimensions.Height = 5;
                    //                _lineSeries.Appearance.PointMark.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(2));
                    //                _lineSeries.Appearance.PointMark.Visible = true;
                    //                _lineSeries.ActiveRegionToolTip = "Daily Target";
                    //                foreach (DataRow _dataRow in _dt.Rows)
                    //                {
                    //                    ChartSeriesItem _lineSeriesItem = new ChartSeriesItem();
                    //                    //_lineSeriesItem.Label.ActiveRegion.Tooltip = "Last Year Job Value : " + Convert.ToDouble(_dataRow["DailyTarget"].ToString()) + "";
                    //                    //_lineSeriesItem.ActiveRegion.Tooltip = "Last Year Job Value : " + Convert.ToDouble(_dataRow["DailyTarget"].ToString()) + "";
                    //                    _lineSeries.AddItem(Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(_dataRow["DailyTarget"].ToString()), 0, "", false, false, true)));

                    //                }
                    //                radChart.Series.Add(_lineSeries);
                    //            }
                    //            try
                    //            {
                    //                chartSeries2.PlotArea.YAxis.Appearance.CustomFormat = string.Concat(this.objCommon.GetCurrencyinRequiredFormate("", true), " #");
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }
                    //    }

                    //    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder34.ToString()));
                    //    if (dr["ShowPrint"].ToString().ToLower() == "true")
                    //    {
                    //        radDock.ContentContainer.Controls.Add(linkButton28);
                    //    }
                    //    if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                    //    {
                    //        radDock.ContentContainer.Controls.Add(linkButton29);
                    //    }
                    //    if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    //    {
                    //        radDock.ContentContainer.Controls.Add(languageConversion4);
                    //        radDock.ContentContainer.Controls.Add(value9);
                    //    }
                    //    radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder35.ToString()));
                    //}
                    //colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    //Palette palette6 = new Palette("seriesPalette", colorArray, true);
                    //radChart.CustomPalettes.Add(palette6);
                    //radChart.SeriesPalette = "seriesPalette";

                    CopyMasterIDdaily = num5;
                    HtmlGenericControl canvas = new HtmlGenericControl("canvas");
                    canvas.ID = "mixedChartd";
                    canvas.Attributes["width"] = "1322";
                    canvas.Attributes["height"] = "338";
                    radDock.ContentContainer.Controls.Add(canvas);
                    radDock.Title = dr["TitleName"].ToString();
                    //radDock.Visible = false;
                    //RadDock2.Title = dr["TitleName"].ToString();
                    //RadDock2.Visible = true;
                    dailyTarget = Convert.ToBoolean(dr["IsDailyTarget"].ToString());
                    dailyLastyear = Convert.ToBoolean(dr["IsLastYearData"].ToString());
                    string script = "DailyData();";
                    ClientScript.RegisterStartupScript(this.GetType(), "DailyData", script, true);


                }
                else if (dr["MasterID"].ToString() == "14")
                {
                    //if (dr["GraphType"].ToString().ToLower() == "bar")
                    //{
                    //    StringBuilder stringBuilder34 = new StringBuilder();
                    //    StringBuilder stringBuilder35 = new StringBuilder();
                    //    stringBuilder34.Append("<div style='margin-top:0px;'>");
                    //    stringBuilder34.Append("<table style='width:99%;'>");
                    //    stringBuilder34.Append("<tr>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    DropDownList languageConversion4 = new DropDownList();
                    //    languageConversion4.Items.Insert(0, " ");
                    //    languageConversion4.Items[0].Text = "---Select---";
                    //    languageConversion4.Items[0].Value = "---Select---";
                    //    languageConversion4.Items.Insert(1, " ");
                    //    languageConversion4.Items[1].Text = this.objLanguage.GetLanguageConversion("Today");
                    //    languageConversion4.Items[1].Value = "Today";
                    //    languageConversion4.Items.Insert(2, " ");
                    //    languageConversion4.Items[2].Text = "This Week";
                    //    languageConversion4.Items[2].Value = "ThisWeek";
                    //    languageConversion4.Items.Insert(3, " ");
                    //    languageConversion4.Items[3].Text = this.objLanguage.GetLanguageConversion("This_Month");
                    //    languageConversion4.Items[3].Value = "ThisMonth";
                    //    languageConversion4.ID = "ddldaterange12_";
                    //    languageConversion4.AutoPostBack = true;
                    //    languageConversion4.Style.Add("float", "right;");
                    //    languageConversion4.Style.Add("margin-right", "15px;");
                    //    languageConversion4.Style.Add("width", "115px;margin-top:1px;");
                    //    languageConversion4.CssClass = "simpledropdownPopup";
                    //    languageConversion4.Attributes.Add("onchange", string.Concat("javascript:CallVS(this.value, ", num5, ");"));
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    DropDownList value9 = new DropDownList();
                    //    forecast _forecast12 = new forecast();
                    //    DataTable dataTable14 = new DataTable();
                    //    dataTable14 = _forecast12.SelectAllUsers(this.CompanyID);
                    //    foreach (DataRow row15 in dataTable14.Rows)
                    //    {
                    //        foreach (DataColumn column6 in dataTable14.Columns)
                    //        {
                    //            column6.ReadOnly = false;
                    //        }
                    //        row15["SalesPersonName"] = this.objBase.SpecialDecode(row15["SalesPersonName"].ToString());
                    //    }
                    //    value9.DataSource = dataTable14;
                    //    value9.DataTextField = "SalesPersonName";
                    //    value9.DataValueField = "userid";
                    //    value9.DataBind();
                    //    value9.Items.Insert(0, " ");
                    //    value9.Items[0].Text = "All";
                    //    value9.Items[0].Value = "-1";
                    //    value9.ID = "ddlcustomertask12_";
                    //    value9.AutoPostBack = true;
                    //    value9.Style.Add("float", "right;");
                    //    value9.Style.Add("margin-right", "15px;");
                    //    value9.Style.Add("width", "115px;margin-top:1px;");
                    //    value9.CssClass = "simpledropdownPopup";
                    //    value9.Attributes.Add("onchange", string.Concat("javascript:CallVS1(this.value, ", num5, ");"));
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    LinkButton linkButton28 = new LinkButton()
                    //    {
                    //        Text = this.objLanguage.GetLanguageConversion("Print"),
                    //        ID = string.Concat("lnkPrint_", num5)
                    //    };
                    //    linkButton28.Style.Add("float", "right; margin-top:5px;");
                    //    if (this.hdnCallVS1.Value == "")
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = dr["DefaultDate"].ToString();
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton28.OnClientClick = string.Concat(str);
                    //    }
                    //    else
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton28.OnClientClick = string.Concat(str);
                    //    }
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder34.Append("<td>");
                    //    stringBuilder34.Append("<div style='float:right'>");
                    //    LinkButton linkButton29 = new LinkButton()
                    //    {
                    //        Text = this.objLanguage.GetLanguageConversion("Full_Screen"),
                    //        ID = string.Concat("LnkFullscreen_", num5)
                    //    };
                    //    linkButton29.Style.Add("float", "right;");
                    //    linkButton29.Style.Add("margin-right", "15px;margin-top:5px;");
                    //    if (this.hdnCallVS1.Value == "")
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", dr["DisplayRecordSalesOf"].ToString(), "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton29.OnClientClick = string.Concat(str);
                    //    }
                    //    else
                    //    {
                    //        if (this.hdnCallVS.Value == "")
                    //        {
                    //            this.hdnCallVS.Value = "---Select---";
                    //        }
                    //        str = new object[] { "Javascript:PrintCallBar('", num5, "','", dr["MasterID"].ToString(), "','", dr["GraphType"].ToString(), "','", this.ddlStatusValue.Value, "','", dr["CustomizeColumns"].ToString(), "','", this.hdnCallVS1.Value, "','", dr["NoOfRecords"].ToString(), "','", this.hdnCallVS.Value, "','", dr["DisplayType"].ToString(), "','", dr["TitleName"].ToString(), "');" };
                    //        linkButton29.OnClientClick = string.Concat(str);
                    //    }
                    //    stringBuilder35.Append("</div>");
                    //    stringBuilder35.Append("</td>");
                    //    stringBuilder35.Append("</tr>");
                    //    stringBuilder35.Append("</table>");
                    //    stringBuilder35.Append("</div>");
                    //    string value10 = "";
                    //    if (dr["DefaultDate"].ToString() == "1")
                    //    {
                    //        value10 = "Today";
                    //    }
                    //    if (dr["DefaultDate"].ToString() == "2")
                    //    {
                    //        value10 = "ThisWeek";
                    //    }
                    //    if (dr["DefaultDate"].ToString() == "3")
                    //    {
                    //        value10 = "ThisMonth";
                    //    }
                    //    dataSet = dashboardestimate.Dashboard_Select_DailyOrMonthlyJobTotal(Convert.ToInt64(this.Session["CompanyId"]), 12, "Monthly");


                    //    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    //    {
                    //        DataView dataViews2 = new DataView(dataSet.Tables[0]);
                    //        strArrays = new string[] { "Month" };
                    //        DataTable table2 = dataViews2.ToTable(true, strArrays);
                    //        DataView dataViews3 = new DataView(dataSet.Tables[0]);
                    //        strArrays = new string[] { "MonthlyTarget" };
                    //        DataTable table3 = dataViews2.ToTable(true, strArrays);
                    //        radChart.PlotArea.XAxis.AddRange(1, (double)table2.Rows.Count, 1);
                    //        List<string> months = new List<string>();
                    //        foreach (DataRow monthlyData in dataSet.Tables[0].Rows)
                    //        {
                    //            months.Add(monthlyData["Month"].ToString());
                    //        }



                    //        foreach (DataRow dataRow4 in table3.Rows)  //monthly target
                    //        {
                    //            ChartSeries chartSeries2 = new ChartSeries(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRow4["MonthlyTarget"].ToString()), 0, "", false, false, true), ChartSeriesType.Bar);
                    //            chartSeries2.YAxisType = ChartYAxisType.Primary;
                    //            chartSeries2.Type = ChartSeriesType.Bar;
                    //            chartSeries2.Appearance.LabelAppearance.Visible = true;
                    //            int num11 = 0;
                    //            foreach (DataRow row5 in table2.Rows)  //month
                    //            {
                    //                DataTable item2 = dataSet.Tables[0];  //whole
                    //                strArrays = new string[] { " MonthlyTarget='", this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRow4["MonthlyTarget"].ToString()), 0, "", false, false, true), "' and Month='", row5["Month"].ToString(), "'" };
                    //                DataRow[] dataRowArray1 = item2.Select(string.Concat(strArrays));
                    //                if ((int)dataRowArray1.Length <= 0)
                    //                {
                    //                    //strArrays = new string[] { "Month='", row5["Month"].ToString(), "'" };
                    //                    //DataRow[] dataRowArray12 = item2.Select(string.Concat(strArrays));

                    //                    ChartSeriesItem chartSeriesItem2 = new ChartSeriesItem(0)
                    //                    {
                    //                        Name = "wew"  // row5["Month"].ToString(),
                    //                        //YValue = Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray12[0]["SubTotal"]), 0, "", false, false, true)),

                    //                    };
                    //                    chartSeriesItem2.Label.Visible = false;
                    //                    //chartSeriesItem2.Appearance.FillStyle.MainColor = System.Drawing.Color.MediumPurple;
                    //                    //chartSeriesItem2.Appearance.FillStyle.FillType = FillType.Solid;
                    //                    chartSeries2.AddItem(chartSeriesItem2, new ChartSeriesItem[0]);
                    //                    num11++;
                    //                }
                    //                else
                    //                {
                    //                    ChartSeriesItem chartSeriesItem3 = new ChartSeriesItem()
                    //                    {
                    //                        YValue = Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray1[0]["SubTotal"]), 0, "", false, false, true)),
                    //                        Name = dataRowArray1[0]["Month"].ToString()
                    //                        };
                    //                    chartSeriesItem3.Label.Visible = false;
                    //                    strArrays = new string[] { "Total Value (", this.objCommon.GetCurrencyinRequiredFormate("", true), "): ", this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray1[0]["SubTotal"].ToString()), 0, "", false, false, true) };
                    //                    string str5 = string.Concat(strArrays);
                    //                    chartSeriesItem3.Label.ActiveRegion.Tooltip = str5;
                    //                    chartSeriesItem3.ActiveRegion.Tooltip = str5;

                    //                    chartSeries2.Name = this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(dataRowArray1[0]["SubTotal"].ToString()), 0, "", false, false, true);
                    //                    chartSeries2.Appearance.LabelAppearance.Position.AlignedPosition = AlignedPositions.Center;//.BarWidthPercent = 50;
                    //                    chartSeries2.Appearance.BarWidthPercent = 50;

                    //                    chartSeries2.AddItem(chartSeriesItem3, new ChartSeriesItem[0]);
                    //                    dataRowArray1[0]["Month"] = dataRowArray1[0]["Month"].ToString();
                    //                    //radChart.PlotArea.XAxis.IsZeroBased = true;
                    //                    //radChart.PlotArea.XAxis.AutoScale = true;
                    //                    radChart.PlotArea.XAxis[num11].TextBlock.Text = dataRowArray1[0]["Month"].ToString();
                    //                    num11++;           
                    //                }
                    //            }                             
                    //                radChart.PlotArea.XAxis.DataLabelsColumn = "Month";
                    //                radChart.Series.Add(chartSeries2);

                    //            if (dr["IsLastYearData"].ToString().ToLower() == "true")
                    //            {
                    //                DataTable dt = dashboardestimate.Dashboard_Select_LastYearDailyOrMonthlyJobTotal(Convert.ToInt64(this.Session["CompanyId"]), 12, "Monthly");
                    //                ChartSeries lineSeries = new ChartSeries("Monthly Last Year Data", ChartSeriesType.Line);
                    //                int i = 0;
                    //                lineSeries.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.Nothing;
                    //                lineSeries.YAxisType = ChartYAxisType.Primary;
                    //                lineSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Orange;
                    //                //lineSeries.Type = ChartSeriesType.Line;
                    //                lineSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                    //                lineSeries.Appearance.PointMark.Dimensions.Width = 5;
                    //                lineSeries.Appearance.PointMark.Dimensions.Height = 5;
                    //                lineSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Red ;
                    //                lineSeries.Appearance.PointMark.Visible = true;
                    //                lineSeries.ActiveRegionToolTip = "Last Year Job Value";
                    //                foreach (DataRow _dataRow in dt.Rows)
                    //                {
                    //                    lineSeries.AddItem(Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(_dataRow["SubTotal"].ToString()), 0, "", false, false, true)), "", Color.Black);
                    //                }
                    //                radChart.Series.Add(lineSeries);
                    //            }

                    //            if (dr["IsMonthlyTarget"].ToString().ToLower() == "true")
                    //            {
                    //                DataTable dt = dataSet.Tables[0];
                    //                StyleSeries ss = new StyleSeries();
                    //                ChartSeries lineSeries = new ChartSeries("Monthly Target", ChartSeriesType.Line,null,ChartYAxisType.Primary,ss);
                    //                int i = 0;
                    //                lineSeries.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.Nothing;
                    //                lineSeries.YAxisType = ChartYAxisType.Primary;
                    //                lineSeries.Appearance.LineSeriesAppearance.Color = ColorTranslator.FromHtml(this.BarColors(2));

                    //                //lineSeries.Type = ChartSeriesType.Line;
                    //                lineSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                    //                lineSeries.Appearance.PointMark.Dimensions.Width = 5;
                    //                lineSeries.Appearance.PointMark.Dimensions.Height = 5;

                    //                lineSeries.Appearance.PointMark.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(2));
                    //                lineSeries.Appearance.PointMark.Visible = true;
                    //                lineSeries.ActiveRegionToolTip = "Monthly Target";
                    //                foreach (DataRow _dataRow in dt.Rows)
                    //                {
                    //                    foreach (string month in months)
                    //                    {
                    //                        if (month == _dataRow["Month"].ToString())
                    //                        {
                    //                            lineSeries.AddItem(Convert.ToDouble(this.objJava.Eprint_ReturnFinal_Formated_Amount(Convert.ToInt32(this.CompanyID), this.UserID, Convert.ToDecimal(_dataRow["MonthlyTarget"].ToString()), 0, "", false, false, true)), "", Color.Blue);
                    //                        }
                    //                    }
                    //                }
                    //                radChart.Series.Add(lineSeries);
                    //            }
                    //            try
                    //            {
                    //                chartSeries2.PlotArea.YAxis.Appearance.CustomFormat = string.Concat(this.objCommon.GetCurrencyinRequiredFormate("", true), " #");
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }
                    //    }
                    //HtmlGenericControl canvas = new HtmlGenericControl("canvas");

                    //// Set canvas attributes
                    //canvas.ID = "myCanvas";
                    //canvas.Attributes["width"] = "1322"; // Set your desired width
                    //canvas.Attributes["height"] = "338"; // Set your desired height

                    //// Add canvas to the RadDock control
                    //radDock.Controls.Add(canvas);
                    // radDock.ContentContainer.Controls.Add(canvas);
                    // ClientScript.RegisterStartupScript(this.Page.GetType(), "OnLoad", $"javascript:test()", true);
                    //radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder34.ToString()));
                    //if (dr["ShowPrint"].ToString().ToLower() == "true")
                    //{
                    //    radDock.ContentContainer.Controls.Add(linkButton28);
                    //}
                    //if (dr["ShowFullScreen"].ToString().ToLower() == "true")
                    //{
                    //    radDock.ContentContainer.Controls.Add(linkButton29);
                    //}
                    //if (dr["ShowAllOptions"].ToString().ToLower() == "true")
                    //{
                    //    radDock.ContentContainer.Controls.Add(languageConversion4);
                    //    radDock.ContentContainer.Controls.Add(value9);
                    //}
                    //radDock.ContentContainer.Controls.Add(new LiteralControl(stringBuilder35.ToString()));



                    // }

                    //widget 12
                    CopyMasterIDmonthly = num5;
                    HtmlGenericControl canvas = new HtmlGenericControl("canvas");
                    canvas.ID = "mixedChartm";
                    canvas.Attributes["width"] = "1322";
                    canvas.Attributes["height"] = "338";
                    radDock.ContentContainer.Controls.Add(canvas);
                    radDock.Title = dr["TitleName"].ToString();
                    //  canvas.Style["border"] = "1px solid #000";

                    //radDock.Visible = false;

                    //RadDock1.Title = dr["TitleName"].ToString();
                    //RadDock1.Visible = true;
                    monthlyTarget = Convert.ToBoolean(dr["IsMonthlyTarget"].ToString());
                    monthlyLastyear = Convert.ToBoolean(dr["IsLastYearData"].ToString());
                    string script = "MonthlyData();";
                    ClientScript.RegisterStartupScript(this.GetType(), "MonthlyData", script, true);

                    ////int num13 = 0;
                    //foreach (ChartSeriesItem item4 in radChart.Series[0].Items)
                    //{
                    //    DataTable dt = dataSet.Tables[0];
                    //    foreach(DataRow item in dt.Rows)
                    //    {

                    //        if (item["Month"].ToString() == item4.Name)
                    //        {
                    //            if(item4.YValue >= Convert.ToDouble(item["MonthlyTarget"]))
                    //            {
                    //                item4.Appearance.FillStyle.MainColor = System.Drawing.Color.Green;
                    //                item4.Appearance.FillStyle.FillType = FillType.Solid;

                    //            }
                    //            else
                    //            {
                    //                item4.Appearance.FillStyle.MainColor = System.Drawing.Color.MediumPurple;
                    //                item4.Appearance.FillStyle.FillType = FillType.Solid;

                    //            }
                    //        }

                    //    }
                    //    if (item4.Name == "wew")
                    //    {
                    //        item4.Appearance.FillStyle.MainColor = System.Drawing.Color.MediumPurple;
                    //        item4.Appearance.FillStyle.FillType = FillType.Solid;
                    //    }

                    //}

                    //colorArray = new Color[] { Color.FromArgb(35, 176, 46), Color.FromArgb(255, 146, 0), Color.FromArgb(23, 137, 197), Color.FromArgb(167, 124, 203), Color.FromArgb(237, 142, 209), Color.FromArgb(200, 200, 0), Color.FromArgb(0, 200, 218), Color.FromArgb(235, 110, 56), Color.FromArgb(246, 146, 78), Color.FromArgb(19, 104, 178), Color.FromArgb(0, 188, 167), Color.FromArgb(65, 84, 111), Color.FromArgb(142, 208, 210) };
                    //Palette palette6 = new Palette("seriesPalette", colorArray, true);
                    //radChart.CustomPalettes.Add(palette6);
                    //radChart.SeriesPalette = "seriesPalette";
                }
                else if (dr["MasterID"].ToString() == "15")
                {
                    dataSet = dashboardestimate.Dashboard_GetInvoiceCodesPercentage(int.Parse(dr["DefaultDate"].ToString()), Convert.ToInt64(this.Session["CompanyId"]));
                    //dataSet = dashboardestimate.Dashboard_GetEstStatusCount(Convert.ToInt64(this.Session["CompanyId"]));

                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        radChart.PlotArea.YAxis.AddRange(1, (double)dataSet.Tables[0].Rows.Count, 1);
                        for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                        {
                            radChart.PlotArea.YAxis[num7].TextBlock.Text = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[j]["AccountingCode"].ToString());
                            radChart.PlotArea.YAxis.Items[num7].ActiveRegion.Tooltip = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[j]["AccountingCode"].ToString());
                            num7++;
                        }
                    }
                    ChartSeries chartSeries4 = new ChartSeries()
                    {
                        Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), dr["GraphType"].ToString()),
                        DefaultLabelValue = "#%"
                    };
                    chartSeries4.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;
                    chartSeries4.DataYColumn = "CodePercentage";

                    if (dr["GraphType"].ToString().ToLower() == "pie")
                    {
                        try
                        {
                            chartSeries4.Appearance.DiameterScale = 0.95;
                            // chartSeries4.Appearance.TextAppearance.TextProperties.Font= new Font("Verdana", 10f, FontStyle.Bold);
                            chartSeries4.Appearance.TextAppearance.Dimensions.Paddings = "10px;10px;10px;10px";

                            //chartSeries4.PlotArea.Appearance.Dimensions.Width = Telerik.Charting.Styles.Unit.Pixel(300);
                            //chartSeries4.PlotArea.Appearance.Dimensions.Height = Telerik.Charting.Styles.Unit.Pixel(200);
                        }
                        catch
                        {
                        }
                    }
                    radChart.Series.Add(chartSeries4);
                    radChart.DataSource = dataSet;
                    radChart.DataBind();
                    radChart.PlotArea.YAxis.Appearance.MinorGridLines.Visible = false;
                    radChart.Chart.PlotArea.Appearance.Border.Visible = false;
                    radChart.Legend.Visible = true;
                    if (dr["GraphType"].ToString().ToLower() != "line")
                    {
                        int num13 = 0;
                        foreach (ChartSeriesItem item4 in radChart.Series[0].Items)
                        {
                            int num14 = num13;
                            num13 = num14 + 1;
                            item4.Appearance.FillStyle.MainColor = ColorTranslator.FromHtml(this.BarColors(num14));
                            item4.Appearance.FillStyle.FillType = FillType.Solid;
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                item4.Name = this.objBase.SpecialDecode(dataSet.Tables[0].Rows[num14]["AccountingCode"].ToString());
                            }
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
                radChart.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new Font("Arial", 8.25f, FontStyle.Bold);
                radChart.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 35f;
                radChart.PlotArea.XAxis.Appearance.TextAppearance.AutoTextWrap = AutoTextWrap.False;
                radChart.PlotArea.XAxis.Appearance.TextAppearance.Dimensions.Margins = new ChartMargins(1, 1, 8, 1);
                //radChart.Width= System.Web.UI.WebControls.Unit.Pixel(500);
                //radChart.Height = System.Web.UI.WebControls.Unit.Pixel(350);
                radDock.ContentContainer.Controls.Add(radChart);
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:hideloading();", true);
            return radDock;
        }

        protected void ddlAssignto_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlAssignto.SelectedValue != null)
            {
                if (this.ddlAssignto.SelectedValue == "-1")
                {
                    DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskCall_Today_ForallUsers((long)this.CompanyID, (long)0);
                    this.RadGridTodayAdmin.DataSource = dataSet;
                    this.RadGridTodayAdmin.DataBind();
                    this.objBase.SetDDLValue(this.ddlAssignto, this.ddlAssignto.SelectedValue);
                    return;
                }
                if (this.ddlAssignto.SelectedValue != "")
                {
                    try
                    {
                        DataSet dataSet1 = DepartmentBaseClass.Dashboard_Select_TaskCall_Today_ForallUsers((long)this.CompanyID, Convert.ToInt64(this.ddlAssignto.SelectedValue));
                        if (dataSet1.Tables[0].Rows.Count > 0)
                        {
                            this.RadGridTodayAdmin.DataSource = dataSet1;
                            this.RadGridTodayAdmin.DataBind();
                            this.objBase.SetDDLValue(this.ddlAssignto, this.ddlAssignto.SelectedValue);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected void ddlCallTaskEvent_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownList = (DropDownList)sender;
                string[] strArrays = dropDownList.ID.Split(new char[] { '\u005F' });
                RadDock radDock = (RadDock)this.raddockzonefirst.FindControl(string.Concat("radDock", strArrays[1].ToString()));
                RadGrid radGrid = (RadGrid)radDock.ContentContainer.FindControl(string.Concat("radGrid_", strArrays[1].ToString()));
                RadDatePicker radDatePicker = (RadDatePicker)radDock.ContentContainer.FindControl(string.Concat("rdpCalender_", strArrays[1].ToString()));
                if (dropDownList.SelectedItem.Text == "All")
                {
                    DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_Today((long)this.ClientID, (long)this.CompanyID, this.UserID, "All");
                    radGrid.DataSource = dataSet;
                    radGrid.DataBind();
                }
                else if (dropDownList.SelectedItem.Text != "")
                {
                    DataSet dataSet1 = DepartmentBaseClass.Dashboard_Select_TaskEventCall_Today((long)this.ClientID, (long)this.CompanyID, this.UserID, dropDownList.SelectedItem.Text);
                    radGrid.DataSource = dataSet1;
                    radGrid.DataBind();
                }
            }
            catch
            {
            }
        }

        public void ddlstatus_OnSelectedIndexChanged1()
        {
            this.raddockzonefirst.Controls.Clear();
            this.raddockzonesecond.Controls.Clear();
            DataTable dataTable = dashboardestimate.PC_Dashboard_Select_Widgets((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
            if (dataTable.Rows.Count > 0)
            {
                this.raddockzonefirst.Visible = true;
                this.raddockzonesecond.Visible = true;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.j = i;
                    this.Session["DockHeading"] = "Dashboard";
                    RadDock radDock = this.CreateRadDock(dataTable.Rows[i]);
                    if (dataTable.Rows[i]["IsSpreadOverTwoColumns"].ToString().ToLower() != "true")
                    {
                        if (dataTable.Rows[i]["DockPosition"].ToString() == "left")
                        {
                            this.raddockzonefirst.Controls.Add(radDock);
                        }
                        else if (dataTable.Rows[i]["DockPosition"].ToString() == "right")
                        {
                            this.raddockzonesecond.Controls.Add(radDock);
                        }
                        else if (this.j % 2 != 0)
                        {
                            this.raddockzonesecond.Controls.Add(radDock);
                        }
                        else
                        {
                            this.raddockzonefirst.Controls.Add(radDock);
                        }
                    }
                    else if (dataTable.Rows[i]["GraphType"].ToString().ToLower() != "pie")
                    {
                        this.raddockzonetop.Controls.Add(radDock);
                    }
                    else if (dataTable.Rows[i]["DockPosition"].ToString() == "left")
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                    else if (dataTable.Rows[i]["DockPosition"].ToString() == "right")
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else if (this.j % 2 != 0)
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                }
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
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (headertext.ToLower() == "contact name")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
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
                    if (this.DateFormat != "dd/mm/yyyy")
                    {
                        gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    }
                    else
                    {
                        gridBoundColumn.DataFormatString = "{0:dd/MM/yyyy hh:mm tt}";
                    }
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

        public void GenerateGridBoundColumns123(string datafield, string headertext, RadGrid Grid)
        {
            try
            {
                GridBoundColumn gridBoundColumn = new GridBoundColumn()
                {
                    DataField = datafield,
                    HeaderText = headertext
                };
                gridBoundColumn.ItemStyle.VerticalAlign = VerticalAlign.Top;
                if (headertext == "")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(1.2);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(1.2);
                }
                else if (headertext.ToLower() == "subject")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (headertext.ToLower() == "contact name")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(8);
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
                    if (this.DateFormat != "dd/mm/yyyy")
                    {
                        gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    }
                    else
                    {
                        gridBoundColumn.DataFormatString = "{0:dd/MM/yyyy hh:mm tt}";
                    }
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
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(25);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(25);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                }
                if (headertext.ToLower() == "scheduled")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(5);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(5);
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                    gridBoundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
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
                    if (this.DateFormat != "dd/mm/yyyy")
                    {
                        gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    }
                    else
                    {
                        gridBoundColumn.DataFormatString = "{0:dd/MM/yyyy hh:mm tt}";
                    }
                }
                else if (datafield.ToString().ToLower() == "addedfromcall" || datafield.ToString().ToLower() == "subject")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (datafield.ToString().ToLower() == "duedate")
                {
                    this.DateFormat = this.Session["DateFormat"].ToString();
                    if (this.DateFormat != "dd/mm/yyyy")
                    {
                        gridBoundColumn.DataFormatString = "{0:MM/dd/yyyy hh:mm tt}";
                    }
                    else
                    {
                        gridBoundColumn.DataFormatString = "{0:dd/MM/yyyy hh:mm tt}";
                    }
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(9);
                }
                else if (datafield.ToString().ToLower() == "specificto")
                {
                    gridBoundColumn.ItemStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                    gridBoundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Percentage(10);
                }
                else if (datafield.ToString().ToLower() == "customername")
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

        public string GenerateWhereConditions(DataRow drItem)
        {
            string empty = string.Empty;
            if (drItem["DefaultDate"].ToString() == "1")
            {
                empty = "Today";
            }
            else if (drItem["DefaultDate"].ToString() == "2")
            {
                empty = "This Week";
            }
            else if (drItem["DefaultDate"].ToString() != "3")
            {
            }
            else
            {
                empty = "This Month";
            }
            return empty;
        }

        public void lnkSavesettings_Click(object sender, EventArgs e)
        {
            dashboardestimate.Dashboard_Widget_Delete(Convert.ToInt32(this.Session["UserID"]));
            if (this.hdnLeftZoneIds.Value != null)
            {
                string[] strArrays = this.hdnLeftZoneIds.Value.Split(new char[] { ',' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string[] strArrays1 = strArrays[i].Split(new char[] { '\u005E' });
                    string[] strArrays2 = strArrays1[0].Split(new char[] { '\u005F' });
                    int num = 0;
                    long num1 = (long)0;
                    if ((int)strArrays1.Length > 1 && strArrays1[1].ToString() != "")
                    {
                        num = Convert.ToInt32(strArrays1[1].ToString());
                    }
                    if ((int)strArrays2.Length > 2 && strArrays2[2].ToString() != "")
                    {
                        string str = strArrays2[2].ToString().Replace("RadDock", "");
                        num1 = (long)Convert.ToInt32(str);
                    }
                    dashboardestimate.Dashboard_Widget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays[i].ToString(), num1, "left", num);
                }
            }
            if (this.hdnRightZoneIds.Value != null)
            {
                string[] strArrays3 = this.hdnRightZoneIds.Value.Split(new char[] { ',' });
                for (int j = 0; j < (int)strArrays3.Length - 1; j++)
                {
                    string[] strArrays4 = strArrays3[j].Split(new char[] { '\u005E' });
                    string[] strArrays5 = strArrays4[0].Split(new char[] { '\u005F' });
                    int num2 = 0;
                    long num3 = (long)0;
                    if ((int)strArrays4.Length > 1 && strArrays4[1].ToString() != "")
                    {
                        num2 = Convert.ToInt32(strArrays4[1].ToString());
                    }
                    if ((int)strArrays5.Length > 2 && strArrays5[2].ToString() != "")
                    {
                        string str1 = strArrays5[2].ToString().Replace("RadDock", "");
                        num3 = (long)Convert.ToInt32(str1);
                    }
                    dashboardestimate.Dashboard_Widget_Update(Convert.ToInt64(this.Session["UserID"]), strArrays3[j].ToString(), num3, "right", num2);
                }
            }
            this.hdnLeftZoneIds.Value = "";
            this.hdnRightZoneIds.Value = "";
            this.raddockzonefirst.Controls.Clear();
            this.raddockzonesecond.Controls.Clear();
            DataSet dataSet = dashboardestimate.PC_Dashboard_Select_WidgetsnewPC_Dashboard_Select_Widgetsnew((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.lnkSavesettings.Visible = false;
                return;
            }
            this.lnkSavesettings.Visible = true;
            for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
            {
                this.j = k;
                this.Session["DockHeading"] = "Dashboard";
                RadDock radDock = this.CreateRadDock(dataSet.Tables[0].Rows[k]);
                radDock.OnClientDragEnd = "OnClientDragEnd";
                try
                {
                    if (dataSet.Tables[0].Rows[k]["DockPosition"].ToString() == "left")
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                    else if (dataSet.Tables[0].Rows[k]["DockPosition"].ToString() == "right")
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else if (this.j % 2 != 0)
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                }
                catch
                {
                }
            }
            this.Session["msg"] = "msg";
            base.Response.Redirect(base.Request.Url.ToString());
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
                string str = empty;
                item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                item.Style.Add("cursor", "pointer");
                string text = string.Empty;
                text = item["contactname"].Text;
                TableCell tableCell = item["contactname"];
                string[] strArrays = new string[] { "<a style='color:#10357F;' href=", empty, ">", text, "</a>" };
                tableCell.Text = string.Concat(strArrays);
            }
        }

        private void OnRowDataBound_GridViewCustomerActivity(object sender, GridItemEventArgs e)
        {
            try
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
                    string str = empty;
                    item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item.Style.Add("cursor", "pointer");
                    string text = string.Empty;
                    text = item["Customername"].Text;
                    TableCell tableCell = item["Customername"];
                    string[] strArrays = new string[] { "<a style='color:#10357F;' href=", empty, ">", text, "</a>" };
                    tableCell.Text = string.Concat(strArrays);
                }
            }
            catch
            {
            }
        }

        private void OnRowDataBound_GridViewLatestNotes(object sender, GridItemEventArgs e)
        {
            try
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
                    string str = empty;
                    item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item.Style.Add("cursor", "pointer");
                    string text = string.Empty;
                    text = item["SpecificTo"].Text;
                    TableCell tableCell = item["SpecificTo"];
                    string[] strArrays = new string[] { "<a style='color:#10357F;' href=", empty, ">", text, "</a>" };
                    tableCell.Text = string.Concat(strArrays);
                }
            }
            catch
            {
            }
        }

        private void OnRowDataBound_GridViewTAsk(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    QueryString queryString = new QueryString()
                {
                    { "clientid", dataItem["TypeID"].ToString() },
                    { "isnew", "2" },
                    { "bypass", "1" },
                    { "type", dataItem["CustomerType"].ToString() }
                };
                    string empty = string.Empty;
                    empty = string.Concat(this.strSitepath, "client/client_detail.aspx");
                    QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                    empty = string.Concat(empty, queryString1.ToString());
                    GridDataItem item = (GridDataItem)e.Item;
                    string str = empty;
                    item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item.Style.Add("cursor", "pointer");
                    string text = string.Empty;
                    text = item["contactname"].Text;
                    TableCell tableCell = item["contactname"];
                    string[] strArrays = new string[] { "<a style='color:#10357F;' href=", empty, ">", text, "</a>" };
                    tableCell.Text = string.Concat(strArrays);
                }
            }
            catch
            {
            }
        }

        private void OnRowDataBound_GridViewTaskCall(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                QueryString queryString = new QueryString()
            {
                { "clientid", dataItem["clientid"].ToString() },
                { "isnew", "2" },
                { "bypass", "1" },
                { "type", dataItem["CustomerType"].ToString() },
                { "TaskID", dataItem["TaskID"].ToString() },
                { "ActivityType", dataItem["ActivityType"].ToString() }
            };
                string empty = string.Empty;
                string str = string.Empty;
                empty = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                empty = string.Concat(empty, queryString1.ToString());
                GridDataItem item = (GridDataItem)e.Item;
                str = empty;


                DataTable _dt = dashboardestimate.PC_Get_AccessRights((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
                bool isAdd = false;
                bool isEdit = false;
                foreach (DataRow _row in _dt.Rows)
                {
                    isAdd = Convert.ToBoolean(_row["isAdd"].ToString());
                    isEdit = Convert.ToBoolean(_row["isEdit"].ToString());

                }
                if (isAdd || isEdit)
                {
                    item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item.Style.Add("cursor", "pointer");
                }
                else
                {
                    item.Style.Add("cursor", "default");
                    empty = "#";
                }



                //item.Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                //item.Style.Add("cursor", "pointer");
                string text = string.Empty;
                this.Session["Popup"] = "Popup";
                text = item["contactname"].Text;
                TableCell tableCell = item["contactname"];
                string[] strArrays = new string[] { "<a style='color:#10357F;' href=", empty, ">", text, "</a>" };
                tableCell.Text = string.Concat(strArrays);
                if (item["ActivityType"].Text == "Task")
                {
                    item["ActivityType"].Text = "<img style='color:#10357F; margin-left:-6px;' src='images/Tasks.png' alt='Task' title='Task'/>";
                    return;
                }
                item["ActivityType"].Text = "<img style='color:#10357F;margin-left:-7px; margin-top:3px;' src='images/Call.png' alt='Call' title='Call'/>";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lnkSavesettings.Text = this.objLangClass.GetLanguageConversion("Save_Current_Layout");
            this.dockExchangeInformation.Title = this.objLangClass.GetLanguageConversion("Showing_Activities_for_Today");
            this.lblNowidgets.Text = this.objLangClass.GetLanguageConversion("No_Widgets_found");
            this.ddlCallTaskEvent.Items[0].Text = this.objLangClass.GetLanguageConversion("All");
            this.ddlCallTaskEvent.Items[1].Text = this.objLangClass.GetLanguageConversion("Call");
            this.ddlCallTaskEvent.Items[2].Text = this.objLangClass.GetLanguageConversion("Task");
            this.RadGridTodayAdmin.Columns[0].HeaderText = this.objLangClass.GetLanguageConversion("Action").ToString();
            this.RadGridTodayAdmin.Columns[1].HeaderText = this.objLangClass.GetLanguageConversion("Time").ToString();
            this.RadGridTodayAdmin.Columns[2].HeaderText = this.objLangClass.GetLanguageConversion("Subject").ToString();
            this.RadGridTodayAdmin.Columns[3].HeaderText = this.objLangClass.GetLanguageConversion("Contact").ToString();
            this.RadGridTodayAdmin.Columns[4].HeaderText = this.objLangClass.GetLanguageConversion("Phone").ToString();
            this.RadGridTodayAdmin.Columns[5].HeaderText = this.objLangClass.GetLanguageConversion("Assigned_To").ToString();
            this.RadGridTodayAdmin.Columns[6].HeaderText = this.objLangClass.GetLanguageConversion("Status").ToString();
            this.Connectionstr = this.commclass.strConnection;
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            compid = Convert.ToInt32(this.Session["CompanyID"].ToString());
            usrid = Convert.ToInt32(this.Session["UserID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.BindMiniWidgets();
            if (this.objBase.Return_IsEnable_CRM(Convert.ToInt32(this.CompanyID)).Trim().ToLower() == "false")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "welcome.aspx"));
            }
            if (this.Session["msg"] != null)
            {
                this.objBase.Message_Display("Current Layout Saved Successfully", "msg-success", this.plhMessage);
                this.Session["msg"] = null;
            }
            global.pageName = "Home";
            this.gloobj.setpagename("Home");
            base.Title = (new languageClass()).convert(global.pageTitle(this.objBase.ReturnScreenName("Dashboard", 2, "p") ?? "", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.tabcolor = this.objpage.colorCode(Convert.ToInt32(this.Session["companyid"]), "Home");
            this.txtdate.Attributes.Add("onfocus", "javascript:InsertSearchtext1('f');");
            this.txtdate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;lcs(this,'", this.DateFormat, "');"));
            this.txtdate.Attributes.Add("onblur", "javascript:InsertSearchtext1('b');");
            bool flag = false;
            foreach (DataRow row in CompanyBasePage.Select_Isadmin(this.CompanyID, this.UserID).Rows)
            {
                flag = Convert.ToBoolean(row["IsAdmin"].ToString());
            }
            if (!flag)
            {
                this.RadDockAssignto.Visible = false;
                this.divddlAssignto.Style.Add("display", "none");
            }
            else
            {
                this.RadDockAssignto.Visible = true;
                this.divddlAssignto.Style.Add("display", "none");
            }
            if (!base.IsPostBack)
            {
                this.BindUserDrop();
                this.BindTodayGrid();
                this.BindWeekGrid();
                this.BindTodayAdminGrid();
                this.BindScheduler();
                commonClass _commonClass = this.commclass;
                DateTime now = DateTime.Now;
                string str = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), Convert.ToInt32(this.CompanyID), Convert.ToInt32(this.UserID), false);
                string[] strArrays = str.Split(new char[] { ' ' });
                this.txtdate.Text = strArrays[0].ToString();
                this.raddockzonefirst.Controls.Clear();
                this.raddockzonesecond.Controls.Clear();
            }
            DataTable dataTable = dashboardestimate.PC_Dashboard_Select_Widgets((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
            if (dataTable.Rows.Count <= 0)
            {
                this.raddockzonefirst.Visible = false;
                this.raddockzonesecond.Visible = false;
                this.RadDockZoneTopLeft.Style.Add("margin-top", "0px;");
                this.divddlAssignto.Style.Add("margin-top", "0px;");
                this.lnkSavesettings.Visible = false;
                if (flag)
                {
                    this.RadDockAssignto.Visible = true;
                    this.divlblNowidgets.Style.Add("display", "block");
                    this.divddlAssignto.Style.Add("display", "none");
                    return;
                }
                this.RadDockAssignto.Visible = false;
                this.divlblNowidgets.Style.Add("display", "block");
                this.divddlAssignto.Style.Add("display", "none");
                return;
            }
            this.raddockzonefirst.Visible = true;
            this.raddockzonesecond.Visible = true;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                this.j = i;
                this.Session["DockHeading"] = "Dashboard";
                RadDock radDock = this.CreateRadDock(dataTable.Rows[i]);
                if (dataTable.Rows[i]["IsSpreadOverTwoColumns"].ToString().ToLower() != "true")
                {
                    if (dataTable.Rows[i]["DockPosition"].ToString() == "left")
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                    else if (dataTable.Rows[i]["DockPosition"].ToString() == "right")
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else if (this.j % 2 != 0)
                    {
                        this.raddockzonesecond.Controls.Add(radDock);
                    }
                    else
                    {
                        this.raddockzonefirst.Controls.Add(radDock);
                    }
                }
                else if (dataTable.Rows[i]["GraphType"].ToString().ToLower() != "pie")
                {
                    this.raddockzonetop.Controls.Add(radDock);
                }
                else if (dataTable.Rows[i]["DockPosition"].ToString() == "left")
                {
                    this.raddockzonefirst.Controls.Add(radDock);
                }
                else if (dataTable.Rows[i]["DockPosition"].ToString() == "right")
                {
                    this.raddockzonesecond.Controls.Add(radDock);
                }
                else if (this.j % 2 != 0)
                {
                    this.raddockzonesecond.Controls.Add(radDock);
                }
                else
                {
                    this.raddockzonefirst.Controls.Add(radDock);
                }
            }
            DataTable _dt = dashboardestimate.PC_Get_AccessRights((long)Convert.ToInt32(this.Session["CompanyID"]), (long)Convert.ToInt32(this.Session["UserID"]));
            bool isAdd = false;
            bool isEdit = false;
            foreach (DataRow _row in _dt.Rows)
            {
                isAdd = Convert.ToBoolean(_row["isAdd"].ToString());
                isEdit = Convert.ToBoolean(_row["isEdit"].ToString());

            }
            if (isAdd || isEdit)
            {
                this.lnkSavesettings.Enabled = true;
                this.btnCustomize.Enabled = true;
                this.lnkSavesettings.Style.Add("cursor", "pointer");
            }
            else
            {
                this.lnkSavesettings.Enabled = false;
                this.btnCustomize.Enabled = false;
                this.lnkSavesettings.Style.Add("cursor", "default");

            }
        }
        public class obj
        {
            public List<string> data { get; set; }
            public List<double> targets { get; set; }
            public List<double> subtotal { get; set; }
            public List<double> lastyeardata { get; set; }
            public List<string> lastyeardates { get; set; }
            public List<string> currency { get; set; }
            public string format { get; set; }
        }

        [WebMethod]
        public static dashboard.obj GetDataMonthly()
        {
            dashboard.obj o = new dashboard.obj();

            DataSet dataset = dashboardestimate.Dashboard_Select_DailyOrMonthlyJobTotal(compid, 12, "Monthly", usrid);
            DataTable dt = dashboardestimate.Dashboard_Select_LastYearDailyOrMonthlyJobTotal(compid, 12, "Monthly");
            List<string> months = new List<string>();
            List<double> targets = new List<double>();
            List<double> subtotal = new List<double>();
            List<double> lastyeatdata = new List<double>();
            List<string> currency = new List<string>();
            foreach (DataRow monthlyData in dataset.Tables[0].Rows)
            {
                try
                {
                    months.Add(monthlyData["Month"].ToString());
                    subtotal.Add(Convert.ToDouble(monthlyData["SubTotal"]));
                    targets.Add(Convert.ToDouble(monthlyData["MonthlyTarget"]));
                    currency.Add(ConnectionClass.CurrencySymbol);
                }
                catch (Exception)
                {
                }
            }
            foreach (DataRow monthlyData in dt.Rows)
            {

                lastyeatdata.Add(Convert.ToDouble(monthlyData["SubTotal"]));

            }

            o.data = months;
            o.subtotal = subtotal;
            o.currency = currency;
            o.format = format.ToUpper();
            if (monthlyTarget)
                o.targets = targets;
            else
                o.targets = null;

            if (monthlyLastyear)
                o.lastyeardata = lastyeatdata;
            else
                o.lastyeardata = null;



            return o;
        }


        static DataTable GetCommonRecords(DataTable table1, DataTable table2, string columnToCompare)
        {
            DataTable result = new DataTable();

            // Add columns to the result DataTable
            foreach (DataColumn col in table1.Columns)
            {
                result.Columns.Add(col.ColumnName, col.DataType);
            }

            // Iterate through rows of the first DataTable
            foreach (DataRow row1 in table1.Rows)
            {
                object valueToCompare = row1[columnToCompare];

                // Check if the value exists in the specified column of the second DataTable
                DataRow[] matchingRows = table2.Select($"{columnToCompare} = '{valueToCompare}'");

                if (matchingRows.Length > 0)
                {
                    // Add the row to the result DataTable
                    result.ImportRow(row1);
                }
            }

            return result;
        }
        public class missingDateMonth
        {
            public int date { get; set; }
            public int month { get; set; }
            public int year { get; set; }
        }


        static List<missingDateMonth> ConvertDataTableToDates(DataTable dataTable)
        {
            List<missingDateMonth> dates = new List<missingDateMonth>();
            missingDateMonth obj;
            foreach (DataRow row in dataTable.Rows)
            {
                int date = Convert.ToInt32(row["Day"]); // Assuming "Date" is the column name for dates
                int month = Convert.ToInt32(row["Month"]); // Assuming "Date" is the column name for dates
                int year = Convert.ToInt32(row["Year"]); // Assuming "Date" is the column name for dates
                obj = new missingDateMonth();
                obj.date = date;
                obj.month = month;
                obj.year = year;
                dates.Add(obj);
            }
            return dates;
        }
        static List<int> ConvertDataTableToDatesint(DataTable dataTable)
        {
            List<int> dates = new List<int>();

            foreach (DataRow row in dataTable.Rows)
            {
                int date = Convert.ToInt32(row["Day"]); // Assuming "Date" is the column name for dates

                dates.Add(date);
            }
            return dates;
        }

        static List<missingDateMonth> IdentifyMissingDates(List<missingDateMonth> current, List<int> last)
        {
            List<missingDateMonth> missingDates = new List<missingDateMonth>();
            missingDateMonth obj;
            foreach (missingDateMonth dateA in current)
            {
                if (!last.Contains(dateA.date))
                {

                    missingDates.Add(dateA);
                }
            }
            return missingDates;
        }

        static DataTable addData(DataTable dataTable, List<missingDateMonth> data)
        {
            foreach (missingDateMonth misssingdata in data)
            {
                DataRow customRow = dataTable.NewRow();
                string formattedDate = "";

                if (format.ToLower() == "dd/mm/yyyy")
                {
                    formattedDate = misssingdata.date + "/" + (misssingdata.month - 1) + "/" + misssingdata.year;
                }
                else
                {
                    formattedDate = (misssingdata.month - 1) + "/" + misssingdata.date + "/" + misssingdata.year;
                }
                // Format the DateTime object into dd/MM/yyyy format

                customRow["Createddate"] = formattedDate;
                customRow["Day"] = misssingdata.date;
                customRow["Month"] = misssingdata.month - 1;
                customRow["Year"] = misssingdata.year;
                customRow["DailyTarget"] = 0.00;
                customRow["SubTotal"] = 0.00;
                dataTable.Rows.Add(customRow);
            }
            return dataTable;
        }

        static DataTable SortDataTable(DataTable table)
        {
            // Convert DataTable to collection of DataRow objects and order them using LINQ
            var orderedRows = table.AsEnumerable()
                                   .OrderBy(row => row.Field<int>("Month"))
                                   .ThenBy(row => row.Field<int>("Day"));

            // Create a new DataTable with the same schema as the original table
            DataTable sortedTable = table.Clone();

            // Add sorted rows to the new DataTable
            foreach (DataRow row in orderedRows)
            {
                sortedTable.ImportRow(row);
            }

            return sortedTable;
        }




        [WebMethod]
        public static dashboard.obj GetDataDaily()
        {
            dashboard.obj o = new dashboard.obj();

            DataSet dataset = dashboardestimate.Dashboard_Select_DailyOrMonthlyJobTotal(compid, 12, "Daily", usrid);
            DataTable dt = dashboardestimate.Dashboard_Select_LastYearDailyOrMonthlyJobTotal(compid, 12, "Daily");


            List<missingDateMonth> currentmonthdates = ConvertDataTableToDates(dataset.Tables[0]);
            List<int> lastmonthsdates = ConvertDataTableToDatesint(dt);
            List<missingDateMonth> missingDates = IdentifyMissingDates(currentmonthdates, lastmonthsdates);

            DataTable lastyearupdatedData = addData(dt, missingDates);
            DataTable sortedTable = SortDataTable(lastyearupdatedData);

            string columnToCompare = "Day";

            DataTable commonRecords = GetCommonRecords(dataset.Tables[0], sortedTable, columnToCompare);

            List<string> Days = new List<string>();
            List<double> targets = new List<double>();
            List<double> subtotal = new List<double>();
            List<double> lastyeatdata = new List<double>();
            List<string> lastyeatdates = new List<string>();
            List<string> currency = new List<string>();
            foreach (DataRow monthlyData in commonRecords.Rows)
            {
                try
                {
                    Days.Add(monthlyData["createddate"].ToString());
                    subtotal.Add(Convert.ToDouble(monthlyData["SubTotal"]));
                    targets.Add(Convert.ToDouble(monthlyData["DailyTarget"]));
                    currency.Add(ConnectionClass.CurrencySymbol);
                }
                catch (Exception)
                {
                }
            }
            foreach (DataRow monthlyData in sortedTable.Rows)
            {
                lastyeatdata.Add(Convert.ToDouble(monthlyData["SubTotal"]));
                lastyeatdates.Add(monthlyData["CreatedDate"].ToString());
            }

            o.data = Days;
            o.lastyeardates = lastyeatdates;
            o.subtotal = subtotal;
            o.currency = currency;
            o.format = format.ToUpper();
            if (dailyTarget)
                o.targets = targets;
            else
                o.targets = null;

            if (dailyLastyear)
                o.lastyeardata = lastyeatdata;
            else
                o.lastyeardata = null;

            return o;
        }
        private void radChart_EstimateJobInvoiceItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {
            if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
            {
                if (((DataRowView)e.DataItem)["SalespersonName"].ToString().Length <= 10)
                {
                    e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    return;
                }
                e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString()).Substring(0, 10), "...");
                e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                return;
            }
            if (((DataRowView)e.DataItem)["SalespersonName"].ToString().Length <= 10)
            {
                try
                {
                    e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString()).Substring(0, 10), "...");
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["SalespersonName"].ToString());
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
                    if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 10)
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                    else
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 10), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                }
                else if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 10)
                {
                    try
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 10), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()));
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

        private void radChart_ItemDataBound1(object sender, ChartItemDataBoundEventArgs e)
        {
            try
            {
                if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
                {
                    if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 10)
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(string.Concat(((DataRowView)e.DataItem)["EstimateStatus"].ToString(), "\r\nTotal Count: ", ((DataRowView)e.DataItem)["TotalNoOfCount"].ToString())));
                    }
                    else
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 10), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(string.Concat(((DataRowView)e.DataItem)["EstimateStatus"].ToString(), "\r\nTotal Count: ", ((DataRowView)e.DataItem)["TotalNoOfCount"].ToString())));
                    }
                }
                else if (((DataRowView)e.DataItem)["EstimateStatus"].ToString().Length <= 10)
                {
                    try
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(string.Concat(((DataRowView)e.DataItem)["EstimateStatus"].ToString(), "\r\nTotal Count: ", ((DataRowView)e.DataItem)["TotalNoOfCount"].ToString())));
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["EstimateStatus"].ToString()).Substring(0, 10), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat("Status: ", this.objBase.SpecialDecode(string.Concat(((DataRowView)e.DataItem)["EstimateStatus"].ToString(), "\r\nTotal Count: ", ((DataRowView)e.DataItem)["TotalNoOfCount"].ToString())));
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

        private void radChart_ItemDataBoundPie1(object sender, ChartItemDataBoundEventArgs e)
        {
            try
            {


                if (((DataRowView)e.DataItem)["AccountingCode"].ToString().Length > 30)
                {
                    try
                    {
                        ((DataRowView)e.DataItem)["AccountingCode"] = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["AccountingCode"].ToString()).Substring(0, 30), "...");

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

        private void radChart_ItemDataBoundPie(object sender, ChartItemDataBoundEventArgs e)
        {
            try
            {
                if (((RadChart)sender).PlotArea.XAxis.Items.Count > 8)
                {
                    if (((DataRowView)e.DataItem)["ValueType"].ToString().Length <= 15)
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["ValueType"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat(((DataRowView)e.DataItem)["ValueType"].ToString(), ": ", ((DataRowView)e.DataItem)["Amount"].ToString());
                    }
                    else
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["ValueType"].ToString()).Substring(0, 15), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat(((DataRowView)e.DataItem)["ValueType"].ToString(), ": ", ((DataRowView)e.DataItem)["Amount"].ToString());
                    }
                }
                else if (((DataRowView)e.DataItem)["ValueType"].ToString().Length <= 15)
                {
                    try
                    {
                        e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["ValueType"].ToString());
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat(((DataRowView)e.DataItem)["ValueType"].ToString(), ": ", ((DataRowView)e.DataItem)["Amount"].ToString());
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["ValueType"].ToString()).Substring(0, 15), "...");
                        e.SeriesItem.ActiveRegion.Tooltip = string.Concat(((DataRowView)e.DataItem)["ValueType"].ToString(), ": ", ((DataRowView)e.DataItem)["Amount"].ToString());
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
                    e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    return;
                }
                e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString()).Substring(0, 10), "...");
                e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                return;
            }
            if (((DataRowView)e.DataItem)["StatusName"].ToString().Length <= 20)
            {
                try
                {
                    e.SeriesItem.Name = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    e.SeriesItem.Name = string.Concat(this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString()).Substring(0, 20), "...");
                    e.SeriesItem.ActiveRegion.Tooltip = this.objBase.SpecialDecode(((DataRowView)e.DataItem)["StatusName"].ToString());
                }
                catch
                {
                }
            }
        }

        protected void RadGridToday_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("CallIcon");
                    ImageButton imageButton1 = (ImageButton)e.Item.FindControl("TaskIcon");
                    ImageButton imageButton2 = (ImageButton)e.Item.FindControl("EventIcon");
                    Label str = (Label)e.Item.FindControl("lblSubject");
                    Label label = (Label)e.Item.FindControl("lblContactName");
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    if (dataItem["SectionName"].ToString().ToLower() == "task")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "block");
                        imageButton2.Style.Add("display", "none");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "event")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "block");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "call")
                    {
                        imageButton.Style.Add("display", "block");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "none");
                    }
                    string str1 = "";
                    str1 = (dataItem["Subject"].ToString().Length <= 24 ? dataItem["Subject"].ToString() : string.Concat(dataItem["Subject"].ToString().Substring(0, 24), "..."));
                    str.Text = str1;
                    str.ToolTip = dataItem["Subject"].ToString();
                    string str2 = "";
                    str2 = (dataItem["ContactName"].ToString().Length <= 18 ? dataItem["ContactName"].ToString() : string.Concat(dataItem["ContactName"].ToString().Substring(0, 18), "..."));
                    label.Text = str2;
                    label.ToolTip = dataItem["ContactName"].ToString();
                }
            }
            catch
            {
            }
        }

        protected void RadGridToday_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_Today((long)this.ClientID, (long)this.CompanyID, this.UserID, "All");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadGridToday.DataSource = dataSet;
            }
        }

        protected void RadGridTodayAdmin_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("CallIconAdmin");
                    ImageButton imageButton1 = (ImageButton)e.Item.FindControl("TaskIconAdmin");
                    ImageButton imageButton2 = (ImageButton)e.Item.FindControl("EventIconAdmin");
                    Label str = (Label)e.Item.FindControl("lblSubjectAdmin");
                    Label label = (Label)e.Item.FindControl("lblContactNameAdmin");
                    Label label1 = (Label)e.Item.FindControl("lblAssignToAdmin");
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    if (dataItem["SectionName"].ToString().ToLower() == "task")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "block");
                        imageButton2.Style.Add("display", "none");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "event")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "block");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "call")
                    {
                        imageButton.Style.Add("display", "block");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "none");
                    }
                    string str1 = "";
                    str1 = (dataItem["Subject"].ToString().Length <= 20 ? dataItem["Subject"].ToString() : string.Concat(dataItem["Subject"].ToString().Substring(0, 20), "..."));
                    str.Text = str1;
                    str.ToolTip = dataItem["Subject"].ToString();
                    string str2 = "";
                    str2 = (dataItem["ContactName"].ToString().Length <= 18 ? dataItem["ContactName"].ToString() : string.Concat(dataItem["ContactName"].ToString().Substring(0, 18), "..."));
                    label.Text = str2;
                    label.ToolTip = dataItem["ContactName"].ToString();
                    if (dataItem["AssignTo"].ToString().Length <= 18)
                    {
                        this.objBase.SpecialDecode(dataItem["AssignTo"].ToString());
                    }
                    else
                    {
                        string.Concat(this.objBase.SpecialDecode(dataItem["AssignTo"].ToString().Substring(0, 18)), "...");
                    }
                    label1.Text = this.objBase.SpecialDecode(dataItem["AssignTo"].ToString());
                    label1.ToolTip = this.objBase.SpecialDecode(dataItem["AssignTo"].ToString());
                }
            }
            catch
            {
            }
        }

        protected void RadGridTodayAdmin_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskCall_Today_ForallUsers((long)this.CompanyID, (long)0);
            this.RadGridTodayAdmin.DataSource = dataSet;
        }

        protected void RadGridWeeks_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton imageButton = (ImageButton)e.Item.FindControl("CallIconWeek");
                    ImageButton imageButton1 = (ImageButton)e.Item.FindControl("TaskIconWeek");
                    ImageButton imageButton2 = (ImageButton)e.Item.FindControl("EventIconWeek");
                    Label str = (Label)e.Item.FindControl("lblDueDate");
                    Label label = (Label)e.Item.FindControl("lblSubject1");
                    Label str1 = (Label)e.Item.FindControl("lblContactName1");
                    DataRowView dataItem = (DataRowView)e.Item.DataItem;
                    string str2 = this.commclass.Eprint_return_DateTime_Before_View(dataItem["DueDate"].ToString(), this.CompanyID, this.UserID, false);
                    string[] strArrays = str2.Split(new char[] { ' ' });
                    str.Text = strArrays[0].ToString();
                    if (dataItem["SectionName"].ToString().ToLower() == "task")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "block");
                        imageButton2.Style.Add("display", "none");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "event")
                    {
                        imageButton.Style.Add("display", "none");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "block");
                    }
                    if (dataItem["SectionName"].ToString().ToLower() == "call")
                    {
                        imageButton.Style.Add("display", "block");
                        imageButton1.Style.Add("display", "none");
                        imageButton2.Style.Add("display", "none");
                    }
                    string str3 = "";
                    str3 = (dataItem["Subject"].ToString().Length <= 23 ? dataItem["Subject"].ToString() : string.Concat(dataItem["Subject"].ToString().Substring(0, 23), "..."));
                    label.Text = str3;
                    label.ToolTip = dataItem["Subject"].ToString();
                    string str4 = "";
                    str4 = (dataItem["ContactName"].ToString().Length <= 18 ? dataItem["ContactName"].ToString() : string.Concat(dataItem["ContactName"].ToString().Substring(0, 18), "..."));
                    str1.Text = str4;
                    str1.ToolTip = dataItem["ContactName"].ToString();
                }
            }
            catch
            {
            }
        }

        protected void RadGridWeeks_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_ThiSweek(this.ClientID, this.CompanyID, this.UserID, Convert.ToDateTime(this.SelectedDate));
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadGridWeeks.DataSource = dataSet;
            }
        }

        protected void RadScheduler1_OnAppointmentClick(object sender, SchedulerEventArgs e)
        {
            this.SectionName = e.Appointment.Description.ToString();
            this.AppID = Convert.ToInt32(e.Appointment.ID);
            DataSet dataSet = DepartmentBaseClass.Crm_Select_TaskEventCall_Scheduler_Details(Convert.ToInt64(this.AppID), this.SectionName);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (this.SectionName.ToString().ToLower() == "call")
                {
                    this.lblSectionName.Text = row["Section"].ToString();
                    this.lblTime.Text = row["CallStartTime"].ToString();
                    this.lblSubjectDetail.Text = row["Subject"].ToString();
                    this.lblStatues.Text = row["CallDetails"].ToString();
                }
                else if (this.SectionName.ToString().ToLower() != "task")
                {
                    this.lblSectionName.Text = row["Section"].ToString();
                    this.lblTime.Text = row["EventTime"].ToString();
                    this.lblSubjectDetail.Text = row["Subject"].ToString();
                }
                else
                {
                    this.lblSectionName.Text = row["Section"].ToString();
                    this.lblTime.Text = row["TaskTime"].ToString();
                    this.lblSubjectDetail.Text = row["Subject"].ToString();
                    this.lblStatues.Text = row["TaskStatus"].ToString();
                }
                this.lblContact.Text = this.objBase.SpecialDecode(row["ContactName"].ToString());
                this.lblPhone.Text = row["PersonalPhone"].ToString();
                this.lblAssignedTo.Text = this.objBase.SpecialDecode(row["AssignTO"].ToString());
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "_showconfirm", "javascript:OpeneRadWindow();", true);
        }

        private void rdpCalender_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            try
            {
                RadDatePicker radDatePicker = (RadDatePicker)sender;
                string[] strArrays = radDatePicker.ID.Split(new char[] { '\u005F' });
                RadDock radDock = (RadDock)this.raddockzonefirst.FindControl(string.Concat("radDock", strArrays[1].ToString()));
                RadGrid radGrid = (RadGrid)radDock.ContentContainer.FindControl(string.Concat("radGrid_", strArrays[1].ToString()));
                if (radDatePicker.SelectedDate.HasValue)
                {
                    commonClass _commonClass = this.commclass;
                    string dateFormat = this.DateFormat;
                    DateTime? selectedDate = radDatePicker.SelectedDate;
                    this.SelectedDate = _commonClass.eprint_checkdateformat_returnonlymmddyyyy(dateFormat, selectedDate.ToString());
                    DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_ThiSweek(this.ClientID, this.CompanyID, this.UserID, Convert.ToDateTime(this.SelectedDate));
                    radGrid.DataSource = dataSet;
                    radGrid.DataBind();
                }
            }
            catch
            {
            }
        }

        [WebMethod]
        public static void setResolution(int width, int height)
        {
            dashboard.ScreenResolution = new Size(width, height);
        }

        protected void txtdate_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtdate.Text != "")
                {
                    this.SelectedDate = this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtdate.Text);
                    DataSet dataSet = DepartmentBaseClass.Dashboard_Select_TaskEventCall_ThiSweek(this.ClientID, this.CompanyID, this.UserID, Convert.ToDateTime(this.SelectedDate));
                    this.RadGridWeeks.DataSource = dataSet;
                    this.RadGridWeeks.DataBind();
                }
            }
            catch
            {
            }
        }
    }
}