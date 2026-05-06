using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.Products
{
    public class DBProducts
	{
		public DBProducts()
		{
		}

		public virtual DataTable AddOptionsProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder, int WebOtherCostID, int ChoiceID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AddOptionsProductDetails_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
			database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, WebOtherCostID);
			database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, ChoiceID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable CoategoryName(int priceCatalogueCategoryID, int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GetCategoryName");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, priceCatalogueCategoryID);
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual int Company_RoundOff_Value(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_DefaultSettings_RoundOff_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			return (int)database.ExecuteScalar(storedProcCommand);
		}

		public virtual string DBKeyForTemplate_Select(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DBKeyForTemplate_Select");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable default_price_for_pack_select(int CompanyID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_default_price_for_pack_select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_FeaturedProducts_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable GetTaxDetails_ByProductCatalogueId(int CompanyId, int ProductCatalogueId)
		{
			commonclass _commonclass = new commonclass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_GetTaxDetails_ByProductCatalogueId");
			database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
			database.AddInParameter(storedProcCommand, "@ProductCatalogueID", DbType.Int32, ProductCatalogueId);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string IsRightPanelCalc_Enabled(long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsRightPanelCalc_Enabled");
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			bool flag = (bool)database.ExecuteScalar(storedProcCommand);
			return flag.ToString().ToLower();
		}

		public virtual string MeasurementValue(long CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_PaperStockMeasure_Type");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable OtherMultiple_Default_Select(long ProductCatalogueID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultiple_Default_Select");
			database.AddInParameter(storedProcCommand, "@ProductCatalogueID", DbType.Int64, ProductCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable OtherMultiple_product_Select(long PriceCatalogueID, int CompanyID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultiple_product_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Product_CatalogueQty_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable BindTreeView(int CompanyID, long AccountID, int Categoryid, long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsCategoryCounts_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@Categoryid", DbType.Int64, Categoryid);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual List<Properties.GetQuantity> Product_CatalogueQty_SelectFor_OtherMultiple(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Product_CatalogueQty_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			dataSet = database.ExecuteDataSet(storedProcCommand);
			List<Properties.GetQuantity> getQuantities = new List<Properties.GetQuantity>();
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					Properties.GetQuantity getQuantity = new Properties.GetQuantity()
					{
						FromQuantity = row["FromQuantity"].ToString(),
						ToQuantity = row["ToQuantity"].ToString(),
						Price = row["Price"].ToString(),
						Markup = row["Markup"].ToString(),
						SellingPrice = row["SellingPrice"].ToString(),
						NewPrice = row["NewPrice"].ToString(),
						IsPriceStartFrom = row["IsPriceStartFrom"].ToString(),
						IsShowStock = row["IsShowStock"].ToString(),
						IsShowSoldInPacksof = row["IsShowSoldInPacksof"].ToString(),
						SoldInPacksof = row["SoldInPacksof"].ToString(),
						MatrixType = row["MatrixType"].ToString(),
						IsCumulativePricing = row["IsCumulativePricing"].ToString(),
						IsStockItem = row["IsStockItem"].ToString(),
						DrawStockFrom = row["DrawStockFrom"].ToString(),
						IsBackOrder = row["IsBackOrder"].ToString(),
						AvailableQuantity = row["AvailableQuantity"].ToString(),
						CatalogueName = row["CatalogueName"].ToString(),
						Description = row["Description"].ToString(),
						ProductImage = row["ProductImage"].ToString(),
						IsShortDescription = row["IsShortDescription"].ToString(),
						ProductTaxId = row["SalesTaxRate"].ToString(),
						ProductTaxName = row["TaxName"].ToString(),
						ProductTaxRate = row["TaxRate"].ToString()
					};
					getQuantities.Add(getQuantity);
				}
			}
			return getQuantities;
		}

		public virtual DataTable productCategoryImage(int companyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productCategoryImage");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productListImage(int companyID, int priceCatalogueCategoryID, int AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productListImage");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, priceCatalogueCategoryID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productsCategoryList_Select(long CompanyID, long AccountID, long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsCategoryList_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable TopSubCatName(long CompanyID, int ParentCategoryID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_TopSubCatName");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@ParentCategoryID", DbType.Int64, ParentCategoryID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productsDetails_Select(int PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsDetails_Select");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productSearch(int companyID, int AccountID, string searchProducts)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productSearch");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			database.AddInParameter(storedProcCommand, "@searchProducts", DbType.String, searchProducts);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable productsList_Select(long CompanyID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsList_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable productsList_Select_custom(int CompanyID, long AccountID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("ws_CustomCategory");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
		{
			commonclass _commonclass = new commonclass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsDetail");
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsIDs");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_OtherCostMatrix_Value(long WebOtherCostID, int Quantity)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostMatrix_Value");
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_PriceCatalogueID(long TemplateID)
		{
			DataTable dataTable = new DataTable();
			commonclass _commonclass = new commonclass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_PriceCatalogueID");
			database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SubAdditionalOptions_SubValues(int ChoiceID, int WebOtherCostID)
		{
			commonclass _commonclass = new commonclass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionalOptionsValues_Select_Order");
			database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, ChoiceID);
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, WebOtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable SubAdditionalOptions_Values(int ChoiceID, int WebOtherCostID)
		{
			commonclass _commonclass = new commonclass();
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionalOptionsValues_Select");
			database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, ChoiceID);
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, WebOtherCostID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Tax_Bind(int CompanyID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Tax_Bind");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Cart_Details_Edit(long CartItemID)
		{
			commonclass _commonclass = new commonclass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Get_CartDetails_CartID");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable AdditionalOptions_Value(long CartItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_AdditionalItems");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			//database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int16, SortOrderNo);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

	}
}