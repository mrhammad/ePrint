using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnection;
using System;
using System.Collections;
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

		public virtual void company_country_select(DropDownList ddlcountry)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_company_country_select");
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			int num = 0;
			foreach (DataRow row in dataTable.Rows)
			{
				if (row["Countryname"].ToString() != "Australia")
				{
					continue;
				}
				num = Convert.ToInt32(row["Countryid"]);
			}
			ddlcountry.DataSource = dataTable;
			ddlcountry.DataTextField = "Countryname";
			ddlcountry.DataValueField = "Countryid";
			ddlcountry.DataBind();
			ddlcountry.Items.Insert(0, "");
			ddlcountry.Items[0].Text = "--- Select ---";
			ddlcountry.Items[0].Value = "0";
			ddlcountry.SelectedIndex = num;
			storedProcCommand.Dispose();
			dataTable.Dispose();
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

		public virtual void Estimate_insertFrom_WebOrders(int CompanyID, long ClientID, long StoreUserID, long OrderID, DateTime Date, string CreatedDateTime)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Estimate_insertFrom_WebOrders");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
			database.AddInParameter(storedProcCommand, "@Date", DbType.DateTime, Date);
			database.AddInParameter(storedProcCommand, "@CreatedDateTime", DbType.String, CreatedDateTime);
			database.ExecuteNonQuery(storedProcCommand);
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

		public virtual void Insert_AgentCode_Details(long EstimateID, string AGentCode, string SecretCode)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2C_AgentDetails_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@AgentCode", DbType.String, AGentCode);
			database.AddInParameter(storedProcCommand, "@SecretCode", DbType.String, SecretCode);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_BillingShipping_Address");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
			database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
			database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
			database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
			database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
			database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
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
			DbCommand storedProcCommand = database.GetStoredProcCommand("ws_Insert_Guest_Contact");
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
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_CreditCardDetails");
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
			database.AddInParameter(storedProcCommand, "@CardHolderName", DbType.String, CardHolderName);
			database.AddInParameter(storedProcCommand, "@CardName", DbType.String, CardName);
			database.AddInParameter(storedProcCommand, "@CardNumber", DbType.Int64, CardNumber);
			database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
			database.AddInParameter(storedProcCommand, "@SecurityCode", DbType.String, SecurityCode);
			database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int32, ExpirationMonth);
			database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int32, ExpirationYear);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual long Insert_CustomerOn_Order(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate, string Phone, string MobilePhone)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_CustomerOn_Order");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
			database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
			database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
			database.AddInParameter(storedProcCommand, "@FromRegistration", DbType.String, FromRegistration);
			database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);

			database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
			database.AddInParameter(storedProcCommand, "@MobilePhone", DbType.String, MobilePhone);

			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Insert_CustomerOn_OrderAgentCode(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_CustomerOn_OrderAgentCode");
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

		public virtual void Insert_OrderItemDetails_MIS(long CartItemID, bool IsBackOrder, long EstimateID, long CompanyID, long StoreUserID, int ItemCount)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_B2C_OrderItem_Insert");
			database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
			database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int64, CompanyID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
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

		public virtual long Insert_Orders(long StoreUserID, long AccountID, string OrderNo, decimal TotalPrice, decimal Tax, decimal OrderShipping, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, long CostCentreID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_Orders");
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
			database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
			database.AddInParameter(storedProcCommand, "@OrderPrefix", DbType.String, ConnectionClass.OrderPrefix);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
		}

		public virtual long Insert_OrdersItems(long OrderID, long CartItemID, bool IsBackOrder)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_OrdersItems");
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
			database.AddInParameter(storedProcCommand, "@CartItemID", DbType.Int64, CartItemID);
			database.AddInParameter(storedProcCommand, "@IsBackOrder", DbType.Boolean, IsBackOrder);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
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

		public virtual long InsertOrderDetails_MIS(long StoreUserID, long AccountID, decimal TotalPrice, decimal Tax, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, long CostCentreID, string BT_OrderID, string BT_AuthorizationCode, long CartID, string Stripe_Paymentid)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_OrdersDetails_MIS");
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
			database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
			database.AddInParameter(storedProcCommand, "@OrderPrefix", DbType.String, ConnectionClass.OrderPrefix);
			database.AddInParameter(storedProcCommand, "@BT_OrderID ", DbType.String, BT_OrderID);
			database.AddInParameter(storedProcCommand, "@BT_AuthorizationCode ", DbType.String, BT_AuthorizationCode);
			database.AddInParameter(storedProcCommand, "@St_Paymentid", DbType.String, Stripe_Paymentid);
			database.AddInParameter(storedProcCommand, "@CartID", DbType.Int64, CartID);
			database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
			database.ExecuteNonQuery(storedProcCommand);
			object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
			return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
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

		public virtual void PriceCatalogue_ItemDescription_InsertUpdate(long EstimateID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PriceCatalogue_ItemDescription_InsertUpdate");
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, EstimateID);
			database.ExecuteNonQuery(storedProcCommand);
		}

		public virtual DataTable Select_BillingShipping_Address(long StoreUserID, string type, long StoreContactID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_BillingShipping_Address");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@type", DbType.String, type);
			database.AddInParameter(storedProcCommand, "@StoreContactID", DbType.Int64, StoreContactID);
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

		public virtual DataTable Select_One_BillingShipping_Address(long AddressID)
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

		public virtual DataTable Select_OrderAdditionalOptions(long StoreUserID, long OrderID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderAdditionalOptions");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.String, StoreUserID);
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_OrderID(string OrderKey, long StoreUserID)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderID");
			database.AddInParameter(storedProcCommand, "@OrderKey", DbType.String, OrderKey);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
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
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderItems");
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
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_OrderItems");
			database.AddInParameter(storedProcCommand, "@OrderID", DbType.String, OrderID);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataSet Select_OrderItems_BeforeOrder(long StoreUserID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("WS_Select_OrderItems_BeforeOrder", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
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

		public virtual DataTable Select_Orders_Individiually(long StoreUserID, string ModuleName, string WhereCondition)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2C_Select_Orders_New");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
			database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public virtual DataTable Select_Orders_reeng(long StoreUserID, string WhereCondition)
		{
			DataTable dataTable = new DataTable();
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Select_Orders");
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
			database.AddInParameter(storedProcCommand, "@WhereCondition", DbType.String, WhereCondition);
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
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_B2CProductDetailsTag_Select");
			database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
			database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int32, AccountID);
			database.AddInParameter(storedProcCommand, "@EmailToCustomerID", DbType.Int64, EmailToCustomerID);
			using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public DataTable SelectDeptandCostCentre(long StoreUserID)
		{
			string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
			SqlConnection sqlConnection = new SqlConnection(str);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			SqlCommand sqlCommand = new SqlCommand("WS_SelectDeptandCostCentre", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@StoreUserID", StoreUserID);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			(new SqlDataAdapter(sqlCommand)).Fill(dataTable);
			sqlConnection.Close();
			return dataTable;
		}

		public DataTable SelectEstimatedDeliveryDays(long CompanyID)
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

		public virtual void Update_BillingShipping_Address(long AddressID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Phone, string Fax, string Country, string AddressLabel, string Address5, long IsDefaultBilling, long IsDefaultShipping, long StoreUserID)
		{
			Database database = CustomDatabaseFactory.CreateDatabase((new commonclass()).strConnection);
			DataTable dataTable = new DataTable();
			DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Update_BillingShipping_Address");
			database.AddInParameter(storedProcCommand, "@AddressID", DbType.Int64, AddressID);
			database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
			database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
			database.AddInParameter(storedProcCommand, "@Address1", DbType.String, Address1);
			database.AddInParameter(storedProcCommand, "@Address2", DbType.String, Address2);
			database.AddInParameter(storedProcCommand, "@Address3", DbType.String, Address3);
			database.AddInParameter(storedProcCommand, "@Address4", DbType.String, Address4);
			database.AddInParameter(storedProcCommand, "@Address5", DbType.String, Address5);
			database.AddInParameter(storedProcCommand, "@Phone", DbType.String, Phone);
			database.AddInParameter(storedProcCommand, "@Fax", DbType.String, Fax);
			database.AddInParameter(storedProcCommand, "@Country", DbType.String, Country);
			database.AddInParameter(storedProcCommand, "@AddressLabel", DbType.String, AddressLabel);
			database.AddInParameter(storedProcCommand, "@IsDefaultBilling", DbType.Int16, IsDefaultBilling);
			database.AddInParameter(storedProcCommand, "@IsDefaultShipping", DbType.Int16, IsDefaultShipping);
			database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int16, StoreUserID);
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
	}
}