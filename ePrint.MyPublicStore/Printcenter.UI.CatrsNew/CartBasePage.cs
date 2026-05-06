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

		public static void Cart_AdditionalOptions_Delete(long StoreUserID)
		{
			Carts.Cart_AdditionalOptions_Delete(StoreUserID);
		}

		public static DataTable CategoryName_SubCategory_Select_for_Navigation(int PriceCatalogueID)
		{
			return Carts.CategoryName_SubCategory_Select_for_Navigation(PriceCatalogueID);
		}

		public static void Delete_CartAdditionalItems(long CartItemID)
		{
			Carts.Delete_CartAdditionalItems(CartItemID);
		}

		public static void Delete_CartItem(string CookieID, long StoreUserID, long CartID, long CartItemID)
		{
			Carts.Delete_CartItem(CookieID, StoreUserID, CartID, CartItemID);
		}

		public static DataTable eStore_Visibility_Settings_Select(int companyId, int accountId)
		{
			return Carts.eStore_Visibility_Settings_Select(companyId, accountId);
		}

		public static DataSet Get_BackOrderStock_Check(string CartItemIDs)
		{
			return Carts.Get_BackOrderStock_Check(CartItemIDs);
		}

		public static DataTable Get_HGroupDetails(long Gid, long templateid)
		{
			return Carts.Get_HorizontalGroup(Gid, templateid);
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

		public static DataTable GetGroupRunUintPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode)
		{
			return Carts.GetGroupRunUintPrice(ProductID, TotalQty, CartItemId, CouponCode);
		}

		public static long Insert_into_Cart(string CookieID, long UserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping, bool IsDeliveryCost)
		{
			return Carts.Insert_into_Cart(CookieID, UserID, CartTotalPrice, CartTax, CartShipping, IsDeliveryCost);
		}
		//public static void Update_Cart(string CookieID, long CartID, long CartItemID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		//{
		//	Carts.Update_Cart(CookieID, CartID, CartItemID, StoreUserID, CartTotalPrice, CartTax, CartShipping);
		//}
		public static long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType)
		{
			return Carts.Insert_into_CartAdditionalItems(CartItemID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, ParentWebOtherCostID, WebOtherCostType);
		}

		public static long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, decimal Height, decimal Width, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long MainProductID, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			return Carts.Insert_into_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, Height, Width, OriginalFileName1, OriginalFileName2, OriginalFileName3, MainProductID, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static long Insert_into_CartItem_EditableProd(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, long MainProductID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			return Carts.Insert_into_CartItem_EditableProd(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, Tax, MainPriceExcMarkup, TaxID, MainProductID, OriginalFileName1, OriginalFileName2, OriginalFileName3, eprintDocumentName_Report, eprintDocumentName1_Report, eprintDocumentName2_Report);
		}

		public static void Insert_To_CartAdditionalOptions(long StoreUserID, string SessionID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, int CartAdditionalTaxID, decimal CartAdditionalTaxPercentage, decimal CartAdditionalTaxValue)
		{
			Carts.Insert_To_CartAdditionalOptions(StoreUserID, SessionID, OptionID, Formula, Markup, TotalPrice, SelectedID, SelectedValue, SelectedPrice, MarkUpValue, SortOrderNo, CartAdditionalTaxID, CartAdditionalTaxPercentage, CartAdditionalTaxValue);
		}

		public static long Product_Exists_Check(int ProductID)
		{
			return Carts.Product_Exists_Check(ProductID);
		}

		public static DataTable Select_ArtworkFile(long CartItemID, long CartID, string type)
		{
			return Carts.Select_ArtworkFile(CartItemID, CartID, type);
		}

		public static DataTable Select_CartAdditionalItems(long CartItemID)
		{
			return Carts.Select_CartAdditionalItems(CartItemID);
		}

		public static DataTable Select_CartAdditionalOptions(string SessionID, long StoreUserID, string type)
		{
			return Carts.Select_CartAdditionalOptions(SessionID, StoreUserID, type);
		}

		public static DataTable Select_CartItems(string CookieID, string type, long StoreUserID)
		{
			return Carts.Select_CartItems(CookieID, type, StoreUserID);
		}

		public static DataTable Select_CartItems_Paypal(long StoreUserID, string MultipleCartID)
		{
			return Carts.Select_CartItems_Paypal(StoreUserID, MultipleCartID);
		}

		public static string Select_MainProductName(long ProductID)
		{
			return Carts.Select_MainProductName(ProductID);
		}

		public static DataSet Select_TemplateID(long PriceCatalogueID)
		{
			return Carts.Select_TemplateID(PriceCatalogueID);
		}

		public static DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
		{
			return Carts.ShoppingCart_AdditionalOption_Select(CompanyID, AccountID, IsVisibleToCart);
		}

		public static void Update_Cart(string CookieID, long CartID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		{
			Carts.Update_Cart(CookieID, CartID, StoreUserID, CartTotalPrice, CartTax, CartShipping);
		}

		public static void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
		{
			Carts.Update_Cart_StoreUserID(CookieID, StoreUserID);
		}

		public static void Update_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal TaxPercent, decimal MainPriceExcMarkup, long TaxID)
		{
			Carts.Update_CartItem(CartID, ProductID, JobName, Quantity, UnitPrice, eprintDocumentName, eprintDocumentName1, eprintDocumentName2, MainTotalPriceIncMarkup, TaxPercent, MainPriceExcMarkup, TaxID);
		}

		public static void Update_CartItems_JobName(long CartItemID, string JobName)
		{
			Carts.Update_CartItems_JobName(CartItemID, JobName);
		}

		public static void Update_PDFNameC(long CartitemID, string PDFName, string ImageName, string Previewtype, string JobName)
		{
			Carts.Update_PDFNameCart(CartitemID, PDFName, ImageName, Previewtype, JobName);
		}

		public static void Update_PDFNameP(long CartitemID, string PDFName, string ImageName, string Previewtype)
		{
			Carts.Update_PDFNamePreview(CartitemID, PDFName, ImageName, Previewtype);
		}

		public static void Update_SaveName_Status(long CartitemID, string PDFName, string ImageName, string PreviewType)
		{
			Carts.ToUpdate_SaveStatus(CartitemID, PDFName, ImageName, PreviewType);
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
		
	}
}