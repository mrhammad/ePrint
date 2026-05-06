using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace ePrint.usercontrol.ESTIMATE
{
    public partial class Estimate_Search : UsercontrolBasePage
    {
        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private CompanyBasePage objComp = new CompanyBasePage();

        private commonClass objJava = new commonClass();

        public languageClass objLanguage = new languageClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

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

        public string flag_estdate = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

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

        public string cellvalue_CostCentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_estdate = string.Empty;

        public string flag_validfor = string.Empty;

        public string cellvalue_validfor = string.Empty;

        public string flag_estimatetype = string.Empty;

        public string cellvalue_estimatetype = string.Empty;

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

        public DataTable dt = new DataTable();

        public string defaultsortedby = string.Empty;

        public string defaultsortdirection = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public int PageSize;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public string EstimateID = string.Empty;

        private DataTable dtArtwork = new DataTable();

        public int ViewID;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public int EstimateRecCount;

        public string pgsearch = string.Empty;

        public string Mode = string.Empty;

        private bool IsItemSelected;

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

        public Estimate_Search()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.grvEstimateSearch.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "estimatedate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                }
                for (int j = 0; j < this.grvEstimateSearch.Columns.Count; j++)
                {
                    this.grvEstimateSearch.Columns[j].CurrentFilterFunction = GridKnownFunction.Contains;
                    this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.grvEstimateSearch.Columns[j].HeaderStyle.Wrap = false;
                    if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_No");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Person");
                        this.cellvalue_sales = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Title");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(150);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(150);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_estTitle = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_contactname = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_custname = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "company")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_company = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_company = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "ordernumber")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.cellvalue_custordernumber = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_custordernumber = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.cellvalue_custordernumber = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_custordernumber = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Status");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.cellvalue_status = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.cellvalue_AccountStatus = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.cellvalue_estimator = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "validfor")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Valid_For");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_validfor = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Created_On");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Est_Value"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatedate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Est_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_estdate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "quantity1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity1");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity1 = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "quantity2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity2");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity2 = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "quantity3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity3");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity3 = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "quantity4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity5");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity4 = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.cellvalue_referredby = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_referredby = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.cellvalue_custacountnumber = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_customeraccountnumber = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "isconvertedtojob")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "isarchive")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "emailcount")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimateitemid")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimateid")
                    {
                        this.grvEstimateSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Est_Value_Exc_Tax"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estvalExcGST = "true";
                        this.cellvalue_estvalExcGST = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.cellvalue_paymentterms = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_paymerntterms = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_centre");
                        this.cellvalue_CostCentre = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_costcentre = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "greeting")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Greeting");
                        this.cellvalue_greeting = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "header")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Header");
                        this.cellvalue_Header = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "footer")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Footer");
                        this.cellvalue_footer = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_footer = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.cellvalue_estimator = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Type");
                        this.cellvalue_estimatetype = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estimatetype = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title_View");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemquantity1")
                    {
                        this.flag_ItemQTY1 = "true";
                        this.cellvalue_ItemQTY1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity1");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemquantity2")
                    {
                        this.flag_ItemQTY2 = "true";
                        this.cellvalue_ItemQTY1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity2");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemquantity3")
                    {
                        this.flag_ItemQTY3 = "true";
                        this.cellvalue_ItemQTY1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity3");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemquantity4")
                    {
                        this.flag_ItemQTY4 = "true";
                        this.cellvalue_ItemQTY1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity4");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax1 = "true";
                        this.cellvalue_ItemValue_ExcTax1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax2 = "true";
                        this.cellvalue_ItemValue_ExcTax2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax3 = "true";
                        this.cellvalue_ItemValue_ExcTax3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax4 = "true";
                        this.cellvalue_ItemValue_ExcTax4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax1 = "true";
                        this.cellvalue_ItemValue_IncTax1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax2 = "true";
                        this.cellvalue_ItemValue_IncTax2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax3 = "true";
                        this.cellvalue_ItemValue_IncTax3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax4 = "true";
                        this.cellvalue_ItemValue_IncTax4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue1 = "true";
                        this.cellvalue_ItemTaxValue1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue2 = "true";
                        this.cellvalue_ItemTaxValue2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue3 = "true";
                        this.cellvalue_ItemTaxValue3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue4 = "true";
                        this.cellvalue_ItemTaxValue4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup1 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup2 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup3 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup4 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue1 = "true";
                        this.cellvalue_ItemMarkupValue1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue2 = "true";
                        this.cellvalue_ItemMarkupValue2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue3 = "true";
                        this.cellvalue_ItemMarkupValue3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue4 = "true";
                        this.cellvalue_ItemMarkupValue4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup1 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup2 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup3 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup4 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage1 = "true";
                        this.cellvalue_ItemProfitMarginPercentage1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage2 = "true";
                        this.cellvalue_ItemProfitMarginPercentage2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage3 = "true";
                        this.cellvalue_ItemProfitMarginPercentage3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage4 = "true";
                        this.cellvalue_ItemProfitMarginPercentage4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue1 = "true";
                        this.cellvalue_ItemProfitMarginValue1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue2 = "true";
                        this.cellvalue_ItemProfitMarginValue2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue3 = "true";
                        this.cellvalue_ItemProfitMarginValue3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue4 = "true";
                        this.cellvalue_ItemProfitMarginValue4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage1_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage1 = "true";
                        this.cellvalue_ItemGrossProfitPercentage1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage2_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage2 = "true";
                        this.cellvalue_ItemGrossProfitPercentage2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage3_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage3 = "true";
                        this.cellvalue_ItemGrossProfitPercentage3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage4_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage4 = "true";
                        this.cellvalue_ItemGrossProfitPercentage4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue1")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value1"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue1 = "true";
                        this.cellvalue_ItemGrossProfitValue1 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue2")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value2"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue2 = "true";
                        this.cellvalue_ItemGrossProfitValue2 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue3")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value3"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue3 = "true";
                        this.cellvalue_ItemGrossProfitValue3 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue4")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value4"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue4 = "true";
                        this.cellvalue_ItemGrossProfitValue4 = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvEstimateSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_view");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ContactEmail = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ContactEmail = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ComapnyEmail = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ComapnyEmail = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ContactPhone = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ContactPhone = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "artworkdate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Artwork_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ArtworkDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ArtworkDate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "proofdate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Proof_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ProofDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ProofDate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "approvaldate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Approval_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ApprovalDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ApprovalDate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "productiondate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Production_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_ProductionDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_ProductionDate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "completiondate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Completion_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_CompletionDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_CompletionDate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.grvEstimateSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.grvEstimateSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_DeliveryDate = this.grvEstimateSearch.Columns[j].SortExpression.ToLower();
                        this.flag_DeliveryDate = "true";
                    }
                }
            }
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)this.Page.Master.FindControl("keywordsearch");
            if (textBox.Text != "")
            {
                this.para = this.objBase.ReplaceSingleQuote(textBox.Text.Trim());
                base.Response.Redirect(string.Concat(this.strSitepath, "estimates/estimate_search.aspx?para=", this.para));
            }
        }

        public void CallPagingBtn_ScrollGrid(UserControl usrPagingID)
        {
            ((LinkButton)usrPagingID.FindControl("lnkFirst")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkSecond")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkThird")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFour")).OnClientClick = "javascript:CheckGrid();";
            ((LinkButton)usrPagingID.FindControl("lnkFive")).OnClientClick = "javascript:CheckGrid();";
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

        public void GridBind(int CompanyID, int UserID, int PageSize, int PageNumber, int ViewID, string SortedBy, string SortDirection, string para, string new_para)
        {
            string empty = string.Empty;
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView_ForSearch(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para, new_para);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
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
                    if (row.Table.Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("EstimateDate"))
                    {
                        row["EstimateDate"] = this.objJava.Eprint_return_Date_Before_View(row["EstimateDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("OrderNumber"))
                    {
                        row["OrderNumber"] = this.objBase.SpecialDecode(row["OrderNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("EstimateNumber"))
                    {
                        row["EstimateNumber"] = this.objBase.SpecialDecode(row["EstimateNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("EstimateTitle"))
                    {
                        row["EstimateTitle"] = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("Estimator"))
                    {
                        row["Estimator"] = this.objBase.SpecialDecode(row["Estimator"].ToString());
                    }
                    if (row.Table.Columns.Contains("Header"))
                    {
                        row["Header"] = this.objBase.SpecialDecode(row["Header"].ToString());
                    }
                    if (row.Table.Columns.Contains("Footer"))
                    {
                        row["Footer"] = this.objBase.SpecialDecode(row["Footer"].ToString());
                    }
                    if (row.Table.Columns.Contains("SalesPerson"))
                    {
                        row["SalesPerson"] = this.objBase.SpecialDecode(row["SalesPerson"].ToString());
                    }
                    if (row.Table.Columns.Contains("StatusID"))
                    {
                        row["StatusID"] = this.objBase.SpecialDecode(row["StatusID"].ToString());
                    }
                    if (row.Table.Columns.Contains("ReferredBY"))
                    {
                        row["ReferredBY"] = this.objBase.SpecialDecode(row["ReferredBY"].ToString());
                    }
                    if (row.Table.Columns.Contains("Company"))
                    {
                        row["Company"] = this.objBase.SpecialDecode(row["Company"].ToString());
                    }
                    if (row.Table.Columns.Contains("Greeting"))
                    {
                        row["Greeting"] = this.objBase.SpecialDecode(row["Greeting"].ToString());
                    }
                    if (row.Table.Columns.Contains("CostCentre"))
                    {
                        row["CostCentre"] = this.objBase.SpecialDecode(row["CostCentre"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerID"))
                    {
                        row["CustomerID"] = this.objBase.SpecialDecode(row["CustomerID"].ToString());
                    }
                    if (row.Table.Columns.Contains("AttentionID"))
                    {
                        row["AttentionID"] = this.objBase.SpecialDecode(row["AttentionID"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerAccountNumber"))
                    {
                        row["CustomerAccountNumber"] = this.objBase.SpecialDecode(row["CustomerAccountNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemMaterial"))
                    {
                        row["ItemMaterial"] = this.objBase.SpecialDecode(row["ItemMaterial"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemTitle"))
                    {
                        row["ItemTitle"] = this.objBase.SpecialDecode(row["ItemTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemDescription"))
                    {
                        row["ItemDescription"] = this.objBase.SpecialDecode(row["ItemDescription"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemColour"))
                    {
                        row["ItemColour"] = this.objBase.SpecialDecode(row["ItemColour"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemSize"))
                    {
                        row["ItemSize"] = this.objBase.SpecialDecode(row["ItemSize"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemArtwork"))
                    {
                        row["ItemArtwork"] = this.objBase.SpecialDecode(row["ItemArtwork"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemProofs"))
                    {
                        row["ItemProofs"] = this.objBase.SpecialDecode(row["ItemProofs"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemDelivery"))
                    {
                        row["ItemDelivery"] = this.objBase.SpecialDecode(row["ItemDelivery"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemFinishing"))
                    {
                        row["ItemFinishing"] = this.objBase.SpecialDecode(row["ItemFinishing"].ToString());
                    }
                    if (row.Table.Columns.Contains("Itemterms_Instructions"))
                    {
                        row["Itemterms_Instructions"] = this.objBase.SpecialDecode(row["Itemterms_Instructions"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemNotes"))
                    {
                        row["ItemNotes"] = this.objBase.SpecialDecode(row["ItemNotes"].ToString());
                    }
                    if (row.Table.Columns.Contains("ItemPacking"))
                    {
                        row["ItemPacking"] = this.objBase.SpecialDecode(row["ItemPacking"].ToString());
                    }
                    if (row.Table.Columns.Contains("CompanyEmail"))
                    {
                        row["CompanyEmail"] = this.objBase.SpecialDecode(row["CompanyEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactEmail"))
                    {
                        row["ContactEmail"] = this.objBase.SpecialDecode(row["ContactEmail"].ToString());
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
                    if (row.Table.Columns.Contains("Address1"))
                    {
                        row["Address1"] = this.objBase.SpecialDecode(row["Address1"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address2"))
                    {
                        row["Address2"] = this.objBase.SpecialDecode(row["Address2"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address3"))
                    {
                        row["Address3"] = this.objBase.SpecialDecode(row["Address3"].ToString());
                    }
                    if (row.Table.Columns.Contains("Address4"))
                    {
                        row["Address4"] = this.objBase.SpecialDecode(row["Address4"].ToString());
                    }
                    if (!row.Table.Columns.Contains("Address5"))
                    {
                        continue;
                    }
                    row["Address5"] = this.objBase.SpecialDecode(row["Address5"].ToString());
                }
            }
            _commonClass.closeConnection();
            this.grvEstimateSearch.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvEstimateSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvEstimateSearch.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvEstimateSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvEstimateSearch.AllowCustomPaging = true;
                this.grvEstimateSearch.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.EstimateRecCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getEstimateRecCount != null)
                {
                    this.getEstimateRecCount(this.EstimateRecCount);
                    return;
                }
            }
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
            this.objJava.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvEstimateSearch, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvEstimateSearch);
        }

        protected void grvEstimateSearch_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            e.Column.Visible = false;
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

        protected void grvEstimateSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "estimatevalue" || commandArgument.Second.ToString().ToLower() == "quantity1" || commandArgument.Second.ToString().ToLower() == "quantity2" || commandArgument.Second.ToString().ToLower() == "quantity3" || commandArgument.Second.ToString().ToLower() == "quantity4"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text != "")
                    {
                        item.Text = item.Text;
                    }
                }
                if (base.Session["search_Est"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_Est"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_Est"];
                }
                DataRow[] dataRowArray = this.dtsearch.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if (item.Text != "")
                {
                    if ((int)dataRowArray.Length <= 0)
                    {
                        object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        this.dtsearch.Rows.Add(second);
                    }
                    else
                    {
                        this.dtsearch.Rows.Remove(dataRowArray[0]);
                        if (commandArgument.First.ToString().ToLower() != "nofilter")
                        {
                            object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                            this.dtsearch.Rows.Add(objArray);
                        }
                    }
                }
                base.Session["search_Est"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.grvEstimateSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.grvEstimateSearch.Rebind();
            }
        }

        protected void grvEstimateSearch_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvEstimateSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvEstimateSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvEstimateSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvEstimateSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.grvEstimateSearch.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void grvEstimateSearch_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridBind(this.CompanyID, this.UserID, this.grvEstimateSearch.PageSize, this.grvEstimateSearch.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
            this.grvEstimateSearch.MasterTableView.FilterExpression = null;
        }

        protected void grvEstimateSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridItem item in this.grvEstimateSearch.MasterTableView.Items)
            {
                if (!item.Selected)
                {
                    continue;
                }
                item.Cells[2].Text.ToString();
            }
        }

        protected void grvEstimateSearch_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            this.SortedBy = e.SortExpression;
            this.sortdirection = e.NewSortOrder.ToString();
            if (this.sortdirection.ToLower() == "ascending")
            {
                this.sortdirection = "ASC";
            }
            else if (this.sortdirection.ToLower() != "descending")
            {
                this.sortdirection = "ASC";
            }
            else
            {
                this.sortdirection = "DESC";
            }
            this.grvEstimateSearch.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.grvEstimateSearch.PageSize, this.grvEstimateSearch.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        public string Only_number(string input)
        {
            return Regex.Replace(input, "[^0-9.]", "");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.GridStateSave();
        }

        protected void OnRowDataBound_grvEstimateSearch(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.grvEstimateSearch.Columns.Count; i++)
                {
                    if (this.grvEstimateSearch.MasterTableView.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.grvEstimateSearch.MasterTableView.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimatedate")
                    {
                        this.cellvalue_estdate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "validfor")
                    {
                        this.cellvalue_validfor = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.cellvalue_status = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "order")
                    {
                        this.cellvalue_order = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_order = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "greeting")
                    {
                        this.cellvalue_greeting = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.cellvalue_estimator = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_custname = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "company")
                    {
                        this.cellvalue_company = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_company = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_sales = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "contactname")
                    {
                        this.cellvalue_contactname = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "header")
                    {
                        this.cellvalue_Header = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "footer")
                    {
                        this.cellvalue_footer = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_footer = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.cellvalue_estTitle = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "isconvertedtojob")
                    {
                        this.grvEstimateSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "isarchive")
                    {
                        this.grvEstimateSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.grvEstimateSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.grvEstimateSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_estvalExcGST = "true";
                        this.cellvalue_estvalExcGST = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_custacountnumber = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "ordernumber")
                    {
                        this.flag_custordernumber = "true";
                        this.cellvalue_custordernumber = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "attentionid")
                    {
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymerntterms = "true";
                        this.cellvalue_paymentterms = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        this.flag_costcentre = "true";
                        this.cellvalue_CostCentre = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.flag_estimatetype = "true";
                        this.cellvalue_estimatetype = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_ComapnyEmail = "true";
                        this.cellvalue_ComapnyEmail = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "artworkdate")
                    {
                        this.flag_ArtworkDate = "true";
                        this.cellvalue_ArtworkDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "proofdate")
                    {
                        this.flag_ProofDate = "true";
                        this.cellvalue_ProofDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "approvaldate")
                    {
                        this.flag_ApprovalDate = "true";
                        this.cellvalue_ApprovalDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "productiondate")
                    {
                        this.flag_ProductionDate = "true";
                        this.cellvalue_ProductionDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.flag_CompletionDate = "true";
                        this.cellvalue_CompletionDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemquantity1")
                    {
                        this.flag_ItemQTY1 = "true";
                        this.cellvalue_ItemQTY1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemquantity2")
                    {
                        this.flag_ItemQTY2 = "true";
                        this.cellvalue_ItemQTY2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemquantity3")
                    {
                        this.flag_ItemQTY3 = "true";
                        this.cellvalue_ItemQTY3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemquantity4")
                    {
                        this.flag_ItemQTY4 = "true";
                        this.cellvalue_ItemQTY4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax1")
                    {
                        this.flag_ItemValue_ExcTax1 = "true";
                        this.cellvalue_ItemValue_ExcTax1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax2")
                    {
                        this.flag_ItemValue_ExcTax2 = "true";
                        this.cellvalue_ItemValue_ExcTax2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax3")
                    {
                        this.flag_ItemValue_ExcTax3 = "true";
                        this.cellvalue_ItemValue_ExcTax3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax4")
                    {
                        this.flag_ItemValue_ExcTax4 = "true";
                        this.cellvalue_ItemValue_ExcTax4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax1")
                    {
                        this.flag_ItemValue_IncTax1 = "true";
                        this.cellvalue_ItemValue_IncTax1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax2")
                    {
                        this.flag_ItemValue_IncTax2 = "true";
                        this.cellvalue_ItemValue_IncTax2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax3")
                    {
                        this.flag_ItemValue_IncTax3 = "true";
                        this.cellvalue_ItemValue_IncTax3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax4")
                    {
                        this.flag_ItemValue_IncTax4 = "true";
                        this.cellvalue_ItemValue_IncTax4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue1")
                    {
                        this.flag_ItemTaxValue1 = "true";
                        this.cellvalue_ItemTaxValue1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue2")
                    {
                        this.flag_ItemTaxValue2 = "true";
                        this.cellvalue_ItemTaxValue2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue3")
                    {
                        this.flag_ItemTaxValue3 = "true";
                        this.cellvalue_ItemTaxValue3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue4")
                    {
                        this.flag_ItemTaxValue4 = "true";
                        this.cellvalue_ItemTaxValue4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup1")
                    {
                        this.flag_ItemCostPriceExcMarkup1 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup2")
                    {
                        this.flag_ItemCostPriceExcMarkup2 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup3")
                    {
                        this.flag_ItemCostPriceExcMarkup3 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup4")
                    {
                        this.flag_ItemCostPriceExcMarkup4 = "true";
                        this.cellvalue_ItemCostPriceExcMarkup4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue1")
                    {
                        this.flag_ItemMarkupValue1 = "true";
                        this.cellvalue_ItemMarkupValue1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue2")
                    {
                        this.flag_ItemMarkupValue2 = "true";
                        this.cellvalue_ItemMarkupValue2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue3")
                    {
                        this.flag_ItemMarkupValue3 = "true";
                        this.cellvalue_ItemMarkupValue3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue4")
                    {
                        this.flag_ItemMarkupValue4 = "true";
                        this.cellvalue_ItemMarkupValue4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup1")
                    {
                        this.flag_ItemCostPriceIncMarkup1 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup2")
                    {
                        this.flag_ItemCostPriceIncMarkup2 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup3")
                    {
                        this.flag_ItemCostPriceIncMarkup3 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup4")
                    {
                        this.flag_ItemCostPriceIncMarkup4 = "true";
                        this.cellvalue_ItemCostPriceIncMarkup4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage1")
                    {
                        this.flag_ItemProfitMarginPercentage1 = "true";
                        this.cellvalue_ItemProfitMarginPercentage1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage2")
                    {
                        this.flag_ItemProfitMarginPercentage2 = "true";
                        this.cellvalue_ItemProfitMarginPercentage2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage3")
                    {
                        this.flag_ItemProfitMarginPercentage3 = "true";
                        this.cellvalue_ItemProfitMarginPercentage3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage4")
                    {
                        this.flag_ItemProfitMarginPercentage4 = "true";
                        this.cellvalue_ItemProfitMarginPercentage4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue1")
                    {
                        this.flag_ItemProfitMarginValue1 = "true";
                        this.cellvalue_ItemProfitMarginValue1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue2")
                    {
                        this.flag_ItemProfitMarginValue2 = "true";
                        this.cellvalue_ItemProfitMarginValue2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue3")
                    {
                        this.flag_ItemProfitMarginValue3 = "true";
                        this.cellvalue_ItemProfitMarginValue3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue4")
                    {
                        this.flag_ItemProfitMarginValue4 = "true";
                        this.cellvalue_ItemProfitMarginValue4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage1")
                    {
                        this.flag_ItemGrossProfitPercentage1 = "true";
                        this.cellvalue_ItemGrossProfitPercentage1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage2")
                    {
                        this.flag_ItemGrossProfitPercentage2 = "true";
                        this.cellvalue_ItemGrossProfitPercentage2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage3")
                    {
                        this.flag_ItemGrossProfitPercentage3 = "true";
                        this.cellvalue_ItemGrossProfitPercentage3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage4")
                    {
                        this.flag_ItemGrossProfitPercentage4 = "true";
                        this.cellvalue_ItemGrossProfitPercentage4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue1")
                    {
                        this.flag_ItemGrossProfitValue1 = "true";
                        this.cellvalue_ItemGrossProfitValue1 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue2")
                    {
                        this.flag_ItemGrossProfitValue2 = "true";
                        this.cellvalue_ItemGrossProfitValue2 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue3")
                    {
                        this.flag_ItemGrossProfitValue3 = "true";
                        this.cellvalue_ItemGrossProfitValue3 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvEstimateSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue4")
                    {
                        this.flag_ItemGrossProfitValue4 = "true";
                        this.cellvalue_ItemGrossProfitValue4 = this.grvEstimateSearch.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                empty = (!this.IsItemSelected ? ((DataRowView)e.Item.DataItem)[0].ToString() : ((DataRowView)e.Item.DataItem)[1].ToString());
                string str = string.Concat("estimates/estimate_summary_reeng.aspx?estid=", empty);
                if (this.IsItemSelected)
                {
                    str = string.Concat(str, "&EstItemID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                }
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_EmailSent");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plhConvertJob");
                PlaceHolder placeHolder3 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                string empty1 = string.Empty;
                string languageConversion = string.Empty;
                empty1 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                string str3 = string.Empty;
                empty3 = string.Concat(this.strImagepath, "quote-icon.png");
                str3 = "Email sent";
                str1 = string.Concat(this.strImagepath, "Attachment.PNG");
                empty2 = "Item with an attachment(s)";
                str2 = string.Concat(this.strImagepath, "liner_j_icon.png");
                string empty4 = string.Empty;
                DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", ((DataRowView)e.Item.DataItem)[0].ToString()));
                if ((int)dataRowArray.Length > 0)
                {
                    empty4 = dataRowArray[0]["ArtWork"].ToString();
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls = placeHolder3.Controls;
                    string[] strArrays = new string[] { "<img src='", empty1, "'  title='", languageConversion, "' class='viewicon_margin'  />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                if (Convert.ToInt16(item["EmailCount"].Text) == 0)
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else if (Convert.ToInt16(item["EmailCount"].Text) > 0)
                {
                    if (base.Session["SupplierQuote"].ToString().ToLower() != "true")
                    {
                        placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                    }
                    else
                    {
                        ControlCollection controlCollections = placeHolder.Controls;
                        string[] strArrays1 = new string[] { "<img src='", empty3, "'  title='", str3, "'/>" };
                        controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                    }
                }
                if (item["EstItemCoun"].Text != "0" || empty4 != "")
                {
                    ControlCollection controls1 = placeHolder1.Controls;
                    string[] strArrays2 = new string[] { "<img src='", str1, "'  title='", empty2, "' style='cursor:pointer;'/>" };
                    controls1.Add(new LiteralControl(string.Concat(strArrays2)));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                if (item["ISDeletedJob"].Text != "0")
                {
                    ControlCollection controlCollections1 = placeHolder2.Controls;
                    string[] text = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&jID=", item["jobid"].Text, "estid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "><img src='", this.strImagepath, "1t.gif' border='0' /></a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(text)));
                }
                else if (!(item["IsConvertedToJob"].Text == "1") || !(item["IsArchive"].Text == "0"))
                {
                    ControlCollection controls2 = placeHolder2.Controls;
                    string[] text1 = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&jID=", item["jobid"].Text, "estid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "><img src='", this.strImagepath, "1t.gif' border='0' /></a>" };
                    controls2.Add(new LiteralControl(string.Concat(text1)));
                }
                else
                {
                    ControlCollection controlCollections2 = placeHolder2.Controls;
                    string[] text2 = new string[] { "<a href=", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&jID=", item["jobid"].Text, "&estid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "><img src='", str2, "' title = 'Job Raised' style='cursor:pointer;'/></a>" };
                    controlCollections2.Add(new LiteralControl(string.Concat(text2)));
                }
                if (((DataRowView)e.Item.DataItem).DataView.Table.Columns.Contains("CustomerType") && item["CustomerType"].Text.Trim().Length > 30)
                {
                    item["CustomerType"].ToolTip = item["CustomerType"].Text;
                    item["CustomerType"].Text = string.Concat(item["CustomerType"].Text.Substring(0, 30), "..");
                }
                if (!this.IsItemSelected)
                {
                    TableCell tableCell = item["estimatenumber"];
                    string[] text3 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", empty, ">", item["estimatenumber"].Text, "</a>" };
                    tableCell.Text = string.Concat(text3);
                }
                else
                {
                    TableCell item1 = item["estimatenumber"];
                    string[] strArrays3 = new string[] { "<a href=", this.strSitepath, "estimates/estimate_summary_reeng.aspx?frm=view&estid=", empty, "&EstItemID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["estimatenumber"].Text, "</a>" };
                    item1.Text = string.Concat(strArrays3);
                }
                if (this.flag_estval == "true")
                {
                    item[this.cellvalue_estval].Attributes.Add("align", "right");
                    item[this.cellvalue_estval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_estvalExcGST].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estvalExcGST].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estvalExcGST].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estvalExcGST].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_estdate == "true")
                {
                    item[this.cellvalue_estdate].Attributes.Add("align", "center");
                    item[this.cellvalue_estdate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estdate].Style.Add("cursor", "pointer");
                }
                if (this.flag_validfor == "true")
                {
                    item[this.cellvalue_validfor].Attributes.Add("align", "right");
                    item[this.cellvalue_validfor].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_validfor].Style.Add("cursor", "pointer");
                    TableCell tableCell1 = item[this.cellvalue_validfor];
                    string[] text4 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_validfor].Text, "</div>" };
                    tableCell1.Text = string.Concat(text4);
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    TableCell item2 = item[this.cellvalue_status];
                    string[] strArrays4 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_status].Text, "</div>" };
                    item2.Text = string.Concat(strArrays4);
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_AccountStatus];
                    string[] text5 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_AccountStatus].Text, "</div>" };
                    tableCell2.Text = string.Concat(text5);
                }
                if (this.flag_order == "true")
                {
                    item[this.cellvalue_order].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_order].Style.Add("cursor", "pointer");
                    TableCell item3 = item[this.cellvalue_order];
                    string[] strArrays5 = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_order].Text, "</div>" };
                    item3.Text = string.Concat(strArrays5);
                }
                if (this.flag_greeting == "true")
                {
                    item[this.cellvalue_greeting].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_greeting].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_greeting];
                    string[] text6 = new string[] { "<div style='width: ", this.type3, ";min-width: ", this.type3, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_greeting].Text, "</div>" };
                    tableCell3.Text = string.Concat(text6);
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estimator].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                    TableCell item4 = item[this.cellvalue_estimator];
                    string[] strArrays6 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_estimator].Text, "</div>" };
                    item4.Text = string.Concat(strArrays6);
                }
                if (this.flag_custname == "true")
                {
                    item[this.cellvalue_custname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_custname].Style.Add("cursor", "pointer");
                }
                if (this.flag_company == "true")
                {
                    item[this.cellvalue_company].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_company].Style.Add("cursor", "pointer");
                }
                if (this.flag_sales == "true")
                {
                    item[this.cellvalue_sales].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_sales].Style.Add("cursor", "pointer");
                    TableCell tableCell4 = item[this.cellvalue_sales];
                    string[] text7 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_sales].Text, "</div>" };
                    tableCell4.Text = string.Concat(text7);
                }
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                }
                if (this.flag_Header == "true")
                {
                    item[this.cellvalue_Header].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Header].Style.Add("cursor", "pointer");
                    TableCell item5 = item[this.cellvalue_Header];
                    string[] strArrays7 = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Header].Text, "</div>" };
                    item5.Text = string.Concat(strArrays7);
                }
                if (this.flag_footer == "true")
                {
                    item[this.cellvalue_footer].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_footer].Style.Add("cursor", "pointer");
                    TableCell tableCell5 = item[this.cellvalue_footer];
                    string[] text8 = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_footer].Text, "</div>" };
                    tableCell5.Text = string.Concat(text8);
                }
                if (this.flag_estTitle == "true")
                {
                    item[this.cellvalue_estTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estTitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_quantity1 == "true")
                {
                    item[this.cellvalue_quantity1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_quantity1].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity1].Attributes.Add("align", "right");
                    TableCell item6 = item[this.cellvalue_quantity1];
                    string[] strArrays8 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity1].Text, "</div>" };
                    item6.Text = string.Concat(strArrays8);
                }
                if (this.flag_quantity2 == "true")
                {
                    item[this.cellvalue_quantity2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_quantity2].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity2].Attributes.Add("align", "right");
                    TableCell tableCell6 = item[this.cellvalue_quantity2];
                    string[] text9 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity2].Text, "</div>" };
                    tableCell6.Text = string.Concat(text9);
                }
                if (this.flag_quantity3 == "true")
                {
                    item[this.cellvalue_quantity3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_quantity3].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity3].Attributes.Add("align", "right");
                    TableCell item7 = item[this.cellvalue_quantity3];
                    string[] strArrays9 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity3].Text, "</div>" };
                    item7.Text = string.Concat(strArrays9);
                }
                if (this.flag_quantity4 == "true")
                {
                    item[this.cellvalue_quantity4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_quantity4].Style.Add("cursor", "pointer");
                    item[this.cellvalue_quantity4].Attributes.Add("align", "right");
                    TableCell tableCell7 = item[this.cellvalue_quantity4];
                    string[] text10 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity4].Text, "</div>" };
                    tableCell7.Text = string.Concat(text10);
                }
                if (this.flag_paymerntterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_custordernumber == "true")
                {
                    item[this.cellvalue_custordernumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_custordernumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_custacountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_custacountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_CostCentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CostCentre].Style.Add("cursor", "pointer");
                }
                if (this.flag_estimatetype == "true")
                {
                    item[this.cellvalue_estimatetype].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estimatetype].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemValue_ExcTax1 == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax1].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_ExcTax2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_ExcTax3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_ExcTax4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_IncTax1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_IncTax2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_IncTax3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemValue_IncTax4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemTaxValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemTaxValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemTaxValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemTaxValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceExcMarkup1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceExcMarkup2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceExcMarkup3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceExcMarkup4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemMarkupValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemMarkupValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemMarkupValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemMarkupValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceIncMarkup1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceIncMarkup2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceIncMarkup3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemCostPriceIncMarkup4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginPercentage1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginPercentage2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginPercentage3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginPercentage4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemProfitMarginValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitPercentage1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitPercentage2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitPercentage3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitPercentage4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitValue1].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitValue2].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitValue3].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemGrossProfitValue4].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemGrossProfitValue4].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue4].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue4].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_Height == "true")
                {
                    item[this.cellvalue_Height].Attributes.Add("align", "right");
                    item[this.cellvalue_Height].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_Width].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
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
                    item[this.cellvalue_ItemDescription].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemDescription].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemColour == "true")
                {
                    item[this.cellvalue_ItemColour].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemColour].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemSize == "true")
                {
                    item[this.cellvalue_ItemSize].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemSize].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemArtwork == "true")
                {
                    item[this.cellvalue_ItemArtwork].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemArtwork].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemDelivery == "true")
                {
                    item[this.cellvalue_ItemDelivery].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemDelivery].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemFinishing == "true")
                {
                    item[this.cellvalue_ItemFinishing].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemFinishing].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemProofs == "true")
                {
                    item[this.cellvalue_ItemProofs].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemProofs].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemPacking == "true")
                {
                    item[this.cellvalue_ItemPacking].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemPacking].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemNotes == "true")
                {
                    item[this.cellvalue_ItemNotes].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemNotes].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemTermsInstructions == "true")
                {
                    item[this.cellvalue_ItemTermsInstructions].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemTermsInstructions].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactEmail == "true")
                {
                    item[this.cellvalue_ContactEmail].Attributes.Add("align", "left");
                    item[this.cellvalue_ContactEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ContactEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ComapnyEmail == "true")
                {
                    item[this.cellvalue_ComapnyEmail].Attributes.Add("align", "left");
                    item[this.cellvalue_ComapnyEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ComapnyEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactPhone == "true")
                {
                    item[this.cellvalue_ContactPhone].Attributes.Add("align", "left");
                    item[this.cellvalue_ContactPhone].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ContactPhone].Style.Add("cursor", "pointer");
                }
                if (this.flag_ArtworkDate == "true")
                {
                    item[this.cellvalue_ArtworkDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ArtworkDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ArtworkDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ArtworkDate == "true")
                {
                    item[this.cellvalue_ArtworkDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ArtworkDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ArtworkDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ProofDate == "true")
                {
                    item[this.cellvalue_ProofDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ProofDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ProofDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ApprovalDate == "true")
                {
                    item[this.cellvalue_ApprovalDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ApprovalDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ApprovalDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ProductionDate == "true")
                {
                    item[this.cellvalue_ProductionDate].Attributes.Add("align", "center");
                    item[this.cellvalue_ProductionDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ProductionDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_CompletionDate == "true")
                {
                    item[this.cellvalue_CompletionDate].Attributes.Add("align", "center");
                    item[this.cellvalue_CompletionDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CompletionDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_DeliveryDate == "true")
                {
                    item[this.cellvalue_DeliveryDate].Attributes.Add("align", "center");
                    item[this.cellvalue_DeliveryDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_DeliveryDate].Style.Add("cursor", "pointer");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            global.pageName = "estimate";
            global.pgName = "";
            this.gloobj.setpagename("estimate");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "estimate";
            this.pgsearch = "estimatesearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            if (!base.IsPostBack)
            {
                this.grvEstimateSearch.PageSize = 50;
                if (base.Request.Params["suc"] != null && base.Request.Params["suc"].ToString().ToLower() == "cop")
                {
                    Convert.ToInt64(base.Request.Params["estid"]);
                }
            }
            languageClass _languageClass = new languageClass();
            this.grvEstimateSearch.MasterTableView.NoMasterRecordsText = _languageClass.GetLanguageConversion("No_records_To_display");
            this.Page.Title = _languageClass.convert(global.pageTitle("Estimate View", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "estimates_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["EstViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["EstViewID"]);
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "estimate");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row in this.dt.Rows)
                {
                    this.defaultsortedby = row["SortedBy"].ToString();
                    this.defaultsortdirection = row["SortDirection"].ToString();
                }
            }
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            if (!base.IsPostBack)
            {
                this.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    this.SortedBy = "EstimateNumber";
                }
                else
                {
                    this.SortedBy = this.defaultsortedby;
                }
                if (this.defaultsortedby == "")
                {
                    this.sortdirection = "Desc";
                }
                else if (this.defaultsortdirection != "")
                {
                    this.sortdirection = this.defaultsortdirection;
                }
            }
            if (!base.IsPostBack && base.Request.QueryString["viewid"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                string str1 = string.Concat(this.pgsearch, this.UserID, this.pgsearch);
                base.Session["search_Est"] = null;
                base.Session[str1] = null;
                base.Session["EstViewID"] = this.defaultviewid;
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckAll", this.objJava.functionCheckAll());
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckChanged", this.objJava.functionCheckChange());
            }
            try
            {
                if (base.Request.QueryString["custom"] != null)
                {
                    string empty = string.Empty;
                    empty = base.Request.QueryString["custom"].ToString().Trim();
                    if (empty != "")
                    {
                        empty = this.objBase.ReplaceSingleQuote(empty);
                        this.GridBind(this.CompanyID, this.UserID, this.PageSize, 1, this.defaultviewid, "customerid", "desc", empty, this.ViewState["WhereCondition"].ToString());
                    }
                }
            }
            catch
            {
            }
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            if (!base.IsPostBack)
            {
                string str2 = "";
                string str3 = "";
                if (base.Request.Params["srch_val"] != null)
                {
                    BaseClass baseClass1 = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str4 = baseClass1.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str4, "%' OR Company LIKE '%", str4, "%' OR estimator LIKE '%", str4, "%' OR greeting LIKE '%", str4, "%' OR salesperson LIKE '%", str4, "%' OR estimatetitle LIKE '%", str4, "%' OR EstimateNumber LIKE '%", str4, "%' OR orderNumber LIKE '%", str4, "%' OR CustomerType like   '%", str4, "%' OR ((contactaddress + ' ' + DeliveryAddress + ' ' + Address1 + ' ' + Address2 + ' ' + Address3 + ' ' + Address4 + ' ' + Address5 + ' ' + InvoiceAddress) like  '%", str4, "%'))" };
                    str3 = string.Concat(strArrays);
                    str3 = string.Concat(str3, "AND EstimateNumber NOT LIKE '%Direct%'");
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["search_Est"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_Est"];
                    str2 = "";
                }
                base.Session["EstViewID"] = this.defaultviewid;
                this.PageSize = this.objJava.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvEstimateSearch);
                this.grvEstimateSearch.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.grvEstimateSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.grvEstimateSearch.Rebind();
            }
            try
            {
                this.grvEstimateSearch.MasterTableView.GetColumn("estimateitemid").Visible = false;
            }
            catch
            {
            }
            this.grvEstimateSearch.MasterTableView.GetColumn("estimateid").Visible = false;
            this.grvEstimateSearch.MasterTableView.GetColumn("jobid").Visible = false;
        }

        public void SetDDLValue(DropDownList ddl, string value)
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

        public event GetRecordCount getEstimateRecCount;
    }
}