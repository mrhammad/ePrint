using Microsoft.Practices.EnterpriseLibrary.Data;
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
using System.IO;
using System.Text;
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

namespace ePrint.Jobs
{
    public partial class jobs_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected HiddenField hdnaddress1;

        //protected HiddenField hdnaddress2;

        //protected HiddenField hdnaddress3;

        //protected HiddenField hdnaddress4;

        //protected HiddenField hdnaddress5;

        //protected UpdateProgress upProgress;

        //protected ImageButton ImageButton1;

        //protected RadioButton rdb_Delete_Job;

        //protected RadioButton rdb_Delete_All;

        //protected Label lbl_note;

        //protected Button btn_Delete_JOb;

        //protected Button btn_Delete_Cancel;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkJobsedit;

        //protected LinkButton btnclrFilters;

        //protected Label lblView;

        //protected HiddenField hdnAlphabet;

        //protected RadListBox RadListBox2;

        //protected Panel pnlChangeStatus;

        //protected Label lblArchive;

        //protected HtmlGenericControl divarchive;

        //protected Label lblUnArchive;

        //protected HtmlGenericControl divunarchive;

        //protected Label lblDelete;

        //protected HtmlGenericControl divDelete;

        //protected Label lblRecordPayment;

        //protected HtmlGenericControl divPaid;

        //protected Label lblProgressToInvoice;

        //protected HtmlGenericControl divProgToInv;

        //protected Label lblsendbulkemail;

        //protected HtmlGenericControl sendbulkemail;

        //protected HtmlTableCell td_sendbulkemail;

        //protected RadGrid GridView1;

        //protected LinkButton lnkJobDelete;

        //protected LinkButton lnkJobArchive;

        //protected LinkButton lnkJobUnArchive;

        //protected LinkButton lnkCopyJob;

        //protected LinkButton lnkPaidInvoice;

        //protected LinkButton lnkProgToInv;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hdnJobID;

        //protected HiddenField hdnEstimateID;

        //protected HiddenField hidGridCount;

        //protected HiddenField hdnEstimateIds;

        //protected HiddenField hdnInvoiceEstimateIds;

        //protected HiddenField hdnJobDelete;

        //protected HiddenField hdnSelectedChkfrmGrid;

        //protected UpdatePanel updtehidnfield;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        //protected HiddenField hdn_stockBack;

        //protected HiddenField hdn_stockBackwarehoue;

        //protected HiddenField editJobViewID;

        //protected HiddenField hdnIDs;

        //protected HiddenField hdn_ISInventoryStockBack;

        public string ServerName = ConnectionClass.ServerName;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass cmnClass = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath;

        public int totalrec;

        private string para = string.Empty;

        public string newdate = string.Empty;

        public int CompanyID;

        public int UserID;

        private string pg = string.Empty;

        public DataTable dt = new DataTable();

        private commonClass comm = new commonClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        public long JobNo;

        public int defaultviewid;

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string cellvalue_completiondate = string.Empty;

        public string cellvalue_jobval = string.Empty;

        public string cellvalue_jobvalExcGst = string.Empty;

        public string cellvalue_converteddate = string.Empty;

        public string cellvalue_deliverydate = string.Empty;
        public string cellvalue_actualdeliverydate = string.Empty;
        public string cellvalue_estimateddeliverydate = string.Empty;


        public string flag_completiondate = string.Empty;

        public string flag_jobval = string.Empty;

        public string flag_jobvalExcGst = string.Empty;

        public string flag_converteddate = string.Empty;

        public string flag_deliverydate = string.Empty;
        public string flag_actualdeliverydate = string.Empty;
        public string flag_estimateddeliverydate = string.Empty;


        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;

        public string cellvalue_quantity = string.Empty;

        public string flag_quantity = string.Empty;

        public string cellvalue_FromWebStore = string.Empty;

        public string cellvalue_OrderID = string.Empty;

        public string flag_isproformainvoice = string.Empty;

        public string cellvalue_IsProformaInvoice = string.Empty;

        public string cellvalue_contactname = string.Empty;

        public string flag_contactname = string.Empty;

        public string cellvalue_jobtitle = string.Empty;

        public string flag_jobtitle = string.Empty;

        public string cellvalue_salesperson = string.Empty;

        public string flag_salesperson = string.Empty;

        public string cellvalue_estimator = string.Empty;

        public string flag_estimator = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_status = string.Empty;

        public string cellvalue_jobstatus = string.Empty;

        public string flag_status = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string flag_jobstatus = string.Empty;

        public string cellvalue_estimateno = string.Empty;

        public string flag_estimateno = string.Empty;

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_customerordernumber = string.Empty;

        public string flag_customerordernumber = string.Empty;

        public string cellvalue_isfromwebstore = string.Empty;

        public string flag_isfromwebstore = string.Empty;

        public string cellvalue_costcentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_jobno = string.Empty;

        public string flag_jobno = string.Empty;

        public string cellvalue_PONumber = string.Empty;   /////Modification By Bilal warehouse stage 1

        public string flag_PONumber = string.Empty;       /////Modification By Bilal

        public string cellvalue_DelNumber = string.Empty;   /////Modification By Bilal

        public string flag_DelNumber = string.Empty;       /////Modification By Bilal

        public string cellvalue_POStage = string.Empty;   /////Modification By Bilal

        public string flag_POStage = string.Empty;       /////Modification By Bilal

        public string cellvalue_StockStage = string.Empty;   /////Modification By Bilal

        public string flag_StockStage = string.Empty;       /////Modification By Bilal

        public string cellvalue_JobType = string.Empty;

        public string flag_JobType = string.Empty;

        public string cellvalue_Department = string.Empty;

        public string flag_Department = string.Empty;

        public string cellvalue_CompamyEmail = string.Empty;

        public string flag_CompamyEmail = string.Empty;

        public string cellvalue_ContactEmail = string.Empty;

        public string flag_ContactEmail = string.Empty;

        public string cellvalue_ContactPhone = string.Empty;

        public string flag_ContactPhone = string.Empty;

        public string cellvalue_JobDate = string.Empty;

        public string flag_JobDate = string.Empty;

        public string cellvalue_Estimator = string.Empty;

        public string flag_Estimator = string.Empty;

        public string cellvalue_EstimateNumber = string.Empty;

        public string flag_EstimateNumber = string.Empty;

        public string cellvalue_ArtworkDate = string.Empty;

        public string flag_ArtworkDate = string.Empty;

        public string cellvalue_ApprovalDate = string.Empty;

        public string flag_ApprovalDate = string.Empty;

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

        public string cellvalue_productiondate = string.Empty;

        public string flag_productiondate = string.Empty;

        public string flag_ItemStatus = string.Empty;

        public string cellvalue_ItemStatus = string.Empty;

        public string flag_ProofStatus = string.Empty;

        public string cellvalue_ProofStatus = string.Empty;

        public string flag_InventoryName = string.Empty;

        public string cellvalue_InventoryName = string.Empty;

        public string flag_InventoryFriendlyName = string.Empty;

        public string cellvalue_InventoryFriendlyName = string.Empty;

        public string flag_InventoryDescription = string.Empty;

        public string cellvalue_InventoryDescription = string.Empty;

        public string flag_InventoryWeight = string.Empty;

        public string cellvalue_InventoryWeight = string.Empty;

        public string flag_ItemTitle = string.Empty;

        public string cellvalue_ItemTitle = string.Empty;

        public string flag_comments = string.Empty;

        public string cellvalue_comments = string.Empty;

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

        public string flag_EventVenue = string.Empty;

        public string cellValue_EventVenue = string.Empty;

        public string flag_Height = string.Empty;

        public string cellvalue_Height = string.Empty;

        public string flag_Width = string.Empty;

        public string cellvalue_Width = string.Empty;

        public string flag_ItemDescription = string.Empty;

        public string cellvalue_ItemDescription = string.Empty;

        public string flag_ItemColour = string.Empty;

        public string cellvalue_ItemColour = string.Empty;

        public string flag_ItemSize = string.Empty;

        public string cellvalue_ItemSize = string.Empty;

        public string flag_ItemArtwork = string.Empty;

        public string cellvalue_ItemArtwork = string.Empty;

        public string flag_ItemDelivery = string.Empty;

        public string cellvalue_ItemDelivery = string.Empty;

        public string flag_DeliveryAddressLabel = string.Empty;

        public string cellvalue_DeliveryAddressLabel = string.Empty;

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

        public string flag_MainItemSupplier = string.Empty;

        public string cellvalue_MainItemSupplier = string.Empty;

        public string cellvalue_PressName = string.Empty;

        public string flag_PressName = string.Empty;

        public string flag_ProofComment = string.Empty;

        public string cellvalue_ProofComment = string.Empty;

        public string flag_DefaultTemplate = string.Empty;

        public string cellvalue_DefaultTemplate = string.Empty;

        public string flag_ChooseTemplate = string.Empty;

        public string cellvalue_ChooseTemplate = string.Empty;

        public string flag_DownloadTemplate = string.Empty;

        public string cellvalue_DownloadTemplate = string.Empty;


        public string flag_FTPStatus = string.Empty;

        public string cellvalue_FTPStatus = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        public static string WhereCondition;

        public static string sortdirection;

        public static string SortedBy;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public static int PageSize;

        private DataSet ds = new DataSet();

        public string ViewCondition = string.Empty;

        public string ViewDays = string.Empty;

        public string ViewColor = string.Empty;

        public string option = string.Empty;

        private string JobViewColor = string.Empty;

        private DataTable dtColor = new DataTable();

        private DataTable dtArtwork = new DataTable();

        private DataTable dtColorApply = new DataTable();

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string ReduceStockType = string.Empty;

        public string ReduceStockTypeForCancelled = string.Empty;

        public string InventoryManagement = ConnectionClass.InventoryManagement;

        private SummaryClass SummaryClassObj = new SummaryClass();

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public string Archive_Row_Selection_Alert = string.Empty;

        public string Delete_Row_Selection_Alert = string.Empty;

        public string UnArchive_Row_Selection_Alert = string.Empty;

        public string Invoice_Paid_Row_Select_Note = string.Empty;

        public string Progress_To_Invoice_Selection_Alert = string.Empty;

        public bool IsItemSelected;

        public string RecordsToDisplay = "";

        private static bool IsItem_Selected;

        public string JobCountForSameJobid = string.Empty;

        public int SameJobSelectedCount;

        public string JobIdnotequals = string.Empty;

        public string DateTypeSelected = string.Empty;

        private string Jobnumber = string.Empty;

        private string JobItem_number = string.Empty;

        private long ModuleID;

        private Notes objN = new Notes();

        private notesclass objnotes = new notesclass();

        public string cellvalue_proofdate = string.Empty;

        public string flag_proofdate = string.Empty;

        public string SR_JobStatusID = string.Empty;

        public string Replenish_JobStatusID = string.Empty;

        public string SR_WhenStockReduced = string.Empty;

        public string Please_Check_Atleast_One_Row = string.Empty;

        public bool EnableBulkEmailSend = ConnectionClass.EnableBulkEmailSend;
        //public bool IsGrouping;

        //public string GroupByColumn = string.Empty;
        public string FilterDateType = string.Empty;
        public string FilterDateRange = string.Empty;

        public string cellvalue_priority = string.Empty;

        public string flag_priority = string.Empty;

        private string EditableTemplatePath = EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString();

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


        public string flag_Archive = string.Empty;

        public string cellvalue_Archive = string.Empty;

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

        static jobs_view()
        {
            jobs_view.WhereCondition = string.Empty;
            jobs_view.sortdirection = string.Empty;
            jobs_view.SortedBy = string.Empty;
            jobs_view.PageSize = 50;
            jobs_view.ManageStockPermission = 0;
        }

