using Printcenter.DataAccessLayer.Cart;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Carts
{
    public class Carts
    {
        public Carts()
        {
        }

        public static DataTable ArtworkFile_Cart_Order_Select(long CartItemID, long CartorOrderItem_ID, long OrderID, string Type)
        {
            return (new DBCart()).ArtworkFile_Cart_Order_Select(CartItemID, CartorOrderItem_ID, OrderID, Type);
        }

        public static void Cart_AdditionalOptions_Delete(long StoreUserID)
        {
            (new DBCart()).Cart_AdditionalOptions_Delete(StoreUserID);
        }

        public static DataTable default_settings(int CompanyID, int AccountID)
        {
            return (new DBCart()).default_settings(CompanyID, AccountID);
        }

        public static void Delete_CartAdditionalItems(long CartItemID)
        {
            (new DBCart()).Delete_CartAdditionalItems(CartItemID);
        }

        public static void Delete_CartItem(string CookieID, long StoreUserID, long CartID)
        {
            (new DBCart()).Delete_CartItem(CookieID, StoreUserID, CartID);
        }

        public static void Delete_CartItem_B2B(long CartItemID, long CartID)
        {
            (new DBCart()).Delete_CartItem_B2B(CartItemID, CartID);
        }

        public static DataSet Get_BackOrderStock_Check(string CartItemIDs)
        {
            return (new DBCart()).Get_BackOrderStock_Check(CartItemIDs);
        }

        public static DataTable Get_CartItemCount(long StoreUserID)
        {
            return (new DBCart()).Get_CartItemCount(StoreUserID);
        }

        public static DataTable Get_Cartstatus(long CartitemID)
        {
            return (new DBCart()).Select_Status(CartitemID);
        }

        public static DataTable Get_Edit_Profile_Approval_Pending(string Email, long AccountID)
        {
            return (new DBCart()).Get_Edit_Profile_Approval_Pending(Email, AccountID);
        }

        public static DataTable Get_HorizontalGroup(long Gid, long templateid)
        {
            return (new DBCart()).GetHorizontalGrpDetail(Gid, templateid);
        }

        public static DataTable Get_pendingApprovalUser(string Email, long AccountID)
        {
            return (new DBCart()).Get_pendingApprovalUser(Email, AccountID);
        }

        public static DataTable Get_VerticalGroup(long Gid, long templateid)
        {
            return (new DBCart()).GetVerticalGrpDetail(Gid, templateid);
        }

        public static DataSet GetAllCartDetails(long CartID)
        {
            return (new DBCart()).GetAllCartDetails(CartID);
        }

        public static DataTable GetGroupRunUnitPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode, long AccountID)
        {
            return (new DBCart()).GetGroupRunUnitPrice(ProductID, TotalQty, CartItemId, CouponCode, AccountID);
        }

        public static long Insert_into_Cart(string CookieID, long UserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping, bool IsDeliveryCost)
        {
            return (new DBCart()).Insert_into_Cart(CookieID, UserID, CartTotalPrice, CartTax, CartShipping, IsDeliveryCost);
        }

        public static DataTable Check_Delivery_Cart()
        {
            return (new DBCart()).Check_Delivery_Cart();
        }

        public static void Update_ZipTax_Cart(decimal Tax)
        {
            (new DBCart()).Update_ZipTax_Cart(Tax);
        }

        public static void Update_DefaultTax_Cart(int CompanyID)
        {
            (new DBCart()).Update_DefaultTax_Cart(CompanyID);
        }

        public static long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong= "")
        {
            DBCart dBCart = new DBCart();
            return dBCart.Insert_into_CartAdditionalItems(CartItemID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType,FreeTextQuestionLong);
        }

        public static long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string Status, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long Order_behalf_DeptID, long Order_Behalf_UserID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, long TemplateImportID, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
        {
            DBCart dBCart = new DBCart();
            return dBCart.Insert_into_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, Status, OriginalFileName1, OriginalFileName2, OriginalFileName3, Order_behalf_DeptID, Order_Behalf_UserID, IsStockReplenish, CampaignID, Height, Width, TemplateImportID, MainProductId, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
        }

        public static void Insert_NotesOnEditItem(long CartItemID, long StoreUserID)
        {
            (new DBCart()).Insert_NotesOnEditItem(CartItemID, StoreUserID);
        }

        public static void Insert_To_CartAdditionalOptions(long StoreUserID, string SessionID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, int CartAdditionalTaxID, decimal CartAdditionalTaxPercentage, decimal CartAdditionalTaxValue)
        {
            DBCart dBCart = new DBCart();
            dBCart.Insert_To_CartAdditionalOptions(StoreUserID, SessionID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, CartAdditionalTaxID, CartAdditionalTaxPercentage, CartAdditionalTaxValue);
        }

        public static DataTable JobInvoice_ArtworkFile_Select(long CartItemID, string OrdJobInvid)
        {
            return (new DBCart()).JobInvoice_ArtworkFile_Select(CartItemID, OrdJobInvid);
        }

        public static DataTable JobInvoice_ArtworkFile_Select_splititem(long CartItemID, long OrderItemID)
        {
            return (new DBCart()).JobInvoice_ArtworkFile_Select_splititem(CartItemID, OrderItemID);
        }

        public static long Product_Exists_Check(int ProductID)
        {
            return (new DBCart()).Product_Exists_Check(ProductID);
        }

        public static DataTable settings_Product_Matrix_EnableCheck(long PriceCatalogueID)
        {
            return (new DBCart()).settings_Product_Matrix_EnableCheck(PriceCatalogueID);
        }

        public static DataTable Select_CartAdditionalItems(long CartItemID)
        {
            return (new DBCart()).Select_CartAdditionalItems(CartItemID);
        }

        public static DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            return (new DBCart()).PC_select_DeliveryCost_Settings(CompanyID, AccountID);
        }

        public static DataTable Select_CartAdditionalOptions(string SessionID, long StoreUserID, string type)
        {
            return (new DBCart()).Select_CartAdditionalOptions(SessionID, StoreUserID, type);
        }

        public static DataTable Select_ShipRates_Detail(int CompanyID, int AccountID)
        {
            return (new DBCart()).Select_ShipRates_Detail(CompanyID, AccountID);
        }

        public static DataTable Select_NonShipRates_Detail()
        {
            return (new DBCart()).Select_NonShipRates_Detail();
        }

        public static DataTable Select_CartItems(string CookieID, string type, long StoreUserID)
        {
            return (new DBCart()).Select_CartItems(CookieID, type, StoreUserID);
        }

        public static void DeliveryCostAdjustments_CartItems()
        {
            (new DBCart()).DeliveryCostAdjustments_CartItems();
        }
        public static DataTable Select_CartItemsStoreCredit(long StoreUserID, long CartItemID)
        {
            return (new DBCart()).Select_CartItemsStoreCredit(StoreUserID, CartItemID);
        }

        public static DataTable Select_DeliveryCost_SEItemsDetail(string AccountID)
        {
            return (new DBCart()).Select_DeliveryCost_SEItemsDetail(AccountID);
        }

        public static DataTable Select_CBMCartItems_DC(string CartID)
        {
            return (new DBCart()).Select_CBMCartItems_DC(CartID);
        }

        public static void Update_DeliveryCost_ItemsDetail(int CompanyID, int DeliveryCostID, Double DeliveryCost)
        {
            (new DBCart()).Update_DeliveryCost_ItemsDetail(CompanyID, DeliveryCostID, DeliveryCost);
        }

        public static void Update_Rates_NonSE(string DeliveryCostTitle, Double DeliveryCost)
        {
            (new DBCart()).Update_Rates_NonSE(DeliveryCostTitle, DeliveryCost);
        }

        public static DataTable Select_ShipRates_SEItemsDetail(string Carrierid)
        {
            return (new DBCart()).Select_ShipRates_SEItemsDetail(Carrierid);
        }

        public static DataTable Select_ShipEngine_ErrDetail(string AccountID)
        {
            return (new DBCart()).Select_ShipEngine_ErrDetail(AccountID);
        }

        public static void Update_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            (new DBCart()).Update_ShipRates_SEItemsDetail(Rateid, Carrierid, CarrierFriendlyName, CarrierCode, ServiceType, ServiceCode, DeliveryCost);
        }

        public static void Insert_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            (new DBCart()).Insert_ShipRates_SEItemsDetail(Rateid, Carrierid, CarrierFriendlyName, CarrierCode, ServiceType, ServiceCode, DeliveryCost);
        }

        public static void Delete_ShipRates_SEItemsDetail(string Carrierid)
        {
            (new DBCart()).Delete_ShipRates_SEItemsDetail(Carrierid);
        }

        public static void Update_ShipEngine_ErrDetail(string Carrierid, string ErrDesc)
        {
            (new DBCart()).Update_ShipEngine_ErrDetail(Carrierid, ErrDesc);
        }

        public static void ShipEnginecall_Details_Insert(string Carrierid, string AccountID, bool IsDeleted, string PayLoadDetail, string ErrorDetail)
        {
            (new DBCart()).ShipEnginecall_Details_Insert(Carrierid, AccountID, IsDeleted, PayLoadDetail, ErrorDetail);
        }

        public static void Update_ShipEngine_PayloadDetail(string Carrierid, string PayloadDetail)
        {
            (new DBCart()).Update_ShipEngine_PayloadDetail(Carrierid, PayloadDetail);
        }

        public static void Delete_ShipRates(int CompanyID, int AccountID)
        {
            (new DBCart()).Delete_ShipRates(CompanyID, AccountID);
        }

        public static void Save_CartItemsStoreCredit(long CartItemID, double TaxAmout, double UnitPrice, Double CartItemTotal)
        {
             (new DBCart()).Save_CartItemsStoreCredit(CartItemID, TaxAmout, UnitPrice, CartItemTotal);
        }
        public static void Update_StoreCredit(long StoreUserID, double StoreCredit)
        {
            (new DBCart()).Update_StoreCredit(StoreUserID, StoreCredit);
        }
       
        public static DataTable Select_CartItems_Paypal(long StoreUserID, string MultipleCartID)
        {
            return (new DBCart()).Select_CartItems_Paypal(StoreUserID, MultipleCartID);
        }

        public static string Select_MainProductName(long MainProductID)
        {
            return (new DBCart()).Select_MainProductName(MainProductID);
        }

        public static bool Select_IsZip2taxEnabled(int CompanyID, long AccountID)
        {
            return (new DBCart()).Select_IsZip2taxEnabled(CompanyID, AccountID);
        }

        public static DataTable Setting_ZiptoTax_Select(long AccountID, long CompanyID)
        {
            return (new DBCart()).Setting_ZiptoTax_Select(AccountID, CompanyID);
        }

        public static void Setting_ZiptoTax_Update(long AccountID, long CompanyID, string Url, string Response)
        {
            (new DBCart()).Setting_ZiptoTax_Update(AccountID, CompanyID, Url, Response);
        }

        public static DataTable Select_MultipleCartItems(string CookieID, string type, long StoreUserID, string strMultipleCartID)
        {
            return (new DBCart()).Select_MultipleCartItems(CookieID, type, StoreUserID, strMultipleCartID);
        }

        public static DataTable Select_MyDesignCartItems(string CookieID, string type, long StoreUserID)
        {
            return (new DBCart()).Select_MyDesignCartItems(CookieID, type, StoreUserID);
        }

        public static DataTable Select_OrderDetails(long CartItemID)
        {
            return (new DBCart()).Select_OrderDetails(CartItemID);
        }

        public static string Select_DefaultFromAddress()
        {
            return (new DBCart()).Select_DefaultFromAddress();
        }

        public static string Select_DefaultMarkup(int CompanyID)
        {
            return (new DBCart()).Select_DefaultMarkup(CompanyID);
        }

        public static DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
        {
            return (new DBCart()).ShoppingCart_AdditionalOption_Select(CompanyID, AccountID, IsVisibleToCart);
        }

        public static void ToUpdate_SaveStatus(long CartitemID, string PDFName, string ImagesName)
        {
            (new DBCart()).Update_Savestatus(CartitemID, PDFName, ImagesName);
        }

        public static void Update_Cart(string CookieID, long CartID, long CartItemID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
        {
            DBCart dBCart = new DBCart();
            dBCart.Update_Cart(CookieID, CartID, CartItemID, StoreUserID, CartTotalPrice, CartTax, CartShipping);
        }

        public static void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
        {
            (new DBCart()).Update_Cart_StoreUserID(CookieID, StoreUserID);
        }

        public static void Update_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal MarkUp, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
        {
            DBCart dBCart = new DBCart();
            dBCart.Update_CartAdditionalItems(CartItemID, OptionID, Formula, MarkUp, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType, FreeTextQuestionLong);
        }

        public static void Update_Delivery_Cart(long CartID, decimal CartTotalPrice, string DeliveryCostDesc)
        {
            DBCart dBCart = new DBCart();
            dBCart.Update_Delivery_Cart(CartID, CartTotalPrice, DeliveryCostDesc);
        }

        public static void Update_Delivery_CartItem(long CartItemID, decimal CartTotalPrice)
        {
            DBCart dBCart = new DBCart();
            dBCart.Update_Delivery_CartItem(CartItemID, CartTotalPrice);
        }

        public static void Update_CartItem(long CartID, long CartItemID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long OnBehalfUserID, long OnBehyalfDeptID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
        {
            DBCart dBCart = new DBCart();
            dBCart.Update_CartItem(CartID, CartItemID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, OriginalFileName1, OriginalFileName2, OriginalFileName3, OnBehalfUserID, OnBehyalfDeptID, IsStockReplenish, CampaignID, Height, Width, MainProductId, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
        }

        public static void Update_Cart_TotalWithDc(long CartID, decimal DeliveryCost, string DeliveryCostDesc)
        {
            (new DBCart()).Update_Cart_TotalWithDc(CartID, DeliveryCost, DeliveryCostDesc);
        }

        public static void Update_CartItems_JobName(long CartItemID, string JobName)
        {
            (new DBCart()).Update_CartItems_JobName(CartItemID, JobName);
        }

        public static void Update_OrderMarkup(long CartItemID)
        {
            (new DBCart()).Update_OrderMarkup(CartItemID);
        }

        public static void Update_PDFNameCart(long CartitemID, string PDFName, string ImagesName, string PreviewType, string JobName)
        {
            (new DBCart()).Update_PDFcartstatus(CartitemID, PDFName, ImagesName, PreviewType, JobName);
        }

        public static void Update_PDFNamePreview(long CartitemID, string PDFName, string ImagesName, string PreviewType)
        {
            (new DBCart()).Update_PDFPreviewstatus(CartitemID, PDFName, ImagesName, PreviewType);
        }

        public static DataTable Update_Select_OtherCostAdditional_Onoptionid(long CartItemID, long OptionID, long ProductID, decimal TotQty, long CartAdditionalItemID)
        {
            return (new DBCart()).Update_Select_OtherCostAdditional_Onoptionid(CartItemID, OptionID, ProductID, TotQty, CartAdditionalItemID);
        }

        public static void update_singlequestion_additionaloptions(long CartItemID, long CartAdditionalItemID, string Formula, double TotalPrice)
        {
            (new DBCart()).update_singlequestion_additionaloptions(CartItemID, CartAdditionalItemID, Formula, TotalPrice);
        }

        public static void UpdateSingleQuestionvalues(long WebOtherCostID, long Questionvalue)
        {
            (new DBCart()).UpdateSingleQuestionvalues(WebOtherCostID, Questionvalue);
        }

        public DataTable GetCartItemStatusForApproval(Int32 CartItemId)
        {
            return (new DBCart()).GetCartItemStatusForApproval(CartItemId);
        }

        public static void Product_CataloguePdfNameWaterMark_Update(Int64 PriceCatalogueID, string WaterMarkPdfName)
        {
            DBCart dBCart = new DBCart();
            dBCart.Product_CataloguePdfNameWaterMark_Update(PriceCatalogueID, WaterMarkPdfName);
        }
        public static DataTable Select_B2B_CartItem(int CartItemID, int ProductID)
        {
            return (new DBCart()).Select_B2B_CartItem(CartItemID, ProductID);
        }
        public static DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            return (new DBCart()).OrderMangerOptions_Select(CompanyID, AccountID);
        }
    }
}