using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.Inventories
{
	public class InventoryItem : BaseItem
	{
		private int _CategoryID;

		private string _CategoryCode = string.Empty;

		private string _CategoryName = string.Empty;

		private string _Description = string.Empty;

		private bool _IsWeight;

		private bool _IsColor;

		private bool _IsItemCustomSize;

		private bool _IsItemPaperSize;

		private bool _IsCoatingType;

		private bool _IsPrinting;

		private bool _IsCoated;

		private bool _IsExposure;

		private bool _IsProcessingCharge;

		private int _SubCategoryID;

		private string _SubCategoryCode = string.Empty;

		private string _SubCategoryName = string.Empty;

		private long _InventoryID;

		private string _InventoryName = string.Empty;

		private string _FriendlyName = string.Empty;

		private string _InventoryCode = string.Empty;

		private int _InventoryCategoryID;

		private int _InventorySubCategoryID;

		private string _Location = string.Empty;

		private string _Status = string.Empty;

		private int _SupplierID;

		private decimal _InStock;

		private decimal _InvInStock;

		private decimal _ReOrderLevel;

		private int _ReOrderQuantity;

		private decimal _AllocatedQty;

		private bool _IsLargeFormatMaterial;

		private int _InventoryPropertyID;

		private decimal _Cost;

		private int _PerQuantity;

		private decimal _InvPerQuantity;

		private int _PackedIn;

		private decimal _InvPackedIn;

		private decimal _PackedPrice;

		private decimal _ProcessCharge;

		private decimal _SellingPrice;

		private decimal _CostPerReel;

		private int _PaperSizeID;

		private decimal _Height;

		private decimal _Width;

		private string _WidthType = string.Empty;

		private int _Length;

		private decimal _InvLength;

		private string _LengthType = string.Empty;

		private decimal _BasisWeight;

		private string _Coated = string.Empty;

		private string _Colour = string.Empty;

		private string _PaperType = string.Empty;

		private decimal _InkAbsorption;

		private int _WashupCounter;

		private decimal _Yield;

		private string _YieldType = string.Empty;

		private string _PackedInType = string.Empty;

		private string _InkType = string.Empty;

		private long _InventorySheetsFrom;

		private long _InventorySheetsTo;

		private decimal _ChargableCost;

		private long _ChargableSheets;

		private decimal _SetUpCost;

		private long _InkMatrixId;

		private decimal _InkMinimumCost;

		private decimal _CostPerLinear;
		//Ticket 81174
		private decimal _Markup;

		private decimal _Caliper;

		public decimal AllocatedQty
		{
			get
			{
				return this._AllocatedQty;
			}
			set
			{
				this._AllocatedQty = value;
			}
		}

		public decimal BasisWeight
		{
			get
			{
				return this._BasisWeight;
			}
			set
			{
				this._BasisWeight = value;
			}
		}
		public decimal Caliper
		{
			get
			{
				return this._Caliper;
			}
			set
			{
				this._Caliper = value;
			}
		}
		public string CategoryCode
		{
			get
			{
				return this._CategoryCode;
			}
			set
			{
				this._CategoryCode = value;
			}
		}

		public int CategoryID
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

		public decimal ChargableCost
		{
			get
			{
				return this._ChargableCost;
			}
			set
			{
				this._ChargableCost = value;
			}
		}

		public long ChargableSheets
		{
			get
			{
				return this._ChargableSheets;
			}
			set
			{
				this._ChargableSheets = value;
			}
		}

		public string Coated
		{
			get
			{
				return this._Coated;
			}
			set
			{
				this._Coated = value;
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

		public decimal Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				this._Cost = value;
			}
		}

		public decimal CostPerLinear
		{
			get
			{
				return this._CostPerLinear;
			}
			set
			{
				this._CostPerLinear = value;
			}
		}

		public decimal CostPerReel
		{
			get
			{
				return this._CostPerReel;
			}
			set
			{
				this._CostPerReel = value;
			}
		}

		public new string Description
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

		public string FriendlyName
		{
			get
			{
				return this._FriendlyName;
			}
			set
			{
				this._FriendlyName = value;
			}
		}

		public new decimal Height
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

		public decimal InkAbsorption
		{
			get
			{
				return this._InkAbsorption;
			}
			set
			{
				this._InkAbsorption = value;
			}
		}

		public long InkMatrixId
		{
			get
			{
				return this._InkMatrixId;
			}
			set
			{
				this._InkMatrixId = value;
			}
		}

		public decimal InkMinimumCost
		{
			get
			{
				return this._InkMinimumCost;
			}
			set
			{
				this._InkMinimumCost = value;
			}
		}

		public string InkType
		{
			get
			{
				return this._InkType;
			}
			set
			{
				this._InkType = value;
			}
		}

		public decimal InStock
		{
			get
			{
				return this._InStock;
			}
			set
			{
				this._InStock = value;
			}
		}

		public int InventoryCategoryID
		{
			get
			{
				return this._InventoryCategoryID;
			}
			set
			{
				this._InventoryCategoryID = value;
			}
		}

		public string InventoryCode
		{
			get
			{
				return this._InventoryCode;
			}
			set
			{
				this._InventoryCode = value;
			}
		}

		public long InventoryID
		{
			get
			{
				return this._InventoryID;
			}
			set
			{
				this._InventoryID = value;
			}
		}

		public string InventoryName
		{
			get
			{
				return this._InventoryName;
			}
			set
			{
				this._InventoryName = value;
			}
		}

		public int InventoryPropertyID
		{
			get
			{
				return this._InventoryPropertyID;
			}
			set
			{
				this._InventoryPropertyID = value;
			}
		}

		public long InventorySheetsFrom
		{
			get
			{
				return this._InventorySheetsFrom;
			}
			set
			{
				this._InventorySheetsFrom = value;
			}
		}

		public long InventorySheetsTo
		{
			get
			{
				return this._InventorySheetsTo;
			}
			set
			{
				this._InventorySheetsTo = value;
			}
		}

		public int InventorySubCategoryID
		{
			get
			{
				return this._InventorySubCategoryID;
			}
			set
			{
				this._InventorySubCategoryID = value;
			}
		}

		public decimal InvInStock
		{
			get
			{
				return this._InvInStock;
			}
			set
			{
				this._InvInStock = value;
			}
		}

		public decimal InvLength
		{
			get
			{
				return this._InvLength;
			}
			set
			{
				this._InvLength = value;
			}
		}

		public decimal InvPackedIn
		{
			get
			{
				return this._InvPackedIn;
			}
			set
			{
				this._InvPackedIn = value;
			}
		}

		public decimal InvPerQuantity
		{
			get
			{
				return this._InvPerQuantity;
			}
			set
			{
				this._InvPerQuantity = value;
			}
		}

		public bool IsCoated
		{
			get
			{
				return this._IsCoated;
			}
			set
			{
				this._IsCoated = value;
			}
		}

		public bool IsCoatingType
		{
			get
			{
				return this._IsCoatingType;
			}
			set
			{
				this._IsCoatingType = value;
			}
		}

		public bool IsPrinting
		{
			get
			{
				return this._IsPrinting;
			}
			set
			{
				this._IsPrinting = value;
			}
		}

		public bool IsColor
		{
			get
			{
				return this._IsColor;
			}
			set
			{
				this._IsColor = value;
			}
		}

		public bool IsExposure
		{
			get
			{
				return this._IsExposure;
			}
			set
			{
				this._IsExposure = value;
			}
		}

		public bool IsItemCustomSize
		{
			get
			{
				return this._IsItemCustomSize;
			}
			set
			{
				this._IsItemCustomSize = value;
			}
		}

		public bool IsItemPaperSize
		{
			get
			{
				return this._IsItemPaperSize;
			}
			set
			{
				this._IsItemPaperSize = value;
			}
		}

		public bool IsLargeFormatMaterial
		{
			get
			{
				return this._IsLargeFormatMaterial;
			}
			set
			{
				this._IsLargeFormatMaterial = value;
			}
		}

		public bool IsProcessingCharge
		{
			get
			{
				return this._IsProcessingCharge;
			}
			set
			{
				this._IsProcessingCharge = value;
			}
		}

		public bool IsWeight
		{
			get
			{
				return this._IsWeight;
			}
			set
			{
				this._IsWeight = value;
			}
		}

		public int Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				this._Length = value;
			}
		}

		public string LengthType
		{
			get
			{
				return this._LengthType;
			}
			set
			{
				this._LengthType = value;
			}
		}

		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				this._Location = value;
			}
		}

		public int PackedIn
		{
			get
			{
				return this._PackedIn;
			}
			set
			{
				this._PackedIn = value;
			}
		}

		public string PackedInType
		{
			get
			{
				return this._PackedInType;
			}
			set
			{
				this._PackedInType = value;
			}
		}

		public decimal PackedPrice
		{
			get
			{
				return this._PackedPrice;
			}
			set
			{
				this._PackedPrice = value;
			}
		}

		public int PaperSizeID
		{
			get
			{
				return this._PaperSizeID;
			}
			set
			{
				this._PaperSizeID = value;
			}
		}

		public string PaperType
		{
			get
			{
				return this._PaperType;
			}
			set
			{
				this._PaperType = value;
			}
		}

		public int PerQuantity
		{
			get
			{
				return this._PerQuantity;
			}
			set
			{
				this._PerQuantity = value;
			}
		}

		public decimal ProcessCharge
		{
			get
			{
				return this._ProcessCharge;
			}
			set
			{
				this._ProcessCharge = value;
			}
		}

		public decimal ReOrderLevel
		{
			get
			{
				return this._ReOrderLevel;
			}
			set
			{
				this._ReOrderLevel = value;
			}
		}

		public int ReOrderQuantity
		{
			get
			{
				return this._ReOrderQuantity;
			}
			set
			{
				this._ReOrderQuantity = value;
			}
		}

		public decimal SellingPrice
		{
			get
			{
				return this._SellingPrice;
			}
			set
			{
				this._SellingPrice = value;
			}
		}

		public decimal SetUpCost
		{
			get
			{
				return this._SetUpCost;
			}
			set
			{
				this._SetUpCost = value;
			}
		}

		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

		public string SubCategoryCode
		{
			get
			{
				return this._SubCategoryCode;
			}
			set
			{
				this._SubCategoryCode = value;
			}
		}

		public int SubCategoryID
		{
			get
			{
				return this._SubCategoryID;
			}
			set
			{
				this._SubCategoryID = value;
			}
		}

		public string SubCategoryName
		{
			get
			{
				return this._SubCategoryName;
			}
			set
			{
				this._SubCategoryName = value;
			}
		}

		public new int SupplierID
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

		public int WashupCounter
		{
			get
			{
				return this._WashupCounter;
			}
			set
			{
				this._WashupCounter = value;
			}
		}

		public new decimal Width
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

		public string WidthType
		{
			get
			{
				return this._WidthType;
			}
			set
			{
				this._WidthType = value;
			}
		}

		public decimal Yield
		{
			get
			{
				return this._Yield;
			}
			set
			{
				this._Yield = value;
			}
		}

		public string YieldType
		{
			get
			{
				return this._YieldType;
			}
			set
			{
				this._YieldType = value;
			}
		}
		//Ticket 81174
		public decimal Markup
		{
			get
			{
				return this._Markup;
			}
			set
			{
				this._Markup = value;
			}
		}

		public InventoryItem()
		{
		}
	}
}