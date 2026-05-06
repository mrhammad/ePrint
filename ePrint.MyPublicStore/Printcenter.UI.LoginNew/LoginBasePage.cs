using Printcenter.BusinessAccessLayer.Login;
using System;
using System.Data;

namespace Printcenter.UI.LoginNew
{
	public class LoginBasePage
	{
		public LoginBasePage()
		{
		}

		public static int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
		{
			return Login.CheckEmailID_Duplicacy(StoreUserID, EmailID, AccountID);
		}

		public static long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			return Login.Create_StoreUser(StoreUserID, defaultClientID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static long Create_StoreUser_AgentCode(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
		{
			return Login.Create_StoreUser_AgentCode(StoreUserID, defaultClientID, FirstName, LastName, EmailID, Password, CompanyID, AccountID, IsPsw, CompanyName, subscribe_newsletter);
		}

		public static string Fetch_LanguageConversionFileName(long AccountID)
		{
			return Login.Fetch_LanguageConversionFileName(AccountID);
		}

		public static int GetIsRightBanner(int CompanyID, long AccountID)
		{
			return Login.GetIsRightBanner(CompanyID, AccountID);
		}

		public static DataSet GetSiteMapData(long CategoryID, int CompanyID, long AccountID)
		{
			return Login.GetSiteMapData(CategoryID, CompanyID, AccountID);
		}

		public static DataTable LoginTo_Store(string EmailID, string Password, long AccountID, string WebAccountType)
		{
			return Login.LoginTo_Store(EmailID, Password, AccountID, WebAccountType);
		}

		public static DataTable Public_User_ClientIDbyAgentCode(long CompanyID, long AccountID, string AgentCode)
		{
			return Login.Public_User_ClientIDbyAgentCode(CompanyID, AccountID, AgentCode);
		}

		public static DataTable Public_User_SecretCodebyAccountID(long CompanyID, long AccountID, string SecretCode)
		{
			return Login.Public_User_SecretCodebyAccountID(CompanyID, AccountID, SecretCode);
		}

		public static DataTable Select_AccountDetails(long CompanyID, long AccountID)
		{
			return Login.Select_AccountDetails(CompanyID, AccountID);
		}

		public static DataTable Select_PublicUserAccountDetails(long CompanyID, long AccountID)
		{
			return Login.Select_PublicUserAccountDetails(CompanyID, AccountID);
		}

		public static DataTable SelectB2B_DefaultLandingPage(int CompanyID, long AccountID, string Type)
		{
			return Login.SelectB2B_DefaultLandingPage(CompanyID, AccountID, Type);
		}

		public static DataTable StoreUser_select(long StoreUserID)
		{
			return Login.StoreUser_select(StoreUserID);
		}
	}
}