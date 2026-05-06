using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsOpportunity
{
	public class contactRoleClass
	{
		public contactRoleClass()
		{
		}

		public void contactRole_add(int companyId, int contactId, int opportunityId, int roleId, int isPrimary)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_contactRole_add"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@roleId", roleId);
			sqlCommand.Parameters.AddWithValue("@isPrimary", isPrimary);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contactRole_delete(int contactRoleId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_contactrole_delete"
			};
			sqlCommand.Parameters.AddWithValue("@contactRoleId", contactRoleId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contactRole_delete_all(int opportunityId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_contactrole_delete_all"
			};
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader dtr_select_contact_all(int opportunityId, int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_contactrole_all", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader dtrRole(int companyid)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_Role", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("companyid", companyid);
			return sqlCommand.ExecuteReader();
		}
	}
}