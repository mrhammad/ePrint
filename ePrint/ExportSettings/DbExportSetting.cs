using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

namespace ExportSettings
{
	public class DbExportSetting
	{
		public DbExportSetting()
		{
		}

		public void contact_xeroerror_update(int CompanyID, long ContactID, bool XeroErrorCode, string XeroErrorDesc)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_contact_xeroerror_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
			database.AddInParameter(storedProcCommand, "@XeroErrorCode", DbType.Boolean, XeroErrorCode);
			database.AddInParameter(storedProcCommand, "@XeroErrorDesc", DbType.String, XeroErrorDesc);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void invoice_xeroerror_update(int CompanyID, long EstimateID, bool XeroErrorCode, string XeroErrorDesc)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_xeroerror_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@XeroErrorCode", DbType.Boolean, XeroErrorCode);
			database.AddInParameter(storedProcCommand, "@XeroErrorDesc", DbType.String, XeroErrorDesc);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void PC_accountingExportSetting_accountingMethod_insertion(int companyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accountingExportSetting_accountingMethod_Bind");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyID);
			DataSet dataSet = database.ExecuteDataSet(storedProcCommand);
			try
			{
				DataRow item = dataSet.Tables[0].Rows[0];
			}
			catch
			{
				storedProcCommand = database.GetStoredProcCommand("PC_accountingExportSetting_accountingMethod_insertion");
				database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyID);
				database.ExecuteNonQuery(storedProcCommand);
			}
		}

		public DataSet PC_PaymentExportSetting_PaymentMethod_Bind(int companyID)
		{
			DataSet dataSet;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_accountingExportSetting_accountingMethod_Bind");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyID);
			DataSet dataSet1 = database.ExecuteDataSet(storedProcCommand);
			try
			{
				DataRow item = dataSet1.Tables[0].Rows[0];
				dataSet = dataSet1;
			}
			catch
			{
				dataSet = database.ExecuteDataSet(database.GetStoredProcCommand("PC_accountingExportSetting_accountingMethod_Bind_zerolevel"));
			}
			return dataSet;
		}

		public DataSet PC_PaymentExportSetting_PaymentModule_Bind()
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			return database.ExecuteDataSet(database.GetStoredProcCommand("PC_AccountExportSetting_AccountType_Bind"));
		}

		public void purchase_xeroerror_update(int CompanyID, long PurchaseID, bool XeroErrorCode, string XeroErrorDesc)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_xeroerror_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@XeroErrorCode", DbType.Boolean, XeroErrorCode);
			database.AddInParameter(storedProcCommand, "@XeroErrorDesc", DbType.String, XeroErrorDesc);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void Setting_Export_ResetOldData(int CompanyID, string ExportViewName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			object[] exportViewName = new object[] { "update ", ExportViewName, " set ISExported=0 where CompanyID=", CompanyID };
			DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat(exportViewName));
			database.ExecuteNonQuery(sqlStringCommand);
		}

		public DataTable setting_getpaymentmoduleforexport(int paymentmethodid, string modulename)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_getpaymentmodule_ColumnName_ColumnAliasforexport");
			database.AddInParameter(storedProcCommand, "@paymentmethodid", DbType.Int32, paymentmethodid);
			database.AddInParameter(storedProcCommand, "@modulename", DbType.String, modulename);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable settings_Accounting_export_contact(int CompanyID, int IsExported, string CompanyType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Accounting_export_Contact_Type_myob");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@IsExported", DbType.Int32, IsExported);
			database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable settings_Accounting_export_Contact_Type_Xero(int CompanyID, int IsSenttoxero)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Accounting_export_contact_Type_Xero");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@IsSenttoxero", DbType.Int32, IsSenttoxero);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable settings_Accounting_export_invoice(int CompanyID, string ExportSettingType, int IsExported)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Accounting_export_Invoice_Type_myob");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@IsExported", DbType.Int32, IsExported);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable settings_Accounting_export_Purchase(int CompanyID, string ExportSettingType, int IsExported)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Accounting_export_Purchase_Type_myob");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@IsExported", DbType.Int32, IsExported);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable settings_Accounting_export_Purchase_Type_Xero(int CompanyID, string ExportSettingType, int IsExported)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Accounting_export_Purchase_Type_Xero");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, ExportSettingType);
			database.AddInParameter(storedProcCommand, "@IsExported", DbType.Int32, IsExported);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public int settings_exportsetting_check(int CompanyID, int ExportType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_exportsetting_check");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ExportType", DbType.Int32, ExportType);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public DataTable settings_PaymentExportSetting_AccountingColumn_Value_select(int ddl1value, string ddl2value, string ddl1item)
		{
			DataTable dataTable;
			DataTable dataTable1 = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_exportsetting_AccountingColumns_select");
			database.AddInParameter(storedProcCommand, "@AccountingID", DbType.Int32, ddl1value);
			database.AddInParameter(storedProcCommand, "@AccountingTypeID", DbType.String, ddl2value);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable1.Load(dataReader);
			}
			try
			{
				DataRow item = dataTable1.Rows[0];
				dataTable = dataTable1;
			}
			catch
			{
				DataTable dataTable2 = new DataTable();
				DataTable dataTable3 = new DataTable();
				storedProcCommand = database.GetStoredProcCommand("PC_settings_exportsetting_AccountingMethod_AccountingMethodID_select_zero");
				database.AddInParameter(storedProcCommand, "@AccountingType", DbType.String, ddl1item);
				using (IDataReader dataReader1 = database.ExecuteReader(storedProcCommand))
				{
					dataTable3.Load(dataReader1);
				}
				DataRow dataRow = dataTable3.Rows[0];
				int num = Convert.ToInt32(dataRow[0]);
				storedProcCommand = database.GetStoredProcCommand("PC_settings_exportsetting_AccountingColumns_select");
				database.AddInParameter(storedProcCommand, "@AccountingID", DbType.Int32, num);
				database.AddInParameter(storedProcCommand, "@AccountingTypeID", DbType.String, ddl2value);
				using (IDataReader dataReader2 = database.ExecuteReader(storedProcCommand))
				{
					dataTable2.Load(dataReader2);
				}
				dataTable = dataTable2;
			}
			return dataTable;
		}

		public DataTable settings_PaymentExportSetting_PaymentMethod_FieldValue_select(int ddlvalue)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_exportsetting_Allfields_value_select");
			database.AddInParameter(storedProcCommand, "@PaymentMethodId", DbType.Int32, ddlvalue);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
	}
}