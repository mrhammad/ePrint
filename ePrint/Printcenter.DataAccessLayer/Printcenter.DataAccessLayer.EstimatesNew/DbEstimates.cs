using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

namespace Printcenter.DataAccessLayer.EstimatesNew
{
	public class DbEstimates
	{
		public DbEstimates()
		{
		}

		public virtual void AccountCode_Update_InSummary(int CompanyID, long EstimateItemID, string EstimateType, int AccountCodeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AccountingCode_Update_InSummary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
			database.ExecuteNonQuery(storedProcCommand);
		}

        public virtual void Update_EstimateItems_SortingOrder(long EstimateItemID, int SortingOrderId, string pageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItems_SortingOrder_Update");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@SortingOrderId", DbType.Int32, SortingOrderId);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, pageName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void update_multiple_product_categories(long PriceCatalogueID, int PriceCatalogueCategoryID_2, int PriceCatalogueCategoryID_3, int PriceCatalogueCategoryID_4, int PriceCatalogueCategoryID_5, int PriceCatalogueCategoryID_6)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("update_multiple_product_categories");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID_2", DbType.Int32, PriceCatalogueCategoryID_2);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID_3", DbType.Int32, PriceCatalogueCategoryID_3);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID_4", DbType.Int32, PriceCatalogueCategoryID_4);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID_5", DbType.Int32, PriceCatalogueCategoryID_5);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID_6", DbType.Int32, PriceCatalogueCategoryID_6);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Import_otherstore_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherStore_Delivery_Costs_Import");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, PriceCatalogueCategoryID_2);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Import_MIS_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_MIS_Delivery_Costs_Import");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, PriceCatalogueCategoryID_2);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable AccountingCode_Select_forRerun(long EstimateID, long EstimateItemID, string estimatetype)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AccountingCode_Select_forRerun");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, estimatetype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void AddMore_Supplier(long SupplierID, long SupplierContactID, long EstimateItemID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_AddMore_QuoteDetails");
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, SupplierID);
			database.AddInParameter(storedProcCommand, "@SupplierContactID", DbType.Int64, SupplierContactID);
			database.AddInParameter(storedProcCommand, "@EstimateITemID", DbType.Int64, EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void booklet_delete(int CompanyID, long EstimateBookletItemID, string EstType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_booklet_delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstType", DbType.String, EstType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long booklet_item_insert(EstimatesItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_booklet_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, item.EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ParentID", DbType.Int64, item.ParentID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, item.SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, item.RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
			database.AddInParameter(storedProcCommand, "@BookletType", DbType.String, item.BookletType);
			database.AddInParameter(storedProcCommand, "@NoOfPagesInSection", DbType.Decimal, item.NoOfPagesInSection);
			database.AddInParameter(storedProcCommand, "@PagesPerSignature", DbType.Decimal, item.PagesPerSignature);
			database.AddInParameter(storedProcCommand, "@NoOfSignatures", DbType.Decimal, item.NoOfSignatures);
			database.AddInParameter(storedProcCommand, "@BookletFormat", DbType.String, item.BookletFormat);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, item.SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, item.SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, item.JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, item.JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, item.GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, item.GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@NonImageHeight", DbType.Decimal, item.NonImageHeight);
			database.AddInParameter(storedProcCommand, "@NonImageWidth", DbType.Decimal, item.NonImageWidth);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, item.PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, item.LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
			database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
			database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
			database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.Boolean, item.IsCompleted);
			database.AddInParameter(storedProcCommand, "@SectionReference", DbType.String, item.SectionRef);
			database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, item.IsDeleted);
			database.AddInParameter(storedProcCommand, "@isCeilPrintSheetPerSection", DbType.Boolean, item.isCeilPrintSheetPerSection);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, item.ManualValue);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable booklet_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_booklet_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable booklet_job_qty(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_booklet_job_qty");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Booklet_SelectSubsectioniddetail_byEstimateBookletItemID(int CompanyID, long EstimateItemID, string Estimationtype, long EstimateBookletItemID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Booklet_SelectSubsectioniddetail_byEstimateBookletItemID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, Estimationtype);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public static DataSet bookletncr_subtotal_all_select(int CompanyID, long EstimateItemID, string EstimateType)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_bookletncr_subtotal_all_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, EstimateType);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual long calculation_insert_estimate(int CompanyID, string Data)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_calculation_insert_estimate");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
			database.AddOutParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@EstimateCalculationID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual string Check_EstimateItem_Transaction(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_KitDetails_EstimateItems_Status_Change");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual bool Check_SpecialPrivilege_For_User(long UserID, long CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Check_SpecialPrivilege_For_User");
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			return (bool)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable CheckSubitemPresentsorNotinItemDescriptionpage(long ParentItemID, string ParentItemType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("CheckSubitemPresentsorNotinItemDescriptionpage");
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable client_tax_select(int CompanyID, int CustomerID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_tax_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Clients_New_Contact_Select(int CompanyID, int ClientID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Clients_New_Contact_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Clientid", DbType.Int32, ClientID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long copy_booklet_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_booklet_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_large_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_large_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_othercost_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_othercost_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_outwork_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_outwork_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_pad_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_pad_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_price_catalogue(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_price_catalogue_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long copy_warehouse_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_warehouse_item_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable CopyesttitletoitemTitle(int Companyid, long EstimateID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("CopyesttitletoitemTitle");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, Companyid);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Copying_ArtworkFile(long CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_ArtworkFile");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void copyJobInvoice_isdirect(int CompanyID, long EstimateID, string Isdirect)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copyJobInvoice_isdirect");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@Isdirect", DbType.String, Isdirect);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable cost_view_for_booklet(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_cost_view_for_booklet");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void delete_on_booklet(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delete_on_booklet");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void deletencrsection(long Estimateitemid, int DelPartsCount)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deletencrsection");
			database.AddInParameter(storedProcCommand, "@Estimateitemid", DbType.Int64, Estimateitemid);
			database.AddInParameter(storedProcCommand, "@DelPartsCount", DbType.Int32, DelPartsCount);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Estimate_AccountingCode_Insert(int AccountCodeID, long EstimateID, long CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Estimate_AccountingCode_Insert");
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual int Estimate_AccountingCode_Select(long EstimateID, long CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Estimate_AccountingCode_Select");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			return 0;
		}

		public virtual DataTable estimate_booklet_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@QtyNumber", (object)QtyNumber) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_booklet_item_onQtyNumber_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_booklet_item_select(int CompanyID, long EstimateItemID)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_booklet_item_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_Calculation_select(int CompanyID, long EstimateItemID, long EstimateBNLBItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_Calculation_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateBNLBItemID", DbType.Int64, EstimateBNLBItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_click_charge_zone_2nd_calculation(int CompanyID, long EstimateCalculationID, decimal TotalSheets, string ZoneType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_click_charge_zone_2nd_calculation");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@TotalSheets", DbType.Decimal, TotalSheets);
			database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_click_charge_zone_insert(int CompanyID, long EstimateCalculationID, long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_click_charge_zone_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_click_charge_zone_range_check(int CompanyID, long EstimateCalculationID, decimal TotalSheets, string ZoneType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_click_charge_zone_range_check");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@TotalSheets", DbType.Decimal, TotalSheets);
			database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Estimate_Copy(int CompanyID, long EstimateID, string EstimateNumber, int UserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_copy_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateNumber", DbType.String, EstimateNumber);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long estimate_copy_all(int CompanyID, long ModuleID, long NewEstimateID, string pgType, string DirectJObOrInvoice, string Date, bool IsHandy, int newCustomer)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_estimate_copy_all");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@pgType", DbType.String, pgType);
			database.AddInParameter(storedProcCommand, "@DirectJObOrInvoice", DbType.String, DirectJObOrInvoice);
			database.AddInParameter(storedProcCommand, "@Date", DbType.String, Date);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddInParameter(storedProcCommand, "@IsNewCustomer", DbType.Int32, newCustomer);
			database.AddInParameter(storedProcCommand, "@JobPrefix", DbType.String, ConnectionClass.JobPrefix);
			database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
			database.AddOutParameter(storedProcCommand, "@InvoiceOrJobID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@InvoiceOrJobID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long Estimate_Copy_Estimate_Insert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_copy_estimate_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateID", DbType.Int64, Old_EstimateID);
			database.AddInParameter(storedProcCommand, "@DirectJObOrInvoice", DbType.String, DirectJObOrInvoice);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
			database.AddInParameter(storedProcCommand, "@Date", DbType.String, Date);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddInParameter(storedProcCommand, "@Pgtype", DbType.String, Pgtype);
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@EstimatePrefix", DbType.String, ConnectionClass.EstimatePrefix);
			database.AddOutParameter(storedProcCommand, "@New_EstimateID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstimateID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}
		public virtual long EstimateCopyEstimateInsert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID, DateTime Estimateartworkdate, DateTime Estimatedeliverydate, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProductionDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateCopyEstimateInsert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateID", DbType.Int64, Old_EstimateID);
			database.AddInParameter(storedProcCommand, "@DirectJObOrInvoice", DbType.String, DirectJObOrInvoice);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
			database.AddInParameter(storedProcCommand, "@Date", DbType.String, Date);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddInParameter(storedProcCommand, "@Pgtype", DbType.String, Pgtype);
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@EstimatePrefix", DbType.String, ConnectionClass.EstimatePrefix);
			database.AddInParameter(storedProcCommand, "@Estimateartworkdate", DbType.DateTime, Estimateartworkdate);
			database.AddInParameter(storedProcCommand, "@Estimatedeliverydate", DbType.DateTime, Estimatedeliverydate);
			database.AddInParameter(storedProcCommand, "@JobCompletionDate", DbType.DateTime, JobCompletionDate);
			database.AddInParameter(storedProcCommand, "@ProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@ApprovalDate", DbType.DateTime, ApprovalDate);
			database.AddInParameter(storedProcCommand, "@ProductionDate", DbType.DateTime, ProductionDate);
			database.AddOutParameter(storedProcCommand, "@New_EstimateID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstimateID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable estimate_delivery_quantity_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_delivery_quantity_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_deliverynote_ByJobID_selectall(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_DeliveryNote_QuickLinks_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_deliverynote_onitemid_selectall(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_deliverynote_onitemid_selectall");
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

		public virtual DataTable estimate_deliverynote_onitemid_selectIndividual(int CompanyID, long EstimateID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_deliverynote_onitemid_select_Induvidual");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_deliverynote_Select_ByDeleveryID(int CompanyID, long DeleveryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_DeliveryQuickLinks_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeleveryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_ESTID_JOBID_INVID_Select(long EstimateItemID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_ESTID_JOBID_INVID_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_EstimateID_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_EstimateID_select_ByInvoiceID");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_EstTotalPriceDetails_Update(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_EstTotalPriceDetails_Update");
			database.AddInParameter(storedProcCommand, "@CurrentEstimateItemID", DbType.Int64, EstimateItemID);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet estimate_for_litho_add_all(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_for_litho_add_all");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			return database.ExecuteDataSet(storedProcCommand);
		}

        public virtual DataSet estimate_for_Digital_add_all(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_for_Digital_add_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual long Estimate_Insert(int CompanyID, int UserID, int CustomerID, long AttentionID, string Greeting, string Company, long Address, string Header, string Footer, int SalesPerson, string EstimateTitle, string EstimateNumber, string OrderNumber, int StatusID, DateTime EstimateDate, int ValidFor, long DeliveryAddress, bool IsConvertedToJob, DateTime ModifiedDate, int ModifiedBy, long EstimateID, bool IsForInvoice, string AddressType, string DelAddressType, long CurrentEstNo, DateTime EstimatedArtwork, DateTime EstimatedDelivery, string PageType, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProdcnDate, long InvoiceAddressID, long DepartmentID, long CostCentreID, int estimatorid, string Comments, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_insert_new_stage1");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
			database.AddInParameter(storedProcCommand, "@AttentionID", DbType.Int64, AttentionID);
			database.AddInParameter(storedProcCommand, "@Greeting", DbType.String, Greeting);
			database.AddInParameter(storedProcCommand, "@Company", DbType.String, Company);
			database.AddInParameter(storedProcCommand, "@Address", DbType.Int64, Address);
			database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
			database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
			database.AddInParameter(storedProcCommand, "@SalesPerson", DbType.Int32, SalesPerson);
			database.AddInParameter(storedProcCommand, "@EstimateTitle", DbType.String, EstimateTitle);
			database.AddInParameter(storedProcCommand, "@EstimateNumber", DbType.String, EstimateNumber);
			database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@EstimateDate", DbType.DateTime, EstimateDate);
			database.AddInParameter(storedProcCommand, "@ValidFor", DbType.Int32, ValidFor);
			database.AddInParameter(storedProcCommand, "@DeliveryAddress", DbType.Int64, DeliveryAddress);
			database.AddInParameter(storedProcCommand, "@IsConvertedToJob", DbType.Boolean, IsConvertedToJob);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@IsForInvoice", DbType.Boolean, IsForInvoice);
			database.AddInParameter(storedProcCommand, "@AddressType", DbType.String, AddressType);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DelAddressType);
			database.AddInParameter(storedProcCommand, "@CurrentEstNo", DbType.Int64, CurrentEstNo);
			database.AddInParameter(storedProcCommand, "@EstimatedArtwork", DbType.DateTime, EstimatedArtwork);
			database.AddInParameter(storedProcCommand, "@EstimatedDelivery", DbType.DateTime, EstimatedDelivery);
			database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
			database.AddInParameter(storedProcCommand, "@EstProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@EstApprovalDate", DbType.DateTime, ApprovalDate);
			database.AddInParameter(storedProcCommand, "@EstProductionDate", DbType.DateTime, ProdcnDate);
			database.AddInParameter(storedProcCommand, "@EstCompletionDate", DbType.DateTime, JobCompletionDate);
			database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int64, InvoiceAddressID);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
			database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@EstimatorId", DbType.Int32, estimatorid);
			database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@InvoiceContactId", DbType.Int64, InvoiceContactId);
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual int estimate_iscompleted_select(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_iscompleted_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Estimate_Item_AccountCode_Insert(long EstimateItemID, int AccountCodeID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Item_AccountCode_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_item_detail_outwork_item_select(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_item_detail_outwork_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_item_detail_quantities_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_estimate_item_detail_quantities_select");
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

		public virtual void estimate_item_details_insert(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_details_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_item_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_details_select");
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

		public virtual DataTable estimate_item_details_selectall(int CompanyID, long EstimateItemID, string EstimateType)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateType", EstimateType) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_estimate_item_details_selectall", sqlParameterArray).Tables[0];
		}

		public virtual void estimate_item_details_update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_details_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@Qty1", DbType.Int32, Qty1);
			database.AddInParameter(storedProcCommand, "@Qty2", DbType.Int32, Qty2);
			database.AddInParameter(storedProcCommand, "@Qty3", DbType.Int32, Qty3);
			database.AddInParameter(storedProcCommand, "@Qty4", DbType.Int32, Qty4);
			database.AddInParameter(storedProcCommand, "@ReqPrePress", DbType.String, ReqPrePress);
			database.AddInParameter(storedProcCommand, "@ReqPress", DbType.String, ReqPress);
			database.AddInParameter(storedProcCommand, "@ReqPostPress", DbType.String, ReqPostPress);
			database.AddInParameter(storedProcCommand, "@ReqPriceCatalogue", DbType.String, ReqPriceCatalogue);
			database.AddInParameter(storedProcCommand, "@ReqOutwork", DbType.String, ReqOutwork);
			database.AddInParameter(storedProcCommand, "@ReqWarehouse", DbType.String, ReqWarehouse);
			database.AddInParameter(storedProcCommand, "@ReqAdmin", DbType.String, ReqAdmin);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Estimate_Item_ID_Select(int CompanyID, long EstimateID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimateitem_id_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet estimate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_info_select_by_qtynumber_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			storedProcCommand.CommandTimeout = int.MaxValue;
			return database.ExecuteDataSet(storedProcCommand);
		}

        public virtual DataSet estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType, long EstimateItemIDForRaisePO)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@EstimateItemIDForRaisePO", DbType.Int64, EstimateItemIDForRaisePO);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual long Estimate_Item_Insert(int CompanyID, long EstimateID, string EstimateType, bool IsParentItem, long ParentItemID, long ProductID = 0)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@IsParentItem", DbType.Boolean, IsParentItem);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
            database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual string estimate_item_quantity_fordelivery_select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, int QtyNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_quantity_fordelivery_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_item_select(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_item_select_ByModule(int CompanyID, long ModuleID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ApprovedOrderItem_Select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_item_select_reeng(int CompanyID, long EstimateID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_item_select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_summary_total(long ModuleID, string ModuleType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Summary");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}


		public virtual DataTable estimate_item_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_item_select_ByInvoiceID");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_item_select_reeng_ByJob(int CompanyID, long JobID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_item_select_ByJobID");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_item_title_update(int CompanyID, long EstimateItemID, string ItemTitle, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_title_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_item_total_price_details_select(int CompanyID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_item_total_price_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_item_total_price_details_update(long EstimateID, long EstimateItemID, long SectionID, string EstimateType, decimal TotalProfitMarginPercentage1, decimal TotalProfitMarginPercentage2, decimal TotalProfitMarginPercentage3, decimal TotalProfitMarginPercentage4, decimal TotalProfitMarginPrice1, decimal TotalProfitMarginPrice2, decimal TotalProfitMarginPrice3, decimal TotalProfitMarginPrice4, decimal TotalSubTotal1, decimal TotalSubTotal2, decimal TotalSubTotal3, decimal TotalSubTotal4, int TotalTaxID1, int TotalTaxID2, int TotalTaxID3, int TotalTaxID4, decimal TotalTaxPercentage1, decimal TotalTaxPercentage2, decimal TotalTaxPercentage3, decimal TotalTaxPercentage4, decimal TotalTaxPrice1, decimal TotalTaxPrice2, decimal TotalTaxPrice3, decimal TotalTaxPrice4, decimal TotalSellingPrice1, decimal TotalSellingPrice2, decimal TotalSellingPrice3, decimal TotalSellingPrice4, decimal TotalGrossProfitPercentage1, decimal TotalGrossProfitPercentage2, decimal TotalGrossProfitPercentage3, decimal TotalGrossProfitPercentage4, decimal TotalGrossProfitPrice1, decimal TotalGrossProfitPrice2, decimal TotalGrossProfitPrice3, decimal TotalGrossProfitPrice4, bool IsSubTotalLocked, decimal SellingPricePerSQM1, decimal SellingPricePerSQM2, decimal SellingPricePerSQM3, decimal SellingPricePerSQM4, decimal SubTotalUnitPrice1, decimal SubTotalUnitPrice2, decimal SubTotalUnitPrice3, decimal SubTotalUnitPrice4)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Estimate_Item_Total_Price_Details_Update");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SectionID", DbType.Int64, SectionID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPercentage1", DbType.Decimal, TotalProfitMarginPercentage1);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPercentage2", DbType.Decimal, TotalProfitMarginPercentage2);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPercentage3", DbType.Decimal, TotalProfitMarginPercentage3);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPercentage4", DbType.Decimal, TotalProfitMarginPercentage4);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPrice1", DbType.Decimal, TotalProfitMarginPrice1);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPrice2", DbType.Decimal, TotalProfitMarginPrice2);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPrice3", DbType.Decimal, TotalProfitMarginPrice3);
			database.AddInParameter(storedProcCommand, "@TotalProfitMarginPrice4", DbType.Decimal, TotalProfitMarginPrice4);
			database.AddInParameter(storedProcCommand, "@TotalSubTotal1", DbType.Decimal, TotalSubTotal1);
			database.AddInParameter(storedProcCommand, "@TotalSubTotal2", DbType.Decimal, TotalSubTotal2);
			database.AddInParameter(storedProcCommand, "@TotalSubTotal3", DbType.Decimal, TotalSubTotal3);
			database.AddInParameter(storedProcCommand, "@TotalSubTotal4", DbType.Decimal, TotalSubTotal4);
			database.AddInParameter(storedProcCommand, "@TotalTaxID1", DbType.Int32, TotalTaxID1);
			database.AddInParameter(storedProcCommand, "@TotalTaxID2", DbType.Int32, TotalTaxID2);
			database.AddInParameter(storedProcCommand, "@TotalTaxID3", DbType.Int32, TotalTaxID3);
			database.AddInParameter(storedProcCommand, "@TotalTaxID4", DbType.Int32, TotalTaxID4);
			database.AddInParameter(storedProcCommand, "@TotalTaxPercentage1", DbType.Decimal, TotalTaxPercentage1);
			database.AddInParameter(storedProcCommand, "@TotalTaxPercentage2", DbType.Decimal, TotalTaxPercentage2);
			database.AddInParameter(storedProcCommand, "@TotalTaxPercentage3", DbType.Decimal, TotalTaxPercentage3);
			database.AddInParameter(storedProcCommand, "@TotalTaxPercentage4", DbType.Decimal, TotalTaxPercentage4);
			database.AddInParameter(storedProcCommand, "@TotalTaxPrice1", DbType.Decimal, TotalTaxPrice1);
			database.AddInParameter(storedProcCommand, "@TotalTaxPrice2", DbType.Decimal, TotalTaxPrice2);
			database.AddInParameter(storedProcCommand, "@TotalTaxPrice3", DbType.Decimal, TotalTaxPrice3);
			database.AddInParameter(storedProcCommand, "@TotalTaxPrice4", DbType.Decimal, TotalTaxPrice4);
			database.AddInParameter(storedProcCommand, "@TotalSellingPrice1", DbType.Decimal, TotalSellingPrice1);
			database.AddInParameter(storedProcCommand, "@TotalSellingPrice2", DbType.Decimal, TotalSellingPrice2);
			database.AddInParameter(storedProcCommand, "@TotalSellingPrice3", DbType.Decimal, TotalSellingPrice3);
			database.AddInParameter(storedProcCommand, "@TotalSellingPrice4", DbType.Decimal, TotalSellingPrice4);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPercentage1", DbType.Decimal, TotalGrossProfitPercentage1);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPercentage2", DbType.Decimal, TotalGrossProfitPercentage2);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPercentage3", DbType.Decimal, TotalGrossProfitPercentage3);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPercentage4", DbType.Decimal, TotalGrossProfitPercentage4);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPrice1", DbType.Decimal, TotalGrossProfitPrice1);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPrice2", DbType.Decimal, TotalGrossProfitPrice2);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPrice3", DbType.Decimal, TotalGrossProfitPrice3);
			database.AddInParameter(storedProcCommand, "@TotalGrossProfitPrice4", DbType.Decimal, TotalGrossProfitPrice4);
			database.AddInParameter(storedProcCommand, "@IsSubTotalLocked", DbType.Decimal, IsSubTotalLocked);

			database.AddInParameter(storedProcCommand, "@SellingPricePerSQM1", DbType.Decimal, SellingPricePerSQM1);
			database.AddInParameter(storedProcCommand, "@SellingPricePerSQM2", DbType.Decimal, SellingPricePerSQM2);
			database.AddInParameter(storedProcCommand, "@SellingPricePerSQM3", DbType.Decimal, SellingPricePerSQM3);
			database.AddInParameter(storedProcCommand, "@SellingPricePerSQM4", DbType.Decimal, SellingPricePerSQM4);

            database.AddInParameter(storedProcCommand, "@SubTotalUnitPrice1", DbType.Decimal, SubTotalUnitPrice1);
            database.AddInParameter(storedProcCommand, "@SubTotalUnitPrice2", DbType.Decimal, SubTotalUnitPrice2);
            database.AddInParameter(storedProcCommand, "@SubTotalUnitPrice3", DbType.Decimal, SubTotalUnitPrice3);
            database.AddInParameter(storedProcCommand, "@SubTotalUnitPrice4", DbType.Decimal, SubTotalUnitPrice4);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_itemandsubitem_select(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_itemandsubitem_select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int Estimate_Items_Count_Select(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_items_count_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void Estimate_Items_Delete(int CompanyID, long EstimateItemID, string Estimatetype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PCR_Estimate_Items_Delete]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, Estimatetype);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Estimate_Items_Quantity_Select(int CompanyID, int EstimateItemID, string EstType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate__item__quantity_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, EstType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_Items_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_ItemRFQ_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable Estimate_ProofItems_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_ProofItemRFQ_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        // create delivery note
        public virtual DataTable Estimate_ByEstimateItemId_Select(int CompanyID, long EstimateItemID, string ModuleType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Estimate_ByEstimateItemId_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

		public virtual DataTable Estimate_Items_Select(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate__items_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet estimate_itemtitle_select(int CompanyID, long EstimateItemID, string ItemType, int qtynumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_itemtitle_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			database.AddInParameter(storedProcCommand, "@QuantityNumber", DbType.String, qtynumber);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual void estimate_itemtitle_update(long EstimateID, string EstimateTitle)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_itemtitle_update");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateTitle", DbType.String, EstimateTitle);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_large_item_ink(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_large_item_ink");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_large_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_large_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_largeitemMetarals_select(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_largeitemMaterials_select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_litho_booklet_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_lithobooklet_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_Litho_ink_select(int CompanyID, long PressID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_Litho_ink_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_litho_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_litho_ink_select_inkcost_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
			database.AddInParameter(storedProcCommand, "@CalType", DbType.String, CalType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long estimate_litho_NCR_item_insert(int CompanyID, int EstimateLithoNcrItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetUpSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, long GuillotineID, int CreatedBy, int ModifiedBy, DateTime CreatedDate, bool IsDeleted, string ItemTitle, string ItemDescription, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, string SectionReference, decimal NcrPartsPerSet, decimal NcrSetsPerPad, string NcrImageType, string NcrPadFormat, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, string Ncrcommonfrom, bool Perfecting, decimal ManualValue,bool sheetwork)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_estimate_litho_NCRPadItem_insert]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNcrItemID", DbType.Int64, EstimateLithoNcrItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Decimal, SetUpSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@sidesprinted", DbType.String, sidesprinted);
			database.AddInParameter(storedProcCommand, "@side1Color", DbType.String, side1Color);
			database.AddInParameter(storedProcCommand, "@side2Color", DbType.String, side2Color);
			database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, PlateID);
			database.AddInParameter(storedProcCommand, "@Noofplates", DbType.String, Noofplates);
			database.AddInParameter(storedProcCommand, "@NoofMakeReady", DbType.String, NoofMakeReady);
			database.AddInParameter(storedProcCommand, "@NoofWashup", DbType.String, NoofWashup);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
			database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@WorknTurn", DbType.Boolean, WorknTurn);
			database.AddInParameter(storedProcCommand, "@WorknTumble", DbType.Boolean, WorknTumble);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int32, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			database.AddInParameter(storedProcCommand, "@SectionReference", DbType.String, SectionReference);
			database.AddInParameter(storedProcCommand, "@NcrPartsPerSet", DbType.Decimal, NcrPartsPerSet);
			database.AddInParameter(storedProcCommand, "@NcrSetsPerPad", DbType.Decimal, NcrSetsPerPad);
			database.AddInParameter(storedProcCommand, "@NcrImageType", DbType.String, NcrImageType);
			database.AddInParameter(storedProcCommand, "@NcrPadFormat", DbType.String, NcrPadFormat);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, LandscapeValue);
			database.AddInParameter(storedProcCommand, "@NcrCommonFrom", DbType.String, Ncrcommonfrom);
			database.AddInParameter(storedProcCommand, "@CheckPerfecting", DbType.Boolean, Perfecting);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, ManualValue);
			database.AddInParameter(storedProcCommand, "@sheetwork", DbType.Boolean, sheetwork);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

        public virtual DataTable estimate_digital_ncr_item_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_digitalncr_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_litho_ncr_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_lithoncr_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long estimate_litho_pad_item_insert(int CompanyID, long EstimateLithoPadItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, decimal LeavesPerPad, string SidesPrinted, string Side1Color, string Side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue, bool worksheet)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_litho_pad_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoPadItemID", DbType.Int64, EstimateLithoPadItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@LeavesPerPad", DbType.Decimal, LeavesPerPad);
			database.AddInParameter(storedProcCommand, "@Sidesprinted", DbType.String, SidesPrinted);
			database.AddInParameter(storedProcCommand, "@Side1Color", DbType.String, Side1Color);
			database.AddInParameter(storedProcCommand, "@Side2Color", DbType.String, Side2Color);
			database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, PlateID);
			database.AddInParameter(storedProcCommand, "@Noofplates", DbType.String, Noofplates);
			database.AddInParameter(storedProcCommand, "@NoofMakeReady", DbType.String, NoofMakeReady);
			database.AddInParameter(storedProcCommand, "@NoofWashup", DbType.String, NoofWashup);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@WorknTurn", DbType.Boolean, WorknTurn);
			database.AddInParameter(storedProcCommand, "@WorknTumble", DbType.Boolean, WorknTumble);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			database.AddInParameter(storedProcCommand, "@perfecting", DbType.Boolean, Perfecting);
			database.AddInParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, ManualValue);
			database.AddInParameter(storedProcCommand, "@worksheet", DbType.Boolean, worksheet);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable estimate_litho_pad_item_select(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_litho_pad_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_litho_pad_item_select_reeng(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_litho_pad_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_litho_plate_select_popup(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_litho_plate_select_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_Litho_Press_Select(int CompanyID, long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Litho_Press_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable Estimate_Digital_Press_Select_byPressID(int CompanyID, long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Digital_Press_Select_byPress");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_litho_single_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_litho_estimate_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithobooklet_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithoBooklet_ink_select_inkcost_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoBookletItemID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
			database.AddInParameter(storedProcCommand, "@CalType", DbType.String, CalType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithobooklet_plateswashupmakeready_popup(int CompanyID, long EstimateItemID, long EstimateLithoBookletItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithobooklet_plateswashupmakeready_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoBookletItemID", DbType.Int64, EstimateLithoBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithoNCR_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithoNCR_ink_select_inkcost_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
			database.AddInParameter(storedProcCommand, "@CalType", DbType.String, CalType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithoNCR_select_popup(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithoNCR_select_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNcrItemID", DbType.Int64, EstimateLithoNcrItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithoPad_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithoPad_ink_select_inkcost_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
			database.AddInParameter(storedProcCommand, "@CalType", DbType.String, CalType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_lithoPad_plate_select_popup(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithoPad_plate_select_popup");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_lithopress_delete_ink(int CompanyID, long PressID, long EstimateItemID, string EstType, long EstimateLithoItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithopress_delete_ink");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstType", DbType.String, EstType);
			database.AddInParameter(storedProcCommand, "@EstimateLithoItemID", DbType.Int64, EstimateLithoItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual IDataReader estimate_lithopress_select_ink_count(int CompanyID, long LithoPressID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithopress_select_ink_count");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@side", DbType.String, side);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemID", DbType.Int64, EstimateLithoNCRItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithobookletItemID", DbType.Int64, EstimateLithobookletItemID);
			return database.ExecuteReader(storedProcCommand);
		}

		public virtual DataTable estimate_lithopress_select_ink_name_item_desc(int CompanyID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string esttype)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_estimate_lithopress_select_ink_name_item_desc]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@side", DbType.String, side);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemID", DbType.Int64, EstimateLithoNCRItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithobookletItemID", DbType.Int64, EstimateLithobookletItemID);
			database.AddInParameter(storedProcCommand, "@esttype", DbType.String, esttype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual IDataReader estimate_lithopress_select_ink_rownum(int CompanyID, long LithoPressID, int rownum, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string sidenumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_lithopress_select_ink_rownum");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@rownum", DbType.Int32, rownum);
			database.AddInParameter(storedProcCommand, "@side", DbType.String, side);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemID", DbType.Int64, EstimateLithoNCRItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithobookletItemID", DbType.Int64, EstimateLithobookletItemID);
			database.AddInParameter(storedProcCommand, "@sidenumber", DbType.String, sidenumber);
			return database.ExecuteReader(storedProcCommand);
		}

		public virtual void estimate_number_update(int CompanyID, long EstimateID, bool IsHandy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_number_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_othercost_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_othercost_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_othercost_press_details_select(long CompanyID, long EstimateItemID, string EstimateType, long BookletSectionID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_press_details_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@BookletSectionID", DbType.Int64, BookletSectionID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_othercost_ProfitTax_select(long EstimateItemID, long EstOthercostID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_ProfitTax_select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstOthercostID", DbType.Int64, EstOthercostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string estimate_othercost_select_new(int CompanyID, string EstimateType, long TypeID, string MainOrSubItem)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@MainOrSubItem", DbType.String, MainOrSubItem);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_othercost_subitem_costview(int CompanyID, long EstOtherCostID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_subitem_costview");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_othercost_subitem_select(int CompanyID, long TypeID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_subitem_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_othercost_typeid_update(int CompanyID, long EstimateItemID, string EstimateType, long TypeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_typeid_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long estimate_othercost_variableqty_insert(int CompanyID, long EstOtherCostVariableID, long EstOtherCostID, long EstQuantityID, decimal HoursOrQty, decimal Cost, string EstType, string FormulaWithActual, int Quantity, int qtynumber, string FinalFormulaTag)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_variableqty_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOtherCostVariableID", DbType.Int64, EstOtherCostVariableID);
			database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
			database.AddInParameter(storedProcCommand, "@EstQuantityID", DbType.Int64, EstQuantityID);
			database.AddInParameter(storedProcCommand, "@HoursOrQty", DbType.Decimal, HoursOrQty);
			database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Cost);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstType);
			database.AddInParameter(storedProcCommand, "@FormulaWithActual", DbType.String, FormulaWithActual);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
			database.AddInParameter(storedProcCommand, "@Quantitynumber", DbType.Int32, qtynumber);
			database.AddInParameter(storedProcCommand, "@FinalFormulaTag", DbType.String, FinalFormulaTag);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			object obj = database.ExecuteScalar(storedProcCommand);
			return (obj == null ? (long)0 : long.Parse(obj.ToString()));
		}

		public virtual DataSet estimate_Othercostitem_info(int CompanyID, long EstimateID, int QtyNumber, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_Othercostitem_info");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual void Estimate_OtherWare_MainItems_Pricing_Update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, decimal CostPrice1ExMarkup, decimal TotalMarkupPrice1, int QtyNumber, long EstOutworkSupplierID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Estimate_OtherWare_MainItems_Pricing_Update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@CostPrice1ExMarkup", DbType.Decimal, CostPrice1ExMarkup);
			database.AddInParameter(storedProcCommand, "@TotalMarkupPrice1", DbType.Decimal, TotalMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.AddInParameter(storedProcCommand, "@EstOutworkSupplierID", DbType.Int64, EstOutworkSupplierID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Estimate_Outwork_Insert(int CompanyID, string Query)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_outwork_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
			database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_outwork_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_outwork_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_pad_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@QtyNumber", (object)QtyNumber) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_pad_item_onQtyNumber_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_pad_item_select(int CompanyID, long EstimateItemID)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_pad_item_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_press_select(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_press_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable estimate_Digital_press_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_Digital_press_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_price_catalogue_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_price_catalogue_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string estimate_printbroker_itemdescription_select(int CompanyID, long EstimateItemID, string EstimateType, string SelectType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_itemdescription_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@SelectType", DbType.String, SelectType);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_printbroker_select(int CompanyID, long EstOutworkID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_printbroker_select_new(int CompanyID, long EstOutworkID, int rownumber)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
			database.AddInParameter(storedProcCommand, "@rownumber", DbType.Int32, rownumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_printbroker_subitem_select(int CompanyID, long EstOutworkID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_subitem_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_printbroker_suppliers_count(int CompanyID, string Estype, long TypeID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_suppliers_count_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Esttype", DbType.String, Estype);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_qty_onQtyNumber_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID, int QtyNumber)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@QtyNumber", (object)QtyNumber) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_estimate_qty_onQtyNumber_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_qty_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_qty_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_qty_select_for_booklet(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_qty_select_for_booklet");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_quantity_forcostview_select(int CompanyID, long EstimateItemID, string EstimateType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_quantity_forcostview_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_quantity_select_new(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_estimate_qty_select_new", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_quick_quote_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_quickquote_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Estimate_quickquote_insert(EstimatesItem item, bool IsHandy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_quickquote_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, item.EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Quantity1", DbType.Int32, item.Quantity1);
			database.AddInParameter(storedProcCommand, "@Quantity2", DbType.Int32, item.Quantity2);
			database.AddInParameter(storedProcCommand, "@Quantity3", DbType.Int32, item.Quantity3);
			database.AddInParameter(storedProcCommand, "@Quantity4", DbType.Int32, item.Quantity4);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@Profitmargin", DbType.Decimal, item.Profitmargin);
			database.AddInParameter(storedProcCommand, "@Subtotal1", DbType.Decimal, item.Subtotal1);
			database.AddInParameter(storedProcCommand, "@Subtotal2", DbType.Decimal, item.Subtotal2);
			database.AddInParameter(storedProcCommand, "@Subtotal3", DbType.Decimal, item.Subtotal3);
			database.AddInParameter(storedProcCommand, "@Subtotal4", DbType.Decimal, item.Subtotal4);
			database.AddInParameter(storedProcCommand, "@CostPrice1", DbType.Decimal, item.CostPrice1);
			database.AddInParameter(storedProcCommand, "@CostPrice2", DbType.Decimal, item.CostPrice2);
			database.AddInParameter(storedProcCommand, "@CostPrice3", DbType.Decimal, item.CostPrice3);
			database.AddInParameter(storedProcCommand, "@CostPrice4", DbType.Decimal, item.CostPrice4);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, item.Tax);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
			database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, item.SellingPrice);
			database.AddInParameter(storedProcCommand, "@QuickQuoteID", DbType.Int64, item.QuickQuoteID);
			database.AddInParameter(storedProcCommand, "@Iscompleted", DbType.Int32, item.Iscompleted);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, item.ModuleType);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_RaisePoOrders_Selectitems(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_RaisePoOrders_Selectitems");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_select_litho_details_all(int CompanyID, int LithoPressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_litho_details_all");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int32, LithoPressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_select_litho_ink_count(int CompanyID, int LithoPressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_litho_ink_count");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int32, LithoPressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_select_paper_size(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_paper_size");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_select_summary(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_summary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            //storedProcCommand.CommandTimeout=600;

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
		public virtual DataTable order_select_summary(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_order_select_summary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			//storedProcCommand.CommandTimeout=600;

			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_select_summary_new(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_summary_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
        public virtual DataTable PC_Proof_select_summary_new(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Proof_select_summary_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable estimate_select_summary_PerItem(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_summary_PerItem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable proof_select_summary_PerItem(int CompanyID, long ProofItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_proof_select_summary_PerItem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_single_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@QtyNumber", (object)QtyNumber) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_single_item_onQtyNumber_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable estimate_single_item_select(int CompanyID, long EstimateItemID)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			return SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_single_item_select", sqlParameterArray).Tables[0];
		}

		public virtual DataTable Estimate_Single_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_single_item_select_by_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_SingleItem_Subitem_By_EstimateItemID(int CompanyID, long EstimateItemID, string esttype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_selectsubitem_singleitem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimationtype", DbType.String, esttype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_speed_weight_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_speedweight_select(int CompanyID, long EstimateCalculationID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_speedweight_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_sub_item_delete(string EstimateType, long EstimateItemID, long ItemTypeID)
		{
			long num = (long)0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_sub_item_delete");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemTypeID", DbType.Int64, ItemTypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.String, num);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimate_subitem_delete(string EstimateType, long EstimateItemID, long EstimateSPLBWOCU)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_subitem_delete");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateSPLBWOCU", DbType.Int64, EstimateSPLBWOCU);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimate_subitem_delete_FromSummary(string EstimateType, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_subitem_delete_FromSummary");
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimate_subitem_select(long EstimateID, long ParentItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_subitem_select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_subitem_select_New(long ParentItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimate_subitem_select_New");
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Estimate_Subitem_showonItemdesc(int CompanyID, long EstimateItemID, string Estimationtype)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Subitem_showonItemdesc");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, Estimationtype);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable Estimate_Summary_Calculation_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID, long EstBookletSectionID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_calculation_select_by_estimateitem_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Estimate_Summary_EstimateValues_Update(int CompanyID, long EstimateID, decimal EstimateValue, decimal EstimateSubTotal, int EstimateTotalQuantity)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_estimate_values_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateValue", DbType.Decimal, EstimateValue);
			database.AddInParameter(storedProcCommand, "@EstimateSubTotal", DbType.Decimal, EstimateSubTotal);
			database.AddInParameter(storedProcCommand, "@EstimateTotalQuantity", DbType.Int32, EstimateTotalQuantity);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual decimal Estimate_Summary_Guillotine_Standard_Table(int CompanyID, decimal Printlayout, string IsGutter)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_guilllotine_standard_cut");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Printlayout", DbType.Decimal, Printlayout);
			database.AddInParameter(storedProcCommand, "@IsGutter", DbType.String, IsGutter);
			object obj = database.ExecuteScalar(storedProcCommand);
			return (obj == null ? new decimal(0) : decimal.Parse(obj.ToString()));
		}

		public virtual string Estimate_Summary_Item_Warehouse_Cost(int CompanyID, long TypeID, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_warehouse_cost_ForSubitem");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_summary_items_othercost_select_new(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_othercost_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_Summary_Items_select_by_EstimateID(int CompanyID, long EstimateID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_Summary_Large_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_large_item_by_estimateitem_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_summary_othercost_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_othercost_by_estimateitem_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_summary_outwork_taxprofitmargin_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_taxprofitmargin_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Estimate_Summary_Pad_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_pad_item_by_estimateitem_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Estimate_Warehouse_Insert(int CompanyID, string Query, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_warehouse_insert_New");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.String, EstimateItemID);
			database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable estimate_warehouse_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_warehouse_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimate_zone_calculation_1(int CompanyID, long EstimateCalculationID, int TotalSheets, string ZoneType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_zone_calculation_1");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@TotalSheets", DbType.Int32, TotalSheets);
			database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimate_zone_markup_update(int CompanyID, long EstimateCalculationID, decimal Markup)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_zone_markup_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable EstimateHistory(long SupplierID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_EstimateHistory");
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, SupplierID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void EstimateItem_Archive(int CompanyID, long EstimateItemID, string ModuleType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItem_Archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			database.ExecuteNonQuery(storedProcCommand);
		}
		public virtual void ProofItem_Archive(int CompanyID, long ProofItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofItem_Archive");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}
		public virtual void EstimateItem_Delete(int CompanyID, long EstimateItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItem_Delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
			database.AddInParameter(storedProcCommand, "@KeepEstimateJobLive", DbType.Boolean, Keep_EstimateJOB_LIVE);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
			database.ExecuteNonQuery(storedProcCommand);
		}
		public virtual void ProofItem_Delete(int CompanyID, long ProofItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofItem_Delete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
			database.AddInParameter(storedProcCommand, "@KeepEstimateJobLive", DbType.Boolean, Keep_EstimateJOB_LIVE);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
			database.ExecuteNonQuery(storedProcCommand);
		}
		public virtual void EstimateItem_UnArchive(int CompanyID, long EstimateItemID, string ModuleType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_EstimateItem_UnArchive]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable EstimateitemIDList_PerEstID(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_EstimateItemIDList");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable EstimateitemIDList_PerEstItemID(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_MainSubOutWorkItemId_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estimateitemselect_reeng(int CompanyID, long EstimateItemID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimateitem_select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long EstimateItemsOnCheck_Status_Update(int CompanyID, string EstimateItemIDs, int StatusID, string Module)
		{
			long num = (long)0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItemsOnCheck_Status_Update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemIDS", DbType.String, EstimateItemIDs);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int32, num);
			database.AddOutParameter(storedProcCommand, "@ReturnMainStatusID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnMainStatusID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual void estimatenumberupdateandiscomplete(int CompanyID, long EstimateID, long EstimateItemID, bool IsHandy)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimatenumberupdateandiscomplete");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
			database.AddInParameter(storedProcCommand, "@EstimatePrefix", DbType.String, ConnectionClass.EstimatePrefix);
			database.AddInParameter(storedProcCommand, "@JobPrefix", DbType.String, ConnectionClass.JobPrefix);
			database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet estimatePlate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimatePlate_item_info_select_by_qtynumber_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual void estimates_litho_markup_calculation_insert(int CompanyID, long EstimateCalculationID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_litho_markup_calculation_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.ExecuteNonQuery(storedProcCommand);
		}


		public virtual void estimates_litho_markup_calculation_insertnew(int CompanyID, long EstimateCalculationID,long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_litho_markup_calculation_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimates_litho_markup_calculation_update(int CompanyID, long EstimateItemID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_litho_markup_calculation_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@EstCalType", DbType.String, EstCalType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable estimates_litho_press_matrix_select_By_ID(int CompanyID, long EstimateCalculationID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_litho_press_matrix_select_By_ID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void estimates_markup_calculation_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module, decimal CostExMarkup_Actual1, decimal CostExMarkup_Actual2, decimal CostExMarkup_Actual3, decimal CostExMarkup_Actual4)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_markup_calculation_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@EstCalType", DbType.String, EstCalType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@Markup2", DbType.Decimal, Markup2);
			database.AddInParameter(storedProcCommand, "@Markup3", DbType.Decimal, Markup3);
			database.AddInParameter(storedProcCommand, "@Markup4", DbType.Decimal, Markup4);
			database.AddInParameter(storedProcCommand, "@MarkupPrice1", DbType.Decimal, MarkupPrice1);
			database.AddInParameter(storedProcCommand, "@MarkupPrice2", DbType.Decimal, MarkupPrice2);
			database.AddInParameter(storedProcCommand, "@MarkupPrice3", DbType.Decimal, MarkupPrice3);
			database.AddInParameter(storedProcCommand, "@MarkupPrice4", DbType.Decimal, MarkupPrice4);
			database.AddInParameter(storedProcCommand, "@CostExMarkup1", DbType.Decimal, CostExMarkup1);
			database.AddInParameter(storedProcCommand, "@CostExMarkup2", DbType.Decimal, CostExMarkup2);
			database.AddInParameter(storedProcCommand, "@CostExMarkup3", DbType.Decimal, CostExMarkup3);
			database.AddInParameter(storedProcCommand, "@CostExMarkup4", DbType.Decimal, CostExMarkup4);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@CostExMarkup_Actual1", DbType.Decimal, CostExMarkup_Actual1);
			database.AddInParameter(storedProcCommand, "@CostExMarkup_Actual2", DbType.Decimal, CostExMarkup_Actual2);
			database.AddInParameter(storedProcCommand, "@CostExMarkup_Actual3", DbType.Decimal, CostExMarkup_Actual3);
			database.AddInParameter(storedProcCommand, "@CostExMarkup_Actual4", DbType.Decimal, CostExMarkup_Actual4);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimates_markup_calculation_update_ForPressZone(int CompanyID, long EstimateCalculationID, long TypeID, string EstimateType, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal PressMarkupPrice1, decimal PressMarkupPrice2, decimal PressMarkupPrice3, decimal PressMarkupPrice4, string Module, decimal PressCostExMarkup1, decimal PressCostExMarkup2, decimal PressCostExMarkup3, decimal PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimates_markup_calculation_update_ForPressZone");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPercentage1", DbType.Decimal, Zone_Side1_PressMarkupPercentage1);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPercentage2", DbType.Decimal, Zone_Side1_PressMarkupPercentage2);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPercentage3", DbType.Decimal, Zone_Side1_PressMarkupPercentage3);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPercentage4", DbType.Decimal, Zone_Side1_PressMarkupPercentage4);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPercentage1", DbType.Decimal, Zone_Side2_PressMarkupPercentage1);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPercentage2", DbType.Decimal, Zone_Side2_PressMarkupPercentage2);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPercentage3", DbType.Decimal, Zone_Side2_PressMarkupPercentage3);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPercentage4", DbType.Decimal, Zone_Side2_PressMarkupPercentage4);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPrice1", DbType.Decimal, Zone_Side1_PressMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPrice2", DbType.Decimal, Zone_Side1_PressMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPrice3", DbType.Decimal, Zone_Side1_PressMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@Zone_Side1_PressMarkupPrice4", DbType.Decimal, Zone_Side1_PressMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPrice1", DbType.Decimal, Zone_Side2_PressMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPrice2", DbType.Decimal, Zone_Side2_PressMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPrice3", DbType.Decimal, Zone_Side2_PressMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@Zone_Side2_PressMarkupPrice4", DbType.Decimal, Zone_Side2_PressMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@PressMarkupPrice1", DbType.Decimal, PressMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@PressMarkupPrice2", DbType.Decimal, PressMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@PressMarkupPrice3", DbType.Decimal, PressMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@PressMarkupPrice4", DbType.Decimal, PressMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup1", DbType.Decimal, PressCostExMarkup1);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup2", DbType.Decimal, PressCostExMarkup2);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup3", DbType.Decimal, PressCostExMarkup3);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup4", DbType.Decimal, PressCostExMarkup4);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup_Actual1", DbType.Decimal, PressCostExMarkup_Actual1);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup_Actual2", DbType.Decimal, PressCostExMarkup_Actual2);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup_Actual3", DbType.Decimal, PressCostExMarkup_Actual3);
			database.AddInParameter(storedProcCommand, "@PressCostExMarkup_Actual4", DbType.Decimal, PressCostExMarkup_Actual4);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimates_Materialmarkup_calculation_update(int CompanyID, long EstimateCalculationID, string EstimateType, decimal Markup1, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_MaterialsMarkup_calculation_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstLargeItemCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@Markup1", DbType.Decimal, Markup1);
			database.AddInParameter(storedProcCommand, "@Markup2", DbType.Decimal, Markup2);
			database.AddInParameter(storedProcCommand, "@Markup3", DbType.Decimal, Markup3);
			database.AddInParameter(storedProcCommand, "@Markup4", DbType.Decimal, Markup4);
			database.AddInParameter(storedProcCommand, "@MarkupPrice1", DbType.Decimal, MarkupPrice1);
			database.AddInParameter(storedProcCommand, "@MarkupPrice2", DbType.Decimal, MarkupPrice2);
			database.AddInParameter(storedProcCommand, "@MarkupPrice3", DbType.Decimal, MarkupPrice3);
			database.AddInParameter(storedProcCommand, "@MarkupPrice4", DbType.Decimal, MarkupPrice4);
			database.AddInParameter(storedProcCommand, "@CostExMarkup1", DbType.Decimal, CostExMarkup1);
			database.AddInParameter(storedProcCommand, "@CostExMarkup2", DbType.Decimal, CostExMarkup2);
			database.AddInParameter(storedProcCommand, "@CostExMarkup3", DbType.Decimal, CostExMarkup3);
			database.AddInParameter(storedProcCommand, "@CostExMarkup4", DbType.Decimal, CostExMarkup4);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual string estimates_outworkdescription_printemail_select(int CompanyID, long EstOutworkID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_outworkdescription_printemail_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual string estimates_quantity_select(int CompanyID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_quantity_select_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual void estimates_zonemarkup_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, string ZoneType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_estimates_zonemarkup_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@EstCalType", DbType.String, EstCalType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void estimateslitho_popup_ink_insert(int CompanyID, long estimateitemid, long inkid, decimal coverage, long PressID, string Side, long LithoItemID, string EstimateType, string sidenumber, string SectionName, decimal InkCostExMarkup1, decimal InkCostExMarkup2, decimal InkCostExMarkup3, decimal InkCostExMarkup4, decimal InkMarkup1, decimal InkMarkup2, decimal InkMarkup3, decimal InkMarkup4, decimal InkMarkupPrice1, decimal InkMarkupPrice2, decimal InkMarkupPrice3, decimal InkMarkupPrice4, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual1, decimal InkCostExMarkup_Actual2, decimal InkCostExMarkup_Actual3, decimal InkCostExMarkup_Actual4)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimateslitho_popup_ink_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@estimateitemid", DbType.Int64, estimateitemid);
			database.AddInParameter(storedProcCommand, "@InkID", DbType.Int64, inkid);
			database.AddInParameter(storedProcCommand, "@coverage", DbType.Decimal, coverage);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@Side", DbType.String, Side);
			database.AddInParameter(storedProcCommand, "@LithoItemID", DbType.Int64, LithoItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@sidenumber", DbType.String, sidenumber);
			database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup1", DbType.Decimal, InkCostExMarkup1);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup2", DbType.Decimal, InkCostExMarkup2);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup3", DbType.Decimal, InkCostExMarkup3);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup4", DbType.Decimal, InkCostExMarkup4);
			database.AddInParameter(storedProcCommand, "@InkMarkup1", DbType.Decimal, InkMarkup1);
			database.AddInParameter(storedProcCommand, "@InkMarkup2", DbType.Decimal, InkMarkup2);
			database.AddInParameter(storedProcCommand, "@InkMarkup3", DbType.Decimal, InkMarkup3);
			database.AddInParameter(storedProcCommand, "@InkMarkup4", DbType.Decimal, InkMarkup4);
			database.AddInParameter(storedProcCommand, "@InkMarkupPrice1", DbType.Decimal, InkMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@InkMarkupPrice2", DbType.Decimal, InkMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@InkMarkupPrice3", DbType.Decimal, InkMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@InkMarkupPrice4", DbType.Decimal, InkMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@InkSetupCharge", DbType.Decimal, InkSetupCharge);
			database.AddInParameter(storedProcCommand, "@InkMinimumCharge", DbType.Decimal, InkMinimumCharge);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup_Actual1", DbType.Decimal, InkCostExMarkup_Actual1);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup_Actual2", DbType.Decimal, InkCostExMarkup_Actual2);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup_Actual3 ", DbType.Decimal, InkCostExMarkup_Actual3);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup_Actual4", DbType.Decimal, InkCostExMarkup_Actual4);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public DataTable EstimatItem_Details_Select(int CompanyID, long EstimateID, string PageType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_EstimatItem_Details_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, PageType);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable estitem_select_ToConvertProductCatalogue(int CompanyID, long EstimateID, long PrarentItemID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estitem_select_ToConvertProductCatalogue");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, PrarentItemID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable EstPriceCatAddOptionDetailsSelect(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstPriceCatAddOptionDetailsSelect");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Get_Details_EstimateItems_PriceCatalogueType(long EstimateItemID, int QtyNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_Details_EstimateItems_Type_PriceCatalogue");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Get_EstimateItems_Type_PriceCatalogue(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_EstimateItems_Type_PriceCatalogue");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Get_KitDetails_EstimateItems_PriceCatalogueType(long PriceCatalogueID, int Quantity)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_KitDetails_EstimateItems_Status_Change");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string GetEstimateType_EstimateItemID(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetEstimateType_EstimateItemID");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}
		public virtual int GetPriceCatalogueIDByEstimateItemID(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetPriceCatalogueIDByEstimateItemID");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return Convert.ToInt32(database.ExecuteScalar(storedProcCommand));
		}
		public virtual DataTable GetPriceCatalogueIDByEstimateID(int CompanyID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetPriceCatalogueIDByEstimateID");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}
		public virtual int GetProductId_ByEstimatetItemId(int CompanyId, int EstimateItemId)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProductId_ByEstimateItemId");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyId);
			database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int32, EstimateItemId);
			return Convert.ToInt32(database.ExecuteScalar(storedProcCommand));
		}

		public virtual DataTable getQuantity_for_items(long ParentEstimateItemID, string ParentEstimateType, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Quantity_populate_subitem");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, ParentEstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ParentEstimateType);
			database.AddInParameter(storedProcCommand, "@modulename", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable GetTaxDetails_ByEstimateItemId(int EstimateItemId)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetTaxDetails_ByEstimateItemId");
			database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int32, EstimateItemId);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Ink_Delete_BasedOn_estimateitemID(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Ink_Delete_BasedOn_estimateitemID");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Ink_Select_BasedOn_estimateitemID(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Ink_Select_BasedOn_estimateitemID");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable inkselectfromdatabase(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_inkselectfromdatabase]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public void Insert_EstPriceCatAddOptionDetails(long EstimateAdditionalItemID, long EstimateID, string CalculationType, long EstimateItemID, string SelectedValue, decimal MarkupPercentage1, decimal MarkupPercentage2, decimal MarkupPercentage3, decimal MarkupPercentage4, decimal CostPriceInMarkup1, decimal CostPriceInMarkup2, decimal CostPriceInMarkup3, decimal CostPriceInMarkup4, long SelectedID, decimal MarkupValue1, decimal MarkupValue2, decimal MarkupValue3, decimal MarkupValue4, int SortOrderNo, decimal SelectedPrice1, decimal SelectedPrice2, decimal SelectedPrice3, decimal SelectedPrice4, string EstimateOtherCostName, decimal TotalPriceExMarkup1, decimal TotalPriceExMarkup2, decimal TotalPriceExMarkup3, decimal TotalPriceExMarkup4, decimal TotalPriceIncMarkup1, decimal TotalPriceIncMarkup2, decimal TotalPriceIncMarkup3, decimal TotalPriceIncMarkup4, int IsFirst, long WebOtherCostID, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstPriceCatAddOptionDetails");
			database.AddInParameter(storedProcCommand, "@EstimateAdditionalItemID", DbType.Int64, EstimateAdditionalItemID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
			database.AddInParameter(storedProcCommand, "@MarkupPercentage1", DbType.Decimal, MarkupPercentage1);
			database.AddInParameter(storedProcCommand, "@MarkupPercentage2", DbType.Decimal, MarkupPercentage2);
			database.AddInParameter(storedProcCommand, "@MarkupPercentage3", DbType.Decimal, MarkupPercentage3);
			database.AddInParameter(storedProcCommand, "@MarkupPercentage4", DbType.Decimal, MarkupPercentage4);
			database.AddInParameter(storedProcCommand, "@CostPriceInMarkup1", DbType.Decimal, CostPriceInMarkup1);
			database.AddInParameter(storedProcCommand, "@CostPriceInMarkup2", DbType.Decimal, CostPriceInMarkup2);
			database.AddInParameter(storedProcCommand, "@CostPriceInMarkup3", DbType.Decimal, CostPriceInMarkup3);
			database.AddInParameter(storedProcCommand, "@CostPriceInMarkup4", DbType.Decimal, CostPriceInMarkup4);
			database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
			database.AddInParameter(storedProcCommand, "@MarkupValue1", DbType.Decimal, MarkupValue1);
			database.AddInParameter(storedProcCommand, "@MarkupValue2", DbType.Decimal, MarkupValue2);
			database.AddInParameter(storedProcCommand, "@MarkupValue3", DbType.Decimal, MarkupValue3);
			database.AddInParameter(storedProcCommand, "@MarkupValue4", DbType.Decimal, MarkupValue4);
			database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
			database.AddInParameter(storedProcCommand, "@SelectedPrice1", DbType.Decimal, SelectedPrice1);
			database.AddInParameter(storedProcCommand, "@SelectedPrice2", DbType.Decimal, SelectedPrice2);
			database.AddInParameter(storedProcCommand, "@SelectedPrice3", DbType.Decimal, SelectedPrice3);
			database.AddInParameter(storedProcCommand, "@SelectedPrice4", DbType.Decimal, SelectedPrice4);
			database.AddInParameter(storedProcCommand, "@EstimateOtherCostName", DbType.String, EstimateOtherCostName);
			database.AddInParameter(storedProcCommand, "@TotalPriceExMarkup1", DbType.Decimal, TotalPriceExMarkup1);
			database.AddInParameter(storedProcCommand, "@TotalPriceExMarkup2", DbType.Decimal, TotalPriceExMarkup2);
			database.AddInParameter(storedProcCommand, "@TotalPriceExMarkup3", DbType.Decimal, TotalPriceExMarkup3);
			database.AddInParameter(storedProcCommand, "@TotalPriceExMarkup4", DbType.Decimal, TotalPriceExMarkup4);
			database.AddInParameter(storedProcCommand, "@TotalPriceIncMarkup1", DbType.Decimal, TotalPriceIncMarkup1);
			database.AddInParameter(storedProcCommand, "@TotalPriceIncMarkup2", DbType.Decimal, TotalPriceIncMarkup2);
			database.AddInParameter(storedProcCommand, "@TotalPriceIncMarkup3", DbType.Decimal, TotalPriceIncMarkup3);
			database.AddInParameter(storedProcCommand, "@TotalPriceIncMarkup4", DbType.Decimal, TotalPriceIncMarkup4);
			database.AddInParameter(storedProcCommand, "@IsFirst", DbType.Int32, IsFirst);
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
			database.AddInParameter(storedProcCommand, "@ParentWebOtherCostID", DbType.Int64, ParentWebOtherCostID);
			database.AddInParameter(storedProcCommand, "@WebOtherCostType", DbType.String, WebOtherCostType);
			database.AddInParameter(storedProcCommand, "@FreeTextQuestionLong", DbType.String, FreeTextQuestionLong);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void insert_largeitem_quantity(long EstimateItemID, long QuantityID, long MaterialID, decimal InvSheets1, decimal InvSheets2, decimal InvSheets3, decimal InvSheets4, decimal PrintSheets1, decimal PrintSheets2, decimal PrintSheets3, decimal PrintSheets4, decimal MaterialLength1, decimal MaterialLength2, decimal MaterialLength3, decimal MaterialLength4, decimal MaterialMarkupPrice1, decimal MaterialCostExMarkup1, decimal MaterialMarkupPrice2, decimal MaterialCostExMarkup2, decimal MaterialMarkupPrice3, decimal MaterialCostExMarkup3, decimal MaterialMarkupPrice4, decimal MaterialCostExMarkup4, int MaterialNo, string savetype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_insert_largeitem_quantity");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, QuantityID);
			database.AddInParameter(storedProcCommand, "@MaterialID", DbType.Int64, MaterialID);
			database.AddInParameter(storedProcCommand, "@InvSheets1", DbType.Decimal, InvSheets1);
			database.AddInParameter(storedProcCommand, "@InvSheets2", DbType.Decimal, InvSheets2);
			database.AddInParameter(storedProcCommand, "@InvSheets3", DbType.Decimal, InvSheets3);
			database.AddInParameter(storedProcCommand, "@InvSheets4", DbType.Decimal, InvSheets4);
			database.AddInParameter(storedProcCommand, "@PrintSheets1", DbType.Decimal, PrintSheets1);
			database.AddInParameter(storedProcCommand, "@PrintSheets2", DbType.Decimal, PrintSheets2);
			database.AddInParameter(storedProcCommand, "@PrintSheets3", DbType.Decimal, PrintSheets3);
			database.AddInParameter(storedProcCommand, "@PrintSheets4", DbType.Decimal, PrintSheets4);
			database.AddInParameter(storedProcCommand, "@MaterialLength1", DbType.Decimal, MaterialLength1);
			database.AddInParameter(storedProcCommand, "@MaterialLength2", DbType.Decimal, MaterialLength2);
			database.AddInParameter(storedProcCommand, "@MaterialLength3", DbType.Decimal, MaterialLength3);
			database.AddInParameter(storedProcCommand, "@MaterialLength4", DbType.Decimal, MaterialLength4);
			database.AddInParameter(storedProcCommand, "@MaterialMarkupPrice1", DbType.Decimal, MaterialMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@MaterialCostExMarkup1", DbType.Decimal, MaterialCostExMarkup1);
			database.AddInParameter(storedProcCommand, "@MaterialMarkupPrice2", DbType.Decimal, MaterialMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@MaterialCostExMarkup2", DbType.Decimal, MaterialCostExMarkup2);
			database.AddInParameter(storedProcCommand, "@MaterialMarkupPrice3", DbType.Decimal, MaterialMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@MaterialCostExMarkup3", DbType.Decimal, MaterialCostExMarkup3);
			database.AddInParameter(storedProcCommand, "@MaterialMarkupPrice4", DbType.Decimal, MaterialMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@MaterialCostExMarkup4", DbType.Decimal, MaterialCostExMarkup4);
			database.AddInParameter(storedProcCommand, "@MaterialNo", DbType.Int32, MaterialNo);
			database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, savetype);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Invoice_CustomerID_Select(long InvoiceID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("");
			database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Invoice_DeliveryNote_QuickLinks_Select(int CompanyID, long InvoiceID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Invoice_DeliveryNote_QuickLinks_Select]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Item_Copy_AllMainItem_withallAdditionItems(long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Item_Copy_AllMainItem_withallAdditionItems");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@NewEstItemId", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@NewEstItemId");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Item_Copy_AllMainItem_withallAdditionItems_reeng(long EstimateItemID, string EstimateType, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Item_Copy_AllMainItem_withallAdditionItems");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, Module);
			database.AddOutParameter(storedProcCommand, "@NewEstItemId", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@NewEstItemId");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable item_cost_view_sub_item_outwork(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_cost_view_sub_item_outwork");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void item_description_update(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_description_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void item_description_update_new(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription, long EstimateID, string Itemtitle)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_description_update_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, Itemtitle);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable item_select_itemDescription_foralltypes(int CompanyID, long EstimateItemID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_select_itemDescription_foralltypes");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet itemdescription_selectall_fromSettings_foralltypes(int CompanyID, string EstimateType)
		{
			BaseClass baseClass = new BaseClass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_itemdescription_selectall_fromSettings_foralltypes");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, EstimateType);
			dataSet = database.ExecuteDataSet(storedProcCommand);
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				row["ScreenName"] = baseClass.SpecialDecode(row["ScreenName"].ToString());
			}
			return dataSet;
		}

		public virtual void itemTitleUpdate_for_eStoreOtherCost(int CompanyID, long EstimateID, long EstimateItemID, string ItemTitle)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_itemTitleUpdate_for_eStoreOtherCost");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Job_item_select(int CompanyID, long JobID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int Job_Items_Count_Select(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_items_count_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable job_othercost_subitem_select(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID, int Quantity)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_othercost_subitem_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int64, Quantity);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable jobcard_select_directjob(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobcard_select_directjob");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long large_item_insert(EstimatesItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_large_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLargeItemID", DbType.Int64, item.EstimateLargeItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, item.SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, item.RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, item.SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, item.SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, item.JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, item.JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, item.GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, item.GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@NonImageHeight", DbType.Decimal, item.NonImageHeight);
			database.AddInParameter(storedProcCommand, "@NonImageWidth", DbType.Decimal, item.NonImageWidth);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, item.PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, item.LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
			database.AddInParameter(storedProcCommand, "@PrintQuality", DbType.String, item.PrintQuality);
			database.AddInParameter(storedProcCommand, "@InkCoverageSide1", DbType.Decimal, item.InkCoverageSide1);
			database.AddInParameter(storedProcCommand, "@InkCoverageSide2", DbType.Decimal, item.InkCoverageSide2);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
			database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
			database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
			database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.Boolean, item.IsCompleted);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, item.ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, item.ParentItemType);
			database.AddInParameter(storedProcCommand, "@Row", DbType.Decimal, item.Row);
			database.AddInParameter(storedProcCommand, "@Col", DbType.Decimal, item.Col);
			database.AddInParameter(storedProcCommand, "@MaterialID2", DbType.Int64, item.MaterialID2);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack2", DbType.Boolean, item.IsPricePerPack2);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied2", DbType.Boolean, item.IsPaperSupplied2);
			database.AddInParameter(storedProcCommand, "@MaterialID3", DbType.Int64, item.MaterialID3);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack3", DbType.Boolean, item.IsPricePerPack3);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied3", DbType.Boolean, item.IsPaperSupplied3);
			database.AddInParameter(storedProcCommand, "@MaterialID4", DbType.Int64, item.MaterialID4);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack4", DbType.Boolean, item.IsPricePerPack4);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied4", DbType.Boolean, item.IsPaperSupplied4);
			database.AddInParameter(storedProcCommand, "@MaterialID5", DbType.Int64, item.MaterialID5);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack5", DbType.Boolean, item.IsPricePerPack5);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied5", DbType.Boolean, item.IsPaperSupplied5);
			database.AddInParameter(storedProcCommand, "@CalcType", DbType.String, item.CalculationType);
			database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide1", DbType.Decimal, item.WhiteInkCoverageSide1);
			database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide2", DbType.Decimal, item.WhiteInkCoverageSide2);
			database.AddInParameter(storedProcCommand, "@DPI", DbType.Int32, item.DPI);
			database.AddInParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.AddInParameter(storedProcCommand, "@isFullSheet", DbType.Boolean, item.isFullSheet);
            database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable large_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_large_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable large_item_select_forMaterials(long CompanyID, long EstimateItemID, long MaterialID, int MetarialNO)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_large_item_select_forMaterials");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@MateralID", DbType.Int64, MaterialID);
			database.AddInParameter(storedProcCommand, "@MetarialNO", DbType.Int32, MetarialNO);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable LargeItem_Ink_Details_Select(int CompanyID, long EstimateItemID, string color, string sidecolor, bool IsDoubleSided)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LargeItem_InkDetailsSelect");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@color", DbType.String, color);
			database.AddInParameter(storedProcCommand, "@sidecolor", DbType.String, sidecolor);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, IsDoubleSided);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable LargeItem_ink_UnitPrice_MinimumCost_Select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LargeItem_ink_UnitPrice_MinimumCost_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void LargeItemCalculation_insert(long EstimateCalculationID, long EstimateItemID, long MaterialID, decimal MaterialUnitPrice, decimal MaterialWeight, decimal MaterialPackedInQty, decimal MaterialMarkup1, decimal MaterialMarkup2, decimal MaterialMarkup3, decimal MaterialMarkup4, int MaterialNo, string savetype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LargeItemCalculation_insert");
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@MaterialID", DbType.Int64, MaterialID);
			database.AddInParameter(storedProcCommand, "@MaterialUnitPrice", DbType.Decimal, MaterialUnitPrice);
			database.AddInParameter(storedProcCommand, "@MaterialWeight", DbType.Decimal, MaterialWeight);
			database.AddInParameter(storedProcCommand, "@MaterialPackedInQty", DbType.Decimal, MaterialPackedInQty);
			database.AddInParameter(storedProcCommand, "@MaterialMarkup1", DbType.Decimal, MaterialMarkup1);
			database.AddInParameter(storedProcCommand, "@MaterialMarkup2", DbType.Decimal, MaterialMarkup2);
			database.AddInParameter(storedProcCommand, "@MaterialMarkup3", DbType.Decimal, MaterialMarkup3);
			database.AddInParameter(storedProcCommand, "@MaterialMarkup4", DbType.Decimal, MaterialMarkup4);
			database.AddInParameter(storedProcCommand, "@MaterialNo", DbType.Int32, MaterialNo);
			database.AddInParameter(storedProcCommand, "@savetype", DbType.String, savetype);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable litho_estimate_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_litho_estimate_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable litho_pad_estimate_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_litho_pad_estimate_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long litho_press_insert(int CompanyID, long EstLithoItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue, bool sheetwork)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_litho_press_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstLithoItemID", DbType.Int64, EstLithoItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@sidesprinted", DbType.String, sidesprinted);
			database.AddInParameter(storedProcCommand, "@side1Color", DbType.String, side1Color);
			database.AddInParameter(storedProcCommand, "@side2Color", DbType.String, side2Color);
			database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, PlateID);
			database.AddInParameter(storedProcCommand, "@Noofplates", DbType.String, Noofplates);
			database.AddInParameter(storedProcCommand, "@NoofMakeReady", DbType.String, NoofMakeReady);
			database.AddInParameter(storedProcCommand, "@NoofWashup", DbType.String, NoofWashup);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@WorknTurn", DbType.Boolean, WorknTurn);
			database.AddInParameter(storedProcCommand, "@WorknTumble", DbType.Boolean, WorknTumble);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			database.AddInParameter(storedProcCommand, "@Perfecting", DbType.Boolean, Perfecting);
			database.AddInParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, ManualValue);
			database.AddInParameter(storedProcCommand, "@sheetwork", DbType.Boolean, sheetwork);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual void litho_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_litho_speed_weight_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, EstimateCalculationID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long Lithobooklet_item_insert(EstimatesItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Lithobooklet_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoBookletItemID", DbType.Int64, item.EstimateLithoBookletItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SectionReference", DbType.String, item.SectionRef);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, item.SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, item.LithoBookletRunningSpoilage);
			database.AddInParameter(storedProcCommand, "@sidesprinted", DbType.String, item.NCRNoofsidesprinted);
			database.AddInParameter(storedProcCommand, "@side1Color", DbType.String, item.NCRSide1color);
			database.AddInParameter(storedProcCommand, "@side2Color", DbType.String, item.NCRSide2color);
			database.AddInParameter(storedProcCommand, "@WorknTurn", DbType.Boolean, item.NCRCheckturn);
			database.AddInParameter(storedProcCommand, "@WorknTumble", DbType.Boolean, item.NCRChecktumble);
			database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, Convert.ToInt64(item.NCRPlateID));
			database.AddInParameter(storedProcCommand, "@Noofplates", DbType.String, item.NCRPlate);
			database.AddInParameter(storedProcCommand, "@NoofMakeReady", DbType.String, item.NoofMakeReady);
			database.AddInParameter(storedProcCommand, "@NoofWashup", DbType.String, item.NCRWashup);
			database.AddInParameter(storedProcCommand, "@BookletType", DbType.String, item.BookletType);
			database.AddInParameter(storedProcCommand, "@NoOfPagesInSection", DbType.Decimal, item.NoOfPagesInSection);
			database.AddInParameter(storedProcCommand, "@PagesPerSignature", DbType.Decimal, item.PagesPerSignature);
			database.AddInParameter(storedProcCommand, "@NoOfSignatures", DbType.Decimal, item.NoOfSignatures);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, item.SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, item.SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, item.JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, item.JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, item.GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, item.GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@NonImageHeight", DbType.Decimal, item.NonImageHeight);
			database.AddInParameter(storedProcCommand, "@NonImageWidth", DbType.Decimal, item.NonImageWidth);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, item.PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, item.LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
			database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, item.IsDeleted);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.Boolean, item.IsCompleted);
			database.AddInParameter(storedProcCommand, "@BookletFormat", DbType.String, item.BookletFormat);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, item.ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, item.ParentItemType);
			database.AddInParameter(storedProcCommand, "@isCeilPrintSheetPerSection", DbType.Boolean, item.isCeilPrintSheetPerSection);
			database.AddInParameter(storedProcCommand, "@CheckPerfecting", DbType.Boolean, item.NCRCheckPerfecting);
			database.AddInParameter(storedProcCommand, "@SheetWork", DbType.Boolean, item.NCRChkSheetWork);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, item.ManualValue);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable lithobooklet_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_lithobooklet_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable lithobooklet_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_lithobooklet_item_select_othercostasadditional");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLithobookletItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable lithobooklet_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoBookletItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_lithobooklet_item_select_popup_paperpressinkguillotine");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoBookletItemID", DbType.Int64, EstimateLithoBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void LithoBookletquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithobookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LithoBookletquantity_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qty1", DbType.Int32, Qty1);
			database.AddInParameter(storedProcCommand, "@Qty2", DbType.Int32, Qty2);
			database.AddInParameter(storedProcCommand, "@Qty3", DbType.Int32, Qty3);
			database.AddInParameter(storedProcCommand, "@Qty4", DbType.Int32, Qty4);
			database.AddInParameter(storedProcCommand, "@SubTotal1", DbType.Double, SubTotal1);
			database.AddInParameter(storedProcCommand, "@SubTotal2", DbType.Double, SubTotal2);
			database.AddInParameter(storedProcCommand, "@SubTotal3", DbType.Double, SubTotal3);
			database.AddInParameter(storedProcCommand, "@SubTotal4", DbType.Double, SubTotal4);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Double, Tax);
			database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, QueryType);
			database.AddInParameter(storedProcCommand, "@EstimateLithobookletItemID", DbType.Int64, EstimateLithobookletItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable lithoncr_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_lithoncr_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable digitalncr_item_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_digitalncr_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable lithoncr_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_lithoncr_item_select_othercostasadditional");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoncrItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable lithoncr_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_lithoncr_item_select_popup_paperpressinkguillotine");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNcrItemID", DbType.Int64, EstimateLithoNcrItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void LockItemStatus(long EstimateItemID, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimates_LockEstimateItemStatus");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Materials_select_ForPOCreate(long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Materials_select_ForPOCreate");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Module_IsConverted_To_NextModule(long ModuleId, string ModuleType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsModuleConverted2NextPhase");
			database.AddInParameter(storedProcCommand, "@ModuleId", DbType.Int64, ModuleId);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			return (long)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable NCR_item_quantity_select(int CompanyID, int EstimateItemID, string EstType, int EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_NCR_item_quantity_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, EstType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int32, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void NCRquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithoNCRItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_NCRquantity_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qty1", DbType.Int32, Qty1);
			database.AddInParameter(storedProcCommand, "@Qty2", DbType.Int32, Qty2);
			database.AddInParameter(storedProcCommand, "@Qty3", DbType.Int32, Qty3);
			database.AddInParameter(storedProcCommand, "@Qty4", DbType.Int32, Qty4);
			database.AddInParameter(storedProcCommand, "@SubTotal1", DbType.Double, SubTotal1);
			database.AddInParameter(storedProcCommand, "@SubTotal2", DbType.Double, SubTotal2);
			database.AddInParameter(storedProcCommand, "@SubTotal3", DbType.Double, SubTotal3);
			database.AddInParameter(storedProcCommand, "@SubTotal4", DbType.Double, SubTotal4);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Double, Tax);
			database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, QueryType);
			database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemID", DbType.Int64, EstimateLithoNCRItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public DataTable OrderItemID_Select(long OrderID, long EstimateItemID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderItemID_Select");
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Orders_Othercostitem_select(int CompanyID, long EstimateID, string Pgtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Orders_OthercostItem_select");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@Pagetype", DbType.String, Pgtype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void othercost_formula_tag_update(int CompanyID, long EstOthercostID, long EstimateItemID, string FormulaTag, int QtyNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_formula_tag_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOthercostID", DbType.Int64, EstOthercostID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@FormulaTag", DbType.String, FormulaTag);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long OtherCostSequence_GetCountBy_EstimatType(int CompanyID, string EstimateType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_OtherCostSequence_GetCountBy_EstimatType");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddOutParameter(storedProcCommand, "@ReturnCount", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnCount");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataSet OtherCostSequenceDetails(long CompanyID, string EstimateType)
		{
			commonClass _commonClass = new commonClass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCostSequence_Get_By_EstimatType");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, EstimateType);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual long pad_item_insert(EstimatesItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_pad_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimatePadItemID", DbType.Int64, item.EstimatePadItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, item.SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, item.RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@LeavesPerPad", DbType.Decimal, item.LeavesPerPad);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, item.SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, item.SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, item.JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, item.JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, item.GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, item.GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@NonImageHeight", DbType.Decimal, item.NonImageHeight);
			database.AddInParameter(storedProcCommand, "@NonImageWidth", DbType.Decimal, item.NonImageWidth);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, item.PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, item.LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
			database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
			database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
			database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.Boolean, item.IsCompleted);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, item.ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, item.ParentItemType);
			database.AddInParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, item.ManualValue);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable pad_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_pad_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable pad_item_summary(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_pad_item_summary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PaperSupplied_select_ForPOCreate(long EstimateItemID, string EstimateItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaperSupplierSelect_byItemID");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemType", DbType.String, EstimateItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet PC_EstimateLargeItem_InkCalID_Select(long EstimateItemID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateLargeItem_InkCalcID_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual void PC_EstimateLargeItem_InkMarkUp_Insert(long EstimateItemID, decimal InkMarkup)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateLargeItem_InkMark_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateInkCalcID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@InkMarkup", DbType.Decimal, InkMarkup);
			database.ExecuteDataSet(storedProcCommand);
		}

		public virtual void PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(int CompanyID, long ParentItemID, string ParentItemType, string SubItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			database.AddInParameter(storedProcCommand, "@SubItemType", DbType.String, SubItemType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable PCR_Estimate_InkMarkup_Select(int CompanyID, long EstimateItemID, long InventoryID, long TypeID, string EstimateType, int QuantityNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Estimate_InkMarkup_Select");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
			database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@QuantityNumber", DbType.Int32, QuantityNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void PCR_Estimate_InkMarkup_Update(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual, int QuantityNumber, long EstimateInkCalcID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Estimate_InkMarkup_Update");
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup", DbType.Decimal, InkCostExMarkup);
			database.AddInParameter(storedProcCommand, "@InkMarkup", DbType.Decimal, InkMarkup);
			database.AddInParameter(storedProcCommand, "@InkMarkupPrice", DbType.Decimal, InkMarkupPrice);
			database.AddInParameter(storedProcCommand, "@InkSetupCharge", DbType.Decimal, InkSetupCharge);
			database.AddInParameter(storedProcCommand, "@InkMinimumCharge", DbType.Decimal, InkMinimumCharge);
			database.AddInParameter(storedProcCommand, "@InkCostExMarkup_Actual", DbType.Decimal, InkCostExMarkup_Actual);
			database.AddInParameter(storedProcCommand, "@QuantityNumber", DbType.Int32, QuantityNumber);
			database.AddInParameter(storedProcCommand, "@EstimateInkCalcID", DbType.Int64, EstimateInkCalcID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void PCR_Estimate_Large_Ink_Insert(long EstimateItemID, string ActionType, int CompanyID, string Color, string sidecolor, bool IsDoubleSided, long PressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_Estimate_Large_Ink_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			//database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, "qty");
			database.AddInParameter(storedProcCommand, "@ActionType", DbType.String, ActionType);

			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@color", DbType.String, Color);
			database.AddInParameter(storedProcCommand, "@sidecolor", DbType.String, sidecolor);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, IsDoubleSided);
			database.AddInParameter(storedProcCommand, "@press_id", DbType.Boolean, PressID);

			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void PCR_estimates_markup_calculation_update_forInk(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkCostExMarkup_Actual, int QtyNo, long EstimateInkCalcID, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimates_markup_calculation_update_forInk");
			database.AddInParameter(storedProcCommand, "@CostExMarkup", DbType.Decimal, InkCostExMarkup);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, InkMarkup);
			database.AddInParameter(storedProcCommand, "@MarkupPrice", DbType.Decimal, InkMarkupPrice);
			database.AddInParameter(storedProcCommand, "@CostExMarkup_Actual", DbType.Decimal, InkCostExMarkup_Actual);
			database.AddInParameter(storedProcCommand, "@QtyNo", DbType.Int32, QtyNo);
			database.AddInParameter(storedProcCommand, "@EstimateInkCalcID", DbType.Int64, EstimateInkCalcID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void PCR_estimates_Update_SetupCharge_Or_MakeReady(long EstimateInkCalcID, decimal SetUpCharge_OrMake_ReadyValue, string SetUpCharge_OrMake_Ready)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_estimates_Update_SetupCharge_Or_MakeReady");
			database.AddInParameter(storedProcCommand, "@EstimateInkCalcID", DbType.Int64, EstimateInkCalcID);
			database.AddInParameter(storedProcCommand, "@SetUpCharge_OrMake_ReadyValue", DbType.Decimal, SetUpCharge_OrMake_ReadyValue);
			database.AddInParameter(storedProcCommand, "@SetUpCharge_OrMake_Ready", DbType.String, SetUpCharge_OrMake_Ready);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable PCR_Guillotine_Cost_ViewOnPopUp(long GuillotineID, long EstimateItemID, string EstimateType, long TypeID, string Module)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Guillotine_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet PCR_Ink_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module, string Section)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Ink_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@Section", DbType.String, Section);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable PCR_MakeReady_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_MakeReady_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PCR_OtherCostSequence_GetIDSToValidate(int CompanyID, string ParentEstimateType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_OtherCostSequence_GetIDSToValidate");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentEstimateType", DbType.String, ParentEstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PCR_Paper_Cost_ViewOnPopUp(int PaperID, long EstimateItemID, string EstimateType, long TypeID, string Module, int MaterialNo)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Paper_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@MetarialNO", DbType.Int32, MaterialNo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable PCR_Plate_Cost_ViewOnPopUp(long PlateID, long EstimateItemID, string EstimateType, long TypeID, string Module)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Plate_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, PlateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet PCR_Press_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Press_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable PCR_WashUp_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_washup_Cost_ViewOnPopUp");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@UniqueID", DbType.Int64, TypeID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void price_catalogue_insert(int CompanyID, string Data)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable price_catalogue_select_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select_by_estimateitem_id_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Pricecatalog_selecttiemdescription_byestimateitemid(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Pricecatalog_selecttiemdescription_byestimateitemid");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void PrintReadyfile_Insert(long EstimateID, long EstimateItemID, long UserID, string ModuleType, string AttachmentType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PrintReadyfile_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
			database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable PrintReadyFile_Select(long PriceCatalogueID, int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PrintReadyFile_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Product_CatalogueQty_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
            foreach (DataColumn col in dataTable.Columns)
            {
                col.ReadOnly = false;
            }
			return dataTable;
		}

		public virtual DataTable ProductOROrder_Item_Qty_Select(long EstimateItemID)
		{
			SqlConnection sqlConnection = new SqlConnection((new commonClass()).strConnection);
			SqlCommand sqlCommand = new SqlCommand("PC_ProductOROrder_Item_Qty_Select", sqlConnection)
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@EstimateItemID", SqlDbType.BigInt).Value = EstimateItemID;
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			using (IDataReader dataReader = sqlCommand.ExecuteReader())
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable productsDetails_Select(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsDetails_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable TaxPrecedence_Select( long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("SP_TaxPrecedence_Select");
            database.AddInParameter(storedProcCommand, "@EstimateId", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Profit_Margin_By_Client_System(int CompanyID, long EstimateID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_profit_margin_select_by_estimateid_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Profit_Margin_By_Client_System_InvoiceID(int CompanyID, long InvoiceID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_ProfitMargin_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Profit_Margin_By_ProductCatalogue(int CompanyID, long productid)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PricecatalogueTaxrate_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@productid", DbType.Int64, productid);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void qty_delete(int CompanyID, long EstimateItemID, long EstimateBookletItemID, string EstimateType, int QtyNumber)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@EstimateType", EstimateType), new SqlParameter("@QtyNumber", (object)QtyNumber) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_qty_delete", sqlParameterArray);
		}

		public virtual void quantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_quantity_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qty1", DbType.Int32, Qty1);
			database.AddInParameter(storedProcCommand, "@Qty2", DbType.Int32, Qty2);
			database.AddInParameter(storedProcCommand, "@Qty3", DbType.Int32, Qty3);
			database.AddInParameter(storedProcCommand, "@Qty4", DbType.Int32, Qty4);
			database.AddInParameter(storedProcCommand, "@SubTotal1", DbType.Double, SubTotal1);
			database.AddInParameter(storedProcCommand, "@SubTotal2", DbType.Double, SubTotal2);
			database.AddInParameter(storedProcCommand, "@SubTotal3", DbType.Double, SubTotal3);
			database.AddInParameter(storedProcCommand, "@SubTotal4", DbType.Double, SubTotal4);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Double, Tax);
			database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, QueryType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void quantity_insert_large_item(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PaperLength1, decimal PaperLength2, decimal PaperLength3, decimal PaperLength4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Qty1", (object)Qty1), new SqlParameter("@InvSheets1", (object)InvSheets1), new SqlParameter("@PrintSheets1", (object)PrintSheets1), new SqlParameter("@PaperCostExMarkup1", (object)PaperCostExMarkup1), new SqlParameter("@PaperMarkupPrice1", (object)PaperMarkupPrice1), new SqlParameter("@PressCostExMarkup1", (object)PressCostExMarkup1), new SqlParameter("@PressMarkupPrice1", (object)PressMarkupPrice1), new SqlParameter("@FirstTrimCuts1", (object)FirstTrimCuts1), new SqlParameter("@FirstTrimNoOfBundles1", (object)FirstTrimNoOfBundles1), new SqlParameter("@SecondTrimCuts1", (object)SecondTrimCuts1), new SqlParameter("@SecondTrimNoOfBundles1", (object)SecondTrimNoOfBundles1), new SqlParameter("@GuillotineCostExMarkup1", (object)GuillotineCostExMarkup1), new SqlParameter("@GuillotineMarkupPrice1", (object)GuillotineMarkupPrice1), new SqlParameter("@InkCostExMarkup1", (object)InkCostExMarkup1), new SqlParameter("@InkMarkupPrice1", (object)InkMarkupPrice1), new SqlParameter("@Qty2", (object)Qty2), new SqlParameter("@InvSheets2", (object)InvSheets2), new SqlParameter("@PrintSheets2", (object)PrintSheets2), new SqlParameter("@PaperCostExMarkup2", (object)PaperCostExMarkup2), new SqlParameter("@PaperMarkupPrice2", (object)PaperMarkupPrice2), new SqlParameter("@PressCostExMarkup2", (object)PressCostExMarkup2), new SqlParameter("@PressMarkupPrice2", (object)PressMarkupPrice2), new SqlParameter("@FirstTrimCuts2", (object)FirstTrimCuts2), new SqlParameter("@FirstTrimNoOfBundles2", (object)FirstTrimNoOfBundles2), new SqlParameter("@SecondTrimCuts2", (object)SecondTrimCuts2), new SqlParameter("@SecondTrimNoOfBundles2", (object)SecondTrimNoOfBundles2), new SqlParameter("@GuillotineCostExMarkup2", (object)GuillotineCostExMarkup2), new SqlParameter("@GuillotineMarkupPrice2", (object)GuillotineMarkupPrice2), new SqlParameter("@InkCostExMarkup2", (object)InkCostExMarkup2), new SqlParameter("@InkMarkupPrice2", (object)InkMarkupPrice2), new SqlParameter("@Qty3", (object)Qty3), new SqlParameter("@InvSheets3", (object)InvSheets3), new SqlParameter("@PrintSheets3", (object)PrintSheets3), new SqlParameter("@PaperCostExMarkup3", (object)PaperCostExMarkup3), new SqlParameter("@PaperMarkupPrice3", (object)PaperMarkupPrice3), new SqlParameter("@PressCostExMarkup3", (object)PressCostExMarkup3), new SqlParameter("@PressMarkupPrice3", (object)PressMarkupPrice3), new SqlParameter("@FirstTrimCuts3", (object)FirstTrimCuts3), new SqlParameter("@FirstTrimNoOfBundles3", (object)FirstTrimNoOfBundles3), new SqlParameter("@SecondTrimCuts3", (object)SecondTrimCuts3), new SqlParameter("@SecondTrimNoOfBundles3", (object)SecondTrimNoOfBundles3), new SqlParameter("@GuillotineCostExMarkup3", (object)GuillotineCostExMarkup3), new SqlParameter("@GuillotineMarkupPrice3", (object)GuillotineMarkupPrice3), new SqlParameter("@InkCostExMarkup3", (object)InkCostExMarkup3), new SqlParameter("@InkMarkupPrice3", (object)InkMarkupPrice3), new SqlParameter("@Qty4", (object)Qty4), new SqlParameter("@InvSheets4", (object)InvSheets4), new SqlParameter("@PrintSheets4", (object)PrintSheets4), new SqlParameter("@PaperCostExMarkup4", (object)PaperCostExMarkup4), new SqlParameter("@PaperMarkupPrice4", (object)PaperMarkupPrice4), new SqlParameter("@PressCostExMarkup4", (object)PressCostExMarkup4), new SqlParameter("@PressMarkupPrice4", (object)PressMarkupPrice4), new SqlParameter("@FirstTrimCuts4", (object)FirstTrimCuts4), new SqlParameter("@FirstTrimNoOfBundles4", (object)FirstTrimNoOfBundles4), new SqlParameter("@SecondTrimCuts4", (object)SecondTrimCuts4), new SqlParameter("@SecondTrimNoOfBundles4", (object)SecondTrimNoOfBundles4), new SqlParameter("@GuillotineCostExMarkup4", (object)GuillotineCostExMarkup4), new SqlParameter("@GuillotineMarkupPrice4", (object)GuillotineMarkupPrice4), new SqlParameter("@InkCostExMarkup4", (object)InkCostExMarkup4), new SqlParameter("@InkMarkupPrice4", (object)InkMarkupPrice4), new SqlParameter("@QueryType", QueryType), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@PressJobTimeSide11", (object)PressJobTimeSide11), new SqlParameter("@PressJobTimeSide12", (object)PressJobTimeSide12), new SqlParameter("@PressJobTimeSide13", (object)PressJobTimeSide13), new SqlParameter("@PressJobTimeSide14", (object)PressJobTimeSide14), new SqlParameter("@PressJobTimeSide21", (object)PressJobTimeSide21), new SqlParameter("@PressJobTimeSide22", (object)PressJobTimeSide22), new SqlParameter("@PressJobTimeSide23", (object)PressJobTimeSide23), new SqlParameter("@PressJobTimeSide24", (object)PressJobTimeSide24), new SqlParameter("@Zone_Side1_PressMarkupPercentage1", (object)Zone_Side1_PressMarkupPercentage1), new SqlParameter("@Zone_Side1_PressMarkupPercentage2", (object)Zone_Side1_PressMarkupPercentage2), new SqlParameter("@Zone_Side1_PressMarkupPercentage3", (object)Zone_Side1_PressMarkupPercentage3), new SqlParameter("@Zone_Side1_PressMarkupPercentage4", (object)Zone_Side1_PressMarkupPercentage4), new SqlParameter("@Zone_Side2_PressMarkupPercentage1", (object)Zone_Side2_PressMarkupPercentage1), new SqlParameter("@Zone_Side2_PressMarkupPercentage2", (object)Zone_Side2_PressMarkupPercentage2), new SqlParameter("@Zone_Side2_PressMarkupPercentage3", (object)Zone_Side2_PressMarkupPercentage3), new SqlParameter("@Zone_Side2_PressMarkupPercentage4", (object)Zone_Side2_PressMarkupPercentage4), new SqlParameter("@Zone_Side1_PressMarkupPrice1", (object)Zone_Side1_PressMarkupPrice1), new SqlParameter("@Zone_Side1_PressMarkupPrice2", (object)Zone_Side1_PressMarkupPrice2), new SqlParameter("@Zone_Side1_PressMarkupPrice3", (object)Zone_Side1_PressMarkupPrice3), new SqlParameter("@Zone_Side1_PressMarkupPrice4", (object)Zone_Side1_PressMarkupPrice4), new SqlParameter("@Zone_Side2_PressMarkupPrice1", (object)Zone_Side2_PressMarkupPrice1), new SqlParameter("@Zone_Side2_PressMarkupPrice2", (object)Zone_Side2_PressMarkupPrice2), new SqlParameter("@Zone_Side2_PressMarkupPrice3", (object)Zone_Side2_PressMarkupPrice3), new SqlParameter("@Zone_Side2_PressMarkupPrice4", (object)Zone_Side2_PressMarkupPrice4), new SqlParameter("@Zone_Side1_PressCostExMarkup1", (object)Zone_Side1_PressCostExMarkup1), new SqlParameter("@Zone_Side1_PressCostExMarkup2", (object)Zone_Side1_PressCostExMarkup2), new SqlParameter("@Zone_Side1_PressCostExMarkup3", (object)Zone_Side1_PressCostExMarkup3), new SqlParameter("@Zone_Side1_PressCostExMarkup4", (object)Zone_Side1_PressCostExMarkup4), new SqlParameter("@Zone_Side2_PressCostExMarkup1", (object)Zone_Side2_PressCostExMarkup1), new SqlParameter("@Zone_Side2_PressCostExMarkup2", (object)Zone_Side2_PressCostExMarkup2), new SqlParameter("@Zone_Side2_PressCostExMarkup3", (object)Zone_Side2_PressCostExMarkup3), new SqlParameter("@Zone_Side2_PressCostExMarkup4", (object)Zone_Side2_PressCostExMarkup4), new SqlParameter("@PaperLength1", (object)PaperLength1), new SqlParameter("@PaperLength2", (object)PaperLength2), new SqlParameter("@PaperLength3", (object)PaperLength3), new SqlParameter("@PaperLength4", (object)PaperLength4), new SqlParameter("@PressCostExMarkup_Actual1", (object)PressCostExMarkup_Actual1), new SqlParameter("@PressCostExMarkup_Actual2", (object)PressCostExMarkup_Actual2), new SqlParameter("@PressCostExMarkup_Actual3", (object)PressCostExMarkup_Actual3), new SqlParameter("@PressCostExMarkup_Actual4", (object)PressCostExMarkup_Actual4), new SqlParameter("@GuillotineCostExMarkup_Actual1", (object)GuillotineCostExMarkup_Actual1), new SqlParameter("@GuillotineCostExMarkup_Actual2", (object)GuillotineCostExMarkup_Actual2), new SqlParameter("@GuillotineCostExMarkup_Actual3", (object)GuillotineCostExMarkup_Actual3), new SqlParameter("@GuillotineCostExMarkup_Actual4", (object)GuillotineCostExMarkup_Actual4) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_quantity_insert_large_item", sqlParameterArray);
		}

		public virtual void quantity_insert_new(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_Cost1, decimal Zone_Side1_Cost2, decimal Zone_Side1_Cost3, decimal Zone_Side1_Cost4, decimal Zone_Side2_Cost1, decimal Zone_Side2_Cost2, decimal Zone_Side2_Cost3, decimal Zone_Side2_Cost4)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Qty1", (object)Qty1), new SqlParameter("@InvSheets1", (object)InvSheets1), new SqlParameter("@PrintSheets1", (object)PrintSheets1), new SqlParameter("@PaperCostExMarkup1", (object)PaperCostExMarkup1), new SqlParameter("@PaperMarkupPrice1", (object)PaperMarkupPrice1), new SqlParameter("@PressCostExMarkup1", (object)PressCostExMarkup1), new SqlParameter("@PressMarkupPrice1", (object)PressMarkupPrice1), new SqlParameter("@FirstTrimCuts1", (object)FirstTrimCuts1), new SqlParameter("@FirstTrimNoOfBundles1", (object)FirstTrimNoOfBundles1), new SqlParameter("@SecondTrimCuts1", (object)SecondTrimCuts1), new SqlParameter("@SecondTrimNoOfBundles1", (object)SecondTrimNoOfBundles1), new SqlParameter("@GuillotineCostExMarkup1", (object)GuillotineCostExMarkup1), new SqlParameter("@GuillotineMarkupPrice1", (object)GuillotineMarkupPrice1), new SqlParameter("@Qty2", (object)Qty2), new SqlParameter("@InvSheets2", (object)InvSheets2), new SqlParameter("@PrintSheets2", (object)PrintSheets2), new SqlParameter("@PaperCostExMarkup2", (object)PaperCostExMarkup2), new SqlParameter("@PaperMarkupPrice2", (object)PaperMarkupPrice2), new SqlParameter("@PressCostExMarkup2", (object)PressCostExMarkup2), new SqlParameter("@PressMarkupPrice2", (object)PressMarkupPrice2), new SqlParameter("@FirstTrimCuts2", (object)FirstTrimCuts2), new SqlParameter("@FirstTrimNoOfBundles2", (object)FirstTrimNoOfBundles2), new SqlParameter("@SecondTrimCuts2", (object)SecondTrimCuts2), new SqlParameter("@SecondTrimNoOfBundles2", (object)SecondTrimNoOfBundles2), new SqlParameter("@GuillotineCostExMarkup2", (object)GuillotineCostExMarkup2), new SqlParameter("@GuillotineMarkupPrice2", (object)GuillotineMarkupPrice2), new SqlParameter("@Qty3", (object)Qty3), new SqlParameter("@InvSheets3", (object)InvSheets3), new SqlParameter("@PrintSheets3", (object)PrintSheets3), new SqlParameter("@PaperCostExMarkup3", (object)PaperCostExMarkup3), new SqlParameter("@PaperMarkupPrice3", (object)PaperMarkupPrice3), new SqlParameter("@PressCostExMarkup3", (object)PressCostExMarkup3), new SqlParameter("@PressMarkupPrice3", (object)PressMarkupPrice3), new SqlParameter("@FirstTrimCuts3", (object)FirstTrimCuts3), new SqlParameter("@FirstTrimNoOfBundles3", (object)FirstTrimNoOfBundles3), new SqlParameter("@SecondTrimCuts3", (object)SecondTrimCuts3), new SqlParameter("@SecondTrimNoOfBundles3", (object)SecondTrimNoOfBundles3), new SqlParameter("@GuillotineCostExMarkup3", (object)GuillotineCostExMarkup3), new SqlParameter("@GuillotineMarkupPrice3", (object)GuillotineMarkupPrice3), new SqlParameter("@Qty4", (object)Qty4), new SqlParameter("@InvSheets4", (object)InvSheets4), new SqlParameter("@PrintSheets4", (object)PrintSheets4), new SqlParameter("@PaperCostExMarkup4", (object)PaperCostExMarkup4), new SqlParameter("@PaperMarkupPrice4", (object)PaperMarkupPrice4), new SqlParameter("@PressCostExMarkup4", (object)PressCostExMarkup4), new SqlParameter("@PressMarkupPrice4", (object)PressMarkupPrice4), new SqlParameter("@FirstTrimCuts4", (object)FirstTrimCuts4), new SqlParameter("@FirstTrimNoOfBundles4", (object)FirstTrimNoOfBundles4), new SqlParameter("@SecondTrimCuts4", (object)SecondTrimCuts4), new SqlParameter("@SecondTrimNoOfBundles4", (object)SecondTrimNoOfBundles4), new SqlParameter("@GuillotineCostExMarkup4", (object)GuillotineCostExMarkup4), new SqlParameter("@GuillotineMarkupPrice4", (object)GuillotineMarkupPrice4), new SqlParameter("@QueryType", QueryType), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@PressJobTimeSide11", (object)PressJobTimeSide11), new SqlParameter("@PressJobTimeSide12", (object)PressJobTimeSide12), new SqlParameter("@PressJobTimeSide13", (object)PressJobTimeSide13), new SqlParameter("@PressJobTimeSide14", (object)PressJobTimeSide14), new SqlParameter("@PressJobTimeSide21", (object)PressJobTimeSide21), new SqlParameter("@PressJobTimeSide22", (object)PressJobTimeSide22), new SqlParameter("@PressJobTimeSide23", (object)PressJobTimeSide23), new SqlParameter("@PressJobTimeSide24", (object)PressJobTimeSide24), new SqlParameter("@Zone_Side1_PressMarkupPercentage1", (object)Zone_Side1_PressMarkupPercentage1), new SqlParameter("@Zone_Side1_PressMarkupPercentage2", (object)Zone_Side1_PressMarkupPercentage2), new SqlParameter("@Zone_Side1_PressMarkupPercentage3", (object)Zone_Side1_PressMarkupPercentage3), new SqlParameter("@Zone_Side1_PressMarkupPercentage4", (object)Zone_Side1_PressMarkupPercentage4), new SqlParameter("@Zone_Side2_PressMarkupPercentage1", (object)Zone_Side2_PressMarkupPercentage1), new SqlParameter("@Zone_Side2_PressMarkupPercentage2", (object)Zone_Side2_PressMarkupPercentage2), new SqlParameter("@Zone_Side2_PressMarkupPercentage3", (object)Zone_Side2_PressMarkupPercentage3), new SqlParameter("@Zone_Side2_PressMarkupPercentage4", (object)Zone_Side2_PressMarkupPercentage4), new SqlParameter("@Zone_Side1_PressMarkupPrice1", (object)Zone_Side1_PressMarkupPrice1), new SqlParameter("@Zone_Side1_PressMarkupPrice2", (object)Zone_Side1_PressMarkupPrice2), new SqlParameter("@Zone_Side1_PressMarkupPrice3", (object)Zone_Side1_PressMarkupPrice3), new SqlParameter("@Zone_Side1_PressMarkupPrice4", (object)Zone_Side1_PressMarkupPrice4), new SqlParameter("@Zone_Side2_PressMarkupPrice1", (object)Zone_Side2_PressMarkupPrice1), new SqlParameter("@Zone_Side2_PressMarkupPrice2", (object)Zone_Side2_PressMarkupPrice2), new SqlParameter("@Zone_Side2_PressMarkupPrice3", (object)Zone_Side2_PressMarkupPrice3), new SqlParameter("@Zone_Side2_PressMarkupPrice4", (object)Zone_Side2_PressMarkupPrice4), new SqlParameter("@Zone_Side1_PressCostExMarkup1", (object)Zone_Side1_PressCostExMarkup1), new SqlParameter("@Zone_Side1_PressCostExMarkup2", (object)Zone_Side1_PressCostExMarkup2), new SqlParameter("@Zone_Side1_PressCostExMarkup3", (object)Zone_Side1_PressCostExMarkup3), new SqlParameter("@Zone_Side1_PressCostExMarkup4", (object)Zone_Side1_PressCostExMarkup4), new SqlParameter("@Zone_Side2_PressCostExMarkup1", (object)Zone_Side2_PressCostExMarkup1), new SqlParameter("@Zone_Side2_PressCostExMarkup2", (object)Zone_Side2_PressCostExMarkup2), new SqlParameter("@Zone_Side2_PressCostExMarkup3", (object)Zone_Side2_PressCostExMarkup3), new SqlParameter("@Zone_Side2_PressCostExMarkup4", (object)Zone_Side2_PressCostExMarkup4), new SqlParameter("@Zone_Side1_ChargeableRate1", (object)Zone_Side1_ChargeableRate1), new SqlParameter("@Zone_Side1_ChargeableRate2", (object)Zone_Side1_ChargeableRate2), new SqlParameter("@Zone_Side1_ChargeableRate3", (object)Zone_Side1_ChargeableRate3), new SqlParameter("@Zone_Side1_ChargeableRate4", (object)Zone_Side1_ChargeableRate4), new SqlParameter("@Zone_Side2_ChargeableRate1", (object)Zone_Side2_ChargeableRate1), new SqlParameter("@Zone_Side2_ChargeableRate2", (object)Zone_Side2_ChargeableRate2), new SqlParameter("@Zone_Side2_ChargeableRate3", (object)Zone_Side2_ChargeableRate3), new SqlParameter("@Zone_Side2_ChargeableRate4", (object)Zone_Side2_ChargeableRate4), new SqlParameter("@PressCostExMarkup_Actual1", (object)PressCostExMarkup_Actual1), new SqlParameter("@PressCostExMarkup_Actual2", (object)PressCostExMarkup_Actual2), new SqlParameter("@PressCostExMarkup_Actual3", (object)PressCostExMarkup_Actual3), new SqlParameter("@PressCostExMarkup_Actual4", (object)PressCostExMarkup_Actual4), new SqlParameter("@GuillotineCostExMarkup_Actual1", (object)GuillotineCostExMarkup_Actual1), new SqlParameter("@GuillotineCostExMarkup_Actual2", (object)GuillotineCostExMarkup_Actual2), new SqlParameter("@GuillotineCostExMarkup_Actual3", (object)GuillotineCostExMarkup_Actual3), new SqlParameter("@GuillotineCostExMarkup_Actual4", (object)GuillotineCostExMarkup_Actual4), new SqlParameter("@Zone_Side1_Cost1", (object)Zone_Side1_Cost1), new SqlParameter("@Zone_Side1_Cost2", (object)Zone_Side1_Cost2), new SqlParameter("@Zone_Side1_Cost3", (object)Zone_Side1_Cost3), new SqlParameter("@Zone_Side1_Cost4", (object)Zone_Side1_Cost4), new SqlParameter("@Zone_Side2_Cost1", (object)Zone_Side2_Cost1), new SqlParameter("@Zone_Side2_Cost2", (object)Zone_Side2_Cost2), new SqlParameter("@Zone_Side2_Cost3", (object)Zone_Side2_Cost3), new SqlParameter("@Zone_Side2_Cost4", (object)Zone_Side2_Cost4) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_quantity_insert_new", sqlParameterArray);
		}

		public virtual void quantity_insert_offset_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateType", EstimateType), new SqlParameter("@Qty1", (object)Qty1), new SqlParameter("@InvSheets1", (object)InvSheets1), new SqlParameter("@PrintSheets1", (object)PrintSheets1), new SqlParameter("@PaperCostExMarkup1", (object)PaperCostExMarkup1), new SqlParameter("@PaperMarkupPrice1", (object)PaperMarkupPrice1), new SqlParameter("@PressCostExMarkup1", (object)PressCostExMarkup1), new SqlParameter("@PressMarkupPrice1", (object)PressMarkupPrice1), new SqlParameter("@FirstTrimCuts1", (object)FirstTrimCuts1), new SqlParameter("@FirstTrimNoOfBundles1", (object)FirstTrimNoOfBundles1), new SqlParameter("@SecondTrimCuts1", (object)SecondTrimCuts1), new SqlParameter("@SecondTrimNoOfBundles1", (object)SecondTrimNoOfBundles1), new SqlParameter("@GuillotineCostExMarkup1", (object)GuillotineCostExMarkup1), new SqlParameter("@GuillotineMarkupPrice1", (object)GuillotineMarkupPrice1), new SqlParameter("@InkCostExMarkup1", (object)InkCostExMarkup1), new SqlParameter("@InkMarkupPrice1", (object)InkMarkupPrice1), new SqlParameter("@PlatesCostExMarkup1", (object)PlatesCostExMarkup1), new SqlParameter("@PlatesMarkupPrice1", (object)PlatesMarkupPrice1), new SqlParameter("@MakeReadyCostExMarkup1", (object)MakeReadyCostExMarkup1), new SqlParameter("@MakeReadyMarkupPrice1", (object)MakeReadyMarkupPrice1), new SqlParameter("@WashUpCostExMarkup1", (object)WashUpCostExMarkup1), new SqlParameter("@WashUpMarkupPrice1", (object)WashUpMarkupPrice1), new SqlParameter("@Qty2", (object)Qty2), new SqlParameter("@InvSheets2", (object)InvSheets2), new SqlParameter("@PrintSheets2", (object)PrintSheets2), new SqlParameter("@PaperCostExMarkup2", (object)PaperCostExMarkup2), new SqlParameter("@PaperMarkupPrice2", (object)PaperMarkupPrice2), new SqlParameter("@PressCostExMarkup2", (object)PressCostExMarkup2), new SqlParameter("@PressMarkupPrice2", (object)PressMarkupPrice2), new SqlParameter("@FirstTrimCuts2", (object)FirstTrimCuts2), new SqlParameter("@FirstTrimNoOfBundles2", (object)FirstTrimNoOfBundles2), new SqlParameter("@SecondTrimCuts2", (object)SecondTrimCuts2), new SqlParameter("@SecondTrimNoOfBundles2", (object)SecondTrimNoOfBundles2), new SqlParameter("@GuillotineCostExMarkup2", (object)GuillotineCostExMarkup2), new SqlParameter("@GuillotineMarkupPrice2", (object)GuillotineMarkupPrice2), new SqlParameter("@InkCostExMarkup2", (object)InkCostExMarkup2), new SqlParameter("@InkMarkupPrice2", (object)InkMarkupPrice2), new SqlParameter("@PlatesCostExMarkup2", (object)PlatesCostExMarkup2), new SqlParameter("@PlatesMarkupPrice2", (object)PlatesMarkupPrice2), new SqlParameter("@MakeReadyCostExMarkup2", (object)MakeReadyCostExMarkup2), new SqlParameter("@MakeReadyMarkupPrice2", (object)MakeReadyMarkupPrice2), new SqlParameter("@WashUpCostExMarkup2", (object)WashUpCostExMarkup2), new SqlParameter("@WashUpMarkupPrice2", (object)WashUpMarkupPrice2), new SqlParameter("@Qty3", (object)Qty3), new SqlParameter("@InvSheets3", (object)InvSheets3), new SqlParameter("@PrintSheets3", (object)PrintSheets3), new SqlParameter("@PaperCostExMarkup3", (object)PaperCostExMarkup3), new SqlParameter("@PaperMarkupPrice3", (object)PaperMarkupPrice3), new SqlParameter("@PressCostExMarkup3", (object)PressCostExMarkup3), new SqlParameter("@PressMarkupPrice3", (object)PressMarkupPrice3), new SqlParameter("@FirstTrimCuts3", (object)FirstTrimCuts3), new SqlParameter("@FirstTrimNoOfBundles3", (object)FirstTrimNoOfBundles3), new SqlParameter("@SecondTrimCuts3", (object)SecondTrimCuts3), new SqlParameter("@SecondTrimNoOfBundles3", (object)SecondTrimNoOfBundles3), new SqlParameter("@GuillotineCostExMarkup3", (object)GuillotineCostExMarkup3), new SqlParameter("@GuillotineMarkupPrice3", (object)GuillotineMarkupPrice3), new SqlParameter("@InkCostExMarkup3", (object)InkCostExMarkup3), new SqlParameter("@InkMarkupPrice3", (object)InkMarkupPrice3), new SqlParameter("@PlatesCostExMarkup3", (object)PlatesCostExMarkup3), new SqlParameter("@PlatesMarkupPrice3", (object)PlatesMarkupPrice3), new SqlParameter("@MakeReadyCostExMarkup3", (object)MakeReadyCostExMarkup3), new SqlParameter("@MakeReadyMarkupPrice3", (object)MakeReadyMarkupPrice3), new SqlParameter("@WashUpCostExMarkup3", (object)WashUpCostExMarkup3), new SqlParameter("@WashUpMarkupPrice3", (object)WashUpMarkupPrice3), new SqlParameter("@Qty4", (object)Qty4), new SqlParameter("@InvSheets4", (object)InvSheets4), new SqlParameter("@PrintSheets4", (object)PrintSheets4), new SqlParameter("@PaperCostExMarkup4", (object)PaperCostExMarkup4), new SqlParameter("@PaperMarkupPrice4", (object)PaperMarkupPrice4), new SqlParameter("@PressCostExMarkup4", (object)PressCostExMarkup4), new SqlParameter("@PressMarkupPrice4", (object)PressMarkupPrice4), new SqlParameter("@FirstTrimCuts4", (object)FirstTrimCuts4), new SqlParameter("@FirstTrimNoOfBundles4", (object)FirstTrimNoOfBundles4), new SqlParameter("@SecondTrimCuts4", (object)SecondTrimCuts4), new SqlParameter("@SecondTrimNoOfBundles4", (object)SecondTrimNoOfBundles4), new SqlParameter("@GuillotineCostExMarkup4", (object)GuillotineCostExMarkup4), new SqlParameter("@GuillotineMarkupPrice4", (object)GuillotineMarkupPrice4), new SqlParameter("@InkCostExMarkup4", (object)InkCostExMarkup4), new SqlParameter("@InkMarkupPrice4", (object)InkMarkupPrice4), new SqlParameter("@PlatesCostExMarkup4", (object)PlatesCostExMarkup4), new SqlParameter("@PlatesMarkupPrice4", (object)PlatesMarkupPrice4), new SqlParameter("@MakeReadyCostExMarkup4", (object)MakeReadyCostExMarkup4), new SqlParameter("@MakeReadyMarkupPrice4", (object)MakeReadyMarkupPrice4), new SqlParameter("@WashUpCostExMarkup4", (object)WashUpCostExMarkup4), new SqlParameter("@WashUpMarkupPrice4", (object)WashUpMarkupPrice4), new SqlParameter("@QueryType", QueryType), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@PressJobTimeSide11", (object)PressJobTimeSide11), new SqlParameter("@PressJobTimeSide12", (object)PressJobTimeSide12), new SqlParameter("@PressJobTimeSide13", (object)PressJobTimeSide13), new SqlParameter("@PressJobTimeSide14", (object)PressJobTimeSide14), new SqlParameter("@PressJobTimeSide21", (object)PressJobTimeSide21), new SqlParameter("@PressJobTimeSide22", (object)PressJobTimeSide22), new SqlParameter("@PressJobTimeSide23", (object)PressJobTimeSide23), new SqlParameter("@PressJobTimeSide24", (object)PressJobTimeSide24), new SqlParameter("@Zone_Side1_PressMarkupPercentage1", (object)Zone_Side1_PressMarkupPercentage1), new SqlParameter("@Zone_Side1_PressMarkupPercentage2", (object)Zone_Side1_PressMarkupPercentage2), new SqlParameter("@Zone_Side1_PressMarkupPercentage3", (object)Zone_Side1_PressMarkupPercentage3), new SqlParameter("@Zone_Side1_PressMarkupPercentage4", (object)Zone_Side1_PressMarkupPercentage4), new SqlParameter("@Zone_Side2_PressMarkupPercentage1", (object)Zone_Side2_PressMarkupPercentage1), new SqlParameter("@Zone_Side2_PressMarkupPercentage2", (object)Zone_Side2_PressMarkupPercentage2), new SqlParameter("@Zone_Side2_PressMarkupPercentage3", (object)Zone_Side2_PressMarkupPercentage3), new SqlParameter("@Zone_Side2_PressMarkupPercentage4", (object)Zone_Side2_PressMarkupPercentage4), new SqlParameter("@Zone_Side1_PressMarkupPrice1", (object)Zone_Side1_PressMarkupPrice1), new SqlParameter("@Zone_Side1_PressMarkupPrice2", (object)Zone_Side1_PressMarkupPrice2), new SqlParameter("@Zone_Side1_PressMarkupPrice3", (object)Zone_Side1_PressMarkupPrice3), new SqlParameter("@Zone_Side1_PressMarkupPrice4", (object)Zone_Side1_PressMarkupPrice4), new SqlParameter("@Zone_Side2_PressMarkupPrice1", (object)Zone_Side2_PressMarkupPrice1), new SqlParameter("@Zone_Side2_PressMarkupPrice2", (object)Zone_Side2_PressMarkupPrice2), new SqlParameter("@Zone_Side2_PressMarkupPrice3", (object)Zone_Side2_PressMarkupPrice3), new SqlParameter("@Zone_Side2_PressMarkupPrice4", (object)Zone_Side2_PressMarkupPrice4), new SqlParameter("@Zone_Side1_PressCostExMarkup1", (object)Zone_Side1_PressCostExMarkup1), new SqlParameter("@Zone_Side1_PressCostExMarkup2", (object)Zone_Side1_PressCostExMarkup2), new SqlParameter("@Zone_Side1_PressCostExMarkup3", (object)Zone_Side1_PressCostExMarkup3), new SqlParameter("@Zone_Side1_PressCostExMarkup4", (object)Zone_Side1_PressCostExMarkup4), new SqlParameter("@Zone_Side2_PressCostExMarkup1", (object)Zone_Side2_PressCostExMarkup1), new SqlParameter("@Zone_Side2_PressCostExMarkup2", (object)Zone_Side2_PressCostExMarkup2), new SqlParameter("@Zone_Side2_PressCostExMarkup3", (object)Zone_Side2_PressCostExMarkup3), new SqlParameter("@Zone_Side2_PressCostExMarkup4", (object)Zone_Side2_PressCostExMarkup4), new SqlParameter("@PressCostExMarkup_Actual1", (object)PressCostExMarkup_Actual1), new SqlParameter("@PressCostExMarkup_Actual2", (object)PressCostExMarkup_Actual2), new SqlParameter("@PressCostExMarkup_Actual3", (object)PressCostExMarkup_Actual3), new SqlParameter("@PressCostExMarkup_Actual4", (object)PressCostExMarkup_Actual4), new SqlParameter("@GuillotineCostExMarkup_Actual1", (object)GuillotineCostExMarkup_Actual1), new SqlParameter("@GuillotineCostExMarkup_Actual2", (object)GuillotineCostExMarkup_Actual2), new SqlParameter("@GuillotineCostExMarkup_Actual3", (object)GuillotineCostExMarkup_Actual3), new SqlParameter("@GuillotineCostExMarkup_Actual4", (object)GuillotineCostExMarkup_Actual4) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_quantity_insert_offset_item", sqlParameterArray);
		}

        public virtual void quantity_insert_digital_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateType", EstimateType), new SqlParameter("@Qty1", (object)Qty1), new SqlParameter("@InvSheets1", (object)InvSheets1), new SqlParameter("@PrintSheets1", (object)PrintSheets1), new SqlParameter("@PaperCostExMarkup1", (object)PaperCostExMarkup1), new SqlParameter("@PaperMarkupPrice1", (object)PaperMarkupPrice1), new SqlParameter("@PressCostExMarkup1", (object)PressCostExMarkup1), new SqlParameter("@PressMarkupPrice1", (object)PressMarkupPrice1), new SqlParameter("@FirstTrimCuts1", (object)FirstTrimCuts1), new SqlParameter("@FirstTrimNoOfBundles1", (object)FirstTrimNoOfBundles1), new SqlParameter("@SecondTrimCuts1", (object)SecondTrimCuts1), new SqlParameter("@SecondTrimNoOfBundles1", (object)SecondTrimNoOfBundles1), new SqlParameter("@GuillotineCostExMarkup1", (object)GuillotineCostExMarkup1), new SqlParameter("@GuillotineMarkupPrice1", (object)GuillotineMarkupPrice1), new SqlParameter("@InkCostExMarkup1", (object)InkCostExMarkup1), new SqlParameter("@InkMarkupPrice1", (object)InkMarkupPrice1), new SqlParameter("@PlatesCostExMarkup1", (object)PlatesCostExMarkup1), new SqlParameter("@PlatesMarkupPrice1", (object)PlatesMarkupPrice1), new SqlParameter("@MakeReadyCostExMarkup1", (object)MakeReadyCostExMarkup1), new SqlParameter("@MakeReadyMarkupPrice1", (object)MakeReadyMarkupPrice1), new SqlParameter("@WashUpCostExMarkup1", (object)WashUpCostExMarkup1), new SqlParameter("@WashUpMarkupPrice1", (object)WashUpMarkupPrice1), new SqlParameter("@Qty2", (object)Qty2), new SqlParameter("@InvSheets2", (object)InvSheets2), new SqlParameter("@PrintSheets2", (object)PrintSheets2), new SqlParameter("@PaperCostExMarkup2", (object)PaperCostExMarkup2), new SqlParameter("@PaperMarkupPrice2", (object)PaperMarkupPrice2), new SqlParameter("@PressCostExMarkup2", (object)PressCostExMarkup2), new SqlParameter("@PressMarkupPrice2", (object)PressMarkupPrice2), new SqlParameter("@FirstTrimCuts2", (object)FirstTrimCuts2), new SqlParameter("@FirstTrimNoOfBundles2", (object)FirstTrimNoOfBundles2), new SqlParameter("@SecondTrimCuts2", (object)SecondTrimCuts2), new SqlParameter("@SecondTrimNoOfBundles2", (object)SecondTrimNoOfBundles2), new SqlParameter("@GuillotineCostExMarkup2", (object)GuillotineCostExMarkup2), new SqlParameter("@GuillotineMarkupPrice2", (object)GuillotineMarkupPrice2), new SqlParameter("@InkCostExMarkup2", (object)InkCostExMarkup2), new SqlParameter("@InkMarkupPrice2", (object)InkMarkupPrice2), new SqlParameter("@PlatesCostExMarkup2", (object)PlatesCostExMarkup2), new SqlParameter("@PlatesMarkupPrice2", (object)PlatesMarkupPrice2), new SqlParameter("@MakeReadyCostExMarkup2", (object)MakeReadyCostExMarkup2), new SqlParameter("@MakeReadyMarkupPrice2", (object)MakeReadyMarkupPrice2), new SqlParameter("@WashUpCostExMarkup2", (object)WashUpCostExMarkup2), new SqlParameter("@WashUpMarkupPrice2", (object)WashUpMarkupPrice2), new SqlParameter("@Qty3", (object)Qty3), new SqlParameter("@InvSheets3", (object)InvSheets3), new SqlParameter("@PrintSheets3", (object)PrintSheets3), new SqlParameter("@PaperCostExMarkup3", (object)PaperCostExMarkup3), new SqlParameter("@PaperMarkupPrice3", (object)PaperMarkupPrice3), new SqlParameter("@PressCostExMarkup3", (object)PressCostExMarkup3), new SqlParameter("@PressMarkupPrice3", (object)PressMarkupPrice3), new SqlParameter("@FirstTrimCuts3", (object)FirstTrimCuts3), new SqlParameter("@FirstTrimNoOfBundles3", (object)FirstTrimNoOfBundles3), new SqlParameter("@SecondTrimCuts3", (object)SecondTrimCuts3), new SqlParameter("@SecondTrimNoOfBundles3", (object)SecondTrimNoOfBundles3), new SqlParameter("@GuillotineCostExMarkup3", (object)GuillotineCostExMarkup3), new SqlParameter("@GuillotineMarkupPrice3", (object)GuillotineMarkupPrice3), new SqlParameter("@InkCostExMarkup3", (object)InkCostExMarkup3), new SqlParameter("@InkMarkupPrice3", (object)InkMarkupPrice3), new SqlParameter("@PlatesCostExMarkup3", (object)PlatesCostExMarkup3), new SqlParameter("@PlatesMarkupPrice3", (object)PlatesMarkupPrice3), new SqlParameter("@MakeReadyCostExMarkup3", (object)MakeReadyCostExMarkup3), new SqlParameter("@MakeReadyMarkupPrice3", (object)MakeReadyMarkupPrice3), new SqlParameter("@WashUpCostExMarkup3", (object)WashUpCostExMarkup3), new SqlParameter("@WashUpMarkupPrice3", (object)WashUpMarkupPrice3), new SqlParameter("@Qty4", (object)Qty4), new SqlParameter("@InvSheets4", (object)InvSheets4), new SqlParameter("@PrintSheets4", (object)PrintSheets4), new SqlParameter("@PaperCostExMarkup4", (object)PaperCostExMarkup4), new SqlParameter("@PaperMarkupPrice4", (object)PaperMarkupPrice4), new SqlParameter("@PressCostExMarkup4", (object)PressCostExMarkup4), new SqlParameter("@PressMarkupPrice4", (object)PressMarkupPrice4), new SqlParameter("@FirstTrimCuts4", (object)FirstTrimCuts4), new SqlParameter("@FirstTrimNoOfBundles4", (object)FirstTrimNoOfBundles4), new SqlParameter("@SecondTrimCuts4", (object)SecondTrimCuts4), new SqlParameter("@SecondTrimNoOfBundles4", (object)SecondTrimNoOfBundles4), new SqlParameter("@GuillotineCostExMarkup4", (object)GuillotineCostExMarkup4), new SqlParameter("@GuillotineMarkupPrice4", (object)GuillotineMarkupPrice4), new SqlParameter("@InkCostExMarkup4", (object)InkCostExMarkup4), new SqlParameter("@InkMarkupPrice4", (object)InkMarkupPrice4), new SqlParameter("@PlatesCostExMarkup4", (object)PlatesCostExMarkup4), new SqlParameter("@PlatesMarkupPrice4", (object)PlatesMarkupPrice4), new SqlParameter("@MakeReadyCostExMarkup4", (object)MakeReadyCostExMarkup4), new SqlParameter("@MakeReadyMarkupPrice4", (object)MakeReadyMarkupPrice4), new SqlParameter("@WashUpCostExMarkup4", (object)WashUpCostExMarkup4), new SqlParameter("@WashUpMarkupPrice4", (object)WashUpMarkupPrice4), new SqlParameter("@QueryType", QueryType), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@PressJobTimeSide11", (object)PressJobTimeSide11), new SqlParameter("@PressJobTimeSide12", (object)PressJobTimeSide12), new SqlParameter("@PressJobTimeSide13", (object)PressJobTimeSide13), new SqlParameter("@PressJobTimeSide14", (object)PressJobTimeSide14), new SqlParameter("@PressJobTimeSide21", (object)PressJobTimeSide21), new SqlParameter("@PressJobTimeSide22", (object)PressJobTimeSide22), new SqlParameter("@PressJobTimeSide23", (object)PressJobTimeSide23), new SqlParameter("@PressJobTimeSide24", (object)PressJobTimeSide24), new SqlParameter("@Zone_Side1_PressMarkupPercentage1", (object)Zone_Side1_PressMarkupPercentage1), new SqlParameter("@Zone_Side1_PressMarkupPercentage2", (object)Zone_Side1_PressMarkupPercentage2), new SqlParameter("@Zone_Side1_PressMarkupPercentage3", (object)Zone_Side1_PressMarkupPercentage3), new SqlParameter("@Zone_Side1_PressMarkupPercentage4", (object)Zone_Side1_PressMarkupPercentage4), new SqlParameter("@Zone_Side2_PressMarkupPercentage1", (object)Zone_Side2_PressMarkupPercentage1), new SqlParameter("@Zone_Side2_PressMarkupPercentage2", (object)Zone_Side2_PressMarkupPercentage2), new SqlParameter("@Zone_Side2_PressMarkupPercentage3", (object)Zone_Side2_PressMarkupPercentage3), new SqlParameter("@Zone_Side2_PressMarkupPercentage4", (object)Zone_Side2_PressMarkupPercentage4), new SqlParameter("@Zone_Side1_PressMarkupPrice1", (object)Zone_Side1_PressMarkupPrice1), new SqlParameter("@Zone_Side1_PressMarkupPrice2", (object)Zone_Side1_PressMarkupPrice2), new SqlParameter("@Zone_Side1_PressMarkupPrice3", (object)Zone_Side1_PressMarkupPrice3), new SqlParameter("@Zone_Side1_PressMarkupPrice4", (object)Zone_Side1_PressMarkupPrice4), new SqlParameter("@Zone_Side2_PressMarkupPrice1", (object)Zone_Side2_PressMarkupPrice1), new SqlParameter("@Zone_Side2_PressMarkupPrice2", (object)Zone_Side2_PressMarkupPrice2), new SqlParameter("@Zone_Side2_PressMarkupPrice3", (object)Zone_Side2_PressMarkupPrice3), new SqlParameter("@Zone_Side2_PressMarkupPrice4", (object)Zone_Side2_PressMarkupPrice4), new SqlParameter("@Zone_Side1_PressCostExMarkup1", (object)Zone_Side1_PressCostExMarkup1), new SqlParameter("@Zone_Side1_PressCostExMarkup2", (object)Zone_Side1_PressCostExMarkup2), new SqlParameter("@Zone_Side1_PressCostExMarkup3", (object)Zone_Side1_PressCostExMarkup3), new SqlParameter("@Zone_Side1_PressCostExMarkup4", (object)Zone_Side1_PressCostExMarkup4), new SqlParameter("@Zone_Side2_PressCostExMarkup1", (object)Zone_Side2_PressCostExMarkup1), new SqlParameter("@Zone_Side2_PressCostExMarkup2", (object)Zone_Side2_PressCostExMarkup2), new SqlParameter("@Zone_Side2_PressCostExMarkup3", (object)Zone_Side2_PressCostExMarkup3), new SqlParameter("@Zone_Side2_PressCostExMarkup4", (object)Zone_Side2_PressCostExMarkup4), new SqlParameter("@PressCostExMarkup_Actual1", (object)PressCostExMarkup_Actual1), new SqlParameter("@PressCostExMarkup_Actual2", (object)PressCostExMarkup_Actual2), new SqlParameter("@PressCostExMarkup_Actual3", (object)PressCostExMarkup_Actual3), new SqlParameter("@PressCostExMarkup_Actual4", (object)PressCostExMarkup_Actual4), new SqlParameter("@GuillotineCostExMarkup_Actual1", (object)GuillotineCostExMarkup_Actual1), new SqlParameter("@GuillotineCostExMarkup_Actual2", (object)GuillotineCostExMarkup_Actual2), new SqlParameter("@GuillotineCostExMarkup_Actual3", (object)GuillotineCostExMarkup_Actual3), new SqlParameter("@GuillotineCostExMarkup_Actual4", (object)GuillotineCostExMarkup_Actual4), new SqlParameter("@Zone_Side1_ChargeableRate1", (object)Zone_Side1_ChargeableRate1), new SqlParameter("@Zone_Side1_ChargeableRate2", (object)Zone_Side1_ChargeableRate2), new SqlParameter("@Zone_Side1_ChargeableRate3", (object)Zone_Side1_ChargeableRate3), new SqlParameter("@Zone_Side1_ChargeableRate4", (object)Zone_Side1_ChargeableRate4), new SqlParameter("@Zone_Side2_ChargeableRate1", (object)Zone_Side2_ChargeableRate1), new SqlParameter("@Zone_Side2_ChargeableRate2", (object)Zone_Side2_ChargeableRate2), new SqlParameter("@Zone_Side2_ChargeableRate3", (object)Zone_Side2_ChargeableRate3), new SqlParameter("@Zone_Side2_ChargeableRate4", (object)Zone_Side2_ChargeableRate4) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            commonClass _commonClass = new commonClass();
            SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_quantity_insert_digital_item", sqlParameterArray);
        }

        public virtual DataTable quantity_Select_forOtherCost(long EstimateItemID, string QueryType, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_quantity_Select_forOtherCost");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, QueryType);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public DataTable DeliveryCost_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryCost_Description_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable deliverycost_item_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_deliverycost_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable QuickQuote_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_QuickQuote_Description_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

        public virtual DataTable estimate_DeliveryCost_item_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PCR_DeliveryCost_item_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable quickquote_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_quickquote_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void Update_InvStock_calculation(long EstimatesItem, decimal InvStock)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_InvStock_calculation");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimatesItem);
			database.AddInParameter(storedProcCommand, "@InvStock", DbType.Decimal, InvStock);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Estimate_DeliveryCost_insert(EstimatesItem item, bool IsHandy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_DeliveryCost_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, item.EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Quantity1", DbType.Int32, item.Quantity1);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddInParameter(storedProcCommand, "@Profitmargin", DbType.Decimal, item.Profitmargin);
            database.AddInParameter(storedProcCommand, "@Subtotal1", DbType.Decimal, item.Subtotal1);
            database.AddInParameter(storedProcCommand, "@CostPrice1", DbType.Decimal, item.CostPrice1);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, item.Tax);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
            database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, item.SellingPrice);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.Int64, item.QuickQuoteID);
            database.AddInParameter(storedProcCommand, "@Iscompleted", DbType.Int32, item.Iscompleted);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, item.ModuleType);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void SaveQtyDescription(long EstimateItemID, string Qtydesc1, string Qtydesc2, string Qtydesc3, string Qtydesc4, int CompanyID)
		{
			commonClass _commonClass = new commonClass();
			int num = 0;
			if (HttpContext.Current.Session["UserID"] != null)
			{
				num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
			}
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_Qtydescription");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qtydesc1", DbType.String, Qtydesc1);
			database.AddInParameter(storedProcCommand, "@Qtydesc2", DbType.String, Qtydesc2);
			database.AddInParameter(storedProcCommand, "@Qtydesc3", DbType.String, Qtydesc3);
			database.AddInParameter(storedProcCommand, "@Qtydesc4", DbType.String, Qtydesc4);
			database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.String, num);
			DateTime now = DateTime.Now;
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Select_AccountingCode_For_Summary(int CompanyID, long EstimateItemID, string EstimateType, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_AccountingCode_For_Summary");
			DataTable dataTable = new DataTable();
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_AdditionalItem_IDs(int CompanyID, long EstimateItemID, string EstimateItemType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_AdditionalItem_IDs");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemType", DbType.String, EstimateItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_Converted_Prodect(int CompanyID, long EstimateItemID, string Esttype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_Converted_Product");
			storedProcCommand.CommandTimeout = 0;
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, Esttype);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_details_for_Activity_History(int CompanyID, long EstimateID, string PgType, long POID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_details_for_Activity_History");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@PgType", DbType.String, PgType);
			database.AddInParameter(storedProcCommand, "@POID", DbType.Int64, POID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_details_for_JobActivity_History(int CompanyID, long JobID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_DetailsForJob_ActivityHistory");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_EstimateItemID(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_EstimateItemID");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_InventoryInkMatrix_SetUpCost(int CompanyID, long InventoryId)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_InventoryInkMatrix_SetUpCost");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryId", DbType.Int64, InventoryId);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable select_InventoryInkMatrixDetails_inkCal(int CompanyID, long InventoryId, string InventorySheetsFromTo)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_InventoryInkMatrixDetails_inkCal");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryId", DbType.Int64, InventoryId);
			database.AddInParameter(storedProcCommand, "@InventorySheetsFromTo", DbType.String, InventorySheetsFromTo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_Item_Number_Title_basedonModule(int CompanyID, long EstimateItemID, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ItemNumber_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@module", DbType.String, Module);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable Select_OrderIDAdditionalitemID_Select(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderID_Select_ForEstimate");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataSet Select_OrderItems_WithAdditionalItems(long OrderItemID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_Select_OrderItems_WithAdditionalItems", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@OrderItemID", OrderItemID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual DataSet select_othercost_parentdetails(long EstimateID, long EstimateItemID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_select_othercost_parentdetails", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
			sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstimateItemID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
		{
			commonClass _commonClass = new commonClass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsDetail");
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsIDs");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_OtherCostItemQty(long EstimateID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_OtherCostItemQty");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_ProductCatalogueQty(long EstimateItemID, string EstimateType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_ProductCatalogueQty");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_Prompt_Archive(int CompanyID, string Event)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArchiveStatus_Prompt__Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@Event", DbType.String, Event);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable selectEstimatetype_estimateitemid(long EstimateItemID, long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_selectEstimatetype_estimateitemid");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SelectItemDescFrmEsOutwork(long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("SelectItemDescFrmEsOutwork");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable selectoutworkQtyType(int EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_selectoutworkQtyType");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SelectPlateunitprice_eachSectin(int InventoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectPlateunitprice_eachSectin");
			database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int32, InventoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void SendingNewArtWorkFilenames(int CompanyID, long EstimateItemID, string SaveNewfilenames, string SaveOriginalFileNames, long NewEstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArtWorkFile_Copy");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@SaveNewfilenames", DbType.String, SaveNewfilenames);
			database.AddInParameter(storedProcCommand, "@SaveOriginalFileNames", DbType.String, SaveOriginalFileNames);
			database.AddInParameter(storedProcCommand, "@NewEstimateItemID", DbType.Int64, NewEstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable SentForQuoteStatus_SupQuoteDet(long SupplierID, long Estoutworkid, int QuantityNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SentForQuote_SupQuoteDet");
			database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, SupplierID);
			database.AddInParameter(storedProcCommand, "@EstoutworkID", DbType.Int64, Estoutworkid);
			database.AddInParameter(storedProcCommand, "@QuantityNumber", DbType.Int32, QuantityNumber);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string settings_jobViewColor_SelectedDateType(int CompanyId)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_jobViewColor_SelectedDateType");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int16, CompanyId);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable settings_lithopress_InkSelect(int CompanyID, long LithoPressID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_lithopress_InkSelect]");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataSet settings_Product_CatalogueAdditional_Select(int CompanyID, long PriceCatalogueID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("PC_settings_Product_CatalogueAdditional_Select", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
			sqlCommand.Parameters.AddWithValue("@PriceCatalogueID", PriceCatalogueID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}

		public virtual long SingelItem_Inset_By_Copy(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID, string IsParentItem)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_single_item_copy_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
			database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
			database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
			database.AddInParameter(storedProcCommand, "@IsParentItem", DbType.String, IsParentItem);
			database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@Ret_EstimateItemID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual long single_item_insert(EstimatesItem item)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_single_item_insert");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateSingleItemID", DbType.Int64, item.EstimateSingleItemID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
			database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
			database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
			database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
			database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
			database.AddInParameter(storedProcCommand, "@SetupSpoilage", DbType.Decimal, item.SetupSpoilage);
			database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, item.RunningSpoilage);
			database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
			database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
			database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
			database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
			database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Decimal, item.SheetHeight);
			database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Decimal, item.SheetWidth);
			database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
			database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
			database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Decimal, item.JobHeight);
			database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Decimal, item.JobWidth);
			database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
			database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, item.GutterHorizontal);
			database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, item.GutterVertical);
			database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
			database.AddInParameter(storedProcCommand, "@NonImageHeight", DbType.Decimal, item.NonImageHeight);
			database.AddInParameter(storedProcCommand, "@NonImageWidth", DbType.Decimal, item.NonImageWidth);
			database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
			database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Decimal, item.PortraitValue);
			database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Decimal, item.LandscapeValue);
			database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
			database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
			database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
			database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
			database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
			database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
			database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
			database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
			database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
			database.AddInParameter(storedProcCommand, "@IsCompleted", DbType.Boolean, item.IsCompleted);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, item.ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, item.ParentItemType);
			database.AddInParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@ManualValue", DbType.Decimal, item.ManualValue);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
		}

		public virtual DataTable single_item_select(int CompanyID, long EstimateItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_single_item_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void sub_item_outwork_markup_update(int CompanyID, long EstOutworkSupplierID, decimal Markup, decimal TotalPrice)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_sub_item_outwork_markup_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstOutworkSupplierID", DbType.Int64, EstOutworkSupplierID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet sub_item_summary(int CompanyID, long EstimateItemID, string Estimatetype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_sub_item_summary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, Estimatetype);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable sub_warehouse_in_summary(long CompanyID, long ParentItemID, string ParentItemType)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_sub_warehouse_in_summary");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int64, ParentItemID);
			database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentItemType);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void subtotal_update(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_subtotal_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Qty);
			database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
			database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@orderNumber", DbType.Int32, orderNumber);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@CostPriceExMarkup", DbType.Decimal, CostPriceExMarkup);
			database.AddInParameter(storedProcCommand, "@MarkupPrice", DbType.Decimal, MarkupPrice);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void subtotal_update_new(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, decimal ProfitMarginPrice, int QtyNumber, decimal TaxValue, decimal SellingPrice)
		{
			SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Qty", (object)Qty), new SqlParameter("@SubTotal", (object)SubTotal), new SqlParameter("@Tax", (object)Tax), new SqlParameter("@ProfitMargin", (object)ProfitMargin), new SqlParameter("@TaxID", (object)TaxID), new SqlParameter("@orderNumber", (object)orderNumber), new SqlParameter("@EstimateBookletItemID", (object)EstimateBookletItemID), new SqlParameter("@CostPriceExMarkup", (object)CostPriceExMarkup), new SqlParameter("@MarkupPrice", (object)MarkupPrice), new SqlParameter("@ProfitMarginPrice", (object)ProfitMarginPrice), new SqlParameter("@QtyNumber", (object)QtyNumber), new SqlParameter("@TaxPrice", (object)TaxValue), new SqlParameter("@SellingPrice", (object)SellingPrice) };
			SqlParameter[] sqlParameterArray = sqlParameter;
			commonClass _commonClass = new commonClass();
			SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PCR_subtotal_update", sqlParameterArray);
		}

		public virtual void subtotal_update_OnSave(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, int QtyNumber)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_subtotal_update_OnSave");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Qty);
			database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
			database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@orderNumber", DbType.Int32, orderNumber);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.AddInParameter(storedProcCommand, "@CostPriceExMarkup", DbType.Decimal, CostPriceExMarkup);
			database.AddInParameter(storedProcCommand, "@MarkupPrice", DbType.Decimal, MarkupPrice);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable summary_outwork_select(int CompanyID, long EstimateItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_summary_outwork_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void summary_sub_ware_markup_update(int CompanyID, long EstWarehouseItemID, decimal Markup)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_summary_sub_ware_markup_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstWarehouseItemID", DbType.Int64, EstWarehouseItemID);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataSet SupplierID_PerQty(long EstimateItemID, string Type)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SupplierID_PerQty_QuoteDetails");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, Type);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataTable Tax_Bind(int companyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Tax_Bind");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual void taxprofit_update(int CompanyID, long EstimateItemID, string EstimateType, int TaxID, decimal Tax, decimal ProfitMargin, long EstimateBookletItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_taxprofit_update");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
			database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
			database.AddInParameter(storedProcCommand, "@EstimateBookletItemID", DbType.Int64, EstimateBookletItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void UnLockItemStatus(long EstimateItemID, string Module)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimates_UnLockEstimateItemStatus");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Update_customer_details_forNew_copy_estimate(int CompanyID, long EstimateID, long CustomerID, long AttentionID, string Greeting, string Company, long Address, long DeliveryAddress, int UserID, long InvAddressID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_customer_details_forNew_copy_estimate");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
			database.AddInParameter(storedProcCommand, "@AttentionID", DbType.Int64, AttentionID);
			database.AddInParameter(storedProcCommand, "@Greeting", DbType.String, Greeting);
			database.AddInParameter(storedProcCommand, "@Company", DbType.String, Company);
			database.AddInParameter(storedProcCommand, "@Address", DbType.Int64, Address);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@DeliveryAddress", DbType.Int64, DeliveryAddress);
			database.AddInParameter(storedProcCommand, "@InvAddressID", DbType.Int64, InvAddressID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void update_Materialcost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_update_Materialcost_onLockUnitPrice");
			database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, qtyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, estCalculationID);
			database.AddInParameter(storedProcCommand, "@PaperUnitPrice", DbType.Decimal, PaperUnitPrice);
			database.AddInParameter(storedProcCommand, "@IsPaperUnitPriceLocked", DbType.Boolean, islock);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup1", DbType.Decimal, PaperCostExMarkup1);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup2", DbType.Decimal, PaperCostExMarkup2);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup3", DbType.Decimal, PaperCostExMarkup3);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup4", DbType.Decimal, PaperCostExMarkup4);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice1", DbType.Decimal, PaperMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice2", DbType.Decimal, PaperMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice3", DbType.Decimal, PaperMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice4", DbType.Decimal, PaperMarkupPrice4);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void update_OtherCostItemQty(long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_update_OtherCostItemQty");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@QTY1", DbType.Int32, Qty1);
			database.AddInParameter(storedProcCommand, "@QTY2", DbType.Int32, Qty2);
			database.AddInParameter(storedProcCommand, "@QTY3", DbType.Int32, Qty3);
			database.AddInParameter(storedProcCommand, "@QTY4", DbType.Int32, Qty4);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void update_papercost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4, string Module, int QtyNumber)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("pc_update_papercost_onLockUnitPrice");
			database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, qtyID);
			database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, estCalculationID);
			database.AddInParameter(storedProcCommand, "@PaperUnitPrice", DbType.Decimal, PaperUnitPrice);
			database.AddInParameter(storedProcCommand, "@IsPaperUnitPriceLocked", DbType.Boolean, islock);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup1", DbType.Decimal, PaperCostExMarkup1);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup2", DbType.Decimal, PaperCostExMarkup2);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup3", DbType.Decimal, PaperCostExMarkup3);
			database.AddInParameter(storedProcCommand, "@PaperCostExMarkup4", DbType.Decimal, PaperCostExMarkup4);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice1", DbType.Decimal, PaperMarkupPrice1);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice2", DbType.Decimal, PaperMarkupPrice2);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice3", DbType.Decimal, PaperMarkupPrice3);
			database.AddInParameter(storedProcCommand, "@PaperMarkupPrice4", DbType.Decimal, PaperMarkupPrice4);
			database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
			database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int16, QtyNumber);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void updateitemdescription_forink_litho(long EstimateItemID, string EstimateType, string ItemDescription, long Estimatelithoncritemid, long Estimatelithobookletitemid)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_updateitemdescription_forink_litho");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
			database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
			database.AddInParameter(storedProcCommand, "@Estimatelithoncritemid", DbType.Int64, Estimatelithoncritemid);
			database.AddInParameter(storedProcCommand, "@Estimatelithobookletitemid", DbType.Int64, Estimatelithobookletitemid);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void updateProfitmargin_OnCustomerChange(long CompanyId, long EstimateID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_updateProfitmarginPerPrice");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void updateSubTotalLock(long EstimateItemID)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_updateSubTotalLock");
			database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void updatetotalTax_and_sellingPrice_forOtherCost(long EstTotalID, decimal TaxValue, decimal SellingPrice, long taxID, decimal taxpercent)
		{
			commonClass _commonClass = new commonClass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_updatetotalTax_and_sellingPrice_forOtherCost");
			database.AddInParameter(storedProcCommand, "@EstTotalID", DbType.Int64, EstTotalID);
			database.AddInParameter(storedProcCommand, "@TaxValue", DbType.Decimal, TaxValue);
			database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, SellingPrice);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int64, taxID);
			database.AddInParameter(storedProcCommand, "@Taxpercent", DbType.Decimal, taxpercent);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual bool Views_IsItemDetailsSelected(long ViewID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Views_IsItemDetailsSelected");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@ViewID", DbType.Int64, ViewID);
			return (bool)database.ExecuteScalar(storedProcCommand);
		}

		public virtual string Views_RecordsToDisplay(long ViewID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Views_RecordsToDisplay");
			database.AddInParameter(storedProcCommand, "@ViewID", DbType.Int64, ViewID);
			return (string)database.ExecuteScalar(storedProcCommand);
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

		public virtual string Warehouse_Markup(int CompanyID, int InventoryNo)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_markup_New");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@InventoryNo", DbType.Int32, InventoryNo);
			string markUp=(database.ExecuteScalar(storedProcCommand)).ToString();
			return markUp;
		}

		public virtual string warehouse_perquantity_select(int CompanyID, string WarehouseType, long WarehouseTypeID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_perquantity_select_New");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@WarehouseType", DbType.String, WarehouseType);
			database.AddInParameter(storedProcCommand, "@WarehouseTypeID", DbType.Int64, WarehouseTypeID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}


        public virtual DataTable estimateCalculationSelect(long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateCalculation_Select");
            database.AddInParameter(storedProcCommand, "@EstimateCalculationID", DbType.Int64, ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }


        ///Added by Amin


        public virtual Boolean PC_select_JobLocking_Status(long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("SELECT ISNULL( tb_job.IsJobLocked,0) as IsJobLocked from tb_job where jobid= ", ID));
           
            return (Boolean)database.ExecuteScalar(sqlStringCommand);
        }


        public virtual void PC_update_JobLocking_Status(long ID, Boolean Status)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_JobLocking_Status");
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Double, ID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        //End added by Amin


        //
        public virtual void updatePrintSheets(decimal printSheet1, decimal printSheet2, decimal printSheet3, decimal printSheet4, long QuantityID, decimal printSheetPrize1, decimal printSheetPrize2, decimal printSheetPrize3, decimal printSheetPrize4)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_printSheet_Update");
            database.AddInParameter(storedProcCommand, "@printSheet1", DbType.Decimal, printSheet1);
            database.AddInParameter(storedProcCommand, "@printSheet2", DbType.Decimal, printSheet2);
            database.AddInParameter(storedProcCommand, "@printSheet3", DbType.Decimal, printSheet3);
            database.AddInParameter(storedProcCommand, "@printSheet4", DbType.Decimal, printSheet4);
            database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, QuantityID);
            database.AddInParameter(storedProcCommand, "@printSheetPrize1", DbType.Decimal, printSheetPrize1);
            database.AddInParameter(storedProcCommand, "@printSheetPrize2", DbType.Decimal, printSheetPrize2);
            database.AddInParameter(storedProcCommand, "@printSheetPrize3", DbType.Decimal, printSheetPrize3);
            database.AddInParameter(storedProcCommand, "@printSheetPrize4", DbType.Decimal, printSheetPrize4);
            database.ExecuteNonQuery(storedProcCommand);
        }


        public virtual DataTable GetEstimateQty(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetEstimateQty");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}