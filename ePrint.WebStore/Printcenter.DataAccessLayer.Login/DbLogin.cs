using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.UI.LoginNew;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.Login
{
	public class DbLogin
	{
		public DbLogin()
		{
		}

		public DataTable accounts_getAccountDetails(int accountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getAccountDetails");
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable AddEditAddress_select(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_StoreUser_AddEditAddress_orderingprocess");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Address_Insert_Registration(long AccountID, string Address, string AddressLine2, string City, string State, string Country, string Telephone, string Fax, string ZipCode, string AddressLabel)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_address_insert_Registration");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
			database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
			database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
			database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
			database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
			database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
			database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
			database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, ZipCode);
			database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public DataSet ApproversEmail_Select(long AccountID, long DepartmentID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_ApproversEmail_Select");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataTable b2b_Campaign_Select(long AccountID, long CompanyID, long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_b2b_Campaign_Select");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int Campaign_Duplicate_Check(long ManageID, long AccountID, long CompanyID, string EventName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2b_Campaign_Duplicate_Check");
			database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EventName", DbType.String, EventName);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual int Check_Dept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Check_Dept_Duplicacy");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@DeptName", DbType.String, DeptName);
			database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int32, DeptID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicacy_for_Account");
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, Client_ID);
			database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, Contact_ID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicacy");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable costcenter_getdefaultcenter(int ClientID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CRM_DefaultCostCenter_Select");
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			DataTable dataTable = new DataTable();
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUser");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@IsPsw", DbType.String, IsPsw);
			database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUserDefault");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@defaultClientID", DbType.Int64, defaultClientID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@IsPsw", DbType.String, IsPsw);
			database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public DataSet Delete_Address_FromTempTable_ForApproval(long StoreUserID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Delete_Address_From_TempTable_ForApproval");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual long departmentInsert(long DeptID, string DeptName, int CustomerID, int ContactID, int UserID, int AddressID, string AddressType, DateTime CreatedDate, DateTime ModifiedDate, int CompanyID, long DeliveryAddressID, int DeptApproverID, int CostCenterID, string Othercostcenter, bool IsApprovalNotRequired, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, long InvoiceContactID, string OriginalFileName, string ActualFilename, bool IsPdf)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public long ExistanceOfEmail(string EmailID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_ApproverEmail_Check");
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public long ExistanceOfPassword(long StoreUserID, string Password)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_ApproverPassword_Check");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public string FetchLanguageConversion(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Fetch_LanguageConversion_FileName");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			object obj = database.ExecuteScalar(storedProcCommand);
			if (obj == null)
			{
				return "";
			}
			return (string)obj;
		}

		public virtual DataTable Get_IsApprovRegistraton_Status(long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_IsApprovRegistraton_Status");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable GetCompanyIDByAccountID(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_GetCompanyIDFromAccountID");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataSet GetDepartmentName(long DepartmentID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_GetDepartmentName");
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public int GetIsRightBanner(int CompanyID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsRightBanner");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public DataSet GetSiteMapData(long CategoryIDint, int CompanyID, long AccountID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GenerateSiteMAP");
			database.AddInParameter(storedProcCommand, "@ParentCategoryID", DbType.Int64, CategoryIDint);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet Insert_Approved_Address_ForAdmin(long StoreUserID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet Insert_Edit_Address_IsActive(long StoreUserID, long ApproverUserID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Update_IsActive");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@IsActive", DbType.Int32, 1);
			database.AddInParameter(storedProcCommand, "@Approved_Or_Rejected_By", DbType.Int64, ApproverUserID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet Insert_Edit_Address_RejectReason(long StoreUserID, string RejectedReason, long Approved_Or_Rejected_By)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Insert_Reject_Reason");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@RejectedReason", DbType.String, RejectedReason);
			database.AddInParameter(storedProcCommand, "@Approved_Or_Rejected_By", DbType.Int64, Approved_Or_Rejected_By);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet Insert_Edit_Address_RejectReason_For_Approval(long StoreUserID, string RejectedReason, long ApprovedOrRejectedBy)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Insert_Reject_Reason_For_Approval");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@RejectedReason", DbType.String, RejectedReason);
			database.AddInParameter(storedProcCommand, "@ApprovedOrRejectedBy", DbType.Int64, ApprovedOrRejectedBy);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet Insert_StoreUser_temp(int ClientID, long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long AccountID, long AddressID, string ApproverEmail, string ApprovedType, string PersonalProfileEditType)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Insert_Personal_Information_temp");
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
			database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
			database.AddInParameter(storedProcCommand, "@ApprovedType", DbType.String, ApprovedType);
			database.AddInParameter(storedProcCommand, "@PersonalProfileEditType", DbType.String, PersonalProfileEditType);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual int IsSelfRegister_Select(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_RegistrationOption_IsSelfRegister_Select");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			int num = 0;
			if (parameterValue != null)
			{
				num = int.Parse(parameterValue.ToString());
			}
			return num;
		}

		public virtual DataTable LoginTo_Store(string EmailID, string Password, long AccountID, string WebAccountType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_LoginTo_Store");
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@WebAccountType", DbType.String, WebAccountType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void ManageCampign_Insert_Update(long CompanyID, long UserID, long AccountID, long ManageID, string EventTitle, string Venue, string EventCode, DateTime StartDate, DateTime EndDate, string UseType, bool isarchive, string ordernumber, long DeliveryAddressId, DateTime deliveryDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2b_Campaign_InsertUpdate");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
			database.AddInParameter(storedProcCommand, "@Eventname", DbType.String, EventTitle);
			database.AddInParameter(storedProcCommand, "@Venue", DbType.String, Venue);
			database.AddInParameter(storedProcCommand, "@EventCode", DbType.String, EventCode);
			database.AddInParameter(storedProcCommand, "@EventStartdate", DbType.DateTime, StartDate);
			database.AddInParameter(storedProcCommand, "@EventEnddate", DbType.DateTime, EndDate);
			database.AddInParameter(storedProcCommand, "@Createdbytype", DbType.String, UseType);
			database.AddInParameter(storedProcCommand, "@isArchive", DbType.Boolean, isarchive);
			database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, ordernumber);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressId);
			database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, deliveryDate);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public DataTable PendCountUsersandOrders(string Email, long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_PendCountUsersandOrders");
			database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_AccountDetails(long CompanyID, long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Select_AccountDetails");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_AccountInformation(string AccountName)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_AccountInformation_Select");
			database.AddInParameter(storedProcCommand, "@AccountName", DbType.String, AccountName);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_CompanyID(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_CompanyID_By_Account");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_DepartmentID_ApproverUserID(long AccountID, long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Select_DepartmentID_ApproverUserID");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_Departments(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_Select_Departments");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_DeptDetail_For_StoreUser(long AccountID, long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Select_DepartmentDetails_from_StoreUser");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public string Select_Phrases(string PhraseType, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_Select_Phrases");
			database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public DataTable Select_UserDetail(long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_UserPersonal_Address");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_UserDetail_For_Approval(long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_UserPersonal_Address_For_Approval");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SelectB2B_DefaultLandingPage(int CompanyID, long AccountID, string Type)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pagesSelect");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable SelectDefaultAddress(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_SelectDefaultAddress");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SelectInUse_IsArchiveCampaign(long ManageID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_ManageCampaign_InUse_IsArchive_Campaign");
			database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void settings_managecampaign_delete(long ManageID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_managecampaign_delete");
			database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public long StoreUser_Register(LoginItems objLogItems, long CompanyID, long AccountID, string CompanyName, DateTime CreatedDate, bool IsActive, bool IsNewDept)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_Create_StoreUser");
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, objLogItems.FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, objLogItems.LastName);
			database.AddInParameter(storedProcCommand, "@MiddleName", DbType.String, string.Empty);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, objLogItems.DepartmentID);
			database.AddInParameter(storedProcCommand, "@DepartmentName", DbType.String, objLogItems.DepartmentName);
			database.AddInParameter(storedProcCommand, "@Address1", DbType.String, objLogItems.Address1);
			database.AddInParameter(storedProcCommand, "@Address2", DbType.String, objLogItems.Address2);
			database.AddInParameter(storedProcCommand, "@Address3", DbType.String, objLogItems.Address3);
			database.AddInParameter(storedProcCommand, "@Address4", DbType.String, objLogItems.Address4);
			database.AddInParameter(storedProcCommand, "@Address5", DbType.String, objLogItems.Address5);
			database.AddInParameter(storedProcCommand, "@Country", DbType.String, objLogItems.Country);
			database.AddInParameter(storedProcCommand, "@Phone", DbType.String, objLogItems.Telephone);
			database.AddInParameter(storedProcCommand, "@Fax", DbType.String, objLogItems.Fax);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, objLogItems.Email);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, objLogItems.Password);
			database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int64, objLogItems.IsSubscribeuser);
			database.AddInParameter(storedProcCommand, "@DesignatedApproverEmail", DbType.String, objLogItems.ApproverEmail);
			database.AddInParameter(storedProcCommand, "@ApprovalType", DbType.String, objLogItems.ApprovalType);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
			database.AddInParameter(storedProcCommand, "@IsActive", DbType.Boolean, IsActive);
			database.AddInParameter(storedProcCommand, "@IsNewDept", DbType.Boolean, IsNewDept);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public long StoreUser_Register_prefil(LoginItems objLogItems, long CompanyID, long AccountID, string CompanyName, DateTime CreatedDate, bool IsActive, long AddressID, bool IsNewDept)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_Create_StoreUser_Prefil");
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, objLogItems.FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, objLogItems.LastName);
			database.AddInParameter(storedProcCommand, "@MiddleName", DbType.String, string.Empty);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, objLogItems.DepartmentID);
			database.AddInParameter(storedProcCommand, "@DepartmentName", DbType.String, objLogItems.DepartmentName);
			database.AddInParameter(storedProcCommand, "@Address1", DbType.String, objLogItems.Address1);
			database.AddInParameter(storedProcCommand, "@Address2", DbType.String, objLogItems.Address2);
			database.AddInParameter(storedProcCommand, "@Address3", DbType.String, objLogItems.Address3);
			database.AddInParameter(storedProcCommand, "@Address4", DbType.String, objLogItems.Address4);
			database.AddInParameter(storedProcCommand, "@Address5", DbType.String, objLogItems.Address5);
			database.AddInParameter(storedProcCommand, "@Country", DbType.String, objLogItems.Country);
			database.AddInParameter(storedProcCommand, "@Phone", DbType.String, objLogItems.Telephone);
			database.AddInParameter(storedProcCommand, "@Fax", DbType.String, objLogItems.Fax);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, objLogItems.Email);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, objLogItems.Password);
			database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int64, objLogItems.IsSubscribeuser);
			database.AddInParameter(storedProcCommand, "@DesignatedApproverEmail", DbType.String, objLogItems.ApproverEmail);
			database.AddInParameter(storedProcCommand, "@ApprovalType", DbType.String, objLogItems.ApprovalType);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
			database.AddInParameter(storedProcCommand, "@IsActive", DbType.Boolean, IsActive);
			database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
			database.AddInParameter(storedProcCommand, "@IsNewDept", DbType.Boolean, IsNewDept);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable StoreUser_select(long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_StoreUser_select");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable StoreUser_select_by_Conditions(long ContactID, string Type, long DeptID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[Ws_StoreUser_select_By_Condition]");
			database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
			database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataSet Update_Address_Detail(long AddressID, string AddressLine2, string AddressLabel, string Fax, string Telephone, string Country, string State, string City, string Address, string ZipCode, long StoreUserID, long Approved_Or_Rejected_By, bool IsDefaultShipping, bool IsDefaultBillingAddress, long ClientID, string DesignatedApproverEmail)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Update_Address_Detail");
			database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
			database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
			database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
			database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
			database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
			database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
			database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
			database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
			database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
			database.AddInParameter(storedProcCommand, "@ZipCode", DbType.String, ZipCode);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@IsActive", DbType.Int32, 1);
			database.AddInParameter(storedProcCommand, "@Approved_Or_Rejected_By", DbType.Int64, Approved_Or_Rejected_By);
			database.AddInParameter(storedProcCommand, "@IsApprovedProfile", DbType.Int32, 1);
			database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Boolean, IsDefaultShipping);
			database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Boolean, IsDefaultBillingAddress);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
			database.AddInParameter(storedProcCommand, "@DesignatedApproverEmail", DbType.String, DesignatedApproverEmail);
			database.ExecuteNonQuery(storedProcCommand);
			return dataSet;
		}

		public DataSet Update_Login_Detail(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long Approved_Or_Rejected_By, string DesignatedApproverEmail)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Update_Login_Detail");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
			database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
			database.AddInParameter(storedProcCommand, "@IsActive", DbType.Int32, 1);
			database.AddInParameter(storedProcCommand, "@Approved_Or_Rejected_By", DbType.Int64, Approved_Or_Rejected_By);
			database.AddInParameter(storedProcCommand, "@DesignatedApproverEmail", DbType.String, DesignatedApproverEmail);
			database.ExecuteNonQuery(storedProcCommand);
			return dataSet;
		}

		public DataTable UserRegistrationDetails_Rejection(long RegisterPendingUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_UserRegistrationDetails_Rejection");
			database.AddInParameter(storedProcCommand, "@RegisterPendingUserID", DbType.Int64, RegisterPendingUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public string UserTypeCheck(long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_UserTypeCheck");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual long Ws_UploadCSVFile(string FileName, int ProductID, int TemplateID, int Uploadedby, int AccountID, int IsImport, string ErrorMsg, int IsEmailSend, string OriginalCSvFileName, int CompanyID, string ZipImageFileName)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_B2B_UploadCSV_FileInsert");
			database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int32, ProductID);
			database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
			database.AddInParameter(storedProcCommand, "@Uploadedby", DbType.Int32, Uploadedby);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			database.AddInParameter(storedProcCommand, "@IsImport", DbType.Int32, IsImport);
			database.AddInParameter(storedProcCommand, "@ErrorMsg", DbType.String, ErrorMsg);
			database.AddInParameter(storedProcCommand, "@IsEmailSend", DbType.Int32, IsEmailSend);
			database.AddInParameter(storedProcCommand, "@OriginalCSvFileName", DbType.String, OriginalCSvFileName);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int16, CompanyID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ZippedImageFileName", DbType.String, ZipImageFileName);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}
	}
}