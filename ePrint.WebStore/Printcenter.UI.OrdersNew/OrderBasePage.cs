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

        public static DataTable B2B_Select_All_Address_ByStoreUserID(long StoreUserID)
        {
            return Orders.B2B_Select_All_Address_ByStoreUserID(StoreUserID);
        }

        public static void company_country_select(DropDownList ddlcountry)
        {
            Orders.company_country_select(ddlcountry);
        }

        public static DataTable CustomizeJob_Report(long companyid, long storeuserid, string JobFromDate, string JobToDate)
        {
            return Orders.CustomizeJob_Report(companyid, storeuserid, JobFromDate, JobToDate);
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

        public static void Estimate_insertFrom_WebOrders(int CompanyID, long ClientID, long StoreUserID, long OrderID, DateTime Date, string CreatedDateTime, bool IsApproved, string ApproverEmail)
        {
            Orders.Estimate_insertFrom_WebOrders(CompanyID, ClientID, StoreUserID, OrderID, Date, CreatedDateTime, IsApproved, ApproverEmail);
        }

        public static bool Fetch_Stock_Mgmt_Exists(long CompanyID)
        {
            return Orders.Fetch_Stock_Mgmt_Exists(CompanyID);
        }

        public static bool Get_Catgry_IsApprovalNotRequired(long ProductID)
        {
            return Orders.Get_Catgry_IsApprovalNotRequired(ProductID);
        }

        public static bool Get_Dept_IsApprovalNotRequired(long DepartmentID)
        {
            return Orders.Get_Dept_IsApprovalNotRequired(DepartmentID);
        }

        public static DataTable Get_EditableTemplate_Imageurl(int PriceCatalogueID, int CartItemID)
        {
            return Orders.Get_EditableTemplate_Imageurl(PriceCatalogueID, CartItemID);
        }

        public static DataTable Get_IsApprovalAddress(long StoreUserID)
        {
            return Orders.Get_IsApprovalAddress(StoreUserID);
        }

        public static DataTable Get_IsApprovalProfile(long StoreUserID)
        {
            return Orders.Get_IsApprovalProfile(StoreUserID);
        }

        public static DataTable Get_IsApprove_For_registration(long StoreUserID)
        {
            return Orders.Get_IsApprove_For_registration(StoreUserID);
        }

        public static int GetOrderItems(long OrderID)
        {
            return Orders.GetOrderItems(OrderID);
        }

        public static DataTable GetStoreUserContactDetails(long StoreUserID)
        {
            return Orders.GetStoreUserContactDetails(StoreUserID);
        }

        public static long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Email, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
        {
            return Orders.Insert_BillingShipping_Address(StoreUserID, FirstName, LastName, Address1, Address2, Address3, Address4, Address5, Phone, Email, Fax, Country, IsDefaultBilling, IsDefaultShipping, AddressLabel, CreatedDate);
        }

        public static void Insert_Contact(long CompanyID, long StoreUserID, long AccountID, long AddressID)
        {
            Orders.Insert_Contact(CompanyID, StoreUserID, AccountID, AddressID);
        }

        public static long Insert_Contact(int CompanyID, long ClientID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
        {
            return Orders.Insert_Contact(CompanyID, ClientID, StoreUserID, AccountID, BillingAddressID, ShippingAddressID, FromRegistration, CreatedDate);
        }

        public static void Insert_CreditCardDetails(long OrderID, string CardHolderName, string CardName, long CardNumber, string CardType, string SecurityCode, int ExpirationMonth, int ExpirationYear)
        {
            Orders.Insert_CreditCardDetails(OrderID, CardHolderName, CardName, CardNumber, CardType, SecurityCode, ExpirationMonth, ExpirationYear);
        }

        public static long Insert_CustomerOn_Order(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
        {
            return Orders.Insert_CustomerOn_Order(CompanyID, StoreUserID, AccountID, BillingAddressID, ShippingAddressID, FromRegistration, CreatedDate);
        }

        public static void Insert_InvoicePaymentDetailsForEstore(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Orders.Insert_InvoicePaymentDetailsForEstore(invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber);
        }

        public static void Insert_OrderItemDetails_MIS(long CartItemID, bool IsBackOrder, long EstimateID, long CompanyID, bool ApproveStatus, long StoreUserID, string ApproverEmail, long ClientID, int ItemCount)
        {
            Orders.Insert_OrderItemDetails_MIS(CartItemID, IsBackOrder, EstimateID, CompanyID, ApproveStatus, StoreUserID, ApproverEmail, ClientID, ItemCount);
        }

        public static void Insert_OrderItemDetails_ToNotes(long EstimateID, long CompanyID, long StoreUserID, long itemCount)
        {
            Orders.Insert_OrderItemDetails_ToNotes(EstimateID, CompanyID, StoreUserID, itemCount);
        }

        public static long Insert_Orders(long StoreUserID, long AccountID, string OrderNo, decimal TotalPrice, decimal Tax, decimal OrderShipping, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, string ApproverEmail, long BehalfUserID, long BehalfDeptID, bool IsApproved, long CostCentreID, long OrderedBy, string orderbehalftype)
        {
            return Orders.Insert_Orders(StoreUserID, AccountID, OrderNo, TotalPrice, Tax, OrderShipping, BillingAddressID, ShippingAddressID, CompanyID, ClientID, PaymentType, OrderDate, RequiredDate, Comments, OrderKey, OrderTitle, UserRefOrderNo, ApproverEmail, BehalfUserID, BehalfDeptID, IsApproved, CostCentreID, OrderedBy, orderbehalftype);
        }

        public static long Insert_OrdersItems(long OrderID, long CartItemID, bool BKOrder)
        {
            return Orders.Insert_OrdersItems(OrderID, CartItemID, BKOrder);
        }

        public static void Insert_Personal_Info_Address_temp(long StoreUserID, long AccountID, string AddressLabel, string Fax, string Telephone, string Country, string Address1, string Address2, string Address3, string Address4, string Address5, long AddressID, int IsDefaultBilling, int IsDefaultShipping, string ApproverEmail, string ApprovedType, string PersonalProfileEditType)
        {
            Orders.Insert_Personal_Info_Address_temp(StoreUserID, AccountID, AddressLabel, Fax, Telephone, Country, Address1, Address2, Address3, Address4, Address5, AddressID, IsDefaultBilling, IsDefaultShipping, ApproverEmail, ApprovedType, PersonalProfileEditType);
        }

        public static DataTable Insert_Reorder_Deatil(long OrderID)
        {
            return Orders.Insert_Reorder_Deatil(OrderID);
        }

        public static DataTable Insert_Reordered_CartItemsandDetails(long CartItemID, string GUID, long StoreUserID)
        {
            return Orders.Insert_Reordered_CartItemsandDetails(CartItemID, GUID, StoreUserID);
        }

        public static long InsertOrderDetails_MIS(long StoreUserID, long AccountID, decimal TotalPrice, decimal Tax, long BillingAddressID, long ShippingAddressID, long CompanyID, long ClientID, string PaymentType, DateTime OrderDate, DateTime RequiredDate, string Comments, string OrderKey, string OrderTitle, string UserRefOrderNo, string ApproverEmail, long BehalfUserID, long BehalfDeptID, long CostCentreID, long OrderedBy, string orderbehalftype, bool IsApproved, string BT_OrderID, string BT_AuthorizationCode, long CartID, string Stripe_Paymentid, string IsTwoWayApproval = "0", string DepartmentApproval = "0", string MainApproval = "0", string ApprovalEmails = "")
        {
            return Orders.InsertOrderDetails_MIS(StoreUserID, AccountID, TotalPrice, Tax, BillingAddressID, ShippingAddressID, CompanyID, ClientID, PaymentType, OrderDate, RequiredDate, Comments, OrderKey, OrderTitle, UserRefOrderNo, ApproverEmail, BehalfUserID, BehalfDeptID, CostCentreID, OrderedBy, orderbehalftype, IsApproved, BT_OrderID, BT_AuthorizationCode, CartID, Stripe_Paymentid, IsTwoWayApproval, DepartmentApproval, MainApproval, ApprovalEmails);
        }

        public static DataSet itemdescription_selectall_fromSettings_foralltypes(long companyid, string type)
        {
            return Orders.itemdescription_selectall_fromSettings_foralltypes(companyid, type);
        }

        public static DataSet JobReport_CustomizeCustomer(long companyid, long storeuserid, DateTime JobFromDate, DateTime JobToDate, string filter)
        {
            return Orders.JobReport_CustomizeCustomer(companyid, storeuserid, JobFromDate, JobToDate, filter);
        }

        public static DataTable Order_Status(long OrderID, long EstimateID)
        {
            return Orders.Order_Status(OrderID, EstimateID);
        }

        public static void OrderBehalf_DeptOrUser_Update(string OrderKey, long StoreUserID, long DeptID)
        {
            Orders.OrderBehalf_DeptOrUser_Update(OrderKey, StoreUserID, DeptID);
        }

        public static DataTable OrderMangerOptions_Select(int CompanyID, int AccountID)
        {
            return Orders.OrderMangerOptions_Select(CompanyID, AccountID);
        }

        public static DataTable Orderreport_systemgenerated(int CompanyID, long storeuserid, DateTime fromdate, DateTime todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            return Orders.Orderreport_systemgenerated(CompanyID, storeuserid, fromdate, todate, ISStockItem, IsStockReplenish, AllowUnApprovedOrder);
        }

        public static DataTable Orderreport_systemgenerated_splitoff(int CompanyID, long storeuserid, DateTime fromdate, DateTime todate, string ISStockItem, string IsStockReplenish, bool AllowUnApprovedOrder)
        {
            return Orders.Orderreport_systemgenerated_splitoff(CompanyID, storeuserid, fromdate, todate, ISStockItem, IsStockReplenish, AllowUnApprovedOrder);
        }

        public static DataTable OtherMultipleProductDetails_Select(long PriceCatalogueID, int Quantity, bool IsBackOrder)
        {
            return Orders.OtherMultipleProductDetails_Select(PriceCatalogueID, Quantity, IsBackOrder);
        }

        public static DataTable PreFill_OrderInfo(long ManageCampaignID)
        {
            return Orders.PreFill_OrderInfo(ManageCampaignID);
        }

        public static DataTable Price_For_Whole_Pack_Select(int CompanyID)
        {
            return Orders.Price_For_Whole_Pack_Select(CompanyID);
        }

        public static void PriceCatalogue_ItemDescription_InsertUpdate(long EstimateID)
        {
            Orders.PriceCatalogue_ItemDescription_InsertUpdate(EstimateID);
        }

        public static DataTable Prod_report_stockusage_bymontandYear(long companyid, long storeuserid, string deptid, string monthcategory)
        {
            return Orders.Prod_report_stockusage_bymontandYear(companyid, storeuserid, deptid, monthcategory);
        }

        public static DataTable Product_Report_quartersales(long companyid, long storeuserid)
        {
            return Orders.Product_Report_quartersales(companyid, storeuserid);
        }

        public static DataTable productcatalogue_warehousestock_select(int CompanyID)
        {
            return Orders.productcatalogue_warehousestock_select(CompanyID);
        }

        public static DataTable ProductReport_Stockrelease_adjustment(long companyid, DateTime fromdate, DateTime todate, long storeuserid)
        {
            return Orders.ProductReport_Stockrelease_adjustment(companyid, fromdate, todate, storeuserid);
        }

        public static DataSet productreport_stockusage(long companyid, long storeuserid)
        {
            return Orders.productreport_stockusage(companyid, storeuserid);
        }

        public static void Reject_Order(string OrderNo, string Reason, string Type, long StoreUserID, long OrderItemID)
        {
            Orders.Reject_Order(OrderNo, Reason, Type, StoreUserID, OrderItemID);
        }

        public static void Reject_OrderItem(string OrderNo, string Reason, string Type, long ApproverID, long UserGettingApproved, long OrderItemID)
        {
            Orders.Reject_OrderItem(OrderNo, Reason, Type, ApproverID, UserGettingApproved, OrderItemID);
        }

        public static DataSet Select_B2B_Orders(long StoreUserID, string WhereCondition, string ModuleName, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders)
        {
            return Orders.Select_B2B_Orders(StoreUserID, WhereCondition, ModuleName, Is_Only_User_Jobs, Is_Only_User_DepartmentJobs, Is_User_All_Jobs, Is_only_User_Invoice, Is_only_user_DepartmentInvoice, Is_User_All_Invoice, Is_Only_User_Orders, Is_Only_User_DepartmentOrders, Is_User_All_Orders);
        }

        public static DataSet Select_B2B_Orders_ByItems(long StoreUserID, string WhereCondition, string ModuleName, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders)
        {
            return Orders.Select_B2B_Orders_ByItems(StoreUserID, WhereCondition, ModuleName, Is_Only_User_Jobs, Is_Only_User_DepartmentJobs, Is_User_All_Jobs, Is_only_User_Invoice, Is_only_user_DepartmentInvoice, Is_User_All_Invoice, Is_Only_User_Orders, Is_Only_User_DepartmentOrders, Is_User_All_Orders);
        }

        public static DataTable Select_B2B_Orders_reeng(long StoreUserID, string WhereCondition, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, bool IsHideMISJobVisible, bool IsHideMISInvoiceVisible)
        {
            return Orders.Select_B2B_Orders_reeng(StoreUserID, WhereCondition, Is_Only_User_Jobs, Is_Only_User_DepartmentJobs, Is_User_All_Jobs, Is_only_User_Invoice, Is_only_user_DepartmentInvoice, Is_User_All_Invoice, Is_Only_User_Orders, Is_Only_User_DepartmentOrders, Is_User_All_Orders, IsHideMISJobVisible, IsHideMISInvoiceVisible);
        }

        public static DataTable Select_B2B_Orders_reeng_Approval_New(long StoreUserID, string WhereCondition, string Type, string ModuleName)
        {
            return Orders.Select_B2B_Orders_reeng_Approval_New(StoreUserID, WhereCondition, Type, ModuleName);
        }

        public static DataTable Select_B2B_Orders_reeng_Approval_On(long StoreUserID, string WhereCondition, string Type)
        {
            return Orders.Select_B2B_Orders_reeng_Approval_On(StoreUserID, WhereCondition, Type);
        }

        public static DataTable Select_B2B_Orders_reeng_ByItem(long StoreUserID, string WhereCondition, bool Is_Only_User_Jobs, bool Is_Only_User_DepartmentJobs, bool Is_User_All_Jobs, bool Is_only_User_Invoice, bool Is_only_user_DepartmentInvoice, bool Is_User_All_Invoice, bool Is_Only_User_Orders, bool Is_Only_User_DepartmentOrders, bool Is_User_All_Orders, bool IsHideMISJobVisible, bool IsHideMISInvoiceVisible)
        {
            return Orders.Select_B2B_Orders_reeng_ByItem(StoreUserID, WhereCondition, Is_Only_User_Jobs, Is_Only_User_DepartmentJobs, Is_User_All_Jobs, Is_only_User_Invoice, Is_only_user_DepartmentInvoice, Is_User_All_Invoice, Is_Only_User_Orders, Is_Only_User_DepartmentOrders, Is_User_All_Orders, IsHideMISJobVisible, IsHideMISInvoiceVisible);
        }

        public static DataSet Select_B2B_Pending_Orders(string Email, long StoreUserID, string WhereCondition, string TypeName)
        {
            return Orders.Select_B2B_Pending_Orders(Email, StoreUserID, WhereCondition, TypeName);
        }

        public static DataSet Select_B2B_Pending_Orders_By_Item(string Email, long StoreUserID, string WhereCondition, string TypeName)
        {
            return Orders.Select_B2B_Pending_Orders_By_Item(Email, StoreUserID, WhereCondition, TypeName);
        }

        public static DataSet Select_BehalfUsersOrDept(long AccountID, long StoreUserID)
        {
            return Orders.Select_BehalfUsersOrDept(AccountID, StoreUserID);
        }

        public static DataTable Select_BillingShipping_Address(long AddressID)
        {
            return Orders.Select_BillingShipping_Address(AddressID);
        }

        public static DataTable Select_BillingShipping_Address_Grid(long StoreUserID, string type, long StoreContactID, string Filter)
        {
            return Orders.Select_BillingShipping_Address_Grid(StoreUserID, type, StoreContactID, Filter);
        }

        public static DataTable Select_BillingShippingAddress_OnAddressID(long StoreUserID, long AddressID)
        {
            return Orders.Select_BillingShippingAddress_OnAddressID(StoreUserID, AddressID);
        }

        public static DataTable Select_BillingShippingAddress_DeliveryCost(long AddressID ,bool isfrom, long CompanyID)
        {
            return Orders.Select_BillingShippingAddress_DeliveryCost(AddressID, isfrom, CompanyID);
        }

        public static DataTable Select_BrainTree_Details(long AccountID, long StoreUserID)
        {
            return Orders.Select_BrainTree_Details(AccountID, StoreUserID);
        }

        public static DataTable Select_CustomerAddress(long CompanyID, long StoreUserID, long ContactID)
        {
            return Orders.Select_CustomerAddress(CompanyID, StoreUserID, ContactID);
        }

        public static DataTable Select_DeptOrUser_Name(long ContactID, long DeptID)
        {
            return Orders.Select_DeptOrUser_Name(ContactID, DeptID);
        }

        public static DataTable Select_details_ClientInfo(long CompanyID, string ServerName)
        {
            return Orders.Select_details_ClientInfo(CompanyID, ServerName);
        }

        public static DataTable Select_EstoreReportsEnabled(long StoreUserID, long CompanyID, long Accountid)
        {
            return Orders.Select_EstoreReportsEnabled(StoreUserID, CompanyID, Accountid);
        }

        public static DataTable Select_Individual_Address(long StoreUserID, long AddressID, long StoreContactID)
        {
            return Orders.Select_Individual_Address(StoreUserID, AddressID, StoreContactID);
        }

        public static DataSet Select_MainOrDepOrUser(long StoreUserID)
        {
            return Orders.Select_MainOrDepOrUser(StoreUserID);
        }

        public static DataTable PC_select_DeliveryCost_Settings(int CompanyID, int AccountID)
        {
            return Orders.PC_select_DeliveryCost_Settings(CompanyID, AccountID);
        }

        public static DataTable Select_OrderAdditionalItems(long OrderItemID)
        {
            return Orders.Select_OrderAdditionalItems(OrderItemID);
        }

        public static DataTable Select_OrderAdditionalOptions(long StoreUserID, string OrderID)
        {
            return Orders.Select_OrderAdditionalOptions(StoreUserID, OrderID);
        }

        public static DataTable Select_OrderID(string OrderKey)
        {
            return Orders.Select_OrderID(OrderKey);
        }

        public static DataTable Select_OrderItems(long OrderID, long StoreUserID)
        {
            return Orders.Select_OrderItems(OrderID, StoreUserID);
        }

        public static DataTable Select_OrderItems(string OrderID, long StoreUserID)
        {
            return Orders.Select_OrderItems(OrderID, StoreUserID);
        }

        public static DataSet Select_OrderItems_BeforeOrder(long StoreUserID, string MultipleCartID)
        {
            return Orders.Select_OrderItems_BeforeOrder(StoreUserID, MultipleCartID);
        }

        public static DataTable Select_OrderItems_ForStock(long OrderID, long StoreUserID, string ItemIDs)
        {
            return Orders.Select_OrderItems_ForStock(OrderID, StoreUserID, ItemIDs);
        }

        public static DataTable Select_Orders(long StoreUserID)
        {
            return Orders.Select_Orders(StoreUserID);
        }

        public static DataTable Select_Orders_reeng(long StoreUserID)
        {
            return Orders.Select_Orders_reeng(StoreUserID);
        }

        public static DataTable Select_ProductDetailsTag(int CompanyID, int AccountID, long EmailToCustomerID)
        {
            return Orders.Select_ProductDetailsTag(CompanyID, AccountID, EmailToCustomerID);
        }

        public static DataSet Select_Reports_databyreportid(long reportid, long companyid, long storeuserid, DateTime fromdate, DateTime todate, int pagesize, int pagenumber)
        {
            return Orders.Select_Reports_databyreportid(reportid, companyid, storeuserid, fromdate, todate, pagesize, pagenumber);
        }

        public static DataTable Select_Reports_forCustomer(long storeuserid, string pagename)
        {
            return Orders.Select_Reports_forCustomer(storeuserid, pagename);
        }

        public static DataTable Select_StoreUserID_UserDept_Behalf(string cartitemids, string orderbehalftype)
        {
            return Orders.Select_StoreUserID_UserDept_Behalf(cartitemids, orderbehalftype);
        }

        public static DataSet SelectDeptandCostCentre(long StoreUserID, string orderbehalftype, long DeptID)
        {
            return Orders.SelectDeptandCostCentre(StoreUserID, orderbehalftype, DeptID);
        }

        public static DataTable SelectEstimateDays(long CompanyID)
        {
            return Orders.SelectEstimateDays(CompanyID);
        }

        public static DataTable settings_companyprofile_select(int CompanyID)
        {
            return Orders.settings_companyprofile_select(CompanyID);
        }

        public static DataTable settings_regionalsettings_select(int CompanyID)
        {
            return Orders.settings_regionalsettings_select(CompanyID);
        }

        public static void Update_BillingShipping_Address(long AddressID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Phone, string Email, string Fax, string Country, string AddressLabel, string Address5)
        {
            Orders.Update_BillingShipping_Address(AddressID, FirstName, LastName, Address1, Address2, Address3, Address4, Phone, Email, Fax, Country, AddressLabel, Address5);
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

        public static DataTable Ws_Get_TaxName(int AccountID)
        {
            return Orders.Ws_Get_TaxName(AccountID);
        }
        public static DataTable settings_OrderingProcess_select(int CompanyID, int AccountID)
        {
            return Orders.settings_OrderingProcess_select(CompanyID, AccountID);
        }
        public static DataSet approvalsystemsettings_getDetails(long UserID, long CompanyID, long AccountID)
        {
            return Orders.approvalsystemsettings_getDetails(UserID, CompanyID, AccountID);
        }

        public static int etimates_attachment_insert(int CompanyID, int AttachmentID, string AttachmentType, int AttachmentTypeID, string FileName, int EstimateID, string ModuleType, int UploadedBy, bool IsDisplayToEstore, string OriginalFileName, string ReportFile, bool IsDisplayToPdf)
        {
            return Orders.etimates_attachment_insert(CompanyID, AttachmentID, AttachmentType, AttachmentTypeID, FileName, EstimateID, ModuleType, UploadedBy, IsDisplayToEstore, OriginalFileName, ReportFile, IsDisplayToPdf);
        }

        public static DataSet GetStockUsage_InPacks_cost(int CompanyID, long StoreUserID, string WhereCondition)
        {
            return Orders.GetStockUsage_InPacks_cost(CompanyID, StoreUserID,WhereCondition);
        }
        public static DataTable ProductstockUsageHistoryReport(long CompanyID, long StoreUserID, string DepartmentID, string MonthCatagory)
        {
            return Orders.ProductstockUsageHistoryReport(CompanyID, StoreUserID, DepartmentID, MonthCatagory);
        }
        public static DataTable GetProduct_SelectDepartment(int CompanyID, long StoreUserID)
        {
            return Orders.GetProduct_SelectDepartment(CompanyID, StoreUserID);
        }
        public static DataTable etimates_attachment_select(int CompanyID, int UserID, string AttachmentType, int EstimateID, string ModuleType)
        {
            return Orders.etimates_attachment_select(CompanyID, UserID, AttachmentType,  EstimateID, ModuleType);
        }
        public static void etimates_attachment_delete(int companyid, long attachmentid)
        {
            Orders.etimates_attachment_delete(companyid, attachmentid);
        }
        public static DataTable GetPriceCatalogueIDByEstimateID(int CompanyID, long EstimateID)
        {
            return Orders.GetPriceCatalogueIDByEstimateID(CompanyID, EstimateID);
        }

    }
}