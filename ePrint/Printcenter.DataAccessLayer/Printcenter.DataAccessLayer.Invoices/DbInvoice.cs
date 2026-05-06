using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;

namespace Printcenter.DataAccessLayer.Invoices
{
    public class DbInvoice
    {
        public DbInvoice()
        {
        }

        public virtual string Check_Invoice_PaymentType(long EstimateID)
        {
            string str;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentType_Check");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            try
            {
                str = (string)database.ExecuteScalar(storedProcCommand);
            }
            catch
            {
                str = "";
            }
            return str;
        }

        public virtual bool CheckAllocationExist(long JobID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CheckAllocationExist");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@AllocationExist", DbType.Boolean, 0);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual bool CheckInvoicePossible(long JobID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_CheckInvoicePossible");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddOutParameter(storedProcCommand, "@IsInvoicePossible", DbType.Boolean, 0);
            return (bool)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void copy_invoice(int CompanyID, long Old_EstimateID, long New_EstimateID, bool IsHandy)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_copy_invoice");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Old_EstimateID", DbType.Int64, Old_EstimateID);
            database.AddInParameter(storedProcCommand, "@New_EstimateID", DbType.Int64, New_EstimateID);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void EstimateItems_ProgressToInvoice(long EstimateItemID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItems_ProgressToInvoice");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int32, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable EstimateItems_Type_PriceCatalogue_Invoice_Select(long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItems_Type_PriceCatalogue_Invoice_Select");
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual long From_InvoiceID_Select_EstimateID(long InvoieID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("SELECT EstimateID FROM tb_Invoice WHERE Invoiceid =", InvoieID));
            long num = (long)database.ExecuteScalar(sqlStringCommand);
            return (long)database.ExecuteScalar(sqlStringCommand);
        }

