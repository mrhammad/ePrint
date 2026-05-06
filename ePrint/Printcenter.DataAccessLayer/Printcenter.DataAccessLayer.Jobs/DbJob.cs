using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;

namespace Printcenter.DataAccessLayer.Jobs
{
	public class DbJob : DataAccess
	{
		public DbJob()
		{
		}

		public virtual DataSet AllModuleDetails_Select(int CompanyID, long PoDnID, string page)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_AllModuleDetails_Select", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@PurchaseOrDeliveryID", PoDnID);
			sqlCommand.Parameters.AddWithValue("@ModuleType", page);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual long copy_job(int CompanyID, long JobID, long New_EstimateID, bool IsHandy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_job");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, New_EstimateID);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddOutParameter(storedProcCommand, "@New_JobID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@New_JobID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual void copy_jobcard(int CompanyID, long Old_EstimateItemID, long New_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_job_card");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddInParameter(storedProcCommand, "@New_EstimateItemID", DbType.Int64, New_EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Estimate_Revert_Status_Update(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Revert_status_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long EstimateID_Select_By_JobID(int CompanyID, long JobID)
		{
			long num;
			string empty = string.Empty;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateID_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			try
			{
				num = (long)database.ExecuteScalar(storedProcCommand);
			}
			catch
			{
				num = (long)0;
			}
			return num;
		}

		public virtual string EstimateItem_JobItemNumber_Select(long JobID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItem_JobItemNumber_Select");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable EstimateItems_PendingForInvoice_Select(string JobIDs)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItems_PendingForInvoice_Select");
			database.AddInParameter(storedProcCommand, "@JobIDs", DbType.String, JobIDs);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void EstimateItems_ProgressToJob(long EstimateItemID, long JobID, bool IsArchive_Job, DateTime CreatedDate)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			Database database = CustomDatabaseFactory.CreateDatabase(str);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItems_ProgressToJob");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@IsArchive_Job", DbType.Boolean, IsArchive_Job);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable GetAccountID(int CompanyID, long EstimateID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			Database database = CustomDatabaseFactory.CreateDatabase(str);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetAccountID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable job_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_advance_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
			database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
			database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
			database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
			database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
			database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
			database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
			database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
			database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable job_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_advance_search_SplitItems");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
			database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
			database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
			database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
			database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
			database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
			database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
			database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
			database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable job_advance_search_top5(int CompanyID, int ClientID, string Status, string DateType, bool IsArchived)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_advance_search_top5");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
			database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
			database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Job_Archive(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Job_Booklet_Quantity_Details_Select(int CompanyID, long EstimateItemID, short QtyNumber)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_booklet_quantity_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Card_Full_Info_Select_By_JobID(long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Card_Info_Select_By_JobID_New_RaisePO");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable Job_Card_Full_Info_Select_By_JobID_Create_Bulk(long JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Card_Info_Select_By_JobID_New_RaisePO_CREATEBULK");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Job_Card_Info_Select_By_JobID(long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Card_Info_Select_By_JobID");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable job_card_othercost_sub_items(int CompanyID, long TypeID, string EstimateType, long QuantityID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_othercost_sub_items");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, QuantityID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void job_card_price_catalogue_update(int CompanyID, long EstimateItemID, string ReqPriceCatalogue)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_price_catalogue_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ReqPriceCatalogue", DbType.String, ReqPriceCatalogue);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void job_card_required_update(int CompanyID, long EstimateItemID, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_required_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ReqPrePress", DbType.String, ReqPrePress);
			database.AddInParameter(storedProcCommand, "@ReqPress", DbType.String, ReqPress);
			database.AddInParameter(storedProcCommand, "@ReqPostPress", DbType.String, ReqPostPress);
			database.AddInParameter(storedProcCommand, "@ReqPriceCatalogue", DbType.String, ReqPriceCatalogue);
			database.AddInParameter(storedProcCommand, "@ReqOutwork", DbType.String, ReqOutwork);
			database.AddInParameter(storedProcCommand, "@ReqWarehouse", DbType.String, ReqWarehouse);
			database.AddInParameter(storedProcCommand, "@ReqAdmin", DbType.String, ReqAdmin);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long job_check_estimate(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_check_estimate");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			object obj = database.ExecuteScalar(storedProcCommand);
			return (obj == null ? (long)0 : Convert.ToInt64(obj));
		}

		public virtual short Job_Item_QuantityNumber_Select(int CompanyID, long EstimateItemID)
		{
			short num;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_quantity_number_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			try
			{
				num = (short)database.ExecuteScalar(storedProcCommand);
			}
			catch
			{
				num = 1;
			}
			return num;
		}

		public virtual DataTable Job_Items_Quantity_Details_Select(int CompanyID, long ItemID, string ItemType, short QtyNumber)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_quantity_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string Job_Job_Number_Select(int CompanyID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_number_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Job_Jobcard_Insert_NewItem(int CompanyID, long EstimateItemID, short QtyNumber, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_insert_newitem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Job_Jobcard_Insert_NewItem_JOBTIME(int CompanyID, long EstimateItemID, short QtyNumber, long EstimateID, decimal JobTime)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_insert_newitem_JOBTIME");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@JobTime", DbType.Decimal, JobTime);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet Job_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Job_PageText", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
			sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void Job_Progress_Status_Insert(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Progress_Status_Insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet Job_ProgressToInv_Contacts_Select(string EstimateItemIDs)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_ProgressToInv_Contacts_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.String, EstimateItemIDs);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataSet Job_ProgToInvoice_allContacts_Select(string EstimateItemIDs)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_ProgToInvoice_allContacts_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.String, EstimateItemIDs);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable Job_QtyIDQty_Select(int CompanyID, short QtyNo, long ItemID, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_qtyIdQty_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.AddInParameter(storedProcCommand, "@QtyNo", DbType.Int64, QtyNo);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Quantity_Numbert_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_quantity_number_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Quantity_Select_By_ID(int CompanyID, string EstimateType, long ItemID, short QtyNo)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_quantity_select_by_id");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.AddInParameter(storedProcCommand, "@QtyNo", DbType.Int16, QtyNo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Select_By_EstimateID(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_select_PerItem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Select_By_JobID(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_select_SplitItem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string Get_JobID_By_EstimateID(long estimateID, int CompanyID)
		{
			string JOBID = string.Empty;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			string query = "SELECT TOP 1 JobID FROM tb_job WHERE EstimateID = @EstimateID and CompanyID = @CompanyID";
			DbCommand command = database.GetSqlStringCommand(query);
			database.AddInParameter(command, "@EstimateID", DbType.Int64, estimateID);
			database.AddInParameter(command, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader reader = database.ExecuteReader(command))
			{
				if (reader.Read())
				{
					JOBID = reader["JobID"].ToString();
				}
			}
			return JOBID;
		}


		public virtual void Job_Status_Update(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_status_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Job_Summary_Item_Cost_View_Qtys_And_Cal(int CompanyID, long EstimateItemID, long TypeID, string EstType, long EstBookletSectionID, string SpType, short QtyNo)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_summary_item_cost_qty_and_cal");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstType", DbType.String, EstType);
			database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
			database.AddInParameter(storedProcCommand, "@SpType", DbType.String, SpType);
			database.AddInParameter(storedProcCommand, "@QtyNo", DbType.Int16, QtyNo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Summary_Item_Cost_View_Qtys_And_Cal_Book(int CompanyID, long EstBookletSectionID, string SpType, short QtyNo)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_summary_item_cost_qty_and_cal_for_book");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
			database.AddInParameter(storedProcCommand, "@SpType", DbType.String, SpType);
			database.AddInParameter(storedProcCommand, "@QtyNo", DbType.String, QtyNo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Job_Summary_Outwork_Select_By_EstimateItemID(int CompanyID, long EstimateItemID, short QtyNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_summary_outwork_select_by_estimateitemid");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Job_UnArchive(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_unarchive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void job_update(int CompanyID, long EstimateID, string Header, string Footer, int StatusID, DateTime Jobdate, DateTime CompletionDate, DateTime DeliveryDate, DateTime ProofDate, DateTime ProducDate, long JobID, DateTime ArtworkDate,DateTime ApprovalDate, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (this.Session["UserID"] != null)
			{
				num = Convert.ToInt32(this.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
			database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@JobDate", DbType.DateTime, Jobdate);
			database.AddInParameter(storedProcCommand, "@CompletionDate", DbType.DateTime, CompletionDate);
			database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
			database.AddInParameter(storedProcCommand, "@ProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@ProducDate", DbType.DateTime, ProducDate);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
            database.AddInParameter(storedProcCommand, "@ArtworkDate", DbType.DateTime, ArtworkDate);
            database.AddInParameter(storedProcCommand, "@ApprovalDate", DbType.DateTime, ApprovalDate);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int jobcard_existcheck(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_existcheck");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual void jobcard_item_description_update(int CompanyID, long EstimateItemID, string ItemDescription)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("jobcard_item_description_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable jobcard_jobItemdetails_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_jobItemdetails_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable JobItem_EstimateItemID_Select(long JobID, string Type)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateIDsForStatus_Update");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int JobItemNotConvertedToInvoice_Select(long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobItemNotConvertedToInvoice_Select");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Jobs_Delete(int CompanyID, long JobID, bool Keep_EstimateJOB_LIVE)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (this.Session["UserID"] != null)
			{
				num = Convert.ToInt32(this.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
			database.AddInParameter(storedProcCommand, "@KeepEstimateJobLive", DbType.Boolean, Keep_EstimateJOB_LIVE);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Jobs_EmailAutoJobStatus(int StatusID, string autojob, string type, long EstimateID, int companyID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			Database database = CustomDatabaseFactory.CreateDatabase(str);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Jobs_EmailAutoJobStatus");
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, autojob);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
		public virtual DataTable Jobs_EmailAutoJobStatus_Item(int StatusID, string autojob, string type, long EstimateID, int companyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Jobs_EmailAlert_AutoJobStatus");
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, StatusID);
			database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, autojob);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			database.AddInParameter(storedProcCommand, "@EstimateitemidID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_EmailStatus_select(int CompanyID, int StatusID, long CheckMailSentJobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Jobs_EmailStatus_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@CheckMailSentJobID", DbType.Int64, CheckMailSentJobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string Jobs_EstimateType_select(int CompanyID, int EstimateItemID)
		{
			string empty = string.Empty;
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_estimatetype_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable Jobs_GuillotineDetails_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_guillotine_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long jobs_insert(int CompanyID, long EstID, string JobNumber, DateTime ConvertedDate, DateTime JobDate, DateTime CompletionDate, DateTime DeliveryDate, int ConvertedBy, string OrderNumber, DateTime ArtworkDate, DateTime ApprovalDate, DateTime ProofDate, DateTime ProductionDate, bool IsConverted, int StatusID, bool IsHandy, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstID", DbType.Int64, EstID);
			database.AddInParameter(storedProcCommand, "@JobNumber", DbType.String, JobNumber);
			database.AddInParameter(storedProcCommand, "@ConvertedDate", DbType.DateTime, ConvertedDate);
			database.AddInParameter(storedProcCommand, "@JobDate", DbType.DateTime, JobDate);
			database.AddInParameter(storedProcCommand, "@CompletionDate", DbType.DateTime, CompletionDate);
			database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
			database.AddInParameter(storedProcCommand, "@ConvertedBy", DbType.Int32, ConvertedBy);
			database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
			database.AddInParameter(storedProcCommand, "@ArtworkDate", DbType.DateTime, ArtworkDate);
			database.AddInParameter(storedProcCommand, "@ApprovalDate", DbType.DateTime, ApprovalDate);
			database.AddInParameter(storedProcCommand, "@ProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@ProductionDate", DbType.DateTime, ProductionDate);
			database.AddInParameter(storedProcCommand, "@IsConverted", DbType.Boolean, IsConverted);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddInParameter(storedProcCommand, "@JobPrefix", DbType.String, ConnectionClass.JobPrefix);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            return (long)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable Jobs_ItemTitle_select(int CompanyID, string Query)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_itemtitle_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Query", DbType.String, Query);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual IDataReader Jobs_Job_Details_select(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
			return database.ExecuteReader(storedProcCommand);
		}

		public virtual DataTable Jobs_Jobcard_details_select(int CompanyID, int EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void jobs_jobcard_insert(int CompanyID, int EstimateItemID, short QtyNumber, DateTime CompletionDate, DateTime DeliveryDate, DateTime ArtworkDate, DateTime ApprovalDate, DateTime ProofDate, DateTime ProductionDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			database.AddInParameter(storedProcCommand, "@CompletionDate", DbType.DateTime, CompletionDate);
			database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
			database.AddInParameter(storedProcCommand, "@ArtworkDate", DbType.DateTime, ArtworkDate);
			database.AddInParameter(storedProcCommand, "@ApprovalDate", DbType.DateTime, ApprovalDate);
			database.AddInParameter(storedProcCommand, "@ProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@ProductionDate", DbType.DateTime, ProductionDate);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Jobs_Jobcard_ItemQuantity_select(int CompanyID, long ItemID, short QtyNumber, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_item_quantity_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_Jobcard_Jobdetails_select(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_jobdetails_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Jobs_Jobcard_Update(int CompanyID, int EstimateItemID, DateTime ReqArtworkDate, DateTime ActArtworkdate, DateTime ReqApprovalDate, DateTime ActApprovalDate, DateTime ReqProofDate, DateTime ActProofDate, DateTime ReqProductionDate, DateTime ActProductionDate, DateTime ReqDeliveryDate, DateTime ActDeliveryDate, string ReqPrePress, string ActPrePress, string ReqPress, string ActPress, string ReqPostPress, string ActPostPress, string ReqWarehouse, string ActWarehouse, string ReqOutwork, string ActOutwork, string ReqPriceCatalogue, string ActPriceCatalogue, string ReqAdmin, string ActAdmin, string ReqPaper, string ReqInk, string ReqPlates, string ReqGuillotine, string ReqWashUp, string ReqMakeReady, string ActPaper, string ActInk, string ActPlates, string ActGuillotine, string ActWashUp, string ActMakeReady, decimal ActualJobTime)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ReqArtworkDate", DbType.DateTime, ReqArtworkDate);
			database.AddInParameter(storedProcCommand, "@ActArtworkdate", DbType.DateTime, ActArtworkdate);
			database.AddInParameter(storedProcCommand, "@ReqApprovalDate", DbType.DateTime, ReqApprovalDate);
			database.AddInParameter(storedProcCommand, "@ActApprovalDate", DbType.DateTime, ActApprovalDate);
			database.AddInParameter(storedProcCommand, "@ReqProofDate", DbType.DateTime, ReqProofDate);
			database.AddInParameter(storedProcCommand, "@ActProofDate", DbType.DateTime, ActProofDate);
			database.AddInParameter(storedProcCommand, "@ReqProductionDate", DbType.DateTime, ReqProductionDate);
			database.AddInParameter(storedProcCommand, "@ActProductionDate", DbType.DateTime, ActProductionDate);
			database.AddInParameter(storedProcCommand, "@ReqDeliveryDate", DbType.DateTime, ReqDeliveryDate);
			database.AddInParameter(storedProcCommand, "@ActDeliveryDate", DbType.DateTime, ActDeliveryDate);
			database.AddInParameter(storedProcCommand, "@ReqPrePress", DbType.String, (ReqPrePress.Trim() == "<1linebreak>" ? "" : ReqPrePress));
			database.AddInParameter(storedProcCommand, "@ActPrePress", DbType.String, ActPrePress);
			database.AddInParameter(storedProcCommand, "@ReqPress", DbType.String, (ReqPress.Trim()=="<1linebreak>"? "" : ReqPress));
			database.AddInParameter(storedProcCommand, "@ActPress", DbType.String, ActPress);
			database.AddInParameter(storedProcCommand, "@ReqPostPress", DbType.String, (ReqPostPress.Trim() == "<1linebreak>" ? "" : ReqPostPress));
			database.AddInParameter(storedProcCommand, "@ActPostPress", DbType.String, ActPostPress);
			database.AddInParameter(storedProcCommand, "@ReqWarehouse", DbType.String, (ReqWarehouse.Trim() == "<1linebreak>" ? "" : ReqWarehouse));
			database.AddInParameter(storedProcCommand, "@ActWarehouse", DbType.String, ActWarehouse);
			database.AddInParameter(storedProcCommand, "@ReqOutwork", DbType.String, (ReqOutwork.Trim() == "<1linebreak>" ? "" : ReqOutwork));
			database.AddInParameter(storedProcCommand, "@ActOutwork", DbType.String, ActOutwork);
			database.AddInParameter(storedProcCommand, "@ReqPriceCatalogue", DbType.String, (ReqPriceCatalogue.Trim() == "<1linebreak>" ? "" : ReqPriceCatalogue));
			database.AddInParameter(storedProcCommand, "@ActPriceCatalogue", DbType.String, ActPriceCatalogue);
			database.AddInParameter(storedProcCommand, "@ReqAdmin", DbType.String, (ReqAdmin.Trim() == "<1linebreak>" ? "" : ReqAdmin));
			database.AddInParameter(storedProcCommand, "@ActAdmin", DbType.String, ActAdmin);
			database.AddInParameter(storedProcCommand, "@ReqPaper", DbType.String, (ReqPaper.Trim() == "<1linebreak>" ? "" : ReqPaper));
			database.AddInParameter(storedProcCommand, "@ReqInk", DbType.String, (ReqInk.Trim() == "<1linebreak>" ? "" : ReqInk));
			database.AddInParameter(storedProcCommand, "@ReqPlates", DbType.String, (ReqPlates.Trim() == "<1linebreak>" ? "" : ReqPlates));
			database.AddInParameter(storedProcCommand, "@ReqGuillotine", DbType.String, (ReqGuillotine.Trim() == "<1linebreak>" ? "" : ReqGuillotine));
			database.AddInParameter(storedProcCommand, "@ReqWashUp", DbType.String, (ReqWashUp.Trim() == "<1linebreak>" ? "" : ReqWashUp));
			database.AddInParameter(storedProcCommand, "@ReqMakeReady", DbType.String, (ReqMakeReady.Trim() == "<1linebreak>" ? "" : ReqMakeReady));
			database.AddInParameter(storedProcCommand, "@ActPaper", DbType.String, ActPaper);
			database.AddInParameter(storedProcCommand, "@ActInk", DbType.String, ActInk);
			database.AddInParameter(storedProcCommand, "@ActPlates", DbType.String, ActPlates);
			database.AddInParameter(storedProcCommand, "@ActGuillotine", DbType.String, ActGuillotine);
			database.AddInParameter(storedProcCommand, "@ActWashUp", DbType.String, ActWashUp);
			database.AddInParameter(storedProcCommand, "@ActMakeReady", DbType.String, ActMakeReady);
			database.AddInParameter(storedProcCommand, "@ActualJobTime", DbType.Decimal, ActualJobTime);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Jobs_OtherCostItemDetails_Select(int CompanyID, long OtherCostID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_othercost_item_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OtherCostItemName_Slect(int CompanyID, long OtherCostID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_othercost_item_name_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OtherCostItems_Slect(int CompanyID, long TypeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_othercost_items_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OtherCostMainItems_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_othercost_main_items_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OutworkItemDescription_Select(int CompanyID, long EstItemOutworkID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_outwork_item_description_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstItemOutworkID", DbType.Int64, EstItemOutworkID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OutworkItems_Select(int CompanyID, long TypeID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_outwork_itemsID_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_OutworkMainItem_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_outwork_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_PressDetails_select(int CompanyID, string Query)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_press_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Query", DbType.String, Query);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Jobs_Revert(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_revert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Jobs_Select_All(int CompanyID, string Para)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_select_all");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Para", DbType.String, Para);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_WarehouseItemName_Slect(int CompanyID, long WarehouseTypeID, string WarehouseType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_warehouse_item_name_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@WarehouseTypeID", DbType.Int64, WarehouseTypeID);
			database.AddInParameter(storedProcCommand, "@WarehouseType", DbType.String, WarehouseType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_WarehouseItems_Slect(int CompanyID, long TypeID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_warehouse_items_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_WarehouseMainItemDetails_Slect(int CompanyID, long EstBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_warehouse_main_item_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstBookletItemID", DbType.Int32, EstBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_WarehouseMainItems_Slect(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_warehouse_main_items_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Jobs_WarehouseRFQ_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobs_warehouse_RFQ_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet PCR_JOBCard_GetAllItems(long CurrentEstimateItemID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PCR_JOBCard_GetAllItems", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CurrentEstimateItemID", CurrentEstimateItemID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet PCR_JOBCard_Values_To_Replace(long EstimateItemID, string EstimateType, long ParentItemID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PCR_JOBCard_Values_To_Replace", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
			sqlCommand.Parameters.AddWithValue("@EstimateType", EstimateType);
			sqlCommand.Parameters.AddWithValue("@ParentItemID", ParentItemID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void PCR_JOBCard_Values_Update_After_Replace(long EstimateItemID, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin, string ReqPaper, string ReqInk, string ReqPlates, string ReqGuillotine, string ReqWashUp, string ReqMakeReady)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand("PCR_JOBCard_Values_Update_After_Replace", sqlConnection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
			sqlCommand.Parameters.AddWithValue("@ReqPrePress", ReqPrePress);
			sqlCommand.Parameters.AddWithValue("@ReqPress", ReqPress);
			sqlCommand.Parameters.AddWithValue("@ReqPostPress", ReqPostPress);
			sqlCommand.Parameters.AddWithValue("@ReqPriceCatalogue", ReqPriceCatalogue);
			sqlCommand.Parameters.AddWithValue("@ReqOutwork", ReqOutwork);
			sqlCommand.Parameters.AddWithValue("@ReqWarehouse", ReqWarehouse);
			sqlCommand.Parameters.AddWithValue("@ReqAdmin", ReqAdmin);
			sqlCommand.Parameters.AddWithValue("@ReqPaper", ReqPaper);
			sqlCommand.Parameters.AddWithValue("@ReqInk", ReqInk);
			sqlCommand.Parameters.AddWithValue("@ReqPlates", ReqPlates);
			sqlCommand.Parameters.AddWithValue("@ReqGuillotine", ReqGuillotine);
			sqlCommand.Parameters.AddWithValue("@ReqWashUp", ReqWashUp);
			sqlCommand.Parameters.AddWithValue("@ReqMakeReady", ReqMakeReady);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public virtual DataSet PCR_Select_JobCardSettings_ForReplace(int CompanyID, string EstimateType, string MainOrSub)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PCR_Select_JobCardSettings_ForReplace", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@EstimateType", EstimateType);
			sqlCommand.Parameters.AddWithValue("@MainOrSub", MainOrSub);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet PCR_Select_JobCardTags_ForReplace(int CompanyID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PCR_Select_JobCardTags_ForReplace", sqlConnection)
			{
				CommandType = CommandType.StoredProcedure
			};
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataTable price_catalogue_select_by_estimateitem_id_qtynumber(int CompanyID, long EstimateItemID, int QtyNumber)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select_by_estimateitem_id_qtynumber_reeng");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int64, QtyNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable QuickLinks_ItemDetials_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_QuickLinks_ItemDetials_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Update_EstimateJobTime(long EstimateItemID, decimal JobTime)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_EstimateJobTime");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@JobTime", DbType.Decimal, JobTime);
			database.ExecuteNonQuery(storedProcCommand);
		}
	}
}