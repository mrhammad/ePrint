using nmsCommon;
using Printcenter.BusinessAccessLayer.Purchases;
using System;
using System.Data;

namespace Printcenter.UI.Purchases
{
    public class PurchaseBasePage : BasePage
    {
        public PurchaseBasePage()
        {
        }

        public static DataTable company_client_alladdress_select_ForDeliveryAddress(int CompanyID, int CustomerID, string ClearFilter)
        {
            return Purchase.company_client_alladdress_select_ForDeliveryAddress(CompanyID, CustomerID, ClearFilter);
        }

        public static DataTable getPODeliveryAddress(int CompanyID, long PurchaseID, long DeliveryAddressID, string DeliveryAddressType, long EstimateID)
        {
            return Purchase.getPODeliveryAddress(CompanyID, PurchaseID, DeliveryAddressID, DeliveryAddressType, EstimateID);
        }

        public static DataTable getPODeliveryAddress_new(int CompanyID, long PurchaseID, long EstimateID)
        {
            return Purchase.getPODeliveryAddress_new(CompanyID, PurchaseID, EstimateID);
        }

        public static DataTable Kit_Details(long PriceCatalogueID)
        {
            return Purchase.Kit_Details(PriceCatalogueID);
        }

        public static string KitItemDescription(int CompanyID, long PriceCatalogueID)
        {
            return Purchase.KitItemDescription(CompanyID, PriceCatalogueID);
        }

        public static DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
        {
            return Purchase.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder);
        }

        public static DataTable PO_ProductSelect(long EstimateItemID, string EstimateType)
        {
            return Purchase.PO_ProductSelect(EstimateItemID, EstimateType);
        }

        public static DataSet selectPOfromJob(long jobID, long companyID, long estimateID)
        {
            return Purchase.selectPOfromJob(jobID, companyID, estimateID);
        }

        public static void ProgressToJob_StockItem_Update(long PriceCatalogueID, long PurchaseItemID)
        {
            Purchase.ProgressToJob_StockItem_Update(PriceCatalogueID, PurchaseItemID);
        }

        public static void PurchaseItem_Goodsreceived_Update(bool IsGoodsReceived, long PurchaseItemID)
        {
            Purchase.PurchaseItem_Goodsreceived_Update(IsGoodsReceived, PurchaseItemID);
        }

