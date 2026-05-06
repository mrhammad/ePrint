using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
using Printcenter.UI.Company;
using Printcenter.UI.Estimates;
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

namespace ePrint.usercontrol.orders
{
    public partial class Order_Search : UsercontrolBasePage
    {
        public int OrderRecCount;

        private Global gloobj = new Global();

        private languageClass objLanguage = new languageClass();

        private commonClass objJava = new commonClass();

        private BasePage objpage = new BasePage();

        private BaseClass objBase = new BaseClass();

        private CompanyBasePage objComp = new CompanyBasePage();

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

        public int CompanyID;

        public int UserID;

        public string pg;

        public string DateFormat = string.Empty;

        public int defaultviewid;

        public int totalrec;

        private string para = string.Empty;

        public string WhereCondition = string.Empty;

        public string SortedBy = string.Empty;

        public string sortdirection = string.Empty;

        private createViewClass objCreateView = new createViewClass();

        public string flag_estval = string.Empty;

        public string cellvalue_estval = string.Empty;

        public string cellvalue_estvalExcGst = string.Empty;

        public string flag_estvalExcGst = string.Empty;

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

        public string cellvalue_referredby = string.Empty;

        public string flag_referredby = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_quantity1 = string.Empty;

        public string flag_quantity1 = string.Empty;

        public string cellvalue_quantity2 = string.Empty;

        public string flag_quantity2 = string.Empty;

        public string cellvalue_quantity3 = string.Empty;

        public string flag_quantity3 = string.Empty;

        public string cellvalue_quantity4 = string.Empty;

        public string flag_quantity4 = string.Empty;

        public string cellvalue_costcentre = string.Empty;

        public string flag_costcentre = string.Empty;

        public string cellvalue_estdate = string.Empty;

        public string cellvalue_orderno = string.Empty;

        public string StockCancellationType = string.Empty;

        public static int ManageStockPermission;

        public string cellvalue_orderedfor = string.Empty;

        public string flag_orderedfor = string.Empty;

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

        private DataTable dtsearch = new DataTable();

        public long EstNo;

        public string newdate = string.Empty;

        public int PageSize;

        public int ViewID;

        public string Mode = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string pgsearch = string.Empty;

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

        public string flag_IsApproved = string.Empty;

        public string cellvalue_IsApproved = string.Empty;

        public string flag_ItemMaterial = string.Empty;

        public string cellvalue_ItemMaterial = string.Empty;

        public string flag_EventVenue = string.Empty;

        public string cellvalue_EventVenue = string.Empty;

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

        public string cellvalue_OrderBy = string.Empty;

        public string flag_OrderBy = string.Empty;

        public string cellvalue_Department = string.Empty;

        public string flag_Department = string.Empty;

        public string cellvalue_CompamyEmail = string.Empty;

        public string flag_CompamyEmail = string.Empty;

        public string cellvalue_ContactEmail = string.Empty;

        public string flag_ContactEmail = string.Empty;

        public string cellvalue_ContactPhone = string.Empty;

        public string flag_ContactPhone = string.Empty;

        public string cellvalue_CustomerOrderNumber = string.Empty;

        public string flag_CustomerOrderNumber = string.Empty;

        public string cellvalue_PaymentType = string.Empty;

        public string flag_PaymentType = string.Empty;

        public string cellvalue_DeliveryDate = string.Empty;

        public string flag_DeliveryDate = string.Empty;

        public bool IsItemSelected;

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

        static Order_Search()
        {
        }

        public Order_Search()
        {
        }

