using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsLead
{
	public class leadClass
	{
		public leadClass()
		{
		}

		public bool chkLeadViewNameExist(string viewName, int companyiD)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_checkLeadViewname", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@viewName", viewName);
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

		public int create_leadview(int companyid, string viewname, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9, string field10, string field11, string condition1, string condition2, string condition3, string condition4, string condition5, string operator1, string operator2, string operator3, string operator4, string operator5, string value1, string value2, string value3, string value4, string value5, int isdelete, int createuserid, int modifyuserid, string createdate, string modifydate, int isallunconvertedlead, int ismyunconvertedlead, int ishide, int isDefault, string SortedField, string sortDirection)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_create_leadview"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@viewname", viewname);
			sqlCommand.Parameters.AddWithValue("@field1", field1);
			sqlCommand.Parameters.AddWithValue("@field2", field2);
			sqlCommand.Parameters.AddWithValue("@field3", field3);
			sqlCommand.Parameters.AddWithValue("@field4", field4);
			sqlCommand.Parameters.AddWithValue("@field5", field5);
			sqlCommand.Parameters.AddWithValue("@field6", field6);
			sqlCommand.Parameters.AddWithValue("@field7", field7);
			sqlCommand.Parameters.AddWithValue("@field8", field8);
			sqlCommand.Parameters.AddWithValue("@field9", field9);
			sqlCommand.Parameters.AddWithValue("@field10", field10);
			sqlCommand.Parameters.AddWithValue("@field11", field11);
			sqlCommand.Parameters.AddWithValue("@condition1", condition1);
			sqlCommand.Parameters.AddWithValue("@condition2", condition2);
			sqlCommand.Parameters.AddWithValue("@condition3", condition3);
			sqlCommand.Parameters.AddWithValue("@condition4", condition4);
			sqlCommand.Parameters.AddWithValue("@condition5", condition5);
			sqlCommand.Parameters.AddWithValue("@operator1", operator1);
			sqlCommand.Parameters.AddWithValue("@operator2", operator2);
			sqlCommand.Parameters.AddWithValue("@operator3", operator3);
			sqlCommand.Parameters.AddWithValue("@operator4", operator4);
			sqlCommand.Parameters.AddWithValue("@operator5", operator5);
			sqlCommand.Parameters.AddWithValue("@value1", value1);
			sqlCommand.Parameters.AddWithValue("@value2", value2);
			sqlCommand.Parameters.AddWithValue("@value3", value3);
			sqlCommand.Parameters.AddWithValue("@value4", value4);
			sqlCommand.Parameters.AddWithValue("@value5", value5);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
			sqlCommand.Parameters.AddWithValue("@isallunconvertedlead", isallunconvertedlead);
			sqlCommand.Parameters.AddWithValue("@ismyunconvertedlead", ismyunconvertedlead);
			sqlCommand.Parameters.AddWithValue("@ishide", ishide);
			sqlCommand.Parameters.AddWithValue("@isDefault", isDefault);
			sqlCommand.Parameters.AddWithValue("@SortedField", SortedField);
			sqlCommand.Parameters.AddWithValue("@sortDirection", sortDirection);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void deleteLeadView(int leadviewvalueID, int companyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_deleteleadview", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@leadviewvalueID", leadviewvalueID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void edit_leadview(int leadViewValueID, int companyid, string viewname, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9, string field10, string field11, string condition1, string condition2, string condition3, string condition4, string condition5, string operator1, string operator2, string operator3, string operator4, string operator5, string value1, string value2, string value3, string value4, string value5, int isdelete, int createuserid, int modifyuserid, string createdate, string modifydate, int isallunconvertedlead, int ismyunconvertedlead, int ishide, int isdefault, string sortfield, string sortDirection)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_edit_leadview"
			};
			sqlCommand.Parameters.AddWithValue("@leadViewValueID", leadViewValueID);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@viewname", viewname);
			sqlCommand.Parameters.AddWithValue("@field1", field1);
			sqlCommand.Parameters.AddWithValue("@field2", field2);
			sqlCommand.Parameters.AddWithValue("@field3", field3);
			sqlCommand.Parameters.AddWithValue("@field4", field4);
			sqlCommand.Parameters.AddWithValue("@field5", field5);
			sqlCommand.Parameters.AddWithValue("@field6", field6);
			sqlCommand.Parameters.AddWithValue("@field7", field7);
			sqlCommand.Parameters.AddWithValue("@field8", field8);
			sqlCommand.Parameters.AddWithValue("@field9", field9);
			sqlCommand.Parameters.AddWithValue("@field10", field10);
			sqlCommand.Parameters.AddWithValue("@field11", field11);
			sqlCommand.Parameters.AddWithValue("@condition1", condition1);
			sqlCommand.Parameters.AddWithValue("@condition2", condition2);
			sqlCommand.Parameters.AddWithValue("@condition3", condition3);
			sqlCommand.Parameters.AddWithValue("@condition4", condition4);
			sqlCommand.Parameters.AddWithValue("@condition5", condition5);
			sqlCommand.Parameters.AddWithValue("@operator1", operator1);
			sqlCommand.Parameters.AddWithValue("@operator2", operator2);
			sqlCommand.Parameters.AddWithValue("@operator3", operator3);
			sqlCommand.Parameters.AddWithValue("@operator4", operator4);
			sqlCommand.Parameters.AddWithValue("@operator5", operator5);
			sqlCommand.Parameters.AddWithValue("@value1", value1);
			sqlCommand.Parameters.AddWithValue("@value2", value2);
			sqlCommand.Parameters.AddWithValue("@value3", value3);
			sqlCommand.Parameters.AddWithValue("@value4", value4);
			sqlCommand.Parameters.AddWithValue("@value5", value5);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
			sqlCommand.Parameters.AddWithValue("@isallunconvertedlead", isallunconvertedlead);
			sqlCommand.Parameters.AddWithValue("@ismyunconvertedlead", ismyunconvertedlead);
			sqlCommand.Parameters.AddWithValue("@ishide", ishide);
			sqlCommand.Parameters.AddWithValue("@isdefault", isdefault);
			sqlCommand.Parameters.AddWithValue("@sortfield", sortfield);
			sqlCommand.Parameters.AddWithValue("@sortDirection", sortDirection);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int lead_Add(int companyid, string salutation, string firstName, string lastName, string companyName, string title, string leadSourceName, string industryName, decimal annualRevenue, int noOfEmployee, string phone, string mobile, string fax, string email, string website, string leadStatusName, string rating, int isEmailOut, string Description, string createDate, string modifiedDate, string lastViewDate, int createUserID, int modifyUserID, int assignToUserID, int isConverted, string convertDate, int campaignID, int isRead, int isDelete, string street, string city, string state, string zip, string country, int assigntogroupid, int btassigned, string leadalias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@salutation", salutation);
			sqlCommand.Parameters.AddWithValue("@firstName", firstName);
			sqlCommand.Parameters.AddWithValue("@lastName", lastName);
			sqlCommand.Parameters.AddWithValue("@companyName", companyName);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@industryName", industryName);
			sqlCommand.Parameters.AddWithValue("@annualRevenue", annualRevenue);
			sqlCommand.Parameters.AddWithValue("@noOfEmployee", noOfEmployee);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@website", website);
			sqlCommand.Parameters.AddWithValue("@leadStatusName", leadStatusName);
			sqlCommand.Parameters.AddWithValue("@rating", rating);
			sqlCommand.Parameters.AddWithValue("@isEmailOut", isEmailOut);
			sqlCommand.Parameters.AddWithValue("@Description", Description);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@assignToUserID", assignToUserID);
			sqlCommand.Parameters.AddWithValue("@isConverted", isConverted);
			sqlCommand.Parameters.AddWithValue("@convertDate", convertDate);
			sqlCommand.Parameters.AddWithValue("@campaignID", campaignID);
			sqlCommand.Parameters.AddWithValue("@isRead", isRead);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@street", street);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@state", state);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@assigntogroupid", assigntogroupid);
			sqlCommand.Parameters.AddWithValue("@btassigned", btassigned);
			sqlCommand.Parameters.AddWithValue("@leadalias", leadalias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public int lead_convert(int leadid, int createuserid, int companyid, int userid, string clientname, string opportunityname, int createopportunity, string convertedstatus, int task_assigntoid, string task_subject, string task_status, string task_priority, string task_duedate, string task_time, string comments)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_convert", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@leadid", leadid);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@userid", userid);
			sqlCommand.Parameters.AddWithValue("@clientname", clientname);
			sqlCommand.Parameters.AddWithValue("@opportunityname", opportunityname);
			sqlCommand.Parameters.AddWithValue("@createopportunity", createopportunity);
			sqlCommand.Parameters.AddWithValue("@convertedstatus", convertedstatus);
			sqlCommand.Parameters.AddWithValue("@task_assigntoid", task_assigntoid);
			sqlCommand.Parameters.AddWithValue("@task_subject", task_subject);
			sqlCommand.Parameters.AddWithValue("@task_status", task_status);
			sqlCommand.Parameters.AddWithValue("@task_priority", task_priority);
			sqlCommand.Parameters.AddWithValue("@task_duedate", task_duedate);
			sqlCommand.Parameters.AddWithValue("@task_time", task_time);
			sqlCommand.Parameters.AddWithValue("@comments", comments);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void lead_customize_add(int leadCustomizeID, int leadId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_customize_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@leadCustomizeID", leadCustomizeID);
			sqlCommand.Parameters.AddWithValue("@leadId", leadId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void lead_customize_Edit(int leadCustomizeID, int leadId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_customize_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@leadCustomizeID", leadCustomizeID);
			sqlCommand.Parameters.AddWithValue("@leadId", leadId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void lead_delete(int leadID)
		{
			commonClass _commonClass = new commonClass();
			string str = string.Concat("crm_lead_delete ", leadID);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader lead_detail(int leadID, int userID)
		{
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_lead_detail ", leadID, " , ", userID };
			string str = string.Concat(objArray);
			return (new SqlCommand(str, _commonClass.openConnection())).ExecuteReader();
		}

		public void lead_Edit(int leadID, int companyid, string salutation, string firstName, string lastName, string companyName, string title, string leadSourceName, string industryName, decimal annualRevenue, int noOfEmployee, string phone, string mobile, string fax, string email, string website, string leadStatusName, string rating, int isEmailOut, string Description, string modifiedDate, int modifyUserID, int assignToUserID, int campaignID, string street, string city, string state, string zip, string country, string leadalias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@leadID", leadID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.Parameters.AddWithValue("@salutation", salutation);
			sqlCommand.Parameters.AddWithValue("@firstName", firstName);
			sqlCommand.Parameters.AddWithValue("@lastName", lastName);
			sqlCommand.Parameters.AddWithValue("@companyName", companyName);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@industryName", industryName);
			sqlCommand.Parameters.AddWithValue("@annualRevenue", annualRevenue);
			sqlCommand.Parameters.AddWithValue("@noOfEmployee", noOfEmployee);
			sqlCommand.Parameters.AddWithValue("@phone", phone);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@website", website);
			sqlCommand.Parameters.AddWithValue("@leadStatusName", leadStatusName);
			sqlCommand.Parameters.AddWithValue("@rating", rating);
			sqlCommand.Parameters.AddWithValue("@isEmailOut", isEmailOut);
			sqlCommand.Parameters.AddWithValue("@Description", Description);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@assignToUserID", assignToUserID);
			sqlCommand.Parameters.AddWithValue("@campaignID", campaignID);
			sqlCommand.Parameters.AddWithValue("@street", street);
			sqlCommand.Parameters.AddWithValue("@city", city);
			sqlCommand.Parameters.AddWithValue("@state", state);
			sqlCommand.Parameters.AddWithValue("@zip", zip);
			sqlCommand.Parameters.AddWithValue("@country", country);
			sqlCommand.Parameters.AddWithValue("@leadalias", leadalias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int lead_IsConverted(int leadid, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_lead_IsConverted", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@leadid", leadid);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public DataSet lead_leadview(int leadviewvalueID, int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_lead_leadview ", leadviewvalueID, ",", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public DataSet lead_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_lead_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}