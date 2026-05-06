using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

namespace Printcenter.DataAccessLayer.dashboard
{
    public class DbDashboard
    {
        public DbDashboard()
        {
        }

        public virtual DataSet CRM_Dashboard_select_Dock(long CompanyID, int CreatedBy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_select_Dock");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_CustomerActivity_Select(long CompanyID, int UserID, string CompanyType, int NoOFRecords, string Columns)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_CustomerbyActivity_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, CompanyType);
            database.AddInParameter(storedProcCommand, "@NoRecords", DbType.Int32, NoOFRecords);
            database.AddInParameter(storedProcCommand, "@Columns", DbType.String, Columns);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_LatestNotes_Select(long clientid, long companyid, string companytype, string showrecords, long salespersonid, int noofrecords, string columns)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            string empty = string.Empty;
            empty = (clientid == (long)0 || clientid == (long)-1 ? "CRM_Dashboard_LatestNotes_SelectForAll" : "CRM_Dashboard_LatestNotes_Select");
            DbCommand storedProcCommand = database.GetStoredProcCommand(empty);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, clientid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@CompanyType", DbType.String, companytype);
            database.AddInParameter(storedProcCommand, "@ShowRecords", DbType.String, showrecords);
            database.AddInParameter(storedProcCommand, "@SelespersonId", DbType.Int64, salespersonid);
            database.AddInParameter(storedProcCommand, "@NoRecords", DbType.Int32, noofrecords);
            database.AddInParameter(storedProcCommand, "@Columns", DbType.String, columns);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void Dashboard_MiniWidget_Delete(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_DeleteDashboardMiniWidgets");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Dashboard_MiniWidget_Update(long UserID, string HomePageState, long CopyMasterId, string dockposition, int indexno)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DashBoardMiniLayout");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@HomePageState", DbType.String, HomePageState);
            database.AddInParameter(storedProcCommand, "@CopyMasterId", DbType.Int64, CopyMasterId);
            database.AddInParameter(storedProcCommand, "@dockposition", DbType.String, dockposition);
            database.AddInParameter(storedProcCommand, "@indexno", DbType.String, indexno);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_ByDueDate(long CompanyId, string WhereCondition, int noOfRecords, string ModuleName, string StatusID, bool ShowArchvedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_JObStatusDueDate_Select");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
                database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, noOfRecords);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, StatusID);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchvedrecords);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusDueDate_Select");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@WhereCondition", DbType.String, WhereCondition);
                database.AddInParameter(dbCommand, "@NoOfRecords", DbType.Int32, noOfRecords);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, StatusID);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchvedrecords);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            return dataSet;
        }

        public virtual DataSet Dashboard_Select_ByDueDate_SplitItem(long CompanyId, string WhereCondition, int noOfRecords, string ModuleName, string StatusID, bool ShowArchvedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_JObStatusDueDate_Select_SpliItem");
                database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
                database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, noOfRecords);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, StatusID);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchvedrecords);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusDueDate_Select_SplitItem");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@WhereCondition", DbType.String, WhereCondition);
                database.AddInParameter(dbCommand, "@NoOfRecords", DbType.Int32, noOfRecords);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, StatusID);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchvedrecords);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            return dataSet;
        }
        public virtual DataSet Dashboard_GetInvoiceCodesPercentage(int DateType, long CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand;
            storedProcCommand = database.GetStoredProcCommand("PC_GetInvoiceCodesPercentage");
            database.AddInParameter(storedProcCommand, "@DateType", DbType.Int64, DateType);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
            dataSet = database.ExecuteDataSet(storedProcCommand);

            return dataSet;
        }
        public virtual DataSet Dashboard_GetEstStatusCount(long CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand;
            storedProcCommand = database.GetStoredProcCommand("PC_GetEstStatusCount");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyId);
            dataSet = database.ExecuteDataSet(storedProcCommand);

            return dataSet;
        }
        public virtual DataSet Dashboard_Select_CallVS(long CompanyId, string DateType, string SalesPersonID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Select_CallScheduledVSCallMade");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@DispType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@SalesPersonID", DbType.String, SalesPersonID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_CallVSCount(long CompanyId, string DateType, string SalesPersonID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CustomerCall_CountDetail");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@DispType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@SalesPersonID", DbType.String, SalesPersonID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusCount_Select");
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusCount_Select");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusCount_Select");
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }

        public virtual DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItem(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusCount_Select_ForSplitItem");
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusCount_Select_ForSplitItem");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusCount_Select_ForSplitItem");
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, StatusID);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }
        public virtual DataSet Dashboard_Select_JobsInvoiceEstimatesCountbySalesPersonandStatus_SplitItemNew(long CompanyId, string SalesPersonID, string ModuleName, string StatusID, bool ShowArchivedrecords, string dateType, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (string.IsNullOrEmpty(dateType))
            {
                dateType = "Annual";
            }
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusCount_Select_ForSplitItemNew");
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, StatusID);

                database.AddInParameter(storedProcCommand, "@dateType", DbType.String, dateType);
                database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
                database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);

                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusCount_Select_ForSplitItemNew");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, StatusID);

                database.AddInParameter(dbCommand, "@dateType", DbType.String, dateType);
                database.AddInParameter(dbCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(dbCommand, "@StartDate", DbType.String, StartDate);
                database.AddInParameter(dbCommand, "@EndDate", DbType.String, EndDate);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusCount_Select_ForSplitItemNew");
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPersonID);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedrecords);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, StatusID);

                database.AddInParameter(storedProcCommand1, "@dateType", DbType.String, dateType);
                database.AddInParameter(storedProcCommand1, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(storedProcCommand1, "@StartDate", DbType.String, StartDate);
                database.AddInParameter(storedProcCommand1, "@EndDate", DbType.String, EndDate);

                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }

        public virtual DataSet Dashboard_Select_Probalility(long CompanyId, string UserID, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_EstimateStatusProbabilty_Select");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_Probalility_SplitItems(long CompanyId, string UserID, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_EstimateStatusProbabilty_Select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_ProbalilityPercent(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateProbability_select");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedRecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_ProbalilityPercent_SplitItem(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateProbability_select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedRecords);
            return database.ExecuteDataSet(storedProcCommand);
        }
        public virtual DataSet Dashboard_Select_ProbalilityPercent_SplitItemNew(long CompanyId, string Status, string ModuleName, bool ShowArchivedRecords, string DateType, string IsCalendarYear, string FromDate, string ToDate)
        {
            if (string.IsNullOrEmpty(DateType))
            {
                DateType = "Annual";
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateProbability_select_SplitItemNew");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedRecords);

            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, ToDate);

            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_SalesPersonByModule(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusValue_Select");
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusValue_Select");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusValue_Select");
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }

        public virtual DataSet Dashboard_Select_SalesPersonByModule_SplitItem(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusValue_Select_SplitItem");
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusValue_Select_SpitItem");
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusValue_Select_SplitItem");
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, Status);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }
        public virtual DataSet Dashboard_Select_SalesPersonByModule_SplitItemNew(long CompanyId, string SalesPerson, string ModuleName, string Status, bool ShowArchivedStatus, string DateType, string IsCalendarYear, string FromDate, string ToDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            if (string.IsNullOrEmpty(DateType))
            {
                DateType = "Annual";
            }
            if (ModuleName.ToLower() == "estimates")
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_EstimateStatusValue_Select_SplitItemNew");
                storedProcCommand.CommandTimeout = int.MaxValue;
                database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);

                database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
                database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, FromDate);
                database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, ToDate);
                dataSet = database.ExecuteDataSet(storedProcCommand);
            }
            else if (ModuleName.ToLower() == "invoice")
            {
                DbCommand dbCommand = database.GetStoredProcCommand("Crm_InvoiceStatusValue_Select_SpitItemNew");
                dbCommand.CommandTimeout = int.MaxValue;
                database.AddInParameter(dbCommand, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(dbCommand, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(dbCommand, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(dbCommand, "@StatusIDs", DbType.String, Status);

                database.AddInParameter(dbCommand, "@dateType", DbType.String, DateType);
                database.AddInParameter(dbCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(dbCommand, "@StartDate", DbType.String, FromDate);
                database.AddInParameter(dbCommand, "@EndDate", DbType.String, ToDate);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            else if (ModuleName.ToLower() == "jobs")
            {
                DbCommand storedProcCommand1 = database.GetStoredProcCommand("Crm_JobStatusValue_Select_SplitItemNew");
                storedProcCommand1.CommandTimeout = int.MaxValue;
                database.AddInParameter(storedProcCommand1, "@CompanyId", DbType.Int64, CompanyId);
                database.AddInParameter(storedProcCommand1, "@Salesperson", DbType.String, SalesPerson);
                database.AddInParameter(storedProcCommand1, "@ISArchive", DbType.Boolean, ShowArchivedStatus);
                database.AddInParameter(storedProcCommand1, "@StatusIDs", DbType.String, Status);

                database.AddInParameter(storedProcCommand1, "@dateType", DbType.String, DateType);
                database.AddInParameter(storedProcCommand1, "@IsCalendarYear", DbType.String, IsCalendarYear);
                database.AddInParameter(storedProcCommand1, "@StartDate", DbType.String, FromDate);
                database.AddInParameter(storedProcCommand1, "@EndDate", DbType.String, ToDate);
                dataSet = database.ExecuteDataSet(storedProcCommand1);
            }
            return dataSet;
        }
        public virtual DataSet Dashboard_Select_DailyOrMonthlyJobTotal(long CompanyId, int CopyMasterID, string DateType, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand;
            if (DateType == "Daily")
            {
                storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_DailyJobTotal");
            }
            else
            {
                storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_MonthlyJobTotal");
            }
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.String, CopyMasterID);
            database.AddInParameter(storedProcCommand, "@Userid", DbType.Int64, userid);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            return dataSet;
        }

        public virtual DataTable Dashboard_Select_LastYearDailyOrMonthlyJobTotal(long CompanyId, int CopyMasterID, string DateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand;
            if (DateType == "Daily")
            {
                storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_LastYearDailyJobTotal");
            }
            else
            {
                storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_LastYearMonthlyJobTotal");
            }
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@CopyMasterID", DbType.String, CopyMasterID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Dashboard_Select_TaskCall(long CompanyId, string whereConditions, int NoOfRecords, string RecordType, string SalesPersonID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Select_TaskCall_ForDashboard");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@DispType", DbType.String, whereConditions);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            database.AddInParameter(storedProcCommand, "@RecordType", DbType.String, RecordType);
            database.AddInParameter(storedProcCommand, "@SalesPersonID", DbType.String, SalesPersonID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskCall_ForAdmin(long CompanyId, int UserID, string whereConditions, int NoOfRecords, string RecordType, long CustomerID, long Salespersonid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Crm_Select_TaskCall_ForAdminForAll");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@DispType", DbType.String, whereConditions);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            database.AddInParameter(storedProcCommand, "@RecordType", DbType.String, RecordType);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@Salespersonid", DbType.Int32, Salespersonid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Select_TaskEventCall_Today(long ClientID, long CompanyId, int UserID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Crm_Select_TaskEventCall_Today");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyId);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable dashboard_state_select(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_SelectDashBoardState");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void dashboard_state_update(int UserID, string DBState)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_UpdateDashBoardState");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@dbState", DbType.String, DBState);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Dashboard_Target_Actual_Date_Select(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_Target_Actual_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, Salesperson);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TargetRecordType", DbType.String, TargetRecordType);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Target_Actual_Date_Select_SplitItem(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_Target_Actual_Select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, Salesperson);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TargetRecordType", DbType.String, TargetRecordType);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Target_Actual_Date_SelectPie(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_TargetActualValue_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, Salesperson);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TargetRecordType", DbType.String, TargetRecordType);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet Dashboard_Target_Actual_Date_SelectPie_SplitItem(long CompanyID, string Salesperson, string QuarterType, string EstimateType, string TargetRecordType, string Status, bool ShowArcihivedrecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Dashboard_TargetActualValue_Select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Salesperson", DbType.String, Salesperson);
            database.AddInParameter(storedProcCommand, "@QuarterType", DbType.String, QuarterType);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstimateType);
            database.AddInParameter(storedProcCommand, "@TargetRecordType", DbType.String, TargetRecordType);
            database.AddInParameter(storedProcCommand, "@StatusIDs", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@ISArchive", DbType.Boolean, ShowArcihivedrecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void Dashboard_Widget_Delete(int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_DeleteDashboardWidgets");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Dashboard_Widget_Update(long UserID, string HomePageState, long CopyMasterId, string dockposition, int indexno)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DashBoardLayout");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@HomePageState", DbType.String, HomePageState);
            database.AddInParameter(storedProcCommand, "@CopyMasterId", DbType.Int64, CopyMasterId);
            database.AddInParameter(storedProcCommand, "@dockposition", DbType.String, dockposition);
            database.AddInParameter(storedProcCommand, "@indexno", DbType.String, indexno);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Dashboard_WidgetTasks_Select(int CompanyID, int UserID, string DispType, string TaskStatus, int NoOfRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("crm_SelectTask_ForDashBoard");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@DispType", DbType.String, DispType);
            database.AddInParameter(storedProcCommand, "@TaskStatus", DbType.String, TaskStatus);
            database.AddInParameter(storedProcCommand, "@NoOfRecords", DbType.Int32, NoOfRecords);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet GetFromUsertype_ShowAll(int companyid, int userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("CRM_Type_SelectbyUserID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_AppointmentsTaskscompletedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TaskCompletedCount");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Callscompletedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CallCompletedCount");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_DataForQuoteNumberCount(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_QuotesCountDetails");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);



            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable PC_Dashboard_Select_MiniWidgets(long companyid, long userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_MINIWidgets");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, userid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet PC_Dashboard_Select_Newcustomerscreatedineprint(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_NewcustCreatedCount");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);

            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Quoteconversionrate(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstToJoBConversionPercentage");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);

            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Saleslivejobsteam(string UserID, string DateType, bool ArchivedRecords, long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LiveJobsCount");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_SaleslivejobsteamWithValue(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate, string hostName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobsCount_WithValues");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@HostName", DbType.String, hostName);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Salesnumberofjobs(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_LiveJobsCount");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Salessubtotalvalueofjobs(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TotalSubtotalOfJobs");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_SalesvalueofjobsGP(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobsValueIncGPS");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_SalesvalueofinvoicesGP(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            if (string.IsNullOrEmpty(DateType))
            {
                DateType = "Annual";
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoicesValueIncGPS");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);

        }

        public virtual DataSet PC_Dashboard_Select_SalesvalueofjobsGP_Percentage(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobsValueIncGPS_Percentage");
            storedProcCommand.CommandTimeout = Int32.MaxValue;
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataSet PC_Dashboard_Select_Valueofinvoicessubtotalfigure(string UserID, string DateType, bool ArchivedRecords, long CompanyID, string IsCalendarYear, string StartDate, string EndDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TotalSubtotalOfInvoice");
            database.AddInParameter(storedProcCommand, "@userID", DbType.String, UserID);
            database.AddInParameter(storedProcCommand, "@dateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IncludedArchive", DbType.Boolean, ArchivedRecords);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@IsCalendarYear", DbType.String, IsCalendarYear);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);

            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable PC_Dashboard_Select_Widgets(long companyid, long userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_Widgets");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, userid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_Get_AccessRights(long companyid, long userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetAccessRights");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, userid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet PC_Dashboard_Select_Widgetsnew(long companyid, long userid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Dashboard_Select_Widgets");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@userid", DbType.Int64, userid);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable PC_Select_SalesperSalespersonperMonth(long companyid, long SalesPersonID, long Range, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SalesperSalespersonperMonth");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@SalesPersonID", DbType.Int64, SalesPersonID);
            database.AddInParameter(storedProcCommand, "@Daterange", DbType.Int64, Range);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PC_Select_TaskCall_forwidgets(long companyid, long SalesPersonID, long Range, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TaskCallCompletedDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@SalesPersonID", DbType.Int64, SalesPersonID);
            database.AddInParameter(storedProcCommand, "@Daterange", DbType.Int64, Range);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Estimate()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_estimate_latest1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Estimate_Converted()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_estimate_converted1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Estimate_Highest()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_estimate_highest1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_invoice_highest()
        {
            Database database = DatabaseFactory.CreateDatabase((new commonClass()).connectionStringName);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_invoice_highest")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_invoice_latest()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_invoice_latest")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_job_converted()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_job_converted1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_job_highest()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_job_highest1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable select_job_latest()
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(database.GetStoredProcCommand("pc_dashboard_job_latest1")))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}