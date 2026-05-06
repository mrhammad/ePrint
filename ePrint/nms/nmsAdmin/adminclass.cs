using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsAdmin
{
	public class adminclass
	{
		private commonClass objCommonClass = new commonClass();

		public adminclass()
		{
		}

		public void documentcategory_add(int companyId, string documentcategory)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_document_category"
			};
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@documentcategory", documentcategory);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void documentcategory_delete(int documentcategoryId, int companyid)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_delete_document_category"
			};
			sqlCommand.Parameters.AddWithValue("@documentcategoryId", documentcategoryId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}

		public void documentcategory_update(int documentcategoryId, string documentcategory)
		{
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = this.objCommonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_update_document_category"
			};
			sqlCommand.Parameters.AddWithValue("@documentcategoryID", documentcategoryId);
			sqlCommand.Parameters.AddWithValue("@documentcategory", documentcategory);
			sqlCommand.ExecuteNonQuery();
			this.objCommonClass.closeConnection();
		}
	}
}