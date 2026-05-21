using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsnotesclass;
using nmsView;
using Printcenter.BusinessAccessLayer.Notes;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Services;
using System.Configuration;
using System.Linq;
using System.IO;

namespace ePrint.Printcenter.Views.Estimate
{
    public partial class estimate_view : BaseClass, IRequiresSessionState
    {
        //protected RadAjaxManager RadAjaxManager1;

        //protected HiddenField hdnaddress1;

        //protected HiddenField hdnaddress2;

        //protected HiddenField hdnaddress3;

        //protected HiddenField hdnaddress4;

        //protected HiddenField hdnaddress5;

        //protected UpdateProgress upProgress;

        //protected PlaceHolder plhMessage;

        //protected UpdatePanel UPMessage;

        //protected PlaceHolder plhErrorMessage;

        //protected UpdatePanel UpdatePanel1;

        //protected DropDownList ddl_View;

        //protected LinkButton lnkPurchaseedit;

        //protected LinkButton btnclrFilters;

        //protected Label lblView;

        //protected HiddenField hdnAlphabet;

        //protected RadListBox RadListBox1;

        //protected Panel pnl_StatusList;

        //protected Label lblArchive;

        //protected HtmlGenericControl divarchive;

        //protected Label lblUnArchive;

        //protected HtmlGenericControl divunarchive;

        //protected Label lblDelete;

        //protected HtmlGenericControl divDelete;

        //protected RadGrid GridView1;

        //protected LinkButton lnkEstDelete;

        //protected LinkButton lnkEstArchive;

        //protected LinkButton lnkEstUnArchive;

        //protected LinkButton lnkEstimateCopy;

        //protected HtmlGenericControl div_Main;

        //protected HiddenField hdnEstimateID;

        //protected HiddenField hidGridCount;

        //protected HiddenField hdnEstimateIds;

        //protected HiddenField hdnSelectedChkfrmGrid;

        //protected UpdatePanel updtehidnfield;

        //protected HiddenField edit_estViewID;

        //protected HiddenField hdnIDs;

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        private notesclass objnotes = new notesclass();

        private Notes objN = new Notes();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath;

        public string strSitepath;

        private Global gloobj = new Global();

        public int totalrec;

        public int CompanyID;

        private string para = string.Empty;

        public long EstNo;

        public string newdate = string.Empty;

        public int UserID;

        public string pg;

        private createViewClass objCreateView = new createViewClass();

        public int defaultviewid;

        public string flag_estval = string.Empty;

        public string cellvalue_estval = string.Empty;

        public string flag_estvalExcGST = string.Empty;

        public string cellvalue_estvalExcGST = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string flag_DefaultTemplate = string.Empty;

        public string cellvalue_DefaultTemplate = string.Empty;


        public string flag_Archive = string.Empty;

        public string cellvalue_Archive = string.Empty;

        public string flag_ChooseTemplate = string.Empty;

        public string cellvalue_ChooseTemplate = string.Empty;

        public string flag_DownloadTemplate = string.Empty;

        public string cellvalue_DownloadTemplate = string.Empty;

        public string flag_estdate = string.Empty;

        public string cellvalue_status = string.Empty;

        public string cellvalue_estimatestatus = string.Empty;

        public string flag_status = string.Empty;

        public string flag_estimatestatus = string.Empty;

        public string cellvalue_order = string.Empty;

        public string flag_order = string.Empty;

        public string cellvalue_greeting = string.Empty;

        public string flag_greeting = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string cellvalue_estimator = string.Empty;

        public string flag_estimator = string.Empty;

        public string cellvalue_custname = string.Empty;

        public string flag_custname = string.Empty;

        public string cellvalue_company = string.Empty;

        public string flag_company = string.Empty;

        public string cellvalue_sales = string.Empty;

        public string flag_sales = string.Empty;

        public string cellvalue_contactname = string.Empty;

        public string flag_contactname = string.Empty;

        public string cellvalue_Header = string.Empty;

        public string flag_Header = string.Empty;

        public string cellvalue_footer = string.Empty;

        public string flag_footer = string.Empty;

        public string cellvalue_comments = string.Empty;

        public string flag_comments = string.Empty;

        public string cellvalue_estTitle = string.Empty;

        public string flag_estTitle = string.Empty;

        public string cellvalue_valid = string.Empty;

        public string flag_valid = string.Empty;

        public string cellvalue_custacountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymerntterms = string.Empty;

        public string cellvalue_custordernumber = string.Empty;

        public string flag_custordernumber = string.Empty;

        public string cellvalue_quantity1 = string.Empty;

        public string flag_quantity1 = string.Empty;

        public string cellvalue_quantity2 = string.Empty;

        public string flag_quantity2 = string.Empty;

        public string cellvalue_quantity3 = string.Empty;

        public string flag_quantity3 = string.Empty;

        public string cellvalue_quantity4 = string.Empty;

        public string flag_quantity4 = string.Empty;

        public string cellvalue_costcenter = string.Empty;

        public string flag_costcenter = string.Empty;

        public string cellvalue_estimateno = string.Empty;

        public string flag_estimattype = string.Empty;

        public string cellvalue_estimattype = string.Empty;

        public string flag_estimateno = string.Empty;

        public string cellvalue_estdate = string.Empty;

        public string flag_ContactEmail = string.Empty;

        public string cellvalue_ContactEmail = string.Empty;

        public string flag_ComapnyEmail = string.Empty;

        public string cellvalue_ComapnyEmail = string.Empty;

        public string flag_ContactPhone = string.Empty;

        public string cellvalue_ContactPhone = string.Empty;

        public string flag_ArtworkDate = string.Empty;

        public string cellvalue_ArtworkDate = string.Empty;

        public string flag_ProofDate = string.Empty;

        public string cellvalue_ProofDate = string.Empty;

        public string flag_ApprovalDate = string.Empty;

        public string cellvalue_ApprovalDate = string.Empty;

        public string flag_ProductionDate = string.Empty;

        public string cellvalue_ProductionDate = string.Empty;

        public string flag_CompletionDate = string.Empty;

        public string cellvalue_CompletionDate = string.Empty;

        public string flag_DeliveryDate = string.Empty;

        public string cellvalue_DeliveryDate = string.Empty;

        public string flag_SinceEmailed = string.Empty;

        public string cellvalue_SinceEmailed = string.Empty;

        public string flag_SinceStatusUpdate = string.Empty;

        public string cellvalue_SinceStatusUpdate = string.Empty;

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

        public string flag_ItemQTY1 = string.Empty;

        public string cellvalue_ItemQTY1 = string.Empty;

        public string flag_ItemQTY2 = string.Empty;

        public string cellvalue_ItemQTY2 = string.Empty;

        public string flag_ItemQTY3 = string.Empty;

        public string cellvalue_ItemQTY3 = string.Empty;

        public string flag_ItemQTY4 = string.Empty;

        public string cellvalue_ItemQTY4 = string.Empty;

        public string flag_ItemValue_ExcTax1 = string.Empty;

        public string cellvalue_ItemValue_ExcTax1 = string.Empty;

        public string flag_ItemValue_ExcTax2 = string.Empty;

        public string cellvalue_ItemValue_ExcTax2 = string.Empty;

        public string flag_ItemValue_ExcTax3 = string.Empty;

        public string cellvalue_ItemValue_ExcTax3 = string.Empty;

        public string flag_ItemValue_ExcTax4 = string.Empty;

        public string cellvalue_ItemValue_ExcTax4 = string.Empty;

        public string flag_ItemValue_IncTax1 = string.Empty;

        public string cellvalue_ItemValue_IncTax1 = string.Empty;

        public string flag_ItemValue_IncTax2 = string.Empty;

        public string cellvalue_ItemValue_IncTax2 = string.Empty;

        public string flag_ItemValue_IncTax3 = string.Empty;

        public string cellvalue_ItemValue_IncTax3 = string.Empty;

        public string flag_ItemValue_IncTax4 = string.Empty;

        public string cellvalue_ItemValue_IncTax4 = string.Empty;

        public string flag_ItemTaxValue1 = string.Empty;

        public string cellvalue_ItemTaxValue1 = string.Empty;

        public string flag_ItemTaxValue2 = string.Empty;

        public string cellvalue_ItemTaxValue2 = string.Empty;

        public string flag_ItemTaxValue3 = string.Empty;

        public string cellvalue_ItemTaxValue3 = string.Empty;

        public string flag_ItemTaxValue4 = string.Empty;

        public string cellvalue_ItemTaxValue4 = string.Empty;

        public string flag_ItemCostPriceExcMarkup1 = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup1 = string.Empty;

        public string flag_ItemCostPriceExcMarkup2 = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup2 = string.Empty;

        public string flag_ItemCostPriceExcMarkup3 = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup3 = string.Empty;

        public string flag_ItemCostPriceExcMarkup4 = string.Empty;

        public string cellvalue_ItemCostPriceExcMarkup4 = string.Empty;

        public string flag_ItemMarkupValue1 = string.Empty;

        public string cellvalue_ItemMarkupValue1 = string.Empty;

        public string flag_ItemMarkupValue2 = string.Empty;

        public string cellvalue_ItemMarkupValue2 = string.Empty;

        public string flag_ItemMarkupValue3 = string.Empty;

        public string cellvalue_ItemMarkupValue3 = string.Empty;

        public string flag_ItemMarkupValue4 = string.Empty;

        public string cellvalue_ItemMarkupValue4 = string.Empty;

        public string flag_ItemCostPriceIncMarkup1 = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup1 = string.Empty;

        public string flag_ItemCostPriceIncMarkup2 = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup2 = string.Empty;

        public string flag_ItemCostPriceIncMarkup3 = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup3 = string.Empty;

        public string flag_ItemCostPriceIncMarkup4 = string.Empty;

        public string cellvalue_ItemCostPriceIncMarkup4 = string.Empty;

        public string flag_ItemProfitMarginPercentage1 = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage1 = string.Empty;

        public string flag_ItemProfitMarginPercentage2 = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage2 = string.Empty;

        public string flag_ItemProfitMarginPercentage3 = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage3 = string.Empty;

        public string flag_ItemProfitMarginPercentage4 = string.Empty;

        public string cellvalue_ItemProfitMarginPercentage4 = string.Empty;

        public string flag_ItemProfitMarginValue1 = string.Empty;

        public string cellvalue_ItemProfitMarginValue1 = string.Empty;

        public string flag_ItemProfitMarginValue2 = string.Empty;

        public string cellvalue_ItemProfitMarginValue2 = string.Empty;

        public string flag_ItemProfitMarginValue3 = string.Empty;

        public string cellvalue_ItemProfitMarginValue3 = string.Empty;

        public string flag_ItemProfitMarginValue4 = string.Empty;

        public string cellvalue_ItemProfitMarginValue4 = string.Empty;

        public string flag_ItemGrossProfitPercentage1 = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage1 = string.Empty;

        public string flag_ItemGrossProfitPercentage2 = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage2 = string.Empty;

        public string flag_ItemGrossProfitPercentage3 = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage3 = string.Empty;

        public string flag_ItemGrossProfitPercentage4 = string.Empty;

        public string cellvalue_ItemGrossProfitPercentage4 = string.Empty;

        public string flag_ItemGrossProfitValue1 = string.Empty;

        public string cellvalue_ItemGrossProfitValue1 = string.Empty;

        public string flag_ItemGrossProfitValue2 = string.Empty;

        public string cellvalue_ItemGrossProfitValue2 = string.Empty;

        public string flag_ItemGrossProfitValue3 = string.Empty;

        public string cellvalue_ItemGrossProfitValue3 = string.Empty;

        public string flag_ItemGrossProfitValue4 = string.Empty;

        public string cellvalue_ItemGrossProfitValue4 = string.Empty;

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

        public string flag_ProofComment = string.Empty;

        public string cellvalue_ProofComment = string.Empty;

        public DataTable dt = new DataTable();

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string flag_validfor = string.Empty;

        public string cellvalue_validfor = string.Empty;

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

        public string EstimateID = string.Empty;

        private DataTable dtArtwork = new DataTable();

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string Archive_Row_Selection_Alert = string.Empty;

        public string Delete_Row_Selection_Alert = string.Empty;

        public string UnArchive_Row_Selection_Alert = string.Empty;

        public bool IsItemSelected;

        public string RecordsToDisplay = "";

        private long ModuleID;

        private string EstimateItem_number = string.Empty;

        private string Estimate_number = string.Empty;

        public string flag_ProofStatus = string.Empty;

        public string cellvalue_ProofStatus = string.Empty;

        //public bool IsGrouping;
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

        //public string GroupByColumn = string.Empty;
        public string FilterDateType = string.Empty;
        public string FilterDateRange = string.Empty;

        public string cellvalue_priority = string.Empty;

        public string flag_priority = string.Empty;

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

        static estimate_view()
        {
            estimate_view.WhereCondition = string.Empty;
            estimate_view.sortdirection = string.Empty;
            estimate_view.SortedBy = string.Empty;
            estimate_view.PageSize = 50;
        }

        public estimate_view()
        {
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
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "estimatedate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    if (dt.Columns[i].ColumnName.ToLower() == "estimatevalue" || dt.Columns[i].ColumnName.ToLower() == "estimatevalue_excgst")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Decimal");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    if (dt.Columns[i].ColumnName.ToLower() == "validfor")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.Int32");
                        gridBoundColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    }
                    //if (dt.Columns[i].ColumnName.ToLower() == "comments")
                    //{
                     //   this.GridView1.MasterTableView.Columns.Remove(gridBoundColumn);
                        
