using System;
using System.IO;
using System.IO.Compression;

public static class Compressor
{
	public static byte[] Compress(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream();
		GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
		gZipStream.Write(data, 0, (int)data.Length);
		gZipStream.Close();
		return memoryStream.ToArray();
	}

	public static byte[] Decompress(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(data, 0, (int)data.Length);
		memoryStream.Position = (long)0;
		GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress, true);
		MemoryStream memoryStream1 = new MemoryStream();
		byte[] numArray = new byte[64];
		int i = -1;
		for (i = gZipStream.Read(numArray, 0, (int)numArray.Length); i > 0; i = gZipStream.Read(numArray, 0, (int)numArray.Length))
		{
			memoryStream1.Write(numArray, 0, i);
		}
		gZipStream.Close();
		return memoryStream1.ToArray();
	}
}