using nmsCommon;
using nmsConnection;
using nmsLanguage;
using Printcenter.UI.CatrsNew;
using Printcenter.UI.OrdersNew;
using Printcenter.UI.Products;
using RewriteModule;

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.GridExcelBuilder;

namespace ePrint.MyPublicStore.account
{
    public partial class myorder : BaseClass, IRequiresSessionState
    {
        //protected RadScriptManager RadScriptManager1;

        //protected RadAjaxManager RadAjaxManager1;

        //protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

        //protected Label lbl_home;

        //protected Label lbl_spliter;

        //protected usercontrols_account_leftpanel account_panel1;

        //protected RadTabStrip RadTabStrip1;

        //protected Label lbl_noOrders;

        //protected HtmlGenericControl order_content;

        //protected LinkButton btnOrderclrFilters;

        //protected LinkButton lnkbtnExport_Order;

        //protected ImageButton btnExport_Order;

        //protected HtmlGenericControl DivOrder1;

        //protected LinkButton lnkbtnExport_Job;

        //protected ImageButton btnExport_Job;

        //protected HtmlGenericControl DivJob;

        //protected LinkButton lnkbtnExport_Invoice;

        //protected ImageButton btnExport_Invoice;

        //protected HtmlGenericControl DivInvoice;

        //protected ImageButton btnExport_All;

        //protected HtmlGenericControl DivOrder;

        //protected HtmlGenericControl order_content_table;

        //protected RadGrid RadGridOrder;

        //protected RadPageView RadPageView2;

        //protected RadGrid RadGridJob;

        //protected RadPageView RadPageView5;

        //protected RadGrid RadGridInvoice;

        //protected RadPageView RadPageView6;

        //protected RadGrid MyOrdergrid;

        //protected RadPageView RadPageView4;

        //protected RadMultiPage RadMultiPage2;

        public commonclass comm = new commonclass();

        public languageClass objLanguage = new languageClass();

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

        private string CartItemID = "0";

        private string TemplateID = string.Empty;

        private static DataTable Dt_Orders;

        private static DataTable Dt_Jobs;

        private static DataTable Dt_Invoice;

        private static DataTable Dt_AllData;

        private string WhereCondition = string.Empty;

        private BaseClass objBc = new BaseClass();

        public int UserID;

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
        }

        public myorder()
        {
        }

        public void btnExportAll_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                myorder.Dt_AllData = OrderBasePage.Select_Orders_reeng(this.StoreUserID, this.WhereCondition);
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
            if (myorder.Dt_AllData.Columns[3].ColumnName == "quantity")
            {
                myorder.Dt_AllData.Columns[3].ColumnName = "Qty";
            }
            if (myorder.Dt_AllData.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_AllData.Columns[4].ColumnName = "Title";
            }
            if (myorder.Dt_AllData.Columns[5].ColumnName == "orderStatus")
            {
                myorder.Dt_AllData.Columns[5].ColumnName = "Status";
            }
            if (myorder.Dt_AllData.Columns[6].ColumnName == "TotalPrice")
            {
                myorder.Dt_AllData.Columns[6].ColumnName = "Price Exc. Tax";
            }
            if (myorder.Dt_AllData.Columns[7].ColumnName == "FinalPrice")
            {
                myorder.Dt_AllData.Columns[7].ColumnName = "Price Inc. Tax";
            }
            DataTable dtAllData = myorder.Dt_AllData;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            this.ExportData(dtAllData, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
        }

