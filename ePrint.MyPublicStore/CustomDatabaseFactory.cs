using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.Common;

public static class CustomDatabaseFactory
{
	private readonly static DbProviderFactory dbProviderFactory;

	static CustomDatabaseFactory()
	{
		CustomDatabaseFactory.dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
	}

	public static Database CreateDatabase(string connectionString)
	{
		return new GenericDatabase(connectionString, CustomDatabaseFactory.dbProviderFactory);
	}
}