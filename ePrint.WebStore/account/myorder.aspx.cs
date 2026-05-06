using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.LoginNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;
using Spire.DataExport.XLS;

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Spire.DataExport.Common;

namespace ePrint.WebStore.account
{
    public partial class myorder : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel2;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel3;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel4;

        //protected RadTabStrip RadTabStrip1;

        //protected usercontrol_left_banner2 left_banner2;

        //protected HtmlGenericControl accountInfoContent_left;

        //protected LinkButton lnkOrder;

        //protected LinkButton lnkExport_Excel;

        //protected ImageButton btnExport_Order;

        //protected HtmlGenericControl DivOrder1;

        //protected LinkButton lnkJob;

        //protected LinkButton lnkExport_Excel_Job;

        //protected ImageButton btnExport_Job;

        //protected HtmlGenericControl DivJob;

        //protected LinkButton lnkInvoice;

        //protected LinkButton lnkExport_Excel_Invoice;

        //protected ImageButton btnExport_Invoice;

        //protected HtmlGenericControl DivInvoice;

        //protected LinkButton btnOrderclrFilters;

        //protected ImageButton btnExport_All;

        //protected HtmlGenericControl DivOrder;

        //protected LinkButton lnlAwatingClearFil;

        //protected LinkButton lnk_Export_Awaiting;

        //protected ImageButton btnExport_awaiting;

        //protected HtmlGenericControl DivAwating;

        //protected LinkButton lnkPendingApproval;

        //protected LinkButton lnk_Export_pending;

        //protected ImageButton btnExport_pending;

        //protected HtmlGenericControl DivPending;

        //protected HtmlImage imgSucess;

        //protected Label lblSucess;

        //protected HtmlGenericControl divMsg;

        //protected Label lbl_noOrders;

        //protected RadGrid RadGridOrder;

        //protected RadPageView RadPageView2;

        //protected RadGrid RadGridJob;

        //protected RadPageView RadPageView5;

        //protected RadGrid RadGridInvoice;

        //protected RadPageView RadPageView6;

        //protected RadGrid MyOrdergrid;

        //protected RadPageView RadPageView3;

        //protected RadGrid radPendingOrder;

        //protected RadPageView RadPageView4;

        //protected RadGrid radAwaiting;

        //protected RadPageView RadPageView1;

        //protected RadMultiPage RadMultiPage2;

        //protected HtmlGenericControl order_content_table;

        //protected RadWindow RadWindow1;

        //protected RadWindowManager RadWindowManager3;

        protected FontStyle objFontStyle;

        public BaseClass objBc = new BaseClass();

        public commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

        public commonclass objJava = new commonclass();

        public string strSitepath = string.Empty;

        public string AllProductsDeletedMSG = string.Empty;

        public string ReorderDltdMsg1 = string.Empty;

        public string ReorderDltdMsg2 = string.Empty;

        public string FileExtension = string.Empty;

        public char KeySeparator;

        public long StoreUserID;

        public long orderNo = (long)210;

        public int CompanyID;

        public static long AccountID;

        public static string isMyAccount;

        public string UserType = string.Empty;

        public string StyleSheetPath = string.Empty;

        public string PDFFrom = string.Empty;

        public string StorePDFTo = string.Empty;

        public string ImagePathFromFrontEnd = string.Empty;

        public string ImageFromPath = string.Empty;

        public string ImageToPath = string.Empty;

        private string CartItemID = "0";

        private string TemplateID = string.Empty;

        private string SessionID1 = string.Empty;

        public double CropMarkWidth;

        public double CropMarkHeight;

        public bool isAllowPDFPreviews;

        public bool isPDFPreviewMandatory;

        public bool isAllowWaterMark;

        public string WaterMarkText;

        private string TOPDFName = "";

        private string ConnectionString = string.Empty;

        protected Color color;

        private string _curentstatus = string.Empty;

        public int totalRequiredPages;

        public string _pathforpdf = string.Empty;

        public string WhereCondition = string.Empty;

        public string Email = string.Empty;

        public string approvalType = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public string DateFormat = string.Empty;

        public bool Is_Only_User_Jobs = true;

        public bool Is_Only_User_DepartmentJobs;

        public bool Is_User_All_Jobs;

        public bool Is_only_User_Invoice = true;

        public bool Is_only_user_DepartmentInvoice;

        public bool Is_User_All_Invoice;

        public bool Is_Only_User_Orders = true;

        public bool Is_Only_User_DepartmentOrders;

        public bool Is_User_All_Orders;

        public bool IsHideMISJobVisible;

        public bool IsHideMISInvoiceVisible;

        public string IsCampaignEnabled = string.Empty;

        public decimal TotalExcPrice;

        public decimal TotalIncPrice;

        public string IsEnableHidePrice = string.Empty;

        private string PdfImage = string.Empty;

        private static DataTable Dt_Orders;

        private static DataTable Dt_Jobs;

        private static DataTable Dt_Invoice;

        private static DataTable Dt_AllData;

        private static DataTable Dt_Pending;

        private static DataTable Dt_awaiting;

        public string deptScreenName = string.Empty;

        private string SumofTotalPrice = "0";

        private string SumofFinalPrice = "0";

        public string customDatetitle1 = string.Empty;
        public string customDatetitle2 = string.Empty;
        public string customDatetitle3 = string.Empty;
        public string customDatetitle4 = string.Empty;
        public string customDatetitle5 = string.Empty;

        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static myorder()
        {
            myorder.AccountID = (long)0;
            myorder.isMyAccount = "1";
            myorder.Dt_Orders = new DataTable();
            myorder.Dt_Jobs = new DataTable();
            myorder.Dt_Invoice = new DataTable();
            myorder.Dt_AllData = new DataTable();
            myorder.Dt_Pending = new DataTable();
            myorder.Dt_awaiting = new DataTable();
        }

        public myorder()
        {
        }

