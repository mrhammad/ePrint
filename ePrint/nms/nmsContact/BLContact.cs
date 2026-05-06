using System;

namespace nmsContact
{
	public class BLContact
	{
		public BLContact()
		{
		}

		public static int InsertContact(ContactItem record)
		{
			return (new DbContact()).InsertContact(record);
		}

		public static int InsertContact(int companyID, int clientID, string salutation, string firstname, string lastname, string title, string leadSourceName, string phone1, string phone2, string phonehome, string mobile, string fax, string email, string department, int reportToUserID, string assistant, string assistantphone, string description, bool isSample, int createUserID, int modifyUserID, DateTime createDate, DateTime modifiedDate, DateTime lastViewDate, bool isEmailOut, bool isDelete, string malingStreet, string mailingCity, string mailingState, string mailingZip, string mailingCountry, string otherStreet, string otherCity, string otherState, string otherZip, string otherCountry, string contactalias, int assigntouserid, int assigntogroupid, bool btassigned)
		{
			ContactItem contactItem = new ContactItem(companyID, clientID, salutation, firstname, lastname, title, leadSourceName, phone1, phone2, phonehome, mobile, fax, email, department, reportToUserID, assistant, assistantphone, description, isSample, createUserID, modifyUserID, createDate, modifiedDate, lastViewDate, isEmailOut, isDelete, malingStreet, mailingCity, mailingState, mailingZip, mailingCountry, otherStreet, otherCity, otherState, otherZip, otherCountry, contactalias, assigntouserid, assigntogroupid, btassigned);
			return (new DbContact()).InsertContact(contactItem);
		}
	}
}