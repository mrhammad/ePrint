using nmsCommon;
using nmsConnection;
using Printcenter.UI.CMS;
using Printcenter.UI.LoginNew;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;

namespace nmsLoginclass
{
	public class loginclass : System.Web.UI.Page
	{
		public loginclass()
		{
		}

		public void Insert_intoResume_Session(string email, string password)
		{
			commonclass _commonclass = new commonclass();
			SqlCommand sqlCommand = new SqlCommand("[Ws_ResumeSessionStore_insert]", _commonclass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@Email", email);
			sqlCommand.Parameters.Add("@Password", password);
			sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.BigInt).Direction = ParameterDirection.ReturnValue;
			string str = Convert.ToString(sqlCommand.ExecuteScalar());
			this.Context.Response.Cookies.Add(new HttpCookie("ResumeSessionID", str.ToString()));
			_commonclass.closeConnection();
		}

		public void LogIn_FromBaseClass(string email, string password)
		{
			long num = (long)0;
			foreach (DataRow row in LoginBasePage.LoginTo_Store(email, password, num, ConnectionClass.AccountType).Rows)
			{
				this.Session["FirstName"] = row["FirstName"].ToString();
				this.Session["LastName"] = row["LastName"].ToString();
				this.Session["EmailID"] = row["EmailID"].ToString();
				this.Session["Password"] = row["Password"].ToString();
				this.Session["ProductStockManagement"] = row["ProductStockManagement"].ToString();
				this.Session["LanguageConversion"] = row["LanguageConversionFile"].ToString();
				this.Session["CompanyName"] = row["CompanyName"].ToString();
				this.Session["CurrencySymbol"] = row["CurrencySymbol"].ToString();
				this.Session["StatusTitle"] = row["StatusTitle"].ToString();
			}
		}

		public void LogInFromDefault(string email, string password)
		{
			string empty = string.Empty;
			long num = Convert.ToInt64(ConnectionClass.AccountID);
			foreach (DataRow row in LoginBasePage.LoginTo_Store(email, password, num, ConnectionClass.AccountType).Rows)
			{
				this.Session["StoreUserID"] = row["StoreUserID"].ToString();
				this.Session["FirstName"] = row["FirstName"].ToString();
				this.Session["LastName"] = row["LastName"].ToString();
				this.Session["EmailID"] = row["EmailID"].ToString();
				this.Session["Password"] = row["Password"].ToString();
				this.Session["ProductStockManagement"] = row["ProductStockManagement"].ToString();
				this.Session["LanguageConversion"] = row["LanguageConversionFile"].ToString();
				this.Session["CompanyName"] = row["CompanyName"].ToString();
				this.Session["CurrencySymbol"] = row["CurrencySymbol"].ToString();
				this.Session["StatusTitle"] = row["StatusTitle"].ToString();
			}
			string str = this.Session.SessionID.ToString();
			string str1 = email;
			empty = (EprintConfigurationManager.AppSettings["AccountType"].ToString().ToLower() != "private" ? "x" : "p");
			if (empty == "x")
			{
				DataTable displaySettings = CMSBasePage.GetDisplaySettings(num);
				this.Session["eStoreDisplaySetting"] = displaySettings;
			}
			TimeSpan timeSpan = new TimeSpan(0, 1, 0, 0, 0);
			HttpContext.Current.Cache.Insert(str1, str, null, DateTime.MaxValue, timeSpan, CacheItemPriority.NotRemovable, null);
		}
	}
}