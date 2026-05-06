using Printcenter.DataAccessLayer.EstimatesNew;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.EstimatesNew
{
    public class EstimateNew
    {
        public EstimateNew()
        {
        }

        public static void AccountCode_Update_InSummary(int CompanyID, long EstimateItemID, string EstimateType, int AccountCodeID)
        {
            (new DbEstimates()).AccountCode_Update_InSummary(CompanyID, EstimateItemID, EstimateType, AccountCodeID);
        }

        public static void Update_EstimateItems_SortingOrder(long EstimateItemID, int SortingOrderId, string pageName)
        {
            (new DbEstimates()).Update_EstimateItems_SortingOrder(EstimateItemID, SortingOrderId, pageName);
        }

        public static void update_multiple_product_categories(long PriceCatalogueID, int PriceCatalogueCategoryID_2, int PriceCatalogueCategoryID_3, int PriceCatalogueCategoryID_4, int PriceCatalogueCategoryID_5, int PriceCatalogueCategoryID_6)
        {
            (new DbEstimates()).update_multiple_product_categories(PriceCatalogueID, PriceCatalogueCategoryID_2, PriceCatalogueCategoryID_3, PriceCatalogueCategoryID_4, PriceCatalogueCategoryID_5, PriceCatalogueCategoryID_6);
        }

        public static void Import_otherstore_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            (new DbEstimates()).Import_otherstore_deliveryCost(PriceCatalogueID, PriceCatalogueCategoryID_2);
        }

        public static void Import_MIS_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            (new DbEstimates()).Import_MIS_deliveryCost(PriceCatalogueID, PriceCatalogueCategoryID_2);
        }

        public static DataTable AccountingCode_Select_forRerun(long EstimateID, long EstimateItemID, string estimatetype)
        {
            return (new DbEstimates()).AccountingCode_Select_forRerun(EstimateID, EstimateItemID, estimatetype);
        }

        public static void AddMore_Supplier(long SupplierID, long SupplierContactID, long EstimateItemID)
        {
            (new DbEstimates()).AddMore_Supplier(SupplierID, SupplierContactID, EstimateItemID);
        }

        public static void booklet_delete(int CompanyID, long EstimateBookletItemID, string EstType)
        {
            (new DbEstimates()).booklet_delete(CompanyID, EstimateBookletItemID, EstType);
        }

        public static long booklet_item_insert(EstimatesItem item)
        {
            return (new DbEstimates()).booklet_item_insert(item);
        }

        public static DataTable booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable booklet_job_qty(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return (new DbEstimates()).booklet_job_qty(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static DataSet Booklet_SelectSubsectioniddetail_byEstimateBookletItemID(int CompanyID, long EstimateItemID, string Estimationtype, long EstimateBookletItemID)
        {
            return (new DbEstimates()).Booklet_SelectSubsectioniddetail_byEstimateBookletItemID(CompanyID, EstimateItemID, Estimationtype, EstimateBookletItemID);
        }

        public static DataSet bookletncr_subtotal_all_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return EstimateNew.bookletncr_subtotal_all_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static long calculation_insert_estimate(int CompanyID, string Data)
        {
            return (new DbEstimates()).calculation_insert_estimate(CompanyID, Data);
        }

        public static string Check_EstimateItem_Transaction(long EstimateItemID)
        {
            return (new DbEstimates()).Check_EstimateItem_Transaction(EstimateItemID);
        }

        public static bool Check_SpecialPrivilege_For_User(long UserID, long CompanyID)
        {
            return (new DbEstimates()).Check_SpecialPrivilege_For_User(UserID, CompanyID);
        }

        public static DataTable CheckSubitemPresentsorNotinItemDescriptionpage(long ParentItemID, string ParentItemType)
        {
            return (new DbEstimates()).CheckSubitemPresentsorNotinItemDescriptionpage(ParentItemID, ParentItemType);
        }

        public static DataTable client_tax_select(int CompanyID, int CustomerID)
        {
            return (new DbEstimates()).client_tax_select(CompanyID, CustomerID);
        }

        public static DataTable Clients_New_Contact_Select(int CompanyID, int ClientID)
        {
            return (new DbEstimates()).Clients_New_Contact_Select(CompanyID, ClientID);
        }

        public static long copy_booklet_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_booklet_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_large_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_large_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_othercost_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_othercost_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_outwork_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_outwork_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_pad_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_pad_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_price_catalogue(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_price_catalogue(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_warehouse_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimates()).copy_warehouse_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static DataTable CopyesttitletoitemTitle(int Companyid, long EstimateID)
        {
            return (new DbEstimates()).CopyesttitletoitemTitle(Companyid, EstimateID);
        }

        public static DataTable Copying_ArtworkFile(long CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).Copying_ArtworkFile(CompanyID, EstimateItemID);
        }

        public static void copyJobInvoice_isdirect(int CompanyID, long EstimateID, string Isdirect)
        {
            (new DbEstimates()).copyJobInvoice_isdirect(CompanyID, EstimateID, Isdirect);
        }

        public static DataTable cost_view_for_booklet(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return (new DbEstimates()).cost_view_for_booklet(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static void delete_on_booklet(int CompanyID, long EstimateItemID)
        {
            (new DbEstimates()).delete_on_booklet(CompanyID, EstimateItemID);
        }

        public static void deletencrsection(long Estimateitemid, int DelPartsCount)
        {
            (new DbEstimates()).deletencrsection(Estimateitemid, DelPartsCount);
        }

        public static void Estimate_AccountingCode_Insert(int AccountCodeID, long EstimateID, long CompanyID)
        {
            (new DbEstimates()).Estimate_AccountingCode_Insert(AccountCodeID, EstimateID, CompanyID);
        }

        public static int Estimate_AccountingCode_Select(long EstimateID, long CompanyID)
        {
            return (new DbEstimates()).Estimate_AccountingCode_Select(EstimateID, CompanyID);
        }

        public static DataTable estimate_booklet_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimates()).estimate_booklet_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_Calculation_select(int CompanyID, long EstimateItemID, long EstimateBNLBItemID)
        {
            return (new DbEstimates()).estimate_Calculation_select(CompanyID, EstimateItemID, EstimateBNLBItemID);
        }

        public static DataTable estimate_click_charge_zone_2nd_calculation(int CompanyID, long EstimateCalculationID, decimal TotalSheets, string ZoneType)
        {
            return (new DbEstimates()).estimate_click_charge_zone_2nd_calculation(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void estimate_click_charge_zone_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            (new DbEstimates()).estimate_click_charge_zone_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static DataTable estimate_click_charge_zone_range_check(int CompanyID, long EstimateCalculationID, decimal TotalSheets, string ZoneType)
        {
            return (new DbEstimates()).estimate_click_charge_zone_range_check(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void Estimate_Copy(int CompanyID, long EstimateID, string EstimateNumber, int UserID)
        {
            (new DbEstimates()).Estimate_Copy(CompanyID, EstimateID, EstimateNumber, UserID);
        }

        public static long estimate_copy_all(int CompanyID, long ModuleID, long NewEstimateID, string pgType, string DirectJObOrInvoice, string Date, bool IsHandy, int newCustomer)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_copy_all(CompanyID, ModuleID, NewEstimateID, pgType, DirectJObOrInvoice, Date, IsHandy, newCustomer);
        }

        public static long Estimate_Copy_Estimate_Insert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.Estimate_Copy_Estimate_Insert(CompanyID, Old_EstimateID, DirectJObOrInvoice, UserID, Date, IsHandy, Pgtype, ModuleID);
        }
        public static long EstimateCopyEstimateInsert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID, DateTime Estimateartworkdate, DateTime Estimatedeliverydate, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProductionDate)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.EstimateCopyEstimateInsert(CompanyID, Old_EstimateID, DirectJObOrInvoice, UserID, Date, IsHandy, Pgtype, ModuleID, Estimateartworkdate, Estimatedeliverydate, JobCompletionDate, ProofDate, ApprovalDate, ProductionDate);
        }
        public static DataTable estimate_delivery_quantity_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
        {
            return (new DbEstimates()).estimate_delivery_quantity_details_select(CompanyID, EstimateID, EstimateItemID, EstimateType, PageType);
        }

        public static DataTable estimate_deliverynote_ByJobID_selectall(int CompanyID, long JobID)
        {
            return (new DbEstimates()).estimate_deliverynote_ByJobID_selectall(CompanyID, JobID);
        }

        public static DataTable estimate_deliverynote_onitemid_selectall(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimate_deliverynote_onitemid_selectall(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_deliverynote_onitemid_selectIndividual(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_deliverynote_onitemid_selectIndividual(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable estimate_deliverynote_Select_ByDeleveryID(int CompanyID, long DeleveryID)
        {
            return (new DbEstimates()).estimate_deliverynote_Select_ByDeleveryID(CompanyID, DeleveryID);
        }

        public static DataTable Estimate_ESTID_JOBID_INVID_Select(long EstimateItemID)
        {
            return (new DbEstimates()).Estimate_ESTID_JOBID_INVID_Select(EstimateItemID);
        }

        public static DataTable estimate_EstimateID_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
        {
            return (new DbEstimates()).estimate_EstimateID_select_reeng_ByInvoice(CompanyID, InvoiceID, Pgtype);
        }

        public static DataTable estimate_EstTotalPriceDetails_Update(long EstimateItemID)
        {
            return (new DbEstimates()).estimate_EstTotalPriceDetails_Update(EstimateItemID);
        }

        public static DataSet estimate_for_litho_add_all(int CompanyID)
        {
            return (new DbEstimates()).estimate_for_litho_add_all(CompanyID);
        }

     
        public static DataSet estimate_for_Digital_add_all(int CompanyID)
        {
            return (new DbEstimates()).estimate_for_Digital_add_all(CompanyID);
        }

        public static long Estimate_Insert(int CompanyID, int UserID, int CustomerID, long AttentionID, string Greeting, string Company, long Address, string Header, string Footer, int SalesPerson, string EstimateTitle, string EstimateNumber, string OrderNumber, int StatusID, DateTime EstimateDate, int ValidFor, long DeliveryAddress, bool IsConvertedToJob, DateTime ModifiedDate, int ModifiedBy, long EstimateID, bool IsForInvoice, string AddressType, string DelAddressType, long CurrentEstNo, DateTime EstimatedArtwork, DateTime EstimatedDelivery, string PageType, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProdcnDate, long InvoiceAddressID, long DepartmentID, long CostCentreID, int estimatorid, string Comments, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.Estimate_Insert(CompanyID, UserID, CustomerID, AttentionID, Greeting, Company, Address, Header, Footer, SalesPerson, EstimateTitle, EstimateNumber, OrderNumber, StatusID, EstimateDate, ValidFor, DeliveryAddress, IsConvertedToJob, ModifiedDate, ModifiedBy, EstimateID, IsForInvoice, AddressType, DelAddressType, CurrentEstNo, EstimatedArtwork, EstimatedDelivery, PageType, JobCompletionDate, ProofDate, ApprovalDate, ProdcnDate, InvoiceAddressID, DepartmentID, CostCentreID, estimatorid,Comments,  InvoiceContactId, priority, customDate1, customDate2, customDate3, customDate4, customDate5);
        }

        public static int estimate_iscompleted_select(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).estimate_iscompleted_select(CompanyID, EstimateID);
        }

        internal static void Estimate_Item_AccountCode_Insert(long EstimateItemID, int AccountCodeID)
        {
            (new DbEstimates()).Estimate_Item_AccountCode_Insert(EstimateItemID, AccountCodeID);
        }

        public static DataTable estimate_item_detail_outwork_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_item_detail_outwork_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_item_detail_quantities_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
        {
            return (new DbEstimates()).estimate_item_detail_quantities_select(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID);
        }

        public static void estimate_item_details_insert(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            (new DbEstimates()).estimate_item_details_insert(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimate_item_details_select(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_details_selectall(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimate_item_details_selectall(CompanyID, EstimateItemID, EstimateType);
        }

        public static void estimate_item_details_update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimate_item_details_update(CompanyID, EstimateID, EstimateItemID, EstimateType, Qty1, Qty2, Qty3, Qty4, ReqPrePress, ReqPress, ReqPostPress, ReqPriceCatalogue, ReqOutwork, ReqWarehouse, ReqAdmin);
        }

        public static DataTable Estimate_Item_ID_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).Estimate_Item_ID_Select(CompanyID, EstimateID);
        }

        public static DataSet estimate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            return (new DbEstimates()).estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
        }
        public static DataSet estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType, long EstimateItemIDForRaisePO)
        {
            return (new DbEstimates()).estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(CompanyID, EstimateItemID, QtyNumber, ItemType, EstimateItemIDForRaisePO);
        }

        public static long Estimate_Item_Insert(int CompanyID, long EstimateID, string EstimateType, bool IsParentItem, long ParentItemID, long ProductID = 0)
        {
            return (new DbEstimates()).Estimate_Item_Insert(CompanyID, EstimateID, EstimateType, IsParentItem, ParentItemID, ProductID);
        }

        public static string estimate_item_quantity_fordelivery_select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, int QtyNumber)
        {
            return (new DbEstimates()).estimate_item_quantity_fordelivery_select(CompanyID, EstimateItemID, ItemID, ItemType, QtyNumber);
        }

        public static DataTable estimate_item_select(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).estimate_item_select(CompanyID, EstimateID);
        }

        public static DataTable estimate_item_select_ByModule(int CompanyID, long ModuleID, string Pgtype)
        {
            return (new DbEstimates()).estimate_item_select_ByModule(CompanyID, ModuleID, Pgtype);
        }

        public static DataTable estimate_item_select_reeng(int CompanyID, long EstimateID, string Pgtype)
        {
            return (new DbEstimates()).estimate_item_select_reeng(CompanyID, EstimateID, Pgtype);
        }
        public static DataTable estimate_summary_total(long ModuleID, string ModuleType)
        {
            return (new DbEstimates()).estimate_summary_total(ModuleID, ModuleType);
        }

        public static DataTable estimate_item_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
        {
            return (new DbEstimates()).estimate_item_select_reeng_ByInvoice(CompanyID, InvoiceID, Pgtype);
        }

        public static DataTable estimate_item_select_reeng_ByJob(int CompanyID, long JobID, string Pgtype)
        {
            return (new DbEstimates()).estimate_item_select_reeng_ByJob(CompanyID, JobID, Pgtype);
        }

        public static void estimate_item_title_update(int CompanyID, long EstimateItemID, string ItemTitle, string EstimateType)
        {
            (new DbEstimates()).estimate_item_title_update(CompanyID, EstimateItemID, ItemTitle, EstimateType);
        }

        public static DataTable estimate_item_total_price_details_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimate_item_total_price_details_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_total_price_details_update(long EstimateID, long EstimateItemID, long SectionID, string EstimateType, decimal TotalProfitMarginPercentage1, decimal TotalProfitMarginPercentage2, decimal TotalProfitMarginPercentage3, decimal TotalProfitMarginPercentage4, decimal TotalProfitMarginPrice1, decimal TotalProfitMarginPrice2, decimal TotalProfitMarginPrice3, decimal TotalProfitMarginPrice4, decimal TotalSubTotal1, decimal TotalSubTotal2, decimal TotalSubTotal3, decimal TotalSubTotal4, int TotalTaxID1, int TotalTaxID2, int TotalTaxID3, int TotalTaxID4, decimal TotalTaxPercentage1, decimal TotalTaxPercentage2, decimal TotalTaxPercentage3, decimal TotalTaxPercentage4, decimal TotalTaxPrice1, decimal TotalTaxPrice2, decimal TotalTaxPrice3, decimal TotalTaxPrice4, decimal TotalSellingPrice1, decimal TotalSellingPrice2, decimal TotalSellingPrice3, decimal TotalSellingPrice4, decimal TotalGrossProfitPercentage1, decimal TotalGrossProfitPercentage2, decimal TotalGrossProfitPercentage3, decimal TotalGrossProfitPercentage4, decimal TotalGrossProfitPrice1, decimal TotalGrossProfitPrice2, decimal TotalGrossProfitPrice3, decimal TotalGrossProfitPrice4, bool IsSubTotalLocked, decimal SellingPricePerSQM1, decimal SellingPricePerSQM2, decimal SellingPricePerSQM3, decimal SellingPricePerSQM4, decimal SubTotalUnitPrice1, decimal SubTotalUnitPrice2, decimal SubTotalUnitPrice3, decimal SubTotalUnitPrice4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_item_total_price_details_update(EstimateID, EstimateItemID, SectionID, EstimateType, TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4, TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4, TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4, TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4, TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4, TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4, TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4, TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4, TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4, IsSubTotalLocked,  SellingPricePerSQM1,  SellingPricePerSQM2,  SellingPricePerSQM3,  SellingPricePerSQM4, SubTotalUnitPrice1, SubTotalUnitPrice2, SubTotalUnitPrice3, SubTotalUnitPrice4);
        }

        public static DataTable estimate_itemandsubitem_select(long EstimateID)
        {
            return (new DbEstimates()).estimate_itemandsubitem_select(EstimateID);
        }

        public static int Estimate_Items_Count_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).Estimate_Items_Count_Select(CompanyID, EstimateID);
        }

        public static void Estimate_Items_Delete(int CompanyID, long EstimateItemID, string Estimatetype)
        {
            (new DbEstimates()).Estimate_Items_Delete(CompanyID, EstimateItemID, Estimatetype);
        }

        public static DataTable Estimate_Items_Quantity_Select(int CompanyID, int EstimateItemID, string EstType)
        {
            return (new DbEstimates()).Estimate_Items_Quantity_Select(CompanyID, EstimateItemID, EstType);
        }

        public static DataTable Estimate_Items_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
        {
            return (new DbEstimates()).Estimate_Items_RFQdescription_Select(CompanyID, EstimateID, ModuleType);
        }

        public static DataTable Estimate_ProofItems_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
        {
            return (new DbEstimates()).Estimate_ProofItems_RFQdescription_Select(CompanyID, EstimateID, ModuleType);
        }
        // create delivery note
        public static DataTable Estimate_ByEstimateItemId_Select(int CompanyID, long EstimateItemID, string ModuleType)
        {
            return (new DbEstimates()).Estimate_ByEstimateItemId_Select(CompanyID, EstimateItemID, ModuleType);
        }
        public static DataTable Estimate_Items_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).Estimate_Items_Select(CompanyID, EstimateID);
        }

        public static DataSet estimate_itemtitle_select(int CompanyID, long EstimateItemID, string ItemType, int qtynumber)
        {
            return (new DbEstimates()).estimate_itemtitle_select(CompanyID, EstimateItemID, ItemType, qtynumber);
        }

        public static void estimate_itemtitle_update(long EstimateID, string EstimateTitle)
        {
            (new DbEstimates()).estimate_itemtitle_update(EstimateID, EstimateTitle);
        }

        public static DataTable estimate_large_item_ink(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_large_item_ink(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_large_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_large_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_largeitemMetarals_select(long EstimateItemID)
        {
            return (new DbEstimates()).estimate_largeitemMetarals_select(EstimateItemID);
        }

        public static DataTable estimate_litho_booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_Litho_ink_select(int CompanyID, long PressID)
        {
            return (new DbEstimates()).estimate_Litho_ink_select(CompanyID, PressID);
        }

        public static DataTable estimate_litho_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
        {
            return (new DbEstimates()).estimate_litho_ink_select_inkcost_popup(CompanyID, EstimateItemID, SectionName, CalType);
        }

        public static long estimate_litho_NCR_item_insert(int CompanyID, int EstimateLithoNcrItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetUpSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, long GuillotineID, int CreatedBy, int ModifiedBy, DateTime CreatedDate, bool IsDeleted, string ItemTitle, string ItemDescription, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, string SectionReference, decimal NcrPartsPerSet, decimal NcrSetsPerPad, string NcrImageType, string NcrPadFormat, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, string Ncrcommonfrom, bool Perfecting, decimal ManualValue,bool sheetwork)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_litho_NCR_item_insert(CompanyID, EstimateLithoNcrItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage, sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, GuillotineID, CreatedBy, ModifiedBy, CreatedDate, IsDeleted, ItemTitle, ItemDescription, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, SectionReference, NcrPartsPerSet, NcrSetsPerPad, NcrImageType, NcrPadFormat, PrintLayout, PortraitValue, LandscapeValue, Ncrcommonfrom, Perfecting, ManualValue, sheetwork);
        }

        public static DataTable estimate_litho_ncr_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_ncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_digital_ncr_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_digital_ncr_item_select(CompanyID, EstimateItemID);
        }

        public static long estimate_litho_pad_item_insert(int CompanyID, long EstimateLithoPadItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, decimal LeavesPerPad, string SidesPrinted, string Side1Color, string Side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue,bool worksheet)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_litho_pad_item_insert(CompanyID, EstimateLithoPadItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetupSpoilage, RunningSpoilage, LeavesPerPad, SidesPrinted, Side1Color, Side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID, ItemTitle, CreatedBy, ModifiedBy, ModifiedDate, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, Perfecting, ManualValue, worksheet);
        }

        public static DataTable estimate_litho_pad_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_litho_pad_item_select_reeng(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_pad_item_select_reeng(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_litho_plate_select_popup(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_plate_select_popup(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Litho_Press_Select(int CompanyID, long PressID)
        {
            return (new DbEstimates()).Estimate_Litho_Press_Select(CompanyID, PressID);
        }
        public static DataTable Estimate_Digital_Press_Select_byPressID(int CompanyID, long PressID)
        {
            return (new DbEstimates()).Estimate_Digital_Press_Select_byPressID(CompanyID, PressID);
        }

        public static DataTable estimate_litho_single_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_litho_single_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_lithobooklet_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
        {
            return (new DbEstimates()).estimate_lithobooklet_ink_select_inkcost_popup(CompanyID, EstimateItemID, TypeID, SectionName, CalType);
        }

        public static DataTable estimate_lithobooklet_plateswashupmakeready_popup(int CompanyID, long EstimateItemID, long EstimateLithoBookletItemID)
        {
            return (new DbEstimates()).estimate_lithobooklet_plateswashupmakeready_popup(CompanyID, EstimateItemID, EstimateLithoBookletItemID);
        }

        public static DataTable estimate_lithoNCR_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
        {
            return (new DbEstimates()).estimate_lithoNCR_ink_select_inkcost_popup(CompanyID, EstimateItemID, TypeID, SectionName, CalType);
        }

        public static DataTable estimate_lithoNCR_select_popup(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return (new DbEstimates()).estimate_lithoNCR_select_popup(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static DataTable estimate_lithoPad_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
        {
            return (new DbEstimates()).estimate_lithoPad_ink_select_inkcost_popup(CompanyID, EstimateItemID, SectionName, CalType);
        }

        public static DataTable estimate_lithoPad_plate_select_popup(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_lithoPad_plate_select_popup(CompanyID, EstimateItemID);
        }

        public static void estimate_lithopress_delete_ink(int CompanyID, long LithoPressID, long EstimateItemID, string EstType, long EstimateLithoItemID)
        {
            (new DbEstimates()).estimate_lithopress_delete_ink(CompanyID, LithoPressID, EstimateItemID, EstType, EstimateLithoItemID);
        }

        public static IDataReader estimate_lithopress_select_ink_count(int CompanyID, long LithoPressID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_lithopress_select_ink_count(CompanyID, LithoPressID, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID);
        }

        public static DataTable estimate_lithopress_select_ink_name_item_desc(int CompanyID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string esttype)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, esttype);
        }

        public static IDataReader estimate_lithopress_select_ink_rownum(int CompanyID, long LithoPressID, int rownum, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string sidenumber)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_lithopress_select_ink_rownum(CompanyID, LithoPressID, rownum, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, sidenumber);
        }

        public static void estimate_number_update(int CompanyID, long EstimateID, bool IsHandy)
        {
            (new DbEstimates()).estimate_number_update(CompanyID, EstimateID, IsHandy);
        }

        public static DataTable estimate_othercost_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_othercost_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_othercost_press_details_select(long CompanyID, long EstimateItemID, string EstimateType, long BookletSectionID)
        {
            return (new DbEstimates()).estimate_othercost_press_details_select(CompanyID, EstimateItemID, EstimateType, BookletSectionID);
        }

        public static DataTable estimate_othercost_ProfitTax_select(long EstimateItemID, long EstOthercostID)
        {
            return (new DbEstimates()).estimate_othercost_ProfitTax_select(EstimateItemID, EstOthercostID);
        }

        public static string estimate_othercost_select_new(int CompanyID, string EstimateType, long TypeID, string MainOrSubItem)
        {
            return (new DbEstimates()).estimate_othercost_select_new(CompanyID, EstimateType, TypeID, MainOrSubItem);
        }

        public static DataTable estimate_othercost_subitem_costview(int CompanyID, long EstOtherCostID)
        {
            return (new DbEstimates()).estimate_othercost_subitem_costview(CompanyID, EstOtherCostID);
        }

        public static DataTable estimate_othercost_subitem_select(int CompanyID, long TypeID)
        {
            return (new DbEstimates()).estimate_othercost_subitem_select(CompanyID, TypeID);
        }

        public static void estimate_othercost_typeid_update(int CompanyID, long EstimateItemID, string EstimateType, long TypeID)
        {
            (new DbEstimates()).estimate_othercost_typeid_update(CompanyID, EstimateItemID, EstimateType, TypeID);
        }

        public static long estimate_othercost_variableqty_insert(int CompanyID, long EstOtherCostVariableID, long EstOtherCostID, long EstQuantityID, decimal HoursOrQty, decimal Cost, string EstType, string FormulaWithActual, int Quantity, int qtynumber, string FinalFormulaTag)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.estimate_othercost_variableqty_insert(CompanyID, EstOtherCostVariableID, EstOtherCostID, EstQuantityID, HoursOrQty, Cost, EstType, FormulaWithActual, Quantity, qtynumber, FinalFormulaTag);
        }

        public static DataSet estimate_Othercostitem_info(int CompanyID, long EstimateID, int QtyNumber, string ItemType)
        {
            return (new DbEstimates()).estimate_Othercostitem_info(CompanyID, EstimateID, QtyNumber, ItemType);
        }

        public static void Estimate_OtherWare_MainItems_Pricing_Update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, decimal CostPrice1ExMarkup, decimal TotalMarkupPrice1, int QtyNumber, long EstOutworkSupplierID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.Estimate_OtherWare_MainItems_Pricing_Update(CompanyID, EstimateID, EstimateItemID, EstimateType, CostPrice1ExMarkup, TotalMarkupPrice1, QtyNumber, EstOutworkSupplierID);
        }

        public static void Estimate_Outwork_Insert(int CompanyID, string Query)
        {
            (new DbEstimates()).Estimate_Outwork_Insert(CompanyID, Query);
        }

        public static DataTable estimate_outwork_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_outwork_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_pad_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimates()).estimate_pad_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_pad_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_press_select(int companyID)
        {
            return (new DbEstimates()).estimate_press_select(companyID);
        }

        public static DataTable estimate_Digital_press_select(int companyID)
        {
            return (new DbEstimates()).estimate_Digital_press_select(companyID);
        }

        public static DataTable estimate_price_catalogue_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_price_catalogue_item_select(CompanyID, EstimateItemID);
        }

        public static string estimate_printbroker_itemdescription_select(int CompanyID, long EstimateItemID, string EstimateType, string SelectType)
        {
            return (new DbEstimates()).estimate_printbroker_itemdescription_select(CompanyID, EstimateItemID, EstimateType, SelectType);
        }

        public static DataTable estimate_printbroker_select(int CompanyID, long EstOutworkID)
        {
            return (new DbEstimates()).estimate_printbroker_select(CompanyID, EstOutworkID);
        }

        public static DataTable estimate_printbroker_select_new(int CompanyID, long EstOutworkID, int rownumber)
        {
            return (new DbEstimates()).estimate_printbroker_select_new(CompanyID, EstOutworkID, rownumber);
        }

        public static DataTable estimate_printbroker_subitem_select(int CompanyID, long EstOutworkID)
        {
            return (new DbEstimates()).estimate_printbroker_subitem_select(CompanyID, EstOutworkID);
        }

        public static DataTable estimate_printbroker_suppliers_count(int CompanyID, string Estype, long TypeID)
        {
            return (new DbEstimates()).estimate_printbroker_suppliers_count(CompanyID, Estype, TypeID);
        }

        public static DataTable estimate_qty_onQtyNumber_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID, int QtyNumber)
        {
            return (new DbEstimates()).estimate_qty_onQtyNumber_select(CompanyID, EstimateItemID, EstimateBookletItemID, QtyNumber);
        }

        public static DataTable estimate_qty_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return (new DbEstimates()).estimate_qty_select(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static DataTable estimate_qty_select_for_booklet(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_qty_select_for_booklet(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_quantity_forcostview_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimate_quantity_forcostview_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_quantity_select_new(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return (new DbEstimates()).estimate_quantity_select_new(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static DataTable estimate_quick_quote_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_quick_quote_item_select(CompanyID, EstimateItemID);
        }

        public static void Estimate_quickquote_insert(EstimatesItem item, bool IsHandy)
        {
            (new DbEstimates()).Estimate_quickquote_insert(item, IsHandy);
        }

        public static DataTable estimate_RaisePoOrders_Selectitems(long EstimateID)
        {
            return (new DbEstimates()).estimate_RaisePoOrders_Selectitems(EstimateID);
        }

        public static DataTable estimate_select_litho_details_all(int CompanyID, int LithoPressID)
        {
            return (new DbEstimates()).estimate_select_litho_details_all(CompanyID, LithoPressID);
        }

        public static DataTable estimate_select_litho_ink_count(int CompanyID, int LithoPressID)
        {
            return (new DbEstimates()).estimate_select_litho_ink_count(CompanyID, LithoPressID);
        }

        public static DataTable estimate_select_paper_size(int CompanyID)
        {
            return (new DbEstimates()).estimate_select_paper_size(CompanyID);
        }

        public static DataTable estimate_select_summary(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).estimate_select_summary(CompanyID, EstimateID);
        }
        public static DataTable order_select_summary(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).order_select_summary(CompanyID, EstimateID);
        }
        public static DataTable estimate_select_summary_new(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).estimate_select_summary_new(CompanyID, EstimateID);
        }
        
        public static DataTable PC_Proof_select_summary_new(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).PC_Proof_select_summary_new(CompanyID, EstimateID);
        }

        public static DataTable estimate_select_summary_PerItem(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_select_summary_PerItem(CompanyID, EstimateItemID);
        }

        public static DataTable proof_select_summary_PerItem(int CompanyID, long ProofItemID)
        {
            return (new DbEstimates()).proof_select_summary_PerItem(CompanyID, ProofItemID);
        }

        public static DataTable estimate_single_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimates()).estimate_single_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_single_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_single_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Single_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).Estimate_Single_Item_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_SingleItem_Subitem_By_EstimateItemID(int CompanyID, long EstimateItemID, string esttype)
        {
            return (new DbEstimates()).Estimate_SingleItem_Subitem_By_EstimateItemID(CompanyID, EstimateItemID, esttype);
        }

        public static void estimate_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            (new DbEstimates()).estimate_speed_weight_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static DataTable estimate_speedweight_select(int CompanyID, long EstimateCalculationID)
        {
            return (new DbEstimates()).estimate_speedweight_select(CompanyID, EstimateCalculationID);
        }

        public static void estimate_sub_item_delete(string EstimateType, long EstimateItemID, long ItemTypeID)
        {
            (new DbEstimates()).estimate_sub_item_delete(EstimateType, EstimateItemID, ItemTypeID);
        }

        public static void estimate_subitem_delete(string EstimateType, long EstimateItemID, long EstimateSPLBWOCU)
        {
            (new DbEstimates()).estimate_subitem_delete(EstimateType, EstimateItemID, EstimateSPLBWOCU);
        }

        public static void estimate_subitem_delete_FromSummary(string EstimateType, long EstimateItemID)
        {
            (new DbEstimates()).estimate_subitem_delete_FromSummary(EstimateType, EstimateItemID);
        }

        public static DataTable estimate_subitem_select(long EstimateID, long ParentItemID)
        {
            return (new DbEstimates()).estimate_subitem_select(EstimateID, ParentItemID);
        }

        public static DataTable estimate_subitem_select_New(long ParentItemID)
        {
            return (new DbEstimates()).estimate_subitem_select_New(ParentItemID);
        }

        public static DataSet Estimate_Subitem_showonItemdesc(int CompanyID, long EstimateItemID, string Estimationtype)
        {
            return (new DbEstimates()).Estimate_Subitem_showonItemdesc(CompanyID, EstimateItemID, Estimationtype);
        }

        public static DataTable Estimate_Summary_Calculation_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID, long EstBookletSectionID)
        {
            return (new DbEstimates()).Estimate_Summary_Calculation_Select_By_EstimateItem_ID(CompanyID, EstimateItemID, EstBookletSectionID);
        }

        public static void Estimate_Summary_EstimateValues_Update(int CompanyID, long EstimateID, decimal EstimateValue, decimal EstimateSubTotal, int EstimateTotalQuantity)
        {
            (new DbEstimates()).Estimate_Summary_EstimateValues_Update(CompanyID, EstimateID, EstimateValue, EstimateSubTotal, EstimateTotalQuantity);
        }

        public static decimal Estimate_Summary_Guillotine_Standard_Table(int CompanyID, decimal Printlayout, string IsGutter)
        {
            return (new DbEstimates()).Estimate_Summary_Guillotine_Standard_Table(CompanyID, Printlayout, IsGutter);
        }

        public static string Estimate_Summary_Item_Warehouse_Cost(int CompanyID, long TypeID, string ItemType)
        {
            return (new DbEstimates()).Estimate_Summary_Item_Warehouse_Cost(CompanyID, TypeID, ItemType);
        }

        public static DataTable estimate_summary_items_othercost_select_new(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID)
        {
            return (new DbEstimates()).estimate_summary_items_othercost_select_new(CompanyID, EstimateType, TypeID, EstOtherCostID);
        }

        public static DataTable Estimate_Summary_Items_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).Estimate_Summary_Items_select_by_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Summary_Large_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).Estimate_Summary_Large_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_summary_othercost_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_summary_othercost_by_estimateitem_id_new(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_summary_outwork_taxprofitmargin_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_summary_outwork_taxprofitmargin_select(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Pad_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).Estimate_Summary_Pad_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Warehouse_Insert(int CompanyID, string Query, long EstimateItemID)
        {
            (new DbEstimates()).Estimate_Warehouse_Insert(CompanyID, Query, EstimateItemID);
        }

        public static DataTable estimate_warehouse_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_warehouse_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_zone_calculation_1(int CompanyID, long EstimateCalculationID, int TotalSheets, string ZoneType)
        {
            return (new DbEstimates()).estimate_zone_calculation_1(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void estimate_zone_markup_update(int CompanyID, long EstimateCalculationID, decimal Markup)
        {
            (new DbEstimates()).estimate_zone_markup_update(CompanyID, EstimateCalculationID, Markup);
        }

        public static DataTable EstimateHistory(long SupplierID, long EstimateItemID)
        {
            return (new DbEstimates()).EstimateHistory(SupplierID, EstimateItemID);
        }

        public static void EstimateItem_Archive(int CompanyID, long EstimateItemID, string ModuleType)
        {
            (new DbEstimates()).EstimateItem_Archive(CompanyID, EstimateItemID, ModuleType);
        }
        public static void ProofItem_Archive(int CompanyID, long ProofItemID)
        {
            (new DbEstimates()).ProofItem_Archive(CompanyID, ProofItemID);
        }
        public static void EstimateItem_Delete(int CompanyID, long EstimateItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
        {
            (new DbEstimates()).EstimateItem_Delete(CompanyID, EstimateItemID, ModuleType, Keep_EstimateJOB_LIVE);
        }
        public static void ProofItem_Delete(int CompanyID, long ProofItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
        {
            (new DbEstimates()).ProofItem_Delete(CompanyID, ProofItemID, ModuleType, Keep_EstimateJOB_LIVE);
        }

        public static void EstimateItem_UnArchive(int CompanyID, long EstimateItemID, string ModuleType)
        {
            (new DbEstimates()).EstimateItem_UnArchive(CompanyID, EstimateItemID, ModuleType);
        }

        public static DataTable EstimateitemIDList_PerEstID(long EstimateID)
        {
            return (new DbEstimates()).EstimateitemIDList_PerEstID(EstimateID);
        }

        public static DataTable EstimateitemIDList_PerEstItemID(long EstimateItemID)
        {
            return (new DbEstimates()).EstimateitemIDList_PerEstItemID(EstimateItemID);
        }

        public static DataTable estimateitemselect_reeng(int CompanyID, long EstimateItemID, string Pgtype)
        {
            return (new DbEstimates()).estimateitemselect_reeng(CompanyID, EstimateItemID, Pgtype);
        }

        public static long EstimateItemsOnCheck_Status_Update(int CompanyID, string EstimateItemIDs, int StatusID, string Module)
        {
            return (new DbEstimates()).EstimateItemsOnCheck_Status_Update(CompanyID, EstimateItemIDs, StatusID, Module);
        }

        public static void estimatenumberupdateandiscomplete(int CompanyID, long EstimateID, long EstimateItemID, bool IsHandy)
        {
            (new DbEstimates()).estimatenumberupdateandiscomplete(CompanyID, EstimateID, EstimateItemID, IsHandy);
        }

        public static DataSet estimatePlate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            return (new DbEstimates()).estimatePlate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
        }

        public static void estimates_litho_markup_calculation_insert(int CompanyID, long EstimateCalculationID)
        {
            (new DbEstimates()).estimates_litho_markup_calculation_insert(CompanyID, EstimateCalculationID);
        }
        public static void estimates_litho_markup_calculation_insertnew(int CompanyID, long EstimateCalculationID,long PressID)
        {
            (new DbEstimates()).estimates_litho_markup_calculation_insertnew(CompanyID, EstimateCalculationID,PressID);
        }
        public static void estimates_litho_markup_calculation_update(int CompanyID, long EstimateItemID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType)
        {
            (new DbEstimates()).estimates_litho_markup_calculation_update(CompanyID, EstimateItemID, Markup, EstCalType, EstimateBookletItemID, EstimateType);
        }

        public static DataTable estimates_litho_press_matrix_select_By_ID(int CompanyID, long EstimateCalculationID)
        {
            return (new DbEstimates()).estimates_litho_press_matrix_select_By_ID(CompanyID, EstimateCalculationID);
        }

        public static void estimates_markup_calculation_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module, decimal CostExMarkup_Actual1, decimal CostExMarkup_Actual2, decimal CostExMarkup_Actual3, decimal CostExMarkup_Actual4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimates_markup_calculation_update(CompanyID, EstimateCalculationID, Markup, EstCalType, EstimateBookletItemID, EstimateType, Markup2, Markup3, Markup4, MarkupPrice1, MarkupPrice2, MarkupPrice3, MarkupPrice4, CostExMarkup1, CostExMarkup2, CostExMarkup3, CostExMarkup4, Module, CostExMarkup_Actual1, CostExMarkup_Actual2, CostExMarkup_Actual3, CostExMarkup_Actual4);
        }

        public static void estimates_markup_calculation_update_ForPressZone(int CompanyID, long EstimateCalculationID, long TypeID, string EstimateType, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal PressMarkupPrice1, decimal PressMarkupPrice2, decimal PressMarkupPrice3, decimal PressMarkupPrice4, string Module, decimal PressCostExMarkup1, decimal PressCostExMarkup2, decimal PressCostExMarkup3, decimal PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimates_markup_calculation_update_ForPressZone(CompanyID, EstimateCalculationID, TypeID, EstimateType, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, PressMarkupPrice1, PressMarkupPrice2, PressMarkupPrice3, PressMarkupPrice4, Module, PressCostExMarkup1, PressCostExMarkup2, PressCostExMarkup3, PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4);
        }

        public static void estimates_Materialmarkup_calculation_update(int CompanyID, long EstimateCalculationID, string EstimateType, decimal Markup1, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimates_Materialmarkup_calculation_update(CompanyID, EstimateCalculationID, EstimateType, Markup1, Markup2, Markup3, Markup4, MarkupPrice1, MarkupPrice2, MarkupPrice3, MarkupPrice4, CostExMarkup1, CostExMarkup2, CostExMarkup3, CostExMarkup4, Module);
        }

        public static string estimates_outworkdescription_printemail_select(int CompanyID, long EstOutworkID)
        {
            return (new DbEstimates()).estimates_outworkdescription_printemail_select(CompanyID, EstOutworkID);
        }

        public static string estimates_quantity_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).estimates_quantity_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static void estimates_zonemarkup_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, string ZoneType)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimates_zonemarkup_update(CompanyID, EstimateCalculationID, Markup, EstCalType, EstimateBookletItemID, EstimateType, ZoneType);
        }

        public static void estimateslitho_popup_ink_insert(int CompanyID, long estimateitemid, long inkid, decimal coverage, long PressID, string Side, long LithoItemID, string EstimateType, string sidenumber, string SectionName, decimal InkCostExMarkup1, decimal InkCostExMarkup2, decimal InkCostExMarkup3, decimal InkCostExMarkup4, decimal InkMarkup1, decimal InkMarkup2, decimal InkMarkup3, decimal InkMarkup4, decimal InkMarkupPrice1, decimal InkMarkupPrice2, decimal InkMarkupPrice3, decimal InkMarkupPrice4, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual1, decimal InkCostExMarkup_Actual2, decimal InkCostExMarkup_Actual3, decimal InkCostExMarkup_Actual4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.estimateslitho_popup_ink_insert(CompanyID, estimateitemid, inkid, coverage, PressID, Side, LithoItemID, EstimateType, sidenumber, SectionName, InkCostExMarkup1, InkCostExMarkup2, InkCostExMarkup3, InkCostExMarkup4, InkMarkup1, InkMarkup2, InkMarkup3, InkMarkup4, InkMarkupPrice1, InkMarkupPrice2, InkMarkupPrice3, InkMarkupPrice4, InkSetupCharge, InkMinimumCharge, InkCostExMarkup_Actual1, InkCostExMarkup_Actual2, InkCostExMarkup_Actual3, InkCostExMarkup_Actual4);
        }

        public static DataTable EstimatItem_Details_Select(int CompanyID, long EstimateID, string PageType)
        {
            return (new DbEstimates()).EstimatItem_Details_Select(CompanyID, EstimateID, PageType);
        }

        public static DataTable estitem_select_ToConvertProductCatalogue(int CompanyID, long EstimateID, long PrarentItemID, string Pgtype)
        {
            return (new DbEstimates()).estitem_select_ToConvertProductCatalogue(CompanyID, EstimateID, PrarentItemID, Pgtype);
        }

        public static DataTable EstPriceCatAddOptionDetailsSelect(long EstimateItemID)
        {
            return (new DbEstimates()).EstPriceCatAddOptionDetailsSelect(EstimateItemID);
        }

        public static DataTable Get_Details_EstimateItems_PriceCatalogueType(long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimates()).Get_Details_EstimateItems_PriceCatalogueType(EstimateItemID, QtyNumber);
        }

        public static DataTable Get_EstimateItems_Type_PriceCatalogue(long EstimateID)
        {
            return (new DbEstimates()).Get_EstimateItems_Type_PriceCatalogue(EstimateID);
        }

        public static DataTable Get_KitDetails_EstimateItems_PriceCatalogueType(long PriceCatalogueID, int Quantity)
        {
            return (new DbEstimates()).Get_KitDetails_EstimateItems_PriceCatalogueType(PriceCatalogueID, Quantity);
        }

        public static string GetEstimateType_EstimateItemID(long EstimateItemID)
        {
            return (new DbEstimates()).GetEstimateType_EstimateItemID(EstimateItemID);
        }
        public static int GetPriceCatalogueIDByEstimateItemID(long EstimateItemID)
        {
            return (new DbEstimates()).GetPriceCatalogueIDByEstimateItemID(EstimateItemID);
        }

        public static DataTable GetPriceCatalogueIDByEstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).GetPriceCatalogueIDByEstimateID(CompanyID, EstimateID);
        }
        public static int GetProductId_ByEstimatetItemId(int CompanyId, int EstimateItemId)
        {
            return (new DbEstimates()).GetProductId_ByEstimatetItemId(CompanyId, EstimateItemId);
        }

        public static DataTable getQuantity_for_items(long ParentEstimateItemID, string ParentEstimateType, string estimates)
        {
            return (new DbEstimates()).getQuantity_for_items(ParentEstimateItemID, ParentEstimateType, estimates);
        }

        public static DataTable GetTaxDetails_ByEstimateItemId(int EstimateItemId)
        {
            return (new DbEstimates()).GetTaxDetails_ByEstimateItemId(EstimateItemId);
        }

        public static void Ink_Delete_BasedOn_estimateitemID(long EstimateItemID)
        {
            (new DbEstimates()).Ink_Delete_BasedOn_estimateitemID(EstimateItemID);
        }

        public static DataTable Ink_Select_BasedOn_estimateitemID(long EstimateItemID)
        {
            return (new DbEstimates()).Ink_Select_BasedOn_estimateitemID(EstimateItemID);
        }

        public static DataTable inkselectfromdatabase(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).inkselectfromdatabase(CompanyID, EstimateItemID);
        }

        public static void Insert_EstPriceCatAddOptionDetails(long EstimateAdditionalItemID, long EstimateID, string CalculationType, long EstimateItemID, string SelectedValue, decimal MarkupPercentage1, decimal MarkupPercentage2, decimal MarkupPercentage3, decimal MarkupPercentage4, decimal CostPriceInMarkup1, decimal CostPriceInMarkup2, decimal CostPriceInMarkup3, decimal CostPriceInMarkup4, long SelectedID, decimal MarkupValue1, decimal MarkupValue2, decimal MarkupValue3, decimal MarkupValue4, int SortOrderNo, decimal SelectedPrice1, decimal SelectedPrice2, decimal SelectedPrice3, decimal SelectedPrice4, string EstimateOtherCostName, decimal TotalPriceExMarkup1, decimal TotalPriceExMarkup2, decimal TotalPriceExMarkup3, decimal TotalPriceExMarkup4, decimal TotalPriceIncMarkup1, decimal TotalPriceIncMarkup2, decimal TotalPriceIncMarkup3, decimal TotalPriceIncMarkup4, int IsFirst, long WebOtherCostID, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.Insert_EstPriceCatAddOptionDetails(EstimateAdditionalItemID, EstimateID, CalculationType, EstimateItemID, SelectedValue, MarkupPercentage1, MarkupPercentage2, MarkupPercentage3, MarkupPercentage4, CostPriceInMarkup1, CostPriceInMarkup2, CostPriceInMarkup3, CostPriceInMarkup4, SelectedID, MarkupValue1, MarkupValue2, MarkupValue3, MarkupValue4, SortOrderNo, SelectedPrice1, SelectedPrice2, SelectedPrice3, SelectedPrice4, EstimateOtherCostName, TotalPriceExMarkup1, TotalPriceExMarkup2, TotalPriceExMarkup3, TotalPriceExMarkup4, TotalPriceIncMarkup1, TotalPriceIncMarkup2, TotalPriceIncMarkup3, TotalPriceIncMarkup4, IsFirst, WebOtherCostID, ParentWebOtherCostID, WebOtherCostType,FreeTextQuestionLong);
        }

        public static void insert_largeitem_quantity(long EstimateItemID, long QuantityID, long MaterialID, decimal InvSheets1, decimal InvSheets2, decimal InvSheets3, decimal InvSheets4, decimal PrintSheets1, decimal PrintSheets2, decimal PrintSheets3, decimal PrintSheets4, decimal MaterialLength1, decimal MaterialLength2, decimal MaterialLength3, decimal MaterialLength4, decimal MaterialMarkupPrice1, decimal MaterialCostExMarkup1, decimal MaterialMarkupPrice2, decimal MaterialCostExMarkup2, decimal MaterialMarkupPrice3, decimal MaterialCostExMarkup3, decimal MaterialMarkupPrice4, decimal MaterialCostExMarkup4, int MaterialNo, string savetype)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.insert_largeitem_quantity(EstimateItemID, QuantityID, MaterialID, InvSheets1, InvSheets2, InvSheets3, InvSheets4, PrintSheets1, PrintSheets2, PrintSheets3, PrintSheets4, MaterialLength1, MaterialLength2, MaterialLength3, MaterialLength4, MaterialMarkupPrice1, MaterialCostExMarkup1, MaterialMarkupPrice2, MaterialCostExMarkup2, MaterialMarkupPrice3, MaterialCostExMarkup3, MaterialMarkupPrice4, MaterialCostExMarkup4, MaterialNo, savetype);
        }

        public static DataTable Invoice_DeliveryNote_QuickLinks_Select(int CompanyID, long InvoiceID, long EstimateItemID)
        {
            return (new DbEstimates()).Invoice_DeliveryNote_QuickLinks_Select(CompanyID, InvoiceID, EstimateItemID);
        }

        public static long Item_Copy_AllMainItem_withallAdditionItems(long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).Item_Copy_AllMainItem_withallAdditionItems(EstimateItemID, EstimateType);
        }

        public static long Item_Copy_AllMainItem_withallAdditionItems_reeng(long EstimateItemID, string EstimateType, string Module)
        {
            return (new DbEstimates()).Item_Copy_AllMainItem_withallAdditionItems_reeng(EstimateItemID, EstimateType, Module);
        }

        public static DataTable item_cost_view_sub_item_outwork(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).item_cost_view_sub_item_outwork(CompanyID, EstimateItemID);
        }

        public static void item_description_update(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription)
        {
            (new DbEstimates()).item_description_update(CompanyID, EstimateItemID, EstimateType, ItemDescription);
        }

        public static void item_description_update_new(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription, long EstimateID, string Itemtitle)
        {
            (new DbEstimates()).item_description_update_new(CompanyID, EstimateItemID, EstimateType, ItemDescription, EstimateID, Itemtitle);
        }

        public static DataTable item_select_itemDescription_foralltypes(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).item_select_itemDescription_foralltypes(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataSet itemdescription_selectall_fromSettings_foralltypes(int CompanyID, string EstimateType)
        {
            return (new DbEstimates()).itemdescription_selectall_fromSettings_foralltypes(CompanyID, EstimateType);
        }

        public static void itemTitleUpdate_for_eStoreOtherCost(int CompanyID, long EstimateID, long EstimateItemID, string ItemTitle)
        {
            (new DbEstimates()).itemTitleUpdate_for_eStoreOtherCost(CompanyID, EstimateID, EstimateItemID, ItemTitle);
        }

        public static DataTable Job_item_select(int CompanyID, long JobID)
        {
            return (new DbEstimates()).Job_item_select(CompanyID, JobID);
        }

        public static int Job_Items_Count_Select(int CompanyID, long JobID)
        {
            return (new DbEstimates()).Job_Items_Count_Select(CompanyID, JobID);
        }

        public static DataTable job_othercost_subitem_select(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID, int Quantity)
        {
            return (new DbEstimates()).job_othercost_subitem_select(CompanyID, EstimateType, TypeID, EstOtherCostID, Quantity);
        }

        public static DataTable jobcard_select_directjob(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).jobcard_select_directjob(CompanyID, EstimateItemID);
        }

        public static long large_item_insert(EstimatesItem item)
        {
            return (new DbEstimates()).large_item_insert(item);
        }

        public static DataTable large_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).large_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable large_item_select_forMaterials(long CompanyID, long EstimateItemID, long MaterialID, int MetarialNO)
        {
            return (new DbEstimates()).large_item_select_forMaterials(CompanyID, EstimateItemID, MaterialID, MetarialNO);
        }

        public static DataTable LargeItem_Ink_Details_Select(int CompanyID, long EstimateItemID, string color, string sidecolor, bool IsDoubleSided)
        {
            return (new DbEstimates()).LargeItem_Ink_Details_Select(CompanyID, EstimateItemID, color, sidecolor, IsDoubleSided);
        }

        public static DataTable LargeItem_ink_UnitPrice_MinimumCost_Select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).LargeItem_ink_UnitPrice_MinimumCost_Select(CompanyID, EstimateItemID);
        }

        public static void LargeItemCalculation_insert(long EstimateCalculationID, long EstimateItemID, long MaterialID, decimal MaterialUnitPrice, decimal MaterialWeight, decimal MaterialPackedInQty, decimal MaterialMarkup1, decimal MaterialMarkup2, decimal MaterialMarkup3, decimal MaterialMarkup4, int MaterialNo, string savetype)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.LargeItemCalculation_insert(EstimateCalculationID, EstimateItemID, MaterialID, MaterialUnitPrice, MaterialWeight, MaterialPackedInQty, MaterialMarkup1, MaterialMarkup2, MaterialMarkup3, MaterialMarkup4, MaterialNo, savetype);
        }

        public static DataTable litho_estimate_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).litho_estimate_select(CompanyID, EstimateItemID);
        }

        public static DataTable litho_pad_estimate_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).litho_pad_estimate_select(CompanyID, EstimateItemID);
        }

        public static long litho_press_insert(int CompanyID, long EstLithoItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue, bool sheetwork)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.litho_press_insert(CompanyID, EstLithoItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetupSpoilage, RunningSpoilage, sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID, ItemTitle, CreatedBy, ModifiedBy, ModifiedDate, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, Perfecting, ManualValue, sheetwork);
        }

        public static void litho_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            (new DbEstimates()).litho_speed_weight_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static long Lithobooklet_item_insert(EstimatesItem item)
        {
            return (new DbEstimates()).Lithobooklet_item_insert(item);
        }

        public static DataTable lithobooklet_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).lithobooklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable lithobooklet_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).lithobooklet_item_select_othercostasadditional(CompanyID, EstimateItemID);
        }

        public static DataTable lithobooklet_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return (new DbEstimates()).lithobooklet_item_select_popup_paperpressinkguillotine(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static void LithoBookletquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithobookletItemID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.LithoBookletquantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateLithobookletItemID);
        }

        public static DataTable lithoncr_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).lithoncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable digitalncr_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).digitalncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable lithoncr_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).lithoncr_item_select_othercostasadditional(CompanyID, EstimateItemID);
        }

        public static DataTable lithoncr_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return (new DbEstimates()).lithoncr_item_select_popup_paperpressinkguillotine(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static void LockItemStatus(long EstimateItemID, string Module)
        {
            (new DbEstimates()).LockItemStatus(EstimateItemID, Module);
        }

        public static DataTable Materials_select_ForPOCreate(long EstimateItemID)
        {
            return (new DbEstimates()).Materials_select_ForPOCreate(EstimateItemID);
        }

        public static long Module_IsConverted_To_NextModule(long ModuleId, string ModuleType)
        {
            return (new DbEstimates()).Module_IsConverted_To_NextModule(ModuleId, ModuleType);
        }

        public static DataTable NCR_item_quantity_select(int CompanyID, int EstimateItemID, string EstType, int EstimateBookletItemID)
        {
            return (new DbEstimates()).NCR_item_quantity_select(CompanyID, EstimateItemID, EstType, EstimateBookletItemID);
        }

        public static void NCRquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithoNCRItemID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.NCRquantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateLithoNCRItemID);
        }

        public static DataTable OrderItemID_Select(long OrderID, long EstimateItemID)
        {
            return (new DbEstimates()).OrderItemID_Select(OrderID, EstimateItemID);
        }

        public static DataTable Orders_Othercostitem_select(int CompanyID, long EstimateID, string Pgtype)
        {
            return (new DbEstimates()).Orders_Othercostitem_select(CompanyID, EstimateID, Pgtype);
        }

        public static void othercost_formula_tag_update(int CompanyID, long EstOthercostID, long EstimateItemID, string FormulaTag, int QtyNumber)
        {
            (new DbEstimates()).othercost_formula_tag_update(CompanyID, EstOthercostID, EstimateItemID, FormulaTag, QtyNumber);
        }

        public static long OtherCostSequence_GetCountBy_EstimatType(int CompanyID, string Estimatetype)
        {
            return (new DbEstimates()).OtherCostSequence_GetCountBy_EstimatType(CompanyID, Estimatetype);
        }

        public static DataSet OtherCostSequenceDetails(long CompanyID, string EstimateType)
        {
            return (new DbEstimates()).OtherCostSequenceDetails(CompanyID, EstimateType);
        }

        public static long pad_item_insert(EstimatesItem item)
        {
            return (new DbEstimates()).pad_item_insert(item);
        }

        public static DataTable pad_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable pad_item_summary(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).pad_item_summary(CompanyID, EstimateItemID);
        }

        public static DataTable PaperSupplied_select_ForPOCreate(long EstimateItemID, string EstimateItemType)
        {
            return (new DbEstimates()).PaperSupplied_select_ForPOCreate(EstimateItemID, EstimateItemType);
        }

        public static DataSet PC_EstimateLargeItem_InkCalID_Select(long EstimateItemID)
        {
            return (new DbEstimates()).PC_EstimateLargeItem_InkCalID_Select(EstimateItemID);
        }

        public static void PC_EstimateLargeItem_InkMarkUp_Insert(long EstimateItemID, decimal InkMarkup)
        {
            (new DbEstimates()).PC_EstimateLargeItem_InkMarkUp_Insert(EstimateItemID, InkMarkup);
        }

        public static void PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(int CompanyID, long ParentItemID, string ParentItemType, string SubItemType)
        {
            (new DbEstimates()).PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(CompanyID, ParentItemID, ParentItemType, SubItemType);
        }

        public static DataTable PCR_Estimate_InkMarkup_Select(int CompanyID, long EstimateItemID, long InventoryID, long TypeID, string EstimateType, int QuantityNumber)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.PCR_Estimate_InkMarkup_Select(CompanyID, EstimateItemID, InventoryID, TypeID, EstimateType, QuantityNumber);
        }

        public static void PCR_Estimate_InkMarkup_Update(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual, int QuantityNumber, long EstimateInkCalcID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.PCR_Estimate_InkMarkup_Update(InkCostExMarkup, InkMarkup, InkMarkupPrice, InkSetupCharge, InkMinimumCharge, InkCostExMarkup_Actual, QuantityNumber, EstimateInkCalcID);
        }

        public static void PCR_Estimate_Large_Ink_Insert(long EstimateItemID, string ActionType, int CompanyID, string Color, string sidecolor, bool IsDoubleSided, long PressID)
        {
            (new DbEstimates()).PCR_Estimate_Large_Ink_Insert(EstimateItemID, ActionType, CompanyID, Color, sidecolor, IsDoubleSided,PressID);
        }

        public static void PCR_estimates_markup_calculation_update_forInk(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkCostExMarkup_Actual, int QtyNo, long EstimateInkCalcID, string Module)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.PCR_estimates_markup_calculation_update_forInk(InkCostExMarkup, InkMarkup, InkMarkupPrice, InkCostExMarkup_Actual, QtyNo, EstimateInkCalcID, Module);
        }

        public static void PCR_estimates_Update_SetupCharge_Or_MakeReady(long EstimateInkCalcID, decimal SetUpCharge_OrMake_ReadyValue, string SetUpCharge_OrMake_Ready)
        {
            (new DbEstimates()).PCR_estimates_Update_SetupCharge_Or_MakeReady(EstimateInkCalcID, SetUpCharge_OrMake_ReadyValue, SetUpCharge_OrMake_Ready);
        }

        public static DataTable PCR_Guillotine_Cost_ViewOnPopUp(long GuillotineID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return (new DbEstimates()).PCR_Guillotine_Cost_ViewOnPopUp(GuillotineID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataSet PCR_Ink_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module, string Section)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.PCR_Ink_Cost_ViewOnPopUp(PressID, EstimateItemID, EstimateType, TypeID, Module, Section);
        }

        public static DataTable PCR_MakeReady_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return (new DbEstimates()).PCR_MakeReady_Cost_ViewOnPopUp(EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataTable PCR_OtherCostSequence_GetIDSToValidate(int CompanyID, string ParentEstimateType)
        {
            return (new DbEstimates()).PCR_OtherCostSequence_GetIDSToValidate(CompanyID, ParentEstimateType);
        }

        public static DataTable PCR_Paper_Cost_ViewOnPopUp(int PaperID, long EstimateItemID, string EstimateType, long TypeID, string Module, int MaterialNo)
        {
            DbEstimates dbEstimate = new DbEstimates();
            return dbEstimate.PCR_Paper_Cost_ViewOnPopUp(PaperID, EstimateItemID, EstimateType, TypeID, Module, MaterialNo);
        }

        public static DataTable PCR_Plate_Cost_ViewOnPopUp(long PlateID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return (new DbEstimates()).PCR_Plate_Cost_ViewOnPopUp(PlateID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataSet PCR_Press_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return (new DbEstimates()).PCR_Press_Cost_ViewOnPopUp(PressID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataTable PCR_WashUp_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return (new DbEstimates()).PCR_WashUp_Cost_ViewOnPopUp(EstimateItemID, EstimateType, TypeID, Module);
        }

        public static void price_catalogue_insert(int CompanyID, string Data)
        {
            (new DbEstimates()).price_catalogue_insert(CompanyID, Data);
        }

        public static DataTable price_catalogue_select_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).price_catalogue_select_by_estimateitem_id_new(CompanyID, EstimateItemID);
        }

        public static DataTable Pricecatalog_selecttiemdescription_byestimateitemid(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).Pricecatalog_selecttiemdescription_byestimateitemid(CompanyID, EstimateItemID);
        }

        public static void PrintReadyfile_Insert(long EstimateID, long EstimateItemID, long UserID, string ModuleType, string AttachmentType)
        {
            (new DbEstimates()).PrintReadyfile_Insert(EstimateID, EstimateItemID, UserID, ModuleType, AttachmentType);
        }

        public static DataTable PrintReadyFile_Select(long PriceCatalogueID, int CompanyId)
        {
            return (new DbEstimates()).PrintReadyFile_Select(PriceCatalogueID, CompanyId);
        }

        public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
        {
            return (new DbEstimates()).Product_CatalogueQty_Select(PriceCatalogueID);
        }

        public static DataTable ProductOROrder_Item_Qty_Select(long EstimateItemID)
        {
            return (new DbEstimates()).ProductOROrder_Item_Qty_Select(EstimateItemID);
        }

        public static DataTable productsDetails_Select(long PriceCatalogueID)
        {
            return (new DbEstimates()).productsDetails_Select(PriceCatalogueID);
        }

        public static DataTable Profit_Margin_By_Client_System(int CompanyID, long EstimateID)
        {
            return (new DbEstimates()).Profit_Margin_By_Client_System(CompanyID, EstimateID);
        }

        public static DataTable Profit_Margin_By_Client_System_InvoiceID(int CompanyID, long InvoiceID)
        {
            return (new DbEstimates()).Profit_Margin_By_Client_System_InvoiceID(CompanyID, InvoiceID);
        }

        public static DataTable TaxPrecedence_Select(long EstimateID)
        {
            return (new DbEstimates()).TaxPrecedence_Select(EstimateID);
        }

        public static DataTable Profit_Margin_By_ProductCatalogue(int CompanyID, long productid)
        {
            return (new DbEstimates()).Profit_Margin_By_ProductCatalogue(CompanyID, productid);
        }

        public static void qty_delete(int CompanyID, long EstimateItemID, long EstimateBookletItemID, string EstimateType, int QtyNumber)
        {
            (new DbEstimates()).qty_delete(CompanyID, EstimateItemID, EstimateBookletItemID, EstimateType, QtyNumber);
        }

        public static void quantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateBookletItemID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.quantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateBookletItemID);
        }

        public static void quantity_insert_large_item(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PaperLength1, decimal PaperLength2, decimal PaperLength3, decimal PaperLength4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.quantity_insert_large_item(CompanyID, EstimateItemID, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PaperLength1, PaperLength2, PaperLength3, PaperLength4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4);
        }

        public static void quantity_insert_new(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_Cost1, decimal Zone_Side1_Cost2, decimal Zone_Side1_Cost3, decimal Zone_Side1_Cost4, decimal Zone_Side2_Cost1, decimal Zone_Side2_Cost2, decimal Zone_Side2_Cost3, decimal Zone_Side2_Cost4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.quantity_insert_new(CompanyID, EstimateItemID, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, Zone_Side1_ChargeableRate1, Zone_Side1_ChargeableRate2, Zone_Side1_ChargeableRate3, Zone_Side1_ChargeableRate4, Zone_Side2_ChargeableRate1, Zone_Side2_ChargeableRate2, Zone_Side2_ChargeableRate3, Zone_Side2_ChargeableRate4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4, Zone_Side1_Cost1, Zone_Side1_Cost2, Zone_Side1_Cost3, Zone_Side1_Cost4, Zone_Side2_Cost1, Zone_Side2_Cost2, Zone_Side2_Cost3, Zone_Side2_Cost4);
        }

        public static void quantity_insert_offset_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.quantity_insert_offset_item(CompanyID, EstimateItemID, EstimateType, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, PlatesCostExMarkup1, PlatesMarkupPrice1, MakeReadyCostExMarkup1, MakeReadyMarkupPrice1, WashUpCostExMarkup1, WashUpMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, PlatesCostExMarkup2, PlatesMarkupPrice2, MakeReadyCostExMarkup2, MakeReadyMarkupPrice2, WashUpCostExMarkup2, WashUpMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, PlatesCostExMarkup3, PlatesMarkupPrice3, MakeReadyCostExMarkup3, MakeReadyMarkupPrice3, WashUpCostExMarkup3, WashUpMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, PlatesCostExMarkup4, PlatesMarkupPrice4, MakeReadyCostExMarkup4, MakeReadyMarkupPrice4, WashUpCostExMarkup4, WashUpMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4);
        }

        public static void quantity_insert_digital_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.quantity_insert_digital_item(CompanyID, EstimateItemID, EstimateType, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, PlatesCostExMarkup1, PlatesMarkupPrice1, MakeReadyCostExMarkup1, MakeReadyMarkupPrice1, WashUpCostExMarkup1, WashUpMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, PlatesCostExMarkup2, PlatesMarkupPrice2, MakeReadyCostExMarkup2, MakeReadyMarkupPrice2, WashUpCostExMarkup2, WashUpMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, PlatesCostExMarkup3, PlatesMarkupPrice3, MakeReadyCostExMarkup3, MakeReadyMarkupPrice3, WashUpCostExMarkup3, WashUpMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, PlatesCostExMarkup4, PlatesMarkupPrice4, MakeReadyCostExMarkup4, MakeReadyMarkupPrice4, WashUpCostExMarkup4, WashUpMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4, Zone_Side1_ChargeableRate1, Zone_Side1_ChargeableRate2, Zone_Side1_ChargeableRate3, Zone_Side1_ChargeableRate4, Zone_Side2_ChargeableRate1, Zone_Side2_ChargeableRate2, Zone_Side2_ChargeableRate3, Zone_Side2_ChargeableRate4);
        }

        public static DataTable quantity_Select_forOtherCost(long EstimateItemID, string QueryType, long EstimateBookletItemID)
        {
            return (new DbEstimates()).quantity_Select_forOtherCost(EstimateItemID, QueryType, EstimateBookletItemID);
        }

        public static DataTable deliverycost_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).deliverycost_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable DeliveryCost_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return (new DbEstimates()).DeliveryCost_Description_Select(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable QuickQuote_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return (new DbEstimates()).QuickQuote_Description_Select(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable estimate_DeliveryCost_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).estimate_DeliveryCost_item_select(CompanyID, EstimateItemID);
        }

        public static void Estimate_DeliveryCost_insert(EstimatesItem item, bool IsHandy)
        {
            (new DbEstimates()).Estimate_DeliveryCost_insert(item, IsHandy);
        }

        public static DataTable quickquote_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).quickquote_item_select(CompanyID, EstimateItemID);
        }

        public static void Update_InvStock_calculation(long EstimateItemID, decimal InvStock)
        {
            (new DbEstimates()).Update_InvStock_calculation(EstimateItemID, InvStock);
        }

        public static void SaveQtyDescription(long EstimateItemID, string Qtydesc1, string Qtydesc2, string Qtydesc3, string Qtydesc4, int CompanyID)
        {
            (new DbEstimates()).SaveQtyDescription(EstimateItemID, Qtydesc1, Qtydesc2, Qtydesc3, Qtydesc4, CompanyID);
        }

        public static DataTable Select_AccountingCode_For_Summary(int CompanyID, long EstimateItemID, string EstimateType, long EstimateID)
        {
            return (new DbEstimates()).Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, EstimateType, EstimateID);
        }

        public static DataTable select_AdditionalItem_IDs(int CompanyID, long EstimateItemID, string EstimateItemType)
        {
            return (new DbEstimates()).select_AdditionalItem_IDs(CompanyID, EstimateItemID, EstimateItemType);
        }

        public static DataTable select_Converted_Prodect(int CompanyID, long EstimateItemID, string Esttype)
        {
            return (new DbEstimates()).select_Converted_Prodect(CompanyID, EstimateItemID, Esttype);
        }

        public static DataTable select_details_for_Activity_History(int CompanyID, long EstimateID, string PgType, long POID)
        {
            return (new DbEstimates()).select_details_for_Activity_History(CompanyID, EstimateID, PgType, POID);
        }

        public static DataTable select_details_for_JobActivity_History(int CompanyID, long JobID)
        {
            return (new DbEstimates()).select_details_for_JobActivity_History(CompanyID, JobID);
        }

        public static DataTable select_EstimateItemID(long EstimateID)
        {
            return (new DbEstimates()).select_EstimateItemID(EstimateID);
        }

        public static DataTable select_InventoryInkMatrix_SetUpCost(int CompanyID, long InventoryID)
        {
            return (new DbEstimates()).select_InventoryInkMatrix_SetUpCost(CompanyID, InventoryID);
        }

        public static DataTable select_InventoryInkMatrixDetails_inkCal(int CompanyID, long InventoryID, string InventorySheetsFromTo)
        {
            return (new DbEstimates()).select_InventoryInkMatrixDetails_inkCal(CompanyID, InventoryID, InventorySheetsFromTo);
        }

        public static DataTable Select_Item_Number_Title_basedonModule(int ComanyID, long EstimateItemID, string Module)
        {
            return (new DbEstimates()).Select_Item_Number_Title_basedonModule(ComanyID, EstimateItemID, Module);
        }

        public static DataTable Select_OrderIDAdditionalitemID_Select(long PriceCatalogueID)
        {
            return (new DbEstimates()).Select_OrderIDAdditionalitemID_Select(PriceCatalogueID);
        }

        public static DataSet Select_OrderItems_WithAdditionalItems(long OrderItemID)
        {
            return (new DbEstimates()).Select_OrderItems_WithAdditionalItems(OrderItemID);
        }

        public static DataSet select_othercost_parentdetails(long EstimateID, long EstimateItemID)
        {
            return (new DbEstimates()).select_othercost_parentdetails(EstimateID, EstimateItemID);
        }

        public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
        {
            return (new DbEstimates()).Select_OtherCostAdditional_ItemsDetail(WebOtherCostID);
        }

        public static DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
        {
            return (new DbEstimates()).Select_OtherCostAdditional_ItemsIDs(PriceCatalogueID);
        }

        public static DataTable Select_OtherCostItemQty(long EstimateID, long EstimateItemID)
        {
            return (new DbEstimates()).Select_OtherCostItemQty(EstimateID, EstimateItemID);
        }

        public static DataTable Select_ProductCatalogueQty(long EstimateItemID, string EstimateType)
        {
            return (new DbEstimates()).Select_ProductCatalogueQty(EstimateItemID, EstimateType);
        }

        public static DataTable Select_Prompt_Archive(int CompanyID, string Event)
        {
            return (new DbEstimates()).Select_Prompt_Archive(CompanyID, Event);
        }

        public static DataTable selectEstimatetype_estimateitemid(long EstimateItemID, long EstimateID)
        {
            return (new DbEstimates()).selectEstimatetype_estimateitemid(EstimateItemID, EstimateID);
        }

        public static DataTable SelectItemDescFrmEsOutwork(long EstimateItemID)
        {
            return (new DbEstimates()).SelectItemDescFrmEsOutwork(EstimateItemID);
        }

        public static DataTable selectoutworkQtyType(int EstimateItemID)
        {
            return (new DbEstimates()).selectoutworkQtyType(EstimateItemID);
        }

        public static DataTable SelectPlateunitprice_eachSectin(int InventoryID)
        {
            return (new DbEstimates()).SelectPlateunitprice_eachSectin(InventoryID);
        }

        public static void SendingNewArtWorkFilenames(int CompanyID, long EstimateItemID, string SaveNewfilenames, string SaveOriginalFileNames, long NewEstimateItemID)
        {
            (new DbEstimates()).SendingNewArtWorkFilenames(CompanyID, EstimateItemID, SaveNewfilenames, SaveOriginalFileNames, NewEstimateItemID);
        }

        public static DataTable SentForQuoteStatus_SupQuoteDet(long SupplierID, long Estoutworkid, int QuantityNumber)
        {
            return (new DbEstimates()).SentForQuoteStatus_SupQuoteDet(SupplierID, Estoutworkid, QuantityNumber);
        }

        public static string settings_jobViewColor_SelectedDateType(int CompanyId)
        {
            return (new DbEstimates()).settings_jobViewColor_SelectedDateType(CompanyId);
        }

        public static DataTable settings_lithopress_InkSelect(int CompanyID, long LithoPressID)
        {
            return (new DbEstimates()).settings_lithopress_InkSelect(CompanyID, LithoPressID);
        }

        public static DataSet settings_Product_CatalogueAdditional_Select(int CompanyID, long PriceCatalogueID)
        {
            return (new DbEstimates()).settings_Product_CatalogueAdditional_Select(CompanyID, PriceCatalogueID);
        }

        public static long SingelItem_Inset_By_Copy(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID, string IsParentItem)
        {
            return (new DbEstimates()).SingelItem_Inset_By_Copy(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID, IsParentItem);
        }

        public static long single_item_insert(EstimatesItem item)
        {
            return (new DbEstimates()).single_item_insert(item);
        }

        public static DataTable single_item_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).single_item_select(CompanyID, EstimateItemID);
        }

        public static void sub_item_outwork_markup_update(int CompanyID, long EstOutworkSupplierID, decimal Markup, decimal TotalPrice)
        {
            (new DbEstimates()).sub_item_outwork_markup_update(CompanyID, EstOutworkSupplierID, Markup, TotalPrice);
        }

        public static DataSet sub_item_summary(int CompanyID, long EstimateItemID, string Estimatetype)
        {
            return (new DbEstimates()).sub_item_summary(CompanyID, EstimateItemID, Estimatetype);
        }

        public static DataTable sub_warehouse_in_summary(long CompanyID, long ParentItemID, string ParentItemType)
        {
            return (new DbEstimates()).sub_warehouse_in_summary(CompanyID, ParentItemID, ParentItemType);
        }

        public static void subtotal_update(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.subtotal_update(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice);
        }

        public static void subtotal_update_new(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, decimal ProfitMarginPrice, int QtyNumber, decimal TaxValue, decimal SellingPrice)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.subtotal_update_new(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice, ProfitMarginPrice, QtyNumber, TaxValue, SellingPrice);
        }

        public static void subtotal_update_OnSave(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, int QtyNumber)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.subtotal_update_OnSave(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice, QtyNumber);
        }

        public static DataTable summary_outwork_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimates()).summary_outwork_select(CompanyID, EstimateItemID);
        }

        public static void summary_sub_ware_markup_update(int CompanyID, long EstWarehouseItemID, decimal Markup)
        {
            (new DbEstimates()).summary_sub_ware_markup_update(CompanyID, EstWarehouseItemID, Markup);
        }

        public static DataSet SupplierID_PerQty(long EstimateItemID, string Type)
        {
            return (new DbEstimates()).SupplierID_PerQty(EstimateItemID, Type);
        }

        public static DataTable Tax_Bind(int companyID)
        {
            return (new DbEstimates()).Tax_Bind(companyID);
        }

        public static void taxprofit_update(int CompanyID, long EstimateItemID, string EstimateType, int TaxID, decimal Tax, decimal ProfitMargin, long EstimateBookletItemID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.taxprofit_update(CompanyID, EstimateItemID, EstimateType, TaxID, Tax, ProfitMargin, EstimateBookletItemID);
        }

        public static void UnLockItemStatus(long EstimateItemID, string Module)
        {
            (new DbEstimates()).UnLockItemStatus(EstimateItemID, Module);
        }

        public static void Update_customer_details_forNew_copy_estimate(int CompanyID, long EstimateID, long CustomerID, long AttentionID, string Greeting, string Company, long Address, long DeliveryAddress, int UserID, long InvAddressID)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.Update_customer_details_forNew_copy_estimate(CompanyID, EstimateID, CustomerID, AttentionID, Greeting, Company, Address, DeliveryAddress, UserID, InvAddressID);
        }

        public static void update_Materialcost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.update_Materialcost_onLockUnitPrice(qtyID, estCalculationID, PaperUnitPrice, islock, PaperCostExMarkup1, PaperCostExMarkup2, PaperCostExMarkup3, PaperCostExMarkup4, PaperMarkupPrice1, PaperMarkupPrice2, PaperMarkupPrice3, PaperMarkupPrice4);
        }

        public static void update_OtherCostItemQty(long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4)
        {
            (new DbEstimates()).update_OtherCostItemQty(EstimateItemID, EstimateType, Qty1, Qty2, Qty3, Qty4);
        }

        public static void update_papercost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4, string Module, int QtyNumber)
        {
            DbEstimates dbEstimate = new DbEstimates();
            dbEstimate.update_papercost_onLockUnitPrice(qtyID, estCalculationID, PaperUnitPrice, islock, PaperCostExMarkup1, PaperCostExMarkup2, PaperCostExMarkup3, PaperCostExMarkup4, PaperMarkupPrice1, PaperMarkupPrice2, PaperMarkupPrice3, PaperMarkupPrice4, Module, QtyNumber);
        }

        public static void updateitemdescription_forink_litho(long EstimateItemID, string EstimateType, string ItemDescription, long Estimatelithoncritemid, long Estimatelithobookletitemid)
        {
            (new DbEstimates()).updateitemdescription_forink_litho(EstimateItemID, EstimateType, ItemDescription, Estimatelithoncritemid, Estimatelithobookletitemid);
        }

        public static void updateProfitmargin_OnCustomerChange(long CompanyID, long EstimateID)
        {
            (new DbEstimates()).updateProfitmargin_OnCustomerChange(CompanyID, EstimateID);
        }

        public static void updateSubTotalLock(long EstimateItemID)
        {
            (new DbEstimates()).updateSubTotalLock(EstimateItemID);
        }

        public static void updatetotalTax_and_sellingPrice_forOtherCost(long EstTotalID, decimal TaxValue, decimal SellingPrice, long taxID, decimal taxpercent)
        {
            (new DbEstimates()).updatetotalTax_and_sellingPrice_forOtherCost(EstTotalID, TaxValue, SellingPrice, taxID, taxpercent);
        }

        public static bool Views_IsItemDetailsSelected(long ViewID)
        {
            return (new DbEstimates()).Views_IsItemDetailsSelected(ViewID);
        }

        public static string Views_RecordsToDisplay(long ViewID)
        {
            return (new DbEstimates()).Views_RecordsToDisplay(ViewID);
        }

        public static DataTable warehouse_inventoryinkMatrix_select(int CompanyID, long InventoryID)
        {
            return (new DbEstimates()).warehouse_inventoryinkMatrix_select(CompanyID, InventoryID);
        }

        public static string Warehouse_Markup(int CompanyID, int InventoryNo)
        {
            return (new DbEstimates()).Warehouse_Markup(CompanyID, InventoryNo);
        }

        public static string warehouse_perquantity_select(int CompanyID, string WarehouseType, long WarehouseTypeID)
        {
            return (new DbEstimates()).warehouse_perquantity_select(CompanyID, WarehouseType, WarehouseTypeID);
        }

        public static DataTable estimateCalculationSelect(long ID)
        {
            return (new DbEstimates()).estimateCalculationSelect(ID);
        }

        public static Boolean PC_select_JobLocking_Status(long ID)
        {
            return (new DbEstimates()).PC_select_JobLocking_Status(ID);
        }

        public static void PC_update_JobLocking_Status(long ID, Boolean Status)
        {
            (new DbEstimates()).PC_update_JobLocking_Status(ID, Status);
        }

        internal static void updatePrintSheets(decimal printSheet1, decimal printSheet2, decimal printSheet3, decimal printSheet4, long QuantityID, decimal printSheetPrize1, decimal printSheetPrize2, decimal printSheetPrize3, decimal printSheetPrize4)
        {
            (new DbEstimates()).updatePrintSheets(printSheet1, printSheet2, printSheet3, printSheet4, QuantityID, printSheetPrize1, printSheetPrize2, printSheetPrize3, printSheetPrize4);

        }

        public static DataTable GetEstimateQty(long EstimateItemID)
        {
            return (new DbEstimates()).GetEstimateQty(EstimateItemID);
        }
    }
}