using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsContract
{
	public class contractClass
	{
		public contractClass()
		{
		}

		public int contract_Add(string contractalias, int companyID, int clientid, string status, string contractstartdate, string contractenddate, int companysignedbyid, string companysigneddate, int customersignedbyid, string customersignedtitle, string customersigneddate, int ownerexpirationnotice, int reportToUserID, string description, int createUserID, int modifyUserID, string createDate, string modifiedDate, string lastViewDate, int isDelete, string billingStreet, string billingCity, string billingState, string billingZip, string billingCountry, string shippingStreet, string shippingCity, string shippingState, string shippingZip, string shippingCountry, int contractterm)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@contractalias", contractalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@clientid", clientid);
			sqlCommand.Parameters.AddWithValue("@status", status);
			sqlCommand.Parameters.AddWithValue("@contractstartdate", contractstartdate);
			sqlCommand.Parameters.AddWithValue("@contractenddate", contractenddate);
			sqlCommand.Parameters.AddWithValue("@companysignedbyid", companysignedbyid);
			sqlCommand.Parameters.AddWithValue("@companysigneddate", companysigneddate);
			sqlCommand.Parameters.AddWithValue("@customersignedbyid", customersignedbyid);
			sqlCommand.Parameters.AddWithValue("@customersignedtitle", customersignedtitle);
			sqlCommand.Parameters.AddWithValue("@customersigneddate", customersigneddate);
			sqlCommand.Parameters.AddWithValue("@ownerexpirationnotice", ownerexpirationnotice);
			sqlCommand.Parameters.AddWithValue("@reportToUserID", reportToUserID);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@billingStreet", billingStreet);
			sqlCommand.Parameters.AddWithValue("@billingCity", billingCity);
			sqlCommand.Parameters.AddWithValue("@billingState", billingState);
			sqlCommand.Parameters.AddWithValue("@billingZip", billingZip);
			sqlCommand.Parameters.AddWithValue("@billingCountry", billingCountry);
			sqlCommand.Parameters.AddWithValue("@shippingStreet", shippingStreet);
			sqlCommand.Parameters.AddWithValue("@shippingCity", shippingCity);
			sqlCommand.Parameters.AddWithValue("@shippingState", shippingState);
			sqlCommand.Parameters.AddWithValue("@shippingZip", shippingZip);
			sqlCommand.Parameters.AddWithValue("@shippingCountry", shippingCountry);
			sqlCommand.Parameters.AddWithValue("@contractterm", contractterm);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void contract_AddCustomizValue(int CustomizeId, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@customizeid", CustomizeId);
			sqlCommand.Parameters.AddWithValue("@id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedvalue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int contract_approval_Add(int contractid, int companyID, string approvalstatus, int assigntouserid, int createUserID, int modifyUserID, string createDate, string modifiedDate, int isDelete, string requestcomment)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_approval_add", _commonClass.openConnection());
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.AddWithValue("@contractid", contractid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@approvalstatus", approvalstatus);
			sqlCommand.Parameters.AddWithValue("@assigntouserid", assigntouserid);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@requestcomment", requestcomment);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public SqlDataReader contract_approval_Detail(int contractapprovalid, int companyID)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_contract_approval_detail", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contractapprovalid", contractapprovalid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public void contract_approval_Edit(int contractapprovalid, int companyID, string approvalstatus, int modifyUserID, string modifiedDate, string approvalcomment)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_approval_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contractapprovalid", contractapprovalid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@approvalstatus", approvalstatus);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@approvalcomment", approvalcomment);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contract_Delete(int contractId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contractId", contractId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contract_Edit(int contractId, string contractalias, int companyID, int clientid, string status, string contractstartdate, string contractenddate, int companysignedbyid, string companysigneddate, int customersignedbyid, string customersignedtitle, string customersigneddate, int ownerexpirationnotice, int reportToUserID, string description, int createUserID, int modifyUserID, string createDate, string modifiedDate, string lastViewDate, int isDelete, string billingStreet, string billingCity, string billingState, string billingZip, string billingCountry, string shippingStreet, string shippingCity, string shippingState, string shippingZip, string shippingCountry, int contractterm)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contractId", contractId);
			sqlCommand.Parameters.AddWithValue("@contractalias", contractalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@clientid", clientid);
			sqlCommand.Parameters.AddWithValue("@status", status);
			sqlCommand.Parameters.AddWithValue("@contractstartdate", contractstartdate);
			sqlCommand.Parameters.AddWithValue("@contractenddate", contractenddate);
			sqlCommand.Parameters.AddWithValue("@companysignedbyid", companysignedbyid);
			sqlCommand.Parameters.AddWithValue("@companysigneddate", companysigneddate);
			sqlCommand.Parameters.AddWithValue("@customersignedbyid", customersignedbyid);
			sqlCommand.Parameters.AddWithValue("@customersignedtitle", customersignedtitle);
			sqlCommand.Parameters.AddWithValue("@customersigneddate", customersigneddate);
			sqlCommand.Parameters.AddWithValue("@ownerexpirationnotice", ownerexpirationnotice);
			sqlCommand.Parameters.AddWithValue("@reportToUserID", reportToUserID);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@billingStreet", billingStreet);
			sqlCommand.Parameters.AddWithValue("@billingCity", billingCity);
			sqlCommand.Parameters.AddWithValue("@billingState", billingState);
			sqlCommand.Parameters.AddWithValue("@billingZip", billingZip);
			sqlCommand.Parameters.AddWithValue("@billingCountry", billingCountry);
			sqlCommand.Parameters.AddWithValue("@shippingStreet", shippingStreet);
			sqlCommand.Parameters.AddWithValue("@shippingCity", shippingCity);
			sqlCommand.Parameters.AddWithValue("@shippingState", shippingState);
			sqlCommand.Parameters.AddWithValue("@shippingZip", shippingZip);
			sqlCommand.Parameters.AddWithValue("@shippingCountry", shippingCountry);
			sqlCommand.Parameters.AddWithValue("@contractterm", contractterm);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contract_EditCustomizeVAlue(int CustomizeID, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contract_editcustomizevalue", _commonClass.openConnection())
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

		public string contract_GetContractNumber(int contractid, int companyID)
		{
			string str = "";
			SqlCommand sqlCommand = new SqlCommand("crm_contract_get_contractnumber", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contractid", contractid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			while (sqlDataReader.Read())
			{
				str = sqlDataReader["contractnumber"].ToString();
			}
			sqlDataReader.Close();
			return str;
		}

		public DataSet contract_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_contract_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}