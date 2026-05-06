using Printcenter.BusinessAccessLayer;
using System;

namespace Printcenter.BusinessAccessLayer.Purchases
{
    public class PurchaseItem : BaseItem
    {
        private string _Comments = string.Empty;

        private string _FootNote = string.Empty;

        private string _PONO = string.Empty;

        private long _CurrentPONO;

        private DateTime _PODate = DateTime.Now;

        private string _ReferenceNo = string.Empty;

        private string _SupplierQuoteNo = string.Empty;

        private string _SupplierInvoiceNo = string.Empty;

        private long _RaisedByID;

        private DateTime _ReqDate = DateTime.Now;

        private bool _GoodsReceived;

        private bool _IsCompleted;

        private bool _InvoiceReceived;

        private string _Status = string.Empty;

        private int _StatusID;

        private long _EstimateID;

        private long _PurchaseItemID;

        private long _WarehouseItemID;

        private string _WarehouseItemType = string.Empty;

        private string _ItemCode = string.Empty;

        private string _Description = string.Empty;

        private int _Qty;

        private int _PackedIn;

        private decimal _PurQty;

        private decimal _PurPackedIn;

        private decimal _Price;

        private int _TaxID;

        private decimal _TaxValue;

        private int _AccountCodeID;

        private string _Note = string.Empty;

        private string _headernote = string.Empty;

        private long _EstimateItemID;

        private string _EstimateType = string.Empty;

        private DateTime _TodayDate;

        private long _DeliveryAddressID;

        private string _DeliveryAddressType = string.Empty;

        private int _CourierID;

        private long _EstimateBookletItemID;

        private DateTime _SupplierInvoiceDate;

        private string _AdditionalOptionDetails = string.Empty;

        private bool _isFromProductItem;

        private long _EstLargeItemCalculationID;

        private string _IsFromProgreesTojob = string.Empty;

        private long _EstimateAdditionalItemID;

        private long _poNum;

        private string _isCombine = string.Empty;

        public long poNum
        {
            get
            {
                return this._poNum;
            }
            set
            {
                this._poNum = value;
            }
        }

        public string isCombine
        {
            get
            {
                return this._isCombine;
            }
            set
            {
                this._isCombine = value;
            }
        }

        public int AccountCodeID
        {
            get
            {
                return this._AccountCodeID;
            }
            set
            {
                this._AccountCodeID = value;
            }
        }

        public string AdditionalOptionDetails
        {
            get
            {
                return this._AdditionalOptionDetails;
            }
            set
            {
                this._AdditionalOptionDetails = value;
            }
        }

        public string Comments
        {
            get
            {
                return this._Comments;
            }
            set
            {
                this._Comments = value;
            }
        }

        public int CourierID
        {
            get
            {
                return this._CourierID;
            }
            set
            {
                this._CourierID = value;
            }
        }

        public long CurrentPONO
        {
            get
            {
                return this._CurrentPONO;
            }
            set
            {
                this._CurrentPONO = value;
            }
        }

        public long DeliveryAddressID
        {
            get
            {
                return this._DeliveryAddressID;
            }
            set
            {
                this._DeliveryAddressID = value;
            }
        }

        public string DeliveryAddressType
        {
            get
            {
                return this._DeliveryAddressType;
            }
            set
            {
                this._DeliveryAddressType = value;
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

        public long EstimateAdditionalItemID
        {
            get
            {
                return this._EstimateAdditionalItemID;
            }
            set
            {
                this._EstimateAdditionalItemID = value;
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

        public new long EstimateItemID
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

        public string EstimateType
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

        public long EstLargeItemCalculationID
        {
            get
            {
                return this._EstLargeItemCalculationID;
            }
            set
            {
                this._EstLargeItemCalculationID = value;
            }
        }

        public string FootNote
        {
            get
            {
                return this._FootNote;
            }
            set
            {
                this._FootNote = value;
            }
        }

        public bool GoodsReceived
        {
            get
            {
                return this._GoodsReceived;
            }
            set
            {
                this._GoodsReceived = value;
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

        public string headernote
        {
            get
            {
                return this._headernote;
            }
            set
            {
                this._headernote = value;
            }
        }

        public bool InvoiceReceived
        {
            get
            {
                return this._InvoiceReceived;
            }
            set
            {
                this._InvoiceReceived = value;
            }
        }

        public bool isFromProductItem
        {
            get
            {
                return this._isFromProductItem;
            }
            set
            {
                this._isFromProductItem = value;
            }
        }

        public string IsFromProgreesTojob
        {
            get
            {
                return this._IsFromProgreesTojob;
            }
            set
            {
                this._IsFromProgreesTojob = value;
            }
        }

        public string ItemCode
        {
            get
            {
                return this._ItemCode;
            }
            set
            {
                this._ItemCode = value;
            }
        }

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this._Note = value;
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

        public DateTime PODate
        {
            get
            {
                return this._PODate;
            }
            set
            {
                this._PODate = value;
            }
        }

        public string PONO
        {
            get
            {
                return this._PONO;
            }
            set
            {
                this._PONO = value;
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

        public long PurchaseItemID
        {
            get
            {
                return this._PurchaseItemID;
            }
            set
            {
                this._PurchaseItemID = value;
            }
        }

        public decimal PurPackedIn
        {
            get
            {
                return this._PurPackedIn;
            }
            set
            {
                this._PurPackedIn = value;
            }
        }

        public decimal PurQty
        {
            get
            {
                return this._PurQty;
            }
            set
            {
                this._PurQty = value;
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

        public long RaisedByID
        {
            get
            {
                return this._RaisedByID;
            }
            set
            {
                this._RaisedByID = value;
            }
        }

        public string ReferenceNo
        {
            get
            {
                return this._ReferenceNo;
            }
            set
            {
                this._ReferenceNo = value;
            }
        }

        public DateTime ReqDate
        {
            get
            {
                return this._ReqDate;
            }
            set
            {
                this._ReqDate = value;
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

        public DateTime SupplierInvoiceDate
        {
            get
            {
                return this._SupplierInvoiceDate;
            }
            set
            {
                this._SupplierInvoiceDate = value;
            }
        }

        public string SupplierInvoiceNo
        {
            get
            {
                return this._SupplierInvoiceNo;
            }
            set
            {
                this._SupplierInvoiceNo = value;
            }
        }

        public string SupplierQuoteNo
        {
            get
            {
                return this._SupplierQuoteNo;
            }
            set
            {
                this._SupplierQuoteNo = value;
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

        public decimal TaxValue
        {
            get
            {
                return this._TaxValue;
            }
            set
            {
                this._TaxValue = value;
            }
        }

        public DateTime TodayDate
        {
            get
            {
                return this._TodayDate;
            }
            set
            {
                this._TodayDate = value;
            }
        }

        public long WarehouseItemID
        {
            get
            {
                return this._WarehouseItemID;
            }
            set
            {
                this._WarehouseItemID = value;
            }
        }

        public string WarehouseItemType
        {
            get
            {
                return this._WarehouseItemType;
            }
            set
            {
                this._WarehouseItemType = value;
            }
        }

        public PurchaseItem()
        {
        }
    }
}