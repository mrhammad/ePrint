using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.DbNotes
{
	public class DbNotes
	{
		public DbNotes()
		{
		}

		public virtual void insert_Activity_History(int CompanyID, string NoteType, string ModuleName, long ModuleID, string Description, DateTime CreateDate, int CreateUserId, long ItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_insert_Activity_History");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@NoteType", DbType.String, NoteType);
			database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
			database.AddInParameter(storedProcCommand, "@CreateDate", DbType.DateTime, CreateDate);
			database.AddInParameter(storedProcCommand, "@CreateUserId", DbType.Int16, CreateUserId);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable select_EstimateType_for_Activity_History(long EstimateID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_EstimateType_for_Activity_History");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_item_number_for_Activity_History(long ModuleID, long EstimateItemID, string ModuleType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_item_number_for_Activity_History");
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_item_Title_for_Activity_History(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_Title_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
	}
}