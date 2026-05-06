using nmsCommon;
using nmsConnectionClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ePrint
{
    /// <summary>
    /// Summary description for AttachmentsManager
    /// </summary>
    public class AttachmentsManager : IHttpHandler, IRequiresSessionState
    {
		private HttpContext _httpContext;

		private string _fileName;

		private string _type;

		private string _CompanyID = string.Empty;

		public string _DocID = string.Empty;

		public string DocType = string.Empty;

		public string _PID = string.Empty;

		public string SecFileName = string.Empty;

		private commonClass comncls = new commonClass();

		private nmsCommon.global @global = new nmsCommon.global();

		public string SecureSitePath = string.Empty;

		public string ServerName = string.Empty;

		public string path = string.Empty;

		public string SecureDocPath = string.Empty;

		public string SecureDocFilepath = string.Empty;

		public string _CatID = string.Empty;

		public string DocumentType = string.Empty;

		public string ReqSecuredFileName = string.Empty;

		public string AccountID = string.Empty;

		public string recive = string.Empty;

		public string Store_ThemePath = string.Empty;

		public string CartImg = string.Empty;

		public string IsReport = string.Empty;

		public string orderNumber = string.Empty;

		public string newfilePath = string.Empty;

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public AttachmentsManager()
        {

        }
		public void ProcessRequest(HttpContext context)
        {
			this.Store_ThemePath = string.Concat(nmsCommon.global.PublicDocPath(), ConnectionClass.ServerName, "/");
			this.SecureSitePath = nmsCommon.global.SecureSitePath();
			this.SecureDocPath = nmsCommon.global.SecureDocPath();
			this.SecureDocFilepath = nmsCommon.global.SecureDocFilepath();
			this.ServerName = ConnectionClass.ServerName;
			ArrayList arrayLists = new ArrayList();

			this._httpContext = context;
			if (this._httpContext.Request.QueryString["doctype"] != null)
			{
				this.DocumentType = this._httpContext.Request.QueryString["doctype"];
			}
			if (this._httpContext.Session["CompanyID"] != null)
			{
				this._CompanyID = this._httpContext.Session["CompanyID"].ToString();
			}
			else if (this._httpContext.Session["LoginCompanyID"] != null)
			{
				this._CompanyID = this._httpContext.Session["LoginCompanyID"].ToString();
			}
			QueryString queryString = QueryString.FromCurrent();
			try
			{
				this.recive = Encryption.DecryptQueryString(queryString).ToString();
				arrayLists = Encryption.querystrvalue(this.recive);
				if (!string.IsNullOrEmpty(arrayLists[1].ToString()))
				{
					this.DocumentType = arrayLists[1].ToString();
					this.ReqSecuredFileName = arrayLists[3].ToString();
					this.CartImg = arrayLists[5].ToString();
				}
			}
			catch
			{
			}
			if (this._httpContext.Request.QueryString["filename"] != null)
			{
				this.ReqSecuredFileName = this._httpContext.Request.QueryString["filename"];
			}
			if (this._httpContext.Request.QueryString["ordernumber"] != null)
			{
				this.orderNumber = this._httpContext.Request.QueryString["ordernumber"];
			}
			if (this._httpContext.Request.QueryString["rep"] != null)
			{
				this.IsReport = this._httpContext.Request.QueryString["rep"];
			}
			string lower = this.DocumentType.ToString().ToLower();
			string str = lower;
			if (lower != null)
			{
				switch (str)
				{
					case "product":
						{
							if (!string.IsNullOrEmpty(arrayLists[3].ToString()))
							{
								this._PID = arrayLists[3].ToString();
							}
							DataTable dataTable = new DataTable();
							dataTable = this.comncls.GetFileNameonDocType("product", Convert.ToInt32(this._PID));
							IEnumerator enumerator = dataTable.Rows.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									DataRow current = (DataRow)enumerator.Current;
									this.SecFileName = current["productimage"].ToString();
									if (string.IsNullOrEmpty(this.SecFileName))
									{
										continue;
									}
									string[] secureDocPath = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/Product/", this.SecFileName };
									this.path = string.Concat(secureDocPath);
								}
								break;
							}
							finally
							{
								IDisposable disposable = enumerator as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
							break;
						}
					case "prodnew":
						{
							string[] strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/Product/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays);
							break;
						}
					case "category":
						{
							if (!string.IsNullOrEmpty(arrayLists[3].ToString()))
							{
								this._CatID = arrayLists[3].ToString();
							}
							DataTable fileNameonDocType = new DataTable();
							fileNameonDocType = this.comncls.GetFileNameonDocType("cataloguecategory", Convert.ToInt32(this._CatID));
							IEnumerator enumerator1 = fileNameonDocType.Rows.GetEnumerator();
							try
							{
								while (enumerator1.MoveNext())
								{
									DataRow dataRow = (DataRow)enumerator1.Current;
									this.SecFileName = dataRow["categoryimage"].ToString();
									if (string.IsNullOrEmpty(this.SecFileName))
									{
										continue;
									}
									string[] secureDocPath1 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/ProductCatalogueCategory/", this.SecFileName };
									this.path = string.Concat(secureDocPath1);
								}
								break;
							}
							finally
							{
								IDisposable disposable1 = enumerator1 as IDisposable;
								if (disposable1 != null)
								{
									disposable1.Dispose();
								}
							}
							break;
						}
					case "catnew":
						{
							string[] strArrays1 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/ProductCatalogueCategory/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays1);
							break;
						}
					case "pr":
						{
							if (this.IsReport != "yes")
							{
								if (!string.IsNullOrEmpty(arrayLists[3].ToString()))
								{
									this._PID = arrayLists[3].ToString();
								}
								DataTable dataTable1 = new DataTable();
								dataTable1 = this.comncls.GetFileNameonDocType("printreadyfile", Convert.ToInt32(this._PID));
								IEnumerator enumerator2 = dataTable1.Rows.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										DataRow current1 = (DataRow)enumerator2.Current;
										this.SecFileName = current1["printreadyfile"].ToString();
										if (string.IsNullOrEmpty(this.SecFileName))
										{
											continue;
										}
										string[] secureDocFilepath = new string[] { this.SecureDocFilepath, this.ServerName, "/", this._CompanyID, "/Product/PrintReady/", this.SecFileName };
										this.path = string.Concat(secureDocFilepath);
									}
									break;
								}
								finally
								{
									IDisposable disposable2 = enumerator2 as IDisposable;
									if (disposable2 != null)
									{
										disposable2.Dispose();
									}
								}
							}
							else
							{
								string[] secureDocFilepath1 = new string[] { this.SecureDocFilepath, this.ServerName, "/", this._CompanyID, "/Product/PrintReady/", this.ReqSecuredFileName };
								this.path = string.Concat(secureDocFilepath1);
								break;
							}
							break;
						}
					case "imgcpprd":
						{
							string[] secureDocPath2 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/Product/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath2);
							break;
						}
					case "imgcpcat":
						{
							string[] strArrays2 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/ProductCatalogueCategory/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays2);
							break;
						}
					case "imgcpuser":
						{
							string[] secureDocPath3 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/UserImageCategory/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath3);
							break;
						}
					case "attachments":
						{
							string[] _strArrays = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/attachments/" };
							string _path = string.Concat(_strArrays);

						    this.newfilePath = string.Concat(_path, orderNumber + "_" + this.ReqSecuredFileName);
							string[] strArrays3 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/attachments/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays3);
							if (!File.Exists(this.newfilePath))
                            {
								File.Copy(this.path, this.newfilePath);
							}
							break;
						}
					case "banner":
						{
							if (this._httpContext.Request.QueryString["actid"] != null)
							{
								this.AccountID = this._httpContext.Request.QueryString["actid"];
							}
							string[] secureDocPath4 = new string[] { this.SecureDocPath, this.ServerName, "/store/", this.AccountID, "/banners/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath4);
							break;
						}
					case "logo":
						{
							string[] strArrays4 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays4);
							break;
						}
					case "tpdf":
						{
							string[] secureDocPath5 = new string[] { this.SecureDocPath, this.ServerName, "/", this._CompanyID, "/TemplatePDF/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath5);
							break;
						}
					case "cartimage":
						{
							string[] storeThemePath = new string[] { this.Store_ThemePath, "store\\", this.ReqSecuredFileName, "\\CartIcon\\", this.CartImg };
							this.path = string.Concat(storeThemePath);
							break;
						}
					case "defaultcartimage":
						{
							this.path = string.Concat(nmsCommon.global.filePath(), "/images/StoreImages/empty_cart_icon.png");
							break;
						}
					case "contactimg":
						{
							string[] strArrays5 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this._CompanyID, "//ContactImages/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays5);
							break;
						}
					case "deptimg":
						{
							string[] secureDocPath6 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this._CompanyID, "//DepartmentImages/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath6);
							break;
						}
					case "pitstopinput":
						{
							string[] strArrays6 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this._CompanyID, "//PitStop/inputpdf/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays6);
							break;
						}
					case "pitstopoutput":
						{
							string[] secureDocPath7 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this._CompanyID, "//PitStop/outputPdf/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath7);
							break;
						}
					case "pitstopreport":
						{
							string[] strArrays7 = new string[] { this.SecureDocPath, "//", this.ServerName, "//", this._CompanyID, "//PitStop/ReportPdf/", this.ReqSecuredFileName };
							this.path = string.Concat(strArrays7);
							break;
						}
					case "previewimage":
						{
							if (this._httpContext.Request.QueryString["actid"] != null)
							{
								this.AccountID = this._httpContext.Request.QueryString["actid"];
							}
							string[] secureDocPath8 = new string[] { this.SecureDocPath, this.ServerName, "/store/", this.AccountID, "/pdf/", this.ReqSecuredFileName };
							this.path = string.Concat(secureDocPath8);
							break;
						}
				}
			}
			if (File.Exists(this.newfilePath))
			{
				FileInfo fileInfo = new FileInfo(this.newfilePath);
				File.ReadAllBytes(this.newfilePath);
				context.Response.StatusCode = 200;
				context.Response.ContentType = "application/octet-stream";
				context.Response.Buffer = true;
				context.Response.Clear();
				context.Response.AddHeader("content-disposition", string.Concat("attachment;filename=\"", fileInfo.Name, "\""));
				context.Response.TransmitFile(this.newfilePath);
				context.Response.End();
				context.Response.Flush();

			}
		}
    }
}