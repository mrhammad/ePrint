using System;
using System.Drawing;

public class DrawAll
{
	public DrawAll()
	{
	}

	public SolidBrush brushGet(string astrColor)
	{
		return new SolidBrush(this.colorGet(astrColor));
	}

	public Bitmap clearBmp(Bitmap aoBmp, Color aColor)
	{
		for (int i = 0; i < aoBmp.Width; i++)
		{
			for (int j = 0; j < aoBmp.Height; j++)
			{
				aoBmp.SetPixel(i, j, aColor);
			}
		}
		return aoBmp;
	}

	public Color colorGet(string astrColor)
	{
		Color black;
		string str = astrColor;
		string str1 = str;
		if (str != null)
		{
			switch (str1)
			{
				case "black":
				{
					black = Color.Black;
					break;
				}
				case "white":
				{
					black = Color.White;
					break;
				}
				case "gray":
				case "grey":
				{
					black = Color.Gray;
					break;
				}
				case "lightgray":
				case "lightgrey":
				{
					black = Color.LightGray;
					break;
				}
				case "darkgray":
				case "darkgrey":
				{
					black = Color.DarkGray;
					break;
				}
				case "red":
				{
					black = Color.Red;
					break;
				}
				case "green":
				{
					black = Color.Green;
					break;
				}
				case "blue":
				{
					black = Color.Blue;
					break;
				}
				case "yellow":
				{
					black = Color.Yellow;
					break;
				}
				case "lightyellow":
				{
					black = Color.LightYellow;
					break;
				}
				case "teal":
				{
					black = Color.Teal;
					break;
				}
				case "cyan":
				{
					black = Color.Cyan;
					break;
				}
				case "brown":
				{
					black = Color.Brown;
					break;
				}
				case "sandybrown":
				{
					black = Color.SandyBrown;
					break;
				}
				case "beige":
				{
					black = Color.Beige;
					break;
				}
				case "tan":
				{
					black = Color.Tan;
					break;
				}
				case "coral":
				{
					black = Color.Coral;
					break;
				}
				case "fuchsia":
				{
					black = Color.Fuchsia;
					break;
				}
				case "violet":
				{
					black = Color.Violet;
					break;
				}
				case "pink":
				{
					black = Color.Pink;
					break;
				}
				case "salmon":
				{
					black = Color.Salmon;
					break;
				}
				case "lightsalmon":
				{
					black = Color.LightSalmon;
					break;
				}
				case "magenta":
				{
					black = Color.Magenta;
					break;
				}
				case "maroon":
				{
					black = Color.Maroon;
					break;
				}
				case "plum":
				{
					black = Color.Plum;
					break;
				}
				case "powderblue":
				{
					black = Color.PowderBlue;
					break;
				}
				case "royalblue":
				{
					black = Color.RoyalBlue;
					break;
				}
				case "seashell":
				{
					black = Color.SeaShell;
					break;
				}
				case "silver":
				{
					black = Color.Silver;
					break;
				}
				case "snow":
				{
					black = Color.Snow;
					break;
				}
				case "thistle":
				{
					black = Color.Thistle;
					break;
				}
				case "whitesmoke":
				{
					black = Color.WhiteSmoke;
					break;
				}
				case "yellowgreen":
				{
					black = Color.YellowGreen;
					break;
				}
				case "azure":
				{
					black = Color.Azure;
					break;
				}
				case "dodgerblue":
				{
					black = Color.DodgerBlue;
					break;
				}
				case "skyblue":
				{
					black = Color.SkyBlue;
					break;
				}
				case "indigo":
				{
					black = Color.Indigo;
					break;
				}
				case "navy":
				{
					black = Color.Navy;
					break;
				}
				case "steelblue":
				{
					black = Color.SteelBlue;
					break;
				}
				case "lightsteelblue":
				{
					black = Color.LightSteelBlue;
					break;
				}
				case "blueviolet":
				{
					black = Color.BlueViolet;
					break;
				}
				case "purple":
				{
					black = Color.Purple;
					break;
				}
				default:
				{
					black = Color.LightGray;
					return black;
				}
			}
		}
		else
		{
			black = Color.LightGray;
			return black;
		}
		return black;
	}

