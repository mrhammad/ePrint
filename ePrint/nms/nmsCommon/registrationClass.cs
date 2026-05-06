using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class registrationClass
	{
		public registrationClass()
		{
		}

		public void add_user(int companyid, string email, string password, string firstname, string lastname, string phone, string jobtitle, int isadmin, string createdate, string modifieddate, int timezoneid, int ispasswordexpire, string expiredate, int groupid, int usertypeid, int iscorporateright, string verificationcode)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_user_add_withAccessRights"
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@password", password);
			sqlCommand.Parameters.AddWithValue("@firstname", firstname);
			sqlCommand.Parameters.AddWithValue("@lastname", lastname);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@jobtitle", jobtitle);
			sqlCommand.Parameters.AddWithValue("@isadmin", isadmin);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.Parameters.AddWithValue("@modifieddate", modifieddate);
			sqlCommand.Parameters.AddWithValue("@timezoneid", timezoneid);
			sqlCommand.Parameters.AddWithValue("@ispasswordexpire", ispasswordexpire);
			sqlCommand.Parameters.AddWithValue("@expiredate", expiredate);
			sqlCommand.Parameters.AddWithValue("@groupid", groupid);
			sqlCommand.Parameters.AddWithValue("@usertypeid", usertypeid);
			sqlCommand.Parameters.AddWithValue("@iscorporateright", iscorporateright);
			sqlCommand.Parameters.AddWithValue("@verificationcode", verificationcode);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void AddSecondAdmin(string companyname, string firstname, string lastname, string email, string password, string confirmpassword, string address1, string address2, string city, string country, string zip, string hearaboutus, string comments, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_addsecondadmin"
			};
			sqlCommand.Parameters.AddWithValue("@companyname", companyname);
			sqlCommand.Parameters.AddWithValue("@firstname", firstname);
			sqlCommand.Parameters.AddWithValue("@lastname", lastname);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@password", password);
			sqlCommand.Parameters.AddWithValue("@confirmpassword", confirmpassword);
			sqlCommand.Parameters.AddWithValue("@address1", address1);
			sqlCommand.Parameters.AddWithValue("@address2", address2);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@hearaboutus", hearaboutus);
			sqlCommand.Parameters.AddWithValue("@comments", comments);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int registration(string country, string lcid, string companyname, string address, string city, string zip, int noofemployee, int noofuser, string hearfrom, string comment, int isTrial, string regdate, string modifieddate, int isnewsletter, int isbusiness, string expiredate, string languagename, string currency, int isgroupenabled, int timezoneid, string datetimeformat, string email, int createuserid, int expire, string uniqueValue)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_register"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@lcid", lcid);
			sqlCommand.Parameters.AddWithValue("@companyname", companyname);
			sqlCommand.Parameters.AddWithValue("@address", address);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@noofemployee", noofemployee);
			sqlCommand.Parameters.AddWithValue("@noofuser", noofuser);
			sqlCommand.Parameters.AddWithValue("@hearfrom", hearfrom);
			sqlCommand.Parameters.AddWithValue("@comment", comment);
			sqlCommand.Parameters.AddWithValue("@istrail", isTrial);
			sqlCommand.Parameters.AddWithValue("@regdate", regdate);
			sqlCommand.Parameters.AddWithValue("@modifieddate", modifieddate);
			sqlCommand.Parameters.AddWithValue("@isnewsletter", isnewsletter);
			sqlCommand.Parameters.AddWithValue("@isbusiness", isbusiness);
			sqlCommand.Parameters.AddWithValue("@expiredate", expiredate);
			sqlCommand.Parameters.AddWithValue("@languagename", languagename);
			sqlCommand.Parameters.AddWithValue("@currency", currency);
			sqlCommand.Parameters.AddWithValue("@datetimeformat", datetimeformat);
			sqlCommand.Parameters.AddWithValue("@isgroupenabled", isgroupenabled);
			sqlCommand.Parameters.AddWithValue("@timezoneid", timezoneid);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@expires", expire);
			sqlCommand.Parameters.AddWithValue("@UniqueValue", uniqueValue);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}
	}
}