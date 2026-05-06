using System;

namespace Printcenter.BusinessAccessLayer.EstimatesNew
{
	public class EstimatesItem
	{
		private int _CompanyID;

		private long _AttachmentTypeID;

		private long _AttachmentID;

		private string _AttachmentType = string.Empty;

		private string _FileName = string.Empty;

		private long _EstNotesID;

		private string _ModuleType = string.Empty;

		private long _ModuleID;

		private string _NotesType = string.Empty;

		private long _EstSingleItemID;

		private long _EstimatePadItemID;

		private long _EstimateSingleItemID;

		private long _EstimateBookletItemID;

		private long _EstimateLithoBookletItemID;

		private long _EstimateLargeItemID;

		private long _EstLithoItemID;

		private long _ParentID;

		private string _BookletType = string.Empty;

		private decimal _NoOfPagesInSection;

		private decimal _PagesPerSignature;

		private decimal _NoOfSignatures;

		private string _BookletFormat = string.Empty;

		private long _EstimateItemID;

		private long _EstQuantityID;

		private long _PressID;

		private char _PressType;

		private long _PaperID;

		private bool _IsPricePerPack;

		private bool _IsPaperSupplied;

        private bool _isFullSheet;

        private decimal _SetupSpoilage;

		private double _PaperUnitPrice;

		private decimal _RunningSpoilage;

		private decimal _LithoBookletRunningSpoilage;

		private string _Colour = string.Empty;

		private string _sidesprinted = string.Empty;

		private string _side1Color = string.Empty;

		private bool _IsDoubleSided;

		private int _PrintSheetSizeID;

		private bool _IsSheetCustom;

		private decimal _SheetHeight;

		private decimal _SheetWidth;

		private int _JobFlatSizeID;

		private bool _IsJobCustom;

		private decimal _JobHeight;

		private decimal _JobWidth;

		private bool _IsIncludeGutters;

		private int _GutterHeight;

		private int _GutterWidth;

		private decimal _GutterHorizontal;

		private decimal _GutterVertical;

		private bool _IsPressRestrictions;

		private char _PrintLayout;

		private decimal _PrintLayoutValue;

		private decimal _PortraitValue;

		private decimal _ManualValue;

		private decimal _LandscapeValue;

		private long _GuillotineID;

		private string _Design = string.Empty;

		private string _Delivery = string.Empty;

		private string _Finishing = string.Empty;

		private string _Notes = string.Empty;

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

		private decimal _LeavesPerPad;

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

		private bool _isCeilPrintSheetPerSection;

		private string _SideColor = string.Empty;

		private decimal _NonImageHeight;

		private decimal _NonImageWidth;

		private bool _IsCompleted;

		private long _ParentItemID;

		private long _PlateID;

		private string _ParentItemType = string.Empty;

		private string _Noofplates = string.Empty;

		private string _NoofMakeReady = string.Empty;

		private string _NoofWashup = string.Empty;

		private decimal _Row;

		private decimal _Col;

		private string _NCRItemTitle = string.Empty;

		private int _NCRQuantity1;

		private int _NCRQuantity2;

		private int _NCRQuantity3;

		private int _NCRQuantity4;

		private decimal _NCRPartsperset;

		private decimal _NCRSetsperpad;

		private string _NCRSectionreference = string.Empty;

		private int _NCRAssignedpress;

		private int _NCRPaperID;

		private string _NCRPaperName = string.Empty;

		private bool _NCRPriceForWhaolePack;

		private bool _NCRPaperSupplied;

		private decimal _NCRSetupspoilage;

		private decimal _NCRRunningspoilage;

		private string _NCRNoofsidesprinted = string.Empty;

		private string _NCRSide1color = string.Empty;

		private string _NCRSide2color = string.Empty;

		private bool _NCRCheckturn;

		private bool _NCRChecktumble;

		private bool _NCRCheckPerfecting;

		private string _NCRPlatename = string.Empty;

		private string _NCRPlateID = string.Empty;

		private string _NCRPlate = string.Empty;

		private string _NCRMakeready = string.Empty;

		private string _NCRWashup = string.Empty;

		private string _NCRPrintSheetSizeID = string.Empty;

		private bool _NCRIsPrintCustom;

		private decimal _NCRPrintSheetHeight;

		private decimal _NCRPrintSheetWidth;

		private int _NCRJobFlatSizeID;

		private bool _NCRIsJobCustom;

		private decimal _NCRJobFlatSizeHeight;

		private decimal _NCRJobFlatSizeWidth;

		private bool _NCRIsIncludeGutters;

		private decimal _NCRGutterHorizontal;

		private decimal _NCRGutterVertical;

		private bool _NCRIsPressRestrictions;

		private int _NCRGuilotineID;

		private string _NCRGuilotineName = string.Empty;

		private bool _NCRIsFirstTrim;

		private bool _NCRIsSecondTrim;

		private string _NCRPrintLayout = string.Empty;

		private decimal _NCRPortraitvalue;

		private decimal _NCRLandscapevalue;

		private string _Ncrcommonuncommon = string.Empty;

		private string _NCRNcommonfrom = string.Empty;

		private int _EstimateLithoNCRItemID;

		private int _EstimateCalculationID;

		private int _NCRInkID;

		private double _NcrInkcoverage;

		private int _Quantity1;

		private int _Quantity2;

		private int _Quantity3;

		private int _Quantity4;

		private decimal _Profitmargin;

		private decimal _Subtotal1;

		private decimal _Subtotal2;

		private decimal _Subtotal3;

		private decimal _Subtotal4;

		private decimal _CostPrice1;

		private decimal _CostPrice2;

		private decimal _CostPrice3;

		private decimal _CostPrice4;

		private decimal _Tax;

		private int _TaxID;

		private decimal _SellingPrice;

		private long _QuickQuoteID;

		private long _EstimateID;

		private int _Iscompleted;

		private decimal _PaperCostExMarkup;

		private decimal _PaperMarkupPrice;

		private decimal _InventorySheets;

		private decimal _PrintSheets;

		private decimal _FirstTrimCuts;

		private decimal _FirstTrimNoOfBundles;

		private decimal _SecondTrimCuts;

		private decimal _SecondTrimNoOfBundles;

		private decimal _PressCostExMarkup;

		private decimal _PressMarkupPrice;

		private decimal _GuillotineCostExMarkup;

		private decimal _GuillotineMarkupPrice;

		private int _Qty;

		private int _Qty1;

		private int _Qty2;

		private int _Qty3;

		private int _Qty4;

		private decimal _PaperMarkup1;

		private decimal _PaperMarkup2;

		private decimal _PaperMarkup3;

		private decimal _PaperMarkup4;

		private decimal _PressMarkUp1;

		private decimal _PressMarkUp2;

		private decimal _PressMarkUp3;

		private decimal _PressMarkUp4;

		private decimal _GuillotineMarkUp1;

		private decimal _GuillotineMarkUp2;

		private decimal _GuillotineMarkUp3;

		private decimal _GuillotineMarkUp4;

		private decimal _PaperCostExMarkup1;

		private decimal _PaperCostExMarkup2;

		private decimal _PaperCostExMarkup3;

		private decimal _PaperCostExMarkup4;

		private decimal _PaperMarkupPrice1;

		private decimal _PaperMarkupPrice2;

		private decimal _PaperMarkupPrice3;

		private decimal _PaperMarkupPrice4;

		private decimal _PaperCostInMarkup1;

		private decimal _PaperCostInMarkup2;

		private decimal _PaperCostInMarkup3;

		private decimal _PaperCostInMarkup4;

		private decimal _InvSheets1;

		private decimal _InvSheets2;

		private decimal _InvSheets3;

		private decimal _InvSheets4;

		private decimal _PrintSheets1;

		private decimal _PrintSheets2;

		private decimal _PrintSheets3;

		private decimal _PrintSheets4;

		private decimal _PressCostExMarkup1;

		private decimal _PressCostExMarkup2;

		private decimal _PressCostExMarkup3;

		private decimal _PressCostExMarkup4;

		private decimal _PressMarkupPrice1;

		private decimal _PressMarkupPrice2;

		private decimal _PressMarkupPrice3;

		private decimal _PressMarkupPrice4;

		private decimal _PressCostInMarkup1;

		private decimal _PressCostInMarkup2;

		private decimal _PressCostInMarkup3;

		private decimal _PressCostInMarkup4;

		private decimal _GuillotineCostInMarkup1;

		private decimal _GuillotineCostInMarkup2;

		private decimal _GuillotineCostInMarkup3;

		private decimal _GuillotineCostInMarkup4;

		private decimal _GuillotineCostExMarkup1;

		private decimal _GuillotineCostExMarkup2;

		private decimal _GuillotineCostExMarkup3;

		private decimal _GuillotineCostExMarkup4;

		private decimal _GuillotineMarkupPrice1;

		private decimal _GuillotineMarkupPrice2;

		private decimal _GuillotineMarkupPrice3;

		private decimal _GuillotineMarkupPrice4;

		private decimal _InkCostExMarkup1;

		private decimal _InkCostExMarkup2;

		private decimal _InkCostExMarkup3;

		private decimal _InkCostExMarkup4;

		private decimal _InkMarkupPrice1;

		private decimal _InkMarkupPrice2;

		private decimal _InkMarkupPrice3;

		private decimal _InkMarkupPrice4;

		private decimal _InkCostInMarkup1;

		private decimal _InkCostInMarkup2;

		private decimal _InkCostInMarkup3;

		private decimal _InkCostInMarkup4;

		private decimal _PlatesCostExMarkup1;

		private decimal _PlatesCostExMarkup2;

		private decimal _PlatesCostExMarkup3;

		private decimal _PlatesCostExMarkup4;

		private decimal _PlatesMarkupPrice1;

		private decimal _PlatesMarkupPrice2;

		private decimal _PlatesMarkupPrice3;

		private decimal _PlatesMarkupPrice4;

		private decimal _PlatesCostInMarkup1;

		private decimal _PlatesCostInMarkup2;

		private decimal _PlatesCostInMarkup3;

		private decimal _PlatesCostInMarkup4;

		private decimal _MakeReadyCostExMarkup1;

		private decimal _MakeReadyCostExMarkup2;

		private decimal _MakeReadyCostExMarkup3;

		private decimal _MakeReadyCostExMarkup4;

		private decimal _MakeReadyMarkupPrice1;

		private decimal _MakeReadyMarkupPrice2;

		private decimal _MakeReadyMarkupPrice3;

		private decimal _MakeReadyMarkupPrice4;

		private decimal _MakeReadyCostInMarkup1;

		private decimal _MakeReadyCostInMarkup2;

		private decimal _MakeReadyCostInMarkup3;

		private decimal _MakeReadyCostInMarkup4;

		private decimal _WashUpCostExMarkup1;

		private decimal _WashUpCostExMarkup2;

		private decimal _WashUpCostExMarkup3;

		private decimal _WashUpCostExMarkup4;

		private decimal _WashUpMarkupPrice1;