        public void btnExportAll_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (this.WhereCondition != "")
            {
                if (this.Session["ApprovalSystem"] == null)
                {
                    dataTable = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                    this.MyOrdergrid.DataSource = dataTable;
                    myorder.Dt_AllData = dataTable;
                }
                else if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    dataTable = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                    dataTable.Columns["RequiredBy"].ReadOnly = false;
                    dataTable.Columns["OrderDate"].ReadOnly = false;
                    this.MyOrdergrid.DataSource = dataTable;
                    myorder.Dt_AllData = dataTable;
                }
                else
                {
                    dataTable = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                    this.MyOrdergrid.DataSource = dataTable;
                    myorder.Dt_AllData = dataTable;
                }
            }
            if (myorder.Dt_AllData.Columns.Contains("OrderID"))
            {
                myorder.Dt_AllData.Columns.Remove("OrderID");
            }
            if (myorder.Dt_AllData.Columns.Contains("OrderKey"))
            {
                myorder.Dt_AllData.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_AllData.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_AllData.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_AllData.Columns.Contains("AccountID"))
            {
                myorder.Dt_AllData.Columns.Remove("AccountID");
            }
            if (myorder.Dt_AllData.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_AllData.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_AllData.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_AllData.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_AllData.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_AllData.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_AllData.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_AllData.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_AllData.Columns.Contains("EstimateID"))
            {
                myorder.Dt_AllData.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_AllData.Columns.Contains("CompanyID"))
            {
                myorder.Dt_AllData.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_AllData.Columns.Contains("ClientID"))
            {
                myorder.Dt_AllData.Columns.Remove("ClientID");
            }
            if (myorder.Dt_AllData.Columns.Contains("PaymentType"))
            {
                myorder.Dt_AllData.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_AllData.Columns.Contains("createdBy"))
            {
                myorder.Dt_AllData.Columns.Remove("createdBy");
            }
            if (myorder.Dt_AllData.Columns.Contains("createdBy"))
            {
                myorder.Dt_AllData.Columns.Remove("createdBy");
            }
            if (myorder.Dt_AllData.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_AllData.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_AllData.Columns.Contains("Tax"))
            {
                myorder.Dt_AllData.Columns.Remove("Tax");
            }
            if (myorder.Dt_AllData.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_AllData.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_AllData.Columns.Contains("modulename"))
            {
                myorder.Dt_AllData.Columns.Remove("modulename");
            }
            if (myorder.Dt_AllData.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_AllData.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_AllData.Columns.Contains("IsFromWebStore"))
            {
                myorder.Dt_AllData.Columns.Remove("IsFromWebStore");
            }
            if (myorder.Dt_AllData.Columns.Contains("IsRejected"))
            {
                myorder.Dt_AllData.Columns.Remove("IsRejected");
            }
            if (myorder.Dt_AllData.Columns.Contains("RejectReason"))
            {
                myorder.Dt_AllData.Columns.Remove("RejectReason");
            }
            if (myorder.Dt_AllData.Columns.Contains("AttentionFor"))
            {
                myorder.Dt_AllData.Columns.Remove("AttentionFor");
            }
            if (myorder.Dt_AllData.Columns.Contains("CartItemID"))
            {
                myorder.Dt_AllData.Columns.Remove("CartItemID");
            }
            if (myorder.Dt_AllData.Columns.Contains("ProductID"))
            {
                myorder.Dt_AllData.Columns.Remove("ProductID");
            }
            if (myorder.Dt_AllData.Columns.Contains("OrderItemID"))
            {
                myorder.Dt_AllData.Columns.Remove("OrderItemID");
            }
            if (myorder.Dt_AllData.Columns.Contains("ItemMaterial"))
            {
                myorder.Dt_AllData.Columns.Remove("ItemMaterial");
            }
            if (myorder.Dt_AllData.Columns.Contains("ActualDeliveryDate"))
            {
                myorder.Dt_AllData.Columns.Remove("ActualDeliveryDate");
            }
            if (myorder.Dt_AllData.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_AllData.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_AllData.Columns[1].ColumnName == "OrderDate")
            {
                myorder.Dt_AllData.Columns[1].ColumnName = "Date Raised";
            }
            if (myorder.Dt_AllData.Columns[2].ColumnName == "RequiredBy")
            {
                myorder.Dt_AllData.Columns[2].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_AllData.Columns[3].ColumnName == "OrderedFor")
            {
                myorder.Dt_AllData.Columns[3].ColumnName = "Raised By/For";
            }
            if (myorder.Dt_AllData.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_AllData.Columns[4].ColumnName = "Title";
            }
            if (myorder.Dt_AllData.Columns[5].ColumnName == "quantity")
            {
                myorder.Dt_AllData.Columns[5].ColumnName = "Qty";
            }
            if (myorder.Dt_AllData.Columns[6].ColumnName == "SignNumber")
            {
                myorder.Dt_AllData.Columns[6].ColumnName = "Sign Number";
            }
            if (myorder.Dt_AllData.Columns[7].ColumnName == "CampaignName")
            {
                myorder.Dt_AllData.Columns[7].ColumnName = "Campaign Name";
            }
            if (myorder.Dt_AllData.Columns[8].ColumnName == "orderStatus")
            {
                myorder.Dt_AllData.Columns[8].ColumnName = "Status";
            }
            if (myorder.Dt_AllData.Columns[9].ColumnName == "Approved")
            {
                myorder.Dt_AllData.Columns[9].ColumnName = "Approved";
            }
            if (myorder.Dt_AllData.Columns[10].ColumnName == "TotalPrice")
            {
                myorder.Dt_AllData.Columns[10].ColumnName = "Price ex Tax";
            }
            if (myorder.Dt_AllData.Columns[11].ColumnName == "FinalPrice")
            {
                myorder.Dt_AllData.Columns[11].ColumnName = "Price in Tax";
            }
            if (this.Session["ApprovalSystem"].ToString() != "on" && myorder.Dt_AllData.Columns.Contains("Approved"))
            {
                myorder.Dt_AllData.Columns.Remove("Approved");
            }
            if (this.IsCampaignEnabled.ToLower() == "false")
            {
                if (myorder.Dt_AllData.Columns.Contains("Sign Number"))
                {
                    myorder.Dt_AllData.Columns.Remove("Sign Number");
                }
                if (myorder.Dt_AllData.Columns.Contains("Campaign Name"))
                {
                    myorder.Dt_AllData.Columns.Remove("Campaign Name");
                }
            }
            DataTable dtAllData = myorder.Dt_AllData;
            //HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dtAllData, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dtAllData, filename);
        }

        public void btnExportawaiting_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "awaiting");
                myorder.Dt_awaiting = dataSet.Tables[0];
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in myorder.Dt_awaiting.Rows)
            {
                if (!myorder.Dt_awaiting.Columns.Contains("OrderItemTitle"))
                {
                    continue;
                }
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString().Replace("<br/>", "\n"));
            }
            if (this.IsEnableHidePrice == "true")
            {
                if (myorder.Dt_awaiting.Columns.Contains("TotalPrice"))
                {
                    myorder.Dt_awaiting.Columns.Remove("TotalPrice");
                }
                if (myorder.Dt_awaiting.Columns.Contains("FinalPrice"))
                {
                    myorder.Dt_awaiting.Columns.Remove("FinalPrice");
                }
            }
            if (myorder.Dt_awaiting.Columns.Contains("OrderID"))
            {
                myorder.Dt_awaiting.Columns.Remove("OrderID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("OrderKey"))
            {
                myorder.Dt_awaiting.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_awaiting.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_awaiting.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("AccountID"))
            {
                myorder.Dt_awaiting.Columns.Remove("AccountID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_awaiting.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_awaiting.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_awaiting.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_awaiting.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_awaiting.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_awaiting.Columns.Contains("EstimateID"))
            {
                myorder.Dt_awaiting.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("CompanyID"))
            {
                myorder.Dt_awaiting.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ClientID"))
            {
                myorder.Dt_awaiting.Columns.Remove("ClientID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("PaymentType"))
            {
                myorder.Dt_awaiting.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_awaiting.Columns.Contains("createdBy"))
            {
                myorder.Dt_awaiting.Columns.Remove("createdBy");
            }
            if (myorder.Dt_awaiting.Columns.Contains("createdBy"))
            {
                myorder.Dt_awaiting.Columns.Remove("createdBy");
            }
            if (myorder.Dt_awaiting.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_awaiting.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_awaiting.Columns.Contains("Tax"))
            {
                myorder.Dt_awaiting.Columns.Remove("Tax");
            }
            if (myorder.Dt_awaiting.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_awaiting.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_awaiting.Columns.Contains("modulename"))
            {
                myorder.Dt_awaiting.Columns.Remove("modulename");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_awaiting.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_awaiting.Columns.Contains("IsFromWebStore"))
            {
                myorder.Dt_awaiting.Columns.Remove("IsFromWebStore");
            }
            if (myorder.Dt_awaiting.Columns.Contains("IsRejected"))
            {
                myorder.Dt_awaiting.Columns.Remove("IsRejected");
            }
            if (myorder.Dt_awaiting.Columns.Contains("RejectReason"))
            {
                myorder.Dt_awaiting.Columns.Remove("RejectReason");
            }
            if (myorder.Dt_awaiting.Columns.Contains("AttentionFor"))
            {
                myorder.Dt_awaiting.Columns.Remove("AttentionFor");
            }
            if (myorder.Dt_awaiting.Columns.Contains("CartItemID"))
            {
                myorder.Dt_awaiting.Columns.Remove("CartItemID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ProductID"))
            {
                myorder.Dt_awaiting.Columns.Remove("ProductID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("OrderItemID"))
            {
                myorder.Dt_awaiting.Columns.Remove("OrderItemID");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ItemMaterial"))
            {
                myorder.Dt_awaiting.Columns.Remove("ItemMaterial");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ActualDeliveryDate"))
            {
                myorder.Dt_awaiting.Columns.Remove("ActualDeliveryDate");
            }
            if (myorder.Dt_awaiting.Columns.Contains("ScheduleType"))
            {
                myorder.Dt_awaiting.Columns.Remove("ScheduleType");
            }
            if (myorder.Dt_awaiting.Columns.Contains("IsApproved"))
            {
                myorder.Dt_awaiting.Columns.Remove("IsApproved");
            }
            if (this.Session["ApprovalSystem"].ToString() != "on" && myorder.Dt_awaiting.Columns.Contains("Approved"))
            {
                myorder.Dt_awaiting.Columns.Remove("Approved");
            }
            if (this.IsCampaignEnabled.ToLower() == "false")
            {
                if (myorder.Dt_awaiting.Columns.Contains("SignNumber"))
                {
                    myorder.Dt_awaiting.Columns.Remove("SignNumber");
                }
                if (myorder.Dt_awaiting.Columns.Contains("CampaignName"))
                {
                    myorder.Dt_awaiting.Columns.Remove("CampaignName");
                }
            }
            if (myorder.Dt_awaiting.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_awaiting.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_awaiting.Columns[1].ColumnName.ToLower() == "department")
            {
                if (this.deptScreenName != "")
                {
                    myorder.Dt_awaiting.Columns[1].ColumnName = this.deptScreenName;
                }
                else
                {
                    myorder.Dt_awaiting.Columns[1].ColumnName = this.objLanguage.GetLanguageConversion("Department_To");
                }
            }
            if (myorder.Dt_awaiting.Columns[2].ColumnName == "OrderDate")
            {
                myorder.Dt_awaiting.Columns[2].ColumnName = "Date Raised";
            }
            if (myorder.Dt_awaiting.Columns[3].ColumnName == "RequiredBy")
            {
                myorder.Dt_awaiting.Columns[3].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_awaiting.Columns[4].ColumnName == "OrderedFor")
            {
                myorder.Dt_awaiting.Columns[4].ColumnName = "Raised By/For";
            }
            if (myorder.Dt_awaiting.Columns[5].ColumnName == "OrderTitle")
            {
                myorder.Dt_awaiting.Columns[5].ColumnName = "Order Title";
            }
            if (myorder.Dt_awaiting.Columns[6].ColumnName == "OrderItemTitle")
            {
                myorder.Dt_awaiting.Columns[6].ColumnName = "Item Title";
            }
            if (myorder.Dt_awaiting.Columns[7].ColumnName == "quantity")
            {
                myorder.Dt_awaiting.Columns[7].ColumnName = "Qty";
            }
            if (this.IsCampaignEnabled.ToLower() != "true")
            {
                if (myorder.Dt_awaiting.Columns[8].ColumnName == "orderStatus")
                {
                    myorder.Dt_awaiting.Columns[8].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (myorder.Dt_awaiting.Columns[9].ColumnName == "Approved")
                    {
                        myorder.Dt_awaiting.Columns[9].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (myorder.Dt_awaiting.Columns[10].ColumnName == "TotalPrice")
                        {
                            myorder.Dt_awaiting.Columns[10].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (myorder.Dt_awaiting.Columns[11].ColumnName == "FinalPrice")
                        {
                            myorder.Dt_awaiting.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                else if (this.IsEnableHidePrice == "false")
                {
                    if (myorder.Dt_awaiting.Columns[9].ColumnName == "TotalPrice")
                    {
                        myorder.Dt_awaiting.Columns[9].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (myorder.Dt_awaiting.Columns[10].ColumnName == "FinalPrice")
                    {
                        myorder.Dt_awaiting.Columns[10].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }
            }
            else
            {
                if (myorder.Dt_awaiting.Columns[8].ColumnName == "SignNumber")
                {
                    myorder.Dt_awaiting.Columns[8].ColumnName = "Sign No.";
                }
                if (myorder.Dt_awaiting.Columns[9].ColumnName == "CampaignName")
                {
                    myorder.Dt_awaiting.Columns[9].ColumnName = "Campaign Name";
                }
                if (myorder.Dt_awaiting.Columns[10].ColumnName == "orderStatus")
                {
                    myorder.Dt_awaiting.Columns[10].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (myorder.Dt_awaiting.Columns[11].ColumnName == "Approved")
                    {
                        myorder.Dt_awaiting.Columns[11].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (myorder.Dt_awaiting.Columns[12].ColumnName == "TotalPrice")
                        {
                            myorder.Dt_awaiting.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (myorder.Dt_awaiting.Columns[13].ColumnName == "FinalPrice")
                        {
                            myorder.Dt_awaiting.Columns[13].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                else if (this.IsEnableHidePrice == "false")
                {
                    if (myorder.Dt_awaiting.Columns[11].ColumnName == "TotalPrice")
                    {
                        myorder.Dt_awaiting.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (myorder.Dt_awaiting.Columns[12].ColumnName == "FinalPrice")
                    {
                        myorder.Dt_awaiting.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }
            }
            DataTable dtAwaiting = myorder.Dt_awaiting;
            //HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dtAwaiting, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");

            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dtAwaiting, filename);

        }

        public void btnExportInvoice_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (this.WhereCondition != "")
            {
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "invoice", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
                myorder.Dt_Invoice = dataSet.Tables[0];
                dataTable.Columns["RequiredBy"].ReadOnly = false;
                dataTable.Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in myorder.Dt_Invoice.Rows)
            {
                if (!myorder.Dt_Invoice.Columns.Contains("OrderItemTitle"))
                {
                    continue;
                }
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString().Replace("<br/>", "\n"));
            }
            if (this.IsEnableHidePrice == "true")
            {
                if (myorder.Dt_Invoice.Columns.Contains("TotalPrice"))
                {
                    myorder.Dt_Invoice.Columns.Remove("TotalPrice");
                }
                if (myorder.Dt_Invoice.Columns.Contains("FinalPrice"))
                {
                    myorder.Dt_Invoice.Columns.Remove("FinalPrice");
                }
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderID"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderKey"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_Invoice.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_Invoice.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("AccountID"))
            {
                myorder.Dt_Invoice.Columns.Remove("AccountID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_Invoice.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_Invoice.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_Invoice.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_Invoice.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_Invoice.Columns.Contains("EstimateID"))
            {
                myorder.Dt_Invoice.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("CompanyID"))
            {
                myorder.Dt_Invoice.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ClientID"))
            {
                myorder.Dt_Invoice.Columns.Remove("ClientID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("PaymentType"))
            {
                myorder.Dt_Invoice.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_Invoice.Columns.Contains("createdBy"))
            {
                myorder.Dt_Invoice.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Invoice.Columns.Contains("createdBy"))
            {
                myorder.Dt_Invoice.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_Invoice.Columns.Contains("Tax"))
            {
                myorder.Dt_Invoice.Columns.Remove("Tax");
            }
            if (myorder.Dt_Invoice.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_Invoice.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_Invoice.Columns.Contains("modulename"))
            {
                myorder.Dt_Invoice.Columns.Remove("modulename");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_Invoice.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_Invoice.Columns.Contains("IsFromWebStore"))
            {
                myorder.Dt_Invoice.Columns.Remove("IsFromWebStore");
            }
            if (myorder.Dt_Invoice.Columns.Contains("IsRejected"))
            {
                myorder.Dt_Invoice.Columns.Remove("IsRejected");
            }
            if (myorder.Dt_Invoice.Columns.Contains("RejectReason"))
            {
                myorder.Dt_Invoice.Columns.Remove("RejectReason");
            }
            if (myorder.Dt_Invoice.Columns.Contains("AttentionFor"))
            {
                myorder.Dt_Invoice.Columns.Remove("AttentionFor");
            }
            if (myorder.Dt_Invoice.Columns.Contains("CartItemID"))
            {
                myorder.Dt_Invoice.Columns.Remove("CartItemID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ProductID"))
            {
                myorder.Dt_Invoice.Columns.Remove("ProductID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderItemID"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderItemID");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ItemMaterial"))
            {
                myorder.Dt_Invoice.Columns.Remove("ItemMaterial");
            }
            if (myorder.Dt_Invoice.Columns.Contains("ActualDeliveryDate"))
            {
                myorder.Dt_Invoice.Columns.Remove("ActualDeliveryDate");
            }
            if (myorder.Dt_Invoice.Columns.Contains("SignNumber"))
            {
                myorder.Dt_Invoice.Columns.Remove("SignNumber");
            }
            if (myorder.Dt_Invoice.Columns.Contains("CampaignName"))
            {
                myorder.Dt_Invoice.Columns.Remove("CampaignName");
            }
            if (myorder.Dt_Invoice.Columns.Contains("Approved"))
            {
                myorder.Dt_Invoice.Columns.Remove("Approved");
            }
            if (myorder.Dt_Invoice.Columns.Contains("OrderedFor"))
            {
                myorder.Dt_Invoice.Columns.Remove("OrderedFor");
            }
            if (myorder.Dt_Invoice.Columns.Contains("EstimateType"))
            {
                myorder.Dt_Invoice.Columns.Remove("EstimateType");
            }
            if (myorder.Dt_Invoice.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Invoice.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Invoice.Columns[1].ColumnName.ToLower() == "department")
            {
                if (this.deptScreenName != "")
                {
                    myorder.Dt_Invoice.Columns[1].ColumnName = this.deptScreenName;
                }
                else
                {
                    myorder.Dt_Invoice.Columns[1].ColumnName = this.objLanguage.GetLanguageConversion("Department_To");
                }
            }
            if (myorder.Dt_Invoice.Columns[2].ColumnName == "OrderDate")
            {
                myorder.Dt_Invoice.Columns[2].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Invoice.Columns[3].ColumnName == "RequiredBy")
            {
                myorder.Dt_Invoice.Columns[3].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Invoice.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_Invoice.Columns[4].ColumnName = "Invoice Title";
            }
            if (myorder.Dt_Invoice.Columns[5].ColumnName == "OrderItemTitle")
            {
                myorder.Dt_Invoice.Columns[5].ColumnName = "Item Title";
            }
            if (myorder.Dt_Invoice.Columns[6].ColumnName == "quantity")
            {
                myorder.Dt_Invoice.Columns[6].ColumnName = "Qty";
                myorder.Dt_Invoice.Columns[6].SetOrdinal(6);
            }
            if (myorder.Dt_Invoice.Columns[6].ColumnName == "orderStatus")
            {
                myorder.Dt_Invoice.Columns[6].ColumnName = "Order Status";
            }
            if (this.IsEnableHidePrice == "false")
            {
                if (myorder.Dt_Invoice.Columns[8].ColumnName == "TotalPrice")
                {
                    myorder.Dt_Invoice.Columns[8].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
                if (myorder.Dt_Invoice.Columns[9].ColumnName == "FinalPrice")
                {
                    myorder.Dt_Invoice.Columns[9].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
            }
            DataTable dtInvoice = myorder.Dt_Invoice;
            //HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dtInvoice, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");

            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dtInvoice, filename);
        }

        public void btnExportJob_OnClick(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (this.WhereCondition != "")
            {
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "order", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
                myorder.Dt_Jobs = dataSet.Tables[0];
                dataTable.Columns["RequiredBy"].ReadOnly = false;
                dataTable.Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in myorder.Dt_Jobs.Rows)
            {
                if (!myorder.Dt_Jobs.Columns.Contains("OrderItemTitle"))
                {
                    continue;
                }
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString().Replace("<br/>", "\n"));
            }
            if (this.IsEnableHidePrice == "true")
            {
                if (myorder.Dt_Jobs.Columns.Contains("TotalPrice"))
                {
                    myorder.Dt_Jobs.Columns.Remove("TotalPrice");
                }
                if (myorder.Dt_Jobs.Columns.Contains("FinalPrice"))
                {
                    myorder.Dt_Jobs.Columns.Remove("FinalPrice");
                }
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderID"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderKey"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_Jobs.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_Jobs.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("AccountID"))
            {
                myorder.Dt_Jobs.Columns.Remove("AccountID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_Jobs.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_Jobs.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_Jobs.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_Jobs.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_Jobs.Columns.Contains("EstimateID"))
            {
                myorder.Dt_Jobs.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("CompanyID"))
            {
                myorder.Dt_Jobs.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ClientID"))
            {
                myorder.Dt_Jobs.Columns.Remove("ClientID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("PaymentType"))
            {
                myorder.Dt_Jobs.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_Jobs.Columns.Contains("createdBy"))
            {
                myorder.Dt_Jobs.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Jobs.Columns.Contains("createdBy"))
            {
                myorder.Dt_Jobs.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_Jobs.Columns.Contains("Tax"))
            {
                myorder.Dt_Jobs.Columns.Remove("Tax");
            }
            if (myorder.Dt_Jobs.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_Jobs.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_Jobs.Columns.Contains("modulename"))
            {
                myorder.Dt_Jobs.Columns.Remove("modulename");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_Jobs.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_Jobs.Columns.Contains("IsFromWebStore"))
            {
                myorder.Dt_Jobs.Columns.Remove("IsFromWebStore");
            }
            if (myorder.Dt_Jobs.Columns.Contains("IsRejected"))
            {
                myorder.Dt_Jobs.Columns.Remove("IsRejected");
            }
            if (myorder.Dt_Jobs.Columns.Contains("RejectReason"))
            {
                myorder.Dt_Jobs.Columns.Remove("RejectReason");
            }
            if (myorder.Dt_Jobs.Columns.Contains("AttentionFor"))
            {
                myorder.Dt_Jobs.Columns.Remove("AttentionFor");
            }
            if (myorder.Dt_Jobs.Columns.Contains("CartItemID"))
            {
                myorder.Dt_Jobs.Columns.Remove("CartItemID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ProductID"))
            {
                myorder.Dt_Jobs.Columns.Remove("ProductID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderItemID"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderItemID");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ItemMaterial"))
            {
                myorder.Dt_Jobs.Columns.Remove("ItemMaterial");
            }
            if (myorder.Dt_Jobs.Columns.Contains("ActualDeliveryDate"))
            {
                myorder.Dt_Jobs.Columns.Remove("ActualDeliveryDate");
            }
            if (myorder.Dt_Jobs.Columns.Contains("SignNumber"))
            {
                myorder.Dt_Jobs.Columns.Remove("SignNumber");
            }
            if (myorder.Dt_Jobs.Columns.Contains("CampaignName"))
            {
                myorder.Dt_Jobs.Columns.Remove("CampaignName");
            }
            if (myorder.Dt_Jobs.Columns.Contains("Approved"))
            {
                myorder.Dt_Jobs.Columns.Remove("Approved");
            }
            if (myorder.Dt_Jobs.Columns.Contains("OrderedFor"))
            {
                myorder.Dt_Jobs.Columns.Remove("OrderedFor");
            }
            if (myorder.Dt_Jobs.Columns.Contains("EstimateType"))
            {
                myorder.Dt_Jobs.Columns.Remove("EstimateType");
            }
            if (myorder.Dt_Jobs.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Jobs.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Jobs.Columns[1].ColumnName.ToLower() == "department")
            {
                if (this.deptScreenName != "")
                {
                    myorder.Dt_Jobs.Columns[1].ColumnName = this.deptScreenName;
                }
                else
                {
                    myorder.Dt_Jobs.Columns[1].ColumnName = this.objLanguage.GetLanguageConversion("Department_To");
                }
            }
            if (myorder.Dt_Jobs.Columns[2].ColumnName == "OrderDate")
            {
                myorder.Dt_Jobs.Columns[2].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Jobs.Columns[3].ColumnName == "RequiredBy")
            {
                myorder.Dt_Jobs.Columns[3].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Jobs.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_Jobs.Columns[4].ColumnName = "Job Title";
            }
            if (myorder.Dt_Jobs.Columns[5].ColumnName == "OrderItemTitle")
            {
                myorder.Dt_Jobs.Columns[5].ColumnName = "Item Title";
            }
            if (myorder.Dt_Jobs.Columns[6].ColumnName == "quantity")
            {
                myorder.Dt_Jobs.Columns[6].ColumnName = "Qty";
                myorder.Dt_Jobs.Columns[6].SetOrdinal(6);
            }
            if (myorder.Dt_Jobs.Columns[6].ColumnName == "orderStatus")
            {
                myorder.Dt_Jobs.Columns[6].ColumnName = "Order Status";
            }
            if (this.IsEnableHidePrice == "false")
            {
                if (myorder.Dt_Jobs.Columns[8].ColumnName == "TotalPrice")
                {
                    myorder.Dt_Jobs.Columns[8].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
                if (myorder.Dt_Jobs.Columns[9].ColumnName == "FinalPrice")
                {
                    myorder.Dt_Jobs.Columns[9].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                }
            }
            DataTable dtJobs = myorder.Dt_Jobs;
            //HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dtJobs, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");

            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dtJobs, filename);

        }

        public void btnExportOrder_OnClick(object sender, EventArgs e)
        {
            this.RadGridOrder.MasterTableView.Columns[0].Visible = false;
            this.RadGridOrder.MasterTableView.ExportToExcel();
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (this.WhereCondition == "")
            {
                dataTable = myorder.Dt_Orders;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!dataTable.Columns.Contains("OrderItemTitle"))
                    {
                        continue;
                    }
                    row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString().Replace("<br/>", "\n"));
                }
            }
            else
            {
                OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "order", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
            }
            if (this.IsEnableHidePrice == "true")
            {
                if (dataTable.Columns.Contains("TotalPrice"))
                {
                    dataTable.Columns.Remove("TotalPrice");
                }
                if (dataTable.Columns.Contains("FinalPrice"))
                {
                    dataTable.Columns.Remove("FinalPrice");
                }
            }
            if (dataTable.Columns.Contains("OrderID"))
            {
                dataTable.Columns.Remove("OrderID");
            }
            if (dataTable.Columns.Contains("OrderKey"))
            {
                dataTable.Columns.Remove("OrderKey");
            }
            if (dataTable.Columns.Contains("StoreUserID"))
            {
                dataTable.Columns.Remove("StoreUserID");
            }
            if (dataTable.Columns.Contains("AccountID"))
            {
                dataTable.Columns.Remove("AccountID");
            }
            if (dataTable.Columns.Contains("OrderShipping"))
            {
                dataTable.Columns.Remove("OrderShipping");
            }
            if (dataTable.Columns.Contains("BillingAddressID"))
            {
                dataTable.Columns.Remove("BillingAddressID");
            }
            if (dataTable.Columns.Contains("ShippingAddressID"))
            {
                dataTable.Columns.Remove("ShippingAddressID");
            }
            if (dataTable.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                dataTable.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (dataTable.Columns.Contains("EstimateID"))
            {
                dataTable.Columns.Remove("EstimateID");
            }
            if (dataTable.Columns.Contains("CompanyID"))
            {
                dataTable.Columns.Remove("CompanyID");
            }
            if (dataTable.Columns.Contains("ClientID"))
            {
                dataTable.Columns.Remove("ClientID");
            }
            if (dataTable.Columns.Contains("PaymentType"))
            {
                dataTable.Columns.Remove("PaymentType");
            }
            if (dataTable.Columns.Contains("createdBy"))
            {
                dataTable.Columns.Remove("createdBy");
            }
            if (dataTable.Columns.Contains("createdBy"))
            {
                dataTable.Columns.Remove("createdBy");
            }
            if (dataTable.Columns.Contains("OrderAdditionalPrice"))
            {
                dataTable.Columns.Remove("OrderAdditionalPrice");
            }
            if (dataTable.Columns.Contains("Tax"))
            {
                dataTable.Columns.Remove("Tax");
            }
            if (dataTable.Columns.Contains("EstimatedCompletionDate"))
            {
                dataTable.Columns.Remove("EstimatedCompletionDate");
            }
            if (dataTable.Columns.Contains("modulename"))
            {
                dataTable.Columns.Remove("modulename");
            }
            if (dataTable.Columns.Contains("ReOrderCheck"))
            {
                dataTable.Columns.Remove("ReOrderCheck");
            }
            if (dataTable.Columns.Contains("IsFromWebStore"))
            {
                dataTable.Columns.Remove("IsFromWebStore");
            }
            if (dataTable.Columns.Contains("IsRejected"))
            {
                dataTable.Columns.Remove("IsRejected");
            }
            if (dataTable.Columns.Contains("RejectReason"))
            {
                dataTable.Columns.Remove("RejectReason");
            }
            if (dataTable.Columns.Contains("AttentionFor"))
            {
                dataTable.Columns.Remove("AttentionFor");
            }
            if (dataTable.Columns.Contains("CartItemID"))
            {
                dataTable.Columns.Remove("CartItemID");
            }
            if (dataTable.Columns.Contains("ProductID"))
            {
                dataTable.Columns.Remove("ProductID");
            }
            if (dataTable.Columns.Contains("OrderItemID"))
            {
                dataTable.Columns.Remove("OrderItemID");
            }
            if (dataTable.Columns.Contains("ItemMaterial"))
            {
                dataTable.Columns.Remove("ItemMaterial");
            }
            if (dataTable.Columns.Contains("ActualDeliveryDate"))
            {
                dataTable.Columns.Remove("ActualDeliveryDate");
            }
            if (dataTable.Columns.Contains("EstimateType"))
            {
                dataTable.Columns.Remove("EstimateType");
            }
            if (this.Session["ApprovalSystem"].ToString() != "on" && dataTable.Columns.Contains("Approved"))
            {
                dataTable.Columns.Remove("Approved");
            }
            if (this.IsCampaignEnabled.ToLower() == "false")
            {
                if (dataTable.Columns.Contains("SignNumber"))
                {
                    dataTable.Columns.Remove("SignNumber");
                }
                if (dataTable.Columns.Contains("CampaignName"))
                {
                    dataTable.Columns.Remove("CampaignName");
                }
            }
            if (dataTable.Columns[0].ColumnName == "OrderNo")
            {
                dataTable.Columns[0].ColumnName = "Order Reference";
            }
            if (dataTable.Columns[1].ColumnName.ToLower() == "department")
            {
                if (this.deptScreenName != "")
                {
                    dataTable.Columns[1].ColumnName = this.deptScreenName;
                }
                else
                {
                    dataTable.Columns[1].ColumnName = this.objLanguage.GetLanguageConversion("Department_To");
                }
            }
            if (dataTable.Columns[2].ColumnName == "OrderDate")
            {
                dataTable.Columns[2].ColumnName = "Date Raised";
            }
            if (dataTable.Columns[3].ColumnName == "RequiredBy")
            {
                dataTable.Columns[3].ColumnName = "Delivery Date";
            }
            if (dataTable.Columns[4].ColumnName == "OrderedFor")
            {
                dataTable.Columns[4].ColumnName = "Raised By/For";
            }
            if (dataTable.Columns[5].ColumnName == "OrderTitle")
            {
                dataTable.Columns[5].ColumnName = "Order Title";
            }
            if (dataTable.Columns[6].ColumnName == "OrderItemTitle")
            {
                dataTable.Columns[6].ColumnName = "Item Title";
            }
            if (dataTable.Columns[7].ColumnName == "quantity")
            {
                dataTable.Columns[7].ColumnName = "Qty";
            }
            if (this.IsCampaignEnabled.ToLower() != "true")
            {
                if (dataTable.Columns[8].ColumnName == "orderStatus")
                {
                    dataTable.Columns[8].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (dataTable.Columns[9].ColumnName == "Approved")
                    {
                        dataTable.Columns[9].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (dataTable.Columns[10].ColumnName == "TotalPrice")
                        {
                            dataTable.Columns[10].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dataTable.Columns[11].ColumnName == "FinalPrice")
                        {
                            dataTable.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                else if (this.IsEnableHidePrice == "false")
                {
                    if (dataTable.Columns[9].ColumnName == "TotalPrice")
                    {
                        dataTable.Columns[9].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (dataTable.Columns[10].ColumnName == "FinalPrice")
                    {
                        dataTable.Columns[10].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }
            }
            else
            {
                if (dataTable.Columns[8].ColumnName == "SignNumber")
                {
                    dataTable.Columns[8].ColumnName = "Sign No.";
                }
                if (dataTable.Columns[9].ColumnName == "CampaignName")
                {
                    dataTable.Columns[9].ColumnName = "Campaign Name";
                }
                if (dataTable.Columns[10].ColumnName == "orderStatus")
                {
                    dataTable.Columns[10].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (dataTable.Columns[11].ColumnName == "Approved")
                    {
                        dataTable.Columns[11].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (dataTable.Columns[12].ColumnName == "TotalPrice")
                        {
                            dataTable.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (dataTable.Columns[13].ColumnName == "FinalPrice")
                        {
                            dataTable.Columns[13].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                else if (this.IsEnableHidePrice == "false")
                {
                    if (dataTable.Columns[11].ColumnName == "TotalPrice")
                    {
                        dataTable.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (dataTable.Columns[12].ColumnName == "FinalPrice")
                    {
                        dataTable.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }
            }
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();

            //this.ExportData(dataTable, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dataTable, filename);
        }


        public void Export_with_XSLT_Web(DataTable dsExport, string FileName)
        {
            CellExport cellExport = new CellExport()
            {
                ActionAfterExport = ActionType.OpenView,
                AutoFitColWidth = true
            };
            cellExport.DataFormats.CultureName = "en-US";
            cellExport.DataFormats.Currency = "#,###,##0.00";
            cellExport.DataFormats.DateTime = "yyyy-M-d H:mm";
            cellExport.DataFormats.Float = "#,###,##0.00";
            cellExport.DataFormats.Integer = "#,###,##0";
            cellExport.DataFormats.Time = "H:mm";
            cellExport.SheetOptions.AggregateFormat.Font.Name = "Arial";
            cellExport.SheetOptions.CustomDataFormat.Font.Name = "Arial";
            cellExport.SheetOptions.DefaultFont.Name = "Arial";
            cellExport.SheetOptions.FooterFormat.Font.Name = "Arial";
            cellExport.SheetOptions.HeaderFormat.Font.Name = "Arial";
            cellExport.SheetOptions.HyperlinkFormat.Font.Color = CellColor.Blue;
            cellExport.SheetOptions.HyperlinkFormat.Font.Name = "Arial";
            cellExport.SheetOptions.HyperlinkFormat.Font.Underline = XlsFontUnderline.Single;
            cellExport.SheetOptions.NoteFormat.Alignment.Horizontal = HorizontalAlignment.Left;
            cellExport.SheetOptions.NoteFormat.Alignment.Vertical = VerticalAlignment.Top;
            cellExport.SheetOptions.NoteFormat.Font.Bold = true;
            cellExport.SheetOptions.NoteFormat.Font.Name = "Tahoma";
            cellExport.SheetOptions.NoteFormat.Font.Size = 8f;
            cellExport.SheetOptions.TitlesFormat.Font.Bold = true;
            cellExport.SheetOptions.TitlesFormat.Font.Name = "Arial";
            cellExport.DataTable = dsExport;
            cellExport.DataSource = ExportSource.DataTable;
            FileName = FileName.ToLower().Replace(".csv", "").Replace(".xls", "");
            cellExport.FileName = string.Concat(FileName, ".xls");
            MemoryStream memoryStream = new MemoryStream();
            cellExport.SaveToStream(memoryStream);
            byte[] numArray = new byte[checked(memoryStream.Length)];
            memoryStream.Read(numArray, 0, (int)numArray.Length);
            memoryStream.Close();
            Response.ClearHeaders();
            Response.ClearContent();
            this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            this.Response.AddHeader("content-disposition", string.Concat("attachment; filename=\"", cellExport.FileName, "\""));
            this.Response.BinaryWrite(numArray);
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Flush();
         
            Response.End();
        }

        public void btnExportpending_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "pending");
                myorder.Dt_Pending = dataSet.Tables[0];
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in myorder.Dt_Pending.Rows)
            {
                if (!myorder.Dt_Pending.Columns.Contains("OrderItemTitle"))
                {
                    continue;
                }
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString().Replace("<br/>", "\n"));
            }
            if (this.IsEnableHidePrice == "true")
            {
                if (myorder.Dt_Pending.Columns.Contains("TotalPrice"))
                {
                    myorder.Dt_Pending.Columns.Remove("TotalPrice");
                }
                if (myorder.Dt_Pending.Columns.Contains("FinalPrice"))
                {
                    myorder.Dt_Pending.Columns.Remove("FinalPrice");
                }
            }
            if (myorder.Dt_Pending.Columns.Contains("OrderID"))
            {
                myorder.Dt_Pending.Columns.Remove("OrderID");
            }
            if (myorder.Dt_Pending.Columns.Contains("OrderKey"))
            {
                myorder.Dt_Pending.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_Pending.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_Pending.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_Pending.Columns.Contains("AccountID"))
            {
                myorder.Dt_Pending.Columns.Remove("AccountID");
            }
            if (myorder.Dt_Pending.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_Pending.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_Pending.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_Pending.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_Pending.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_Pending.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_Pending.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_Pending.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_Pending.Columns.Contains("EstimateID"))
            {
                myorder.Dt_Pending.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_Pending.Columns.Contains("CompanyID"))
            {
                myorder.Dt_Pending.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_Pending.Columns.Contains("ClientID"))
            {
                myorder.Dt_Pending.Columns.Remove("ClientID");
            }
            if (myorder.Dt_Pending.Columns.Contains("PaymentType"))
            {
                myorder.Dt_Pending.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_Pending.Columns.Contains("createdBy"))
            {
                myorder.Dt_Pending.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Pending.Columns.Contains("createdBy"))
            {
                myorder.Dt_Pending.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Pending.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_Pending.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_Pending.Columns.Contains("Tax"))
            {
                myorder.Dt_Pending.Columns.Remove("Tax");
            }
            if (myorder.Dt_Pending.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_Pending.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_Pending.Columns.Contains("modulename"))
            {
                myorder.Dt_Pending.Columns.Remove("modulename");
            }
            if (myorder.Dt_Pending.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_Pending.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_Pending.Columns.Contains("IsFromWebStore"))
            {
                myorder.Dt_Pending.Columns.Remove("IsFromWebStore");
            }
            if (myorder.Dt_Pending.Columns.Contains("IsRejected"))
            {
                myorder.Dt_Pending.Columns.Remove("IsRejected");
            }
            if (myorder.Dt_Pending.Columns.Contains("RejectReason"))
            {
                myorder.Dt_Pending.Columns.Remove("RejectReason");
            }
            if (myorder.Dt_Pending.Columns.Contains("AttentionFor"))
            {
                myorder.Dt_Pending.Columns.Remove("AttentionFor");
            }
            if (myorder.Dt_Pending.Columns.Contains("CartItemID"))
            {
                myorder.Dt_Pending.Columns.Remove("CartItemID");
            }
            if (myorder.Dt_Pending.Columns.Contains("ProductID"))
            {
                myorder.Dt_Pending.Columns.Remove("ProductID");
            }
            if (myorder.Dt_Pending.Columns.Contains("OrderItemID"))
            {
                myorder.Dt_Pending.Columns.Remove("OrderItemID");
            }
            if (myorder.Dt_Pending.Columns.Contains("ItemMaterial"))
            {
                myorder.Dt_Pending.Columns.Remove("ItemMaterial");
            }
            if (myorder.Dt_Pending.Columns.Contains("ActualDeliveryDate"))
            {
                myorder.Dt_Pending.Columns.Remove("ActualDeliveryDate");
            }
            if (myorder.Dt_Pending.Columns.Contains("ScheduleType"))
            {
                myorder.Dt_Pending.Columns.Remove("ScheduleType");
            }
            if (myorder.Dt_Pending.Columns.Contains("IsApproved"))
            {
                myorder.Dt_Pending.Columns.Remove("IsApproved");
            }
            if (this.IsCampaignEnabled.ToLower() == "false")
            {
                if (myorder.Dt_Pending.Columns.Contains("SignNumber"))
                {
                    myorder.Dt_Pending.Columns.Remove("SignNumber");
                }
                if (myorder.Dt_Pending.Columns.Contains("CampaignName"))
                {
                    myorder.Dt_Pending.Columns.Remove("CampaignName");
                }
            }
            if (myorder.Dt_Pending.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Pending.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Pending.Columns[1].ColumnName.ToLower() == "department")
            {
                if (this.deptScreenName != "")
                {
                    myorder.Dt_Pending.Columns[1].ColumnName = this.deptScreenName;
                }
                else
                {
                    myorder.Dt_Pending.Columns[1].ColumnName = this.objLanguage.GetLanguageConversion("Department_To");
                }
            }
            if (myorder.Dt_Pending.Columns[2].ColumnName == "OrderDate")
            {
                myorder.Dt_Pending.Columns[2].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Pending.Columns[3].ColumnName == "RequiredBy")
            {
                myorder.Dt_Pending.Columns[3].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Pending.Columns[4].ColumnName == "OrderedFor")
            {
                myorder.Dt_Pending.Columns[4].ColumnName = "Raised By/For";
            }
            if (myorder.Dt_Pending.Columns[5].ColumnName == "OrderTitle")
            {
                myorder.Dt_Pending.Columns[5].ColumnName = "Order Title";
            }
            if (myorder.Dt_Pending.Columns[6].ColumnName == "OrderItemTitle")
            {
                myorder.Dt_Pending.Columns[6].ColumnName = "Item Title";
            }
            if (myorder.Dt_Pending.Columns[7].ColumnName == "quantity")
            {
                myorder.Dt_Pending.Columns[7].ColumnName = "Qty";
            }
            if (this.IsCampaignEnabled.ToLower() != "true")
            {
                if (myorder.Dt_Pending.Columns[8].ColumnName == "orderStatus")
                {
                    myorder.Dt_Pending.Columns[8].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    if (myorder.Dt_Pending.Columns[9].ColumnName == "Approved")
                    {
                        myorder.Dt_Pending.Columns[9].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (myorder.Dt_Pending.Columns[10].ColumnName == "TotalPrice")
                        {
                            myorder.Dt_Pending.Columns[10].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (myorder.Dt_Pending.Columns[11].ColumnName == "FinalPrice")
                        {
                            myorder.Dt_Pending.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
            }
            else
            {
                if (myorder.Dt_Pending.Columns[8].ColumnName == "SignNumber")
                {
                    myorder.Dt_Pending.Columns[8].ColumnName = "Sign No.";
                }
                if (myorder.Dt_Pending.Columns[9].ColumnName == "CampaignName")
                {
                    myorder.Dt_Pending.Columns[9].ColumnName = "Campaign Name";
                }
                if (myorder.Dt_Pending.Columns[10].ColumnName == "orderStatus")
                {
                    myorder.Dt_Pending.Columns[10].ColumnName = "Order Status";
                }
                if (this.Session["ApprovalSystem"].ToString() == "on")
                {
                    if (myorder.Dt_Pending.Columns[11].ColumnName == "Approved")
                    {
                        myorder.Dt_Pending.Columns[11].ColumnName = "Approval Status";
                    }
                    if (this.IsEnableHidePrice == "false")
                    {
                        if (myorder.Dt_Pending.Columns[12].ColumnName == "TotalPrice")
                        {
                            myorder.Dt_Pending.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                        if (myorder.Dt_Pending.Columns[13].ColumnName == "FinalPrice")
                        {
                            myorder.Dt_Pending.Columns[13].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                        }
                    }
                }
                else if (this.IsEnableHidePrice == "false")
                {
                    if (myorder.Dt_Pending.Columns[11].ColumnName == "TotalPrice")
                    {
                        myorder.Dt_Pending.Columns[11].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                    if (myorder.Dt_Pending.Columns[12].ColumnName == "FinalPrice")
                    {
                        myorder.Dt_Pending.Columns[12].ColumnName = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
                    }
                }
            }
            DataTable dtPending = myorder.Dt_Pending;
            //HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            //this.ExportData(dtPending, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
            var filename = string.Concat("Orders_", guid.ToString().Substring(0, 10));
            Export_with_XSLT_Web(dtPending, filename);
        }

        protected void EditItem_Click(object sender, CommandEventArgs e)
        {
            Convert.ToInt64(e.CommandArgument);
        }

        public void ExportData(DataTable WashedPart, string attachmentName, string Name)
        {
            //Workbook workbook = new Workbook()
            //{
            //    Version = ExcelVersion.Version2007
            //};
            //Worksheet item = workbook.Worksheets[0];
            //CellStyle cellStyle = workbook.Styles.Add("style");
            //cellStyle.HorizontalAlignment = HorizontalAlignType.Center;
            //item.Range["B1:C1"].Style = cellStyle;
            //item.Range["B2:B10000"].Style = cellStyle;
            //item.Range["C2:C10000"].Style = cellStyle;
            //item.InsertDataTable(WashedPart, true, 1, 1);
            //workbook.SaveToFile(attachmentName);
            //FileInfo fileInfo = new FileInfo(attachmentName);
            //if (fileInfo.Exists)
            //{
            //    base.Response.Clear();
            //    base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", Name));
            //    base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            //    base.Response.ContentType = "application/octet-stream";
            //    base.Response.WriteFile(fileInfo.FullName);
            //    base.Response.End();
            //}
        }

        public string FilterFunction(DataTable dtsearchfilter)
        {
            foreach (DataRow row in LoginBasePage.Select_AccountDetails((long)this.CompanyID, myorder.AccountID).Rows)
            {
                this.DateFormat = row["DateFormat"].ToString();
            }
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow dataRow in dtsearchfilter.Rows)
            {
                if (dataRow["filter"].ToString().ToLower() != "nofilter" && empty1 != "")
                {
                    empty1 = string.Concat(empty1, " and ");
                }
                if (dataRow["ColumnName"].ToString().ToLower() == "orderdate" || dataRow["ColumnName"].ToString().ToLower() == "requiredby")
                {
                    str = this.objJava.eprint_checkdateformat_returnonlymmddyyyy("DateFormat", dataRow["FilterText"].ToString().Trim());
                    empty = string.Concat("DateAdd(d,0,DateDiff(d,0,", dataRow["ColumnName"].ToString(), "))");
                }
                string lower = dataRow["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                if (str1 == "startswith")
                {
                    string str2 = empty1;
                    string[] strArrays = new string[] { str2, " ", dataRow["ColumnName"].ToString(), " like '", dataRow["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays);
                }
                else if (str1 == "endswith")
                {
                    string str3 = empty1;
                    string[] strArrays1 = new string[] { str3, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays1);
                }
                else if (str1 == "equalto")
                {
                    if (dataRow["ColumnName"].ToString().ToLower() == "orderdate" || dataRow["ColumnName"].ToString().ToLower() == "requiredby")
                    {
                        string str4 = empty1;
                        string[] strArrays2 = new string[] { str4, " ", empty, " = '", str, "'" };
                        empty1 = string.Concat(strArrays2);
                    }
                    else
                    {
                        string str5 = empty1;
                        string[] strArrays3 = new string[] { str5, " ", dataRow["ColumnName"].ToString(), " = '", dataRow["FilterText"].ToString().Trim(), "'" };
                        empty1 = string.Concat(strArrays3);
                    }
                }
                else if (str1 != "contains")
                {
                    if (str1 == "doesnotcontain")
                    {
                        string str6 = empty1;
                        string[] strArrays4 = new string[] { str6, " ", dataRow["ColumnName"].ToString(), " not like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                        empty1 = string.Concat(strArrays4);
                    }
                }
                else if (dataRow["ColumnName"].ToString().ToLower() == "orderdate" || dataRow["ColumnName"].ToString().ToLower() == "requiredby")
                {
                    string str7 = empty1;
                    string[] strArrays5 = new string[] { str7, " ", empty, " = '", str, "'" };
                    empty1 = string.Concat(strArrays5);
                }
                else
                {
                    string str8 = empty1;
                    string[] strArrays6 = new string[] { str8, " ", dataRow["ColumnName"].ToString(), " like '%", dataRow["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays6);
                }
            }
            return empty1;
        }

        protected void imgApproPending_Click(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            HttpResponse response = base.Response;
            string[] commandArgument = new string[] { this.strSitepath, "order.aspx?OrderID=", imageButton.CommandArgument, "&UserID=", imageButton.CommandName };
            response.Redirect(string.Concat(commandArgument));
        }

        protected void lnkArtworkItem_Click(object sender, CommandEventArgs e)
        {
            long num = Convert.ToInt64(e.CommandArgument);
            DataTable dataTable = OrderBasePage.Insert_Reorder_Deatil(num);
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] str = new object[] { "javascript:openArtworkPopup(", dataTable.Rows[0]["CartItemID"].ToString(), ",", dataTable.Rows[0]["OrderItemID"].ToString(), ",", num, ");" };
            System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "_showArtwork", string.Concat(str), true);
        }

        protected void lnkAwaitingApproval_ArtworkiconClick(object sender, CommandEventArgs e)
        {
            long num = Convert.ToInt64(e.CommandArgument);
            DataTable dataTable = OrderBasePage.Insert_Reorder_Deatil(num);
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] str = new object[] { "javascript:openArtworkPopup(", dataTable.Rows[0]["CartItemID"].ToString(), ",", dataTable.Rows[0]["OrderItemID"].ToString(), ",", num, ");" };
            System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "_showArtwork", string.Concat(str), true);
        }

        protected void lnkInvoiceFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGridInvoice.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["searchJobs"] = null;
            this.RadGridInvoice.MasterTableView.FilterExpression = string.Empty;
            this.RadGridInvoice.MasterTableView.Rebind();
        }

        protected void lnkJobFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGridJob.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["searchJobs"] = null;
            this.RadGridJob.MasterTableView.FilterExpression = string.Empty;
            this.RadGridJob.MasterTableView.Rebind();
        }

        protected void lnkorderArtworkItem_Click(object sender, CommandEventArgs e)
        {
            long num = Convert.ToInt64(e.CommandArgument);
            DataTable dataTable = OrderBasePage.Insert_Reorder_Deatil(num);
            System.Web.UI.Page page = this.Page;
            Type type = base.GetType();
            object[] str = new object[] { "javascript:openArtworkPopup(", dataTable.Rows[0]["CartItemID"].ToString(), ",", dataTable.Rows[0]["OrderItemID"].ToString(), ",", num, ");" };
            System.Web.UI.ScriptManager.RegisterStartupScript(page, type, "_showArtworkorder", string.Concat(str), true);
        }

        protected void lnkOrderFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.RadGridOrder.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["searchOrder"] = null;
            this.RadGridOrder.MasterTableView.FilterExpression = string.Empty;
            this.RadGridOrder.MasterTableView.Rebind();
        }

        protected void lnkPendingApproval_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.radPendingOrder.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["searchJobs"] = null;
            this.radPendingOrder.MasterTableView.FilterExpression = string.Empty;
            this.radPendingOrder.MasterTableView.Rebind();
        }

        protected void LnkReorder_Click(object sender, CommandEventArgs e)
        {
            long num = (long)0;
            string[] strArrays = e.CommandArgument.ToString().ToString().Split(new char[] { '\u005F' });
            num = Convert.ToInt64(strArrays[1]);
            DataTable dataTable = OrderBasePage.Insert_Reorder_Deatil(Convert.ToInt64(strArrays[0]));
            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToInt64(row["CartItemID"]) != num)
                {
                    continue;
                }
                this.TemplateID = row["TemplateID"].ToString();
                DataTable dataTable1 = OrderBasePage.Insert_Reordered_CartItemsandDetails(Convert.ToInt64(row["CartItemID"]), "", this.StoreUserID);
                if (dataTable1.Rows.Count > 0)
                {
                    this.CartItemID = dataTable1.Rows[0]["CartItemID"].ToString();
                }
                string str = row["PDFNameFromCart"].ToString();
                if (Convert.ToInt64(this.TemplateID) <= (long)0)
                {
                    continue;
                }
                DataTable dataTable2 = ProductBasePage.Select_PriceCatalogueID(Convert.ToInt64(this.TemplateID));
                if (dataTable2.Rows.Count <= 0)
                {
                    continue;
                }
                //ticket 104806
                DataTable dataTable3 = ProductBasePage.productsDetails_Select(Convert.ToInt32(dataTable2.Rows[0]["PriceCatalogueID"].ToString()));
                if (dataTable3.Rows.Count <= 0 || !(dataTable3.Rows[0]["IsEditableProduct"].ToString().ToLower() == "true") || !(str != ""))
                {
                    continue;
                }
                string cartItemID = this.CartItemID;
                Guid guid = Guid.NewGuid();
                string str1 = string.Concat(cartItemID, "_", guid.ToString().Substring(0, 30), ".pdf");
                object[] secureDocPath = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID, "\\pdf\\", str };
                string str2 = string.Concat(secureDocPath);
                object[] objArray = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID, "\\pdf\\", str1 };
                string str3 = string.Concat(objArray);
                if (File.Exists(str2))
                {
                    object[] secureDocPath1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID };
                    if (!Directory.Exists(string.Concat(secureDocPath1)))
                    {
                        object[] objArray1 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID };
                        Directory.CreateDirectory(string.Concat(objArray1));
                    }
                    object[] secureDocPath2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID, "\\pdf\\" };
                    if (!Directory.Exists(string.Concat(secureDocPath2)))
                    {
                        object[] objArray2 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\store\\", myorder.AccountID, "\\pdf\\" };
                        Directory.CreateDirectory(string.Concat(objArray2));
                    }
                    File.Copy(str2, str3, true);
                }
                object[] secureDocPath3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", str };
                string str4 = string.Concat(secureDocPath3);
                object[] objArray3 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\", str1 };
                string str5 = string.Concat(objArray3);
                if (File.Exists(str4))
                {
                    object[] secureDocPath4 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                    if (!Directory.Exists(string.Concat(secureDocPath4)))
                    {
                        object[] objArray4 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID };
                        Directory.CreateDirectory(string.Concat(objArray4));
                    }
                    object[] secureDocPath5 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                    if (!Directory.Exists(string.Concat(secureDocPath5)))
                    {
                        object[] objArray5 = new object[] { ConnectionClass.SecureDocPath, ConnectionClass.ServerName, "\\", this.CompanyID, "\\attachments\\" };
                        Directory.CreateDirectory(string.Concat(objArray5));
                    }
                    File.Copy(str4, str5, true);
                }
                CartBasePage.Update_PDFNameC(Convert.ToInt64(this.CartItemID), str1, "", "", row["JobName"].ToString());
            }
            base.Response.Redirect(string.Concat(this.strSitepath, "ShoppingCart.aspx?type=ro"));
        }

        protected void lnlAwatingClearFil_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.radAwaiting.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.Session["searchJobs"] = null;
            this.radAwaiting.MasterTableView.FilterExpression = string.Empty;
            this.radAwaiting.MasterTableView.Rebind();
        }

        protected void MyOrdergrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)this.Session["searchJobs"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchJobs"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataTable dataTable1 = new DataTable();
                if (this.Session["ApprovalSystem"] == null)
                {
                    dataTable = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                }
                else if (this.Session["ApprovalSystem"].ToString() != "on")
                {
                    dataTable1 = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                    dataTable1.Columns["RequiredBy"].ReadOnly = false;
                    dataTable1.Columns["OrderDate"].ReadOnly = false;
                }
                else
                {
                    dataTable1 = OrderBasePage.Select_B2B_Orders_reeng_ByItem(this.StoreUserID, this.WhereCondition, this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders, this.IsHideMISJobVisible, this.IsHideMISInvoiceVisible);
                    dataTable1.Columns["RequiredBy"].ReadOnly = false;
                    dataTable1.Columns["OrderDate"].ReadOnly = false;
                }
                this.MyOrdergrid.Rebind();
            }
        }

        protected void MyOrdergrid_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("div_atnfor");
                if (((Label)e.Item.FindControl("lbl_forattn")).Text != "")
                {
                    htmlControl.Style.Add("display", "block");
                }
                if (dataItem["Approved"].ToString().ToLower() == "no")
                {
                    string[] fileExtension = new string[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", dataItem["ProductID"].ToString(), "&CartItemID=", dataItem["CartItemID"].ToString(), "&OrdKey=", dataItem["OrderKey"].ToString() };
                    string str = string.Concat(fileExtension);
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plheditImage")).Controls;
                    object[] accountID = new object[] { "<a href=", str, "><img id='img_Edit' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(accountID)));
                }
                if (CartBasePage.ArtworkFile_Cart_Order_Select(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"]), Convert.ToInt64(dataItem["OrderID"]), "order").Rows.Count > 0)
                {
                    ControlCollection controlCollections = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick='javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",", dataItem["OrderID"], ") ' class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                }
                Label label = (Label)e.Item.FindControl("lblTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
                LinkButton linkButton = (LinkButton)e.Item.FindControl("LnkReorder");
                if (dataItem["IsFromWebstore"].ToString().ToLower() == "yes")
                {
                    linkButton.Visible = true;
                }
                Label red = (Label)e.Item.FindControl("lblOrderStatus");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("imgReject");
                if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && dataItem["IsRejected"].ToString().ToLower() == "true")
                {
                    imageButton.Visible = false;
                    red.Text = "Rejected";
                    red.ForeColor = Color.Red;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.MyOrdergrid.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.MyOrdergrid.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void MyOrdergrid_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GridFilterMenu filterMenu = this.MyOrdergrid.FilterMenu;
            for (int i = filterMenu.Items.Count - 1; i >= 0; i--)
            {
                if (filterMenu.Items[i].Text == "Custom")
                {
                    filterMenu.Items[i].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu.Items[i].Text.ToLower() == "isempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisempty")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "isnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notisnull")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "between")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notbetween")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "notequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthan")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
                if (filterMenu.Items[i].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu.Items[i].Visible = false;
                }
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
            GridFilterMenu languageConversion = this.radAwaiting.FilterMenu;
            for (int j = languageConversion.Items.Count - 1; j >= 0; j--)
            {
                if (languageConversion.Items[j].Text == "Custom")
                {
                    languageConversion.Items[j].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion.Items[j].Text.ToLower() == "isempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisempty")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "isnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notisnull")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "between")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notbetween")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "notequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion.Items[j].Visible = false;
                }
                if (languageConversion.Items[j].Text.ToLower() == "nofilter")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion.Items[j].Text.ToLower() == "contains")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion.Items[j].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion.Items[j].Text.ToLower() == "startswith")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "endswith")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion.Items[j].Text.ToLower() == "equalto")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion.Items[j].Text.ToLower() == "greaterthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion.Items[j].Text.ToLower() == "lessthan")
                {
                    languageConversion.Items[j].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu gridFilterMenu = this.radPendingOrder.FilterMenu;
            for (int k = gridFilterMenu.Items.Count - 1; k >= 0; k--)
            {
                if (gridFilterMenu.Items[k].Text == "Custom")
                {
                    gridFilterMenu.Items[k].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "isempty")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "isnull")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "between")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "notequalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu.Items[k].Visible = false;
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "nofilter")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "contains")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "doesnotcontain")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "startswith")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "endswith")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "equalto")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (gridFilterMenu.Items[k].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu.Items[k].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu filterMenu1 = this.RadGridJob.FilterMenu;
            for (int l = filterMenu.Items.Count - 1; l >= 0; l--)
            {
                if (filterMenu1.Items[l].Text == "Custom")
                {
                    filterMenu1.Items[l].Text = "Custom-Text (ThisWeek)";
                }
                if (filterMenu1.Items[l].Text.ToLower() == "isempty")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "notisempty")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "isnull")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "notisnull")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "between")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "notbetween")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "notequalto")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "greaterthan")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "lessthan")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "greaterthanorequalto")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "lessthanorequalto")
                {
                    filterMenu1.Items[l].Visible = false;
                }
                if (filterMenu1.Items[l].Text.ToLower() == "nofilter")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "contains")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "doesnotcontain")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "startswith")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "endswith")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "equalto")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "greaterthan")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (filterMenu1.Items[l].Text.ToLower() == "lessthan")
                {
                    filterMenu1.Items[l].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu languageConversion1 = this.RadGridInvoice.FilterMenu;
            for (int m = filterMenu.Items.Count - 1; m >= 0; m--)
            {
                if (languageConversion1.Items[m].Text == "Custom")
                {
                    languageConversion1.Items[m].Text = "Custom-Text (ThisWeek)";
                }
                if (languageConversion1.Items[m].Text.ToLower() == "isempty")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "notisempty")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "isnull")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "notisnull")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "between")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "notbetween")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "notequalto")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "greaterthan")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "lessthan")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "greaterthanorequalto")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "lessthanorequalto")
                {
                    languageConversion1.Items[m].Visible = false;
                }
                if (languageConversion1.Items[m].Text.ToLower() == "nofilter")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "contains")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "doesnotcontain")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "startswith")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "endswith")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "equalto")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "greaterthan")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (languageConversion1.Items[m].Text.ToLower() == "lessthan")
                {
                    languageConversion1.Items[m].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
            GridFilterMenu gridFilterMenu1 = this.RadGridOrder.FilterMenu;
            for (int n = filterMenu.Items.Count - 1; n >= 0; n--)
            {
                if (gridFilterMenu1.Items[n].Text == "Custom")
                {
                    gridFilterMenu1.Items[n].Text = "Custom-Text (ThisWeek)";
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "isempty")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "notisempty")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "isnull")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "notisnull")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "between")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "notbetween")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "notequalto")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "greaterthanorequalto")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "lessthanorequalto")
                {
                    gridFilterMenu1.Items[n].Visible = false;
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "nofilter")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("NoFilter");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "contains")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("Contains");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "doesnotcontain")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("DoesNotContain");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "startswith")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("StartsWith");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "endswith")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("EndsWith");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "equalto")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("EqualTo");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "greaterthan")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("GreaterThan");
                }
                if (gridFilterMenu1.Items[n].Text.ToLower() == "lessthan")
                {
                    gridFilterMenu1.Items[n].Text = this.objLanguage.GetLanguageConversion("LessThan");
                }
            }
        }

        protected void OrderclrFilters_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in this.MyOrdergrid.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            this.MyOrdergrid.MasterTableView.FilterExpression = string.Empty;
            this.MyOrdergrid.MasterTableView.Rebind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                myorder.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            DataTable dataTable = ProductBasePage.Setting_SpendLimit_Select(myorder.AccountID, (long)this.CompanyID);
            if (dataTable.Rows.Count <= 0)
            {
                this.IsEnableHidePrice = "false";
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    this.IsEnableHidePrice = row["EnableHidePrice"].ToString().ToLower();
                }
            }
            if (ConnectionClass.SitePath != null)
            {
                this.strSitepath = ConnectionClass.SitePath;
            }
            if (ConnectionClass.FileExtension != null)
            {
                this.FileExtension = ConnectionClass.FileExtension;
            }
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            else if (ConnectionClass.RewriteModule.ToLower() != "on")
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
            }
            else
            {
                base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
            }
            if (myorder.AccountID == (long)0)
            {
                if (ConnectionClass.RewriteModule.ToLower() != "on")
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login.aspx"));
                }
                else
                {
                    base.Response.Redirect(string.Concat(this.strSitepath, "login", ConnectionClass.FileExtension));
                }
            }
            this.IsCampaignEnabled = ProductBasePage.GetCampaign_Enabled(myorder.AccountID);
            this.deptScreenName = base.Return_ApprovalRegistration_Settings("deptscreenname");
            if (this.Session["ApprovalSystem"].ToString() != "on")
            {
                this.RadGridOrder.MasterTableView.GetColumn("Approved").Display = false;
                this.MyOrdergrid.MasterTableView.GetColumn("Approved").Display = false;
                this.radAwaiting.MasterTableView.GetColumn("Approved").Display = false;
                this.radPendingOrder.MasterTableView.GetColumn("Approved").Display = false;
            }
            if (this.IsCampaignEnabled.ToLower() == "false")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CampaignName").Display = false;
                this.RadGridOrder.MasterTableView.GetColumn("SignNumber").Display = false;
                this.MyOrdergrid.MasterTableView.GetColumn("CampaignName").Display = false;
                this.MyOrdergrid.MasterTableView.GetColumn("SignNumber").Display = false;
                this.radAwaiting.MasterTableView.GetColumn("CampaignName").Display = false;
                this.radAwaiting.MasterTableView.GetColumn("SignNumber").Display = false;
                this.radPendingOrder.MasterTableView.GetColumn("CampaignName").Display = false;
                this.radPendingOrder.MasterTableView.GetColumn("SignNumber").Display = false;
            }
            this.PDFFrom = EprintConfigurationManager.AppSettings["PDFFrom"].ToString();
            this.StorePDFTo = EprintConfigurationManager.AppSettings["StorePDFTo"].ToString();
            if (!Directory.Exists(string.Concat(this.StorePDFTo, myorder.AccountID, "/pdf/")))
            {
                Directory.CreateDirectory(string.Concat(this.StorePDFTo, myorder.AccountID, "/pdf/"));
            }
            this.ImagePathFromFrontEnd = EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"].ToString();
            this.ImageFromPath = EprintConfigurationManager.AppSettings["ImageFromPath"].ToString();
            this.ImageToPath = EprintConfigurationManager.AppSettings["ImageToPath"].ToString();
            this.ConnectionString = EprintConfigurationManager.ConnectionStrings["TemplateConnectionString"].ToString();
            this.AllProductsDeletedMSG = this.objLanguage.GetLanguageConversion("All_Products_Deleted_MSG");
            this.ReorderDltdMsg1 = this.objLanguage.GetLanguageConversion("Reorder_Deleted_Msg1");
            this.ReorderDltdMsg2 = this.objLanguage.GetLanguageConversion("Reorder_Deleted_Msg2");
            this.lnkExport_Excel.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnk_Export_Awaiting.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnk_Export_pending.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnkExport_Excel_Invoice.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnkExport_Excel_Job.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            Label label = (Label)base.Master.FindControl("lblPathLink");
            string[] sitePath = new string[] { "<a Class='floatLeft TextUnderline' href ='", BaseClass.SitePath, "account/myorder.aspx' >", this.objLanguage.GetLanguageConversion("Orders"), "</a><span Class='floatLeft'>&nbsp;</span>" };
            label.Text = string.Concat(sitePath);
            this.RadTabStrip1.Tabs[0].Text = this.objLanguage.GetLanguageConversion("Order");
            this.RadTabStrip1.Tabs[1].Text = this.objLanguage.GetLanguageConversion("Job");
            this.RadTabStrip1.Tabs[2].Text = this.objLanguage.GetLanguageConversion("Invoice");
            this.RadTabStrip1.Tabs[3].Text = this.objLanguage.GetLanguageConversion("Pending_Approval");
            this.RadTabStrip1.Tabs[4].Text = this.objLanguage.GetLanguageConversion("Awaiting_Approval");
            this.RadGridJob.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGridJob.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridJob.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("CustomerPO");
            if (this.deptScreenName != "")
            {
                this.RadGridJob.Columns[3].HeaderText = this.deptScreenName;
            }
            else
            {
                this.RadGridJob.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Department_To");
            }
            this.RadGridJob.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridJob.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridJob.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
            this.RadGridJob.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Job_Title");
            this.RadGridJob.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridJob.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.RadGridJob.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridInvoice.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Invoice_Title");
            this.radPendingOrder.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Order_Title");
            this.radAwaiting.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Order_Title");
            this.RadGridInvoice.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.radPendingOrder.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.radAwaiting.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridInvoice.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGridInvoice.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridInvoice.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("CustomerPO");
            if (this.deptScreenName != "")
            {
                this.RadGridInvoice.Columns[3].HeaderText = this.deptScreenName;
            }
            else
            {
                this.RadGridInvoice.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Department_To");
            }
            this.RadGridInvoice.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridInvoice.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridInvoice.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
            this.RadGridInvoice.Columns[7].HeaderText = "Invoice Title";
            this.RadGridInvoice.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridInvoice.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.RadGridInvoice.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridOrder.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGridOrder.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridOrder.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("CustomerPO");
            if (this.deptScreenName != "")
            {
                this.RadGridOrder.Columns[3].HeaderText = this.deptScreenName;
            }
            else
            {
                this.RadGridOrder.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Department_To");
            }
            this.RadGridOrder.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridOrder.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridOrder.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Raised_By");
            this.RadGridOrder.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Job_Name");
            this.RadGridOrder.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Item_Title");
            this.RadGridOrder.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Order_Title");
            this.RadGridOrder.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridOrder.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Sign_Number");
            this.RadGridOrder.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Name");
            this.RadGridOrder.Columns[13].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.RadGridOrder.Columns[14].HeaderText = this.objLanguage.GetLanguageConversion("Approved");
            this.MyOrdergrid.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.MyOrdergrid.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.MyOrdergrid.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.MyOrdergrid.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.MyOrdergrid.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Raised_By");
            this.MyOrdergrid.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.MyOrdergrid.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Sign_Number");
            this.MyOrdergrid.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Name");
            this.MyOrdergrid.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.MyOrdergrid.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Approved");
            this.radPendingOrder.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.radPendingOrder.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            if (this.deptScreenName != "")
            {
                this.radPendingOrder.Columns[2].HeaderText = this.deptScreenName;
            }
            else
            {
                this.radPendingOrder.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Department_To");
            }
            this.radPendingOrder.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.radPendingOrder.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.radPendingOrder.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Raised_By");
            this.radPendingOrder.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.radPendingOrder.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Sign_Number");
            this.radPendingOrder.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Name");
            this.radPendingOrder.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.radPendingOrder.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Approved");
            this.radAwaiting.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.radAwaiting.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            if (this.deptScreenName != "")
            {
                this.radAwaiting.Columns[2].HeaderText = this.deptScreenName;
            }
            else
            {
                this.radAwaiting.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Department_To");
            }
            this.radAwaiting.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.radAwaiting.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.radAwaiting.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Raised_By");
            this.radAwaiting.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.radAwaiting.Columns[9].HeaderText = this.objLanguage.GetLanguageConversion("Sign_Number");
            this.radAwaiting.Columns[10].HeaderText = this.objLanguage.GetLanguageConversion("Campaign_Name");
            this.radAwaiting.Columns[11].HeaderText = this.objLanguage.GetLanguageConversion("Order_Status");
            this.radAwaiting.Columns[12].HeaderText = this.objLanguage.GetLanguageConversion("Approved");
            this.lnkPendingApproval.Text = this.objLanguage.GetLanguageConversion("Clear_All_Filters");
            this.lnlAwatingClearFil.Text = this.objLanguage.GetLanguageConversion("Clear_All_filters");
            this.btnOrderclrFilters.Text = this.objLanguage.GetLanguageConversion("Clear_All_filters");
            this.lnkOrder.Text = this.objLanguage.GetLanguageConversion("Clear_All_Filters");
            this.lnkJob.Text = this.objLanguage.GetLanguageConversion("Clear_All_filters");
            this.lnkInvoice.Text = this.objLanguage.GetLanguageConversion("Clear_All_filters");
            base.Title = commonclass.pageTitle("My Orders", Convert.ToInt32(this.CompanyID), Convert.ToInt32(myorder.AccountID));
            if (this.Session["StoreUserID"] != null && this.Session["StoreUserID"] != null)
            {
                this.UserType = LoginBasePage.UserTypeCheck(Convert.ToInt64(this.Session["StoreUserID"]));
            }
            if (this.Session["EmailID"] != null)
            {
                this.Email = this.Session["EmailID"].ToString();
            }
            if (ConnectionClass.RewriteModule.ToLower() == "on")
            {
                if (RewriteContext.Current.Params["ID"] != null)
                {
                    string str = RewriteContext.Current.Params["ID"].ToString();
                    char[] keySeparator = new char[] { this.KeySeparator };
                    this.orderNo = (long)Convert.ToInt32(str.Split(keySeparator)[1]);
                }
            }
            else if (base.Request.Params["ID"] != null)
            {
                this.orderNo = (long)Convert.ToInt32(base.Request.Params["ID"]);
            }
            if (this.comm.GetDisplayValue("isMyAccount", myorder.AccountID) == "false")
            {
                myorder.isMyAccount = "0";
            }
            if (base.Request.Url.ToString().ToLower().Contains("account/myorder.aspx"))
            {
                this.accountInfoContent_left.Style.Add("display", "block");
            }
            if (!base.IsPostBack)
            {
                if (base.Request.Params["Po"] != null)
                {
                    if (base.Request.Params["Po"].ToString() == "1")
                    {
                        this.RadTabStrip1.Tabs[3].Selected = true;
                        this.RadPageView4.Selected = true;
                        this.DivOrder.Style.Add("display", "none");
                        this.DivAwating.Style.Add("display", "none");
                        this.DivPending.Style.Add("display", "block");
                        this.DivOrder1.Style.Add("display", "none");
                        this.DivJob.Style.Add("display", "none");
                        this.DivInvoice.Style.Add("display", "none");
                    }
                    if (base.Request.Params["Po"].ToString() == "2")
                    {
                        this.RadTabStrip1.Tabs[4].Selected = true;
                        this.RadPageView1.Selected = true;
                        this.DivOrder.Style.Add("display", "none");
                        this.DivAwating.Style.Add("display", "block");
                        this.DivPending.Style.Add("display", "none");
                        this.DivOrder1.Style.Add("display", "none");
                        this.DivJob.Style.Add("display", "none");
                        this.DivInvoice.Style.Add("display", "none");
                    }
                }
                if (this.Session["ApprovalSystem"] != null)
                {
                    if (this.Session["ApprovalSystem"].ToString() != "on")
                    {
                        this.RadTabStrip1.Tabs[3].Visible = false;
                        this.RadTabStrip1.Tabs[4].Visible = true;
                    }
                    else
                    {
                        this.approvalType = base.Return_ApprovalSystem_Settings("approvaltype");
                        if (this.approvalType == "s")
                        {
                            DataSet dataSet = new DataSet();
                            if (OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "awaiting").Tables[0].Rows.Count <= 0)
                            {
                                this.RadTabStrip1.SelectedIndex = 0;
                                this.RadPageView2.Selected = true;
                            }
                            else
                            {
                                this.RadTabStrip1.Tabs[3].Visible = false;
                                this.RadTabStrip1.Tabs[4].Visible = true;
                            }
                        }
                        else if (this.approvalType == "u")
                        {
                            this.RadTabStrip1.Tabs[3].Visible = false;
                            this.RadTabStrip1.Tabs[4].Visible = true;
                        }
                        else
                        {
                            DataSet dataSet1 = new DataSet();
                            dataSet1 = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "pending");
                            DataSet dataSet2 = OrderBasePage.Select_MainOrDepOrUser(this.StoreUserID);
                            if (dataSet2.Tables.Count <= 0)
                            {
                                this.RadTabStrip1.Tabs[3].Visible = false;
                                this.RadTabStrip1.Tabs[4].Visible = true;
                            }
                            else if (dataSet2.Tables[0].Rows.Count <= 0 && dataSet2.Tables[1].Rows.Count <= 0 && dataSet2.Tables[2].Rows.Count <= 0 && dataSet2.Tables[3].Rows.Count <= 0)
                            {
                                this.RadTabStrip1.Tabs[3].Visible = false;
                                this.RadTabStrip1.Tabs[4].Visible = true;
                            }
                            else if (dataSet1.Tables[0].Rows.Count <= 0)
                            {
                                this.RadTabStrip1.SelectedIndex = 0;
                                this.RadPageView2.Selected = true;
                            }
                            else
                            {
                                this.RadTabStrip1.Tabs[3].Visible = true;
                                this.RadTabStrip1.Tabs[4].Visible = false;
                            }
                        }
                    }
                }
            }
            if (base.Request.Params["Type"] != null)
            {
                if (base.Request.Params["Type"].ToString() == "approve")
                {
                    this.divMsg.Style.Add("display", "block");
                    this.lblSucess.Text = "Order approved successfully";
                    this.imgSucess.Style.Add("display", "block");
                }
                else if (base.Request.Params["Type"].ToString() == "reject")
                {
                    this.divMsg.Style.Add("display", "block");
                    this.lblSucess.Text = "Order rejected successfully";
                    this.imgSucess.Style.Add("display", "block"); 
                }
            }
            
            this.RadGridJob.MasterTableView.Columns[11].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridJob.MasterTableView.Columns[12].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridInvoice.MasterTableView.Columns[11].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridInvoice.MasterTableView.Columns[12].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridOrder.MasterTableView.Columns[15].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.RadGridOrder.MasterTableView.Columns[16].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.MyOrdergrid.MasterTableView.Columns[11].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.MyOrdergrid.MasterTableView.Columns[12].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.radPendingOrder.Columns[13].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.radPendingOrder.Columns[14].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.radAwaiting.Columns[13].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");
            this.radAwaiting.Columns[14].HeaderText = string.Concat(this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket"), " (", this.comm.GetCurrencyinRequiredFormate("", true), ")");

            foreach (DataRow row in ProductBasePage.default_price_for_pack_select(this.CompanyID).Rows)
            {
                customDatetitle1 = row["DefaultCustomDateTitle1"].ToString();
                customDatetitle2 = row["DefaultCustomDateTitle2"].ToString();
                customDatetitle3 = row["DefaultCustomDateTitle3"].ToString();
                customDatetitle4 = row["DefaultCustomDateTitle4"].ToString();
                customDatetitle5 = row["DefaultCustomDateTitle5"].ToString();
            }

            // For RadGridJob
            this.RadGridJob.MasterTableView.Columns[13].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
            this.RadGridJob.MasterTableView.Columns[14].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
            this.RadGridJob.MasterTableView.Columns[15].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
            this.RadGridJob.MasterTableView.Columns[16].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
            this.RadGridJob.MasterTableView.Columns[17].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
            this.RadGridJob.MasterTableView.Columns[18].HeaderText = "Proof Status";


            // For RadGridInvoice
            this.RadGridInvoice.MasterTableView.Columns[13].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
            this.RadGridInvoice.MasterTableView.Columns[14].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
            this.RadGridInvoice.MasterTableView.Columns[15].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
            this.RadGridInvoice.MasterTableView.Columns[16].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
            this.RadGridInvoice.MasterTableView.Columns[17].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
       

            // For RadGridOrder
            this.RadGridOrder.MasterTableView.Columns[17].HeaderText = string.IsNullOrEmpty(customDatetitle1) ? "Custom Date 1" : customDatetitle1;
            this.RadGridOrder.MasterTableView.Columns[18].HeaderText = string.IsNullOrEmpty(customDatetitle2) ? "Custom Date 2" : customDatetitle2;
            this.RadGridOrder.MasterTableView.Columns[19].HeaderText = string.IsNullOrEmpty(customDatetitle3) ? "Custom Date 3" : customDatetitle3;
            this.RadGridOrder.MasterTableView.Columns[20].HeaderText = string.IsNullOrEmpty(customDatetitle4) ? "Custom Date 4" : customDatetitle4;
            this.RadGridOrder.MasterTableView.Columns[21].HeaderText = string.IsNullOrEmpty(customDatetitle5) ? "Custom Date 5" : customDatetitle5;
            this.RadGridOrder.MasterTableView.Columns[22].HeaderText = "Job Status";
            this.RadGridOrder.MasterTableView.Columns[23].HeaderText = "Proof Status";





            if (this.comm.GetDisplayValue("isCheckDeliveryRequiredBy", myorder.AccountID) != "true")
            {
                this.RadGridJob.Columns[4].Visible = false;
                this.RadGridInvoice.Columns[4].Visible = false;
                this.RadGridOrder.Columns[4].Visible = false;
                this.MyOrdergrid.Columns[3].Visible = false;
                this.radPendingOrder.Columns[4].Visible = false;
                this.radAwaiting.Columns[3].Visible = false;
            }
            else
            {
                this.RadGridJob.Columns[4].Visible = true;
                this.RadGridInvoice.Columns[4].Visible = true;
                this.RadGridOrder.Columns[4].Visible = true;
                this.MyOrdergrid.Columns[3].Visible = true;
                this.radPendingOrder.Columns[4].Visible = true;
                this.radAwaiting.Columns[3].Visible = true;
            }
            DataTable dataTable1 = OrderBasePage.OrderMangerOptions_Select(Convert.ToInt32(this.CompanyID), Convert.ToInt32(myorder.AccountID));
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                if (Convert.ToBoolean(dataRow["IsHideMISJob"]))
                {
                    this.RadTabStrip1.Tabs[1].Visible = false;
                }
                else
                {
                    this.RadTabStrip1.Tabs[1].Visible = true;
                    this.IsHideMISJobVisible = true;
                }
                if (Convert.ToBoolean(dataRow["IsHideMISInvoice"]))
                {
                    this.RadTabStrip1.Tabs[2].Visible = false;
                }
                else
                {
                    this.RadTabStrip1.Tabs[2].Visible = true;
                    this.IsHideMISInvoiceVisible = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_Only_User_Jobs"]))
                {
                    this.Is_Only_User_Jobs = false;
                }
                if (!Convert.ToBoolean(dataRow["Is_Only_User_DepartmentJobs"]))
                {
                    this.Is_Only_User_DepartmentJobs = false;
                }
                else
                {
                    this.Is_Only_User_DepartmentJobs = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_User_All_Jobs"]))
                {
                    this.Is_User_All_Jobs = false;
                }
                else
                {
                    this.Is_User_All_Jobs = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_only_User_Invoice"]))
                {
                    this.Is_only_User_Invoice = false;
                }
                if (!Convert.ToBoolean(dataRow["Is_only_user_DepartmentInvoice"]))
                {
                    this.Is_only_user_DepartmentInvoice = false;
                }
                else
                {
                    this.Is_only_user_DepartmentInvoice = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_User_All_Invoice"]))
                {
                    this.Is_User_All_Invoice = false;
                }
                else
                {
                    this.Is_User_All_Invoice = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_Only_User_Orders"]))
                {
                    this.Is_Only_User_Orders = false;
                }
                if (!Convert.ToBoolean(dataRow["Is_Only_User_DepartmentOrders"]))
                {
                    this.Is_Only_User_DepartmentOrders = false;
                }
                else
                {
                    this.Is_Only_User_DepartmentOrders = true;
                }
                if (!Convert.ToBoolean(dataRow["Is_User_All_Orders"]))
                {
                    this.Is_User_All_Orders = false;
                }
                else
                {
                    this.Is_User_All_Orders = true;
                }
            }
            if (this.IsEnableHidePrice == "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("TotalPrice").Display = false;
                this.RadGridOrder.MasterTableView.GetColumn("FinalPrice").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("TotalPrice").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("FinalPrice").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("TotalPrice").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("FinalPrice").Display = false;
                this.radPendingOrder.MasterTableView.GetColumn("TotalPrice").Display = false;
                this.radPendingOrder.MasterTableView.GetColumn("FinalPrice").Display = false;
                this.radAwaiting.MasterTableView.GetColumn("TotalPrice").Display = false;
                this.radAwaiting.MasterTableView.GetColumn("FinalPrice").Display = false;
            }

            // isDepartment
            if (this.comm.GetDisplayValue("isDepartment", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("Department").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("Department").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("Department").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("Department").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("Department").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("Department").Display = true;
            }

            // isRaisedBy
            if (this.comm.GetDisplayValue("isRaisedBy", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderedFor").Display = false;
                //this.RadGridJob.MasterTableView.GetColumn("OrderedFor").Display = false;
                //this.RadGridInvoice.MasterTableView.GetColumn("OrderedFor").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderedFor").Display = true;
                //this.RadGridJob.MasterTableView.GetColumn("OrderedFor").Display = true;
                //this.RadGridInvoice.MasterTableView.GetColumn("OrderedFor").Display = true;
            }

            // isOrderStatus
            if (this.comm.GetDisplayValue("isOrderStatus", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderStatus").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("OrderStatus").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("OrderStatus").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderStatus").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("OrderStatus").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("OrderStatus").Display = true;
            }

            // isJobName
            if (this.comm.GetDisplayValue("isJobName", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("JobName").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("JobName").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("JobName").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("JobName").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("JobName").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("JobName").Display = true;
            }

            // isDeliveryDate
            if (this.comm.GetDisplayValue("isDeliveryDate", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("RequiredBy").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("RequiredBy").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("RequiredBy").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("RequiredBy").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("RequiredBy").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("RequiredBy").Display = true;
            }

            // isRaisedDate
            if (this.comm.GetDisplayValue("isRaisedDate", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderDate").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("OrderDate").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("OrderDate").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("OrderDate").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("OrderDate").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("OrderDate").Display = true;
            }

            // isCustomDate1
            if (this.comm.GetDisplayValue("isCustomDate1", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate1").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate1").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate1").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate1").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate1").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate1").Display = true;
            }

            // isCustomDate2
            if (this.comm.GetDisplayValue("isCustomDate2", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate2").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate2").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate2").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate2").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate2").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate2").Display = true;
            }

            // isCustomDate3
            if (this.comm.GetDisplayValue("isCustomDate3", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate3").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate3").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate3").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate3").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate3").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate3").Display = true;
            }

            // isCustomDate4
            if (this.comm.GetDisplayValue("isCustomDate4", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate4").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate4").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate4").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate4").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate4").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate4").Display = true;
            }

            // isCustomDate5
            if (this.comm.GetDisplayValue("isCustomDate5", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate5").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate5").Display = false;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate5").Display = false;
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("CustomDate5").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("CustomDate5").Display = true;
                this.RadGridInvoice.MasterTableView.GetColumn("CustomDate5").Display = true;
            }

            
            if (this.comm.GetDisplayValue("isJobStatus", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("JobStatus").Display = false;
             
            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("JobStatus").Display = true;
            
            }

            if (this.comm.GetDisplayValue("isProofStatus", myorder.AccountID) != "true")
            {
                this.RadGridOrder.MasterTableView.GetColumn("ProofStatus").Display = false;
                this.RadGridJob.MasterTableView.GetColumn("ProofStatus").Display = false;

            }
            else
            {
                this.RadGridOrder.MasterTableView.GetColumn("ProofStatus").Display = true;
                this.RadGridJob.MasterTableView.GetColumn("ProofStatus").Display = true;

            }





        }

        protected void radAwaiting_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)this.Session["searchJobs"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchJobs"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "awaiting");
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
                this.radAwaiting.Rebind();
            }
        }

        protected void radAwaiting_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataSet dataSet = new DataSet();
            dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "awaiting");
            dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
            dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
            dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["OrderStatus"] = base.SpecialDecode(row["OrderStatus"].ToString());
                if (this.deptScreenName != "")
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString()).Replace("[Department]", string.Concat("[", this.deptScreenName, "]"));
                }
                else
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString());
                }
                row["AttentionFor"] = base.SpecialDecode(row["AttentionFor"].ToString());
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString());
            }
            this.radAwaiting.DataSource = dataSet.Tables[0];
            myorder.Dt_awaiting = dataSet.Tables[0];
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.RadTabStrip1.Tabs[4].Visible = true;
                this.radAwaiting.AllowPaging = true;
                return;
            }
            this.RadTabStrip1.Tabs[4].Visible = false;
            this.radAwaiting.AllowPaging = false;
        }

        protected void radAwaitingOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string str = "order";
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderDate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["RequiredBy"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["SignNumber"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("div_atnfor");
                if (((Label)e.Item.FindControl("lbl_forattn")).Text != "")
                {
                    htmlControl.Style.Add("display", "block");
                }
                LinkButton linkButton = (LinkButton)e.Item.FindControl("Lnk_ReorderIcon");
                if (dataItem["IsFromWebstore"].ToString().ToLower() == "yes")
                {
                    linkButton.Visible = true;
                }
                if (dataItem["Approved"].ToString().ToLower() == "no")
                {
                    string[] fileExtension = new string[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", dataItem["ProductID"].ToString(), "&CartItemID=", dataItem["CartItemID"].ToString(), "&OrdKey=", dataItem["OrderKey"].ToString() };
                    string str1 = string.Concat(fileExtension);
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plheditImage")).Controls;
                    object[] accountID = new object[] { "<a href=", str1, "><img id='img_Edit' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(accountID)));
                }
                if (CartBasePage.ArtworkFile_Cart_Order_Select(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"]), Convert.ToInt64(dataItem["OrderID"]), "order").Rows.Count > 0)
                {
                    ControlCollection controlCollections = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick=javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",", dataItem["OrderID"], ",'", str, "') class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                }
                Label label = (Label)e.Item.FindControl("lblTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.radAwaiting.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridInvoice_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)this.Session["searchJobs"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchJobs"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataTable dataTable1 = new DataTable();
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "invoice", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
                dataTable1 = dataSet.Tables[0];
                if (dataTable1.Rows.Count > 0)
                {
                    dataTable1.Columns["RequiredBy"].ReadOnly = false;
                    dataTable1.Columns["OrderDate"].ReadOnly = false;
                }
                foreach (DataRow row in dataTable1.Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridInvoice.Rebind();
            }
        }

        protected void RadGridInvoice_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            string str = "invoice";
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderDate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["RequiredBy"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_InvoiceKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_InvoiceCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                if (CartBasePage.JobInvoice_ArtworkFile_Select_splititem(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"])).Rows.Count > 0)
                {
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick=javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",'", dataItem["OrderKey"], "','", str, "') class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                Label label = (Label)e.Item.FindControl("lbl_InvoiceTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lbl_InvoiceFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
                Label red = (Label)e.Item.FindControl("lbl_InvoiceStatus");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("img_invocieReject");
                if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && dataItem["IsRejected"].ToString().ToLower() == "true")
                {
                    imageButton.Visible = false;
                    red.Text = "Rejected";
                    red.ForeColor = Color.Red;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGridInvoice.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGridInvoice.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridInvoice_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (!(e.RebindReason == GridRebindReason.InitialLoad))
            {
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "invoice", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
            }
            if (dataSet.Tables.Count > 0)
            {
                dataTable = dataSet.Tables[0];
            }
            if (dataTable.Rows.Count > 0)
            {
                dataTable.Columns["RequiredBy"].ReadOnly = false;
                dataTable.Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["OrderStatus"] = base.SpecialDecode(row["OrderStatus"].ToString());
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString());
                row["CustomDate1"] = String.IsNullOrEmpty(row["CustomDate1"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate2"] = String.IsNullOrEmpty(row["CustomDate2"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate3"] = String.IsNullOrEmpty(row["CustomDate3"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate4"] = String.IsNullOrEmpty(row["CustomDate4"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate5"] = String.IsNullOrEmpty(row["CustomDate5"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);

            }
            this.RadGridInvoice.DataSource = dataTable;
            myorder.Dt_Invoice = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridInvoice.AllowPaging = true;
                return;
            }
            this.RadGridInvoice.AllowPaging = false;
        }

        protected void RadGridJob_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)this.Session["searchJobs"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchJobs"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataTable dataTable1 = new DataTable();
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "job", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
                dataTable1 = dataSet.Tables[0];
                if (dataTable1.Rows.Count > 0)
                {
                    dataTable1.Columns["RequiredBy"].ReadOnly = false;
                    dataTable1.Columns["OrderDate"].ReadOnly = false;
                }
                foreach (DataRow row in dataTable1.Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridJob.Rebind();
            }
        }

        protected void RadGridJob_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            string str = "job";
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderDate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["RequiredBy"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_JobKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_JobCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                if (CartBasePage.JobInvoice_ArtworkFile_Select_splititem(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"])).Rows.Count > 0)
                {
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick=javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",'", dataItem["OrderKey"].ToString(), "','", str, "') class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                Label label = (Label)e.Item.FindControl("lbl_jobTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lbl_JobFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
                Label red = (Label)e.Item.FindControl("lbl_JobStatus");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("img_JobReject");
                if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && dataItem["IsRejected"].ToString().ToLower() == "true")
                {
                    imageButton.Visible = false;
                    red.Text = "Rejected";
                    red.ForeColor = Color.Red;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                GridTableView masterTableView = this.RadGridJob.MasterTableView;
                GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                this.RadGridJob.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridJob_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (!(e.RebindReason == GridRebindReason.InitialLoad))
            {
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "job", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
            }
            if (dataSet.Tables.Count > 0)
            {
                dataTable = dataSet.Tables[0];
            }
            if (dataTable.Columns.Count > 0)
            {
                dataTable.Columns["RequiredBy"].ReadOnly = false;
                dataTable.Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["OrderStatus"] = base.SpecialDecode(row["OrderStatus"].ToString());
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString());
                row["CustomDate1"] = String.IsNullOrEmpty(row["CustomDate1"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate2"] = String.IsNullOrEmpty(row["CustomDate2"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate3"] = String.IsNullOrEmpty(row["CustomDate3"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate4"] = String.IsNullOrEmpty(row["CustomDate4"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate5"] = String.IsNullOrEmpty(row["CustomDate5"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["ProofStatus"] = base.SpecialDecode(row["ProofStatus"].ToString());
            }
            this.RadGridJob.DataSource = dataTable;
            myorder.Dt_Jobs = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridJob.AllowPaging = true;
                return;
            }
            this.RadGridJob.AllowPaging = false;
        }

        protected void RadGridOrder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchOrder"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchOrder"] != null)
                {
                    dataTable = (DataTable)this.Session["searchOrder"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchOrder"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataTable dataTable1 = new DataTable();
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "order", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
                dataTable1 = dataSet.Tables[0];
                if (dataTable1.Rows.Count > 0)
                {
                    dataTable1.Columns["RequiredBy"].ReadOnly = false;
                    dataTable1.Columns["OrderDate"].ReadOnly = false;
                }
                foreach (DataRow row in dataTable1.Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridOrder.Rebind();
            }
        }

        protected void RadGridOrder_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            string str = "order";
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderDate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["RequiredBy"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["SignNumber"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdn_OrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdn_CreatedBy");
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("div_atnfor");
                if (((Label)e.Item.FindControl("lbl_forattn")).Text != "")
                {
                    htmlControl.Style.Add("display", "block");
                }
                if (dataItem["Approved"].ToString().ToLower() == "no")
                {
                    string[] fileExtension = new string[] { this.strSitepath, "products/productdetails", ConnectionClass.FileExtension, "?ID=", dataItem["ProductID"].ToString(), "&CartItemID=", dataItem["CartItemID"].ToString(), "&OrdKey=", dataItem["OrderKey"].ToString() };
                    string str1 = string.Concat(fileExtension);
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plheditImage")).Controls;
                    object[] accountID = new object[] { "<a href=", str1, "><img id='img_Edit' class='Atatchments WS_Cursor_Style' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Edit.gif&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Edit' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(accountID)));
                }
                if (CartBasePage.ArtworkFile_Cart_Order_Select(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"]), Convert.ToInt64(dataItem["OrderID"]), "order").Rows.Count > 0)
                {
                    ControlCollection controlCollections = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick=javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",", dataItem["OrderID"], ",'", str, "') class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray)));
                }
                //Label labelCustomerPO = (Label)e.Item.FindControl("lbl_CustomerPO");
                //labelCustomerPO.Text = "Test";

                this.SumofTotalPrice = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(this.TotalExcPrice), 2, "", false, false, true);
                this.SumofFinalPrice = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(this.TotalIncPrice), 2, "", false, false, true);
                Convert.ToInt32(hiddenField1.Value);
                Label label = (Label)e.Item.FindControl("lbl_OrderTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lbl_OrderFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
                LinkButton linkButton = (LinkButton)e.Item.FindControl("Lnk_Reorder");
                if (dataItem["IsFromWebstore"].ToString().ToLower() == "yes" && dataItem["EstimateType"].ToString().ToLower() == "x")
                {
                    linkButton.Visible = true;
                }
                Label red = (Label)e.Item.FindControl("lbl_OrderStatus");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("img_OrderReject");
                if (this.Session["ApprovalSystem"] != null && this.Session["ApprovalSystem"].ToString() == "on" && dataItem["IsRejected"].ToString().ToLower() == "true")
                {
                    imageButton.Visible = false;
                    red.Text = "Rejected";
                    red.ForeColor = Color.Red;
                }
                if (e.Item is GridPagerItem)
                {
                    Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                    languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                    GridTableView masterTableView = this.RadGridOrder.MasterTableView;
                    GridItemType[] gridItemTypeArray = new GridItemType[] { GridItemType.Pager };
                    GridPagerItem items = (GridPagerItem)masterTableView.GetItems(gridItemTypeArray)[0];
                    this.RadGridOrder.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
                }
            }
        }

        protected void RadGridOrder_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            dataSet = OrderBasePage.Select_B2B_Orders_ByItems(this.StoreUserID, this.WhereCondition, "order", this.Is_Only_User_Jobs, this.Is_Only_User_DepartmentJobs, this.Is_User_All_Jobs, this.Is_only_User_Invoice, this.Is_only_user_DepartmentInvoice, this.Is_User_All_Invoice, this.Is_Only_User_Orders, this.Is_Only_User_DepartmentOrders, this.Is_User_All_Orders);
            dataTable = dataSet.Tables[0];
            if (dataTable.Columns.Count > 0)
            {
                dataTable.Columns["RequiredBy"].ReadOnly = false;
                dataTable.Columns["OrderDate"].ReadOnly = false;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["OrderStatus"] = base.SpecialDecode(row["OrderStatus"].ToString());
                row["CustomDate1"] = String.IsNullOrEmpty(row["CustomDate1"].ToString())?"---":this.comm.Eprint_return_Date_Before_View(row["CustomDate1"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate2"] = String.IsNullOrEmpty(row["CustomDate2"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate2"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate3"] = String.IsNullOrEmpty(row["CustomDate3"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate3"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate4"] = String.IsNullOrEmpty(row["CustomDate4"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate4"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["CustomDate5"] = String.IsNullOrEmpty(row["CustomDate5"].ToString()) ? "---" : this.comm.Eprint_return_Date_Before_View(row["CustomDate5"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["JobStatus"] = base.SpecialDecode(row["JobStatus"].ToString());
                row["ProofStatus"] = base.SpecialDecode(row["ProofStatus"].ToString());
                if (this.deptScreenName != "")
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString()).Replace("[Department]", string.Concat("[", this.deptScreenName, "]"));
                }
                else
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString());
                }
                row["AttentionFor"] = base.SpecialDecode(row["AttentionFor"].ToString());
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString());
            }
            this.RadGridOrder.DataSource = dataTable;
            myorder.Dt_Orders = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridOrder.AllowPaging = true;
                return;
            }
            this.RadGridOrder.AllowPaging = false;
        }

        protected void radPendingOrder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DataTable dataTable = new DataTable();
            if (e.CommandName == "Filter")
            {
                Pair commandArgument = (Pair)e.CommandArgument;
                string str = commandArgument.Second.ToString();
                TextBox item = (e.Item as GridFilteringItem)[str].Controls[0] as TextBox;
                item.Text = this.objBc.ReplaceSingleQuote(item.Text);
                this.WhereCondition = "";
                if (this.Session["searchJobs"] == null)
                {
                    dataTable.Columns.Add("ColumnName");
                    dataTable.Columns.Add("Filter");
                    dataTable.Columns.Add("FilterText");
                }
                if (this.Session["searchJobs"] != null)
                {
                    dataTable = (DataTable)this.Session["searchJobs"];
                }
                DataRow[] dataRowArray = dataTable.Select(string.Concat("ColumnName='", commandArgument.Second.ToString(), "'"));
                if ((int)dataRowArray.Length <= 0)
                {
                    object[] second = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                    dataTable.Rows.Add(second);
                }
                else
                {
                    dataTable.Rows.Remove(dataRowArray[0]);
                    if (commandArgument.First.ToString().ToLower() != "nofilter")
                    {
                        object[] objArray = new object[] { commandArgument.Second, commandArgument.First, item.Text };
                        dataTable.Rows.Add(objArray);
                    }
                }
                this.Session["searchJobs"] = dataTable;
                this.WhereCondition = this.FilterFunction(dataTable);
                DataSet dataSet = new DataSet();
                dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "pending");
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
                dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
                dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
                this.radPendingOrder.Rebind();
            }
        }

        protected void radPendingOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string str = "order";
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["OrderDate"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["RequiredBy"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item is GridFilteringItem)
            {
                ((GridFilteringItem)e.Item)["SignNumber"].HorizontalAlign = HorizontalAlign.Center;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                HtmlControl htmlControl = (HtmlControl)e.Item.FindControl("div_atnfor");
                if (((Label)e.Item.FindControl("lbl_forattn")).Text != "")
                {
                    htmlControl.Style.Add("display", "block");
                }
                if (CartBasePage.ArtworkFile_Cart_Order_Select(Convert.ToInt64(dataItem["CartItemID"]), Convert.ToInt64(dataItem["OrderItemID"]), Convert.ToInt64(dataItem["OrderID"]), "order").Rows.Count > 0)
                {
                    ControlCollection controls = ((PlaceHolder)e.Item.FindControl("plhAttachments")).Controls;
                    object[] objArray = new object[] { "<a ><img id='img_atachments' onclick=javascript:openArtworkPopup(", dataItem["CartItemID"].ToString(), ",", dataItem["OrderItemID"].ToString(), ",", dataItem["OrderID"], ",'", str, "') ' class='Atatchments WS_Cursor_Style floatLeft' src='", this.strSitepath, "ImageHandler.ashx?ImageName=Artworkicon.PNG&amp;type=r&amp;aid=", myorder.AccountID, "&amp;cid=", this.CompanyID, "' title='Artwork Item' alt=' '/></a>" };
                    controls.Add(new LiteralControl(string.Concat(objArray)));
                }
                Label label = (Label)e.Item.FindControl("lblTotalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblFinalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.radPendingOrder.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void radPendingOrder_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataSet dataSet = new DataSet();
            dataSet = OrderBasePage.Select_B2B_Pending_Orders_By_Item(this.Email, this.StoreUserID, this.WhereCondition, "pending");
            dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
            dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            dataSet.Tables[0].Columns["RequiredBy"].ReadOnly = false;
            dataSet.Tables[0].Columns["OrderDate"].ReadOnly = false;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["OrderStatus"] = base.SpecialDecode(row["OrderStatus"].ToString());
                if (this.deptScreenName != "")
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString()).Replace("[Department]", string.Concat("[", this.deptScreenName, "]"));
                }
                else
                {
                    row["OrderedFor"] = base.SpecialDecode(row["OrderedFor"].ToString());
                }
                row["OrderItemTitle"] = base.SpecialDecode(row["OrderItemTitle"].ToString());
            }
            this.radPendingOrder.DataSource = dataSet.Tables[0];
            myorder.Dt_Pending = dataSet.Tables[0];
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.radPendingOrder.AllowPaging = true;
                return;
            }
            this.RadTabStrip1.Tabs[3].Visible = false;
            this.radPendingOrder.AllowPaging = false;
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (this.RadTabStrip1.SelectedIndex == 0)
            {
                this.RadGridOrder.Rebind();
                this.RadGridOrder.Visible = true;
                this.DivOrder.Style.Add("display", "none");
                this.DivAwating.Style.Add("display", "none");
                this.DivPending.Style.Add("display", "none");
                this.DivOrder1.Style.Add("display", "block");
                this.DivJob.Style.Add("display", "none");
                this.DivInvoice.Style.Add("display", "none");
                this.divMsg.Style.Add("display", "none");
                this.lnkOrderFilters_Click(null, null);
            }
            if (this.RadTabStrip1.SelectedIndex == 1)
            {
                this.RadGridJob.Visible = true;
                this.RadGridOrder.Visible = false;
                this.RadGridInvoice.Visible = false;
                this.DivOrder.Style.Add("display", "none");
                this.DivAwating.Style.Add("display", "none");
                this.DivPending.Style.Add("display", "none");
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "block");
                this.DivInvoice.Style.Add("display", "none");
                this.divMsg.Style.Add("display", "none");
                this.lnkJobFilters_Click(null, null);
            }
            if (this.RadTabStrip1.SelectedIndex == 2)
            {
                this.RadGridInvoice.Visible = true;
                this.RadGridJob.Visible = false;
                this.RadGridOrder.Visible = false;
                this.DivOrder.Style.Add("display", "none");
                this.DivAwating.Style.Add("display", "none");
                this.DivPending.Style.Add("display", "none");
                this.DivInvoice.Style.Add("display", "block");
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "none");
                this.divMsg.Style.Add("display", "none");
                this.lnkInvoiceFilters_Click(null, null);
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 3)
            {
                this.RadPageView4.Selected = true;
                this.radPendingOrder.Visible = true;
                this.MyOrdergrid.Visible = false;
                this.radPendingOrder.Rebind();
                this.DivOrder.Style.Add("display", "none");
                this.DivAwating.Style.Add("display", "none");
                this.DivPending.Style.Add("display", "block");
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "none");
                this.DivInvoice.Style.Add("display", "none");
                this.lnkPendingApproval_Click(null, null);
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 4)
            {
                this.RadPageView1.Selected = true;
                this.RadTabStrip1.Tabs[4].Visible = true;
                this.radAwaiting.Rebind();
                this.DivOrder.Style.Add("display", "none");
                this.DivAwating.Style.Add("display", "block");
                this.DivPending.Style.Add("display", "none");
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "none");
                this.DivInvoice.Style.Add("display", "none");
                this.divMsg.Style.Add("display", "none");
                this.lnlAwatingClearFil_Click(null, null);
            }
        }
    }
}