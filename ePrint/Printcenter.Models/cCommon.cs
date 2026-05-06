using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

public class cCommon
{
	public static Random random;

	static cCommon()
	{
		cCommon.random = new Random();
	}

	public cCommon()
	{
	}

	public static bool GeocodeAddress(GooglePoint GP, string GoogleAPIKey)
	{
		string str = string.Concat("http://maps.google.com/maps/geo?q=", GP.Address, "&output=xml&key=", GoogleAPIKey);
		WebRequest length = WebRequest.Create(str);
		length.Timeout = 10000;
		length.Method = "POST";
		byte[] bytes = Encoding.UTF8.GetBytes("This is a test that posts this string to a Web server.");
		length.ContentType = "application/x-www-form-urlencoded";
		length.ContentLength = (long)((int)bytes.Length);
		Stream requestStream = length.GetRequestStream();
		requestStream.Write(bytes, 0, (int)bytes.Length);
		requestStream.Close();
		requestStream = length.GetResponse().GetResponseStream();
		StringReader stringReader = new StringReader((new StreamReader(requestStream)).ReadToEnd());
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(stringReader);
		if (cCommon.GetIntegerValue(dataSet.Tables["Status"].Rows[0]["code"]) != 200)
		{
			return false;
		}
		string stringValue = cCommon.GetStringValue(dataSet.Tables["Point"].Rows[0]["coordinates"]);
		string[] strArrays = stringValue.Split(new char[] { ',' });
		if ((int)strArrays.Length > 1)
		{
			GP.Latitude = cCommon.GetNumericValue(strArrays[1]);
			GP.Longitude = cCommon.GetNumericValue(strArrays[0]);
		}
		if (dataSet.Tables["Placemark"] != null)
		{
			GP.Address = cCommon.GetStringValue(dataSet.Tables["Placemark"].Rows[0]["address"]);
		}
		if (dataSet.Tables["PostalCode"] != null)
		{
			GooglePoint gP = GP;
			gP.Address = string.Concat(gP.Address, " ", cCommon.GetStringValue(dataSet.Tables["PostalCode"].Rows[0]["PostalCodeNumber"]));
		}
		return true;
	}

	public static decimal GetFractional(decimal source)
	{
		return source % new decimal(10, 0, 0, false, 1);
	}

	public static string GetHttpURL()
	{
		string[] strArrays = HttpContext.Current.Request.Url.AbsoluteUri.Split(new char[] { '/' });
		string str = string.Concat(strArrays[0], "/");
		for (int i = 1; i < (int)strArrays.Length - 1; i++)
		{
			str = string.Concat(str, strArrays[i], "/");
		}
		return str;
	}

	public static decimal GetIntegerPart(decimal source)
	{
		return decimal.Parse(source.ToString("#.00"));
	}

	public static int GetIntegerValue(object pNumValue)
	{
		if (pNumValue == null)
		{
			return 0;
		}
		if (!cCommon.IsNumeric(pNumValue))
		{
			return 0;
		}
		return int.Parse(pNumValue.ToString());
	}

	public static string GetLocalPath()
	{
		string[] strArrays = HttpContext.Current.Request.Url.AbsoluteUri.Split(new char[] { '/' });
		string str = strArrays[(int)strArrays.Length - 1];
		strArrays = HttpContext.Current.Request.MapPath(str).Split(new char[] { '\\' });
		string str1 = string.Concat(strArrays[0], "\\");
		for (int i = 1; i < (int)strArrays.Length - 1; i++)
		{
			str1 = string.Concat(str1, strArrays[i], "\\");
		}
		return str1;
	}

	public static double GetNumericValue(object pNumValue)
	{
		if (pNumValue == null)
		{
			return 0;
		}
		if (!cCommon.IsNumeric(pNumValue))
		{
			return 0;
		}
		return double.Parse(pNumValue.ToString());
	}

	public static string GetStringValue(object obj)
	{
		if (obj == null)
		{
			return "";
		}
		if (obj == null)
		{
			return "";
		}
		if (obj == null)
		{
			return "";
		}
		return obj.ToString();
	}

	public static bool IsNumeric(object s)
	{
		bool flag;
		try
		{
			double.Parse(s.ToString());
			return true;
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	public static decimal RandomNumber(decimal min, decimal max)
	{
		decimal num = new decimal(10000000);
		int integerPart = (int)cCommon.GetIntegerPart(min * num);
		int integerPart1 = (int)cCommon.GetIntegerPart(max * num);
		return cCommon.random.Next(integerPart, integerPart1) / num;
	}
}