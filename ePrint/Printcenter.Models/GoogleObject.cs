using System;

[Serializable]
public class GoogleObject
{
	private GoogleDirections _gdirections = new GoogleDirections();

	private GooglePoints _gpoints = new GooglePoints();

	private GooglePolylines _gpolylines = new GooglePolylines();

	private GooglePolygons _gpolygons = new GooglePolygons();

	private GooglePoint _centerpoint = new GooglePoint();

	private int _zoomlevel = 3;

	private bool _showzoomcontrol = true;

	private bool _recentermap;

	private bool _automaticboundaryandzoom;

	private bool _showtraffic;

	private bool _showmaptypescontrol = true;

	private string _width = "500px";

	private string _height = "400px";

	private string _maptype = "";

	private string _apikey = "";

	private string _apiversion = "2";

	public string APIKey
	{
		get
		{
			return this._apikey;
		}
		set
		{
			this._apikey = value;
		}
	}

	public string APIVersion
	{
		get
		{
			return this._apiversion;
		}
		set
		{
			this._apiversion = value;
		}
	}

	public bool AutomaticBoundaryAndZoom
	{
		get
		{
			return this._automaticboundaryandzoom;
		}
		set
		{
			this._automaticboundaryandzoom = value;
		}
	}

	public GooglePoint CenterPoint
	{
		get
		{
			return this._centerpoint;
		}
		set
		{
			this._centerpoint = value;
		}
	}

	public GoogleDirections Directions
	{
		get
		{
			return this._gdirections;
		}
		set
		{
			this._gdirections = value;
		}
	}

	public string Height
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

	public string MapType
	{
		get
		{
			return this._maptype;
		}
		set
		{
			this._maptype = value;
		}
	}

	public GooglePoints Points
	{
		get
		{
			return this._gpoints;
		}
		set
		{
			this._gpoints = value;
		}
	}

	public GooglePolygons Polygons
	{
		get
		{
			return this._gpolygons;
		}
		set
		{
			this._gpolygons = value;
		}
	}

	public GooglePolylines Polylines
	{
		get
		{
			return this._gpolylines;
		}
		set
		{
			this._gpolylines = value;
		}
	}

	public bool RecenterMap
	{
		get
		{
			return this._recentermap;
		}
		set
		{
			this._recentermap = value;
		}
	}

	public bool ShowMapTypesControl
	{
		get
		{
			return this._showmaptypescontrol;
		}
		set
		{
			this._showmaptypescontrol = value;
		}
	}

	public bool ShowTraffic
	{
		get
		{
			return this._showtraffic;
		}
		set
		{
			this._showtraffic = value;
		}
	}

	public bool ShowZoomControl
	{
		get
		{
			return this._showzoomcontrol;
		}
		set
		{
			this._showzoomcontrol = value;
		}
	}

	public string Width
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

	public int ZoomLevel
	{
		get
		{
			return this._zoomlevel;
		}
		set
		{
			this._zoomlevel = value;
		}
	}

	public GoogleObject()
	{
	}

	public GoogleObject(GoogleObject prev)
	{
		this.Directions = prev.Directions;
		this.Points = GooglePoints.CloneMe(prev.Points);
		this.Polylines = GooglePolylines.CloneMe(prev.Polylines);
		this.Polygons = GooglePolygons.CloneMe(prev.Polygons);
		this.ZoomLevel = prev.ZoomLevel;
		this.ShowZoomControl = prev.ShowZoomControl;
		this.ShowMapTypesControl = prev.ShowMapTypesControl;
		this.Width = prev.Width;
		this.Height = prev.Height;
		this.MapType = prev.MapType;
		this.APIKey = prev.APIKey;
		this.ShowTraffic = prev.ShowTraffic;
		this.RecenterMap = prev.RecenterMap;
		this.AutomaticBoundaryAndZoom = prev.AutomaticBoundaryAndZoom;
	}
}