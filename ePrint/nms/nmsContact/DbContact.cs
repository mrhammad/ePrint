using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace nmsContact
{
	public class DbContact
	{
		public DbContact()
		{
		}

		public virtual int InsertContact(ContactItem items)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_add_new1", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@companyID", items.CompanyID);
			sqlCommand.Parameters.AddWithValue("@clientid", items.ClientID);
			sqlCommand.Parameters.AddWithValue("@salutation", items.Salutation);
			sqlCommand.Parameters.AddWithValue("@firstName", items.Firstname);
			sqlCommand.Parameters.AddWithValue("@lastName", items.Lastname);
			sqlCommand.Parameters.AddWithValue("@title", items.Title);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", items.LeadSourceName);
			sqlCommand.Parameters.AddWithValue("@phone1", items.Phone1);
			sqlCommand.Parameters.AddWithValue("@phone2", items.Phone2);
			sqlCommand.Parameters.AddWithValue("@PhoneHome", items.Phonehome);
			sqlCommand.Parameters.AddWithValue("@mobile", items.Mobile);
			sqlCommand.Parameters.AddWithValue("@fax", items.Fax);
			sqlCommand.Parameters.AddWithValue("@email", items.Email);
			sqlCommand.Parameters.AddWithValue("@department", items.Department);
			sqlCommand.Parameters.AddWithValue("@reportToUserID", items.ReportToUserID);
			sqlCommand.Parameters.AddWithValue("@assistant", items.Assistant);
			sqlCommand.Parameters.AddWithValue("@assistantPhone", items.Assistantphone);
			sqlCommand.Parameters.AddWithValue("@description", items.Description);
			sqlCommand.Parameters.AddWithValue("@isSample", items.IsSample);
			sqlCommand.Parameters.AddWithValue("@createUserID", items.CreateUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", items.ModifyUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", items.CreateDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", items.ModifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", items.lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isEmailOut", items.IsEmailOut);
			sqlCommand.Parameters.AddWithValue("@isDelete", items.IsDelete);
			sqlCommand.Parameters.AddWithValue("@mailingStreet", items.MalingStreet);
			sqlCommand.Parameters.AddWithValue("@mailingCity", items.MailingCity);
			sqlCommand.Parameters.AddWithValue("@mailingState", items.MailingState);
			sqlCommand.Parameters.AddWithValue("@mailingZip", items.MailingZip);
			sqlCommand.Parameters.AddWithValue("@mailingCountry", items.MailingCountry);
			sqlCommand.Parameters.AddWithValue("@otherStreet", items.OtherStreet);
			sqlCommand.Parameters.AddWithValue("@otherCity", items.OtherCity);
			sqlCommand.Parameters.AddWithValue("@otherState", items.OtherState);
			sqlCommand.Parameters.AddWithValue("@otherZip", items.OtherZip);
			sqlCommand.Parameters.AddWithValue("@otherCountry", items.OtherCountry);
			sqlCommand.Parameters.AddWithValue("@contactalias", items.Contactalias);
			sqlCommand.Parameters.AddWithValue("assigntouserid", items.Assigntouserid);
			sqlCommand.Parameters.AddWithValue("assigntogroupid", items.Assigntogroupid);
			sqlCommand.Parameters.AddWithValue("btassigned", items.Btassigned);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public virtual void test(int a, int b, int c)
		{
			SqlCommand sqlCommand = new SqlCommand("crm_contact_add_new1", (new commonClass()).openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@contactId", a);
			sqlCommand.Parameters.AddWithValue("@companyID", b);
			sqlCommand.Parameters.AddWithValue("@clientid", c);
		}
	}
}