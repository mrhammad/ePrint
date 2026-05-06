using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.CMS
{
	public class DBCMS
	{
		public DBCMS()
		{
		}

		public virtual DataTable CMSPages_get(int companyID, int accountID, int pageID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_CMSPages_get");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable GetDetailForHome(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_select_AccountHome");
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable GetDisplaySettings(long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_eStoreDisplay");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        internal DataTable Get_CurrencySymbol_Currency_Company(int companyID)
        {
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GetCurrency_CurrencySymbol_Company");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public DataTable getGuestDetail(long UserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_GuestDetail");
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable headerSelect(int companyID, int accountID, string type)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_headerSelect");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable homePageSelect(long PageID, int CompanyID, int AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_homePageSelect");
			database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, PageID);
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable paymentSelect(int CompanyID, int AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_paymentSelect");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_BannerImages(long AccountID, int PageID, string Location, string Page)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_BannerImages");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@PageID", DbType.Int32, PageID);
			database.AddInParameter(storedProcCommand, "@Location", DbType.String, Location);
			database.AddInParameter(storedProcCommand, "@Page", DbType.String, Page);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_TermsAndConditions(int CompanyID, int AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_select_TermsAndConditions");
			database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
	}
}