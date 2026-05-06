using nmsCommon;
using Printcenter.BusinessAccessLayer.Company;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.Company
{
	public class CompanyBasePage : BasePage
	{
		public CompanyBasePage()
		{
		}

		public static DataTable Account_Number_Generate(long CompanyID, string ModuleType)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Account_Number_Generate(CompanyID, ModuleType);
		}

		public static DataTable ActiveHistoryEstimate(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryEstimate(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryEstimate_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryEstimate_Filter(ClientID, SalesPersonCondition, WhereConditionEstimate);
		}

		public static DataTable ActiveHistoryEstimate_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryEstimate_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryEstimate_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionEstimate)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryEstimate_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionEstimate);
		}

		public static DataTable ActiveHistoryeStore(int CompanyID, int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryeStore(CompanyID, ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryeStore_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryeStore_Filter(CompanyID, ClientID, SalesPersonCondition, WhereConditionEstore);
		}

		public static DataTable ActiveHistoryeStore_SplitItems_Filter(int CompanyID, int ClientID, string SalesPersonCondition, string WhereConditionEstore)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryeStore_SplitItems_Filter(CompanyID, ClientID, SalesPersonCondition, WhereConditionEstore);
		}

		public static DataTable ActiveHistoryInvoice(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryInvoice(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryInvoice_Filter(int ClientID, string SalesPersonCondition, string WhereConditionInvoice)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryInvoice_Filter(ClientID, SalesPersonCondition, WhereConditionInvoice);
		}

		public static DataTable ActiveHistoryInvoice_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryInvoice_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryInvoice_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryInvoice_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public static DataTable ActiveHistoryJobs(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryJobs(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryJobs_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryJobs_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public static DataTable ActiveHistoryJobs_SplitItems(int ClientID, string SalesPersonCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryJobs_SplitItems(ClientID, SalesPersonCondition);
		}

		public static DataTable ActiveHistoryJobs_SplitItems_Filter(int ClientID, string SalesPersonCondition, string WhereConditionJob)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ActiveHistoryJobs_SplitItems_Filter(ClientID, SalesPersonCondition, WhereConditionJob);
		}

		public void address_delete(int companyid, int addressid, int userid)
		{
			Printcenter.BusinessAccessLayer.Company.Company.address_delete(companyid, addressid, userid);
		}

		public int address_insert(int CompanyID, int UserID, int ClientID, string Address, string City, string State, string Country, string Telephone, string Fax, string ZipCode, string Ref, string Email, bool IsDefaultEmail, bool IsDefaultDeliveryAddress, bool IsDefaultBillingAddress, string CreatedDate, bool IsDefaultPostBoxAddress, string AddressLabel, string AddressLine2, string URL, string isHideAddress)
		{
			CompanyItem companyItem = new CompanyItem()
			{
				CompanyID = CompanyID,
				UserID = UserID,
				ClientID = ClientID,
				Address = Address,
				City = City,
				State = State,
				Country = Country,
				Telephone = Telephone,
				Fax = Fax,
				ZipCode = ZipCode,
				Ref = Ref,
				Email = Email,
				IsDefaultEmail = IsDefaultEmail,
				IsDefaultDeliveryAddress = IsDefaultDeliveryAddress,
				IsDefaultBillingAddress = IsDefaultBillingAddress,
				CreatedDate = CreatedDate,
				IsDefaultPostBoxAddress = IsDefaultPostBoxAddress,
				AddressLabel = AddressLabel,
				AddressLine2 = AddressLine2,
				URL = URL,
				isHideAddress = isHideAddress
			};
			return Printcenter.BusinessAccessLayer.Company.Company.address_insert(companyItem);
		}

		public void address_select(int companyid, int userid, int addresssid, TextBox txtaddress, TextBox txtcity, TextBox txtstate, DropDownList ddlcountry, TextBox txttelephone, TextBox txtfax, TextBox txtzipcode, TextBox txtref, TextBox txtemail, CheckBox chkemail, CheckBox chkdelivery, CheckBox chkbilling, CheckBox chkpostbox, TextBox txt_AddressLabel, TextBox txt_addressline5, TextBox txtURL, CheckBox isHideAddress)
		{
			Printcenter.BusinessAccessLayer.Company.Company.address_select(companyid, userid, addresssid, txtaddress, txtcity, txtstate, ddlcountry, txttelephone, txtfax, txtzipcode, txtref, txtemail, chkemail, chkdelivery, chkbilling, chkpostbox, txt_AddressLabel, txt_addressline5, txtURL, isHideAddress);
		}

		public static DataTable address_select_For_Edit(int CompanyID, int AddressID, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.address_select_For_Edit(CompanyID, AddressID, UserID);
		}

		public void address_update(int CompanyID, int UserID, int ClientID, int AddressID, string Address, string City, string State, string Country, string Telephone, string Fax, string ZipCode, string Ref, string Email, bool IsDefaultEmail, bool IsDefaultDeliveryAddress, bool IsDefaultBillingAddress, bool IsDefaultPostBoxAddress, string AddressLabel, string AddressLine2, string URL, string isHideAddress)
		{
			CompanyItem companyItem = new CompanyItem()
			{
				CompanyID = CompanyID,
				UserID = UserID,
				ClientID = ClientID,
				AddressID = AddressID,
				Address = Address,
				City = City,
				State = State,
				Country = Country,
				Telephone = Telephone,
				Fax = Fax,
				ZipCode = ZipCode,
				Ref = Ref,
				Email = Email,
				IsDefaultEmail = IsDefaultEmail,
				IsDefaultDeliveryAddress = IsDefaultDeliveryAddress,
				IsDefaultBillingAddress = IsDefaultBillingAddress,
				IsDefaultPostBoxAddress = IsDefaultPostBoxAddress,
				AddressLabel = AddressLabel,
				AddressLine2 = AddressLine2,
				URL = URL,
				isHideAddress = isHideAddress
			};
			Printcenter.BusinessAccessLayer.Company.Company.address_update(companyItem);
		}

		public static int Campaign_customview_count(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Campaign_customview_count(CompanyID);
		}

		public static int Check_Dept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Check_Dept_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
		}
        public static int Check_Cost_Centre_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
        {
            return Printcenter.BusinessAccessLayer.Company.Company.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
        }

        public static int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Check_EmailID_Duplicacy_for_Account(EmailID, Client_ID, Contact_ID);
		}

		public static int Check_EmailID_Duplicate_for_Account(string EmailID, long Client_ID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Check_EmailID_Duplicate_for_Account(EmailID, Client_ID);
		}

		public static int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.CheckEmailID_Duplicacy(StoreUserID, EmailID, AccountID);
		}

		public static DataTable client_contact_selectnew(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.client_contact_selectnew(CompanyID);
		}

		public static DataTable client_contacts_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.client_contacts_select(CompanyID, ClientID);
		}

		public static DataSet client_contacts_select_for_filter(int CompanyID, int ClientID, int pageno, int pagesize, string WhereConditionContact)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.client_contacts_select_for_filter(CompanyID, ClientID, pageno, pagesize, WhereConditionContact);
		}

		public static DataTable client_contacts_select_Praveen(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.client_contacts_select_Praveen(CompanyID, ClientID);
		}

		public void client_defaultcontact(int CompanyID, int ClientID, int ContactID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.client_defaultcontact(CompanyID, ClientID, ContactID);
		}

		public static DataTable Client_GetLast_Account(int CompanyID, string Companytype)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Client_GetLast_Account(CompanyID, Companytype);
		}

		public static void Client_ReferencedBy_Insert(int CompanyID, int retClientID, string ReferencedBy, int ReferencedID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Client_ReferencedBy_Insert(CompanyID, retClientID, ReferencedBy, ReferencedID);
		}

		public DataTable Clientaddresslabels(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Clientaddresslabels(CompanyID);
		}

		public static DataTable ClientReferencedByName_Select(string Name, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ClientReferencedByName_Select(Name, CompanyID);
		}

		public static DataTable company_activityhistory_select(int CompanyID, int CustomerID, string SearchText, string ModuleType, string DateType, string FromDate, string ToDate)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_activityhistory_select(CompanyID, CustomerID, SearchText, ModuleType, DateType, FromDate, ToDate);
		}

		public DataTable company_address_select(int ClientID, int CompanyID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_address_select(ClientID, CompanyID, SelectAll);
		}

		public DataTable company_address_select_one(int CompanyID, int AddressID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_address_select_one(CompanyID, AddressID, ClientID);
		}

		public DataTable company_autocomplete(int CompanyID, string CompanyType, string ClientName)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_autocomplete(CompanyID, CompanyType, ClientName);
		}

		public void company_carrier_supplier_select(int companyid, DropDownList ddlsupplier)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_carrier_supplier_select(companyid, ddlsupplier);
		}

		public static DataTable company_client_address_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_address_select(CompanyID, ClientID);
		}

		public static DataTable company_client_alladdress_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_alladdress_select(CompanyID, ClientID);
		}

		public static DataTable company_client_alladdress_select_clientname(int CompanyID, int ClientID, string ClientAddress)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_alladdress_select_clientname(CompanyID, ClientID, ClientAddress);
		}

		public static DataTable company_client_alladdress_select_split(int CompanyID, int ClientID, string FreeText)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_alladdress_select_split(CompanyID, ClientID, FreeText);
		}

		public static void company_client_defaultaddresstype_update(int CompanyID, int ClientID, string IsDelOrInv, string DefaultType, int DefaultID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_client_defaultaddresstype_update(CompanyID, ClientID, IsDelOrInv, DefaultType, DefaultID);
		}

		public static DataTable company_client_defaultdeliverytype_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_defaultdeliverytype_select(CompanyID, ClientID);
		}

		public static void company_client_delete(int CompanyID, int ClientID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_client_delete(CompanyID, ClientID);
		}

		public static void company_client_email_delete(int UserID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_client_email_delete(UserID);
		}

		public static void company_client_email_insert(int UserID, string FileName)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_client_email_insert(UserID, FileName);
		}

		public static DataTable company_client_email_select(int UserID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_email_select(UserID);
		}

		public static string company_client_fax_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_fax_select(CompanyID, ClientID);
		}

		public static DataTable company_client_For_subsection(int CompanyID, int ClientID, string CompanyType)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_For_subsection(CompanyID, ClientID, CompanyType);
		}

		public static int company_client_insert(int CompanyID, int ClientID, string Query, bool IsDefaultDeliveryAddress, bool IsDefaultInvoiceAddress)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_insert(CompanyID, ClientID, Query, IsDefaultDeliveryAddress, IsDefaultInvoiceAddress);
		}

		public static DataTable company_client_select(int CompanyID, int ClientID, string CompanyType)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_client_select(CompanyID, ClientID, CompanyType);
		}
        public static DataTable company_InvoiceContact_select(int CompanyID, int EstId,string type)
        {
            return Printcenter.BusinessAccessLayer.Company.Company.company_InvoiceContact_select(CompanyID, EstId,type);
        }
        

        public static string company_contact_address_select(int CompanyID, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_address_select(CompanyID, ContactID);
		}

		public static bool HasInvoiceContact(int CompanyID, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.HasInvoiceContact(CompanyID, ContactID);
		}

		public static DataTable company_contact_address_select_new(int CompanyID, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_address_select_new(CompanyID, ContactID);
		}

		public static DataTable company_contact_address_selectall(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_address_selectall(CompanyID, ClientID);
		}

		public static DataTable company_contact_address_selectall_new(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_address_selectall_new(CompanyID, ClientID);
		}

		public static DataTable company_contact_deladdr_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_deladdr_select(CompanyID, ClientID);
		}

		public static void company_contact_delete(int CompanyID, int ClientID, int ContactID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_contact_delete(CompanyID, ClientID, ContactID);
		}

		public static int company_contact_insert(int CompanyID, int ClientID, int ContactID, string Query, bool DefaultContact, bool DefaultDeliveryAddress, bool DefaultInvoiceAddress)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_insert(CompanyID, ClientID, ContactID, Query, DefaultContact, DefaultDeliveryAddress, DefaultInvoiceAddress);
		}

		public static DataTable company_contact_select(int CompanyID, int ContactID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contact_select(CompanyID, ContactID, ClientID);
		}
        public static DataTable PC_company_contactByContactId_select(int ContactID)
        {
            return Printcenter.BusinessAccessLayer.Company.Company.PC_company_contactByContactId_select(ContactID);
        }

		public static DataTable PC_company_StoreCredit_select(int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.PC_company_StoreCredit_select(ContactID);
		}
		
		public static DataTable company_contacts_byid_select(int CompanyID, int ClientID, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contacts_byid_select(CompanyID, ClientID, ContactID);
		}

		public DataTable company_contacts_select(int CompanyID, int ClientID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_contacts_select(CompanyID, ClientID, SelectAll);
		}

		public static void company_convert_to_customer(int ClienrID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_convert_to_customer(ClienrID);
		}

		public void company_country_select(DropDownList ddlcountry)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_country_select(ddlcountry);
		}

		public DataTable company_customer_autocomplete(int CompanyID, string ClientName, string isDisplaySupplier)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_customer_autocomplete(CompanyID, ClientName, isDisplaySupplier);
		}

		public void company_customer_bind(int companyid, DropDownList ddlcustomer)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_customer_bind(companyid, ddlcustomer);
		}

		public DataTable company_customer_select(int companyid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_customer_select(companyid);
		}
		public DataTable company_customer_select_by_clientID(int CompanyID, long ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_customer_select_by_clientID(CompanyID, ClientID);
		}
		public static string company_customizedvalue_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_customizedvalue_select(CompanyID, ClientID);
		}

		public DataTable company_customizefield_select(string pg, int CompanyID, int UserID, int CustomizeID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_customizefield_select(pg, CompanyID, UserID, CustomizeID);
		}

		public static int Company_InsertUpdate(int CompanyID, int ClientID, string CompanyType, string ClientName, string ClientAlias, string Type, string AccountStatus, string AccountNumber, string BusinessEmail, string WebSite, string CreditLimit, string CreditRef, int Tax1, int Tax2, string TaxRegNo, string PaymentTerms, string CompanyNumber, string ProfitMargin, DateTime AcOpened, string BankCode, string BankAccountNumber, string AccountName, int SalesPerson, string TaxNumber, string Balance, string Description, DateTime ModifiedDate, int ModifyUserId, int ReferencedID, int iscarrier, bool RoyalityFree, string ClientTypeID, string ClientType,bool TaxPrecedence)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Company_InsertUpdate(CompanyID, ClientID, CompanyType, ClientName, ClientAlias, Type, AccountStatus, AccountNumber, BusinessEmail, WebSite, CreditLimit, CreditRef, Tax1, Tax2, TaxRegNo, PaymentTerms, CompanyNumber, ProfitMargin, AcOpened, BankCode, BankAccountNumber, AccountName, SalesPerson, TaxNumber, Balance, Description, ModifiedDate, ModifyUserId, ReferencedID, iscarrier, RoyalityFree, ClientTypeID, ClientType, TaxPrecedence);
		}

		public static DataTable company_logo_select(int CompanyID, string LogoType)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_logo_select(CompanyID, LogoType);
		}

		public static void company_ownership_customer_bind(int companyid, string companytype, DropDownList ddlAccount)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_ownership_customer_bind(companyid, companytype, ddlAccount);
		}

		public DataTable company_prospect_select(int companyid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_prospect_select(companyid);
		}

		public void company_prospect_to_customer(int CompanyID, int Clientid)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_prospect_to_customer(CompanyID, Clientid);
		}

		public DataSet company_select(int companyid, string companytype)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_select(companyid, companytype);
		}

		public DataTable company_select_By_ID(int companyid, int clientid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_select_By_ID(companyid, clientid);
		}

		public void company_supplier_select(int companyid, DropDownList ddlsupplier)
		{
			Printcenter.BusinessAccessLayer.Company.Company.company_supplier_select(companyid, ddlsupplier);
		}

		public DataTable company_supplierddl_select(int companyid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.company_supplierddl_select(companyid);
		}

		public static void CompanyAddress_Update(long CompanyID, string Type, long ClientID, long ContactID, long InvoiceAddressID, int IsDefaultDelivery, int IsDefaultInvoice, long DeliveryAddressID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.CompanyAddress_Update(CompanyID, Type, ClientID, ContactID, InvoiceAddressID, IsDefaultDelivery, IsDefaultInvoice, DeliveryAddressID);
		}

		public static long CompanyDefaultAddress_InsertUpdate(long AddressID, long ClientID, string Address, string City, string State, string ZipCode, string Country, string Telephone, string Fax, string URL, int CreatedUserID, string CreatedDate, string AddressLabel, string AddressLine2, string Email, string IsHideAddress)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.CompanyDefaultAddress_InsertUpdate(AddressID, ClientID, Address, City, State, ZipCode, Country, Telephone, Fax, URL, CreatedUserID, CreatedDate, AddressLabel, AddressLine2, Email, IsHideAddress);
		}

		public static DataTable contact_default_info(int CompanyID, int ContactID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.contact_default_info(CompanyID, ContactID);
		}

		public void contact_delete(int companyid, string contactids, int userid)
		{
			Printcenter.BusinessAccessLayer.Company.Company.contact_delete(companyid, contactids, userid);
		}

		public static int Contact_InsertUpdate(int CompanyID, int ContactID, int ClientID, string Salutation, string FirstName, string MiddleName, string LastName, string ContactAlias, string CompanyName, string JobTitle, string JobTitle2, string HomeTelephone, string Mobile, string Email, int ReportToUserID, int CreateUserID, long DepartmentID, string PersonalFax, int ContactAddressID, bool MainApprover, int ChkSubscribed, int IsReceiveMailOut, string AlternateNumbers, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, string ActualFilename, string OriginalFileName, bool IsPdf, DateTime TodaysDate)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Contact_InsertUpdate(CompanyID, ContactID, ClientID, Salutation, FirstName, MiddleName, LastName, ContactAlias, CompanyName, JobTitle, JobTitle2, HomeTelephone, Mobile, Email, ReportToUserID, CreateUserID, DepartmentID, PersonalFax, ContactAddressID, MainApprover, ChkSubscribed, IsReceiveMailOut, AlternateNumbers, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, ActualFilename, OriginalFileName, IsPdf, TodaysDate);
		}

		public void Contact_or_Dept_SpendLimitUpdate(int CompanyID, long ContactId, string Duration, decimal Amount, string Type, Boolean EnableRollOver, string RollOverLimit, DateTime RollOverStart)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Contact_or_Dept_SpendLimitUpdate(CompanyID, ContactId, Duration, Amount, Type, EnableRollOver, RollOverLimit, RollOverStart);
		}


		public  void StoreCreditUpdate(int CompanyID, long ContactId, Double StoreCredit)
		{
			Printcenter.BusinessAccessLayer.Company.Company.StoreCreditUpdate(CompanyID, ContactId, StoreCredit);
		}
		public void contact_Subscribe_Unsubscribe(int companyid, string contactids, int userid, bool IsSubscribe, DateTime TodaysDate)
		{
			Printcenter.BusinessAccessLayer.Company.Company.contact_Subscribe_Unsubscribe(companyid, contactids, userid, IsSubscribe, TodaysDate);
		}

		public DataTable contactcustomfields(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.contactcustomfields(CompanyID);
		}

		public static DataTable ContactCustomFields_ScreenName_Select(long CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ContactCustomFields_ScreenName_Select(CompanyID);
		}

		public static long Create_StoreUser(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Create_StoreUser(StoreUserID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static void crm_clientType_add(long CompanyID, long ClientID, long TypeID, string ClientType)
		{
			Printcenter.BusinessAccessLayer.Company.Company.crm_clientType_add(CompanyID, ClientID, TypeID, ClientType);
		}

		public static void crm_common_attachment_add(int CompanyID, string SectionName, int SectionID, string FileName, string FileSize, DateTime CreateDate, DateTime ModifiedDate, int CreateUserID, int ModifyUserID, string Subject, string Title)
		{
			Printcenter.BusinessAccessLayer.Company.Company.crm_common_attachment_add(CompanyID, SectionName, SectionID, FileName, FileSize, CreateDate, ModifiedDate, CreateUserID, ModifyUserID, Subject, Title);
		}

		public void crm_common_attachment_delete(int AttachmentID, int CompanyID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.crm_common_attachment_delete(AttachmentID, CompanyID);
		}

		public static DataTable crm_common_attachment_detail(int CompanyID, int AttachmentID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_common_attachment_detail(CompanyID, AttachmentID);
		}

		public static void crm_common_attachment_edit(int CompanyID, int AttachmentID, string FileName, string FileSize, DateTime ModifiedDate, int ModifyUserID, string Subject, string Title)
		{
			Printcenter.BusinessAccessLayer.Company.Company.crm_common_attachment_edit(CompanyID, AttachmentID, FileName, FileSize, ModifiedDate, ModifyUserID, Subject, Title);
		}

		public void crm_common_email_delete(string pg, int sl, int Client, int CompanyID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.crm_common_email_delete(pg, sl, Client, CompanyID);
		}

		public static DataTable crm_common_select_accessrightOfUserType(int companyid, int usertypeid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_common_select_accessrightOfUserType(companyid, usertypeid);
		}

		public static DataTable crm_common_select_all_email_new(int CompanyID, int ClientID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_common_select_all_email_new(CompanyID, ClientID, SelectAll);
		}

		public static DataTable crm_common_select_all_email_new_filter(int CompanyID, int ClientID, string SelectAll, string WhereCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_common_select_all_email_new_filter(CompanyID, ClientID, SelectAll, WhereCondition);
		}

		public static DataTable crm_common_select_attachment(int ClientID, string SectionName, int CompanyID, string SelectAll)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_common_select_attachment(ClientID, SectionName, CompanyID, SelectAll);
		}

		public static DataTable crm_select_HeaderImage_new1(int CompanyID, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.crm_select_HeaderImage_new1(CompanyID, UserID);
		}

		public long Customer_code_select(int companyid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Customer_code_select(companyid);
		}

		public void Customer_COde_Update(int companyid, long LastCount)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Customer_COde_Update(companyid, LastCount);
		}

		public string Customer_Company_Select(int companyid, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Customer_Company_Select(companyid, ClientID);
		}

		public static DataTable Customer_Products_Select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Customer_Products_Select(CompanyID, ClientID);
		}

		public static DataTable Customer_Products_Select_Filter(int CompanyID, int ClientID, string WhereCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Customer_Products_Select_Filter(CompanyID, ClientID, WhereCondition);
		}

		public void Deactivate_SpendLimitUser(int CompanyID, string IDs, string Type)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Deactivate_SpendLimitUser(CompanyID, IDs, Type);
		}

		public void Deactivate_StoreCredit(int CompanyID, string IDs)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Deactivate_StoreCredit(CompanyID, IDs);
		}
		
		public string default_address_select(int CompanyID, int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.default_address_select(CompanyID, ClientID);
		}

		public static void default_delivery_address_update(int CompanyID, int ClientID, int CommonID, string AddressType)
		{
			Printcenter.BusinessAccessLayer.Company.Company.default_delivery_address_update(CompanyID, ClientID, CommonID, AddressType);
		}

		public static DataTable Delivery_Address_Select(int CompanyID, long EstimateID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Delivery_Address_Select(CompanyID, EstimateID);
		}

		public DataTable departmentcustomfields(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.departmentcustomfields(CompanyID);
		}

		public static DataSet eprintreport_select(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.eprintreport_select(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
		}

		public static DataTable Get_AccountName(int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Get_AccountName(ClientID);
		}

		public static DataTable Get_B2bAccountName(int ClientID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Get_AccountName(ClientID);
		}

		public static string get_module_number(int CompanyID, string pagename, int moduleid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.get_module_number(CompanyID, pagename, moduleid);
		}

		public static DataSet GetDeptAddressDetails(int CompanyID, int DeptID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.GetDeptAddressDetails(CompanyID, DeptID);
		}

		public static DataTable getEstimateTitle_autofill(int CompanyID, string SearchParameter)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.getEstimateTitle_autofill(CompanyID, SearchParameter);
		}

		public static DataTable GetImageNames_CopyTemplates(long PriceCatalogueID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.GetImageNames_CopyTemplates(PriceCatalogueID);
		}

		public static DataTable getItemtitleItemcode_autofill(int CompanyID, string SearchParameter)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.getItemtitleItemcode_autofill(CompanyID, SearchParameter);
		}

		public static DataTable getOldPDFName_CopyTemplates(long PriceCatalogueID, long NewPriceCatalogueID, string _newpdfnameforcopied)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.getOldPDFName_CopyTemplates(PriceCatalogueID, NewPriceCatalogueID, _newpdfnameforcopied);
		}

		public static DataTable getwarehouselocation_autofill(int CompanyID, string SearchParameter)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.getwarehouselocation_autofill(CompanyID, SearchParameter);
		}

		public static long Insert_BillingShipping_Address(long StoreUserID, string FirstName, string LastName, string Address1, string Address2, string Address3, string Address4, string Address5, string Phone, string Fax, string Country, int IsDefaultBilling, int IsDefaultShipping, string AddressLabel, DateTime CreatedDate)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Insert_BillingShipping_Address(StoreUserID, FirstName, LastName, Address1, Address2, Address3, Address4, Address5, Phone, Fax, Country, IsDefaultBilling, IsDefaultShipping, AddressLabel, CreatedDate);
		}

		public static DataTable InvoiceReportGenrated_select()
		{
			return Printcenter.BusinessAccessLayer.Company.Company.InvoiceReportGenrated_select();
		}

		public static void MailChimp_Insert(int CompanyID, string MailChimpAPIKey, string MailChimpListId)
		{
			Printcenter.BusinessAccessLayer.Company.Company.MailChimp_Insert(CompanyID, MailChimpAPIKey, MailChimpListId);
		}

		public DataTable main_company_address_select(int ClientID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.main_company_address_select(ClientID, CompanyID);
		}

		public DataTable main_company_address_select_new(int ClientID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.main_company_address_select_new(ClientID, CompanyID);
		}

		public string main_company_salesperson_select(int ClientID, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.main_company_salesperson_select(ClientID, CompanyID);
		}
        public string main_company_InvocieContact_select(int ClientID, int CompanyID)
        {
            return Printcenter.BusinessAccessLayer.Company.Company.main_company_invoicecontact_select(ClientID, CompanyID);
        }

        public static string Measurment(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Measurment(CompanyID);
		}

		public static DataTable PreflightProfile_Select()
		{
			return Printcenter.BusinessAccessLayer.Company.Company.PreflightProfile_Select();
		}

		public static int pricecatalogueTemplate_ToanotherSystem_copy(string ServerName, long PriceCatalogueID, string FromSystem, string ToSystem, long FromCompanyid, long ToCompanyid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.pricecatalogueTemplate_ToanotherSystem_copy(ServerName, PriceCatalogueID, FromSystem, ToSystem, FromCompanyid, ToCompanyid);
		}

		public static DataTable Select_BillingShipping_Address(long StoreUserID, string type, long DefaultBillingID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Select_BillingShipping_Address(StoreUserID, type, DefaultBillingID);
		}

		public static DataTable Select_Isadmin(int CompanyID, int UserID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.Select_Isadmin(CompanyID, UserID);
		}

		public static DataSet selectall_AddressValue_FromSetting(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.selectall_AddressValue_FromSetting(CompanyID);
		}

		public DataTable selectall_MailchimpIntegration(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.selectall_MailchimpIntegration(CompanyID);
		}

		public static void SetDefaultAddressID(int ClientID, int SetDefault_AddressID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.SetDefaultAddressID(ClientID, SetDefault_AddressID);
		}

		public long settings_lastcounter_select(int CompanyID, string ModuleType)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.settings_lastcounter_select(CompanyID, ModuleType);
		}

		public void settings_lastcounter_update(int CompanyID, string ModuleType, long LastCounter)
		{
			Printcenter.BusinessAccessLayer.Company.Company.settings_lastcounter_update(CompanyID, ModuleType, LastCounter);
		}

		public void StoreUser_AccountIsActivate(int CompanyID, int ContactID, int Isactive)
		{
			Printcenter.BusinessAccessLayer.Company.Company.StoreUser_AccountIsActivate(CompanyID, ContactID, Isactive);
		}

		public static DataTable StoreUser_select(long StoreUserID)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.StoreUser_select(StoreUserID);
		}

		public static void Update_ContactID_ForB2B(long StoreUserID, long DefaultBillingID, long DefaultShippingID, int ContactID)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Update_ContactID_ForB2B(StoreUserID, DefaultBillingID, DefaultShippingID, ContactID);
		}

		public void Updatecontactcustomfields(int CompanyID, int LabelID, string ScreenName)
		{
			Printcenter.BusinessAccessLayer.Company.Company.Updatecontactcustomfields(CompanyID, LabelID, ScreenName);
		}

		public void UpdateDepartmentcustomfields(int CompanyID, int LabelID, string ScreenName)
		{
			Printcenter.BusinessAccessLayer.Company.Company.UpdateDepartmentcustomfields(CompanyID, LabelID, ScreenName);
		}

		public static void UpdateImageName_CopyTemplates(long New_PriceCatalogueID, string ControlID, string _newimgname)
		{
			Printcenter.BusinessAccessLayer.Company.Company.UpdateImageName_CopyTemplates(New_PriceCatalogueID, ControlID, _newimgname);
		}

		public static int UserCheck_forSupportTeam(int userid)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.UserCheck_forSupportTeam(userid);
		}

		public static void View_Delete(int CompanyID, string PageName, long ViewID, int UserID, string KeyName)
		{
			Printcenter.BusinessAccessLayer.Company.Company.View_Delete(CompanyID, PageName, ViewID, UserID, KeyName);
		}

		public static DataSet ViewContacts(int CompanyID, string Selectall, string para, int PageNumber, int PageSize, string SortBy, string SortDirection)
		{
			return Printcenter.BusinessAccessLayer.Company.Company.ViewContacts(CompanyID, Selectall, para, PageNumber, PageSize, SortBy, SortDirection);
		}
	}
}