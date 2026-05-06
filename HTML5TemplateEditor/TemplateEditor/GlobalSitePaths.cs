using System;

namespace TemplateEditor
{
    public class GlobalSitePaths
    {
        private GlobalVariables _ObjGlobalVariables = new GlobalVariables();

        public GlobalSitePaths()
        {
        }

        public Globals GetSitePaths(long companyID, string _key)
        {
            TemplateEditorService templateEditorService = new TemplateEditorService();
            Globals global = new Globals();
            Globals keyValuesForPath = templateEditorService.GetKeyValuesForPath(_key);
            global.FontPath = keyValuesForPath.FontPath;
            global.BackgroundImagesPath = string.Concat(keyValuesForPath.PdfImagePath, companyID.ToString(), "/Images/");
            global.WebMethodsPath = keyValuesForPath.BackendSitePath;
            global.SiteImages = string.Concat(keyValuesForPath.BackendSitePath, "StyleSheets/Images/");
            global.ImageUploadPath = keyValuesForPath.PdfImageUploadPath;
            global.ServicePath = string.Concat(keyValuesForPath.BackendSitePath, "TemplateEditorService.svc/");
            global.DBkey = _key;
            return global;
        }
    }
}