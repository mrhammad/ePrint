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
using Stripe;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ePrint.common
{
    public partial class Invoice_Paid : System.Web.UI.Page, IRequiresSessionState
    {
        public string ServerName = ConnectionClass.ServerName;

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass commclass = new commonClass();

        public string strSitepath = global.sitePath();

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

        public string ItemIDsFMMain = string.Empty;

        public static int[] EstimateIDsFMMain;

        public static int[] ItemIDsFMMain_Array;

        private long InvoiceNum;

        private DateTime TodayDate;

        private string UserName = string.Empty;

        public string PaperMeasure = string.Empty;

        public long OrderID;

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

        public long Invoice_ID;

        public long Job_ID;

        public long EstItemID;

        public string ProgressType = string.Empty;

        public string divEstItemsList_Style = string.Empty;

        public string Currency = string.Empty;

        private string Braintree_ResultId = string.Empty;

        private string Braintree_AuthorizationCode = string.Empty;

        private string Stripe_ResultId = string.Empty;

        private string Stripe_AuthorizationCode = string.Empty;

        private decimal TotalPriceWithShoppingCartValue;

        private decimal TotalTaxWithShoppingCartValue;

        private DataTable dtAllItems = new DataTable();

        public string SR_WhenStockReduced = string.Empty;

        private string sum = "0";

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

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

        static Invoice_Paid()
        {
            Invoice_Paid.objLanguage = new languageClass();
            Invoice_Paid.Module = "estimate";
            Invoice_Paid.PDID = (long)0;
            Invoice_Paid.IsJobCopied = false;
            Invoice_Paid.NewEstID = (long)0;
            Invoice_Paid.SalesPersonID = string.Empty;
            Invoice_Paid.IsEditOnlyHisRecords = string.Empty;
            Invoice_Paid.MoreEstimateID = new int[2];
            Invoice_Paid.InvoiceIDsFMMain = new int[2];
            Invoice_Paid.JobIDsFMMain = new int[2];
            Invoice_Paid.EstimateIDsFMMain = new int[2];
            Invoice_Paid.ItemIDsFMMain_Array = new int[2];
        }

        public Invoice_Paid()
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
                this.OrderID = Convert.ToInt64(base.Request.Params["OrderID"].ToString());
            }
            if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0" || (this.hdnPaymentMode.Value.Contains("Braintree") || this.hdnPaymentMode.Value.Contains("Stripe") || this.hdnPaymentMode.Value.Contains("Paypal")) && base.Request.Params["IsPaid"].ToString().ToLower() == "1" && base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
            {
                dataTable = InvoiceBasePage.OrderDetails_select(this.CompanyID, this.OrderID);
            }
            else if (this.Invoice_ID <= (long)0)
            {
                long num = (long)0;
                if (base.Request.Params["JID"] != null)
                {
                    num = Convert.ToInt64(base.Request.Params["JID"].ToString());
                }
                if (num > (long)0)
                {
                    dataTable = InvoiceBasePage.InvoicePaid_HistoryDetails_JobSummary_Select(this.CompanyID, num);
                }
                else if (this.OrderID > (long)0)
                {
                    dataTable = InvoiceBasePage.OrderDetails_select(this.CompanyID, this.OrderID);
                }
            }
            else
            {
                dataTable = InvoiceBasePage.InvoicePaid_HistoryDetails_Select(this.CompanyID, this.Invoice_ID);
            }
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
            if (this.hdnPaymentMode.Value.ToString().ToLower() == "credit card" && base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
            {
                DataTable dataTable1 = InvoiceBasePage.OrderDetails_select(this.CompanyID, this.OrderID);
                this.div_linkclick.Style.Add("display", "none");
                this.divview.Style.Add("display", "block");
                this.divbtnrecord.Style.Add("display", "none");
                this.divUpdateMain.Style.Add("display", "none");
                this.divPMTitle.Style.Add("display", "none");
                this.divEditPayment.Style.Add("display", "none");
                this.PaymentDetails.Style.Add("display", "block");
                this.TableForBraintree.Style.Add("display", "none");
                this.TableForStripe.Style.Add("display", "none");
                this.imgbackforview.Style.Add("display", "none");
                this.div_invopmnt.Style.Add("display", "none");
                this.divamountpaid.Style.Add("display", "none");
                foreach (DataRow row in dataTable1.Rows)
                {
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
            }
            else if (dataTable.Rows.Count != 0)
            {
                this.RadGrid2.Visible = true;
                this.divrecordpayment.Style.Add("display", "block");
                this.divMessage.Style.Add("display", "none");
                if ((!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0")) && (!this.hdnPaymentMode.Value.Contains("Braintree") && !this.hdnPaymentMode.Value.Contains("Stripe") && !this.hdnPaymentMode.Value.Contains("Paypal") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "1")) && !(this.hdnPaymentMode.Value.ToLower().ToString() == "credit card"))
                {
                    this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                }
                else
                {
                    this.divMessage.Style.Add("display", "none");
                    if (base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
                    {
                        this.div_linkclick.Style.Add("display", "none");
                    }
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
                this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
            }
            if (base.IsPostBack)
            {
                this.plhamountpaid.Controls.Clear();
                DataTable dataTable2 = new DataTable();
                if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary" || base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" && base.Request.Params["IsJobFromWebstore"].ToString().ToLower() == "0")
                {
                    if (base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
                    {
                        this.ModuleType = "jobrecordview";
                        dataTable2 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "");
                    }
                    else
                    {
                        this.ModuleType = "invoicesummary";
                        dataTable2 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select_Items(this.CompanyID, "", this.Invoice_ID);
                    }
                    foreach (DataRow dataRow in dataTable2.Rows)
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
                        this.lblCustomervalue.Text = dataRow["CompanyName"].ToString();
                        this.lblPaymentTermsvalue.Text = string.Concat(dataRow["PaymentName"].ToString(), " (", dataRow["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
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
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
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
                    dataTable2 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "orderinvoicesummary");
                    foreach (DataRow row1 in dataTable2.Rows)
                    {
                        this.hdnPTfordelete.Value = row1["PaymentType"].ToString();
                        this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["TotalSellingPrice"]), 0, "", false, false, true, false, true));
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
                        if (row1["InvoiceNumber"].ToString() == "0")
                        {
                            continue;
                        }
                        this.plhamountpaid.Visible = false;
                        this.divInvDetails.Visible = true;
                        this.lblinvoicenovalue.Text = row1["InvoiceNumber"].ToString();
                        this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(row1["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblCustomervalue.Text = row1["CompanyName"].ToString();
                        this.lblPaymentTermsvalue.Text = string.Concat(row1["PaymentName"].ToString(), " (", row1["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
                        if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0")
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Black;
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
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
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
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
            this.lblamountpaidtextdisp.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
        }

        protected void BtnContinue_onclick(object sender, EventArgs e)
        {
            DateTime now;
            char[] chrArray;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            int num = 0;
            if (this.EstItemID > (long)0)
            {
                DataTable dataTable = EstimatesBasePage.Estimate_ESTID_JOBID_INVID_Select(this.EstItemID);
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["InvoiceID"].ToString() != "0")
                {
                    num = 1;
                }
            }
            if (num != 0)
            {
                this.div_invopmnt.Style.Add("display", "none");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "alert('This Job is already progressed to an invoice and hence cannot be progressed again.');Close(-1);", true);
                return;
            }
            commonClass _commonClass = new commonClass();
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate_module.Text));
            this.InvoiceNum = this.objCom.settings_lastcounter_select(Convert.ToInt32(this.Session["CompanyID"]), "i");
            long invoiceNum = (long)10000000 + this.InvoiceNum;
            string str2 = string.Concat(ConnectionClass.InvoicePrefix, invoiceNum.ToString().Substring(1, invoiceNum.ToString().Length - 1));
            int num1 = 0;
            int num2 = 0;
            string text = string.Empty;
            string text1 = string.Empty;
            string str3 = "";
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
                str3 = "American";
            }
            else if (this.rbnVisaID_module.Checked)
            {
                str3 = "Visa";
            }
            else if (this.rbnMasterCardID_module.Checked)
            {
                str3 = "MasterCard";
            }
            else if (this.rbnDiscoverID_module.Checked)
            {
                str3 = "Discover";
            }
            if (this.txt_cardNumber_module.Text != "")
            {
                text1 = this.txt_cardNumber_module.Text;
            }
            if (this.txt_verification_module.Text != "")
            {
                text = this.txt_verification_module.Text;
            }
            int num3 = 0;
            if (this.rdnProformaInvYes.Checked)
            {
                num3 = 1;
            }
            else if (this.rdnProformaInvNo.Checked)
            {
                num3 = 0;
            }
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
            {
                empty2 = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
            {
                empty3 = dataRow["PhraseText"].ToString();
            }
            int defaultStatusID = 0;
            int num4 = 0;
            for (int i = 0; i < (int)Invoice_Paid.MoreEstimateID.Length; i++)
            {
                if (Invoice_Paid.MoreEstimateID[i].ToString() != "0")
                {
                    if (this.hdnPaymentMode.Value.Contains("Braintree") || this.hdnPaymentMode.Value.Contains("Paypal") || this.hdnPaymentMode.Value.Contains("Stripe") || this.hdnPaymentMode.Value.Contains("API payment"))
                    {
                        string empty4 = string.Empty;
                        bool selected = this.rdopaymenttype_module.Items[2].Selected;
                        string str4 = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        if (this.hdnPaymentMode.Value == "PayPal")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "7";
                        }
                        if (this.hdnPaymentMode.Value == "Braintree Credit Card")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "10";
                        }
                        if (this.hdnPaymentMode.Value == "Stripe Credit Card")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "15";
                        }
                        if (this.hdnPaymentMode.Value == "API payment")
                        {
                            this.ddl_Paymentmode_module.SelectedValue = "20";
                        }
                        long num5 = this.SummaryClassObj.ProgrssTo_Invoice(this.CompanyID, this.UserID, this.EstimateID, str4, "Yes", this.txtInvoicePaymentDate.Text, this.ddl_Paymentmode_module.SelectedValue, this.txt_PaymentDetailNotes.Text, this.DateFormat, this.PaperMeasure, this.hdnPaymentMode.Value, num3);
                        this.Invoice_ID = num5;
                        try
                        {
                            commonClass _commonClass1 = this.commclass;
                            now = DateTime.Now;
                            this.TodayDate = _commonClass1.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        }
                        catch
                        {
                            now = DateTime.Now;
                            this.TodayDate = Convert.ToDateTime(now.ToString());
                        }
                        if (this.ProgressType == "main")
                        {
                            foreach (DataRow row1 in InvoiceBasePage.Job_Items_Select(this.Job_ID).Rows)
                            {
                                InvoiceBasePage.InvoiceID_Update_in_Items(num5, Convert.ToInt64(row1["EstimateItemID"]));
                                if (!this.rdnProformaInvNo.Checked)
                                {
                                    continue;
                                }
                                InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, Convert.ToInt64(row1["EstimateItemID"]));
                            }
                        }
                        else if (this.EstItemID != (long)0)
                        {
                            InvoiceBasePage.InvoiceID_Update_in_Items(num5, this.EstItemID);
                            if (this.rdnProformaInvNo.Checked)
                            {
                                InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, this.EstItemID);
                            }
                        }
                        this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid.MoreEstimateID[i], num5);
                        foreach (DataRow dataRow1 in InvoiceBasePage.InvoiceItem_EstimateItemID_Select(this.Invoice_ID, "jobinv").Rows)
                        {
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            DataTable dataTable1 = JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, Convert.ToInt64(dataRow1["EstimateItemID"]));
                            foreach (DataRow row2 in dataTable1.Rows)
                            {
                                str5 = row2["InvoiceItemNumber"].ToString();
                                empty5 = row2["JobItemNumber"].ToString();
                            }
                            this.objnotes.Job_number = empty5;
                            this.objnotes.Invoice_number = str5;
                            this.objnotes.ModuleID = this.Invoice_ID;
                            this.objnotes.ModuleName = "Invoice";
                            this.objnotes.ItemID = Convert.ToInt64(dataRow1["EstimateItemID"]);
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemProgInv);
                            this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                            this.objnotes.CompanyID = this.CompanyID;
                            this.objnotes.UserID = this.UserID;
                            this.objN.NotesAdd(this.objnotes);
                        }
                    }
                    else
                    {
                        defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "invoice", Convert.ToInt32(Invoice_Paid.MoreEstimateID[i]));
                        int num6 = 0;
                        char chr = 'C';
                        DataTable clientDefaultInvoiceDetails = InvoiceBasePage.GetClientDefaultInvoiceDetails(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid.MoreEstimateID[i]);
                        foreach (DataRow dataRow2 in clientDefaultInvoiceDetails.Rows)
                        {
                            num6 = Convert.ToInt32(dataRow2["InvoiceAddressID"].ToString());
                            chr = Convert.ToChar(dataRow2["InvoiceAddressType"].ToString());
                        }
                        try
                        {
                            commonClass _commonClass2 = this.commclass;
                            now = DateTime.Now;
                            this.TodayDate = _commonClass2.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        }
                        catch
                        {
                            now = DateTime.Now;
                            this.TodayDate = Convert.ToDateTime(now.ToString());
                        }
                        if (!this.rdopaymenttype_module.Items[2].Selected)
                        {
                            int num7 = 0;
                            num7 = 1;
                            num4 = InvoiceBasePage.invoice_insert_ispaid(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid.MoreEstimateID[i], str2, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(this.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty2), this.objBC.ReplaceSingleQuote(empty3), num7, ConnectionClass.IsHandy, num6, chr, num6);
                            this.Invoice_ID = (long)num4;
                            Invoice_Paid.PDID = (long)0;
                            //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, (long)num4, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_module.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_module.Text, this.txt_HolderName_module.Text, str3, num1, num2, text, text1, Convert.ToDecimal(this.txtamtpaid_module.Text));
                            InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, (long)num4, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_module.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_module.Text, "", "" , 0, 0, "", "", Convert.ToDecimal(this.txtamtpaid_module.Text));
                            InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_module.SelectedItem.Text);
                            if (this.ProgressType == "main")
                            {
                                if (this.dtAllItems.Rows.Count != 0)
                                {
                                    foreach (DataRow row3 in InvoiceBasePage.Job_Items_Select(this.Job_ID).Rows)
                                    {
                                        InvoiceBasePage.InvoiceID_Update_in_Items((long)num4, Convert.ToInt64(row3["EstimateItemID"]));
                                        if (!this.rdnProformaInvNo.Checked)
                                        {
                                            continue;
                                        }
                                        InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, Convert.ToInt64(row3["EstimateItemID"]));
                                    }
                                }
                                else
                                {
                                    string value = this.hdnSelectedItemIDs.Value;
                                    chrArray = new char[] { '\u00B6' };
                                    string[] strArrays = value.Split(chrArray);
                                    for (int j = 0; j < (int)strArrays.Length - 1; j++)
                                    {
                                        InvoiceBasePage.InvoiceID_Update_in_Items((long)num4, Convert.ToInt64(strArrays[j]));
                                        if (this.rdnProformaInvNo.Checked)
                                        {
                                            InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, Convert.ToInt64(strArrays[j]));
                                        }
                                    }
                                }
                            }
                            else if (this.EstItemID != (long)0)
                            {
                                InvoiceBasePage.InvoiceID_Update_in_Items((long)num4, this.EstItemID);
                                if (this.rdnProformaInvNo.Checked)
                                {
                                    InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, this.EstItemID);
                                }
                            }
                            this.objnotes.ModuleID = this.Job_ID;
                        }
                        else
                        {
                            int paymentDetailsFromEstimateID = InvoiceBasePage.Get_PaymentDetails_From_EstimateID((long)Invoice_Paid.MoreEstimateID[i]);
                            commonClass _commonClass3 = this.commclass;
                            now = DateTime.Now;
                            now = now.AddDays((double)paymentDetailsFromEstimateID);
                            DateTime dateTime1 = _commonClass3.Eprint_return_ActualDate_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                            long num8 = InvoiceBasePage.Invoice_insert(Convert.ToInt32(this.Session["CompanyID"]), (long)Invoice_Paid.MoreEstimateID[i], str2, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(this.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty2), this.objBC.ReplaceSingleQuote(empty3), 0, ConnectionClass.IsHandy, num6, chr, num6, dateTime1, this.Job_ID, "Pending", null, null, null, null, null);
                            this.Invoice_ID = num8;
                            if (this.ProgressType == "main")
                            {
                                if (this.dtAllItems.Rows.Count != 0)
                                {
                                    foreach (DataRow dataRow3 in InvoiceBasePage.Job_Items_Select(this.Job_ID).Rows)
                                    {
                                        InvoiceBasePage.InvoiceID_Update_in_Items(num8, Convert.ToInt64(dataRow3["EstimateItemID"]));
                                        if (!this.rdnProformaInvNo.Checked)
                                        {
                                            continue;
                                        }
                                        InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, Convert.ToInt64(dataRow3["EstimateItemID"]));
                                    }
                                }
                                else
                                {
                                    string value1 = this.hdnSelectedItemIDs.Value;
                                    chrArray = new char[] { '\u00B6' };
                                    string[] strArrays1 = value1.Split(chrArray);
                                    for (int k = 0; k < (int)strArrays1.Length - 1; k++)
                                    {
                                        InvoiceBasePage.InvoiceID_Update_in_Items(num8, Convert.ToInt64(strArrays1[k]));
                                        if (this.rdnProformaInvNo.Checked)
                                        {
                                            InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, Convert.ToInt64(strArrays1[k]));
                                        }
                                    }
                                }
                            }
                            else if (this.EstItemID != (long)0)
                            {
                                InvoiceBasePage.InvoiceID_Update_in_Items(num8, this.EstItemID);
                                if (this.rdnProformaInvNo.Checked)
                                {
                                    InvoiceBasePage.JobItems_Archive_Update(this.CompanyID, this.UserID, this.TodayDate, this.EstItemID);
                                }
                            }
                            this.objnotes.ModuleID = this.Job_ID;
                        }
                        foreach (DataRow row4 in InvoiceBasePage.Invoice_JobDetails_SelectByInvoiceID(this.CompanyID, this.Invoice_ID).Rows)
                        {
                            str = row4["Estimatenumber"].ToString();
                            empty1 = row4["jobnumber"].ToString();
                            str1 = row4["invoicenumber"].ToString();
                        }
                        if (!this.rdopaymenttype_module.Items[2].Selected)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvCreatedWithPayment);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvCreatedWithoutPayment);
                        }
                        this.objnotes.Job_number = empty1;
                        this.objnotes.Invoice_number = str1;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.ModuleID = this.Invoice_ID;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass4 = this.commclass;
                        now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass4.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        if (!this.rdopaymenttype_module.Items[2].Selected)
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInvPayment);
                        }
                        else
                        {
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                        }
                        this.objnotes.Estimate_number = str;
                        this.objnotes.Job_number = empty1;
                        this.objnotes.Invoice_number = str1;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.ModuleID = this.Job_ID;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass1 = this.objnotes;
                        commonClass _commonClass5 = this.commclass;
                        now = DateTime.Now;
                        _notesclass1.Created_Date = _commonClass5.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        foreach (DataRow dataRow4 in InvoiceBasePage.InvoiceItem_EstimateItemID_Select(this.Invoice_ID, "jobinv").Rows)
                        {
                            string empty6 = string.Empty;
                            string str6 = string.Empty;
                            DataTable dataTable2 = JobBasePage.QuickLinks_ItemDetials_Select(this.CompanyID, Convert.ToInt64(dataRow4["EstimateItemID"]));
                            foreach (DataRow row5 in dataTable2.Rows)
                            {
                                str6 = row5["InvoiceItemNumber"].ToString();
                                empty6 = row5["JobItemNumber"].ToString();
                            }
                            this.objnotes.Job_number = empty6;
                            this.objnotes.Invoice_number = str6;
                            this.objnotes.ModuleID = this.Invoice_ID;
                            this.objnotes.ModuleName = "Invoice";
                            this.objnotes.ItemID = Convert.ToInt64(dataRow4["EstimateItemID"]);
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemProgInv);
                            this.objN.NotesAdd(this.objnotes);
                        }
                        this.Call_Inventory_Adjustment("completed-i", (long)Invoice_Paid.MoreEstimateID[i], this.Invoice_ID);
                    }
                }
                this.Session["CreateNewInvoice"] = "true";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", string.Concat("Close(", this.Invoice_ID, ");"), true);
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
            for (int i = 0; i < (int)Invoice_Paid.InvoiceIDsFMMain.Length; i++)
            {
                if (base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
                {
                    if (Invoice_Paid.InvoiceIDsFMMain[i].ToString() != "0")
                    {
                        this.InvoiceID__fromdb_ispaid = (long)Invoice_Paid.InvoiceIDsFMMain[i];
                        long num2 = (long)0;
                        DataTable dataTable = new DataTable();
                        num2 = (long)0;
                        //dataTable = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(this.InvoiceID__fromdb_ispaid, num2, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text, this.txt_HolderName.Text, str, num, num1, text, empty);
                        dataTable = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(this.InvoiceID__fromdb_ispaid, num2, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text,"", "", 0, 0, "", "");
                        if (Convert.ToInt32(dataTable.Rows[0]["returnid"]) > 0)
                        {
                            string empty1 = string.Empty;
                            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvfullPaidMain);
                            this.objnotes.Payment_Type = "In Full";
                            this.objnotes.Amount_Paid = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable.Rows[0]["Outstandingamt"]), 0, "", false, false, true, false, true).ToString();
                            this.objnotes.ModuleName = "invoice";
                            this.objnotes.ModuleID = this.InvoiceID__fromdb_ispaid;
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
                else if (base.Request.Params["Module"].ToString().ToLower() == "job_view" && Invoice_Paid.EstimateIDsFMMain[i].ToString() != "0")
                {
                    DataTable dataTable1 = new DataTable();
                    Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
                    DbCommand sqlStringCommand = database.GetSqlStringCommand(string.Concat("select i.InvoiceID from tb_invoice i where i.IsDeleted=0 and i.EstimateID in (SELECT J.EstimateID FROM tb_job J WHERE J.IsDeleted=0 and J.jobid =", Invoice_Paid.JobIDsFMMain[i], ")"));
                    long num3 = (long)database.ExecuteScalar(sqlStringCommand);
                    long estimateIDsFMMain = (long)0;
                    estimateIDsFMMain = (long)Invoice_Paid.EstimateIDsFMMain[i];
                    //dataTable1 = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(num3, estimateIDsFMMain, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text, this.txt_HolderName.Text, str, num, num1, text, empty);
                    dataTable1 = InvoiceBasePage.Insert_InvoicePaymentDetails_Main(num3, estimateIDsFMMain, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes.Text,"","",0, 0, "","");
                    if (Convert.ToInt32(dataTable1.Rows[0]["returnid"]) > 0)
                    {
                        string str1 = string.Empty;
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvfullPaidMain);
                        this.objnotes.Payment_Type = "In Full";
                        this.objnotes.Amount_Paid = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataTable1.Rows[0]["Outstandingamt"]), 0, "", false, false, true, false, true).ToString();
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.ModuleID = estimateIDsFMMain;
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
            string d = (sender as Button).ID;
            commonClass _commonClass = new commonClass();
            DateTime dateTime = Convert.ToDateTime(this.commclass.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, this.txtInvoicePaymentDate_Add.Text));
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            string text = string.Empty;
            string str = "";
            if(this.ddl_Paymentmode_Add.SelectedValue == "15")
            {
                if (this.ddl_year_Add_Stripe.SelectedIndex != 0)
                {
                    num1 = Convert.ToInt16(this.ddl_year_Add_Stripe.SelectedItem.Text);
                }
                if (this.ddl_month_Add_Stripe.SelectedIndex != 0)
                {
                    num = Convert.ToInt16(this.ddl_month_Add_Stripe.SelectedItem.Text);
                }
                if (this.rbnAmericanID_Add_Stripe.Checked)
                {
                    str = "American";
                }
                else if (this.rbnVisaID_Add_Stripe.Checked)
                {
                    str = "Visa";
                }
                else if (this.rbnMasterCardID_Add_Stripe.Checked)
                {
                    str = "MasterCard";
                }
                else if (this.rbnDiscoverID_Add_Stripe.Checked)
                {
                    str = "Discover";
                }
                if (this.txt_cardNumber_Add_Stripe.Text != "")
                {
                    text = this.txt_cardNumber_Add_Stripe.Text;
                }
                if (this.txt_verification_Add_Stripe.Text != "")
                {
                    empty = this.txt_verification_Add_Stripe.Text;
                }
            }
            else
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
            }
          
            Invoice_Paid.PDID = (long)0;
            if (base.Request.Params["Module"].ToString().ToLower() != "invoicesummary")
            {
                for (int i = 0; i < (int)Invoice_Paid.MoreEstimateID.Length; i++)
                {
                    if (Invoice_Paid.MoreEstimateID[i].ToString() != "0")
                    {
                        if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                        {
                            //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text,"", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                        }
                        else if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary")
                        {
                            //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                        }
                        else if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" || base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                        {
                            //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                            InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                        }
                        string empty1 = string.Empty;
                        this.objBC.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
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
                        this.objnotes.ModuleID = (long)Invoice_Paid.MoreEstimateID[i];
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
            else
            {
                try
                {
                    if (this.ddl_Paymentmode_Add.SelectedValue == "15")
                    {
                        DataTable dtStripe = InvoiceBasePage.Select_details_ClientInfo(this.CompanyID, this.ServerName);
                        string StripeKey = string.Empty;
                        foreach (DataRow dr in dtStripe.Rows)
                        {
                            StripeKey = dr["StripePrivateKey"].ToString();
                        }
                        //StripeConfiguration.ApiKey = "sk_test_51IuXtDLZhDp9vDgTTGOdua2XLT3EYA4vuTXIBHhfi5VK1UKluDt52FsMBdkH2L9pfZu6VX32p3VEjHXV11FTGQud009bHw2kGH";
                        StripeConfiguration.ApiKey = StripeKey;
                        var option = new TokenCreateOptions
                        {
                            Card = new TokenCardOptions
                            {
                                //Number = "4242424242424242",
                                //ExpMonth = 9,
                                //ExpYear = 2023,
                                //Cvc = "314",
                                Name = this.txt_HolderName_Add_Stripe.Text,
                                Number = this.txt_cardNumber_Add_Stripe.Text,
                                ExpMonth = Convert.ToInt64(this.ddl_month_Add_Stripe.SelectedItem.Text),
                                ExpYear = Convert.ToInt64(this.ddl_year_Add_Stripe.SelectedItem.Text),
                                Cvc = this.txt_verification_Add_Stripe.Text,

                                //CardholderName = this.txt_HolderName.Text
                            },
                        };
                        var service = new TokenService();
                        var res = service.Create(option);
                        decimal totalPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(this.txtAmtpaidAddedit.Text), 2, "", false, false, true));
                        long TAmount = Convert.ToInt64((totalPrice) * 100);

                        var options = new ChargeCreateOptions
                        {
                            Amount = TAmount,
                            Currency = "AUD",
                            Source = res.Id, // obtained with Stripe.js
                                             //Description = current["OrderNumber"].ToString(),
                        };
                        var service1 = new ChargeService();
                        var res3 = service1.Create(options);
                        string Stripe_Paymentid = res3.Id;
                        InvoiceBasePage.Insert_StripePayment((long)this.CompanyID, this.EstimateID, Stripe_Paymentid);
                        InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.Invoice_ID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
                        //InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.Invoice_ID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add_Stripe.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
                    }
                    else
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.Invoice_ID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, this.txt_HolderName_Add.Text, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
                        InvoiceBasePage.InvoicePaymentDetails_Insert_SplitItem(this.Invoice_ID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), dateTime, this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text), Convert.ToDecimal(this.hdntxtvalue.Value));
                    }
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
                    string empty2 = string.Empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.ModuleID = this.Invoice_ID;
                    this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                    notesclass _notesclass1 = this.objnotes;
                    commonClass _commonClass2 = this.commclass;
                    DateTime now1 = DateTime.Now;
                    _notesclass1.Created_Date = _commonClass2.Eprint_return_DateTime_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                    this.objnotes.CompanyID = this.CompanyID;
                    this.objnotes.UserID = this.UserID;
                    this.objN.NotesAdd(this.objnotes);
                }
                catch (Exception ex)
                {

                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "alert('"+ex.Message.Replace("'","")+"');Close(-1);", true);
                    return;
                }
              
            }
            this.hdnpaymenttypeforupdate.Value = this.ddl_Paymentmode_Add.SelectedItem.Text;
            this.hdnpresentvalueforupdate.Value = this.txtAmtpaidAddedit.Text;
            if (d != "btnRecordNclose")
            {
                this.btnvalue = "record";
            }
            else
            {
                this.btnvalue = "recordclose";
            }
            this.div_JobStatus.Style.Add("display", "none");
            this.divrecordpayment.Style.Add("display", "block");
            this.divview.Style.Add("display", "none");
            this.BindInvoicePaidRecords();
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
            for (int i = 0; i < (int)Invoice_Paid.MoreEstimateID.Length; i++)
            {
                if (Invoice_Paid.MoreEstimateID[i].ToString() != "0")
                {
                    this.txtAmtpaidAddedit.Text = this.txtAmtpaidAddedit.Text;
                    foreach (DataRow row in InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, Invoice_Paid.PDID).Rows)
                    {
                        this.objnotes.Previous_Amount = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["AmountPaid"]), 0, "", false, false, true, false, true);
                    }
                    if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" || base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                    {
                        //InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, empty1, str, num, num1, empty, text, Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.InvoicePaymentDetails_Insert(Invoice_Paid.PDID, this.InvoiceID__fromdb_ispaid, (long)Invoice_Paid.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode_Add.SelectedItem.Value), Convert.ToDateTime(dateTime), this.txt_PaymentDetailNotes_Add.Text, "", "", 0, 0, "", "", Convert.ToDecimal(this.txtAmtpaidAddedit.Text));
                        InvoiceBasePage.Update_PaymentTypeForEstore((long)Invoice_Paid.MoreEstimateID[i], this.CompanyID, this.ddl_Paymentmode_Add.SelectedItem.Text);
                    }
                    string str1 = string.Empty;
                    this.objBC.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
                    string empty2 = string.Empty;
                    this.objnotes.ModuleName = "invoice";
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPaymentUpdate);
                    this.objnotes.Amount_Paid = this.txtAmtpaidAddedit.Text;
                    this.objnotes.ModuleID = (long)Invoice_Paid.MoreEstimateID[i];
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
                    /*if (this.ServerName.ToLower().Contains("dmc"))
                    {
                        continue;
                    }*/
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
                            this.htInventory.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
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
                            this.htInventory.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
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
                            this.htInventory.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        if (!hashtables.ContainsKey(num4))
                        {
                            hashtables.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            hashtables[num4] = Convert.ToDecimal(hashtables[num4].ToString()) + Convert.ToDecimal(num10);
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
                            hashtables1[num4] = Convert.ToDecimal(hashtables1[num4].ToString()) + Convert.ToDecimal(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
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
                    if (this.ServerName.ToLower().Contains("dmc"))
                    {
                        continue;
                    }
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row3 in dataSet.Tables[0].Rows)
                    {
                        long num11 = Convert.ToInt64(row3["PriceCatalogueID"]);
                        bool flag = Convert.ToBoolean(row3["IsStockReplenish"]);
                        Convert.ToBoolean(row3["IsStockReplenished"]);
                        num5 = Convert.ToInt32(row3["Quantity"]);
                        decimal num12 = Convert.ToDecimal(row3["Price"]);
                        if (flag || !(this.SR_WhenStockReduced == "c") && !(this.SR_WhenStockReduced == "j"))
                        {
                            continue;
                        }
                        foreach (DataRow dataRow3 in this.objBC.ProductStockType_Select((long)this.CompanyID, num11).Rows)
                        {
                            this.Session["StockItemType"] = "C";
                            if (dataRow3["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, num11, (long)0, "self", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            if (dataRow3["DrawStockFrom"].ToString().ToLower() == "p")
                            {
                                empty = objBC.SimpleStockReduction(num11, num5);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, (long)0, num11, "other", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else if (dataRow3["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow3["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, num11, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num12);
                            }
                            else
                            {
                                empty = this.objBC.StockReductionProcessForAdditionalOption((long)this.CompanyID, num11, "additional option", num5, num2, "Job", (long)this.UserID, num12);
                            }
                        }
                    }
                    if (commonClass.CheckFTPEnable())
                    {
                        long priceCatalogurID = 0;
                        string filePath = string.Empty;
                        if (dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "0" && dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "")
                        {
                            priceCatalogurID = Convert.ToInt64(dataSet.Tables[0].Rows[0]["PriceCatalogueID"]);
                        }
                        //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                        DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                        if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                        {
                            //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                            {
                                object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                filePath = string.Concat(editableTemplatePath);
                            }
                            else
                            {
                                string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                            }
                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceCreation","ProductEstimate", num2);
                        }

                    }

                    this.Session["StockItemType"] = "C";
                    this.Adjust_Inventory_On_Job_Complete(dataSet, str, num, EstimateID, this.htInventory, num2, JobStatus);
                }
                else if (string.Compare(str2, "X", true) == 0)
                {
                    if (this.ServerName.ToLower().Contains("dmc"))
                    {
                        continue;
                    }
                    bool flag1 = true;
                    dataSet = EstimatesBasePage.estimate_item_info_select_by_qtynumber_new(this.CompanyID, num2, num3, str2);
                    foreach (DataRow row4 in dataSet.Tables[0].Rows)
                    {
                        long num13 = Convert.ToInt64(row4["PriceCatalogueID"]);
                        num5 = Convert.ToInt32(row4["Quantity"]);
                        decimal num14 = Convert.ToDecimal(row4["Price"]);
                        bool flag2 = Convert.ToBoolean(row4["IsStockReplenish"]);
                        bool flag3 = Convert.ToBoolean(row4["IsStockReplenished"]);
                        if (flag2.ToString().ToLower() == "true" && flag3.ToString().ToLower() != "true")
                        {
                            flag1 = false;
                        }
                        if (!(flag2.ToString().ToLower() != "true") || !(flag1.ToString().ToLower() == "true") || !(this.SR_WhenStockReduced == "c") && !(this.SR_WhenStockReduced == "j"))
                        {
                            continue;
                        }
                        foreach (DataRow dataRow4 in this.objBC.ProductStockType_Select((long)this.CompanyID, num13).Rows)
                        {
                            this.Session["StockItemType"] = "X";
                            this.Session["ALC_OrderItemId"] = row4["OrderItemId"].ToString();
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() == "s")
                            {
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, num13, (long)0, "self", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            if (dataRow4["DrawStockFrom"].ToString().ToLower() == "p")
                            {
                                empty = objBC.SimpleStockReduction(num13, num5);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() == "o")
                            {
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, (long)0, num13, "other", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else if (dataRow4["DrawStockFrom"].ToString().ToLower() != "a")
                            {
                                if (dataRow4["DrawStockFrom"].ToString().ToLower() != "m")
                                {
                                    continue;
                                }
                                empty = this.objBC.StockReductionProcess((long)this.CompanyID, num13, (long)0, "multiple", num5, num2, "Job", (long)this.UserID, num14);
                            }
                            else
                            {
                                empty = this.objBC.StockReductionProcessForAdditionalOption((long)this.CompanyID, num13, "additional option", num5, num2, "Job", (long)this.UserID, num14);
                            }
                        }
                    }
                    if (commonClass.CheckFTPEnable())
                    {
                        long priceCatalogurID = 0;
                        string filePath = string.Empty;
                        if (dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "0" && dataSet.Tables[0].Rows[0]["PriceCatalogueID"].ToString() != "")
                        {
                            priceCatalogurID = Convert.ToInt64(dataSet.Tables[0].Rows[0]["PriceCatalogueID"]);
                        }
                        //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                        DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                        if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                        {
                            //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                            if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                            {
                                DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(num2));
                                object[] secureDocEditablePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                //object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                filePath = string.Concat(secureDocEditablePath);
                            }
                            else
                            {
                                string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                            }
                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceCreation", "OnlineOrder", num2);
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
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
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
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
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
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
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
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num10);
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
                            hashtables2[num4] = Convert.ToDecimal(hashtables2[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
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
                            this.htInventory.Add(num4, Convert.ToDecimal(num10));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToDecimal(num10);
                        }
                        if (!hashtables2.ContainsKey(num4))
                        {
                            hashtables2.Add(num4, Convert.ToDecimal(printSheetCalulation));
                        }
                        else
                        {
                            hashtables2[num4] = Convert.ToDecimal(hashtables2[num4].ToString()) + Convert.ToDecimal(num10);
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
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(printSheetCalulation);
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
                            hashtables3[num4] = Convert.ToDecimal(hashtables3[num4].ToString()) + Convert.ToInt32(num5);
                        }
                        if (!this.htInventory.ContainsKey(num4))
                        {
                            this.htInventory.Add(num4, Convert.ToInt32(num5));
                        }
                        else
                        {
                            this.htInventory[num4] = Convert.ToDecimal(this.htInventory[num4].ToString()) + Convert.ToInt32(num5);
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
                            hashtables3[num4] = Convert.ToDecimal(hashtables3[num4].ToString()) + Convert.ToInt32(num10);
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
                        estimateID = new object[] { "Stock restored due to job status not matched: <a href='", this.strSitepath, "invoice/invoice_summary_reeng.aspx?InvID=", this.Invoice_ID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
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
                            estimateID = new object[] { "Stock utilized: <a href='", this.strSitepath, "/invoice/invoice_summary_reeng.aspx?InvID=", this.Invoice_ID, "' target='_blank' style='color:Blue'>", empty1, "</a>" };
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
            this.objnotes.ModuleID = this.Invoice_ID;
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
            Invoice_Paid.PDID = num1;
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
                    this.txtInvoicePaymentDate_Add.Text = this.commclass.Eprint_return_Date_Before_View(this.objBC.ReplaceSingleQuote(row["PaymentDate"].ToString()), this.CompanyID, this.UserID, false);
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

        private static bool isNotZero(int n)
        {
            return n != 0;
        }

        protected void lnkbtnEdit_Click(object sender, CommandEventArgs e)
        {
            commonClass _commonClass = new commonClass();
            int num = 0;
            string[] strArrays = new string[] { " " };
            long num1 = Convert.ToInt64(e.CommandArgument);
            this.AddorEdit = "edit";
            Invoice_Paid.PDID = num1;
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
            Invoice_Paid.PDID = num;
            this.divview.Style.Add("display", "block");
            this.divbtnrecord.Style.Add("display", "none");
            this.divUpdateMain.Style.Add("display", "none");
            this.divPMTitle.Style.Add("display", "none");
            this.divEditPayment.Style.Add("display", "none");
            DataTable dataTable = new DataTable();
            if (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0"))
            {
                dataTable = InvoiceBasePage.InvoicePaid_HistoryDetails_EditSelect(this.CompanyID, num);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.hdnPaymentMode.Value = row["PaymentModeValue"].ToString();
                }
            }
            else
            {
                dataTable = InvoiceBasePage.OrderDetails_select(this.CompanyID, this.OrderID);
            }
            if (this.hdnPaymentMode.Value == "Braintree Credit Card")
            {
                DataTable dataTable1 = InvoiceBasePage.Select_BraintreeDetails_Authorize(this.CompanyID, this.OrderID, this.Invoice_ID);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.Braintree_ResultId = dataRow["BrainTree_ResultID"].ToString();
                    this.Braintree_AuthorizationCode = dataRow["BrainTree_AuthorizationCode"].ToString();
                }
                this.lblOrderId_Value.Text = this.Braintree_ResultId;
                this.lblAuthorizationcode_BTvalue.Text = this.Braintree_AuthorizationCode;
                this.PaymentDetails.Style.Add("display", "none");
                this.TableForBraintree.Style.Add("display", "block");
                this.lgheader.InnerText = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Braintree_Transaction"), " ", Invoice_Paid.objLanguage.GetLanguageConversion("Details"));
            }
            else if (this.hdnPaymentMode.Value == "Stripe Credit Card")
            {
                DataTable dataTable1 = InvoiceBasePage.Select_BraintreeDetails_Authorize(this.CompanyID, this.OrderID, this.Invoice_ID);
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    this.Stripe_ResultId = dataRow["Stripe_Paymentid"].ToString();
                    this.Stripe_AuthorizationCode = dataRow["BrainTree_AuthorizationCode"].ToString();
                }
                this.lblSTAuthorizationcode.Style.Add("display", "none");
                this.lblAuthorizationcode_STvalue.Style.Add("display", "none");
                this.lblOrdetId_STValue.Text = this.Stripe_ResultId;
                this.lblAuthorizationcode_STvalue.Text = this.Stripe_AuthorizationCode;
                this.PaymentDetails.Style.Add("display", "none");
                this.TableForStripe.Style.Add("display", "block");
                this.lgheader.InnerText = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Stripe_Transaction"), " ", Invoice_Paid.objLanguage.GetLanguageConversion("Details"));
            }
            else
            {
                this.PaymentDetails.Style.Add("display", "block");
                this.TableForBraintree.Style.Add("display", "none");
                foreach (DataRow row1 in dataTable.Rows)
                {
                    if (this.txtAmtpaidAddedit != null)
                    {
                        if (!(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") || !(base.Request.Params["IsWebStore"].ToString().ToLower() == "1") || !(base.Request.Params["IsPaid"].ToString().ToLower() == "0"))
                        {
                            this.txtAmtpaidAddedit.Text = this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["AmountPaid"]), 0, "", false, false, true, false, true);
                            this.EditAmount = this.txtamtpaid.Text;
                            this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                        else
                        {
                            this.EditAmount = this.lblInvAmountvalue.Text;
                            this.OutStandingAmount = new decimal(0);
                            this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                        }
                    }
                    this.lblNVHoldervalue.Text = row1["CardHoldersName"].ToString();
                    this.lblNVCardtypeValue.Text = row1["CardType"].ToString();
                    if (row1["CardNumber"].ToString() != "0")
                    {
                        this.lblNVCardnoValue.Text = row1["CardNumber"].ToString();
                    }
                    else
                    {
                        this.lblNVCardnoValue.Text = "";
                    }
                    this.lblNVVerNoValue.Text = row1["VerificationNumber"].ToString();
                    if (Convert.ToInt16(row1["ExpirationMonth"]) == 0 || Convert.ToInt16(row1["ExpirationYear"]) == 0)
                    {
                        continue;
                    }
                    if (Convert.ToInt16(row1["ExpirationMonth"]) >= 10)
                    {
                        this.lblNVExpirationdatevalue.Text = string.Concat(row1["ExpirationMonth"].ToString(), " / ", row1["ExpirationYear"].ToString());
                    }
                    else
                    {
                        this.lblNVExpirationdatevalue.Text = string.Concat("0", row1["ExpirationMonth"].ToString(), " / ", row1["ExpirationYear"].ToString());
                    }
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
                else if (dataItem["PaymentModeValue"].ToString() == "Braintree Credit Card" && e.Item.ItemIndex == 0)
                {
                    if (imageButton != null)
                    {
                        imageButton.Visible = true;
                    }
                }
                else if (dataItem["PaymentModeValue"].ToString() == "Stripe Credit Card" && e.Item.ItemIndex == 0)
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
                    if ((this.hdnPaymentMode.Value.Contains("Braintree") || this.hdnPaymentMode.Value.Contains("Stripe") || this.hdnPaymentMode.Value.Contains("Paypal")) && base.Request.Params["IsPaid"].ToString().ToLower() == "1" && imageButton2 != null)
                    {
                        imageButton2.Visible = false;
                    }
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
            IEnumerator enumerator;
            IDisposable disposable;
            char[] chrArray;
            string[] languageConversion;
            this.SR_WhenStockReduced = this.objBC.Return_StockManagementSettings("SR_WhenStockReduced");
            this.RadGrid2.Columns[2].HeaderText = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            Invoice_Paid.objLanguage.GetLanguageConversion("Total_Paid");
            this.rdopaymenttype.Items[0].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttype.Items[1].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttype.Items[2].Text = Invoice_Paid.objLanguage.GetLanguageConversion("None");
            this.rdopaymenttype_module.Items[0].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttype_module.Items[1].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttype_module.Items[2].Text = Invoice_Paid.objLanguage.GetLanguageConversion("None");
            this.rdopaymenttypeforaddedit.Items[0].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Full");
            this.rdopaymenttypeforaddedit.Items[1].Text = Invoice_Paid.objLanguage.GetLanguageConversion("In_Part");
            this.rdopaymenttypeforaddedit.Items[2].Text = Invoice_Paid.objLanguage.GetLanguageConversion("None");
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
            this.rdnProformaInvYes.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Generate_Invoice_and_keep_the_job_live");
            this.rdnProformaInvNo.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Generate_Invoice_and_archive_the_job");
            this.lblPaymentmode.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lblDate.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblNotes.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Notes");
            this.Label3.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.Label5.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Type");
            this.Label7.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Number");
            this.Label4.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lblverficationnotext.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Verification_Number");
            this.lbl_HolderName.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Verification_Number");
            this.lblNotes_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Notes");
            this.lblDate_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblPaymentmode_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lbl_HolderName_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification_Add.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Verification_Number");

            this.lbl_HolderName_Add_Stripe.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType_Add_Stripe.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber_Add_Stripe.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate_Add_Stripe.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification_Add_Stripe.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Verification_Number");

            this.lblamountpaidtextaddEdit.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            this.BtnPay.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Record_Payment");
            this.BtnContinue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Continue");
            this.lnkNotPaid.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_make_the_payment_as_not_paid");
            this.lblPaymentmode_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Mode");
            this.lblDate_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Payment_Date");
            this.lblNotes_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Notes");
            this.lbl_HolderName_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Holder_Name");
            this.lbl_cardType_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Type");
            this.lbl_cardNumber_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Card_Number");
            this.lbl_expDate_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Expiration_Date");
            this.lbl_verification_module.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Verification_Number");
            this.lgheader.InnerText = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Credit_Card"), " ", Invoice_Paid.objLanguage.GetLanguageConversion("Details"));
            if (base.Request.Params["Module"] != null && base.Request.Params["Module"].ToString().ToLower() == "invoicesummary" && base.Request.Params["InvoiceID"] != null && base.Request.Params["InvoiceID"].ToString() != "")
            {
                this.Invoice_ID = Convert.ToInt64(base.Request.Params["InvoiceID"]);
            }
            if (base.Request.Params["Module"] != null && (base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromjob" || base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder"))
            {
                if (base.Request.Params["JID"] != null)
                {
                    this.Job_ID = Convert.ToInt64(base.Request.Params["JID"]);
                }
                if (base.Request.Params["ItemID"] != null)
                {
                    this.EstItemID = Convert.ToInt64(base.Request.Params["ItemID"]);
                }
                if (base.Request.Params["Type"] != null)
                {
                    this.ProgressType = base.Request.Params["Type"].ToString();
                }
            }
            if (base.Request.Params["EstimateID"] != null && this.EstimateID == (long)0)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["EstimateID"]);
                this.OrderID = Convert.ToInt64(base.Request.Params["EstimateID"]);
            }
            else if (base.Request.Params["OrderID"] != null && this.OrderID == (long)0)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["OrderID"]);
                this.OrderID = Convert.ToInt64(base.Request.Params["OrderID"].ToString());
            }
            if (base.Request.Params["IsPaid"] != null)
            {
                this.IsPaid = base.Request.Params["IsPaid"].ToString();
            }
            DataTable dataTable = OrderBasePage.Order_select(this.CompanyID, this.OrderID);
            foreach (DataRow row in dataTable.Rows)
            {
                this.EstimateID = Convert.ToInt64(row["EstimateID"].ToString());
                this.hdnPaymentMode.Value = row["PaymentType"].ToString();
                if (!(row["PaymentType"].ToString() == "Paypal") && !(row["PaymentType"].ToString() == "Braintree Credit Card") && !(row["PaymentType"].ToString() == "Stripe Credit Card") && !(row["PaymentType"].ToString() == "API payment"))
                {
                    continue;
                }
                this.RadPanelBar1.FindItemByValue("pnlInvoicePayment").Visible = false;
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["EstimateID"] != null)
                {
                    this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstimateID"].ToString());
                    this.hdnEstimateID.Value = this.EstimateID.ToString();
                    if (this.EstimateID != (long)0)
                    {
                        Invoice_Paid.MoreEstimateID[0] = Convert.ToInt32(this.EstimateID);
                    }
                    else if (this.EstimateID == (long)0)
                    {
                        string value = this.hdnEstimatIds.Value;
                        chrArray = new char[] { ',' };
                        string[] strArrays = value.Split(chrArray);
                        Invoice_Paid.MoreEstimateID = new int[(int)strArrays.Length];
                        for (int i = 0; i < (int)strArrays.Length; i++)
                        {
                            if (strArrays[i].ToString() != "")
                            {
                                int[] moreEstimateID = Invoice_Paid.MoreEstimateID;
                                string str = strArrays[i];
                                char[] chrArray1 = new char[] { '\u005F' };
                                moreEstimateID[i] = Convert.ToInt32(str.Split(chrArray1)[0].ToString());
                            }
                        }
                    }
                }
                if (base.Request.Params["Module"] != null)
                {
                    if (base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromjob")
                    {
                        this.ModuleType = "";
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ProgressJob_reeng_module();", true);
                        base.Title = "Progress To Invoice";
                        this.PaidYesNo_module.Style.Add("display", "block");
                        this.divamountpaidshowhide_module.Style.Add("display", "block");
                        this.ddl_Paymentmode_module.Enabled = false;
                        this.txt_PaymentDetailNotes_module.Enabled = false;
                        this.txtInvoicePaymentDate_module.Enabled = false;
                        this.txtamtpaid_module.Enabled = false;
                        this.divUpdateMain.Style.Add("display", "none");
                        this.divMessage.Style.Add("display", "none");
                        this.divrecordpayment.Style.Add("display", "none");
                        this.div_linkclick.Style.Add("display", "none");
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder")
                    {
                        this.ModuleType = "";
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:ProgressJob_reeng_OrderNew();", true);
                        base.Title = "Progress To Invoice";
                        this.ddl_Paymentmode.Enabled = false;
                        this.txt_PaymentDetailNotes.Enabled = false;
                        this.txtInvoicePaymentDate.Enabled = false;
                        this.PaidYesNo_module.Style.Add("display", "block");
                        this.divamountpaidshowhide_module.Style.Add("display", "block");
                        this.ddl_Paymentmode_module.Enabled = false;
                        this.txt_PaymentDetailNotes_module.Enabled = false;
                        this.txtInvoicePaymentDate_module.Enabled = false;
                        this.txtamtpaid_module.Enabled = false;
                        this.divUpdateMain.Style.Add("display", "none");
                        this.divMessage.Style.Add("display", "none");
                        this.divrecordpayment.Style.Add("display", "none");
                        this.div_linkclick.Style.Add("display", "none");
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                    {
                        this.ModuleType = "invoicesummary";
                        if (base.Request.Params["IsPaid"].ToString() != "1")
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForSummary();", true);
                            base.Title = "Invoice Payment";
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                            this.lblnewpayment.Visible = true;
                            this.BindInvoicePaidRecords();
                        }
                        else
                        {
                            base.Title = "Payment Record History";
                            this.divMessage.Style.Add("display", "none");
                            this.RadPanelBar1.Style.Add("display", "none");
                            this.lblnewpayment.Visible = true;
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                            this.divrecordpayment.Style.Add("display", "block");
                            this.divbtnrecord.Style.Add("display", "none");
                            this.divamountpaidshowhide.Style.Add("display", "none");
                            this.divpaymentradio.Style.Add("display", "none");
                            this.DivPaddingTop.Style.Add("display", "none");
                            this.rdopaymenttype.Items[0].Selected = true;
                            this.btnRecord.Enabled = true;
                            this.btnRecordNclose.Enabled = true;
                            this.ddl_Paymentmode.Enabled = true;
                            this.txtInvoicePaymentDate.Enabled = true;
                            this.txt_PaymentDetailNotes.Enabled = true;
                            this.BindInvoicePaidRecords();
                        }
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview")
                    {
                        this.ModuleType = "jobrecordview";
                        if (base.Request.Params["IsPaid"].ToString() != "1")
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForSummary();", true);
                            base.Title = "Invoice Payment";
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                            this.lblnewpayment.Visible = true;
                            this.BindInvoicePaidRecords();
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:PaymentDetails_New('invoice');", true);
                            base.Title = "Payment Record History";
                            this.divMessage.Style.Add("display", "none");
                            this.RadPanelBar1.Style.Add("display", "none");
                            this.lblnewpayment.Visible = true;
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                            this.divrecordpayment.Style.Add("display", "block");
                            this.divbtnrecord.Style.Add("display", "none");
                            this.divamountpaidshowhide.Style.Add("display", "none");
                            this.divpaymentradio.Style.Add("display", "none");
                            this.DivPaddingTop.Style.Add("display", "none");
                            this.rdopaymenttype.Items[0].Selected = true;
                            this.btnRecord.Enabled = true;
                            this.btnRecordNclose.Enabled = true;
                            this.ddl_Paymentmode.Enabled = true;
                            this.txtInvoicePaymentDate.Enabled = true;
                            this.txt_PaymentDetailNotes.Enabled = true;
                            this.BindInvoicePaidRecords();
                        }
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                    {
                        this.ModuleType = "ojsummary";
                        if (base.Request.Params["IsPaid"].ToString() != "1")
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForOJSummary();", true);
                            base.Title = "Invoice Payment";
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                            this.lblnewpayment.Visible = true;
                            this.BindInvoicePaidRecords();
                        }
                        else
                        {
                            base.Title = "Payment Record History";
                            this.divMessage.Style.Add("display", "none");
                            this.RadPanelBar1.Style.Add("display", "none");
                            this.lblnewpayment.Visible = true;
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                            this.divrecordpayment.Style.Add("display", "block");
                            this.divbtnrecord.Style.Add("display", "none");
                            this.divamountpaidshowhide.Style.Add("display", "none");
                            this.divpaymentradio.Style.Add("display", "none");
                            this.DivPaddingTop.Style.Add("display", "none");
                            this.rdopaymenttype.Items[0].Selected = true;
                            this.btnRecord.Enabled = true;
                            this.btnRecordNclose.Enabled = true;
                            this.ddl_Paymentmode.Enabled = true;
                            this.txtInvoicePaymentDate.Enabled = true;
                            this.txt_PaymentDetailNotes.Enabled = true;
                            this.BindInvoicePaidRecords();
                        }
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                    {
                        this.ModuleType = "orderinvoicesummary";
                        if (base.Request.Params["IsPaid"].ToString() != "1")
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForSummary();", true);
                            base.Title = "Invoice Payment";
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                            this.lblnewpayment.Visible = true;
                            this.BindInvoicePaidRecords();
                        }
                        else
                        {
                            base.Title = "Payment Record History";
                            this.divMessage.Style.Add("display", "none");
                            this.RadPanelBar1.Style.Add("display", "none");
                            this.lblnewpayment.Visible = true;
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                            this.divrecordpayment.Style.Add("display", "block");
                            this.divbtnrecord.Style.Add("display", "none");
                            this.divamountpaidshowhide.Style.Add("display", "none");
                            this.divpaymentradio.Style.Add("display", "none");
                            this.DivPaddingTop.Style.Add("display", "none");
                            this.rdopaymenttype.Items[0].Selected = true;
                            this.btnRecord.Enabled = true;
                            this.btnRecordNclose.Enabled = true;
                            this.ddl_Paymentmode.Enabled = true;
                            this.txtInvoicePaymentDate.Enabled = true;
                            this.txt_PaymentDetailNotes.Enabled = true;
                            this.BindInvoicePaidRecords();
                        }
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "job_view" || base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:PaymentTypeOnChangeNew();FetchEstimateIDs();", true);
                        base.Title = "Invoice Payment";
                        this.ModuleType = "jobinvview";
                        this.rdopaymenttype.Items[0].Selected = true;
                        this.rdopaymenttype.Items[0].Enabled = true;
                        this.rdopaymenttype.Items[1].Attributes.Add("style", "display:none");
                        this.rdopaymenttype.Items[2].Attributes.Add("style", "display:none");
                    }
                    else if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary")
                    {
                        this.ModuleType = "ordersummary";
                        if (base.Request.Params["IsPaid"].ToString() != "1")
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OnChangeForWebStore();", true);
                            base.Title = "Invoice Payment";
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_Payment");
                            this.lblnewpayment.Visible = true;
                            this.divrecordpayment.Style.Add("display", "block");
                            this.BindInvoicePaidRecords();
                        }
                        else
                        {
                            base.Title = "Payment Record History";
                            this.divMessage.Style.Add("display", "none");
                            this.RadPanelBar1.Style.Add("display", "none");
                            this.lblnewpayment.Visible = true;
                            this.spnlnk.InnerText = Invoice_Paid.objLanguage.GetLanguageConversion("Click_here_to_record_a_new_Payment");
                            this.divrecordpayment.Style.Add("display", "block");
                            this.divbtnrecord.Style.Add("display", "none");
                            this.divamountpaidshowhide.Style.Add("display", "none");
                            this.divpaymentradio.Style.Add("display", "none");
                            this.DivPaddingTop.Style.Add("display", "none");
                            this.rdopaymenttype.Items[0].Selected = true;
                            this.btnRecord.Enabled = true;
                            this.btnRecordNclose.Enabled = true;
                            this.ddl_Paymentmode.Enabled = true;
                            this.txtInvoicePaymentDate.Enabled = true;
                            this.txt_PaymentDetailNotes.Enabled = true;
                            this.BindInvoicePaidRecords();
                        }
                    }
                }
            }
            else if ((base.Request.Params["Module"] == null || !(base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")) && (base.Request.Params["Module"] == null || !(base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")) && (base.Request.Params["Module"] == null || !(base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder")) && !(base.Request.Params["Module"].ToString().ToLower() == "ordersummary") && !(base.Request.Params["Module"].ToString().ToLower() == "jobrecordview") && !(base.Request.Params["Module"].ToString().ToLower() == "ojsummary"))
            {
                this.ModuleType = "";
                if (base.Request.Params["EstimateID"] != null)
                {
                    this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstimateID"].ToString());
                    this.hdnEstimateID.Value = this.EstimateID.ToString();
                    if (this.EstimateID != (long)0)
                    {
                        Invoice_Paid.MoreEstimateID[0] = Convert.ToInt32(this.EstimateID);
                    }
                    else if (this.EstimateID == (long)0)
                    {
                        string[] strArrays1 = this.hdnEstimatIds.Value.Split(new char[] { ',' });
                        Invoice_Paid.MoreEstimateID = new int[(int)strArrays1.Length];
                        for (int j = 0; j < (int)strArrays1.Length; j++)
                        {
                            if (strArrays1[j].ToString() != "")
                            {
                                int[] num = Invoice_Paid.MoreEstimateID;
                                string str1 = strArrays1[j];
                                char[] chrArray2 = new char[] { '\u005F' };
                                num[j] = Convert.ToInt32(str1.Split(chrArray2)[0].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                if (base.Request.Params["Module"] != null && base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                {
                    this.ModuleType = "invoicesummary";
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary")
                {
                    this.ModuleType = "orderinvoicesummary";
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder")
                {
                    this.ModuleType = "";
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "jobrecordview")
                {
                    this.ModuleType = "jobrecordview";
                }
                else if (base.Request.Params["Module"].ToString().ToLower() != "ojsummary")
                {
                    this.ModuleType = "ordersummary";
                }
                else
                {
                    this.ModuleType = "ojsummary";
                }
                if (base.Request.Params["EstimateID"] != null)
                {
                    this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstimateID"].ToString());
                    this.hdnEstimateID.Value = this.EstimateID.ToString();
                    if (this.EstimateID != (long)0)
                    {
                        Invoice_Paid.MoreEstimateID[0] = Convert.ToInt32(this.EstimateID);
                    }
                    else if (this.EstimateID == (long)0)
                    {
                        string[] strArrays2 = this.hdnEstimatIds.Value.Split(new char[] { ',' });
                        Invoice_Paid.MoreEstimateID = new int[(int)strArrays2.Length];
                        for (int k = 0; k < (int)strArrays2.Length; k++)
                        {
                            if (strArrays2[k].ToString() != "")
                            {
                                int[] numArray = Invoice_Paid.MoreEstimateID;
                                string str2 = strArrays2[k];
                                char[] chrArray3 = new char[] { '\u005F' };
                                numArray[k] = Convert.ToInt32(str2.Split(chrArray3)[0].ToString());
                            }
                        }
                    }
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("job"))
            {
                Invoice_Paid.Module = "job";
                this.Pgtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice"))
            {
                Invoice_Paid.Module = "estimate";
                this.Pgtype = "estimate";
            }
            else
            {
                Invoice_Paid.Module = "invoice";
                this.Pgtype = "invoice";
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (this.Session["email"] == null)
            {
                base.Response.Redirect(string.Concat(global.sitePath(), "error.aspx"));
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable1 = SettingsBasePage.settings_PaymentValue_select((long)this.CompanyID);
                string condition = "PaymentModeID = '4' OR PaymentModeID = '19'";
                DataRow[] rowsToRemove = dataTable1.Select(condition);
                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    dataTable1.Rows.Remove(rowToRemove);
                }

                this.ddl_Paymentmode.DataSource = dataTable1;
                this.ddl_Paymentmode.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode.DataBind();
                this.ddl_Paymentmode.Items.Insert(0, " ");
                this.ddl_Paymentmode.Items[0].Text = "--Select--";
                this.ddl_Paymentmode.Items[0].Value = "0";
                this.ddl_Paymentmode_module.DataSource = dataTable1;
                this.ddl_Paymentmode_module.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode_module.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode_module.DataBind();
                this.ddl_Paymentmode_module.Items.Insert(0, " ");
                this.ddl_Paymentmode_module.Items[0].Text = "--Select--";
                this.ddl_Paymentmode_module.Items[0].Value = "0";
                this.ddl_Paymentmode_Add.DataSource = dataTable1;
                this.ddl_Paymentmode_Add.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode_Add.DataValueField = "PaymentModeID";
                
                this.ddl_Paymentmode_Add.DataBind();
                this.ddl_Paymentmode_Add.Items.Insert(0, " ");
                this.ddl_Paymentmode_Add.Items[0].Text = "--Select--";
                this.ddl_Paymentmode_Add.Items[0].Value = "0";
                string paymentSelectedMethod = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    paymentSelectedMethod = row["InvoicePaymentMethod"].ToString();
                    if (!string.IsNullOrEmpty(paymentSelectedMethod))
                    {
                        this.ddl_Paymentmode_Add.SelectedValue = paymentSelectedMethod;
                    }
                    else
                    {
                        this.ddl_Paymentmode_Add.SelectedValue = "0";
                    }
                }
                if (string.IsNullOrEmpty(paymentSelectedMethod))
                {
                    this.ddl_Paymentmode_Add.SelectedValue = "0";
                }
                TextBox txtInvoicePaymentDateAdd = this.txtInvoicePaymentDate_Add;
                commonClass _commonClass1 = this.commclass;
                DateTime dateTime = DateTime.Now;
                txtInvoicePaymentDateAdd.Text = _commonClass1.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                TextBox txtInvoicePaymentDateModule = this.txtInvoicePaymentDate_module;
                commonClass _commonClass2 = this.commclass;
                DateTime now1 = DateTime.Now;
                txtInvoicePaymentDateModule.Text = _commonClass2.Eprint_return_Date_Before_View(now1.ToString(), this.CompanyID, this.UserID, true);
                TextBox textBox = this.txtInvoicePaymentDate;
                commonClass _commonClass3 = this.commclass;
                DateTime dateTime1 = DateTime.Now;
                textBox.Text = _commonClass3.Eprint_return_Date_Before_View(dateTime1.ToString(), this.CompanyID, this.UserID, true);
            }
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (!base.IsPostBack)
            {
                if (!this.commclass.performinvoicecheck(this.CompanyID, Invoice_Paid.Module, "Job_Progress_to_Invoice"))
                {
                    this.rdnProformaInvYes.Checked = true;
                    this.rdnProformaInvNo.Checked = false;
                }
                else
                {
                    this.rdnProformaInvNo.Checked = true;
                    this.rdnProformaInvYes.Checked = false;
                }
                if (Invoice_Paid.Module == "job")
                {
                    this.rdnProformaInvYes.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Generate_Invoice_and_keep_the_job__Item_live");
                    this.rdnProformaInvNo.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Generate_Invoice_and_archive_the_job_Item");
                }
                this.txtInvoicePaymentDate_module.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtInvoicePaymentDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                this.txtInvoicePaymentDate_Add.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
                commonClass _commonClass4 = this.commclass;
                string dateFormat = this.DateFormat;
                commonClass _commonClass5 = this.commclass;
                DateTime now2 = DateTime.Now;
                string str3 = _commonClass4.date_Check_new(dateFormat, _commonClass5.Eprint_return_Date_Before_View(now2.ToString(), this.CompanyID, this.UserID, false), this.CompanyID);
                try
                {
                    this.TodayDate = Convert.ToDateTime(str3);
                }
                catch
                {
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["Module"].ToString().ToLower() == "job_view")
                {
                    HttpCookie httpCookie = new HttpCookie("jobviewestids");
                    httpCookie = base.Request.Cookies["jobviewestids"];
                    if (httpCookie != null)
                    {
                        string[] strArrays3 = httpCookie.Value.Split(new char[] { ',' });
                        this.ViewSelectedEstimateID = new int[(int)strArrays3.Length];
                        Invoice_Paid.JobIDsFMMain = new int[(int)strArrays3.Length];
                        Invoice_Paid.EstimateIDsFMMain = new int[(int)strArrays3.Length];
                        Invoice_Paid.ItemIDsFMMain_Array = new int[(int)strArrays3.Length];
                        for (int l = 0; l < (int)strArrays3.Length; l++)
                        {
                            if (strArrays3[l].ToString() != "")
                            {
                                int[] viewSelectedEstimateID = this.ViewSelectedEstimateID;
                                string str4 = strArrays3[l];
                                char[] chrArray4 = new char[] { '\u005F' };
                                viewSelectedEstimateID[l] = Convert.ToInt32(str4.Split(chrArray4)[1].ToString());
                                int[] jobIDsFMMain = Invoice_Paid.JobIDsFMMain;
                                string str5 = strArrays3[l];
                                char[] chrArray5 = new char[] { '\u005F' };
                                jobIDsFMMain[l] = Convert.ToInt32(str5.Split(chrArray5)[0].ToString());
                                int[] estimateIDsFMMain = Invoice_Paid.EstimateIDsFMMain;
                                string str6 = strArrays3[l];
                                char[] chrArray6 = new char[] { '\u005F' };
                                estimateIDsFMMain[l] = Convert.ToInt32(str6.Split(chrArray6)[1].ToString());
                                string itemIDsFMMain = this.ItemIDsFMMain;
                                string str7 = strArrays3[l];
                                char[] chrArray7 = new char[] { '\u005F' };
                                this.ItemIDsFMMain = string.Concat(itemIDsFMMain, str7.Split(chrArray7)[2].ToString(), ",");
                                int[] itemIDsFMMainArray = Invoice_Paid.ItemIDsFMMain_Array;
                                string str8 = strArrays3[l];
                                char[] chrArray8 = new char[] { '\u005F' };
                                itemIDsFMMainArray[l] = Convert.ToInt32(str8.Split(chrArray8)[2].ToString());
                            }
                        }
                        now = DateTime.Now;
                        httpCookie.Expires = now.AddDays(-1);
                        base.Response.Cookies.Add(httpCookie);
                    }
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
                {
                    HttpCookie item = new HttpCookie("invoiceviewestids");
                    item = base.Request.Cookies["invoiceviewestids"];
                    if (item != null)
                    {
                        string value1 = item.Value;
                        chrArray = new char[] { ',' };
                        string[] strArrays4 = value1.Split(chrArray);
                        this.ViewSelectedEstimateID = new int[(int)strArrays4.Length];
                        Invoice_Paid.InvoiceIDsFMMain = new int[(int)strArrays4.Length];
                        Invoice_Paid.EstimateIDsFMMain = new int[(int)strArrays4.Length];
                        for (int m = 0; m < (int)strArrays4.Length; m++)
                        {
                            if (strArrays4[m].ToString() != "")
                            {
                                int[] viewSelectedEstimateID1 = this.ViewSelectedEstimateID;
                                string str9 = strArrays4[m];
                                chrArray = new char[] { '\u005F' };
                                if (Array.IndexOf<int>(viewSelectedEstimateID1, Convert.ToInt32(str9.Split(chrArray)[1])) == -1)
                                {
                                    int[] num1 = this.ViewSelectedEstimateID;
                                    string str10 = strArrays4[m];
                                    chrArray = new char[] { '\u005F' };
                                    num1[m] = Convert.ToInt32(str10.Split(chrArray)[1].ToString());
                                }
                                int[] invoiceIDsFMMain = Invoice_Paid.InvoiceIDsFMMain;
                                string str11 = strArrays4[m];
                                chrArray = new char[] { '\u005F' };
                                if (Array.IndexOf<int>(invoiceIDsFMMain, Convert.ToInt32(str11.Split(chrArray)[0])) == -1)
                                {
                                    int[] invoiceIDsFMMain1 = Invoice_Paid.InvoiceIDsFMMain;
                                    string str12 = strArrays4[m];
                                    chrArray = new char[] { '\u005F' };
                                    invoiceIDsFMMain1[m] = Convert.ToInt32(str12.Split(chrArray)[0].ToString());
                                }
                                int[] estimateIDsFMMain1 = Invoice_Paid.EstimateIDsFMMain;
                                string str13 = strArrays4[m];
                                chrArray = new char[] { '\u005F' };
                                if (Array.IndexOf<int>(estimateIDsFMMain1, Convert.ToInt32(str13.Split(chrArray)[1])) == -1)
                                {
                                    int[] numArray1 = Invoice_Paid.EstimateIDsFMMain;
                                    string str14 = strArrays4[m];
                                    chrArray = new char[] { '\u005F' };
                                    numArray1[m] = Convert.ToInt32(str14.Split(chrArray)[1].ToString());
                                }
                            }
                        }
                        Invoice_Paid.InvoiceIDsFMMain = Array.FindAll<int>(Invoice_Paid.InvoiceIDsFMMain, new Predicate<int>(Invoice_Paid.isNotZero));
                        now = DateTime.Now;
                        item.Expires = now.AddDays(-1);
                        base.Response.Cookies.Add(item);
                    }
                }
            }
            if (base.IsPostBack)
            {
                if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary" && this.Invoice_ID != (long)0)
                {
                    this.ModuleType = "invoicesummary";
                    DataTable dataTable2 = InvoiceBasePage.InvoicePaid_HistoryDetails_Select(this.CompanyID, this.Invoice_ID);
                    enumerator = dataTable2.Rows.GetEnumerator();
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
                        disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                else if (base.Request.Params["Module"].ToString().ToLower() != "job_view" && base.Request.Params["Module"].ToString().ToLower() != "invoice_view" && this.Invoice_ID != (long)0)
                {
                    DataTable dataTable3 = InvoiceBasePage.InvoicePaid_HistoryDetails_Select(this.CompanyID, this.Invoice_ID);
                    enumerator = dataTable3.Rows.GetEnumerator();
                    try
                    {
                        if (enumerator.MoveNext())
                        {
                            DataRow dataRow = (DataRow)enumerator.Current;
                            this.TotalAmountPaid = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                        }
                    }
                    finally
                    {
                        disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            string empty = string.Empty;
            DataTable dataTable4 = new DataTable();
            if (base.Request.Params["Module"].ToString().ToLower() == "job_view" || base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
            {
                this.divInvDetails.Visible = false;
                this.plhamountpaid.Controls.Add(new LiteralControl("<table id='tbinvoicesummery' cellpadding='0' cellspacing='0' style='width:100%;float:center'>"));
                this.plhamountpaid.Controls.Add(new LiteralControl("<tr>"));
                this.plhamountpaid.Controls.Add(new LiteralControl("<td>"));
                this.plhamountpaid.Controls.Add(new LiteralControl("<div class='bglabelforamountpaid' style='width: 150px;margin-left:5px;'>"));
                this.plhamountpaid.Controls.Add(new LiteralControl(Invoice_Paid.objLanguage.GetLanguageConversion("invoice_number")));
                this.plhamountpaid.Controls.Add(new LiteralControl("</div>"));
                this.plhamountpaid.Controls.Add(new LiteralControl("<div id='divinvoicenumber' class='box'  style='margin-top: 4px;width:55%;'>"));
                for (int n = 0; n < (int)Invoice_Paid.InvoiceIDsFMMain.Length; n++)
                {
                    if (Invoice_Paid.InvoiceIDsFMMain[n].ToString() != "0")
                    {
                        foreach (DataRow row1 in InvoiceBasePage.InvoiceDetails_ByInvoiceID_Select((long)Invoice_Paid.InvoiceIDsFMMain[n]).Rows)
                        {
                            Label label = new Label()
                            {
                                ID = string.Concat("lblinvoiceid_", Invoice_Paid.InvoiceIDsFMMain[n].ToString()),
                                Width = 90
                            };
                            empty = string.Concat(empty, row1["InvoiceNumber"].ToString(), ",");
                            if (n != (int)Invoice_Paid.InvoiceIDsFMMain.Length - 1)
                            {
                                Label label1 = label;
                                label1.Text = string.Concat(label1.Text, row1["InvoiceNumber"].ToString(), ", ");
                            }
                            else
                            {
                                Label label2 = label;
                                label2.Text = string.Concat(label2.Text, row1["InvoiceNumber"].ToString());
                            }
                            this.plhamountpaid.Controls.Add(label);
                        }
                    }
                }
                this.plhamountpaid.Controls.Add(new LiteralControl("</div>"));
            }
            else if (base.Request.Params["Module"].ToString().ToLower() != "ordersummary")
            {
                this.divaddEdit.Style.Add("display", "none");
                this.divview.Style.Add("display", "none");
                DataTable dataTable5 = new DataTable();
                if (base.Request.Params["Module"].ToString().ToLower() == "orderinvoicesummary" || base.Request.Params["Module"].ToString().ToLower() == "jobrecordview" && base.Request.Params["IsJobFromWebstore"].ToString().ToLower() == "1" || base.Request.Params["Module"].ToString().ToLower() == "ojsummary")
                {
                    dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "orderinvoicesummary");
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                {
                    dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select_Items(this.CompanyID, "", this.Invoice_ID);
                }
                else if (base.Request.Params["Module"].ToString().ToLower() != "progresstoinvoicefromjob" && base.Request.Params["Module"].ToString().ToLower() != "progresstoinvoicefromorder")
                {
                    dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "");
                }
                else if (this.ProgressType != "main")
                {
                    dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForJob_select(this.CompanyID, this.Job_ID, this.EstItemID);
                }
                else
                {
                    this.dtAllItems = OrderBasePage.Select_OrderAdditionalOptions(this.CompanyID, this.EstimateID, this.EstimateID);
                    if (this.hdnPaymentMode.Value.Contains("Braintree") || this.hdnPaymentMode.Value.Contains("Stripe") || this.hdnPaymentMode.Value.Contains("Paypal") || this.dtAllItems.Rows.Count != 0 || this.hdnPaymentMode.Value.Contains("API payment"))
                    {
                        dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForJob_select(this.CompanyID, this.Job_ID, (long)0);
                    }
                    else
                    {
                        DataTable dataTable6 = new DataTable();
                        if (this.Job_ID > (long)0)
                        {
                            dataTable6 = JobsBasePage.Select_All_Job_Item(this.Job_ID);
                        }
                        if (dataTable6.Rows.Count == 1)
                        {
                            this.hdnAllItemIDs.Value = string.Concat(dataTable6.Rows[0]["EstimateItemID"].ToString(), "¶");
                            this.hdnSelectedItemIDs.Value = string.Concat(dataTable6.Rows[0]["EstimateItemID"].ToString(), "¶");
                            dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForJob_select(this.CompanyID, this.Job_ID, Convert.ToInt64(dataTable6.Rows[0]["EstimateItemID"]));
                        }
                        else if (dataTable6.Rows.Count > 1)
                        {
                            this.TotalPriceWithShoppingCartValue = Convert.ToDecimal(dataTable6.Rows[0]["ShoppingCartValue"].ToString()) / dataTable6.Rows.Count;
                            this.TotalTaxWithShoppingCartValue = Convert.ToDecimal(dataTable6.Rows[0]["OrderTotalTax"].ToString()) / dataTable6.Rows.Count;
                            this.plhJobItems.Controls.Add(new LiteralControl("<div id='divEstItemsList_Inner' style='overflow-y: auto; max-height: 360px; height: auto; padding-left: 2px;'>"));
                            foreach (DataRow dataRow1 in dataTable6.Rows)
                            {
                                this.div_JobStatus.Style.Add("display", "none");
                                string str15 = dataRow1["EstimateItemID"].ToString();
                                string str16 = dataRow1["ItemTitle"].ToString().Replace("<br/>", " - ");
                                string str17 = dataRow1["JobItemNumber"].ToString();
                                this.Currency = this.commclass.GetCurrencyinRequiredFormate("", true);
                                if (Convert.ToInt64(dataRow1["InvoiceID"]) != (long)0)
                                {
                                    continue;
                                }
                                ControlCollection controls = this.plhJobItems.Controls;
                                languageConversion = new string[] { "<div style='padding: 0px 5px 6px 0px; float: left;'><input style='cursor: pointer;' type='checkbox' id='chkJobItems_", str15, "' title='", str16, "' checked='checked' value='", str15, "'/></div>" };
                                controls.Add(new LiteralControl(string.Concat(languageConversion)));
                                this.plhJobItems.Controls.Add(new LiteralControl("<table><tr><td valign='top' width='110px;'>"));
                                this.plhJobItems.Controls.Add(new LiteralControl(string.Concat("<div style='float: left;'>", str17, "</div></td>")));
                                this.plhJobItems.Controls.Add(new LiteralControl(string.Concat("<td valign='top' style='text-align:justify'; width='320px';>", str16, "</td></tr>")));
                                this.plhJobItems.Controls.Add(new LiteralControl("<tr></tr></table>"));
                                ControlCollection controlCollections = this.plhJobItems.Controls;
                                //object[] objArray = new object[] { "<input type='hidden'id='hdnItemAmount_", str15, "' value='", (Convert.ToDecimal(dataRow1["TotalSubTotal1"]) + Convert.ToDecimal(dataRow1["ShoppingCartValue"])) + Convert.ToDecimal(dataRow1["OrderTotalTax"]), "' />" };

                                object[] objArray = new object[] { "<input type='hidden'id='hdnItemAmount_", str15, "' value='", (Convert.ToDecimal(dataRow1["TotalSellingPrice"]) ), "' />" };

                                //TotalSellingPrice
                                controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                                this.plhJobItems.Controls.Add(new LiteralControl("<div style='clear: both;'></div>"));
                                this.hdnAllItemIDs.Value = string.Concat(this.hdnAllItemIDs.Value, str15, "¶");
                            }
                            this.plhJobItems.Controls.Add(new LiteralControl("</div>"));
                            this.plhJobItems.Controls.Add(new LiteralControl("<div style='padding-top: 5px; float: left; padding-left: 23px;'><input type='submit' id='btnJobItems_Next' value='Next' class='button' onclick='javascript:JobItemListNext();return false;'/></div>"));
                            dataTable5 = InvoiceBasePage.PaymentAmountPaid_ForJob_select(this.CompanyID, this.Job_ID, (long)0);
                        }
                    }
                }
                foreach (DataRow row2 in dataTable5.Rows)
                {
                    this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalSellingPrice"]), 0, "", false, false, true, false, true));
                    this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                    this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                    if (row2["InvoiceNumber"].ToString() == "0")
                    {
                        continue;
                    }
                    this.plhamountpaid.Visible = false;
                    this.divInvDetails.Visible = true;
                    this.lblinvoicenovalue.Text = row2["InvoiceNumber"].ToString();
                    this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(row2["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblCustomervalue.Text = row2["CompanyName"].ToString();
                    this.lblPaymentTermsvalue.Text = string.Concat(row2["PaymentName"].ToString(), " (", row2["PaymentTerms"].ToString(), " days)");
                    this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
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
                        this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
                    }
                }
            }
            else
            {
                DataTable dataTable7 = new DataTable();
                if (base.Request.Params["Module"].ToString().ToLower() != "ordersummary")
                {
                    dataTable7 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "");
                }
                else
                {
                    dataTable7 = InvoiceBasePage.PaymentAmountPaid_ForInvoice_select(this.CompanyID, this.EstimateID, "orderinvoicesummary");
                    if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0" || (this.hdnPaymentMode.Value.Contains("Braintree") || this.hdnPaymentMode.Value.Contains("Stripe") || this.hdnPaymentMode.Value.Contains("Paypal") || this.hdnPaymentMode.Value.Contains("API payment")) && base.Request.Params["IsPaid"].ToString().ToLower() == "1")
                    {
                        DataTable dataTable8 = InvoiceBasePage.OrderDetails_select(this.CompanyID, this.EstimateID);
                        enumerator = dataTable8.Rows.GetEnumerator();
                        try
                        {
                            if (enumerator.MoveNext())
                            {
                                DataRow current1 = (DataRow)enumerator.Current;
                                this.TotalAmountPaid = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(current1["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                            }
                        }
                        finally
                        {
                            disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                }
                foreach (DataRow dataRow2 in dataTable7.Rows)
                {
                    this.TotalInvoiceSellingPrice = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["TotalSellingPrice"]), 0, "", false, false, true, false, true));
                    this.OutStandingAmount = this.TotalInvoiceSellingPrice - this.TotalAmountPaid;
                    this.hdntxtvalue.Value = this.OutStandingAmount.ToString();
                    if (dataRow2["InvoiceNumber"].ToString() == "0")
                    {
                        this.plhamountpaid.Visible = false;
                        this.divInvDetails.Visible = true;
                        this.lblinvoicenovalue.Text = "NA";
                        this.lblInvoiceDatevalue.Text = "NA";
                        this.lblCustomervalue.Text = dataRow2["CompanyName"].ToString();
                        this.lblPaymentTermsvalue.Text = string.Concat(dataRow2["PaymentName"].ToString(), " (", dataRow2["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
                        if (base.Request.Params["Module"].ToString().ToLower() == "ordersummary" && base.Request.Params["IsWebStore"].ToString().ToLower() == "1" && base.Request.Params["IsPaid"].ToString().ToLower() == "0")
                        {
                            this.lblOutStandingvalue.ForeColor = Color.Black;
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
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
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
                        }
                    }
                    else
                    {
                        this.plhamountpaid.Visible = false;
                        this.divInvDetails.Visible = true;
                        this.lblinvoicenovalue.Text = dataRow2["InvoiceNumber"].ToString();
                        this.lblInvoiceDatevalue.Text = this.commclass.Eprint_return_Date_Before_View(dataRow2["PaymentDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblCustomervalue.Text = dataRow2["CompanyName"].ToString();
                        this.lblPaymentTermsvalue.Text = string.Concat(dataRow2["PaymentName"].ToString(), " (", dataRow2["PaymentTerms"].ToString(), " days)");
                        this.lblInvAmountvalue.Text = this.commclass.GetCurrencyinRequiredFormate(Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow2["TotalSellingPrice"]), 0, "", false, false, true, false, true)), true);
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
                            this.lblOutStandingvalue.Text = Invoice_Paid.objLanguage.GetLanguageConversion("Nill");
                        }
                    }
                }
                this.lblamountpaidtextdisp.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
                this.lblamountpaidtextdisp_module.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            }
            this.lblamountpaidtextdisp.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
            this.lblamountpaidtextdisp_module.Text = string.Concat(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.commclass.GetCurrencyinRequiredFormate("", true), ")");
           
            if (!(base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromjob") && !(base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder"))
            {
                if (base.Request.Params["Module"].ToString().ToLower() == "invoicesummary")
                {
                    if (!base.IsPostBack)
                    {
                        foreach (DataRow row3 in dataTable.Rows)
                        {
                            this.txt_HolderName_Add.Text = row3["CardHolderName"].ToString();
                            this.txt_cardNumber_Add.Text = row3["CardNumber"].ToString();
                            this.rdopaymenttypeforaddedit.Items[0].Selected = true;
                            if (row3["PaymentType"].ToString() != "Credit Card")
                            {
                                continue;
                            }
                            this.txt_HolderName_Add.Text = row3["CardHolderName"].ToString();
                            if (row3["CardType"].ToString().Trim() == "Visa")
                            {
                                this.rbnVisaID_Add.Checked = true;
                            }
                            if (row3["CardType"].ToString().Trim() == "MasterCard")
                            {
                                this.rbnMasterCardID_Add.Checked = true;
                            }
                            if (row3["CardType"].ToString().Trim() == "American")
                            {
                                this.rbnAmericanID_Add.Checked = true;
                            }
                            if (row3["CardType"].ToString().Trim() == "Discover")
                            {
                                this.rbnDiscoverID_Add.Checked = true;
                            }
                            this.div_CreditCardDetails_Add.Style.Add("display", "block");
                            this.ddl_Paymentmode_Add.SelectedValue = "4";
                            this.ddl_month_Add.SelectedValue = row3["ExpirationMonth"].ToString();
                            this.ddl_year_Add.SelectedValue = row3["ExpirationYear"].ToString();
                            this.txt_verification_Add.Text = row3["SecurityCode"].ToString();
                        }
                    }
                }
                else if (base.Request.Params["Module"].ToString().ToLower() == "job_view" || base.Request.Params["Module"].ToString().ToLower() == "invoice_view")
                {
                    this.rdopaymenttype.Items[0].Enabled = true;
                    this.rdopaymenttype.Items[0].Selected = true;
                    this.rdopaymenttype.Items[1].Enabled = false;
                    this.rdopaymenttype.Items[2].Enabled = false;
                    Label label3 = this.lblviewnote;
                    languageConversion = new string[] { "<div style='margin-left: 5px;'>", Invoice_Paid.objLanguage.GetLanguageConversion("Please_Note"), ":   </div><div style='margin-left: 8px;width: 100%;' class='smallgraytext'> <table><tr class='smallgraytext'><td VAlign='Top'>1.</td><td align='left'>", Invoice_Paid.objLanguage.GetLanguageConversion("Plese_Note_For_Invoice_Amount_paid"), " </td></tr></table>  </div>  <div style='margin-left: 9px;margin-top: 5px;margin-bottom: 5px;'> <table><tr class='smallgraytext'><td VAlign='Top'>2.</td><td align='left'>", Invoice_Paid.objLanguage.GetLanguageConversion("Invoices_which_are_already_paid_full_will_be_ignored"), "</td></tr></table></div>" };
                    label3.Text = string.Concat(languageConversion);
                }
                return;
            }
            this.plhamountpaid.Visible = false;
            this.divInvDetails.Visible = false;
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<table id='tbinvoicesummery' cellpadding='0' cellspacing='0' style='width:100%;float:left'>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div class='bglabelforamountpaid'style='padding-top:3px;width:150px;'>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl(Invoice_Paid.objLanguage.GetLanguageConversion("Invoice_Amount")));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div id='divinvoicesellingprice' class='box' style='width:200px;padding-top:3px;'>"));
            Label label4 = new Label()
            {
                ID = "lblInvoiceSellingprice_",
                Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalInvoiceSellingPrice, 0, "", false, false, true, false, true), true)
            };
            Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.TotalInvoiceSellingPrice, 0, "", false, false, true, false, true));
            this.plhamountpaidinvcreate.Controls.Add(label4);
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div class='bglabel' style='width:150px'>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl(Invoice_Paid.objLanguage.GetLanguageConversion("Amount_paid")));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div id='divoutstandingamount' class='box' style='width:200px;padding-top:3px;' >"));
            Label label5 = new Label()
            {
                ID = "lblAmtpaid",
                Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AmountPaid, 0, "", false, false, true, false, true), true)
            };
            this.plhamountpaidinvcreate.Controls.Add(label5);
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div class='bglabelforamountpaid' style='width:150px'>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl(Invoice_Paid.objLanguage.GetLanguageConversion("Outstanding")));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("<div id='divoutstandingamount' class='box' style='width:200px;padding-top:3px;' >"));
            Label label6 = new Label()
            {
                ID = "lblOustandingAmt",
                Text = this.commclass.GetCurrencyinRequiredFormate(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true), true)
            };
            Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.OutStandingAmount, 0, "", false, false, true, false, true));
            this.plhamountpaidinvcreate.Controls.Add(label6);
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</div>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</td>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</tr>"));
            this.plhamountpaidinvcreate.Controls.Add(new LiteralControl("</table>"));
            if (!base.IsPostBack)
            {
                this.txtamtpaid.Text = Convert.ToString(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, this.AmountPaid, 0, "", false, false, true, false, true));
                this.txtamtpaid.Style.Add("text-align", "right");
                this.rdopaymenttype_module.Items[2].Selected = true;
                if (base.Request.Params["Module"].ToString().ToLower() == "progresstoinvoicefromorder")
                {
                    foreach (DataRow dataRow3 in dataTable.Rows)
                    {
                        if (dataRow3["PaymentType"].ToString() != "Credit Card")
                        {
                            continue;
                        }
                        this.rdopaymenttype_module.Items[2].Selected = false;
                        this.rdopaymenttype_module.Items[0].Selected = true;
                        this.txt_cardNumber_module.Text = dataRow3["CardNumber"].ToString();
                        this.txt_HolderName_module.Text = dataRow3["CardHolderName"].ToString();
                        if (dataRow3["CardType"].ToString().Trim() == "Visa")
                        {
                            this.rbnVisaID_module.Checked = true;
                            this.rbnVisaID_Add.Checked = true;
                        }
                        if (dataRow3["CardType"].ToString().Trim() == "MasterCard")
                        {
                            this.rbnMasterCardID_module.Checked = true;
                            this.rbnMasterCardID_Add.Checked = true;
                        }
                        if (dataRow3["CardType"].ToString().Trim() == "American")
                        {
                            this.rbnAmericanID_module.Checked = true;
                            this.rbnAmericanID_Add.Checked = true;
                        }
                        if (dataRow3["CardType"].ToString().Trim() == "Discover")
                        {
                            this.rbnDiscoverID_module.Checked = true;
                            this.rbnDiscoverID_Add.Checked = true;
                        }
                        this.div_CreditCardDetails_module.Style.Add("display", "block");
                        this.txtamtpaid_module.Enabled = true;
                        this.txtamtpaid_module.Text = this.OutStandingAmount.ToString();
                        this.ddl_Paymentmode_module.Enabled = true;
                        this.ddl_Paymentmode_module.SelectedValue = "4";
                        this.ddl_Paymentmode_Add.SelectedValue = "4";
                        this.txt_verification_module.Text = dataRow3["SecurityCode"].ToString();
                        this.ddl_month_module.SelectedValue = dataRow3["ExpirationMonth"].ToString();
                        this.ddl_year_module.SelectedValue = dataRow3["ExpirationYear"].ToString();
                        this.ddl_month_Add.SelectedValue = dataRow3["ExpirationMonth"].ToString();
                        this.ddl_year_Add.SelectedValue = dataRow3["ExpirationYear"].ToString();
                        this.txt_verification_Add.Text = dataRow3["SecurityCode"].ToString();
                        this.txtInvoicePaymentDate_module.Enabled = true;
                        this.txt_PaymentDetailNotes_module.Enabled = true;
                    }
                }
            }
            this.divrecordpayment.Style.Add("display", "none");
            this.div_NewPaymnethdng.Style.Add("display", "none");
            this.divpaymentradio.Style.Add("display", "none");
            this.divamountpaidshowhide.Style.Add("display", "none");
            this.divamountpaidshowhide_module.Style.Add("display", "block");
            this.PaidYesNo_module.Style.Add("display", "block");
            this.divbtnrecord.Style.Add("display", "none");
            this.DivPaddingTop.Style.Add("display", "block");
        }
    }
}