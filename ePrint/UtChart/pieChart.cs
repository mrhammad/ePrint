using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace UtChart
{
	public class pieChart
	{
		private ImageFormat[] imgFormat = new ImageFormat[3];

		public pieChart()
		{
			this.imgFormat[0] = ImageFormat.Gif;
			this.imgFormat[1] = ImageFormat.Jpeg;
			this.imgFormat[2] = ImageFormat.Bmp;
		}

		public Stream getPieChart(ref pieChartData mychartdata)
		{
			Stream memoryStream = new MemoryStream();
			Brush solidBrush = new SolidBrush(Color.Black);
			Brush brush = new SolidBrush(Color.FromArgb(204, 204, 204));
			Pen pen = new Pen(Color.FromArgb(204, 204, 204), 1f);
			ushort num = mychartdata.pieDia;
			byte num1 = mychartdata.pieRatio;
			Font font = mychartdata.chartFont;
			pieDrawData drawData = mychartdata.getDrawData();
			ushort num2 = drawData.imageHeight;
			ushort num3 = drawData.imageWidth;
			ushort num4 = drawData.piewidth;
			ushort num5 = drawData.valWidth;
			ushort num6 = drawData.legendWidth;
			ushort percentWidth = drawData.PercentWidth;
			Bitmap bitmap = new Bitmap((int)num3, (int)num2, PixelFormat.Format24bppRgb);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.Clear(Color.White);
			Rectangle rectangle = new Rectangle(0, 0, 0, 0)
			{
				X = (int)((double)(mychartdata.leftMargin + num4) + (double)drawData.fontHeight * 0.5),
				Y = mychartdata.topMargin,
				Width = (int)((double)drawData.fontHeight * 2.2 + (double)num5 + (double)num6 + (double)percentWidth + 10),
				Height = mychartdata.elements * drawData.fontHeight + 7
			};
			graphic.FillRectangle(brush, new Rectangle(rectangle.X + 5, rectangle.Y + 5, rectangle.Width, rectangle.Height));
			graphic.FillRectangle(new SolidBrush(Color.White), rectangle);
			graphic.DrawRectangle(pen, rectangle);
			for (int i = (int)((float)(num * mychartdata.pie3dRatio) * 0.01f); i >= 0; i--)
			{
				for (int j = 0; j <= mychartdata.elements - 1; j++)
				{
					Rectangle rectangle1 = new Rectangle(drawData.pieRect[j].X, drawData.pieRect[j].Y + i, drawData.pieRect[j].Width, drawData.pieRect[j].Height);
					graphic.FillPie(new HatchBrush(HatchStyle.Percent50, mychartdata.colorVal[j]), rectangle1, mychartdata.startAngle[j], mychartdata.span[j]);
				}
			}
			for (int k = 0; k <= mychartdata.elements - 1; k++)
			{
				graphic.FillPie(new SolidBrush(mychartdata.colorVal[k]), drawData.pieRect[k], mychartdata.startAngle[k], mychartdata.span[k]);
				graphic.DrawString(string.Concat("(", mychartdata.percentVal[k], "%)"), font, new SolidBrush(Color.Blue), (float)((int)((double)num4 + (double)drawData.fontHeight * 2 + (double)mychartdata.leftMargin + (double)num5 + (double)num6)), (float)(k * drawData.fontHeight + 4 + mychartdata.topMargin));
				graphic.DrawString(mychartdata.Vals[k].ToString(), font, solidBrush, (float)((int)((double)num4 + (double)drawData.fontHeight * 1.5 + (double)mychartdata.leftMargin)), (float)(k * drawData.fontHeight + 4 + mychartdata.topMargin));
				graphic.DrawString(mychartdata.Legends[k], font, solidBrush, (float)((int)((double)num4 + (double)drawData.fontHeight * 1.75 + (double)num5 + (double)mychartdata.leftMargin)), (float)(k * drawData.fontHeight + 4 + mychartdata.topMargin));
				graphic.FillRectangle(new SolidBrush(mychartdata.colorVal[k]), new Rectangle((int)((double)num4 + (double)drawData.fontHeight * 0.75 + (double)mychartdata.leftMargin), k * drawData.fontHeight + drawData.fontHeight / 5 + 4 + mychartdata.topMargin, (int)((double)drawData.fontHeight * 0.7), (int)((double)drawData.fontHeight * 0.7)));
				graphic.DrawRectangle(new Pen(Color.Black), new Rectangle((int)((double)num4 + (double)drawData.fontHeight * 0.75 + (double)mychartdata.leftMargin), k * drawData.fontHeight + drawData.fontHeight / 5 + 4 + mychartdata.topMargin, (int)((double)drawData.fontHeight * 0.7), (int)((double)drawData.fontHeight * 0.7)));
			}
			bitmap.Save(memoryStream, this.imgFormat[(int)mychartdata.imageFormat]);
			return memoryStream;
		}
	}
}