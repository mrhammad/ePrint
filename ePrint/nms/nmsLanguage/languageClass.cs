using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmsLanguage
{
	public class languageClass : System.Web.UI.Page
	{
		private ResourceManager rm;

		protected Label lblLanguage;

		protected DropDownList cboLanguage;

		protected Button Button1;

		public languageClass()
		{
		}

		public string convert(string languageKey)
		{
			string str;
			string str1;
			object obj;
			if (this.Session["language"] == null)
			{
				this.Session["language"] = "english";
			}
			if (!Directory.Exists(base.Server.MapPath("localization")))
			{
				this.rm = ResourceManager.CreateFileBasedResourceManager("MyStrings", base.Server.MapPath("Localization"), null);
			}
			else
			{
				this.rm = ResourceManager.CreateFileBasedResourceManager("MyStrings", base.Server.MapPath("Localization"), null);
			}
			string str2 = this.Session["language"].ToString();
			string lower = str2.ToLower();
			string str3 = lower;
			if (lower != null)
			{
				if (str3 == "english")
				{
					str = "en-US";
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
					str1 = "";
					try
					{
						str1 = this.rm.GetString(languageKey);
						if (this.rm.GetString(languageKey) != null)
						{
							languageKey = str1;
						}
					}
					catch
					{
						obj = new object();
					}
					return languageKey;
				}
				else
				{
					if (str3 != "spanish")
					{
						str = "";
						Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
						str1 = "";
						try
						{
							str1 = this.rm.GetString(languageKey);
							if (this.rm.GetString(languageKey) != null)
							{
								languageKey = str1;
							}
						}
						catch
						{
                            obj = new object();
						}
						return languageKey;
					}
					str = "es-ES";
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
					str1 = "";
					try
					{
						str1 = this.rm.GetString(languageKey);
						if (this.rm.GetString(languageKey) != null)
						{
							languageKey = str1;
						}
					}
					catch
					{
                        obj = new object();
					}
					return languageKey;
				}
			}
			str = "";
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
			str1 = "";
			try
			{
				str1 = this.rm.GetString(languageKey);
				if (this.rm.GetString(languageKey) != null)
				{
					languageKey = str1;
				}
			}
			catch
			{
                obj = new object();
			}
			return languageKey;
		}

		public string GetLanguageConversion(string languageKey)
		{
			try
			{
				if (this.Session["LanguageConversion"] == null || this.Session["LanguageConversion"] == null)
				{
					languageKey = (string)base.GetGlobalResourceObject("English_To_English", languageKey);
				}
				else
				{
					languageKey = (string)base.GetGlobalResourceObject(this.Session["LanguageConversion"].ToString(), languageKey);
				}
			}
			catch
			{
				languageKey = languageKey;
			}
			return languageKey;
		}

		public string GetValueOnLang(string languageKey)
		{
			try
			{
				languageKey = (string)base.GetGlobalResourceObject("Resource", languageKey);
			}
			catch
			{
				languageKey = languageKey;
			}
			return languageKey;
		}

		private void Page_Load(object sender, EventArgs e)
		{
		}

		public string[] SetCulture(string strLanguage, string[] languageKey)
		{
			string str;
			int i;
			object obj;
			if (this.Session["language"] == null)
			{
				this.Session["language"] = "english";
			}
			if (!Directory.Exists(base.Server.MapPath("localization")))
			{
				this.rm = ResourceManager.CreateFileBasedResourceManager("MyStrings", base.Server.MapPath("Localization"), null);
			}
			else
			{
				this.rm = ResourceManager.CreateFileBasedResourceManager("MyStrings", base.Server.MapPath("Localization"), null);
			}
			string lower = strLanguage.ToLower();
			string str1 = lower;
			if (lower != null)
			{
				if (str1 == "english")
				{
					str = "en-US";
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
					for (i = 0; i < (int)languageKey.Length; i++)
					{
						try
						{
							if (this.rm.GetString(languageKey[i]) != null)
							{
								languageKey[i] = this.rm.GetString(languageKey[i]);
							}
						}
						catch
						{
                            obj = new object();
						}
					}
					return languageKey;
				}
				else
				{
					if (str1 != "spanish")
					{
						str = "";
						Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
						for (i = 0; i < (int)languageKey.Length; i++)
						{
							try
							{
								if (this.rm.GetString(languageKey[i]) != null)
								{
									languageKey[i] = this.rm.GetString(languageKey[i]);
								}
							}
							catch
							{
                                obj = new object();
							}
						}
						return languageKey;
					}
					str = "es-ES";
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
					for (i = 0; i < (int)languageKey.Length; i++)
					{
						try
						{
							if (this.rm.GetString(languageKey[i]) != null)
							{
								languageKey[i] = this.rm.GetString(languageKey[i]);
							}
						}
						catch
						{
                            obj = new object();
						}
					}
					return languageKey;
				}
			}
			str = "";
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(str);
			for (i = 0; i < (int)languageKey.Length; i++)
			{
				try
				{
					if (this.rm.GetString(languageKey[i]) != null)
					{
						languageKey[i] = this.rm.GetString(languageKey[i]);
					}
				}
				catch
				{
                    obj = new object();
				}
			}
			return languageKey;
		}
	}
}