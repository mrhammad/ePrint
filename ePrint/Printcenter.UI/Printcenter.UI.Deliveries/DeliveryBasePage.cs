using nmsCommon;
using Printcenter.BusinessAccessLayer.Deliveries;
using System;
using System.Data;

namespace Printcenter.UI.Deliveries
{
    public class DeliveryBasePage : BasePage
    {
        public DeliveryBasePage()
        {
        }

        public static long Allcn_Check(long ModuleID)
        {
            return Delivery.Allcn_Check(ModuleID);
        }

        public static void delivery_accounting_code_insert(int CompanyID, long DeliveryID, int AccountCodeID)
        {
            Delivery.delivery_accounting_code_insert(CompanyID, DeliveryID, AccountCodeID);
        }

        public static void delivery_delete(int CompanyID, long DeliveryID)
        {
            Delivery.delivery_delete(CompanyID, DeliveryID);
        }

        public static DataTable Delivery_EmailAuto_DeliveryStatus_Item(long statusid, string templatetype, string isenabled, long DeliveryID, long Companyid)
        {
            return Delivery.Delivery_EmailAuto_DeliveryStatus_Item(statusid, templatetype, isenabled, DeliveryID, Companyid);
        }

        public static DataTable Delivery_EmailStatus_select(int CompanyID, int StatusID, long CheckMailSentJobID)
        {
            return Delivery.Delivery_EmailStatus_select(CompanyID, StatusID, CheckMailSentJobID);
        }

        public static long delivery_insert(long DeliveryID, int CompanyID, long EstimateID, long ItemID, string ItemType, int CustomerID, int AttentionID, string ShippedTo, long DeliveryAddressID, string DelAddressType, string Footer, string Comments, string DeliveryNumber, DateTime DeliveryDate, string RefNo, string OrderNo, bool GoodsDelivered, int CarrierID, int CreatedBy, int StatusID, DateTime ModifiedDate, int ModifiedBy, long CurrentDelNO, string Header, DateTime TodayDate, int DeliveryToClientID, string ConsignmentNumber, string ConsigneeUrl, DateTime ActualDeliveryDate, long CostCentreID, string DeliveryNotePrefix)
        {
            return Delivery.delivery_insert(DeliveryID, CompanyID, EstimateID, ItemID, ItemType, CustomerID, AttentionID, ShippedTo, DeliveryAddressID, DelAddressType, Footer, Comments, DeliveryNumber, DeliveryDate, RefNo, OrderNo, GoodsDelivered, CarrierID, CreatedBy, StatusID, ModifiedDate, ModifiedBy, CurrentDelNO, Header, TodayDate, DeliveryToClientID, ConsignmentNumber, ConsigneeUrl, ActualDeliveryDate, CostCentreID, DeliveryNotePrefix);
        }
        public static long delivery_copy_insert(long DeliveryID, int CompanyID, long EstimateID, long ItemID, string ItemType, int CustomerID, int AttentionID, string ShippedTo, long DeliveryAddressID, string DelAddressType, string Footer, string Comments, string DeliveryNumber, DateTime DeliveryDate, string RefNo, string OrderNo, bool GoodsDelivered, int CarrierID, int CreatedBy, int StatusID, DateTime ModifiedDate, int ModifiedBy, long CurrentDelNO, string Header, DateTime TodayDate, int DeliveryToClientID, string ConsignmentNumber, string ConsigneeUrl, DateTime ActualDeliveryDate, long CostCentreID, string DeliveryNotePrefix)
        {
            return Delivery.delivery_copy_insert(DeliveryID, CompanyID, EstimateID, ItemID, ItemType, CustomerID, AttentionID, ShippedTo, DeliveryAddressID, DelAddressType, Footer, Comments, DeliveryNumber, DeliveryDate, RefNo, OrderNo, GoodsDelivered, CarrierID, CreatedBy, StatusID, ModifiedDate, ModifiedBy, CurrentDelNO, Header, TodayDate, DeliveryToClientID, ConsignmentNumber, ConsigneeUrl, ActualDeliveryDate, CostCentreID, DeliveryNotePrefix);
        }


        public static int delivery_items_count(int CompanyID, long DeliveryID)
        {
            return Delivery.delivery_items_count(CompanyID, DeliveryID);
        }

        public static void Delivery_Make_Archive(int CompanyID, long DeliveryID)
        {
            Delivery.Delivery_Make_Archive(CompanyID, DeliveryID);
        }

        public static DataSet delivery_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Delivery.delivery_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static DataTable delivery_search(int CompanyID, string Para)
        {
            return Delivery.delivery_search(CompanyID, Para);
        }

        public static DataTable delivery_select(int CompanyID, long DeliveryID)
        {
            return Delivery.delivery_select(CompanyID, DeliveryID);
        }

        public static void deliveryitem_delete(int CompanyID, long DeliveryItemID, long DeliveryID)
        {
            Delivery.deliveryitem_delete(CompanyID, DeliveryItemID, DeliveryID);
        }

        public static DataTable deliveryitem_GetDeletedItemValue(int CompanyID, string DeliveryItemID)
        {
            return Delivery.deliveryitem_GetDeletedItemValue(CompanyID, DeliveryItemID);
        }

        public static long deliveryitem_insert(int CompanyID, long DeliveryItemID, long DeliveryID, long EstimateID, long ItemID, string ItemType, string Quantity, string Description, long itemNo, string notes, long RepositionRowNumber, long PriceCatalogueID = 0)
        {
            return Delivery.deliveryitem_insert(CompanyID, DeliveryItemID, DeliveryID, EstimateID, ItemID, ItemType, Quantity, Description, itemNo, notes,  RepositionRowNumber,PriceCatalogueID);
        }

        public static long deliveryitem_insert_withProductID(int CompanyID, long DeliveryItemID, long DeliveryID, long EstimateID, long ItemID, string ItemType, string Quantity, string Description, long PriceCatalogueID)
        {
            return Delivery.deliveryitem_insert_withProductID(CompanyID, DeliveryItemID, DeliveryID, EstimateID, ItemID, ItemType, Quantity, Description, PriceCatalogueID);
        }

        public static DataTable deliveryitem_select(int CompanyID, long DeliveryID)
        {
            return Delivery.deliveryitem_select(CompanyID, DeliveryID);
        }

        public static DataTable deliveryitem_select_splitdelivery(int CompanyID, long EstimateItemId, long EstimateID, string ItemType)
        {
            return Delivery.deliveryitem_select_splitdelivery(CompanyID, EstimateItemId, EstimateID, ItemType);
        }

        public static DataTable deliveryitem_selectdeletedItem(int CompanyID, string DeliveryItemID)
        {
            return Delivery.deliveryitem_selectdeletedItem(CompanyID, DeliveryItemID);
        }

        public static DataTable DeliveryNote_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonCondition)
        {
            return Delivery.DeliveryNote_advance_search(CompanyID, SearchText, ClientID, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonCondition);
        }

        public static void DeliveryOnCheck_Status_Update(int CompanyID, string DeliveryIDs, int StatusID, string Module)
        {
            Delivery.DeliveryOnCheck_Status_Update(CompanyID, DeliveryIDs, StatusID, Module);
        }
        public static DataTable Internal_Delivery_Email_Select(int StatusID, int companyID, string TemplateType,int DeliveryID)
        {
            return Delivery.Internal_Delivery_Email_Select(StatusID, companyID, TemplateType,DeliveryID);
        }

        public static void Delivery_Comments_Update(int commentId, string newComment)
        {
            Delivery.Delivery_Comments_Update(commentId, newComment);
        }
    }
}