using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Invoices;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using System.Linq;
using System.IO;

namespace ePrint.invoice
{
    public partial class invoice_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected HiddenField hdnaddress1;

        //protected HiddenField hdnaddress2;

        //protected HiddenField hdnaddress3;

        //protected HiddenField hdnaddress4;

        //protected HiddenField hdnaddress5;

        //protected UpdateProgress upProgress;

        //protected ImageButton ImageButton1;

        //protected RadioButton rdb_Delete_Invoice;

        //protected RadioButton rdb_Delete_All;

        //protected Label lbl_note;

        //protected Button btn_Delete_Invoice;

        //protected Button btn_Delete_Cancel;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkInvoiceedit;

        //protected LinkButton btnclrFilters;

        //protected Label lblView;

        //protected HiddenField hdnAlphabet;

        //protected RadListBox RadListBox1;

        //protected Panel pnlChangeStatus;

        //protected Label lblArchive;

        //protected HtmlGenericControl divarchive;

        //protected Label lblUnArchive;

        //protected HtmlGenericControl divunarchive;

        //protected Label lblDelete;

        //protected HtmlGenericControl divDeleteSelected;

        //protected Label lblRecordPayment;

        //protected HtmlGenericControl divPaid;

        //protected RadGrid GridViewInvoice;

        //protected HtmlGenericControl div_Main;

        //protected LinkButton lnkInvoiceDelete;

        //protected LinkButton lnkInvoiceArchive;

        //protected LinkButton lnkInvoiceUnArchive;

        //protected LinkButton lnkInvoiceCopy;

        //protected HiddenField hdnEstimateID;

        //protected HiddenField hdnInvoiceID;

        //protected HiddenField hdnInvoiceEstimateIds;

        //protected HiddenField hdnSelectedChkfrmGrid;

        //protected UpdatePanel updtehidnfield;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager1;

        //protected HiddenField editInvoiceViewID;

        //protected HiddenField hdnIDs;

        //protected HiddenField hdn_ISInventoryStockBack;

        //protected HiddenField hdn_stockBackwarehoue;

        //protected HiddenField hdnInvoiceDelete;

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass objJava = new commonClass();

        private EstimateBasePage ObjEst = new EstimateBasePage();

        private commonClass comm = new commonClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        private Notes objN = new Notes();

        private notesclass objnotes = new notesclass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath;

        private Global gloobj = new Global();

        public int totalrec;

        private string para = string.Empty;

        public string newdate = string.Empty;

        public int CompanyID;

        public int defaultviewid;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string pg;

        public DataTable dt = new DataTable();

        private createViewClass objCreateView = new createViewClass();

        public string cellvalue_createddate = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_ispaid = string.Empty;

        public string flag_ispaid = string.Empty;

        public string cellvalue_Invval = string.Empty;

        public string cellvalue_InvoiceAmountPaid = string.Empty;

        public string cellvalue_InvoiceOutstanding = string.Empty;

        public string flag_Invval = string.Empty;

        public string cellvalue_InvvalExcGst = string.Empty;

        public string flag_InvvalExcGst = string.Empty;

        public string cellvalue_Quantity = string.Empty;

        public string flag_Quantity = string.Empty;

        public string flag_InvoiceAmountPaid = string.Empty;

        public string flag_InvoiceOutstanding = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_invoicetitle = string.Empty;

        public string flag_invoicetitle = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_status = string.Empty;

        public string cellvalue_invoicestatus = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string flag_invoicestatus = string.Empty;

        public string cellvalue_customerordernumber = string.Empty;

        public string flag_customerordernumber = string.Empty;

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_contactname = string.Empty;

        public string flag_contactname = string.Empty;

        public string cellvalue_salesperson = string.Empty;

        public string flag_salesperson = string.Empty;

        public string cellvalue_costcentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_invoiceno = string.Empty;

        public string flag_invoiceno = string.Empty;

        public string cellvalue_InvoiceType = string.Empty;

        public string flag_InvoiceType = string.Empty;

        public string cellvalue_Department = string.Empty;

        public string flag_Department = string.Empty;

        public string cellvalue_EstimateNumber = string.Empty;

        public string flag_EstimateNumber = string.Empty;

        public string cellvalue_JobNumber = string.Empty;

        public string flag_JobNumber = string.Empty;

        public string cellvalue_InvoiceDueDate = string.Empty;

        public string flag_InvoiceDueDate = string.Empty;

        public string cellvalue_paymentdate = string.Empty;

        public string flag_paymentdate = string.Empty;

        public string cellvalue_PaymentNotes = string.Empty;

        public string flag_PaymentNotes = string.Empty;

        public string flag_CustomerType = string.Empty;

        public string cellvalue_CustomerType = string.Empty;

        public string flag_Address1 = string.Empty;

        public string cellvalue_Address1 = string.Empty;

        public string flag_Address2 = string.Empty;

        public string cellvalue_Address2 = string.Empty;

        public string flag_Address3 = string.Empty;

        public string cellvalue_Address3 = string.Empty;

        public string flag_Address4 = string.Empty;

        public string cellvalue_Address4 = string.Empty;

        public string flag_Address5 = string.Empty;

        public string cellvalue_Address5 = string.Empty;

        public string flag_ItemStatus = string.Empty;

        public string cellvalue_ItemStatus = string.Empty;

        public string flag_ItemTitle = string.Empty;

        public string cellvalue_ItemTitle = string.Empty;

        public string flag_ItemAccCode = string.Empty;

        public string cellvalue_ItemAccCode = string.Empty;

        public string flag_ItemQTY = string.Empty;

        public string cellvalue_ItemQTY = string.Empty;

        public string flag_ItemValue_ExcTax = string.Empty;

        public string cellvalue_ItemValue_ExcTax = string.Empty;

        public string flag_ItemValue_IncTax = string.Empty;

        public string cellvalue_ItemValue_IncTax = string.Empty;

        public string flag_ItemTaxValue = string.Empty;

        public string cellvalue_ItemTaxValue = string.Empty;

        public string flag_ItemCostPriceExcMarkup = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup = string.Empty;

        public string flag_ItemMarkupValue = string.Empty;

        public string cellvalue_ItemMarkupValue = string.Empty;

        public string flag_ItemCostPriceIncMarkup = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup = string.Empty;

        public string flag_ItemProfitMarginPercentage = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage = string.Empty;

        public string flag_ItemProfitMarginValue = string.Empty;

        public string cellvalue_ItemProfitMarginValue = string.Empty;

        public string flag_ItemGrossProfitPercentage = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage = string.Empty;

        public string flag_ItemGrossProfitValue = string.Empty;

        public string cellvalue_ItemGrossProfitValue = string.Empty;

        public string flag_EventName = string.Empty;

        public string cellvalue_EventName = string.Empty;

        public string flag_EventCodeNumber = string.Empty;

        public string cellvalue_EventCodeNumber = string.Empty;

        public string flag_CampaignSignNumber = string.Empty;

        public string cellvalue_CampaignSignNumber = string.Empty;

        public string flag_ItemMaterial = string.Empty;

        public string cellvalue_ItemMaterial = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;
        public string flag_EventVenue = string.Empty;

        public string cellValue_EventVenue = string.Empty;

        public string flag_Height = string.Empty;

        public string cellvalue_Height = string.Empty;

        public string flag_Width = string.Empty;

        public string cellvalue_Width = string.Empty;

        public string flag_ItemDescription = string.Empty;

        public string cellvalue_ItemDescription = string.Empty;

        public string cellvalue_comments = string.Empty;

        public string flag_comments = string.Empty;

        public string flag_ItemColour = string.Empty;

        public string cellvalue_ItemColour = string.Empty;

        public string flag_ItemSize = string.Empty;

        public string cellvalue_ItemSize = string.Empty;

        public string flag_ItemArtwork = string.Empty; 

        public string cellvalue_ItemArtwork = string.Empty;

        public string flag_ItemDelivery = string.Empty; 

        public string cellvalue_ItemDelivery = string.Empty;

        public string cellvalue_deliverydate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string flag_ItemFinishing = string.Empty;

        public string cellvalue_ItemFinishing = string.Empty;

        public string flag_ItemProofs = string.Empty;

        public string cellvalue_ItemProofs = string.Empty;

        public string flag_ItemPacking = string.Empty;

        public string cellvalue_ItemPacking = string.Empty;

        public string flag_ItemNotes = string.Empty;

        public string cellvalue_ItemNotes = string.Empty;

        public string flag_ItemTermsInstructions = string.Empty;

        public string cellvalue_ItemTermsInstructions = string.Empty;

        public string flag_JobName = string.Empty;

        public string cellvalue_JobName = string.Empty;

        public string flag_JobStatus = string.Empty;

        public string cellvalue_JobStatus = string.Empty;

        public string flag_PONumber = string.Empty;

        public string cellvalue_PONumber = string.Empty;

        public string flag_FTPStatus = string.Empty;

        public string cellvalue_FTPStatus = string.Empty;

        public int UserID;

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public static int PageSize;

        private DataTable dtArtwork = new DataTable();

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        private SummaryClass SummaryClassObj = new SummaryClass();

        public string Archive_Row_Selection_Alert = string.Empty;

        public string Delete_Row_Selection_Alert = string.Empty;

        public string UnArchive_Row_Selection_Alert = string.Empty;

        public string Invoice_Paid_Row_Select_Note = string.Empty;
        public string Export_Row_Select_Note = string.Empty;
        public string Unexport_Row_Select_Note = string.Empty;

        public bool IsItemSelected;

        public string RecordsToDisplay = "";

        private long ModuleID;

        private string Invoice_Number = string.Empty;

        private string InvoiceItem_Number = string.Empty;
        //public bool IsGrouping;

        //public string GroupByColumn = string.Empty;
        public string FilterDateType = string.Empty;
        public string FilterDateRange = string.Empty;

        public string cellvalue_priority = string.Empty;

        public string flag_priority = string.Empty;

        public string flag_DefaultTemplate = string.Empty;

        public string cellvalue_DefaultTemplate = string.Empty;

        public string flag_ChooseTemplate = string.Empty;

        public string cellvalue_ChooseTemplate = string.Empty;

        public string flag_DownloadTemplate = string.Empty;

        public string cellvalue_DownloadTemplate = string.Empty;

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();
        public string flag_Archive = string.Empty;

        public string cellvalue_Archive = string.Empty;

        public string flag_CustomDate1 = string.Empty;

        public string cellvalue_CustomDate1 = string.Empty;

        public string flag_CustomDate2 = string.Empty;

        public string cellvalue_CustomDate2 = string.Empty;

        public string flag_CustomDate3 = string.Empty;

        public string cellvalue_CustomDate3 = string.Empty;

        public string flag_CustomDate4 = string.Empty;

        public string cellvalue_CustomDate4 = string.Empty;

        public string flag_CustomDate5 = string.Empty;

        public string cellvalue_CustomDate5 = string.Empty;
        public string customDatetitle1 = string.Empty;
        public string customDatetitle2 = string.Empty;
        public string customDatetitle3 = string.Empty;
        public string customDatetitle4 = string.Empty;
        public string customDatetitle5 = string.Empty;


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

        static invoice_view()
        {
            invoice_view.WhereCondition = string.Empty;
            invoice_view.sortdirection = string.Empty;
            invoice_view.SortedBy = string.Empty;
            invoice_view.PageSize = 50;
            invoice_view.ManageStockPermission = 0;
        }

        public invoice_view()
        {
        }

        public class ImageTemplate : ITemplate
        {
            private string _imageUrl;

            public ImageTemplate(string imageUrl)
            {
                _imageUrl = imageUrl;
            }

            public void InstantiateIn(Control container)
            {
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                {
                    ImageUrl = _imageUrl,
                    AlternateText = "",
                    Width = Unit.Pixel(16),
                    Height = Unit.Pixel(16)
                };
                container.Controls.Add(img);
            }
        }
        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.GridViewInvoice.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    else if (dt.Columns[i].ColumnName.ToLower() == "invoicevalue" || dt.Columns[i].ColumnName.ToLower() == "estimatevalue_excgst" || dt.Columns[i].ColumnName.ToLower() == "invoiceamountpaid" || dt.Columns[i].ColumnName.ToLower() == "invoiceoutstanding")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Decimal");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    //if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    //{
                    //  this.GridViewInvoice.MasterTableView.Columns.Remove(gridBoundColumn);

