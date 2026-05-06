using DocumentFormat.OpenXml.Spreadsheet;
using ePrint.WebStore;
using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using nmsLanguage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Printcenter.DataAccessLayer.Order
{
    public class DBOrder
    {
        public DBOrder()
        {
        }

        public virtual DataTable B2B_Select_All_Address_ByStoreUserID(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_All_Address_ByStoreUserID");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Client_Address_select(int CompanyID, int AccountID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Client_Address_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void company_country_select(DropDownList ddlcountry)
        {
            languageClass _languageClass = new languageClass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_country_select");
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            int num = 0;
            string empty = string.Empty;
            int num1 = 0;
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                num1 = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                num = Convert.ToInt32(ConnectionClass.AccountID);
            }
            DataTable dataTable1 = new DataTable();
            dataTable1 = this.Client_Address_select(num1, num);
            foreach (DataRow row in dataTable1.Rows)
            {
                empty = row["Country"].ToString();
            }
            if (empty == "")
            {
                empty = "Australia";
            }
            ddlcountry.DataSource = dataTable;
            ddlcountry.DataTextField = "Countryname";
            ddlcountry.DataValueField = "Countryid";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, "");
            ddlcountry.Items[0].Text = string.Concat("--- ", _languageClass.GetLanguageConversion("Select"), " ---");
            ddlcountry.Items[0].Value = "0";
            ddlcountry.SelectedIndex = ddlcountry.Items.IndexOf(ddlcountry.Items.FindByText(empty.Trim()));
            storedProcCommand.Dispose();
            dataTable.Dispose();
        }

        public virtual DataTable CustomizeJob_Report(long companyid, long storeuserid, string JobFromDate, string JobToDate)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_GetCustomizeEstoreJobReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.Parameters.AddWithValue("@FromDate", JobFromDate);
            sqlCommand.Parameters.AddWithValue("@ToDate", JobToDate);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public virtual void Delete_BillingShippingAddress(long StoreUserID, long AddressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_BillingShippingAddress");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet EmailToAdmin_SelectIsActiveType(long CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_EmailToAdmin_SelectIsActiveType", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataSet EmailToAdminBackORD_SelectIsActiveType(long CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_EmailToAdminBackOrder_SelectIsActiveType", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable EmailToCustomer_Select_WebStore(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailFor)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_EmailToCustomer_Select_WebStore");
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

        public virtual void Estimate_insertFrom_WebOrders(int CompanyID, long ClientID, long StoreUserID, long OrderID, DateTime Date, string CreatedDateTime, bool IsApproved, string ApproverEmail)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("[PC_B2B_Estimate_insertFrom_WebOrders]");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@Date", DbType.DateTime, Date);
            database.AddInParameter(storedProcCommand, "@IsApproved", DbType.Boolean, IsApproved);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.AddInParameter(storedProcCommand, "@CreatedDateTime", DbType.String, CreatedDateTime);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual bool Fetch_Stock_Mgmt_Exists(long CompanyID)
        {
            bool flag;
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Fetch_StockMgmt");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            object obj = database.ExecuteScalar(storedProcCommand);
            try
            {
                if (obj != null)
                {
                    flag = (!(bool)obj ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public virtual bool Get_Catgry_IsApprovalNotRequired(long ProductID)
        {
            bool flag;
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_Get_Catgry_IsApprovalNotRequired");
            database.AddInParameter(storedProcCommand, "@ProductID", DbType.Int64, ProductID);
            object obj = database.ExecuteScalar(storedProcCommand);
            try
            {
                if (obj != null)
                {
                    flag = (!(bool)obj ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public virtual bool Get_Dept_IsApprovalNotRequired(long DepartmentID)
        {
            bool flag;
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_Get_Dept_IsApprovalNotRequired");
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            object obj = database.ExecuteScalar(storedProcCommand);
            try
            {
                if (obj != null)
                {
                    flag = (!(bool)obj ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public virtual DataTable Get_EditableTemplate_Imageurl(int PriceCatalogueID, int CartItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EditableTemplate_Imageurl_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int32, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int32, CartItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_IsApprovalAddress(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_IsApprovalAddress");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_IsApprovalProfile(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_IsApprovalProfile");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_IsApprove_For_registration(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Get_IsApprove_For_registration");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual int GetOrderItems(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_OrderItems_Checkpending");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            return (int)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable GetStoreUserContactDetails(long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_Contact_Name_By_StoreUserID");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Email, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_BillingShipping_Address");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
            database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
            database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
            database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
            database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
            database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Int16, IsDefaultBilling);
            database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Int16, IsDefaultShipping);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Insert_Contact(long CompanyID, long StoreUserID, long AccountID, long AddressID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_Contact");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public long Insert_Contact(int CompanyID, long ClientID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("ws_B2B_Insert_Guest_Contact");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@FromRegistration", DbType.String, FromRegistration);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Insert_CreditCardDetails(long OrderID, string CardHolderName, string CardName, long CardNumber, string CardType, string SecurityCode, int ExpirationMonth, int ExpirationYear)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_CreditCardDetails");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@CardHolderName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardName", DbType.String, CardName);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.Int64, CardNumber);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@SecurityCode", DbType.String, SecurityCode);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int32, ExpirationMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int32, ExpirationYear);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Insert_CustomerOn_Order(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_CustomerOn_Order");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@FromRegistration", DbType.String, FromRegistration);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Insert_InvoicePaymentDetailsForEstore(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoicePaymentDetails_Forestore");
            database.AddInParameter(storedProcCommand, "@invoiceID", DbType.Int64, invoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void Insert_OrderItemDetails_MIS(long CartItemID, bool IsBackOrder, long EstimateID, long CompanyID, bool ApproveStatus, long StoreUserID, string ApproverEmail, long ClientID, int ItemCount)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_OrderItem_Insert");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@Companyid", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ApproveStatus", DbType.Boolean, ApproveStatus);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@EstimateItemCount", DbType.Int32, ItemCount);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Insert_OrderItemDetails_ToNotes(long EstimateID, long CompanyID, long StoreUserID, long itemCount)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WebStore_ActivityHistoryAllItem_Insert");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@itemCount", DbType.Int32, itemCount);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Insert_Orders(long StoreUserID, long AccountID, string OrderNo, decimal TotalPrice, decimal Tax, decimal OrderShipping, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, string ApproverEmail, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long OrderedBy, string orderbehalftype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_Orders");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.String, OrderNo);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@OrderShipping", DbType.Decimal, OrderShipping);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@PaymentType", DbType.String, PaymentType);
            database.AddInParameter(storedProcCommand, "@OrderDate", DbType.DateTime, OrderDate);
            database.AddInParameter(storedProcCommand, "@RequiredDate", DbType.DateTime, RequiredDate);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
            database.AddInParameter(storedProcCommand, "@OrderTitle", DbType.String, OrderTitle);
            database.AddInParameter(storedProcCommand, "@UserRefOrderNo", DbType.String, UserRefOrderNo);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.AddInParameter(storedProcCommand, "@Order_Behalf_UserID", DbType.Int64, BehalfUserID);
            database.AddInParameter(storedProcCommand, "@Order_behalf_DeptID", DbType.Int64, BehalfDeptID);
            database.AddInParameter(storedProcCommand, "@IsApproved", DbType.Int32, IsApproved);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@OrderedBy", DbType.Int64, OrderedBy);
            database.AddInParameter(storedProcCommand, "@OrderPrefix", DbType.String, ConnectionClass.OrderPrefix);
            database.AddInParameter(storedProcCommand, "@orderbehalftype", DbType.String, orderbehalftype);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual long Insert_OrdersItems(long OrderID, long CartItemID, bool BKOrder)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_OrdersItems");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, BKOrder);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual void Insert_Personal_Info_Address_temp(long StoreUserID, long AccountID, string AddressLabel, string Fax, string Telephone, string Country, string Address1, string Address2, string Address3, string Address4, string Address5, long AddressID, int IsDefaultBilling, int IsDefaultShipping, string ApproverEmail, string ApprovedType, string PersonalProfileEditType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("B2B_Insert_Personal_Info_Address_temp");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@Telephone", DbType.String, Telephone);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
            database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
            database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
            database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
            database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Int32, IsDefaultBilling);
            database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Int32, IsDefaultShipping);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.AddInParameter(storedProcCommand, "@ApprovedType", DbType.String, ApprovedType);
            database.AddInParameter(storedProcCommand, "@PersonalProfileEditType", DbType.String, PersonalProfileEditType);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Insert_Reorder_Deatil(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_CartItemsByOrderID");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Insert_Reordered_CartItemsandDetails(long CartItemID, string GUID, long StoreUserID)
        {
            commonclass _commonclass = new commonclass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_Reordered_CartItemsandDetails");
            database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@GUID", DbType.String, GUID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long InsertOrderDetails_MIS(long StoreUserID, long AccountID, decimal TotalPrice, decimal Tax, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, string ApproverEmail, long BehalfUserID, long BehalfDeptID, long CostCentreID, long OrderedBy, string orderbehalftype, bool IsApproved, string BT_OrderID, string BT_AuthorizationCode, long CartID, string Stripe_Paymentid, string IsTwoWayApproval = "0", string DepartmentApproval = "0", string MainApproval = "0", string ApprovalEmails = "")
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Insert_OrdersDetails_MIS");
            storedProcCommand.CommandTimeout = 0;
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@TotalPrice", DbType.Decimal, TotalPrice);
            database.AddInParameter(storedProcCommand, "@Tax", DbType.Decimal, Tax);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@PaymentType", DbType.String, PaymentType);
            database.AddInParameter(storedProcCommand, "@OrderDate", DbType.DateTime, OrderDate);
            database.AddInParameter(storedProcCommand, "@RequiredDate", DbType.DateTime, RequiredDate);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comments);
            database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
            database.AddInParameter(storedProcCommand, "@OrderTitle", DbType.String, OrderTitle);
            database.AddInParameter(storedProcCommand, "@UserRefOrderNo", DbType.String, UserRefOrderNo);
            database.AddInParameter(storedProcCommand, "@ApproverEmail", DbType.String, ApproverEmail);
            database.AddInParameter(storedProcCommand, "@Order_Behalf_UserID", DbType.Int64, BehalfUserID);
            database.AddInParameter(storedProcCommand, "@Order_behalf_DeptID", DbType.Int64, BehalfDeptID);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@OrderedBy", DbType.Int64, OrderedBy);
            database.AddInParameter(storedProcCommand, "@OrderPrefix", DbType.String, ConnectionClass.OrderPrefix);
            database.AddInParameter(storedProcCommand, "@orderbehalftype", DbType.String, orderbehalftype);
            database.AddInParameter(storedProcCommand, "@BT_OrderID ", DbType.String, BT_OrderID);
            database.AddInParameter(storedProcCommand, "@BT_AuthorizationCode ", DbType.String, BT_AuthorizationCode);
            database.AddInParameter(storedProcCommand, "@St_Paymentid", DbType.String, Stripe_Paymentid);
            database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);

            database.AddInParameter(storedProcCommand, "@IsTwoWayApproval", DbType.String, IsTwoWayApproval);
            database.AddInParameter(storedProcCommand, "@DepartmentApproval", DbType.String, DepartmentApproval);
            database.AddInParameter(storedProcCommand, "@MainApproval", DbType.String, MainApproval);
            database.AddInParameter(storedProcCommand, "@ApprovalEmails", DbType.String, ApprovalEmails);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        public virtual DataSet itemdescription_selectall_fromSettings_foralltypes(long companyid, string type)
        {
            BaseClass baseClass = new BaseClass();
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_itemdescription_selectall_fromSettings_foralltypes");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@Estimatetype", DbType.String, type);
            dataSet = database.ExecuteDataSet(storedProcCommand);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["ScreenName"] = baseClass.SpecialDecode(row["ScreenName"].ToString());
            }
            return dataSet;
        }

        public virtual DataSet JobReport_CustomizeCustomer(long companyid, long storeuserid, DateTime JobFromDate, DateTime JobToDate, string filter)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("pc_GetJobProduct_EstoreReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.Parameters.AddWithValue("@FromDate", JobFromDate);
            sqlCommand.Parameters.AddWithValue("@ToDate", JobToDate);
            sqlCommand.Parameters.AddWithValue("@Condition", filter);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Order_Status(long OrderID, long EstimateID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Order_Status");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void OrderBehalf_DeptOrUser_Update(string OrderKey, long StoreUserID, long DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderOnBehalf_UserOrDept_Update");
            database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            commonclass _commonclass = new commonclass();
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase(_commonclass.strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderMangerOptions_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Orderreport_systemgenerated(int CompanyID, long storeuserid, DateTime fromdate, DateTime todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_OrderDetails_EstoreReport");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@storeuserid", DbType.Int32, storeuserid);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, fromdate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.DateTime, todate);
            database.AddInParameter(storedProcCommand, "@ISStockItem", DbType.String, ISStockItem);
            database.AddInParameter(storedProcCommand, "@IsStockReplenish", DbType.String, IsStockReplenish);
            database.AddInParameter(storedProcCommand, "@AllowUnApprovedOrder", DbType.Boolean, AllowUnApprovedOrder);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Orderreport_systemgenerated_splitoff(int CompanyID, long storeuserid, DateTime fromdate, DateTime todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_OrderDetails_EstoreReport_SplitOff");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@storeuserid", DbType.Int32, storeuserid);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.DateTime, fromdate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.DateTime, todate);
            database.AddInParameter(storedProcCommand, "@ISStockItem", DbType.String, ISStockItem);
            database.AddInParameter(storedProcCommand, "@IsStockReplenish", DbType.String, IsStockReplenish);
            database.AddInParameter(storedProcCommand, "@AllowUnApprovedOrder", DbType.Boolean, AllowUnApprovedOrder);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OtherMultipleProductDetails_Select");
            database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
            database.AddInParameter(storedProcCommand, "@Quantity", DbType.Int32, Quantity);
            database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PreFill_OrderInfo(long ManageCampaignID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_ManageCampaign_Select");
            database.AddInParameter(storedProcCommand, "@ManageCampaignID", DbType.Int64, ManageCampaignID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_default_price_for_pack_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void PriceCatalogue_ItemDescription_InsertUpdate(long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_ItemDescription_InsertUpdate");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Prod_report_stockusage_bymontandYear(long companyid, long storeuserid, string deptid, string monthcategory)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_StockProductUsage_EstoreReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", deptid);
            sqlCommand.Parameters.AddWithValue("@MonthCatagory", monthcategory);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public virtual DataTable Product_Report_quartersales(long companyid, long storeuserid)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("pc_getcustomizeproductEstorereport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public virtual DataTable productcatalogue_warehousestock_select(int CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_WareHouse_Stock_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable ProductReport_Stockrelease_adjustment(long companyid, DateTime fromdate, DateTime todate, long storeuserid)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("Pc_GetProduct_EstoreReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@FromDate", fromdate);
            sqlCommand.Parameters.AddWithValue("@ToDate", todate);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public virtual DataSet productreport_stockusage(long companyid, long storeuserid)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_ProductStock_InPack_EstoreReport", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@companyid", companyid);
            sqlCommand.Parameters.AddWithValue("@storeuserid", storeuserid);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public void Reject_Order(string OrderNo, string Reason, string Type, long StoreUserID, long OrderItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Reject_Order");
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.String, OrderNo);
            database.AddInParameter(storedProcCommand, "@Reason", DbType.String, Reason);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public void Reject_OrderItem(string OrderNo, string Reason, string Type, long ApproverID, long UserGettingApproved, long OrderItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Reject_OrderItem");
            database.AddInParameter(storedProcCommand, "@OrderNo", DbType.String, OrderNo);
            database.AddInParameter(storedProcCommand, "@Reason", DbType.String, Reason);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@ApproverID", DbType.Int64, ApproverID);
            database.AddInParameter(storedProcCommand, "@UserGettingApproved", DbType.Int64, UserGettingApproved);
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.Int64, OrderItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Select_B2B_Orders(long StoreUserID, string WhereCondition, string ModuleName, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_B2B_IndividualJobInvoiceOrder_Select", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@ModuleName", ModuleName);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_Jobs", Is_Only_User_Jobs);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_DepartmentJobs", Is_Only_User_DepartmentJobs);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Jobs", Is_User_All_Jobs);
            sqlCommand.Parameters.AddWithValue("@Is_only_User_Invoice", Is_only_User_Invoice);
            sqlCommand.Parameters.AddWithValue("@Is_only_user_DepartmentInvoice", Is_only_user_DepartmentInvoice);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Invoice", Is_User_All_Invoice);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_Orders", Is_Only_User_Orders);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_DepartmentOrders", Is_Only_User_DepartmentOrders);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Orders", Is_User_All_Orders);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataSet Select_B2B_Orders_ByItems(long StoreUserID, string WhereCondition, string ModuleName, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();

            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_B2B_IndividualJobInvoiceOrder_Select_SplitItem", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@ModuleName", ModuleName);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_Jobs", Is_Only_User_Jobs);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_DepartmentJobs", Is_Only_User_DepartmentJobs);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Jobs", Is_User_All_Jobs);
            sqlCommand.Parameters.AddWithValue("@Is_only_User_Invoice", Is_only_User_Invoice);
            sqlCommand.Parameters.AddWithValue("@Is_only_user_DepartmentInvoice", Is_only_user_DepartmentInvoice);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Invoice", Is_User_All_Invoice);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_Orders", Is_Only_User_Orders);
            sqlCommand.Parameters.AddWithValue("@Is_Only_User_DepartmentOrders", Is_Only_User_DepartmentOrders);
            sqlCommand.Parameters.AddWithValue("@Is_User_All_Orders", Is_User_All_Orders);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = int.MaxValue;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Select_B2B_Orders_reeng(long StoreUserID, string WhereCondition, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, bool IsHideMISJobVisible, bool IsHideMISInvoiceVisible)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Orders_SelectAll");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Jobs", DbType.Boolean, Is_Only_User_Jobs);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentJobs", DbType.Boolean, Is_Only_User_DepartmentJobs);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Jobs", DbType.Boolean, Is_User_All_Jobs);
            database.AddInParameter(storedProcCommand, "@Is_only_User_Invoice", DbType.Boolean, Is_only_User_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_only_user_DepartmentInvoice", DbType.Boolean, Is_only_user_DepartmentInvoice);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Invoice", DbType.Boolean, Is_User_All_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Orders", DbType.Boolean, Is_Only_User_Orders);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentOrders", DbType.Boolean, Is_Only_User_DepartmentOrders);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Orders", DbType.Boolean, Is_User_All_Orders);
            database.AddInParameter(storedProcCommand, "@IsHideMISJobVisible", DbType.Boolean, IsHideMISJobVisible);
            database.AddInParameter(storedProcCommand, "@IsHideMISInvoiceVisible", DbType.Boolean, IsHideMISInvoiceVisible);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_B2B_Orders_reeng_Approval_New(long StoreUserID, string WhereCondition, string Type, string ModuleName)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_Orders_Approval_New");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_B2B_Orders_reeng_Approval_On(long StoreUserID, string WhereCondition, string Type)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_Orders_Approval_On");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_B2B_Orders_reeng_ByItem(long StoreUserID, string WhereCondition, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, bool IsHideMISJobVisible, bool IsHideMISInvoiceVisible)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Orders_SelectAll_SplitItem");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Jobs", DbType.Boolean, Is_Only_User_Jobs);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentJobs", DbType.Boolean, Is_Only_User_DepartmentJobs);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Jobs", DbType.Boolean, Is_User_All_Jobs);
            database.AddInParameter(storedProcCommand, "@Is_only_User_Invoice", DbType.Boolean, Is_only_User_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_only_user_DepartmentInvoice", DbType.Boolean, Is_only_user_DepartmentInvoice);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Invoice", DbType.Boolean, Is_User_All_Invoice);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_Orders", DbType.Boolean, Is_Only_User_Orders);
            database.AddInParameter(storedProcCommand, "@Is_Only_User_DepartmentOrders", DbType.Boolean, Is_Only_User_DepartmentOrders);
            database.AddInParameter(storedProcCommand, "@Is_User_All_Orders", DbType.Boolean, Is_User_All_Orders);
            database.AddInParameter(storedProcCommand, "@IsHideMISJobVisible", DbType.Boolean, IsHideMISJobVisible);
            database.AddInParameter(storedProcCommand, "@IsHideMISInvoiceVisible", DbType.Boolean, IsHideMISInvoiceVisible);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet Select_B2B_Pending_Orders(string Email, long StoreUserID, string WhereCondition, string Typename)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_Select_B2B_Pending_Orders", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@Type", Typename);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public DataSet Select_B2B_Pending_Orders_By_Item(string Email, long StoreUserID, string WhereCondition, string Typename)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_B2B_AwaitingPending_Orders_SplitItem", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@Type", Typename);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandTimeout = Int32.MaxValue;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public DataSet Select_BehalfUsersOrDept(long AccountID, long StoreUserID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_Select_BehalfUsersOrDept", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Select_BillingShipping_Address(long AddressID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_BillingShipping_Address");
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_BillingShipping_Address_Grid(long StoreUserID, string type, long StoreContactID, string Filter)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_BillingShipping_Address_FreeSearch");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
            database.AddInParameter(storedProcCommand, "@StoreContactID", DbType.Int64, StoreContactID);
            database.AddInParameter(storedProcCommand, "@Filter", DbType.String, Filter);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_BillingShippingAddress_OnAddressID(long StoreUserID, long AddressID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_BillingShippingAddress_OnAddressID");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_BillingShippingAddress_DeliveryCost(long AddressID, bool isfrom, long CompanyID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_BillingShippingAddress_DeliveryCost");
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.AddInParameter(storedProcCommand, "@isfrom", DbType.Boolean, isfrom);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_BrainTree_Details(long AccountID, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Select_Braintree_Details");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_CustomerAddress(long CompanyID, long StoreUserID, long ContactID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Select_CustomerAddress");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_DeptOrUser_Name(long ContactID, long DeptID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_UserDept_Name");
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            database.AddInParameter(storedProcCommand, "@DeptID", DbType.Int64, DeptID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_details_ClientInfo(long CompanyID, string ServerName)
        {
            DataTable dataTable = new DataTable();
            commonclass _commonclass = new commonclass();
            Database database = CustomDatabaseFactory.CreateDatabase(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_details_ClientInfo");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ServerName", DbType.String, ServerName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_EstoreReportsEnabled(long StoreUserID, long CompanyID, long Accountid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_eStoreReportsEnable_Select");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@accountid", DbType.Int64, Accountid);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Individual_Address(long StoreUserID, long AddressID, long StoreContactID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_Individual_Address");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.String, AddressID);
            database.AddInParameter(storedProcCommand, "@StoreContactID", DbType.Int64, StoreContactID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet Select_MainOrDepOrUser(long StoreUserID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_B2B_Select_MainOrDepOrUser", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
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

        public virtual DataTable Select_OrderAdditionalItems(long OrderItemID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalItems");
            database.AddInParameter(storedProcCommand, "@OrderItemID", DbType.String, OrderItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderAdditionalOptions(long StoreUserID, string OrderID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalOptions");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.String, StoreUserID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.String, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderID(string OrderKey)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_OrderID");
            database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_OrderItems");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_OrderItems(string OrderID, long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Select_OrderItems");
            storedProcCommand.CommandTimeout = int.MaxValue;
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.String, OrderID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet Select_OrderItems_BeforeOrder(long StoreUserID, string MultipleCartID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_B2B_Select_OrderItems_BeforeOrder", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@MultipleCartID", MultipleCartID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Select_OrderItems_ForStock(long OrderID, long StoreUserID, string ItemIDs)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_OrderItemsStock_Select");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@ItemIDs", DbType.String, ItemIDs);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Orders(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_Orders");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_Orders_reeng(long StoreUserID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_Orders_test");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_ProductDetailsTag(int CompanyID, int AccountID, long EmailToCustomerID)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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

        public virtual DataSet Select_Reports_databyreportid(long reportid, long companyid, long storeuserid, DateTime fromdate, DateTime todate, int pagesize, int pagenumber)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstoreReport_Select");
            database.AddInParameter(storedProcCommand, "@reportid", DbType.Int32, reportid);
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int32, companyid);
            database.AddInParameter(storedProcCommand, "@storeuserid", DbType.Int32, storeuserid);
            database.AddInParameter(storedProcCommand, "@Fromdate", DbType.DateTime, fromdate);
            database.AddInParameter(storedProcCommand, "@Todate", DbType.DateTime, todate);
            database.AddInParameter(storedProcCommand, "@PageSize", DbType.Int32, pagesize);
            database.AddInParameter(storedProcCommand, "@PageNumber", DbType.Int32, pagenumber);
            storedProcCommand.CommandTimeout = 0;
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable Select_Reports_forCustomer(long storeuserid, string pagename)
        {
            DataTable dataTable = new DataTable();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EnableEndUserReport");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, storeuserid);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, pagename);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_StoreUserID_UserDept_Behalf(string cartitemids, string orderbehalftype)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_StoreUserID_BehalfDeptorUser");
            database.AddInParameter(storedProcCommand, "@CartItemIds", DbType.String, cartitemids);
            database.AddInParameter(storedProcCommand, "@BehalfType", DbType.String, orderbehalftype);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public DataSet SelectDeptandCostCentre(long StoreUserID, string orderbehalftype, long DeptID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("WS_SelectDeptandCostCentre", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
            sqlCommand.Parameters.AddWithValue("@orderbehalftype", orderbehalftype);
            sqlCommand.Parameters.AddWithValue("@DeptID", DeptID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public DataTable SelectEstimateDays(long CompanyID)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("PC_Select_EstimateDeliveryDays", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable settings_companyprofile_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_companyprofile_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable settings_regionalsettings_select(int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_settings_regionalsettings_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_BillingShipping_Address(long AddressID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Phone, string Email, string Fax, string Country, string AddressLabel, string Address5)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2B_Update_BillingShipping_Address");
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
            database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
            database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
            database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
            database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
            database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
            database.AddInParameter(storedProcCommand, "@Email", DbType.String, Email);
            database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
            database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
            database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void update_BillingShipping_AddressID(long StoreUserID, long AddressID, int IsDefaultBilling, int IsDefaultShipping)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_update_BillingShipping_AddressID");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
            database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Int32, IsDefaultBilling);
            database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Int32, IsDefaultShipping);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_ConfirmOrder(long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_ConfirmOrder");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_Orders(long OrderID, long BillingAddressID, long ShippingAddressID, long ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_Orders");
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public DataTable Ws_Get_TaxName(int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Get_TaxName");
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable settings_OrderingProcess_select(int CompanyID, int AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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

        public virtual DataSet approvalsystemsettings_getDetails(long UserID, long CompanyID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2B_approvalsystemsettings_select");
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int64, UserID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            return database.ExecuteDataSet(storedProcCommand);
        }



        public virtual int etimates_attachment_insert(int CompanyID,int AttachmentID,string AttachmentType,int AttachmentTypeID,string FileName,int EstimateID,string ModuleType,int UploadedBy,bool IsDisplayToEstore,string OriginalFileName,string ReportFile,bool IsDisplayToPdf)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_etimates_attachment_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@AttachmentID", DbType.Int64, AttachmentID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, AttachmentType);
            database.AddInParameter(storedProcCommand, "@AttachmentTypeID", DbType.Int64, AttachmentTypeID);
            database.AddInParameter(storedProcCommand, "@FileName", DbType.String, FileName);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            database.AddInParameter(storedProcCommand, "@UploadedBy", DbType.Int32, UploadedBy);
            database.AddInParameter(storedProcCommand, "@IsDisplayToEstore", DbType.Boolean, IsDisplayToEstore);
            database.AddInParameter(storedProcCommand, "@OriginalFileName", DbType.String, OriginalFileName);
            database.AddInParameter(storedProcCommand, "@ReportFile", DbType.String, ReportFile);
            database.AddInParameter(storedProcCommand, "@isDisplayInJobEstimate", DbType.Boolean, IsDisplayToPdf);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual DataSet GetStockUsage_InPacks_cost(int CompanyID, long StoreUserID,string WhereCondition)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ProductStock_InPack_Report_cost_Estore");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual DataTable ProductstockUsageHistoryReport(long CompanyID, long StoreUserID, string DepartmentID, string MonthCatagory)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_StockProductUsageHistory_Report_Estore");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@DepartmentId", DbType.String, DepartmentID);
            database.AddInParameter(storedProcCommand, "@MonthCatagory", DbType.String, MonthCatagory);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual DataTable GetProduct_SelectDepartment(long CompanyID, long StoreUserID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_DepartmentAllocation_Select_Estore");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable etimates_attachment_select(int companyID, int userID, string attachmentType, int estimateID, string moduleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Attachments_Select_For_General");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, userID);
            database.AddInParameter(storedProcCommand, "@AttachmentType", DbType.String, attachmentType);
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, estimateID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, moduleType);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void etimates_attachment_delete(int companyid, long attachmentid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Delete_Attachment");
            database.AddInParameter(storedProcCommand, "@companyid", DbType.Int64, companyid);
            database.AddInParameter(storedProcCommand, "@attachmentid", DbType.Int64, attachmentid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual FtpSettingsModel GetFtpSettings(int companyId)
        {
            FtpSettingsModel settings = null;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFtpSettings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                if (reader.Read())
                {
                    settings = new FtpSettingsModel
                    {
                        FtpAddress = reader["FtpAddress"].ToString(),
                        Username = reader["Username"].ToString(),
                        EncryptedPassword = reader["EncryptedPassword"].ToString(),
                        Port = reader["FTPPort"] != DBNull.Value ? Convert.ToInt32(reader["FTPPort"]) : 22, // default to 22 if null
                        RootFolder = reader["RootFolder"].ToString(),
                        FileTransferProtocol = reader["FileTransferProtocol"].ToString()
                    };
                }
            }

            return settings;
        }

        public virtual List<FtpRouteSetting> LoadFtpRouteSettings(int companyId)
        {
            var list = new List<FtpRouteSetting>();
            Database db = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand cmd = db.GetStoredProcCommand("PC_GetFtpRouteSettings");
            db.AddInParameter(cmd, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new FtpRouteSetting
                    {
                        SectionName = reader["SectionName"] != DBNull.Value ? reader["SectionName"].ToString() : null,
                        ActionName = reader["ActionName"] != DBNull.Value ? reader["ActionName"].ToString() : null,
                        StatusValue = reader["StatusValue"] != DBNull.Value ? Convert.ToInt32(reader["StatusValue"].ToString()) : 0,
                        IsSelected = reader["IsSelected"] != DBNull.Value ? Convert.ToBoolean(reader["IsSelected"].ToString()) : false
                    });
                }
            }

            return list;
        }

        public virtual DataTable Settings_Product_Catalogue_Select(int CompanyID, int PriceCatalogueID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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

        public virtual FtpPrefixSettingsModel GetFtpPrefixSettings(int companyId)
        {
            FtpPrefixSettingsModel settings = null;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetFTPPrefixSettings");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyId);

            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                if (reader.Read())
                {
                    settings = new FtpPrefixSettingsModel
                    {
                        ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                        PrefixSelectedMode = reader["PrefixMode"] != DBNull.Value ? Convert.ToInt32(reader["PrefixMode"]) : 0
                    };
                }
            }

            return settings;
        }
        public virtual DataTable GetPriceCatalogueIDByEstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetPriceCatalogueIDByEstimateID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        public virtual void SaveEstimateItemFTPAddress(int CompanyID, long EstimateItemID, string FTPAddress,string FTPStatus, string FTPSource)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Update_EstimateItem_FTPAddress");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@FTPAddress", DbType.String, FTPAddress);
            database.AddInParameter(storedProcCommand, "@FTPStatus", DbType.String, FTPStatus);
            database.AddInParameter(storedProcCommand, "@FTPSource", DbType.String, FTPSource);
            database.ExecuteNonQuery(storedProcCommand);

        }
        public void SaveFtpLogs(int CompanyID, long ProductCatalogueID, long EstimateItemID, DateTime TimeStamp, string Status, string TargetDestination, string FileName,string FTPError)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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

        public virtual DataTable GetFTPEmailTemplate(int CompanyID, string TemplateType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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
        public virtual DataTable GetFTPEmailTags(int CompanyID, long PriceCatalogueID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
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
        public virtual DataTable Jobs_EmailStatus_select(int CompanyID, int StatusID, long CheckMailSentJobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase(EprintConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Jobs_EmailStatus_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@CheckMailSentJobID", DbType.Int64, CheckMailSentJobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
    }
}