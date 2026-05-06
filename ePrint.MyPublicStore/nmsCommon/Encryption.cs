using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace nmsCommon
{
	public class Encryption
	{
		private static byte[] bytes;

		static Encryption()
		{
			Encryption.bytes = Encoding.ASCII.GetBytes("ZeroCool");
		}

		private Encryption()
		{
		}

		public static string Decrypt(string cryptedString)
		{
			if (string.IsNullOrEmpty(cryptedString))
			{
				throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
			}
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(Encryption.bytes, Encryption.bytes), CryptoStreamMode.Read);
			return (new StreamReader(cryptoStream)).ReadToEnd();
		}

		public static string Encrypt(string originalString)
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				if (string.IsNullOrEmpty(originalString))
				{
					throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
				}
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(Encryption.bytes, Encryption.bytes), CryptoStreamMode.Write);
				StreamWriter streamWriter = new StreamWriter(cryptoStream);
				streamWriter.Write(originalString);
				streamWriter.Flush();
				cryptoStream.FlushFinalBlock();
				streamWriter.Flush();
			}
			catch
			{
			}
			return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		}
	}
}