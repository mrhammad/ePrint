using Printcenter.BusinessAccessLayer;
using Printcenter.DataAccessLayer.Company;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.BusinessAccessLayer.Company
{
	public class Company : BaseBusiness
	{
		public Company()
		{
		}

		public static DataTable Account_Number_Generate(long CompanyID, string ModuleType)
		{
			return (new DbCompany()).Account_Number_Generate(CompanyID, ModuleType);
		}

		public static DataTable ActiveHistoryEstimate(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryEstimate(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryEstimate_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
		{
			return (new DbCompany()).ActiveHistoryEstimate_Filter(ClientID, SalesPersonCondition, WhereConditionEstimate);
		}

		public static DataTable ActiveHistoryEstimate_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryEstimate_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryEstimate_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
		{
			return (new DbCompany()).ActiveHistoryEstimate_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionEstimate);
		}

		public static DataTable ActiveHistoryeStore(int CompanyID, int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryeStore(CompanyID, ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryeStore_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
		{
			return (new DbCompany()).ActiveHistoryeStore_Filter(CompanyID, ClientID, SalesPersonCondition, WhereConditionEstore);
		}

		public static DataTable ActiveHistoryeStore_SplitItems_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
		{
			return (new DbCompany()).ActiveHistoryeStore_SplitItems_Filter(CompanyID, ClientID, SalesPersonCondition, WhereConditionEstore);
		}

		public static DataTable ActiveHistoryInvoice(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryInvoice(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryInvoice_Filter(int ClientID, string SalesPersonCondition, string WhereConditionInvoice)
		{
			return (new DbCompany()).ActiveHistoryInvoice_Filter(ClientID, SalesPersonCondition, WhereConditionInvoice);
		}

		public static DataTable ActiveHistoryInvoice_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryInvoice_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryInvoice_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return (new DbCompany()).ActiveHistoryInvoice_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public static DataTable ActiveHistoryJobs(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryJobs(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryJobs_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return (new DbCompany()).ActiveHistoryJobs_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public static DataTable ActiveHistoryJobs_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return (new DbCompany()).ActiveHistoryJobs_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryJobs_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return (new DbCompany()).ActiveHistoryJobs_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public static void address_delete(int companyid, int addressid, int userid)
		{
			(new DbCompany()).address_delete(companyid, addressid, userid);
		}

		public static int address_insert(CompanyItem item)
		{
			return (new DbCompany()).address_insert(item);
		}

		public static void address_select(int companyid, int userid, int addresssid, TextBox txtaddress, TextBox txtcity, TextBox txtstate, DropDownList ddlcountry, TextBox txttelephone, TextBox txtfax, TextBox txtzipcode, TextBox txtref, TextBox txtemail, CheckBox chkemail, CheckBox chkdelivery, CheckBox chkbilling, CheckBox chkpostbox, TextBox txt_AddressLabel, TextBox txt_addressline5, TextBox txtURL, CheckBox isHideAddress)
		{
			DbCompany dbCompany = new DbCompany();
			dbCompany.address_select(companyid, userid, addresssid, txtaddress, txtcity, txtstate, ddlcountry, txttelephone, txtfax, txtzipcode, txtref, txtemail, chkemail, chkdelivery, chkbilling, chkpostbox, txt_AddressLabel, txt_addressline5, txtURL, isHideAddress);
		}

		public static DataTable address_select_For_Edit(int CompanyID, int AddressID, int UserID)
		{
			return (new DbCompany()).address_select_For_Edit(CompanyID, AddressID, UserID);
		}

		public static void address_update(CompanyItem item)
		{
			(new DbCompany()).address_update(item);
		}

		public static int Campaign_customview_count(int CompanyID)
		{
			return (new DbCompany()).Campaign_customview_count(CompanyID);
		}

		public static int Check_Dept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
		{
			return (new DbCompany()).Check_Dept_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
		}
        public static int Check_Cost_Centre_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
        {
            return (new DbCompany()).Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
        }
        

        public static int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
		{
			return (new DbCompany()).Check_EmailID_Duplicacy_for_Account(EmailID, Client_ID, Contact_ID);
		}

		public static int Check_EmailID_Duplicate_for_Account(string EmailID, long Client_ID)
		{
			return (new DbCompany()).Check_EmailID_Duplicate_for_Account(EmailID, Client_ID);
		}

		public static int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			return (new DbCompany()).CheckEmailID_Duplicacy(StoreUserID, EmailID, AccountID);
		}

		public static DataTable client_contact_selectnew(int CompanyID)
		{
			return (new DbCompany()).client_contact_selectnew(CompanyID);
		}

		public static DataTable client_contacts_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).client_contacts_select(CompanyID, ClientID);
		}

        public static DataSet client_contacts_select_for_filter(int CompanyID, int ClientID, int pageno, int pagesize, string WhereConditionContact)
		{
			return (new DbCompany()).client_contacts_select_for_filter(CompanyID, ClientID,  pageno,  pagesize, WhereConditionContact);
		}

		public static DataTable client_contacts_select_Praveen(int CompanyID, int ClientID)
		{
			return (new DbCompany()).client_contacts_select_Praveen(CompanyID, ClientID);
		}

		public static void client_defaultcontact(int CompanyID, int ClientID, int ContactID)
		{
			(new DbCompany()).client_defaultcontact(CompanyID, ClientID, ContactID);
		}

		public static DataTable Client_GetLast_Account(int CompanyID, string CompanyType)
		{
			return (new DbCompany()).Client_GetLast_Account(CompanyID, CompanyType);
		}

		public static void Client_ReferencedBy_Insert(int CompanyID, int retClientID, string ReferencedBy, int ReferencedID)
		{
			(new DbCompany()).Client_ReferencedBy_Insert(CompanyID, retClientID, ReferencedBy, ReferencedID);
		}

		public static DataTable Clientaddresslabels(int CompanyID)
		{
			return (new DbCompany()).Clientaddresslabels(CompanyID);
		}

		public static DataTable ClientReferencedByName_Select(string Name, int CompanyID)
		{
			return (new DbCompany()).ClientReferencedByName_Select(Name, CompanyID);
		}

		public static DataTable company_activityhistory_select(int CompanyID, int CustomerID, string SearchText, string ModuleType, string DateType, string FromDate, string ToDate)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.company_activityhistory_select(CompanyID, CustomerID, SearchText, ModuleType, DateType, FromDate, ToDate);
		}

		public static DataTable company_address_select(int ClientID, int CompanyID, string SelectAll)
		{
			return (new DbCompany()).company_address_select(ClientID, CompanyID, SelectAll);
		}

		public static DataTable company_address_select_one(int CompanyID, int AddressID, int ClientID)
		{
			return (new DbCompany()).company_address_select_one(CompanyID, AddressID, ClientID);
		}

		public static DataTable company_autocomplete(int CompanyID, string CompanyType, string ClientName)
		{
			return (new DbCompany()).company_autocomplete(CompanyID, CompanyType, ClientName);
		}

		public static void company_carrier_supplier_select(int companyid, DropDownList ddlsupplier)
		{
			(new DbCompany()).company_carrier_supplier_select(companyid, ddlsupplier);
		}

		public static DataTable company_client_address_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_client_address_select(CompanyID, ClientID);
		}

		public static DataTable company_client_alladdress_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_client_alladdress_select(CompanyID, ClientID);
		}

		public static DataTable company_client_alladdress_select_clientname(int CompanyID, int ClientID, string ClientAddress)
		{
			return (new DbCompany()).company_client_alladdress_select_clientname(CompanyID, ClientID, ClientAddress);
		}

		public static DataTable company_client_alladdress_select_split(int CompanyID, int ClientID, string FreeText)
		{
			return (new DbCompany()).company_client_alladdress_select_split(CompanyID, ClientID, FreeText);
		}

		public static void company_client_defaultaddresstype_update(int CompanyID, int ClientID, string IsDelOrInv, string DefaultType, int DefaultID)
		{
			(new DbCompany()).company_client_defaultaddresstype_update(CompanyID, ClientID, IsDelOrInv, DefaultType, DefaultID);
		}

		public static DataTable company_client_defaultdeliverytype_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_client_defaultdeliverytype_select(CompanyID, ClientID);
		}

		public static void company_client_delete(int CompanyID, int ClientID)
		{
			(new DbCompany()).company_client_delete(CompanyID, ClientID);
		}

		public static void company_client_email_delete(int UserID)
		{
			(new DbCompany()).company_client_email_delete(UserID);
		}

		public static void company_client_email_insert(int UserID, string FileName)
		{
			(new DbCompany()).company_client_email_insert(UserID, FileName);
		}

		public static DataTable company_client_email_select(int UserID)
		{
			return (new DbCompany()).company_client_email_select(UserID);
		}

		public static string company_client_fax_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_client_fax_select(CompanyID, ClientID);
		}

		public static DataTable company_client_For_subsection(int CompanyID, int ClientID, string CompanyType)
		{
			return (new DbCompany()).company_client_For_subsection(CompanyID, ClientID, CompanyType);
		}

		public static int company_client_insert(int CompanyID, int ClientID, string Query, bool IsDefaultDeliveryAddress, bool IsDefaultInvoiceAddress)
		{
			return (new DbCompany()).company_client_insert(CompanyID, ClientID, Query, IsDefaultDeliveryAddress, IsDefaultInvoiceAddress);
		}

		public static DataTable company_client_select(int CompanyID, int ClientID, string CompanyType)
		{
			return (new DbCompany()).company_client_select(CompanyID, ClientID, CompanyType);
		}
        public static DataTable company_InvoiceContact_select(int CompanyID, int EstID, string type)
        {
            return (new DbCompany()).company_InvoiceContact_select(CompanyID, EstID,type);
        }
        

        public static string company_contact_address_select(int CompanyID, int ContactID)
		{
			return (new DbCompany()).company_contact_address_select(CompanyID, ContactID);
		}

		public static bool HasInvoiceContact(int CompanyID, int ContactID)
		{
			return (new DbCompany()).HasInvoiceContact(CompanyID, ContactID);
		}

		public static DataTable company_contact_address_select_new(int CompanyID, int ContactID)
		{
			return (new DbCompany()).company_contact_address_select_new(CompanyID, ContactID);
		}

		public static DataTable company_contact_address_selectall(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_contact_address_selectall(CompanyID, ClientID);
		}

		public static DataTable company_contact_address_selectall_new(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_contact_address_selectall_new(CompanyID, ClientID);
		}

		public static DataTable company_contact_deladdr_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_contact_deladdr_select(CompanyID, ClientID);
		}

		public static void company_contact_delete(int CompanyID, int ClientID, int ContactID)
		{
			(new DbCompany()).company_contact_delete(CompanyID, ClientID, ContactID);
		}

		public static int company_contact_insert(int CompanyID, int ClientID, int ContactID, string Query, bool DefaultContact, bool DefaultDeliveryAddress, bool DefaultInvoiceAddress)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.company_contact_insert(CompanyID, ClientID, ContactID, Query, DefaultContact, DefaultDeliveryAddress, DefaultInvoiceAddress);
		}

		public static DataTable company_contact_select(int CompanyID, int ContactID, int ClientID)
		{
			return (new DbCompany()).company_contact_select(CompanyID, ContactID, ClientID);
		}

        public static DataTable PC_company_contactByContactId_select(int ContactID)
        {
            return (new DbCompany()).PC_company_contactByContactId_select(ContactID);
        }

		public static DataTable PC_company_StoreCredit_select(int ContactID)
		{
			return (new DbCompany()).PC_company_StoreCredit_select(ContactID);
		}

		public static DataTable company_contacts_byid_select(int CompanyID, int ClientID, int ContactID)
		{
			return (new DbCompany()).company_contacts_byid_select(CompanyID, ClientID, ContactID);
		}

		public static DataTable company_contacts_select(int CompanyID, int ClientID, string SelectAll)
		{
			return (new DbCompany()).company_contacts_select(CompanyID, ClientID, SelectAll);
		}

		public static void company_convert_to_customer(int ClientID)
		{
			(new DbCompany()).company_convert_to_customer(ClientID);
		}

		public static void company_country_select(DropDownList ddlcountry)
		{
			(new DbCompany()).company_country_select(ddlcountry);
		}

		public static DataTable company_customer_autocomplete(int CompanyID, string ClientName, string isDisplaySupplier)
		{
			return (new DbCompany()).company_customer_autocomplete(CompanyID, ClientName, isDisplaySupplier);
		}

		public static void company_customer_bind(int companyid, DropDownList ddlcustomer)
		{
			(new DbCompany()).company_customer_bind(companyid, ddlcustomer);
		}

		public static DataTable company_customer_select(int companyid)
		{
			return (new DbCompany()).company_customer_select(companyid);
		}
		public static DataTable company_customer_select_by_clientID(int CompanyID, long ClientID)
		{
			return (new DbCompany()).company_customer_select_by_clientID(CompanyID,ClientID);
		}
		public static string company_customizedvalue_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).company_customizedvalue_select(CompanyID, ClientID);
		}

		public static DataTable company_customizefield_select(string pg, int CompanyID, int UserID, int CustomizeID)
		{
			return (new DbCompany()).company_customizefield_select(pg, CompanyID, UserID, CustomizeID);
		}

		public static int Company_InsertUpdate(int CompanyID, int ClientID, string CompanyType, string ClientName, string ClientAlias, string Type, string AccountStatus, string AccountNumber, string BusinessEmail, string WebSite, string CreditLimit, string CreditRef, int Tax1, int Tax2, string TaxRegNo, string PaymentTerms, string CompanyNumber, string ProfitMargin, DateTime AcOpened, string BankCode, string BankAccountNumber, string AccountName, int SalesPerson, string TaxNumber, string Balance, string Description, DateTime ModifiedDate, int ModifyUserId, int ReferencedID, int iscarrier, bool RoyalityFree, string ClientTypeID, string ClientType, Boolean TaxPrecedence)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.Company_InsertUpdate(CompanyID, ClientID, CompanyType, ClientName, ClientAlias, Type, AccountStatus, AccountNumber, BusinessEmail, WebSite, CreditLimit, CreditRef, Tax1, Tax2, TaxRegNo, PaymentTerms, CompanyNumber, ProfitMargin, AcOpened, BankCode, BankAccountNumber, AccountName, SalesPerson, TaxNumber, Balance, Description, ModifiedDate, ModifyUserId, ReferencedID, iscarrier, RoyalityFree, ClientTypeID, ClientType, TaxPrecedence);
		}

		public static DataTable company_logo_select(int CompanyID, string LogoType)
		{
			return (new DbCompany()).company_logo_select(CompanyID, LogoType);
		}

		public static void company_ownership_customer_bind(int companyid, string companytype, DropDownList ddlAccount)
		{
			(new DbCompany()).company_ownership_customer_bind(companyid, companytype, ddlAccount);
		}

		public static DataTable company_prospect_select(int companyid)
		{
			return (new DbCompany()).company_prospect_select(companyid);
		}

		public static void company_prospect_to_customer(int CompanyID, int Clientid)
		{
			(new DbCompany()).company_prospect_to_customer(CompanyID, Clientid);
		}

		public static DataSet company_select(int companyid, string companytype)
		{
			return (new DbCompany()).company_select(companyid, companytype);
		}

		public static DataTable company_select_By_ID(int companyid, int clientid)
		{
			return (new DbCompany()).company_select_By_ID(companyid, clientid);
		}

		public static void company_supplier_select(int companyid, DropDownList ddlsupplier)
		{
			(new DbCompany()).company_supplier_select(companyid, ddlsupplier);
		}

		public static DataTable company_supplierddl_select(int companyid)
		{
			return (new DbCompany()).company_supplierddl_select(companyid);
		}

		public static void CompanyAddress_Update(long CompanyID, string Type, long ClientID, long ContactID, long InvoiceAddressID, int IsDefaultDelivery, int IsDefaultInvoice, long DeliveryAddressID)
		{
			DbCompany dbCompany = new DbCompany();
			dbCompany.CompanyAddress_Update(CompanyID, Type, ClientID, ContactID, InvoiceAddressID, IsDefaultDelivery, IsDefaultInvoice, DeliveryAddressID);
		}

		public static long CompanyDefaultAddress_InsertUpdate(long AddressID, long ClientID, string Address, string City, string State, string ZipCode, string Country, string Telephone, string Fax, string URL, int CreatedUserID, string CreatedDate, string AddressLabel, string AddressLine2, string Email, string IsHideAddress)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.CompanyDefaultAddress_InsertUpdate(AddressID, ClientID, Address, City, State, ZipCode, Country, Telephone, Fax, URL, CreatedUserID, CreatedDate, AddressLabel, AddressLine2, Email, IsHideAddress);
		}

		public static DataTable contact_default_info(int CompanyID, int ContactID)
		{
			return (new DbCompany()).contact_default_info(CompanyID, ContactID);
		}

		public static void contact_delete(int companyid, string contactids, int userid)
		{
			(new DbCompany()).contact_delete(companyid, contactids, userid);
		}

		public static int Contact_InsertUpdate(int CompanyID, int ContactID, int ClientID, string Salutation, string FirstName, string MiddleName, string LastName, string ContactAlias, string CompanyName, string JobTitle, string JobTitle2, string HomeTelephone, string Mobile, string Email, int ReportToUserID, int CreateUserID, long DepartmentID, string PersonalFax, int ContactAddressID, bool MainApprover, int ChkSubscribed, int IsReceiveMailOut, string AlternateNumbers, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, string ActualFilename, string OriginalFileName, bool IsPdf, DateTime TodaysDate)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.Contact_InsertUpdate(CompanyID, ContactID, ClientID, Salutation, FirstName, MiddleName, LastName, ContactAlias, CompanyName, JobTitle, JobTitle2, HomeTelephone, Mobile, Email, ReportToUserID, CreateUserID, DepartmentID, PersonalFax, ContactAddressID, MainApprover, ChkSubscribed, IsReceiveMailOut, AlternateNumbers, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, ActualFilename, OriginalFileName, IsPdf, TodaysDate);
		}

		public static void Contact_or_Dept_SpendLimitUpdate(int CompanyID, long ContactId, string Duration, decimal Amount, string Type, Boolean EnableRollOver, string RollOverLimit, DateTime RollOverStart)
		{
			(new DbCompany()).Contact_or_Dept_SpendLimitUpdate(CompanyID, ContactId, Duration, Amount, Type, EnableRollOver, RollOverLimit, RollOverStart);
		}
		public static void StoreCreditUpdate(int CompanyID, long ContactId, Double StoreCredit)
		{
			(new DbCompany()).StoreCreditUpdate(CompanyID, ContactId, StoreCredit);
		}
		
		public static void contact_Subscribe_Unsubscribe(int companyid, string contactids, int userid, bool IsSubscribe, DateTime TodaysDate)
		{
			(new DbCompany()).contact_Subscribe_Unsubscribe(companyid, contactids, userid, IsSubscribe, TodaysDate);
		}

		public static DataTable contactcustomfields(int CompanyID)
		{
			return (new DbCompany()).contactcustomfields(CompanyID);
		}

		public static DataTable ContactCustomFields_ScreenName_Select(long CompanyID)
		{
			return (new DbCompany()).ContactCustomFields_ScreenName_Select(CompanyID);
		}

		public static long Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.Create_StoreUser(StoreUserID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static void crm_clientType_add(long CompanyID, long ClientID, long TypeID, string ClientType)
		{
			(new DbCompany()).crm_clientType_add(CompanyID, ClientID, TypeID, ClientType);
		}

		public static void crm_common_attachment_add(int CompanyID, string SectionName, int SectionID, string FileName, string FileSize, DateTime CreateDate, DateTime ModifiedDate, int CreateUserID, int ModifyUserID, string Subject, string Title)
		{
			DbCompany dbCompany = new DbCompany();
			dbCompany.crm_common_attachment_add(CompanyID, SectionName, SectionID, FileName, FileSize, CreateDate, ModifiedDate, CreateUserID, ModifyUserID, Subject, Title);
		}

		public static void crm_common_attachment_delete(int AttachmentID, int CompanyID)
		{
			(new DbCompany()).crm_common_attachment_delete(AttachmentID, CompanyID);
		}

		public static DataTable crm_common_attachment_detail(int CompanyID, int AttachmentID)
		{
			return (new DbCompany()).crm_common_attachment_detail(CompanyID, AttachmentID);
		}

		public static void crm_common_attachment_edit(int CompanyID, int AttachmentID, string FileName, string FileSize, DateTime ModifiedDate, int ModifyUserID, string Subject, string Title)
		{
			DbCompany dbCompany = new DbCompany();
			dbCompany.crm_common_attachment_edit(CompanyID, AttachmentID, FileName, FileSize, ModifiedDate, ModifyUserID, Subject, Title);
		}

		public static void crm_common_email_delete(string pg, int sl, int Client, int CompanyID)
		{
			(new DbCompany()).crm_common_email_delete(pg, sl, Client, CompanyID);
		}

		public static DataTable crm_common_select_accessrightOfUserType(int companyid, int usertypeid)
		{
			return (new DbCompany()).crm_common_select_accessrightOfUserType(companyid, usertypeid);
		}

		public static DataTable crm_common_select_all_email_new(int CompanyID, int ClientID, string SelectAll)
		{
			return (new DbCompany()).crm_common_select_all_email_new(CompanyID, ClientID, SelectAll);
		}

		public static DataTable crm_common_select_all_email_new_filter(int CompanyID, int ClientID, string SelectAll, string WhereCondition)
		{
			return (new DbCompany()).crm_common_select_all_email_new_filter(CompanyID, ClientID, SelectAll, WhereCondition);
		}

		public static DataTable crm_common_select_attachment(int ClientID, string SectionName, int CompanyID, string SelectAll)
		{
			return (new DbCompany()).crm_common_select_attachment(ClientID, SectionName, CompanyID, SelectAll);
		}

		public static DataTable crm_select_HeaderImage_new1(int CompanyID, int UserID)
		{
			return (new DbCompany()).crm_select_HeaderImage_new1(CompanyID, UserID);
		}

		public static long Customer_code_select(int companyid)
		{
			return (new DbCompany()).Customer_code_select(companyid);
		}

		public static void Customer_COde_Update(int companyid, long LastCount)
		{
			(new DbCompany()).Customer_COde_Update(companyid, LastCount);
		}

		public static string Customer_Company_Select(int companyid, int ClientID)
		{
			return (new DbCompany()).Customer_Company_Select(companyid, ClientID);
		}

		public static DataTable Customer_Products_Select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).Customer_Products_Select(CompanyID, ClientID);
		}

		public static DataTable Customer_Products_Select_Filter(int CompanyID, int ClientID, string WhereCondition)
		{
			return (new DbCompany()).Customer_Products_Select_Filter(CompanyID, ClientID, WhereCondition);
		}

		public static void Deactivate_SpendLimitUser(int CompanyID, string IDs, string Type)
		{
			(new DbCompany()).Deactivate_SpendLimitUser(CompanyID, IDs, Type);
		}
		public static void Deactivate_StoreCredit(int CompanyID, string IDs)
		{
			(new DbCompany()).Deactivate_StoreCredit(CompanyID, IDs);
		}
		
		public static string default_address_select(int CompanyID, int ClientID)
		{
			return (new DbCompany()).default_address_select(CompanyID, ClientID);
		}

		public static void default_delivery_address_update(int CompanyID, int ClientID, int CommonID, string AddressType)
		{
			(new DbCompany()).default_delivery_address_update(CompanyID, ClientID, CommonID, AddressType);
		}

		public static DataTable Delivery_Address_Select(int CompanyID, long EstimateID)
		{
			return (new DbCompany()).Delivery_Address_Select(CompanyID, EstimateID);
		}

		public static DataTable departmentcustomfields(int CompanyID)
		{
			return (new DbCompany()).departmentcustomfields(CompanyID);
		}

		public static DataSet eprintreport_select(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.eprintreport_select(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataTable Get_AccountName(int ClientID)
		{
			return (new DbCompany()).Get_AccountName(ClientID);
		}

		public static DataTable Get_B2bAccountName(int ClientID)
		{
			return (new DbCompany()).Get_AccountName(ClientID);
		}

		public static string get_module_number(int CompanyID, string pagename, int moduleid)
		{
			return (new DbCompany()).get_module_number(CompanyID, pagename, moduleid);
		}

		public static DataSet GetDeptAddressDetails(int CompanyID, int DeptID)
		{
			return (new DbCompany()).GetDeptAddressDetails(CompanyID, DeptID);
		}

		public static DataTable getEstimateTitle_autofill(int CompanyID, string SearchParameter)
		{
			return (new DbCompany()).getEstimateTitle_autofill(CompanyID, SearchParameter);
		}

		public static DataTable GetImageNames_CopyTemplates(long PriceCatalogueID)
		{
			return (new DbCompany()).GetImageNames_CopyTemplates(PriceCatalogueID);
		}

		public static DataTable getItemtitleItemcode_autofill(int CompanyID, string SearchParameter)
		{
			return (new DbCompany()).getItemtitleItemcode_autofill(CompanyID, SearchParameter);
		}

		public static DataTable getOldPDFName_CopyTemplates(long PriceCatalogueID, long NewPriceCatalogueID, string _newpdfnameforcopied)
		{
			return (new DbCompany()).getOldPDFName_CopyTemplates(PriceCatalogueID, NewPriceCatalogueID, _newpdfnameforcopied);
		}

		public static DataTable getwarehouselocation_autofill(int CompanyID, string SearchParameter)
		{
			return (new DbCompany()).getwarehouselocation_autofill(CompanyID, SearchParameter);
		}

		public static long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.Insert_BillingShipping_Address(StoreUserID, FirstName, LastName, Address1, Address2, Address3, Address4, Address5, Phone, Fax, Country, IsDefaultBilling, IsDefaultShipping, AddressLabel, CreatedDate);
		}

		public static DataTable InvoiceReportGenrated_select()
		{
			return (new DbCompany()).InvoiceReportGenrated_select();
		}

		public static void MailChimp_Insert(int CompanyID, string MailChimpAPIKey, string MailChimpListId)
		{
			(new DbCompany()).MailChimp_Insert(CompanyID, MailChimpAPIKey, MailChimpListId);
		}

		public static DataTable main_company_address_select(int ClientID, int CompanyID)
		{
			return (new DbCompany()).main_company_address_select(ClientID, CompanyID);
		}

		public static DataTable main_company_address_select_new(int ClientID, int CompanyID)
		{
			return (new DbCompany()).main_company_address_select_new(ClientID, CompanyID);
		}

		public static string main_company_salesperson_select(int ClientID, int CompanyID)
		{
			return (new DbCompany()).main_company_salesperson_select(ClientID, CompanyID);
		}
        public static string main_company_invoicecontact_select(int ClientID, int CompanyID)
        {
            return (new DbCompany()).main_company_invoicecontact_select(ClientID, CompanyID);
        }

        public static string Measurment(int CompanyID)
		{
			return (new DbCompany()).Measurment(CompanyID);
		}

		public static DataTable PreflightProfile_Select()
		{
			return (new DbCompany()).PreflightProfile_Select();
		}

		public static int pricecatalogueTemplate_ToanotherSystem_copy(string ServerName, long PriceCatalogueID, string FromSystem, string ToSystem, long FromCompanyid, long ToCompanyid)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.pricecatalogueTemplate_ToanotherSystem_copy(ServerName, PriceCatalogueID, FromSystem, ToSystem, FromCompanyid, ToCompanyid);
		}

		public static DataTable Select_BillingShipping_Address(long StoreUserID, string type, long DefaultBillingID)
		{
			return (new DbCompany()).Select_BillingShipping_Address(StoreUserID, type, DefaultBillingID);
		}

		public static DataTable Select_Isadmin(int CompanyID, int UserID)
		{
			return (new DbCompany()).Select_Isadmin(CompanyID, UserID);
		}

		public static DataSet selectall_AddressValue_FromSetting(int CompanyID)
		{
			return (new DbCompany()).selectall_AddressValue_FromSetting(CompanyID);
		}

		public static DataTable selectall_MailchimpIntegration(int CompanyID)
		{
			return (new DbCompany()).selectall_MailchimpIntegration(CompanyID);
		}

		public static void SetDefaultAddressID(int ClientID, int SetDefault_AddressID)
		{
			(new DbCompany()).SetDefaultAddressID(ClientID, SetDefault_AddressID);
		}

		public static long settings_lastcounter_select(int CompanyID, string ModuleType)
		{
			return (new DbCompany()).settings_lastcounter_select(CompanyID, ModuleType);
		}

		public static void settings_lastcounter_update(int CompanyID, string ModuleType, long LastCounter)
		{
			(new DbCompany()).settings_lastcounter_update(CompanyID, ModuleType, LastCounter);
		}

		public static void StoreUser_AccountIsActivate(int CompanyID, int ContactID, int Isactive)
		{
			(new DbCompany()).StoreUser_AccountIsActivate(CompanyID, ContactID, Isactive);
		}

		public static DataTable StoreUser_select(long StoreUserID)
		{
			return (new DbCompany()).StoreUser_select(StoreUserID);
		}

		public static void Update_ContactID_ForB2B(long StoreUserID, long DefaultBillingID, long DefaultShippingID, int ContactID)
		{
			(new DbCompany()).Update_ContactID_ForB2B(StoreUserID, DefaultBillingID, DefaultShippingID, ContactID);
		}

		public static void Updatecontactcustomfields(int CompanyID, int LabelID, string ScreenName)
		{
			(new DbCompany()).Updatecontactcustomfields(CompanyID, LabelID, ScreenName);
		}

		public static void UpdateDepartmentcustomfields(int CompanyID, int LabelID, string ScreenName)
		{
			(new DbCompany()).UpdateDepartmentcustomfields(CompanyID, LabelID, ScreenName);
		}

		public static void UpdateImageName_CopyTemplates(long New_PriceCatalogueID, string ControlID, string _newimgname)
		{
			(new DbCompany()).UpdateImageName_CopyTemplates(New_PriceCatalogueID, ControlID, _newimgname);
		}

		public static int UserCheck_forSupportTeam(int userid)
		{
			return (new DbCompany()).UserCheck_forSupportTeam(userid);
		}

		public static void View_Delete(int CompanyID, string PageName, long ViewID, int UserID, string KeyName)
		{
			(new DbCompany()).View_Delete(CompanyID, PageName, ViewID, UserID, KeyName);
		}

		public static DataSet ViewContacts(int CompanyID, string Selectall, string para, int PageNumber, int PageSize, string SortBy, string SortDirection)
		{
			DbCompany dbCompany = new DbCompany();
			return dbCompany.ViewContacts(CompanyID, Selectall, para, PageNumber, PageSize, SortBy, SortDirection);
		}
	}
}