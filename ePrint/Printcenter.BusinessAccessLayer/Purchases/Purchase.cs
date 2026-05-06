using Printcenter.DataAccessLayer.Purchases;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Purchases
{
	public class Purchase
	{
		public Purchase()
		{
		}

		public static DataTable company_client_alladdress_select_ForDeliveryAddress(int CompanyID, int CustomerID, string ClearFilter)
		{
			return (new DbPurchase()).company_client_alladdress_select_ForDeliveryAddress(CompanyID, CustomerID, ClearFilter);
		}

		public static DataTable getPODeliveryAddress(int CompanyID, long PurchaseID, long DeliveryAddressID, string DeliveryAddressType, long EstimateID)
		{
			return (new DbPurchase()).getPODeliveryAddress(CompanyID, PurchaseID, DeliveryAddressID, DeliveryAddressType, EstimateID);
		}

		public static DataTable getPODeliveryAddress_new(int CompanyID, long PurchaseID, long EstimateID)
		{
			return (new DbPurchase()).getPODeliveryAddress_new(CompanyID, PurchaseID, EstimateID);
		}

		public static DataTable Kit_Details(long PriceCatalogueID)
		{
			return (new DbPurchase()).Kit_Details(PriceCatalogueID);
		}

		public static string KitItemDescription(int CompanyID, long PriceCatalogueID)
		{
			return (new DbPurchase()).KitItemDescription(CompanyID, PriceCatalogueID);
		}

		public static DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
		{
			return (new DbPurchase()).OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder);
		}

		public static DataTable PO_ProductSelect(long EstimateItemID, string EstimateType)
		{
			return (new DbPurchase()).PO_ProductSelect(EstimateItemID, EstimateType);
		}

        public static DataSet selectPOfromJob(long jobID, long companyID, long estimateID)
        {
            return (new DbPurchase()).selectPOfromJob(jobID, companyID, estimateID);
        }

        public static void ProgressToJob_StockItem_Update(long PriceCatalogueID, long PurchaseItemID)
		{
			(new DbPurchase()).ProgressToJob_StockItem_Update(PriceCatalogueID, PurchaseItemID);
		}

        public static void PurchaseItem_Goodsreceived_Update(bool IsGoodsReceived, long PurchaseItemID)
        {
            (new DbPurchase()).PurchaseItem_Goodsreceived_Update(IsGoodsReceived, PurchaseItemID);
        }

        public static DataTable Purchase_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
		{
			DbPurchase dbPurchase = new DbPurchase();
			return dbPurchase.Purchase_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
		}

		public static void purchase_delete(int CompanyID, long PurchaseID)
		{
			(new DbPurchase()).purchase_delete(CompanyID, PurchaseID);
		}

		public static void Purchase_Comments_Update(int commentId, string newComment)
		{
			(new DbPurchase()).Purchase_Comments_Update(commentId, newComment);
		}

		public static void Purchase_History_Update(string Notes, long PriceCatalogueID, string NotesCompare)
		{
			(new DbPurchase()).Purchase_History_Update(Notes, PriceCatalogueID, NotesCompare);
		}

		public static long purchase_insert(PurchaseItem item)
		{
			return (new DbPurchase()).purchase_insert(item);
		}
		public static DataTable GetPurchaseItemByJobID(long JobID, int CompanyID, long SupplierID)
		{
			return (new DbPurchase()).GetPurchaseItemByJobID(JobID, CompanyID, SupplierID);
		}

		public static int GetPurchaseItemcount(long PurchaseID, string EstimateType, string Description, Decimal Qty, Decimal Price, int TaxID, Decimal TaxValue)
		{
			return (new DbPurchase()).GetPurchaseItemcount(PurchaseID, EstimateType, Description,Qty,Price,TaxID,TaxValue);
		}
		public static int Purchase_Items_Count_Select(int CompanyID, long PurchaseID)
		{
			return (new DbPurchase()).Purchase_Items_Count_Select(CompanyID, PurchaseID);
		}

		public static void Purchase_Make_Archive(int CompanyID, long PurchaseID)
		{
			(new DbPurchase()).Purchase_Make_Archive(CompanyID, PurchaseID);
		}

		public static long Purchase_Make_Copy(int CompanyID, long PurchaseID, short IsEstimatecopy)
		{
			return (new DbPurchase()).Purchase_Make_Copy(CompanyID, PurchaseID, IsEstimatecopy);
		}

		public static DataSet purchase_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			DbPurchase dbPurchase = new DbPurchase();
			return dbPurchase.purchase_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataTable purchase_search(int CompanyID, string Para)
		{
			return (new DbPurchase()).purchase_search(CompanyID, Para);
		}

		public static DataTable purchase_select(int CompanyID, long PurchaseID)
		{
			return (new DbPurchase()).purchase_select(CompanyID, PurchaseID);
		}

		public static DataTable purchase_select_by_EstimateItemID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
		{
			return (new DbPurchase()).purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID);
		}

		public static DataTable purchase_select_by_EstimateItemID_and_MaterialID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID, long MaterialID)
		{
			DbPurchase dbPurchase = new DbPurchase();
			return dbPurchase.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID, MaterialID);
		}

		public static DataTable purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(long EstimateID, long EstimateItemID, long MaterialID, long EstLargeItemCalculationID)
		{
			return (new DbPurchase()).purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(EstimateID, EstimateItemID, MaterialID, EstLargeItemCalculationID);
		}

		public static DataTable Purchase_select_by_EstimateItemID_Product_AddItem(long EstimateID, long EstimateItemID, long EstimateAdditionalItemID)
		{
			return (new DbPurchase()).Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, EstimateItemID, EstimateAdditionalItemID);
		}

		public static DataTable purchase_selectall(int CompanyID)
		{
			return (new DbPurchase()).purchase_selectall(CompanyID);
		}

		public static void purchase_warehouseitemid_update(int CompanyID, long PurchaseItemID, long WarehouseItemID, string WarehouseItemType, string ItemCode)
		{
			(new DbPurchase()).purchase_warehouseitemid_update(CompanyID, PurchaseItemID, WarehouseItemID, WarehouseItemType, ItemCode);
		}

		public static void purchase_warehouseqty_update(int CompanyID, long WarehouseItemID, string WarehouseItemType, decimal StockQty)
		{
			(new DbPurchase()).purchase_warehouseqty_update(CompanyID, WarehouseItemID, WarehouseItemType, StockQty);
		}

		public static string purchase_warehousestockqty_select(int CompanyID, long WarehouseItemID, string WarehouseItemType)
		{
			return (new DbPurchase()).purchase_warehousestockqty_select(CompanyID, WarehouseItemID, WarehouseItemType);
		}

		public static void purchaseitem_delete(int CompanyID, long PurchaseItemID, long PurchaseID)
		{
			(new DbPurchase()).purchaseitem_delete(CompanyID, PurchaseItemID, PurchaseID);
		}

		public static long purchaseitem_insert(PurchaseItem item)
		{
			return (new DbPurchase()).purchaseitem_insert(item);
		}

		public static long purchaseitem_insert_new(PurchaseItem item)
		{
			return (new DbPurchase()).purchaseitem_insert_new(item);
		}

		public static long purchaseitem_insert_ProdAdditional_Item(PurchaseItem item)
		{
			return (new DbPurchase()).purchaseitem_insert_ProdAdditional_Item(item);
		}

		public static long purchaseitem_insertPOfromJob(PurchaseItem item)
		{
			return (new DbPurchase()).purchaseitem_insertPOfromJob(item);
		}

		public static DataTable purchaseitem_select(int CompanyID, long PurchaseID)
		{
			return (new DbPurchase()).purchaseitem_select(CompanyID, PurchaseID);
		}

		public static DataTable PurchaseItems_Details_Select(long PurchaseItemID)
		{
			return (new DbPurchase()).PurchaseItems_Details_Select(PurchaseItemID);
		}

		public static void PurchaseOnCheck_Status_Update(int CompanyID, string PurchaseIDs, int StatusID, string Module)
		{
			(new DbPurchase()).PurchaseOnCheck_Status_Update(CompanyID, PurchaseIDs, StatusID, Module);
		}

		public static DataTable Select_PriceCat_ItemTitle_n_DrawStockFrom(long PriceCatalogue)
		{
			return (new DbPurchase()).Select_PriceCat_ItemTitle_n_DrawStockFrom(PriceCatalogue);
		}

		public static DataSet Warehouse_Inventory_Select(int CompanyID, int ClientID)
		{
			return (new DbPurchase()).Warehouse_Inventory_Select(CompanyID, ClientID);
		}
	}
}