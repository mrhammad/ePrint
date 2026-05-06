using System;

namespace nmsCommon
{
	public class MailContact
	{
		private string _email = string.Empty;

		private string _name = string.Empty;

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

		public string FullEmail
		{
			get
			{
				return this.Email;
			}
		}

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public MailContact()
		{
		}
	}
}