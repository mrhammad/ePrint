using nmsConnectionClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;
using Telerik.Web.UI.Widgets;

namespace RadExtendedFileProvider
{
	public class ExtendedFileProvider : FileSystemContentProvider
	{
		private string test = "";

		private readonly string itemHandlerPath;

		public override bool CanCreateDirectory
		{
			get
			{
				return true;
			}
		}

		public ExtendedFileProvider(HttpContext context, string[] searchPatterns, string[] viewPaths, string[] uploadPaths, string[] deletePaths, string selectedUrl, string selectedItemTag) : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
		{
			this.itemHandlerPath = EprintConfigurationManager.AppSettings["RadCustomEditorPathItemHandler"];
			if (this.itemHandlerPath.StartsWith("~/"))
			{
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				char[] chrArray = new char[] { '/' };
				this.itemHandlerPath = string.Concat(applicationPath.TrimEnd(chrArray), this.itemHandlerPath.Substring(1));
			}
		}

		public override bool CheckDeletePermissions(string folderPath)
		{
			string[] deletePaths = base.DeletePaths;
			for (int i = 0; i < (int)deletePaths.Length; i++)
			{
				if (folderPath.StartsWith(deletePaths[i], StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public override bool CheckReadPermissions(string folderPath)
		{
			string[] viewPaths = base.ViewPaths;
			for (int i = 0; i < (int)viewPaths.Length; i++)
			{
				if (folderPath.StartsWith(viewPaths[i], StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public override bool CheckWritePermissions(string folderPath)
		{
			string[] uploadPaths = base.UploadPaths;
			for (int i = 0; i < (int)uploadPaths.Length; i++)
			{
				if (folderPath.StartsWith(uploadPaths[i], StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return true;
		}

		public override string CopyFile(string path, string newPath)
		{
			return "";
		}

		private string ExtractPathFromUrl(string url)
		{
			string str = FileBrowserContentProvider.RemoveProtocolNameAndServerName(url);
			if (str == null)
			{
				return string.Empty;
			}
			if (!str.StartsWith(this.itemHandlerPath))
			{
				return str;
			}
			return str.Substring(this.GetItemUrl(string.Empty).Length);
		}

		public override Stream GetFile(string url)
		{
			string empty = string.Empty;
			string str = Convert.ToString(this.GetSession("CompanyID"));
			if (!url.Contains("~securepath~"))
			{
				string[] imageHandlerPath = new string[] { ConnectionClass.ImageHandlerPath, null, null, null, null, null };
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				char[] chrArray = new char[] { '/' };
				imageHandlerPath[1] = applicationPath.TrimEnd(chrArray);
				imageHandlerPath[2] = "/document/";
				imageHandlerPath[3] = str;
				imageHandlerPath[4] = "/";
				imageHandlerPath[5] = this.GetFileName(url);
				empty = string.Concat(imageHandlerPath);
			}
			else
			{
				string str1 = url.Replace(string.Concat(this.itemHandlerPath, "?path="), "");
				empty = string.Concat(ConnectionClass.ImageHandlerPath, str1.Replace("~securepath~", string.Concat("/document/", str, "/")));
			}
			if (File.Exists(empty))
			{
				byte[] numArray = File.ReadAllBytes(empty);
				if (!object.Equals(numArray, null))
				{
					return new MemoryStream(numArray);
				}
			}
			return null;
		}

		public override string GetFileName(string url)
		{
			return Path.GetFileName(this.ExtractPathFromUrl(url));
		}

		private string GetItemUrl(string virtualItemPath)
		{
			return string.Format("{0}?path={1}", this.itemHandlerPath, virtualItemPath);
		}

		public override string GetPath(string url)
		{
			return base.GetPath(this.ExtractPathFromUrl(url));
		}

		private new PathPermissions GetPermissions(string folderPath)
		{
			PathPermissions pathPermission = PathPermissions.Read;
			if (this.CheckDeletePermissions(folderPath))
			{
				pathPermission = PathPermissions.Delete | pathPermission;
			}
			if (this.CheckWritePermissions(folderPath))
			{
				pathPermission = PathPermissions.Upload | pathPermission;
			}
			return pathPermission;
		}

		public object GetSession(string key)
		{
			if (HttpContext.Current.Session[key] == null)
			{
				return string.Empty;
			}
			return HttpContext.Current.Session[key];
		}

		public override string MoveFile(string path, string newPath)
		{
			return "";
		}

		public override DirectoryItem ResolveDirectory(string path)
		{
			DirectoryItem permissions = base.ResolveDirectory(path);
			if (permissions == null)
			{
				return null;
			}
			permissions.Permissions = this.GetPermissions(permissions.Path);
			List<FileItem> fileItems = new List<FileItem>();
			FileItem[] files = permissions.Files;
			for (int i = 0; i < (int)files.Length; i++)
			{
				FileItem itemUrl = files[i];
				itemUrl.Location = this.GetItemUrl(itemUrl.Path.Replace(string.Concat("/document/", HttpContext.Current.Session["CompanyID"].ToString(), "/"), "~securepath~"));
			}
			return permissions;
		}

		public override string StoreBitmap(Bitmap bitmap, string url, ImageFormat format)
		{
			string str = this.ExtractPathFromUrl(url);
			string fileName = this.GetFileName(str);
			string path = this.GetPath(str);
			path = string.Concat(ConnectionClass.ImageHandlerPath, str);
			if (!path.Contains("~securepath~"))
			{
				string[] imageHandlerPath = new string[] { ConnectionClass.ImageHandlerPath, null, null, null, null, null };
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				char[] chrArray = new char[] { '/' };
				imageHandlerPath[1] = applicationPath.TrimEnd(chrArray);
				imageHandlerPath[2] = "/document/";
				imageHandlerPath[3] = HttpContext.Current.Session["CompanyID"].ToString();
				imageHandlerPath[4] = "/";
				imageHandlerPath[5] = fileName;
				path = string.Concat(imageHandlerPath);
			}
			else
			{
				path = path.Replace("~securepath~", string.Concat("/document/", HttpContext.Current.Session["CompanyID"].ToString(), "/"));
			}
			bitmap.Save(path);
			if (!string.IsNullOrEmpty("Please try again"))
			{
				return string.Empty;
			}
			return string.Format("{0}{1}{2}", path, this.PathSeparator, fileName);
		}
	}
}