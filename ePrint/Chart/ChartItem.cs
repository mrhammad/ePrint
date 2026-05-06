using System;
using System.Drawing;

namespace Chart
{
	public class ChartItem
	{
		private string _label;

		private string _description;

		private float _value;

		private Color _color;

		private float _startPos;

		private float _sweepSize;

		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}

		public Color ItemColor
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

		public string Label
		{
			get
			{
				return this._label;
			}
			set
			{
				this._label = value;
			}
		}

		public float StartPos
		{
			get
			{
				return this._startPos;
			}
			set
			{
				this._startPos = value;
			}
		}

		public float SweepSize
		{
			get
			{
				return this._sweepSize;
			}
			set
			{
				this._sweepSize = value;
			}
		}

		public float Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		private ChartItem()
		{
		}

		public ChartItem(string label, string desc, float data, float start, float sweep, Color clr)
		{
			this._label = label;
			this._description = desc;
			this._value = data;
			this._startPos = start;
			this._sweepSize = sweep;
			this._color = clr;
		}
	}
}