using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Department
{
    public class DbDepartment : DataAccess
    {
        public DbDepartment()
        {
        }

        public virtual DataTable address_select(int ClientID, int CompanyID, string SelectAll)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select");
            database.AddInParameter(storedProcCommand, "@clientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@selectall", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable address_select_for_filter(int ClientID, int CompanyID, string SelectAll, string WhereConditionAddress)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_select_Filter");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@clientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@selectall", DbType.String, SelectAll);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionAddress);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet AddressAndCompanyname_select(int ClientID, int CompanyID, string SelectAll,Int32 PageSize,Int32 CurrentPageIndex,string SearchText)
        {
            DataSet dataSet;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet1 = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_addressAndCompanyname_select");
            database.AddInParameter(storedProcCommand, "@clientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@selectall", DbType.String, SelectAll);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, PageSize);
            database.AddInParameter(storedProcCommand, "@CurrentPageIndex", DbType.Int32, CurrentPageIndex);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            
            try
            {
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            catch (Exception exception)
            {
                dataSet = null;
            }
            return dataSet;
        }

        public virtual bool CheckApproveEnable(long ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_IsApprovalSystemEnable");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable client_contacts_select(int ClientID, int CompanyID, string SelectAll)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contacts_select");
            database.AddInParameter(storedProcCommand, "@clientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@selectall", DbType.String, SelectAll);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet client_contacts_selectAll(int ClientID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_contacts_selectAll");
            database.AddInParameter(storedProcCommand, "@clientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void costcenter_details_delete(int CostCenterID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_CostCenter_Delete");
            database.AddInParameter(storedProcCommand, "@CostCenterID", DbType.Int32, CostCenterID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void costcenter_details_insert(int CompanyID, int ClientID, string CostcenterCode, string CostcenterName, int isapplydept, int iscostdefault, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_CostCenter_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CostCenterCode", DbType.String, CostcenterCode);
            database.AddInParameter(storedProcCommand, "@CostCenterName", DbType.String, CostcenterName);
            database.AddInParameter(storedProcCommand, "@IsApplyDepartment", DbType.Int32, isapplydept);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, iscostdefault);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable costcenter_details_select(string CostCenterID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CostCenter_Details_Select");
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.String, CostCenterID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void costcenter_details_update(int CostCenterID, int ClientID, string CostcenterCode, string CostcenterName, int isapplydept, int iscostdefault, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_CostCenter_Update");
            database.AddInParameter(storedProcCommand, "@CostCenterID", DbType.Int32, CostCenterID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CostCenterCode", DbType.String, CostcenterCode);
            database.AddInParameter(storedProcCommand, "@CostCenterName", DbType.String, CostcenterName);
            database.AddInParameter(storedProcCommand, "@IsApplyDepartment", DbType.Int32, isapplydept);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, iscostdefault);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable costcenter_getdefaultcenter(int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_DefaultCostCenter_Select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable costcenter_getdetails(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_CostCentre_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable costcenter_getdetails_for_filter(int CompanyID, int ClientID, string WhereConditionCostcenter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_CostCentre_Select_Filter");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionCostcenter);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet CRM_Alluser_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_CompanyUser_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual List<CRMCallView> Crm_Call_Insert(int CompanyID, int ClientID, string Subject, string CallType, int CallPurpose, string CallDetails, int ContactID, string CallStartdate, string CallStartTime, int CallDurationMinutes, int CallDurationSeconds, string CallResult, int AssignedTo, string Description, bool isBillabel, int CreatedBy, int NotespageNummber, string CallEnddate, string ParentType, int ParentID, long ModuleID, string ModuleName, string ContactPhone, string ContactMobile, string DepartmentPhone)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Customer_Call_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@CallType", DbType.String, CallType);
            database.AddInParameter(storedProcCommand, "@CallPurpose", DbType.Int32, CallPurpose);
            database.AddInParameter(storedProcCommand, "@CallDetails", DbType.String, CallDetails);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@CallStartdate", DbType.String, CallStartdate);
            database.AddInParameter(storedProcCommand, "@CallStartTime", DbType.String, CallStartTime);
            database.AddInParameter(storedProcCommand, "@CallDurationMinutes", DbType.Int32, CallDurationMinutes);
            database.AddInParameter(storedProcCommand, "@CallDurationSeconds", DbType.Int32, CallDurationSeconds);
            database.AddInParameter(storedProcCommand, "@CallResult", DbType.String, CallResult);
            database.AddInParameter(storedProcCommand, "@AssignedTo", DbType.Int32, AssignedTo);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@isBillabel", DbType.Boolean, isBillabel);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@CallEnddate", DbType.String, CallEnddate);
            database.AddInParameter(storedProcCommand, "@ParentType", DbType.String, ParentType);
            database.AddInParameter(storedProcCommand, "@ParentID", DbType.String, ParentID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@ContactPhone", DbType.String, ContactPhone);
            database.AddInParameter(storedProcCommand, "@ContactMobile", DbType.String, ContactMobile);
            database.AddInParameter(storedProcCommand, "@DepartmentPhone", DbType.String, DepartmentPhone);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllCalls = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                CallID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual List<CRMCallView> Crm_Call_Update(long CallID, int CompanyID, int ClientID, string Subject, string CallType, int CallPurpose, string CallDetails, int ContactID, string CallStartdate, string CallStartTime, int CallDurationMinutes, int CallDurationSeconds, string CallResult, int AssignedTo, string Description, bool isBillabel, int LastUpdatedBy, int NotespageNummber, string CallEnddate, string ContactPhone, string ContactMobile, string DepartmentPhone)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Update_Calls");
            database.AddInParameter(storedProcCommand, "@CallID", DbType.Int64, CallID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@CallType", DbType.String, CallType);
            database.AddInParameter(storedProcCommand, "@CallPurpose", DbType.Int32, CallPurpose);
            database.AddInParameter(storedProcCommand, "@CallDetails", DbType.String, CallDetails);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@CallStartdate", DbType.String, CallStartdate);
            database.AddInParameter(storedProcCommand, "@CallStartTime", DbType.String, CallStartTime);
            database.AddInParameter(storedProcCommand, "@CallDurationMinutes", DbType.Int32, CallDurationMinutes);
            database.AddInParameter(storedProcCommand, "@CallDurationSeconds", DbType.Int32, CallDurationSeconds);
            database.AddInParameter(storedProcCommand, "@CallResult", DbType.String, CallResult);
            database.AddInParameter(storedProcCommand, "@AssignedTo", DbType.Int32, AssignedTo);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@isBillabel", DbType.Boolean, isBillabel);
            database.AddInParameter(storedProcCommand, "@LastUpdatedBy", DbType.Int32, LastUpdatedBy);
            database.AddInParameter(storedProcCommand, "@CallEnddate", DbType.String, CallEnddate);
            database.AddInParameter(storedProcCommand, "@ContactPhone", DbType.String, ContactPhone);
            database.AddInParameter(storedProcCommand, "@ContactMobile", DbType.String, ContactMobile);
            database.AddInParameter(storedProcCommand, "@DepartmentPhone", DbType.String, DepartmentPhone);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllOA = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyID.ToString(), ClientID.ToString()),
                AllCalls = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                AllNotes = CRMNotes.ReturnNotes(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                CallID = num.ToString()
            };
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                BaseClass baseClass = new BaseClass();
                cRMCallView.Status = baseClass.SpecialDecode(row["Status"].ToString());
                cRMCallView.Subject = baseClass.SpecialDecode(row["Subject"].ToString());
                cRMCallView.Type = baseClass.SpecialDecode(row["SectionName"].ToString());
                cRMCallView.DueDate = row["DueDate"].ToString();
                cRMCallView.taskTime = row["CallStartTime"].ToString();
                cRMCallView.ContactName = row["Contactname"].ToString();
                cRMCallView.ContactPhone = baseClass.SpecialDecode(row["Contactphone"].ToString());
                cRMCallView.AssignTo = baseClass.SpecialDecode(row["AssignTo"].ToString());
                cRMCallView.Description = baseClass.SpecialDecode(row["Description"].ToString());
            }
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual List<NotesInsertSubject> Crm_Callsubject_Insert(long CompanyID, string StatusTitle, bool IsDefault, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_insert_Callsubject");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, StatusTitle);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<NotesInsertSubject> notesInsertSubjects = new List<NotesInsertSubject>();
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    NotesInsertSubject notesInsertSubject = new NotesInsertSubject()
                    {
                        CompanyID = row["CompanyID"].ToString(),
                        StatusTitle = row["StatusTitle"].ToString(),
                        IsDefault = row["IsDefault"].ToString(),
                        UserID = row["CreatedBy"].ToString()
                    };
                    notesInsertSubjects.Add(notesInsertSubject);
                }
            }
            return notesInsertSubjects;
        }

        public virtual List<CRMCallView> Crm_Completed_Call(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_Completed_Call");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@Sectionname", DbType.String, Sectionname);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllOA = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyID.ToString(), ClientId.ToString()),
                Alltask = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual DataSet CRM_Contact_select(int CompanyID, int clientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_Contact_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, clientID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual List<CRMContactNotesView> Crm_ContactNotes_Insert(int companyId, string sectionname, int sectionid, string filename, string filesize, int createUserId, string subject, string title, int NotespageNummber, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Notes_add");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, filename);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, filesize);
            database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, createUserId);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, title);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.String, ContactID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMContactNotesView> cRMContactNotesViews = new List<CRMContactNotesView>();
            CRMContactNotesView cRMContactNotesView = new CRMContactNotesView()
            {
                AllNotes = CRMContactNotes.ReturnContactNotes(ContactID.ToString()),
                attachmentID = num.ToString()
            };
            cRMContactNotesViews.Add(cRMContactNotesView);
            return cRMContactNotesViews;
        }

        public virtual List<CRMContactNotesView> Crm_ContactNotes_Update(int attachmentId, int companyId, string sectionname, int sectionid, string filename, string filesize, int modifyUserID, string subject, string title, int NotespageNummber, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Update_ContactNotes");
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, filename);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, filesize);
            database.AddInParameter(storedProcCommand, "@modifyUserID", DbType.Int32, modifyUserID);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, title);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMContactNotesView> cRMContactNotesViews = new List<CRMContactNotesView>();
            CRMContactNotesView cRMContactNotesView = new CRMContactNotesView()
            {
                AllNotes = CRMContactNotes.ReturnContactNotes(ContactID.ToString()),
                attachmentID = num.ToString()
            };
            cRMContactNotesViews.Add(cRMContactNotesView);
            return cRMContactNotesViews;
        }

        public virtual List<CRMCloseActi> Crm_Delete_CloseActivities(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_DeleteCloseActivity");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@Sectionname", DbType.String, Sectionname);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCloseActi> cRMCloseActis = new List<CRMCloseActi>();
            CRMCloseActi cRMCloseActi = new CRMCloseActi()
            {
                AllCL = CRMAllCloseActivity.ReturnAllCloseActivity(CompanyID.ToString(), ClientId.ToString()),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                AllNotes = CRMNotes.ReturnNotes(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCloseActis.Add(cRMCloseActi);
            return cRMCloseActis;
        }

        public virtual List<CRMContactNotesView> Crm_Delete_ContactNotes(int companyId, int sectionid, int attachmentId, int NotespageNummber, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Delete_Contactnotes");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMContactNotesView> cRMContactNotesViews = new List<CRMContactNotesView>();
            CRMContactNotesView cRMContactNotesView = new CRMContactNotesView()
            {
                AllNotes = CRMContactNotes.ReturnContactNotes(ContactID.ToString()),
                attachmentID = num.ToString()
            };
            cRMContactNotesViews.Add(cRMContactNotesView);
            return cRMContactNotesViews;
        }

        public virtual List<CRMNotesView> Crm_Delete_Notes(int companyId, int sectionid, int attachmentId, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Delete_notes");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMNotesView> cRMNotesViews = new List<CRMNotesView>();
            CRMNotesView cRMNotesView = new CRMNotesView()
            {
                AllNotesPrint = CRMNotesPrint.ReturnNotesPrint(companyId.ToString(), sectionid.ToString()),
                AllNotes = CRMNotes.ReturnNotes(companyId.ToString(), sectionid.ToString(), NotespageNummber),
                AllNotesPopup = CRMShowAllNotes.ReturnAllNotes(companyId.ToString(), sectionid.ToString()),
                attachmentID = num.ToString()
            };
            cRMNotesViews.Add(cRMNotesView);
            return cRMNotesViews;
        }

        public virtual List<CRMCallView> Crm_Delete_OpenActivities(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_DeleteTaskEvent");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@Sectionname", DbType.String, Sectionname);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllOA = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyID.ToString(), ClientId.ToString()),
                Alltask = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                AllNotes = CRMNotes.ReturnNotes(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual List<CRMCallView> Crm_Delete_Task(long ID, long CompanyID, long ClientId, string Sectionname, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_DeleteCloseActivity");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@Sectionname", DbType.String, Sectionname);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllOA = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyID.ToString(), ClientId.ToString()),
                AllCL = CRMAllCloseActivity.ReturnAllCloseActivity(CompanyID.ToString(), ClientId.ToString()),
                Alltask = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientId.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual void Crm_DismissAlert_Notifications(long ID, long CompanyID, string SectionName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Crm_Dismiss_Notification");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, SectionName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual List<CallItemsEdit> Crm_Edit_Call(int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Call_Select");
            database.AddInParameter(storedProcCommand, "@CallID", DbType.Int32, id);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<CallItemsEdit> callItemsEdits = new List<CallItemsEdit>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                commonClass _commonClass = new commonClass();
                string str = _commonClass.Eprint_return_DateTime_Before_View(row["CallStartDate"].ToString(), Convert.ToInt32(row["CompanyID"]), num, false);
                string[] strArrays = str.Split(new char[] { ' ' });
                BaseClass baseClass = new BaseClass();
                CallItemsEdit callItemsEdit = new CallItemsEdit()
                {
                    CompanyID = row["CompanyID"].ToString(),
                    Subject = baseClass.SpecialDecode(row["Subject"].ToString()),
                    CallType = baseClass.SpecialDecode(row["CallType"].ToString()),
                    CallPurpose = row["CallPurpose"].ToString(),
                    CallDetails = baseClass.SpecialDecode(row["CallDetails"].ToString()),
                    ContactID = row["ContactID"].ToString(),
                    CallStartdate = strArrays[0].ToString(),
                    CallStartTime = row["CallStartTime"].ToString(),
                    CallDurationMinutes = row["CallDurationMinutes"].ToString(),
                    CallDurationSeconds = row["CallDurationSeconds"].ToString(),
                    CallResult = row["CallResult"].ToString(),
                    AssignedTo = row["AssignedTo"].ToString(),
                    Description = row["Description"].ToString(),
                    isBillabel = row["isBillabel"].ToString(),
                    ContactName = baseClass.SpecialDecode(row["ContactName"].ToString()),
                    ContactEmail = baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()),
                    ContactMobile = baseClass.SpecialDecode(row["ContactMobile"].ToString()),
                    Contactphone = baseClass.SpecialDecode(row["Contactphone"].ToString()),

                    DepartmentName = baseClass.SpecialDecode(row["DepartmentName"].ToString()),
                    AssignTo = baseClass.SpecialDecode(row["AssignTo"].ToString()),
                    DepartmentPhone = baseClass.SpecialDecode(row["TelePhone"].ToString()),

                    clientid = baseClass.SpecialDecode(row["clientid"].ToString()),
                    clientName = baseClass.SpecialDecode(row["clientName"].ToString()),
                    companytype = baseClass.SpecialDecode(row["companytype"].ToString()),
                    companyname = baseClass.SpecialDecode(row["clientName"].ToString()),
                    areff = ""
                };
                callItemsEdits.Add(callItemsEdit);

                //------------------------------
                QueryString queryString = new QueryString()
                {
                    { "clientid", callItemsEdits[0].clientid.ToString() },
                    { "isnew", "2" },
                    { "bypass", "1" },
                    { "type", callItemsEdits[0].companytype.ToString() }
                };
                string strRedirect = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                string str1 = string.Concat(strRedirect, queryString1.ToString());

                //------------------------------
                callItemsEdits[0].areff = str1;
            }
            return callItemsEdits;
        }

        public virtual List<EventItemsEdit> Crm_Edit_Event(int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Event_Select");
            database.AddInParameter(storedProcCommand, "@EventID", DbType.Int32, id);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<EventItemsEdit> eventItemsEdits = new List<EventItemsEdit>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                commonClass _commonClass = new commonClass();
                BaseClass baseClass = new BaseClass();
                string str = _commonClass.Eprint_return_DateTime_Before_View(row["EventDate"].ToString(), Convert.ToInt32(row["CompanyID"]), num, false);
                string[] strArrays = str.Split(new char[] { ' ' });
                EventItemsEdit eventItemsEdit = new EventItemsEdit()
                {
                    CompanyID = row["CompanyID"].ToString(),
                    Subject = baseClass.SpecialDecode(row["Subject"].ToString()),
                    Location = row["Location"].ToString(),
                    ContactId = row["ContactId"].ToString(),
                    ContactType = baseClass.SpecialDecode(row["ContactType"].ToString()),
                    EventDate = strArrays[0].ToString(),
                    EventTime = row["EventTime"].ToString(),
                    Duration = row["Duration"].ToString(),
                    Comment = baseClass.SpecialDecode(row["Comment"].ToString()),
                    assignToUserID = row["assignToUserID"].ToString()
                };
                eventItemsEdits.Add(eventItemsEdit);
            }
            return eventItemsEdits;
        }

        public virtual List<NotesItemsDelete> Crm_Edit_Notes(int attachmentId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_select_notes_foredit");
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<NotesItemsDelete> notesItemsDeletes = new List<NotesItemsDelete>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                BaseClass baseClass = new BaseClass();
                int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                commonClass _commonClass = new commonClass();
                string str = _commonClass.Eprint_return_DateTime_Before_View(row["createDate"].ToString(), Convert.ToInt32(row["CompanyID"]), num, false);
                string[] strArrays = str.Split(new char[] { ' ' });
                int num1 = 0;
                Label label = new Label()
                {
                    ID = string.Concat("lbl_notes_", num1 + 1),
                    Text = row["subject"].ToString().Replace(Environment.NewLine, "~±")
                };
                string[] strArrays1 = label.Text.Split(new char[] { '~' });
                string empty = string.Empty;
                if ((int)strArrays1.Length > 0)
                {
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        empty = string.Concat(empty, baseClass.InsertAtIntervals(strArrays1[i], 180, "<br/>"));
                    }
                }
                label.Text = baseClass.SpecialDecode(empty.Replace("\n", "<br/>"));
                NotesItemsDelete notesItemsDelete = new NotesItemsDelete()
                {
                    attachmentID = row["attachmentId"].ToString(),
                    subjectdet = HttpUtility.HtmlDecode(label.Text),
                    subject = baseClass.SpecialDecode(row["subject"].ToString()),
                    title = baseClass.SpecialDecode(row["title"].ToString()),
                    filename = row["filename"].ToString(),
                    filsize = row["fileSize"].ToString(),
                    companyId = row["companyId"].ToString(),
                    SpecificTo = row["SpecificTo"].ToString(),
                    username = row["CreatedBy"].ToString(),
                    createDate = strArrays[0].ToString(),
                    SpecificName = baseClass.SpecialDecode(row["SpecificToName"].ToString())
                };
                notesItemsDeletes.Add(notesItemsDelete);
            }
            return notesItemsDeletes;
        }

        public virtual List<TaskItemsEdit> Crm_Edit_Task(int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Task_Select");
            database.AddInParameter(storedProcCommand, "@Taskid", DbType.Int32, id);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<TaskItemsEdit> taskItemsEdits = new List<TaskItemsEdit>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                BaseClass baseClass = new BaseClass();
                int num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                commonClass _commonClass = new commonClass();
                string str = _commonClass.Eprint_return_DateTime_Before_View(row["DueDate"].ToString(), Convert.ToInt32(row["CompanyID"]), num, false);
                string[] strArrays = str.Split(new char[] { ' ' });
                TaskItemsEdit taskItemsEdit = new TaskItemsEdit()
                {
                    CompanyId = row["CompanyId"].ToString(),
                    Subject = baseClass.SpecialDecode(row["Subject"].ToString()),
                    TaskStatus = baseClass.SpecialDecode(row["TaskStatus"].ToString()),
                    DueDate = strArrays[0].ToString(),
                    TaskTime = row["TaskTime"].ToString(),
                    ContactId = row["ContactId"].ToString(),
                    ContactType = row["ContactType"].ToString(),
                    Priority = row["Priority"].ToString(),
                    TypeId = row["TypeId"].ToString(),
                    Description = baseClass.SpecialDecode(row["Description"].ToString()),
                    AssignToUserId = row["AssignToUserId"].ToString(),
                    ContactName = baseClass.SpecialDecode(row["ContactName"].ToString()),
                    ContactEmail = baseClass.SpecialDecode(row["ContactEmailAddress"].ToString()),

                    ContactMobile = row["ContactMobile"].ToString(),
                    Contactphone = row["Contactphone"].ToString(),
                    DepartmentName = baseClass.SpecialDecode(row["DepartmentName"].ToString()),

                    DepartmentPhone = row["TelePhone"].ToString(),
                    AssignTo = baseClass.SpecialDecode(row["AssignTo"].ToString()),
                    clientid = baseClass.SpecialDecode(row["clientid"].ToString()),
                    clientName = baseClass.SpecialDecode(row["clientName"].ToString()),
                    companytype = baseClass.SpecialDecode(row["companytype"].ToString()),
                    companyname = baseClass.SpecialDecode(row["clientName"].ToString()),
                    areff = ""

                };
                taskItemsEdits.Add(taskItemsEdit);

                //------------------------------
                QueryString queryString = new QueryString()
                {
                    { "clientid", taskItemsEdits[0].clientid.ToString() },
                    { "isnew", "2" },
                    { "bypass", "1" },
                    { "type", taskItemsEdits[0].companytype.ToString() }
                };
                string strRedirect = string.Concat(this.strSitepath, "client/client_detail.aspx");
                QueryString queryString1 = Encryption.EncryptQueryString(queryString);
                string str1 = string.Concat(strRedirect, queryString1.ToString());

                //------------------------------
                taskItemsEdits[0].areff = str1;
            }
            return taskItemsEdits;
        }

        public virtual List<CRMCallView> Crm_Event_Insert(int companyId, string subject, string Location, int ContactId, string ContactType, string EventDate, string EventType, int EventTypeID, string EventTime, string Duration, int IsAllDay, string Comment, int IsSample, int assignToUserID, int createUserId, string createDate, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_insert_Event");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@Location", DbType.String, Location);
            database.AddInParameter(storedProcCommand, "@ContactId", DbType.Int32, ContactId);
            database.AddInParameter(storedProcCommand, "@ContactType", DbType.String, ContactType);
            database.AddInParameter(storedProcCommand, "@EventDate", DbType.DateTime, EventDate);
            database.AddInParameter(storedProcCommand, "@EventType", DbType.String, EventType);
            database.AddInParameter(storedProcCommand, "@EventTypeID", DbType.Int32, EventTypeID);
            database.AddInParameter(storedProcCommand, "@EventTime", DbType.String, EventTime);
            database.AddInParameter(storedProcCommand, "@Duration", DbType.String, Duration);
            database.AddInParameter(storedProcCommand, "@IsAllDay", DbType.Int32, IsAllDay);
            database.AddInParameter(storedProcCommand, "@Comment", DbType.String, Comment);
            database.AddInParameter(storedProcCommand, "@IsSample", DbType.Int32, IsSample);
            database.AddInParameter(storedProcCommand, "@assignToUserID", DbType.Int32, assignToUserID);
            database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, createUserId);
            database.AddInParameter(storedProcCommand, "@createDate", DbType.DateTime, createDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                Alltask = CRMCalls.ReturnCalls(companyId.ToString(), EventTypeID.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual List<CRMCallView> Crm_Event_Update(int EventID, int CompanyID, string Subject, string Location, int ContactId, string ContactType, string EventDate, string EventType, int EventTypeID, string EventTime, string Duration, string Comment, int assignToUserID, int modifyUserID, string ModifiedDate, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Update_Event");
            database.AddInParameter(storedProcCommand, "@EventID", DbType.Int32, EventID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Location", DbType.String, Location);
            database.AddInParameter(storedProcCommand, "@ContactId", DbType.Int32, ContactId);
            database.AddInParameter(storedProcCommand, "@ContactType", DbType.String, ContactType);
            database.AddInParameter(storedProcCommand, "@EventDate", DbType.DateTime, EventDate);
            database.AddInParameter(storedProcCommand, "@EventType", DbType.String, EventType);
            database.AddInParameter(storedProcCommand, "@EventTypeID", DbType.Int32, EventTypeID);
            database.AddInParameter(storedProcCommand, "@EventTime", DbType.String, EventTime);
            database.AddInParameter(storedProcCommand, "@Duration", DbType.String, Duration);
            database.AddInParameter(storedProcCommand, "@Comment", DbType.String, Comment);
            database.AddInParameter(storedProcCommand, "@assignToUserID", DbType.Int32, assignToUserID);
            database.AddInParameter(storedProcCommand, "@modifyUserID", DbType.Int32, modifyUserID);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                Alltask = CRMCalls.ReturnCalls(CompanyID.ToString(), EventTypeID.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), EventTypeID.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual DataSet CRM_GetEndDateOFCall(int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_SelectCall_Enddate");
            database.AddInParameter(storedProcCommand, "@CallID", DbType.Int32, id);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual List<CRMNotesView> Crm_Notes_Insert(int companyId, string sectionname, int sectionid, string filename, string filesize, int createUserId, string subject, string title, int NotespageNummber, int ContactID, int SpecificTo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Notes_add");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, filename);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, filesize);
            database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, createUserId);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, title);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@SpecificTo", DbType.Int32, SpecificTo);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMNotesView> cRMNotesViews = new List<CRMNotesView>();
            CRMNotesView cRMNotesView = new CRMNotesView()
            {
                AllNotes = CRMNotes.ReturnNotes(companyId.ToString(), sectionid.ToString(), NotespageNummber),
                AllNotesPrint = CRMNotesPrint.ReturnNotesPrint(companyId.ToString(), sectionid.ToString()),
                attachmentID = num.ToString()
            };
            cRMNotesViews.Add(cRMNotesView);
            return cRMNotesViews;
        }

        public virtual List<CRMNotesView> Crm_Notes_Update(int attachmentId, int companyId, string sectionname, int sectionid, string filename, string filesize, int modifyUserID, string subject, string title, int NotespageNummber, int SpecificTo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Update_Notes");
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, filename);
            database.AddInParameter(storedProcCommand, "@filesize", DbType.String, filesize);
            database.AddInParameter(storedProcCommand, "@modifyUserID", DbType.Int32, modifyUserID);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, title);
            database.AddInParameter(storedProcCommand, "@SpecificTo", DbType.Int32, SpecificTo);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMNotesView> cRMNotesViews = new List<CRMNotesView>();
            CRMNotesView cRMNotesView = new CRMNotesView()
            {
                AllNotesPrint = CRMNotesPrint.ReturnNotesPrint(companyId.ToString(), sectionid.ToString()),
                AllNotesPopup = CRMShowAllNotes.ReturnAllNotes(companyId.ToString(), sectionid.ToString()),
                AllNotes = CRMNotes.ReturnNotes(companyId.ToString(), sectionid.ToString(), NotespageNummber),
                attachmentID = num.ToString()
            };
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                BaseClass baseClass = new BaseClass();
                int num1 = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                commonClass _commonClass = new commonClass();
                string str = _commonClass.Eprint_return_DateTime_Before_View(row["createDate"].ToString(), Convert.ToInt32(row["CompanyID"]), num1, false);
                string[] strArrays = str.Split(new char[] { ' ' });
                cRMNotesView.NoteTitle = baseClass.SpecialDecode(row["title"].ToString());
                cRMNotesView.SpecificToName = baseClass.SpecialDecode(row["SpecificName"].ToString());
                cRMNotesView.AddedBy = baseClass.SpecialDecode(row["UserName"].ToString());
                cRMNotesView.Date = strArrays[0].ToString();
                cRMNotesView.NoteContent = baseClass.SpecialDecode(row["subject"].ToString());
            }
            cRMNotesViews.Add(cRMNotesView);
            return cRMNotesViews;
        }

        public virtual DataSet CRM_Print_Customer_Info_with_Dept_Info(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Print_Customer_Info_with_DeptInfo");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Print_Customer_Info_with_Main_Contact_and_Address(int CompanyID, int ClientID, string CompanyType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Print_Customer_Info_with_Main_Contact_and_Address");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual List<SearchResults> Crm_Search_OpenActivities(long CompanyID, long ClientID, string WhereCondition, int NotespageNummber)
        {
            List<SearchResults> searchResults;
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_SearchNotesCallAndTask");
                database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyID);
                database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
                List<SearchResults> searchResults1 = new List<SearchResults>();
                SearchResults searchResult = new SearchResults()
                {
                    AllNotes = CRMNotes.ReturnNotes(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                    AllOpenActivities = CRMCalls.ReturnCalls(CompanyID.ToString(), ClientID.ToString(), NotespageNummber),
                    AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), ClientID.ToString(), NotespageNummber)
                };
                searchResults1.Add(searchResult);
                searchResults = searchResults1;
            }
            catch (Exception exception)
            {
                searchResults = null;
            }
            return searchResults;
        }

        public virtual DataSet Crm_Select_Addreess(long ClientID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ContactCompanyAddress_select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Crm_Select_Alert_Notifications(int CompanyID, int UserID, string CurrentDate, bool IsAdvancedCrm)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_SelectAlert_Notification");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CurrentDate", DbType.String, CurrentDate);
            database.AddInParameter(storedProcCommand, "@IsAdvanceCRM", DbType.Boolean, IsAdvancedCrm);
            return database.ExecuteDataSet(storedProcCommand);

        }

        public virtual DataSet CRM_Select_AttachedFileName(int attachmentId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Select_AttachedFileName");
            database.AddInParameter(storedProcCommand, "@attachmentId", DbType.Int32, attachmentId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_CallPurpose(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_CrmCallPurpose");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_CloseActivities(int ClientID, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEventForCloseActivity_Select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_CloseActivities_Search(int ClientID, int CompanyId, string WhereCondition)
        {
            DataSet dataSet;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet1 = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEventForCloseActivity_Select_search");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            try
            {
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            catch (Exception exception)
            {
                dataSet = null;
            }
            return dataSet;
        }

        public virtual DataSet Crm_select_CloseActivity_SalesTargetSearch(int ClientID, int CompanyId, int UserID, string WhereCondition, string Type, string SearchText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_select_CloseActivity_SalesTarget_Search");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            try
            {
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            catch (Exception exception)
            {
                throw;
            }
            return dataSet;
        }

        public virtual DataSet CRM_Select_Contact_Notes(int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Select_Contact_Notes");
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Conversion_Persentage_Est_Job(int ClientId, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRm_GetJoBConversionPercentage");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Conversion_Persentage_Est_toInvoice(int ClientId, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRm_GetInvoiceConversionPercentage");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_OpenActivities(int ClientID, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEvent_Select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_OpenActivitiesSearch(int ClientID, int CompanyId, string WhereCondition)
        {
            DataSet dataSet;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet1 = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEvent_Select_search");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            try
            {
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            catch (Exception exception)
            {
                dataSet = null;
            }
            return dataSet;
        }

        public virtual DataSet CRM_Select_SalesTarget(int UserID, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Select_SalesTarget");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Crm_Select_TaskEventCall_Scheduler_Details(long ID, string SectionName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_Scheduler_Details");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Top3Estimate(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2BEstimateNumberValue_Select");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@SelespersonId", DbType.Int64, SelespersonId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Top3Invoice(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2BInvoiceNumberValue_Select");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@SelespersonId", DbType.Int64, SelespersonId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Top3Job(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2BJobNumberJobValue_Select");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int32, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@SelespersonId", DbType.Int64, SelespersonId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Top3Order(int ClientId, int CompanyId, string CompanyType, string ShowRecords, long SelespersonId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2BOrderNumberValue_Select");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int64, ClientId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@SelespersonId", DbType.Int64, SelespersonId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_TopFiveContact(long Clientid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Select_TopFive_Contact");
            database.AddInParameter(storedProcCommand, "@Clientid", DbType.Int64, Clientid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_TopFiveNotes(int companyId, int sectionid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Select_top_5Notes");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_TopFiveNotesSearch(int companyId, int sectionid, string WhereCondition, string SearchText)
        {
            DataSet dataSet;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet1 = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Select_top_5Notes_Search");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            try
            {
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            catch (Exception exception)
            {
                dataSet = null;
            }
            return dataSet;
        }

        public virtual DataSet CRM_Select_TopTenNotes(int companyId, int sectionid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Select_top_10Notes");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, sectionid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Type_fromUsertype(int CompanyID, int UserTypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Select_Type_fromUsertype");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int32, UserTypeID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Type_fromUsertype(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Select_UserTypeID");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual List<NotesInsertSubject> Crm_subject_Insert(string sampleSubject, int companyId, string languagename)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_insert_subject");
            database.AddInParameter(storedProcCommand, "@sampleSubject", DbType.String, sampleSubject);
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@languagename", DbType.String, languagename);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            List<NotesInsertSubject> notesInsertSubjects = new List<NotesInsertSubject>();
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    BaseClass baseClass = new BaseClass();
                    NotesInsertSubject notesInsertSubject = new NotesInsertSubject()
                    {
                        sampleSubject = baseClass.SpecialDecode(row["sampleSubject"].ToString()),
                        companyId = row["companyId"].ToString(),
                        languagename = row["languagename"].ToString()
                    };
                    notesInsertSubjects.Add(notesInsertSubject);
                }
            }
            return notesInsertSubjects;
        }

        public virtual List<CRMCallView> Crm_Task_Insert(int companyId, string subject, string taskTitle, string taskStatus, string dueDate, string taskTime, int contactId, string priority, string type, long typeid, string description, int isSample, int assignToUserId, int createUserId, int modifyUserId, string createDate, string modifiedDate, string contactType, int isDelete, int NotespageNummber, string ParentType, int ParentID, long ModuleID, string ModuleName, string ContactPhone, string ContactMobile, string DepartmentPhone)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_insert_task");
            database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@taskTitle", DbType.String, taskTitle);
            database.AddInParameter(storedProcCommand, "@taskStatus", DbType.String, taskStatus);
            database.AddInParameter(storedProcCommand, "@dueDate", DbType.DateTime, dueDate);
            database.AddInParameter(storedProcCommand, "@taskTime", DbType.String, taskTime);
            database.AddInParameter(storedProcCommand, "@contactId", DbType.Int32, contactId);
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@typeid", DbType.Int64, typeid);
            database.AddInParameter(storedProcCommand, "@description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@isSample", DbType.Int32, isSample);
            database.AddInParameter(storedProcCommand, "@assignToUserId", DbType.Int32, assignToUserId);
            database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, createUserId);
            database.AddInParameter(storedProcCommand, "@modifyUserId", DbType.Int32, modifyUserId);
            database.AddInParameter(storedProcCommand, "@createDate", DbType.DateTime, createDate);
            database.AddInParameter(storedProcCommand, "@modifiedDate", DbType.DateTime, modifiedDate);
            database.AddInParameter(storedProcCommand, "@contactType", DbType.String, contactType);
            database.AddInParameter(storedProcCommand, "@isDelete", DbType.Int32, isDelete);
            database.AddInParameter(storedProcCommand, "@ParentType", DbType.String, ParentType);
            database.AddInParameter(storedProcCommand, "@ParentID", DbType.Int32, ParentID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@ContactPhone", DbType.String, ContactPhone);
            database.AddInParameter(storedProcCommand, "@ContactMobile", DbType.String, ContactMobile);
            database.AddInParameter(storedProcCommand, "@DepartmentPhone", DbType.String, DepartmentPhone);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                Alltask = CRMCalls.ReturnCalls(companyId.ToString(), typeid.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual List<CRMCallView> Crm_Task_Update(int taskID, int CompanyID, string subject, string taskStatus, string dueDate, string taskTime, int contactId, string contactType, string priority, string type, int typeId, string description, int assignToUserId, int modifyUserId, string modifiedDate, int NotespageNummber, string ContactPhone, string ContactMobile, string DepartmentPhone)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Update_task");
            database.AddInParameter(storedProcCommand, "@taskID", DbType.Int32, taskID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@subject", DbType.String, subject);
            database.AddInParameter(storedProcCommand, "@taskStatus", DbType.String, taskStatus);
            database.AddInParameter(storedProcCommand, "@dueDate", DbType.String, dueDate);
            database.AddInParameter(storedProcCommand, "@taskTime", DbType.String, taskTime);
            database.AddInParameter(storedProcCommand, "@contactId", DbType.Int32, contactId);
            database.AddInParameter(storedProcCommand, "@contactType", DbType.String, contactType);
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@typeId", DbType.Int32, typeId);
            database.AddInParameter(storedProcCommand, "@description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@assignToUserId", DbType.Int32, assignToUserId);
            database.AddInParameter(storedProcCommand, "@modifyUserId", DbType.Int32, modifyUserId);
            database.AddInParameter(storedProcCommand, "@modifiedDate", DbType.String, modifiedDate);
            database.AddInParameter(storedProcCommand, "@ContactPhone", DbType.String, ContactPhone);
            database.AddInParameter(storedProcCommand, "@ContactMobile", DbType.String, ContactMobile);
            database.AddInParameter(storedProcCommand, "@DepartmentPhone", DbType.String, DepartmentPhone);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMCallView> cRMCallViews = new List<CRMCallView>();
            CRMCallView cRMCallView = new CRMCallView()
            {
                AllOA = CRMShowAllOpenActivities.ReturnAllOpenActivities(CompanyID.ToString(), typeId.ToString()),
                Alltask = CRMCalls.ReturnCalls(CompanyID.ToString(), typeId.ToString(), NotespageNummber),
                AllCloseActivity = CRMCloseActivity.ReturnCloseActivity(CompanyID.ToString(), typeId.ToString(), NotespageNummber),
                taskID = num.ToString()
            };
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                BaseClass baseClass = new BaseClass();
                cRMCallView.Status = baseClass.SpecialDecode(row["Status"].ToString());
                cRMCallView.Subject = baseClass.SpecialDecode(row["Subject"].ToString());
                cRMCallView.Type = row["SectionName"].ToString();
                cRMCallView.DueDate = row["DueDate"].ToString();
                cRMCallView.taskTime = row["taskTime"].ToString();
                cRMCallView.ContactName = baseClass.SpecialDecode(row["Contactname"].ToString());
                cRMCallView.ContactEmail = baseClass.SpecialDecode(row["ContactEmailAddress"].ToString());
                cRMCallView.ContactPhone = baseClass.SpecialDecode(row["Contactphone"].ToString());
                cRMCallView.DepartmentName = baseClass.SpecialDecode(row["DepartmentName"].ToString());

                cRMCallView.AssignTo = baseClass.SpecialDecode(row["AssignTo"].ToString());
                cRMCallView.Description = baseClass.SpecialDecode(row["Description"].ToString());
            }
            cRMCallViews.Add(cRMCallView);
            return cRMCallViews;
        }

        public virtual DataSet Crm_TaskEvent_Select_SalesTerget(int ClientID, int CompanyId, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEvent_Select_SalesTerget");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Crm_TaskEvent_Select_SalesTerget_Search(int ClientID, int CompanyId, int UserID, string WhereCondition, string Type, string SearchText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_TaskEvent_Select_SalesTerget_Search");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void CRM_Update_AttacmentFileName(int attachmentID, int CompanyID, string fileName, string fileSize)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_AttachFile_Update");
            database.AddInParameter(storedProcCommand, "@attachmentID", DbType.Int32, attachmentID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@fileName", DbType.String, fileName);
            database.AddInParameter(storedProcCommand, "@fileSize", DbType.String, fileSize);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual List<CRMContactView> Crm_Update_Contact(int companyID, int clientid, int contactid, int NotespageNummber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_Set_defaultcontact");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, companyID);
            database.AddInParameter(storedProcCommand, "@clientid", DbType.Int32, clientid);
            database.AddInParameter(storedProcCommand, "@contactid", DbType.Int32, contactid);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            long num = (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
            List<CRMContactView> cRMContactViews = new List<CRMContactView>();
            CRMContactView cRMContactView = new CRMContactView();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                CallItemsEdit callItemsEdit = new CallItemsEdit();
                cRMContactView.ContactName = row["ContactName"].ToString();
                cRMContactView.Mobile = row["PersonalPhone"].ToString();
                cRMContactView.Email = row["Email"].ToString();
            }
            cRMContactView.AllContacts = CRMContacts.ReturnContacts(clientid.ToString(), NotespageNummber);
            cRMContactView.ContactID = num.ToString();
            cRMContactViews.Add(cRMContactView);
            return cRMContactViews;
        }

        public virtual DataSet CRM_user_select(int CompanyID, int UserID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_user_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskCall_Today_ForallUsers(long CompanyId, long UserId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskCall_Today_ForallUsers");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserId", DbType.Int64, UserId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskEventCall_Scheduler(int ClientID, int CompanyId, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_Scheduler");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskEventCall_ThiSweek(int ClientID, int CompanyId, int UserID, DateTime SelectedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_ThiSweek");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@SelectedDate", DbType.DateTime, SelectedDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskEventCall_Today(long ClientID, long CompanyId, int UserID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_Today");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskEventCall_Today_ForallUsers(long ClientID, long CompanyId, long UserId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_Today_ForallUsers");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserId", DbType.Int64, UserId);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable department_getAllDetails(int CompanyID, int UserID, int CustomerID, long DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_department_getAllDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.String, CustomerID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet department_getAllDetails_for_filter(int CompanyID, int UserID, int CustomerID, long DeptID, int pageno, int pagesize, string WhereConditionDepartment)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);            
            DataSet departments = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_department_getAllDetails_Filter");
            storedProcCommand.CommandTimeout = Int32.MaxValue;        
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.String, CustomerID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.String, pageno);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int64, pagesize);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionDepartment);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                //dataTable.Load(dataReader);
                do
                {
                    var datatable = new DataTable();
                    datatable.Load(dataReader);
                    departments.Tables.Add(datatable);
                }
                while (!dataReader.IsClosed);
            }
            return departments;
        }

        public virtual DataTable department_getDeptNameID(int CompanyID, int UserID, int CustomerID, long DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_department_getDeptNameID");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.String, CustomerID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void departmentcostcentre_delete(long DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_DepartmentCostCentre_Delete");
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DeptID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void departmentcostcentre_insert(int DeptID, int selectedcostcenter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_DepartmentCostCentre_Insert");
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int32, DeptID);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int32, selectedcostcenter);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable departmentcostcentre_select(int DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DepartmentCostCentre_select");
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int32, DeptID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable DepartmentCustomFields_ScreenName_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DepartmentCustomFields_ScreenName_Select");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void departmentDelete(int CompanyID, int UserID, int DeleteDeptID, int AssignedDeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_departmentDelete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@DeleteDeptID", DbType.Int32, DeleteDeptID);
            database.AddInParameter(storedProcCommand, "@AssignedDeptID", DbType.Int32, AssignedDeptID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long departmentInsert(long DeptID, string DeptName, int CustomerID, int ContactID, int UserID, int AddressID, string AddressType, DateTime CreatedDate, DateTime ModifiedDate, int CompanyID, long DeliveryAddressID, int DeptApproverID, int CostCenterID, string Othercostcenter, bool IsApprovalNotRequired, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, long InvoiceContactID, string OriginalFileName, string ActualFilename, bool IsPdf, string Territory_Manager_Email)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_departmentInsert");
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            database.AddInParameter(storedProcCommand, "@DeptName", DbType.String, DeptName);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            database.AddInParameter(storedProcCommand, "@DefaultContactID", DbType.Int32, ContactID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int32, AddressID);
            database.AddInParameter(storedProcCommand, "@AddressType", DbType.String, AddressType);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@DeptApproverID", DbType.Int32, DeptApproverID);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int32, CostCenterID);
            database.AddInParameter(storedProcCommand, "@OtherCostCenter", DbType.String, Othercostcenter);
            database.AddInParameter(storedProcCommand, "@IsApprovalNotRequired", DbType.String, IsApprovalNotRequired);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, CustomField1);
            database.AddInParameter(storedProcCommand, "@CustomField2", DbType.String, CustomField2);
            database.AddInParameter(storedProcCommand, "@CustomField3", DbType.String, CustomField3);
            database.AddInParameter(storedProcCommand, "@CustomField4", DbType.String, CustomField4);
            database.AddInParameter(storedProcCommand, "@CustomField5", DbType.String, CustomField5);
            database.AddInParameter(storedProcCommand, "@CustomField6", DbType.String, CustomField6);
            database.AddInParameter(storedProcCommand, "@CustomField7", DbType.String, CustomField7);
            database.AddInParameter(storedProcCommand, "@CustomField8", DbType.String, CustomField8);
            database.AddInParameter(storedProcCommand, "@CustomField9", DbType.String, CustomField9);
            database.AddInParameter(storedProcCommand, "@CustomField10", DbType.String, CustomField10);
            database.AddInParameter(storedProcCommand, "@CustomField11", DbType.String, CustomField11);
            database.AddInParameter(storedProcCommand, "@CustomField12", DbType.String, CustomField12);
            database.AddInParameter(storedProcCommand, "@CustomField13", DbType.String, CustomField13);
            database.AddInParameter(storedProcCommand, "@CustomField14", DbType.String, CustomField14);
            database.AddInParameter(storedProcCommand, "@CustomField15", DbType.String, CustomField15);
            database.AddInParameter(storedProcCommand, "@InvoiceContactID", DbType.Int64, InvoiceContactID);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@ActualFilename", DbType.String, ActualFilename);
            database.AddInParameter(storedProcCommand, "@IsPdf", DbType.Boolean, IsPdf);
            database.AddInParameter(storedProcCommand, "@TerritoryManagerEmail", DbType.String, Territory_Manager_Email);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void departmentSetDefault(int CompanyID, int DeptID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_departmentSetDefault");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int32, DeptID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Forecast_Select_month(long CompanyId, int QuarterNo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_RegionalSetting_Monthname_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@QuarterNo", DbType.Int32, QuarterNo);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable GetContactNames(int ClientID, int CompanyID, string ContactName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetContactNames");
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactName", DbType.String, ContactName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable IsApprovalSystem_Enable(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_ApprovelType_ApprovelEmail");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual List<LoadCustomer> LoadCustomerList(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_customer_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            List<LoadCustomer> loadCustomers = new List<LoadCustomer>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    LoadCustomer loadCustomer = new LoadCustomer()
                    {
                        ClientName = row["ClientName"].ToString(),
                        ClientID = row["ClientID"].ToString()
                    };
                    loadCustomers.Add(loadCustomer);
                }
            }
            return loadCustomers;
        }

        public virtual List<LoadCustomerNameOnSummary> LoadCustomerNameOnSummary(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, "customer");
            dataSet = database.ExecuteDataSet(storedProcCommand);
            List<LoadCustomerNameOnSummary> loadCustomerNameOnSummaries = new List<LoadCustomerNameOnSummary>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    LoadCustomerNameOnSummary loadCustomerNameOnSummary = new LoadCustomerNameOnSummary()
                    {
                        ClientName = row["ClientName"].ToString()
                    };
                    loadCustomerNameOnSummaries.Add(loadCustomerNameOnSummary);
                }
            }
            return loadCustomerNameOnSummaries;
        }

        public virtual List<LoadTaskStatus> LoadTaskStatusList(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_taskstatus_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            List<LoadTaskStatus> loadTaskStatuses = new List<LoadTaskStatus>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    LoadTaskStatus loadTaskStatu = new LoadTaskStatus()
                    {
                        taskStatus = row["taskstatus"].ToString(),
                        tastStatusID = row["taskstatusid"].ToString()
                    };
                    loadTaskStatuses.Add(loadTaskStatu);
                }
            }
            return loadTaskStatuses;
        }

        public virtual List<DDLBindList> PopupDDLBind(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_Contact_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, ClientID);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            List<DDLBindList> dDLBindLists = new List<DDLBindList>();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DDLBindList dDLBindList = new DDLBindList()
                    {
                        CompanyName = row["CompanyName"].ToString(),
                        ContactName = row["contactname"].ToString(),
                        ContactID = row["Contactid"].ToString(),
                        DefaultContact = row["DefaultContact"].ToString(),
                        ContactPhone = row["HomeTelephone"].ToString(),
                        ContactMobile = row["mobile"].ToString(),
                        DepartmentPhone = row["Telephone"].ToString()
                    };
                    dDLBindLists.Add(dDLBindList);
                }
            }
            return dDLBindLists;
        }

        public virtual DataSet rm_select_CloseActivity_SalesTarget(int ClientID, int CompanyId, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_select_CloseActivity_SalesTarget");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }
    }
}