        public static DataTable Purchase_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            return Purchase.Purchase_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
        }

        public static void purchase_delete(int CompanyID, long PurchaseID)
        {
            Purchase.purchase_delete(CompanyID, PurchaseID);
        }

        public static void Purchase_Comments_Update(int commentId, string newComment)
        {
            Purchase.Purchase_Comments_Update(commentId, newComment);
        }

        public static void Purchase_History_Update(string Notes, long PriceCatalogueID, string NotesCompare)
        {
            Purchase.Purchase_History_Update(Notes, PriceCatalogueID, NotesCompare);
        }

        //public static long purchase_insert(long purchaseID, int companyID, int supplierID, int contactID, long addressID, string comments, string footNote, string pONO, DateTime pODate, string referenceNo, string supplierQuoteNo, string supplierInvoiceNo, long raisedByID, DateTime reqDate, bool goodsReceived, bool invoiceReceived, int StatusID, int createdBy, int modifiedBy, DateTime modifiedDate, long currentPONO, string addressType, long estimateID, string headernote, long EstimateItemID, DateTime TodayDate, long DeliveryAddressID, string DeliveryAddressType, int CourierID, long EstimateBookletItemID, DateTime SupplierInvoiceDate, string IsFromProgreesTojob, long poNum = 0, string isCombine = "no")
        public static long purchase_insert(long purchaseID, int companyID, int supplierID, int contactID, long addressID, string comments, string footNote, string pONO, DateTime pODate, string referenceNo, string supplierQuoteNo, string supplierInvoiceNo, long raisedByID, DateTime reqDate, bool goodsReceived, bool invoiceReceived, int StatusID, int createdBy, int modifiedBy, DateTime modifiedDate, long currentPONO, string addressType, long estimateID, string headernote, long EstimateItemID, DateTime TodayDate, long DeliveryAddressID, string DeliveryAddressType, int CourierID, long EstimateBookletItemID, DateTime SupplierInvoiceDate, string IsFromProgreesTojob, long poNum = 0, string isCombine = "yes")
        {
            if (isCombine == "no")
            {
                poNum = 0;
            }
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                PurchaseID = purchaseID,
                CompanyID = companyID,
                SupplierID = supplierID,
                ContactID = contactID,
                AddressID = addressID,
                Comments = comments,
                FootNote = footNote,
                PONO = pONO,
                PODate = pODate,
                ReferenceNo = referenceNo,
                SupplierQuoteNo = supplierQuoteNo,
                SupplierInvoiceNo = supplierInvoiceNo,
                RaisedByID = raisedByID,
                ReqDate = reqDate,
                GoodsReceived = goodsReceived,
                InvoiceReceived = invoiceReceived,
                StatusID = StatusID,
                CreatedBy = createdBy,
                ModifiedBy = modifiedBy,
                ModifiedDate = modifiedDate,
                CurrentPONO = currentPONO,
                AddressType = addressType,
                EstimateID = estimateID,
                headernote = headernote,
                EstimateItemID = EstimateItemID,
                TodayDate = TodayDate,
                DeliveryAddressID = DeliveryAddressID,
                DeliveryAddressType = DeliveryAddressType,
                CourierID = CourierID,
                EstimateBookletItemID = EstimateBookletItemID,
                SupplierInvoiceDate = SupplierInvoiceDate,
                IsFromProgreesTojob = IsFromProgreesTojob,
                poNum = poNum,
                isCombine = isCombine
            };
            return Purchase.purchase_insert(purchaseItem);
        }

        public static DataTable GetPurchaseItemByJobID(long JobID, int CompanyID, long SupplierID)
        {
            return Purchase.GetPurchaseItemByJobID(JobID, CompanyID, SupplierID);
        }
        public static int GetPurchaseItemcount(long PurchaseID, string EstimateType, string Description, Decimal Qty, Decimal Price, int TaxID, Decimal TaxValue)
        {
            return Purchase.GetPurchaseItemcount(PurchaseID, EstimateType, Description, Qty, Price, TaxID, TaxValue);
        }
        public static int Purchase_Items_Count_Select(int CompanyID, long PurchaseID)
        {
            return Purchase.Purchase_Items_Count_Select(CompanyID, PurchaseID);
        }

        public void Purchase_Make_Archive(int CompanyID, long PurchaseID)
        {
            Purchase.Purchase_Make_Archive(CompanyID, PurchaseID);
        }

        public static long Purchase_Make_Copy(int CompanyID, long PurchaseID, short IsEstimatecopy)
        {
            return Purchase.Purchase_Make_Copy(CompanyID, PurchaseID, IsEstimatecopy);
        }

        public static DataSet purchase_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Purchase.purchase_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static DataTable purchase_search(int CompanyID, string Para)
        {
            return Purchase.purchase_search(CompanyID, Para);
        }

        public static DataTable purchase_select(int CompanyID, long PurchaseID)
        {
            return Purchase.purchase_select(CompanyID, PurchaseID);
        }

        public static DataTable purchase_select_by_EstimateItemID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
        {
            return Purchase.purchase_select_by_EstimateItemID(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID);
        }

        public static DataTable purchase_select_by_EstimateItemID_and_MaterialID(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID, long MaterialID)
        {
            return Purchase.purchase_select_by_EstimateItemID_and_MaterialID(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID, MaterialID);
        }

        public static DataTable purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(long EstimateID, long EstimateItemID, long MaterialID, long EstLargeItemCalculationID)
        {
            return Purchase.purchase_select_by_EstimateItemID_and_MaterialID_LargeFormat(EstimateID, EstimateItemID, MaterialID, EstLargeItemCalculationID);
        }

        public static DataTable Purchase_select_by_EstimateItemID_Product_AddItem(long EstimateID, long EstimateItemID, long EstimateAdditionalItemID)
        {
            return Purchase.Purchase_select_by_EstimateItemID_Product_AddItem(EstimateID, EstimateItemID, EstimateAdditionalItemID);
        }

        public static DataTable purchase_selectall(int CompanyID)
        {
            return Purchase.purchase_selectall(CompanyID);
        }

        public static void purchase_warehouseitemid_update(int CompanyID, long PurchaseItemID, long WarehouseItemID, string WarehouseItemType, string ItemCode)
        {
            Purchase.purchase_warehouseitemid_update(CompanyID, PurchaseItemID, WarehouseItemID, WarehouseItemType, ItemCode);
        }

        public static void purchase_warehouseqty_update(int CompanyID, long WarehouseItemID, string WarehouseItemType, decimal StockQty)
        {
            Purchase.purchase_warehouseqty_update(CompanyID, WarehouseItemID, WarehouseItemType, StockQty);
        }

        public static string purchase_warehousestockqty_select(int CompanyID, long WarehouseItemID, string WarehouseItemType)
        {
            return Purchase.purchase_warehousestockqty_select(CompanyID, WarehouseItemID, WarehouseItemType);
        }

        public static void purchaseitem_delete(int CompanyID, long PurchaseItemID, long PurchaseID)
        {
            Purchase.purchaseitem_delete(CompanyID, PurchaseItemID, PurchaseID);
        }

        public static long purchaseitem_insert(int companyID, long purchaseItemID, long purchaseID, long warehouseItemID, string warehouseItemType, string itemCode, string description, decimal qty, decimal packedIn, decimal price, int taxID, decimal taxValue, int accountCodeID, string note, bool goodsReceived, long EstimateItemId, string EstimateType, long EstLargeItemCalculationID, int UserID, DateTime CreatedDate)
        {
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                CompanyID = companyID,
                PurchaseItemID = purchaseItemID,
                PurchaseID = purchaseID,
                WarehouseItemID = warehouseItemID,
                WarehouseItemType = warehouseItemType,
                ItemCode = itemCode,
                Description = description,
                PurQty = qty,
                PurPackedIn = packedIn,
                Price = price,
                TaxID = taxID,
                TaxValue = taxValue,
                AccountCodeID = accountCodeID,
                Note = note,
                GoodsReceived = goodsReceived,
                EstimateItemID = EstimateItemId,
                EstimateType = EstimateType,
                EstLargeItemCalculationID = EstLargeItemCalculationID,
                UserID = UserID,
                CreatedDate = CreatedDate
            };
            return Purchase.purchaseitem_insert(purchaseItem);
        }

        public static long purchaseitem_insert_new(int companyID, long purchaseItemID, long purchaseID, long warehouseItemID, string warehouseItemType, string itemCode, string description, decimal qty, decimal packedIn, decimal price, int taxID, decimal taxValue, int accountCodeID, string note, bool goodsReceived, long EstimateItemId, string EstimateType, string AdditionalOptionDetails, bool IsCompleted)
        {
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                CompanyID = companyID,
                PurchaseItemID = purchaseItemID,
                PurchaseID = purchaseID,
                WarehouseItemID = warehouseItemID,
                WarehouseItemType = warehouseItemType,
                ItemCode = itemCode,
                Description = description,
                PurQty = qty,
                PurPackedIn = packedIn,
                Price = price,
                TaxID = taxID,
                TaxValue = taxValue,
                AccountCodeID = accountCodeID,
                Note = note,
                GoodsReceived = goodsReceived,
                EstimateItemID = EstimateItemId,
                EstimateType = EstimateType,
                AdditionalOptionDetails = AdditionalOptionDetails,
                IsCompleted = IsCompleted
            };
            return Purchase.purchaseitem_insert_new(purchaseItem);
        }

        public static long purchaseitem_insert_ProdAdditional_Item(int companyID, long purchaseItemID, long purchaseID, long warehouseItemID, string warehouseItemType, string itemCode, string description, decimal qty, decimal packedIn, decimal price, int taxID, decimal taxValue, int accountCodeID, string note, bool goodsReceived, long EstimateItemId, string EstimateType, long EstLargeItemCalculationID, long EstimateAdditionalItemID, int UserID, DateTime CreatedDate)
        {
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                CompanyID = companyID,
                PurchaseItemID = purchaseItemID,
                PurchaseID = purchaseID,
                WarehouseItemID = warehouseItemID,
                WarehouseItemType = warehouseItemType,
                ItemCode = itemCode,
                Description = description,
                PurQty = qty,
                PurPackedIn = packedIn,
                Price = price,
                TaxID = taxID,
                TaxValue = taxValue,
                AccountCodeID = accountCodeID,
                Note = note,
                GoodsReceived = goodsReceived,
                EstimateItemID = EstimateItemId,
                EstimateType = EstimateType,
                EstLargeItemCalculationID = EstLargeItemCalculationID,
                EstimateAdditionalItemID = EstimateAdditionalItemID,
                UserID = UserID,
                CreatedDate = CreatedDate
            };
            return Purchase.purchaseitem_insert_ProdAdditional_Item(purchaseItem);
        }

        public static long purchaseitem_insertPOfromJob(int companyID, long purchaseItemID, long purchaseID, long warehouseItemID, string warehouseItemType, string itemCode, string description, decimal qty, decimal packedIn, decimal price, int taxID, decimal taxValue, int accountCodeID, string note, bool goodsReceived, long EstimateItemId, string EstimateType, bool isFromProductItem, long EstLargeItemCalculationID, int LoggedIN_UserID, DateTime CreatedDate)
        {
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                CompanyID = companyID,
                PurchaseItemID = purchaseItemID,
                PurchaseID = purchaseID,
                WarehouseItemID = warehouseItemID,
                WarehouseItemType = warehouseItemType,
                ItemCode = itemCode,
                Description = description,
                PurQty = qty,
                PurPackedIn = packedIn,
                Price = price,
                TaxID = taxID,
                TaxValue = taxValue,
                AccountCodeID = accountCodeID,
                Note = note,
                GoodsReceived = goodsReceived,
                EstimateItemID = EstimateItemId,
                EstimateType = EstimateType,
                isFromProductItem = isFromProductItem,
                EstLargeItemCalculationID = EstLargeItemCalculationID,
                UserID = LoggedIN_UserID,
                CreatedDate = CreatedDate
            };
            return Purchase.purchaseitem_insertPOfromJob(purchaseItem);
        }

        public static DataTable purchaseitem_select(int CompanyID, long PurchaseID)
        {
            return Purchase.purchaseitem_select(CompanyID, PurchaseID);
        }

        public static DataTable PurchaseItems_Details_Select(long PurchaseItemID)
        {
            return Purchase.PurchaseItems_Details_Select(PurchaseItemID);
        }

        public static void PurchaseOnCheck_Status_Update(int CompanyID, string PurchaseIDs, int StatusID, string Module)
        {
            Purchase.PurchaseOnCheck_Status_Update(CompanyID, PurchaseIDs, StatusID, Module);
        }

        public static DataTable Select_PriceCat_ItemTitle_n_DrawStockFrom(long PriceCatalogue)
        {
            return Purchase.Select_PriceCat_ItemTitle_n_DrawStockFrom(PriceCatalogue);
        }

        public static DataSet Warehouse_Inventory_Select(int CompanyID, int ClientID)
        {
            return Purchase.Warehouse_Inventory_Select(CompanyID, ClientID);
        }
    }
}