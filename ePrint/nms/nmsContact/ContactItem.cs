using System;

namespace nmsContact
{
	public class ContactItem
	{
		private int _contactID;

		private int _companyID;

		private int _clientID;

		private string _salutation = string.Empty;

		private string _firstname = string.Empty;

		private string _lastname = string.Empty;

		private string _title = string.Empty;

		private string _leadSourceName = string.Empty;

		private string _phone1 = string.Empty;

		private string _phone2 = string.Empty;

		private string _phonehome = string.Empty;

		private string _mobile = string.Empty;

		private string _fax = string.Empty;

		private string _email = string.Empty;

		private string _department = string.Empty;

		private int _reportToUserID;

		private string _assistant = string.Empty;

		private string _assistantphone = string.Empty;

		private string _description = string.Empty;

		private bool _isSample;

		private int _createUserID;

		private bool _isEmailOut;

		private int _modifyUserID;

		private DateTime _createDate = DateTime.Parse("01/01/1900");

		private DateTime _modifiedDate = DateTime.Parse("01/01/1900");

		private DateTime _lastViewDate = DateTime.Parse("01/01/1900");

		private bool _isDelete;

		private string _mailingStreet = string.Empty;

		private string _mailingCity = string.Empty;

		private string _mailingState = string.Empty;

		private string _mailingZip = string.Empty;

		private string _mailingCountry = string.Empty;

		private string _otherStreet = string.Empty;

		private string _otherCity = string.Empty;

		private string _otherState = string.Empty;

		private string _otherZip = string.Empty;

		private string _otherCountry = string.Empty;

		private int _assigntouserid;

		private int _assigntogroupid;

		private bool _btassigned;

		private string _contactalias = string.Empty;

		public int Assigntogroupid
		{
			get
			{
				return this._assigntogroupid;
			}
			set
			{
				this._assigntogroupid = value;
			}
		}

		public int Assigntouserid
		{
			get
			{
				return this._assigntouserid;
			}
			set
			{
				this._assigntouserid = value;
			}
		}

		public string Assistant
		{
			get
			{
				return this._assistant;
			}
			set
			{
				this._assistant = value;
			}
		}

		public string Assistantphone
		{
			get
			{
				return this._assistantphone;
			}
			set
			{
				this._assistantphone = value;
			}
		}

		public bool Btassigned
		{
			get
			{
				return this._btassigned;
			}
			set
			{
				this._btassigned = value;
			}
		}

		public int ClientID
		{
			get
			{
				return this._clientID;
			}
			set
			{
				this._clientID = value;
			}
		}

		public int CompanyID
		{
			get
			{
				return this._companyID;
			}
			set
			{
				this._companyID = value;
			}
		}

		public string Contactalias
		{
			get
			{
				return this._contactalias;
			}
			set
			{
				this._contactalias = value;
			}
		}

		public int ContactID
		{
			get
			{
				return this._contactID;
			}
			set
			{
				this._contactID = value;
			}
		}

