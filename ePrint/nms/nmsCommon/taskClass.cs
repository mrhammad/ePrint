using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class taskClass
	{
		public taskClass()
		{
		}

		public void Add_task(string pg, int companyid, string subject, string taskTitle, string taskStatus, string dueDate, string tasktime, int contactId, string priority, string type, long typeId, string description, int isSample, int assignToUserId, int createUserId, int modifyUserId, string createDate, string modifiedDate, string contactType, int isDelete, long appointmentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_scheduler_task_add"
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@taskTitle", taskTitle);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatus);
			sqlCommand.Parameters.AddWithValue("@dueDate", dueDate);
			sqlCommand.Parameters.AddWithValue("@taskTime", tasktime);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@priority", priority);
			sqlCommand.Parameters.AddWithValue("@type", type);
			sqlCommand.Parameters.AddWithValue("@typeId", typeId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@AppointmentID", appointmentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataTable BindScheduler(int UserId, int CompanyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand();
			DataTable dataTable = new DataTable();
			sqlCommand.Connection = _commonClass.openConnection();
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.CommandText = "pc_dashboard_schedulerbind";
			sqlCommand.Parameters.AddWithValue("@UserId", UserId);
			sqlCommand.Parameters.AddWithValue("@CompanyId", CompanyId);
			using (IDataReader dataReader = sqlCommand.ExecuteReader())
			{
				dataTable.Load(dataReader);
			}
			return dataTable;
		}

		public SqlDataReader dtrTaskStatus(int companyId)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_common_taskstatus_select", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			return sqlCommand.ExecuteReader();
		}

		public void scheduler_task_Delete(string pg, int taskId, int companyid, long appointmentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "pc_dashboard_scheduler_task_delete"
			};
			sqlCommand.Parameters.AddWithValue("@pg", "ss");
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@AppointmentID", appointmentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void scheduler_task_Edit(int taskId, int companyid, string subject, string taskTitle, string taskStatus, string dueDate, string taskTime, int contactId, string priority, string type, long typeId, string description, int isSample, int assignToUserId, int modifyUserId, string modifiedDate, string contactType, int isDelete, long appointmentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "pc_dashboard_scheduler_task_edit"
			};
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@taskTitle", taskTitle);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatus);
			sqlCommand.Parameters.AddWithValue("@dueDate", dueDate);
			sqlCommand.Parameters.AddWithValue("@taskTime", taskTime);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@priority", priority);
			sqlCommand.Parameters.AddWithValue("@type", type);
			sqlCommand.Parameters.AddWithValue("@typeId", typeId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@AppointmentID", appointmentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader sp_task_appointmentID(string Subject)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand();
			DataTable dataTable = new DataTable();
			sqlCommand.Connection = _commonClass.openConnection();
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.CommandText = "sp_task_appId_insert";
			sqlCommand.Parameters.AddWithValue("@subject", Subject);
			return sqlCommand.ExecuteReader();
		}

		public void task_Add(string pg, int companyid, string subject, string taskTitle, string taskStatus, string dueDate, string tasktime, int contactId, string priority, string type, long typeId, string description, int isSample, int assignToUserId, int createUserId, int modifyUserId, string createDate, string modifiedDate, string contactType, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_task_add"
			};
			sqlCommand.Parameters.AddWithValue("@pg", pg);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@taskTitle", taskTitle);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatus);
			sqlCommand.Parameters.AddWithValue("@dueDate", dueDate);
			sqlCommand.Parameters.AddWithValue("@taskTime", tasktime);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@priority", priority);
			sqlCommand.Parameters.AddWithValue("@type", type);
			sqlCommand.Parameters.AddWithValue("@typeId", typeId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void task_appointment_add(string Subject, string Description, DateTime StartTime, DateTime EndTime, int UserId, int CompanyId, string RecurrenceRule, string RecurrenceParentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "pc_dashboard_scheduler_app"
			};
			sqlCommand.Parameters.AddWithValue("@Subject", Subject);
			sqlCommand.Parameters.AddWithValue("@Description", Description);
			sqlCommand.Parameters.AddWithValue("@StartTime", StartTime);
			sqlCommand.Parameters.AddWithValue("@EndTime", EndTime);
			sqlCommand.Parameters.AddWithValue("@UserId", UserId);
			sqlCommand.Parameters.AddWithValue("@CompanyId", CompanyId);
			sqlCommand.Parameters.AddWithValue("@RecurrenceRule", RecurrenceRule);
			sqlCommand.Parameters.AddWithValue("@RecurrenceParentKey", RecurrenceParentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void task_appointment_delete(long AppointmentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "pc_dashboard_scheduler_delete"
			};
			sqlCommand.Parameters.AddWithValue("@AppointmentID", AppointmentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void task_appointment_update(string Subject, string Description, DateTime StartTime, DateTime EndTime, long UserId, long CompanyId, string RecurrenceRule, string RecurrenceParentID, long AppointmentID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "pc_dashboard_scheduler_update"
			};
			sqlCommand.Parameters.AddWithValue("@Subject", Subject);
			sqlCommand.Parameters.AddWithValue("@Description", Description);
			sqlCommand.Parameters.AddWithValue("@StartTime", StartTime);
			sqlCommand.Parameters.AddWithValue("@EndTime", EndTime);
			sqlCommand.Parameters.AddWithValue("@UserId", UserId);
			sqlCommand.Parameters.AddWithValue("@CompanyId", CompanyId);
			sqlCommand.Parameters.AddWithValue("@RecurrenceRule", RecurrenceRule);
			sqlCommand.Parameters.AddWithValue("@RecurrenceParentKey", RecurrenceParentID);
			sqlCommand.Parameters.AddWithValue("@AppointmentID", AppointmentID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void task_Delete(string pg, int taskId, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_task_delete"
			};
			sqlCommand.Parameters.AddWithValue("@pg", "ss");
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void task_Edit(int taskId, int companyid, string subject, string taskTitle, string taskStatus, string dueDate, string taskTime, int contactId, string priority, string type, long typeId, string description, int isSample, int assignToUserId, int modifyUserId, string modifiedDate, string contactType, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_task_edit"
			};
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@taskTitle", taskTitle);
			sqlCommand.Parameters.AddWithValue("@taskStatus", taskStatus);
			sqlCommand.Parameters.AddWithValue("@dueDate", dueDate);
			sqlCommand.Parameters.AddWithValue("@taskTime", taskTime);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@priority", priority);
			sqlCommand.Parameters.AddWithValue("@type", type);
			sqlCommand.Parameters.AddWithValue("@typeId", typeId);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader task_Select_detail(int taskId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_task_detail_new"
			};
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader task_Select_Reader(int taskId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_task_select_new"
			};
			sqlCommand.Parameters.AddWithValue("@taskId", taskId);
			sqlCommand.Parameters.AddWithValue("@companyId", companyId);
			return sqlCommand.ExecuteReader();
		}
	}
}