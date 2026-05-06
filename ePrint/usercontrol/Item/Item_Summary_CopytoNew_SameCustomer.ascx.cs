using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class Item_Summary_CopytoNew_SameCustomer : UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        private commonClass commclass = new commonClass();

        private CompanyBasePage objCom = new CompanyBasePage();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private SummaryClass SummaryClassObj = new SummaryClass();

        public languageClass objLanguage = new languageClass();

        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public int CompanyID;

        public int UserID;

        public long EstimateID;

        public string Module = string.Empty;

        public string modulename = string.Empty;

        public string submodulename = string.Empty;

        public string MainType = string.Empty;

        public bool Check_SpecialPrivilege;

        public string estimateconvertedtojob = string.Empty;

        private string isdirectjob = string.Empty;

        public string CompanyType = string.Empty;

        public string Ordernumbervalidtiononlyforcoralcoastsystem = string.Empty;

        public string DateFormat = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public int ISInventoryReduced;

        private Hashtable htInventory = new Hashtable();

        public string UserName = string.Empty;

        public string PONO = string.Empty;

        private string Jobconvertedate = string.Empty;

        public long DeliveryID;

        public long DeliveryItemID;

        public int CustomerID;

        public int AttentionID;

        public string ShippedTo = string.Empty;

        public long DeliveryAddID;

        public string DelAddType = string.Empty;

        public string Footer = string.Empty;

        public long DelNO;

        public DateTime DeliveyDate = DateTime.Now;

        public DateTime ActualDeliveryDate = DateTime.Now;

        public string RefNo = string.Empty;

        public string OrderNo = string.Empty;

        public string newdate = string.Empty;

        public string StrDelNum = string.Empty;

        private long Estimateitemid_directjob;

        public static bool IsJobCopied;

        public static long NewEstID;

        public static bool IsItemCopied;

        public string Pgtype = string.Empty;

        public string activityhist = string.Empty;

        public string IsProformaInvoice = string.Empty;

        public long jobID;

        public long InvoiceID;

        public string jID = string.Empty;

        public string InvID = string.Empty;

        private long NewJobID;

        private long NewInvoiceID;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static Item_Summary_CopytoNew_SameCustomer()
        {
        }

        public Item_Summary_CopytoNew_SameCustomer()
        {
        }

        private void Activity_history_insert(string Pgtype, long EstimateID, long NewEstID)
        {
            if (Pgtype == "estimate")
            {
                string empty = string.Empty;
                DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, EstimateID, "", (long)0);
                foreach (DataRow row in dataTable.Rows)
                {
                    empty = row["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_number = empty;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewCopied);
                this.objnotes.ModuleID = NewEstID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.commclass;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                string str = string.Empty;
                DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, NewEstID, "", (long)0);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    empty = dataRow["Estimatenumber"].ToString();
                    str = dataRow["ClientName"].ToString();
                }
                this.objnotes.new_Estimate_number = empty;
                this.objnotes.Customer_Name = str;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCopied);
                this.objnotes.ModuleID = EstimateID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.commclass;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (Pgtype == "order")
            {
                string empty1 = string.Empty;
                DataTable dataTable2 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, EstimateID, "", (long)0);
                foreach (DataRow row1 in dataTable2.Rows)
                {
                    empty1 = row1["Estimatenumber"].ToString();
                }
                this.objnotes.Estimate_number = empty1;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstNewCopied);
                this.objnotes.ModuleID = NewEstID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass2 = this.objnotes;
                commonClass _commonClass2 = this.commclass;
                DateTime now1 = DateTime.Now;
                _notesclass2.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                string str1 = string.Empty;
                DataTable dataTable3 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, NewEstID, "", (long)0);
                foreach (DataRow dataRow1 in dataTable3.Rows)
                {
                    empty1 = dataRow1["Estimatenumber"].ToString();
                    str1 = dataRow1["ClientName"].ToString();
                }
                this.objnotes.new_Estimate_number = empty1;
                this.objnotes.Customer_Name = str1;
                this.objnotes.ModuleName = "order";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstCopied);
                this.objnotes.ModuleID = EstimateID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass3 = this.objnotes;
                commonClass _commonClass3 = this.commclass;
                DateTime dateTime1 = DateTime.Now;
                _notesclass3.Created_Date = _commonClass3.Eprint_return_DateTime_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (Pgtype == "job")
            {
                string empty2 = string.Empty;
                DataTable dataTable4 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, EstimateID, "", (long)0);
                foreach (DataRow row2 in dataTable4.Rows)
                {
                    empty2 = row2["jobnumber"].ToString();
                }
                this.objnotes.Job_number = empty2;
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobNewCopied);
                this.objnotes.ModuleID = this.NewJobID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass4 = this.objnotes;
                commonClass _commonClass4 = this.commclass;
                DateTime now2 = DateTime.Now;
                _notesclass4.Created_Date = _commonClass4.Eprint_return_DateTime_Before_View(now2.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                string str2 = string.Empty;
                DataTable dataTable5 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, NewEstID, "", (long)0);
                foreach (DataRow dataRow2 in dataTable5.Rows)
                {
                    empty2 = dataRow2["jobnumber"].ToString();
                    str2 = dataRow2["ClientName"].ToString();
                }
                this.objnotes.new_Job_number = empty2;
                this.objnotes.ModuleName = "job";
                this.objnotes.Customer_Name = str2;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobCopied);
                this.objnotes.ModuleID = this.jobID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass5 = this.objnotes;
                commonClass _commonClass5 = this.commclass;
                DateTime dateTime2 = DateTime.Now;
                _notesclass5.Created_Date = _commonClass5.Eprint_return_DateTime_Before_View(dateTime2.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                return;
            }
            if (Pgtype == "invoice")
            {
                string empty3 = string.Empty;
                DataTable dataTable6 = new DataTable();
                dataTable6.Load(InvoiceBasePage.Invoices_Invoice_Details_select(this.CompanyID, EstimateID));
                foreach (DataRow row3 in dataTable6.Rows)
                {
                    empty3 = row3["invoicenumber"].ToString();
                }
                this.objnotes.Invoice_number = empty3;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNewCopied);
                this.objnotes.ModuleID = this.NewInvoiceID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass6 = this.objnotes;
                commonClass _commonClass6 = this.commclass;
                DateTime now3 = DateTime.Now;
                _notesclass6.Created_Date = _commonClass6.Eprint_return_DateTime_Before_View(now3.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                string str3 = string.Empty;
                DataTable dataTable7 = new DataTable();
                dataTable7.Load(InvoiceBasePage.Invoices_Invoice_Details_select(this.CompanyID, NewEstID));
                foreach (DataRow dataRow3 in dataTable7.Rows)
                {
                    empty3 = dataRow3["invoicenumber"].ToString();
                    str3 = dataRow3["ClientName"].ToString();
                }
                this.objnotes.new_Invoice_number = empty3;
                this.objnotes.Customer_Name = str3;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvCopied);
                this.objnotes.ModuleID = this.InvoiceID;
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass7 = this.objnotes;
                commonClass _commonClass7 = this.commclass;
                DateTime dateTime3 = DateTime.Now;
                _notesclass7.Created_Date = _commonClass7.Eprint_return_DateTime_Before_View(dateTime3.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
        }

        public void lnkEstimateCopyToNewCustArchive_OnClick(object sender, EventArgs e)
        {
            if (base.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            }
            if (this.rdnCopyYes.Checked)
            {
                long estimateID = (long)0;
                if (this.Pgtype == "estimate")
                {
                    estimateID = this.EstimateID;
                }
                else if (this.Pgtype == "order")
                {
                    estimateID = this.EstimateID;
                }
                else if (this.Pgtype == "job")
                {
                    estimateID = this.jobID;
                }
                else if (this.Pgtype == "invoice")
                {
                    estimateID = this.InvoiceID;
                }
                int companyID = this.CompanyID;
                long num = this.EstimateID;
                int userID = this.UserID;
                DateTime now = DateTime.Now;

                DateTime Estimateartworkdate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ArtworkDate")));
                DateTime Estimatedeliverydate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "DeliveryDate")));
                DateTime JobCompletionDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "CompletionDate")));
                DateTime ProofDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ProofDate")));
                DateTime ApprovalDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ApprovalDate")));
                DateTime ProductionDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ProductionDate")));

                //DateTime Estimateartworkdate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "ArtworkDate"));
                //DateTime Estimatedeliverydate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "DeliveryDate"));
                //DateTime JobCompletionDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "CompletionDate"));
                //DateTime ProofDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "ProofDate"));
                //DateTime ApprovalDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "ApprovalDate"));
                //DateTime ProductionDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID, "ProductionDate"));
                Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.EstimateCopyEstimateInsert(companyID, num, "", userID, now.ToString(), ConnectionClass.IsHandy, this.Pgtype, estimateID, Estimateartworkdate, Estimatedeliverydate, JobCompletionDate, ProofDate, ApprovalDate, ProductionDate);
                //Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID, num, "", userID, now.ToString(), ConnectionClass.IsHandy, this.Pgtype, estimateID);
                this.objCom.settings_lastcounter_update(this.CompanyID, "e", (long)0);
                EstimatesBasePage.Update_customer_details_forNew_copy_estimate(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, Convert.ToInt64(this.hid_ClientID.Value), Convert.ToInt64(this.hdn_Attention.Value), Convert.ToString(this.hid_Greeting.Value), this.objBC.SpecialDecode(Convert.ToString(this.hid_CustName.Value)), Convert.ToInt64(this.hid_contactId.Value), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.UserID, Convert.ToInt64(this.hdn_InvAddressID.Value));
                if (this.Pgtype == "estimate")
                {
                    int companyID1 = this.CompanyID;
                    long estimateID1 = this.EstimateID;
                    long newEstID = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime dateTime = DateTime.Now;
                    EstimatesBasePage.estimate_copy_all(companyID1, estimateID1, newEstID, "estimate", "", dateTime.ToString(), ConnectionClass.IsHandy, 1);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "");
                    this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                    if (this.activityhist == null || !(this.activityhist == "yes"))
                    {
                        this.pnlcrmcopy.Visible = true;
                    }
                    else
                    {
                        EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "EstimateSamecustomerFrmCRM");
                        this.pnlcrmcopy.Visible = true;
                    }
                }
                if (this.Pgtype == "order")
                {
                    int num1 = this.CompanyID;
                    long estimateID2 = this.EstimateID;
                    long newEstID1 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime now1 = DateTime.Now;
                    EstimatesBasePage.estimate_copy_all(num1, estimateID2, newEstID1, "order", "", now1.ToString(), ConnectionClass.IsHandy, 1);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "");
                    this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                    if (this.activityhist == null || !(this.activityhist == "yes"))
                    {
                        this.pnlcrmcopy.Visible = true;
                        return;
                    }
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "EstimateSamecustomerFrmCRM");
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                if (this.Pgtype == "job")
                {
                    int companyID2 = this.CompanyID;
                    long num2 = this.jobID;
                    long newEstID2 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime dateTime1 = DateTime.Now;
                    this.NewJobID = EstimatesBasePage.estimate_copy_all(companyID2, num2, newEstID2, "job", "", dateTime1.ToString(), ConnectionClass.IsHandy, 1);
                    this.jID = string.Concat("&jID=", this.NewJobID);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "JobnotDirect");
                    this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                    if (this.activityhist != null && this.activityhist == "yes")
                    {
                        this.pnlcrmcopy.Visible = true;
                        return;
                    }
                    string empty = string.Empty;
                    foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                    {
                        empty = row["StatusID"].ToString();
                    }
                    Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                    this.SummaryClassObj.IsJobCopied = true;
                    this.SummaryClassObj.Call_Inventory_Adjustment("progressed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    else if (this.ReduceStockType.ToLower() == empty.ToString())
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", (long)0, this.NewJobID);
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                if (this.Pgtype == "invoice")
                {
                    int companyID3 = this.CompanyID;
                    long invoiceID = this.InvoiceID;
                    long newEstID3 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime now2 = DateTime.Now;
                    this.NewInvoiceID = EstimatesBasePage.estimate_copy_all(companyID3, invoiceID, newEstID3, "invoice", "", now2.ToString(), ConnectionClass.IsHandy, 1);
                    this.InvID = string.Concat("&InvID=", this.NewInvoiceID);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "InvoicenotDirect");
                    if (this.IsProformaInvoice == "True")
                    {
                        EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "ProformaInvoice");
                    }
                    this.Activity_history_insert(this.Pgtype, this.InvoiceID, this.NewInvoiceID);
                    if (this.activityhist != null && this.activityhist == "yes")
                    {
                        this.pnlcrmcopy.Visible = true;
                        return;
                    }
                    Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                    this.SummaryClassObj.IsJobCopied = true;
                    string str = "0";
                    foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                    {
                        str = dataRow["StatusID"].ToString();
                    }
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str), "job", (long)0, this.EstimateID);
                    this.SummaryClassObj.Call_Inventory_Adjustment("progressed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    else if (this.ReduceStockType.ToLower() == "i")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    else if (this.ReduceStockType.ToString() == str.ToString())
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
            }
            else if (this.rdnCopyNo.Checked)
            {
                if (this.Pgtype == "job")
                {
                    int num3 = this.CompanyID;
                    long estimateID3 = this.EstimateID;
                    int userID1 = this.UserID;
                    DateTime dateTime2 = DateTime.Now;
                    Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(num3, estimateID3, "Direct Job", userID1, dateTime2.ToString(), ConnectionClass.IsHandy, this.Pgtype, this.jobID);
                    EstimatesBasePage.Update_customer_details_forNew_copy_estimate(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, Convert.ToInt64(this.hid_ClientID.Value), Convert.ToInt64(this.hdn_Attention.Value), Convert.ToString(this.hid_Greeting.Value), this.objBC.SpecialDecode(Convert.ToString(this.hid_CustName.Value)), Convert.ToInt64(this.hid_contactId.Value), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.UserID, Convert.ToInt64(this.hdn_InvAddressID.Value));
                    int companyID4 = this.CompanyID;
                    long num4 = this.jobID;
                    long newEstID4 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime now3 = DateTime.Now;
                    this.NewJobID = EstimatesBasePage.estimate_copy_all(companyID4, num4, newEstID4, "job", "Direct Job", now3.ToString(), ConnectionClass.IsHandy, 1);
                    this.jID = string.Concat("&jID=", this.NewJobID);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "jobdirect");
                    this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                    if (this.activityhist != null && this.activityhist == "yes")
                    {
                        this.pnlcrmcopy.Visible = true;
                        return;
                    }
                    string empty1 = string.Empty;
                    foreach (DataRow row1 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                    {
                        empty1 = row1["StatusID"].ToString();
                    }
                    Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                    this.SummaryClassObj.IsJobCopied = true;
                    this.SummaryClassObj.Call_Inventory_Adjustment("progressed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    else if (this.ReduceStockType.ToLower() == empty1.ToString())
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty1), "job", (long)0, this.NewJobID);
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                if (this.Pgtype == "invoice")
                {
                    int companyID5 = this.CompanyID;
                    long estimateID4 = this.EstimateID;
                    int userID2 = this.UserID;
                    DateTime dateTime3 = DateTime.Now;
                    Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID5, estimateID4, "DirectInvoice", userID2, dateTime3.ToString(), ConnectionClass.IsHandy, this.Pgtype, this.InvoiceID);
                    EstimatesBasePage.Update_customer_details_forNew_copy_estimate(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, Convert.ToInt64(this.hid_ClientID.Value), Convert.ToInt64(this.hdn_Attention.Value), Convert.ToString(this.hid_Greeting.Value), this.objBC.SpecialDecode(Convert.ToString(this.hid_CustName.Value)), Convert.ToInt64(this.hid_contactId.Value), Convert.ToInt64(this.hid_DeliveryAddressID.Value), this.UserID, Convert.ToInt64(this.hdn_InvAddressID.Value));
                    int num5 = this.CompanyID;
                    long invoiceID1 = this.InvoiceID;
                    long newEstID5 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                    DateTime now4 = DateTime.Now;
                    this.NewInvoiceID = EstimatesBasePage.estimate_copy_all(num5, invoiceID1, newEstID5, "invoice", "DirectInvoice", now4.ToString(), ConnectionClass.IsHandy, 1);
                    this.InvID = string.Concat("&InvID=", this.NewInvoiceID);
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "InvoiceDirect");
                    this.Activity_history_insert(this.Pgtype, this.InvoiceID, this.NewInvoiceID);
                    if (this.activityhist != null && this.activityhist == "yes")
                    {
                        this.pnlcrmcopy.Visible = true;
                        return;
                    }
                    Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                    this.SummaryClassObj.IsJobCopied = true;
                    string str1 = "0";
                    foreach (DataRow dataRow1 in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                    {
                        str1 = dataRow1["StatusID"].ToString();
                    }
                    this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str1), "job", (long)0, this.EstimateID);
                    this.SummaryClassObj.Call_Inventory_Adjustment("progressed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    if (this.ReduceStockType.ToLower() == "e")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    else if (this.ReduceStockType.ToLower() == "i" || this.hdnisStock_Reduce.Value == "yes")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("completed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                    }
                    this.pnlcrmcopy.Visible = true;
                }
            }
        }

        public void lnkEstimateCopyToSameCustArchive_OnClick(object sender, EventArgs e)
        {
            Item_Summary_CopytoNew_SameCustomer.NewEstID = (long)0;
            if (base.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            }
            long estimateID = (long)0;
            if (this.Pgtype == "estimate")
            {
                estimateID = this.EstimateID;
            }
            else if (this.Pgtype == "order")
            {
                estimateID = this.EstimateID;
            }
            else if (this.Pgtype == "job")
            {
                estimateID = this.jobID;
            }
            else if (this.Pgtype == "invoice")
            {
                estimateID = this.InvoiceID;
            }
            int companyID = this.CompanyID;
            long num = this.EstimateID;
            int userID = this.UserID;
            DateTime now = DateTime.Now;
            
            DateTime Estimateartworkdate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat,this.commclass.setDateAfterAddedDay(this.CompanyID, "ArtworkDate")));
            DateTime Estimatedeliverydate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "DeliveryDate")));
            DateTime JobCompletionDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat,this.commclass.setDateAfterAddedDay(this.CompanyID, "CompletionDate")));
            DateTime ProofDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ProofDate")));
            DateTime ApprovalDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ApprovalDate")));
            DateTime ProductionDate = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.commclass.setDateAfterAddedDay(this.CompanyID, "ProductionDate")));



            //DateTime Estimateartworkdate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"ArtworkDate"));
            //DateTime Estimatedeliverydate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"DeliveryDate"));
            //DateTime JobCompletionDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"CompletionDate"));
            //DateTime ProofDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"ProofDate"));
            //DateTime ApprovalDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"ApprovalDate"));
            //DateTime ProductionDate = Convert.ToDateTime(this.commclass.setDateAfterAddedDay(this.CompanyID,"ProductionDate"));

            Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.EstimateCopyEstimateInsert(companyID, num, "", userID, now.ToString(), ConnectionClass.IsHandy, this.Pgtype, estimateID, Estimateartworkdate, Estimatedeliverydate, JobCompletionDate, ProofDate, ApprovalDate, ProductionDate);
            //Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID, num, "", userID, now.ToString(), ConnectionClass.IsHandy, this.Pgtype, estimateID);
            this.objCom.settings_lastcounter_update(this.CompanyID, "e", (long)0);
            if (this.Pgtype == "estimate")
            {
                int companyID1 = this.CompanyID;
                long estimateID1 = this.EstimateID;
                long newEstID = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime dateTime = DateTime.Now;
                EstimatesBasePage.estimate_copy_all(companyID1, estimateID1, newEstID, "estimate", "", dateTime.ToString(), ConnectionClass.IsHandy, 0);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "");
                this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                if (this.activityhist == null || !(this.activityhist == "yes"))
                {
                    HttpResponse response = base.Response;
                    object[] objArray = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?suc=cop&ordid=", Item_Summary_CopytoNew_SameCustomer.NewEstID, "&estid=", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.jID, this.InvID };
                    response.Redirect(string.Concat(objArray));
                }
                else
                {
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "EstimateSamecustomerFrmCRM");
                    this.pnlcrmcopy.Visible = true;
                }
            }
            if (this.Pgtype == "order")
            {
                int num1 = this.CompanyID;
                long estimateID2 = this.EstimateID;
                long newEstID1 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime now1 = DateTime.Now;
                EstimatesBasePage.estimate_copy_all(num1, estimateID2, newEstID1, "order", "", now1.ToString(), ConnectionClass.IsHandy, 0);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "");
                this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                if (this.activityhist != null && this.activityhist == "yes")
                {
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "EstimateSamecustomerFrmCRM");
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                HttpResponse httpResponse = base.Response;
                object[] objArray1 = new object[] { this.strSitepath, "orders/order_summary.aspx?suc=cop&ordid=", Item_Summary_CopytoNew_SameCustomer.NewEstID, "&estid=", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.jID, this.InvID };
                httpResponse.Redirect(string.Concat(objArray1));
                return;
            }
            if (this.Pgtype == "job")
            {
                int companyID2 = this.CompanyID;
                long num2 = this.jobID;
                long newEstID2 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime dateTime1 = DateTime.Now;
                this.NewJobID = EstimatesBasePage.estimate_copy_all(companyID2, num2, newEstID2, "job", "", dateTime1.ToString(), ConnectionClass.IsHandy, 0);
                this.jID = string.Concat("&jID=", this.NewJobID);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "jobnotdirect");
                this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                if (this.activityhist != null && this.activityhist == "yes")
                {
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                string empty = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                {
                    empty = row["StatusID"].ToString();
                }
                Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                this.SummaryClassObj.IsJobCopied = true;
                this.SummaryClassObj.Call_Inventory_Adjustment("progressed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == empty.ToString())
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", (long)0, this.NewJobID);
                this.pnlcrmcopy.Visible = true;
                return;
            }
            if (this.Pgtype == "invoice")
            {
                int companyID3 = this.CompanyID;
                long invoiceID = this.InvoiceID;
                long newEstID3 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime now2 = DateTime.Now;
                this.NewInvoiceID = EstimatesBasePage.estimate_copy_all(companyID3, invoiceID, newEstID3, "invoice", "", now2.ToString(), ConnectionClass.IsHandy, 0);
                this.InvID = string.Concat("&InvID=", this.NewInvoiceID);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "InvoicenotDirect");
                if (this.IsProformaInvoice == "True")
                {
                    EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "ProformaInvoice");
                }
                this.Activity_history_insert(this.Pgtype, this.InvoiceID, this.NewInvoiceID);
                if (this.activityhist != null && this.activityhist == "yes")
                {
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                this.SummaryClassObj.IsJobCopied = true;
                string str = "0";
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                {
                    str = dataRow["StatusID"].ToString();
                }
                this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, Convert.ToInt32(str), "job", (long)0, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                this.SummaryClassObj.Call_Inventory_Adjustment("progressed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "i" || this.hdnisStock_Reduce.Value == "yes")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                else if (this.ReduceStockType.ToString() == str.ToString())
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                this.pnlcrmcopy.Visible = true;
            }
        }

        public void lnkEstimateCopytoSameCustUnArchive_OnClick(object sender, EventArgs e)
        {
            if (base.Session["UserID"] != null)
            {
                this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            }
            if (this.Pgtype == "job")
            {
                int companyID = this.CompanyID;
                long estimateID = this.EstimateID;
                int userID = this.UserID;
                DateTime now = DateTime.Now;
                Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID, estimateID, "DirectJOb", userID, now.ToString(), ConnectionClass.IsHandy, this.Pgtype, this.jobID);
                int num = this.CompanyID;
                long num1 = this.jobID;
                long newEstID = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime dateTime = DateTime.Now;
                this.NewJobID = EstimatesBasePage.estimate_copy_all(num, num1, newEstID, "job", "DirectJOb", dateTime.ToString(), ConnectionClass.IsHandy, 0);
                this.jID = string.Concat("&jID=", this.NewJobID);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "jobdirect");
                this.Activity_history_insert(this.Pgtype, this.EstimateID, Item_Summary_CopytoNew_SameCustomer.NewEstID);
                if (this.activityhist != null && this.activityhist == "yes")
                {
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                string empty = string.Empty;
                foreach (DataRow row in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                {
                    empty = row["StatusID"].ToString();
                }
                Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                this.SummaryClassObj.IsJobCopied = true;
                this.SummaryClassObj.Call_Inventory_Adjustment("progressed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == empty.ToString())
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(empty), "job", (long)0, this.NewJobID);
                this.pnlcrmcopy.Visible = true;
                return;
            }
            if (this.Pgtype == "invoice")
            {
                int companyID1 = this.CompanyID;
                long estimateID1 = this.EstimateID;
                int userID1 = this.UserID;
                DateTime now1 = DateTime.Now;
                Item_Summary_CopytoNew_SameCustomer.NewEstID = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID1, estimateID1, "DirectInvoice", userID1, now1.ToString(), ConnectionClass.IsHandy, this.Pgtype, this.InvoiceID);
                int companyID2 = this.CompanyID;
                long invoiceID = this.InvoiceID;
                long newEstID1 = Item_Summary_CopytoNew_SameCustomer.NewEstID;
                DateTime dateTime1 = DateTime.Now;
                this.NewInvoiceID = EstimatesBasePage.estimate_copy_all(companyID2, invoiceID, newEstID1, "invoice", "DirectInvoice", dateTime1.ToString(), ConnectionClass.IsHandy, 0);
                this.InvID = string.Concat("&InvID=", this.NewInvoiceID);
                EstimatesBasePage.copyJobInvoice_isdirect(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID, "InvoiceDirect");
                this.Activity_history_insert(this.Pgtype, this.InvoiceID, this.NewInvoiceID);
                if (this.activityhist != null && this.activityhist == "yes")
                {
                    this.pnlcrmcopy.Visible = true;
                    return;
                }
                Item_Summary_CopytoNew_SameCustomer.IsJobCopied = true;
                this.SummaryClassObj.IsJobCopied = true;
                this.SummaryClassObj.Call_Inventory_Adjustment("progressed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                if (this.ReduceStockType.ToLower() == "e")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                else if (this.ReduceStockType.ToLower() == "i" || this.hdnisStock_Reduce.Value == "yes")
                {
                    this.SummaryClassObj.Call_Inventory_Adjustment("completed-invoice", Item_Summary_CopytoNew_SameCustomer.NewEstID, this.CompanyID, this.Estimateitemid_directjob, this.UserID);
                }
                string str = "0";
                foreach (DataRow dataRow in JobBasePage.Job_Select_By_EstimateID(this.CompanyID, Item_Summary_CopytoNew_SameCustomer.NewEstID).Rows)
                {
                    str = dataRow["StatusID"].ToString();
                }
                this.commclass.SendMailOnJobStatusChange_Item(this.CompanyID, this.EstimateID, Convert.ToInt32(str), "job", (long)0, this.EstimateID);
                this.pnlcrmcopy.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            if (base.Request.QueryString["jID"] != null)
            {
                this.jobID = Convert.ToInt64(base.Request.Params["jID"]);
            }
            if (base.Request.QueryString["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (this.jobID != (long)0)
            {
                this.jID = string.Concat("&jID=", this.jobID);
            }
            if (this.InvoiceID != (long)0)
            {
                this.InvID = string.Concat("&InvID=", this.InvoiceID);
            }
            if (base.Request.Params["pg"] != null)
            {
                if (base.Request.Params["pg"].ToString().ToLower() == "job")
                {
                    this.Module = "job";
                    this.Pgtype = "job";
                }
                else if (base.Request.Params["pg"].ToString().ToLower() == "invoice")
                {
                    this.Module = "invoice";
                    this.Pgtype = "invoice";
                }
                else if (base.Request.Params["pg"].ToString().ToLower() != "order")
                {
                    this.Module = "estimate";
                    this.Pgtype = "estimate";
                }
                else
                {
                    this.Module = "order";
                    this.Pgtype = "order";
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                this.Module = "job";
                this.Pgtype = "job";
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Module = "invoice";
                this.Pgtype = "invoice";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                this.Module = "estimate";
                this.Pgtype = "estimate";
            }
            else
            {
                this.Module = "order";
                this.Pgtype = "order";
            }
            if (!base.IsPostBack && base.Request.Params["type"] != null)
            {
                if (base.Request.Params["type"].ToString().ToLower() == "copytonewcust")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:EstimateCopyto_NewCust_Controls('", this.Module, "');"), true);
                }
                else if (base.Request.Params["type"].ToString().ToLower() == "copytosamecust")
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("javascript:alert_CopyJobInvoicetoSameConfirm('", this.Module, "');"), true);
                }
            }
            this.txtName.Attributes.Add("autocomplete", "off");
            this.txtName.Attributes.Add("onkeyup", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
            this.txtName.Attributes.Add("onclick", string.Concat("javascript:displayClient(this,'customer','", this.CompanyID, "','1',event);"));
            if (ConnectionClass.Ordernumbervalidtiononlyforcoralcoastsystem != null)
            {
                this.Ordernumbervalidtiononlyforcoralcoastsystem = "yes";
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (base.Request.QueryString["acthist"] != null)
            {
                this.activityhist = base.Request.QueryString["acthist"].ToString().ToLower();
            }
            if (base.Request.QueryString["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.QueryString["estid"].ToString());
            }
            DataTable dataTable = new DataTable();
            if (this.EstimateID != (long)0)
            {
                dataTable = EstimatesBasePage.estimate_select_summary_new(this.CompanyID, this.EstimateID);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsProformaInvoice = row["IsProformaInvoice"].ToString();
                    this.estimateconvertedtojob = row["IsConvertedTojob"].ToString();
                    this.CompanyType = row["CompanyType"].ToString();
                    this.isdirectjob = row["isdirectjob"].ToString();
                    this.Estimateitemid_directjob = Convert.ToInt64(row["EstimateItemID"].ToString());
                }
            }
        }
    }
}