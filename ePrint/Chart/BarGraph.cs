using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Chart
{
	public class BarGraph : Chart
	{
		private const float _graphLegendSpacer = 15f;

		private const int _labelFontSize = 7;

		private const int _legendFontSize = 9;

		private const float _legendRectangleSize = 10f;

		private const float _spacer = 5f;

		private Color _backColor;

		private string _fontFamily;

		private string _longestTickValue = string.Empty;

		private float _maxTickValueWidth;

		private float _totalHeight;

		private float _totalWidth;

		private float _barWidth;

		private float _bottomBuffer;

		private bool _displayBarData;

		private Color _fontColor;

		private float _graphHeight;

		private float _graphWidth;

		private float _maxValue;

		private float _scaleFactor;

		private float _spaceBtwBars;

		private float _topBuffer;

		private float _xOrigin;

		private float _yOrigin;

		private string _yLabel;

		private int _yTickCount;

		private float _yTickValue;

		private bool _displayLegend;

		private float _legendWidth;

		private string _longestLabel = string.Empty;

		private float _maxLabelWidth;

		public Color BackgroundColor
		{
			set
			{
				this._backColor = value;
			}
		}

		public int BottomBuffer
		{
			set
			{
				this._bottomBuffer = Convert.ToSingle(value);
			}
		}

		public Color FontColor
		{
			set
			{
				this._fontColor = value;
			}
		}

		public string FontFamily
		{
			get
			{
				return this._fontFamily;
			}
			set
			{
				this._fontFamily = value;
			}
		}

		public int Height
		{
			get
			{
				return Convert.ToInt32(this._totalHeight);
			}
			set
			{
				this._totalHeight = Convert.ToSingle(value);
			}
		}

		public bool ShowData
		{
			get
			{
				return this._displayBarData;
			}
			set
			{
				this._displayBarData = value;
			}
		}

		public bool ShowLegend
		{
			get
			{
				return this._displayLegend;
			}
			set
			{
				this._displayLegend = value;
			}
		}

		public int TopBuffer
		{
			set
			{
				this._topBuffer = Convert.ToSingle(value);
			}
		}

		public string VerticalLabel
		{
			get
			{
				return this._yLabel;
			}
			set
			{
				this._yLabel = value;
			}
		}

		public int VerticalTickCount
		{
			get
			{
				return this._yTickCount;
			}
			set
			{
				this._yTickCount = value;
			}
		}

		public int Width
		{
			get
			{
				return Convert.ToInt32(this._totalWidth);
			}
			set
			{
				this._totalWidth = Convert.ToSingle(value);
			}
		}

		public BarGraph()
		{
			this.AssignDefaultSettings();
		}

		public BarGraph(Color bgColor)
		{
			this.AssignDefaultSettings();
			this.BackgroundColor = bgColor;
		}

		private void AssignDefaultSettings()
		{
			this._totalWidth = 700f;
			this._totalHeight = 450f;
			this._fontFamily = "Verdana";
			this._backColor = Color.White;
			this._fontColor = Color.Black;
			this._topBuffer = 30f;
			this._bottomBuffer = 30f;
			this._yTickCount = 2;
			this._displayLegend = false;
			this._displayBarData = false;
		}

		private void CalculateBarWidth(int dataCount, float barGraphWidth)
		{
			this._barWidth = barGraphWidth / (float)(dataCount * 2);
			this._spaceBtwBars = this._barWidth;
		}

		private void CalculateGraphDimension()
		{
			this.FindLongestTickValue();
			BarGraph barGraph = this;
			barGraph._longestTickValue = string.Concat(barGraph._longestTickValue, "0");
			this._maxTickValueWidth = this.CalculateImgFontWidth(this._longestTickValue, 7, this.FontFamily);
			float single = 5f + this._maxTickValueWidth;
			float single1 = 0f;
			if (!this._displayLegend)
			{
				single1 = 5f;
			}
			else
			{
				this._legendWidth = 20f + this._maxLabelWidth + 5f;
				single1 = 15f + this._legendWidth + 5f;
			}
			this._graphHeight = this._totalHeight - this._topBuffer - this._bottomBuffer;
			this._graphWidth = this._totalWidth - single - single1;
			this._xOrigin = single;
			this._yOrigin = this._topBuffer;
			this._scaleFactor = this._maxValue / this._graphHeight;
		}

		private float CalculateImgFontWidth(string text, int size, string family)
		{
			float width;
			Bitmap bitmap = null;
			Graphics graphic = null;
			Font font = null;
			try
			{
				font = new Font(family, (float)size);
				bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
				graphic = Graphics.FromImage(bitmap);
				width = graphic.MeasureString(text, font).Width;
			}
			finally
			{
				if (graphic != null)
				{
					graphic.Dispose();
				}
				if (bitmap != null)
				{
					bitmap.Dispose();
				}
				if (font != null)
				{
					font.Dispose();
				}
			}
			return width;
		}

		private void CalculateSweepValues()
		{
			int num = 0;
			foreach (ChartItem dataPoint in base.DataPoints)
			{
				if (dataPoint.Value >= 0f)
				{
					dataPoint.SweepSize = dataPoint.Value / this._scaleFactor;
				}
				dataPoint.StartPos = this._spaceBtwBars / 2f + (float)num * (this._barWidth + this._spaceBtwBars);
				num++;
			}
		}

		private void CalculateTickAndMax()
		{
			float single = 0f;
			BarGraph barGraph = this;
			barGraph._maxValue = barGraph._maxValue * 1.1f;
			if (this._maxValue == 0f)
			{
				single = 1f;
			}
			else
			{
				double num = Convert.ToDouble(Math.Floor(Math.Log10((double)this._maxValue)));
				single = Convert.ToSingle(Math.Ceiling((double)this._maxValue / Math.Pow(10, num)) * Math.Pow(10, num));
			}
			this._yTickValue = single / (float)this._yTickCount;
			double num1 = Convert.ToDouble(Math.Floor(Math.Log10((double)this._yTickValue)));
			this._yTickValue = Convert.ToSingle(Math.Ceiling((double)this._yTickValue / Math.Pow(10, num1)) * Math.Pow(10, num1));
			this._maxValue = this._yTickValue * (float)this._yTickCount;
		}

		public void CollectDataPoints(string[] labels, string[] values)
		{
			if ((int)labels.Length != (int)values.Length)
			{
				throw new Exception("X data count is different from Y data count");
			}
			for (int i = 0; i < (int)labels.Length; i++)
			{
				float single = Convert.ToSingle(values[i]);
				string str = this.MakeShortLabel(labels[i]);
				base.DataPoints.Add(new ChartItem(str, labels[i], single, 0f, 0f, base.GetColor(i)));
				if (this._maxValue < single)
				{
					this._maxValue = single;
				}
				if (this._displayLegend)
				{
					string str1 = string.Concat(labels[i], " (", str, ")");
					float single1 = this.CalculateImgFontWidth(str1, 9, this.FontFamily);
					if (this._maxLabelWidth < single1)
					{
						this._longestLabel = str1;
						this._maxLabelWidth = single1;
					}
				}
			}
			this.CalculateTickAndMax();
			this.CalculateGraphDimension();
			this.CalculateBarWidth(base.DataPoints.Count, this._graphWidth);
			this.CalculateSweepValues();
		}

		public void CollectDataPoints(string[] values)
		{
			this.CollectDataPoints(values, values);
		}

		public override Bitmap Draw()
		{
			int num = Convert.ToInt32(this._totalHeight);
			Bitmap bitmap = new Bitmap(Convert.ToInt32(this._totalWidth), num);
			using (Graphics graphic = Graphics.FromImage(bitmap))
			{
				graphic.CompositingQuality = CompositingQuality.HighQuality;
				graphic.SmoothingMode = SmoothingMode.AntiAlias;
				graphic.FillRectangle(new SolidBrush(this._backColor), -1, -1, bitmap.Width + 1, bitmap.Height + 1);
				this.DrawVerticalLabelArea(graphic);
				this.DrawBars(graphic);
				this.DrawXLabelArea(graphic);
				if (this._displayLegend)
				{
					this.DrawLegend(graphic);
				}
			}
			return bitmap;
		}

		private void DrawBars(Graphics graph)
		{
			SolidBrush solidBrush = null;
			Font font = null;
			StringFormat stringFormat = null;
			try
			{
				solidBrush = new SolidBrush(this._fontColor);
				font = new Font(this._fontFamily, 7f);
				stringFormat = new StringFormat()
				{
					Alignment = StringAlignment.Center
				};
				int num = 0;
				foreach (ChartItem dataPoint in base.DataPoints)
				{
					using (SolidBrush solidBrush1 = new SolidBrush(dataPoint.ItemColor))
					{
						float sweepSize = this._yOrigin + this._graphHeight - dataPoint.SweepSize;
						graph.FillRectangle(solidBrush1, this._xOrigin + dataPoint.StartPos, sweepSize, this._barWidth, dataPoint.SweepSize);
						if (this._displayBarData)
						{
							float single = this._xOrigin + (float)num * (this._barWidth + this._spaceBtwBars);
							float height = sweepSize - 2f - (float)font.Height;
							RectangleF rectangleF = new RectangleF(single, height, this._barWidth + this._spaceBtwBars, (float)font.Height);
							float value = dataPoint.Value;
							graph.DrawString(value.ToString("#,###.##"), font, solidBrush, rectangleF, stringFormat);
						}
						num++;
					}
				}
			}
			finally
			{
				if (solidBrush != null)
				{
					solidBrush.Dispose();
				}
				if (font != null)
				{
					font.Dispose();
				}
				if (stringFormat != null)
				{
					stringFormat.Dispose();
				}
			}
		}

		private void DrawLegend(Graphics graph)
		{
			Font font = null;
			SolidBrush solidBrush = null;
			StringFormat stringFormat = null;
			Pen pen = null;
			try
			{
				font = new Font(this._fontFamily, 9f);
				solidBrush = new SolidBrush(this._fontColor);
				stringFormat = new StringFormat();
				pen = new Pen(this._fontColor);
				stringFormat.Alignment = StringAlignment.Near;
				float single = this._xOrigin + this._graphWidth + 15f;
				float single1 = this._yOrigin;
				float single2 = single + 5f;
				float single3 = single2 + 10f + 5f;
				float height = 0f;
				for (int i = 0; i < base.DataPoints.Count; i++)
				{
					ChartItem item = base.DataPoints[i];
					string str = string.Concat(item.Description, " (", item.Label, ")");
					float height1 = single1 + 5f + (float)i * ((float)font.Height + 5f);
					height = height + ((float)font.Height + 5f);
					graph.DrawString(str, font, solidBrush, single3, height1, stringFormat);
					graph.FillRectangle(new SolidBrush(base.DataPoints[i].ItemColor), single2, height1 + 3f, 10f, 10f);
				}
				graph.DrawRectangle(pen, single, single1, this._legendWidth, height + 5f);
			}
			finally
			{
				if (font != null)
				{
					font.Dispose();
				}
				if (solidBrush != null)
				{
					solidBrush.Dispose();
				}
				if (stringFormat != null)
				{
					stringFormat.Dispose();
				}
				if (pen != null)
				{
					pen.Dispose();
				}
			}
		}

		private void DrawVerticalLabelArea(Graphics graph)
		{
			Font font = null;
			SolidBrush solidBrush = null;
			StringFormat stringFormat = null;
			Pen pen = null;
			StringFormat stringFormat1 = null;
			try
			{
				font = new Font(this._fontFamily, 7f);
				solidBrush = new SolidBrush(this._fontColor);
				stringFormat = new StringFormat();
				pen = new Pen(this._fontColor);
				stringFormat1 = new StringFormat();
				stringFormat.Alignment = StringAlignment.Near;
				RectangleF rectangleF = new RectangleF(0f, this._yOrigin - 10f - (float)font.Height, this._xOrigin * 2f, (float)font.Height);
				stringFormat1.Alignment = StringAlignment.Center;
				graph.DrawString(this._yLabel, font, solidBrush, rectangleF, stringFormat1);
				for (int i = 0; i < this._yTickCount; i++)
				{
					float single = this._topBuffer + (float)i * this._yTickValue / this._scaleFactor;
					float height = single - (float)(font.Height / 2);
					RectangleF rectangleF1 = new RectangleF(5f, height, this._maxTickValueWidth, (float)font.Height);
					float single1 = this._maxValue - (float)i * this._yTickValue;
					graph.DrawString(single1.ToString("#,###.##"), font, solidBrush, rectangleF1, stringFormat);
					graph.DrawLine(pen, this._xOrigin, single, this._xOrigin - 4f, single);
				}
				graph.DrawLine(pen, this._xOrigin, this._yOrigin, this._xOrigin, this._yOrigin + this._graphHeight);
			}
			finally
			{
				if (font != null)
				{
					font.Dispose();
				}
				if (solidBrush != null)
				{
					solidBrush.Dispose();
				}
				if (stringFormat != null)
				{
					stringFormat.Dispose();
				}
				if (pen != null)
				{
					pen.Dispose();
				}
				if (stringFormat1 != null)
				{
					stringFormat1.Dispose();
				}
			}
		}

		private void DrawXLabelArea(Graphics graph)
		{
			Font font = null;
			SolidBrush solidBrush = null;
			StringFormat stringFormat = null;
			Pen pen = null;
			try
			{
				font = new Font(this._fontFamily, 7f);
				solidBrush = new SolidBrush(this._fontColor);
				stringFormat = new StringFormat();
				pen = new Pen(this._fontColor);
				stringFormat.Alignment = StringAlignment.Center;
				graph.DrawLine(pen, this._xOrigin, this._yOrigin + this._graphHeight, this._xOrigin + this._graphWidth, this._yOrigin + this._graphHeight);
				float single = this._yOrigin + this._graphHeight + 2f;
				float single1 = this._barWidth + this._spaceBtwBars;
				int num = 0;
				foreach (ChartItem dataPoint in base.DataPoints)
				{
					float single2 = this._xOrigin + (float)num * single1;
					RectangleF rectangleF = new RectangleF(single2, single, single1, (float)font.Height);
					graph.DrawString((this._displayLegend ? dataPoint.Label : dataPoint.Description), font, solidBrush, rectangleF, stringFormat);
					num++;
				}
			}
			finally
			{
				if (font != null)
				{
					font.Dispose();
				}
				if (solidBrush != null)
				{
					solidBrush.Dispose();
				}
				if (stringFormat != null)
				{
					stringFormat.Dispose();
				}
				if (pen != null)
				{
					pen.Dispose();
				}
			}
		}

		private void FindLongestTickValue()
		{
			for (int i = 0; i < this._yTickCount; i++)
			{
				float single = this._maxValue - (float)i * this._yTickValue;
				string str = single.ToString("#,###.##");
				if (this._longestTickValue.Length < str.Length)
				{
					this._longestTickValue = str;
				}
			}
		}

		private string MakeShortLabel(string text)
		{
			return text;
		}
	}
}