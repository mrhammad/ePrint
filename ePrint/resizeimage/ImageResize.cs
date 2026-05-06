using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;

namespace resizeimage
{
	public class ImageResize : System.Web.UI.Page
	{
		public ImageResize()
		{
		}

		public static Image ConstrainProportions(Image imgPhoto, int Size, ImageResize.Dimensions Dimension)
		{
			int width = imgPhoto.Width;
			int height = imgPhoto.Height;
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			float single = 0f;
			single = (Dimension != ImageResize.Dimensions.Width ? (float)Size / (float)height : (float)Size / (float)width);
			int num4 = (int)((float)width * single);
			int num5 = (int)((float)height * single);
			Bitmap bitmap = new Bitmap(num4, num5, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(imgPhoto, new Rectangle(num2, num3, num4, num5), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
			graphic.Dispose();
			return bitmap;
		}

		public static Image Crop(Image imgPhoto, int Width, int Height, ImageResize.AnchorPosition Anchor)
		{
			int width = imgPhoto.Width;
			int height = imgPhoto.Height;
			int num = 0;
			int num1 = 0;
			int width1 = 0;
			int height1 = 0;
			double num2 = 0;
			double width2 = 0;
			double height2 = 0;
			width2 = (double)Width / (double)width * 2;
			height2 = (double)Height / (double)height * 2.2;
			if (height2 >= width2)
			{
				num2 = height2;
				switch (Anchor)
				{
					case ImageResize.AnchorPosition.Left:
					{
						width1 = 0;
						break;
					}
					case ImageResize.AnchorPosition.Right:
					{
						width1 = (int)((double)Width - (double)width * num2);
						break;
					}
					default:
					{
						width1 = (int)(((double)Width - (double)width * num2) / 2);
						height1 = (int)(((double)Height - (double)height * num2) / 2);
						break;
					}
				}
			}
			else
			{
				num2 = width2;
				switch (Anchor)
				{
					case ImageResize.AnchorPosition.Top:
					{
						height1 = 0;
						break;
					}
					case ImageResize.AnchorPosition.Center:
					{
						height1 = (int)(((double)Height - (double)height * num2) / 2);
						break;
					}
					case ImageResize.AnchorPosition.Bottom:
					{
						height1 = (int)((double)Height - (double)height * num2);
						break;
					}
					default:
					{
						goto case ImageResize.AnchorPosition.Center;
					}
				}
			}
			int num3 = (int)((double)width * num2);
			int num4 = (int)((double)height * num2);
			Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num3, num4), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
			graphic.Dispose();
			return bitmap;
		}

		public static Image CropInc(Image imgPhoto, int Width, int Height, ImageResize.AnchorPosition Anchor)
		{
			int width = imgPhoto.Width;
			int height = imgPhoto.Height;
			int num = 0;
			int num1 = 0;
			int width1 = 0;
			int height1 = 0;
			double num2 = 0;
			double width2 = 0;
			double height2 = 0;
			width2 = (double)Width / (double)width * 1.3;
			height2 = (double)Height / (double)height * 1.5;
			if (height2 >= width2)
			{
				num2 = height2;
				switch (Anchor)
				{
					case ImageResize.AnchorPosition.Left:
					{
						width1 = 0;
						break;
					}
					case ImageResize.AnchorPosition.Right:
					{
						width1 = (int)((double)Width - (double)width * num2);
						break;
					}
					default:
					{
						width1 = (int)(((double)Width - (double)width * num2) / 2);
						height1 = (int)(((double)Height - (double)height * num2) / 2);
						break;
					}
				}
			}
			else
			{
				num2 = width2;
				switch (Anchor)
				{
					case ImageResize.AnchorPosition.Top:
					{
						height1 = 0;
						break;
					}
					case ImageResize.AnchorPosition.Center:
					{
						height1 = (int)(((double)Height - (double)height * num2) / 2);
						break;
					}
					case ImageResize.AnchorPosition.Bottom:
					{
						height1 = (int)((double)Height - (double)height * num2);
						break;
					}
					default:
					{
						goto case ImageResize.AnchorPosition.Center;
					}
				}
			}
			int num3 = (int)((double)width * num2);
			int num4 = (int)((double)height * num2);
			Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num3, num4), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
			graphic.Dispose();
			return bitmap;
		}

		public static Image FixedSize(Image imgPhoto, int Width, int Height)
		{
			int width = imgPhoto.Width;
			int height = imgPhoto.Height;
			int num = 0;
			int num1 = 0;
			int width1 = 0;
			int height1 = 0;
			float single = 0f;
			float single1 = 0f;
			float height2 = 0f;
			single1 = (float)Width / (float)width;
			height2 = (float)Height / (float)height;
			if (height2 >= single1)
			{
				single = single1;
				height1 = (int)(((float)Height - (float)height * single) / 2f);
			}
			else
			{
				single = height2;
				width1 = (int)(((float)Width - (float)width * single) / 2f);
			}
			int num2 = (int)((float)width * single);
			int num3 = (int)((float)height * single);
			Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.Clear(Color.Red);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num2, num3), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
			graphic.Dispose();
			return bitmap;
		}

		[STAThread]
		public static Image ScaleByPercent(Image imgPhoto, int Percent)
		{
			float percent = (float)Percent / 100f;
			int width = imgPhoto.Width;
			int height = imgPhoto.Height;
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = (int)((float)width * percent);
			int num5 = (int)((float)height * percent);
			Bitmap bitmap = new Bitmap(num4, num5, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(imgPhoto, new Rectangle(num2, num3, num4, num5), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
			graphic.Dispose();
			return bitmap;
		}

		public enum AnchorPosition
		{
			Top,
			Center,
			Bottom,
			Left,
			Right
		}

		public enum Dimensions
		{
			Width,
			Height
		}
	}
}