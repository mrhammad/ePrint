using Microsoft.VisualBasic.FileIO;
using Spire.Xls;
using Spire.Xls.Collections;
using Spire.Xls.Core.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

public class Import
{
	public Import()
	{
	}

	public static DataSet ConnectFile(string filename, string FilePath)
	{
		Workbook workbook;
		Worksheet sheet;
		int counter;
		DataSet dataSet;
		DataSet ds = new DataSet();
		try
		{
			string fileextension = Path.GetExtension(filename);
			if (fileextension.ToLower() == ".csv")
			{
				workbook = new Workbook();
				workbook.LoadFromFile(string.Concat(FilePath, filename), ",");
				sheet = workbook.Worksheets[0];
				counter = 1;
				ds.Tables.Add(sheet.ExportDataTable());
				dataSet = ds;
			}
			else if (fileextension.ToLower() == ".xls")
			{
				workbook = new Workbook();
				workbook.LoadFromFile(string.Concat(FilePath, filename), ExcelVersion.Version97to2003);
				sheet = workbook.Worksheets[0];
				ds.Tables.Add(sheet.ExportDataTable());
				dataSet = ds;
			}
			else if (fileextension.ToLower() == ".xlsx")
			{
				workbook = new Workbook();
				workbook.LoadFromFile(string.Concat(FilePath, filename), ExcelVersion.Version2007);
				sheet = workbook.Worksheets[0];
				ds.Tables.Add(sheet.ExportDataTable());
				dataSet = ds;
			}
			else if (!(fileextension.ToLower() == ".xlsm"))
			{
				dataSet = ds;
				return dataSet;
			}
			else
			{
				workbook = new Workbook();
				workbook.LoadFromFile(string.Concat(FilePath, filename), ExcelVersion.Version2010);
				sheet = workbook.Worksheets[0];
				counter = 1;
				CellRange[] columns = sheet.Columns;
				for (int i = 0; i < (int)columns.Length; i++)
				{
					CellRange cl = columns[i];
					Guid guid = Guid.NewGuid();
					sheet.SetCellValue(1, counter, guid.ToString().Substring(0, 10));
					counter++;
				}
				ds.Tables.Add(sheet.ExportDataTable());
				dataSet = ds;
			}
		}
		catch (Exception exception)
		{
			Exception ex = exception;
			ds = null;
			throw ex;
		}
		return dataSet;
	}

	public static DataTable ConnectFileNew(string filename, string FilePath)
	{
		List<string[]> fileContent = new List<string[]>();
		FileStream reader = File.OpenRead(string.Concat(FilePath, filename));
		try
		{
			TextFieldParser parser = new TextFieldParser(reader);
			try
			{
				parser.TrimWhiteSpace = true;
				parser.Delimiters = new string[] { "," };
				parser.HasFieldsEnclosedInQuotes = true;
				while (!parser.EndOfData)
				{
					fileContent.Add(parser.ReadFields());
				}
			}
			finally
			{
				if (parser != null)
				{
					((IDisposable)parser).Dispose();
				}
			}
		}
		finally
		{
			if (reader != null)
			{
				((IDisposable)reader).Dispose();
			}
		}
		return Import.ConvertListToDataTable(fileContent);
	}

	public static DataTable ConvertListToDataTable(List<string[]> list)
	{
		//string[] array = null;
		DataTable table = new DataTable();
		int columns = 0;
		foreach (string[] array in list)
		{
			if ((int)array.Length > columns)
			{
				columns = (int)array.Length;
				break;
			}
		}
		int count = 0;
		foreach (string[] strArrays in list)
		{
			if (count == 0)
			{
				for (int i = 0; i < columns; i++)
				{
					table.Columns.Add(strArrays[i].ToString());
				}
			}
			if (count > 0)
			{
				table.Rows.Add(strArrays);
			}
			count++;
		}
		return table;
	}

	public static DataSet ImportFromTextFile(string File, string TableName, string delimiter)
	{
		int num;
		DataSet result = new DataSet();
		StreamReader s = new StreamReader(File);
		string[] columns = s.ReadLine().Split(delimiter.ToCharArray());
		result.Tables.Add(TableName);
		string[] strArrays = columns;
		for (num = 0; num < (int)strArrays.Length; num++)
		{
			string col = strArrays[num];
			bool added = false;
			string next = "";
			int i = 0;
			while (!added)
			{
				string columnname = string.Concat(col, next);
				columnname = columnname.Replace("#", "");
				columnname = columnname.Replace("'", "");
				columnname = columnname.Replace("&", "");
				if (result.Tables[TableName].Columns.Contains(columnname))
				{
					i++;
					next = string.Concat("_", i.ToString());
				}
				else
				{
					result.Tables[TableName].Columns.Add(columnname);
					added = true;
				}
			}
		}
		string[] rows = s.ReadToEnd().Split("\r\n".ToCharArray());
		int errorinline = 0;
		strArrays = rows;
		for (num = 0; num < (int)strArrays.Length; num++)
		{
			string r = strArrays[num];
			if (r.Trim().Length > 0)
			{
				string[] items = r.Split(delimiter.ToCharArray());
				try
				{
					result.Tables[TableName].Rows.Add(items);
				}
				catch
				{
					Console.WriteLine(string.Concat("error at line no ", errorinline.ToString(), "\n"));
				}
			}
			errorinline++;
		}
		s.Close();
		s.Dispose();
		return result;
	}

	public static DataTable ToDataTable<T>(List<T> items)
	{
		DataTable dataTable = new DataTable(typeof(T).Name);
		PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
		PropertyInfo[] propertyInfoArray = Props;
		for (int num = 0; num < (int)propertyInfoArray.Length; num++)
		{
			PropertyInfo prop = propertyInfoArray[num];
			dataTable.Columns.Add(prop.Name);
		}
		foreach (T item in items)
		{
			object[] values = new object[(int)Props.Length];
			for (int i = 0; i < (int)Props.Length; i++)
			{
				values[i] = Props[i].GetValue(item, null);
			}
			dataTable.Rows.Add(values);
		}
		return dataTable;
	}
}