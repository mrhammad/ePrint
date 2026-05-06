using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsAsset
{
	public class assetClass
	{
		public assetClass()
		{
		}

		public int asset_Add(string assetname, string assetalias, int companyID, int productID, int clientID, int contactID, int competitorasset, string serialnumber, string assetstatus, decimal price, int quantity, string description, string createDate, string modifiedDate, string lastViewDate, int createUserId, int modifyuserId, string purchasedate, string installdate, string usageEndDate, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_asset_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@assetname", assetname);
			sqlCommand.Parameters.AddWithValue("@assetalias", assetalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@clientID", clientID);
			sqlCommand.Parameters.AddWithValue("@contactID", contactID);
			sqlCommand.Parameters.AddWithValue("@competitorasset", competitorasset);
			sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
			sqlCommand.Parameters.AddWithValue("@assetstatus", assetstatus);
			sqlCommand.Parameters.AddWithValue("@price", price);
			sqlCommand.Parameters.AddWithValue("@quantity", quantity);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyuserId", modifyuserId);
			sqlCommand.Parameters.AddWithValue("@purchasedate", purchasedate);
			sqlCommand.Parameters.AddWithValue("@installdate", installdate);
			sqlCommand.Parameters.AddWithValue("@usageEndDate", usageEndDate);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void asset_AddCustomizValue(int CustomizeId, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_asset_AddCustomizeValue", _commonClass.openConnection())
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

		public void asset_Delete(int productId)
		{
			commonClass _commonClass = new commonClass();
			string str = string.Concat("crm_asset_delete ", productId);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void asset_Edit(int assetID, string assetname, string assetalias, int companyID, int productID, int clientID, int contactID, int competitorasset, string serialnumber, string assetstatus, decimal price, int quantity, string description, string modifiedDate, string lastViewDate, int modifyuserId, string purchasedate, string installdate, string usageEndDate, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_asset_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@assetid", assetID);
			sqlCommand.Parameters.AddWithValue("@assetname", assetname);
			sqlCommand.Parameters.AddWithValue("@assetalias", assetalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@clientID", clientID);
			sqlCommand.Parameters.AddWithValue("@contactID", contactID);
			sqlCommand.Parameters.AddWithValue("@competitorasset", competitorasset);
			sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
			sqlCommand.Parameters.AddWithValue("@assetstatus", assetstatus);
			sqlCommand.Parameters.AddWithValue("@price", price);
			sqlCommand.Parameters.AddWithValue("@quantity", quantity);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@modifyuserId", modifyuserId);
			sqlCommand.Parameters.AddWithValue("@purchasedate", purchasedate);
			sqlCommand.Parameters.AddWithValue("@installdate", installdate);
			sqlCommand.Parameters.AddWithValue("@usageEndDate", usageEndDate);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void asset_EditCustomizeVAlue(int CustomizeID, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_asset_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
			sqlCommand.Parameters.AddWithValue("@Id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}
	}
}