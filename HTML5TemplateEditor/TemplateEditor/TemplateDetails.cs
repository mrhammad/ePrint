using System;

namespace TemplateEditor
{
    public class TemplateDetails
    {
        private long _templateid;

        private long _createdby;

        private long _pricecatalogueid;

        private long _companyID;

        private long _userID;

        private string _templatename;

        private string _templatedescription;

        private string _title;

        private string _pdfname;

        private string _imagename;

        private string _watermarktext;

        private string _productName;

        private DateTime _createdon;

        private bool _isdeleted;

        private bool _showeditpages;

        private bool _sendattach;

        private bool _addnewtextblock;

        private bool _addnewparagraph;

        private bool _addnewimage;

        private bool _showeditor;

        private bool _isconverted;

        private bool _isoverprintfilerequired;

        private bool _isallowpdfpreview;

        private bool _ispdfpreviewmandatory;

        private bool _isallowwatermark;

        private bool _isgroupconsiderlabel;

        private double _pagewidth;

        private double _pageheight;

        private double _zoompercent;

        private double _zoomX;

        private double _zoomY;

        private double _cropmarkwidth;

        private double _cropmarkheight;

        private double _r;

        private double _g;

        private double _b;

        private double _a;

        private double _Totalpage;

        public bool AddNewImage
        {
            get
            {
                return this._addnewimage;
            }
            set
            {
                this._addnewimage = value;
            }
        }

        public bool AddNewParagraph
        {
            get
            {
                return this._addnewparagraph;
            }
            set
            {
                this._addnewparagraph = value;
            }
        }

        public bool AddNewTextBlock
        {
            get
            {
                return this._addnewtextblock;
            }
            set
            {
                this._addnewtextblock = value;
            }
        }

        public long CompanyID
        {
            get
            {
                return this._companyID;
            }
            set
            {
                this._companyID = value;
            }
        }

        public long CreatedBy
        {
            get
            {
                return this._createdby;
            }
            set
            {
                this._createdby = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this._createdon;
            }
            set
            {
                this._createdon = value;
            }
        }

        public double CropMarkHeight
        {
            get
            {
                return this._cropmarkheight;
            }
            set
            {
                this._cropmarkheight = value;
            }
        }

        public double CropMarkWidth
        {
            get
            {
                return this._cropmarkwidth;
            }
            set
            {
                this._cropmarkwidth = value;
            }
        }

        public string ImageName
        {
            get
            {
                return this._imagename;
            }
            set
            {
                this._imagename = value;
            }
        }

        public bool IsAllowPDFPreviews
        {
            get
            {
                return this._isallowpdfpreview;
            }
            set
            {
                this._isallowpdfpreview = value;
            }
        }

        public bool IsAllowWaterMark
        {
            get
            {
                return this._isallowwatermark;
            }
            set
            {
                this._isallowwatermark = value;
            }
        }

        public bool IsConverted
        {
            get
            {
                return this._isconverted;
            }
            set
            {
                this._isconverted = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this._isdeleted;
            }
            set
            {
                this._isdeleted = value;
            }
        }

        public bool IsGroupConsiderLabel
        {
            get
            {
                return this._isgroupconsiderlabel;
            }
            set
            {
                this._isgroupconsiderlabel = value;
            }
        }

        public bool IsOverPrintFileRequired
        {
            get
            {
                return this._isoverprintfilerequired;
            }
            set
            {
                this._isoverprintfilerequired = value;
            }
        }

        public bool isPDFPreviewMandatory
        {
            get
            {
                return this._ispdfpreviewmandatory;
            }
            set
            {
                this._ispdfpreviewmandatory = value;
            }
        }

        public double PageHeight
        {
            get
            {
                return this._pageheight;
            }
            set
            {
                this._pageheight = value;
            }
        }

        public double PageWidth
        {
            get
            {
                return this._pagewidth;
            }
            set
            {
                this._pagewidth = value;
            }
        }

        public string PDFName
        {
            get
            {
                return this._pdfname;
            }
            set
            {
                this._pdfname = value;
            }
        }

        public long PriceCatalogueID
        {
            get
            {
                return this._pricecatalogueid;
            }
            set
            {
                this._pricecatalogueid = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this._productName;
            }
            set
            {
                this._productName = value;
            }
        }

        public bool SendAttachment
        {
            get
            {
                return this._sendattach;
            }
            set
            {
                this._sendattach = value;
            }
        }

        public bool ShowEdiotr
        {
            get
            {
                return this._showeditor;
            }
            set
            {
                this._showeditor = value;
            }
        }

        public bool ShowEditablePages
        {
            get
            {
                return this._showeditpages;
            }
            set
            {
                this._showeditpages = value;
            }
        }

        public string TemplateDescription
        {
            get
            {
                return this._templatedescription;
            }
            set
            {
                this._templatedescription = value;
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

        public string TemplateName
        {
            get
            {
                return this._templatename;
            }
            set
            {
                this._templatename = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public double Totalpage
        {
            get
            {
                return this._Totalpage;
            }
            set
            {
                this._Totalpage = value;
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

        public string WaterMarkText
        {
            get
            {
                return this._watermarktext;
            }
            set
            {
                this._watermarktext = value;
            }
        }

        public double ZoomPercent
        {
            get
            {
                return this._zoompercent;
            }
            set
            {
                this._zoompercent = value;
            }
        }

        public double ZoomX
        {
            get
            {
                return this._zoomX;
            }
            set
            {
                this._zoomX = value;
            }
        }

        public double ZoomY
        {
            get
            {
                return this._zoomY;
            }
            set
            {
                this._zoomY = value;
            }
        }

        public TemplateDetails()
        {
        }
    }
}