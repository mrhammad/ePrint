using Printcenter.BusinessAccessLayer.Carts;
using System;
using System.Data;

namespace Printcenter.UI.CatrsNew
{
	public class CartBasePage
	{
		public CartBasePage()
		{
		}

		public static DataTable ArtworkFile_Cart_Order_Select(long CartItemID, long CartorOrderItem_ID, long OrderID, string Type)
		{
			return Carts.ArtworkFile_Cart_Order_Select(CartItemID, CartorOrderItem_ID, OrderID, Type);
		}

		public static void Cart_AdditionalOptions_Delete(long StoreUserID)
		{
			Carts.Cart_AdditionalOptions_Delete(StoreUserID);
		}

		public static DataTable default_settings(int CompanyID, int AccountID)
		{
			return Carts.default_settings(CompanyID, AccountID);
		}

		public static void Delete_CartAdditionalItems(long CartItemID)
		{
			Carts.Delete_CartAdditionalItems(CartItemID);
		}

		public static void Delete_CartItem(string CookieID, long StoreUserID, long CartID)
		{
			Carts.Delete_CartItem(CookieID, StoreUserID, CartID);
		}

		public static void Delete_CartItem_B2B(long CartItemID, long CartID)
		{
			Carts.Delete_CartItem_B2B(CartItemID, CartID);
		}

		public static DataSet Get_BackOrderStock_Check(string CartItemIDs)
		{
			return Carts.Get_BackOrderStock_Check(CartItemIDs);
		}

		public static DataTable Get_CartItemCount(long StoreUserID)
		{
			return Carts.Get_CartItemCount(StoreUserID);
		}

		public static DataTable Get_Edit_Profile_Approval_Pending(string Email, long AccountID)
		{
			return Carts.Get_Edit_Profile_Approval_Pending(Email, AccountID);
		}

		public static DataTable Get_HGroupDetails(long Gid, long templateid)
		{
			return Carts.Get_HorizontalGroup(Gid, templateid);
		}

		public static DataTable Get_pendingApprovalUser(string Email, long AccountID)
		{
			return Carts.Get_pendingApprovalUser(Email, AccountID);
		}

		public static DataTable Get_Status(long CartitemID)
		{
			return Carts.Get_Cartstatus(CartitemID);
		}

		public static DataTable Get_VGroupDetails(long Gid, long templateid)
		{
			return Carts.Get_VerticalGroup(Gid, templateid);
		}

		public static DataSet GetAllCartDetails(long CartID)
		{
			return Carts.GetAllCartDetails(CartID);
		}

		public static DataTable GetGroupRunUnitPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode, long AccountID)
		{
			return Carts.GetGroupRunUnitPrice(ProductID, TotalQty, CartItemId, CouponCode, AccountID);
		}

		public static long Insert_into_Cart(string CookieID, long UserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping, bool IsDeliveryCost)
		{
			return Carts.Insert_into_Cart(CookieID, UserID, CartTotalPrice, CartTax, CartShipping, IsDeliveryCost);
		}

        public static DataTable Check_Delivery_Cart()
        {
            return Carts.Check_Delivery_Cart();
        }

        public static void Update_ZipTax_Cart(decimal Tax)
        {
            Carts.Update_ZipTax_Cart(Tax);
        }

        public static void Update_DefaultTax_Cart(int CompanyID)
        {
            Carts.Update_DefaultTax_Cart(CompanyID);
        }

