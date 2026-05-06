using nmsCommon;
using Printcenter.UI.CMS;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace nmsConnection
{
	public class ConnectionClass
	{
		private commonclass comm = new commonclass();

		public static string AccountID
		{
			get
			{
				string empty = string.Empty;
				HttpSessionState session = HttpContext.Current.Session;
				empty = (session["AccountID"] == null ? "0" : session["AccountID"].ToString());
				return empty;
			}
		}

		public static string AccountName
		{
			get
			{
				string empty = string.Empty;
				HttpSessionState session = HttpContext.Current.Session;
				empty = (session["AccountName"] == null ? "" : session["AccountName"].ToString());
				return empty;
			}
		}

		public static string AccountType
		{
			get
			{
				return "private";
			}
		}

		public static string CatagoryImagePath
		{
			get
			{
				commonclass _commonclass = new commonclass();
				string empty = string.Empty;
				string str = string.Empty;
				if (ConnectionClass.AccountType.ToString().ToLower() == "private")
				{
					str = _commonclass.return_CompanyID("private");
					empty = (EprintConfigurationManager.AppSettings["ImagePath"] == null ? "" : string.Concat(EprintConfigurationManager.AppSettings["ImagePath"].ToString(), str, "/ProductCatalogueCategory/"));
				}
				else if (ConnectionClass.AccountType.ToString().ToLower() == "public")
				{
					str = _commonclass.return_CompanyID("public");
					empty = (EprintConfigurationManager.AppSettings["ImagePath"] == null ? "" : string.Concat(EprintConfigurationManager.AppSettings["ImagePath"].ToString(), str, "/ProductCatalogueCategory/"));
				}
				return empty;
			}
		}

		public static string CompanyID
		{
			get
			{
				commonclass _commonclass = new commonclass();
				if (ConnectionClass.AccountType.ToString().ToLower() == "private")
				{
					string empty = string.Empty;
					return _commonclass.return_CompanyID("private");
				}
				if (EprintConfigurationManager.AppSettings["CompanyID"] == null)
				{
					return "0";
				}
				return EprintConfigurationManager.AppSettings["CompanyID"].ToString();
			}
		}

		public static string CurrencySymbol
		{
			get
			{
				if (HttpContext.Current.Session["CurrencySymbol"] == null)
				{
					return "$";
				}
				return HttpContext.Current.Session["CurrencySymbol"].ToString().Trim();
			}
		}

		public static string EmailEnable
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailEnable"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["EmailEnable"].ToString();
			}
		}

		public static string EmailHostName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailHostName"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailHostName"].ToString();
			}
		}

		public static string EmailPassword
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailPassword"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailPassword"].ToString();
			}
		}

		public static string EmailUserName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailUserName"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailUserName"].ToString();
			}
		}

		public static string EnableDescription
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EnableDescription"] == null)
				{
					return "true";
				}
				return EprintConfigurationManager.AppSettings["EnableDescription"].ToString();
			}
		}

		public static string eprintDocument
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["eprintDocument"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["eprintDocument"];
			}
		}

		public static string FileExtension
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["FileExtension"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["FileExtension"].ToString();
			}
		}

		public static string FromEmail
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["FromEmail"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["FromEmail"].ToString();
			}
		}

		public static string ImageHandlerPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ImageHandlerPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["ImageHandlerPath"];
			}
		}

		public static string ImagePath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["StoreimagePath"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["StoreimagePath"].ToString();
			}
		}

		public static bool IsAdvancePayPal
		{
			get
			{
				bool flag = false;
				if (EprintConfigurationManager.AppSettings["IsAdvancePayPal"] != null)
				{
					flag = Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsAdvancePayPal"].ToString());
				}
				return flag;
			}
		}

		public static bool IsImageUploadEnable
		{
			get
			{
				bool flag = false;
				if (EprintConfigurationManager.AppSettings["IsImageUploadEnable"] != null)
				{
					flag = Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsImageUploadEnable"].ToString());
				}
				return flag;
			}
		}

		public static string IsmailChimpEnabled
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["IsmailChimpEnabled"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["IsmailChimpEnabled"] != "true" ? "false" : EprintConfigurationManager.AppSettings["IsmailChimpEnabled"].ToString());
				}
				return str;
			}
		}

		public static bool IsPreflightEnable
		{
			get
			{
				bool flag = false;
				if (EprintConfigurationManager.AppSettings["IsPreflightEnable"] != null)
				{
					flag = Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsPreflightEnable"].ToString());
				}
				return flag;
			}
		}

		public static string KeySeparator
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["KeySeparator"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["KeySeparator"].ToString();
			}
		}

		public static string mSmtpClientEnableSsl
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"] != "true" ? "false" : EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"].ToString());
				}
				return str;
			}
		}

		public static int mSmtpClientPort
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["mSmtpClientPort"] == null)
				{
					return 25;
				}
				return Convert.ToInt32(EprintConfigurationManager.AppSettings["mSmtpClientPort"]);
			}
		}

		public static string NewOrderAdminEmailID
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["NewOrderAdminEmailID"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["NewOrderAdminEmailID"];
			}
		}

		public static string OrderPrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OrderPrefix"] == null)
				{
					return "ORD-";
				}
				return EprintConfigurationManager.AppSettings["OrderPrefix"].ToString();
			}
		}

		public static string PayPal_Live_APIPassword
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_Live_APIPassword"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_Live_APIPassword"];
			}
		}

		public static string PayPal_Live_APISignature
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_Live_APISignature"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_Live_APISignature"];
			}
		}

		public static string PayPal_Live_APIUsername
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_Live_APIUsername"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_Live_APIUsername"];
			}
		}

		public static string PayPal_SandBox_APIPassword
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_SandBox_APIPassword"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_SandBox_APIPassword"];
			}
		}

		public static string PayPal_SandBox_APISignature
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_SandBox_APISignature"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_SandBox_APISignature"];
			}
		}

		public static string PayPal_SandBox_APIUsername
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PayPal_SandBox_APIUsername"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PayPal_SandBox_APIUsername"];
			}
		}

		public static string Paypalbusiness
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Paypalbusiness"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["Paypalbusiness"].ToString();
			}
		}

		public static string PaypalLiveMode
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PaypalLiveMode"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PaypalLiveMode"];
			}
		}

		public static string PaypalLiveUrl
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PaypalLiveUrl"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PaypalLiveUrl"];
			}
		}

		public static string PaypalTestUrl
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PaypalTestUrl"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PaypalTestUrl"];
			}
		}

		public static string PdfSource
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PdfSource"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PdfSource"];
			}
		}

		public static string PreviewPageName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PreviewPageName"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["PreviewPageName"].ToString();
			}
		}

		public static string ProductImagePath
		{
			get
			{
				commonclass _commonclass = new commonclass();
				string empty = string.Empty;
				string str = string.Empty;
				if (ConnectionClass.AccountType.ToString().ToLower() == "private")
				{
					str = _commonclass.return_CompanyID("private");
					empty = (EprintConfigurationManager.AppSettings["ImagePath"] == null ? "" : string.Concat(EprintConfigurationManager.AppSettings["ImagePath"].ToString(), str, "/Product/"));
				}
				else if (ConnectionClass.AccountType.ToString().ToLower() == "public")
				{
					str = _commonclass.return_CompanyID("public");
					empty = (EprintConfigurationManager.AppSettings["ImagePath"] == null ? "" : string.Concat(EprintConfigurationManager.AppSettings["ImagePath"].ToString(), str, "/Product/"));
				}
				return empty;
			}
		}

		public static string PublicDocPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PublicDocPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["PublicDocPath"];
			}
		}

		public static string RewriteModule
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["RewriteModule"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["RewriteModule"].ToString();
			}
		}

		public static string SecureDocFilepath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SecureDocFilepath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["SecureDocFilepath"];
			}
		}

		public static string SecureDocPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SecureDocPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["SecureDocPath"];
			}
		}

		public static string SecureSitePath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SecureSitePath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["SecureSitePath"];
			}
		}

		public static string ServerName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ServerName"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["ServerName"];
			}
		}

		public static string SitePath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SitePath"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["SitePath"].ToString();
			}
		}

		public static string StoreimageHandlerPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["StoreimageHandlerPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["StoreimageHandlerPath"].ToString();
			}
		}

		public static string StyleSheetPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["StyleSheetPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["StyleSheetPath"];
			}
		}

		public static string SystemName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SystemName"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["SystemName"].ToString();
			}
		}

		public static string VersionNumber
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["VersionNumber"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["VersionNumber"].ToString();
			}
		}

        public static string ShipApiKey
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["ShipAPiKey"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["ShipAPiKey"].ToString();
            }
        }

        public ConnectionClass()
		{
		}

		public static string PageName(int CompanyID, int AccountID, int pageID)
		{
			string str;
			DataTable dataTable = CMSBasePage.CMSPages_get(CompanyID, AccountID, pageID);
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow current = (DataRow)enumerator.Current;
					if (pageID != 0)
					{
						str = current["pageName"].ToString();
						return str;
					}
					else
					{
						if (current["systemName"].ToString().ToLower().Trim() != "home")
						{
							continue;
						}
						str = current["pageName"].ToString();
						return str;
					}
				}
				return "Home";
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return str;
		}

		public static string RemoveIllegalChars(string S)
		{
			if (S != "")
			{
				S = S.Replace("\\", "-");
				S = S.Replace("/", "-");
				S = S.Replace("|", "-");
				S = S.Replace(":", "-");
				S = S.Replace("*", "-");
				S = S.Replace("?", "-");
				S = S.Replace("<", "-");
				S = S.Replace(">", "-");
				S = S.Replace("&", "");
				S = S.Replace(".htm", "?htm");
				S = S.Replace(".", "");
				S = S.Replace("?htm", ".htm");
				S = S.Replace("(", "_");
				S = S.Replace(")", "_");
				S = S.Replace("%", "");
				S = S.Replace("\"", "-");
				S = S.Replace(" ", "-");
				S = S.Replace("+", "-");
				S = S.Replace("\r\n", "-");
			}
			return S;
		}
	}
}