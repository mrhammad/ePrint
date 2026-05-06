using Printcenter.BusinessAccessLayer;
using Printcenter.DataAccessLayer.Accounts;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Printcenter.BusinessAccessLayer.Accounts
{
	public class Accounts : BaseBusiness
	{
		public Accounts()
		{
		}

		public static int account_insert(AccountsItem item)
		{
			return (new DbAccounts()).account_insert(item);
		}

		public static void account_modify(AccountsItem item)
		{
			(new DbAccounts()).account_modify(item);
		}

		public static void account_modifyPublic(AccountsItem item)
		{
			(new DbAccounts()).account_modifyPublic(item);
		}

		public static DataTable accounts_accountName(string accountName)
		{
			return (new DbAccounts()).accounts_accountName(accountName);
		}

		public static DataTable accounts_clientAddress(int CompanyID, string companytype, int clientID, char addressType, int def_addressID)
		{
			return (new DbAccounts()).accounts_clientAddress(CompanyID, companytype, clientID, addressType, def_addressID);
		}

		public static DataTable accounts_clientID(string accountName, int CompanyID)
		{
			return (new DbAccounts()).accounts_clientID(accountName, CompanyID);
		}

		public static DataTable accounts_contactName(int contactID)
		{
			return (new DbAccounts()).accounts_contactName(contactID);
		}

		public static DataTable accounts_delete(int CompanyID, int AccountID)
		{
			return (new DbAccounts()).accounts_delete(CompanyID, AccountID);
		}

		public static DataTable accounts_getAccountDetails(int accountID)
		{
			return (new DbAccounts()).accounts_getAccountDetails(accountID);
		}

		public static DataTable accounts_getAccountID(string accountName, string accountPrefix, int CompanyID)
		{
			return (new DbAccounts()).accounts_getAccountID(accountName, accountPrefix, CompanyID);
		}

		public static DataTable accounts_getcontactDetails(int CompanyID, int clientID)
		{
			return (new DbAccounts()).accounts_getcontactDetails(CompanyID, clientID);
		}

		public static DataTable accounts_getDetails(int clientID, int CompanyID, int accountID)
		{
			return (new DbAccounts()).accounts_getDetails(clientID, CompanyID, accountID);
		}

		public static DataTable accounts_getDetails1(int accountID)
		{
			return (new DbAccounts()).accounts_getDetails1(accountID);
		}

		public static DataTable accounts_getUserDetails(int createdBy)
		{
			return (new DbAccounts()).accounts_getUserDetails(createdBy);
		}

		public static DataTable accountsList(int CompanyID)
		{
			return (new DbAccounts()).accountsList(CompanyID);
		}

		public static DataTable AccountsListforApprovalSystem(int CompanyID)
		{
			return (new DbAccounts()).AccountsListforApprovalSystem(CompanyID);
		}

		public static void productCategoryReorder_Delete(int accountID, int companyID)
		{
			(new DbAccounts()).productCategoryReorder_Delete(accountID, companyID);
		}

		public static void ProductCategoryReorder_Insert_Update(int sortorderID, int accountID, int ClientID, int productcategoryID, int sortedorderNo, int companyID)
		{
			(new DbAccounts()).ProductCategoryReorder_Insert_Update(sortorderID, accountID, ClientID, productcategoryID, sortedorderNo, companyID);
		}

		public static DataTable productsCategoryList_Select(int CompanyID, int AccountID)
		{
			return (new DbAccounts()).productsCategoryList_Select(CompanyID, AccountID);
		}

		public static DataTable productsCategoryList_Select_CategoryID(int CompanyID, int AccountID, int CategoryID, bool IsAllselected)
		{
			return (new DbAccounts()).productsCategoryList_Select_CategoryID(CompanyID, AccountID, CategoryID, IsAllselected);
		}

		public static void publicAccount_bind(char accountType, int CompanyID, DropDownList ddlAccountPublic)
		{
			(new DbAccounts()).publicAccount_bind(accountType, CompanyID, ddlAccountPublic);
		}

		public static DataTable publicAccount_bind(int CompanyID)
		{
			return (new DbAccounts()).publicAccount_bind(CompanyID);
		}

		public static DataTable PublicAccountsListforApprovalSystem(int CompanyID)
		{
			return (new DbAccounts()).PublicAccountsListforApprovalSystem(CompanyID);
		}
	}
}