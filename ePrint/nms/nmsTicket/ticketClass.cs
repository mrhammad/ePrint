using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsTicket
{
	public class ticketClass
	{
		public ticketClass()
		{
		}

		public void add_assignmentRule(int companyid, int ordernumber, int assignruleid, int templateid, string condition1, string condition2, string condition3, string operator1, string operator2, string operator3, string value1, string value2, string value3, string finalquery, int assigntoUserid, int createuserid, int modifyuserid, string createdate, string modifydate, int isemail, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_ticket_add_assignmentRule"
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

		public SqlDataReader dtr_Ticketreason(int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_select_ticket_reason", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			return sqlCommand.ExecuteReader();
		}

		public void edit_assignmentRule(int ticketassignrulefinalid, int companyid, int ordernumber, int assignruleid, int templateid, string condition1, string condition2, string condition3, string operator1, string operator2, string operator3, string value1, string value2, string value3, string finalquery, int assigntoUserid, int modifyuserid, string modifydate, int isemail, int isdelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_ticket_update_assignmentRule"
			};
			sqlCommand.Parameters.AddWithValue("@ticketassignrulefinalid", ticketassignrulefinalid);
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

		public SqlDataReader select_assignmentRule(int ticketassignrulefinalid, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_ticket_select_assignmentRule"
			};
			sqlCommand.Parameters.AddWithValue("@ticketassignrulefinalid", ticketassignrulefinalid);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			return sqlCommand.ExecuteReader();
		}

		public int ticket_Add(int companyId, int contactId, string ticketNumber, string ticketType, string ticketReason, string ticketStatus, string ticketPriority, string ticketOrigine, string bugNumber, string subject, string description, int isAssignTicket, int isNotification, int createUserId, int modifyUserId, string createDate, string modifiedDate, string lastViewDate, int isSample, int isDelete, int isClose, string closeDate, int ticketOwnerId, int isEscalated, string ticketAlias)
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
			sqlCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);
			sqlCommand.Parameters.AddWithValue("@ticketType", ticketType);
			sqlCommand.Parameters.AddWithValue("@ticketReason", ticketReason);
			sqlCommand.Parameters.AddWithValue("@ticketStatus", ticketStatus);
			sqlCommand.Parameters.AddWithValue("@ticketPriority", ticketPriority);
			sqlCommand.Parameters.AddWithValue("@ticketOrigine", ticketOrigine);
			sqlCommand.Parameters.AddWithValue("@bugNumber", bugNumber);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isAssignTicket", isAssignTicket);
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
			sqlCommand.Parameters.AddWithValue("@ticketOwnerId", ticketOwnerId);
			sqlCommand.Parameters.AddWithValue("@isEscalated", isEscalated);
			sqlCommand.Parameters.AddWithValue("@ticketAlias", ticketAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void ticket_AddCustomizValue(int ticketCustomizeId, int ticketId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ticketCustomizeId", ticketCustomizeId);
			sqlCommand.Parameters.AddWithValue("@ticketId", ticketId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void ticket_Close(int ticketId, int companyId, string ticketReason, string ticketStatus, string solutiontitle, string description, int modifyUserId, string modifiedDate)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_close", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ticketId", ticketId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@ticketReason", ticketReason);
			sqlCommand.Parameters.AddWithValue("@ticketStatus", ticketStatus);
			sqlCommand.Parameters.AddWithValue("@solutiontitle", solutiontitle);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void ticket_Delete(int ticketId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ticketId", ticketId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void ticket_Edit(int ticketId, int companyId, int contactId, string ticketNumber, string ticketType, string ticketReason, string ticketStatus, string ticketPriority, string ticketOrigine, string bugNumber, string subject, string description, int isAssignTicket, int isNotification, int modifyUserId, string modifiedDate, string lastViewDate, int isSample, int isDelete, int isClose, string closeDate, int ticketOwnerId, int isEscalated, string ticketAlias)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ticketId", ticketId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);
			sqlCommand.Parameters.AddWithValue("@ticketType", ticketType);
			sqlCommand.Parameters.AddWithValue("@ticketReason", ticketReason);
			sqlCommand.Parameters.AddWithValue("@ticketStatus", ticketStatus);
			sqlCommand.Parameters.AddWithValue("@ticketPriority", ticketPriority);
			sqlCommand.Parameters.AddWithValue("@ticketOrigine", ticketOrigine);
			sqlCommand.Parameters.AddWithValue("@bugNumber", bugNumber);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isAssignTicket", isAssignTicket);
			sqlCommand.Parameters.AddWithValue("@isNotification", isNotification);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isClose", isClose);
			sqlCommand.Parameters.AddWithValue("@closeDate", closeDate);
			sqlCommand.Parameters.AddWithValue("@ticketOwnerId", ticketOwnerId);
			sqlCommand.Parameters.AddWithValue("@isEscalated", isEscalated);
			sqlCommand.Parameters.AddWithValue("@ticketAlias", ticketAlias);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void ticket_EditCustomizeVAlue(int ticketCustomizeID, int ticketId, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_ticket_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@ticketCustomizeID", ticketCustomizeID);
			sqlCommand.Parameters.AddWithValue("@ticketId", ticketId);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet ticket_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_ticket_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}

		public void ticketrule_delete(int intruleid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_delete_ticket_rule"
			};
			sqlCommand.Parameters.AddWithValue("@ticketruleid", intruleid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}
	}
}