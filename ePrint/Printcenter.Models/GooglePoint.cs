using System;
using System.Drawing;

public class GooglePoint
{
	private string _pointstatus = "";

	private string _address = "";

	private string _id = "";

	private string _icon = "";

	private string _iconshadowimage = "";

	private int _iconimagewidth = 32;

	private int _iconshadowwidth;

	private int _iconshadowheight;

	private int _iconanchor_posx = 16;

	private int _iconanchor_posy = 32;

	private int _infowindowanchor_posx = 16;

	private int _infowindowanchor_posy = 5;

	private bool _draggable;

	private int _iconimageheight = 32;

	private double _lat;

	private double _lon;

	private string _infohtml = "";

	private string _tooltip = "";

	public string Address
	{
		get
		{
			return this._address;
		}
		set
		{
			this._address = value;
		}
	}

	public bool Draggable
	{
		get
		{
			return this._draggable;
		}
		set
		{
			this._draggable = value;
		}
	}

	public int IconAnchor_posX
	{
		get
		{
			return this._iconanchor_posx;
		}
		set
		{
			this._iconanchor_posx = value;
		}
	}

	public int IconAnchor_posY
	{
		get
		{
			return this._iconanchor_posy;
		}
		set
		{
			this._iconanchor_posy = value;
		}
	}

	public string IconImage
	{
		get
		{
			return this._icon;
		}
		set
		{
			string str = value;
			if (str == "")
			{
				return;
			}
			string str1 = string.Concat(cCommon.GetLocalPath(), str.Replace("/", "\\"));
			using (Image image = Image.FromFile(str1))
			{
				this.IconImageWidth = image.Width;
				this.IconImageHeight = image.Height;
				this.IconAnchor_posX = image.Width / 2;
				this.IconAnchor_posY = image.Height;
				this.InfoWindowAnchor_posX = image.Width / 2;
				this.InfoWindowAnchor_posY = image.Height / 3;
			}
			this._icon = string.Concat(cCommon.GetHttpURL(), str);
			this._icon = value;
		}
	}

	public int IconImageHeight
	{
		get
		{
			return this._iconimageheight;
		}
		set
		{
			this._iconimageheight = value;
		}
	}

	public int IconImageWidth
	{
		get
		{
			return this._iconimagewidth;
		}
		set
		{
			this._iconimagewidth = value;
		}
	}

	public int IconShadowHeight
	{
		get
		{
			return this._iconshadowheight;
		}
		set
		{
			this._iconshadowheight = value;
		}
	}

	public string IconShadowImage
	{
		get
		{
			return this._iconshadowimage;
		}
		set
		{
			string str = value;
			if (str == "")
			{
				return;
			}
			string str1 = string.Concat(cCommon.GetLocalPath(), str.Replace("/", "\\"));
			using (Image image = Image.FromFile(str1))
			{
				this.IconShadowWidth = image.Width;
				this.IconShadowHeight = image.Height;
			}
			this._iconshadowimage = string.Concat(cCommon.GetHttpURL(), str);
			this._iconshadowimage = value;
		}
	}

	public int IconShadowWidth
	{
		get
		{
			return this._iconshadowwidth;
		}
		set
		{
			this._iconshadowwidth = value;
		}
	}

	public string ID
	{
		get
		{
			return this._id;
		}
		set
		{
			this._id = value;
		}
	}

	public string InfoHTML
	{
		get
		{
			return this._infohtml;
		}
		set
		{
			this._infohtml = value;
		}
	}

	public int InfoWindowAnchor_posX
	{
		get
		{
			return this._infowindowanchor_posx;
		}
		set
		{
			this._infowindowanchor_posx = value;
		}
	}

	public int InfoWindowAnchor_posY
	{
		get
		{
			return this._infowindowanchor_posy;
		}
		set
		{
			this._infowindowanchor_posy = value;
		}
	}

	public double Latitude
	{
		get
		{
			return this._lat;
		}
		set
		{
			this._lat = value;
		}
	}

	public double Longitude
	{
		get
		{
			return this._lon;
		}
		set
		{
			this._lon = value;
		}
	}

	public string PointStatus
	{
		get
		{
			return this._pointstatus;
		}
		set
		{
			this._pointstatus = value;
		}
	}

	public string ToolTip
	{
		get
		{
			return this._tooltip;
		}
		set
		{
			this._tooltip = value;
		}
	}

	public GooglePoint()
	{
	}

	public GooglePoint(string pID, double plat, double plon, string picon, string pinfohtml)
	{
		this.ID = pID;
		this.Latitude = plat;
		this.Longitude = plon;
		this.IconImage = picon;
		this.InfoHTML = pinfohtml;
	}

	public GooglePoint(string pID, double plat, double plon, string picon, string pinfohtml, string pTooltipText, bool pDraggable)
	{
		this.ID = pID;
		this.Latitude = plat;
		this.Longitude = plon;
		this.IconImage = picon;
		this.InfoHTML = pinfohtml;
		this.ToolTip = pTooltipText;
		this.Draggable = pDraggable;
	}

	public GooglePoint(string pID, double plat, double plon, string picon)
	{
		this.ID = pID;
		this.Latitude = plat;
		this.Longitude = plon;
		this.IconImage = picon;
	}

	public GooglePoint(string pID, double plat, double plon)
	{
		this.ID = pID;
		this.Latitude = plat;
		this.Longitude = plon;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		GooglePoint googlePoint = obj as GooglePoint;
		if (googlePoint == null)
		{
			return false;
		}
		if (!(this.InfoHTML == googlePoint.InfoHTML) || !(this.IconImage == googlePoint.IconImage) || !(googlePoint.ID == this.ID) || googlePoint.Latitude != this.Latitude)
		{
			return false;
		}
		return googlePoint.Longitude == this.Longitude;
	}

	public bool GeocodeAddress(string sAPIKey)
	{
		return cCommon.GeocodeAddress(this, sAPIKey);
	}
}