        public void btnExportInvoice_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "invoice", this.WhereCondition);
                myorder.Dt_Invoice = dataTable;
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
            if (myorder.Dt_Invoice.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Invoice.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Invoice.Columns[1].ColumnName == "OrderDate")
            {
                myorder.Dt_Invoice.Columns[1].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Invoice.Columns[2].ColumnName == "RequiredBy")
            {
                myorder.Dt_Invoice.Columns[2].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Invoice.Columns[3].ColumnName == "quantity")
            {
                myorder.Dt_Invoice.Columns[3].ColumnName = "Qty";
            }
            if (myorder.Dt_Invoice.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_Invoice.Columns[4].ColumnName = "Title";
            }
            if (myorder.Dt_Invoice.Columns[5].ColumnName == "orderStatus")
            {
                myorder.Dt_Invoice.Columns[5].ColumnName = "Status";
            }
            if (myorder.Dt_Invoice.Columns[6].ColumnName == "TotalPrice")
            {
                myorder.Dt_Invoice.Columns[6].ColumnName = "Price Exc. Tax";
            }
            if (myorder.Dt_Invoice.Columns[7].ColumnName == "FinalPrice")
            {
                myorder.Dt_Invoice.Columns[7].ColumnName = "Price Inc. Tax";
            }
            DataTable dtInvoice = myorder.Dt_Invoice;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            this.ExportData(dtInvoice, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
        }

        public void btnExportJob_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "order", this.WhereCondition);
                myorder.Dt_Jobs = dataTable;
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
            if (myorder.Dt_Jobs.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Jobs.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Jobs.Columns[1].ColumnName == "OrderDate")
            {
                myorder.Dt_Jobs.Columns[1].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Jobs.Columns[2].ColumnName == "RequiredBy")
            {
                myorder.Dt_Jobs.Columns[2].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Jobs.Columns[3].ColumnName == "quantity")
            {
                myorder.Dt_Jobs.Columns[3].ColumnName = "Qty";
            }
            if (myorder.Dt_Jobs.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_Jobs.Columns[4].ColumnName = "Title";
            }
            if (myorder.Dt_Jobs.Columns[5].ColumnName == "orderStatus")
            {
                myorder.Dt_Jobs.Columns[5].ColumnName = "Status";
            }
            if (myorder.Dt_Jobs.Columns[6].ColumnName == "TotalPrice")
            {
                myorder.Dt_Jobs.Columns[6].ColumnName = "Price Exc. Tax";
            }
            if (myorder.Dt_Jobs.Columns[7].ColumnName == "FinalPrice")
            {
                myorder.Dt_Jobs.Columns[7].ColumnName = "Price Inc. Tax";
            }
            DataTable dtJobs = myorder.Dt_Jobs;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            this.ExportData(dtJobs, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
        }

        public void btnExportOrder_OnClick(object sender, EventArgs e)
        {
            if (this.WhereCondition != "")
            {
                DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "order", this.WhereCondition);
                myorder.Dt_Orders = dataTable;
            }
            if (myorder.Dt_Orders.Columns.Contains("OrderID"))
            {
                myorder.Dt_Orders.Columns.Remove("OrderID");
            }
            if (myorder.Dt_Orders.Columns.Contains("OrderKey"))
            {
                myorder.Dt_Orders.Columns.Remove("OrderKey");
            }
            if (myorder.Dt_Orders.Columns.Contains("StoreUserID"))
            {
                myorder.Dt_Orders.Columns.Remove("StoreUserID");
            }
            if (myorder.Dt_Orders.Columns.Contains("AccountID"))
            {
                myorder.Dt_Orders.Columns.Remove("AccountID");
            }
            if (myorder.Dt_Orders.Columns.Contains("OrderShipping"))
            {
                myorder.Dt_Orders.Columns.Remove("OrderShipping");
            }
            if (myorder.Dt_Orders.Columns.Contains("BillingAddressID"))
            {
                myorder.Dt_Orders.Columns.Remove("BillingAddressID");
            }
            if (myorder.Dt_Orders.Columns.Contains("ShippingAddressID"))
            {
                myorder.Dt_Orders.Columns.Remove("ShippingAddressID");
            }
            if (myorder.Dt_Orders.Columns.Contains("IsCompletlyConvertedToJob"))
            {
                myorder.Dt_Orders.Columns.Remove("IsCompletlyConvertedToJob");
            }
            if (myorder.Dt_Orders.Columns.Contains("EstimateID"))
            {
                myorder.Dt_Orders.Columns.Remove("EstimateID");
            }
            if (myorder.Dt_Orders.Columns.Contains("CompanyID"))
            {
                myorder.Dt_Orders.Columns.Remove("CompanyID");
            }
            if (myorder.Dt_Orders.Columns.Contains("ClientID"))
            {
                myorder.Dt_Orders.Columns.Remove("ClientID");
            }
            if (myorder.Dt_Orders.Columns.Contains("PaymentType"))
            {
                myorder.Dt_Orders.Columns.Remove("PaymentType");
            }
            if (myorder.Dt_Orders.Columns.Contains("createdBy"))
            {
                myorder.Dt_Orders.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Orders.Columns.Contains("createdBy"))
            {
                myorder.Dt_Orders.Columns.Remove("createdBy");
            }
            if (myorder.Dt_Orders.Columns.Contains("OrderAdditionalPrice"))
            {
                myorder.Dt_Orders.Columns.Remove("OrderAdditionalPrice");
            }
            if (myorder.Dt_Orders.Columns.Contains("Tax"))
            {
                myorder.Dt_Orders.Columns.Remove("Tax");
            }
            if (myorder.Dt_Orders.Columns.Contains("EstimatedCompletionDate"))
            {
                myorder.Dt_Orders.Columns.Remove("EstimatedCompletionDate");
            }
            if (myorder.Dt_Orders.Columns.Contains("modulename"))
            {
                myorder.Dt_Orders.Columns.Remove("modulename");
            }
            if (myorder.Dt_Orders.Columns.Contains("ReOrderCheck"))
            {
                myorder.Dt_Orders.Columns.Remove("ReOrderCheck");
            }
            if (myorder.Dt_Orders.Columns[0].ColumnName == "OrderNo")
            {
                myorder.Dt_Orders.Columns[0].ColumnName = "Order Reference";
            }
            if (myorder.Dt_Orders.Columns[1].ColumnName == "OrderDate")
            {
                myorder.Dt_Orders.Columns[1].ColumnName = "Date Raised";
            }
            if (myorder.Dt_Orders.Columns[2].ColumnName == "RequiredBy")
            {
                myorder.Dt_Orders.Columns[2].ColumnName = "Delivery Date";
            }
            if (myorder.Dt_Orders.Columns[3].ColumnName == "quantity")
            {
                myorder.Dt_Orders.Columns[3].ColumnName = "Qty";
            }
            if (myorder.Dt_Orders.Columns[4].ColumnName == "OrderTitle")
            {
                myorder.Dt_Orders.Columns[4].ColumnName = "Title";
            }
            if (myorder.Dt_Orders.Columns[5].ColumnName == "orderStatus")
            {
                myorder.Dt_Orders.Columns[5].ColumnName = "Status";
            }
            if (myorder.Dt_Orders.Columns[6].ColumnName == "TotalPrice")
            {
                myorder.Dt_Orders.Columns[6].ColumnName = "Price Exc. Tax";
            }
            if (myorder.Dt_Orders.Columns[7].ColumnName == "FinalPrice")
            {
                myorder.Dt_Orders.Columns[7].ColumnName = "Price Inc. Tax";
            }
            DataTable dtOrders = myorder.Dt_Orders;
            HttpServerUtility server = base.Server;
            Guid guid = Guid.NewGuid();
            this.ExportData(dtOrders, server.MapPath(string.Concat("./temp/", guid.ToString().Substring(0, 10), "Orders.xlsx")), "Orders.xlsx");
        }

        public void ExportData(DataTable WashedPart, string attachmentName, string Name)
        {
            //WorkBook workbook = new Workbook()
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
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            foreach (DataRow row in dtsearchfilter.Rows)
            {
                if (row["filter"].ToString().ToLower() != "nofilter" && empty1 != "")
                {
                    empty1 = string.Concat(empty1, " and ");
                }
                string lower = row["filter"].ToString().ToLower();
                string str1 = lower;
                if (lower == null)
                {
                    continue;
                }
                if (str1 == "startswith")
                {
                    string str2 = empty1;
                    string[] strArrays = new string[] { str2, " ", row["ColumnName"].ToString(), " like '", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays);
                }
                else if (str1 == "endswith")
                {
                    string str3 = empty1;
                    string[] strArrays1 = new string[] { str3, " ", row["ColumnName"].ToString(), " like '%", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays1);
                }
                else if (str1 == "equalto")
                {
                    string str4 = empty1;
                    string[] strArrays2 = new string[] { str4, " ", row["ColumnName"].ToString(), " = '", row["FilterText"].ToString().Trim(), "'" };
                    empty1 = string.Concat(strArrays2);
                }
                else if (str1 == "contains")
                {
                    string str5 = empty1;
                    string[] strArrays3 = new string[] { str5, " ", row["ColumnName"].ToString(), " like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays3);
                }
                else if (str1 == "doesnotcontain")
                {
                    string str6 = empty1;
                    string[] strArrays4 = new string[] { str6, " ", row["ColumnName"].ToString(), " not like '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays4);
                }
                else if (str1 == "nofilter")
                {
                    string str7 = empty1;
                    string[] strArrays5 = new string[] { str7, " ", row["ColumnName"].ToString(), " > '%", row["FilterText"].ToString().Trim(), "%'" };
                    empty1 = string.Concat(strArrays5);
                }
            }
            return empty1;
        }

        protected void LnkReorder_Click(object semder, CommandEventArgs e)
        {
            foreach (DataRow row in OrderBasePage.Insert_Reorder_Deatil(Convert.ToInt64(e.CommandArgument)).Rows)
            {
                this.TemplateID = row["TemplateID"].ToString();
                DataTable dataTable = OrderBasePage.Insert_Reordered_CartItemsandDetails(Convert.ToInt64(row["CartItemID"]), "", this.StoreUserID);
                if (dataTable.Rows.Count > 0)
                {
                    this.CartItemID = dataTable.Rows[0]["CartItemID"].ToString();
                }
                string str = row["PDFNameFromCart"].ToString();
                if (Convert.ToInt64(this.TemplateID) <= (long)0)
                {
                    continue;
                }
                DataTable dataTable1 = ProductBasePage.Select_PriceCatalogueID(Convert.ToInt64(this.TemplateID));
                if (dataTable1.Rows.Count <= 0)
                {
                    continue;
                }
                DataTable dataTable2 = ProductBasePage.productsDetails_Select(Convert.ToInt16(dataTable1.Rows[0]["PriceCatalogueID"].ToString()));
                if (dataTable2.Rows.Count <= 0 || !(dataTable2.Rows[0]["IsEditableProduct"].ToString().ToLower() == "true") || !(str != ""))
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
                foreach (DataRow row in OrderBasePage.Select_Orders_reeng(this.StoreUserID, this.WhereCondition).Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
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
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("hdnOrderNo");
                ImageButton imageButton = (ImageButton)e.Item.FindControl("LnkReorder");
                int num = Convert.ToInt32(hiddenField1.Value);
                Label label = (Label)e.Item.FindControl("lblOrderDate");
                label.Text = this.comm.Eprint_return_Date_Before_View(label.Text, this.CompanyID, num, false);
                Label label1 = (Label)e.Item.FindControl("lblEstimatedCompletionDate");
                label1.Text = this.comm.Eprint_return_Date_Before_View(label1.Text, this.CompanyID, num, false);
                Label label2 = (Label)e.Item.FindControl("lblFinalPrice");
                label2.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label2.Text), 2, "", false, false, true);
                Label label3 = (Label)e.Item.FindControl("lblTotalPrice");
                label3.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label3.Text), 2, "", false, false, true);
                if (hiddenField2.Value.Contains("JOB") || hiddenField2.Value.Contains("INV"))
                {
                    imageButton.Visible = false;
                }
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.MyOrdergrid.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void MyOrdergrid_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_Orders_reeng(this.StoreUserID, this.WhereCondition);
            myorder.Dt_AllData = dataTable;
            foreach (DataRow row in dataTable.Rows)
            {
                row["ORderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
            }
            this.MyOrdergrid.DataSource = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.MyOrdergrid.AllowPaging = true;
                return;
            }
            this.MyOrdergrid.AllowPaging = false;
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
            GridFilterMenu languageConversion = this.RadGridOrder.FilterMenu;
            for (int j = filterMenu.Items.Count - 1; j >= 0; j--)
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
            GridFilterMenu gridFilterMenu = this.RadGridJob.FilterMenu;
            for (int k = filterMenu.Items.Count - 1; k >= 0; k--)
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
            GridFilterMenu filterMenu1 = this.RadGridInvoice.FilterMenu;
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
        }

        protected void OrderclrFilters_Click(object sender, EventArgs e)
        {
            if (this.RadTabStrip1.SelectedIndex == 0)
            {
                foreach (GridColumn column in this.RadGridOrder.MasterTableView.Columns)
                {
                    column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    column.CurrentFilterValue = string.Empty;
                }
                this.RadGridOrder.MasterTableView.FilterExpression = string.Empty;
                this.RadGridOrder.MasterTableView.Rebind();
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 1)
            {
                foreach (GridColumn empty in this.RadGridJob.MasterTableView.Columns)
                {
                    empty.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    empty.CurrentFilterValue = string.Empty;
                }
                this.RadGridJob.MasterTableView.FilterExpression = string.Empty;
                this.RadGridJob.MasterTableView.Rebind();
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 2)
            {
                foreach (GridColumn gridColumn in this.RadGridInvoice.MasterTableView.Columns)
                {
                    gridColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
                    gridColumn.CurrentFilterValue = string.Empty;
                }
                this.RadGridInvoice.MasterTableView.FilterExpression = string.Empty;
                this.RadGridInvoice.MasterTableView.Rebind();
                return;
            }
            foreach (GridColumn column1 in this.MyOrdergrid.MasterTableView.Columns)
            {
                column1.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column1.CurrentFilterValue = string.Empty;
            }
            this.MyOrdergrid.MasterTableView.FilterExpression = string.Empty;
            this.MyOrdergrid.MasterTableView.Rebind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            this.AllProductsDeletedMSG = this.objLanguage.GetLanguageConversion("All_Products_Deleted_MSG");
            this.ReorderDltdMsg1 = this.objLanguage.GetLanguageConversion("Reorder_Deleted_Msg1");
            this.ReorderDltdMsg2 = this.objLanguage.GetLanguageConversion("Reorder_Deleted_Msg2");
            this.btnOrderclrFilters.Text = this.objLanguage.GetLanguageConversion("Clear_All_Filters");
            this.MyOrdergrid.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.MyOrdergrid.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.MyOrdergrid.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.MyOrdergrid.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.MyOrdergrid.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.MyOrdergrid.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Title");
            this.MyOrdergrid.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.MyOrdergrid.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket");
            this.MyOrdergrid.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket");
            this.RadTabStrip1.Tabs[0].Text = this.objLanguage.GetLanguageConversion("Order");
            this.RadTabStrip1.Tabs[1].Text = this.objLanguage.GetLanguageConversion("Job");
            this.RadTabStrip1.Tabs[2].Text = this.objLanguage.GetLanguageConversion("Invoice");
            this.RadGridOrder.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Action");
            this.RadGridOrder.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridOrder.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridOrder.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridOrder.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridOrder.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Title");
            this.RadGridOrder.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.RadGridOrder.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket");
            this.RadGridOrder.Columns[8].HeaderText = this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket");
            this.RadGridJob.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridJob.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridJob.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridJob.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridJob.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Title");
            this.RadGridJob.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.RadGridJob.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket");
            this.RadGridJob.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket");
            this.RadGridInvoice.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Order_Reference");
            this.RadGridInvoice.Columns[1].HeaderText = this.objLanguage.GetLanguageConversion("Date_Raised");
            this.RadGridInvoice.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Delivery_Date");
            this.RadGridInvoice.Columns[3].HeaderText = this.objLanguage.GetLanguageConversion("Qty");
            this.RadGridInvoice.Columns[4].HeaderText = this.objLanguage.GetLanguageConversion("Title");
            this.RadGridInvoice.Columns[5].HeaderText = this.objLanguage.GetLanguageConversion("Status");
            this.RadGridInvoice.Columns[6].HeaderText = this.objLanguage.GetLanguageConversion("Price_ex_Tax_Without_Bracket");
            this.RadGridInvoice.Columns[7].HeaderText = this.objLanguage.GetLanguageConversion("Price_in_Tax_Without_Bracket");
            this.lnkbtnExport_Order.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnkbtnExport_Job.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.lnkbtnExport_Invoice.Text = this.objLanguage.GetLanguageConversion("Export_To_Excel");
            this.DivOrder1.Style.Add("display", "block");
            this.DivJob.Style.Add("display", "none");
            this.DivInvoice.Style.Add("display", "none");
            this.DivOrder.Style.Add("display", "none");
            if (ConnectionClass.CompanyID != null && ConnectionClass.CompanyID != "")
            {
                this.CompanyID = Convert.ToInt32(ConnectionClass.CompanyID);
            }
            if (ConnectionClass.AccountID != null && ConnectionClass.AccountID != "")
            {
                myorder.AccountID = Convert.ToInt64(ConnectionClass.AccountID);
            }
            base.Title = commonclass.pageTitle("My Orders", Convert.ToInt32(this.CompanyID), Convert.ToInt32(myorder.AccountID));
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
            if (this.comm.GetDisplayValue("IsHome", myorder.AccountID) != "true")
            {
                this.lbl_home.Visible = false;
                this.lbl_spliter.Visible = false;
            }
            else
            {
                this.lbl_home.Text = ConnectionClass.PageName(Convert.ToInt32(this.CompanyID), Convert.ToInt32(myorder.AccountID), 0);
                this.lbl_home.Visible = true;
                this.lbl_spliter.Visible = true;
            }
            if (this.comm.GetDisplayValue("isMyAccount", myorder.AccountID) == "false")
            {
                myorder.isMyAccount = "0";
            }


            if (EprintConfigurationManager.AppSettings["IsHideJobsTab"].ToString() == "true")
            {
                RadTabStrip1.Tabs[1].Style.Add("display", "none");
            }
            if (EprintConfigurationManager.AppSettings["IsHideInvoicesTab"].ToString() == "true")
            {
                RadTabStrip1.Tabs[2].Style.Add("display", "none");
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
                foreach (DataRow row in OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "invoice", this.WhereCondition).Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridInvoice.Rebind();
            }
        }

        protected void RadGridInvoice_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                Label label = (Label)e.Item.FindControl("lblFinalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblTotalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.RadGridInvoice.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridInvoice_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "invoice", this.WhereCondition);
            dataTable.Columns["RequiredBy"].ReadOnly = false;
            dataTable.Columns["OrderDate"].ReadOnly = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["ORderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
            }
            myorder.Dt_Invoice = dataTable;
            this.RadGridInvoice.DataSource = dataTable;
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
                foreach (DataRow row in OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "job", this.WhereCondition).Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridJob.Rebind();
            }
        }

        protected void RadGridJob_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                Convert.ToInt32(hiddenField1.Value);
                Label label = (Label)e.Item.FindControl("lblFinalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblTotalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.RadGridJob.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridJob_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "job", this.WhereCondition);
            dataTable.Columns["RequiredBy"].ReadOnly = false;
            dataTable.Columns["OrderDate"].ReadOnly = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["ORderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
            }
            myorder.Dt_Jobs = dataTable;
            this.RadGridJob.DataSource = dataTable;
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
                foreach (DataRow row in OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "order", this.WhereCondition).Rows)
                {
                    row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                    row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
                }
                this.RadGridOrder.Rebind();
            }
        }

        protected void RadGridOrder_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                GridHeaderItem item = (GridHeaderItem)e.Item;
            }
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnOrderKey");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnCreatedBy");
                this.UserID = Convert.ToInt32(hiddenField1.Value);
                Label label = (Label)e.Item.FindControl("lblFinalPrice");
                label.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label.Text), 2, "", false, false, true);
                Label label1 = (Label)e.Item.FindControl("lblTotalPrice");
                label1.Text = this.comm.Eprint_ReturnFinal_Formated_Amount(this.CompanyID, 0, Convert.ToDecimal(label1.Text), 2, "", false, false, true);
            }
            if (e.Item is GridPagerItem)
            {
                Label languageConversion = (Label)((GridPagerItem)e.Item).FindControl("ChangePageSizeLabel");
                languageConversion.Text = this.objLanguage.GetLanguageConversion("Page_size");
                this.RadGridOrder.PagerStyle.PagerTextFormat = string.Concat("{4} {5} ", this.objLanguage.GetLanguageConversion("items_in"), " {1} ", this.objLanguage.GetLanguageConversion("pages"));
            }
        }

        protected void RadGridOrder_OnNeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (this.Session["StoreUserID"] != null)
            {
                this.StoreUserID = Convert.ToInt64(this.Session["StoreUserID"].ToString());
            }
            DataTable dataTable = OrderBasePage.Select_Orders_Individiually(this.StoreUserID, "order", this.WhereCondition);
            dataTable.Columns["RequiredBy"].ReadOnly = false;
            dataTable.Columns["OrderDate"].ReadOnly = false;
            foreach (DataRow row in dataTable.Rows)
            {
                row["RequiredBy"] = this.comm.Eprint_return_Date_Before_View(row["RequiredBy"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderDate"] = this.comm.Eprint_return_Date_Before_View(row["OrderDate"].ToString(), this.CompanyID, Convert.ToInt32(this.StoreUserID), false);
                row["OrderTitle"] = base.SpecialDecode(row["OrderTitle"].ToString());
                row["orderStatus"] = base.SpecialDecode(row["orderStatus"].ToString());
            }
            this.RadGridOrder.DataSource = dataTable;
            myorder.Dt_Orders = dataTable;
            this.ViewState["dt"] = dataTable;
            if (dataTable.Rows.Count > 0)
            {
                this.RadGridOrder.AllowPaging = true;
                return;
            }
            this.RadGridOrder.AllowPaging = false;
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (this.RadTabStrip1.SelectedIndex == 0)
            {
                this.RadGridOrder.Visible = true;
                this.RadGridJob.Visible = false;
                this.RadGridInvoice.Visible = false;
                this.MyOrdergrid.Visible = false;
                this.DivOrder1.Style.Add("display", "block");
                this.DivJob.Style.Add("display", "none");
                this.DivInvoice.Style.Add("display", "none");
                this.DivOrder.Style.Add("display", "none");
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 1)
            {
                this.RadGridOrder.Visible = false;
                this.RadGridJob.Visible = true;
                this.RadGridInvoice.Visible = false;
                this.MyOrdergrid.Visible = false;
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "block");
                this.DivInvoice.Style.Add("display", "none");
                this.DivOrder.Style.Add("display", "none");
                return;
            }
            if (this.RadTabStrip1.SelectedIndex == 2)
            {
                this.RadGridOrder.Visible = false;
                this.RadGridJob.Visible = false;
                this.RadGridInvoice.Visible = true;
                this.MyOrdergrid.Visible = false;
                this.DivInvoice.Style.Add("display", "block");
                this.DivOrder1.Style.Add("display", "none");
                this.DivJob.Style.Add("display", "none");
                this.DivOrder.Style.Add("display", "none");
            }
        }
    }
}