		private decimal _WashUpMarkupPrice2;

		private decimal _WashUpMarkupPrice3;

		private decimal _WashUpMarkupPrice4;

		private decimal _WashUpCostInMarkup1;

		private decimal _WashUpCostInMarkup2;

		private decimal _WashUpCostInMarkup3;

		private decimal _WashUpCostInMarkup4;

		private decimal _FirstTrimCuts1;

		private decimal _FirstTrimCuts2;

		private decimal _FirstTrimCuts3;

		private decimal _FirstTrimCuts4;

		private decimal _FirstTrimNoOfBundles1;

		private decimal _FirstTrimNoOfBundles2;

		private decimal _FirstTrimNoOfBundles3;

		private decimal _FirstTrimNoOfBundles4;

		private decimal _SecondTrimCuts1;

		private decimal _SecondTrimCuts2;

		private decimal _SecondTrimCuts3;

		private decimal _SecondTrimCuts4;

		private decimal _SecondTrimNoOfBundles1;

		private decimal _SecondTrimNoOfBundles2;

		private decimal _SecondTrimNoOfBundles3;

		private decimal _SecondTrimNoOfBundles4;

		private decimal _CostPriceExMarkup1;

		private decimal _CostPriceExMarkup2;

		private decimal _CostPriceExMarkup3;

		private decimal _CostPriceExMarkup4;

		private decimal _MarkupPrice1;

		private decimal _MarkupPrice2;

		private decimal _MarkupPrice3;

		private decimal _MarkupPrice4;

		private decimal _CostPriceInMarkup1;

		private decimal _CostPriceInMarkup2;

		private decimal _CostPriceInMarkup3;

		private decimal _CostPriceInMarkup4;

		private decimal _AdditionalItemsCostExMarkup1;

		private decimal _AdditionalItemsCostExMarkup2;

		private decimal _AdditionalItemsCostExMarkup3;

		private decimal _AdditionalItemsCostExMarkup4;

		private decimal _AdditionalItemsMarkupPrice1;

		private decimal _AdditionalItemsMarkupPrice2;

		private decimal _AdditionalItemsMarkupPrice3;

		private decimal _AdditionalItemsMarkupPrice4;

		private decimal _ProfitMargin1;

		private decimal _ProfitMargin2;

		private decimal _ProfitMargin3;

		private decimal _ProfitMargin4;

		private decimal _ProfitMarginPrice1;

		private decimal _ProfitMarginPrice2;

		private decimal _ProfitMarginPrice3;

		private decimal _ProfitMarginPrice4;

		private decimal _TaxRate1;

		private decimal _TaxRate2;

		private decimal _TaxRate3;

		private decimal _TaxRate4;

		private decimal _SubTotal1;

		private decimal _SubTotal2;

		private decimal _SubTotal3;

		private decimal _SubTotal4;

		private decimal _TaxPrice1;

		private decimal _TaxPrice2;

		private decimal _TaxPrice3;

		private decimal _TaxPrice4;

		private decimal _SellingPrice1;

		private decimal _SellingPrice2;

		private decimal _SellingPrice3;

		private decimal _SellingPrice4;

		private decimal _GrossProfitPercentage1;

		private decimal _GrossProfitPercentage2;

		private decimal _GrossProfitPercentage3;

		private decimal _GrossProfitPercentage4;

		private decimal _GrossProfitPrice1;

		private decimal _GrossProfitPrice2;

		private decimal _GrossProfitPrice3;

		private decimal _GrossProfitPrice4;

		private string _PricePerUnitOfMeasure1 = string.Empty;

		private string _PricePerUnitOfMeasure2 = string.Empty;

		private string _PricePerUnitOfMeasure3 = string.Empty;

		private string _PricePerUnitOfMeasure4 = string.Empty;

		private string _SupplierName1 = string.Empty;

		private string _SupplierName2 = string.Empty;

		private string _SupplierName3 = string.Empty;

		private string _SupplierName4 = string.Empty;

		private string _SupplierQuoteNo1 = string.Empty;

		private string _SupplierQuoteNo2 = string.Empty;

		private string _SupplierQuoteNo3 = string.Empty;

		private string _SupplierQuoteNo4 = string.Empty;

		private decimal _OutworkDeliveryCost1;

		private decimal _OutworkDeliveryCost2;

		private decimal _OutworkDeliveryCost3;

		private decimal _OutworkDeliveryCost4;

		private string _OutworkMarkupType1 = string.Empty;

		private string _OutworkMarkupType2 = string.Empty;

		private string _OutworkMarkupType3 = string.Empty;

		private string _OutworkMarkupType4 = string.Empty;

		private decimal _MultipleOf;

		private decimal _AllQty1;

		private decimal _AllQty2;

		private decimal _AllQty3;

		private decimal _AllQty4;

		private decimal _AllPaperCostExMarkup1;

		private decimal _AllPaperCostExMarkup2;

		private decimal _AllPaperCostExMarkup3;

		private decimal _AllPaperCostExMarkup4;

		private decimal _AllPaperMarkupPrice1;

		private decimal _AllPaperMarkupPrice2;

		private decimal _AllPaperMarkupPrice3;

		private decimal _AllPaperMarkupPrice4;

		private decimal _AllPaperCostInMarkup1;

		private decimal _AllPaperCostInMarkup2;

		private decimal _AllPaperCostInMarkup3;

		private decimal _AllPaperCostInMarkup4;

		private decimal _AllPressCostExMarkup1;

		private decimal _AllPressCostExMarkup2;

		private decimal _AllPressCostExMarkup3;

		private decimal _AllPressCostExMarkup4;

		private decimal _AllPressMarkupPrice1;

		private decimal _AllPressMarkupPrice2;

		private decimal _AllPressMarkupPrice3;

		private decimal _AllPressMarkupPrice4;

		private decimal _AllPressCostInMarkup1;

		private decimal _AllPressCostInMarkup2;

		private decimal _AllPressCostInMarkup3;

		private decimal _AllPressCostInMarkup4;

		private decimal _AllGuillotineCostExMarkup1;

		private decimal _AllGuillotineCostExMarkup2;

		private decimal _AllGuillotineCostExMarkup3;

		private decimal _AllGuillotineCostExMarkup4;

		private decimal _AllGuillotineMarkupPrice1;

		private decimal _AllGuillotineMarkupPrice2;

		private decimal _AllGuillotineMarkupPrice3;

		private decimal _AllGuillotineMarkupPrice4;

		private decimal _AllGuillotineCostInMarkup1;

		private decimal _AllGuillotineCostInMarkup2;

		private decimal _AllGuillotineCostInMarkup3;

		private decimal _AllGuillotineCostInMarkup4;

		private long _MaterialID2;

		private long _MaterialID3;

		private long _MaterialID4;

		private long _MaterialID5;

		private bool _IsPricePerPack2;

		private bool _IsPaperSupplied2;

		private bool _IsPricePerPack3;

		private bool _IsPaperSupplied3;

		private bool _IsPricePerPack4;

		private bool _IsPaperSupplied4;

		private bool _IsPricePerPack5;

		private bool _IsPaperSupplied5;

		private string _CalculationType = string.Empty;

		private string _MatrixType = string.Empty;

		private decimal _Dimension1;

		private decimal _Dimension2;

		private decimal _Dimension3;

		private decimal _Dimension4;

		private decimal _Width1;

		private decimal _Width2;

		private decimal _Width3;

		private decimal _Width4;

		private decimal _Height1;

		private decimal _Height2;

		private decimal _Height3;

		private decimal _Height4;

		private string _Qtydesc = string.Empty;

		private string _Qtydesc1 = string.Empty;

		private string _Qtydesc2 = string.Empty;

		private string _Qtydesc3 = string.Empty;

		private string _Qtydesc4 = string.Empty;

		private decimal _WhiteInkCoverageSide1;

		private decimal _WhiteInkCoverageSide2;

		private int _DPI;

		private bool _NCRChkSheetWork;

		public decimal AdditionalItemsCostExMarkup1
		{
			get
			{
				return this._AdditionalItemsCostExMarkup1;
			}
			set
			{
				this._AdditionalItemsCostExMarkup1 = value;
			}
		}

		public decimal AdditionalItemsCostExMarkup2
		{
			get
			{
				return this._AdditionalItemsCostExMarkup2;
			}
			set
			{
				this._AdditionalItemsCostExMarkup2 = value;
			}
		}

		public decimal AdditionalItemsCostExMarkup3
		{
			get
			{
				return this._AdditionalItemsCostExMarkup3;
			}
			set
			{
				this._AdditionalItemsCostExMarkup3 = value;
			}
		}

		public decimal AdditionalItemsCostExMarkup4
		{
			get
			{
				return this._AdditionalItemsCostExMarkup4;
			}
			set
			{
				this._AdditionalItemsCostExMarkup4 = value;
			}
		}

		public decimal AdditionalItemsMarkupPrice1
		{
			get
			{
				return this._AdditionalItemsMarkupPrice1;
			}
			set
			{
				this._AdditionalItemsMarkupPrice1 = value;
			}
		}

		public decimal AdditionalItemsMarkupPrice2
		{
			get
			{
				return this._AdditionalItemsMarkupPrice2;
			}
			set
			{
				this._AdditionalItemsMarkupPrice2 = value;
			}
		}

		public decimal AdditionalItemsMarkupPrice3
		{
			get
			{
				return this._AdditionalItemsMarkupPrice3;
			}
			set
			{
				this._AdditionalItemsMarkupPrice3 = value;
			}
		}

		public decimal AdditionalItemsMarkupPrice4
		{
			get
			{
				return this._AdditionalItemsMarkupPrice4;
			}
			set
			{
				this._AdditionalItemsMarkupPrice4 = value;
			}
		}

		public decimal AllGuillotineCostExMarkup1
		{
			get
			{
				return this._AllGuillotineCostExMarkup1;
			}
			set
			{
				this._AllGuillotineCostExMarkup1 = value;
			}
		}

		public decimal AllGuillotineCostExMarkup2
		{
			get
			{
				return this._AllGuillotineCostExMarkup2;
			}
			set
			{
				this._AllGuillotineCostExMarkup2 = value;
			}
		}

		public decimal AllGuillotineCostExMarkup3
		{
			get
			{
				return this._AllGuillotineCostExMarkup3;
			}
			set
			{
				this._AllGuillotineCostExMarkup3 = value;
			}
		}

		public decimal AllGuillotineCostExMarkup4
		{
			get
			{
				return this._AllGuillotineCostExMarkup4;
			}
			set
			{
				this._AllGuillotineCostExMarkup4 = value;
			}
		}

		public decimal AllGuillotineCostInMarkup1
		{
			get
			{
				return this._AllGuillotineCostInMarkup1;
			}
			set
			{
				this._AllGuillotineCostInMarkup1 = value;
			}
		}

		public decimal AllGuillotineCostInMarkup2
		{
			get
			{
				return this._AllGuillotineCostInMarkup2;
			}
			set
			{
				this._AllGuillotineCostInMarkup2 = value;
			}
		}

