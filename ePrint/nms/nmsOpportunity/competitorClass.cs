using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsOpportunity
{
	public class competitorClass
	{
		public competitorClass()
		{
		}

		public void competitor_Add(int companyId, int opportunityId, string competitorName, string strength, string weakness, int createUserID, string createDate, int modifyUserID, string modifiedDate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_competitor_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@competitorName", competitorName);
			sqlCommand.Parameters.AddWithValue("@strength", strength);
			sqlCommand.Parameters.AddWithValue("@weakness", weakness);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void competitor_Delete(int competitorId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_competitor_delete"
			};
			sqlCommand.Parameters.AddWithValue("@competitorId", competitorId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void competitor_Edit(int competitorId, int companyId, int opportunityId, string competitorName, string strength, string weakness, int modifyUserID, string modifiedDate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_competitor_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@competitorId", competitorId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@competitorName", competitorName);
			sqlCommand.Parameters.AddWithValue("@strength", strength);
			sqlCommand.Parameters.AddWithValue("@weakness", weakness);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader dtr_Select_Competitor(int competitorId, int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_competitor", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@competitorId", competitorId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			return sqlCommand.ExecuteReader();
		}
	}
}