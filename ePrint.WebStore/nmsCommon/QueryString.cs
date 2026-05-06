using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;

namespace nmsCommon
{
	public class QueryString : NameValueCollection
	{
		private string document;

		public string Document
		{
			get
			{
				return this.document;
			}
		}

		public QueryString()
		{
		}

		public QueryString(NameValueCollection clone) : base(clone)
		{
		}

		public override void Add(string name, string value)
		{
			if (base[name] != null)
			{
				base[name] = value;
				return;
			}
			base.Add(name, value);
		}

		public void ClearAllExcept(string except)
		{
			this.ClearAllExcept(new string[] { except });
		}

		public void ClearAllExcept(string[] except)
		{
			ArrayList arrayLists = new ArrayList();
			string[] allKeys = this.AllKeys;
			for (int i = 0; i < (int)allKeys.Length; i++)
			{
				string str = allKeys[i];
				string[] strArrays = except;
				for (int j = 0; j < (int)strArrays.Length; j++)
				{
					string str1 = strArrays[j];
					if (str.ToLower() == str1.ToLower() && !arrayLists.Contains(str))
					{
						arrayLists.Add(str);
					}
				}
			}
			foreach (string arrayList in arrayLists)
			{
				this.Remove(arrayList);
			}
		}

		public static QueryString FromCurrent()
		{
			return QueryString.FromUrl(HttpContext.Current.Request.Url.AbsoluteUri);
		}

		public static QueryString FromUrl(string url)
		{
			QueryString queryString;
			QueryString queryString1 = new QueryString();
			try
			{
				string[] strArrays = url.Split("?".ToCharArray());
				queryString1.document = strArrays[0];
				if ((int)strArrays.Length != 1)
				{
					string[] strArrays1 = strArrays[1].Split("&".ToCharArray());
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						string[] strArrays2 = strArrays1[i].Split("=".ToCharArray());
						if ((int)strArrays2.Length == 1)
						{
							queryString1.Add(strArrays2[0], "");
						}
						queryString1.Add(strArrays2[0], strArrays2[1]);
					}
					queryString = queryString1;
				}
				else
				{
					queryString = queryString1;
				}
			}
			catch
			{
				queryString = queryString1;
			}
			return queryString;
		}

		public override string ToString()
		{
			return this.ToString(false);
		}

		public string ToString(bool includeUrl)
		{
			string[] strArrays = new string[this.Count];
			string[] allKeys = this.AllKeys;
			for (int i = 0; i < (int)allKeys.Length; i++)
			{
				strArrays[i] = string.Concat(allKeys[i], "=", HttpContext.Current.Server.UrlEncode(base[allKeys[i]]));
			}
			string str = string.Join("&", strArrays);
			if ((str != null || str != string.Empty) && !str.StartsWith("?"))
			{
				str = string.Concat("?", str);
			}
			if (includeUrl)
			{
				str = string.Concat(this.document, str);
			}
			return str;
		}
	}
}