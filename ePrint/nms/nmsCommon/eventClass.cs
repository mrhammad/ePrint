using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsCommon
{
	public class eventClass
	{
		public eventClass()
		{
		}

		public SqlDataReader dtrName_BasedOnId(int Id, string tasktype, int companyid)
		{
			SqlDataReader sqlDataReader;
			try
			{
				SqlCommand sqlCommand = new SqlCommand("crm_common_taskEvent_type", (new commonClass()).openConnection())
				{
					CommandType = CommandType.StoredProcedure
				};
				sqlCommand.Parameters.AddWithValue("@tasktypeid", Id);
				sqlCommand.Parameters.AddWithValue("@tasktype", tasktype);
				sqlCommand.Parameters.AddWithValue("@companyID", companyid);
				sqlDataReader = sqlCommand.ExecuteReader();
			}
			catch
			{
				throw new Exception("The method or operation is not implemented.");
			}
			return sqlDataReader;
		}

		public void event_Add(int companyid, string subject, string location, int contactId, string eventDate, string eventType, int eventTypeId, string eventTime, string duration, int isAllDay, string comment, int isSample, string contactType, int assignToUserId, int createUserId, int modifyUserId, string createDate, string modifiedDate, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_event_add"
			};
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@location", location);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@eventDate", eventDate);
			sqlCommand.Parameters.AddWithValue("@eventType", eventType);
			sqlCommand.Parameters.AddWithValue("@eventTypeId", eventTypeId);
			sqlCommand.Parameters.AddWithValue("@eventTime", eventTime);
			sqlCommand.Parameters.AddWithValue("@duration", duration);
			sqlCommand.Parameters.AddWithValue("@isallDay", isAllDay);
			sqlCommand.Parameters.AddWithValue("@comment", comment);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@createUserId", createUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void event_Delete(int eventId, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_event_delete"
			};
			sqlCommand.Parameters.AddWithValue("@eventId", eventId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void event_Edit(int eventId, int companyid, string subject, string location, int contactId, string eventDate, string eventType, int eventTypeId, string eventTime, string duration, int isAllDay, string comment, int isSample, string contactType, int assignToUserId, int modifyUserId, string modifiedDate, int isDelete)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_event_edit"
			};
			sqlCommand.Parameters.AddWithValue("@eventId", eventId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyid);
			sqlCommand.Parameters.AddWithValue("@subject", subject);
			sqlCommand.Parameters.AddWithValue("@location", location);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@eventDate", eventDate);
			sqlCommand.Parameters.AddWithValue("@eventType", eventType);
			sqlCommand.Parameters.AddWithValue("@eventTypeId", eventTypeId);
			sqlCommand.Parameters.AddWithValue("@eventTime", eventTime);
			sqlCommand.Parameters.AddWithValue("@duration", duration);
			sqlCommand.Parameters.AddWithValue("@isallDay", isAllDay);
			sqlCommand.Parameters.AddWithValue("@comment", comment);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@contactType", contactType);
			sqlCommand.Parameters.AddWithValue("@assignToUserId", assignToUserId);
			sqlCommand.Parameters.AddWithValue("@modifyUserId", modifyUserId);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public SqlDataReader event_Select_deltail(int eventId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_event_detail_new"
			};
			sqlCommand.Parameters.AddWithValue("@eventId", eventId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			return sqlCommand.ExecuteReader();
		}

		public SqlDataReader event_Select_Reader(int eventId, int companyId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand()
			{
				Connection = _commonClass.openConnection(),
				CommandType = CommandType.StoredProcedure,
				CommandText = "crm_common_event_select"
			};
			sqlCommand.Parameters.AddWithValue("@eventId", eventId);
			sqlCommand.Parameters.AddWithValue("@companyid", companyId);
			return sqlCommand.ExecuteReader();
		}
	}
}