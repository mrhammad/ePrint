using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.Accounts
{
	public class AccountsItem : BaseItem
	{
		private int _accountID;

		private int _clientID;

		private string _clientName = string.Empty;

		private string _accountName = string.Empty;

		private string _accountPrefix = string.Empty;

		private string _createdOn = string.Empty;

		private int _createdBy;

		private bool _isDeleted;

		private int _defaultContactID;

		private int _defaultAddressID;

		private char _accountType = 'p';

		private char _addressType = 'M';

		private int _CompanyID;

		private string _StoreURL = string.Empty;

		private string _FileExtension = string.Empty;

		public int accountID
		{
			get
			{
				return this._accountID;
			}
			set
			{
				this._accountID = value;
			}
		}

		public string accountName
		{
			get
			{
				return this._accountName;
			}
			set
			{
				this._accountName = value;
			}
		}

		public string accountPrefix
		{
			get
			{
				return this._accountPrefix;
			}
			set
			{
				this._accountPrefix = value;
			}
		}

		public char accountType
		{
			get
			{
				return this._accountType;
			}
			set
			{
				this._accountType = value;
			}
		}

		public char addressType
		{
			get
			{
				return this._addressType;
			}
			set
			{
				this._addressType = value;
			}
		}

		public int clientID
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

		public string clientName
		{
			get
			{
				return this._clientName;
			}
			set
			{
				this._clientName = value;
			}
		}

		public new int CompanyID
		{
			get
			{
				return this._CompanyID;
			}
			set
			{
				this._CompanyID = value;
			}
		}

		public int createdBy
		{
			get
			{
				return this._createdBy;
			}
			set
			{
				this._createdBy = value;
			}
		}

		public string createdOn
		{
			get
			{
				return this._createdOn;
			}
			set
			{
				this._createdOn = value;
			}
		}

		public int defaultAddressID
		{
			get
			{
				return this._defaultAddressID;
			}
			set
			{
				this._defaultAddressID = value;
			}
		}

		public int defaultContactID
		{
			get
			{
				return this._defaultContactID;
			}
			set
			{
				this._defaultContactID = value;
			}
		}

		public string FileExtension
		{
			get
			{
				return this._FileExtension;
			}
			set
			{
				this._FileExtension = value;
			}
		}

		public bool isDeleted
		{
			get
			{
				return this._isDeleted;
			}
			set
			{
				this._isDeleted = value;
			}
		}

		public string StoreURL
		{
			get
			{
				return this._StoreURL;
			}
			set
			{
				this._StoreURL = value;
			}
		}

		public AccountsItem()
		{
		}
	}
}