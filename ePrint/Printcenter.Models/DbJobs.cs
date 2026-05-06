using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

public class DbJobs
{
	public DbJobs()
	{
	}

	public virtual void Delete_PODeliverynote_for_RevertJob(long CompanyID, long EstimateID, int DeletePO, int DeleteDel, string Type)
	{
		commonClass _commonClass = new commonClass();
		int num = 0;
		if (HttpContext.Current.Session["UserID"] != null)
		{
			num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		}
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Delete_PODeliverynote_for_RevertJob");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
		database.AddInParameter(storedProcCommand, "@DeletePO", DbType.Int32, DeletePO);
		database.AddInParameter(storedProcCommand, "@DeleteDel", DbType.Int32, DeleteDel);
		database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
		DateTime now = DateTime.Now;
		database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), Convert.ToInt32(CompanyID), num, true));
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual DataTable Job_DeliveryNote_AllItems_Quantity_Details_Select(int CompanyID, long EstimateItemID, string EstimateType, long ItemID, int QtyNumber)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_DeliveryNote_AllItems_Quantity_Details_Select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
		database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual void Job_DeliveryNote_DeliveryQty_Update(int CompanyID, long DeliveryID, long DeliveryItemID, long EstimateItemID, string EstimateType, long DeliveryAddressID, string DeliveryAddressType, int Quantity)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_DeliveryNote_DeliveryQty_Update");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
		database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
		database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DeliveryAddressType);
		database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual int Job_DeliveryNote_QtyProduced_Select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_DeliveryNote_QtyProduced_Select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		return (int)database.ExecuteScalar(storedProcCommand);
	}

	public virtual void Job_DeliveryNote_QtyProduced_Update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, int QtyProduced)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_DeliveryNote_QtyProduced_Update");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		database.AddInParameter(storedProcCommand, "@QtyProduced", DbType.Int32, QtyProduced);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual DataTable job_item_cost_view_sub_item_outwork(int CompanyID, long ParentEstimateItemID, long EstimateItemID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_cost_view_sub_item_outwork");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ParentEstimateItemID", DbType.Int64, ParentEstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable job_item_details_selectall(int CompanyID, long EstimateItemID, string EstimateType)
	{
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateType", EstimateType) };
		SqlParameter[] sqlParameterArray = sqlParameter;
		commonClass _commonClass = new commonClass();
		return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_job_item_details_selectall", sqlParameterArray).Tables[0];
	}

	public virtual int Job_Item_Invoiced_Count(long JobID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Item_Invoiced_Count");
		database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
		object obj = database.ExecuteScalar(storedProcCommand);
		return (obj == null ? 0 : int.Parse(obj.ToString()));
	}

	public virtual void Job_Item_Revart(long EstimateItemID, long CompanyID, long UserID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Item_Revart");
		database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, UserID);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public virtual DataTable Job_Items_Quantity_Details_Select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, short QtyNumber)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_quantity_details_select_new");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
		database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
		database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual string job_outwork_by_id(int CompanyID, long EstimateItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_outwork_by_id");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		return (string)database.ExecuteScalar(storedProcCommand);
	}

	public virtual DataTable job_qty_select_by_qtynumber(int CompanyID, long EstimateItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_qty_select_by_qtynumber");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual int job_quantity_number_select(int CompanyID, long ParentEstimateItemID, string ParentEstimateType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_job_quantity_number_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ParentEstimateItemID", DbType.Int64, ParentEstimateItemID);
		database.AddInParameter(storedProcCommand, "@ParentEstimateType", DbType.String, ParentEstimateType);
		database.ExecuteNonQuery(storedProcCommand);
		object obj = database.ExecuteScalar(storedProcCommand);
		return (obj == null ? 1 : int.Parse(obj.ToString())); //Changed by Amin from 0 to 1
	}

	public virtual DataTable job_subitem_qty_select_by_qtynumber(long CompanyID, long EstimateItemID, long ParentEstimateItemID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_subitem_qty_select_by_qtynumber");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@ParentEstimateItemID", DbType.Int64, ParentEstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataSet jobcard_for_sub_item(int CompanyID, long ParentItemID, string ParentItemType)
	{
		DataSet dataSet = new DataSet();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_for_sub_item");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
		database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
		return database.ExecuteDataSet(storedProcCommand);
	}

	public virtual DataTable jobcard_outwork(int CompanyID, long EstOutworkID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_outwork");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable jobcard_quantity_select(int CompanyID, short QtyNumber, long EstimateItemID, long EstimateBookletItemID, string EstimateType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_quantity_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
		database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable jobs_deliverynote_warehouse_details_select(int CompanyID, long EstimateItemID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_deliverynote_warehouse_details_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Jobs_ItemTitle_select(int CompanyID, string Query)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_itemtitle_select_new");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@Query", DbType.String, Query);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Jobs_Jobcard_ItemQuantity_select(int CompanyID, long ItemID, long EstimateItemID, short QtyNumber, string ItemType)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_quantity_select_new");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
		database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Jobs_Jobcard_Jobdetails_ByJobID_select(int CompanyID, long JobID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_jobdetails_ByJobID_select");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Select_All_Job_Item(long JobID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_All_Job_Item_Select");
		database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public virtual DataTable Select_jobcard_Details_forOrders(int CompanyID, long EstimateID, long EstimateItemID)
	{
		DataTable dataTable = new DataTable();
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_jobcard_Details_forOrders");
		database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}
}