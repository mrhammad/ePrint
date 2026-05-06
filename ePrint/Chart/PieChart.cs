using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Chart
{
	public class PieChart : Chart
	{
		private const int _bufferSpace = 125;

		private ArrayList _chartItems;

		private int _perimeter;

		private Color _backgroundColor;

		private Color _borderColor;

		private float _total;

		private int _legendWidth;

		private int _legendHeight;

		private int _legendFontHeight;

		private string _legendFontStyle;

		private float _legendFontSize;

		public PieChart()
		{
			this._chartItems = new ArrayList();
			this._perimeter = 150;
			this._backgroundColor = Color.White;
			this._borderColor = Color.FromArgb(63, 63, 63);
			this._legendFontSize = 8f;
			this._legendFontStyle = "Verdana";
		}

		public PieChart(Color bgColor)
		{
			this._chartItems = new ArrayList();
			this._perimeter = 250;
			this._backgroundColor = bgColor;
			this._borderColor = Color.FromArgb(63, 63, 63);
			this._legendFontSize = 8f;
			this._legendFontStyle = "Verdana";
		}

		private void CalculateLegendWidthHeight()
		{
			Font font = new Font(this._legendFontStyle, this._legendFontSize);
			this._legendFontHeight = font.Height + 5;
			this._legendHeight = font.Height * (this._chartItems.Count + 1);
			if (this._legendHeight > this._perimeter)
			{
				this._perimeter = this._legendHeight;
			}
			this._legendWidth = this._perimeter + 125;
		}

		public void CollectDataPoints(string[] xValues, string[] yValues)
		{
			this._total = 0f;
			for (int i = 0; i < (int)xValues.Length; i++)
			{
				float single = Convert.ToSingle(yValues[i]);
				this._chartItems.Add(new ChartItem(xValues[i], xValues.ToString(), single, 0f, 0f, Color.AliceBlue));
				PieChart pieChart = this;
				pieChart._total = pieChart._total + single;
			}
			float startPos = 0f;
			int num = 0;
			foreach (ChartItem _chartItem in this._chartItems)
			{
				_chartItem.StartPos = startPos;
				_chartItem.SweepSize = _chartItem.Value / this._total * 360f;
				startPos = _chartItem.StartPos + _chartItem.SweepSize;
				int num1 = num;
				num = num1 + 1;
				_chartItem.ItemColor = base.GetColor(num1);
			}
			this.CalculateLegendWidthHeight();
		}

		public override Bitmap Draw()
		{
			int num = this._perimeter;
			Rectangle rectangle = new Rectangle(0, 0, num, num - 1);
			Bitmap bitmap = new Bitmap(num + this._legendWidth, num);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.FillRectangle(new SolidBrush(this._backgroundColor), 0, 0, num + this._legendWidth, num);
			StringFormat stringFormat = new StringFormat()
			{
				Alignment = StringAlignment.Far
			};
			for (int i = 0; i < this._chartItems.Count; i++)
			{
				ChartItem item = (ChartItem)this._chartItems[i];
				SolidBrush solidBrush = new SolidBrush(item.ItemColor);
				graphic.FillPie(solidBrush, rectangle, item.StartPos, item.SweepSize);
				graphic.FillRectangle(solidBrush, num + 125, i * this._legendFontHeight + 15, 10, 10);
				graphic.DrawString(item.Label, new Font(this._legendFontStyle, this._legendFontSize), new SolidBrush(Color.Black), (float)(num + 125 + 20), (float)(i * this._legendFontHeight + 13));
				float value = item.Value;
				graphic.DrawString(value.ToString(), new Font(this._legendFontStyle, this._legendFontSize), new SolidBrush(Color.Black), (float)(num + 125 + 200), (float)(i * this._legendFontHeight + 13), stringFormat);
			}
			graphic.DrawEllipse(new Pen(this._borderColor, 2f), rectangle);
			graphic.DrawRectangle(new Pen(this._borderColor, 1f), num + 125 - 10, 10, 220, this._chartItems.Count * this._legendFontHeight + 25);
			graphic.DrawString("Total", new Font(this._legendFontStyle, this._legendFontSize, FontStyle.Bold), new SolidBrush(Color.Black), (float)(num + 125 + 30), (float)((this._chartItems.Count + 1) * this._legendFontHeight), stringFormat);
			graphic.DrawString(this._total.ToString(), new Font(this._legendFontStyle, this._legendFontSize, FontStyle.Bold), new SolidBrush(Color.Black), (float)(num + 125 + 200), (float)((this._chartItems.Count + 1) * this._legendFontHeight), stringFormat);
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			graphic.Dispose();
			return bitmap;
		}
	}
}