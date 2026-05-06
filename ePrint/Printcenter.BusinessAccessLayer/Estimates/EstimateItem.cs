using System;

namespace Printcenter.BusinessAccessLayer.Estimates
{
	public class EstimateItem
	{
		private int _CompanyID;

		private long _AttachmentTypeID;

		private long _AttachmentID;

		private string _AttachmentType = string.Empty;

		private string _FileName = string.Empty;

		private long _EstimateID;

		private int _UploadedBy;

		private long _EstNotesID;

		private long _NotesID;

		private string _ModuleType = string.Empty;

		private long _ModuleID;

		private string _NotesType = string.Empty;

		private long _EstSingleItemID;

		private long _EstimateItemID;

		private long _EstQuantityID;

		private long _PressID;

		private char _PressType;

		private long _PaperID;

		private bool _IsPricePerPack;

		private bool _IsPaperSupplied;

		private double _SetUpSpoilage;

		private int _RunningSpoilage;

		private string _Colour = string.Empty;

		private bool _IsDoubleSided;

		private int _PrintSheetSizeID;

		private bool _IsSheetCustom;

		private int _SheetHeight;

		private int _SheetWidth;

		private int _JobFlatSizeID;

		private bool _IsJobCustom;

		private int _JobHeight;

		private int _JobWidth;

		private bool _IsIncludeGutters;

		private int _GutterHeight;

		private int _GutterWidth;

		private int _GutterHorizontal;

		private int _GutterVertical;

		private bool _IsPressRestrictions;

		private char _PrintLayout;

		private int _PortraitValue;

		private int _LandscapeValue;

		private long _GuillotineID;

		private string _Design = string.Empty;

		private string _Delivery = string.Empty;

		private string _Finishing = string.Empty;

		private string _Notes = string.Empty;

		private string _Description = string.Empty;

		private char _IsAnyWarehouseItem;

		private char _IsAnyOutwork;

		private char _IsAnyOtherCost;

		private int _CreatedBy;

		private int _ModifiedBy;

		private DateTime _CreatedDate;

		private DateTime _ModifiedDate;

		private bool _IsDeleted;

		private long _EstItemWarehouseID;

		private char _EstimateType;

		private long _TypeID;

		private char _WarehouseType;

		private long _WarehouseTypeID;

		private int _LeavesPerPad;

		private string _Title = string.Empty;

		private string _Color = string.Empty;

		private string _Size = string.Empty;

		private string _PaperDesc = string.Empty;

		private string _PrintQuality = string.Empty;

		private decimal _InkCoverageSide1;

		private decimal _InkCoverageSide2;

		private string _ItemTitle = string.Empty;

		private string _SectionRef = string.Empty;

		private string _ItemDescription = string.Empty;

		private bool _IsFirstTrim;

		private bool _IsSecondTrim;

		private string _SideColor = string.Empty;

		private string _CreatedOn = string.Empty;

		private string _OriginalFileName = string.Empty;

		private bool _IsDisplayToEstore;

		private bool _IsDisplayToPdf;

		private string _ReportFile = string.Empty;

		public long AttachmentID
		{
			get
			{
				return this._AttachmentID;
			}
			set
			{
				this._AttachmentID = value;
			}
		}

		public string AttachmentType
		{
			get
			{
				return this._AttachmentType;
			}
			set
			{
				this._AttachmentType = value;
			}
		}

