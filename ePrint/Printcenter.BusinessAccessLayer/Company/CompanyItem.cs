using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.Company
{
	public class CompanyItem : BaseItem
	{
		private int _ClientID;

		private string _Address = string.Empty;

		private string _City = string.Empty;

		private string _State = string.Empty;

		private string _Country = string.Empty;

		private string _Telephone = string.Empty;

		private string _Fax = string.Empty;

		private string _ZipCode = string.Empty;

		private string _Ref = string.Empty;

		private string _Email = string.Empty;

		private bool _IsDefaultEmail;

		private bool _IsDefaultDeliveryAddress;

		private bool _IsDefaultBillingAddress;

		private string _CreatedDate = string.Empty;

		private int _AddressID;

		private bool _IsDefaultPostBoxAddress;

		private string _AddressLabel = string.Empty;

		private string _AddressLine2 = string.Empty;

		private string _URL = string.Empty;

		private string _isHideAddress = string.Empty;

		private string _Measurement = string.Empty;

		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this._Address = value;
			}
		}

		public new int AddressID
		{
			get
			{
				return this._AddressID;
			}
			set
			{
				this._AddressID = value;
			}
		}

		public string AddressLabel
		{
			get
			{
				return this._AddressLabel;
			}
			set
			{
				this._AddressLabel = value;
			}
		}

		public string AddressLine2
		{
			get
			{
				return this._AddressLine2;
			}
			set
			{
				this._AddressLine2 = value;
			}
		}

		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				this._City = value;
			}
		}

		public int ClientID
		{
			get
			{
				return this._ClientID;
			}
			set
			{
				this._ClientID = value;
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

		public new string CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				this._CreatedDate = value;
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

		public bool IsDefaultBillingAddress
		{
			get
			{
				return this._IsDefaultBillingAddress;
			}
			set
			{
				this._IsDefaultBillingAddress = value;
			}
		}

		public bool IsDefaultDeliveryAddress
		{
			get
			{
				return this._IsDefaultDeliveryAddress;
			}
			set
			{
				this._IsDefaultDeliveryAddress = value;
			}
		}

		public bool IsDefaultEmail
		{
			get
			{
				return this._IsDefaultEmail;
			}
			set
			{
				this._IsDefaultEmail = value;
			}
		}

		public bool IsDefaultPostBoxAddress
		{
			get
			{
				return this._IsDefaultPostBoxAddress;
			}
			set
			{
				this._IsDefaultPostBoxAddress = value;
			}
		}

		public string isHideAddress
		{
			get
			{
				return this._isHideAddress;
			}
			set
			{
				this._isHideAddress = value;
			}
		}

		public string Measurement
		{
			get
			{
				return this._Measurement;
			}
			set
			{
				this._Measurement = value;
			}
		}

		public string Ref
		{
			get
			{
				return this._Ref;
			}
			set
			{
				this._Ref = value;
			}
		}

		public string State
		{
			get
			{
				return this._State;
			}
			set
			{
				this._State = value;
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

		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				this._URL = value;
			}
		}

		public string ZipCode
		{
			get
			{
				return this._ZipCode;
			}
			set
			{
				this._ZipCode = value;
			}
		}

		public CompanyItem()
		{
		}
	}
}