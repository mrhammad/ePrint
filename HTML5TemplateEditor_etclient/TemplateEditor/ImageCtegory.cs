using System;

namespace TemplateEditor
{
	public class ImageCtegory
	{
		private long _CategoryID;

		private long _CompanyID;

		private long _ParentID;

		private long _UserID;

		private long _ImageID;

		private long _FileSize;

		private string _CategoryName;

		private string _Description;

		private string _CategoryImage;

		private string _MultiLevelCategory;

		private string _UserType;

		private string _OriginalFileName;

		private string _FileName;

		private string _ImageDescription;

		private string _MetaTags;

		private long _AssignmentID;

		private string _ObjectID;

		private long _TemplateID;

		private string _Type;

		private long _TypeID;

		private bool _IsDefault;

		public long AssignmentID
		{
			get
			{
				return this._AssignmentID;
			}
			set
			{
				this._AssignmentID = value;
			}
		}

		public long CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				this._CategoryID = value;
			}
		}

		public string CategoryImage
		{
			get
			{
				return this._CategoryImage;
			}
			set
			{
				this._CategoryImage = value;
			}
		}

		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				this._CategoryName = value;
			}
		}

		public long CompanyID
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

		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this._Description = value;
			}
		}

		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				this._FileName = value;
			}
		}

		public long FileSize
		{
			get
			{
				return this._FileSize;
			}
			set
			{
				this._FileSize = value;
			}
		}

		public string ImageDescription
		{
			get
			{
				return this._ImageDescription;
			}
			set
			{
				this._ImageDescription = value;
			}
		}

		public long ImageID
		{
			get
			{
				return this._ImageID;
			}
			set
			{
				this._ImageID = value;
			}
		}

		public bool IsDefault
		{
			get
			{
				return this._IsDefault;
			}
			set
			{
				this._IsDefault = value;
			}
		}

		public string MetaTags
		{
			get
			{
				return this._MetaTags;
			}
			set
			{
				this._MetaTags = value;
			}
		}

		public string MultiLevelCategory
		{
			get
			{
				return this._MultiLevelCategory;
			}
			set
			{
				this._MultiLevelCategory = value;
			}
		}

		public string ObjectID
		{
			get
			{
				return this._ObjectID;
			}
			set
			{
				this._ObjectID = value;
			}
		}

		public string OriginalFileName
		{
			get
			{
				return this._OriginalFileName;
			}
			set
			{
				this._OriginalFileName = value;
			}
		}

		public long ParentID
		{
			get
			{
				return this._ParentID;
			}
			set
			{
				this._ParentID = value;
			}
		}

		public long TemplateID
		{
			get
			{
				return this._TemplateID;
			}
			set
			{
				this._TemplateID = value;
			}
		}

		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		public long TypeID
		{
			get
			{
				return this._TypeID;
			}
			set
			{
				this._TypeID = value;
			}
		}

		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				this._UserID = value;
			}
		}

		public string UserType
		{
			get
			{
				return this._UserType;
			}
			set
			{
				this._UserType = value;
			}
		}

		public ImageCtegory()
		{
		}
	}
}