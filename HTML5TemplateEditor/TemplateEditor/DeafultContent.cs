using System;

namespace TemplateEditor
{
    public class DeafultContent
    {
        private string _Title;

        private string phraseid;

        public string PhraseID
        {
            get
            {
                return this.phraseid;
            }
            set
            {
                this.phraseid = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public DeafultContent()
        {
        }
    }
}