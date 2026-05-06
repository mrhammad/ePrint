using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol.Item
{
    public partial class Item_summary_ProgressTo_Invoice : UserControl
    {
        public string VersionNumber = ConnectionClass.VersionNumber;

        private Global gloobj = new Global();

        private BaseClass objBC = new BaseClass();

        private commonClass commclass = new commonClass();

        private CompanyBasePage objCom = new CompanyBasePage();

        private notesclass objnotes = new notesclass();

        public languageClass objLanguage = new languageClass();

        private Notes objN = new Notes();

        private SummaryClass SummaryClassObj = new SummaryClass();

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

        public string UserName = string.Empty;

        public string PONO = string.Empty;

        private string Jobconvertedate = string.Empty;

        private DateTime TodayDate;

        private DateTime JobConDate;

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

        public string Pgtype = "estimate";

        public string activityhist = string.Empty;

        public string IsProformaInvoice = string.Empty;

        public string PaperMeasure = string.Empty;

        private BasePage objpage = new BasePage();

        private long InvoiceNum;

        public long InvoiceID__fromdb_ispaid;

        public long[] MoreEstimateID = new long[1];

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

        static Item_summary_ProgressTo_Invoice()
        {
        }

        public Item_summary_ProgressTo_Invoice()
        {
        }

        protected void BtnContinue_onclick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            string str = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtInvoicePaymentDate.Text));
            this.InvoiceNum = this.objCom.settings_lastcounter_select(Convert.ToInt32(base.Session["CompanyID"]), "i");
            long invoiceNum = (long)10000000 + this.InvoiceNum;
            string str1 = string.Concat("INV-", invoiceNum.ToString().Substring(1, invoiceNum.ToString().Length - 1));
            int num = 0;
            if (this.rdnProformaInvYes.Checked)
            {
                num = 1;
            }
            else if (this.rdnProformaInvNo.Checked)
            {
                num = 0;
            }
            string empty = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Header").Rows)
            {
                empty = row["PhraseText"].ToString();
            }
            foreach (DataRow dataRow in SettingsBasePage.settings_default_phrasebook_select(this.CompanyID, "Invoice Footer").Rows)
            {
                empty1 = dataRow["PhraseText"].ToString();
            }
            int defaultStatusID = 0;
            int num1 = 0;
            for (int i = 0; i < (int)this.MoreEstimateID.Length - 1; i++)
            {
                defaultStatusID = SettingsBasePage.get_default_Status_ID(this.CompanyID, "invoice", Convert.ToInt32(this.MoreEstimateID[i]));
                int num2 = 0;
                char chr = 'C';
                DataTable clientDefaultInvoiceDetails = InvoiceBasePage.GetClientDefaultInvoiceDetails(Convert.ToInt32(base.Session["CompanyID"]), this.MoreEstimateID[i]);
                foreach (DataRow row1 in clientDefaultInvoiceDetails.Rows)
                {
                    num2 = Convert.ToInt32(row1["InvoiceAddressID"].ToString());
                    chr = Convert.ToChar(row1["InvoiceAddressType"].ToString());
                }
                if (!this.RdnNo.Checked)
                {
                    num1 = InvoiceBasePage.invoice_insert_ispaid(Convert.ToInt32(base.Session["CompanyID"]), this.MoreEstimateID[i], str1, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(base.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty), this.objBC.ReplaceSingleQuote(empty1), 1, ConnectionClass.IsHandy, num2, chr, num2);
                    InvoiceBasePage.Insert_InvoicePaymentDetails((long)num1, this.MoreEstimateID[i], (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.Text), Convert.ToDateTime(str), this.txt_PaymentDetailNotes.Text, "", "", 0, 0, "0", "0");
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInvPayment);
                }
                else
                {
                    InvoiceBasePage.Invoice_insert(Convert.ToInt32(base.Session["CompanyID"]), this.MoreEstimateID[i], str1, defaultStatusID, this.TodayDate, this.TodayDate, Convert.ToInt32(base.Session["UserID"].ToString()), 0, this.objBC.ReplaceSingleQuote(empty), this.objBC.ReplaceSingleQuote(empty1), 0, ConnectionClass.IsHandy, num2, chr, num2, this.TodayDate, (long)0, "Pending", null, null, null, null, null);
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobProgInv);
                }
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                DataTable dataTable = EstimatesBasePage.select_details_for_Activity_History(this.CompanyID, this.MoreEstimateID[i], "", (long)0);
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    str2 = dataRow1["Estimatenumber"].ToString();
                    empty3 = dataRow1["jobnumber"].ToString();
                    str3 = dataRow1["invoicenumber"].ToString();
                }
                if (num == 1)
                {
                    empty3 = string.Concat(empty3, "<b>(Job Active)</b>");
                }
                this.objnotes.Estimate_number = str2;
                this.objnotes.Job_number = empty3;
                this.objnotes.Invoice_number = str3;
                this.objnotes.ModuleName = "job";
                this.objnotes.ModuleID = this.MoreEstimateID[i];
                this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass1 = this.commclass;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                if (this.InventoryManagement == "IM")
                {
                }
            }
            ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "Close();", true);
        }

        protected void BtnPay_onclick(object sender, EventArgs e)
        {
            commonClass _commonClass = new commonClass();
            BaseClass baseClass = new BaseClass();
            string str = this.date_Check_new(this.DateFormat, baseClass.ReplaceSingleQuote(this.txtInvoicePaymentDate.Text));
            this.InvoiceID__fromdb_ispaid = InvoiceBasePage.invoice_InvoiceID_select(this.CompanyID, this.EstimateID, "Paid");
            InvoiceBasePage.Insert_InvoicePaymentDetails(this.InvoiceID__fromdb_ispaid, this.EstimateID, (long)this.CompanyID, Convert.ToInt32(this.ddl_Paymentmode.SelectedItem.Value), Convert.ToDateTime(str), this.txt_PaymentDetailNotes.Text, "", "", 0, 0, "0", "0");
            string empty = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvPayment);
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass1 = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstimateID));
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

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("jobs", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                this.rdnYes.Visible = false;
            }
            else
            {
                this.rdnYes.Visible = true;
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            this.UserName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            if (base.Request.Url.ToString().ToLower().Contains("job"))
            {
                this.Module = "job";
                this.Pgtype = "job";
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("invoice"))
            {
                this.Module = "estimate";
                this.Pgtype = "estimate";
            }
            else
            {
                this.Module = "invoice";
                this.Pgtype = "invoice";
            }
            if (base.Request.Params["EstimateID"] != null)
            {
                this.EstimateID = (long)Convert.ToInt32(base.Request.Params["EstimateID"].ToString());
                if (this.EstimateID != (long)0)
                {
                    this.MoreEstimateID[0] = this.EstimateID;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "FetchEstimateIDs();", true);
                    if (this.EstimateID == (long)0)
                    {
                        string[] strArrays = this.hdnEstimatIds.Value.Split(new char[] { ',' });
                        this.MoreEstimateID = new long[(int)strArrays.Length];
                        for (int i = 0; i < (int)strArrays.Length - 1; i++)
                        {
                            this.MoreEstimateID[i] = Convert.ToInt64(strArrays[i]);
                        }
                    }
                }
            }
            if (!base.IsPostBack)
            {
                DataTable dataTable = SettingsBasePage.settings_PaymentValue_select((long)this.CompanyID);
                this.ddl_Paymentmode.DataSource = dataTable;
                this.ddl_Paymentmode.DataTextField = "PaymentModeValue";
                this.ddl_Paymentmode.DataValueField = "PaymentModeID";
                this.ddl_Paymentmode.DataBind();
            }
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            string str = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, false);
            this.txtInvoicePaymentDate.Text = str;
            this.txtInvoicePaymentDate.Attributes.Add("onClick", string.Concat("javascript:event.cancelBubble=true;this.select();lcs(this,'", this.DateFormat, "');"));
            this.PaperMeasure = this.objpage.GetRegionalSettings(this.CompanyID, "PaperMeasure");
            if (!base.IsPostBack)
            {
                if (!this.commclass.performinvoicecheck(this.CompanyID, this.Module, "Job_Progress_to_Invoice"))
                {
                    this.rdnProformaInvYes.Checked = true;
                    this.rdnProformaInvNo.Checked = false;
                }
                else
                {
                    this.rdnProformaInvNo.Checked = true;
                    this.rdnProformaInvYes.Checked = false;
                }
            }
            commonClass _commonClass1 = this.commclass;
            string dateFormat = this.DateFormat;
            commonClass _commonClass2 = this.commclass;
            DateTime dateTime = DateTime.Now;
            string str1 = _commonClass1.date_Check_new(dateFormat, _commonClass2.Eprint_return_Date_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, false), this.CompanyID);
            try
            {
                this.TodayDate = Convert.ToDateTime(str1);
            }
            catch
            {
            }
        }
    }
}