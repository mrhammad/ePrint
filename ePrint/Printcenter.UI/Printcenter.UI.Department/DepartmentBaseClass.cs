using nmsCommon;
using Printcenter.BusinessAccessLayer.Department;
using System;
using System.Collections.Generic;
using System.Data;

namespace Printcenter.UI.Department
{
	public class DepartmentBaseClass : BasePage
	{
		public DepartmentBaseClass()
		{
		}

		public static DataTable address_select(int ClientID, int CompanyID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.address_select(ClientID, CompanyID, SelectAll);
		}

		public static DataTable address_select_for_filter(int ClientID, int CompanyID, string SelectAll, string WhereConditionAddress)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.address_select_for_filter(ClientID, CompanyID, SelectAll, WhereConditionAddress);
		}

		public static DataSet AddressAndCompanyname_select(int ClientID, int CompanyID, string SelectAll, Int32 PageSize, Int32 CurrentPageIndex, string SearchText)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.AddressAndCompanyname_select(ClientID, CompanyID, SelectAll, PageSize,CurrentPageIndex,SearchText);
		}

		public static bool CheckApproveEnable(long ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CheckApproveEnable(ClientID);
		}

		public static DataTable client_contacts_select(int ClientID, int CompanyID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.client_contacts_select(ClientID, CompanyID, SelectAll);
		}

		public static DataSet client_contacts_selectAll(int ClientID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.client_contacts_selectAll(ClientID, CompanyID);
		}

		public static void costcenter_details_delete(int CostCenterID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.costcenter_details_delete(CostCenterID);
		}

		public static void costcenter_details_insert(int CompanyID, int ClientID, string CostcenterCode, string CostcenterName, int isapplydept, int iscostdefault, int UserID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.costcenter_details_insert(CompanyID, ClientID, CostcenterCode, CostcenterName, isapplydept, iscostdefault, UserID);
		}

		public static DataTable costcenter_details_select(string CostCenterID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.costcenter_details_select(CostCenterID);
		}

		public static void costcenter_details_update(int CostCenterID, int ClientID, string CostcenterCode, string CostcenterName, int isapplydept, int iscostdefault, int UserID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.costcenter_details_update(CostCenterID, ClientID, CostcenterCode, CostcenterName, isapplydept, iscostdefault, UserID);
		}

		public static DataTable costcenter_getdefaultcenter(int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.costcenter_getdefaultcenter(ClientID);
		}

		public static DataTable costcenter_getdetails(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.costcenter_getdetails(CompanyID, ClientID);
		}

		public static DataTable costcenter_getdetails_for_filter(int CompanyID, int ClientID, string WhereConditionCostcenter)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.costcenter_getdetails_for_filter(CompanyID, ClientID, WhereConditionCostcenter);
		}

		public static DataSet CRM_Alluser_select(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Alluser_select(CompanyID);
		}

		public static List<CRMCallView> Crm_Call_Insert(int CompanyID, int ClientID, string Subject, string CallType, int CallPurpose, string CallDetails, int ContactID, string CallStartdate, string CallStartTime, int CallDurationMinutes, int CallDurationSeconds, string CallResult, int AssignedTo, string Description, bool isBillabel, int CreatedBy, int NotespageNummber, string CallEnddate, string ParentType, int ParentID, long ModuleID, string ModuleName, string ContactPhone, string ContactMobile, string DepartmentPhone)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Call_Insert(CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, CreatedBy, NotespageNummber, CallEnddate, ParentType, ParentID, Convert.ToInt64(ModuleID), ModuleName, ContactPhone, ContactMobile, DepartmentPhone);
		}

		public static List<CRMCallView> Crm_Call_Update(long CallID, int CompanyID, int ClientID, string Subject, string CallType, int CallPurpose, string CallDetails, int ContactID, string CallStartdate, string CallStartTime, int CallDurationMinutes, int CallDurationSeconds, string CallResult, int AssignedTo, string Description, bool isBillabel, int LastUpdatedBy, int NotespageNummber, string CallEnddate, string ContactPhone, string ContactMobile, string DepartmentPhone)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Call_Update(CallID, CompanyID, ClientID, Subject, CallType, CallPurpose, CallDetails, ContactID, CallStartdate, CallStartTime, CallDurationMinutes, CallDurationSeconds, CallResult, AssignedTo, Description, isBillabel, LastUpdatedBy, NotespageNummber, CallEnddate, ContactPhone, ContactMobile, DepartmentPhone);
		}

		public static List<NotesInsertSubject> Crm_Callsubject_Insert(long CompanyID, string StatusTitle, bool IsDefault, long UserID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Callsubject_Insert(CompanyID, StatusTitle, IsDefault, UserID);
		}

		public static List<CRMCallView> Crm_Completed_Call(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Completed_Call(ID, CompanyID, ClientId, Sectionname, NotespageNummber);
		}

		public static DataSet CRM_Contact_select(int CompanyID, int clientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Contact_select(CompanyID, clientID);
		}

		public static List<CRMContactNotesView> Crm_ContactNotes_Insert(int companyId, string sectionname, int sectionid, string filename, string filesize, int createUserId, string subject, string title, int NotespageNummber, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_ContactNotes_Insert(companyId, sectionname, sectionid, filename, filesize, createUserId, subject, title, NotespageNummber, ContactID);
		}

		public static List<CRMContactNotesView> Crm_ContactNotes_Update(int attachmentId, int companyId, string sectionname, int sectionid, string filename, string filesize, int modifyUserID, string subject, string title, int NotespageNummber, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_ContactNotes_Update(attachmentId, companyId, sectionname, sectionid, filename, filesize, modifyUserID, subject, title, NotespageNummber, ContactID);
		}

		public static List<CRMCloseActi> Crm_Delete_CloseActivities(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Delete_CloseActivities(ID, CompanyID, ClientId, Sectionname, NotespageNummber);
		}

		public static List<CRMContactNotesView> Crm_Delete_ContactNotes(int companyId, int sectionid, int attachmentId, int NotespageNummber, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Delete_ContactNotes(companyId, sectionid, attachmentId, NotespageNummber, ContactID);
		}

		public static List<CRMNotesView> Crm_Delete_Notes(int companyId, int sectionid, int attachmentId, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Delete_Notes(companyId, sectionid, attachmentId, NotespageNummber);
		}

		public static List<CRMCallView> Crm_Delete_OpenActivities(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Delete_OpenActivities(ID, CompanyID, ClientId, Sectionname, NotespageNummber);
		}

		public static List<CRMCallView> Crm_Delete_Task(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Delete_Task(ID, CompanyID, ClientId, Sectionname, NotespageNummber);
		}

		public static void Crm_DismissAlert_Notifications(long ID, long CompanyID, string SectionName)
		{
			Printcenter.BusinessAccessLayer.Department.Department.Crm_DismissAlert_Notifications(ID, CompanyID, SectionName);
		}

		public static List<CallItemsEdit> Crm_Edit_Call(int id)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Edit_Call(id);
		}

		public static List<EventItemsEdit> Crm_Edit_Event(int id)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Edit_Event(id);
		}

		public static List<NotesItemsDelete> Crm_Edit_Notes(int attachmentId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Edit_Notes(attachmentId);
		}

		public static List<TaskItemsEdit> Crm_Edit_Task(int id)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Edit_Task(id);
		}

		public static List<CRMCallView> Crm_Event_Insert(int companyId, string subject, string Location, int ContactId, string ContactType, string EventDate, string EventType, int EventTypeID, string EventTime, string Duration, int IsAllDay, string Comment, int IsSample, int assignToUserID, int createUserId, string createDate, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Event_Insert(companyId, subject, Location, ContactId, ContactType, EventDate, EventType, EventTypeID, EventTime, Duration, IsAllDay, Comment, IsSample, assignToUserID, createUserId, createDate, NotespageNummber);
		}

		public static List<CRMCallView> Crm_Event_Update(int EventID, int CompanyID, string Subject, string Location, int ContactId, string ContactType, string EventDate, string EventType, int EventTypeID, string EventTime, string Duration, string Comment, int assignToUserID, int modifyUserID, string ModifiedDate, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Event_Update(EventID, CompanyID, Subject, Location, ContactId, ContactType, EventDate, EventType, EventTypeID, EventTime, Duration, Comment, assignToUserID, modifyUserID, ModifiedDate, NotespageNummber);
		}

		public static DataSet CRM_GetEndDateOFCall(int id)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_GetEndDateOFCall(id);
		}

		public static List<CRMNotesView> Crm_Notes_Insert(int companyId, string sectionname, int sectionid, string filename, string filesize, int createUserId, string subject, string title, int NotespageNummber, int ContactID, int SpecificTo)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Notes_Insert(companyId, sectionname, sectionid, filename, filesize, createUserId, subject, title, NotespageNummber, ContactID, SpecificTo);
		}

		public static List<CRMNotesView> Crm_Notes_Update(int attachmentId, int companyId, string sectionname, int sectionid, string filename, string filesize, int modifyUserID, string subject, string title, int NotespageNummber, int SpecificTo)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Notes_Update(attachmentId, companyId, sectionname, sectionid, filename, filesize, modifyUserID, subject, title, NotespageNummber, SpecificTo);
		}

		public static DataSet CRM_Print_Customer_Info_with_Dept_Info(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Print_Customer_Info_with_Dept_Info(CompanyID, ClientID);
		}

		public static DataSet CRM_Print_Customer_Info_with_Main_Contact_and_Address(int CompanyID, int ClientID, string CompanyType)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Print_Customer_Info_with_Main_Contact_and_Address(CompanyID, ClientID, CompanyType);
		}

		public static List<SearchResults> Crm_Search_OpenActivities(long CompanyID, long ClientID, string WhereCondition, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Search_OpenActivities(CompanyID, ClientID, WhereCondition, NotespageNummber);
		}

		public static DataSet Crm_Select_Addreess(long ClientID, long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Select_Addreess(ClientID, CompanyID);
		}

		public static DataSet Crm_Select_Alert_Notifications(int CompanyID, int UserID, string CurrentDate, bool IsAdvancedCrm)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Select_Alert_Notifications(CompanyID, UserID, CurrentDate, IsAdvancedCrm);
		}

		public static DataSet CRM_Select_AttachedFileName(int attachmentId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_AttachedFileName(attachmentId);
		}

		public static DataSet CRM_Select_CallPurpose(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_CallPurpose(CompanyID);
		}

		public static DataSet CRM_Select_CloseActivities(int ClientID, int CompanyId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_CloseActivities(ClientID, CompanyId);
		}

		public static DataSet CRM_Select_CloseActivities_Search(int ClientID, int CompanyId, string WhereCondition)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_CloseActivities_Search(ClientID, CompanyId, WhereCondition);
		}

		public static DataSet Crm_select_CloseActivity_SalesTargetSearch(int ClientID, int CompanyId, int UserID, string WhereCondition, string Type, string SearchText)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_select_CloseActivity_SalesTargetSearch(ClientID, CompanyId, UserID, WhereCondition, Type, SearchText);
		}

		public static DataSet CRM_Select_Contact_Notes(int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Contact_Notes(ContactID);
		}

		public static DataSet CRM_Select_Conversion_Persentage_Est_Job(int ClientId, int CompanyId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Conversion_Persentage_Est_Job(ClientId, CompanyId);
		}

		public static DataSet CRM_Select_Conversion_Persentage_Est_toInvoice(int ClientId, int CompanyId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Conversion_Persentage_Est_toInvoice(ClientId, CompanyId);
		}

		public static DataSet CRM_Select_OpenActivities(int ClientID, int CompanyId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_OpenActivities(ClientID, CompanyId);
		}

		public static DataSet CRM_Select_OpenActivitiesSearch(int ClientID, int CompanyId, string WhereCondition)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_OpenActivitiesSearch(ClientID, CompanyId, WhereCondition);
		}

		public static DataSet CRM_Select_SalesTarget(int UserID, int CompanyId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_SalesTarget(UserID, CompanyId);
		}

		public static DataSet Crm_Select_TaskEventCall_Scheduler_Details(long ID, string SectionName)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Select_TaskEventCall_Scheduler_Details(ID, SectionName);
		}

		public static DataSet CRM_Select_Top3Estimate(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Top3Estimate(ClientId, CompanyId, CompanyType, ShowRecords, SelespersonId);
		}

		public static DataSet CRM_Select_Top3Invoice(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Top3Invoice(ClientId, CompanyId, CompanyType, ShowRecords, SelespersonId);
		}

		public static DataSet CRM_Select_Top3Job(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Top3Job(ClientId, CompanyId, CompanyType, ShowRecords, SelespersonId);
		}

		public static DataSet CRM_Select_Top3Order(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Top3Order(ClientId, CompanyId, CompanyType, ShowRecords, SelespersonId);
		}

		public static DataSet CRM_Select_TopFiveContact(long Clientid)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_TopFiveContact(Clientid);
		}

		public static DataSet CRM_Select_TopFiveNotes(int companyId, int sectionid)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_TopFiveNotes(companyId, sectionid);
		}

		public static DataSet CRM_Select_TopFiveNotesSearch(int companyId, int sectionid, string WhereCondition, string SearchText)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_TopFiveNotesSearch(companyId, sectionid, WhereCondition, SearchText);
		}

		public static DataSet CRM_Select_TopTenNotes(int companyId, int sectionid)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_TopTenNotes(companyId, sectionid);
		}

		public static DataSet CRM_Select_Type_fromUsertype(int CompanyID, int UserTypeID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Type_fromUsertype(CompanyID, UserTypeID);
		}

		public static DataSet CRM_Select_Type_fromUsertype(int UserID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_Select_Type_fromUsertype(UserID);
		}

		public static List<NotesInsertSubject> Crm_subject_Insert(string sampleSubject, int companyId, string languagename)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_subject_Insert(sampleSubject, companyId, languagename);
		}

		public static List<CRMCallView> Crm_Task_Insert(int companyId, string subject, string taskTitle, string taskStatus, string dueDate, string taskTime, int contactId, string priority, string type, long typeid, string description, int isSample, int assignToUserId, int createUserId, int modifyUserId, string createDate, string modifiedDate, string contactType, int isDelete, int NotespageNummber, string ParentType, int ParentID, long ModuleID, string ModuleName, string Contact_Phone, string Contact_Mobile, string Department_Phone)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Task_Insert(companyId, subject, taskTitle, taskStatus, dueDate, taskTime, contactId, priority, type, typeid, description, isSample, assignToUserId, createUserId, modifyUserId, createDate, modifiedDate, contactType, isDelete, NotespageNummber, ParentType, ParentID, ModuleID, ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
		}

		public static List<CRMCallView> Crm_Task_Update(int taskID, int CompanyID, string subject, string taskStatus, string dueDate, string taskTime, int contactId, string contactType, string priority, string type, int typeId, string description, int assignToUserId, int modifyUserId, string modifiedDate, int NotespageNummber, string ContactPhone, string ContactMobile, string DepartmentPhone)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Task_Update(taskID, CompanyID, subject, taskStatus, dueDate, taskTime, contactId, contactType, priority, type, typeId, description, assignToUserId, modifyUserId, modifiedDate, NotespageNummber, ContactPhone, ContactMobile, DepartmentPhone);
		}

		public static DataSet Crm_TaskEvent_Select_SalesTerget(int ClientID, int CompanyId, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_TaskEvent_Select_SalesTerget(ClientID, CompanyId, UserID);
		}

		public static DataSet Crm_TaskEvent_Select_SalesTerget_Search(int ClientID, int CompanyId, int UserID, string WhereCondition, string Type, string SearchText)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_TaskEvent_Select_SalesTerget_Search(ClientID, CompanyId, UserID, WhereCondition, Type, SearchText);
		}

		public static void CRM_Update_AttacmentFileName(int attachmentID, int CompanyID, string fileName, string fileSize)
		{
			Printcenter.BusinessAccessLayer.Department.Department.CRM_Update_AttacmentFileName(attachmentID, CompanyID, fileName, fileSize);
		}

		public static List<CRMContactView> Crm_Update_Contact(int companyID, int clientid, int contactid, int NotespageNummber)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Crm_Update_Contact(companyID, clientid, contactid, NotespageNummber);
		}

		public static DataSet CRM_user_select(int CompanyID, int UserID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.CRM_user_select(CompanyID, UserID, ClientID);
		}

		public static DataSet Dashboard_Select_TaskCall_Today_ForallUsers(long CompanyId, long UserId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Dashboard_Select_TaskCall_Today_ForallUsers(CompanyId, UserId);
		}

		public static DataSet Dashboard_Select_TaskEventCall_Scheduler(int ClientID, int CompanyId, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Dashboard_Select_TaskEventCall_Scheduler(ClientID, CompanyId, UserID);
		}

		public static DataSet Dashboard_Select_TaskEventCall_ThiSweek(int ClientID, int CompanyId, int UserID, DateTime SelectedDate)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Dashboard_Select_TaskEventCall_ThiSweek(ClientID, CompanyId, UserID, SelectedDate);
		}

		public static DataSet Dashboard_Select_TaskEventCall_Today(long ClientID, long CompanyId, int UserID, string Type)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Dashboard_Select_TaskEventCall_Today(ClientID, CompanyId, UserID, Type);
		}

		public static DataSet Dashboard_Select_TaskEventCall_Today_ForallUsers(long ClientID, long CompanyId, long UserId)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Dashboard_Select_TaskEventCall_Today_ForallUsers(ClientID, CompanyId, UserId);
		}

		public static DataTable department_getAllDetails(int CompanyID, int UserID, int CustomerID, long DeptID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.department_getAllDetails(CompanyID, UserID, CustomerID, DeptID);
		}

		public static DataSet department_getAllDetails_for_filter(int CompanyID, int UserID, int CustomerID, long DeptID, int pageno, int pagesize, string WhereConditionDepartment)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.department_getAllDetails_for_filter(CompanyID, UserID, CustomerID, DeptID, pageno, pagesize, WhereConditionDepartment);
		}

		public static DataTable department_getDeptNameID(int CompanyID, int UserID, int CustomerID, long DeptID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.department_getDeptNameID(CompanyID, UserID, CustomerID, DeptID);
		}

		public static void departmentcostcentre_delete(long DeptID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.departmentcostcentre_delete(DeptID);
		}

		public static void departmentcostcentre_insert(int DeptID, int selectedcostcenter)
		{
			Printcenter.BusinessAccessLayer.Department.Department.departmentcostcentre_insert(DeptID, selectedcostcenter);
		}

		public static DataTable departmentcostcentre_select(int DeptID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.departmentcostcentre_select(DeptID);
		}

		public static DataTable DepartmentCustomFields_ScreenName_Select(long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.DepartmentCustomFields_ScreenName_Select(CompanyID);
		}

		public void departmentDelete(int CompanyID, int UserID, int DeleteDeptID, int AssignedDeptID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.departmentDelete(CompanyID, UserID, DeleteDeptID, AssignedDeptID);
		}

		public static long departmentInsert(long DeptID, string DeptName, int CustomerID, int ContactID, int UserID, int AddressID, string AddressType, DateTime CreatedDate, DateTime ModifiedDate, int CompanyID, long DeliveryAddressID, int DeptApproverID, int CostCenterID, string Othercostcenter, bool IsApprovalNotRequired, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, long InvoiceContactID, string OriginalFileName, string ActualFilename, bool IsPdf, string Territory_Manager_Email)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.departmentInsert(DeptID, DeptName, CustomerID, ContactID, UserID, AddressID, AddressType, CreatedDate, ModifiedDate, CompanyID, DeliveryAddressID, DeptApproverID, CostCenterID, Othercostcenter, IsApprovalNotRequired, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, InvoiceContactID, OriginalFileName, ActualFilename, IsPdf, Territory_Manager_Email);
		}

		public void departmentSetDefault(int CompanyID, int DeptID, int ClientID)
		{
			Printcenter.BusinessAccessLayer.Department.Department.departmentSetDefault(CompanyID, DeptID, ClientID);
		}

		public static DataSet Forecast_Select_month(long CompanyId, int QuarterNo)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.Forecast_Select_month(CompanyId, QuarterNo);
		}

		public static DataTable GetContactNames(int ClientID, int CompanyID, string ContactName)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.GetContactNames(ClientID, CompanyID, ContactName);
		}

		public static DataTable IsApprovalSystem_Enable(int AccountID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.IsApprovalSystem_Enable(AccountID);
		}

		public static List<LoadCustomer> LoadCustomerList(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.LoadCustomerList(CompanyID);
		}

		public static List<LoadCustomerNameOnSummary> LoadCustomerNameOnSummary(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.LoadCustomerNameOnSummary(CompanyID, ClientID);
		}

		public static List<LoadTaskStatus> LoadTaskStatusList(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.LoadTaskStatusList(CompanyID);
		}

		public static List<DDLBindList> PopupDDLBind(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.PopupDDLBind(CompanyID, ClientID);
		}

		public static DataSet rm_select_CloseActivity_SalesTarget(int ClientID, int CompanyId, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Department.Department.rm_select_CloseActivity_SalesTarget(ClientID, CompanyId, UserID);
		}
	}
}