		public decimal AllGuillotineCostInMarkup3
		{
			get
			{
				return this._AllGuillotineCostInMarkup3;
			}
			set
			{
				this._AllGuillotineCostInMarkup3 = value;
			}
		}

		public decimal AllGuillotineCostInMarkup4
		{
			get
			{
				return this._AllGuillotineCostInMarkup4;
			}
			set
			{
				this._AllGuillotineCostInMarkup4 = value;
			}
		}

		public decimal AllGuillotineMarkupPrice1
		{
			get
			{
				return this._AllGuillotineMarkupPrice1;
			}
			set
			{
				this._AllGuillotineMarkupPrice1 = value;
			}
		}

		public decimal AllGuillotineMarkupPrice2
		{
			get
			{
				return this._AllGuillotineMarkupPrice2;
			}
			set
			{
				this._AllGuillotineMarkupPrice2 = value;
			}
		}

		public decimal AllGuillotineMarkupPrice3
		{
			get
			{
				return this._AllGuillotineMarkupPrice3;
			}
			set
			{
				this._AllGuillotineMarkupPrice3 = value;
			}
		}

		public decimal AllGuillotineMarkupPrice4
		{
			get
			{
				return this._AllGuillotineMarkupPrice4;
			}
			set
			{
				this._AllGuillotineMarkupPrice4 = value;
			}
		}

		public decimal AllPaperCostExMarkup1
		{
			get
			{
				return this._AllPaperCostExMarkup1;
			}
			set
			{
				this._AllPaperCostExMarkup1 = value;
			}
		}

		public decimal AllPaperCostExMarkup2
		{
			get
			{
				return this._AllPaperCostExMarkup2;
			}
			set
			{
				this._AllPaperCostExMarkup2 = value;
			}
		}

		public decimal AllPaperCostExMarkup3
		{
			get
			{
				return this._AllPaperCostExMarkup3;
			}
			set
			{
				this._AllPaperCostExMarkup3 = value;
			}
		}

		public decimal AllPaperCostExMarkup4
		{
			get
			{
				return this._AllPaperCostExMarkup4;
			}
			set
			{
				this._AllPaperCostExMarkup4 = value;
			}
		}

		public decimal AllPaperCostInMarkup1
		{
			get
			{
				return this._AllPaperCostInMarkup1;
			}
			set
			{
				this._AllPaperCostInMarkup1 = value;
			}
		}

		public decimal AllPaperCostInMarkup2
		{
			get
			{
				return this._AllPaperCostInMarkup2;
			}
			set
			{
				this._AllPaperCostInMarkup2 = value;
			}
		}

		public decimal AllPaperCostInMarkup3
		{
			get
			{
				return this._AllPaperCostInMarkup3;
			}
			set
			{
				this._AllPaperCostInMarkup3 = value;
			}
		}

		public decimal AllPaperCostInMarkup4
		{
			get
			{
				return this._AllPaperCostInMarkup4;
			}
			set
			{
				this._AllPaperCostInMarkup4 = value;
			}
		}

		public decimal AllPaperMarkupPrice1
		{
			get
			{
				return this._AllPaperMarkupPrice1;
			}
			set
			{
				this._AllPaperMarkupPrice1 = value;
			}
		}

		public decimal AllPaperMarkupPrice2
		{
			get
			{
				return this._AllPaperMarkupPrice2;
			}
			set
			{
				this._AllPaperMarkupPrice2 = value;
			}
		}

		public decimal AllPaperMarkupPrice3
		{
			get
			{
				return this._AllPaperMarkupPrice3;
			}
			set
			{
				this._AllPaperMarkupPrice3 = value;
			}
		}

		public decimal AllPaperMarkupPrice4
		{
			get
			{
				return this._AllPaperMarkupPrice4;
			}
			set
			{
				this._AllPaperMarkupPrice4 = value;
			}
		}

		public decimal AllPressCostExMarkup1
		{
			get
			{
				return this._AllPressCostExMarkup1;
			}
			set
			{
				this._AllPressCostExMarkup1 = value;
			}
		}

		public decimal AllPressCostExMarkup2
		{
			get
			{
				return this._AllPressCostExMarkup2;
			}
			set
			{
				this._AllPressCostExMarkup2 = value;
			}
		}

		public decimal AllPressCostExMarkup3
		{
			get
			{
				return this._AllPressCostExMarkup3;
			}
			set
			{
				this._AllPressCostExMarkup3 = value;
			}
		}

		public decimal AllPressCostExMarkup4
		{
			get
			{
				return this._AllPressCostExMarkup4;
			}
			set
			{
				this._AllPressCostExMarkup4 = value;
			}
		}

		public decimal AllPressCostInMarkup1
		{
			get
			{
				return this._AllPressCostInMarkup1;
			}
			set
			{
				this._AllPressCostInMarkup1 = value;
			}
		}

		public decimal AllPressCostInMarkup2
		{
			get
			{
				return this._AllPressCostInMarkup2;
			}
			set
			{
				this._AllPressCostInMarkup2 = value;
			}
		}

		public decimal AllPressCostInMarkup3
		{
			get
			{
				return this._AllPressCostInMarkup3;
			}
			set
			{
				this._AllPressCostInMarkup3 = value;
			}
		}

		public decimal AllPressCostInMarkup4
		{
			get
			{
				return this._AllPressCostInMarkup4;
			}
			set
			{
				this._AllPressCostInMarkup4 = value;
			}
		}

		public decimal AllPressMarkupPrice1
		{
			get
			{
				return this._AllPressMarkupPrice1;
			}
			set
			{
				this._AllPressMarkupPrice1 = value;
			}
		}

		public decimal AllPressMarkupPrice2
		{
			get
			{
				return this._AllPressMarkupPrice2;
			}
			set
			{
				this._AllPressMarkupPrice2 = value;
			}
		}

		public decimal AllPressMarkupPrice3
		{
			get
			{
				return this._AllPressMarkupPrice3;
			}
			set
			{
				this._AllPressMarkupPrice3 = value;
			}
		}

		public decimal AllPressMarkupPrice4
		{
			get
			{
				return this._AllPressMarkupPrice4;
			}
			set
			{
				this._AllPressMarkupPrice4 = value;
			}
		}

		public decimal AllQty1
		{
			get
			{
				return this._AllQty1;
			}
			set
			{
				this._AllQty1 = value;
			}
		}

		public decimal AllQty2
		{
			get
			{
				return this._AllQty2;
			}
			set
			{
				this._AllQty2 = value;
			}
		}

		public decimal AllQty3
		{
			get
			{
				return this._AllQty3;
			}
			set
			{
				this._AllQty3 = value;
			}
		}

		public decimal AllQty4
		{
			get
			{
				return this._AllQty4;
			}
			set
			{
				this._AllQty4 = value;
			}
		}

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

		public string BookletFormat
		{
			get
			{
				return this._BookletFormat;
			}
			set
			{
				this._BookletFormat = value;
			}
		}

		public string BookletType
		{
			get
			{
				return this._BookletType;
			}
			set
			{
				this._BookletType = value;
			}
		}

		public string CalculationType
		{
			get
			{
				return this._CalculationType;
			}
			set
			{
				this._CalculationType = value;
			}
		}

