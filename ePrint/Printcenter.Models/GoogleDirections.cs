using System;
using System.Collections;
using System.ComponentModel;

[Serializable]
public class GoogleDirections
{
	private ArrayList _addresses = new ArrayList();

	private string _locale = "en_US";

	private bool _showdirectioninstructions;

	private bool _hideMarkers;

	private double _polylineopacity = 0.6;

	private int _polylineweight = 3;

	private string _polylinecolor = "#0000FF";

	public ArrayList Addresses
	{
		get
		{
			return this._addresses;
		}
		set
		{
			this._addresses = value;
		}
	}

	public bool HideMarkers
	{
		get
		{
			return this._hideMarkers;
		}
		set
		{
			this._hideMarkers = value;
		}
	}

	public string Locale
	{
		get
		{
			return this._locale;
		}
		set
		{
			this._locale = value;
		}
	}

	[Description("Direction line color")]
	public string PolylineColor
	{
		get
		{
			return this._polylinecolor;
		}
		set
		{
			this._polylinecolor = value;
		}
	}

	[Description("Direction line opacity. Valid values : 0.1 to 1.0")]
	public double PolylineOpacity
	{
		get
		{
			return this._polylineopacity;
		}
		set
		{
			this._polylineopacity = value;
		}
	}

	[Description("Direction line weight or width. Valid values : 1 to 10.")]
	public int PolylineWeight
	{
		get
		{
			return this._polylineweight;
		}
		set
		{
			this._polylineweight = value;
		}
	}

	public bool ShowDirectionInstructions
	{
		get
		{
			return this._showdirectioninstructions;
		}
		set
		{
			this._showdirectioninstructions = value;
		}
	}

	public GoogleDirections()
	{
	}
}