                    // GridTemplateColumn commentColumn = new GridTemplateColumn();
                    // commentColumn.UniqueName = dt.Columns[i].ColumnName;
                    // commentColumn.HeaderText = "Comments";
                    // commentColumn.ItemTemplate = new CommentsTemplate();
                    // gv.MasterTableView.Columns.Add(commentColumn);
                    //}
                    if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address1")
                    {
                        this.GridViewInvoice.Columns[i].HeaderText = this.hdnaddress1.Value;
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address2")
                    {
                        this.GridViewInvoice.Columns[i].HeaderText = this.hdnaddress2.Value;
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address3")
                    {
                        this.GridViewInvoice.Columns[i].HeaderText = this.hdnaddress3.Value;
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address4")
                    {
                        this.GridViewInvoice.Columns[i].HeaderText = this.hdnaddress4.Value;
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address5")
                    {
                        this.GridViewInvoice.Columns[i].HeaderText = this.hdnaddress5.Value;
                    }
                }
                for (int j = 1; j < this.GridViewInvoice.Columns.Count; j++)
                {
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewInvoice.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoicenumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_No");
                        this.GridViewInvoice.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_invoiceno = "true";
                        this.cellvalue_invoiceno = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.GridViewInvoice.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridViewInvoice.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.GridViewInvoice.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "priority")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Priority";
                        this.GridViewInvoice.Columns[j].HeaderStyle.Width = Unit.Pixel(100);
                        this.GridViewInvoice.Columns[j].ItemStyle.Width = Unit.Pixel(100);
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridViewInvoice.Columns[j].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_priority = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_priority = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Person");
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inv_Title");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_invoicetitle = "true";
                        this.cellvalue_invoicetitle = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoicestatus")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inv_Status");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_invoicestatus = "true";
                        this.cellvalue_invoicestatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "ispaid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Paid");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ispaid = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_ispaid = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Date");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customdate1")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate1 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate1 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customdate2")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate2 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate2 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customdate3")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate3 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate3 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customdate4")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate4 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate4 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customdate5")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate5 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate5 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoicevalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Inv_Value"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_Invval = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_Invval = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoiceamountpaid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Amount_Paid"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_InvoiceAmountPaid = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_InvoiceAmountPaid = "true";
                    }

                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Default Template";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Choose Template";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ChooseTemplate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }

                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Download Default Template";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DownloadTemplate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Archive";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }


                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoiceoutstanding")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Amount_Outstanding"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_InvoiceOutstanding = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_InvoiceOutstanding = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "quantity")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Quantity");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_Quantity = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_Quantity = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "isfromwebstore")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "orderid")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Inv_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_InvvalExcGst = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_InvvalExcGst = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_type");
                        this.flag_InvoiceType = "true";
                        this.cellvalue_InvoiceType = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number_Order_Number");
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "job number")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Number");
                        this.flag_JobNumber = "true";
                        this.cellvalue_JobNumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoiceduedate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Due_Date");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.flag_InvoiceDueDate = "true";
                        this.cellvalue_InvoiceDueDate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_deliverydate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "paymentdate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Payment Date";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.flag_paymentdate = "true";
                        this.cellvalue_paymentdate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "paymentnotes")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Notes");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.flag_PaymentNotes = "true";
                        this.cellvalue_PaymentNotes = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.flag_CustomerType = "true";
                        this.cellvalue_CustomerType = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Status Days";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceStatusUpdate = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_SinceStatusUpdate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "Email Days";
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceEmailed = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_SinceEmailed = "true";
                    }

                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "address1")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address1 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Address1 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "address2")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address2 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Address2 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "address3")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address3 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Address3 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "address4")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address4 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Address4 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "address5")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address5 = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Address5 = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Comments");
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "eventname")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Name");
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Code_Number");
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Sign_Number");
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                        this.flag_ItemMaterial = "true";
                        this.cellvalue_ItemMaterial = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "eventvenue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Venue");
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.GridViewInvoice.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_View");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "jobname")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "jobstatus")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Status");
                        this.flag_JobStatus = "true";
                        this.cellvalue_JobStatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "po number")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = "PO Number";
                        this.flag_PONumber = "true";
                        this.cellvalue_PONumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "department")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Department = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.flag_Department = "true";
                    }
                }
            }

            for (int j = 0; j < this.GridViewInvoice.Columns.Count; j++)
            {


                if (this.GridViewInvoice.Columns[j].UniqueName.ToLower() == "defaulttemplate")
                {
                    this.GridViewInvoice.Columns[j].HeaderText = "Default Template";
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DefaultTemplate = this.GridViewInvoice.Columns[j].UniqueName.ToLower();
                    this.flag_DefaultTemplate = "true";
                }

                else if (this.GridViewInvoice.Columns[j].UniqueName.ToLower() == "choosetemplate")
                {
                    this.GridViewInvoice.Columns[j].HeaderText = "Choose Template";
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_ChooseTemplate = this.GridViewInvoice.Columns[j].UniqueName.ToLower();
                    this.flag_ChooseTemplate = "true";
                }

                else if (this.GridViewInvoice.Columns[j].UniqueName.ToLower() == "downloadtemplate")
                {
                    this.GridViewInvoice.Columns[j].HeaderText = "Download Default Template";
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DownloadTemplate = this.GridViewInvoice.Columns[j].UniqueName.ToLower();
                    this.flag_DownloadTemplate = "true";
                }
                else if (this.GridViewInvoice.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridViewInvoice.Columns[j].HeaderText = "Archive";
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    this.flag_Archive = "true";
                }
            }


            for (int i = 0; i < gv.MasterTableView.Columns.Count; i++)
                {
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "defaulttemplate")
                    {
                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "defaulttemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "previewpdf.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "choosetemplate")
                    {
                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "choosetemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "template-select.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "downloadtemplate")
                    {

                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "downloadtemplate";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "download-pdf.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
                    if (gv.MasterTableView.Columns[i].UniqueName.ToLower() == "archive")
                    {

                        GridTemplateColumn imgColumn = new GridTemplateColumn();
                        imgColumn.UniqueName = "archive";
                        imgColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

                        // Set the custom template for the header
                        imgColumn.HeaderTemplate = new ImageTemplate(string.Concat(this.strImagepath, "archive.png"));
                        imgColumn.AllowFiltering = false;
                        imgColumn.HeaderStyle.Width = Unit.Pixel(20); // Set a small width for the header
                        imgColumn.ItemStyle.Width = Unit.Pixel(20);   // Set the same width for content rows


                        gv.MasterTableView.Columns.RemoveAt(i); // Remove old column
                        gv.MasterTableView.Columns.Insert(i, imgColumn); // Insert the new column

                    }
            }
            
        }

        public class CommentsTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                HyperLink hlEditComment = new HyperLink();
                hlEditComment.DataBinding += (s, e) =>
                {
                    GridDataItem item = (GridDataItem)container.NamingContainer;
                    hlEditComment.Text = DataBinder.Eval(item.DataItem, "Comments").ToString();
                    string invoiceId = DataBinder.Eval(item.DataItem, "InvoiceID").ToString();
                    hlEditComment.Attributes["onclick"] = $"openCommentPopup('{invoiceId}', '{hlEditComment.Text}'); return false;";
                };
                container.Controls.Add(hlEditComment);
            }
        }
        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string newComment = hiddenCommentText.Value;
            int commentId = int.Parse(hiddenCommentId.Value);

            UpdateCommentInDatabase(commentId, newComment);

            GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, this.GridViewInvoice.CurrentPageIndex + 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, this.para);
            this.GridViewInvoice.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_view.aspx"));
        }

        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            InvoiceBasePage.Invoice_Comments_Update(commentId, newComment);
        }

        public void bindRadlistStatus()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "invoice");
            this.RadListBox1.DataSource = dataTable;
            this.RadListBox1.DataTextField = "StatusTitle";
            this.RadListBox1.DataValueField = "StatusID";
            this.RadListBox1.DataBind();
        }

        public void btnEditViewInvoice_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../invoice/customviewinvoice.aspx?type=edit&id=", this.editInvoiceViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("invoice_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("invoice_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            invoice_view.WhereCondition = "";
            this.Session["search_Inv"] = null;
            foreach (GridColumn column in this.GridViewInvoice.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridViewInvoice.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "invoice/invoice_view.aspx?viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num=0;
            string empty = string.Empty;
            string str = string.Empty;
            int num1 = 0;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                num1 = Convert.ToInt32(row["Roundoff"].ToString());
            }
            this.Session["search_Inv"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && invoice_view.WhereCondition != "")
                {
                    invoice_view.WhereCondition = string.Concat(invoice_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "invoiceduedate" || dataRow["ColumnName"].ToString().ToLower() == "paymentdate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "invoiceamountpaid" || dataRow["ColumnName"].ToString().ToLower() == "invoiceoutstanding")
                {
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                    object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                    empty = string.Concat(objArray);
                }
                else if (dataRow["ColumnName"].ToString().ToLower() != "ispaid")
                {
                    empty = dataRow["ColumnName"].ToString();
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                }
                else
                {
                    empty = dataRow["ColumnName"].ToString();
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                //             if (< PrivateImplementationDetails >{ E83FC58D - 0B15 - 49E2 - B17F - 1247C3CBE9AC}.$$method0x6000017 - 1 == null)
                //{

                //             < PrivateImplementationDetails >{ E83FC58D - 0B15 - 49E2 - B17F - 1247C3CBE9AC}.$$method0x6000017 - 1 = new Dictionary<string, int>(10)
                //             {
                //                 { "startswith", 0 },
                //                 { "endswith", 1 },
                //                 { "contains", 2 },
                //                 { "doesnotcontain", 3 },
                //                 { "equalto", 4 },
                //                 { "notequalto", 5 },
                //                 { "greaterthan", 6 },
                //                 { "greaterthanorequalto", 7 },
                //                 { "lessthan", 8 },
                //                 { "lessthanorequalto", 9 }
                //             };
                //             }
                //             if (!< PrivateImplementationDetails >{ E83FC58D - 0B15 - 49E2 - B17F - 1247C3CBE9AC}.$$method0x6000017 - 1.TryGetValue(str1, out num))
                //{
                //                 continue;
                //             }

                var dictionary = new Dictionary<string, int>(10)
                             {
                                 { "startswith", 0 },
                                 { "endswith", 1 },
                                 { "contains", 2 },
                                 { "doesnotcontain", 3 },
                                 { "equalto", 4 },
                                 { "notequalto", 5 },
                                 { "greaterthan", 6 },
                                 { "greaterthanorequalto", 7 },
                                 { "lessthan", 8 },
                                 { "lessthanorequalto", 9 }
                             };

                dictionary.TryGetValue(str1, out num);

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = invoice_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            invoice_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = invoice_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            invoice_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "invoiceduedate" || dataRow["ColumnName"].ToString().ToLower() == "paymentdate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = invoice_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string str2 = invoice_view.WhereCondition;
                                string[] strArrays3 = new string[] { str2, " ", empty, " like '%", str, "%'" };
                                invoice_view.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        }
                    case 3:
                        {
                            string whereCondition3 = invoice_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " not like '%", str, "%'" };
                            invoice_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity" || dataRow["ColumnName"].ToString().ToLower() == "invoiceamountpaid")
                            {
                                string str3 = invoice_view.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                            else if (dataRow["ColumnName"].ToString().ToLower() != "invoiceoutstanding")
                            {
                                string whereCondition4 = invoice_view.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " = '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                            else
                            {
                                string str4 = invoice_view.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " = ", str, " or ", empty, " = -", str };
                                invoice_view.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string whereCondition5 = invoice_view.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " != ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                            else
                            {
                                string str5 = invoice_view.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " != '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string whereCondition6 = invoice_view.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " > ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                            else
                            {
                                string str6 = invoice_view.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " > '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string whereCondition7 = invoice_view.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " >= ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                            else
                            {
                                string str7 = invoice_view.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " >= '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string whereCondition8 = invoice_view.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " < ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                            else
                            {
                                string str8 = invoice_view.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " < '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "invoicevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string whereCondition9 = invoice_view.WhereCondition;
                                string[] strArrays16 = new string[] { whereCondition9, " ", empty, " <= ", str };
                                invoice_view.WhereCondition = string.Concat(strArrays16);
                                continue;
                            }
                            else
                            {
                                string str9 = invoice_view.WhereCondition;
                                string[] strArrays17 = new string[] { str9, " ", empty, " <= '", str, "'" };
                                invoice_view.WhereCondition = string.Concat(strArrays17);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return invoice_view.WhereCondition;
        }

        [WebMethod]
        public static string GetItemCount(long invId)
        {
            invoice_view invoiceInvoiceView = new invoice_view();
            DataTable dataTable = EstimatesBasePage.estimate_item_select_reeng_ByInvoice(Convert.ToInt32(invoiceInvoiceView.Session["CompanyID"]), invId, "invoice");
            return dataTable.Rows.Count.ToString();
        }

        private string GetSortDirection(string column)
        {
            string str = "ASC";
            string item = this.ViewState["SortExpression"] as string;
            if (item != null && item == column)
            {
                string item1 = this.ViewState["SortDirection"] as string;
                if (item1 != null && item1 == "ASC")
                {
                    str = "DESC";
                }
            }
            this.ViewState["SortDirection"] = str;
            this.ViewState["SortExpression"] = column;
            return str;
        }

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();

            para = (para.Contains("Job Number") && !para.Contains("[Job Number]")) ? para.Replace("Job Number", "[Job Number]") : para;
            para = (para.Contains("PO Number") && !para.Contains("[PO Number]")) ? para.Replace("PO Number", "[PO Number]") : para;
            para = (para.Contains("Consignment Number") && !para.Contains("[Consignment Number]")) ? para.Replace("Consignment Number", "[Consignment Number]") : para;
            para = (para.Contains("Carrier Information") && !para.Contains("[Carrier Information]")) ? para.Replace("Carrier Information", "[Carrier Information]") : para;
            para = (para.Contains("Consignee Url") && !para.Contains("[Consignee Url]")) ? para.Replace("Consignee Url", "[Consignee Url]") : para;

            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
                CommandTimeout = 0,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            sqlCommand.Parameters.AddWithValue("@strSQL", empty);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable item = dataSet.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }

            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("deliverydate"))
                    {
                        row["deliverydate"] = _commonClass.Eprint_return_Date_Before_View(row["deliverydate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate1"))
                    {
                        row["CustomDate1"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate2"))
                    {
                        row["CustomDate2"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate3"))
                    {
                        row["CustomDate3"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate4"))
                    {
                        row["CustomDate4"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate5"))
                    {
                        row["CustomDate5"] = this.objJava.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), CompanyID, UserID, false);
                    }

                }
            }




            _commonClass.closeConnection();
            this.GridViewInvoice.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewInvoice);
                this.div_Main.Style.Add("display", "block");
                this.GridViewInvoice.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridViewInvoice);
                this.div_Main.Style.Add("display", "block");
                this.GridViewInvoice.AllowCustomPaging = true;
                this.GridViewInvoice.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
            }
            this.GridViewInvoice.Style.Add("width", "100%");
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewInvoice, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridViewInvoice);
        }

        protected void GridViewInvoice_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewInvoice_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                invoice_view.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "invoicevalue" || commandArgument.Second.ToString().ToLower() == "quantity" || commandArgument.Second.ToString().ToLower() == "estimatevalue_excgst" || commandArgument.Second.ToString().ToLower() == "invoiceamountpaid" || commandArgument.Second.ToString().ToLower() == "invoiceoutstanding"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Please Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text.Trim();
                    }
                }
                if (this.Session["search_Inv"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_Inv"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_Inv"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    if (commandArgument.First.ToString().ToLower() != "nofilter" && item.Text != "")
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(second);
                        this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                    }
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter" && item.Text !="")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                this.Session["search_Inv"] = this.dtsearch;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                invoice_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
                this.GridViewInvoice.DataBind();
                //this.GridViewInvoice.Rebind();
            }
        }

        protected void GridViewInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewInvoice.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, this.GridViewInvoice.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.SelectedValue), invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
        }

        protected void GridViewInvoice_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            invoice_view.SortedBy = e.SortExpression;
            invoice_view.sortdirection = e.NewSortOrder.ToString();
            if (invoice_view.sortdirection.ToLower() == "ascending")
            {
                invoice_view.sortdirection = "ASC";
                this.GridViewInvoice.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (invoice_view.sortdirection.ToLower() != "descending")
            {
                invoice_view.sortdirection = "ASC";
                this.GridViewInvoice.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                invoice_view.sortdirection = "DESC";
                this.GridViewInvoice.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridViewInvoice.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, this.GridViewInvoice.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, invoice_view.sortdirection, invoice_view.WhereCondition);
        }

        protected void lnkInvoiceArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    DataTable dataTable = InvoiceBasePage.Invoice_Select_By_InvoiceID(companyID, (long)Convert.ToInt32(str.Split(chrArray)[0].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Invoice_Number = row["InvoiceNumber"].ToString();
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        this.ModuleID = Convert.ToInt64(str1.Split(chrArray1)[0].ToString());
                    }
                    this.objnotes.Invoice_number = this.Invoice_Number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvArchived);
                    int num = this.CompanyID;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    InvoiceBasePage.Invoice_Archive(num, (long)Convert.ToInt32(str2.Split(chrArray2)[0].ToString()));
                }
                else
                {
                    int companyID1 = this.CompanyID;
                    string str3 = strArrays[i];
                    char[] chrArray3 = new char[] { '\u005F' };
                    DataTable dataTable1 = InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(companyID1, (long)Convert.ToInt32(str3.Split(chrArray3)[2].ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.InvoiceItem_Number = dataRow["InvoiceItemNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(dataRow["InvoiceID"].ToString());
                    }
                    this.objnotes.Item_number = this.InvoiceItem_Number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemArchived);
                    notesclass _notesclass = this.objnotes;
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    _notesclass.ItemID = (long)Convert.ToInt32(str4.Split(chrArray4)[2].ToString());
                    int num1 = this.CompanyID;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Archive(num1, (long)Convert.ToInt32(str5.Split(chrArray5)[2].ToString()), "invoice");
                }
                this.objnotes.ModuleName = "Invoice";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.Rebind();
        }

        protected void lnkInvoiceExported_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                //if (!this.IsItemSelected)
                //{
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    DataTable dataTable = InvoiceBasePage.Invoice_Select_By_InvoiceID(companyID, (long)Convert.ToInt32(str.Split(chrArray)[0].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Invoice_Number = row["InvoiceNumber"].ToString();
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        this.ModuleID = Convert.ToInt64(str1.Split(chrArray1)[0].ToString());
                    }
                    this.objnotes.Invoice_number = this.Invoice_Number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvExported);
                    int num = this.CompanyID;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    InvoiceBasePage.Invoice_Exported(num, (long)Convert.ToInt32(str2.Split(chrArray2)[0].ToString()));
                //}
                //else
                //{
                //    int companyID1 = this.CompanyID;
                //    string str3 = strArrays[i];
                //    char[] chrArray3 = new char[] { '\u005F' };
                //    DataTable dataTable1 = InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(companyID1, (long)Convert.ToInt32(str3.Split(chrArray3)[2].ToString()));
                //    foreach (DataRow dataRow in dataTable1.Rows)
                //    {
                //        this.InvoiceItem_Number = dataRow["InvoiceItemNumber"].ToString();
                //        this.ModuleID = Convert.ToInt64(dataRow["InvoiceID"].ToString());
                //    }
                //    this.objnotes.Item_number = this.InvoiceItem_Number;
                //    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvExported);
                //    notesclass _notesclass = this.objnotes;
                //    string str4 = strArrays[i];
                //    char[] chrArray4 = new char[] { '\u005F' };
                //    _notesclass.ItemID = (long)Convert.ToInt32(str4.Split(chrArray4)[2].ToString());
                //    int num1 = this.CompanyID;
                //    string str5 = strArrays[i];
                //    char[] chrArray5 = new char[] { '\u005F' };
                //    EstimatesBasePage.EstimateItem_Archive(num1, (long)Convert.ToInt32(str5.Split(chrArray5)[2].ToString()), "invoice");
                //}
                this.objnotes.ModuleName = "Invoice";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            //if (!this.IsItemSelected)
            //{
                base.Message_Display("Invoice(s) Exported successfully", "successfulMsg", this.plhMessage);
            //}
            //else
            //{
            //    base.Message_Display("Invoice item(s) archived successfully", "successfulMsg", this.plhMessage);
            //}
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.Rebind();
        }

        protected void lnkInvoiceUnexported_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                //if (!this.IsItemSelected)
                //{
                int companyID = this.CompanyID;
                string str = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                DataTable dataTable = InvoiceBasePage.Invoice_Select_By_InvoiceID(companyID, (long)Convert.ToInt32(str.Split(chrArray)[0].ToString()));
                foreach (DataRow row in dataTable.Rows)
                {
                    this.Invoice_Number = row["InvoiceNumber"].ToString();
                    string str1 = strArrays[i];
                    char[] chrArray1 = new char[] { '\u005F' };
                    this.ModuleID = Convert.ToInt64(str1.Split(chrArray1)[0].ToString());
                }
                this.objnotes.Invoice_number = this.Invoice_Number;
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvUnexported);
                int num = this.CompanyID;
                string str2 = strArrays[i];
                char[] chrArray2 = new char[] { '\u005F' };
                InvoiceBasePage.Invoice_Unexported(num, (long)Convert.ToInt32(str2.Split(chrArray2)[0].ToString()));
                //}
                //else
                //{
                //    int companyID1 = this.CompanyID;
                //    string str3 = strArrays[i];
                //    char[] chrArray3 = new char[] { '\u005F' };
                //    DataTable dataTable1 = InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(companyID1, (long)Convert.ToInt32(str3.Split(chrArray3)[2].ToString()));
                //    foreach (DataRow dataRow in dataTable1.Rows)
                //    {
                //        this.InvoiceItem_Number = dataRow["InvoiceItemNumber"].ToString();
                //        this.ModuleID = Convert.ToInt64(dataRow["InvoiceID"].ToString());
                //    }
                //    this.objnotes.Item_number = this.InvoiceItem_Number;
                //    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvExported);
                //    notesclass _notesclass = this.objnotes;
                //    string str4 = strArrays[i];
                //    char[] chrArray4 = new char[] { '\u005F' };
                //    _notesclass.ItemID = (long)Convert.ToInt32(str4.Split(chrArray4)[2].ToString());
                //    int num1 = this.CompanyID;
                //    string str5 = strArrays[i];
                //    char[] chrArray5 = new char[] { '\u005F' };
                //    EstimatesBasePage.EstimateItem_Archive(num1, (long)Convert.ToInt32(str5.Split(chrArray5)[2].ToString()), "invoice");
                //}
                this.objnotes.ModuleName = "Invoice";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            //if (!this.IsItemSelected)
            //{
            base.Message_Display("Invoice(s) UnExported successfully", "successfulMsg", this.plhMessage);
            //}
            //else
            //{
            //    base.Message_Display("Invoice item(s) archived successfully", "successfulMsg", this.plhMessage);
            //}
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.Rebind();
        }

        protected void lnkInvoiceCopy_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnInvoiceID.Value.Split(new char[] { ',' });
            string[] strArrays1 = this.hdnEstimateID.Value.Split(new char[] { ',' });
            if (strArrays[0] != "" && strArrays1[0] != "")
            {
                long num = Convert.ToInt64(strArrays[0]);
                long num1 = Convert.ToInt64(strArrays1[0]);
                bool flag = false;
                long num2 = EstimateBasePage.Copy_Estimate(this.CompanyID, num1, "invoice", ref flag);
                if (flag)
                {
                    JobBasePage.copy_job(this.CompanyID, num, num2, ConnectionClass.IsHandy);
                }
                InvoiceBasePage.copy_invoice(this.CompanyID, num1, num2, ConnectionClass.IsHandy);
                this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
                this.GridViewInvoice.Rebind();
            }
        }

        protected void lnkInvoiceDelete_OnClick(object sender, EventArgs e)
        {
            Int32 countZero = 0;
            string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)Convert.ToInt32(strArray.Split(chrArray)[!this.IsItemSelected ? 0 : 2].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this invoice and it can not be deleted. Please contact support and request assistance" : "There is an error in one of the invoice(s) and can not be deleted. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);

                return;
            }

            bool flag = true;
            //string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (this.rdb_Delete_All.Checked)
                {
                    flag = false;
                }
                if (!this.IsItemSelected)
                {
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    InvoiceBasePage.Invoice_Delete(companyID, (long)Convert.ToInt32(str.Split(chrArray)[0].ToString()), flag);
                }
                else
                {
                    int num = this.CompanyID;
                    string str1 = strArrays[i];
                    char[] chrArray1 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Delete(num, (long)Convert.ToInt32(str1.Split(chrArray1)[2].ToString()), "invoice", flag);
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.Rebind();
        }

        protected void lnkInvoiceUnArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    DataTable dataTable = InvoiceBasePage.Invoice_Select_By_InvoiceID(companyID, (long)Convert.ToInt32(str.Split(chrArray)[0].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Invoice_Number = row["InvoiceNumber"].ToString();
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        this.ModuleID = Convert.ToInt64(str1.Split(chrArray1)[0].ToString());
                    }
                    this.objnotes.Invoice_number = this.Invoice_Number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvUnArchived);
                    int num = this.CompanyID;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    InvoiceBasePage.Invoice_UnArchive(num, (long)Convert.ToInt32(str2.Split(chrArray2)[0].ToString()));
                }
                else
                {
                    int companyID1 = this.CompanyID;
                    string str3 = strArrays[i];
                    char[] chrArray3 = new char[] { '\u005F' };
                    DataTable dataTable1 = InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(companyID1, (long)Convert.ToInt32(str3.Split(chrArray3)[2].ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.InvoiceItem_Number = dataRow["InvoiceItemNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(dataRow["InvoiceID"].ToString());
                    }
                    this.objnotes.Item_number = this.InvoiceItem_Number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvItemUnArchived);
                    notesclass _notesclass = this.objnotes;
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    _notesclass.ItemID = (long)Convert.ToInt32(str4.Split(chrArray4)[2].ToString());
                    int num1 = this.CompanyID;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_UnArchive(num1, (long)Convert.ToInt32(str5.Split(chrArray5)[2].ToString()), "invoice");
                }
                this.objnotes.ModuleName = "Invoice";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Invoice_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, invoice_view.WhereCondition);
            this.GridViewInvoice.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridViewInvoice.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text.ToLower() == "nofilter")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu.Items[i].Text.ToLower() == "contains")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu.Items[i].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu.Items[i].Text.ToLower() == "startswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "endswith")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu.Items[i].Text.ToLower() == "equalto")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        public string Only_number(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
            //foreach (GridItem item in GridViewInvoice.MasterTableView.Items)
            //{
            //    if (item is GridGroupHeaderItem groupHeader)
            //    {
            //        string text = groupHeader.DataCell.Text;

            //        int colonIndex = text.IndexOf(':');
            //        if (colonIndex > -1 && colonIndex + 1 < text.Length)
            //        {
            //            string justValue = text.Substring(colonIndex + 1).Trim(); // e.g., "08/04/2025"
            //            groupHeader.DataCell.Text = justValue;
            //        }
            //    }
            //}
        }

        protected void OnRowDataBound_GridViewInvoice(object sender, GridItemEventArgs e)
        {
            string[] languageConversion;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewInvoice.Columns.Count; i++)
                {
                    if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoicenumber")
                    {
                        this.flag_invoiceno = "true";
                        this.cellvalue_invoiceno = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoicevalue")
                    {
                        this.cellvalue_Invval = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_Invval = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoiceamountpaid")
                    {
                        this.cellvalue_InvoiceAmountPaid = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvoiceAmountPaid = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoiceoutstanding")
                    {
                        this.cellvalue_InvoiceOutstanding = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvoiceOutstanding = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "ispaid")
                    {
                        this.cellvalue_ispaid = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_ispaid = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "priority")
                    {
                        this.cellvalue_priority = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_priority = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.cellvalue_InvvalExcGst = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvvalExcGst = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "quantity")
                    {
                        this.cellvalue_Quantity = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_Quantity = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.cellvalue_customername = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_customername = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.cellvalue_invoicetitle = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_invoicetitle = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.cellvalue_paymentterms = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_paymentterms = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.cellvalue_customeraccountnumber = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_customeraccountnumber = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "attentionid")
                    {
                        this.cellvalue_contactname = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_contactname = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoicestatus")
                    {
                        this.cellvalue_invoicestatus = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_invoicestatus = "true";
                    }

                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.cellvalue_ChooseTemplate = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.cellvalue_DownloadTemplate = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.cellvalue_AccountStatus = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.cellvalue_status = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_status = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.cellvalue_customerordernumber = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_customerordernumber = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.cellvalue_referredby = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_referredby = "true";
                    }

                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.flag_SinceStatusUpdate = "true";
                        this.cellvalue_SinceStatusUpdate = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.flag_SinceEmailed = "true";
                        this.cellvalue_SinceEmailed = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
                        {
                            this.GridViewInvoice.MasterTableView.GetColumn("costcentre").Visible = true;
                            this.cellvalue_costcentre = this.GridViewInvoice.Columns[i].SortExpression;
                            this.flag_costcentre = "true";
                        }
                        else
                        {
                            this.GridViewInvoice.MasterTableView.GetColumn("costcentre").Visible = false;
                        }
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_salesperson = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_salesperson = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.cellvalue_InvoiceType = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvoiceType = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.cellvalue_EstimateNumber = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_EstimateNumber = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "job number")
                    {
                        this.cellvalue_JobNumber = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_JobNumber = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoiceduedate")
                    {
                        this.cellvalue_InvoiceDueDate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvoiceDueDate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "paymentdate")
                    {
                        this.cellvalue_paymentdate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_paymentdate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.cellvalue_deliverydate = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "paymentnotes")
                    {
                        this.cellvalue_PaymentNotes = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_PaymentNotes = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "customertype")
                    {
                        this.flag_CustomerType = "true";
                        this.cellvalue_CustomerType = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address1")
                    {
                        this.flag_Address1 = "true";
                        this.cellvalue_Address1 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address2")
                    {
                        this.flag_Address2 = "true";
                        this.cellvalue_Address2 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address3")
                    {
                        this.flag_Address3 = "true";
                        this.cellvalue_Address3 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address4")
                    {
                        this.flag_Address4 = "true";
                        this.cellvalue_Address4 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "address5")
                    {
                        this.flag_Address5 = "true";
                        this.cellvalue_Address5 = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "eventname")
                    {
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "eventvenue")
                    {
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "jobname")
                    {
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "jobstatus")
                    {
                        this.flag_JobStatus = "true";
                        this.cellvalue_JobStatus = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "po number")
                    {
                        this.flag_PONumber = "true";
                        this.cellvalue_PONumber = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "department")
                    {
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "ftp")
                    {
                        this.flag_FTPStatus = "true";
                        this.cellvalue_FTPStatus = this.GridViewInvoice.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_Error");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plh_backorder");
                PlaceHolder placeHolder3 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder4 = (PlaceHolder)e.Item.FindControl("plh_stockproduct");
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                str1 = string.Concat(this.strImagepath, "Attachment.PNG");
                empty2 = "Item with an attachment(s)";
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string languageConversion1 = string.Empty;
                empty3 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion1 = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                str = string.Concat(this.strImagepath, "Stock-Icon.jpg");
                empty1 = this.objLanguage.GetLanguageConversion("Stock_Product");
                if (!this.IsItemSelected)
                {
                    DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", ((DataRowView)e.Item.DataItem)[1].ToString()));
                    if ((int)dataRowArray.Length > 0)
                    {
                        str2 = dataRowArray[0]["ArtWork"].ToString();
                    }
                }
                else
                {
                    DataRow[] dataRowArray1 = this.dtArtwork.Select(string.Concat("EstimateItemID=", ((DataRowView)e.Item.DataItem)[2].ToString()));
                    if ((int)dataRowArray1.Length > 0)
                    {
                        str2 = dataRowArray1[0]["ArtWork"].ToString();
                    }
                }
                if (Convert.ToInt16(item["ErrorCount"].Text) <= 0)
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                }
                if (item["EstItemCoun"].Text != "0" || str2 != "")
                {
                    ControlCollection controls = placeHolder.Controls;
                    languageConversion = new string[] { "<img src='", str1, "' title='", empty2, "' style='cursor:pointer;' class='viewicon_margin' />" };
                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                if (Convert.ToInt16(item["BackOrder"].Text) != 1)
                {
                    placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0'  style='width:0px' />")));
                }
                else
                {
                    ControlCollection controlCollections = placeHolder2.Controls;
                    languageConversion = new string[] { "<img src='", this.strImagepath, "BackOrder.png' border='0' title='", this.objLanguage.GetLanguageConversion("Back_Order"), "' class='viewicon_margin' />" };
                    controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls1 = placeHolder3.Controls;
                    languageConversion = new string[] { "<img src='", empty3, "'  title='", languageConversion1, "' class='viewicon_margin'  />" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (Convert.ToInt16(item["IsStockProduct"].Text) == 1)
                {
                    ControlCollection controlCollections1 = placeHolder3.Controls;
                    languageConversion = new string[] { "<img src='", str, "'  title='", empty1, "' class='viewicon_margin'  />" };
                    controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (item["isfromwebstore"].Text.Trim().ToLower() != "yes")
                {
                    empty = string.Concat("invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell = item["invoicenumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell.Text = string.Concat(languageConversion);
                    }
                    else
                    {
                        TableCell item1 = item["invoicenumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", ((DataRowView)e.Item.DataItem)[2].ToString(), "&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        item1.Text = string.Concat(languageConversion);
                    }
                }
                else
                {
                    languageConversion = new string[] { "invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString() };
                    empty = string.Concat(languageConversion);
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell1 = item["invoicenumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell1.Text = string.Concat(languageConversion);
                    }
                    else
                    {
                        TableCell item2 = item["invoicenumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", ((DataRowView)e.Item.DataItem)[2].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        item2.Text = string.Concat(languageConversion);
                    }
                }
                if (this.flag_priority == "true")
                {

                    item[this.cellvalue_priority].Attributes.Add("align", "center");
                    item[this.cellvalue_priority].Attributes.Add("class", "hyperlinkNoUnderline");

                    //item[this.cellvalue_ApprovalDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_priority].Attributes.Add("onclick",
                             string.Concat("javascript:OnPriorityClick('",
                             ((DataRowView)e.Item.DataItem)[0].ToString(), "','",
                             string.IsNullOrEmpty(item[this.cellvalue_priority].Text.Replace("&nbsp;", "")) ? "-" : item[this.cellvalue_priority].Text.Replace("&nbsp;", ""),
                             "');"));
                    try
                    {
                        //item[this.cellvalue_priority].Text = string.IsNullOrEmpty(item[this.cellvalue_priority].Text.Replace("&nbsp;", "")) ? "-" : item[this.cellvalue_priority].Text.Replace("&nbsp;", "");
                        string priorityText = item[this.cellvalue_priority].Text.Replace("&nbsp;", "").Trim();
                        // Handle display logic
                        if (string.IsNullOrEmpty(priorityText) || priorityText == "99" || priorityText.Equals("pending", StringComparison.OrdinalIgnoreCase))
                        {
                            priorityText = "...";
                        }

                        // Set final display text
                        item[this.cellvalue_priority].Text = priorityText;
                    }
                    catch
                    {
                    }

                    item[this.cellvalue_priority].Style.Add("cursor", "pointer");
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                    item[this.cellvalue_createddate].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_createddate].Text);
                }
                if (this.flag_Invval == "true")
                {
                    item[this.cellvalue_Invval].Attributes.Add("align", "right");
                    item[this.cellvalue_Invval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Invval].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Invval].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Invval].Text), 0, "", false, false, true);
                    item[this.cellvalue_Invval].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Invval].Text);
                }
                if (this.flag_InvoiceAmountPaid == "true")
                {
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("align", "right");
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceAmountPaid].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvoiceAmountPaid].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvoiceAmountPaid].Text), 0, "", false, false, true);
                    item[this.cellvalue_InvoiceAmountPaid].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_InvoiceAmountPaid].Text);
                }
                if (this.flag_InvoiceOutstanding == "true")
                {
                    item[this.cellvalue_InvoiceOutstanding].Attributes.Add("align", "right");
                    item[this.cellvalue_InvoiceOutstanding].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceOutstanding].Style.Add("cursor", "pointer");
                    if (Convert.ToDecimal(item[this.cellvalue_InvoiceOutstanding].Text) < new decimal(0))
                    {
                        item[this.cellvalue_InvoiceOutstanding].ForeColor = Color.Green;
                        item[this.cellvalue_InvoiceOutstanding].Text = item[this.cellvalue_InvoiceOutstanding].Text.Substring(1, item[this.cellvalue_InvoiceOutstanding].Text.Length - 1);
                    }
                    else
                    {
                        item[this.cellvalue_InvoiceOutstanding].ForeColor = Color.Red;
                    }
                    item[this.cellvalue_InvoiceOutstanding].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvoiceOutstanding].Text), 0, "", false, false, true);
                    item[this.cellvalue_InvoiceOutstanding].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_InvoiceOutstanding].Text);
                }
                if (this.flag_InvvalExcGst == "true")
                {
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvvalExcGst].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvvalExcGst].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvvalExcGst].Text), 0, "", false, false, true);
                    item[this.cellvalue_InvvalExcGst].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_InvvalExcGst].Text);
                }
                if (this.flag_ispaid == "true")
                {
                    item[this.cellvalue_ispaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ispaid].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ispaid].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ispaid].Text);
                }
                if (this.flag_Quantity == "true")
                {
                    item[this.cellvalue_Quantity].Attributes.Add("align", "right");
                    item[this.cellvalue_Quantity].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Quantity].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Quantity].ToolTip = item[this.cellvalue_Quantity].Text;
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customername].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_customername].Text);
                }
                if (this.flag_invoicetitle == "true")
                {
                    item[this.cellvalue_invoicetitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_invoicetitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_invoicetitle].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_invoicetitle].Text);
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                    item[this.cellvalue_paymentterms].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_paymentterms].Text);
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customeraccountnumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_customeraccountnumber].Text);
                }


                if (this.flag_DefaultTemplate == "true")
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["EstimateID"].Text;
                    string invid= item["InvoiceID"].Text;
                    string targetUrl = $"{this.strSitepath}Invoice/templates_view1.aspx?sectionid={customerid}&sectionname=Invoice&type=Customer&page=Invoice&EstID={estimateId}&InvID={invid}&ordid={orderid}&GenPdf=all&customtype=preview";

                  
                    item[this.cellvalue_DefaultTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_DefaultTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_DefaultTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_DefaultTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_self", // Opens in new tab
                        ToolTip = "Click to display default PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = string.Concat(this.strImagepath, "previewpdf.png"),
                        AlternateText = "Preview",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_DefaultTemplate].Controls.Add(link);
                }

                if (this.flag_ChooseTemplate == "true") // Using flag_ChooseTemplate
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["EstimateID"].Text;
                    string invid = item["InvoiceID"].Text;
                    string targetUrl = $"{this.strSitepath}Invoice/templates_view1.aspx?sectionid={customerid}&sectionname=Invoice&type=Customer&page=Invoice&EstID={estimateId}&InvID={invid}&ordid={orderid}&GenPdf=all&customtype=choosetemp";

                    item[this.cellvalue_ChooseTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_ChooseTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_ChooseTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_ChooseTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_self", // Opens in a new tab
                        ToolTip = "Click to choose PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}template-select.png",
                        AlternateText = "View Order",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_ChooseTemplate].Controls.Add(link);
                }

                if (this.flag_DownloadTemplate == "true") // Using flag_DownloadTemplate
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string orderid = item["EstimateID"].Text;
                    string invid = item["InvoiceID"].Text;
                    string targetUrl = $"{this.strSitepath}Invoice/templates_view1.aspx?sectionid={customerid}&sectionname=Invoice&type=Customer&page=Invoice&EstID={estimateId}&InvID={invid}&ordid={orderid}&GenPdf=all&customtype=download";

                    item[this.cellvalue_DownloadTemplate].Attributes.Add("align", "center");
                    item[this.cellvalue_DownloadTemplate].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_DownloadTemplate].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_DownloadTemplate].Controls.Clear();

                    // Create HyperLink control
                    HyperLink link = new HyperLink
                    {
                        NavigateUrl = targetUrl,
                        Target = "_blank", // Opens in a new tab
                        ToolTip = "Click to download PDF"
                    };

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}download-pdf.png", // Assuming download icon
                        AlternateText = "Download PDF",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_DownloadTemplate].Controls.Add(link);
                }

                if (this.flag_Archive == "true") // Using flag_DownloadTemplate
                {
                  

                    string type = "archive"; // or "unarchive", depending on your logic

                    string estimateitemid = string.Empty;

                    string invoiceId = item["InvoiceID"].Text;
                    string estimateId = item["EstimateID"].Text;
                    string estimateItemId = item["EstimateItemID"].Text;
                    string custId = item["Cust_ID"].Text;
                    string paymentType = item["PaymentType"].Text;
                    this.cellvalue_Archive = "archive";



                    string combinedValue = String.Concat(
                             invoiceId, "_",
                             estimateId, "_",
                             estimateItemId, "_",
                             custId, "_",
                             paymentType
                         );
                    // Escape any single quotes to avoid JS errors
                    combinedValue = combinedValue.Replace("'", "\\'").Replace("&nbsp;", "").Trim();

                    item[this.cellvalue_Archive].Attributes.Add("align", "center");
                    item[this.cellvalue_Archive].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_Archive].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_Archive].Controls.Clear();

                    // Create HyperLink control
                    HtmlGenericControl link = new HtmlGenericControl("a");
                    link.Attributes["href"] = "javascript:void(0);"; // prevent navigation
                    link.Attributes["onclick"] = $"CheckOne('{type}', '{combinedValue}');"; // call JS function
                    link.Attributes["title"] = "Click to Archive";

                    // Create Image control
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
                    {
                        ImageUrl = $"{this.strImagepath}archive.png", // Assuming download icon
                        AlternateText = "Archive the item",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_Archive].Controls.Add(link);
                }




                if (this.flag_salesperson == "true")
                {
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                    item[this.cellvalue_salesperson].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_salesperson].Text);
                }
                if (this.flag_invoicestatus == "true")
                {
                    item[this.cellvalue_invoicestatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_invoicestatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_invoicestatus].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                    item[this.cellvalue_invoicestatus].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_invoicestatus].Text);
                }


                if (this.flag_JobStatus == "true")
                {
                    item[this.cellvalue_JobStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobStatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_JobStatus].Style.Add("background-color", item["jobStatusColCode"].Text); // Add this line
                    item[this.cellvalue_JobStatus].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_JobStatus].Text);
                }

                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_AccountStatus].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_AccountStatus].Text.Replace("<span style=color:red; >", "").Replace("</span>", ""));
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                   
                    item[this.cellvalue_status].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_status].Text);
                }
                if (this.flag_customerordernumber == "true")
                {
                    item[this.cellvalue_customerordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customerordernumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_customerordernumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_customerordernumber].Text);
                    string originalText = base.Server.HtmlDecode(item[this.cellvalue_customerordernumber].Text);
                    if (!string.IsNullOrEmpty(originalText) && originalText.Length > 25)
                    {
                        item[this.cellvalue_customerordernumber].Text = originalText.Substring(0, 25) + "...";
                    }
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                    item[this.cellvalue_referredby].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_referredby].Text);
                }
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                    item[this.cellvalue_contactname].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_contactname].Text);
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_costcentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_costcentre].Style.Add("cursor", "pointer");
                    item[this.cellvalue_costcentre].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_costcentre].Text);
                }
                if (this.flag_salesperson == "true")
                {
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                    item[this.cellvalue_salesperson].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_salesperson].Text);
                }
                if (this.flag_InvoiceType == "true")
                {
                    item[this.cellvalue_InvoiceType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceType].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvoiceType].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_InvoiceType].Text);
                }
                if (this.flag_EstimateNumber == "true")
                {
                    item[this.cellvalue_EstimateNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EstimateNumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_EstimateNumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_EstimateNumber].Text);
                }
                if (this.flag_JobNumber == "true")
                {
                    item[this.cellvalue_JobNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobNumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_JobNumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_JobNumber].Text);
                }
                if (this.flag_PONumber == "true")
                {
                    item[this.cellvalue_PONumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_PONumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_PONumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_PONumber].Text);
                }
                if (this.flag_InvoiceDueDate == "true")
                {
                    item[this.cellvalue_InvoiceDueDate].Attributes.Add("align", "center");
                    item[this.cellvalue_InvoiceDueDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceDueDate].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvoiceDueDate].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_InvoiceDueDate].Text);
                }
                if (this.flag_CustomDate1 == "true")
                {
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentdate == "true")
                {
                    item[this.cellvalue_paymentdate].Attributes.Add("align", "left");
                    item[this.cellvalue_paymentdate].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_paymentdate].Text);
                    if (item[this.cellvalue_paymentdate].Text.Length > 30)
                    {
                        item[this.cellvalue_paymentdate].Text = string.Concat(item[this.cellvalue_paymentdate].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_paymentdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_paymentdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "left");
                    item[this.cellvalue_deliverydate].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_deliverydate].Text);
                    if (item[this.cellvalue_deliverydate].Text.Length > 30)
                    {
                        item[this.cellvalue_deliverydate].Text = string.Concat(item[this.cellvalue_deliverydate].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                }
                if (this.flag_PaymentNotes == "true")
                {
                    item[this.cellvalue_PaymentNotes].Attributes.Add("align", "left");
                    item[this.cellvalue_PaymentNotes].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_PaymentNotes].Text);
                    if (item[this.cellvalue_PaymentNotes].Text.Length > 30)
                    {
                        item[this.cellvalue_PaymentNotes].Text = string.Concat(item[this.cellvalue_PaymentNotes].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_PaymentNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_PaymentNotes].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomerType == "true")
                {
                    item[this.cellvalue_CustomerType].Attributes.Add("align", "left");
                    item[this.cellvalue_CustomerType].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_CustomerType].Text);
                    if (item[this.cellvalue_CustomerType].Text.Length > 30)
                    {
                        item[this.cellvalue_CustomerType].Text = string.Concat(item[this.cellvalue_CustomerType].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_CustomerType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomerType].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address1 == "true")
                {
                    item[this.cellvalue_Address1].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Address1].Text);
                    if (item[this.cellvalue_Address1].Text.Length > 30)
                    {
                        item[this.cellvalue_Address1].Text = string.Concat(item[this.cellvalue_Address1].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address1].Attributes.Add("align", "left");
                    item[this.cellvalue_Address1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address1].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address2 == "true")
                {
                    item[this.cellvalue_Address2].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Address2].Text);
                    if (item[this.cellvalue_Address2].Text.Length > 30)
                    {
                        item[this.cellvalue_Address2].Text = string.Concat(item[this.cellvalue_Address2].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address2].Attributes.Add("align", "left");
                    item[this.cellvalue_Address2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address2].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address3 == "true")
                {
                    item[this.cellvalue_Address3].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Address3].Text);
                    if (item[this.cellvalue_Address3].Text.Length > 30)
                    {
                        item[this.cellvalue_Address3].Text = string.Concat(item[this.cellvalue_Address3].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address3].Attributes.Add("align", "left");
                    item[this.cellvalue_Address3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address3].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address4 == "true")
                {
                    item[this.cellvalue_Address4].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Address4].Text);
                    if (item[this.cellvalue_Address4].Text.Length > 30)
                    {
                        item[this.cellvalue_Address4].Text = string.Concat(item[this.cellvalue_Address4].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address4].Attributes.Add("align", "left");
                    item[this.cellvalue_Address4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address4].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address5 == "true")
                {
                    item[this.cellvalue_Address5].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Address5].Text);
                    if (item[this.cellvalue_Address5].Text.Length > 30)
                    {
                        item[this.cellvalue_Address5].Text = string.Concat(item[this.cellvalue_Address5].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address5].Attributes.Add("align", "left");
                    item[this.cellvalue_Address5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address5].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemStatus].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemStatus].Text);
                    item[this.cellvalue_ItemStatus].Text = string.Concat("<div style='overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>");
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemTitle].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemTitle].Text);
                }
                if (this.flag_comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_comments, "InvoiceID");               
                }
                if (this.flag_ItemAccCode == "true")
                {
                    item[this.cellvalue_ItemAccCode].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemAccCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemAccCode].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemAccCode].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemAccCode].Text);
                }
                if (this.flag_ItemQTY == "true")
                {
                    item[this.cellvalue_ItemQTY].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemQTY].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemQTY].ToolTip = item[this.cellvalue_ItemQTY].Text;
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemValue_ExcTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemValue_ExcTax].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemValue_ExcTax].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemValue_IncTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemValue_IncTax].ToolTip = item[this.cellvalue_ItemValue_IncTax].Text;
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTaxValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemTaxValue].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemTaxValue].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemCostPriceExcMarkup].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemCostPriceExcMarkup].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemMarkupValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemMarkupValue].ToolTip = item[this.cellvalue_ItemMarkupValue].Text;
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemCostPriceIncMarkup].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemCostPriceIncMarkup].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemProfitMarginPercentage].ToolTip = item[this.cellvalue_ItemProfitMarginPercentage].Text;
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemProfitMarginValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemProfitMarginValue].ToolTip = item[this.cellvalue_ItemProfitMarginValue].Text;
                    }
                    catch
                    {
                    }
                }


                if (this.flag_SinceEmailed == "true")
                {
                    item[this.cellvalue_SinceEmailed].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceEmailed"].Text) >= Convert.ToInt32(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceEmailed"].Text != "0")
                            item[this.cellvalue_SinceEmailed].Style.Add("background-color", "#E64557"); // Add this line

                    if (item["isAnyEmailed"].Text == "0")
                        item[this.cellvalue_SinceEmailed].Text = "N/A";
                    item[this.cellvalue_SinceEmailed].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceEmailed].Style.Add("cursor", "pointer");
                }
                if (this.flag_SinceStatusUpdate == "true")
                {
                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceStatusUpdate"].Text) >= Convert.ToInt32(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceStatusUpdate"].Text != "0")
                            item[this.cellvalue_SinceStatusUpdate].Style.Add("background-color", "#E64557"); // Add this line

                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceStatusUpdate].Style.Add("cursor", "pointer");
                }


                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemGrossProfitPercentage].ToolTip = item[this.cellvalue_ItemGrossProfitPercentage].Text;
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemGrossProfitValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue].Text), 0, "", false, false, true);
                        item[this.cellvalue_ItemGrossProfitValue].ToolTip = item[this.cellvalue_ItemGrossProfitValue].Text;
                    }
                    catch
                    {
                    }
                }
                if (this.flag_EventName == "true")
                {
                    item[this.cellvalue_EventName].Attributes.Add("align", "left");
                    item[this.cellvalue_EventName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EventName].Style.Add("cursor", "pointer");
                    item[this.cellvalue_EventName].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_EventName].Text);
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("align", "left");
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EventCodeNumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_EventCodeNumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_EventCodeNumber].Text);
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("align", "right");
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CampaignSignNumber].Style.Add("cursor", "pointer");
                    item[this.cellvalue_CampaignSignNumber].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_CampaignSignNumber].Text);
                }
                if (this.flag_ItemMaterial == "true")
                {
                    item[this.cellvalue_ItemMaterial].Attributes.Add("align", "left");
                    item[this.cellvalue_ItemMaterial].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemMaterial].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemMaterial].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemMaterial].Text);
                }
                if (this.flag_EventVenue == "true")
                {
                    item[this.cellValue_EventVenue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellValue_EventVenue].Style.Add("cursor", "pointer");
                    item[this.cellValue_EventVenue].ToolTip = base.Server.HtmlDecode(item[this.cellValue_EventVenue].Text);
                }
                if (this.flag_Height == "true")
                {
                    item[this.cellvalue_Height].Attributes.Add("align", "right");
                    item[this.cellvalue_Height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Height].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Height].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Height].Text), 0, "", false, false, true);
                        item[this.cellvalue_Height].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Height].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_Width == "true")
                {
                    item[this.cellvalue_Width].Attributes.Add("align", "right");
                    item[this.cellvalue_Width].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Width].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Width].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Width].Text), 0, "", false, false, true);
                        item[this.cellvalue_Width].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Width].Text);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemDescription == "true")
                {
                    if (item[this.cellvalue_ItemDescription].Text != "")
                    {
                        item[this.cellvalue_ItemDescription].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemDescription].Text);
                    }
                    if (item[this.cellvalue_ItemDescription].Text.Length > 60)
                    {
                        item[this.cellvalue_ItemDescription].Text = item[this.cellvalue_ItemDescription].Text.Substring(0, 50);
                    }
                    item[this.cellvalue_ItemDescription].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemDescription].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemColour == "true")
                {
                    item[this.cellvalue_ItemColour].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemColour].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemColour].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemColour].Text);
                }
                if (this.flag_ItemSize == "true")
                {
                    item[this.cellvalue_ItemSize].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemSize].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemSize].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemSize].Text);
                }
                if (this.flag_ItemArtwork == "true")
                {
                    item[this.cellvalue_ItemArtwork].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemArtwork].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemArtwork].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemArtwork].Text);
                }
                if (this.flag_ItemDelivery == "true")
                {
                    item[this.cellvalue_ItemDelivery].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemDelivery].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemDelivery].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemDelivery].Text);
                }
                if (this.flag_ItemFinishing == "true")
                {
                    item[this.cellvalue_ItemFinishing].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemFinishing].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemFinishing].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemFinishing].Text);
                }
                if (this.flag_ItemProofs == "true")
                {
                    item[this.cellvalue_ItemProofs].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemProofs].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemProofs].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemProofs].Text);
                }
                if (this.flag_ItemPacking == "true")
                {
                    item[this.cellvalue_ItemPacking].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemPacking].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemPacking].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemPacking].Text);
                }
                if (this.flag_ItemNotes == "true")
                {
                    item[this.cellvalue_ItemNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemNotes].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemNotes].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemNotes].Text);
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    item[this.cellvalue_ItemTermsInstructions].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTermsInstructions].Style.Add("cursor", "pointer");
                    item[this.cellvalue_ItemTermsInstructions].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_ItemTermsInstructions].Text);
                }
                if (this.flag_JobName == "true")
                {
                    item[this.cellvalue_JobName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobName].Style.Add("cursor", "pointer");
                    item[this.cellvalue_JobName].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_JobName].Text);
                }
                if (this.flag_Department == "true")
                {
                    item[this.cellvalue_Department].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Department].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Department].ToolTip = base.Server.HtmlDecode(item[this.cellvalue_Department].Text);
                }
                if (this.flag_FTPStatus == "true")
                {
                    if (item[this.cellvalue_FTPStatus].Text == "Successful")
                    {
                        item[this.cellvalue_FTPStatus].Style.Add("background-color", "#01DA66");
                    }
                    else if (item[this.cellvalue_FTPStatus].Text == "Fail")
                    {
                        item[this.cellvalue_FTPStatus].Style.Add("background-color", "#E64557");
                    }
                    else
                    {
                        item[this.cellvalue_FTPStatus].Text = "N/A";
                    }
                }

            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_invoiceno == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_invoiceno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_invoiceno)] != null && this.Session[string.Concat("invoice_", this.cellvalue_invoiceno)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_customername == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_customername].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_customername)] != null && this.Session[string.Concat("invoice_", this.cellvalue_customername)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }
                if (this.flag_priority == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_priority].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_priority)] != null && this.Session[string.Concat("estimate_", this.cellvalue_priority)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_salesperson == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_salesperson].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_salesperson)] != null && this.Session[string.Concat("invoice_", this.cellvalue_salesperson)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_referredby == "true")
                {
                    TextBox item3 = (e.Item as GridFilteringItem)[this.cellvalue_referredby].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_referredby)] != null && this.Session[string.Concat("invoice_", this.cellvalue_referredby)].ToString() == "")
                    {
                        item3.Text = "";
                    }
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_customeraccountnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_customeraccountnumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_customeraccountnumber)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }

                if (this.flag_SinceEmailed == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceEmailed].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_SinceEmailed)] != null && this.Session[string.Concat("estimate_", this.cellvalue_SinceEmailed)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_SinceStatusUpdate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceStatusUpdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_SinceStatusUpdate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_SinceStatusUpdate)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_contactname == "true")
                {
                    TextBox item4 = (e.Item as GridFilteringItem)[this.cellvalue_contactname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_contactname)] != null && this.Session[string.Concat("invoice_", this.cellvalue_contactname)].ToString() == "")
                    {
                        item4.Text = "";
                    }
                }
                if (this.flag_invoicetitle == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_invoicetitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_invoicetitle)] != null && this.Session[string.Concat("invoice_", this.cellvalue_invoicetitle)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_invoicestatus == "true")
                {
                    TextBox item5 = (e.Item as GridFilteringItem)[this.cellvalue_invoicestatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_invoicestatus)] != null && this.Session[string.Concat("invoice_", this.cellvalue_invoicestatus)].ToString() == "")
                    {
                        item5.Text = "";
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_AccountStatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_AccountStatus)] != null && this.Session[string.Concat("invoice_", this.cellvalue_AccountStatus)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox item6 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_status)] != null && this.Session[string.Concat("invoice_", this.cellvalue_status)].ToString() == "")
                    {
                        item6.Text = "";
                    }
                }
                if (this.flag_customerordernumber == "true")
                {
                    TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_customerordernumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_customerordernumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_customerordernumber)].ToString() == "")
                    {
                        textBox6.Text = "";
                    }
                }
                if (this.flag_paymentterms == "true")
                {
                    TextBox item7 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("invoice_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        item7.Text = "";
                    }
                }
                if (this.flag_costcentre == "true")
                {
                    TextBox textBox7 = (e.Item as GridFilteringItem)[this.cellvalue_costcentre].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_costcentre)] != null && this.Session[string.Concat("invoice_", this.cellvalue_costcentre)].ToString() == "")
                    {
                        textBox7.Text = "";
                    }
                }
                if (this.flag_Invval == "true")
                {
                    gridFilteringItem[this.cellvalue_Invval].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item8 = (e.Item as GridFilteringItem)[this.cellvalue_Invval].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_Invval)] != null && this.Session[string.Concat("invoice_", this.cellvalue_Invval)].ToString() == "")
                    {
                        item8.Text = "";
                    }
                }
                if (this.flag_InvoiceAmountPaid == "true")
                {
                    gridFilteringItem[this.cellvalue_InvoiceAmountPaid].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox8 = (e.Item as GridFilteringItem)[this.cellvalue_InvoiceAmountPaid].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_InvoiceAmountPaid)] != null && this.Session[string.Concat("invoice_", this.cellvalue_InvoiceAmountPaid)].ToString() == "")
                    {
                        textBox8.Text = "";
                    }
                }
                if (this.flag_InvoiceOutstanding == "true")
                {
                    gridFilteringItem[this.cellvalue_InvoiceOutstanding].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item9 = (e.Item as GridFilteringItem)[this.cellvalue_InvoiceOutstanding].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_InvoiceOutstanding)] != null && this.Session[string.Concat("invoice_", this.cellvalue_InvoiceOutstanding)].ToString() == "")
                    {
                        item9.Text = "";
                    }
                }
                if (this.flag_InvvalExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_InvvalExcGst].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox9 = (e.Item as GridFilteringItem)[this.cellvalue_InvvalExcGst].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_InvvalExcGst)] != null && this.Session[string.Concat("invoice_", this.cellvalue_InvvalExcGst)].ToString() == "")
                    {
                        textBox9.Text = "";
                    }
                }
                if (this.flag_Quantity == "true")
                {
                    gridFilteringItem[this.cellvalue_Quantity].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item10 = (e.Item as GridFilteringItem)[this.cellvalue_Quantity].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_Quantity)] != null && this.Session[string.Concat("invoice_", this.cellvalue_Quantity)].ToString() == "")
                    {
                        item10.Text = "";
                    }
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox10 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
                    if (this.Session[this.cellvalue_createddate] != null && this.Session[string.Concat("invoice_", this.cellvalue_createddate)].ToString() == "")
                    {
                        textBox10.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_ispaid == "true")
                {
                    gridFilteringItem[this.cellvalue_ispaid].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item11 = (e.Item as GridFilteringItem)[this.cellvalue_ispaid].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ispaid)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ispaid)].ToString() == "")
                    {
                        item11.Text = "";
                    }
                }
                if (this.flag_InvoiceType == "true")
                {
                    gridFilteringItem[this.cellvalue_InvoiceType].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox11 = (e.Item as GridFilteringItem)[this.cellvalue_InvoiceType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_InvoiceType)] != null && this.Session[string.Concat("invoice_", this.cellvalue_InvoiceType)].ToString() == "")
                    {
                        textBox11.Text = "";
                    }
                }
                if (this.flag_InvoiceDueDate == "true")
                {
                    gridFilteringItem[this.cellvalue_InvoiceDueDate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_InvoiceDueDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_InvoiceDueDate)] != null && this.Session[string.Concat("invoice_", this.cellvalue_InvoiceDueDate)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_paymentdate == "true")
                {
                    gridFilteringItem[this.cellvalue_paymentdate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_paymentdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_paymentdate)] != null && this.Session[string.Concat("invoice_", this.cellvalue_paymentdate)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_deliverydate == "true")
                {
                    gridFilteringItem[this.cellvalue_deliverydate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_deliverydate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_deliverydate)] != null && this.Session[string.Concat("invoice_", this.cellvalue_deliverydate)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_PaymentNotes == "true")
                {
                    gridFilteringItem[this.cellvalue_PaymentNotes].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox12 = (e.Item as GridFilteringItem)[this.cellvalue_PaymentNotes].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_PaymentNotes)] != null && this.Session[string.Concat("invoice_", this.cellvalue_PaymentNotes)].ToString() == "")
                    {
                        textBox12.Text = "";
                    }
                }
                if (this.flag_CustomerType == "true")
                {
                    gridFilteringItem[this.cellvalue_CustomerType].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item13 = (e.Item as GridFilteringItem)[this.cellvalue_CustomerType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CustomerType)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CustomerType)].ToString() == "")
                    {
                        item13.Text = "";
                    }
                }
                if (this.flag_Address1 == "true")
                {
                    TextBox textBox13 = (e.Item as GridFilteringItem)[this.cellvalue_Address1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address1)] != null && this.Session[string.Concat("job_", this.cellvalue_Address1)].ToString() == "")
                    {
                        textBox13.Text = "";
                    }
                }
                if (this.flag_Address2 == "true")
                {
                    TextBox item14 = (e.Item as GridFilteringItem)[this.cellvalue_Address2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address2)] != null && this.Session[string.Concat("job_", this.cellvalue_Address2)].ToString() == "")
                    {
                        item14.Text = "";
                    }
                }
                if (this.flag_Address3 == "true")
                {
                    TextBox textBox14 = (e.Item as GridFilteringItem)[this.cellvalue_Address3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address3)] != null && this.Session[string.Concat("job_", this.cellvalue_Address3)].ToString() == "")
                    {
                        textBox14.Text = "";
                    }
                }
                if (this.flag_Address4 == "true")
                {
                    TextBox item15 = (e.Item as GridFilteringItem)[this.cellvalue_Address4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address4)] != null && this.Session[string.Concat("job_", this.cellvalue_Address4)].ToString() == "")
                    {
                        item15.Text = "";
                    }
                }
                if (this.flag_Address5 == "true")
                {
                    TextBox textBox15 = (e.Item as GridFilteringItem)[this.cellvalue_Address5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address5)] != null && this.Session[string.Concat("job_", this.cellvalue_Address5)].ToString() == "")
                    {
                        textBox15.Text = "";
                    }
                }
                if (this.flag_ItemQTY == "true")
                {
                    TextBox item16 = (e.Item as GridFilteringItem)[this.cellvalue_ItemQTY].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemQTY)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemQTY)].ToString() == "")
                    {
                        item16.Text = "";
                    }
                }
                if (this.flag_ItemTitle == "true")
                {
                    TextBox textBox16 = (e.Item as GridFilteringItem)[this.cellvalue_ItemTitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemTitle)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemTitle)].ToString() == "")
                    {
                        textBox16.Text = "";
                    }
                }
                if (this.flag_comments == "true")
                {
                    TextBox textBoxcomments = (e.Item as GridFilteringItem)[this.cellvalue_comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_comments)] != null && this.Session[string.Concat("invoice_", this.cellvalue_comments)].ToString() == "")
                    {
                        textBoxcomments.Text = "";
                    }
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    TextBox item17 = (e.Item as GridFilteringItem)[this.cellvalue_ItemValue_ExcTax].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemValue_ExcTax)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemValue_ExcTax)].ToString() == "")
                    {
                        item17.Text = "";
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    TextBox textBox17 = (e.Item as GridFilteringItem)[this.cellvalue_ItemCostPriceExcMarkup].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemCostPriceExcMarkup)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemCostPriceExcMarkup)].ToString() == "")
                    {
                        textBox17.Text = "";
                    }
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_ItemProfitMarginPercentage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemProfitMarginPercentage)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemProfitMarginPercentage)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    TextBox textBox18 = (e.Item as GridFilteringItem)[this.cellvalue_ItemCostPriceIncMarkup].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemCostPriceIncMarkup)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemCostPriceIncMarkup)].ToString() == "")
                    {
                        textBox18.Text = "";
                    }
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    TextBox item19 = (e.Item as GridFilteringItem)[this.cellvalue_ItemProfitMarginValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemProfitMarginValue)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemProfitMarginValue)].ToString() == "")
                    {
                        item19.Text = "";
                    }
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    TextBox textBox19 = (e.Item as GridFilteringItem)[this.cellvalue_ItemGrossProfitPercentage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemGrossProfitPercentage)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemGrossProfitPercentage)].ToString() == "")
                    {
                        textBox19.Text = "";
                    }
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_ItemGrossProfitValue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemGrossProfitValue)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemGrossProfitValue)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_EventName == "true")
                {
                    TextBox textBox20 = (e.Item as GridFilteringItem)[this.cellvalue_EventName].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_EventName)] != null && this.Session[string.Concat("invoice_", this.cellvalue_EventName)].ToString() == "")
                    {
                        textBox20.Text = "";
                    }
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    TextBox item21 = (e.Item as GridFilteringItem)[this.cellvalue_EventCodeNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_EventCodeNumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_EventCodeNumber)].ToString() == "")
                    {
                        item21.Text = "";
                    }
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    TextBox textBox21 = (e.Item as GridFilteringItem)[this.cellvalue_CampaignSignNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_CampaignSignNumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_CampaignSignNumber)].ToString() == "")
                    {
                        textBox21.Text = "";
                    }
                }
                if (this.flag_EstimateNumber == "true")
                {
                    TextBox item22 = (e.Item as GridFilteringItem)[this.cellvalue_EstimateNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_EstimateNumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_EstimateNumber)].ToString() == "")
                    {
                        item22.Text = "";
                    }
                }
                if (this.flag_JobNumber == "true")
                {
                    TextBox textBox22 = (e.Item as GridFilteringItem)[this.cellvalue_JobNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_JobNumber)] != null && this.Session[string.Concat("invoice_", this.cellvalue_JobNumber)].ToString() == "")
                    {
                        textBox22.Text = "";
                    }
                }
                if (this.flag_EventVenue == "true")
                {
                    TextBox item23 = (e.Item as GridFilteringItem)[this.cellValue_EventVenue].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellValue_EventVenue)] != null && this.Session[string.Concat("invoice_", this.cellValue_EventVenue)].ToString() == "")
                    {
                        item23.Text = "";
                    }
                }
                if (this.flag_Height == "true")
                {
                    TextBox textBox23 = (e.Item as GridFilteringItem)[this.cellvalue_Height].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_Height)] != null && this.Session[string.Concat("invoice_", this.cellvalue_Height)].ToString() == "")
                    {
                        textBox23.Text = "";
                    }
                }
                if (this.flag_Width == "true")
                {
                    TextBox item24 = (e.Item as GridFilteringItem)[this.cellvalue_Width].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_Width)] != null && this.Session[string.Concat("invoice_", this.cellvalue_Width)].ToString() == "")
                    {
                        item24.Text = "";
                    }
                }
                if (this.flag_ItemDescription == "true")
                {
                    TextBox textBox24 = (e.Item as GridFilteringItem)[this.cellvalue_ItemDescription].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemDescription)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemDescription)].ToString() == "")
                    {
                        textBox24.Text = "";
                    }
                }
                if (this.flag_ItemColour == "true")
                {
                    TextBox item25 = (e.Item as GridFilteringItem)[this.cellvalue_ItemColour].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemColour)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemColour)].ToString() == "")
                    {
                        item25.Text = "";
                    }
                }
                if (this.flag_ItemSize == "true")
                {
                    TextBox textBox25 = (e.Item as GridFilteringItem)[this.cellvalue_ItemSize].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemSize)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemSize)].ToString() == "")
                    {
                        textBox25.Text = "";
                    }
                }
                if (this.flag_ItemArtwork == "true")
                {
                    TextBox item26 = (e.Item as GridFilteringItem)[this.cellvalue_ItemArtwork].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemArtwork)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemArtwork)].ToString() == "")
                    {
                        item26.Text = "";
                    }
                }
                if (this.flag_ItemDelivery == "true")
                {
                    TextBox textBox26 = (e.Item as GridFilteringItem)[this.cellvalue_ItemDelivery].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemDelivery)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemDelivery)].ToString() == "")
                    {
                        textBox26.Text = "";
                    }
                }
                if (this.flag_ItemFinishing == "true")
                {
                    TextBox item27 = (e.Item as GridFilteringItem)[this.cellvalue_ItemFinishing].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemFinishing)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemFinishing)].ToString() == "")
                    {
                        item27.Text = "";
                    }
                }
                if (this.flag_ItemProofs == "true")
                {
                    TextBox textBox27 = (e.Item as GridFilteringItem)[this.cellvalue_ItemProofs].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemProofs)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemProofs)].ToString() == "")
                    {
                        textBox27.Text = "";
                    }
                }
                if (this.flag_ItemPacking == "true")
                {
                    TextBox item28 = (e.Item as GridFilteringItem)[this.cellvalue_ItemPacking].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemPacking)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemPacking)].ToString() == "")
                    {
                        item28.Text = "";
                    }
                }
                if (this.flag_ItemNotes == "true")
                {
                    TextBox textBox28 = (e.Item as GridFilteringItem)[this.cellvalue_ItemNotes].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemNotes)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemNotes)].ToString() == "")
                    {
                        textBox28.Text = "";
                    }
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    TextBox item29 = (e.Item as GridFilteringItem)[this.cellvalue_ItemTermsInstructions].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_ItemTermsInstructions)] != null && this.Session[string.Concat("invoice_", this.cellvalue_ItemTermsInstructions)].ToString() == "")
                    {
                        item29.Text = "";
                    }
                }
                if (this.flag_Department == "true")
                {
                    TextBox textBox29 = (e.Item as GridFilteringItem)[this.cellvalue_Department].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_Department)] != null && this.Session[string.Concat("invoice_", this.cellvalue_Department)].ToString() == "")
                    {
                        textBox29.Text = "";
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    TextBox item30 = (e.Item as GridFilteringItem)[this.cellvalue_AccountStatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_AccountStatus)] != null && this.Session[string.Concat("invoice_", this.cellvalue_AccountStatus)].ToString() == "")
                    {
                        item30.Text = "";
                    }
                }
                if (this.flag_PaymentNotes == "true")
                {
                    TextBox textBox30 = (e.Item as GridFilteringItem)[this.cellvalue_PaymentNotes].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_PaymentNotes)] != null && this.Session[string.Concat("invoice_", this.cellvalue_PaymentNotes)].ToString() == "")
                    {
                        textBox30.Text = "";
                    }
                }
                if (this.flag_JobName == "true")
                {
                    TextBox item31 = (e.Item as GridFilteringItem)[this.cellvalue_JobName].Controls[0] as TextBox;
                    if (this.Session[string.Concat("invoice_", this.cellvalue_JobName)] != null && this.Session[string.Concat("invoice_", this.cellvalue_JobName)].ToString() == "")
                    {
                        item31.Text = "";
                    }
                }
                if (this.flag_ItemAccCode == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemAccCode].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_EventName == "true")
                {
                    gridFilteringItem[this.cellvalue_EventName].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    gridFilteringItem[this.cellvalue_EventCodeNumber].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    gridFilteringItem[this.cellvalue_CampaignSignNumber].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMaterial == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMaterial].HorizontalAlign = HorizontalAlign.Left;
                }
            }
            //if (e.Item is GridGroupHeaderItem groupHeader)
            //{
            //    // Make the whole "Est. Status: Completed" text bold and 14px
            //    groupHeader.Font.Bold = true;
            //    groupHeader.Font.Size = FontUnit.Point(14);

            //}
            if (e.Item is GridPagerItem)
            {
                Label label = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                label.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.GridViewInvoice.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridViewInvoice.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        private void ApplyGridGrouping(RadGrid grid, string fieldName, string headerText)
        {
            grid.MasterTableView.GroupByExpressions.Clear();
            grid.GroupingEnabled = true;
            grid.MasterTableView.GroupsDefaultExpanded = true;

            GridGroupByExpression groupByExpr = new GridGroupByExpression();
            GridGroupByField groupByField = new GridGroupByField
            {
                FieldName = fieldName,
                HeaderText = headerText,
                HeaderValueSeparator = ": " // Optional formatting
            };

            groupByExpr.SelectFields.Add(groupByField);
            groupByExpr.GroupByFields.Add(groupByField);

            grid.MasterTableView.GroupByExpressions.Add(groupByExpr);
            grid.Rebind();
        }



        protected void ApplyGroupingByHeaderTextDynamic1(Telerik.Web.UI.RadGrid grid, string headerTextToGroupBy)
        {
            // Find the column with matching header text
            GridColumn groupColumn = grid.MasterTableView.Columns
                .OfType<GridColumn>()
                .FirstOrDefault(c => c.HeaderText == headerTextToGroupBy);

            if (groupColumn != null)
            {
                // Clear existing groupings
                grid.MasterTableView.GroupByExpressions.Clear();

                // Create new grouping expression
                GridGroupByExpression groupByExpr = new GridGroupByExpression();
                GridGroupByField groupByField = new GridGroupByField();

                groupByField.FieldName = groupColumn.UniqueName; // or groupColumn.DataField
                groupByField.HeaderText = headerTextToGroupBy;

                groupByExpr.SelectFields.Add(groupByField);
                groupByExpr.GroupByFields.Add(groupByField);

                // Apply grouping
                grid.MasterTableView.GroupByExpressions.Add(groupByExpr);

                // Rebind the grid
                grid.Rebind();
            }
            else
            {
                throw new ArgumentException($"No column found with header text: {headerTextToGroupBy}");
            }
        }

        protected void ApplyGroupingByFieldName(RadGrid grid, string fieldNameToGroupBy)
        {
            // Verify grid is ready
            if (grid.MasterTableView == null ||
                (grid.MasterTableView.Columns.Count == 0 && !grid.MasterTableView.AutoGenerateColumns))
            {
                return;
                //   throw new InvalidOperationException("Grid must have columns before applying grouping.");
            }

            // Find the column by field name (checking both DataField and UniqueName)
            GridColumn groupColumn = FindColumnByFieldName(grid.MasterTableView, fieldNameToGroupBy);

            if (groupColumn == null)
            {
                return;
                // throw new ArgumentException($"Column with field name '{fieldNameToGroupBy}' not found.");
            }

            // Get the header text (fallback to field name if no header text)
            string headerText = !string.IsNullOrEmpty(groupColumn.HeaderText)
                ? groupColumn.HeaderText
                : fieldNameToGroupBy;

            // Apply grouping
            ApplyGridGrouping(grid, fieldNameToGroupBy, headerText);
        }

        private GridColumn FindColumnByFieldName(GridTableView tableView, string fieldName)
        {
            // First try exact match on DataField (for bound columns)
            var column = tableView.Columns
                .OfType<GridColumn>()
                .FirstOrDefault(c =>
                    (c is GridBoundColumn boundCol &&
                     string.Equals(boundCol.DataField, fieldName, StringComparison.OrdinalIgnoreCase)) ||
                    string.Equals(c.UniqueName, fieldName, StringComparison.OrdinalIgnoreCase));

            // If not found and auto-generate columns is on, we might need to check the generated columns
            if (column == null && tableView.AutoGenerateColumns)
            {
                // For auto-generated columns, the UniqueName typically matches the field name
                column = tableView.Columns
                    .OfType<GridColumn>()
                    .FirstOrDefault(c => string.Equals(c.UniqueName, fieldName, StringComparison.OrdinalIgnoreCase));
            }

            return column;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lnkInvoiceedit.Text = this.objLanguage.GetLanguageConversion("Edit_View");
            this.GridViewInvoice.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.Invoice_Paid_Row_Select_Note = this.objLanguage.GetLanguageConversion("Invoice_Paid_Row_Select_Note");
            this.lblArchive.Text = this.objLanguage.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.lblRecordPayment.Text = this.objLanguage.GetLanguageConversion("Record_Payment");
            
            this.Export_Row_Select_Note = this.objLanguage.GetLanguageConversion("Export_Row_Select_Note");
            this.Unexport_Row_Select_Note = this.objLanguage.GetLanguageConversion("Unexport_Row_Select_Note");
            
            this.lblExported.Text = this.objLanguage.GetLanguageConversion("Set_Exported");
            this.lblUnExported.Text = this.objLanguage.GetLanguageConversion("Set_Unexported");
            this.lblUnArchive.Text = this.objLanguage.GetLanguageConversion("UnArchive_Selected");
            this.rdb_Delete_All.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_its_corresponding_Estimate_Job");
            this.rdb_Delete_Invoice.Text = this.objLanguage.GetLanguageConversion("Delete_Invoice_and_keep_Job_Estimate_live");
            this.divunarchive.Style.Add("display", "none");
            if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divDeleteSelected.Visible = true;
            }
            else
            {
                this.divDeleteSelected.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("invoices", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
            }
            this.objBase.ReturnRoles_Privileges_Tabs("invoices", "isview", "");
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
                this.hdnIDs.Value = "";
            }
            for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridViewInvoice.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "','", this.RadListBox1.Items[i].Text, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            global.pageName = "invoice";
            global.pgName = "";
            this.gloobj.setpagename("invoice");
            this.pg = "invoice";
            this.strImagepath = global.imagePath();
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            base.Title = this.objLanguage.convert(global.pageTitle("Invoices View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Invoice_View")));
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }


            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_DateTime_Before_View(now.ToString().ToString(), this.CompanyID, this.UserID, true);
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "invoices_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.Session["InvViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["InvViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewInvoice.PageSize = 50;
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView("invoice", this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
                    int num = 0;
                    while (num < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num].Value != this.ViewID.ToString())
                        {
                            num++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                    string str1 = string.Concat(this.pg, this.UserID, this.pg);
                    this.Session["search_Inv"] = null;
                    this.Session[str1] = null;
                }
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.pg);
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow row in this.dt.Rows)
                        {
                            this.defaultviewid = Convert.ToInt32(row["ViewID"].ToString());
                        }
                    }
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View);
                    int num1 = 0;
                    while (num1 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num1].Value != this.defaultviewid.ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num1].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }
                else
                {
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, this.defaultviewid);
                    int num2 = 0;
                    while (num2 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num2].Value != this.defaultviewid.ToString())
                        {
                            num2++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num2].Value.ToString());
                            break;
                        }
                    }
                    this.lblView.Text = this.ddl_View.SelectedItem.Text;
                }
                if (this.ddl_View.Text.Length == 0)
                {
                    this.ddl_View.Visible = false;
                }
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow dataRow in this.objComp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if (dataRow["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (dataRow["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLanguage.GetLanguageConversion("Address1");
                        }
                        else
                        {
                            this.hdnaddress1.Value = dataRow["addressvalue"].ToString();
                        }
                    }
                    if (dataRow["addresslkey"].ToString().ToLower() == "address2")
                    {
                        if (dataRow["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress2.Value = this.objLanguage.GetLanguageConversion("Address2");
                        }
                        else
                        {
                            this.hdnaddress2.Value = dataRow["addressvalue"].ToString();
                        }
                    }
                    if (dataRow["addresslkey"].ToString().ToLower() == "address3")
                    {
                        if (dataRow["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress3.Value = this.objLanguage.GetLanguageConversion("Address3");
                        }
                        else
                        {
                            this.hdnaddress3.Value = dataRow["addressvalue"].ToString();
                        }
                    }
                    if (dataRow["addresslkey"].ToString().ToLower() == "address4")
                    {
                        if (dataRow["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress4.Value = this.objLanguage.GetLanguageConversion("Address4");
                        }
                        else
                        {
                            this.hdnaddress4.Value = dataRow["addressvalue"].ToString();
                        }
                    }
                    if (dataRow["addresslkey"].ToString().ToLower() != "address5")
                    {
                        continue;
                    }
                    if (dataRow["addressvalue"].ToString() == "")
                    {
                        this.hdnaddress5.Value = this.objLanguage.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = dataRow["addressvalue"].ToString();
                    }
                }
            }
            int num3 = 0;
            num3 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            if (base.Request.Params["ViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["ViewID"]);
            }
            this.RecordsToDisplay = EstimatesBasePage.Views_RecordsToDisplay((long)this.defaultviewid);
            if (this.RecordsToDisplay.ToLower().ToString() == "live")
            {
                this.divunarchive.Style.Add("display", "none");
                this.divarchive.Style.Add("display", "block");
            }
            else if (this.RecordsToDisplay.ToLower().ToString() == "archive")
            {
                this.divunarchive.Style.Add("display", "block");
                this.divarchive.Style.Add("display", "none");
            }
            else if (this.RecordsToDisplay.ToLower().ToString() == "all")
            {
                this.divunarchive.Style.Add("display", "block");
                this.divarchive.Style.Add("display", "block");
            }
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, "invoice");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row1 in this.dt.Rows)
                {
                    this.defaultsortedby = row1["SortedBy"].ToString();
                    this.defaultsortdirection = row1["SortDirection"].ToString();
                    //83
                    //this.IsGrouping = String.IsNullOrEmpty(row1["isGrouping"].ToString()) ? false : Convert.ToBoolean(row1["isGrouping"].ToString());

                    //this.IsGrouping = (row1["ColumnNames"].ToString().Contains(row1["GroupByColumn"].ToString()) && !String.IsNullOrEmpty(row1["isGrouping"].ToString())) ? Convert.ToBoolean(row1["isGrouping"].ToString()) : false;
                    //this.GroupByColumn = row1["GroupByColumn"].ToString();
                    this.FilterDateType = row1["FilterDateType"].ToString();
                    this.FilterDateRange = row1["FilterDateRange"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                invoice_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    invoice_view.SortedBy = "InvoiceNumber";
                }
                else
                {
                    invoice_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    invoice_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    invoice_view.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                }
                if (this.InventoryManagement == "IM")
                {
                    this.ReduceStockType = this.comm.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                    this.ReduceStockTypeForCancelled = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
                }
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            invoice_view.ManageStockPermission = Convert.ToInt32(dataTable.Rows[0]["ProductStockManagement"]);
            if (invoice_view.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            try
            {
                if (base.Request.QueryString["custom"] != null)
                {
                    string empty = string.Empty;
                    empty = base.Request.QueryString["custom"].ToString().Trim();
                    if (empty != "")
                    {
                        empty = base.ReplaceSingleQuote(empty);
                        this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, "CustomerID", "desc", empty);
                    }
                }
            }
            catch
            {
            }
            if (!base.IsPostBack)
            {
                string str2 = "";
                this.GridStateLoad();
                if (this.Session["search_Inv"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_Inv"];
                    str2 = this.FilterFunction(item);
                }
                this.Session["InvViewID"] = this.defaultviewid;
                invoice_view.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridViewInvoice);
                this.GridViewInvoice.PageSize = invoice_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, invoice_view.SortedBy, invoice_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridViewInvoice.Rebind();
            }
            //if (!IsPostBack)
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridViewInvoice, this.GroupByColumn);
            //}
            if (!base.IsPostBack && base.Request.Params["su"] != null && base.Request.Params["su"].ToString().ToLower() == "payment")
            {
                this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Payment_details_updated_successfully"), "successfulMsg", this.plhMessage);
            }
            var column = this.GridViewInvoice.MasterTableView.Columns.FindByUniqueNameSafe("SinceStatusCount");
            if (column != null)
            {
                column.Visible = false;
            }
            var column2 = this.GridViewInvoice.MasterTableView.Columns.FindByUniqueNameSafe("SinceEmailCount");
            if (column2 != null)
            {
                column2.Visible = false;
            }
            var column3 = this.GridViewInvoice.MasterTableView.Columns.FindByUniqueNameSafe("isAnyEmailed");
            if (column3 != null)
            {
                column3.Visible = false;
            }
            try
            {
                this.GridViewInvoice.MasterTableView.GetColumn("InvoiceID").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("custid").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("estimateid").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("backOrder").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("estimateitemid").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("Cust_ID").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("InvAddress_ID").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("IsAccountOnHold").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("IsStockProduct").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("PaymentType").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("StatusColorCode").Visible = false;
                this.GridViewInvoice.MasterTableView.GetColumn("jobStatusColCode").Visible = false;
                
            }
            catch (Exception exception)
            {
            }
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            int num = Convert.ToInt16(this.RadListBox1.SelectedValue);
            string[] strArrays = this.hdnSelectedChkfrmGrid.Value.Split(new char[] { ',' });
            string empty = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str1 = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                empty = string.Concat(empty, str1.Split(chrArray)[0].ToString(), ',');
                string str2 = strArrays[i];
                char[] chrArray1 = new char[] { '\u005F' };
                str = string.Concat(str, str2.Split(chrArray1)[2].ToString(), ',');
            }
            this.RadListBox1.ClearSelection();
            string str3 = "Invoice";
            if (!(str != "") || num == 0 || !this.IsItemSelected)
            {
                if (empty != "" && num != 0)
                {
                    InvoiceBasePage.InvoiceOnCheck_Status_Update(this.CompanyID, empty, num, str3);
                    string[] strArrays1 = empty.Split(new char[] { ',' });
                    for (int j = 0; j < (int)strArrays1.Length - 1; j++)
                    {
                        string empty1 = string.Empty;
                        string empty2 = string.Empty;
                        long estimateID = 0;
                        DataTable dataTable = InvoiceBasePage.Invoice_Select_By_InvoiceID(this.CompanyID, (long)Convert.ToInt32(strArrays1[j].ToString()));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            empty1 = row["Status"].ToString();
                            empty2 = row["InvoiceNumber"].ToString();
                            estimateID = Convert.ToInt64(row["EstimateID"].ToString());
                        }
                        this.objnotes.Job_number = empty2;
                        this.objnotes.Status_name = empty1;
                        this.objnotes.ModuleName = "invoice";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvChangeStatus);
                        this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                        this.objnotes.ModuleID = (long)Convert.ToInt32(strArrays1[j].ToString());
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass = this.objJava;
                        DateTime now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objnotes.ItemID = this.ModuleID;
                        this.objN.NotesAdd(this.objnotes);
                        DataTable dt = EstimatesBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, estimateID);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["EstimateType"].ToString() == "C" || dr["EstimateType"].ToString() == "X")
                                {
                                    if (commonClass.CheckFTPEnable())
                                    {
                                        string filePath = string.Empty;
                                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                                        //var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                                        var product = dr["EstimateType"].ToString() == "X"
                                            ? settings.FirstOrDefault(s => s.SectionName == "OnlineOrder")
                                            : settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                                        int _statusID = product.StatusValue;
                                        if (_statusID == num)
                                        {
                                            long priceCatalogurID = Convert.ToInt64(dr["PriceCatalogueID"].ToString());
                                            //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                                            DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                                            if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                                            {
                                                //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                                                if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                                                {
                                                    object[] editableTemplatePath ;
                                                    if (dr["EstimateType"].ToString() == "X")
                                                    {
                                                        DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                        editableTemplatePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                                    }
                                                    else
                                                    {
                                                        editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                                    }
                                                    filePath = string.Concat(editableTemplatePath);
                                                }
                                                else
                                                {
                                                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                                }
                                                if (dr["EstimateType"].ToString() == "X")
                                                {
                                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                }
                                                else
                                                {
                                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "ProductEstimate", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                }
                                            }
                                        }
                                    }

                                }

                            }

                        }
                    }
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                    this.hdnSelectedChkfrmGrid.Value = "";
                    this.GridViewInvoice.Rebind();
                }
                return;
            }
            EstimatesBasePage.EstimateItemsOnCheck_Status_Update(this.CompanyID, str, num, str3.ToLower());
            string[] strArrays2 = str.Split(new char[] { ',' });
            for (int k = 0; k < (int)strArrays2.Length - 1; k++)
            {
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                DataTable dataTable1 = InvoiceBasePage.Invoice_Select_By_EstimateItemID_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays2[k].ToString()));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    empty3 = dataRow["InvoiceStatusName"].ToString();
                    empty4 = dataRow["InvoiceItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(dataRow["InvoiceID"].ToString());
                }
                this.objnotes.Invoice_number = empty4;
                this.objnotes.Status_name = empty3;
                this.objnotes.ModuleName = "invoice";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.InvChangeStatus);
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = (long)Convert.ToInt32(strArrays2[k].ToString());
                this.objN.NotesAdd(this.objnotes);
                string itemType = EstimatesBasePage.GetEstimateType_EstimateItemID((long)Convert.ToInt32(strArrays2[k].ToString()));
                if (itemType == "C" || itemType == "X")
                {
                    if (commonClass.CheckFTPEnable())
                    {
                        string filePath = string.Empty;
                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                        //var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                        var product = itemType == "X"
                                    ? settings.FirstOrDefault(s => s.SectionName == "OnlineOrder")
                                    : settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                        int _statusID = product.StatusValue;
                        if (_statusID == num)
                        {
                            long priceCatalogurID = EstimatesBasePage.GetPriceCatalogueIDByEstimateItemID((long)Convert.ToInt32(strArrays2[k].ToString()));
                            //DataTable dataTable6 = EstimatesBasePage.PrintReadyFile_Select(priceCatalogurID, this.CompanyID);
                            DataTable dataTable6 = commonClass.Get_ProductFileByType(priceCatalogurID, this.CompanyID);
                            if (dataTable6.Rows[0]["PrintReadyFile"].ToString() != "")
                            {
                                //filePath = commonClass.CopyPrintReadyFile(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID, dataTable6.Rows[0]["PrintReadyFile"].ToString(), "attachments");
                                if (dataTable6.Rows[0]["FileType"].ToString() == "Editable")
                                {
                                    object[] editableTemplatePath;
                                    if (itemType == "X")
                                    {
                                        DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(strArrays2[k].ToString()));
                                        editableTemplatePath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", _attachment.Rows[0]["FileName"].ToString() };
                                    }
                                    else
                                    {
                                        editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                    }
                                    //object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                    filePath = string.Concat(editableTemplatePath);
                                }
                                else
                                {
                                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                }
                                if (itemType == "X")
                                {
                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "OnlineOrder", Convert.ToInt64(strArrays2[k].ToString()));
                                }
                                else
                                {
                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "InvoiceStatus", "ProductEstimate", Convert.ToInt64(strArrays2[k].ToString()));
                                }
                            }
                        }
                    }

                }
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
            this.hdnSelectedChkfrmGrid.Value = "";
            this.GridViewInvoice.Rebind();
        }
    }
}

