using System;
using System.Drawing;

namespace UtChart
{
	public class pieChartData
	{
		private float[] m_Vals;

		private float[] m_PercentVal;

		private float[] m_StartAngle;

		private float[] m_Span;

		private string[] m_Legends;

		private string[] m_Links;

		private bool[] m_Explode;

		private ushort m_TopMargin;

		private ushort m_BottomMargin;

		private ushort m_RightMargin;

		private ushort m_LeftMargin;

		private byte m_Pie3dRatio;

		private byte m_pieRatio;

		private byte m_ExploadOffset;

		private Font m_chartFont;

		private ushort m_elements;

		private ushort m_pieDia;

		private UtChart.imageFormat m_imageFormat;

		private Color[] m_colorVal;

		public ushort bottomMargin
		{
			get
			{
				return this.m_BottomMargin;
			}
			set
			{
				this.m_BottomMargin = value;
			}
		}

		public Font chartFont
		{
			get
			{
				return this.m_chartFont;
			}
			set
			{
				this.m_chartFont = value;
			}
		}

		public Color[] colorVal
		{
			get
			{
				return this.m_colorVal;
			}
			set
			{
				this.m_colorVal = value;
			}
		}

		public ushort elements
		{
			get
			{
				return this.m_elements;
			}
			set
			{
				this.m_elements = value;
			}
		}

		public byte ExploadOffset
		{
			get
			{
				return this.m_ExploadOffset;
			}
			set
			{
				this.m_ExploadOffset = value;
			}
		}

		public bool[] Explode
		{
			get
			{
				return this.m_Explode;
			}
			set
			{
				this.m_Explode = value;
			}
		}

		public UtChart.imageFormat imageFormat
		{
			get
			{
				return this.m_imageFormat;
			}
			set
			{
				this.m_imageFormat = value;
			}
		}

		public ushort leftMargin
		{
			get
			{
				return this.m_LeftMargin;
			}
			set
			{
				this.m_LeftMargin = value;
			}
		}

		public string[] Legends
		{
			get
			{
				return this.m_Legends;
			}
			set
			{
				this.m_Legends = value;
			}
		}

		public string[] Links
		{
			get
			{
				return this.m_Links;
			}
			set
			{
				this.m_Links = value;
			}
		}

		public float[] percentVal
		{
			get
			{
				return this.m_PercentVal;
			}
		}

		public byte pie3dRatio
		{
			get
			{
				return this.m_Pie3dRatio;
			}
			set
			{
				this.m_Pie3dRatio = value;
			}
		}

		public ushort pieDia
		{
			get
			{
				return this.m_pieDia;
			}
			set
			{
				this.m_pieDia = value;
			}
		}

		public byte pieRatio
		{
			get
			{
				return this.m_pieRatio;
			}
			set
			{
				this.m_pieRatio = value;
			}
		}

		public ushort rightMargin
		{
			get
			{
				return this.m_RightMargin;
			}
			set
			{
				this.m_RightMargin = value;
			}
		}

		public float[] span
		{
			get
			{
				return this.m_Span;
			}
			set
			{
				this.m_Span = value;
			}
		}

		public float[] startAngle
		{
			get
			{
				return this.m_StartAngle;
			}
			set
			{
				this.m_StartAngle = value;
			}
		}

		public ushort topMargin
		{
			get
			{
				return this.m_TopMargin;
			}
			set
			{
				this.m_TopMargin = value;
			}
		}

		public float[] Vals
		{
			get
			{
				return this.m_Vals;
			}
			set
			{
				this.m_Vals = value;
			}
		}

		public pieChartData(float[] Vals, string[] Legends, bool[] Explode)
		{
			this.m_pieChartData(Vals, Legends, Explode);
		}

		public pieChartData(float[] Vals, string[] Legends)
		{
			int length = (int)Vals.Length;
			bool[] flagArray = new bool[length];
			for (int i = 0; i <= length - 1; i++)
			{
				flagArray[i] = false;
			}
			this.m_pieChartData(Vals, Legends, flagArray);
		}

