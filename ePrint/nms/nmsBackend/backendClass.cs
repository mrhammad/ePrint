using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsBackend
{
	public class backendClass
	{
		private commonClass objCommonClass = new commonClass();

		public backendClass()
		{
		}

		public bool admin_login(string username, string password1, int companyid)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_check_admin", this.objCommonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@username", username);
			sqlCommand.Parameters.AddWithValue("@password", password1);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			this.objCommonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		public void taskstatus_add(int companyId, string taskStatusName)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_task_status"
			};
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatusName);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void taskstatus_delete(int taskStatusId, int companyid)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_delete_task_status"
			};
			sqlCommand.Parameters.AddWithValue("@taskStatusID", taskStatusId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void taskstatus_update(int taskStatusId, string taskStatusName)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_update_task_status"
			};
			sqlCommand.Parameters.AddWithValue("@taskStatusID", taskStatusId);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatusName);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void timezone_add(string timezone, string stroperator, int hourdiff, int mindiff, int secdiff)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_timezone_add_new"
			};
			sqlCommand.Parameters.AddWithValue("@timezone", timezone);
			sqlCommand.Parameters.AddWithValue("@stroperator", stroperator);
			sqlCommand.Parameters.AddWithValue("@hourdiff", hourdiff);
			sqlCommand.Parameters.AddWithValue("@mindiff", mindiff);
			sqlCommand.Parameters.AddWithValue("@secdiff", secdiff);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void timezone_delete(int timezoneId)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_delete_timezone"
			};
			sqlCommand.Parameters.AddWithValue("@timezoneId", timezoneId);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public SqlDataReader timezone_dtr(int timezoneid)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_timezone_select_field_new"
			};
			sqlCommand.Parameters.AddWithValue("@timezoneID", timezoneid);
			return sqlCommand.ExecuteReader();
		}

		public void timezone_update(int timezoneid, string timezone, string stroperator, int hourdiff, int mindiff, int secdiff)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_timezone_update_new"
			};
			sqlCommand.Parameters.AddWithValue("@timezoneID", timezoneid);
			sqlCommand.Parameters.AddWithValue("@timezone", timezone);
			sqlCommand.Parameters.AddWithValue("@stroperator", stroperator);
			sqlCommand.Parameters.AddWithValue("@hourdiff", hourdiff);
			sqlCommand.Parameters.AddWithValue("@mindiff", mindiff);
			sqlCommand.Parameters.AddWithValue("@secdiff", secdiff);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}
	}
}