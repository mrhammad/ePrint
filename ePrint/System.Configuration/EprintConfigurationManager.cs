using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web;

namespace System.Configuration
{
	public static class EprintConfigurationManager
	{
		public static EprintAppSettings AppSettings
		{
			get;
			private set;
		}

		public static EprintConnectionStrings ConnectionStrings
		{
			get;
			private set;
		}

		static EprintConfigurationManager()
		{
			DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
			DataTable item = appSettingsAndConnectionString.Tables[0];
			Dictionary<string, string> strs = new Dictionary<string, string>();
			DataRow dataRow = item.Rows[0];
			foreach (DataColumn column in item.Columns)
			{
				if (dataRow[column.ColumnName.ToString()].ToString().Length <= 0)
				{
					continue;
				}
				strs.Add(column.ColumnName.ToString().ToUpper(), dataRow[column.ColumnName.ToString()].ToString());
			}
			EprintConfigurationManager.AppSettings = new EprintAppSettings(strs);
			DataTable dataTable = appSettingsAndConnectionString.Tables[1];
			Dictionary<string, string> strs1 = new Dictionary<string, string>();
			DataRow item1 = dataTable.Rows[0];
			foreach (DataColumn dataColumn in dataTable.Columns)
			{
				if (item1[dataColumn.ColumnName.ToString()].ToString().Length <= 0)
				{
					continue;
				}
				strs1.Add(dataColumn.ColumnName.ToString().ToUpper(), item1[dataColumn.ColumnName.ToString()].ToString());
			}
			EprintConfigurationManager.ConnectionStrings = new EprintConnectionStrings(strs1);
		}

		public static DataSet GetAppSettingsAndConnectionString()
		{
			string str = HttpContext.Current.Request.Url.Host.ToString();
			if (str.Trim().ToLower() == "localhost" || str.Trim().ToLower() == "192.168.1.6")
			{
				str = ConfigurationManager.AppSettings["HostName"].ToString();
			}
			DataSet dataSet = new DataSet();
			SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
			string[] strArrays = new string[] { "select *  from tb_MIS_AppSettings where (HostName='", str, "') or (Host1='", str, "') or (Host2='", str, "') or (Host3='", str, "') or (Host4='", str, "') or (Host5='", str, "')" };
			string str1 = string.Concat(strArrays);
			string[] strArrays1 = new string[] { str1, ";  select * from tb_MIS_ConnectionStrings where (HostName='", str, "') or (Host1='", str, "') or (Host2='", str, "') or (Host3='", str, "') or (Host4='", str, "') or (Host5='", str, "')" };
			SqlCommand sqlCommand = new SqlCommand(string.Concat(strArrays1))
			{
				Connection = sqlConnection
			};
			sqlConnection.Open();
			(new SqlDataAdapter(sqlCommand)).Fill(dataSet);
			sqlConnection.Close();
			return dataSet;
		}
	}
}