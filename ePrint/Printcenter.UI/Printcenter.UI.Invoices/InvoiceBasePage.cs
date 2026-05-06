using Printcenter.BusinessAccessLayer.Invoice;
using System;
using System.Data;

namespace Printcenter.UI.Invoices
{
    public class InvoiceBasePage
    {
        public InvoiceBasePage()
        {
        }

        public static string Check_Invoice_PaymentType(long EstimateID)
        {
            return Invoice.Check_Invoice_PaymentType(EstimateID);
        }

        public static bool CheckAllocationExist(long JobID, long EstimateItemID)
        {
            return Invoice.CheckAllocationExist(JobID, EstimateItemID);
        }

        public static bool CheckInvoicePossible(long JobID, long EstimateItemID)
        {
            return Invoice.CheckInvoicePossible(JobID, EstimateItemID);
        }

        public static void copy_invoice(int CompanyID, long Old_EstimateID, long New_EstimateID, bool IsHandy)
        {
            Invoice.copy_invoice(CompanyID, Old_EstimateID, New_EstimateID, IsHandy);
        }

        public static void EstimateItems_ProgressToInvoice(long EstimateItemID, long InvoiceID)
        {
            Invoice.EstimateItems_ProgressToInvoice(EstimateItemID, InvoiceID);
        }

        public static DataTable EstimateItems_Type_PriceCatalogue_Invoice_Select(long InvoiceID)
        {
            return Invoice.EstimateItems_Type_PriceCatalogue_Invoice_Select(InvoiceID);
        }

        public static long From_InvoiceID_Select_EstimateID(long InvoiceID)
        {
            return Invoice.From_InvoiceID_Select_EstimateID(InvoiceID);
        }

        public static int Get_PaymentDetails_From_EstimateID(long EstimateID)
        {
            return Invoice.Get_PaymentDetails_From_EstimateID(EstimateID);
        }

        public static DataTable GetClientDefaultInvoiceDetails(int CompanyID, long EstimateID)
        {
            return Invoice.GetClientDefaultInvoiceDetails(CompanyID, EstimateID);
        }

        public static DataTable GetInvoiceAddressDetails(int CompanyID, int ClientID)
        {
            return Invoice.GetInvoiceAddressDetails(CompanyID, ClientID);
        }

        public static void Insert_InvoicePaymentDetails(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Invoice.Insert_InvoicePaymentDetails(invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber);
        }

        public static DataTable Insert_InvoicePaymentDetails_Main(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            return Invoice.Insert_InvoicePaymentDetails_Main(invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber);
        }

        public static void Insert_InvoicePaymentDetailsForEstore(long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber)
        {
            Invoice.Insert_InvoicePaymentDetailsForEstore(invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber);
        }

