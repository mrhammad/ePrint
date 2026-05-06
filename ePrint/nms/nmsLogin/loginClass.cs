using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;

namespace nmsLogin
{
	public class loginClass : System.Web.UI.Page
	{
		public static bool _LogIN;

		public static string _email;

		public static string _password;

		public static string hdnvalue;

		public commonClass cmn = new commonClass();

		public BasePage objpage = new BasePage();

		static loginClass()
		{
			loginClass._LogIN = false;
			loginClass._email = "";
			loginClass._password = "";
			loginClass.hdnvalue = "";
		}

		public loginClass()
		{
		}

		public void LogInFromBaseClass(string email, string password)
		{
			bool flag = false;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_login", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("email", email);
			sqlCommand.Parameters.AddWithValue("password", password);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			int num1 = 0;
			while (sqlDataReader.Read())
			{
				flag = true;
				num = int.Parse(sqlDataReader["companyid"].ToString());
				this.Session["companyID"] = num.ToString();
				this.Session["companyName"] = sqlDataReader["companyname"].ToString();
				this.Session["language"] = sqlDataReader["languagename"].ToString();
				this.Session["currency"] = sqlDataReader["currency"].ToString();
				this.Session["userID"] = int.Parse(sqlDataReader["userid"].ToString());
				num1 = int.Parse(sqlDataReader["userid"].ToString());
				this.Session["userTypeID"] = sqlDataReader["usertypeid"].ToString();
				this.Session["firstName"] = sqlDataReader["firstname"].ToString();
				this.Session["lastName"] = sqlDataReader["lastname"].ToString();
				this.Session["email"] = email;
				this.Session["CustomAccessRight"] = sqlDataReader["IsCustomAccessRight"].ToString();
				this.Session["SupplierQuote"] = sqlDataReader["IssupplierQuote"].ToString();
				this.Session["TimeZoneOrderNumber"] = sqlDataReader["TimeZoneOrderNumber"].ToString();
				this.Session["LanguageConversion"] = sqlDataReader["LanguageConversionFile"].ToString();
				this.Session["DateFormat"] = this.objpage.GetRegionalSettings(num, "Dateformat");
				this.Session["ProductStockManagement"] = sqlDataReader["ProductStockManagement"].ToString();
				this.Session["CurrencySymbol"] = sqlDataReader["CurrencySymbol"].ToString();
				this.Session["ForOtherCostFormula"] = sqlDataReader["ForOtherCostFormula"].ToString();
				if (int.Parse(sqlDataReader["subscriptionid"].ToString()) == 1000)
				{
					DateTime dateTime = Convert.ToDateTime(DateTime.Now);
					DateTime dateTime1 = Convert.ToDateTime(sqlDataReader["expiredate"].ToString());
					TimeSpan timeSpan = dateTime1.Subtract(dateTime);
					this.Session["noofdaysremaining"] = Convert.ToInt32(timeSpan.Days) + 1;
				}
				if (sqlDataReader["isadmin"].ToString().ToLower() != "true")
				{
					this.Session["admin"] = 0;
				}
				else
				{
					this.Session["admin"] = 1;
				}
				if (sqlDataReader["isassignmentright"].ToString().ToLower() != "true")
				{
					this.Session["assignmentright"] = 0;
				}
				else
				{
					this.Session["assignmentright"] = 1;
				}
				if (sqlDataReader["isOwnershipRights"].ToString().ToLower() != "true")
				{
					this.Session["isTransferRights"] = 0;
				}
				else
				{
					this.Session["isTransferRights"] = 1;
				}
				this.Session["AssignmentSetting"] = sqlDataReader["AssignmentSetting"].ToString().ToLower();
				if (sqlDataReader["iscorporateright"].ToString().ToLower() != "true")
				{
					this.Session["iscorporateright"] = 0;
				}
				else
				{
					this.Session["iscorporateright"] = 1;
					this.Session["admin"] = 1;
					this.Session["assignmentright"] = 1;
				}
			}
			_commonClass.closeConnection();
			if (flag)
			{
				this.Session["HOME"] = "False";
				this.Session["CLIENTS"] = "False";
				this.Session["CONTACTS"] = "False";
				this.Session["CAMPAIGN"] = "False";
				this.Session["SOLUTIONS"] = "False";
				this.Session["DOCUMENTS"] = "False";
				this.Session["REPORTS"] = "False";
				this.Session["FORECAST"] = "False";
				this.Session["DASHBOARD"] = "False";
				this.Session["CONTRACTS"] = "False";
				this.Session["PRODUCTS"] = "False";
				this.Session["ASSETS"] = "False";
				this.Session["S_HOME"] = "HOME";
				this.Session["S_CLIENTS"] = "CLIENTS";
				this.Session["S_CONTACTS"] = "CONTACTS";
				this.Session["S_CAMPAIGN"] = "CAMPAIGN";
				this.Session["S_SOLUTIONS"] = "SOLUTIONS";
				this.Session["S_DOCUMENTS"] = "DOCUMENTS";
				this.Session["S_REPORTS"] = "REPORTS";
				this.Session["S_FORECAST"] = "FORECAST";
				this.Session["S_DASHBOARD"] = "DASHBOARD";
				this.Session["S_CONTRACTS"] = "CONTRACTS";
				this.Session["S_PRODUCTS"] = "PRODUCTS";
				this.Session["S_ASSETS"] = "ASSETS";
				SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_UserTab", _commonClass.openConnection());
				sqlCommand1.Parameters.AddWithValue("@companyID", num);
				sqlCommand1.Parameters.AddWithValue("@userID", num1);
				sqlCommand1.CommandType = CommandType.StoredProcedure;
				SqlDataReader item = sqlCommand1.ExecuteReader();
				while (item.Read())
				{
					this.Session[item["headerName"].ToString()] = item["isDisplay"];
					this.Session[item["s_HeaderName"].ToString()] = item["screenname"];
				}
				item.Close();
				_commonClass.closeConnection();
				SqlCommand sqlCommand2 = new SqlCommand("crm_selectSessionmanagement", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand2.Parameters.Add("@companyID", num);
				sqlCommand2.Parameters.Add("@userID", num1);
				SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
				while (sqlDataReader1.Read())
				{
					this.Session["session_expireon"] = sqlDataReader1["sessionexpireafter"].ToString();
					this.Session["redirectpage"] = sqlDataReader1["redirectPage"].ToString();
				}
				sqlDataReader1.Close();
				_commonClass.closeConnection();
			}
		}

		public void LogInFromDefault(string email, string password)
		{
			bool flag = false;
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_login", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("email", email);
			sqlCommand.Parameters.AddWithValue("password", password);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			int num1 = 0;
			while (sqlDataReader.Read())
			{
				flag = true;
				num = int.Parse(sqlDataReader["companyid"].ToString());
				this.Session["companyID"] = num.ToString();
				this.Session["companyName"] = sqlDataReader["companyname"].ToString();
				this.Session["language"] = sqlDataReader["languagename"].ToString();
				this.Session["currency"] = sqlDataReader["currency"].ToString();
				this.Session["userID"] = int.Parse(sqlDataReader["userid"].ToString());
				num1 = int.Parse(sqlDataReader["userid"].ToString());
				this.Session["userTypeID"] = sqlDataReader["usertypeid"].ToString();
				this.Session["firstName"] = sqlDataReader["firstname"].ToString();
				this.Session["lastName"] = sqlDataReader["lastname"].ToString();
				this.Session["email"] = email;
				this.Session["CustomAccessRight"] = sqlDataReader["IsCustomAccessRight"].ToString();
				this.Session["SupplierQuote"] = sqlDataReader["IssupplierQuote"].ToString();
				this.Session["TimeZoneOrderNumber"] = sqlDataReader["TimeZoneOrderNumber"].ToString();
				this.Session["LanguageConversion"] = sqlDataReader["LanguageConversionFile"].ToString();
				this.Session["DateFormat"] = this.objpage.GetRegionalSettings(num, "Dateformat");
				this.Session["ProductStockManagement"] = sqlDataReader["ProductStockManagement"].ToString();
				this.Session["UpgradeNotification"] = "view";
				this.Session["CurrencySymbol"] = sqlDataReader["CurrencySymbol"].ToString();
				this.Session["ForOtherCostFormula"] = sqlDataReader["ForOtherCostFormula"].ToString();
				if (int.Parse(sqlDataReader["subscriptionid"].ToString()) == 1000)
				{
					DateTime dateTime = Convert.ToDateTime(DateTime.Now);
					DateTime dateTime1 = Convert.ToDateTime(sqlDataReader["expiredate"].ToString());
					TimeSpan timeSpan = dateTime1.Subtract(dateTime);
					this.Session["noofdaysremaining"] = Convert.ToInt32(timeSpan.Days) + 1;
				}
				if (sqlDataReader["isadmin"].ToString().ToLower() != "true")
				{
					this.Session["admin"] = 0;
				}
				else
				{
					this.Session["admin"] = 1;
				}
				if (sqlDataReader["isassignmentright"].ToString().ToLower() != "true")
				{
					this.Session["assignmentright"] = 0;
				}
				else
				{
					this.Session["assignmentright"] = 1;
				}
				if (sqlDataReader["isOwnershipRights"].ToString().ToLower() != "true")
				{
					this.Session["isTransferRights"] = 0;
				}
				else
				{
					this.Session["isTransferRights"] = 1;
				}
				this.Session["AssignmentSetting"] = sqlDataReader["AssignmentSetting"].ToString().ToLower();
				if (sqlDataReader["iscorporateright"].ToString().ToLower() != "true")
				{
					this.Session["iscorporateright"] = 0;
				}
				else
				{
					this.Session["iscorporateright"] = 1;
					this.Session["admin"] = 1;
					this.Session["assignmentright"] = 1;
				}
			}
			_commonClass.closeConnection();
			if (flag)
			{
				this.Session["HOME"] = "False";
				this.Session["CLIENTS"] = "False";
				this.Session["CONTACTS"] = "False";
				this.Session["CAMPAIGN"] = "False";
				this.Session["SOLUTIONS"] = "False";
				this.Session["DOCUMENTS"] = "False";
				this.Session["REPORTS"] = "False";
				this.Session["FORECAST"] = "False";
				this.Session["DASHBOARD"] = "False";
				this.Session["CONTRACTS"] = "False";
				this.Session["PRODUCTS"] = "False";
				this.Session["ASSETS"] = "False";
				this.Session["S_HOME"] = "HOME";
				this.Session["S_CLIENTS"] = "CLIENTS";
				this.Session["S_CONTACTS"] = "CONTACTS";
				this.Session["S_CAMPAIGN"] = "CAMPAIGN";
				this.Session["S_SOLUTIONS"] = "SOLUTIONS";
				this.Session["S_DOCUMENTS"] = "DOCUMENTS";
				this.Session["S_REPORTS"] = "REPORTS";
				this.Session["S_FORECAST"] = "FORECAST";
				this.Session["S_DASHBOARD"] = "DASHBOARD";
				this.Session["S_CONTRACTS"] = "CONTRACTS";
				this.Session["S_PRODUCTS"] = "PRODUCTS";
				this.Session["S_ASSETS"] = "ASSETS";
				SqlCommand sqlCommand1 = new SqlCommand("crm_common_select_UserTab", _commonClass.openConnection());
				sqlCommand1.Parameters.AddWithValue("@companyID", num);
				sqlCommand1.Parameters.AddWithValue("@userID", num1);
				sqlCommand1.CommandType = CommandType.StoredProcedure;
				SqlDataReader item = sqlCommand1.ExecuteReader();
				while (item.Read())
				{
					this.Session[item["headerName"].ToString()] = item["isDisplay"];
					this.Session[item["s_HeaderName"].ToString()] = item["screenname"];
				}
				item.Close();
				_commonClass.closeConnection();
				SqlCommand sqlCommand2 = new SqlCommand("crm_selectSessionmanagement", _commonClass.openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand2.Parameters.Add("@companyID", num);
				sqlCommand2.Parameters.Add("@userID", num1);
				SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
				while (sqlDataReader1.Read())
				{
					this.Session["session_expireon"] = sqlDataReader1["sessionexpireafter"].ToString();
					this.Session["redirectpage"] = sqlDataReader1["redirectPage"].ToString();
				}
				sqlDataReader1.Close();
				_commonClass.closeConnection();
				string str = this.Session.SessionID.ToString();
				string str1 = email;
				TimeSpan timeSpan1 = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
				HttpContext.Current.Cache.Insert(str1, str, null, DateTime.MaxValue, timeSpan1, CacheItemPriority.NotRemovable, null);
			}
		}
	}
}