using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Xml;

[ScriptService]
[WebService(Namespace="http://tempuri.org/")]
[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
public class QuoteWebService : WebService
{
	private Random random;

	private string yahooFeedTemplate = "http://finance.yahoo.com/d/quotes.csv?s={0}&f=sl1d1t1c1ohgv&e=.csv";

	private string SessionQuotesData
	{
		get
		{
			return (string)HttpContext.Current.Session["TelerikAspAjaxGridApplication"];
		}
		set
		{
			HttpContext.Current.Session["TelerikAspAjaxGridApplication"] = value;
		}
	}

	public QuoteWebService()
	{
		this.random = new Random(DateTime.Now.Millisecond);
	}

	[Description("Gets DataSet of stock quote for a specific symbol")]
	[WebMethod]
	public DataSet GetDSOfStockQuotes()
	{
		string[] strArrays = "MSFT, YHOO, GOOG, HPQ, DELL, AAPL, NOVL".Split(new char[] { ',' });
		for (int i = 0; i <= (int)strArrays.Length - 1; i++)
		{
			strArrays[i] = strArrays[i].Trim();
		}
		List<Quote> quotes = new List<Quote>();
		if (this.SessionQuotesData == null)
		{
			string empty = string.Empty;
			WebResponse response = null;
			string[] strArrays1 = strArrays;
			for (int j = 0; j < (int)strArrays1.Length; j++)
			{
				string str = strArrays1[j];
				empty = string.Format(this.yahooFeedTemplate, HttpUtility.UrlEncode(str));
				response = WebRequest.Create(empty).GetResponse();
				quotes.Add(this.GetQuoteData(response.GetResponseStream()));
			}
		}
		else
		{
			quotes = this.GetQuotesData(this.SessionQuotesData);
			foreach (Quote quote in quotes)
			{
				this.ModifyQuote(quote);
			}
		}
		this.SerializeQuotesData(quotes);
		DataSet dataSet = new DataSet("QuotesDataSet");
		XmlReader xmlReader = XmlReader.Create(new StringReader(this.SessionQuotesData));
		dataSet.ReadXml(xmlReader);
		return dataSet;
	}

	[Description("Gets list of stock quote for a specific symbol")]
	[WebMethod(EnableSession=true)]
	public List<Quote> GetListOfStockQuotes()
	{
		string[] strArrays = "MSFT, YHOO, GOOG, HPQ, DELL, AAPL, NOVL".Split(new char[] { ',' });
		for (int i = 0; i <= (int)strArrays.Length - 1; i++)
		{
			strArrays[i] = strArrays[i].Trim();
		}
		List<Quote> quotes = new List<Quote>();
		if (this.SessionQuotesData == null)
		{
			string empty = string.Empty;
			WebResponse response = null;
			string[] strArrays1 = strArrays;
			for (int j = 0; j < (int)strArrays1.Length; j++)
			{
				string str = strArrays1[j];
				empty = string.Format(this.yahooFeedTemplate, HttpUtility.UrlEncode(str));
				response = WebRequest.Create(empty).GetResponse();
				quotes.Add(this.GetQuoteData(response.GetResponseStream()));
			}
		}
		else
		{
			quotes = this.GetQuotesData(this.SessionQuotesData);
			foreach (Quote quote in quotes)
			{
				this.ModifyQuote(quote);
			}
		}
		this.SerializeQuotesData(quotes);
		return quotes;
	}

	private Quote GetQuote(string[] bufferList)
	{
		string str = bufferList[0];
		decimal num = decimal.Parse(bufferList[1], CultureInfo.InvariantCulture);
		DateTime dateTime = DateTime.Parse(string.Concat(bufferList[2], " ", bufferList[3]), CultureInfo.InvariantCulture);
		decimal num1 = decimal.Parse(bufferList[4], CultureInfo.InvariantCulture);
		decimal num2 = new decimal(0);
		if (bufferList[6] != "N/A")
		{
			num2 = decimal.Parse(bufferList[6], CultureInfo.InvariantCulture);
		}
		decimal num3 = new decimal(0);
		if (bufferList[7] != "N/A")
		{
			num3 = decimal.Parse(bufferList[7], CultureInfo.InvariantCulture);
		}
		return new Quote(str, num, dateTime, num1, num3, num2);
	}

	private Quote GetQuote(XmlNode quoteNode)
	{
		string value = quoteNode.Attributes["stockTicker"].Value;
		decimal num = decimal.Parse(quoteNode.Attributes["lastTrade"].Value, CultureInfo.InvariantCulture);
		DateTime dateTime = DateTime.Parse(quoteNode.Attributes["lastUpdated"].Value, CultureInfo.InvariantCulture);
		decimal num1 = decimal.Parse(quoteNode.Attributes["change"].Value, CultureInfo.InvariantCulture);
		decimal num2 = (quoteNode.Attributes["dailyMaxRange"].Value == "N/A" ? new decimal(0) : decimal.Parse(quoteNode.Attributes["dailyMaxRange"].Value, CultureInfo.InvariantCulture));
		return new Quote(value, num, dateTime, num1, (quoteNode.Attributes["dailyMinRange"].Value == "N/A" ? new decimal(0) : decimal.Parse(quoteNode.Attributes["dailyMinRange"].Value, CultureInfo.InvariantCulture)), num2);
	}

	private Quote GetQuoteData(Stream dataStream)
	{
		string end = null;
		StreamReader streamReader = new StreamReader(dataStream);
		try
		{
			end = streamReader.ReadToEnd();
		}
		finally
		{
			streamReader.Dispose();
		}
		end = end.Replace("\"", "");
		char[] chrArray = new char[] { ',' };
		return this.GetQuote(end.Split(chrArray));
	}

	private List<Quote> GetQuotesData(string xmlData)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlData);
		List<Quote> quotes = new List<Quote>();
		foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
		{
			quotes.Add(this.GetQuote(childNode));
		}
		return quotes;
	}

	[WebMethod]
	public string HelloWorld()
	{
		return "Hello World";
	}

	private void ModifyQuote(Quote quote)
	{
		decimal stockQuote = quote.StockQuote;
		decimal num = (decimal)((double)this.random.NextDouble());
		if (num != new decimal(0))
		{
			num = decimal.Round(num, this.random.Next(1, 5));
		}
		if (stockQuote > num && this.random.NextDouble() <= 0.5)
		{
			num = -num;
		}
		quote.Change = num;
		Quote stockQuote1 = quote;
		stockQuote1.StockQuote = stockQuote1.StockQuote + num;
		quote.LastUpdated = DateTime.Now;
		if (quote.StockQuote < quote.DailyMinRange)
		{
			quote.DailyMinRange = quote.StockQuote;
		}
		else if (quote.StockQuote > quote.DailyMaxRange)
		{
			quote.DailyMaxRange = quote.StockQuote;
		}
		if (quote.DailyMinRange == new decimal(0))
		{
			quote.DailyMinRange = quote.StockQuote;
		}
	}

	private void SerializeQuotesData(List<Quote> quotes)
	{
		StringBuilder stringBuilder = new StringBuilder("<quotes>");
		try
		{
			foreach (Quote quote in quotes)
			{
				stringBuilder.Append("<quote ");
				stringBuilder.Append(string.Concat("stockTicker=\"", quote.StockTicker, "\" "));
				decimal stockQuote = quote.StockQuote;
				stringBuilder.Append(string.Concat("lastTrade=\"", stockQuote.ToString(CultureInfo.InvariantCulture), "\" "));
				decimal change = quote.Change;
				stringBuilder.Append(string.Concat("change=\"", change.ToString(CultureInfo.InvariantCulture), "\" "));
				DateTime lastUpdated = quote.LastUpdated;
				stringBuilder.Append(string.Concat("lastUpdated=\"", lastUpdated.ToString("MM/dd/yyyy HH:mm:ss"), "\" "));
				decimal dailyMaxRange = quote.DailyMaxRange;
				stringBuilder.Append(string.Concat("dailyMaxRange=\"", dailyMaxRange.ToString(CultureInfo.InvariantCulture), "\" "));
				decimal dailyMinRange = quote.DailyMinRange;
				stringBuilder.Append(string.Concat("dailyMinRange=\"", dailyMinRange.ToString(CultureInfo.InvariantCulture), "\" "));
				stringBuilder.Append(" />");
			}
		}
		catch (Exception exception)
		{
		}
		stringBuilder.Append("</quotes>");
		this.SessionQuotesData = stringBuilder.ToString();
	}
}