using System;

public class GooglePolyline
{
	private string _linestatus = "";

	private string _id = "";

	private GooglePoints _gpoints = new GooglePoints();

	private string _colorcode = "#66FF00";

	private int _width = 10;

	private bool _geodesic;

	public string ColorCode
	{
		get
		{
			return this._colorcode;
		}
		set
		{
			this._colorcode = value;
		}
	}

	public bool Geodesic
	{
		get
		{
			return this._geodesic;
		}
		set
		{
			this._geodesic = value;
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

	public string LineStatus
	{
		get
		{
			return this._linestatus;
		}
		set
		{
			this._linestatus = value;
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

	public int Width
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

	public GooglePolyline()
	{
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		GooglePolyline googlePolyline = obj as GooglePolyline;
		if (googlePolyline == null)
		{
			return false;
		}
		if (this.Geodesic != googlePolyline.Geodesic || this.Width != googlePolyline.Width || !(googlePolyline.ID == this.ID) || !(googlePolyline.ColorCode == this.ColorCode))
		{
			return false;
		}
		return googlePolyline.Points.Equals(this.Points);
	}
}