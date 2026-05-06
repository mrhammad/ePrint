using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.Item
{
    public partial class Item_Summary_CustomerDetails : UserControl
    {
        //protected HiddenField hdn_Summurypage_ContactID;

        //protected HiddenField hdn_Summurypage_ClientID;

        //protected Label lbl_SummaryHeader;

        //protected Label lbl_UpdateMsg;

        //protected HtmlGenericControl spnCompany;

        //protected Label lblCustomerName;

        //protected Label lblCompanyEmail;

        //protected HtmlGenericControl spnContact;

        //protected Label lblAttention;

        //protected HtmlGenericControl Span1;

        //protected Label lblOrderedBy;

        //protected Label lblCompany;

        //protected Label lblContactEmail;

        //protected Label lblContactPhone;

        //protected Label lblContactMobile;

        //protected Label lblEstimator;

        //protected Label lblGreeting;

        //protected Label lblSalePerson;

        //protected Label lblAddress;

        //protected Label lblDeliveryAddress;

        //protected Label lblInvoiceAddress;

        //protected Label lblHeader;

        //protected HtmlGenericControl Div1_Header;

        //protected Label lblFooter;

        //protected HtmlGenericControl Div2_Footer;

        //protected HtmlGenericControl spntitle;

        //protected Label lblEstimateTitle;

        //protected HtmlGenericControl spnNo;

        //protected Label lblEstimateNo;

        //protected Label lblOrderNo;

        //protected ImageButton Hyperlink_PaymentDetails;

        //protected ImageButton ChengePaymentMode;

        //protected HiddenField hdnEstimate;

        //protected HiddenField hdnPaidValue;

        //protected HiddenField hdnacthist;

        //protected Label lblIspaid;

        //protected HtmlGenericControl Div_InvoicePaid;

        //protected DropDownList ddlStatus;

        //protected HiddenField hdn_SelectedStatusID;

        //protected Label lblInvoicestatus;

        //protected Button btnSaveStatus;

        //protected HiddenField hdnReduceStockTypeForCancelled;

        //protected LinkButton lnkSaveStatus;

        //protected HiddenField hidDeleteID;

        //protected LinkButton lnkEstItemDelete;

        //protected Label lblAccountNo;

        //protected Label lblAccStatus;

        //protected Label lblJobNumber;

        //protected Label lblEstimateDate;

        //protected Label lblInvoiceDueDate;

        //protected HtmlGenericControl div_InvoiceDueDate;

        //protected Label lblProgressedOn;

        //protected Label lblCompletionDate;

        //protected HtmlGenericControl div_JobCompletionDate;

        //protected Label lblDeliveryDate;

        //protected HtmlGenericControl div_JobDeliveryDate;

        //protected Label lblestimatedartwork;

        //protected HtmlGenericControl Div_EstArtwork;

        //protected Label lblestimatedProof;

        //protected HtmlGenericControl Div_Estproof;

        //protected Label lbl_EstApproval;

        //protected HtmlGenericControl div_ApprovalNew;

        //protected Label lbl_EstProduction;

        //protected HtmlGenericControl divProductionDate;

        //protected Label lbl_EstCompletion;

        //protected HtmlGenericControl divJobCompletionDate;

        //protected HtmlGenericControl spnDelivery;

        //protected Label lblestimateddelivery;

        //protected HtmlGenericControl div_deliverydate;

        //protected Label lblInvoiceEstimateWas;

        //protected Label lblInvoiceJobWas;

        //protected Label lblVaidFor;

        //protected Label lbl_Days;

        //protected Label lblcostcentre;

        //protected HtmlGenericControl div_costcentredisp;

        //protected HtmlImage imgBtn_PaymentDetails;

        //protected Label lblPaymentType;

        //protected HtmlGenericControl div_PaymentType;

        //protected Label lblComments;

        //protected Button btn_estimate;

        //protected Label Label10;

        //protected ImageButton ImageButton2;

        //protected Button btnYes;

        //protected Button btnNo;

        //protected HiddenField hdnIsPaid;

        //protected HiddenField hdnJIcreated;

        private SettingsBasePage objSet = new SettingsBasePage();

        private commonClass commclass = new commonClass();

        private BaseClass objBc = new BaseClass();

        public string strSitepath = global.sitePath();

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        private SummaryClass SummaryClassObj = new SummaryClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string strImagepath = global.imagePath();

        public static languageClass objLanguage;

        public languageClass objLang = new languageClass();

        private string EstStatus = string.Empty;

        public string TodayDate = string.Empty;

        public static string Module;

        public string Pgtype = "estimate";

        public long EstimateID;

        public int CompanyID;

        public int UserID;

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

        public int JobID;

        public int InvoiceID;

        public string strtype = string.Empty;

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

        static Item_Summary_CustomerDetails()
        {
            Item_Summary_CustomerDetails.objLanguage = new languageClass();
            Item_Summary_CustomerDetails.Module = "estimate";
            Item_Summary_CustomerDetails.IsJobCopied = false;
            Item_Summary_CustomerDetails.NewEstID = (long)0;
            Item_Summary_CustomerDetails.SalesPersonID = string.Empty;
            Item_Summary_CustomerDetails.IsEditOnlyHisRecords = string.Empty;
        }

        public Item_Summary_CustomerDetails()
        {
        }

        protected void btnSaveStatus_OnClick(object sender, EventArgs e)
        {
            if (Item_Summary_CustomerDetails.Module.ToLower() == "estimate")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", this.EstimateID, "&suc=stae" };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (Item_Summary_CustomerDetails.Module.ToLower() == "job")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", this.EstimateID, "&suc=staj" };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (Item_Summary_CustomerDetails.Module.ToLower() == "invoice")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", this.EstimateID, "&suc=stai" };
                response1.Redirect(string.Concat(estimateID1));
            }
        }

        protected void OnClick_Delete(object sender, EventArgs e)
        {
            string empty = string.Empty;
            this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            DataTable dataTable = Notes.select_item_number_for_Activity_History(this.EstimateID, Convert.ToInt64(this.hidDeleteID.Value), Item_Summary_CustomerDetails.Module);
            foreach (DataRow row in dataTable.Rows)
            {
                empty = row["rownumber"].ToString();
                empty1 = row["EstimateType"].ToString();
            }
            DataTable dataTable1 = Notes.select_item_Title_for_Activity_History(this.CompanyID, this.EstimateID, Convert.ToInt64(this.hidDeleteID.Value), empty1);
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                str1 = dataRow["itemtitle"].ToString();
            }
            if (Item_Summary_CustomerDetails.Module == "estimate")
            {
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemDeleted);
            }
            else if (Item_Summary_CustomerDetails.Module == "job")
            {
                this.objnotes.ModuleName = "job";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.JobItemDeleted);
                if (this.InventoryManagement == "IM")
                {
                    if (this.ReduceStockTypeForCancelled == "a")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, Convert.ToInt64(this.hidDeleteID.Value), this.UserID);
                    }
                    else if (this.ReduceStockTypeForCancelled == "p" && this.hdnReduceStockTypeForCancelled.Value.ToLower() == "true")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, Convert.ToInt64(this.hidDeleteID.Value), this.UserID);
                        this.hdnReduceStockTypeForCancelled.Value = "false";
                    }
                }
            }
            else if (Item_Summary_CustomerDetails.Module == "invoice")
            {
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemDeleted);
                if (this.InventoryManagement == "IM")
                {
                    if (this.ReduceStockTypeForCancelled == "a")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, Convert.ToInt64(this.hidDeleteID.Value), this.UserID);
                    }
                    else if (this.ReduceStockTypeForCancelled == "p" && this.hdnReduceStockTypeForCancelled.Value.ToLower() == "true")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled", this.EstimateID, this.CompanyID, Convert.ToInt64(this.hidDeleteID.Value), this.UserID);
                        this.hdnReduceStockTypeForCancelled.Value = "false";
                    }
                }
            }
            this.objnotes.Item_number = string.Concat("Item ", empty);
            this.objnotes.Item_title = str1;
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            EstimateBasePage.Estimate_Summary_Item_Delete(this.CompanyID, Convert.ToInt64(this.hidDeleteID.Value));
        }

        public void Onclick_lnkNotPaid(object sender, EventArgs e)
        {
            this.InvoiceID__fromdb_ispaid = InvoiceBasePage.invoice_InvoiceID_select(this.CompanyID, this.EstimateID, "NotPaid");
            string empty = string.Empty;
            this.objnotes.ModuleName = "invoice";
            this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvNotPayment);
            this.objnotes.ModuleID = this.EstimateID;
            this.objnotes.CustomerName = string.Concat(base.Session["FirstName"].ToString(), base.Session["LastName"].ToString());
            notesclass _notesclass = this.objnotes;
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            this.objnotes.CompanyID = this.CompanyID;
            this.objnotes.UserID = this.UserID;
            this.objN.NotesAdd(this.objnotes);
            base.Response.Redirect(string.Concat(global.sitePath(), "invoice/invoice_summary_reeng.aspx?frm=view&estid=", this.EstimateID));
        }

        protected void OnClick_ReRunEstimateInfo(object sender, EventArgs e)
        {
            if (Item_Summary_CustomerDetails.Module.ToLower() == "job")
            {
                HttpResponse response = base.Response;
                object[] estimateID = new object[] { this.strSitepath, "jobs/job_add.aspx?type=edit&estid=", this.EstimateID, "&ReRun=Y&jID=", this.JobID };
                response.Redirect(string.Concat(estimateID));
                return;
            }
            if (Item_Summary_CustomerDetails.Module.ToLower() == "invoice")
            {
                HttpResponse httpResponse = base.Response;
                object[] objArray = new object[] { this.strSitepath, "invoice/invoices_add.aspx?type=edit&estid=", this.EstimateID, "&ReRun=Y&InvID=", this.InvoiceID };
                httpResponse.Redirect(string.Concat(objArray));
                return;
            }
            if (Item_Summary_CustomerDetails.Module.ToLower() != "order")
            {
                HttpResponse response1 = base.Response;
                object[] estimateID1 = new object[] { this.strSitepath, "estimates/estimates_add.aspx?type=edit&estid=", this.EstimateID, "&ReRun=Y" };
                response1.Redirect(string.Concat(estimateID1));
                return;
            }
            HttpResponse httpResponse1 = base.Response;
            object[] objArray1 = new object[] { this.strSitepath, "Orders/order_summary_rerun.aspx?type=webstoreorder&orderid=", this.EstimateID, "&estid=", this.EstimateID };
            httpResponse1.Redirect(string.Concat(objArray1));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseClass baseClass = new BaseClass();
            string empty = string.Empty;
            empty = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
            if (empty == "0" || empty == "2")
            {
                this.ChengePaymentMode.Visible = false;
            }
            else
            {
                this.ChengePaymentMode.Visible = true;
            }
            bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
            if (!ConnectionClass.Is_Non_Printing_System)
            {
                this.Div_EstArtwork.Attributes.Add("style", "display:block");
                this.Div_Estproof.Attributes.Add("style", "display:block");
            }
            else
            {
                this.Div_EstArtwork.Attributes.Add("style", "display:none");
                this.Div_Estproof.Attributes.Add("style", "display:none");
            }
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"]);
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["DateFormat"].ToString();
            commonClass _commonClass = this.commclass;
            DateTime now = DateTime.Now;
            this.TodayDate = _commonClass.Eprint_return_Date_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
            if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
            {
                this.div_costcentredisp.Style.Add("display", "block");
            }
            if (!base.IsPostBack)
            {
                this.lbl_SummaryHeader.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Estimate_Information_Detail");
                this.btn_estimate.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("ReRun_Estimate_Info");
            }
            if (base.Request.Params["estid"] != null)
            {
                this.EstimateID = Convert.ToInt64(base.Request.Params["estid"]);
                this.hdnEstimate.Value = base.Request.Params["estid"].ToString();
            }
            if (base.Request.Params["acthist"] != null)
            {
                this.IsFrom = base.Request.Params["acthist"].ToString();
                this.hdnacthist.Value = base.Request.Params["acthist"].ToString();
            }
            if (base.Request.Params["jID"] != null)
            {
                this.JobID = Convert.ToInt32(base.Request.Params["jID"]);
            }
            if (base.Request.Params["InvID"] != null)
            {
                this.InvoiceID = Convert.ToInt32(base.Request.Params["InvID"]);
            }
            if (this.InventoryManagement == "IM")
            {
                this.ReduceStockType = this.commclass.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                this.ReduceStockTypeForCancelled = this.commclass.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
            }
            if (this.IsFrom.ToLower() == "yes")
            {
                this.btn_estimate.Visible = false;
            }
            Item_Summary_CustomerDetails.IsEditOnlyHisRecords = baseClass.ReturnRoles_Privileges_Others("editrecords");
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job"))
            {
                Item_Summary_CustomerDetails.Module = "job";
                this.Pgtype = "job";
                this.btn_estimate.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Re_run_Job_Info");
                this.lbl_SummaryHeader.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Job_Information_Detail");
                if (this.objBc.ReturnRoles_Privileges_ForGrid("jobs", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btn_estimate.Visible = false;
                }
                else if (Item_Summary_CustomerDetails.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != Item_Summary_CustomerDetails.SalesPersonID)
                {
                    this.btn_estimate.Visible = false;
                }
            }
            else if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                Item_Summary_CustomerDetails.Module = "invoice";
                this.Pgtype = "invoice";
                this.btn_estimate.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Rerun_Invoice_Info");
                this.lbl_SummaryHeader.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Invoice_Information_Detail");
                this.div_InvoiceDueDate.Style.Add("display", "block");
                if (this.objBc.ReturnRoles_Privileges_ForGrid("invoices", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btn_estimate.Visible = false;
                }
                else if (Item_Summary_CustomerDetails.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != Item_Summary_CustomerDetails.SalesPersonID)
                {
                    this.btn_estimate.Visible = false;
                }
            }
            else if (!base.Request.Url.ToString().ToLower().Contains("orders/order"))
            {
                Item_Summary_CustomerDetails.Module = "estimate";
                this.Pgtype = "estimate";
                this.btn_estimate.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Re_run_Estimate_Info");
                this.lbl_SummaryHeader.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Estimate_Information_Detail");
                if (this.objBc.ReturnRoles_Privileges_ForGrid("estimates", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btn_estimate.Visible = false;
                }
                else if (Item_Summary_CustomerDetails.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != Item_Summary_CustomerDetails.SalesPersonID)
                {
                    this.btn_estimate.Visible = false;
                }
            }
            else
            {
                Item_Summary_CustomerDetails.Module = "order";
                this.Pgtype = "order";
                this.btn_estimate.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Re_run_Order_Info");
                this.lbl_SummaryHeader.Text = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Ordered_Customer_Detail");
                if (this.objBc.ReturnRoles_Privileges_ForGrid("webstoreorder", "isadd", this.Page.Request.Url.ToString()).Trim().ToLower() == "false")
                {
                    this.btn_estimate.Visible = false;
                }
                else if (Item_Summary_CustomerDetails.IsEditOnlyHisRecords.ToLower() == "his" && base.Session["UserID"].ToString() != Item_Summary_CustomerDetails.SalesPersonID)
                {
                    this.btn_estimate.Visible = false;
                }
                this.Div2_Footer.Visible = false;
                this.Div1_Header.Visible = false;
            }
            if (!base.IsPostBack)
            {
                if (Item_Summary_CustomerDetails.Module == "job")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "--- Select ---", "job");
                }
                else if (Item_Summary_CustomerDetails.Module != "invoice")
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "--- Select ---", "estimate");
                }
                else
                {
                    this.objSet.Bind_Status_new(this.ddlStatus, this.CompanyID, "--- Select ---", "invoice");
                }
                for (int i = 0; i < this.ddlStatus.Items.Count; i++)
                {
                    if (this.ddlStatus.Items[i].Text.ToLower().Trim() == this.EstStatus.ToLower().Trim())
                    {
                        this.ddlStatus.SelectedIndex = i;
                        base.Session["ddlStatus"] = this.EstStatus.ToLower().Trim();
                    }
                }
            }
            if (this.EstimateID != (long)0)
            {
                if (Item_Summary_CustomerDetails.Module.ToLower() == "job")
                {
                    foreach (DataRow row in EstimatesBasePage.estimate_select_summary(this.CompanyID, this.EstimateID).Rows)
                    {
                        this.lblVaidFor.Text = row["ValidFor"].ToString();
                        this.lblCustomerName.Text = this.objBc.SpecialDecode(row["ClientName"].ToString());
                        this.hdn_Summurypage_ClientID.Value = row["ClientID"].ToString();
                        this.lblAttention.Text = this.objBc.SpecialDecode(row["ContactName"].ToString());
                        this.hdn_Summurypage_ContactID.Value = row["AttentionID"].ToString();
                        this.lblEstimateTitle.Text = this.objBc.SpecialDecode(row["EstimateTitle"].ToString());
                        this.lblGreeting.Text = this.objBc.SpecialDecode(row["Greeting"].ToString());
                        this.lblCompany.Text = this.objBc.SpecialDecode(row["Company"].ToString());
                        this.lblCompanyEmail.Text = this.objBc.SpecialDecode(row["BusinessEmail"].ToString());
                        this.lblContactPhone.Text = this.objBc.SpecialDecode(row["HomeTelephone"].ToString());
                        this.lblContactMobile.Text = this.objBc.SpecialDecode(row["ContactMobile"].ToString());
                        this.lblContactEmail.Text = baseClass.SpecialDecode(row["Email"].ToString());
                        this.lblAddress.Text = this.objBc.SpecialDecode(row["Address"].ToString());
                        this.lblDeliveryAddress.Text = this.objBc.SpecialDecode(row["DeliveryAddress"].ToString());

                        this.lblDeliveryAddressLabel.Text = this.objBc.SpecialDecode(row["DeliveryAddressLabel"].ToString()); 

                        this.lblInvoiceAddress.Text = this.objBc.SpecialDecode(row["InvoiceAddress"].ToString());
                        this.lblSalePerson.Text = this.objBc.SpecialDecode(row["SalesPersonName"].ToString());
                        this.lblEstimator.Text = this.objBc.SpecialDecode(row["Estimator"].ToString());
                        this.lblEstimateNo.Text = this.objBc.SpecialDecode(row["EstimateNumber"].ToString());
                        this.lblOrderNo.Text = this.objBc.SpecialDecode(row["OrderNumber"].ToString());
                        this.EstStatus = this.objBc.SpecialDecode(row["StatusTitle"].ToString());
                        this.lblAccountNo.Text = this.objBc.SpecialDecode(row["AccountNo"].ToString());
                        this.lblAccStatus.Text = this.objBc.SpecialDecode(row["CustomerStatusTitle"].ToString());
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row["EstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblestimatedartwork.Text = this.commclass.Eprint_return_Date_Before_View(row["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblestimatedProof.Text = this.commclass.Eprint_return_Date_Before_View(row["Estproofdate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(row["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                        this.lbl_EstApproval.Text = this.commclass.Eprint_return_Date_Before_View(row["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lbl_EstProduction.Text = this.commclass.Eprint_return_Date_Before_View(row["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lbl_EstCompletion.Text = this.commclass.Eprint_return_Date_Before_View(row["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                        Item_Summary_CustomerDetails.SalesPersonID = row["SalesPerson"].ToString();
                        this.lblcostcentre.Text = this.objBc.SpecialDecode(row["CostCentreName"].ToString());
                        this.lblHeader.Text = this.objBc.SpecialDecode(row["Header"].ToString());
                        this.lblFooter.Text = this.objBc.SpecialDecode(row["Footer"].ToString());
                        this.lblComments.Text = this.objBc.SpecialDecode(row["Comments"].ToString());

                        if (!string.IsNullOrEmpty(row["CustomDate1"].ToString()))
                        {
                            this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate1.Text = "";
                        }
                        if (!string.IsNullOrEmpty(row["CustomDate2"].ToString()))
                        {
                            this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate2.Text = "";
                        }
                        if (!string.IsNullOrEmpty(row["CustomDate3"].ToString()))
                        {
                            this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate3.Text = "";
                        }
                        if (!string.IsNullOrEmpty(row["CustomDate4"].ToString()))
                        {
                            this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate4.Text = "";
                        }
                        if (!string.IsNullOrEmpty(row["CustomDate5"].ToString()))
                        {
                            this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate5.Text = "";
                        }

                        Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["invoiceAmount"]), 0, "", false, false, true, false, true));
                        decimal num = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                        if (!(Item_Summary_CustomerDetails.Module.ToLower() == "order") && !base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
                        {
                            continue;
                        }
                        this.lblOrderedBy.Text = this.objBc.SpecialDecode(row["OrderedBy"].ToString());
                        this.lblEstimateNo.Text = this.objBc.SpecialDecode(row["SystemOrderNumber"].ToString());
                        this.lblPaymentType.Text = this.objBc.SpecialDecode(row["PaymentType"].ToString());
                        if (this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("credit card") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                        {
                            if (this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                            {
                                this.hdnIsPaid.Value = "1";
                            }
                            else if (num <= new decimal(0))
                            {
                                this.hdnIsPaid.Value = "0";
                            }
                            else
                            {
                                this.hdnIsPaid.Value = "1";
                            }
                            this.imgBtn_PaymentDetails.Style.Add("display", "block");
                        }
                        this.lblComments.Text = this.objBc.SpecialDecode(row["eStoreComments"].ToString());
                       

                    }
                    DataTable dataTable = JobBasePage.Job_Select_By_JobID(this.CompanyID, (long)this.JobID);
                    string[] strArrays = new string[] { " " };
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        this.lblJobNumber.Text = this.objBc.SpecialDecode(dataRow["EstimateNumber"].ToString());
                        this.lblEstimateNo.Text = this.objBc.SpecialDecode(dataRow["JobNumber"].ToString());
                        string[] strArrays1 = dataRow["CompletionDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblCompletionDate.Text = (this.lblCompletionDate.Text.ToString() == "01/01/1900" ? "" : this.commclass.Eprint_return_Date_Before_View(strArrays1[0].ToString(), this.CompanyID, this.UserID, false));
                        string[] strArrays2 = dataRow["JobDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblEstimateDate.Text = (this.lblEstimateDate.Text.ToString() == "01/01/1900" ? "" : this.commclass.Eprint_return_Date_Before_View(strArrays1[0].ToString(), this.CompanyID, this.UserID, false));
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays2[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays3 = dataRow["ConvertedDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblProgressedOn.Text = this.commclass.Eprint_return_Date_Before_View(strArrays3[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays5 = dataRow["EstimatedArtwork"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblArtworkDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays5[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays6 = dataRow["EstProofDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblProofDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays6[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays7 = dataRow["EstApprovalDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblApprovalDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays7[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays8 = dataRow["EstProductionDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblProductionDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays8[0].ToString(), this.CompanyID, this.UserID, false);
                        string[] strArrays4 = dataRow["DeliveryDate"].ToString().Split(strArrays, StringSplitOptions.None);
                        this.lblDeliveryDate.Text = this.commclass.Eprint_return_Date_Before_View(strArrays4[0].ToString(), this.CompanyID, this.UserID, false);
                        this.lblDeliveryDate.Text = (this.lblDeliveryDate.Text.ToString() == "01/01/1900" ? "" : this.lblDeliveryDate.Text.ToString());

                        if (!string.IsNullOrEmpty(dataRow["CustomDate1"].ToString()))
                        {
                            string[] strArrays91 = dataRow["CustomDate1"].ToString().Split(strArrays, StringSplitOptions.None);
                            this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(strArrays91[0].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate1.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow["CustomDate2"].ToString()))
                        {
                            string[] strArrays92 = dataRow["CustomDate2"].ToString().Split(strArrays, StringSplitOptions.None);
                            this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(strArrays92[0].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate2.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow["CustomDate3"].ToString()))
                        {
                            string[] strArrays93 = dataRow["CustomDate3"].ToString().Split(strArrays, StringSplitOptions.None);
                            this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(strArrays93[0].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate3.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow["CustomDate4"].ToString()))
                        {
                            string[] strArrays94 = dataRow["CustomDate4"].ToString().Split(strArrays, StringSplitOptions.None);
                            this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(strArrays94[0].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate4.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow["CustomDate5"].ToString()))
                        {
                            string[] strArrays95 = dataRow["CustomDate5"].ToString().Split(strArrays, StringSplitOptions.None);
                            this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(strArrays95[0].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate5.Text = "";
                        }

                        this.EstStatus = dataRow["jobstatus"].ToString();
                        Item_Summary_CustomerDetails.SalesPersonID = dataRow["SalesPerson"].ToString();
                        this.lblHeader.Text = this.objBc.SpecialDecode(dataRow["Header"].ToString());
                        this.lblFooter.Text = this.objBc.SpecialDecode(dataRow["Footer"].ToString());
                    }
                }
                else if (Item_Summary_CustomerDetails.Module.ToLower() != "invoice")
                {
                    DataSet appSettingsAndConnectionString = EprintConfigurationManager.GetAppSettingsAndConnectionString();
                    string connectionString = string.Empty;
                    string DbName = string.Empty;
                    foreach(DataRow dr in appSettingsAndConnectionString.Tables[1].Rows)
                    {
                        connectionString=dr["CRMConnectionString"].ToString();
                        string[] strArray = connectionString.Split(';');
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].Contains("Initial Catalog"))
                            {
                                DbName = strArray[i].ToString().Split('=')[1];
                            }
                        }
                    }
                    if(DbName== "eprint_birchprint")
                    {
                        foreach (DataRow row1 in EstimatesBasePage.order_select_summary(this.CompanyID, this.EstimateID).Rows)
                        {
                            this.lblVaidFor.Text = row1["ValidFor"].ToString();
                            this.lblCustomerName.Text = this.objBc.SpecialDecode(row1["ClientName"].ToString());
                            this.hdn_Summurypage_ClientID.Value = row1["ClientID"].ToString();
                            this.lblAttention.Text = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                            this.hdn_Summurypage_ContactID.Value = row1["AttentionID"].ToString();
                            this.lblEstimateTitle.Text = this.objBc.SpecialDecode(row1["EstimateTitle"].ToString());
                            this.lblGreeting.Text = this.objBc.SpecialDecode(row1["Greeting"].ToString());
                            this.lblCompany.Text = this.objBc.SpecialDecode(row1["Company"].ToString());
                            this.lblCompanyEmail.Text = this.objBc.SpecialDecode(row1["BusinessEmail"].ToString());
                            this.lblContactPhone.Text = this.objBc.SpecialDecode(row1["HomeTelephone"].ToString());
                            this.lblContactMobile.Text = this.objBc.SpecialDecode(row1["ContactMobile"].ToString());
                            this.lblContactEmail.Text = baseClass.SpecialDecode(row1["Email"].ToString());
                            this.lblAddress.Text = this.objBc.SpecialDecode(row1["Address"].ToString());
                            this.lblDeliveryAddress.Text = this.objBc.SpecialDecode(row1["DeliveryAddress"].ToString());

                            this.lblDeliveryAddressLabel.Text = this.objBc.SpecialDecode(row1["DeliveryAddressLabel"].ToString());

                            this.lblInvoiceAddress.Text = this.objBc.SpecialDecode(row1["InvoiceAddress"].ToString());
                            this.lblSalePerson.Text = this.objBc.SpecialDecode(row1["SalesPersonName"].ToString());
                            this.lblEstimator.Text = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                            this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["EstimateNumber"].ToString());
                            this.lblOrderNo.Text = this.objBc.SpecialDecode(row1["OrderNumber"].ToString());
                            this.EstStatus = this.objBc.SpecialDecode(row1["StatusTitle"].ToString());
                            this.lblAccountNo.Text = this.objBc.SpecialDecode(row1["AccountNo"].ToString());
                            this.lblAccStatus.Text = this.objBc.SpecialDecode(row1["CustomerStatusTitle"].ToString());
                            this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimatedartwork.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimatedProof.Text = this.commclass.Eprint_return_Date_Before_View(row1["Estproofdate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstApproval.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstProduction.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstCompletion.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                            Item_Summary_CustomerDetails.SalesPersonID = row1["SalesPerson"].ToString();
                            this.lblcostcentre.Text = this.objBc.SpecialDecode(row1["CostCentreName"].ToString());
                            this.lblHeader.Text = this.objBc.SpecialDecode(row1["Header"].ToString());
                            this.lblFooter.Text = this.objBc.SpecialDecode(row1["Footer"].ToString());
                            if (!string.IsNullOrEmpty(row1["CustomDate1"].ToString()))
                            {
                                this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate1.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate2"].ToString()))
                            {
                                this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate2.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate3"].ToString()))
                            {
                                this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate3.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate4"].ToString()))
                            {
                                this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate4.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate5"].ToString()))
                            {
                                this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate5.Text = "";
                            }
                            if (Item_Summary_CustomerDetails.Module.ToLower() != "order")
                            {
                                continue;
                            }
                            Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["invoiceAmount"]), 0, "", false, false, true, false, true));
                            decimal num1 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                            if (this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("credit card") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                            {
                                if (this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                                {
                                    this.hdnIsPaid.Value = "1";
                                }
                                else if (num1 <= new decimal(0))
                                {
                                    this.hdnIsPaid.Value = "0";
                                }
                                else
                                {
                                    this.hdnIsPaid.Value = "1";
                                }
                                this.imgBtn_PaymentDetails.Style.Add("display", "block");
                            }
                            this.lblOrderedBy.Text = this.objBc.SpecialDecode(row1["OrderedBy"].ToString());
                            this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["SystemOrderNumber"].ToString());
                            this.lblPaymentType.Text = this.objBc.SpecialDecode(row1["PaymentType"].ToString());
                            this.lblComments.Text = this.objBc.SpecialDecode(row1["eStoreComments"].ToString());
                           
                        }

                    }
                    else
                    {
                        foreach (DataRow row1 in EstimatesBasePage.estimate_select_summary(this.CompanyID, this.EstimateID).Rows)
                        {
                            this.lblVaidFor.Text = row1["ValidFor"].ToString();
                            this.lblCustomerName.Text = this.objBc.SpecialDecode(row1["ClientName"].ToString());
                            this.hdn_Summurypage_ClientID.Value = row1["ClientID"].ToString();
                            this.lblAttention.Text = this.objBc.SpecialDecode(row1["ContactName"].ToString());
                            this.hdn_Summurypage_ContactID.Value = row1["AttentionID"].ToString();
                            this.lblEstimateTitle.Text = this.objBc.SpecialDecode(row1["EstimateTitle"].ToString());
                            this.lblGreeting.Text = this.objBc.SpecialDecode(row1["Greeting"].ToString());
                            this.lblCompany.Text = this.objBc.SpecialDecode(row1["Company"].ToString());
                            this.lblCompanyEmail.Text = this.objBc.SpecialDecode(row1["BusinessEmail"].ToString());
                            this.lblContactPhone.Text = this.objBc.SpecialDecode(row1["HomeTelephone"].ToString());
                            this.lblContactMobile.Text = this.objBc.SpecialDecode(row1["ContactMobile"].ToString());
                            this.lblContactEmail.Text = baseClass.SpecialDecode(row1["Email"].ToString());
                            this.lblAddress.Text = this.objBc.SpecialDecode(row1["Address"].ToString());
                            this.lblDeliveryAddress.Text = this.objBc.SpecialDecode(row1["DeliveryAddress"].ToString());

                            this.lblDeliveryAddressLabel.Text = this.objBc.SpecialDecode(row1["DeliveryAddressLabel"].ToString());

                            this.lblInvoiceAddress.Text = this.objBc.SpecialDecode(row1["InvoiceAddress"].ToString());
                            this.lblSalePerson.Text = this.objBc.SpecialDecode(row1["SalesPersonName"].ToString());
                            this.lblEstimator.Text = this.objBc.SpecialDecode(row1["Estimator"].ToString());
                            if(this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                            {
                                if(string.IsNullOrEmpty(row1["EstimateNumber"].ToString()))
                                {
                                    this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["SystemOrderNumber"].ToString());
                                }
                                else
                                {
                                    this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["EstimateNumber"].ToString());
                                }
                            }
                            else
                            {
                                this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["EstimateNumber"].ToString());
                            }
                            this.lblOrderNo.Text = this.objBc.SpecialDecode(row1["OrderNumber"].ToString());
                            this.EstStatus = this.objBc.SpecialDecode(row1["StatusTitle"].ToString());
                            this.lblAccountNo.Text = this.objBc.SpecialDecode(row1["AccountNo"].ToString());
                            this.lblAccStatus.Text = this.objBc.SpecialDecode(row1["CustomerStatusTitle"].ToString());
                            this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimateDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimatedartwork.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedArtwork"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimatedProof.Text = this.commclass.Eprint_return_Date_Before_View(row1["Estproofdate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstApproval.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstApprovalDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstProduction.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstProductionDate"].ToString(), this.CompanyID, this.UserID, false);
                            this.lbl_EstCompletion.Text = this.commclass.Eprint_return_Date_Before_View(row1["EstCompletionDate"].ToString(), this.CompanyID, this.UserID, false);
                            Item_Summary_CustomerDetails.SalesPersonID = row1["SalesPerson"].ToString();
                            this.lblcostcentre.Text = this.objBc.SpecialDecode(row1["CostCentreName"].ToString());
                            this.lblHeader.Text = this.objBc.SpecialDecode(row1["Header"].ToString());
                            this.lblFooter.Text = this.objBc.SpecialDecode(row1["Footer"].ToString());
                            this.lblComments.Text = this.objBc.SpecialDecode(row1["Comments"].ToString());

                            if (!string.IsNullOrEmpty(row1["CustomDate1"].ToString()))
                            {
                                this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate1.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate2"].ToString()))
                            {
                                this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate2.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate3"].ToString()))
                            {
                                this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate3.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate4"].ToString()))
                            {
                                this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate4.Text = "";
                            }
                            if (!string.IsNullOrEmpty(row1["CustomDate5"].ToString()))
                            {
                                this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(row1["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);
                            }
                            else
                            {
                                this.lblCustomDate5.Text = "";
                            }

                            if (Item_Summary_CustomerDetails.Module.ToLower() != "order")
                            {
                                continue;
                            }
                            Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["invoiceAmount"]), 0, "", false, false, true, false, true));
                            decimal num1 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row1["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                            if (this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("credit card") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                            {
                                if (this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("braintree") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("paypal") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("stripe") || this.objBc.SpecialDecode(row1["PaymentType"].ToString().ToLower().Trim()).Contains("api payment"))
                                {
                                    this.hdnIsPaid.Value = "1";
                                }
                                else if (num1 <= new decimal(0))
                                {
                                    this.hdnIsPaid.Value = "0";
                                }
                                else
                                {
                                    this.hdnIsPaid.Value = "1";
                                }
                                this.imgBtn_PaymentDetails.Style.Add("display", "block");
                            }
                            this.lblOrderedBy.Text = this.objBc.SpecialDecode(row1["OrderedBy"].ToString());
                            this.lblEstimateNo.Text = this.objBc.SpecialDecode(row1["SystemOrderNumber"].ToString());
                            this.lblPaymentType.Text = this.objBc.SpecialDecode(row1["PaymentType"].ToString());
                            this.lblComments.Text = this.objBc.SpecialDecode(row1["eStoreComments"].ToString());

                           
                        }

                    }
                }
                else
                {
                    DataSet dataSet = InvoiceBasePage.Invoice_SummaryDetails_Select(this.CompanyID, (long)this.InvoiceID);
                    foreach (DataRow dataRow1 in dataSet.Tables[0].Rows)
                    {
                        this.lblCustomerName.Text = this.objBc.SpecialDecode(dataRow1["ClientName"].ToString());
                        this.hdn_Summurypage_ClientID.Value = dataRow1["ClientID"].ToString();
                        this.lblAttention.Text = this.objBc.SpecialDecode(dataRow1["ContactName"].ToString());
                        this.hdn_Summurypage_ContactID.Value = dataRow1["ContactID"].ToString();
                        this.lblCompanyEmail.Text = this.objBc.SpecialDecode(dataRow1["BusinessEmail"].ToString());
                        this.lblContactPhone.Text = this.objBc.SpecialDecode(dataRow1["HomeTelephone"].ToString());
                        this.lblContactMobile.Text = this.objBc.SpecialDecode(dataRow1["ContactMobile"].ToString());
                        this.lblContactEmail.Text = baseClass.SpecialDecode(dataRow1["Email"].ToString());
                        this.lblInvoiceAddress.Text = this.objBc.SpecialDecode(dataRow1["InvoiceAddress"].ToString());
                        this.EstStatus = this.objBc.SpecialDecode(dataRow1["StatusTitle"].ToString());
                        this.lblAccountNo.Text = this.objBc.SpecialDecode(dataRow1["AccountNo"].ToString());
                        this.lblAccStatus.Text = this.objBc.SpecialDecode(dataRow1["CustomerStatusTitle"].ToString());
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                        Item_Summary_CustomerDetails.SalesPersonID = dataRow1["SalesPerson"].ToString();
                        this.lblEstimateTitle.Text = this.objBc.SpecialDecode(dataRow1["EstimateTitle"].ToString());
                        this.lblEstimator.Text = this.objBc.SpecialDecode(dataRow1["Estimator"].ToString());
                        this.lblSalePerson.Text = this.objBc.SpecialDecode(dataRow1["SalesPersonName"].ToString());
                        this.lblCompany.Text = this.objBc.SpecialDecode(dataRow1["DepartmentName"].ToString());
                        this.lblAddress.Text = this.objBc.SpecialDecode(dataRow1["Address"].ToString());
                        this.lblDeliveryAddress.Text = this.objBc.SpecialDecode(dataRow1["DeliveryAddress"].ToString());
                        this.lblOrderNo.Text = this.objBc.SpecialDecode(dataRow1["OrderNumber"].ToString());
                        this.lblcostcentre.Text = this.objBc.SpecialDecode(dataRow1["CostCentreName"].ToString());
                        this.lblGreeting.Text = this.objBc.SpecialDecode(dataRow1["Greeting"].ToString());
                        this.lblHeader.Text = this.objBc.SpecialDecode(dataRow1["InvoiceHeader"].ToString());
                        this.lblFooter.Text = this.objBc.SpecialDecode(dataRow1["InvoiceFooter"].ToString());
                        this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblInvoiceDueDate.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["Invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                        this.lblEstimateNo.Text = this.objBc.SpecialDecode(dataRow1["InvoiceNumber"].ToString());
                        this.lblIspaid.Text = dataRow1["IsPaid"].ToString();
                        this.hdnPaidValue.Value = dataRow1["IsPaid"].ToString();
                        this.lblComments.Text = dataRow1["Comments"].ToString();
                        decimal num2 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["invoiceAmount"]), 0, "", false, false, true, false, true));
                        decimal num3 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(dataRow1["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                        string str = string.Empty;
                        str = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
                        if (str == "0" || str == "2")
                        {
                            this.Hyperlink_PaymentDetails.Visible = false;
                            this.ChengePaymentMode.Visible = false;
                        }
                        else
                        {
                            this.ChengePaymentMode.Visible = true;
                        }
                        if ((num2 == num3 || num3 > num2) && this.lblIspaid.Text == "1")
                        {
                            this.hdnIsPaid.Value = "1";
                            this.lblIspaid.Text = "Paid in Full";
                            this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                        }
                        else if (num2 > num3 && this.lblIspaid.Text == "1")
                        {
                            this.hdnIsPaid.Value = "1";
                            this.lblIspaid.Text = "Partially Paid";
                            this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                        }
                        else if (num3 == new decimal(0) && this.lblIspaid.Text == "0")
                        {
                            this.hdnIsPaid.Value = "0";
                            this.lblIspaid.Text = "No";
                            this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                        }
                        if (!string.IsNullOrEmpty(dataRow1["CustomDate1"].ToString()))
                        {
                            this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate1.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow1["CustomDate2"].ToString()))
                        {
                            this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate2.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow1["CustomDate3"].ToString()))
                        {
                            this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate3.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow1["CustomDate4"].ToString()))
                        {
                            this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate4.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dataRow1["CustomDate5"].ToString()))
                        {
                            this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(dataRow1["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);
                        }
                        else
                        {
                            this.lblCustomDate5.Text = "";
                        }
                        if (!(Item_Summary_CustomerDetails.Module.ToLower() == "order") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                        {
                            continue;
                        }
                        this.lblOrderedBy.Text = this.objBc.SpecialDecode(dataRow1["OrderedBy"].ToString());
                        this.lblPaymentType.Text = this.objBc.SpecialDecode(dataRow1["PaymentType"].ToString());
                       
                    }
                    if (this.IsFrom.ToLower() == "yes")
                    {
                        this.ChengePaymentMode.Visible = false;
                    }
                }
                if (this.lblEstimateTitle.Text != "" && this.lblEstimateTitle.Text.Length > 50)
                {
                    this.lblEstimateTitle.Text = BaseClass.WrapString(this.lblEstimateTitle.Text, 50);
                }
            }
            else if (this.InvoiceID != 0)
            {
                DataSet dataSet1 = InvoiceBasePage.Invoice_SummaryDetails_Select(this.CompanyID, (long)this.InvoiceID);
                foreach (DataRow row2 in dataSet1.Tables[0].Rows)
                {
                    this.lblCustomerName.Text = this.objBc.SpecialDecode(row2["ClientName"].ToString());
                    this.hdn_Summurypage_ClientID.Value = row2["ClientID"].ToString();
                    this.lblAttention.Text = this.objBc.SpecialDecode(row2["ContactName"].ToString());
                    this.hdn_Summurypage_ContactID.Value = row2["ContactID"].ToString();
                    this.lblCompanyEmail.Text = this.objBc.SpecialDecode(row2["BusinessEmail"].ToString());
                    this.lblContactPhone.Text = this.objBc.SpecialDecode(row2["HomeTelephone"].ToString());
                    this.lblContactMobile.Text = this.objBc.SpecialDecode(row2["ContactMobile"].ToString());
                    this.lblContactEmail.Text = baseClass.SpecialDecode(row2["Email"].ToString());
                    this.lblInvoiceAddress.Text = this.objBc.SpecialDecode(row2["InvoiceAddress"].ToString());
                    this.EstStatus = this.objBc.SpecialDecode(row2["StatusTitle"].ToString());
                    this.lblAccountNo.Text = this.objBc.SpecialDecode(row2["AccountNo"].ToString());
                    this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row2["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                    Item_Summary_CustomerDetails.SalesPersonID = row2["SalesPerson"].ToString();
                    this.lblEstimator.Text = this.objBc.SpecialDecode(row2["Estimator"].ToString());
                    this.lblEstimateTitle.Text = this.objBc.SpecialDecode(row2["EstimateTitle"].ToString());
                    this.lblCompany.Text = this.objBc.SpecialDecode(row2["DepartmentName"].ToString());
                    this.lblSalePerson.Text = this.objBc.SpecialDecode(row2["SalesPersonName"].ToString());
                    this.lblAddress.Text = this.objBc.SpecialDecode(row2["Address"].ToString());
                    this.lblDeliveryAddress.Text = this.objBc.SpecialDecode(row2["DeliveryAddress"].ToString());

                    this.lblDeliveryAddressLabel.Text = this.objBc.SpecialDecode(row2["DeliveryAddressLabel"].ToString());

                    this.lblOrderNo.Text = this.objBc.SpecialDecode(row2["OrderNumber"].ToString());
                    this.lblcostcentre.Text = this.objBc.SpecialDecode(row2["CostCentreName"].ToString());
                    this.lblGreeting.Text = this.objBc.SpecialDecode(row2["Greeting"].ToString());
                    this.lblHeader.Text = this.objBc.SpecialDecode(row2["InvoiceHeader"].ToString());
                    this.lblFooter.Text = this.objBc.SpecialDecode(row2["InvoiceFooter"].ToString());
                    this.lblestimateddelivery.Text = this.commclass.Eprint_return_Date_Before_View(row2["EstimatedDelivery"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblEstimateDate.Text = this.commclass.Eprint_return_Date_Before_View(row2["CreatedDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblInvoiceDueDate.Text = this.commclass.Eprint_return_Date_Before_View(row2["Invoice_DueDate"].ToString(), this.CompanyID, this.UserID, false);
                    this.lblEstimateNo.Text = this.objBc.SpecialDecode(row2["InvoiceNumber"].ToString());
                    this.lblAccStatus.Text = this.objBc.SpecialDecode(row2["CustomerStatusTitle"].ToString());
                    this.lblIspaid.Text = row2["IsPaid"].ToString();
                    this.hdnPaidValue.Value = row2["IsPaid"].ToString();
                    this.lblComments.Text = row2["Comments"].ToString();
                    decimal num4 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["invoiceAmount"]), 0, "", false, false, true, false, true));
                    decimal num5 = Convert.ToDecimal(this.commclass.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(row2["TotalAmountPaid"]), 0, "", false, false, true, false, true));
                    string empty1 = string.Empty;
                    empty1 = baseClass.ReturnRoles_Privileges_ForGrid("invoices", "others", this.Page.Request.Url.ToString());
                    if (empty1 == "0" || empty1 == "2")
                    {
                        this.Hyperlink_PaymentDetails.Visible = false;
                        this.ChengePaymentMode.Visible = false;
                    }
                    else
                    {
                        this.ChengePaymentMode.Visible = true;
                    }
                    if ((num4 == num5 || num5 > num4) && this.lblIspaid.Text == "1")
                    {
                        this.lblIspaid.Text = "Paid in Full";
                        this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                    }
                    else if (num4 > num5 && this.lblIspaid.Text == "1")
                    {
                        this.lblIspaid.Text = "Partially Paid";
                        this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                    }
                    else if (num5 == new decimal(0) && this.lblIspaid.Text == "0")
                    {
                        this.lblIspaid.Text = "No";
                        this.ChengePaymentMode.ToolTip = Item_Summary_CustomerDetails.objLanguage.GetLanguageConversion("Record_or_View_Payment");
                    }
                    if (!string.IsNullOrEmpty(row2["CustomDate1"].ToString()))
                    {
                        this.lblCustomDate1.Text = this.commclass.Eprint_return_Date_Before_View(row2["CustomDate1"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.lblCustomDate1.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row2["CustomDate2"].ToString()))
                    {
                        this.lblCustomDate2.Text = this.commclass.Eprint_return_Date_Before_View(row2["CustomDate2"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.lblCustomDate2.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row2["CustomDate3"].ToString()))
                    {
                        this.lblCustomDate3.Text = this.commclass.Eprint_return_Date_Before_View(row2["CustomDate3"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.lblCustomDate3.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row2["CustomDate4"].ToString()))
                    {
                        this.lblCustomDate4.Text = this.commclass.Eprint_return_Date_Before_View(row2["CustomDate4"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.lblCustomDate4.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row2["CustomDate5"].ToString()))
                    {
                        this.lblCustomDate5.Text = this.commclass.Eprint_return_Date_Before_View(row2["CustomDate5"].ToString(), this.CompanyID, this.UserID, false);
                    }
                    else
                    {
                        this.lblCustomDate5.Text = "";
                    }
                    if (!(Item_Summary_CustomerDetails.Module.ToLower() == "order") && !base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
                    {
                        continue;
                    }
                    this.lblOrderedBy.Text = this.objBc.SpecialDecode(row2["OrderedBy"].ToString());
                    this.lblPaymentType.Text = this.objBc.SpecialDecode(row2["PaymentType"].ToString());
                   
                }
                if (Item_Summary_CustomerDetails.Module.ToLower() == "invoice" && this.IsFrom.ToLower() == "yes")
                {
                    this.ChengePaymentMode.Visible = false;
                }
            }
            foreach (DataRow dataRow2 in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                SpanCustomDate1.InnerText =string.IsNullOrEmpty(dataRow2["DefaultCustomDateTitle1"].ToString())?"Custom Date 1": dataRow2["DefaultCustomDateTitle1"].ToString();
                SpanCustomDate2.InnerText = string.IsNullOrEmpty(dataRow2["DefaultCustomDateTitle2"].ToString()) ? "Custom Date 2" : dataRow2["DefaultCustomDateTitle2"].ToString();
                SpanCustomDate3.InnerText = string.IsNullOrEmpty(dataRow2["DefaultCustomDateTitle3"].ToString()) ? "Custom Date 3" : dataRow2["DefaultCustomDateTitle3"].ToString();
                SpanCustomDate4.InnerText = string.IsNullOrEmpty(dataRow2["DefaultCustomDateTitle4"].ToString()) ? "Custom Date 4" : dataRow2["DefaultCustomDateTitle4"].ToString();
                SpanCustomDate5.InnerText = string.IsNullOrEmpty(dataRow2["DefaultCustomDateTitle5"].ToString()) ? "Custom Date 5" : dataRow2["DefaultCustomDateTitle5"].ToString();


                if (!Convert.ToBoolean(dataRow2["IsDefaultArtwork"]))
                {
                    this.Div_EstArtwork.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.Div_EstArtwork.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow2["IsDefaultProof"]))
                {
                    this.Div_Estproof.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.Div_Estproof.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow2["IsDefaultApproval"]))
                {
                    this.div_ApprovalNew.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_ApprovalNew.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow2["IsDefaultProduction"]))
                {
                    this.divProductionDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divProductionDate.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow2["IsDefaultCompletion"]))
                {
                    this.divJobCompletionDate.Attributes.Add("style", "display:none");
                    this.div_JobCompletionDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.divJobCompletionDate.Attributes.Add("style", "display:block");
                    this.div_JobCompletionDate.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(dataRow2["IsDefaultDelivery"]))
                {
                    this.div_deliverydate.Attributes.Add("style", "display:none");
                    this.div_JobDeliveryDate.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.div_deliverydate.Attributes.Add("style", "display:block");
                    this.div_JobDeliveryDate.Attributes.Add("style", "display:block");
                }

                if (!Convert.ToBoolean(dataRow2["IsDefaultCustomDate1"]))
                {
                  
                    this.div_CustomDate1.Attributes.Add("style", "display:none");
                }
                else
                {
                    if (!this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
               
                        this.div_CustomDate1.Attributes.Add("style", "display:block");
                    }
                }

                if (!Convert.ToBoolean(dataRow2["IsDefaultCustomDate2"]))
                {
                   
                    this.div_CustomDate2.Attributes.Add("style", "display:none");
                }
                else
                {
                    if (!this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
                     
                        this.div_CustomDate2.Attributes.Add("style", "display:block");
                    }
                }

                if (!Convert.ToBoolean(dataRow2["IsDefaultCustomDate3"]))
                {
               
                    this.div_CustomDate3.Attributes.Add("style", "display:none");
                }
                else
                {
                    if (!this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
                    
                        this.div_CustomDate3.Attributes.Add("style", "display:block");
                    }
                }

                if (!Convert.ToBoolean(dataRow2["IsDefaultCustomDate4"]))
                {
                
                    this.div_CustomDate4.Attributes.Add("style", "display:none");
                }
                else
                {
                    if (!this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
                       
                        this.div_CustomDate4.Attributes.Add("style", "display:block");
                    }
                }

                if (!Convert.ToBoolean(dataRow2["IsDefaultCustomDate5"]))
                {
                  
                    this.div_CustomDate5.Attributes.Add("style", "display:none");
                }
                else
                {
                    if (!this.Page.Request.Url.ToString().ToLower().Contains("proofs/proof_summary.aspx"))
                    {
                       
                        this.div_CustomDate5.Attributes.Add("style", "display:block");
                    }
                }
            }
            foreach (DataRow row in SettingsBasePage.Select_JobDefault_Settings(this.CompanyID).Rows)
            {
                if (!Convert.ToBoolean(row["IsDefaultJobArtwork"]))
                {
                    this.DivArtwork.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.DivArtwork.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row["IsDefaultJobProof"]))
                {
                    this.DivProof.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.DivProof.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row["IsDefaultJobApproval"]))
                {
                    this.DivApproval.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.DivApproval.Attributes.Add("style", "display:block");
                }
                if (!Convert.ToBoolean(row["IsDefaultJobProduction"]))
                {
                    this.DivProduction.Attributes.Add("style", "display:none");
                }
                else
                {
                    this.DivProduction.Attributes.Add("style", "display:block");
                }
            }
            if (base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary"))
            {
                Item_Summary_CustomerDetails.Module = "joborder";
            }
            if (base.Request.Url.ToString().ToLower().Contains("invoice/invoice_order_summary"))
            {
                Item_Summary_CustomerDetails.Module = "invoiceorder";
            }
            if (Item_Summary_CustomerDetails.Module.ToLower() == "order" || base.Request.Url.ToString().ToLower().Contains("jobs/job_order_summary") || base.Request.Url.ToString().ToLower().Contains("invoice/invoice"))
            {
                this.Div_EstArtwork.Attributes.Add("style", "display:none");
                this.Div_Estproof.Attributes.Add("style", "display:none");
                this.div_ApprovalNew.Attributes.Add("style", "display:none");
                this.divProductionDate.Attributes.Add("style", "display:none");
                this.divJobCompletionDate.Attributes.Add("style", "display:none");
                this.div_JobCompletionDate.Attributes.Add("style", "display:none");
            }
            if (this.lblAccStatus.Text.Trim().ToLower() == "account on hold")
            {
                this.lblAccStatus.Style.Add("color", "red");
            }
        }
    }
}