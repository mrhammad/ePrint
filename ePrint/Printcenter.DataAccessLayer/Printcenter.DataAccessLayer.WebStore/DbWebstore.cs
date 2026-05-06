using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.WebStore
{
    public class DbWebstore
    {
        public DbWebstore()
        {
        }

        public virtual void AdditionalGroup_delete(long AdditionalGroupID, long PricecatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalGroup_delete");
            database.AddInParameter(storedProcCommand, "@AdditionalGroupID", DbType.Int64, AdditionalGroupID);
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long AdditionalGroup_insert(long PricecatalogueID, string GroupName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalGroup_insert");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual void AdditionalGroup_ProductID_Update(long TempProductID, long PricecatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalGroup_ProductID_Update");
            database.AddInParameter(storedProcCommand, "@TempProductID", DbType.Int64, TempProductID);
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable AdditionalGroup_select(long PricecatalogueID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalGroup_select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable AdditionalOption_Select(int CompanyID, int CategoryID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalOption_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CategoryID", DbType.Int64, CategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Assign_ProductCatatoryToAccountsOrCustomer(long categoryID, long customerID, long accountID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Assign_ProductCatatoryToAccountsOrCustomer");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, categoryID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, customerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, accountID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataSet Available_couponCode_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_Available_couponCode_PageText", sqlConnection);
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

        public virtual void bannerDelete(int bannerID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_bannerDelete");
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void bannerImageUpdate(int bannerID, string bannerImage)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_bannerImageUpdate");
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.AddInParameter(storedProcCommand, "@bannerImage", DbType.String, bannerImage);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual int bannerInsert(int bannerID, int companyID, int accountID, string bannerTitle, string bannerDescription, string bannerImage, string URL, string type, int imageSortOrderNo, string bannerName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_bannerInsert");
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@bannerTitle", DbType.String, bannerTitle);
            database.AddInParameter(storedProcCommand, "@bannerDescription", DbType.String, bannerDescription);
            database.AddInParameter(storedProcCommand, "@bannerImage", DbType.String, bannerImage);
            database.AddInParameter(storedProcCommand, "@URL", DbType.String, URL);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@imageSortOrderNo", DbType.Int32, imageSortOrderNo);
            database.AddInParameter(storedProcCommand, "@bannerName", DbType.String, bannerName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void bannerLocationInsert(int bannerID, string location, int pageID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_bannerLocationInsert");
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.AddInParameter(storedProcCommand, "@location", DbType.String, location);
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataSet bannerSelect(int bannerID, int companyID, int accountID, string type)
        {
            commonClass _commonClass = new commonClass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_bannerSelect");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void bannerSort(int bannerID, int companyID, int accountID, int imageSortOrderNo)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_bannerSort");
            database.AddInParameter(storedProcCommand, "@bannerID", DbType.Int32, bannerID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@imageSortOrderNo", DbType.Int32, imageSortOrderNo);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public DataTable BindBanner(int AccountID, int PageID, string Location, string Page)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_RightBannerImages");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@PageID", DbType.Int32, PageID);
            database.AddInParameter(storedProcCommand, "@Location", DbType.String, Location);
            database.AddInParameter(storedProcCommand, "@Page", DbType.String, Page);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Category_ClientDepartment_select(long CustomerID, string Departmentids)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Pricecataloguecategory_Department_Select");
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@Departmentids", DbType.String, Departmentids);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Check_pages_Duplicacy(long CompanyID, long AccountID, long PageID, string PageName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Check_pages_Duplicacy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@PageID", DbType.Int64, PageID);
            database.AddInParameter(storedProcCommand, "@PageName", DbType.String, PageName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual long Checking_ShopCartCostDetails(long webothercostid, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Checking_ShopCartCostDetails");
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void client_defaultLand(int CompanyID, int AccountID, int pageID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2Bpage_DefaultLand");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void CopyBanners(int BannerID, int AccountID, string Type, string bannerImgName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_CopyBanners");
            database.AddInParameter(storedProcCommand, "@BannerID", DbType.Int32, BannerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@BannerImage", DbType.String, bannerImgName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long CouponCode_Insertupdate(long CompanyID, long CouponID, long AccountID, string type, string CouponCode, string FriendlyName, decimal Discount, string DiscountType, bool CanbeuseMultipleTime)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CouponCode_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CouponID", DbType.Int64, CouponID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@CouponCode", DbType.String, CouponCode);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, FriendlyName);
            database.AddInParameter(storedProcCommand, "@Discount", DbType.Decimal, Discount);
            database.AddInParameter(storedProcCommand, "@DiscountType", DbType.String, DiscountType);
            database.AddInParameter(storedProcCommand, "@CanbeuseMultipleTime", DbType.Boolean, CanbeuseMultipleTime);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataSet CouponCode_Select(long CompanyID, long CouponCodeID, long AccountID, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CouponCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@CouponCodeID", DbType.Int64, CouponCodeID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void CouponCode_Webstore_Delete_Per_Account(int CompanyID, long CouponCodeID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CouponCode_Webstore_Delete_Per_Account");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@CouponCodeID", DbType.Int64, CouponCodeID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable CouponCodeOption_Select(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CouponCodeOption_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long DefaultProductStock_Self_Insert(long PricecatalogueID, long UserID, long CompanyID, DateTime date)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DefaultProductStock_Self_Insert");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StockEntryDate", DbType.DateTime, date);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual DataTable EmailTags_Select(string TagEvent, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailTags_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@TagEvent", DbType.String, TagEvent);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void EmailToAdmin_EnableUpdate(long CompanyID, string Type)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailToAdmin_EnableUpdate");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable EmailToCustomer_Select(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailFor)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailToCustomer_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@EmailToCustomerID", DbType.Int64, EmailToCustomerID);
            database.AddInParameter(storedProcCommand, "@TagEvent", DbType.String, TagEvent);
            database.AddInParameter(storedProcCommand, "@EmailFor", DbType.String, EmailFor);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long EmailToCustomer_Update(long EmailToCustomerID, int CompanyID, int AccountID, string Subject, string Body, int IsActive, DateTime ModifiedDate, string IsEnable, string IsFromCopy, int IsArtwork, int IsOrderPdf, int StatusID, int IsProductName, int IsJobName, int IsQuantity, int IsTotalPrice, int IsOrderedWidth, int IsOrderedHeight, int IsProductWidth, int IsProductHeight, int IsAdditionalOption, int IsItemNumber, int IsItemCode, int IsCustomerCode, int IsUnitOfMeasure, int isItemDescription, int isWeight, int isCubicMeasurment, int isOrderedWeight, int isOrderedCubicMeasurment, int isPerQuantity, int IsDimensions)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailToCustomer_Update");
            database.AddInParameter(storedProcCommand, "@EmailToCustomerID", DbType.Int64, EmailToCustomerID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@Subject", DbType.String, Subject);
            database.AddInParameter(storedProcCommand, "@Body", DbType.String, Body);
            database.AddInParameter(storedProcCommand, "@IsActive", DbType.Int32, IsActive);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@IsEnable", DbType.String, IsEnable);
            database.AddInParameter(storedProcCommand, "@IsFromCopy", DbType.String, IsFromCopy);
            database.AddInParameter(storedProcCommand, "@IsArtwork", DbType.Int32, IsArtwork);
            database.AddInParameter(storedProcCommand, "@IsOrderPdf", DbType.Int32, IsOrderPdf);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@IsProductName", DbType.Int32, IsProductName);
            database.AddInParameter(storedProcCommand, "@IsJobName", DbType.Int32, IsJobName);
            database.AddInParameter(storedProcCommand, "@IsQuantity", DbType.Int32, IsQuantity);
            database.AddInParameter(storedProcCommand, "@IsTotalPrice", DbType.Int32, IsTotalPrice);
            database.AddInParameter(storedProcCommand, "@IsOrderedWidth", DbType.Int32, IsOrderedWidth);
            database.AddInParameter(storedProcCommand, "@IsOrderedHeight", DbType.Int32, IsOrderedHeight);
            database.AddInParameter(storedProcCommand, "@IsProductWidth", DbType.Int32, IsProductWidth);
            database.AddInParameter(storedProcCommand, "@IsProductHeight", DbType.Int32, IsProductHeight);
            database.AddInParameter(storedProcCommand, "@IsAdditionalOption", DbType.Int32, IsAdditionalOption);
            database.AddInParameter(storedProcCommand, "@IsItemNumber", DbType.Int32, IsItemNumber);
            database.AddInParameter(storedProcCommand, "@IsItemCode", DbType.Int32, IsItemCode);
            database.AddInParameter(storedProcCommand, "@IsCustomerCode", DbType.Int32, IsCustomerCode);
            database.AddInParameter(storedProcCommand, "@IsUnitOfMeasure", DbType.Int32, IsUnitOfMeasure);

            database.AddInParameter(storedProcCommand, "@IsItemDescription", DbType.Int32, isItemDescription);
            database.AddInParameter(storedProcCommand, "@IsWeight", DbType.Int32, isWeight);
            database.AddInParameter(storedProcCommand, "@IsCubicMeasurment", DbType.Int32, isCubicMeasurment);
            database.AddInParameter(storedProcCommand, "@IsOrderedWeight", DbType.Int32, isOrderedWeight);
            database.AddInParameter(storedProcCommand, "@IsOrderedCubicMeasurment", DbType.Int32, isOrderedCubicMeasurment);
            database.AddInParameter(storedProcCommand, "@IsPerQuantity", DbType.Int32, isPerQuantity);
            database.AddInParameter(storedProcCommand, "@IsDimensions", DbType.Int32, IsDimensions);
            //database.AddInParameter(storedProcCommand, "@IsWidth", DbType.Int32, isWidth);
            //database.AddInParameter(storedProcCommand, "@IsHeight", DbType.Int32, isHeight);

            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            int num = (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
            _commonClass.closeConnection();
            return (long)num;
        }

        public virtual void estore_phrasebook_delete(WebstoreItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_PhraseBook_Delete");
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.Int32, item.PhraseBookID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void estore_phrasebook_insert(WebstoreItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_PhraseBook_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, item.CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.AddInParameter(storedProcCommand, "@accountid", DbType.Int64, item.AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable estore_phrasebook_select(int CompanyID, string PhraseType, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("ws_estore_phrasebook_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, PhraseType);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void estore_phrasebook_update(WebstoreItem item)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_PhraseBook_Update");
            database.AddInParameter(storedProcCommand, "@PhraseBookID", DbType.Int32, item.PhraseBookID);
            database.AddInParameter(storedProcCommand, "@PhraseType", DbType.String, item.PhraseType);
            database.AddInParameter(storedProcCommand, "@PhraseText", DbType.String, item.PhraseText);
            database.AddInParameter(storedProcCommand, "@IsDefaultPhrase", DbType.String, item.IsDefaultPhrase);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void EstoreReports_AllocatedCustomers_Delete(long Reportid, long CustomerID, string ReportName, string ModuleName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreReport_Customer_Delete");
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@ReportID", DbType.Int64, Reportid);
            database.AddInParameter(storedProcCommand, "@ReportName", DbType.String, ReportName);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void EstoreReports_AllocatedCustomers_Insert(long Reportid, long CustomerID, string ReportType, string EstoreReportType)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreReports_AllocatedCustomers");
            database.AddInParameter(storedProcCommand, "@Reportid", DbType.Int64, Reportid);
            database.AddInParameter(storedProcCommand, "@customerid", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@ReportType", DbType.String, ReportType);
            database.AddInParameter(storedProcCommand, "@EstoreReportType", DbType.String, EstoreReportType);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable EstoreSystemReport_CustomerCount(string pagename)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreSystemReport_CustomerCount");
            database.AddInParameter(storedProcCommand, "@pagename", DbType.String, pagename);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void FeaturedProducts_Insert(long CompanyID, long AccountID, long PriceCatalogueID, long OrderNo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_FeaturedProducts_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.Int64, OrderNo);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable FeaturedProducts_Select(long CompanyID, long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_FeaturedProducts_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void FeaturedProducts_Update(long CompanyID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_FeaturedProducts_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable getAutogenerate_ItemCode(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AutoGenerateItemCode");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet GetCatgoryList(int CompanyID, int AccountID, long StoreUserID)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_productsCategoryList_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public DataTable GetContentByAccountId(long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TypeID_Select");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataTable GetEditText(long EditID, long AccountID, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GetCustomText");
            database.AddInParameter(storedProcCommand, "@EditID", DbType.Int64, EditID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Group_Insert_Update(long PriceCatalogueGroupID, string GroupName, int companyID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionOptions_Insert_Update");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueGroupID", DbType.Int32, PriceCatalogueGroupID);
            database.AddInParameter(storedProcCommand, "@GroupName", DbType.String, GroupName);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual void headerInsert(int appID, int companyID, int accountID, string logoImage, string logoText, string logoTemplate, string logoType, string type, bool IsLogoEnlarged, bool IsLogoResized, int LogoResizedsize)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_headerInsert");
            database.AddInParameter(storedProcCommand, "@appID", DbType.Int32, appID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@logoImage", DbType.String, logoImage);
            database.AddInParameter(storedProcCommand, "@logoText", DbType.String, logoText);
            database.AddInParameter(storedProcCommand, "@logoTemplate", DbType.String, logoTemplate);
            database.AddInParameter(storedProcCommand, "@logoType", DbType.String, logoType);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@IsLogoEnlarged", DbType.Boolean, IsLogoEnlarged);
            database.AddInParameter(storedProcCommand, "@IsLogoResized", DbType.Boolean, IsLogoResized);
            database.AddInParameter(storedProcCommand, "@LogoResizedsize", DbType.Int32, LogoResizedsize);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable headerSelect(int CompanyID, int AccountID, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_headerSelect");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable homePageSelect(long pageID, int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_homePageSelect");
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int64, pageID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long homePageUpdate(long pageID, int IsSliddingBanners, string CenterPanelText, string CenterPanelOption, string CustomText)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_homePageUpdate");
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int64, pageID);
            database.AddInParameter(storedProcCommand, "@IsSliddingBanners", DbType.Int32, IsSliddingBanners);
            database.AddInParameter(storedProcCommand, "@CenterPanelText", DbType.String, CenterPanelText);
            database.AddInParameter(storedProcCommand, "@CenterPanelOption", DbType.String, CenterPanelOption);
            database.AddInParameter(storedProcCommand, "@CustomText", DbType.String, CustomText);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void ImageGallery_Insert(long UserID, long CompanyID, string ImageName, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ImageGallery_Insert");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ImageName", DbType.String, ImageName);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable ImageGallery_Select(long UserID, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ImageGallery_Select");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void InsertUpdate_Custom_Alphbetic_Order(bool IsAlphabticOrder, bool IsCustomOrder, long CompanyID, long AccountID, string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertUpdate_Custom_Alphbetic_Order");
            database.AddInParameter(storedProcCommand, "@IsAlphabticOrder", DbType.Boolean, IsAlphabticOrder);
            database.AddInParameter(storedProcCommand, "@IsCustomOrder", DbType.Boolean, IsCustomOrder);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual bool IsApprovalFeaturesOn_Select(long CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IsApprovalFeaturesOn_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Orderingprocess_settings(int companyID, int accountID, bool Is_Select_AllCartItems, bool IsHideMISJob, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool IsHideMISInvoice, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, string txt_jobScreenName, bool chk_jobScreenNameShow, bool chk_jobScreenNameRequired,
            bool attachConNumToUrl)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Orderingprocess_settings");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@Is_Select_AllCartItems", DbType.Boolean, Is_Select_AllCartItems);
            database.AddInParameter(storedProcCommand, "@IsHideMISJob", DbType.Boolean, IsHideMISJob);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Jobs", DbType.Boolean, Is_Only_User_Jobs);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentJobs", DbType.Boolean, Is_Only_User_DepartmentJobs);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Jobs", DbType.Boolean, Is_User_All_Jobs);
            database.AddInParameter(storedProcCommand, "@IsHideMISInvoice", DbType.Boolean, IsHideMISInvoice);
            database.AddInParameter(storedProcCommand, "@Is_only_User_Invoice", DbType.Boolean, Is_only_User_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_only_user_DepartmentInvoice", DbType.Boolean, Is_only_user_DepartmentInvoice);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Invoice", DbType.Boolean, Is_User_All_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Orders", DbType.Boolean, Is_Only_User_Orders);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentOrders", DbType.Boolean, Is_Only_User_DepartmentOrders);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Orders", DbType.Boolean, Is_User_All_Orders);
            database.AddInParameter(storedProcCommand, "@CartJobScreenName", DbType.String, txt_jobScreenName);
            database.AddInParameter(storedProcCommand, "@CartJobNameShow", DbType.Boolean, chk_jobScreenNameShow);
            database.AddInParameter(storedProcCommand, "@CartJobNameIsMandatory", DbType.Boolean, chk_jobScreenNameRequired);
            database.AddInParameter(storedProcCommand, "@AttachConNumToUrl", DbType.Boolean, attachConNumToUrl);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderMangerOptions_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OtherCost_WebStore_AllocatetoOtherAccounts(int WebOtherCostID, int AccountID, string AccountType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCost_WebStore_AllocatetoOtherAccounts");
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, WebOtherCostID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@AccountType", DbType.String, AccountType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_Webstore_Delete(int CompanyID, long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_Webstore_Delete");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_Webstore_Delete_Per_Account(int CompanyID, long webothercostid, long AccountID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_Webstore_Delete_Per_Account");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long OtherCost_WebStore_Insertupdate(long webothercostid, long CompanyID, long UserID, string webothercostName, string Description, string UserFriendlyName, long CategoryId, string MainCalculationType, string AdditionalType, int VisibletoCart, int SupplierID, bool IsSubAdditionOption, bool IsMandatory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCost_WebStore_Insertupdate");
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@webothercostName", DbType.String, webothercostName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@CategoryId", DbType.Int64, CategoryId);
            database.AddInParameter(storedProcCommand, "@MainCalculationType", DbType.String, MainCalculationType);
            database.AddInParameter(storedProcCommand, "@AdditionalType", DbType.String, AdditionalType);
            database.AddInParameter(storedProcCommand, "@VisibletoCart", DbType.Int32, VisibletoCart);
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
            database.AddInParameter(storedProcCommand, "@IsSubAdditionOption", DbType.Boolean, IsSubAdditionOption);
            database.AddInParameter(storedProcCommand, "@IsMandatory", DbType.Boolean, IsMandatory);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual long OtherCost_WebStore_Insertupdate_ShopCartCost(long webothercostid, long CompanyID, long UserID, string webothercostName, string Description, string UserFriendlyName, long CategoryId, string MainCalculationType, string AdditionalType, int VisibletoCart, long AccountID, string AllocationStatus, bool IsCartmandatory, bool IsSubAdditionOption)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCost_WebStore_Insertupdate_ShopCartCost");
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@webothercostName", DbType.String, webothercostName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@UserFriendlyName", DbType.String, UserFriendlyName);
            database.AddInParameter(storedProcCommand, "@CategoryId", DbType.Int64, CategoryId);
            database.AddInParameter(storedProcCommand, "@MainCalculationType", DbType.String, MainCalculationType);
            database.AddInParameter(storedProcCommand, "@AdditionalType", DbType.String, AdditionalType);
            database.AddInParameter(storedProcCommand, "@VisibletoCart", DbType.Int32, VisibletoCart);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@AllocationStatus", DbType.String, AllocationStatus);
            database.AddInParameter(storedProcCommand, "@IsCartmandatory", DbType.Boolean, IsCartmandatory);
            database.AddInParameter(storedProcCommand, "@IsSubAdditionOption", DbType.Boolean, IsSubAdditionOption);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataTable OtherCost_WebStore_Select(long webothercostid, long CompanyID, long UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherCost_WebStore_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Othercost_WebstoreChoice_Delete(long webothercostid, long ChoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreChoice_Delete");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int64, ChoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_WebstoreChoice_Insertupdate(long ChoiceID, long webothercostid, string Label, string CalculationType, string Formula, decimal Markup, long InventoryID, int sortorder, int Reorderposition, long GroupID, int SubadditionCount, bool IsMandatoryField)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreChoice_Insertupdate");
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int64, ChoiceID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@Label", DbType.String, Label);
            database.AddInParameter(storedProcCommand, "@CalculationType", DbType.String, CalculationType);
            database.AddInParameter(storedProcCommand, "@Formula", DbType.String, Formula);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
            database.AddInParameter(storedProcCommand, "@sortorder", DbType.Int16, sortorder);
            database.AddInParameter(storedProcCommand, "@Reorderposition", DbType.Int16, Reorderposition);
            database.AddInParameter(storedProcCommand, "@GroupID", DbType.Int64, GroupID);
            database.AddInParameter(storedProcCommand, "@SubadditionCount", DbType.Int32, SubadditionCount);
            database.AddInParameter(storedProcCommand, "@IsMandatoryField", DbType.Boolean, IsMandatoryField);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Othercost_WebstoreChoice_Select(long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreChoice_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Othercost_WebstoreMatrix_Delete(long webothercostid, long MatrixID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreMatrix_Delete");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@MatrixID", DbType.Int64, MatrixID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_WebstoreMatrix_Insertupdate(long MatrixID, long webothercostid, string MatrixType, int FromQuantity, int ToQuantity, decimal Price, decimal Markup, decimal sellingPrice, int Reorderposition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreMatrix_Insertupdate");
            database.AddInParameter(storedProcCommand, "@MatrixID", DbType.Int64, MatrixID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@MatrixType", DbType.String, MatrixType);
            database.AddInParameter(storedProcCommand, "@FromQuantity", DbType.Int32, FromQuantity);
            database.AddInParameter(storedProcCommand, "@ToQuantity", DbType.Int32, ToQuantity);
            database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@sellingPrice", DbType.Decimal, sellingPrice);
            database.AddInParameter(storedProcCommand, "@Reorderposition", DbType.Int32, Reorderposition);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Othercost_WebstoreMatrix_Select(long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreMatrix_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Othercost_WebstoreQuestion_Delete(long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreQuestion_Delete");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_WebstoreQuestion_Insertupdate(long QuestionID, long webothercostid, string Question, string formula)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreQuestion_Insertupdate");
            database.AddInParameter(storedProcCommand, "@QuestionID", DbType.Int64, QuestionID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@Question", DbType.String, Question);
            database.AddInParameter(storedProcCommand, "@formula", DbType.String, formula);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Othercost_WebstoreFreeTextQuestion_Insertupdate(long QuestionID, long webothercostid, string Question, string formula, bool HideAdditionalName,bool chkMandatory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreFreeTextQuestion_Insertupdate");
            database.AddInParameter(storedProcCommand, "@QuestionID", DbType.Int64, QuestionID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@Question", DbType.String, Question);
            database.AddInParameter(storedProcCommand, "@formula", DbType.String, formula);
            database.AddInParameter(storedProcCommand, "@HideAdditionalOptionName", DbType.Boolean, HideAdditionalName);
            database.AddInParameter(storedProcCommand, "@chkMandatory", DbType.Boolean, chkMandatory);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual DataTable Othercost_WebstoreQuestion_Select(long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Othercost_WebstoreQuestion_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherMultiple_DefaultItem_Select(long ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultiple_Default_Select");
            database.AddInParameter(storedProcCommand, "@ProductCatalogueID", DbType.Int64, ProductCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pageDelete(int pageID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pageDelete");
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable pagesDetails(int pageID, int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pagesDetails");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int pagesInsert(int pageID, int companyID, int accountID, string systemName, string pageName, DateTime modifiedDate, int sortOrderID, string pageBody, string metatitle, string metadescription, string metakeywords, char showPagesIn, DateTime createdDate)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pagesInsert");
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@systemName", DbType.String, systemName);
            database.AddInParameter(storedProcCommand, "@pageName", DbType.String, pageName);
            database.AddInParameter(storedProcCommand, "@modifiedDate", DbType.DateTime, modifiedDate);
            database.AddInParameter(storedProcCommand, "@sortOrderID", DbType.Int32, sortOrderID);
            database.AddInParameter(storedProcCommand, "@pageBody", DbType.String, pageBody);
            database.AddInParameter(storedProcCommand, "@metatitle", DbType.String, metatitle);
            database.AddInParameter(storedProcCommand, "@metadescription", DbType.String, metadescription);
            database.AddInParameter(storedProcCommand, "@metakeywords", DbType.String, metakeywords);
            database.AddInParameter(storedProcCommand, "@showPagesIn", DbType.String, showPagesIn);
            database.AddInParameter(storedProcCommand, "@createdDate", DbType.DateTime, createdDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable pagesSelect(int CompanyID, int AccountID, string type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pagesSelect");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pagesSort(int pageID, int companyID, int accountID, int sortOrderID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_pagesSort");
            database.AddInParameter(storedProcCommand, "@pageID", DbType.Int32, pageID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@sortOrderID", DbType.Int32, sortOrderID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void paymentInsert(int PaymentID, int companyID, int accountID, string paymentMode, string defaultPaymentMode, string creaditCardTypes, string CreditCardBrainTreeTypes, string CreditCardStripeTypes, int IsEnable)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_paymentInsert");
            database.AddInParameter(storedProcCommand, "@PaymentID", DbType.Int32, PaymentID);
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@paymentMode", DbType.String, paymentMode);
            database.AddInParameter(storedProcCommand, "@defaultpaymentMode", DbType.String, defaultPaymentMode);
            database.AddInParameter(storedProcCommand, "@creaditCardTypes", DbType.String, creaditCardTypes);
            database.AddInParameter(storedProcCommand, "@creditCardBrainTreeTypes", DbType.String, CreditCardBrainTreeTypes);
            database.AddInParameter(storedProcCommand, "@creditCardStripeTypes", DbType.String, CreditCardStripeTypes);
            database.AddInParameter(storedProcCommand, "@IsEnable", DbType.Int32, IsEnable);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable paymentSelect(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_paymentSelect");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pricecatalogue_Categorycustomer_delete(long PriceCatalogueCategoryID, long PriceCategoryCustomerID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CategoryCustomerAllocation_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, PriceCatalogueCategoryID);
            database.AddInParameter(storedProcCommand, "@PriceCategoryCustomerID", DbType.Int64, PriceCategoryCustomerID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void pricecatalogue_other_delete(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PricecatalogueOtherProduct_Delete");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable pricecatalogue_other_select(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PricecatalogueOtherProduct_Select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherProductStockAllocationExist(long CompanyID, long ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherProductStockAllocationExist");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ProductCatalogueID", DbType.Int64, ProductCatalogueID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable pricecataloguecategory_allocatedcustomer_select(long PriceCatalogueCategoryID, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCataloguecategory_Customer_View");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.String, PriceCatalogueCategoryID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PriceCatalogueCustomer_Delete(long PriceCatalogueID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueCustomer_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void PriceCatalogueCustomer_Insert(long PriceCatalogueID, long CustomerID, long AccountID, string customerType)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueCustomer_Insert");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, CustomerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@CustomerType", DbType.String, customerType);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void PriceCatalogueCustomer_Public_Delete(long PriceCatalogueID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueCustomer_Public_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable PriceCatalogueCustomer_Select(long PriceCatalogueID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogueCustomer_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string pricecataloguestock_actiontype_check(long PricecatalogueID, string From)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStockActionType_Check");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@From", DbType.String, From);
            database.AddOutParameter(storedProcCommand, "@Return", DbType.String, 10);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@Return");
            return (parameterValue == null ? 0.ToString() : parameterValue.ToString());
        }

        public virtual string pricecataloguestock_actiontype_checkAdditional(long ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStockActionType_CheckAdditional");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, ProductCatalogueID);
            database.AddOutParameter(storedProcCommand, "@Return", DbType.String, 10);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@Return");
            return (parameterValue == null ? 0.ToString() : parameterValue.ToString());
        }

        public virtual long pricecataloguestock_additional_insert(int id, string optionname, string optionvalue, int openingstock, string customfield1, string customfield2, string customfield3, string customfield4, string customfield5, string customfield6, int webothercostid, int UserID, DateTime date, decimal price, string actiontype, int choiceid, string Notes)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PricecatalogueAdditional_Insert");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, id);
            database.AddInParameter(storedProcCommand, "@optionname", DbType.String, optionname);
            database.AddInParameter(storedProcCommand, "@optionvalue", DbType.String, optionvalue);
            database.AddInParameter(storedProcCommand, "@NewQuantity", DbType.Int32, openingstock);
            database.AddInParameter(storedProcCommand, "@Customfield1", DbType.String, customfield1);
            database.AddInParameter(storedProcCommand, "@Customfield2", DbType.String, customfield2);
            database.AddInParameter(storedProcCommand, "@Customfield3", DbType.String, customfield3);
            database.AddInParameter(storedProcCommand, "@Customfield4", DbType.String, customfield4);
            database.AddInParameter(storedProcCommand, "@Customfield5", DbType.String, customfield5);
            database.AddInParameter(storedProcCommand, "@Customfield6", DbType.String, customfield6);
            database.AddInParameter(storedProcCommand, "@WebStoreOtherCostID", DbType.String, webothercostid);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@StockEntryDate", DbType.DateTime, date);
            database.AddInParameter(storedProcCommand, "@price", DbType.Decimal, price);
            database.AddInParameter(storedProcCommand, "@Actiontype", DbType.String, actiontype);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, choiceid);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual DataTable pricecataloguestock_additional_select(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PricecatalogueAdditional_Select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pricecataloguestock_AdditionalAdjustments_update(long AdditionalStockID, char Operator, int AdjustQty, long PricecatalogueID, long UserID, string AdjustmentType, long ChoiceID, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_Additional_Adjustment");
            database.AddInParameter(storedProcCommand, "@PricecatalogueStockAdditionalid", DbType.Int64, AdditionalStockID);
            database.AddInParameter(storedProcCommand, "@Operator", DbType.String, Operator);
            database.AddInParameter(storedProcCommand, "@Adjustmentqty", DbType.Int32, AdjustQty);
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@AdjustmentType", DbType.String, AdjustmentType);
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int64, ChoiceID);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, CustomField1);
            database.AddInParameter(storedProcCommand, "@CustomField2", DbType.String, CustomField2);
            database.AddInParameter(storedProcCommand, "@CustomField3", DbType.String, CustomField3);
            database.AddInParameter(storedProcCommand, "@CustomField4", DbType.String, CustomField4);
            database.AddInParameter(storedProcCommand, "@CustomField5", DbType.String, CustomField5);
            database.AddInParameter(storedProcCommand, "@CustomField6", DbType.String, CustomField6);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void pricecataloguestock_additionaloption_Delete(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PricecatalogueStock_Additional_Delete ");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable pricecataloguestock_additionaloptions_stocklevels(long ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_AdditionalOptions_StockLevel_Select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, ProductCatalogueID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pricecataloguestock_adjustments_update(long StockselfID, char Operator, int AdjustQty, long PricecatalogueID, long UserID, string AdjustmentType, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string ManualNotes)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_Self_Adjustment_new");
            database.AddInParameter(storedProcCommand, "@PricecatalogueStockID", DbType.Int64, StockselfID);
            database.AddInParameter(storedProcCommand, "@Operator", DbType.String, Operator);
            database.AddInParameter(storedProcCommand, "@Adjustmentqty", DbType.Int32, AdjustQty);
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@AdjustmentType", DbType.String, AdjustmentType);
            database.AddInParameter(storedProcCommand, "@CustomField1", DbType.String, CustomField1);
            database.AddInParameter(storedProcCommand, "@CustomField2", DbType.String, CustomField2);
            database.AddInParameter(storedProcCommand, "@CustomField3", DbType.String, CustomField3);
            database.AddInParameter(storedProcCommand, "@CustomField4", DbType.String, CustomField4);
            database.AddInParameter(storedProcCommand, "@CustomField5", DbType.String, CustomField5);
            database.AddInParameter(storedProcCommand, "@CustomField6", DbType.String, CustomField6);
            database.AddInParameter(storedProcCommand, "@ManualNotes", DbType.String, ManualNotes);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet pricecataloguestock_history_select(long ProductCatalogueID, int PageSize, int PageNumber, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("PC_Select_ProductStock_History", sqlConnection);
            sqlCommand.CommandTimeout = 180;
            sqlCommand.Parameters.AddWithValue("@PricecatalogueID", ProductCatalogueID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            DataSet dataSet = new DataSet();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void pricecataloguestock_other_insert(int ProductCatalogueID, long kititemid, int unit, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_PriceCatalogueStock_Other_Insert]");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, kititemid);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, unit);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void pricecataloguestock_other_update(int id,int ProductCatalogueID, long kititemid, int unit, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_PriceCatalogueStock_Other_Update]");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, id);
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, kititemid);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, unit);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void pricecataloguestock_other_delete(int id)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_PriceCatalogueStock_Other_Delete]");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, id);
            database.ExecuteNonQuery(storedProcCommand);
        }
        public virtual void pricecataloguestock_othermultiple_insert(int ProductCatalogueID, long KitItemID, int isdefault, int UserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Settings_PriceCatalogueStock_OtherMultiple_Insert");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@KitItemID", DbType.Int64, KitItemID);
            database.AddInParameter(storedProcCommand, "@IsDefault", DbType.Int32, isdefault);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Pricecataloguestock_Othermultiple_select(long PricecatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Pricecataloguestock_OtherMultiple_Select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int64, PricecatalogueID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pricecataloguestock_Quantity_Update(long ProductCatalogueID, int TotalQuantity, int AvailableQuantity, int AllocatedQuantity)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Stockqty_Pricecatalogue_Update");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@TotalQuantity", DbType.Int32, TotalQuantity);
            database.AddInParameter(storedProcCommand, "@AvailableQuantity", DbType.Int32, AvailableQuantity);
            database.AddInParameter(storedProcCommand, "@AllocatedQuantity", DbType.Int32, AllocatedQuantity);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void pricecataloguestock_self_delete(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_priceCatalogueStock_Self_Delete]");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long pricecataloguestock_self_insert(int PricecatalogueID, int openingstock, string Customfield1, string Customfield2, string Customfield3, string Customfield4, string Customfield5, string Customfield6, decimal Price, int UserID, DateTime date, string actiontype, string Notes,string ManualNotes)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_ProductStock_Self_Insert]");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, PricecatalogueID);
            database.AddInParameter(storedProcCommand, "@openingstock", DbType.Int32, openingstock);
            database.AddInParameter(storedProcCommand, "@Customfield1", DbType.String, Customfield1);
            database.AddInParameter(storedProcCommand, "@Customfield2", DbType.String, Customfield2);
            database.AddInParameter(storedProcCommand, "@Customfield3", DbType.String, Customfield3);
            database.AddInParameter(storedProcCommand, "@Customfield4", DbType.String, Customfield4);
            database.AddInParameter(storedProcCommand, "@Customfield5", DbType.String, Customfield5);
            database.AddInParameter(storedProcCommand, "@Customfield6", DbType.String, Customfield6);
            database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, UserID);
            database.AddInParameter(storedProcCommand, "@StockEntryDate", DbType.DateTime, date);
            database.AddInParameter(storedProcCommand, "@Actiontype", DbType.String, actiontype);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@ManualNotes", DbType.String, ManualNotes);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (long)((parameterValue == null ? 0 : int.Parse(parameterValue.ToString())));
        }

        public virtual DataTable pricecataloguestock_self_select(int ProductCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockSelfAdjustment_select");
            database.AddInParameter(storedProcCommand, "@PricecatalogueID", DbType.Int32, ProductCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void pricecataloguestock_stockdetails_update(int ProductCatalogueID, string DrawStockFrom, int ReorderLevel, int ReorderQty, string AlertUser, string UserEmail, int TotalQuantity, int AllocatedQuantity, int AvailableQuantity, bool IsEnableSubDetail)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_settings_pricecatalogue_update");
            database.AddInParameter(storedProcCommand, "@pricecatalogueid", DbType.Int32, ProductCatalogueID);
            database.AddInParameter(storedProcCommand, "@drawfromstock", DbType.String, DrawStockFrom);
            database.AddInParameter(storedProcCommand, "@reorderlevel", DbType.String, ReorderLevel);
            database.AddInParameter(storedProcCommand, "@reorderquantity", DbType.Int32, ReorderQty);
            database.AddInParameter(storedProcCommand, "@alertuser", DbType.String, AlertUser);
            database.AddInParameter(storedProcCommand, "@alertuseremail", DbType.String, UserEmail);
            database.AddInParameter(storedProcCommand, "@totalquantity", DbType.String, TotalQuantity);
            database.AddInParameter(storedProcCommand, "@allocatedquantity", DbType.String, AllocatedQuantity);
            database.AddInParameter(storedProcCommand, "@availablequantity", DbType.String, AvailableQuantity);
            database.AddInParameter(storedProcCommand, "@IsEnableSubDetail", DbType.Boolean, IsEnableSubDetail);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Product_CatalogueCouponCode_insert(int CompanyID, long PriceCatalogueID, long CouponCodeID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogue_CouponCode_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CouponCodeID", DbType.Int64, CouponCodeID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Product_CatalogueCouponCode_Select(long CompanyID, long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogue_CouponCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void ProductCatalogue_CouponCode_Delete(long CompanyID, long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogue_CouponCode_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual int ProductCatalogueCategory_Insert_Update(long PriceCatalogueCategoryID, string catagoryName, string description, string catagoryType, int companyID, long userID, string catagoryImage, long ParentCategoryID, int IsCategoryVisible, bool Isallocated, bool IsApprovalNotRequired)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategory_Insert_Update");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, PriceCatalogueCategoryID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryName", DbType.String, catagoryName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, description);
            database.AddInParameter(storedProcCommand, "@CategoryType", DbType.String, catagoryType);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, userID);
            database.AddInParameter(storedProcCommand, "@CategoryImage", DbType.String, catagoryImage);
            database.AddInParameter(storedProcCommand, "@ParentCategoryID", DbType.Int64, ParentCategoryID);
            database.AddInParameter(storedProcCommand, "@IsCategoryVisible", DbType.Int32, IsCategoryVisible);
            database.AddInParameter(storedProcCommand, "@Isallocated", DbType.Boolean, Isallocated);
            database.AddInParameter(storedProcCommand, "@IsApprovalNotRequired", DbType.Boolean, IsApprovalNotRequired);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable ProductCatalogueCategory_Select(int category)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategory_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, category);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet ProductCatalogueCategory_SelectViewAll(int companyID, int userID, string sortedBy, string sortdirection, string whereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_ProductCatalogueCategory_SelectViewAll", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", companyID);
            sqlCommand.Parameters.AddWithValue("@UserID", userID);
            sqlCommand.Parameters.AddWithValue("@sortedBy", sortedBy);
            sqlCommand.Parameters.AddWithValue("@sortdirection", sortdirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", whereCondition);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void ProductCatalogueCategory_UpdateImage(int CategoryID, string catagoryImage)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategory_UpdateImage");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, CategoryID);
            database.AddInParameter(storedProcCommand, "@CategoryImage", DbType.String, catagoryImage);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void ProductCatalogueCategoryCustomer_Delete(long categoryID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategoryCustomer_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, categoryID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual long ProductCatalogueCategoryCustomer_Insert(long categoryID, long customerID, long accountID, string catagoryType, long DepartmentID, string DeptAllocationType)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategoryCustomer_Insert");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, categoryID);
            database.AddInParameter(storedProcCommand, "@CustomerID", DbType.Int64, customerID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, accountID);
            database.AddInParameter(storedProcCommand, "@catagoryType", DbType.String, catagoryType);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.AddInParameter(storedProcCommand, "@DepartmentAllocationType", DbType.String, DeptAllocationType);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void ProductCatalogueCategoryCustomer_Public_Delete(long categoryID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategoryCustomer_Public_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, categoryID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable ProductCatalogueCategoryCustomer_Select(long categoryID, long accountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategoryCustomer_Select");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, categoryID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, accountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int ProductCatalogueGroup_Insert(long ProductWebOtherCostid, long GroupID, long WebOthercostID, bool IsAllocated, string WebOtherCostName)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueGroupOptions_Insert");
            database.AddInParameter(storedProcCommand, "@PricatalogueGroupID", DbType.Int32, GroupID);
            database.AddInParameter(storedProcCommand, "@ProductWebOtherCostid", DbType.Int32, ProductWebOtherCostid);
            database.AddInParameter(storedProcCommand, "@WebOthercostID", DbType.Int32, WebOthercostID);
            database.AddInParameter(storedProcCommand, "@IsAllocated", DbType.Boolean, IsAllocated);
            database.AddInParameter(storedProcCommand, "@WebOtherCostName", DbType.String, WebOtherCostName);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable ProductCatalogueGroup_SelectViewAll(int CompanyID, long PriceCatalogueGroupID, string searchgroupName)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueGroup_SelectViewAll");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueGroupID", DbType.Int64, PriceCatalogueGroupID);
            database.AddInParameter(storedProcCommand, "@searchgroupName", DbType.String, searchgroupName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable JobItem_Select(int CompanyID, string jobItem, long StatusId)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Select_estimate_item_Details_ByJobItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobItem", DbType.String, jobItem);
            database.AddInParameter(storedProcCommand, "@StatusId", DbType.Int64, StatusId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable JobItemStatus_Select(int CompanyID, string statustitle)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Select_estimate_item_status_ByJobStatusTitle");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusTitle", DbType.String, statustitle);            
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void ProductCategory_CustomerDepartment_insert(long PriceCategoryCustomerID, long DepartmentID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCategoryCustomer_Department_Allocation_insert");
            database.AddInParameter(storedProcCommand, "@PriceCategoryCustomerID", DbType.Int64, PriceCategoryCustomerID);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void productCategory_Delete(int categoryID)
        {
            long num = (long)0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
            }
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductCatalogueCategory_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int32, categoryID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void productGroup_Delete(int GroupID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("GroupSubAdditionalOptions_delete");
            database.AddInParameter(storedProcCommand, "@PricatalogueGroupID", DbType.Int32, GroupID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void ProductGroupSubAdditionalOptions_Delete(long PriceCatalogueGroupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductGroupSubAdditionalOptions_Delete");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueGroupID", DbType.Int64, PriceCatalogueGroupID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet ProductJobList_Select(long PriceCatalogueID, string SearchParameter)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_StockManualRelease_select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PriceCatalogueID", PriceCatalogueID);
            sqlCommand.Parameters.AddWithValue("@SearchParameter", SearchParameter);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable products_Select(long CompanyID, long AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_products_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable products_Select_Select_Basedon_CatID(long CompanyID, long AccountID, long PriceCatalogueCategoryID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_products_Select_Select_Basedon_CatID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, PriceCatalogueCategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void ProductsReorder_Delete(long CompanyID, long AccountID, int key,int catid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductsReorder_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, key);
            database.AddInParameter(storedProcCommand, "@CatID", DbType.Int32, catid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void ProductsReorder_Insert_Update(int CompanyID, int AccountID, int PriceCatalogueID, int SortOrderNo, int ClientID ,int CatID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductsReorder_Insert_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@SortOrderNo", DbType.Int32, SortOrderNo);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@CatID", DbType.Int32, CatID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable PublicAccount_List_Select(long CompanyID, string accounttype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PublicAccountList_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@accounttype", DbType.String, accounttype);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PublicSettings_Options(int accountID, int Order_Check, int Address_Check)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_PublicDisplay_Setting");
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@isCheckOrderInfoPublic", DbType.Int32, Order_Check);
            database.AddInParameter(storedProcCommand, "@isCheckAddressInfo", DbType.Int32, Address_Check);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable RestrictedUser(long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Restricted_User");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Retaining_ShopCartCostDetails_To_OtherAccounts(long webothercostid, long CompanyID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Retaining_ShopCartCostDetails_To_OtherAccounts");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Select_ConsignmentNote(long StoreUserID, long OrderID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ConsigneURL");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.String, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Custom_OR_Alphbetic_Order(long CompanyID, long AccountID, string Module)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Custom_or_Alphbetic_Order");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Select_Inventory_PopUp_Select(int CompanyID, string ItemType, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Inventory_PopUp_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ItemType", DbType.String, ItemType);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, PageSize);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, PageNumber);
            database.AddInParameter(storedProcCommand, "@SortBy", DbType.String, SortBy);
            database.AddInParameter(storedProcCommand, "@SortDirection", DbType.String, SortDirection);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable Select_InventoryProperties(int CompanyID, long InventoryID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_InventoryProperties");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@InventoryID", DbType.Int64, InventoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet select_ItemDetalis_ForProduct(int CompanyID, long EstimateID, long EstItemID, string EstType)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_select_ItemDetalis_ForProduct", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@EstimateID", EstimateID);
            sqlCommand.Parameters.AddWithValue("@EstimateItemID", EstItemID);
            sqlCommand.Parameters.AddWithValue("@EstimateType", EstType);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Select_OrderAdditionalItems(long OrderItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalItems");
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderAdditionalOptions(long StoreUserID, long OrderID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalOptions");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.String, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderItems");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ProductCategory_based_on_accountid(long CompanyID, string PageType, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ProductCategory_based_on_catid_accountid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
            database.AddInParameter(storedProcCommand, "@accountid", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ProductCategory_List(long CompanyID, string PageType, long PriceCatalogueCategoryID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_ProductCategory_List");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PageType", DbType.String, PageType);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueCategoryID", DbType.Int64, PriceCatalogueCategoryID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ProductDetailsTag(int CompanyID, int AccountID, long EmailToCustomerID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_GetProductDetailsTag");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            database.AddInParameter(storedProcCommand, "@EmailToCustomerID", DbType.Int64, EmailToCustomerID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Select_WebOtherCostID(int GroupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_WebOtherCostType");
            database.AddInParameter(storedProcCommand, "@GroupID", DbType.Int32, GroupID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string SelectAccountType(int AccountID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand(string.Concat("SELECT AccountType FROM tb_accounts WHERE AccountID = ", AccountID), sqlConnection)
            {
                CommandType = CommandType.Text
            };
            string str1 = (string)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            return str1;
        }

        public virtual DataTable SelectRadioButtonStatus(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_select_radiobuttonstatus");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int Settings_Product_Catalogue_InsertUpdate(int CompanyID, int PriceCatalogueID, string itemcode, string CategoryName, string CatalogueName, string Description, int UserID, int PriceCatalogueCategoryID, string ItemTitle, string Artwork, string Color, string Size, string Material, string Delivery, string Finishing, string Notes, string Terms, string MatrixType, string Proofs, string Packing, string ProductImage, string ArtworkFile, int ProductVisible, string ShortDescription, string ItemDescription, int UnitOfMeasure, int ArtworkCount, string CustomerType, int IsSides, int IsPrintReadyFile, int IsShortDescription, int IsItemDescription, int IsPriceStartFrom, int IsPriceList, bool IsUploadMandatory, int SupplierID, string CustomDescription1, string CustomDescription2, string CustomDescription3, string CustomDescription4, string CustomDescription5, string CustomDescription6, string CustomDescription7, string CustomDescription8, string CustomDescription9, string CustomDescription10, string CustomDescription11, string CustomDescription12, string CustomDescription13, string CustomDescription14, string CustomDescription15, string CustomDescription16, string CustomDescription17, string CustomDescription18, string CustomDescription19, string CustomDescription20, string CustomDescription21, string CustomDescription22, string CustomDescription23, string CustomDescription24, string CustomDescription25, int IsEditableProduct, int IsStockItem, int IsBackOrder, int IsShowStock, int OwnerID, long EstItemID, string EstType, string CustomerCode, int SoldInPacks, int IsShowSoldInPacks, bool AllowGroupRun, bool isCustomercode, bool isItemcode, int IsShowPriceSubtotalTax, int IsShowUnitPrice, int IsShowPackPrice, bool IsShowJobName, bool isQuickitemadd, bool isAddtoCartandStay, bool IsCumulativePricing, bool IsDisplayAdditionalOptions,
            string drawStockFrom, int SalesTaxRate, int PressID, int DefaultPreflightProfile, string Decoration1_Title, string Decoration2_Title, string Decoration3_Title, string Decoration4_Title, string Decoration5_Title, string Decoration6_Title, string Decoration1_Name, string Decoration2_Name, string Decoration3_Name, string Decoration4_Name, string Decoration5_Name, string Decoration6_Name, string Decoration1_Description, string Decoration2_Description, string Decoration3_Description, string Decoration4_Description, string Decoration5_Description, string Decoration6_Description, double Decoration1_SetupCost, double Decoration2_SetupCost, double Decoration3_SetupCost, double Decoration4_SetupCost, double Decoration5_SetupCost, double Decoration6_SetupCost, double Decoration1_PerItemCost, double Decoration2_PerItemCost, double Decoration3_PerItemCost, double Decoration4_PerItemCost, double Decoration5_PerItemCost, double Decoration6_PerItemCost, double Decoration1_MinimiumCost, double Decoration2_MinimiumCost, double Decoration3_MinimiumCost, double Decoration4_MinimiumCost, double Decoration5_MinimiumCost, double Decoration6_MinimiumCost, Boolean Decoration1_Mandadory, Boolean Decoration2_Mandadory, Boolean Decoration3_Mandadory, Boolean Decoration4_Mandadory, Boolean Decoration5_Mandadory, Boolean Decoration6_Mandadory,long FTPFolderID,string Prefix,string FTPFileName,string FTPFileType, int AccountingCode = 0, int isWaterMarkReady = 0, string waterMarkText = "", double CBMHeight = 0.00, double CBMWidth = 0.00, double CBMLength = 0.00, double CBMWeight = 0.00, double CBMMeasurement = 0.00, bool IsCBM = false, int PurAccountingCode = 0, double PerQuantity = 0.00, double VolumetricWeight = 0.00)
        {
            long num = (long)0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_Product_Catalogue_InsertUpdate]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@itemcode", DbType.String, itemcode);
            database.AddInParameter(storedProcCommand, "@CategoryName", DbType.String, CategoryName);
            database.AddInParameter(storedProcCommand, "@CatalogueName", DbType.String, CatalogueName);
            database.AddInParameter(storedProcCommand, "@Description", DbType.String, Description);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, Convert.ToInt32(UserID));
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
            database.AddInParameter(storedProcCommand, "@Proofs", DbType.String, Proofs);
            database.AddInParameter(storedProcCommand, "@Packing", DbType.String, Packing);
            database.AddInParameter(storedProcCommand, "@ProductImage", DbType.String, ProductImage);
            database.AddInParameter(storedProcCommand, "@ArtworkFile", DbType.String, ArtworkFile);
            database.AddInParameter(storedProcCommand, "@ProductVisible", DbType.Int16, ProductVisible);
            database.AddInParameter(storedProcCommand, "@ShortDescription", DbType.String, ShortDescription);
            database.AddInParameter(storedProcCommand, "@ItemDescription", DbType.String, ItemDescription);
            database.AddInParameter(storedProcCommand, "@UnitOfMeasure", DbType.Int32, UnitOfMeasure);
            database.AddInParameter(storedProcCommand, "@ArtworkCount", DbType.Int32, ArtworkCount);
            database.AddInParameter(storedProcCommand, "@CustomerType", DbType.String, CustomerType);
            database.AddInParameter(storedProcCommand, "@IsSides", DbType.Int32, IsSides);
            database.AddInParameter(storedProcCommand, "@IsPrintReadyFile", DbType.Int32, IsPrintReadyFile);
            database.AddInParameter(storedProcCommand, "@IsShortDescription", DbType.Int32, IsShortDescription);
            database.AddInParameter(storedProcCommand, "@IsItemDescription", DbType.Int32, IsItemDescription);
            database.AddInParameter(storedProcCommand, "@IsPriceStartFrom", DbType.Int32, IsPriceStartFrom);
            database.AddInParameter(storedProcCommand, "@IsPriceList", DbType.Int32, IsPriceList);
            database.AddInParameter(storedProcCommand, "@IsUploadMandatory", DbType.Boolean, IsUploadMandatory);
            database.AddInParameter(storedProcCommand, "@SupplierID", DbType.Int32, SupplierID);
            database.AddInParameter(storedProcCommand, "@CustomDescription1", DbType.String, CustomDescription1);
            database.AddInParameter(storedProcCommand, "@CustomDescription2", DbType.String, CustomDescription2);
            database.AddInParameter(storedProcCommand, "@CustomDescription3", DbType.String, CustomDescription3);
            database.AddInParameter(storedProcCommand, "@CustomDescription4", DbType.String, CustomDescription4);
            database.AddInParameter(storedProcCommand, "@CustomDescription5", DbType.String, CustomDescription5);
            database.AddInParameter(storedProcCommand, "@CustomDescription6", DbType.String, CustomDescription6);
            database.AddInParameter(storedProcCommand, "@CustomDescription7", DbType.String, CustomDescription7);
            database.AddInParameter(storedProcCommand, "@CustomDescription8", DbType.String, CustomDescription8);
            database.AddInParameter(storedProcCommand, "@CustomDescription9", DbType.String, CustomDescription9);
            database.AddInParameter(storedProcCommand, "@CustomDescription10", DbType.String, CustomDescription10);
            database.AddInParameter(storedProcCommand, "@CustomDescription11", DbType.String, CustomDescription11);
            database.AddInParameter(storedProcCommand, "@CustomDescription12", DbType.String, CustomDescription12);
            database.AddInParameter(storedProcCommand, "@CustomDescription13", DbType.String, CustomDescription13);
            database.AddInParameter(storedProcCommand, "@CustomDescription14", DbType.String, CustomDescription14);
            database.AddInParameter(storedProcCommand, "@CustomDescription15", DbType.String, CustomDescription15);
            database.AddInParameter(storedProcCommand, "@CustomDescription16", DbType.String, CustomDescription16);
            database.AddInParameter(storedProcCommand, "@CustomDescription17", DbType.String, CustomDescription17);
            database.AddInParameter(storedProcCommand, "@CustomDescription18", DbType.String, CustomDescription18);
            database.AddInParameter(storedProcCommand, "@CustomDescription19", DbType.String, CustomDescription19);
            database.AddInParameter(storedProcCommand, "@CustomDescription20", DbType.String, CustomDescription20);
            database.AddInParameter(storedProcCommand, "@CustomDescription21", DbType.String, CustomDescription21);
            database.AddInParameter(storedProcCommand, "@CustomDescription22", DbType.String, CustomDescription22);
            database.AddInParameter(storedProcCommand, "@CustomDescription23", DbType.String, CustomDescription23);
            database.AddInParameter(storedProcCommand, "@CustomDescription24", DbType.String, CustomDescription24);
            database.AddInParameter(storedProcCommand, "@CustomDescription25", DbType.String, CustomDescription25);
            database.AddInParameter(storedProcCommand, "@IsEditableProduct", DbType.Int32, IsEditableProduct);
            database.AddInParameter(storedProcCommand, "@IsStockItem", DbType.Int32, IsStockItem);
            database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Int32, IsBackOrder);
            database.AddInParameter(storedProcCommand, "@IsShowStock", DbType.Int32, IsShowStock);
            database.AddInParameter(storedProcCommand, "@OwnerID", DbType.Int32, OwnerID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstItemID);
            database.AddInParameter(storedProcCommand, "@EstimateType", DbType.String, EstType);
            database.AddInParameter(storedProcCommand, "@CustomerCode", DbType.String, CustomerCode);
            database.AddInParameter(storedProcCommand, "@SoldInPacksof", DbType.Int32, SoldInPacks);
            database.AddInParameter(storedProcCommand, "@IsShowSoldInPacksof", DbType.Int32, IsShowSoldInPacks);
            database.AddInParameter(storedProcCommand, "@AllowGroupRun", DbType.Boolean, AllowGroupRun);
            database.AddInParameter(storedProcCommand, "@IsCustomerCode", DbType.Boolean, isCustomercode);
            database.AddInParameter(storedProcCommand, "@IsItemCode", DbType.Boolean, isItemcode);
            database.AddInParameter(storedProcCommand, "@IsShowPriceSubtotalTax", DbType.Int32, IsShowPriceSubtotalTax);
            database.AddInParameter(storedProcCommand, "@IsShowUnitPrice", DbType.Int32, IsShowUnitPrice);
            database.AddInParameter(storedProcCommand, "@IsShowPackPrice", DbType.Int32, IsShowPackPrice);
            database.AddInParameter(storedProcCommand, "@IsShowJobName", DbType.Boolean, IsShowJobName);

            database.AddInParameter(storedProcCommand, "@IsQuickItem", DbType.Boolean, isQuickitemadd);
            database.AddInParameter(storedProcCommand, "@isAddtoCartandStay", DbType.Boolean, isAddtoCartandStay);
            database.AddInParameter(storedProcCommand, "@IsCumulativePricing", DbType.Boolean, IsCumulativePricing);
            database.AddInParameter(storedProcCommand, "@IsDisplayAdditionalOptions", DbType.Boolean, IsDisplayAdditionalOptions);
            database.AddInParameter(storedProcCommand, "@drawStockFrom", DbType.String, drawStockFrom);
            database.AddInParameter(storedProcCommand, "@SalesTaxRate", DbType.Int32, SalesTaxRate);
            database.AddInParameter(storedProcCommand, "@PressId", DbType.Int32, PressID);
            database.AddInParameter(storedProcCommand, "@PreflightProfile", DbType.Int32, DefaultPreflightProfile);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.AddInParameter(storedProcCommand, "@AccountingCode", DbType.Int64, AccountingCode);

            database.AddInParameter(storedProcCommand, "@PrintReadyFileWaterMarkText", DbType.String, waterMarkText);
            database.AddInParameter(storedProcCommand, "@IsPrintReadyFileWaterMark", DbType.Int64, isWaterMarkReady);
            database.AddInParameter(storedProcCommand, "@CBMHeight", DbType.Double, CBMHeight);
            database.AddInParameter(storedProcCommand, "@CBMWidth", DbType.Double, CBMWidth);
            database.AddInParameter(storedProcCommand, "@CBMLength", DbType.Double, CBMLength);
            database.AddInParameter(storedProcCommand, "@CBMWeight", DbType.Double, CBMWeight);
            database.AddInParameter(storedProcCommand, "@CBMMeasurement", DbType.Double, CBMMeasurement);
            database.AddInParameter(storedProcCommand, "@IsCBM", DbType.Boolean, IsCBM);
            database.AddInParameter(storedProcCommand, "@PurAccountingCode", DbType.Int64, PurAccountingCode);
            database.AddInParameter(storedProcCommand, "@Decoration1_Title", DbType.String, Decoration1_Title);
            database.AddInParameter(storedProcCommand, "@Decoration2_Title", DbType.String, Decoration2_Title);
            database.AddInParameter(storedProcCommand, "@Decoration3_Title", DbType.String, Decoration3_Title);
            database.AddInParameter(storedProcCommand, "@Decoration4_Title", DbType.String, Decoration4_Title);
            database.AddInParameter(storedProcCommand, "@Decoration5_Title", DbType.String, Decoration5_Title);
            database.AddInParameter(storedProcCommand, "@Decoration6_Title", DbType.String, Decoration6_Title);

            database.AddInParameter(storedProcCommand, "@Decoration1_Name", DbType.String, Decoration1_Name);
            database.AddInParameter(storedProcCommand, "@Decoration2_Name", DbType.String, Decoration2_Name);
            database.AddInParameter(storedProcCommand, "@Decoration3_Name", DbType.String, Decoration3_Name);
            database.AddInParameter(storedProcCommand, "@Decoration4_Name", DbType.String, Decoration4_Name);
            database.AddInParameter(storedProcCommand, "@Decoration5_Name", DbType.String, Decoration5_Name);
            database.AddInParameter(storedProcCommand, "@Decoration6_Name", DbType.String, Decoration6_Name);

            database.AddInParameter(storedProcCommand, "@Decoration1_Description", DbType.String, Decoration1_Description);
            database.AddInParameter(storedProcCommand, "@Decoration2_Description", DbType.String, Decoration2_Description);
            database.AddInParameter(storedProcCommand, "@Decoration3_Description", DbType.String, Decoration3_Description);
            database.AddInParameter(storedProcCommand, "@Decoration4_Description", DbType.String, Decoration4_Description);
            database.AddInParameter(storedProcCommand, "@Decoration5_Description", DbType.String, Decoration5_Description);
            database.AddInParameter(storedProcCommand, "@Decoration6_Description", DbType.String, Decoration6_Description);

            database.AddInParameter(storedProcCommand, "@Decoration1_SetupCost", DbType.Double, Decoration1_SetupCost);
            database.AddInParameter(storedProcCommand, "@Decoration2_SetupCost", DbType.Double, Decoration2_SetupCost);
            database.AddInParameter(storedProcCommand, "@Decoration3_SetupCost", DbType.Double, Decoration3_SetupCost);
            database.AddInParameter(storedProcCommand, "@Decoration4_SetupCost", DbType.Double, Decoration4_SetupCost);
            database.AddInParameter(storedProcCommand, "@Decoration5_SetupCost", DbType.Double, Decoration5_SetupCost);
            database.AddInParameter(storedProcCommand, "@Decoration6_SetupCost", DbType.Double, Decoration6_SetupCost);

            database.AddInParameter(storedProcCommand, "@Decoration1_PerItemCost", DbType.Double, Decoration1_PerItemCost);
            database.AddInParameter(storedProcCommand, "@Decoration2_PerItemCost", DbType.Double, Decoration2_PerItemCost);
            database.AddInParameter(storedProcCommand, "@Decoration3_PerItemCost", DbType.Double, Decoration3_PerItemCost);
            database.AddInParameter(storedProcCommand, "@Decoration4_PerItemCost", DbType.Double, Decoration4_PerItemCost);
            database.AddInParameter(storedProcCommand, "@Decoration5_PerItemCost", DbType.Double, Decoration5_PerItemCost);
            database.AddInParameter(storedProcCommand, "@Decoration6_PerItemCost", DbType.Double, Decoration6_PerItemCost);

            database.AddInParameter(storedProcCommand, "@Decoration1_MinimiumCost", DbType.Double, Decoration1_MinimiumCost);
            database.AddInParameter(storedProcCommand, "@Decoration2_MinimiumCost", DbType.Double, Decoration2_MinimiumCost);
            database.AddInParameter(storedProcCommand, "@Decoration3_MinimiumCost", DbType.Double, Decoration3_MinimiumCost);
            database.AddInParameter(storedProcCommand, "@Decoration4_MinimiumCost", DbType.Double, Decoration4_MinimiumCost);
            database.AddInParameter(storedProcCommand, "@Decoration5_MinimiumCost", DbType.Double, Decoration5_MinimiumCost);
            database.AddInParameter(storedProcCommand, "@Decoration6_MinimiumCost", DbType.Double, Decoration6_MinimiumCost);

            database.AddInParameter(storedProcCommand, "@Decoration1_Mandadory", DbType.Boolean, Decoration1_Mandadory);
            database.AddInParameter(storedProcCommand, "@Decoration2_Mandadory", DbType.Boolean, Decoration2_Mandadory);
            database.AddInParameter(storedProcCommand, "@Decoration3_Mandadory", DbType.Boolean, Decoration3_Mandadory);
            database.AddInParameter(storedProcCommand, "@Decoration4_Mandadory", DbType.Boolean, Decoration4_Mandadory);
            database.AddInParameter(storedProcCommand, "@Decoration5_Mandadory", DbType.Boolean, Decoration5_Mandadory);
            database.AddInParameter(storedProcCommand, "@Decoration6_Mandadory", DbType.Boolean, Decoration6_Mandadory);
            database.AddInParameter(storedProcCommand, "@PerQuantity", DbType.Double, PerQuantity);
            database.AddInParameter(storedProcCommand, "@VolumetricWeight", DbType.Double, VolumetricWeight);
            database.AddInParameter(storedProcCommand, "@FTPFolderID", DbType.Int64, FTPFolderID);
            database.AddInParameter(storedProcCommand, "@Prefix", DbType.String, Prefix);
            database.AddInParameter(storedProcCommand, "@FTPFileName", DbType.String, FTPFileName);
            database.AddInParameter(storedProcCommand, "@FTPFileType", DbType.String, FTPFileType);


            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataTable Settings_Product_Catalogue_Select(int CompanyID, int PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_Product_Catalogue_Select]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_Product_CatalogueAdditional_Delete(long CompanyID, long PriceCatalogueID, string WebOtherCostIDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_CatalogueAdditional_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostIDs", DbType.String, Convert.ToString(WebOtherCostIDs));
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_Product_CatalogueAdditional_insert(int CompanyID, long PriceCatalogueID, long WebOtherCostID, long AdditionalGroupID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_Product_CatalogueAdditional_insert]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            database.AddInParameter(storedProcCommand, "@AdditionalGroupID", DbType.Int64, AdditionalGroupID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_Product_CatalogueAdditional_Select(long CompanyID, long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_Product_CatalogueAdditional_Select]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void settings_Product_CatalogueImage_Update(long CompanyID, long PriceCatalogueID, string ProductImage, string ImageOrPdfFile, bool ForceUser, string ReportFileName)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_CatalogueImage_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@ProductImage", DbType.String, ProductImage);
            database.AddInParameter(storedProcCommand, "@ImageOrPdfFile", DbType.String, ImageOrPdfFile);
            database.AddInParameter(storedProcCommand, "@ForceUser", DbType.Boolean, ForceUser);
            database.AddInParameter(storedProcCommand, "@ReportFileName", DbType.String, ReportFileName);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Settings_Product_CatalogueQty_delete(int PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_Settings_Product_CatalogueQty_delete]");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void settings_Product_CatalogueQty_insert(int CompanyID, int PriceCatalogueID, decimal FromQuantity, decimal ToQuantity, decimal Price, decimal Markup, decimal SellingPrice, decimal Weight, decimal Width, decimal Height, decimal Length,bool HideOnEStore)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_settings_Product_CatalogueQty_insert]");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@FromQuantity", DbType.Decimal, FromQuantity);
            database.AddInParameter(storedProcCommand, "@ToQuantity", DbType.Decimal, ToQuantity);
            database.AddInParameter(storedProcCommand, "@Price", DbType.Decimal, Price);
            database.AddInParameter(storedProcCommand, "@Markup", DbType.Decimal, Markup);
            database.AddInParameter(storedProcCommand, "@SellingPrice", DbType.Decimal, SellingPrice);
            database.AddInParameter(storedProcCommand, "@Weight", DbType.Decimal, Weight);
            database.AddInParameter(storedProcCommand, "@Width", DbType.Decimal, Width);
            database.AddInParameter(storedProcCommand, "@Height", DbType.Decimal, Height);
            database.AddInParameter(storedProcCommand, "@Length", DbType.Decimal, Length);
            database.AddInParameter(storedProcCommand, "@HideOnEStore", DbType.Boolean, HideOnEStore);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable settings_Product_CatalogueQty_Select(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_CatalogueQty_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_Product_Matrix_EnableCheck(long PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_Product_Matrix_EnableCheck");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int settingsWeb_othercostduplicacy_check(long CompanyID, string webothercostName, long webothercostid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settingsWeb_othercostduplicacy_check");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@webothercostName", DbType.String, webothercostName);
            database.AddInParameter(storedProcCommand, "@webothercostid", DbType.Int64, webothercostid);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual long SettingsWebStore_OtherCost_Copy(int CompanyID, long WebOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SettingsWebStore_OtherCost_Copy");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual long SettingsWebStore_OtherCost_Copy_ShopCartCost(int CompanyID, long WebOtherCostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SettingsWebStore_OtherCost_Copy_ShopCartCost");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int64, WebOtherCostID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataSet SettingsWebStore_OtherCost_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string AdditionalType, bool IsSubAdditionOption)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_SettingsWebStore_OtherCost_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@AdditionalType", AdditionalType);
            sqlCommand.Parameters.AddWithValue("@IsSubAdditionOption", IsSubAdditionOption);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataSet SettingsWebStore_OtherCost_PageText_ShopCartCost(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition, string AdditionalType, long AccountID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_SettingsWebStore_OtherCost_PageText_ShopCartCost", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@AdditionalType", AdditionalType);
            sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual void ShowOrderInformation_Update(long accountId, long companyId, string lbl_OrderTitle, string lbl_OrdNum, string lbl_DelReq, string lbl_Comments, string lbl_costcenter, string txt_OrdTit_Screen, string txt_OrdNum_Screen, string txt_DelReq_Screen, string txt_Comments_Screen, string txt_costcenter_screen, bool chk_OrdTit_Show, bool chk_OrdNum_Show, bool chk_DelReq_Show, bool chek_Comments_Show, bool chk_OrdTit_Req, bool chk_OrdNum_Req, bool chk_DelReq_Req, bool chk_Comments_Req, bool chkCostCenter_Req, bool Chk_Mandotory_Del, bool chk_Mandotory_Inv, bool Chk_Display_Del, bool Chk_Display_Inv, bool chk_EnableOrder, bool Chk_EnableAddress, int EstimateDelivery, int ddlWorkingdaysFrom, int ddlWorkingDaysTo, CheckBoxList chkColumnsList, string dateType, String dateRange, bool isDisplayDates = false)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreDisplaySettings_Update_New");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, Convert.ToInt64(accountId));
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, Convert.ToInt64(companyId));
            database.AddInParameter(storedProcCommand, "@FieldNameTitle", DbType.String, Convert.ToString(lbl_OrderTitle));
            database.AddInParameter(storedProcCommand, "@FieldNameNumber", DbType.String, Convert.ToString(lbl_OrdNum));
            database.AddInParameter(storedProcCommand, "@FieldNameDelReq", DbType.String, Convert.ToString(lbl_DelReq));
            database.AddInParameter(storedProcCommand, "@FieldNameComments", DbType.String, Convert.ToString(lbl_Comments));
            database.AddInParameter(storedProcCommand, "@FieldNameCostCenter", DbType.String, Convert.ToString(lbl_costcenter));
            database.AddInParameter(storedProcCommand, "@ScreenNameTitle", DbType.String, Convert.ToString(txt_OrdTit_Screen));
            database.AddInParameter(storedProcCommand, "@ScreenNameNumber", DbType.String, Convert.ToString(txt_OrdNum_Screen));
            database.AddInParameter(storedProcCommand, "@ScreenNameDelReq", DbType.String, Convert.ToString(txt_DelReq_Screen));
            database.AddInParameter(storedProcCommand, "@ScreenNameComments", DbType.String, Convert.ToString(txt_Comments_Screen));
            database.AddInParameter(storedProcCommand, "@ScreenNameCostCenter", DbType.String, Convert.ToString(txt_costcenter_screen));
            database.AddInParameter(storedProcCommand, "@isdisplayTitle", DbType.Boolean, chk_OrdTit_Show);
            database.AddInParameter(storedProcCommand, "@isdisplayNumber", DbType.Boolean, chk_OrdNum_Show);
            database.AddInParameter(storedProcCommand, "@isdisplayDelReq", DbType.Boolean, chk_DelReq_Show);
            database.AddInParameter(storedProcCommand, "@isdisplayComments", DbType.Boolean, chek_Comments_Show);
            database.AddInParameter(storedProcCommand, "@isMandatoryTitle", DbType.Boolean, chk_OrdTit_Req);
            database.AddInParameter(storedProcCommand, "@isMandatoryNumber", DbType.Boolean, chk_OrdNum_Req);
            database.AddInParameter(storedProcCommand, "@isMandatoryDelReq", DbType.Boolean, chk_DelReq_Req);
            database.AddInParameter(storedProcCommand, "@isMandatoryComments", DbType.Boolean, chk_Comments_Req);
            database.AddInParameter(storedProcCommand, "@isMandatoryCostCenter", DbType.Boolean, chkCostCenter_Req);
            database.AddInParameter(storedProcCommand, "@is_DelAddres_Mandatory", DbType.Boolean, Chk_Mandotory_Del);
            database.AddInParameter(storedProcCommand, "@is_InvAddres_Mandatory", DbType.Boolean, chk_Mandotory_Inv);
            database.AddInParameter(storedProcCommand, "@is_Display_Delivery", DbType.Boolean, Chk_Display_Del);
            database.AddInParameter(storedProcCommand, "@is_Display_Invoice", DbType.Boolean, Chk_Display_Inv);
            database.AddInParameter(storedProcCommand, "@isCheckOrderInfoPublic", DbType.Boolean, chk_EnableOrder);
            database.AddInParameter(storedProcCommand, "@isCheckAddressInfo", DbType.Boolean, Chk_EnableAddress);
            database.AddInParameter(storedProcCommand, "@DefaultEstimatedDelivery", DbType.Int32, EstimateDelivery);
            database.AddInParameter(storedProcCommand, "@WorkingDaysFrom", DbType.Int32, ddlWorkingdaysFrom);
            database.AddInParameter(storedProcCommand, "@WorkingDaysTo", DbType.Int32, ddlWorkingDaysTo);
            database.AddInParameter(storedProcCommand, "@isDisplayDates", DbType.Boolean, isDisplayDates);
            foreach (ListItem item in chkColumnsList.Items)
            {
                string columnName = item.Value;   // e.g. "isDepartment"
                bool selected = item.Selected;    // checked/unchecked
                database.AddInParameter(storedProcCommand, "@" + columnName, DbType.Boolean, selected);
            }
            database.AddInParameter(storedProcCommand, "@filterDateType", DbType.String, Convert.ToString(dateType));
            database.AddInParameter(storedProcCommand, "@filterDateRange", DbType.String, Convert.ToString(dateRange));
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable stockcustomfields_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_StockDisplay_Select");
            database.AddInParameter(storedProcCommand, "@Company", DbType.Int32, CompanyID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable stockmanagementsettings_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementSettings_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void stockmanagementsettings_update(string SA_eprintmisjobs, int SA_EprintJobstatusID, string SA_EstoreOrdersJobs, int SA_EstoreJobstatusID, string SR_StockReductionMethod, int SR_IsStockPickSingleLocation, string SR_WhenStockReduced, int SR_JobStatusID, string SC_IFJobCancelled, int StatusMessage, int CompanyID, int UserID, int Replenish_JobStatusID,string SA_WhenStockAdded)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockManagementSettings_Update");
            database.AddInParameter(storedProcCommand, "@SA_EprintMISJobs", DbType.String, SA_eprintmisjobs);
            database.AddInParameter(storedProcCommand, "@SA_JobStatusID", DbType.Int64, SA_EprintJobstatusID);
            database.AddInParameter(storedProcCommand, "@SA_EstoreOrdersAndJobs", DbType.String, SA_EstoreOrdersJobs);
            database.AddInParameter(storedProcCommand, "@SA_EstoreJobStatusID", DbType.Int64, SA_EstoreJobstatusID);
            database.AddInParameter(storedProcCommand, "@SR_StockReductionMethod", DbType.String, SR_StockReductionMethod);
            database.AddInParameter(storedProcCommand, "@SR_IsStockPickFromSingleLoc", DbType.Int32, SR_IsStockPickSingleLocation);
            database.AddInParameter(storedProcCommand, "@SR_WhenStockReduced ", DbType.String, SR_WhenStockReduced);
            database.AddInParameter(storedProcCommand, "@SR_JobStatusID", DbType.Int64, SR_JobStatusID);
            database.AddInParameter(storedProcCommand, "@SC_IfJobCancelled", DbType.String, SC_IFJobCancelled);
            database.AddInParameter(storedProcCommand, "@StatusMessage", DbType.Int32, StatusMessage);
            database.AddInParameter(storedProcCommand, "@ModifiedBy", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Replenish_JobStatusID", DbType.Int32, Replenish_JobStatusID);
            database.AddInParameter(storedProcCommand, "@SA_WhenStockAdded", DbType.String, SA_WhenStockAdded);
            
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void StockScanningJobOrPOStatus_Update( Int32 StockScanFullJobStatusID, int StockScanPartialJobStatusID, Int32 StockScanFullPOStatusID, Int32 StockScanPartialPOStatusID, Int32 CompanyId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockScanningJobOrPOStatus_Update");
           
            database.AddInParameter(storedProcCommand, "@StockScanFullJobStatusID", DbType.Int32, StockScanFullJobStatusID);
            database.AddInParameter(storedProcCommand, "@StockScanPartialJobStatusID", DbType.Int32, StockScanPartialJobStatusID);
            database.AddInParameter(storedProcCommand, "@StockScanFullPOStatusID", DbType.Int32, StockScanFullPOStatusID);
            database.AddInParameter(storedProcCommand, "@StockScanPartialPOStatusID", DbType.Int32, StockScanPartialPOStatusID);
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyId);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void StoreEmailSetting_Insert_Update(int CompanyID, int StoreEmailSettingsID, string AdminTo, string AdminCc, string AdminBcc, string CustomerFrom, string CustomerCc, string CustomerBcc)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_StoreEmailSetting");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreEmailSettingsID", DbType.Int32, StoreEmailSettingsID);
            database.AddInParameter(storedProcCommand, "@AdminTo", DbType.String, AdminTo);
            database.AddInParameter(storedProcCommand, "@AdminCc", DbType.String, AdminCc);
            database.AddInParameter(storedProcCommand, "@AdminBcc", DbType.String, AdminBcc);
            database.AddInParameter(storedProcCommand, "@CustomerFrom", DbType.String, CustomerFrom);
            database.AddInParameter(storedProcCommand, "@CustomerCc", DbType.String, CustomerCc);
            database.AddInParameter(storedProcCommand, "@CustomerBcc", DbType.String, CustomerBcc);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable StoreEmailSetting_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_StoreEmailSetting_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable SubAdditionalOptions_SubValues(int ChoiceID, int OthercostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionalOptionsValues_Select_Order");
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, ChoiceID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, OthercostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable SubAdditionalOptions_Values(int ChoiceID, int OthercostID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_SubAdditionalOptionsValues_Select");
            database.AddInParameter(storedProcCommand, "@ChoiceID", DbType.Int32, ChoiceID);
            database.AddInParameter(storedProcCommand, "@WebOtherCostID", DbType.Int32, OthercostID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void TermsAndConditions_Insert(int companyID, int accountID, int isTerms, string TermsAndConditions)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TermsAndConditions_Insert");
            database.AddInParameter(storedProcCommand, "@companyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@accountID", DbType.Int32, accountID);
            database.AddInParameter(storedProcCommand, "@IsTerms", DbType.Int32, isTerms);
            database.AddInParameter(storedProcCommand, "@TermsAndConditions", DbType.String, TermsAndConditions);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual DataTable TermsAndConditions_Select(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_TermsAndConditions_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_customerType(long PriceCatalogueID, string CustomerType)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_customerType");
            database.AddInParameter(storedProcCommand, "@priceCatalogueId", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@customerType", DbType.String, CustomerType);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void Update_Disable_Account(long UserID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_disable_account");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void Update_lock_account(long UserID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_lock_account");
            DataTable dataTable = new DataTable();
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, UserID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual void WebStore_AccountingCode_Insert(int CompanyID, long WebOthercostID, int AccountCodeID)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonClass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_WebStore_AccountingCode_Insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WebOthercostID", DbType.Int64, WebOthercostID);
            database.AddInParameter(storedProcCommand, "@AccountCodeID", DbType.Int32, AccountCodeID);
            database.ExecuteNonQuery(storedProcCommand);
            _commonClass.closeConnection();
        }

        public virtual int WebStore_AccountingCode_Select(int CompanyID, long WebOthercostID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("pc_WebStore_AccountingCode_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@WebOthercostID", DbType.Int64, WebOthercostID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }
    }
}