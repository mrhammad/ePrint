using System;
using System.Runtime.Serialization;

namespace TemplateEditorFrontEnd
{
	public class ImageCategory
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

		private bool _IsPdfImage;

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
		public bool IsPdfImage
		{
			get
			{
				return this._IsPdfImage;
			}
			set
			{
				this._IsPdfImage = value;
			}
		}

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		[DataMember]
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

		public ImageCategory()
		{
		}

		public ImageCategory(long cCategoryID, string cMultiLevelCategory)
		{
			this.CategoryID = cCategoryID;
			this.MultiLevelCategory = cMultiLevelCategory;
		}

		public ImageCategory(long cImageID, long cCompanyID, long cCategoryID, long cUserID, string cUserType, string cOriginalFileName, string cFileName, long cFileSize, string cImageDescription, string cMetaTags, bool IsPdfImage)
		{
			this.ImageID = cImageID;
			this.CompanyID = cCompanyID;
			this.CategoryID = cCategoryID;
			this.UserID = cUserID;
			this.UserType = cUserType;
			this.OriginalFileName = cOriginalFileName;
			this.FileName = cFileName;
			this.FileSize = cFileSize;
			this.ImageDescription = cImageDescription;
			this.MetaTags = cMetaTags;
			this.IsPdfImage = IsPdfImage;
		}

		public ImageCategory(long cCategoryID, long cCompanyID, string cCategoryName, string cDescription, long cParentID, string cCategoryImage, long cUserID)
		{
			this.CategoryID = cCategoryID;
			this.CompanyID = cCompanyID;
			this.CategoryName = cCategoryName;
			this.Description = cDescription;
			this.ParentID = cParentID;
			this.CategoryImage = cCategoryImage;
			this.UserID = cUserID;
		}
	}
}