using System;

namespace TemplateEditorFrontEnd
{
	public class ColorStyle
	{
		private long _colorid;

		private long _templateid;

		private long _userid;

		private long _companyid;

		private string _colorstylename;

		private string _c;

		private string _m;

		private string _y;

		private string _k;

		private string _spotcolorref;

		private double _tint;

		private double _r;

		private double _g;

		private double _b;

		private double _a;

		private bool _spotcolor;

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

		public long ColorID
		{
			get
			{
				return this._colorid;
			}
			set
			{
				this._colorid = value;
			}
		}

		public string ColorStyleName
		{
			get
			{
				return this._colorstylename;
			}
			set
			{
				this._colorstylename = value;
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

		public ColorStyle()
		{
		}
	}
}