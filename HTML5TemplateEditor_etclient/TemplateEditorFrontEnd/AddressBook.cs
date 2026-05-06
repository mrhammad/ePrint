using System;

namespace TemplateEditorFrontEnd
{
	public class AddressBook
	{
		private string _Label;

		private string _Address;

		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this._Address = value;
			}
		}

		public string Label
		{
			get
			{
				return this._Label;
			}
			set
			{
				this._Label = value;
			}
		}

		public AddressBook()
		{
		}
	}
}