using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TemplateEditor
{
    public class ImageGalleryParentResponse
    {
        public IList<ImageCategory> ImageCategories
        {
            get;
            set;
        }

        public IList<ImageCategory> ImageGallery
        {
            get;
            set;
        }

        public long ParentID
        {
            get;
            set;
        }

        public ImageGalleryParentResponse()
        {
        }
    }
}