		public long AttachmentTypeID
		{
			get
			{
				return this._AttachmentTypeID;
			}
			set
			{
				this._AttachmentTypeID = value;
			}
		}

		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				this._Color = value;
			}
		}

		public string Colour
		{
			get
			{
				return this._Colour;
			}
			set
			{
				this._Colour = value;
			}
		}

		public int CompanyID
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

		public int CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				this._CreatedBy = value;
			}
		}

		public DateTime CreatedDate
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

		public string CreatedOn
		{
			get
			{
				return this._CreatedOn;
			}
			set
			{
				this._CreatedOn = value;
			}
		}

		public string Delivery
		{
			get
			{
				return this._Delivery;
			}
			set
			{
				this._Delivery = value;
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

		public string Design
		{
			get
			{
				return this._Design;
			}
			set
			{
				this._Design = value;
			}
		}

		public long EstimateID
		{
			get
			{
				return this._EstimateID;
			}
			set
			{
				this._EstimateID = value;
			}
		}

		public long EstimateItemID
		{
			get
			{
				return this._EstimateItemID;
			}
			set
			{
				this._EstimateItemID = value;
			}
		}

		public char EstimateType
		{
			get
			{
				return this._EstimateType;
			}
			set
			{
				this._EstimateType = value;
			}
		}

		public long EstItemWarehouseID
		{
			get
			{
				return this._EstItemWarehouseID;
			}
			set
			{
				this._EstItemWarehouseID = value;
			}
		}

		public long EstNotesID
		{
			get
			{
				return this._EstNotesID;
			}
			set
			{
				this._EstNotesID = value;
			}
		}

		public long EstQuantityID
		{
			get
			{
				return this._EstQuantityID;
			}
			set
			{
				this._EstQuantityID = value;
			}
		}

		public long EstSingleItemID
		{
			get
			{
				return this._EstSingleItemID;
			}
			set
			{
				this._EstSingleItemID = value;
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

		public string Finishing
		{
			get
			{
				return this._Finishing;
			}
			set
			{
				this._Finishing = value;
			}
		}

		public long GuillotineID
		{
			get
			{
				return this._GuillotineID;
			}
			set
			{
				this._GuillotineID = value;
			}
		}

		public int GutterHeight
		{
			get
			{
				return this._GutterHeight;
			}
			set
			{
				this._GutterHeight = value;
			}
		}

		public int GutterHorizontal
		{
			get
			{
				return this._GutterHorizontal;
			}
			set
			{
				this._GutterHorizontal = value;
			}
		}

		public int GutterVertical
		{
			get
			{
				return this._GutterVertical;
			}
			set
			{
				this._GutterVertical = value;
			}
		}

		public int GutterWidth
		{
			get
			{
				return this._GutterWidth;
			}
			set
			{
				this._GutterWidth = value;
			}
		}

		public decimal InkCoverageSide1
		{
			get
			{
				return this._InkCoverageSide1;
			}
			set
			{
				this._InkCoverageSide1 = value;
			}
		}

		public decimal InkCoverageSide2
		{
			get
			{
				return this._InkCoverageSide2;
			}
			set
			{
				this._InkCoverageSide2 = value;
			}
		}

		public char IsAnyOtherCost
		{
			get
			{
				return this._IsAnyOtherCost;
			}
			set
			{
				this._IsAnyOtherCost = value;
			}
		}

		public char IsAnyOutwork
		{
			get
			{
				return this._IsAnyOutwork;
			}
			set
			{
				this._IsAnyOutwork = value;
			}
		}

		public char IsAnyWarehouseItem
		{
			get
			{
				return this._IsAnyWarehouseItem;
			}
			set
			{
				this._IsAnyWarehouseItem = value;
			}
		}

		public bool IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				this._IsDeleted = value;
			}
		}

		public bool IsDisplayToEstore
		{
			get
			{
				return this._IsDisplayToEstore;
			}
			set
			{
				this._IsDisplayToEstore = value;
			}
		}

		public bool IsDisplayToPdf
		{
			get
			{
				return this._IsDisplayToPdf;
			}
			set
			{
				this._IsDisplayToPdf = value;
			}
		}

		public bool IsDoubleSided
		{
			get
			{
				return this._IsDoubleSided;
			}
			set
			{
				this._IsDoubleSided = value;
			}
		}

		public bool IsFirstTrim
		{
			get
			{
				return this._IsFirstTrim;
			}
			set
			{
				this._IsFirstTrim = value;
			}
		}

		public bool IsIncludeGutters
		{
			get
			{
				return this._IsIncludeGutters;
			}
			set
			{
				this._IsIncludeGutters = value;
			}
		}

		public bool IsJobCustom
		{
			get
			{
				return this._IsJobCustom;
			}
			set
			{
				this._IsJobCustom = value;
			}
		}

		public bool IsPaperSupplied
		{
			get
			{
				return this._IsPaperSupplied;
			}
			set
			{
				this._IsPaperSupplied = value;
			}
		}

		public bool IsPressRestrictions
		{
			get
			{
				return this._IsPressRestrictions;
			}
			set
			{
				this._IsPressRestrictions = value;
			}
		}

		public bool IsPricePerPack
		{
			get
			{
				return this._IsPricePerPack;
			}
			set
			{
				this._IsPricePerPack = value;
			}
		}

		public bool IsSecondTrim
		{
			get
			{
				return this._IsSecondTrim;
			}
			set
			{
				this._IsSecondTrim = value;
			}
		}

		public bool IsSheetCustom
		{
			get
			{
				return this._IsSheetCustom;
			}
			set
			{
				this._IsSheetCustom = value;
			}
		}

		public string ItemDescription
		{
			get
			{
				return this._ItemDescription;
			}
			set
			{
				this._ItemDescription = value;
			}
		}

		public string ItemTitle
		{
			get
			{
				return this._ItemTitle;
			}
			set
			{
				this._ItemTitle = value;
			}
		}

		public int JobFlatSizeID
		{
			get
			{
				return this._JobFlatSizeID;
			}
			set
			{
				this._JobFlatSizeID = value;
			}
		}

		public int JobHeight
		{
			get
			{
				return this._JobHeight;
			}
			set
			{
				this._JobHeight = value;
			}
		}

		public int JobWidth
		{
			get
			{
				return this._JobWidth;
			}
			set
			{
				this._JobWidth = value;
			}
		}

		public int LandscapeValue
		{
			get
			{
				return this._LandscapeValue;
			}
			set
			{
				this._LandscapeValue = value;
			}
		}

		public int LeavesPerPad
		{
			get
			{
				return this._LeavesPerPad;
			}
			set
			{
				this._LeavesPerPad = value;
			}
		}

		public int ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				this._ModifiedBy = value;
			}
		}

		public DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				this._ModifiedDate = value;
			}
		}

		public long ModuleID
		{
			get
			{
				return this._ModuleID;
			}
			set
			{
				this._ModuleID = value;
			}
		}

		public string ModuleType
		{
			get
			{
				return this._ModuleType;
			}
			set
			{
				this._ModuleType = value;
			}
		}

		public string Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				this._Notes = value;
			}
		}

		public long NotesID
		{
			get
			{
				return this._NotesID;
			}
			set
			{
				this._NotesID = value;
			}
		}

		public string NotesType
		{
			get
			{
				return this._NotesType;
			}
			set
			{
				this._NotesType = value;
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

		public string PaperDesc
		{
			get
			{
				return this._PaperDesc;
			}
			set
			{
				this._PaperDesc = value;
			}
		}

		public long PaperID
		{
			get
			{
				return this._PaperID;
			}
			set
			{
				this._PaperID = value;
			}
		}

		public int PortraitValue
		{
			get
			{
				return this._PortraitValue;
			}
			set
			{
				this._PortraitValue = value;
			}
		}

		public long PressID
		{
			get
			{
				return this._PressID;
			}
			set
			{
				this._PressID = value;
			}
		}

		public char PressType
		{
			get
			{
				return this._PressType;
			}
			set
			{
				this._PressType = value;
			}
		}

		public char PrintLayout
		{
			get
			{
				return this._PrintLayout;
			}
			set
			{
				this._PrintLayout = value;
			}
		}

		public string PrintQuality
		{
			get
			{
				return this._PrintQuality;
			}
			set
			{
				this._PrintQuality = value;
			}
		}

		public int PrintSheetSizeID
		{
			get
			{
				return this._PrintSheetSizeID;
			}
			set
			{
				this._PrintSheetSizeID = value;
			}
		}

		public string ReportFile
		{
			get
			{
				return this._ReportFile;
			}
			set
			{
				this._ReportFile = value;
			}
		}

		public int RunningSpoilage
		{
			get
			{
				return this._RunningSpoilage;
			}
			set
			{
				this._RunningSpoilage = value;
			}
		}

		public string SectionRef
		{
			get
			{
				return this._SectionRef;
			}
			set
			{
				this._SectionRef = value;
			}
		}

		public double SetUpSpoilage
		{
			get
			{
				return this._SetUpSpoilage;
			}
			set
			{
				this._SetUpSpoilage = value;
			}
		}

		public int SheetHeight
		{
			get
			{
				return this._SheetHeight;
			}
			set
			{
				this._SheetHeight = value;
			}
		}

		public int SheetWidth
		{
			get
			{
				return this._SheetWidth;
			}
			set
			{
				this._SheetWidth = value;
			}
		}

		public string SideColor
		{
			get
			{
				return this._SideColor;
			}
			set
			{
				this._SideColor = value;
			}
		}

		public string Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				this._Size = value;
			}
		}

		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				this._Title = value;
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

		public int UploadedBy
		{
			get
			{
				return this._UploadedBy;
			}
			set
			{
				this._UploadedBy = value;
			}
		}

		public char WarehouseType
		{
			get
			{
				return this._WarehouseType;
			}
			set
			{
				this._WarehouseType = value;
			}
		}

		public long WarehouseTypeID
		{
			get
			{
				return this._WarehouseTypeID;
			}
			set
			{
				this._WarehouseTypeID = value;
			}
		}

		public EstimateItem()
		{
		}
	}
}