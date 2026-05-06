using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.BusinessAccessLayer.Accounts;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Accounts
{
	public class DbAccounts : DataAccess
	{
		public DbAccounts()
		{
		}

		public virtual int account_insert(AccountsItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_create");
			database.AddInParameter(storedProcCommand, "@clientID", DbType.String, item.clientID);
			database.AddInParameter(storedProcCommand, "@clientName", DbType.String, item.clientName);
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, item.accountName);
			database.AddInParameter(storedProcCommand, "@accountPrefix", DbType.String, item.accountPrefix);
			database.AddInParameter(storedProcCommand, "@createdOn", DbType.String, item.createdOn);
			database.AddInParameter(storedProcCommand, "@createdBy", DbType.Int32, item.createdBy);
			database.AddInParameter(storedProcCommand, "@defaultContactID", DbType.Int32, item.defaultContactID);
			database.AddInParameter(storedProcCommand, "@defaultAddressID", DbType.Int32, item.defaultAddressID);
			database.AddInParameter(storedProcCommand, "@accountType", DbType.String, item.accountType);
			database.AddInParameter(storedProcCommand, "@addressType", DbType.String, item.addressType);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.String, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@StoreURL", DbType.String, item.StoreURL);
			database.AddInParameter(storedProcCommand, "@FileExtension", DbType.String, item.FileExtension);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual void account_modify(AccountsItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_modify");
			database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, item.clientID);
			database.AddInParameter(storedProcCommand, "@clientName", DbType.String, item.clientName);
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, item.accountName);
			database.AddInParameter(storedProcCommand, "@accountPrefix", DbType.String, item.accountPrefix);
			database.AddInParameter(storedProcCommand, "@createdOn", DbType.String, item.createdOn);
			database.AddInParameter(storedProcCommand, "@createdBy", DbType.Int32, item.createdBy);
			database.AddInParameter(storedProcCommand, "@defaultContactID", DbType.Int32, item.defaultContactID);
			database.AddInParameter(storedProcCommand, "@defaultAddressID", DbType.Int32, item.defaultAddressID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, item.accountID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void account_modifyPublic(AccountsItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_modifyPublic");
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, item.accountName);
			database.AddInParameter(storedProcCommand, "@accountPrefix", DbType.String, item.accountPrefix);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, item.accountID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable accounts_accountName(string accountName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_accountName");
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, accountName);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_clientAddress(int CompanyID, string companytype, int clientID, char addressType, int def_addressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_view_tbclient");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.String, CompanyID);
			database.AddInParameter(storedProcCommand, "@companytype", DbType.String, companytype);
			database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, clientID);
			database.AddInParameter(storedProcCommand, "@addressType", DbType.String, addressType);
			database.AddInParameter(storedProcCommand, "@def_addressID", DbType.Int32, def_addressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_clientID(string accountName, int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getClientID");
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, accountName);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.String, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_contactName(int contactID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getcontactName");
			database.AddInParameter(storedProcCommand, "@contactID", DbType.Int32, contactID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_delete(int CompanyID, int AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getAccountDetails(int accountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getAccountDetails");
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getAccountID(string accountName, string accountPrefix, int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getAccountID");
			database.AddInParameter(storedProcCommand, "@accountName", DbType.String, accountName);
			database.AddInParameter(storedProcCommand, "@accountPrefix", DbType.String, accountPrefix);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.String, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getcontactDetails(int CompanyID, int clientID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getcontactDetails");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.String, CompanyID);
			database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, clientID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getDetails(int clientID, int CompanyID, int accountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_editView");
			database.AddInParameter(storedProcCommand, "@clientID", DbType.Int32, clientID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getDetails1(int accountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_editView1");
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accounts_getUserDetails(int createdBy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accounts_getUserDetails");
			database.AddInParameter(storedProcCommand, "@userID", DbType.Int32, createdBy);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable accountsList(int CompanyID)
		{
			BaseClass baseClass = new BaseClass();
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accountsList");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable AccountsListforApprovalSystem(int CompanyID)
		{
			BaseClass baseClass = new BaseClass();
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AccountsList_forApprovalSystem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void productCategoryReorder_Delete(int accountID, int companyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_productCategoryReorder_Delete");
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void ProductCategoryReorder_Insert_Update(int sortorderID, int accountID, int ClientID, int productcategoryID, int sortedorderNo, int companyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCategoryReorder_Insert_Update");
			database.AddInParameter(storedProcCommand, "@sortorderID", DbType.Int32, sortorderID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@productcategoryID", DbType.Int32, productcategoryID);
			database.AddInParameter(storedProcCommand, "@sortedorderNo", DbType.Int32, sortedorderNo);
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable productsCategoryList_Select(int CompanyID, int AccountID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_productsCategoryList_Select ");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productsCategoryList_Select_CategoryID(int CompanyID, int AccountID, int CategoryID, bool IsAllselected)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_productsCategoryList_Select_CategoryID ");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
			database.AddInParameter(storedProcCommand, "@IsAllselected", DbType.Boolean, IsAllselected);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void publicAccount_bind(char accountType, int CompanyID, DropDownList ddlAccountPublic)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_publicAccount_bind");
			database.AddInParameter(storedProcCommand, "@accountType", DbType.String, accountType);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			IDataReader dataReader = database.ExecuteReader(storedProcCommand);
			ddlAccountPublic.DataSource = dataReader;
			ddlAccountPublic.DataTextField = "accountname";
			ddlAccountPublic.DataValueField = "accountID";
			ddlAccountPublic.DataBind();
			storedProcCommand.Dispose();
			dataReader.Dispose();
		}

		public virtual DataTable publicAccount_bind(int CompanyID)
		{
			BaseClass baseClass = new BaseClass();
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_publicAccount_Names");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PublicAccountsListforApprovalSystem(int CompanyID)
		{
			BaseClass baseClass = new BaseClass();
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accountsList_Forpublic");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
	}
}