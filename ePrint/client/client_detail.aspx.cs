using nmsCommon;
using nmsConnectionClass;
using nmsCustomize;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.Company;
using Printcenter.UI.Department;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.client
{
    public partial class client_detail : BaseClass, IRequiresSessionState
    {

        private Global gloobj = new Global();

	private CustomizeSubsection subsection = new CustomizeSubsection();

	public commonClass comncls = new commonClass();

	private BaseClass objBase = new BaseClass();

	private SettingsBasePage objSetBase = new SettingsBasePage();

	public string newdate = string.Empty;

	public string DateFormat = string.Empty;

	public string companytype = string.Empty;

	public string companyName = string.Empty;

	public string clientName = string.Empty;

	public string pg = string.Empty;

	public string tabcolor = string.Empty;

	private string QSsuc = string.Empty;

	private string strSuc = string.Empty;

	public string web_key = string.Empty;

	public string NavigateTo = string.Empty;

	public int CompanyID;

	public int UserID;

	public int accountID;

	public int ClientID;

	private int isnew = 2;

	public int intNoteId;

	public int flag;

	public int AccountID;

	public int AddressID;

	public string VersionNumber = ConnectionClass.VersionNumber;

	public languageClass objLangClass = new languageClass();

	public static string DateFormatNew;

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

	static client_detail()
	{
		client_detail.DateFormatNew = "";
	}

	public client_detail()
	{
	}

	[WebMethod(EnableSession=true)]
	public static IList<DDLBindList> BindAllPopupDropDownList(string CompanyID, string ClientID)
	{
		List<DDLBindList> dDLBindLists = DepartmentBaseClass.PopupDDLBind(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID));
		return dDLBindLists;
	}

	[WebMethod(EnableSession=true)]
	public static IList<DDLBindList> BindContactList(string CompanyID, string ClientID)
	{
		List<DDLBindList> dDLBindLists = DepartmentBaseClass.PopupDDLBind(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID));
		return dDLBindLists;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> ClientCallCompleted(string id, string CompanyId, string Clientid, string SectionName, string NotespageNummber)
	{
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Completed_Call(Convert.ToInt64(id), Convert.ToInt64(CompanyId), Convert.ToInt64(Clientid), SectionName, Convert.ToInt32(NotespageNummber));
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactNotesView> ClientContactNotesDelete(string CompanyID, string SectionID, string attachmentId, string NotespageNummber, string ContactID)
	{
		List<CRMContactNotesView> cRMContactNotesViews = DepartmentBaseClass.Crm_Delete_ContactNotes(Convert.ToInt32(CompanyID), Convert.ToInt32(SectionID), Convert.ToInt32(attachmentId), Convert.ToInt32(NotespageNummber), Convert.ToInt32(ContactID));
		return cRMContactNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactNotesView> ClientContactNotesUpdate(string attachmentId, string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string modifyUserID, string Subject, string Title, string NotespageNummber, string ContactID)
	{
		BaseClass baseClass = new BaseClass();
		List<CRMContactNotesView> cRMContactNotesViews = DepartmentBaseClass.Crm_ContactNotes_Update(Convert.ToInt32(attachmentId), Convert.ToInt32(CompanyID), SectionName, Convert.ToInt32(SectionID), FileName, FileSize, Convert.ToInt32(modifyUserID), baseClass.SpecialEncode(Subject), baseClass.SpecialEncode(Title), Convert.ToInt32(NotespageNummber), Convert.ToInt32(ContactID));
		return cRMContactNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCloseActi> ClientDeleteCloseActivities(string id, string CompanyId, string Clientid, string SectionName, string NotespageNummber)
	{
		List<CRMCloseActi> cRMCloseActis = DepartmentBaseClass.Crm_Delete_CloseActivities(Convert.ToInt64(id), Convert.ToInt64(CompanyId), Convert.ToInt64(Clientid), SectionName, Convert.ToInt32(NotespageNummber));
		return cRMCloseActis;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> ClientDeleteOpenActivities(string id, string CompanyId, string Clientid, string SectionName, string NotespageNummber)
	{
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Delete_OpenActivities(Convert.ToInt64(id), Convert.ToInt64(CompanyId), Convert.ToInt64(Clientid), SectionName, Convert.ToInt32(NotespageNummber));
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> ClientDeleteTask(string id, string CompanyId, string Clientid, string SectionName, string NotespageNummber)
	{
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Delete_Task(Convert.ToInt64(id), Convert.ToInt64(CompanyId), Convert.ToInt64(Clientid), SectionName, Convert.ToInt32(NotespageNummber));
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> ClientNotesAdd(string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string CreateUserID, string Subject, string Title, string NotespageNummber, string ContactID, string SpecificTo)
	{
		BaseClass baseClass = new BaseClass();
		List<CRMNotesView> cRMNotesViews = DepartmentBaseClass.Crm_Notes_Insert(Convert.ToInt32(CompanyID), SectionName, Convert.ToInt32(SectionID), FileName, FileSize, Convert.ToInt32(CreateUserID), baseClass.SpecialEncode(Subject), baseClass.SpecialEncode(Title), Convert.ToInt32(NotespageNummber), Convert.ToInt32(ContactID), Convert.ToInt32(SpecificTo));
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> ClientNotesDelete(string CompanyID, string SectionID, string attachmentId, string NotespageNummber)
	{
		List<CRMNotesView> cRMNotesViews = DepartmentBaseClass.Crm_Delete_Notes(Convert.ToInt32(CompanyID), Convert.ToInt32(SectionID), Convert.ToInt32(attachmentId), Convert.ToInt32(NotespageNummber));
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<NotesItemsDelete> ClientNotesEdit(string attachmentId)
	{
		return DepartmentBaseClass.Crm_Edit_Notes(Convert.ToInt32(attachmentId));
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> ClientNotesUpdate(string attachmentId, string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string modifyUserID, string Subject, string Title, string NotespageNummber, string SpecifiedTo)
	{
		BaseClass baseClass = new BaseClass();
		List<CRMNotesView> cRMNotesViews = DepartmentBaseClass.Crm_Notes_Update(Convert.ToInt32(attachmentId), Convert.ToInt32(CompanyID), SectionName, Convert.ToInt32(SectionID), FileName, FileSize, Convert.ToInt32(modifyUserID), baseClass.SpecialEncode(Subject), baseClass.SpecialEncode(Title), Convert.ToInt32(NotespageNummber), Convert.ToInt32(SpecifiedTo));
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactNotesView> ContactNotesAdd(string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string CreateUserID, string Subject, string Title, string NotespageNummber, string ContactID)
	{
		BaseClass baseClass = new BaseClass();
		List<CRMContactNotesView> cRMContactNotesViews = DepartmentBaseClass.Crm_ContactNotes_Insert(Convert.ToInt32(CompanyID), SectionName, Convert.ToInt32(SectionID), FileName, FileSize, Convert.ToInt32(CreateUserID), baseClass.SpecialEncode(Subject), baseClass.SpecialEncode(Title), Convert.ToInt32(NotespageNummber), Convert.ToInt32(ContactID));
		return cRMContactNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<NotesInsertSubject> Crm_Callsubjec_Insert(string CompanyID, string CallSubject, string Default, string UserID)
	{
		List<NotesInsertSubject> notesInsertSubjects = DepartmentBaseClass.Crm_Callsubject_Insert(Convert.ToInt64(CompanyID), CallSubject, Convert.ToBoolean(Default), Convert.ToInt64(UserID));
		return notesInsertSubjects;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CallItemsEdit> Crm_Edit_Call(string id)
	{
		return DepartmentBaseClass.Crm_Edit_Call(Convert.ToInt32(id));
	}

	[WebMethod(EnableSession=true)]
	public static IList<EventItemsEdit> Crm_Edit_Event(string id)
	{
		return DepartmentBaseClass.Crm_Edit_Event(Convert.ToInt32(id));
	}

	[WebMethod(EnableSession=true)]
	public static IList<TaskItemsEdit> Crm_Edit_Task(string id)
	{
		return DepartmentBaseClass.Crm_Edit_Task(Convert.ToInt32(id));
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> Crm_Event_Update(string EventID, string CompanyID, string Subject, string Location, string ContactId, string ContactType, string EventDate, string EventType, string EventTypeID, string EventTime, string Duration, string Comment, string assignToUserID, string modifyUserID, string ModifiedDate, string NotespageNummber)
	{
		string str = DateTime.Now.ToString();
		BaseClass baseClass = new BaseClass();
		str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, EventDate.ToString());
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Event_Update(Convert.ToInt32(EventID), Convert.ToInt32(CompanyID), Subject, Location, Convert.ToInt32(ContactId), ContactType, str, EventType, Convert.ToInt32(EventTypeID), EventTime, Duration, Comment, Convert.ToInt32(assignToUserID), Convert.ToInt32(modifyUserID), ModifiedDate, Convert.ToInt32(NotespageNummber));
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<NotesInsertSubject> Crm_subject_Insert(string Subject, string CompanyID, string Language)
	{
		BaseClass baseClass = new BaseClass();
		List<NotesInsertSubject> notesInsertSubjects = DepartmentBaseClass.Crm_subject_Insert(baseClass.SpecialEncode(Subject), Convert.ToInt32(CompanyID), Language);
		return notesInsertSubjects;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> CrmCallInsert(string CompanyID, string ClientID, string Subject, string CallType, string CallPurpose, string CallDetails, string ContactID, string CallStartdate, string CallStartTime, string CallDurationMinutes, string CallDurationSeconds, string CallResult, string AssignedTo, string Description, string isBillabel, string CreatedBy, string NotespageNummber, string CallEndDate, string ParentType, string ParentID, long ModuleID, string ModuleName, string Contact_Phone, string Contact_Mobile, string Department_Phone)
	{
		IList<CRMCallView> cRMCallViews;
		try
		{
			BaseClass baseClass = new BaseClass();
			string str = DateTime.Now.ToString();
			string str1 = DateTime.Now.ToString();
			int num = 0;
			string callStartTime = "";
			if (CallDetails.ToString().ToLower() == "current")
			{
				str = CallStartdate;
				callStartTime = CallStartTime;
				string[] strArrays = callStartTime.Split(new char[] { ':' });
				if (Convert.ToInt32(strArrays[0].ToString()) <= 12)
				{
					callStartTime = string.Concat(CallStartTime, " AM");
				}
				else
				{
					num = Convert.ToInt32(strArrays[0].ToString()) - 12;
					callStartTime = string.Concat(num, ":", strArrays[1].ToString());
					if (num.ToString().Length < 2)
					{
						object[] objArray = new object[] { "0", num, ":", strArrays[1].ToString(), " PM" };
						callStartTime = string.Concat(objArray);
					}
				}
			}
			else if (CallDetails.ToString().ToLower() == "completed")
			{
				str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, CallStartdate.ToString());
				DateTime now = DateTime.Now;
				DateTime dateTime = DateTime.Now;
				now = Convert.ToDateTime(str);
				string[] strArrays1 = CallStartTime.Split(new char[] { ':' });
				string[] strArrays2 = strArrays1[1].Split(new char[] { ' ' });
				int num1 = 0;
				if (strArrays2[1] != "PM")
				{
					now = now.AddHours((double)Convert.ToInt32(strArrays1[0]));
				}
				else
				{
					num1 = Convert.ToInt32(strArrays1[0].ToString()) + 12;
					now = now.AddHours((double)Convert.ToInt32(num1));
				}
				now = now.AddMinutes((double)Convert.ToInt32(strArrays2[0]));
				callStartTime = CallStartTime;
				if (CallDurationMinutes != "")
				{
					dateTime = now.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
					str1 = dateTime.ToString();
				}
				else
				{
					CallDurationMinutes = "0";
					str1 = "";
				}
				if (CallDurationSeconds != "")
				{
					dateTime = now.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
					str1 = dateTime.ToString();
				}
				else
				{
					CallDurationSeconds = "0";
					if (str1 == "")
					{
						str1 = "";
					}
				}
			}
			else if (CallDetails.ToString().ToLower() == "scheduled")
			{
				str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, CallStartdate.ToString());
				DateTime now1 = DateTime.Now;
				DateTime dateTime1 = DateTime.Now;
				string[] strArrays3 = CallStartTime.Split(new char[] { ':' });
				string[] strArrays4 = strArrays3[1].Split(new char[] { ' ' });
				int num2 = 0;
				now1 = Convert.ToDateTime(str);
				if (strArrays4[1] != "PM")
				{
					now1 = now1.AddHours((double)Convert.ToInt32(strArrays3[0]));
				}
				else
				{
					num2 = Convert.ToInt32(strArrays3[0].ToString()) + 12;
					now1 = now1.AddHours((double)Convert.ToInt32(num2));
				}
				now1 = now1.AddMinutes((double)Convert.ToInt32(strArrays4[0]));
				callStartTime = CallStartTime;
				if (CallDurationMinutes != "")
				{
					dateTime1 = now1.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
					str1 = dateTime1.ToString();
				}
				else
				{
					CallDurationMinutes = "0";
					str1 = "";
				}
				if (CallDurationSeconds != "")
				{
					dateTime1 = now1.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
					str1 = dateTime1.ToString();
				}
				else
				{
					CallDurationSeconds = "0";
					if (str1 == "")
					{
						str1 = "";
					}
				}
			}
			List<CRMCallView> cRMCallViews1 = DepartmentBaseClass.Crm_Call_Insert(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID), baseClass.SpecialEncode(Subject), CallType, Convert.ToInt32(CallPurpose), CallDetails, Convert.ToInt32(ContactID), str, callStartTime, Convert.ToInt32(CallDurationMinutes), Convert.ToInt32(CallDurationSeconds), CallResult, Convert.ToInt32(AssignedTo), baseClass.SpecialEncode(Description), Convert.ToBoolean(isBillabel), Convert.ToInt32(CreatedBy), Convert.ToInt32(NotespageNummber), str1, ParentType, Convert.ToInt32(ParentID), Convert.ToInt64(ModuleID), ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
			cRMCallViews = cRMCallViews1;
		}
		catch (Exception exception)
		{
			cRMCallViews = null;
		}
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> CrmCallUpdate(string CallID, string CompanyID, string ClientID, string Subject, string CallType, string CallPurpose, string CallDetails, string ContactID, string CallStartdate, string CallStartTime, string CallDurationMinutes, string CallDurationSeconds, string CallResult, string AssignedTo, string Description, string isBillabel, string LastUpdatedBy, string NotespageNummber, string CallEnddate, string Contact_Phone, string Contact_Mobile, string Department_Phone)
	{
		string str = DateTime.Now.ToString();
		string str1 = DateTime.Now.ToString();
		string callStartTime = "";
		BaseClass baseClass = new BaseClass();
		if (CallDetails.ToString().ToLower() == "current")
		{
			str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, CallStartdate.ToString());
			DateTime now = DateTime.Now;
			DateTime dateTime = DateTime.Now;
			string[] strArrays = CallStartTime.Split(new char[] { ':' });
			string[] strArrays1 = strArrays[1].Split(new char[] { ' ' });
			int num = 0;
			now = Convert.ToDateTime(str);
			if (strArrays1[1] != "PM")
			{
				now = now.AddHours((double)Convert.ToInt32(strArrays[0]));
			}
			else
			{
				num = Convert.ToInt32(strArrays[0].ToString()) + 12;
				now = now.AddHours((double)Convert.ToInt32(num));
			}
			now = now.AddMinutes((double)Convert.ToInt32(strArrays1[0]));
			dateTime = now.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
			callStartTime = CallStartTime;
			str1 = dateTime.ToString();
		}
		else if (CallDetails.ToString().ToLower() == "completed")
		{
			str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, CallStartdate.ToString());
			DateTime now1 = DateTime.Now;
			DateTime dateTime1 = DateTime.Now;
			string[] strArrays2 = CallStartTime.Split(new char[] { ':' });
			string[] strArrays3 = strArrays2[1].Split(new char[] { ' ' });
			int num1 = 0;
			now1 = Convert.ToDateTime(str);
			if (strArrays3[1] != "PM")
			{
				now1 = now1.AddHours((double)Convert.ToInt32(strArrays2[0]));
			}
			else
			{
				num1 = Convert.ToInt32(strArrays2[0].ToString()) + 12;
				now1 = now1.AddHours((double)Convert.ToInt32(num1));
			}
			now1 = now1.AddMinutes((double)Convert.ToInt32(strArrays3[0]));
			callStartTime = CallStartTime;
			if (CallDurationMinutes != "")
			{
				dateTime1 = now1.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
				str1 = dateTime1.ToString();
			}
			else
			{
				CallDurationMinutes = "0";
				str1 = "";
			}
			if (CallDurationSeconds != "")
			{
				dateTime1 = now1.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
				str1 = dateTime1.ToString();
			}
			else
			{
				CallDurationSeconds = "0";
				if (str1 == "")
				{
					str1 = "";
				}
			}
		}
		else if (CallDetails.ToString().ToLower() == "scheduled")
		{
			DateTime now2 = DateTime.Now;
			DataSet dataSet = DepartmentBaseClass.CRM_GetEndDateOFCall(Convert.ToInt32(CallID));
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				if (row["CallEnddate"].ToString().Contains("1900"))
				{
					continue;
				}
				now2 = Convert.ToDateTime(row["CallEnddate"].ToString());
			}
			str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, CallStartdate.ToString());
			DateTime dateTime2 = DateTime.Now;
			string[] strArrays4 = CallStartTime.Split(new char[] { ':' });
			string[] strArrays5 = strArrays4[1].Split(new char[] { ' ' });
			int num2 = 0;
			dateTime2 = Convert.ToDateTime(str);
			if (strArrays5[1] != "PM")
			{
				dateTime2 = dateTime2.AddHours((double)Convert.ToInt32(strArrays4[0]));
			}
			else
			{
				num2 = Convert.ToInt32(strArrays4[0].ToString()) + 12;
				dateTime2 = dateTime2.AddHours((double)Convert.ToInt32(num2));
			}
			dateTime2 = dateTime2.AddMinutes((double)Convert.ToInt32(strArrays5[0]));
			callStartTime = CallStartTime;
			if (CallDurationMinutes != "")
			{
				now2 = dateTime2.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
				str1 = now2.ToString();
			}
			else
			{
				CallDurationMinutes = "0";
				str1 = "";
			}
			if (CallDurationSeconds != "")
			{
				now2 = dateTime2.AddMinutes((double)Convert.ToInt32(CallDurationMinutes));
				str1 = now2.ToString();
			}
			else
			{
				CallDurationSeconds = "0";
				if (str1 == "")
				{
					str1 = "";
				}
			}
		}
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Call_Update(Convert.ToInt64(CallID), Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID), baseClass.SpecialEncode(Subject), CallType, Convert.ToInt32(CallPurpose), CallDetails, Convert.ToInt32(ContactID), str, callStartTime, Convert.ToInt32(CallDurationMinutes), Convert.ToInt32(CallDurationSeconds), CallResult, Convert.ToInt32(AssignedTo), baseClass.SpecialEncode(Description), Convert.ToBoolean(isBillabel), Convert.ToInt32(LastUpdatedBy), Convert.ToInt32(NotespageNummber), str1, Contact_Phone, Contact_Mobile, Department_Phone);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactView> CrmContactUpdate(string CompanyID, string clientID, string ContactID, string NotespageNummber)
	{
		List<CRMContactView> cRMContactViews = DepartmentBaseClass.Crm_Update_Contact(Convert.ToInt32(CompanyID), Convert.ToInt32(clientID), Convert.ToInt32(ContactID), Convert.ToInt32(NotespageNummber));
		return cRMContactViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> CrmEventInsert(string companyId, string subject, string Location, string ContactId, string ContactType, string EventDate, string EventType, string EventTypeID, string EventTime, string Duration, string IsAllDay, string Comment, string IsSample, string assignToUserID, string createUserId, string createDate, string NotespageNummber)
	{
		string str = DateTime.Now.ToString();
		BaseClass baseClass = new BaseClass();
		str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, EventDate.ToString());
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Event_Insert(Convert.ToInt32(companyId), subject, Location, Convert.ToInt32(ContactId), ContactType, str, EventType, Convert.ToInt32(EventTypeID), EventTime, Duration, Convert.ToInt32(IsAllDay), Comment, Convert.ToInt32(IsSample), Convert.ToInt32(assignToUserID), Convert.ToInt32(createUserId), createDate, Convert.ToInt32(NotespageNummber));
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> CrmTaskInsert(string companyId, string subject, string taskTitle, string taskStatus, string dueDate, string taskTime, string contactId, string priority, string type, string typeid, string description, string isSample, string assignToUserId, string createUserId, string modifyUserId, string createDate, string modifiedDate, string contactType, string isDelete, string NotespageNummber, string ParentType, string ParentID, long ModuleID, string ModuleName, string Contact_Phone, string Contact_Mobile, string Department_Phone)
	{
		BaseClass baseClass = new BaseClass();
		string str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, dueDate.ToString());
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Task_Insert(Convert.ToInt32(companyId), baseClass.SpecialEncode(subject), baseClass.SpecialEncode(taskTitle), taskStatus, str, taskTime, Convert.ToInt32(contactId), priority, type, Convert.ToInt64(typeid), baseClass.SpecialEncode(description), Convert.ToInt32(isSample), Convert.ToInt32(assignToUserId), Convert.ToInt32(createUserId), Convert.ToInt32(modifyUserId), createDate, modifiedDate, contactType, Convert.ToInt32(isDelete), Convert.ToInt32(NotespageNummber), ParentType, Convert.ToInt32(ParentID), (long)Convert.ToInt32(ModuleID), ModuleName, Contact_Phone, Contact_Mobile, Department_Phone);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> CrmTaskUpdate(string taskID, string CompanyID, string subject, string taskStatus, string dueDate, string taskTime, string contactId, string contactType, string priority, string type, string typeId, string description, string assignToUserId, string modifyUserId, string modifiedDate, string NotespageNummber, string Contact_Phone, string Contact_Mobile, string Department_Phone)
	{
		BaseClass baseClass = new BaseClass();
		string str = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, dueDate.ToString());
		List<CRMCallView> cRMCallViews = DepartmentBaseClass.Crm_Task_Update(Convert.ToInt32(taskID), Convert.ToInt32(CompanyID), baseClass.SpecialEncode(subject), taskStatus, str, taskTime, Convert.ToInt32(contactId), contactType, priority, type, Convert.ToInt32(typeId), baseClass.SpecialEncode(description), Convert.ToInt32(assignToUserId), Convert.ToInt32(modifyUserId), modifiedDate, Convert.ToInt32(NotespageNummber), Contact_Phone, Contact_Mobile, Department_Phone);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCloseActi> LoadAllCloseActivity(string ClientID, string CompanyId)
	{
		IList<CRMCloseActi> cRMCloseActis;
		try
		{
			List<CRMCloseActi> cRMCloseActis1 = new List<CRMCloseActi>();
			CRMCloseActi cRMCloseActi = new CRMCloseActi()
			{
				AllCloseActivity = CRMAllCloseActivity.ReturnAllCloseActivity(CompanyId.ToString(), ClientID.ToString()),
				taskID = "0"
			};
			cRMCloseActis1.Add(cRMCloseActi);
			cRMCloseActis = cRMCloseActis1;
		}
		catch
		{
			cRMCloseActis = null;
		}
		return cRMCloseActis;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> LoadAllNotes(string companyId, string sectionid)
	{
		IList<CRMNotesView> cRMNotesViews;
		try
		{
			List<CRMNotesView> cRMNotesViews1 = new List<CRMNotesView>();
			CRMNotesView cRMNotesView = new CRMNotesView()
			{
				AllNotes = CRMShowAllNotes.ReturnAllNotes(companyId.ToString(), sectionid.ToString()),
				attachmentID = "0"
			};
			cRMNotesViews1.Add(cRMNotesView);
			cRMNotesViews = cRMNotesViews1;
		}
		catch
		{
			cRMNotesViews = null;
		}
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadAllOpenActivity(string ClientID, string CompanyId)
	{
		IList<CRMCallView> cRMCallViews;
		try
		{
			List<CRMCallView> cRMCallViews1 = new List<CRMCallView>();
			CRMCallView cRMCallView = new CRMCallView()
			{
				Alltask = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyId.ToString(), ClientID.ToString()),
				CallID = "0"
			};
			cRMCallViews1.Add(cRMCallView);
			cRMCallViews = cRMCallViews1;
		}
		catch
		{
			cRMCallViews = null;
		}
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadAllSearchedCloseActivity(string ClientID, string CompanyId, string MultipalSearchText, string StartDate, string Enddate, string Type)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ))");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, " ))");
			}
		}
		else if (StartDate.Trim().Length > 0 && Enddate.Trim().Length == 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
				empty = string.Concat(empty, " or ((");
				empty = string.Concat(empty, " CallStartdate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " CallStartdate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
		}
		else if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			AllCloseActivity = CRMAllCloseActivitySearch.ReturnAllCloseActivitySearch(CompanyId.ToString(), ClientID.ToString(), 5555555, empty, Type, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> LoadAllSearchedNotes(string companyId, string sectionid, string MultipalSearchText, string StartDate, string Enddate)
	{
		IList<CRMNotesView> cRMNotesViews;
		try
		{
			BaseClass baseClass = new BaseClass();
			string empty = string.Empty;
			if (MultipalSearchText != "")
			{
				MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
			}
			if (StartDate.Trim().Length > 2)
			{
				StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
			}
			if (Enddate.Trim().Length > 2)
			{
				Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
			}
			ArrayList arrayLists = new ArrayList();
			arrayLists.Add("title");
			arrayLists.Add("subject");
			arrayLists.Add("UserName");
			arrayLists.Add("SpecificName");
			if (MultipalSearchText.Trim().Length > 0)
			{
				char[] chrArray = new char[] { ' ' };
				string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
				empty = " and (";
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string str = string.Empty;
					str = "(";
					if (strArrays[i].Length > 0)
					{
						for (int j = 0; j < arrayLists.Count; j++)
						{
							if (j != arrayLists.Count - 1)
							{
								object obj = str;
								object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
								str = string.Concat(item);
							}
							else
							{
								object obj1 = str;
								object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
								str = string.Concat(objArray);
							}
						}
						str = string.Concat(str, ")");
						if (str.Trim().Length > 4)
						{
							empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
						}
					}
				}
				empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
			}
			if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
			{
				if (empty.Trim().Length > 2)
				{
					empty = string.Concat(empty, " and ((");
					string str1 = empty;
					string[] startDate = new string[] { str1, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(startDate);
					empty = string.Concat(empty, " ) or (");
					string str2 = empty;
					string[] startDate1 = new string[] { str2, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(startDate1);
					empty = string.Concat(empty, "))");
				}
			}
			else if (StartDate.Trim().Length > 0 && Enddate.Trim().Length == 0)
			{
				if (empty.Trim().Length > 2)
				{
					empty = string.Concat(empty, " and ((");
					string str3 = empty;
					string[] strArrays1 = new string[] { str3, " createDate between '", StartDate, "'  and  '", null, null };
					strArrays1[4] = DateTime.Now.ToString();
					strArrays1[5] = "'";
					empty = string.Concat(strArrays1);
					empty = string.Concat(empty, " ) or (");
					string str4 = empty;
					string[] startDate2 = new string[] { str4, " createDate between '", StartDate, "'  and  '", null, null };
					startDate2[4] = DateTime.Now.ToString();
					startDate2[5] = "'";
					empty = string.Concat(startDate2);
					empty = string.Concat(empty, "))");
				}
			}
			else if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0 && empty.Trim().Length > 2)
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ) or (");
				empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, "))");
			}
			List<CRMNotesView> cRMNotesViews1 = new List<CRMNotesView>();
			CRMNotesView cRMNotesView = new CRMNotesView()
			{
				AllNotes = CRMNotesSearchAll.ReturnNotesSearchAll(companyId.ToString(), sectionid.ToString(), 555555, empty, MultipalSearchText),
				attachmentID = "0"
			};
			cRMNotesViews1.Add(cRMNotesView);
			cRMNotesViews = cRMNotesViews1;
		}
		catch
		{
			cRMNotesViews = null;
		}
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadAllSearchedOpenActivity(string ClientID, string CompanyId, string MultipalSearchText, string StartDate, string Enddate, string Type)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ))");
			}
			else if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, " ))");
			}
		}
		else if (StartDate.Trim().Length <= 0 || Enddate.Trim().Length != 0)
		{
			if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
			{
				if (Type == "Task")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else if (Type != "Call")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
					empty = string.Concat(empty, " or ((");
					empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
			}
		}
		else if (Type == "Task")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else if (Type != "Call")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
			empty = string.Concat(empty, " or ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			SearcedCall = CRMAllOASearch.ReturnAllOASearch(CompanyId.ToString(), ClientID.ToString(), 55555555, empty, Type, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod]
	public static List<LoadAssgiendto> LoadAssignedTODDL(string CompanyID, string UserID, string ClientID)
	{
		DataSet dataSet = DepartmentBaseClass.CRM_user_select(Convert.ToInt32(CompanyID), Convert.ToInt32(UserID), Convert.ToInt32(ClientID));
		List<LoadAssgiendto> loadAssgiendtos = new List<LoadAssgiendto>();
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				LoadAssgiendto loadAssgiendto = new LoadAssgiendto()
				{
					Name = row["Name"].ToString(),
					UserID = row["UserID"].ToString()
				};
				loadAssgiendtos.Add(loadAssgiendto);
			}
		}
		return loadAssgiendtos;
	}

	[WebMethod]
	public static IList<LoadCallStatus> LoadCallStatusList(int CompanyID)
	{
		DataSet dataSet = DepartmentBaseClass.CRM_Select_CallPurpose(CompanyID);
		List<LoadCallStatus> loadCallStatuses = new List<LoadCallStatus>();
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				LoadCallStatus loadCallStatu = new LoadCallStatus()
				{
					StatusTitle = row["StatusTitle"].ToString(),
					StatusID = row["Id"].ToString(),
					IsDefault = row["Isdefault"].ToString()
				};
				loadCallStatuses.Add(loadCallStatu);
			}
		}
		return loadCallStatuses;
	}

	[WebMethod(EnableSession=true)]
	public static IList<LoadCustomer> LoadCustomerList(int CompanyID)
	{
		return DepartmentBaseClass.LoadCustomerList(CompanyID);
	}

	[WebMethod(EnableSession=true)]
	public static IList<LoadCustomerNameOnSummary> LoadCustomerNameOnSummary(string CompanyID, string ClientID)
	{
		List<LoadCustomerNameOnSummary> loadCustomerNameOnSummaries = DepartmentBaseClass.LoadCustomerNameOnSummary(Convert.ToInt32(CompanyID), Convert.ToInt32(ClientID));
		return loadCustomerNameOnSummaries;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCloseActi> LoadHideCloseActivity(string ClientID, string CompanyId, string NotespageNummber)
	{
		IList<CRMCloseActi> cRMCloseActis;
		try
		{
			List<CRMCloseActi> cRMCloseActis1 = new List<CRMCloseActi>();
			CRMCloseActi cRMCloseActi = new CRMCloseActi()
			{
				AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				taskID = "0"
			};
			cRMCloseActis1.Add(cRMCloseActi);
			cRMCloseActis = cRMCloseActis1;
		}
		catch
		{
			cRMCloseActis = null;
		}
		return cRMCloseActis;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactView> LoadHideContacts(string ClientID, string NotespageNummber)
	{
		IList<CRMContactView> cRMContactViews;
		try
		{
			List<CRMContactView> cRMContactViews1 = new List<CRMContactView>();
			CRMContactView cRMContactView = new CRMContactView()
			{
				AllContacts = CRMContacts.ReturnContacts(ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				ClientID = ClientID
			};
			cRMContactViews1.Add(cRMContactView);
			cRMContactViews = cRMContactViews1;
		}
		catch
		{
			cRMContactViews = null;
		}
		return cRMContactViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> LoadHideMoreNotes(string companyId, string sectionid, string NotespageNummber)
	{
		IList<CRMNotesView> cRMNotesViews;
		try
		{
			List<CRMNotesView> cRMNotesViews1 = new List<CRMNotesView>();
			CRMNotesView cRMNotesView = new CRMNotesView()
			{
				AllNotes = CRMNotes.ReturnNotes(companyId.ToString(), sectionid.ToString(), Convert.ToInt32(NotespageNummber)),
				attachmentID = "0"
			};
			cRMNotesViews1.Add(cRMNotesView);
			cRMNotesViews = cRMNotesViews1;
		}
		catch
		{
			cRMNotesViews = null;
		}
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadHideOpenActivity(string ClientID, string CompanyId, string NotespageNummber)
	{
		IList<CRMCallView> cRMCallViews;
		try
		{
			List<CRMCallView> cRMCallViews1 = new List<CRMCallView>();
			CRMCallView cRMCallView = new CRMCallView()
			{
				Alltask = CRMCalls.ReturnCalls(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				CallID = "0"
			};
			cRMCallViews1.Add(cRMCallView);
			cRMCallViews = cRMCallViews1;
		}
		catch
		{
			cRMCallViews = null;
		}
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCloseActi> LoadMoreCloseActivity(string ClientID, string CompanyId, string NotespageNummber)
	{
		IList<CRMCloseActi> cRMCloseActis;
		try
		{
			List<CRMCloseActi> cRMCloseActis1 = new List<CRMCloseActi>();
			CRMCloseActi cRMCloseActi = new CRMCloseActi()
			{
				AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				taskID = "0"
			};
			cRMCloseActis1.Add(cRMCloseActi);
			cRMCloseActis = cRMCloseActis1;
		}
		catch
		{
			cRMCloseActis = null;
		}
		return cRMCloseActis;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMContactView> LoadMoreContacts(string ClientID, string NotespageNummber)
	{
		IList<CRMContactView> cRMContactViews;
		try
		{
			List<CRMContactView> cRMContactViews1 = new List<CRMContactView>();
			CRMContactView cRMContactView = new CRMContactView()
			{
				AllContacts = CRMContacts.ReturnContacts(ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				ClientID = ClientID
			};
			cRMContactViews1.Add(cRMContactView);
			cRMContactViews = cRMContactViews1;
		}
		catch
		{
			cRMContactViews = null;
		}
		return cRMContactViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> LoadMoreNotes(string companyId, string sectionid, string NotespageNummber)
	{
		IList<CRMNotesView> cRMNotesViews;
		try
		{
			List<CRMNotesView> cRMNotesViews1 = new List<CRMNotesView>();
			CRMNotesView cRMNotesView = new CRMNotesView()
			{
				AllNotes = CRMNotes.ReturnNotes(companyId.ToString(), sectionid.ToString(), Convert.ToInt32(NotespageNummber)),
				attachmentID = "0"
			};
			cRMNotesViews1.Add(cRMNotesView);
			cRMNotesViews = cRMNotesViews1;
		}
		catch
		{
			cRMNotesViews = null;
		}
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadMoreOpenActivity(string ClientID, string CompanyId, string NotespageNummber)
	{
		IList<CRMCallView> cRMCallViews;
		try
		{
			List<CRMCallView> cRMCallViews1 = new List<CRMCallView>();
			CRMCallView cRMCallView = new CRMCallView()
			{
				Alltask = CRMCalls.ReturnCalls(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber)),
				CallID = "0"
			};
			cRMCallViews1.Add(cRMCallView);
			cRMCallViews = cRMCallViews1;
		}
		catch
		{
			cRMCallViews = null;
		}
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadMoreSearchedCloseActivity(string ClientID, string CompanyId, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber, string Type)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ))");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, " ))");
			}
		}
		else if (StartDate.Trim().Length > 0 && Enddate.Trim().Length == 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
				empty = string.Concat(empty, " or ((");
				empty = string.Concat(empty, " CallStartdate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " CallStartdate > '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
		}
		else if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
			if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ))");
			}
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			AllCloseActivity = CRMCloseActivitySearch.ReturnCloseActivitySearch(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber), empty, Type, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMNotesView> LoadMoreSearchedNotes(string companyId, string sectionid, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber)
	{
		IList<CRMNotesView> cRMNotesViews;
		try
		{
			BaseClass baseClass = new BaseClass();
			string empty = string.Empty;
			if (MultipalSearchText != "")
			{
				MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
			}
			if (StartDate.Trim().Length > 2)
			{
				StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
			}
			if (Enddate.Trim().Length > 2)
			{
				Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
			}
			ArrayList arrayLists = new ArrayList();
			arrayLists.Add("title");
			arrayLists.Add("subject");
			arrayLists.Add("UserName");
			arrayLists.Add("SpecificName");
			if (MultipalSearchText.Trim().Length > 0)
			{
				char[] chrArray = new char[] { ' ' };
				string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
				empty = " and (";
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string str = string.Empty;
					str = "(";
					if (strArrays[i].Length > 0)
					{
						for (int j = 0; j < arrayLists.Count; j++)
						{
							if (j != arrayLists.Count - 1)
							{
								object obj = str;
								object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
								str = string.Concat(item);
							}
							else
							{
								object obj1 = str;
								object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
								str = string.Concat(objArray);
							}
						}
						str = string.Concat(str, ")");
						if (str.Trim().Length > 4)
						{
							empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
						}
					}
				}
				empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
			}
			if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ) or (");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, "))");
			}
			else if (StartDate.Trim().Length > 0 && Enddate.Trim().Length == 0)
			{
				empty = string.Concat(empty, " and ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " createDate between '", StartDate, "'  and  '", null, null };
				strArrays1[4] = DateTime.Now.ToString();
				strArrays1[5] = "'";
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ) or (");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " createDate between '", StartDate, "'  and  '", null, null };
				startDate2[4] = DateTime.Now.ToString();
				startDate2[5] = "'";
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, "))");
			}
			else if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, " ) or (");
				empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
				empty = string.Concat(empty, "))");
			}
			List<CRMNotesView> cRMNotesViews1 = new List<CRMNotesView>();
			CRMNotesView cRMNotesView = new CRMNotesView()
			{
				AllNotes = CRMNotesSearch.ReturnNotesSearch(companyId.ToString(), sectionid.ToString(), Convert.ToInt32(NotespageNummber), empty, MultipalSearchText),
				attachmentID = "0"
			};
			cRMNotesViews1.Add(cRMNotesView);
			cRMNotesViews = cRMNotesViews1;
		}
		catch
		{
			cRMNotesViews = null;
		}
		return cRMNotesViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> LoadMoreSearchedOpenActivity(string ClientID, string CompanyId, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber, string Type)
	{
		IList<CRMCallView> cRMCallViews;
		try
		{
			BaseClass baseClass = new BaseClass();
			string empty = string.Empty;
			if (MultipalSearchText != "")
			{
				MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
			}
			if (StartDate.Trim().Length > 2)
			{
				StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
			}
			if (Enddate.Trim().Length > 2)
			{
				Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
			}
			ArrayList arrayLists = new ArrayList();
			arrayLists.Add("SectionName");
			arrayLists.Add("Subject");
			arrayLists.Add("Status");
			arrayLists.Add("Contactname");
			arrayLists.Add("AssignTo");
			if (MultipalSearchText.Trim().Length > 0)
			{
				char[] chrArray = new char[] { ' ' };
				string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
				empty = " and (";
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string str = string.Empty;
					str = "(";
					if (strArrays[i].Length > 0)
					{
						for (int j = 0; j < arrayLists.Count; j++)
						{
							if (j != arrayLists.Count - 1)
							{
								object obj = str;
								object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
								str = string.Concat(item);
							}
							else
							{
								object obj1 = str;
								object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
								str = string.Concat(objArray);
							}
						}
						str = string.Concat(str, ")");
						if (str.Trim().Length > 4)
						{
							empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
						}
					}
				}
				empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
			}
			if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
			{
				if (Type == "Task")
				{
					empty = string.Concat(empty, " and ((");
					string str1 = empty;
					string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(startDate);
					empty = string.Concat(empty, " ))");
				}
				else if (Type != "Call")
				{
					empty = string.Concat(empty, " and ((");
					string str2 = empty;
					string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(startDate1);
					empty = string.Concat(empty, " ))");
					empty = string.Concat(empty, " or ((");
					string str3 = empty;
					string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(strArrays1);
					empty = string.Concat(empty, " ))");
				}
				else
				{
					empty = string.Concat(empty, " and ((");
					string str4 = empty;
					string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
					empty = string.Concat(startDate2);
					empty = string.Concat(empty, " ))");
				}
			}
			else if (StartDate.Trim().Length <= 0 || Enddate.Trim().Length != 0)
			{
				if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
				{
					if (Type == "Task")
					{
						empty = string.Concat(empty, " and ((");
						empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
						empty = string.Concat(empty, " ))");
					}
					else if (Type != "Call")
					{
						empty = string.Concat(empty, " and ((");
						empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
						empty = string.Concat(empty, " ))");
						empty = string.Concat(empty, " or ((");
						empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
						empty = string.Concat(empty, " ))");
					}
					else
					{
						empty = string.Concat(empty, " and ((");
						empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
						empty = string.Concat(empty, " ))");
					}
				}
			}
			else if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate >= '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			else if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " duedate >= '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
				empty = string.Concat(empty, " or ((");
				empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
				empty = string.Concat(empty, " ) )");
			}
			List<CRMCallView> cRMCallViews1 = new List<CRMCallView>();
			CRMCallView cRMCallView = new CRMCallView()
			{
				SearcedCall = CRMOASearch.ReturnOASearch(CompanyId.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber), empty, Type, MultipalSearchText),
				CallID = "0"
			};
			cRMCallViews1.Add(cRMCallView);
			cRMCallViews = cRMCallViews1;
		}
		catch
		{
			cRMCallViews = null;
		}
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<LoadTaskStatus> LoadTaskStatus(int CompanyID)
	{
		return DepartmentBaseClass.LoadTaskStatusList(CompanyID);
	}

	[WebMethod(EnableSession=true)]
	public static List<LoadEditSubject> LoadTaskSubject(int CompanyID)
	{
		DataTable dataTable = Settings.settings_subject_select(CompanyID);
		List<LoadEditSubject> loadEditSubjects = new List<LoadEditSubject>();
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				LoadEditSubject loadEditSubject = new LoadEditSubject()
				{
					sampleSubject = row["sampleSubject"].ToString(),
					sampleSubjectId = row["sampleSubjectId"].ToString(),
					IsDefault = row["IsDefault"].ToString()
				};
				loadEditSubjects.Add(loadEditSubject);
			}
		}
		return loadEditSubjects;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		this.objBase.ReturnRoles_Privileges_Tabs("clients", "isview", "");
		global.pageName = "client";
		global.pgName = "";
		this.gloobj.setpagename("client");
		this.pg = "Client";
		this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
		this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
		base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.ReturnScreenName("CLIENTS", 2, "p").ToUpper(), " Detail"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
		base.Navigation_Path("<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>Customer View</a>", "&nbsp;>&nbsp;Customer Details");
		this.DateFormat = this.Session["DateFormat"].ToString();
		client_detail.DateFormatNew = this.DateFormat;
		commonClass _commonClass = this.comncls;
		DateTime now = DateTime.Now;
		this.newdate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.companyid, this.UserID, true);
		this.tabcolor = this.objpage.colorCode(Convert.ToInt32(this.Session["companyid"]), "client");
		try
		{
			string str = Encryption.DecryptQueryString(QueryString.FromCurrent()).ToString();
			ArrayList arrayLists = Encryption.querystrvalue(str);
			this.ClientID = int.Parse(arrayLists[1].ToString());
			this.companyName = arrayLists[3].ToString();
			this.companytype = arrayLists[7].ToString();
			this.QSsuc = arrayLists[8].ToString();
			this.strSuc = arrayLists[9].ToString();
			try
			{
				this.isnew = int.Parse(Convert.ToString(arrayLists[3]));
			}
			catch
			{
			}
		}
		catch
		{
		}
		if (this.companytype.ToLower().Trim() == "customer")
		{
			this.NavigateTo = "<a href=client_view.aspx class='subnavigator' style=text-decoration:underline>";
			string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;", this.NavigateTo, this.objLangClass.GetLanguageConversion("Customer_View"), "</a>" };
			base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Customer_Details"), "&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Summary_Information")));
			this.lbl_header.Text = string.Concat(this.objLangClass.GetLanguageConversion("Customer_Details"), " : ");
		}
		else if (this.companytype.ToLower().Trim() != "supplier")
		{
			this.NavigateTo = "<a href=client_view.aspx?type=Prospect class='subnavigator' style=text-decoration:underline>";
			string[] strArrays = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;", this.NavigateTo, this.objLangClass.GetLanguageConversion("Prospect_View"), "</a>" };
			base.Navigation_Path(string.Concat(strArrays), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Prospect_Details"), "&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Summary_Information")));
			this.lbl_header.Text = string.Concat(this.objLangClass.GetLanguageConversion("Prospect_Details"), " : ");
		}
		else
		{
			this.NavigateTo = "<a href=client_view.aspx?type=Supplier class='subnavigator' style=text-decoration:underline>";
			string[] languageConversion1 = new string[] { "<a href=../welcome.aspx class='subnavigator' style=text-decoration:underline>", this.objLangClass.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;", this.NavigateTo, this.objLangClass.GetLanguageConversion("Supplier_View"), "</a>" };
			base.Navigation_Path(string.Concat(languageConversion1), string.Concat("&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Supplier_Details"), "&nbsp;>&nbsp;", this.objLangClass.GetLanguageConversion("Summary_Information")));
			this.lbl_header.Text = string.Concat(this.objLangClass.GetLanguageConversion("Supplier_Details"), " : ");
		}
		base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(base.ReturnScreenName("CLIENTS", 2, "p").ToUpper(), " Detail"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
		if (!base.IsPostBack)
		{
			DataTable dataTable = CompanyBasePage.company_client_select(this.CompanyID, this.ClientID, this.companytype);
			foreach (DataRow row in dataTable.Rows)
			{
				this.lbl_Company.Text = this.objBase.SpecialDecode(row["clientName"].ToString());
			}
		}
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> SearchCA(string CompanyID, string ClientID, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber, string Type)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ))");
			}
			else if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, " ))");
			}
		}
		else if (StartDate.Trim().Length <= 0 || Enddate.Trim().Length != 0)
		{
			if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
			{
				if (Type == "Task")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else if (Type != "Call")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
					empty = string.Concat(empty, " or ((");
					empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
			}
		}
		else if (Type == "Task")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else if (Type != "Call")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
			empty = string.Concat(empty, " or ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			AllCloseActivity = CRMCloseActivitySearch.ReturnCloseActivitySearch(CompanyID.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber), empty, Type, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> SearchNotes(string CompanyID, string ClientID, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("title");
		arrayLists.Add("subject");
		arrayLists.Add("UserName");
		arrayLists.Add("SpecificName");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			empty = string.Concat(empty, " and ((");
			string str1 = empty;
			string[] startDate = new string[] { str1, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
			empty = string.Concat(startDate);
			empty = string.Concat(empty, " ) or (");
			string str2 = empty;
			string[] startDate1 = new string[] { str2, " createDate between '", StartDate, "'  and  '", Enddate, "'" };
			empty = string.Concat(startDate1);
			empty = string.Concat(empty, "))");
		}
		else if (StartDate.Trim().Length > 0 && Enddate.Trim().Length == 0)
		{
			empty = string.Concat(empty, " and ((");
			string str3 = empty;
			string[] strArrays1 = new string[] { str3, " createDate between '", StartDate, "'  and  '", null, null };
			strArrays1[4] = DateTime.Now.ToString();
			strArrays1[5] = "'";
			empty = string.Concat(strArrays1);
			empty = string.Concat(empty, " ) or (");
			string str4 = empty;
			string[] startDate2 = new string[] { str4, " createDate between '", StartDate, "'  and  '", null, null };
			startDate2[4] = DateTime.Now.ToString();
			startDate2[5] = "'";
			empty = string.Concat(startDate2);
			empty = string.Concat(empty, "))");
		}
		else if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
			empty = string.Concat(empty, " ) or (");
			empty = string.Concat(empty, " createDate between '1/1/1900'  and  '", Enddate, "'");
			empty = string.Concat(empty, "))");
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			Alltask = CRMNotesSearch.ReturnNotesSearch(CompanyID.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber), empty, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<CRMCallView> SearchOA(string CompanyID, string ClientID, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber, string Type)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0)
		{
			if (Type == "Task")
			{
				empty = string.Concat(empty, " and ((");
				string str1 = empty;
				string[] startDate = new string[] { str1, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate);
				empty = string.Concat(empty, " ))");
			}
			else if (Type != "Call")
			{
				empty = string.Concat(empty, " and ((");
				string str2 = empty;
				string[] startDate1 = new string[] { str2, " duedate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate1);
				empty = string.Concat(empty, " ))");
				empty = string.Concat(empty, " or ((");
				string str3 = empty;
				string[] strArrays1 = new string[] { str3, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(strArrays1);
				empty = string.Concat(empty, " ))");
			}
			else
			{
				empty = string.Concat(empty, " and ((");
				string str4 = empty;
				string[] startDate2 = new string[] { str4, " CallStartdate between '", StartDate, "'  and  '", Enddate, "'" };
				empty = string.Concat(startDate2);
				empty = string.Concat(empty, " ))");
			}
		}
		else if (StartDate.Trim().Length <= 0 || Enddate.Trim().Length != 0)
		{
			if (StartDate.Trim().Length == 0 && Enddate.Trim().Length > 0)
			{
				if (Type == "Task")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else if (Type != "Call")
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " duedate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
					empty = string.Concat(empty, " or ((");
					empty = string.Concat(empty, " CallStartdate between '2/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
				else
				{
					empty = string.Concat(empty, " and ((");
					empty = string.Concat(empty, " CallStartdate between '1/1/1900'  and  '", Enddate, "'");
					empty = string.Concat(empty, " ))");
				}
			}
		}
		else if (Type == "Task")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else if (Type != "Call")
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " duedate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
			empty = string.Concat(empty, " or ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		else
		{
			empty = string.Concat(empty, " and ((");
			empty = string.Concat(empty, " CallStartdate >= '", StartDate, "'");
			empty = string.Concat(empty, " ) )");
		}
		List<CRMCallView> cRMCallViews = new List<CRMCallView>();
		CRMCallView cRMCallView = new CRMCallView()
		{
			AllCalls = CRMOASearch.ReturnOASearch(CompanyID.ToString(), ClientID.ToString(), Convert.ToInt32(NotespageNummber), empty, Type, MultipalSearchText),
			CallID = "0"
		};
		cRMCallViews.Add(cRMCallView);
		return cRMCallViews;
	}

	[WebMethod(EnableSession=true)]
	public static IList<SearchResults> SearchOpenActivities(string CompanyID, string ClientID, string MultipalSearchText, string StartDate, string Enddate, string NotespageNummber)
	{
		BaseClass baseClass = new BaseClass();
		string empty = string.Empty;
		if (MultipalSearchText != "")
		{
			MultipalSearchText = baseClass.SpecialEncode(MultipalSearchText.ToString());
		}
		if (StartDate.Trim().Length > 2)
		{
			StartDate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, StartDate.ToString());
		}
		if (Enddate.Trim().Length > 2)
		{
			Enddate = baseClass.DateFormat_Return_As_MM_DD_YYYY(client_detail.DateFormatNew, Enddate.ToString());
		}
		ArrayList arrayLists = new ArrayList();
		arrayLists.Add("SectionName");
		arrayLists.Add("Subject");
		arrayLists.Add("Status");
		arrayLists.Add("Contactname");
		arrayLists.Add("AssignTo");
		if (MultipalSearchText.Trim().Length > 0)
		{
			char[] chrArray = new char[] { ' ' };
			string[] strArrays = MultipalSearchText.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
			empty = " and (";
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = string.Empty;
				str = "(";
				if (strArrays[i].Length > 0)
				{
					for (int j = 0; j < arrayLists.Count; j++)
					{
						if (j != arrayLists.Count - 1)
						{
							object obj = str;
							object[] item = new object[] { obj, arrayLists[j], " like '%", strArrays[i].ToString(), "%' or " };
							str = string.Concat(item);
						}
						else
						{
							object obj1 = str;
							object[] objArray = new object[] { obj1, arrayLists[j], " like '%", strArrays[i].ToString(), "%' " };
							str = string.Concat(objArray);
						}
					}
					str = string.Concat(str, ")");
					if (str.Trim().Length > 4)
					{
						empty = ((int)strArrays.Length - 1 != i ? string.Concat(empty, str, " and ") : string.Concat(empty, str));
					}
				}
			}
			empty = (empty.Trim().Length <= 7 ? "" : string.Concat(empty, ")"));
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0 && empty.Trim().Length > 2)
		{
			empty = string.Concat(empty, " and ((");
			string str1 = empty;
			string[] startDate = new string[] { str1, " DueDate between '", StartDate, "'  and  '", null, null };
			startDate[4] = DateTime.Now.ToString();
			startDate[5] = "'";
			empty = string.Concat(startDate);
			empty = string.Concat(empty, " ) or (");
			string str2 = empty;
			string[] startDate1 = new string[] { str2, " createddate between '", StartDate, "'  and  '", null, null };
			startDate1[4] = DateTime.Now.ToString();
			startDate1[5] = "'";
			empty = string.Concat(startDate1);
			empty = string.Concat(empty, "))");
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0 && empty.Trim().Length > 2)
		{
			empty = string.Concat(empty, " and ((");
			string str3 = empty;
			string[] strArrays1 = new string[] { str3, " DueDate between '", StartDate, "'  and  '", null, null };
			strArrays1[4] = DateTime.Now.ToString();
			strArrays1[5] = "'";
			empty = string.Concat(strArrays1);
			empty = string.Concat(empty, " ))");
		}
		if (StartDate.Trim().Length > 0 && Enddate.Trim().Length > 0 && empty.Trim().Length > 2)
		{
			empty = string.Concat(empty, " and ((");
			string str4 = empty;
			string[] startDate2 = new string[] { str4, " createddate between '", StartDate, "'  and  '", null, null };
			startDate2[4] = DateTime.Now.ToString();
			startDate2[5] = "'";
			empty = string.Concat(startDate2);
			empty = string.Concat(empty, " ))");
		}
		List<SearchResults> searchResults = DepartmentBaseClass.Crm_Search_OpenActivities(Convert.ToInt64(CompanyID), Convert.ToInt64(ClientID), empty, Convert.ToInt32(NotespageNummber));
		return searchResults;
	}
}
}