		public pieDrawData getDrawData()
		{
			float mStartAngle;
			Rectangle[] mLeftMargin = new Rectangle[this.m_elements];
			ushort height = (ushort)this.m_chartFont.GetHeight();
			float[] singleArray = new float[this.m_elements];
			float[] singleArray1 = new float[this.m_elements];
			Rectangle[] rectangle = new Rectangle[this.m_elements];
			float single = 0f;
			float single1 = 0f;
			float single2 = 0f;
			float single3 = 0f;
			for (int i = 0; i <= this.m_elements - 1; i++)
			{
				if (this.m_Explode[i])
				{
					mStartAngle = (this.m_StartAngle[i] + this.m_Span[i] / 2f) * 3.14159274f / 180f;
					singleArray[i] = (float)Math.Cos((double)mStartAngle) * (float)this.m_pieDia * (float)this.m_ExploadOffset * 0.5f * 0.01f;
					singleArray1[i] = (float)Math.Sin((double)mStartAngle) * (float)this.m_pieDia * (float)this.m_pieRatio * (float)this.m_ExploadOffset * 0.5f * 0.01f * 0.01f;
					if (singleArray[i] > single)
					{
						single = singleArray[i];
					}
					if (singleArray1[i] > single1)
					{
						single1 = singleArray1[i];
					}
					if (singleArray[i] < single2)
					{
						single2 = singleArray[i];
					}
					if (singleArray1[i] < single3)
					{
						single3 = singleArray1[i];
					}
				}
			}
			for (int j = 0; j <= this.m_elements - 1; j++)
			{
				if (!this.m_Explode[j])
				{
					singleArray[j] = 0f;
					singleArray1[j] = 0f;
				}
				else
				{
					mStartAngle = (this.m_StartAngle[j] + this.m_Span[j] / 2f) * 3.14159274f / 180f;
					singleArray[j] = (float)Math.Cos((double)mStartAngle) * (float)this.m_pieDia * (float)this.m_ExploadOffset * 0.5f * 0.01f;
					singleArray1[j] = (float)Math.Sin((double)mStartAngle) * (float)this.m_pieDia * (float)this.m_pieRatio * (float)this.m_ExploadOffset * 0.5f * 0.01f * 0.01f;
				}
				rectangle[j] = new Rectangle((int)((float)this.m_LeftMargin + singleArray[j] - single2), (int)((float)this.m_TopMargin + singleArray1[j] - single3), (int)this.m_pieDia, (int)((float)(this.m_pieDia * this.m_pieRatio) * 0.01f));
			}
			ushort mPieDia = (ushort)((float)this.m_pieDia * ((float)this.m_pieRatio * 0.01f) + single1 - single3 + (float)this.m_TopMargin + (float)this.m_BottomMargin + (float)(this.m_pieDia * this.m_Pie3dRatio) * 0.01f + 15f);
			if (this.m_elements * height + this.m_TopMargin + this.m_BottomMargin + 15 > mPieDia)
			{
				mPieDia = (ushort)(this.m_elements * height + this.m_TopMargin + this.m_BottomMargin + 15);
			}
			Graphics graphic = Graphics.FromImage(new Bitmap(1, 1));
			ushort num = 0;
			ushort num1 = 0;
			ushort num2 = 0;
			ushort mLeftMargin1 = 200;
			for (int k = 0; k <= this.m_elements - 1; k++)
			{
				SizeF sizeF = graphic.MeasureString(this.m_Vals[k].ToString(), this.m_chartFont);
				ushort width = (ushort)sizeF.Width;
				SizeF sizeF1 = graphic.MeasureString(this.m_Legends[k], this.m_chartFont);
				ushort width1 = (ushort)sizeF1.Width;
				SizeF sizeF2 = graphic.MeasureString(string.Concat(this.m_PercentVal[k].ToString(), "()"), this.m_chartFont);
				ushort width2 = (ushort)sizeF2.Width;
				if (width1 > num)
				{
					num = width1;
				}
				if (width > num1)
				{
					num1 = width;
				}
				if (width2 > num2)
				{
					num2 = width2;
				}
			}
			ushort mPieDia1 = (ushort)((float)this.m_pieDia + single - single2);
			mLeftMargin1 = (ushort)((double)(this.m_LeftMargin + mPieDia1) + (double)height * 2.75 + 12 + (double)num1 + (double)num + (double)num2 + (double)this.m_RightMargin);
			graphic.Dispose();
			for (int l = 0; l <= this.m_elements - 1; l++)
			{
				mLeftMargin[l].X = (int)((double)mPieDia1 + (double)height * 0.75 + (double)this.m_LeftMargin);
				mLeftMargin[l].Y = l * height + height / 4 + 4 + this.m_TopMargin;
				mLeftMargin[l].Width = height + num1 + num + num2;
				mLeftMargin[l].Height = height - 1;
			}
			pieDrawData pieDrawDatum = new pieDrawData()
			{
				legendWidth = num,
				valWidth = num1,
				imageHeight = mPieDia,
				pieRect = rectangle,
				imageWidth = mLeftMargin1,
				piewidth = mPieDia1,
				fontHeight = height,
				PercentWidth = num2,
				LegandMap = mLeftMargin
			};
			return pieDrawDatum;
		}

