using nmsCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;

public class PieGraph : BaseClass
{
	private DataTable dtGraphData = new DataTable();

	private string GTitle;

	private string GColors;

	private string GWidth;

	private string GHeight;

	private string GTitleColor;

	private string GTitleSize;

	private List<Color> colorList;

	public DataTable dtData
	{
		set
		{
			this.dtGraphData = value;
		}
	}

	public string GraphColors
	{
		set
		{
			this.GColors = value;
		}
	}

	public string GraphHeight
	{
		set
		{
			this.GHeight = value;
		}
	}

	public string GraphTitle
	{
		set
		{
			this.GTitle = value;
		}
	}

	public string GraphTitleColor
	{
		set
		{
			this.GTitleColor = value;
		}
	}

	public string GraphTitleSize
	{
		set
		{
			this.GTitleSize = value;
		}
	}

	public string GraphWidth
	{
		set
		{
			this.GWidth = value;
		}
	}

	public PieGraph()
	{
	}

	public string ColorToHex(string color)
	{
		string str = string.Format("0x{0:X8}", color);
		str = string.Concat("#", str.Substring(str.Length - 6, 6));
		return str;
	}

	public string DrawPieGraph(string Graphheight, string Graphwidth, string Graphtitle, string SectionName)
	{
		DataTable dataTable = new DataTable();
		dataTable = this.GetGraphData(SectionName);
		PieGraph pieGraph = new PieGraph()
		{
			GraphHeight = Graphheight,
			GraphWidth = Graphwidth,
			GraphTitle = Graphtitle,
			GraphTitleColor = "112233",
			GraphTitleSize = "20",
			dtData = dataTable
		};
		return pieGraph.GenerateGraph();
	}

	public string GenerateGraph()
	{
		DataTable dataTable = new DataTable();
		dataTable = this.dtGraphData;
		int maxVal = this.GetMaxVal(dataTable);
		this.GColors = this.GetColorName(dataTable);
		string[] gTitleColor = new string[] { "http://chart.apis.google.com/chart?chts=", this.GTitleColor, ",", this.GTitleSize, "&chtt=", this.GTitle, "&chco=", this.GColors, "&cht=p3&chs=", this.GWidth, "x", this.GHeight };
		string str = string.Concat(gTitleColor);
		string str1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		string empty = string.Empty;
		string empty1 = string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder1 = new StringBuilder();
		stringBuilder.Append("&chd=s:");
		stringBuilder1.Append("&chl=");
		int length = str1.Length - 1;
		foreach (DataRow row in dataTable.Rows)
		{
			int num = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(row["iValue"])));
			int num1 = length * num / maxVal;
			stringBuilder.Append(str1.Substring(num1, 1));
			stringBuilder1.Append(string.Concat(row["iLabel"].ToString().Replace("&", "and"), "|"));
		}
		empty = stringBuilder.ToString();
		empty1 = stringBuilder1.ToString();
		empty1 = empty1.Substring(0, empty1.Length - 1);
		return string.Concat(str, empty, empty1);
	}

	private void GetColorList(string colorfull)
	{
		this.colorList = new List<Color>();
		string[] names = Enum.GetNames(typeof(KnownColor));
		for (int i = 0; i < (int)names.Length; i++)
		{
			string str = names[i];
			if (str.StartsWith("D"))
			{
				this.colorList.Add(Color.FromName(str));
			}
		}
	}

	public string GetColorName(DataTable dt)
	{
		this.GetColorList("color");
		string empty = string.Empty;
		int num = 0;
		foreach (DataRow row in dt.Rows)
		{
			int argb = this.colorList[num].ToArgb();
			empty = string.Concat(empty, this.ColorToHex(argb.ToString()).Replace("#", ""), ",");
			num++;
		}
		if (empty.Length > 2)
		{
			empty = empty.Substring(0, empty.Length - 1);
		}
		return empty;
	}

	private DataTable GetGraphData(string SectionName)
	{
		commonClass _commonClass = new commonClass();
		SqlCommand sqlCommand = new SqlCommand("Crm_generate_graph", _commonClass.openConnection());
		sqlCommand.Parameters.Add("@CompanyID", Convert.ToInt32(this.Session["companyID"]));
		sqlCommand.Parameters.Add("@UserID", Convert.ToInt32(this.Session["userID"]));
		sqlCommand.Parameters.Add("@SectionName", SectionName.Trim().ToLower());
		sqlCommand.Parameters.Add("@isAdmin", Convert.ToInt32(this.Session["admin"]));
		sqlCommand.CommandType = CommandType.StoredProcedure;
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		DataTable dataTable = new DataTable();
		dataTable.Load(sqlDataReader);
		sqlDataReader.Close();
		_commonClass.closeConnection();
		return dataTable;
	}

	public int GetMaxVal(DataTable dt)
	{
		int num = 0;
		int num1 = 0;
		foreach (DataRow row in dt.Rows)
		{
			num1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(row["iValue"])));
			if (num1 < num)
			{
				continue;
			}
			num = num1;
		}
		return num;
	}
}