		public decimal Col
		{
			get
			{
				return this._Col;
			}
			set
			{
				this._Col = value;
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

		public decimal CostPrice1
		{
			get
			{
				return this._CostPrice1;
			}
			set
			{
				this._CostPrice1 = value;
			}
		}

		public decimal CostPrice2
		{
			get
			{
				return this._CostPrice2;
			}
			set
			{
				this._CostPrice2 = value;
			}
		}

		public decimal CostPrice3
		{
			get
			{
				return this._CostPrice3;
			}
			set
			{
				this._CostPrice3 = value;
			}
		}

		public decimal CostPrice4
		{
			get
			{
				return this._CostPrice4;
			}
			set
			{
				this._CostPrice4 = value;
			}
		}

		public decimal CostPriceExMarkup1
		{
			get
			{
				return this._CostPriceExMarkup1;
			}
			set
			{
				this._CostPriceExMarkup1 = value;
			}
		}

		public decimal CostPriceExMarkup2
		{
			get
			{
				return this._CostPriceExMarkup2;
			}
			set
			{
				this._CostPriceExMarkup2 = value;
			}
		}

		public decimal CostPriceExMarkup3
		{
			get
			{
				return this._CostPriceExMarkup3;
			}
			set
			{
				this._CostPriceExMarkup3 = value;
			}
		}

		public decimal CostPriceExMarkup4
		{
			get
			{
				return this._CostPriceExMarkup4;
			}
			set
			{
				this._CostPriceExMarkup4 = value;
			}
		}

		public decimal CostPriceInMarkup1
		{
			get
			{
				return this._CostPriceInMarkup1;
			}
			set
			{
				this._CostPriceInMarkup1 = value;
			}
		}

		public decimal CostPriceInMarkup2
		{
			get
			{
				return this._CostPriceInMarkup2;
			}
			set
			{
				this._CostPriceInMarkup2 = value;
			}
		}

		public decimal CostPriceInMarkup3
		{
			get
			{
				return this._CostPriceInMarkup3;
			}
			set
			{
				this._CostPriceInMarkup3 = value;
			}
		}

		public decimal CostPriceInMarkup4
		{
			get
			{
				return this._CostPriceInMarkup4;
			}
			set
			{
				this._CostPriceInMarkup4 = value;
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

		public decimal Dimension1
		{
			get
			{
				return this._Dimension1;
			}
			set
			{
				this._Dimension1 = value;
			}
		}

		public decimal Dimension2
		{
			get
			{
				return this._Dimension2;
			}
			set
			{
				this._Dimension2 = value;
			}
		}

		public decimal Dimension3
		{
			get
			{
				return this._Dimension3;
			}
			set
			{
				this._Dimension3 = value;
			}
		}

		public decimal Dimension4
		{
			get
			{
				return this._Dimension4;
			}
			set
			{
				this._Dimension4 = value;
			}
		}

		public int DPI
		{
			get
			{
				return this._DPI;
			}
			set
			{
				this._DPI = value;
			}
		}

		public long EstimateBookletItemID
		{
			get
			{
				return this._EstimateBookletItemID;
			}
			set
			{
				this._EstimateBookletItemID = value;
			}
		}

		public int EstimateCalculationID
		{
			get
			{
				return this._EstimateCalculationID;
			}
			set
			{
				this._EstimateCalculationID = value;
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

		public long EstimateLargeItemID
		{
			get
			{
				return this._EstimateLargeItemID;
			}
			set
			{
				this._EstimateLargeItemID = value;
			}
		}

		public long EstimateLithoBookletItemID
		{
			get
			{
				return this._EstimateLithoBookletItemID;
			}
			set
			{
				this._EstimateLithoBookletItemID = value;
			}
		}

		public int EstimateLithoNCRItemID
		{
			get
			{
				return this._EstimateLithoNCRItemID;
			}
			set
			{
				this._EstimateLithoNCRItemID = value;
			}
		}

		public long EstimatePadItemID
		{
			get
			{
				return this._EstimatePadItemID;
			}
			set
			{
				this._EstimatePadItemID = value;
			}
		}

		public long EstimateSingleItemID
		{
			get
			{
				return this._EstimateSingleItemID;
			}
			set
			{
				this._EstimateSingleItemID = value;
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

		public long EstLithoItemID
		{
			get
			{
				return this._EstLithoItemID;
			}
			set
			{
				this._EstLithoItemID = value;
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

		public decimal FirstTrimCuts
		{
			get
			{
				return this._FirstTrimCuts;
			}
			set
			{
				this._FirstTrimCuts = value;
			}
		}

		public decimal FirstTrimCuts1
		{
			get
			{
				return this._FirstTrimCuts1;
			}
			set
			{
				this._FirstTrimCuts1 = value;
			}
		}

		public decimal FirstTrimCuts2
		{
			get
			{
				return this._FirstTrimCuts2;
			}
			set
			{
				this._FirstTrimCuts2 = value;
			}
		}

		public decimal FirstTrimCuts3
		{
			get
			{
				return this._FirstTrimCuts3;
			}
			set
			{
				this._FirstTrimCuts3 = value;
			}
		}

		public decimal FirstTrimCuts4
		{
			get
			{
				return this._FirstTrimCuts4;
			}
			set
			{
				this._FirstTrimCuts4 = value;
			}
		}

		public decimal FirstTrimNoOfBundles
		{
			get
			{
				return this._FirstTrimNoOfBundles;
			}
			set
			{
				this._FirstTrimNoOfBundles = value;
			}
		}

		public decimal FirstTrimNoOfBundles1
		{
			get
			{
				return this._FirstTrimNoOfBundles1;
			}
			set
			{
				this._FirstTrimNoOfBundles1 = value;
			}
		}

		public decimal FirstTrimNoOfBundles2
		{
			get
			{
				return this._FirstTrimNoOfBundles2;
			}
			set
			{
				this._FirstTrimNoOfBundles2 = value;
			}
		}

		public decimal FirstTrimNoOfBundles3
		{
			get
			{
				return this._FirstTrimNoOfBundles3;
			}
			set
			{
				this._FirstTrimNoOfBundles3 = value;
			}
		}

		public decimal FirstTrimNoOfBundles4
		{
			get
			{
				return this._FirstTrimNoOfBundles4;
			}
			set
			{
				this._FirstTrimNoOfBundles4 = value;
			}
		}

		public decimal GrossProfitPercentage1
		{
			get
			{
				return this._GrossProfitPercentage1;
			}
			set
			{
				this._GrossProfitPercentage1 = value;
			}
		}

		public decimal GrossProfitPercentage2
		{
			get
			{
				return this._GrossProfitPercentage2;
			}
			set
			{
				this._GrossProfitPercentage2 = value;
			}
		}

		public decimal GrossProfitPercentage3
		{
			get
			{
				return this._GrossProfitPercentage3;
			}
			set
			{
				this._GrossProfitPercentage3 = value;
			}
		}

		public decimal GrossProfitPercentage4
		{
			get
			{
				return this._GrossProfitPercentage4;
			}
			set
			{
				this._GrossProfitPercentage4 = value;
			}
		}

		public decimal GrossProfitPrice1
		{
			get
			{
				return this._GrossProfitPrice1;
			}
			set
			{
				this._GrossProfitPrice1 = value;
			}
		}

		public decimal GrossProfitPrice2
		{
			get
			{
				return this._GrossProfitPrice2;
			}
			set
			{
				this._GrossProfitPrice2 = value;
			}
		}

		public decimal GrossProfitPrice3
		{
			get
			{
				return this._GrossProfitPrice3;
			}
			set
			{
				this._GrossProfitPrice3 = value;
			}
		}

		public decimal GrossProfitPrice4
		{
			get
			{
				return this._GrossProfitPrice4;
			}
			set
			{
				this._GrossProfitPrice4 = value;
			}
		}

		public decimal GuillotineCostExMarkup
		{
			get
			{
				return this._GuillotineCostExMarkup;
			}
			set
			{
				this._GuillotineCostExMarkup = value;
			}
		}

		public decimal GuillotineCostExMarkup1
		{
			get
			{
				return this._GuillotineCostExMarkup1;
			}
			set
			{
				this._GuillotineCostExMarkup1 = value;
			}
		}

		public decimal GuillotineCostExMarkup2
		{
			get
			{
				return this._GuillotineCostExMarkup2;
			}
			set
			{
				this._GuillotineCostExMarkup2 = value;
			}
		}

		public decimal GuillotineCostExMarkup3
		{
			get
			{
				return this._GuillotineCostExMarkup3;
			}
			set
			{
				this._GuillotineCostExMarkup3 = value;
			}
		}

		public decimal GuillotineCostExMarkup4
		{
			get
			{
				return this._GuillotineCostExMarkup4;
			}
			set
			{
				this._GuillotineCostExMarkup4 = value;
			}
		}

		public decimal GuillotineCostInMarkup1
		{
			get
			{
				return this._GuillotineCostInMarkup1;
			}
			set
			{
				this._GuillotineCostInMarkup1 = value;
			}
		}

		public decimal GuillotineCostInMarkup2
		{
			get
			{
				return this._GuillotineCostInMarkup2;
			}
			set
			{
				this._GuillotineCostInMarkup2 = value;
			}
		}

		public decimal GuillotineCostInMarkup3
		{
			get
			{
				return this._GuillotineCostInMarkup3;
			}
			set
			{
				this._GuillotineCostInMarkup3 = value;
			}
		}

		public decimal GuillotineCostInMarkup4
		{
			get
			{
				return this._GuillotineCostInMarkup4;
			}
			set
			{
				this._GuillotineCostInMarkup4 = value;
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

		public decimal GuillotineMarkUp1
		{
			get
			{
				return this._GuillotineMarkUp1;
			}
			set
			{
				this._GuillotineMarkUp1 = value;
			}
		}

		public decimal GuillotineMarkUp2
		{
			get
			{
				return this._GuillotineMarkUp2;
			}
			set
			{
				this._GuillotineMarkUp2 = value;
			}
		}

		public decimal GuillotineMarkUp3
		{
			get
			{
				return this._GuillotineMarkUp3;
			}
			set
			{
				this._GuillotineMarkUp3 = value;
			}
		}

		public decimal GuillotineMarkUp4
		{
			get
			{
				return this._GuillotineMarkUp4;
			}
			set
			{
				this._GuillotineMarkUp4 = value;
			}
		}

		public decimal GuillotineMarkupPrice
		{
			get
			{
				return this._GuillotineMarkupPrice;
			}
			set
			{
				this._GuillotineMarkupPrice = value;
			}
		}

		public decimal GuillotineMarkupPrice1
		{
			get
			{
				return this._GuillotineMarkupPrice1;
			}
			set
			{
				this._GuillotineMarkupPrice1 = value;
			}
		}

		public decimal GuillotineMarkupPrice2
		{
			get
			{
				return this._GuillotineMarkupPrice2;
			}
			set
			{
				this._GuillotineMarkupPrice2 = value;
			}
		}

		public decimal GuillotineMarkupPrice3
		{
			get
			{
				return this._GuillotineMarkupPrice3;
			}
			set
			{
				this._GuillotineMarkupPrice3 = value;
			}
		}

		public decimal GuillotineMarkupPrice4
		{
			get
			{
				return this._GuillotineMarkupPrice4;
			}
			set
			{
				this._GuillotineMarkupPrice4 = value;
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

		public decimal GutterHorizontal
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

		public decimal GutterVertical
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

		public decimal Height1
		{
			get
			{
				return this._Height1;
			}
			set
			{
				this._Height1 = value;
			}
		}

		public decimal Height2
		{
			get
			{
				return this._Height2;
			}
			set
			{
				this._Height2 = value;
			}
		}

		public decimal Height3
		{
			get
			{
				return this._Height3;
			}
			set
			{
				this._Height3 = value;
			}
		}

		public decimal Height4
		{
			get
			{
				return this._Height4;
			}
			set
			{
				this._Height4 = value;
			}
		}

		public decimal InkCostExMarkup1
		{
			get
			{
				return this._InkCostExMarkup1;
			}
			set
			{
				this._InkCostExMarkup1 = value;
			}
		}

		public decimal InkCostExMarkup2
		{
			get
			{
				return this._InkCostExMarkup2;
			}
			set
			{
				this._InkCostExMarkup2 = value;
			}
		}

		public decimal InkCostExMarkup3
		{
			get
			{
				return this._InkCostExMarkup3;
			}
			set
			{
				this._InkCostExMarkup3 = value;
			}
		}

		public decimal InkCostExMarkup4
		{
			get
			{
				return this._InkCostExMarkup4;
			}
			set
			{
				this._InkCostExMarkup4 = value;
			}
		}

		public decimal InkCostInMarkup1
		{
			get
			{
				return this._InkCostInMarkup1;
			}
			set
			{
				this._InkCostInMarkup1 = value;
			}
		}

		public decimal InkCostInMarkup2
		{
			get
			{
				return this._InkCostInMarkup2;
			}
			set
			{
				this._InkCostInMarkup2 = value;
			}
		}

		public decimal InkCostInMarkup3
		{
			get
			{
				return this._InkCostInMarkup3;
			}
			set
			{
				this._InkCostInMarkup3 = value;
			}
		}

		public decimal InkCostInMarkup4
		{
			get
			{
				return this._InkCostInMarkup4;
			}
			set
			{
				this._InkCostInMarkup4 = value;
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

		public decimal InkMarkupPrice1
		{
			get
			{
				return this._InkMarkupPrice1;
			}
			set
			{
				this._InkMarkupPrice1 = value;
			}
		}

		public decimal InkMarkupPrice2
		{
			get
			{
				return this._InkMarkupPrice2;
			}
			set
			{
				this._InkMarkupPrice2 = value;
			}
		}

		public decimal InkMarkupPrice3
		{
			get
			{
				return this._InkMarkupPrice3;
			}
			set
			{
				this._InkMarkupPrice3 = value;
			}
		}

		public decimal InkMarkupPrice4
		{
			get
			{
				return this._InkMarkupPrice4;
			}
			set
			{
				this._InkMarkupPrice4 = value;
			}
		}

		public decimal InventorySheets
		{
			get
			{
				return this._InventorySheets;
			}
			set
			{
				this._InventorySheets = value;
			}
		}

		public decimal InvSheets1
		{
			get
			{
				return this._InvSheets1;
			}
			set
			{
				this._InvSheets1 = value;
			}
		}

		public decimal InvSheets2
		{
			get
			{
				return this._InvSheets2;
			}
			set
			{
				this._InvSheets2 = value;
			}
		}

		public decimal InvSheets3
		{
			get
			{
				return this._InvSheets3;
			}
			set
			{
				this._InvSheets3 = value;
			}
		}

		public decimal InvSheets4
		{
			get
			{
				return this._InvSheets4;
			}
			set
			{
				this._InvSheets4 = value;
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

		public bool isCeilPrintSheetPerSection
		{
			get
			{
				return this._isCeilPrintSheetPerSection;
			}
			set
			{
				this._isCeilPrintSheetPerSection = value;
			}
		}

		public int Iscompleted
		{
			get
			{
				return this._Iscompleted;
			}
			set
			{
				this._Iscompleted = value;
			}
		}

		public bool IsCompleted
		{
			get
			{
				return this._IsCompleted;
			}
			set
			{
				this._IsCompleted = value;
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

		public bool IsPaperSupplied2
		{
			get
			{
				return this._IsPaperSupplied2;
			}
			set
			{
				this._IsPaperSupplied2 = value;
			}
		}

		public bool IsPaperSupplied3
		{
			get
			{
				return this._IsPaperSupplied3;
			}
			set
			{
				this._IsPaperSupplied3 = value;
			}
		}

		public bool IsPaperSupplied4
		{
			get
			{
				return this._IsPaperSupplied4;
			}
			set
			{
				this._IsPaperSupplied4 = value;
			}
		}

		public bool IsPaperSupplied5
		{
			get
			{
				return this._IsPaperSupplied5;
			}
			set
			{
				this._IsPaperSupplied5 = value;
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

        public bool isFullSheet
        {
            get
            {
                return this._isFullSheet;
            }
            set
            {
                this._isFullSheet = value;
            }
        }

        public bool IsPricePerPack2
		{
			get
			{
				return this._IsPricePerPack2;
			}
			set
			{
				this._IsPricePerPack2 = value;
			}
		}

		public bool IsPricePerPack3
		{
			get
			{
				return this._IsPricePerPack3;
			}
			set
			{
				this._IsPricePerPack3 = value;
			}
		}

		public bool IsPricePerPack4
		{
			get
			{
				return this._IsPricePerPack4;
			}
			set
			{
				this._IsPricePerPack4 = value;
			}
		}

		public bool IsPricePerPack5
		{
			get
			{
				return this._IsPricePerPack5;
			}
			set
			{
				this._IsPricePerPack5 = value;
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

		public decimal JobHeight
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

		public decimal JobWidth
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

		public decimal LandscapeValue
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

		public decimal LeavesPerPad
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

		public decimal LithoBookletRunningSpoilage
		{
			get
			{
				return this._LithoBookletRunningSpoilage;
			}
			set
			{
				this._LithoBookletRunningSpoilage = value;
			}
		}

		public decimal MakeReadyCostExMarkup1
		{
			get
			{
				return this._MakeReadyCostExMarkup1;
			}
			set
			{
				this._MakeReadyCostExMarkup1 = value;
			}
		}

		public decimal MakeReadyCostExMarkup2
		{
			get
			{
				return this._MakeReadyCostExMarkup2;
			}
			set
			{
				this._MakeReadyCostExMarkup2 = value;
			}
		}

		public decimal MakeReadyCostExMarkup3
		{
			get
			{
				return this._MakeReadyCostExMarkup3;
			}
			set
			{
				this._MakeReadyCostExMarkup3 = value;
			}
		}

		public decimal MakeReadyCostExMarkup4
		{
			get
			{
				return this._MakeReadyCostExMarkup4;
			}
			set
			{
				this._MakeReadyCostExMarkup4 = value;
			}
		}

		public decimal MakeReadyCostInMarkup1
		{
			get
			{
				return this._MakeReadyCostInMarkup1;
			}
			set
			{
				this._MakeReadyCostInMarkup1 = value;
			}
		}

		public decimal MakeReadyCostInMarkup2
		{
			get
			{
				return this._MakeReadyCostInMarkup2;
			}
			set
			{
				this._MakeReadyCostInMarkup2 = value;
			}
		}

		public decimal MakeReadyCostInMarkup3
		{
			get
			{
				return this._MakeReadyCostInMarkup3;
			}
			set
			{
				this._MakeReadyCostInMarkup3 = value;
			}
		}

		public decimal MakeReadyCostInMarkup4
		{
			get
			{
				return this._MakeReadyCostInMarkup4;
			}
			set
			{
				this._MakeReadyCostInMarkup4 = value;
			}
		}

		public decimal MakeReadyMarkupPrice1
		{
			get
			{
				return this._MakeReadyMarkupPrice1;
			}
			set
			{
				this._MakeReadyMarkupPrice1 = value;
			}
		}

		public decimal MakeReadyMarkupPrice2
		{
			get
			{
				return this._MakeReadyMarkupPrice2;
			}
			set
			{
				this._MakeReadyMarkupPrice2 = value;
			}
		}

		public decimal MakeReadyMarkupPrice3
		{
			get
			{
				return this._MakeReadyMarkupPrice3;
			}
			set
			{
				this._MakeReadyMarkupPrice3 = value;
			}
		}

		public decimal MakeReadyMarkupPrice4
		{
			get
			{
				return this._MakeReadyMarkupPrice4;
			}
			set
			{
				this._MakeReadyMarkupPrice4 = value;
			}
		}

		public decimal MarkupPrice1
		{
			get
			{
				return this._MarkupPrice1;
			}
			set
			{
				this._MarkupPrice1 = value;
			}
		}

		public decimal MarkupPrice2
		{
			get
			{
				return this._MarkupPrice2;
			}
			set
			{
				this._MarkupPrice2 = value;
			}
		}

		public decimal MarkupPrice3
		{
			get
			{
				return this._MarkupPrice3;
			}
			set
			{
				this._MarkupPrice3 = value;
			}
		}

		public decimal MarkupPrice4
		{
			get
			{
				return this._MarkupPrice4;
			}
			set
			{
				this._MarkupPrice4 = value;
			}
		}

		public long MaterialID2
		{
			get
			{
				return this._MaterialID2;
			}
			set
			{
				this._MaterialID2 = value;
			}
		}

		public long MaterialID3
		{
			get
			{
				return this._MaterialID3;
			}
			set
			{
				this._MaterialID3 = value;
			}
		}

		public long MaterialID4
		{
			get
			{
				return this._MaterialID4;
			}
			set
			{
				this._MaterialID4 = value;
			}
		}

		public long MaterialID5
		{
			get
			{
				return this._MaterialID5;
			}
			set
			{
				this._MaterialID5 = value;
			}
		}

		public string MatrixType
		{
			get
			{
				return this._MatrixType;
			}
			set
			{
				this._MatrixType = value;
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

		public decimal MultipleOf
		{
			get
			{
				return this._MultipleOf;
			}
			set
			{
				this._MultipleOf = value;
			}
		}

		public int NCRAssignedpress
		{
			get
			{
				return this._NCRAssignedpress;
			}
			set
			{
				this._NCRAssignedpress = value;
			}
		}

		public bool NCRCheckPerfecting
		{
			get
			{
				return this._NCRCheckPerfecting;
			}
			set
			{
				this._NCRCheckPerfecting = value;
			}
		}

		public bool NCRChecktumble
		{
			get
			{
				return this._NCRChecktumble;
			}
			set
			{
				this._NCRChecktumble = value;
			}
		}

		public bool NCRCheckturn
		{
			get
			{
				return this._NCRCheckturn;
			}
			set
			{
				this._NCRCheckturn = value;
			}
		}

		public bool NCRChkSheetWork
		{
			get
			{
				return this._NCRChkSheetWork;
			}
			set
			{
				this._NCRChkSheetWork = value;
			}
		}

		public string Ncrcommonuncommon
		{
			get
			{
				return this._Ncrcommonuncommon;
			}
			set
			{
				this._Ncrcommonuncommon = value;
			}
		}

		public int NCRGuilotineID
		{
			get
			{
				return this._NCRGuilotineID;
			}
			set
			{
				this._NCRGuilotineID = value;
			}
		}

		public string NCRGuilotineName
		{
			get
			{
				return this._NCRGuilotineName;
			}
			set
			{
				this._NCRGuilotineName = value;
			}
		}

		public decimal NCRGutterHorizontal
		{
			get
			{
				return this._NCRGutterHorizontal;
			}
			set
			{
				this._NCRGutterHorizontal = value;
			}
		}

		public decimal NCRGutterVertical
		{
			get
			{
				return this._NCRGutterVertical;
			}
			set
			{
				this._NCRGutterVertical = value;
			}
		}

		public double NcrInkcoverage
		{
			get
			{
				return this._NcrInkcoverage;
			}
			set
			{
				this._NcrInkcoverage = value;
			}
		}

		public int NCRInkID
		{
			get
			{
				return this._NCRInkID;
			}
			set
			{
				this._NCRInkID = value;
			}
		}

		public bool NCRIsFirstTrim
		{
			get
			{
				return this._NCRIsFirstTrim;
			}
			set
			{
				this._NCRIsFirstTrim = value;
			}
		}

		public bool NCRIsIncludeGutters
		{
			get
			{
				return this._NCRIsIncludeGutters;
			}
			set
			{
				this._NCRIsIncludeGutters = value;
			}
		}

		public bool NCRIsJobCustom
		{
			get
			{
				return this._NCRIsJobCustom;
			}
			set
			{
				this._NCRIsJobCustom = value;
			}
		}

		public bool NCRIsPressRestrictions
		{
			get
			{
				return this._NCRIsPressRestrictions;
			}
			set
			{
				this._NCRIsPressRestrictions = value;
			}
		}

		public bool NCRIsPrintCustom
		{
			get
			{
				return this._NCRIsPrintCustom;
			}
			set
			{
				this._NCRIsPrintCustom = value;
			}
		}

		public bool NCRIsSecondTrim
		{
			get
			{
				return this._NCRIsSecondTrim;
			}
			set
			{
				this._NCRIsSecondTrim = value;
			}
		}

		public string NCRItemTitle
		{
			get
			{
				return this._NCRItemTitle;
			}
			set
			{
				this._NCRItemTitle = value;
			}
		}

		public decimal NCRJobFlatSizeHeight
		{
			get
			{
				return this._NCRJobFlatSizeHeight;
			}
			set
			{
				this._NCRJobFlatSizeHeight = value;
			}
		}

		public int NCRJobFlatSizeID
		{
			get
			{
				return this._NCRJobFlatSizeID;
			}
			set
			{
				this._NCRJobFlatSizeID = value;
			}
		}

		public decimal NCRJobFlatSizeWidth
		{
			get
			{
				return this._NCRJobFlatSizeWidth;
			}
			set
			{
				this._NCRJobFlatSizeWidth = value;
			}
		}

		public decimal NCRLandscapevalue
		{
			get
			{
				return this._NCRLandscapevalue;
			}
			set
			{
				this._NCRLandscapevalue = value;
			}
		}

		public string NCRMakeready
		{
			get
			{
				return this._NCRMakeready;
			}
			set
			{
				this._NCRMakeready = value;
			}
		}

		public string NCRNcommonfrom
		{
			get
			{
				return this._NCRNcommonfrom;
			}
			set
			{
				this._NCRNcommonfrom = value;
			}
		}

		public string NCRNoofsidesprinted
		{
			get
			{
				return this._NCRNoofsidesprinted;
			}
			set
			{
				this._NCRNoofsidesprinted = value;
			}
		}

		public int NCRPaperID
		{
			get
			{
				return this._NCRPaperID;
			}
			set
			{
				this._NCRPaperID = value;
			}
		}

		public string NCRPaperName
		{
			get
			{
				return this._NCRPaperName;
			}
			set
			{
				this._NCRPaperName = value;
			}
		}

		public bool NCRPaperSupplied
		{
			get
			{
				return this._NCRPaperSupplied;
			}
			set
			{
				this._NCRPaperSupplied = value;
			}
		}

		public decimal NCRPartsperset
		{
			get
			{
				return this._NCRPartsperset;
			}
			set
			{
				this._NCRPartsperset = value;
			}
		}

		public string NCRPlate
		{
			get
			{
				return this._NCRPlate;
			}
			set
			{
				this._NCRPlate = value;
			}
		}

		public string NCRPlateID
		{
			get
			{
				return this._NCRPlateID;
			}
			set
			{
				this._NCRPlateID = value;
			}
		}

		public string NCRPlatename
		{
			get
			{
				return this._NCRPlatename;
			}
			set
			{
				this._NCRPlatename = value;
			}
		}

		public decimal NCRPortraitvalue
		{
			get
			{
				return this._NCRPortraitvalue;
			}
			set
			{
				this._NCRPortraitvalue = value;
			}
		}

		public bool NCRPriceForWhaolePack
		{
			get
			{
				return this._NCRPriceForWhaolePack;
			}
			set
			{
				this._NCRPriceForWhaolePack = value;
			}
		}

		public string NCRPrintLayout
		{
			get
			{
				return this._NCRPrintLayout;
			}
			set
			{
				this._NCRPrintLayout = value;
			}
		}

		public decimal NCRPrintSheetHeight
		{
			get
			{
				return this._NCRPrintSheetHeight;
			}
			set
			{
				this._NCRPrintSheetHeight = value;
			}
		}

		public string NCRPrintSheetSizeID
		{
			get
			{
				return this._NCRPrintSheetSizeID;
			}
			set
			{
				this._NCRPrintSheetSizeID = value;
			}
		}

		public decimal NCRPrintSheetWidth
		{
			get
			{
				return this._NCRPrintSheetWidth;
			}
			set
			{
				this._NCRPrintSheetWidth = value;
			}
		}

		public int NCRQuantity1
		{
			get
			{
				return this._NCRQuantity1;
			}
			set
			{
				this._NCRQuantity1 = value;
			}
		}

		public int NCRQuantity2
		{
			get
			{
				return this._NCRQuantity2;
			}
			set
			{
				this._NCRQuantity2 = value;
			}
		}

		public int NCRQuantity3
		{
			get
			{
				return this._NCRQuantity3;
			}
			set
			{
				this._NCRQuantity3 = value;
			}
		}

		public int NCRQuantity4
		{
			get
			{
				return this._NCRQuantity4;
			}
			set
			{
				this._NCRQuantity4 = value;
			}
		}

		public decimal NCRRunningspoilage
		{
			get
			{
				return this._NCRRunningspoilage;
			}
			set
			{
				this._NCRRunningspoilage = value;
			}
		}

		public string NCRSectionreference
		{
			get
			{
				return this._NCRSectionreference;
			}
			set
			{
				this._NCRSectionreference = value;
			}
		}

		public decimal NCRSetsperpad
		{
			get
			{
				return this._NCRSetsperpad;
			}
			set
			{
				this._NCRSetsperpad = value;
			}
		}

		public decimal NCRSetupspoilage
		{
			get
			{
				return this._NCRSetupspoilage;
			}
			set
			{
				this._NCRSetupspoilage = value;
			}
		}

		public string NCRSide1color
		{
			get
			{
				return this._NCRSide1color;
			}
			set
			{
				this._NCRSide1color = value;
			}
		}

		public string NCRSide2color
		{
			get
			{
				return this._NCRSide2color;
			}
			set
			{
				this._NCRSide2color = value;
			}
		}

		public string NCRWashup
		{
			get
			{
				return this._NCRWashup;
			}
			set
			{
				this._NCRWashup = value;
			}
		}

		public decimal NonImageHeight
		{
			get
			{
				return this._NonImageHeight;
			}
			set
			{
				this._NonImageHeight = value;
			}
		}

		public decimal NonImageWidth
		{
			get
			{
				return this._NonImageWidth;
			}
			set
			{
				this._NonImageWidth = value;
			}
		}

		public string NoofMakeReady
		{
			get
			{
				return this._NoofMakeReady;
			}
			set
			{
				this._NoofMakeReady = value;
			}
		}

		public decimal NoOfPagesInSection
		{
			get
			{
				return this._NoOfPagesInSection;
			}
			set
			{
				this._NoOfPagesInSection = value;
			}
		}

		public string Noofplates
		{
			get
			{
				return this._Noofplates;
			}
			set
			{
				this._Noofplates = value;
			}
		}

		public decimal NoOfSignatures
		{
			get
			{
				return this._NoOfSignatures;
			}
			set
			{
				this._NoOfSignatures = value;
			}
		}

		public string NoofWashup
		{
			get
			{
				return this._NoofWashup;
			}
			set
			{
				this._NoofWashup = value;
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

		public decimal OutworkDeliveryCost1
		{
			get
			{
				return this._OutworkDeliveryCost1;
			}
			set
			{
				this._OutworkDeliveryCost1 = value;
			}
		}

		public decimal OutworkDeliveryCost2
		{
			get
			{
				return this._OutworkDeliveryCost2;
			}
			set
			{
				this._OutworkDeliveryCost2 = value;
			}
		}

		public decimal OutworkDeliveryCost3
		{
			get
			{
				return this._OutworkDeliveryCost3;
			}
			set
			{
				this._OutworkDeliveryCost3 = value;
			}
		}

		public decimal OutworkDeliveryCost4
		{
			get
			{
				return this._OutworkDeliveryCost4;
			}
			set
			{
				this._OutworkDeliveryCost4 = value;
			}
		}

		public string OutworkMarkupType1
		{
			get
			{
				return this._OutworkMarkupType1;
			}
			set
			{
				this._OutworkMarkupType1 = value;
			}
		}

		public string OutworkMarkupType2
		{
			get
			{
				return this._OutworkMarkupType2;
			}
			set
			{
				this._OutworkMarkupType2 = value;
			}
		}

		public string OutworkMarkupType3
		{
			get
			{
				return this._OutworkMarkupType3;
			}
			set
			{
				this._OutworkMarkupType3 = value;
			}
		}

		public string OutworkMarkupType4
		{
			get
			{
				return this._OutworkMarkupType4;
			}
			set
			{
				this._OutworkMarkupType4 = value;
			}
		}

		public decimal PagesPerSignature
		{
			get
			{
				return this._PagesPerSignature;
			}
			set
			{
				this._PagesPerSignature = value;
			}
		}

		public decimal PaperCostExMarkup
		{
			get
			{
				return this._PaperCostExMarkup;
			}
			set
			{
				this._PaperCostExMarkup = value;
			}
		}

		public decimal PaperCostExMarkup1
		{
			get
			{
				return this._PaperCostExMarkup1;
			}
			set
			{
				this._PaperCostExMarkup1 = value;
			}
		}

		public decimal PaperCostExMarkup2
		{
			get
			{
				return this._PaperCostExMarkup2;
			}
			set
			{
				this._PaperCostExMarkup2 = value;
			}
		}

		public decimal PaperCostExMarkup3
		{
			get
			{
				return this._PaperCostExMarkup3;
			}
			set
			{
				this._PaperCostExMarkup3 = value;
			}
		}

		public decimal PaperCostExMarkup4
		{
			get
			{
				return this._PaperCostExMarkup4;
			}
			set
			{
				this._PaperCostExMarkup4 = value;
			}
		}

		public decimal PaperCostInMarkup1
		{
			get
			{
				return this._PaperCostInMarkup1;
			}
			set
			{
				this._PaperCostInMarkup1 = value;
			}
		}

		public decimal PaperCostInMarkup2
		{
			get
			{
				return this._PaperCostInMarkup2;
			}
			set
			{
				this._PaperCostInMarkup2 = value;
			}
		}

		public decimal PaperCostInMarkup3
		{
			get
			{
				return this._PaperCostInMarkup3;
			}
			set
			{
				this._PaperCostInMarkup3 = value;
			}
		}

		public decimal PaperCostInMarkup4
		{
			get
			{
				return this._PaperCostInMarkup4;
			}
			set
			{
				this._PaperCostInMarkup4 = value;
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

		public decimal PaperMarkup1
		{
			get
			{
				return this._PaperMarkup1;
			}
			set
			{
				this._PaperMarkup1 = value;
			}
		}

		public decimal PaperMarkup2
		{
			get
			{
				return this._PaperMarkup2;
			}
			set
			{
				this._PaperMarkup2 = value;
			}
		}

		public decimal PaperMarkup3
		{
			get
			{
				return this._PaperMarkup3;
			}
			set
			{
				this._PaperMarkup3 = value;
			}
		}

		public decimal PaperMarkup4
		{
			get
			{
				return this._PaperMarkup4;
			}
			set
			{
				this._PaperMarkup4 = value;
			}
		}

		public decimal PaperMarkupPrice
		{
			get
			{
				return this._PaperMarkupPrice;
			}
			set
			{
				this._PaperMarkupPrice = value;
			}
		}

		public decimal PaperMarkupPrice1
		{
			get
			{
				return this._PaperMarkupPrice1;
			}
			set
			{
				this._PaperMarkupPrice1 = value;
			}
		}

		public decimal PaperMarkupPrice2
		{
			get
			{
				return this._PaperMarkupPrice2;
			}
			set
			{
				this._PaperMarkupPrice2 = value;
			}
		}

		public decimal PaperMarkupPrice3
		{
			get
			{
				return this._PaperMarkupPrice3;
			}
			set
			{
				this._PaperMarkupPrice3 = value;
			}
		}

		public decimal PaperMarkupPrice4
		{
			get
			{
				return this._PaperMarkupPrice4;
			}
			set
			{
				this._PaperMarkupPrice4 = value;
			}
		}

		public double PaperUnitPrice
		{
			get
			{
				return this._PaperUnitPrice;
			}
			set
			{
				this._PaperUnitPrice = value;
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

		public long ParentItemID
		{
			get
			{
				return this._ParentItemID;
			}
			set
			{
				this._ParentItemID = value;
			}
		}

		public string ParentItemType
		{
			get
			{
				return this._ParentItemType;
			}
			set
			{
				this._ParentItemType = value;
			}
		}

		public long PlateID
		{
			get
			{
				return this._PlateID;
			}
			set
			{
				this._PlateID = value;
			}
		}

		public decimal PlatesCostExMarkup1
		{
			get
			{
				return this._PlatesCostExMarkup1;
			}
			set
			{
				this._PlatesCostExMarkup1 = value;
			}
		}

		public decimal PlatesCostExMarkup2
		{
			get
			{
				return this._PlatesCostExMarkup2;
			}
			set
			{
				this._PlatesCostExMarkup2 = value;
			}
		}

		public decimal PlatesCostExMarkup3
		{
			get
			{
				return this._PlatesCostExMarkup3;
			}
			set
			{
				this._PlatesCostExMarkup3 = value;
			}
		}

		public decimal PlatesCostExMarkup4
		{
			get
			{
				return this._PlatesCostExMarkup4;
			}
			set
			{
				this._PlatesCostExMarkup4 = value;
			}
		}

		public decimal PlatesCostInMarkup1
		{
			get
			{
				return this._PlatesCostInMarkup1;
			}
			set
			{
				this._PlatesCostInMarkup1 = value;
			}
		}

		public decimal PlatesCostInMarkup2
		{
			get
			{
				return this._PlatesCostInMarkup2;
			}
			set
			{
				this._PlatesCostInMarkup2 = value;
			}
		}

		public decimal PlatesCostInMarkup3
		{
			get
			{
				return this._PlatesCostInMarkup3;
			}
			set
			{
				this._PlatesCostInMarkup3 = value;
			}
		}

		public decimal PlatesCostInMarkup4
		{
			get
			{
				return this._PlatesCostInMarkup4;
			}
			set
			{
				this._PlatesCostInMarkup4 = value;
			}
		}

		public decimal PlatesMarkupPrice1
		{
			get
			{
				return this._PlatesMarkupPrice1;
			}
			set
			{
				this._PlatesMarkupPrice1 = value;
			}
		}

		public decimal PlatesMarkupPrice2
		{
			get
			{
				return this._PlatesMarkupPrice2;
			}
			set
			{
				this._PlatesMarkupPrice2 = value;
			}
		}

		public decimal PlatesMarkupPrice3
		{
			get
			{
				return this._PlatesMarkupPrice3;
			}
			set
			{
				this._PlatesMarkupPrice3 = value;
			}
		}

		public decimal PlatesMarkupPrice4
		{
			get
			{
				return this._PlatesMarkupPrice4;
			}
			set
			{
				this._PlatesMarkupPrice4 = value;
			}
		}

		public decimal PortraitValue
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

		public decimal ManualValue
		{
			get
			{
				return this._ManualValue;
			}
			set
			{
				this._ManualValue = value;
			}
		}

		public decimal PressCostExMarkup
		{
			get
			{
				return this._PressCostExMarkup;
			}
			set
			{
				this._PressCostExMarkup = value;
			}
		}

		public decimal PressCostExMarkup1
		{
			get
			{
				return this._PressCostExMarkup1;
			}
			set
			{
				this._PressCostExMarkup1 = value;
			}
		}

		public decimal PressCostExMarkup2
		{
			get
			{
				return this._PressCostExMarkup2;
			}
			set
			{
				this._PressCostExMarkup2 = value;
			}
		}

		public decimal PressCostExMarkup3
		{
			get
			{
				return this._PressCostExMarkup3;
			}
			set
			{
				this._PressCostExMarkup3 = value;
			}
		}

		public decimal PressCostExMarkup4
		{
			get
			{
				return this._PressCostExMarkup4;
			}
			set
			{
				this._PressCostExMarkup4 = value;
			}
		}

		public decimal PressCostInMarkup1
		{
			get
			{
				return this._PressCostInMarkup1;
			}
			set
			{
				this._PressCostInMarkup1 = value;
			}
		}

		public decimal PressCostInMarkup2
		{
			get
			{
				return this._PressCostInMarkup2;
			}
			set
			{
				this._PressCostInMarkup2 = value;
			}
		}

		public decimal PressCostInMarkup3
		{
			get
			{
				return this._PressCostInMarkup3;
			}
			set
			{
				this._PressCostInMarkup3 = value;
			}
		}

		public decimal PressCostInMarkup4
		{
			get
			{
				return this._PressCostInMarkup4;
			}
			set
			{
				this._PressCostInMarkup4 = value;
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

		public decimal PressMarkUp1
		{
			get
			{
				return this._PressMarkUp1;
			}
			set
			{
				this._PressMarkUp1 = value;
			}
		}

		public decimal PressMarkUp2
		{
			get
			{
				return this._PressMarkUp2;
			}
			set
			{
				this._PressMarkUp2 = value;
			}
		}

		public decimal PressMarkUp3
		{
			get
			{
				return this._PressMarkUp3;
			}
			set
			{
				this._PressMarkUp3 = value;
			}
		}

		public decimal PressMarkUp4
		{
			get
			{
				return this._PressMarkUp4;
			}
			set
			{
				this._PressMarkUp4 = value;
			}
		}

		public decimal PressMarkupPrice
		{
			get
			{
				return this._PressMarkupPrice;
			}
			set
			{
				this._PressMarkupPrice = value;
			}
		}

		public decimal PressMarkupPrice1
		{
			get
			{
				return this._PressMarkupPrice1;
			}
			set
			{
				this._PressMarkupPrice1 = value;
			}
		}

		public decimal PressMarkupPrice2
		{
			get
			{
				return this._PressMarkupPrice2;
			}
			set
			{
				this._PressMarkupPrice2 = value;
			}
		}

		public decimal PressMarkupPrice3
		{
			get
			{
				return this._PressMarkupPrice3;
			}
			set
			{
				this._PressMarkupPrice3 = value;
			}
		}

		public decimal PressMarkupPrice4
		{
			get
			{
				return this._PressMarkupPrice4;
			}
			set
			{
				this._PressMarkupPrice4 = value;
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

		public string PricePerUnitOfMeasure1
		{
			get
			{
				return this._PricePerUnitOfMeasure1;
			}
			set
			{
				this._PricePerUnitOfMeasure1 = value;
			}
		}

		public string PricePerUnitOfMeasure2
		{
			get
			{
				return this._PricePerUnitOfMeasure2;
			}
			set
			{
				this._PricePerUnitOfMeasure2 = value;
			}
		}

		public string PricePerUnitOfMeasure3
		{
			get
			{
				return this._PricePerUnitOfMeasure3;
			}
			set
			{
				this._PricePerUnitOfMeasure3 = value;
			}
		}

		public string PricePerUnitOfMeasure4
		{
			get
			{
				return this._PricePerUnitOfMeasure4;
			}
			set
			{
				this._PricePerUnitOfMeasure4 = value;
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

		public decimal PrintLayoutValue
		{
			get
			{
				return this._PrintLayoutValue;
			}
			set
			{
				this._PrintLayoutValue = value;
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

		public decimal PrintSheets
		{
			get
			{
				return this._PrintSheets;
			}
			set
			{
				this._PrintSheets = value;
			}
		}

		public decimal PrintSheets1
		{
			get
			{
				return this._PrintSheets1;
			}
			set
			{
				this._PrintSheets1 = value;
			}
		}

		public decimal PrintSheets2
		{
			get
			{
				return this._PrintSheets2;
			}
			set
			{
				this._PrintSheets2 = value;
			}
		}

		public decimal PrintSheets3
		{
			get
			{
				return this._PrintSheets3;
			}
			set
			{
				this._PrintSheets3 = value;
			}
		}

		public decimal PrintSheets4
		{
			get
			{
				return this._PrintSheets4;
			}
			set
			{
				this._PrintSheets4 = value;
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

		public decimal Profitmargin
		{
			get
			{
				return this._Profitmargin;
			}
			set
			{
				this._Profitmargin = value;
			}
		}

		public decimal ProfitMargin1
		{
			get
			{
				return this._ProfitMargin1;
			}
			set
			{
				this._ProfitMargin1 = value;
			}
		}

		public decimal ProfitMargin2
		{
			get
			{
				return this._ProfitMargin2;
			}
			set
			{
				this._ProfitMargin2 = value;
			}
		}

		public decimal ProfitMargin3
		{
			get
			{
				return this._ProfitMargin3;
			}
			set
			{
				this._ProfitMargin3 = value;
			}
		}

		public decimal ProfitMargin4
		{
			get
			{
				return this._ProfitMargin4;
			}
			set
			{
				this._ProfitMargin4 = value;
			}
		}

		public decimal ProfitMarginPrice1
		{
			get
			{
				return this._ProfitMarginPrice1;
			}
			set
			{
				this._ProfitMarginPrice1 = value;
			}
		}

		public decimal ProfitMarginPrice2
		{
			get
			{
				return this._ProfitMarginPrice2;
			}
			set
			{
				this._ProfitMarginPrice2 = value;
			}
		}

		public decimal ProfitMarginPrice3
		{
			get
			{
				return this._ProfitMarginPrice3;
			}
			set
			{
				this._ProfitMarginPrice3 = value;
			}
		}

		public decimal ProfitMarginPrice4
		{
			get
			{
				return this._ProfitMarginPrice4;
			}
			set
			{
				this._ProfitMarginPrice4 = value;
			}
		}

		public int Qty
		{
			get
			{
				return this._Qty;
			}
			set
			{
				this._Qty = value;
			}
		}

		public int Qty1
		{
			get
			{
				return this._Qty1;
			}
			set
			{
				this._Qty1 = value;
			}
		}

		public int Qty2
		{
			get
			{
				return this._Qty2;
			}
			set
			{
				this._Qty2 = value;
			}
		}

		public int Qty3
		{
			get
			{
				return this._Qty3;
			}
			set
			{
				this._Qty3 = value;
			}
		}

		public int Qty4
		{
			get
			{
				return this._Qty4;
			}
			set
			{
				this._Qty4 = value;
			}
		}

		public string Qtydesc
		{
			get
			{
				return this._Qtydesc;
			}
			set
			{
				this._Qtydesc = value;
			}
		}

		public string Qtydesc1
		{
			get
			{
				return this._Qtydesc1;
			}
			set
			{
				this._Qtydesc1 = value;
			}
		}

		public string Qtydesc2
		{
			get
			{
				return this._Qtydesc2;
			}
			set
			{
				this._Qtydesc2 = value;
			}
		}

		public string Qtydesc3
		{
			get
			{
				return this._Qtydesc3;
			}
			set
			{
				this._Qtydesc3 = value;
			}
		}

		public string Qtydesc4
		{
			get
			{
				return this._Qtydesc4;
			}
			set
			{
				this._Qtydesc4 = value;
			}
		}

		public int Quantity1
		{
			get
			{
				return this._Quantity1;
			}
			set
			{
				this._Quantity1 = value;
			}
		}

		public int Quantity2
		{
			get
			{
				return this._Quantity2;
			}
			set
			{
				this._Quantity2 = value;
			}
		}

		public int Quantity3
		{
			get
			{
				return this._Quantity3;
			}
			set
			{
				this._Quantity3 = value;
			}
		}

		public int Quantity4
		{
			get
			{
				return this._Quantity4;
			}
			set
			{
				this._Quantity4 = value;
			}
		}

		public long QuickQuoteID
		{
			get
			{
				return this._QuickQuoteID;
			}
			set
			{
				this._QuickQuoteID = value;
			}
		}

		public decimal Row
		{
			get
			{
				return this._Row;
			}
			set
			{
				this._Row = value;
			}
		}

		public decimal RunningSpoilage
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

		public decimal SecondTrimCuts
		{
			get
			{
				return this._SecondTrimCuts;
			}
			set
			{
				this._SecondTrimCuts = value;
			}
		}

		public decimal SecondTrimCuts1
		{
			get
			{
				return this._SecondTrimCuts1;
			}
			set
			{
				this._SecondTrimCuts1 = value;
			}
		}

		public decimal SecondTrimCuts2
		{
			get
			{
				return this._SecondTrimCuts2;
			}
			set
			{
				this._SecondTrimCuts2 = value;
			}
		}

		public decimal SecondTrimCuts3
		{
			get
			{
				return this._SecondTrimCuts3;
			}
			set
			{
				this._SecondTrimCuts3 = value;
			}
		}

		public decimal SecondTrimCuts4
		{
			get
			{
				return this._SecondTrimCuts4;
			}
			set
			{
				this._SecondTrimCuts4 = value;
			}
		}

		public decimal SecondTrimNoOfBundles
		{
			get
			{
				return this._SecondTrimNoOfBundles;
			}
			set
			{
				this._SecondTrimNoOfBundles = value;
			}
		}

		public decimal SecondTrimNoOfBundles1
		{
			get
			{
				return this._SecondTrimNoOfBundles1;
			}
			set
			{
				this._SecondTrimNoOfBundles1 = value;
			}
		}

		public decimal SecondTrimNoOfBundles2
		{
			get
			{
				return this._SecondTrimNoOfBundles2;
			}
			set
			{
				this._SecondTrimNoOfBundles2 = value;
			}
		}

		public decimal SecondTrimNoOfBundles3
		{
			get
			{
				return this._SecondTrimNoOfBundles3;
			}
			set
			{
				this._SecondTrimNoOfBundles3 = value;
			}
		}

		public decimal SecondTrimNoOfBundles4
		{
			get
			{
				return this._SecondTrimNoOfBundles4;
			}
			set
			{
				this._SecondTrimNoOfBundles4 = value;
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

		public decimal SellingPrice1
		{
			get
			{
				return this._SellingPrice1;
			}
			set
			{
				this._SellingPrice1 = value;
			}
		}

		public decimal SellingPrice2
		{
			get
			{
				return this._SellingPrice2;
			}
			set
			{
				this._SellingPrice2 = value;
			}
		}

		public decimal SellingPrice3
		{
			get
			{
				return this._SellingPrice3;
			}
			set
			{
				this._SellingPrice3 = value;
			}
		}

		public decimal SellingPrice4
		{
			get
			{
				return this._SellingPrice4;
			}
			set
			{
				this._SellingPrice4 = value;
			}
		}

		public decimal SetupSpoilage
		{
			get
			{
				return this._SetupSpoilage;
			}
			set
			{
				this._SetupSpoilage = value;
			}
		}

		public decimal SheetHeight
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

		public decimal SheetWidth
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

		public string side1Color
		{
			get
			{
				return this._side1Color;
			}
			set
			{
				this._side1Color = value;
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

		public string sidesprinted
		{
			get
			{
				return this._sidesprinted;
			}
			set
			{
				this._sidesprinted = value;
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

		public decimal Subtotal1
		{
			get
			{
				return this._Subtotal1;
			}
			set
			{
				this._Subtotal1 = value;
			}
		}

		public decimal SubTotal1
		{
			get
			{
				return this._SubTotal1;
			}
			set
			{
				this._SubTotal1 = value;
			}
		}

		public decimal Subtotal2
		{
			get
			{
				return this._Subtotal2;
			}
			set
			{
				this._Subtotal2 = value;
			}
		}

		public decimal SubTotal2
		{
			get
			{
				return this._SubTotal2;
			}
			set
			{
				this._SubTotal2 = value;
			}
		}

		public decimal Subtotal3
		{
			get
			{
				return this._Subtotal3;
			}
			set
			{
				this._Subtotal3 = value;
			}
		}

		public decimal SubTotal3
		{
			get
			{
				return this._SubTotal3;
			}
			set
			{
				this._SubTotal3 = value;
			}
		}

		public decimal Subtotal4
		{
			get
			{
				return this._Subtotal4;
			}
			set
			{
				this._Subtotal4 = value;
			}
		}

		public decimal SubTotal4
		{
			get
			{
				return this._SubTotal4;
			}
			set
			{
				this._SubTotal4 = value;
			}
		}

		public string SupplierName1
		{
			get
			{
				return this._SupplierName1;
			}
			set
			{
				this._SupplierName1 = value;
			}
		}

		public string SupplierName2
		{
			get
			{
				return this._SupplierName2;
			}
			set
			{
				this._SupplierName2 = value;
			}
		}

		public string SupplierName3
		{
			get
			{
				return this._SupplierName3;
			}
			set
			{
				this._SupplierName3 = value;
			}
		}

		public string SupplierName4
		{
			get
			{
				return this._SupplierName4;
			}
			set
			{
				this._SupplierName4 = value;
			}
		}

		public string SupplierQuoteNo1
		{
			get
			{
				return this._SupplierQuoteNo1;
			}
			set
			{
				this._SupplierQuoteNo1 = value;
			}
		}

		public string SupplierQuoteNo2
		{
			get
			{
				return this._SupplierQuoteNo2;
			}
			set
			{
				this._SupplierQuoteNo2 = value;
			}
		}

		public string SupplierQuoteNo3
		{
			get
			{
				return this._SupplierQuoteNo3;
			}
			set
			{
				this._SupplierQuoteNo3 = value;
			}
		}

		public string SupplierQuoteNo4
		{
			get
			{
				return this._SupplierQuoteNo4;
			}
			set
			{
				this._SupplierQuoteNo4 = value;
			}
		}

		public decimal Tax
		{
			get
			{
				return this._Tax;
			}
			set
			{
				this._Tax = value;
			}
		}

		public int TaxID
		{
			get
			{
				return this._TaxID;
			}
			set
			{
				this._TaxID = value;
			}
		}

		public decimal TaxPrice1
		{
			get
			{
				return this._TaxPrice1;
			}
			set
			{
				this._TaxPrice1 = value;
			}
		}

		public decimal TaxPrice2
		{
			get
			{
				return this._TaxPrice2;
			}
			set
			{
				this._TaxPrice2 = value;
			}
		}

		public decimal TaxPrice3
		{
			get
			{
				return this._TaxPrice3;
			}
			set
			{
				this._TaxPrice3 = value;
			}
		}

		public decimal TaxPrice4
		{
			get
			{
				return this._TaxPrice4;
			}
			set
			{
				this._TaxPrice4 = value;
			}
		}

		public decimal TaxRate1
		{
			get
			{
				return this._TaxRate1;
			}
			set
			{
				this._TaxRate1 = value;
			}
		}

		public decimal TaxRate2
		{
			get
			{
				return this._TaxRate2;
			}
			set
			{
				this._TaxRate2 = value;
			}
		}

		public decimal TaxRate3
		{
			get
			{
				return this._TaxRate3;
			}
			set
			{
				this._TaxRate3 = value;
			}
		}

		public decimal TaxRate4
		{
			get
			{
				return this._TaxRate4;
			}
			set
			{
				this._TaxRate4 = value;
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

		public decimal WashUpCostExMarkup1
		{
			get
			{
				return this._WashUpCostExMarkup1;
			}
			set
			{
				this._WashUpCostExMarkup1 = value;
			}
		}

		public decimal WashUpCostExMarkup2
		{
			get
			{
				return this._WashUpCostExMarkup2;
			}
			set
			{
				this._WashUpCostExMarkup2 = value;
			}
		}

		public decimal WashUpCostExMarkup3
		{
			get
			{
				return this._WashUpCostExMarkup3;
			}
			set
			{
				this._WashUpCostExMarkup3 = value;
			}
		}

		public decimal WashUpCostExMarkup4
		{
			get
			{
				return this._WashUpCostExMarkup4;
			}
			set
			{
				this._WashUpCostExMarkup4 = value;
			}
		}

		public decimal WashUpCostInMarkup1
		{
			get
			{
				return this._WashUpCostInMarkup1;
			}
			set
			{
				this._WashUpCostInMarkup1 = value;
			}
		}

		public decimal WashUpCostInMarkup2
		{
			get
			{
				return this._WashUpCostInMarkup2;
			}
			set
			{
				this._WashUpCostInMarkup2 = value;
			}
		}

		public decimal WashUpCostInMarkup3
		{
			get
			{
				return this._WashUpCostInMarkup3;
			}
			set
			{
				this._WashUpCostInMarkup3 = value;
			}
		}

		public decimal WashUpCostInMarkup4
		{
			get
			{
				return this._WashUpCostInMarkup4;
			}
			set
			{
				this._WashUpCostInMarkup4 = value;
			}
		}

		public decimal WashUpMarkupPrice1
		{
			get
			{
				return this._WashUpMarkupPrice1;
			}
			set
			{
				this._WashUpMarkupPrice1 = value;
			}
		}

		public decimal WashUpMarkupPrice2
		{
			get
			{
				return this._WashUpMarkupPrice2;
			}
			set
			{
				this._WashUpMarkupPrice2 = value;
			}
		}

		public decimal WashUpMarkupPrice3
		{
			get
			{
				return this._WashUpMarkupPrice3;
			}
			set
			{
				this._WashUpMarkupPrice3 = value;
			}
		}

		public decimal WashUpMarkupPrice4
		{
			get
			{
				return this._WashUpMarkupPrice4;
			}
			set
			{
				this._WashUpMarkupPrice4 = value;
			}
		}

		public decimal WhiteInkCoverageSide1
		{
			get
			{
				return this._WhiteInkCoverageSide1;
			}
			set
			{
				this._WhiteInkCoverageSide1 = value;
			}
		}

		public decimal WhiteInkCoverageSide2
		{
			get
			{
				return this._WhiteInkCoverageSide2;
			}
			set
			{
				this._WhiteInkCoverageSide2 = value;
			}
		}

		public decimal Width1
		{
			get
			{
				return this._Width1;
			}
			set
			{
				this._Width1 = value;
			}
		}

		public decimal Width2
		{
			get
			{
				return this._Width2;
			}
			set
			{
				this._Width2 = value;
			}
		}

		public decimal Width3
		{
			get
			{
				return this._Width3;
			}
			set
			{
				this._Width3 = value;
			}
		}

		public decimal Width4
		{
			get
			{
				return this._Width4;
			}
			set
			{
				this._Width4 = value;
			}
		}

		public EstimatesItem()
		{
		}
	}
}