        public virtual int Get_PaymentDetails_From_EstimateID(long EstimateID)
        {
            int num;
            object obj;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("SELECT CustomerID from tb_Estimate where Estimateid = ", EstimateID));
            object obj1 = database.ExecuteScalar(sqlStringCommand);
            if (obj1 == null)
            {
                obj = null;
            }
            else
            {
                obj = int.Parse(obj1.ToString());
            }
            //long num1 = (long)obj;
            long num1 = Convert.ToInt64(obj);
            sqlStringCommand = database.GetStoredProcCommand("PC_PaymentTermDays_Select");
            database.AddInParameter(sqlStringCommand, "@ClientID", DbType.Int64, num1);
            try
            {
                num = (int)database.ExecuteScalar(sqlStringCommand);
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public virtual DataTable GetClientDefaultInvoiceDetails(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetClientDefaultInvoiceDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable GetInvoiceAddressDetails(int CompanyID, int ClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_GetInvoiceAddressDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Insert_InvoicePaymentDetails(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_InvoicePaymentDetails");
            database.AddInParameter(storedProcCommand, "@invoiceID", DbType.Int64, invoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Insert_InvoicePaymentDetails_Main(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InsertInvoicePaymentDetails");
            database.AddInParameter(storedProcCommand, "@invoiceID", DbType.Int64, invoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Insert_InvoicePaymentDetailsForEstore(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoicePaymentDetails_Forestore");
            database.AddInParameter(storedProcCommand, "@invoiceID", DbType.Int64, invoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable invoice_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_advance_search");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable invoice_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_advance_search_SplitItems");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@SearchText", DbType.String, SearchText);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@FromDate", DbType.String, FromDate);
            database.AddInParameter(storedProcCommand, "@ToDate", DbType.String, ToDate);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
            database.AddInParameter(storedProcCommand, "@TodayDate", DbType.String, TodayDate);
            database.AddInParameter(storedProcCommand, "@StartDate", DbType.String, StartDate);
            database.AddInParameter(storedProcCommand, "@EndDate", DbType.String, EndDate);
            database.AddInParameter(storedProcCommand, "@SalesPersonRecords", DbType.String, SalesPersonRecords);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable invoice_advance_search_top5(int CompanyID, int ClientID, string Status, string DateType, bool IsArchived)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_advance_search_top5");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int32, ClientID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.String, Status);
            database.AddInParameter(storedProcCommand, "@DateType", DbType.String, DateType);
            database.AddInParameter(storedProcCommand, "@IsArchived", DbType.Boolean, IsArchived);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Invoice_Archive(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_archive");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Invoice_Comments_Update(int commentId, string newComment)
        {
            commonClass _commonClass = new commonClass();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_Comments_Update");
            database.AddInParameter(storedProcCommand, "@commentId", DbType.Int32, commentId);
            database.AddInParameter(storedProcCommand, "@newComment", DbType.String, newComment);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Invoice_Exported(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_Exported");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Invoice_Unexported(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_Unexported");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Invoice_Delete(int CompanyID, long InvoiceID, bool Keep_EstimateJOB_LIVE)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int64, num);
            database.AddInParameter(storedProcCommand, "@KeepEstimateJobLive", DbType.Boolean, Keep_EstimateJOB_LIVE);
            DateTime now = DateTime.Now;
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, _commonClass.Eprint_return_ActualDate_Before_View(now.ToString(), CompanyID, num, true));
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual long Invoice_insert(int CompanyID, long EstID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID, DateTime InvoiceDueDate, long Job_ID, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_insert");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstID", DbType.Int64, EstID);
            database.AddInParameter(storedProcCommand, "@InvoiceNumber", DbType.String, InvoiceNumber);
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@ConvertedDate", DbType.DateTime, ConvertedDate);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ConvertedBy", DbType.Int32, ConvertedBy);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@Ispaid", DbType.Int32, Ispaid);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int32, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressType", DbType.String, InvoiceAddressType);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressClientID", DbType.Int32, InvoiceAddressClientID);
            database.AddInParameter(storedProcCommand, "@InvoiceDueDate", DbType.DateTime, InvoiceDueDate);
            database.AddInParameter(storedProcCommand, "@Job_ID", DbType.Int32, Job_ID);
            database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, Convert.ToInt32(HttpContext.Current.Session["UserID"]));
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual int invoice_insert_ispaid(int CompanyID, long EstID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_insert_ispaid");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstID", DbType.Int64, EstID);
            database.AddInParameter(storedProcCommand, "@InvoiceNumber", DbType.String, InvoiceNumber);
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@ConvertedDate", DbType.DateTime, ConvertedDate);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ConvertedBy", DbType.Int32, ConvertedBy);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@Ispaid", DbType.Int32, Ispaid);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int32, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressType", DbType.String, InvoiceAddressType);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressClientID", DbType.String, InvoiceAddressClientID);
            database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, Convert.ToInt32(HttpContext.Current.Session["UserID"]));
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        public virtual long Invoice_insert_SplitItems(int CompanyID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID, DateTime InvoiceDueDate, long ClientID, long ContactID, long SalespersonID, string InvoiceTitle, bool IsArchive, string CustomerOrdNo)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_insert_SplitItems");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceNumber", DbType.String, InvoiceNumber);
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@ConvertedDate", DbType.DateTime, ConvertedDate);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddInParameter(storedProcCommand, "@CreatedBy", DbType.Int32, CreatedBy);
            database.AddInParameter(storedProcCommand, "@ConvertedBy", DbType.Int32, ConvertedBy);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@Ispaid", DbType.Int32, Ispaid);
            database.AddInParameter(storedProcCommand, "@IsHandy", DbType.Boolean, IsHandy);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int32, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressType", DbType.String, InvoiceAddressType);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressClientID", DbType.Int32, InvoiceAddressClientID);
            database.AddInParameter(storedProcCommand, "@InvoiceDueDate", DbType.DateTime, InvoiceDueDate);
            database.AddInParameter(storedProcCommand, "@InvoicePrefix", DbType.String, ConnectionClass.InvoicePrefix);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            database.AddInParameter(storedProcCommand, "@UserID", DbType.Int32, Convert.ToInt32(HttpContext.Current.Session["UserID"]));
            database.AddInParameter(storedProcCommand, "@SalespersonID", DbType.Int64, SalespersonID);
            database.AddInParameter(storedProcCommand, "@InvoiceTitle", DbType.String, InvoiceTitle);
            database.AddInParameter(storedProcCommand, "@IsArchive", DbType.Boolean, IsArchive);
            database.AddInParameter(storedProcCommand, "@CustomerOrderNumber", DbType.String, CustomerOrdNo);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual long invoice_InvoiceID_select(int CompanyID, long EstimateID, string Type)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_InvoiceID_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            return (long)database.ExecuteScalar(storedProcCommand);
        }

        public virtual void invoice_isexported_update(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_isexported_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void invoice_job_estimate_isconv_update(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_job_estimate_isconv_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable Invoice_JobDetails_SelectByInvoiceID(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_JobDetails_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Invoiceid", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataSet invoice_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            string str = EprintConfigurationManager.ConnectionStrings["CRMConnectionString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("PC_invoice_PageText", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            sqlCommand.Parameters.AddWithValue("@PageSize", PageSize);
            sqlCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
            sqlCommand.Parameters.AddWithValue("@SortBy", SortBy);
            sqlCommand.Parameters.AddWithValue("@SortDirection", SortDirection);
            sqlCommand.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            (new SqlDataAdapter(sqlCommand)).Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public virtual DataTable Invoice_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Invoice_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoiceItem_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Invoice_Select_By_EstimateItemID_PerItem(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_select_PerItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Invoice_Select_By_InvoiceID(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Invoiceid", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Invoice_Select_By_JobID(int CompanyID, long JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobInvoice_QuickLink_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobId", DbType.Int64, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Invoice_Status_Update(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_status_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int32, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataSet Invoice_SummaryDetails_Select(int CompanyID, long InvoiceID)
        {
            DataSet dataSet = new DataSet();
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Invoice_SummaryDetails_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            return database.ExecuteDataSet(storedProcCommand);
        }

        public virtual void Invoice_UnArchive(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_unarchive");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void invoice_update(long CompanyID, long InvoiceID, int Status, DateTime Invoicecreateddate, DateTime ModifiedDate, DateTime InvoiceDueDate, string Header, string Footer, long SalespersonID, string InvoiceTitle, string CustomerOrderNumber, int ValidFor, long ClientID, long ContactID, string Greeting, long ContactAddressID, long DeliveryAddressID, long InvoiceAddressID, char InvoiceAddressType, long InvoiceAddressClientID, long DepartmentID, long CostCentreID, long LoggedInUserID,string Comment, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@Invoiceid", DbType.Int64, InvoiceID);
            database.AddInParameter(storedProcCommand, "@Status", DbType.Int32, Status);
            database.AddInParameter(storedProcCommand, "@InvoiceCreatedDate", DbType.DateTime, Invoicecreateddate);
            database.AddInParameter(storedProcCommand, "@ModifiedDate", DbType.DateTime, ModifiedDate);
            database.AddInParameter(storedProcCommand, "@InvoiceDueDate", DbType.DateTime, InvoiceDueDate);
            database.AddInParameter(storedProcCommand, "@Header", DbType.String, Header);
            database.AddInParameter(storedProcCommand, "@Footer", DbType.String, Footer);
            database.AddInParameter(storedProcCommand, "@SalespersonID", DbType.Int64, SalespersonID);
            database.AddInParameter(storedProcCommand, "@InvoiceTitle", DbType.String, InvoiceTitle);
            database.AddInParameter(storedProcCommand, "@CustomerOrderNumber", DbType.String, CustomerOrderNumber);
            database.AddInParameter(storedProcCommand, "@ValidFor", DbType.Int32, ValidFor);
            database.AddInParameter(storedProcCommand, "@ClientID", DbType.Int64, ClientID);
            database.AddInParameter(storedProcCommand, "@ContactID", DbType.Int64, ContactID);
            database.AddInParameter(storedProcCommand, "@Greeting", DbType.String, Greeting);
            database.AddInParameter(storedProcCommand, "@ContactAddressID", DbType.Int64, ContactAddressID);
            database.AddInParameter(storedProcCommand, "@DeliveryAddressID", DbType.Int64, DeliveryAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int64, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressType", DbType.String, InvoiceAddressType);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressClientID", DbType.Int64, InvoiceAddressClientID);
            database.AddInParameter(storedProcCommand, "@DepartmentID", DbType.Int64, DepartmentID);
            database.AddInParameter(storedProcCommand, "@CostCentreID", DbType.Int64, CostCentreID);
            database.AddInParameter(storedProcCommand, "@LoggedInUserID", DbType.Int64, LoggedInUserID);
            database.AddInParameter(storedProcCommand, "@Comments", DbType.String, Comment);
            database.AddInParameter(storedProcCommand, "@InvoiceContactId", DbType.Int64, InvoiceContactId);
            database.AddInParameter(storedProcCommand, "@priority", DbType.String, priority);
            database.AddInParameter(storedProcCommand, "@CustomDate1", DbType.DateTime, customDate1);
            database.AddInParameter(storedProcCommand, "@CustomDate2", DbType.DateTime, customDate2);
            database.AddInParameter(storedProcCommand, "@CustomDate3", DbType.DateTime, customDate3);
            database.AddInParameter(storedProcCommand, "@CustomDate4", DbType.DateTime, customDate4);
            database.AddInParameter(storedProcCommand, "@CustomDate5", DbType.DateTime, customDate5);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void invoice_update_Address(int CompanyID, long EstID, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_update_Address");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstID", DbType.Int64, EstID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressID", DbType.Int32, InvoiceAddressID);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressType", DbType.String, InvoiceAddressType);
            database.AddInParameter(storedProcCommand, "@InvoiceAddressClientID", DbType.Int32, InvoiceAddressClientID);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable InvoiceAmount_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoicedetails_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable InvoiceDetails_ByInvoiceID_Select(long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoiceDetails_ByInvoiceID_Select");
            database.AddInParameter(storedProcCommand, "@Invoiceid", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void InvoiceID_Update_in_Items(long InvoiceID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoiceID_Update_in_Item");
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable InvoiceItem_EstimateItemID_Select(long ModuleID, string Module)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateItemIDsForStatus_ByModuleID");
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable invoiceItemdetails_select(int CompanyID, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoiceItemdetails_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable InvoiceItemNum_EstimateItems_Select(int CompanyID, string EstimateItemIDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoiceItemNum_EstimateItems_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.String, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemIDs", DbType.String, EstimateItemIDs);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void InvoiceOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
        {
            long num = (long)0;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                num = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
            }
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_EstimateOnCheck_Status_Update");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateIDS", DbType.String, EstimateIDs);
            database.AddInParameter(storedProcCommand, "@StatusID", DbType.Int32, StatusID);
            database.AddInParameter(storedProcCommand, "@Module", DbType.String, Module);
            database.AddInParameter(storedProcCommand, "@LoggedIN_UserID", DbType.Int32, num);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void InvoicePaid_HistoryDetails_Delete(int CompanyID, long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_InvoicePaid_HistoryDetails_Delete");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable InvoicePaid_HistoryDetails_EditSelect(int CompanyID, long ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_InvoicePaid_HistoryDetails_EditSelect");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable InvoicePaid_HistoryDetails_JobSummary_Select(int CompanyID, long JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_InvoicePaid_HistoryDetails_JobSummary_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable InvoicePaid_HistoryDetails_Select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_InvoicePaid_HistoryDetails_Select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, EstimateID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void InvoicePaymentDetails_Insert(long ID, long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber, decimal Amountpaid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoicePaymentDetails_Insert");
            database.AddInParameter(storedProcCommand, "@ID", DbType.Int64, ID);
            database.AddInParameter(storedProcCommand, "@invoiceID", DbType.Int64, invoiceID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.AddInParameter(storedProcCommand, "@Amountpaid", DbType.Decimal, Amountpaid);
            database.ExecuteScalar(storedProcCommand);
        }

        public virtual void InvoicePaymentDetails_Insert_SplitItem(long InvoiceID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber, decimal Amountpaid, decimal InvoiceAmount)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_InvoicePaymentDetails_Insert_SplitItems");
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@PaymentMode", DbType.Int16, PaymentMode);
            database.AddInParameter(storedProcCommand, "@PaymentDate", DbType.DateTime, PaymentDate);
            database.AddInParameter(storedProcCommand, "@Notes", DbType.String, Notes);
            database.AddInParameter(storedProcCommand, "@CardHoldersName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int16, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int16, ExpYear);
            database.AddInParameter(storedProcCommand, "@VerificationNumber", DbType.String, VarificationNumber);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.AddInParameter(storedProcCommand, "@Amountpaid", DbType.Decimal, Amountpaid);
            database.AddInParameter(storedProcCommand, "@InvoiceAmount", DbType.Decimal, InvoiceAmount);
            database.ExecuteScalar(storedProcCommand);
        }
        public virtual void Insert_StripePayment(long CompanyID, long EstimateID, string StripePaymentID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Insert_StripePayment");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@StripePaymentID", DbType.String, StripePaymentID);
            database.ExecuteScalar(storedProcCommand);
        }
        public virtual DataTable Select_details_ClientInfo(long CompanyID, string ServerName)
        {
            DataTable dataTable = new DataTable();
            commonclass _commonclass = new commonclass();
            Database database = CustomDatabaseFactory.CreateDatabase(ConfigurationManager.ConnectionStrings["MasterConnectionString"].ToString());
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_details_ClientInfo");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@ServerName", DbType.String, ServerName);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual IDataReader Invoices_Invoice_Details_select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_details_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int32, EstimateID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual IDataReader Invoices_Invoice_Details_select_ByInvoiceID(int CompanyID, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_details_select_ByInvoiceID");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int32, InvoiceID);
            return database.ExecuteReader(storedProcCommand);
        }

        public virtual DataTable Invoices_Select_All(int CompanyID, string Para)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoices_select_all");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Para", DbType.String, Para);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual string Invoices_Status_Select(int CompanyID, long EstimateID)
        {
            string empty = string.Empty;
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_status_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string Is_INVOICE_from_Webstore(long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_ISINVOICE_from_Webstore");
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual string IS_INVOICEorJOB_from_Webstore(long ModuleID, string ModuleType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_IS_INVOICEorJOB_from_Webstore");
            database.AddInParameter(storedProcCommand, "@ModuleID", DbType.Int64, ModuleID);
            database.AddInParameter(storedProcCommand, "@ModuleType", DbType.String, ModuleType);
            return (string)database.ExecuteScalar(storedProcCommand);
        }

        public virtual DataTable Job_Card_Info_Select_By_InvoiceID(long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Job_Card_Info_Select_By_InvoiceID");
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int64, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Get_JobNumber_ProductID_ForAlert(long JobID, long EstimateItemID, int CompanyID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Get_JobNumber_ProductID_ForAlert");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Job_Items_Select(long JobID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_jobItem_select");
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, JobID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void JobItems_Archive_Update(int CompanyId, int UserId, DateTime CreatedDate, long EstimateItemID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_JobItems_Archive_Update");
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyId);
            database.AddInParameter(storedProcCommand, "@userid", DbType.Int32, UserId);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual DataTable OrderDetails_select(int CompanyID, long OrderID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_OrderDetail_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PaymentAmountPaid_ForInvoice_select(int CompanyID, long EstimateID, string Type)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PaymentAmountPaid_ForInvoice_select");
            database.AddInParameter(storedProcCommand, "@EstimateId", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@Type", DbType.String, Type);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PaymentAmountPaid_ForInvoice_select_Items(int CompanyID, string EstimateItemIds, long InvoiceID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PaymentAmountPaid_ForInvoice_select_Items");
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.String, EstimateItemIds);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@InvoiceID", DbType.Int32, InvoiceID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PaymentAmountPaid_ForInvoice_select_SplitItem(int CompanyID, string EstimateItemIDs)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PaymentAmountPaid_ForInvoice_select_SplitItem");
            database.AddInParameter(storedProcCommand, "@CompanyId", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.String, EstimateItemIDs);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PaymentAmountPaid_ForJob_select(int CompanyID, long JobId, long EstimateItemId)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_PaymentAmountPaid_ForJob_select");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@JobId", DbType.Int64, JobId);
            database.AddInParameter(storedProcCommand, "@EstimateItemId", DbType.Int64, EstimateItemId);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable PaymentDetails_select(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_PaymentDetails_select");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_BraintreeDetails_Authorize(int CompanyID, long OrderID, long Invoice_ID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("Pc_Select_BrainTreeAuthorizatioDetails");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            database.AddInParameter(storedProcCommand, "@OrderID", DbType.Int64, OrderID);
            database.AddInParameter(storedProcCommand, "@InvoiceId", DbType.Int64, Invoice_ID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual DataTable Select_details_for_Activity_History(int CompanyID, long EstimateID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_select_inv_activity_history");
            database.AddInParameter(storedProcCommand, "@EstimateId", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, CompanyID);
            using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }

        public virtual void Update_AmountPaid(long EstimateID, int companyID, decimal AmountPaid)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("PC_invoice_AmountPaid_update");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@AmountPaid", DbType.Decimal, AmountPaid);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_PaymentType(long EstimateID, int companyID, string PaymentType, string CardHolderName, string CardName, long CardNumber, string CardType, string SecurityCode, int ExpMonth, int ExpYear)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Order_PaymentType_Update");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@PaymentType", DbType.String, PaymentType);
            database.AddInParameter(storedProcCommand, "@CardHolderName", DbType.String, CardHolderName);
            database.AddInParameter(storedProcCommand, "@CardName", DbType.String, CardName);
            database.AddInParameter(storedProcCommand, "@CardNumber", DbType.String, CardNumber);
            database.AddInParameter(storedProcCommand, "@CardType", DbType.String, CardType);
            database.AddInParameter(storedProcCommand, "@SecurityCode", DbType.String, SecurityCode);
            database.AddInParameter(storedProcCommand, "@ExpirationMonth", DbType.Int32, ExpMonth);
            database.AddInParameter(storedProcCommand, "@ExpirationYear", DbType.Int32, ExpYear);
            database.ExecuteNonQuery(storedProcCommand);
        }

        public virtual void Update_PaymentTypeForEstore(long EstimateID, int companyID, string PaymentType)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_Order_PaymentTypeUpdate");
            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int32, companyID);
            database.AddInParameter(storedProcCommand, "@PaymentType", DbType.String, PaymentType);
            database.ExecuteNonQuery(storedProcCommand);
        }
    }
}