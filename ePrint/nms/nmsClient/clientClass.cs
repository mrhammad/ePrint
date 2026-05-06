using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsClient
{
	public class clientClass
	{
		public clientClass()
		{
		}

		public int client_Add(int companyID, int isSample, string clientName, string rating, string clientSite, int intLevel, string phone, string mobile, string fax, string clientNo, string webSite, string clientTypeName, string tickerSymbol, string industryName, string ownerShipType, decimal annualRevenue, int noOfEmployee, string siccode, string description, string createDate, string modifiedDate, string lastViewDate, int modifyUserID, int createUserID, int isDelete, string billingstreet, string billingcity, string billingstate, string billingzip, string billingcountry, string shippingstreet, string shippingcity, string shippingstate, string shippingzip, string shippingcountry, string clientalias, string parentclient, string companytype)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_client_add"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@clientName", clientName);
			sqlCommand.Parameters.AddWithValue("@rating", rating);
			sqlCommand.Parameters.AddWithValue("@clientSite", clientSite);
			sqlCommand.Parameters.AddWithValue("@intLevel", intLevel);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@clientNo", clientNo);
			sqlCommand.Parameters.AddWithValue("@webSite", webSite);
			sqlCommand.Parameters.AddWithValue("@clientTypeName", clientTypeName);
			sqlCommand.Parameters.AddWithValue("@tickerSymbol", tickerSymbol);
			sqlCommand.Parameters.AddWithValue("@industryName", industryName);
			sqlCommand.Parameters.AddWithValue("@ownerShipType", ownerShipType);
			sqlCommand.Parameters.AddWithValue("@annualRevenue", annualRevenue);
			sqlCommand.Parameters.AddWithValue("@noOfEmployee", noOfEmployee);
			sqlCommand.Parameters.AddWithValue("@siccode", siccode);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@billingstreet", billingstreet);
			sqlCommand.Parameters.AddWithValue("@billingcity", billingcity);
			sqlCommand.Parameters.AddWithValue("@billingstate", billingstate);
			sqlCommand.Parameters.AddWithValue("@billingzip", billingzip);
			sqlCommand.Parameters.AddWithValue("@billingcountry", billingcountry);
			sqlCommand.Parameters.AddWithValue("@shippingstreet", shippingstreet);
			sqlCommand.Parameters.AddWithValue("@shippingcity", shippingcity);
			sqlCommand.Parameters.AddWithValue("@shippingstate", shippingstate);
			sqlCommand.Parameters.AddWithValue("@shippingzip", shippingzip);
			sqlCommand.Parameters.AddWithValue("@shippingcountry", shippingcountry);
			sqlCommand.Parameters.AddWithValue("@clientalias", clientalias);
			sqlCommand.Parameters.AddWithValue("@parentclient", parentclient);
			sqlCommand.Parameters.AddWithValue("@companytype", companytype);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void client_AddCustomizValue(int clientCustomizeId, int clientId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_client_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@clientCustomizeId", clientCustomizeId);
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@CompanyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public bool client_ChkClientNameExist(string clientName, int companyiD)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_client_checkclientname", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@clientName", clientName);
			sqlCommand.Parameters.AddWithValue("@companyID", companyiD);
			sqlCommand.ExecuteNonQuery();
			int value = (int)sqlCommand.Parameters["ReturnValue"].Value;
			_commonClass.closeConnection();
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		public void client_Delete(int clientId)
		{
			commonClass _commonClass = new commonClass();
			string str = string.Concat("crm_client_delete ", clientId);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void client_EditCustomizeVAlue(int clientCustomizeID, int clientId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_client_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@clientCustomizeID", clientCustomizeID);
			sqlCommand.Parameters.AddWithValue("@clientId", clientId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void client_MassDelete(int clientId)
		{
			commonClass _commonClass = new commonClass();
			string str = string.Concat("crm_client_massdelete ", clientId);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void client_Update(int clientid, int companyID, int isSample, string clientName, string rating, string clientSite, int intLevel, string phone, string mobile, string fax, string clientNo, string webSite, string clientTypeName, string tickerSymbol, string industryName, string ownerShipType, decimal annualRevenue, int noOfEmployee, string siccode, string description, string createDate, string modifiedDate, string lastViewDate, int modifyUserID, int createUserID, int isDelete, string billingstreet, string billingcity, string billingstate, string billingzip, string billingcountry, string shippingstreet, string shippingcity, string shippingstate, string shippingzip, string shippingcountry, string clientalias, string parentclient)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_client_edit"
			};
			sqlCommand.Parameters.AddWithValue("@clientid", clientid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@clientName", clientName);
			sqlCommand.Parameters.AddWithValue("@rating", rating);
			sqlCommand.Parameters.AddWithValue("@clientSite", clientSite);
			sqlCommand.Parameters.AddWithValue("@intLevel", intLevel);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@clientNo", clientNo);
			sqlCommand.Parameters.AddWithValue("@webSite", webSite);
			sqlCommand.Parameters.AddWithValue("@clientTypeName", clientTypeName);
			sqlCommand.Parameters.AddWithValue("@tickerSymbol", tickerSymbol);
			sqlCommand.Parameters.AddWithValue("@industryName", industryName);
			sqlCommand.Parameters.AddWithValue("@ownerShipType", ownerShipType);
			sqlCommand.Parameters.AddWithValue("@annualRevenue", annualRevenue);
			sqlCommand.Parameters.AddWithValue("@noOfEmployee", noOfEmployee);
			sqlCommand.Parameters.AddWithValue("@siccode", siccode);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@billingstreet", billingstreet);
			sqlCommand.Parameters.AddWithValue("@billingcity", billingcity);
			sqlCommand.Parameters.AddWithValue("@billingstate", billingstate);
			sqlCommand.Parameters.AddWithValue("@billingzip", billingzip);
			sqlCommand.Parameters.AddWithValue("@billingcountry", billingcountry);
			sqlCommand.Parameters.AddWithValue("@shippingstreet", shippingstreet);
			sqlCommand.Parameters.AddWithValue("@shippingcity", shippingcity);
			sqlCommand.Parameters.AddWithValue("@shippingstate", shippingstate);
			sqlCommand.Parameters.AddWithValue("@shippingzip", shippingzip);
			sqlCommand.Parameters.AddWithValue("@shippingcountry", shippingcountry);
			sqlCommand.Parameters.AddWithValue("@clientalias", clientalias);
			sqlCommand.Parameters.AddWithValue("@parentclient", parentclient);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet client_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_client_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}