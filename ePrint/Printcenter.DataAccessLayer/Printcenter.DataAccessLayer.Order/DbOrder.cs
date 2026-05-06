using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

namespace Printcenter.DataAccessLayer.Order
{
    public class DbOrder
    {
        public DbOrder()
        {
        }

        public virtual void Archive_Order(long OrderID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Archive_Order");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Order_Comments_Update(int commentId, string newComment)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Order_Comments_Update");
            database.AddInParameter(storedProcCommand, "@commentId", DbType.Int32, commentId);
            database.AddInParameter(storedProcCommand, "@newComment", DbType.String, newComment);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void CartAdditionalValues_Update(long OrderID, long OptionID, decimal TotalPrice, int SelectedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CartAdditionalValues_Update");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@OptionID", DbType.Int32, OptionID);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Company_RoundOff_Value(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_DefaultSettings_RoundOff_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void delete_Order(long OrderID, long CompanyID, long LoggedIN_UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_delete_Order");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, LoggedIN_UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Delete_OrderItems(long CompanyID, long OrderItemID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Delete_OrderItems");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Insert_OrderAdditionalItems(long OrderID, long OrderItemID, long OptionID, string Formula, decimal Markup, decimal TotalPrice, decimal SelectedID, string SelectedValue, decimal SelectedPrice, decimal MarkupValue, int SortOrderNo, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_OrderAdditionalItems");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.AddInParameter(storedProcCommand, "@OptionID", DbType.Int64, OptionID);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
            database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
            database.AddInParameter(storedProcCommand, "@SelectedPrice", DbType.Decimal, SelectedPrice);
            database.AddInParameter(storedProcCommand, "@MarkupValue", DbType.Decimal, MarkupValue);
            database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Decimal, SortOrderNo);
            database.AddInParameter(storedProcCommand, "@ParentWebOtherCostID", DbType.Int64, ParentWebOtherCostID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostType", DbType.String, WebOtherCostType);
            database.AddInParameter(storedProcCommand, "@FreeTextQuestionLong", DbType.String, FreeTextQuestionLong);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable JobInvoiceAllItemDetails_select(long ModuleID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Order_AllItemsDetails_SelectAll");
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;

            //    DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JObInvoiceAllItemDetails_select");

        }


        public virtual DataTable jobOrder_select(int CompanyID, long OrderID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_jobOrder_select]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable order_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_order_advance_search");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, Convert.ToBoolean(IsArchived));
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable order_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_order_advance_search_SplitItems");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, Convert.ToBoolean(IsArchived));
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Order_AllItemsDetails_Select(long ModuleID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Order_AllItemsDetails_SelectAll");
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Order_select(int CompanyID, long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_order_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            //storedProcCommand.CommandTimeout = 600;

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Order_select_Summary_PerItem(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Order_select_summary_PerItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OrderAdditionalOptions_Update(long OrderID, string Formula, decimal Markup, decimal TotalPrice, long SelectedID, string SelectedValue, decimal MarkupValue, int SortOrderNo, decimal SelectedPrice, long TaxID, decimal TaxPercentage, decimal TotalTaxValue)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderAdditionalOptions_Update");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@SelectedID", DbType.Int64, SelectedID);
            database.AddInParameter(storedProcCommand, "@SelectedValue", DbType.String, SelectedValue);
            database.AddInParameter(storedProcCommand, "@MarkupValue", DbType.Decimal, MarkupValue);
            database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
            database.AddInParameter(storedProcCommand, "@SelectedPrice", DbType.Decimal, SelectedPrice);
            database.AddInParameter(storedProcCommand, "@OrderAdditionalTaxID", DbType.Int64, TaxID);
            database.AddInParameter(storedProcCommand, "@OrderAdditionalTaxPercentage", DbType.Decimal, TaxPercentage);
            database.AddInParameter(storedProcCommand, "@OrderAdditionalTaxValue", DbType.Decimal, TotalTaxValue);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string OrderConvertedToJob(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderConvertedToJob_Select");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void OrderEditDetails_update(string Module, long OrderID, long EstimateID, long CompanyID, long ContactID, string ContactEmail, string ContactPhone, long DepartmentID, int CostCentrID, string Greeting, long ContactAddressID, long DeliveryAddressID, long InvoiceAddressID, string Header, string Footer, int SalesPerson, string Title, long StatusID, string OrderNumber, string Comments, DateTime DeliveryDate, DateTime InvoiceDueDate, long JobID, long InvoiceID, DateTime InvoiceDate, DateTime EstimatedArtwork, DateTime EstProofDate, DateTime EstApprovalDate, DateTime EstCompletionDate, int InvoiceContactid, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_OrderEditDetails_Update");
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            database.AddInParameter(storedProcCommand, "@ContactEmail", DbType.String, ContactEmail);
            database.AddInParameter(storedProcCommand, "@ContactPhone", DbType.String, ContactPhone);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int32, CostCentrID);
            database.AddInParameter(storedProcCommand, "@Greeting", DbType.String, Greeting);
            database.AddInParameter(storedProcCommand, "@ContactAddressID", DbType.Int64, ContactAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int64, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@SalesPerson", DbType.Int32, SalesPerson);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, Title);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, StatusID);
            database.AddInParameter(storedProcCommand, "@CustomerOrderNumber", DbType.String, OrderNumber);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
            database.AddInParameter(storedProcCommand, "@InvoiceDueDate", DbType.DateTime, InvoiceDueDate);
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.AddInParameter(storedProcCommand, "@InvoiceDate", DbType.DateTime, InvoiceDate);
            database.AddInParameter(storedProcCommand, "@LoginuserID", DbType.Int32, num);
            DateTime now = DateTime.Now;
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), Convert.ToInt32(CompanyID), num, true));


            database.AddInParameter(storedProcCommand, "@EstApprovalDate", DbType.DateTime, EstApprovalDate);
            database.AddInParameter(storedProcCommand, "@EstCompletionDate", DbType.DateTime, EstCompletionDate);
            database.AddInParameter(storedProcCommand, "@EstProofDate", DbType.DateTime, EstProofDate);
            database.AddInParameter(storedProcCommand, "@EstimatedArtwork", DbType.DateTime, EstimatedArtwork);
            database.AddInParameter(storedProcCommand, "@InvoiceContactid", DbType.Int32, InvoiceContactid);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);


            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int OrderItemApprovalStatus_Select(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderItemApprovalStatus_Select");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable OrderItemID_Select(long OrderID, long EstimateItemID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderItemID_Select");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OrderOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
        {
            long num = (long)0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateOnCheck_Status_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateIDS", DbType.String, EstimateIDs);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int32, num);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void PC_OrderAdditionalOptions_Delete(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderAdditionalOptions_Delete");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void PC_UpdateOrderAdditional_InOrders(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateOrderAdditional_InOrders");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Product_CatalogueQty_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable productsDetails_Select(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Progress_toJob(long CompanyID, long OrderID, long OrderItemID, DateTime ConvertedDate, long EstimateItemID, string IsAllConverted)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Progress_toJob");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.AddInParameter(storedProcCommand, "@ConvertedDate", DbType.DateTime, ConvertedDate);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@IsAllConverted", DbType.String, IsAllConverted);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Select_AccountID(int CompanyID, long ModuleID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AccountId_Select");
            database.AddInParameter(storedProcCommand, "@Companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Select_CampaignValues(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetCampaignName");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderAdditionalOptions(int CompanyID, long EstimateID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_OrderAdditionalOptions");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Select_OrderItems_WithAdditionalItems(long OrderItemID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_Select_OrderItems_WithAdditionalItems", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@OrderItemID", OrderItemID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }
        public virtual DataSet Select_OrderItems_WithAdditionalItems1(long OrderItemID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_Select_OrderItems_WithAdditionalItems1", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@OrderItemID", OrderItemID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }
        public virtual DataTable Select_OtherCost_AdditionalItemDetails(int CompanyID, long OrderItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_OtherCost_AdditionalItemDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
        {
            commonClass _commonClass = new commonClass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsDetail");
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID, long OrderID)
        {
            commonClass _commonClass = new commonClass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OtherCostAdditional_ItemsDetail_new");
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            database.AddInParameter(storedProcCommand, "@orderID", DbType.Int64, OrderID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
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
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
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

        public virtual DataTable Select_ProductCatalogue_Details(int CompanyID, long OrderItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Select_ProductCatalogue_Details]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ShoppingCart_AdditionalOption_Select(long CompanyID, long AccountID, string IsVisibleToCart)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
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

        public virtual DataTable Tax_Bind(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Tax_Bind");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_OrdersItems(long CompanyID, long OrderID, long OrderItemID, long ProductID, string JobName, int Quantity, decimal UnitPrice, string UploadFile, string UploadFile1, string UploadFile2, decimal MainItemPrice, decimal TaxRate, decimal MainItemMarkupPrice, decimal OrderItemTotalPrice, decimal OrderItemTax, decimal OrderItemShipping, string ItemDesc, decimal TotalMarkupPrice, long CampaignID, decimal Height, decimal Width, decimal Markup, int TaxId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_OrdersItems");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
            database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@UnitPrice", DbType.Decimal, UnitPrice);
            database.AddInParameter(storedProcCommand, "@UploadFile", DbType.String, UploadFile);
            database.AddInParameter(storedProcCommand, "@UploadFile1", DbType.String, UploadFile1);
            database.AddInParameter(storedProcCommand, "@UploadFile2", DbType.String, UploadFile2);
            database.AddInParameter(storedProcCommand, "@MainItemPrice", DbType.Decimal, MainItemPrice);
            database.AddInParameter(storedProcCommand, "@TaxRate", DbType.Decimal, TaxRate);
            database.AddInParameter(storedProcCommand, "@MainItemMarkupPrice", DbType.Decimal, MainItemMarkupPrice);
            database.AddInParameter(storedProcCommand, "@OrderItemTotalPrice", DbType.Decimal, OrderItemTotalPrice);
            database.AddInParameter(storedProcCommand, "@OrderItemTax", DbType.Decimal, OrderItemTax);
            database.AddInParameter(storedProcCommand, "@OrderItemShipping", DbType.Decimal, OrderItemShipping);
            database.AddInParameter(storedProcCommand, "@ItemDesc", DbType.String, ItemDesc);
            database.AddInParameter(storedProcCommand, "@TotalMarkupPrice", DbType.Decimal, TotalMarkupPrice);
            database.AddInParameter(storedProcCommand, "@CampaignID", DbType.Int64, CampaignID);
            database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, Height);
            database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, Width);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@TaxId", DbType.Int32, TaxId);
            database.ExecuteNonQuery(storedProcCommand);
        }
    }
}