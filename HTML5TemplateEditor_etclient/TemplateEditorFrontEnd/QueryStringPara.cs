using System;

namespace TemplateEditorFrontEnd
{
	public class QueryStringPara
	{
		private long _templateid;

		private long _companyid;

		private long _userID;

		private long _priceccatid;

		private long storeuserid;

		private long cartitmid;

		private long _accid;

		private string _dbKey;

		private string _sessionid;

		private string _type;

		public long AccountID
		{
			get
			{
				return this._accid;
			}
			set
			{
				this._accid = value;
			}
		}

		public long CartItemID
		{
			get
			{
				return this.cartitmid;
			}
			set
			{
				this.cartitmid = value;
			}
		}

		public long CompanyID
		{
			get
			{
				return this._companyid;
			}
			set
			{
				this._companyid = value;
			}
		}

		public string dbKey
		{
			get
			{
				return this._dbKey;
			}
			set
			{
				this._dbKey = value;
			}
		}

		public long PriceCatalogId
		{
			get
			{
				return this._priceccatid;
			}
			set
			{
				this._priceccatid = value;
			}
		}

		public string SessionID
		{
			get
			{
				return this._sessionid;
			}
			set
			{
				this._sessionid = value;
			}
		}

		public long StoreUserID
		{
			get
			{
				return this.storeuserid;
			}
			set
			{
				this.storeuserid = value;
			}
		}

		public long TemplateID
		{
			get
			{
				return this._templateid;
			}
			set
			{
				this._templateid = value;
			}
		}

		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public long UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				this._userID = value;
			}
		}

		public QueryStringPara()
		{
		}
	}
}