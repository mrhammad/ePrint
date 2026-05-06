using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.BusinessAccessLayer.Products;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Printcenter.UI.Products
{
	public class ProductBasePage
	{
		public ProductBasePage()
		{
		}

		public static DataTable AdditionalOptions_Value(long CartItemID, int SortOrderNo)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.AdditionalOptions_Value(CartItemID, SortOrderNo);
		}

		public static DataTable AdditionalOptions_Value(long CartItemID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.AdditionalOptions_Value(CartItemID);
		}

		public static DataTable AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder, int WebOtherCostID, int ChoiceID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.AddOptionsProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder, WebOtherCostID, ChoiceID);
		}

		public static string AllowDefaultCostcentre(long DepartmentId)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.AllowDefaultCostcentre(DepartmentId);
		}

		public static DataTable BindTreeView(int CompanyID, long AccountID, int Categoryid, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.BindTreeView(CompanyID, AccountID, Categoryid, StoreUserID);
		}

		public static DataSet Cart_Details_Edit(long CartItemID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Cart_Details_Edit(CartItemID);
		}

		public static DataTable CategoryName_Select_for_Navigation(int CompanyID, int Categoryid)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CategoryName_Select_for_Navigation(CompanyID, Categoryid);
		}

		public static bool CheckB2BApprovalSystemEnable(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CheckB2BApprovalSystemEnable(AccountID);
		}

		public static int CheckPDF_Generated(int TemplateImportID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CheckPDF_Generated(TemplateImportID);
		}

		public static DataTable CoategoryName(int priceCatalogueCategoryID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CoategoryName(priceCatalogueCategoryID, CompanyID);
		}

		public static int Company_RoundOff_Value(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Company_RoundOff_Value(CompanyID);
		}

		public static string CSV_UploadDownload_Enabled(long TemplateID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CSV_UploadDownload_Enabled(TemplateID);
		}

		public static DataTable default_price_for_pack_select(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.default_price_for_pack_select(CompanyID);
		}

		public static DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.FeaturedProducts_Select(CompanyID, AccountID);
		}

		public static DataTable Get_Select_TemplateID_Exist(int TemplateID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Get_Select_TemplateID_Exist(TemplateID);
		}

		public static DataTable Get_TemplateProperties_FriendlyName(int TemplateID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Get_TemplateProperties_FriendlyName(TemplateID);
		}

		public static DataTable Get404Content(int CompanyID, long AccountID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Get404Content");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public static string GetCampaign_Enabled(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetCampaign_Enabled(AccountID);
		}

		public static string GetStoreUserOnDeptID(long DeptID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetStoreUserOnDeptID(DeptID);
		}

		public static DataTable GetTaxDetails(int companyID, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetTaxDetails(companyID, StoreUserID);
		}

		public static DataTable GetTaxDetails_ByProductCatalogueId(int CompanyId, int ProductCatalogueId)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetTaxDetails_ByProductCatalogueId(CompanyId, ProductCatalogueId);
		}

		public static DataTable GetTaxDetailsByTaxID(int companyID, long TaxID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetTaxDetailsByTaxID(companyID, TaxID);
		}

		public static string IsRightPanelCalc_Enabled(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.IsRightPanelCalc_Enabled(AccountID);
		}

		public static string MeasurementValue(long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.MeasurementValue(CompanyID);
		}

        public static DataTable OtherMultiple_product_ForMatrix(long PriceCatalogueID, int companyID)
        {
            return Printcenter.BusinessAccessLayer.Products.Products.OtherMultiple_product_ForMatrix(PriceCatalogueID, companyID);
        }

        public static DataTable OtherMultiple_DefaultItem_Select(int PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.OtherMultiple_DefaultItem_Select(PriceCatalogueID);
		}

		public static DataTable OtherMultiple_product_Select(long PriceCatalogueID, int companyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.OtherMultiple_product_Select(PriceCatalogueID, companyID);
		}

		public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Product_CatalogueQty_Select(PriceCatalogueID);
		}

        public static DataTable Product_CatalogueQty_SelectMMX(long PriceCatalogueID)
        {
            return Printcenter.BusinessAccessLayer.Products.Products.Product_CatalogueQty_SelectMMX(PriceCatalogueID);
        }

        public static DataTable ProductStockType_Select(long CompanyID, long PriceCatalogueID)
        {
            return Printcenter.BusinessAccessLayer.Products.Products.ProductStockType_Select(CompanyID, PriceCatalogueID);
        }

        public static List<Properties.GetQuantity> Product_CatalogueQty_SelectFor_OtherMultiple(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Product_CatalogueQty_SelectFor_OtherMultiple(PriceCatalogueID);
		}

		public static DataTable productCategoryImage(int companyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productCategoryImage(companyID);
		}

		public static DataTable ProductCategoryNameSelect_Navigation(int CompanyID, int Categoryid)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.ProductCategoryNameSelect_Navigation(CompanyID, Categoryid);
		}

		public static DataTable productListImage(int companyID, int priceCatalogueCategoryID, int AccountID, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productListImage(companyID, priceCatalogueCategoryID, AccountID, StoreUserID);
		}

		public static DataTable productsCategoryList_Select(long CompanyID, long AccountID, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsCategoryList_Select(CompanyID, AccountID, StoreUserID);
		}

		public static DataTable productsDetails_Select(int PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsDetails_Select(PriceCatalogueID);
		}
        public static DataTable TaxPrecedence_Select(int AccountId)
        {
            return Printcenter.BusinessAccessLayer.Products.Products.TaxPrecedence_Select(AccountId);
        }

        
        public static DataTable productSearch(int companyID, int AccountID, string searchProducts, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productSearch(companyID, AccountID, searchProducts, StoreUserID);
		}

		public static DataTable productsList_Select(long CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsList_Select(CompanyID, AccountID);
		}

		public static DataTable productsList_Select_custom(int CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsList_Select_custom(CompanyID, AccountID);
		}

		public static DataTable Select_CampaignValues(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_CampaignValues(AccountID);
		}

		public static DataTable Select_FeaturedProducts_Description(long CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_FeaturedProducts_Description(CompanyID, AccountID);
		}

		public static DataTable Select_NewProductList(long CompanyID, long AccountID, string Producttype_New)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_NewProductList(CompanyID, AccountID, Producttype_New);
		}

		public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_OtherCostAdditional_ItemsDetail(WebOtherCostID);
		}

		public static DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_OtherCostAdditional_ItemsIDs(PriceCatalogueID);
		}

		public static DataTable Select_OtherCostMatrix_Value(long PriceCatalogueID, int Quantity)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_OtherCostMatrix_Value(PriceCatalogueID, Quantity);
		}

		public static DataTable Select_PriceCatalogueID(long TemplateID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_PriceCatalogueID(TemplateID);
		}

		public static DataTable Select_SpendLimitAmount(long StoreUserID, long AccountID, string OrderKey, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_SpendLimitAmount(StoreUserID, AccountID, OrderKey, CompanyID);
		}

        public static DataTable Select_SpendLimitAmount_Dashboard(long StoreUserID, long AccountID,  int CompanyID)
        {
            return Printcenter.BusinessAccessLayer.Products.Products.Select_SpendLimitAmount_Dashboard(StoreUserID, AccountID, CompanyID);
        }

		public static DataTable Select_StoreCreditAmount_Dashboard(long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_StoreCreditAmount_Dashboard(StoreUserID);
		}
		public static DataSet Select_TemplateID(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_TemplateID(PriceCatalogueID);
		}

		public static DataTable Select_UserID_BasedOnBehalf(long CartItemID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Select_UserID(CartItemID);
		}

		public static DataTable Setting_SpendLimit_Select(long AccountID, long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Setting_SpendLimit_Select(AccountID, CompanyID);
		}

		public static DataTable SubAdditionalOptions_SubValues(int ChoiceID, int WebOtherCostID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.SubAdditionalOptions_SubValues(ChoiceID, WebOtherCostID);
		}

		public static DataTable SubAdditionalOptions_Values(int ChoiceID, int WebOtherCostID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.SubAdditionalOptions_Values(ChoiceID, WebOtherCostID);
		}

		public static DataTable Tax_Bind(int companyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Tax_Bind(companyID);
		}

		public static DataTable WS_CategoryName_SubCategory_Select_for_Navigation(int PriceCatalogueID, int CompanyID, int Categoryid)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.WS_CategoryName_SubCategory_Select_for_Navigation(PriceCatalogueID, CompanyID, Categoryid);
		}
	}
}