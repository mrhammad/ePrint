using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.Cart
{
	public class DBCart
	{
		public DBCart()
		{
		}

		public virtual void Cart_AdditionalOptions_Delete(long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Cart_AdditionalOptions_Delete");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable CategoryName_SubCategory_Select_for_Navigation(int PriceCatalogueID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_CategoryName_SubCategory_Select_for_Navigation");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public void Delete_CartAdditionalItems(long CartItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_CartAdditionalItems");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Delete_CartItem(string CookieID, long StoreUserID, long CartID, long CartItemID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_CartItem");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable eStore_Visibility_Settings_Select(int companyId, int accountId)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_default_settings");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, accountId);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Get_BackOrderStock_Check(string CartItemIDs)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataSet dataSet = new DataSet();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductAvailableQty_Check");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.String, CartItemIDs);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataSet GetAllCartDetails(long CartID)
		{
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_get_ALL_Cart_Details");
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public DataTable GetGroupRunUintPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GetGroupRunUnitPrice");
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
			database.AddInParameter(storedProcCommand, "@TotalQty", DbType.Decimal, TotalQty);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemId);
			database.AddInParameter(storedProcCommand, "@CouponCode", DbType.String, CouponCode);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, Convert.ToInt64(ConnectionClass.AccountID));
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable GetHorizontalGrpDetail(long Gid, long templateid)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_Select_HorizontalGroup_Details");
			database.AddInParameter(storedProcCommand, "@GID", DbType.Int64, Gid);
			database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, templateid);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable GetVerticalGrpDetail(long Gid, long templateid)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_Select_VerticalGroup_Details");
			database.AddInParameter(storedProcCommand, "@GID", DbType.Int64, Gid);
			database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, templateid);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual long Insert_into_Cart(string CookieID, long UserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping, bool IsDeliveryCost)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_into_Cart");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
			database.AddInParameter(storedProcCommand, "@CartTotalPrice", DbType.Decimal, CartTotalPrice);
			database.AddInParameter(storedProcCommand, "@CartTax", DbType.Decimal, CartTax);
			database.AddInParameter(storedProcCommand, "@CartShipping", DbType.Decimal, CartShipping);
            database.AddInParameter(storedProcCommand, "@IsDeliveryCost", DbType.Boolean, IsDeliveryCost);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_into_CartAdditionalItems");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@OptionID", DbType.Int64, OptionID);
			database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
			database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
			database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
			database.AddInParameter(storedProcCommand, "@SelectedPrice", DbType.Decimal, SelectedPrice);
			database.AddInParameter(storedProcCommand, "@MarkUpValue", DbType.Decimal, MarkUpValue);
			database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
			database.AddInParameter(storedProcCommand, "@ParentWebOtherCostID", DbType.Int64, ParentWebOtherCostID);
			database.AddInParameter(storedProcCommand, "@WebOtherCostType", DbType.String, WebOtherCostType);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, decimal Height, decimal Width, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long MainProductID, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_into_CartItem");
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
			database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int64, Quantity);
			database.AddInParameter(storedProcCommand, "@UnitPrice", DbType.Decimal, UnitPrice);
			database.AddInParameter(storedProcCommand, "@UploadFile", DbType.String, eprintDocumentName);
			database.AddInParameter(storedProcCommand, "@UploadFile1", DbType.String, eprintDocumentName1);
			database.AddInParameter(storedProcCommand, "@UploadFile2", DbType.String, eprintDocumentName2);
			database.AddInParameter(storedProcCommand, "@MainTotalPriceIncMarkup", DbType.Decimal, MainTotalPriceIncMarkup);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
			database.AddInParameter(storedProcCommand, "@MainPriceExcMarkup", DbType.Decimal, MainPriceExcMarkup);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int64, TaxID);
			database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, Height);
			database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, Width);
			database.AddInParameter(storedProcCommand, "@OriginalFileName1", DbType.String, OriginalFileName1);
			database.AddInParameter(storedProcCommand, "@OriginalFileName2", DbType.String, OriginalFileName2);
			database.AddInParameter(storedProcCommand, "@OriginalFileName3", DbType.String, OriginalFileName3);
			database.AddInParameter(storedProcCommand, "@MainProductID", DbType.Int64, MainProductID);
			database.AddInParameter(storedProcCommand, "@UploadFile_Report", DbType.String, eprintDocumentName_Report);
			database.AddInParameter(storedProcCommand, "@UploadFile1_Report", DbType.String, eprintDocumentName1_Report);
			database.AddInParameter(storedProcCommand, "@UploadFile2_Report", DbType.String, eprintDocumentName2_Report);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Insert_into_CartItem_EditableProd(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, long MainProductID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_into_CartItem_EditableProd");
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
			database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int64, Quantity);
			database.AddInParameter(storedProcCommand, "@UnitPrice", DbType.Decimal, UnitPrice);
			database.AddInParameter(storedProcCommand, "@UploadFile", DbType.String, eprintDocumentName);
			database.AddInParameter(storedProcCommand, "@UploadFile1", DbType.String, eprintDocumentName1);
			database.AddInParameter(storedProcCommand, "@UploadFile2", DbType.String, eprintDocumentName2);
			database.AddInParameter(storedProcCommand, "@MainTotalPriceIncMarkup", DbType.Decimal, MainTotalPriceIncMarkup);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
			database.AddInParameter(storedProcCommand, "@MainPriceExcMarkup", DbType.Decimal, MainPriceExcMarkup);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int64, TaxID);
			database.AddInParameter(storedProcCommand, "@OriginalFileName1", DbType.String, OriginalFileName1);
			database.AddInParameter(storedProcCommand, "@OriginalFileName2", DbType.String, OriginalFileName2);
			database.AddInParameter(storedProcCommand, "@OriginalFileName3", DbType.String, OriginalFileName3);
			database.AddInParameter(storedProcCommand, "@MainProductID", DbType.Int64, MainProductID);
			database.AddInParameter(storedProcCommand, "@UploadFile_Report", DbType.String, eprintDocumentName_Report);
			database.AddInParameter(storedProcCommand, "@UploadFile1_Report", DbType.String, eprintDocumentName1_Report);
			database.AddInParameter(storedProcCommand, "@UploadFile2_Report", DbType.String, eprintDocumentName2_Report);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual void Insert_To_CartAdditionalOptions(long StoreUserID, string SessionID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, int CartAdditionalTaxID, decimal CartAdditionalTaxPercentage, decimal CartAdditionalTaxValue)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_To_CartAdditionalOptions");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@SessionID", DbType.String, SessionID);
			database.AddInParameter(storedProcCommand, "@OptionID", DbType.Int64, OptionID);
			database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
			database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
			database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
			database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
			database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
			database.AddInParameter(storedProcCommand, "@SelectedPrice", DbType.Decimal, SelectedPrice);
			database.AddInParameter(storedProcCommand, "@MarkUpValue", DbType.Decimal, MarkUpValue);
			database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
			database.AddInParameter(storedProcCommand, "@CartAdditionalTaxID", DbType.Int32, CartAdditionalTaxID);
			database.AddInParameter(storedProcCommand, "@CartAdditionalTaxPercentage", DbType.Decimal, CartAdditionalTaxPercentage);
			database.AddInParameter(storedProcCommand, "@CartAdditionalTaxValue", DbType.Decimal, CartAdditionalTaxValue);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long Product_Exists_Check(int ProductID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Product_Exists_Check");
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int32, ProductID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual DataTable Select_ArtworkFile(long CartItemID, long CartID, string type)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArtworkFile_Cart_Order_Select");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@CartorOrderItem_ID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, 0);
			database.AddInParameter(storedProcCommand, "@Type", DbType.String, type);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_CartAdditionalItems(long CartItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_CartAdditionalItems");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_CartAdditionalOptions(string SessionID, long StoreUserID, string type)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_CartAdditionalOptions");
			database.AddInParameter(storedProcCommand, "@SessionID", DbType.String, SessionID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_CartItems(string CookieID, string type, long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2C_Select_CartItems");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, ConnectionClass.AccountID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_CartItems_Paypal(long StoreUserID, string MultipleCartID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartItems_Paypal");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@MultipleCartID", DbType.String, MultipleCartID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual string Select_MainProductName(long ProductID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_MainProductName");
			database.AddInParameter(storedProcCommand, "@MainProductID", DbType.Int64, ProductID);
			return (string)database.ExecuteScalar(storedProcCommand);
		}

		public virtual DataTable Select_Status(long CartItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_Select_Status");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Select_TemplateID(long PriceCatalogueID)
		{
			commonclass _commonclass = new commonclass();
			DataSet dataSet = new DataSet();
			Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_TemplateID");
			database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
			return database.ExecuteDataSet(storedProcCommand);
		}

		public virtual DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ShoppingCart_AdditionalOption_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@IsVisibleToCart", DbType.String, IsVisibleToCart);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public void Update_Cart(string CookieID, long CartID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_Cart");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@CartTotalPrice", DbType.Decimal, CartTotalPrice);
			database.AddInParameter(storedProcCommand, "@CartTax", DbType.Decimal, CartTax);
			database.AddInParameter(storedProcCommand, "@CartShipping", DbType.Decimal, CartShipping);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_Cart_StoreUserID");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void Update_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal TaxPercent, decimal MainPriceExcMarkup, long TaxID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_CartItem");
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
			database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
			database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int64, Quantity);
			database.AddInParameter(storedProcCommand, "@UnitPrice", DbType.Decimal, UnitPrice);
			database.AddInParameter(storedProcCommand, "@UploadFile", DbType.String, eprintDocumentName);
			database.AddInParameter(storedProcCommand, "@UploadFile1", DbType.String, eprintDocumentName1);
			database.AddInParameter(storedProcCommand, "@UploadFile2", DbType.String, eprintDocumentName2);
			database.AddInParameter(storedProcCommand, "@MainTotalPriceIncMarkup", DbType.Decimal, MainTotalPriceIncMarkup);
			database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, TaxPercent);
			database.AddInParameter(storedProcCommand, "@MainPriceExcMarkup", DbType.Decimal, MainPriceExcMarkup);
			database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int64, TaxID);
			//database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual void Update_CartItems_JobName(long CartItemID, string JobName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_CartItems_JobName");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void Update_PDFcartstatus(long CartitemID, string PDFName, string ImageName, string Previewtype, string JobName)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateCartStatus");
			database.AddInParameter(storedProcCommand, "@PDFNameFromCart", DbType.String, PDFName);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
			database.AddInParameter(storedProcCommand, "@ImageNameFromCart", DbType.String, ImageName);
			database.AddInParameter(storedProcCommand, "@PreviewType", DbType.String, Previewtype);
			database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void Update_PDFPreviewstatus(long CartitemID, string PDFName, string ImageName, string Previewtype)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdatePreviewStatus");
			database.AddInParameter(storedProcCommand, "@PDFName", DbType.String, PDFName);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
			database.AddInParameter(storedProcCommand, "@ImageName", DbType.String, ImageName);
			database.AddInParameter(storedProcCommand, "@PreviewType", DbType.String, Previewtype);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void Update_Savestatus(long CartitemID, string PDFName, string ImageName, string PreviewType)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateSaveStatus_PDFName");
			database.AddInParameter(storedProcCommand, "@PDFNameFromCart", DbType.String, PDFName);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
			database.AddInParameter(storedProcCommand, "@ImageNameFromCart", DbType.String, ImageName);
			database.AddInParameter(storedProcCommand, "@PreviewType", DbType.String, PreviewType);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Update_Select_OtherCostAdditional_Onoptionid(long CartItemID, long OptionID, long ProductId, decimal TotQty, long CartAdditionalItemID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2C_Select_OtherCostAdditional_Onoptionid");
			database.AddInParameter(storedProcCommand, "@CartItemId", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@OptionId", DbType.Int64, OptionID);
			database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductId);
			database.AddInParameter(storedProcCommand, "@TotalQty", DbType.Decimal, TotQty);
			database.AddInParameter(storedProcCommand, "@CartAdditionalItemID", DbType.Int64, CartAdditionalItemID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public void update_singlequestion_additionaloptions(long CartItemID, long CartAdditionalItemID, string Formula, double TotalPrice)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2C_update_singlequestion_additionaloptions");
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@CartAdditionalItemID", DbType.Int64, CartAdditionalItemID);
			database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
			database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public void UpdateSingleQuestionvalues(long WebOtherCostID, long Questionvalue)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2C_Update_SingleQuestionValues");
			database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
			database.AddInParameter(storedProcCommand, "@Questionvalue", DbType.Int64, Questionvalue);
			database.ExecuteNonQuery(storedProcCommand);
		}
		public void Update_Cart(string CookieID, long CartID, long CartItemID, long StoreUserID, decimal CartTotalPrice, decimal CartTax, decimal CartShipping)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_Cart");
			database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@CartTotalPrice", DbType.Decimal, CartTotalPrice);
			database.AddInParameter(storedProcCommand, "@CartTax", DbType.Decimal, CartTax);
			database.AddInParameter(storedProcCommand, "@CartShipping", DbType.Decimal, CartShipping);
			database.ExecuteNonQuery(storedProcCommand);
		}
	}
}