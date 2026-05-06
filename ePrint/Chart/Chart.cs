using System;
using System.Drawing;

namespace Chart
{
	public abstract class Chart
	{
		private const int _colorLimit = 100;

		private Color[] _color = new Color[] { Color.Chocolate, Color.YellowGreen, Color.Olive, Color.DarkKhaki, Color.Sienna, Color.PaleGoldenrod, Color.Peru, Color.Tan, Color.Khaki, Color.DarkGoldenrod, Color.Maroon, Color.OliveDrab };

		private ChartItemsCollection _dataPoints = new ChartItemsCollection();

		public ChartItemsCollection DataPoints
		{
			get
			{
				return this._dataPoints;
			}
			set
			{
				this._dataPoints = value;
			}
		}

		protected Chart()
		{
		}

		public abstract Bitmap Draw();

		public Color GetColor(int index)
		{
			if (index > 11)
			{
				index = index % 11;
			}
			if (index >= 100)
			{
				throw new Exception(string.Concat("Color Limit is ", 100));
			}
			return this._color[index];
		}

		public void SetColor(int index, Color NewColor)
		{
			if (index > 11)
			{
				index = index % 11;
			}
			if (index >= 100)
			{
				throw new Exception(string.Concat("Color Limit is ", 100));
			}
			this._color[index] = NewColor;
		}
	}
}