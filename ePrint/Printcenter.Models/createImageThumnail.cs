using nmsCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

public class createImageThumnail : System.Web.UI.Page
{
	public createImageThumnail()
	{
	}

	public static Image ConstrainProportions(Image imgPhoto, int Size, createImageThumnail.Dimensions Dimension)
	{
		int width = imgPhoto.Width;
		int height = imgPhoto.Height;
		int num = 0;
		int num1 = 0;
		int num2 = 0;
		int num3 = 0;
		float single = 0f;
		single = (Dimension != createImageThumnail.Dimensions.Width ? (float)Size / (float)height : (float)Size / (float)width);
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

	public static byte[] ConvertImageToByteArray(Image imageToConvert)
	{
		byte[] array;
		try
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				imageToConvert.Save(memoryStream, ImageFormat.Jpeg);
				array = memoryStream.ToArray();
			}
		}
		catch (Exception exception)
		{
			throw;
		}
		return array;
	}

	public void corpImages(string oldImage, string NewImage, int width, int height)
	{
		Image image = Image.FromFile(oldImage);
		Image image1 = Image.FromFile(oldImage);
		Image image2 = null;
		image2 = createImageThumnail.Crop(image1, width, height, createImageThumnail.AnchorPosition.Center);
		image2.Save(NewImage, ImageFormat.Jpeg);
		image2.Dispose();
		image.Dispose();
		image1.Dispose();
	}

	public MemoryStream corpImages(int width, int height, Image imgSave)
	{
		byte[] byteArray = createImageThumnail.ConvertImageToByteArray(imgSave);
		Image image = Image.FromStream(new MemoryStream(byteArray));
		Image image1 = null;
		image1 = this.ResizeImageNew(image, width, height, true);
		MemoryStream memoryStream = new MemoryStream();
		image1.Save(memoryStream, ImageFormat.Jpeg);
		image1.Dispose();
		image.Dispose();
		return memoryStream;
	}

	public void corpImagesJavascript(string oldImage, string NewImage, int destX, int destY, int destWidth, int destHight)
	{
		Image.FromFile(oldImage);
		Image image = Image.FromFile(oldImage);
		Image image1 = null;
		NewImage = NewImage.Replace("MyUploads", "tempUpload");
		image1 = createImageThumnail.CropJavascript(image, destX, destY, destWidth, destHight);
		if (!File.Exists(NewImage))
		{
			image1.Save(NewImage, ImageFormat.Jpeg);
		}
		else
		{
			File.Delete(NewImage);
			image1.Save(NewImage, ImageFormat.Jpeg);
		}
		image1.Dispose();
	}

	public static Image Crop(Image imgPhoto, int Width, int Height, createImageThumnail.AnchorPosition Anchor)
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
			single = height2;
			switch (Anchor)
			{
				case createImageThumnail.AnchorPosition.Left:
				{
					width1 = 0;
					break;
				}
				case createImageThumnail.AnchorPosition.Right:
				{
					width1 = (int)((float)Width - (float)width * single);
					break;
				}
				default:
				{
					width1 = (int)(((float)Width - (float)width * single) / 2f);
					break;
				}
			}
		}
		else
		{
			single = single1;
			switch (Anchor)
			{
				case createImageThumnail.AnchorPosition.Top:
				{
					height1 = 0;
					break;
				}
				case createImageThumnail.AnchorPosition.Center:
				{
					height1 = (int)(((float)Height - (float)height * single) / 2f);
					break;
				}
				case createImageThumnail.AnchorPosition.Bottom:
				{
					height1 = (int)((float)Height - (float)height * single);
					break;
				}
				default:
				{
					goto case createImageThumnail.AnchorPosition.Center;
				}
			}
		}
		int num2 = (int)((float)width * single);
		int num3 = (int)((float)height * single);
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
		bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
		Graphics graphic = Graphics.FromImage(bitmap);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num2, num3), new Rectangle(num, num1, width, height), GraphicsUnit.Pixel);
		graphic.Dispose();
		return bitmap;
	}

	public static Image CropJavascript(Image imgPhoto, int destX, int destY, int destWidth, int destHeight)
	{
		int width = imgPhoto.Width;
		int height = imgPhoto.Height;
		Bitmap bitmap = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
		bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
		Graphics graphic = Graphics.FromImage(bitmap);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.DrawImage(imgPhoto, 0, 0, new Rectangle(destX, destY, destWidth, destHeight), GraphicsUnit.Pixel);
		graphic.Dispose();
		return bitmap;
	}

	public static Image FixedSize(string OriginalFile, Image imgPhoto, int Width, int Height, bool OnlyResizeIfWider)
	{
		Image image = Image.FromFile(OriginalFile);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		if (OnlyResizeIfWider && image.Width <= Width)
		{
			Width = image.Width;
		}
		int height = image.Height * Width / image.Width;
		if (height > Height)
		{
			Width = image.Width * Height / image.Height;
			height = Height;
		}
		Height = height;
		int width = imgPhoto.Width;
		int num = imgPhoto.Height;
		int num1 = 0;
		int num2 = 0;
		int width1 = 0;
		int height1 = 0;
		float single = 0f;
		float single1 = 0f;
		float height2 = 0f;
		single1 = (float)Width / (float)width;
		height2 = (float)Height / (float)num;
		if (height2 >= single1)
		{
			single = single1;
			height1 = (int)(((float)Height - (float)num * single) / 2f);
		}
		else
		{
			single = height2;
			width1 = (int)(((float)Width - (float)width * single) / 2f);
		}
		int num3 = (int)((float)width * single);
		int num4 = (int)((float)num * single);
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
		bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
		Graphics graphic = Graphics.FromImage(bitmap);
		graphic.Clear(Color.White);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num3, num4), new Rectangle(num1, num2, width, num), GraphicsUnit.Pixel);
		graphic.Dispose();
		return bitmap;
	}

	public static Image FixedSize1(string OriginalFile, Image imgPhoto, int Width, int Height, bool OnlyResizeIfWider)
	{
		Image image = Image.FromFile(OriginalFile);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
        int width = imgPhoto.Width;
        int num = imgPhoto.Height;
        int num1 = 0;
        int num2 = 0;
        int width1 = 0;
        int height1 = 0;
        float single = 0f;
        float single1 = 0f;
        float height2 = 0f;
        single1 = (float)Width / (float)width;
        height2 = (float)Height / (float)num;
        if (height2 >= single1)
        {
            single = single1;
            height1 = (int)(((float)Height - (float)num * single) / 2f);
        }
        else
        {
            single = height2;
            width1 = (int)(((float)Width - (float)width * single) / 2f);
        }
        int num3 = (int)((float)width * single);
        int num4 = (int)((float)num * single);
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
		bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
		Graphics graphic = Graphics.FromImage(bitmap);
		graphic.Clear(Color.White);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num3, num4), new Rectangle(num1, num2, width, num), GraphicsUnit.Pixel);
		graphic.Dispose();
		return bitmap;

	}

	public static Image FixedSize(string OriginalFile, Image imgPhoto, int Width, int Height, bool OnlyResizeIfWider, string NewFile)
	{
		Image image = Image.FromFile(OriginalFile);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		if (OnlyResizeIfWider && image.Width <= Width)
		{
			Width = image.Width;
		}
		int height = image.Height * Width / image.Width;
		if (height > Height)
		{
			Width = image.Width * Height / image.Height;
			height = Height;
		}
		Height = height;
		int width = imgPhoto.Width;
		int num = imgPhoto.Height;
		int num1 = 0;
		int num2 = 0;
		int width1 = 0;
		int height1 = 0;
		float single = 0f;
		float single1 = 0f;
		float height2 = 0f;
		single1 = (float)Width / (float)width;
		height2 = (float)Height / (float)num;
		if (height2 >= single1)
		{
			single = single1;
			height1 = (int)(((float)Height - (float)num * single) / 2f);
		}
		else
		{
			single = height2;
			width1 = (int)(((float)Width - (float)width * single) / 2f);
		}
		int num3 = (int)((float)width * single);
		int num4 = (int)((float)num * single);
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
		bitmap.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
		Graphics graphic = Graphics.FromImage(bitmap);
		graphic.Clear(Color.White);
		graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphic.DrawImage(imgPhoto, new Rectangle(width1, height1, num3, num4), new Rectangle(num1, num2, width, num), GraphicsUnit.Pixel);
		bitmap.Save(NewFile);
		graphic.Dispose();
		return bitmap;
	}

	public static ImageCodecInfo GetEncoderInfo(string mimeType)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < (int)imageEncoders.Length; i++)
		{
			if (imageEncoders[i].MimeType == mimeType)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	public void InsertThumbCommand(string Command)
	{
		commonClass _commonClass = new commonClass();
		string str = string.Concat("insert into tb_ThumbnailCommand (CommandName,isImageCreated) values ('", Command, "',0)");
		SqlCommand sqlCommand = new SqlCommand(str, _commonClass.openConnection())
		{
			CommandType = CommandType.Text
		};
		sqlCommand.ExecuteNonQuery();
		_commonClass.closeConnection();
	}

	public Image ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
	{
		Image image = Image.FromFile(OriginalFile);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		image.RotateFlip(RotateFlipType.Rotate180FlipNone);
		if (OnlyResizeIfWider && image.Width <= NewWidth)
		{
			NewWidth = image.Width;
		}
		int height = image.Height * NewWidth / image.Width;
		if (height > MaxHeight)
		{
			NewWidth = image.Width * MaxHeight / image.Height;
			height = MaxHeight;
		}
		Image thumbnailImage = image.GetThumbnailImage(NewWidth, height, new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
		image.Dispose();
		thumbnailImage.Save(NewFile, ImageFormat.Jpeg);
		return thumbnailImage;
	}

	public Image ResizeImageNew(Image FullsizeImage, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
	{
		FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
		FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
		if (OnlyResizeIfWider && FullsizeImage.Width <= NewWidth)
		{
			NewWidth = FullsizeImage.Width;
		}
		int height = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
		if (height > MaxHeight)
		{
			NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
			height = MaxHeight;
		}
		Image thumbnailImage = FullsizeImage.GetThumbnailImage(NewWidth, height, new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
		FullsizeImage.Dispose();
		return thumbnailImage;
	}

	public void RotateImage(string ImageUrl, string tempUplaod, int angle)
	{
		Image image = Image.FromFile(ImageUrl);
		ImageCodecInfo encoderInfo = createImageThumnail.GetEncoderInfo("image/jpeg");
		Encoder transformation = Encoder.Transformation;
		EncoderParameters encoderParameter = new EncoderParameters(1);
		EncoderParameter encoderParameter1 = null;
		if (angle == 90)
		{
			encoderParameter1 = new EncoderParameter(transformation, (long)13);
		}
		else if (angle == 180)
		{
			encoderParameter1 = new EncoderParameter(transformation, (long)14);
		}
		else if (angle == 270)
		{
			encoderParameter1 = new EncoderParameter(transformation, (long)15);
		}
		encoderParameter.Param[0] = encoderParameter1;
		image.Save(tempUplaod, encoderInfo, encoderParameter);
		image.Dispose();
		image = null;
		GC.Collect();
	}

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

	public void SwapImage(string oldImage, string NewImage, string cropType)
	{
		NewImage = NewImage.Replace("MyUploads", "tempUpload");
		Image image = Image.FromFile(NewImage);
		string str = oldImage;
		string str1 = str.Replace("MyUploads/", "MyUploads/");
		string str2 = str.Replace("MyUploads/", "MyUploads/t_");
		if (cropType == "null")
		{
			File.Delete(oldImage);
			image.Save(oldImage, ImageFormat.Jpeg);
			image.Dispose();
			return;
		}
		if (cropType == "bigphoto")
		{
			File.Delete(oldImage);
			this.ResizeImage(NewImage, str1, 500, 500, true);
			return;
		}
		if (cropType == "thumbnail")
		{
			this.corpImages(NewImage, str2, 50, 50);
		}
	}

	public bool ThumbnailCallback()
	{
		return true;
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