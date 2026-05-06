using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace nmsCampaign
{
	public class campaignClass
	{
		public campaignClass()
		{
		}

		public void assigncampaign(int campaignid, int id, int userorgroup)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_assign", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignid", campaignid);
			sqlCommand.Parameters.AddWithValue("@id", id);
			sqlCommand.Parameters.AddWithValue("@userorgroup", userorgroup);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void BindAddressList(DropDownList ddl, int CompanyID, int userID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("sp_AddressList_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@CompanyID", CompanyID);
			sqlCommand.Parameters.Add("@UserID", userID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			ddl.DataSource = sqlDataReader;
			ddl.DataTextField = "AddressListName";
			ddl.DataValueField = "AddressListID";
			ddl.DataBind();
			sqlDataReader.Close();
			_commonClass.closeConnection();
			if (ddl.Items.Count > 0)
			{
				ddl.Items.Insert(0, "Please select");
				ddl.Items[0].Text = "Please select";
				ddl.Items[0].Value = "0";
				return;
			}
			ddl.Items.Insert(0, "No AddressList Found");
			ddl.Items[0].Text = "No AddressList Found";
			ddl.Items[0].Value = "0";
		}

		public int campaign_Add(int companyId, string campaignAlias, string campaignName, string campaignStatus, string campaignType, string startdate, string enddate, decimal expectedRevenue, decimal expectedRevenuePerCent, decimal budgetedCost, decimal actualCost, decimal expectedResponse, int noOfIndividualsTargeted, string description, int createUserId, int modifyUserId, string createDate, string modifiedDate, string lastViewDate, int isActive, int isSample, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@campaignAlias", campaignAlias);
			sqlCommand.Parameters.AddWithValue("@campaignName", campaignName);
			sqlCommand.Parameters.AddWithValue("@campaignStatus", campaignStatus);
			sqlCommand.Parameters.AddWithValue("@campaignType", campaignType);
			sqlCommand.Parameters.AddWithValue("@startdate", startdate);
			sqlCommand.Parameters.AddWithValue("@enddate", enddate);
			sqlCommand.Parameters.AddWithValue("@expectedRevenue", expectedRevenue);
			sqlCommand.Parameters.AddWithValue("@expectedRevenuePerCent", expectedRevenuePerCent);
			sqlCommand.Parameters.AddWithValue("@budgetedCost", budgetedCost);
			sqlCommand.Parameters.AddWithValue("@actualCost", actualCost);
			sqlCommand.Parameters.AddWithValue("@expectedResponse", expectedResponse);
			sqlCommand.Parameters.AddWithValue("@noOfIndividualsTargeted", noOfIndividualsTargeted);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isActive", isActive);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void campaign_AddCustomizValue(int campaignCustomizeId, int campaignId, string customizedValue, int CompanyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_addcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignCustomizeId", campaignCustomizeId);
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.Add("@companyID", CompanyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void campaign_Delete(int campaignId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void campaign_Edit(int campaignId, int companyId, string campaignAlias, string campaignName, string campaignStatus, string campaignType, string startdate, string enddate, decimal expectedRevenue, decimal expectedRevenuePerCent, decimal budgetedCost, decimal actualCost, decimal expectedResponse, int noOfIndividualsTargeted, string description, int modifyUserId, string modifiedDate, string lastViewDate, int isActive, int isSample, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@campaignAlias", campaignAlias);
			sqlCommand.Parameters.AddWithValue("@campaignName", campaignName);
			sqlCommand.Parameters.AddWithValue("@campaignStatus", campaignStatus);
			sqlCommand.Parameters.AddWithValue("@campaignType", campaignType);
			sqlCommand.Parameters.AddWithValue("@startdate", startdate);
			sqlCommand.Parameters.AddWithValue("@enddate", enddate);
			sqlCommand.Parameters.AddWithValue("@expectedRevenue", expectedRevenue);
			sqlCommand.Parameters.AddWithValue("@expectedRevenuePerCent", expectedRevenuePerCent);
			sqlCommand.Parameters.AddWithValue("@budgetedCost", budgetedCost);
			sqlCommand.Parameters.AddWithValue("@actualCost", actualCost);
			sqlCommand.Parameters.AddWithValue("@expectedResponse", expectedResponse);
			sqlCommand.Parameters.AddWithValue("@noOfIndividualsTargeted", noOfIndividualsTargeted);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isActive", isActive);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void campaign_EditCustomizeVAlue(int campaignCustomizeID, int campaignId, string customizedValue, int CompanyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignCustomizeID", campaignCustomizeID);
			sqlCommand.Parameters.AddWithValue("@campaignId", campaignId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.Add("@companyID", CompanyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet campaign_ViewAll(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_campaign_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public int InsertAddressList(string Name, int companyID, int userID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("sp_AddressList_Add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@AddressList", Name);
			sqlCommand.Parameters.Add("@CompanyID", companyID);
			sqlCommand.Parameters.Add("@UserID", userID);
			sqlCommand.Parameters.Add("@AddressListID", SqlDbType.BigInt).Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			int num = int.Parse(sqlCommand.Parameters["@AddressListID"].Value.ToString());
			_commonClass.closeConnection();
			return num;
		}

		public void InsertAddressListValue(int AddressListID, int SectionID, string Section, int CompanyID, int UserID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("sp_AddressListvALUE_Add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.Add("@AddressListID", AddressListID);
			sqlCommand.Parameters.Add("@SectionID", SectionID);
			sqlCommand.Parameters.Add("@Section", Section);
			sqlCommand.Parameters.Add("@CompanyID", CompanyID);
			sqlCommand.Parameters.Add("@UserID", UserID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void Unassigncampaign(int campaignid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_campaign_Unassign", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@campaignid", campaignid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}
	}
}