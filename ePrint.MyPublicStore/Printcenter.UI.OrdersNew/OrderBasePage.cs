using Printcenter.BusinessAccessLayer.Orders;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.OrdersNew
{
	public class OrderBasePage
	{
		public OrderBasePage()
		{
		}

		public static void company_country_select(DropDownList ddlcountry)
		{
			Orders.company_country_select(ddlcountry);
		}

		public static void Delete_BillingShippingAddress(long StoreUserID, long AddressID)
		{
			Orders.Delete_BillingShippingAddress(StoreUserID, AddressID);
		}

		public static DataSet EmailToAdmin_SelectIsActiveType(long CompanyID)
		{
			return Orders.EmailToAdmin_SelectIsActiveType(CompanyID);
		}

		public static DataSet EmailToAdminBackORD_SelectIsActiveType(long CompanyID)
		{
			return Orders.EmailToAdminBackORD_SelectIsActiveType(CompanyID);
		}

		public static DataTable EmailToCustomer_Select_WebStore(int CompanyID, int AccountID, long EmailToCustomerID, string TagEvent, string EmailFor)
		{
			return Orders.EmailToCustomer_Select_WebStore(CompanyID, AccountID, EmailToCustomerID, TagEvent, EmailFor);
		}

		public static void Estimate_insertFrom_WebOrders(int CompanyID, long ClientID, long StoreUserID, long OrderID, DateTime Date, string CreatedDateTime)
		{
			Orders.Estimate_insertFrom_WebOrders(CompanyID, ClientID, StoreUserID, OrderID, Date, CreatedDateTime);
		}

		public static bool Fetch_Stock_Mgmt_Exists(long CompanyID)
		{
			return Orders.Fetch_Stock_Mgmt_Exists(CompanyID);
		}

		public static DataTable Get_EditableTemplate_Imageurl(int PriceCatalogueID, int CartItemID)
		{
			return Orders.Get_EditableTemplate_Imageurl(PriceCatalogueID, CartItemID);
		}

		public static void Insert_AgentCode_Details(long EstimateID, string AGentCode, string SecretCode)
		{
			Orders.Insert_AgentCode_Details(EstimateID, AGentCode, SecretCode);
		}

		public static long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
		{
			return Orders.Insert_BillingShipping_Address(StoreUserID, FirstName, LastName, Address1, Address2, Address3, Address4, Address5, Phone, Fax, Country, IsDefaultBilling, IsDefaultShipping, AddressLabel, CreatedDate);
		}

		public static void Insert_Contact(long CompanyID, long StoreUserID, long AccountID, long AddressID)
		{
			Orders.Insert_Contact(CompanyID, StoreUserID, AccountID, AddressID);
		}

		public static void Insert_InvoicePaymentDetailsForEstore(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
		{
			Orders.Insert_InvoicePaymentDetailsForEstore(invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber);
		}
		public static long Insert_Contact(int CompanyID, long ClientID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
		{
			return Orders.Insert_Contact(CompanyID, ClientID, StoreUserID, AccountID, BillingAddressID, ShippingAddressID, FromRegistration, CreatedDate);
		}

		public static void Insert_CreditCardDetails(long OrderID, string CardHolderName, string CardName, long CardNumber, string CardType, string SecurityCode, int ExpirationMonth, int ExpirationYear)
		{
			Orders.Insert_CreditCardDetails(OrderID, CardHolderName, CardName, CardNumber, CardType, SecurityCode, ExpirationMonth, ExpirationYear);
		}

		public static long Insert_CustomerOn_Order(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate, string Phone, string MobilePhone)
		{
			return Orders.Insert_CustomerOn_Order(CompanyID, StoreUserID, AccountID, BillingAddressID, ShippingAddressID, FromRegistration, CreatedDate, Phone, MobilePhone);
		}

		public static long Insert_CustomerOn_OrderAgentCode(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
		{
			return Orders.Insert_CustomerOn_OrderAgentCode(CompanyID, StoreUserID, AccountID, BillingAddressID, ShippingAddressID, FromRegistration, CreatedDate);
		}

		public static void Insert_OrderItemDetails_MIS(long CartItemID, bool IsBackOrder, long EstimateID, long CompanyID, long StoreUserID, int ItemCount)
		{
			Orders.Insert_OrderItemDetails_MIS(CartItemID, IsBackOrder, EstimateID, CompanyID, StoreUserID, ItemCount);
		}

		public static void Insert_OrderItemDetails_ToNotes(long EstimateID, long CompanyID, long StoreUserID, long itemCount)
		{
			Orders.Insert_OrderItemDetails_ToNotes(EstimateID, CompanyID, StoreUserID, itemCount);
		}

		public static long Insert_Orders(long StoreUserID, long AccountID, string OrderNo, decimal TotalPrice, decimal Tax, decimal OrderShipping, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, long CostCentreID)
		{
			return Orders.Insert_Orders(StoreUserID, AccountID, OrderNo, TotalPrice, Tax, OrderShipping, BillingAddressID, ShippingAddressID, CompanyID, ClientID, PaymentType, OrderDate, RequiredDate, Comments, OrderKey, OrderTitle, UserRefOrderNo, CostCentreID);
		}

		public static long Insert_OrdersItems(long OrderID, long CartItemID, bool IsBackOrder)
		{
			return Orders.Insert_OrdersItems(OrderID, CartItemID, IsBackOrder);
		}

		public static DataTable Insert_Reorder_Deatil(long OrderID)
		{
			return Orders.Insert_Reorder_Deatil(OrderID);
		}

		public static DataTable Insert_Reordered_CartItemsandDetails(long CartItemID, string GUID, long StoreUserID)
		{
			return Orders.Insert_Reordered_CartItemsandDetails(CartItemID, GUID, StoreUserID);
		}

		public static long InsertOrderDetails_MIS(long StoreUserID, long AccountID, decimal TotalPrice, decimal Tax, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, long CostCentreID, string BT_OrderID, string BT_AuthorizationCode, long CartID, string Stripe_Paymentid)
		{
			return Orders.InsertOrderDetails_MIS(StoreUserID, AccountID, TotalPrice, Tax, BillingAddressID, ShippingAddressID, CompanyID, ClientID, PaymentType, OrderDate, RequiredDate, Comments, OrderKey, OrderTitle, UserRefOrderNo, CostCentreID, BT_OrderID, BT_AuthorizationCode, CartID, Stripe_Paymentid);
		}

		public static DataTable Order_Status(long OrderID, long EstimateID)
		{
			return Orders.Order_Status(OrderID, EstimateID);
		}

		public static DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
		{
			return Orders.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder);
		}

		public static void PriceCatalogue_ItemDescription_InsertUpdate(long EstimateID)
		{
			Orders.PriceCatalogue_ItemDescription_InsertUpdate(EstimateID);
		}

		public static DataTable Select_BillingShipping_Address(long StoreUserID, string type, long StoreContactID)
		{
			return Orders.Select_BillingShipping_Address(StoreUserID, type, StoreContactID);
		}

		public static DataTable Select_BillingShipping_Address_Grid(long StoreUserID, string type, long StoreContactID, string Filter)
		{
			return Orders.Select_BillingShipping_Address_Grid(StoreUserID, type, StoreContactID, Filter);
		}

		public static DataTable Select_BillingShippingAddress_OnAddressID(long StoreUserID, long AddressID)
		{
			return Orders.Select_BillingShippingAddress_OnAddressID(StoreUserID, AddressID);
		}

		public static DataTable Select_BrainTree_Details(long AccountID, long StoreUserID)
		{
			return Orders.Select_BrainTree_Details(AccountID, StoreUserID);
		}

		public static DataTable Select_CustomerAddress(long CompanyID, long StoreUserID, long ContactID)
		{
			return Orders.Select_CustomerAddress(CompanyID, StoreUserID, ContactID);
		}

		public static DataTable Select_details_ClientInfo(long CompanyID, string ServerName)
		{
			return Orders.Select_details_ClientInfo(CompanyID, ServerName);
		}

		public static DataTable Select_Individual_Address(long StoreUserID, long AddressID, long StoreContactID)
		{
			return Orders.Select_Individual_Address(StoreUserID, AddressID, StoreContactID);
		}

		public static DataSet Select_MainOrDepOrUser(long StoreUserID)
		{
			return Orders.Select_MainOrDepOrUser(StoreUserID);
		}

		public static DataTable Select_One_BillingShipping_Address(long AddressID)
		{
			return Orders.Select_One_BillingShipping_Address(AddressID);
		}

		public static DataTable Select_OrderAdditionalItems(long OrderItemID)
		{
			return Orders.Select_OrderAdditionalItems(OrderItemID);
		}

		public static DataTable Select_OrderAdditionalOptions(long StoreUserID, long OrderID)
		{
			return Orders.Select_OrderAdditionalOptions(StoreUserID, OrderID);
		}

		public static DataTable Select_OrderID(string OrderKey, long StoreUserID)
		{
			return Orders.Select_OrderID(OrderKey, StoreUserID);
		}

		public static DataTable Select_OrderItems(long OrderID, long StoreUserID)
		{
			return Orders.Select_OrderItems(OrderID, StoreUserID);
		}

		public static DataTable Select_OrderItems(string OrderID, long StoreUserID)
		{
			return Orders.Select_OrderItems(OrderID, StoreUserID);
		}

		public static DataSet Select_OrderItems_BeforeOrder(long StoreUserID)
		{
			return Orders.Select_OrderItems_BeforeOrder(StoreUserID);
		}

		public static DataSet Select_OrderItems_BeforeOrder(long StoreUserID, string MultipleCartID)
		{
			return Orders.Select_OrderItems_BeforeOrder(StoreUserID, MultipleCartID);
		}

		public static DataTable Select_Orders(long StoreUserID)
		{
			return Orders.Select_Orders(StoreUserID);
		}

		public static DataTable Select_Orders_Individiually(long StoreUserID, string ModuleName, string WhereCondition)
		{
			return Orders.Select_Orders_Individiually(StoreUserID, ModuleName, WhereCondition);
		}

		public static DataTable Select_Orders_reeng(long StoreUserID, string WhereCondition)
		{
			return Orders.Select_Orders_reeng(StoreUserID, WhereCondition);
		}

		public static DataTable Select_ProductDetailsTag(int CompanyID, int AccountID, long EmailToCustomerID)
		{
			return Orders.Select_ProductDetailsTag(CompanyID, AccountID, EmailToCustomerID);
		}

		public static DataTable SelectDeptandCostCentre(long StoreUserID)
		{
			return Orders.SelectDeptandCostCentre(StoreUserID);
		}

		public static DataTable SelectEstimatedDeliveryDays(long CompanyID)
		{
			return Orders.SelectEstimatedDeliveryDays(CompanyID);
		}

		public static DataTable settings_companyprofile_select(int CompanyID)
		{
			return Orders.settings_companyprofile_select(CompanyID);
		}

		public static DataTable settings_regionalsettings_select(int CompanyID)
		{
			return Orders.settings_regionalsettings_select(CompanyID);
		}

		public static void Update_BillingShipping_Address(long AddressID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Phone, string Fax, string Country, string AddressLabel, string Address5, long IsDefaultBilling, long IsDefaultShipping, long StoreUserID)
		{
			Orders.Update_BillingShipping_Address(AddressID, FirstName, LastName, Address1, Address2, Address3, Address4, Phone, Fax, Country, AddressLabel, Address5, IsDefaultBilling, IsDefaultShipping, StoreUserID);
		}

		public static void update_BillingShipping_AddressID(long StoreUserID, long AddressID, int IsDefaultBilling, int IsDefaultShipping)
		{
			Orders.update_BillingShipping_AddressID(StoreUserID, AddressID, IsDefaultBilling, IsDefaultShipping);
		}

		public static void Update_ConfirmOrder(long OrderID)
		{
			Orders.Update_ConfirmOrder(OrderID);
		}

		public static void Update_Orders(long OrderID, long BillingAddressID, long ShippingAddressID, long ClientID)
		{
			Orders.Update_Orders(OrderID, BillingAddressID, ShippingAddressID, ClientID);
		}
	}
}