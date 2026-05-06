using Printcenter.DataAccessLayer.Login;
using Printcenter.UI.LoginNew;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Login
{
	public class Login
	{
		public Login()
		{
		}

		public static DataTable accounts_getAccountDetails(int accountID)
		{
			return (new DbLogin()).accounts_getAccountDetails(accountID);
		}

		public static DataTable AddEditAddress_select(long AccountID)
		{
			return (new DbLogin()).AddEditAddress_select(AccountID);
		}

		public static long Address_Insert_Registration(long AccountID, string Address, string AddressLine2, string City, string State, string Country, string Telephone, string Fax, string ZipCode, string AddressLabel)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Address_Insert_Registration(AccountID, Address, AddressLine2, City, State, Country, Telephone, Fax, ZipCode, AddressLabel);
		}

		public static DataSet ApproversEmail_Select(long AccountID, long DepartmentID)
		{
			return (new DbLogin()).ApproversEmail_Select(AccountID, DepartmentID);
		}

		public static DataTable b2b_Campaign_Select(long AccountID, long CompanyID, long StoreUserID)
		{
			return (new DbLogin()).b2b_Campaign_Select(AccountID, CompanyID, StoreUserID);
		}

		public static int Campaign_Duplicate_Check(long ManageID, long AccountID, long CompanyID, string EventName)
		{
			return (new DbLogin()).Campaign_Duplicate_Check(ManageID, AccountID, CompanyID, EventName);
		}

		public static int Check_Dept_Duplicacy(int CompanyID, int ClientID, string DeptName, int DeptID)
		{
			return (new DbLogin()).Check_Dept_Duplicacy(CompanyID, ClientID, DeptName, DeptID);
		}

		public static int Check_EmailID_Duplicacy_for_Account(string EmailID, long Client_ID, long Contact_ID)
		{
			return (new DbLogin()).Check_EmailID_Duplicacy_for_Account(EmailID, Client_ID, Contact_ID);
		}

		public static int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			return (new DbLogin()).CheckEmailID_Duplicacy(StoreUserID, EmailID, AccountID);
		}

		public static DataTable costcenter_getdefaultcenter(int ClientID)
		{
			return (new DbLogin()).costcenter_getdefaultcenter(ClientID);
		}

		public static long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Create_StoreUser(StoreUserID, defaultClientID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName);
		}

		public static DataSet Delete_Address_FromTempTable_ForApproval(long StoreUserID)
		{
			return (new DbLogin()).Delete_Address_FromTempTable_ForApproval(StoreUserID);
		}

		public static long departmentInsert(long DeptID, string DeptName, int CustomerID, int ContactID, int UserID, int AddressID, string AddressType, DateTime CreatedDate, DateTime ModifiedDate, int CompanyID, long DeliveryAddressID, int DeptApproverID, int CostCenterID, string Othercostcenter, bool IsApprovalNotRequired, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6, string CustomField7, string CustomField8, string CustomField9, string CustomField10, string CustomField11, string CustomField12, string CustomField13, string CustomField14, string CustomField15, long InvoiceContactID, string OriginalFileName, string ActualFilename, bool IsPdf)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.departmentInsert(DeptID, DeptName, CustomerID, ContactID, UserID, AddressID, AddressType, CreatedDate, ModifiedDate, CompanyID, DeliveryAddressID, DeptApproverID, CostCenterID, Othercostcenter, IsApprovalNotRequired, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, InvoiceContactID, OriginalFileName, ActualFilename, IsPdf);
		}

		public static long ExistanceOfEmail(string EmailID, long AccountID)
		{
			return (new DbLogin()).ExistanceOfEmail(EmailID, AccountID);
		}

		public static long ExistanceOfPassword(long StoreUserID, string Password)
		{
			return (new DbLogin()).ExistanceOfPassword(StoreUserID, Password);
		}

		public static string FetchLanguageConversion(long AccountID)
		{
			return (new DbLogin()).FetchLanguageConversion(AccountID);
		}

		public static DataTable Get_IsApprovRegistraton_Status(long StoreUserID)
		{
			return (new DbLogin()).Get_IsApprovRegistraton_Status(StoreUserID);
		}

		public static DataTable GetCompanyIDByAccountID(long AccountID)
		{
			return (new DbLogin()).GetCompanyIDByAccountID(AccountID);
		}

		public static DataSet GetDepartmentName(long DepartmentID)
		{
			return (new DbLogin()).GetDepartmentName(DepartmentID);
		}

		public static int GetIsRightBanner(int CompanyID, long AccountID)
		{
			return (new DbLogin()).GetIsRightBanner(CompanyID, AccountID);
		}

		public static DataSet GetSiteMapData(long CategoryID, int CompanyID, long AccountID)
		{
			return (new DbLogin()).GetSiteMapData(CategoryID, CompanyID, AccountID);
		}

		public static DataSet Insert_Approved_Address_ForAdmin(long StoreUserID)
		{
			return (new DbLogin()).Insert_Approved_Address_ForAdmin(StoreUserID);
		}

		public static DataSet Insert_Edit_Address_IsActive(long StoreUserID, long ApproverUserID)
		{
			return (new DbLogin()).Insert_Edit_Address_IsActive(StoreUserID, ApproverUserID);
		}

		public static DataSet Insert_Edit_Address_RejectReason(long StoreUserID, string RejectedReason, long Approved_Or_Rejected_By)
		{
			return (new DbLogin()).Insert_Edit_Address_RejectReason(StoreUserID, RejectedReason, Approved_Or_Rejected_By);
		}

		public static DataSet Insert_Edit_Address_RejectReason_For_Approval(long StoreUserID, string RejectedReason, long ApprovedOrRejectedBy)
		{
			return (new DbLogin()).Insert_Edit_Address_RejectReason_For_Approval(StoreUserID, RejectedReason, ApprovedOrRejectedBy);
		}

		public static DataSet Insert_StoreUser_temp(int ClientID, long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long AccountID, long AddressID, string ApproverEmail, string ApprovedType, string PersonalProfileEditType)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Insert_StoreUser_temp(ClientID, StoreUserID, FirstName, LastName, EmailID, Password, AccountID, AddressID, ApproverEmail, ApprovedType, PersonalProfileEditType);
		}

		public static int IsSelfRegister_Select(long AccountID)
		{
			return (new DbLogin()).IsSelfRegister_Select(AccountID);
		}

		public static DataTable LoginTo_Store(string EmailID, string Password, long AccountID, string WebAccountType)
		{
			return (new DbLogin()).LoginTo_Store(EmailID, Password, AccountID, WebAccountType);
		}

		public static void ManageCampign_Insert_Update(long CompanyID, long UserID, long AccountID, long ManageID, string EventTitle, string Venue, string EventCode, DateTime StartDate, DateTime EndDate, string UseType, bool isarchive, string ordernumber, long DeliveryAddressId, DateTime deliveryDate)
		{
			DbLogin dbLogin = new DbLogin();
			dbLogin.ManageCampign_Insert_Update(CompanyID, UserID, AccountID, ManageID, EventTitle, Venue, EventCode, StartDate, EndDate, UseType, isarchive, ordernumber, DeliveryAddressId, deliveryDate);
		}

		public static DataTable PendCountUsersandOrders(string Email, long AccountID)
		{
			return (new DbLogin()).PendCountUsersandOrders(Email, AccountID);
		}

		public static DataTable Select_AccountDetails(long CompanyID, long AccountID)
		{
			return (new DbLogin()).Select_AccountDetails(CompanyID, AccountID);
		}

		public static DataTable Select_AccountInformation(string AccountName)
		{
			return (new DbLogin()).Select_AccountInformation(AccountName);
		}

		public static DataTable Select_CompanyID(long AccountID)
		{
			return (new DbLogin()).Select_CompanyID(AccountID);
		}

		public static DataTable Select_DepartmentID_ApproverUserID(long AccountID, long StoreUserID)
		{
			return (new DbLogin()).Select_DepartmentID_ApproverUserID(AccountID, StoreUserID);
		}

		public static DataTable Select_Departments(long AccountID)
		{
			return (new DbLogin()).Select_Departments(AccountID);
		}

		public static DataTable Select_DeptDetail_For_StoreUser(long AccountID, long StoreUserID)
		{
			return (new DbLogin()).Select_DeptDetail_For_StoreUser(AccountID, StoreUserID);
		}

		public static string Select_Phrases(string PhraseType, long AccountID)
		{
			return (new DbLogin()).Select_Phrases(PhraseType, AccountID);
		}

		public static DataTable Select_UserDetail(long StoreUserID)
		{
			return (new DbLogin()).Select_UserDetail(StoreUserID);
		}

		public static DataTable Select_UserDetail_For_Approval(long StoreUserID)
		{
			return (new DbLogin()).Select_UserDetail_For_Approval(StoreUserID);
		}

		public static DataTable SelectB2B_DefaultLandingPage(int CompanyID, long AccountID, string Type)
		{
			return (new DbLogin()).SelectB2B_DefaultLandingPage(CompanyID, AccountID, Type);
		}

		public static DataTable SelectDefaultAddress(long AccountID)
		{
			return (new DbLogin()).SelectDefaultAddress(AccountID);
		}

		public static DataTable SelectInUse_IsArchiveCampaign(long ManageID)
		{
			return (new DbLogin()).SelectInUse_IsArchiveCampaign(ManageID);
		}

		public static void settings_managecampaign_delete(long ManageID)
		{
			(new DbLogin()).settings_managecampaign_delete(ManageID);
		}

		public static long StoreUser_Register(LoginItems objLogItems, long CompanyID, long AccountID, string CompanyName, DateTime CreatedDate, bool IsActive, bool IsNewDept)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.StoreUser_Register(objLogItems, CompanyID, AccountID, CompanyName, CreatedDate, IsActive, IsNewDept);
		}

		public static long StoreUser_Register_prefil(LoginItems objLogItems, long CompanyID, long AccountID, string CompanyName, DateTime CreatedDate, bool IsActive, long AddressID, bool IsNewDept)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.StoreUser_Register_prefil(objLogItems, CompanyID, AccountID, CompanyName, CreatedDate, IsActive, AddressID, IsNewDept);
		}

		public static DataTable StoreUser_select(long StoreUserID)
		{
			return (new DbLogin()).StoreUser_select(StoreUserID);
		}

		public static DataTable StoreUser_select_by_Conditions(long ContactID, string Type, long DeptID)
		{
			return (new DbLogin()).StoreUser_select_by_Conditions(ContactID, Type, DeptID);
		}

		public static DataSet Update_Address_Detail(long AddressID, string AddressLine2, string AddressLabel, string Fax, string Telephone, string Country, string State, string City, string Address, string ZipCode, long StoreUserID, long Approved_Or_Rejected_By, bool IsDefaultShipping, bool IsDefaultBillingAddress, long ClientID, string DesignatedApproverEmail)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Update_Address_Detail(AddressID, AddressLine2, AddressLabel, Fax, Telephone, Country, State, City, Address, ZipCode, StoreUserID, Approved_Or_Rejected_By, IsDefaultShipping, IsDefaultBillingAddress, ClientID, DesignatedApproverEmail);
		}

		public static DataSet Update_Login_Detail(long StoreUserID, string FirstName, string LastName, string EmailID, string Password, long Approved_Or_Rejected_By, string DesignatedApproverEmail)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Update_Login_Detail(StoreUserID, FirstName, LastName, EmailID, Password, Approved_Or_Rejected_By, DesignatedApproverEmail);
		}

		public static DataTable UserRegistrationDetails_Rejection(long RegisterPendingUserID)
		{
			return (new DbLogin()).UserRegistrationDetails_Rejection(RegisterPendingUserID);
		}

		public static string UserTypeCheck(long StoreUserID)
		{
			return (new DbLogin()).UserTypeCheck(StoreUserID);
		}

		public static long Ws_UploadCSVFile(string FileName, int ProductID, int TemplateID, int Uploadedby, int AccountID, int IsImport, string ErrorMsg, int IsEmailSend, string OriginalCSvFileName, int CompanyID, string ZipImageFileName)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Ws_UploadCSVFile(FileName, ProductID, TemplateID, Uploadedby, AccountID, IsImport, ErrorMsg, IsEmailSend, OriginalCSvFileName, CompanyID, ZipImageFileName);
		}
	}
}