using System;

namespace TemplateEditor
{
    public class QueryStringPara
    {
        private long _templateid;

        private long _companyid;

        private long _userID;

        private long _priceccatid;

        private string _dbKey;

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