        public static DataTable invoice_advance_search(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            return Invoice.invoice_advance_search(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
        }

        public static DataTable invoice_advance_search_SplitItems(int CompanyID, string SearchText, int ClientID, string Status, string DateType, string FromDate, string ToDate, bool IsArchived, string TodayDate, string StartDate, string EndDate, string SalesPersonRecords)
        {
            return Invoice.invoice_advance_search_SplitItems(CompanyID, SearchText, ClientID, Status, DateType, FromDate, ToDate, IsArchived, TodayDate, StartDate, EndDate, SalesPersonRecords);
        }

        public static DataTable invoice_advance_search_top5(int CompanyID, int ClientID, string Status, string DateType, bool IsArchived)
        {
            return Invoice.invoice_advance_search_top5(CompanyID, ClientID, Status, DateType, IsArchived);
        }

        public static void Invoice_Archive(int CompanyID, long InvoiceID)
        {
            Invoice.Invoice_Archive(CompanyID, InvoiceID);
        }

        public static void Invoice_Comments_Update(int commentId, string newComment)
        {
            Invoice.Invoice_Comments_Update(commentId, newComment);
        }

        public static void Invoice_Exported(int CompanyID, long InvoiceID)
        {
            Invoice.Invoice_Exported(CompanyID, InvoiceID);
        }

        public static void Invoice_Unexported(int CompanyID, long InvoiceID)
        {
            Invoice.Invoice_Unexported(CompanyID, InvoiceID);
        }

        public static void Invoice_Delete(int CompanyID, long InvoiceID, bool Keep_EstimateJOB_LIVE)
        {
            Invoice.Invoice_Delete(CompanyID, InvoiceID, Keep_EstimateJOB_LIVE);
        }

        public static long Invoice_insert(int CompanyID, long EstID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID, DateTime InvoiceDueDate, long Job_ID, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            return Invoice.Invoice_insert(CompanyID, EstID, InvoiceNumber, Status, ConvertedDate, CreatedDate, ConvertedBy, CreatedBy, Header, Footer, Ispaid, IsHandy, InvoiceAddressID, InvoiceAddressType, InvoiceAddressClientID, InvoiceDueDate, Job_ID,  priority, customDate1, customDate2, customDate3, customDate4, customDate5);
        }

        public static int invoice_insert_ispaid(int CompanyID, long EstID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID)
        {
            return Invoice.invoice_insert_ispaid(CompanyID, EstID, InvoiceNumber, Status, ConvertedDate, CreatedDate, ConvertedBy, CreatedBy, Header, Footer, Ispaid, IsHandy, InvoiceAddressID, InvoiceAddressType, InvoiceAddressClientID);
        }

        public static long Invoice_insert_SplitItems(int CompanyID, string InvoiceNumber, int Status, DateTime ConvertedDate, DateTime CreatedDate, int ConvertedBy, int CreatedBy, string Header, string Footer, int Ispaid, bool IsHandy, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID, DateTime InvoiceDueDate, long ClientID, long ContactID, long SalespersonID, string InvoiceTitle, bool IsArchive, string CustomerOrdNo)
        {
            return Invoice.Invoice_insert_SplitItems(CompanyID, InvoiceNumber, Status, ConvertedDate, CreatedDate, ConvertedBy, CreatedBy, Header, Footer, Ispaid, IsHandy, InvoiceAddressID, InvoiceAddressType, InvoiceAddressClientID, InvoiceDueDate, ClientID, ContactID, SalespersonID, InvoiceTitle, IsArchive, CustomerOrdNo);
        }

        public static long invoice_InvoiceID_select(int CompanyID, long EstimateID, string Type)
        {
            return Invoice.invoice_InvoiceID_select(CompanyID, EstimateID, Type);
        }

        public static void invoice_isexported_update(int CompanyID, long EstimateID)
        {
            Invoice.invoice_isexported_update(CompanyID, EstimateID);
        }

        public static void invoice_job_estimate_isconv_update(int CompanyID, long EstimateID)
        {
            Invoice.invoice_job_estimate_isconv_update(CompanyID, EstimateID);
        }

        public static DataTable Invoice_JobDetails_SelectByInvoiceID(int CompanyID, long InvoiceID)
        {
            return Invoice.Invoice_JobDetails_SelectByInvoiceID(CompanyID, InvoiceID);
        }

        public static DataSet invoice_PageText(int CompanyID, int PageSize, int PageNumber, string SortBy, string SortDirection, string WhereCondition)
        {
            return Invoice.invoice_PageText(CompanyID, PageSize, PageNumber, SortBy, SortDirection, WhereCondition);
        }

        public static DataTable Invoice_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            return Invoice.Invoice_Select_By_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable Invoice_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return Invoice.Invoice_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static DataTable Invoice_Select_By_EstimateItemID_PerItem(int CompanyID, long EstimateItemID)
        {
            return Invoice.Invoice_Select_By_EstimateItemID_PerItem(CompanyID, EstimateItemID);
        }

        public static DataTable Invoice_Select_By_InvoiceID(int CompanyID, long InvoiceID)
        {
            return Invoice.Invoice_Select_By_InvoiceID(CompanyID, InvoiceID);
        }

        public static DataTable Invoice_Select_By_JobID(int CompanyID, long JobID)
        {
            return Invoice.Invoice_Select_By_JobID(CompanyID, JobID);
        }

        public static void Invoice_Status_Update(int CompanyID, long InvoiceID)
        {
            Invoice.Invoice_Status_Update(CompanyID, InvoiceID);
        }

        public static DataSet Invoice_SummaryDetails_Select(int CompanyID, long InvoiceID)
        {
            return Invoice.Invoice_SummaryDetails_Select(CompanyID, InvoiceID);
        }

        public static void Invoice_UnArchive(int CompanyID, long InvoiceID)
        {
            Invoice.Invoice_UnArchive(CompanyID, InvoiceID);
        }

        public static void invoice_update(long CompanyID, long InvoiceID, int Status, DateTime Invoicecreateddate, DateTime ModifiedDate, DateTime InvoiceDueDate, string Header, string Footer, long SalespersonID, string InvoiceTitle, string CustomerOrderNumber, int ValidFor, long ClientID, long ContactID, string Greeting, long ContactAddressID, long DeliveryAddressID, long InvoiceAddressID, char InvoiceAddressType, long InvoiceAddressClientID, long DepartmentID, long CostCentreID, long LoggedInUserID, string Comment, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            Invoice.invoice_update(CompanyID, InvoiceID, Status, Invoicecreateddate, ModifiedDate, InvoiceDueDate, Header, Footer, SalespersonID, InvoiceTitle, CustomerOrderNumber, ValidFor, ClientID, ContactID, Greeting, ContactAddressID, DeliveryAddressID, InvoiceAddressID, InvoiceAddressType, InvoiceAddressClientID, DepartmentID, CostCentreID, LoggedInUserID, Comment, InvoiceContactId,  priority, customDate1, customDate2, customDate3, customDate4, customDate5);
        }

        public static void invoice_update_Address(int CompanyID, long EstID, int InvoiceAddressID, char InvoiceAddressType, int InvoiceAddressClientID)
        {
            Invoice.invoice_update_Address(CompanyID, EstID, InvoiceAddressID, InvoiceAddressType, InvoiceAddressClientID);
        }

        public static DataTable InvoiceAmount_Select_By_EstimateID(int CompanyID, long EstimateID)
        {
            return Invoice.InvoiceAmount_Select_By_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable InvoiceDetails_ByInvoiceID_Select(long InvoiceID)
        {
            return Invoice.InvoiceDetails_ByInvoiceID_Select(InvoiceID);
        }

        public static void InvoiceID_Update_in_Items(long InvoiceID, long EstimateItemID)
        {
            Invoice.InvoiceID_Update_in_Items(InvoiceID, EstimateItemID);
        }

        public static DataTable InvoiceItem_EstimateItemID_Select(long ModuleID, string Module)
        {
            return Invoice.InvoiceItem_EstimateItemID_Select(ModuleID, Module);
        }

        public static DataTable invoiceItemdetails_select(int CompanyID, long EstimateItemID)
        {
            return Invoice.invoiceItemdetails_select(CompanyID, EstimateItemID);
        }

        public static DataTable InvoiceItemNum_EstimateItems_Select(int CompanyID, string EstimateItemIDs)
        {
            return Invoice.InvoiceItemNum_EstimateItems_Select(CompanyID, EstimateItemIDs);
        }

        public static void InvoiceOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
        {
            Invoice.InvoiceOnCheck_Status_Update(CompanyID, EstimateIDs, StatusID, Module);
        }

        public static void InvoicePaid_HistoryDetails_Delete(int CompanyID, long ID)
        {
            Invoice.InvoicePaid_HistoryDetails_Delete(CompanyID, ID);
        }

        public static DataTable InvoicePaid_HistoryDetails_EditSelect(int CompanyID, long ID)
        {
            return Invoice.InvoicePaid_HistoryDetails_EditSelect(CompanyID, ID);
        }

        public static DataTable InvoicePaid_HistoryDetails_JobSummary_Select(int CompanyID, long JobID)
        {
            return Invoice.InvoicePaid_HistoryDetails_JobSummary_Select(CompanyID, JobID);
        }

        public static DataTable InvoicePaid_HistoryDetails_Select(int CompanyID, long EstimateID)
        {
            return Invoice.InvoicePaid_HistoryDetails_Select(CompanyID, EstimateID);
        }

        public static void InvoicePaymentDetails_Insert(long ID, long invoiceID, long EstimateID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber, decimal Amountpaid)
        {
            Invoice.InvoicePaymentDetails_Insert(ID, invoiceID, EstimateID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber, Amountpaid);
        }

        public static void InvoicePaymentDetails_Insert_SplitItem(long InvoiceID, long CompanyID, int PaymentMode, DateTime PaymentDate, string Notes, string CardHolderName, string CardType, int ExpMonth, int ExpYear, string VarificationNumber, string CardNumber, decimal Amountpaid, decimal InvoiceAmount)
        {
            Invoice.InvoicePaymentDetails_Insert_SplitItem(InvoiceID, CompanyID, PaymentMode, PaymentDate, Notes, CardHolderName, CardType, ExpMonth, ExpYear, VarificationNumber, CardNumber, Amountpaid, InvoiceAmount);
        }
        public static void Insert_StripePayment(long CompanyID,long EstimateID,string StripePaymentID)
        {
            Invoice.Insert_StripePayment(CompanyID,EstimateID,StripePaymentID);
        }
        public static DataTable Select_details_ClientInfo(long CompanyID, string ServerName)
        {
            return Invoice.Select_details_ClientInfo(CompanyID, ServerName);
        }
        public static IDataReader Invoices_Invoice_Details_select(int CompanyID, long EstimateID)
        {
            return Invoice.Invoices_Invoice_Details_select(CompanyID, EstimateID);
        }

        public static IDataReader Invoices_Invoice_Details_select_ByInvoiceID(int CompanyID, long InvoiceID)
        {
            return Invoice.Invoices_Invoice_Details_select_ByInvoiceID(CompanyID, InvoiceID);
        }

        public static DataTable Invoices_Select_All(int CompanyID, string Para)
        {
            return Invoice.Invoices_Select_All(CompanyID, Para);
        }

        public static string Invoices_Status_Select(int CompanyID, long EstimateID)
        {
            return Invoice.Invoices_Status_Select(CompanyID, EstimateID);
        }

        public static string Is_INVOICE_from_Webstore(long InvoiceID)
        {
            return Invoice.Is_INVOICE_from_Webstore(InvoiceID);
        }

        public static string IS_INVOICEorJOB_from_Webstore(long ModuleID, string ModuleType)
        {
            return Invoice.IS_INVOICEorJOB_from_Webstore(ModuleID, ModuleType);
        }

        public static DataTable Job_Card_Info_Select_By_InvoiceID(long InvoiceID)
        {
            return Invoice.Job_Card_Info_Select_By_InvoiceID(InvoiceID);
        }

        public static DataTable Get_JobNumber_ProductID_ForAlert(long JobID, long EstimateItemID, int CompanyID)
        {
            return Invoice.Get_JobNumber_ProductID_ForAlert(JobID, EstimateItemID, CompanyID);
        }

        public static DataTable Job_Items_Select(long JobID)
        {
            return Invoice.Job_Items_Select(JobID);
        }

        public static void JobItems_Archive_Update(int CompanyId, int UserId, DateTime CreatedDate, long EstimateItemID)
        {
            Invoice.JobItems_Archive_Update(CompanyId, UserId, CreatedDate, EstimateItemID);
        }

        public static DataTable OrderDetails_select(int CompanyID, long OrderID)
        {
            return Invoice.OrderDetails_select(CompanyID, OrderID);
        }

        public static DataTable PaymentAmountPaid_ForInvoice_select(int CompanyID, long EstimateID, string Type)
        {
            return Invoice.PaymentAmountPaid_ForInvoice_select(CompanyID, EstimateID, Type);
        }

        public static DataTable PaymentAmountPaid_ForInvoice_select_Items(int CompanyID, string EstimateItemIds, long InvoiceID)
        {
            return Invoice.PaymentAmountPaid_ForInvoice_select_Items(CompanyID, EstimateItemIds, InvoiceID);
        }

        public static DataTable PaymentAmountPaid_ForJob_select(int CompanyID, long JobId, long EstimateItemId)
        {
            return Invoice.PaymentAmountPaid_ForJob_select(CompanyID, JobId, EstimateItemId);
        }

        public static DataTable PaymentDetails_select(int CompanyID, long EstimateID)
        {
            return Invoice.PaymentDetails_select(CompanyID, EstimateID);
        }

        public static DataTable Select_BraintreeDetails_Authorize(int CompanyID, long OrderID, long Invoice_ID)
        {
            return Invoice.Select_BraintreeDetails_Authorize(CompanyID, OrderID, Invoice_ID);
        }

        public static DataTable Select_details_for_Activity_History(int CompanyID, long EstimateID)
        {
            return Invoice.Select_details_for_Activity_History(CompanyID, EstimateID);
        }

        public static void Update_AmountPaid(long EstimateID, int CompanyID, decimal AmountPaid)
        {
            Invoice.Update_AmountPaid(EstimateID, CompanyID, AmountPaid);
        }

        public static void Update_PaymentType(long EstimateID, int CompanyID, string PaymentType, string CardHolderName, string CardName, long CardNumber, string CardType, string SecurityCode, int ExpMonth, int ExpYear)
        {
            Invoice.Update_PaymentType(EstimateID, CompanyID, PaymentType, CardHolderName, CardName, CardNumber, CardType, SecurityCode, ExpMonth, ExpYear);
        }

        public static void Update_PaymentTypeForEstore(long EstimateID, int CompanyID, string PaymentType)
        {
            Invoice.Update_PaymentTypeForEstore(EstimateID, CompanyID, PaymentType);
        }
    }
}