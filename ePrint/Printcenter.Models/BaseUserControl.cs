using nmsCommon;
using nmsLanguage;
using nmsLogin;
using System;
using System.Web.SessionState;
using System.Web.UI;

public class BaseUserControl : UserControl
{
	public languageClass objLanguage = new languageClass();

	public static string ExportReport;

	private loginClass login = new loginClass();

	public string tabcolor = "";

	public int companyid;

	public BasePage objpage = new BasePage();

	public string Padding;

	public string rtn;

	public string strSitepath = global.sitePath();

	public string strImagepath = global.imagePath();

	public string strFilepath = global.filePath();

	static BaseUserControl()
	{
		BaseUserControl.ExportReport = string.Empty;
	}

	public BaseUserControl()
	{
	}

	public string ApplyTimeZone(string date)
	{
		double num = Convert.ToDouble(global.ServerTimeZoneOrderNumber());
		int num1 = Convert.ToInt32(global.AdjustableNumber());
		double num2 = Convert.ToDouble(base.Session["TimeZoneOrderNumber"]);
		double num3 = 0;
		double num4 = 0;
		if (num > num2)
		{
			double num5 = num2 - num;
			string[] strArrays = num5.ToString("N2").ToString().Split(new char[] { '.' });
			num3 = Convert.ToDouble(strArrays[0]);
			num4 = Convert.ToDouble(strArrays[1]);
			if (num4 < -30)
			{
				num4 = -30;
			}
		}
		else if (num >= num2)
		{
		}
		else
		{
			double num6 = num2 - num;
			string[] strArrays1 = num6.ToString("N2").ToString().Split(new char[] { '.' });
			num3 = Convert.ToDouble(strArrays1[0]);
			num4 = Convert.ToDouble(strArrays1[1]);
			if (num4 > 30)
			{
				num4 = 30;
			}
		}
		if (num1 != 0)
		{
			num3 = num3 - (double)num1;
		}
		DateTime dateTime = Convert.ToDateTime(date);
		dateTime = dateTime.AddHours(num3);
		dateTime = dateTime.AddMinutes(num4);
		dateTime = dateTime.AddSeconds(0);
		return dateTime.ToString();
	}

	public string ReplaceSingleQuote(string OriginalString)
	{
		return OriginalString.Replace("'", "`");
	}
}