		public string getImageMap(string mapName)
		{
			pieDrawData drawData = this.getDrawData();
			Point[] x = new Point[this.m_elements];
			Point[] y = new Point[this.m_elements];
			Point[] pointArray = new Point[this.m_elements];
			Point[] x1 = new Point[this.m_elements];
			Point[] y1 = new Point[this.m_elements];
			Rectangle[] rectangleArray = drawData.pieRect;
			string str = "";
			for (int i = 0; i <= this.m_elements - 1; i++)
			{
				x[i].X = rectangleArray[i].X + rectangleArray[i].Width / 2;
				x[i].Y = rectangleArray[i].Y + rectangleArray[i].Height / 2;
				float mStartAngle = (float)((double)(this.m_StartAngle[i] + 1f) * 3.14159265358979 / 180);
				float single = (float)((double)(this.m_StartAngle[i] + this.m_Span[i] - 1f) * 3.14159265358979 / 180);
				y[i].X = (int)((double)x[i].X + Math.Cos((double)(this.m_StartAngle[i] + this.m_Span[i] / 2f) * 3.14159265358979 / 180) * (double)this.m_pieDia * 0.05);
				y[i].Y = (int)((double)x[i].Y + Math.Sin((double)(this.m_StartAngle[i] + this.m_Span[i] / 2f) * 3.14159265358979 / 180) * (double)this.m_pieDia * (double)this.m_pieRatio * 0.05 * 0.00999999977648258);
				pointArray[i].X = (int)((double)x[i].X + Math.Cos((double)mStartAngle) * (double)this.m_pieDia / 2);
				pointArray[i].Y = (int)((double)x[i].Y + Math.Sin((double)mStartAngle) * (double)this.m_pieDia * (double)this.m_pieRatio * 0.00999999977648258 / 2);
				x1[i].X = (int)((double)x[i].X + Math.Cos((double)(this.m_StartAngle[i] + this.m_Span[i] / 2f) * 3.14159265358979 / 180) * (double)this.m_pieDia / 2);
				x1[i].Y = (int)((double)x[i].Y + Math.Sin((double)(this.m_StartAngle[i] + this.m_Span[i] / 2f) * 3.14159265358979 / 180) * (double)this.m_pieRatio * 0.00999999977648258 * (double)this.m_pieDia / 2);
				y1[i].X = (int)((double)x[i].X + Math.Cos((double)single) * (double)this.m_pieDia / 2);
				y1[i].Y = (int)((double)x[i].Y + Math.Sin((double)single) * (double)this.m_pieDia * (double)this.m_pieRatio * 0.00999999977648258 / 2);
			}
			Rectangle[] legandMap = drawData.LegandMap;
			str = string.Concat("<map name='", mapName, "'>\n");
			for (int j = 0; j <= this.m_elements - 1; j++)
			{
				string[] mLinks = new string[22];
				mLinks[0] = str;
				mLinks[1] = "<area  href='";
				mLinks[2] = this.m_Links[j];
				mLinks[3] = "' shape='polygon' coords='";
				int num = y[j].X;
				mLinks[4] = num.ToString();
				mLinks[5] = ",";
				int num1 = y[j].Y;
				mLinks[6] = num1.ToString();
				mLinks[7] = ",";
				int x2 = pointArray[j].X;
				mLinks[8] = x2.ToString();
				mLinks[9] = ",";
				int y2 = pointArray[j].Y;
				mLinks[10] = y2.ToString();
				mLinks[11] = ",";
				int num2 = x1[j].X;
				mLinks[12] = num2.ToString();
				mLinks[13] = ",";
				int y3 = x1[j].Y;
				mLinks[14] = y3.ToString();
				mLinks[15] = ",";
				int x3 = y1[j].X;
				mLinks[16] = x3.ToString();
				mLinks[17] = ",";
				int num3 = y1[j].Y;
				mLinks[18] = num3.ToString();
				mLinks[19] = "' alt='";
				mLinks[20] = this.m_Legends[j];
				mLinks[21] = "'>\n";
				str = string.Concat(mLinks);
				object[] objArray = new object[] { str, "<area  href='", this.m_Links[j], "' shape='rect' coords='", legandMap[j].X, ",", legandMap[j].Y, ",", legandMap[j].X + legandMap[j].Width, ",", legandMap[j].Y + legandMap[j].Height, "' alt='", this.m_Legends[j], "'>\n" };
				str = string.Concat(objArray);
			}
			return str;
		}

		private void m_pieChartData(float[] Vals, string[] Legends, bool[] Explode)
		{
			int length = (int)Vals.Length;
			this.m_PercentVal = new float[length];
			this.m_StartAngle = new float[length];
			this.m_Span = new float[length];
			this.m_Links = new string[length];
			this.m_colorVal = new Color[length];
			this.m_LeftMargin = 10;
			this.m_RightMargin = 10;
			this.m_TopMargin = 10;
			this.m_BottomMargin = 10;
			this.m_ExploadOffset = 25;
			this.m_Pie3dRatio = 8;
			this.m_pieRatio = 80;
			this.m_pieDia = 150;
			this.m_Vals = Vals;
			this.m_Legends = Legends;
			this.m_elements = (ushort)length;
			this.m_Explode = Explode;
			this.m_imageFormat = UtChart.imageFormat.Gif;
			this.m_chartFont = new Font("Verdana", 8f, FontStyle.Bold);
			float vals = 0f;
			for (int i = 0; i <= length - 1; i++)
			{
				vals = vals + Vals[i];
			}
			float mVals = 0f;
			int num = 0;
			colordata colordatum = new colordata();
			for (int j = 0; j <= length - 1; j++)
			{
				this.m_StartAngle[j] = mVals;
				this.m_Span[j] = Vals[j] * 360f / vals;
				this.m_PercentVal[j] = (float)((int)(Vals[j] * 10000f / vals)) / 100f;
				mVals = mVals + this.m_Vals[j] * 360f / vals;
				this.m_colorVal[j] = colordatum.colorval[num];
				num = (num + 1 < (int)colordatum.colorval.Length ? num + 1 : 0);
			}
		}
	}
}