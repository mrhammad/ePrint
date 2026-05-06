using Printcenter.DataAccessLayer.dashboard;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.dashboardNew
{
	public class dashboardNew
	{
		public dashboardNew()
		{
		}

		public static DataSet CRM_Dashboard_select_Dock(long CompanyID, int CreatedBy)
		{
			return (new DbDashboard()).CRM_Dashboard_select_Dock(CompanyID, CreatedBy);
		}

		public static DataSet Dashboard_CustomerActivity_Select(long CompanyID, int UserID, string CompanyType, int NoOFRecords, string Columns)
		{
			return (new DbDashboard()).Dashboard_CustomerActivity_Select(CompanyID, UserID, CompanyType, NoOFRecords, Columns);
		}

		public static DataSet Dashboard_LatestNotes_Select(long clientid, long companyid, string companytype, string showrecords, long salespersonid, int noofrecords, string columns)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_LatestNotes_Select(clientid, companyid, companytype, showrecords, salespersonid, noofrecords, columns);
		}

		public static void Dashboard_MiniWidget_Delete(int UserID)
		{
			(new DbDashboard()).Dashboard_MiniWidget_Delete(UserID);
		}

		public static void Dashboard_MiniWidget_Update(long UserID, string HomePageState, long CopyMasterId, string dockposition, int indexno)
		{
			(new DbDashboard()).Dashboard_MiniWidget_Update(UserID, HomePageState, CopyMasterId, dockposition, indexno);
		}

		public static DataSet Dashboard_Select_ByDueDate(long CompanyId, string WhereCondition, int noOfRecords, string ModuleName, string StatusID, bool ShowArchvedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Select_ByDueDate(CompanyId, WhereCondition, noOfRecords, ModuleName, StatusID, ShowArchvedrecords);
		}

		public static DataSet Dashboard_Select_ByDueDate_SplitItem(long CompanyId, string WhereCondition, int noOfRecords, string ModuleName, string StatusID, bool ShowArchvedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Select_ByDueDate_SplitItem(CompanyId, WhereCondition, noOfRecords, ModuleName, StatusID, ShowArchvedrecords);
		}
		public static DataSet Dashboard_GetInvoiceCodesPercentage(int DateType,long CompanyId)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_GetInvoiceCodesPercentage(DateType,CompanyId);
		}
		public static DataSet Dashboard_GetEstStatusCount(long CompanyId)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_GetEstStatusCount(CompanyId);
		}
		public static DataSet Dashboard_Select_CallVS(long CompanyId, string DateType, string SalesPersonID)
		{
			return (new DbDashboard()).Dashboard_Select_CallVS(CompanyId, DateType, SalesPersonID);
		}

		public static DataSet Dashboard_Select_CallVSCount(long CompanyId, string DateType, string SalesPersonID)
		{
			return (new DbDashboard()).Dashboard_Select_CallVSCount(CompanyId, DateType, SalesPersonID);
		}

		public static DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords)
		{
			return (new DbDashboard()).Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus(CompanyId, SalesPersonID, ModuleName, StatusID, ShowArchivedrecords);
		}

		public static DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItem(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords)
		{
			return (new DbDashboard()).Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItem(CompanyId, SalesPersonID, ModuleName, StatusID, ShowArchivedrecords);
		}
		public static DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords, string dateType, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(CompanyId, SalesPersonID, ModuleName, StatusID, ShowArchivedrecords,dateType,IsCalendarYear,StartDate,EndDate);
		}

		public static DataSet Dashboard_Select_Probalility(long CompanyId, string UserID, string Status, bool ShowArcihivedrecords)
		{
			return (new DbDashboard()).Dashboard_Select_Probalility(CompanyId, UserID, Status, ShowArcihivedrecords);
		}

		public static DataSet Dashboard_Select_Probalility_SplitItems(long CompanyId, string UserID, string Status, bool ShowArcihivedrecords)
		{
			return (new DbDashboard()).Dashboard_Select_Probalility_SplitItems(CompanyId, UserID, Status, ShowArcihivedrecords);
		}

		public static DataSet Dashboard_Select_ProbalilityPercent(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords)
		{
			return (new DbDashboard()).Dashboard_Select_ProbalilityPercent(CompanyId, Status, ModuleName, ShowArchivedRecords);
		}

		public static DataSet Dashboard_Select_ProbalilityPercent_SplitItem(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords)
		{
			return (new DbDashboard()).Dashboard_Select_ProbalilityPercent_SplitItem(CompanyId, Status, ModuleName, ShowArchivedRecords);
		}
		public static DataSet Dashboard_Select_ProbalilityPercent_SplitItemNew(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords, string DateType, string IsCalendarYear, string FromDate, string ToDate)
		{
			return (new DbDashboard()).Dashboard_Select_ProbalilityPercent_SplitItemNew(CompanyId, Status, ModuleName, ShowArchivedRecords, DateType, IsCalendarYear, FromDate, ToDate);
		}

		public static DataSet Dashboard_Select_SalesPersonByModule(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus)
		{
			return (new DbDashboard()).Dashboard_Select_SalesPersonByModule(CompanyId, SalesPerson, ModuleName, Status, ShowArchivedStatus);
		}

		public static DataSet Dashboard_Select_SalesPersonByModule_SplitItem(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus)
		{
			return (new DbDashboard()).Dashboard_Select_SalesPersonByModule_SplitItem(CompanyId, SalesPerson, ModuleName, Status, ShowArchivedStatus);
		}
		public static DataSet Dashboard_Select_SalesPersonByModule_SplitItemNew(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus, string DateType, string IsCalendarYear, string FromDate, string ToDate)
		{
			return (new DbDashboard()).Dashboard_Select_SalesPersonByModule_SplitItemNew(CompanyId, SalesPerson, ModuleName, Status, ShowArchivedStatus, DateType, IsCalendarYear, FromDate, ToDate);
		}
		public static DataSet Dashboard_Select_DailyOrMonthlyJobTotal(long CompanyId,int CopyMasterID,string DateType, int userid)
		{
			return (new DbDashboard()).Dashboard_Select_DailyOrMonthlyJobTotal(CompanyId, CopyMasterID,DateType,userid);
		}
		public static DataTable Dashboard_Select_LastYearDailyOrMonthlyJobTotal(long CompanyId, int CopyMasterID, string DateType)
		{
			return (new DbDashboard()).Dashboard_Select_LastYearDailyOrMonthlyJobTotal(CompanyId, CopyMasterID, DateType);
		}
		public static DataSet Dashboard_Select_TaskCall(long CompanyId, string whereConditions, int NoOfRecords, string RecordType, string SalesPersonID)
		{
			return (new DbDashboard()).Dashboard_Select_TaskCall(CompanyId, whereConditions, NoOfRecords, RecordType, SalesPersonID);
		}

		public static DataSet Dashboard_Select_TaskCall_ForAdmin(long CompanyId, int UserID, string whereConditions, int NoOfRecords, string RecordType, long CustomerID, long Salespersonid)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Select_TaskCall_ForAdmin(CompanyId, UserID, whereConditions, NoOfRecords, RecordType, CustomerID, Salespersonid);
		}

		public static DataSet Dashboard_Select_TaskEventCall_Today(long ClientID, long CompanyId, int UserID, string Type)
		{
			return (new DbDashboard()).Dashboard_Select_TaskEventCall_Today(ClientID, CompanyId, UserID, Type);
		}

		public static DataTable dashboard_state_select(int UserID)
		{
			return (new DbDashboard()).dashboard_state_select(UserID);
		}

		public static void dashboard_state_update(int UserID, string DBState)
		{
			(new DbDashboard()).dashboard_state_update(UserID, DBState);
		}

		public static DataSet Dashboard_Target_Actual_Date_Select(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Target_Actual_Date_Select(CompanyID, Salesperson, QuarterType, EstimateType, TargetRecordType, Status, ShowArcihivedrecords);
		}

		public static DataSet Dashboard_Target_Actual_Date_Select_SplitItem(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Target_Actual_Date_Select_SplitItem(CompanyID, Salesperson, QuarterType, EstimateType, TargetRecordType, Status, ShowArcihivedrecords);
		}

		public static DataSet Dashboard_Target_Actual_Date_SelectPie(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Target_Actual_Date_SelectPie(CompanyID, Salesperson, QuarterType, EstimateType, TargetRecordType, Status, ShowArcihivedrecords);
		}

		public static DataSet Dashboard_Target_Actual_Date_SelectPie_SplitItem(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
		{
			DbDashboard dbDashboard = new DbDashboard();
			return dbDashboard.Dashboard_Target_Actual_Date_SelectPie_SplitItem(CompanyID, Salesperson, QuarterType, EstimateType, TargetRecordType, Status, ShowArcihivedrecords);
		}

		public static void Dashboard_Widget_Delete(int UserID)
		{
			(new DbDashboard()).Dashboard_Widget_Delete(UserID);
		}

		public static void Dashboard_Widget_Update(long UserID, string HomePageState, long CopyMasterId, string dockposition, int indexno)
		{
			(new DbDashboard()).Dashboard_Widget_Update(UserID, HomePageState, CopyMasterId, dockposition, indexno);
		}

		public static DataSet Dashboard_WidgetTasks_Select(int CompanyID, int UserID, string DispType, string TaskStatus, int NoOfRecords)
		{
			return (new DbDashboard()).Dashboard_WidgetTasks_Select(CompanyID, UserID, DispType, TaskStatus, NoOfRecords);
		}

		public static DataSet GetFromUsertype_ShowAll(int companyid, int userid)
		{
			return (new DbDashboard()).GetFromUsertype_ShowAll(companyid, userid);
		}

		public static DataSet PC_Dashboard_Select_AppointmentsTaskscompletedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_AppointmentsTaskscompletedineprint(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_Callscompletedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Callscompletedineprint(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_DataForQuoteNumberCount(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_DataForQuoteNumberCount(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataTable PC_Dashboard_Select_MiniWidgets(long companyid, long userid)
		{
			return (new DbDashboard()).PC_Dashboard_Select_MiniWidgets(companyid, userid);
		}

		public static DataSet PC_Dashboard_Select_Newcustomerscreatedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Newcustomerscreatedineprint(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_Quoteconversionrate(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Quoteconversionrate(UserID, DateType, ArchivedRecords, CompanyID,  IsCalendarYear,  StartDate,  EndDate);
		}

		public static DataSet PC_Dashboard_Select_Saleslivejobsteam(string UserID, string DateType, bool ArchivedRecords, long CompanyID)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Saleslivejobsteam(UserID, DateType, ArchivedRecords, CompanyID);
		}

		public static DataSet PC_Dashboard_Select_SaleslivejobsteamWithValue(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate, string hostName)
		{
			return (new DbDashboard()).PC_Dashboard_Select_SaleslivejobsteamWithValue(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate,hostName);
		}

		public static DataSet PC_Dashboard_Select_Salesnumberofjobs(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Salesnumberofjobs(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_Salessubtotalvalueofjobs(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Salessubtotalvalueofjobs(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_SalesvalueofjobsGP(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_SalesvalueofjobsGP(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_SalesvalueofinvoicesGP(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_SalesvalueofinvoicesGP(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataSet PC_Dashboard_Select_SalesvalueofjobsGP_Percentage(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            return (new DbDashboard()).PC_Dashboard_Select_SalesvalueofjobsGP_Percentage(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
        }

        public static DataSet PC_Dashboard_Select_Valueofinvoicessubtotalfigure(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Valueofinvoicessubtotalfigure(UserID, DateType, ArchivedRecords, CompanyID, IsCalendarYear, StartDate, EndDate);
		}

		public static DataTable PC_Dashboard_Select_Widgets(long companyid, long userid)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Widgets(companyid, userid);
		}

        public static DataTable PC_Get_AccessRights(long companyid, long userid)
        {
            return (new DbDashboard()).PC_Get_AccessRights(companyid, userid);
        }
        public static DataSet PC_Dashboard_Select_WidgetsnewPC_Dashboard_Select_Widgetsnew(long companyid, long userid)
		{
			return (new DbDashboard()).PC_Dashboard_Select_Widgetsnew(companyid, userid);
		}

		public static DataTable PC_Select_SalesperSalespersonperMonth(long CompanyID, long SalesPersonID, long Range, string Type)
		{
			return (new DbDashboard()).PC_Select_SalesperSalespersonperMonth(CompanyID, SalesPersonID, Range, Type);
		}

		public static DataTable PC_Select_TaskCall_forwidgets(long CompanyID, long SalesPersonID, long Range, string Type)
		{
			return (new DbDashboard()).PC_Select_TaskCall_forwidgets(CompanyID, SalesPersonID, Range, Type);
		}

		public static DataTable Select_Estimate()
		{
			return (new DbDashboard()).Select_Estimate();
		}

		public static DataTable Select_Estimate_Converted()
		{
			return (new DbDashboard()).Select_Estimate_Converted();
		}

		public static DataTable Select_Estimate_Highest()
		{
			return (new DbDashboard()).Select_Estimate_Highest();
		}

		public static DataTable select_invoice_highest()
		{
			return (new DbDashboard()).select_invoice_highest();
		}

		public static DataTable select_invoice_latest()
		{
			return (new DbDashboard()).select_invoice_latest();
		}

		public static DataTable select_job_converted()
		{
			return (new DbDashboard()).select_job_converted();
		}

		public static DataTable select_job_highest()
		{
			return (new DbDashboard()).select_job_highest();
		}

		public static DataTable select_job_latest()
		{
			return (new DbDashboard()).select_job_latest();
		}
	}
}