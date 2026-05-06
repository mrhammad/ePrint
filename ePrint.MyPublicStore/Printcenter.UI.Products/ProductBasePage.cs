using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
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

		public static DataTable AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder, int WebOtherCostID, int ChoiceID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.AddOptionsProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder, WebOtherCostID, ChoiceID);
		}

		public static DataTable CoategoryName(int priceCatalogueCategoryID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.CoategoryName(priceCatalogueCategoryID, CompanyID);
		}

		public static int Company_RoundOff_Value(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Company_RoundOff_Value(CompanyID);
		}

		public static DataTable BindTreeView(int CompanyID, long AccountID, int Categoryid, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.BindTreeView(CompanyID, AccountID, Categoryid, StoreUserID);
		}

		public static string DBKeyForTemplate_Select(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.DBKeyForTemplate_Select(AccountID);
		}

		public static DataTable default_price_for_pack_select(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.default_price_for_pack_select(CompanyID);
		}

		public static DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.FeaturedProducts_Select(CompanyID, AccountID);
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

		public static DataTable GetTaxDetails_ByProductCatalogueId(int CompanyId, int ProductcatalogueId)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.GetTaxDetails_ByProductCatalogueId(CompanyId, ProductcatalogueId);
		}

		public static string IsRightPanelCalc_Enabled(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.IsRightPanelCalc_Enabled(AccountID);
		}

		public static string MeasurementValue(long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.MeasurementValue(CompanyID);
		}

		public static DataTable OtherMultiple_Default_Select(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.OtherMultiple_Default_Select(PriceCatalogueID);
		}

		public static DataTable OtherMultiple_product_Select(long PriceCatalogueID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.OtherMultiple_product_Select(PriceCatalogueID, CompanyID);
		}

		public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Product_CatalogueQty_Select(PriceCatalogueID);
		}

		public static List<Properties.GetQuantity> Product_CatalogueQty_SelectFor_OtherMultiple(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.Product_CatalogueQty_SelectFor_OtherMultiple(PriceCatalogueID);
		}

		public static DataTable productCategoryImage(int companyID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productCategoryImage(companyID);
		}

		public static DataTable productListImage(int companyID, int priceCatalogueCategoryID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productListImage(companyID, priceCatalogueCategoryID, AccountID);
		}

		public static DataTable productsCategoryList_Select(long CompanyID, long AccountID, long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsCategoryList_Select(CompanyID, AccountID, StoreUserID);
		}

		public static DataTable TopSubCatName(long CompanyID, int ParentCategoryID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.TopSubCatName(CompanyID, ParentCategoryID);
		}

		public static DataTable productsDetails_Select(int PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsDetails_Select(PriceCatalogueID);
		}

		public static DataTable productSearch(int companyID, int AccountID, string searchProducts)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productSearch(companyID, AccountID, searchProducts);
		}

		public static DataTable productsList_Select(long CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsList_Select(CompanyID, AccountID);
		}

		public static DataTable productsList_Select_custom(int CompanyID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Products.Products.productsList_Select_custom(CompanyID, AccountID);
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
	}
}