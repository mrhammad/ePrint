using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsDocument
{
	public class documentClass
	{
		public documentClass()
		{
		}

		public int document_Add(int parentlevel, string categoryname, int companyId, string description, string title, string fileName, string createDate, string modifiedDate, int createUserID, int modifyUserID, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_document_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@parentlevel", parentlevel);
			sqlCommand.Parameters.AddWithValue("@categoryname", categoryname);
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@fileName", fileName);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void document_Delete(int documentId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_document_delete ", documentId, ",", companyId };
			string str = string.Concat(objArray);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void document_Edit(int parentlevel, string categoryname, int documentId, int companyId, string description, string title, string fileName, string modifiedDate, int modifyUserID, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_document_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@parentlevel", parentlevel);
			sqlCommand.Parameters.AddWithValue("@categoryname", categoryname);
			sqlCommand.Parameters.AddWithValue("@documentId", documentId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@fileName", fileName);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void documentCategory_Add(int companyId, string documentCategory, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_documentCategory_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			sqlCommand.Parameters.AddWithValue("@documentCategory", documentCategory);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet documentCategory_ViewAll(int companyID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_documentCategory_viewall ", companyID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public SqlDataReader documentDetail(int documentId, int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_document_detail", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@documentId", documentId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader fillDropdown(int companyId, int parentLevel)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_document_category_inddl", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			sqlCommand.Parameters.AddWithValue("@parentlevel", parentLevel);
			return sqlCommand.ExecuteReader();
		}
	}
}