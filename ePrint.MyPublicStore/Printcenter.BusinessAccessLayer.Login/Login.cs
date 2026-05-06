using Printcenter.DataAccessLayer.Login;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.Login
{
	public class Login
	{
		public Login()
		{
		}

		public static int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			return (new DbLogin()).CheckEmailID_Duplicacy(StoreUserID, EmailID, AccountID);
		}

		public static long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Create_StoreUser(StoreUserID, defaultClientID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static long Create_StoreUser_AgentCode(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			DbLogin dbLogin = new DbLogin();
			return dbLogin.Create_StoreUser_AgentCode(StoreUserID, defaultClientID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static string Fetch_LanguageConversionFileName(long AccountID)
		{
			return (new DbLogin()).Fetch_LanguageConversionFileName(AccountID);
		}

		public static int GetIsRightBanner(int CompanyID, long AccountID)
		{
			return (new DbLogin()).GetIsRightBanner(CompanyID, AccountID);
		}

		public static DataSet GetSiteMapData(long CategoryID, int CompanyID, long AccountID)
		{
			return (new DbLogin()).GetSiteMapData(CategoryID, CompanyID, AccountID);
		}

		public static DataTable LoginTo_Store(string EmailID, string Password, long AccountID, string WebAccountType)
		{
			return (new DbLogin()).LoginTo_Store(EmailID, Password, AccountID, WebAccountType);
		}

		public static DataTable Public_User_ClientIDbyAgentCode(long CompanyID, long AccountID, string AgentCode)
		{
			return (new DbLogin()).Public_User_ClientIDbyAgentCode(CompanyID, AccountID, AgentCode);
		}

		public static DataTable Public_User_SecretCodebyAccountID(long CompanyID, long AccountID, string SecretCode)
		{
			return (new DbLogin()).Public_User_SecretCodebyAccountID(CompanyID, AccountID, SecretCode);
		}

		public static DataTable Select_AccountDetails(long CompanyID, long AccountID)
		{
			return (new DbLogin()).Select_AccountDetails(CompanyID, AccountID);
		}

		public static DataTable Select_PublicUserAccountDetails(long CompanyID, long AccountID)
		{
			return (new DbLogin()).Select_PublicUserAccountDetails(CompanyID, AccountID);
		}

		public static DataTable SelectB2B_DefaultLandingPage(int CompanyID, long AccountID, string Type)
		{
			return (new DbLogin()).SelectB2B_DefaultLandingPage(CompanyID, AccountID, Type);
		}

		public static DataTable StoreUser_select(long StoreUserID)
		{
			return (new DbLogin()).StoreUser_select(StoreUserID);
		}
	}
}