        public static long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType,string FreeTextQuestionLong = "")
		{
			return Carts.Insert_into_CartAdditionalItems(CartItemID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType,FreeTextQuestionLong);
		}

		public static long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string Status, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long Order_behalf_DeptID, long Order_Behalf_UserID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, long TemplateImportID, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			return Carts.Insert_into_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, Status, OriginalFileName1, OriginalFileName2, OriginalFileName3, Order_behalf_DeptID, Order_Behalf_UserID, IsStockReplenish, CampaignID, Height, Width, TemplateImportID, MainProductId, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static void Insert_NotesOnEditItem(long CartItemID, long StoreUserID)
		{
			Carts.Insert_NotesOnEditItem(CartItemID, StoreUserID);
		}

		public static void Insert_To_CartAdditionalOptions(long StoreUserID, string SessionID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, int CartAdditionalTaxID, decimal CartAdditionalTaxPercentage, decimal CartAdditionalTaxValue)
		{
			Carts.Insert_To_CartAdditionalOptions(StoreUserID, SessionID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, CartAdditionalTaxID, CartAdditionalTaxPercentage, CartAdditionalTaxValue);
		}

		public static DataTable JobInvoice_ArtworkFile_Select(long CartItemID, string OrdJobInvid)
		{
			return Carts.JobInvoice_ArtworkFile_Select(CartItemID, OrdJobInvid);
		}

		public static DataTable JobInvoice_ArtworkFile_Select_splititem(long CartItemID, long OrderItemID)
		{
			return Carts.JobInvoice_ArtworkFile_Select_splititem(CartItemID, OrderItemID);
		}

		public static long Product_Exists_Check(int ProductID)
		{
			return Carts.Product_Exists_Check(ProductID);
		}

        public static DataTable settings_Product_Matrix_EnableCheck(long PriceCatalogueID)
        {
            return Carts.settings_Product_Matrix_EnableCheck(PriceCatalogueID);
        }

		public static DataTable Select_CartAdditionalItems(long CartItemID)
		{
			return Carts.Select_CartAdditionalItems(CartItemID);
		}

		public static DataTable Select_CartAdditionalOptions(string SessionID, long StoreUserID, string type)
		{
			return Carts.Select_CartAdditionalOptions(SessionID, StoreUserID, type);
		}

        public static DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            return Carts.PC_select_DeliveryCost_Settings(CompanyID, AccountID);
        }

        public static DataTable Select_CartItems(string CookieID, string type, long StoreUserID)
		{
			return Carts.Select_CartItems(CookieID, type, StoreUserID);
		}

        public static void DeliveryCostAdjustments_CartItems()
        {
            Carts.DeliveryCostAdjustments_CartItems();
        }

        public static DataTable Select_ShipRates_Detail(int CompanyID, int AccountID)
        {
            return Carts.Select_ShipRates_Detail(CompanyID, AccountID);
        }

        public static DataTable Select_NonShipRates_Detail()
        {
            return Carts.Select_NonShipRates_Detail();
        }

        public static DataTable Select_CartItemsStoreCredit(long StoreUserID, long CartItemID)
		{
			return Carts.Select_CartItemsStoreCredit(StoreUserID, CartItemID);
		}
		public static void Save_CartItemsStoreCredit(long CartItemID, double TaxAmout, double UnitPrice, Double CartItemTotal)
		{
			 Carts.Save_CartItemsStoreCredit(CartItemID, TaxAmout, UnitPrice, CartItemTotal);
		}

        public static DataTable Select_DeliveryCost_SEItemsDetail(string AccountID)
        {
            return Carts.Select_DeliveryCost_SEItemsDetail(AccountID);
        }

        public static void Update_StoreCredit(long StoreUserID, double StoreCredit)
		{
			Carts.Update_StoreCredit(StoreUserID, StoreCredit);
		}

        public static DataTable Select_CBMCartItems_DC(string CartID)
        {
            return Carts.Select_CBMCartItems_DC(CartID);
        }

        public static DataTable Select_CartItems_Paypal(long StoreUserID, string MultipleCartID)
		{
			return Carts.Select_CartItems_Paypal(StoreUserID, MultipleCartID);
		}

		public static string Select_MainProductName(long MainProductID)
		{
			return Carts.Select_MainProductName(MainProductID);
		}

        public static bool Select_IsZip2taxEnabled(int CompanyID, long AccountID)
        {
            return Carts.Select_IsZip2taxEnabled(CompanyID, AccountID);
        }

        public static DataTable Setting_ZiptoTax_Select(long AccountID, long CompanyID)
        {
            return Carts.Setting_ZiptoTax_Select(AccountID, CompanyID);
        }

		public static void Setting_ZiptoTax_Update(long AccountID, long CompanyID, string Url, string Response)
		{
			Carts.Setting_ZiptoTax_Update(AccountID, CompanyID, Url, Response);
		}

		public static void Update_DeliveryCost_ItemsDetail(int CompanyID, int DeliveryCostID, Double DeliveryCost)
        {
            Carts.Update_DeliveryCost_ItemsDetail(CompanyID, DeliveryCostID, DeliveryCost);
        }

        public static void Update_Rates_NonSE(string DeliveryCostTitle, Double DeliveryCost)
        {
            Carts.Update_Rates_NonSE(DeliveryCostTitle, DeliveryCost);
        }

        public static DataTable Select_MultipleCartItems(string CookieID, string type, long StoreUserID, string strMultipleCartID)
		{
			return Carts.Select_MultipleCartItems(CookieID, type, StoreUserID, strMultipleCartID);
		}

		public static DataTable Select_MyDesignCartItems(string CookieID, string type, long StoreUserID)
		{
			return Carts.Select_MyDesignCartItems(CookieID, type, StoreUserID);
		}

        public static DataTable Select_ShipRates_SEItemsDetail(string Carrierid)
        {
            return Carts.Select_ShipRates_SEItemsDetail(Carrierid);
        }

        public static DataTable Select_ShipEngine_ErrDetail(string AccountID)
        {
            return Carts.Select_ShipEngine_ErrDetail(AccountID);
        }

        public static void Update_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            Carts.Update_ShipRates_SEItemsDetail(Rateid, Carrierid, CarrierFriendlyName, CarrierCode, ServiceType, ServiceCode, DeliveryCost);
        }

        public static void Insert_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            Carts.Insert_ShipRates_SEItemsDetail(Rateid, Carrierid, CarrierFriendlyName, CarrierCode, ServiceType, ServiceCode, DeliveryCost);
        }

        public static void Delete_ShipRates_SEItemsDetail(string Carrierid)
        {
            Carts.Delete_ShipRates_SEItemsDetail(Carrierid);
        }

        public static void Update_ShipEngine_ErrDetail(string Carrierid , string ErrDesc)
        {
            Carts.Update_ShipEngine_ErrDetail(Carrierid, ErrDesc);
        }

        public static void ShipEnginecall_Details_Insert(string Carrierid, string AccountID, bool IsDeleted, string PayLoadDetail, string ErrorDetail)
        {
            Carts.ShipEnginecall_Details_Insert(Carrierid, AccountID, IsDeleted, PayLoadDetail, ErrorDetail);
        }

        public static void Update_ShipEngine_PayloadDetail(string Carrierid, string PayloadDetail)
        {
            Carts.Update_ShipEngine_PayloadDetail(Carrierid, PayloadDetail);
        }

        public static void Delete_ShipRates(int CompanyID, int AccountID)
        {
            Carts.Delete_ShipRates(CompanyID, AccountID);
        }

        public static DataTable Select_OrderDetails(long CartItemID)
		{
			return Carts.Select_OrderDetails(CartItemID);
		}

		public static DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
		{
			return Carts.ShoppingCart_AdditionalOption_Select(CompanyID, AccountID, IsVisibleToCart);
		}

		public static void Update_Cart(string CookieID, long CartID, long CartItemID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		{
			Carts.Update_Cart(CookieID, CartID, CartItemID, StoreUserID, CartTotalPrice, CartTax, CartShipping);
		}

		public static void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
		{
			Carts.Update_Cart_StoreUserID(CookieID, StoreUserID);
		}

		public static void Update_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal MarkUp, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
		{
			Carts.Update_CartAdditionalItems(CartItemID, OptionID, Formula, MarkUp, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType, FreeTextQuestionLong);
		}

		public static void Update_CartItem(long CartID, long CartItemID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long OnBehalfUserID, long OnBehalfDeptID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			Carts.Update_CartItem(CartID, CartItemID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, OriginalFileName1, OriginalFileName2, OriginalFileName3, OnBehalfUserID, OnBehalfDeptID, IsStockReplenish, CampaignID, Height, Width, MainProductId, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static void Update_CartItems_JobName(long CartItemID, string JobName)
		{
			Carts.Update_CartItems_JobName(CartItemID, JobName);
		}

		public static void Update_OrderMarkup(long CartItemID)
		{
			Carts.Update_OrderMarkup(CartItemID);
		}

        public static string Select_DefaultFromAddress()
        {
            return Carts.Select_DefaultFromAddress();
        }

        public static string Select_DefaultMarkup(int CompanyID)
        {
            return Carts.Select_DefaultMarkup(CompanyID);
        }

        public static void Update_PDFNameC(long CartitemID, string PDFName, string ImagesName, string PreviewType, string JobName)
		{
			Carts.Update_PDFNameCart(CartitemID, PDFName, ImagesName, PreviewType, JobName);
		}

        public static void Update_Delivery_Cart(long CartID, decimal CartTotalPrice, string DeliveryCostDesc)
        {
            Carts.Update_Delivery_Cart(CartID, CartTotalPrice, DeliveryCostDesc);
        }

        public static void Update_Delivery_CartItem(long CartItemID, decimal CartTotalPrice)
        {
            Carts.Update_Delivery_CartItem(CartItemID, CartTotalPrice);
        }

        public static void Update_PDFNameP(long CartitemID, string PDFName, string ImagesName, string PreviewType)
		{
			Carts.Update_PDFNamePreview(CartitemID, PDFName, ImagesName, PreviewType);
		}

		public static void Update_SaveName_Status(long CartitemID, string PDFName, string ImagesName)
		{
			Carts.ToUpdate_SaveStatus(CartitemID, PDFName, ImagesName);
		}

        public static void Update_Cart_TotalWithDc(long CartID, decimal DeliveryCost, string DeliveryCostDesc)
        {
            Carts.Update_Cart_TotalWithDc(CartID, DeliveryCost, DeliveryCostDesc);
        }

        public static DataTable Update_Select_OtherCostAdditional_Onoptionid(long CartItemID, long OptionID, long ProductID, decimal TotQty, long CartAdditionalItemID)
		{
			return Carts.Update_Select_OtherCostAdditional_Onoptionid(CartItemID, OptionID, ProductID, TotQty, CartAdditionalItemID);
		}

		public static void update_singlequestion_additionaloptions(long CartItemID, long CartAdditionalItemID, string Formula, double TotalPrice)
		{
			Carts.update_singlequestion_additionaloptions(CartItemID, CartAdditionalItemID, Formula, TotalPrice);
		}

		public static void UpdateSingleQuestionvalues(long WebOtherCostID, long Questionvalue)
		{
			Carts.UpdateSingleQuestionvalues(WebOtherCostID, Questionvalue);
		}

        public static DataTable GetCartItemStatusForApproval(Int32 CartItemId)
        {
            return (new Carts()).GetCartItemStatusForApproval(CartItemId);
        }
        public static void Product_CataloguePdfNameWaterMark_Update(Int64 PriceCatalogueID, string WaterMarkPdfName)
        {

            Carts.Product_CataloguePdfNameWaterMark_Update(PriceCatalogueID, WaterMarkPdfName);
        }
		public static DataTable Select_B2B_CartItem(int CartItemID, int ProductID)
		{
			return Carts.Select_B2B_CartItem(CartItemID, ProductID);
		}
		public static DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
		{
			return Carts.OrderMangerOptions_Select(CompanyID, AccountID);
		}
	}
}