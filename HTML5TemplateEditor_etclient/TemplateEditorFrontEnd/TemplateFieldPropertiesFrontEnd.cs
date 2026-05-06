using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TemplateEditorFrontEnd
{
	public class TemplateFieldPropertiesFrontEnd
	{
		private string _manualTrackingOriginal;

		private string _editedImageName;

		private string _background;

		private string _labelfntsyle;

		private string _orgnalname;

		private string _fontextension;

		private string _phrasetype;

		private string _createdfontstyle;

		private string _imgglry;

		private string _lblfontextension;

		private string _lblactualfontname;

		private string _actualfontname;

		private string _objectid;

		private string _tracksign;

		private string _trackdimension;

		private string _grouporeintation;

		private string _keepotions;

		private string _status;

		private string _fieldname;

		private string _friendlyname;

		private string _helptext;

		private string _exceedwidth;

		private string _fontstyle;

		private string _font;

		private string _manualtracking;

		private string _textalign;

		private string _capitalize;

		private string _datatype;

		private string _format;

		private string _colorstyle;

		private string _color;

		private string _c;

		private string _m;

		private string _y;

		private string _k;

		private string _spotcolorref;

		private string _defaultcontent;

		private string _databasecontent;

		private string _dropdowns;

		private string _labels;

		private string _objvalue;

		private string _labelstyle;

		private string _labelcolor;

		private string _labelposition;

		private string _objtag;

		private string _imgurl;

		private string _imgsrc;

		private string _align;

		private string _fontfamily;

		private string _fontweight;

		private string _textdecoration;

		private string _backgroundcolor;

		private string _defaultImageFrom;

		private string _CustomFieldType;

		private string _offsetwidth;

		private string _offsettop;

		private string _offsetleft;

		private string _pixelwidth;

		private string _pixelheight;

		private string _offsetheight;

		private string _type;

		private string _objtype;

		private string _exceedheight;

		private string _exceedimage;

		private string _imagelocation;

		private string _phoneFormat;

		private string _currencyFormat;

		private bool _isFromBackEnd;

		private bool _isImageQuality;

		private bool _isCropFromTop;

		private bool _isCropped;

		private bool _iscontentchanged;

		private bool _mandatory;

		private bool _iskeep;

		private bool _hide;

		private bool _edit;

		private bool _visibility;

		private bool _lock;

		private bool _spotcolor;

		private bool _copy;

		private bool _canchangefontcolor;

		private bool _canchangefontsize;

		private bool _canmove;

		private bool _canchangefont;

		private bool _underlinetext;

		private bool _isDisplayonPDf;

		private bool _isFromPdf;

		private bool _allowImageEdit;

		private bool _isjobnamefield;

		private bool _editdropdown;

		private int _zIndexValue;

		private int _zMinDPI;

		private int _pagenumber;

		private int _fontid;

		private int _lablfontid;

		private int _controlnumber;

		private int _phrasebookID;

		private int _UsedImageId;

		private double _originalfontsize;

		private double _positionX;

		private double _labelfontsize;

		private double _paralnspc;

		private double _positionY;

		private double _orignalpositionX;

		private double _orignalpositionY;

		private double _maxwidth;

		private double _maxshrink;

		private double _rotateangle;

		private double _fontsize;

		private double _indent;

		private double _tint;

		private double _customleft;

		private double _customtop;

		private double _customright;

		private double _maxheight;

		private double _positionoffset;

		private double _coordsX;

		private double _coordsY;

		private double _top;

		private double _left;

		private double _width;

		private double _height;

		private double _r;

		private double _g;

		private double _b;

		private double _a;

		private long _groupid;

		[DataMember]
		public double A
		{
			get
			{
				return this._a;
			}
			set
			{
				this._a = value;
			}
		}

		[DataMember]
		public string ActualFontName
		{
			get
			{
				return this._actualfontname;
			}
			set
			{
				this._actualfontname = value;
			}
		}

		[DataMember]
		public string Align
		{
			get
			{
				return this._align;
			}
			set
			{
				this._align = value;
			}
		}

		[DataMember]
		public bool AllowImageEdit
		{
			get
			{
				return this._allowImageEdit;
			}
			set
			{
				this._allowImageEdit = value;
			}
		}

		[DataMember]
		public double B
		{
			get
			{
				return this._b;
			}
			set
			{
				this._b = value;
			}
		}

		[DataMember]
		public string BackgroundColor
		{
			get
			{
				return this._backgroundcolor;
			}
			set
			{
				this._backgroundcolor = value;
			}
		}

		[DataMember]
		public string BackgroundImage
		{
			get
			{
				return this._background;
			}
			set
			{
				this._background = value;
			}
		}

		[DataMember]
		public string C
		{
			get
			{
				return this._c;
			}
			set
			{
				this._c = value;
			}
		}

		[DataMember]
		public bool CanChangeFont
		{
			get
			{
				return this._canchangefont;
			}
			set
			{
				this._canchangefont = value;
			}
		}

		[DataMember]
		public bool CanChangeFontColor
		{
			get
			{
				return this._canchangefontcolor;
			}
			set
			{
				this._canchangefontcolor = value;
			}
		}

		[DataMember]
		public bool CanChangeFontSize
		{
			get
			{
				return this._canchangefontsize;
			}
			set
			{
				this._canchangefontsize = value;
			}
		}

		[DataMember]
		public bool CanMove
		{
			get
			{
				return this._canmove;
			}
			set
			{
				this._canmove = value;
			}
		}

		[DataMember]
		public string Capitalize
		{
			get
			{
				return this._capitalize;
			}
			set
			{
				this._capitalize = value;
			}
		}

		[DataMember]
		public string Color
		{
			get
			{
				return this._color;
			}
			set
			{
				this._color = value;
			}
		}

		[DataMember]
		public string ColorStyle
		{
			get
			{
				return this._colorstyle;
			}
			set
			{
				this._colorstyle = value;
			}
		}

		[DataMember]
		public double CoordsX
		{
			get
			{
				return this._coordsX;
			}
			set
			{
				this._coordsX = value;
			}
		}

		[DataMember]
		public double CoordsY
		{
			get
			{
				return this._coordsY;
			}
			set
			{
				this._coordsY = value;
			}
		}

		[DataMember]
		public bool Copy
		{
			get
			{
				return this._copy;
			}
			set
			{
				this._copy = value;
			}
		}

		[DataMember]
		public string CurrencyFormat
		{
			get
			{
				return this._currencyFormat;
			}
			set
			{
				this._currencyFormat = value;
			}
		}

		[DataMember]
		public string CustomFieldType
		{
			get
			{
				return this._CustomFieldType;
			}
			set
			{
				this._CustomFieldType = value;
			}
		}

		[DataMember]
		public double CustomLeft
		{
			get
			{
				return this._customleft;
			}
			set
			{
				this._customleft = value;
			}
		}

		[DataMember]
		public double CustomRight
		{
			get
			{
				return this._customright;
			}
			set
			{
				this._customright = value;
			}
		}

		[DataMember]
		public double CustomTop
		{
			get
			{
				return this._customtop;
			}
			set
			{
				this._customtop = value;
			}
		}

		[DataMember]
		public string DatabaseContent
		{
			get
			{
				return this._databasecontent;
			}
			set
			{
				this._databasecontent = value;
			}
		}

		[DataMember]
		public string DataType
		{
			get
			{
				return this._datatype;
			}
			set
			{
				this._datatype = value;
			}
		}

		[DataMember]
		public string DefaultContent
		{
			get
			{
				return this._defaultcontent;
			}
			set
			{
				this._defaultcontent = value;
			}
		}

		[DataMember]
		public string DefaultImageFrom
		{
			get
			{
				return this._defaultImageFrom;
			}
			set
			{
				this._defaultImageFrom = value;
			}
		}

		[DataMember]
		public string Dropdowns
		{
			get
			{
				return this._dropdowns;
			}
			set
			{
				this._dropdowns = value;
			}
		}

		[DataMember]
		public bool Edit
		{
			get
			{
				return this._edit;
			}
			set
			{
				this._edit = value;
			}
		}

		[DataMember]
		public bool EditDropdown
		{
			get
			{
				return this._editdropdown;
			}
			set
			{
				this._editdropdown = value;
			}
		}

		public string EditedImageName
		{
			get
			{
				return this._editedImageName;
			}
			set
			{
				this._editedImageName = value;
			}
		}

		[DataMember]
		public string ExceedHeight
		{
			get
			{
				return this._exceedheight;
			}
			set
			{
				this._exceedheight = value;
			}
		}

		[DataMember]
		public string ExceedImage
		{
			get
			{
				return this._exceedimage;
			}
			set
			{
				this._exceedimage = value;
			}
		}

		[DataMember]
		public string ExceedWidth
		{
			get
			{
				return this._exceedwidth;
			}
			set
			{
				this._exceedwidth = value;
			}
		}

		[DataMember]
		public string FieldName
		{
			get
			{
				return this._fieldname;
			}
			set
			{
				this._fieldname = value;
			}
		}

		[DataMember]
		public string Font
		{
			get
			{
				return this._font;
			}
			set
			{
				this._font = value;
			}
		}

		[DataMember]
		public string FontExtension
		{
			get
			{
				return this._fontextension;
			}
			set
			{
				this._fontextension = value;
			}
		}

		[DataMember]
		public string FontFamily
		{
			get
			{
				return this._fontfamily;
			}
			set
			{
				this._fontfamily = value;
			}
		}

		[DataMember]
		public int FontID
		{
			get
			{
				return this._fontid;
			}
			set
			{
				this._fontid = value;
			}
		}

		[DataMember]
		public double FontSize
		{
			get
			{
				return this._fontsize;
			}
			set
			{
				this._fontsize = value;
			}
		}

		[DataMember]
		public string FontStyle
		{
			get
			{
				return this._fontstyle;
			}
			set
			{
				this._fontstyle = value;
			}
		}

		[DataMember]
		public string FontStyleName
		{
			get
			{
				return this._createdfontstyle;
			}
			set
			{
				this._createdfontstyle = value;
			}
		}

		public long FontSyleID
		{
			get;
			set;
		}

		[DataMember]
		public string FontWeight
		{
			get
			{
				return this._fontweight;
			}
			set
			{
				this._fontweight = value;
			}
		}

		[DataMember]
		public string Format
		{
			get
			{
				return this._format;
			}
			set
			{
				this._format = value;
			}
		}

		[DataMember]
		public string FriendlyName
		{
			get
			{
				return this._friendlyname;
			}
			set
			{
				this._friendlyname = value;
			}
		}

		[DataMember]
		public double G
		{
			get
			{
				return this._g;
			}
			set
			{
				this._g = value;
			}
		}

		[DataMember]
		public long GroupID
		{
			get
			{
				return this._groupid;
			}
			set
			{
				this._groupid = value;
			}
		}

		[DataMember]
		public string GroupOrientation
		{
			get
			{
				return this._grouporeintation;
			}
			set
			{
				this._grouporeintation = value;
			}
		}

		[DataMember]
		public double Height
		{
			get
			{
				return this._height;
			}
			set
			{
				this._height = value;
			}
		}

		[DataMember]
		public string HelpText
		{
			get
			{
				return this._helptext;
			}
			set
			{
				this._helptext = value;
			}
		}

		[DataMember]
		public bool HideVisibility
		{
			get
			{
				return this._hide;
			}
			set
			{
				this._hide = value;
			}
		}

		[DataMember]
		public string ImageGallery
		{
			get
			{
				return this._imgglry;
			}
			set
			{
				this._imgglry = value;
			}
		}

		[DataMember]
		public string ImageLocation
		{
			get
			{
				return this._imagelocation;
			}
			set
			{
				this._imagelocation = value;
			}
		}

		[DataMember]
		public string ImageSource
		{
			get
			{
				return this._imgsrc;
			}
			set
			{
				this._imgsrc = value;
			}
		}

		[DataMember]
		public string ImgUrl
		{
			get
			{
				return this._imgurl;
			}
			set
			{
				this._imgurl = value;
			}
		}

		[DataMember]
		public double Indent
		{
			get
			{
				return this._indent;
			}
			set
			{
				this._indent = value;
			}
		}

		[DataMember]
		public bool IsCropFromTop
		{
			get
			{
				return this._isCropFromTop;
			}
			set
			{
				this._isCropFromTop = value;
			}
		}

		[DataMember]
		public bool IsCropped
		{
			get
			{
				return this._isCropped;
			}
			set
			{
				this._isCropped = value;
			}
		}

		[DataMember]
		public bool IsDefaultContentChanged
		{
			get
			{
				return this._iscontentchanged;
			}
			set
			{
				this._iscontentchanged = value;
			}
		}

		[DataMember]
		public bool isDisplayonPDf
		{
			get
			{
				return this._isDisplayonPDf;
			}
			set
			{
				this._isDisplayonPDf = value;
			}
		}

		public bool IsFromBackEnd
		{
			get
			{
				return this._isFromBackEnd;
			}
			set
			{
				this._isFromBackEnd = value;
			}
		}

		public bool IsFromPdf
		{
			get
			{
				return this._isFromPdf;
			}
			set
			{
				this._isFromPdf = value;
			}
		}

		public bool IsImageQuality
		{
			get
			{
				return this._isImageQuality;
			}
			set
			{
				this._isImageQuality = value;
			}
		}

		[DataMember]
		public bool IsJobNameField
		{
			get
			{
				return this._isjobnamefield;
			}
			set
			{
				this._isjobnamefield = value;
			}
		}

		[DataMember]
		public bool IsKeepOtion
		{
			get
			{
				return this._iskeep;
			}
			set
			{
				this._iskeep = value;
			}
		}

		[DataMember]
		public string K
		{
			get
			{
				return this._k;
			}
			set
			{
				this._k = value;
			}
		}

		[DataMember]
		public string KeepOptions
		{
			get
			{
				return this._keepotions;
			}
			set
			{
				this._keepotions = value;
			}
		}

		[DataMember]
		public string LabelActualFontName
		{
			get
			{
				return this._lblactualfontname;
			}
			set
			{
				this._lblactualfontname = value;
			}
		}

		[DataMember]
		public string LabelColor
		{
			get
			{
				return this._labelcolor;
			}
			set
			{
				this._labelcolor = value;
			}
		}

		[DataMember]
		public string LabelFontExtension
		{
			get
			{
				return this._lblfontextension;
			}
			set
			{
				this._lblfontextension = value;
			}
		}

		[DataMember]
		public int LabelFontID
		{
			get
			{
				return this._lablfontid;
			}
			set
			{
				this._lablfontid = value;
			}
		}

		[DataMember]
		public double LabelFontSize
		{
			get
			{
				return this._labelfontsize;
			}
			set
			{
				this._labelfontsize = value;
			}
		}

		[DataMember]
		public string LabelFontStyle
		{
			get
			{
				return this._labelfntsyle;
			}
			set
			{
				this._labelfntsyle = value;
			}
		}

		[DataMember]
		public string LabelPosition
		{
			get
			{
				return this._labelposition;
			}
			set
			{
				this._labelposition = value;
			}
		}

		[DataMember]
		public string Labels
		{
			get
			{
				return this._labels;
			}
			set
			{
				this._labels = value;
			}
		}

		[DataMember]
		public string LabelStyle
		{
			get
			{
				return this._labelstyle;
			}
			set
			{
				this._labelstyle = value;
			}
		}

		public string LabelValue
		{
			get;
			set;
		}

		[DataMember]
		public double Left
		{
			get
			{
				return this._left;
			}
			set
			{
				this._left = value;
			}
		}

		[DataMember]
		public bool Lock
		{
			get
			{
				return this._lock;
			}
			set
			{
				this._lock = value;
			}
		}

		[DataMember]
		public string M
		{
			get
			{
				return this._m;
			}
			set
			{
				this._m = value;
			}
		}

		[DataMember]
		public bool Mandatory
		{
			get
			{
				return this._mandatory;
			}
			set
			{
				this._mandatory = value;
			}
		}

		[DataMember]
		public string ManualTrackDimension
		{
			get
			{
				return this._trackdimension;
			}
			set
			{
				this._trackdimension = value;
			}
		}

		[DataMember]
		public string ManualTracking
		{
			get
			{
				return this._manualtracking;
			}
			set
			{
				this._manualtracking = value;
			}
		}

		public string ManualTrackingOriginal
		{
			get
			{
				return this._manualTrackingOriginal;
			}
			set
			{
				this._manualTrackingOriginal = value;
			}
		}

		[DataMember]
		public string ManualTrackSign
		{
			get
			{
				return this._tracksign;
			}
			set
			{
				this._tracksign = value;
			}
		}

		[DataMember]
		public double MaxHeight
		{
			get
			{
				return this._maxheight;
			}
			set
			{
				this._maxheight = value;
			}
		}

		[DataMember]
		public double MaxShrink
		{
			get
			{
				return this._maxshrink;
			}
			set
			{
				this._maxshrink = value;
			}
		}

		[DataMember]
		public double MaxWidth
		{
			get
			{
				return this._maxwidth;
			}
			set
			{
				this._maxwidth = value;
			}
		}

		public int MinDPI
		{
			get
			{
				return this._zMinDPI;
			}
			set
			{
				this._zMinDPI = value;
			}
		}

		[DataMember]
		public string ObjectID
		{
			get
			{
				return this._objectid;
			}
			set
			{
				this._objectid = value;
			}
		}

		[DataMember]
		public string ObjTag
		{
			get
			{
				return this._objtag;
			}
			set
			{
				this._objtag = value;
			}
		}

		[DataMember]
		public string ObjType
		{
			get
			{
				return this._objtype;
			}
			set
			{
				this._objtype = value;
			}
		}

		[DataMember]
		public string ObjValue
		{
			get
			{
				return this._objvalue;
			}
			set
			{
				this._objvalue = value;
			}
		}

		[DataMember]
		public string OffsetHeight
		{
			get
			{
				return this._offsetheight;
			}
			set
			{
				this._offsetheight = value;
			}
		}

		[DataMember]
		public string OffsetLeft
		{
			get
			{
				return this._offsetleft;
			}
			set
			{
				this._offsetleft = value;
			}
		}

		[DataMember]
		public string OffsetTop
		{
			get
			{
				return this._offsettop;
			}
			set
			{
				this._offsettop = value;
			}
		}

		[DataMember]
		public string OffsetWidth
		{
			get
			{
				return this._offsetwidth;
			}
			set
			{
				this._offsetwidth = value;
			}
		}

		[DataMember]
		public int OrderNumber
		{
			get
			{
				return this._controlnumber;
			}
			set
			{
				this._controlnumber = value;
			}
		}

		public double OriginalFontSize
		{
			get
			{
				return this._originalfontsize;
			}
			set
			{
				this._originalfontsize = value;
			}
		}

		[DataMember]
		public string OrignalImageName
		{
			get
			{
				return this._orgnalname;
			}
			set
			{
				this._orgnalname = value;
			}
		}

		[DataMember]
		public double OrignalPositionX
		{
			get
			{
				return this._orignalpositionX;
			}
			set
			{
				this._orignalpositionX = value;
			}
		}

		[DataMember]
		public double OrignalPositionY
		{
			get
			{
				return this._orignalpositionY;
			}
			set
			{
				this._orignalpositionY = value;
			}
		}

		[DataMember]
		public int PageNumber
		{
			get
			{
				return this._pagenumber;
			}
			set
			{
				this._pagenumber = value;
			}
		}

		[DataMember]
		public double ParaLineSpace
		{
			get
			{
				return this._paralnspc;
			}
			set
			{
				this._paralnspc = value;
			}
		}

		[DataMember]
		public string PhoneFormat
		{
			get
			{
				return this._phoneFormat;
			}
			set
			{
				this._phoneFormat = value;
			}
		}

		[DataMember]
		public int PhraseBookID
		{
			get
			{
				return this._phrasebookID;
			}
			set
			{
				this._phrasebookID = value;
			}
		}

		[DataMember]
		public string PhraseType
		{
			get
			{
				return this._phrasetype;
			}
			set
			{
				this._phrasetype = value;
			}
		}

		[DataMember]
		public string PixelHeight
		{
			get
			{
				return this._pixelheight;
			}
			set
			{
				this._pixelheight = value;
			}
		}

		[DataMember]
		public string PixelWidth
		{
			get
			{
				return this._pixelwidth;
			}
			set
			{
				this._pixelwidth = value;
			}
		}

		[DataMember]
		public double PositionOffset
		{
			get
			{
				return this._positionoffset;
			}
			set
			{
				this._positionoffset = value;
			}
		}

		[DataMember]
		public double PositionX
		{
			get
			{
				return this._positionX;
			}
			set
			{
				this._positionX = value;
			}
		}

		[DataMember]
		public double PositionY
		{
			get
			{
				return this._positionY;
			}
			set
			{
				this._positionY = value;
			}
		}

		[DataMember]
		public double R
		{
			get
			{
				return this._r;
			}
			set
			{
				this._r = value;
			}
		}

		[DataMember]
		public double RotateAngle
		{
			get
			{
				return this._rotateangle;
			}
			set
			{
				this._rotateangle = value;
			}
		}

		[DataMember]
		public bool SpotColor
		{
			get
			{
				return this._spotcolor;
			}
			set
			{
				this._spotcolor = value;
			}
		}

		[DataMember]
		public string SpotColorRef
		{
			get
			{
				return this._spotcolorref;
			}
			set
			{
				this._spotcolorref = value;
			}
		}

		[DataMember]
		public string Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		[DataMember]
		public string TextAlign
		{
			get
			{
				return this._textalign;
			}
			set
			{
				this._textalign = value;
			}
		}

		[DataMember]
		public string TextDecoration
		{
			get
			{
				return this._textdecoration;
			}
			set
			{
				this._textdecoration = value;
			}
		}

		[DataMember]
		public double Tint
		{
			get
			{
				return this._tint;
			}
			set
			{
				this._tint = value;
			}
		}

		[DataMember]
		public double Top
		{
			get
			{
				return this._top;
			}
			set
			{
				this._top = value;
			}
		}

		[DataMember]
		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		[DataMember]
		public bool UnderlineText
		{
			get
			{
				return this._underlinetext;
			}
			set
			{
				this._underlinetext = value;
			}
		}

		[DataMember]
		public int UsedImageId
		{
			get
			{
				return this._UsedImageId;
			}
			set
			{
				this._UsedImageId = value;
			}
		}

		public string UserFontSyleName
		{
			get;
			set;
		}

		[DataMember]
		public bool Visibility
		{
			get
			{
				return this._visibility;
			}
			set
			{
				this._visibility = value;
			}
		}

		[DataMember]
		public double Width
		{
			get
			{
				return this._width;
			}
			set
			{
				this._width = value;
			}
		}

		[DataMember]
		public string Y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		public int ZIndexValue
		{
			get
			{
				return this._zIndexValue;
			}
			set
			{
				this._zIndexValue = value;
			}
		}

		public TemplateFieldPropertiesFrontEnd()
		{
		}
	}
}