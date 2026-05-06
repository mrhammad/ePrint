using System;

public class GooglePolygon
{
	private string _status = "";

	private string _id = "";

	private GooglePoints _gpoints = new GooglePoints();

	private string _strokecolor = "#0000FF";

	private string _fillcolor = "#66FF00";

	private int _strokeweight = 10;

	private double _strokeopacity = 1;

	private double _fillopacity = 0.2;

	public string FillColor
	{
		get
		{
			return this._fillcolor;
		}
		set
		{
			this._fillcolor = value;
		}
	}

	public double FillOpacity
	{
		get
		{
			return this._fillopacity;
		}
		set
		{
			this._fillopacity = value;
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

	public string StrokeColor
	{
		get
		{
			return this._strokecolor;
		}
		set
		{
			this._strokecolor = value;
		}
	}

	public double StrokeOpacity
	{
		get
		{
			return this._strokeopacity;
		}
		set
		{
			this._strokeopacity = value;
		}
	}

	public int StrokeWeight
	{
		get
		{
			return this._strokeweight;
		}
		set
		{
			this._strokeweight = value;
		}
	}

	public GooglePolygon()
	{
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		GooglePolygon googlePolygon = obj as GooglePolygon;
		if (googlePolygon == null)
		{
			return false;
		}
		if (!(this.FillColor == googlePolygon.FillColor) || this.FillOpacity != googlePolygon.FillOpacity || !(googlePolygon.ID == this.ID) || !(googlePolygon.Status == this.Status) || !(googlePolygon.StrokeColor == this.StrokeColor) || googlePolygon.StrokeOpacity != this.StrokeOpacity || googlePolygon.StrokeWeight != this.StrokeWeight)
		{
			return false;
		}
		return googlePolygon.Points.Equals(this.Points);
	}
}