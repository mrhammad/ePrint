using System;
using System.Data;
using System.IO;

public class OLDDATA
{
	public OLDDATA()
	{
	}

	public DataTable GetDate(string FilePath)
	{
		DataSet dataSet = new DataSet();
		if (File.Exists(FilePath))
		{
			dataSet.ReadXml(FilePath);
		}
		if (dataSet.Tables.Count <= 0)
		{
			return null;
		}
		return dataSet.Tables[0];
	}
}