		public DateTime CreateDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				this._createDate = value;
			}
		}

		public int CreateUserID
		{
			get
			{
				return this._createUserID;
			}
			set
			{
				this._createUserID = value;
			}
		}

		public string Department
		{
			get
			{
				return this._department;
			}
			set
			{
				this._department = value;
			}
		}

		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}

		public string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
			}
		}

		public string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				this._fax = value;
			}
		}

		public string Firstname
		{
			get
			{
				return this._firstname;
			}
			set
			{
				this._firstname = value;
			}
		}

		public bool IsDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				this._isDelete = value;
			}
		}

		public bool IsEmailOut
		{
			get
			{
				return this._isEmailOut;
			}
			set
			{
				this._isEmailOut = value;
			}
		}

		public bool IsSample
		{
			get
			{
				return this._isSample;
			}
			set
			{
				this._isSample = value;
			}
		}

		public string Lastname
		{
			get
			{
				return this._lastname;
			}
			set
			{
				this._lastname = value;
			}
		}

		public DateTime lastViewDate
		{
			get
			{
				return this._lastViewDate;
			}
			set
			{
				this._lastViewDate = value;
			}
		}

		public string LeadSourceName
		{
			get
			{
				return this._leadSourceName;
			}
			set
			{
				this._leadSourceName = value;
			}
		}

		public string MailingCity
		{
			get
			{
				return this._mailingCity;
			}
			set
			{
				this._mailingCity = value;
			}
		}

		public string MailingCountry
		{
			get
			{
				return this._mailingCountry;
			}
			set
			{
				this._mailingCountry = value;
			}
		}

		public string MailingState
		{
			get
			{
				return this._mailingState;
			}
			set
			{
				this._mailingState = value;
			}
		}

		public string MailingZip
		{
			get
			{
				return this._mailingZip;
			}
			set
			{
				this._mailingZip = value;
			}
		}

		public string MalingStreet
		{
			get
			{
				return this._mailingStreet;
			}
			set
			{
				this._mailingStreet = value;
			}
		}

		public string Mobile
		{
			get
			{
				return this._mobile;
			}
			set
			{
				this._mobile = value;
			}
		}

		public DateTime ModifiedDate
		{
			get
			{
				return this._modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}

		public int ModifyUserID
		{
			get
			{
				return this._modifyUserID;
			}
			set
			{
				this._modifyUserID = value;
			}
		}

		public string OtherCity
		{
			get
			{
				return this._otherCity;
			}
			set
			{
				this._otherCity = value;
			}
		}

		public string OtherCountry
		{
			get
			{
				return this._otherCountry;
			}
			set
			{
				this._otherCountry = value;
			}
		}

		public string OtherState
		{
			get
			{
				return this._otherState;
			}
			set
			{
				this._otherState = value;
			}
		}

		public string OtherStreet
		{
			get
			{
				return this._otherStreet;
			}
			set
			{
				this._otherStreet = value;
			}
		}

		public string OtherZip
		{
			get
			{
				return this._otherZip;
			}
			set
			{
				this._otherZip = value;
			}
		}

		public string Phone1
		{
			get
			{
				return this._phone1;
			}
			set
			{
				this._phone1 = value;
			}
		}

		public string Phone2
		{
			get
			{
				return this._phone2;
			}
			set
			{
				this._phone2 = value;
			}
		}

		public string Phonehome
		{
			get
			{
				return this._phonehome;
			}
			set
			{
				this._phonehome = value;
			}
		}

		public int ReportToUserID
		{
			get
			{
				return this._reportToUserID;
			}
			set
			{
				this._reportToUserID = value;
			}
		}

		public string Salutation
		{
			get
			{
				return this._salutation;
			}
			set
			{
				this._salutation = value;
			}
		}

		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}

		public ContactItem()
		{
		}

		public ContactItem(int companyID, int clientID, string salutation, string firstname, string lastname, string title, string leadSourceName, string phone1, string phone2, string phonehome, string mobile, string fax, string email, string department, int reportToUserID, string assistant, string assistantphone, string description, bool isSample, int createUserID, int modifyUserID, DateTime createDate, DateTime modifiedDate, DateTime lastViewDate, bool isEmailOut, bool isDelete, string malingStreet, string mailingCity, string mailingState, string mailingZip, string mailingCountry, string otherStreet, string otherCity, string otherState, string otherZip, string otherCountry, string contactalias, int assigntouserid, int assigntogroupid, bool btassigned)
		{
			this.CompanyID = companyID;
			this.ClientID = clientID;
			this.Salutation = salutation;
			this.Firstname = firstname;
			this.Lastname = lastname;
			this.Title = title;
			this.LeadSourceName = leadSourceName;
			this.Phone1 = phone1;
			this.Phone2 = phone2;
			this.Phonehome = phonehome;
			this.Mobile = mobile;
			this.Fax = fax;
			this.Email = email;
			this.Department = department;
			this.ReportToUserID = reportToUserID;
			this.Assistant = assistant;
			this.Assistantphone = assistantphone;
			this.Description = description;
			this.IsSample = isSample;
			this.CreateUserID = createUserID;
			this.ModifyUserID = modifyUserID;
			this.CreateDate = createDate;
			this.ModifiedDate = modifiedDate;
			this.lastViewDate = lastViewDate;
			this.IsEmailOut = isEmailOut;
			this.IsDelete = isDelete;
			this.MalingStreet = mailingState;
			this.MailingCity = mailingCity;
			this.MailingState = mailingState;
			this.MailingZip = mailingZip;
			this.MailingCountry = mailingCountry;
			this.OtherStreet = this.OtherStreet;
			this.OtherCity = otherCity;
			this.OtherState = otherState;
			this.OtherZip = otherZip;
			this.OtherCountry = otherCountry;
			this.Contactalias = contactalias;
			this.Assigntouserid = assigntouserid;
			this.Assigntogroupid = assigntogroupid;
			this.Btassigned = btassigned;
		}
	}
}