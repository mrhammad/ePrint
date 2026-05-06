using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using nmsView;
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

namespace ePrint.usercontrol.INVOICE
{
    public partial class Invoice_Search : System.Web.UI.UserControl
    {
        private int invoicereccount;

        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        public languageClass objLanguage = new languageClass();

        private commonClass objJava = new commonClass();

        private EstimateBasePage ObjEst = new EstimateBasePage();

        private commonClass comm = new commonClass();

        public string tabcolor = string.Empty;

        public string forecolor = string.Empty;

        public string strImagepath = global.imagePath();

        public string strSitepath = global.sitePath();

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

        public string cellvalue_deliverydate = string.Empty;

        public string flag_deliverydate = string.Empty;

        public string cellvalue_createddate = string.Empty;

        public string flag_createddate = string.Empty;

        public string cellvalue_completiondate = string.Empty;

        public string flag_completiondate = string.Empty;

        public string cellvalue_ispaid = string.Empty;

        public string flag_ispaid = string.Empty;

        public string cellvalue_Invval = string.Empty;

        public string flag_Invval = string.Empty;

        public string cellvalue_InvoiceAmountPaid = string.Empty;

        public string flag_InvoiceAmountPaid = string.Empty;

        public string cellvalue_InvoiceOutstanding = string.Empty;

        public string flag_InvoiceOutstanding = string.Empty;

        public string cellvalue_AccountStatus = string.Empty;

        public string flag_AccountStatus = string.Empty;

        public string cellvalue_InvvalExcGst = string.Empty;

        public string flag_InvvalExcGst = string.Empty;

        public string cellvalue_Quantity = string.Empty;

        public string flag_Quantity = string.Empty;

        public string cellvalue_customername = string.Empty;

        public string flag_customername = string.Empty;

        public string cellvalue_invoicetitle = string.Empty;

        public string flag_invoicetitle = string.Empty;

        public string cellvalue_paymentterms = string.Empty;

        public string flag_paymentterms = string.Empty;

        public string cellvalue_customeraccountnumber = string.Empty;

        public string flag_customeraccountnumber = string.Empty;

        public string cellvalue_status = string.Empty;

        public string flag_status = string.Empty;

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

        public string cellvalue_invoicetype = string.Empty;

        public string flag_invoicetype = string.Empty;

        public string cellvalue_EstimateNumber = string.Empty;

        public string flag_EstimateNumber = string.Empty;

        public string cellvalue_JobNumber = string.Empty;

        public string flag_JobNumber = string.Empty;

        public string cellvalue_InvoiceDueDate = string.Empty;

        public string flag_InvoiceDueDate = string.Empty;

        public int UserID;

        public string WhereCondition = string.Empty;

        public string sortdirection = string.Empty;

        public string SortedBy = string.Empty;

        public int PageSize;

        public string DateFormat = string.Empty;

        private DataTable dtsearch = new DataTable();

        private DataTable dtArtwork = new DataTable();

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

        public string type1 = "40px";

        public string type2 = "70px";

        public string type3 = "90px";

        public string type4 = "100px";

        public string type5 = "110px";

        public string type6 = "200px";

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

