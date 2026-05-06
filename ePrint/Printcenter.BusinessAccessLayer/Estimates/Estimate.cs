using Printcenter.DataAccessLayer.Estimates;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Estimates
{
    public class Estimate : BaseBusiness
    {
        public Estimate()
        {
        }

        public static DataTable AccountInfo_FrontEnd(string AccountName)
        {
            return (new DbEstimate()).AccountInfo_FrontEnd(AccountName);
        }

        public static DataTable Attachment_DN_Select(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long DeliveryID, long EstimateID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Attachment_DN_Select(CompanyID, UserID, AttachmentType, AttachmentTypeID, DeliveryID, EstimateID);
        }

        public static DataTable Attachment_Duplicate_CheckChange(long EstimateID, string FileName)
        {
            return (new DbEstimate()).Attachment_Duplicate_CheckChange(EstimateID, FileName);
        }

        public static DataTable Attachment_Duplicate_CheckChange_ForItemSpecific(long EstimateID, long AttachmentTypeID, string AttachmentType, string FileName, string ModuleType)
        {
            return (new DbEstimate()).Attachment_Duplicate_CheckChange_ForItemSpecific(EstimateID, AttachmentTypeID, AttachmentType, FileName, ModuleType);
        }

        public static DataTable Attachment_eStore_General_Select(long CompanyID)
        {
            return (new DbEstimate()).Attachment_eStore_General_Select(CompanyID);
        }

        public static DataTable Attachment_PO_Select(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, long PurchaseID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Attachment_PO_Select(CompanyID, UserID, AttachmentType, AttachmentTypeID, EstimateID, PurchaseID);
        }

        public static DataTable Attachments_eStore_General(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, string pg)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Attachments_eStore_General(CompanyID, UserID, AttachmentType, AttachmentTypeID, EstimateID, pg);
        }

        public static DataTable Attachments_eStore_ItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID)
        {
            return (new DbEstimate()).Attachments_eStore_ItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID);
        }

        public static void Attachments_General_Delete(long AttachmentID)
        {
            (new DbEstimate()).Attachments_General_Delete(AttachmentID);
        }

        public static DataTable Attachments_ItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {
            return (new DbEstimate()).Attachments_ItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID, ModuleType);
        }
        public static DataTable Attachments_ProofItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType,int ProofID,int JobID)
        {
            return (new DbEstimate()).Attachments_ProofItemSpecific_Select(CompanyID, UserID, AttachmentType, EstimateID, ModuleType,ProofID,JobID);
        }
        public static void Attachments_PO_DN_Copy(long EstimateID, long EstimateItemID, long TypeID, string Attachmenttype)
        {
            (new DbEstimate()).Attachments_PO_DN_Copy(EstimateID, EstimateItemID, TypeID, Attachmenttype);
        }

        public static DataTable Attachments_Select_For_General(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {
            return (new DbEstimate()).Attachments_Select_For_General(CompanyID, UserID, AttachmentType, EstimateID, ModuleType);
        }

        public static DataTable booklet_sectionID_select(int CompanyID, long EstBookletItemID)
        {
            return (new DbEstimate()).booklet_sectionID_select(CompanyID, EstBookletItemID);
        }

        public static DataTable client_tax_select(int CompanyID, int CustomerID)
        {
            return (new DbEstimate()).client_tax_select(CompanyID, CustomerID);
        }

        public static DataTable Common_AddressSelect_PerClient(long ClientID)
        {
            return (new DbEstimate()).Common_AddressSelect_PerClient(ClientID);
        }

        public static long copy_booklet_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_booklet_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_estimate_bookletitem(int CompanyID, long New_EstimateItemID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_estimate_bookletitem(CompanyID, New_EstimateItemID, Old_EstimateItemID);
        }

        public static long copy_estimate_bookletsection(int CompanyID, long New_EstBookletItemID, long Old_EstBookletSectionID, long New_EstimateItemID)
        {
            return (new DbEstimate()).copy_estimate_bookletsection(CompanyID, New_EstBookletItemID, Old_EstBookletSectionID, New_EstimateItemID);
        }

        public static long copy_estimateitem(int CompanyID, long New_EstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_estimateitem(CompanyID, New_EstimateID, Old_EstimateItemID);
        }

        public static long copy_large_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_large_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_other_cost(int CompanyID, long Old_EstimateItemID, long New_EstimateItemID, long Old_EstOtherCostID)
        {
            return (new DbEstimate()).copy_other_cost(CompanyID, Old_EstimateItemID, New_EstimateItemID, Old_EstOtherCostID);
        }

        public static long copy_othercost_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_othercost_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static void copy_othercost_variable(int CompanyID, string Data)
        {
            (new DbEstimate()).copy_othercost_variable(CompanyID, Data);
        }

        public static long copy_outwork_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_outwork_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_pad_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_pad_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_price_catalogue(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_price_catalogue(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_warehouse_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).copy_warehouse_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static int default_tax_id(int CompanyID)
        {
            return (new DbEstimate()).default_tax_id(CompanyID);
        }

        public static int DefaultPageSize_Select(long CompanyID)
        {
            return (new DbEstimate()).DefaultPageSize_Select(CompanyID);
        }

        public static DataTable DeliveryNote_Attached_Select(long EstimateID)
        {
            return (new DbEstimate()).DeliveryNote_Attached_Select(EstimateID);
        }

        public static DataTable DeliveryNote_ItemID_Select(long DeliveryID)
        {
            return (new DbEstimate()).DeliveryNote_ItemID_Select(DeliveryID);
        }

        public static void DeliveryNoteCarInfoUpdate(long CompanyID, long CarInfoID, long DeliveryID)
        {
            (new DbEstimate()).DeliveryNoteCarInfoUpdate(CompanyID, CarInfoID, DeliveryID);
        }

        public static void DeliveryNoteStatusUpdate(long CompanyID, long StatusID, long DeliveryID)
        {
            (new DbEstimate()).DeliveryNoteStatusUpdate(CompanyID, StatusID, DeliveryID);
        }

        public static DataSet DeliveryPurchase_Check(int CompnyID, long JObID, long EstimateItemID)
        {
            return (new DbEstimate()).DeliveryPurchase_Check(CompnyID, JObID, EstimateItemID);
        }

        public static string Digital_Press_Select(int CompanyID)
        {
            return (new DbEstimate()).Digital_Press_Select(CompanyID);
        }

        public static DataTable DNAttachment_forPurchase(long EstimateID)
        {
            return (new DbEstimate()).DNAttachment_forPurchase(EstimateID);
        }

        internal static DataTable EmailAttachment_ForSupplierRFQ_Select(long EstimateID, long AttachmentTypeID)
        {
            return (new DbEstimate()).EmailAttachment_ForSupplierRFQ_Select(EstimateID, AttachmentTypeID);
        }

        public static DataTable estiamte_select_type_typeid_by_estimateitemid(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimate()).estiamte_select_type_typeid_by_estimateitemid(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.estimate_advance_search(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
        }

        public static DataTable estimate_advance_search_splititems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.estimate_advance_search_splititems(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
        }

        public static DataTable estimate_advance_search_top5(int CompanyID, string SearchText, int ClientID, string Status, string DateType, bool IsArchived, string type)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.estimate_advance_search_top5(CompanyID, SearchText, ClientID, Status, DateType, IsArchived, type);
        }

        public static void Estimate_Archive(int CompanyID, long EstimateID)
        {
            (new DbEstimate()).Estimate_Archive(CompanyID, EstimateID);
        }

        public static long Estimate_Booklet_Item_Insert(int CompanyID, long EstimateItemID, string Titile, string Design, string Color, string Size, string Paper, string Delivery, string Finishing, string Notes, string IsAnyWarehouseItem, string IsAnyOutwork, string IsAnyOtherCost, int CreatedBy, string ItemDescription)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Estimate_Booklet_Item_Insert(CompanyID, EstimateItemID, Titile, Design, Color, Size, Paper, Delivery, Finishing, Notes, IsAnyWarehouseItem, IsAnyOutwork, IsAnyOtherCost, CreatedBy, ItemDescription);
        }

        public static DataTable Estimate_Booklet_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Booklet_Item_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static string Estimate_Booklet_Qty_Select_On_SectionID(int CompanyID, long EstBookletSectionID)
        {
            return (new DbEstimate()).Estimate_Booklet_Qty_Select_On_SectionID(CompanyID, EstBookletSectionID);
        }

        public static DataTable Estimate_Booklet_Quantity_Details_Select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Booklet_Quantity_Details_Select(CompanyID, EstimateItemID);
        }

        public static long Estimate_Booklet_Section_Insert(int CompanyID, string Query)
        {
            return (new DbEstimate()).Estimate_Booklet_Section_Insert(CompanyID, Query);
        }

        public static DataTable estimate_bookletsection_select(int CompanyID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).estimate_bookletsection_select(CompanyID, Old_EstimateItemID);
        }

        public static long Estimate_Calculation_Insert_First(int CompanyID, string Query)
        {
            return (new DbEstimate()).Estimate_Calculation_Insert_First(CompanyID, Query);
        }

        public static void Estimate_ClickChargeZone_Insert_By_EstCalculationID(int CompanyID, long EstCalculationID, long PressID)
        {
            (new DbEstimate()).Estimate_ClickChargeZone_Insert_By_EstCalculationID(CompanyID, EstCalculationID, PressID);
        }

        public static string estimate_contacts_select_by_clientid(int CompanyID, int ClientID)
        {
            return (new DbEstimate()).estimate_contacts_select_by_clientid(CompanyID, ClientID);
        }

        public static void Estimate_Copy(int CompanyID, long EstimateID, string EstimateNumber, int UserID)
        {
            (new DbEstimate()).Estimate_Copy(CompanyID, EstimateID, EstimateNumber, UserID);
        }

        public static long Estimate_Copy_Estimate_Insert(int CompanyID, long Old_EstimateID, bool IsHandy)
        {
            return (new DbEstimate()).Estimate_Copy_Estimate_Insert(CompanyID, Old_EstimateID, IsHandy);
        }

        public static long estimate_default_digitalpress_select(int CompanyID)
        {
            return (new DbEstimate()).estimate_default_digitalpress_select(CompanyID);
        }

        public static long estimate_default_largeformatpress_select(int CompanyID)
        {
            return (new DbEstimate()).estimate_default_largeformatpress_select(CompanyID);
        }

        public static void Estimate_Delete(int CompanyID, long EstimateID)
        {
            (new DbEstimate()).Estimate_Delete(CompanyID, EstimateID);
        }

        public static void Estimate_Comments_Update(int commentId, string newComment)
        {
            (new DbEstimate()).Estimate_Comments_Update(commentId, newComment);
        }

        public static DataTable Estimate_DeliveryAddressID_Select(int CompanyID, long ModuleID, string Module)
        {
            return (new DbEstimate()).Estimate_DeliveryAddressID_Select(CompanyID, ModuleID, Module);
        }

        public static DataTable estimate_deliverynote_selectall(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).estimate_deliverynote_selectall(CompanyID, EstimateID);
        }

        public static long estimate_deliverynoteid_select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).estimate_deliverynoteid_select(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Digital_Press_Select(int CompanyID, long PressID)
        {
            return (new DbEstimate()).Estimate_Digital_Press_Select(CompanyID, PressID);
        }

        public static DataTable Estimate_Estimate_Singlitem_By_EstimateItemID(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimate()).Estimate_Estimate_Singlitem_By_EstimateItemID(CompanyID, EstimateItemID, EstimateType);
        }

        public static void Estimate_EstQuantity_Insert(int CompanyID, string Data)
        {
            (new DbEstimate()).Estimate_EstQuantity_Insert(CompanyID, Data);
        }

        public static DataSet estimate_for_item_add_all(int CompanyID)
        {
            return (new DbEstimate()).estimate_for_item_add_all(CompanyID);
        }

        public static DataTable Estimate_Guillotine_Select_By_ID(int CompanyID, long GuillotineID)
        {
            return (new DbEstimate()).Estimate_Guillotine_Select_By_ID(CompanyID, GuillotineID);
        }

        public static DataTable estimate_guillotine_standard_table_selectall(int CompanyID)
        {
            return (new DbEstimate()).estimate_guillotine_standard_table_selectall(CompanyID);
        }

        public static void estimate_hasdeliverynote_delete(int CompanyID, long EstimateID)
        {
            (new DbEstimate()).estimate_hasdeliverynote_delete(CompanyID, EstimateID);
        }

        public static string estimate_hasdeliverynote_select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).estimate_hasdeliverynote_select(CompanyID, EstimateID);
        }

        public static void estimate_hasdeliverynote_update(int CompanyID, long EstimateID)
        {
            (new DbEstimate()).estimate_hasdeliverynote_update(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Information_By_ID(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Information_By_ID(CompanyID, EstimateType, TypeID);
        }

        public static long Estimate_Insert(int CompanyID, int UserID, int CustomerID, long AttentionID, string Greeting, string Company, long Address, string Header, string Footer, int SalesPerson, string EstimateTitle, string EstimateNumber, string OrderNumber, int StatusID, DateTime EstimateDate, int ValidFor, long DeliveryAddress, bool IsConvertedToJob, DateTime ModifiedDate, int ModifiedBy, long EstimateID, bool IsForInvoice, string AddressType, string DelAddressType, long CurrentEstNo, DateTime EstimatedArtwork, DateTime EstimatedDelivery, DateTime EstimateCreatedDate, bool IsDirectJob, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProdcnDate, long InvoiceAddressID, long DepartmentID, long CostCentreID, int estimatorid, string Comment, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Estimate_Insert(CompanyID, UserID, CustomerID, AttentionID, Greeting, Company, Address, Header, Footer, SalesPerson, EstimateTitle, EstimateNumber, OrderNumber, StatusID, EstimateDate, ValidFor, DeliveryAddress, IsConvertedToJob, ModifiedDate, ModifiedBy, EstimateID, IsForInvoice, AddressType, DelAddressType, CurrentEstNo, EstimatedArtwork, EstimatedDelivery, EstimateCreatedDate, IsDirectJob, JobCompletionDate, ProofDate, ApprovalDate, ProdcnDate, InvoiceAddressID, DepartmentID, CostCentreID, estimatorid, Comment, InvoiceContactId, priority, customDate1, customDate2, customDate3, customDate4, customDate5);
        }

        public static DataTable Estimate_Item_ID_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Item_ID_Select(CompanyID, EstimateID);
        }

        public static DataSet estimate_item_info_select_by_qtynumber(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            return (new DbEstimate()).estimate_item_info_select_by_qtynumber(CompanyID, EstimateItemID, QtyNumber, ItemType);
        }

        public static long Estimate_Item_Insert(int CompanyID, long EstimateID, string EstimateType)
        {
            return (new DbEstimate()).Estimate_Item_Insert(CompanyID, EstimateID, EstimateType);
        }

        public static DataTable Estimate_Item_OtherCost_Cost_By_ID(int CompanyID, long EstOtherCostID)
        {
            return (new DbEstimate()).Estimate_Item_OtherCost_Cost_By_ID(CompanyID, EstOtherCostID);
        }

        public static string Estimate_Item_Outwork_by_EstimateType(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Item_Outwork_by_EstimateType(CompanyID, EstimateType, TypeID);
        }

        public static DataTable Estimate_Item_QtyNumber_Select(int CompanyID, long ItemID, string ItemType)
        {
            return (new DbEstimate()).Estimate_Item_QtyNumber_Select(CompanyID, ItemID, ItemType);
        }

        public static string estimate_item_quantity_fordelivery_select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, int QtyNumber)
        {
            return (new DbEstimate()).estimate_item_quantity_fordelivery_select(CompanyID, EstimateItemID, ItemID, ItemType, QtyNumber);
        }

        public static string estimate_item_type_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).estimate_item_type_select(CompanyID, EstimateItemID);
        }

        public static string Estimate_Item_Warehouse_Select_by_TypeID(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Item_Warehouse_Select_by_TypeID(CompanyID, EstimateType, TypeID);
        }

        public static int Estimate_Items_Count_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Items_Count_Select(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Items_Quantity_Details_Select(int CompanyID, long ItemID, string ItemType)
        {
            return (new DbEstimate()).Estimate_Items_Quantity_Details_Select(CompanyID, ItemID, ItemType);
        }

        public static DataTable Estimate_Items_Quantity_Select(int CompanyID, int EstimateItemID, string EstType)
        {
            return (new DbEstimate()).Estimate_Items_Quantity_Select(CompanyID, EstimateItemID, EstType);
        }

        public static DataTable Estimate_Items_RFQdescription_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Items_RFQdescription_Select(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Items_Select(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Items_Select(CompanyID, EstimateID);
        }

        public static long Estimate_Items_TypeID_Select(int CompanyID, string Query)
        {
            return (new DbEstimate()).Estimate_Items_TypeID_Select(CompanyID, Query);
        }

        public static DataTable Estimate_Large_Format_Press_Charge_Select(int CompanyID, long PressID)
        {
            return (new DbEstimate()).Estimate_Large_Format_Press_Charge_Select(CompanyID, PressID);
        }

        public static long Estimate_LargeFormatItem_Insert(EstimateItem item)
        {
            return (new DbEstimate()).Estimate_LargeFormatItem_Insert(item);
        }

        public static string estimate_largeitem_paperproperties_select(int CompanyID, long InventoryID, string EstimateType)
        {
            return (new DbEstimate()).estimate_largeitem_paperproperties_select(CompanyID, InventoryID, EstimateType);
        }

        public static DataTable estimate_othercost_by_id(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).estimate_othercost_by_id(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_othercost_description_select(int CompanyID, string EstimateType, long EstimateID)
        {
            return (new DbEstimate()).estimate_othercost_description_select(CompanyID, EstimateType, EstimateID);
        }

        public static long estimate_othercost_insert(int CompanyID, long EstOtherCostID, string EstimateType, long TypeID, long EstimateItemID, long OtherCostID, string CalculationType, decimal HoursOrQty, decimal HourlyRate, decimal UnitRate, decimal SetUpTime, decimal HourlyRunSpeed, decimal Passes, decimal Cost, decimal MinimumCost, decimal Markup, string ItemTitle, string Design, string Delivery, string Finishing, string Notes, decimal ProfitMargin, decimal SubTotal, decimal Tax, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, string ItemDescription, string Formula, string FormulaTag, long EstBookletSectionID, int SectionNo, decimal Cost1, decimal Cost2, decimal Cost3, decimal Markup1, decimal Markup2, decimal Markup3, string FormulaTag1, string FormulaTag2, string FormulaTag3, decimal UnitRate1, decimal UnitRate2, decimal UnitRate3, decimal HoursOrQty1, decimal HoursOrQty2, decimal HoursOrQty3, int TaxID, long oldOtherCostID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.estimate_othercost_insert(CompanyID, EstOtherCostID, EstimateType, TypeID, EstimateItemID, OtherCostID, CalculationType, HoursOrQty, HourlyRate, UnitRate, SetUpTime, HourlyRunSpeed, Passes, Cost, MinimumCost, Markup, ItemTitle, Design, Delivery, Finishing, Notes, ProfitMargin, SubTotal, Tax, CreatedBy, ModifiedBy, ModifiedDate, ItemDescription, Formula, FormulaTag, EstBookletSectionID, SectionNo, Cost1, Cost2, Cost3, Markup1, Markup2, Markup3, FormulaTag1, FormulaTag2, FormulaTag3, UnitRate1, UnitRate2, UnitRate3, HoursOrQty1, HoursOrQty2, HoursOrQty3, TaxID, oldOtherCostID);
        }
        public static DataTable get_estimate_othercost(long TypeID, long EstimateItemID, long OtherCostID)
        {
            return (new DbEstimate()).get_estimate_othercost(TypeID, EstimateItemID, OtherCostID);
        }
        public static DataTable Estimate_OtherCost_Qty_Details_Select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimate()).Estimate_OtherCost_Qty_Details_Select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable Estimate_OtherCost_Quantity_Details_Select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimate()).Estimate_OtherCost_Quantity_Details_Select(CompanyID, EstimateItemID, EstimateType);
        }

        public static string estimate_othercost_select(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).estimate_othercost_select(CompanyID, EstimateType, TypeID);
        }

        public static string estimate_othercost_select_by_categoryid(int CompanyID, int OtherCostCategoryID, string ParentEstimateType)
        {
            return (new DbEstimate()).estimate_othercost_select_by_categoryid(CompanyID, OtherCostCategoryID, ParentEstimateType);
        }

        public static string estimate_othercost_select_category(int CompanyID, string ParentEstimateType, bool IsOtherCostSequence)
        {
            return (new DbEstimate()).estimate_othercost_select_category(CompanyID, ParentEstimateType, IsOtherCostSequence);
        }

        public static void estimate_othercost_variableqty_delete(int CompanyID, long EstOtherCostID)
        {
            (new DbEstimate()).estimate_othercost_variableqty_delete(CompanyID, EstOtherCostID);
        }

        public static long estimate_othercost_variableqty_insert(int CompanyID, long EstOtherCostVariableID, long EstOtherCostID, long EstQuantityID, decimal HoursOrQty, decimal Cost, string EstType, string FormulaWithActual)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.estimate_othercost_variableqty_insert(CompanyID, EstOtherCostVariableID, EstOtherCostID, EstQuantityID, HoursOrQty, Cost, EstType, FormulaWithActual);
        }

        public static string estimate_othercost_variableqty_select(int CompanyID, long EstOthercostID, long EstQuantityID)
        {
            return (new DbEstimate()).estimate_othercost_variableqty_select(CompanyID, EstOthercostID, EstQuantityID);
        }

        public static DataTable Estimate_OtherCost_View_By_EstOtherCostID(int CompanyID, long EstOtherCostID)
        {
            return (new DbEstimate()).Estimate_OtherCost_View_By_EstOtherCostID(CompanyID, EstOtherCostID);
        }

        public static string Estimate_Outwork_By_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Outwork_By_ID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Outwork_Delete(int CompanyID, long OutworkID, string OutworkType)
        {
            (new DbEstimate()).Estimate_Outwork_Delete(CompanyID, OutworkID, OutworkType);
        }

        public static void Estimate_Outwork_Insert(int CompanyID, string Query, string IsPrintEmail, long EstimateItemID)
        {
            (new DbEstimate()).Estimate_Outwork_Insert(CompanyID, Query, IsPrintEmail, EstimateItemID);
        }

        public static string estimate_outwork_itemdescription_select(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).estimate_outwork_itemdescription_select(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Outwork_Quantity_Details_Select(int CompanyID, long EstOutworkID, int QtyNumber)
        {
            return (new DbEstimate()).Estimate_Outwork_Quantity_Details_Select(CompanyID, EstOutworkID, QtyNumber);
        }

        public static long Estimate_PadItem_Insert(EstimateItem item)
        {
            return (new DbEstimate()).Estimate_PadItem_Insert(item);
        }

        public static string estimate_paperproperties_select(int CompanyID, long InventoryID)
        {
            return (new DbEstimate()).estimate_paperproperties_select(CompanyID, InventoryID);
        }

        public static DataTable estimate_printbroker_headerfooter_select(int CompanyID, string EstType, long TypeID)
        {
            return (new DbEstimate()).estimate_printbroker_headerfooter_select(CompanyID, EstType, TypeID);
        }

        public static DataTable estimate_printbroker_item_outwork_quantity_details_select(int CompanyID, long EstOutworkID, int QtyNumber, int SupplierID)
        {
            return (new DbEstimate()).estimate_printbroker_item_outwork_quantity_details_select(CompanyID, EstOutworkID, QtyNumber, SupplierID);
        }

        public static DataTable estimate_printbroker_item_quantity_number_select(int CompanyID, long ItemID, string ItemType)
        {
            return (new DbEstimate()).estimate_printbroker_item_quantity_number_select(CompanyID, ItemID, ItemType);
        }

        public static DataTable estimate_printbroker_suppliers_count(int CompanyID, string Estype, long TypeID)
        {
            return (new DbEstimate()).estimate_printbroker_suppliers_count(CompanyID, Estype, TypeID);
        }

        public static long Estimate_Quantity_Insert(int CompanyID, string ItemType, long ItemID, string QtyType, int Qty1, int Qty2, int Qty3, int Qty4, int Qty5)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Estimate_Quantity_Insert(CompanyID, ItemType, ItemID, QtyType, Qty1, Qty2, Qty3, Qty4, Qty5);
        }

        public static DataTable Estimate_Quantity_Select_By_ID(int CompanyID, string EstimateType, long ItemID)
        {
            return (new DbEstimate()).Estimate_Quantity_Select_By_ID(CompanyID, EstimateType, ItemID);
        }

        public static DataTable Estimate_Quantity_Select_By_QtyNo(int CompanyID, string EstimateType, long ItemID, short QtyNo)
        {
            return (new DbEstimate()).Estimate_Quantity_Select_By_QtyNo(CompanyID, EstimateType, ItemID, QtyNo);
        }

        public static DataTable Estimate_Select_All(int CompanyID, string Para)
        {
            return (new DbEstimate()).Estimate_Select_All(CompanyID, Para);
        }

        public static DataTable Estimate_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Select_By_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Select_By_EstimateID_New(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Select_By_EstimateID_New(CompanyID, EstimateID);
        }

        public static void Estimate_Single_Item_Calculation_Insert(int CompanyID, long EstimateItemID, decimal PaperUnitPrice, decimal PaperWeight, decimal PaperMarkup, decimal OneSqCmInkCost, decimal InkMarkup, decimal LookUpCostPerClick, decimal SpeedHourlyRate, int PagesPerMinute, decimal LargeHourlyRate, int LargePrintPerHour, decimal PressSetupCharge, decimal PressMinimumRunningCharge, decimal PressMarkUp, decimal GuillotineSetupCharge, decimal GuillotineMinimumRunningCharge, decimal GuillotineMarkUp, decimal CostPerCut, decimal GuillotinePaperWeight, int GuillotineMaximumThroat)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.Estimate_Single_Item_Calculation_Insert(CompanyID, EstimateItemID, PaperUnitPrice, PaperWeight, PaperMarkup, OneSqCmInkCost, InkMarkup, LookUpCostPerClick, SpeedHourlyRate, PagesPerMinute, LargeHourlyRate, LargePrintPerHour, PressSetupCharge, PressMinimumRunningCharge, PressMarkUp, GuillotineSetupCharge, GuillotineMinimumRunningCharge, GuillotineMarkUp, CostPerCut, GuillotinePaperWeight, GuillotineMaximumThroat);
        }

        public static string Estimate_Single_Item_Outwork_by_ID_Select(int CompanyID, long EstItemOutworkID)
        {
            return (new DbEstimate()).Estimate_Single_Item_Outwork_by_ID_Select(CompanyID, EstItemOutworkID);
        }

        public static DataTable Estimate_Single_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Single_Item_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static long Estimate_SingleItem_Insert(EstimateItem item)
        {
            return (new DbEstimate()).Estimate_SingleItem_Insert(item);
        }

        public static void Estimate_SingleItem_Outwork_Insert(int CompanyID, string Query)
        {
            (new DbEstimate()).Estimate_SingleItem_Outwork_Insert(CompanyID, Query);
        }

        public static void Estimate_SingleItem_Warehouse_Insert(int CompanyID, string Query)
        {
            (new DbEstimate()).Estimate_SingleItem_Warehouse_Insert(CompanyID, Query);
        }

        public static long Estimate_SpeedWeight_Insert_BY_ID(int CompanyID, long EstimateItemID, long PressID, long EstSpeedWeightID)
        {
            return (new DbEstimate()).Estimate_SpeedWeight_Insert_BY_ID(CompanyID, EstimateItemID, PressID, EstSpeedWeightID);
        }

        public static void Estimate_Status_Update(int CompanyID, long EstimateID, int StatusID, string ModuleType, long ModuleID)
        {
            (new DbEstimate()).Estimate_Status_Update(CompanyID, EstimateID, StatusID, ModuleType, ModuleID);
        }
        public static void Proof_Status_Update(int CompanyID, int StatusID, string ModuleType, long ModuleID)
        {
            (new DbEstimate()).Proof_Status_Update(CompanyID, StatusID, ModuleType, ModuleID);
        }
        public static void Proof_ItemStatus_Update(int CompanyID,long EstimateItemID, int StatusID, string ModuleType, long ModuleID,int ProofItemID)
        {
            (new DbEstimate()).Proof_ItemStatus_Update(CompanyID,EstimateItemID, StatusID, ModuleType, ModuleID, ProofItemID);
        }

        public static string Estimate_Summary_Booklet_Data(int CompanyID, long EstBookletSectionID, long EstBookletQty)
        {
            return (new DbEstimate()).Estimate_Summary_Booklet_Data(CompanyID, EstBookletSectionID, EstBookletQty);
        }

        public static DataTable Estimate_Summary_Booklet_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Booklet_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static string Estimate_Summary_Booklet_Qty_by_SectionID(int CompanyID, long EstBookletSectionID)
        {
            return (new DbEstimate()).Estimate_Summary_Booklet_Qty_by_SectionID(CompanyID, EstBookletSectionID);
        }

        public static void Estimate_Summary_Booklet_Update(int CompanyID, string data)
        {
            (new DbEstimate()).Estimate_Summary_Booklet_Update(CompanyID, data);
        }

        public static DataTable Estimate_Summary_Calculation_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID, long EstBookletSectionID)
        {
            return (new DbEstimate()).Estimate_Summary_Calculation_Select_By_EstimateItem_ID(CompanyID, EstimateItemID, EstBookletSectionID);
        }

        public static DataTable Estimate_Summary_ClickChargeZone_Select_By_ID(int CompanyID, long EstCalculationID, decimal TotalSheets, string ZoneType)
        {
            return (new DbEstimate()).Estimate_Summary_ClickChargeZone_Select_By_ID(CompanyID, EstCalculationID, TotalSheets, ZoneType);
        }

        public static void Estimate_Summary_EstimateValues_Update(int CompanyID, long EstimateID, double EstimateValue)
        {
            (new DbEstimate()).Estimate_Summary_EstimateValues_Update(CompanyID, EstimateID, EstimateValue);
        }

        public static decimal Estimate_Summary_Guillotine_Standard_Table(int CompanyID, decimal Printlayout, string IsGutter)
        {
            return (new DbEstimate()).Estimate_Summary_Guillotine_Standard_Table(CompanyID, Printlayout, IsGutter);
        }

        public static DataTable Estimate_Summary_Item_Cost_View_Qtys_And_Cal(int CompanyID, long EstimateItemID, long TypeID, string EstType, long EstBookletSectionID, string SpType)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.Estimate_Summary_Item_Cost_View_Qtys_And_Cal(CompanyID, EstimateItemID, TypeID, EstType, EstBookletSectionID, SpType);
        }

        public static DataTable Estimate_Summary_Item_Cost_View_Qtys_And_Cal_Book(int CompanyID, long EstBookletSectionID, string SpType)
        {
            return (new DbEstimate()).Estimate_Summary_Item_Cost_View_Qtys_And_Cal_Book(CompanyID, EstBookletSectionID, SpType);
        }

        public static void Estimate_Summary_Item_Delete(int CompanyID, long EstimateItemID)
        {
            (new DbEstimate()).Estimate_Summary_Item_Delete(CompanyID, EstimateItemID);
        }

        public static void Estimate_Summary_Item_Markup_Update(int CompanyID, long PrimaryKeyID, decimal Markup, string ItemType, decimal TotalPrice)
        {
            (new DbEstimate()).Estimate_Summary_Item_Markup_Update(CompanyID, PrimaryKeyID, Markup, ItemType, TotalPrice);
        }

        public static void Estimate_Summary_Item_OtherQuantities_Markup_Update(long PrimaryKeyID, decimal Markup2, decimal Markup3, decimal Markup4)
        {
            (new DbEstimate()).Estimate_Summary_Item_OtherQuantities_Markup_Update(PrimaryKeyID, Markup2, Markup3, Markup4);
        }
        public static DataTable Estimate_Summary_Item_OtherCost_select(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Summary_Item_OtherCost_select(CompanyID, EstimateType, TypeID);
        }

        public static string Estimate_Summary_Item_Outwork_Cost(int CompanyID, long TypeID)
        {
            return (new DbEstimate()).Estimate_Summary_Item_Outwork_Cost(CompanyID, TypeID);
        }

        public static DataTable Estimate_Summary_Item_Outwork_select(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Summary_Item_Outwork_select(CompanyID, EstimateType, TypeID);
        }

        public static string Estimate_Summary_Item_Warehouse_Cost(int CompanyID, long TypeID, string ItemType)
        {
            return (new DbEstimate()).Estimate_Summary_Item_Warehouse_Cost(CompanyID, TypeID, ItemType);
        }

        public static DataTable Estimate_Summary_Item_Warehouse_select(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Summary_Item_Warehouse_select(CompanyID, EstimateType, TypeID);
        }

        public static DataTable Estimate_Summary_Items_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Estimate_Summary_Items_select_by_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Summary_Items_select_by_JobInvoiceID(int CompanyID, string Module, long ID)
        {
            return (new DbEstimate()).Estimate_Summary_Items_select_by_JobInvoiceID(CompanyID, Module, ID);
        }

        public static Int32 PC_select_JobLocking_Status(long ID)
        {
            return (new DbEstimate()).PC_select_JobLocking_Status(ID);
        }

        public static void PC_update_JobLocking_Status(long ID, Boolean Status)
        {
            (new DbEstimate()).PC_update_JobLocking_Status(ID, Status);
        }



        public static DataTable Estimate_Summary_Large_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Large_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static string Estimate_Summary_OtherCost_Cost_Select(int CompanyID, long EstQuantityID)
        {
            return (new DbEstimate()).Estimate_Summary_OtherCost_Cost_Select(CompanyID, EstQuantityID);
        }

        public static void Estimate_Summary_OtherCost_Remove(int CompanyID, long EstOtherCostID)
        {
            (new DbEstimate()).Estimate_Summary_OtherCost_Remove(CompanyID, EstOtherCostID);
        }

        public static DataTable Estimate_Summary_OtherCost_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_OtherCost_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Summary_OtherCost_SubTotal_Update(int CompanyID, long EstimateItemID, decimal Profitmargin, decimal SubTotal, decimal Tax, string ItemTitle, int TaxID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.Estimate_Summary_OtherCost_SubTotal_Update(CompanyID, EstimateItemID, Profitmargin, SubTotal, Tax, ItemTitle, TaxID);
        }

        public static DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Outwork_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_1(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Outwork_Select_By_EstimateItemID_1(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_2(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Outwork_Select_By_EstimateItemID_2(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_3(int CompanyID, long EstOutworkID, int SupplierID)
        {
            return (new DbEstimate()).Estimate_Summary_Outwork_Select_By_EstimateItemID_3(CompanyID, EstOutworkID, SupplierID);
        }

        public static void Estimate_Summary_Outwork_Update(int CompanyID, long EstOutworkSupplierID, string ItemTitle, decimal Tax, decimal ProfitMargin, decimal SubTotal, int TaxID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.Estimate_Summary_Outwork_Update(CompanyID, EstOutworkSupplierID, ItemTitle, Tax, ProfitMargin, SubTotal, TaxID);
        }

        public static DataTable Estimate_Summary_Pad_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Pad_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Summary_Single_Item_Update(int CompanyID, string Data)
        {
            (new DbEstimate()).Estimate_Summary_Single_Item_Update(CompanyID, Data);
        }

        public static DataTable Estimate_Summary_SpeedWeight_Select_By_ID(int CompanyID, long EstSpeedWeightID)
        {
            return (new DbEstimate()).Estimate_Summary_SpeedWeight_Select_By_ID(CompanyID, EstSpeedWeightID);
        }

        public static DataTable Estimate_Summary_SubItem_OtherCost(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).Estimate_Summary_SubItem_OtherCost(CompanyID, EstimateType, TypeID);
        }

        public static DataTable Estimate_Summary_SubTotal_Select(int CompanyID, long ItemID)
        {
            return (new DbEstimate()).Estimate_Summary_SubTotal_Select(CompanyID, ItemID);
        }

        public static string Estimate_Summary_Tax_Bind(int CompanyID)
        {
            return (new DbEstimate()).Estimate_Summary_Tax_Bind(CompanyID);
        }

        public static DataTable estimate_summary_tax_bind_2(int CompanyID)
        {
            return (new DbEstimate()).estimate_summary_tax_bind_2(CompanyID);
        }

        public static string estimate_summary_tax_bind_3(int CompanyID)
        {
            return (new DbEstimate()).estimate_summary_tax_bind_3(CompanyID);
        }

        public static decimal Estimate_Summary_TaxRate(int CompanyID)
        {
            return (new DbEstimate()).Estimate_Summary_TaxRate(CompanyID);
        }

        public static void Estimate_Summary_Update(int CompanyID, long ItemID, decimal ProfitMargin, decimal SubTotal1, decimal SubTotal2, decimal SubTotal3, decimal SubTotal4)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.Estimate_Summary_Update(CompanyID, ItemID, ProfitMargin, SubTotal1, SubTotal2, SubTotal3, SubTotal4);
        }

        public static void Estimate_Summary_Warehouse_Delete(int CompanyID, long EstWarehouseItemID)
        {
            (new DbEstimate()).Estimate_Summary_Warehouse_Delete(CompanyID, EstWarehouseItemID);
        }

        public static string Estimate_Summary_Warehouse_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Warehouse_Select_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Warehouse_SubTotal_Slect_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Summary_Warehouse_SubTotal_Slect_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Summary_Warehouse_SubTotal_Update(int CompanyID, long EstimateItemID, decimal ProfitMargin, decimal SubTotal, decimal Tax, string ItemTitle, int TaxID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.Estimate_Summary_Warehouse_SubTotal_Update(CompanyID, EstimateItemID, ProfitMargin, SubTotal, Tax, ItemTitle, TaxID);
        }

        public static void estimate_tojob_headerfooter_update(int CompanyID, long EstimateID, string Header, string Footer)
        {
            (new DbEstimate()).estimate_tojob_headerfooter_update(CompanyID, EstimateID, Header, Footer);
        }

        public static DataTable estimate_type_info_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).estimate_type_info_by_estimateitemid(CompanyID, EstimateItemID);
        }

        public static void Estimate_UnArchive(int CompanyID, long EstimateID)
        {
            (new DbEstimate()).Estimate_UnArchive(CompanyID, EstimateID);
        }

        public static int Estimate_ViewNameduplicacy_check(int CompanyID, string ViewName, int ViewID, string pagename)
        {
            return (new DbEstimate()).Estimate_ViewNameduplicacy_check(CompanyID, ViewName, ViewID, pagename);
        }

        public static void Estimate_Warehouse_Insert(int CompanyID, string Query)
        {
            (new DbEstimate()).Estimate_Warehouse_Insert(CompanyID, Query);
        }

        public static DataTable Estimate_Warehouse_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).Estimate_Warehouse_Item_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static void estimate_warehouseqty_update(int CompanyID, long WarehouseItemID, string WarehouseItemType, decimal AllocatedQty, string ProgressRevertType, long EstimateItemID)
        {
            (new DbEstimate()).estimate_warehouseqty_update(CompanyID, WarehouseItemID, WarehouseItemType, AllocatedQty, ProgressRevertType, EstimateItemID);
        }

        public static DataTable estimate_zone_2nd_calculation(int CompanyID, long EstCalculationID, decimal TotalSheets, string ZoneType)
        {
            return (new DbEstimate()).estimate_zone_2nd_calculation(CompanyID, EstCalculationID, TotalSheets, ZoneType);
        }

        public static DataTable EstimateItemID_Select(int CompanyID, int UserID, long PurchaseID)
        {
            return (new DbEstimate()).EstimateItemID_Select(CompanyID, UserID, PurchaseID);
        }

        public static DataTable EstimateItemID_Select_eStore(int CompanyID, int UserID, long EstimateID)
        {
            return (new DbEstimate()).EstimateItemID_Select_eStore(CompanyID, UserID, EstimateID);
        }

        public static void EstimateOnCheck_Status_Update(int CompanyID, string EstimateID, int StatusID, string Module)
        {
            (new DbEstimate()).EstimateOnCheck_Status_Update(CompanyID, EstimateID, StatusID, Module);
        }

        public static void EstimateQuoteDetails_Update_ByAdmin_Unselect(string EstimateItemID)
        {
            (new DbEstimate()).EstimateQuoteDetails_Update_ByAdmin_Unselect(EstimateItemID);
        }

        public static void estimates_attachment_delete(int CompanyID, long AttachmentID)
        {
            (new DbEstimate()).estimates_attachment_delete(CompanyID, AttachmentID);
        }

        public static DataTable estimates_attachment_select(int CompanyID, long AttachmentTypeID)
        {
            return (new DbEstimate()).estimates_attachment_select(CompanyID, AttachmentTypeID);
        }

        public static int estimates_customview_count(int CompanyID, string pagename)
        {
            return (new DbEstimate()).estimates_customview_count(CompanyID, pagename);
        }

        public static decimal estimates_estcalculation_select(int CompanyID, long EstCalculationID, string EstCalType)
        {
            return (new DbEstimate()).estimates_estcalculation_select(CompanyID, EstCalculationID, EstCalType);
        }

        public static long estimates_estcalculation_update(int CompanyID, long EstCalculationID, decimal Markup, string EstCalType)
        {
            return (new DbEstimate()).estimates_estcalculation_update(CompanyID, EstCalculationID, Markup, EstCalType);
        }

        public static DataTable estimates_notes_select(int CompanyID, string ModuleType, long ModuleID, string NotesType)
        {
            return (new DbEstimate()).estimates_notes_select(CompanyID, ModuleType, ModuleID, NotesType);
        }

        public static DataTable estimates_notes_select_PerItem(int CompanyID, string ModuleType, long ModuleID, string NotesType, long ItemID)
        {
            return (new DbEstimate()).estimates_notes_select_PerItem(CompanyID, ModuleType, ModuleID, NotesType, ItemID);
        }

        public static DataTable estimates_notestag_select(int CompanyID)
        {
            return (new DbEstimate()).estimates_notestag_select(CompanyID);
        }

        public static IDataReader estimates_number_estid_select(int CompanyID, string Module)
        {
            return (new DbEstimate()).estimates_number_estid_select(CompanyID, Module);
        }

        public static string estimates_othercost_selectall(int CompanyID)
        {
            return (new DbEstimate()).estimates_othercost_selectall(CompanyID);
        }

        public static string estimates_quantity_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return (new DbEstimate()).estimates_quantity_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable estimates_systemnotes_select(int CompanyID, string NotesTag)
        {
            return (new DbEstimate()).estimates_systemnotes_select(CompanyID, NotesTag);
        }

        public static DataTable Estimates_ViewName_Select_By_ID(int CompanyID, long ViewID, string Pagename)
        {
            return (new DbEstimate()).Estimates_ViewName_Select_By_ID(CompanyID, ViewID, Pagename);
        }

        public static bool EstPriceCatalogue_IsBackOrder_Check(long PriceCatalogueID, int Quantity, long EstimateItemID)
        {
            return (new DbEstimate()).EstPriceCatalogue_IsBackOrder_Check(PriceCatalogueID, Quantity, EstimateItemID);
        }

        public static int etimates_attachment_insert(EstimateItem item)
        {
            return (new DbEstimate()).etimates_attachment_insert(item);
        }

        public static int etimates_notes_insert(string CompanyID, string NotesID, string ModuleType, string ModuleID, string Type, string ErrorType, string NotesType, string Description, string CreatedBy, string CreatedDate, string ItemId)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.etimates_notes_insert(CompanyID, NotesID, ModuleType, ModuleID, Type, ErrorType, NotesType, Description, CreatedBy, CreatedDate, ItemId);
        }

        public static void etimates_tempattachment_delete(int CompanyID, int UserID)
        {
            (new DbEstimate()).etimates_tempattachment_delete(CompanyID, UserID);
        }

        public static int etimates_tempattachment_insert(int CompanyID, long TempEstAttachmentID, int UserID, string ItemNo, string FileName)
        {
            return (new DbEstimate()).etimates_tempattachment_insert(CompanyID, TempEstAttachmentID, UserID, ItemNo, FileName);
        }

        public static DataTable etimates_tempattachment_selectall(int CompanyID, int UserID, string ItemNo)
        {
            return (new DbEstimate()).etimates_tempattachment_selectall(CompanyID, UserID, ItemNo);
        }

        public static int Get_Client_PaymentTerms(long ClientID)
        {
            return (new DbEstimate()).Get_Client_PaymentTerms(ClientID);
        }

        public static DataTable GetCostCentre_Autofill(int CompamyID, int ClientID, int DepartmentID, int ContactID)
        {
            return (new DbEstimate()).GetCostCentre_Autofill(CompamyID, ClientID, DepartmentID, ContactID);
        }

        public static DataTable Ink_Information_By_LargeItem_ID(int CompanyID, long EstLargeItemID)
        {
            return (new DbEstimate()).Ink_Information_By_LargeItem_ID(CompanyID, EstLargeItemID);
        }

        public static void Insert_EmailAttachment(long EstimateID, string FileName)
        {
            (new DbEstimate()).Insert_EmailAttachment(EstimateID, FileName);
        }

        public static void Insert_EmailAttachment_ItemSpecific(long EstimateID, long AttachmentTypeID, string FileName)
        {
            (new DbEstimate()).Insert_EmailAttachment_ItemSpecific(EstimateID, AttachmentTypeID, FileName);
        }

        public static void Insert_EmailAttachment_ItemSpecific_SupplierRFQ(long EstimateID, long AttachmentTypeID, string FileName)
        {
            (new DbEstimate()).Insert_EmailAttachment_ItemSpecific_SupplierRFQ(EstimateID, AttachmentTypeID, FileName);
        }

        public static void Insert_EmailAttachment_SupplierRFQ(long EstimateID, long AttachmentTypeID, string FileName)
        {
            (new DbEstimate()).Insert_EmailAttachment_SupplierRFQ(EstimateID, AttachmentTypeID, FileName);
        }

        public static DataTable Invoice_ItemDescn_EstimateNum_Select(int CompanyID, int UserID, long EstimateID)
        {
            return (new DbEstimate()).Invoice_ItemDescn_EstimateNum_Select(CompanyID, UserID, EstimateID);
        }

        public static DataTable Invoice_Purchase_QuickLinks_Select(int CompanyID, long InvoiceID)
        {
            return (new DbEstimate()).Invoice_Purchase_QuickLinks_Select(CompanyID, InvoiceID);
        }

        public static DataTable Item_Other_Cost_By_ID(int CompanyID, long EstimateItemID, int QuantityID)
        {
            return (new DbEstimate()).Item_Other_Cost_By_ID(CompanyID, EstimateItemID, QuantityID);
        }

        public static DataTable item_othercost_by_qty_id_new_qtynumber(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID, int QtyNumber)
        {
            return (new DbEstimate()).item_othercost_by_qty_id_new_qtynumber(CompanyID, EstimateType, TypeID, EstOtherCostID, QtyNumber);
        }

        public static DataTable job_card_info_select_by_estimateid(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).job_card_info_select_by_estimateid(CompanyID, EstimateID);
        }

        public static DataTable job_card_info_select_by_estimateid_With_Subitem(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).job_card_info_select_by_estimateid_With_Subitem(CompanyID, EstimateID);
        }

        public static DataTable job_card_info_select_by_estimateid_new_RaisePO(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).job_card_info_select_by_estimateid_new_RaisePO(CompanyID, EstimateID);
        }

        public static DataTable job_card_info_select_by_OrderID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).job_card_info_select_by_OrderID(CompanyID, EstimateID);
        }

        public static DataTable job_details_oncustomerid_select(int CompanyID, int CustomerID)
        {
            return (new DbEstimate()).job_details_oncustomerid_select(CompanyID, CustomerID);
        }

        public static DataTable JobDeliveryNote_Details_Select(int CompanyID, int CustomerID)
        {
            return (new DbEstimate()).JobDeliveryNote_Details_Select(CompanyID, CustomerID);
        }

        public static DataTable Jobs_Jobcard_Jobdetails_selectByEstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Jobs_Jobcard_Jobdetails_selectByEstimateID(CompanyID, EstimateID);
        }

        public static int KeyCode_Check(string KeyCode)
        {
            return (new DbEstimate()).KeyCode_Check(KeyCode);
        }

        public static string LargeFormat_Press_Select(int CompanyID)
        {
            return (new DbEstimate()).LargeFormat_Press_Select(CompanyID);
        }

        public static string Material_Calculation(long CompanyID, long PaperID)
        {
            return (new DbEstimate()).Material_Calculation(CompanyID, PaperID);
        }

        public static void NoticationSeen_insert(long UserID, long NotificationID)
        {
            (new DbEstimate()).NoticationSeen_insert(UserID, NotificationID);
        }

        public static int NoticationSeen_select(long UserID, long NotificationID)
        {
            return (new DbEstimate()).NoticationSeen_select(UserID, NotificationID);
        }

        public static DataTable Notification_select(string VersionNumber)
        {
            return (new DbEstimate()).Notification_select(VersionNumber);
        }

        public static DataTable other_cost_select_by_itemid(int CompanyID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).other_cost_select_by_itemid(CompanyID, Old_EstimateItemID);
        }

        public static DataTable othercost_all_cost_by_estimateitem_id(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).othercost_all_cost_by_estimateitem_id(CompanyID, EstimateItemID);
        }

        public static void othercost_formula_value_update(int CompanyID, long EstimateItemID, string FormulaWithActualValue)
        {
            (new DbEstimate()).othercost_formula_value_update(CompanyID, EstimateItemID, FormulaWithActualValue);
        }

        public static DataTable othercost_select_by_bookletsection(int CompanyID, long EstBookletSectionID)
        {
            return (new DbEstimate()).othercost_select_by_bookletsection(CompanyID, EstBookletSectionID);
        }

        public static DataTable othercost_subitem_by_sectionid(int CompanyID, long EstimateItemID, long QuantityID, long EstBookletSectionID)
        {
            return (new DbEstimate()).othercost_subitem_by_sectionid(CompanyID, EstimateItemID, QuantityID, EstBookletSectionID);
        }

        public static DataTable OtherCost_SubItem_Select_By_EstOtherCostID(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID)
        {
            return (new DbEstimate()).OtherCost_SubItem_Select_By_EstOtherCostID(CompanyID, EstimateType, TypeID, EstOtherCostID);
        }

        public static DataTable OtherMultiple_product_Select(int CompanyID, long PriceCatalogueID)
        {
            return (new DbEstimate()).OtherMultiple_product_Select(CompanyID, PriceCatalogueID);
        }

        public static DataTable outwork_select_qty(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).outwork_select_qty(CompanyID, EstimateItemID);
        }

        public static DataTable outwork_supplier_select_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).outwork_supplier_select_by_estimateitemid(CompanyID, EstimateItemID);
        }

        public static void OutworkItemAttachmentUpdate(int CompanyID, int UserID, long ModuleID, long EstimateItemID, char EstimateType, string Filename, string ModuleType, string DeleteFiles, string OnLoadArtworkFileDeleted)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.OutworkItemAttachmentUpdate(CompanyID, UserID, ModuleID, EstimateItemID, EstimateType, Filename, ModuleType, DeleteFiles, OnLoadArtworkFileDeleted);
        }

        public static DataSet PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static string Paper_Calculation(int CompanyID, int PaperID)
        {
            return (new DbEstimate()).Paper_Calculation(CompanyID, PaperID);
        }

        public static string Paper_Size_Select(int CompanyID)
        {
            return (new DbEstimate()).Paper_Size_Select(CompanyID);
        }

        public static string PC_estimates_othercost_select_byOtherCostID(int CompanyID, long OtherCostID)
        {
            return (new DbEstimate()).PC_estimates_othercost_select_byOtherCostID(CompanyID, OtherCostID);
        }

        public static DataSet PC_QuickLinkDetails_Select(int CompanyID, long ModuleID, string Module)
        {
            return (new DbEstimate()).PC_QuickLinkDetails_Select(CompanyID, ModuleID, Module);
        }

        public static void price_catalogue_insert(int CompanyID, string Data, long EstimateItemID)
        {
            (new DbEstimate()).price_catalogue_insert(CompanyID, Data, EstimateItemID);
        }
        /// warehouse Modification By Bilal
        public static void Stock_Replenishment_insert(int CompanyID, string Data, long EstimateItemID)
        {
            (new DbEstimate()).Stock_Replenishment_insert(CompanyID, Data, EstimateItemID);
        }

        public static void price_catalogue_markup_update(int CompanyID, long EstPriceCatalogueID, decimal Markup)
        {
            (new DbEstimate()).price_catalogue_markup_update(CompanyID, EstPriceCatalogueID, Markup);
        }

        public static void price_catalogue_price_update(int CompanyID, long EstPriceCatalogueID, decimal Price)
        {
            (new DbEstimate()).price_catalogue_Price_update(CompanyID, EstPriceCatalogueID, Price);
        }

        public static DataTable price_catalogue_select(int CompanyID)
        {
            return (new DbEstimate()).price_catalogue_select(CompanyID);
        }

        public static DataTable price_catalogue_select_by_estimateitem_id(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).price_catalogue_select_by_estimateitem_id(CompanyID, EstimateItemID);
        }

        public static DataTable price_catalogue_select_by_id(int CompanyID, long PriceCatalogueID, char Drawstockfrom)
        {
            return (new DbEstimate()).price_catalogue_select_by_id(CompanyID, PriceCatalogueID, Drawstockfrom);
        }

        public static DataSet price_catalogue_select_search(int CompanyID, string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, int PageSize, int PageNumber, string SortExpression, string SortDirection, string Webstore, string WhereConditionEstimateProdouct)
        {
            DbEstimate dbEstimate = new DbEstimate();
            return dbEstimate.price_catalogue_select_search(CompanyID, QueryType, CustomerID, CustomerName, ItemTitle, Description, PageSize, PageNumber, SortExpression, SortDirection, Webstore, WhereConditionEstimateProdouct);
        }

        public static void price_catalogue_summary_update(int CompanyID, long EstimateItemID, string ItemTitle, decimal SubTotal, decimal ProfitMargin, decimal Tax, long EstPriceCatalogueID, int TaxID)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.price_catalogue_summary_update(CompanyID, EstimateItemID, ItemTitle, SubTotal, ProfitMargin, Tax, EstPriceCatalogueID, TaxID);
        }

        public static DataTable PrintBroker_SubItem_Select_By_Quantity(int CompanyID, string EstimateType, long TypeID, int Quantity)
        {
            return (new DbEstimate()).PrintBroker_SubItem_Select_By_Quantity(CompanyID, EstimateType, TypeID, Quantity);
        }

        public static DataTable ProductAdditional_Price_Select(long EstimateID, long EstimateItemID, string pgType)
        {
            return (new DbEstimate()).ProductAdditional_Price_Select(EstimateID, EstimateItemID, pgType);
        }

        public static DataTable Profit_Margin_By_Client_System(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).Profit_Margin_By_Client_System(CompanyID, EstimateID);
        }

        public static bool ProgressToJob_IsBackOrder_Check(long EstimateItemID, int QtyNumber)
        {
            return (new DbEstimate()).ProgressToJob_IsBackOrder_Check(EstimateItemID, QtyNumber);
        }

        public static DataTable Purchase_PurchaseID_Select(long EstimateID, long AttachmenttypeID)
        {
            return (new DbEstimate()).Purchase_PurchaseID_Select(EstimateID, AttachmenttypeID);
        }

        public static DataTable purchase_select_by_estimateid(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).purchase_select_by_estimateid(CompanyID, EstimateID);
        }

        public static DataTable purchase_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).purchase_select_by_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable purchase_select_by_JobID(int CompanyID, long JobID)
        {
            return (new DbEstimate()).purchase_select_by_JobID(CompanyID, JobID);
        }

        public static DataTable purchase_select_by_purchaseID(int CompanyID, long PurchaseID)
        {
            return (new DbEstimate()).purchase_select_by_purchaseID(CompanyID, PurchaseID);
        }

        public static DataTable purchaseItem_select_by_estimateid(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).purchaseItem_select_by_estimateid(CompanyID, EstimateItemID);
        }

        public static void PurchaseOrdStatusUpdate(long CompanyID, long StatusID, long PurchaseID)
        {
            (new DbEstimate()).PurchaseOrdStatusUpdate(CompanyID, StatusID, PurchaseID);
        }

        public static DataTable quantity_select_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).quantity_select_by_estimateitemid(CompanyID, EstimateItemID);
        }

        public static void QuickQuote_AccountingCode_Insert(long EstimateItemID, int CompanyID, int AccountCodeID)
        {
            (new DbEstimate()).QuickQuote_AccountingCode_Insert(EstimateItemID, CompanyID, AccountCodeID);
        }

        public static void DeliveryCost_AccountingCode_Insert(long EstimateItemID, int CompanyID, int AccountCodeID)
        {
            (new DbEstimate()).DeliveryCost_AccountingCode_Insert(EstimateItemID, CompanyID, AccountCodeID);
        }

        public static int QuickQuote_AccountingCode_Select(long EstimateItemID, int CompanyID)
        {
            return (new DbEstimate()).QuickQuote_AccountingCode_Select(EstimateItemID, CompanyID);
        }

        public static int DeliveryCost_AccountingCode_Select(long EstimateItemID, int CompanyID)
        {
            return (new DbEstimate()).DeliveryCost_AccountingCode_Select(EstimateItemID, CompanyID);
        }

        public static DataTable Select_AccountingCode_For_eStoreSummary(int CompanyID)
        {
            return (new DbEstimate()).Select_AccountingCode_For_eStoreSummary(CompanyID);
        }

        public static DataTable Select_EmailAttachment_General(long EstimateID)
        {
            return (new DbEstimate()).Select_EmailAttachment_General(EstimateID);
        }

        public static DataTable Select_EstimateItemDetails(int ComanyID, long ModuleID, long EstimateItemID, string ModuleName)
        {
            return (new DbEstimate()).Select_EstimateItemDetails(ComanyID, ModuleID, EstimateItemID, ModuleName);
        }

        public static DataTable Select_EstimateItemID_SupplierID_EmailAttach(long EstimateID, long EstimateItemID)
        {
            return (new DbEstimate()).Select_EstimateItemID_SupplierID_EmailAttach(EstimateID, EstimateItemID);
        }

        public static DataTable select_IssupplierQuote(long CompanyID)
        {
            return (new DbEstimate()).select_IssupplierQuote(CompanyID);
        }

        public static void Select_ItemDesn_OnCheckboxCheck(long EstimateItemID, string Label, string FieldName, string Description, bool IsChecked)
        {
            (new DbEstimate()).Select_ItemDesn_OnCheckboxCheck(EstimateItemID, Label, FieldName, Description, IsChecked);
        }

        public static DataTable selectEstimatetype_estimateitemid_New(long EstimateItemID, long EstimateID)
        {
            return (new DbEstimate()).selectEstimatetype_estimateitemid_New(EstimateItemID, EstimateID);
        }

        public static long SingelItem_Inset_By_Copy(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return (new DbEstimate()).SingelItem_Inset_By_Copy(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static int SubItemType_ByParentItemID_Select(long ParentItemID)
        {
            return (new DbEstimate()).SubItemType_ByParentItemID_Select(ParentItemID);
        }

        public static string SubOtem_OtherCost_List(int CompanyID, string EstimateType, long TypeID)
        {
            return (new DbEstimate()).SubOtem_OtherCost_List(CompanyID, EstimateType, TypeID);
        }

        public static DataTable SuplrQt_EstItmID_perEstID(long EstimateItemID)
        {
            return (new DbEstimate()).SuplrQt_EstItmID_perEstID(EstimateItemID);
        }

        public static string Supplier_Contacts_Select(int CompanyID)
        {
            return (new DbEstimate()).Supplier_Contacts_Select(CompanyID);
        }

        public static DataSet Supplier_QuoteAccepted_Details(long EstimateItemID)
        {
            return (new DbEstimate()).Supplier_QuoteAccepted_Details(EstimateItemID);
        }

        public static string Supplier_Select(int CompanyID)
        {
            return (new DbEstimate()).Supplier_Select(CompanyID);
        }

        public static string supplier_select_in_printbroker(int CompanyID)
        {
            return (new DbEstimate()).supplier_select_in_printbroker(CompanyID);
        }

        public static string supplier_select_in_QuoteDetails(int CompanyID, long EstimateItemID)
        {
            return (new DbEstimate()).supplier_select_in_QuoteDetails(CompanyID, EstimateItemID);
        }

        public static void SupplierDetailsInsert_HistoryTable(string EstimateItemID, string SupplierID, string Quantity1, string Price1, DateTime DeliveryDate1, string IsDeliveryIncluded1, string DeliveryCost1, string MarkUpValue1, string TotalPrice1, string Quantity2, string Price2, DateTime DeliveryDate2, string IsDeliveryIncluded2, string DeliveryCost2, string MarkUpValue2, string TotalPrice2, string Quantity3, string Price3, DateTime DeliveryDate3, string IsDeliveryIncluded3, string DeliveryCost3, string MarkUpValue3, string TotalPrice3, string Quantity4, string Price4, DateTime DeliveryDate4, string IsDeliveryIncluded4, string DeliveryCost4, string MarkUpValue4, string TotalPrice4, string MarkUpType, string Comments, string KeyCode)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.SupplierDetailsInsert_HistoryTable(EstimateItemID, SupplierID, Quantity1, Price1, DeliveryDate1, IsDeliveryIncluded1, DeliveryCost1, MarkUpValue1, TotalPrice1, Quantity2, Price2, DeliveryDate2, IsDeliveryIncluded2, DeliveryCost2, MarkUpValue2, TotalPrice2, Quantity3, Price3, DeliveryDate3, IsDeliveryIncluded3, DeliveryCost3, MarkUpValue3, TotalPrice3, Quantity4, Price4, DeliveryDate4, IsDeliveryIncluded4, DeliveryCost4, MarkUpValue4, TotalPrice4, MarkUpType, Comments, KeyCode);
        }

        public static void SupplierDetailsInsert_OnlySave(string EstimateItemID, string SupplierID, string Quantity, string Cost, DateTime DeliveryDate, string IsDeliveryIncluded, string DeliveryCost, string QuantityNumber, string MarkUpType, string MarkupValue, string TotalPrice, string SupplierQuoteNo, string IsSelected, string KeyCode, string Type)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.SupplierDetailsInsert_OnlySave(EstimateItemID, SupplierID, Quantity, Cost, DeliveryDate, IsDeliveryIncluded, DeliveryCost, QuantityNumber, MarkUpType, MarkupValue, TotalPrice, SupplierQuoteNo, IsSelected, KeyCode, Type);
        }

        public static DataTable SupplierEmailBody_Select(long CompanyID, string TemplateType)
        {
            return (new DbEstimate()).SupplierEmailBody_Select(CompanyID, TemplateType);
        }

        public static DataSet SupplierQuote_Details(string KeyCode)
        {
            return (new DbEstimate()).SupplierQuote_Details(KeyCode);
        }

        public static void SupplierQuote_Insert_BySupplier(string EstimateItemID, string SupplierID, string EstimateNumber, string EstimateTitle, string ArtworkIncluded, string ArtwordFileName, DateTime RFQDueBy, DateTime JobCompletionDate, string ItemTitle, string ItemDescription, string UserEstimateNumber, string Comments, string Quantity1, string Price1, DateTime DeliveryDate1, string IsDeliveryIncluded1, string DeliveryCost1, string Quantity2, string Price2, DateTime DeliveryDate2, string IsDeliveryIncluded2, string DeliveryCost2, string Quantity3, string Price3, DateTime DeliveryDate3, string IsDeliveryIncluded3, string DeliveryCost3, string Quantity4, string Price4, DateTime DeliveryDate4, string IsDeliveryIncluded4, string DeliveryCost4, int IsRejected, string RejectedReason, string KeyCode)
        {
            DbEstimate dbEstimate = new DbEstimate();
            dbEstimate.SupplierQuote_Insert_BySupplier(EstimateItemID, SupplierID, EstimateNumber, EstimateTitle, ArtworkIncluded, ArtwordFileName, RFQDueBy, JobCompletionDate, ItemTitle, ItemDescription, UserEstimateNumber, Comments, Quantity1, Price1, DeliveryDate1, IsDeliveryIncluded1, DeliveryCost1, Quantity2, Price2, DeliveryDate2, IsDeliveryIncluded2, DeliveryCost2, Quantity3, Price3, DeliveryDate3, IsDeliveryIncluded3, DeliveryCost3, Quantity4, Price4, DeliveryDate4, IsDeliveryIncluded4, DeliveryCost4, IsRejected, RejectedReason, KeyCode);
        }

        public static DataTable template_printbroker_RFQdescription_Select(int CompanyID, string Estype, long TypeID)
        {
            return (new DbEstimate()).template_printbroker_RFQdescription_Select(CompanyID, Estype, TypeID);
        }

        public static void Update_Description_OnCheck(int CompanyID, long EstimateID, long EstimateItemID, string Description)
        {
            (new DbEstimate()).Update_Description_OnCheck(CompanyID, EstimateID, EstimateItemID, Description);
        }

        public static void Update_Description_OnCheck_DN(long EstimateID, long EstimateItemID, string Description)
        {
            (new DbEstimate()).Update_Description_OnCheck_DN(EstimateID, EstimateItemID, Description);
        }

        public static DataTable Warehouse_Information_By_EstimateItemID(int CompanyID, long EstimateItemID, long EstWarehouseItemID)
        {
            return (new DbEstimate()).Warehouse_Information_By_EstimateItemID(CompanyID, EstimateItemID, EstWarehouseItemID);
        }

        public static string Warehouse_Markup(int CompanyID)
        {
            return (new DbEstimate()).Warehouse_Markup(CompanyID);
        }

        public static string warehouse_perquantity_select(int CompanyID, string WarehouseType, long WarehouseTypeID)
        {
            return (new DbEstimate()).warehouse_perquantity_select(CompanyID, WarehouseType, WarehouseTypeID);
        }

        public static void zone_markup_update(int CompanyID, long EstCalculationID, double Markup)
        {
            (new DbEstimate()).zone_markup_update(CompanyID, EstCalculationID, Markup);
        }
        public static Int32 Create_proof(int CompanyID, long EstimateID, long ProofID, DateTime ProofDate,int StatusID)
        {
          return  (new DbEstimate()).Create_proof(CompanyID, EstimateID, ProofID,ProofDate,StatusID);
        }
        public static void Create_proof_detail(int EstimateItemID, long AttachmentId, long ProofID,Int32 UserId,DateTime CreatedDate,int CompanyID,int ItemStatus)
        {
             (new DbEstimate()).Create_proof_detail(EstimateItemID, AttachmentId, ProofID, UserId,CreatedDate,CompanyID,ItemStatus);
        }
        public static void AddProofItemDetails(long ProofID,long EstimateItemID, DateTime CreatedDate,int StatusID)
        {
            (new DbEstimate()).AddProofItemDetails(ProofID,EstimateItemID ,CreatedDate,StatusID);
        }
        public static DataTable GetProofEstimateItemIDs(long ProofID)
        {
           return (new DbEstimate()).GetProofEstimateItemIDs(ProofID);
        }
        public static DataTable Get_ProofAprovedFilesDetail(int ProofID, long EstimateItemID)
        {
            return (new DbEstimate()).Get_ProofAprovedFilesDetail(ProofID, EstimateItemID);
        }
        public static DataTable Get_ProofAttachments(int ProofID, long EstimateItemID,long ProofItemID)
        {
            return (new DbEstimate()).Get_ProofAttachments(ProofID, EstimateItemID,ProofItemID);
        }
        public static DataTable Get_Proof_History(Int32 AttachmentID)
        {
            return (new DbEstimate()).Get_Proof_History(AttachmentID);
        }

        public static DataTable GetProofAttachmentID(long EstimateID, Int32 UserId, int Number, int EstimateItemID)
        {
            return (new DbEstimate()).GetProofAttachmentID(EstimateID, UserId, Number, EstimateItemID);
        }
        public static DataTable GetDefaultSelectedImage(int ProofID, long EstimateItemID, long ProofItemID)
        {
            return (new DbEstimate()).GetDefaultSelectedImage(ProofID, EstimateItemID,ProofItemID);
        }
        public static DataTable ProofHistoryDetails(int ProofID, long EstimateItemID, int AttachmentID)
        {
            return (new DbEstimate()).ProofHistoryDetails(ProofID, EstimateItemID, AttachmentID);
        }
        public static DataTable ProofAttachmentHistory(int ProofID, long EstimateItemID, int AttachmentID,long ProofItemID)
        {
            return (new DbEstimate()).GetProofAttachmentHistory(ProofID, EstimateItemID, AttachmentID,ProofItemID);
        }
        public static DataTable ProofSelectedAttachmentHistory(int ProofID, long EstimateItemID, int AttachmentID)
        {
            return (new DbEstimate()).ProofSelectedAttachmentHistory(ProofID, EstimateItemID, AttachmentID);
        }
        public static DataTable ProofSelectedAttachmentImage(int ProofID, long EstimateItemID, int AttachmentID)
        {
            return (new DbEstimate()).ProofSelectedAttachmentImage(ProofID, EstimateItemID, AttachmentID);
        }
        public static string Get_Proof_Number(Int32 ProofID)
        {
            return (new DbEstimate()).Get_Proof_Number(ProofID);
        }
        public static DataTable Get_Proofed_Attachment(long EstimateItemID)
        {
            return (new DbEstimate()).Get_Proofed_Attachment(EstimateItemID);
        }
        public static DataTable Get_Proofed_WebLink(long EstimateItemID)
        {
            return (new DbEstimate()).Get_Proofed_WebLink(EstimateItemID);
        }
        public static int Get_AttachmentCount(long EstimateItemID)
        {
            return (new DbEstimate()).Get_AttachmentCount(EstimateItemID);
        }
        public static void InsertProofLastCounter(int CompanyID)
        {
            new DbEstimate().InsertProofLastCounter(CompanyID);
        }

        public static string GetContactFirstName(string contactID)
        {
            return (new DbEstimate()).GetContactFirstName(contactID);
        }

        public static DataTable GetProofStatusAll(int CompanyID)
        {
            return (new DbEstimate()).GetProofStatusAll(CompanyID);
        }

        public static void Update_ProofUserEmail(int ProofID, string Email)
        {
            (new DbEstimate()).UpdateProofUserEmail(ProofID, Email);
        }
        public static string GetEstimateID(int CompanyID,long JobID)
        {
            return (new DbEstimate()).GetEstimateID(CompanyID,JobID);
        }
        public static string GetEstimateCustomerID(int CompanyID, long EstimateID)
        {
            return (new DbEstimate()).GetEstimateCustomerID(CompanyID, EstimateID);
        }
        public static string GetProofAttachmentCount(long EstimateID,string PageType,long JobID)
        {
            return (new DbEstimate()).GetProofAttachmentCount(EstimateID,PageType,JobID);
        }
        public static void UpdateProofHistory(int AttachmentID, int EstimateItemID, int ProofID, int UserID, bool IsDropdownDisplay,int UpdatedAttachmentID,int ProofItemID)
        {
             (new DbEstimate()).UpdateProofHistory(AttachmentID, EstimateItemID, ProofID, UserID, IsDropdownDisplay,UpdatedAttachmentID,ProofItemID);
        }

        public static void InsertProofHistory(int AttachmentID, int EstimateItemID, int ProofID, int UserID,int ProofItemID)
        {
            (new DbEstimate()).InsertProofHistory(AttachmentID, EstimateItemID, ProofID, UserID,ProofItemID);
        }

        public static DataTable GetAPIOrderID(long EstimateID)
        {
            return (new DbEstimate()).GetAPIOrderID(EstimateID);
        }
        public static DataTable GetStatusDetails(int statusID)
        {
            return (new DbEstimate()).GetStatusDetails(statusID);
        }
        public static DataTable GetProofViewDefault(int CompanyID,int UserID)
        {
            return (new DbEstimate()).GetProofViewDefault(CompanyID,UserID);
        }
        public static void UpdateProofApproval(bool IsChecked, int ProofItemID,string ApproverName,string ApproverEmail)
        {
            (new DbEstimate()).UpdateProofApproval(IsChecked, ProofItemID,ApproverName,ApproverEmail);
        }
        public static DataTable GetProofApproval(long ProofItemID)
        {
            return (new DbEstimate()).GetProofApproval(ProofItemID);
        }
        public static DataTable GetAttachmentByAttachmentID(long AttachmentID, string PageType,long EstimateID)
        {
            return (new DbEstimate()).GetAttachmentByAttachmentID(AttachmentID,PageType,EstimateID);
        }

        public static DataTable GetUpdateJobLockingOrUnlockingStatus(long JobID, long CompanyID, string Event)
        {
            return (new DbEstimate()).GetUpdateJobLockingOrUnlockingStatus(JobID, CompanyID, Event);
        }
        public static string GetProofStatus(int ProofID, long EstimateItemID, int AttachmentID)
        {
            return (new DbEstimate()).GetProofStatus(ProofID, EstimateItemID, AttachmentID);
        }
        public static bool UpdateProofStatus(int ProofID, long EstimateItemID, int AttachmentID, string Comment, string Status, bool IsTermsAndConditions)
        {
            return (new DbEstimate()).UpdateProofStatus(ProofID, EstimateItemID, AttachmentID, Comment, Status, IsTermsAndConditions);
        }
        public static bool UpdateProofItemStatus(int ProofID, long EstimateItemID, string Status)
        {
            return (new DbEstimate()).UpdateProofItemStatus(ProofID, EstimateItemID, Status);
        }
        public static DataTable Get_SecondApprover_EmailAndName(int ProofItemID)
        {
            return (new DbEstimate()).Get_SecondApprover_EmailAndName(ProofItemID);
        }
        public static int GetApprovalCount(int ProofID, long EstimateItemID, int AttachmentID,int ProofItemID)
        {
            return (new DbEstimate()).GetApprovalCount(ProofID, EstimateItemID, AttachmentID, ProofItemID);
        }
        public static bool InsertProofAttachmentHistory(int ProofID, long EstimateItemID,int ProofItemID, int AttachmentID, string Comment, string Status,int UserID,int CompanyID)
        {
            return (new DbEstimate()).InsertProofAttachmentHistory(ProofID, EstimateItemID, ProofItemID, AttachmentID, Comment, Status,UserID, CompanyID);
        }

        public static DataTable Internal_Proof_Email_Select(int StatusID, int companyID, string TemplateType, int ProofID)
        {
            return (new DbEstimate()).Internal_Proof_Email_Select(StatusID, companyID, TemplateType, ProofID);
        }
        public static void SaveEstimateItemFTPAddress(int CompanyID, long EstimateItemID, string FTPAddress,string FTPStatus, string FTPSource)
        {
            (new DbEstimate()).SaveEstimateItemFTPAddress(CompanyID, EstimateItemID, FTPAddress, FTPStatus, FTPSource);
        }
    }
}