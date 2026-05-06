using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsClient
{
	public class partnerClass
	{
		public partnerClass()
		{
		}

		public SqlDataReader dtr_select_partner_clientName(int clientId, int companyid)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_partner_clientName", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader dtrPartnerRole()
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_partnerRole", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			return sqlCommand.ExecuteReader();
		}

		public void Partner_add(int companyId, int clientId, string PartnerClientName, int partnerRoleId, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_partner_add"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@PartnerClientName", PartnerClientName);
			sqlCommand.Parameters.AddWithValue("@partnerRoleId", partnerRoleId);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void partner_delete(int partnerId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_partner_delete"
			};
			sqlCommand.Parameters.AddWithValue("@partnerId", partnerId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}
	}
}