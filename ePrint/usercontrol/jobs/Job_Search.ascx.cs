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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.usercontrol.jobs
{
    public partial class Job_Search : UsercontrolBasePage
    {
        public int jobRecCount;

        private Global gloobj = new Global();

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        private commonClass cmnClass = new commonClass();

        private createViewClass objCreateView = new createViewClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

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

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string cellvalue_completiondate = string.Empty;

        public string cellvalue_jobval = string.Empty;

        public string cellvalue_jobvalExcGst = string.Empty;

        public string cellvalue_converteddate = string.Empty;

        public string cellvalue_deliverydate = string.Empty;

        public string flag_completiondate = string.Empty;

        public string flag_jobval = string.Empty;

        public string flag_jobvalExcGst = string.Empty;

        public string flag_converteddate = string.Empty;

        public string flag_deliverydate = string.Empty;

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

        public string flag_status = string.Empty;

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

        public string cellvalue_jobtype = string.Empty;

        public string flag_jobtype = string.Empty;

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

        public string cellvalue_productiondate = string.Empty;

        public string flag_productiondate = string.Empty;

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        public int PageSize_Job;

        private DataSet ds = new DataSet();

        public string ViewCondition = string.Empty;

        public string ViewDays = string.Empty;

        public string ViewColor = string.Empty;

        public string option = string.Empty;

        private string JobViewColor = string.Empty;

        private DataTable dtColor = new DataTable();

        private DataTable dtArtwork = new DataTable();

        public int ViewID;

        public string Mode = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        private string pgsearch = string.Empty;

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

        public bool IsItemSelected;

        public string DateTypeSelected = string.Empty;

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

        public Job_Search()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.grvJobSearch.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "completiondate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate" || dt.Columns[i].ColumnName.ToLower() == "converteddate" || dt.Columns[i].ColumnName.ToLower() == "productiondate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                    if (dt.Columns[i].ColumnName.ToLower() == "isproformainvoice")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.String");
                    }
                }
                for (int j = 0; j < this.grvJobSearch.Columns.Count; j++)
                {
                    this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.grvJobSearch.Columns[j].HeaderStyle.Wrap = false;
                    if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "jobnumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_No");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_No");
                        this.flag_estimateno = "true";
                        this.cellvalue_estimateno = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_person");
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Title");
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.grvJobSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvJobSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.grvJobSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Status");
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "completiondate")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Completed_On");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_completiondate = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.flag_completiondate = "true";
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_deliverydate = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "productiondate")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Production_Date");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_productiondate = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.flag_productiondate = "true";
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Job_value"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_jobval = "true";
                        this.cellvalue_jobval = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "converteddate")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Converted_On");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_converteddate = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.flag_converteddate = "true";
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "quantity")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_quantity = "true";
                        this.cellvalue_quantity = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "isfromwebstore")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = "IsFromWebStore";
                        this.cellvalue_FromWebStore = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].Visible = false;
                        this.flag_isfromwebstore = "true";
                        this.cellvalue_isfromwebstore = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "orderid")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = "OrderID";
                        this.cellvalue_OrderID = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "isproformainvoice")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Raised");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_IsProformaInvoice = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.flag_isproformainvoice = "true";
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "proformainvoice")
                    {
                        this.grvJobSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "paid")
                    {
                        this.grvJobSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.grvJobSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.grvJobSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Job_Value_Exc_Tax"), "(", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_jobvalExcGst = "true";
                        this.cellvalue_jobvalExcGst = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("PAyment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("job_Type");
                        this.flag_jobtype = "true";
                        this.cellvalue_jobtype = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title_View");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Quantity");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value_View"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "eventname")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Name");
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Code_Number");
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Sign_Number");
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                        this.flag_ItemMaterial = "true";
                        this.cellvalue_ItemMaterial = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "eventvenue")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Venue");
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.grvJobSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.grvJobSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvJobSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_View");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "department")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "jobdate")
                    {
                        this.grvJobSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Date");
                        this.flag_JobDate = "true";
                        this.cellvalue_JobDate = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number");
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[j].SortExpression.ToLower() == "jobname")
                    {
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.grvJobSearch.Columns[j].SortExpression.ToLower();
                        this.grvJobSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
                    }
                }
            }
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)this.Page.Master.FindControl("keywordsearch");
            if (textBox.Text != "")
            {
                this.para = this.objBase.ReplaceSingleQuote(textBox.Text);
                base.Response.Redirect(string.Concat(this.objBase.strSitepath, "jobs/job_search.aspx?para=", this.para));
            }
        }

        protected void clrFilters_Click(object sender, EventArgs e)
        {
            this.WhereCondition = "";
            base.Session["search_job"] = null;
            foreach (GridColumn column in this.grvJobSearch.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.grvJobSearch.MasterTableView.FilterExpression = string.Empty;
            this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
            this.grvJobSearch.MasterTableView.Rebind();
        }

        public void GetDatetimeValue_ViewColor(int CompanyID)
        {
            this.DateTypeSelected = EstimatesBasePage.settings_jobViewColor_SelectedDateType(CompanyID);
            if (this.DateTypeSelected == "Delivery")
            {
                this.DateTypeSelected = "";
            }
            this.dtColor = this.objCreateView.Settings_JobViewColor_Select(CompanyID, this.DateTypeSelected);
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
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            viewClass _viewClass = new viewClass();
            empty = _viewClass.ReturnFinalQueryForNewCustomView_ForSearch(CompanyID, UserID, PageSize, PageNumber, this.pg, ViewID, SortedBy, SortDirection, para, new_para);
            commonClass _commonClass = new commonClass();
            SqlCommand sqlCommand = new SqlCommand("PC_CustomizeView_Execute", _commonClass.openConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.CommandTimeout = Int32.MaxValue;//KR 01-11-2018
            //sqlCommand.CommandTimeout = 300;
            sqlCommand.Parameters.AddWithValue("@strSQL", empty);
            (new SqlDataAdapter(sqlCommand)).Fill(this.ds);
            dataTable = this.ds.Tables[0];
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
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
                    if (row.Table.Columns.Contains("Proofdate"))
                    {
                        row["Proofdate"] = this.cmnClass.Eprint_return_Date_Before_View(row["Proofdate"].ToString(), CompanyID, UserID, false);
                    }
                    if (dataTable.Columns.Contains("IsProformaInvoice"))
                    {
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
                    if (row.Table.Columns.Contains("JobNumber"))
                    {
                        row["JobNumber"] = this.objBase.SpecialDecode(row["JobNumber"].ToString());
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
                    if (row.Table.Columns.Contains("CustomerOrderNumber"))
                    {
                        row["CustomerOrderNumber"] = this.objBase.SpecialDecode(row["CustomerOrderNumber"].ToString());
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
                    if (row.Table.Columns.Contains("EventVenue"))
                    {
                        row["EventVenue"] = this.objBase.SpecialDecode(row["EventVenue"].ToString());
                    }
                    if (row.Table.Columns.Contains("JobDate"))
                    {
                        row["JobDate"] = this.cmnClass.Eprint_return_Date_Before_View(row["JobDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CompanyEmail"))
                    {
                        row["CompanyEmail"] = this.objBase.SpecialDecode(row["CompanyEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactEmail"))
                    {
                        row["ContactEmail"] = this.objBase.SpecialDecode(row["ContactEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("MainItemSupplier"))
                    {
                        row["MainItemSupplier"] = this.objBase.SpecialDecode(row["MainItemSupplier"].ToString());
                    }
                    if (row.Table.Columns.Contains("JobName"))
                    {
                        row["JobName"] = this.objBase.SpecialDecode(row["JobName"].ToString());
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
            this.grvJobSearch.DataSource = this.ds;
            if (dataTable.Rows.Count <= 0)
            {
                this.AddBoundColumns(dataTable, this.grvJobSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvJobSearch.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataTable, this.grvJobSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvJobSearch.AllowCustomPaging = true;
                this.grvJobSearch.VirtualItemCount = Convert.ToInt32(this.ds.Tables[1].Rows[0][0].ToString());
                this.jobRecCount = Convert.ToInt32(this.ds.Tables[1].Rows[0][0].ToString());
                if (this.getJobRecCount != null)
                {
                    this.getJobRecCount(this.jobRecCount);
                    return;
                }
            }
        }

        private void GridStateLoad()
        {
            this.cmnClass.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvJobSearch, "yes");
        }

        private void GridStateSave()
        {
            this.cmnClass.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvJobSearch);
        }

        protected void grvJobSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBase.ReplaceSingleQuote(item.Text);
                string empty = string.Empty;
                string empty1 = string.Empty;
                foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(this.CompanyID).Rows)
                {
                    Convert.ToInt32(row["Roundoff"].ToString());
                }
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "estimatevalue" || commandArgument.Second.ToString().ToLower() == "quantity"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text == "")
                    {
                        this.objBase.Message_Display("Pls Enter only Number", "msg-fail", this.plhErrorMessage);
                    }
                    else
                    {
                        item.Text = item.Text;
                    }
                }
                if (base.Session["search_job"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_job"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_job"];
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
                base.Session["search_job"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.grvJobSearch.Rebind();
            }
        }

        protected void grvJobSearch_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvJobSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvJobSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvJobSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvJobSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.grvJobSearch.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void grvJobSearch_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, this.grvJobSearch.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void grvJobSearch_SortCommand(object sender, GridSortCommandEventArgs e)
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
            this.grvJobSearch.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, this.grvJobSearch.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void lnkBtnViewMore_Click(object sender, EventArgs e)
        {
            this.grvJobSearch.AllowPaging = false;
            this.GridBind(this.CompanyID, this.UserID, 1000, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
            this.grvJobSearch.DataBind();
            int count = this.grvJobSearch.Items.Count;
            this.grvJobSearch.AllowPaging = true;
            this.grvJobSearch.Rebind();
            this.grvJobSearch.PageSize = this.grvJobSearch.PageSize + 10;
            this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
            this.grvJobSearch.Rebind();
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

        protected void OnRowDataBound_grvJobSearch(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.grvJobSearch.Columns.Count; i++)
                {
                    if (this.grvJobSearch.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.grvJobSearch.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "converteddate")
                    {
                        this.cellvalue_converteddate = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                        this.flag_converteddate = "true";
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatevalue")
                    {
                        this.flag_jobval = "true";
                        this.cellvalue_jobval = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.cellvalue_completiondate = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                        this.flag_completiondate = "true";
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.cellvalue_deliverydate = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                        this.flag_deliverydate = "true";
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "productiondate")
                    {
                        this.cellvalue_productiondate = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                        this.flag_productiondate = "true";
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "isproformainvoice")
                    {
                        this.cellvalue_IsProformaInvoice = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                        this.flag_isproformainvoice = "true";
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_jobvalExcGst = "true";
                        this.cellvalue_jobvalExcGst = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_customername = "true";
                        this.cellvalue_customername = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "attentionid")
                    {
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.flag_salesperson = "true";
                        this.cellvalue_salesperson = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.flag_status = "true";
                        this.cellvalue_status = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_estimateno = "true";
                        this.cellvalue_estimateno = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.flag_customerordernumber = "true";
                        this.cellvalue_customerordernumber = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatetitle")
                    {
                        this.flag_jobtitle = "true";
                        this.cellvalue_jobtitle = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.flag_jobtype = "true";
                        this.cellvalue_jobtype = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "department")
                    {
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "jobdate")
                    {
                        this.flag_JobDate = "true";
                        this.cellvalue_JobDate = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "eventvenue")
                    {
                        this.flag_EventVenue = "true";
                        this.cellValue_EventVenue = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvJobSearch.Columns[i].SortExpression.ToLower() == "jobname")
                    {
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.grvJobSearch.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plhInv");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plh_attach");
                string str = string.Empty;
                string languageConversion = string.Empty;
                str = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                string empty1 = string.Empty;
                string str1 = string.Empty;
                empty1 = string.Concat(this.strImagepath, "Attachment.PNG");
                str1 = "Item with an attachment(s)";
                string empty2 = string.Empty;
                DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", ((DataRowView)e.Item.DataItem)[1].ToString()));
                if ((int)dataRowArray.Length > 0)
                {
                    empty2 = dataRowArray[0]["ArtWork"].ToString();
                }
                if (item["EstItemCoun"].Text != "0" || empty2 != "")
                {
                    ControlCollection controls = placeHolder2.Controls;
                    string[] strArrays = new string[] { "<img src='", empty1, "' title='", str1, "' style='cursor:pointer;' />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                else
                {
                    placeHolder2.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controlCollections = placeHolder.Controls;
                    string[] strArrays1 = new string[] { "<img src='", str, "'  title='", languageConversion, "' class='viewicon_margin'  />" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                string str2 = string.Empty;
                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgProformaInvoice");
                if (item["ProformaInvoice"].Text != "1")
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else
                {
                    string empty3 = string.Empty;
                    string str3 = string.Empty;
                    if (item["Paid"].Text != "1")
                    {
                        empty3 = string.Concat(this.strImagepath, "invoiced.PNG");
                        str3 = "Invoice raised";
                    }
                    else
                    {
                        empty3 = string.Concat(this.strImagepath, "invoiced-paid.PNG");
                        str3 = "Invoice raised and Paid";
                    }
                    if (item["IsFromWebStore"].Text.Trim().ToLower() != "yes")
                    {
                        ControlCollection controls1 = placeHolder1.Controls;
                        string[] text = new string[] { "<a href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?frm=view&InvID=", item["InvoiceID"].Text, "&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "><img src='", empty3, "' border='0' title='", str3, "'/></a>" };
                        controls1.Add(new LiteralControl(string.Concat(text)));
                    }
                    else
                    {
                        ControlCollection controlCollections1 = placeHolder1.Controls;
                        string[] text1 = new string[] { "<a href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&InvID=", item["InvoiceID"].Text, "&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "><img src='", empty3, "' border='0' title='", str3, "'/></a>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(text1)));
                    }
                }
                if (item["IsFromWebStore"].Text.Trim().ToLower() != "yes")
                {
                    empty = string.Concat("jobs/job_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell = item["jobnumber"];
                        string[] strArrays2 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        tableCell.Text = string.Concat(strArrays2);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item1 = item["jobnumber"];
                        string[] strArrays3 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_summary_reeng.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["jobnumber"].Text, "</a>" };
                        item1.Text = string.Concat(strArrays3);
                    }
                }
                else
                {
                    string[] str4 = new string[] { "jobs/job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString() };
                    empty = string.Concat(str4);
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell1 = item["jobnumber"];
                        string[] strArrays4 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["jobnumber"].Text, "</a>" };
                        tableCell1.Text = string.Concat(strArrays4);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item2 = item["jobnumber"];
                        string[] str5 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["OrderID"].Text, "&jID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["jobnumber"].Text, "</a>" };
                        item2.Text = string.Concat(str5);
                    }
                }
                if (((DataRowView)e.Item.DataItem).DataView.Table.Columns.Contains("CustomerType") && item["CustomerType"].Text.Trim().Length > 30)
                {
                    item["CustomerType"].ToolTip = item["CustomerType"].Text;
                    item["CustomerType"].Text = string.Concat(item["CustomerType"].Text.Substring(0, 30), "..");
                }
                if (this.flag_jobval == "true")
                {
                    item[this.cellvalue_jobval].Attributes.Add("align", "right");
                    item[this.cellvalue_jobval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobval].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_jobval];
                    string[] strArrays5 = new string[] { "<div style='min-width: 100px ;width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_jobval].Text.ToString()), 0, "", false, false, true), "</div>" };
                    tableCell2.Text = string.Concat(strArrays5);
                }
                if (this.flag_jobvalExcGst == "true")
                {
                    item[this.cellvalue_jobvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_jobvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobvalExcGst].Style.Add("cursor", "pointer");
                    TableCell item3 = item[this.cellvalue_jobvalExcGst];
                    string[] strArrays6 = new string[] { "<div style='min-width: 100px ;width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_jobvalExcGst].Text.ToString()), 0, "", false, false, true), "</div>" };
                    item3.Text = string.Concat(strArrays6);
                }
                if (this.flag_converteddate == "true")
                {
                    item[this.cellvalue_converteddate].Attributes.Add("align", "center");
                    item[this.cellvalue_converteddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_converteddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_completiondate == "true")
                {
                    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_completiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_completiondate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                    if (this.DateTypeSelected == "" || this.DateTypeSelected == "Delivery")
                    {
                        try
                        {
                            string empty4 = string.Empty;
                            string empty5 = string.Empty;
                            int days = 0;
                            TimeSpan timeSpan = new TimeSpan();
                            empty4 = Convert.ToString(DateTime.Now.ToString());
                            item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));
                            DateTime dateTime = this.cmnClass.Eprint_return_ActualDate_Before_View(empty4, this.CompanyID, this.UserID, true);
                            DateTime dateTime1 = Convert.ToDateTime(dateTime.ToShortDateString());
                            DateTime dateTime2 = this.cmnClass.Eprint_return_ActualDate_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false);
                            DateTime dateTime3 = Convert.ToDateTime(dateTime2.ToShortDateString());
                            timeSpan = dateTime3 - dateTime1;
                            days = timeSpan.Days;
                            if (days > 0)
                            {
                                DataRow[] dataRowArray1 = this.dtColor.Select(string.Concat("Days>= ", days));
                                if ((int)dataRowArray1.Length > 0)
                                {
                                    empty5 = dataRowArray1[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days == 0)
                            {
                                DataRow[] dataRowArray2 = this.dtColor.Select("[optionType]= 'On same day'");
                                if ((int)dataRowArray2.Length > 0)
                                {
                                    empty5 = dataRowArray2[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            else if (days < 0)
                            {
                                DataRow[] dataRowArray3 = this.dtColor.Select("[optionType]= 'elapsed'");
                                if ((int)dataRowArray3.Length > 0)
                                {
                                    empty5 = dataRowArray3[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(empty5);
                            }
                            item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                            item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        item[this.cellvalue_deliverydate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_deliverydate].Text, this.CompanyID, this.UserID, false));
                    }
                }
                if (this.flag_productiondate == "true")
                {
                    item[this.cellvalue_productiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_productiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_productiondate].Style.Add("cursor", "pointer");
                    if (this.DateTypeSelected != "Production")
                    {
                        item[this.cellvalue_productiondate].Text = (item[this.cellvalue_productiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false));
                    }
                    else
                    {
                        try
                        {
                            string empty6 = string.Empty;
                            string str6 = string.Empty;
                            int num = 0;
                            TimeSpan timeSpan1 = new TimeSpan();
                            empty6 = Convert.ToString(DateTime.Now.ToString());
                            item[this.cellvalue_productiondate].Text = (item[this.cellvalue_deliverydate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.comm.Eprint_return_Date_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false));
                            DateTime dateTime4 = this.cmnClass.Eprint_return_ActualDate_Before_View(empty6, this.CompanyID, this.UserID, true);
                            DateTime dateTime5 = Convert.ToDateTime(dateTime4.ToShortDateString());
                            DateTime dateTime6 = this.cmnClass.Eprint_return_ActualDate_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false);
                            DateTime dateTime7 = Convert.ToDateTime(dateTime6.ToShortDateString());
                            timeSpan1 = dateTime7 - dateTime5;
                            num = timeSpan1.Days;
                            if (num > 0)
                            {
                                DataRow[] dataRowArray4 = this.dtColor.Select(string.Concat("Days>= ", num));
                                if ((int)dataRowArray4.Length > 0)
                                {
                                    str6 = dataRowArray4[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(str6);
                            }
                            else if (num == 0)
                            {
                                DataRow[] dataRowArray5 = this.dtColor.Select("[optionType]= 'On same day'");
                                if ((int)dataRowArray5.Length > 0)
                                {
                                    str6 = dataRowArray5[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(str6);
                            }
                            else if (num < 0)
                            {
                                DataRow[] dataRowArray6 = this.dtColor.Select("[optionType]= 'elapsed'");
                                if ((int)dataRowArray6.Length > 0)
                                {
                                    str6 = dataRowArray6[0]["color"].ToString();
                                }
                                item.BackColor = ColorTranslator.FromHtml(str6);
                            }
                            item[this.cellvalue_productiondate].Attributes.Add("align", "center");
                            item[this.cellvalue_productiondate].Text = (item[this.cellvalue_productiondate].Text.ToString() == "01/01/1900" ? "01/01/1900" : this.cmnClass.Eprint_return_Date_Before_View(item[this.cellvalue_productiondate].Text, this.CompanyID, this.UserID, false));
                        }
                        catch
                        {
                        }
                    }
                }
                if (this.flag_quantity == "true")
                {
                    item[this.cellvalue_quantity].Attributes.Add("align", "right");
                    item[this.cellvalue_quantity].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_quantity].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_quantity];
                    string[] str7 = new string[] { "<div style='min-width: 100px ;width:", this.type1, " ;overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_quantity].Text.ToString(), "</div>" };
                    tableCell3.Text = string.Concat(str7);
                }
                if (this.flag_isproformainvoice == "true")
                {
                    item[this.cellvalue_IsProformaInvoice].Attributes.Add("align", "Center");
                    item[this.cellvalue_IsProformaInvoice].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_IsProformaInvoice].Style.Add("cursor", "pointer");
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
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
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
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
                if (this.flag_jobtype == "true")
                {
                    item[this.cellvalue_jobtype].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_jobtype].Style.Add("cursor", "pointer");
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
                    item[this.cellvalue_JobDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
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
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    TableCell item4 = item[this.cellvalue_ItemStatus];
                    string[] text2 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    item4.Text = string.Concat(text2);
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
                }
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
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemValue_ExcTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax].Text), 0, "", false, false, true);
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
                        item[this.cellvalue_ItemGrossProfitPercentage].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage].Text), 0, "", false, false, true);
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
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("align", "right");
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
                        item[this.cellvalue_Height].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Height].Text), 0, "", false, false, true);
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
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemDescription == "true")
                {
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
                    item[this.cellvalue_JobDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
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
                if (this.flag_JobName == "true")
                {
                    item[this.cellvalue_JobName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobName].Style.Add("cursor", "pointer");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grvJobSearch.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_Records_TO_display");
            global.pageName = "job";
            global.pgName = "";
            this.gloobj.setpagename("job");
            this.pg = "job";
            this.pgsearch = "jobsearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            this.GetDatetimeValue_ViewColor(this.CompanyID);
            this.DateFormat = base.Session["Dateformat"].ToString();
            this.strImagepath = global.imagePath();
            this.Page.Title = this.objLanguage.convert(global.pageTitle("Jobs Search", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_DateTime_Before_View(now.ToString().ToString(), this.CompanyID, this.UserID, true);
            string str = this.comm.UserSetting_Selete(this.CompanyID, this.UserID, "jobs_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["JobViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["JobViewID"]);
            }
            if (!base.IsPostBack)
            {
                if (base.Session["Search_job"] != null)
                {
                    base.Session["Search_Job"] = null;
                }
                this.grvJobSearch.PageSize = 50;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "job");
            if (this.dt.Rows.Count != 0)
            {
                foreach (DataRow row in this.dt.Rows)
                {
                    this.defaultsortedby = row["SortedBy"].ToString();
                    this.defaultsortdirection = row["SortDirection"].ToString();
                }
            }
            if (!base.IsPostBack)
            {
                this.WhereCondition = "";
                if (this.defaultsortedby == "")
                {
                    this.SortedBy = "JobNumber";
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
                base.Session["search_job"] = null;
                base.Session[str1] = null;
                base.Session["JobViewID"] = this.defaultviewid;
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckAll"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckAll", this.cmnClass.functionCheckAll());
            }
            if (!this.Page.IsClientScriptBlockRegistered("clientScriptCheckChanged"))
            {
                this.Page.RegisterClientScriptBlock("clientScriptCheckChanged", this.cmnClass.functionCheckChange());
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
                        this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, 1, this.defaultviewid, "customerid", "desc", empty, this.ViewState["WhereCondition"].ToString());
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
                    BaseClass baseClass = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str4 = baseClass.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str4, "%' OR estimator LIKE '%", str4, "%' OR salesperson LIKE '%", str4, "%' OR jobNumber LIKE '%", str4, "%' OR estimateNumber LIKE '%", str4, "%' OR CustomerOrderNumber LIKE '%", str4, "%' OR StatusID LIKE '%", str4, "%' OR estimatetitle LIKE '%", str4, "%' OR Greeting like '%", str4, "%' OR CustomerType like   '%", str4, "%' OR ((contactaddress + ' ' + DeliveryAddress + ' ' + InvoiceAddress + ' ' + Address1 + ' ' + Address2 + ' ' + Address3 + ' ' + Address4 + ' ' + Address5) like '%", str4, "%') OR Department like '%", str4, "%')" };
                    str3 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["search_job"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_job"];
                    str2 = "";
                }
                base.Session["JobViewID"] = this.defaultviewid;
                int num1 = this.cmnClass.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvJobSearch);
                this.grvJobSearch.PageSize = num1;
                this.GridBind(this.CompanyID, this.UserID, this.grvJobSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.grvJobSearch.Rebind();
                if (this.Mode.ToLower() != "all")
                {
                    this.divContentJob.Style.Value = "display:block";
                }
                else
                {
                    this.divContentJob.Style.Value = "display:none";
                }
            }
            this.grvJobSearch.MasterTableView.GetColumn("jobid").Visible = false;
            this.grvJobSearch.MasterTableView.GetColumn("estimateid").Visible = false;
            if (this.grvJobSearch.MasterTableView.GetColumn("estimateitemid") != null)
            {
                this.grvJobSearch.MasterTableView.GetColumn("estimateitemid").Visible = false;
            }
            this.grvJobSearch.MasterTableView.GetColumn("InvoiceID").Visible = false;
        }

        public event GetJobRecordCount getJobRecCount;
    }
}