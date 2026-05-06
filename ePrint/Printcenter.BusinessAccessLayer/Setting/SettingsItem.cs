using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.Setting
{
	public class SettingsItem : BaseItem
	{
		private int _PaperSizeID;

		private string _PaperSizeName = string.Empty;

		private int _StatusID;

        private int _DeliveryCostID;

        private long _CPStatusID;

		private string _StatusTitle = string.Empty;

		private bool _IsDefaultStatus;

		private int _TaxID;

		private string _TaxName = string.Empty;

        private string _Alias = string.Empty;

		private decimal _TaxRate;

		private int _PhraseBookID;

		private string _PhraseType = string.Empty;

		private string _PhraseText = string.Empty;

		private string _Type = string.Empty;

		private string _Title = string.Empty;

		private bool _IsDefaultPhrase;

		private string _EmailTemplateName = string.Empty;

		private string _EmailTemplateType = string.Empty;

		private int _ItemTitleID;

		private string _ItemTitle = string.Empty;

		private int _MarkupID;

		private string _MarkupName = string.Empty;

		private decimal _MarkupRate;

		private int _SystemMarkupID;

		private int _CompanyID;

		private int _UserID;

		private decimal _Paper;

		private decimal _PrintBroker;

		private decimal _Inks;

		private decimal _InventoryItems;

		private decimal _OtherCosts;

        private decimal _DeliveryCost;

        private bool _RoundUpTotals;

		private int _RegionalID;

		private int _LanguageID;

		private string _DateFormat = string.Empty;

		private string _Colour = string.Empty;

		private string _Organisation = string.Empty;

		private string _State = string.Empty;

		private string _Centre = string.Empty;

		private string _PostCode = string.Empty;

		private string _Metre = string.Empty;

		private string _Weight = string.Empty;

		private string _GeneralWeight = string.Empty;

		private string _PaperMeasure = string.Empty;

		private string _License = string.Empty;

		private string _PageTitle = string.Empty;

		private string _CompanyTitle = string.Empty;

		private string _Languages = string.Empty;

		private long _OtherCostCategoryID;

		private string _OtherCostCategoryName = string.Empty;

		private int _Priority;

		private int _TimeZoneID;

		private string _CategoryName = string.Empty;

		private string _CatalogueName = string.Empty;

		private int _PriceCatalogueID;

		private int _qty;

		private decimal _Price;

		private int _isdefault;

		private DateTime _fiscalfrom;

		private DateTime _fiscalto;

		private string _PDFTitle = string.Empty;

		private string _PDFName = string.Empty;

		private string _ImageName = string.Empty;

		private string _PDFKey = string.Empty;

		private int _Roundoff;

		private string _FeaturedName = string.Empty;

		private int _NoOfOptions;

		private string _FeaturedDescription = string.Empty;

		private DateTime _CreatedDate;

		private string _JobcardCategory = string.Empty;

		private int _IsDisplayCostCentre;

		private long _ManageID;

		private long _AccountID;

		private string _Digital = string.Empty;

		private string _Offset = string.Empty;

		private string _Largeformat = string.Empty;

		private string _Outwork = string.Empty;

		private string _ProdCatalogue = string.Empty;

		private string _OtherCost = string.Empty;

		private string _QuickQuote = string.Empty;

		private string _Warehouse = string.Empty;

		private string _Order = string.Empty;

		private string _DirectPO = string.Empty;

		private string _DescriptionInclude = string.Empty;

		private string _PaperMaterial = string.Empty;

		public long AccountID
		{
			get
			{
				return this._AccountID;
			}
			set
			{
				this._AccountID = value;
			}
		}

		public string CatalogueName
		{
			get
			{
				return this._CatalogueName;
			}
			set
			{
				this._CatalogueName = value;
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

		public string Centre
		{
			get
			{
				return this._Centre;
			}
			set
			{
				this._Centre = value;
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

		public string CompanyTitle
		{
			get
			{
				return this._CompanyTitle;
			}
			set
			{
				this._CompanyTitle = value;
			}
		}

		public long CPStatusID
		{
			get
			{
				return this._CPStatusID;
			}
			set
			{
				this._CPStatusID = value;
			}
		}

		public new DateTime CreatedDate
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

		public string DateFormat
		{
			get
			{
				return this._DateFormat;
			}
			set
			{
				this._DateFormat = value;
			}
		}

		public string Digital
		{
			get
			{
				return this._Digital;
			}
			set
			{
				this._Digital = value;
			}
		}

		public string DirectPO
		{
			get
			{
				return this._DirectPO;
			}
			set
			{
				this._DirectPO = value;
			}
		}

		public string DescriptionInclude
		{
			get
			{
				return this._DescriptionInclude;
			}
			set
			{
				this._DescriptionInclude = value;
			}
		}

		

		public string EmailTemplateName
		{
			get
			{
				return this._EmailTemplateName;
			}
			set
			{
				this._EmailTemplateName = value;
			}
		}

		public string EmailTemplateType
		{
			get
			{
				return this._EmailTemplateType;
			}
			set
			{
				this._EmailTemplateType = value;
			}
		}

		public string FeaturedDescription
		{
			get
			{
				return this._FeaturedDescription;
			}
			set
			{
				this._FeaturedDescription = value;
			}
		}

		public string FeaturedName
		{
			get
			{
				return this._FeaturedName;
			}
			set
			{
				this._FeaturedName = value;
			}
		}

		public DateTime fiscalfrom
		{
			get
			{
				return this._fiscalfrom;
			}
			set
			{
				this._fiscalfrom = value;
			}
		}

		public DateTime fiscalto
		{
			get
			{
				return this._fiscalto;
			}
			set
			{
				this._fiscalto = value;
			}
		}

		public string GeneralWeight
		{
			get
			{
				return this._GeneralWeight;
			}
			set
			{
				this._GeneralWeight = value;
			}
		}

		public string ImageName
		{
			get
			{
				return this._ImageName;
			}
			set
			{
				this._ImageName = value;
			}
		}

		public decimal Inks
		{
			get
			{
				return this._Inks;
			}
			set
			{
				this._Inks = value;
			}
		}

		public decimal InventoryItems
		{
			get
			{
				return this._InventoryItems;
			}
			set
			{
				this._InventoryItems = value;
			}
		}

		public int isdefault
		{
			get
			{
				return this._isdefault;
			}
			set
			{
				this._isdefault = value;
			}
		}

		public bool IsDefaultPhrase
		{
			get
			{
				return this._IsDefaultPhrase;
			}
			set
			{
				this._IsDefaultPhrase = value;
			}
		}

		public bool IsDefaultStatus
		{
			get
			{
				return this._IsDefaultStatus;
			}
			set
			{
				this._IsDefaultStatus = value;
			}
		}

		public int IsDisplayCostCentre
		{
			get
			{
				return this._IsDisplayCostCentre;
			}
			set
			{
				this._IsDisplayCostCentre = value;
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

		public int ItemTitleID
		{
			get
			{
				return this._ItemTitleID;
			}
			set
			{
				this._ItemTitleID = value;
			}
		}

		public string JobcardCategory
		{
			get
			{
				return this._JobcardCategory;
			}
			set
			{
				this._JobcardCategory = value;
			}
		}

		public int LanguageID
		{
			get
			{
				return this._LanguageID;
			}
			set
			{
				this._LanguageID = value;
			}
		}

		public string Languages
		{
			get
			{
				return this._Languages;
			}
			set
			{
				this._Languages = value;
			}
		}

		public string Largeformat
		{
			get
			{
				return this._Largeformat;
			}
			set
			{
				this._Largeformat = value;
			}
		}

		public string License
		{
			get
			{
				return this._License;
			}
			set
			{
				this._License = value;
			}
		}

		public long ManageID
		{
			get
			{
				return this._ManageID;
			}
			set
			{
				this._ManageID = value;
			}
		}

		public int MarkupID
		{
			get
			{
				return this._MarkupID;
			}
			set
			{
				this._MarkupID = value;
			}
		}

		public string MarkupName
		{
			get
			{
				return this._MarkupName;
			}
			set
			{
				this._MarkupName = value;
			}
		}

		public decimal MarkupRate
		{
			get
			{
				return this._MarkupRate;
			}
			set
			{
				this._MarkupRate = value;
			}
		}

		public string Metre
		{
			get
			{
				return this._Metre;
			}
			set
			{
				this._Metre = value;
			}
		}

		public int NoOfOptions
		{
			get
			{
				return this._NoOfOptions;
			}
			set
			{
				this._NoOfOptions = value;
			}
		}

		public string Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		public string Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				this._Order = value;
			}
		}

		public string Organisation
		{
			get
			{
				return this._Organisation;
			}
			set
			{
				this._Organisation = value;
			}
		}

		public string OtherCost
		{
			get
			{
				return this._OtherCost;
			}
			set
			{
				this._OtherCost = value;
			}
		}

		public long OtherCostCategoryID
		{
			get
			{
				return this._OtherCostCategoryID;
			}
			set
			{
				this._OtherCostCategoryID = value;
			}
		}

		public string OtherCostCategoryName
		{
			get
			{
				return this._OtherCostCategoryName;
			}
			set
			{
				this._OtherCostCategoryName = value;
			}
		}

		public decimal OtherCosts
		{
			get
			{
				return this._OtherCosts;
			}
			set
			{
				this._OtherCosts = value;
			}
		}

        public decimal DeliveryCost
        {
            get
            {
                return this._DeliveryCost;
            }
            set
            {
                this._DeliveryCost = value;
            }
        }

        public string Outwork
		{
			get
			{
				return this._Outwork;
			}
			set
			{
				this._Outwork = value;
			}
		}

		public string PageTitle
		{
			get
			{
				return this._PageTitle;
			}
			set
			{
				this._PageTitle = value;
			}
		}

		public decimal Paper
		{
			get
			{
				return this._Paper;
			}
			set
			{
				this._Paper = value;
			}
		}

		public string PaperMeasure
		{
			get
			{
				return this._PaperMeasure;
			}
			set
			{
				this._PaperMeasure = value;
			}
		}
		public string PaperMaterial
		{
			get
			{
				return this._PaperMaterial;
			}
			set
			{
				this._PaperMaterial = value;
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

		public string PaperSizeName
		{
			get
			{
				return this._PaperSizeName;
			}
			set
			{
				this._PaperSizeName = value;
			}
		}

		public string PDFKey
		{
			get
			{
				return this._PDFKey;
			}
			set
			{
				this._PDFKey = value;
			}
		}

		public string PDFName
		{
			get
			{
				return this._PDFName;
			}
			set
			{
				this._PDFName = value;
			}
		}

		public string PDFTitle
		{
			get
			{
				return this._PDFTitle;
			}
			set
			{
				this._PDFTitle = value;
			}
		}

		public int PhraseBookID
		{
			get
			{
				return this._PhraseBookID;
			}
			set
			{
				this._PhraseBookID = value;
			}
		}

		public string PhraseText
		{
			get
			{
				return this._PhraseText;
			}
			set
			{
				this._PhraseText = value;
			}
		}

		public string PhraseType
		{
			get
			{
				return this._PhraseType;
			}
			set
			{
				this._PhraseType = value;
			}
		}

		public string PostCode
		{
			get
			{
				return this._PostCode;
			}
			set
			{
				this._PostCode = value;
			}
		}

		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				this._Price = value;
			}
		}

		public int PriceCatalogueID
		{
			get
			{
				return this._PriceCatalogueID;
			}
			set
			{
				this._PriceCatalogueID = value;
			}
		}

		public decimal PrintBroker
		{
			get
			{
				return this._PrintBroker;
			}
			set
			{
				this._PrintBroker = value;
			}
		}

		public new int Priority
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

		public string ProdCatalogue
		{
			get
			{
				return this._ProdCatalogue;
			}
			set
			{
				this._ProdCatalogue = value;
			}
		}

		public int qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
			}
		}

		public string QuickQuote
		{
			get
			{
				return this._QuickQuote;
			}
			set
			{
				this._QuickQuote = value;
			}
		}

		public int RegionalID
		{
			get
			{
				return this._RegionalID;
			}
			set
			{
				this._RegionalID = value;
			}
		}

		public int Roundoff
		{
			get
			{
				return this._Roundoff;
			}
			set
			{
				this._Roundoff = value;
			}
		}

		public bool RoundUpTotals
		{
			get
			{
				return this._RoundUpTotals;
			}
			set
			{
				this._RoundUpTotals = value;
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

		public int StatusID
		{
			get
			{
				return this._StatusID;
			}
			set
			{
				this._StatusID = value;
			}
		}

        public int DeliveryCostID
        {
            get
            {
                return this._DeliveryCostID;
            }
            set
            {
                this._DeliveryCostID = value;
            }
        }

        public string StatusTitle
		{
			get
			{
				return this._StatusTitle;
			}
			set
			{
				this._StatusTitle = value;
			}
		}

		public int SystemMarkupID
		{
			get
			{
				return this._SystemMarkupID;
			}
			set
			{
				this._SystemMarkupID = value;
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

		public string TaxName
		{
			get
			{
				return this._TaxName;
			}
			set
			{
				this._TaxName = value;
			}
		}

        public string Alias
        {
            get
            {
                return this._Alias;
            }
            set
            {
                this._Alias = value;
            }
        }

        public decimal TaxRate
		{
			get
			{
				return this._TaxRate;
			}
			set
			{
				this._TaxRate = value;
			}
		}

		public int TimeZoneID
		{
			get
			{
				return this._TimeZoneID;
			}
			set
			{
				this._TimeZoneID = value;
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

		public new int UserID
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

		public string Warehouse
		{
			get
			{
				return this._Warehouse;
			}
			set
			{
				this._Warehouse = value;
			}
		}

		public string Weight
		{
			get
			{
				return this._Weight;
			}
			set
			{
				this._Weight = value;
			}
		}

		public SettingsItem()
		{
		}
	}
}