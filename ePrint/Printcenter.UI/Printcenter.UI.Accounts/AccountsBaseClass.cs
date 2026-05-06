using Printcenter.BusinessAccessLayer.Accounts;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.UI.Accounts
{
	public class AccountsBaseClass : BaseClass
	{
		public AccountsBaseClass()
		{
		}

		public int account_insert(int clientID, string clientName, string accountName, string accountPrefix, string createdOn, int createdBy, int defaultContactID, int defaultAddressID, char accountType, char addressType, int CompanyID, string StoreURL, string FileExtension)
		{
			AccountsItem accountsItem = new AccountsItem()
			{
				clientID = clientID,
				clientName = clientName,
				accountName = accountName,
				accountPrefix = accountPrefix,
				createdOn = createdOn,
				createdBy = createdBy,
				defaultContactID = defaultContactID,
				defaultAddressID = defaultAddressID
			};
			accountsItem.accountName = accountName;
			accountsItem.accountType = accountType;
			accountsItem.CompanyID = CompanyID;
			accountsItem.StoreURL = StoreURL;
			accountsItem.FileExtension = FileExtension;
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.account_insert(accountsItem);
		}

		public void account_modify(int clientID, string clientName, string accountName, string accountPrefix, string createdOn, int createdBy, int defaultContactID, int defaultAddressID, int accountID)
		{
			AccountsItem accountsItem = new AccountsItem()
			{
				clientID = clientID,
				clientName = clientName,
				accountName = accountName,
				accountPrefix = accountPrefix,
				createdOn = createdOn,
				createdBy = createdBy,
				defaultContactID = defaultContactID,
				defaultAddressID = defaultAddressID,
				accountID = accountID
			};
			Printcenter.BusinessAccessLayer.Accounts.Accounts.account_modify(accountsItem);
		}

		public void account_modifyPublic(string accountName, string accountPrefix, int accountID)
		{
			AccountsItem accountsItem = new AccountsItem()
			{
				accountName = accountName,
				accountPrefix = accountPrefix,
				accountID = accountID
			};
			Printcenter.BusinessAccessLayer.Accounts.Accounts.account_modifyPublic(accountsItem);
		}

		public static DataTable accounts_accountName(string accountName)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_accountName(accountName);
		}

		public static DataTable accounts_clientAddress(int CompanyID, string companytype, int clientID, char addressType, int def_addressID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_clientAddress(CompanyID, companytype, clientID, addressType, def_addressID);
		}

		public static DataTable accounts_clientID(string accountName, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_clientID(accountName, CompanyID);
		}

		public static DataTable accounts_contactName(int contactID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_contactName(contactID);
		}

		public static DataTable accounts_delete(int CompanyID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_delete(CompanyID, AccountID);
		}

		public static DataTable accounts_getAccountDetails(int accountID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getAccountDetails(accountID);
		}

		public static DataTable accounts_getAccountID(string accountName, string accountPrefix, int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getAccountID(accountName, accountPrefix, CompanyID);
		}

		public static DataTable accounts_getcontactDetails(int CompanyID, int clientID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getcontactDetails(CompanyID, clientID);
		}

		public static DataTable accounts_getDetails(int clientID, int CompanyID, int accountID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getDetails(clientID, CompanyID, accountID);
		}

		public static DataTable accounts_getDetails1(int accountID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getDetails1(accountID);
		}

		public static DataTable accounts_getUserDetails(int createdBy)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accounts_getUserDetails(createdBy);
		}

		public DataTable accountsList(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.accountsList(CompanyID);
		}

		public DataTable AccountsListforApprovalSystem(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.AccountsListforApprovalSystem(CompanyID);
		}

		public static void productCategoryReorder_Delete(int accountID, int companyID)
		{
			Printcenter.BusinessAccessLayer.Accounts.Accounts.productCategoryReorder_Delete(accountID, companyID);
		}

		public static void ProductCategoryReorder_Insert_Update(int sortorderID, int accountID, int ClientID, int productcategoryID, int sortedorderNo, int companyID)
		{
			Printcenter.BusinessAccessLayer.Accounts.Accounts.ProductCategoryReorder_Insert_Update(sortorderID, accountID, ClientID, productcategoryID, sortedorderNo, companyID);
		}

		public DataTable productsCategoryList_Select(int CompanyID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.productsCategoryList_Select(CompanyID, AccountID);
		}

		public DataTable productsCategoryList_Select_CategoryID(int CompanyID, int AccountID, int CategoryID, bool IsAllselected)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.productsCategoryList_Select_CategoryID(CompanyID, AccountID, CategoryID, IsAllselected);
		}

		public void publicAccount_bind(char accountType, int CompanyID, DropDownList ddlAccountPublic)
		{
			Printcenter.BusinessAccessLayer.Accounts.Accounts.publicAccount_bind(accountType, CompanyID, ddlAccountPublic);
		}

		public DataTable PublicAccountsListforApprovalSystem(int CompanyID)
		{
			return Printcenter.BusinessAccessLayer.Accounts.Accounts.PublicAccountsListforApprovalSystem(CompanyID);
		}
	}
}