        public Invoice_Search()
        {
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
                    if (dt.Columns[i].ColumnName.ToLower() == "createddate" || dt.Columns[i].ColumnName.ToLower() == "completiondate" || dt.Columns[i].ColumnName.ToLower() == "deliverydate")
                    {
                        gridBoundColumn.DataType = Type.GetType("System.DateTime");
                    }
                }
                for (int j = 1; j < this.GridViewInvoice.Columns.Count; j++)
                {
                    this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    this.GridViewInvoice.Columns[j].HeaderStyle.Wrap = false;
                    if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoicenumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_No");
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "customertype")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Customer_Type");
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
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "status")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Status");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_status = "true";
                        this.cellvalue_status = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "accountstatus")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Account_Status");
                        this.GridViewInvoice.Columns[j].ItemStyle.Wrap = false;
                        this.flag_AccountStatus = "true";
                        this.cellvalue_AccountStatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "ispaid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Paid");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                        this.cellvalue_ispaid = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_ispaid = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "deliverydate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_deliverydate = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_deliverydate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "completiondate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Completed_On");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_completiondate = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_completiondate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "createddate")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Created");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        this.cellvalue_createddate = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoicevalue")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Inv_Value"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_Invval = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_Invval = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoiceamountpaid")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Amount_Paid"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_InvoiceAmountPaid = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_InvoiceAmountPaid = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "invoiceoutstanding")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Amount_Outstanding"), "(", this.objJava.GetCurrencyinRequiredFormate("", true), ")");
                        this.GridViewInvoice.Columns[j].HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
                        this.cellvalue_InvoiceOutstanding = this.GridViewInvoice.Columns[j].SortExpression;
                        this.flag_InvoiceOutstanding = "true";
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "quantity")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Quantity");
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
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "isaccountonhold")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "orderid")
                    {
                        this.GridViewInvoice.Columns[j].Visible = false;
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "isaccountonhold")
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
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "paymentterms")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Payment_Terms");
                        this.flag_paymentterms = "true";
                        this.cellvalue_paymentterms = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "costcentre")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Cost_centre");
                        this.flag_costcentre = "true";
                        this.cellvalue_costcentre = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatetype")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Type");
                        this.flag_invoicetype = "true";
                        this.cellvalue_invoicetype = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "estimatenumber")
                    {
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Estimate_Number");
                        this.flag_EstimateNumber = "true";
                        this.cellvalue_EstimateNumber = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "jobnumber")
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
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemstatus")
                    {
                        this.flag_ItemStatus = "true";
                        this.cellvalue_ItemStatus = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Status");
                    }
                    else if (this.GridViewInvoice.Columns[j].SortExpression.ToLower() == "itemtitle")
                    {
                        this.flag_ItemTitle = "true";
                        this.cellvalue_ItemTitle = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title_View");
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
                        this.flag_JobName = "true";
                        this.cellvalue_JobName = this.GridViewInvoice.Columns[j].SortExpression.ToLower();
                        this.GridViewInvoice.Columns[j].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
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
                base.Response.Redirect(string.Concat(this.strSitepath, "invoice/invoice_search.aspx?para=", this.para));
            }
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
            //sqlCommand.CommandTimeout = 300;
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
                    if (row.Table.Columns.Contains("CompletionDate"))
                    {
                        row["CompletionDate"] = this.objJava.Eprint_return_Date_Before_View(row["CompletionDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CreatedDate"))
                    {
                        row["CreatedDate"] = this.objJava.Eprint_return_Date_Before_View(row["CreatedDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("DeliveryDate"))
                    {
                        row["DeliveryDate"] = this.objJava.Eprint_return_Date_Before_View(row["DeliveryDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("SalesPerson"))
                    {
                        row["SalesPerson"] = this.objBase.SpecialDecode(row["SalesPerson"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerID"))
                    {
                        row["CustomerID"] = this.objBase.SpecialDecode(row["CustomerID"].ToString());
                    }
                    if (row.Table.Columns.Contains("InvoiceNumber"))
                    {
                        row["InvoiceNumber"] = this.objBase.SpecialDecode(row["InvoiceNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("ReferredBY"))
                    {
                        row["ReferredBY"] = this.objBase.SpecialDecode(row["ReferredBY"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerAccountNumber"))
                    {
                        row["CustomerAccountNumber"] = this.objBase.SpecialDecode(row["CustomerAccountNumber"].ToString());
                    }
                    if (row.Table.Columns.Contains("AttentionID"))
                    {
                        row["AttentionID"] = this.objBase.SpecialDecode(row["AttentionID"].ToString());
                    }
                    if (row.Table.Columns.Contains("EstimateTitle"))
                    {
                        row["EstimateTitle"] = this.objBase.SpecialDecode(row["EstimateTitle"].ToString());
                    }
                    if (row.Table.Columns.Contains("Status"))
                    {
                        row["Status"] = this.objBase.SpecialDecode(row["Status"].ToString());
                    }
                    if (row.Table.Columns.Contains("PaymentTerms"))
                    {
                        row["PaymentTerms"] = this.objBase.SpecialDecode(row["PaymentTerms"].ToString());
                    }
                    if (row.Table.Columns.Contains("CostCentre"))
                    {
                        row["CostCentre"] = this.objBase.SpecialDecode(row["CostCentre"].ToString());
                    }
                    if (row.Table.Columns.Contains("CustomerOrderNumber"))
                    {
                        row["CustomerOrderNumber"] = this.objBase.SpecialDecode(row["CustomerOrderNumber"].ToString());
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
                    if (row.Table.Columns.Contains("InvoiceDueDate"))
                    {
                        row["InvoiceDueDate"] = this.objJava.Eprint_return_Date_Before_View(row["InvoiceDueDate"].ToString(), CompanyID, UserID, false);
                    }
                    if (row.Table.Columns.Contains("CompanyEmail"))
                    {
                        row["CompanyEmail"] = this.objBase.SpecialDecode(row["CompanyEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("ContactEmail"))
                    {
                        row["ContactEmail"] = this.objBase.SpecialDecode(row["ContactEmail"].ToString());
                    }
                    if (row.Table.Columns.Contains("paymentnotes"))
                    {
                        row["paymentnotes"] = this.objBase.SpecialDecode(row["paymentnotes"].ToString());
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
                this.invoicereccount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0].ToString());
                if (this.getInvoiceRecordCount != null)
                {
                    this.getInvoiceRecordCount(this.invoicereccount);
                    return;
                }
            }
        }

        private void GridStateLoad()
        {
            this.objJava.GridStateLoadNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewInvoice, "yes");
        }

        private void GridStateSave()
        {
            this.objJava.GridStateSaveNew(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewInvoice);
        }

        protected void GridViewInvoice_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
        }

        protected void GridViewInvoice_ItemCommand(object sender, GridCommandEventArgs e)
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
                if (commandArgument.First.ToString().ToLower() != "nofilter" && (commandArgument.Second.ToString().ToLower() == "invoicevalue" || commandArgument.Second.ToString().ToLower() == "quantity"))
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
                if (base.Session["search_Inv"] == null)
                {
                    this.dtsearch.Columns.Add("ColumnName");
                    this.dtsearch.Columns.Add("Filter");
                    this.dtsearch.Columns.Add("FilterText");
                }
                if (base.Session["search_Inv"] != null)
                {
                    this.dtsearch = (DataTable)base.Session["search_Inv"];
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
                base.Session["search_Inv"] = this.dtsearch;
                this.WhereCondition = "";
                this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
                this.GridViewInvoice.Rebind();
            }
        }

        protected void GridViewInvoice_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridPagerItem)
            {
                RadComboBox radComboBox = (e.Item as GridPagerItem).FindControl("PageSizeComboBox") as RadComboBox;
                RadComboBoxItem radComboBoxItem = new RadComboBoxItem("5", "5");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInvoice.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("5") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("10", "10");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInvoice.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("10") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("20", "20");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInvoice.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("20") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                radComboBoxItem = new RadComboBoxItem("50", "50");
                radComboBoxItem.Attributes.Add("ownerTableViewId", this.GridViewInvoice.MasterTableView.ClientID);
                if (radComboBox.Items.FindItemByValue("50") == null)
                {
                    radComboBox.Items.Add(radComboBoxItem);
                }
                //radComboBox.Items.Sort(new PageSizeItemsComparer()); Temporarily commented by KR [21 March 2017]
                RadComboBoxItemCollection items = radComboBox.Items;
                int pageSize = this.GridViewInvoice.PageSize;
                items.FindItemByValue(pageSize.ToString()).Selected = true;
            }
        }

        protected void GridViewInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.GridViewInvoice.AllowCustomPaging = true;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, this.GridViewInvoice.CurrentPageIndex + 1, this.defaultviewid, this.SortedBy, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
        }

        protected void GridViewInvoice_SortCommand(object sender, GridSortCommandEventArgs e)
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
            this.GridViewInvoice.CurrentPageIndex = 0;
            this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, this.GridViewInvoice.CurrentPageIndex + 1, this.defaultviewid, e.SortExpression, this.sortdirection, this.WhereCondition, this.ViewState["WhereCondition"].ToString());
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

        protected void OnRowDataBound_GridViewInvoice(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Header)
            {
                e.Item.Visible = false;
                for (int i = 0; i < this.GridViewInvoice.Columns.Count; i++)
                {
                    if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "createddate")
                    {
                        this.cellvalue_createddate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_createddate = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "deliverydate")
                    {
                        this.flag_deliverydate = "true";
                        this.cellvalue_deliverydate = this.GridViewInvoice.Columns[i].SortExpression;
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "completiondate")
                    {
                        this.cellvalue_completiondate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_completiondate = "true";
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
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatevalue_excgst")
                    {
                        this.cellvalue_InvvalExcGst = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvvalExcGst = "true";
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
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "status")
                    {
                        this.cellvalue_status = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_status = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "accountstatus")
                    {
                        this.cellvalue_AccountStatus = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_AccountStatus = "true";
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
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "costcentre")
                    {
                        this.cellvalue_costcentre = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_costcentre = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "salesperson")
                    {
                        this.cellvalue_salesperson = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_salesperson = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "estimatetype")
                    {
                        this.cellvalue_invoicetype = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_invoicetype = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "jobnumber")
                    {
                        this.cellvalue_JobNumber = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_JobNumber = "true";
                    }
                    else if (this.GridViewInvoice.Columns[i].SortExpression.ToLower() == "invoiceduedate")
                    {
                        this.cellvalue_InvoiceDueDate = this.GridViewInvoice.Columns[i].SortExpression;
                        this.flag_InvoiceDueDate = "true";
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
                }
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                e.Item.Visible = false;
                GridDataItem item = (GridDataItem)e.Item;
                string empty = string.Empty;
                PlaceHolder placeHolder = (PlaceHolder)e.Item.FindControl("plh_customerstatus");
                PlaceHolder placeHolder1 = (PlaceHolder)e.Item.FindControl("plh_attach");
                string str = string.Empty;
                string empty1 = string.Empty;
                str = string.Concat(this.strImagepath, "Attachment.PNG");
                empty1 = "Item with an attachment(s)";
                string str1 = string.Empty;
                string languageConversion = string.Empty;
                str1 = string.Concat(this.strImagepath, "AccountOnHold.png");
                languageConversion = this.objLanguage.GetLanguageConversion("Account_On_Hold");
                string empty2 = string.Empty;
                DataRow[] dataRowArray = this.dtArtwork.Select(string.Concat("EstimateID=", ((DataRowView)e.Item.DataItem)[1].ToString()));
                if ((int)dataRowArray.Length > 0)
                {
                    empty2 = dataRowArray[0]["ArtWork"].ToString();
                }
                if (Convert.ToInt16(item["IsAccountOnHold"].Text) == 1)
                {
                    ControlCollection controls = placeHolder.Controls;
                    string[] strArrays = new string[] { "<img src='", str1, "'  title='", languageConversion, "' class='viewicon_margin'  />" };
                    controls.Add(new LiteralControl(string.Concat(strArrays)));
                }
                if (item["EstItemCoun"].Text != "0" || empty2 != "")
                {
                    ControlCollection controlCollections = placeHolder1.Controls;
                    string[] strArrays1 = new string[] { "<img src='", str, "' title='", empty1, "' style='cursor:pointer;'/>" };
                    controlCollections.Add(new LiteralControl(string.Concat(strArrays1)));
                }
                else
                {
                    placeHolder1.Controls.Add(new LiteralControl(string.Concat("<img src='", this.strImagepath, "1t.gif' border='0' />")));
                }
                if (item["isfromwebstore"].Text.Trim().ToLower() != "yes")
                {
                    empty = string.Concat("invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString());
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell = item["invoicenumber"];
                        string[] str2 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell.Text = string.Concat(str2);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item1 = item["invoicenumber"];
                        string[] strArrays2 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_summary_reeng.aspx?estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["invoicenumber"].Text, "</a>" };
                        item1.Text = string.Concat(strArrays2);
                    }
                }
                else
                {
                    string[] str3 = new string[] { "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString() };
                    empty = string.Concat(str3);
                    if (!this.IsItemSelected)
                    {
                        TableCell tableCell1 = item["invoicenumber"];
                        string[] strArrays3 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), ">", item["invoicenumber"].Text, "</a>" };
                        tableCell1.Text = string.Concat(strArrays3);
                    }
                    else
                    {
                        empty = string.Concat(empty, "&EstItemID=", item["EstimateItemID"].Text);
                        TableCell item2 = item["invoicenumber"];
                        string[] str4 = new string[] { "<a style='border:0px solid red;color:#10357F;' href=", this.strSitepath, "invoice/invoice_order_summary.aspx?frm=view&estid=", ((DataRowView)e.Item.DataItem)[1].ToString(), "&ordid=", item["orderid"].Text, "&InvID=", ((DataRowView)e.Item.DataItem)[0].ToString(), "&EstItemID=", item["EstimateItemID"].Text, ">", item["invoicenumber"].Text, "</a>" };
                        item2.Text = string.Concat(str4);
                    }
                }
                if (((DataRowView)e.Item.DataItem).DataView.Table.Columns.Contains("CustomerType") && item["CustomerType"].Text.Trim().Length > 30)
                {
                    item["CustomerType"].ToolTip = item["CustomerType"].Text;
                    item["CustomerType"].Text = string.Concat(item["CustomerType"].Text.Substring(0, 30), "..");
                }
                if (this.flag_createddate == "true")
                {
                    item[this.cellvalue_createddate].Attributes.Add("align", "center");
                    item[this.cellvalue_createddate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_createddate].Style.Add("cursor", "pointer");
                }
                if (this.flag_deliverydate == "true")
                {
                    item[this.cellvalue_deliverydate].Attributes.Add("align", "center");
                    item[this.cellvalue_deliverydate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_deliverydate].Style.Add("cursor", "pointer");
                }
                if (this.flag_completiondate == "true")
                {
                    item[this.cellvalue_completiondate].Attributes.Add("align", "center");
                    item[this.cellvalue_completiondate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_completiondate].Style.Add("cursor", "pointer");
                }
                if (this.flag_Invval == "true")
                {
                    item[this.cellvalue_Invval].Attributes.Add("align", "right");
                    item[this.cellvalue_Invval].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Invval].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Invval].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_Invval].Text), 0, "", false, false, true);
                }
                if (this.flag_InvoiceAmountPaid == "true")
                {
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("align", "right");
                    item[this.cellvalue_InvoiceAmountPaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceAmountPaid].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvoiceAmountPaid].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvoiceAmountPaid].Text), 0, "", false, false, true);
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
                }
                if (this.flag_InvvalExcGst == "true")
                {
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("align", "right");
                    item[this.cellvalue_InvvalExcGst].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvvalExcGst].Style.Add("cursor", "pointer");
                    item[this.cellvalue_InvvalExcGst].Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, this.UserID, Convert.ToDecimal(item[this.cellvalue_InvvalExcGst].Text), 0, "", false, false, true);
                }
                if (this.flag_ispaid == "true")
                {
                    item[this.cellvalue_ispaid].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ispaid].Style.Add("cursor", "pointer");
                }
                if (this.flag_Quantity == "true")
                {
                    item[this.cellvalue_Quantity].Attributes.Add("align", "right");
                    item[this.cellvalue_Quantity].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_Quantity].Style.Add("cursor", "pointer");
                    item[this.cellvalue_Quantity].Text = item[this.cellvalue_Quantity].Text;
                }
                if (this.flag_customername == "true")
                {
                    item[this.cellvalue_customername].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customername].Style.Add("cursor", "pointer");
                }
                if (this.flag_invoicetitle == "true")
                {
                    item[this.cellvalue_invoicetitle].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_invoicetitle].Style.Add("cursor", "pointer");
                }
                if (this.flag_paymentterms == "true")
                {
                    item[this.cellvalue_paymentterms].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_paymentterms].Style.Add("cursor", "pointer");
                }
                if (this.flag_customeraccountnumber == "true")
                {
                    item[this.cellvalue_customeraccountnumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_customeraccountnumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_salesperson == "true")
                {
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
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
                if (this.flag_contactname == "true")
                {
                    item[this.cellvalue_contactname].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_contactname].Style.Add("cursor", "pointer");
                }
                if (this.flag_costcentre == "true")
                {
                    item[this.cellvalue_costcentre].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_costcentre].Style.Add("cursor", "pointer");
                }
                if (this.flag_salesperson == "true")
                {
                    item[this.cellvalue_salesperson].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_salesperson].Style.Add("cursor", "pointer");
                }
                if (this.flag_invoicetype == "true")
                {
                    item[this.cellvalue_invoicetype].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_invoicetype].Style.Add("cursor", "pointer");
                }
                if (this.flag_EstimateNumber == "true")
                {
                    item[this.cellvalue_EstimateNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_EstimateNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_JobNumber == "true")
                {
                    item[this.cellvalue_JobNumber].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobNumber].Style.Add("cursor", "pointer");
                }
                if (this.flag_InvoiceDueDate == "true")
                {
                    item[this.cellvalue_InvoiceDueDate].Attributes.Add("align", "center");
                    item[this.cellvalue_InvoiceDueDate].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_InvoiceDueDate].Style.Add("cursor", "pointer");
                }
                if (this.flag_ItemStatus == "true")
                {
                    item[this.cellvalue_ItemStatus].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_ItemStatus].Style.Add("cursor", "pointer");
                    TableCell tableCell2 = item[this.cellvalue_ItemStatus];
                    string[] text = new string[] { "<div style='width: ", this.type4, ";overflow:hidden;max-height: 15px;height:15px;'>", item[this.cellvalue_ItemStatus].Text, "</div>" };
                    tableCell2.Text = string.Concat(text);
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
                    item[this.cellvalue_EventCodeNumber].Attributes.Add("align", "left");
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
                if (this.flag_JobName == "true")
                {
                    item[this.cellvalue_JobName].Attributes.Add("onclick", string.Concat("javascript:OnRowClick('", empty, "');"));
                    item[this.cellvalue_JobName].Style.Add("cursor", "pointer");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewInvoice.MasterTableView.NoMasterRecordsText = this.objLanguage.GetLanguageConversion("No_records_To_Display");
            global.pageName = "invoice";
            global.pgName = "";
            this.gloobj.setpagename("invoice");
            this.pg = "invoice";
            this.pgsearch = "invoicesearch";
            this.strImagepath = global.imagePath();
            this.CompanyID = Convert.ToInt32(base.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(base.Session["UserID"].ToString());
            this.DateFormat = base.Session["Dateformat"].ToString();
            this.dtArtwork = this.objCreateView.Estimate_Outwork_ArtworkFile_Select(this.CompanyID);
            this.Page.Title = this.objLanguage.convert(global.pageTitle("Invoices Search view", int.Parse(base.Session["companyid"].ToString()), base.Session["companyName"].ToString()));
            commonClass _commonClass = this.comm;
            DateTime now = DateTime.Now;
            this.newdate = _commonClass.Eprint_return_DateTime_Before_View(now.ToString().ToString(), this.CompanyID, this.UserID, true);
            string str = this.objJava.UserSetting_Selete(this.CompanyID, this.UserID, "invoices_view");
            if (str != "" && str != null)
            {
                this.defaultviewid = Convert.ToInt32(str);
            }
            if (base.Session["InvViewID"] != null)
            {
                this.defaultviewid = Convert.ToInt32(base.Session["InvViewID"]);
            }
            if (!base.IsPostBack)
            {
                this.GridViewInvoice.PageSize = 50;
                this.PageSize = 50;
            }
            int num = 0;
            num = (this.ViewID != 0 ? this.ViewID : this.defaultviewid);
            this.dt = this.objCreateView.CustomizeView_Select(num, this.CompanyID, "invoice");
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
                    this.SortedBy = "InvoiceNumber";
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
                        this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, "CustomerID", "desc", empty, this.ViewState["WhereCondition"].ToString());
                    }
                }
            }
            catch
            {
            }
            this.IsItemSelected = EstimatesBasePage.Views_IsItemDetailsSelected((long)this.defaultviewid);
            if (!base.IsPostBack)
            {
                string str1 = "";
                string str2 = "";
                if (base.Request.Params["srch_val"] != null)
                {
                    BaseClass baseClass = this.objBase;
                    string item = base.Request.Params["srch_val"];
                    char[] chrArray = new char[] { '?' };
                    string str3 = baseClass.SpecialEncode(item.Split(chrArray)[0].ToString());
                    string[] strArrays = new string[] { " AND(CustomerID LIKE '%", str3, "%' OR Department LIKE '%", str3, "%' OR Estimator LIKE '%", str3, "%' OR Greeting LIKE '%", str3, "%' OR SalesPerson LIKE '%", str3, "%' OR EstimateTitle LIKE '%", str3, "%' OR InvoiceNumber LIKE '%", str3, "%' OR EstimateNumber LIKE '%", str3, "%' OR JobNumber LIKE '%", str3, "%' OR CustomerOrderNumber LIKE '%", str3, "%' OR CustomerType like   '%", str3, "%' OR ((ContactAddress + ' ' + DeliveryAddress + ' ' + InvoiceAddress + ' ' + Address1 + ' ' + Address2 + ' ' + Address3 + ' ' + Address4 + ' ' + Address5) like '%", str3, "%') OR Status LIKE '%", str3, "%')" };
                    str2 = string.Concat(strArrays);
                    this.ViewState["WhereCondition"] = str2;
                }
                this.GridStateLoad();
                if (base.Session["search_Inv"] != null)
                {
                    DataTable dataTable = (DataTable)base.Session["search_Inv"];
                    str1 = "";
                }
                base.Session["InvViewID"] = this.defaultviewid;
                this.PageSize = this.objJava.ReturnPageSize(this.pgsearch, string.Concat(this.UserID, this.pgsearch), this.GridViewInvoice);
                this.GridViewInvoice.PageSize = this.PageSize;
                this.GridBind(this.CompanyID, this.UserID, this.GridViewInvoice.PageSize, 1, this.defaultviewid, this.SortedBy, this.sortdirection, str1, str2);
                this.GridStateLoad();
                this.GridViewInvoice.Rebind();
            }
            this.GridViewInvoice.MasterTableView.GetColumn("InvoiceID").Visible = false;
            this.GridViewInvoice.MasterTableView.GetColumn("estimateid").Visible = false;
            if (this.GridViewInvoice.MasterTableView.GetColumn("estimateitemid") != null)
            {
                this.GridViewInvoice.MasterTableView.GetColumn("estimateitemid").Visible = false;
            }
        }

        public event GetInvoiceRecCount getInvoiceRecordCount;
    }
}