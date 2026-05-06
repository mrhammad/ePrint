using DataAccessLayer;
using DocumentFormat.OpenXml.Spreadsheet;
using ePrint.settings;
using ePrint.StoreSettings;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using Printcenter.BusinessAccessLayer;
using Printcenter.BusinessAccessLayer.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Settings
{
    public class DbSettings : DataAccess
    {
        public DbSettings()
        {
        }

        public virtual DataTable ActivityCallReport_SelectColoumn()
        {
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("PC_Select_ActivityCallReport_Coloumns")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ActivityTaskEventReport_SelectColoumn()
        {
            BaseClass baseClass = new BaseClass();
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("PC_Select_ActivityTaskEventReport_Coloumns")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable AllowCSvEnable(long PriceCatalogueID, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsAllowCSvFile");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ArchiveStatus_Edit(long CompanyID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArchiveStatus_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void ArchiveStatus_Update(long CompanyID, long ArchiveStatusId, string Module, string Event, long StatusID, int IsArchive)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ArchiveStatus_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ArchiveStatusId", DbType.Int32, ArchiveStatusId);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@Event", DbType.String, Event);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@IsArchive", DbType.Int16, IsArchive);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable AutoDeliveryAlert_EditSelectStatus(int CompanyID, int StatusID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AutoDeliveryalert_Status_EditSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable AutoDeliveryAlert_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AutoDeliveryAlert_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable AutoDeliveryAlert_SelectStatus(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AutoDeliveryalert_Status_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void autojobalert_delete(int CompanyID, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_emailbody_deleterow");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable AutojobAlert_EditSelectStatus(int CompanyID, int StatusID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Autojobalert_Status_EditSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Auto_Module_Alert_EditSelectStatus(int CompanyID, int StatusID,string PageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Auto_Module_Alert_Status_EditSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable AutojobAlert_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AutoJobAlert_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable AutoAlertEmailByTemplate_select(int CompanyID, string TemplateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetAutoEmailByTemplate_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable AutojobAlert_SelectStatus(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Autojobalert_Status_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable SelectModuleStatus(int CompanyID,string PageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_module_status");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Bindddl_othercostSelectedCategory(int CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_OtherCost_Category_select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataSet Bindddl_SelectedCategory(int CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_PriceCatalogue_CategoryID_Select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void CallPurpose_delete(long Id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CallPurpose_delete");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int64, Id);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int CallPurpose_insert(SettingsItem items)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CallPurpose_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, items.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, items.StatusTitle);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.String, items.IsDefaultStatus);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.String, items.UserID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable CallPurpose_select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CallPurpose_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void CallPurpose_status_update(long CompanyID, long StatusID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CallPurpose_status_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int64, StatusID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void CallPurpose_update(SettingsItem items)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CallPurpose_update");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int32, items.CPStatusID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, items.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, items.StatusTitle);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.String, items.IsDefaultStatus);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void CartImage_Insert_Update(long AccountID, string CartImage, string OriginalCartImageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CartImage_Insert_Update");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CartImage", DbType.String, CartImage);
            database.AddInParameter(storedProcCommand, "@OriginalCartImageName", DbType.String, OriginalCartImageName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Category_Customer_Select(long companyid, long CustID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Category_Customer_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, CustID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual DataTable Check_IsApprovalFeaturesOn(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Check_IsApprovalFeaturesOn");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void CheckInksWhileRerun(int CompanyID, long EstimateItemID, long EstimateLithoNCRItemId, long EstimateLithoBookletItemId, string sidenumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_CheckInksWhileRerun");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@EstimateLithoNCRItemId", DbType.Int64, EstimateLithoNCRItemId);
            database.AddInParameter(storedProcCommand, "@EstimateLithoBookletItemId", DbType.Int64, EstimateLithoBookletItemId);
            database.AddInParameter(storedProcCommand, "@sidenumber", DbType.String, sidenumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual bool CheckIsCampaignEnabled(long AccountID, long CompanyID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_CheckIsCampaignEnabled");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public DataTable ClientReferencedByName_Select(string Name, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ClientReferencedByName_Select");
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, Name);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void common_add_usertype_and_accessrights_new_Default(long CompanyID, long UserID, string usertype, string sectionname, int isview, int isadd, int isedit, int isdelete, int isdisplay, int isassignmentrights, string Others, string PrintorEmail, string ExportorImport, string IsRevert, string description)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_add_usertype_and_accessrights_new_Default");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@userID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@usertype", DbType.String, usertype);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@isview", DbType.Int16, isview);
            database.AddInParameter(storedProcCommand, "@isadd", DbType.Int16, isadd);
            database.AddInParameter(storedProcCommand, "@isedit", DbType.Int16, isedit);
            database.AddInParameter(storedProcCommand, "@isdelete", DbType.Int16, isdelete);
            database.AddInParameter(storedProcCommand, "@isdisplay", DbType.Int16, isdisplay);
            database.AddInParameter(storedProcCommand, "@isassignmentrights", DbType.Int16, isassignmentrights);
            database.AddInParameter(storedProcCommand, "@Others", DbType.String, Others);
            database.AddInParameter(storedProcCommand, "@PrintorEmail", DbType.String, PrintorEmail);
            database.AddInParameter(storedProcCommand, "@ExportorImport", DbType.String, ExportorImport);
            database.AddInParameter(storedProcCommand, "@IsRevert", DbType.String, IsRevert);
            database.AddInParameter(storedProcCommand, "@expireyafter", DbType.Int16, 0);
            database.AddInParameter(storedProcCommand, "@description", DbType.String, description);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void common_update_accessrights_New(long CompanyID, long usertypeid, string sectionname, int isview, int isadd, int isedit, int isdelete, int isdisplay, int isassignmentrights, string Others, string PrintorEmail, string ExportorImport, string IsRevert, string description)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_common_update_accessrights_New");
            database.AddInParameter(storedProcCommand, "@usertypeid", DbType.Int64, usertypeid);
            database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, sectionname);
            database.AddInParameter(storedProcCommand, "@isview", DbType.Int16, isview);
            database.AddInParameter(storedProcCommand, "@isadd", DbType.Int16, isadd);
            database.AddInParameter(storedProcCommand, "@isedit", DbType.Int16, isedit);
            database.AddInParameter(storedProcCommand, "@isdelete", DbType.Int16, isdelete);
            database.AddInParameter(storedProcCommand, "@isdisplay", DbType.Int16, isdisplay);
            database.AddInParameter(storedProcCommand, "@isassignmentrights", DbType.Int16, isassignmentrights);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Others", DbType.String, Others);
            database.AddInParameter(storedProcCommand, "@PrintorEmail", DbType.String, PrintorEmail);
            database.AddInParameter(storedProcCommand, "@ExportorImport", DbType.String, ExportorImport);
            database.AddInParameter(storedProcCommand, "@IsRevert", DbType.String, IsRevert);
            database.AddInParameter(storedProcCommand, "@expireyafter", DbType.AnsiString);
            database.AddInParameter(storedProcCommand, "@description", DbType.String, description);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable CRM_Customers_SelectForDashboard(long CompanyID, string widgetType)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Customers_SelectForDashboard");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@WidgetType", DbType.String, widgetType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet CRM_Select_IsAdvance_Crm(int CompanyID, string HostName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_IsAdvance_Crm");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, HostName);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet CRM_Select_Isstore_ForOrder(int CompanyID, string SystemName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Isstore_ForOrder");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@System_Name", DbType.String, SystemName);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable CustomizeClient_Report(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CustomizeClientReport");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable CustomizeJob_Report(int CompanyID, string FromDate, string ToDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetCustomizeJobReport");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable CustomizeProduct_Report(int CompanyID, long ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetCustomizeProductReport");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable CustomStyles_Details(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CustomStyles_Details");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void CustomStyles_Insert_Update(string ClassName, long AccountID, string Color, string FontFamily, string FontSize, string BackgroundColor, string Height, string Border, string FontWeight, string BackgroundImage, string TextDecoration, string TextTranform)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CustomStyles_Insert_Update");
            database.AddInParameter(storedProcCommand, "@ClassName", DbType.String, ClassName);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@FontFamily", DbType.String, FontFamily);
            database.AddInParameter(storedProcCommand, "@FontSize", DbType.String, FontSize);
            database.AddInParameter(storedProcCommand, "@BackgroundColor", DbType.String, BackgroundColor);
            database.AddInParameter(storedProcCommand, "@Height", DbType.String, Height);
            database.AddInParameter(storedProcCommand, "@Border", DbType.String, Border);
            database.AddInParameter(storedProcCommand, "@FontWeight", DbType.String, FontWeight);
            database.AddInParameter(storedProcCommand, "@BackgroundImage", DbType.String, BackgroundImage);
            database.AddInParameter(storedProcCommand, "@TextDecoration", DbType.String, TextDecoration);
            database.AddInParameter(storedProcCommand, "@TextTranform", DbType.String, TextTranform);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Default_templates_select(int COmpanyID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Default_template_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, COmpanyID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable DefaultSettings_ProductType_Select(long CompanyID, string Type)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultSettings_ProductType_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string DeleteImageCategory(long CategoryID, long UserID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageCategory_Delete");
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual void DeleteMultipleImageCategory(long CompanyID, long UserID, string CategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            string empty = string.Empty;
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_Multiple_ImageCategory_Delete");
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, Convert.ToInt64(CategoryID.ToString()));
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string DeleteMultipleImageCategory_Check(long CompanyID, long UserID, string CategoryIDs, string ImgIDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            string empty = string.Empty;
            if (CategoryIDs != "")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_Group_ImageCategory_Delete_Check");
                database.AddInParameter(storedProcCommand, "@CategoryID", DbType.String, CategoryIDs);
                database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
                {
                    dataTable.Load(dataReader);
                }
                empty = string.Concat(empty, dataTable.Rows[0][0].ToString(), ',');
            }
            if (ImgIDs != "")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("PC_Settings_Group_ImageFiles_Delete_Check");
                database.AddInParameter(dbCommand, "@ImageID", DbType.String, ImgIDs);
                database.AddInParameter(dbCommand, "@UserID", DbType.Int64, UserID);
                DataTable dataTable1 = new DataTable();
                try
                {
                    using (IDataReader dataReader1 = database.ExecuteReader(dbCommand))
                    {
                        dataTable1.Load(dataReader1);
                    }
                    empty = string.Concat(empty, dataTable1.Rows[0][0].ToString(), ',');
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return empty;
        }

        public virtual void DeleteMultipleImages(long CompanyID, long UserID, string ImgID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_Multiple_ImageFiles_Delete");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, Convert.ToInt64(ImgID.ToString()));
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string DeleteRootImage(long ImageID, long UserID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_RootImage_Delete");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, ImageID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual void DeleteSingleInUseCategory(string CategoryID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_InUseCategory_Delete");
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, Convert.ToInt64(CategoryID.ToString()));
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void DeleteSingleInUseImage(string ImgID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_InUseImage_Delete");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, Convert.ToInt64(ImgID.ToString()));
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void DigitalPress_AccountingCode_Insert(long CompanyID, long DigitalPressID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_DigitalPress_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int DigitalPress_AccountingCode_Select(long CompanyID, long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_DigitalPress_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void DigitalPress_New_Copy(long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DigitalPress_New_Copy");
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Guillotine_New_Copy(long GuillotineID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Guillotine_New_Copy");
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void LargeFormate_New_Copy(long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LargeFormate_New_Copy");
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void lithopress_New_Copy(long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LithoPressID_New_Copy");
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int DigitalPressMatrixCounter_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DigitalPressMatrixCounter_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            int num = (int)database.ExecuteScalar(storedProcCommand);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public void DisableApprovalSystem(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DisableApprovalSystem");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void editabletemplate_colorstyle_delete(long ColorID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_ColorStyle_Delete");
            database.AddInParameter(storedProcCommand, "@ColorID", DbType.Int64, ColorID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void editabletemplate_colorstyle_insert(long TemplateID, long UserID, long CompanyID, string ColorStyle, string code_c, string code_m, string code_y, string code_k, decimal code_r, decimal code_g, decimal code_b, decimal code_a, decimal Tint, int IsSpotColor, string SpotColor)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[et_InsertNewColorStyle]");
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ColorStyle", DbType.String, ColorStyle);
            database.AddInParameter(storedProcCommand, "@C", DbType.String, code_c);
            database.AddInParameter(storedProcCommand, "@M", DbType.String, code_m);
            database.AddInParameter(storedProcCommand, "@Y", DbType.String, code_y);
            database.AddInParameter(storedProcCommand, "@K", DbType.String, code_k);
            database.AddInParameter(storedProcCommand, "@R", DbType.Decimal, code_r);
            database.AddInParameter(storedProcCommand, "@G", DbType.Decimal, code_g);
            database.AddInParameter(storedProcCommand, "@B", DbType.Decimal, code_b);
            database.AddInParameter(storedProcCommand, "@A", DbType.Decimal, code_a);
            database.AddInParameter(storedProcCommand, "@Tint", DbType.Decimal, Tint);
            database.AddInParameter(storedProcCommand, "@SpotColor", DbType.String, IsSpotColor);
            database.AddInParameter(storedProcCommand, "@SpotColorRef", DbType.String, SpotColor);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable editabletemplate_colorstyle_select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_ColorStyle_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void editabletemplate_colorstyle_update(long ColorID, long TemplateID, long UserID, long CompanyID, string ColorStyle, string code_c, string code_m, string code_y, string code_k, decimal code_r, decimal code_g, decimal code_b, decimal code_a, decimal Tint, int IsSpotColor, string SpotColor)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[et_UpdateColorStylebyID]");
            database.AddInParameter(storedProcCommand, "@ColorID", DbType.Int64, ColorID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ColorStyle", DbType.String, ColorStyle);
            database.AddInParameter(storedProcCommand, "@C", DbType.String, code_c);
            database.AddInParameter(storedProcCommand, "@M", DbType.String, code_m);
            database.AddInParameter(storedProcCommand, "@Y", DbType.String, code_y);
            database.AddInParameter(storedProcCommand, "@K", DbType.String, code_k);
            database.AddInParameter(storedProcCommand, "@R", DbType.Decimal, code_r);
            database.AddInParameter(storedProcCommand, "@G", DbType.Decimal, code_g);
            database.AddInParameter(storedProcCommand, "@B", DbType.Decimal, code_b);
            database.AddInParameter(storedProcCommand, "@A", DbType.Decimal, code_a);
            database.AddInParameter(storedProcCommand, "@Tint", DbType.Decimal, Tint);
            database.AddInParameter(storedProcCommand, "@SpotColor", DbType.String, IsSpotColor);
            database.AddInParameter(storedProcCommand, "@SpotColorRef", DbType.String, SpotColor);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable editabletemplate_fontfamily_select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_FontFamily_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void editabletemplate_fontstyle_delete(long FontID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_FontStyles_Delete");
            database.AddInParameter(storedProcCommand, "@FontID", DbType.Int64, FontID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void editabletemplate_fontstyle_insert(long TemplateID, long UserID, long CompanyID, string FontStyle, decimal FontSize, string ManualTracking, string TextAlign, decimal Indent, string Capitalize, string DataType, string Format, string FontFamily)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_InsertNewFontStyle");
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@FontStyle", DbType.String, FontStyle);
            database.AddInParameter(storedProcCommand, "@FontSize", DbType.Decimal, FontSize);
            database.AddInParameter(storedProcCommand, "@ManualTracking", DbType.String, ManualTracking);
            database.AddInParameter(storedProcCommand, "@TextAlign", DbType.String, TextAlign);
            database.AddInParameter(storedProcCommand, "@Indent", DbType.Decimal, Indent);
            database.AddInParameter(storedProcCommand, "@Capitalize", DbType.String, Capitalize);
            database.AddInParameter(storedProcCommand, "@Datatype", DbType.String, DataType);
            database.AddInParameter(storedProcCommand, "@Format", DbType.String, Format);
            database.AddInParameter(storedProcCommand, "@FontFamily", DbType.String, FontFamily);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void editabletemplate_fontstyle_update(long CompanyID, decimal FontSize, string ManualTracking, string TextAlign, decimal Indent, string Capitalize, string DataType, string Format, string FontFamily, string FontStyle, long FontID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateUserFontStyle");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@FontSize", DbType.Decimal, FontSize);
            database.AddInParameter(storedProcCommand, "@ManualTracking", DbType.String, ManualTracking);
            database.AddInParameter(storedProcCommand, "@TextAlign", DbType.String, TextAlign);
            database.AddInParameter(storedProcCommand, "@Indent", DbType.Decimal, Indent);
            database.AddInParameter(storedProcCommand, "@Capitalize", DbType.String, Capitalize);
            database.AddInParameter(storedProcCommand, "@Datatype", DbType.String, DataType);
            database.AddInParameter(storedProcCommand, "@Format", DbType.String, Format);
            database.AddInParameter(storedProcCommand, "@FontFamily", DbType.String, FontFamily);
            database.AddInParameter(storedProcCommand, "@FontStyle", DbType.String, FontStyle);
            database.AddInParameter(storedProcCommand, "@FontStyleID", DbType.String, FontID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable editabletemplate_fontstyles_select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_FontStyles_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string eprint_numbering(int CompanyID, string ModuleName, bool IsHandy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_eprint_numbering");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.AddInParameter(storedProcCommand, "@EstimatePrefix", DbType.String, ConnectionClass.EstimatePrefix);
            database.AddInParameter(storedProcCommand, "@JobPrefix", DbType.String, ConnectionClass.JobPrefix);
            database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
            database.AddInParameter(storedProcCommand, "@DeliveryNotePrefix", DbType.String, ConnectionClass.DeliveryNotePrefix);
            database.AddInParameter(storedProcCommand, "@PurchasePrefix", DbType.String, ConnectionClass.PurhcasePrefix);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual DataSet Estimate_Outwork_Supplier_Select(long CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Supplier_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Estimate_Outwork_Supplier_Select_per_Item(long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_Supplier_Select_per_Item");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            DataSet dataSet = new DataSet();
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataTable EstoreReport_Customer_View(int CompanyID, long ReportID, string ReportName, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreReport_Customer_View");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ReportID", DbType.Int64, ReportID);
            database.AddInParameter(storedProcCommand, "@ReportName", DbType.String, ReportName);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Fetch_SelectedAccountID(long USerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FetchSelectedAccountID");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, USerID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? "" : obj.ToString());
        }

        public virtual string Fetch_SelectedAccountName(long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FetchSelectedAccountName");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? "" : obj.ToString());
        }

        public virtual bool Fetch_SupplierQuote(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetSupplierQuote");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int16, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? false : Convert.ToBoolean(obj.ToString()));
        }

        public virtual void Font_Delete(long CompanyID, long FontID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Font_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@FontID", DbType.Int64, FontID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Font_Insert_Update(long CompanyID, string FontName, long UserID, string FontFilePath, bool ReadyFile, string Extension, string ActualFontFamilyName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UploadNewFont");
            database.AddInParameter(storedProcCommand, "@FontName", DbType.String, FontName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@FontFilePath", DbType.String, FontFilePath);
            database.AddInParameter(storedProcCommand, "@IsReady", DbType.Boolean, ReadyFile);
            database.AddInParameter(storedProcCommand, "@FontExtension", DbType.String, Extension);
            database.AddInParameter(storedProcCommand, "@ActualFontFamily", DbType.String, ActualFontFamilyName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Font_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_et_Fonts_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int get_default_Status_ID(int companyID, string type, int estimateid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_default_Status_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@estimateid", DbType.Int32, estimateid);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Get_Estimate_DefaulSetting(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Get_Estimate_DefaulSetting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int get_jobStatus_ID(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_jobStatus_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, item.StatusTitle);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable get_jobStatus_Title(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_jobStatus_Title");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, item.StatusID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetCategories(long CompanyID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetImageCategory");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetCategoryNames(long CompanyID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_GetCategoryNames");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual bool GetEditableTemplate_Value(long ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetEditableTemplate");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, ProductCatalogueID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? false : Convert.ToBoolean(obj.ToString()));
        }

        public DataTable getEmailForSetting(int AccountId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Email_Select_storeSett");
            database.AddInParameter(storedProcCommand, "@AccountId", DbType.Int64, AccountId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetFirstandLastPagedetails(int PDFID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFirstandLastPagedetails");
            database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int32, PDFID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet GetImageGalleryCategories(long CompanyID, long CategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetImageGalleryCategories");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable GetImageNames(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_GetImageNameFor_Copy");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetImagePath(long CompanyID, long CategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_GetIamgeCategory");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable getIsStock_Value(long PricecatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PriceCatalogueStockValue_Select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, PricecatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable getOldPDFName(int PriceCatalogueID, int NewPriceCatalogueID, string _newpdfnameforcopied)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[et_GetPDFNameFor_Copy]");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NewPriceCatalogueID", DbType.Int32, NewPriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@NewPDFName", DbType.String, _newpdfnameforcopied);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetProduct_SelectClient(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductReport_SelectedClient");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetProduct_SelectClient(int CompanyID, int clientTypeId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductReport_SelectedClient");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerTypeId", DbType.String, Convert.ToString(clientTypeId));
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetProduct_SelectDepartment(int CompanyID, string ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DepartmentAllocation_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.String, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetProductCanned_Customer(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductReport_CustomerSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetSearchItems(long CompanyID, long CategoryID, long UserID, string SearchText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_ImageGallerySearchResult_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet GetStockUsage_InPacks(int CompanyID, string ClientId, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_InPack_Report");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.String, ClientId);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet GetStockUsage_InPacks_cost(int CompanyID, string ClientId, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_InPack_Report_cost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.String, ClientId);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }
        public virtual DataSet GetItemsWithReorderAlertsSet(int CompanyID, long ClientId)//, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("GetItemsWithReorderAlertsSet");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.String, ClientId);
            //database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }
        public virtual DataSet GetItemsRequiringReorder(int CompanyID, long ClientId)//, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("GetItemsRequiringReorder");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientId", DbType.String, ClientId);
            //database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }
        public virtual DataSet GetAllEstimateItemsByCustomers(string query, long companyId, long clientId)//, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetSqlStringCommand(query);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@clientId", DbType.String, clientId);
            //database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }
        public virtual DataTable GetCustomerYearlyComparisonData(int CompanyID, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Customer_Yearly_Comparison_Report");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual string Group_webothercostName_Select(long companyid, long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_webothercostName_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void Guillotine_AccountingCode_Insert(long CompanyID, long GuillotineID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Guillotine_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Guillotine_AccountingCode_Select(long CompanyID, long GuillotineID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Guillotine_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable guillotine_for_large_format_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_guillotine_for_large_format_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public long Insert_BlankPDFDetails(int CreadtedBy, int CompanyID, string PDFName, string ImageName, string Title, long PriceCatalogueID, double Pageheight, double Pagewidth, double zoomx, double zoomy, double zoompercentage, bool isOverPrintFileRequired, double CropMarkWidth, double CropMarkHeight, bool isAllowPDFPreviews, bool isPDFPreviewMandatory, bool isAllowWaterMark, string WaterMarkText, int NoOfPages)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CreatedBy", (object)CreadtedBy), new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@PDFName", PDFName), new SqlParameter("@ImageName", ImageName), new SqlParameter("@Title", Title), new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID), new SqlParameter("@WaterMarkText", (object)Pageheight), new SqlParameter("@WaterMarkText", (object)Pagewidth), new SqlParameter("@ZoomX", (object)zoomx), new SqlParameter("@ZoomY", (object)zoomy), new SqlParameter("@ZoomPercentage", (object)zoompercentage), new SqlParameter("@CropMarkWidth", (object)CropMarkWidth), new SqlParameter("@CropMarkHeight", (object)CropMarkHeight), new SqlParameter("@isOverPrintFileRequired", (object)isOverPrintFileRequired), new SqlParameter("@CropMarkWidth", (object)CropMarkWidth), new SqlParameter("@CropMarkHeight", (object)CropMarkHeight), new SqlParameter("@isAllowPDFPreviews", (object)isAllowPDFPreviews), new SqlParameter("@isPDFPreviewMandatory", (object)isPDFPreviewMandatory), new SqlParameter("@isAllowWaterMark", (object)isAllowWaterMark), new SqlParameter("@WaterMarkText", WaterMarkText), new SqlParameter("@NoOfPages", (object)NoOfPages), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"], CommandType.StoredProcedure, "et_Insert_BlankPDFDetails", sqlParameterArray);
            return Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        public long Insert_In_EtTemplate(int CreadtedBy, int CompanyID, string PdfName, string Title, long PriceCatalogueID, bool IsOverPrintFileRequired, double CropMarkWidth, double CropNarkHeight, bool IsAllowPDFPreview, bool IsPdfPreviewMandotrory, bool IsAllowWaterMark, string WaterMarkText, long NoOfPages, bool ChkAllowCSV, string Type, string TitleHighResPDFName, string HighResPdfName)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CreatedBy", (object)CreadtedBy), new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@PDFName", PdfName), new SqlParameter("@Title", Title), new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID), new SqlParameter("@isOverPrintFileRequired", (object)IsOverPrintFileRequired), new SqlParameter("@CropMarkWidth", (object)CropMarkWidth), new SqlParameter("@CropMarkHeight", (object)CropNarkHeight), new SqlParameter("@isAllowPDFPreviews", (object)IsAllowPDFPreview), new SqlParameter("@isPDFPreviewMandatory", (object)IsPdfPreviewMandotrory), new SqlParameter("@isAllowWaterMark", (object)IsAllowWaterMark), new SqlParameter("@WaterMarkText", WaterMarkText), new SqlParameter("@NoOfPages", (object)NoOfPages), new SqlParameter("@IsAllowCSV", (object)ChkAllowCSV), new SqlParameter("@PreviewType", Type), new SqlParameter("@HighResPDFName", HighResPdfName), new SqlParameter("@HighResIMGName", TitleHighResPDFName), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(EprintConfigurationManager.ConnectionStrings["CRMConnectionString"], CommandType.StoredProcedure, "PC_InsertIn_EtTemplate", sqlParameterArray);
            return Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        public virtual long InsertCategory(long CompanyID, string CategoryName, string Description, long parentId, string CategoryImage, long UserID, string UserType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageCategory_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, CategoryName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@ParentID", DbType.Int64, parentId);
            database.AddInParameter(storedProcCommand, "@CategoryImage", DbType.String, CategoryImage);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.String, UserType);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual long InsertImageGallery(long CompanyID, long CategoryID, long UserID, string UserType, string OriginalFileName, string filename, long FileSize, string Description, string MetaTag, bool IsPDF, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageGallery_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.String, UserType);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@filename", DbType.String, filename);
            database.AddInParameter(storedProcCommand, "@FileSize", DbType.Int64, FileSize);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MetaTags", DbType.String, MetaTag);
            database.AddInParameter(storedProcCommand, "@IsPDF", DbType.Boolean, IsPDF);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual string IsCategoryDeleted(long CatID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageGallery_IsCategoryDelted");
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CatID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual DataSet IsConverted_IsCorped(long PriceCatalogueID, int DbID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectIsConverted");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@DbID", DbType.Int32, DbID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual string IsGalleryCategoryAssigned(long CategoryID, long UserID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageCategory_Assigned");
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual string IsGalleryImageAssigned(long ImageID, long UserID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_GalleryImage_Assigned");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, ImageID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual string IsImageDeleted(long ImgID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ImageGallery_IsImageDelted");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, ImgID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            empty = dataTable.Rows[0][0].ToString();
            return empty;
        }

        public virtual DataSet JobReport_CustomizeCustomer(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_GetJobProduct_Report");
            //DbCommand storedProcCommand = database.GetStoredProcCommand("pc_GetJobProduct_Report_TestAllocatReport");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.DateTime, ToDate);
            database.AddInParameter(storedProcCommand, "@Condition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }

        /// <summary>
        ///  added new report "Stock Product Sales (Release) Report" [Ticket #6174 ] by shehzad
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="ClientID"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <param name="WhereCondition"></param>
        /// <returns></returns>

        public virtual DataSet JobReport_CustomizeCustomer2(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            //DbCommand storedProcCommand = database.GetStoredProcCommand("pc_GetJobProduct_Report");            
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_GetJobProduct_Report_ForReleasedJobs");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.DateTime, ToDate);
            database.AddInParameter(storedProcCommand, "@Condition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void LargeFormatPress_AccountingCode_Insert(long CompanyID, long PressID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_LargeFormatPress_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int LargeFormatPress_AccountingCode_Select(long CompanyID, long PressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_LargeFormatPress_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressID", DbType.Int64, PressID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Litho_press_AccountingCode_Insert(long CompanyID, long LithoPressID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Litho_press_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int LithoPress_AccountingCode_Select(long CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_LithoPress_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void ManageCampign_Insert_Update(long CompanyID, long UserID, long AccountID, long ManageID, string EventTitle, string Venue, string EventCode, DateTime StartDate, DateTime EndDate, string UseType, bool IsArchive, string OrderNumber, long DeliveryAddressID, DateTime DeliveryDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_ManageCamgain_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
            database.AddInParameter(storedProcCommand, "@Eventname", DbType.String, EventTitle);
            database.AddInParameter(storedProcCommand, "@Venue", DbType.String, Venue);
            database.AddInParameter(storedProcCommand, "@EventCode", DbType.String, EventCode);
            database.AddInParameter(storedProcCommand, "@EventStartdate", DbType.DateTime, StartDate);
            database.AddInParameter(storedProcCommand, "@EventEnddate", DbType.DateTime, EndDate);
            database.AddInParameter(storedProcCommand, "@Createdbytype", DbType.String, UseType);
            database.AddInParameter(storedProcCommand, "@IsArchive", DbType.Boolean, IsArchive);
            database.AddInParameter(storedProcCommand, "@OrderNumber ", DbType.String, OrderNumber);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID ", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@DeliveryDate", DbType.DateTime, DeliveryDate);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public long MasterTemplate_Insert(long DbID, int CreadtedBy, int CompanyID, string Title, string PdfName, long PriceCatalogueID, bool IsOverPrintFileRequired, double CropMarkWidth, double CropNarkHeight, bool IsAllowPDFPreview, bool IsPdfPreviewMandotrory, bool IsAllowWaterMark, string WaterMarkText, long NoOfPages, string Type, string TitleHighResPDFName, string HighResPdfName)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@DBID", (object)DbID), new SqlParameter("@CreatedBy", (object)CreadtedBy), new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@Title", Title), new SqlParameter("@PDFName", PdfName), new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID), new SqlParameter("@isOverPrintFileRequired", (object)IsOverPrintFileRequired), new SqlParameter("@CropMarkWidth", (object)CropMarkWidth), new SqlParameter("@CropMarkHeight", (object)CropNarkHeight), new SqlParameter("@isAllowPDFPreviews", (object)IsAllowPDFPreview), new SqlParameter("@isPDFPreviewMandatory", (object)IsPdfPreviewMandotrory), new SqlParameter("@isAllowWaterMark", (object)IsAllowWaterMark), new SqlParameter("@WaterMarkText", WaterMarkText), new SqlParameter("@NoOfPages", (object)NoOfPages), new SqlParameter("@PreviewType", Type), new SqlParameter("@HighResActualName", TitleHighResPDFName), new SqlParameter("@HighResPDFName", HighResPdfName), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"], CommandType.StoredProcedure, "et_MasterTemplate_InsertUpdate", sqlParameterArray);
            return Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        public long MasterTemplate_InsertBlankPDFDetails(long DbID, int CreadtedBy, int CompanyID, string PDFName, string ImageName, string Title, long PriceCatalogueID, double Pageheight, double Pagewidth, double zoomx, double zoomy, double zoompercentage, bool isOverPrintFileRequired, double CropMarkWidth, double CropMarkHeight, bool isAllowPDFPreviews, bool isPDFPreviewMandatory, bool isAllowWaterMark, string WaterMarkText, int NoOfPages)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@DBID", (object)DbID), new SqlParameter("@CreatedBy", (object)CreadtedBy), new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@Title", Title), new SqlParameter("@PDFName", PDFName), new SqlParameter("@PriceCatalogueID", (object)PriceCatalogueID), new SqlParameter("@isOverPrintFileRequired", (object)isOverPrintFileRequired), new SqlParameter("@CropMarkWidth", (object)CropMarkWidth), new SqlParameter("@CropMarkHeight", (object)CropMarkHeight), new SqlParameter("@isAllowPDFPreviews", (object)isAllowPDFPreviews), new SqlParameter("@isPDFPreviewMandatory", (object)isPDFPreviewMandatory), new SqlParameter("@isAllowWaterMark", (object)isAllowWaterMark), new SqlParameter("@WaterMarkText", WaterMarkText), new SqlParameter("@NoOfPages", (object)NoOfPages), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"], CommandType.StoredProcedure, "et_MasterTemplate_InsertBlankPDF", sqlParameterArray);
            return Convert.ToInt64(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        public virtual DataTable notenc_password_select()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("sp_notenc_password_select")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OrderDetailsReport(long CompanyID, string ClientId, DateTime FromDate, DateTime Todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_OrderDetails_Report");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.String, ClientId);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.DateTime, Todate);
            database.AddInParameter(storedProcCommand, "@ISStockItem", DbType.String, ISStockItem);
            database.AddInParameter(storedProcCommand, "@IsStockReplenish", DbType.String, IsStockReplenish);
            database.AddInParameter(storedProcCommand, "@AllowUnApprovedOrder", DbType.Boolean, AllowUnApprovedOrder);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OtherCost_AccountingCode_Insert(long CompanyID, long OtherCostID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_OtherCost_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int OtherCost_AccountingCode_Select(long CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_OtherCost_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void othercost_category_order_number_update(int CompanyID, long OthercostCategoryID, int OrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othercost_category_order_number_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OthercostCategoryID", DbType.Int64, OthercostCategoryID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void othercost_oncategory_Insert(long CompanyID, long OtherCostID, string EstimateType, long OrderNo, bool isMandatory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCostSequence_Save");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@SortWeight", DbType.Int64, OrderNo);
            database.AddInParameter(storedProcCommand, "@isMandatory", DbType.Boolean, isMandatory);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable othercost_oncategory_select(int CompanyID, long OtherCostCategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_oncategory_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, OtherCostCategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void othercost_oncategory_Update(long CompanyID, long ID, int SortWeight)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCostSequence_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@SortWeight", DbType.Int32, SortWeight);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void othercost_sequence_Delete(long CompanyID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCostSequence_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable othercost_sequence_select(long CompanyID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCostSequence_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string paper_size_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_paper_size_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public void PaymentTerm_Details_Delete(int PaymentTermID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentTerm_Details_Delete");
            database.AddInParameter(storedProcCommand, "@PaymentTermID", DbType.Int32, PaymentTermID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable PaymentTerm_Details_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentTerm_Details_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void PaymentTerms_Detail_Insert(long CompanyID, string PaymentName, string PaymentDays, bool IsDefault, int PaymentTermID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentTerm_Details_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, PaymentName);
            database.AddInParameter(storedProcCommand, "@Days", DbType.Int32, PaymentDays);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.AddInParameter(storedProcCommand, "@PaymentTermID", DbType.Int32, PaymentTermID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable PhraseBook_Colour_Size_Material_Select(long CompanyID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PhraseBook_Colour_Size_Material_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string PODeliveryAddress_BasedonSettings_Select(int CompanyID, string EstimateType)
        {
            string str;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_POdeliveryAddress_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable.Rows.Count <= 0)
            {
                return "c";
            }
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    if (EstimateType.ToLower() == "s" || EstimateType.ToLower() == "b" || EstimateType.ToLower() == "b")
                    {
                        str = current["Digital"].ToString();
                    }
                    else if (EstimateType.ToLower() == "l")
                    {
                        str = current["LargeFormat"].ToString();
                    }
                    else if (EstimateType.ToLower() == "f" || EstimateType.ToLower() == "k" || EstimateType.ToLower() == "d" || EstimateType.ToLower() == "n")
                    {
                        str = current["Offset"].ToString();
                    }
                    else if (EstimateType.ToLower() == "u")
                    {
                        str = current["OtherCost"].ToString();
                    }
                    else if (EstimateType.ToLower() == "o")
                    {
                        str = current["Outwork"].ToString();
                    }
                    else if (EstimateType.ToLower() == "c")
                    {
                        str = current["PriceCatalogue"].ToString();
                    }
                    else if (EstimateType.ToLower() == "q")
                    {
                        str = current["QuickQuote"].ToString();
                    }
                    else if (EstimateType.ToLower() == "w")
                    {
                        str = current["Warehouse"].ToString();
                    }
                    else if (EstimateType.ToLower() == "descriptioninclude")
                    {
                        str = current["DescriptionInclude"].ToString();
                    }
                    else if (EstimateType.ToLower() != "x")
                    {
                        str = (EstimateType.ToLower() != "directpo" ? "c" : current["DirectPO"].ToString());
                    }
                    else
                    {
                        str = current["order"].ToString();
                    }
                }
                else
                {
                    return "c";
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return str;
        }

        public virtual DataTable PreFlight_Options_Select(string Type, int TypeId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PreFlight_Options_Select");
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@TypeId", DbType.Int32, TypeId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PreFlightProfile_Insert(string ProfileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PreFlightProfile_Insert");
            database.AddInParameter(storedProcCommand, "@ProfileName", DbType.String, ProfileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int price_catalogue_copy(int CompanyID, int UserID, int PriceCatalogueID)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_price_catalogue_copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void Price_Catalogue_Order_Number_Update(int CompanyID, long PriceCatalogueID, int OrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Price_Catalogue_Order_Number_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Price_For_Whole_Pack_Insert(int CompanyID, bool DefaultPriceForWholePack, string DefaultEstimateType, int Roundoff, string DefaultOutworkMarkpupType, bool DefaultPORaise, bool DefaultDelivaryRaise, bool UpdateItemDescription, string WorkingDaysFrom, string WorkingDaysTo, string RoundoffSubtotal, bool IsRoundLock, int DefaultPaperSize, bool DigitalSingle, bool DigitalBooklet, bool DigitalPad, bool OffsetSingle, bool OffsetBooklet, bool OffsetPad, bool OffsetNCR, bool LargeFormatLinear, bool LargeFormatsquaremeter, bool IsCombineItemfor_SameSupplier, bool Highlightsellingprice, char ProductSelectType, bool AllowPrintReadyFile, bool AllowUnApprovedOrder, bool AllowSorting, bool CopyOutworkDescFieldsToSupplier, bool AllowSortingPopup, bool chkSumCondensedView, bool chkUnitPrice,int PaymentMethod, bool DontTickDescbox, int DefaultCostingType,bool chkisaddheadings,bool chk3DecimalPlaces, bool chkEnblePriority, bool MandatoryReplenishments)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_price_for_pack_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DefaultPriceForWholePack", DbType.Boolean, DefaultPriceForWholePack);
            database.AddInParameter(storedProcCommand, "@DefaultEstimateType", DbType.String, DefaultEstimateType);
            
            database.AddInParameter(storedProcCommand, "@Roundoff", DbType.Int32, Roundoff);
            database.AddInParameter(storedProcCommand, "@OutworkMarkuptype", DbType.String, DefaultOutworkMarkpupType);
            database.AddInParameter(storedProcCommand, "@DefaultPORaise", DbType.Boolean, DefaultPORaise);
            database.AddInParameter(storedProcCommand, "@DefaultDelivaryRaise", DbType.Boolean, DefaultDelivaryRaise);
            database.AddInParameter(storedProcCommand, "@UpdateItemDescription", DbType.Boolean, UpdateItemDescription);
            database.AddInParameter(storedProcCommand, "@WorkingDaysFrom", DbType.String, WorkingDaysFrom);
            database.AddInParameter(storedProcCommand, "@WorkingDaysTo", DbType.String, WorkingDaysTo);
            database.AddInParameter(storedProcCommand, "@RoundoffSubtotal", DbType.String, RoundoffSubtotal);
            database.AddInParameter(storedProcCommand, "@IsRoundLock", DbType.Boolean, IsRoundLock);
            database.AddInParameter(storedProcCommand, "@DefaultPaperSize", DbType.Int32, DefaultPaperSize);
            database.AddInParameter(storedProcCommand, "@Digital_Single", DbType.Boolean, DigitalSingle);
            database.AddInParameter(storedProcCommand, "@Digital_Booklet", DbType.Boolean, DigitalBooklet);
            database.AddInParameter(storedProcCommand, "@Digital_Pad", DbType.Boolean, DigitalPad);
            database.AddInParameter(storedProcCommand, "@Offset_Single", DbType.Boolean, OffsetSingle);
            database.AddInParameter(storedProcCommand, "@Offset_Booklet", DbType.Boolean, OffsetBooklet);
            database.AddInParameter(storedProcCommand, "@Offset_Pad", DbType.Boolean, OffsetPad);
            database.AddInParameter(storedProcCommand, "@Offset_NCR", DbType.Boolean, OffsetNCR);
            database.AddInParameter(storedProcCommand, "@ItemDescLinear", DbType.Boolean, LargeFormatLinear);
            database.AddInParameter(storedProcCommand, "@ItemDescSquare_Meter", DbType.Boolean, LargeFormatsquaremeter);
            database.AddInParameter(storedProcCommand, "@IsCombineItemfor_SameSupplier", DbType.Boolean, IsCombineItemfor_SameSupplier);
            database.AddInParameter(storedProcCommand, "@Highlightsellingprice", DbType.Boolean, Highlightsellingprice);
            database.AddInParameter(storedProcCommand, "@Productcatlg_ItemDisplay", DbType.String, ProductSelectType);
            database.AddInParameter(storedProcCommand, "@AllowPrintReadyFile", DbType.Boolean, AllowPrintReadyFile);
            database.AddInParameter(storedProcCommand, "@AllowUnApprovedOrder", DbType.Boolean, AllowUnApprovedOrder);
            database.AddInParameter(storedProcCommand, "@AllowSorting", DbType.Boolean, AllowSorting);
            database.AddInParameter(storedProcCommand, "@CopyOutworkDescFieldsToSupplier", DbType.Boolean, CopyOutworkDescFieldsToSupplier);
            database.AddInParameter(storedProcCommand, "@AllowSortingPopup", DbType.Boolean, AllowSortingPopup);
            database.AddInParameter(storedProcCommand, "@chkSumCondensedView", DbType.Boolean, chkSumCondensedView);
            database.AddInParameter(storedProcCommand, "@chkUnitPrice", DbType.Boolean, chkUnitPrice);
            database.AddInParameter(storedProcCommand, "@InvoicePaymentMethod", DbType.Int32, PaymentMethod);
            database.AddInParameter(storedProcCommand, "@DontTickDescbox", DbType.Boolean, DontTickDescbox);
            database.AddInParameter(storedProcCommand, "@DefaultCostingType", DbType.Int32, DefaultCostingType);
            database.AddInParameter(storedProcCommand, "@chkIsAddDescHeadings", DbType.Boolean, chkisaddheadings);
            database.AddInParameter(storedProcCommand, "@chk3DecimalPlaces", DbType.Boolean, chk3DecimalPlaces);
            database.AddInParameter(storedProcCommand, "@chkEnblePriority", DbType.Boolean, chkEnblePriority);
            database.AddInParameter(storedProcCommand, "@MandatoryReplenishments", DbType.Boolean, MandatoryReplenishments);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void PC_settings_default_Dates_insert(int CompanyID, int ValidFor, string DefaultEstimatedArtwork, string DefaultEstimatedProof, string DefaultEstimatedApproval, string DefaultEstimatedProduction, string DefaultEstimatedCompletion, string DefaultEstimatedDelivery, bool IsDefaultArtwork, bool IsDefaultProof, bool IsDefaultApproval, bool IsDefaultProduction, bool IsDefaultCompletion, bool IsDefaultDelivery, bool IsDefaultCustomDate1, bool IsDefaultCustomDate2, bool IsDefaultCustomDate3, bool IsDefaultCustomDate4, bool IsDefaultCustomDate5, string DefaultCustomDate1, string DefaultCustomDate2, string DefaultCustomDate3, string DefaultCustomDate4, string DefaultCustomDate5, string DefaultCustomDateTitle1, string DefaultCustomDateTitle2, string DefaultCustomDateTitle3, string DefaultCustomDateTitle4, string DefaultCustomDateTitle5)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_Dates_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            database.AddInParameter(storedProcCommand, "@ValidFor", DbType.Int32, ValidFor);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedArtwork", DbType.String, DefaultEstimatedArtwork);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedProof", DbType.String, DefaultEstimatedProof);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedApproval", DbType.String, DefaultEstimatedApproval);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedProduction", DbType.String, DefaultEstimatedProduction);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedCompletion", DbType.String, DefaultEstimatedCompletion);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedDelivery", DbType.String, DefaultEstimatedDelivery);
            database.AddInParameter(storedProcCommand, "@IsDefaultArtwork", DbType.Boolean, IsDefaultArtwork);
            database.AddInParameter(storedProcCommand, "@IsDefaultProof", DbType.Boolean, IsDefaultProof);
            database.AddInParameter(storedProcCommand, "@IsDefaultApproval", DbType.Boolean, IsDefaultApproval);
            database.AddInParameter(storedProcCommand, "@IsDefaultProduction", DbType.Boolean, IsDefaultProduction);
            database.AddInParameter(storedProcCommand, "@IsDefaultCompletion", DbType.Boolean, IsDefaultCompletion);
            database.AddInParameter(storedProcCommand, "@IsDefaultDelivery", DbType.Boolean, IsDefaultDelivery);
            database.AddInParameter(storedProcCommand, "@IsDefaultCustomDate1", DbType.Boolean, IsDefaultCustomDate1);
            database.AddInParameter(storedProcCommand, "@IsDefaultCustomDate2", DbType.Boolean, IsDefaultCustomDate2);
            database.AddInParameter(storedProcCommand, "@IsDefaultCustomDate3", DbType.Boolean, IsDefaultCustomDate3);
            database.AddInParameter(storedProcCommand, "@IsDefaultCustomDate4", DbType.Boolean, IsDefaultCustomDate4);
            database.AddInParameter(storedProcCommand, "@IsDefaultCustomDate5", DbType.Boolean, IsDefaultCustomDate5);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDate1", DbType.String, DefaultCustomDate1);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDate2", DbType.String, DefaultCustomDate2);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDate3", DbType.String, DefaultCustomDate3);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDate4", DbType.String, DefaultCustomDate4);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDate5", DbType.String, DefaultCustomDate5);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDateTitle1", DbType.String, DefaultCustomDateTitle1);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDateTitle2", DbType.String, DefaultCustomDateTitle2);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDateTitle3", DbType.String, DefaultCustomDateTitle3);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDateTitle4", DbType.String, DefaultCustomDateTitle4);
            database.AddInParameter(storedProcCommand, "@DefaultCustomDateTitle5", DbType.String, DefaultCustomDateTitle5);

            database.ExecuteNonQuery(storedProcCommand);
        }


        public virtual DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_price_for_pack_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        ///Added by Amin


        public virtual string PC_select_ProductEditingOption_Status(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("SELECT ISNULL( tb_Company.PrdoductEditingOptions,'') as PrdoductEditingOptions from tb_Company where companyID= ", CompanyID));

            return (string)database.ExecuteScalar(sqlStringCommand);
        }

        public virtual DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_DeliveryCost_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_select_MIS_DeliveryCost_Settings(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_MIS_DeliveryCost_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }


        public virtual void PC_Update_ProductEditingOption_Status(long ID, string Status)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_ProductEditingOption_Status");
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Double, ID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void PC_Update_DeliveryCost_Settings(int CompanyID, int AccountID, bool IsEnableDC, bool IsEnableShipEngine, bool Allowpickup)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_DeliveryCost_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@IsEnableDC", DbType.Boolean, IsEnableDC);
            database.AddInParameter(storedProcCommand, "@IsEnableShipEngine", DbType.Boolean, IsEnableShipEngine);
            database.AddInParameter(storedProcCommand, "@Allowpickup", DbType.Boolean, Allowpickup);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void PC_Update_MIS_DeliveryCost_Settings(int CompanyID, bool IsEnableDC, bool IsEnableShipEngine, bool Allowpickup)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_MIS_DeliveryCost_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsEnableDC", DbType.Boolean, IsEnableDC);
            database.AddInParameter(storedProcCommand, "@IsEnableShipEngine", DbType.Boolean, IsEnableShipEngine);
            database.AddInParameter(storedProcCommand, "@Allowpickup", DbType.Boolean, Allowpickup);
            database.ExecuteNonQuery(storedProcCommand);
        }


        public virtual DataTable Pricecatalog_Import(long CompanyID, string IsFromWebStore, string EstimateType, string MatrixType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Pricecatalog_Import");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsFromWebStore", DbType.String, IsFromWebStore);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@MatrixType", DbType.String, MatrixType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PriceCatalogue_AccountingCode_Insert(long CompanyID, long PriceCatalogueID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_PriceCatalogue_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int PriceCatalogue_AccountingCode_Select(long CompanyID, long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_PriceCatalogue_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public void PriceCatalogue_Allocation_Insert(int id, int CustomerID, int AccountID, string AllocationType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PriceCatalogue_Allocation_Insert");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, id);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@AllocationType", DbType.String, AllocationType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void PriceCatalogue_Allocation_Remove(int id, string AllocationType, int CustomerID, string From)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_Allocation_Remove");
            database.AddInParameter(storedProcCommand, "@id", DbType.Int64, id);
            database.AddInParameter(storedProcCommand, "@AllocatedType", DbType.String, AllocationType);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@From", DbType.String, From);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable PriceCatalogue_Allocation_Select(int companyid, string allocationType, long ID, string From)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_Allocation_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@AllocatedType", DbType.String, allocationType);
            database.AddInParameter(storedProcCommand, "@id", DbType.Int32, ID);
            database.AddInParameter(storedProcCommand, "@From", DbType.String, From);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PriceCatalogue_Category_Delete(int CompanyID, int PriceCatalogueCategoryID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_category_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, PriceCatalogueCategoryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int PriceCatalogue_Category_Insert(int CompanyID, string PriceCatalogueCategoryName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_category_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryName", DbType.String, PriceCatalogueCategoryName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));
        }

        public virtual DataTable PriceCatalogue_Category_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_category_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int PriceCatalogue_CategoryID_Import(int CompanyID, string PriceCatalogueCategoryName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_CategoryID_Import");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryName", DbType.String, PriceCatalogueCategoryName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));
        }

        public DataTable PriceCatalogue_Customer_View(int CompanyID, long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_Customer_View");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        //Modification Stage 1 New Sp added for multiple Delivery Note No view Pop up
        public DataTable DeliveryNote_Number_View(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DeliveryNote_Number_View");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        //Modification Stage 1 New Sp added for multiple Purchase No view Pop up
        public DataTable Purchase_Number_View(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Purchase_Number_View");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int PriceCatalogue_DeleteCatalogueID_Exsists(int CompanyID, int CategoryID, string Itemcode)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_DeleteCatalogueID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
            database.AddInParameter(storedProcCommand, "@Itemcode", DbType.String, Itemcode);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));
        }

        public virtual int PriceCatalogue_PriceCatalogueID_Exsists(int CompanyID, int CategoryID, string Itemcode, string ItemTitle)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_PriceCatalogueID_Exsists");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int32, CategoryID);
            database.AddInParameter(storedProcCommand, "@Itemcode", DbType.String, Itemcode);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : Convert.ToInt32(parameterValue));
        }

        public virtual DataTable PriceCatalogue_webothercost_Select(int companyid, long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_webothercost_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long PriceCatalogueFeatures_Insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueFeatures_Insert");
            database.AddInParameter(storedProcCommand, "@FeaturedName", DbType.String, item.FeaturedName);
            database.AddInParameter(storedProcCommand, "@NoOfOptions", DbType.Int32, item.NoOfOptions);
            database.AddInParameter(storedProcCommand, "@FeaturedDescription", DbType.String, item.FeaturedDescription);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, item.UserID);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, item.CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataSet PriceCatalogueFeatures_select(int CompanyID, int PriceCatalogueFeautredID, int maximumRows, int startRowIndex)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueFeatures_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueFeautredID", DbType.Int32, PriceCatalogueFeautredID);
            database.AddInParameter(storedProcCommand, "@maximumRows", DbType.Int32, PriceCatalogueFeautredID);
            database.AddInParameter(storedProcCommand, "@startRowIndex", DbType.Int32, PriceCatalogueFeautredID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public int Product_AddEditAccess_Check(int CompanyId, int UserId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_product_AddEditAccess_Check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserId);
            return Convert.ToInt32(database.ExecuteScalar(storedProcCommand));
        }

        public virtual DataTable Product_Customer_Select(long companyid, long ID, string AllocationType, string From)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Product_Customer_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@AllocationType", DbType.String, AllocationType);
            database.AddInParameter(storedProcCommand, "@From", DbType.String, From);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Product_ItemTitle_Select(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Product_ItemTitle_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            return ((string)database.ExecuteScalar(storedProcCommand) == null ? "" : (string)database.ExecuteScalar(storedProcCommand));
        }

        public virtual void productcatalogue_StockReminderEmail_delete(int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PriceCatalogueStock_EmailBody_Delete");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable productcatalogue_StockReminderEmail_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueStock_EmailBody_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable productcatalogue_StockReminderEmail_selectedrow(int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueStock_EmailBody_SelectedRow");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void productcatalogue_StockReminderEmailBody_insert(int CompanyID, int UserID, string TemplateName, string EmailBody, int IsDefault, string Subject)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PriceCatalogueStock_EmailBody_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, EmailBody);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, IsDefault);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void productcatalogue_StockReminderEmailBody_update(int EmailID, string TemplateName, string EmailBody, int IsDefault, string Subject)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PriceCatalogueStock_EmailBody_Update");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, EmailBody);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, IsDefault);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void productcatalogue_warehouselocation_delete(int LocationID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Location_Delete");
            database.AddInParameter(storedProcCommand, "@Locationid", DbType.Int32, LocationID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void productcatalogue_warehouselocation_insert(int companyid, string LocationName, string Address, string City, string Suburb, string PostCode, string Country, string Telephone, int IsDefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Location_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@LocationName", DbType.String, LocationName);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, Suburb);
            database.AddInParameter(storedProcCommand, "@zipcode", DbType.String, PostCode);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, IsDefault);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable productcatalogue_warehouselocation_select(int companyid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Location_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void productcatalogue_warehouselocation_update(int companyid, int LocationID, string LocationName, string Address, string City, string Suburb, string PostCode, string Country, string Telephone, int IsDefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Location_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@Locationid", DbType.Int32, LocationID);
            database.AddInParameter(storedProcCommand, "@LocationName", DbType.String, LocationName);
            database.AddInParameter(storedProcCommand, "@Address", DbType.String, Address);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, Suburb);
            database.AddInParameter(storedProcCommand, "@zipcode", DbType.String, PostCode);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, IsDefault);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable productcatalogue_warehousestock_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Stock_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void productcatalogue_warehousestock_update(int CompanyID, string FieldName, string ScreenName, int IsDisplay)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Stock_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DataFieldName", DbType.String, FieldName);
            database.AddInParameter(storedProcCommand, "@ScreenName", DbType.String, ScreenName);
            database.AddInParameter(storedProcCommand, "@IsDisplay", DbType.Int32, IsDisplay);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable ProductReport_CustomizeCustomer(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_GetProduct_Report");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.DateTime, ToDate);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        // added code for new report "Stock Release and Adjustment Report 2" by shehzad

        public virtual DataTable ProductReport_CustomizeCustomer2(long CompanyID, long ClientID, DateTime FromDate, DateTime ToDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_GetProduct_Report2");
            storedProcCommand.CommandTimeout = int.MaxValue;
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.DateTime, ToDate);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProductstockUsageReport(long CompanyID, string ClientId, string DepartmentId, string MonthCatagory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockProductUsage_Report");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.String, ClientId);
            database.AddInParameter(storedProcCommand, "@DepartmentId", DbType.String, DepartmentId);
            database.AddInParameter(storedProcCommand, "@MonthCatagory", DbType.String, MonthCatagory);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProductstockUsageHistoryReport(long CompanyID, string ClientId, string DepartmentId, string MonthCatagory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockProductUsageHistory_Report");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.String, ClientId);
            database.AddInParameter(storedProcCommand, "@DepartmentId", DbType.String, DepartmentId);
            database.AddInParameter(storedProcCommand, "@MonthCatagory", DbType.String, MonthCatagory);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void ProductVisibility_Item(string type, string IDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogue_ProductVisibility_Update");
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@ProductIDs", DbType.String, IDs);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Purchase_AccountingCode_Insert(long CompanyID, long PurchaseID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Purchase_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Purchase_AccountingCode_Select(long CompanyID, long PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Purchase_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int64, PurchaseID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet Report_ActivitytaskEvent_select(int companyID, int PageSize, int PageNumber, long UserID, string Columns, string GroupBy, string CompanyType, string ReportName, string Description, string SaveType, long ReportID, string PageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ActivityTaskEvent_Report");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, PageSize);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, PageNumber);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@Columns", DbType.String, Columns);
            database.AddInParameter(storedProcCommand, "@GroupBy", DbType.String, GroupBy);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@ReportName", DbType.String, ReportName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@SaveType", DbType.String, SaveType);
            database.AddInParameter(storedProcCommand, "@ReportID", DbType.Int64, ReportID);
            database.AddInParameter(storedProcCommand, "@Pagename", DbType.String, PageName);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet report_pricecatalogue_select(int companyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string Columns, string Qtyoption, string IsPriceChecked, string SearchText, string Catagory, string Customer, string PublicAccount, string IsSpecific, string ISDateChecked, string SaveType, string DateType, string CompanyName, string ReportName, string Description, string PageName, long UserID, long ReportID, string FromDate, string ToDate, string createdDate, string CategoryID, int ClientID, int IsNonEditable, int IsStock, int IsEditable, int IsOpeningStock, int IsLocation, int IsQtyAdded, int IsQtySold, int IsQtyAdjustedIncreament, int IsQtyAdjustedDecrement, int IsDetailedAdditionalOptionStock)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatelogue_Report");
            // Ticket #8923 dmc timeout error
            storedProcCommand.CommandTimeout = 1000;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, PageSize);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, PageNumber);
            database.AddInParameter(storedProcCommand, "@SortBy", DbType.String, SortBy);
            database.AddInParameter(storedProcCommand, "@SortDirection", DbType.String, SortDirection);
            database.AddInParameter(storedProcCommand, "@Columns", DbType.String, Columns);
            database.AddInParameter(storedProcCommand, "@Qtyoption", DbType.String, Qtyoption);
            database.AddInParameter(storedProcCommand, "@IsPriceChecked", DbType.String, IsPriceChecked);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@Catagory", DbType.String, Catagory);
            database.AddInParameter(storedProcCommand, "@Customer", DbType.String, Customer);
            database.AddInParameter(storedProcCommand, "@PublicAccount", DbType.String, PublicAccount);
            database.AddInParameter(storedProcCommand, "@IsSpecific", DbType.String, IsSpecific);
            database.AddInParameter(storedProcCommand, "@ISDateChecked", DbType.String, ISDateChecked);
            database.AddInParameter(storedProcCommand, "@SaveType", DbType.String, SaveType);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@ReportName", DbType.String, ReportName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@ReportID", DbType.Int64, ReportID);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.DateTime, ToDate);
            database.AddInParameter(storedProcCommand, "@createdDate", DbType.DateTime, createdDate);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.String, CategoryID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@IsNonEditable", DbType.Int16, IsNonEditable);
            database.AddInParameter(storedProcCommand, "@IsStock", DbType.Int16, IsStock);
            database.AddInParameter(storedProcCommand, "@IsEditable", DbType.Int16, IsEditable);
            database.AddInParameter(storedProcCommand, "@IsOpeningStock", DbType.Int16, IsOpeningStock);
            database.AddInParameter(storedProcCommand, "@IsLocation", DbType.Int16, IsLocation);
            database.AddInParameter(storedProcCommand, "@IsQtyAdded", DbType.Int16, IsQtyAdded);
            database.AddInParameter(storedProcCommand, "@IsQtySold", DbType.Int16, IsQtySold);
            database.AddInParameter(storedProcCommand, "@IsQtyAdjustedIncreament", DbType.Int16, IsQtyAdjustedIncreament);
            database.AddInParameter(storedProcCommand, "@IsQtyAdjustedDecrement", DbType.Int16, IsQtyAdjustedDecrement);
            database.AddInParameter(storedProcCommand, "@IsDetailedAdditionalOptionStock", DbType.Int16, IsDetailedAdditionalOptionStock);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable ReturnScreenName_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ReturnScreenName_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void Roles_AccessDetails_Insert(long RoleID, string SectionName, int AddEdit, int Read, int Tab_Delete, int Show, string Others, string PrintorEmail, string ExportorImport, string Revert, long CompanyID, string IsTaskEventCall, string IsForecast, string IsRemove)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_RoleTab_Insert_New");
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int64, RoleID);
            database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
            database.AddInParameter(storedProcCommand, "@IsAdd", DbType.Int16, AddEdit);
            database.AddInParameter(storedProcCommand, "@IsView", DbType.Int16, Read);
            database.AddInParameter(storedProcCommand, "@IsDelete", DbType.Int16, Tab_Delete);
            database.AddInParameter(storedProcCommand, "@IsDisplay", DbType.Int16, Show);
            database.AddInParameter(storedProcCommand, "@Others", DbType.String, Others);
            database.AddInParameter(storedProcCommand, "@PrintorEmail", DbType.String, PrintorEmail);
            database.AddInParameter(storedProcCommand, "@ExportorImport", DbType.String, ExportorImport);
            database.AddInParameter(storedProcCommand, "@Revert", DbType.String, Revert);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsTaskEventCall", DbType.Int64, IsTaskEventCall);
            database.AddInParameter(storedProcCommand, "@IsForecast", DbType.Int64, IsForecast);
            database.AddInParameter(storedProcCommand, "@IsRemove", DbType.Int64, IsRemove);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Roles_AccessDetails_Update(long RoleID, string SectionName, int AddEdit, int Read, int Tab_Delete, int archive, int Show, string Others, string PrintorEmail, string ExportorImport, string Revert, long CompanyID, string IsTaskEventCall, string IsForecast, string IsRemove)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_RoleTab_Update_New");
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int64, RoleID);
            database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
            database.AddInParameter(storedProcCommand, "@IsAdd", DbType.Int16, AddEdit);
            database.AddInParameter(storedProcCommand, "@IsView", DbType.Int16, Read);
            database.AddInParameter(storedProcCommand, "@IsDelete", DbType.Int16, Tab_Delete);
            database.AddInParameter(storedProcCommand, "@isArchive", DbType.Int16, archive);
            database.AddInParameter(storedProcCommand, "@IsDisplay", DbType.Int16, Show);
            database.AddInParameter(storedProcCommand, "@Others", DbType.String, Others);
            database.AddInParameter(storedProcCommand, "@PrintorEmail", DbType.String, PrintorEmail);
            database.AddInParameter(storedProcCommand, "@ExportorImport", DbType.String, ExportorImport);
            database.AddInParameter(storedProcCommand, "@Revert", DbType.String, Revert);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsTaskEventCall", DbType.Int64, IsTaskEventCall);
            database.AddInParameter(storedProcCommand, "@IsForecast", DbType.Int64, IsForecast);
            database.AddInParameter(storedProcCommand, "@IsRemove", DbType.String, IsRemove);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Roles_ReportDetails_Insert(long RoleID, int ShowReport, int ExportReport, long CompanyID, string ReportItems, int ReportOrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_RoleReport_Insert");
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int64, RoleID);
            database.AddInParameter(storedProcCommand, "@ShowReport", DbType.Int16, ShowReport);
            database.AddInParameter(storedProcCommand, "@ExportReport", DbType.Int16, ExportReport);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ReportItems", DbType.String, ReportItems);
            database.AddInParameter(storedProcCommand, "@ReportOrderNumber", DbType.Int16, ReportOrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Roles_ReportDetails_Update(long RoleID, int ShowReport, int ExportReport, long CompanyID, string ReportItems, int ReportOrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_RoleReport_Update");
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int64, RoleID);
            database.AddInParameter(storedProcCommand, "@ShowReport", DbType.Int16, ShowReport);
            database.AddInParameter(storedProcCommand, "@ExportReport", DbType.Int16, ExportReport);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ReportItems", DbType.String, ReportItems);
            database.AddInParameter(storedProcCommand, "@ReportOrderNumber", DbType.Int16, ReportOrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public long Roles_StaticCheckBox_Insert(string RoleName, int CompanyId, string Description, bool showCostExMarkup, bool showMarkup, bool showCostIncMarkup, bool showProfitMargin, bool showProfitInCurrency, bool showSubTotal, bool showTax, bool showSellingPrice, bool showGrossProfitMargin, bool showGrossProfit, bool showSupplierName, bool showPrice, bool showCalculated, bool showSubItems, string unSuccessfulLoginAttemptCount, string changePWDAfterSelectedDays, string restrictSystemIPforUnauthorizedEmailAccess, bool isDelete, bool isSpecialPrivilege, string ShowRecords, string EditRecords, string TypeList, string IPType, string IPList)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_StaticCheckBoxList_Insert_New");
            database.AddInParameter(storedProcCommand, "@RoleName", DbType.String, RoleName);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int16, CompanyId);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@showCostExMarkup", DbType.Boolean, showCostExMarkup);
            database.AddInParameter(storedProcCommand, "@showMarkup", DbType.Boolean, showMarkup);
            database.AddInParameter(storedProcCommand, "@showCostIncMarkup", DbType.Boolean, showCostIncMarkup);
            database.AddInParameter(storedProcCommand, "@showProfitMargin", DbType.Boolean, showProfitMargin);
            database.AddInParameter(storedProcCommand, "@showProfitInCurrency", DbType.Boolean, showProfitInCurrency);
            database.AddInParameter(storedProcCommand, "@showSubTotal", DbType.Boolean, showSubTotal);
            database.AddInParameter(storedProcCommand, "@showTax", DbType.Boolean, showTax);
            database.AddInParameter(storedProcCommand, "@showSellingPrice", DbType.Boolean, showSellingPrice);
            database.AddInParameter(storedProcCommand, "@showGrossProfitMargin", DbType.Boolean, showGrossProfitMargin);
            database.AddInParameter(storedProcCommand, "@showGrossProfit", DbType.Boolean, showGrossProfit);
            database.AddInParameter(storedProcCommand, "@showSupplierName", DbType.Boolean, showSupplierName);
            database.AddInParameter(storedProcCommand, "@showPrice", DbType.Boolean, showPrice);
            database.AddInParameter(storedProcCommand, "@showCalculated", DbType.Boolean, showCalculated);
            database.AddInParameter(storedProcCommand, "@showSubItems", DbType.Boolean, showSubItems);
            database.AddInParameter(storedProcCommand, "@unSuccessfulLoginAttemptCount", DbType.String, unSuccessfulLoginAttemptCount);
            database.AddInParameter(storedProcCommand, "@changePWDAfterSelectedDays", DbType.String, changePWDAfterSelectedDays);
            database.AddInParameter(storedProcCommand, "@restrictSystemIPforUnauthorizedEmailAccess", DbType.String, restrictSystemIPforUnauthorizedEmailAccess);
            database.AddInParameter(storedProcCommand, "@isDelete", DbType.Boolean, isDelete);
            database.AddInParameter(storedProcCommand, "@isSpecialPrivilege", DbType.Boolean, isSpecialPrivilege);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@EditRecords", DbType.String, EditRecords);
            database.AddInParameter(storedProcCommand, "@TypeList", DbType.String, TypeList);
            database.AddInParameter(storedProcCommand, "@IPAddressType", DbType.String, IPType);
            database.AddInParameter(storedProcCommand, "@IPAddressList", DbType.String, IPList);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public void Roles_StaticCheckBox_Update(long RoleID, int CompanyId, string Description, bool showCostExMarkup, bool showMarkup, bool showCostIncMarkup, bool showProfitMargin, bool showProfitInCurrency, bool showSubTotal, bool showTax, bool showSellingPrice, bool showGrossProfitMargin, bool showGrossProfit, bool showSupplierName, bool showPrice, bool showCalculated, bool showSubItems, string unSuccessfulLoginAttemptCount, string changePWDAfterSelectedDays, string restrictSystemIPforUnauthorizedEmailAccess, bool isSpecialPrivilege, string ShowRecords, string EditRecords, string TypeList, string IPType, string IPList, Boolean Locking, Boolean IgnoreLock, bool showAdditional)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_StaticCheckBoxList_Update_New");
            database.AddInParameter(storedProcCommand, "@RoleID", DbType.Int16, RoleID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int16, CompanyId);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@showCostExMarkup", DbType.Boolean, showCostExMarkup);
            database.AddInParameter(storedProcCommand, "@showMarkup", DbType.Boolean, showMarkup);
            database.AddInParameter(storedProcCommand, "@showCostIncMarkup", DbType.Boolean, showCostIncMarkup);
            database.AddInParameter(storedProcCommand, "@showProfitMargin", DbType.Boolean, showProfitMargin);
            database.AddInParameter(storedProcCommand, "@showProfitInCurrency", DbType.Boolean, showProfitInCurrency);
            database.AddInParameter(storedProcCommand, "@showSubTotal", DbType.Boolean, showSubTotal);
            database.AddInParameter(storedProcCommand, "@showTax", DbType.Boolean, showTax);
            database.AddInParameter(storedProcCommand, "@showSellingPrice", DbType.Boolean, showSellingPrice);
            database.AddInParameter(storedProcCommand, "@showGrossProfitMargin", DbType.Boolean, showGrossProfitMargin);
            database.AddInParameter(storedProcCommand, "@showGrossProfit", DbType.Boolean, showGrossProfit);
            database.AddInParameter(storedProcCommand, "@showSupplierName", DbType.Boolean, showSupplierName);
            database.AddInParameter(storedProcCommand, "@showPrice", DbType.Boolean, showPrice);
            database.AddInParameter(storedProcCommand, "@showCalculated", DbType.Boolean, showCalculated);
            database.AddInParameter(storedProcCommand, "@showSubItems", DbType.Boolean, showSubItems);
            database.AddInParameter(storedProcCommand, "@unSuccessfulLoginAttemptCount", DbType.String, unSuccessfulLoginAttemptCount);
            database.AddInParameter(storedProcCommand, "@changePWDAfterSelectedDays", DbType.String, changePWDAfterSelectedDays);
            database.AddInParameter(storedProcCommand, "@restrictSystemIPforUnauthorizedEmailAccess", DbType.String, restrictSystemIPforUnauthorizedEmailAccess);
            database.AddInParameter(storedProcCommand, "@isSpecialPrivilege", DbType.Boolean, isSpecialPrivilege);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, ShowRecords);
            database.AddInParameter(storedProcCommand, "@EditRecords", DbType.String, EditRecords);
            database.AddInParameter(storedProcCommand, "@TypeList", DbType.String, TypeList);
            database.AddInParameter(storedProcCommand, "@IPAddressType", DbType.String, IPType);
            database.AddInParameter(storedProcCommand, "@IPAddressList", DbType.String, IPList);
            database.AddInParameter(storedProcCommand, "@Locking", DbType.Boolean, Locking);
            database.AddInParameter(storedProcCommand, "@IgnoreLock", DbType.Boolean, IgnoreLock);
            database.AddInParameter(storedProcCommand, "@showAdditional", DbType.Boolean, showAdditional);

            database.ExecuteNonQuery(storedProcCommand);
        }

        //public DataSet SelectUserTypeSettings(long companyID, long UserID)
        //{
        //    SqlCommand sqlCommand = new SqlCommand("pc_Select_User_UserTypeSettings", (new commonClass()).openConnection())
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };
        //    sqlCommand.Parameters.AddWithValue("@companyID", companyID);
        //    sqlCommand.Parameters.AddWithValue("@UserID", UserID);
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataSet dataSet = new DataSet();
        //    sqlDataAdapter.Fill(dataSet);
        //    return dataSet;
        //}

        public int Save_Estore_EmailSetting(int EmailSettingID, int AccountID, int CompanyID, string AdminTo, string AdminCc, string AdminBcc, string CustomerFrom, string CustomerCc, string CustomerBcc)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertUpdate_StoreEmailSetting");
            database.AddInParameter(storedProcCommand, "@EmailSettingID", DbType.Int64, EmailSettingID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AdminTo", DbType.String, AdminTo);
            database.AddInParameter(storedProcCommand, "@AdminCc", DbType.String, AdminCc);
            database.AddInParameter(storedProcCommand, "@AdminBcc", DbType.String, AdminBcc);
            database.AddInParameter(storedProcCommand, "@CustomerFrom", DbType.String, CustomerFrom);
            database.AddInParameter(storedProcCommand, "@CustomerCc", DbType.String, CustomerCc);
            database.AddInParameter(storedProcCommand, "@CustomerBcc", DbType.String, CustomerBcc);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void SaveCampaign(long AccountID, long CompanyID, int IsCampaign)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ManageCampaign_Update");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCampign", DbType.Int16, IsCampaign);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Select_Address_CheckBoxStatus(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Address_CheckBoxStatus");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_Alert_Notification_EmailBody(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("select_Alert_Notification_EmailBody");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_EmailSignature(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_emailsignature_title_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_JobCardSettings(long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Select_JobCardSettings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ProductStockManagement(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_ProductStockManagement");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_SystemIp_Address(long UserTypeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("AP_B2B_SelectIPA_Address");
            database.AddInParameter(storedProcCommand, "@UserTypeID", DbType.Int64, UserTypeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_UpdatedStatus(long CompanyID, string type, long estimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_UpdatedStatus");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@estimateID", DbType.Int64, estimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public static long SelectDBID(long CompanyID, string SystemName)
        {
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@SystemName", SystemName), new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null) };
            SqlParameter[] sqlParameterArray = sqlParameter;
            SQL.ExecuteNonQuery(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"], CommandType.StoredProcedure, "PC_GetDbID", sqlParameterArray);
            return (long)Convert.ToInt32(sqlParameterArray[(int)sqlParameterArray.Length - 1].Value);
        }

        public virtual string SelectForecolor_GetActiveTabForeColor(int CompanyID, string HeaderName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetActiveTabForeColor");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@headerName", DbType.String, HeaderName);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable SelectInUseCampaign(long AccountID, long ManageID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_ManageCampaign_InUse_IsArchive_Campaign");
            database.AddInParameter(storedProcCommand, "@ManageID", DbType.Int64, ManageID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public static string SelectIsConverted(long PriceCatalogueID, long DbID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"]);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectIsConverted");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@DBID", DbType.Int64, DbID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? "" : obj.ToString());
        }

        public static string SelectIsConverted_Croped(long PriceCatalogueID, int DbID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SelectIsConvertedAndCroped");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@DBID", DbType.Int64, DbID);
            object obj = database.ExecuteScalar(storedProcCommand);
            return (obj == null ? "" : obj.ToString());
        }

        public virtual DataTable SelectMangeCampign(long CompanyID, long UserID, long AccountID)
        {
            commonClass _commonClass = new commonClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ManageCampaign_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Set_Horizontal_Group_TOP(int CompanyID, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Set_Horizontal_Group_TOP");
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet Set_TemplateID(long PriceCatalogueID)
        {
            commonClass _commonClass = new commonClass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_TemplateID");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void SetDefault_PaymentTerm(long CompanyID, int PaymentTermID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultPaymentTerm");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentTermID", DbType.Int16, PaymentTermID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void SetDefault_RefferceBy(long CompanyID, int ReferencedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultReferencedBy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ReferencedID", DbType.Int16, ReferencedID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_accountingCode_Delete(int CompanyID, int AccountCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_accountingCode_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Setting_accountingCode_Insert(int CompanyID, string Code, string Description, bool IsDefault, bool IsDefaultPurchase, int AccountCodeID, bool IsRevenueCode, bool IsPurchaseCode)
        {
            int num = 0;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_accountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Code", DbType.String, Code);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.String, IsDefault);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.AddInParameter(storedProcCommand, "@IsdefaultPurchase", DbType.Boolean, IsDefaultPurchase);
            database.AddInParameter(storedProcCommand, "@IsRevenueCode", DbType.Boolean, IsRevenueCode);
            database.AddInParameter(storedProcCommand, "@IsPurchaseCode", DbType.Boolean, IsPurchaseCode);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, num);
            database.ExecuteNonQuery(storedProcCommand);
            return (int)database.GetParameterValue(storedProcCommand, "@ReturnID");
        }

        public virtual DataTable Setting_accountingCode_SelectAll(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_accountingCode_SelectAll");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_accountingCode_SelectAllPurchaseCode(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_accountingCode_SelectAllpurchaseCode");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_accountingCode_SelectAllRevenueCode(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_accountingCode_SelectAllRevenueCode");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Setting_eStoreReports_InsertUpdate(bool IsEnabled, string UserType, int accountId, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_setting_eStoreReports_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@IsEnabled", DbType.Boolean, IsEnabled);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.String, UserType);
            database.AddInParameter(storedProcCommand, "@accountId", DbType.Int32, accountId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Setting_eStoreReports_Select(int accountId, int CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_setting_eStoreReports_Select");
            database.AddInParameter(storedProcCommand, "@accountId", DbType.Int32, accountId);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Setting_Insert_PublicLogoutSettings(long AccountID, long CompanyID, long UserID, string ReDirectURL, bool IsCustomLogout, bool IsForceUSer)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PublicUserLogoutSettings_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@ReDirectURL", DbType.String, ReDirectURL);
            database.AddInParameter(storedProcCommand, "@IsCustomLogout", DbType.Boolean, IsCustomLogout);
            database.AddInParameter(storedProcCommand, "@IsForceUSer", DbType.Boolean, IsForceUSer);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_PublicttrackingSettings(long AccountID, long CompanyID, long UserID, string ReDirectURL, bool IsEnableTracking)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PublicUserTrackingSettings_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@SecretCode", DbType.String, ReDirectURL);
            database.AddInParameter(storedProcCommand, "@IsEnableTracking", DbType.Boolean, IsEnableTracking);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_SpendLimitSettings(long AccountID, long CompanyID, long UserID, bool IsSpendLimit, bool IsPerUser, bool IsPerDept)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SpendLimitSettings_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsSpendLimit", DbType.Boolean, IsSpendLimit);
            database.AddInParameter(storedProcCommand, "@IsPerUser", DbType.Boolean, IsPerUser);
            database.AddInParameter(storedProcCommand, "@IsPerDept", DbType.Boolean, IsPerDept);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_StoreCreditsettings(long AccountID, long CompanyID, long UserID, bool IsStoreCreditsEnabled, bool IsDeleted)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StoreCreditsSettings_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsStoreCreditsEnabled", DbType.Boolean, IsStoreCreditsEnabled);
            database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_ZipToTaxsettings(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted, string ZipUserName, string ZipPassword)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ZipToTaxSettings_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsZip2taxEnabled", DbType.Boolean, IsZip2taxEnabled);
            database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.AddInParameter(storedProcCommand, "@ZipTaxUserName", DbType.String, ZipUserName);
            database.AddInParameter(storedProcCommand, "@ZipTaxPassword", DbType.String, ZipPassword);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_InsertUpdateProofTermsAndConditions(long CompanyID, long ClientID, bool IsTermAndConditions, string TermsAndConditions)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProofTermsAndConditions");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@IsTermAndConditions", DbType.Boolean, IsTermAndConditions);
            database.AddInParameter(storedProcCommand, "@TermsAndConditions", DbType.String, TermsAndConditions);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_InsertUpdateShipEngineErrorMsg(long CompanyID, long ClientID, bool IsTermAndConditions, string ErrorMsg)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertShipEngineErrorMsg");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@IsTermAndConditions", DbType.Boolean, IsTermAndConditions);
            database.AddInParameter(storedProcCommand, "@ErrorMsg", DbType.String, ErrorMsg);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_ZipToTaxsettings_only(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ZipToTaxSettings_Insert_only");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsZip2taxEnabled", DbType.Boolean, IsZip2taxEnabled);
            database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Setting_Insert_Crm_ZipToTaxsettings(long AccountID, long CompanyID, long UserID, bool IsZip2taxEnabled, bool IsDeleted)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ZipToTaxSettings_Crm_Insert");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsZip2taxEnabled", DbType.Boolean, IsZip2taxEnabled);
            database.AddInParameter(storedProcCommand, "@IsDeleted", DbType.Boolean, IsDeleted);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, DateTime.Now);
            database.ExecuteNonQuery(storedProcCommand);
        }


        public void Setting_AllInsertUpdateProofTermsAndConditions(List<ProofTermsAndConditionsData> dataList)
        {
            using (SqlConnection connection = new SqlConnection((new commonClass()).strConnection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("PC_AllInsertProofTermsAndConditions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create and populate DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("CompanyID", typeof(long));
                    dataTable.Columns.Add("ClientID", typeof(long));
                    dataTable.Columns.Add("IsTermsAndConditions", typeof(bool));
                    dataTable.Columns.Add("TermsAndConditions", typeof(string));

                    foreach (var data in dataList)
                    {
                        dataTable.Rows.Add(data.CompanyID, data.ClientID, data.IsTermsAndConditions, data.TermsAndConditions);
                    }

                    // Add TVP parameter
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Data", dataTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.ProofTermsAndConditionsType"; // Replace with your actual TVP type name
                    command.Parameters.AddWithValue("@CompanyID", dataList[0].CompanyID);
                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Setting_AllInsertUpdateShipEngineErrorData(List<ShipEngineErrorData> dataList)
        {
            using (SqlConnection connection = new SqlConnection((new commonClass()).strConnection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("PC_AllInsertShipEngineError", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create and populate DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("CompanyID", typeof(long));
                    dataTable.Columns.Add("ClientID", typeof(long));
                    dataTable.Columns.Add("IsTermsAndConditions", typeof(bool));
                    dataTable.Columns.Add("ErrorMsg", typeof(string));

                    foreach (var data in dataList)
                    {
                        dataTable.Rows.Add(data.CompanyID, data.ClientID, data.IsTermsAndConditions, data.ErrorMsg);
                    }

                    // Add TVP parameter
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@Data", dataTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.ShipEngineError"; // Replace with your actual TVP type name
                    command.Parameters.AddWithValue("@CompanyID", dataList[0].CompanyID);
                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual void Setting_InsertUpdate_ProofTermsAndCondition(long CompanyID, long ClientID, bool IsTermAndConditions)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StoreCreditsSettings_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@IsTermAndConditions", DbType.Boolean, IsTermAndConditions);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void Setting_JobCardSettings_Insert(int CompanyID, string SectionName, string Description, bool IsChecked, string EstimateType, string ItemType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_JobCardSettings_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, SectionName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            if (!IsChecked)
            {
                database.AddInParameter(storedProcCommand, "@IsChecked", DbType.Boolean, 0);
            }
            else
            {
                database.AddInParameter(storedProcCommand, "@IsChecked", DbType.Boolean, 1);
            }
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Setting_JobCardSettings_SelectAll(int CompanyID, string Estimatetype, string ItemtType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_JobCardSettings_SelectAll");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@estimateType", DbType.String, Estimatetype);
            database.AddInParameter(storedProcCommand, "@itemType", DbType.String, ItemtType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_JobCardSettings_SelectAll_levelZero(string Estimatetype, string ItemType)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_JobCardSettings_SelectAll_levelZero");
            database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, Estimatetype);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_jobcardtags_Select(string estimatetype)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_Setting_jobcardtags_Select");
            database.AddInParameter(storedProcCommand, "@estimateType", DbType.String, estimatetype);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_PublicLogoutSettings_Select(long AccountID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PublicSettings_Select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Setting_ReferencedBy_InsertUpdate(int ReferencedID, int CompanyID, string Name, string CommissionValue, bool InUse, bool IsDefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Setting_ReferencedBy_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@ReferencedID", DbType.Int32, ReferencedID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, Name);
            database.AddInParameter(storedProcCommand, "@CommissionValue", DbType.String, CommissionValue);
            database.AddInParameter(storedProcCommand, "@InUse", DbType.String, InUse);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Setting_SpendLimit_Select(long AccountID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SpendLimitSettings_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_StoreCredit_Select(long AccountID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StoreCreditsSettings_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Setting_ProofTermsAndCondition_Select(long ClientID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofTermsAndCondition_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_ShipEngineError_Select(long ClientID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ShipEngineError_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable Setting_GetProofTermsSelectedCustomer(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofTerms_SelectedCustomer");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_GetShipEngineErrorSelectedCustomer(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetShipEngineError_SelectedCustomer");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Setting_ZiptoTax_Select(long AccountID, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
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

        public virtual void Setting_UpdateHidePrice(long AccountID, bool IsHidePrice)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateHidePrice");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@IsHidePrice", DbType.Boolean, IsHidePrice);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable setting_user_edit(int companyID, int userid, TextBox txtname, TextBox txtemail, TextBox txtpassword, TextBox txtconfirmpassword, DropDownList ddlrole, TextBox txtdesription, CheckBox chkdisable, TextBox txtPhone, TextBox txtMobile, TextBox txtFax)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_user_select_edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable setting_user_profile(int companyID, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_user_select_edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, this.companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_accountstatus_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_accountstatus_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.String, item.StatusID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_accountstatus_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_accountstatus_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, item.StatusTitle);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.String, item.IsDefaultStatus);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_accountstatus_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_accountstatus_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_accountstatus_setDefalut(int CompanyID, int StatusID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ISDefaultAccountStatus_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.String, StatusID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_AccountStatus_SetDefault(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultAccountStatus_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_accountstatus_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_accountstatus_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, item.StatusID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, item.StatusTitle);
            database.AddInParameter(storedProcCommand, "@ISDefault", DbType.Boolean, item.IsDefaultStatus);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_check_userid_exist(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_check_userid_exist");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual long Settings_ClickChargeLookup_Insert(int CompanyID, decimal BlackChargeableSheets, decimal ColorChargeableSheets, decimal ChargeableSheets, long ClickChargeLookupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_clickchargeLookup_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@BlackChargeableSheets", DbType.Decimal, BlackChargeableSheets);
            database.AddInParameter(storedProcCommand, "@ColorChargeableSheets", DbType.Decimal, ColorChargeableSheets);
            database.AddInParameter(storedProcCommand, "@ChargeableSheets", DbType.Decimal, ChargeableSheets);
            database.AddInParameter(storedProcCommand, "@ClickChargeLookupID", DbType.Int64, ClickChargeLookupID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Settings_ClickChargeLookup_Select_By_ID(int CompanyID, long ClickChargeLookupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_clickchargelookup_select_by_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClickChargeLookupID", DbType.Int64, ClickChargeLookupID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Settings_ClickChargeZoneLookup_Insert(int CompanyID, long DigitalPressID, int ZoneFrom, int ZoneTo, int ChargeableSheets, decimal Cost, decimal ChargeableRate, string ZoneType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_clickchargezonelookup_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            database.AddInParameter(storedProcCommand, "@ZoneFrom", DbType.Int32, ZoneFrom);
            database.AddInParameter(storedProcCommand, "@ZoneTo", DbType.Int32, ZoneTo);
            database.AddInParameter(storedProcCommand, "@ChargeableSheets", DbType.Int32, ChargeableSheets);
            database.AddInParameter(storedProcCommand, "@Cost", DbType.Decimal, Cost);
            database.AddInParameter(storedProcCommand, "@ChargeableRate", DbType.Decimal, ChargeableRate);
            database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_LargeFormatChargeZone_Insert(string ZoneType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_LargeFormatChargeZone_insert");
            
            database.AddInParameter(storedProcCommand, "@ZoneType", DbType.String, ZoneType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Settings_ClickChargeZoneLookup_Select_By_ID(int CompanyID, long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_clickchargezonelookup_select_by_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Settings_LargeFormatChargeZone_Select_By_ID( long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_LargeFormatChargeZone_select_by_ID");
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, DigitalPressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string settings_companyweight_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_companyweight_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual DataTable settings_companyprofile_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_companyprofile_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable shipengine_sent_settings_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_shipengine_sent_settings_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void UpdateJobDeliveryDate(long jobId, DateTime deliveryDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdateDeliveryDate");
                database.AddInParameter(storedProcCommand, "@JobId", DbType.Int32, jobId);
                database.AddInParameter(storedProcCommand, "@deliveryDate", DbType.DateTime, deliveryDate);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }

        public virtual void UpdateJobProofDate(long jobId, DateTime proofDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdateProofDate");
                database.AddInParameter(storedProcCommand, "@JobId", DbType.Int32, jobId);
                database.AddInParameter(storedProcCommand, "@proofDate", DbType.DateTime, proofDate);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }
        public virtual void UpdateJobEstimatedDeliveryDate(long jobId,long estimateItemID, DateTime deliveryDate,string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdateEstimatedDeliveryDate");
                database.AddInParameter(storedProcCommand, "@JobId", DbType.Int32, jobId);
                database.AddInParameter(storedProcCommand, "@estimateItemId", DbType.Int32, estimateItemID);
                database.AddInParameter(storedProcCommand, "@deliveryDate", DbType.DateTime, deliveryDate);
                database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }
        public virtual void UpdateJobDates(long companyID, long jobID, long estimateItemID, DateTime date, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdateJobDates");
                database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, companyID);
                database.AddInParameter(storedProcCommand, "@jobID", DbType.Int64, jobID);
                database.AddInParameter(storedProcCommand, "@estimateItemId", DbType.Int32, estimateItemID);
                database.AddInParameter(storedProcCommand, "@date", DbType.DateTime, date);
                database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }
        public virtual void UpdateSalesPerson(long jobId, long salesPersonId,string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdateSalesPerson");
                database.AddInParameter(storedProcCommand, "@jobId", DbType.Int32, jobId);
                database.AddInParameter(storedProcCommand, "@salesPersonId", DbType.Int32, salesPersonId);
                database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }

        public virtual void Updatepriority(long estid, string priority,string page)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            {
                DataTable dataTable = new DataTable();
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UpdatePriority");
                database.AddInParameter(storedProcCommand, "@id", DbType.Int32, estid);
                database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
                database.AddInParameter(storedProcCommand, "@page", DbType.String, page);

                database.ExecuteNonQuery(storedProcCommand);
            }
        }

        public virtual void settings_companyprofile_update(int CompanyID, string CompanyName, string AddressLine1, string AddressLine2, string AddressLine3, string PostalCode, string Country, string Telephone, string Fax, string URL, string CompanyNumber, string TaxNumber, int CountryID, string MarketingEmail, DateTime fiscalfromtxt, DateTime fiscaltotxt, string CurrencyCountryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_companyprofile_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@AddressLine1", DbType.String, AddressLine1);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
            database.AddInParameter(storedProcCommand, "@AddressLine3", DbType.String, AddressLine3);
            database.AddInParameter(storedProcCommand, "@PostalCode", DbType.String, PostalCode);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, URL);
            database.AddInParameter(storedProcCommand, "@CompanyNumber", DbType.String, CompanyNumber);
            database.AddInParameter(storedProcCommand, "@TaxNumber", DbType.String, TaxNumber);
            database.AddInParameter(storedProcCommand, "@FiscalFrom", DbType.DateTime, fiscalfromtxt);
            database.AddInParameter(storedProcCommand, "@FisCalTo", DbType.DateTime, fiscaltotxt);
            database.AddInParameter(storedProcCommand, "@CountryID", DbType.Int32, CountryID);
            database.AddInParameter(storedProcCommand, "@MarketingEmail", DbType.String, MarketingEmail);
            database.AddInParameter(storedProcCommand, "@CurrencyCountryID", DbType.String, CurrencyCountryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void shipengine_sent_settings_update(int CompanyID, string AddressLine1, string AddressLine2, string City, string State, string PostalCode, string Country, string MaxWeight, int CountryID, string Weight)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_shipengine_sent_settings_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AddressLine1", DbType.String, AddressLine1);
            database.AddInParameter(storedProcCommand, "@AddressLine2", DbType.String, AddressLine2);
            database.AddInParameter(storedProcCommand, "@City", DbType.String, City);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
            database.AddInParameter(storedProcCommand, "@PostalCode", DbType.String, PostalCode);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@MaxWeight", DbType.String, MaxWeight);
            database.AddInParameter(storedProcCommand, "@CountryID", DbType.Int32, CountryID);
            database.AddInParameter(storedProcCommand, "@Weight", DbType.String, Weight);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_CompanyType_ddlselect(int Id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[pc_settings_companyType_ddlSelect]");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int32, Id);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void settings_CompanyType_deleterow(int id, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_CompanyType_deleterow");
            database.AddInParameter(storedProcCommand, "@id", DbType.Int32, id);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_CompanyType_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_companyType_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_CompanyType_select_ForClient(int CompanyID, string Companytype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[pc_settings_companyType_Select_ForClient]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Companytype", DbType.String, Companytype);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void settings_copmanyType_insert(int id, int CompanyID, string CompanyType, int UserID, string UsedIn, DateTime datetime)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_copmanyType_insert");
            database.AddInParameter(storedProcCommand, "@id", DbType.Int32, id);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@copmanytype", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@createdBy", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@UsedFor", DbType.String, UsedIn);
            database.AddInParameter(storedProcCommand, "@createdOn", DbType.DateTime, DateTime.Now);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_CopyWidget_delete(int CopyMasterID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_CopyWidget_delete");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int32, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_costformulabased_delete(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costformulabased_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long settings_costformulabased_insert(int CompanyID, long CostFormulaBasedID, long OtherCostID, string FormulaType, string Formula, string FormulaTag)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costformulabased_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CostFormulaBasedID", DbType.Int64, CostFormulaBasedID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@FormulaType", DbType.String, FormulaType);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FormulaTag", DbType.String, FormulaTag);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_costformulabased_select(int CompanyID, long CostFormulaBasedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costformulabased_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CostFormulaBasedID", DbType.Int64, CostFormulaBasedID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_costformulatag_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costformulatag_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long settings_costquantitybased_insert(int CompanyID, long OtherCostID, long CostQuantityBasedID, decimal HourlyRate, decimal MakeReadyTime, decimal TimePerUnit, decimal DefaultUnitCost, string DefaultQtyType, decimal FixedQty, string VariableQty, bool IsMatrix)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costquantitybased_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@CostQuantityBasedID", DbType.Int64, CostQuantityBasedID);
            database.AddInParameter(storedProcCommand, "@HourlyRate", DbType.Decimal, HourlyRate);
            database.AddInParameter(storedProcCommand, "@MakeReadyTime", DbType.Decimal, MakeReadyTime);
            database.AddInParameter(storedProcCommand, "@TimePerUnit", DbType.Decimal, TimePerUnit);
            database.AddInParameter(storedProcCommand, "@DefaultUnitCost", DbType.Decimal, DefaultUnitCost);
            database.AddInParameter(storedProcCommand, "@DefaultQtyType", DbType.String, DefaultQtyType);
            database.AddInParameter(storedProcCommand, "@FixedQty", DbType.Decimal, FixedQty);
            database.AddInParameter(storedProcCommand, "@VariableQty", DbType.String, VariableQty);
            database.AddInParameter(storedProcCommand, "@IsMatrix", DbType.Boolean, IsMatrix);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_costquantitybased_select(int CompanyID, long CostQuantityBasedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costquantitybased_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CostQuantityBasedID", DbType.Int64, CostQuantityBasedID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long settings_costtimebased_insert(int CompanyID, long OtherCostID, long CostTimeBasedID, decimal HourlyRate, decimal MakeReadyTime, decimal HourlyRunSpeed, string DefaultHourType, decimal FixedHours, string VariableHours, string timebasetype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costtimebased_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@CostTimeBasedID", DbType.Int64, CostTimeBasedID);
            database.AddInParameter(storedProcCommand, "@HourlyRate", DbType.Decimal, HourlyRate);
            database.AddInParameter(storedProcCommand, "@MakeReadyTime", DbType.Decimal, MakeReadyTime);
            database.AddInParameter(storedProcCommand, "@HourlyRunSpeed", DbType.Decimal, HourlyRunSpeed);
            database.AddInParameter(storedProcCommand, "@DefaultHourType", DbType.String, DefaultHourType);
            database.AddInParameter(storedProcCommand, "@FixedHours", DbType.Decimal, FixedHours);
            database.AddInParameter(storedProcCommand, "@VariableHours", DbType.String, VariableHours);
            database.AddInParameter(storedProcCommand, "@TimeBasedType", DbType.String, timebasetype);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_costtimebased_select(int CompanyID, long CostTimeBasedID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costtimebased_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CostTimeBasedID", DbType.Int64, CostTimeBasedID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_costtimebased_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_costtimebased_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Settings_dashbaord_AllStatus(int CompanyID, string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_dashbaord_AllStatus");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_default_phrasebook_forestimate_select(int CompanyID, string PhraseType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_phrasebook_forestimate_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
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
                row["PhraseType"] = base.SpecialDecode(row["PhraseType"].ToString());
                row["PhraseText"] = base.SpecialDecode(row["PhraseText"].ToString());
            }
            return dataTable;
        }

        public virtual DataSet settings_default_phrasebook_of_outwork_header_foooter(int CompanyID, string PhraseType)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_phrasebook_of_outwork_header_foooter");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable settings_default_phrasebook_select(int CompanyID, string PhraseType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_phrasebook_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet settings_default_phrasebook_select_header_footer(int CompanyID, string PhraseType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_phrasebook_select_header_footer");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable settings_default_template_group_select(int COmpanyID, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_template_group_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, COmpanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_default_template_select(int CompanyID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_template_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void settings_default_template_update(int CompanyID, int TemplateID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_template_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataSet settings_digital_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_digital_press_PageText", sqlConnection);
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

        public virtual void settings_digital_press_SetDefault(int CompanyID, int DigitalPressId)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_digital_press_SetDefault", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@DigitalPressID", DigitalPressId);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
        }

        public virtual void settings_digitalpress_delete(int CompanyID, long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_digitalpress_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Settings_DigitalPress_Insert(int CompanyID, string DigitalPressName, string Description, decimal MaxImgHeight, decimal MaxImgWidth, decimal MaxSheetWeight, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, decimal SpoilageSheets, decimal RunningSpoilage, long PaperID, int PrintSheetID, int JobSizeID, long GuillotineID, decimal SetupCharge, decimal MinCharge, decimal MarkUp, string MethodName, long MethodID, bool IsBlackFlatternClick, bool IsBlackSumClick, bool IsColorFlatternClick, bool IsColorSumClick, long DigitalPressID, bool IsDefaultPress, bool CalculationType, int UnitOfMeasure)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_digital_press_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressName", DbType.String, DigitalPressName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MaxImgHeight", DbType.Decimal, MaxImgHeight);
            database.AddInParameter(storedProcCommand, "@MaxImgWidth", DbType.Decimal, MaxImgWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetWeight", DbType.Decimal, MaxSheetWeight);
            database.AddInParameter(storedProcCommand, "@PrintImageHeight", DbType.Decimal, PrintImageHeight);
            database.AddInParameter(storedProcCommand, "@PrintImageWidth", DbType.Decimal, PrintImageWidth);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
            database.AddInParameter(storedProcCommand, "@SpoilageSheets", DbType.Decimal, SpoilageSheets);
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
            database.AddInParameter(storedProcCommand, "@PrintSheetID", DbType.Int32, PrintSheetID);
            database.AddInParameter(storedProcCommand, "@JobSizeID", DbType.Int32, JobSizeID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.AddInParameter(storedProcCommand, "@SetupCharge", DbType.Decimal, SetupCharge);
            database.AddInParameter(storedProcCommand, "@MinCharge", DbType.Decimal, MinCharge);
            database.AddInParameter(storedProcCommand, "@MarkUp", DbType.Decimal, MarkUp);
            database.AddInParameter(storedProcCommand, "@MethodName", DbType.String, MethodName);
            database.AddInParameter(storedProcCommand, "@MethodID", DbType.Int64, MethodID);
            database.AddInParameter(storedProcCommand, "@IsBlackFlatternClick", DbType.Boolean, IsBlackFlatternClick);
            database.AddInParameter(storedProcCommand, "@IsBlackSumClick", DbType.Boolean, IsBlackSumClick);
            database.AddInParameter(storedProcCommand, "@IsColorFlatternClick", DbType.Boolean, IsColorFlatternClick);
            database.AddInParameter(storedProcCommand, "@IsColorSumClick", DbType.Boolean, IsColorSumClick);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            database.AddInParameter(storedProcCommand, "@IsDefaultPress", DbType.Boolean, IsDefaultPress);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.Boolean, CalculationType);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Settings_DigitalPress_Select_All(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_digital_press_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Settings_DigitalPress_Select_By_ID(int CompanyID, long DigitalPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_digital_press_select_By_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DigitalPressID", DbType.Int64, DigitalPressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_EmailBody_Copy(int CompanyID, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_EmailBody_Copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int32, EmailID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_EmailSetting_Email_Eprint(int CompanyID, int EmailSettingID, string EmailSettingType, string Bcc, string Cc, int UserID, bool IsSuplierRFQ_AttachAll, bool IsPurchase_AttachAll, bool IsCheckedCC, bool IsCheckedBCC, bool SupplierAttachLink, bool PurchaseAttachLink, bool AttachDeliveryNote, bool AttacheStoreFile)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_EmailSetting_Email_Eprint");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EmailSettingID", DbType.Int32, EmailSettingID);
            database.AddInParameter(storedProcCommand, "@EmailSettingType", DbType.String, EmailSettingType);
            database.AddInParameter(storedProcCommand, "@Bcc", DbType.String, Bcc);
            database.AddInParameter(storedProcCommand, "@Cc", DbType.String, Cc);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@IsSuplierRFQ_AttachAll", DbType.Boolean, IsSuplierRFQ_AttachAll);
            database.AddInParameter(storedProcCommand, "@IsPurchase_AttachAll", DbType.Boolean, IsPurchase_AttachAll);
            database.AddInParameter(storedProcCommand, "@IsCheckedCC", DbType.Boolean, IsCheckedCC);
            database.AddInParameter(storedProcCommand, "@IsCheckedBCC", DbType.Boolean, IsCheckedBCC);
            database.AddInParameter(storedProcCommand, "@Supplier_AttachLink", DbType.Boolean, SupplierAttachLink);
            database.AddInParameter(storedProcCommand, "@Purchase_AttachLink", DbType.Boolean, PurchaseAttachLink);
            database.AddInParameter(storedProcCommand, "@DeliveryNote_AttachLink", DbType.Boolean, AttachDeliveryNote);
            database.AddInParameter(storedProcCommand, "@Is_eStoreAttachment", DbType.Boolean, AttacheStoreFile);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_emailsetting_insert(int CompanyID, int EmailSettingID, string EmailSettingType, string Bcc, string Cc, int UserID, bool Checked_OtherCC, bool Checked_OtherBCC)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_emailsetting_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EmailSettingID", DbType.Int32, EmailSettingID);
            database.AddInParameter(storedProcCommand, "@EmailSettingType", DbType.String, EmailSettingType);
            database.AddInParameter(storedProcCommand, "@Bcc", DbType.String, Bcc);
            database.AddInParameter(storedProcCommand, "@Cc", DbType.String, Cc);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@IsCheckedCC", DbType.Boolean, Checked_OtherCC);
            database.AddInParameter(storedProcCommand, "@IsCheckedBCC", DbType.Boolean, Checked_OtherBCC);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_emailsetting_select(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_emailsetting_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_estimatestatus_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.String, item.StatusID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_DeliveryCost_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_DeliveryCost_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.String, item.DeliveryCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_MIS_DeliveryCost_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_MIS_DeliveryCost_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.String, item.DeliveryCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_estimatestatus_delete_check_all_module(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_delete_check_all_module");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.String, item.StatusID);
            database.AddInParameter(storedProcCommand, "@Statusname", DbType.String, item.StatusTitle);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_estimatestatus_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, item.StatusTitle);
            database.AddInParameter(storedProcCommand, "@isdefault", DbType.Int32, item.isdefault);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_estimatestatus_insert_new(int CompanyID, string StatusTitle, int estimate, int job, int invoice, int purchase, int delivery, int orders, int estimateDefault, int jobDefault, int invoiceDefault, int purchaseDefault, int deliveryDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability,string colorcode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_insert_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, StatusTitle);
            database.AddInParameter(storedProcCommand, "@Estimate", DbType.Int32, estimate);
            database.AddInParameter(storedProcCommand, "@Job", DbType.Int32, job);
            database.AddInParameter(storedProcCommand, "@Invoice", DbType.Int32, invoice);
            database.AddInParameter(storedProcCommand, "@Purchase", DbType.Int32, purchase);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.Int32, delivery);
            database.AddInParameter(storedProcCommand, "@orders", DbType.Int32, orders);
            database.AddInParameter(storedProcCommand, "@EstimateDefault", DbType.Int32, estimateDefault);
            database.AddInParameter(storedProcCommand, "@JobDefault", DbType.Int32, jobDefault);
            database.AddInParameter(storedProcCommand, "@InvoiceDefault", DbType.Int32, invoiceDefault);
            database.AddInParameter(storedProcCommand, "@PurchaseDefault", DbType.Int32, purchaseDefault);
            database.AddInParameter(storedProcCommand, "@DeliveryDefault", DbType.Int32, deliveryDefault);
            database.AddInParameter(storedProcCommand, "@ordersDefault", DbType.Int32, ordersDefault);
            database.AddInParameter(storedProcCommand, "@isdefault", DbType.Int32, isdefault);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@Probability", DbType.Int32, Probability);
            database.AddInParameter(storedProcCommand, "@StatusColorCode", DbType.String, colorcode);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_DeliveryCost_insert_new(int CompanyID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_DeliveryCost_insert_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostTitle", DbType.String, DeliveryCostTitle);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FromShipEngine", DbType.Boolean, FromShipEngine);
            database.AddInParameter(storedProcCommand, "@FromOtherStore", DbType.Boolean, FromOtherStore);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_MIS_DeliveryCost_insert_new(int CompanyID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_MIS_DeliveryCost_insert_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostTitle", DbType.String, DeliveryCostTitle);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FromShipEngine", DbType.Boolean, FromShipEngine);
            database.AddInParameter(storedProcCommand, "@FromOtherStore", DbType.Boolean, FromOtherStore);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }
        public virtual int settings_estimatestatus_insert_new_proof(int CompanyID, string StatusTitle, int estimate, int job, int invoice, int purchase, int delivery,int proof, int orders, int estimateDefault, int jobDefault, int invoiceDefault, int purchaseDefault, int deliveryDefault,int proofDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability, string code)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_insert_new_proof");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, StatusTitle);
            database.AddInParameter(storedProcCommand, "@Estimate", DbType.Int32, estimate);
            database.AddInParameter(storedProcCommand, "@Job", DbType.Int32, job);
            database.AddInParameter(storedProcCommand, "@Invoice", DbType.Int32, invoice);
            database.AddInParameter(storedProcCommand, "@Purchase", DbType.Int32, purchase);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.Int32, delivery);
            database.AddInParameter(storedProcCommand, "@Proof", DbType.Int32, proof);
            database.AddInParameter(storedProcCommand, "@orders", DbType.Int32, orders);
            database.AddInParameter(storedProcCommand, "@EstimateDefault", DbType.Int32, estimateDefault);
            database.AddInParameter(storedProcCommand, "@JobDefault", DbType.Int32, jobDefault);
            database.AddInParameter(storedProcCommand, "@InvoiceDefault", DbType.Int32, invoiceDefault);
            database.AddInParameter(storedProcCommand, "@PurchaseDefault", DbType.Int32, purchaseDefault);
            database.AddInParameter(storedProcCommand, "@DeliveryDefault", DbType.Int32, deliveryDefault);
            database.AddInParameter(storedProcCommand, "@ProofDefault", DbType.Int32, proofDefault);
            database.AddInParameter(storedProcCommand, "@ordersDefault", DbType.Int32, ordersDefault);
            database.AddInParameter(storedProcCommand, "@isdefault", DbType.Int32, isdefault);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@Probability", DbType.Int32, Probability);
            database.AddInParameter(storedProcCommand, "@StatusColorCode", DbType.String, code);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_estimatestatus_moduletype_select(int CompanyID, string cond)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_moduletype_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@cond", DbType.String, cond);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_estimatestatus_moduletype_select_new(int CompanyID, string cond)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_moduletype_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@cond", DbType.String, cond);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_estimatestatus_order_number_update(int CompanyID, int StatusID, int OrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_order_number_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.Int32, OrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_estimatestatus_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_estimatestatus_select_new(int CompanyID, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string settings_estimatestatus_sortalpha_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_sortalpha_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void settings_estimatestatus_sortalpha_update(int CompanyID, int StatusID, string cond)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_sortalpha_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@cond", DbType.String, cond);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_estimatestatus_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, item.StatusID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, item.StatusTitle);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_estimatestatus_update_new(int CompanyID, int StatusID, string StatusTitle, int Estimate, int Job, int Invoice, int Purchase, int Delivery, int orders, int EstimateDefault, int JobDefault, int InvoiceDefault, int PurchaseDefault, int DeliveryDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability,string code)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_update_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, StatusTitle);
            database.AddInParameter(storedProcCommand, "@Estimate", DbType.Int32, Estimate);
            database.AddInParameter(storedProcCommand, "@Job", DbType.Int32, Job);
            database.AddInParameter(storedProcCommand, "@Invoice", DbType.Int32, Invoice);
            database.AddInParameter(storedProcCommand, "@Purchase", DbType.Int32, Purchase);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.Int32, Delivery);
            database.AddInParameter(storedProcCommand, "@orders", DbType.Int32, orders);
            database.AddInParameter(storedProcCommand, "@EstimateDefault", DbType.Int32, EstimateDefault);
            database.AddInParameter(storedProcCommand, "@JobDefault", DbType.Int32, JobDefault);
            database.AddInParameter(storedProcCommand, "@InvoiceDefault", DbType.Int32, InvoiceDefault);
            database.AddInParameter(storedProcCommand, "@PurchaseDefault", DbType.Int32, PurchaseDefault);
            database.AddInParameter(storedProcCommand, "@DeliveryDefault", DbType.Int32, DeliveryDefault);
            database.AddInParameter(storedProcCommand, "@ordersDefault", DbType.Int32, ordersDefault);
            database.AddInParameter(storedProcCommand, "@isdefault", DbType.Int32, isdefault);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@Probability", DbType.Int32, Probability);
            //database.AddInParameter(storedProcCommand, "@StatusColor", DbType.String, color);
            database.AddInParameter(storedProcCommand, "@StatusColorCode", DbType.String, code);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_DeliveryCost_update_new(int CompanyID, int DeliveryCostID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_DeliveryCost_Update_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.Int32, DeliveryCostID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostTitle", DbType.String, DeliveryCostTitle);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FromShipEngine", DbType.Boolean, FromShipEngine);
            database.AddInParameter(storedProcCommand, "@FromOtherStore", DbType.Boolean, FromOtherStore);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_MIS_DeliveryCost_update_new(int CompanyID, int DeliveryCostID, string DeliveryCostTitle, string Type, string Formula, bool FromShipEngine, bool FromOtherStore, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_MIS_DeliveryCost_Update_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostID", DbType.Int32, DeliveryCostID);
            database.AddInParameter(storedProcCommand, "@DeliveryCostTitle", DbType.String, DeliveryCostTitle);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@FromShipEngine", DbType.Boolean, FromShipEngine);
            database.AddInParameter(storedProcCommand, "@FromOtherStore", DbType.Boolean, FromOtherStore);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }
        public virtual int settings_estimatestatus_update_new_proof(int CompanyID, int StatusID, string StatusTitle, int Estimate, int Job, int Invoice, int Purchase, int Delivery,int Proof, int orders, int EstimateDefault, int JobDefault, int InvoiceDefault, int PurchaseDefault, int DeliveryDefault,int ProofDefault, int ordersDefault, int isdefault, string UserFriendlyName, int Probability, string code)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_estimatestatus_update_new_proof");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, StatusTitle);
            database.AddInParameter(storedProcCommand, "@Estimate", DbType.Int32, Estimate);
            database.AddInParameter(storedProcCommand, "@Job", DbType.Int32, Job);
            database.AddInParameter(storedProcCommand, "@Invoice", DbType.Int32, Invoice);
            database.AddInParameter(storedProcCommand, "@Purchase", DbType.Int32, Purchase);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.Int32, Delivery);
            database.AddInParameter(storedProcCommand, "@Proof", DbType.Int32, Proof);
            database.AddInParameter(storedProcCommand, "@orders", DbType.Int32, orders);
            database.AddInParameter(storedProcCommand, "@EstimateDefault", DbType.Int32, EstimateDefault);
            database.AddInParameter(storedProcCommand, "@JobDefault", DbType.Int32, JobDefault);
            database.AddInParameter(storedProcCommand, "@InvoiceDefault", DbType.Int32, InvoiceDefault);
            database.AddInParameter(storedProcCommand, "@PurchaseDefault", DbType.Int32, PurchaseDefault);
            database.AddInParameter(storedProcCommand, "@DeliveryDefault", DbType.Int32, DeliveryDefault);
            database.AddInParameter(storedProcCommand, "@ProofDefault", DbType.Int32, ProofDefault);
            database.AddInParameter(storedProcCommand, "@ordersDefault", DbType.Int32, ordersDefault);
            database.AddInParameter(storedProcCommand, "@isdefault", DbType.Int32, isdefault);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@Probability", DbType.Int32, Probability);
            database.AddInParameter(storedProcCommand, "@StatusColorCode", DbType.String, code);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_eStore_Orders(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_eStore_Orders");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_Delivery_Costs(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Delivery_Costs");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherStore_Delivery_Costs(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherStore_Delivery_Costs");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_MIS_Delivery_Costs(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_MIS_Delivery_Costs");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_MIS_Delivery_Cost_Selector(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_MIS_Delivery_Cost_Selector");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Settings_fromemail_get(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_fromemail_get");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void Settings_fromemail_save(int CompanyID, string FromEmail)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_fromemail_save");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@FromEmail", DbType.String, FromEmail);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string settings_getDateondateformat(int CompanyID, string Date, string DateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_getDateondateformat");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Date", DbType.String, Date);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Settings_Guillotine_Delete(int CompanyID, long GuillotineID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_guillotine_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int Settings_Guillotine_Insert(int CompanyID, string GuillotineName, string Description, decimal MinSheetHeight, decimal MinSheetWidth, decimal MaxSheetHeight, decimal MaxSheetWidth, decimal MaxSheetWeight, decimal SetUpCharge, decimal CostPerCut, decimal MinCharge, decimal MarkUp, decimal PaperWeight1, decimal MaxSheets1, decimal PaperWeight2, decimal MaxSheets2, decimal PaperWeight3, decimal MaxSheets3, long GuillotineID, bool DefaultFirstTrim, bool DefaultSecondTrim, bool IsLarge, int JobCut,string GuillotineType, string CalculationType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_guillotine_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineName", DbType.String, GuillotineName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MinSheetHeight", DbType.Decimal, MinSheetHeight);
            database.AddInParameter(storedProcCommand, "@MinSheetWidth", DbType.Decimal, MinSheetWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetHeight", DbType.Decimal, MaxSheetHeight);
            database.AddInParameter(storedProcCommand, "@MaxSheetWidth", DbType.Decimal, MaxSheetWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetWeight", DbType.Decimal, MaxSheetWeight);
            database.AddInParameter(storedProcCommand, "@SetUpCharge", DbType.Decimal, SetUpCharge);
            database.AddInParameter(storedProcCommand, "@CostPerCut", DbType.Decimal, CostPerCut);
            database.AddInParameter(storedProcCommand, "@MinCharge", DbType.Decimal, MinCharge);
            database.AddInParameter(storedProcCommand, "@MarkUp", DbType.Decimal, MarkUp);
            database.AddInParameter(storedProcCommand, "@PaperWeight1", DbType.Decimal, PaperWeight1);
            database.AddInParameter(storedProcCommand, "@MaxSheets1", DbType.Decimal, MaxSheets1);
            database.AddInParameter(storedProcCommand, "@PaperWeight2", DbType.Decimal, PaperWeight2);
            database.AddInParameter(storedProcCommand, "@MaxSheets2", DbType.Decimal, MaxSheets2);
            database.AddInParameter(storedProcCommand, "@PaperWeight3", DbType.Decimal, PaperWeight3);
            database.AddInParameter(storedProcCommand, "@MaxSheets3", DbType.Decimal, MaxSheets3);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.AddInParameter(storedProcCommand, "@DefaultFirstTrim", DbType.Boolean, DefaultFirstTrim);
            database.AddInParameter(storedProcCommand, "@DefaultSecondTrim", DbType.Boolean, DefaultSecondTrim);
            database.AddInParameter(storedProcCommand, "@IsLarge", DbType.Boolean, IsLarge);
            database.AddInParameter(storedProcCommand, "@JobCut", DbType.Int32, JobCut);
            database.AddInParameter(storedProcCommand, "@GuillotineType", DbType.String, GuillotineType);
            //database.AddInParameter(storedProcCommand, "@PaperCaliper1", DbType.Decimal, PaperCaliper1);
            //database.AddInParameter(storedProcCommand, "@PaperCaliper2", DbType.Decimal, PaperCaliper2);
            //database.AddInParameter(storedProcCommand, "@PaperCaliper3", DbType.Decimal, PaperCaliper3);
            //database.AddInParameter(storedProcCommand, "@MaxSheetsCaliper1", DbType.Decimal, MaxSheetsCaliper1);
            //database.AddInParameter(storedProcCommand, "@MaxSheetsCaliper2", DbType.Decimal, MaxSheetsCaliper2);
            //database.AddInParameter(storedProcCommand, "@MaxSheetsCaliper3", DbType.Decimal, MaxSheetsCaliper3);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataSet settings_guillotine_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string IsForLarge)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_guillotine_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@IsForLarge", IsForLarge);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        internal DataTable Settings_Guillotine_PageText_New(int CompanyID, string IsLarge)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_guillotine_PageText_new", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@IsForLarge", IsLarge);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public virtual DataTable Settings_Guillotine_Select_All(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_guillotine_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Settings_Guillotine_Select_By_ID(int CompanyID, long GuillotineID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_guillotine_select_by_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Settings_Insert_Alert_Setting(long CompanyID, long UserID, bool isShowTaskAlertonScreen, int ShowTaskAlertOnScreenTime, bool isShowCallAlertOnScreen, int ShowCallAlertOnScreenTime, bool isSendTaskAlert, int SendTaskAlertTime, bool isSendCallAlert, int SendCallAlertTime, int CreatedBy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_Alert_Setting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@isShowTaskAlertonScreen", DbType.Boolean, isShowTaskAlertonScreen);
            database.AddInParameter(storedProcCommand, "@ShowTaskAlertOnScreenTime", DbType.Int32, ShowTaskAlertOnScreenTime);
            database.AddInParameter(storedProcCommand, "@isShowCallAlertOnScreen", DbType.Boolean, isShowCallAlertOnScreen);
            database.AddInParameter(storedProcCommand, "@ShowCallAlertOnScreenTime", DbType.Int32, ShowCallAlertOnScreenTime);
            database.AddInParameter(storedProcCommand, "@isSendTaskAlert", DbType.Boolean, isSendTaskAlert);
            database.AddInParameter(storedProcCommand, "@SendTaskAlertTime", DbType.Int32, SendTaskAlertTime);
            database.AddInParameter(storedProcCommand, "@isSendCallAlert", DbType.Boolean, isSendCallAlert);
            database.AddInParameter(storedProcCommand, "@SendCallAlertTime", DbType.Int32, SendCallAlertTime);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Insert_Alert_Settings(long CompanyID, long UserID, string TasksAlert, int TasksAlertMinute, string TasksAlertFor, string EventAlert, int EventAlertMinute, string EventAlertFor, string CallAlert, int CallAlertMinute, string CallAlertFor, int CreatedBy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_Alert_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@TasksAlert", DbType.String, TasksAlert);
            database.AddInParameter(storedProcCommand, "@TasksAlertMinute", DbType.Int32, TasksAlertMinute);
            database.AddInParameter(storedProcCommand, "@TasksAlertFor", DbType.String, TasksAlertFor);
            database.AddInParameter(storedProcCommand, "@EventAlert", DbType.String, EventAlert);
            database.AddInParameter(storedProcCommand, "@EventAlertMinute", DbType.Int32, EventAlertMinute);
            database.AddInParameter(storedProcCommand, "@EventAlertFor", DbType.String, EventAlertFor);
            database.AddInParameter(storedProcCommand, "@CallAlert", DbType.String, CallAlert);
            database.AddInParameter(storedProcCommand, "@CallAlertMinute", DbType.Int32, CallAlertMinute);
            database.AddInParameter(storedProcCommand, "@CallAlertFor", DbType.String, CallAlertFor);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Insert_CopyWidgets(int MasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int CreatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Insert_CopyWidgets");
            database.AddInParameter(storedProcCommand, "@MasterID", DbType.Int32, MasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@WidgetType", DbType.String, WidgetType);
            database.AddInParameter(storedProcCommand, "@DefaultDate", DbType.Int32, DefaultDate);
            database.AddInParameter(storedProcCommand, "@ShowPrint", DbType.Int32, ShowPrint);
            database.AddInParameter(storedProcCommand, "@TitleName", DbType.String, TitleName);
            database.AddInParameter(storedProcCommand, "@WidgetName", DbType.String, WidgetName);
            database.AddInParameter(storedProcCommand, "@DisplayType", DbType.String, DisplayType);
            database.AddInParameter(storedProcCommand, "@GraphType", DbType.String, GraphType);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            database.AddInParameter(storedProcCommand, "@CustomizeColumns", DbType.String, Customizecolumns);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, Customerid);
            database.AddInParameter(storedProcCommand, "@IsSpreadOverTwoColumns", DbType.Boolean, isSpread);
            database.AddInParameter(storedProcCommand, "@TaskStatus", DbType.String, TaskStatus);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@DisplayRecordSalesOf", DbType.String, DisplayRecordSalesOf);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.String, Todate);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ShowFullScreen", DbType.Boolean, ShowFullScreen);
            database.AddInParameter(storedProcCommand, "@ShowAllOptions", DbType.Boolean, ShowAllOptions);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ShowArchivedStatus", DbType.Boolean, ShowArchivedStatus);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Insert_CopyWidgetsNew(int MasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int CreatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus, bool IsLastYearData,bool IsDailyTarget,bool IsMonthlyTarget)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Insert_CopyWidgetsNew");
            database.AddInParameter(storedProcCommand, "@MasterID", DbType.Int32, MasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@WidgetType", DbType.String, WidgetType);
            database.AddInParameter(storedProcCommand, "@DefaultDate", DbType.Int32, DefaultDate);
            database.AddInParameter(storedProcCommand, "@ShowPrint", DbType.Int32, ShowPrint);
            database.AddInParameter(storedProcCommand, "@TitleName", DbType.String, TitleName);
            database.AddInParameter(storedProcCommand, "@WidgetName", DbType.String, WidgetName);
            database.AddInParameter(storedProcCommand, "@DisplayType", DbType.String, DisplayType);
            database.AddInParameter(storedProcCommand, "@GraphType", DbType.String, GraphType);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            database.AddInParameter(storedProcCommand, "@CustomizeColumns", DbType.String, Customizecolumns);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, Customerid);
            database.AddInParameter(storedProcCommand, "@IsSpreadOverTwoColumns", DbType.Boolean, isSpread);
            database.AddInParameter(storedProcCommand, "@TaskStatus", DbType.String, TaskStatus);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@DisplayRecordSalesOf", DbType.String, DisplayRecordSalesOf);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.String, Todate);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ShowFullScreen", DbType.Boolean, ShowFullScreen);
            database.AddInParameter(storedProcCommand, "@ShowAllOptions", DbType.Boolean, ShowAllOptions);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ShowArchivedStatus", DbType.Boolean, ShowArchivedStatus);
            database.AddInParameter(storedProcCommand, "@IsLastYearData", DbType.Boolean, IsLastYearData);
            database.AddInParameter(storedProcCommand, "@IsDailyTarget", DbType.Boolean, IsDailyTarget);
            database.AddInParameter(storedProcCommand, "@IsMonthlyTarget", DbType.Boolean, IsMonthlyTarget);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Insert_CopyWidgets(long CopyMasterID, long CompanyID, string UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, long CreatedBy, string IsCalendarYear, string FromDate, string ToDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Insert_MiniUserdWidgets");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int64, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludeArchiverecords", DbType.Boolean, IncludeArchiverecords);
            database.AddInParameter(storedProcCommand, "@IsDisplayWidget", DbType.Boolean, IsDisplayWidget);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, Title);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void Settings_Insert_CopyWidgets(long CopyMasterID, long CompanyID, int UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, long CreatedBy, string IsCalendarYear, string FromDate, string ToDate,DailyTarget dailyTarget,MonthlyTarget monthlyTarget)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Insert_MiniUserdWidgetsNew");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int64, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludeArchiverecords", DbType.Boolean, IncludeArchiverecords);
            database.AddInParameter(storedProcCommand, "@IsDisplayWidget", DbType.Boolean, IsDisplayWidget);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, Title);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, CreatedBy);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget1", DbType.Currency, monthlyTarget.MonthlyTarget1);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget2", DbType.Currency, monthlyTarget.MonthlyTarget2);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget3", DbType.Currency, monthlyTarget.MonthlyTarget3);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget4", DbType.Currency, monthlyTarget.MonthlyTarget4);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget5", DbType.Currency, monthlyTarget.MonthlyTarget5);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget6", DbType.Currency, monthlyTarget.MonthlyTarget6);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget7", DbType.Currency, monthlyTarget.MonthlyTarget7);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget8", DbType.Currency, monthlyTarget.MonthlyTarget8);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget9", DbType.Currency, monthlyTarget.MonthlyTarget9);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget10", DbType.Currency, monthlyTarget.MonthlyTarget10);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget11", DbType.Currency, monthlyTarget.MonthlyTarget11);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget12", DbType.Currency, monthlyTarget.MonthlyTarget12);

            database.AddInParameter(storedProcCommand, "@DailyTarget1", DbType.Currency, dailyTarget.DailyTarget1);
            database.AddInParameter(storedProcCommand, "@DailyTarget2", DbType.Currency, dailyTarget.DailyTarget2);
            database.AddInParameter(storedProcCommand, "@DailyTarget3", DbType.Currency, dailyTarget.DailyTarget3);
            database.AddInParameter(storedProcCommand, "@DailyTarget4", DbType.Currency, dailyTarget.DailyTarget4);
            database.AddInParameter(storedProcCommand, "@DailyTarget5", DbType.Currency, dailyTarget.DailyTarget5);
            database.AddInParameter(storedProcCommand, "@DailyTarget6", DbType.Currency, dailyTarget.DailyTarget6);
            database.AddInParameter(storedProcCommand, "@DailyTarget7", DbType.Currency, dailyTarget.DailyTarget7);
            database.AddInParameter(storedProcCommand, "@DailyTarget8", DbType.Currency, dailyTarget.DailyTarget8);
            database.AddInParameter(storedProcCommand, "@DailyTarget9", DbType.Currency, dailyTarget.DailyTarget9);
            database.AddInParameter(storedProcCommand, "@DailyTarget10", DbType.Currency, dailyTarget.DailyTarget10);
            database.AddInParameter(storedProcCommand, "@DailyTarget11", DbType.Currency, dailyTarget.DailyTarget11);
            database.AddInParameter(storedProcCommand, "@DailyTarget12", DbType.Currency, dailyTarget.DailyTarget12);
            database.AddInParameter(storedProcCommand, "@DailyTarget13", DbType.Currency, dailyTarget.DailyTarget13);
            database.AddInParameter(storedProcCommand, "@DailyTarget14", DbType.Currency, dailyTarget.DailyTarget14);
            database.AddInParameter(storedProcCommand, "@DailyTarget15", DbType.Currency, dailyTarget.DailyTarget15);
            database.AddInParameter(storedProcCommand, "@DailyTarget16", DbType.Currency, dailyTarget.DailyTarget16);
            database.AddInParameter(storedProcCommand, "@DailyTarget17", DbType.Currency, dailyTarget.DailyTarget17);
            database.AddInParameter(storedProcCommand, "@DailyTarget18", DbType.Currency, dailyTarget.DailyTarget18);
            database.AddInParameter(storedProcCommand, "@DailyTarget19", DbType.Currency, dailyTarget.DailyTarget19);
            database.AddInParameter(storedProcCommand, "@DailyTarget20", DbType.Currency, dailyTarget.DailyTarget20);
            database.AddInParameter(storedProcCommand, "@DailyTarget21", DbType.Currency, dailyTarget.DailyTarget21);
            database.AddInParameter(storedProcCommand, "@DailyTarget22", DbType.Currency, dailyTarget.DailyTarget22);
            database.AddInParameter(storedProcCommand, "@DailyTarget23", DbType.Currency, dailyTarget.DailyTarget23);
            database.AddInParameter(storedProcCommand, "@DailyTarget24", DbType.Currency, dailyTarget.DailyTarget24);
            database.AddInParameter(storedProcCommand, "@DailyTarget25", DbType.Currency, dailyTarget.DailyTarget25);
            database.AddInParameter(storedProcCommand, "@DailyTarget26", DbType.Currency, dailyTarget.DailyTarget26);
            database.AddInParameter(storedProcCommand, "@DailyTarget27", DbType.Currency, dailyTarget.DailyTarget27);
            database.AddInParameter(storedProcCommand, "@DailyTarget28", DbType.Currency, dailyTarget.DailyTarget28);
            database.AddInParameter(storedProcCommand, "@DailyTarget29", DbType.Currency, dailyTarget.DailyTarget29);
            database.AddInParameter(storedProcCommand, "@DailyTarget30", DbType.Currency, dailyTarget.DailyTarget30);
            database.AddInParameter(storedProcCommand, "@DailyTarget31", DbType.Currency, dailyTarget.DailyTarget31);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual int Settings_inventoryStockReduction_insert_update(long CompanyID, string StockReduces, int JobStatusChange, string CancelledJob, int StatusMsg)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_inventoryStockReduction_insert_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StockReduces", DbType.String, StockReduces);
            database.AddInParameter(storedProcCommand, "@JobStatusChange", DbType.Int32, JobStatusChange);
            database.AddInParameter(storedProcCommand, "@CanceledJob", DbType.String, CancelledJob);
            database.AddInParameter(storedProcCommand, "@StatusMsg", DbType.Int32, StatusMsg);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Settings_inventoryStockReduction_Select(long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_inventoryStockReduction_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long settings_itemdescription_insert(int CompanyID, long ItemDescriptionID, string EstimateType, string DatabaseFieldName, string ScreenName, bool IsChecked, int DisplayOrder)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemdescription_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemDescriptionID", DbType.Int64, ItemDescriptionID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@DatabaseFieldName", DbType.String, DatabaseFieldName);
            database.AddInParameter(storedProcCommand, "@ScreenName", DbType.String, ScreenName);
            database.AddInParameter(storedProcCommand, "@IsChecked", DbType.Boolean, IsChecked);
            database.AddInParameter(storedProcCommand, "@DisplayOrder", DbType.Int32, DisplayOrder);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual string settings_itemdescription_select(int CompanyID, string EstimateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemdescription_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string settings_itemdescription_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemdescription_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable settings_itemdescriptionNew_select(int companyid, string EstType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemdescriptionNew_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable settings_items_delivery_note_select(int CompanyID, long DeliveryID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estimate_delivery_note_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int64, DeliveryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_itemtitle_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemtitle_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemTitleID", DbType.Int32, item.ItemTitleID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_itemtitle_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemtitle_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_itemtitle_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemtitle_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_itemtitle_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_itemtitle_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemTitleID", DbType.Int32, item.ItemTitleID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, item.ItemTitle);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_jobcardsettings_itemdescription_update(int CompanyID, string Data)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_jobcardsettings_itemdescription_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Data", DbType.String, Data);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_languages_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_languages_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet settings_largeformat_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_largeformat_press_PageText", sqlConnection);
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

        public virtual DataSet settings_largeformat_press_SetDefault(int CompanyID, int PressID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_largeformat_press_SetDefault", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PressId", PressID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void Settings_LargeFormate_Delete(int CompanyID, long LargeFormatPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Settings_LargeFormate_Insert(int CompanyID, string PressName, string Description, decimal MinWebWidth, decimal MaxWebWidth, decimal MaxSheetWidth, string GripSideOrientation, decimal GripDepth, decimal GutterDepth, string PaperType, decimal SetUpSpoilage, string SpoilageInTerms, decimal RunningSpoilage, decimal PaperSizeID, decimal SheetSizeID, decimal JobSizeID, decimal GuillotineID, bool IsPerfecting, decimal SetupCharge, decimal MinRunningCharge, decimal Markup, decimal PrintPerHourLow, decimal PrintPerHourMedium, decimal PrintPerHourHigh, decimal PerHourCharge, decimal CoverageSide1, decimal CoverageSide2, bool IsDefaultPress, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, string InkType, int UnitOfMeasure, long Materail2, long Material3, long Material4, long Material5, decimal WhiteInkCoverageSide1, decimal WhiteInkCoverageSide2, bool isFullSheet, string CalculationType, decimal SetUpSpoilage_Sqm)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_press_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PressName", DbType.String, PressName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MinWebWidth", DbType.Decimal, MinWebWidth);
            database.AddInParameter(storedProcCommand, "@MaxWebWidth", DbType.Decimal, MaxWebWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetWeight", DbType.Decimal, MaxSheetWidth);
            database.AddInParameter(storedProcCommand, "@GripSideOrientation", DbType.String, GripSideOrientation);
            database.AddInParameter(storedProcCommand, "@GripDepth", DbType.Decimal, GripDepth);
            database.AddInParameter(storedProcCommand, "@GutterDepth", DbType.Decimal, GutterDepth);
            database.AddInParameter(storedProcCommand, "@PaperType", DbType.String, PaperType);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Decimal, SetUpSpoilage);
            database.AddInParameter(storedProcCommand, "@SpoilageInTerms", DbType.String, SpoilageInTerms);
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, PaperSizeID);
            database.AddInParameter(storedProcCommand, "@SheetSizeID", DbType.Int32, SheetSizeID);
            database.AddInParameter(storedProcCommand, "@JobSizeID", DbType.Int32, JobSizeID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int32, GuillotineID);
            database.AddInParameter(storedProcCommand, "@IsPerfecting", DbType.Boolean, IsPerfecting);
            database.AddInParameter(storedProcCommand, "@SetupCharge", DbType.Decimal, SetupCharge);
            database.AddInParameter(storedProcCommand, "@MinRunningCharge", DbType.Decimal, MinRunningCharge);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@PrintPerHourLow", DbType.Decimal, PrintPerHourLow);
            database.AddInParameter(storedProcCommand, "@PrintPerHourMedium", DbType.Decimal, PrintPerHourMedium);
            database.AddInParameter(storedProcCommand, "@PrintPerHourHigh", DbType.Decimal, PrintPerHourHigh);
            database.AddInParameter(storedProcCommand, "@PerHourCharge", DbType.Decimal, PerHourCharge);
            database.AddInParameter(storedProcCommand, "@CoverageSide1", DbType.Decimal, CoverageSide1);
            database.AddInParameter(storedProcCommand, "@CoverageSide2", DbType.Decimal, CoverageSide2);
            database.AddInParameter(storedProcCommand, "@IsDefaultPress", DbType.Boolean, IsDefaultPress);
            database.AddInParameter(storedProcCommand, "@PrintImageHeight", DbType.Decimal, PrintImageHeight);
            database.AddInParameter(storedProcCommand, "@PrintImageWidth", DbType.Decimal, PrintImageWidth);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
            database.AddInParameter(storedProcCommand, "@InkType", DbType.String, InkType);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddInParameter(storedProcCommand, "@Material2", DbType.Int64, Materail2);
            database.AddInParameter(storedProcCommand, "@Material3", DbType.Int64, Material3);
            database.AddInParameter(storedProcCommand, "@Material4", DbType.Int64, Material4);
            database.AddInParameter(storedProcCommand, "@Material5", DbType.Int64, Material5);
            database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide1", DbType.Decimal, WhiteInkCoverageSide1);
            database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide2", DbType.Decimal, WhiteInkCoverageSide2);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.AddInParameter(storedProcCommand, "@isFullSheet", DbType.Boolean, isFullSheet);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage_Sqm", DbType.Decimal, SetUpSpoilage_Sqm);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Settings_LargeFormate_Insert_ink_insert(int CompanyID, long LargeFormatPressID, int InkID, bool IswhiteInk)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_insert_ink_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            database.AddInParameter(storedProcCommand, "@InkID", DbType.Int32, InkID);
            database.AddInParameter(storedProcCommand, "@IswhiteInk", DbType.Boolean, IswhiteInk);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual IDataReader Settings_LargeFormate_Insert_ink_update(int CompanyID, long LargeFormatPressID, bool IswhiteInk)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_select_ink_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            database.AddInParameter(storedProcCommand, "@IswhiteInk", DbType.Boolean, IswhiteInk);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader Settings_LargeFormate_Select(int CompanyID, long LargeFormatPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_select_for_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual int Settings_LargeFormate_Update(int CompanyID, long LargeFormatPressID, string PressName, string Description, decimal MinWebWidth, decimal MaxWebWidth, decimal MaxSheetWidth, string GripSideOrientation, decimal GripDepth, decimal GutterDepth, string PaperType, decimal SetUpSpoilage, decimal RunningSpoilage, int PaperSizeID, int SheetSizeID, int JobSizeID, int GuillotineID, bool IsPerfecting, decimal SetupCharge, decimal MinRunningCharge, decimal Markup, decimal PrintPerHourLow, decimal PrintPerHourMedium, decimal PrintPerHourHigh, decimal PerHourCharge, decimal CoverageSide1, decimal CoverageSide2, bool IsDefaultPress, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, string InkType, int UnitOfMeasure, long Material2, long Material3, long Material4, long Material5, decimal WhiteInkCoverageSide1, decimal WhiteInkCoverageSide2, bool isFullSheet, decimal SetUpSpoilage_Sqm)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_press_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int32, LargeFormatPressID);
            database.AddInParameter(storedProcCommand, "@PressName", DbType.String, PressName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MinWebWidth", DbType.Decimal, MinWebWidth);
            database.AddInParameter(storedProcCommand, "@MaxWebWidth", DbType.Decimal, MaxWebWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetWidth", DbType.Decimal, MaxSheetWidth);
            database.AddInParameter(storedProcCommand, "@GripSideOrientation", DbType.String, GripSideOrientation);
            database.AddInParameter(storedProcCommand, "@GripDepth", DbType.Decimal, GripDepth);
            database.AddInParameter(storedProcCommand, "@GutterDepth", DbType.Decimal, GutterDepth);
            database.AddInParameter(storedProcCommand, "@PaperType", DbType.String, PaperType);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage", DbType.Decimal, SetUpSpoilage);
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, PaperSizeID);
            database.AddInParameter(storedProcCommand, "@SheetSizeID", DbType.Int32, SheetSizeID);
            database.AddInParameter(storedProcCommand, "@JobSizeID", DbType.Int32, JobSizeID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int32, GuillotineID);
            database.AddInParameter(storedProcCommand, "@IsPerfecting", DbType.Boolean, IsPerfecting);
            database.AddInParameter(storedProcCommand, "@SetupCharge", DbType.Decimal, SetupCharge);
            database.AddInParameter(storedProcCommand, "@MinRunningCharge", DbType.Decimal, MinRunningCharge);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@PrintPerHourLow", DbType.Decimal, PrintPerHourLow);
            database.AddInParameter(storedProcCommand, "@PrintPerHourMedium", DbType.Decimal, PrintPerHourMedium);
            database.AddInParameter(storedProcCommand, "@PrintPerHourHigh", DbType.Decimal, PrintPerHourHigh);
            database.AddInParameter(storedProcCommand, "@PerHourCharge", DbType.Decimal, PerHourCharge);
            database.AddInParameter(storedProcCommand, "@CoverageSide1", DbType.Decimal, CoverageSide1);
            database.AddInParameter(storedProcCommand, "@CoverageSide2", DbType.Decimal, CoverageSide2);
            database.AddInParameter(storedProcCommand, "@IsDefaultPress", DbType.Boolean, IsDefaultPress);
            database.AddInParameter(storedProcCommand, "@PrintImageHeight", DbType.Decimal, PrintImageHeight);
            database.AddInParameter(storedProcCommand, "@PrintImageWidth", DbType.Decimal, PrintImageWidth);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
            database.AddInParameter(storedProcCommand, "@InkType", DbType.String, InkType);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddInParameter(storedProcCommand, "@Material2", DbType.Int64, Material2);
            database.AddInParameter(storedProcCommand, "@Material3", DbType.Int64, Material3);
            database.AddInParameter(storedProcCommand, "@Material4", DbType.Int64, Material4);
            database.AddInParameter(storedProcCommand, "@Material5", DbType.Int64, Material5);
            database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide1", DbType.Decimal, WhiteInkCoverageSide1);
            database.AddInParameter(storedProcCommand, "@WhiteInkCoverageSide2", DbType.Decimal, WhiteInkCoverageSide2);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@isFullSheet", DbType.Boolean, isFullSheet);
            database.AddInParameter(storedProcCommand, "@SetUpSpoilage_Sqm", DbType.Decimal, SetUpSpoilage_Sqm);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void Settings_LargeFormate_update_ink_Delete(int CompanyID, long LargeFormatPressID, int InkID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_insert_ink_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            database.AddInParameter(storedProcCommand, "@InkID", DbType.Int32, InkID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_LargeFormate_update_ink_update(int CompanyID, long LargeFormatPressID, int InkID, bool IswhiteInk)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_largeformate_insert_ink_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LargeFormatPressID", DbType.Int64, LargeFormatPressID);
            database.AddInParameter(storedProcCommand, "@InkID", DbType.Int32, InkID);
            database.AddInParameter(storedProcCommand, "@IswhiteInk", DbType.Boolean, IswhiteInk);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Litho_Insert_ink_insert(int CompanyID, long LithoPressID, int InkID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lithopress_insert_ink_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.AddInParameter(storedProcCommand, "@InkID", DbType.Int32, InkID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_Litho_press_matrix_insert(int CompanyID, long pressID, decimal GSM, decimal sheet, decimal sheetsperhour)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Litho_press_matrix_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@pressID", DbType.Int64, pressID);
            database.AddInParameter(storedProcCommand, "@GSM", DbType.Decimal, GSM);
            database.AddInParameter(storedProcCommand, "@sheet", DbType.Decimal, sheet);
            database.AddInParameter(storedProcCommand, "@sheetsperhour", DbType.Decimal, sheetsperhour);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_Litho_press_matrix_update(int CompanyID, long pressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Litho_press_matrix_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@pressID", DbType.Int64, pressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet settings_litho_press_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_litho_press_PageText", sqlConnection);
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

        public virtual void settings_lithopress_delete(int CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lithopress_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Settings_LithoPress_Insert(int CompanyID, string LithoPressName, string Description, decimal MaxImgHeight, decimal MaxImgWidth, decimal MaxSheetWeight, decimal PrintImageHeight, decimal PrintImageWidth, decimal GutterHorizontal, decimal GutterVertical, decimal SpoilageSheets, decimal RunningSpoilage, long PaperID, int PrintSheetID, int JobSizeID, long GuillotineID, decimal SetupCharge, decimal MinCharge, decimal MarkUp, long PlateID, decimal MakeReadyPerPlate, bool MakeReadyPerPlateCheck, decimal WashupChargePerColour, bool WashupChargePerColourCheck, string MethodName, decimal HourlyChargeRate, string ColourUnits, string DefaultColour, decimal DefaultInkCoverageSide, string InkType, bool IsDefaultPress, long LithoPressID, int UnitOfMeasure, decimal SetupChargeWork_n_Turn, decimal SetupChargeWork_n_Tumble, decimal MakeReadyWork_n_Turn, decimal MakeReadyWork_n_Tumble, bool isPerfect)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Litho_press_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressName", DbType.String, LithoPressName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MaxImgHeight", DbType.Decimal, MaxImgHeight);
            database.AddInParameter(storedProcCommand, "@MaxImgWidth", DbType.Decimal, MaxImgWidth);
            database.AddInParameter(storedProcCommand, "@MaxSheetWeight", DbType.Decimal, MaxSheetWeight);
            database.AddInParameter(storedProcCommand, "@PrintImageHeight", DbType.Decimal, PrintImageHeight);
            database.AddInParameter(storedProcCommand, "@PrintImageWidth", DbType.Decimal, PrintImageWidth);
            database.AddInParameter(storedProcCommand, "@GutterHorizontal", DbType.Decimal, GutterHorizontal);
            database.AddInParameter(storedProcCommand, "@GutterVertical", DbType.Decimal, GutterVertical);
            database.AddInParameter(storedProcCommand, "@SpoilageSheets", DbType.Decimal, SpoilageSheets);
            database.AddInParameter(storedProcCommand, "@RunningSpoilage", DbType.Decimal, RunningSpoilage);
            database.AddInParameter(storedProcCommand, "@PaperID", DbType.Int64, PaperID);
            database.AddInParameter(storedProcCommand, "@PrintSheetID", DbType.Int32, PrintSheetID);
            database.AddInParameter(storedProcCommand, "@JobSizeID", DbType.Int32, JobSizeID);
            database.AddInParameter(storedProcCommand, "@GuillotineID", DbType.Int64, GuillotineID);
            database.AddInParameter(storedProcCommand, "@SetupCharge", DbType.Decimal, SetupCharge);
            database.AddInParameter(storedProcCommand, "@MinCharge", DbType.Decimal, MinCharge);
            database.AddInParameter(storedProcCommand, "@MarkUp", DbType.Decimal, MarkUp);
            database.AddInParameter(storedProcCommand, "@PlateID", DbType.Int64, PlateID);
            database.AddInParameter(storedProcCommand, "@MakeReadyPerPlate", DbType.Decimal, MakeReadyPerPlate);
            database.AddInParameter(storedProcCommand, "@MakeReadyPerPlateCheck", DbType.Boolean, MakeReadyPerPlateCheck);
            database.AddInParameter(storedProcCommand, "@WashupChargePerColour", DbType.Decimal, WashupChargePerColour);
            database.AddInParameter(storedProcCommand, "@WashupChargePerColourCheck", DbType.Boolean, WashupChargePerColourCheck);
            database.AddInParameter(storedProcCommand, "@MethodName", DbType.String, MethodName);
            database.AddInParameter(storedProcCommand, "@HourlyChargeRate", DbType.Decimal, HourlyChargeRate);
            database.AddInParameter(storedProcCommand, "@ColourUnits", DbType.String, ColourUnits);
            database.AddInParameter(storedProcCommand, "@DefaultColour", DbType.String, DefaultColour);
            database.AddInParameter(storedProcCommand, "@DefaultInkCoverageSide", DbType.Decimal, DefaultInkCoverageSide);
            database.AddInParameter(storedProcCommand, "@IsDefaultPress", DbType.Boolean, IsDefaultPress);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.AddInParameter(storedProcCommand, "@InkType", DbType.String, InkType);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddInParameter(storedProcCommand, "@SetupChargeWork_n_Turn", DbType.Decimal, SetupChargeWork_n_Turn);
            database.AddInParameter(storedProcCommand, "@SetupChargeWork_n_Tumble", DbType.Decimal, SetupChargeWork_n_Tumble);
            database.AddInParameter(storedProcCommand, "@MakeReadyWork_n_Turn", DbType.Decimal, MakeReadyWork_n_Turn);
            database.AddInParameter(storedProcCommand, "@MakeReadyWork_n_Tumble", DbType.Decimal, MakeReadyWork_n_Tumble);
            database.AddInParameter(storedProcCommand, "@isPressPerfect", DbType.Boolean, isPerfect);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : Convert.ToInt64(parameterValue));
        }

        public virtual DataTable Settings_LithoPress_Select_By_ID(int CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_litho_press_select_By_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual IDataReader settings_lithopress_select_ink(int CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lithopress_select_ink");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader settings_lithopress_select_ink_rownum(int CompanyID, long LithoPressID, int rownum)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lithopress_select_ink_rownum");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.AddInParameter(storedProcCommand, "@rownum", DbType.Int32, rownum);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual void settings_lithopress_SetDefault(int CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_lithopress_SetDefault");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_lithopress_update_ink_Delete(int CompanyID, long LithoPressID, int InkID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_litho_insert_ink_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            database.AddInParameter(storedProcCommand, "@InkID", DbType.Int32, InkID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Settings_LithoPressMatrix_Select_By_ID(int CompanyID, long LithoPressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_litho_press_matrix_select_By_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@LithoPressID", DbType.Int64, LithoPressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_managecampaign_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_managecampaign_delete");
            database.AddInParameter(storedProcCommand, "@ManageID", DbType.String, item.ManageID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_markup_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_markup_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@MarkupID", DbType.String, item.MarkupID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_markup_for_printbroker_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_markup_for_printbroker_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_markup_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_markup_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@MarkupName", DbType.String, item.MarkupName);
            database.AddInParameter(storedProcCommand, "@MarkupRate", DbType.Decimal, item.MarkupRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_markup_rate_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_markup_rate_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_markup_select(int CompanyID, int MarkupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_markup_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, MarkupID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_markup_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_markup_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_markup_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_markup_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, item.MarkupID);
            database.AddInParameter(storedProcCommand, "@MarkupName", DbType.String, item.MarkupName);
            database.AddInParameter(storedProcCommand, "@MarkupRate", DbType.Decimal, item.MarkupRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataSet Settings_MasterWidget_Select_ByMasterID(int MasterID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_MasterWidget_Select_ByMasterID");
            database.AddInParameter(storedProcCommand, "@MasterID", DbType.Int64, MasterID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void Settings_MiniCopyWidget_delete(int CopyMasterID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_MiniCopyWidget_delete");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int32, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Settings_MiniMasterWidget_Select_ByMasterID(int MasterID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Mini_MasterWidget_Select_ByMasterID");
            database.AddInParameter(storedProcCommand, "@MasterID", DbType.Int64, MasterID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void settings_number_insert(int CompanyID, int Estimate, int Jobs, int Invoices, int Purchases, int Delivery, char Type, int Order, string NumberingType, string IpAddress, string NumberingChangeHistory, int Account)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_number_insert]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Estimate", DbType.Int32, Estimate);
            database.AddInParameter(storedProcCommand, "@Jobs", DbType.Int32, Jobs);
            database.AddInParameter(storedProcCommand, "@Invoices", DbType.Int32, Invoices);
            database.AddInParameter(storedProcCommand, "@Purchases", DbType.Int32, Purchases);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.Int32, Delivery);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@Order", DbType.Int32, Order);
            database.AddInParameter(storedProcCommand, "@NumberingType", DbType.String, NumberingType);
            database.AddInParameter(storedProcCommand, "@IpAddress", DbType.String, IpAddress);
            database.AddInParameter(storedProcCommand, "@NumberingHistory", DbType.String, NumberingChangeHistory);
            database.AddInParameter(storedProcCommand, "@Account", DbType.Int32, Account);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual IDataReader settings_number_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_number_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual DataTable settings_number_select1(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_number_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_OrderingProcess_select(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_estoredisplaySettings_Select_New");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string settings_otherCost_category_sortalpha_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_otherCost_category_sortalpha_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void settings_otherCost_category_sortalpha_update(int CompanyID, int FieldID, string cond)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_otherCost_category_sortalpha_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@FieldID", DbType.Int32, FieldID);
            database.AddInParameter(storedProcCommand, "@cond", DbType.String, cond);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_othercost_categoryduplicacy_check(int CompanyID, string OtherCostCategoryName, long OtherCostCategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_categoryduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryName", DbType.String, OtherCostCategoryName);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, OtherCostCategoryID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual long settings_OtherCost_Copy(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_OtherCost_Copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "OtherCostID", DbType.Int64, OtherCostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void settings_othercost_delete(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet settings_othercost_formulatag_select(int CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_othercost_formulatag_select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual long settings_othercost_insert(long OtherCostID, int CompanyID, string OtherCostName, string Description, long OtherCostCategoryID, string CalculationType, long CostTimeBasedID, int SupplierID, decimal PerHourCost, decimal Profit, decimal Minimum, string Formula)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_insert");
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostName", DbType.String, OtherCostName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, OtherCostCategoryID);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@CostTimeBasedID", DbType.Int64, CostTimeBasedID);
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
            database.AddInParameter(storedProcCommand, "@PerHourCost", DbType.Decimal, PerHourCost);
            database.AddInParameter(storedProcCommand, "@Profit", DbType.Decimal, Profit);
            database.AddInParameter(storedProcCommand, "@Minimum", DbType.Decimal, Minimum);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual int settings_othercost_matrix_insert(long OtherCostID, string CalculationType, string Column1, string Column2, string Column3, string Column4, string Column5, string Column6, string Column7, string Column8, string Column9, string Column10, string Prompt)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_insert");
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, Convert.ToInt32(this.Session["CompanyID"].ToString()));
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@Column1", DbType.String, Column1);
            database.AddInParameter(storedProcCommand, "@Column2", DbType.String, Column2);
            database.AddInParameter(storedProcCommand, "@Column3", DbType.String, Column3);
            database.AddInParameter(storedProcCommand, "@Column4", DbType.String, Column4);
            database.AddInParameter(storedProcCommand, "@Column5", DbType.String, Column5);
            database.AddInParameter(storedProcCommand, "@Column6", DbType.String, Column6);
            database.AddInParameter(storedProcCommand, "@Column7", DbType.String, Column7);
            database.AddInParameter(storedProcCommand, "@Column8", DbType.String, Column8);
            database.AddInParameter(storedProcCommand, "@Column9", DbType.String, Column9);
            database.AddInParameter(storedProcCommand, "@Column10", DbType.String, Column10);
            database.AddInParameter(storedProcCommand, "@Prompt", DbType.String, Prompt);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_othercost_matrix_select(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_othercost_matrix_update(int MatrixHeadingID, string CalculationType, string Column1, string Column2, string Column3, string Column4, string Column5, string Column6, string Column7, string Column8, string Column9, string Column10, string Prompt)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_update");
            database.AddInParameter(storedProcCommand, "@MatrixHeadingID", DbType.Int64, MatrixHeadingID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, Convert.ToInt32(this.Session["CompanyID"].ToString()));
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@Column1", DbType.String, Column1);
            database.AddInParameter(storedProcCommand, "@Column2", DbType.String, Column2);
            database.AddInParameter(storedProcCommand, "@Column3", DbType.String, Column3);
            database.AddInParameter(storedProcCommand, "@Column4", DbType.String, Column4);
            database.AddInParameter(storedProcCommand, "@Column5", DbType.String, Column5);
            database.AddInParameter(storedProcCommand, "@Column6", DbType.String, Column6);
            database.AddInParameter(storedProcCommand, "@Column7", DbType.String, Column7);
            database.AddInParameter(storedProcCommand, "@Column8", DbType.String, Column8);
            database.AddInParameter(storedProcCommand, "@Column9", DbType.String, Column9);
            database.AddInParameter(storedProcCommand, "@Column10", DbType.String, Column10);
            database.AddInParameter(storedProcCommand, "@Prompt", DbType.String, Prompt);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_othercost_matrix_value_insert(int MatrixID, int From, int To, decimal Col1Value, decimal Col2Value, decimal Col3Value, decimal Col4Value, decimal Col5Value, decimal Col6Value, decimal Col7Value, decimal Col8Value, decimal Col9Value, decimal Col10Value)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_value_insert");
            database.AddInParameter(storedProcCommand, "@MatrixID", DbType.Int32, MatrixID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, Convert.ToInt32(this.Session["CompanyID"].ToString()));
            database.AddInParameter(storedProcCommand, "@From", DbType.Int32, From);
            database.AddInParameter(storedProcCommand, "@To", DbType.Int32, To);
            database.AddInParameter(storedProcCommand, "@Col1Value", DbType.Decimal, Col1Value);
            database.AddInParameter(storedProcCommand, "@Col2Value", DbType.Decimal, Col2Value);
            database.AddInParameter(storedProcCommand, "@Col3Value", DbType.Decimal, Col3Value);
            database.AddInParameter(storedProcCommand, "@Col4Value", DbType.Decimal, Col4Value);
            database.AddInParameter(storedProcCommand, "@Col5Value", DbType.Decimal, Col5Value);
            database.AddInParameter(storedProcCommand, "@Col6Value", DbType.Decimal, Col6Value);
            database.AddInParameter(storedProcCommand, "@Col7Value", DbType.Decimal, Col7Value);
            database.AddInParameter(storedProcCommand, "@Col8Value", DbType.Decimal, Col8Value);
            database.AddInParameter(storedProcCommand, "@Col9Value", DbType.Decimal, Col9Value);
            database.AddInParameter(storedProcCommand, "@Col10Value", DbType.Decimal, Col10Value);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_othercost_matrix_value_select(int CompanyID, int MatrixHeadingID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_value_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@MatrixHeadingID", DbType.Int32, MatrixHeadingID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_othercost_matrix_value_update(int MatrixValueID, int From, int To, decimal Col1Value, decimal Col2Value, decimal Col3Value, decimal Col4Value, decimal Col5Value, decimal Col6Value, decimal Col7Value, decimal Col8Value, decimal Col9Value, decimal Col10Value)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_matrix_value_update");
            database.AddInParameter(storedProcCommand, "@MatrixValueID", DbType.Int32, MatrixValueID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, Convert.ToInt32(this.Session["CompanyID"].ToString()));
            database.AddInParameter(storedProcCommand, "@From", DbType.Int32, From);
            database.AddInParameter(storedProcCommand, "@To", DbType.Int32, To);
            database.AddInParameter(storedProcCommand, "@Col1Value", DbType.Decimal, Col1Value);
            database.AddInParameter(storedProcCommand, "@Col2Value", DbType.Decimal, Col2Value);
            database.AddInParameter(storedProcCommand, "@Col3Value", DbType.Decimal, Col3Value);
            database.AddInParameter(storedProcCommand, "@Col4Value", DbType.Decimal, Col4Value);
            database.AddInParameter(storedProcCommand, "@Col5Value", DbType.Decimal, Col5Value);
            database.AddInParameter(storedProcCommand, "@Col6Value", DbType.Decimal, Col6Value);
            database.AddInParameter(storedProcCommand, "@Col7Value", DbType.Decimal, Col7Value);
            database.AddInParameter(storedProcCommand, "@Col8Value", DbType.Decimal, Col8Value);
            database.AddInParameter(storedProcCommand, "@Col9Value", DbType.Decimal, Col9Value);
            database.AddInParameter(storedProcCommand, "@Col10Value", DbType.Decimal, Col10Value);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet settings_othercost_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int OthercostCategoryid)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_othercost_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@OtherCostCategoryid", OthercostCategoryid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable settings_othercost_select(int CompanyID, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_othercost_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercost_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet settings_othercost_View(int CompanyID, int OtherCostCategoryID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_OtherCost_Ctgry_Select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@OtherCostCategoryID", OtherCostCategoryID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void settings_othercostcategory_delete(int CompanyID, long OtherCostCategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostcategory_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, OtherCostCategoryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_othercostcategory_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostcategory_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, item.OtherCostCategoryID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryName", DbType.String, item.OtherCostCategoryName);
            database.AddInParameter(storedProcCommand, "@PreStatus", DbType.Int32, item.StatusID);
            database.AddInParameter(storedProcCommand, "@JobcardCategory", DbType.String, item.JobcardCategory);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_othercostcategory_select(int CompanyID, long OtherCostCategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostcategory_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostCategoryID", DbType.Int64, OtherCostCategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_othercostcategory_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostcategory_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_othercostcategory_selectall_new(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostcategory_selectall_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_othercostduplicacy_check(int CompanyID, string OtherCostName, long OtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_othercostduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OtherCostName", DbType.String, OtherCostName);
            database.AddInParameter(storedProcCommand, "@OtherCostID", DbType.Int64, OtherCostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_OtherSettings_insert_update(int CompanyID, string JobName, string DatabaseFieldName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertUpdate_Storedescriptionfield");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobName", DbType.String, JobName);
            database.AddInParameter(storedProcCommand, "@DatabaseFieldName", DbType.String, DatabaseFieldName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_othersettings_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_othersettings_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_papersize_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.String, item.PaperSizeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_papersize_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_add");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeName", DbType.String, item.PaperSizeName);
            database.AddInParameter(storedProcCommand, "@Height", DbType.String, item.Height);
            database.AddInParameter(storedProcCommand, "@Width", DbType.String, item.Width);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_papersize_ordernumber_update(int CompanyID, int PaperSizeID, int OrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_papersize_order_number_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.String, PaperSizeID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.String, OrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_papersize_select(int CompanyID, int PaperSizeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, PaperSizeID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_papersize_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_papersize_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersize_edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, item.PaperSizeID);
            database.AddInParameter(storedProcCommand, "@PaperSizeName", DbType.String, item.PaperSizeName);
            database.AddInParameter(storedProcCommand, "@Height", DbType.String, item.Height);
            database.AddInParameter(storedProcCommand, "@Width", DbType.String, item.Width);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_PaperSize_update(int CompanyID, int OrderNumber, int PapaersizeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Papersize_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.Int32, OrderNumber);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, PapaersizeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string settings_papersizename_select(int CompanyID, int PaperSizeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_papersizename_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaperSizeID", DbType.Int32, PaperSizeID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable settings_PaymentTerms_SetDefault(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultPaymentTerms_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_PaymentValue_select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentDetails_Values_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_phrasebook_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.Int32, item.PhraseBookID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_phrasebook_footersignature_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_footersignature_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_phrasebook_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.AddInParameter(storedProcCommand, "@EmailTemplateName", DbType.String, item.EmailTemplateName);
            database.AddInParameter(storedProcCommand, "@EmailTemplateType", DbType.String, item.EmailTemplateType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_phrasebook_insert_drpdn(SettingsItem item, string LineSeparator, string LabelSeparator)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_insert_drpdn");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, item.Type);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, item.Title);
            database.AddInParameter(storedProcCommand, "@EmailTemplateName", DbType.String, item.EmailTemplateName);
            database.AddInParameter(storedProcCommand, "@EmailTemplateType", DbType.String, item.EmailTemplateType);
            database.AddInParameter(storedProcCommand, "@LineSeparator", DbType.String, LineSeparator);
            database.AddInParameter(storedProcCommand, "@LabelSeparator", DbType.String, LabelSeparator);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_phrasebook_select(int CompanyID, string PhraseType)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["PhraseText"] = baseClass.SpecialDecode(row["PhraseText"].ToString());
            }
            return dataTable;
        }

        public virtual void settings_phrasebook_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.Int32, item.PhraseBookID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.AddInParameter(storedProcCommand, "@EmailTemplateName", DbType.String, item.EmailTemplateName);
            database.AddInParameter(storedProcCommand, "@EmailTemplateType", DbType.String, item.EmailTemplateType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_phrasebook_update_drpdn(SettingsItem item, string LineSeparator, string LabelSeparator)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_phrasebook_update_drpdn");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.Int32, item.PhraseBookID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, item.Type);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, item.Title);
            database.AddInParameter(storedProcCommand, "@EmailTemplateName", DbType.String, item.EmailTemplateName);
            database.AddInParameter(storedProcCommand, "@EmailTemplateType", DbType.String, item.EmailTemplateType);
            database.AddInParameter(storedProcCommand, "@LineSeparator", DbType.String, LineSeparator);
            database.AddInParameter(storedProcCommand, "@LabelSeparator", DbType.String, LabelSeparator);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_plantpressduplicacy_check(int CompanyID, string PlantPressType, string PlantPressName, long PlantpressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_plantpressduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PlantPressType", DbType.String, PlantPressType);
            database.AddInParameter(storedProcCommand, "@PlantPressName", DbType.String, PlantPressName);
            database.AddInParameter(storedProcCommand, "@PlantpressID", DbType.Int64, PlantpressID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_PO_DeliveryAdrress_insertupdate(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_POdeliveryAddress_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@Digital", DbType.String, item.Digital);
            database.AddInParameter(storedProcCommand, "@DirectPO", DbType.String, item.DirectPO);
            database.AddInParameter(storedProcCommand, "@LargeFormat", DbType.String, item.Largeformat);
            database.AddInParameter(storedProcCommand, "@Offset", DbType.String, item.Offset);
            database.AddInParameter(storedProcCommand, "@OtherCost", DbType.String, item.OtherCost);
            database.AddInParameter(storedProcCommand, "@Outwork", DbType.String, item.Outwork);
            database.AddInParameter(storedProcCommand, "@PriceCatalogue", DbType.String, item.ProdCatalogue);
            database.AddInParameter(storedProcCommand, "@QuickQuote", DbType.String, item.QuickQuote);
            database.AddInParameter(storedProcCommand, "@Warehouse", DbType.String, item.Warehouse);
            database.AddInParameter(storedProcCommand, "@Order", DbType.String, item.Order);
            database.AddInParameter(storedProcCommand, "@DescriptionInclude", DbType.String, item.DescriptionInclude);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_PODeliveryAddress_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_POdeliveryAddress_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Settings_PreFlightOptions_InsertUpdate(int ProfileId, string Type, int TypeId, bool IsEnabled)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SETtings_PreFlightOptions_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@ProfileId", DbType.Int32, ProfileId);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@TypeId", DbType.Int32, TypeId);
            database.AddInParameter(storedProcCommand, "@IsEnabled", DbType.Boolean, IsEnabled);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_preFlightProfile_delete(long preflightID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PreflightProfile_Delete");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, preflightID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_PressName_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PressName_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_price_catalogue_chkexsisting(int CompanyID, int PriceCatalogueid, string itemcode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_chkexsisting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueid", DbType.Int32, PriceCatalogueid);
            database.AddInParameter(storedProcCommand, "@itemcode", DbType.String, itemcode);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_price_catalogue_customer_insert(int CompanyID, string SqlData)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_customer_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SqlData", DbType.String, SqlData);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_price_catalogue_insert(int CompanyID, int PriceCatalogueID, string itemcode, string CategoryName, string CatalogueName, string Description, int PriceCatalogueCategoryID, string ItemTitle, string Artwork, string Color, string Size, string Material, string Delivery, string Finishing, string Notes, string Terms, string MatrixType, string CustomerType, string Proofs, string Packing, int UnitOfMeasure)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@itemcode", DbType.String, itemcode);
            database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, CategoryName);
            database.AddInParameter(storedProcCommand, "@CatalogueName", DbType.String, CatalogueName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, Convert.ToInt32(this.Session["UserID"]));
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, PriceCatalogueCategoryID);
            database.AddInParameter(storedProcCommand, "@ItemTitle", DbType.String, ItemTitle);
            database.AddInParameter(storedProcCommand, "@Artwork", DbType.String, Artwork);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@Size", DbType.String, Size);
            database.AddInParameter(storedProcCommand, "@Material", DbType.String, Material);
            database.AddInParameter(storedProcCommand, "@Delivery", DbType.String, Delivery);
            database.AddInParameter(storedProcCommand, "@Finishing", DbType.String, Finishing);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@Instructions", DbType.String, Terms);
            database.AddInParameter(storedProcCommand, "@MatrixType", DbType.String, MatrixType);
            database.AddInParameter(storedProcCommand, "@CustomerType", DbType.String, CustomerType);
            database.AddInParameter(storedProcCommand, "@Proofs", DbType.String, Proofs);
            database.AddInParameter(storedProcCommand, "@Packing", DbType.String, Packing);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataSet settings_price_catalogue_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, int PriceCatalogueCategoryid)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_price_catalogue_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@PriceCatalogueCategoryID", PriceCatalogueCategoryid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void settings_price_catalogue_properties_delete(int PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_properties_delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_price_catalogue_properties_deleteAll(int CompanyID, int PriceCatalogueID)
        {
            long num = (long)0;
            if (this.Session["UserID"] != null)
            {
                num = Convert.ToInt64(this.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_properties_deleteAll");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_price_catalogue_properties_insert(int CompanyID, int PriceCatalogueID, int FromQuantity, int ToQuantity, decimal Price, decimal Markup, decimal SellingPrice)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_properties_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@FromQuantity", DbType.Int32, FromQuantity);
            database.AddInParameter(storedProcCommand, "@ToQuantity", DbType.Int32, ToQuantity);
            database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, SellingPrice);
            database.ExecuteNonQuery(storedProcCommand);
            return 1;
        }

        public virtual DataTable settings_price_catalogue_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_price_catalogue_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet settings_price_catalogue_selectByID(int CompanyID, int PriceCatalogueID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_settings_price_catalogue_selectByID", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PriceCatalogueID", PriceCatalogueID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void Settings_ReferedBy_Isdelete_Update(int ReferencedID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_ReferedBy_Isdelete_Update");
            database.AddInParameter(storedProcCommand, "@ReferencedID", DbType.Int32, ReferencedID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_RefferceBy_SetDefault(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultClientReferencedBy_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_regionalsettings_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_regionalsettings_insert");
            database.AddInParameter(storedProcCommand, "@RegionalID", DbType.Int32, item.RegionalID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@LanguageID", DbType.Int32, item.LanguageID);
            database.AddInParameter(storedProcCommand, "@DateFormat", DbType.String, item.DateFormat);
            database.AddInParameter(storedProcCommand, "@Colour", DbType.String, item.Colour);
            database.AddInParameter(storedProcCommand, "@Organisation", DbType.String, item.Organisation);
            database.AddInParameter(storedProcCommand, "@Centre", DbType.String, item.Centre);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, item.State);
            database.AddInParameter(storedProcCommand, "@PostCode", DbType.String, item.PostCode);
            database.AddInParameter(storedProcCommand, "@Metre", DbType.String, item.Metre);
            database.AddInParameter(storedProcCommand, "@Weight", DbType.String, item.Weight);
            database.AddInParameter(storedProcCommand, "@GeneralWeight", DbType.String, item.GeneralWeight);
            database.AddInParameter(storedProcCommand, "@PaperMeasure", DbType.String, item.PaperMeasure);
            database.AddInParameter(storedProcCommand, "@License", DbType.String, item.License);
            database.AddInParameter(storedProcCommand, "@PageTitle", DbType.String, item.PageTitle);
            database.AddInParameter(storedProcCommand, "@CompanyTitle", DbType.String, item.CompanyTitle);
            database.AddInParameter(storedProcCommand, "@TimeZoneID", DbType.String, item.TimeZoneID);
            database.AddInParameter(storedProcCommand, "@FiscalFrom", DbType.DateTime, item.fiscalfrom);
            database.AddInParameter(storedProcCommand, "@FisCalTo", DbType.DateTime, item.fiscalto);
            database.AddInParameter(storedProcCommand, "@IsDisplayCostCentre", DbType.Int32, item.IsDisplayCostCentre);
            database.AddInParameter(storedProcCommand, "@Roundoff", DbType.Int32, item.Roundoff);
            database.AddInParameter(storedProcCommand, "@PaperMaterial", DbType.String, item.PaperMaterial);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_regionalsettings_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_regionalsettings_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string settings_regionalsettings_select_by_type(int CompanyID, string RegionalType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_regionalsettings_select_by_type");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@RegionalType", DbType.String, RegionalType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void settings_RegionalSettings_update(int CompanyID, int LanguageID, string DateFormate, string Colour, string Organization, string State, string Centre, string ZipCode, string Metre, string Weight, string GeneralWeight, string PaperMeasure, string PageTitle, string CompanyTitle, int TimeZoneID, DateTime fiscalfromtxt, DateTime fiscaltotxt, int IsDisplayCostCentre,string PaperMaterial)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Regional_Settings__update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Language", DbType.Int32, LanguageID);
            database.AddInParameter(storedProcCommand, "@DateFormate", DbType.String, DateFormate);
            database.AddInParameter(storedProcCommand, "@colour", DbType.String, Colour);
            database.AddInParameter(storedProcCommand, "@organization", DbType.String, Organization);
            database.AddInParameter(storedProcCommand, "@State", DbType.String, State);
            database.AddInParameter(storedProcCommand, "@Centre", DbType.String, Centre);
            database.AddInParameter(storedProcCommand, "@zipcode", DbType.String, ZipCode);
            database.AddInParameter(storedProcCommand, "@Metre", DbType.String, Metre);
            database.AddInParameter(storedProcCommand, "@Weight", DbType.String, Weight);
            database.AddInParameter(storedProcCommand, "@GeneralWeight", DbType.String, GeneralWeight);
            database.AddInParameter(storedProcCommand, "@PaperMeasure", DbType.String, PaperMeasure);
            database.AddInParameter(storedProcCommand, "@PageTitle", DbType.String, PageTitle);
            database.AddInParameter(storedProcCommand, "@companytitle", DbType.String, CompanyTitle);
            database.AddInParameter(storedProcCommand, "@TimeZone", DbType.Int32, TimeZoneID);
            database.AddInParameter(storedProcCommand, "@FiscalFrom", DbType.DateTime, fiscalfromtxt);
            database.AddInParameter(storedProcCommand, "@FisCalTo", DbType.DateTime, fiscaltotxt);
            database.AddInParameter(storedProcCommand, "@IsDisplayCostCentre", DbType.Int32, IsDisplayCostCentre);
            database.AddInParameter(storedProcCommand, "@PaperMaterial", DbType.String, PaperMaterial);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_role_select(int companyid, int roleid, TextBox txtdescription, Label lblheader)
        {
            BaseClass baseClass = new BaseClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_role_select_one");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@RoleID", DbType.Int32, roleid);
            IDataReader dataReader = database.ExecuteReader(storedProcCommand);
            while (dataReader.Read())
            {
                txtdescription.Text = baseClass.SpecialDecode(dataReader["description"].ToString());
                lblheader.Text = string.Concat("Edit ", dataReader["usertype"].ToString(), " Role");
            }
            storedProcCommand.Dispose();
            dataReader.Dispose();
        }

        public virtual DataSet Settings_Select_Alert_Email_Body(int AlertID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("select_Alert_Notification_settings");
            database.AddInParameter(storedProcCommand, "@AlertID", DbType.Int32, AlertID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet settings_Select_Alert_Setting(long CompanyID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Alert_Setting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet settings_Select_Alert_Settings(long CompanyID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Alert_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Settings_Select_Copywidget_ByUserID(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Select_Copywidget_ByUserID");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Settings_Select_CopyWidgets(int CopyMasterID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Select_CopyWidgets");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int64, CopyMasterID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Settings_Select_MasterWidgets()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            return database.ExecuteDataSet(database.GetStoredProcCommand("Pc_Settings_Select_MasterWidgets"));
        }

        public virtual DataSet Settings_Select_MasterWidgetsForUSer()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            return database.ExecuteDataSet(database.GetStoredProcCommand("Pc_Settings_Select_MasterWidgetsForUSer"));
        }

        public virtual DataSet Settings_Select_MiniCopywidget(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Select_MiniCopywidget");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Settings_Select_MiniMasterWidgets()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            return database.ExecuteDataSet(database.GetStoredProcCommand("Pc_Settings_Select_MiniMasterWidgets"));
        }

        public virtual long Settings_SpeedWeightLookup_Insert_Update(int CompanyID, decimal HourlyCharge, decimal BlackGSM1, decimal BlackPagesPerMinute1, decimal BlackGSM2, decimal BlackPagesPerMinute2, decimal BlackGSM3, decimal BlackPagesPerMinute3, decimal ColorGSM1, decimal ColorPagesPerMinute1, decimal ColorGSM2, decimal ColorPagesPerMinute2, decimal ColorGSM3, decimal ColorPagesPerMinute3, long SpeedWeightLookupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_speedweightlookup_insert_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@HourlyCharge", DbType.Decimal, HourlyCharge);
            database.AddInParameter(storedProcCommand, "@BlackGSM1", DbType.Decimal, BlackGSM1);
            database.AddInParameter(storedProcCommand, "@BlackPagesPerMinute1", DbType.Decimal, BlackPagesPerMinute1);
            database.AddInParameter(storedProcCommand, "@BlackGSM2", DbType.Decimal, BlackGSM2);
            database.AddInParameter(storedProcCommand, "@BlackPagesPerMinute2", DbType.Decimal, BlackPagesPerMinute2);
            database.AddInParameter(storedProcCommand, "@BlackGSM3", DbType.Decimal, BlackGSM3);
            database.AddInParameter(storedProcCommand, "@BlackPagesPerMinute3", DbType.Decimal, BlackPagesPerMinute3);
            database.AddInParameter(storedProcCommand, "@ColorGSM1", DbType.Decimal, ColorGSM1);
            database.AddInParameter(storedProcCommand, "@ColorPagesPerMinute1", DbType.Decimal, ColorPagesPerMinute1);
            database.AddInParameter(storedProcCommand, "@ColorGSM2", DbType.Decimal, ColorGSM2);
            database.AddInParameter(storedProcCommand, "@ColorPagesPerMinute2", DbType.Decimal, ColorPagesPerMinute2);
            database.AddInParameter(storedProcCommand, "@ColorGSM3", DbType.Decimal, ColorGSM3);
            database.AddInParameter(storedProcCommand, "@ColorPagesPerMinute3", DbType.Decimal, ColorPagesPerMinute3);
            database.AddInParameter(storedProcCommand, "@SpeedWeightLookupID", DbType.Int64, SpeedWeightLookupID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Settings_SpeedWeightLookup_Select_By_ID(int CompanyID, long SpeedWeightLookupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_speedweightlookup_select_by_ID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SpeedWeightLookupID", DbType.Int64, SpeedWeightLookupID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_stockproperties_select()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection((new commonClass()).strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand("PC_settings_stockproperties_select", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                dataTable1.Load(sqlCommand.ExecuteReader());
                sqlConnection.Close();
                dataTable = dataTable1;
            }
            return dataTable;
        }

        public virtual void settings_subject_delete(int CompanyID, string Subject)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_subject_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_subject_insert(int CompanyID, string Subject)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_subject_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_subject_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_subject_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Settings_SupplierEmailBody_Insert(long CompanyID, string TemplateType, string TemplateName, string Subject, string Body, long EmailtoAdminID, bool Isdefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_SuplierEmailBody_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@EmailtoAdminID", DbType.Int64, EmailtoAdminID);
            database.AddInParameter(storedProcCommand, "@Isdefault", DbType.Boolean, Isdefault);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual string settings_system_markup_by_type(int CompanyID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_system_markup_by_type");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void settings_system_markup_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_system_markup_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@SystemMarkupID", DbType.String, item.SystemMarkupID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_system_markup_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_system_markup_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@Paper", DbType.Decimal, item.Paper);
            database.AddInParameter(storedProcCommand, "@PrintBroker", DbType.Decimal, item.PrintBroker);
            database.AddInParameter(storedProcCommand, "@Inks", DbType.Decimal, item.Inks);
            database.AddInParameter(storedProcCommand, "@InventoryItems", DbType.Decimal, item.InventoryItems);
            database.AddInParameter(storedProcCommand, "@OtherCosts", DbType.Decimal, item.OtherCosts);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Decimal, item.DeliveryCost);
            database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, item.MarkupID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
            database.AddInParameter(storedProcCommand, "@RoundUpTotals", DbType.Boolean, item.RoundUpTotals);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_system_markup_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_system_markup_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_system_markup_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_system_markup_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@SystemMarkupID", DbType.Int32, item.SystemMarkupID);
            database.AddInParameter(storedProcCommand, "@Paper", DbType.Decimal, item.Paper);
            database.AddInParameter(storedProcCommand, "@PrintBroker", DbType.Decimal, item.PrintBroker);
            database.AddInParameter(storedProcCommand, "@Inks", DbType.Decimal, item.Inks);
            database.AddInParameter(storedProcCommand, "@InventoryItems", DbType.Decimal, item.InventoryItems);
            database.AddInParameter(storedProcCommand, "@OtherCosts", DbType.Decimal, item.OtherCosts);
            database.AddInParameter(storedProcCommand, "@DeliveryCost", DbType.Decimal, item.DeliveryCost);
            database.AddInParameter(storedProcCommand, "@MarkupID", DbType.Int32, item.MarkupID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
            database.AddInParameter(storedProcCommand, "@RoundUpTotals", DbType.Boolean, item.RoundUpTotals);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_taborder_update(int CompanyID, int OrderNumber, int HeaderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taborder_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.Int32, OrderNumber);
            database.AddInParameter(storedProcCommand, "@HeaderID", DbType.Int32, HeaderID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_TaskSubject_delete(long SubjectId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_TaskSubject_delete");
            database.AddInParameter(storedProcCommand, "@SubjectId", DbType.Int64, SubjectId);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_TaskSubject_Insert(string Subject, long CompanyID, bool IsDefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_TaskSubject_Insert");
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Settings_TaskSubject_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_TaskSubject_Select");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Settings_TaskSubject_status_update(long SubjectId, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_TaskSubject_status_update");
            database.AddInParameter(storedProcCommand, "@SubjectId", DbType.Int64, SubjectId);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_TaskSubject_Update(long SubjectID, long CompanyID, string Subject, bool IsDefault)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_TaskSubject_Update");
            database.AddInParameter(storedProcCommand, "@SubjectId", DbType.Int64, SubjectID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_taxrate_delete(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.String, item.TaxID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_taxrate_delete_new(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_delete_new");
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.String, item.TaxID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_taxrate_insert(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxName", DbType.String, item.TaxName);
            database.AddInParameter(storedProcCommand, "@TaxRate", DbType.Decimal, item.TaxRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);

            database.AddInParameter(storedProcCommand, "@Alias", DbType.String, item.Alias);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_taxrate_insert_new(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxName", DbType.String, item.TaxName);
            database.AddInParameter(storedProcCommand, "@TaxRate", DbType.Decimal, item.TaxRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_taxrate_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_taxrate_selectbyID(int CompanyID, int TaxID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_selectbyID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, TaxID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_taxrate_update(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
            database.AddInParameter(storedProcCommand, "@TaxName", DbType.String, item.TaxName);
            database.AddInParameter(storedProcCommand, "@TaxRate", DbType.Decimal, item.TaxRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@Alias", DbType.String, item.Alias);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual int settings_taxrate_update_new(SettingsItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_taxrate_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@TaxID", DbType.Int32, item.TaxID);
            database.AddInParameter(storedProcCommand, "@TaxName", DbType.String, item.TaxName);
            database.AddInParameter(storedProcCommand, "@TaxRate", DbType.Decimal, item.TaxRate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual IDataReader settings_template(int CompanyID, string page)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_fields_select_new");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Page", DbType.String, page);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader settings_template_CustomerValue_select(int CompanyID, int CustomerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_customerValue_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, CustomerID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual void settings_template_Delete(int CompanyID, int TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_template_emailed_insert(string TemplateName, string TemplateKey, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_insert");
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string settings_template_emailed_select(string TemplateKey)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_select");
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual string settings_template_emailed_select_CompanyID(string TemplateKey)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_select_CompanyID");
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual string settings_template_emailed_select_GUID(string TemplateKey)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_select_GUID");
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void settings_template_emailed_update(string TemplateGUIDName, string TemplateKey)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_Update");
            database.AddInParameter(storedProcCommand, "@TemplateGUIDName", DbType.String, TemplateGUIDName);
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_template_field_category_selectall(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_template_field_category_selectall");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual IDataReader settings_template_FieldText_select(int CompanyID, string PageType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_FieldText_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader settings_template_FieldValue_select(int CompanyID, int EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_Allfields_value_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual DataSet Settings_Template_Group_Select(int ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_Group_Select");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Settings_Template_HGroup_Select(int ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_HGroup_Select");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual IDataReader settings_template_notes_values_select(int CompanyID, int DeliveryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_notes_Allfields_value_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@DeliveryID", DbType.Int32, DeliveryID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual void settings_template_pdf_delete(int CompanyID, long PDFID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_pdf_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int32, PDFID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual IDataReader settings_template_purchase_values_select(int CompanyID, int PurchaseID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_purchase_Allfields_value_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PurchaseID", DbType.Int32, PurchaseID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader settings_template_quantity_select(int CompanyID, int QuantityID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_quantity_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@QuantityID", DbType.Int32, QuantityID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader settings_template_select_byID(int CompanyID, int TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_select_byID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual void settings_template_update(int CompanyID, int TemplateID, string Name, string Description, string Contents, string ControlList, string ModuleName, bool IsDefault, long PDFID, decimal FooterSpace, decimal HeaderSpace, char ItemSplitStatus, bool isKeepWithPrevious, bool issplitsubitem, 
            bool isLocationBasedSorting, bool isGroupingBasedOnStock, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, Name);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@Contents", DbType.String, Contents);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
            database.AddInParameter(storedProcCommand, "@ControlList", DbType.String, ControlList);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int64, PDFID);
            database.AddInParameter(storedProcCommand, "@FooterSpace", DbType.Decimal, FooterSpace);
            database.AddInParameter(storedProcCommand, "@HeaderSpace", DbType.Decimal, HeaderSpace);
            database.AddInParameter(storedProcCommand, "@ItemSplitStatus", DbType.String, ItemSplitStatus);
            database.AddInParameter(storedProcCommand, "@isKeepWithPrevious", DbType.Boolean, isKeepWithPrevious);
            database.AddInParameter(storedProcCommand, "@isSplitSubitem", DbType.Boolean, issplitsubitem);
            database.AddInParameter(storedProcCommand, "@isLocationBasedSorting", DbType.Boolean, isLocationBasedSorting);
            database.AddInParameter(storedProcCommand, "@isGroupingBasedOnStockLocation", DbType.Boolean, isGroupingBasedOnStock);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_templatecategory_delete(int CompanyID, long CategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatecategory_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_templatecategory_insert(int CompanyID, string fieldName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatecategory_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@fieldName", DbType.String, fieldName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_templatecategory_select(int CompanyID, string fieldName, int fieldValue)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatecategory_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@fieldName", DbType.String, fieldName);
            database.AddInParameter(storedProcCommand, "@fieldValue", DbType.Int32, fieldValue);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        internal void settings_templatefield_Isdelete_update(int FieldID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatefield_Isdelete_Update");
            database.AddInParameter(storedProcCommand, "@FieldID", DbType.Int32, FieldID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_templatefield_order_number_update(int CompanyID, int FieldID, int OrderNumber, string FieldName, string FieldValue, string FieldText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatefield_order_number_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@FieldID", DbType.Int32, FieldID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.Int32, OrderNumber);
            database.AddInParameter(storedProcCommand, "@FieldName", DbType.String, FieldName);
            database.AddInParameter(storedProcCommand, "@FieldValue", DbType.String, FieldValue);
            database.AddInParameter(storedProcCommand, "@FieldText", DbType.String, FieldText);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_templatefield_properties_delete(int CompanyID, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatefield_properties_delete");
            storedProcCommand.CommandTimeout = 200;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void settings_templatefield_properties_insert(int CompanyID, long TemplateID, string objID, string objType, string objName, string type, string objValue, string imgsrc, string title, string align, string position, decimal top, decimal left, decimal width, decimal height, string zindex, string padding, string display, string overflow, string fontfamily, string fontsize, string fontweight, string fontstyle, string fontcolor, string textdecoration, string textalign, string border, string backgroundcolor, string visibility, string maxlength, string offsetwidth, string offsetheight, string offsettop, string offsetleft, string pixelwidth, string pixelheight, string pixeltop, string objlock, string canmove, string canchangefontcolor, string canchangefontsize, string canchangefont, string objclass, string onmouseoverclass, string objTag, string GroupID, string HGroupID, string AssociatedLabel, bool IsHGroupMain, string objrepeat)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatefield_properties_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            database.AddInParameter(storedProcCommand, "@objID", DbType.String, objID);
            database.AddInParameter(storedProcCommand, "@objType", DbType.String, objType);
            database.AddInParameter(storedProcCommand, "@objName", DbType.String, objName);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@objValue", DbType.String, objValue);
            database.AddInParameter(storedProcCommand, "@imgsrc", DbType.String, imgsrc);
            database.AddInParameter(storedProcCommand, "@title", DbType.String, title);
            database.AddInParameter(storedProcCommand, "@align", DbType.String, align);
            database.AddInParameter(storedProcCommand, "@position", DbType.String, position);
            database.AddInParameter(storedProcCommand, "@top", DbType.Decimal, top);
            database.AddInParameter(storedProcCommand, "@left", DbType.Decimal, left);
            database.AddInParameter(storedProcCommand, "@width", DbType.Decimal, width);
            database.AddInParameter(storedProcCommand, "@height", DbType.Decimal, height);
            database.AddInParameter(storedProcCommand, "@zindex", DbType.String, zindex);
            database.AddInParameter(storedProcCommand, "@padding", DbType.String, padding);
            database.AddInParameter(storedProcCommand, "@display", DbType.String, display);
            database.AddInParameter(storedProcCommand, "@overflow", DbType.String, overflow);
            database.AddInParameter(storedProcCommand, "@fontfamily", DbType.String, fontfamily);
            database.AddInParameter(storedProcCommand, "@fontsize", DbType.String, fontsize);
            database.AddInParameter(storedProcCommand, "@fontweight", DbType.String, fontweight);
            database.AddInParameter(storedProcCommand, "@fontstyle", DbType.String, fontstyle);
            database.AddInParameter(storedProcCommand, "@fontcolor", DbType.String, fontcolor);
            database.AddInParameter(storedProcCommand, "@textdecoration", DbType.String, textdecoration);
            database.AddInParameter(storedProcCommand, "@textalign", DbType.String, textalign);
            database.AddInParameter(storedProcCommand, "@border", DbType.String, border);
            database.AddInParameter(storedProcCommand, "@backgroundcolor", DbType.String, backgroundcolor);
            database.AddInParameter(storedProcCommand, "@visibility", DbType.String, visibility);
            database.AddInParameter(storedProcCommand, "@maxlength", DbType.String, maxlength);
            database.AddInParameter(storedProcCommand, "@offsetwidth", DbType.String, offsetwidth);
            database.AddInParameter(storedProcCommand, "@offsetheight", DbType.String, offsetheight);
            database.AddInParameter(storedProcCommand, "@offsettop", DbType.String, offsettop);
            database.AddInParameter(storedProcCommand, "@offsetleft", DbType.String, offsetleft);
            database.AddInParameter(storedProcCommand, "@pixelwidth", DbType.String, pixelwidth);
            database.AddInParameter(storedProcCommand, "@pixelheight", DbType.String, pixelheight);
            database.AddInParameter(storedProcCommand, "@pixeltop", DbType.String, pixeltop);
            database.AddInParameter(storedProcCommand, "@lock", DbType.String, objlock);
            database.AddInParameter(storedProcCommand, "@canmove", DbType.String, canmove);
            database.AddInParameter(storedProcCommand, "@canchangefontcolor", DbType.String, canchangefontcolor);
            database.AddInParameter(storedProcCommand, "@canchangefontsize", DbType.String, canchangefontsize);
            database.AddInParameter(storedProcCommand, "@canchangefont", DbType.String, canchangefont);
            database.AddInParameter(storedProcCommand, "@class", DbType.String, objclass);
            database.AddInParameter(storedProcCommand, "@onmouseoverclass", DbType.String, onmouseoverclass);
            database.AddInParameter(storedProcCommand, "@objTag", DbType.String, objTag);
            int num = 0;
            if (GroupID.Length > 0)
            {
                try
                {
                    num = Convert.ToInt32(GroupID);
                }
                catch
                {
                    num = 0;
                }
            }
            database.AddInParameter(storedProcCommand, "@GroupID", DbType.Int32, num);
            int num1 = 0;
            if (HGroupID.Length > 0)
            {
                try
                {
                    num1 = Convert.ToInt32(HGroupID);
                }
                catch
                {
                    num1 = 0;
                }
            }
            database.AddInParameter(storedProcCommand, "@HGroupID", DbType.Int32, num1);
            database.AddInParameter(storedProcCommand, "@AssociatedLabel", DbType.String, AssociatedLabel);
            database.AddInParameter(storedProcCommand, "@IsHGroupMain", DbType.Boolean, IsHGroupMain);
            database.AddInParameter(storedProcCommand, "@Repeat", DbType.String, objrepeat);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_templatefield_properties_select(int CompanyID, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_email_phrasebook_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.String, TemplateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_templatefield_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatefield_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_templatefieldadd_Delete(int CompanyID, int fieldID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_templatefield_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@fieldID", DbType.Int32, fieldID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_templates_associatelabel_select(int TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_associatelabel_select");
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int32, TemplateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_templates_checkDuplicate(int CompanyID, string TemplateName, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_duplicateCheck");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_templates_emailed_insert(string TemplateName, string TemplateKey)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_emailed_insert");
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@TemplateKey", DbType.String, TemplateKey);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_templates_groups_copy(long CompanyID, long OldTemplateID, long NewTemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_groups_copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldTemplateID", DbType.Int64, OldTemplateID);
            database.AddInParameter(storedProcCommand, "@NewTemplateID", DbType.Int64, NewTemplateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_templates_Hgroups_copy(long CompanyID, long OldTemplateID, long NewTemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_Hgroups_copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OldTemplateID", DbType.Int64, OldTemplateID);
            database.AddInParameter(storedProcCommand, "@NewTemplateID", DbType.Int64, NewTemplateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long settings_templates_insert(int CompanyID, string Name, string Description, string Contents, string ControlList, string ModuleName, bool IsDefault, long PDFID, decimal FooterSpace, decimal HeaderSpace, char ItemSplitStatus, bool isKeepWithPrevious, bool isSplitSubitem, bool isLocationBasedSorting
            , bool isGroupingBasedStockLocation)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_template_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, Name);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@Contents", DbType.String, Contents);
            database.AddInParameter(storedProcCommand, "@ControlList", DbType.String, ControlList);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int64, PDFID);
            database.AddInParameter(storedProcCommand, "@FooterSpace", DbType.Decimal, FooterSpace);
            database.AddInParameter(storedProcCommand, "@HeaderSpace", DbType.Decimal, HeaderSpace);
            database.AddInParameter(storedProcCommand, "@ItemSplitStatus", DbType.String, ItemSplitStatus);
            database.AddInParameter(storedProcCommand, "@isKeepWithPrevious", DbType.Boolean, isKeepWithPrevious);
            database.AddInParameter(storedProcCommand, "@isSplitSubitem", DbType.Boolean, isSplitSubitem);
            database.AddInParameter(storedProcCommand, "@isLocationBasedSorting", DbType.Boolean, isLocationBasedSorting);
            database.AddInParameter(storedProcCommand, "@isGroupingBasedOnStockLocation", DbType.Boolean, isGroupingBasedStockLocation);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_templates_properties_select(int COmpanyID, long TemplateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_properties_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, COmpanyID);
            database.AddInParameter(storedProcCommand, "@TemplateID", DbType.Int64, TemplateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_templates_properties_update(int CompanyID, long TemplatePropertiesID, string align, decimal top, decimal left, decimal width, decimal height, string fontfamily, string fontsize, string GroupID, string HGroupID, string AssociatedLabel, bool IsHGroupMain, bool IsLock)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_properties_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@TemplatePropertiesID", DbType.Int64, TemplatePropertiesID);
            database.AddInParameter(storedProcCommand, "@align", DbType.String, align);
            database.AddInParameter(storedProcCommand, "@top", DbType.Decimal, top);
            database.AddInParameter(storedProcCommand, "@left", DbType.Decimal, left);
            database.AddInParameter(storedProcCommand, "@width", DbType.Decimal, width);
            database.AddInParameter(storedProcCommand, "@height", DbType.Decimal, height);
            database.AddInParameter(storedProcCommand, "@fontfamily", DbType.String, fontfamily);
            database.AddInParameter(storedProcCommand, "@fontsize", DbType.String, fontsize);
            database.AddInParameter(storedProcCommand, "@GroupID", DbType.Int32, Convert.ToInt64(GroupID));
            database.AddInParameter(storedProcCommand, "@HGroupID", DbType.Int32, Convert.ToInt64(HGroupID));
            database.AddInParameter(storedProcCommand, "@AssociatedLabel", DbType.String, AssociatedLabel);
            database.AddInParameter(storedProcCommand, "@IsHGroupMain", DbType.Boolean, IsHGroupMain);
            database.AddInParameter(storedProcCommand, "@IsLock", DbType.Boolean, IsLock);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_templates_select(int COmpanyID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templates_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, COmpanyID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_templatesfields_select(int CompanyID, int CategoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_templatesfields_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@categoryID", DbType.String, CategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settings_templatespdf_insert(int CompanyID, long PDFID, string PDFTitle, string PDFName, string PDFKey, string ReportFileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_templatespdf_insert]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PDFID", DbType.Int64, PDFID);
            database.AddInParameter(storedProcCommand, "@PDFTitle", DbType.String, PDFTitle);
            database.AddInParameter(storedProcCommand, "@PDFName", DbType.String, PDFName);
            database.AddInParameter(storedProcCommand, "@PDFKey", DbType.String, PDFKey);
            database.AddInParameter(storedProcCommand, "@ReportFileName", DbType.String, ReportFileName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_templatespdf_pages_insert(int ID, int FirstPageNumber, int LastPageNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TemplatesPDFtc_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@TemplatePDFID", DbType.Int32, ID);
            database.AddInParameter(storedProcCommand, "@FirstPageNo", DbType.Int32, FirstPageNumber);
            database.AddInParameter(storedProcCommand, "@LastPageNo", DbType.Int32, LastPageNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_titlecode_fortemplate_select(int CompanyID, long ModuleID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_titlecode_fortemplate_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@EstimateitemIDs", DbType.String, "");
            //storedProcCommand.CommandTimeout = 120;
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable settings_get_internal_email_template_values(int CompanyID, long ModuleID,string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_get_internal_email_template_values");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            //storedProcCommand.CommandTimeout = 120;
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable settings_titlecode_fortemplate_select(int CompanyID, long ModuleID, string ModuleName, string Items)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_titlecode_fortemplate_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@EstimateitemIDs", DbType.String, Items);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_proof_template_select(int CompanyID, long ModuleID, string Items)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProofTemplateSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@EstimateitemIDs", DbType.String, Items);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_titlecode_fortemplate_select_Item(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobAlertEmail_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateitemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_titlecode_fortemplate_select_Item_delivery(int CompanyID, long Deliveryid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DelAlertEmail_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@deliveryID", DbType.Int64, Deliveryid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Settings_Update_Alert_Notification_settings(int AlertID, long CompanyID, long UserID, string TemplateName, string Subject, string Body)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Update_Alert_Notification_settings");
            database.AddInParameter(storedProcCommand, "@AlertID", DbType.Int32, AlertID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Update_Alert_Setting(long CompanyID, long UserID, bool isShowTaskAlertonScreen, int ShowTaskAlertOnScreenTime, bool isShowCallAlertOnScreen, int ShowCallAlertOnScreenTime, bool isSendTaskAlert, int SendTaskAlertTime, bool isSendCallAlert, int SendCallAlertTime, int CreatedBy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_Alert_Setting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@isShowTaskAlertonScreen", DbType.Boolean, isShowTaskAlertonScreen);
            database.AddInParameter(storedProcCommand, "@ShowTaskAlertOnScreenTime", DbType.Int32, ShowTaskAlertOnScreenTime);
            database.AddInParameter(storedProcCommand, "@isShowCallAlertOnScreen", DbType.Boolean, isShowCallAlertOnScreen);
            database.AddInParameter(storedProcCommand, "@ShowCallAlertOnScreenTime", DbType.Int32, ShowCallAlertOnScreenTime);
            database.AddInParameter(storedProcCommand, "@isSendTaskAlert", DbType.Boolean, isSendTaskAlert);
            database.AddInParameter(storedProcCommand, "@SendTaskAlertTime", DbType.Int32, SendTaskAlertTime);
            database.AddInParameter(storedProcCommand, "@isSendCallAlert", DbType.Boolean, isSendCallAlert);
            database.AddInParameter(storedProcCommand, "@SendCallAlertTime", DbType.Int32, SendCallAlertTime);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Update_Alert_Settings(long CompanyID, long UserID, string TasksAlert, int TasksAlertMinute, string TasksAlertFor, string EventAlert, int EventAlertMinute, string EventAlertFor, string CallAlert, int CallAlertMinute, string CallAlertFor, int CreatedBy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_Alert_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@TasksAlert", DbType.String, TasksAlert);
            database.AddInParameter(storedProcCommand, "@TasksAlertMinute", DbType.Int32, TasksAlertMinute);
            database.AddInParameter(storedProcCommand, "@TasksAlertFor", DbType.String, TasksAlertFor);
            database.AddInParameter(storedProcCommand, "@EventAlert", DbType.String, EventAlert);
            database.AddInParameter(storedProcCommand, "@EventAlertMinute", DbType.Int32, EventAlertMinute);
            database.AddInParameter(storedProcCommand, "@EventAlertFor", DbType.String, EventAlertFor);
            database.AddInParameter(storedProcCommand, "@CallAlert", DbType.String, CallAlert);
            database.AddInParameter(storedProcCommand, "@CallAlertMinute", DbType.Int32, CallAlertMinute);
            database.AddInParameter(storedProcCommand, "@CallAlertFor", DbType.String, CallAlertFor);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Update_CopyWidgets(long ID, long CopyMasterID, long CompanyID, string UserID, string DateType, bool IncludeArchiverecords, bool IsDisplayWidget, string Color, string Title, string IsCalendarYear, string FromDate, string ToDate, DailyTarget dailyTarget, MonthlyTarget monthlyTarget)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Update_MiniUserdWidgets");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int64, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludeArchiverecords", DbType.Boolean, IncludeArchiverecords);
            database.AddInParameter(storedProcCommand, "@IsDisplayWidget", DbType.Boolean, IsDisplayWidget);
            database.AddInParameter(storedProcCommand, "@Color", DbType.String, Color);
            database.AddInParameter(storedProcCommand, "@Title", DbType.String, Title);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);

            database.AddInParameter(storedProcCommand, "@MonthlyTarget1", DbType.Currency, monthlyTarget.MonthlyTarget1);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget2", DbType.Currency, monthlyTarget.MonthlyTarget2);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget3", DbType.Currency, monthlyTarget.MonthlyTarget3);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget4", DbType.Currency, monthlyTarget.MonthlyTarget4);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget5", DbType.Currency, monthlyTarget.MonthlyTarget5);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget6", DbType.Currency, monthlyTarget.MonthlyTarget6);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget7", DbType.Currency, monthlyTarget.MonthlyTarget7);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget8", DbType.Currency, monthlyTarget.MonthlyTarget8);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget9", DbType.Currency, monthlyTarget.MonthlyTarget9);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget10", DbType.Currency, monthlyTarget.MonthlyTarget10);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget11", DbType.Currency, monthlyTarget.MonthlyTarget11);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget12", DbType.Currency, monthlyTarget.MonthlyTarget12);

            database.AddInParameter(storedProcCommand, "@DailyTarget1", DbType.Currency, dailyTarget.DailyTarget1);
            database.AddInParameter(storedProcCommand, "@DailyTarget2", DbType.Currency, dailyTarget.DailyTarget2);
            database.AddInParameter(storedProcCommand, "@DailyTarget3", DbType.Currency, dailyTarget.DailyTarget3);
            database.AddInParameter(storedProcCommand, "@DailyTarget4", DbType.Currency, dailyTarget.DailyTarget4);
            database.AddInParameter(storedProcCommand, "@DailyTarget5", DbType.Currency, dailyTarget.DailyTarget5);
            database.AddInParameter(storedProcCommand, "@DailyTarget6", DbType.Currency, dailyTarget.DailyTarget6);
            database.AddInParameter(storedProcCommand, "@DailyTarget7", DbType.Currency, dailyTarget.DailyTarget7);
            database.AddInParameter(storedProcCommand, "@DailyTarget8", DbType.Currency, dailyTarget.DailyTarget8);
            database.AddInParameter(storedProcCommand, "@DailyTarget9", DbType.Currency, dailyTarget.DailyTarget9);
            database.AddInParameter(storedProcCommand, "@DailyTarget10", DbType.Currency, dailyTarget.DailyTarget10);
            database.AddInParameter(storedProcCommand, "@DailyTarget11", DbType.Currency, dailyTarget.DailyTarget11);
            database.AddInParameter(storedProcCommand, "@DailyTarget12", DbType.Currency, dailyTarget.DailyTarget12);
            database.AddInParameter(storedProcCommand, "@DailyTarget13", DbType.Currency, dailyTarget.DailyTarget13);
            database.AddInParameter(storedProcCommand, "@DailyTarget14", DbType.Currency, dailyTarget.DailyTarget14);
            database.AddInParameter(storedProcCommand, "@DailyTarget15", DbType.Currency, dailyTarget.DailyTarget15);
            database.AddInParameter(storedProcCommand, "@DailyTarget16", DbType.Currency, dailyTarget.DailyTarget16);
            database.AddInParameter(storedProcCommand, "@DailyTarget17", DbType.Currency, dailyTarget.DailyTarget17);
            database.AddInParameter(storedProcCommand, "@DailyTarget18", DbType.Currency, dailyTarget.DailyTarget18);
            database.AddInParameter(storedProcCommand, "@DailyTarget19", DbType.Currency, dailyTarget.DailyTarget19);
            database.AddInParameter(storedProcCommand, "@DailyTarget20", DbType.Currency, dailyTarget.DailyTarget20);
            database.AddInParameter(storedProcCommand, "@DailyTarget21", DbType.Currency, dailyTarget.DailyTarget21);
            database.AddInParameter(storedProcCommand, "@DailyTarget22", DbType.Currency, dailyTarget.DailyTarget22);
            database.AddInParameter(storedProcCommand, "@DailyTarget23", DbType.Currency, dailyTarget.DailyTarget23);
            database.AddInParameter(storedProcCommand, "@DailyTarget24", DbType.Currency, dailyTarget.DailyTarget24);
            database.AddInParameter(storedProcCommand, "@DailyTarget25", DbType.Currency, dailyTarget.DailyTarget25);
            database.AddInParameter(storedProcCommand, "@DailyTarget26", DbType.Currency, dailyTarget.DailyTarget26);
            database.AddInParameter(storedProcCommand, "@DailyTarget27", DbType.Currency, dailyTarget.DailyTarget27);
            database.AddInParameter(storedProcCommand, "@DailyTarget28", DbType.Currency, dailyTarget.DailyTarget28);
            database.AddInParameter(storedProcCommand, "@DailyTarget29", DbType.Currency, dailyTarget.DailyTarget29);
            database.AddInParameter(storedProcCommand, "@DailyTarget30", DbType.Currency, dailyTarget.DailyTarget30);
            database.AddInParameter(storedProcCommand, "@DailyTarget31", DbType.Currency, dailyTarget.DailyTarget31);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Update_CopyWidgets(int CopyMasterID, int CompanyID, int UserID, string WidgetType, int DefaultDate, int ShowPrint, string TitleName, string WidgetName, string DisplayType, string GraphType, int LastUpdatedBy, string ModuleName, int NoOfRecords, string Customizecolumns, int Customerid, bool isSpread, string TaskStatus, string CompanyType, string DisplayRecordSalesOf, string QuarterType, string FromDate, string Todate, string EstimateType, bool ShowFullScreen, bool ShowAllOptions, string Status, bool ShowArchivedStatus,string IsCalendarYear,string DateType,bool IsLastYearData=false, bool IsDailyTarget = false, bool IsMonthlyTarget = false)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Update_CopyWidgets");
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.Int32, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@WidgetType", DbType.String, WidgetType);
            database.AddInParameter(storedProcCommand, "@DefaultDate", DbType.Int32, DefaultDate);
            database.AddInParameter(storedProcCommand, "@ShowPrint", DbType.Int32, ShowPrint);
            database.AddInParameter(storedProcCommand, "@TitleName", DbType.String, TitleName);
            database.AddInParameter(storedProcCommand, "@WidgetName", DbType.String, WidgetName);
            database.AddInParameter(storedProcCommand, "@DisplayType", DbType.String, DisplayType);
            database.AddInParameter(storedProcCommand, "@GraphType", DbType.String, GraphType);
            database.AddInParameter(storedProcCommand, "@LastUpdatedBy", DbType.Int32, LastUpdatedBy);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            database.AddInParameter(storedProcCommand, "@CustomizeColumns", DbType.String, Customizecolumns);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int32, Customerid);
            database.AddInParameter(storedProcCommand, "@IsSpreadOverTwoColumns", DbType.Boolean, isSpread);
            database.AddInParameter(storedProcCommand, "@TaskStatus", DbType.String, TaskStatus);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@DisplayRecordSalesOf", DbType.String, DisplayRecordSalesOf);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.String, Todate);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@ShowFullScreen", DbType.Boolean, ShowFullScreen);
            database.AddInParameter(storedProcCommand, "@ShowAllOptions", DbType.Boolean, ShowAllOptions);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ShowArchivedStatus", DbType.Boolean, ShowArchivedStatus);

            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IsLastYearData", DbType.Boolean, IsLastYearData);
            database.AddInParameter(storedProcCommand, "@IsDailyTarget", DbType.Boolean, IsDailyTarget);
            database.AddInParameter(storedProcCommand, "@IsMonthlyTarget", DbType.Boolean, IsMonthlyTarget);


            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual bool settings_user_access_rights_check(int CompanyID, int UserID, string Module, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_user_access_rights");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Settings_user_check_isadmin(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_user_check_isadmin");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetTrackingOPtions(Int32 Id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TrackingOptions_Get");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int32, Id);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void DeleteTrackingOPtions(Int32 Id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TrackingOptions_Delete");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int32, Id);
            database.ExecuteNonQuery(storedProcCommand);

        }

        public virtual DataTable SaveUpdateTrackingOPtions(Int32 Id, string TrackingOption, string Description)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TrackingOptions_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int32, Id);
            database.AddInParameter(storedProcCommand, "@TrackingOption", DbType.String, TrackingOption);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }


        public virtual void settings_user_delete(int companyid, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int settings_user_insert(int companyID, string email, string name, string password, int usertype, string description, bool disable, string createddate, string phone, string Mobile, string Fax, string defaultlanding, bool IsActivateUserForSalesTargets, string UserImage, string JobTitle, Int32 LocationId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_insert_New");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, email);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, name);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, password);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.Int32, usertype);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@Disable", DbType.Boolean, disable);
            database.AddInParameter(storedProcCommand, "@phone", DbType.String, phone);
            database.AddInParameter(storedProcCommand, "@Mobile", DbType.String, Mobile);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@DefaultLanding", DbType.String, defaultlanding);
            database.AddInParameter(storedProcCommand, "@IsActivateUserForSalesTargets", DbType.Boolean, IsActivateUserForSalesTargets);
            database.AddInParameter(storedProcCommand, "@UserImage", DbType.String, UserImage);
            database.AddInParameter(storedProcCommand, "@JobTitle", DbType.String, JobTitle);
            database.AddInParameter(storedProcCommand, "@TrackingOptionId", DbType.Int32, LocationId);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void settings_user_password_update(int companyID, int userid, string password)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_userEmialPassword");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, password);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_user_profile_update(int companyID, int userid, string name, string description, string phone, string Mobile, string Fax, string defaultlanding, string UserImage, string JobTitle)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_userProfile_Edit");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, name);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@Phone", DbType.String, phone);
            database.AddInParameter(storedProcCommand, "@Mobile", DbType.String, Mobile);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@DefaultLanding", DbType.String, defaultlanding);
            database.AddInParameter(storedProcCommand, "@UserImage", DbType.String, UserImage);
            database.AddInParameter(storedProcCommand, "@JobTitle", DbType.String, JobTitle);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_user_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_user_select_forddl(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_user_update(int companyID, int userid, string email, string name, string password, int usertype, string description, bool disable, string phone, string Mobile, string Fax, string defaultlanding, bool IsActivateUserForSalesTargets, string UserImage, string JobTitle, Int32 TrackingOptionId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_update_New");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, email);
            database.AddInParameter(storedProcCommand, "@Name", DbType.String, name);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, password);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.Int32, usertype);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@Disable", DbType.Boolean, disable);
            database.AddInParameter(storedProcCommand, "@Phone", DbType.String, phone);
            database.AddInParameter(storedProcCommand, "@Mobile", DbType.String, Mobile);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@DefaultLanding", DbType.String, defaultlanding);
            database.AddInParameter(storedProcCommand, "@IsActivateUserForSalesTargets", DbType.Boolean, IsActivateUserForSalesTargets);
            database.AddInParameter(storedProcCommand, "@UserImage", DbType.String, UserImage);
            database.AddInParameter(storedProcCommand, "@JobTitle", DbType.String, JobTitle);
            database.AddInParameter(storedProcCommand, "@TrackingOptionId", DbType.Int32, TrackingOptionId);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string Settings_UserImage_Select(long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_UserImage_Select");
            storedProcCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int settings_usermailduplicacy_check(int CompanyID, string PlantPressType, string PlantPressName, long PlantpressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_usermailduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PlantPressType", DbType.String, PlantPressType);
            database.AddInParameter(storedProcCommand, "@PlantPressName", DbType.String, PlantPressName);
            database.AddInParameter(storedProcCommand, "@PlantpressID", DbType.Int64, PlantpressID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable settings_userrole_select(int CompanyID, DropDownList ddl)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_user_role_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_userTab_display_update(string TabName, int IsDisplay)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_userTab_display_update");
            database.AddInParameter(storedProcCommand, "@userTab", DbType.String, TabName);
            database.AddInParameter(storedProcCommand, "@IsDisplay", DbType.Int32, IsDisplay);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_webstoreothercost_order_number_update(int CompanyID, int WebOtherCostID, int OrderNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_websroreothercost_order_number_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, WebOtherCostID);
            database.AddInParameter(storedProcCommand, "@OrderNumber", DbType.Int32, OrderNumber);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable SubAdditional_Option_Select(int companyid, long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionOptions_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void system_autoDeliveryalert_email(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_autodeliveryalert_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@FooterID", DbType.Int32, FooterID);
            database.AddInParameter(storedProcCommand, "@IsEnabled", DbType.Int32, IsEnabled);
            database.AddInParameter(storedProcCommand, "@CC", DbType.String, CC);
            database.AddInParameter(storedProcCommand, "@BCC", DbType.String, BCC);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int32, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable system_autojobalert(int CompanyID, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Autojobalert_selectedRow");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void system_autojobalert_email(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_autojobalert_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@FooterID", DbType.Int32, FooterID);
            database.AddInParameter(storedProcCommand, "@IsEnabled", DbType.Int32, IsEnabled);
            database.AddInParameter(storedProcCommand, "@CC", DbType.String, CC);
            database.AddInParameter(storedProcCommand, "@BCC", DbType.String, BCC);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int32, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void system_auto_internal_alert(int CompanyID, int UserID, int StatusID, string Subject, string Body, int FooterID, int IsEnabled, string CC, string BCC,string EmailTo,string EmailType, int EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_auto_internal_alert_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@FooterID", DbType.Int32, FooterID);
            database.AddInParameter(storedProcCommand, "@IsEnabled", DbType.Int32, IsEnabled);
            database.AddInParameter(storedProcCommand, "@CC", DbType.String, CC);
            database.AddInParameter(storedProcCommand, "@BCC", DbType.String, BCC);
            database.AddInParameter(storedProcCommand, "@EmailTo", DbType.String, EmailTo);
            database.AddInParameter(storedProcCommand, "@EmailType", DbType.String, EmailType);

            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int32, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual string system_default_settings(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_default_settings_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual DataTable template_email_phrasebook_select(int CompanyID, string PhraseType, string EmailTemplateType, string SelectType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_email_phrasebook_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            database.AddInParameter(storedProcCommand, "@EmailTemplateType", DbType.String, EmailTemplateType);
            database.AddInParameter(storedProcCommand, "@SelectType", DbType.String, SelectType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Template_Group_Update(int ID, string GroupName, bool IsAuto)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_template_Group_Update");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
            database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
            database.AddInParameter(storedProcCommand, "@IsAuto", DbType.String, IsAuto);
            database.ExecuteScalar(storedProcCommand);
            return 0;
        }

        public virtual int Template_HGroup_Update(int ID, string GroupName, bool isDeleteAllIfMainisBlank)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Template_HGroup_Update");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, ID);
            database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
            database.AddInParameter(storedProcCommand, "@isDeleteAllIfMainisBlank", DbType.Decimal, isDeleteAllIfMainisBlank);
            database.ExecuteScalar(storedProcCommand);
            return 0;
        }

        public virtual void Unauth_Access_EmailBody_delete(long EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Unauth_Access_EmailBody_Delete  ");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Unauth_Access_EmailBody_Details(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Unauth_Access_EmailBody_Details");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Unauth_Access_EmailBody_insert(long CompanyID, long UserID, string TemplateName, string Subject, string Body, int FooterID, bool IsDefault, long EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_UnthorisedAccess_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@TemplateName", DbType.String, TemplateName);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@FooterID", DbType.Int32, FooterID);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Boolean, IsDefault);
            database.AddInParameter(storedProcCommand, "@EmailId", DbType.Int32, EmailID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Unauth_Access_EmailBody_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Unauth_Access_EmailBody_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Unauth_Access_EmailBody_selectedrow(long EmailID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Unauth_Access_EmailBody_SelectedRow");
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.Int64, EmailID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_settings_TemNameLastCounter(int CompanyID, long ModuleID, string ModuleName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_settings_TemNameLastCounter");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateCategory(long CompanyID, long CategoryID, string CategoryName, string Description, long parentId, string CategoryImage, long UserID, string UserType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateImageCategory");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, CategoryName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@ParentID", DbType.Int64, parentId);
            database.AddInParameter(storedProcCommand, "@CategoryImage", DbType.String, CategoryImage);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@UserType", DbType.String, UserType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateImageDetails(long ImageID, long CompanyID, long CategoryID, long UserID, string OriginalFileName, string newfilename, string Description, string MetaTag)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_GalleryImages_Update");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, ImageID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, newfilename);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MetaTags", DbType.String, MetaTag);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateImageGallery(long ImageID, long CompanyID, string OriginalFileName, string Description, string MetaTag)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateImageGallery");
            database.AddInParameter(storedProcCommand, "@ImageID", DbType.Int64, ImageID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@MetaTags", DbType.String, MetaTag);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateImageName(int New_PriceCatalogueID, string ControlID, string _newimgname)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("et_UpdateImageNameFor_Copy");
            database.AddInParameter(storedProcCommand, "@New_PriceCatalogueID", DbType.Int32, New_PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@ObjectID", DbType.String, ControlID);
            database.AddInParameter(storedProcCommand, "@ImageUrl", DbType.String, _newimgname);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateSelectedAccountID(long USerID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_AccountID");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, USerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable User_IsValid_Select(string Email, string Password)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_User_IsValid_Select");
            database.AddInParameter(storedProcCommand, "@email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@password", DbType.String, Password);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int user_profile_userTypeId_Select(int companyID, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_userTypeId");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string view_Default_select(string PageName, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_view_Default_select");
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            return database.ExecuteScalar(storedProcCommand).ToString();
        }

        public virtual void ScanningStockHistory_InsertOrUpdate(long Id, long CompanyID, string JobOrPoCode, Int32 Qty, string ItemCode,Int32 PriceCatalogueStockId, Int32 EstimateItemId, Int32 PurchaseItemId, Boolean Status, String ErrorMessage, Int32 UserId,string FileName,DateTime Date)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ScanningStockHistory_InsertOrUpdate");
            database.AddInParameter(storedProcCommand, "@Id", DbType.Int64, Id);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobOrPoCode", DbType.String, JobOrPoCode);
            database.AddInParameter(storedProcCommand, "@Qty", DbType.Int32, Qty);
            database.AddInParameter(storedProcCommand, "@ItemCode", DbType.String, ItemCode);

            database.AddInParameter(storedProcCommand, "@PriceCatalogueStockId", DbType.Int32, PriceCatalogueStockId);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int32, EstimateItemId);
            database.AddInParameter(storedProcCommand, "@PurchaseItemId", DbType.Int32, PurchaseItemId);
            database.AddInParameter(storedProcCommand, "@Status", DbType.Byte, Status);

            database.AddInParameter(storedProcCommand, "@ErrorMessage", DbType.String, ErrorMessage);
            database.AddInParameter(storedProcCommand, "@UserId", DbType.Int32, UserId);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@Date", DbType.DateTime, Date);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable ScanningStockHistory_Select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ScanningStockHistory_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void Settings_Save_Targets(long CompanyID, int UserID, string DataType,DailyTarget dailyTarget, MonthlyTarget monthlyTarget)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Settings_Insert_Targets");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@DataType", DbType.String, DataType);
          
            database.AddInParameter(storedProcCommand, "@MonthlyTarget1", DbType.Currency, monthlyTarget.MonthlyTarget1);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget2", DbType.Currency, monthlyTarget.MonthlyTarget2);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget3", DbType.Currency, monthlyTarget.MonthlyTarget3);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget4", DbType.Currency, monthlyTarget.MonthlyTarget4);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget5", DbType.Currency, monthlyTarget.MonthlyTarget5);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget6", DbType.Currency, monthlyTarget.MonthlyTarget6);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget7", DbType.Currency, monthlyTarget.MonthlyTarget7);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget8", DbType.Currency, monthlyTarget.MonthlyTarget8);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget9", DbType.Currency, monthlyTarget.MonthlyTarget9);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget10", DbType.Currency, monthlyTarget.MonthlyTarget10);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget11", DbType.Currency, monthlyTarget.MonthlyTarget11);
            database.AddInParameter(storedProcCommand, "@MonthlyTarget12", DbType.Currency, monthlyTarget.MonthlyTarget12);

            database.AddInParameter(storedProcCommand, "@DailyTarget1", DbType.Currency, dailyTarget.DailyTarget1);
            database.AddInParameter(storedProcCommand, "@DailyTarget2", DbType.Currency, dailyTarget.DailyTarget2);
            database.AddInParameter(storedProcCommand, "@DailyTarget3", DbType.Currency, dailyTarget.DailyTarget3);
            database.AddInParameter(storedProcCommand, "@DailyTarget4", DbType.Currency, dailyTarget.DailyTarget4);
            database.AddInParameter(storedProcCommand, "@DailyTarget5", DbType.Currency, dailyTarget.DailyTarget5);
            database.AddInParameter(storedProcCommand, "@DailyTarget6", DbType.Currency, dailyTarget.DailyTarget6);
            database.AddInParameter(storedProcCommand, "@DailyTarget7", DbType.Currency, dailyTarget.DailyTarget7);
            database.AddInParameter(storedProcCommand, "@DailyTarget8", DbType.Currency, dailyTarget.DailyTarget8);
            database.AddInParameter(storedProcCommand, "@DailyTarget9", DbType.Currency, dailyTarget.DailyTarget9);
            database.AddInParameter(storedProcCommand, "@DailyTarget10", DbType.Currency, dailyTarget.DailyTarget10);
            database.AddInParameter(storedProcCommand, "@DailyTarget11", DbType.Currency, dailyTarget.DailyTarget11);
            database.AddInParameter(storedProcCommand, "@DailyTarget12", DbType.Currency, dailyTarget.DailyTarget12);
            database.AddInParameter(storedProcCommand, "@DailyTarget13", DbType.Currency, dailyTarget.DailyTarget13);
            database.AddInParameter(storedProcCommand, "@DailyTarget14", DbType.Currency, dailyTarget.DailyTarget14);
            database.AddInParameter(storedProcCommand, "@DailyTarget15", DbType.Currency, dailyTarget.DailyTarget15);
            database.AddInParameter(storedProcCommand, "@DailyTarget16", DbType.Currency, dailyTarget.DailyTarget16);
            database.AddInParameter(storedProcCommand, "@DailyTarget17", DbType.Currency, dailyTarget.DailyTarget17);
            database.AddInParameter(storedProcCommand, "@DailyTarget18", DbType.Currency, dailyTarget.DailyTarget18);
            database.AddInParameter(storedProcCommand, "@DailyTarget19", DbType.Currency, dailyTarget.DailyTarget19);
            database.AddInParameter(storedProcCommand, "@DailyTarget20", DbType.Currency, dailyTarget.DailyTarget20);
            database.AddInParameter(storedProcCommand, "@DailyTarget21", DbType.Currency, dailyTarget.DailyTarget21);
            database.AddInParameter(storedProcCommand, "@DailyTarget22", DbType.Currency, dailyTarget.DailyTarget22);
            database.AddInParameter(storedProcCommand, "@DailyTarget23", DbType.Currency, dailyTarget.DailyTarget23);
            database.AddInParameter(storedProcCommand, "@DailyTarget24", DbType.Currency, dailyTarget.DailyTarget24);
            database.AddInParameter(storedProcCommand, "@DailyTarget25", DbType.Currency, dailyTarget.DailyTarget25);
            database.AddInParameter(storedProcCommand, "@DailyTarget26", DbType.Currency, dailyTarget.DailyTarget26);
            database.AddInParameter(storedProcCommand, "@DailyTarget27", DbType.Currency, dailyTarget.DailyTarget27);
            database.AddInParameter(storedProcCommand, "@DailyTarget28", DbType.Currency, dailyTarget.DailyTarget28);
            database.AddInParameter(storedProcCommand, "@DailyTarget29", DbType.Currency, dailyTarget.DailyTarget29);
            database.AddInParameter(storedProcCommand, "@DailyTarget30", DbType.Currency, dailyTarget.DailyTarget30);
            database.AddInParameter(storedProcCommand, "@DailyTarget31", DbType.Currency, dailyTarget.DailyTarget31);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual DataTable Settings_Targets_Select(long CompanyID,int UserID,string DataType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Targets_Select");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@DataType", DbType.String, DataType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Proof_Settings(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Proof_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void InsertProofSettingIfNotExist(int CompanyID, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertProofSettingIfNotExist");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.ExecuteNonQuery(storedProcCommand);

        }
        public virtual void Save_Proof_Settings(int CompanyID, int UserID,bool IsDisplayModuleNumber,bool IsItemPanelState, bool IsProofDescriptionStatus, bool IsItemTitle, bool IsDescription, bool IsArtwork, bool IsSize, bool IsColour, bool IsMaterial, bool IsDelivery, bool IsFinishing, bool IsProofs, bool IsPacking, bool IsNotes, bool IsInstructions, bool isCustomDescription1, bool isCustomDescription2, bool isCustomDescription3, bool isCustomDescription4, bool isCustomDescription5, bool isCustomDescription6, bool isCustomDescription7, bool isCustomDescription8, bool isCustomDescription9, bool isCustomDescription10, bool isCustomDescription11, bool isCustomDescription12, bool isCustomDescription13, bool isCustomDescription14, bool isCustomDescription15, bool isCustomDescription16, bool isCustomDescription17, bool isCustomDescription18, bool isCustomDescription19, bool isCustomDescription20, bool isCustomDescription21, bool isCustomDescription22, bool isCustomDescription23, bool isCustomDescription24, bool isCustomDescription25,bool chkDownloadFileBeforeApprove,bool chkMultiApproval,bool chkChangeProofDescription, bool chkProofCustomerComment)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Save_Proof_Settings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@IsDisplayModuleNumber", DbType.Boolean, IsDisplayModuleNumber);
            database.AddInParameter(storedProcCommand, "@IsItemPanelState", DbType.Boolean, IsItemPanelState);
            database.AddInParameter(storedProcCommand, "@IsProofDescriptionStatus", DbType.Boolean, IsProofDescriptionStatus);


            database.AddInParameter(storedProcCommand, "@IsItemTitle", DbType.Boolean, IsItemTitle);
            database.AddInParameter(storedProcCommand, "@IsDescription", DbType.Boolean, IsDescription);
            database.AddInParameter(storedProcCommand, "@IsArtwork", DbType.Boolean, IsArtwork);
            database.AddInParameter(storedProcCommand, "@IsSize", DbType.Boolean, IsSize);
            database.AddInParameter(storedProcCommand, "@IsColour", DbType.Boolean, IsColour);
            database.AddInParameter(storedProcCommand, "@IsMaterial", DbType.Boolean, IsMaterial);
            database.AddInParameter(storedProcCommand, "@IsDelivery", DbType.Boolean, IsDelivery);
            database.AddInParameter(storedProcCommand, "@IsFinishing", DbType.Boolean, IsFinishing);
            database.AddInParameter(storedProcCommand, "@IsProofs", DbType.Boolean, IsProofs);
            database.AddInParameter(storedProcCommand, "@IsPacking", DbType.Boolean, IsPacking);
            database.AddInParameter(storedProcCommand, "@IsNotes", DbType.Boolean, IsNotes);
            database.AddInParameter(storedProcCommand, "@IsInstructions", DbType.Boolean, IsInstructions);
            database.AddInParameter(storedProcCommand, "@isCustomDescription1", DbType.Boolean, isCustomDescription1);
            database.AddInParameter(storedProcCommand, "@isCustomDescription2", DbType.Boolean, isCustomDescription2);
            database.AddInParameter(storedProcCommand, "@isCustomDescription3", DbType.Boolean, isCustomDescription3);
            database.AddInParameter(storedProcCommand, "@isCustomDescription4", DbType.Boolean, isCustomDescription4);
            database.AddInParameter(storedProcCommand, "@isCustomDescription5", DbType.Boolean, isCustomDescription5);
            database.AddInParameter(storedProcCommand, "@isCustomDescription6", DbType.Boolean, isCustomDescription6);
            database.AddInParameter(storedProcCommand, "@isCustomDescription7", DbType.Boolean, isCustomDescription7);
            database.AddInParameter(storedProcCommand, "@isCustomDescription8", DbType.Boolean, isCustomDescription8);
            database.AddInParameter(storedProcCommand, "@isCustomDescription9", DbType.Boolean, isCustomDescription9);
            database.AddInParameter(storedProcCommand, "@isCustomDescription10", DbType.Boolean, isCustomDescription10);
            database.AddInParameter(storedProcCommand, "@isCustomDescription11", DbType.Boolean, isCustomDescription11);
            database.AddInParameter(storedProcCommand, "@isCustomDescription12", DbType.Boolean, isCustomDescription12);
            database.AddInParameter(storedProcCommand, "@isCustomDescription13", DbType.Boolean, isCustomDescription13);
            database.AddInParameter(storedProcCommand, "@isCustomDescription14", DbType.Boolean, isCustomDescription14);
            database.AddInParameter(storedProcCommand, "@isCustomDescription15", DbType.Boolean, isCustomDescription15);
            database.AddInParameter(storedProcCommand, "@isCustomDescription16", DbType.Boolean, isCustomDescription16);
            database.AddInParameter(storedProcCommand, "@isCustomDescription17", DbType.Boolean, isCustomDescription17);
            database.AddInParameter(storedProcCommand, "@isCustomDescription18", DbType.Boolean, isCustomDescription18);
            database.AddInParameter(storedProcCommand, "@isCustomDescription19", DbType.Boolean, isCustomDescription19);
            database.AddInParameter(storedProcCommand, "@isCustomDescription20", DbType.Boolean, isCustomDescription20);
            database.AddInParameter(storedProcCommand, "@isCustomDescription21", DbType.Boolean, isCustomDescription21);
            database.AddInParameter(storedProcCommand, "@isCustomDescription22", DbType.Boolean, isCustomDescription22);
            database.AddInParameter(storedProcCommand, "@isCustomDescription23", DbType.Boolean, isCustomDescription23);
            database.AddInParameter(storedProcCommand, "@isCustomDescription24", DbType.Boolean, isCustomDescription24);
            database.AddInParameter(storedProcCommand, "@isCustomDescription25", DbType.Boolean, isCustomDescription25);

            database.AddInParameter(storedProcCommand, "@chkDownloadFileBeforeApprove", DbType.Boolean, chkDownloadFileBeforeApprove);
            database.AddInParameter(storedProcCommand, "@chkMultiApproval", DbType.Boolean, chkMultiApproval);
            database.AddInParameter(storedProcCommand, "@chkChangeProofDescription", DbType.Boolean, chkChangeProofDescription);
            database.AddInParameter(storedProcCommand, "@chkProofCustomerComment", DbType.Boolean, chkProofCustomerComment);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual DataTable Select_JobDefault_Settings(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_job_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void InsertUpdate_JobDefault_Settings(int CompanyID, bool IsDefaultJobArtwork, bool IsDefaultJobProof, bool IsDefaultJobApproval, bool IsDefaultJobProduction,bool Display100JobsOnJobPage)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_job_insert_or_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsDefaultJobArtwork", DbType.Boolean, IsDefaultJobArtwork);
            database.AddInParameter(storedProcCommand, "@IsDefaultJobProof", DbType.Boolean, IsDefaultJobProof);
            database.AddInParameter(storedProcCommand, "@IsDefaultJobApproval", DbType.Boolean, IsDefaultJobApproval);
            database.AddInParameter(storedProcCommand, "@IsDefaultJobProduction", DbType.Boolean, IsDefaultJobProduction);
            database.AddInParameter(storedProcCommand, "@Display100JobsOnJobPage", DbType.Boolean, Display100JobsOnJobPage);
            database.ExecuteNonQuery(storedProcCommand);

        }


        public virtual void UpdateStripeDetails(int CompanyID, string HostName, string StripeKey, string StripeImage)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_StripeDetails");
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, HostName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            database.AddInParameter(storedProcCommand, "@StripeKey", DbType.String, StripeKey);
            database.AddInParameter(storedProcCommand, "@StripeImage", DbType.String, StripeImage);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void UpdateStripeSuccessDetails(int CompanyID, string HostName, string url, string message,string img, string logourl)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_StripeSuccessDetails");
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, HostName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            database.AddInParameter(storedProcCommand, "@logoimg", DbType.String, img);
            database.AddInParameter(storedProcCommand, "@message", DbType.String, message);
            database.AddInParameter(storedProcCommand, "@redirecturl", DbType.String, url);
            database.AddInParameter(storedProcCommand, "@LogoURL", DbType.String, logourl);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable GetStripeDetails(int CompanyID, string HostName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_StripeDetails");
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, HostName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetStripeSuccessDetails(int CompanyID, string HostName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_StripeSuccessDetails");
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, HostName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void add_small_format_formula_tag(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("add_small_format_formula_tag");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);

        }

         public virtual DataTable Select_DaysSince_Settings(int companyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DaysSince_Settings_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public void InsertUpdate_DaysSince_Settings(int companyID, string eststatus, string ordstatus, string proofstatus, string prooffilestatus, string jobstatus, string postatus, string invstatus, string dnstatus, string estemail, string ordemail, string proofemail, string prooffileemail, string jobemail, string poemail, string invemail, string dnemail, int isEstStatus, int isOrdStatus, int isProofStatus, int isProofFileStatus,int isJobStatus, int isPOStatus, int isInvStatus, int isDNStatus, int isEstEmail, int isOrdEmail, int isProofEmail, int isProofFileEmail,int isJobEmail, int isPOEmail, int isInvEmail, int isDNEmail )
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_DaysSince_insertupdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@estStatus", DbType.Int32, String.IsNullOrEmpty(eststatus) ? 0 : Convert.ToInt32(eststatus));
            database.AddInParameter(storedProcCommand, "@ordstatus", DbType.Int32, string.IsNullOrEmpty(ordstatus) ? 0 : Convert.ToInt32(ordstatus));
            database.AddInParameter(storedProcCommand, "@proofstatus", DbType.Int32, string.IsNullOrEmpty(proofstatus) ? 0 : Convert.ToInt32(proofstatus));
            database.AddInParameter(storedProcCommand, "@prooffilestatus", DbType.Int32, string.IsNullOrEmpty(prooffilestatus) ? 0 : Convert.ToInt32(prooffilestatus));
            database.AddInParameter(storedProcCommand, "@jobstatus", DbType.Int32, string.IsNullOrEmpty(jobstatus) ? 0 : Convert.ToInt32(jobstatus));
            database.AddInParameter(storedProcCommand, "@postatus", DbType.Int32, string.IsNullOrEmpty(postatus) ? 0 : Convert.ToInt32(postatus));
            database.AddInParameter(storedProcCommand, "@invstatus", DbType.Int32, string.IsNullOrEmpty(invstatus) ? 0 : Convert.ToInt32(invstatus));
            database.AddInParameter(storedProcCommand, "@dnstatus", DbType.Int32, string.IsNullOrEmpty(dnstatus) ? 0 : Convert.ToInt32(dnstatus));

            database.AddInParameter(storedProcCommand, "@estemail", DbType.Int32, string.IsNullOrEmpty(estemail) ? 0 : Convert.ToInt32(estemail));
            database.AddInParameter(storedProcCommand, "@ordemail", DbType.Int32, string.IsNullOrEmpty(ordemail) ? 0 : Convert.ToInt32(ordemail));
            database.AddInParameter(storedProcCommand, "@proofemail", DbType.Int32, string.IsNullOrEmpty(proofemail) ? 0 : Convert.ToInt32(proofemail));
            database.AddInParameter(storedProcCommand, "@prooffileemail", DbType.Int32, string.IsNullOrEmpty(prooffileemail) ? 0 : Convert.ToInt32(prooffileemail));
            database.AddInParameter(storedProcCommand, "@jobemail", DbType.Int32, string.IsNullOrEmpty(jobemail) ? 0 : Convert.ToInt32(jobemail));
            database.AddInParameter(storedProcCommand, "@poemail", DbType.Int32, string.IsNullOrEmpty(poemail) ? 0 : Convert.ToInt32(poemail));
            database.AddInParameter(storedProcCommand, "@invemail", DbType.Int32, string.IsNullOrEmpty(invemail) ? 0 : Convert.ToInt32(invemail));
            database.AddInParameter(storedProcCommand, "@dnemail", DbType.Int32, string.IsNullOrEmpty(dnemail) ? 0 : Convert.ToInt32(dnemail));


            database.AddInParameter(storedProcCommand, "@isEstStatus", DbType.Boolean, isEstStatus == 1);
            database.AddInParameter(storedProcCommand, "@isOrdStatus", DbType.Boolean, isOrdStatus == 1);
            database.AddInParameter(storedProcCommand, "@isProofStatus", DbType.Boolean, isProofStatus == 1);
            database.AddInParameter(storedProcCommand, "@isProofFileStatus", DbType.Boolean, isProofFileStatus == 1);
            database.AddInParameter(storedProcCommand, "@isJobStatus", DbType.Boolean, isJobStatus == 1);
            database.AddInParameter(storedProcCommand, "@isPOStatus", DbType.Boolean, isPOStatus == 1);
            database.AddInParameter(storedProcCommand, "@isInvStatus", DbType.Boolean, isInvStatus == 1);
            database.AddInParameter(storedProcCommand, "@isDNStatus", DbType.Boolean, isDNStatus == 1);
            database.AddInParameter(storedProcCommand, "@isEstEmail", DbType.Boolean, isEstEmail == 1);
            database.AddInParameter(storedProcCommand, "@isOrdEmail", DbType.Boolean, isOrdEmail == 1);
            database.AddInParameter(storedProcCommand, "@isProofEmail", DbType.Boolean, isProofEmail == 1);
            database.AddInParameter(storedProcCommand, "@isProofFileEmail", DbType.Boolean, isProofFileEmail == 1);
            database.AddInParameter(storedProcCommand, "@isJobEmail", DbType.Boolean, isJobEmail == 1);
            database.AddInParameter(storedProcCommand, "@isPOEmail", DbType.Boolean, isPOEmail == 1);
            database.AddInParameter(storedProcCommand, "@isInvEmail", DbType.Boolean, isInvEmail == 1);
            database.AddInParameter(storedProcCommand, "@isDNEmail", DbType.Boolean, isDNEmail == 1);

            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual DataTable PC_SecondApproval_Email(int CompanyID, int ProofID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_SecondApproval_Email");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable PC_GetProofEmailDetails(int ProofID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetProofEmailDetails");
            database.AddInParameter(storedProcCommand, "@ProofID", DbType.Int64, ProofID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void add_warehouse_caliper_formula_tag(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("add_warehouse_caliper_formula_tag");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.ExecuteNonQuery(storedProcCommand);

        }

        public virtual int SaveFtpSettings(string ftpAddress, string username, string encryptedPassword, int CompanyID, int ftpPort,string rootFolder,string fileTransferProtocol)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SaveFtpSettings");
            database.AddInParameter(storedProcCommand, "@FtpAddress", DbType.String, ftpAddress);
            database.AddInParameter(storedProcCommand, "@Username", DbType.String, username);
            database.AddInParameter(storedProcCommand, "@EncryptedPassword", DbType.String, encryptedPassword);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@FTPPort", DbType.Int64, ftpPort);
            database.AddInParameter(storedProcCommand, "@RootFolder", DbType.String, rootFolder);
            database.AddInParameter(storedProcCommand, "@ProtocolType", DbType.String, fileTransferProtocol);
            database.AddOutParameter(storedProcCommand, "@FtpSettingsId", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@FtpSettingsId");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }
        public virtual void SaveSelectedFolders(int ftpSettingsId, List<string> selectedFolders)
        {

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            foreach (var folder in selectedFolders)
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SaveSelectedFolders");
                database.AddInParameter(storedProcCommand, "@FtpSettingsId", DbType.Int32, ftpSettingsId);
                database.AddInParameter(storedProcCommand, "@FolderPath", DbType.String, folder);
                database.ExecuteNonQuery(storedProcCommand);
            }
        }
        public virtual List<string> GetSavedFtpFoldersByFtpId(int ftpSettingsId)
        {
            List<string> folders = new List<string>();

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand command = database.GetSqlStringCommand("SELECT FolderName FROM FtpFolderSelections WHERE FtpSettingsId = @FtpSettingsId");
            database.AddInParameter(command, "@FtpSettingsId", DbType.Int32, ftpSettingsId);

            using (IDataReader reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    folders.Add(reader["FolderName"].ToString());
                }
            }

            return folders;
        }
        public virtual void DeleteSelectedFolder(int ftpSettingsId, string folderName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand cmd = database.GetSqlStringCommand("DELETE FROM FtpFolderSelections WHERE FtpSettingsId = @FtpSettingsId AND FolderName = @FolderName");
            database.AddInParameter(cmd, "@FtpSettingsId", DbType.Int32, ftpSettingsId);
            database.AddInParameter(cmd, "@FolderName", DbType.String, folderName);
            database.ExecuteNonQuery(cmd);
        }
        public virtual void SaveSelectedFolder(int ftpSettingsId, string folderName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SaveSelectedFolder");

            database.AddInParameter(storedProcCommand, "@FtpSettingsId", DbType.Int32, ftpSettingsId);
            database.AddInParameter(storedProcCommand, "@FolderName", DbType.String, folderName);

            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual Dictionary<int, string> GetSavedFtpFolders(int CompanyID)
        {
            string saved = "";
            //var savedFolders = new List<string>();
            Dictionary<int, string> savedFolders = new Dictionary<int, string>();

            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetSelectedFtpFolders");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.String, CompanyID);
            //database.ExecuteNonQuery(storedProcCommand);
            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())  // Use while to read all rows
                {
                    int folderId = Convert.ToInt32(reader["ID"]);
                    string folder = reader["FolderName"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(folder))
                    {
                        savedFolders[folderId] = folder.Trim();
                    }
                }
            }

            return savedFolders;
        }

        public virtual FtpSettingsModel GetFtpSettings(int companyId)
        {
            FtpSettingsModel settings = null;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFtpSettings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                if (reader.Read())
                {
                    settings = new FtpSettingsModel
                    {
                        FtpAddress = reader["FtpAddress"]?.ToString(),
                        Username = reader["Username"]?.ToString(),
                        EncryptedPassword = reader["EncryptedPassword"]?.ToString(),
                        Port = reader["FTPPort"] != DBNull.Value ? Convert.ToInt32(reader["FTPPort"]) : 22 , // default to 22 if null
                        RootFolder = reader["RootFolder"].ToString(),
                        FileTransferProtocol = reader["FileTransferProtocol"].ToString()
                    };
                }
            }

            return settings;
        }
        public void SaveFtpRouteSetting(int companyId, string sectionName, string actionName, int statusValue, bool isSelected)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SaveFtpRouteSetting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);
            database.AddInParameter(storedProcCommand, "@SectionName", DbType.String, sectionName);
            database.AddInParameter(storedProcCommand, "@ActionName", DbType.String, actionName);
            database.AddInParameter(storedProcCommand, "@StatusValue", DbType.Int32, statusValue);
            database.AddInParameter(storedProcCommand, "@IsSelected", DbType.Boolean, isSelected);

            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual List<FtpRouteSetting> LoadFtpRouteSettings(int companyId)
        {
            var list = new List<FtpRouteSetting>();
            Database db = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand cmd = db.GetStoredProcCommand("PC_GetFtpRouteSettings");
            db.AddInParameter(cmd, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new FtpRouteSetting
                    {
                        SectionName = reader["SectionName"].ToString(),
                        ActionName = reader["ActionName"].ToString(),
                        StatusValue = Convert.ToInt32(reader["StatusValue"]?.ToString()),
                        IsSelected = Convert.ToBoolean(reader["IsSelected"]?.ToString())
                    });
                }
            }

            return list;
        }
        public virtual void InsertUpdateFTPPrefix(int CompanyID, int PrefixMode)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_UpdateInsertFTPPrefix");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PrefixMode", DbType.Int64, PrefixMode);
            database.ExecuteNonQuery(storedProcCommand);

        }
        public virtual FtpPrefixSettingsModel GetFtpPrefixSettings(int companyId)
        {
            FtpPrefixSettingsModel settings = null;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFTPPrefixSettings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                if (reader.Read())
                {
                    settings = new FtpPrefixSettingsModel
                    {
                        ID = Convert.ToInt32(reader["ID"]?.ToString()),
                        PrefixSelectedMode = Convert.ToInt32(reader["PrefixMode"]?.ToString())
                    };
                }
            }

            return settings;
        }

        public virtual DataTable GetFTPEmailTags(int CompanyID, long PriceCatalogueID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFtpEmailsTags");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetFTPEmailTemplate(int CompanyID, string TemplateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFTPEmailTemplate");
            database.AddInParameter(storedProcCommand, "@TemplateType", DbType.String, TemplateType);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetFtpLogSettings(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFTPLogs");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);

            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public void SaveFtpLogs(int CompanyID, long ProductCatalogueID, long EstimateItemID, DateTime TimeStamp, string Status, string TargetDestination, string FileName,string FTPError)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SaveFtpLogs");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ProductCatalogueID", DbType.Int64, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@TimeStamp", DbType.DateTime, TimeStamp);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@TargetDestination", DbType.String, TargetDestination);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@FTPError", DbType.String, FTPError);

            database.ExecuteNonQuery(storedProcCommand);
        }
    }
}
    