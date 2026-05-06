using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace nmsCommon
{
	public class Encryption
	{
		private Encryption()
		{
		}

		public static QueryString DecryptQueryString(QueryString queryString)
		{
			QueryString queryString1 = new QueryString();
			foreach (string str in queryString)
			{
				string str1 = Encryption.DeHex(str);
				string str2 = Encryption.DeHex(queryString[str]);
				queryString1.Add(str1, str2);
			}
			return queryString1;
		}

		public static string DeHex(string hexstring)
		{
			string empty = string.Empty;
			StringBuilder stringBuilder = new StringBuilder(hexstring.Length / 2);
			for (int i = 0; i <= hexstring.Length - 1; i = i + 2)
			{
				stringBuilder.Append((char)int.Parse(hexstring.Substring(i, 2), NumberStyles.HexNumber));
			}
			return stringBuilder.ToString();
		}

		public static QueryString EncryptQueryString(QueryString queryString)
		{
			QueryString queryString1 = new QueryString();
			string empty = string.Empty;
			string item = string.Empty;
			foreach (string str in queryString)
			{
				empty = str;
				item = queryString[str];
				queryString1.Add(Encryption.Hex(empty), Encryption.Hex(item));
			}
			return queryString1;
		}

		public static string Hex(string sData)
		{
			string empty = string.Empty;
			string str = string.Empty;
			StringBuilder stringBuilder = new StringBuilder(sData.Length * 2);
			for (int i = 0; i < sData.Length; i++)
			{
				if (sData.Length - (i + 1) <= 0)
				{
					stringBuilder.Append(string.Format("{0:X2}", (int)sData.ToCharArray()[i]));
				}
				else
				{
					empty = sData.Substring(i, 2);
					if (empty == "\\n")
					{
						str = string.Concat(str, "0A");
					}
					else if (empty == "\\b")
					{
						str = string.Concat(str, "20");
					}
					else if (empty == "\\r")
					{
						str = string.Concat(str, "0D");
					}
					else if (empty == "\\c")
					{
						str = string.Concat(str, "2C");
					}
					else if (empty == "\\c")
					{
						str = string.Concat(str, "5C");
					}
					else if (empty == "\\0")
					{
						str = string.Concat(str, "00");
					}
					else if (empty != "\\t")
					{
						stringBuilder.Append(string.Format("{0:X2}", (int)sData.ToCharArray()[i]));
						i--;
					}
					else
					{
						str = string.Concat(str, "07");
					}
				}
				i++;
			}
			return stringBuilder.ToString();
		}

		public static ArrayList querystrvalue(string querystr)
		{
			string str = querystr.Substring(1, querystr.Length - 1);
			string[] strArrays = str.Split(new char[] { '&' });
			ArrayList arrayLists = new ArrayList();
			string[] strArrays1 = strArrays;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				string str1 = strArrays1[i];
				string[] strArrays2 = str1.Split(new char[] { '=' });
				arrayLists.Add(strArrays2[0]);
				arrayLists.Add(strArrays2[1]);
			}
			return arrayLists;
		}
	}
}