	public string colorName(int ai)
	{
		string[] strArrays = new string[] { "black", "white", "gray", "grey", "lightgray", "lightgrey", "darkgray", "red", "green", "blue", "yellow", "teal", "cyan", "purple", "brown", "sandybrown", "beige", "tan", "darkgrey", "coral", "plum", "pink", "salmon", "lightsteelblue", "magenta", "maroon", "dodgerblue", "skyblue", "indigo", "navy", "steelblue", "lightsalmon", "blueviolet" };
		return strArrays[ai];
	}

	public Bitmap drawBar(Bitmap aoBmp, int aLeft, int aWidth, int aHeight, Color aColor)
	{
		if (aLeft + aWidth < aoBmp.Width && aHeight < aoBmp.Height)
		{
			for (int i = aLeft; i < aLeft + aWidth; i++)
			{
				for (int j = aHeight; j < aoBmp.Height; j++)
				{
					aoBmp.SetPixel(i, j, aColor);
				}
			}
		}
		return aoBmp;
	}

	public Bitmap drawBarChart(Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, string astrXaxis, string astrYaxis, int[] aintV, string[] astrTitles)
	{
		int i;
		float[] singleArray = new float[(int)aintV.Length];
		Graphics graphic = Graphics.FromImage(aoBmp);
		Font font = new Font("Small Fonts", 7f);
		int num = (astrCaption == "" ? 4 : 20);
		graphic.FillRectangle(this.brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);
		graphic.DrawLine(this.penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left + aintWidth, aoRect.Top + aintHeight - aoRect.Height));
		graphic.DrawLine(this.penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left, aoRect.Top));
		this.writeHeaders(aoRect, graphic, astrXaxis, astrYaxis, astrCaption, aintWidth, aintHeight);
		int length = (int)aintV.Length;
		int num1 = 10;
		int num2 = aintWidth / length - num1;
		int num3 = aintHeight / length;
		float single = 1f;
		float single1 = 0f;
		for (i = 0; i < length; i++)
		{
			single = ((float)aintV[i] > single ? (float)aintV[i] : single);
			single1 = single1 + (float)aintV[i];
		}
		for (i = 0; i < length; i++)
		{
			singleArray[i] = (float)aintV[i] / single * (float)(aintHeight - 10);
		}
		for (i = 0; i < length; i++)
		{
			graphic.FillRectangle(this.brushGet(this.colorName(i + 11)), (float)(aoRect.Left + num1 + (num1 + num2) * i), (float)(aoRect.Top - num + aintHeight) - singleArray[i], (float)num2, singleArray[i]);
		}
		this.writeLegend(aoRect, graphic, astrCaption, astrTitles, aintV, aintWidth, single1);
		return aoBmp;
	}

	public Bitmap drawEllipse(Bitmap aoBmp, int aWidth, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
	{
		Graphics graphic = Graphics.FromImage(aoBmp);
		Pen pen = new Pen(aColor, (float)aWidth);
		Rectangle rectangle = new Rectangle(aLeft, aTop, aRight, aBottom);
		graphic.DrawEllipse(pen, rectangle);
		return aoBmp;
	}

	public Bitmap drawGraph(Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, string astrXaxis, string astrYaxis, int[] aintV, string astrType)
	{
		int i;
		int left;
		int top;
		Graphics graphic = Graphics.FromImage(aoBmp);
		Font font = new Font("Small Fonts", 7f);
		graphic.FillRectangle(this.brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);
		graphic.DrawLine(this.penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left + aintWidth, aoRect.Top + aintHeight - aoRect.Height));
		graphic.DrawLine(this.penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left, aoRect.Top));
		this.writeHeaders(aoRect, graphic, astrXaxis, astrYaxis, astrCaption, aintWidth, aintHeight);
		float single = 0f;
		float single1 = 0f;
		int length = (int)aintV.Length;
		for (i = 0; i < length - 1; i = i + 2)
		{
			single = ((float)aintV[i] > single ? (float)aintV[i] : single);
			single1 = ((float)aintV[i + 1] > single1 ? (float)aintV[i + 1] : single1);
		}
		if (astrType == "graph" || astrType == "bullgraph" || astrType == "circlegraph")
		{
			for (i = 0; i < length - 2; i = i + 2)
			{
				top = (int)((float)(aoRect.Top + aintHeight - aoRect.Height) - (float)(aintHeight - 50) * ((float)aintV[i + 1] / single1));
				int num = (int)((float)(aoRect.Top + aintHeight - aoRect.Height) - (float)(aintHeight - 50) * ((float)aintV[i + 3] / single1));
				left = (int)((float)aoRect.Left + (float)(aintWidth - aoRect.Left - 10) * ((float)aintV[i] / single));
				int left1 = (int)((float)aoRect.Left + (float)(aintWidth - aoRect.Left - 10) * ((float)aintV[i + 2] / single));
				graphic.DrawLine(this.penGet("black", 1), new Point(left, top), new Point(left1, num));
			}
		}
		if (astrType == "bullgraph" || astrType == "circlegraph" || astrType == "points" || astrType == "squares" || astrType == "circles" || astrType == "dots" || astrType == "bullseyes")
		{
			for (i = 0; i < length - 1; i = i + 2)
			{
				top = (int)((float)(aoRect.Top + aintHeight - aoRect.Height) - (float)(aintHeight - 50) * ((float)aintV[i + 1] / single1));
				left = (int)((float)aoRect.Left + (float)(aintWidth - aoRect.Left - 10) * ((float)aintV[i] / single));
				if (astrType == "points" || astrType == "squares")
				{
					graphic.DrawRectangle(this.penGet("blue", 2), left - 1, top - 1, 2, 2);
				}
				else if (astrType == "dots")
				{
					graphic.DrawRectangle(this.penGet("black", 1), left, top, 1, 1);
				}
				else if (astrType == "circles" || astrType == "circlegraph")
				{
					graphic.DrawEllipse(this.penGet("blue", 1), left - 2, top - 2, 4, 4);
				}
				else if (astrType == "bullseyes" || astrType == "bullgraph")
				{
					graphic.DrawRectangle(this.penGet("black", 1), left - 4, top - 4, 8, 8);
					graphic.DrawEllipse(this.penGet("black", 1), left - 3, top - 3, 6, 6);
					graphic.DrawLine(this.penGet("black", 1), new Point(left - 4, top - 4), new Point(left + 4, top + 4));
					graphic.DrawLine(this.penGet("black", 1), new Point(left - 4, top + 4), new Point(left + 4, top - 4));
				}
			}
		}
		return aoBmp;
	}

	public Bitmap drawLine(Bitmap aoBmp, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
	{
		int i;
		int j;
		decimal num;
		if (aRight < aoBmp.Width && aBottom < aoBmp.Height)
		{
			int num1 = aRight - aLeft;
			int num2 = aBottom - aTop;
			if (num1 * num2 > 0)
			{
				decimal num3 = new decimal(0);
				if (num1 < num2)
				{
					num = num2 / num1;
					for (i = 10; i < 100; i++)
					{
						j = aTop + (int)num3;
						aoBmp.SetPixel(i, j, aColor);
						num3 = num3 + num;
					}
				}
				else
				{
					num = num1 / num2;
					for (j = aTop; j < aBottom; j++)
					{
						i = aLeft + (int)num3;
						aoBmp.SetPixel(i, j, aColor);
						num3 = num3 + num;
					}
				}
			}
		}
		return aoBmp;
	}

	public Bitmap drawPieChart(Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, int[] aintV, string[] astrTitles)
	{
		int i;
		Graphics graphic = Graphics.FromImage(aoBmp);
		Font font = new Font("Small Fonts", 7f);
		graphic.FillRectangle(this.brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);
		Rectangle rectangle = new Rectangle(10, 10, aintWidth - 20, aintHeight - 20);
		int length = (int)aintV.Length;
		float single = 0f;
		for (i = 0; i < length; i++)
		{
			single = single + (float)aintV[i];
		}
		float single1 = 0f;
		for (i = 0; i < length; i++)
		{
			float single2 = 360f * (float)aintV[i] / single;
			graphic.FillPie(this.brushGet(this.colorName(i + 11)), rectangle, single1, single2);
			single1 = single1 + single2;
		}
		this.writeLegend(aoRect, graphic, astrCaption, astrTitles, aintV, aintWidth, single);
		return aoBmp;
	}

	public Bitmap drawRectangle(Bitmap aoBmp, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
	{
		for (int i = aLeft; i < aRight; i++)
		{
			aoBmp.SetPixel(i, aTop, aColor);
			aoBmp.SetPixel(i, aBottom, aColor);
		}
		for (int j = aTop; j < aBottom; j++)
		{
			aoBmp.SetPixel(aLeft, j, aColor);
			aoBmp.SetPixel(aRight, j, aColor);
		}
		return aoBmp;
	}

	public string getPercent(int aintV, float aflTotal)
	{
		double num = (double)(100 * aintV) / (double)aflTotal;
		string str = Convert.ToString(num);
		if (str.IndexOf(".") == -1)
		{
			str = string.Concat(str, ".");
		}
		str = string.Concat(str, "000");
		str = str.Substring(0, str.IndexOf(".") + 3);
		return str;
	}

	public Pen penGet(string astrColor, int aintWidth)
	{
		return new Pen(this.colorGet(astrColor), (float)aintWidth);
	}

	public bool writeHeaders(Rectangle aoRect, Graphics oGraphic, string astrXaxis, string astrYaxis, string astrCaption, int aintWidth, int aintHeight)
	{
		Font font = new Font("Arial", 8f);
		Font font1 = new Font("Arial", 11f, FontStyle.Bold);
		astrXaxis = astrXaxis.Replace("%20", " ");
		if (astrXaxis != "")
		{
			oGraphic.DrawString(astrXaxis, font, this.brushGet("black"), new PointF((float)((aintWidth - 4 * astrXaxis.Length) / 2), (float)(aintHeight + aoRect.Bottom - 20)));
		}
		astrYaxis = astrYaxis.Replace("%20", " ");
		if (astrYaxis != "")
		{
			oGraphic.DrawString(astrYaxis, font, this.brushGet("black"), new PointF(4f, (float)((aintHeight + aoRect.Top) / 2)));
		}
		astrCaption = astrCaption.Replace("%20", " ");
		if (astrCaption != "")
		{
			oGraphic.DrawString(astrCaption, font1, this.brushGet("black"), new PointF((float)((aintWidth - aoRect.Left - 3 * astrCaption.Length) / 2), 5f));
		}
		return true;
	}

	public bool writeLegend(Rectangle aoRect, Graphics oGraphic, string astrCaption, string[] astrTitles, int[] aintV, int aintWidth, float flTotal)
	{
		int num = 8;
		int num1 = (astrCaption == "" ? 4 : 20);
		Font font = new Font("Small Fonts", 7f);
		Font font1 = new Font("Small Fonts", 7f, FontStyle.Bold);
		for (int i = 0; i < (int)aintV.Length; i++)
		{
			string percent = this.getPercent(aintV[i], flTotal);
			int num2 = (astrCaption == "" ? num1 + 10 : aoRect.Top);
			oGraphic.FillRectangle(this.brushGet(this.colorName(i + 11)), aoRect.Left + 10 + aintWidth, num2 + i * (num + 2), 25, num);
			oGraphic.DrawString(string.Concat(percent, "% "), font, this.brushGet("black"), new PointF((float)(aoRect.Left + 38 + aintWidth), (float)(num2 - 2 + i * (num + 2))));
			if (i < (int)astrTitles.Length)
			{
				oGraphic.DrawString(astrTitles[i], font, this.brushGet("black"), new PointF((float)(aoRect.Left + 72 + aintWidth), (float)(num2 - 2 + i * (num + 2))));
			}
		}
		num1 = (astrCaption == "" ? -14 : 0);
		if ((int)astrTitles.Length > 0)
		{
			oGraphic.DrawString("Legend", font1, this.brushGet("black"), new PointF((float)(aoRect.Left + 8 + aintWidth), (float)(aoRect.Top - num1 - 14)));
		}
		return true;
	}
}