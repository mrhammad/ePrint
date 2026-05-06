using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TemplateEditorFrontEnd
{
	public class createThumbnail
	{
		public createThumbnail()
		{
		}

		public static string CreateProportionalImage(Image imgPhoto, string path, string savepath, string originalFilename, int Width, int Height, double originalWidth, double originalHeight, bool OnlyResizeIfWider, double zoomper, bool Thumbnail100x100)
		{
			bool flag = false;
			int height = 0;
			int width = 0;
			if (zoomper > 0)
			{
				int num = Convert.ToInt32(zoomper / 100);
				if (num == 1 && !Thumbnail100x100)
				{
					num = 2;
				}
				if (num == 0 && !Thumbnail100x100)
				{
					num = 1;
				}
				Image image = Image.FromFile(string.Concat(path, originalFilename));
				image.RotateFlip(RotateFlipType.Rotate180FlipNone);
				image.RotateFlip(RotateFlipType.Rotate180FlipNone);
				if (originalWidth <= (double)Width && originalHeight <= (double)Height)
				{
					num = 1;
				}
				if (OnlyResizeIfWider && image.Width <= Width)
				{
					Width = image.Width;
				}
				height = image.Height * Width / image.Width;
				width = 0;
				if (height > Height)
				{
					Width = image.Width * Height / image.Height;
					height = Height;
				}
				width = Width;
				Height = height * num;
				Width = Width * num;
				int width1 = imgPhoto.Width;
				int height1 = imgPhoto.Height;
				int num1 = 0;
				int num2 = 0;
				int width2 = 0;
				int height2 = 0;
				float single = 0f;
				float single1 = 0f;
				float single2 = 0f;
				single1 = (float)Width / (float)width1;
				single2 = (float)Height / (float)height1;
				if (single2 >= single1)
				{
					single = single1;
					height2 = (int)(((float)Height - (float)height1 * single) / 2f);
				}
				else
				{
					single = single2;
					width2 = (int)(((float)Width - (float)width1 * single) / 2f);
				}
				int width3 = Width;
				int height3 = Height;
				Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
				bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
				bitmap.MakeTransparent();
				Graphics graphic = Graphics.FromImage(bitmap);
				graphic.Clear(Color.Transparent);
				graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphic.SmoothingMode = SmoothingMode.AntiAlias;
				graphic.DrawImage(imgPhoto, new Rectangle(width2, height2, width3, height3), new Rectangle(num1, num2, width1, height1), GraphicsUnit.Pixel);
				int num3 = 0;
				while (File.Exists(string.Concat(savepath, originalFilename)))
				{
					num3++;
					string[] strArrays = originalFilename.Split(new char[] { '.' });
					string str = strArrays[(int)strArrays.Length - 1].ToString();
					originalFilename = originalFilename.Substring(0, originalFilename.Length - (str.Length + 1));
					string[] strArrays1 = originalFilename.Split(new char[] { '-' });
					string str1 = "";
					if ((int)strArrays1.Length <= 1)
					{
						object[] objArray = new object[] { originalFilename, "-", num3, ".", str };
						originalFilename = string.Concat(objArray);
					}
					else
					{
						string str2 = strArrays1[(int)strArrays1.Length - 1];
						str1 = originalFilename.Substring(0, originalFilename.Length - (str2.Length + 1));
						object[] objArray1 = new object[] { str1, "-", num3, ".", str };
						originalFilename = string.Concat(objArray1);
					}
				}
				if (!Thumbnail100x100)
				{
					bitmap.Save(string.Concat(savepath, originalFilename));
				}
				else
				{
					bitmap.Save(string.Concat(savepath, "t_", originalFilename));
				}
				graphic.Dispose();
				bitmap.Dispose();
			}
			flag = true;
			object[] objArray2 = new object[] { originalFilename, "~", height, "~", width, "~", flag };
			return string.Concat(objArray2);
		}

		public static string CreateProportionalImageIsCropFromTop(Image imgPhoto, string path, string savepath, string originalFilename, int Width, int Height, double imageWidth, double imageHeight, bool OnlyResizeIfWider, double zoomper, bool _iscropfromtop)
		{
			bool flag = false;
			int num = Convert.ToInt32(zoomper / 100);
			if (num == 1)
			{
				num = 2;
			}
			if (num == 0)
			{
				num = 1;
			}
			int height = 0;
			int width = 0;
			string str = originalFilename;
			int width1 = Width;
			int height1 = Height;
			if (_iscropfromtop)
			{
				width = Width;
				if (imageWidth <= (double)width1 && imageHeight <= (double)height1)
				{
					num = 1;
				}
				Height = Height * num;
				Width = Width * num;
				imgPhoto = createThumbnail.ResizeByWidth(imgPhoto, Width);
				int num1 = 0;
				while (File.Exists(string.Concat(savepath, originalFilename)))
				{
					num1++;
					string[] strArrays = originalFilename.Split(new char[] { '.' });
					string str1 = strArrays[(int)strArrays.Length - 1].ToString();
					originalFilename = originalFilename.Substring(0, originalFilename.Length - (str1.Length + 1));
					string[] strArrays1 = originalFilename.Split(new char[] { '-' });
					string str2 = "";
					if ((int)strArrays1.Length <= 1)
					{
						object[] objArray = new object[] { originalFilename, "-", num1, ".", str1 };
						originalFilename = string.Concat(objArray);
					}
					else
					{
						string str3 = strArrays1[(int)strArrays1.Length - 1];
						str2 = originalFilename.Substring(0, originalFilename.Length - (str3.Length + 1));
						object[] objArray1 = new object[] { str2, "-", num1, ".", str1 };
						originalFilename = string.Concat(objArray1);
					}
				}
				imgPhoto.Save(string.Concat(savepath, originalFilename));
				height = imgPhoto.Height;
				if (height <= Height)
				{
					height = (width1 < imgPhoto.Width ? imgPhoto.Height * width1 / imgPhoto.Width : imgPhoto.Height);
				}
				else
				{
					int num2 = 0;
					int height2 = imgPhoto.Height - Height;
					double num3 = Convert.ToDouble(height2) / Convert.ToDouble(imgPhoto.Height) * 100;
					string str4 = createThumbnail.cropImage(imgPhoto, num2, height2, imgPhoto.Width, Height, originalFilename, path, savepath, width1, height1);
					string[] strArrays2 = str4.Split(new char[] { '~' });
					height = Convert.ToInt32(strArrays2[1]);
					Image image = Image.FromFile(string.Concat(path, str));
					int height3 = image.Height;
					double height4 = num3 / 100 * (double)image.Height;
					string str5 = createThumbnail.cropImage(image, num2, Convert.ToInt32(height4), image.Width, image.Height - Convert.ToInt32(height4), str, path, savepath, width1, height1);
					flag = true;
					char[] chrArray = new char[] { '~' };
					originalFilename = str5.Split(chrArray)[0];
				}
				imgPhoto.Dispose();
			}
			object[] objArray2 = new object[] { originalFilename, "~", height, "~", width, "~", flag };
			return string.Concat(objArray2);
		}

		public static Image Crop(Image image, int x, int y, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
			bitmap.MakeTransparent();
			bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			using (Graphics graphic = Graphics.FromImage(bitmap))
			{
				graphic.Clear(Color.Transparent);
				graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphic.SmoothingMode = SmoothingMode.AntiAlias;
				graphic.CompositingQuality = CompositingQuality.HighQuality;
				graphic.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
			}
			return bitmap;
		}

		private static string cropImage(Image img, int cropX, int cropY, int cropWidth, int cropHeight, string imgfilename, string path, string savepath, int ctrlwidth, int ctrlheight)
		{
			Rectangle rectangle = new Rectangle(cropX, cropY, cropWidth, cropHeight);
			Bitmap bitmap = new Bitmap(img, img.Width, img.Height);
			Bitmap bitmap1 = new Bitmap(cropWidth, cropHeight);
			Graphics graphic = Graphics.FromImage(bitmap1);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphic.CompositingQuality = CompositingQuality.HighQuality;
			graphic.SmoothingMode = SmoothingMode.HighQuality;
			graphic.DrawImage(bitmap, 0, 0, rectangle, GraphicsUnit.Pixel);
			int num = 0;
			while (File.Exists(string.Concat(savepath, imgfilename)))
			{
				num++;
				string[] strArrays = imgfilename.Split(new char[] { '.' });
				string str = strArrays[(int)strArrays.Length - 1].ToString();
				imgfilename = imgfilename.Substring(0, imgfilename.Length - (str.Length + 1));
				string[] strArrays1 = imgfilename.Split(new char[] { '-' });
				string str1 = "";
				if ((int)strArrays1.Length <= 1)
				{
					object[] objArray = new object[] { imgfilename, "-", num, ".", str };
					imgfilename = string.Concat(objArray);
				}
				else
				{
					string str2 = strArrays1[(int)strArrays1.Length - 1];
					str1 = imgfilename.Substring(0, imgfilename.Length - (str2.Length + 1));
					object[] objArray1 = new object[] { str1, "-", num, ".", str };
					imgfilename = string.Concat(objArray1);
				}
			}
			bitmap1.Save(string.Concat(savepath, imgfilename));
			double height = 0;
			height = (double)(bitmap1.Height * ctrlwidth / bitmap1.Width);
			graphic.Dispose();
			bitmap1.Dispose();
			bitmap.Dispose();
			return string.Concat(imgfilename, "~", height);
		}

		public static Image Resize(Image image, int scaledWidth, int scaledHeight)
		{
			int width = image.Width;
			int height = image.Height;
			float single = 0f;
			float single1 = 0f;
			float single2 = 0f;
			single1 = (float)scaledWidth / (float)width;
			single2 = (float)scaledHeight / (float)height;
			single = (single2 >= single1 ? single1 : single2);
			int num = (int)((float)width * single);
			int num1 = (int)((float)height * single);
			Bitmap bitmap = new Bitmap(num, num1);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.DrawImage(image, 0, 0, num, num1);
			graphic.Dispose();
			return bitmap;
		}

		public static Image ResizeByWidth(Image Img, int NewWidth)
		{
			float width = (float)Img.Width / (float)NewWidth;
			Bitmap bitmap = new Bitmap(NewWidth, (int)((float)Img.Height / width));
			bitmap.MakeTransparent();
			bitmap.SetResolution(Img.HorizontalResolution, Img.VerticalResolution);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.Clear(Color.Transparent);
			graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			graphic.DrawImage(Img, 0, 0, bitmap.Width, bitmap.Height);
			graphic.Dispose();
			return bitmap;
		}

		public static Image RotateImageByAngle(Image oldBitmap, float angle)
		{
			Bitmap bitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.TranslateTransform((float)oldBitmap.Width / 2f, (float)oldBitmap.Height / 2f);
			graphic.RotateTransform(angle);
			graphic.TranslateTransform(-(float)oldBitmap.Width / 2f, -(float)oldBitmap.Height / 2f);
			graphic.DrawImage(oldBitmap, new Point(0, 0));
			return bitmap;
		}
	}
}