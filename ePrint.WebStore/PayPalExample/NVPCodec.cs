using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Web;

namespace PayPalExample
{
	public sealed class NVPCodec : NameValueCollection
	{
		private const string AMPERSAND = "&";

		private const string EQUALS = "=";

		private readonly static char[] AMPERSAND_CHAR_ARRAY;

		private readonly static char[] EQUALS_CHAR_ARRAY;

		public string this[string name, int index]
		{
			get
			{
				return base[NVPCodec.GetArrayName(index, name)];
			}
			set
			{
				base[NVPCodec.GetArrayName(index, name)] = value;
			}
		}

		static NVPCodec()
		{
			NVPCodec.AMPERSAND_CHAR_ARRAY = "&".ToCharArray();
			NVPCodec.EQUALS_CHAR_ARRAY = "=".ToCharArray();
		}

		public NVPCodec()
		{
		}

		public void Add(string name, string value, int index)
		{
			this.Add(NVPCodec.GetArrayName(index, name), value);
		}

		public void Decode(string nvpstring)
		{
			this.Clear();
			string[] strArrays = nvpstring.Split(NVPCodec.AMPERSAND_CHAR_ARRAY);
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string[] strArrays1 = strArrays[i].Split(NVPCodec.EQUALS_CHAR_ARRAY);
				if ((int)strArrays1.Length >= 2)
				{
					string str = HttpUtility.UrlDecode(strArrays1[0]);
					this.Add(str, HttpUtility.UrlDecode(strArrays1[1]));
				}
			}
		}

		public string Encode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			string[] allKeys = this.AllKeys;
			for (int i = 0; i < (int)allKeys.Length; i++)
			{
				string str = allKeys[i];
				string str1 = HttpUtility.UrlEncode(str);
				string str2 = HttpUtility.UrlEncode(base[str]);
				if (!flag)
				{
					stringBuilder.Append("&");
				}
				stringBuilder.Append(str1).Append("=").Append(str2);
				flag = false;
			}
			return stringBuilder.ToString();
		}

		private static string GetArrayName(int index, string name)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", string.Concat("index can not be negative : ", index));
			}
			return string.Concat(name, index);
		}

		public void Remove(string arrayName, int index)
		{
			this.Remove(NVPCodec.GetArrayName(index, arrayName));
		}
	}
}