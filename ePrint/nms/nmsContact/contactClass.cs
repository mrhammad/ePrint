using nmsCommon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace nmsContact
{
	public class contactClass
	{
		public contactClass()
		{
		}

		public int contact_Add(string contactalias, int companyID, int clientid, string salutation, string firstName, string lastName, string title, string leadSourceName, string phone1, string phone2, string PhoneHome, string mobile, string fax, string email, string department, int reportToUserID, string assistant, string assistantPhone, string description, int isSample, int createUserID, int modifyUserID, string createDate, string modifiedDate, string lastViewDate, int isEmailOut, int isDelete, string mailingStreet, string mailingCity, string mailingState, string mailingZip, string mailingCountry, string otherStreet, string otherCity, string otherState, string otherZip, string otherCountry, bool DefaultDeliveryaddress, bool DefaultInvoiceaddress, bool DefaultContact)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@contactalias", contactalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@clientid", clientid);
			sqlCommand.Parameters.AddWithValue("@salutation", salutation);
			sqlCommand.Parameters.AddWithValue("@firstName", firstName);
			sqlCommand.Parameters.AddWithValue("@lastName", lastName);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@phone1", phone1);
			sqlCommand.Parameters.AddWithValue("@phone2", phone2);
			sqlCommand.Parameters.AddWithValue("@PhoneHome", PhoneHome);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@department", department);
			sqlCommand.Parameters.AddWithValue("@reportToUserID", reportToUserID);
			sqlCommand.Parameters.AddWithValue("@assistant", assistant);
			sqlCommand.Parameters.AddWithValue("@assistantPhone", assistantPhone);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isEmailOut", isEmailOut);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@mailingStreet", mailingStreet);
			sqlCommand.Parameters.AddWithValue("@mailingCity", mailingCity);
			sqlCommand.Parameters.AddWithValue("@mailingState", mailingState);
			sqlCommand.Parameters.AddWithValue("@mailingZip", mailingZip);
			sqlCommand.Parameters.AddWithValue("@mailingCountry", mailingCountry);
			sqlCommand.Parameters.AddWithValue("@otherStreet", otherStreet);
			sqlCommand.Parameters.AddWithValue("@otherCity", otherCity);
			sqlCommand.Parameters.AddWithValue("@otherState", otherState);
			sqlCommand.Parameters.AddWithValue("@otherZip", otherZip);
			sqlCommand.Parameters.AddWithValue("@otherCountry", otherCountry);
			sqlCommand.Parameters.AddWithValue("@DefaultDeliveryaddress", DefaultDeliveryaddress);
			sqlCommand.Parameters.AddWithValue("@DefaultInvoiceaddress", DefaultInvoiceaddress);
			sqlCommand.Parameters.AddWithValue("@DefaultContact", DefaultContact);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void contact_AddCustomizValue(int CustomizeId, int Id, string customizedValue, int companyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@customizeid", CustomizeId);
			sqlCommand.Parameters.AddWithValue("@id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedvalue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contact_Delete(int contactId)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contact_Edit(string contactalias, int contactId, int companyID, int clientid, string salutation, string firstName, string lastName, string title, string leadSourceName, string phone1, string phone2, string PhoneHome, string mobile, string fax, string email, string department, int reportToUserID, string assistant, string assistantPhone, string description, int isSample, int modifyUserID, string modifiedDate, string lastViewDate, int isEmailOut, int isDelete, string mailingStreet, string mailingCity, string mailingState, string mailingZip, string mailingCountry, string otherStreet, string otherCity, string otherState, string otherZip, string otherCountry, bool DefaultDeliveryaddress, bool DefaultInvoiceaddress, bool DefaultContact)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_update", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@contactalias", contactalias);
			sqlCommand.Parameters.AddWithValue("@contactId", contactId);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@clientid", clientid);
			sqlCommand.Parameters.AddWithValue("@salutation", salutation);
			sqlCommand.Parameters.AddWithValue("@firstName", firstName);
			sqlCommand.Parameters.AddWithValue("@lastName", lastName);
			sqlCommand.Parameters.AddWithValue("@title", title);
			sqlCommand.Parameters.AddWithValue("@leadSourceName", leadSourceName);
			sqlCommand.Parameters.AddWithValue("@phone1", phone1);
			sqlCommand.Parameters.AddWithValue("@phone2", phone2);
			sqlCommand.Parameters.AddWithValue("@PhoneHome", PhoneHome);
			sqlCommand.Parameters.AddWithValue("@mobile", mobile);
			sqlCommand.Parameters.AddWithValue("@fax", fax);
			sqlCommand.Parameters.AddWithValue("@email", email);
			sqlCommand.Parameters.AddWithValue("@department", department);
			sqlCommand.Parameters.AddWithValue("@reportToUserID", reportToUserID);
			sqlCommand.Parameters.AddWithValue("@assistant", assistant);
			sqlCommand.Parameters.AddWithValue("@assistantPhone", assistantPhone);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@isSample", isSample);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@isEmailOut", isEmailOut);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@mailingStreet", mailingStreet);
			sqlCommand.Parameters.AddWithValue("@mailingCity", mailingCity);
			sqlCommand.Parameters.AddWithValue("@mailingState", mailingState);
			sqlCommand.Parameters.AddWithValue("@mailingZip", mailingZip);
			sqlCommand.Parameters.AddWithValue("@mailingCountry", mailingCountry);
			sqlCommand.Parameters.AddWithValue("@otherStreet", otherStreet);
			sqlCommand.Parameters.AddWithValue("@otherCity", otherCity);
			sqlCommand.Parameters.AddWithValue("@otherState", otherState);
			sqlCommand.Parameters.AddWithValue("@otherZip", otherZip);
			sqlCommand.Parameters.AddWithValue("@otherCountry", otherCountry);
			sqlCommand.Parameters.AddWithValue("@DefaultDeliveryaddress", DefaultDeliveryaddress);
			sqlCommand.Parameters.AddWithValue("@DefaultInvoiceaddress", DefaultInvoiceaddress);
			sqlCommand.Parameters.AddWithValue("@DefaultContact", DefaultContact);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void contact_EditCustomizeVAlue(int CustomizeID, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_contact_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
			sqlCommand.Parameters.AddWithValue("@Id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public DataSet contact_viewall(int companyID, int userID, string sortField, string letter1)
		{
			if (letter1 == null | (letter1 == ""))
			{
				letter1 = "XX";
			}
			commonClass _commonClass = new commonClass();
			object[] objArray = new object[] { "crm_contact_viewall ", companyID, ",", userID, ",", sortField, ",", letter1 };
			string str = string.Concat(objArray);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, _commonClass.openConnection());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			_commonClass.closeConnection();
			return dataSet;
		}
	}
}