using System;

namespace Printcenter.UI.LoginNew
{
	public class LoginItems
	{
		private long _DepartmentID;

		private string _FirstName = string.Empty;

		private string _LastName = string.Empty;

		private string _MiddleName = string.Empty;

		private string _DepartmentName = string.Empty;

		private string _Address1 = string.Empty;

		private string _Address2 = string.Empty;

		private string _Address3 = string.Empty;

		private string _Address4 = string.Empty;

		private string _Address5 = string.Empty;

		private string _Country = string.Empty;

		private string _Telephone = string.Empty;

		private string _Fax = string.Empty;

		private string _Email = string.Empty;

		private string _Password = string.Empty;

		private string _ApproverEmail = string.Empty;

		private string _ApprovalType = string.Empty;

		private long _IsSubscribeuser;

		public string Address1
		{
			get
			{
				return this._Address1;
			}
			set
			{
				this._Address1 = value;
			}
		}

		public string Address2
		{
			get
			{
				return this._Address2;
			}
			set
			{
				this._Address2 = value;
			}
		}

		public string Address3
		{
			get
			{
				return this._Address3;
			}
			set
			{
				this._Address3 = value;
			}
		}

		public string Address4
		{
			get
			{
				return this._Address4;
			}
			set
			{
				this._Address4 = value;
			}
		}

		public string Address5
		{
			get
			{
				return this._Address5;
			}
			set
			{
				this._Address5 = value;
			}
		}

		public string ApprovalType
		{
			get
			{
				return this._ApprovalType;
			}
			set
			{
				this._ApprovalType = value;
			}
		}

		public string ApproverEmail
		{
			get
			{
				return this._ApproverEmail;
			}
			set
			{
				this._ApproverEmail = value;
			}
		}

		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				this._Country = value;
			}
		}

		public long DepartmentID
		{
			get
			{
				return this._DepartmentID;
			}
			set
			{
				this._DepartmentID = value;
			}
		}

		public string DepartmentName
		{
			get
			{
				return this._DepartmentName;
			}
			set
			{
				this._DepartmentName = value;
			}
		}

		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this._Email = value;
			}
		}

		public string Fax
		{
			get
			{
				return this._Fax;
			}
			set
			{
				this._Fax = value;
			}
		}

		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				this._FirstName = value;
			}
		}

		public long IsSubscribeuser
		{
			get
			{
				return this._IsSubscribeuser;
			}
			set
			{
				this._IsSubscribeuser = value;
			}
		}

		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				this._LastName = value;
			}
		}

		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				this._MiddleName = value;
			}
		}

		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				this._Password = value;
			}
		}

		public string Telephone
		{
			get
			{
				return this._Telephone;
			}
			set
			{
				this._Telephone = value;
			}
		}

		public LoginItems()
		{
		}
	}
}