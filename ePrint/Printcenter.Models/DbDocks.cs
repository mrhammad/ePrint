using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

public class DbDocks
{
	public DbDocks()
	{
	}

	public virtual DataSet dock_View_Dock(int CompanyID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		return database.ExecuteDataSet(database.GetStoredProcCommand("dock_View_Dock"));
	}
}