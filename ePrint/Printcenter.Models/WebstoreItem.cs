using System;

public class WebstoreItem
{
	private int _CompanyID;

	private string _PhraseType = string.Empty;

	private string _PhraseText = string.Empty;

	private bool _IsDefaultPhrase;

	private long _AccountID;

	private bool _IsDeleted;

	private int _PhraseBookID;

	public long AccountID
	{
		get
		{
			return this._AccountID;
		}
		set
		{
			this._AccountID = value;
		}
	}

	public int CompanyID
	{
		get
		{
			return this._CompanyID;
		}
		set
		{
			this._CompanyID = value;
		}
	}

	public bool IsDefaultPhrase
	{
		get
		{
			return this._IsDefaultPhrase;
		}
		set
		{
			this._IsDefaultPhrase = value;
		}
	}

	public bool IsDeleted
	{
		get
		{
			return this._IsDeleted;
		}
		set
		{
			this._IsDeleted = value;
		}
	}

	public int PhraseBookID
	{
		get
		{
			return this._PhraseBookID;
		}
		set
		{
			this._PhraseBookID = value;
		}
	}

	public string PhraseText
	{
		get
		{
			return this._PhraseText;
		}
		set
		{
			this._PhraseText = value;
		}
	}

	public string PhraseType
	{
		get
		{
			return this._PhraseType;
		}
		set
		{
			this._PhraseType = value;
		}
	}

	public WebstoreItem()
	{
	}
}