                      //  GridTemplateColumn commentColumn = new GridTemplateColumn();
                      //  commentColumn.UniqueName = dt.Columns[i].ColumnName;
                      //  commentColumn.HeaderText = "Comments";
                      //  commentColumn.ItemTemplate = new CommentsTemplate();
                      //  gv.MasterTableView.Columns.Add(commentColumn);
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
                }
                for (int j = 0; j < this.GridView1.Columns.Count; j++)
                {
                    this.GridView1.Columns[j].CurrentFilterFunction = GridKnownFunction.Contains;
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridView1.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_No");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_estimateno = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimateno = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Person");
                        this.cellvalue_sales = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Title");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(150);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_estTitle = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_contactname = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_custname = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "company")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_company = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_company = "true";
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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "ordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.cellvalue_custordernumber = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_custordernumber = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.cellvalue_custordernumber = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_custordernumber = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatestatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_estimatestatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimatestatus = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_AccountStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                        this.GridView1.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.GridView1.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_status = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "validfor")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Valid_For");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_validfor = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Created_On");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.GridView1.Columns[j].HeaderText = "Default Template";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "archive")
                    {
                        this.GridView1.Columns[j].HeaderText = "Archive";
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_Archive = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Archive = "true";
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



                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Est_Value"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatedate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_estdate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity1")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity1");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity1 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity2")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity2");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity2 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity2 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity3")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity3");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity3 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity3 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "quantity4")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity5");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity4 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_quantity4 = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.cellvalue_referredby = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_referredby = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.cellvalue_custacountnumber = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_customeraccountnumber = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isconvertedtojob")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isarchive")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "emailcount")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "errorcount")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "isdeletedjob")
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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Est_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estvalExcGST = "true";
                        this.cellvalue_estvalExcGST = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.cellvalue_paymentterms = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_paymerntterms = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.cellvalue_costcenter = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_costcenter = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "greeting")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Greeting");
                        this.cellvalue_greeting = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "header")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Header");
                        this.cellvalue_Header = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "footer")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Footer");
                        this.cellvalue_footer = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "comments")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Comments");
                        this.cellvalue_comments = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.cellvalue_estimator = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Type");
                        this.cellvalue_estimattype = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_estimattype = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "backorder")
                    {
                        this.GridView1.Columns[j].Visible = false;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status_View");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity1")
                    {
                        this.flag_ItemQTY1 = "true";
                        this.cellvalue_ItemQTY1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity1");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity2")
                    {
                        this.flag_ItemQTY2 = "true";
                        this.cellvalue_ItemQTY1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity2");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity3")
                    {
                        this.flag_ItemQTY3 = "true";
                        this.cellvalue_ItemQTY1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity3");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemquantity4")
                    {
                        this.flag_ItemQTY4 = "true";
                        this.cellvalue_ItemQTY1 = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity4");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax1 = "true";
                        this.cellvalue_ItemValue_ExcTax1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax2 = "true";
                        this.cellvalue_ItemValue_ExcTax2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax3 = "true";
                        this.cellvalue_ItemValue_ExcTax3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueexctax4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax4 = "true";
                        this.cellvalue_ItemValue_ExcTax4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax1 = "true";
                        this.cellvalue_ItemValue_IncTax1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax2 = "true";
                        this.cellvalue_ItemValue_IncTax2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax3 = "true";
                        this.cellvalue_ItemValue_IncTax3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemvalueintax4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax4 = "true";
                        this.cellvalue_ItemValue_IncTax4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue1 = "true";
                        this.cellvalue_ItemTaxValue1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue2 = "true";
                        this.cellvalue_ItemTaxValue2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue3 = "true";
                        this.cellvalue_ItemTaxValue3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemtaxvalue4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue4 = "true";
                        this.cellvalue_ItemTaxValue4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup1 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup2 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup3 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup4 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue1 = "true";
                        this.cellvalue_ItemMarkupValue1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue2 = "true";
                        this.cellvalue_ItemMarkupValue2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue3 = "true";
                        this.cellvalue_ItemMarkupValue3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmarkupvalue4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue4 = "true";
                        this.cellvalue_ItemMarkupValue4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup1 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup2 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup3 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup4 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage1 = "true";
                        this.cellvalue_ItemProfitMarginPercentage1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage2 = "true";
                        this.cellvalue_ItemProfitMarginPercentage2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage3 = "true";
                        this.cellvalue_ItemProfitMarginPercentage3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage4 = "true";
                        this.cellvalue_ItemProfitMarginPercentage4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue1 = "true";
                        this.cellvalue_ItemProfitMarginValue1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue2 = "true";
                        this.cellvalue_ItemProfitMarginValue2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue3 = "true";
                        this.cellvalue_ItemProfitMarginValue3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue4 = "true";
                        this.cellvalue_ItemProfitMarginValue4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage1 = "true";
                        this.cellvalue_ItemGrossProfitPercentage1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage2 = "true";
                        this.cellvalue_ItemGrossProfitPercentage2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage3 = "true";
                        this.cellvalue_ItemGrossProfitPercentage3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage4_view"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage4 = "true";
                        this.cellvalue_ItemGrossProfitPercentage4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue1")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue1 = "true";
                        this.cellvalue_ItemGrossProfitValue1 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue2")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue2 = "true";
                        this.cellvalue_ItemGrossProfitValue2 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue3")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue3 = "true";
                        this.cellvalue_ItemGrossProfitValue3 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue4")
                    {
                        this.GridView1.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue4 = "true";
                        this.cellvalue_ItemGrossProfitValue4 = this.GridView1.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
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
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_view");
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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ContactEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ContactEmail = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ComapnyEmail = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ComapnyEmail = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ContactPhone = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ContactPhone = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "artworkdate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Artwork_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ArtworkDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ArtworkDate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofdate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ProofDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ProofDate = "true";
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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofcomments")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Comments");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ProofComment = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ProofComment = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "approvaldate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Approval_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ApprovalDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ApprovalDate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "productiondate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Production_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ProductionDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ProductionDate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "completiondate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Completion_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CompletionDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_CompletionDate = "true";
                    }
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DeliveryDate = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_DeliveryDate = "true";
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
                    else if (this.GridView1.Columns[j].SortExpression.ToLower() == "proofstatus")
                    {
                        this.GridView1.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Status");
                        this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ProofStatus = this.GridView1.Columns[j].SortExpression.ToLower();
                        this.flag_ProofStatus = "true";
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
                    this.GridView1.Columns[j].HeaderText = "Archive Item";
                    this.GridView1.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    this.cellvalue_Archive = this.GridView1.Columns[j].UniqueName.ToLower();
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


        public class ImageTemplate : ITemplate
        {
            private string _imageUrl;

            public ImageTemplate(string imageUrl)
            {
                _imageUrl = imageUrl;
            }

            public void InstantiateIn(Control container)
            {
                Image img = new Image
                {
                    ImageUrl = _imageUrl,
                    AlternateText = "Default Template",
                    Width = Unit.Pixel(16),
                    Height = Unit.Pixel(16)
                };
                container.Controls.Add(img);
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

            GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, this.para);
            this.GridView1.Rebind();
            base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_view.aspx"));
        }


        private void UpdateCommentInDatabase(int commentId, string newComment)
        {
            EstimateBasePage.Estimate_Comments_Update(commentId, newComment);

        }

        public void bindRadlistStatus()
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            DataTable dataTable = SettingsBasePage.settings_estimatestatus_moduletype_select(this.CompanyID, "estimate");
            this.RadListBox1.DataSource = dataTable;
            this.RadListBox1.DataTextField = "StatusTitle";
            this.RadListBox1.DataValueField = "StatusID";
            this.RadListBox1.DataBind();
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            EstimateBasePage.Estimate_Delete(Convert.ToInt32(this.Session["companyid"]), Convert.ToInt64(this.hdnEstimateID.Value));
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, this.para);
        }

        public void btnEditView_Click(object sender, EventArgs e)
        {
            HttpResponse response = base.Response;
            object[] value = new object[] { "../estimates/customview.aspx?type=edit&id=", this.edit_estViewID.Value, "&cid=", Convert.ToInt16(this.Session["CompanyID"]) };
            response.Redirect(string.Concat(value));
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
        }

        public void ClearPerticularFilterExpression(string FilterExpression, string ColName, string value)
        {
            if (FilterExpression.ToLower() != "nofilter")
            {
                this.Session[string.Concat("estimate_", ColName.ToLower())] = value;
                return;
            }
            this.Session[string.Concat("estimate_", ColName.ToLower())] = "";
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            estimate_view.WhereCondition = "";
            this.Session["search_Est"] = null;
            foreach (GridColumn column in this.GridView1.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.GridView1.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);
            this.GridView1.MasterTableView.Rebind();
        }

        public void ddlView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = Convert.ToInt32(this.ddl_View.SelectedValue);
            num = Convert.ToInt32(this.ddl_View.SelectedIndex);
            HttpResponse response = base.Response;
            object[] objArray = new object[] { this.strSitepath, "estimates/estimate_view.aspx?viewid=", num1, "&index=", num };
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
                num1 = Convert.ToInt32(row["Roundoff"].ToString());
            }
            this.Session["search_Est"] = dtsearch;
            foreach (DataRow dataRow in dtsearch.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && estimate_view.WhereCondition != "")
                {
                    estimate_view.WhereCondition = string.Concat(estimate_view.WhereCondition, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "estimatedate" || dataRow["Columnname"].ToString().ToLower() == "artworkdate" || dataRow["Columnname"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "approvaldate" || dataRow["Columnname"].ToString().ToLower() == "productiondate" || dataRow["Columnname"].ToString().ToLower() == "completiondate" || dataRow["Columnname"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() =="customdate5")
                {
                    str = this.objJava.eprint_checkdateformat_returnonlymmddyyyy(this.DateFormat, dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst")
                {
                    str = base.SpecialEncode(dataRow["FilterText"].ToString().Trim());
                    object[] objArray = new object[] { "round(", dataRow["ColumnName"].ToString(), ",", num1, ")" };
                    empty = string.Concat(objArray);
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
                //             if (< PrivateImplementationDetails >{ 4D412C83 - 4704 - 44CF - 88AD - 5137B9E4F995}.$$method0x600001b - 1 == null)
                //{

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

                //             }
                //             if (!< PrivateImplementationDetails >{ 4D412C83 - 4704 - 44CF - 88AD - 5137B9E4F995}.$$method0x600001b - 1.TryGetValue(str1, out num))
                //{
                //                 continue;
                //             }

                switch (num)
                {
                    case 0:
                        {
                            string whereCondition = estimate_view.WhereCondition;
                            string[] strArrays = new string[] { whereCondition, " ", empty, " like '", str, "%'" };
                            estimate_view.WhereCondition = string.Concat(strArrays);
                            continue;
                        }
                    case 1:
                        {
                            string whereCondition1 = estimate_view.WhereCondition;
                            string[] strArrays1 = new string[] { whereCondition1, " ", empty, " like '%", str, "'" };
                            estimate_view.WhereCondition = string.Concat(strArrays1);
                            continue;
                        }
                    case 2:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "createddate" || dataRow["ColumnName"].ToString().ToLower() == "estimatedate" || dataRow["Columnname"].ToString().ToLower() == "artworkdate" || dataRow["Columnname"].ToString().ToLower() == "proofdate" || dataRow["Columnname"].ToString().ToLower() == "approvaldate" || dataRow["Columnname"].ToString().ToLower() == "productiondate" || dataRow["Columnname"].ToString().ToLower() == "completiondate" || dataRow["Columnname"].ToString().ToLower() == "deliverydate" || dataRow["Columnname"].ToString().ToLower() == "customdate1" || dataRow["Columnname"].ToString().ToLower() == "customdate2" || dataRow["Columnname"].ToString().ToLower() == "customdate3" || dataRow["Columnname"].ToString().ToLower() == "customdate4" || dataRow["Columnname"].ToString().ToLower() == "customdate5")
                            {
                                string whereCondition2 = estimate_view.WhereCondition;
                                string[] strArrays2 = new string[] { whereCondition2, " ", empty, " = '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays2);
                                continue;
                            }
                            else
                            {
                                string str2 = estimate_view.WhereCondition;
                                string[] strArrays3 = new string[] { str2, " ", empty, " like '%", str, "%'" };
                                estimate_view.WhereCondition = string.Concat(strArrays3);
                                continue;
                            }
                        }
                    case 3:
                        {
                            string whereCondition3 = estimate_view.WhereCondition;
                            string[] strArrays4 = new string[] { whereCondition3, " ", empty, " not like '%", str, "%'" };
                            estimate_view.WhereCondition = string.Concat(strArrays4);
                            continue;
                        }
                    case 4:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str3 = estimate_view.WhereCondition;
                                string[] strArrays5 = new string[] { str3, " ", empty, " = ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays5);
                                continue;
                            }
                            else
                            {
                                string whereCondition4 = estimate_view.WhereCondition;
                                string[] strArrays6 = new string[] { whereCondition4, " ", empty, " = '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays6);
                                continue;
                            }
                        }
                    case 5:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str4 = estimate_view.WhereCondition;
                                string[] strArrays7 = new string[] { str4, " ", empty, " != ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays7);
                                continue;
                            }
                            else
                            {
                                string whereCondition5 = estimate_view.WhereCondition;
                                string[] strArrays8 = new string[] { whereCondition5, " ", empty, " != '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays8);
                                continue;
                            }
                        }
                    case 6:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str5 = estimate_view.WhereCondition;
                                string[] strArrays9 = new string[] { str5, " ", empty, " > ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays9);
                                continue;
                            }
                            else
                            {
                                string whereCondition6 = estimate_view.WhereCondition;
                                string[] strArrays10 = new string[] { whereCondition6, " ", empty, " > '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays10);
                                continue;
                            }
                        }
                    case 7:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str6 = estimate_view.WhereCondition;
                                string[] strArrays11 = new string[] { str6, " ", empty, " >= ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays11);
                                continue;
                            }
                            else
                            {
                                string whereCondition7 = estimate_view.WhereCondition;
                                string[] strArrays12 = new string[] { whereCondition7, " ", empty, " >= '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays12);
                                continue;
                            }
                        }
                    case 8:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str7 = estimate_view.WhereCondition;
                                string[] strArrays13 = new string[] { str7, " ", empty, " < ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays13);
                                continue;
                            }
                            else
                            {
                                string whereCondition8 = estimate_view.WhereCondition;
                                string[] strArrays14 = new string[] { whereCondition8, " ", empty, " < '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays14);
                                continue;
                            }
                        }
                    case 9:
                        {
                            if (dataRow["ColumnName"].ToString().ToLower() == "estimatevalue" || dataRow["ColumnName"].ToString().ToLower() == "validfor" || dataRow["ColumnName"].ToString().ToLower() == "estimatevalue_excgst" || dataRow["ColumnName"].ToString().ToLower() == "quantity1" || dataRow["ColumnName"].ToString().ToLower() == "quantity2" || dataRow["ColumnName"].ToString().ToLower() == "quantity3" || dataRow["ColumnName"].ToString().ToLower() == "quantity4")
                            {
                                string str8 = estimate_view.WhereCondition;
                                string[] strArrays15 = new string[] { str8, " ", empty, " <= ", str };
                                estimate_view.WhereCondition = string.Concat(strArrays15);
                                continue;
                            }
                            else
                            {
                                string whereCondition9 = estimate_view.WhereCondition;
                                string[] strArrays16 = new string[] { whereCondition9, " ", empty, " <= '", str, "'" };
                                estimate_view.WhereCondition = string.Concat(strArrays16);
                                continue;
                            }
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
            return estimate_view.WhereCondition;
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
            string str = "";
            if (item != null)
            {
                foreach (DataRow row in item.Rows)
                {
                    if (row.Table.Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("EstimateDate"))
                    {
                        row["EstimateDate"] = this.objJava.Eprint_return_Date_Before_View(row["EstimateDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ArtworkDate"))
                    {
                        row["ArtworkDate"] = this.objJava.Eprint_return_Date_Before_View(row["ArtworkDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProofDate"))
                    {
                        row["ProofDate"] = this.objJava.Eprint_return_Date_Before_View(row["ProofDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ApprovalDate"))
                    {
                        row["ApprovalDate"] = this.objJava.Eprint_return_Date_Before_View(row["ApprovalDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("ProductionDate"))
                    {
                        row["ProductionDate"] = this.objJava.Eprint_return_Date_Before_View(row["ProductionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CompletionDate"))
                    {
                        row["CompletionDate"] = this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
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
                    if (row.Table.Columns.Contains("ProofComments"))
                    {
                        bool commentFlag = false;
                        string comment = row["ProofComments"].ToString();
                        if(!string.IsNullOrEmpty(comment))
                        {
                            string[] items = comment.Split(',');
                            foreach (string _comment in items)
                            {
                                if(!string.IsNullOrEmpty(_comment))
                                {
                                    commentFlag = true;
                                }
                            }
                        }
                        if(commentFlag)
                        {
                            row["ProofComments"] = "Provided";
                        }
                        else
                        {
                            row["ProofComments"] = "";
                        }
                    }
                    if (!row.Table.Columns.Contains("IsArchive"))
                    {
                        continue;
                    }
                    if (row["IsArchive"].ToString() == "1")
                    {
                        this.lblArchive.Visible = false;
                        str = string.Concat(str, row["IsArchive"].ToString());
                    }
                    if (row["IsArchive"].ToString() == "0")
                    {
                        this.lblUnArchive.Visible = false;
                        str = string.Concat(str, row["IsArchive"].ToString());
                    }
                    if (!str.Contains("1") || !str.Contains("0"))
                    {
                        continue;
                    }
                    this.lblArchive.Visible = true;
                    this.lblUnArchive.Visible = true;
                }
            }
            _commonClass.closeConnection();
            this.GridView1.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
                this.div_Main.Style.Add("display", "block");
                this.GridView1.AllowCustomPaging = false;
                return;
            }
            this.AddBoundColumns(dataSet.Tables[0], this.GridView1);
            this.div_Main.Style.Add("display", "block");
            this.GridView1.AllowCustomPaging = true;
            this.GridView1.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
        }

        protected void GridPurchase_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            string str;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblEstimateValue");
                Label label1 = label;
                if (label.Text == "")
                {
                    double num = Convert.ToDouble("0");
                    str = string.Concat("$", num.ToString());
                }
                else
                {
                    double num1 = Convert.ToDouble(label.Text);
                    str = string.Concat("$", num1.ToString("0.00"));
                }
                label1.Text = str;
                Label label2 = (Label)e.Row.FindControl("lblCustomerName");
                label2.Text = BaseClass.WrapString(label2.Text.ToString().Trim(), 15);
                Label label3 = (Label)e.Row.FindControl("lblContactName");
                label3.Text = BaseClass.WrapString(label3.Text.ToString().Trim(), 15);
                Label label4 = (Label)e.Row.FindControl("lblStatus");
                label4.Text = BaseClass.WrapString(label4.Text.ToString().Trim(), 15);
                Label label5 = (Label)e.Row.FindControl("lblEstimateTitle");
                label5.Text = BaseClass.WrapString(label5.Text.ToString().Trim(), 20);
                Label label6 = (Label)e.Row.FindControl("lblSalesPerson");
                label6.Text = BaseClass.WrapString(label6.Text.ToString().Trim(), 15);
                Label label7 = (Label)e.Row.FindControl("lblEstimator");
                label7.Text = BaseClass.WrapString(label7.Text.ToString().Trim(), 15);
                Label str1 = (Label)e.Row.FindControl("lblEstimateDate");
                string[] strArrays = new string[] { " " };
                string[] strArrays1 = str1.Text.Split(strArrays, StringSplitOptions.None);
                str1.Text = strArrays1[0].ToString();
            }
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
        }

        protected void GridView1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
           // e.Column.Visible = false;
            if (e.Column.IsBoundToFieldName("Date"))
            {
                (e.Column as GridDateTimeColumn).DataFormatString = "{0:D}";
            }
            else if (e.Column.IsBoundToFieldName("UnitPrice"))
            {
                (e.Column as GridNumericColumn).DataFormatString = "{0:C}";
            }
            if (e.Column is GridBoundColumn)
            {
                (e.Column as GridBoundColumn).FilterControlWidth = Unit.Pixel(100);
            }
        }
        
        protected void GridView1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                e.Canceled = true;
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                estimate_view.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "estimatevalue" || commandArgument.Second.ToString().ToLower() == "estimatevalue_excgst" || commandArgument.Second.ToString().ToLower() == "quantity1" || commandArgument.Second.ToString().ToLower() == "quantity2" || commandArgument.Second.ToString().ToLower() == "quantity3" || commandArgument.Second.ToString().ToLower() == "quantity4"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Pls_Enter_Only_Number"), "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (this.Session["search_Est"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (this.Session["search_Est"] != null)
                {
                    this.dtsearch = (DataTable)this.Session["search_Est"];
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
                this.Session["search_Est"] = this.dtsearch;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);
                estimate_view.WhereCondition = this.FilterFunction(this.dtsearch);
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);
                this.GridView1.DataBind();
                //this.GridView1.Rebind();
            }
        }

        protected void GridView1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.SelectedValue), estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);

        }




        protected void GridView1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            estimate_view.SortedBy = e.SortExpression;
            estimate_view.sortdirection = e.NewSortOrder.ToString();
            if (estimate_view.sortdirection.ToLower() == "ascending")
            {
                estimate_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Desc");
            }
            else if (estimate_view.sortdirection.ToLower() != "descending")
            {
                estimate_view.sortdirection = "ASC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort");
            }
            else
            {
                estimate_view.sortdirection = "DESC";
                this.GridView1.SortingSettings.SortToolTip = this.objLanguage.GetLanguageConversion("Click_here_to_sort_Asc");
            }
            this.GridView1.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, this.GridView1.CurrentPageIndex + 1, Convert.ToInt32(this.ddl_View.Items[this.ddl_View.SelectedIndex].Value), e.SortExpression, estimate_view.sortdirection, estimate_view.WhereCondition);
        }

        protected void lnkEstArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    DataTable dataTable = EstimatesBasePage.estimate_select_summary(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Estimate_number = row["EstimateNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(strArrays[i].ToString());
                    }
                    this.objnotes.Estimate_number = this.Estimate_number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstArchivedandProgtoJob);
                    EstimateBasePage.Estimate_Archive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                }
                else
                {
                    DataTable dataTable1 = EstimatesBasePage.estimate_select_summary_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.EstimateItem_number = dataRow["EstimateItemNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(dataRow["ModuleID"]);
                    }
                    this.objnotes.Item_number = this.EstimateItem_number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemArchived);
                    this.objnotes.ItemID = (long)Convert.ToInt32(strArrays[i].ToString());
                    EstimatesBasePage.EstimateItem_Archive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), "Estimate");
                }
                this.objnotes.ModuleName = "Estimate";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Item_Archived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkEstDelete_OnClick(object sender, EventArgs e)
        {
            bool flag = false;
            Int32 countZero = 0;
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {

                string strArray = strArrays[i];
                char[] chrArray = new char[] { '\u005F' };
                if ((long)Convert.ToInt32(strArrays[i].ToString()) == 0)
                {
                    countZero++;
                }
            }
            if (countZero > 0)
            {
                this.objBase.Message_Display(countZero == 1 ? "There is an error in this job and it can not be deleted. Please contact support and request assistance" : "There is an error in one of the job(s) and can not be deleted. Please contact support and request assistance", "msg-fail", this.plhErrorMessage);

                return;
            }

            //string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    EstimateBasePage.Estimate_Delete(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                }
                else
                {

                    EstimatesBasePage.EstimateItem_Delete(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), "estimate", flag);
                }
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Item_Deleted_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkEstimateCopy_OnClick(object sender, EventArgs e)
        {
            this.EstNo = this.objComp.settings_lastcounter_select(this.CompanyID, "e") + (long)1;
            long estNo = (long)10000000 + this.EstNo;
            string.Concat("EST-", estNo.ToString().Substring(1, estNo.ToString().Length - 1));
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            long num = (long)0;
            if (strArrays[0] != "")
            {
                long num1 = Convert.ToInt64(strArrays[0]);
                int companyID = this.CompanyID;
                int userID = this.UserID;
                DateTime now = DateTime.Now;
                num = EstimatesBasePage.Estimate_Copy_Estimate_Insert(companyID, num1, "", userID, now.ToString(), ConnectionClass.IsHandy, "", (long)0);
                int companyID1 = this.CompanyID;
                DateTime dateTime = DateTime.Now;
                EstimatesBasePage.estimate_copy_all(companyID1, num1, num, "estimate", "", dateTime.ToString(), ConnectionClass.IsHandy, 0);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, this.defaultsortedby, this.defaultsortdirection, estimate_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected void lnkUnEstArchive_OnClick(object sender, EventArgs e)
        {
            string[] strArrays = this.hdnEstimateIds.Value.Split(new char[] { ',' });
            for (int i = 0; i < (int)strArrays.Length - 1; i++)
            {
                if (!this.IsItemSelected)
                {
                    DataTable dataTable = EstimatesBasePage.estimate_select_summary(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        this.Estimate_number = row["EstimateNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(strArrays[i]);
                    }
                    this.objnotes.Estimate_number = this.Estimate_number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstUnArchived);
                    EstimateBasePage.Estimate_UnArchive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                }
                else
                {
                    DataTable dataTable1 = EstimatesBasePage.estimate_select_summary_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                    foreach (DataRow dataRow in dataTable1.Rows)
                    {
                        this.EstimateItem_number = dataRow["EstimateItemNumber"].ToString();
                        this.ModuleID = Convert.ToInt64(dataRow["ModuleID"]);
                    }
                    this.objnotes.Item_number = this.EstimateItem_number;
                    this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstItemUnArchived);
                    this.objnotes.ItemID = (long)Convert.ToInt32(strArrays[i].ToString());
                    EstimatesBasePage.EstimateItem_UnArchive(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), "Estimate");
                }
                this.objnotes.ModuleName = "Estimate";
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass = this.objnotes;
                commonClass _commonClass = this.objJava;
                DateTime now = DateTime.Now;
                _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objN.NotesAdd(this.objnotes);
            }
            if (!this.IsItemSelected)
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            else
            {
                base.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Item_UnArchived_Successfully"), "successfulMsg", this.plhMessage);
            }
            this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, estimate_view.WhereCondition);
            this.GridView1.Rebind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.GridView1.FilterMenu;
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
            string[] text;
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridView1.Columns.Count; i++)
                {
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.cellvalue_estimateno = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimateno = "true";
                    }
                    if (this.GridView1.MasterTableView.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.GridView1.MasterTableView.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.GridView1.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatedate")
                    {
                        this.cellvalue_estdate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "validfor")
                    {
                        this.cellvalue_validfor = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "est. status")
                    {
                        this.flag_estimatestatus = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimatestatus = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.cellvalue_status = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "order")
                    {
                        this.cellvalue_order = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_order = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "greeting")
                    {
                        this.cellvalue_greeting = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.cellvalue_estimator = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "defaulttemplate")
                    {
                        this.cellvalue_DefaultTemplate = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_DefaultTemplate = "true";
                    }

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "archive")
                    {
                        this.cellvalue_Archive = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Archive = "true";
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_custname = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "company")
                    {
                        this.cellvalue_company = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_company = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "priority")
                    {
                        this.cellvalue_priority = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_priority = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_sales = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactname")
                    {
                        this.cellvalue_contactname = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "header")
                    {
                        this.cellvalue_Header = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "footer")
                    {
                        this.cellvalue_footer = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_footer = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "comments")
                    {
                        this.cellvalue_comments = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_comments = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.cellvalue_estTitle = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofcomments")
                    {
                        this.cellvalue_ProofComment = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_ProofComment = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isconvertedtojob")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isarchive")
                    {
                        this.GridView1.Columns[i].Visible = false;
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "isdeletedjob")
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_estvalExcGST = "true";
                        this.cellvalue_estvalExcGST = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_custacountnumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatestatus")
                    {
                        this.cellvalue_estimatestatus = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_estimatestatus = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.cellvalue_AccountStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "ordernumber")
                    {
                        this.flag_custordernumber = "true";
                        this.cellvalue_custordernumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.flag_custordernumber = "true";
                        this.cellvalue_custordernumber = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "attentionid")
                    {
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymerntterms = "true";
                        this.cellvalue_paymentterms = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        if (Convert.ToBoolean(SettingsBasePage.settings_regionalsettings_select(this.CompanyID).Rows[0]["IsDisplayCostCentre"]))
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = true;
                            this.flag_costcenter = "true";
                            this.cellvalue_costcenter = this.GridView1.Columns[i].SortExpression.ToLower();
                        }
                        else
                        {
                            this.GridView1.MasterTableView.GetColumn("costcentre").Visible = false;
                        }
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.flag_estimattype = "true";
                        this.cellvalue_estimattype = this.GridView1.Columns[i].SortExpression.ToLower();
                        this.GridView1.Columns[i].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Type");
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "backorder")
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity1")
                    {
                        this.flag_ItemQTY1 = "true";
                        this.cellvalue_ItemQTY1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity2")
                    {
                        this.flag_ItemQTY2 = "true";
                        this.cellvalue_ItemQTY2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity3")
                    {
                        this.flag_ItemQTY3 = "true";
                        this.cellvalue_ItemQTY3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemquantity4")
                    {
                        this.flag_ItemQTY4 = "true";
                        this.cellvalue_ItemQTY4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax1")
                    {
                        this.flag_ItemValue_ExcTax1 = "true";
                        this.cellvalue_ItemValue_ExcTax1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax2")
                    {
                        this.flag_ItemValue_ExcTax2 = "true";
                        this.cellvalue_ItemValue_ExcTax2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax3")
                    {
                        this.flag_ItemValue_ExcTax3 = "true";
                        this.cellvalue_ItemValue_ExcTax3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueexctax4")
                    {
                        this.flag_ItemValue_ExcTax4 = "true";
                        this.cellvalue_ItemValue_ExcTax4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax1")
                    {
                        this.flag_ItemValue_IncTax1 = "true";
                        this.cellvalue_ItemValue_IncTax1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax2")
                    {
                        this.flag_ItemValue_IncTax2 = "true";
                        this.cellvalue_ItemValue_IncTax2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax3")
                    {
                        this.flag_ItemValue_IncTax3 = "true";
                        this.cellvalue_ItemValue_IncTax3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemvalueintax4")
                    {
                        this.flag_ItemValue_IncTax4 = "true";
                        this.cellvalue_ItemValue_IncTax4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue1")
                    {
                        this.flag_ItemTaxValue1 = "true";
                        this.cellvalue_ItemTaxValue1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue2")
                    {
                        this.flag_ItemTaxValue2 = "true";
                        this.cellvalue_ItemTaxValue2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue3")
                    {
                        this.flag_ItemTaxValue3 = "true";
                        this.cellvalue_ItemTaxValue3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemtaxvalue4")
                    {
                        this.flag_ItemTaxValue4 = "true";
                        this.cellvalue_ItemTaxValue4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup1")
                    {
                        this.flag_ItemCostPriceExcMarkup1 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup2")
                    {
                        this.flag_ItemCostPriceExcMarkup2 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup3")
                    {
                        this.flag_ItemCostPriceExcMarkup3 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup4")
                    {
                        this.flag_ItemCostPriceExcMarkup4 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue1")
                    {
                        this.flag_ItemMarkupValue1 = "true";
                        this.cellvalue_ItemMarkupValue1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue2")
                    {
                        this.flag_ItemMarkupValue2 = "true";
                        this.cellvalue_ItemMarkupValue2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue3")
                    {
                        this.flag_ItemMarkupValue3 = "true";
                        this.cellvalue_ItemMarkupValue3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemmarkupvalue4")
                    {
                        this.flag_ItemMarkupValue4 = "true";
                        this.cellvalue_ItemMarkupValue4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup1")
                    {
                        this.flag_ItemCostPriceIncMarkup1 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup2")
                    {
                        this.flag_ItemCostPriceIncMarkup2 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup3")
                    {
                        this.flag_ItemCostPriceIncMarkup3 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup4")
                    {
                        this.flag_ItemCostPriceIncMarkup4 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage1")
                    {
                        this.flag_ItemProfitMarginPercentage1 = "true";
                        this.cellvalue_ItemProfitMarginPercentage1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage2")
                    {
                        this.flag_ItemProfitMarginPercentage2 = "true";
                        this.cellvalue_ItemProfitMarginPercentage2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage3")
                    {
                        this.flag_ItemProfitMarginPercentage3 = "true";
                        this.cellvalue_ItemProfitMarginPercentage3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage4")
                    {
                        this.flag_ItemProfitMarginPercentage4 = "true";
                        this.cellvalue_ItemProfitMarginPercentage4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue1")
                    {
                        this.flag_ItemProfitMarginValue1 = "true";
                        this.cellvalue_ItemProfitMarginValue1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue2")
                    {
                        this.flag_ItemProfitMarginValue2 = "true";
                        this.cellvalue_ItemProfitMarginValue2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue3")
                    {
                        this.flag_ItemProfitMarginValue3 = "true";
                        this.cellvalue_ItemProfitMarginValue3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue4")
                    {
                        this.flag_ItemProfitMarginValue4 = "true";
                        this.cellvalue_ItemProfitMarginValue4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage1")
                    {
                        this.flag_ItemGrossProfitPercentage1 = "true";
                        this.cellvalue_ItemGrossProfitPercentage1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage2")
                    {
                        this.flag_ItemGrossProfitPercentage2 = "true";
                        this.cellvalue_ItemGrossProfitPercentage2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage3")
                    {
                        this.flag_ItemGrossProfitPercentage3 = "true";
                        this.cellvalue_ItemGrossProfitPercentage3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage4")
                    {
                        this.flag_ItemGrossProfitPercentage4 = "true";
                        this.cellvalue_ItemGrossProfitPercentage4 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue1")
                    {
                        this.flag_ItemGrossProfitValue1 = "true";
                        this.cellvalue_ItemGrossProfitValue1 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue2")
                    {
                        this.flag_ItemGrossProfitValue2 = "true";
                        this.cellvalue_ItemGrossProfitValue2 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue3")
                    {
                        this.flag_ItemGrossProfitValue3 = "true";
                        this.cellvalue_ItemGrossProfitValue3 = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue4")
                    {
                        this.flag_ItemGrossProfitValue4 = "true";
                        this.cellvalue_ItemGrossProfitValue4 = this.GridView1.Columns[i].SortExpression.ToLower();
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_ComapnyEmail = "true";
                        this.cellvalue_ComapnyEmail = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "artworkdate")
                    {
                        this.flag_ArtworkDate = "true";
                        this.cellvalue_ArtworkDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofdate")
                    {
                        this.flag_ProofDate = "true";
                        this.cellvalue_ProofDate = this.GridView1.Columns[i].SortExpression.ToLower();
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

                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "approvaldate")
                    {
                        this.flag_ApprovalDate = "true";
                        this.cellvalue_ApprovalDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "productiondate")
                    {
                        this.flag_ProductionDate = "true";
                        this.cellvalue_ProductionDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.flag_CompletionDate = "true";
                        this.cellvalue_CompletionDate = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.GridView1.Columns[i].SortExpression.ToLower();
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "customertype")
                    {
                        this.flag_CustomerType = "true";
                        this.cellvalue_CustomerType = this.GridView1.Columns[i].SortExpression.ToLower();
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
                    else if (this.GridView1.Columns[i].SortExpression.ToLower() == "proofstatus")
                    {
                        this.flag_ProofStatus = "true";
                        this.cellvalue_ProofStatus = this.GridView1.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                string str = string.Empty;
                string empty1 = string.Empty;
                string _proofID = string.Empty;
                if (!this.IsItemSelected)
                {
                    empty = ((DataRowView)e.Item.DataItem)[0].ToString();
                }
                else
                {
                    empty = ((DataRowView)e.Item.DataItem)[1].ToString();
                    str = ((DataRowView)e.Item.DataItem)[0].ToString();
                    empty1 = ((DataRowView)e.Item.DataItem)[2].ToString();
                }
                string str1 = string.Concat("estimate_summary_reeng.aspx?estid=", empty);
                if (this.IsItemSelected)
                {
                    str1 = string.Concat(str1, "&EstItemID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                }
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_EmailSent");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plhConvertJob");
                PlaceHolder placeHolder3 = (PlaceHolder)e.Item.FindControl("plh_Error");
                PlaceHolder placeHolder4 = (PlaceHolder)e.Item.FindControl("plhBackOrder");
                PlaceHolder placeHolderRowIcon = (PlaceHolder)e.Item.FindControl("plh_EstimateRowIcon");
                HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Item.FindControl("Id");
                PlaceHolder placeHolder5 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder6 = (PlaceHolder)e.Item.FindControl("plh_stockproduct");
                htmlInputCheckBox.Value = ((DataRowView)e.Item.DataItem)[0].ToString();
                string estimateSummaryUrl = string.Concat(this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", empty);
                string estimateListLockIcon = string.Concat(this.strImagepath, "estimate_list_lock.png");
                if (placeHolderRowIcon != null)
                {
                    placeHolderRowIcon.Controls.Add(new LiteralControl(string.Concat(
                        "<a href='", estimateSummaryUrl, "'><img src='", estimateListLockIcon,
                        "' title='", this.objLanguage.GetLanguageConversion("Estimate"),
                        "' class='viewicon_margin' /></a>")));
                }
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string languageConversion = string.Empty;
                string empty3 = string.Empty;
                string languageConversion1 = string.Empty;
                string str3 = string.Empty;
                string languageConversion2 = string.Empty;
                string empty4 = string.Empty;
                string languageConversion3 = string.Empty;
                string str4 = string.Empty;
                string languageConversion4 = string.Empty;
                empty3 = string.Concat(this.strImagepath, "quote-icon.png");
                languageConversion1 = this.objLanguage.GetLanguageConversion("Email_sent");
                str3 = string.Concat(this.strImagepath, "BackOrder.png");
                languageConversion2 = this.objLanguage.GetLanguageConversion("Back_Order");
                empty2 = string.Concat(this.strImagepath, "Attachment.PNG");
                languageConversion = this.objLanguage.GetLanguageConversion("Item_With_Attachment");
                str2 = string.Concat(this.strImagepath, "liner_j_icon.png");
                str4 = string.Concat(this.strImagepath, "Stock-Icon.jpg");
                languageConversion4 = this.objLanguage.GetLanguageConversion("Stock_Product");
                empty4 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion3 = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                string empty5 = string.Empty;
                string str5 = string.Empty;
                if (!this.IsItemSelected)
                {
                    DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", empty));
                    if ((int)dataRowArray.Length > 0)
                    {
                        str5 = dataRowArray[0]["ArtWork"].ToString();
                    }
                }
                else
                {
                    DataRow[] dataRowArray1 = this.dtArtwork.Select(string.Concat("EstimateItemID=", str));
                    if ((int)dataRowArray1.Length > 0)
                    {
                        str5 = dataRowArray1[0]["ArtWork"].ToString();
                    }
                }
                if (Convert.ToInt16(item["EmailCount"].Text) == 0)
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                else if (Convert.ToInt16(item["EmailCount"].Text) > 0)
                {
                    if (this.Session["SupplierQuote"].ToString().ToLower() != "true")
                    {
                        placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                    }
                    else
                    {
                        ControlCollection controls = placeHolder.Controls;
                        text = new string[] { "<img src='", empty3, "'  title='", languageConversion1, "' class='viewicon_margin' />" };
                        controls.Add(new LiteralControl(string.Concat(text)));
                    }
                }

                //start
                if (e.Item.OwnerTableView.Columns.FindByUniqueNameSafe("EstimateID") != null && e.Item.OwnerTableView.Columns.FindByUniqueNameSafe("EstimateItemID") != null)
                {
                    string Error_Count = "0";


                    //Error_Count = getErrorCount(Convert.ToInt32(item["EstimateID"].Text), Convert.ToInt32(item["EstimateItemID"].Text));
                    if (Convert.ToInt32(Error_Count) <= 0)
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                    }
                    else
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                    }
                }
                else
                {
                    if (Convert.ToInt16(item["ErrorCount"].Text) <= 0)
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                    }
                    else
                    {
                        placeHolder3.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "iconErrorSmall.png' border='0' title='Error' class='viewicon_margin' />")));
                    }
                }
                //end

                if (item["EstItemCoun"].Text != "0" || str5 != "")
                {
                    ControlCollection controlCollections = placeHolder1.Controls;
                    text = new string[] { "<img src='", empty2, "'  title='", languageConversion, "' style='cursor:pointer;' class='viewicon_margin'/>" };
                    controlCollections.Add(new LiteralControl(string.Concat(text)));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls1 = placeHolder5.Controls;
                    text = new string[] { "<img src='", empty4, "'  title='", languageConversion3, "' class='viewicon_margin' />" };
                    controls1.Add(new LiteralControl(string.Concat(text)));
                }
                if (Convert.ToInt16(item["IsStockProduct"].Text) == 1)
                {
                    ControlCollection controlCollections1 = placeHolder6.Controls;
                    text = new string[] { "<img src='", str4, "'  title='", languageConversion4, "' class='viewicon_margin' />" };
                    controlCollections1.Add(new LiteralControl(string.Concat(text)));
                }
                if (item["ISDeletedJob"].Text != "0")
                {
                    ControlCollection controls2 = placeHolder2.Controls;
                    text = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", empty, "><img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' /></a>" };
                    controls2.Add(new LiteralControl(string.Concat(text)));
                }
                else if (item["IsConvertedToJob"].Text != "1")
                {
                    ControlCollection controlCollections2 = placeHolder2.Controls;
                    text = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", empty, "><img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' /></a>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(text)));
                }
                else if (!this.IsItemSelected)
                {
                    placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", str2, "' title = 'Job Raised' style='cursor:pointer;' class='viewicon_margin' />")));
                }
                else
                {
                    ControlCollection controls3 = placeHolder2.Controls;
                    text = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?estid=", empty, "&jID=", empty1, "><img src='", str2, "' title = 'Job Raised' style='cursor:pointer;' class='viewicon_margin' /></a>" };
                    controls3.Add(new LiteralControl(string.Concat(text)));
                }
                if (Convert.ToInt16(item["BackOrder"].Text) != 0)
                {
                    ControlCollection controlCollections3 = placeHolder4.Controls;
                    text = new string[] { "<img src='", str3, "'  title='", languageConversion2, "' class='viewicon_margin'  />" };
                    controlCollections3.Add(new LiteralControl(string.Concat(text)));
                }
                else
                {
                    placeHolder4.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' style='width:0px' />")));
                }
                if (!this.IsItemSelected)
                {
                    TableCell tableCell = item["estimatenumber"];
                    text = new string[] { "<a href=", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", empty, ">", item["estimatenumber"].Text, "</a>" };
                    tableCell.Text = string.Concat(text);
                }
                else
                {
                    TableCell item1 = item["estimatenumber"];
                    text = new string[] { "<a href=", this.strSitepath, "estimates/estimate_summary_reeng.aspx?estid=", empty, "&EstItemID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["estimatenumber"].Text, "</a>" };
                    item1.Text = string.Concat(text);
                }
                if (this.flag_estval == "true")
                {
                    item[this.cellvalue_estval].Attributes.Add("align", "right");
                    item[this.cellvalue_estval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estval].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estval].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estval].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_estvalExcGST == "true")
                {
                    item[this.cellvalue_estvalExcGST].Attributes.Add("align", "right");
                    item[this.cellvalue_estvalExcGST].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estvalExcGST].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estvalExcGST].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estvalExcGST].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_ExcTax1 == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_ExcTax1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_ExcTax2 == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_ExcTax2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_ExcTax3 == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_ExcTax3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_ExcTax4 == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_ExcTax4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax1 == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_IncTax1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax2 == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_IncTax2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax3 == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_IncTax3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax4 == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemValue_IncTax4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue1 == "true")
                {
                    item[this.cellvalue_ItemTaxValue1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTaxValue1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue2 == "true")
                {
                    item[this.cellvalue_ItemTaxValue2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTaxValue2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue3 == "true")
                {
                    item[this.cellvalue_ItemTaxValue3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTaxValue3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue4 == "true")
                {
                    item[this.cellvalue_ItemTaxValue4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTaxValue4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup1 == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup2 == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup3 == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup4 == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue1 == "true")
                {
                    item[this.cellvalue_ItemMarkupValue1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMarkupValue1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue2 == "true")
                {
                    item[this.cellvalue_ItemMarkupValue2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMarkupValue2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue3 == "true")
                {
                    item[this.cellvalue_ItemMarkupValue3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMarkupValue3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue4 == "true")
                {
                    item[this.cellvalue_ItemMarkupValue4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemMarkupValue4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup1 == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup2 == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup3 == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup4 == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage1 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage2 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage3 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage4 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue1 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginValue1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue2 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginValue2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue3 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginValue3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue4 == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProfitMarginValue4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage1 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage2 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage3 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage4 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue1 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitValue1].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue1].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue1].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue2 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitValue2].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue2].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue2].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue3 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitValue3].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue3].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue3].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue4 == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemGrossProfitValue4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    
                    TableCell tableCell1 = item[this.cellvalue_ItemStatus];
                    text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    tableCell1.Text = string.Concat(text);
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
                    TableCell item2 = item[this.cellvalue_ItemTitle];
                    text = new string[] { "<div style='width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemTitle].Text, "</div>" };
                    item2.Text = string.Concat(text);
                }
                if (this.flag_ItemQTY1 == "true")
                {
                    item[this.cellvalue_ItemQTY1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemQTY1].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY2 == "true")
                {
                    item[this.cellvalue_ItemQTY2].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemQTY2].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY3 == "true")
                {
                    item[this.cellvalue_ItemQTY3].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemQTY3].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY4 == "true")
                {
                    item[this.cellvalue_ItemQTY4].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemQTY4].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemAccCode == "true")
                {
                    item[this.cellvalue_ItemAccCode].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemAccCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemAccCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_estdate == "true")
                {
                    item[this.cellvalue_estdate].Attributes.Add("align", "center");
                    item[this.cellvalue_estdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_validfor == "true")
                {
                    item[this.cellvalue_validfor].Attributes.Add("align", "right");
                    item[this.cellvalue_validfor].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_validfor].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_validfor];
                    text = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_validfor].Text, "</div>" };
                    tableCell2.Text = string.Concat(text);
                }
                if (this.flag_estimatestatus == "true")
                {
                    item[this.cellvalue_estimatestatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estimatestatus].Style.Add("cursor", "pointer");
                    item[this.cellvalue_estimatestatus].Style.Add("background-color", item["StatusColorCode"].Text); // Add this line
                    TableCell item3 = item[this.cellvalue_estimatestatus];
                    text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_estimatestatus].Text, "</div>" };
                    item3.Text = string.Concat(text);
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_AccountStatus];
                    text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_AccountStatus].Text, "</div>" };
                    tableCell3.Text = string.Concat(text);
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    item[this.cellvalue_status].Style.Add("background-color", item["itemStatusColorCode"].Text); // Add this line
                    TableCell item4 = item[this.cellvalue_status];
                    text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_status].Text, "</div>" };
                    item4.Text = string.Concat(text);
                }
                if (this.flag_order == "true")
                {
                    item[this.cellvalue_order].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_order].Style.Add("cursor", "pointer");
                    TableCell tableCell4 = item[this.cellvalue_order];
                    text = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_order].Text, "</div>" };
                    tableCell4.Text = string.Concat(text);
                }
                if (this.flag_greeting == "true")
                {
                    item[this.cellvalue_greeting].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_greeting].Style.Add("cursor", "pointer");
                    TableCell item5 = item[this.cellvalue_greeting];
                    text = new string[] { "<div style='width: ", this.type3, ";min-width: ", this.type3, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_greeting].Text, "</div>" };
                    item5.Text = string.Concat(text);
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estimator].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                    TableCell tableCell5 = item[this.cellvalue_estimator];
                    text = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_estimator].Text, "</div>" };
                    tableCell5.Text = string.Concat(text);
                }
                if (this.flag_custname == "true")
                {
                    item[this.cellvalue_custname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_custname].Style.Add("cursor", "pointer");
                }
                if (this.flag_company == "true")
                {
                    item[this.cellvalue_company].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_company].Style.Add("cursor", "pointer");
                }
                if (this.flag_priority == "true")
                {

                    item[this.cellvalue_priority].Attributes.Add("align", "center");
                    item[this.cellvalue_priority].Attributes.Add("class", "hyperlinkNoUnderline");

                    //item[this.cellvalue_ApprovalDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_priority].Attributes.Add("onclick",
                             string.Concat("javascript:OnPriorityClick('",
                             empty, "','",
                             string.IsNullOrEmpty(item[this.cellvalue_priority].Text.Replace("&nbsp;","")) ? "-" : item[this.cellvalue_priority].Text.Replace("&nbsp;", ""),
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
               
                if (this.flag_sales == "true")
                {
                    item[this.cellvalue_sales].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_sales].Style.Add("cursor", "pointer");
                    TableCell item6 = item[this.cellvalue_sales];
                    text = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_sales].Text, "</div>" };
                    item6.Text = string.Concat(text);
                }
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                }
                if (this.flag_Header == "true")
                {
                    item[this.cellvalue_Header].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Header].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Header].ToolTip = item[this.cellvalue_Header].Text;
                    TableCell tableCell6 = item[this.cellvalue_Header];
                    text = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Header].Text, "</div>" };
                    tableCell6.Text = string.Concat(text);
                }
                if (this.flag_footer == "true")
                {
                    item[this.cellvalue_footer].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_footer].Style.Add("cursor", "pointer");
                    item[this.cellvalue_footer].ToolTip = item[this.cellvalue_footer].Text;
                    TableCell item7 = item[this.cellvalue_footer];
                    text = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_footer].Text, "</div>" };
                    item7.Text = string.Concat(text);
                }
                if (this.flag_comments == "true")
                {
                    ePrintUtilities.Utilities.SetGridViewItemProperties(item, this.cellvalue_comments, "EstimateID");
                   
                }

                if (this.flag_DefaultTemplate == "true")
                {
                    string estimateId = item["EstimateID"].Text;
                    string customerid= item["custid"].Text;
                    string targetUrl = $"{this.strSitepath}estimates/templates_view1.aspx?sectionid={customerid}&sectionname=Estimate&type=Customer&page=Estimate&EstID={estimateId}&GenPdf=all&customtype=preview";

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
                        AlternateText = "Comment",
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
                    string targetUrl = $"{this.strSitepath}estimates/templates_view1.aspx?sectionid={customerid}&sectionname=Estimate&type=Customer&page=Estimate&EstID={estimateId}&GenPdf=all&customtype=choosetemp";

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
                        AlternateText = "View Estimate",
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
                    string targetUrl = $"{this.strSitepath}estimates/templates_view1.aspx?sectionid={customerid}&sectionname=Estimate&type=Customer&page=Estimate&EstID={estimateId}&GenPdf=all&customtype=download";

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
                        AlternateText = "Download Estimate",
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
                    string estimateId = item["EstimateID"].Text;
                    
                    string type = "archive"; // or "unarchive", depending on your logic

                    string estimateitemid = string.Empty;

                    if (this.IsItemSelected)
                    {
                        estimateitemid = item["EstimateitemID"].Text;
                    }

                    item[this.cellvalue_Archive].Attributes.Add("align", "center");
                    item[this.cellvalue_Archive].Attributes.Add("class", "hyperlinkNoUnderline");
                    item[this.cellvalue_Archive].Style.Add("cursor", "pointer");

                    // Clear existing controls
                    item[this.cellvalue_Archive].Controls.Clear();

                    // Create HyperLink control
                    HtmlGenericControl link = new HtmlGenericControl("a");
                    link.Attributes["href"] = "javascript:void(0);"; // prevent navigation
                    link.Attributes["onclick"] = $"CheckOne('{type}', '{estimateId}','{estimateitemid}');"; // call JS function
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



                if (this.flag_estTitle == "true")
                {
                    item[this.cellvalue_estTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estTitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_quantity1 == "true")
                {
                    item[this.cellvalue_quantity1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_quantity1].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity1].Attributes.Add("align", "right");
                    TableCell tableCell7 = item[this.cellvalue_quantity1];
                    text = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity1].Text, "</div>" };
                    tableCell7.Text = string.Concat(text);
                }
                if (this.flag_quantity2 == "true")
                {
                    item[this.cellvalue_quantity2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_quantity2].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity2].Attributes.Add("align", "right");
                    TableCell item8 = item[this.cellvalue_quantity2];
                    text = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity2].Text, "</div>" };
                    item8.Text = string.Concat(text);
                }
                if (this.flag_quantity3 == "true")
                {
                    item[this.cellvalue_quantity3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_quantity3].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity3].Attributes.Add("align", "right");
                    TableCell tableCell8 = item[this.cellvalue_quantity3];
                    text = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity3].Text, "</div>" };
                    tableCell8.Text = string.Concat(text);
                }
                if (this.flag_quantity4 == "true")
                {
                    item[this.cellvalue_quantity4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_quantity4].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity4].Attributes.Add("align", "right");
                    TableCell item9 = item[this.cellvalue_quantity4];
                    text = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity4].Text, "</div>" };
                    item9.Text = string.Concat(text);
                }
                if (this.flag_paymerntterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_custordernumber == "true")
                {
                    item[this.cellvalue_custordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_custordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_custacountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_custacountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                }
                if (this.flag_costcenter == "true")
                {
                    item[this.cellvalue_costcenter].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_costcenter].Style.Add("cursor", "pointer");
                }
                if (this.flag_estimattype == "true")
                {
                    item[this.cellvalue_estimattype].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_estimattype].Style.Add("cursor", "pointer");
                }
                if (this.flag_Height == "true")
                {
                    item[this.cellvalue_Height].Attributes.Add("align", "right");
                    item[this.cellvalue_Height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Height].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Height].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Height].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_Width == "true")
                {
                    item[this.cellvalue_Width].Attributes.Add("align", "right");
                    item[this.cellvalue_Width].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Width].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_Width].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Width].Text), 0, "", false, false, true);
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
                    item[this.cellvalue_ItemDescription].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemDescription].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemColour == "true")
                {
                    item[this.cellvalue_ItemColour].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemColour].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemSize == "true")
                {
                    item[this.cellvalue_ItemSize].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemSize].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemArtwork == "true")
                {
                    item[this.cellvalue_ItemArtwork].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemArtwork].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemDelivery == "true")
                {
                    item[this.cellvalue_ItemDelivery].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemDelivery].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemFinishing == "true")
                {
                    item[this.cellvalue_ItemFinishing].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemFinishing].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemProofs == "true")
                {
                    item[this.cellvalue_ItemProofs].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemProofs].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemPacking == "true")
                {
                    item[this.cellvalue_ItemPacking].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemPacking].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemNotes == "true")
                {
                    item[this.cellvalue_ItemNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemNotes].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    item[this.cellvalue_ItemTermsInstructions].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ItemTermsInstructions].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactEmail == "true")
                {
                    item[this.cellvalue_ContactEmail].Attributes.Add("align", "left");
                    item[this.cellvalue_ContactEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ContactEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ComapnyEmail == "true")
                {
                    item[this.cellvalue_ComapnyEmail].Attributes.Add("align", "left");
                    item[this.cellvalue_ComapnyEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ComapnyEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactPhone == "true")
                {
                    item[this.cellvalue_ContactPhone].Attributes.Add("align", "left");
                    item[this.cellvalue_ContactPhone].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ContactPhone].Style.Add("cursor", "pointer");
                }
                if (this.flag_ArtworkDate == "true")
                {
                    item[this.cellvalue_ArtworkDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ArtworkDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ArtworkDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ProofDate == "true")
                {
                    item[this.cellvalue_ProofDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ProofDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ProofDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate1 == "true")
                {
                    item[this.cellvalue_CustomDate1].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate1].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomDate2 == "true")
                {
                    item[this.cellvalue_CustomDate2].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate2].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate3 == "true")
                {
                    item[this.cellvalue_CustomDate3].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate3].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate4 == "true")
                {
                    item[this.cellvalue_CustomDate4].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate4].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomDate5 == "true")
                {
                    item[this.cellvalue_CustomDate5].Attributes.Add("align", "center");
                    item[this.cellvalue_CustomDate5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CustomDate5].Style.Add("cursor", "pointer");
                }

                if (this.flag_ApprovalDate == "true")
                {
                    item[this.cellvalue_ApprovalDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ApprovalDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ApprovalDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ProductionDate == "true")
                {
                    item[this.cellvalue_ProductionDate].Attributes.Add("align", "left");
                    item[this.cellvalue_ProductionDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_ProductionDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CompletionDate == "true")
                {
                    item[this.cellvalue_CompletionDate].Attributes.Add("align", "center");
                    item[this.cellvalue_CompletionDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_CompletionDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_DeliveryDate == "true")
                {
                    item[this.cellvalue_DeliveryDate].Attributes.Add("align", "center");
                    item[this.cellvalue_DeliveryDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_DeliveryDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_SinceEmailed == "true")
                {
                    item[this.cellvalue_SinceEmailed].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()))
                        if ( Convert.ToInt32(item["sinceEmailed"].Text) >= Convert.ToInt32(item["SinceEmailCount"].Text.Replace("&nbsp;", "").Trim()) && item["sinceEmailed"].Text != "0")
                            item[this.cellvalue_SinceEmailed].Style.Add("background-color", "#E64557"); // Add this line
                   
                    if (item["isAnyEmailed"].Text=="0")
                        item[this.cellvalue_SinceEmailed].Text = "N/A";

                    item[this.cellvalue_SinceEmailed].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceEmailed].Style.Add("cursor", "pointer");
                }
                if (this.flag_SinceStatusUpdate == "true")
                {
                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("align", "center");

                    if (!String.IsNullOrEmpty(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim()))
                        if (Convert.ToInt32(item["sinceStatusUpdate"].Text) >= Convert.ToInt32(item["SinceStatusCount"].Text.Replace("&nbsp;", "").Trim())   && item["sinceStatusUpdate"].Text != "0")
                            item[this.cellvalue_SinceStatusUpdate].Style.Add("background-color", "#E64557"); // Add this line

                    item[this.cellvalue_SinceStatusUpdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_SinceStatusUpdate].Style.Add("cursor", "pointer");
                }

                if (this.flag_CustomerType == "true")
                {
                    if (item[this.cellvalue_CustomerType].Text.Length > 30)
                    {
                        item[this.cellvalue_CustomerType].ToolTip = item[this.cellvalue_CustomerType].Text;
                        item[this.cellvalue_CustomerType].Text = string.Concat(item[this.cellvalue_CustomerType].Text.Substring(0, 30), "...");
                    }
                    item[this.cellvalue_CustomerType].Attributes.Add("align", "left");
                    item[this.cellvalue_CustomerType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
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
                    item[this.cellvalue_Address1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
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
                    item[this.cellvalue_Address2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
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
                    item[this.cellvalue_Address3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
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
                    item[this.cellvalue_Address4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
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
                    item[this.cellvalue_Address5].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str1, "');"));
                    item[this.cellvalue_Address5].Style.Add("cursor", "pointer");
                }
                if (this.flag_ProofStatus == "true")
                {
                    _proofID = ((DataRowView)e.Item.DataItem)[3].ToString();
                    string proofURL = string.Concat(global.sitePath(), "Proofs/Proof_summary.aspx?estid=", empty, "&EstItemID=", str, "&ProofID=", _proofID);
                    item[this.cellvalue_ProofStatus].Attributes.Add("align", "left");
                    if (!string.IsNullOrEmpty(_proofID))
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
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_estimateno == "true")
                {
                    TextBox textBox = (e.Item as GridFilteringItem)[this.cellvalue_estimateno].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estimateno)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estimateno)].ToString() == "")
                    {
                        textBox.Text = "";
                    }
                }
                if (this.flag_custname == "true")
                {
                    TextBox textBox1 = (e.Item as GridFilteringItem)[this.cellvalue_custname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_custname)] != null && this.Session[string.Concat("estimate_", this.cellvalue_custname)].ToString() == "")
                    {
                        textBox1.Text = "";
                    }
                }
                if (this.flag_estTitle == "true")
                {
                    TextBox textBox2 = (e.Item as GridFilteringItem)[this.cellvalue_estTitle].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estTitle)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estTitle)].ToString() == "")
                    {
                        textBox2.Text = "";
                    }
                }
                if (this.flag_greeting == "true")
                {
                    TextBox textBox3 = (e.Item as GridFilteringItem)[this.cellvalue_greeting].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_greeting)] != null && this.Session[string.Concat("estimate_", this.cellvalue_greeting)].ToString() == "")
                    {
                        textBox3.Text = "";
                    }
                }
                if (this.flag_company == "true")
                {
                    TextBox textBox4 = (e.Item as GridFilteringItem)[this.cellvalue_company].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_company)] != null && this.Session[string.Concat("estimate_", this.cellvalue_company)].ToString() == "")
                    {
                        textBox4.Text = "";
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
                if (this.flag_Header == "true")
                {
                    TextBox textBox5 = (e.Item as GridFilteringItem)[this.cellvalue_Header].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Header)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Header)].ToString() == "")
                    {
                        textBox5.Text = "";
                    }
                }
                if (this.flag_footer == "true")
                {
                    TextBox textBox6 = (e.Item as GridFilteringItem)[this.cellvalue_footer].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_footer)] != null && this.Session[string.Concat("estimate_", this.cellvalue_footer)].ToString() == "")
                    {
                        textBox6.Text = "";
                    }
                }
                if (this.flag_comments == "true")
                {
                    TextBox textBoxComments = (e.Item as GridFilteringItem)[this.cellvalue_comments].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_comments)] != null && this.Session[string.Concat("estimate_", this.cellvalue_comments)].ToString() == "")
                    {
                        textBoxComments.Text = "";
                    }
                }

                if (this.flag_sales == "true")
                {
                    TextBox textBox7 = (e.Item as GridFilteringItem)[this.cellvalue_sales].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_sales)] != null && this.Session[string.Concat("estimate_", this.cellvalue_sales)].ToString() == "")
                    {
                        textBox7.Text = "";
                    }
                }
                if (this.flag_custordernumber == "true")
                {
                    TextBox textBox8 = (e.Item as GridFilteringItem)[this.cellvalue_custordernumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_custordernumber)] != null && this.Session[string.Concat("estimate_", this.cellvalue_custordernumber)].ToString() == "")
                    {
                        textBox8.Text = "";
                    }
                }
                if (this.flag_estimatestatus == "true")
                {
                    TextBox textBox9 = (e.Item as GridFilteringItem)[this.cellvalue_estimatestatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estimatestatus)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estimatestatus)].ToString() == "")
                    {
                        textBox9.Text = "";
                    }
                }
                if (this.flag_AccountStatus == "true")
                {
                    TextBox item10 = (e.Item as GridFilteringItem)[this.cellvalue_AccountStatus].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_AccountStatus)] != null && this.Session[string.Concat("estimate_", this.cellvalue_AccountStatus)].ToString() == "")
                    {
                        item10.Text = "";
                    }
                }
                if (this.flag_status == "true")
                {
                    TextBox textBox10 = (e.Item as GridFilteringItem)[this.cellvalue_status].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_status)] != null && this.Session[string.Concat("estimate_", this.cellvalue_status)].ToString() == "")
                    {
                        textBox10.Text = "";
                    }
                }
                if (this.flag_contactname == "true")
                {
                    TextBox item11 = (e.Item as GridFilteringItem)[this.cellvalue_contactname].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_contactname)] != null && this.Session[string.Concat("estimate_", this.cellvalue_contactname)].ToString() == "")
                    {
                        item11.Text = "";
                    }
                }
                if (this.flag_estimator == "true")
                {
                    TextBox textBox11 = (e.Item as GridFilteringItem)[this.cellvalue_estimator].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estimator)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estimator)].ToString() == "")
                    {
                        textBox11.Text = "";
                    }
                }
                if (this.flag_referredby == "true")
                {
                    TextBox item12 = (e.Item as GridFilteringItem)[this.cellvalue_referredby].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_referredby)] != null && this.Session[string.Concat("estimate_", this.cellvalue_referredby)].ToString() == "")
                    {
                        item12.Text = "";
                    }
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    TextBox textBox12 = (e.Item as GridFilteringItem)[this.cellvalue_custacountnumber].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_custacountnumber)] != null && this.Session[string.Concat("estimate_", this.cellvalue_custacountnumber)].ToString() == "")
                    {
                        textBox12.Text = "";
                    }
                }
                if (this.flag_paymerntterms == "true")
                {
                    TextBox item13 = (e.Item as GridFilteringItem)[this.cellvalue_paymentterms].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_paymentterms)] != null && this.Session[string.Concat("estimate_", this.cellvalue_paymentterms)].ToString() == "")
                    {
                        item13.Text = "";
                    }
                }
                if (this.flag_costcenter == "true")
                {
                    TextBox textBox13 = (e.Item as GridFilteringItem)[this.cellvalue_costcenter].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_costcenter)] != null && this.Session[string.Concat("estimate_", this.cellvalue_costcenter)].ToString() == "")
                    {
                        textBox13.Text = "";
                    }
                }
                if (this.flag_estval == "true")
                {
                    gridFilteringItem[this.cellvalue_estval].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item14 = (e.Item as GridFilteringItem)[this.cellvalue_estval].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estval)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estval)].ToString() == "")
                    {
                        item14.Text = "";
                    }
                }
                if (this.flag_estvalExcGST == "true")
                {
                    gridFilteringItem[this.cellvalue_estvalExcGST].HorizontalAlign = HorizontalAlign.Right;
                    TextBox textBox14 = (e.Item as GridFilteringItem)[this.cellvalue_estvalExcGST].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estvalExcGST)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estvalExcGST)].ToString() == "")
                    {
                        textBox14.Text = "";
                    }
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox item15 = (e.Item as GridFilteringItem)[this.cellvalue_createddate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_createddate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_createddate)].ToString() == "")
                    {
                        item15.Text = "";
                    }
                }
                if (this.flag_estdate == "true")
                {
                    gridFilteringItem[this.cellvalue_estdate].HorizontalAlign = HorizontalAlign.Center;
                    TextBox textBox15 = (e.Item as GridFilteringItem)[this.cellvalue_estdate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estdate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estdate)].ToString() == "")
                    {
                        textBox15.Text = "";
                    }
                }
                if (this.flag_validfor == "true")
                {
                    gridFilteringItem[this.cellvalue_validfor].HorizontalAlign = HorizontalAlign.Right;
                    TextBox item16 = (e.Item as GridFilteringItem)[this.cellvalue_validfor].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_validfor)] != null && this.Session[string.Concat("estimate_", this.cellvalue_validfor)].ToString() == "")
                    {
                        item16.Text = "";
                    }
                }
                if (this.flag_estimattype == "true")
                {
                    gridFilteringItem[this.cellvalue_estimattype].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox16 = (e.Item as GridFilteringItem)[this.cellvalue_estimattype].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_estimattype)] != null && this.Session[string.Concat("estimate_", this.cellvalue_estimattype)].ToString() == "")
                    {
                        textBox16.Text = "";
                    }
                }
                if (this.flag_ContactPhone == "true")
                {
                    TextBox item17 = (e.Item as GridFilteringItem)[this.cellvalue_ContactPhone].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ContactPhone)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ContactPhone)].ToString() == "")
                    {
                        item17.Text = "";
                    }
                }
                if (this.flag_ArtworkDate == "true")
                {
                    TextBox textBox17 = (e.Item as GridFilteringItem)[this.cellvalue_ArtworkDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ArtworkDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ArtworkDate)].ToString() == "")
                    {
                        textBox17.Text = "";
                    }
                }
                if (this.flag_ProofDate == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_ProofDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ProofDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ProofDate)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate1 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomDate1)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomDate1)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate2 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomDate2)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomDate2)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate3 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomDate3)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomDate3)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate4 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomDate4)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomDate4)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_CustomDate5 == "true")
                {
                    TextBox item18 = (e.Item as GridFilteringItem)[this.cellvalue_CustomDate5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomDate5)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomDate5)].ToString() == "")
                    {
                        item18.Text = "";
                    }
                }
                if (this.flag_ApprovalDate == "true")
                {
                    TextBox textBox18 = (e.Item as GridFilteringItem)[this.cellvalue_ApprovalDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ApprovalDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ApprovalDate)].ToString() == "")
                    {
                        textBox18.Text = "";
                    }
                }
                if (this.flag_ProductionDate == "true")
                {
                    TextBox item19 = (e.Item as GridFilteringItem)[this.cellvalue_ProductionDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ProductionDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ProductionDate)].ToString() == "")
                    {
                        item19.Text = "";
                    }
                }
                if (this.flag_CompletionDate == "true")
                {
                    TextBox textBox19 = (e.Item as GridFilteringItem)[this.cellvalue_CompletionDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CompletionDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CompletionDate)].ToString() == "")
                    {
                        textBox19.Text = "";
                    }
                }
                if (this.flag_DeliveryDate == "true")
                {
                    TextBox item20 = (e.Item as GridFilteringItem)[this.cellvalue_DeliveryDate].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_DeliveryDate)] != null && this.Session[string.Concat("estimate_", this.cellvalue_DeliveryDate)].ToString() == "")
                    {
                        item20.Text = "";
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
                if (this.flag_ComapnyEmail == "true")
                {
                    TextBox textBox20 = (e.Item as GridFilteringItem)[this.cellvalue_ComapnyEmail].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_ComapnyEmail)] != null && this.Session[string.Concat("estimate_", this.cellvalue_ComapnyEmail)].ToString() == "")
                    {
                        textBox20.Text = "";
                    }
                }
                if (this.flag_CustomerType == "true")
                {
                    TextBox item21 = (e.Item as GridFilteringItem)[this.cellvalue_CustomerType].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_CustomerType)] != null && this.Session[string.Concat("estimate_", this.cellvalue_CustomerType)].ToString() == "")
                    {
                        item21.Text = "";
                    }
                }
                if (this.flag_quantity1 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity2 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity3 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_quantity4 == "true")
                {
                    gridFilteringItem[this.cellvalue_quantity4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_Address1 == "true")
                {
                    gridFilteringItem[this.cellvalue_Address1].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox21 = (e.Item as GridFilteringItem)[this.cellvalue_Address1].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Address1)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Address1)].ToString() == "")
                    {
                        textBox21.Text = "";
                    }
                }
                if (this.flag_Address2 == "true")
                {
                    gridFilteringItem[this.cellvalue_Address2].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item22 = (e.Item as GridFilteringItem)[this.cellvalue_Address2].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Address2)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Address2)].ToString() == "")
                    {
                        item22.Text = "";
                    }
                }
                if (this.flag_Address3 == "true")
                {
                    gridFilteringItem[this.cellvalue_Address3].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox22 = (e.Item as GridFilteringItem)[this.cellvalue_Address3].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Address3)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Address3)].ToString() == "")
                    {
                        textBox22.Text = "";
                    }
                }
                if (this.flag_Address4 == "true")
                {
                    gridFilteringItem[this.cellvalue_Address4].HorizontalAlign = HorizontalAlign.Left;
                    TextBox item23 = (e.Item as GridFilteringItem)[this.cellvalue_Address4].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Address4)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Address4)].ToString() == "")
                    {
                        item23.Text = "";
                    }
                }
                if (this.flag_Address5 == "true")
                {
                    gridFilteringItem[this.cellvalue_Address5].HorizontalAlign = HorizontalAlign.Left;
                    TextBox textBox23 = (e.Item as GridFilteringItem)[this.cellvalue_Address5].Controls[0] as TextBox;
                    if (this.Session[string.Concat("estimate_", this.cellvalue_Address5)] != null && this.Session[string.Concat("estimate_", this.cellvalue_Address5)].ToString() == "")
                    {
                        textBox23.Text = "";
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
                if (this.flag_ItemQTY1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemQTY4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemQTY4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_ExcTax4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_ExcTax4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemValue_IncTax4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemValue_IncTax4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemTaxValue4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemTaxValue4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceExcMarkup4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceExcMarkup4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemMarkupValue4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemMarkupValue4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemCostPriceIncMarkup4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemCostPriceIncMarkup4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginPercentage4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginPercentage4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemProfitMarginValue4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemProfitMarginValue4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitPercentage4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitPercentage4].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue1 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue1].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue2 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue2].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue3 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue3].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_ItemGrossProfitValue4 == "true")
                {
                    gridFilteringItem[this.cellvalue_ItemGrossProfitValue4].HorizontalAlign = HorizontalAlign.Right;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.objBase.ReturnRoles_Privileges_Tabs("estimates", "isview", "");
            this.GridView1.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_to_display");
            this.Archive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Archive_Row_Selection_Alert");
            this.Delete_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert");
            this.UnArchive_Row_Selection_Alert = this.objLanguage.GetLanguageConversion("UnArchive_Row_Selection_Alert");
            this.lblArchive.Text = this.objLanguage.GetLanguageConversion("Archive_Selected");
            this.lblDelete.Text = this.objLanguage.GetLanguageConversion("Detele_Selected");
            this.lblUnArchive.Text = this.objLanguage.GetLanguageConversion("UnArchive_Selected");
            this.divunarchive.Style.Add("display", "none");
            if (!base.IsPostBack)
            {
                this.bindRadlistStatus();
                this.hdnSelectedChkfrmGrid.Value = "";
                this.edit_estViewID.Value = "";
                this.hdnIDs.Value = "";
            }
         
            if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isdelete", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divDelete.Visible = true;
            }
            else
            {
                this.divDelete.Visible = false;
            }
            if (this.objBase.ReturnRoles_Privileges_ForGrid("estimates", "isarchive", this.Page.Request.Url.ToString()).Trim().ToLower() != "false")
            {
                this.divarchive.Visible = true;
                this.divunarchive.Visible = true;
            }
            else
            {
                this.divarchive.Visible = false;
                this.divunarchive.Visible = false;
            }
            global.pageName = "estimate";
            global.pgName = "";
            this.gloobj.setpagename("estimate");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "estimate";
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
            this.DateFormat = this.Session["Dateformat"].ToString();

            foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            if (!base.IsPostBack)
            {
                this.GridView1.PageSize = 50;
                if (base.Request.Params["suc"] != null)
                {
                    if (base.Request.Params["suc"].ToString().ToLower() == "cop")
                    {
                        long num = Convert.ToInt64(base.Request.Params["estid"]);
                        BaseClass baseClass = this.objBase;
                        object[] languageConversion = new object[] { this.objLanguage.GetLanguageConversion("Estimate_Copied_Successfully"), "<a href='../estimates/estimate_summary_reeng.aspx?estid=", num, "'>", this.objLanguage.GetLanguageConversion("Click_here_to_view"), "</a>" };
                        baseClass.Message_Display(string.Concat(languageConversion), "successfulMsg", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "arc")
                    {
                        this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Archived_Successfully"), "successfulMsg", this.plhMessage);
                    }
                    if (base.Request.Params["suc"].ToString().ToLower() == "del")
                    {
                        this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Estimate_Deleted_Successfully"), "successfulMsg", this.plhMessage);
                    }
                }
            }
            for (int i = 0; i < this.RadListBox1.Items.Count; i++)
            {
                AttributeCollection attributes = this.RadListBox1.Items[i].Attributes;
                string[] clientID = new string[] { "javascript:SelectGriditems('", this.GridView1.ClientID, "','id','", this.hdnSelectedChkfrmGrid.ClientID, "');" };
                attributes.Add("onclick", string.Concat(clientID));
            }
            base.Title = this.objLanguage.convert(global.pageTitle("Estimate View", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            base.Navigation_Path(string.Concat("<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>"), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Estimate_View")));
            BaseClass baseClass1 = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass1.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
           // string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "view");
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "estimates_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (this.Session["EstViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(this.Session["EstViewID"]);
            }
            if (!base.IsPostBack)
            {
                foreach (DataRow row in this.objComp.Clientaddresslabels(this.CompanyID).Rows)
                {
                    if (row["addresslkey"].ToString().ToLower() == "address1")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress1.Value = this.objLanguage.GetLanguageConversion("Address1");
                        }
                        else
                        {
                            this.hdnaddress1.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address2")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress2.Value = this.objLanguage.GetLanguageConversion("Address2");
                        }
                        else
                        {
                            this.hdnaddress2.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address3")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress3.Value = this.objLanguage.GetLanguageConversion("Address3");
                        }
                        else
                        {
                            this.hdnaddress3.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() == "address4")
                    {
                        if (row["addressvalue"].ToString() == "")
                        {
                            this.hdnaddress4.Value = this.objLanguage.GetLanguageConversion("Address4");
                        }
                        else
                        {
                            this.hdnaddress4.Value = row["addressvalue"].ToString();
                        }
                    }
                    if (row["addresslkey"].ToString().ToLower() != "address5")
                    {
                        continue;
                    }
                    if (row["addressvalue"].ToString() == "")
                    {
                        this.hdnaddress5.Value = this.objLanguage.GetLanguageConversion("Address5");
                    }
                    else
                    {
                        this.hdnaddress5.Value = row["addressvalue"].ToString();
                    }
                }
                if (base.Request.Params["ViewID"] != null)
                {
                    this.ViewID = Convert.ToInt32(base.Request.Params["ViewID"]);
                    this.objCreateView.BindCustomView("estimate", this.CompanyID, this.ddl_View, Convert.ToInt32(base.Request.Params["ViewID"]));
                    int num1 = 0;
                    while (num1 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num1].Value != this.ViewID.ToString())
                        {
                            num1++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num1].Value.ToString());
                            break;
                        }
                    }
                    this.SyncViewLabelFromDropdown();
                }
                else if (this.defaultviewid == 0)
                {
                    this.dt = this.objCreateView.GetdefaultviewID(this.CompanyID, this.pg);
                    if (this.dt.Rows.Count != 0)
                    {
                        foreach (DataRow dataRow in this.dt.Rows)
                        {
                            this.defaultviewid = Convert.ToInt32(dataRow["ViewID"].ToString());
                        }
                    }
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View);
                    if (this.defaultviewid == 0 && this.ddl_View.Items.Count > 0)
                    {
                        this.defaultviewid = Convert.ToInt32(this.ddl_View.Items[0].Value);
                    }
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
                    this.SyncViewLabelFromDropdown();
                }
                else
                {
                    this.objCreateView.BindCustomView(this.pg, this.CompanyID, this.ddl_View, this.defaultviewid);
                    int num3 = 0;
                    while (num3 < this.ddl_View.Items.Count)
                    {
                        if (this.ddl_View.Items[num3].Value != this.defaultviewid.ToString())
                        {
                            num3++;
                        }
                        else
                        {
                            this.objBase.SetDDLValue(this.ddl_View, this.ddl_View.Items[num3].Value.ToString());
                            break;
                        }
                    }
                    this.SyncViewLabelFromDropdown();
                }
                if (this.ddl_View.Text.Length == 0)
                {
                    this.ddl_View.Visible = false;
                }
            }
            int num4 = 0;
            num4 = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num4, this.CompanyID, "estimate");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row1 in this.dt.Rows)
                {
                    this.defaultsortedby = row1["SortedBy"].ToString();
                    this.defaultsortdirection = row1["SortDirection"].ToString();
                    //83
                    //this.IsGrouping = String.IsNullOrEmpty(row1["isGrouping"].ToString())?false:Convert.ToBoolean(row1["isGrouping"].ToString());

                    //this.IsGrouping =  (row1["ColumnNames"].ToString().Contains(row1["GroupByColumn"].ToString()) && !String.IsNullOrEmpty(row1["isGrouping"].ToString()) ) ? Convert.ToBoolean(row1["isGrouping"].ToString()) : false;
                    //this.GroupByColumn= row1["GroupByColumn"].ToString();
                    this.FilterDateType = row1["FilterDateType"].ToString();
                    this.FilterDateRange = row1["FilterDateRange"].ToString();
                }
            }
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            if (!base.IsPostBack)
            {
                estimate_view.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    estimate_view.SortedBy = "EstimateNumber";
                }
                else
                {
                    estimate_view.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    estimate_view.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    estimate_view.sortdirection = this.defaultsortdirection;
                }
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                    string str1 = string.Concat(this.pg, this.UserID, this.pg);
                    this.Session["search_Est"] = null;
                    this.Session[str1] = null;
                    this.Session["EstViewID"] = this.defaultviewid;
                }
            }

            //try
            //{

            //    if (!base.IsPostBack)
            //    {
            //        if (this.IsGrouping)//&& this.GridView1.MasterTableView.GetColumn(this.GroupByColumn) != null)
            //        {
            //            GridView1.GroupingEnabled = true;
            //            GridView1.MasterTableView.GroupsDefaultExpanded = true;

            //            GridGroupByExpression groupByExpression = new GridGroupByExpression();

            //            groupByExpression.GroupByFields.Add(new GridGroupByField()
            //            {
            //                FieldName = this.GroupByColumn,
            //                SortOrder = GridSortOrder.Ascending
            //            });

            //            groupByExpression.SelectFields.Add(new GridGroupByField()
            //            {
            //                FieldName = this.GroupByColumn
            //            });

            //            GridView1.MasterTableView.GroupByExpressions.Add(groupByExpression);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{

            //}



            if (!base.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
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
                        this.GridBind(this.CompanyID, this.UserID, estimate_view.PageSize, 1, this.defaultviewid, "customerid", "desc", empty);
                    }
                }
            }
            catch
            {
            }
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
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
            if (!base.IsPostBack)
            {
                string str2 = "";
                if (this.Session["search_Est"] != null)
                {
                    DataTable item = (DataTable)this.Session["search_Est"];
                    str2 = this.FilterFunction(item);
                }
                this.Session["EstViewID"] = this.defaultviewid;
                estimate_view.PageSize = this.objJava.ReturnPageSize(this.pg, string.Concat(this.UserID, this.pg), this.GridView1);
                this.GridView1.PageSize = estimate_view.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridView1.PageSize, 1, this.defaultviewid, estimate_view.SortedBy, estimate_view.sortdirection, str2);
                this.GridStateLoad();
                this.GridView1.Rebind();
            }

            //if (!IsPostBack && this.IsGrouping)
            //{
            //    // Example: Group by "Employee Name" header text
            //    //this.ApplyGroupingByHeaderTextDynamic(this.GridView1, "Customer Name");
            //    this.ApplyGroupingByFieldName(this.GridView1, this.GroupByColumn);
            //}



            if (this.GridView1.MasterTableView.GetColumn("StatusColorCode") != null)
            {
                this.GridView1.MasterTableView.GetColumn("StatusColorCode").Visible = false;
            }
            if (this.GridView1.MasterTableView.GetColumn("itemStatusColorCode") != null)
            {
                this.GridView1.MasterTableView.GetColumn("itemStatusColorCode").Visible = false;
            }
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
                this.GridView1.MasterTableView.GetColumn("estimateid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("custid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("estimateitemid").Visible = false;
                this.GridView1.MasterTableView.GetColumn("JOBID").Visible = false;
                //this.GridView1.MasterTableView.GetColumn("ProofID").Visible = false;
                if (this.GridView1.MasterTableView.Columns.FindByUniqueNameSafe("ProofID") != null)
                {
                    this.GridView1.MasterTableView.GetColumn("ProofID").Visible = false;
                }
                this.GridView1.MasterTableView.GetColumn("isconvertedtojob").Visible = false;
                this.GridView1.MasterTableView.GetColumn("isarchive").Visible = false;
                this.GridView1.MasterTableView.GetColumn("iSdeletedjob").Visible = false;
                this.GridView1.MasterTableView.GetColumn("BackOrder").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsAccountOnHold").Visible = false;
                this.GridView1.MasterTableView.GetColumn("IsStockProduct").Visible = false;
                //this.GridView1.MasterTableView.GetColumn("StatusColorCode").Visible = false;
            }
            catch (Exception exception)
            {
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


        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"]);
            int num = Convert.ToInt16(this.RadListBox1.SelectedValue);
            string str = this.hdnSelectedChkfrmGrid.Value.ToString();
            this.RadListBox1.ClearSelection();
            string str1 = "Estimate";
            if (!this.IsItemSelected || !(str != "") || num == 0)
            {
                if (str != "" && num != 0)
                {
                    EstimatesBasePage.EstimateOnCheck_Status_Update(this.CompanyID, str, num, str1.ToLower());
                    string[] strArrays = str.Split(new char[] { ',' });
                    for (int i = 0; i < (int)strArrays.Length - 1; i++)
                    {
                        string empty = string.Empty;
                        string empty1 = string.Empty;
                        DataTable dataTable = EstimatesBasePage.estimate_select_summary(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            empty = row["StatusTitle"].ToString();
                            empty1 = row["EstimateNumber"].ToString();
                        }
                        this.objnotes.Estimate_number = empty1;
                        this.objnotes.Status_name = empty;
                        this.objnotes.ModuleName = "estimate";
                        this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstChangeStatus);
                        this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                        this.objnotes.ModuleID = (long)Convert.ToInt32(strArrays[i].ToString());
                        this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                        notesclass _notesclass = this.objnotes;
                        commonClass _commonClass = this.objJava;
                        DateTime now = DateTime.Now;
                        _notesclass.Created_Date = _commonClass.Eprint_return_DateTime_Before_View(now.ToString(), this.CompanyID, this.UserID, true);
                        this.objnotes.CompanyID = this.CompanyID;
                        this.objnotes.UserID = this.UserID;
                        this.objN.NotesAdd(this.objnotes);
                        this.objJava.SendInternalMailOnModuleStatusChange(CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()), num, "estimate");
                        DataTable dt = EstimatesBasePage.GetPriceCatalogueIDByEstimateID(this.CompanyID, (long)Convert.ToInt32(strArrays[i].ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["EstimateType"].ToString() == "C")
                                {
                                    if (commonClass.CheckFTPEnable())
                                    {
                                        string filePath = string.Empty;
                                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                                        var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
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
                                                    object[] editableTemplatePath = new object[] { this.EditableTemplatePath, this.CompanyID.ToString(), "/pdf/", dataTable6.Rows[0]["PrintReadyFile"].ToString() };
                                                    filePath = string.Concat(editableTemplatePath);
                                                }
                                                else
                                                {
                                                    string basePath = Path.Combine(ConnectionClass.SecureDocPath, ConnectionClass.ServerName, this.CompanyID.ToString());
                                                    filePath = Path.Combine(basePath, "Product", "PrintReady", dataTable6.Rows[0]["PrintReadyFile"].ToString());
                                                }
                                                commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "EstimateStatus", "ProductEstimate",Convert.ToInt64(dr["EstimateItemID"].ToString()));
                                            }
                                        }
                                    }

                                }

                            }

                        }
                    }
                    this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
                    this.hdnSelectedChkfrmGrid.Value = "";
                    this.GridView1.Rebind();
                }
                return;
            }
            EstimatesBasePage.EstimateItemsOnCheck_Status_Update(this.CompanyID, str, num, str1.ToLower());
            string[] strArrays1 = str.Split(new char[] { ',' });
            for (int j = 0; j < (int)strArrays1.Length - 1; j++)
            {
                string empty2 = string.Empty;
                string str2 = string.Empty;
                DataTable dataTable1 = EstimatesBasePage.estimate_select_summary_PerItem(this.CompanyID, (long)Convert.ToInt32(strArrays1[j].ToString()));
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    empty2 = dataRow["StatusName"].ToString();
                    str2 = dataRow["EstimateItemNumber"].ToString();
                    this.ModuleID = Convert.ToInt64(dataRow["ModuleID"]);
                }
                this.objnotes.Estimate_number = str2;
                this.objnotes.Status_name = empty2;
                this.objnotes.ModuleName = "estimate";
                this.objnotes.NotesType = Convert.ToString(Notes.NotesType.EstChangeStatus);
                this.UserID = Convert.ToInt32(this.Session["UserID"].ToString());
                this.objnotes.ModuleID = this.ModuleID;
                this.objnotes.CustomerName = string.Concat(this.Session["FirstName"].ToString(), this.Session["LastName"].ToString());
                notesclass _notesclass1 = this.objnotes;
                commonClass _commonClass1 = this.objJava;
                DateTime dateTime = DateTime.Now;
                _notesclass1.Created_Date = _commonClass1.Eprint_return_DateTime_Before_View(dateTime.ToString(), this.CompanyID, this.UserID, true);
                this.objnotes.CompanyID = this.CompanyID;
                this.objnotes.UserID = this.UserID;
                this.objnotes.ItemID = (long)Convert.ToInt32(strArrays1[j].ToString());
                this.objN.NotesAdd(this.objnotes);
                this.objJava.SendInternalMailOnModuleStatusChange(CompanyID, this.ModuleID, num, "estimate");

                string itemType = EstimatesBasePage.GetEstimateType_EstimateItemID((long)Convert.ToInt32(strArrays1[j].ToString()));
                if (itemType == "C")
                {
                    if (commonClass.CheckFTPEnable())
                    {
                        string filePath = string.Empty;
                        var settings = SettingsBasePage.LoadFtpRouteSettings(this.CompanyID);
                        var product = settings.FirstOrDefault(s => s.SectionName == "ProductEstimate");
                        int _statusID = product.StatusValue;
                        if (_statusID == num)
                        {
                            long priceCatalogurID = EstimatesBasePage.GetPriceCatalogueIDByEstimateItemID((long)Convert.ToInt32(strArrays1[j].ToString()));
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
                                commonClass.UploadPrintReadyFileToSftp(this.CompanyID, priceCatalogurID.ToString(), filePath, "EstimateStatus","ProductEstimate", Convert.ToInt64(strArrays1[j].ToString()));
                            }
                        }
                    }

                }
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "reload", "window.location.reload();", true);

            this.objBase.Message_Display(this.objLanguage.GetLanguageConversion("Status_Updated_Successfully"), "successfulMsg", this.plhMessage);
            this.hdnSelectedChkfrmGrid.Value = "";
            this.GridView1.Rebind();
        }

        public new void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        private string getErrorCount(int estimateid, int estimateitemid)
        {


            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataSet dataSet = new DataSet();
            DbCommand storedProcCommand = database.GetStoredProcCommand("sp_GetErrorCountForEstimate");


            database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, Convert.ToInt64(estimateid));
            database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, Convert.ToInt64(estimateitemid));

            dataSet = database.ExecuteDataSet(storedProcCommand);


            DataRow dr = dataSet.Tables[0].Rows[0];

            string errorCount = dr["ErrorCount"].ToString();


            return errorCount;
        }

        [WebMethod(EnableSession = true)]
        public static string accountcreate(string AddEmilToDmc, string txtcompanyname, string txtsignupEmail, string txtuname, string txtlname, string txtupass, string agentcode)
        {
            estimate_view vw = new estimate_view();

            string returnResult = "";
            BaseClass baseClass = new BaseClass();

            long num = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
            int num1 = 260;
            long num2 = (long)0;
            long num3 = (long)0;

            if (vw.CheckEmailID_Duplicacy(num3, baseClass.SpecialDecode(txtsignupEmail), Convert.ToInt64(num1)) != -1)
            {
                int num4 = 0;
                num4 = (AddEmilToDmc != "true" ? 0 : 1);
                num3 = vw.Create_StoreUser((long)0, (long)0, baseClass.SpecialEncode(txtuname), baseClass.SpecialEncode(txtlname), baseClass.SpecialEncode(txtsignupEmail), txtupass, num, Convert.ToInt64(num1), "new", baseClass.SpecialEncode(txtcompanyname), num4);
                if (num3 != (long)0)
                {

                    long num5 = (long)0;
                    long num6 = (long)0;
                    if (num2 == (long)0)
                    {
                        vw.Insert_CustomerOn_Order(num, num3, Convert.ToInt64(num1), num5, num6, "yes", DateTime.Now);

                        returnResult = "OK";
                    }
                    else
                    {
                        returnResult = "Not OK";
                    }

                }

            }
            else
            {
                returnResult = "exists";
            }
            return returnResult;
        }

        private int CheckEmailID_Duplicacy(long StoreUserID, string EmailID, long AccountID)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DbCommand storedProcCommand = database.GetStoredProcCommand("Ws_CheckEmailID_Duplicacy");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int32, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? 0 : int.Parse(parameterValue.ToString()));
        }

        private long Create_StoreUser(long StoreUserID, long defaultClientID, string FirstName, string LastName, string EmailID, string Password, long CompanyID, long AccountID, string IsPsw, string CompanyName, int subscribe_newsletter)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Create_StoreUserDefault");
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@defaultClientID", DbType.Int64, defaultClientID);
            database.AddInParameter(storedProcCommand, "@FirstName", DbType.String, FirstName);
            database.AddInParameter(storedProcCommand, "@LastName", DbType.String, LastName);
            database.AddInParameter(storedProcCommand, "@EmailID", DbType.String, EmailID);
            database.AddInParameter(storedProcCommand, "@Password", DbType.String, Password);
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@IsPsw", DbType.String, IsPsw);
            database.AddInParameter(storedProcCommand, "@CompanyName", DbType.String, CompanyName);
            database.AddInParameter(storedProcCommand, "@subscribe_newsletter", DbType.Int32, subscribe_newsletter);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        private long Insert_CustomerOn_Order(long CompanyID, long StoreUserID, long AccountID, long BillingAddressID, long ShippingAddressID, string FromRegistration, DateTime CreatedDate)
        {
            Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
            DataTable dataTable = new DataTable();
            DbCommand storedProcCommand = database.GetStoredProcCommand("WS_Insert_CustomerOn_Order");
            database.AddInParameter(storedProcCommand, "@CompanyID", DbType.Int64, CompanyID);
            database.AddInParameter(storedProcCommand, "@StoreUserID", DbType.Int64, StoreUserID);
            database.AddInParameter(storedProcCommand, "@AccountID", DbType.Int64, AccountID);
            database.AddInParameter(storedProcCommand, "@BillingAddressID", DbType.Int64, BillingAddressID);
            database.AddInParameter(storedProcCommand, "@ShippingAddressID", DbType.Int64, ShippingAddressID);
            database.AddInParameter(storedProcCommand, "@FromRegistration", DbType.String, FromRegistration);
            database.AddInParameter(storedProcCommand, "@CreatedDate", DbType.DateTime, CreatedDate);
            database.AddOutParameter(storedProcCommand, "@ReturnID", DbType.Int64, 0);
            database.ExecuteNonQuery(storedProcCommand);
            object parameterValue = database.GetParameterValue(storedProcCommand, "@ReturnID");
            return (parameterValue == null ? (long)0 : long.Parse(parameterValue.ToString()));
        }

        private void SyncViewLabelFromDropdown()
        {
            if (this.ddl_View.SelectedItem != null)
            {
                this.lblView.Text = this.ddl_View.SelectedItem.Text;
                return;
            }
            if (this.ddl_View.Items.Count > 0)
            {
                this.ddl_View.SelectedIndex = 0;
                this.lblView.Text = this.ddl_View.SelectedItem.Text;
                return;
            }
            this.ddl_View.Visible = false;
            this.lblView.Text = string.Empty;
        }
    }
}