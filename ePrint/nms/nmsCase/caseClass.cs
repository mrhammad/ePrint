using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsCase
{
	public class caseClass
	{
		public caseClass()
		{
		}

		public void add_assignmentRule(int companyid, int ordernumber, int assignruleid, int templateid, string condition1, string condition2, string condition3, string operator1, string operator2, string operator3, string value1, string value2, string value3, string finalquery, int assigntoUserid, int createuserid, int modifyuserid, string createdate, string modifydate, int isemail, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_case_add_assignmentRule"
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@ordernumber", ordernumber);
			sqlCommand.Parameters.AddWithValue("@assignruleid", assignruleid);
			sqlCommand.Parameters.AddWithValue("@templateid", templateid);
			sqlCommand.Parameters.AddWithValue("@condition1", condition1);
			sqlCommand.Parameters.AddWithValue("@condition2", condition2);
			sqlCommand.Parameters.AddWithValue("@condition3", condition3);
			sqlCommand.Parameters.AddWithValue("@operator1", operator1);
			sqlCommand.Parameters.AddWithValue("@operator2", operator2);
			sqlCommand.Parameters.AddWithValue("@operator3", operator3);
			sqlCommand.Parameters.AddWithValue("@value1", value1);
			sqlCommand.Parameters.AddWithValue("@value2", value2);
			sqlCommand.Parameters.AddWithValue("@value3", value3);
			sqlCommand.Parameters.AddWithValue("@finalquery", finalquery);
			sqlCommand.Parameters.AddWithValue("@assigntoUserid", assigntoUserid);
			sqlCommand.Parameters.AddWithValue("@createuserid", createuserid);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@createdate", createdate);
			sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
			sqlCommand.Parameters.AddWithValue("@isemail", isemail);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int case_Add(int companyId, int contactId, string caseNumber, string caseType, string caseReason, string caseStatus, string casePriority, string caseOrigine, string bugNumber, string subject, string description, int isAssignCase, int isNotification, int createUserId, int modifyUserId, string createDate, string modifiedDate, string lastViewDate, int isSample, int isDelete, int isClose, string closeDate, int caseOwnerId, int isEscalated, string caseAlias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@caseNumber", caseNumber);
			sqlCommand.Parameters.AddWithValue("@caseType", caseType);
			sqlCommand.Parameters.AddWithValue("@caseReason", caseReason);
			sqlCommand.Parameters.AddWithValue("@caseStatus", caseStatus);
			sqlCommand.Parameters.AddWithValue("@casePriority", casePriority);
			sqlCommand.Parameters.AddWithValue("@caseOrigine", caseOrigine);
			sqlCommand.Parameters.AddWithValue("@bugNumber", bugNumber);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isAssignCase", isAssignCase);
			sqlCommand.Parameters.AddWithValue("@isNotification", isNotification);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isClose", isClose);
			sqlCommand.Parameters.AddWithValue("@closeDate", closeDate);
			sqlCommand.Parameters.AddWithValue("@caseOwnerId", caseOwnerId);
			sqlCommand.Parameters.AddWithValue("@isEscalated", isEscalated);
			sqlCommand.Parameters.AddWithValue("@caseAlias", caseAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void case_AddCustomizValue(int caseCustomizeId, int caseId, string customizedValue)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_case_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@caseCustomizeId", caseCustomizeId);
			sqlCommand.Parameters.AddWithValue("@caseId", caseId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void case_Close(int caseId, int companyId, string caseReason, string caseStatus, string solutiontitle, string description, int modifyUserId, string modifiedDate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_case_close", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@caseId", caseId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@caseReason", caseReason);
			sqlCommand.Parameters.AddWithValue("@caseStatus", caseStatus);
			sqlCommand.Parameters.AddWithValue("@solutiontitle", solutiontitle);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void case_Delete(int caseId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_case_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@caseId", caseId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void case_Edit(int caseId, int companyId, int contactId, string caseNumber, string caseType, string caseReason, string caseStatus, string casePriority, string caseOrigine, string bugNumber, string subject, string description, int isAssignCase, int isNotification, int modifyUserId, string modifiedDate, string lastViewDate, int isSample, int isDelete, int isClose, string closeDate, int caseOwnerId, int isEscalated, string caseAlias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_case_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@caseId", caseId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@caseNumber", caseNumber);
			sqlCommand.Parameters.AddWithValue("@caseType", caseType);
			sqlCommand.Parameters.AddWithValue("@caseReason", caseReason);
			sqlCommand.Parameters.AddWithValue("@caseStatus", caseStatus);
			sqlCommand.Parameters.AddWithValue("@casePriority", casePriority);
			sqlCommand.Parameters.AddWithValue("@caseOrigine", caseOrigine);
			sqlCommand.Parameters.AddWithValue("@bugNumber", bugNumber);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isAssignCase", isAssignCase);
			sqlCommand.Parameters.AddWithValue("@isNotification", isNotification);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isClose", isClose);
			sqlCommand.Parameters.AddWithValue("@closeDate", closeDate);
			sqlCommand.Parameters.AddWithValue("@caseOwnerId", caseOwnerId);
			sqlCommand.Parameters.AddWithValue("@isEscalated", isEscalated);
			sqlCommand.Parameters.AddWithValue("@caseAlias", caseAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void case_EditCustomizeVAlue(int caseCustomizeID, int caseId, string customizedValue)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_case_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@caseCustomizeID", caseCustomizeID);
			sqlCommand.Parameters.AddWithValue("@caseId", caseId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet case_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_case_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public void caserule_delete(int intruleid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_delete_case_rule"
			};
			sqlCommand.Parameters.AddWithValue("@caseruleid", intruleid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader dtr_Casereason(int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_case_reason", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			return sqlCommand.ExecuteReader();
		}

		public void edit_assignmentRule(int caseassignrulefinalid, int companyid, int ordernumber, int assignruleid, int templateid, string condition1, string condition2, string condition3, string operator1, string operator2, string operator3, string value1, string value2, string value3, string finalquery, int assigntoUserid, int modifyuserid, string modifydate, int isemail, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_case_update_assignmentRule"
			};
			sqlCommand.Parameters.AddWithValue("@caseassignrulefinalid", caseassignrulefinalid);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@ordernumber", ordernumber);
			sqlCommand.Parameters.AddWithValue("@assignruleid", assignruleid);
			sqlCommand.Parameters.AddWithValue("@templateid", templateid);
			sqlCommand.Parameters.AddWithValue("@condition1", condition1);
			sqlCommand.Parameters.AddWithValue("@condition2", condition2);
			sqlCommand.Parameters.AddWithValue("@condition3", condition3);
			sqlCommand.Parameters.AddWithValue("@operator1", operator1);
			sqlCommand.Parameters.AddWithValue("@operator2", operator2);
			sqlCommand.Parameters.AddWithValue("@operator3", operator3);
			sqlCommand.Parameters.AddWithValue("@value1", value1);
			sqlCommand.Parameters.AddWithValue("@value2", value2);
			sqlCommand.Parameters.AddWithValue("@value3", value3);
			sqlCommand.Parameters.AddWithValue("@finalquery", finalquery);
			sqlCommand.Parameters.AddWithValue("@assigntoUserid", assigntoUserid);
			sqlCommand.Parameters.AddWithValue("@modifyuserid", modifyuserid);
			sqlCommand.Parameters.AddWithValue("@modifydate", modifydate);
			sqlCommand.Parameters.AddWithValue("@isemail", isemail);
			sqlCommand.Parameters.AddWithValue("@isdelete", isdelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader select_assignmentRule(int caseassignrulefinalid, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_case_select_assignmentRule"
			};
			sqlCommand.Parameters.AddWithValue("@caseassignrulefinalid", caseassignrulefinalid);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			return sqlCommand.ExecuteReader();
		}
	}
}