using System;

namespace TemplateEditor
{
    public class Font
    {
        private long _fontid;

        private long _userid;

        private long _templateid;

        private long _companyid;

        private string _fontstylename;

        private string _textalign;

        private string _capitalize;

        private string _datatype;

        private string _format;

        private string _fontfamily;

        private string _displaynmae;

        private string _realfontname;

        private string _offsetTrack;

        private string _trackpt;

        private string _extension;

        private string _FontFilePath;

        private double _fontsize;

        private double _indent;

        private double _manualtracking;

        public string ActualFontName
        {
            get
            {
                return this._displaynmae;
            }
            set
            {
                this._displaynmae = value;
            }
        }

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

        public long CompanyID
        {
            get
            {
                return this._companyid;
            }
            set
            {
                this._companyid = value;
            }
        }

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

        public string DisplayFontName
        {
            get
            {
                return this._realfontname;
            }
            set
            {
                this._realfontname = value;
            }
        }

        public string Fontextension
        {
            get
            {
                return this._extension;
            }
            set
            {
                this._extension = value;
            }
        }

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

        public string FontFilePath
        {
            get
            {
                return this._FontFilePath;
            }
            set
            {
                this._FontFilePath = value;
            }
        }

        public long FontID
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

        public string FontStyleName
        {
            get
            {
                return this._fontstylename;
            }
            set
            {
                this._fontstylename = value;
            }
        }

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

        public double ManualTracking
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

        public string TrackOffSet
        {
            get
            {
                return this._offsetTrack;
            }
            set
            {
                this._offsetTrack = value;
            }
        }

        public string TrackPoint
        {
            get
            {
                return this._trackpt;
            }
            set
            {
                this._trackpt = value;
            }
        }

        public long UserID
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public Font()
        {
        }
    }
}