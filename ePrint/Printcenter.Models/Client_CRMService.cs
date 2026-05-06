using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Data;
using System.Data.Common;

public class Client_CRMService : IClient_CRMService
{
	public Client_CRMService()
	{
	}

	public void ClientNotesAdd(string CompanyID, string SectionName, string SectionID, string FileName, string FileSize, string CreateUserID, string Subject, string Title)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("crm_Notes_add");
		database.AddInParameter(storedProcCommand, "@companyId", DbType.Int32, Convert.ToInt32(CompanyID));
		database.AddInParameter(storedProcCommand, "@sectionname", DbType.String, SectionName);
		database.AddInParameter(storedProcCommand, "@sectionid", DbType.Int32, Convert.ToInt32(SectionID));
		database.AddInParameter(storedProcCommand, "@filename", DbType.String, FileName);
		database.AddInParameter(storedProcCommand, "@filesize", DbType.String, FileSize);
		database.AddInParameter(storedProcCommand, "@createUserId", DbType.Int32, Convert.ToInt32(CreateUserID));
		database.AddInParameter(storedProcCommand, "@subject", DbType.String, Subject);
		database.AddInParameter(storedProcCommand, "@title", DbType.String, Title);
		database.ExecuteNonQuery(storedProcCommand);
	}
}