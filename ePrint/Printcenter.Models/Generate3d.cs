using nmsCommon;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtChart;

public class Generate3d : BaseClass
{
	private bool[] myexpload;

	public Generate3d()
	{
	}

	private void GenerateChart(string strHeading, string strValues, string strLinks, string strExpload, Image img1)
	{
		char[] charArray = "()".ToCharArray();
		char[] chrArray = ",".ToCharArray();
		strHeading = strHeading.Trim(charArray);
		strValues = strValues.Trim(charArray);
		strLinks = strLinks.Trim(charArray);
		strExpload = strExpload.Trim(charArray);
		string[] strArrays = strHeading.Split(chrArray);
		string[] strArrays1 = strValues.Split(chrArray);
		strLinks.Split(chrArray);
		string[] strArrays2 = strExpload.Split(chrArray);
		this.myexpload = new bool[(int)strArrays2.Length];
		for (int i = 0; i < (int)strArrays2.Length - 1; i++)
		{
			this.myexpload[i] = Convert.ToBoolean(strArrays2[i]);
		}
		float[] singleArray = new float[(int)strArrays1.Length];
		for (int j = 0; j <= (int)strArrays1.Length - 1; j++)
		{
			singleArray[j] = (float)double.Parse(strArrays1[j]);
		}
		pieChartData pieChartDatum = new pieChartData(singleArray, strArrays, this.myexpload)
		{
			pieDia = ushort.Parse("300"),
			ExploadOffset = byte.Parse("20")
		};
		object[] objArray = new object[] { "pieChartServer.aspx?Legends=(", strHeading, ")&Vals=(", strValues, ")&Expload=(", strExpload, ")&pieDia=", pieChartDatum.pieDia, "&EoffSet=", pieChartDatum.ExploadOffset };
		img1.ImageUrl = string.Concat(objArray);
	}

	public void Get3dPieChartData(string sectionname, Image img1)
	{
		DataTable graphData = this.GetGraphData(sectionname);
		string str = "";
		string str1 = "";
		string str2 = "";
		string str3 = "";
		int maxVal = this.GetMaxVal(graphData);
		foreach (DataRow row in graphData.Rows)
		{
			str = string.Concat(str, row["iLabel"].ToString().Replace("/", "-").Replace("#", ""), ",");
			str1 = string.Concat(str1, row["iValue"].ToString(), ",");
			str2 = string.Concat(str2, ",");
			str3 = (maxVal != Convert.ToInt32(Math.Ceiling(Convert.ToDouble(row["iValue"]))) ? string.Concat(str3, "False,") : string.Concat(str3, "True,"));
		}
		if (str.Length > 3)
		{
			str = str.Substring(0, str.Length - 1);
			str1 = str1.Substring(0, str1.Length - 1);
			str2 = str2.Substring(0, str2.Length - 1);
			str3 = str3.Substring(0, str3.Length - 1);
		}
		this.GenerateChart(str, str1, str2, str3, img1);
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