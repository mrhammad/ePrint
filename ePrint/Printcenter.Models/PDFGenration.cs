using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class PDFGenration : WebService
{
    public PDFGenration()
    {
    }

    [WebMethod(EnableSession = true)]
    public void GenratePDF(long Main_EstimateID, long Main_jobID, long Main_InvoiceID, string Main_jID, string Main_invid, string Main_PageType, string Main_PDFKey, string Main_IsFrom, string Main_isdirect, long Main_temp_ordid, long Main_OrdID, long Main_TemplateID, long Main_EstimateItemID, long Main_CompanyID, long Main_UserID, ref bool Main_RetRefforPDFVisible, ref ArrayList Main_ArryList_StrFileName, ref bool Main_RetRefforisFromReport)
    {
        pdfGenerate _pdfGenerate = new pdfGenerate();
        _pdfGenerate.MainFunction(Main_EstimateID, Main_jobID, Main_InvoiceID, Main_jID, Main_invid, Main_PageType, Main_PDFKey, Main_IsFrom, Main_isdirect, Main_temp_ordid, Main_OrdID, Main_TemplateID, Main_EstimateItemID, Main_CompanyID, Main_UserID, ref Main_RetRefforPDFVisible, ref Main_ArryList_StrFileName, ref Main_RetRefforisFromReport);
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(EnableSession = true)]
    public void Send_BulkEmail_Insert(long EstimateID, string ModuleName, string EmailGroupID)
    {
        commonClass _commonClass = new commonClass();
        BaseClass baseClass = new BaseClass();
        int num = 0;
        int num1 = 0;
        if (base.Session["UserID"] == null || base.Session["CompanyID"] == null || base.Session["UserID"] == null || base.Session["CompanyID"] == null || base.Session["UserID"] == null || base.Session["CompanyID"] == null)
        {
            baseClass.Session_Check();
        }
        num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        num1 = Convert.ToInt32(HttpContext.Current.Session["CompanyID"]);
        Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
        DbCommand storedProcCommand = database.GetStoredProcCommand("PC_BulkPDFGenration_Insert_Update");
        database.AddInParameter(storedProcCommand, "@ID", DbType.Int32, 0);
        database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, num);
        database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, num1);
        database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, EstimateID);
        database.AddInParameter(storedProcCommand, "@ModuleName", DbType.String, ModuleName);
        database.AddInParameter(storedProcCommand, "@EmailGroupID", DbType.String, EmailGroupID);
        DateTime now = DateTime.Now;
        database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), num1, num, true));
        database.AddInParameter(storedProcCommand, "@IsEmailSend", DbType.Int64, 0);
        database.AddInParameter(storedProcCommand, "@Message", DbType.String, "");
        database.ExecuteNonQuery(storedProcCommand);
    }
}