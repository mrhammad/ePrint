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

		public static void Cart_AdditionalOptions_Delete(long StoreUserID)
		{
			(new DBCart()).Cart_AdditionalOptions_Delete(StoreUserID);
		}

		public static DataTable CategoryName_SubCategory_Select_for_Navigation(int PriceCatalogueID)
		{
			return (new DBCart()).CategoryName_SubCategory_Select_for_Navigation(PriceCatalogueID);
		}

		public static void Delete_CartAdditionalItems(long CartItemID)
		{
			(new DBCart()).Delete_CartAdditionalItems(CartItemID);
		}

		public static void Delete_CartItem(string CookieID, long StoreUserID, long CartID, long CartItemID)
		{
			(new DBCart()).Delete_CartItem(CookieID, StoreUserID, CartID, CartItemID);
		}

		public static DataTable eStore_Visibility_Settings_Select(int companyId, int accountId)
		{
			return (new DBCart()).eStore_Visibility_Settings_Select(companyId, accountId);
		}

		public static DataSet Get_BackOrderStock_Check(string CartItemIDs)
		{
			return (new DBCart()).Get_BackOrderStock_Check(CartItemIDs);
		}

		public static DataTable Get_Cartstatus(long CartitemID)
		{
			return (new DBCart()).Select_Status(CartitemID);
		}

		public static DataTable Get_HorizontalGroup(long Gid, long templateid)
		{
			return (new DBCart()).GetHorizontalGrpDetail(Gid, templateid);
		}

		public static DataTable Get_VerticalGroup(long Gid, long templateid)
		{
			return (new DBCart()).GetVerticalGrpDetail(Gid, templateid);
		}

		public static DataSet GetAllCartDetails(long CartID)
		{
			return (new DBCart()).GetAllCartDetails(CartID);
		}

		public static DataTable GetGroupRunUintPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode)
		{
			return (new DBCart()).GetGroupRunUintPrice(ProductID, TotalQty, CartItemId, CouponCode);
		}

		public static long Insert_into_Cart(string CookieID, long UserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping, bool IsDeliveryCost)
		{
			return (new DBCart()).Insert_into_Cart(CookieID, UserID, CartTotalPrice, CartTax, CartShipping, IsDeliveryCost);
		}

		public static long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType)
		{
			DBCart dBCart = new DBCart();
			return dBCart.Insert_into_CartAdditionalItems(CartItemID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType);
		}

		public static long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, decimal Height, decimal Width, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long MainProductID, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			DBCart dBCart = new DBCart();
			return dBCart.Insert_into_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, Height, Width, OriginalFileName1, OriginalFileName2, OriginalFileName3, MainProductID, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static long Insert_into_CartItem_EditableProd(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, long MainProductID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			DBCart dBCart = new DBCart();
			return dBCart.Insert_into_CartItem_EditableProd(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, MainProductID, OriginalFileName1, OriginalFileName2, OriginalFileName3, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static void Insert_To_CartAdditionalOptions(long StoreUserID, string SessionID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, int CartAdditionalTaxID, decimal CartAdditionalTaxPercentage, decimal CartAdditionalTaxValue)
		{
			DBCart dBCart = new DBCart();
			dBCart.Insert_To_CartAdditionalOptions(StoreUserID, SessionID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, CartAdditionalTaxID, CartAdditionalTaxPercentage, CartAdditionalTaxValue);
		}

		public static long Product_Exists_Check(int ProductID)
		{
			return (new DBCart()).Product_Exists_Check(ProductID);
		}

		public static DataTable Select_ArtworkFile(long CartItemID, long CartID, string type)
		{
			return (new DBCart()).Select_ArtworkFile(CartItemID, CartID, type);
		}

		public static DataTable Select_CartAdditionalItems(long CartItemID)
		{
			return (new DBCart()).Select_CartAdditionalItems(CartItemID);
		}

		public static DataTable Select_CartAdditionalOptions(string SessionID, long StoreUserID, string type)
		{
			return (new DBCart()).Select_CartAdditionalOptions(SessionID, StoreUserID, type);
		}

		public static DataTable Select_CartItems(string CookieID, string type, long StoreUserID)
		{
			return (new DBCart()).Select_CartItems(CookieID, type, StoreUserID);
		}

		public static DataTable Select_CartItems_Paypal(long StoreUserID, string MultipleCartID)
		{
			return (new DBCart()).Select_CartItems_Paypal(StoreUserID, MultipleCartID);
		}

		public static string Select_MainProductName(long ProductID)
		{
			return (new DBCart()).Select_MainProductName(ProductID);
		}

		public static DataSet Select_TemplateID(long PriceCatalogueID)
		{
			return (new DBCart()).Select_TemplateID(PriceCatalogueID);
		}

		public static DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
		{
			return (new DBCart()).ShoppingCart_AdditionalOption_Select(CompanyID, AccountID, IsVisibleToCart);
		}

		public static void ToUpdate_SaveStatus(long CartitemID, string PDFName, string ImageName, string PreviewType)
		{
			(new DBCart()).Update_Savestatus(CartitemID, PDFName, ImageName, PreviewType);
		}

		public static void Update_Cart(string CookieID, long CartID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		{
			(new DBCart()).Update_Cart(CookieID, CartID, StoreUserID, CartTotalPrice, CartTax, CartShipping);
		}

		public static void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
		{
			(new DBCart()).Update_Cart_StoreUserID(CookieID, StoreUserID);
		}

		public static void Update_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal TaxPercent, decimal MainPriceExcMarkup, long TaxID)
		{
			DBCart dBCart = new DBCart();
			dBCart.Update_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, TaxPercent, MainPriceExcMarkup, TaxID);
		}

		public static void Update_CartItems_JobName(long CartItemID, string JobName)
		{
			(new DBCart()).Update_CartItems_JobName(CartItemID, JobName);
		}

		public static void Update_PDFNameCart(long CartitemID, string PDFName, string ImageName, string Previewtype, string JobName)
		{
			(new DBCart()).Update_PDFcartstatus(CartitemID, PDFName, ImageName, Previewtype, JobName);
		}

		public static void Update_PDFNamePreview(long CartitemID, string PDFName, string ImageName, string Previewtype)
		{
			(new DBCart()).Update_PDFPreviewstatus(CartitemID, PDFName, ImageName, Previewtype);
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
	}
}