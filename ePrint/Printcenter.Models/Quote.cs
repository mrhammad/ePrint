using System;

public class Quote
{
	private string _stockTicker;

	private decimal _stockQuote;

	private DateTime _lastUpdated;

	private decimal _change;

	private decimal _dailyMinRange;

	private decimal _dailyMaxRange;

	public decimal Change
	{
		get
		{
			return this._change;
		}
		set
		{
			this._change = value;
		}
	}

	public decimal DailyMaxRange
	{
		get
		{
			return this._dailyMaxRange;
		}
		set
		{
			this._dailyMaxRange = value;
		}
	}

	public decimal DailyMinRange
	{
		get
		{
			return this._dailyMinRange;
		}
		set
		{
			this._dailyMinRange = value;
		}
	}

	public DateTime LastUpdated
	{
		get
		{
			return this._lastUpdated;
		}
		set
		{
			this._lastUpdated = value;
		}
	}

	public decimal StockQuote
	{
		get
		{
			return this._stockQuote;
		}
		set
		{
			this._stockQuote = value;
		}
	}

	public string StockTicker
	{
		get
		{
			return this._stockTicker;
		}
	}

	public Quote()
	{
	}

	public Quote(string _stockTicker, decimal _stockQuote, DateTime _lastUpdated, decimal _change, decimal _dailyMinRange, decimal _dailyMaxRange)
	{
		this._stockTicker = _stockTicker;
		this._stockQuote = _stockQuote;
		this._lastUpdated = _lastUpdated;
		this._change = _change;
		this._dailyMinRange = _dailyMinRange;
		this._dailyMaxRange = _dailyMaxRange;
	}
}