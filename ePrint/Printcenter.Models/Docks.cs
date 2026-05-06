using System;
using System.Data;

public class Docks
{
	public Docks()
	{
	}

	public DataSet dock_View_Dock(int CompanyID)
	{
		return (new DbDocks()).dock_View_Dock(CompanyID);
	}
}