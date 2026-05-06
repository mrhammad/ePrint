using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class QueryStringModule : IHttpModule
{
	private const string PARAMETER_NAME = "path=";

	private const string ENCRYPTION_KEY = "key";

	private readonly static byte[] SALT;

	static QueryStringModule()
	{
		Encoding aSCII = Encoding.ASCII;
		int length = "key".Length;
		QueryStringModule.SALT = aSCII.GetBytes(length.ToString());
	}

	public QueryStringModule()
	{
	}

	public static string Decrypt(string inputText)
	{
		string str;
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		byte[] numArray = Convert.FromBase64String(inputText);
		PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes("key", QueryStringModule.SALT);
		using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16)))
		{
			using (MemoryStream memoryStream = new MemoryStream(numArray))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
				{
					byte[] numArray1 = new byte[(int)numArray.Length];
					int num = cryptoStream.Read(numArray1, 0, (int)numArray1.Length);
					str = Encoding.Unicode.GetString(numArray1, 0, num);
				}
			}
		}
		return str;
	}

	public void Dispose()
	{
	}

	public static string Encrypt(string inputText)
	{
		string str;
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		byte[] bytes = Encoding.Unicode.GetBytes(inputText);
		PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes("key", QueryStringModule.SALT);
		using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16)))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes, 0, (int)bytes.Length);
					cryptoStream.FlushFinalBlock();
					str = string.Concat("?path=", Convert.ToBase64String(memoryStream.ToArray()));
				}
			}
		}
		return str;
	}

	public void Init(HttpApplication context)
	{
	}
}