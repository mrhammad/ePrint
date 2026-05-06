using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Inventories;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Order;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.common
{
    public partial class Invoice_Paid_View :  System.Web.UI.Page, IRequiresSessionState
    {

        protected HiddenField hdnHeader;

        protected HiddenField hdnEstimatIds;

        protected HiddenField hdnEstimateID;

        protected HiddenField hdnPaymentMode;

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass commclass = new commonClass();

        public string strSitepath = global.sitePath();

        private BaseClass objBc = new BaseClass();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        private SummaryClass SummaryClassObj = new SummaryClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        private CompanyBasePage objCom = new CompanyBasePage();

        private BaseClass objBC = new BaseClass();

        private BasePage objpage = new BasePage();

        public string strImagepath = global.imagePath();

        public string strSitePath = global.sitePath();

        public static languageClass objLanguage;

        private string EstStatus = string.Empty;

        public string strTodayDate = string.Empty;

        public static string Module;

        public string Pgtype = "estimate";

        public long EstimateID;

        public long InvoiceID;

        public string SelectedIDs = "";

        public string ItemIDs = "";

        public string EstimateIDs = "";

        public string JobIDs = "";

        public int CompanyID;

        public int UserID;

        public static long PDID;

        private string InvoiceStatus = string.Empty;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public int ISInventoryReduced;

        public long InvoiceID__fromdb_ispaid;

        public static bool IsJobCopied;

        public static long NewEstID;

        public string DateFormat = string.Empty;

        public string IsFrom = string.Empty;

        public static string SalesPersonID;

        public static string IsEditOnlyHisRecords;

        public string IsPaid = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public static int[] MoreEstimateID;

        private int[] ViewSelectedEstimateID = new int[2];

        public static int[] InvoiceIDsFMMain;

        public static int[] JobIDsFMMain;

        public static int[] EstimateIDsFMMain;

        private long InvoiceNum;

        private DateTime TodayDate;

        private string UserName = string.Empty;

        public string PaperMeasure = string.Empty;

        public int OrderID;

        public string Ispaidenable = string.Empty;

        private Hashtable htInventory = new Hashtable();

        public decimal OutStandingAmount;

        public decimal TotalInvoiceSellingPrice;

        public decimal AmountPaid;

        public decimal TotalAmountPaid;

        public string ModuleType = string.Empty;

        public string AddorEdit = string.Empty;

        public string EditAmount = string.Empty;

        public string EditPaymentMode = string.Empty;

        public string NewEdit = string.Empty;

        public decimal OutStandingAmount1;

        public string btnvalue = string.Empty;

        private string sum = "0";

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

        static Invoice_Paid_View()
        {
            Invoice_Paid_View.objLanguage = new languageClass();
            Invoice_Paid_View.Module = "estimate";
            Invoice_Paid_View.PDID = (long)0;
            Invoice_Paid_View.IsJobCopied = false;
            Invoice_Paid_View.NewEstID = (long)0;
            Invoice_Paid_View.SalesPersonID = string.Empty;
            Invoice_Paid_View.IsEditOnlyHisRecords = string.Empty;
            Invoice_Paid_View.MoreEstimateID = new int[2];
            Invoice_Paid_View.InvoiceIDsFMMain = new int[2];
            Invoice_Paid_View.JobIDsFMMain = new int[2];
            Invoice_Paid_View.EstimateIDsFMMain = new int[2];
        }

        public Invoice_Paid_View()
        {
        }

        private void Adjust_Inventory_On_Job_Complete(DataSet ds, string StrJobNum, int StatusID, long EstID, Hashtable htInventory, long EstimteItemID, string JobStatus)
        {
            SummaryClass.SubItem_Inventory_Update(ds, StrJobNum, StatusID, EstID, this.UserID, this.CompanyID, JobStatus, htInventory, EstimteItemID);
        }

        public void BindInvoicePaidRecords()
        {
            DataTable dataTable = new DataTable();
            if (base.Request.Params["OrderID"] != null)
            {
                this.OrderID = Convert.ToInt16(base.Request.Params["OrderID"].ToString());
            }
            dataTable = (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0") ? InvoiceBasePage.InvoicePaid_HistoryDetails_Select(this.CompanyID, this.EstimateID) : InvoiceBasePage.OrderDetails_select(this.CompanyID, (long)this.OrderID));
            this.RadGrid2.DataSource = dataTable;
            this.RadGrid2.DataBind();
            IEnumerator enumerator = dataTable.Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    this.TotalAmountPaid = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(current["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            if (dataTable.Rows.Count != 0)
            {
                this.RadGrid2.Visible = true;
                this.divrecordpayment.Style.Add("display", "block");
                this.divMessage.Style.Add("display", "none");
                if (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0"))
                {
                    this.spnlnk.InnerText = Invoice_Paid_View.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                }
                else
                {
                    this.divMessage.Style.Add("display", "none");
                    this.div_linkclick.Style.Add("display", "none");
                }
            }
            else
            {
                this.RadGrid2.Visible = false;
                this.divrecordpayment.Style.Add("display", "none");
                this.divMessage.Style.Add("display", "block");
                this.divbtnrecord.Style.Add("display", "none");
                this.divpaymentradio.Style.Add("display", "none");
                this.divamountpaidshowhide.Style.Add("display", "none");
                this.PaidYesNo.Style.Add("display", "none");
                this.divUpdateMain.Style.Add("display", "none");
                this.spnlnk.InnerText = Invoice_Paid_View.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
            }
            if (base.IsPostBack)
            {
                this.plhamountpaid.Controls.Clear();
                DataTable dataTable1 = new DataTable();
                if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary" || base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" && base.Request.Params["IsJobFromWebstore"].ToString().ToLower() == "0")
                {
                    if (base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
                    {
                        this.ModuleType = "jobrecordview";
                    }
                    else
                    {
                        this.ModuleType = "invoicesummary";
                    }
                    dataTable1 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "");
                    foreach (DataRow row in dataTable1.Rows)
                    {
                        this.hdnPTfordelete.Value = row["PaymentType"].ToString();
                        this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalSellingPrice"]), 0, "", false, false, true, false, true));
                        if (dataTable.Rows.Count != 0)
                        {
                            this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                        else
                        {
                            this.OutStandingAmount = this.TotalInvoiceSellingPrice;
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                        if (row["InvoiceNumber"].ToString() == "0")
                        {
                            continue;
                        }
                        this.plhamountpaid.Visible = false;
                        this.divInvDetails.Visible = true;
                        this.lblinvoicenovalue.Text = row["InvoiceNumber"].ToString();
                        this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(row["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblCustomervalue.Text = this.objBC.SpecialDecode(row["CompanyName"].ToString());
                        this.lblPaymentTermsvalue.Text = string.Concat(row["PaymentName"].ToString(), " (", row["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
                        if (this.OutStandingAmount > new decimal(0))
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Red;
                            this.lblOutStandingvalue.Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true);
                        }
                        else if (this.OutStandingAmount != new decimal(0))
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Green;
                            this.lblOutStandingvalue.Text = string.Concat("(", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true), ")");
                        }
                        else
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Black;
                            this.lblOutStandingvalue.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Nill");
                        }
                    }
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary" || base.Request.Params["Module"].ToString().ToLower() == "ordersummary" || base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" && base.Request.Params["IsJobFromWebstore"].ToString().ToLower() == "1" || base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                {
                    if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                    {
                        this.ModuleType = "orderinvoicesummary";
                    }
                    if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview")
                    {
                        this.ModuleType = "jobrecordview";
                    }
                    if (base.Request.Params["Module"].ToString().ToLower() != "ojsummary")
                    {
                        this.ModuleType = "ordersummary";
                    }
                    else
                    {
                        this.ModuleType = "ojsummary";
                    }
                    dataTable1 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "orderinvoicesummary");
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.hdnPTfordelete.Value = dataRow["PaymentType"].ToString();
                        this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalSellingPrice"]), 0, "", false, false, true, false, true));
                        if (dataTable.Rows.Count != 0)
                        {
                            this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                        else
                        {
                            this.OutStandingAmount = this.TotalInvoiceSellingPrice;
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                        if (dataRow["InvoiceNumber"].ToString() == "0")
                        {
                            continue;
                        }
                        this.plhamountpaid.Visible = false;
                        this.divInvDetails.Visible = true;
                        this.lblinvoicenovalue.Text = dataRow["InvoiceNumber"].ToString();
                        this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(dataRow["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblCustomervalue.Text = this.objBC.SpecialDecode(dataRow["CompanyName"].ToString());
                        this.lblPaymentTermsvalue.Text = string.Concat(dataRow["PaymentName"].ToString(), " (", dataRow["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
                        if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0")
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Black;
                            this.lblOutStandingvalue.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Nill");
                        }
                        else if (this.OutStandingAmount > new decimal(0))
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Red;
                            this.lblOutStandingvalue.Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true);
                        }
                        else if (this.OutStandingAmount != new decimal(0))
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Green;
                            this.lblOutStandingvalue.Text = string.Concat("(", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true), ")");
                        }
                        else
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Black;
                            this.lblOutStandingvalue.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Nill");
                        }
                    }
                }
                if (this.btnvalue != "")
                {
                    this.hdnbtnvalue.Value = this.btnvalue;
                    this.hdnEstimateIDforUpdate.Value = this.EstimateID.ToString();
                    this.hdntotsellingpriceforUpdate.Value = this.TotalInvoiceSellingPrice.ToString();
                    this.hdnoutstangimgforupdate.Value = this.OutStandingAmount.ToString();
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "UpdateIspaid();", true);
                }
            }
            this.lblamountpaidtextdisp.Text = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
        }

        protected void BtnContinue_onclick(object sender, EventArgs e)
        {
            int num = 0;
            DataTable dataTable = JobBasePage.Jobs_Jobcard_Jobdetails_select(this.CompanyID, this.EstimateID);
            if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["isconverted"] != null)
            {
                num = Convert.ToInt32(dataTable.Rows[0]["isconverted"]);
            }
            if (num != 0)
            {
                this.div_invopmnt.Style.Add("display", "none");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "alert('This Job is already progressed to an invoice and hence cannot be progressed again.');Close();", true);
                return;
            }
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate.Text));
            this.InvoiceNum = this.objCom.settings_lastcounter_select(Convert.ToInt32(this.Session["CompanyID"]), "i");
            long invoiceNum = (long)10000000 + this.InvoiceNum;
            string str = string.Concat(ConnectionClass.InvoicePrefix, invoiceNum.ToString().Substring(1, invoiceNum.ToString().Length - 1));
            int num1 = 0;
            int num2 = 0;
            string empty = string.Empty;
            string text = string.Empty;
            string str1 = "";
            if (this.ddl_year_module.SelectedIndex != 0)
            {
                num2 = Convert.ToInt16(this.ddl_year_module.SelectedItem.Text);
            }
            if (this.ddl_month_module.SelectedIndex != 0)
            {
                num1 = Convert.ToInt16(this.ddl_month_module.SelectedItem.Text);
            }
            if (this.rbnAmericanID_module.Checked)
            {
                str1 = "American";
            }
            else if (this.rbnVisaID_module.Checked)
            {
                str1 = "Visa";
            }
            else if (this.rbnMasterCardID_module.Checked)
            {
                str1 = "MasterCard";
            }
            else if (this.rbnDiscoverID_module.Checked)
            {
                str1 = "Discover";
            }
            if (this.txt_cardNumber_module.Text != "")
            {
                text = this.txt_cardNumber_module.Text;
            }
            if (this.txt_verification_module.Text != "")
            {
                empty = this.txt_verification_module.Text;
            }
            int num3 = 1;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
            {
                empty1 = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
            {
                empty2 = dataRow["PhraseText"].ToString();
            }
            int defaultStatusID = 0;
            int num4 = 0;
            long num5 = (long)0;
            for (int i = 0; i < (int)Invoice_Paid_View.MoreEstimateID.Length; i++)
            {
                if (Invoice_Paid_View.MoreEstimateID[i].ToString() != "0")
                {
                    if (this.hdnPaymentMode.Value == "Credit Card" || this.hdnPaymentMode.Value == "PayPal")
                    {
                        string str2 = string.Empty;
                        bool selected = this.rdopaymenttype_module.Items[2].Selected;
                        string str3 = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        if (this.hdnPaymentMode.Value == "Credit Card")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "4";
                        }
                        if (this.hdnPaymentMode.Value == "PayPal")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "7";
                        }
                        num5 = this.SummaryClassObj.ProgrssTo_Invoice(this.CompanyID, this.UserID, (long)Invoice_Paid_View.MoreEstimateID[i], str3, "Yes", this.txtInvoicePaymentDate.Text, this.ddl_Paymentmode_module.SelectedValue, this.txt_PaymentDetailNotes.Text, this.DateFormat, this.PaperMeasure, this.hdnPaymentMode.Value, num3);
                        if (this.InventoryManagement == "IM" && this.ReduceStockType.ToLower() != "e")
                        {
                            this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid_View.MoreEstimateID[i], num5);
                        }
                        if ((new BaseClass()).Return_StockManagementSettings("SR_WhenStockReduced") == "c")
                        {
                            this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid_View.MoreEstimateID[i], num5);
                        }
                    }
                    else
                    {
                        defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "invoice", Convert.ToInt32(Invoice_Paid_View.MoreEstimateID[i]));
                        int num6 = 0;
                        char chr = 'C';
                        DataTable clientDefaultInvoiceDetails = InvoiceBasePage.GetClientDefaultInvoiceDetails(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid_View.MoreEstimateID[i]);
                        foreach (DataRow row1 in clientDefaultInvoiceDetails.Rows)
                        {
                            num6 = Convert.ToInt32(row1["InvoiceAddressID"].ToString());
                            chr = Convert.ToChar(row1["InvoiceAddressType"].ToString());
                        }
                        commonClass _commonClass1 = this.commclass;
                        DateTime now = DateTime.Now;
                        _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
                        try
                        {
                            this.TodayDate = DateTime.Now;
                        }
                        catch
                        {
                        }
                        if (!this.rdopaymenttype_module.Items[2].Selected)
                        {
                            int num7 = 0;
                            num7 = 1;
                            num4 = InvoiceBasePage.invoice_insert_ispaid(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid_View.MoreEstimateID[i], str, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(this.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty1), this.objBC.ReplaceSingleQuote(empty2), num7, ConnectionClass.IsHandy, num6, chr, num6);                                   
                            Invoice_Paid_View.PDID = (long)0;
                            //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, (long)num4, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_module.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_module.Text, this.txt_HolderName_module.Text, str1, num1, num2, empty, text, Convert.ToDecimal(this.txtamtpaid_module.Text));
                            InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, (long)num4, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_module.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_module.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtamtpaid_module.Text));
                            InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid_View.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_module.SelectedItem.Text);
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInvPayment);
                            num5 = (long)num4;
                        }
                        else
                        {
                            int paymentDetailsFromEstimateID = InvoiceBasePage.Get_PaymentDetails_From_EstimateID((long)Invoice_Paid_View.MoreEstimateID[i]);
                            DateTime dateTime1 = DateTime.Now.AddDays((double)paymentDetailsFromEstimateID);
                            num5 = InvoiceBasePage.Invoice_insert(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid_View.MoreEstimateID[i], str, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(this.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty1), this.objBC.ReplaceSingleQuote(empty2), 0, ConnectionClass.IsHandy, num6, chr, num6, dateTime1, (long)0, "Pending", null,null,null,null,null);                            
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                        }
                        string empty3 = string.Empty;
                        string empty4 = string.Empty;
                        string str4 = string.Empty;
                        string empty5 = string.Empty;
                        DataTable dataTable1 = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, (long)Invoice_Paid_View.MoreEstimateID[i], "", (long)0);
                        foreach (DataRow dataRow1 in dataTable1.Rows)
                        {
                            empty4 = dataRow1["Estimatenumber"].ToString();
                            str4 = dataRow1["jobnumber"].ToString();
                            empty5 = dataRow1["invoicenumber"].ToString();
                        }
                        if (num3 == 1)
                        {
                            str4 = string.Concat(str4, "<b>(Job Active)</b>");
                        }
                        this.objnotes.Estimate_number = empty4;
                        this.objnotes.Job_number = str4;
                        this.objnotes.Invoice_number = empty5;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.ModuleID = (long)Invoice_Paid_View.MoreEstimateID[i];
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass2 = this.commclass;
                        DateTime now1 = DateTime.Now;
                        _notesclass.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        if (this.InventoryManagement == "IM" && this.ReduceStockType.ToLower() != "e")
                        {
                            this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid_View.MoreEstimateID[i], num5);
                        }
                        if ((new BaseClass()).Return_StockManagementSettings("SR_WhenStockReduced") == "c")
                        {
                            this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid_View.MoreEstimateID[i], num5);
                        }
                    }
                }
                this.Session["CreateNewInvoice"] = "true";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
            }
        }

        public void BtnPay_onclick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate.Text));
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            string str = "";
            string text = string.Empty;
            if (this.ddl_year.SelectedIndex != 0)
            {
                num1 = Convert.ToInt16(this.ddl_year.SelectedItem.Text);
            }
            if (this.ddl_month.SelectedIndex != 0)
            {
                num = Convert.ToInt16(this.ddl_month.SelectedItem.Text);
            }
            if (this.rbnAmericanID.Checked)
            {
                str = "American";
            }
            else if (this.rbnVisaID.Checked)
            {
                str = "Visa";
            }
            else if (this.rbnMasterCardID.Checked)
            {
                str = "MasterCard";
            }
            else if (this.rbnDiscoverID.Checked)
            {
                str = "Discover";
            }
            if (this.txt_cardNumber.Text != "")
            {
                empty = this.txt_cardNumber.Text;
            }
            if (this.txt_verification.Text != "")
            {
                text = this.txt_verification.Text;
            }
            for (int i = 0; i < (int)Invoice_Paid_View.EstimateIDsFMMain.Length - 1; i++)
            {
                if (base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
                {
                    if (Invoice_Paid_View.EstimateIDsFMMain[i].ToString() != "0")
                    {
                        this.InvoiceID__fromdb_ispaid = (long)Invoice_Paid_View.InvoiceIDsFMMain[i];
                        long estimateIDsFMMain = (long)0;
                        DataTable dataTable = new DataTable();
                        estimateIDsFMMain = (long)Invoice_Paid_View.EstimateIDsFMMain[i];
                        //dataTable = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(this.InvoiceID__fromdb_ispaid, estimateIDsFMMain, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text, this.txt_HolderName.Text, str, num, num1, text, empty);
                        dataTable = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(this.InvoiceID__fromdb_ispaid, estimateIDsFMMain, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text,"","",0,0,"","");
                        if (Convert.ToInt32(dataTable.Rows[0]["returnid"]) > 0)
                        {
                            string empty1 = string.Empty;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvfullPaidMain);
                            this.objnotes.Payment_Type = "In Full";
                            this.objnotes.Amount_Paid = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable.Rows[0]["Outstandingamt"]), 0, "", false, false, true, false, true).ToString();
                            this.objnotes.ModuleName = "invoice";
                            this.objnotes.ModuleID = estimateIDsFMMain;
                            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                            notesclass _notesclass = this.objnotes;
                            commonClass _commonClass1 = this.commclass;
                            DateTime now = DateTime.Now;
                            _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                            this.objnotes.CompanyID = this.CompanyID;
                            this.objnotes.UserID = this.UserID;
                            this.objN.NotesAdd(this.objnotes);
                        }
                    }
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "job_view" && Invoice_Paid_View.EstimateIDsFMMain[i].ToString() != "0")
                {
                    DataTable dataTable1 = new DataTable();
                    Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                    DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("select i.InvoiceID from tb_invoice i where i.IsDeleted=0 and i.EstimateID in (SELECT J.EstimateID FROM tb_job J WHERE J.IsDeleted=0 and J.jobid =", Invoice_Paid_View.JobIDsFMMain[i], ")"));
                    long num2 = (long)database.ExecuteScalar(sqlStringCommand);
                    long estimateIDsFMMain1 = (long)0;
                    estimateIDsFMMain1 = (long)Invoice_Paid_View.EstimateIDsFMMain[i];
                    //dataTable1 = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(num2, estimateIDsFMMain1, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text, this.txt_HolderName.Text, str, num, num1, text, empty);
                    dataTable1 = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(num2, estimateIDsFMMain1, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text,"","",0,0,"","");
                    if (Convert.ToInt32(dataTable1.Rows[0]["returnid"]) > 0)
                    {
                        string str1 = string.Empty;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvfullPaidMain);
                        this.objnotes.Payment_Type = "In Full";
                        this.objnotes.Amount_Paid = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable1.Rows[0]["Outstandingamt"]), 0, "", false, false, true, false, true).ToString();
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.ModuleID = estimateIDsFMMain1;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass1 = this.objnotes;
                        commonClass _commonClass2 = this.commclass;
                        DateTime now1 = DateTime.Now;
                        _notesclass1.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                    }
                }
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
        }

        public void BtnRecord_onclick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate_Add.Text));
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            string text = string.Empty;
            string str = "";
            if (this.ddl_year_Add.SelectedIndex != 0)
            {
                num1 = Convert.ToInt16(this.ddl_year_Add.SelectedItem.Text);
            }
            if (this.ddl_month_Add.SelectedIndex != 0)
            {
                num = Convert.ToInt16(this.ddl_month_Add.SelectedItem.Text);
            }
            if (this.rbnAmericanID_Add.Checked)
            {
                str = "American";
            }
            else if (this.rbnVisaID_Add.Checked)
            {
                str = "Visa";
            }
            else if (this.rbnMasterCardID_Add.Checked)
            {
                str = "MasterCard";
            }
            else if (this.rbnDiscoverID_Add.Checked)
            {
                str = "Discover";
            }
            if (this.txt_cardNumber_Add.Text != "")
            {
                text = this.txt_cardNumber_Add.Text;
            }
            if (this.txt_verification_Add.Text != "")
            {
                empty = this.txt_verification_Add.Text;
            }
            //InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.InvoiceID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
            InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.InvoiceID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
            BaseClass baseClass = new BaseClass();
            string empty1 = string.Empty;
            baseClass.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
            if (!this.rdopaymenttypeforaddedit.Items[0].Selected)
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPartPaid);
                this.objnotes.Payment_Type = "In Part";
            }
            else
            {
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvfullPaid);
                this.objnotes.Payment_Type = "In Full";
            }
            this.objnotes.Amount_Paid = this.txtAmtpaidAddedit.Text;
            string str1 = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.ModuleID = this.InvoiceID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CloseWindow(", this.InvoiceID, ");"), true);
        }

        public void btnUpdate_onclick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            string text = string.Empty;
            string str = "";
            string empty1 = string.Empty;
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate_Add.Text));
            if (Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value) == 4)
            {
                if (this.ddl_year_Add.SelectedIndex != 0)
                {
                    num1 = Convert.ToInt16(this.ddl_year_Add.SelectedItem.Text);
                }
                if (this.ddl_month_Add.SelectedIndex != 0)
                {
                    num = Convert.ToInt16(this.ddl_month_Add.SelectedItem.Text);
                }
                if (this.rbnAmericanID_Add.Checked)
                {
                    str = "American";
                }
                else if (this.rbnVisaID_Add.Checked)
                {
                    str = "Visa";
                }
                else if (this.rbnMasterCardID_Add.Checked)
                {
                    str = "MasterCard";
                }
                else if (this.rbnDiscoverID_Add.Checked)
                {
                    str = "Discover";
                }
                if (this.txt_cardNumber_Add.Text != "")
                {
                    text = this.txt_cardNumber_Add.Text;
                }
                if (this.txt_verification_Add.Text != "")
                {
                    empty = this.txt_verification_Add.Text;
                }
                if (this.txt_cardNumber_Add.Text != "")
                {
                    empty1 = this.txt_cardNumber_Add.Text;
                }
            }
            for (int i = 0; i < (int)Invoice_Paid_View.MoreEstimateID.Length; i++)
            {
                if (Invoice_Paid_View.MoreEstimateID[i].ToString() != "0")
                {
                    this.txtAmtpaidAddedit.Text = this.txtAmtpaidAddedit.Text;
                    foreach (DataRow row in InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, Invoice_Paid_View.PDID).Rows)
                    {
                        this.objnotes.Previous_Amount = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["AmountPaid"]), 0, "", false, false, true, false, true);
                    }
                    if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid_View.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid_View.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid_View.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" || base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid_View.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid_View.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid_View.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    BaseClass baseClass = new BaseClass();
                    string str1 = string.Empty;
                    baseClass.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
                    string empty2 = string.Empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPaymentUpdate);
                    this.objnotes.Amount_Paid = this.txtAmtpaidAddedit.Text;
                    this.objnotes.ModuleID = (long)Invoice_Paid_View.MoreEstimateID[i];
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass = this.objnotes;
                    commonClass _commonClass1 = this.commclass;
                    DateTime now = DateTime.Now;
                    _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                }
            }
            this.div_JobStatus.Style.Add("display", "none");
            this.divrecordpayment.Style.Add("display", "block");
            this.divpaymentradio.Style.Add("display", "none");
            this.divamountpaidshowhide.Style.Add("display", "none");
            this.PaidYesNo.Style.Add("display", "none");
            this.div_CreditCardDetails.Style.Add("display", "none");
            this.hdnpaymenttypeforupdate.Value = this.ddl_Paymentmode_Add.SelectedItem.Text;
            this.hdnpresentvalueforupdate.Value = this.txtAmtpaidAddedit.Text;
            this.btnvalue = "update";
            this.BindInvoicePaidRecords();
        }

        private string Call_Inventory_Adjustment(string JobStatus, long EstimateID, long InvoiceID)
        {
            object[] estimateID;
            string empty = string.Empty;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            dataTable = InvoiceBasePage.Job_Card_Info_Select_By_InvoiceID(InvoiceID);
            string str = string.Empty;
            string empty1 = string.Empty;
            int num = 0;
            string str1 = string.Empty;
            if (JobStatus == "completed-i")
            {
                JobStatus = "completed";
                str1 = "invoice";
            }
            if (JobStatus == "progressed-i")
            {
                JobStatus = "progressed";
                str1 = "invoice";
            }
            if (JobStatus == "reverted-i")
            {
                str1 = "invoice";
            }
            int num1 = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EstimateItemID"] == null)
                {
                    continue;
                }
                long num2 = Convert.ToInt64(row["EstimateItemID"]);
                int num3 = Convert.ToInt32(row["QtyNumber"]);
                string str2 = row["ItemType"].ToString();
                long num4 = (long)0;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                int num5 = 0;
                int num6 = 0;
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal printSheetCalulation = new decimal(0);
                decimal num10 = new decimal(0);
                string str3 = string.Empty;
                str = row["JobNumber"].ToString();
                num = Convert.ToInt32(row["StatusID"].ToString());
                if (row["InvoiceNumber"] != null)
                {
                    empty1 = row["InvoiceNumber"].ToString();
                }
                if (string.Compare(str2, "S", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow["PaperID"]);
                        empty2 = "I";
                        dataRow["InventoryCode"].ToString();
                        dataRow["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow["Quantity"]);
                        Convert.ToDecimal(dataRow["PackedIn"]);
                        Convert.ToInt64(dataRow["EstimateSingleItemID"]);
                        Convert.ToDecimal(dataRow["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "P", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row1["PaperID"]);
                        empty2 = "I";
                        row1["InventoryCode"].ToString();
                        row1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row1["Quantity"]);
                        Convert.ToDecimal(row1["PackedIn"]);
                        Convert.ToInt64(row1["EstimatePadItemID"]);
                        Convert.ToDecimal(row1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row1["RunningSpoilage"]);
                        Convert.ToDecimal(row1["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row1["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "L", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow1["PaperID"]);
                        empty2 = "I";
                        dataRow1["InventoryCode"].ToString();
                        dataRow1["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow1["Quantity"]);
                        Convert.ToDecimal(dataRow1["PackedIn"]);
                        Convert.ToInt64(dataRow1["EstimateLargeItemID"]);
                        Convert.ToDecimal(dataRow1["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow1["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow1["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow1["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow1["PaperMarkup"]);
                        Convert.ToDecimal(dataRow1["JobHeight"]);
                        Convert.ToDecimal(dataRow1["JobWidth"]);
                        Convert.ToDecimal(dataRow1["SheetHeight"]);
                        Convert.ToDecimal(dataRow1["SheetWidth"]);
                        Convert.ToDecimal(dataRow1["GutterHorizontal"]);
                        Convert.ToDecimal(dataRow1["GutterVertical"]);
                        Convert.ToDecimal(dataRow1["Row"]);
                        Convert.ToDecimal(dataRow1["Col"]);
                        dataRow1["PrintLayout"].ToString();
                        dataRow1["PressPaperType"].ToString();
                        num10 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["InvSheets"].ToString()), 0, "", false, false, true));
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, num10);
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, num10, JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "B", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables = new Hashtable();
                    foreach (DataRow row2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row2["PaperID"]);
                        empty2 = "I";
                        row2["InventoryCode"].ToString();
                        row2["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row2["Quantity"]);
                        Convert.ToDecimal(row2["PackedIn"]);
                        Convert.ToInt64(row2["EstimateBookletItemID"]);
                        Convert.ToDecimal(row2["PaperUnitPrice"]);
                        Convert.ToDecimal(row2["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row2["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row2["RunningSpoilage"]);
                        Convert.ToDecimal(row2["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row2["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        if (!hashtables.ContainsKey(num4))
                        {
                            hashtables.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables[num4] = Convert.ToInt32(hashtables[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key in hashtables.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key), empty2, Convert.ToInt32(hashtables[key]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "W", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    Hashtable hashtables1 = new Hashtable();
                    foreach (DataRow dataRow2 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow2["WarehouseTypeID"]);
                        empty2 = dataRow2["WarehouseType"].ToString();
                        num5 = Convert.ToInt32(dataRow2["Quantity"]);
                        if (Convert.ToInt32(dataRow2["IsDeleted"]) != 0)
                        {
                            continue;
                        }
                        if (!hashtables1.ContainsKey(num4))
                        {
                            hashtables1.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables1[num4] = Convert.ToInt32(hashtables1[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        num1 = num1 + this.SummaryClassObj.Select_Quantity_History_For_Inventory(num2);
                    }
                    if (hashtables1.Count > 0)
                    {
                        foreach (long key1 in hashtables1.Keys)
                        {
                            EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key1), empty2, Convert.ToInt32(hashtables1[key1]), JobStatus, num2);
                        }
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "O", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "C", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num11 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row3["Quantity"]);
                        decimal num12 = Convert.ToDecimal(row3["Price"]);
                        BaseClass baseClass = new BaseClass();
                        baseClass.Return_StockManagementSettings("SR_WhenStockReduced");
                        foreach (DataRow dataRow3 in baseClass.ProductStockType_Select((long)this.CompanyID, num11).Rows)
                        {
                            this.Session["StockItemType"] = "C";
                            if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "self", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, (long)0, num11, "other", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass.StockReductionProcess((long)this.CompanyID, num11, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else
                            {
                                empty = baseClass.StockReductionProcessForAdditionalOption((long)this.CompanyID, num11, "additional option", num5, num2, "Job", (long)this.UserID, num12);
                            }
                        }
                    }
                    this.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "X", true) == 0)
                {
                    bool flag = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row4 in dataSet.Tables[0].Rows)
                    {
                        long num13 = Convert.ToInt64(row4["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row4["Quantity"]);
                        decimal num14 = Convert.ToDecimal(row4["Price"]);
                        bool flag1 = Convert.ToBoolean(row4["IsStockReplenish"]);
                        bool flag2 = Convert.ToBoolean(row4["IsStockReplenished"]);
                        BaseClass baseClass1 = new BaseClass();
                        baseClass1.Return_StockManagementSettings("SR_WhenStockReduced");
                        if (flag1.ToString().ToLower() == "true" && flag2.ToString().ToLower() != "true")
                        {
                            flag = false;
                        }
                        if (flag.ToString().ToLower() != "true")
                        {
                            continue;
                        }
                        foreach (DataRow dataRow4 in baseClass1.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                        {
                            this.Session["StockItemType"] = "X";
                            this.Session["ALC_OrderItemId"] = row4["OrderItemId"].ToString();
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "self", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, (long)0, num13, "other", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = baseClass1.StockReductionProcess((long)this.CompanyID, num13, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else
                            {
                                empty = baseClass1.StockReductionProcessForAdditionalOption((long)this.CompanyID, num13, "additional option", num5, num2, "Job", (long)this.UserID, num14);
                            }
                        }
                    }
                }
                else if (string.Compare(str2, "F", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_estimate_select(this.CompanyID, num2);
                    foreach (DataRow row5 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row5["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row5["Noofplates"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                    }
                    foreach (DataRow dataRow5 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow5["PaperID"]);
                        empty2 = "I";
                        dataRow5["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(dataRow5["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(dataRow5["Quantity"]);
                        Convert.ToDecimal(dataRow5["PackedIn"]);
                        Convert.ToInt64(dataRow5["EstLithoItemID"]);
                        Convert.ToDecimal(dataRow5["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow5["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow5["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow5["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow5["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow5["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "D", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.litho_pad_estimate_select(this.CompanyID, num2);
                    foreach (DataRow row6 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row6["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row6["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (DataRow dataRow6 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow6["PaperID"]);
                        empty2 = "I";
                        dataRow6["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(dataRow6["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(dataRow6["Quantity"]);
                        Convert.ToDecimal(dataRow6["PackedIn"]);
                        Convert.ToInt64(dataRow6["EstimateLithoPadItemID"]);
                        Convert.ToDecimal(dataRow6["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow6["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow6["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow6["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow6["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow6["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num10), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "N", true) == 0)
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithoncr_item_select(this.CompanyID, num2);
                    Hashtable hashtables2 = new Hashtable();
                    foreach (DataRow row7 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(row7["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(row7["Noofplates"]);
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToInt32(hashtables2[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (long key2 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key2), empty2, Convert.ToInt32(hashtables2[key2]), JobStatus, num2);
                    }
                    hashtables2.Clear();
                    foreach (DataRow dataRow7 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(dataRow7["PaperID"]);
                        empty2 = "I";
                        dataRow7["InventoryCode"].ToString();
                        dataRow7["inventoryname"].ToString();
                        num5 = Convert.ToInt32(dataRow7["Quantity"]);
                        Convert.ToDecimal(dataRow7["PackedIn"]);
                        Convert.ToInt64(dataRow7["EstimateLithoNCRItemID"]);
                        Convert.ToDecimal(dataRow7["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(dataRow7["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(dataRow7["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(dataRow7["RunningSpoilage"]);
                        Convert.ToDecimal(dataRow7["NcrPartsPerSet"].ToString());
                        Convert.ToDecimal(dataRow7["NcrSetsPerPad"].ToString());
                        Convert.ToDecimal(dataRow7["PaperMarkup"]);
                        num10 = Convert.ToDecimal(dataRow7["InvSheets"]);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
                        }
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToInt32(hashtables2[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key3 in hashtables2.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key3), empty2, Convert.ToInt32(hashtables2[key3]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "K", true) != 0)
                {
                    if (string.Compare(str2, "Q", true) != 0)
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row8 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row8["PaperID"]);
                        empty2 = "I";
                        row8["InventoryCode"].ToString();
                        SummaryClass.Split_ItemDescription_forpurchaseorder(row8["ItemDescription"].ToString());
                        num5 = Convert.ToInt32(row8["Quantity"]);
                        Convert.ToDecimal(row8["PackedIn"]);
                        Convert.ToInt64(row8["QuickQuoteID"]);
                        Convert.ToDecimal(row8["PaperUnitPrice"]);
                        num6 = Convert.ToInt32(row8["PrintLayoutValue"]);
                        num7 = Convert.ToDecimal(row8["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row8["RunningSpoilage"]);
                        printSheetCalulation = EstimatesBasePage.GetPrintSheetCalulation(num5, num6, num7, num8, new decimal(0), "singleitem", new decimal(0), "", out num9);
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(printSheetCalulation));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(printSheetCalulation);
                        }
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(printSheetCalulation), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else
                {
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    dataTable1 = EstimatesBasePage.lithobooklet_item_select(this.CompanyID, num2);
                    Hashtable hashtables3 = new Hashtable();
                    foreach (DataRow dataRow8 in dataTable1.Rows)
                    {
                        num4 = Convert.ToInt64(dataRow8["PlateID"]);
                        empty2 = "I";
                        num5 = Convert.ToInt32(dataRow8["Noofplates"]);
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, num4, empty2, Convert.ToInt32(num5), JobStatus, num2);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToInt32(hashtables3[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToInt32(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
                        }
                    }
                    foreach (long key4 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key4), empty2, Convert.ToInt32(hashtables3[key4]), JobStatus, num2);
                    }
                    hashtables3.Clear();
                    foreach (DataRow row9 in dataSet.Tables[0].Rows)
                    {
                        num4 = Convert.ToInt64(row9["PaperID"]);
                        empty2 = "I";
                        row9["InventoryCode"].ToString();
                        row9["inventoryname"].ToString();
                        num5 = Convert.ToInt32(row9["Quantity"]);
                        Convert.ToDecimal(row9["PackedIn"]);
                        Convert.ToInt64(row9["EstimateLithobookletItemID"]);
                        Convert.ToDecimal(row9["PaperUnitPrice"]);
                        Convert.ToInt32(row9["NoOfSignatures"]);
                        num7 = Convert.ToDecimal(row9["SetupSpoilage"]);
                        num8 = Convert.ToDecimal(row9["RunningSpoilage"]);
                        Convert.ToDecimal(row9["PaperMarkup"]);
                        num10 = Convert.ToDecimal(row9["InvSheets"]);
                        if (!hashtables3.ContainsKey(num4))
                        {
                            hashtables3.Add(num4, Convert.ToInt32(num10));
                        }
                        else
                        {
                            hashtables3[num4] = Convert.ToInt32(hashtables3[num4].ToString()) + Convert.ToInt32(num10);
                        }
                    }
                    foreach (long key5 in hashtables3.Keys)
                    {
                        EstimateBasePage.estimate_warehouseqty_update(this.CompanyID, Convert.ToInt64(key5), empty2, Convert.ToInt32(hashtables3[key5]), JobStatus, num2);
                    }
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
            }
            this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
            if (this.htInventory.Count > 0)
            {
                foreach (long key6 in this.htInventory.Keys)
                {
                    string empty4 = string.Empty;
                    DataTable dataTable2 = InventoryBasePage.Select_Activity_History_For_Inventory(Convert.ToInt64(key6));
                    if (dataTable2.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow9 in dataTable2.Rows)
                        {
                            empty4 = dataRow9["FinalQuantity"].ToString();
                        }
                    }
                    if (JobStatus == "reverted-i")
                    {
                        commonClass _commonClass = this.commclass;
                        long num15 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job status not matched: <a href='", this.strSitepath, "invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                        _commonClass.Insert_Activity_History_For_Inventory(num15, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                    if (JobStatus == "completed")
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        if (str1 != "invoice")
                        {
                            commonClass _commonClass1 = this.commclass;
                            long num16 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                            _commonClass1.Insert_Activity_History_For_Inventory(num16, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                        else
                        {
                            commonClass _commonClass2 = this.commclass;
                            long num17 = Convert.ToInt64(key6);
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "/invoice/invoice_summary.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
                            _commonClass2.Insert_Activity_History_For_Inventory(num17, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "u", Convert.ToDecimal(empty4) - Convert.ToDecimal(this.htInventory[key6]));
                        }
                    }
                    if (JobStatus != "cancelled")
                    {
                        if (!(JobStatus == "progressed") || !(this.ReduceStockType.ToLower() != "e") || !(this.ReduceStockType.ToLower() != num.ToString()) || !(this.ReduceStockType.ToLower() != "i") || !(str1 != "invoice"))
                        {
                            continue;
                        }
                        commonClass _commonClass3 = this.commclass;
                        long num18 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock allocated: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass3.Insert_Activity_History_For_Inventory(num18, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "h", new decimal(0));
                    }
                    else
                    {
                        if (empty4 == null || empty4 == "")
                        {
                            empty4 = "0";
                        }
                        commonClass _commonClass4 = this.commclass;
                        long num19 = Convert.ToInt64(key6);
                        estimateID = new object[] { "Stock restored due to job cancellation: <a href='", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", EstimateID, "' target='_blank' style='color:Blue'>", str, "</a>" };
                        _commonClass4.Insert_Activity_History_For_Inventory(num19, string.Concat(estimateID), this.UserID, Convert.ToDecimal(this.htInventory[key6]), "a", Convert.ToDecimal(empty4) + Convert.ToDecimal(this.htInventory[key6]));
                    }
                }
            }
            return empty;
        }

        protected string date_Check_new(string DateFormatt, string txtvalue)
        {
            try
            {
                string[] strArrays = txtvalue.Trim().Split(new char[] { '/' });
                if (this.DateFormat == string.Concat(this.PaperMeasure, "/dd/yyyy"))
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays1 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays1);
                    }
                    else if (DateFormatt == string.Concat(this.PaperMeasure, "/dd/yyyy"))
                    {
                        string[] strArrays2 = new string[] { strArrays[0], "/", strArrays[1], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays2);
                    }
                }
                if (this.DateFormat == "dd/mm/yyyy")
                {
                    if (DateFormatt == "dd/mm/yyyy")
                    {
                        string[] strArrays3 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays3);
                    }
                    else if (DateFormatt == string.Concat(this.PaperMeasure, "/dd/yyyy"))
                    {
                        string[] strArrays4 = new string[] { strArrays[1], "/", strArrays[0], "/", strArrays[2] };
                        txtvalue = string.Concat(strArrays4);
                    }
                }
            }
            catch
            {
                txtvalue = "1/1/1900";
            }
            return txtvalue;
        }

        protected void imgbtnDelete_Click(object sender, CommandEventArgs e)
        {
            GridDataItem namingContainer = (GridDataItem)(sender as ImageButton).NamingContainer;
            long num = Convert.ToInt64(e.CommandArgument);
            InvoiceBasePage.InvoicePaid_HistoryDetails_Delete(this.CompanyID, num);
            this.btnvalue = "delete";
            this.BindInvoicePaidRecords();
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPaymentDelete);
            this.objnotes.Amount_Paid = (namingContainer.FindControl("lblAmount") as Label).Text;
            this.objnotes.ModuleID = Convert.ToInt64((namingContainer.FindControl("hdnEstID") as HiddenField).Value);
            string empty = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
        }

        protected void imgbtnEdit_Click(object sender, CommandEventArgs e)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            string[] strArrays = new string[] { " " };
            long num1 = Convert.ToInt64(e.CommandArgument);
            this.AddorEdit = "edit";
            Invoice_Paid_View.PDID = num1;
            if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0")
            {
                return;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "slideItForEdit('divaddforother');", true);
            this.tblbtnupdate.Style.Add("display", "block");
            this.divUpdateMain.Style.Add("display", "block");
            this.divPMTitle.Style.Add("display", "none");
            this.divEditPayment.Style.Add("display", "block");
            DataTable dataTable = InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, num1);
            if (this.rdopaymenttypeforaddedit != null)
            {
                this.rdopaymenttypeforaddedit.Items[1].Selected = true;
                this.rdopaymenttypeforaddedit.Items[2].Enabled = false;
                this.rdopaymenttypeforaddedit.Items[2].Attributes.Add("style", "display:none");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (this.txtamtpaid != null)
                {
                    this.txtAmtpaidAddedit.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["AmountPaid"]), 0, "", false, false, true, false, true);
                    this.EditAmount = this.txtAmtpaidAddedit.Text;
                    this.txtAmtpaidAddedit.Text = this.txtAmtpaidAddedit.Text.Replace(",", "");
                }
                if (this.ddl_Paymentmode_Add != null)
                {
                    this.ddl_Paymentmode_Add.SelectedValue = row["PaymentModeID"].ToString();
                    num = Convert.ToInt16(row["PaymentModeID"]);
                    this.EditPaymentMode = row["PaymentModeID"].ToString();
                }
                if (num != 4)
                {
                    this.div_CreditCardDetails_Add.Style.Add("display", "none");
                }
                else
                {
                    this.div_CreditCardDetails_Add.Style.Add("display", "block");
                }
                if (this.txtInvoicePaymentDate_Add != null)
                {
                    this.txtInvoicePaymentDate_Add.Text = this.commclass.Eprint_return_Date_Before_View(this.objBc.ReplaceSingleQuote(row["PaymentDate"].ToString()), this.CompanyID, this.UserID, false);
                }
                if (this.txt_PaymentDetailNotes_Add != null)
                {
                    this.txt_PaymentDetailNotes_Add.Text = row["Notes"].ToString();
                }
                if (this.txt_HolderName_Add != null)
                {
                    this.txt_HolderName_Add.Text = row["CardHoldersName"].ToString();
                }
                row["PaymentDate"].ToString().Split(strArrays, StringSplitOptions.None);
                this.hdnPaymentMode.Value = row["PaymentModeValue"].ToString();
                this.txt_PaymentDetailNotes_Add.Text = row["Notes"].ToString();
                if (row["CardType"].ToString() == "American")
                {
                    this.rbnAmericanID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "MasterCard")
                {
                    this.rbnMasterCardID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "Discover")
                {
                    this.rbnDiscoverID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "Visa")
                {
                    this.rbnVisaID_Add.Checked = true;
                }
                if (row["CardNumber"].ToString() != "0")
                {
                    this.txt_cardNumber_Add.Text = row["CardNumber"].ToString();
                }
                if (Convert.ToInt16(row["ExpirationMonth"]) != 0 && Convert.ToInt16(row["ExpirationYear"]) != 0)
                {
                    this.ddl_month_Add.SelectedValue = row["ExpirationMonth"].ToString();
                    this.ddl_year_Add.SelectedValue = row["ExpirationYear"].ToString();
                }
                this.txt_verification_Add.Text = row["VerificationNumber"].ToString();
            }
        }

        protected void lnkbtnEdit_Click(object sender, CommandEventArgs e)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            string[] strArrays = new string[] { " " };
            long num1 = Convert.ToInt64(e.CommandArgument);
            this.AddorEdit = "edit";
            Invoice_Paid_View.PDID = num1;
            if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0")
            {
                this.divview.Style.Add("display", "none");
                return;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "slideItForEdit('divaddforother');", true);
            this.tblbtnupdate.Style.Add("display", "block");
            this.divUpdateMain.Style.Add("display", "block");
            this.divPMTitle.Style.Add("display", "none");
            this.divEditPayment.Style.Add("display", "block");
            DataTable dataTable = InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, num1);
            if (this.rdopaymenttypeforaddedit != null)
            {
                this.rdopaymenttypeforaddedit.Items[1].Selected = true;
                this.rdopaymenttypeforaddedit.Items[2].Enabled = false;
                this.rdopaymenttypeforaddedit.Items[2].Attributes.Add("style", "display:none");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (this.txtamtpaid != null)
                {
                    this.txtAmtpaidAddedit.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["AmountPaid"]), 0, "", false, false, true, false, true);
                    this.EditAmount = this.txtAmtpaidAddedit.Text;
                    this.txtAmtpaidAddedit.Text = this.txtAmtpaidAddedit.Text.Replace(",", "");
                }
                if (this.ddl_Paymentmode_Add != null)
                {
                    this.ddl_Paymentmode_Add.SelectedValue = row["PaymentModeID"].ToString();
                    num = Convert.ToInt16(row["PaymentModeID"]);
                    this.EditPaymentMode = row["PaymentModeID"].ToString();
                }
                if (num != 4)
                {
                    this.div_CreditCardDetails_Add.Style.Add("display", "none");
                }
                else
                {
                    this.div_CreditCardDetails_Add.Style.Add("display", "block");
                }
                if (this.txtInvoicePaymentDate_Add != null)
                {
                    this.txtInvoicePaymentDate_Add.Text = this.commclass.Eprint_return_Date_Before_View(row["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (this.txt_PaymentDetailNotes_Add != null)
                {
                    this.txt_PaymentDetailNotes_Add.Text = row["Notes"].ToString();
                }
                if (this.txt_HolderName_Add != null)
                {
                    this.txt_HolderName_Add.Text = row["CardHoldersName"].ToString();
                }
                row["PaymentDate"].ToString().Split(strArrays, StringSplitOptions.None);
                this.hdnPaymentMode.Value = row["PaymentModeValue"].ToString();
                this.txt_PaymentDetailNotes_Add.Text = row["Notes"].ToString();
                if (row["CardType"].ToString() == "American")
                {
                    this.rbnAmericanID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "MasterCard")
                {
                    this.rbnMasterCardID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "Discover")
                {
                    this.rbnDiscoverID_Add.Checked = true;
                }
                else if (row["CardType"].ToString() == "Visa")
                {
                    this.rbnVisaID_Add.Checked = true;
                }
                if (row["CardNumber"].ToString() != "0")
                {
                    this.txt_cardNumber_Add.Text = row["CardNumber"].ToString();
                }
                if (Convert.ToInt16(row["ExpirationMonth"]) != 0 && Convert.ToInt16(row["ExpirationYear"]) != 0)
                {
                    this.ddl_month_Add.SelectedValue = row["ExpirationMonth"].ToString();
                    this.ddl_year_Add.SelectedValue = row["ExpirationYear"].ToString();
                }
                this.txt_verification_Add.Text = row["VerificationNumber"].ToString();
            }
        }

        protected void lnkbtnview_Click(object sender, CommandEventArgs e)
        {
            commonClass _commonClass = new commonClass();
            long num = Convert.ToInt64(e.CommandArgument);
            Invoice_Paid_View.PDID = num;
            this.divview.Style.Add("display", "block");
            this.divbtnrecord.Style.Add("display", "none");
            this.divUpdateMain.Style.Add("display", "none");
            this.divPMTitle.Style.Add("display", "none");
            this.divEditPayment.Style.Add("display", "none");
            DataTable dataTable = new DataTable();
            dataTable = (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0") ? InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, num) : InvoiceBasePage.OrderDetails_select(this.CompanyID, (long)this.OrderID));
            foreach (DataRow row in dataTable.Rows)
            {
                if (this.txtAmtpaidAddedit != null)
                {
                    if (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0"))
                    {
                        this.txtAmtpaidAddedit.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["AmountPaid"]), 0, "", false, false, true, false, true);
                        this.EditAmount = this.txtamtpaid.Text;
                        this.OutStandingAmount = Convert.ToDecimal(this.txtAmtpaidAddedit.Text);
                        this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                    }
                    else
                    {
                        this.EditAmount = this.lblInvAmountvalue.Text;
                        this.OutStandingAmount = new decimal(0);
                        this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                    }
                }
                this.lblNVHoldervalue.Text = row["CardHoldersName"].ToString();
                this.lblNVCardtypeValue.Text = row["CardType"].ToString();
                if (row["CardNumber"].ToString() != "0")
                {
                    this.lblNVCardnoValue.Text = row["CardNumber"].ToString();
                }
                else
                {
                    this.lblNVCardnoValue.Text = "";
                }
                this.lblNVVerNoValue.Text = row["VerificationNumber"].ToString();
                if (Convert.ToInt16(row["ExpirationMonth"]) == 0 || Convert.ToInt16(row["ExpirationYear"]) == 0)
                {
                    continue;
                }
                if (Convert.ToInt16(row["ExpirationMonth"]) >= 10)
                {
                    this.lblNVExpirationdatevalue.Text = string.Concat(row["ExpirationMonth"].ToString(), " / ", row["ExpirationYear"].ToString());
                }
                else
                {
                    this.lblNVExpirationdatevalue.Text = string.Concat("0", row["ExpirationMonth"].ToString(), " / ", row["ExpirationYear"].ToString());
                }
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "slideItForView('divaddforother');", true);
        }

        public void Onclick_lnkNotPaid(object sender, EventArgs e)
        {
            this.InvoiceID__fromdb_ispaid = InvoiceBasePage.invoice_InvoiceID_select(this.CompanyID, this.EstimateID, "NotPaid");
            string empty = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNotPayment);
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
        }

        protected void OnItemDataBound_RadGrid2(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                Label label = (Label)e.Item.FindControl("lblGDate");
                Label label1 = (Label)e.Item.FindControl("lblAmount");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgView");
                ImageButton imageButton1 = (ImageButton)e.Item.FindControl("imgbtnEdit");
                ImageButton imageButton2 = (ImageButton)e.Item.FindControl("imgbtnDelete");
                Label str = (Label)e.Item.FindControl("lblNotes");
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lnkdate");
                LinkButton linkButton1 = (LinkButton)e.Item.FindControl("lnkmode");
                LinkButton linkButton2 = (LinkButton)e.Item.FindControl("lnkamt");
                LinkButton linkButton3 = (LinkButton)e.Item.FindControl("lnknote");
                if (label != null)
                {
                    label.Text = this.commclass.Eprint_return_Date_Before_View(dataItem["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                }
                if (str != null)
                {
                    if (dataItem["Notes"].ToString() != "")
                    {
                        str.Text = dataItem["Notes"].ToString();
                    }
                    else
                    {
                        str.Text = "&nbsp;";
                    }
                }
                if (dataItem["PaymentModeValue"].ToString() == "Credit Card")
                {
                    if (imageButton != null)
                    {
                        imageButton.Visible = true;
                    }
                }
                else if (imageButton != null)
                {
                    imageButton.Visible = false;
                }
                if (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0"))
                {
                    linkButton.Attributes.Add("style", "cursor:pointer");
                    linkButton1.Attributes.Add("style", "cursor:pointer");
                    linkButton2.Attributes.Add("style", "cursor:pointer");
                    linkButton3.Attributes.Add("style", "cursor:pointer");
                    linkButton3.Attributes.Add("style", "text-decoration: none");
                    linkButton.Attributes.Add("style", "text-decoration: none");
                    linkButton1.Attributes.Add("style", "text-decoration: none");
                    linkButton2.Attributes.Add("style", "text-decoration: none");
                    if (label1 != null)
                    {
                        label1.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["AmountPaid"]), 0, "", false, false, true, false, true);
                    }
                    this.sum = Convert.ToString(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["TotalAmountPaid"]), 0, "", false, false, true, false, true), true));
                }
                else
                {
                    if (label1 != null)
                    {
                        label1.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["totalamount"]), 0, "", false, false, true, false, true);
                    }
                    this.sum = Convert.ToString(this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataItem["totalamount"]), 0, "", false, false, true, false, true), true));
                    if (imageButton1 != null)
                    {
                        imageButton1.Visible = false;
                    }
                    if (imageButton2 != null)
                    {
                        imageButton2.Visible = false;
                    }
                }
            }
            if (e.Item is GridFooterItem)
            {
                GridFooterItem gridFooterItem = (GridFooterItem)e.Item;
                (gridFooterItem["amount"].FindControl("TextBox2") as Label).Text = this.sum;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            this.RadGrid2.Columns[2].HeaderText = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Amount"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            Invoice_Paid_View.objLanguage.GetLanguageConversion("Total_Paid");
            this.rdopaymenttype.Items[0].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttype.Items[1].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttype.Items[2].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("None");
            this.rdopaymenttype_module.Items[0].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttype_module.Items[1].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttype_module.Items[2].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("None");
            this.rdopaymenttypeforaddedit.Items[0].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttypeforaddedit.Items[1].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttypeforaddedit.Items[2].Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("None");
            this.rdopaymenttypeforaddedit.Items[2].Attributes.Add("style", "display:none");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.objpage.GetRegionalSettings(this.CompanyID, "dateformat");
            this.UserName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            this.strTodayDate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
            this.Ispaidenable = ConnectionClass.IsPaymentEnable.ToString();
            this.ddl_Paymentmode.Attributes.Add("OnChange", "javascript:DisplayCreditCards();");
            this.ddl_Paymentmode_module.Attributes.Add("OnChange", "javascript:DisplayCreditCards_module();");
            this.ddl_Paymentmode_Add.Attributes.Add("OnChange", "javascript:DisplayCreditCardsForAdd();");
            this.lblPaymentmode.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lblDate.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblNotes.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Notes");
            this.Label3.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.Label5.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Type");
            this.Label7.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Number");
            this.Label4.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lblverficationnotext.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Verification_Number");
            this.lbl_HolderName.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Verification_Number");
            this.lblNotes_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Notes");
            this.lblDate_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblPaymentmode_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lbl_HolderName_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification_Add.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Verification_Number");
            this.lblamountpaidtextaddEdit.Text = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            this.BtnPay.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Record_Payment");
            this.BtnContinue.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Continue");
            this.lnkNotPaid.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Click_here_to_make_the_payment_as_not_paid");
            this.lblPaymentmode_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lblDate_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblNotes_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Notes");
            this.lbl_HolderName_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification_module.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Verification_Number");
            this.lgheader.InnerText = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Credit_Card"), " ", Invoice_Paid_View.objLanguage.GetLanguageConversion("Details"));
            if (!base.IsPostBack)
            {
                if (base.Request.Params["EstimateID"] != null)
                {
                    this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstimateID"].ToString());
                    this.hdnEstimateID.Value = this.EstimateID.ToString();
                    if (this.EstimateID != (long)0)
                    {
                        Invoice_Paid_View.MoreEstimateID[0] = Convert.ToInt32(this.EstimateID);
                    }
                    else if (this.EstimateID == (long)0)
                    {
                        string[] strArrays = this.hdnEstimatIds.Value.Split(new char[] { ',' });
                        Invoice_Paid_View.MoreEstimateID = new int[(int)strArrays.Length];
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            if (strArrays[i].ToString() != "")
                            {
                                int[] moreEstimateID = Invoice_Paid_View.MoreEstimateID;
                                string str = strArrays[i];
                                char[] chrArray = new char[] { '\u005F' };
                                moreEstimateID[i] = Convert.ToInt32(str.Split(chrArray)[0].ToString());
                            }
                        }
                    }
                }
                this.ModuleType = "invoicesummary";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForSummary();", true);
                base.Title = "Invoice Payment";
                this.spnlnk.InnerText = Invoice_Paid_View.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                this.lblnewpayment.Visible = true;
            }
            Invoice_Paid_View.Module = "job";
            this.Pgtype = "job";
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (base.Request.Params["EstimateID"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt64(base.Request.Params["InvID"]);
            }
            if (base.Request.Params["SelectedIDs"] != null)
            {
                this.SelectedIDs = base.Request.Params["SelectedIDs"].ToString();
            }
            if (base.Request.Params["ItemIDs"] != null)
            {
                this.ItemIDs = base.Request.Params["ItemIDs"].ToString();
            }
            if (base.Request.Params["EstimateIDs"] != null)
            {
                this.EstimateIDs = base.Request.Params["EstimateIDs"].ToString();
            }
            if (base.Request.Params["JobIDs"] != null)
            {
                this.JobIDs = base.Request.Params["JobIDs"].ToString();
            }
            this.IsPaid = "0";
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_PaymentValue_select((long)this.CompanyID);
                this.ddl_Paymentmode.DataSource = dataTable;
                this.ddl_Paymentmode.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode.DataBind();
                this.ddl_Paymentmode.Items.Insert(0, " ");
                this.ddl_Paymentmode.Items[0].Text = "--Select--";
                this.ddl_Paymentmode.Items[0].Value = "0";
                this.ddl_Paymentmode_module.DataSource = dataTable;
                this.ddl_Paymentmode_module.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode_module.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode_module.DataBind();
                this.ddl_Paymentmode_module.Items.Insert(0, " ");
                this.ddl_Paymentmode_module.Items[0].Text = "--Select--";
                this.ddl_Paymentmode_module.Items[0].Value = "0";
                this.ddl_Paymentmode_Add.DataSource = dataTable;
                this.ddl_Paymentmode_Add.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode_Add.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode_Add.DataBind();
                this.ddl_Paymentmode_Add.Items.Insert(0, " ");
                this.ddl_Paymentmode_Add.Items[0].Text = "--Select--";
                this.ddl_Paymentmode_Add.Items[0].Value = "0";
                TextBox txtInvoicePaymentDateAdd = this.txtInvoicePaymentDate_Add;
                commonClass _commonClass1 = this.commclass;
                DateTime dateTime = DateTime.Now;
                txtInvoicePaymentDateAdd.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false);
                TextBox txtInvoicePaymentDateModule = this.txtInvoicePaymentDate_module;
                commonClass _commonClass2 = this.commclass;
                DateTime now1 = DateTime.Now;
                txtInvoicePaymentDateModule.Text = _commonClass2.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, false);
                TextBox textBox = this.txtInvoicePaymentDate;
                commonClass _commonClass3 = this.commclass;
                DateTime dateTime1 = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, false);
            }
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (!base.IsPostBack)
            {
                this.txtInvoicePaymentDate_module.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtInvoicePaymentDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtInvoicePaymentDate_Add.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                commonClass _commonClass4 = this.commclass;
                string dateFormat = this.DateFormat;
                commonClass _commonClass5 = this.commclass;
                DateTime now2 = DateTime.Now;
                string str1 = _commonClass4.date_Check_new(dateFormat, _commonClass5.Eprint_return_Date_Before_View(now2.ToString(), this.CompanyID, this.UserID, false), this.CompanyID);
                try
                {
                    this.TodayDate = Convert.ToDateTime(str1);
                }
                catch
                {
                }
            }
            DataTable dataTable1 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select_Items(this.CompanyID, this.ItemIDs, this.InvoiceID);
            string empty = string.Empty;
            this.divaddEdit.Style.Add("display", "none");
            this.divview.Style.Add("display", "none");
            foreach (DataRow row in dataTable1.Rows)
            {
                this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalSellingPrice"]), 0, "", false, false, true, false, true));
                this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                if (row["InvoiceNumber"].ToString() == "0")
                {
                    continue;
                }
                this.plhamountpaid.Visible = false;
                this.divInvDetails.Visible = true;
                this.lblinvoicenovalue.Text = row["InvoiceNumber"].ToString();
                this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(row["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                this.lblCustomervalue.Text = this.objBC.SpecialDecode(row["CompanyName"].ToString());
                this.lblPaymentTermsvalue.Text = string.Concat(row["PaymentName"].ToString(), " (", row["PaymentTerms"].ToString(), " days)");
                this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
                if (this.OutStandingAmount > new decimal(0))
                {
                    this.lblOutStandingvalue.ForeColor = Color.Red;
                    this.lblOutStandingvalue.Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true);
                }
                else if (this.OutStandingAmount != new decimal(0))
                {
                    this.lblOutStandingvalue.ForeColor = Color.Green;
                    this.lblOutStandingvalue.Text = string.Concat("(", this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true), ")");
                }
                else
                {
                    this.lblOutStandingvalue.ForeColor = Color.Black;
                    this.lblOutStandingvalue.Text = Invoice_Paid_View.objLanguage.GetLanguageConversion("Nill");
                }
            }
            this.lblamountpaidtextdisp.Text = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            this.lblamountpaidtextdisp_module.Text = string.Concat(Invoice_Paid_View.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
        }
    }
}
