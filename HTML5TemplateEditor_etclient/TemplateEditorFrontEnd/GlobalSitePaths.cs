using System;

namespace TemplateEditorFrontEnd
{
	public class GlobalSitePaths
	{
		public GlobalSitePaths()
		{
		}

		public Globals GetSitePaths(long companyID, string _key)
		{
			TemplateEditorFrontEndSevice templateEditorFrontEndSevice = new TemplateEditorFrontEndSevice();
			Globals global = new Globals();
			Globals keyValuesForPath = templateEditorFrontEndSevice.GetKeyValuesForPath(_key);
			global.FontPath = keyValuesForPath.FontPath;
			global.BackgroundImagesPath = string.Concat(keyValuesForPath.PdfImagePath, companyID.ToString(), "/Images/");
			global.WebMethodsPath = string.Concat(keyValuesForPath.FrontEndSitePath, "editabletemplate.aspx/");
			global.SiteImages = string.Concat(keyValuesForPath.FrontEndSitePath, "StyleSheets/Images/");
			global.ImageUploadPath = keyValuesForPath.PdfImageUploadPath;
			global.FrontEndUploadPath = keyValuesForPath.FrontEndUploadPath;
			global.FrontEndDocumentPath = keyValuesForPath.FrontEndDocumentPath;
			global.FrontEndImagePath = keyValuesForPath.FrontEndSitePath;
			global.DBkey = _key;
			global.ServicePath = string.Concat(keyValuesForPath.FrontEndSitePath, "TemplateEditorFrontEndSevice.svc/");
			global.PublicSitePath = keyValuesForPath.PublicSitePath;
			global.B2BSitePath = keyValuesForPath.B2BSitePath;
			global.PDFAPIPath = keyValuesForPath.PDFAPIPath;
			global.SecurePath = keyValuesForPath.SecurePath;
			return global;
		}
	}
}