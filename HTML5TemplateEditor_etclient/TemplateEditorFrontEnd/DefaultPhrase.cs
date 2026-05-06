using System;

namespace TemplateEditorFrontEnd
{
	public class DefaultPhrase
	{
		private string _Title;

		private string _Type;

		private string _phrasetext;

		private string _separtor;

		private string _labelSeparator;

		private int phraseid;

		public string LabelSeparator
		{
			get
			{
				return this._labelSeparator;
			}
			set
			{
				this._labelSeparator = value;
			}
		}

		public int PhraseID
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

		public string PhrasText
		{
			get
			{
				return this._phrasetext;
			}
			set
			{
				this._phrasetext = value;
			}
		}

		public string Seperator
		{
			get
			{
				return this._separtor;
			}
			set
			{
				this._separtor = value;
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

		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		public DefaultPhrase()
		{
		}
	}
}