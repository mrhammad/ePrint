using Printcenter.BusinessAccessLayer;
using System;

namespace HelpSystem.BusinessAccessLayer
{
	public class HelpItems : BaseItem
	{
		private int _IssueID;

		private string _Subject = string.Empty;

		private string _IssueDesc = string.Empty;

		private int _BrowserID;

		private string _File1 = string.Empty;

		private string _File2 = string.Empty;

		private string _File3 = string.Empty;

		private string _File4 = string.Empty;

		private string _Version = string.Empty;

		public int BrowserID
		{
			get
			{
				return this._BrowserID;
			}
			set
			{
				this._BrowserID = value;
			}
		}

		public string File1
		{
			get
			{
				return this._File1;
			}
			set
			{
				this._File1 = value;
			}
		}

		public string File2
		{
			get
			{
				return this._File2;
			}
			set
			{
				this._File2 = value;
			}
		}

		public string File3
		{
			get
			{
				return this._File3;
			}
			set
			{
				this._File3 = value;
			}
		}

		public string File4
		{
			get
			{
				return this._File4;
			}
			set
			{
				this._File4 = value;
			}
		}

		public string IssueDesc
		{
			get
			{
				return this._IssueDesc;
			}
			set
			{
				this._IssueDesc = value;
			}
		}

		public int IssueID
		{
			get
			{
				return this._IssueID;
			}
			set
			{
				this._IssueID = value;
			}
		}

		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				this._Subject = value;
			}
		}

		public string Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				this._Version = value;
			}
		}

		public HelpItems()
		{
		}
	}
}