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

        public virtual DataTable ArtworkFile_Cart_Order_Select(long CartItemID, long CartorOrderItem_ID, long OrderID, string Type)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArtworkFile_Cart_Order_Select");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@CartorOrderItem_ID", DbType.Int64, CartorOrderItem_ID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Cart_AdditionalOptions_Delete(long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Cart_AdditionalOptions_Delete");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable default_settings(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_default_settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
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

        public virtual void Delete_CartItem(string CookieID, long StoreUserID, long CartID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_CartItem");
            database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Delete_CartItem_B2B(long CartItemID, long CartID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_CartItem_B2B");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Get_BackOrderStock_Check(string CartItemIDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductAvailableQty_Check");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.String, CartItemIDs);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable Get_CartItemCount(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[Ws_b2b_select_ProductCount]");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_Edit_Profile_Approval_Pending(string Email, long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Edit_Profile_Approval_Pending");
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_pendingApprovalUser(string Email, long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Approval_Pending");
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet GetAllCartDetails(long CartID)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_get_ALL_Cart_Details");
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataTable GetGroupRunUnitPrice(long ProductID, decimal TotalQty, long CartItemId, string CouponCode, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_GetGroupRunUnitPrice");
            database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
            database.AddInParameter(storedProcCommand, "@TotalQty", DbType.Decimal, TotalQty);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemId);
            database.AddInParameter(storedProcCommand, "@CouponCode", DbType.String, CouponCode);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
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

        public virtual DataTable Check_Delivery_Cart()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Check_Delivery_Cart");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_ZipTax_Cart(decimal Tax)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ZipTax_Cart");
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_DefaultTax_Cart(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_DefaultTax_Cart");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Insert_into_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
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
            database.AddInParameter(storedProcCommand, "@FreeTextQuestionLong", DbType.String, FreeTextQuestionLong);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual long Insert_into_CartItem(long CartID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string Status, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long Order_behalf_DeptID, long Order_Behalf_UserID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, long TemplateImportID, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_into_CartItem");
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
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@OriginalFileName1", DbType.String, OriginalFileName1);
            database.AddInParameter(storedProcCommand, "@OriginalFileName2", DbType.String, OriginalFileName2);
            database.AddInParameter(storedProcCommand, "@OriginalFileName3", DbType.String, OriginalFileName3);
            database.AddInParameter(storedProcCommand, "@Order_behalf_DeptID", DbType.Int64, Order_behalf_DeptID);
            database.AddInParameter(storedProcCommand, "@Order_Behalf_UserID", DbType.Int64, Order_Behalf_UserID);
            database.AddInParameter(storedProcCommand, "@IsStockReplenish", DbType.Int32, IsStockReplenish);
            database.AddInParameter(storedProcCommand, "@CampaignID", DbType.Int64, CampaignID);
            database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, Height);
            database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, Width);
            database.AddInParameter(storedProcCommand, "@TemplateImportID", DbType.Int64, TemplateImportID);
            database.AddInParameter(storedProcCommand, "@MainProductId", DbType.Int64, MainProductId);
            database.AddInParameter(storedProcCommand, "@UploadFile_Report", DbType.String, eprintDocumentName_Report);
            database.AddInParameter(storedProcCommand, "@UploadFile1_Report", DbType.String, eprintDocumentName1_Report);
            database.AddInParameter(storedProcCommand, "@UploadFile2_Report", DbType.String, eprintDocumentName2_Report);

     


            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public void Insert_NotesOnEditItem(long CartItemID, long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_OrderItemUpdate_Notes_Insert");
            database.AddInParameter(storedProcCommand, "@CartitemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@StoreUSerID", DbType.Int64, StoreUserID);
            database.ExecuteNonQuery(storedProcCommand);
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

        public virtual DataTable JobInvoice_ArtworkFile_Select(long CartItemID, string OrdJobInvid)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobInvoice_ArtworkFile_Select");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.String, OrdJobInvid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable JobInvoice_ArtworkFile_Select_splititem(long CartItemID, long OrderItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobInvoice_ArtworkFile_Select_splititem");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
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

        public virtual DataTable settings_Product_Matrix_EnableCheck(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_Matrix_EnableCheck");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
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
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartAdditionalItems");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_DeliveryCost_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_DeliveryCost_ItemsDetail()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_DeliveryCost_ItemsDetail");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ShipRates_Detail(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ShipRates_Detail");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_NonShipRates_Detail()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_NonShipRates_Detail");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_DeliveryCost_SEItemsDetail(string AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_DeliveryCost_SEItemsDetail");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.String, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_CBMCartItems_DC(string CartID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CBMCartItems_DC");
            database.AddInParameter(storedProcCommand, "@CartID", DbType.String, CartID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ShipRates_SEItemsDetail(string Carrierid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ShipRates_SEItemsDetail");
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ShipEngine_ErrDetail(string AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ShipEngine_ErrDetail");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.String, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ShipRates_SEItemsDetail");
            database.AddInParameter(storedProcCommand, "@Rateid", DbType.String, Rateid);
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.AddInParameter(storedProcCommand, "@CarrierFriendlyName", DbType.String, CarrierFriendlyName);
            database.AddInParameter(storedProcCommand, "@CarrierCode", DbType.String, CarrierCode);
            database.AddInParameter(storedProcCommand, "@ServiceType", DbType.String, ServiceType);
            database.AddInParameter(storedProcCommand, "@ServiceCode", DbType.String, ServiceCode);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.String, DeliveryCost);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Insert_ShipRates_SEItemsDetail(string Rateid, string Carrierid, string CarrierFriendlyName, string CarrierCode, string ServiceType, string ServiceCode, double DeliveryCost)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_ShipRates_SEItemsDetail");
            database.AddInParameter(storedProcCommand, "@Rateid", DbType.String, Rateid);
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.AddInParameter(storedProcCommand, "@CarrierFriendlyName", DbType.String, CarrierFriendlyName);
            database.AddInParameter(storedProcCommand, "@CarrierCode", DbType.String, CarrierCode);
            database.AddInParameter(storedProcCommand, "@ServiceType", DbType.String, ServiceType);
            database.AddInParameter(storedProcCommand, "@ServiceCode", DbType.String, ServiceCode);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.String, DeliveryCost);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Delete_ShipRates_SEItemsDetail(string Carrierid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_ShipRates_SEItemsDetail");
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_ShipEngine_ErrDetail(string Carrierid, string ErrDesc)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ShipEngine_ErrDetail");
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.AddInParameter(storedProcCommand, "@ErrDesc", DbType.String, ErrDesc);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void ShipEnginecall_Details_Insert(string Carrierid, string AccountID, bool IsDeleted, string PayLoadDetail, string ErrorDetail)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ShipEnginecall_Details_Insert");
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.String, AccountID);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
            database.AddInParameter(storedProcCommand, "@PayLoadDetail", DbType.String, PayLoadDetail);
            database.AddInParameter(storedProcCommand, "@ErrorDetail", DbType.String, ErrorDetail);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_ShipEngine_PayloadDetail(string Carrierid, string PayloadDetail)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ShipEngine_PayloadDetail");
            database.AddInParameter(storedProcCommand, "@Carrierid", DbType.String, Carrierid);
            database.AddInParameter(storedProcCommand, "@PayloadDetail", DbType.String, PayloadDetail);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Delete_ShipRates(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_ShipRates");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_DeliveryCost_ItemsDetail(int CompanyID, int DeliveryCostID, Double DeliveryCost)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_DeliveryCost_ItemsDetail");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.Int32, DeliveryCostID);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Double, DeliveryCost);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_Rates_NonSE(string DeliveryCostTitle, Double DeliveryCost)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_Rates_NonSE");
            database.AddInParameter(storedProcCommand, "@DeliveryCostTitle", DbType.String, DeliveryCostTitle);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Double, DeliveryCost);
            database.ExecuteNonQuery(storedProcCommand);
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
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartItems");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, Convert.ToInt64(ConnectionClass.AccountID));
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void DeliveryCostAdjustments_CartItems()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_DeliveryCostAdjustments_CartItems");
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Select_CartItemsStoreCredit(long StoreUserID ,long CartItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartItem_StoreCredit");
    
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Save_CartItemsStoreCredit( long CartItemID, double TaxAmout, double UnitPrice, Double CartItemTotal)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Save_CartItem_StoreCredit");

            
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@UnitPrice", DbType.Double, UnitPrice);
            database.AddInParameter(storedProcCommand, "@MainItemPrice", DbType.Double, CartItemTotal);
            database.ExecuteNonQuery(storedProcCommand);
           
            
        }

        public virtual void Update_StoreCredit(long StoreUserID,  double StoreCredit)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_StoreCredit");


            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@StoreCredit", DbType.Double, StoreCredit);
           
            database.ExecuteNonQuery(storedProcCommand);


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

        public virtual string Select_MainProductName(long MainProductID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_MainProductName");
            database.AddInParameter(storedProcCommand, "@MainProductID", DbType.Int64, MainProductID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual bool Select_IsZip2taxEnabled(int CompanyID, long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_IsZip2taxEnabled");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Setting_ZiptoTax_Select(long AccountID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ZiptoTaxSettings_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Setting_ZiptoTax_Update(long AccountID, long CompanyID, string Url, string Response)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ZiptoTaxSettings_Update");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Url", DbType.String, Url);
            database.AddInParameter(storedProcCommand, "@Response", DbType.String, Response);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Select_DefaultFromAddress()
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_DefaultFromAddress");
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string Select_DefaultMarkup(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_DefaultMarkup");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Select_MultipleCartItems(string CookieID, string type, long StoreUserID, string strMultipleCartID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_MultipleCartItems");
            database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@MultipleCartID", DbType.String, strMultipleCartID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_MyDesignCartItems(string CookieID, string type, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_MyDesignCartItems");
            database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderDetails(long CartItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderDetails");
            database.AddInParameter(storedProcCommand, "@CartItemId", DbType.Int64, CartItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
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

        public void Update_Delivery_Cart(long CartID, decimal CartTotalPrice, string DeliveryCostDesc)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_Delivery_Cart");
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.AddInParameter(storedProcCommand, "@CartTotalPrice", DbType.Decimal, CartTotalPrice);
            database.AddInParameter(storedProcCommand, "@DeliveryCostDesc", DbType.String, DeliveryCostDesc);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_Delivery_CartItem(long CartItemID, decimal CartTotalPrice)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_Delivery_CartItem");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@CartTotalPrice", DbType.Decimal, CartTotalPrice);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_Cart_StoreUserID(string CookieID, long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_Cart_StoreUserID");
            database.AddInParameter(storedProcCommand, "@CookieID", DbType.String, CookieID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_Cart_TotalWithDc(long CartID, decimal DeliveryCost, string DeliveryCostDesc)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_Cart_TotalWithDC");
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Decimal, DeliveryCost);
            database.AddInParameter(storedProcCommand, "@DeliveryCostDesc", DbType.String, DeliveryCostDesc);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_CartAdditionalItems(long CartItemID, long OptionID, string Formula, decimal MarkUp, decimal TotalPrice, long SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkUpValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_into_CartAdditionalItems");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@OptionID", DbType.Int64, OptionID);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, MarkUp);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
            database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
            database.AddInParameter(storedProcCommand, "@SelectedPrice", DbType.Decimal, SelectedPrice);
            database.AddInParameter(storedProcCommand, "@MarkUpValue", DbType.Decimal, MarkUpValue);
            database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
            database.AddInParameter(storedProcCommand, "@ParentWebOtherCostID", DbType.Int64, ParentWebOtherCostID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostType", DbType.String, WebOtherCostType);
            database.AddInParameter(storedProcCommand, "@FreeTextQuestionLong", DbType.String, FreeTextQuestionLong);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_CartItem(long CartID, long CartItemID, long ProductID, string JobName, long Quantity, decimal UnitPrice, string eprintDocumentName, string eprintDocumentName1, string eprintDocumentName2, decimal MainTotalPriceIncMarkup, decimal Tax, decimal MainPriceExcMarkup, long TaxID, string OriginalFileName1, string OriginalFileName2, string OriginalFileName3, long OnBehalfUserID, long OnBehalfDeptID, int IsStockReplenish, long CampaignID, decimal Height, decimal Width, int MainProductId, string eprintDocumentName_Report, string eprintDocumentName1_Report, string eprintDocumentName2_Report)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_CartItem");
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
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
            database.AddInParameter(storedProcCommand, "@OnBehalfUserID", DbType.Int64, OnBehalfUserID);
            database.AddInParameter(storedProcCommand, "@OnBehalfDeptID", DbType.Int64, OnBehalfDeptID);
            database.AddInParameter(storedProcCommand, "@IsStockReplenish", DbType.Int64, IsStockReplenish);
            database.AddInParameter(storedProcCommand, "@CampaignID", DbType.Int64, CampaignID);
            database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, Height);
            database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, Width);
            database.AddInParameter(storedProcCommand, "@MainProductId", DbType.Int64, MainProductId);
            database.AddInParameter(storedProcCommand, "@UploadFile_Report", DbType.String, eprintDocumentName_Report);
            database.AddInParameter(storedProcCommand, "@UploadFile1_Report", DbType.String, eprintDocumentName1_Report);
            database.AddInParameter(storedProcCommand, "@UploadFile2_Report", DbType.String, eprintDocumentName2_Report);
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

        public virtual void Update_OrderMarkup(long CartItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_OrderMarkup");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_PDFcartstatus(long CartitemID, string PDFName, string ImagesName, string PreviewType, string JobName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateCartStatus");
            database.AddInParameter(storedProcCommand, "@PDFNameFromCart", DbType.String, PDFName);
            database.AddInParameter(storedProcCommand, "@ImageNameFromCart", DbType.String, ImagesName);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
            database.AddInParameter(storedProcCommand, "@PreviewType", DbType.String, PreviewType);
            database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_PDFPreviewstatus(long CartitemID, string PDFName, string ImagesName, string PreviewType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdatePreviewStatus");
            database.AddInParameter(storedProcCommand, "@PDFName", DbType.String, PDFName);
            database.AddInParameter(storedProcCommand, "@ImageName", DbType.String, ImagesName);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
            database.AddInParameter(storedProcCommand, "@PreviewType", DbType.String, PreviewType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_Savestatus(long CartitemID, string PDFName, string ImagesName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateSaveStatus_PDFName");
            database.AddInParameter(storedProcCommand, "@PDFNameFromCart", DbType.String, PDFName);
            database.AddInParameter(storedProcCommand, "@ImageNameFromCart", DbType.String, ImagesName);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartitemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Update_Select_OtherCostAdditional_Onoptionid(long CartItemID, long OptionID, long ProductId, decimal TotQty, long CartAdditionalItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_Onoptionid");
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
            DbCommand storedProcCommand = database.GetStoredProcCommand("ws_update_singlequestion_additionaloptions");
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
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_SingleQuestionValues");
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            database.AddInParameter(storedProcCommand, "@Questionvalue", DbType.Int64, Questionvalue);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable GetCartItemStatusForApproval(long CartItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartItem_StatusForApproval");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }

            return dataTable;
        }

        public virtual void Product_CataloguePdfNameWaterMark_Update(Int64 PriceCatalogueID, string WaterMarkPdfName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_CataloguePdfNameWaterMark_Update");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@PrintReadyFileWaterMark", DbType.String, WaterMarkPdfName);
            database.ExecuteNonQuery(storedProcCommand);

        }
        public virtual DataTable Select_B2B_CartItem(int CartItemID, int ProductID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Select_B2B_CartItem");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int32, CartItemID);
            database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderMangerOptions_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}