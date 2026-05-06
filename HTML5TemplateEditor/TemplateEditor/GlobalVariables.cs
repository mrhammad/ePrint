using System;
using System.Runtime.CompilerServices;

namespace TemplateEditor
{
    public class GlobalVariables
    {
        public long CompanyID
        {
            get;
            set;
        }

        public static string ImageList
        {
            get;
            set;
        }

        public string imageUploadPath
        {
            get;
            set;
        }

        public static string SitePathPahysical
        {
            get;
            set;
        }

        public GlobalVariables()
        {
        }
    }
}