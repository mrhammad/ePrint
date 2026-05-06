using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

public class EprintConfigurationManager
{
    public EprintAppSettings AppSettings
    {
        get;
        private set;
    }

    public EprintConnectionStrings ConnectionStrings
    {
        get;
        private set;
    }

    public EprintConfigurationManager()
    {
        DataSet appSettingsAndConnectionString = this.GetAppSettingsAndConnectionString();
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
        this.AppSettings = new EprintAppSettings(strs);
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
        this.ConnectionStrings = new EprintConnectionStrings(strs1);
    }

    public DataSet GetAppSettingsAndConnectionString()
    {
        DataSet dataSet = new DataSet();
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
        string str = string.Concat("select * from tb_Template_AppSettings where ServerName='", TemplateEditorService.HostName, "'");
        str = string.Concat(str, ";  select * from tb_Template_ConnectionStrings where ServerName='", TemplateEditorService.HostName, "'");
        SqlCommand sqlCommand = new SqlCommand(str)
        {
            Connection = sqlConnection
        };
        sqlConnection.Open();
        (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
        sqlConnection.Close();
        return dataSet;
    }
}