using nmsCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace nmsCustomize
{
	public class DbCustomize
	{
		public DbCustomize()
		{
		}

		public virtual List<CustomizeItem> GetCustomizeField(int CompanyID, int UserID, string pg)
		{
			List<CustomizeItem> customizeItems = new List<CustomizeItem>();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield_All", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyId", CompanyID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				CustomizeItem customizeItem = new CustomizeItem(Convert.ToInt32(sqlDataReader["CustomizeID"].ToString()), Convert.ToInt32(sqlDataReader["CompanyID"].ToString()), sqlDataReader["databaseFieldName"].ToString(), sqlDataReader["labelName"].ToString(), sqlDataReader["inputType"].ToString(), sqlDataReader["dataType"].ToString(), Convert.ToBoolean(sqlDataReader["isDisplayed"].ToString()), Convert.ToBoolean(sqlDataReader["isDefault"].ToString()), Convert.ToBoolean(sqlDataReader["isRequired"].ToString()), Convert.ToBoolean(sqlDataReader["isReadOnly"].ToString()), Convert.ToInt32(sqlDataReader["orderNumber"].ToString()), sqlDataReader["dataBaseName"].ToString(), sqlDataReader["optionValue"].ToString(), Convert.ToInt32(sqlDataReader["maxLength"].ToString()), sqlDataReader["fieldType"].ToString(), Convert.ToBoolean(sqlDataReader["isNewRow"].ToString()), sqlDataReader["screenName"].ToString());
				customizeItems.Add(customizeItem);
			}
			_commonClass.closeConnection();
			return customizeItems;
		}

		public virtual List<CustomizeItem> GetCustomizeFieldByID(int CompanyID, string pg)
		{
			List<CustomizeItem> customizeItems = new List<CustomizeItem>();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_common_select_customizefield", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyId", CompanyID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				CustomizeItem customizeItem = new CustomizeItem(Convert.ToInt32(sqlDataReader["CustomizeID"].ToString()), Convert.ToInt32(sqlDataReader["CompanyID"].ToString()), sqlDataReader["databaseFieldName"].ToString(), sqlDataReader["labelName"].ToString(), sqlDataReader["inputType"].ToString(), sqlDataReader["dataType"].ToString(), bool.Parse(sqlDataReader["isDisplayed"].ToString()), bool.Parse(sqlDataReader["isDefault"].ToString()), bool.Parse(sqlDataReader["isRequired"].ToString()), bool.Parse(sqlDataReader["isReadOnly"].ToString()), Convert.ToInt32(sqlDataReader["orderNumber"].ToString()), sqlDataReader["dataBaseName"].ToString(), sqlDataReader["optionValue"].ToString(), Convert.ToInt32(sqlDataReader["maxLength"].ToString()), sqlDataReader["fieldType"].ToString(), bool.Parse(sqlDataReader["isNewRow"].ToString()), sqlDataReader["screenName"].ToString());
				_commonClass.closeConnection();
				customizeItems.Add(customizeItem);
			}
			return customizeItems;
		}
	}
}