        public void AddBoundColumns(DataTable dt, RadGrid gv)
        {
            if (!base.IsPostBack)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridBoundColumn gridBoundColumn = new GridBoundColumn();
                    this.grvOrderSearch.MasterTableView.Columns.Add(gridBoundColumn);
                    gridBoundColumn.UniqueName = dt.Columns[i].ColumnName;
                    gridBoundColumn.SortExpression = dt.Columns[i].ColumnName;
                    gridBoundColumn.DataField = dt.Columns[i].ColumnName;
                    gridBoundColumn.HeaderText = dt.Columns[i].ColumnName;
                    gridBoundColumn.AutoPostBackOnFilter = false;
                    gridBoundColumn.CurrentFilterFunction = GridKnownFunction.Contains;
                    gridBoundColumn.AutoPostBackOnFilter = true;
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "ordereddate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                }
                for (int j = 0; j < this.grvOrderSearch.Columns.Count; j++)
                {
                    this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.grvOrderSearch.Columns[j].HeaderStyle.Wrap = false;
                    if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "oredernumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_No");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "salesperson")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Sales_Person");
                        this.flag_sales = "true";
                        this.cellvalue_sales = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "ordertitle")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_Title");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(150);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(150);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_estTitle = "true";
                        this.cellvalue_estTitle = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "attentionid")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Name");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_contactname = "true";
                        this.cellvalue_contactname = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "estitemcoun")
                    {
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "customerid")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Name");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "company")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_company = "true";
                        this.cellvalue_company = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "ordernumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_No");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "statusid")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Status");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(200);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "userid")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "validfor")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Valid_For");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_validfor = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Created_On");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "ordervalue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Order_Value"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "ordereddate")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Order_Date");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_estdate = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "quantity1")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity1");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity1 = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity1 = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "quantity2")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity2");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity2 = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity2 = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "quantity3")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity3");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity3 = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity3 = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "quantity4")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity4");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_quantity4 = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.flag_quantity4 = "true";
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "accountcodeid")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Code");
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "referredby")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Referred_By");
                        this.flag_referredby = "true";
                        this.cellvalue_estimator = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "IsCompletlyConvertedToJob")
                    {
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "isarchive")
                    {
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Account_Number");
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.grvOrderSearch.Columns[j].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Order_Value_Exc_Tax"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_estvalExcGst = "true";
                        this.cellvalue_estvalExcGst = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_Centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "estimator")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimator");
                        this.flag_estimator = "true";
                        this.cellvalue_estimator = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "orderedfor")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_For");
                        this.flag_orderedfor = "true";
                        this.cellvalue_orderedfor = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title_View");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Accounting_Code_View");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Exc_Tax_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Value_Inc_Tax_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Tax_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Markup_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Cost_Price_Inc_Markup_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Percentage_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Profit_Margin_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Percentage_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Item_Gross_Profit_Value_View"), " (", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "eventname")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Name");
                        this.flag_EventName = "true";
                        this.cellvalue_EventName = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Code_Number");
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Sign_Number");
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "approved")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Is_Approved");
                        this.flag_IsApproved = "true";
                        this.cellvalue_IsApproved = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemmaterial")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Material_Specific_View");
                        this.flag_ItemMaterial = "true";
                        this.cellvalue_ItemMaterial = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "eventvenue")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Event_Venue");
                        this.flag_EventVenue = "true";
                        this.cellvalue_EventVenue = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "orderedheight")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_Height");
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_Width");
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemdescription")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Description_View");
                        this.grvOrderSearch.Columns[j].HeaderStyle.Width = Unit.Pixel(300);
                        this.grvOrderSearch.Columns[j].ItemStyle.Width = Unit.Pixel(300);
                        this.grvOrderSearch.Columns[j].ItemStyle.Wrap = false;
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemcolour")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Colour_View");
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemsize")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Size_View");
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemartwork")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Artwork_View");
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Delivery_View");
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Finishing_View");
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemproofs")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Proofs_View");
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itempacking")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Packing_View");
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemnotes")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Notes_View");
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "itemterms_instructions")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Itemterms_instructions_View");
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "jobname")
                    {
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "orderedby")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Ordered_By");
                        this.flag_OrderBy = "true";
                        this.cellvalue_OrderBy = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "department")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Department");
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "companyemail")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Company_Email");
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "contactemail")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Email");
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "contactphone")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Contact_Phone");
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Order_Number");
                        this.flag_CustomerOrderNumber = "true";
                        this.cellvalue_CustomerOrderNumber = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "paymenttype")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Type");
                        this.flag_PaymentType = "true";
                        this.cellvalue_PaymentType = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.grvOrderSearch.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.grvOrderSearch.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.grvOrderSearch.Columns[j].SortExpression.ToLower();
                    }
                }
            }
        }

        protected void btn_Delete(object sender, EventArgs e)
        {
            EstimateBasePage.Estimate_Delete(Convert.ToInt32(base.Session["companyid"]), Convert.ToInt64(this.hdnOrderID.Value));
            this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.para, this.ViewState["WhereCondition"].ToString());
        }

        private void btnFreeTextSearch_Click(object sender, ImageClickEventArgs e)
        {
            TextBox textBox = (TextBox)this.Page.FindControl("keywordsearch");
            if (textBox.Text != "")
            {
                this.para = this.objBase.ReplaceSingleQuote(textBox.Text.Trim());
                base.Response.Redirect(string.Concat(this.strSitepath, "orders/order_search.aspx?para=", this.para));
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
                    if (row.Table.Columns.Contains("OrderedDate"))
                    {
                        row["OrderedDate"] = this.objJava.Eprint_return_Date_Before_View(row["OrderedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CustomerID"))
                    {
                        row["CustomerID"] = this.objBase.SpecialDecode(row["CustomerID"].ToString());
                    }
                    if (row.Table.Columns.Contains("SalesPerson"))
                    {
                        row["SalesPerson"] = this.objBase.SpecialDecode(row["SalesPerson"].ToString());
                    }
                    if (row.Table.Columns.Contains("ReferredBy"))
                    {
                        row["ReferredBy"] = this.objBase.SpecialDecode(row["ReferredBy"].ToString());
                    }
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("OrderTitle"))
                    {
                        row["OrderTitle"] = this.objBase.SpecialDecode(row["OrderTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerAccountNumber"))
                    {
                        row["CustomerAccountNumber"] = this.objBase.SpecialDecode(row["CustomerAccountNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("PAymentTerms"))
                    {
                        row["PAymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("CostCentre"))
                    {
                        row["CostCentre"] = this.objBase.SpecialDecode(row["CostCentre"].ToString());
                    }
                    if (row.Table.Columns.Contains("OrderedFor"))
                    {
                        row["OrderedFor"] = this.objBase.SpecialDecode(row["OrderedFor"].ToString());
                    }
                    if (row.Table.Columns.Contains("OrderedBy"))
                    {
                        row["OrderedBy"] = this.objBase.SpecialDecode(row["OrderedBy"].ToString());
                    }
                    if (row.Table.Columns.Contains("ActualDeliveryDate"))
                    {
                        row["ActualDeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["ActualDeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CompanyEmail"))
                    {
                        row["CompanyEmail"] = this.objBase.SpecialDecode(row["CompanyEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactEmail"))
                    {
                        row["ContactEmail"] = this.objBase.SpecialDecode(row["ContactEmail"].ToString());
                    }
                    if (!row.Table.Columns.Contains("IsApproved"))
                    {
                        continue;
                    }
                    if (row["IsApproved"].ToString() != "0")
                    {
                        row["IsApproved"] = this.objLanguage.GetLanguageConversion("Yes");
                    }
                    else
                    {
                        row["IsApproved"] = this.objLanguage.GetLanguageConversion("No");
                    }
                }
            }
            _commonClass.closeConnection();
            this.grvOrderSearch.DataSource = dataSet;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvOrderSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvOrderSearch.AllowCustomPaging = false;
            }
            else
            {
                this.AddBoundColumns(dataSet.Tables[0], this.grvOrderSearch);
                this.div_Main.Style.Add("display", "block");
                this.grvOrderSearch.AllowCustomPaging = true;
                this.grvOrderSearch.VirtualItemCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                this.OrderRecCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getOrderRecCount != null)
                {
                    this.getOrderRecCount(this.OrderRecCount);
                    return;
                }
            }
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvOrderSearch, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvOrderSearch);
        }

        protected void grvOrderSearch_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
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

        protected void grvOrderSearch_ItemCommand(object sender, GridCommandEventArgs e)
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
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "ordervalue" || commandArgument.Second.ToString().ToLower() == "quantity1" || commandArgument.Second.ToString().ToLower() == "quantity2" || commandArgument.Second.ToString().ToLower() == "quantity3" || commandArgument.Second.ToString().ToLower() == "quantity4"))
                {
                    item.Text = item.Text.Replace(",", "");
                    item.Text = this.Only_number(item.Text);
                    if (item.Text != "")
                    {
                        item.Text = item.Text;
                    }
                }
                if (base.Session["search_ord"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_ord"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_ord"];
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
                base.Session["search_ord"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.grvOrderSearch.Rebind();
            }
        }

        protected void grvOrderSearch_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvOrderSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvOrderSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvOrderSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.grvOrderSearch.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.grvOrderSearch.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void grvOrderSearch_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.grvOrderSearch.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, this.grvOrderSearch.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void grvOrderSearch_SortCommand(object sender, GridSortCommandEventArgs e)
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
            this.grvOrderSearch.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, this.grvOrderSearch.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
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

        protected void OnRowDataBound_grvOrderSearch(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.grvOrderSearch.Columns.Count; i++)
                {
                    if (this.grvOrderSearch.MasterTableView.Columns[i].HeaderText.ToLower() == "accountcodeid")
                    {
                        this.grvOrderSearch.MasterTableView.Columns[i].HeaderText = "Account Code";
                    }
                    if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_createddate = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "ordervalue")
                    {
                        this.flag_estval = "true";
                        this.cellvalue_estval = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "ordereddate")
                    {
                        this.cellvalue_estdate = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estdate = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "validfor")
                    {
                        this.cellvalue_validfor = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_validfor = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.cellvalue_AccountStatus = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_AccountStatus = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "statusid")
                    {
                        this.cellvalue_status = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_status = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "order")
                    {
                        this.cellvalue_order = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_order = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "greeting")
                    {
                        this.cellvalue_greeting = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_greeting = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "estimator")
                    {
                        this.cellvalue_estimator = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estimator = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "customername")
                    {
                        this.cellvalue_custname = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_custname = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "company")
                    {
                        this.cellvalue_company = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_company = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_sales = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_sales = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "contactname")
                    {
                        this.cellvalue_contactname = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_contactname = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "header")
                    {
                        this.cellvalue_Header = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_Header = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "footer")
                    {
                        this.cellvalue_footer = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_footer = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "ordertitle")
                    {
                        this.cellvalue_estTitle = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                        this.flag_estTitle = "true";
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "estimateid")
                    {
                        this.grvOrderSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "iscompletlyconvertedtojob")
                    {
                        this.grvOrderSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "isarchived")
                    {
                        this.grvOrderSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "isdeletedjob")
                    {
                        this.grvOrderSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.flag_estvalExcGst = "true";
                        this.cellvalue_estvalExcGst = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "customerid")
                    {
                        this.flag_custname = "true";
                        this.cellvalue_custname = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "referredby")
                    {
                        this.flag_referredby = "true";
                        this.cellvalue_referredby = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "customeraccountnumber")
                    {
                        this.flag_customeraccountnumber = "true";
                        this.cellvalue_customeraccountnumber = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "paymentterms")
                    {
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "backorder")
                    {
                        this.grvOrderSearch.Columns[i].Visible = false;
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "orderedfor")
                    {
                        this.flag_orderedfor = "true";
                        this.cellvalue_orderedfor = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemaccountingcode")
                    {
                        this.flag_ItemAccCode = "true";
                        this.cellvalue_ItemAccCode = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemquantity")
                    {
                        this.flag_ItemQTY = "true";
                        this.cellvalue_ItemQTY = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemvalueexctax")
                    {
                        this.flag_ItemValue_ExcTax = "true";
                        this.cellvalue_ItemValue_ExcTax = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemvalueintax")
                    {
                        this.flag_ItemValue_IncTax = "true";
                        this.cellvalue_ItemValue_IncTax = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemtaxvalue")
                    {
                        this.flag_ItemTaxValue = "true";
                        this.cellvalue_ItemTaxValue = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceexcmarkup")
                    {
                        this.flag_ItemCostPriceExcMarkup = "true";
                        this.cellvalue_ItemCostPriceExcMarkup = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemmarkupvalue")
                    {
                        this.flag_ItemMarkupValue = "true";
                        this.cellvalue_ItemMarkupValue = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemcostpriceincmarkup")
                    {
                        this.flag_ItemCostPriceIncMarkup = "true";
                        this.cellvalue_ItemCostPriceIncMarkup = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginpercentage")
                    {
                        this.flag_ItemProfitMarginPercentage = "true";
                        this.cellvalue_ItemProfitMarginPercentage = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemprofitmarginvalue")
                    {
                        this.flag_ItemProfitMarginValue = "true";
                        this.cellvalue_ItemProfitMarginValue = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitpercentage")
                    {
                        this.flag_ItemGrossProfitPercentage = "true";
                        this.cellvalue_ItemGrossProfitPercentage = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemgrossprofitvalue")
                    {
                        this.flag_ItemGrossProfitValue = "true";
                        this.cellvalue_ItemGrossProfitValue = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "eventcodenumber")
                    {
                        this.flag_EventCodeNumber = "true";
                        this.cellvalue_EventCodeNumber = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "campaignsignnumber")
                    {
                        this.flag_CampaignSignNumber = "true";
                        this.cellvalue_CampaignSignNumber = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "approved")
                    {
                        this.flag_IsApproved = "true";
                        this.cellvalue_IsApproved = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "approved")
                    {
                        this.flag_EventVenue = "true";
                        this.cellvalue_EventVenue = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "orderedheight")
                    {
                        this.flag_Height = "true";
                        this.cellvalue_Height = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "orderedwidth")
                    {
                        this.flag_Width = "true";
                        this.cellvalue_Width = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemdescription")
                    {
                        this.flag_ItemDescription = "true";
                        this.cellvalue_ItemDescription = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemcolour")
                    {
                        this.flag_ItemColour = "true";
                        this.cellvalue_ItemColour = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemsize")
                    {
                        this.flag_ItemSize = "true";
                        this.cellvalue_ItemSize = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemartwork")
                    {
                        this.flag_ItemArtwork = "true";
                        this.cellvalue_ItemArtwork = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemdelivery")
                    {
                        this.flag_ItemDelivery = "true";
                        this.cellvalue_ItemDelivery = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemfinishing")
                    {
                        this.flag_ItemFinishing = "true";
                        this.cellvalue_ItemFinishing = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemproofs")
                    {
                        this.flag_ItemProofs = "true";
                        this.cellvalue_ItemProofs = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itempacking")
                    {
                        this.flag_ItemPacking = "true";
                        this.cellvalue_ItemPacking = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "itemnotes")
                    {
                        this.flag_ItemNotes = "true";
                        this.cellvalue_ItemNotes = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "Itemterms_instructions")
                    {
                        this.flag_ItemTermsInstructions = "true";
                        this.cellvalue_ItemTermsInstructions = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "jobname")
                    {
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "orderedby")
                    {
                        this.flag_OrderBy = "true";
                        this.cellvalue_OrderBy = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "department")
                    {
                        this.flag_Department = "true";
                        this.cellvalue_Department = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "companyemail")
                    {
                        this.flag_CompamyEmail = "true";
                        this.cellvalue_CompamyEmail = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "contactemail")
                    {
                        this.flag_ContactEmail = "true";
                        this.cellvalue_ContactEmail = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "contactphone")
                    {
                        this.flag_ContactPhone = "true";
                        this.cellvalue_ContactPhone = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "customerordernumber")
                    {
                        this.flag_CustomerOrderNumber = "true";
                        this.cellvalue_CustomerOrderNumber = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "paymenttype")
                    {
                        this.flag_PaymentType = "true";
                        this.cellvalue_PaymentType = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                    else if (this.grvOrderSearch.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_DeliveryDate = "true";
                        this.cellvalue_DeliveryDate = this.grvOrderSearch.Columns[i].SortExpression.ToLower();
                    }
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string str = string.Concat("orders/order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text);
                if (this.IsItemSelected)
                {
                    str = string.Concat(str, "&EstItemID=", item["EstimateItemID"].Text);
                }
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_attach");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plhConvertJob");
                PlaceHolder placeHolder2 = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string languageConversion = string.Empty;
                empty2 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                empty = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                str1 = string.Concat(this.strImagepath, "liner_j_icon.png");
                if (item["EstItemCoun"].Text == "0")
                {
                    placeHolder.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                else
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", empty, "' title='", empty1, "' style='cursor:pointer;'/>" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controlCollections = placeHolder2.Controls;
                    string[] strArrays1 = new string[] { "<img src='", empty2, "'  title='", languageConversion, "' />" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                if (item["IsDeletedJob"].Text != "0")
                {
                    ControlCollection controls1 = placeHolder1.Controls;
                    string[] text = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&jID=", item["JOBID"].Text, "&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "><img src='", this.strImagepath, "1t.gif' border='0' /></a>" };
                    controls1.Add(new LiteralControl(string.Concat(text)));
                }
                else if (!(item["IsCompletlyConvertedToJob"].Text == "1") || !(item["IsArchived"].Text == "0"))
                {
                    ControlCollection controlCollections1 = placeHolder1.Controls;
                    string[] text1 = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&&jID=", item["JOBID"].Text, "ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "><img src='", this.strImagepath, "1t.gif' border='0' /></a>" };
                    controlCollections1.Add(new LiteralControl(string.Concat(text1)));
                }
                else
                {
                    ControlCollection controls2 = placeHolder1.Controls;
                    string[] text2 = new string[] { "<a href=", this.strSitepath, "jobs/job_order_summary.aspx?frm=view&jID=", item["JOBID"].Text, "&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "><img src='", str1, "' Title='Job Raised' /></a>" };
                    controls2.Add(new LiteralControl(string.Concat(text2)));
                }
                if (!this.IsItemSelected)
                {
                    TableCell tableCell = item["ordernumber"];
                    string[] str2 = new string[] { "<a href=", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, ">", item["ordernumber"].Text, "</a>" };
                    tableCell.Text = string.Concat(str2);
                }
                else
                {
                    TableCell item1 = item["ordernumber"];
                    string[] strArrays2 = new string[] { "<a href=", this.strSitepath, "orders/order_summary.aspx?frm=view&ordid=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&estid=", item["estimateid"].Text, "&EstItemID=", item["EstimateItemID"].Text, ">", item["ordernumber"].Text, "</a>" };
                    item1.Text = string.Concat(strArrays2);
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
                if (this.flag_estvalExcGst == "true")
                {
                    item[this.cellvalue_estvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_estvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estvalExcGst].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_estvalExcGst].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_estvalExcGst].Text), 0, "", false, false, true);
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
                    string[] text3 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_validfor].Text, "</div>" };
                    tableCell1.Text = string.Concat(text3);
                }
                if (this.flag_status == "true")
                {
                    item[this.cellvalue_status].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_status].Style.Add("cursor", "pointer");
                    TableCell item2 = item[this.cellvalue_status];
                    string[] strArrays3 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_status].Text, "</div>" };
                    item2.Text = string.Concat(strArrays3);
                }
                if (this.flag_AccountStatus == "true")
                {
                    item[this.cellvalue_AccountStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_AccountStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_AccountStatus];
                    string[] text4 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_AccountStatus].Text, "</div>" };
                    tableCell2.Text = string.Concat(text4);
                }
                if (this.flag_order == "true")
                {
                    item[this.cellvalue_order].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_order].Style.Add("cursor", "pointer");
                    TableCell item3 = item[this.cellvalue_order];
                    string[] strArrays4 = new string[] { "<div style='width: ", this.type2, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_order].Text, "</div>" };
                    item3.Text = string.Concat(strArrays4);
                }
                if (this.flag_greeting == "true")
                {
                    item[this.cellvalue_greeting].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_greeting].Style.Add("cursor", "pointer");
                    TableCell tableCell3 = item[this.cellvalue_greeting];
                    string[] text5 = new string[] { "<div style='width: ", this.type3, ";min-width: ", this.type3, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_greeting].Text, "</div>" };
                    tableCell3.Text = string.Concat(text5);
                }
                if (this.flag_estimator == "true")
                {
                    item[this.cellvalue_estval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estimator].Style.Add("cursor", "pointer");
                    TableCell item4 = item[this.cellvalue_estimator];
                    string[] strArrays5 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_estimator].Text, "</div>" };
                    item4.Text = string.Concat(strArrays5);
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
                    string[] text6 = new string[] { "<div style='min-width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_sales].Text, "</div>" };
                    tableCell4.Text = string.Concat(text6);
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
                    string[] strArrays6 = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_Header].Text, "</div>" };
                    item5.Text = string.Concat(strArrays6);
                }
                if (this.flag_footer == "true")
                {
                    item[this.cellvalue_footer].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_footer].Style.Add("cursor", "pointer");
                    TableCell tableCell5 = item[this.cellvalue_footer];
                    string[] text7 = new string[] { "<div style='min-width: ", this.type5, ";width: ", this.type6, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_footer].Text, "</div>" };
                    tableCell5.Text = string.Concat(text7);
                }
                if (this.flag_estTitle == "true")
                {
                    item[this.cellvalue_estTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_estTitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_referredby == "true")
                {
                    item[this.cellvalue_referredby].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_referredby].Style.Add("cursor", "pointer");
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_costcentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_costcentre].Style.Add("cursor", "pointer");
                }
                if (this.flag_quantity1 == "true")
                {
                    item[this.cellvalue_quantity1].Attributes.Add("align", "right");
                    TableCell item6 = item[this.cellvalue_quantity1];
                    string[] strArrays7 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity1].Text, "</div>" };
                    item6.Text = string.Concat(strArrays7);
                }
                if (this.flag_quantity2 == "true")
                {
                    item[this.cellvalue_quantity2].Attributes.Add("align", "right");
                    TableCell tableCell6 = item[this.cellvalue_quantity2];
                    string[] text8 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity2].Text, "</div>" };
                    tableCell6.Text = string.Concat(text8);
                }
                if (this.flag_quantity3 == "true")
                {
                    item[this.cellvalue_quantity3].Attributes.Add("align", "right");
                    TableCell item7 = item[this.cellvalue_quantity3];
                    string[] strArrays8 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity3].Text, "</div>" };
                    item7.Text = string.Concat(strArrays8);
                }
                if (this.flag_quantity4 == "true")
                {
                    item[this.cellvalue_quantity4].Attributes.Add("align", "right");
                    TableCell tableCell7 = item[this.cellvalue_quantity4];
                    string[] text9 = new string[] { "<div style='width: ", this.type1, ";max-height: 15px;height:15px;'>", item[this.cellvalue_quantity4].Text, "</div>" };
                    tableCell7.Text = string.Concat(text9);
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    TableCell item8 = item[this.cellvalue_ItemStatus];
                    string[] strArrays9 = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    item8.Text = string.Concat(strArrays9);
                }
                if (this.flag_ItemTitle == "true")
                {
                    item[this.cellvalue_ItemTitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemTitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemAccCode == "true")
                {
                    item[this.cellvalue_ItemAccCode].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemAccCode].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemAccCode].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemQTY == "true")
                {
                    item[this.cellvalue_ItemQTY].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemQTY].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemQTY].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemValue_ExcTax == "true")
                {
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_ExcTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemValue_ExcTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_ExcTax].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_ExcTax].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemValue_IncTax == "true")
                {
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemValue_IncTax].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemValue_IncTax].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemValue_IncTax].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemValue_IncTax].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemTaxValue == "true")
                {
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemTaxValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemTaxValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemTaxValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemTaxValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceExcMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceExcMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemCostPriceExcMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceExcMarkup].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceExcMarkup].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemMarkupValue == "true")
                {
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemMarkupValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemMarkupValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemMarkupValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemMarkupValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemCostPriceIncMarkup == "true")
                {
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemCostPriceIncMarkup].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemCostPriceIncMarkup].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemCostPriceIncMarkup].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemCostPriceIncMarkup].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginPercentage == "true")
                {
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemProfitMarginPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginPercentage].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginPercentage].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemProfitMarginValue == "true")
                {
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemProfitMarginValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemProfitMarginValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemProfitMarginValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemProfitMarginValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitPercentage == "true")
                {
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitPercentage].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemGrossProfitPercentage].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitPercentage].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitPercentage].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_ItemGrossProfitValue == "true")
                {
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("align", "right");
                    item[this.cellvalue_ItemGrossProfitValue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemGrossProfitValue].Style.Add("cursor", "pointer");
                    try
                    {
                        item[this.cellvalue_ItemGrossProfitValue].Text = this.objJava.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_ItemGrossProfitValue].Text), 0, "", false, false, true);
                    }
                    catch
                    {
                    }
                }
                if (this.flag_EventName == "true")
                {
                    item[this.cellvalue_EventName].Attributes.Add("align", "left");
                    item[this.cellvalue_EventName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_EventName].Style.Add("cursor", "pointer");
                }
                if (this.flag_EventCodeNumber == "true")
                {
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("align", "left");
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_EventCodeNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_CampaignSignNumber == "true")
                {
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("align", "right");
                    item[this.cellvalue_CampaignSignNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CampaignSignNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_IsApproved == "true")
                {
                    item[this.cellvalue_IsApproved].Attributes.Add("align", "center");
                    item[this.cellvalue_IsApproved].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    if (item[this.cellvalue_IsApproved].Text == "Approved")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Green;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Awaiting Approval")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Orange;
                    }
                    if (item[this.cellvalue_IsApproved].Text == "Rejected")
                    {
                        item[this.cellvalue_IsApproved].ForeColor = Color.Red;
                    }
                    item[this.cellvalue_IsApproved].Style.Add("cursor", "pointer");
                }
                if (this.flag_EventVenue == "true")
                {
                    item[this.cellvalue_EventVenue].Attributes.Add("align", "left");
                    item[this.cellvalue_EventVenue].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_EventVenue].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemMaterial == "true")
                {
                    item[this.cellvalue_ItemMaterial].Attributes.Add("align", "left");
                    item[this.cellvalue_ItemMaterial].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ItemMaterial].Style.Add("cursor", "pointer");
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
                if (this.flag_JobName == "true")
                {
                    item[this.cellvalue_JobName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_JobName].Style.Add("cursor", "pointer");
                }
                if (this.flag_OrderBy == "true")
                {
                    item[this.cellvalue_OrderBy].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_OrderBy].Style.Add("cursor", "pointer");
                }
                if (this.flag_Department == "true")
                {
                    item[this.cellvalue_Department].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_Department].Style.Add("cursor", "pointer");
                }
                if (this.flag_CompamyEmail == "true")
                {
                    item[this.cellvalue_CompamyEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CompamyEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactEmail == "true")
                {
                    item[this.cellvalue_ContactEmail].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ContactEmail].Style.Add("cursor", "pointer");
                }
                if (this.flag_ContactPhone == "true")
                {
                    item[this.cellvalue_ContactPhone].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_ContactPhone].Style.Add("cursor", "pointer");
                }
                if (this.flag_CustomerOrderNumber == "true")
                {
                    item[this.cellvalue_CustomerOrderNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_CustomerOrderNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_PaymentType == "true")
                {
                    item[this.cellvalue_PaymentType].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_PaymentType].Style.Add("cursor", "pointer");
                }
                if (this.flag_DeliveryDate == "true")
                {
                    item[this.cellvalue_DeliveryDate].Attributes.Add("align", "center");
                    item[this.cellvalue_DeliveryDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", str, "');"));
                    item[this.cellvalue_DeliveryDate].Style.Add("cursor", "pointer");
                }
            }
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem gridFilteringItem = (GridFilteringItem)e.Item;
                if (this.flag_estval == "true")
                {
                    gridFilteringItem[this.cellvalue_estval].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_estvalExcGst == "true")
                {
                    gridFilteringItem[this.cellvalue_estvalExcGst].HorizontalAlign = HorizontalAlign.Right;
                }
                if (this.flag_createddate == "true")
                {
                    gridFilteringItem[this.cellvalue_createddate].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_estdate == "true")
                {
                    gridFilteringItem[this.cellvalue_estdate].HorizontalAlign = HorizontalAlign.Center;
                }
                if (this.flag_validfor == "true")
                {
                    gridFilteringItem[this.cellvalue_validfor].HorizontalAlign = HorizontalAlign.Right;
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.grvOrderSearch.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            global.pageName = "webstoreorder";
            this.gloobj.setpagename("webstoreorder");
            this.strImagepath = global.imagePath();
            this.strSitepath = global.sitePath();
            this.pg = "webstoreorder";
            this.pgsearch = "estoresearch";
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            this.Page.Title = this.objLanguage.convert(global.pageTitle("eStore View", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            BaseClass baseClass = this.objBase;
            DateTime now = DateTime.Now;
            DateTime dateTime = Convert.ToDateTime(baseClass.ApplyTimeZone(now.ToString()));
            this.newdate = dateTime.ToShortDateString();
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "webstoreorder_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["OrdViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["OrdViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.grvOrderSearch.PageSize = 50;
                if (base.Request.QueryString["viewid"] != null)
                {
                    this.defaultviewid = Convert.ToInt32(base.Request.Params["viewid"].ToString());
                    string str1 = string.Concat(this.pgsearch, this.UserID, this.pgsearch);
                    base.Session["search_ord"] = null;
                    base.Session[str1] = null;
                }
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "webstoreorder");
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
                    this.SortedBy = "OrderNumber";
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
                        this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, 1, this.defaultviewid, "customerid", "desc", empty, this.ViewState["WhereCondition"].ToString());
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
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str4, "%' OR Department LIKE '%", str4, "%' OR greeting LIKE '%", str4, "%' OR salesperson LIKE '%", str4, "%' OR ordertitle LIKE '%", str4, "%' OR OrderNumber LIKE '%", str4, "%' OR Comments LIKE '%", str4, "%' OR StatusID LIKE '%", str4, "%')" };
                    str3 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str3;
                }
                this.GridStateLoad();
                if (base.Session["search_ord"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_ord"];
                    str2 = "";
                }
                this.PageSize = this.objJava.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.grvOrderSearch);
                this.grvOrderSearch.PageSize = this.PageSize;
                base.Session["OrdViewID"] = this.defaultviewid;
                this.GridBind(this.CompanyID, this.UserID, this.grvOrderSearch.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str2, str3);
                this.GridStateLoad();
                this.grvOrderSearch.Rebind();
                if (this.Mode.ToLower() != "all")
                {
                    this.divContentOrder.Style.Value = "display:block";
                }
                else
                {
                    this.divContentOrder.Style.Value = "display:none";
                }
            }
            this.grvOrderSearch.MasterTableView.GetColumn("orderid").Visible = false;
            if (this.grvOrderSearch.MasterTableView.GetColumn("estimateitemid") != null)
            {
                this.grvOrderSearch.MasterTableView.GetColumn("estimateitemid").Visible = false;
            }
            this.grvOrderSearch.MasterTableView.GetColumn("JOBID").Visible = false;
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

        public event GetOrderRecordCount getOrderRecCount;
    }
}