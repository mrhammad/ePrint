using Printcenter.DataAccessLayer.Products;

using System;
using System.Collections.Generic;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Products
{
	public class Products
	{
		public Products()
		{
		}

		public static DataTable AdditionalOptions_Value(long CartItemID, int SortOrderNo)
		{
			return (new DBProducts()).AdditionalOptions_Value(CartItemID, SortOrderNo);
		}
		public static DataTable AdditionalOptions_Value(long CartItemID)
		{
			return (new DBProducts()).AdditionalOptions_Value(CartItemID);
		}
		
		public static DataTable AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder, int WebOtherCostID, int ChoiceID)
		{
			return (new DBProducts()).AddOptionsProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder, WebOtherCostID, ChoiceID);
		}

		public static string AllowDefaultCostcentre(long DepartmentId)
		{
			return (new DBProducts()).AllowDefaultCostcentre(DepartmentId);
		}

		public static DataTable BindTreeView(int CompanyID, long AccountID, int Categoryid, long StoreUserID)
		{
			return (new DBProducts()).BindTreeView(CompanyID, AccountID, Categoryid, StoreUserID);
		}

		public static DataSet Cart_Details_Edit(long CartItemID)
		{
			return (new DBProducts()).Cart_Details_Edit(CartItemID);
		}

		public static DataTable CategoryName_Select_for_Navigation(int CompanyID, int Categoryid)
		{
			return (new DBProducts()).CategoryName_Select_for_Navigation(CompanyID, Categoryid);
		}

		public static bool CheckB2BApprovalSystemEnable(long AccountID)
		{
			return (new DBProducts()).CheckB2BApprovalSystemEnable(AccountID);
		}

		public static int CheckPDF_Generated(int TemplateImportID)
		{
			return (new DBProducts()).CheckPDF_Generated(TemplateImportID);
		}

		public static DataTable CoategoryName(int priceCatalogueCategoryID, int CompanyID)
		{
			return (new DBProducts()).CoategoryName(priceCatalogueCategoryID, CompanyID);
		}

		public static int Company_RoundOff_Value(int CompanyID)
		{
			return (new DBProducts()).Company_RoundOff_Value(CompanyID);
		}

		public static string CSV_UploadDownload_Enabled(long TemplateID)
		{
			return (new DBProducts()).CSV_UploadDownload_Enabled(TemplateID);
		}

		public static DataTable default_price_for_pack_select(int CompanyID)
		{
			return (new DBProducts()).default_price_for_pack_select(CompanyID);
		}

		public static DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
		{
			return (new DBProducts()).FeaturedProducts_Select(CompanyID, AccountID);
		}

		public static DataTable Get_Select_TemplateID_Exist(int TemplateID)
		{
			return (new DBProducts()).Get_Select_TemplateID_Exist(TemplateID);
		}

		public static DataTable Get_TemplateProperties_FriendlyName(int TemplateID)
		{
			return (new DBProducts()).Get_TemplateProperties_FriendlyName(TemplateID);
		}

		public static string GetCampaign_Enabled(long AccountID)
		{
			return (new DBProducts()).GetCampaign_Enabled(AccountID);
		}

		public static string GetStoreUserOnDeptID(long DeptID)
		{
			return (new DBProducts()).GetStoreUserOnDeptID(DeptID);
		}

		public static DataTable GetTaxDetails(int companyID, long StoreUserID)
		{
			return (new DBProducts()).GetTaxDetails(companyID, StoreUserID);
		}

		public static DataTable GetTaxDetails_ByProductCatalogueId(int CompanyId, int ProductCatalogueId)
		{
			return (new DBProducts()).GetTaxDetails_ByProductCatalogueId(CompanyId, ProductCatalogueId);
		}

		public static DataTable GetTaxDetailsByTaxID(int companyID, long TaxID)
		{
			return (new DBProducts()).GetTaxDetailsByTaxID(companyID, TaxID);
		}

		public static string IsRightPanelCalc_Enabled(long AccountID)
		{
			return (new DBProducts()).IsRightPanelCalc_Enabled(AccountID);
		}

		public static string MeasurementValue(long CompanyID)
		{
			return (new DBProducts()).MeasurementValue(CompanyID);
		}

		public static DataTable OtherMultiple_DefaultItem_Select(int PriceCatalogueID)
		{
			return (new DBProducts()).OtherMultiple_DefaultItem_Select(PriceCatalogueID);
		}

        public static DataTable OtherMultiple_product_ForMatrix(long PriceCatalogueID, int companyID)
        {
            return (new DBProducts()).OtherMultiple_product_ForMatrix(PriceCatalogueID, companyID);
        }

        public static DataTable OtherMultiple_product_Select(long PriceCatalogueID, int companyID)
		{
			return (new DBProducts()).OtherMultiple_product_Select(PriceCatalogueID, companyID);
		}

		public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			return (new DBProducts()).Product_CatalogueQty_Select(PriceCatalogueID);
		}

        public static DataTable Product_CatalogueQty_SelectMMX(long PriceCatalogueID)
        {
            return (new DBProducts()).Product_CatalogueQty_SelectMMX(PriceCatalogueID);
        }

        public static DataTable ProductStockType_Select(long CompanyID, long PriceCatalogueID)
        {
            return (new DBProducts()).ProductStockType_Select(CompanyID, PriceCatalogueID);
        }

        public static List<Properties.GetQuantity> Product_CatalogueQty_SelectFor_OtherMultiple(long PriceCatalogueID)
		{
			return (new DBProducts()).Product_CatalogueQty_SelectFor_OtherMultiple(PriceCatalogueID);
		}

		public static DataTable productCategoryImage(int companyID)
		{
			return (new DBProducts()).productCategoryImage(companyID);
		}

		public static DataTable ProductCategoryNameSelect_Navigation(int CompanyID, int Categoryid)
		{
			return (new DBProducts()).ProductCategoryNameSelect_Navigation(CompanyID, Categoryid);
		}

		public static DataTable productListImage(int companyID, int priceCatalogueCategoryID, int AccountID, long StoreUserID)
		{
			return (new DBProducts()).productListImage(companyID, priceCatalogueCategoryID, AccountID, StoreUserID);
		}

		public static DataTable productsCategoryList_Select(long CompanyID, long AccountID, long StoreUserID)
		{
			return (new DBProducts()).productsCategoryList_Select(CompanyID, AccountID, StoreUserID);
		}

		public static DataTable productsDetails_Select(int PriceCatalogueID)
		{
			return (new DBProducts()).productsDetails_Select(PriceCatalogueID);
		}

        public static DataTable TaxPrecedence_Select(int AccountId)
        {
            return (new DBProducts()).TaxPrecedence_Select(AccountId);
        }
        public static DataTable productSearch(int companyID, int AccountID, string searchProducts, long StoreUserID)
		{
			return (new DBProducts()).productSearch(companyID, AccountID, searchProducts, StoreUserID);
		}

		public static DataTable productsList_Select(long CompanyID, long AccountID)
		{
			return (new DBProducts()).productsList_Select(CompanyID, AccountID);
		}

		public static DataTable productsList_Select_custom(int CompanyID, long AccountID)
		{
			return (new DBProducts()).productsList_Select_custom(CompanyID, AccountID);
		}

		public static DataTable Select_CampaignValues(long AccountID)
		{
			return (new DBProducts()).Select_CampaignValues(AccountID);
		}

		public static DataTable Select_FeaturedProducts_Description(long CompanyID, long AccountID)
		{
			return (new DBProducts()).Select_FeaturedProducts_Description(CompanyID, AccountID);
		}

		public static DataTable Select_NewProductList(long CompanyID, long AccountID, string Producttype_New)
		{
			return (new DBProducts()).Select_NewProductList(CompanyID, AccountID, Producttype_New);
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

		public static DataTable Select_SpendLimitAmount(long StoreUserID, long AccountID, string OrderKey, int CompanyID)
		{
			return (new DBProducts()).Select_SpendLimitAmount(StoreUserID, AccountID, OrderKey, CompanyID);
		}

        public static DataTable Select_SpendLimitAmount_Dashboard(long StoreUserID, long AccountID, int CompanyID)
        {
            return (new DBProducts()).Select_SpendLimitAmount_Dashboard(StoreUserID, AccountID, CompanyID);
        }

		public static DataTable Select_StoreCreditAmount_Dashboard(long StoreUserID)
		{
			return (new DBProducts()).Select_StoreCreditAmount_Dashboard(StoreUserID);
		}

		

		public static DataSet Select_TemplateID(long PriceCatalogueID)
		{
			return (new DBProducts()).Select_TemplateID(PriceCatalogueID);
		}

		public static DataTable Select_UserID(long CartItemID)
		{
			return (new DBProducts()).Select_UserID_OnBehalf(CartItemID);
		}

		public static DataTable Setting_SpendLimit_Select(long AccountID, long CompanyID)
		{
			return (new DBProducts()).Setting_SpendLimit_Select(AccountID, CompanyID);
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

		public static DataTable WS_CategoryName_SubCategory_Select_for_Navigation(int PriceCatalogueID, int CompanyID, int Categoryid)
		{
			return (new DBProducts()).WS_CategoryName_SubCategory_Select_for_Navigation(PriceCatalogueID, CompanyID, Categoryid);
		}
	}
}