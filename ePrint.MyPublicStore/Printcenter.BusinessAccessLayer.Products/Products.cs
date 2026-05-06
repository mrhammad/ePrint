using Printcenter.DataAccessLayer.Products;
using System.Collections.Generic;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Products
{
    public class Products
	{
		public Products()
		{
		}

		public static DataTable AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder, int WebOtherCostID, int ChoiceID)
		{
			return (new DBProducts()).AddOptionsProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder, WebOtherCostID, ChoiceID);
		}

		public static DataTable CoategoryName(int priceCatalogueCategoryID, int CompanyID)
		{
			return (new DBProducts()).CoategoryName(priceCatalogueCategoryID, CompanyID);
		}

		public static int Company_RoundOff_Value(int CompanyID)
		{
			return (new DBProducts()).Company_RoundOff_Value(CompanyID);
		}

		public static DataTable BindTreeView(int CompanyID, long AccountID, int Categoryid, long StoreUserID)
		{
			return (new DBProducts()).BindTreeView(CompanyID, AccountID, Categoryid, StoreUserID);
		}

		public static string DBKeyForTemplate_Select(long AccountID)
		{
			return (new DBProducts()).DBKeyForTemplate_Select(AccountID);
		}

		public static DataTable default_price_for_pack_select(int CompanyID)
		{
			return (new DBProducts()).default_price_for_pack_select(CompanyID);
		}

		public static DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
		{
			return (new DBProducts()).FeaturedProducts_Select(CompanyID, AccountID);
		}

		public static DataTable GetTaxDetails_ByProductCatalogueId(int CompanyId, int ProductcatalogueId)
		{
			return (new DBProducts()).GetTaxDetails_ByProductCatalogueId(CompanyId, ProductcatalogueId);
		}

		public static string IsRightPanelCalc_Enabled(long AccountID)
		{
			return (new DBProducts()).IsRightPanelCalc_Enabled(AccountID);
		}

		public static string MeasurementValue(long CompanyID)
		{
			return (new DBProducts()).MeasurementValue(CompanyID);
		}

		public static DataTable OtherMultiple_Default_Select(long PriceCatalogueID)
		{
			return (new DBProducts()).OtherMultiple_Default_Select(PriceCatalogueID);
		}

		public static DataTable OtherMultiple_product_Select(long PriceCatalogueID, int CompanyID)
		{
			return (new DBProducts()).OtherMultiple_product_Select(PriceCatalogueID, CompanyID);
		}

		public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			return (new DBProducts()).Product_CatalogueQty_Select(PriceCatalogueID);
		}

		public static List<Properties.GetQuantity> Product_CatalogueQty_SelectFor_OtherMultiple(long PriceCatalogueID)
		{
			return (new DBProducts()).Product_CatalogueQty_SelectFor_OtherMultiple(PriceCatalogueID);
		}

		public static DataTable productCategoryImage(int companyID)
		{
			return (new DBProducts()).productCategoryImage(companyID);
		}

		public static DataTable productListImage(int companyID, int priceCatalogueCategoryID, int AccountID)
		{
			return (new DBProducts()).productListImage(companyID, priceCatalogueCategoryID, AccountID);
		}

		public static DataTable productsCategoryList_Select(long CompanyID, long AccountID, long StoreUserID)
		{
			return (new DBProducts()).productsCategoryList_Select(CompanyID, AccountID, StoreUserID);
		}
		public static DataTable TopSubCatName(long CompanyID, int ParentCategoryID)
		{
			return (new DBProducts()).TopSubCatName(CompanyID, ParentCategoryID);
		}

		public static DataTable productsDetails_Select(int PriceCatalogueID)
		{
			return (new DBProducts()).productsDetails_Select(PriceCatalogueID);
		}

		public static DataTable productSearch(int companyID, int AccountID, string searchProducts)
		{
			return (new DBProducts()).productSearch(companyID, AccountID, searchProducts);
		}

		public static DataTable productsList_Select(long CompanyID, long AccountID)
		{
			return (new DBProducts()).productsList_Select(CompanyID, AccountID);
		}

		public static DataTable productsList_Select_custom(int CompanyID, long AccountID)
		{
			return (new DBProducts()).productsList_Select_custom(CompanyID, AccountID);
		}

		public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
		{
			return (new DBProducts()).Select_OtherCostAdditional_ItemsDetail(WebOtherCostID);
		}

		public static DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
		{
			return (new DBProducts()).Select_OtherCostAdditional_ItemsIDs(PriceCatalogueID);
		}

		public static DataTable Select_OtherCostMatrix_Value(long PriceCatalogueID, int Quantity)
		{
			return (new DBProducts()).Select_OtherCostMatrix_Value(PriceCatalogueID, Quantity);
		}

		public static DataTable Select_PriceCatalogueID(long TemplateID)
		{
			return (new DBProducts()).Select_PriceCatalogueID(TemplateID);
		}

		public static DataTable SubAdditionalOptions_SubValues(int ChoiceID, int WebOtherCostID)
		{
			return (new DBProducts()).SubAdditionalOptions_SubValues(ChoiceID, WebOtherCostID);
		}

		public static DataTable SubAdditionalOptions_Values(int ChoiceID, int WebOtherCostID)
		{
			return (new DBProducts()).SubAdditionalOptions_Values(ChoiceID, WebOtherCostID);
		}

		public static DataTable Tax_Bind(int companyID)
		{
			return (new DBProducts()).Tax_Bind(companyID);
		}
	}
}