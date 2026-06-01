using DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using Printcenter.BusinessAccessLayer.Estimates;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;

namespace Printcenter.DataAccessLayer.Estimates
{
    public class DbEstimate : DataAccess
    {
        public DbEstimate()
        {
        }

        public virtual DataTable AccountInfo_FrontEnd(string AccountName)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_AccountInformation_Select");
            database.AddInParameter(storedProcCommand, "@AccountName", DbType.String, AccountName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachment_DN_Select(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long DeliveryID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachment_DN_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachment_Duplicate_CheckChange(long EstimateID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachment_Duplicate_CheckChange");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@Filename", DbType.String, FileName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachment_Duplicate_CheckChange_ForItemSpecific(long EstimateID, long AttachmentTypeID, string AttachmentType, string FileName, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachment_Duplicate_CheckChange_ForItemSpecific");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@Filename", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachment_eStore_General_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachment_eStoreOrder_General_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachment_PO_Select(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, long PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachment_PO_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachments_eStore_General(int CompanyID, int UserID, string AttachmentType, long AttachmentTypeID, long EstimateID, string pg)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_eStore_General");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, pg);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Attachments_eStore_ItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_eStore_ItemSpecific_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Attachments_General_Delete(long AttachmentID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_General_Delete");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Attachments_ItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_ItemSpecific_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Attachments_ProofItemSpecific_Select(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType,int ProofID,int JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_ProofItemSpecific_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.String, ProofID);
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int32, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Attachments_PO_DN_Copy(long EstimateID, long EstimateItemID, long TypeID, string Attachmenttype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_PO_DN_Copy");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.String, TypeID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Attachmenttype);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Attachments_Select_For_General(int CompanyID, int UserID, string AttachmentType, long EstimateID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Attachments_Select_For_General");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable booklet_sectionID_select(int CompanyID, long EstBookletItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_booklet_sectionID_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletItemID", DbType.Int64, EstBookletItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable client_tax_select(int CompanyID, int CustomerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_client_tax_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Common_AddressSelect_PerClient(long ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Common_AddressSelect_PerClient");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long copy_booklet_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_booklet_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_estimate_bookletitem(int CompanyID, long New_EstimateItemID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_estimate_bookletitem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@New_EstimateItemID", DbType.Int64, New_EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@New_EstBookletItemID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstBookletItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_estimate_bookletsection(int CompanyID, long New_EstBookletItemID, long Old_EstBookletSectionID, long New_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_estimate_bookletsection");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@New_EstBookletItemID", DbType.Int64, New_EstBookletItemID);
            database.AddInParameter(storedProcCommand, "@Old_EstBookletSectionID", DbType.Int64, Old_EstBookletSectionID);
            database.AddInParameter(storedProcCommand, "@New_EstimateItemID", DbType.Int64, New_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@New_EstBookletSectionID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstBookletSectionID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_estimateitem(int CompanyID, long New_EstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_estimateitem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@New_EstimateID", DbType.Int64, New_EstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@New_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_large_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_large_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_other_cost(int CompanyID, long Old_EstimateItemID, long New_EstimateItemID, long Old_EstOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_other_cost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddInParameter(storedProcCommand, "@New_EstimateItemID", DbType.Int64, New_EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Old_EstOtherCostID", DbType.Int64, Old_EstOtherCostID);
            database.AddOutParameter(storedProcCommand, "@New_EstOtherCostID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstOtherCostID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_othercost_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_othercost_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual void copy_othercost_variable(int CompanyID, string Data)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_othercost_variable");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long copy_outwork_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_outwork_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_pad_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_pad_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_price_catalogue(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_price_catalogue");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual long copy_warehouse_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_warehouse_item");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual int default_tax_id(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_default_tax_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }

        public virtual int DefaultPageSize_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultSettings_PageSize_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public DataTable DeliveryNote_Attached_Select(long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_Attached_Select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable DeliveryNote_ItemID_Select(long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_ItemID_Select");
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void DeliveryNoteCarInfoUpdate(long CompanyID, long CarInfoID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_CarrierInfo_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CarInfoID", DbType.Int64, CarInfoID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void DeliveryNoteStatusUpdate(long CompanyID, long StatusID, long DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_Status_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, StatusID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet DeliveryPurchase_Check(int CompanyID, long JObID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryPurchase_Check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JOBID", DbType.Int64, JObID);
            database.AddInParameter(storedProcCommand, "@EstimateitemID", DbType.Int64, EstimateItemID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual string Digital_Press_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_digitalpress_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public DataTable DNAttachment_forPurchase(long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_selectDN_forAttachment");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable EmailAttachment_ForSupplierRFQ_Select(long EstimateID, long AttachmentTypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EmailAttachment_ForSupplierRFQ_Select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estiamte_select_type_typeid_by_estimateitemid(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estiamte_select_type_typeid_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_advance_search");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
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

        public virtual DataTable estimate_advance_search_splititems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_advance_search_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
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

        public virtual DataTable estimate_advance_search_top5(int CompanyID, string SearchText, int ClientID, string Status, string DateType, bool IsArchived, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_estimate_advance_search_top5]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Archive(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_archive");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Estimate_Booklet_Item_Insert(int CompanyID, long EstimateItemID, string Titile, string Design, string Color, string Size, string Paper, string Delivery, string Finishing, string Notes, string IsAnyWarehouseItem, string IsAnyOutwork, string IsAnyOtherCost, int CreatedBy, string ItemDescription)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_bookletitem_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ItemTitile", DbType.String, Titile);
            database.AddInParameter(storedProcCommand, "@Design", DbType.String, Design);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@Size", DbType.String, Size);
            database.AddInParameter(storedProcCommand, "@Paper", DbType.String, Paper);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, IsAnyWarehouseItem);
            database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, IsAnyOutwork);
            database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, IsAnyOtherCost);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Estimate_Booklet_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_booklet_item_edit_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Booklet_Qty_Select_On_SectionID(int CompanyID, long EstBookletSectionID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_booklet_qty_on_sectionid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Booklet_Quantity_Details_Select(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_booklet_quantity_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_Booklet_Section_Insert(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_booklet_section_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual DataTable estimate_bookletsection_select(int CompanyID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_bookletsection_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_Calculation_Insert_First(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_calculation_insert_first");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.AddOutParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, 0);
            database.ExecuteScalar(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@EstCalculationID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Estimate_ClickChargeZone_Insert_By_EstCalculationID(int CompanyID, long EstCalculationID, long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_clickchargeZone_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string estimate_contacts_select_by_clientid(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_contacts_select_by_clientid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public virtual void Estimate_Copy(int CompanyID, long EstimateID, string EstimateNumber, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateNumber", DbType.String, EstimateNumber);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Estimate_Copy_Estimate_Insert(int CompanyID, long Old_EstimateID, bool IsHandy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_copy_estimate_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateID", DbType.Int64, Old_EstimateID);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.AddOutParameter(storedProcCommand, "@New_EstimateID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@New_EstimateID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue.ToString()));
        }

        public virtual long estimate_default_digitalpress_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_default_digitalpress_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual long estimate_default_largeformatpress_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_default_largeformatpress_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual void Estimate_Delete(int CompanyID, long EstimateID)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt32(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            DateTime now = DateTime.Now;
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Estimate_Comments_Update(int commentId, string newComment)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_Comments_Update");
            database.AddInParameter(storedProcCommand, "@commentId", DbType.Int32, commentId);
            database.AddInParameter(storedProcCommand, "@newComment", DbType.String, newComment);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_DeliveryAddressID_Select(int CompanyID, long ModuleID, string Module)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_deliveryaddress_ID_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_deliverynote_selectall(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_deliverynote_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long estimate_deliverynoteid_select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_deliverynoteid_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual DataTable Estimate_Digital_Press_Select(int CompanyID, long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_press_calculation_type");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Estimate_Singlitem_By_EstimateItemID(int CompanyID, long EstimateItemID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_single_item_select_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_EstQuantity_Insert(int CompanyID, string Data)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_estquantity_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet estimate_for_item_add_all(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_for_item_add_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable Estimate_Guillotine_Select_By_ID(int CompanyID, long GuillotineID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_guillotine_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_guillotine_standard_table_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_guillotine_standard_table_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void estimate_hasdeliverynote_delete(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_hasdeliverynote_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string estimate_hasdeliverynote_select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_hasdeliverynote_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void estimate_hasdeliverynote_update(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_hasdeliverynote_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Information_By_ID(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_information_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

		public virtual long Estimate_Insert(int CompanyID, int UserID, int CustomerID, long AttentionID, string Greeting, string Company, long Address, string Header, string Footer, int SalesPerson, string EstimateTitle, string EstimateNumber, string OrderNumber, int StatusID, DateTime EstimateDate, int ValidFor, long DeliveryAddress, bool IsConvertedToJob, DateTime ModifiedDate, int ModifiedBy, long EstimateID, bool IsForInvoice, string AddressType, string DelAddressType, long CurrentEstNo, DateTime EstimatedArtwork, DateTime EstimatedDelivery, DateTime EstimateCreatedDate, bool IsDirectJob, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProdcnDate, long InvoiceAddressID, long DepartmentID, long CostCentreID, Int32 estimatorid, string Comment, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_insert_new");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
			database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
			database.AddInParameter(storedProcCommand, "@AttentionID", DbType.Int64, AttentionID);
			database.AddInParameter(storedProcCommand, "@Greeting", DbType.String, Greeting);
			database.AddInParameter(storedProcCommand, "@Company", DbType.String, Company);
			database.AddInParameter(storedProcCommand, "@Address", DbType.Int64, Address);
			database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
			database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
			database.AddInParameter(storedProcCommand, "@SalesPerson", DbType.Int32, SalesPerson);
			database.AddInParameter(storedProcCommand, "@EstimateTitle", DbType.String, EstimateTitle);
			database.AddInParameter(storedProcCommand, "@EstimateNumber", DbType.String, EstimateNumber);
			database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
			database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
			database.AddInParameter(storedProcCommand, "@EstimateDate", DbType.DateTime, EstimateDate);
			database.AddInParameter(storedProcCommand, "@ValidFor", DbType.Int32, ValidFor);
			database.AddInParameter(storedProcCommand, "@DeliveryAddress", DbType.Int64, DeliveryAddress);
			database.AddInParameter(storedProcCommand, "@IsConvertedToJob", DbType.Boolean, IsConvertedToJob);
			database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
			database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@IsForInvoice", DbType.Boolean, IsForInvoice);
			database.AddInParameter(storedProcCommand, "@AddressType", DbType.String, AddressType);
			database.AddInParameter(storedProcCommand, "@DeliveryAddressType", DbType.String, DelAddressType);
			database.AddInParameter(storedProcCommand, "@CurrentEstNo", DbType.Int64, CurrentEstNo);
			database.AddInParameter(storedProcCommand, "@EstimatedArtwork", DbType.DateTime, EstimatedArtwork);
			database.AddInParameter(storedProcCommand, "@EstimatedDelivery", DbType.DateTime, EstimatedDelivery);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, EstimateCreatedDate);
			database.AddInParameter(storedProcCommand, "@IsDirectJob", DbType.Boolean, IsDirectJob);
			database.AddInParameter(storedProcCommand, "@EstProofDate", DbType.DateTime, ProofDate);
			database.AddInParameter(storedProcCommand, "@EstApprovalDate", DbType.DateTime, ApprovalDate);
			database.AddInParameter(storedProcCommand, "@EstProductionDate", DbType.DateTime, ProdcnDate);
			database.AddInParameter(storedProcCommand, "@EstCompletionDate", DbType.DateTime, JobCompletionDate);
			database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int64, InvoiceAddressID);
			database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
			database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@EstimatorId", DbType.Int32, estimatorid);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comment);
            database.AddInParameter(storedProcCommand, "@InvoiceContactId", DbType.Int64, InvoiceContactId);
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

        public virtual DataTable Estimate_Item_ID_Select(int CompanyID, long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimateitem_id_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet estimate_item_info_select_by_qtynumber(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_info_select_by_qtynumber");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual long Estimate_Item_Insert(int CompanyID, long EstimateID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Estimate_Item_OtherCost_Cost_By_ID(int CompanyID, long EstOtherCostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_cost_view_othercost_of_cost_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Item_Outwork_by_EstimateType(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_outwork_by_type");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Item_QtyNumber_Select(int CompanyID, long ItemID, string ItemType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_quantity_number_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string estimate_item_quantity_fordelivery_select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, int QtyNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_quantity_fordelivery_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string estimate_item_type_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_type_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string Estimate_Item_Warehouse_Select_by_TypeID(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_subitem_warehouse_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int Estimate_Items_Count_Select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_items_count");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Items_Quantity_Details_Select(int CompanyID, long ItemID, string ItemType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_quantity_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Items_Quantity_Select(int CompanyID, int EstimateItemID, string EstType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate__item__quantity_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, EstType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Items_RFQdescription_Select(int CompanyID, long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_ItemRFQ_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Items_Select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate__items_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_Items_TypeID_Select(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_typeid_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Query", DbType.String, Query);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Large_Format_Press_Charge_Select(int CompanyID, long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_large_press_charge_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_LargeFormatItem_Insert(EstimateItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_largeformatitem_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@EstLargeItemID", DbType.Int64, item.EstSingleItemID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
            database.AddInParameter(storedProcCommand, "@PressType", DbType.String, item.PressType);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
            database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
            database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Double, item.SetUpSpoilage);
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Int32, item.RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
            database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
            database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
            database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
            database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Int32, item.SheetHeight);
            database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Int32, item.SheetWidth);
            database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
            database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
            database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Int32, item.JobHeight);
            database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Int32, item.JobWidth);
            database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Int32, item.GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Int32, item.GutterVertical);
            database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
            database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
            database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Int32, item.PortraitValue);
            database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Int32, item.LandscapeValue);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
            database.AddInParameter(storedProcCommand, "@PrintQuality", DbType.String, item.PrintQuality);
            database.AddInParameter(storedProcCommand, "@InkCoverageSide1", DbType.Decimal, item.InkCoverageSide1);
            database.AddInParameter(storedProcCommand, "@InkCoverageSide2", DbType.Decimal, item.InkCoverageSide2);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddInParameter(storedProcCommand, "@Design", DbType.String, item.Design);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, item.Color);
            database.AddInParameter(storedProcCommand, "@Size", DbType.String, item.Size);
            database.AddInParameter(storedProcCommand, "@Paper", DbType.String, item.PaperDesc);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, item.Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, item.Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, item.Notes);
            database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
            database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
            database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
            database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
            database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual string estimate_largeitem_paperproperties_select(int CompanyID, long InventoryID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_largeitem_paperproperties_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable estimate_othercost_by_id(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_othercost_description_select(int CompanyID, string EstimateType, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_description_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long estimate_othercost_insert(int CompanyID, long EstOtherCostID, string EstimateType, long TypeID, long EstimateItemID, long OtherCostID, string CalculationType, decimal HoursOrQty, decimal HourlyRate, decimal UnitRate, decimal SetUpTime, decimal HourlyRunSpeed, decimal Passes, decimal Cost, decimal MinimumCost, decimal Markup, string ItemTitle, string Design, string Delivery, string Finishing, string Notes, decimal ProfitMargin, decimal SubTotal, decimal Tax, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, string ItemDescription, string Formula, string FormulaTag, long EstBookletSectionID, int SectionNo, decimal Cost1, decimal Cost2, decimal Cost3, decimal Markup1, decimal Markup2, decimal Markup3, string FormulaTag1, string FormulaTag2, string FormulaTag3, decimal UnitRate1, decimal UnitRate2, decimal UnitRate3, decimal HoursOrQty1, decimal HoursOrQty2, decimal HoursOrQty3, int TaxID, long oldOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@HoursOrQty", DbType.Decimal, HoursOrQty);
            database.AddInParameter(storedProcCommand, "@HourlyRate", DbType.Decimal, HourlyRate);
            database.AddInParameter(storedProcCommand, "@UnitRate", DbType.Decimal, UnitRate);
            database.AddInParameter(storedProcCommand, "@SetUpTime", DbType.Decimal, SetUpTime);
            database.AddInParameter(storedProcCommand, "@HourlyRunSpeed", DbType.Decimal, HourlyRunSpeed);
            database.AddInParameter(storedProcCommand, "@Passes", DbType.Decimal, Passes);
            database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Cost);
            database.AddInParameter(storedProcCommand, "@MinimumCost", DbType.Decimal, MinimumCost);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@Design", DbType.String, Design);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, ModifiedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FormulaTag", DbType.String, FormulaTag);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            database.AddInParameter(storedProcCommand, "@SectionNo", DbType.Int16, SectionNo);
            database.AddInParameter(storedProcCommand, "@Cost1", DbType.Decimal, Cost1);
            database.AddInParameter(storedProcCommand, "@Cost2", DbType.Decimal, Cost2);
            database.AddInParameter(storedProcCommand, "@Cost3", DbType.Decimal, Cost3);
            database.AddInParameter(storedProcCommand, "@Markup1", DbType.Decimal, Markup1);
            database.AddInParameter(storedProcCommand, "@Markup2", DbType.Decimal, Markup2);
            database.AddInParameter(storedProcCommand, "@Markup3", DbType.Decimal, Markup3);
            database.AddInParameter(storedProcCommand, "@FormulaTag1", DbType.String, FormulaTag1);
            database.AddInParameter(storedProcCommand, "@FormulaTag2", DbType.String, FormulaTag2);
            database.AddInParameter(storedProcCommand, "@FormulaTag3", DbType.String, FormulaTag3);
            database.AddInParameter(storedProcCommand, "@UnitRate1", DbType.Decimal, UnitRate1);
            database.AddInParameter(storedProcCommand, "@UnitRate2", DbType.Decimal, UnitRate2);
            database.AddInParameter(storedProcCommand, "@UnitRate3", DbType.Decimal, UnitRate3);
            database.AddInParameter(storedProcCommand, "@HoursOrQty1", DbType.Decimal, HoursOrQty1);
            database.AddInParameter(storedProcCommand, "@HoursOrQty2", DbType.Decimal, HoursOrQty2);
            database.AddInParameter(storedProcCommand, "@HoursOrQty3", DbType.Decimal, HoursOrQty3);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            database.AddInParameter(storedProcCommand, "@OldOthercost", DbType.Int64, oldOtherCostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable get_estimate_othercost(long TypeID, long EstimateItemID, long OtherCostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_estimate_othercost");
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int32, TypeID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.String, OtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Estimate_OtherCost_Qty_Details_Select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_othercost_qty_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_OtherCost_Quantity_Details_Select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_othercost_quantity_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string estimate_othercost_select(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string estimate_othercost_select_by_categoryid(int CompanyID, int OtherCostCategoryID, string ParentEstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_select_by_categoryid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int32, OtherCostCategoryID);
            database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentEstimateType);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public virtual string estimate_othercost_select_category(int CompanyID, string ParentEstimateType, bool IsOtherCostSequence)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_select_category");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ParentItemType", DbType.String, ParentEstimateType);
            database.AddInParameter(storedProcCommand, "@IsOtherCostSequence", DbType.Boolean, IsOtherCostSequence);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void estimate_othercost_variableqty_delete(int CompanyID, long EstOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_variableqty_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long estimate_othercost_variableqty_insert(int CompanyID, long EstOtherCostVariableID, long EstOtherCostID, long EstQuantityID, decimal HoursOrQty, decimal Cost, string EstType, string FormulaWithActual)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_variableqty_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostVariableID", DbType.Int64, EstOtherCostVariableID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            database.AddInParameter(storedProcCommand, "@EstQuantityID", DbType.Int64, EstQuantityID);
            database.AddInParameter(storedProcCommand, "@HoursOrQty", DbType.Decimal, HoursOrQty);
            database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Cost);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstType);
            database.AddInParameter(storedProcCommand, "@FormulaWithActual", DbType.String, FormulaWithActual);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual string estimate_othercost_variableqty_select(int CompanyID, long EstOthercostID, long EstQuantityID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_variableqty_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOthercostID", DbType.Int64, EstOthercostID);
            database.AddInParameter(storedProcCommand, "@EstQuantityID", DbType.Int64, EstQuantityID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_OtherCost_View_By_EstOtherCostID(int CompanyID, long EstOtherCostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_othercost_item_select_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Outwork_By_ID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_outwork_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Estimate_Outwork_Delete(int CompanyID, long OutworkID, string OutworkType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_sub_item_outwork_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OutworkID", DbType.Int64, OutworkID);
            database.AddInParameter(storedProcCommand, "@OutworkType", DbType.String, OutworkType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Estimate_Outwork_Insert(int CompanyID, string Query, string IsPrintEmail, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_outwork_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.AddInParameter(storedProcCommand, "@IsPrintEmail", DbType.String, IsPrintEmail);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual string estimate_outwork_itemdescription_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_outwork_itemdescription_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Outwork_Quantity_Details_Select(int CompanyID, long EstOutworkID, int QtyNumber)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_item_outwork_quantity_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_PadItem_Insert(EstimateItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_paditem_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@EstPadItemID", DbType.Int64, item.EstSingleItemID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
            database.AddInParameter(storedProcCommand, "@PressType", DbType.String, item.PressType);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
            database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
            database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Int32, Convert.ToInt32(item.SetUpSpoilage));
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Int32, item.RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@LeavesPerPad", DbType.Int32, item.LeavesPerPad);
            database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
            database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
            database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
            database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
            database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Int32, item.SheetHeight);
            database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Int32, item.SheetWidth);
            database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
            database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
            database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Int32, item.JobHeight);
            database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Int32, item.JobWidth);
            database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Int32, item.GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Int32, item.GutterVertical);
            database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
            database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
            database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Int32, item.PortraitValue);
            database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Int32, item.LandscapeValue);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddInParameter(storedProcCommand, "@Design", DbType.String, item.Design);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, item.Color);
            database.AddInParameter(storedProcCommand, "@Size", DbType.String, item.Size);
            database.AddInParameter(storedProcCommand, "@Paper", DbType.String, item.PaperDesc);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, item.Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, item.Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, item.Notes);
            database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
            database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
            database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
            database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
            database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
            database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual string estimate_paperproperties_select(int CompanyID, long InventoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_paperproperties_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable estimate_printbroker_headerfooter_select(int CompanyID, string EstType, long TypeID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_estimate_printbroker_headerfooter_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstType", DbType.String, EstType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_printbroker_item_outwork_quantity_details_select(int CompanyID, long EstOutworkID, int QtyNumber, int SupplierID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_item_outwork_quantity_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_printbroker_item_quantity_number_select(int CompanyID, long ItemID, string ItemType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_item_quantity_number_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable estimate_printbroker_suppliers_count(int CompanyID, string Estype, long TypeID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_printbroker_suppliers_count");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Esttype", DbType.String, Estype);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_Quantity_Insert(int CompanyID, string ItemType, long ItemID, string QtyType, int Qty1, int Qty2, int Qty3, int Qty4, int Qty5)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_quantity_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@QtyType", DbType.String, QtyType);
            database.AddInParameter(storedProcCommand, "@Qty1", DbType.Int32, Qty1);
            database.AddInParameter(storedProcCommand, "@Qty2", DbType.Int32, Qty2);
            database.AddInParameter(storedProcCommand, "@Qty3", DbType.Int32, Qty3);
            database.AddInParameter(storedProcCommand, "@Qty4", DbType.Int32, Qty4);
            database.AddInParameter(storedProcCommand, "@Qty5", DbType.Int32, Qty5);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Estimate_Quantity_Select_By_ID(int CompanyID, string EstimateType, long ItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_quantity_select_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Quantity_Select_By_QtyNo(int CompanyID, string EstimateType, long ItemID, short QtyNo)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_quantity_select_by_QtyNo");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@QtyNo", DbType.Int16, QtyNo);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Select_All(int CompanyID, string Para)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Para", DbType.String, Para);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Select_By_EstimateID_New(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_select_EstimateId");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Single_Item_Calculation_Insert(int CompanyID, long EstimateItemID, decimal PaperUnitPrice, decimal PaperWeight, decimal PaperMarkup, decimal OneSqCmInkCost, decimal InkMarkup, decimal LookUpCostPerClick, decimal SpeedHourlyRate, int PagesPerMinute, decimal LargeHourlyRate, int LargePrintPerHour, decimal PressSetupCharge, decimal PressMinimumRunningCharge, decimal PressMarkUp, decimal GuillotineSetupCharge, decimal GuillotineMinimumRunningCharge, decimal GuillotineMarkUp, decimal CostPerCut, decimal GuillotinePaperWeight, int GuillotineMaximumThroat)
        {
        }

        public virtual string Estimate_Single_Item_Outwork_by_ID_Select(int CompanyID, long EstItemOutworkID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_single_item_outwork_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstItemOutworkID", DbType.Int64, EstItemOutworkID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Single_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_single_item_select_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Estimate_SingleItem_Insert(EstimateItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_singleitem_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@EstSingleItemID", DbType.Int64, item.EstSingleItemID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, item.EstimateItemID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, item.PressID);
            database.AddInParameter(storedProcCommand, "@PressType", DbType.String, item.PressType);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, item.PaperID);
            database.AddInParameter(storedProcCommand, "@IsPricePerPack", DbType.Boolean, item.IsPricePerPack);
            database.AddInParameter(storedProcCommand, "@IsPaperSupplied", DbType.Boolean, item.IsPaperSupplied);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Int32, Convert.ToInt32(item.SetUpSpoilage));
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Int32, item.RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
            database.AddInParameter(storedProcCommand, "@IsDoubleSided", DbType.Boolean, item.IsDoubleSided);
            database.AddInParameter(storedProcCommand, "@PrintSheetSizeID", DbType.Int32, item.PrintSheetSizeID);
            database.AddInParameter(storedProcCommand, "@IsSheetCustom", DbType.Boolean, item.IsSheetCustom);
            database.AddInParameter(storedProcCommand, "@SheetHeight", DbType.Int32, item.SheetHeight);
            database.AddInParameter(storedProcCommand, "@SheetWidth", DbType.Int32, item.SheetWidth);
            database.AddInParameter(storedProcCommand, "@JobFlatSizeID", DbType.Int32, item.JobFlatSizeID);
            database.AddInParameter(storedProcCommand, "@IsJobCustom", DbType.Boolean, item.IsJobCustom);
            database.AddInParameter(storedProcCommand, "@JobHeight", DbType.Int32, item.JobHeight);
            database.AddInParameter(storedProcCommand, "@JobWidth", DbType.Int32, item.JobWidth);
            database.AddInParameter(storedProcCommand, "@IsIncludeGutters", DbType.Boolean, item.IsIncludeGutters);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Int32, item.GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Int32, item.GutterVertical);
            database.AddInParameter(storedProcCommand, "@IsPressRestrictions", DbType.Boolean, item.IsPressRestrictions);
            database.AddInParameter(storedProcCommand, "@PrintLayout", DbType.String, item.PrintLayout);
            database.AddInParameter(storedProcCommand, "@PortraitValue", DbType.Int32, item.PortraitValue);
            database.AddInParameter(storedProcCommand, "@LandscapeValue", DbType.Int32, item.LandscapeValue);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, item.GuillotineID);
            database.AddInParameter(storedProcCommand, "@Design", DbType.String, item.Design);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, item.Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, item.Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, item.Notes);
            database.AddInParameter(storedProcCommand, "@IsAnyWarehouseItem", DbType.String, item.IsAnyWarehouseItem);
            database.AddInParameter(storedProcCommand, "@IsAnyOutwork", DbType.String, item.IsAnyOutwork);
            database.AddInParameter(storedProcCommand, "@IsAnyOtherCost", DbType.String, item.IsAnyOtherCost);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, item.CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int32, item.ModifiedBy);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, item.ModifiedDate);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddInParameter(storedProcCommand, "@SectionRef", DbType.String, item.SectionRef);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, item.ItemDescription);
            database.AddInParameter(storedProcCommand, "@IsFirstTrim", DbType.Boolean, item.IsFirstTrim);
            database.AddInParameter(storedProcCommand, "@IsSecondTrim", DbType.Boolean, item.IsSecondTrim);
            database.AddInParameter(storedProcCommand, "@SideColor", DbType.String, item.SideColor);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Estimate_SingleItem_Outwork_Insert(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_subitem_outwork_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Estimate_SingleItem_Warehouse_Insert(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_subitem_warehouse_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual long Estimate_SpeedWeight_Insert_BY_ID(int CompanyID, long EstimateItemID, long PressID, long EstSpeedWeightID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_speedweight_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            database.AddInParameter(storedProcCommand, "@EstSpeedWeightID", DbType.Int64, EstSpeedWeightID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Estimate_Status_Update(int CompanyID, long EstimateID, int StatusID, string ModuleType, long ModuleID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_status_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int32, ModuleID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void Proof_Status_Update(int CompanyID, int StatusID, string ModuleType, long ModuleID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_proof_status_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int32, ModuleID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void Proof_ItemStatus_Update(int CompanyID,long EstimateItemID, int StatusID, string ModuleType, long ModuleID, int ProofItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_proof_itemstatus_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int32, ModuleID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int32, ProofItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Estimate_Summary_Booklet_Data(int CompanyID, long EstBookletSectionID, long EstBookletQty)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_booklet_data");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            database.AddInParameter(storedProcCommand, "@EstBookletQty", DbType.Int64, EstBookletQty);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Booklet_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_booklet_item_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Summary_Booklet_Qty_by_SectionID(int CompanyID, long EstBookletSectionID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_select_booklet_qty_by_section_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Estimate_Summary_Booklet_Update(int CompanyID, string data)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_booklet_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, data);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Calculation_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID, long EstBookletSectionID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_calculation_select_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_ClickChargeZone_Select_By_ID(int CompanyID, long EstCalculationID, decimal TotalSheets, string ZoneType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_zone_range_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@TotalSheets", DbType.Decimal, TotalSheets);
            database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Estimate_Summary_EstimateValues_Update(int CompanyID, long EstimateID, double EstimateValue)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_estimate_values_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateValue", DbType.Double, EstimateValue);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual decimal Estimate_Summary_Guillotine_Standard_Table(int CompanyID, decimal Printlayout, string IsGutter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_guilllotine_standard_cut");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Printlayout", DbType.Decimal, Printlayout);
            database.AddInParameter(storedProcCommand, "@IsGutter", DbType.String, IsGutter);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? new decimal(0) : decimal.Parse(obj.ToString()));
        }

        public virtual DataTable Estimate_Summary_Item_Cost_View_Qtys_And_Cal(int CompanyID, long EstimateItemID, long TypeID, string EstType, long EstBookletSectionID, string SpType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_cost_qty_and_cal");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@EstType", DbType.String, EstType);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            database.AddInParameter(storedProcCommand, "@SpType", DbType.String, SpType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Item_Cost_View_Qtys_And_Cal_Book(int CompanyID, long EstBookletSectionID, string SpType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_cost_qty_and_cal_for_book");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            database.AddInParameter(storedProcCommand, "@SpType", DbType.String, SpType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Summary_Item_Delete(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_delete_item_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Estimate_Summary_Item_Markup_Update(int CompanyID, long PrimaryKeyID, decimal Markup, string ItemType, decimal TotalPrice)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_markup_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PrimaryKeyID", DbType.Int64, PrimaryKeyID);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Estimate_Summary_Item_OtherQuantities_Markup_Update(long PrimaryKeyID, decimal Markup2, decimal Markup3, decimal Markup4)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_EstWarehouseOtherQuantities");
            database.AddInParameter(storedProcCommand, "@Markup2", DbType.Decimal, Markup2);
            database.AddInParameter(storedProcCommand, "@Markup3", DbType.Decimal, Markup3);
            database.AddInParameter(storedProcCommand, "@Markup4", DbType.Decimal, Markup4);

            database.AddInParameter(storedProcCommand, "@PrimaryKeyID", DbType.Int64, PrimaryKeyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Item_OtherCost_select(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_othercost_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Summary_Item_Outwork_Cost(int CompanyID, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_outwork_cost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Item_Outwork_select(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_outwork_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Summary_Item_Warehouse_Cost(int CompanyID, long TypeID, string ItemType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_warehouse_cost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Item_Warehouse_select(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_warehouseitem_cost_view_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Items_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Items_select_by_JobInvoiceID(int CompanyID, string Module, long ID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_items_select_by_JobInvoiceID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        ///Added by Amin


        public virtual Int32 PC_select_JobLocking_Status(long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("SELECT ISNULL( tb_job.IsJobLocked,0) as IsJobLocked from tb_job where jobid= ", ID));
            long num = (long)database.ExecuteScalar(sqlStringCommand);
            return (Int32)database.ExecuteScalar(sqlStringCommand);
        }


        public virtual void PC_update_JobLocking_Status(long ID, Boolean Status)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_JobLocking_Status");
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Double, ID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        //End added by Amin

        public virtual DataTable Estimate_Summary_Large_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_large_item_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Summary_OtherCost_Cost_Select(int CompanyID, long EstQuantityID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_othercost_cost_select_qty_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstQuantityID", DbType.Int64, EstQuantityID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Estimate_Summary_OtherCost_Remove(int CompanyID, long EstOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_othercost_remove");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Double, EstOtherCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_OtherCost_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_othercost_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Summary_OtherCost_SubTotal_Update(int CompanyID, long EstimateItemID, decimal ProfitMargin, decimal SubTotal, decimal Tax, string ItemTitle, int TaxID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_othercost_subtotal_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Decimal, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_select_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_1(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_select_by_estimateitemid_1");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_2(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_select_by_estimateitemid_2");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_Outwork_Select_By_EstimateItemID_3(int CompanyID, long EstOutworkID, int SupplierID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_select_by_estimateitemid_3");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOutworkID", DbType.Int64, EstOutworkID);
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Summary_Outwork_Update(int CompanyID, long EstOutworkSupplierID, string ItemTitle, decimal Tax, decimal ProfitMargin, decimal SubTotal, int TaxID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_outwork_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstOutworkSupplierID", DbType.Int64, EstOutworkSupplierID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Pad_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_pad_item_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Summary_Single_Item_Update(int CompanyID, string Data)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_SingleItemTitle_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_SpeedWeight_Select_By_ID(int CompanyID, long EstSpeedWeightID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_speedweight_select_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstSpeedWeightID", DbType.Int64, EstSpeedWeightID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_SubItem_OtherCost(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_item_othercost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimate_Summary_SubTotal_Select(int CompanyID, long ItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_subtotal_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Estimate_Summary_Tax_Bind(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_tax_bind");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable estimate_summary_tax_bind_2(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_tax_bind_2");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string estimate_summary_tax_bind_3(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_tax_bind_3");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public virtual decimal Estimate_Summary_TaxRate(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_taxrate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? new decimal(0) : decimal.Parse(obj.ToString()));
        }

        public virtual void Estimate_Summary_Update(int CompanyID, long ItemID, decimal ProfitMargin, decimal SubTotal1, decimal SubTotal2, decimal SubTotal3, decimal SubTotal4)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@SubTotal1", DbType.Decimal, SubTotal1);
            database.AddInParameter(storedProcCommand, "@SubTotal2", DbType.Decimal, SubTotal2);
            database.AddInParameter(storedProcCommand, "@SubTotal3", DbType.Decimal, SubTotal3);
            database.AddInParameter(storedProcCommand, "@SubTotal4", DbType.Decimal, SubTotal4);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Estimate_Summary_Warehouse_Delete(int CompanyID, long EstWarehouseItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_warehouse_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstWarehouseItemID", DbType.Int64, EstWarehouseItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Estimate_Summary_Warehouse_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_warehouse_select_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Summary_Warehouse_SubTotal_Slect_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_warehouse_subtotal_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_Summary_Warehouse_SubTotal_Update(int CompanyID, long EstimateItemID, decimal ProfitMargin, decimal SubTotal, decimal Tax, string ItemTitle, int TaxID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_summary_warehouse_subtotal_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void estimate_tojob_headerfooter_update(int CompanyID, long EstimateID, string Header, string Footer)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_tojob_headerfooter_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable estimate_type_info_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_type_info_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Estimate_UnArchive(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_unarchive");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Estimate_ViewNameduplicacy_check(int CompanyID, string ViewName, int ViewID, string pagename)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_ViewNameduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ViewName", DbType.String, ViewName);
            database.AddInParameter(storedProcCommand, "@ViewID", DbType.Int32, ViewID);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, pagename);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void Estimate_Warehouse_Insert(int CompanyID, string Query)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_warehouse_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Query);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Estimate_Warehouse_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_warehouse_item_select_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void estimate_warehouseqty_update(int CompanyID, long WarehouseItemID, string WarehouseItemType, decimal AllocatedQty, string ProgressRevertType, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_warehouseqty_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WarehouseItemID", DbType.Int64, WarehouseItemID);
            database.AddInParameter(storedProcCommand, "@WarehouseItemType", DbType.String, WarehouseItemType);
            database.AddInParameter(storedProcCommand, "@AllocatedQty", DbType.Decimal, AllocatedQty);
            database.AddInParameter(storedProcCommand, "@ProgressRevertType", DbType.String, ProgressRevertType);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable estimate_zone_2nd_calculation(int CompanyID, long EstCalculationID, decimal TotalSheets, string ZoneType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_zone_2nd_calculation");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@TotalSheets", DbType.Decimal, TotalSheets);
            database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable EstimateItemID_Select(int CompanyID, int UserID, long PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItemID_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable EstimateItemID_Select_eStore(int CompanyID, int UserID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItemID_Select_eStore");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void EstimateOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
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

        public virtual void EstimateQuoteDetails_Update_ByAdmin_Unselect(string EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateQuoteDetails_Update_ByAdmin_Unselect");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, Convert.ToInt64(EstimateItemID));
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void estimates_attachment_delete(int CompanyID, long AttachmentID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_attachment_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable estimates_attachment_select(int CompanyID, long AttachmentTypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_attachment_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int32, AttachmentTypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int estimates_customview_count(int CompanyID, string PageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_customview_count");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual decimal estimates_estcalculation_select(int CompanyID, long EstCalculationID, string EstCalType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_estcalculation_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@EstCalType", DbType.String, EstCalType);
            return (decimal)database.ExecuteScalar(storedProcCommand);
        }

        public virtual long estimates_estcalculation_update(int CompanyID, long EstCalculationID, decimal Markup, string EstCalType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_estcalculation_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@EstCalType", DbType.String, EstCalType);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? (long)0 : long.Parse(obj.ToString()));
        }

        public virtual DataTable estimates_notes_select(int CompanyID, string ModuleType, long ModuleID, string NotesType)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_notes_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@NotesType", DbType.String, NotesType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Description"] != null)
                {
                    row["Description"] = baseClass.SpecialDecode(row["Description"].ToString());
                }
                row["CreateUser"] = baseClass.SpecialDecode(row["CreateUser"].ToString());
            }
            return dataTable;
        }

        public virtual DataTable estimates_notes_select_PerItem(int CompanyID, string ModuleType, long ModuleID, string NotesType, long ItemID)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_notes_select_PerItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ItemID", DbType.Int64, ItemID);
            database.AddInParameter(storedProcCommand, "@NotesType", DbType.String, NotesType);
            storedProcCommand.CommandTimeout = int.MaxValue;
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Description"] != null)
                {
                    row["Description"] = baseClass.SpecialDecode(row["Description"].ToString());
                }
                row["CreateUser"] = baseClass.SpecialDecode(row["CreateUser"].ToString());
            }
            return dataTable;
        }

        public virtual DataTable estimates_notestag_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_notestag_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual IDataReader estimates_number_estid_select(int CompanyID, string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_number_estid_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual string estimates_othercost_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_othercost_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string estimates_quantity_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_quantity_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable estimates_systemnotes_select(int CompanyID, string NotesTag)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_systemnotes_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@NotesTag", DbType.String, NotesTag);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Estimates_ViewName_Select_By_ID(int CompanyID, long ViewID, string Pagename)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimates_ViewName_select_By_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ViewID", DbType.Int64, ViewID);
            database.AddInParameter(storedProcCommand, "@Pagename", DbType.String, Pagename);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual bool EstPriceCatalogue_IsBackOrder_Check(long PriceCatalogueID, int Quantity, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_PriceCat_Add_IsBackOrder_Check");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int etimates_attachment_insert(EstimateItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_etimates_attachment_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, item.AttachmentID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, item.AttachmentType);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, item.AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, item.FileName);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, item.EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, item.ModuleType);
            database.AddInParameter(storedProcCommand, "@UploadedBy", DbType.Int32, item.UploadedBy);
            database.AddInParameter(storedProcCommand, "@IsDisplayToEstore", DbType.Boolean, item.IsDisplayToEstore);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, item.OriginalFileName);
            database.AddInParameter(storedProcCommand, "@ReportFile", DbType.String, item.ReportFile);
            database.AddInParameter(storedProcCommand, "@isDisplayInJobEstimate", DbType.Boolean, item.IsDisplayToPdf);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int etimates_notes_insert(string CompanyID, string NotesID, string ModuleType, string ModuleID, string Type, string ErrorType, string NotesType, string Description, string CreatedBy, string CreatedDate, string ItemId)
        {
            return 1;
        }

        public virtual void etimates_tempattachment_delete(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_tempattachment_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int etimates_tempattachment_insert(int CompanyID, long TempEstAttachmentID, int UserID, string ItemNo, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_etimates_tempattachment_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TempEstAttachmentID", DbType.Int64, TempEstAttachmentID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@ItemNo", DbType.String, ItemNo);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable etimates_tempattachment_selectall(int CompanyID, int UserID, string ItemNo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_tempattachment_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@ItemNo", DbType.String, ItemNo);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Get_Client_PaymentTerms(long ClientID)
        {
            int num;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentTermDays_Select");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            try
            {
                num = (int)database.ExecuteScalar(storedProcCommand);
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public virtual DataTable GetCostCentre_Autofill(int CompamyID, int ClientID, int DepartmentID, int ContactID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CostCentreAutoFill_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompamyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int32, DepartmentID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int32, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Ink_Information_By_LargeItem_ID(int CompanyID, long EstLargeItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ink_info_by_largeitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstLargeItemID", DbType.Int64, EstLargeItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Insert_EmailAttachment(long EstimateID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_EmailAttachment_General");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Insert_EmailAttachment_ItemSpecific(long EstimateID, long AttachmentTypeID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_EmailAttachment_ItemSpecific");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Insert_EmailAttachment_ItemSpecific_SupplierRFQ(long EstimateID, long AttachmentTypeID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_EmailAttachment_ItemSpecific_SupplierRFQ");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, 0);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Insert_EmailAttachment_SupplierRFQ(long EstimateID, long AttachmentTypeID, string FileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_EmailAttachment_SupplierRFQ");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable Invoice_ItemDescn_EstimateNum_Select(int CompanyID, int UserID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_ItemDescn_EstimateNum_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Invoice_Purchase_QuickLinks_Select(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_Purchase_QuickLinks_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Item_Other_Cost_By_ID(int CompanyID, long EstimateItemID, int QuantityID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_othercost_by_qty_id ");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int32, QuantityID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable item_othercost_by_qty_id_new_qtynumber(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID, int QtyNumber)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_othercost_by_qty_id_new_qtynumber");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable job_card_info_select_by_estimateid(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_info_select_by_estimateid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable job_card_info_select_by_estimateid_With_Subitem(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_info_select_by_estimateid_With_Subitem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable job_card_info_select_by_estimateid_new_RaisePO(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_info_select_by_estimateid_new_RaisePO");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable job_card_info_select_by_OrderID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_card_info_select_by_Orderid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable job_details_oncustomerid_select(int CompanyID, int CustomerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_job_details_oncustomerid_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable JobDeliveryNote_Details_Select(int CompanyID, int CustomerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobDeliveryNote_Select");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@Clientid", DbType.Int32, CustomerID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Jobs_Jobcard_Jobdetails_selectByEstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_JobInvoiceDetails_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int KeyCode_Check(string KeyCode)
        {
            SqlCommand sqlCommand = new SqlCommand("[pc_Estimates_CheckKeyCode]", (new commonClass()).openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@KeyCode", KeyCode);
            return (int)sqlCommand.ExecuteScalar();
        }

        public virtual string LargeFormat_Press_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_largeformat_press_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string Material_Calculation(long CompanyID, long PaperID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Material_calculation_by_id]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void NoticationSeen_insert(long UserID, long NotificationID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_NoticationSeen_insert");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@NotificationID", DbType.Int64, NotificationID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int NoticationSeen_select(long UserID, long NotificationID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_NoticationSeen_select");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@NotificationID", DbType.Int64, NotificationID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Notification_select(string VersionNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Notification_select");
            database.AddInParameter(storedProcCommand, "@VersionNumber", DbType.String, VersionNumber);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable other_cost_select_by_itemid(int CompanyID, long Old_EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_other_cost_select_by_itemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable othercost_all_cost_by_estimateitem_id(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_all_cost_by_estimateitem_id ");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void othercost_formula_value_update(int CompanyID, long EstimateItemID, string FormulaWithActualValue)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_formula_value_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@FormulaWithActualValue", DbType.String, FormulaWithActualValue);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable othercost_select_by_bookletsection(int CompanyID, long EstBookletSectionID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_select_by_bookletsection");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable othercost_subitem_by_sectionid(int CompanyID, long EstimateItemID, long QuantityID, long EstBookletSectionID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_subitem_by_sectionid ");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int64, QuantityID);
            database.AddInParameter(storedProcCommand, "@EstBookletSectionID", DbType.Int64, EstBookletSectionID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherCost_SubItem_Select_By_EstOtherCostID(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_othercost_by_qty_id_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@EstOtherCostID", DbType.Int64, EstOtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherMultiple_product_Select(int CompanyID, long PriceCatalogueID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultiple_product_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable outwork_select_qty(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_outwork_select_qty");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable outwork_supplier_select_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_outwork_supplier_select_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OutworkItemAttachmentUpdate(int CompanyID, int UserID, long ModuleID, long EstimateItemID, char EstimateType, string Filename, string ModuleType, string DeleteFiles, string OnLoadArtworkFileDeleted)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OutworkItemAttachmentUpdate");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@EstimateitemID", DbType.String, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, Filename);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@DeletFiles", DbType.String, DeleteFiles);
            database.AddInParameter(storedProcCommand, "@OnLoadArtworkFileDeleted", DbType.String, OnLoadArtworkFileDeleted);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_estimate_PageText", sqlConnection);
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

        public virtual string Paper_Calculation(int CompanyID, int PaperID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_paper_calculation_by_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int32, PaperID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string Paper_Size_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_paper_size_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string PC_estimates_othercost_select_byOtherCostID(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimates_othercost_select_byOtherCostID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet PC_QuickLinkDetails_Select(int CompanyID, long ModuleID, string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_QuickLinkDetails_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, Module);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void price_catalogue_insert(int CompanyID, string Data, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        ///Warehosue Modification By Bilal
        public virtual void Stock_Replenishment_insert(int CompanyID, string Data, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stock_Replenishment_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void price_catalogue_markup_update(int CompanyID, long EstPriceCatalogueID, decimal Markup)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_markup_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstPriceCatalogueID", DbType.Int64, EstPriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void price_catalogue_Price_update(int CompanyID, long EstPriceCatalogueID, decimal Price)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_price_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstPriceCatalogueID", DbType.Int64, EstPriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable price_catalogue_select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable price_catalogue_select_by_estimateitem_id(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select_by_estimateitem_id");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable price_catalogue_select_by_id(int CompanyID, long PriceCatalogueID, char Drawstockfrom)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select_by_id_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@DrawStockFrom", DbType.String, Drawstockfrom);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet price_catalogue_select_search(int CompanyID, string QueryType, int CustomerID, string CustomerName, string ItemTitle, string Description, int PageSize, int PageNumber, string SortExpression, string SortDirection, string Webstore, string WhereConditionEstimateProdouct)
        {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_select_search_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@QueryType", DbType.String, QueryType);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            database.AddInParameter(storedProcCommand, "@CustomerName", DbType.String, CustomerName);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, PageSize);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, PageNumber);
            database.AddInParameter(storedProcCommand, "@SortExpression", DbType.String, SortExpression);
            database.AddInParameter(storedProcCommand, "@SortDirection", DbType.String, SortDirection);
            database.AddInParameter(storedProcCommand, "@Webstore", DbType.String, Webstore);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereConditionEstimateProdouct);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void price_catalogue_summary_update(int CompanyID, long EstimateItemID, string ItemTitle, decimal SubTotal, decimal ProfitMargin, decimal Tax, long EstPriceCatalogueID, int TaxID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_summary_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@SubTotal", DbType.Decimal, SubTotal);
            database.AddInParameter(storedProcCommand, "@ProfitMargin", DbType.Decimal, ProfitMargin);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@EstPriceCatalogueID", DbType.Int64, EstPriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable PrintBroker_SubItem_Select_By_Quantity(int CompanyID, string EstimateType, long TypeID, int Quantity)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_item_printbroker_select_by_qty ");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProductAdditional_Price_Select(long EstimateID, long EstimateItemID, string pgType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductAdditional_Price_Select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, pgType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Profit_Margin_By_Client_System(int CompanyID, long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_profit_margin_select_by_estimateid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual bool ProgressToJob_IsBackOrder_Check(long EstimateItemID, int QtyNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProgressToJob_IsBackOrder_Check");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@QtyNumber", DbType.Int32, QtyNumber);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public DataTable Purchase_PurchaseID_Select(long EstimateID, long AttachmenttypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Purchase_PurchaseID_Select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@AttachmenttypeID", DbType.Int64, AttachmenttypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }


        public virtual DataTable purchase_select_by_estimateid(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_estimateid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable purchase_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_PurchaseDetails_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable purchase_select_by_JobID(int CompanyID, long JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_select_by_JobID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable purchase_select_by_purchaseID(int CompanyID, long PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchase_PurchaseQuickLinks_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable purchaseItem_select_by_estimateid(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_purchaseItem_select_by_estimateItemId");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PurchaseOrdStatusUpdate(long CompanyID, long StatusID, long PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PurchaseOrder_Status_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, StatusID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable quantity_select_by_estimateitemid(int CompanyID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_quantity_select_by_estimateitemid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void QuickQuote_AccountingCode_Insert(long EstimateItemID, int CompanyID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_QuickQuote_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int64, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void DeliveryCost_AccountingCode_Insert(long EstimateItemID, int CompanyID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_DeliveryCost_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int64, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int QuickQuote_AccountingCode_Select(long EstimateItemID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_QuickQuote_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int DeliveryCost_AccountingCode_Select(long EstimateItemID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_DeliveryCost_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public DataTable Select_AccountingCode_For_eStoreSummary(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_AccountingCode_For_eStoreSummary");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Select_EmailAttachment_General(long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_EmailAttachment_General");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_EstimateItemDetails(int CompanyID, long ModuleID, long EstimateItemID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_EstimateItemDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable Select_EstimateItemID_SupplierID_EmailAttach(long EstimateID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_EstimateItemID_SupplierID_EmailAttach");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_IssupplierQuote(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Check_SupplierQuote");
            database.AddInParameter(storedProcCommand, "CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Select_ItemDesn_OnCheckboxCheck(long EstimateItemID, string Label, string FieldName, string Description, bool IsChecked)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_ItemDesn_OnCheckboxCheck");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Label", DbType.String, Label);
            database.AddInParameter(storedProcCommand, "@FieldName", DbType.String, FieldName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@IsChecked", DbType.Boolean, IsChecked);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable selectEstimatetype_estimateitemid_New(long EstimateItemID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_selectEstimatetype_estimateitemid_New");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long SingelItem_Inset_By_Copy(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_single_item_copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldEstimateID", DbType.Int64, OldEstimateID);
            database.AddInParameter(storedProcCommand, "@NewEstimateID", DbType.Int64, NewEstimateID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateItemID", DbType.Int64, Old_EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@Ret_EstimateItemID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@Ret_EstimateItemID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual int SubItemType_ByParentItemID_Select(long ParentItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubItemType_ByParentItemID_Select");
            database.AddInParameter(storedProcCommand, "@ParentItemID", DbType.Int32, ParentItemID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string SubOtem_OtherCost_List(int CompanyID, string EstimateType, long TypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_subitems_list");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable SuplrQt_EstItmID_perEstID(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SuplrQt_EstItmID_perEstID");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Supplier_Contacts_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_supplier_contacts_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet Supplier_QuoteAccepted_Details(long EstimateItemID)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_QuoteAccepted_Check");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.String, EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@query", DbType.Int32, 0);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual string Supplier_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_supplier_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string supplier_select_in_printbroker(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_supplier_select_in_printbroker");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public virtual string supplier_select_in_QuoteDetails(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_supplier_select_in_QuoteDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            object obj = database.ExecuteScalar(storedProcCommand);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public virtual void SupplierDetailsInsert_HistoryTable(string EstimateItemID, string SupplierID, string Quantity1, string Price1, DateTime DeliveryDate1, string IsDeliveryIncluded1, string DeliveryCost1, string MarkUpValue1, string TotalPrice1, string Quantity2, string Price2, DateTime DeliveryDate2, string IsDeliveryIncluded2, string DeliveryCost2, string MarkUpValue2, string TotalPrice2, string Quantity3, string Price3, DateTime DeliveryDate3, string IsDeliveryIncluded3, string DeliveryCost3, string MarkUpValue3, string TotalPrice3, string Quantity4, string Price4, DateTime DeliveryDate4, string IsDeliveryIncluded4, string DeliveryCost4, string MarkUpValue4, string TotalPrice4, string MarkUpType, string Comments, string KeyCode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_QuoteDetails_Insert_ByAdmin");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, Convert.ToInt64(EstimateItemID));
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, Convert.ToInt64(SupplierID));
            database.AddInParameter(storedProcCommand, "@Quantity1", DbType.String, Quantity1);
            database.AddInParameter(storedProcCommand, "@Price1", DbType.Decimal, Convert.ToDecimal(Price1));
            database.AddInParameter(storedProcCommand, "@DeliveryDate1", DbType.DateTime, DeliveryDate1);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded1", DbType.String, IsDeliveryIncluded1);
            database.AddInParameter(storedProcCommand, "@DeliveryCost1", DbType.Decimal, Convert.ToDecimal(DeliveryCost1));
            database.AddInParameter(storedProcCommand, "@MarkUpValue1", DbType.Decimal, Convert.ToDecimal(MarkUpValue1));
            database.AddInParameter(storedProcCommand, "@TotalPrice1", DbType.Decimal, Convert.ToDecimal(TotalPrice1));
            database.AddInParameter(storedProcCommand, "@Quantity2", DbType.String, Quantity2);
            database.AddInParameter(storedProcCommand, "@Price2", DbType.Decimal, Convert.ToDecimal(Price2));
            database.AddInParameter(storedProcCommand, "@DeliveryDate2", DbType.DateTime, DeliveryDate2);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded2", DbType.String, IsDeliveryIncluded2);
            database.AddInParameter(storedProcCommand, "@DeliveryCost2", DbType.Decimal, Convert.ToDecimal(DeliveryCost2));
            database.AddInParameter(storedProcCommand, "@MarkUpValue2", DbType.Decimal, Convert.ToDecimal(MarkUpValue2));
            database.AddInParameter(storedProcCommand, "@TotalPrice2", DbType.Decimal, Convert.ToDecimal(TotalPrice2));
            database.AddInParameter(storedProcCommand, "@Quantity3", DbType.String, Quantity3);
            database.AddInParameter(storedProcCommand, "@Price3", DbType.Decimal, Convert.ToDecimal(Price3));
            database.AddInParameter(storedProcCommand, "@DeliveryDate3", DbType.DateTime, DeliveryDate3);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded3", DbType.String, IsDeliveryIncluded3);
            database.AddInParameter(storedProcCommand, "@DeliveryCost3", DbType.Decimal, Convert.ToDecimal(DeliveryCost3));
            database.AddInParameter(storedProcCommand, "@MarkUpValue3", DbType.Decimal, Convert.ToDecimal(MarkUpValue3));
            database.AddInParameter(storedProcCommand, "@TotalPrice3", DbType.Decimal, Convert.ToDecimal(TotalPrice3));
            database.AddInParameter(storedProcCommand, "@Quantity4", DbType.String, Quantity4);
            database.AddInParameter(storedProcCommand, "@Price4", DbType.Decimal, Convert.ToDecimal(Price4));
            database.AddInParameter(storedProcCommand, "@DeliveryDate4", DbType.DateTime, DeliveryDate4);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded4", DbType.String, IsDeliveryIncluded4);
            database.AddInParameter(storedProcCommand, "@DeliveryCost4", DbType.Decimal, Convert.ToDecimal(DeliveryCost4));
            database.AddInParameter(storedProcCommand, "@MarkUpValue4", DbType.Decimal, Convert.ToDecimal(MarkUpValue4));
            database.AddInParameter(storedProcCommand, "@TotalPrice4", DbType.Decimal, Convert.ToDecimal(TotalPrice4));
            database.AddInParameter(storedProcCommand, "@MarkUpType", DbType.String, MarkUpType);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@KeyCode", DbType.String, KeyCode);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void SupplierDetailsInsert_OnlySave(string EstimateItemID, string SupplierID, string Quantity, string Cost, DateTime DeliveryDate, string IsDeliveryIncluded, string DeliveryCost, string QuantityNumber, string MarkUpType, string MarkupValue, string TotalPrice, string SupplierQuoteNo, string IsSelected, string KeyCode, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateQuoteDetails_Update_ByAdmin");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, Convert.ToInt64(EstimateItemID));
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, Convert.ToInt64(SupplierID));
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int64, Convert.ToInt64(Quantity));
            database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Convert.ToDecimal(Cost));
            database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded", DbType.String, IsDeliveryIncluded);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Decimal, Convert.ToDecimal(DeliveryCost));
            database.AddInParameter(storedProcCommand, "@QuantityNumber", DbType.Int16, Convert.ToInt16(QuantityNumber));
            database.AddInParameter(storedProcCommand, "@MarkUpType", DbType.String, MarkUpType);
            database.AddInParameter(storedProcCommand, "@MarkupValue", DbType.Decimal, Convert.ToDecimal(MarkupValue));
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, Convert.ToDecimal(TotalPrice));
            database.AddInParameter(storedProcCommand, "@SupplierQuoteNo", DbType.String, SupplierQuoteNo);
            database.AddInParameter(storedProcCommand, "@IsSelected", DbType.Int16, Convert.ToInt16(IsSelected));
            database.AddInParameter(storedProcCommand, "@KeyCode", DbType.String, KeyCode);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable SupplierEmailBody_Select(long CompanyID, string TemplateType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SupplierEmailBody_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet SupplierQuote_Details(string KeyCode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_QuoteDetails");
            database.AddInParameter(storedProcCommand, "@KeyCode", DbType.String, KeyCode);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void SupplierQuote_Insert_BySupplier(string EstimateItemID, string SupplierID, string EstimateNumber, string EstimateTitle, string ArtworkIncluded, string ArtwordFileName, DateTime RFQDueBy, DateTime JobCompletionDate, string ItemTitle, string ItemDescription, string UserEstimateNumber, string Comments, string Quantity1, string Price1, DateTime DeliveryDate1, string IsDeliveryIncluded1, string DeliveryCost1, string Quantity2, string Price2, DateTime DeliveryDate2, string IsDeliveryIncluded2, string DeliveryCost2, string Quantity3, string Price3, DateTime DeliveryDate3, string IsDeliveryIncluded3, string DeliveryCost3, string Quantity4, string Price4, DateTime DeliveryDate4, string IsDeliveryIncluded4, string DeliveryCost4, int IsRejected, string RejectedReason, string KeyCode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Supplier_QuoteDetails_Insert");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, Convert.ToInt64(EstimateItemID));
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int64, Convert.ToInt64(SupplierID));
            database.AddInParameter(storedProcCommand, "@EstimateNumber", DbType.String, EstimateNumber);
            database.AddInParameter(storedProcCommand, "@EstimateTitle", DbType.String, EstimateTitle);
            database.AddInParameter(storedProcCommand, "@ArtworkIncluded", DbType.String, ArtworkIncluded);
            database.AddInParameter(storedProcCommand, "@ArtwordFileName", DbType.String, ArtwordFileName);
            database.AddInParameter(storedProcCommand, "@RFQDueBy", DbType.DateTime, RFQDueBy);
            database.AddInParameter(storedProcCommand, "@JobCompletionDate", DbType.DateTime, JobCompletionDate);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
            database.AddInParameter(storedProcCommand, "@UserEstimateNumber", DbType.String, UserEstimateNumber);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@Quantity1", DbType.Int64, Convert.ToInt64(Quantity1));
            database.AddInParameter(storedProcCommand, "@Price1", DbType.Decimal, Convert.ToDecimal(Price1));
            database.AddInParameter(storedProcCommand, "@DeliveryDate1", DbType.DateTime, DeliveryDate1);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded1", DbType.String, IsDeliveryIncluded1);
            database.AddInParameter(storedProcCommand, "@DeliveryCost1", DbType.Decimal, Convert.ToDecimal(DeliveryCost1));
            database.AddInParameter(storedProcCommand, "@Quantity2", DbType.Int64, Convert.ToInt64(Quantity2));
            database.AddInParameter(storedProcCommand, "@Price2", DbType.Decimal, Convert.ToDecimal(Price2));
            database.AddInParameter(storedProcCommand, "@DeliveryDate2", DbType.DateTime, DeliveryDate2);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded2", DbType.String, IsDeliveryIncluded2);
            database.AddInParameter(storedProcCommand, "@DeliveryCost2", DbType.Decimal, DeliveryCost2);
            database.AddInParameter(storedProcCommand, "@Quantity3", DbType.Int64, Convert.ToInt64(Quantity3));
            database.AddInParameter(storedProcCommand, "@Price3", DbType.Decimal, Convert.ToDecimal(Price3));
            database.AddInParameter(storedProcCommand, "@DeliveryDate3", DbType.DateTime, DeliveryDate3);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded3", DbType.String, IsDeliveryIncluded3);
            database.AddInParameter(storedProcCommand, "@DeliveryCost3", DbType.Decimal, DeliveryCost3);
            database.AddInParameter(storedProcCommand, "@Quantity4", DbType.Int64, Convert.ToInt64(Quantity4));
            database.AddInParameter(storedProcCommand, "@Price4", DbType.Decimal, Convert.ToDecimal(Price4));
            database.AddInParameter(storedProcCommand, "@DeliveryDate4", DbType.DateTime, DeliveryDate4);
            database.AddInParameter(storedProcCommand, "@IsDeliveryIncluded4", DbType.String, IsDeliveryIncluded4);
            database.AddInParameter(storedProcCommand, "@DeliveryCost4", DbType.Decimal, DeliveryCost4);
            database.AddInParameter(storedProcCommand, "@IsRejected", DbType.Int16, IsRejected);
            database.AddInParameter(storedProcCommand, "@RejectedReason", DbType.String, RejectedReason);
            database.AddInParameter(storedProcCommand, "@KeyCode", DbType.String, KeyCode);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable template_printbroker_RFQdescription_Select(int CompanyID, string Estype, long TypeID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_printbroker_RFQdescription_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Esttype", DbType.String, Estype);
            database.AddInParameter(storedProcCommand, "@TypeID", DbType.Int64, TypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Update_Description_OnCheck(int CompanyID, long EstimateID, long EstimateItemID, string Description)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_Description_OnCheck_PO");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Update_Description_OnCheck_DN(long EstimateID, long EstimateItemID, string Description)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_Description_OnCheck_DN");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Warehouse_Information_By_EstimateItemID(int CompanyID, long EstimateItemID, long EstWarehouseItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_item_info");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstWarehouseItemID", DbType.Int64, EstWarehouseItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Warehouse_Markup(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_markup");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string warehouse_perquantity_select(int CompanyID, string WarehouseType, long WarehouseTypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_warehouse_perquantity_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WarehouseType", DbType.String, WarehouseType);
            database.AddInParameter(storedProcCommand, "@WarehouseTypeID", DbType.Int64, WarehouseTypeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void zone_markup_update(int CompanyID, long EstCalculationID, double Markup)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_zone_markup_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstCalculationID", DbType.Int64, EstCalculationID);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Double, Markup);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public Int32 Create_proof(int CompanyID, long EstimateID, long ProofID, DateTime ProofDate,int StatusID)
        {
            int num = 0;   
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_proof_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@ProofDate", DbType.DateTime, ProofDate);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            object obj = database.ExecuteScalar(storedProcCommand);

            return Convert.ToInt32(obj.ToString());

        }

        public void Create_proof_detail(int EstimateItemID, long AttachmentId, long ProofID,Int32 UserId,DateTime CreatedDate,int CompanyID,int ItemStatus)
        {
            int num = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_proof_detail_insert");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentId", DbType.Int64, AttachmentId);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@UserId", DbType.Int32, UserId);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemStatus", DbType.Int32, ItemStatus);
            object obj = database.ExecuteNonQuery(storedProcCommand);

            

        }


        public void AddProofItemDetails(long ProofID,long EstimateItemID, DateTime CreatedDate,int StatusID)
        {
            int num = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AddProofItemDetails");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int32, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@ItemStatus", DbType.Int32, StatusID);
            object obj = database.ExecuteNonQuery(storedProcCommand);
        }
        public DataTable GetProofEstimateItemIDs(long ProofID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofEstimateItemIDs");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;


        }

        public virtual DataTable Get_ProofAprovedFilesDetail(int ProofID, long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_ProofAprovedFilesDetail");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
           
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_ProofAttachments(int ProofID, long EstimateItemID, long ProofItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_ProofDropDownFiles");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_Proof_History(Int32 AttachmentID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Get_Proof_History");
            database.AddInParameter(storedProcCommand, "@AttachmentId", DbType.Int32, AttachmentID);           
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }



        public void InsertProofLastCounter(int CompanyID)
        {
            int num = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProofLastCounter");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            object obj = database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable GetProofAttachmentID(long EstimateID, Int32 UserId, int Number, int EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofAttachmentID");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
            database.AddInParameter(storedProcCommand, "@UserId", DbType.Int64, UserId);
            database.AddInParameter(storedProcCommand, "@Number", DbType.Int64, Number);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
      
        public virtual DataTable GetDefaultSelectedImage(int ProofID, long EstimateItemID, long ProofItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetDefaultSelectedImage");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProofHistoryDetails(int ProofID, long EstimateItemID, int AttachmentID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofHistoryDetails");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetProofAttachmentHistory(int ProofID, long EstimateItemID, int AttachmentID,long ProofItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofAttachmentHistory");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable ProofSelectedAttachmentHistory(int ProofID, long EstimateItemID, int AttachmentID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofSelectedAttachmentHistory");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProofSelectedAttachmentImage(int ProofID, long EstimateItemID, int AttachmentID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofSelectedAttachmentImage");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public string Get_Proof_Number(int proofID)
        {
            try
            {
                commonClass commonClass = new commonClass();
                string proofNo = "";
                string constring = commonClass.strConnection;
                String sqlQuery = "select ProofNumber from tb_Proof where ProofID=@ProofID";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ProofID", DbType.Int32).Value = proofID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    proofNo = reader.GetString(0);
                }
                return proofNo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual DataTable Get_Proofed_Attachment(long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Get_Proof_Attachment");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Get_Proofed_WebLink(long EstimateItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Get_Proof_WebLink");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public int Get_AttachmentCount(long EstimateItemID)
        {
            try
            {
                commonClass commonClass = new commonClass();
                Int32 attachment_count = 0;
                string constring = commonClass.strConnection;
                String sqlQuery = "SELECT count(*) from tb_EstAttachment e where e.AttachmentTypeID=@EstimateItemID and e.IsDeleted=0  AND e.AttachmentTypeID >0";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@EstimateItemID", DbType.Int32).Value = EstimateItemID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                attachment_count = (Int32)cmd.ExecuteScalar();
                return attachment_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public string GetContactFirstName(string contactID)
        {
            try
            {
                commonClass commonClass = new commonClass();
                string firstName = "";
                string constring = commonClass.strConnection;
                String sqlQuery = "select firstName from tb_Contact where contactId=@ContactID";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = contactID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    firstName = reader.GetString(0);
                }
                return firstName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public virtual DataTable GetProofStatusAll(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("get_proof_status_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void UpdateProofUserEmail(long ProofID, string Email)
        {
            int num = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateProofEndUserEmail");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            database.AddInParameter(storedProcCommand, "@EndUserEmail", DbType.String, Email);
            object obj = database.ExecuteNonQuery(storedProcCommand);
        }
        public string GetEstimateID(int CompanyID,long JobID)
        {
            try
            {
                commonClass commonClass = new commonClass();
                string estimateID = "";
                string constring = commonClass.strConnection;
                String sqlQuery = "select EstimateID from tb_job where JobID=@JobID and CompanyID=@CompanyID";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int32).Value = CompanyID;
                cmd.Parameters.AddWithValue("@JobID", DbType.Int32).Value = JobID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                //using (var reader = cmd.ExecuteReader())
                //{
                //    reader.Read();
                //    estimateID = reader.GetString(0).ToString();
                //}
                estimateID = cmd.ExecuteScalar().ToString() ;
                return estimateID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string GetEstimateCustomerID(int CompanyID, long EstimateID)
        {
            try
            {
                commonClass commonClass = new commonClass();
                string customerID = "";
                string constring = commonClass.strConnection;
                String sqlQuery = "select CustomerID from tb_Estimate where EstimateID=@EstimateID and CompanyID=@CompanyID";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CompanyID", DbType.Int32).Value = CompanyID;
                cmd.Parameters.AddWithValue("@EstimateID", DbType.Int32).Value = EstimateID;
                con.Open();
                cmd.CommandType = CommandType.Text;
                customerID = cmd.ExecuteScalar().ToString();
                return customerID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetProofAttachmentCount( long EstimateID,string PageType,long JobID)
        {
            try
            {
                string proof_count = "";
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofFileCount");
                database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
                database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
                database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);

                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                    proof_count = dataTable.Rows[0]["proof_count"].ToString();
                }
                return proof_count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateProofHistory(int AttachmentID, int EstimateItemID, int ProofID, int UserID, bool IsDropdownDisplay,int UpdatedAttachmentID,int ProofItemID)
        {
            try
            {
                string proof_count = "";
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateProofHistory");
                database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
                database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
                database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
                database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
                database.AddInParameter(storedProcCommand, "@IsDropdownDisplay", DbType.Boolean, IsDropdownDisplay);
                database.AddInParameter(storedProcCommand, "@UpdatedAttachmentID", DbType.Int64, UpdatedAttachmentID);
                database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertProofHistory(int AttachmentID, int EstimateItemID, int ProofID, int UserID,int ProofItemID)
        {
            try
            {
                string proof_count = "";
                DataTable dataTable = new DataTable();
                Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProofHistory");
                database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
                database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
                database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
                database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
                database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
                database.ExecuteNonQuery(storedProcCommand);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public virtual DataTable GetAPIOrderID(long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetAPIOrderID");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetStatusDetails(int statusID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetStatusDetails");
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, statusID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetProofViewDefault(int CompanyID,int UserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofViewID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void UpdateProofApproval(bool IsChecked, int ProofItemID,string ApproverName,string ApproverEmail)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateProofApproval");
            database.AddInParameter(storedProcCommand, "@IsChecked", DbType.Boolean, IsChecked);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
            database.AddInParameter(storedProcCommand, "@ApproverName", DbType.String, ApproverName);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.ExecuteReader(storedProcCommand);
            //using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            //{
            //    dataTable.Load(dataReader);
            //}
            //return dataTable;
        }

        public virtual DataTable GetProofApproval(long ProofItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofApproval");
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetAttachmentByAttachmentID(long AttachmentID, string PageType,long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetAttachmentByAttachmentID");
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetUpdateJobLockingOrUnlockingStatus(long JobID, long CompanyID, string Event)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsUpdateJobLockingOrUnlockingStatus");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Event", DbType.String, Event);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string GetProofStatus(int ProofID, long EstimateItemID, int AttachmentID)
        {
            string status = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofStatus");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            using (var reader = database.ExecuteReader(storedProcCommand))
            {
                reader.Read();
                if (!string.IsNullOrEmpty(reader.GetString(0)))
                {
                    status = reader.GetString(0);
                }
                else
                {
                    status = "";
                }
            }
            return status;
        }
        public virtual int GetApprovalCount(int ProofID, long EstimateItemID, int AttachmentID, int ProofItemID)
        {
            int approvalCount = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Get_ApprovalCount");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
            approvalCount = (Int32)database.ExecuteScalar(storedProcCommand);
            return approvalCount;
        }
        public virtual bool UpdateProofStatus(int ProofID, long EstimateItemID, int AttachmentID, string Comment, string Status, bool IsTermsAndConditions)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateProofStatus");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@Comment", DbType.String, Comment);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@IsTermsAndConditions", DbType.Boolean, IsTermsAndConditions);
            database.ExecuteReader(storedProcCommand);
            return true;
        }

        public virtual bool UpdateProofItemStatus(int ProofID, long EstimateItemID, string Status)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateProofItemStatus");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.ExecuteReader(storedProcCommand);
            return true;  
        }

        public virtual DataTable Get_SecondApprover_EmailAndName(int ProofItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_SecondApproverDetails");
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual bool InsertProofAttachmentHistory(int ProofID, long EstimateItemID,int ProofItemID, int AttachmentID, string Comment, string Status,int UserID,int CompanyID)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProofAttachmentHistory");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@ProofItemID", DbType.Int64, ProofItemID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            if(string.IsNullOrEmpty(Comment))
            {
                database.AddInParameter(storedProcCommand, "@Comment", DbType.String, "");
            }
            else
            {
                database.AddInParameter(storedProcCommand, "@Comment", DbType.String, Comment);
            }
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            if (string.IsNullOrEmpty(Status))
            {
                database.AddInParameter(storedProcCommand, "@Status", DbType.String, "");
            }
            else
            {
                database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            }
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteReader(storedProcCommand);
            return true;
        }
        public virtual DataTable Internal_Proof_Email_Select(int StatusID, int companyID, string TemplateType, int ProofID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            Database database = CustomDatabaseFactory.CreateDatabase(str);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Internal_Proof_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int32, ProofID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void SaveEstimateItemFTPAddress(int CompanyID,long EstimateItemID,string FTPAddress,string FTPStatus, string FTPSource)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_EstimateItem_FTPAddress");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@FTPAddress", DbType.String, FTPAddress);
            database.AddInParameter(storedProcCommand, "@FTPStatus", DbType.String, FTPStatus);
            database.AddInParameter(storedProcCommand, "@FTPSource", DbType.String, FTPSource);
            database.ExecuteNonQuery(storedProcCommand);

        }
    }
}