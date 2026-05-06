using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsSolution
{
	public class solutionClass
	{
		public solutionClass()
		{
		}

		public int solution_Add(int companyId, string solutionNumber, string solutionTitle, string description, int isPublished, string solutionStatus, int createUserId, int modifyUserId, string createDate, string modifiedDate, string lastViewDate, int isSample, int isDelete, string solutionAlias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_solution_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyID", companyId);
			sqlCommand.Parameters.AddWithValue("@solutionNumber", solutionNumber);
			sqlCommand.Parameters.AddWithValue("@solutionTitle", solutionTitle);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isPublished", isPublished);
			sqlCommand.Parameters.AddWithValue("@solutionStatus", solutionStatus);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@solutionAlias", solutionAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void solution_AddCustomizValue(int solutionCustomizeId, int solutionId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_solution_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@solutionCustomizeId", solutionCustomizeId);
			sqlCommand.Parameters.AddWithValue("@solutionId", solutionId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyId", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void solution_Delete(int solutionId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_solution_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@solutionId", solutionId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void solution_Edit(int solutionId, int companyId, string solutionNumber, string solutionTitle, string description, int isPublished, string solutionStatus, int modifyUserId, string modifiedDate, string lastViewDate, int isSample, int isDelete, string solutionAlias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_solution_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@solutionId", solutionId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@solutionNumber", solutionNumber);
			sqlCommand.Parameters.AddWithValue("@solutionTitle", solutionTitle);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isPublished", isPublished);
			sqlCommand.Parameters.AddWithValue("@solutionStatus", solutionStatus);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@solutionAlias", solutionAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void solution_EditCustomizeVAlue(int solutionCustomizeID, int solutionId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_solution_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@solutionCustomizeID", solutionCustomizeID);
			sqlCommand.Parameters.AddWithValue("@solutionId", solutionId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet solution_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_solution_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}