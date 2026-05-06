using System;

namespace TemplateEditorFrontEnd
{
    public class HorzontalGroupDetails
    {
        private long _templateid;

        private long _companyid;

        private long _grpid;

        private long _pagenumber;

        private string _align;

        private string _grpname;

        private string _KeepOptions;

        private string _grpOptions;

        private double _curentpositionx;

        private double _curentpositiony;

        private double _positionx;

        private double _positiony;

        private double _ControlSpacing;

        public Boolean GroupMoveRelative { get; set; }
        public decimal GroupMovementValue { get; set; }
        

        public string Alignment
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

        public double ControlSpace
        {
            get
            {
                return this._ControlSpacing;
            }
            set
            {
                this._ControlSpacing = value;
            }
        }

        public double CurrentPositionX
        {
            get
            {
                return this._curentpositionx;
            }
            set
            {
                this._curentpositionx = value;
            }
        }

        public double CurrentPositionY
        {
            get
            {
                return this._curentpositiony;
            }
            set
            {
                this._curentpositiony = value;
            }
        }

        public long GID
        {
            get
            {
                return this._grpid;
            }
            set
            {
                this._grpid = value;
            }
        }

        public string GroupName
        {
            get
            {
                return this._grpname;
            }
            set
            {
                this._grpname = value;
            }
        }

        public string GroupOption
        {
            get
            {
                return this._grpOptions;
            }
            set
            {
                this._grpOptions = value;
            }
        }

        public string GrpKeepOption
        {
            get
            {
                return this._KeepOptions;
            }
            set
            {
                this._KeepOptions = value;
            }
        }

        public long PageNumber
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

        public double PositionX
        {
            get
            {
                return this._positionx;
            }
            set
            {
                this._positionx = value;
            }
        }

        public double PositionY
        {
            get
            {
                return this._positiony;
            }
            set
            {
                this._positiony = value;
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

        public HorzontalGroupDetails()
        {
        }
    }
}