using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.BusinessAccessLayer;
using Printcenter.BusinessAccessLayer.Inventories;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Inventories
{
	public class DbInventory : DataAccess
	{
		public DbInventory()
		{
		}

		public virtual DataTable autocomplete_inventory_selectink(int CompanyID, string ItemType, string InkType, string SearchParameter)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_autocomplete_inventory_selectink");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@InkType", DbType.String, InkType);
			database.AddInParameter(storedProcCommand, "@SearchParameter", DbType.String, SearchParameter);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Bind_StockAdditionalItems(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_StockAdditionalItems_inPurchase");
			database.AddInParameter(storedProcCommand, "@pricecatalogueid", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Copy_Inventory(int CompanyID, long InventoryID, int InStock)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Copy_Inventory");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.AddInParameter(storedProcCommand, "@InStock", DbType.Int64, InStock);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable Fetch_Inventory_Dependancy(long CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Fetch_Inventory_Dependancy");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void FinishedGoods_AccountingCode_Insert(long CompanyID, long FinishedGoodsID, int AccountCodeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_FinishedGoods_AccountingCode_Insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int64, FinishedGoodsID);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int FinishedGoods_AccountingCode_Select(long CompanyID, long FinishedGoodsID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_FinishedGoods_AccountingCode_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int64, FinishedGoodsID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual decimal finishedgoods_getPackedIn_qty(int CompanyID, int FinishedGoodsID, char GoodsType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_finishedgoods_getPackedIn_qty");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, FinishedGoodsID);
			database.AddInParameter(storedProcCommand, "@GoodsType", DbType.String, GoodsType);
			database.ExecuteNonQuery(storedProcCommand);
			return (decimal)database.ExecuteScalar(storedProcCommand);
		}

		public virtual string GetUserEmail(int CompanyID, int UserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			object[] companyID = new object[] { "select isnull(dbo.GetUserEmail ( ", CompanyID, " , ", UserID, "),' ' )" };
			DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat(companyID));
			return (string)database.ExecuteScalar(sqlStringCommand);
		}

		public virtual void Inventory_AccountingCode_Insert(long CompanyID, long InventoryID, int AccountCodeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Inventory_AccountingCode_Insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int Inventory_AccountingCode_Select(long CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Inventory_AccountingCode_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable Inventory_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_advance_search");
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
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual decimal inventory_getPackedIn_qty(int CompanyID, int InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_inventory_getPackedIn_qty");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int32, InventoryID);
			database.ExecuteNonQuery(storedProcCommand);
			return (decimal)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Inventory_InventoryAlerts_On_Insert_Update(long InventoryID, string AlertType, string AlertEmailID, string Reason)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Inventory_InventoryAlerts_On_Insert_Update");
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.AddInParameter(storedProcCommand, "@alertType", DbType.String, AlertType);
			database.AddInParameter(storedProcCommand, "@alertEmailID", DbType.String, AlertEmailID);
			database.AddInParameter(storedProcCommand, "@adjustedReason", DbType.String, Reason);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet inventory_selectall(int CompanyID, string ItemType, string PaperType, string InkType)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_inventory_selectall", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ItemType", ItemType);
			sqlCommand.Parameters.AddWithValue("@PaperType", PaperType);
			sqlCommand.Parameters.AddWithValue("@InkType", InkType);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet inventory_SelectLargeFormat(int CompanyID, string ItemType)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_inventory_selectLargeFormatMaterial", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ItemType", ItemType);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void InventoryItem_Update(int CompanyID, string InventoryCode, int Quantity, string Description, int userID, long PurchaseItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_inventoryItem_Update]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryCode", DbType.String, InventoryCode);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Quantity);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
			database.AddInParameter(storedProcCommand, "@userID", DbType.Int32, userID);
			database.AddInParameter(storedProcCommand, "@purchaseItemID", DbType.Int64, PurchaseItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Select_Activity_History_For_Inventory(long InventoryID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Activity_History_For_Inventory");
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Select_finishedgoods_for_Estimate(int CompanyID, char finishedgoodstype, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Select_finishedgoods_for_Estimate", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@FinishedGoodType", finishedgoodstype);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@SortBy", SortedBy);
			sqlCommand.Parameters.AddWithValue("@SortDirection", Direction);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", para);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet Select_Inventory_Select_Estimate(int CompanyID, int PageSize, int PageNumber, string SortedBy, string Direction, string para)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Select_Inventory_Select_Estimate", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@SortBy", SortedBy);
			sqlCommand.Parameters.AddWithValue("@SortDirection", Direction);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", para);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet SelectProductcatalogueitems_InPurchse(int CompanyID, int PageSize, int PageNumber, string WhereCondition)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_SelectProductcatalogueitems_InPurchse", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataTable settings_InvCategory_selectall(int CompanyID, string CategoryName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_invcategory_selectall]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, CategoryName);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable settings_inventoryproperties_name_select(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_inventoryproperties_name_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable settings_inventoryproperties_name_select_by_categoryID(int CompanyID, int CategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_inventoryproperties_name_select_by_categoryID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int settings_stockcategory_delete(int CompanyID, int CategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stockcategory_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int settings_stockcategory_insert(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stockcategory_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryCode", DbType.String, item.CategoryCode);
			database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, item.CategoryName);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@IsWeight", DbType.Boolean, item.IsWeight);
			database.AddInParameter(storedProcCommand, "@IsColor", DbType.Boolean, item.IsColor);
			database.AddInParameter(storedProcCommand, "@IsItemCustomSize", DbType.Boolean, item.IsItemCustomSize);
			database.AddInParameter(storedProcCommand, "@IsItemPaperSize", DbType.Boolean, item.IsItemPaperSize);
			database.AddInParameter(storedProcCommand, "@IsCoatingType", DbType.Boolean, item.IsCoatingType);
			database.AddInParameter(storedProcCommand, "@IsPrinting", DbType.Boolean, item.IsPrinting);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable settings_stockcategory_select(int CompanyID, int CategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stockcategory_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable settings_stockcategory_selectall(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stockcategory_selectall");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int settings_stockcategory_update(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stockcategory_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, item.CategoryID);
			database.AddInParameter(storedProcCommand, "@CategoryCode", DbType.String, item.CategoryCode);
			database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, item.CategoryName);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@IsWeight", DbType.Boolean, item.IsWeight);
			database.AddInParameter(storedProcCommand, "@IsColor", DbType.Boolean, item.IsColor);
			database.AddInParameter(storedProcCommand, "@IsItemCustomSize", DbType.Boolean, item.IsItemCustomSize);
			database.AddInParameter(storedProcCommand, "@IsItemPaperSize", DbType.Boolean, item.IsItemPaperSize);
			database.AddInParameter(storedProcCommand, "@IsCoatingType", DbType.Boolean, item.IsCoatingType);
			database.AddInParameter(storedProcCommand, "@IsPrinting", DbType.Boolean, item.IsPrinting);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int settings_stocksubcategory_delete(int CompanyID, int SubCategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SubCategoryID", DbType.Int32, SubCategoryID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int settings_stocksubcategory_insert(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentCategory", DbType.Int32, item.CategoryID);
			database.AddInParameter(storedProcCommand, "@SubCategoryCode", DbType.String, item.SubCategoryCode);
			database.AddInParameter(storedProcCommand, "@SubCategoryName", DbType.String, item.SubCategoryName);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable settings_stocksubcategory_select(int CompanyID, int SubCategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SubCategoryID", DbType.Int32, SubCategoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable settings_stocksubcategory_select_by_categoryid(int CompanyID, int ParentCategory)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_select_by_categoryid");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentCategory", DbType.Int32, ParentCategory);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable settings_stocksubcategory_selectall(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_selectall");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int settings_stocksubcategory_update(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_stocksubcategory_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@SubCategoryID", DbType.Int32, item.SubCategoryID);
			database.AddInParameter(storedProcCommand, "@ParentCategory", DbType.Int32, item.CategoryID);
			database.AddInParameter(storedProcCommand, "@SubCategoryCode", DbType.String, item.SubCategoryCode);
			database.AddInParameter(storedProcCommand, "@SubCategoryName", DbType.String, item.SubCategoryName);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable settings_subcategoryonID_selectall(int ParentCategory)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_subcategoryonID_selectall");
			database.AddInParameter(storedProcCommand, "@ParentCategory", DbType.Int32, ParentCategory);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Warehouse_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string pagetype, string TodayDate, string StartDate, string EndDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_advance_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
			database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
			database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
			database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
			database.AddInParameter(storedProcCommand, "@pagetype", DbType.String, pagetype);
			database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
			database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
			database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long warehouse_code_select(int companyid, string type)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_code_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, type);
			return (long)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void warehouse_code_update(int companyid, string type, long lastcount)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_code_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, type);
			database.AddInParameter(storedProcCommand, "@LastCount", DbType.Int64, lastcount);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int warehouse_finished_goods_duplicacy_check(int CompanyID, string ProductName, string ProductCode, long GoodsID, string GooodsType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedduplicacy_check");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ProductName", DbType.String, ProductName);
			database.AddInParameter(storedProcCommand, "@ProductCode", DbType.String, ProductCode);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int64, GoodsID);
			database.AddInParameter(storedProcCommand, "@GoodsType", DbType.String, GooodsType);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual void warehouse_finishedgoods_archive(int companyid, int goodsid)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, goodsid);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void warehouse_finishedgoods_delete(int companyid, int goodsid)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, goodsid);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void warehouse_finishedgoods_edit(int companyid, int goodsid, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_edit");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, goodsid);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, customerid);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, supplierid);
			database.AddInParameter(storedProcCommand, "@BarCode", DbType.String, barcode);
			database.AddInParameter(storedProcCommand, "@ProductName", DbType.String, productname);
			database.AddInParameter(storedProcCommand, "@ProductCode", DbType.String, productcode);
			database.AddInParameter(storedProcCommand, "@Location", DbType.String, location);
			database.AddInParameter(storedProcCommand, "@SupplierPartNo", DbType.String, supplierPartNo);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, taxID);
			database.AddInParameter(storedProcCommand, "@PackQuantity", DbType.Decimal, packQuantity);
			database.AddInParameter(storedProcCommand, "@PackCostPrice", DbType.Decimal, packCostPrice);
			database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, markup);
			database.AddInParameter(storedProcCommand, "@PackSalePrice", DbType.Decimal, packSalePrice);
			database.AddInParameter(storedProcCommand, "@InStockQuantity", DbType.Int32, inStockQuantity);
			database.AddInParameter(storedProcCommand, "@ReOrderLevel", DbType.Int32, reOrderLevel);
			database.AddInParameter(storedProcCommand, "@ReOrderQuantity", DbType.Int32, reorderQuantity);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
			database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet warehouse_finishedgoods_forestimate_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int CustomerID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_warehouse_finishedgoods_forestimate_PageText", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@FinishedGoodType", FinishedGoodType);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
			sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
			sqlCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual int warehouse_finishedgoods_insert(int companyid, char goodstype, int customerid, int supplierid, string barcode, string productname, string productcode, string location, string supplierPartNo, int taxID, decimal packQuantity, decimal packCostPrice, int markup, decimal packSalePrice, int inStockQuantity, int reOrderLevel, int reorderQuantity, string description, decimal ProfitMargin)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@GoodsType", DbType.String, goodstype);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, customerid);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, supplierid);
			database.AddInParameter(storedProcCommand, "@BarCode", DbType.String, barcode);
			database.AddInParameter(storedProcCommand, "@ProductName", DbType.String, productname);
			database.AddInParameter(storedProcCommand, "@ProductCode", DbType.String, productcode);
			database.AddInParameter(storedProcCommand, "@Location", DbType.String, location);
			database.AddInParameter(storedProcCommand, "@SupplierPartNo", DbType.String, supplierPartNo);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, taxID);
			database.AddInParameter(storedProcCommand, "@PackQuantity", DbType.Decimal, packQuantity);
			database.AddInParameter(storedProcCommand, "@PackCostPrice", DbType.Decimal, packCostPrice);
			database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, markup);
			database.AddInParameter(storedProcCommand, "@PackSalePrice", DbType.Decimal, packSalePrice);
			database.AddInParameter(storedProcCommand, "@InStockQuantity", DbType.Int32, inStockQuantity);
			database.AddInParameter(storedProcCommand, "@ReOrderLevel", DbType.Int32, reOrderLevel);
			database.AddInParameter(storedProcCommand, "@ReOrderQuantity", DbType.Int32, reorderQuantity);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
			database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataSet warehouse_finishedgoods_PageText(int CompanyID, string FinishedGoodType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_warehouse_finishedgoods_PageText", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@FinishedGoodType", FinishedGoodType);
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

		public virtual DataTable warehouse_finishedgoods_search(int CompanyID, string FinishedgoodType, string SearchText)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@FinishedgoodType", DbType.String, FinishedgoodType);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void warehouse_finishedgoods_select(int companyid, int goodsid, char goodstype, TextBox txtbarcode, TextBox txtproductname, TextBox txtproductcode, TextBox txtlocation, DropDownList ddlsupplier, TextBox txtpartNo, DropDownList ddltax, TextBox txtpackquentity, TextBox txtPackCostPrice, DropDownList ddlmarkup, HiddenField hid_packprice, TextBox txtInstock, TextBox txtReOrderLevel, TextBox txtReorderQuantity, DropDownList ddlcustomer, TextBox txtdescription, TextBox txtProfitMargin, HiddenField hdn_ArchiveID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_wareshouse_finishedgoods_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, goodsid);
			database.AddInParameter(storedProcCommand, "@GoodsType", DbType.String, goodstype);
			IDataReader dataReader = database.ExecuteReader(storedProcCommand);
			while (dataReader.Read())
			{
				txtbarcode.Text = dataReader["BarCode"].ToString();
				txtproductname.Text = dataReader["ProductName"].ToString();
				txtproductcode.Text = dataReader["ProductCode"].ToString();
				txtlocation.Text = dataReader["Location"].ToString();
				txtpartNo.Text = dataReader["SupplierPartNo"].ToString();
				txtpackquentity.Text = dataReader["PackQuantity"].ToString();
				txtPackCostPrice.Text = dataReader["PackCostPrice"].ToString();
				hid_packprice.Value = dataReader["PackSalePrice"].ToString();
				txtInstock.Text = dataReader["InStockQuantity"].ToString();
				txtReOrderLevel.Text = dataReader["ReOrderLevel"].ToString();
				txtReorderQuantity.Text = dataReader["ReOrderQuantity"].ToString();
				txtdescription.Text = dataReader["Description"].ToString();
				txtProfitMargin.Text = dataReader["ProfitMargin"].ToString();
				hdn_ArchiveID.Value = dataReader["IsArchived"].ToString();
				for (int i = 0; i < ddlsupplier.Items.Count; i++)
				{
					if (ddlsupplier.Items[i].Value == dataReader["SupplierID"].ToString())
					{
						ddlsupplier.SelectedIndex = i;
					}
				}
				for (int j = 0; j < ddltax.Items.Count; j++)
				{
					if (ddltax.Items[j].Value == dataReader["TaxID"].ToString())
					{
						ddltax.SelectedIndex = j;
					}
				}
				if (goodstype != 'c')
				{
					continue;
				}
				for (int k = 0; k < ddlcustomer.Items.Count; k++)
				{
					if (ddlcustomer.Items[k].Value == dataReader["CustomerID"].ToString())
					{
						ddlcustomer.SelectedIndex = k;
					}
				}
			}
			dataReader.Dispose();
			storedProcCommand.Dispose();
		}

		public virtual void warehouse_finishedgoods_unarchive(int companyid, int goodsid)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_finishedgoods_unarchive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
			database.AddInParameter(storedProcCommand, "@FinishedGoodsID", DbType.Int32, goodsid);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void warehouse_inventory_adjustment_update(int CompanyID, long InventoryID, long InventoryPropertyID, int InStock, decimal Cost)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_adjustment_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.AddInParameter(storedProcCommand, "@InventoryPropertyID", DbType.Int64, InventoryPropertyID);
			database.AddInParameter(storedProcCommand, "@InStock", DbType.Int32, InStock);
			database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Cost);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public DataSet Warehouse_Inventory_AllSupplier_Select(int CompanyID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Warehouse_Inventory_AllSupplier_Select", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void warehouse_inventory_archive(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void warehouse_inventory_delete(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int warehouse_inventory_insert(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryName", DbType.String, item.InventoryName);
			database.AddInParameter(storedProcCommand, "@FriendlyName", DbType.String, item.FriendlyName);
			database.AddInParameter(storedProcCommand, "@InventoryCode", DbType.String, item.InventoryCode);
			database.AddInParameter(storedProcCommand, "@InventoryCategoryID", DbType.Int32, item.InventoryCategoryID);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Location", DbType.String, item.Location);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, item.SupplierID);
			database.AddInParameter(storedProcCommand, "@InStock", DbType.Decimal, item.InvInStock);
			database.AddInParameter(storedProcCommand, "@ReOrderLevel", DbType.Decimal, item.ReOrderLevel);
			database.AddInParameter(storedProcCommand, "@ReOrderQuantity", DbType.Int32, item.ReOrderQuantity);
			database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Int32, item.AllocatedQty);
			database.AddInParameter(storedProcCommand, "@IsLargeFromatMaterial", DbType.Boolean, item.IsLargeFormatMaterial);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable warehouse_inventory_search(int CompanyID, string SearchText)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_search");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable warehouse_inventory_select(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable warehouse_inventory_selectall(int CompanyID, string ItemType, string SearchText)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_selectall");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable warehouse_inventory_selectall_onclientid(int CompanyID, int ClientID, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_selectall_onclientid");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet warehouse_inventory_selectall_onclientid_PageText(int CompanyID, int ClientID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_warehouse_inventory_selectall_onclientid_PageText", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ClientID", ClientID);
			sqlCommand.Parameters.AddWithValue("@ItemType", ItemType);
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

		public virtual DataSet warehouse_inventory_selectall_PageText(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string PaperType, string InkType)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_PurchseOrder_inventory_selectall_PageText", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ItemType", ItemType);
			sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
			sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
			sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
			sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
			sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
			sqlCommand.Parameters.AddWithValue("@PaperType", PaperType);
			sqlCommand.Parameters.AddWithValue("@InkType", InkType);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataTable warehouse_inventory_selectink(int CompanyID, string ItemType, string InkType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_selectink");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@InkType", DbType.String, InkType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable warehouse_inventory_selectink_withinktype(int CompanyID, long LithoPressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_selectink_withinktype");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.String, LithoPressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet warehouse_inventory_selectLargeFormat(int CompanyID, string ItemType, string SearchText)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_warehouse_inventory_select_LargeFormatMaterial", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@ItemType", ItemType);
			sqlCommand.Parameters.AddWithValue("@SearchText", SearchText);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual void warehouse_inventory_unarchive(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_unarchive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int warehouse_inventory_update(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventory_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, item.InventoryID);
			database.AddInParameter(storedProcCommand, "@InventoryName", DbType.String, item.InventoryName);
			database.AddInParameter(storedProcCommand, "@FriendlyName", DbType.String, item.FriendlyName);
			database.AddInParameter(storedProcCommand, "@InventoryCode", DbType.String, item.InventoryCode);
			database.AddInParameter(storedProcCommand, "@InventoryCategoryID", DbType.Int32, item.InventoryCategoryID);
			database.AddInParameter(storedProcCommand, "@Description", DbType.String, item.Description);
			database.AddInParameter(storedProcCommand, "@Location", DbType.String, item.Location);
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, item.SupplierID);
			database.AddInParameter(storedProcCommand, "@InStock", DbType.Decimal, item.InStock);
			database.AddInParameter(storedProcCommand, "@ReOrderLevel", DbType.Decimal, item.ReOrderLevel);
			database.AddInParameter(storedProcCommand, "@ReOrderQuantity", DbType.Int32, item.ReOrderQuantity);
			database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Decimal, item.AllocatedQty);
			database.AddInParameter(storedProcCommand, "@IsLargeFormatMaterial", DbType.Boolean, Convert.ToBoolean(item.IsLargeFormatMaterial));
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int warehouse_inventoryduplicacy_check(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventoryduplicacy_check");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryName", DbType.String, item.InventoryName);
			database.AddInParameter(storedProcCommand, "@InventoryCode", DbType.String, item.InventoryCode);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, item.InventoryID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual int warehouse_inventoryinkMatrix_insert(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_InventoryInkMatrixDetails");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, item.InventoryID);
			database.AddInParameter(storedProcCommand, "@InventorySheetsFrom", DbType.Int64, item.InventorySheetsFrom);
			database.AddInParameter(storedProcCommand, "@InventorySheetsTo", DbType.Int64, item.InventorySheetsTo);
			database.AddInParameter(storedProcCommand, "@ChargableCost", DbType.Decimal, item.ChargableCost);
			database.AddInParameter(storedProcCommand, "@ChargableSheets", DbType.Int64, item.ChargableSheets);
			database.AddInParameter(storedProcCommand, "@SetUpCost", DbType.Decimal, item.SetUpCost);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable warehouse_inventoryinkMatrix_select(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_InventoryInkMatrixDetails");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void warehouse_inventoryinkMatrix_Update(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_InventoryInkMatrixDetails");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, item.InventoryID);
			database.AddInParameter(storedProcCommand, "@InkMatrixId", DbType.Int64, item.InkMatrixId);
			database.AddInParameter(storedProcCommand, "@InventorySheetsFrom", DbType.Int64, item.InventorySheetsFrom);
			database.AddInParameter(storedProcCommand, "@InventorySheetsTo", DbType.Int64, item.InventorySheetsTo);
			database.AddInParameter(storedProcCommand, "@ChargableCost", DbType.Decimal, item.ChargableCost);
			database.AddInParameter(storedProcCommand, "@ChargableSheets", DbType.Int64, item.ChargableSheets);
			database.AddInParameter(storedProcCommand, "@SetUpCost", DbType.Decimal, item.SetUpCost);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int warehouse_inventoryproperties_insert(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventoryproperties_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int32, item.InventoryID);
			database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, item.Cost);
			database.AddInParameter(storedProcCommand, "@PerQuantity", DbType.Decimal, item.InvPerQuantity);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.InvPackedIn);
			database.AddInParameter(storedProcCommand, "@PackedPrice", DbType.Decimal, item.PackedPrice);
			database.AddInParameter(storedProcCommand, "@ProcessCharge", DbType.Decimal, item.ProcessCharge);
			database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, item.SellingPrice);
			database.AddInParameter(storedProcCommand, "@CostPerReel", DbType.Decimal, item.CostPerReel);
			database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, item.PaperSizeID);
			database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, item.Height);
			database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, item.Width);
			database.AddInParameter(storedProcCommand, "@WidthType", DbType.String, item.WidthType);
			database.AddInParameter(storedProcCommand, "@Length", DbType.Decimal, item.InvLength);
			database.AddInParameter(storedProcCommand, "@LengthType", DbType.String, item.LengthType);
			database.AddInParameter(storedProcCommand, "@BasisWeight", DbType.Decimal, item.BasisWeight);
			database.AddInParameter(storedProcCommand, "@Coated", DbType.String, item.Coated);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@PaperType", DbType.String, item.PaperType);
			database.AddInParameter(storedProcCommand, "@InkAbsorption", DbType.Decimal, item.InkAbsorption);
			database.AddInParameter(storedProcCommand, "@WashupCounter", DbType.Int32, item.WashupCounter);
			database.AddInParameter(storedProcCommand, "@Yield", DbType.Decimal, item.Yield);
			database.AddInParameter(storedProcCommand, "@YieldType", DbType.String, item.YieldType);
			database.AddInParameter(storedProcCommand, "@PackedInType", DbType.String, item.PackedInType);
			database.AddInParameter(storedProcCommand, "@InkType", DbType.String, item.InkType);
			database.AddInParameter(storedProcCommand, "@InkMinimumCost", DbType.Decimal, item.InkMinimumCost);
			database.AddInParameter(storedProcCommand, "@CostPerLinear", DbType.Decimal, item.CostPerLinear);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, item.Markup);
			database.AddInParameter(storedProcCommand, "@Caliper", DbType.Decimal, item.Caliper);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

		public virtual DataTable warehouse_inventoryproperties_select(int CompanyID, long InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventoryproperties_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int warehouse_inventoryproperties_update(InventoryItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_inventoryproperties_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, item.InventoryID);
			database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, item.Cost);
			database.AddInParameter(storedProcCommand, "@PerQuantity", DbType.Decimal, item.InvPerQuantity);
			database.AddInParameter(storedProcCommand, "@PackedIn", DbType.Decimal, item.InvPackedIn);
			database.AddInParameter(storedProcCommand, "@PackedPrice", DbType.Decimal, item.PackedPrice);
			database.AddInParameter(storedProcCommand, "@ProcessCharge", DbType.Decimal, item.ProcessCharge);
			database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, item.SellingPrice);
			database.AddInParameter(storedProcCommand, "@CostPerReel", DbType.Decimal, item.CostPerReel);
			database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, item.PaperSizeID);
			database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, item.Height);
			database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, item.Width);
			database.AddInParameter(storedProcCommand, "@WidthType", DbType.String, item.WidthType);
			database.AddInParameter(storedProcCommand, "@Length", DbType.Decimal, item.InvLength);
			database.AddInParameter(storedProcCommand, "@LengthType", DbType.String, item.LengthType);
			database.AddInParameter(storedProcCommand, "@BasisWeight", DbType.Decimal, item.BasisWeight);
			database.AddInParameter(storedProcCommand, "@Coated", DbType.String, item.Coated);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@PaperType", DbType.String, item.PaperType);
			database.AddInParameter(storedProcCommand, "@InkAbsorption", DbType.Decimal, item.InkAbsorption);
			database.AddInParameter(storedProcCommand, "@WashupCounter", DbType.Int32, item.WashupCounter);
			database.AddInParameter(storedProcCommand, "@Yield", DbType.Decimal, item.Yield);
			database.AddInParameter(storedProcCommand, "@YieldType", DbType.String, item.YieldType);
			database.AddInParameter(storedProcCommand, "@PackedInType", DbType.String, item.PackedInType);
			database.AddInParameter(storedProcCommand, "@InkType", DbType.String, item.InkType);
			database.AddInParameter(storedProcCommand, "@InkMinimumCost", DbType.Decimal, item.InkMinimumCost);
			database.AddInParameter(storedProcCommand, "@CostPerLinear", DbType.Decimal, item.CostPerLinear);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, item.Markup);
			database.AddInParameter(storedProcCommand, "@Caliper", DbType.Decimal, item.Caliper);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
		}

        public static DataTable uppernavigator_select(int CompanyID, string moduleName, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("SP_uppernavigator_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@moduleName", DbType.String, moduleName);
            database.AddInParameter(storedProcCommand, "@userid", DbType.String, userid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}