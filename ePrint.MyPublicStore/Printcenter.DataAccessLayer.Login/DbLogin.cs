using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
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

		public virtual long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
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
			database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int32, subscribe_newsletter);

			

			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Create_StoreUser_AgentCode(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUserDefaultForAgent");
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
			database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int32, subscribe_newsletter);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public string Fetch_LanguageConversionFileName(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Fetch_LanguageConversion_FileName");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			object obj = database.ExecuteScalar(storedProcCommand);
			return (obj == null ? "" : obj.ToString());
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

		public virtual DataTable Public_User_ClientIDbyAgentCode(long CompanyID, long AccountID, string AgentCode)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_GetClientIDbyAgentCode");
			database.AddInParameter(storedProcCommand, "@AgentCode", DbType.String, AgentCode);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Public_User_SecretCodebyAccountID(long CompanyID, long AccountID, string SecretCode)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_GetSecretCodebyAccountID");
			database.AddInParameter(storedProcCommand, "@SecretCode", DbType.String, SecretCode);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
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

		public virtual DataTable Select_PublicUserAccountDetails(long CompanyID, long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PublicSettings_Select");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
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
	}
}