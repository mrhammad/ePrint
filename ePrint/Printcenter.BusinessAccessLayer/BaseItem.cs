using System;

namespace Printcenter.BusinessAccessLayer
{
	public class BaseItem
	{
		private int _CompanyID;

		private int _UserID;

		private int _SupplierID;

		private int _ContactID;

		private long _AddressID;

		private long _PurchaseID;

		private long _EstimateItemID;

		private int _CostCentreID;

		private string _AddressType = string.Empty;

		private decimal _Height;

		private decimal _Width;

		private decimal _Profit;

		private int _Priority;

		private bool _IsDeleted;

		private string _Description = string.Empty;

		private DateTime _CreatedDate = DateTime.Now;

		private int _CreatedBy;

		private int _ModifiedBy;

		private DateTime _ModifiedDate = DateTime.Now;

		private int _DefaultFilm;

		private int _DefaultPlate;

		private int _DefaultPaper;

		private int _DefaultGuillotine;

		private int _MinimumSheetSizeHeight;

		private int _MinimumSheetSizeWidth;

		private int _MaximumSheetSizeHeight;

		private int _MaximumSheetSizeWidth;

		private int _SetupCharge;

		private decimal _CostPerCut;

		private decimal _Utiltization;

		private int _RunningCharge;

		private bool _IsRoundupPrice;

		private int _PerHourCost;

		private bool _ExternalCost;

		private bool _PrintCost;

		public long AddressID
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

		public string AddressType
		{
			get
			{
				return this._AddressType;
			}
			set
			{
				this._AddressType = value;
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

		public int ContactID
		{
			get
			{
				return this._ContactID;
			}
			set
			{
				this._ContactID = value;
			}
		}

		public int CostCentreID
		{
			get
			{
				return this._CostCentreID;
			}
			set
			{
				this._CostCentreID = value;
			}
		}

		public decimal CostPerCut
		{
			get
			{
				return this._CostPerCut;
			}
			set
			{
				this._CostPerCut = value;
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

		public int DefaultFilm
		{
			get
			{
				return this._DefaultFilm;
			}
			set
			{
				this._DefaultFilm = value;
			}
		}

		public int DefaultGuillotine
		{
			get
			{
				return this._DefaultGuillotine;
			}
			set
			{
				this._DefaultGuillotine = value;
			}
		}

		public int DefaultPaper
		{
			get
			{
				return this._DefaultPaper;
			}
			set
			{
				this._DefaultPaper = value;
			}
		}

		public int DefaultPlate
		{
			get
			{
				return this._DefaultPlate;
			}
			set
			{
				this._DefaultPlate = value;
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

		public bool ExternalCost
		{
			get
			{
				return this._ExternalCost;
			}
			set
			{
				this._ExternalCost = value;
			}
		}

		public decimal Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
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

		public bool IsRoundupPrice
		{
			get
			{
				return this._IsRoundupPrice;
			}
			set
			{
				this._IsRoundupPrice = value;
			}
		}

		public int MaximumSheetSizeHeight
		{
			get
			{
				return this._MaximumSheetSizeHeight;
			}
			set
			{
				this._MaximumSheetSizeHeight = value;
			}
		}

		public int MaximumSheetSizeWidth
		{
			get
			{
				return this._MaximumSheetSizeWidth;
			}
			set
			{
				this._MaximumSheetSizeWidth = value;
			}
		}

		public int MinimumSheetSizeHeight
		{
			get
			{
				return this._MinimumSheetSizeHeight;
			}
			set
			{
				this._MinimumSheetSizeHeight = value;
			}
		}

		public int MinimumSheetSizeWidth
		{
			get
			{
				return this._MinimumSheetSizeWidth;
			}
			set
			{
				this._MinimumSheetSizeWidth = value;
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

		public int PerHourCost
		{
			get
			{
				return this._PerHourCost;
			}
			set
			{
				this._PerHourCost = value;
			}
		}

		public bool PrintCost
		{
			get
			{
				return this._PrintCost;
			}
			set
			{
				this._PrintCost = value;
			}
		}

		public int Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				this._Priority = value;
			}
		}

		public decimal Profit
		{
			get
			{
				return this._Profit;
			}
			set
			{
				this._Profit = value;
			}
		}

		public long PurchaseID
		{
			get
			{
				return this._PurchaseID;
			}
			set
			{
				this._PurchaseID = value;
			}
		}

		public int RunningCharge
		{
			get
			{
				return this._RunningCharge;
			}
			set
			{
				this._RunningCharge = value;
			}
		}

		public int SetupCharge
		{
			get
			{
				return this._SetupCharge;
			}
			set
			{
				this._SetupCharge = value;
			}
		}

		public int SupplierID
		{
			get
			{
				return this._SupplierID;
			}
			set
			{
				this._SupplierID = value;
			}
		}

		public int UserID
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

		public decimal Utiltization
		{
			get
			{
				return this._Utiltization;
			}
			set
			{
				this._Utiltization = value;
			}
		}

		public decimal Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
			}
		}

		public BaseItem()
		{
		}
	}
}