using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

[Serializable]
public class ColumnSettings
{
	private string _uniqueName;

	private int _orderIndex;

	private Unit _width;

	private bool _visible;

	private bool _display;

	private GridKnownFunction _currentFilterFunction;

	private string _currentFilterValue;

	public GridKnownFunction CurrentFilterFunction
	{
		get
		{
			return this._currentFilterFunction;
		}
		set
		{
			this._currentFilterFunction = value;
		}
	}

	public string CurrentFilterValue
	{
		get
		{
			return this._currentFilterValue;
		}
		set
		{
			this._currentFilterValue = value;
		}
	}

	public bool Display
	{
		get
		{
			return this._display;
		}
		set
		{
			this._display = value;
		}
	}

	public int OrderIndex
	{
		get
		{
			return this._orderIndex;
		}
		set
		{
			this._orderIndex = value;
		}
	}

	public string UniqueName
	{
		get
		{
			return this._uniqueName;
		}
		set
		{
			this._uniqueName = value;
		}
	}

	public bool Visible
	{
		get
		{
			return this._visible;
		}
		set
		{
			this._visible = value;
		}
	}

	public Unit Width
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

	public ColumnSettings()
	{
	}
}