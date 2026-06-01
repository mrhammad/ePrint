using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.BusinessAccessLayer;
using Printcenter.BusinessAccessLayer.Purchases;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

namespace Printcenter.DataAccessLayer.Purchases
{
	public class DbPurchase
	{
		public DbPurchase()
		{
		}

		public virtual DataTable company_client_alladdress_select_ForDeliveryAddress(int CompanyID, int CustomerID, string ClearFilter)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_client_alladdress_select_ForDeliveryAddress");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, CustomerID);
			database.AddInParameter(storedProcCommand, "@ClearFilter", DbType.String, ClearFilter);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable getPODeliveryAddress(int CompanyID, long PurchaseID, long DeliveryAddressID, string DeliveryAddressType, long EstimateID)
		{
			BaseClass baseClass = new BaseClass();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PurchaseOrder_DeliveryTo_Detail_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DeliveryAddressType);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				dataTable.Columns[i].ReadOnly = false;
			}
			foreach (DataRow row in dataTable.Rows)
			{
				row["CompanyName"] = baseClass.SpecialDecode(row["CompanyName"].ToString());
				row["Address"] = baseClass.SpecialDecode(row["Address"].ToString());
			}
			return dataTable;
		}

		public virtual DataTable getPODeliveryAddress_new(int CompanyID, long PurchaseID, long EstimateID)
		{
			BaseClass baseClass = new BaseClass();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PurchaseOrder_DeliveryTo_Detail_Select_SMP");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				dataTable.Columns[i].ReadOnly = false;
			}
			foreach (DataRow row in dataTable.Rows)
			{
				row["CompanyName"] = baseClass.SpecialDecode(row["CompanyName"].ToString());
				row["Address"] = baseClass.SpecialDecode(row["Address"].ToString());
			}
			return dataTable;
		}

		public virtual DataTable Kit_Details(long PriceCatalogueID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_PricecatalogueStock_KitDetails");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string KitItemDescription(int CompanyID, long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_KitItemDescription");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultipleProductDetails_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
			database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PO_ProductSelect(long EstimateItemID, string EstimateType)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Product_PO_select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet selectPOfromJob(long jobID, long companyID, long estimateID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("sp_getPurchaseOrderFromJobID", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@JobID", jobID);
			sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
			sqlCommand.Parameters.AddWithValue("@EstimateID", estimateID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void ProgressToJob_StockItem_Update(long PriceCatalogueID, long PurchaseItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProgressToJob_StockItem_Update");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

        public virtual void PurchaseItem_Goodsreceived_Update(bool IsGoodsReceived, long PurchaseItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PurchaseItem_Goodsreceived_Update");
            database.AddInParameter(storedProcCommand, "@IsGoodsReceived", DbType.Boolean, IsGoodsReceived);
            database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Purchase_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_advance_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
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

		public virtual void purchase_delete(int CompanyID, long PurchaseID)
		{
			long num = (long)0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Purchase_Comments_Update(int commentId, string newComment)
		{
			commonClass _commonClass = new commonClass();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_Comments_Update");
			database.AddInParameter(storedProcCommand, "@commentId", DbType.Int32, commentId);
			database.AddInParameter(storedProcCommand, "@newComment", DbType.String, newComment);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Purchase_History_Update(string Notes, long PriceCatalogueID, string NotesCompare)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogue_PurchaseHistory");
			database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@NotesCompare", DbType.String, NotesCompare);
			database.ExecuteNonQuery(storedProcCommand);
		}

		private static DateTime ToSqlDateTime(DateTime value)
		{
			if (value < new DateTime(1753, 1, 1))
			{
				return new DateTime(1900, 1, 1);
			}
			if (value > new DateTime(9999, 12, 31, 23, 59, 59))
			{
				return new DateTime(9999, 12, 31, 23, 59, 59);
			}
			return value;
		}

		public virtual long purchase_insert(PurchaseItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_insert");
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, item.PurchaseID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, item.SupplierID);
			database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, item.ContactID);
			database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, item.AddressID);
			database.AddInParameter(storedProcCommand, "@Comments", DbType.String, item.Comments);
			database.AddInParameter(storedProcCommand, "@FootNote", DbType.String, item.FootNote);
			database.AddInParameter(storedProcCommand, "@PONO", DbType.String, item.PONO);
			database.AddInParameter(storedProcCommand, "@PODate", DbType.DateTime, ToSqlDateTime(item.PODate));
			database.AddInParameter(storedProcCommand, "@ReferenceNo", DbType.String, item.ReferenceNo);
			database.AddInParameter(storedProcCommand, "@SupplierQuoteNo", DbType.String, item.SupplierQuoteNo);
			database.AddInParameter(storedProcCommand, "@SupplierInvoiceNo", DbType.String, item.SupplierInvoiceNo);
			database.AddInParameter(storedProcCommand, "@RaisedByID", DbType.Int32, item.RaisedByID);
			database.AddInParameter(storedProcCommand, "@ReqDate", DbType.DateTime, ToSqlDateTime(item.ReqDate));
			database.AddInParameter(storedProcCommand, "@GoodsReceived", DbType.Boolean, item.GoodsReceived);
			database.AddInParameter(storedProcCommand, "@InvoiceReceived", DbType.Boolean, item.InvoiceReceived);
			database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, item.StatusID);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ToSqlDateTime(item.ModifiedDate));
			database.AddInParameter(storedProcCommand, "@CurrentPONO", DbType.Int64, item.CurrentPONO);
			database.AddInParameter(storedProcCommand, "@AddressType", DbType.String, item.AddressType);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, item.EstimateID);
			database.AddInParameter(storedProcCommand, "@headernote", DbType.String, item.headernote);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@TodayDate", DbType.DateTime, ToSqlDateTime(item.TodayDate));
			database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, item.DeliveryAddressID);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, item.DeliveryAddressType);
			database.AddInParameter(storedProcCommand, "@CourierID", DbType.Int32, item.CourierID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, item.EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@SupplierInvoiceDate", DbType.DateTime, ToSqlDateTime(item.SupplierInvoiceDate));
			database.AddInParameter(storedProcCommand, "@PurhcasePrefix", DbType.String, ConnectionClass.PurhcasePrefix);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@IsFromProgreesTojob", DbType.String, item.IsFromProgreesTojob);

			database.AddInParameter(storedProcCommand, "@poNum", DbType.Int64, item.poNum);
			database.AddInParameter(storedProcCommand, "@isCombine", DbType.String, item.isCombine);

			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable GetPurchaseItemByJobID(long JobID, int CompanyID, long SupplierID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetPurchaseItemByJobID");
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int32, JobID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
		public virtual int GetPurchaseItemcount(long PurchaseID, string EstimateType, string Description,Decimal Qty, Decimal Price, int TaxID, Decimal TaxValue)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetPurchaseItemcount");
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);

			database.AddInParameter(storedProcCommand, "@Qty", DbType.Decimal, Qty);
			database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int64, TaxID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, TaxValue);

			return (int)database.ExecuteScalar(storedProcCommand);
		}
		public virtual int Purchase_Items_Count_Select(int CompanyID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_items_count");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Purchase_Make_Archive(int CompanyID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_make_archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long Purchase_Make_Copy(int CompanyID, long PurchaseID, short IsEstimatecopy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_copy");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.AddInParameter(storedProcCommand, "@IsEstimatecopy", DbType.Int16, IsEstimatecopy);
			database.AddInParameter(storedProcCommand, "@PurhcasePrefix", DbType.String, ConnectionClass.PurhcasePrefix);
			database.AddOutParameter(storedProcCommand, "@New_PurchaseID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@New_PurchaseID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataSet purchase_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_purchase_PageText", sqlConnection);
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

		public virtual DataTable purchase_search(int CompanyID, string Para)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Para", DbType.String, Para);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable purchase_select(int CompanyID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable purchase_select_by_EstimateItemID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_EstimateItemID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable purchase_select_by_EstimateItemID_and_MaterialID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID, long MaterialID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_EstItemID_and_MaterialID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@MaterialID", DbType.Int64, MaterialID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(long EstimateID, long EstimateItemID, long MaterialID, long EstLargeItemCalculationID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_EstItemID_and_MaterialID_LargeFormat");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@MaterialID", DbType.Int64, MaterialID);
			database.AddInParameter(storedProcCommand, "@EstLargeItemCalculationID", DbType.Int64, EstLargeItemCalculationID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Purchase_select_by_EstimateItemID_Product_AddItem(long EstimateID, long EstimateItemID, long EstimateAdditionalItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_EstimateItemID_Product_AddItem");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateAdditionalItemID", DbType.Int64, EstimateAdditionalItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable purchase_selectall(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_selectall");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void purchase_warehouseitemid_update(int CompanyID, long PurchaseItemID, long WarehouseItemID, string WarehouseItemType, string ItemCode)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_warehouseitemid_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, ItemCode);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void purchase_warehouseqty_update(int CompanyID, long WarehouseItemID, string WarehouseItemType, decimal StockQty)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_warehouseqty_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@StockQty", DbType.Decimal, StockQty);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual string purchase_warehousestockqty_select(int CompanyID, long WarehouseItemID, string WarehouseItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_warehousestockqty_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, WarehouseItemType);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void purchaseitem_delete(int CompanyID, long PurchaseItemID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long purchaseitem_insert(PurchaseItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, item.PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, item.PurchaseID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, item.WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, item.WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, item.ItemCode);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Decimal, item.PurQty);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.PurPackedIn);
			database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, item.Price);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, item.TaxValue);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, item.AccountCodeID);
			database.AddInParameter(storedProcCommand, "@Note", DbType.String, item.Note);
			database.AddInParameter(storedProcCommand, "@IsGoodsReceived", DbType.String, item.GoodsReceived);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, item.EstimateType);
			database.AddInParameter(storedProcCommand, "@isFromProductItem", DbType.Boolean, false);
			database.AddInParameter(storedProcCommand, "@EstLargeItemCalculationID", DbType.Int64, item.EstLargeItemCalculationID);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, item.UserID);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, item.CreatedDate);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long purchaseitem_insert_new(PurchaseItem item)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, item.PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, item.PurchaseID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, item.WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, item.WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, item.ItemCode);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Decimal, item.PurQty);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.PurPackedIn);
			database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, item.Price);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, item.TaxValue);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, item.AccountCodeID);
			database.AddInParameter(storedProcCommand, "@Note", DbType.String, item.Note);
			database.AddInParameter(storedProcCommand, "@IsGoodsReceived", DbType.String, item.GoodsReceived);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, item.EstimateType);
			database.AddInParameter(storedProcCommand, "@AdditionalOptionDetails", DbType.String, item.AdditionalOptionDetails);
            database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.String, item.IsCompleted);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), item.CompanyID, num, true));
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long purchaseitem_insert_ProdAdditional_Item(PurchaseItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_insert_ProdAdditional_Item");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, item.PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, item.PurchaseID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, item.WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, item.WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, item.ItemCode);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Decimal, item.PurQty);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.PurPackedIn);
			database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, item.Price);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, item.TaxValue);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, item.AccountCodeID);
			database.AddInParameter(storedProcCommand, "@Note", DbType.String, item.Note);
			database.AddInParameter(storedProcCommand, "@IsGoodsReceived", DbType.String, item.GoodsReceived);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, item.EstimateType);
			database.AddInParameter(storedProcCommand, "@isFromProductItem", DbType.Boolean, false);
			database.AddInParameter(storedProcCommand, "@EstLargeItemCalculationID", DbType.Int64, item.EstLargeItemCalculationID);
			database.AddInParameter(storedProcCommand, "@EstimateAdditionalItemID", DbType.Int64, item.EstimateAdditionalItemID);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, item.UserID);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, item.CreatedDate);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long purchaseitem_insertPOfromJob(PurchaseItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, item.PurchaseItemID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, item.PurchaseID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, item.WarehouseItemID);
			database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, item.WarehouseItemType);
			database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, item.ItemCode);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Decimal, item.PurQty);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.PurPackedIn);
			database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, item.Price);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, item.TaxValue);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, item.AccountCodeID);
			database.AddInParameter(storedProcCommand, "@Note", DbType.String, item.Note);
			database.AddInParameter(storedProcCommand, "@IsGoodsReceived", DbType.String, item.GoodsReceived);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, item.EstimateType);
			database.AddInParameter(storedProcCommand, "@isFromProductItem", DbType.Boolean, item.isFromProductItem);
			database.AddInParameter(storedProcCommand, "@EstLargeItemCalculationID", DbType.Int64, item.EstLargeItemCalculationID);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, item.UserID);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, item.CreatedDate);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable purchaseitem_select(int CompanyID, long PurchaseID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseitem_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PurchaseItems_Details_Select(long PurchaseItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PurchaseItemDetails_Select");
			database.AddInParameter(storedProcCommand, "@PurchaseItemID", DbType.Int64, PurchaseItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void PurchaseOnCheck_Status_Update(int CompanyID, string PurchaseIDs, int StatusID, string Module)
		{
			long num = (long)0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateOnCheck_Status_Update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateIDS", DbType.String, PurchaseIDs);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int32, num);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Select_PriceCat_ItemTitle_n_DrawStockFrom(long PriceCatalogue)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_PriceCat_ItmTtle_n_DrawStkFrm");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogue);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataSet Warehouse_Inventory_Select(int CompanyID, int ClientID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Warehouse_Inventory_PerSupplier_Select", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ClientID", ClientID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}
	}
}