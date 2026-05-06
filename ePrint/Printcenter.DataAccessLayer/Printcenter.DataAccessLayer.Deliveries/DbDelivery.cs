using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace Printcenter.DataAccessLayer.Deliveries
{
    public class DbDelivery : DataAccess
    {
        public string str;

        public DbDelivery()
        {
        }

        public virtual long Allcn_Check(long ModuleID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_Transaction_AllcnCheck");
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void delivery_accounting_code_insert(int CompanyID, long DeliveryID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AccountingCode_InsertUpdate_DeliveryNote");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void delivery_delete(int CompanyID, long DeliveryID)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Delivery_EmailAuto_DeliveryStatus_Item(long statusid, string templatetype, string isenabled, long DeliveryID, long Companyid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Delivery_EmailAlert_AutoDeliveryStatus");
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, statusid);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, templatetype);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, isenabled);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Companyid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Delivery_EmailStatus_select(int CompanyID, int StatusID, long CheckMailSentDelID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Delivery_EmailStatus_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@CheckMailSentDeliveryID", DbType.Int64, CheckMailSentDelID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long delivery_insert(long DeliveryID, int CompanyID, long EstimateID, long ItemID, string ItemType, int CustomerID, int AttentionID, string ShippedTo, long DeliveryAddressID, string DelAddressType, string Footer, string Comments, string DeliveryNumber, DateTime DeliveryDate, string RefNo, string OrderNo, bool GoodsDelivered, int CarrierID, int CreatedBy, int StatusID, DateTime ModifiedDate, int ModifiedBy, long CurrentDelNO, string Header, DateTime TodayDate, int DeliveryToClientID, string ConsignmentNumber, string ConsigneeUrl, DateTime ActualDeliveryDate, long CostCentreID, string DeliveryNotePrefix)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_insert");
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            database.AddInParameter(storedProcCommand, "@AttentionID", DbType.Int32, AttentionID);
            database.AddInParameter(storedProcCommand, "@ShippedTo", DbType.String, ShippedTo);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DelAddressType);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@DeliveryNumber", DbType.String, DeliveryNumber);
            database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
            database.AddInParameter(storedProcCommand, "@RefNo", DbType.String, RefNo);
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.String, OrderNo);
            database.AddInParameter(storedProcCommand, "@GoodsDelivered", DbType.Boolean, GoodsDelivered);
            database.AddInParameter(storedProcCommand, "@CarrierID", DbType.Int32, CarrierID);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
            database.AddInParameter(storedProcCommand, "@CurrentDelNO", DbType.Int64, CurrentDelNO);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.DateTime, TodayDate);
            database.AddInParameter(storedProcCommand, "@DeliveryToClientID", DbType.Int32, DeliveryToClientID);
            database.AddInParameter(storedProcCommand, "@ConsignmentNumber", DbType.String, ConsignmentNumber);
            database.AddInParameter(storedProcCommand, "@ConsigneeUrl", DbType.String, ConsigneeUrl);
            database.AddInParameter(storedProcCommand, "@ActualDeliveryDate", DbType.DateTime, ActualDeliveryDate);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@DeliveryNotePrefix", DbType.String, DeliveryNotePrefix);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }
        public virtual long delivery_insert_copy(long DeliveryID, int CompanyID, long EstimateID, long ItemID, string ItemType, int CustomerID, int AttentionID, string ShippedTo, long DeliveryAddressID, string DelAddressType, string Footer, string Comments, string DeliveryNumber, DateTime DeliveryDate, string RefNo, string OrderNo, bool GoodsDelivered, int CarrierID, int CreatedBy, int StatusID, DateTime ModifiedDate, int ModifiedBy, long CurrentDelNO, string Header, DateTime TodayDate, int DeliveryToClientID, string ConsignmentNumber, string ConsigneeUrl, DateTime ActualDeliveryDate, long CostCentreID, string DeliveryNotePrefix)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_insert_copy");
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            database.AddInParameter(storedProcCommand, "@AttentionID", DbType.Int32, AttentionID);
            database.AddInParameter(storedProcCommand, "@ShippedTo", DbType.String, ShippedTo);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DelAddressType);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@DeliveryNumber", DbType.String, DeliveryNumber);
            database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
            database.AddInParameter(storedProcCommand, "@RefNo", DbType.String, RefNo);
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.String, OrderNo);
            database.AddInParameter(storedProcCommand, "@GoodsDelivered", DbType.Boolean, GoodsDelivered);
            database.AddInParameter(storedProcCommand, "@CarrierID", DbType.Int32, CarrierID);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
            database.AddInParameter(storedProcCommand, "@CurrentDelNO", DbType.Int64, CurrentDelNO);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.DateTime, TodayDate);
            database.AddInParameter(storedProcCommand, "@DeliveryToClientID", DbType.Int32, DeliveryToClientID);
            database.AddInParameter(storedProcCommand, "@ConsignmentNumber", DbType.String, ConsignmentNumber);
            database.AddInParameter(storedProcCommand, "@ConsigneeUrl", DbType.String, ConsigneeUrl);
            database.AddInParameter(storedProcCommand, "@ActualDeliveryDate", DbType.DateTime, ActualDeliveryDate);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@DeliveryNotePrefix", DbType.String, DeliveryNotePrefix);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual int delivery_items_count(int CompanyID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_items_count");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Delivery_Make_Archive(int CompanyID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_make_archive");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet delivery_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_delivery_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable delivery_search(int CompanyID, string Para)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_search");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Para", DbType.String, Para);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable delivery_select(int CompanyID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void deliveryitem_delete(int CompanyID, long DeliveryItemID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable deliveryitem_GetDeletedItemValue(int CompanyID, string DeliveryItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeletedDeliveryNoteItemTitle_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.String, DeliveryItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long deliveryitem_insert(int CompanyID, long DeliveryItemID, long DeliveryID, long EstimateID, long ItemID, string ItemType, string Quantity, string Description, long itemNo, string notes, long RepositionRowNumber,long PriceCatalogueID = 0)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.String, Quantity);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@ItemNo", DbType.Int64, itemNo);
            database.AddInParameter(storedProcCommand, "@Notest", DbType.String, notes);
            database.AddInParameter(storedProcCommand, "@RepositionRowNumber", DbType.Int64, RepositionRowNumber);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.String, num);
            DateTime now = DateTime.Now;
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual long deliveryitem_insert_withProductID(int CompanyID, long DeliveryItemID, long DeliveryID, long EstimateID, long ItemID, string ItemType, string Quantity, string Description, long PriceCatalogueID)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_insert_withProductID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.Int64, DeliveryItemID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.String, Quantity);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.String, num);
            DateTime now = DateTime.Now;
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable deliveryitem_select(int CompanyID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable deliveryitem_select_splitdelivery(int CompanyID, long EstimateItemId, long EstimateID, string ItemType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_select_splitdelivery");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemId);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable deliveryitem_selectdeletedItem(int CompanyID, string DeliveryItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliveryitem_SelectDeletedItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryItemID", DbType.String, DeliveryItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable DeliveryNote_advance_search(int CompanyID, string SearchText, int ClientID, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_deliverynote_advance_search");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@SalesPersonCondition", DbType.String, SalesPersonCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Delivery_Comments_Update(int commentId, string newComment)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_delivery_Comments_Update");
            database.AddInParameter(storedProcCommand, "@commentId", DbType.Int32, commentId);
            database.AddInParameter(storedProcCommand, "@newComment", DbType.String, newComment);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void DeliveryOnCheck_Status_Update(int CompanyID, string DeliveryIDs, int StatusID, string Module)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateOnCheck_Status_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateIDS", DbType.String, DeliveryIDs);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int32, num);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual DataTable Internal_Delivery_Email_Select(int StatusID, int companyID, string TemplateType,int DeliveryID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            Database database = CustomDatabaseFactory.CreateDatabase(str);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Internal_Delivery_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int32, DeliveryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}