        public jobs_view()
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
                    this.GridView1.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "completiondate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate" || dt.Columns[i].ColumnName.ToLower() == "converteddate" || dt.Columns[i].ColumnName.ToLower() == "jobdate" || dt.Columns[i].ColumnName.ToLower() == "artworkdate" || dt.Columns[i].ColumnName.ToLower() == "approvaldate" || dt.Columns[i].ColumnName.ToLower() == "productiondate" || dt.Columns[i].ColumnName.ToLower() == "proofdate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    if (dt.Columns[i].ColumnName.ToLower() == "isproformainvoice")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.String");
                    }
                    if (dt.Columns[i].ColumnName.ToLower() == "estimatevalue" || dt.Columns[i].ColumnName.ToLower() == "estimatevalue_excgst")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Decimal");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    // if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    // {
                    //    this.GridView1.MasterTableView.Columns.Remove(gridBoundColumn);

                    //   GridTemplateColumn commentColumn = new GridTemplateColumn();
                    //  commentColumn.UniqueName = dt.Columns[i].ColumnName;
                    //commentColumn.HeaderText = "Comments";
                    //commentColumn.DataField = "Comments";
                    //commentColumn.SortExpression = "Comments";
                    //commentColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    //commentColumn.AllowFiltering = true;
                    //commentColumn.ItemTemplate = new CommentsTemplate();
                    //gv.MasterTableView.Columns.Add(commentColumn);
                    //}

                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "address1")
                    {
                        this.GridView1.Columns[i].HeaderText = this.hdnaddress1.Value;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address2")
                    {
                        this.GridView1.Columns[i].HeaderText = this.hdnaddress2.Value;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address3")
                    {
                        this.GridView1.Columns[i].HeaderText = this.hdnaddress3.Value;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address4")
                    {
                        this.GridView1.Columns[i].HeaderText = this.hdnaddress4.Value;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address5")
                    {
                        this.GridView1.Columns[i].HeaderText = this.hdnaddress5.Value;
                    }
                    //Add custom description fields 1-5 to jobs
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdescription1")
                    {
                        if (!string.IsNullOrEmpty(Session["CustomDescription1"] as string))
                            this.GridView1.Columns[i].HeaderText = Session["CustomDescription1"].ToString();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdescription2")
                    {
                        if (!string.IsNullOrEmpty(Session["CustomDescription2"] as string))
                            this.GridView1.Columns[i].HeaderText = Session["CustomDescription2"].ToString();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdescription3")
                    {
                        if (!string.IsNullOrEmpty(Session["CustomDescription3"] as string))
                            this.GridView1.Columns[i].HeaderText = Session["CustomDescription3"].ToString();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdescription4")
                    {
                        if (!string.IsNullOrEmpty(Session["CustomDescription4"] as string))
                            this.GridView1.Columns[i].HeaderText = Session["CustomDescription4"].ToString();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdescription5")
                    {
                        if (!string.IsNullOrEmpty(Session["CustomDescription5"] as string))
                            this.GridView1.Columns[i].HeaderText = Session["CustomDescription5"].ToString();
                    }
                }
                for (int j = 0; j < this.GridView1.Columns.Count; j++)
                {
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridView1.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "jobnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_No");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(30);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(30);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_jobno = "true";
                        this.cellvalue_jobno = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "carrierinformation")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Carrier_Information");
                    }
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "consigneeurl")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Consignee_url");
                    }
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "consignmentnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = "Consignment Number";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ponumber")   //////Modification by Bilal
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("PO_Number");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_PONumber = "true";
                        this.cellvalue_PONumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "delnumber")   //////Modification by Bilal
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Del_Number");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_DelNumber = "true";
                        this.cellvalue_DelNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "postage")   //////Modification by Bilal
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("PO_Stage");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_POStage = "true";
                        this.cellvalue_POStage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "stockstage")   //////Modification by Bilal
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Stock_Stage");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_StockStage = "true";
                        this.cellvalue_StockStage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        //this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_No");
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number_Order_Number");
                        this.flag_estimateno = "true";
                        this.cellvalue_estimateno = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "priority")
                    {
                        this.GridView1.Columns[j].HeaderText = "Priority";
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(100);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(100);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridView1.Columns[j].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_priority = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_priority = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_person");
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Title");
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(100);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "jobstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Status");
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_jobstatus = "true";
                        this.cellvalue_jobstatus = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "completiondate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Completion_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_completiondate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_completiondate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_deliverydate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "actualdeliverydate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Actual_Delivery_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_actualdeliverydate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_actualdeliverydate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimateddeliverydate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimated_Delivery_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_estimateddeliverydate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimateddeliverydate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "productiondate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Production_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_productiondate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_productiondate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "artworkdate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Artwork_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ArtworkDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ArtworkDate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "approvaldate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Approval_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ApprovalDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ApprovalDate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate1 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate2 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate2 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate3 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate3 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate4 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate4 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customdate5")
                    {
                        this.GridView1.Columns[j].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CustomDate5 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomDate5 = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Job_value"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_jobval = "true";
                        this.cellvalue_jobval = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "converteddate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Converted_On");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_converteddate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_converteddate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Status Days";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceStatusUpdate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_SinceStatusUpdate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.GridView1.Columns[j].HeaderText = "Email Days";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_SinceEmailed = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_SinceEmailed = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Quantity");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_quantity = "true";
                        this.cellvalue_quantity = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isfromwebstore")
                    {
                        this.GridView1.Columns[j].HeaderText = "IsFromWebStore";
                        this.cellvalue_FromWebStore = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].Visible = false;
                        this.flag_isfromwebstore = "true";
                        this.cellvalue_isfromwebstore = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderid")
                    {
                        this.GridView1.Columns[j].HeaderText = "OrderID";
                        this.cellvalue_OrderID = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isproformainvoice")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Raised");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_IsProformaInvoice = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_isproformainvoice = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_CustomerType = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CustomerType = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address1")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Address1 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address2")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address2 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Address2 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address3")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address3 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Address3 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address4")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address4 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Address4 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "address5")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_Address5 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Address5 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proformainvoice")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paid")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Job_Value_Exc_Tax"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_jobvalExcGst = "true";
                        this.cellvalue_jobvalExcGst = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Type");
                        this.flag_JobType = "true";
                        this.cellvalue_JobType = this.GridView1.Columns[j].SortExpression.ToLower();
                    }


                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Default Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Choose Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ChooseTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Download Default Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DownloadTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridView1.Columns[j].HeaderText = "Archive";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }



                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "backorder")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower().Trim() == "isaccountonhold")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower().Trim() == "isstockproduct")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Comments");
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "mainitemsupplier")
                    {
                        this.flag_MainItemSupplier = "true";
                        this.cellvalue_MainItemSupplier = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Main_Item_Supplier");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventname")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Name");
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Code_Number");
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Sign_Number");
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                        this.flag_ItemMaterial = "true";
                        this.cellvalue_ItemMaterial = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "eventvenue")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Venue");
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_View");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliveryaddresslabel")
                    {
                        this.GridView1.Columns[j].HeaderText = "Delivery Address Label";//this.objLanguage.GetLanguageConversion("Delivery_Address_Label");
                        this.flag_DeliveryAddressLabel = "true";
                        this.cellvalue_DeliveryAddressLabel = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofdate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_proofdate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_proofdate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofcomments")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Comments");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ProofComment = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ProofComment = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "pressname")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Press_Name");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.flag_PressName = "true";
                        this.cellvalue_PressName = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "department")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "jobdate")
                    {
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Date");
                        this.flag_JobDate = "true";
                        this.cellvalue_JobDate = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number");
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofstatus")
                    {
                        this.flag_ProofStatus = "true";
                        this.cellvalue_ProofStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Status");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "inventoryfriendlyname")
                    {
                        this.flag_InventoryFriendlyName = "true";
                        this.cellvalue_InventoryFriendlyName = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Friendly_Name");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "inventoryname")
                    {
                        this.flag_InventoryName = "true";
                        this.cellvalue_InventoryName = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Name");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "inventorydescription")
                    {
                        this.flag_InventoryDescription = "true";
                        this.cellvalue_InventoryDescription = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Description");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "inventorybasisweight")
                    {
                        this.flag_InventoryWeight = "true";
                        this.cellvalue_InventoryWeight = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Inventory_Basis_Weight");
                    }
                }
            }

            for (int j = 0; j < this.GridView1.Columns.Count; j++)
            {
             

                if (this.GridView1.Columns[j].UniqueName.ToLower() == "defaulttemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Default Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DefaultTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_DefaultTemplate = "true";
                }

                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "choosetemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Choose Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_ChooseTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_ChooseTemplate = "true";
                }

                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "downloadtemplate")
                {
                    this.GridView1.Columns[j].HeaderText = "Download Default Template";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_DownloadTemplate = this.GridView1.Columns[j].UniqueName.ToLower();
                    this.flag_DownloadTemplate = "true";
                }

                else if (this.GridView1.Columns[j].UniqueName.ToLower() == "archive")
                {
                    this.GridView1.Columns[j].HeaderText = "Archive";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
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
                    string estimateId = DataBinder.Eval(item.DataItem, "EstimateID").ToString();
                    hlEditComment.Attributes["onclick"] = $"openCommentPopup('{estimateId}', '{hlEditComment.Text}'); return false;";
                };
                container.Controls.Add(hlEditComment);
            }
        }

        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string newComment = hiddenCommentText.Value;
            int commentId = int.Parse(hiddenCommentId.Value);

            UpdateCommentInDatabase(commentId, newComment);

            GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, this.para);
            this.GridView1.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "Jobs/jobs_view.aspx"));
        }


        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            EstimateBasePage.Estimate_Comments_Update(commentId, newComment);
        }

        public void bindRadlistStatus()
        {
            this.CompanyID = CheckIntegerNull(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "job");
            this.RadListBox2.DataSource = dataTable;
            this.RadListBox2.DataTextField = "StatusTitle";
            this.RadListBox2.DataValueField = "StatusID";
            this.RadListBox2.DataBind();
        }

        public void btnEditViewJob_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../jobs/customviewjob.aspx?type=edit&id=", this.editJobViewID.Value, "&cid=", this.CompanyID };
            response.Redirect(string.Concat(value));
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("job_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("job_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            jobs_view.WhereCondition = "";
            this.Session["search_job"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
            this.GridView1.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = CheckIntegerNull(this.ddl_View.SelectedValue);
            num = CheckIntegerNull(this.ddl_View.SelectedIndex);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "Jobs/jobs_view.aspx?viewid=", num1, "&index=", num };
            response.Redirect(string.Concat(objArray));
        }

        public string FilterFunction(DataTable dtsearch)
        {
            int num = 0;
            string empty = string.Empty;
            string str = string.Empty;
            int num1 = 0;
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                num1 = CheckIntegerNull(row["Roundoff"].ToString());
            }
            this.Session["search_job"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && jobs_view.WhereCondition != "")
                {
                    jobs_view.WhereCondition = string.Concat(jobs_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "completiondate" || dataRow["ColumnName"].ToString().ToLower() == "deliverydate" || dataRow["ColumnName"].ToString().ToLower() == "converteddate" || dataRow["ColumnName"].ToString().ToLower() == "jobdate" || dataRow["ColumnName"].ToString().ToLower() == "productiondate" || dataRow["ColumnName"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                {
                    str = this.comm.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                {
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                    object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                    empty = string.Concat(objArray);
                    if (str == "")
                    {
                        str = "0";
                    }
                }
                else if (dataRow["ColumnName"].ToString().ToLower() != "isproformainvoice")
                {
                    empty = dataRow["ColumnName"].ToString();
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                }
                else
                {
                    empty = dataRow["ColumnName"].ToString();
                    if (dataRow["FilterText"].ToString().ToLower().Trim() != "no")
                    {
                        str = (dataRow["FilterText"].ToString().ToLower().Trim() != "yes" ? "01" : "1");
                    }
                    else
                    {
                        str = "0";
                    }
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                //             if (< PrivateImplementationDetails >{ 77BC9223 - F070 - 4C97 - AE00 - 8F1AD58399A8}.$$method0x6000018 - 1 == null)
                //{

                //             < PrivateImplementationDetails >{ 77BC9223 - F070 - 4C97 - AE00 - 8F1AD58399A8}.$$method0x6000018 - 1 = new Dictionary<string, int>(10)
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
                //             if (!< PrivateImplementationDetails >{ 77BC9223 - F070 - 4C97 - AE00 - 8F1AD58399A8}.$$method0x6000018 - 1.TryGetValue(str1, out num))
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
                            string whereCondition = jobs_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            jobs_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = jobs_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            jobs_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "completiondate" || dataRow["ColumnName"].ToString().ToLower() == "deliverydate" || dataRow["ColumnName"].ToString().ToLower() == "converteddate" || dataRow["ColumnName"].ToString().ToLower() == "jobdate" || dataRow["ColumnName"].ToString().ToLower() == "productiondate" || dataRow["ColumnName"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = jobs_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string str2 = jobs_view.WhereCondition;
                                string[] strArrays3 = new string[] { str2, " ", empty, " like '%", str, "%'" };
                                jobs_view.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        }
                    case 3:
                        {
                            string whereCondition3 = jobs_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " not like '%", str, "%'" };
                            jobs_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity" || dataRow["ColumnName"].ToString().ToLower() == "isproformainvoice")
                            {
                                string str3 = jobs_view.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                            else
                            {
                                string whereCondition4 = jobs_view.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " = '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity" || dataRow["ColumnName"].ToString().ToLower() == "isproformainvoice")
                            {
                                string str4 = jobs_view.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " != ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                            else
                            {
                                string whereCondition5 = jobs_view.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " != '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string str5 = jobs_view.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " > ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                            else
                            {
                                string whereCondition6 = jobs_view.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " > '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string str6 = jobs_view.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " >= ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                            else
                            {
                                string whereCondition7 = jobs_view.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " >= '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string str7 = jobs_view.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " < ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                            else
                            {
                                string whereCondition8 = jobs_view.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " < '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity")
                            {
                                string str8 = jobs_view.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " <= ", str };
                                jobs_view.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                            else
                            {
                                string whereCondition9 = jobs_view.WhereCondition;
                                string[] strArrays16 = new string[] { whereCondition9, " ", empty, " <= '", str, "'" };
                                jobs_view.WhereCondition = string.Concat(strArrays16);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return jobs_view.WhereCondition;
        }

        public void GetDatetimeValue_ViewColor(int CompanyID)
        {
            this.DateTypeSelected = EstimatesBasePage.settings_jobViewColor_SelectedDateType(CompanyID);
            foreach (DataRow row in this.dtColorApply.Rows)
            {
                this.DateTypeSelected = row["DateTypeSelected"].ToString();
            }
            if (this.DateTypeSelected == "Delivery")
            {
                this.DateTypeSelected = "";
            }
            this.dtColor = this.objCreateView.Settings_JobViewColor_Select(CompanyID, this.DateTypeSelected);
        }

        [WebMethod]
        public static string GetItemCount(long JobId)
        {
            return InvoiceBasePage.Job_Items_Select(JobId).Rows.Count.ToString();
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
            empty = _viewClass.ReturnFinalQueryForNewCustomView(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;
            empty = empty.Replace("EstItemCoun", "0 as EstItemCoun");
            sqlCommand.Parameters.AddWithValue("@strSQL", empty);
            (new SqlDataAdapter(sqlCommand)).Fill(this.ds);
            DataTable item = this.ds.Tables[0];
            for (int i = 0; i < item.Columns.Count; i++)
            {
                item.Columns[i].ReadOnly = false;
            }
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("EstimatedDeliveryDate"))
                    {
                        row["EstimatedDeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["EstimatedDeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ActualDeliveryDate"))
                    {
                        row["ActualDeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CompletionDate"))
                    {
                        row["CompletionDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ConvertedDate"))
                    {
                        row["ConvertedDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ConvertedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ArtworkDate"))
                    {
                        row["ArtworkDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ApprovalDate"))
                    {
                        row["ApprovalDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProductionDate"))
                    {
                        row["ProductionDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProofDate"))
                    {
                        row["ProofDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("JobDate"))
                    {
                        row["JobDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["JobDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate1"))
                    {
                        row["CustomDate1"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate2"))
                    {
                        row["CustomDate2"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate3"))
                    {
                        row["CustomDate3"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate4"))
                    {
                        row["CustomDate4"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomDate5"))
                    {
                        row["CustomDate5"] = this.cmnClass.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("InventoryFriendlyName"))
                    {
                        string inventoryFriendlyName = row["InventoryFriendlyName"].ToString();
                        string result = inventoryFriendlyName.Replace("$", "<br>");
                        result = $"<span style='white-space: nowrap; overflow: hidden;'>{result}</span>";
                        row["InventoryFriendlyName"] = result;
                        
                    }
                    if (row.Table.Columns.Contains("InventoryName"))
                    {
                        string inventoryName = row["InventoryName"].ToString();
                        string result1 = inventoryName.Replace("$", "<br>");
                        result1 = $"<span style='white-space: nowrap; overflow: hidden;'>{result1}</span>";
                        row["InventoryName"] = result1;

                    }
                    if (row.Table.Columns.Contains("InventoryDescription"))
                    {
                        string inventoryDescription = row["InventoryDescription"].ToString();
                        string descriptionResult = inventoryDescription.Replace("$", "<br>");
                        string[] splitString = descriptionResult.Split(new string[] { "<br>" }, StringSplitOptions.None);
                        StringBuilder finalDescription = new StringBuilder();

                        foreach (string segment in splitString)
                        {
                            int segmentLength = 40;

                            if (segment.Length > segmentLength)
                            {
                                string[] segments = SplitByLength(segment, segmentLength);
                                foreach (var smallSegment in segments)
                                {
                                    finalDescription.Append(smallSegment).Append("<br>");
                                }
                            }
                            else
                            {
                                finalDescription.Append(segment).Append("<br>");
                            }
                        }
                        string finalDesc = finalDescription.ToString().TrimEnd("<br>".ToCharArray());

                        row["InventoryDescription"] = finalDesc;


                    }

                    if (row.Table.Columns.Contains("InventoryBasisWeight"))
                    {
                        string inventoryBasisWeight = row["InventoryBasisWeight"].ToString();
                        string inventoryBasisWeightResult = inventoryBasisWeight.Replace("$", "<br>");
                        string output = FormatInventoryBasisWeight(inventoryBasisWeightResult);
                        row["InventoryBasisWeight"] = output;
                        
                    }

                    if (row.Table.Columns.Contains("ProofComments"))
                    {
                        bool commentFlag = false;
                        string comment = row["ProofComments"].ToString();
                        if (!string.IsNullOrEmpty(comment))
                        {
                            string[] items = comment.Split(',');
                            foreach (string _comment in items)
                            {
                                if (!string.IsNullOrEmpty(_comment))
                                {
                                    commentFlag = true;
                                }
                            }
                        }
                        if (commentFlag)
                        {
                            row["ProofComments"] = "Provided";
                        }
                        else
                        {
                            row["ProofComments"] = "";
                        }
                    }
                    if (!item.Columns.Contains("IsProformaInvoice"))
                    {
                        continue;
                    }
                    row["IsProformaInvoice"].ToString();
                    if (row["IsProformaInvoice"].ToString() != "1")
                    {
                        row["IsProformaInvoice"] = "No";
                    }
                    else
                    {
                        row["IsProformaInvoice"] = "Yes";
                    }
                }
            }
            _commonClass.closeConnection();
            this.GridView1.DataSource = this.ds;
            if (this.ds.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(this.ds.Tables[0], this.GridView1);
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(this.ds.Tables[0], this.GridView1);
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = true;
                this.GridView1.VirtualItemCount = CheckIntegerNull(this.ds.Tables[1].Rows[0][0].ToString());
            }
            this.GridView1.Style.Add("width", "100%");
        }
        private string[] SplitByLength(string input, int maxLength)
        {
            List<string> segments = new List<string>();
            string[] words = input.Split(' ');

            StringBuilder currentSegment = new StringBuilder();
            foreach (string word in words)
            {
                if (currentSegment.Length + word.Length > maxLength)
                {
                    segments.Add(currentSegment.ToString().Trim());
                    currentSegment.Clear();
                }
                currentSegment.Append(word).Append(" ");
            }

            if (currentSegment.Length > 0)
            {
                segments.Add(currentSegment.ToString().Trim());
            }

            return segments.ToArray();
        }
        private string FormatInventoryBasisWeight(string input)
        {
            if (input.Contains("<br>"))
            {
                string[] parts = input.Split(new string[] { "<br>" }, StringSplitOptions.None);
                string formattedParts = string.Empty;

                foreach (var p in parts)
                {
                    if (p != "-")
                    {
                        string formattedPart = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(p), 0, "", false, false, true);
                        formattedParts += formattedPart + "<br>";
                    }
                }

                // Remove the last appended <br>
                if (formattedParts.EndsWith("<br>"))
                {
                    formattedParts = formattedParts.Substring(0, formattedParts.Length - 4);
                }

                return formattedParts;
            }
            else
            {
                if (input != "-")
                {
                    return this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(input), 0, "", false, false, true);
                }
                return input;
            }
        }
        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }

        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                jobs_view.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    CheckIntegerNull(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "estimatevalue" || commandArgument.Second.ToString().ToLower() == "quantity" || commandArgument.Second.ToString().ToLower() == "estimatevalue_excgst"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Please Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (this.Session["search_job"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_job"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_job"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    this.dtsearch.Rows.Add(second);
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }
                else
                {
                    this.dtsearch.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(objArray);
                    }
                    this.ClearPerticularFilterExpression(commandArgument.First.ToString(), commandArgument.Second.ToString(), item.Text);
                }

                this.Session["search_job"] = this.dtsearch;
                for (int i = 0; i < this.dtsearch.Rows.Count; i++)
                {


                    DataRow dr = this.dtsearch.Rows[i];
                    if (dr["FilterText"].ToString() == "")
                        dr.Delete();
                }
                dtsearch.AcceptChanges();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

                jobs_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
                this.GridView1.DataBind();
                //this.GridView1.Rebind();
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridView1.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
        }

        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            jobs_view.SortedBy = e.SortExpression;
            jobs_view.sortdirection = e.NewSortOrder.ToString();
            if (jobs_view.sortdirection.ToLower() == "ascending")
            {
                jobs_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (jobs_view.sortdirection.ToLower() != "descending")
            {
                jobs_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                jobs_view.sortdirection = "DESC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, CheckIntegerNull(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, jobs_view.sortdirection, jobs_view.WhereCondition);
        }

        protected void lnkCopyJob_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnJobID.Value.Split(new char[] { ',' });
            string[] strArrays1 = this.hdnEstimateID.Value.Split(new char[] { ',' });
            if (strArrays[0] != "" && strArrays1[0] != "")
            {
                long num = CheckIntegerNull(strArrays[0]);
                long num1 = CheckIntegerNull(strArrays1[0]);
                bool flag = false;
                long num2 = EstimateBasePage.Copy_Estimate(this.CompanyID, num1, "job", ref flag);
                JobBasePage.copy_job(this.CompanyID, num, num2, ConnectionClass.IsHandy);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
                this.GridView1.Rebind();
            }
        }

        protected void lnkJobArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnJobID.Value.Split(new char[] { ',' });


            //start
            Int32 countZero = 0;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)CheckIntegerNull(strArray.Split(chrArray)[!this.IsItemSelected ? 0 : 2].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this job and it can not be archived. Please contact support and request assistance" : "There is an error in one of the job(s) and can not be archived. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is an error in this job and it can not be archived. Please contact support and request assistance')", true);

                return;
            }

            //end

            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    DataTable dataTable = JobBasePage.Job_Select_By_JobID(companyID, (long)CheckIntegerNull(str.Split(chrArray)[0].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Jobnumber = row["JobNumber"].ToString();
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        this.ModuleID = CheckIntegerNull(str1.Split(chrArray1)[0].ToString());
                    }
                    this.objnotes.Job_number = this.Jobnumber;
                    this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobArchivedandProgtoInv);
                    int num = this.CompanyID;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    JobBasePage.Job_Archive(num, (long)CheckIntegerNull(str2.Split(chrArray2)[0].ToString()));
                }
                else
                {
                    int companyID1 = this.CompanyID;
                    string str3 = strArrays[i];
                    char[] chrArray3 = new char[] { '\u005F' };
                    DataTable dataTable1 = JobBasePage.Job_Select_By_EstimateItemID(companyID1, (long)CheckIntegerNull(str3.Split(chrArray3)[2].ToString().ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.JobItem_number = dataRow["JobItemNumber"].ToString();
                        this.ModuleID = CheckIntegerNull(dataRow["JobID"].ToString());
                    }
                    this.objnotes.Item_number = this.JobItem_number;
                    this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobItemArchived);
                    notesclass _notesclass = this.objnotes;
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    _notesclass.ItemID = (long)CheckIntegerNull(str4.Split(chrArray4)[2].ToString());
                    int num1 = this.CompanyID;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Archive(num1, (long)CheckIntegerNull(str5.Split(chrArray5)[2].ToString()), "job");
                }
                this.objnotes.ModuleName = "Job";
                this.UserID = CheckIntegerNull(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.cmnClass;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
                SummaryClass summaryClassObj = this.SummaryClassObj;
                string str6 = strArrays[i];
                char[] chrArray6 = new char[] { '\u005F' };
                summaryClassObj.Call_Inventory_Adjustment("archive", (long)CheckIntegerNull(str6.Split(chrArray6)[1].ToString()), this.CompanyID, (long)0, this.UserID);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkJobDelete_OnClick(object sender, EventArgs e)
        {
            Int32 countZero = 0;
            string[] strArrays = this.hdnJobID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)CheckIntegerNull(strArray.Split(chrArray)[!this.IsItemSelected ? 0 : 2].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this job and it can not be deleted. Please contact support and request assistance" : "There is an error in one of the job(s) and can not be deleted. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);

                return;
            }
            bool flag = true;

            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (this.rdb_Delete_All.Checked)
                {
                    flag = false;
                }
                if (this.hdn_ISInventoryStockBack.Value.ToLower() == "yes" || this.ReduceStockType.ToString().ToLower() == "a")
                {
                    SummaryClass summaryClassObj = this.SummaryClassObj;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    long num = (long)CheckIntegerNull(str.Split(chrArray)[1].ToString());
                    int companyID = this.CompanyID;
                    string str1 = strArrays[i];
                    char[] chrArray1 = new char[] { '\u005F' };
                    long num1 = (long)CheckIntegerNull(str1.Split(chrArray1)[2].ToString());
                    int userID = this.UserID;
                    bool isItemSelected = this.IsItemSelected;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    summaryClassObj.Call_Inventory_Adjustment_Job("cancelled-jobdelete", num, companyID, num1, userID, isItemSelected, CheckIntegerNull(str2.Split(chrArray2)[0].ToString()), (long)0);
                }
                if (this.hdn_stockBackwarehoue.Value.ToLower() == "yes" && this.StockCancellationType.ToString().ToLower() == "p" || this.StockCancellationType.ToString().ToLower() == "a")
                {
                    SummaryClass summaryClass = this.SummaryClassObj;
                    string str3 = strArrays[i];
                    char[] chrArray3 = new char[] { '\u005F' };
                    long num2 = (long)CheckIntegerNull(str3.Split(chrArray3)[1].ToString());
                    int companyID1 = this.CompanyID;
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    long num3 = (long)CheckIntegerNull(str4.Split(chrArray4)[2].ToString());
                    int userID1 = this.UserID;
                    bool isItemSelected1 = this.IsItemSelected;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    summaryClass.Call_Inventory_Adjustment_Job("cancelled-stock-delete", num2, companyID1, num3, userID1, isItemSelected1, CheckIntegerNull(str5.Split(chrArray5)[0].ToString()), (long)0);
                }
                if (!this.IsItemSelected)
                {
                    int companyID2 = this.CompanyID;
                    string str6 = strArrays[i];
                    char[] chrArray6 = new char[] { '\u005F' };
                    JobBasePage.Jobs_Delete(companyID2, (long)CheckIntegerNull(str6.Split(chrArray6)[0].ToString()), flag);
                }
                else
                {
                    int companyID3 = this.CompanyID;
                    string str7 = strArrays[i];
                    char[] chrArray7 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_Delete(companyID3, (long)CheckIntegerNull(str7.Split(chrArray7)[2].ToString()), "job", flag);
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkJobUnArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnJobID.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.rdb_Delete_All.Checked)
                {
                    this.hdnJobDelete.Value = "0";
                }
                else
                {
                    this.hdnJobDelete.Value = "1";
                }
                if (!this.IsItemSelected)
                {
                    string empty = string.Empty;
                    int companyID = this.CompanyID;
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    DataTable dataTable = JobBasePage.Job_Select_By_JobID(companyID, (long)CheckIntegerNull(str.Split(chrArray)[0].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        empty = row["JobNumber"].ToString();
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        this.ModuleID = CheckIntegerNull(str1.Split(chrArray1)[0].ToString());
                    }
                    this.objnotes.Job_number = empty;
                    this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobUnArchived);
                    int num = this.CompanyID;
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    JobBasePage.Job_UnArchive(num, (long)CheckIntegerNull(str2.Split(chrArray2)[0].ToString()));
                }
                else
                {
                    int companyID1 = this.CompanyID;
                    string str3 = strArrays[i];
                    char[] chrArray3 = new char[] { '\u005F' };
                    DataTable dataTable1 = JobBasePage.Job_Select_By_EstimateItemID(companyID1, (long)CheckIntegerNull(str3.Split(chrArray3)[2].ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.JobItem_number = dataRow["JobItemNumber"].ToString();
                        this.ModuleID = CheckIntegerNull(dataRow["JobID"].ToString());
                    }
                    this.objnotes.Item_number = this.JobItem_number;
                    this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobItemUnArchived);
                    notesclass _notesclass = this.objnotes;
                    string str4 = strArrays[i];
                    char[] chrArray4 = new char[] { '\u005F' };
                    _notesclass.ItemID = (long)CheckIntegerNull(str4.Split(chrArray4)[2].ToString());
                    int num1 = this.CompanyID;
                    string str5 = strArrays[i];
                    char[] chrArray5 = new char[] { '\u005F' };
                    EstimatesBasePage.EstimateItem_UnArchive(num1, (long)CheckIntegerNull(str5.Split(chrArray5)[2].ToString()), "job");
                }
                this.objnotes.ModuleName = "Job";
                this.UserID = CheckIntegerNull(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass = this.cmnClass;
                DateTime now = DateTime.Now;
                _notesclass1.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Job_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, jobs_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkPaidInvoice_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnInvoiceEstimateIds.Value.Split(new char[] { ',' });
            this.hdnInvoiceEstimateIds.Value = "";
            string[] str = new string[] { "" };
            int num = 0;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (JobBasePage.EstimateID_Select_By_JobID(this.CompanyID, CheckIntegerNull(strArrays[i].ToString())) == (long)0)
                {
                    str[num] = strArrays[i].ToString();
                    num++;
                }
                else
                {
                    HiddenField hiddenField = this.hdnInvoiceEstimateIds;
                    hiddenField.Value = string.Concat(hiddenField.Value, strArrays[i].ToString());
                }
            }
            if (this.hdnInvoiceEstimateIds.Value == "")
            {
                base.Message_Display("For your selected job invoice is not created", "successfulMsg", this.plhMessage);
                return;
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), " ", "javascript:OpenPaidPopup();", true);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                string lower = filterMenu.Items[i].Text.ToLower();
                string str = lower;
                if (lower != null)
                {
                    switch (str)
                    {
                        case "nofilter":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                                break;
                            }
                        case "contains":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("Contains");
                                break;
                            }
                        case "doesnotcontain":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                                break;
                            }
                        case "startswith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                                break;
                            }
                        case "endswith":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                                break;
                            }
                        case "equalto":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                                break;
                            }
                        case "greaterthan":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                                break;
                            }
                        case "lessthan":
                            {
                                filterMenu.Items[i].Text = this.objLanguage.GetLanguageConversion("LessThan");
                                break;
                            }
                    }
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
            //foreach (GridItem item in GridView1.MasterTableView.Items)
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

        protected void OnRowDataBound_GridView1(object sender, GridItemEventArgs e)
        {
            string[] languageConversion;
            DateTime now;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridView1.Columns.Count; i++)
                {
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.flag_jobno = "true";
                        this.cellvalue_jobno = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "ponumber") //////Modification By Bilal warehouse stage 1
                    {
                        this.flag_PONumber = "true";
                        this.cellvalue_PONumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "delnumber") //////Modification By Bilal
                    {
                        this.flag_DelNumber = "true";
                        this.cellvalue_DelNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "postage") //////Modification By Bilal
                    {
                        this.flag_POStage = "true";
                        this.cellvalue_POStage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "stockstage") //////Modification By Bilal
                    {
                        this.flag_StockStage = "true";
                        this.cellvalue_StockStage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "priority")
                    {
                        this.cellvalue_priority = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_priority = "true";
                    }
                    if (this.GridView1.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.GridView1.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "converteddate")
                    {
                        this.cellvalue_converteddate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_converteddate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.flag_jobval = "true";
                        this.cellvalue_jobval = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.cellvalue_completiondate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_completiondate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.cellvalue_deliverydate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate1")
                    {
                        this.flag_CustomDate1 = "true";
                        this.cellvalue_CustomDate1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate2")
                    {
                        this.flag_CustomDate2 = "true";
                        this.cellvalue_CustomDate2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate3")
                    {
                        this.flag_CustomDate3 = "true";
                        this.cellvalue_CustomDate3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate4")
                    {
                        this.flag_CustomDate4 = "true";
                        this.cellvalue_CustomDate4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customdate5")
                    {
                        this.flag_CustomDate5 = "true";
                        this.cellvalue_CustomDate5 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "actualdeliverydate")
                    {
                        this.cellvalue_actualdeliverydate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_actualdeliverydate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimateddeliverydate")
                    {
                        this.cellvalue_estimateddeliverydate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimateddeliverydate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "productiondate")
                    {
                        this.cellvalue_productiondate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_productiondate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "artworkdate")
                    {
                        this.cellvalue_ArtworkDate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ArtworkDate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "approvaldate")
                    {
                        this.cellvalue_ApprovalDate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ApprovalDate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isproformainvoice")
                    {
                        this.cellvalue_IsProformaInvoice = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_isproformainvoice = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_jobvalExcGst = "true";
                        this.cellvalue_jobvalExcGst = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "quantity")
                    {
                        this.flag_quantity = "true";
                        this.cellvalue_quantity = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "attentionid")
                    {
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "jobstatus")
                    {
                        this.flag_jobstatus = "true";
                        this.cellvalue_jobstatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "sincestatusupdate")
                    {
                        this.flag_SinceStatusUpdate = "true";
                        this.cellvalue_SinceStatusUpdate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "sinceemailed")
                    {
                        this.flag_SinceEmailed = "true";
                        this.cellvalue_SinceEmailed = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_estimateno = "true";
                        this.cellvalue_estimateno = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customertype")
                    {
                        this.cellvalue_CustomerType = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_CustomerType = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address1")
                    {
                        this.flag_Address1 = "true";
                        this.cellvalue_Address1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address2")
                    {
                        this.flag_Address2 = "true";
                        this.cellvalue_Address2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address3")
                    {
                        this.flag_Address3 = "true";
                        this.cellvalue_Address3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address4")
                    {
                        this.flag_Address4 = "true";
                        this.cellvalue_Address4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "address5")
                    {
                        this.flag_Address5 = "true";
                        this.cellvalue_Address5 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        if (CheckBooleanNull(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = true;
                            this.flag_costcentre = "true";
                            this.cellvalue_costcentre = this.GridView1.Columns[i].SortExpression.ToLower();
                        }
                        else
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = false;
                        }
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.GridView1.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Job_Type");
                        this.flag_JobType = "true";
                        this.cellvalue_JobType = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "backorder")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower().Trim() == "isaccountonhold")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower().Trim() == "isstockproduct")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower().Trim() == "salespersonid")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.flag_comments = "true";
                        this.cellvalue_comments = this.GridView1.Columns[i].SortExpression.ToLower();
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "choosetemplate")
                    {
                        this.cellvalue_ChooseTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ChooseTemplate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "downloadtemplate")
                    {
                        this.cellvalue_DownloadTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_DownloadTemplate = "true";
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "mainitemsupplier")
                    {
                        this.flag_MainItemSupplier = "true";
                        this.cellvalue_MainItemSupplier = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "eventvenue")
                    {
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "deliveryaddresslabel")
                    {
                        this.flag_DeliveryAddressLabel = "true";
                        this.cellvalue_DeliveryAddressLabel = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "department")
                    {
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "jobdate")
                    {
                        this.flag_JobDate = "true";
                        this.cellvalue_JobDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofdate")
                    {
                        this.cellvalue_proofdate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_proofdate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofcomments")
                    {
                        this.cellvalue_ProofComment = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ProofComment = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "pressname")
                    {
                        this.flag_PressName = "true";
                        this.cellvalue_PressName = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofstatus")
                    {
                        this.flag_ProofStatus = "true";
                        this.cellvalue_ProofStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ftp")
                    {
                        this.flag_FTPStatus = "true";
                        this.cellvalue_FTPStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                string _estimateID = ((DataRowView)e.Item.DataItem)[1].ToString();
                string _estimateItemID = ((DataRowView)e.Item.DataItem)[2].ToString();
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plhInv");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plh_Error");
                PlaceHolder placeHolder3 = (PlaceHolder)e.Item.FindControl("plhBackOrder");
                PlaceHolder placeHolder4 = (PlaceHolder)e.Item.FindControl("plhHasReplenishItem");
                PlaceHolder placeHolder5 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                string str = string.Empty;
                string empty1 = string.Empty;
                str = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                string str1 = string.Empty;
                string languageConversion1 = string.Empty;
                PlaceHolder placeHolder6 = (PlaceHolder)e.Item.FindControl("plh_stockproduct");
                string empty2 = string.Empty;
                string languageConversion2 = string.Empty;
                str1 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion1 = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                empty2 = string.Concat(this.strImagepath, "Stock-Icon.jpg");
                languageConversion2 = this.objLanguage.GetLanguageConversion("Stock_Product");
                string str2 = string.Empty;
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

                // ---------- Start 

                // string Error_Count = getErrorCount(CheckIntegerNull(item["EstimateID"].Text), CheckIntegerNull(item["JobID"].Text));



                // ---------- End (Code commented by Amin instructed by Hammad sb)

                //if (CheckIntegerNull(Error_Count) <= 0)
                //{
                //    placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                //}
                //else
                //{
                //    placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                //}
                if (item["EstItemCoun"].Text != "0" || str2 != "")
                {
                    ControlCollection controls = placeHolder1.Controls;
                    languageConversion = new string[] { "<img src='", str, "' title='", empty1, "' style='cursor:pointer;' class='viewicon_margin' />" };
                    controls.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                if (CheckInteger16Null(item["BackOrder"].Text) != 1)
                {
                    placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                else
                {
                    ControlCollection controlCollections = placeHolder3.Controls;
                    languageConversion = new string[] { "<img src='", this.strImagepath, "BackOrder.png' border='0' title='", this.objLanguage.GetLanguageConversion("Back_Order"), "' class='viewicon_margin'/>" };
                    controlCollections.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (CheckInteger16Null(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls1 = placeHolder5.Controls;
                    languageConversion = new string[] { "<img src='", str1, "'  title='", languageConversion1, "' class='viewicon_margin'  />" };
                    controls1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (CheckInteger16Null(item["IsStockProduct"].Text) == 1)
                {
                    ControlCollection controlCollections1 = placeHolder6.Controls;
                    languageConversion = new string[] { "<img src='", empty2, "'  title='", languageConversion2, "' class='viewicon_margin'  />" };
                    controlCollections1.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                string empty3 = string.Empty;
                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgProformaInvoice");
                string str3 = string.Empty;
                string languageConversion3 = string.Empty;
                string empty4 = string.Empty;
                if (!this.IsItemSelected)
                {
                    if (item["ProformaInvoice"].Text == "2")
                    {
                        str3 = string.Concat(this.strImagepath, "invoiced-paid.PNG");
                        languageConversion3 = this.objLanguage.GetLanguageConversion("One_Or_More_Items_Invoiced_And_Paid");
                    }
                    else if (item["ProformaInvoice"].Text != "1")
                    {
                        str3 = string.Concat(this.strImagepath, "1t.gif");
                        languageConversion3 = "";
                    }
                    else
                    {
                        str3 = string.Concat(this.strImagepath, "invoiced.PNG");
                        languageConversion3 = this.objLanguage.GetLanguageConversion("One_Or_More_Items_Invoiced");
                    }
                    empty4 = (JobBasePage.JobItemNotConvertedToInvoice_Select(CheckIntegerNull(((DataRowView)e.Item.DataItem)[0])) != 0 ? "false" : "true");
                    ControlCollection controls2 = placeHolder.Controls;
                    languageConversion = new string[] { "<img src='", str3, "' border='0' title='", languageConversion3, "' class='viewicon_margin'/>" };
                    controls2.Add(new LiteralControl(string.Concat(languageConversion)));
                    ControlCollection controlCollections2 = placeHolder.Controls;
                    languageConversion = new string[] { "<input id='hdnProgToInvChk_", ((DataRowView)e.Item.DataItem)[0].ToString(), "_", ((DataRowView)e.Item.DataItem)[1].ToString(), "_", ((DataRowView)e.Item.DataItem)[2].ToString(), "' value='", empty4, "' type='hidden' />" };
                    controlCollections2.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                else
                {
                    if (item["ProformaInvoice"].Text == "2")
                    {
                        str3 = string.Concat(this.strImagepath, "invoiced-paid.PNG");
                        languageConversion3 = this.objLanguage.GetLanguageConversion("Invoice_Raised_And_Paid");
                        empty4 = "true";
                    }
                    else if (item["ProformaInvoice"].Text != "1")
                    {
                        str3 = string.Concat(this.strImagepath, "1t.gif");
                        languageConversion3 = "";
                        empty4 = "false";
                    }
                    else
                    {
                        str3 = string.Concat(this.strImagepath, "invoiced.PNG");
                        languageConversion3 = this.objLanguage.GetLanguageConversion("Invoice_Raised");
                        empty4 = "true";
                    }
                    if (item["IsFromWebStore"].Text.Trim().ToLower() != "yes")
                    {
                        ControlCollection controls3 = placeHolder.Controls;
                        languageConversion = new string[] { "<a href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&InvID=", item["InvoiceID"].Text, "><img src='", str3, "' border='0' title='", languageConversion3, "' class='viewicon_margin'/></a>" };
                        controls3.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    else
                    {
                        ControlCollection controlCollections3 = placeHolder.Controls;
                        languageConversion = new string[] { "<a href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", item["InvoiceID"].Text, "><img src='", str3, "' border='0' title='", languageConversion3, "' class='viewicon_margin'/></a>" };
                        controlCollections3.Add(new LiteralControl(string.Concat(languageConversion)));
                    }
                    ControlCollection controls4 = placeHolder.Controls;
                    languageConversion = new string[] { "<input archive='hdnProgToInvChk_", ((DataRowView)e.Item.DataItem)[0].ToString(), "_", ((DataRowView)e.Item.DataItem)[1].ToString(), "_", ((DataRowView)e.Item.DataItem)[2].ToString(), "' value='", empty4, "' type='hidden' />" };
                    controls4.Add(new LiteralControl(string.Concat(languageConversion)));
                }
                if (item["IsFromWebStore"].Text.Trim().ToLower() != "yes")
                {
                    empty = string.Concat("job_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell = item["jobnumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        tableCell.Text = string.Concat(languageConversion);
                    }
                    else
                    {
                        TableCell item1 = item["jobnumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", ((DataRowView)e.Item.DataItem)[2].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        item1.Text = string.Concat(languageConversion);
                    }
                }
                else
                {
                    languageConversion = new string[] { "job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString() };
                    empty = string.Concat(languageConversion);
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell1 = item["jobnumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        tableCell1.Text = string.Concat(languageConversion);
                    }
                    else
                    {
                        TableCell item2 = item["jobnumber"];
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", ((DataRowView)e.Item.DataItem)[2].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        item2.Text = string.Concat(languageConversion);
                    }
                }
                if (CheckInteger16Null(item["HasReplenishItem"].Text) != 1)
                {
                    placeHolder4.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                else
                {
                    placeHolder4.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "replenishicon.png' border='0' title='Replenish Item' class='viewicon_margin' />")));
                }
                if (this.flag_jobval == "true")
                {
                    item[this.cellvalue_jobval].Attributes.Add("align", "right");
                    item[this.cellvalue_jobval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobval].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_jobval];
                    if (tableCell2.Text == "&nbsp;")
                        tableCell2.Text = "0";
                    languageConversion = new string[] { "<div style='min-width: 100px ;width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_jobval].Text.ToString()), 0, "", false, false, true), "</div>" };
                    tableCell2.Text = string.Concat(languageConversion);

                }
                if (this.flag_quantity == "true")
                {
                    item[this.cellvalue_quantity].Attributes.Add("align", "right");
                    item[this.cellvalue_quantity].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_quantity].Style.Add("cursor", "pointer");
                    TableCell item3 = item[this.cellvalue_quantity];
                    languageConversion = new string[] { "<div style='min-width: 100px ;width:", this.type1, " ;overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_quantity].Text.ToString(), "</div>" };
                    item3.Text = string.Concat(languageConversion);
                }
                if (this.flag_jobvalExcGst == "true")
                {
                    item[this.cellvalue_jobvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_jobvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobvalExcGst].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_jobvalExcGst];
                    languageConversion = new string[] { "<div style='min-width: 100px ;width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_jobvalExcGst].Text.ToString()), 0, "", false, false, true), "</div>" };
                    tableCell3.Text = string.Concat(languageConversion);
                }
                if (this.flag_converteddate == "true")
                {
                    item[this.cellvalue_converteddate].Attributes.Add("align", "center");
                    item[this.cellvalue_converteddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_converteddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_completiondate == "true")
                {
                    //if (item["IsFromWebStore"].Text == "yes")
                    //{
                    //    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    //    item[this.cellvalue_completiondate].Text = "-";
                    //}
                    //else
                    //{
                        item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                        item[this.cellvalue_completiondate].Attributes.Add("class", "hyperlinkStyle");
                        item[this.cellvalue_completiondate].Attributes.Add("onclick",
                        string.Concat("javascript:OnCompletionDateClick('",
                        item[this.cellvalue_completiondate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                        item[this.cellvalue_completiondate].Style.Add("cursor", "pointer");
                    //}
                    
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
             
                if (this.flag_ArtworkDate == "true")
                {
                    item[this.cellvalue_ArtworkDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ArtworkDate].Attributes.Add("class", "hyperlinkStyle");

                    //item[this.cellvalue_ArtworkDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ArtworkDate].Attributes.Add("onclick",
                    string.Concat("javascript:OnArtworkDateClick('",
                    item[this.cellvalue_ArtworkDate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_ArtworkDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ApprovalDate == "true")
                {
                    item[this.cellvalue_ApprovalDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ApprovalDate].Attributes.Add("class", "hyperlinkStyle");

                    //item[this.cellvalue_ApprovalDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ApprovalDate].Attributes.Add("onclick",
                    string.Concat("javascript:OnApprovalDateClick('",
                    item[this.cellvalue_ApprovalDate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_ApprovalDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate1 == "true")
                {
                   
                   
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick",
                    string.Concat("javascript:OnCustomdate1Click('",
                    item[this.cellvalue_CustomDate1].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick",
                    string.Concat("javascript:OnCustomdate2Click('",
                    item[this.cellvalue_CustomDate2].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick",
                    string.Concat("javascript:OnCustomdate3Click('",
                    item[this.cellvalue_CustomDate3].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick",
                    string.Concat("javascript:OnCustomdate4Click('",
                    item[this.cellvalue_CustomDate4].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick",
                    string.Concat("javascript:OnCustomdate5Click('",
                    item[this.cellvalue_CustomDate5].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomerType == "true")
                {
                    item[this.cellvalue_CustomerType].Attributes.Add("align", "left");
                    if (item[this.cellvalue_CustomerType].Text.Length > 30)
                    {
                        item[this.cellvalue_CustomerType].ToolTip = item[this.cellvalue_CustomerType].Text;
                        item[this.cellvalue_CustomerType].Text = string.Concat(item[this.cellvalue_CustomerType].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_CustomerType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CustomerType].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address1 == "true")
                {
                    if (item[this.cellvalue_Address1].Text.Length > 30)
                    {
                        item[this.cellvalue_Address1].ToolTip = item[this.cellvalue_Address1].Text;
                        item[this.cellvalue_Address1].Text = string.Concat(item[this.cellvalue_Address1].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address1].Attributes.Add("align", "left");
                    item[this.cellvalue_Address1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address1].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address2 == "true")
                {
                    if (item[this.cellvalue_Address2].Text.Length > 30)
                    {
                        item[this.cellvalue_Address2].ToolTip = item[this.cellvalue_Address2].Text;
                        item[this.cellvalue_Address2].Text = string.Concat(item[this.cellvalue_Address2].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address2].Attributes.Add("align", "left");
                    item[this.cellvalue_Address2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address2].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address3 == "true")
                {
                    if (item[this.cellvalue_Address3].Text.Length > 30)
                    {
                        item[this.cellvalue_Address3].ToolTip = item[this.cellvalue_Address3].Text;
                        item[this.cellvalue_Address3].Text = string.Concat(item[this.cellvalue_Address3].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address3].Attributes.Add("align", "left");
                    item[this.cellvalue_Address3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address3].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address4 == "true")
                {
                    if (item[this.cellvalue_Address4].Text.Length > 30)
                    {
                        item[this.cellvalue_Address4].ToolTip = item[this.cellvalue_Address4].Text;
                        item[this.cellvalue_Address4].Text = string.Concat(item[this.cellvalue_Address4].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address4].Attributes.Add("align", "left");
                    item[this.cellvalue_Address4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address4].Style.Add("cursor", "pointer");
                }
                if (this.flag_Address5 == "true")
                {
                    if (item[this.cellvalue_Address5].Text.Length > 30)
                    {
                        item[this.cellvalue_Address5].ToolTip = item[this.cellvalue_Address5].Text;
                        item[this.cellvalue_Address5].Text = string.Concat(item[this.cellvalue_Address5].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_Address5].Attributes.Add("align", "left");
                    item[this.cellvalue_Address5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Address5].Style.Add("cursor", "pointer");
                }


                if (this.flag_DefaultTemplate == "true" )//|| !string.IsNullOrEmpty(this.cellvalue_DefaultTemplate))
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string jobid = item["JobID"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}jobs/templates_view1.aspx?sectionid={customerid}&sectionname=Job&type=Customer&page=Job&EstID={estimateId}&jID={jobid}&ordid={orderid}&GenPdf=all&customtype=preview";

                    //   string targetUrl = $"https://testlive.eprintsoftware.com/estimates/templates_view1.aspx?sectionid=17420&sectionname=Estimate&type=Customer&page=Estimate&EstID=28280&GenPdf=all";
                    //string targetUrl = $"https://yourwebsite.com/details?estimateId={estimateId}";

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
                        AlternateText = "Job Preview",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_DefaultTemplate].Controls.Add(link);
                }

                if (this.flag_ChooseTemplate == "true")// || !string.IsNullOrEmpty(this.cellvalue_ChooseTemplate)) // Using flag_ChooseTemplate
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string jobid = item["JobID"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}jobs/templates_view1.aspx?sectionid={customerid}&sectionname=Job&type=Customer&page=Job&EstID={estimateId}&jID={jobid}&ordid={orderid}&GenPdf=all&customtype=choosetemp";

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
                        AlternateText = "View Job",
                        Width = Unit.Pixel(16),
                        Height = Unit.Pixel(16)
                    };

                    // Add image inside hyperlink
                    link.Controls.Add(img);

                    // Add hyperlink to the cell
                    item[this.cellvalue_ChooseTemplate].Controls.Add(link);
                }

                if (this.flag_DownloadTemplate == "true")// || !string.IsNullOrEmpty(this.cellvalue_DownloadTemplate)) // Using flag_DownloadTemplate
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid = item["custid"].Text;
                    string jobid = item["JobID"].Text;
                    string orderid = item["orderid"].Text;
                    string targetUrl = $"{this.strSitepath}jobs/templates_view1.aspx?sectionid={customerid}&sectionname=Job&type=Customer&page=Job&EstID={estimateId}&jID={jobid}&ordid={orderid}&GenPdf=all&customtype=download";

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

                    string jobId = item["JobID"].Text;
                    string estimateId = item["EstimateID"].Text;
                    string estimateItemId = item["EstimateItemID"].Text;
                    string custId = item["Cust_ID"].Text;
                    string invAddressId = item["InvAddress_ID"].Text;
                    string isFromWebStore = item["IsFromWebStore"].Text;
                    string paymentType = item["PaymentType"].Text;
                    this.cellvalue_Archive = "archive"; 


                    // Combine all values into a single string separated by underscores
                    string combinedValue = string.Join("_", new[]
                                    {
                    jobId,
                    estimateId,
                    estimateItemId,
                    custId,
                    invAddressId,
                    invAddressId,
                    isFromWebStore,
                    paymentType
                     });

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



                if (this.flag_SinceEmailed == "true")
                {
                    item[this.cellvalue_SinceEmailed].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceEmailed"].Text) >= Convert.ToInt32(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceEmailed"].Text != "0")
                            item[this.cellvalue_SinceEmailed].Style.Add("background-color", "#E64557"); // Add this line   #DA5101

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


                if (this.flag_actualdeliverydate == "true")
                {
                    item[this.cellvalue_actualdeliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_actualdeliverydate].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_actualdeliverydate].Attributes.Add("onclick",
                    string.Concat("javascript:OnActualDeliveryDateClick('",
                    item[this.cellvalue_actualdeliverydate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"/*lcs(this,'" + this.DateFormat +"');"*/));
                    item[this.cellvalue_actualdeliverydate].Style.Add("cursor", "pointer");

                }

                if (this.flag_estimateddeliverydate == "true")
                {
                    item[this.cellvalue_estimateddeliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_estimateddeliverydate].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_estimateddeliverydate].Attributes.Add("onclick",
                    string.Concat("javascript:OnEstimatedDeliveryDateClick('",
                    item[this.cellvalue_estimateddeliverydate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"/*lcs(this,'" + this.DateFormat +"');"*/));
                    item[this.cellvalue_estimateddeliverydate].Style.Add("cursor", "pointer");

                }

                if (this.flag_completiondate == "true")
                {
                    //if (item["IsFromWebStore"].Text == "yes")
                    //{
                    //    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    //    item[this.cellvalue_completiondate].Text = "-";
                    //}
                    //else
                    //{
                    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_completiondate].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_completiondate].Attributes.Add("onclick",
                    string.Concat("javascript:OnCompletionDateClick('",
                    item[this.cellvalue_completiondate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_completiondate].Style.Add("cursor", "pointer");
                    //}

                    if (this.DateTypeSelected == "" || this.DateTypeSelected == "Completion")
                    {
                        try
                        {
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            int days = 0;
                            TimeSpan timeSpan = new TimeSpan();
                            str4 = DateTime.Now.ToString();
                            item[this.cellvalue_completiondate].Text = (item[this.cellvalue_completiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_completiondate].Text, this.CompanyID, this.UserID, false));

                            commonClass _commonClass = this.cmnClass;
                            now = DateTime.Now;
                            _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CheckIntegerNull(this.CompanyID), CheckIntegerNull(this.UserID), true);
                            now = this.cmnClass.Eprint_return_ActualDate_Before_View(str4, this.CompanyID, this.UserID, true);
                            DateTime dateTime = CheckDateTimeNull(now.ToShortDateString());
                            now = CheckDateTimeNull(item[this.cellvalue_completiondate].Text);
                            DateTime dateTime1 = CheckDateTimeNull(now.ToShortDateString());
                            timeSpan = dateTime1 - dateTime;
                            days = timeSpan.Days;
                            if (days > 0)
                            {
                                DataRow[] dataRowArray2 = this.dtColor.Select(string.Concat("Days>= ", days));
                                if ((int)dataRowArray2.Length > 0)
                                {
                                    empty5 = dataRowArray2[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days == 0)
                            {
                                DataRow[] dataRowArray3 = this.dtColor.Select("[optionType]= 'On same day'");
                                if ((int)dataRowArray3.Length > 0)
                                {
                                    empty5 = dataRowArray3[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days < 0)
                            {
                                DataRow[] dataRowArray4 = this.dtColor.Select("[optionType]= 'elapsed'");
                                if ((int)dataRowArray4.Length > 0)
                                {
                                    empty5 = dataRowArray4[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            //deliveryDate = string.IsNullOrEmpty(deliveryDate) == true ? "Set Delivery Date" : deliveryDate;
                            //item[this.cellvalue_deliverydate].Text = deliveryDate;
                            item[this.cellvalue_completiondate].Text = (item[this.cellvalue_completiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_completiondate].Text, this.CompanyID, this.UserID, false));
                        }
                        catch
                        {
                        }
                    }

                }

                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");

                    item[this.cellvalue_deliverydate].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick",
                       string.Concat("javascript:OnDeliveryDateClick('",
                       item[this.cellvalue_deliverydate].Text, "'," + item["JobID"].Text + " );"/*lcs(this,'" + this.DateFormat +"');"*/));

                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                    if (this.DateTypeSelected == "" || this.DateTypeSelected == "Delivey")
                    {
                        try
                        {
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            int days = 0;
                            TimeSpan timeSpan = new TimeSpan();
                            str4 = DateTime.Now.ToString();
                            item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));

                            commonClass _commonClass = this.cmnClass;
                            now = DateTime.Now;
                            _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), CheckIntegerNull(this.CompanyID), CheckIntegerNull(this.UserID), true);
                            now = this.cmnClass.Eprint_return_ActualDate_Before_View(str4, this.CompanyID, this.UserID, true);
                            DateTime dateTime = CheckDateTimeNull(now.ToShortDateString());
                            now = CheckDateTimeNull(item[this.cellvalue_deliverydate].Text);
                            DateTime dateTime1 = CheckDateTimeNull(now.ToShortDateString());
                            timeSpan = dateTime1 - dateTime;
                            days = timeSpan.Days;
                            if (days > 0)
                            {
                                DataRow[] dataRowArray2 = this.dtColor.Select(string.Concat("Days>= ", days));
                                if ((int)dataRowArray2.Length > 0)
                                {
                                    empty5 = dataRowArray2[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days == 0)
                            {
                                DataRow[] dataRowArray3 = this.dtColor.Select("[optionType]= 'On same day'");
                                if ((int)dataRowArray3.Length > 0)
                                {
                                    empty5 = dataRowArray3[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days < 0)
                            {
                                DataRow[] dataRowArray4 = this.dtColor.Select("[optionType]= 'elapsed'");
                                if ((int)dataRowArray4.Length > 0)
                                {
                                    empty5 = dataRowArray4[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            //deliveryDate = string.IsNullOrEmpty(deliveryDate) == true ? "Set Delivery Date" : deliveryDate;
                            //item[this.cellvalue_deliverydate].Text = deliveryDate;
                            item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));
                        }
                        catch
                        {
                        }
                    }
                }
                if (this.flag_productiondate == "true")
                {
                    item[this.cellvalue_productiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_productiondate].Attributes.Add("class", "hyperlinkStyle");
                    //item[this.cellvalue_productiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_productiondate].Attributes.Add("onclick",
                    string.Concat("javascript:OnProductionDateClick('",
                    item[this.cellvalue_productiondate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_productiondate].Style.Add("cursor", "pointer");
                    if (this.DateTypeSelected != "Production")
                    {
                        item[this.cellvalue_productiondate].Text = item[this.cellvalue_productiondate].Text.ToString();
                    }
                    else
                    {
                        try
                        {
                            string str5 = string.Empty;
                            string empty6 = string.Empty;
                            int num = 0;
                            TimeSpan timeSpan1 = new TimeSpan();
                            str5 = DateTime.Now.ToString();
                            item[this.cellvalue_productiondate].Text = (item[this.cellvalue_productiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false));
                            commonClass _commonClass1 = this.cmnClass;
                            now = DateTime.Now;
                            _commonClass1.Eprint_return_DateTime_Before_View(now.ToString(), CheckIntegerNull(this.CompanyID), CheckIntegerNull(this.UserID), true);
                            now = this.cmnClass.Eprint_return_ActualDate_Before_View(str5, this.CompanyID, this.UserID, true);
                            DateTime dateTime2 = CheckDateTimeNull(now.ToShortDateString());
                            now = CheckDateTimeNull(item[this.cellvalue_productiondate].Text);
                            DateTime dateTime3 = CheckDateTimeNull(now.ToShortDateString());
                            timeSpan1 = dateTime3 - dateTime2;
                            num = timeSpan1.Days;
                            if (num > 0)
                            {
                                DataRow[] dataRowArray5 = this.dtColor.Select(string.Concat("Days>= ", num));
                                if ((int)dataRowArray5.Length > 0)
                                {
                                    empty6 = dataRowArray5[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty6);
                            }
                            else if (num == 0)
                            {
                                DataRow[] dataRowArray6 = this.dtColor.Select("[optionType]= 'On same day'");
                                if ((int)dataRowArray6.Length > 0)
                                {
                                    empty6 = dataRowArray6[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty6);
                            }
                            else if (num < 0)
                            {
                                DataRow[] dataRowArray7 = this.dtColor.Select("[optionType]= 'elapsed'");
                                if ((int)dataRowArray7.Length > 0)
                                {
                                    empty6 = dataRowArray7[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty6);
                            }
                            item[this.cellvalue_productiondate].Attributes.Add("align", "center");
                            item[this.cellvalue_productiondate].Text = (item[this.cellvalue_productiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false));
                        }
                        catch
                        {
                        }
                    }
                }
                if (this.flag_ProofStatus == "true")
                {
                    string _proofID = ((DataRowView)e.Item.DataItem)[9].ToString();
                    string proofURL = string.Concat(global.sitePath(), "Proofs/Proof_summary.aspx?estid=", _estimateID, "&EstItemID=", _estimateItemID, "&ProofID=", _proofID);
                    item[this.cellvalue_ProofStatus].Attributes.Add("align", "left");
                    if(!string.IsNullOrEmpty(_proofID))
                    {
                        item[this.cellvalue_ProofStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", proofURL, "');"));
                        item[this.cellvalue_ProofStatus].Style.Add("cursor", "pointer");

                        if (item[this.cellvalue_ProofStatus].Text == "Approved")
                        {
                            item[this.cellvalue_ProofStatus].Style.Add("background-color", "#01DA66");
                        }
                        if (item[this.cellvalue_ProofStatus].Text == "Rejected")
                        {
                            item[this.cellvalue_ProofStatus].Style.Add("background-color", "#E64557");
                        }
                    }
                }
                if(this.flag_FTPStatus == "true")
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
                if (this.flag_isproformainvoice == "true")
                {
                    item[this.cellvalue_IsProformaInvoice].Attributes.Add("align", "Center");
                    item[this.cellvalue_IsProformaInvoice].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_IsProformaInvoice].Style.Add("cursor", "pointer");
                }
                if (this.flag_jobstatus == "true")
                {
                    item[this.cellvalue_jobstatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobstatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_jobstatus].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                }
                if (this.flag_PONumber == "true") ////Modification By Bilal
                {
                    TableCell item1 = item["PONumber"];
                    if (item1.Text == "Multiple")
                    {
                        item[this.cellvalue_PONumber].Attributes.Add("onclick", string.Concat("javascript:OpenPurchase_List('", ((DataRowView)e.Item.DataItem)[1].ToString(), "');return false;"));
                        item[this.cellvalue_PONumber].Style.Add("cursor", "pointer");
                    }
                    else
                    {
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "purchase/purchase_add.aspx?type=edit&amp;id=", ((DataRowView)e.Item.DataItem)[6].ToString(), ">", item["PONumber"].Text, "</a>" };
                        item1.Text = string.Concat(languageConversion);
                    }
                }
                if (this.flag_DelNumber == "true") ////Modification By Bilal
                {
                    TableCell item1 = item["DelNumber"];
                    if (item1.Text == "Multiple")
                    {
                        item[this.cellvalue_DelNumber].Attributes.Add("onclick", string.Concat("javascript:OpenDelivery_List('", ((DataRowView)e.Item.DataItem)[1].ToString(), "');return false;"));
                        item[this.cellvalue_DelNumber].Style.Add("cursor", "pointer");
                    }
                    else
                    {
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "delivery/delivery_add.aspx?type=edit&amp;id=", ((DataRowView)e.Item.DataItem)[7].ToString(), ">", item["DelNumber"].Text, "</a>" };
                        item1.Text = string.Concat(languageConversion);
                    }
                }
                if (this.flag_POStage == "true") ////Modification By Bilal
                {
                    TableCell item1 = item["POStage"];
                    if (item1.Text == "N/A" || item1.Text == "Multiple")
                    {
                        item[this.cellvalue_POStage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                        item[this.cellvalue_POStage].Style.Add("cursor", "pointer");
                    }
                    else
                    {
                        languageConversion = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "purchase/purchase_add.aspx?type=edit&amp;id=", ((DataRowView)e.Item.DataItem)[6].ToString(), ">", item["POStage"].Text, "</a>" };
                        item1.Text = string.Concat(languageConversion);
                    }
                }
                if (this.flag_StockStage == "true") ////Modification By Bilal
                {
                    TableCell item1 = item["StockStage"];
                    if (item1.Text == "N/A")
                    {
                        item[this.cellvalue_StockStage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                        item[this.cellvalue_StockStage].Style.Add("cursor", "pointer");
                    }
                    else
                    {
                        item[this.cellvalue_StockStage].Attributes.Add("onclick", string.Concat("javascript:AllocationPopUp('", ((DataRowView)e.Item.DataItem)[8].ToString(), "');return false;"));
                        item[this.cellvalue_StockStage].Style.Add("cursor", "pointer");
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_status].Style.Add("background-color", item["itemStatusColorCode"].Text); // Add this line
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estimator].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                }
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                }
                if (this.flag_jobtitle == "true")
                {
                    item[this.cellvalue_jobtitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobtitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_salesperson == "true")
                {
                    var salesPerson = item[this.cellvalue_salesperson].Text;
                    if (salesPerson == "&nbsp;")
                    {
                        salesPerson = "";
                    }
                    salesPerson = string.IsNullOrEmpty(salesPerson) == true ? "Select Sales Person" : salesPerson;
                    item[this.cellvalue_salesperson].Text = salesPerson;
                    item[this.cellvalue_salesperson].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnSalesPersonClick(" + item["JobId"].Text + ", " + item["SalesPersonId"].Text + "," + item["Cust_ID"].Text + ")"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                }
                if (this.flag_comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_comments, "EstimateID");
                }
                if (this.flag_estimateno == "true")
                {
                    item[this.cellvalue_estimateno].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_estimateno].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_customerordernumber == "true")
                {
                    item[this.cellvalue_customerordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customerordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_costcentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_costcentre].Style.Add("cursor", "pointer");
                }
                if (this.flag_JobType == "true")
                {
                    item[this.cellvalue_JobType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobType].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
        
                    TableCell item4 = item[this.cellvalue_ItemStatus];
                    languageConversion = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    item4.Text = string.Concat(languageConversion);
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
                }
                //if (this.flag_comments == "true")
                //{
                 //   item[this.cellvalue_comments].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                  //  item[this.cellvalue_comments].Style.Add("cursor", "pointer");
                //}
                if (this.flag_ItemAccCode == "true")
                {
                    item[this.cellvalue_ItemAccCode].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemAccCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemAccCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY == "true")
                {
                    item[this.cellvalue_ItemQTY].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemQTY].Style.Add("cursor", "pointer");
                }
                if (this.flag_MainItemSupplier == "true")
                {
                    item[this.cellvalue_MainItemSupplier].Attributes.Add("align", "left");
                    item[this.cellvalue_MainItemSupplier].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_MainItemSupplier].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemValue_ExcTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemValue_ExcTax].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemValue_IncTax].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemValue_IncTax].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemTaxValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemTaxValue].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemCostPriceExcMarkup].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemCostPriceExcMarkup].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemMarkupValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemMarkupValue].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemCostPriceIncMarkup].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemCostPriceIncMarkup].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemProfitMarginPercentage].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemProfitMarginPercentage].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemProfitMarginValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemProfitMarginValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemGrossProfitPercentage].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemGrossProfitValue].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_ItemGrossProfitValue].Text), 0, "", false, false, true);
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
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("align", "Left");
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EventCodeNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("align", "center");
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CampaignSignNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemMaterial == "true")
                {
                    item[this.cellvalue_ItemMaterial].Attributes.Add("align", "left");
                    item[this.cellvalue_ItemMaterial].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemMaterial].Style.Add("cursor", "pointer");
                }
                if (this.flag_EventVenue == "true")
                {
                    item[this.cellValue_EventVenue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellValue_EventVenue].Style.Add("cursor", "pointer");
                }
                if (this.flag_Height == "true")
                {
                    item[this.cellvalue_Height].Attributes.Add("align", "right");
                    item[this.cellvalue_Height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Height].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Height].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_Height].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_Width].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, CheckDecimalNull(item[this.cellvalue_Width].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemDescription == "true")
                {
                    if (item[this.cellvalue_ItemDescription].Text != "")
                    {
                        item[this.cellvalue_ItemDescription].ToolTip = item[this.cellvalue_ItemDescription].Text;
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
                }
                if (this.flag_ItemSize == "true")
                {
                    item[this.cellvalue_ItemSize].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemSize].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemArtwork == "true")
                {
                    item[this.cellvalue_ItemArtwork].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemArtwork].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemDelivery == "true")
                {
                    item[this.cellvalue_ItemDelivery].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemDelivery].Style.Add("cursor", "pointer");
                }
                if (this.flag_DeliveryAddressLabel == "true")
                {
                    item[this.cellvalue_DeliveryAddressLabel].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_DeliveryAddressLabel].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemFinishing == "true")
                {
                    item[this.cellvalue_ItemFinishing].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemFinishing].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemProofs == "true")
                {
                    item[this.cellvalue_ItemProofs].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemProofs].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemPacking == "true")
                {
                    item[this.cellvalue_ItemPacking].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemPacking].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemNotes == "true")
                {
                    item[this.cellvalue_ItemNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemNotes].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    item[this.cellvalue_ItemTermsInstructions].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTermsInstructions].Style.Add("cursor", "pointer");
                }
                if (this.flag_proofdate == "true")
                {
                    item[this.cellvalue_proofdate].Attributes.Add("align", "center");
                    item[this.cellvalue_proofdate].Attributes.Add("class", "hyperlinkStyle");
                    item[this.cellvalue_proofdate].Attributes.Add("onclick",
                     string.Concat("javascript:OnProofDateClick('",
                     item[this.cellvalue_proofdate].Text, "'," + item["JobID"].Text + " );"));
                    //item[this.cellvalue_proofdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_proofdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_Department == "true")
                {
                    item[this.cellvalue_Department].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Department].Style.Add("cursor", "pointer");
                }
                if (this.flag_CompamyEmail == "true")
                {
                    item[this.cellvalue_CompamyEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_CompamyEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactEmail == "true")
                {
                    item[this.cellvalue_ContactEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ContactEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactPhone == "true")
                {
                    item[this.cellvalue_ContactPhone].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ContactPhone].Style.Add("cursor", "pointer");
                }
                if (this.flag_JobDate == "true")
                {
                    item[this.cellvalue_JobDate].Attributes.Add("align", "center");
                    item[this.cellvalue_JobDate].Attributes.Add("class", "hyperlinkStyle");

                    //item[this.cellvalue_JobDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobDate].Attributes.Add("onclick",

                    string.Concat("javascript:OnJobDateClick('",
                    item[this.cellvalue_JobDate].Text, "'," + item["JobID"].Text + "," + item["EstimateItemID"].Text + " );"));
                    item[this.cellvalue_JobDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estimator].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                }
                if (this.flag_EstimateNumber == "true")
                {
                    item[this.cellvalue_EstimateNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EstimateNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_PressName == "true")
                {
                    item[this.cellvalue_PressName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_PressName].Style.Add("cursor", "pointer");
                }
                if (this.flag_InventoryName == "true")
                {
                    item[this.cellvalue_InventoryName].Attributes.Add("align", "left");
                    item[this.cellvalue_InventoryName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InventoryName].Style.Add("cursor", "pointer");
                }
                if (this.flag_InventoryFriendlyName == "true")
                {
                    item[this.cellvalue_InventoryFriendlyName].Attributes.Add("align", "left");
                    item[this.cellvalue_InventoryFriendlyName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InventoryFriendlyName].Style.Add("cursor", "pointer");
                }
                if (this.flag_InventoryDescription == "true")
                {
                    item[this.cellvalue_InventoryDescription].Attributes.Add("align", "left");
                    item[this.cellvalue_InventoryDescription].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InventoryDescription].Style.Add("cursor", "pointer");
                }
                if (this.flag_InventoryWeight == "true")
                {
                    item[this.cellvalue_InventoryWeight].Attributes.Add("align", "left");
                    item[this.cellvalue_InventoryWeight].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InventoryWeight].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_jobno == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_jobno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_jobno)] != null && this.Session[string.Concat("job_", this.cellvalue_jobno)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_PONumber == "true")  /////Modification By Bilal
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_PONumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("PO_", this.cellvalue_PONumber)] != null && this.Session[string.Concat("PO_", this.cellvalue_PONumber)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_DelNumber == "true")  /////Modification By Bilal
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_DelNumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("Del_", this.cellvalue_DelNumber)] != null && this.Session[string.Concat("Del_", this.cellvalue_DelNumber)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_POStage == "true")  /////Modification By Bilal
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_POStage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("PO_", this.cellvalue_POStage)] != null && this.Session[string.Concat("PO_", this.cellvalue_POStage)].ToString() == "")
                    {
                        textBox.Text = "";
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
                if (this.flag_StockStage == "true")  /////Modification By Bilal
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_StockStage].Controls[0] as TextBox;
                    if (this.Session[string.Concat("Stock_", this.cellvalue_StockStage)] != null && this.Session[string.Concat("Stock_", this.cellvalue_StockStage)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_customername == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_customername].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_customername)] != null && this.Session[string.Concat("job_", this.cellvalue_customername)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }

                if (this.flag_SinceEmailed == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceEmailed].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_SinceEmailed)] != null && this.Session[string.Concat("job_", this.cellvalue_SinceEmailed)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }

                if (this.flag_SinceStatusUpdate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_SinceStatusUpdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_SinceStatusUpdate)] != null && this.Session[string.Concat("job_", this.cellvalue_SinceStatusUpdate)].ToString() == "")
                    {
                        item20.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_jobtitle == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_jobtitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_jobtitle)] != null && this.Session[string.Concat("job_", this.cellvalue_jobtitle)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_CustomerType == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_CustomerType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_CustomerType)] != null && this.Session[string.Concat("job_", this.cellvalue_CustomerType)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }
                if (this.flag_costcentre == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_costcentre].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_costcentre)] != null && this.Session[string.Concat("job_", this.cellvalue_costcentre)].ToString() == "")
                    {
                        textBox4.Text = "";
                    }
                }
                if (this.flag_Address1 == "true")
                {
                    TextBox item5 = (e.Item as GridFilteringItem)[this.cellvalue_Address1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address1)] != null && this.Session[string.Concat("job_", this.cellvalue_Address1)].ToString() == "")
                    {
                        item5.Text = "";
                    }
                }
                if (this.flag_Address2 == "true")
                {
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_Address2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address2)] != null && this.Session[string.Concat("job_", this.cellvalue_Address2)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_Address3 == "true")
                {
                    TextBox item6 = (e.Item as GridFilteringItem)[this.cellvalue_Address3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address3)] != null && this.Session[string.Concat("job_", this.cellvalue_Address3)].ToString() == "")
                    {
                        item6.Text = "";
                    }
                }
                if (this.flag_Address4 == "true")
                {
                    TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_Address4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address4)] != null && this.Session[string.Concat("job_", this.cellvalue_Address4)].ToString() == "")
                    {
                        textBox6.Text = "";
                    }
                }
                if (this.flag_Address5 == "true")
                {
                    TextBox item7 = (e.Item as GridFilteringItem)[this.cellvalue_Address5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_Address5)] != null && this.Session[string.Concat("job_", this.cellvalue_Address5)].ToString() == "")
                    {
                        item7.Text = "";
                    }
                }
                if (this.flag_salesperson == "true")
                {
                    TextBox textBox7 = (e.Item as GridFilteringItem)[this.cellvalue_salesperson].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_salesperson)] != null && this.Session[string.Concat("job_", this.cellvalue_salesperson)].ToString() == "")
                    {
                        textBox7.Text = "";
                    }
                }
                if (this.flag_jobstatus == "true")
                {
                    TextBox item8 = (e.Item as GridFilteringItem)[this.cellvalue_jobstatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_jobstatus)] != null && this.Session[string.Concat("job_", this.cellvalue_jobstatus)].ToString() == "")
                    {
                        item8.Text = "";
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    TextBox textBox8 = (e.Item as GridFilteringItem)[this.cellvalue_AccountStatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_AccountStatus)] != null && this.Session[string.Concat("job_", this.cellvalue_AccountStatus)].ToString() == "")
                    {
                        textBox8.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox item9 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_status)] != null && this.Session[string.Concat("job_", this.cellvalue_status)].ToString() == "")
                    {
                        item9.Text = "";
                    }
                }
                if (this.flag_isproformainvoice == "true")
                {
                    TextBox textBox9 = (e.Item as GridFilteringItem)[this.cellvalue_IsProformaInvoice].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_IsProformaInvoice)] != null && this.Session[string.Concat("job_", this.cellvalue_IsProformaInvoice)].ToString() == "")
                    {
                        textBox9.Text = "";
                    }
                }
                if (this.flag_contactname == "true")
                {
                    TextBox item10 = (e.Item as GridFilteringItem)[this.cellvalue_contactname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_contactname)] != null && this.Session[string.Concat("job_", this.cellvalue_contactname)].ToString() == "")
                    {
                        item10.Text = "";
                    }
                }
                if (this.flag_estimator == "true")
                {
                    TextBox textBox10 = (e.Item as GridFilteringItem)[this.cellvalue_estimator].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_estimator)] != null && this.Session[string.Concat("job_", this.cellvalue_estimator)].ToString() == "")
                    {
                        textBox10.Text = "";
                    }
                }
                if (this.flag_estimateno == "true")
                {
                    TextBox item11 = (e.Item as GridFilteringItem)[this.cellvalue_estimateno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_estimateno)] != null && this.Session[string.Concat("job_", this.cellvalue_estimateno)].ToString() == "")
                    {
                        item11.Text = "";
                    }
                }
                if (this.flag_customerordernumber == "true")
                {
                    TextBox textBox11 = (e.Item as GridFilteringItem)[this.cellvalue_customerordernumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_customerordernumber)] != null && this.Session[string.Concat("job_", this.cellvalue_customerordernumber)].ToString() == "")
                    {
                        textBox11.Text = "";
                    }
                }
                if (this.flag_referredby == "true")
                {
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_referredby].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_referredby)] != null && this.Session[string.Concat("job_", this.cellvalue_referredby)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    TextBox textBox12 = (e.Item as GridFilteringItem)[this.cellvalue_customeraccountnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_customeraccountnumber)] != null && this.Session[string.Concat("job_", this.cellvalue_customeraccountnumber)].ToString() == "")
                    {
                        textBox12.Text = "";
                    }
                }
                if (this.flag_paymentterms == "true")
                {
                    TextBox item13 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("job_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        item13.Text = "";
                    }
                }
                if (this.flag_comments == "true")
                {
                    TextBox textBoxComments = (e.Item as GridFilteringItem)[this.cellvalue_comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_comments)] != null && this.Session[string.Concat("job_", this.cellvalue_comments)].ToString() == "")
                    {
                        textBoxComments.Text = "";
                    }
                }
                if (this.flag_jobval == "true")
                {
                    gridFilteringItem[this.cellvalue_jobval].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox13 = (e.Item as GridFilteringItem)[this.cellvalue_jobval].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_jobval)] != null && this.Session[string.Concat("job_", this.cellvalue_jobval)].ToString() == "")
                    {
                        textBox13.Text = "";
                    }
                }
                if (this.flag_jobvalExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_jobvalExcGst].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item14 = (e.Item as GridFilteringItem)[this.cellvalue_jobvalExcGst].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_jobvalExcGst)] != null && this.Session[string.Concat("job_", this.cellvalue_jobvalExcGst)].ToString() == "")
                    {
                        item14.Text = "";
                    }
                }
                if (this.flag_converteddate == "true")
                {
                    gridFilteringItem[this.cellvalue_converteddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox14 = (e.Item as GridFilteringItem)[this.cellvalue_converteddate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_converteddate)] != null && this.Session[string.Concat("job_", this.cellvalue_converteddate)].ToString() == "")
                    {
                        textBox14.Text = "";
                    }
                }
                if (this.flag_completiondate == "true")
                {
                    gridFilteringItem[this.cellvalue_completiondate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item15 = (e.Item as GridFilteringItem)[this.cellvalue_completiondate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_completiondate)] != null && this.Session[string.Concat("job_", this.cellvalue_completiondate)].ToString() == "")
                    {
                        item15.Text = "";
                    }
                }
                if (this.flag_deliverydate == "true")
                {
                    gridFilteringItem[this.cellvalue_deliverydate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox15 = (e.Item as GridFilteringItem)[this.cellvalue_deliverydate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_deliverydate)] != null && this.Session[string.Concat("job_", this.cellvalue_deliverydate)].ToString() == "")
                    {
                        textBox15.Text = "";
                    }
                }
                if (this.flag_productiondate == "true")
                {
                    gridFilteringItem[this.cellvalue_productiondate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item16 = (e.Item as GridFilteringItem)[this.cellvalue_productiondate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_productiondate)] != null && this.Session[string.Concat("job_", this.cellvalue_productiondate)].ToString() == "")
                    {
                        item16.Text = "";
                    }
                }
                if (this.flag_ArtworkDate == "true")
                {
                    gridFilteringItem[this.cellvalue_ArtworkDate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox16 = (e.Item as GridFilteringItem)[this.cellvalue_ArtworkDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_ArtworkDate)] != null && this.Session[string.Concat("job_", this.cellvalue_ArtworkDate)].ToString() == "")
                    {
                        textBox16.Text = "";
                    }
                }
                if (this.flag_ApprovalDate == "true")
                {
                    gridFilteringItem[this.cellvalue_ApprovalDate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item17 = (e.Item as GridFilteringItem)[this.cellvalue_ApprovalDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_ApprovalDate)] != null && this.Session[string.Concat("job_", this.cellvalue_ApprovalDate)].ToString() == "")
                    {
                        item17.Text = "";
                    }
                }
                if (this.flag_proofdate == "true")
                {
                    gridFilteringItem[this.cellvalue_proofdate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox17 = (e.Item as GridFilteringItem)[this.cellvalue_proofdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_proofdate)] != null && this.Session[string.Concat("job_", this.cellvalue_proofdate)].ToString() == "")
                    {
                        textBox17.Text = "";
                    }
                }
                if (this.flag_quantity == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_quantity].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_quantity)] != null && this.Session[string.Concat("job_", this.cellvalue_quantity)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_isproformainvoice == "true")
                {
                    gridFilteringItem[this.cellvalue_IsProformaInvoice].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox18 = (e.Item as GridFilteringItem)[this.cellvalue_IsProformaInvoice].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_IsProformaInvoice)] != null && this.Session[string.Concat("job_", this.cellvalue_IsProformaInvoice)].ToString() == "")
                    {
                        textBox18.Text = "";
                    }
                }
                if (this.flag_JobType == "true")
                {
                    gridFilteringItem[this.cellvalue_JobType].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item19 = (e.Item as GridFilteringItem)[this.cellvalue_JobType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_JobType)] != null && this.Session[string.Concat("job_", this.cellvalue_JobType)].ToString() == "")
                    {
                        item19.Text = "";
                    }
                }
                if (this.flag_PressName == "true")
                {
                    gridFilteringItem[this.cellvalue_PressName].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox19 = (e.Item as GridFilteringItem)[this.cellvalue_PressName].Controls[0] as TextBox;
                    if (this.Session[string.Concat("job_", this.cellvalue_PressName)] != null && this.Session[string.Concat("job_", this.cellvalue_PressName)].ToString() == "")
                    {
                        textBox19.Text = "";
                    }
                }
                if (this.flag_ItemStatus == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemStatus].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTitle == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTitle].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_ItemAccCode == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemAccCode].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_MainItemSupplier == "true")
                {
                    gridFilteringItem[this.cellvalue_MainItemSupplier].HorizontalAlign = HorizontalAlign.Left;
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
                    gridFilteringItem[this.cellvalue_CampaignSignNumber].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_ItemMaterial == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMaterial].HorizontalAlign = HorizontalAlign.Left;
                }
                if (this.flag_PressName == "true")
                {
                    gridFilteringItem[this.cellvalue_PressName].HorizontalAlign = HorizontalAlign.Left;
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
                GridTableView masterTableView = this.GridView1.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.GridView1.PagerStyle.PagerTextFormat = string.Concat("{4} {5}", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
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
            this.SR_WhenStockReduced = this.objBase.Return_StockManagementSettings("SR_WhenStockReduced");
            this.SR_JobStatusID = this.objBase.Return_StockManagementSettings("SR_JobStatusID");
            this.Replenish_JobStatusID = this.objBase.Return_StockManagementSettings("Replenish_JobStatusID");
            this.lnkJobsedit.Text = this.objLanguage.GetLanguageConversion("Edit_View");
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.Invoice_Paid_Row_Select_Note = this.objLanguage.GetLanguageConversion("Invoice_Paid_Row_Select_Note");
            this.Progress_To_Invoice_Selection_Alert = this.objLanguage.GetLanguageConversion("Progress_To_Invoice_Selection_Alert");
            this.rdb_Delete_All.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_its_corresponding_Estimate_Estimate_Item");
            this.rdb_Delete_Job.Text = this.objLanguage.GetLanguageConversion("Delete_Job_and_keep_Estimate_live");
            this.lbl_note.Text = string.Concat(this.objLanguage.GetLanguageConversion("By_deleteing_the_job_its_corresponding_invoice_will_be_deleted"), ". ", this.objLanguage.GetLanguageConversion("Stock_Item_Delete_Alert_Message"));
            this.lblArchive.Text = this.objLanguage.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.lblRecordPayment.Text = this.objLanguage.GetLanguageConversion("Record_Payment");
            this.lblUnArchive.Text = this.objLanguage.GetLanguageConversion("UnArchive_Selected");
            this.lblsendbulkemail.Text = this.objLanguage.GetLanguageConversion("Send_Email");
            this.Please_Check_Atleast_One_Row = this.objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row");
            if (!this.EnableBulkEmailSend)
            {
                this.td_sendbulkemail.Visible = false;
            }
            this.divunarchive.Style.Add("display", "none");
            this.objBase.ReturnRoles_Privileges_Tabs("jobs", "isview", "");
            if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divDelete.Visible = true;
            }
            else
            {
                this.divDelete.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
                this.divunarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
                this.divunarchive.Visible = false;
            }
            string strPToI = this.objBase.ReturnRoles_Privileges_ForGrid("jobs", "others", this.Page.Request.Url.ToString());
            if ((strPToI == "0" || strPToI == "2") && (this.divDelete.Visible != false || this.divarchive.Visible != false))
            {
                this.divProgToInv.Visible = false;
            }
            else
            {
                this.divProgToInv.Visible = true;
            }
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
                this.hdnIDs.Value = "";
            }
            for (int i = 0; i < this.RadListBox2.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox2.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridView1.ClientID, "','Id','", this.hdnSelectedChkfrmGrid.ClientID, "','", this.objBase.SpecialEncode(this.RadListBox2.Items[i].Text), "','", this.RadListBox2.Items[i].Value, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            global.pageName = "job";
            global.pgName = "";
            this.gloobj.setpagename("job");
            this.pg = "job";
            this.CompanyID = CheckIntegerNull(this.Session["CompanyID"].ToString());
            this.UserID = CheckIntegerNull(this.Session["UserID"].ToString());
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            this.GetDatetimeValue_ViewColor(this.CompanyID);
            this.DateFormat = this.Session["Dateformat"].ToString();
            this.strImagepath = global.imagePath();
            base.Title = this.objLanguage.convert(global.pageTitle("Jobs View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator' style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Job_View")));
            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_DateTime_Before_View(now.ToString().ToString(), this.CompanyID, this.UserID, true);
            string str = this.comm.UserSetting_Selete(this.CompanyID, this.UserID, "jobs_view");
            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            if (str != "" && str != null)
            {
                this.defaultviewid = CheckIntegerNull(str);
            }
            if (this.Session["JobViewID"] != null)
            {
                this.defaultviewid = CheckIntegerNull(this.Session["JobViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridView1.PageSize = 50;
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = CheckIntegerNull(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView("job", this.CompanyID, this.ddl_View, CheckIntegerNull(base.Request.Params["ViewID"]));
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
                }
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.pg);
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow row in this.dt.Rows)
                        {
                            this.defaultviewid = CheckIntegerNull(row["ViewID"].ToString());
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
            int num3 = 0;
            num3 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num3, this.CompanyID, "job");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow dataRow in this.dt.Rows)
                {
                    this.defaultsortedby = dataRow["SortedBy"].ToString();
                    this.defaultsortdirection = dataRow["SortDirection"].ToString();
                    //83
                    //this.IsGrouping = String.IsNullOrEmpty(dataRow["isGrouping"].ToString()) ? false : Convert.ToBoolean(dataRow["isGrouping"].ToString());

                    //this.IsGrouping = (dataRow["ColumnNames"].ToString().Contains(dataRow["GroupByColumn"].ToString()) && !String.IsNullOrEmpty(dataRow["isGrouping"].ToString())) ? Convert.ToBoolean(dataRow["isGrouping"].ToString()) : false;
                    //this.GroupByColumn = dataRow["GroupByColumn"].ToString();
                    this.FilterDateType = dataRow["FilterDateType"].ToString();
                    this.FilterDateRange = dataRow["FilterDateRange"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                jobs_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    jobs_view.SortedBy = "JobNumber";
                }
                else
                {
                    jobs_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    jobs_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    jobs_view.sortdirection = this.defaultsortdirection;
                }
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = CheckIntegerNull(base.Request.Params["viewid"].ToString());
                    string str1 = string.Concat(this.pg, this.UserID, this.pg);
                    this.Session["search_job"] = null;
                    this.Session[str1] = null;
                    this.Session["JobViewID"] = this.defaultviewid;

                }
                if (this.InventoryManagement == "IM")
                {
                    this.ReduceStockType = this.comm.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                    this.ReduceStockTypeForCancelled = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
                }
                foreach (DataRow row1 in this.objComp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if (row1["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (row1["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLanguage.GetLanguageConversion("Address1");
                        }
                        else
                        {
                            this.hdnaddress1.Value = row1["addressvalue"].ToString();
                        }
                    }
                    if (row1["addresslkey"].ToString().ToLower() == "address2")
                    {
                        if (row1["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress2.Value = this.objLanguage.GetLanguageConversion("Address2");
                        }
                        else
                        {
                            this.hdnaddress2.Value = row1["addressvalue"].ToString();
                        }
                    }
                    if (row1["addresslkey"].ToString().ToLower() == "address3")
                    {
                        if (row1["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress3.Value = this.objLanguage.GetLanguageConversion("Address3");
                        }
                        else
                        {
                            this.hdnaddress3.Value = row1["addressvalue"].ToString();
                        }
                    }
                    if (row1["addresslkey"].ToString().ToLower() == "address4")
                    {
                        if (row1["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress4.Value = this.objLanguage.GetLanguageConversion("Address4");
                        }
                        else
                        {
                            this.hdnaddress4.Value = row1["addressvalue"].ToString();
                        }
                    }
                    if (row1["addresslkey"].ToString().ToLower() != "address5")
                    {
                        continue;
                    }
                    if (row1["addressvalue"].ToString() == "")
                    {
                        this.hdnaddress5.Value = this.objLanguage.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row1["addressvalue"].ToString();
                    }
                }
            }
            else
            {
                if (this.defaultsortedby == "")
                {
                    jobs_view.SortedBy = "JobNumber";
                }
                else
                {
                    jobs_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    jobs_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    jobs_view.sortdirection = this.defaultsortdirection;
                }
            }
            DataTable dataTable = SettingsBasePage.settings_companyprofile_select(this.CompanyID);
            jobs_view.ManageStockPermission = CheckIntegerNull(dataTable.Rows[0]["ProductStockManagement"]);
            if (jobs_view.ManageStockPermission == 1)
            {
                this.StockCancellationType = this.objBase.Return_StockManagementSettings("SC_IfJobCancelled");
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.cmnClass.functionCheckAll());
            }
            if (!base.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckChanged", this.cmnClass.functionCheckChange());
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
                        this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, "customerid", "desc", empty);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            this.lblProgressToInvoice.Text = this.objLanguage.GetLanguageConversion("Progress_To_Invoice");
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            jobs_view.IsItem_Selected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
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
            this.divProgToInv.Style.Add("display", "block");
            this.divPaid.Style.Clear();
            this.divPaid.Style.Add("border-left", "1px solid #CBCBCB");
            this.divPaid.Style.Add("border-right", "1px solid #CBCBCB");
            this.divPaid.Style.Add("border-top", "1px solid #CBCBCB;");
            if (!base.IsPostBack)
            {
                string str2 = "";
                if (this.Session["search_job"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_job"];
                    str2 = this.FilterFunction(item);
                }
                this.Session["JobViewID"] = this.defaultviewid;

                int pageSize = 50;
                DataTable jobSettings = SettingsBasePage.Select_JobDefault_Settings(this.CompanyID);
                foreach (DataRow dr in jobSettings.Rows)
                {
                    pageSize = dr["Display100JobsOnJobPage"].ToString().ToLower() == "true" ? 100 : 50;
                }
                this.GridView1.PageSize = pageSize;
                //jobs_view.PageSize = this.cmnClass.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                jobs_view.PageSize = pageSize;
                this.GridView1.PageSize = jobs_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, jobs_view.SortedBy, jobs_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridView1.Rebind();
                if (base.Request.Params["su"] != null)
                {
                    if (base.Request.Params["su"].ToString().ToLower() == "payment")
                    {
                        this.objBase.Message_Display("Payment details updated successfully. ", "successfulMsg", this.plhMessage);
                    }
                    else if (base.Request.Params["su"].ToString().ToLower() == "p2i")
                    {
                        this.objBase.Message_Display("Progressed to Invoice successfully. ", "successfulMsg", this.plhMessage);
                    }
                }
            }
            //if (!IsPostBack && this.IsGrouping)
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridView1, this.GroupByColumn);
            //}
            

            var column = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("SinceStatusCount");
            if (column != null)
            {
                column.Visible = false;
            }
            var column2 = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("SinceEmailCount");
            if (column2 != null)
            {
                column2.Visible = false;
            }
            var column3 = this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("isAnyEmailed");
            if (column3 != null)
            {
                column3.Visible = false;
            }
            try
            {
                this.GridView1.MasterTableView.GetColumn("StatusColorCode").Visible = false;
                this.GridView1.MasterTableView.GetColumn("itemStatusColorCode").Visible = false;
                this.GridView1.MasterTableView.GetColumn("jobid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("custid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("estimateid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("estimateitemid").Visible = false;
                //this.GridView1.MasterTableView.GetColumn("ProofID").Visible = false;
                if (this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("ProofID") != null)
                {
                    this.GridView1.MasterTableView.GetColumn("ProofID").Visible = false;
                }
                this.GridView1.MasterTableView.GetColumn("Cust_ID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("InvAddress_ID").Visible = false;
                this.GridView1.MasterTableView.GetColumn("backOrder").Visible = false;
                this.GridView1.MasterTableView.GetColumn("HasReplenishItem").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsAccountOnHold").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsStockProduct").Visible = false;
                this.GridView1.MasterTableView.GetColumn("PaymentType").Visible = false;
             

                if (this.IsItemSelected)
                {
                    this.GridView1.MasterTableView.GetColumn("InvoiceID").Visible = false;
                    this.GridView1.MasterTableView.GetColumn("PurchaseID").Visible = false;  ////Modification By Bilal warehouse stage 1
                    this.GridView1.MasterTableView.GetColumn("DeliveryID").Visible = false;  ////Modification By Bilal
                    this.GridView1.MasterTableView.GetColumn("PriceCatalogueID").Visible = false;  ////Modification By Bilal
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.MasterTableView.PageSize = GridView1.PageSize;
                GridView1.Rebind();
            }
        }
        protected void RadListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string empty = string.Empty;
            this.CompanyID = CheckIntegerNull(this.Session["CompanyID"]);
            int num = CheckIntegerNull(this.RadListBox2.SelectedValue);
            string text = this.RadListBox2.SelectedItem.Text;
            string[] strArrays = this.hdnSelectedChkfrmGrid.Value.Split(new char[] { ',' });
            string str = string.Empty;
            string empty1 = string.Empty;
            int num1 = 0;
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                string str1 = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                str = string.Concat(str, str1.Split(chrArray)[0].ToString(), ',');
                string str2 = strArrays[i];
                char[] chrArray1 = new char[] { '\u005F' };
                if (str2.Split(chrArray1)[2].ToString() != "0")
                {
                    string str3 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    empty1 = string.Concat(empty1, str3.Split(chrArray2)[2].ToString(), ',');
                    num1++;
                }
            }
            this.RadListBox2.ClearSelection();
            string str4 = "Job";
            if (str != "" && num != 0)
            {
                if (!this.IsItemSelected)
                {
                    EstimatesBasePage.EstimateOnCheck_Status_Update(this.CompanyID, str, num, str4.ToLower());
                }
                if (num1 > 0)
                {
                    EstimatesBasePage.EstimateItemsOnCheck_Status_Update(this.CompanyID, empty1, num, str4.ToLower());
                }

                var locking = this.objBase.ReturnRoles_Privileges_Others("locking").ToLower();
                if (locking == "true")
                {
                    Int32 LockStatusId = comm.getLockUnlockStatus(CompanyID, "JOBS", "Lock Job");
                    Int32 UnLockStatusId = comm.getLockUnlockStatus(CompanyID, "JOBS", "UnLock Job");
                    string chkLockingStatus = string.Empty;
                    string chkUnlockingStatus = string.Empty;
                    string[] IDs = str.Split(new char[] { ',' });
                    DataTable _dt = new DataTable();
                    if (num == LockStatusId)
                    {
                        for (int n = 0; n < (int)IDs.Length - 1; n++)
                        {
                            _dt = EstimateBasePage.GetUpdateJobLockingOrUnlockingStatus(long.Parse(IDs[n]), this.CompanyID, "Lock Job");
                            foreach (DataRow dr in _dt.Rows)
                            {
                                chkLockingStatus = dr["status"].ToString();
                            }
                            if (chkLockingStatus == "1")
                            {
                                EstimateBasePage.PC_update_JobLocking_Status(long.Parse(IDs[n]), true);
                            }

                        }
                    }
                    else if(num == UnLockStatusId)
                    {
                        for (int n = 0; n < (int)IDs.Length - 1; n++)
                        {
                            _dt = EstimateBasePage.GetUpdateJobLockingOrUnlockingStatus(long.Parse(IDs[n]), this.CompanyID, "UnLock Job");
                            foreach (DataRow dr in _dt.Rows)
                            {
                                chkUnlockingStatus = dr["status"].ToString();
                            }
                            if (chkUnlockingStatus == "1")
                            {
                                EstimateBasePage.PC_update_JobLocking_Status(long.Parse(IDs[n]), false);
                            }

                        }
                    }
                }

                if (this.InventoryManagement == "IM")
                {
                    this.ReduceStockType = this.comm.Settings_inventoryStockReduction_Select((long)this.CompanyID);
                    this.ReduceStockTypeForCancelled = this.comm.Settings_inventoryStockReduction_CancelledJob((long)this.CompanyID);
                }
                string empty2 = string.Empty;
                for (int j = 0; j < (int)strArrays.Length - 1; j++)
                {
                    string str5 = strArrays[j];
                    char[] chrArray3 = new char[] { '\u005F' };
                    empty2 = string.Concat(empty2, str5.Split(chrArray3)[1].ToString(), ',');
                }
                string[] strArrays1 = empty2.Split(new char[] { ',' });
                for (int k = 0; k < (int)strArrays1.Length - 1; k++)
                {
                    string empty3 = string.Empty;
                    if (this.hdn_stockBack.Value.ToLower() == "yes")
                    {
                        this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-status", CheckIntegerNull(strArrays1[k].ToString()), this.CompanyID, (long)0, this.UserID);
                    }
                    empty = ((this.hdn_stockBackwarehoue.Value == "yes" || this.StockCancellationType == "a") && text.ToLower() == "cancelled" ? this.SummaryClassObj.Call_Inventory_Adjustment("cancelled-stock-status", CheckIntegerNull(strArrays1[k].ToString()), this.CompanyID, (long)0, this.UserID) : this.SummaryClassObj.Call_Inventory_Adjustment("completed-status", CheckIntegerNull(strArrays1[k].ToString()), this.CompanyID, (long)0, this.UserID));
                }
                string[] strArrays2 = str.Split(new char[] { ',' });
                string[] strArrays3 = empty1.Split(new char[] { ',' });
                int estimateId = 0;
                if (empty1.Trim().Length != 0)
                {
                    for (int l = 0; l < (int)strArrays3.Length - 1; l++)
                    {
                        string empty4 = string.Empty;
                        DataTable dataTable = JobBasePage.Job_Select_By_EstimateItemID(this.CompanyID, (long)CheckIntegerNull(strArrays3[l].ToString()));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            empty4 = row["JobstatusName"].ToString();
                            this.Jobnumber = row["JobItemNumber"].ToString();
                            this.ModuleID = CheckIntegerNull(row["JobID"].ToString());
                            estimateId = Convert.ToInt32(row["EstimateID"]);
                        }
                        this.objnotes.Job_number = this.Jobnumber;
                        this.objnotes.Status_name = empty4;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobChangeStatus);
                        this.UserID = CheckIntegerNull(this.Session["UserID"].ToString());
                        this.objnotes.ModuleID = this.ModuleID;
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass = this.cmnClass;
                        DateTime now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objnotes.ItemID = (long)CheckIntegerNull(strArrays3[l].ToString());
                        this.objN.NotesAdd(this.objnotes);
                        this.cmnClass.SendMailOnJobStatusChange_Item(this.CompanyID, (long)0, num, "job", (long)CheckIntegerNull(strArrays3[l].ToString()), (long)0);
                        this.cmnClass.NewMailOnJobStatusChange(this.CompanyID, estimateId, num, "job");
                        this.comm.SendInternalMailOnModuleStatusChange(CompanyID, estimateId, num, "job");
                        string itemType = EstimatesBasePage.GetEstimateType_EstimateItemID((long)Convert.ToInt32(strArrays3[l].ToString()));
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
                                    long priceCatalogurID = EstimatesBasePage.GetPriceCatalogueIDByEstimateItemID((long)Convert.ToInt32(strArrays3[l].ToString()));
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
                                                DataTable _attachment = commonClass.GetAttachmentByEstimateItemID(Convert.ToInt64(strArrays3[l].ToString()));
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
                                        if (itemType == "X")
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "OnlineOrder", Convert.ToInt64(strArrays3[l].ToString()));
                                        }
                                        else
                                        {
                                            commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "ProductEstimate", Convert.ToInt64(strArrays3[l].ToString()));
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    for (int m = 0; m < (int)strArrays2.Length - 1; m++)
                    {
                        string empty5 = string.Empty;

                        DataTable dataTable1 = JobBasePage.Job_Select_By_JobID(this.CompanyID, (long)CheckIntegerNull(strArrays2[m].ToString()));
                        foreach (DataRow dataRow in dataTable1.Rows)
                        {
                            empty5 = dataRow["jobstatus"].ToString();
                            this.Jobnumber = dataRow["JobNumber"].ToString();
                            estimateId = Convert.ToInt32(dataRow["EstimateID"]);
                        }
                        this.objnotes.Job_number = this.Jobnumber;
                        this.objnotes.Status_name = empty5;
                        this.objnotes.ModuleName = "job";
                        this.objnotes.NotesType = CheckStringNull(Notes.NotesType.JobChangeStatus);
                        this.UserID = CheckIntegerNull(this.Session["UserID"].ToString());
                        this.objnotes.ModuleID = (long)CheckIntegerNull(strArrays2[m].ToString());
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass1 = this.objnotes;
                        commonClass _commonClass1 = this.cmnClass;
                        DateTime dateTime = DateTime.Now;
                        _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        this.cmnClass.SendMailOnJobStatusChange_Item(this.CompanyID, (long)0, num, "job", (long)0, (long)CheckIntegerNull(strArrays2[m].ToString()));
                        this.cmnClass.NewMailOnJobStatusChange(this.CompanyID, estimateId, num, "job");
                        this.comm.SendInternalMailOnModuleStatusChange(CompanyID, estimateId, num, "job");
                        DataTable dt = EstimatesBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, Convert.ToInt64(estimateId));
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
                                                    object[] editableTemplatePath;
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
                                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "OnlineOrder", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                }
                                                else
                                                {
                                                    commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "JobStatus", "ProductEstimate", Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                                }
                                            }
                                        }
                                    }

                                }

                            }

                        }
                    }
                }
                this.objBase.Message_Display(string.Concat("Status updated successfully.", empty), "successfulMsg", this.plhMessage);
                this.hdnSelectedChkfrmGrid.Value = "";
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);
          
            this.GridView1.Rebind();
        }

        [WebMethod]
        public static string SetEstimateID(string val, int companyID)
        {
            string[] strArrays = val.Split(new char[] { ',' });
            val = "";
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!jobs_view.IsItem_Selected)
                {
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '\u005F' };
                    if (JobBasePage.EstimateID_Select_By_JobID(companyID, CheckIntegerNull(str.Split(chrArray)[0].ToString())) != (long)0)
                    {
                        string str1 = strArrays[i];
                        char[] chrArray1 = new char[] { '\u005F' };
                        val = string.Concat(val, str1.Split(chrArray1)[0].ToString(), ",");
                    }
                }
                else
                {
                    string str2 = strArrays[i];
                    char[] chrArray2 = new char[] { '\u005F' };
                    val = string.Concat(val, str2.Split(chrArray2)[2].ToString(), ",");
                }
            }
            return val;
        }

        private string getErrorCount(int estimateid, int jobid)
        {


            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_GetErrorCountForJob");


            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, CheckIntegerNull(estimateid));
            database.AddInParameter(storedProcCommand, "@JobID", DbType.Int64, CheckIntegerNull(jobid));

            dataSet = database.ExecuteDataSet(storedProcCommand);


            DataRow dr = dataSet.Tables[0].Rows[0];

            string errorCount = dr["ErrorCount"].ToString();


            return errorCount;
        }



    }
}