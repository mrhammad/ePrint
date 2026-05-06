using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsOpportunity
{
	public class opportunityClass
	{
		public opportunityClass()
		{
		}

		public int opportunity_Add(string opportunityalias, int clientId, int companyid, int campaignId, string opportunityName, string opportunityType, string opportunityStageName, string leadSourceName, string description, string lastViewDate, int createUserID, string createDate, int modifyUserID, string modifiedDate, decimal probability, string nextStep, decimal amount, decimal expectedAmount, string closeDate, int isClosed, int isWon, int isDelete, int isSample)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@opportunityalias", opportunityalias);
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.Parameters.AddWithValue("@opportunityName", opportunityName);
			sqlCommand.Parameters.AddWithValue("@opportunityType", opportunityType);
			sqlCommand.Parameters.AddWithValue("@opportunityStageName", opportunityStageName);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@probability", probability);
			sqlCommand.Parameters.AddWithValue("@nextStep", nextStep);
			sqlCommand.Parameters.AddWithValue("@amount", amount);
			sqlCommand.Parameters.AddWithValue("@expectedAmount", expectedAmount);
			sqlCommand.Parameters.AddWithValue("@closeDate", closeDate);
			sqlCommand.Parameters.AddWithValue("@isClosed", isClosed);
			sqlCommand.Parameters.AddWithValue("@isWon", isWon);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void opportunity_AddCustomizValue(int CustomizeId, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@customizeid", CustomizeId);
			sqlCommand.Parameters.AddWithValue("@id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedvalue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_Delete(int opportunityId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_Edit(string opportunityalias, int opportunityId, int clientId, int companyid, int campaignId, string opportunityName, string opportunityType, string opportunityStageName, string leadSourceName, string description, string lastViewDate, int modifyUserID, string modifiedDate, decimal probability, string nextStep, decimal amount, decimal expectedAmount, string closeDate, int isClosed, int isWon, int isDelete, int isSample)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@opportunityalias", opportunityalias);
			sqlCommand.Parameters.AddWithValue("@opportunityId", opportunityId);
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.Parameters.AddWithValue("@opportunityName", opportunityName);
			sqlCommand.Parameters.AddWithValue("@opportunityType", opportunityType);
			sqlCommand.Parameters.AddWithValue("@opportunityStageName", opportunityStageName);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@probability", probability);
			sqlCommand.Parameters.AddWithValue("@nextStep", nextStep);
			sqlCommand.Parameters.AddWithValue("@amount", amount);
			sqlCommand.Parameters.AddWithValue("@expectedAmount", expectedAmount);
			sqlCommand.Parameters.AddWithValue("@closeDate", closeDate);
			sqlCommand.Parameters.AddWithValue("@isClosed", isClosed);
			sqlCommand.Parameters.AddWithValue("@isWon", isWon);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_EditCustomizeVAlue(int CustomizeID, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
			sqlCommand.Parameters.AddWithValue("@Id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_listprice_Add(int productID, int companyID, int opportunityID, int quantity, double salePrice, string detail, string createdate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_pricelist_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@opportunityID", opportunityID);
			sqlCommand.Parameters.AddWithValue("@quantity", quantity);
			sqlCommand.Parameters.AddWithValue("@salePrice", salePrice);
			sqlCommand.Parameters.AddWithValue("@detail", detail);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_listprice_Delete(int tableID, int companyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_pricelist_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@tableid", tableID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void opportunity_listprice_Edit(int tableID, int companyID, int opportunityID, int quantity, double salePrice, string detail, string createdate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_opportunity_pricelist_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@tableid", tableID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@quantity", quantity);
			sqlCommand.Parameters.AddWithValue("@salePrice", salePrice);
			sqlCommand.Parameters.AddWithValue("@detail", detail);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet opportunity_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_opportunity_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}