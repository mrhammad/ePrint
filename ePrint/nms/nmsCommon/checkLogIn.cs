using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class checkLogIn
	{
		public int companyID;

		public int userID;

		public int groupID;

		public int userTypeID;

		public string companyName;

		public string languageName;

		public string currency;

		public string firstName;

		public string lastName;

		public int isAdmin;

		public int isCorporateRight;

		public int isGroupEnabled;

		public int isAssignmentRight;

		public checkLogIn()
		{
		}

		public void initSession(string email)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_initSession", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@email", email);
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@companyId", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter1 = sqlCommand.Parameters.AddWithValue("@companyName", SqlDbType.VarChar);
			sqlParameter1.Size = 250;
			sqlParameter1.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter2 = sqlCommand.Parameters.AddWithValue("@languagename", SqlDbType.VarChar);
			sqlParameter2.Size = 50;
			sqlParameter2.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter3 = sqlCommand.Parameters.AddWithValue("@currency", SqlDbType.NVarChar);
			sqlParameter3.Size = 50;
			sqlParameter3.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter4 = sqlCommand.Parameters.AddWithValue("@isGroupEnabled", SqlDbType.Int);
			sqlParameter4.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter5 = sqlCommand.Parameters.AddWithValue("@userID", SqlDbType.Int);
			sqlParameter5.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter6 = sqlCommand.Parameters.AddWithValue("@groupID", SqlDbType.Int);
			sqlParameter6.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter7 = sqlCommand.Parameters.AddWithValue("@userTypeID", SqlDbType.Int);
			sqlParameter7.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter8 = sqlCommand.Parameters.AddWithValue("@isCorporateRight", SqlDbType.Int);
			sqlParameter8.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter9 = sqlCommand.Parameters.AddWithValue("@isAdmin", SqlDbType.Int);
			sqlParameter9.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter10 = sqlCommand.Parameters.AddWithValue("@firstName", SqlDbType.VarChar);
			sqlParameter10.Size = 200;
			sqlParameter10.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter11 = sqlCommand.Parameters.AddWithValue("@lastName", SqlDbType.VarChar);
			sqlParameter11.Size = 200;
			sqlParameter11.Direction = ParameterDirection.Output;
			SqlParameter sqlParameter12 = sqlCommand.Parameters.AddWithValue("@isAssignmentRight", SqlDbType.Int);
			sqlParameter12.Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			this.companyID = (int)sqlCommand.Parameters["@companyID"].Value;
			this.companyName = sqlCommand.Parameters["@companyName"].Value.ToString();
			this.languageName = sqlCommand.Parameters["@languagename"].Value.ToString();
			this.currency = sqlCommand.Parameters["@currency"].Value.ToString();
			this.userID = (int)sqlCommand.Parameters["@userID"].Value;
			this.groupID = (int)sqlCommand.Parameters["@groupID"].Value;
			this.userTypeID = (int)sqlCommand.Parameters["@userTypeID"].Value;
			this.firstName = sqlCommand.Parameters["@firstName"].Value.ToString();
			this.lastName = sqlCommand.Parameters["@lastName"].Value.ToString();
			this.isAdmin = int.Parse(sqlCommand.Parameters["@isAdmin"].Value.ToString());
			this.isAssignmentRight = int.Parse(sqlCommand.Parameters["@isAssignmentRight"].Value.ToString());
			this.isGroupEnabled = (int)sqlCommand.Parameters["@isGroupEnabled"].Value;
			this.isCorporateRight = (int)sqlCommand.Parameters["@isCorporateRight"].Value;
			_commonClass.closeConnection();
		}

		public bool login(string email, string password)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_checkLogin", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@password", password);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}
	}
}